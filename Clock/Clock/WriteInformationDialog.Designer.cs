﻿namespace Clock
{
	// Token: 0x0200005C RID: 92
	public partial class WriteInformationDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x060009B5 RID: 2485 RVA: 0x0006CF31 File Offset: 0x0006B131
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x0006CF50 File Offset: 0x0006B150
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.WriteInformationDialog));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonRun = new global::System.Windows.Forms.PictureBox();
			this.labelText = new global::System.Windows.Forms.Label();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRun).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxObi);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonRun);
			this.splitContainer1.Panel2.Controls.Add(this.labelText);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Size = new global::System.Drawing.Size(377, 128);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 1;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(271, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 25);
			this.pictureBoxObi.TabIndex = 6;
			this.pictureBoxObi.TabStop = false;
			this.pictureBoxButtonRun.Image = global::Clock.Properties.Resources.sim_btn_050;
			this.pictureBoxButtonRun.Location = new global::System.Drawing.Point(202, 59);
			this.pictureBoxButtonRun.Name = "pictureBoxButtonRun";
			this.pictureBoxButtonRun.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonRun.TabIndex = 4;
			this.pictureBoxButtonRun.TabStop = false;
			this.pictureBoxButtonRun.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRun_MouseDown);
			this.pictureBoxButtonRun.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonRun_MouseEnter);
			this.pictureBoxButtonRun.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonRun_MouseLeave);
			this.pictureBoxButtonRun.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRun_MouseUp);
			this.labelText.AutoSize = true;
			this.labelText.Font = new global::System.Drawing.Font("メイリオ", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelText.Location = new global::System.Drawing.Point(115, 23);
			this.labelText.Name = "labelText";
			this.labelText.Size = new global::System.Drawing.Size(164, 21);
			this.labelText.TabIndex = 3;
			this.labelText.Text = "書込みが完了しました。";
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(74, 59);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 1;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			base.ClientSize = new global::System.Drawing.Size(377, 128);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "WriteInformationDialog";
			this.Text = "WriteInformationDialog";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.WriteInformationDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRun).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040006E6 RID: 1766
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040006E7 RID: 1767
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040006E8 RID: 1768
		private global::System.Windows.Forms.PictureBox pictureBoxObi;

		// Token: 0x040006E9 RID: 1769
		private global::System.Windows.Forms.Label labelText;

		// Token: 0x040006EA RID: 1770
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x040006EB RID: 1771
		private global::System.Windows.Forms.PictureBox pictureBoxButtonRun;
	}
}
