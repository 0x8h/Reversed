namespace Clock
{
	// Token: 0x02000003 RID: 3
	public partial class BlockPropertyArithmeticDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002704 File Offset: 0x00000904
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002724 File Offset: 0x00000924
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyArithmeticDialog));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.radioButtonTemperature = new global::System.Windows.Forms.RadioButton();
			this.labelPreview = new global::System.Windows.Forms.Label();
			this.numericUpDownRight = new global::System.Windows.Forms.NumericUpDown();
			this.comboBoxRight = new global::System.Windows.Forms.ComboBox();
			this.radioButtonValuable = new global::System.Windows.Forms.RadioButton();
			this.radioButtonConst = new global::System.Windows.Forms.RadioButton();
			this.comboBoxLeft = new global::System.Windows.Forms.ComboBox();
			this.comboBoxOperator = new global::System.Windows.Forms.ComboBox();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.radioButtonLight = new global::System.Windows.Forms.RadioButton();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownRight).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
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
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Size = new global::System.Drawing.Size(432, 271);
			this.splitContainer1.SplitterDistance = 28;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(326, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(106, 28);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.groupBox1.Controls.Add(this.radioButtonLight);
			this.groupBox1.Controls.Add(this.radioButtonTemperature);
			this.groupBox1.Controls.Add(this.labelPreview);
			this.groupBox1.Controls.Add(this.numericUpDownRight);
			this.groupBox1.Controls.Add(this.comboBoxRight);
			this.groupBox1.Controls.Add(this.radioButtonValuable);
			this.groupBox1.Controls.Add(this.radioButtonConst);
			this.groupBox1.Controls.Add(this.comboBoxLeft);
			this.groupBox1.Controls.Add(this.comboBoxOperator);
			this.groupBox1.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.groupBox1.Location = new global::System.Drawing.Point(26, 14);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(378, 168);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.radioButtonTemperature.AutoSize = true;
			this.radioButtonTemperature.Location = new global::System.Drawing.Point(235, 107);
			this.radioButtonTemperature.Name = "radioButtonTemperature";
			this.radioButtonTemperature.Size = new global::System.Drawing.Size(50, 22);
			this.radioButtonTemperature.TabIndex = 12;
			this.radioButtonTemperature.TabStop = true;
			this.radioButtonTemperature.Text = "温度";
			this.radioButtonTemperature.UseVisualStyleBackColor = true;
			this.radioButtonTemperature.CheckedChanged += new global::System.EventHandler(this.radioButtonTemperature_CheckedChanged);
			this.labelPreview.Location = new global::System.Drawing.Point(85, 21);
			this.labelPreview.Name = "labelPreview";
			this.labelPreview.Size = new global::System.Drawing.Size(200, 18);
			this.labelPreview.TabIndex = 11;
			this.labelPreview.Text = "label1";
			this.labelPreview.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.numericUpDownRight.Location = new global::System.Drawing.Point(289, 43);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDownRight;
			int[] array = new int[4];
			array[0] = 127;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDownRight.Minimum = new decimal(new int[] { 128, 0, 0, int.MinValue });
			this.numericUpDownRight.Name = "numericUpDownRight";
			this.numericUpDownRight.Size = new global::System.Drawing.Size(69, 25);
			this.numericUpDownRight.TabIndex = 10;
			this.comboBoxRight.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxRight.FormattingEnabled = true;
			this.comboBoxRight.Location = new global::System.Drawing.Point(258, 75);
			this.comboBoxRight.Name = "comboBoxRight";
			this.comboBoxRight.Size = new global::System.Drawing.Size(95, 26);
			this.comboBoxRight.TabIndex = 9;
			this.radioButtonValuable.AutoSize = true;
			this.radioButtonValuable.Location = new global::System.Drawing.Point(235, 80);
			this.radioButtonValuable.Name = "radioButtonValuable";
			this.radioButtonValuable.Size = new global::System.Drawing.Size(14, 13);
			this.radioButtonValuable.TabIndex = 8;
			this.radioButtonValuable.TabStop = true;
			this.radioButtonValuable.UseVisualStyleBackColor = true;
			this.radioButtonValuable.CheckedChanged += new global::System.EventHandler(this.radioButtonValuable_CheckedChanged);
			this.radioButtonConst.AutoSize = true;
			this.radioButtonConst.Location = new global::System.Drawing.Point(235, 46);
			this.radioButtonConst.Name = "radioButtonConst";
			this.radioButtonConst.Size = new global::System.Drawing.Size(50, 22);
			this.radioButtonConst.TabIndex = 7;
			this.radioButtonConst.TabStop = true;
			this.radioButtonConst.Text = "定数";
			this.radioButtonConst.UseVisualStyleBackColor = true;
			this.radioButtonConst.CheckedChanged += new global::System.EventHandler(this.radioButtonConst_CheckedChanged);
			this.comboBoxLeft.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLeft.FormattingEnabled = true;
			this.comboBoxLeft.Location = new global::System.Drawing.Point(14, 73);
			this.comboBoxLeft.Name = "comboBoxLeft";
			this.comboBoxLeft.Size = new global::System.Drawing.Size(121, 26);
			this.comboBoxLeft.TabIndex = 5;
			this.comboBoxOperator.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxOperator.FormattingEnabled = true;
			this.comboBoxOperator.Location = new global::System.Drawing.Point(151, 73);
			this.comboBoxOperator.Name = "comboBoxOperator";
			this.comboBoxOperator.Size = new global::System.Drawing.Size(67, 26);
			this.comboBoxOperator.TabIndex = 6;
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(86, 201);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 3;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(241, 201);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 4;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.radioButtonLight.AutoSize = true;
			this.radioButtonLight.Location = new global::System.Drawing.Point(235, 135);
			this.radioButtonLight.Name = "radioButtonLight";
			this.radioButtonLight.Size = new global::System.Drawing.Size(62, 22);
			this.radioButtonLight.TabIndex = 13;
			this.radioButtonLight.TabStop = true;
			this.radioButtonLight.Text = "明るさ";
			this.radioButtonLight.UseVisualStyleBackColor = true;
			this.radioButtonLight.CheckedChanged += new global::System.EventHandler(this.radioButtonLight_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(432, 271);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyArithmeticDialog";
			this.Text = "演算設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyArithmeticDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownRight).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000005 RID: 5
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.NumericUpDown numericUpDownRight;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.ComboBox comboBoxRight;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.RadioButton radioButtonValuable;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.RadioButton radioButtonConst;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.ComboBox comboBoxLeft;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.ComboBox comboBoxOperator;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Label labelPreview;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.RadioButton radioButtonTemperature;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.RadioButton radioButtonLight;
	}
}
