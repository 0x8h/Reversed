using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200000F RID: 15
	public partial class BlockPropertyNetworkDisplayDialog : Form
	{
		// Token: 0x060000ED RID: 237 RVA: 0x0000FC50 File Offset: 0x0000DE50
		public BlockPropertyNetworkDisplayDialog(ProgramModule.BlockNetworkDisplay block, NetworkProgramModules programs)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._programs = programs;
			this.comboBoxObjectType.Items.Add(ProgramModule.BlockEvent.OBJECT_TYPE_ITEMS[0]);
			this.comboBoxObjectType.Items.Add(ProgramModule.BlockEvent.OBJECT_TYPE_ITEMS[1]);
			if (this._programs.Level != NetworkProgramModules.LEVEL.LEVEL_1)
			{
				this.comboBoxObjectType.Items.Add(ProgramModule.BlockEvent.OBJECT_TYPE_ITEMS[2]);
				this.comboBoxObjectType.Items.Add(ProgramModule.BlockEvent.OBJECT_TYPE_ITEMS[3]);
			}
			this.comboBoxObjectType.SelectedIndex = (int)block.ObjectType;
			this.updateComboBoxObjectType();
			if (this.comboBoxObject.Items.Count > 0)
			{
				this.comboBoxObject.SelectedIndex = this.comboBoxObject.Items.IndexOf(block.ObjectName);
			}
			if (block.Visible == ProgramModule.BlockNetworkDisplay.VISIBLE.ON)
			{
				this.radioButtonOn.Checked = true;
			}
			else
			{
				this.radioButtonOff.Checked = true;
			}
			if (block.ValueType == ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CONST)
			{
				this.radioButtonConst.Checked = true;
			}
			else
			{
				this.radioButtonVariable.Checked = true;
			}
			this.textBoxConst.MaxLength = NetworkSimulator.NetworkVariable.VARIABLE_LENGTH_MAX;
			this.textBoxConst.Text = block.ConstValue;
			this.comboBoxVariable.Items.Add("入力変数");
			for (int i = 0; i < this._programs.ClientVariableNames.Count; i++)
			{
				this.comboBoxVariable.Items.Add("(C)" + this._programs.ClientVariableNames[i]);
			}
			this.comboBoxVariable.SelectedIndex = BlockPropertyNetworkDisplayDialog.getComboBoxVariableIndex(block.ValueType, block.VariableIndex);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000FE28 File Offset: 0x0000E028
		private void updateComboBoxObjectType()
		{
			this.comboBoxObject.Items.Clear();
			List<NetworkProgramModules.ObjectInfo> list = null;
			switch (this.comboBoxObjectType.SelectedIndex)
			{
			case 0:
				list = this._programs.getObjects(NetworkProgramModules.OBJECT_TYPE.LABEL);
				break;
			case 1:
				list = this._programs.getObjects(NetworkProgramModules.OBJECT_TYPE.LIST);
				break;
			case 2:
				list = this._programs.getObjects(NetworkProgramModules.OBJECT_TYPE.BUTTON);
				break;
			case 3:
				list = this._programs.getObjects(NetworkProgramModules.OBJECT_TYPE.INPUT);
				break;
			case 4:
				list = this._programs.getObjects(NetworkProgramModules.OBJECT_TYPE.GRAPH);
				break;
			}
			foreach (NetworkProgramModules.ObjectInfo objectInfo in list)
			{
				this.comboBoxObject.Items.Add(objectInfo.getObjectName());
			}
			if (this.comboBoxObject.Items.Count > 0)
			{
				this.comboBoxObject.SelectedIndex = 0;
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000FF28 File Offset: 0x0000E128
		private void setBlockData(ProgramModule.BlockNetworkDisplay block)
		{
			block.ObjectType = (ProgramModule.BlockEvent.OBJECT_TYPE)this.comboBoxObjectType.SelectedIndex;
			if (this.comboBoxObject.SelectedItem != null)
			{
				block.ObjectName = this.comboBoxObject.SelectedItem.ToString();
			}
			block.Visible = (this.radioButtonOn.Checked ? ProgramModule.BlockNetworkDisplay.VISIBLE.ON : ProgramModule.BlockNetworkDisplay.VISIBLE.OFF);
			if (this.radioButtonConst.Checked)
			{
				block.ValueType = ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CONST;
			}
			else
			{
				block.ValueType = BlockPropertyNetworkDisplayDialog.getValueType(this.comboBoxVariable.SelectedIndex);
			}
			block.VariableIndex = BlockPropertyNetworkDisplayDialog.getVariableIndex(block.ValueType, this.comboBoxVariable.SelectedIndex);
			block.ConstValue = this.textBoxConst.Text;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000FFDC File Offset: 0x0000E1DC
		public static int getComboBoxVariableIndex(ProgramModule.BlockNetworkDisplay.VALUE_TYPE type, int variableIndex)
		{
			int num = 0;
			if (type != ProgramModule.BlockNetworkDisplay.VALUE_TYPE.INPUT)
			{
				if (type == ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CLIENT)
				{
					num = 1 + variableIndex;
				}
			}
			else
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000FFFD File Offset: 0x0000E1FD
		public static ProgramModule.BlockNetworkDisplay.VALUE_TYPE getValueType(int comboBoxIndex)
		{
			if (comboBoxIndex == 0)
			{
				return ProgramModule.BlockNetworkDisplay.VALUE_TYPE.INPUT;
			}
			return ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CLIENT;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00010005 File Offset: 0x0000E205
		public static int getVariableIndex(ProgramModule.BlockNetworkDisplay.VALUE_TYPE type, int comboBoxIndex)
		{
			if (type == ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CLIENT)
			{
				return comboBoxIndex - 1;
			}
			return comboBoxIndex;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00010010 File Offset: 0x0000E210
		private void comboBoxObjectType_SelectedValueChanged(object sender, EventArgs e)
		{
			this.updateComboBoxObjectType();
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00010018 File Offset: 0x0000E218
		private void radioButtonOn_CheckedChanged(object sender, EventArgs e)
		{
			this.groupBox1.Visible = true;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00010026 File Offset: 0x0000E226
		private void radioButtonOff_CheckedChanged(object sender, EventArgs e)
		{
			this.groupBox1.Visible = false;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00010034 File Offset: 0x0000E234
		private void radioButtonConst_CheckedChanged(object sender, EventArgs e)
		{
			this.textBoxConst.Enabled = true;
			this.comboBoxVariable.Enabled = false;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0001004E File Offset: 0x0000E24E
		private void radioButtonVariable_CheckedChanged(object sender, EventArgs e)
		{
			this.textBoxConst.Enabled = false;
			this.comboBoxVariable.Enabled = true;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyNetworkDisplayDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00010068 File Offset: 0x0000E268
		private void BlockPropertyNetworkDisplayDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (NetworkWindow.Instance.isTutorial() && !this._block.Updated)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0001008A File Offset: 0x0000E28A
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000100A9 File Offset: 0x0000E2A9
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000100BB File Offset: 0x0000E2BB
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000100D0 File Offset: 0x0000E2D0
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				if (NetworkWindow.Instance.Tutorial == NetworkWindow.TUTORIAL.CHANGE_PROPERTY)
				{
					if (this.comboBoxObjectType.SelectedIndex != 0 || this.comboBoxObject.SelectedIndex != 0 || !this.radioButtonOn.Checked || !this.radioButtonConst.Checked || !(this.textBoxConst.Text != ""))
					{
						return;
					}
				}
				else if (NetworkWindow.Instance.Tutorial == NetworkWindow.TUTORIAL.CHANGE_PROPERTY_2 && (this.comboBoxObjectType.SelectedIndex != 0 || this.comboBoxObject.SelectedIndex != 0 || !this.radioButtonOn.Checked || !this.radioButtonVariable.Checked || this.comboBoxVariable.SelectedIndex != 0))
				{
					return;
				}
				this.setBlockData(this._block);
				base.Close();
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000101B8 File Offset: 0x0000E3B8
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000101D7 File Offset: 0x0000E3D7
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000101E9 File Offset: 0x0000E3E9
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000101FB File Offset: 0x0000E3FB
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x04000112 RID: 274
		private ProgramModule.BlockNetworkDisplay _block;

		// Token: 0x04000113 RID: 275
		private NetworkProgramModules _programs;
	}
}
