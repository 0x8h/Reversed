namespace Clock
{
	// Token: 0x02000055 RID: 85
	public partial class SimulatorWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x0600091B RID: 2331 RVA: 0x00067556 File Offset: 0x00065756
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00067578 File Offset: 0x00065778
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.SimulatorWindow));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonUsbIn = new global::System.Windows.Forms.PictureBox();
			this.labelUsbIn = new global::System.Windows.Forms.Label();
			this.pictureBoxUsbOut = new global::System.Windows.Forms.PictureBox();
			this.textBoxLight = new global::System.Windows.Forms.TextBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label13 = new global::System.Windows.Forms.Label();
			this.hScrollBarLight = new global::System.Windows.Forms.HScrollBar();
			this.label12 = new global::System.Windows.Forms.Label();
			this.pictureBoxSound = new global::System.Windows.Forms.PictureBox();
			this.textBoxTemperature = new global::System.Windows.Forms.TextBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.numericUpDownMinute = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDownHour = new global::System.Windows.Forms.NumericUpDown();
			this.vScrollBarTemperature = new global::System.Windows.Forms.VScrollBar();
			this.pictureBoxButtonTimer = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonAlarm = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonSound = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonButton = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonBright = new global::System.Windows.Forms.PictureBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pictureBoxButtonRunStep = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonRun = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonStop = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonUsbIn).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxUsbOut).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxSound).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownMinute).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownHour).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonTimer).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonAlarm).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonSound).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonButton).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonBright).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRunStep).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRun).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonStop).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
			this.splitContainer1.Panel1MinSize = 20;
			this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonUsbIn);
			this.splitContainer1.Panel2.Controls.Add(this.labelUsbIn);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxUsbOut);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxLight);
			this.splitContainer1.Panel2.Controls.Add(this.label14);
			this.splitContainer1.Panel2.Controls.Add(this.label13);
			this.splitContainer1.Panel2.Controls.Add(this.hScrollBarLight);
			this.splitContainer1.Panel2.Controls.Add(this.label12);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxSound);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxTemperature);
			this.splitContainer1.Panel2.Controls.Add(this.label11);
			this.splitContainer1.Panel2.Controls.Add(this.label10);
			this.splitContainer1.Panel2.Controls.Add(this.label9);
			this.splitContainer1.Panel2.Controls.Add(this.label8);
			this.splitContainer1.Panel2.Controls.Add(this.numericUpDownMinute);
			this.splitContainer1.Panel2.Controls.Add(this.numericUpDownHour);
			this.splitContainer1.Panel2.Controls.Add(this.vScrollBarTemperature);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonTimer);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonAlarm);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonSound);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonButton);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonBright);
			this.splitContainer1.Panel2.Controls.Add(this.label7);
			this.splitContainer1.Panel2.Controls.Add(this.label6);
			this.splitContainer1.Panel2.Controls.Add(this.label5);
			this.splitContainer1.Panel2.Controls.Add(this.label4);
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonRunStep);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonRun);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonStop);
			this.splitContainer1.Size = new global::System.Drawing.Size(432, 394);
			this.splitContainer1.SplitterDistance = 33;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.sim_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(258, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(174, 33);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBoxButtonUsbIn.Image = global::Clock.Properties.Resources.sim_btn_081;
			this.pictureBoxButtonUsbIn.Location = new global::System.Drawing.Point(354, 220);
			this.pictureBoxButtonUsbIn.Name = "pictureBoxButtonUsbIn";
			this.pictureBoxButtonUsbIn.Size = new global::System.Drawing.Size(39, 39);
			this.pictureBoxButtonUsbIn.TabIndex = 37;
			this.pictureBoxButtonUsbIn.TabStop = false;
			this.pictureBoxButtonUsbIn.Visible = false;
			this.pictureBoxButtonUsbIn.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonUsbIn_MouseClick);
			this.labelUsbIn.AutoSize = true;
			this.labelUsbIn.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelUsbIn.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.labelUsbIn.Location = new global::System.Drawing.Point(339, 199);
			this.labelUsbIn.Name = "labelUsbIn";
			this.labelUsbIn.Size = new global::System.Drawing.Size(68, 18);
			this.labelUsbIn.TabIndex = 36;
			this.labelUsbIn.Text = "◇外部入力";
			this.labelUsbIn.Visible = false;
			this.pictureBoxUsbOut.Location = new global::System.Drawing.Point(102, 3);
			this.pictureBoxUsbOut.Name = "pictureBoxUsbOut";
			this.pictureBoxUsbOut.Size = new global::System.Drawing.Size(55, 92);
			this.pictureBoxUsbOut.TabIndex = 35;
			this.pictureBoxUsbOut.TabStop = false;
			this.textBoxLight.Location = new global::System.Drawing.Point(380, 274);
			this.textBoxLight.Name = "textBoxLight";
			this.textBoxLight.ShortcutsEnabled = false;
			this.textBoxLight.Size = new global::System.Drawing.Size(27, 19);
			this.textBoxLight.TabIndex = 34;
			this.textBoxLight.Text = "50";
			this.textBoxLight.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.textBoxLight_KeyPress);
			this.textBoxLight.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.textBoxLight_KeyUp);
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label14.Location = new global::System.Drawing.Point(344, 275);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(29, 18);
			this.label14.TabIndex = 33;
			this.label14.Text = "100";
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label13.Location = new global::System.Drawing.Point(141, 275);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(15, 18);
			this.label13.TabIndex = 32;
			this.label13.Text = "0";
			this.hScrollBarLight.LargeChange = 1;
			this.hScrollBarLight.Location = new global::System.Drawing.Point(159, 274);
			this.hScrollBarLight.Name = "hScrollBarLight";
			this.hScrollBarLight.Size = new global::System.Drawing.Size(183, 20);
			this.hScrollBarLight.TabIndex = 31;
			this.hScrollBarLight.Value = 50;
			this.hScrollBarLight.Scroll += new global::System.Windows.Forms.ScrollEventHandler(this.hScrollBarLight_Scroll);
			this.hScrollBarLight.ValueChanged += new global::System.EventHandler(this.hScrollBarLight_ValueChanged);
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label12.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label12.Location = new global::System.Drawing.Point(139, 245);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(162, 18);
			this.label12.TabIndex = 30;
			this.label12.Text = "◇周囲の明るさ(数値で指定)";
			this.pictureBoxSound.Location = new global::System.Drawing.Point(268, 14);
			this.pictureBoxSound.Name = "pictureBoxSound";
			this.pictureBoxSound.Size = new global::System.Drawing.Size(60, 68);
			this.pictureBoxSound.TabIndex = 29;
			this.pictureBoxSound.TabStop = false;
			this.textBoxTemperature.BackColor = global::System.Drawing.SystemColors.Window;
			this.textBoxTemperature.Location = new global::System.Drawing.Point(82, 157);
			this.textBoxTemperature.Name = "textBoxTemperature";
			this.textBoxTemperature.ShortcutsEnabled = false;
			this.textBoxTemperature.Size = new global::System.Drawing.Size(24, 19);
			this.textBoxTemperature.TabIndex = 28;
			this.textBoxTemperature.Text = "0";
			this.textBoxTemperature.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.textBoxTemperature_KeyPress);
			this.textBoxTemperature.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.textBoxTemperature_KeyUp);
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label11.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label11.Location = new global::System.Drawing.Point(106, 159);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(20, 18);
			this.label11.TabIndex = 27;
			this.label11.Text = "℃";
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label10.ForeColor = global::System.Drawing.Color.Blue;
			this.label10.Location = new global::System.Drawing.Point(82, 202);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(39, 18);
			this.label10.TabIndex = 25;
			this.label10.Text = "-10℃";
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label9.ForeColor = global::System.Drawing.Color.Red;
			this.label9.Location = new global::System.Drawing.Point(80, 114);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(34, 18);
			this.label9.TabIndex = 24;
			this.label9.Text = "50℃";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label8.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label8.Location = new global::System.Drawing.Point(54, 46);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(13, 18);
			this.label8.TabIndex = 23;
			this.label8.Text = ":";
			this.numericUpDownMinute.Location = new global::System.Drawing.Point(67, 46);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDownMinute;
			int[] array = new int[4];
			array[0] = 59;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDownMinute.Name = "numericUpDownMinute";
			this.numericUpDownMinute.Size = new global::System.Drawing.Size(35, 19);
			this.numericUpDownMinute.TabIndex = 22;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDownMinute;
			int[] array2 = new int[4];
			array2[0] = 59;
			numericUpDown2.Value = new decimal(array2);
			this.numericUpDownMinute.ValueChanged += new global::System.EventHandler(this.numericUpDownMinute_ValueChanged);
			this.numericUpDownHour.Location = new global::System.Drawing.Point(18, 46);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDownHour;
			int[] array3 = new int[4];
			array3[0] = 23;
			numericUpDown3.Maximum = new decimal(array3);
			this.numericUpDownHour.Name = "numericUpDownHour";
			this.numericUpDownHour.Size = new global::System.Drawing.Size(35, 19);
			this.numericUpDownHour.TabIndex = 21;
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.numericUpDownHour;
			int[] array4 = new int[4];
			array4[0] = 23;
			numericUpDown4.Value = new decimal(array4);
			this.numericUpDownHour.ValueChanged += new global::System.EventHandler(this.numericUpDownHour_ValueChanged);
			this.vScrollBarTemperature.LargeChange = 1;
			this.vScrollBarTemperature.Location = new global::System.Drawing.Point(60, 114);
			this.vScrollBarTemperature.Maximum = 60;
			this.vScrollBarTemperature.Name = "vScrollBarTemperature";
			this.vScrollBarTemperature.Size = new global::System.Drawing.Size(17, 106);
			this.vScrollBarTemperature.TabIndex = 18;
			this.vScrollBarTemperature.Value = 50;
			this.vScrollBarTemperature.Scroll += new global::System.Windows.Forms.ScrollEventHandler(this.vScrollBarTemperature_Scroll);
			this.vScrollBarTemperature.ValueChanged += new global::System.EventHandler(this.vScrollBarTemperature_ValueChanged);
			this.pictureBoxButtonTimer.Image = global::Clock.Properties.Resources.sim_btn_021;
			this.pictureBoxButtonTimer.Location = new global::System.Drawing.Point(354, 155);
			this.pictureBoxButtonTimer.Name = "pictureBoxButtonTimer";
			this.pictureBoxButtonTimer.Size = new global::System.Drawing.Size(39, 39);
			this.pictureBoxButtonTimer.TabIndex = 17;
			this.pictureBoxButtonTimer.TabStop = false;
			this.pictureBoxButtonTimer.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonTimer_MouseClick);
			this.pictureBoxButtonAlarm.Image = global::Clock.Properties.Resources.sim_btn_031;
			this.pictureBoxButtonAlarm.Location = new global::System.Drawing.Point(354, 90);
			this.pictureBoxButtonAlarm.Name = "pictureBoxButtonAlarm";
			this.pictureBoxButtonAlarm.Size = new global::System.Drawing.Size(39, 39);
			this.pictureBoxButtonAlarm.TabIndex = 16;
			this.pictureBoxButtonAlarm.TabStop = false;
			this.pictureBoxButtonAlarm.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonAlarm_MouseClick);
			this.pictureBoxButtonSound.Image = global::Clock.Properties.Resources.sim_btn_041;
			this.pictureBoxButtonSound.Location = new global::System.Drawing.Point(354, 25);
			this.pictureBoxButtonSound.Name = "pictureBoxButtonSound";
			this.pictureBoxButtonSound.Size = new global::System.Drawing.Size(39, 39);
			this.pictureBoxButtonSound.TabIndex = 15;
			this.pictureBoxButtonSound.TabStop = false;
			this.pictureBoxButtonSound.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonSound_MouseDown);
			this.pictureBoxButtonSound.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonSound_MouseUp);
			this.pictureBoxButtonButton.Image = global::Clock.Properties.Resources.sim_btn_011;
			this.pictureBoxButtonButton.Location = new global::System.Drawing.Point(199, 25);
			this.pictureBoxButtonButton.Name = "pictureBoxButtonButton";
			this.pictureBoxButtonButton.Size = new global::System.Drawing.Size(39, 39);
			this.pictureBoxButtonButton.TabIndex = 14;
			this.pictureBoxButtonButton.TabStop = false;
			this.pictureBoxButtonButton.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonButton_MouseDown);
			this.pictureBoxButtonButton.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonButton_MouseUp);
			this.pictureBoxButtonBright.Image = global::Clock.Properties.Resources.sim_btn_000;
			this.pictureBoxButtonBright.Location = new global::System.Drawing.Point(25, 264);
			this.pictureBoxButtonBright.Name = "pictureBoxButtonBright";
			this.pictureBoxButtonBright.Size = new global::System.Drawing.Size(74, 39);
			this.pictureBoxButtonBright.TabIndex = 13;
			this.pictureBoxButtonBright.TabStop = false;
			this.pictureBoxButtonBright.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonBright_MouseClick);
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label7.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label7.Location = new global::System.Drawing.Point(13, 93);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(44, 18);
			this.label7.TabIndex = 12;
			this.label7.Text = "◇温度";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label6.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label6.Location = new global::System.Drawing.Point(13, 25);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(44, 18);
			this.label6.TabIndex = 11;
			this.label6.Text = "◇時刻";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label5.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label5.Location = new global::System.Drawing.Point(339, 133);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(68, 18);
			this.label5.TabIndex = 10;
			this.label5.Text = "◇タイマー";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label4.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label4.Location = new global::System.Drawing.Point(339, 69);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(68, 18);
			this.label4.TabIndex = 9;
			this.label4.Text = "◇アラーム";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label3.Location = new global::System.Drawing.Point(339, 5);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(32, 18);
			this.label3.TabIndex = 8;
			this.label3.Text = "◇音";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label2.Location = new global::System.Drawing.Point(190, 5);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(56, 18);
			this.label2.TabIndex = 7;
			this.label2.Text = "◇ボタン";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.label1.Location = new global::System.Drawing.Point(13, 244);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(92, 18);
			this.label1.TabIndex = 6;
			this.label1.Text = "◇周囲の明るさ";
			this.pictureBoxButtonRunStep.Image = global::Clock.Properties.Resources.sim_btn_070;
			this.pictureBoxButtonRunStep.Location = new global::System.Drawing.Point(279, 317);
			this.pictureBoxButtonRunStep.Name = "pictureBoxButtonRunStep";
			this.pictureBoxButtonRunStep.Size = new global::System.Drawing.Size(141, 40);
			this.pictureBoxButtonRunStep.TabIndex = 5;
			this.pictureBoxButtonRunStep.TabStop = false;
			this.pictureBoxButtonRunStep.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRunStep_MouseDown);
			this.pictureBoxButtonRunStep.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonRunStep_MouseEnter);
			this.pictureBoxButtonRunStep.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonRunStep_MouseLeave);
			this.pictureBoxButtonRunStep.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRunStep_MouseUp);
			this.pictureBoxButtonRun.Image = global::Clock.Properties.Resources.sim_btn_050;
			this.pictureBoxButtonRun.Location = new global::System.Drawing.Point(60, 317);
			this.pictureBoxButtonRun.Name = "pictureBoxButtonRun";
			this.pictureBoxButtonRun.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonRun.TabIndex = 3;
			this.pictureBoxButtonRun.TabStop = false;
			this.pictureBoxButtonRun.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRun_MouseDown);
			this.pictureBoxButtonRun.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonRun_MouseEnter);
			this.pictureBoxButtonRun.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonRun_MouseLeave);
			this.pictureBoxButtonRun.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRun_MouseUp);
			this.pictureBoxButtonStop.Image = global::Clock.Properties.Resources.sim_btn_063;
			this.pictureBoxButtonStop.Location = new global::System.Drawing.Point(169, 317);
			this.pictureBoxButtonStop.Name = "pictureBoxButtonStop";
			this.pictureBoxButtonStop.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonStop.TabIndex = 4;
			this.pictureBoxButtonStop.TabStop = false;
			this.pictureBoxButtonStop.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonStop_MouseDown);
			this.pictureBoxButtonStop.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonStop_MouseEnter);
			this.pictureBoxButtonStop.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonStop_MouseLeave);
			this.pictureBoxButtonStop.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonStop_MouseUp);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(432, 394);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SimulatorWindow";
			this.Text = "シミュレート";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.SimulatorWindow_FormClosing);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.SimulatorWindow_FormClosed);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.SimulatorWindow_KeyDown);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonUsbIn).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxUsbOut).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxSound).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownMinute).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownHour).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonTimer).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonAlarm).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonSound).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonButton).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonBright).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRunStep).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRun).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonStop).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400068A RID: 1674
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400068B RID: 1675
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x0400068C RID: 1676
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400068D RID: 1677
		private global::System.Windows.Forms.PictureBox pictureBoxButtonRunStep;

		// Token: 0x0400068E RID: 1678
		private global::System.Windows.Forms.PictureBox pictureBoxButtonRun;

		// Token: 0x0400068F RID: 1679
		private global::System.Windows.Forms.PictureBox pictureBoxButtonStop;

		// Token: 0x04000690 RID: 1680
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000691 RID: 1681
		private global::System.Windows.Forms.PictureBox pictureBoxButtonTimer;

		// Token: 0x04000692 RID: 1682
		private global::System.Windows.Forms.PictureBox pictureBoxButtonAlarm;

		// Token: 0x04000693 RID: 1683
		private global::System.Windows.Forms.PictureBox pictureBoxButtonSound;

		// Token: 0x04000694 RID: 1684
		private global::System.Windows.Forms.PictureBox pictureBoxButtonButton;

		// Token: 0x04000695 RID: 1685
		private global::System.Windows.Forms.PictureBox pictureBoxButtonBright;

		// Token: 0x04000696 RID: 1686
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000697 RID: 1687
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000698 RID: 1688
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000699 RID: 1689
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400069A RID: 1690
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400069B RID: 1691
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400069C RID: 1692
		private global::System.Windows.Forms.VScrollBar vScrollBarTemperature;

		// Token: 0x0400069D RID: 1693
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400069E RID: 1694
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400069F RID: 1695
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040006A0 RID: 1696
		private global::System.Windows.Forms.NumericUpDown numericUpDownMinute;

		// Token: 0x040006A1 RID: 1697
		private global::System.Windows.Forms.NumericUpDown numericUpDownHour;

		// Token: 0x040006A2 RID: 1698
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040006A3 RID: 1699
		private global::System.Windows.Forms.TextBox textBoxTemperature;

		// Token: 0x040006A4 RID: 1700
		private global::System.Windows.Forms.PictureBox pictureBoxSound;

		// Token: 0x040006A5 RID: 1701
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040006A6 RID: 1702
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040006A7 RID: 1703
		private global::System.Windows.Forms.HScrollBar hScrollBarLight;

		// Token: 0x040006A8 RID: 1704
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040006A9 RID: 1705
		private global::System.Windows.Forms.TextBox textBoxLight;

		// Token: 0x040006AA RID: 1706
		private global::System.Windows.Forms.PictureBox pictureBoxUsbOut;

		// Token: 0x040006AB RID: 1707
		private global::System.Windows.Forms.PictureBox pictureBoxButtonUsbIn;

		// Token: 0x040006AC RID: 1708
		private global::System.Windows.Forms.Label labelUsbIn;
	}
}
