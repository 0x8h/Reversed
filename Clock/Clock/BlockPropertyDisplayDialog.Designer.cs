namespace Clock
{
	// Token: 0x02000007 RID: 7
	public partial class BlockPropertyDisplayDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600005E RID: 94 RVA: 0x0000669D File Offset: 0x0000489D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000066BC File Offset: 0x000048BC
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyDisplayDialog));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.comboBoxVariable = new global::System.Windows.Forms.ComboBox();
			this.comboBoxMode = new global::System.Windows.Forms.ComboBox();
			this.radioButtonDisable = new global::System.Windows.Forms.RadioButton();
			this.radioButtonEnable = new global::System.Windows.Forms.RadioButton();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
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
			this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxVariable);
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxMode);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonDisable);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonEnable);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Size = new global::System.Drawing.Size(378, 222);
			this.splitContainer1.SplitterDistance = 24;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(272, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 24);
			this.pictureBoxObi.TabIndex = 0;
			this.pictureBoxObi.TabStop = false;
			this.comboBoxVariable.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxVariable.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.comboBoxVariable.FormattingEnabled = true;
			this.comboBoxVariable.Location = new global::System.Drawing.Point(205, 113);
			this.comboBoxVariable.Name = "comboBoxVariable";
			this.comboBoxVariable.Size = new global::System.Drawing.Size(89, 26);
			this.comboBoxVariable.TabIndex = 5;
			this.comboBoxMode.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMode.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.comboBoxMode.FormattingEnabled = true;
			this.comboBoxMode.Location = new global::System.Drawing.Point(85, 71);
			this.comboBoxMode.Name = "comboBoxMode";
			this.comboBoxMode.Size = new global::System.Drawing.Size(207, 26);
			this.comboBoxMode.TabIndex = 4;
			this.comboBoxMode.SelectedIndexChanged += new global::System.EventHandler(this.comboBoxMode_SelectedIndexChanged);
			this.radioButtonDisable.AutoSize = true;
			this.radioButtonDisable.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonDisable.Location = new global::System.Drawing.Point(217, 34);
			this.radioButtonDisable.Name = "radioButtonDisable";
			this.radioButtonDisable.Size = new global::System.Drawing.Size(50, 22);
			this.radioButtonDisable.TabIndex = 3;
			this.radioButtonDisable.TabStop = true;
			this.radioButtonDisable.Text = "消す";
			this.radioButtonDisable.UseVisualStyleBackColor = true;
			this.radioButtonDisable.CheckedChanged += new global::System.EventHandler(this.radioButtonDisable_CheckedChanged);
			this.radioButtonEnable.AutoSize = true;
			this.radioButtonEnable.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonEnable.Location = new global::System.Drawing.Point(75, 34);
			this.radioButtonEnable.Name = "radioButtonEnable";
			this.radioButtonEnable.Size = new global::System.Drawing.Size(74, 22);
			this.radioButtonEnable.TabIndex = 2;
			this.radioButtonEnable.TabStop = true;
			this.radioButtonEnable.Text = "表示する";
			this.radioButtonEnable.UseVisualStyleBackColor = true;
			this.radioButtonEnable.CheckedChanged += new global::System.EventHandler(this.radioButtonEnable_CheckedChanged);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(205, 158);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 1;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(66, 158);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 0;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(378, 222);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyDisplayDialog";
			this.Text = "表示設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyDisplayDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000046 RID: 70
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.PictureBox pictureBoxObi;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.ComboBox comboBoxVariable;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.ComboBox comboBoxMode;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.RadioButton radioButtonDisable;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.RadioButton radioButtonEnable;
	}
}
