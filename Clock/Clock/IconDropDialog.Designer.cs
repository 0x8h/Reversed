namespace Clock
{
	// Token: 0x02000027 RID: 39
	public partial class IconDropDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x060003B1 RID: 945 RVA: 0x000307C1 File Offset: 0x0002E9C1
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x000307E0 File Offset: 0x0002E9E0
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.IconDropDialog));
			this.label1 = new global::System.Windows.Forms.Label();
			this.pictureBoxInsert = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxWrite = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxCancel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxIcon = new global::System.Windows.Forms.PictureBox();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxInsert).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWrite).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCancel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxIcon).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("メイリオ", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label1.Location = new global::System.Drawing.Point(101, 22);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(178, 21);
			this.label1.TabIndex = 3;
			this.label1.Text = "どのように追加しますか？";
			this.pictureBoxInsert.Image = global::Clock.Properties.Resources.popup_btn_040;
			this.pictureBoxInsert.Location = new global::System.Drawing.Point(130, 62);
			this.pictureBoxInsert.Name = "pictureBoxInsert";
			this.pictureBoxInsert.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxInsert.TabIndex = 6;
			this.pictureBoxInsert.TabStop = false;
			this.pictureBoxInsert.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxInsert_MouseDown);
			this.pictureBoxInsert.MouseEnter += new global::System.EventHandler(this.pictureBoxInsert_MouseEnter);
			this.pictureBoxInsert.MouseLeave += new global::System.EventHandler(this.pictureBoxInsert_MouseLeave);
			this.pictureBoxInsert.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxInsert_MouseUp);
			this.pictureBoxWrite.Image = global::Clock.Properties.Resources.popup_btn_030;
			this.pictureBoxWrite.Location = new global::System.Drawing.Point(12, 62);
			this.pictureBoxWrite.Name = "pictureBoxWrite";
			this.pictureBoxWrite.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxWrite.TabIndex = 5;
			this.pictureBoxWrite.TabStop = false;
			this.pictureBoxWrite.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxWrite_MouseDown);
			this.pictureBoxWrite.MouseEnter += new global::System.EventHandler(this.pictureBoxWrite_MouseEnter);
			this.pictureBoxWrite.MouseLeave += new global::System.EventHandler(this.pictureBoxWrite_MouseLeave);
			this.pictureBoxWrite.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxWrite_MouseUp);
			this.pictureBoxCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxCancel.Location = new global::System.Drawing.Point(250, 62);
			this.pictureBoxCancel.Name = "pictureBoxCancel";
			this.pictureBoxCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxCancel.TabIndex = 4;
			this.pictureBoxCancel.TabStop = false;
			this.pictureBoxCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxCancel_MouseDown);
			this.pictureBoxCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxCancel_MouseEnter);
			this.pictureBoxCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxCancel_MouseLeave);
			this.pictureBoxCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxCancel_MouseUp);
			this.pictureBoxIcon.Image = global::Clock.Properties.Resources.popup_icon_010;
			this.pictureBoxIcon.Location = new global::System.Drawing.Point(61, 14);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new global::System.Drawing.Size(34, 34);
			this.pictureBoxIcon.TabIndex = 7;
			this.pictureBoxIcon.TabStop = false;
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxObi);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxWrite);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxIcon);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxInsert);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxCancel);
			this.splitContainer1.Size = new global::System.Drawing.Size(377, 128);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 8;
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
			base.Name = "IconDropDialog";
			this.Text = "追加方法";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.IconDropDialog_FormClosed);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxInsert).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWrite).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxIcon).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000302 RID: 770
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000303 RID: 771
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000304 RID: 772
		private global::System.Windows.Forms.PictureBox pictureBoxCancel;

		// Token: 0x04000305 RID: 773
		private global::System.Windows.Forms.PictureBox pictureBoxWrite;

		// Token: 0x04000306 RID: 774
		private global::System.Windows.Forms.PictureBox pictureBoxInsert;

		// Token: 0x04000307 RID: 775
		private global::System.Windows.Forms.PictureBox pictureBoxIcon;

		// Token: 0x04000308 RID: 776
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000309 RID: 777
		private global::System.Windows.Forms.PictureBox pictureBoxObi;
	}
}
