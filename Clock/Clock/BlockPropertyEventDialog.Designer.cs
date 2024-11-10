namespace Clock
{
	// Token: 0x02000008 RID: 8
	public partial class BlockPropertyEventDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600006C RID: 108 RVA: 0x000071E7 File Offset: 0x000053E7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00007208 File Offset: 0x00005408
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyEventDialog));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.comboBoxTriggerMessage = new global::System.Windows.Forms.ComboBox();
			this.comboBoxTriggerHardware = new global::System.Windows.Forms.ComboBox();
			this.comboBoxTrigger = new global::System.Windows.Forms.ComboBox();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
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
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxTriggerMessage);
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxTriggerHardware);
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxTrigger);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Size = new global::System.Drawing.Size(284, 157);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(178, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(106, 25);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.comboBoxTriggerMessage.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTriggerMessage.FormattingEnabled = true;
			this.comboBoxTriggerMessage.Location = new global::System.Drawing.Point(81, 60);
			this.comboBoxTriggerMessage.Name = "comboBoxTriggerMessage";
			this.comboBoxTriggerMessage.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxTriggerMessage.TabIndex = 11;
			this.comboBoxTriggerHardware.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTriggerHardware.FormattingEnabled = true;
			this.comboBoxTriggerHardware.Location = new global::System.Drawing.Point(81, 60);
			this.comboBoxTriggerHardware.Name = "comboBoxTriggerHardware";
			this.comboBoxTriggerHardware.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxTriggerHardware.TabIndex = 10;
			this.comboBoxTrigger.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTrigger.FormattingEnabled = true;
			this.comboBoxTrigger.Location = new global::System.Drawing.Point(81, 24);
			this.comboBoxTrigger.Name = "comboBoxTrigger";
			this.comboBoxTrigger.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxTrigger.TabIndex = 9;
			this.comboBoxTrigger.SelectedIndexChanged += new global::System.EventHandler(this.comboBoxTrigger_SelectedIndexChanged);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(152, 92);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 8;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(29, 92);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 7;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 157);
			base.Controls.Add(this.splitContainer1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyEventDialog";
			this.Text = "イベント設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyEventDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000050 RID: 80
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000053 RID: 83
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.ComboBox comboBoxTriggerHardware;

		// Token: 0x04000056 RID: 86
		private global::System.Windows.Forms.ComboBox comboBoxTrigger;

		// Token: 0x04000057 RID: 87
		private global::System.Windows.Forms.ComboBox comboBoxTriggerMessage;
	}
}
