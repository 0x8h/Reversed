namespace Clock
{
	// Token: 0x02000011 RID: 17
	public partial class BlockPropertyNetworkLoopEndDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x06000139 RID: 313 RVA: 0x00014B73 File Offset: 0x00012D73
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00014B94 File Offset: 0x00012D94
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyNetworkLoopEndDialog));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.radioButtonDisable = new global::System.Windows.Forms.RadioButton();
			this.radioButtonEnable = new global::System.Windows.Forms.RadioButton();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.comboBoxCondition = new global::System.Windows.Forms.ComboBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
			this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonDisable);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonEnable);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxCondition);
			this.splitContainer1.Size = new global::System.Drawing.Size(440, 290);
			this.splitContainer1.SplitterDistance = 28;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(334, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(106, 28);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.radioButtonDisable.AutoSize = true;
			this.radioButtonDisable.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonDisable.Location = new global::System.Drawing.Point(243, 11);
			this.radioButtonDisable.Name = "radioButtonDisable";
			this.radioButtonDisable.Size = new global::System.Drawing.Size(50, 22);
			this.radioButtonDisable.TabIndex = 14;
			this.radioButtonDisable.TabStop = true;
			this.radioButtonDisable.Text = "なし";
			this.radioButtonDisable.UseVisualStyleBackColor = true;
			this.radioButtonDisable.CheckedChanged += new global::System.EventHandler(this.radioButtonDisable_CheckedChanged);
			this.radioButtonEnable.AutoSize = true;
			this.radioButtonEnable.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonEnable.Location = new global::System.Drawing.Point(159, 11);
			this.radioButtonEnable.Name = "radioButtonEnable";
			this.radioButtonEnable.Size = new global::System.Drawing.Size(50, 22);
			this.radioButtonEnable.TabIndex = 13;
			this.radioButtonEnable.TabStop = true;
			this.radioButtonEnable.Text = "あり";
			this.radioButtonEnable.UseVisualStyleBackColor = true;
			this.radioButtonEnable.CheckedChanged += new global::System.EventHandler(this.radioButtonEnable_CheckedChanged);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(253, 219);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 6;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label1.Location = new global::System.Drawing.Point(54, 13);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(68, 18);
			this.label1.TabIndex = 12;
			this.label1.Text = "終了条件が";
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(77, 219);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 5;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			this.comboBoxCondition.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCondition.FormattingEnabled = true;
			this.comboBoxCondition.Location = new global::System.Drawing.Point(159, 39);
			this.comboBoxCondition.Name = "comboBoxCondition";
			this.comboBoxCondition.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxCondition.TabIndex = 11;
			this.comboBoxCondition.SelectedValueChanged += new global::System.EventHandler(this.comboBoxCondition_SelectedValueChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(440, 290);
			base.Controls.Add(this.splitContainer1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyNetworkLoopEndDialog";
			this.Text = "ループ終了設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyNetworkLoopEndDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000187 RID: 391
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000188 RID: 392
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000189 RID: 393
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x0400018A RID: 394
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x0400018B RID: 395
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400018C RID: 396
		private global::System.Windows.Forms.RadioButton radioButtonDisable;

		// Token: 0x0400018D RID: 397
		private global::System.Windows.Forms.RadioButton radioButtonEnable;

		// Token: 0x0400018E RID: 398
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400018F RID: 399
		private global::System.Windows.Forms.ComboBox comboBoxCondition;
	}
}
