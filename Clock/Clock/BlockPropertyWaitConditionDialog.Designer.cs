namespace Clock
{
	// Token: 0x02000018 RID: 24
	public partial class BlockPropertyWaitConditionDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x060001B1 RID: 433 RVA: 0x0001A29E File Offset: 0x0001849E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0001A2C0 File Offset: 0x000184C0
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyWaitConditionDialog));
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.labelAlarm = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.labelTime = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.groupBoxCondition = new global::System.Windows.Forms.GroupBox();
			this.numericUpDownTemperature = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDownMinute = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDownHour = new global::System.Windows.Forms.NumericUpDown();
			this.radioButtonTemperature = new global::System.Windows.Forms.RadioButton();
			this.radioButtonTime = new global::System.Windows.Forms.RadioButton();
			this.radioButtonTimer = new global::System.Windows.Forms.RadioButton();
			this.radioButtonAlarm = new global::System.Windows.Forms.RadioButton();
			this.radioButtonSound = new global::System.Windows.Forms.RadioButton();
			this.radioButtonLightDark = new global::System.Windows.Forms.RadioButton();
			this.radioButtonLightBright = new global::System.Windows.Forms.RadioButton();
			this.radioButtonButton = new global::System.Windows.Forms.RadioButton();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.groupBoxCondition.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownTemperature).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownMinute).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownHour).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(25, 27);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(44, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "ボタン";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(25, 85);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(56, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "光センサ";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(25, 180);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(56, 18);
			this.label3.TabIndex = 2;
			this.label3.Text = "音センサ";
			this.labelAlarm.AutoSize = true;
			this.labelAlarm.Location = new global::System.Drawing.Point(180, 27);
			this.labelAlarm.Name = "labelAlarm";
			this.labelAlarm.Size = new global::System.Drawing.Size(56, 18);
			this.labelAlarm.TabIndex = 3;
			this.labelAlarm.Text = "アラーム";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(180, 85);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(56, 18);
			this.label5.TabIndex = 4;
			this.label5.Text = "タイマー";
			this.labelTime.AutoSize = true;
			this.labelTime.Location = new global::System.Drawing.Point(180, 137);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new global::System.Drawing.Size(32, 18);
			this.labelTime.TabIndex = 5;
			this.labelTime.Text = "時刻";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(180, 197);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(32, 18);
			this.label7.TabIndex = 6;
			this.label7.Text = "温度";
			this.groupBoxCondition.Controls.Add(this.numericUpDownTemperature);
			this.groupBoxCondition.Controls.Add(this.numericUpDownMinute);
			this.groupBoxCondition.Controls.Add(this.numericUpDownHour);
			this.groupBoxCondition.Controls.Add(this.radioButtonTemperature);
			this.groupBoxCondition.Controls.Add(this.radioButtonTime);
			this.groupBoxCondition.Controls.Add(this.radioButtonTimer);
			this.groupBoxCondition.Controls.Add(this.radioButtonAlarm);
			this.groupBoxCondition.Controls.Add(this.radioButtonSound);
			this.groupBoxCondition.Controls.Add(this.radioButtonLightDark);
			this.groupBoxCondition.Controls.Add(this.radioButtonLightBright);
			this.groupBoxCondition.Controls.Add(this.radioButtonButton);
			this.groupBoxCondition.Controls.Add(this.label1);
			this.groupBoxCondition.Controls.Add(this.label7);
			this.groupBoxCondition.Controls.Add(this.label2);
			this.groupBoxCondition.Controls.Add(this.labelTime);
			this.groupBoxCondition.Controls.Add(this.label3);
			this.groupBoxCondition.Controls.Add(this.label5);
			this.groupBoxCondition.Controls.Add(this.labelAlarm);
			this.groupBoxCondition.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBoxCondition.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.groupBoxCondition.Location = new global::System.Drawing.Point(12, 3);
			this.groupBoxCondition.Name = "groupBoxCondition";
			this.groupBoxCondition.Size = new global::System.Drawing.Size(367, 258);
			this.groupBoxCondition.TabIndex = 7;
			this.groupBoxCondition.TabStop = false;
			this.groupBoxCondition.Text = "条件設定";
			this.numericUpDownTemperature.Location = new global::System.Drawing.Point(213, 220);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDownTemperature;
			int[] array = new int[4];
			array[0] = 50;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDownTemperature.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
			this.numericUpDownTemperature.Name = "numericUpDownTemperature";
			this.numericUpDownTemperature.Size = new global::System.Drawing.Size(45, 25);
			this.numericUpDownTemperature.TabIndex = 17;
			this.numericUpDownMinute.Location = new global::System.Drawing.Point(262, 160);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDownMinute;
			int[] array2 = new int[4];
			array2[0] = 59;
			numericUpDown2.Maximum = new decimal(array2);
			this.numericUpDownMinute.Name = "numericUpDownMinute";
			this.numericUpDownMinute.Size = new global::System.Drawing.Size(35, 25);
			this.numericUpDownMinute.TabIndex = 16;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDownMinute;
			int[] array3 = new int[4];
			array3[0] = 59;
			numericUpDown3.Value = new decimal(array3);
			this.numericUpDownHour.Location = new global::System.Drawing.Point(213, 160);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.numericUpDownHour;
			int[] array4 = new int[4];
			array4[0] = 23;
			numericUpDown4.Maximum = new decimal(array4);
			this.numericUpDownHour.Name = "numericUpDownHour";
			this.numericUpDownHour.Size = new global::System.Drawing.Size(35, 25);
			this.numericUpDownHour.TabIndex = 15;
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.numericUpDownHour;
			int[] array5 = new int[4];
			array5[0] = 23;
			numericUpDown5.Value = new decimal(array5);
			this.radioButtonTemperature.AutoSize = true;
			this.radioButtonTemperature.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonTemperature.Location = new global::System.Drawing.Point(194, 222);
			this.radioButtonTemperature.Name = "radioButtonTemperature";
			this.radioButtonTemperature.Size = new global::System.Drawing.Size(146, 22);
			this.radioButtonTemperature.TabIndex = 14;
			this.radioButtonTemperature.TabStop = true;
			this.radioButtonTemperature.Text = "\u3000\u3000\u3000\u3000℃になるまで";
			this.radioButtonTemperature.UseVisualStyleBackColor = true;
			this.radioButtonTemperature.CheckedChanged += new global::System.EventHandler(this.radioButtonTemperature_CheckedChanged);
			this.radioButtonTime.AutoSize = true;
			this.radioButtonTime.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonTime.Location = new global::System.Drawing.Point(194, 162);
			this.radioButtonTime.Name = "radioButtonTime";
			this.radioButtonTime.Size = new global::System.Drawing.Size(170, 22);
			this.radioButtonTime.TabIndex = 13;
			this.radioButtonTime.TabStop = true;
			this.radioButtonTime.Text = "\u3000\u3000   ：\u3000\u3000\u3000になるまで";
			this.radioButtonTime.UseVisualStyleBackColor = true;
			this.radioButtonTime.CheckedChanged += new global::System.EventHandler(this.radioButtonTime_CheckedChanged);
			this.radioButtonTimer.AutoSize = true;
			this.radioButtonTimer.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonTimer.Location = new global::System.Drawing.Point(194, 108);
			this.radioButtonTimer.Name = "radioButtonTimer";
			this.radioButtonTimer.Size = new global::System.Drawing.Size(104, 22);
			this.radioButtonTimer.TabIndex = 12;
			this.radioButtonTimer.TabStop = true;
			this.radioButtonTimer.Text = "ONになるまで";
			this.radioButtonTimer.UseVisualStyleBackColor = true;
			this.radioButtonTimer.CheckedChanged += new global::System.EventHandler(this.radioButtonTimer_CheckedChanged);
			this.radioButtonAlarm.AutoSize = true;
			this.radioButtonAlarm.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonAlarm.Location = new global::System.Drawing.Point(194, 52);
			this.radioButtonAlarm.Name = "radioButtonAlarm";
			this.radioButtonAlarm.Size = new global::System.Drawing.Size(104, 22);
			this.radioButtonAlarm.TabIndex = 11;
			this.radioButtonAlarm.TabStop = true;
			this.radioButtonAlarm.Text = "ONになるまで";
			this.radioButtonAlarm.UseVisualStyleBackColor = true;
			this.radioButtonAlarm.CheckedChanged += new global::System.EventHandler(this.radioButtonAlarm_CheckedChanged);
			this.radioButtonSound.AutoSize = true;
			this.radioButtonSound.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonSound.Location = new global::System.Drawing.Point(38, 205);
			this.radioButtonSound.Name = "radioButtonSound";
			this.radioButtonSound.Size = new global::System.Drawing.Size(98, 22);
			this.radioButtonSound.TabIndex = 10;
			this.radioButtonSound.TabStop = true;
			this.radioButtonSound.Text = "入力あるまで";
			this.radioButtonSound.UseVisualStyleBackColor = true;
			this.radioButtonSound.CheckedChanged += new global::System.EventHandler(this.radioButtonSound_CheckedChanged);
			this.radioButtonLightDark.AutoSize = true;
			this.radioButtonLightDark.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonLightDark.Location = new global::System.Drawing.Point(38, 139);
			this.radioButtonLightDark.Name = "radioButtonLightDark";
			this.radioButtonLightDark.Size = new global::System.Drawing.Size(98, 22);
			this.radioButtonLightDark.TabIndex = 9;
			this.radioButtonLightDark.TabStop = true;
			this.radioButtonLightDark.Text = "暗くなるまで";
			this.radioButtonLightDark.UseVisualStyleBackColor = true;
			this.radioButtonLightDark.CheckedChanged += new global::System.EventHandler(this.radioButtonLightDark_CheckedChanged);
			this.radioButtonLightBright.AutoSize = true;
			this.radioButtonLightBright.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonLightBright.Location = new global::System.Drawing.Point(38, 112);
			this.radioButtonLightBright.Name = "radioButtonLightBright";
			this.radioButtonLightBright.Size = new global::System.Drawing.Size(110, 22);
			this.radioButtonLightBright.TabIndex = 8;
			this.radioButtonLightBright.TabStop = true;
			this.radioButtonLightBright.Text = "明るくなるまで";
			this.radioButtonLightBright.UseVisualStyleBackColor = true;
			this.radioButtonLightBright.CheckedChanged += new global::System.EventHandler(this.radioButtonLightBright_CheckedChanged);
			this.radioButtonButton.AutoSize = true;
			this.radioButtonButton.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonButton.Location = new global::System.Drawing.Point(38, 52);
			this.radioButtonButton.Name = "radioButtonButton";
			this.radioButtonButton.Size = new global::System.Drawing.Size(98, 22);
			this.radioButtonButton.TabIndex = 7;
			this.radioButtonButton.TabStop = true;
			this.radioButtonButton.Text = "押されるまで";
			this.radioButtonButton.UseVisualStyleBackColor = true;
			this.radioButtonButton.CheckedChanged += new global::System.EventHandler(this.radioButtonButton_CheckedChanged);
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(70, 272);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 8;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(206, 272);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 9;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxObi);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Panel2.Controls.Add(this.groupBoxCondition);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Size = new global::System.Drawing.Size(391, 338);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 10;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(285, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 25);
			this.pictureBoxObi.TabIndex = 3;
			this.pictureBoxObi.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			base.ClientSize = new global::System.Drawing.Size(391, 338);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyWaitConditionDialog";
			this.Text = "条件待ち設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyWaitConditionDialog_FormClosed);
			this.groupBoxCondition.ResumeLayout(false);
			this.groupBoxCondition.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownTemperature).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownMinute).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownHour).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040001E1 RID: 481
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001E2 RID: 482
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040001E4 RID: 484
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040001E5 RID: 485
		private global::System.Windows.Forms.Label labelAlarm;

		// Token: 0x040001E6 RID: 486
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040001E7 RID: 487
		private global::System.Windows.Forms.Label labelTime;

		// Token: 0x040001E8 RID: 488
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040001E9 RID: 489
		private global::System.Windows.Forms.GroupBox groupBoxCondition;

		// Token: 0x040001EA RID: 490
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x040001EB RID: 491
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x040001EC RID: 492
		private global::System.Windows.Forms.NumericUpDown numericUpDownTemperature;

		// Token: 0x040001ED RID: 493
		private global::System.Windows.Forms.NumericUpDown numericUpDownMinute;

		// Token: 0x040001EE RID: 494
		private global::System.Windows.Forms.NumericUpDown numericUpDownHour;

		// Token: 0x040001EF RID: 495
		private global::System.Windows.Forms.RadioButton radioButtonTemperature;

		// Token: 0x040001F0 RID: 496
		private global::System.Windows.Forms.RadioButton radioButtonTime;

		// Token: 0x040001F1 RID: 497
		private global::System.Windows.Forms.RadioButton radioButtonTimer;

		// Token: 0x040001F2 RID: 498
		private global::System.Windows.Forms.RadioButton radioButtonAlarm;

		// Token: 0x040001F3 RID: 499
		private global::System.Windows.Forms.RadioButton radioButtonSound;

		// Token: 0x040001F4 RID: 500
		private global::System.Windows.Forms.RadioButton radioButtonLightDark;

		// Token: 0x040001F5 RID: 501
		private global::System.Windows.Forms.RadioButton radioButtonLightBright;

		// Token: 0x040001F6 RID: 502
		private global::System.Windows.Forms.RadioButton radioButtonButton;

		// Token: 0x040001F7 RID: 503
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040001F8 RID: 504
		private global::System.Windows.Forms.PictureBox pictureBoxObi;
	}
}
