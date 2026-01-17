using System.Collections.Concurrent;
using System.Net;
using System.Net.Http.Headers;

namespace YTDLPGUI.Utils
{
    internal class FastDL : IDisposable
    {
        internal class Chunk
        {
            public long From { get; set; }
            public long To { get; set; }
            public int RetryCount { get; set; }
        }

        const long _chunkSize = 512 * 1024; // 512 KB;
        const int _maxRetry = 5;
        const int _maxConcurrency = 8;

        readonly Uri _baseUri;
        readonly HttpClient _client;
        readonly ConcurrentQueue<Chunk> _downloadQueue;

        long _totalBytes;
        long _downloadedBytes;

        public FastDL(string url)
        {
            _baseUri = new Uri(url);
            _client = new HttpClient
            {
                DefaultRequestVersion = HttpVersion.Version11,
                DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher,
                Timeout = TimeSpan.FromSeconds(30)
            };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            _client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
            _downloadQueue = new ConcurrentQueue<Chunk>();
        }

        public async Task DownloadFileAsync(string filename, CancellationToken cancellationToken = default, IProgress<int>? progress = null)
        {
            await GetContentLength(cancellationToken).ConfigureAwait(false);
            if (_totalBytes == 0)
            {
                throw new InvalidOperationException("Content length is not provided by the server.");
            }

            using var fileStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan);
            fileStream.SetLength(_totalBytes);

            for (long i = 0; i < _totalBytes; i += _chunkSize)
            {
                _downloadQueue.Enqueue(new Chunk
                {
                    From = i,
                    To = Math.Min(i + _chunkSize - 1, _totalBytes - 1),
                    RetryCount = 0
                });
            }

            var workers = new Task[_maxConcurrency];
            for (int i = 0; i < _maxConcurrency; i++)
            {
                workers[i] = Task.Run(async () =>
                {
                    while (!cancellationToken.IsCancellationRequested && _downloadQueue.TryDequeue(out var chunk))
                    {
                        bool success = false;
                        while (!success && chunk.RetryCount <= _maxRetry)
                        {
                            try
                            {
                                var data = await GetRangeBytes(chunk.From, chunk.To, cancellationToken).ConfigureAwait(false);
                                await RandomAccess.WriteAsync(fileStream.SafeFileHandle, data, chunk.From, cancellationToken).ConfigureAwait(false);

                                Interlocked.Add(ref _downloadedBytes, data.Length);
                                var bytes = Interlocked.Read(ref _downloadedBytes);

                                var value = (int)(bytes * 100 / _totalBytes);
                                progress?.Report(value);

                                success = true;
                            }
                            catch
                            {
                                chunk.RetryCount++;
                                if (chunk.RetryCount > _maxRetry)
                                {
                                    throw;
                                }
                                await Task.Delay(200, cancellationToken).ConfigureAwait(false);
                            }
                        }
                    }
                }, cancellationToken);
            }

            await Task.WhenAll(workers).ConfigureAwait(false);
        }

        private async Task GetContentLength(CancellationToken cancellationToken)
        {
            using var req = new HttpRequestMessage(HttpMethod.Head, _baseUri);
            req.Version = HttpVersion.Version20;
            req.VersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;

            using var resp = await _client.SendAsync(req, cancellationToken).ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();
            
            if (resp.Content.Headers.ContentLength.HasValue)
            {
                _totalBytes = resp.Content.Headers.ContentLength.Value;
            }
        }

        private async Task<byte[]> GetRangeBytes(long from, long to, CancellationToken cancellationToken)
        {
            using var req = new HttpRequestMessage(HttpMethod.Get, _baseUri);
            req.Version = HttpVersion.Version20;
            req.VersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
            req.Headers.Range = new RangeHeaderValue(from, to);

            using var resp = await _client.SendAsync(req, cancellationToken).ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();

            return await resp.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
