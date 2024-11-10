namespace Clock
{
	// Token: 0x0200000B RID: 11
	public partial class BlockPropertyLEDDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x0000B012 File Offset: 0x00009212
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000B034 File Offset: 0x00009234
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyLEDDialog));
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.scrollBarRed = new global::System.Windows.Forms.HScrollBar();
			this.scrollBarGreen = new global::System.Windows.Forms.HScrollBar();
			this.scrollBarBlue = new global::System.Windows.Forms.HScrollBar();
			this.comboBoxColor = new global::System.Windows.Forms.ComboBox();
			this.groupBoxFade = new global::System.Windows.Forms.GroupBox();
			this.radioButtonFadeNone = new global::System.Windows.Forms.RadioButton();
			this.radioButtonFadeIn = new global::System.Windows.Forms.RadioButton();
			this.radioButtonFadeOut = new global::System.Windows.Forms.RadioButton();
			this.groupBoxLight = new global::System.Windows.Forms.GroupBox();
			this.radioButtonLightOn = new global::System.Windows.Forms.RadioButton();
			this.numericUpDownTime = new global::System.Windows.Forms.NumericUpDown();
			this.radioButtonLightOff = new global::System.Windows.Forms.RadioButton();
			this.radioButtonLightOnTime = new global::System.Windows.Forms.RadioButton();
			this.numericUpDownRed = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDownGreen = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDownBlue = new global::System.Windows.Forms.NumericUpDown();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonPreview = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxPreview = new global::System.Windows.Forms.PictureBox();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.groupBoxFade.SuspendLayout();
			this.groupBoxLight.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownTime).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownRed).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownGreen).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownBlue).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonPreview).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPreview).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("MS UI Gothic", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(185, 11, 11);
			this.label1.Location = new global::System.Drawing.Point(21, 11);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(22, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "赤";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("MS UI Gothic", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(39, 141, 60);
			this.label2.Location = new global::System.Drawing.Point(21, 44);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(22, 14);
			this.label2.TabIndex = 1;
			this.label2.Text = "緑";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("MS UI Gothic", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(39, 51, 141);
			this.label3.Location = new global::System.Drawing.Point(21, 80);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(22, 14);
			this.label3.TabIndex = 2;
			this.label3.Text = "青";
			this.scrollBarRed.LargeChange = 1;
			this.scrollBarRed.Location = new global::System.Drawing.Point(57, 11);
			this.scrollBarRed.Maximum = 10;
			this.scrollBarRed.Name = "scrollBarRed";
			this.scrollBarRed.Size = new global::System.Drawing.Size(122, 19);
			this.scrollBarRed.TabIndex = 3;
			this.scrollBarRed.ValueChanged += new global::System.EventHandler(this.scrollBarRed_ValueChanged);
			this.scrollBarGreen.LargeChange = 1;
			this.scrollBarGreen.Location = new global::System.Drawing.Point(57, 46);
			this.scrollBarGreen.Maximum = 10;
			this.scrollBarGreen.Name = "scrollBarGreen";
			this.scrollBarGreen.Size = new global::System.Drawing.Size(122, 17);
			this.scrollBarGreen.TabIndex = 4;
			this.scrollBarGreen.ValueChanged += new global::System.EventHandler(this.scrollBarGreen_ValueChanged);
			this.scrollBarBlue.LargeChange = 1;
			this.scrollBarBlue.Location = new global::System.Drawing.Point(57, 78);
			this.scrollBarBlue.Maximum = 10;
			this.scrollBarBlue.Name = "scrollBarBlue";
			this.scrollBarBlue.Size = new global::System.Drawing.Size(122, 19);
			this.scrollBarBlue.TabIndex = 5;
			this.scrollBarBlue.ValueChanged += new global::System.EventHandler(this.scrollBarBlue_ValueChanged);
			this.comboBoxColor.FormattingEnabled = true;
			this.comboBoxColor.Location = new global::System.Drawing.Point(264, 78);
			this.comboBoxColor.Name = "comboBoxColor";
			this.comboBoxColor.Size = new global::System.Drawing.Size(70, 20);
			this.comboBoxColor.TabIndex = 10;
			this.comboBoxColor.SelectedIndexChanged += new global::System.EventHandler(this.comboBoxColor_SelectedIndexChanged);
			this.groupBoxFade.Controls.Add(this.radioButtonFadeNone);
			this.groupBoxFade.Controls.Add(this.radioButtonFadeIn);
			this.groupBoxFade.Controls.Add(this.radioButtonFadeOut);
			this.groupBoxFade.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBoxFade.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.groupBoxFade.Location = new global::System.Drawing.Point(24, 192);
			this.groupBoxFade.Name = "groupBoxFade";
			this.groupBoxFade.Size = new global::System.Drawing.Size(196, 44);
			this.groupBoxFade.TabIndex = 9;
			this.groupBoxFade.TabStop = false;
			this.groupBoxFade.Text = "だんだん変わる/消える";
			this.radioButtonFadeNone.AutoSize = true;
			this.radioButtonFadeNone.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonFadeNone.Location = new global::System.Drawing.Point(13, 17);
			this.radioButtonFadeNone.Name = "radioButtonFadeNone";
			this.radioButtonFadeNone.Size = new global::System.Drawing.Size(50, 22);
			this.radioButtonFadeNone.TabIndex = 4;
			this.radioButtonFadeNone.TabStop = true;
			this.radioButtonFadeNone.Text = "なし";
			this.radioButtonFadeNone.UseVisualStyleBackColor = true;
			this.radioButtonFadeNone.CheckedChanged += new global::System.EventHandler(this.radioButtonFadeNone_CheckedChanged);
			this.radioButtonFadeIn.AutoSize = true;
			this.radioButtonFadeIn.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonFadeIn.Location = new global::System.Drawing.Point(74, 18);
			this.radioButtonFadeIn.Name = "radioButtonFadeIn";
			this.radioButtonFadeIn.Size = new global::System.Drawing.Size(62, 22);
			this.radioButtonFadeIn.TabIndex = 5;
			this.radioButtonFadeIn.TabStop = true;
			this.radioButtonFadeIn.Text = "変わる";
			this.radioButtonFadeIn.UseVisualStyleBackColor = true;
			this.radioButtonFadeIn.CheckedChanged += new global::System.EventHandler(this.radioButtonFadeIn_CheckedChanged);
			this.radioButtonFadeOut.AutoSize = true;
			this.radioButtonFadeOut.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonFadeOut.Location = new global::System.Drawing.Point(140, 18);
			this.radioButtonFadeOut.Name = "radioButtonFadeOut";
			this.radioButtonFadeOut.Size = new global::System.Drawing.Size(62, 22);
			this.radioButtonFadeOut.TabIndex = 6;
			this.radioButtonFadeOut.TabStop = true;
			this.radioButtonFadeOut.Text = "消える";
			this.radioButtonFadeOut.UseVisualStyleBackColor = true;
			this.radioButtonFadeOut.CheckedChanged += new global::System.EventHandler(this.radioButtonFadeOut_CheckedChanged);
			this.groupBoxLight.Controls.Add(this.radioButtonLightOn);
			this.groupBoxLight.Controls.Add(this.numericUpDownTime);
			this.groupBoxLight.Controls.Add(this.radioButtonLightOff);
			this.groupBoxLight.Controls.Add(this.radioButtonLightOnTime);
			this.groupBoxLight.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBoxLight.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.groupBoxLight.Location = new global::System.Drawing.Point(24, 115);
			this.groupBoxLight.Name = "groupBoxLight";
			this.groupBoxLight.Size = new global::System.Drawing.Size(196, 71);
			this.groupBoxLight.TabIndex = 8;
			this.groupBoxLight.TabStop = false;
			this.groupBoxLight.Text = "点灯操作";
			this.radioButtonLightOn.AutoSize = true;
			this.radioButtonLightOn.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonLightOn.Location = new global::System.Drawing.Point(22, 18);
			this.radioButtonLightOn.Name = "radioButtonLightOn";
			this.radioButtonLightOn.Size = new global::System.Drawing.Size(74, 22);
			this.radioButtonLightOn.TabIndex = 1;
			this.radioButtonLightOn.TabStop = true;
			this.radioButtonLightOn.Text = "連続点灯";
			this.radioButtonLightOn.UseVisualStyleBackColor = true;
			this.radioButtonLightOn.CheckedChanged += new global::System.EventHandler(this.radioButtonLightOn_CheckedChanged);
			this.numericUpDownTime.DecimalPlaces = 1;
			this.numericUpDownTime.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
			this.numericUpDownTime.Location = new global::System.Drawing.Point(46, 43);
			this.numericUpDownTime.Maximum = new decimal(new int[] { 255, 0, 0, 65536 });
			this.numericUpDownTime.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
			this.numericUpDownTime.Name = "numericUpDownTime";
			this.numericUpDownTime.Size = new global::System.Drawing.Size(50, 25);
			this.numericUpDownTime.TabIndex = 7;
			this.numericUpDownTime.Value = new decimal(new int[] { 1, 0, 0, 65536 });
			this.radioButtonLightOff.AutoSize = true;
			this.radioButtonLightOff.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonLightOff.Location = new global::System.Drawing.Point(111, 17);
			this.radioButtonLightOff.Name = "radioButtonLightOff";
			this.radioButtonLightOff.Size = new global::System.Drawing.Size(50, 22);
			this.radioButtonLightOff.TabIndex = 2;
			this.radioButtonLightOff.TabStop = true;
			this.radioButtonLightOff.Text = "消灯";
			this.radioButtonLightOff.UseVisualStyleBackColor = true;
			this.radioButtonLightOff.CheckedChanged += new global::System.EventHandler(this.radioButtonLightOff_CheckedChanged);
			this.radioButtonLightOnTime.AutoSize = true;
			this.radioButtonLightOnTime.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonLightOnTime.Location = new global::System.Drawing.Point(22, 43);
			this.radioButtonLightOnTime.Name = "radioButtonLightOnTime";
			this.radioButtonLightOnTime.Size = new global::System.Drawing.Size(110, 22);
			this.radioButtonLightOnTime.TabIndex = 3;
			this.radioButtonLightOnTime.TabStop = true;
			this.radioButtonLightOnTime.Text = "\u3000\u3000\u3000\u3000\u3000秒間";
			this.radioButtonLightOnTime.UseVisualStyleBackColor = true;
			this.radioButtonLightOnTime.CheckedChanged += new global::System.EventHandler(this.radioButtonLightOnTime_CheckedChanged);
			this.numericUpDownRed.Location = new global::System.Drawing.Point(190, 11);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDownRed;
			int[] array = new int[4];
			array[0] = 10;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDownRed.Name = "numericUpDownRed";
			this.numericUpDownRed.Size = new global::System.Drawing.Size(38, 19);
			this.numericUpDownRed.TabIndex = 15;
			this.numericUpDownRed.ValueChanged += new global::System.EventHandler(this.numericUpDownRed_ValueChanged);
			this.numericUpDownGreen.Location = new global::System.Drawing.Point(190, 44);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDownGreen;
			int[] array2 = new int[4];
			array2[0] = 10;
			numericUpDown2.Maximum = new decimal(array2);
			this.numericUpDownGreen.Name = "numericUpDownGreen";
			this.numericUpDownGreen.Size = new global::System.Drawing.Size(38, 19);
			this.numericUpDownGreen.TabIndex = 16;
			this.numericUpDownGreen.ValueChanged += new global::System.EventHandler(this.numericUpDownGreen_ValueChanged);
			this.numericUpDownBlue.Location = new global::System.Drawing.Point(190, 78);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDownBlue;
			int[] array3 = new int[4];
			array3[0] = 10;
			numericUpDown3.Maximum = new decimal(array3);
			this.numericUpDownBlue.Name = "numericUpDownBlue";
			this.numericUpDownBlue.Size = new global::System.Drawing.Size(38, 19);
			this.numericUpDownBlue.TabIndex = 17;
			this.numericUpDownBlue.ValueChanged += new global::System.EventHandler(this.numericUpDownBlue_ValueChanged);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(244, 196);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 13;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(244, 150);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 12;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			this.pictureBoxButtonPreview.Image = global::Clock.Properties.Resources.popup_btn_020;
			this.pictureBoxButtonPreview.Location = new global::System.Drawing.Point(244, 104);
			this.pictureBoxButtonPreview.Name = "pictureBoxButtonPreview";
			this.pictureBoxButtonPreview.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonPreview.TabIndex = 11;
			this.pictureBoxButtonPreview.TabStop = false;
			this.pictureBoxButtonPreview.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonPreview_MouseDown);
			this.pictureBoxButtonPreview.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonPreview_MouseEnter);
			this.pictureBoxButtonPreview.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonPreview_MouseLeave);
			this.pictureBoxButtonPreview.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonPreview_MouseUp);
			this.pictureBoxPreview.BackColor = global::System.Drawing.Color.Black;
			this.pictureBoxPreview.BackgroundImage = global::Clock.Properties.Resources.popup_led_000;
			this.pictureBoxPreview.Location = new global::System.Drawing.Point(264, 3);
			this.pictureBoxPreview.Name = "pictureBoxPreview";
			this.pictureBoxPreview.Size = new global::System.Drawing.Size(70, 70);
			this.pictureBoxPreview.TabIndex = 9;
			this.pictureBoxPreview.TabStop = false;
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxObi);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonPreview);
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.scrollBarBlue);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.numericUpDownRed);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.scrollBarGreen);
			this.splitContainer1.Panel2.Controls.Add(this.numericUpDownGreen);
			this.splitContainer1.Panel2.Controls.Add(this.scrollBarRed);
			this.splitContainer1.Panel2.Controls.Add(this.numericUpDownBlue);
			this.splitContainer1.Panel2.Controls.Add(this.groupBoxFade);
			this.splitContainer1.Panel2.Controls.Add(this.groupBoxLight);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxPreview);
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxColor);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Size = new global::System.Drawing.Size(368, 259);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 18;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(262, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 25);
			this.pictureBoxObi.TabIndex = 1;
			this.pictureBoxObi.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			base.ClientSize = new global::System.Drawing.Size(368, 259);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyLEDDialog";
			this.Text = "LED設定";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.BlockPropertyLEDDialog_FormClosing);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyLEDDialog_FormClosed);
			this.groupBoxFade.ResumeLayout(false);
			this.groupBoxFade.PerformLayout();
			this.groupBoxLight.ResumeLayout(false);
			this.groupBoxLight.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownTime).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownRed).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownGreen).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownBlue).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonPreview).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPreview).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000A4 RID: 164
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.HScrollBar scrollBarRed;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.HScrollBar scrollBarGreen;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.HScrollBar scrollBarBlue;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.PictureBox pictureBoxPreview;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.ComboBox comboBoxColor;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.PictureBox pictureBoxButtonPreview;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.RadioButton radioButtonFadeOut;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.RadioButton radioButtonFadeIn;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.RadioButton radioButtonFadeNone;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.RadioButton radioButtonLightOnTime;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.RadioButton radioButtonLightOff;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.RadioButton radioButtonLightOn;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.NumericUpDown numericUpDownTime;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.NumericUpDown numericUpDownRed;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.NumericUpDown numericUpDownGreen;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.NumericUpDown numericUpDownBlue;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.GroupBox groupBoxFade;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.GroupBox groupBoxLight;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.PictureBox pictureBoxObi;
	}
}
