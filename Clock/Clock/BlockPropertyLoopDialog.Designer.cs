namespace Clock
{
	// Token: 0x0200000C RID: 12
	public partial class BlockPropertyLoopDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x060000C2 RID: 194 RVA: 0x0000C6BD File Offset: 0x0000A8BD
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000C6DC File Offset: 0x0000A8DC
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyLoopDialog));
			this.groupBoxLoop = new global::System.Windows.Forms.GroupBox();
			this.numericUpDownCount = new global::System.Windows.Forms.NumericUpDown();
			this.radioButtonEternal = new global::System.Windows.Forms.RadioButton();
			this.radioButtonCount = new global::System.Windows.Forms.RadioButton();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.groupBoxLoop.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownCount).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			base.SuspendLayout();
			this.groupBoxLoop.Controls.Add(this.numericUpDownCount);
			this.groupBoxLoop.Controls.Add(this.radioButtonEternal);
			this.groupBoxLoop.Controls.Add(this.radioButtonCount);
			this.groupBoxLoop.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBoxLoop.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.groupBoxLoop.Location = new global::System.Drawing.Point(36, 7);
			this.groupBoxLoop.Name = "groupBoxLoop";
			this.groupBoxLoop.Size = new global::System.Drawing.Size(200, 72);
			this.groupBoxLoop.TabIndex = 0;
			this.groupBoxLoop.TabStop = false;
			this.groupBoxLoop.Text = "ループ回数";
			this.numericUpDownCount.Location = new global::System.Drawing.Point(48, 40);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDownCount;
			int[] array = new int[4];
			array[0] = 255;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDownCount;
			int[] array2 = new int[4];
			array2[0] = 1;
			numericUpDown2.Minimum = new decimal(array2);
			this.numericUpDownCount.Name = "numericUpDownCount";
			this.numericUpDownCount.Size = new global::System.Drawing.Size(42, 25);
			this.numericUpDownCount.TabIndex = 2;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDownCount;
			int[] array3 = new int[4];
			array3[0] = 2;
			numericUpDown3.Value = new decimal(array3);
			this.radioButtonEternal.AutoSize = true;
			this.radioButtonEternal.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonEternal.Location = new global::System.Drawing.Point(25, 19);
			this.radioButtonEternal.Name = "radioButtonEternal";
			this.radioButtonEternal.Size = new global::System.Drawing.Size(110, 22);
			this.radioButtonEternal.TabIndex = 1;
			this.radioButtonEternal.Text = "ずっとくり返す";
			this.radioButtonEternal.UseVisualStyleBackColor = true;
			this.radioButtonEternal.CheckedChanged += new global::System.EventHandler(this.radioButtonEternal_CheckedChanged);
			this.radioButtonCount.AutoSize = true;
			this.radioButtonCount.Checked = true;
			this.radioButtonCount.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonCount.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonCount.Location = new global::System.Drawing.Point(25, 42);
			this.radioButtonCount.Name = "radioButtonCount";
			this.radioButtonCount.Size = new global::System.Drawing.Size(138, 22);
			this.radioButtonCount.TabIndex = 0;
			this.radioButtonCount.TabStop = true;
			this.radioButtonCount.Text = "             回くり返す";
			this.radioButtonCount.UseVisualStyleBackColor = true;
			this.radioButtonCount.CheckedChanged += new global::System.EventHandler(this.radioButtonCount_CheckedChanged);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(147, 85);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 2;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(25, 85);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 1;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxObi);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Panel2.Controls.Add(this.groupBoxLoop);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Size = new global::System.Drawing.Size(274, 151);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 3;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(168, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 25);
			this.pictureBoxObi.TabIndex = 2;
			this.pictureBoxObi.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			base.ClientSize = new global::System.Drawing.Size(274, 151);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyLoopDialog";
			this.Text = "ループ設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyLoopDialog_FormClosed);
			this.groupBoxLoop.ResumeLayout(false);
			this.groupBoxLoop.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownCount).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000C0 RID: 192
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.GroupBox groupBoxLoop;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.RadioButton radioButtonEternal;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.RadioButton radioButtonCount;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.NumericUpDown numericUpDownCount;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.PictureBox pictureBoxObi;
	}
}
