using System.Diagnostics;
using YTDLPGUI.Utils;

namespace YTDLPGUI
{
    public partial class fmGUI : MaterialSkin.Controls.MaterialForm
    {
        public fmGUI()
        {
            InitializeComponent();

            var skin = MaterialSkin.MaterialSkinManager.Instance;
            skin.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skin.ColorScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.Red800,
                MaterialSkin.Primary.Red800,
                MaterialSkin.Primary.Red800,
                MaterialSkin.Accent.LightBlue200,
                MaterialSkin.TextShade.WHITE
            );
            skin.AddFormToManage(this);

            YTDLP.Initialize(this);

            Icon = Properties.Resources.main;

            label_DownloadPath.MouseClick += (s, ev) => Process.Start("explorer.exe", tb_DownloadPath.Text);
            tabControl1.SelectedIndexChanged += (s, ev) =>
            {
                var idx = tabControl1.SelectedIndex;
                btn_Download.Visible = btn_Abort.Visible = idx < 2;

            };

            rdo_Default.CheckedChanged += (s, ev) => panel_Codec.Visible = rdo_Custom.Checked;
            rdo_Custom.CheckedChanged += (s, ev) => panel_Codec.Visible = rdo_Custom.Checked;

            combo_ConvertCodec.SelectedIndexChanged += (s, ev) =>
            {
                var idx = combo_ConvertCodec.SelectedIndex;
                combo_ConvertBitrate.Enabled = idx == 1 || idx == 2;
            };

            label_Title.MouseClick += (s, ev) =>
            {
                var tag = label_Title.Tag?.ToString();
                if (string.IsNullOrEmpty(tag)) return;
                Process.Start(new ProcessStartInfo(tag) { UseShellExecute = true });
            };
        }


        private void fmGUI_Load(object sender, EventArgs e)
        {
            // 下載必要的執行檔
            using var fm = new fmBinary();
            if (fm.ShowDialog() != DialogResult.OK)
            {
                Close();
            }

            if (File.Exists("YTDLPGUI.bak"))
                File.Delete("YTDLPGUI.bak");

            // 設定下載資料夾
            var _downloadPath = Properties.Settings.Default.DownloadPath;
            if (string.IsNullOrEmpty(_downloadPath))
                _downloadPath = Path.GetDirectoryName(Environment.ProcessPath);
            tb_DownloadPath.Text = _downloadPath;

            // 預設UI參數
            rdo_Default.Checked = true;
            combo_MaxRes.SelectedIndex = 2;
            combo_VCodec.SelectedIndex = 0;
            combo_ACodec.SelectedIndex = 0;
            combo_ConvertCodec.SelectedIndex = 0;
            combo_ConvertBitrate.SelectedIndex = 2;
        }

        private void tb_DownloadPath_MouseClick(object sender, MouseEventArgs e)
        {
            using var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_DownloadPath.Text = fbd.SelectedPath;
                Properties.Settings.Default.DownloadPath = fbd.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void SetOptions()
        {
            YTDLP.Option.DownloadPath = tb_DownloadPath.Text;
            YTDLP.Option.UseCookies = chk_Cookies.Checked;
            YTDLP.Option.PlayList = chk_PlayList.Checked;
            YTDLP.Option.LiveFromStart = chk_LiveFromStart.Checked;
            YTDLP.Option.Subtitle = chk_Subtitle.Checked;
            YTDLP.Option.TabIndex = tabControl1.SelectedIndex;
            YTDLP.Option.VideoDefault = rdo_Default.Checked;
            YTDLP.Option.VideoCustom = rdo_Custom.Checked;
            YTDLP.Option.VideoMaxRes = combo_MaxRes.Text.TrimEnd('P');
            YTDLP.Option.VideoCodec = combo_VCodec.Text.ToLower();
            YTDLP.Option.AudioCodec = combo_ACodec.Text.ToLower();
            YTDLP.Option.ConvertFormat = combo_ConvertCodec.Text.ToLower();
            YTDLP.Option.ConvertBitrate = combo_ConvertBitrate.Text;
        }

        private async void btn_Download_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = null;
            pictureBox1.ImageLocation = null;
            UpdateProgress();

            SetOptions();

            btn_Download.Enabled = false;

            foreach (var line in tb_URL.Lines)
            {
                if (string.IsNullOrEmpty(line)) continue;

                var t = YTDLP.GetInfo(line);

                while (!t.IsCompleted || YTDLP.infoQueue.Count > 0)
                {
                    if (YTDLP.infoQueue.TryDequeue(out var info))
                    {
                        panel_DownloadInfo.Visible = true;
                        pictureBox1.ImageLocation = $"https://i.ytimg.com/vi/{info.Id}/hqdefault.jpg";
                        label_Title.Text = info.Title;
                        label_Title.Tag = info.Url;
                        await YTDLP.Download(info.Id);
                    }
                    await Task.Delay(500);
                }
            }

            btn_Download.Enabled = true;
        }

        private void btn_Abort_Click(object sender, EventArgs e)
        {
            try
            {
                YTDLP.Pool.ForEach(p => p.Kill(true));
            }
            catch
            {
            }
        }

        public void UpdateProgress(string progress = "", string size = "", string speed = "", string eta = "")
        {
            Invoke(new Action(() =>
            {
                label_Progress.Text = progress;
                label_Size.Text = size;
                label_Speed.Text = speed;
                label_ETA.Text = eta;
            }));
        }

        private async void btn_Update_Click(object sender, EventArgs e)
        {
            btn_Update.Enabled = false;

            var url = "https://github.com/sabpprook/YTDLPGUI/releases/latest/download/YTDLPGUI.exe";
            var t = new FastDL(url).DownloadFileAsync("tmp");
            await t.WaitAsync(TimeSpan.FromSeconds(30));
            if (t.IsCompletedSuccessfully)
            {
                File.Move("YTDLPGUI.exe", "YTDLPGUI.bak", true);
                File.Move("tmp", "YTDLPGUI.exe", true);
            }

            if (MessageBox.Show("是否更新下列檔案\n\n  yt-dlp.exe\n  ffmpeg.exe\n  ffprobe.exe\n  deno.exe", "", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (File.Exists("yt-dlp.exe"))
                    File.Delete("yt-dlp.exe");

                if (File.Exists("ffmpeg.exe"))
                    File.Delete("ffmpeg.exe");

                if (File.Exists("ffprobe.exe"))
                    File.Delete("ffprobe.exe");

                if (File.Exists("deno.exe"))
                    File.Delete("deno.exe");
            }

            Application.Restart();
        }
    }
}
