namespace Clock
{
	// Token: 0x02000031 RID: 49
	public partial class NetworkCheckWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x060005A0 RID: 1440 RVA: 0x00043D31 File Offset: 0x00041F31
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x00043D50 File Offset: 0x00041F50
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.NetworkCheckWindow));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.labelIP = new global::System.Windows.Forms.Label();
			this.pictureBoxButtonReset = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonCheck = new global::System.Windows.Forms.PictureBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.labelSender = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonReset).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCheck).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
			this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer1.Panel2.Controls.Add(this.labelSender);
			this.splitContainer1.Panel2.Controls.Add(this.labelIP);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonReset);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCheck);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Size = new global::System.Drawing.Size(284, 169);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(178, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(106, 25);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			this.labelIP.AutoSize = true;
			this.labelIP.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelIP.ForeColor = global::System.Drawing.Color.Black;
			this.labelIP.Location = new global::System.Drawing.Point(12, 10);
			this.labelIP.Name = "labelIP";
			this.labelIP.Size = new global::System.Drawing.Size(73, 18);
			this.labelIP.TabIndex = 9;
			this.labelIP.Text = "IPアドレス:";
			this.pictureBoxButtonReset.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonReset.Location = new global::System.Drawing.Point(152, 103);
			this.pictureBoxButtonReset.Name = "pictureBoxButtonReset";
			this.pictureBoxButtonReset.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonReset.TabIndex = 4;
			this.pictureBoxButtonReset.TabStop = false;
			this.pictureBoxButtonReset.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonReset_MouseDown);
			this.pictureBoxButtonReset.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonReset_MouseEnter);
			this.pictureBoxButtonReset.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonReset_MouseLeave);
			this.pictureBoxButtonReset.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonReset_MouseUp);
			this.pictureBoxButtonCheck.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonCheck.Location = new global::System.Drawing.Point(28, 103);
			this.pictureBoxButtonCheck.Name = "pictureBoxButtonCheck";
			this.pictureBoxButtonCheck.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCheck.TabIndex = 3;
			this.pictureBoxButtonCheck.TabStop = false;
			this.pictureBoxButtonCheck.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCheck_MouseDown);
			this.pictureBoxButtonCheck.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCheck_MouseEnter);
			this.pictureBoxButtonCheck.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCheck_MouseLeave);
			this.pictureBoxButtonCheck.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCheck_MouseUp);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("メイリオ", 20f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label1.Location = new global::System.Drawing.Point(75, 37);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(126, 41);
			this.label1.TabIndex = 0;
			this.label1.Text = "通信ＯＫ";
			this.label1.Visible = false;
			this.labelSender.AutoSize = true;
			this.labelSender.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelSender.ForeColor = global::System.Drawing.Color.Black;
			this.labelSender.Location = new global::System.Drawing.Point(12, 78);
			this.labelSender.Name = "labelSender";
			this.labelSender.Size = new global::System.Drawing.Size(49, 18);
			this.labelSender.TabIndex = 10;
			this.labelSender.Text = "送信者:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 169);
			base.Controls.Add(this.splitContainer1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "NetworkCheckWindow";
			this.Text = "通信チェック";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.NetworkCheckWindow_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonReset).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCheck).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000468 RID: 1128
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000469 RID: 1129
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x0400046A RID: 1130
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400046B RID: 1131
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400046C RID: 1132
		private global::System.Windows.Forms.PictureBox pictureBoxButtonReset;

		// Token: 0x0400046D RID: 1133
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCheck;

		// Token: 0x0400046E RID: 1134
		private global::System.Windows.Forms.Label labelIP;

		// Token: 0x0400046F RID: 1135
		private global::System.Windows.Forms.Label labelSender;
	}
}
