namespace YTDLPGUI
{
    partial class fmGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tb_URL = new TextBox();
            label1 = new Label();
            tabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            panel_Codec = new Panel();
            combo_ACodec = new ComboBox();
            label3 = new Label();
            combo_MaxRes = new ComboBox();
            combo_VCodec = new ComboBox();
            label9 = new Label();
            label4 = new Label();
            rdo_Custom = new RadioButton();
            rdo_Default = new RadioButton();
            tabPage2 = new TabPage();
            label11 = new Label();
            combo_ConvertBitrate = new ComboBox();
            label10 = new Label();
            combo_ConvertCodec = new ComboBox();
            tabPage3 = new TabPage();
            btn_Update = new Button();
            chk_Subtitle = new CheckBox();
            chk_LiveFromStart = new CheckBox();
            chk_PlayList = new CheckBox();
            chk_Cookies = new CheckBox();
            materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            label_DownloadPath = new Label();
            tb_DownloadPath = new TextBox();
            pictureBox1 = new PictureBox();
            panel_DownloadInfo = new Panel();
            label_Speed = new Label();
            label_ETA = new Label();
            label_Progress = new Label();
            label_Size = new Label();
            label7 = new Label();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label_Title = new Label();
            btn_Download = new MaterialSkin.Controls.MaterialRaisedButton();
            btn_Abort = new MaterialSkin.Controls.MaterialRaisedButton();
            panel1 = new Panel();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel_Codec.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel_DownloadInfo.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tb_URL
            // 
            tb_URL.BackColor = Color.FromArgb(55, 71, 79);
            tb_URL.BorderStyle = BorderStyle.FixedSingle;
            tb_URL.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_URL.ForeColor = Color.White;
            tb_URL.Location = new Point(12, 100);
            tb_URL.Multiline = true;
            tb_URL.Name = "tb_URL";
            tb_URL.ScrollBars = ScrollBars.Vertical;
            tb_URL.Size = new Size(420, 120);
            tb_URL.TabIndex = 0;
            tb_URL.TabStop = false;
            tb_URL.WordWrap = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft JhengHei UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(12, 75);
            label1.Margin = new Padding(3);
            label1.Name = "label1";
            label1.Size = new Size(39, 19);
            label1.TabIndex = 1;
            label1.Text = "網址";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Depth = 0;
            tabControl1.Font = new Font("Segoe UI", 1F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(448, 111);
            tabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(320, 175);
            tabControl1.TabIndex = 2;
            tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel_Codec);
            tabPage1.Controls.Add(rdo_Custom);
            tabPage1.Controls.Add(rdo_Default);
            tabPage1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            tabPage1.Location = new Point(4, 12);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(312, 159);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "VIDEO";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel_Codec
            // 
            panel_Codec.Controls.Add(combo_ACodec);
            panel_Codec.Controls.Add(label3);
            panel_Codec.Controls.Add(combo_MaxRes);
            panel_Codec.Controls.Add(combo_VCodec);
            panel_Codec.Controls.Add(label9);
            panel_Codec.Controls.Add(label4);
            panel_Codec.Location = new Point(6, 76);
            panel_Codec.Name = "panel_Codec";
            panel_Codec.Size = new Size(300, 77);
            panel_Codec.TabIndex = 4;
            // 
            // combo_ACodec
            // 
            combo_ACodec.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_ACodec.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            combo_ACodec.FormattingEnabled = true;
            combo_ACodec.Items.AddRange(new object[] { "mp4a", "opus" });
            combo_ACodec.Location = new Point(207, 44);
            combo_ACodec.Name = "combo_ACodec";
            combo_ACodec.Size = new Size(70, 25);
            combo_ACodec.TabIndex = 7;
            combo_ACodec.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label3.Location = new Point(7, 10);
            label3.Margin = new Padding(10, 10, 3, 3);
            label3.Name = "label3";
            label3.Size = new Size(88, 19);
            label3.TabIndex = 3;
            label3.Text = "最大解析度:";
            // 
            // combo_MaxRes
            // 
            combo_MaxRes.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_MaxRes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            combo_MaxRes.FormattingEnabled = true;
            combo_MaxRes.Items.AddRange(new object[] { "480P", "720P", "1080P", "1440P", "2160P" });
            combo_MaxRes.Location = new Point(101, 8);
            combo_MaxRes.Name = "combo_MaxRes";
            combo_MaxRes.Size = new Size(90, 25);
            combo_MaxRes.TabIndex = 2;
            combo_MaxRes.TabStop = false;
            // 
            // combo_VCodec
            // 
            combo_VCodec.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_VCodec.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            combo_VCodec.FormattingEnabled = true;
            combo_VCodec.Items.AddRange(new object[] { "AVC", "VP9" });
            combo_VCodec.Location = new Point(65, 44);
            combo_VCodec.Name = "combo_VCodec";
            combo_VCodec.Size = new Size(70, 25);
            combo_VCodec.TabIndex = 6;
            combo_VCodec.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label9.Location = new Point(148, 48);
            label9.Margin = new Padding(10, 10, 3, 3);
            label9.Name = "label9";
            label9.Size = new Size(53, 18);
            label9.TabIndex = 5;
            label9.Text = "Audio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label4.Location = new Point(7, 48);
            label4.Margin = new Padding(10, 10, 3, 3);
            label4.Name = "label4";
            label4.Size = new Size(52, 18);
            label4.TabIndex = 4;
            label4.Text = "Video:";
            // 
            // rdo_Custom
            // 
            rdo_Custom.AutoSize = true;
            rdo_Custom.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            rdo_Custom.Location = new Point(13, 48);
            rdo_Custom.Margin = new Padding(10, 10, 10, 3);
            rdo_Custom.Name = "rdo_Custom";
            rdo_Custom.Size = new Size(138, 22);
            rdo_Custom.TabIndex = 1;
            rdo_Custom.Text = "Custom 選擇格式";
            rdo_Custom.UseVisualStyleBackColor = true;
            // 
            // rdo_Default
            // 
            rdo_Default.AutoSize = true;
            rdo_Default.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            rdo_Default.Location = new Point(13, 13);
            rdo_Default.Margin = new Padding(10, 10, 10, 3);
            rdo_Default.Name = "rdo_Default";
            rdo_Default.Size = new Size(136, 22);
            rdo_Default.TabIndex = 0;
            rdo_Default.Text = "Default 預設格式";
            rdo_Default.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(combo_ConvertBitrate);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(combo_ConvertCodec);
            tabPage2.Font = new Font("Microsoft JhengHei UI", 9F);
            tabPage2.Location = new Point(4, 12);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(312, 159);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "AUDIO";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft JhengHei UI", 11.25F, FontStyle.Bold);
            label11.Location = new Point(13, 48);
            label11.Margin = new Padding(10, 10, 3, 3);
            label11.Name = "label11";
            label11.Size = new Size(73, 19);
            label11.TabIndex = 7;
            label11.Text = "轉檔音質:";
            // 
            // combo_ConvertBitrate
            // 
            combo_ConvertBitrate.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_ConvertBitrate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            combo_ConvertBitrate.FormattingEnabled = true;
            combo_ConvertBitrate.Items.AddRange(new object[] { "96K", "128K", "192K", "256K", "320K" });
            combo_ConvertBitrate.Location = new Point(92, 46);
            combo_ConvertBitrate.Name = "combo_ConvertBitrate";
            combo_ConvertBitrate.Size = new Size(100, 25);
            combo_ConvertBitrate.TabIndex = 6;
            combo_ConvertBitrate.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft JhengHei UI", 11.25F, FontStyle.Bold);
            label10.Location = new Point(13, 13);
            label10.Margin = new Padding(10, 10, 3, 3);
            label10.Name = "label10";
            label10.Size = new Size(73, 19);
            label10.TabIndex = 5;
            label10.Text = "轉檔格式:";
            // 
            // combo_ConvertCodec
            // 
            combo_ConvertCodec.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_ConvertCodec.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            combo_ConvertCodec.FormattingEnabled = true;
            combo_ConvertCodec.Items.AddRange(new object[] { "BEST", "AAC", "MP3", "FLAC" });
            combo_ConvertCodec.Location = new Point(92, 11);
            combo_ConvertCodec.Name = "combo_ConvertCodec";
            combo_ConvertCodec.Size = new Size(100, 25);
            combo_ConvertCodec.TabIndex = 4;
            combo_ConvertCodec.TabStop = false;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btn_Update);
            tabPage3.Controls.Add(chk_Subtitle);
            tabPage3.Controls.Add(chk_LiveFromStart);
            tabPage3.Controls.Add(chk_PlayList);
            tabPage3.Controls.Add(chk_Cookies);
            tabPage3.Font = new Font("Microsoft JhengHei UI", 9F);
            tabPage3.Location = new Point(4, 12);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(312, 159);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "OPTION";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_Update
            // 
            btn_Update.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 136);
            btn_Update.ForeColor = Color.Firebrick;
            btn_Update.Location = new Point(80, 118);
            btn_Update.Margin = new Padding(80, 3, 80, 5);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(152, 36);
            btn_Update.TabIndex = 5;
            btn_Update.TabStop = false;
            btn_Update.Text = "UPDATE";
            btn_Update.UseVisualStyleBackColor = true;
            btn_Update.Click += btn_Update_Click;
            // 
            // chk_Subtitle
            // 
            chk_Subtitle.AutoSize = true;
            chk_Subtitle.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            chk_Subtitle.Location = new Point(165, 48);
            chk_Subtitle.Margin = new Padding(10, 10, 10, 3);
            chk_Subtitle.Name = "chk_Subtitle";
            chk_Subtitle.Size = new Size(111, 22);
            chk_Subtitle.TabIndex = 3;
            chk_Subtitle.Text = "下載字幕檔案";
            chk_Subtitle.UseVisualStyleBackColor = true;
            // 
            // chk_LiveFromStart
            // 
            chk_LiveFromStart.AutoSize = true;
            chk_LiveFromStart.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            chk_LiveFromStart.Location = new Point(13, 48);
            chk_LiveFromStart.Margin = new Padding(10, 10, 10, 3);
            chk_LiveFromStart.Name = "chk_LiveFromStart";
            chk_LiveFromStart.Size = new Size(111, 22);
            chk_LiveFromStart.TabIndex = 2;
            chk_LiveFromStart.Text = "下載完整直播";
            chk_LiveFromStart.UseVisualStyleBackColor = true;
            // 
            // chk_PlayList
            // 
            chk_PlayList.AutoSize = true;
            chk_PlayList.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            chk_PlayList.Location = new Point(165, 13);
            chk_PlayList.Margin = new Padding(10, 10, 10, 3);
            chk_PlayList.Name = "chk_PlayList";
            chk_PlayList.Size = new Size(111, 22);
            chk_PlayList.TabIndex = 1;
            chk_PlayList.Text = "下載播放清單";
            chk_PlayList.UseVisualStyleBackColor = true;
            // 
            // chk_Cookies
            // 
            chk_Cookies.AutoSize = true;
            chk_Cookies.Checked = true;
            chk_Cookies.CheckState = CheckState.Checked;
            chk_Cookies.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            chk_Cookies.Location = new Point(13, 13);
            chk_Cookies.Margin = new Padding(10, 10, 10, 3);
            chk_Cookies.Name = "chk_Cookies";
            chk_Cookies.Size = new Size(132, 22);
            chk_Cookies.TabIndex = 0;
            chk_Cookies.Text = "使用 cookies.txt";
            chk_Cookies.UseVisualStyleBackColor = true;
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.BaseTabControl = tabControl1;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Location = new Point(448, 75);
            materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new Size(320, 30);
            materialTabSelector1.TabIndex = 0;
            materialTabSelector1.TabStop = false;
            materialTabSelector1.Text = "materialTabSelector1";
            // 
            // label_DownloadPath
            // 
            label_DownloadPath.AutoSize = true;
            label_DownloadPath.BackColor = Color.Transparent;
            label_DownloadPath.Cursor = Cursors.Hand;
            label_DownloadPath.Font = new Font("Microsoft JhengHei UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label_DownloadPath.ForeColor = Color.Firebrick;
            label_DownloadPath.Location = new Point(12, 234);
            label_DownloadPath.Margin = new Padding(3);
            label_DownloadPath.Name = "label_DownloadPath";
            label_DownloadPath.Size = new Size(113, 19);
            label_DownloadPath.TabIndex = 3;
            label_DownloadPath.Text = "下載位置 (開啟)";
            // 
            // tb_DownloadPath
            // 
            tb_DownloadPath.BackColor = Color.FromArgb(55, 71, 79);
            tb_DownloadPath.BorderStyle = BorderStyle.FixedSingle;
            tb_DownloadPath.Cursor = Cursors.Hand;
            tb_DownloadPath.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_DownloadPath.ForeColor = Color.White;
            tb_DownloadPath.Location = new Point(12, 259);
            tb_DownloadPath.Name = "tb_DownloadPath";
            tb_DownloadPath.Size = new Size(420, 23);
            tb_DownloadPath.TabIndex = 4;
            tb_DownloadPath.TabStop = false;
            tb_DownloadPath.MouseClick += tb_DownloadPath_MouseClick;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(16, 20);
            pictureBox1.Margin = new Padding(20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(260, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // panel_DownloadInfo
            // 
            panel_DownloadInfo.BackColor = Color.White;
            panel_DownloadInfo.Controls.Add(label_Speed);
            panel_DownloadInfo.Controls.Add(label_ETA);
            panel_DownloadInfo.Controls.Add(label_Progress);
            panel_DownloadInfo.Controls.Add(label_Size);
            panel_DownloadInfo.Controls.Add(label7);
            panel_DownloadInfo.Controls.Add(label8);
            panel_DownloadInfo.Controls.Add(label6);
            panel_DownloadInfo.Controls.Add(label5);
            panel_DownloadInfo.Controls.Add(label_Title);
            panel_DownloadInfo.Location = new Point(300, 20);
            panel_DownloadInfo.Name = "panel_DownloadInfo";
            panel_DownloadInfo.Size = new Size(440, 135);
            panel_DownloadInfo.TabIndex = 6;
            panel_DownloadInfo.Visible = false;
            // 
            // label_Speed
            // 
            label_Speed.AutoSize = true;
            label_Speed.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            label_Speed.ForeColor = Color.FromArgb(78, 154, 6);
            label_Speed.Location = new Point(283, 74);
            label_Speed.Margin = new Padding(3);
            label_Speed.Name = "label_Speed";
            label_Speed.Size = new Size(72, 18);
            label_Speed.TabIndex = 9;
            label_Speed.Text = "0.0 MiB/s";
            // 
            // label_ETA
            // 
            label_ETA.AutoSize = true;
            label_ETA.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            label_ETA.ForeColor = Color.FromArgb(196, 160, 0);
            label_ETA.Location = new Point(283, 102);
            label_ETA.Margin = new Padding(3);
            label_ETA.Name = "label_ETA";
            label_ETA.Size = new Size(44, 18);
            label_ETA.TabIndex = 8;
            label_ETA.Text = "00:00";
            // 
            // label_Progress
            // 
            label_Progress.AutoSize = true;
            label_Progress.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            label_Progress.ForeColor = Color.FromArgb(114, 159, 207);
            label_Progress.Location = new Point(73, 102);
            label_Progress.Margin = new Padding(3);
            label_Progress.Name = "label_Progress";
            label_Progress.Size = new Size(29, 18);
            label_Progress.TabIndex = 7;
            label_Progress.Text = "0%";
            // 
            // label_Size
            // 
            label_Size.AutoSize = true;
            label_Size.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            label_Size.ForeColor = Color.DimGray;
            label_Size.Location = new Point(73, 74);
            label_Size.Margin = new Padding(3);
            label_Size.Name = "label_Size";
            label_Size.Size = new Size(59, 18);
            label_Size.TabIndex = 6;
            label_Size.Text = "0.0 MiB";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            label7.ForeColor = Color.Firebrick;
            label7.Location = new Point(213, 74);
            label7.Margin = new Padding(3, 10, 3, 10);
            label7.Name = "label7";
            label7.Size = new Size(64, 18);
            label7.TabIndex = 5;
            label7.Text = "下載速度";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            label8.ForeColor = Color.Firebrick;
            label8.Location = new Point(213, 102);
            label8.Margin = new Padding(3, 10, 3, 10);
            label8.Name = "label8";
            label8.Size = new Size(64, 18);
            label8.TabIndex = 4;
            label8.Text = "剩餘時間";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.Firebrick;
            label6.Location = new Point(3, 102);
            label6.Margin = new Padding(3, 10, 3, 10);
            label6.Name = "label6";
            label6.Size = new Size(64, 18);
            label6.TabIndex = 3;
            label6.Text = "下載進度";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.Firebrick;
            label5.Location = new Point(3, 74);
            label5.Margin = new Padding(3, 10, 3, 10);
            label5.Name = "label5";
            label5.Size = new Size(64, 18);
            label5.TabIndex = 2;
            label5.Text = "檔案大小";
            // 
            // label_Title
            // 
            label_Title.Cursor = Cursors.Hand;
            label_Title.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
            label_Title.ForeColor = Color.Firebrick;
            label_Title.Location = new Point(3, 3);
            label_Title.Margin = new Padding(3);
            label_Title.Name = "label_Title";
            label_Title.Size = new Size(434, 58);
            label_Title.TabIndex = 1;
            // 
            // btn_Download
            // 
            btn_Download.AutoSize = true;
            btn_Download.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Download.Cursor = Cursors.Hand;
            btn_Download.Depth = 0;
            btn_Download.Icon = Properties.Resources.download;
            btn_Download.Location = new Point(513, 161);
            btn_Download.Margin = new Padding(5, 3, 5, 14);
            btn_Download.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Download.Name = "btn_Download";
            btn_Download.Primary = true;
            btn_Download.Size = new Size(124, 36);
            btn_Download.TabIndex = 7;
            btn_Download.Text = "DOWNLOAD";
            btn_Download.UseVisualStyleBackColor = true;
            btn_Download.Click += btn_Download_Click;
            // 
            // btn_Abort
            // 
            btn_Abort.AutoSize = true;
            btn_Abort.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Abort.Cursor = Cursors.Hand;
            btn_Abort.Depth = 0;
            btn_Abort.Icon = Properties.Resources.stop;
            btn_Abort.Location = new Point(647, 161);
            btn_Abort.Margin = new Padding(5, 3, 14, 14);
            btn_Abort.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Abort.Name = "btn_Abort";
            btn_Abort.Primary = true;
            btn_Abort.Size = new Size(93, 36);
            btn_Abort.TabIndex = 8;
            btn_Abort.Text = "ABORT";
            btn_Abort.UseVisualStyleBackColor = true;
            btn_Abort.Click += btn_Abort_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btn_Abort);
            panel1.Controls.Add(panel_DownloadInfo);
            panel1.Controls.Add(btn_Download);
            panel1.Location = new Point(12, 298);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(756, 213);
            panel1.TabIndex = 9;
            // 
            // fmGUI
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 520);
            Controls.Add(panel1);
            Controls.Add(tb_DownloadPath);
            Controls.Add(label_DownloadPath);
            Controls.Add(materialTabSelector1);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Controls.Add(tb_URL);
            Font = new Font("Microsoft JhengHei UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fmGUI";
            Opacity = 0.95D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "yt-dlp GUI";
            Load += fmGUI_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            panel_Codec.ResumeLayout(false);
            panel_Codec.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel_DownloadInfo.ResumeLayout(false);
            panel_DownloadInfo.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_URL;
        private Label label1;
        private MaterialSkin.Controls.MaterialTabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private TabPage tabPage3;
        private Label label_DownloadPath;
        private TextBox tb_DownloadPath;
        private PictureBox pictureBox1;
        private Panel panel_DownloadInfo;
        private Label label_Title;
        private Label label7;
        private Label label8;
        private Label label6;
        private Label label5;
        private Label label_Progress;
        private Label label_Size;
        private Label label_Speed;
        private Label label_ETA;
        private MaterialSkin.Controls.MaterialRaisedButton btn_Download;
        private MaterialSkin.Controls.MaterialRaisedButton btn_Abort;
        private RadioButton rdo_Default;
        private RadioButton rdo_Custom;
        private Label label3;
        private ComboBox combo_MaxRes;
        private Panel panel_Codec;
        private Label label4;
        private Label label9;
        private ComboBox combo_ACodec;
        private ComboBox combo_VCodec;
        private Label label11;
        private ComboBox combo_ConvertBitrate;
        private Label label10;
        private ComboBox combo_ConvertCodec;
        private Panel panel1;
        private CheckBox chk_Cookies;
        private CheckBox chk_PlayList;
        private CheckBox chk_LiveFromStart;
        private CheckBox chk_Subtitle;
        private Button btn_Update;
    }
}
