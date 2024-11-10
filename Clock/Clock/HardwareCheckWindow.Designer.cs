namespace Clock
{
	// Token: 0x02000023 RID: 35
	public partial class HardwareCheckWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06000376 RID: 886 RVA: 0x0002D930 File Offset: 0x0002BB30
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0002D950 File Offset: 0x0002BB50
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.HardwareCheckWindow));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.numericUpDownUsbOut = new global::System.Windows.Forms.NumericUpDown();
			this.hScrollBarUsbOut = new global::System.Windows.Forms.HScrollBar();
			this.pictureBoxButtonUsbOut = new global::System.Windows.Forms.PictureBox();
			this.labelUsbOut = new global::System.Windows.Forms.Label();
			this.connectWarningLabel = new global::System.Windows.Forms.Label();
			this.pictureBoxConnectIcon = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonSound = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonLED = new global::System.Windows.Forms.PictureBox();
			this.radioButtonLEDBlue = new global::System.Windows.Forms.RadioButton();
			this.radioButtonLEDGreen = new global::System.Windows.Forms.RadioButton();
			this.radioButtonLEDRed = new global::System.Windows.Forms.RadioButton();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.labelUsbIn = new global::System.Windows.Forms.Label();
			this.labelUsbInText = new global::System.Windows.Forms.Label();
			this.labelSound = new global::System.Windows.Forms.Label();
			this.labelLightValue = new global::System.Windows.Forms.Label();
			this.labelLight = new global::System.Windows.Forms.Label();
			this.labelTopButton = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownUsbOut).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonUsbOut).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxConnectIcon).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonSound).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonLED).BeginInit();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxObi);
			this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer1.Panel2.Controls.Add(this.numericUpDownUsbOut);
			this.splitContainer1.Panel2.Controls.Add(this.hScrollBarUsbOut);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonUsbOut);
			this.splitContainer1.Panel2.Controls.Add(this.labelUsbOut);
			this.splitContainer1.Panel2.Controls.Add(this.connectWarningLabel);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxConnectIcon);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonSound);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonLED);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonLEDBlue);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonLEDGreen);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonLEDRed);
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Size = new global::System.Drawing.Size(540, 441);
			this.splitContainer1.SplitterDistance = 34;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBoxObi.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(434, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 34);
			this.pictureBoxObi.TabIndex = 1;
			this.pictureBoxObi.TabStop = false;
			this.numericUpDownUsbOut.Location = new global::System.Drawing.Point(219, 373);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDownUsbOut;
			int[] array = new int[4];
			array[0] = 10;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDownUsbOut.Name = "numericUpDownUsbOut";
			this.numericUpDownUsbOut.Size = new global::System.Drawing.Size(40, 19);
			this.numericUpDownUsbOut.TabIndex = 23;
			this.numericUpDownUsbOut.ValueChanged += new global::System.EventHandler(this.numericUpDownUsbOut_ValueChanged);
			this.hScrollBarUsbOut.LargeChange = 1;
			this.hScrollBarUsbOut.Location = new global::System.Drawing.Point(62, 373);
			this.hScrollBarUsbOut.Maximum = 10;
			this.hScrollBarUsbOut.Name = "hScrollBarUsbOut";
			this.hScrollBarUsbOut.Size = new global::System.Drawing.Size(143, 17);
			this.hScrollBarUsbOut.TabIndex = 22;
			this.hScrollBarUsbOut.ValueChanged += new global::System.EventHandler(this.hScrollBarUsbOut_ValueChanged);
			this.pictureBoxButtonUsbOut.Image = global::Clock.Properties.Resources.nw_btn_disable;
			this.pictureBoxButtonUsbOut.Location = new global::System.Drawing.Point(62, 327);
			this.pictureBoxButtonUsbOut.Name = "pictureBoxButtonUsbOut";
			this.pictureBoxButtonUsbOut.Size = new global::System.Drawing.Size(74, 39);
			this.pictureBoxButtonUsbOut.TabIndex = 21;
			this.pictureBoxButtonUsbOut.TabStop = false;
			this.pictureBoxButtonUsbOut.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonUsbOut_MouseClick);
			this.labelUsbOut.AutoSize = true;
			this.labelUsbOut.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelUsbOut.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.labelUsbOut.Location = new global::System.Drawing.Point(56, 304);
			this.labelUsbOut.Name = "labelUsbOut";
			this.labelUsbOut.Size = new global::System.Drawing.Size(56, 18);
			this.labelUsbOut.TabIndex = 20;
			this.labelUsbOut.Text = "外部出力";
			this.connectWarningLabel.AutoSize = true;
			this.connectWarningLabel.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.connectWarningLabel.ForeColor = global::System.Drawing.Color.FromArgb(185, 11, 11);
			this.connectWarningLabel.Location = new global::System.Drawing.Point(78, 27);
			this.connectWarningLabel.Name = "connectWarningLabel";
			this.connectWarningLabel.Size = new global::System.Drawing.Size(80, 18);
			this.connectWarningLabel.TabIndex = 19;
			this.connectWarningLabel.Text = "警告文を表示";
			this.pictureBoxConnectIcon.Image = global::Clock.Properties.Resources.popup_usb_off;
			this.pictureBoxConnectIcon.Location = new global::System.Drawing.Point(40, 18);
			this.pictureBoxConnectIcon.Name = "pictureBoxConnectIcon";
			this.pictureBoxConnectIcon.Size = new global::System.Drawing.Size(32, 35);
			this.pictureBoxConnectIcon.TabIndex = 18;
			this.pictureBoxConnectIcon.TabStop = false;
			this.pictureBoxButtonSound.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonSound.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonSound.Image = global::Clock.Properties.Resources.mld_btn_013;
			this.pictureBoxButtonSound.Location = new global::System.Drawing.Point(81, 242);
			this.pictureBoxButtonSound.Name = "pictureBoxButtonSound";
			this.pictureBoxButtonSound.Size = new global::System.Drawing.Size(86, 50);
			this.pictureBoxButtonSound.TabIndex = 17;
			this.pictureBoxButtonSound.TabStop = false;
			this.pictureBoxButtonSound.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonSound_MouseDown);
			this.pictureBoxButtonSound.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonSound_MouseEnter);
			this.pictureBoxButtonSound.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonSound_MouseLeave);
			this.pictureBoxButtonSound.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonSound_MouseUp);
			this.pictureBoxButtonLED.Image = global::Clock.Properties.Resources.nw_btn_disable;
			this.pictureBoxButtonLED.Location = new global::System.Drawing.Point(62, 77);
			this.pictureBoxButtonLED.Name = "pictureBoxButtonLED";
			this.pictureBoxButtonLED.Size = new global::System.Drawing.Size(74, 39);
			this.pictureBoxButtonLED.TabIndex = 15;
			this.pictureBoxButtonLED.TabStop = false;
			this.pictureBoxButtonLED.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonLED_MouseClick);
			this.radioButtonLEDBlue.AutoSize = true;
			this.radioButtonLEDBlue.Enabled = false;
			this.radioButtonLEDBlue.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonLEDBlue.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.radioButtonLEDBlue.Location = new global::System.Drawing.Point(81, 177);
			this.radioButtonLEDBlue.Name = "radioButtonLEDBlue";
			this.radioButtonLEDBlue.Size = new global::System.Drawing.Size(38, 22);
			this.radioButtonLEDBlue.TabIndex = 6;
			this.radioButtonLEDBlue.Text = "青";
			this.radioButtonLEDBlue.UseVisualStyleBackColor = true;
			this.radioButtonLEDBlue.CheckedChanged += new global::System.EventHandler(this.radioButtonLEDBlue_CheckedChanged);
			this.radioButtonLEDGreen.AutoSize = true;
			this.radioButtonLEDGreen.Enabled = false;
			this.radioButtonLEDGreen.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonLEDGreen.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.radioButtonLEDGreen.Location = new global::System.Drawing.Point(81, 149);
			this.radioButtonLEDGreen.Name = "radioButtonLEDGreen";
			this.radioButtonLEDGreen.Size = new global::System.Drawing.Size(38, 22);
			this.radioButtonLEDGreen.TabIndex = 5;
			this.radioButtonLEDGreen.Text = "緑";
			this.radioButtonLEDGreen.UseVisualStyleBackColor = true;
			this.radioButtonLEDGreen.CheckedChanged += new global::System.EventHandler(this.radioButtonLEDGreen_CheckedChanged);
			this.radioButtonLEDRed.AutoSize = true;
			this.radioButtonLEDRed.Checked = true;
			this.radioButtonLEDRed.Enabled = false;
			this.radioButtonLEDRed.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonLEDRed.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.radioButtonLEDRed.Location = new global::System.Drawing.Point(81, 121);
			this.radioButtonLEDRed.Name = "radioButtonLEDRed";
			this.radioButtonLEDRed.Size = new global::System.Drawing.Size(38, 22);
			this.radioButtonLEDRed.TabIndex = 4;
			this.radioButtonLEDRed.TabStop = true;
			this.radioButtonLEDRed.Text = "赤";
			this.radioButtonLEDRed.UseVisualStyleBackColor = true;
			this.radioButtonLEDRed.CheckedChanged += new global::System.EventHandler(this.radioButtonLEDRed_CheckedChanged);
			this.groupBox1.Controls.Add(this.labelUsbIn);
			this.groupBox1.Controls.Add(this.labelUsbInText);
			this.groupBox1.Controls.Add(this.labelSound);
			this.groupBox1.Controls.Add(this.labelLightValue);
			this.groupBox1.Controls.Add(this.labelLight);
			this.groupBox1.Controls.Add(this.labelTopButton);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBox1.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.groupBox1.Location = new global::System.Drawing.Point(277, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(219, 256);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "センサ状態表示";
			this.labelUsbIn.AutoSize = true;
			this.labelUsbIn.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelUsbIn.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.labelUsbIn.Location = new global::System.Drawing.Point(154, 218);
			this.labelUsbIn.Name = "labelUsbIn";
			this.labelUsbIn.Size = new global::System.Drawing.Size(13, 18);
			this.labelUsbIn.TabIndex = 11;
			this.labelUsbIn.Text = "-";
			this.labelUsbInText.AutoSize = true;
			this.labelUsbInText.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelUsbInText.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.labelUsbInText.Location = new global::System.Drawing.Point(35, 218);
			this.labelUsbInText.Name = "labelUsbInText";
			this.labelUsbInText.Size = new global::System.Drawing.Size(56, 18);
			this.labelUsbInText.TabIndex = 10;
			this.labelUsbInText.Text = "外部入力";
			this.labelSound.AutoSize = true;
			this.labelSound.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelSound.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.labelSound.Location = new global::System.Drawing.Point(154, 174);
			this.labelSound.Name = "labelSound";
			this.labelSound.Size = new global::System.Drawing.Size(13, 18);
			this.labelSound.TabIndex = 9;
			this.labelSound.Text = "-";
			this.labelLightValue.AutoSize = true;
			this.labelLightValue.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelLightValue.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.labelLightValue.Location = new global::System.Drawing.Point(154, 127);
			this.labelLightValue.Name = "labelLightValue";
			this.labelLightValue.Size = new global::System.Drawing.Size(13, 18);
			this.labelLightValue.TabIndex = 8;
			this.labelLightValue.Text = "-";
			this.labelLight.AutoSize = true;
			this.labelLight.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelLight.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.labelLight.Location = new global::System.Drawing.Point(154, 80);
			this.labelLight.Name = "labelLight";
			this.labelLight.Size = new global::System.Drawing.Size(13, 18);
			this.labelLight.TabIndex = 7;
			this.labelLight.Text = "-";
			this.labelTopButton.AutoSize = true;
			this.labelTopButton.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelTopButton.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.labelTopButton.Location = new global::System.Drawing.Point(154, 33);
			this.labelTopButton.Name = "labelTopButton";
			this.labelTopButton.Size = new global::System.Drawing.Size(13, 18);
			this.labelTopButton.TabIndex = 6;
			this.labelTopButton.Text = "-";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label6.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label6.Location = new global::System.Drawing.Point(35, 174);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(92, 18);
			this.label6.TabIndex = 5;
			this.label6.Text = "音センサの反応";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label5.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label5.Location = new global::System.Drawing.Point(35, 127);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(68, 18);
			this.label5.TabIndex = 4;
			this.label5.Text = "光センサ値";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label4.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label4.Location = new global::System.Drawing.Point(35, 80);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(44, 18);
			this.label4.TabIndex = 3;
			this.label4.Text = "周囲が";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label3.Location = new global::System.Drawing.Point(35, 33);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(80, 18);
			this.label3.TabIndex = 2;
			this.label3.Text = "トップボタン";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label2.Location = new global::System.Drawing.Point(56, 212);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(80, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "サウンド設定";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label1.Location = new global::System.Drawing.Point(54, 56);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(55, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "LED設定";
			this.timer1.Enabled = true;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(540, 441);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "HardwareCheckWindow";
			this.Text = "コロックル動作確認";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.HardwareCheckWindow_FormClosed);
			base.Shown += new global::System.EventHandler(this.HardwareCheckWindow_Shown);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownUsbOut).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonUsbOut).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxConnectIcon).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonSound).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonLED).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040002CE RID: 718
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040002CF RID: 719
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040002D0 RID: 720
		private global::System.Windows.Forms.PictureBox pictureBoxObi;

		// Token: 0x040002D1 RID: 721
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002D2 RID: 722
		private global::System.Windows.Forms.RadioButton radioButtonLEDBlue;

		// Token: 0x040002D3 RID: 723
		private global::System.Windows.Forms.RadioButton radioButtonLEDGreen;

		// Token: 0x040002D4 RID: 724
		private global::System.Windows.Forms.RadioButton radioButtonLEDRed;

		// Token: 0x040002D5 RID: 725
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040002D6 RID: 726
		private global::System.Windows.Forms.Label labelSound;

		// Token: 0x040002D7 RID: 727
		private global::System.Windows.Forms.Label labelLightValue;

		// Token: 0x040002D8 RID: 728
		private global::System.Windows.Forms.Label labelLight;

		// Token: 0x040002D9 RID: 729
		private global::System.Windows.Forms.Label labelTopButton;

		// Token: 0x040002DA RID: 730
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040002DB RID: 731
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040002DC RID: 732
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040002DD RID: 733
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040002DE RID: 734
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002DF RID: 735
		private global::System.Windows.Forms.PictureBox pictureBoxButtonLED;

		// Token: 0x040002E0 RID: 736
		private global::System.Windows.Forms.PictureBox pictureBoxButtonSound;

		// Token: 0x040002E1 RID: 737
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x040002E2 RID: 738
		private global::System.Windows.Forms.PictureBox pictureBoxConnectIcon;

		// Token: 0x040002E3 RID: 739
		private global::System.Windows.Forms.Label connectWarningLabel;

		// Token: 0x040002E4 RID: 740
		private global::System.Windows.Forms.NumericUpDown numericUpDownUsbOut;

		// Token: 0x040002E5 RID: 741
		private global::System.Windows.Forms.HScrollBar hScrollBarUsbOut;

		// Token: 0x040002E6 RID: 742
		private global::System.Windows.Forms.PictureBox pictureBoxButtonUsbOut;

		// Token: 0x040002E7 RID: 743
		private global::System.Windows.Forms.Label labelUsbOut;

		// Token: 0x040002E8 RID: 744
		private global::System.Windows.Forms.Label labelUsbIn;

		// Token: 0x040002E9 RID: 745
		private global::System.Windows.Forms.Label labelUsbInText;
	}
}
