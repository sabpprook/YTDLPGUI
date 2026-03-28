using System.IO.Compression;

namespace YTDLPGUI
{
    public partial class fmBinary : Form
    {
        private string YTDLP = "https://github.com/yt-dlp/yt-dlp-master-builds/releases/latest/download/yt-dlp.exe";
        private string FFMPEG = "https://github.com/BtbN/FFmpeg-Builds/releases/latest/download/ffmpeg-n8.0-latest-win64-gpl-8.0.zip";
        private string DENO = "https://github.com/denoland/deno/releases/latest/download/deno-x86_64-pc-windows-msvc.zip";

        public fmBinary()
        {
            InitializeComponent();
        }

        private async void fmBinary_Load(object sender, EventArgs e)
        {
            var showWindows = () => WindowState = FormWindowState.Normal;
            var task = new List<Task>();

            if (!File.Exists("yt-dlp.exe"))
            {
                showWindows();
                var progress = new Progress<int>(value =>
                {
                    progressBar1.Value = value;
                    progressBar1.Update();
                });
                var dl = new Utils.FastDL(YTDLP);
                await dl.DownloadFileAsync("tmp_1", progress: progress);
                File.Move("tmp_1", "yt-dlp.exe");
            }

            if (!File.Exists("ffmpeg.exe") || !File.Exists("ffprobe.exe"))
            {
                showWindows();
                var progress = new Progress<int>(value =>
                {
                    progressBar2.Value = value;
                    progressBar2.Update();
                });
                var dl = new Utils.FastDL(FFMPEG);
                await dl.DownloadFileAsync("tmp_2", progress: progress);
                using (var archive = ZipFile.OpenRead("tmp_2"))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith("ffmpeg.exe"))
                            await Task.Run(() => entry.ExtractToFile("ffmpeg.exe", true));

                        if (entry.FullName.EndsWith("ffprobe.exe"))
                            await Task.Run(() => entry.ExtractToFile("ffprobe.exe", true));
                    }
                }
                File.Delete("tmp_2");
            }

            if (!File.Exists("deno.exe"))
            {
                showWindows();
                var progress = new Progress<int>(value =>
                {
                    progressBar3.Value = value;
                    progressBar3.Update();
                });
                var dl = new Utils.FastDL(DENO);
                await dl.DownloadFileAsync("tmp_3", progress: progress);
                using (var archive = ZipFile.OpenRead("tmp_3"))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith("deno.exe"))
                            await Task.Run(() => entry.ExtractToFile("deno.exe", true));
                    }
                }
                File.Delete("tmp_3");
            }

            if (File.Exists("yt-dlp.exe") &&
                File.Exists("ffmpeg.exe") &&
                File.Exists("ffprobe.exe") &&
                File.Exists("deno.exe"))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("下載執行檔時發生錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Abort;
            }
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            panelTitle.Tag = new Point(e.X, e.Y);
        }

        private void panelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            panelTitle.Tag = string.Empty;
        }

        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (panelTitle.Tag is Point tag)
            {
                this.Location = new Point(this.Left + e.X - tag.X, this.Top + e.Y - tag.Y);
            }
        }
    }
}
