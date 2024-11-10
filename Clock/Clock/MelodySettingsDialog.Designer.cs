namespace Clock
{
	// Token: 0x0200002E RID: 46
	public partial class MelodySettingsDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x060004C2 RID: 1218 RVA: 0x0003D2CF File Offset: 0x0003B4CF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0003D2F0 File Offset: 0x0003B4F0
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.MelodySettingsDialog));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.groupBoxTempo = new global::System.Windows.Forms.GroupBox();
			this.comboBoxTempo = new global::System.Windows.Forms.ComboBox();
			this.groupBoxLink = new global::System.Windows.Forms.GroupBox();
			this.radioButtonLinkOn = new global::System.Windows.Forms.RadioButton();
			this.radioButtonLinkOff = new global::System.Windows.Forms.RadioButton();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			this.groupBoxTempo.SuspendLayout();
			this.groupBoxLink.SuspendLayout();
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
			this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer1.Panel2.Controls.Add(this.groupBoxTempo);
			this.splitContainer1.Panel2.Controls.Add(this.groupBoxLink);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Size = new global::System.Drawing.Size(284, 261);
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 1;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(178, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 50);
			this.pictureBoxObi.TabIndex = 2;
			this.pictureBoxObi.TabStop = false;
			this.groupBoxTempo.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.groupBoxTempo.Controls.Add(this.comboBoxTempo);
			this.groupBoxTempo.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBoxTempo.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.groupBoxTempo.Location = new global::System.Drawing.Point(54, 14);
			this.groupBoxTempo.Name = "groupBoxTempo";
			this.groupBoxTempo.Size = new global::System.Drawing.Size(178, 63);
			this.groupBoxTempo.TabIndex = 22;
			this.groupBoxTempo.TabStop = false;
			this.groupBoxTempo.Text = "テンポ";
			this.comboBoxTempo.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTempo.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.comboBoxTempo.FormattingEnabled = true;
			this.comboBoxTempo.Items.AddRange(new object[] { "60", "90", "120", "150", "180" });
			this.comboBoxTempo.Location = new global::System.Drawing.Point(37, 21);
			this.comboBoxTempo.Name = "comboBoxTempo";
			this.comboBoxTempo.Size = new global::System.Drawing.Size(108, 26);
			this.comboBoxTempo.TabIndex = 0;
			this.comboBoxTempo.TabStop = false;
			this.groupBoxLink.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.groupBoxLink.Controls.Add(this.radioButtonLinkOn);
			this.groupBoxLink.Controls.Add(this.radioButtonLinkOff);
			this.groupBoxLink.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBoxLink.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.groupBoxLink.Location = new global::System.Drawing.Point(54, 83);
			this.groupBoxLink.Name = "groupBoxLink";
			this.groupBoxLink.Size = new global::System.Drawing.Size(178, 66);
			this.groupBoxLink.TabIndex = 21;
			this.groupBoxLink.TabStop = false;
			this.groupBoxLink.Text = "LEDリンク";
			this.radioButtonLinkOn.AutoSize = true;
			this.radioButtonLinkOn.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonLinkOn.Location = new global::System.Drawing.Point(13, 17);
			this.radioButtonLinkOn.Name = "radioButtonLinkOn";
			this.radioButtonLinkOn.Size = new global::System.Drawing.Size(50, 22);
			this.radioButtonLinkOn.TabIndex = 4;
			this.radioButtonLinkOn.Text = "する";
			this.radioButtonLinkOn.UseVisualStyleBackColor = true;
			this.radioButtonLinkOff.AutoSize = true;
			this.radioButtonLinkOff.ForeColor = global::System.Drawing.Color.Black;
			this.radioButtonLinkOff.Location = new global::System.Drawing.Point(13, 38);
			this.radioButtonLinkOff.Name = "radioButtonLinkOff";
			this.radioButtonLinkOff.Size = new global::System.Drawing.Size(62, 22);
			this.radioButtonLinkOff.TabIndex = 5;
			this.radioButtonLinkOff.Text = "しない";
			this.radioButtonLinkOff.UseVisualStyleBackColor = true;
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(30, 164);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 5;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(152, 164);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 6;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 261);
			base.Controls.Add(this.splitContainer1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MelodySettingsDialog";
			this.Text = "MelodySettingsDialog";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.MelodySettingsDialog_FormClosing);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.MelodySettingsDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			this.groupBoxTempo.ResumeLayout(false);
			this.groupBoxLink.ResumeLayout(false);
			this.groupBoxLink.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040003F2 RID: 1010
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040003F3 RID: 1011
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x040003F4 RID: 1012
		private global::System.Windows.Forms.PictureBox pictureBoxObi;

		// Token: 0x040003F5 RID: 1013
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x040003F6 RID: 1014
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x040003F7 RID: 1015
		private global::System.Windows.Forms.GroupBox groupBoxTempo;

		// Token: 0x040003F8 RID: 1016
		private global::System.Windows.Forms.ComboBox comboBoxTempo;

		// Token: 0x040003F9 RID: 1017
		private global::System.Windows.Forms.GroupBox groupBoxLink;

		// Token: 0x040003FA RID: 1018
		private global::System.Windows.Forms.RadioButton radioButtonLinkOn;

		// Token: 0x040003FB RID: 1019
		private global::System.Windows.Forms.RadioButton radioButtonLinkOff;
	}
}
