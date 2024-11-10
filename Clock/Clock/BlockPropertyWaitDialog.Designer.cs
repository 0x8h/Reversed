namespace Clock
{
	// Token: 0x02000019 RID: 25
	public partial class BlockPropertyWaitDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x060001BE RID: 446 RVA: 0x0001B6B3 File Offset: 0x000198B3
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0001B6D4 File Offset: 0x000198D4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyWaitDialog));
			this.numericUpDownTime = new global::System.Windows.Forms.NumericUpDown();
			this.labelWait = new global::System.Windows.Forms.Label();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownTime).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			base.SuspendLayout();
			this.numericUpDownTime.DecimalPlaces = 1;
			this.numericUpDownTime.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
			this.numericUpDownTime.Location = new global::System.Drawing.Point(67, 13);
			this.numericUpDownTime.Maximum = new decimal(new int[] { 255, 0, 0, 65536 });
			this.numericUpDownTime.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
			this.numericUpDownTime.Name = "numericUpDownTime";
			this.numericUpDownTime.Size = new global::System.Drawing.Size(48, 19);
			this.numericUpDownTime.TabIndex = 0;
			this.numericUpDownTime.Value = new decimal(new int[] { 1, 0, 0, 65536 });
			this.labelWait.AutoSize = true;
			this.labelWait.Font = new global::System.Drawing.Font("メイリオ", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelWait.Location = new global::System.Drawing.Point(121, 13);
			this.labelWait.Name = "labelWait";
			this.labelWait.Size = new global::System.Drawing.Size(94, 21);
			this.labelWait.TabIndex = 1;
			this.labelWait.Text = "秒間ウェイト";
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(146, 53);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 3;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(25, 53);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 2;
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
			this.splitContainer1.Panel2.Controls.Add(this.labelWait);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Panel2.Controls.Add(this.numericUpDownTime);
			this.splitContainer1.Size = new global::System.Drawing.Size(274, 121);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 4;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(168, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 25);
			this.pictureBoxObi.TabIndex = 4;
			this.pictureBoxObi.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			base.ClientSize = new global::System.Drawing.Size(274, 121);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyWaitDialog";
			this.Text = "ウェイト設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyWaitDialog_FormClosed);
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownTime).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040001FB RID: 507
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001FC RID: 508
		private global::System.Windows.Forms.NumericUpDown numericUpDownTime;

		// Token: 0x040001FD RID: 509
		private global::System.Windows.Forms.Label labelWait;

		// Token: 0x040001FE RID: 510
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x040001FF RID: 511
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x04000200 RID: 512
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000201 RID: 513
		private global::System.Windows.Forms.PictureBox pictureBoxObi;
	}
}
