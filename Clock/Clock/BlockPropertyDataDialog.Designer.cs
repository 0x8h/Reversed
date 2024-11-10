namespace Clock
{
	// Token: 0x02000006 RID: 6
	public partial class BlockPropertyDataDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600004E RID: 78 RVA: 0x000055AF File Offset: 0x000037AF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000055D0 File Offset: 0x000037D0
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyDataDialog));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.textBoxConst = new global::System.Windows.Forms.TextBox();
			this.numericUpDownConst = new global::System.Windows.Forms.NumericUpDown();
			this.radioButtonLight = new global::System.Windows.Forms.RadioButton();
			this.radioButtonTemperature = new global::System.Windows.Forms.RadioButton();
			this.radioButtonVariable = new global::System.Windows.Forms.RadioButton();
			this.radioButtonConst = new global::System.Windows.Forms.RadioButton();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.comboBoxDirect = new global::System.Windows.Forms.ComboBox();
			this.comboBoxOperate = new global::System.Windows.Forms.ComboBox();
			this.comboBoxRight = new global::System.Windows.Forms.ComboBox();
			this.comboBoxLeft = new global::System.Windows.Forms.ComboBox();
			this.comboBoxKind = new global::System.Windows.Forms.ComboBox();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.labelPreview = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownConst).BeginInit();
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
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxKind);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Panel2.Controls.Add(this.labelPreview);
			this.splitContainer1.Size = new global::System.Drawing.Size(550, 285);
			this.splitContainer1.SplitterDistance = 27;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(444, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(106, 27);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.groupBox1.Controls.Add(this.textBoxConst);
			this.groupBox1.Controls.Add(this.numericUpDownConst);
			this.groupBox1.Controls.Add(this.radioButtonLight);
			this.groupBox1.Controls.Add(this.radioButtonTemperature);
			this.groupBox1.Controls.Add(this.radioButtonVariable);
			this.groupBox1.Controls.Add(this.radioButtonConst);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboBoxDirect);
			this.groupBox1.Controls.Add(this.comboBoxOperate);
			this.groupBox1.Controls.Add(this.comboBoxRight);
			this.groupBox1.Controls.Add(this.comboBoxLeft);
			this.groupBox1.Location = new global::System.Drawing.Point(61, 70);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(459, 126);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.textBoxConst.Location = new global::System.Drawing.Point(284, 16);
			this.textBoxConst.Name = "textBoxConst";
			this.textBoxConst.Size = new global::System.Drawing.Size(100, 19);
			this.textBoxConst.TabIndex = 21;
			this.numericUpDownConst.Location = new global::System.Drawing.Point(283, 16);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDownConst;
			int[] array = new int[4];
			array[0] = 32767;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDownConst.Minimum = new decimal(new int[] { 32768, 0, 0, int.MinValue });
			this.numericUpDownConst.Name = "numericUpDownConst";
			this.numericUpDownConst.Size = new global::System.Drawing.Size(65, 19);
			this.numericUpDownConst.TabIndex = 20;
			this.radioButtonLight.AutoSize = true;
			this.radioButtonLight.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonLight.Location = new global::System.Drawing.Point(264, 90);
			this.radioButtonLight.Name = "radioButtonLight";
			this.radioButtonLight.Size = new global::System.Drawing.Size(62, 22);
			this.radioButtonLight.TabIndex = 19;
			this.radioButtonLight.TabStop = true;
			this.radioButtonLight.Text = "明るさ";
			this.radioButtonLight.UseVisualStyleBackColor = true;
			this.radioButtonLight.CheckedChanged += new global::System.EventHandler(this.radioButtonLight_CheckedChanged);
			this.radioButtonTemperature.AutoSize = true;
			this.radioButtonTemperature.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonTemperature.Location = new global::System.Drawing.Point(264, 65);
			this.radioButtonTemperature.Name = "radioButtonTemperature";
			this.radioButtonTemperature.Size = new global::System.Drawing.Size(50, 22);
			this.radioButtonTemperature.TabIndex = 18;
			this.radioButtonTemperature.TabStop = true;
			this.radioButtonTemperature.Text = "温度";
			this.radioButtonTemperature.UseVisualStyleBackColor = true;
			this.radioButtonTemperature.CheckedChanged += new global::System.EventHandler(this.radioButtonTemperature_CheckedChanged);
			this.radioButtonVariable.AutoSize = true;
			this.radioButtonVariable.BackColor = global::System.Drawing.Color.Transparent;
			this.radioButtonVariable.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonVariable.Location = new global::System.Drawing.Point(264, 45);
			this.radioButtonVariable.Name = "radioButtonVariable";
			this.radioButtonVariable.Size = new global::System.Drawing.Size(14, 13);
			this.radioButtonVariable.TabIndex = 17;
			this.radioButtonVariable.TabStop = true;
			this.radioButtonVariable.UseVisualStyleBackColor = false;
			this.radioButtonVariable.CheckedChanged += new global::System.EventHandler(this.radioButtonVariable_CheckedChanged);
			this.radioButtonConst.AutoSize = true;
			this.radioButtonConst.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.radioButtonConst.Location = new global::System.Drawing.Point(264, 15);
			this.radioButtonConst.Name = "radioButtonConst";
			this.radioButtonConst.Size = new global::System.Drawing.Size(50, 22);
			this.radioButtonConst.TabIndex = 16;
			this.radioButtonConst.TabStop = true;
			this.radioButtonConst.Text = "定数";
			this.radioButtonConst.UseVisualStyleBackColor = true;
			this.radioButtonConst.CheckedChanged += new global::System.EventHandler(this.radioButtonConst_CheckedChanged);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label2.Location = new global::System.Drawing.Point(394, 60);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(44, 18);
			this.label2.TabIndex = 14;
			this.label2.Text = "にする";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label1.Location = new global::System.Drawing.Point(156, 55);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(20, 18);
			this.label1.TabIndex = 13;
			this.label1.Text = "を";
			this.comboBoxDirect.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDirect.FormattingEnabled = true;
			this.comboBoxDirect.Items.AddRange(new object[] { "前に", "後に" });
			this.comboBoxDirect.Location = new global::System.Drawing.Point(182, 53);
			this.comboBoxDirect.Name = "comboBoxDirect";
			this.comboBoxDirect.Size = new global::System.Drawing.Size(52, 20);
			this.comboBoxDirect.TabIndex = 12;
			this.comboBoxOperate.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxOperate.FormattingEnabled = true;
			this.comboBoxOperate.Location = new global::System.Drawing.Point(182, 53);
			this.comboBoxOperate.Name = "comboBoxOperate";
			this.comboBoxOperate.Size = new global::System.Drawing.Size(52, 20);
			this.comboBoxOperate.TabIndex = 11;
			this.comboBoxRight.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxRight.FormattingEnabled = true;
			this.comboBoxRight.Location = new global::System.Drawing.Point(284, 43);
			this.comboBoxRight.Name = "comboBoxRight";
			this.comboBoxRight.Size = new global::System.Drawing.Size(84, 20);
			this.comboBoxRight.TabIndex = 10;
			this.comboBoxLeft.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLeft.FormattingEnabled = true;
			this.comboBoxLeft.Location = new global::System.Drawing.Point(28, 53);
			this.comboBoxLeft.Name = "comboBoxLeft";
			this.comboBoxLeft.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxLeft.TabIndex = 9;
			this.comboBoxKind.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxKind.FormattingEnabled = true;
			this.comboBoxKind.Location = new global::System.Drawing.Point(216, 21);
			this.comboBoxKind.Name = "comboBoxKind";
			this.comboBoxKind.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxKind.TabIndex = 7;
			this.comboBoxKind.SelectedValueChanged += new global::System.EventHandler(this.comboBoxKind_SelectedValueChanged);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(285, 214);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 6;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(162, 214);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 5;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			this.labelPreview.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelPreview.Location = new global::System.Drawing.Point(142, 47);
			this.labelPreview.Name = "labelPreview";
			this.labelPreview.Size = new global::System.Drawing.Size(267, 23);
			this.labelPreview.TabIndex = 15;
			this.labelPreview.Text = "プレビュー";
			this.labelPreview.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(550, 285);
			base.Controls.Add(this.splitContainer1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyDataDialog";
			this.Text = "データ設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyDataDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDownConst).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000030 RID: 48
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.ComboBox comboBoxDirect;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.ComboBox comboBoxOperate;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.ComboBox comboBoxRight;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.ComboBox comboBoxLeft;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.ComboBox comboBoxKind;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.TextBox textBoxConst;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.NumericUpDown numericUpDownConst;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.RadioButton radioButtonLight;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.RadioButton radioButtonTemperature;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.RadioButton radioButtonVariable;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.RadioButton radioButtonConst;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000043 RID: 67
		private global::System.Windows.Forms.Label labelPreview;
	}
}
