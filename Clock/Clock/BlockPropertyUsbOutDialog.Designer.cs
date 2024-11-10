namespace Clock
{
	// Token: 0x02000017 RID: 23
	public partial class BlockPropertyUsbOutDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600019C RID: 412 RVA: 0x000193C2 File Offset: 0x000175C2
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x000193E4 File Offset: 0x000175E4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyUsbOutDialog));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.numericUpDownPower = new global::System.Windows.Forms.NumericUpDown();
			this.hScrollBarPower = new global::System.Windows.Forms.HScrollBar();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.numericUpDownTime = new global::System.Windows.Forms.NumericUpDown();
			this.radioButtonOff = new global::System.Windows.Forms.RadioButton();
			this.radioButtonOnTime = new global::System.Windows.Forms.RadioButton();
			this.radioButtonOn = new global::System.Windows.Forms.RadioButton();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownPower).BeginInit();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownTime).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxObi);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Size = new global::System.Drawing.Size(370, 305);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 4;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(264, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 25);
			this.pictureBoxObi.TabIndex = 5;
			this.pictureBoxObi.TabStop = false;
			this.groupBox2.Controls.Add(this.numericUpDownPower);
			this.groupBox2.Controls.Add(this.hScrollBarPower);
			this.groupBox2.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBox2.Location = new global::System.Drawing.Point(33, 141);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(301, 67);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "出力の強さ";
			this.numericUpDownPower.Location = new global::System.Drawing.Point(231, 25);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDownPower;
			int[] array = new int[4];
			array[0] = 10;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDownPower.Name = "numericUpDownPower";
			this.numericUpDownPower.Size = new global::System.Drawing.Size(47, 25);
			this.numericUpDownPower.TabIndex = 1;
			this.numericUpDownPower.ValueChanged += new global::System.EventHandler(this.numericUpDownPower_ValueChanged);
			this.hScrollBarPower.LargeChange = 1;
			this.hScrollBarPower.Location = new global::System.Drawing.Point(23, 25);
			this.hScrollBarPower.Maximum = 10;
			this.hScrollBarPower.Name = "hScrollBarPower";
			this.hScrollBarPower.Size = new global::System.Drawing.Size(191, 25);
			this.hScrollBarPower.TabIndex = 0;
			this.hScrollBarPower.ValueChanged += new global::System.EventHandler(this.hScrollBarPower_ValueChanged);
			this.groupBox1.Controls.Add(this.numericUpDownTime);
			this.groupBox1.Controls.Add(this.radioButtonOff);
			this.groupBox1.Controls.Add(this.radioButtonOnTime);
			this.groupBox1.Controls.Add(this.radioButtonOn);
			this.groupBox1.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBox1.Location = new global::System.Drawing.Point(33, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(301, 100);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "出力操作";
			this.numericUpDownTime.DecimalPlaces = 1;
			this.numericUpDownTime.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
			this.numericUpDownTime.Location = new global::System.Drawing.Point(40, 57);
			this.numericUpDownTime.Maximum = new decimal(new int[] { 255, 0, 0, 65536 });
			this.numericUpDownTime.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
			this.numericUpDownTime.Name = "numericUpDownTime";
			this.numericUpDownTime.Size = new global::System.Drawing.Size(53, 25);
			this.numericUpDownTime.TabIndex = 3;
			this.numericUpDownTime.Value = new decimal(new int[] { 1, 0, 0, 65536 });
			this.radioButtonOff.AutoSize = true;
			this.radioButtonOff.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonOff.Location = new global::System.Drawing.Point(155, 29);
			this.radioButtonOff.Name = "radioButtonOff";
			this.radioButtonOff.Size = new global::System.Drawing.Size(85, 22);
			this.radioButtonOff.TabIndex = 2;
			this.radioButtonOff.Text = "出力をOFF";
			this.radioButtonOff.UseVisualStyleBackColor = true;
			this.radioButtonOff.CheckedChanged += new global::System.EventHandler(this.radioButtonOff_CheckedChanged);
			this.radioButtonOnTime.AutoSize = true;
			this.radioButtonOnTime.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonOnTime.Location = new global::System.Drawing.Point(23, 57);
			this.radioButtonOnTime.Name = "radioButtonOnTime";
			this.radioButtonOnTime.Size = new global::System.Drawing.Size(134, 22);
			this.radioButtonOnTime.TabIndex = 1;
			this.radioButtonOnTime.Text = "\u3000\u3000\u3000\u3000\u3000秒間出力";
			this.radioButtonOnTime.UseVisualStyleBackColor = true;
			this.radioButtonOnTime.CheckedChanged += new global::System.EventHandler(this.radioButtonOnTime_CheckedChanged);
			this.radioButtonOn.AutoSize = true;
			this.radioButtonOn.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonOn.Location = new global::System.Drawing.Point(23, 29);
			this.radioButtonOn.Name = "radioButtonOn";
			this.radioButtonOn.Size = new global::System.Drawing.Size(80, 22);
			this.radioButtonOn.TabIndex = 0;
			this.radioButtonOn.Text = "出力をON";
			this.radioButtonOn.UseVisualStyleBackColor = true;
			this.radioButtonOn.CheckedChanged += new global::System.EventHandler(this.radioButtonOn_CheckedChanged);
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(56, 237);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 4;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(211, 237);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 5;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			base.ClientSize = new global::System.Drawing.Size(370, 305);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyUsbOutDialog";
			this.Text = "外部出力設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyUsbOutDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			this.groupBox2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownPower).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownTime).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040001D2 RID: 466
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001D3 RID: 467
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040001D4 RID: 468
		private global::System.Windows.Forms.PictureBox pictureBoxObi;

		// Token: 0x040001D5 RID: 469
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x040001D7 RID: 471
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040001D8 RID: 472
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040001D9 RID: 473
		private global::System.Windows.Forms.RadioButton radioButtonOn;

		// Token: 0x040001DA RID: 474
		private global::System.Windows.Forms.RadioButton radioButtonOff;

		// Token: 0x040001DB RID: 475
		private global::System.Windows.Forms.RadioButton radioButtonOnTime;

		// Token: 0x040001DC RID: 476
		private global::System.Windows.Forms.NumericUpDown numericUpDownPower;

		// Token: 0x040001DD RID: 477
		private global::System.Windows.Forms.HScrollBar hScrollBarPower;

		// Token: 0x040001DE RID: 478
		private global::System.Windows.Forms.NumericUpDown numericUpDownTime;
	}
}
