namespace Clock
{
	// Token: 0x02000005 RID: 5
	public partial class BlockPropertyCounterDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x06000037 RID: 55 RVA: 0x000043FB File Offset: 0x000025FB
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000441C File Offset: 0x0000261C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyCounterDialog));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.radioButtonReset = new global::System.Windows.Forms.RadioButton();
			this.radioButtonStart = new global::System.Windows.Forms.RadioButton();
			this.radioButtonStop = new global::System.Windows.Forms.RadioButton();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonReset);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonStart);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonStop);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Size = new global::System.Drawing.Size(284, 157);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(178, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(106, 25);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.radioButtonReset.AutoSize = true;
			this.radioButtonReset.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonReset.Location = new global::System.Drawing.Point(64, 61);
			this.radioButtonReset.Name = "radioButtonReset";
			this.radioButtonReset.Size = new global::System.Drawing.Size(130, 16);
			this.radioButtonReset.TabIndex = 5;
			this.radioButtonReset.Text = "秒カウンタをリセットする";
			this.radioButtonReset.UseVisualStyleBackColor = true;
			this.radioButtonStart.AutoSize = true;
			this.radioButtonStart.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonStart.Location = new global::System.Drawing.Point(64, 17);
			this.radioButtonStart.Name = "radioButtonStart";
			this.radioButtonStart.Size = new global::System.Drawing.Size(111, 16);
			this.radioButtonStart.TabIndex = 2;
			this.radioButtonStart.Text = "秒カウンタを動かす";
			this.radioButtonStart.UseVisualStyleBackColor = true;
			this.radioButtonStop.AutoSize = true;
			this.radioButtonStop.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonStop.Location = new global::System.Drawing.Point(64, 39);
			this.radioButtonStop.Name = "radioButtonStop";
			this.radioButtonStop.Size = new global::System.Drawing.Size(110, 16);
			this.radioButtonStop.TabIndex = 3;
			this.radioButtonStop.Text = "秒カウンタを止める";
			this.radioButtonStop.UseVisualStyleBackColor = true;
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(28, 94);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 3;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(152, 94);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 4;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 157);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyCounterDialog";
			this.Text = "秒カウンタ設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyCounterDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000026 RID: 38
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.RadioButton radioButtonReset;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.RadioButton radioButtonStart;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.RadioButton radioButtonStop;
	}
}
