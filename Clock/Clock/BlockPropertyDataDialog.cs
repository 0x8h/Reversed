using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000006 RID: 6
	public partial class BlockPropertyDataDialog : Form
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00004AC8 File Offset: 0x00002CC8
		public BlockPropertyDataDialog(ProgramModule.BlockData block, NetworkProgramModules programs)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._programs = programs;
			this.comboBoxLeft.SelectedIndexChanged += this.UI_ValueChanged;
			this.comboBoxOperate.SelectedIndexChanged += this.UI_ValueChanged;
			this.comboBoxRight.SelectedIndexChanged += this.UI_ValueChanged;
			this.radioButtonConst.CheckedChanged += this.UI_ValueChanged;
			this.radioButtonVariable.CheckedChanged += this.UI_ValueChanged;
			this.radioButtonTemperature.CheckedChanged += this.UI_ValueChanged;
			this.radioButtonLight.CheckedChanged += this.UI_ValueChanged;
			this.numericUpDownConst.ValueChanged += this.UI_ValueChanged;
			this.comboBoxKind.Items.Add(ProgramModule.BlockData.DATA_KIND_ITEMS[0]);
			if (this._programs.Level != NetworkProgramModules.LEVEL.LEVEL_1)
			{
				this.comboBoxKind.Items.Add(ProgramModule.BlockData.DATA_KIND_ITEMS[1]);
			}
			this.comboBoxKind.SelectedIndex = (int)block.Kind;
			for (int i = 0; i < this._programs.ClientVariableNames.Count<string>(); i++)
			{
				this.comboBoxLeft.Items.Add("(C)" + this._programs.ClientVariableNames[i]);
			}
			this.comboBoxLeft.SelectedIndex = block.VariableIndexLeft;
			this.comboBoxRight.SelectedIndex = BlockPropertyDataDialog.getComboBoxRightIndex(block.Kind, block.VariableType, block.VariableIndexRight);
			switch (block.ValueType)
			{
			case ProgramModule.BlockData.DATA_VALUE_TYPE.CONST:
				this.radioButtonConst.Checked = true;
				break;
			case ProgramModule.BlockData.DATA_VALUE_TYPE.VARIABLE:
				this.radioButtonVariable.Checked = true;
				break;
			case ProgramModule.BlockData.DATA_VALUE_TYPE.TEMPERATURE:
				this.radioButtonTemperature.Checked = true;
				break;
			case ProgramModule.BlockData.DATA_VALUE_TYPE.LIGHT:
				this.radioButtonLight.Checked = true;
				break;
			}
			this.comboBoxDirect.SelectedIndex = (int)block.ConnectDirect;
			this.comboBoxOperate.Items.Add(ProgramModule.BlockData.DATA_OPERATE_ITEMS[0]);
			this.comboBoxOperate.Items.Add(ProgramModule.BlockData.DATA_OPERATE_ITEMS[1]);
			this.comboBoxOperate.SelectedIndex = (int)block.Operate;
			this.textBoxConst.MaxLength = NetworkSimulator.NetworkVariable.VARIABLE_LENGTH_MAX;
			this.textBoxConst.Text = block.ConstString;
			this.numericUpDownConst.Value = block.ConstValue;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004D68 File Offset: 0x00002F68
		private void setBlockData(ProgramModule.BlockData block)
		{
			block.Kind = (ProgramModule.BlockData.DATA_KIND)this.comboBoxKind.SelectedIndex;
			block.VariableIndexLeft = this.comboBoxLeft.SelectedIndex;
			block.VariableIndexRight = BlockPropertyDataDialog.getVariableIndex(block.Kind, this.comboBoxRight.SelectedIndex, this._programs);
			if (this.radioButtonConst.Checked)
			{
				block.ValueType = ProgramModule.BlockData.DATA_VALUE_TYPE.CONST;
			}
			else if (this.radioButtonVariable.Checked)
			{
				block.ValueType = ProgramModule.BlockData.DATA_VALUE_TYPE.VARIABLE;
			}
			else if (this.radioButtonTemperature.Checked)
			{
				block.ValueType = ProgramModule.BlockData.DATA_VALUE_TYPE.TEMPERATURE;
			}
			else
			{
				block.ValueType = ProgramModule.BlockData.DATA_VALUE_TYPE.LIGHT;
			}
			block.VariableType = BlockPropertyDataDialog.getVariableType(block.Kind, this.comboBoxRight.SelectedIndex, this._programs);
			block.ConnectDirect = (ProgramModule.BlockData.CONNECT_DIRECT)this.comboBoxDirect.SelectedIndex;
			block.Operate = (ProgramModule.BlockData.DATA_OPERATE)this.comboBoxOperate.SelectedIndex;
			block.ConstString = this.textBoxConst.Text;
			block.ConstValue = (int)this.numericUpDownConst.Value;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00004E70 File Offset: 0x00003070
		public static int getComboBoxRightIndex(ProgramModule.BlockData.DATA_KIND kind, ProgramModule.BlockData.DATA_VARIABLE_TYPE type, int variableIndex)
		{
			int num = 0;
			if (kind != ProgramModule.BlockData.DATA_KIND.SUBSTITUTION)
			{
				if (kind == ProgramModule.BlockData.DATA_KIND.ARITHMETIC)
				{
					if (type == ProgramModule.BlockData.DATA_VARIABLE_TYPE.CLIENT)
					{
						num = variableIndex;
					}
				}
			}
			else if (type != ProgramModule.BlockData.DATA_VARIABLE_TYPE.INPUT)
			{
				if (type == ProgramModule.BlockData.DATA_VARIABLE_TYPE.CLIENT)
				{
					num = variableIndex + 1;
				}
			}
			else
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00004EA2 File Offset: 0x000030A2
		public static ProgramModule.BlockData.DATA_VARIABLE_TYPE getVariableType(ProgramModule.BlockData.DATA_KIND kind, int comboBoxIndex, NetworkProgramModules programs)
		{
			switch (kind)
			{
			case ProgramModule.BlockData.DATA_KIND.SUBSTITUTION:
				if (comboBoxIndex == 0)
				{
					return ProgramModule.BlockData.DATA_VARIABLE_TYPE.INPUT;
				}
				return ProgramModule.BlockData.DATA_VARIABLE_TYPE.CLIENT;
			case ProgramModule.BlockData.DATA_KIND.ARITHMETIC:
				if (comboBoxIndex < programs.ClientVariableNames.Count)
				{
					return ProgramModule.BlockData.DATA_VARIABLE_TYPE.CLIENT;
				}
				break;
			}
			return ProgramModule.BlockData.DATA_VARIABLE_TYPE.MAX;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004ED0 File Offset: 0x000030D0
		public static int getVariableIndex(ProgramModule.BlockData.DATA_KIND kind, int comboBoxIndex, NetworkProgramModules programs)
		{
			if (kind == ProgramModule.BlockData.DATA_KIND.SUBSTITUTION)
			{
				return comboBoxIndex - 1;
			}
			if (kind != ProgramModule.BlockData.DATA_KIND.ARITHMETIC)
			{
				return comboBoxIndex;
			}
			if (comboBoxIndex < programs.ClientVariableNames.Count)
			{
				return comboBoxIndex;
			}
			return comboBoxIndex - programs.ClientVariableNames.Count;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004F00 File Offset: 0x00003100
		private void updatePreview()
		{
			if (this.comboBoxLeft.SelectedItem != null && this.comboBoxOperate.SelectedItem != null)
			{
				this.labelPreview.Text = this.comboBoxLeft.SelectedItem.ToString() + " " + this.comboBoxOperate.SelectedItem.ToString() + " ";
			}
			if (this.radioButtonConst.Checked)
			{
				Label label = this.labelPreview;
				label.Text += this.numericUpDownConst.Value.ToString();
				return;
			}
			if (this.radioButtonVariable.Checked)
			{
				if (this.comboBoxRight.SelectedItem != null)
				{
					Label label2 = this.labelPreview;
					label2.Text += this.comboBoxRight.SelectedItem.ToString();
					return;
				}
			}
			else
			{
				if (this.radioButtonTemperature.Checked)
				{
					Label label3 = this.labelPreview;
					label3.Text += this.radioButtonTemperature.Text;
					return;
				}
				Label label4 = this.labelPreview;
				label4.Text += this.radioButtonLight.Text;
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000502C File Offset: 0x0000322C
		private void comboBoxKind_SelectedValueChanged(object sender, EventArgs e)
		{
			switch (this.comboBoxKind.SelectedIndex)
			{
			case 0:
			{
				this.label1.Visible = true;
				this.label1.Text = "を";
				this.label2.Visible = true;
				this.label2.Text = "にする";
				this.labelPreview.Visible = false;
				if (this._programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2)
				{
					this.radioButtonConst.Location = new Point(264, 15);
					this.radioButtonVariable.Location = new Point(264, 45);
					this.radioButtonTemperature.Visible = true;
					this.radioButtonLight.Visible = true;
					this.textBoxConst.Location = new Point(284, 15);
					this.comboBoxRight.Location = new Point(284, 44);
				}
				else
				{
					this.radioButtonConst.Location = new Point(214, 45);
					this.radioButtonVariable.Location = new Point(214, 75);
					this.radioButtonTemperature.Visible = false;
					this.radioButtonLight.Visible = false;
					this.textBoxConst.Location = new Point(234, 45);
					this.comboBoxRight.Location = new Point(234, 75);
				}
				this.textBoxConst.Visible = true;
				this.numericUpDownConst.Visible = false;
				this.comboBoxDirect.Visible = false;
				this.comboBoxOperate.Visible = false;
				this.comboBoxRight.Items.Clear();
				this.comboBoxRight.Items.Add("入力変数");
				for (int i = 0; i < this._programs.ClientVariableNames.Count<string>(); i++)
				{
					this.comboBoxRight.Items.Add("(C)" + this._programs.ClientVariableNames[i]);
				}
				break;
			}
			case 1:
			{
				this.label1.Visible = false;
				this.label2.Visible = false;
				this.labelPreview.Visible = true;
				this.radioButtonConst.Location = new Point(264, 15);
				this.radioButtonVariable.Location = new Point(264, 45);
				this.radioButtonTemperature.Visible = true;
				this.radioButtonLight.Visible = true;
				this.textBoxConst.Visible = false;
				this.textBoxConst.Location = new Point(284, 15);
				this.numericUpDownConst.Visible = true;
				this.comboBoxDirect.Visible = false;
				this.comboBoxOperate.Visible = true;
				this.comboBoxRight.Location = new Point(284, 44);
				this.comboBoxRight.Items.Clear();
				for (int j = 0; j < this._programs.ClientVariableNames.Count<string>(); j++)
				{
					this.comboBoxRight.Items.Add("(C)" + this._programs.ClientVariableNames[j]);
				}
				break;
			}
			case 2:
			{
				this.label1.Visible = true;
				this.label1.Text = "の";
				this.label2.Visible = true;
				this.label2.Text = "をつなぐ";
				this.labelPreview.Visible = false;
				this.radioButtonTemperature.Visible = false;
				this.radioButtonLight.Visible = false;
				this.textBoxConst.Visible = true;
				this.numericUpDownConst.Visible = false;
				this.comboBoxDirect.Visible = true;
				this.comboBoxOperate.Visible = false;
				this.comboBoxRight.Items.Clear();
				this.comboBoxRight.Items.Add("入力変数");
				for (int k = 0; k < this._programs.ClientVariableNames.Count<string>(); k++)
				{
					this.comboBoxRight.Items.Add(this._programs.ClientVariableNames[k]);
				}
				break;
			}
			}
			this.comboBoxRight.SelectedIndex = 0;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyDataDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00005459 File Offset: 0x00003659
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005478 File Offset: 0x00003678
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000548A File Offset: 0x0000368A
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000549C File Offset: 0x0000369C
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				this.setBlockData(this._block);
				base.Close();
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000054CD File Offset: 0x000036CD
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000054EC File Offset: 0x000036EC
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000054FE File Offset: 0x000036FE
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005510 File Offset: 0x00003710
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00005535 File Offset: 0x00003735
		private void UI_ValueChanged(object sender, EventArgs e)
		{
			this.updatePreview();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000553D File Offset: 0x0000373D
		private void radioButtonConst_CheckedChanged(object sender, EventArgs e)
		{
			this.textBoxConst.Enabled = true;
			this.numericUpDownConst.Enabled = true;
			this.comboBoxRight.Enabled = false;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00005563 File Offset: 0x00003763
		private void radioButtonVariable_CheckedChanged(object sender, EventArgs e)
		{
			this.textBoxConst.Enabled = false;
			this.numericUpDownConst.Enabled = false;
			this.comboBoxRight.Enabled = true;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00005589 File Offset: 0x00003789
		private void radioButtonTemperature_CheckedChanged(object sender, EventArgs e)
		{
			this.textBoxConst.Enabled = false;
			this.numericUpDownConst.Enabled = false;
			this.comboBoxRight.Enabled = false;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00005589 File Offset: 0x00003789
		private void radioButtonLight_CheckedChanged(object sender, EventArgs e)
		{
			this.textBoxConst.Enabled = false;
			this.numericUpDownConst.Enabled = false;
			this.comboBoxRight.Enabled = false;
		}

		// Token: 0x0400002E RID: 46
		private ProgramModule.BlockData _block;

		// Token: 0x0400002F RID: 47
		private NetworkProgramModules _programs;
	}
}
