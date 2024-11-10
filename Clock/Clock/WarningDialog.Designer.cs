namespace Clock
{
	// Token: 0x0200005B RID: 91
	public partial class WarningDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x060009A7 RID: 2471 RVA: 0x0006C900 File Offset: 0x0006AB00
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0006C920 File Offset: 0x0006AB20
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.WarningDialog));
			this.labelText = new global::System.Windows.Forms.Label();
			this.pictureBoxIcon = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxIcon).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			base.SuspendLayout();
			this.labelText.AutoSize = true;
			this.labelText.Font = new global::System.Drawing.Font("メイリオ", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelText.Location = new global::System.Drawing.Point(64, 20);
			this.labelText.Name = "labelText";
			this.labelText.Size = new global::System.Drawing.Size(52, 21);
			this.labelText.TabIndex = 2;
			this.labelText.Text = "警告文";
			this.pictureBoxIcon.Image = global::Clock.Properties.Resources.popup_icon_000;
			this.pictureBoxIcon.Location = new global::System.Drawing.Point(24, 14);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new global::System.Drawing.Size(34, 34);
			this.pictureBoxIcon.TabIndex = 1;
			this.pictureBoxIcon.TabStop = false;
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(131, 65);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 0;
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
			this.splitContainer1.Panel2.Controls.Add(this.labelText);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxIcon);
			this.splitContainer1.Size = new global::System.Drawing.Size(377, 128);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 3;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(271, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 25);
			this.pictureBoxObi.TabIndex = 5;
			this.pictureBoxObi.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			base.ClientSize = new global::System.Drawing.Size(377, 128);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "WarningDialog";
			this.Text = "警告";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.WarningDialog_FormClosed);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxIcon).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040006DF RID: 1759
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040006E0 RID: 1760
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x040006E1 RID: 1761
		private global::System.Windows.Forms.PictureBox pictureBoxIcon;

		// Token: 0x040006E2 RID: 1762
		private global::System.Windows.Forms.Label labelText;

		// Token: 0x040006E3 RID: 1763
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040006E4 RID: 1764
		private global::System.Windows.Forms.PictureBox pictureBoxObi;
	}
}
