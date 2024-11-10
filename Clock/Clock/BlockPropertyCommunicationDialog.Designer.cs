namespace Clock
{
	// Token: 0x02000004 RID: 4
	public partial class BlockPropertyCommunicationDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002A RID: 42 RVA: 0x0000376B File Offset: 0x0000196B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000378C File Offset: 0x0000198C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyCommunicationDialog));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.radioButtonSend = new global::System.Windows.Forms.RadioButton();
			this.radioButtonReceive = new global::System.Windows.Forms.RadioButton();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.labelDestination = new global::System.Windows.Forms.Label();
			this.labelSource = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.labelCommunication = new global::System.Windows.Forms.Label();
			this.comboBoxDestination = new global::System.Windows.Forms.ComboBox();
			this.comboBoxSource = new global::System.Windows.Forms.ComboBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			this.groupBox1.SuspendLayout();
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
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonReceive);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonSend);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Size = new global::System.Drawing.Size(384, 278);
			this.splitContainer1.SplitterDistance = 41;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(278, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(106, 41);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(217, 196);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 8;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(76, 196);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 7;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			this.radioButtonSend.AutoSize = true;
			this.radioButtonSend.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonSend.Location = new global::System.Drawing.Point(103, 19);
			this.radioButtonSend.Name = "radioButtonSend";
			this.radioButtonSend.Size = new global::System.Drawing.Size(74, 22);
			this.radioButtonSend.TabIndex = 9;
			this.radioButtonSend.TabStop = true;
			this.radioButtonSend.Text = "送信する";
			this.radioButtonSend.UseVisualStyleBackColor = true;
			this.radioButtonSend.CheckedChanged += new global::System.EventHandler(this.radioButtonSend_CheckedChanged);
			this.radioButtonReceive.AutoSize = true;
			this.radioButtonReceive.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonReceive.Location = new global::System.Drawing.Point(217, 19);
			this.radioButtonReceive.Name = "radioButtonReceive";
			this.radioButtonReceive.Size = new global::System.Drawing.Size(74, 22);
			this.radioButtonReceive.TabIndex = 10;
			this.radioButtonReceive.TabStop = true;
			this.radioButtonReceive.Text = "受信する";
			this.radioButtonReceive.UseVisualStyleBackColor = true;
			this.radioButtonReceive.CheckedChanged += new global::System.EventHandler(this.radioButtonReceive_CheckedChanged);
			this.groupBox1.Controls.Add(this.comboBoxSource);
			this.groupBox1.Controls.Add(this.comboBoxDestination);
			this.groupBox1.Controls.Add(this.labelCommunication);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.labelSource);
			this.groupBox1.Controls.Add(this.labelDestination);
			this.groupBox1.Location = new global::System.Drawing.Point(38, 49);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(298, 130);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.labelDestination.AutoSize = true;
			this.labelDestination.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelDestination.Location = new global::System.Drawing.Point(7, 33);
			this.labelDestination.Name = "labelDestination";
			this.labelDestination.Size = new global::System.Drawing.Size(68, 18);
			this.labelDestination.TabIndex = 0;
			this.labelDestination.Text = "サーバーの";
			this.labelSource.AutoSize = true;
			this.labelSource.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelSource.Location = new global::System.Drawing.Point(156, 33);
			this.labelSource.Name = "labelSource";
			this.labelSource.Size = new global::System.Drawing.Size(68, 18);
			this.labelSource.TabIndex = 1;
			this.labelSource.Text = "サーバーの";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label3.Location = new global::System.Drawing.Point(137, 54);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(20, 18);
			this.label3.TabIndex = 2;
			this.label3.Text = "に";
			this.labelCommunication.AutoSize = true;
			this.labelCommunication.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelCommunication.Location = new global::System.Drawing.Point(212, 86);
			this.labelCommunication.Name = "labelCommunication";
			this.labelCommunication.Size = new global::System.Drawing.Size(68, 18);
			this.labelCommunication.TabIndex = 3;
			this.labelCommunication.Text = "を送信する";
			this.comboBoxDestination.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDestination.FormattingEnabled = true;
			this.comboBoxDestination.Location = new global::System.Drawing.Point(10, 54);
			this.comboBoxDestination.Name = "comboBoxDestination";
			this.comboBoxDestination.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxDestination.TabIndex = 4;
			this.comboBoxSource.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSource.FormattingEnabled = true;
			this.comboBoxSource.Location = new global::System.Drawing.Point(159, 54);
			this.comboBoxSource.Name = "comboBoxSource";
			this.comboBoxSource.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxSource.TabIndex = 5;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(384, 278);
			base.Controls.Add(this.splitContainer1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyCommunicationDialog";
			this.Text = "送受信設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyCommunicationDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000016 RID: 22
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.RadioButton radioButtonReceive;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.RadioButton radioButtonSend;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Label labelCommunication;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Label labelSource;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Label labelDestination;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.ComboBox comboBoxSource;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.ComboBox comboBoxDestination;
	}
}
