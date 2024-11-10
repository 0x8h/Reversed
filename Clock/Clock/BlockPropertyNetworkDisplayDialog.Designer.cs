namespace Clock
{
	// Token: 0x0200000F RID: 15
	public partial class BlockPropertyNetworkDisplayDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x06000102 RID: 258 RVA: 0x00010220 File Offset: 0x0000E420
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00010240 File Offset: 0x0000E440
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyNetworkDisplayDialog));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.textBoxConst = new global::System.Windows.Forms.TextBox();
			this.comboBoxVariable = new global::System.Windows.Forms.ComboBox();
			this.radioButtonVariable = new global::System.Windows.Forms.RadioButton();
			this.radioButtonConst = new global::System.Windows.Forms.RadioButton();
			this.radioButtonOff = new global::System.Windows.Forms.RadioButton();
			this.radioButtonOn = new global::System.Windows.Forms.RadioButton();
			this.comboBoxObject = new global::System.Windows.Forms.ComboBox();
			this.comboBoxObjectType = new global::System.Windows.Forms.ComboBox();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.groupBox1.SuspendLayout();
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
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonOff);
			this.splitContainer1.Panel2.Controls.Add(this.radioButtonOn);
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxObject);
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxObjectType);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Size = new global::System.Drawing.Size(284, 304);
			this.splitContainer1.SplitterDistance = 29;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(178, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(106, 29);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.groupBox1.Controls.Add(this.textBoxConst);
			this.groupBox1.Controls.Add(this.comboBoxVariable);
			this.groupBox1.Controls.Add(this.radioButtonVariable);
			this.groupBox1.Controls.Add(this.radioButtonConst);
			this.groupBox1.Location = new global::System.Drawing.Point(43, 126);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(194, 84);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.textBoxConst.Location = new global::System.Drawing.Point(51, 18);
			this.textBoxConst.Name = "textBoxConst";
			this.textBoxConst.Size = new global::System.Drawing.Size(121, 19);
			this.textBoxConst.TabIndex = 22;
			this.comboBoxVariable.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxVariable.FormattingEnabled = true;
			this.comboBoxVariable.Location = new global::System.Drawing.Point(51, 48);
			this.comboBoxVariable.Name = "comboBoxVariable";
			this.comboBoxVariable.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxVariable.TabIndex = 20;
			this.radioButtonVariable.AutoSize = true;
			this.radioButtonVariable.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonVariable.Location = new global::System.Drawing.Point(25, 52);
			this.radioButtonVariable.Name = "radioButtonVariable";
			this.radioButtonVariable.Size = new global::System.Drawing.Size(14, 13);
			this.radioButtonVariable.TabIndex = 21;
			this.radioButtonVariable.TabStop = true;
			this.radioButtonVariable.UseVisualStyleBackColor = true;
			this.radioButtonVariable.CheckedChanged += new global::System.EventHandler(this.radioButtonVariable_CheckedChanged);
			this.radioButtonConst.AutoSize = true;
			this.radioButtonConst.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonConst.Location = new global::System.Drawing.Point(25, 20);
			this.radioButtonConst.Name = "radioButtonConst";
			this.radioButtonConst.Size = new global::System.Drawing.Size(14, 13);
			this.radioButtonConst.TabIndex = 20;
			this.radioButtonConst.TabStop = true;
			this.radioButtonConst.UseVisualStyleBackColor = true;
			this.radioButtonConst.CheckedChanged += new global::System.EventHandler(this.radioButtonConst_CheckedChanged);
			this.radioButtonOff.AutoSize = true;
			this.radioButtonOff.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonOff.Location = new global::System.Drawing.Point(165, 98);
			this.radioButtonOff.Name = "radioButtonOff";
			this.radioButtonOff.Size = new global::System.Drawing.Size(50, 22);
			this.radioButtonOff.TabIndex = 18;
			this.radioButtonOff.TabStop = true;
			this.radioButtonOff.Text = "消す";
			this.radioButtonOff.UseVisualStyleBackColor = true;
			this.radioButtonOff.CheckedChanged += new global::System.EventHandler(this.radioButtonOff_CheckedChanged);
			this.radioButtonOn.AutoSize = true;
			this.radioButtonOn.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonOn.Location = new global::System.Drawing.Point(65, 98);
			this.radioButtonOn.Name = "radioButtonOn";
			this.radioButtonOn.Size = new global::System.Drawing.Size(74, 22);
			this.radioButtonOn.TabIndex = 17;
			this.radioButtonOn.TabStop = true;
			this.radioButtonOn.Text = "表示する";
			this.radioButtonOn.UseVisualStyleBackColor = true;
			this.radioButtonOn.CheckedChanged += new global::System.EventHandler(this.radioButtonOn_CheckedChanged);
			this.comboBoxObject.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxObject.FormattingEnabled = true;
			this.comboBoxObject.Location = new global::System.Drawing.Point(84, 54);
			this.comboBoxObject.Name = "comboBoxObject";
			this.comboBoxObject.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxObject.TabIndex = 9;
			this.comboBoxObjectType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxObjectType.FormattingEnabled = true;
			this.comboBoxObjectType.Location = new global::System.Drawing.Point(84, 18);
			this.comboBoxObjectType.Name = "comboBoxObjectType";
			this.comboBoxObjectType.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxObjectType.TabIndex = 8;
			this.comboBoxObjectType.SelectedValueChanged += new global::System.EventHandler(this.comboBoxObjectType_SelectedValueChanged);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(152, 231);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 6;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(29, 231);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 5;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 304);
			base.Controls.Add(this.splitContainer1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyNetworkDisplayDialog";
			this.Text = "表示設定";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.BlockPropertyNetworkDisplayDialog_FormClosing);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyNetworkDisplayDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000114 RID: 276
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000115 RID: 277
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000116 RID: 278
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x04000117 RID: 279
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x04000118 RID: 280
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000119 RID: 281
		private global::System.Windows.Forms.ComboBox comboBoxObject;

		// Token: 0x0400011A RID: 282
		private global::System.Windows.Forms.ComboBox comboBoxObjectType;

		// Token: 0x0400011B RID: 283
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400011C RID: 284
		private global::System.Windows.Forms.ComboBox comboBoxVariable;

		// Token: 0x0400011D RID: 285
		private global::System.Windows.Forms.RadioButton radioButtonVariable;

		// Token: 0x0400011E RID: 286
		private global::System.Windows.Forms.RadioButton radioButtonConst;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.RadioButton radioButtonOff;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.RadioButton radioButtonOn;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.TextBox textBoxConst;
	}
}
