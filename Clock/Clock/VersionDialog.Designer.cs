namespace Clock
{
	// Token: 0x0200005A RID: 90
	public partial class VersionDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600099D RID: 2461 RVA: 0x0006C35E File Offset: 0x0006A55E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x0006C380 File Offset: 0x0006A580
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.VersionDialog));
			this.labelText = new global::System.Windows.Forms.Label();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			base.SuspendLayout();
			this.labelText.AutoSize = true;
			this.labelText.Font = new global::System.Drawing.Font("メイリオ", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelText.Location = new global::System.Drawing.Point(35, 49);
			this.labelText.Name = "labelText";
			this.labelText.Size = new global::System.Drawing.Size(36, 21);
			this.labelText.TabIndex = 0;
			this.labelText.Text = "text";
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxObi);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.Panel2.Controls.Add(this.pictureBox3);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
			this.splitContainer1.Panel2.Controls.Add(this.labelText);
			this.splitContainer1.Size = new global::System.Drawing.Size(353, 136);
			this.splitContainer1.SplitterDistance = 26;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 1;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(247, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 26);
			this.pictureBoxObi.TabIndex = 5;
			this.pictureBoxObi.TabStop = false;
			this.pictureBox3.Image = global::Clock.Properties.Resources.popup_logo_001;
			this.pictureBox3.Location = new global::System.Drawing.Point(254, 14);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(89, 97);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 2;
			this.pictureBox3.TabStop = false;
			this.pictureBox2.Image = global::Clock.Properties.Resources.popup_logo_002;
			this.pictureBox2.Location = new global::System.Drawing.Point(21, 5);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(232, 38);
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			base.ClientSize = new global::System.Drawing.Size(353, 136);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "VersionDialog";
			this.Text = "バージョン情報";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.VersionDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040006D9 RID: 1753
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040006DA RID: 1754
		private global::System.Windows.Forms.Label labelText;

		// Token: 0x040006DB RID: 1755
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040006DC RID: 1756
		private global::System.Windows.Forms.PictureBox pictureBoxObi;

		// Token: 0x040006DD RID: 1757
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x040006DE RID: 1758
		private global::System.Windows.Forms.PictureBox pictureBox2;
	}
}
