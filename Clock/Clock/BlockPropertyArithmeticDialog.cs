using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000003 RID: 3
	public partial class BlockPropertyArithmeticDialog : Form
	{
		// Token: 0x06000007 RID: 7 RVA: 0x0000216C File Offset: 0x0000036C
		public BlockPropertyArithmeticDialog(ProgramModule.BlockArithmetic block, int costMax)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._costMax = costMax;
			this.comboBoxLeft.SelectedValueChanged += this.all_ValueChanged;
			this.comboBoxRight.SelectedValueChanged += this.all_ValueChanged;
			this.comboBoxOperator.SelectedValueChanged += this.all_ValueChanged;
			this.radioButtonConst.CheckedChanged += this.all_ValueChanged;
			this.radioButtonValuable.CheckedChanged += this.all_ValueChanged;
			this.radioButtonTemperature.CheckedChanged += this.all_ValueChanged;
			this.radioButtonLight.CheckedChanged += this.all_ValueChanged;
			this.numericUpDownRight.ValueChanged += this.all_ValueChanged;
			ComboBox.ObjectCollection items = this.comboBoxLeft.Items;
			object[] array = ProgramModule.BlockIf.VARIABLE_ITEMS;
			items.AddRange(array);
			ComboBox.ObjectCollection items2 = this.comboBoxRight.Items;
			array = ProgramModule.BlockIf.VARIABLE_ITEMS;
			items2.AddRange(array);
			ComboBox.ObjectCollection items3 = this.comboBoxOperator.Items;
			array = ProgramModule.BlockArithmetic.OPERATE_ITEMS;
			items3.AddRange(array);
			this.comboBoxLeft.SelectedIndex = block.VariableIndex[0];
			this.comboBoxRight.SelectedIndex = block.VariableIndex[1];
			this.comboBoxOperator.SelectedIndex = (int)block.Operate;
			this.numericUpDownRight.Value = block.ConstValue;
			switch (block.Variable)
			{
			case ProgramModule.BlockArithmetic.VARIABLE_SECOND.CONST:
				this.radioButtonConst.Select();
				return;
			case ProgramModule.BlockArithmetic.VARIABLE_SECOND.INDEX:
				this.radioButtonValuable.Select();
				return;
			case ProgramModule.BlockArithmetic.VARIABLE_SECOND.TEMPERATURE:
				this.radioButtonTemperature.Select();
				return;
			case ProgramModule.BlockArithmetic.VARIABLE_SECOND.LIGHT:
				this.radioButtonLight.Select();
				return;
			default:
				return;
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002344 File Offset: 0x00000544
		private void all_ValueChanged(object sender, EventArgs e)
		{
			this.updatePreview();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000234C File Offset: 0x0000054C
		private void updatePreview()
		{
			if (this.comboBoxLeft.SelectedIndex >= 0 && this.comboBoxOperator.SelectedIndex >= 0)
			{
				if (this.radioButtonConst.Checked)
				{
					this.labelPreview.Text = string.Concat(new string[]
					{
						ProgramModule.BlockIf.VARIABLE_ITEMS[this.comboBoxLeft.SelectedIndex],
						" ",
						ProgramModule.BlockArithmetic.OPERATE_ITEMS[this.comboBoxOperator.SelectedIndex],
						" ",
						this.numericUpDownRight.Value.ToString()
					});
					return;
				}
				if (this.radioButtonTemperature.Checked)
				{
					this.labelPreview.Text = ProgramModule.BlockIf.VARIABLE_ITEMS[this.comboBoxLeft.SelectedIndex] + " " + ProgramModule.BlockArithmetic.OPERATE_ITEMS[this.comboBoxOperator.SelectedIndex] + " 温度";
					return;
				}
				if (this.radioButtonLight.Checked)
				{
					this.labelPreview.Text = ProgramModule.BlockIf.VARIABLE_ITEMS[this.comboBoxLeft.SelectedIndex] + " " + ProgramModule.BlockArithmetic.OPERATE_ITEMS[this.comboBoxOperator.SelectedIndex] + " 明るさ";
					return;
				}
				if (this.comboBoxRight.SelectedIndex >= 0)
				{
					this.labelPreview.Text = string.Concat(new string[]
					{
						ProgramModule.BlockIf.VARIABLE_ITEMS[this.comboBoxLeft.SelectedIndex],
						" ",
						ProgramModule.BlockArithmetic.OPERATE_ITEMS[this.comboBoxOperator.SelectedIndex],
						" ",
						ProgramModule.BlockIf.VARIABLE_ITEMS[this.comboBoxRight.SelectedIndex]
					});
				}
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyArithmeticDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000024F9 File Offset: 0x000006F9
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002518 File Offset: 0x00000718
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000252A File Offset: 0x0000072A
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000253C File Offset: 0x0000073C
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				ProgramModule.BlockArithmetic blockArithmetic = new ProgramModule.BlockArithmetic();
				this.setBlockData(blockArithmetic);
				if (blockArithmetic.getUsedMemory() > this._costMax)
				{
					WarningDialog warningDialog = new WarningDialog();
					warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
					warningDialog.ShowDialog();
					return;
				}
				this.setBlockData(this._block);
				base.Close();
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000025AC File Offset: 0x000007AC
		private void setBlockData(ProgramModule.BlockArithmetic block)
		{
			block.VariableIndex = new int[]
			{
				this.comboBoxLeft.SelectedIndex,
				this.comboBoxRight.SelectedIndex
			};
			block.Operate = (ProgramModule.BlockArithmetic.OPERATE)this.comboBoxOperator.SelectedIndex;
			block.ConstValue = (int)this.numericUpDownRight.Value;
			if (this.radioButtonConst.Checked)
			{
				block.Variable = ProgramModule.BlockArithmetic.VARIABLE_SECOND.CONST;
				return;
			}
			if (this.radioButtonValuable.Checked)
			{
				block.Variable = ProgramModule.BlockArithmetic.VARIABLE_SECOND.INDEX;
				return;
			}
			if (this.radioButtonTemperature.Checked)
			{
				block.Variable = ProgramModule.BlockArithmetic.VARIABLE_SECOND.TEMPERATURE;
				return;
			}
			block.Variable = ProgramModule.BlockArithmetic.VARIABLE_SECOND.LIGHT;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000264E File Offset: 0x0000084E
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000266D File Offset: 0x0000086D
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000267F File Offset: 0x0000087F
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002691 File Offset: 0x00000891
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000026B6 File Offset: 0x000008B6
		private void radioButtonConst_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownRight.Enabled = true;
			this.comboBoxRight.Enabled = false;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000026D0 File Offset: 0x000008D0
		private void radioButtonValuable_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownRight.Enabled = false;
			this.comboBoxRight.Enabled = true;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000026EA File Offset: 0x000008EA
		private void radioButtonTemperature_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownRight.Enabled = false;
			this.comboBoxRight.Enabled = false;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000026EA File Offset: 0x000008EA
		private void radioButtonLight_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownRight.Enabled = false;
			this.comboBoxRight.Enabled = false;
		}

		// Token: 0x04000003 RID: 3
		private ProgramModule.BlockArithmetic _block;

		// Token: 0x04000004 RID: 4
		private int _costMax;
	}
}
