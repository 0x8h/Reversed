namespace Clock
{
	// Token: 0x02000051 RID: 81
	public partial class SettingWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x060008A7 RID: 2215 RVA: 0x00063691 File Offset: 0x00061891
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x000636B0 File Offset: 0x000618B0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.SettingWindow));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.connectWarningLabel = new global::System.Windows.Forms.Label();
			this.groupBoxFirmware = new global::System.Windows.Forms.GroupBox();
			this.pictureBoxButtonUpdate = new global::System.Windows.Forms.PictureBox();
			this.groupBoxAlerm = new global::System.Windows.Forms.GroupBox();
			this.pictureBoxButtonAlerm = new global::System.Windows.Forms.PictureBox();
			this.alermMinute = new global::System.Windows.Forms.NumericUpDown();
			this.labelAlerm = new global::System.Windows.Forms.Label();
			this.alermHour = new global::System.Windows.Forms.NumericUpDown();
			this.groupBoxTime = new global::System.Windows.Forms.GroupBox();
			this.timeWarningLabel = new global::System.Windows.Forms.Label();
			this.systemTimeSecond = new global::System.Windows.Forms.Label();
			this.pictureBoxButtonTime = new global::System.Windows.Forms.PictureBox();
			this.systemTime = new global::System.Windows.Forms.Label();
			this.pictureBoxConnectIcon = new global::System.Windows.Forms.PictureBox();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			this.groupBoxFirmware.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonUpdate).BeginInit();
			this.groupBoxAlerm.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonAlerm).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.alermMinute).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.alermHour).BeginInit();
			this.groupBoxTime.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonTime).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxConnectIcon).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxObi);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer1.Panel2.Controls.Add(this.connectWarningLabel);
			this.splitContainer1.Panel2.Controls.Add(this.groupBoxFirmware);
			this.splitContainer1.Panel2.Controls.Add(this.groupBoxAlerm);
			this.splitContainer1.Panel2.Controls.Add(this.groupBoxTime);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxConnectIcon);
			this.splitContainer1.Size = new global::System.Drawing.Size(398, 443);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 1;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(292, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 25);
			this.pictureBoxObi.TabIndex = 2;
			this.pictureBoxObi.TabStop = false;
			this.connectWarningLabel.AutoSize = true;
			this.connectWarningLabel.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.connectWarningLabel.ForeColor = global::System.Drawing.Color.FromArgb(185, 11, 11);
			this.connectWarningLabel.Location = new global::System.Drawing.Point(65, 28);
			this.connectWarningLabel.Name = "connectWarningLabel";
			this.connectWarningLabel.Size = new global::System.Drawing.Size(44, 18);
			this.connectWarningLabel.TabIndex = 11;
			this.connectWarningLabel.Text = "通信中";
			this.groupBoxFirmware.Controls.Add(this.pictureBoxButtonUpdate);
			this.groupBoxFirmware.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBoxFirmware.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.groupBoxFirmware.Location = new global::System.Drawing.Point(16, 305);
			this.groupBoxFirmware.Name = "groupBoxFirmware";
			this.groupBoxFirmware.Size = new global::System.Drawing.Size(370, 95);
			this.groupBoxFirmware.TabIndex = 10;
			this.groupBoxFirmware.TabStop = false;
			this.groupBoxFirmware.Text = "◇ファームウェアの更新";
			this.pictureBoxButtonUpdate.Image = global::Clock.Properties.Resources.popup_btn_083;
			this.pictureBoxButtonUpdate.Location = new global::System.Drawing.Point(136, 35);
			this.pictureBoxButtonUpdate.Name = "pictureBoxButtonUpdate";
			this.pictureBoxButtonUpdate.Size = new global::System.Drawing.Size(102, 41);
			this.pictureBoxButtonUpdate.TabIndex = 11;
			this.pictureBoxButtonUpdate.TabStop = false;
			this.pictureBoxButtonUpdate.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonUpdate_MouseDown);
			this.pictureBoxButtonUpdate.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonUpdate_MouseEnter);
			this.pictureBoxButtonUpdate.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonUpdate_MouseLeave);
			this.pictureBoxButtonUpdate.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonUpdate_MouseUp);
			this.groupBoxAlerm.Controls.Add(this.pictureBoxButtonAlerm);
			this.groupBoxAlerm.Controls.Add(this.alermMinute);
			this.groupBoxAlerm.Controls.Add(this.labelAlerm);
			this.groupBoxAlerm.Controls.Add(this.alermHour);
			this.groupBoxAlerm.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBoxAlerm.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.groupBoxAlerm.Location = new global::System.Drawing.Point(16, 195);
			this.groupBoxAlerm.Name = "groupBoxAlerm";
			this.groupBoxAlerm.Size = new global::System.Drawing.Size(370, 95);
			this.groupBoxAlerm.TabIndex = 10;
			this.groupBoxAlerm.TabStop = false;
			this.groupBoxAlerm.Text = "◇アラーム時刻";
			this.pictureBoxButtonAlerm.Image = global::Clock.Properties.Resources.popup_btn_073;
			this.pictureBoxButtonAlerm.Location = new global::System.Drawing.Point(220, 35);
			this.pictureBoxButtonAlerm.Name = "pictureBoxButtonAlerm";
			this.pictureBoxButtonAlerm.Size = new global::System.Drawing.Size(102, 41);
			this.pictureBoxButtonAlerm.TabIndex = 10;
			this.pictureBoxButtonAlerm.TabStop = false;
			this.pictureBoxButtonAlerm.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonAlerm_MouseDown);
			this.pictureBoxButtonAlerm.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonAlerm_MouseEnter);
			this.pictureBoxButtonAlerm.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonAlerm_MouseLeave);
			this.pictureBoxButtonAlerm.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonAlerm_MouseUp);
			this.alermMinute.Enabled = false;
			this.alermMinute.Location = new global::System.Drawing.Point(101, 42);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.alermMinute;
			int[] array = new int[4];
			array[0] = 59;
			numericUpDown.Maximum = new decimal(array);
			this.alermMinute.Name = "alermMinute";
			this.alermMinute.Size = new global::System.Drawing.Size(42, 25);
			this.alermMinute.TabIndex = 9;
			this.labelAlerm.AutoSize = true;
			this.labelAlerm.Font = new global::System.Drawing.Font("メイリオ", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelAlerm.ForeColor = global::System.Drawing.Color.Black;
			this.labelAlerm.Location = new global::System.Drawing.Point(80, 42);
			this.labelAlerm.Name = "labelAlerm";
			this.labelAlerm.Size = new global::System.Drawing.Size(17, 24);
			this.labelAlerm.TabIndex = 8;
			this.labelAlerm.Text = ":";
			this.alermHour.Enabled = false;
			this.alermHour.Location = new global::System.Drawing.Point(36, 42);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.alermHour;
			int[] array2 = new int[4];
			array2[0] = 23;
			numericUpDown2.Maximum = new decimal(array2);
			this.alermHour.Name = "alermHour";
			this.alermHour.Size = new global::System.Drawing.Size(42, 25);
			this.alermHour.TabIndex = 7;
			this.groupBoxTime.Controls.Add(this.timeWarningLabel);
			this.groupBoxTime.Controls.Add(this.systemTimeSecond);
			this.groupBoxTime.Controls.Add(this.pictureBoxButtonTime);
			this.groupBoxTime.Controls.Add(this.systemTime);
			this.groupBoxTime.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBoxTime.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.groupBoxTime.Location = new global::System.Drawing.Point(17, 72);
			this.groupBoxTime.Name = "groupBoxTime";
			this.groupBoxTime.Size = new global::System.Drawing.Size(369, 109);
			this.groupBoxTime.TabIndex = 9;
			this.groupBoxTime.TabStop = false;
			this.groupBoxTime.Text = "◇このコンピュータの時刻を本体に設定";
			this.timeWarningLabel.AutoSize = true;
			this.timeWarningLabel.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.timeWarningLabel.ForeColor = global::System.Drawing.Color.FromArgb(97, 54, 26);
			this.timeWarningLabel.Location = new global::System.Drawing.Point(4, 83);
			this.timeWarningLabel.Name = "timeWarningLabel";
			this.timeWarningLabel.Size = new global::System.Drawing.Size(315, 18);
			this.timeWarningLabel.TabIndex = 12;
			this.timeWarningLabel.Text = "※秒数が0秒のタイミングで設定ボタンを押してください";
			this.systemTimeSecond.AutoSize = true;
			this.systemTimeSecond.Font = new global::System.Drawing.Font("メイリオ", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.systemTimeSecond.ForeColor = global::System.Drawing.Color.DarkGray;
			this.systemTimeSecond.Location = new global::System.Drawing.Point(104, 38);
			this.systemTimeSecond.Name = "systemTimeSecond";
			this.systemTimeSecond.Size = new global::System.Drawing.Size(55, 36);
			this.systemTimeSecond.TabIndex = 3;
			this.systemTimeSecond.Text = ":00";
			this.pictureBoxButtonTime.Image = global::Clock.Properties.Resources.popup_btn_073;
			this.pictureBoxButtonTime.Location = new global::System.Drawing.Point(220, 34);
			this.pictureBoxButtonTime.Name = "pictureBoxButtonTime";
			this.pictureBoxButtonTime.Size = new global::System.Drawing.Size(102, 40);
			this.pictureBoxButtonTime.TabIndex = 2;
			this.pictureBoxButtonTime.TabStop = false;
			this.pictureBoxButtonTime.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonTime_MouseDown);
			this.pictureBoxButtonTime.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonTime_MouseEnter);
			this.pictureBoxButtonTime.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonTime_MouseLeave);
			this.pictureBoxButtonTime.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonTime_MouseUp);
			this.systemTime.AutoSize = true;
			this.systemTime.Font = new global::System.Drawing.Font("メイリオ", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.systemTime.ForeColor = global::System.Drawing.Color.Black;
			this.systemTime.Location = new global::System.Drawing.Point(29, 38);
			this.systemTime.Name = "systemTime";
			this.systemTime.Size = new global::System.Drawing.Size(85, 36);
			this.systemTime.TabIndex = 1;
			this.systemTime.Text = "00:00";
			this.pictureBoxConnectIcon.Image = global::Clock.Properties.Resources.popup_usb_off;
			this.pictureBoxConnectIcon.Location = new global::System.Drawing.Point(27, 18);
			this.pictureBoxConnectIcon.Name = "pictureBoxConnectIcon";
			this.pictureBoxConnectIcon.Size = new global::System.Drawing.Size(32, 35);
			this.pictureBoxConnectIcon.TabIndex = 0;
			this.pictureBoxConnectIcon.TabStop = false;
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(398, 443);
			base.Controls.Add(this.splitContainer1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "SettingWindow";
			this.Text = "設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.SettingWindow_FormClosed);
			base.Shown += new global::System.EventHandler(this.SettingWindow_Shown);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			this.groupBoxFirmware.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonUpdate).EndInit();
			this.groupBoxAlerm.ResumeLayout(false);
			this.groupBoxAlerm.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonAlerm).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.alermMinute).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.alermHour).EndInit();
			this.groupBoxTime.ResumeLayout(false);
			this.groupBoxTime.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonTime).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxConnectIcon).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400064F RID: 1615
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000650 RID: 1616
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000651 RID: 1617
		private global::System.Windows.Forms.PictureBox pictureBoxObi;

		// Token: 0x04000652 RID: 1618
		private global::System.Windows.Forms.PictureBox pictureBoxConnectIcon;

		// Token: 0x04000653 RID: 1619
		private global::System.Windows.Forms.Label systemTime;

		// Token: 0x04000654 RID: 1620
		private global::System.Windows.Forms.GroupBox groupBoxTime;

		// Token: 0x04000655 RID: 1621
		private global::System.Windows.Forms.NumericUpDown alermHour;

		// Token: 0x04000656 RID: 1622
		private global::System.Windows.Forms.GroupBox groupBoxAlerm;

		// Token: 0x04000657 RID: 1623
		private global::System.Windows.Forms.NumericUpDown alermMinute;

		// Token: 0x04000658 RID: 1624
		private global::System.Windows.Forms.Label labelAlerm;

		// Token: 0x04000659 RID: 1625
		private global::System.Windows.Forms.GroupBox groupBoxFirmware;

		// Token: 0x0400065A RID: 1626
		private global::System.Windows.Forms.Label connectWarningLabel;

		// Token: 0x0400065B RID: 1627
		private global::System.Windows.Forms.PictureBox pictureBoxButtonTime;

		// Token: 0x0400065C RID: 1628
		private global::System.Windows.Forms.PictureBox pictureBoxButtonUpdate;

		// Token: 0x0400065D RID: 1629
		private global::System.Windows.Forms.PictureBox pictureBoxButtonAlerm;

		// Token: 0x0400065E RID: 1630
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x0400065F RID: 1631
		private global::System.Windows.Forms.Label systemTimeSecond;

		// Token: 0x04000660 RID: 1632
		private global::System.Windows.Forms.Label timeWarningLabel;
	}
}
