using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace YTDLPGUI.Utils
{
    internal class YTDLP
    {
        public class Option
        {
            // 一般設定
            public static string? DownloadPath { get; set; }
            public static bool UseCookies { get; set; }
            public static bool PlayList { get; set; }
            public static bool LiveFromStart { get; set; }
            public static bool Subtitle { get; set; }


            // 選擇下載 影片=0 音樂=1
            public static int TabIndex { get; set; }

            // 影片下載設定
            public static bool VideoDefault { get; set; }
            public static bool VideoCustom { get; set; }
            public static string VideoMaxRes { get; set; } = "1080";
            public static string VideoCodec { get; set; } = "avc1";
            public static string AudioCodec { get; set; } = "mp4a";

            // 音樂下載設定
            public static string ConvertFormat { get; set; } = "best";
            public static string ConvertBitrate { get; set; } = "192K";
        }

        public class Info
        {
            [JsonPropertyName("id")]
            public required string Id { get; set; }
            [JsonPropertyName("title")]
            public required string Title { get; set; }
            [JsonPropertyName("original_url")]
            public required string Url { get; set; }
        }

        private static fmGUI? _gui;
        public static List<Process> Pool = new List<Process>();
        public static ConcurrentQueue<Info> infoQueue = new ConcurrentQueue<Info>();
        private static (string frag, long size) liveAudio;
        private static (string frag, long size) liveVideo;

        public static void Initialize(fmGUI gui)
        {
            _gui = gui;
        }

        public static string GetArguments(string url)
        {
            var sb = new StringBuilder();

            sb.Append($"\"{url}\" ");

            // General Options
            sb.Append("--ignore-config ");
            if (Option.LiveFromStart)
                sb.Append("--live-from-start ");

            // Video Selection
            if (Option.PlayList)
                sb.Append("--yes-playlist ");
            else
                sb.Append("--no-playlist ");

            // Download Options
            sb.Append("--concurrent-fragments 3 ");
            sb.Append("--retry-sleep 5 ");

            // Filesystem Options
            sb.Append($"-P \"{Option.DownloadPath}\" ");
            sb.Append("-o \"%(title)s.%(ext)s\" ");
            sb.Append("--windows-filenames ");
            if (Option.UseCookies)
                sb.Append("--cookies cookies.txt ");

            // Verbosity and Simulation Options
            sb.Append("--newline ");
            //sb.Append("--progress-delta 0.05 ");

            // Workarounds
            sb.Append("--encoding UTF-8 ");

            // Subtitle Options
            if (Option.Subtitle)
            {
                sb.Append("--write-subs ");
                sb.Append("--sub-langs \"en,zh-Hant,-live_chat\" ");
                sb.Append("--embed-subs ");
                sb.Append("--convert-subs vtt ");
            }

            // Post-Processing Options
            //sb.Append("--limit-rate 1M ");
            sb.Append("--embed-thumbnail ");
            sb.Append("--embed-metadata ");
            sb.Append("--embed-chapters ");
            sb.Append("--convert-thumbnails jpg ");
            sb.Append("--ppa \"ThumbnailsConvertor:-q:v 1\" ");
            sb.Append("--parse-metadata \":(?P<meta_synopsis>)\" ");
            sb.Append("--parse-metadata \":(?P<meta_purl>)\" ");

            // Extractor Options
            sb.Append("--extractor-args \"youtube:lang=zh-TW;player_client=web_music,default;player_skip=configs\" ");
            //sb.Append("--extractor-args \"youtubepot-bgutilhttp:base_url=http://138.2.49.28:4321\" ");

            if (Option.TabIndex == 0)
            {
                if (Option.VideoDefault)
                {
                    sb.Append($"-f ba+bv ");
                }
                else if (Option.VideoCustom)
                {
                    sb.Append($"-f ba[acodec^={Option.AudioCodec}]+");
                    sb.Append($"bv[height<={Option.VideoMaxRes}]");
                    sb.Append($"[vcodec^={Option.VideoCodec}]/ba+bv ");
                }
            }
            else if (Option.TabIndex == 1)
            {
                sb.Append("-f ba ");
                sb.Append("--extract-audio ");
                sb.Append($"--audio-format {Option.ConvertFormat} ");
                switch (Option.ConvertFormat)
                {
                    case "mp3":
                    case "aac":
                        sb.Append($"--audio-quality {Option.ConvertBitrate} ");
                        break;
                    case "flac":
                    case "best":
                        break;
                }
            }

            var args = sb.ToString();
            Debug.WriteLine(args);

            return args;
        }

        public static async Task GetInfo(string url)
        {
            var sb = new StringBuilder();
            sb.Append($"\"{url}\" ");
            sb.Append("--ignore-config ");
            sb.Append("--cookies cookies.txt ");
            sb.Append("--dump-json ");
            sb.Append("--encoding UTF-8 ");
            sb.Append("--extractor-args \"youtube:player_client=web;player_skip=configs\" ");
            var args = sb.ToString();

            var p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "yt-dlp.exe",
                    Arguments = args,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    StandardOutputEncoding = Encoding.UTF8,
                }
            };

            p.OutputDataReceived += (sender, e) =>
            {
                var line = e.Data;
                Debug.WriteLine(line);
                if (string.IsNullOrEmpty(line)) return;
                try
                {
                    var info = JsonSerializer.Deserialize<Info>(line);
                    if (info == null) return;
                    infoQueue.Enqueue(info);
                }
                catch { }
            };

            p.Start();
            p.BeginOutputReadLine();

            Pool.Add(p);
            await p.WaitForExitAsync().ConfigureAwait(false);
            Pool.Remove(p);
        }

        public static async Task Download(string url)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "yt-dlp.exe",
                    Arguments = GetArguments(url),
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    StandardOutputEncoding = Encoding.UTF8,
                }
            };

            p.OutputDataReceived += (sender, e) =>
            {
                var line = e.Data;
                Debug.WriteLine(line);
                if (string.IsNullOrEmpty(line)) return;
                UpdateProgress(line);
            };

            p.Start();
            p.BeginOutputReadLine();

            Pool.Add(p);
            await p.WaitForExitAsync().ConfigureAwait(false);
            Pool.Remove(p);
        }

        public static void UpdateProgress(string text)
        {
            // 一般下載 [download]  10.3% of   97.47MiB at 1011.35KiB/s ETA 01:28
            var m = Regex.Match(text, @"(\d+.?\d%)\D+(\d+.?\d+\wiB)\D+(\d+.?\d+\wiB\/s)\D+(\d+:\d+)");
            if (m.Success)
            {
                _gui?.UpdateProgress(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value, m.Groups[4].Value);
                return;
            }

            // 直播下載 2: [download]    4.07MiB at  599.10KiB/s (00:00:08) (frag 9)
            m = Regex.Match(text, @"(\d)\D+(\d+.?\d+\wiB)\D+(\d+.?\d+\wiB\/s).+(frag ?\d+)");
            if (m.Success)
            {
                var idx = m.Groups[1].Value;
                var size = Helper.GetSize(m.Groups[2].Value);
                var speed = m.Groups[3].Value;
                var frag = m.Groups[4].Value.Replace("frag ", "");

                if (idx.Equals("1")) // audio fragment
                {
                    liveAudio = (frag, size);
                }
                if (idx.Equals("2")) // video fragment
                {
                    liveVideo = (frag, size);
                }

                _gui?.UpdateProgress($"frag: {liveVideo.frag}, {liveAudio.frag}", Helper.FormatSize(liveVideo.size + liveAudio.size), speed);
            }
        }
    }
}
