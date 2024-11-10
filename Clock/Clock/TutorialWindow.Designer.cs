namespace Clock
{
	// Token: 0x02000059 RID: 89
	public partial class TutorialWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06000999 RID: 2457 RVA: 0x0006BD05 File Offset: 0x00069F05
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0006BD24 File Offset: 0x00069F24
		private void InitializeComponent()
		{
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonQuit = new global::System.Windows.Forms.PictureBox();
			this.labelText = new global::System.Windows.Forms.Label();
			this.pictureBoxImage = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonNext = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonQuit).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxImage).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNext).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxObi);
			this.splitContainer1.Panel1MinSize = 20;
			this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonQuit);
			this.splitContainer1.Panel2.Controls.Add(this.labelText);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxImage);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonNext);
			this.splitContainer1.Size = new global::System.Drawing.Size(432, 321);
			this.splitContainer1.SplitterDistance = 27;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.sim_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(258, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(174, 27);
			this.pictureBoxObi.TabIndex = 2;
			this.pictureBoxObi.TabStop = false;
			this.pictureBoxButtonQuit.Image = global::Clock.Properties.Resources.tutorial_btn010;
			this.pictureBoxButtonQuit.Location = new global::System.Drawing.Point(236, 255);
			this.pictureBoxButtonQuit.Name = "pictureBoxButtonQuit";
			this.pictureBoxButtonQuit.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonQuit.TabIndex = 8;
			this.pictureBoxButtonQuit.TabStop = false;
			this.pictureBoxButtonQuit.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonQuit_MouseDown);
			this.pictureBoxButtonQuit.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonQuit_MouseEnter);
			this.pictureBoxButtonQuit.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonQuit_MouseLeave);
			this.pictureBoxButtonQuit.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonQuit_MouseUp);
			this.labelText.AutoSize = true;
			this.labelText.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelText.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.labelText.Location = new global::System.Drawing.Point(45, 213);
			this.labelText.Name = "labelText";
			this.labelText.Size = new global::System.Drawing.Size(42, 18);
			this.labelText.TabIndex = 7;
			this.labelText.Text = "label1";
			this.pictureBoxImage.Location = new global::System.Drawing.Point(12, 5);
			this.pictureBoxImage.Name = "pictureBoxImage";
			this.pictureBoxImage.Size = new global::System.Drawing.Size(412, 200);
			this.pictureBoxImage.TabIndex = 6;
			this.pictureBoxImage.TabStop = false;
			this.pictureBoxButtonNext.Image = global::Clock.Properties.Resources.tutorial_btn020;
			this.pictureBoxButtonNext.Location = new global::System.Drawing.Point(94, 255);
			this.pictureBoxButtonNext.Name = "pictureBoxButtonNext";
			this.pictureBoxButtonNext.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonNext.TabIndex = 4;
			this.pictureBoxButtonNext.TabStop = false;
			this.pictureBoxButtonNext.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNext_MouseDown);
			this.pictureBoxButtonNext.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonNext_MouseEnter);
			this.pictureBoxButtonNext.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonNext_MouseLeave);
			this.pictureBoxButtonNext.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNext_MouseUp);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(432, 321);
			base.ControlBox = false;
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "TutorialWindow";
			this.Text = "チュートリアル";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.TutorialWindow_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonQuit).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxImage).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNext).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040006CF RID: 1743
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040006D0 RID: 1744
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040006D1 RID: 1745
		private global::System.Windows.Forms.PictureBox pictureBoxObi;

		// Token: 0x040006D2 RID: 1746
		private global::System.Windows.Forms.Label labelText;

		// Token: 0x040006D3 RID: 1747
		private global::System.Windows.Forms.PictureBox pictureBoxImage;

		// Token: 0x040006D4 RID: 1748
		private global::System.Windows.Forms.PictureBox pictureBoxButtonNext;

		// Token: 0x040006D5 RID: 1749
		private global::System.Windows.Forms.PictureBox pictureBoxButtonQuit;
	}
}
