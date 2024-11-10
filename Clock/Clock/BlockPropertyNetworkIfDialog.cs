﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000010 RID: 16
	public partial class BlockPropertyNetworkIfDialog : Form
	{
		// Token: 0x06000104 RID: 260 RVA: 0x00010CCC File Offset: 0x0000EECC
		public BlockPropertyNetworkIfDialog(ProgramModule.BlockIf block, NetworkProgramModules programs)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._programs = programs;
			for (int i = 0; i < 7; i++)
			{
				this._groups[i] = new GroupBox();
				this._groups[i].Visible = false;
				this.splitContainer1.Panel2.Controls.Add(this._groups[i]);
				this._groups[i].Location = new Point(20, 40);
				this._groups[i].Size = new Size(this.splitContainer1.Panel2.Width - this._groups[i].Location.X * 2, 140);
				this._groups[i].Font = this._font;
			}
			this.comboBoxCondition.Items.Add(ProgramModule.BlockIf.CONDITION_NETWORK_ITEMS[0]);
			this.comboBoxCondition.Items.Add(ProgramModule.BlockIf.CONDITION_NETWORK_ITEMS[1]);
			if (this._programs.Level != NetworkProgramModules.LEVEL.LEVEL_1)
			{
				this.comboBoxCondition.Items.Add(ProgramModule.BlockIf.CONDITION_NETWORK_ITEMS[2]);
				this.comboBoxCondition.Items.Add(ProgramModule.BlockIf.CONDITION_NETWORK_ITEMS[3]);
				this.comboBoxCondition.Items.Add(ProgramModule.BlockIf.CONDITION_NETWORK_ITEMS[4]);
				this.comboBoxCondition.Items.Add(ProgramModule.BlockIf.CONDITION_NETWORK_ITEMS[5]);
				if (this._programs.Level != NetworkProgramModules.LEVEL.LEVEL_2 && NetworkWindow.Instance.IsUsbInOutEnable)
				{
					this.comboBoxCondition.Items.Add(ProgramModule.BlockIf.CONDITION_NETWORK_ITEMS[6]);
				}
			}
			this._groups[0].Controls.Add(this._comboBoxObjectButton);
			this._groups[0].Controls.Add(this._labelObjectButton);
			this._groups[0].Controls.Add(this._radioButtonObjectButtonOn);
			this._groups[0].Controls.Add(this._radioButtonObjectButtonOff);
			this._comboBoxObjectButton.Location = new Point(40, 40);
			this._comboBoxObjectButton.DropDownStyle = ComboBoxStyle.DropDownList;
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._programs.getObjects(NetworkProgramModules.OBJECT_TYPE.BUTTON))
			{
				this._comboBoxObjectButton.Items.Add(objectInfo.getObjectName());
			}
			this._labelObjectButton.Text = "が";
			this._labelObjectButton.Location = new Point(180, 45);
			this._labelObjectButton.Size = new Size(30, 20);
			this._radioButtonObjectButtonOn.Text = "ON";
			this._radioButtonObjectButtonOn.Location = new Point(220, 40);
			this._radioButtonObjectButtonOn.Width = 50;
			this._radioButtonObjectButtonOff.Text = "OFF";
			this._radioButtonObjectButtonOff.Location = new Point(270, 40);
			this._radioButtonObjectButtonOff.Width = 50;
			this._groups[1].Controls.Add(this._numericUpDownVariable);
			this._groups[1].Controls.Add(this._comboBoxVariableLeft);
			this._groups[1].Controls.Add(this._comboBoxVariableRight);
			this._groups[1].Controls.Add(this._comboBoxVariableCompare);
			this._groups[1].Controls.Add(this._textBoxVariableConstString);
			this._groups[1].Controls.Add(this._radioButtonVariableConst);
			this._groups[1].Controls.Add(this._radioButtonVariableVariable);
			this._groups[1].Controls.Add(this._radioButtonVariableConstString);
			this._groups[1].Controls.Add(this._labelVariable);
			this._groups[1].Controls.Add(this._labelVariablePreview);
			this._comboBoxVariableLeft.SelectedValueChanged += this.variable_ValueChanged;
			this._comboBoxVariableRight.SelectedValueChanged += this.variable_ValueChanged;
			this._comboBoxVariableCompare.SelectedValueChanged += this.variable_ValueChanged;
			this._radioButtonVariableConst.CheckedChanged += this.variable_ValueChanged;
			this._radioButtonVariableConst.CheckedChanged += this._radioButtonVariableConst_CheckedChanged;
			this._radioButtonVariableVariable.CheckedChanged += this.variable_ValueChanged;
			this._radioButtonVariableVariable.CheckedChanged += this._radioButtonVariableVariable_CheckedChanged;
			this._radioButtonVariableConstString.CheckedChanged += this.variable_ValueChanged;
			this._radioButtonVariableConstString.CheckedChanged += this._radioButtonVariableConstString_CheckedChanged;
			this._numericUpDownVariable.ValueChanged += this.variable_ValueChanged;
			this._textBoxVariableConstString.TextChanged += this.variable_ValueChanged;
			this._labelVariablePreview.Text = "preview";
			this._labelVariablePreview.TextAlign = ContentAlignment.TopCenter;
			this._labelVariablePreview.Size = new Size(200, 20);
			this._labelVariablePreview.Location = new Point((this._groups[1].Width - this._labelVariablePreview.Width) / 2, 20);
			this._comboBoxVariableLeft.Location = new Point(20, 55);
			this._comboBoxVariableLeft.Width = 100;
			for (int j = 0; j < this._programs.ClientVariableNames.Count<string>(); j++)
			{
				this._comboBoxVariableLeft.Items.Add("(C)" + this._programs.ClientVariableNames[j]);
			}
			this._comboBoxVariableLeft.DropDownStyle = ComboBoxStyle.DropDownList;
			this._labelVariable.Text = "\u3000\u3000\u3000\u3000\u3000が";
			this._labelVariable.Location = new Point(20, 60);
			this._labelVariable.Size = new Size(100, 20);
			this._radioButtonVariableConst.Text = "";
			this._radioButtonVariableConst.Location = new Point(130, 40);
			this._radioButtonVariableConst.Width = 50;
			this._numericUpDownVariable.Location = new Point(150, 40);
			this._numericUpDownVariable.Width = 65;
			this._numericUpDownVariable.Maximum = 32767m;
			this._numericUpDownVariable.Minimum = -32768m;
			this._radioButtonVariableVariable.Text = "";
			this._radioButtonVariableVariable.Location = new Point(130, 70);
			this._radioButtonVariableVariable.Width = 50;
			this._comboBoxVariableRight.Location = new Point(150, 70);
			this._comboBoxVariableRight.Width = 80;
			this._comboBoxVariableRight.Items.Add("入力変数");
			for (int k = 0; k < this._programs.ClientVariableNames.Count<string>(); k++)
			{
				this._comboBoxVariableRight.Items.Add("(C)" + this._programs.ClientVariableNames[k]);
			}
			this._comboBoxVariableRight.DropDownStyle = ComboBoxStyle.DropDownList;
			this._radioButtonVariableConstString.Text = "";
			this._radioButtonVariableConstString.Location = new Point(130, 100);
			this._radioButtonVariableConstString.Width = 50;
			this._textBoxVariableConstString.Location = new Point(150, 100);
			this._textBoxVariableConstString.Width = 100;
			this._textBoxVariableConstString.MaxLength = NetworkSimulator.NetworkVariable.VARIABLE_LENGTH_MAX;
			this._comboBoxVariableCompare.Location = new Point(250, 55);
			this._comboBoxVariableCompare.Width = 120;
			object[] array;
			if (this._programs.Level == NetworkProgramModules.LEVEL.LEVEL_1)
			{
				this._comboBoxVariableCompare.Items.Add(ProgramModule.BlockIf.COMPARE_ITEMS[1]);
			}
			else
			{
				ComboBox.ObjectCollection items = this._comboBoxVariableCompare.Items;
				array = ProgramModule.BlockIf.COMPARE_ITEMS;
				items.AddRange(array);
			}
			this._comboBoxVariableCompare.DropDownStyle = ComboBoxStyle.DropDownList;
			this._groups[2].Controls.Add(this._radioButtonButtonOn);
			this._groups[2].Controls.Add(this._radioButtonButtonOff);
			this._groups[2].Controls.Add(this._labelButton);
			this._labelButton.Text = "ボタンが";
			this._labelButton.Location = new Point(20, 20);
			this._labelButton.Size = new Size(200, 40);
			this._radioButtonButtonOn.Text = "ON";
			this._radioButtonButtonOn.Location = new Point(20, 40);
			this._radioButtonButtonOn.Width = 50;
			this._radioButtonButtonOff.Text = "OFF";
			this._radioButtonButtonOff.Location = new Point(70, 40);
			this._groups[3].Controls.Add(this._numericUpDownLightThreshold);
			this._groups[3].Controls.Add(this._radioButtonLightBright);
			this._groups[3].Controls.Add(this._radioButtonLightDark);
			this._groups[3].Controls.Add(this._radioButtonLightThreshold);
			this._groups[3].Controls.Add(this._radioButtonLightVariable);
			this._groups[3].Controls.Add(this._labelLight);
			this._groups[3].Controls.Add(this._comboBoxLightVariable);
			this._groups[3].Controls.Add(this._comboBoxLightThreshold);
			this.splitContainer1.Panel2.Controls.Add(this._labelLightNow);
			this.splitContainer1.Panel2.Controls.Add(this._labelLightNowValue);
			this._radioButtonLightBright.CheckedChanged += this._radioButtonLightBright_CheckedChanged;
			this._radioButtonLightDark.CheckedChanged += this._radioButtonLightDark_CheckedChanged;
			this._radioButtonLightThreshold.CheckedChanged += this._radioButtonLightThreshold_CheckedChanged;
			this._radioButtonLightVariable.CheckedChanged += this._radioButtonLightVariable_CheckedChanged;
			this._labelLight.Text = "周囲の明るさが";
			this._labelLight.Location = new Point(20, 20);
			this._labelLight.Size = new Size(200, 40);
			this._labelLightNow.Text = "現在の明るさ：";
			this._labelLightNow.Location = new Point(280, 18);
			this._labelLightNow.Size = new Size(80, 20);
			this._labelLightNowValue.Text = "0";
			this._labelLightNowValue.Location = new Point(360, 18);
			this._labelLightNowValue.Size = new Size(30, 20);
			this._radioButtonLightBright.Text = "明るい";
			this._radioButtonLightBright.Location = new Point(20, 40);
			this._radioButtonLightBright.Width = 70;
			this._radioButtonLightDark.Text = "暗い";
			this._radioButtonLightDark.Location = new Point(90, 40);
			this._radioButtonLightDark.Width = 70;
			this._radioButtonLightThreshold.Location = new Point(160, 40);
			this._radioButtonLightVariable.Location = new Point(160, 80);
			this._radioButtonLightVariable.Width = 15;
			this._numericUpDownLightThreshold.Location = new Point(180, 40);
			this._numericUpDownLightThreshold.Width = 55;
			this._numericUpDownLightThreshold.Minimum = 0m;
			this._numericUpDownLightThreshold.Maximum = 100m;
			this._comboBoxLightVariable.Location = new Point(180, 80);
			this._comboBoxLightVariable.Width = 100;
			for (int l = 0; l < this._programs.ClientVariableNames.Count<string>(); l++)
			{
				this._comboBoxLightVariable.Items.Add("(C)" + this._programs.ClientVariableNames[l]);
			}
			this._comboBoxLightVariable.DropDownStyle = ComboBoxStyle.DropDownList;
			this._comboBoxLightThreshold.Location = new Point(280, 40);
			this._comboBoxLightThreshold.Width = 100;
			ComboBox.ObjectCollection items2 = this._comboBoxLightThreshold.Items;
			array = ProgramModule.BlockIf.LIGHT_ITEMS;
			items2.AddRange(array);
			this._comboBoxLightThreshold.DropDownStyle = ComboBoxStyle.DropDownList;
			this._groups[4].Controls.Add(this._numericUpDownTemperature);
			this._groups[4].Controls.Add(this._radioButtonTemperatureConst);
			this._groups[4].Controls.Add(this._radioButtonTemperatureVariable);
			this._groups[4].Controls.Add(this._comboBoxTemperatureVariable);
			this._groups[4].Controls.Add(this._comboBoxTemperatureCompare);
			this._groups[4].Controls.Add(this._labelTemperature);
			this._groups[4].Controls.Add(this._labelTemperature2);
			this._radioButtonTemperatureConst.CheckedChanged += this._radioButtonTemperatureConst_CheckedChanged;
			this._radioButtonTemperatureVariable.CheckedChanged += this._radioButtonTemperatureVariable_CheckedChanged;
			this._labelTemperature.Text = "温度が";
			this._labelTemperature.Location = new Point(75, 60);
			this._labelTemperature.Size = new Size(80, 40);
			this._labelTemperature2.Text = "℃";
			this._labelTemperature2.Location = new Point(200, 45);
			this._labelTemperature2.Size = new Size(20, 40);
			this._numericUpDownTemperature.Location = new Point(150, 40);
			this._numericUpDownTemperature.Width = 45;
			this._numericUpDownTemperature.Maximum = 50m;
			this._numericUpDownTemperature.Minimum = -10m;
			this._radioButtonTemperatureConst.Location = new Point(130, 40);
			this._radioButtonTemperatureConst.Width = 20;
			this._radioButtonTemperatureVariable.Location = new Point(130, 70);
			this._radioButtonTemperatureVariable.Width = 20;
			this._comboBoxTemperatureVariable.Location = new Point(150, 70);
			this._comboBoxTemperatureVariable.Width = 80;
			for (int m = 0; m < this._programs.ClientVariableNames.Count<string>(); m++)
			{
				this._comboBoxTemperatureVariable.Items.Add("C" + this._programs.ClientVariableNames[m]);
			}
			this._comboBoxTemperatureVariable.DropDownStyle = ComboBoxStyle.DropDownList;
			this._comboBoxTemperatureCompare.Location = new Point(250, 55);
			this._comboBoxTemperatureCompare.Width = 100;
			ComboBox.ObjectCollection items3 = this._comboBoxTemperatureCompare.Items;
			array = ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE;
			items3.AddRange(array);
			this._comboBoxTemperatureCompare.DropDownStyle = ComboBoxStyle.DropDownList;
			this._groups[5].Controls.Add(this._radioButtonSoundOn);
			this._groups[5].Controls.Add(this._radioButtonSoundOff);
			this._groups[5].Controls.Add(this._labelSound);
			this._labelSound.Text = "音センサに入力が";
			this._labelSound.Location = new Point(20, 20);
			this._labelSound.Size = new Size(200, 40);
			this._radioButtonSoundOn.Text = "ある";
			this._radioButtonSoundOn.Location = new Point(20, 40);
			this._radioButtonSoundOn.Width = 50;
			this._radioButtonSoundOff.Text = "ない";
			this._radioButtonSoundOff.Location = new Point(70, 40);
			this._groups[6].Controls.Add(this._radioButtonUsbInOn);
			this._groups[6].Controls.Add(this._radioButtonUsbInOff);
			this._groups[6].Controls.Add(this._labelUsbIn);
			this._labelUsbIn.Text = "外部入力が";
			this._labelUsbIn.Location = new Point(20, 20);
			this._labelUsbIn.Size = new Size(200, 40);
			this._radioButtonUsbInOn.Text = "ある";
			this._radioButtonUsbInOn.Location = new Point(20, 40);
			this._radioButtonUsbInOn.Width = 50;
			this._radioButtonUsbInOff.Text = "ない";
			this._radioButtonUsbInOff.Location = new Point(70, 40);
			this.comboBoxCondition.SelectedIndex = (int)block.ConditionNetwork;
			switch (block.Select)
			{
			case ProgramModule.BlockIf.SELECT.BUTTON_ON:
				this._radioButtonObjectButtonOn.Select();
				this._radioButtonButtonOn.Select();
				this._radioButtonSoundOn.Select();
				this._radioButtonCounterLow.Select();
				this._radioButtonUsbInOn.Select();
				break;
			case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
				this._radioButtonObjectButtonOff.Select();
				this._radioButtonButtonOff.Select();
				this._radioButtonSoundOff.Select();
				this._radioButtonCounterEqual.Select();
				this._radioButtonUsbInOff.Select();
				break;
			case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
				this._radioButtonObjectButtonOn.Select();
				this._radioButtonButtonOn.Select();
				this._radioButtonSoundOn.Select();
				this._radioButtonCounterHigh.Select();
				this._radioButtonUsbInOn.Select();
				break;
			}
			switch (block.Variable)
			{
			case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID:
				if (block.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
				{
					this._radioButtonLightBright.Select();
				}
				else
				{
					this._radioButtonLightDark.Select();
				}
				break;
			case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST:
				this._radioButtonLightThreshold.Select();
				this._numericUpDownLightThreshold.Value = Math.Min(this._numericUpDownLightThreshold.Maximum, Math.Max(this._numericUpDownLightThreshold.Minimum, block.Values[0]));
				break;
			case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX:
				this._radioButtonLightVariable.Select();
				break;
			}
			if (this._comboBoxObjectButton.Items.Count > 0)
			{
				this._comboBoxObjectButton.SelectedIndex = this._comboBoxObjectButton.Items.IndexOf(block.ObjectName);
			}
			this._comboBoxLightVariable.SelectedIndex = block.VariableIndexes[0];
			this._comboBoxLightThreshold.SelectedIndex = (int)block.Select;
			if (this._programs.Level == NetworkProgramModules.LEVEL.LEVEL_1)
			{
				this._comboBoxVariableCompare.SelectedIndex = 0;
			}
			else
			{
				this._comboBoxVariableCompare.SelectedIndex = (int)block.Select;
			}
			this._comboBoxTemperatureCompare.SelectedIndex = (int)block.Select;
			ProgramModule.BlockIf.CONDITION_NETWORK_IF conditionNetwork = block.ConditionNetwork;
			if (conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE)
			{
				if (conditionNetwork == ProgramModule.BlockIf.CONDITION_NETWORK_IF.TEMPERATURE)
				{
					this._numericUpDownTemperature.Value = Math.Min(this._numericUpDownTemperature.Maximum, Math.Max(this._numericUpDownTemperature.Minimum, block.Values[0]));
				}
			}
			else
			{
				this._numericUpDownVariable.Value = block.Values[0];
				this._textBoxVariableConstString.Text = block.ConstString;
			}
			this._comboBoxTemperatureVariable.SelectedIndex = block.VariableIndexes[0];
			this._comboBoxVariableLeft.SelectedIndex = block.VariableIndexes[0];
			this._comboBoxVariableRight.SelectedIndex = block.VariableIndexes[1];
			if (block.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
			{
				this._radioButtonTemperatureConst.Select();
				this._radioButtonVariableConst.Select();
				return;
			}
			if (block.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
			{
				this._radioButtonTemperatureVariable.Select();
				this._radioButtonVariableVariable.Select();
				return;
			}
			this._radioButtonTemperatureConst.Select();
			this._radioButtonVariableConstString.Select();
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0001231C File Offset: 0x0001051C
		private void updateLightNow(int value)
		{
			this._labelLightNowValue.Text = value.ToString();
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00012330 File Offset: 0x00010530
		private void updatePreview()
		{
			if (this._comboBoxVariableLeft.SelectedIndex >= 0 && this._comboBoxVariableCompare.SelectedIndex >= 0)
			{
				int num;
				if (this._programs.Level == NetworkProgramModules.LEVEL.LEVEL_1)
				{
					num = 1;
				}
				else
				{
					num = this._comboBoxVariableCompare.SelectedIndex;
				}
				if (this._radioButtonVariableConst.Checked)
				{
					this._labelVariablePreview.Text = this._comboBoxVariableLeft.SelectedItem.ToString() + "が" + this._numericUpDownVariable.Value.ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[num];
					return;
				}
				if (this._radioButtonVariableConstString.Checked)
				{
					this._labelVariablePreview.Text = this._comboBoxVariableLeft.SelectedItem.ToString() + "が" + this._textBoxVariableConstString.Text + ProgramModule.BlockIf.COMPARE_ITEMS[num];
					return;
				}
				if (this._comboBoxVariableRight.SelectedIndex >= 0)
				{
					this._labelVariablePreview.Text = this._comboBoxVariableLeft.SelectedItem.ToString() + "が" + this._comboBoxVariableRight.SelectedItem.ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[num];
				}
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00012458 File Offset: 0x00010658
		private async void comboBoxCondition_SelectedValueChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < 7; i++)
			{
				this._groups[i].Visible = false;
			}
			this._groups[this.comboBoxCondition.SelectedIndex].Visible = true;
			if (this.comboBoxCondition.SelectedIndex == 3)
			{
				this._radioButtonLightBright.Select();
				this._numericUpDownLightThreshold.Value = 50m;
				this._labelLightNow.Visible = true;
				this._labelLightNowValue.Visible = true;
				this._lightNowEnable = true;
				await Task.Run(delegate
				{
					while (this._lightNowEnable)
					{
						try
						{
							int lightValue = -1;
							lightValue = CommunicationModule.Instance.getLightValue();
							if (lightValue < 0)
							{
								this._lightNowEnable = false;
							}
							else
							{
								base.Invoke(new MethodInvoker(delegate
								{
									this.updateLightNow(lightValue);
								}));
							}
						}
						catch (InvalidOperationException)
						{
						}
						Thread.Sleep(500);
					}
				});
			}
			else
			{
				this._labelLightNow.Visible = false;
				this._labelLightNowValue.Visible = false;
				this._lightNowEnable = false;
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0001248F File Offset: 0x0001068F
		private void BlockPropertyNetworkIfDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			this._lightNowEnable = false;
			base.Dispose();
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0001249E File Offset: 0x0001069E
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000124BD File Offset: 0x000106BD
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000124CF File Offset: 0x000106CF
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000124E1 File Offset: 0x000106E1
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				this.setBlockData(this._block);
				base.Close();
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00012514 File Offset: 0x00010714
		private void setBlockData(ProgramModule.BlockIf block)
		{
			block.ConditionNetwork = (ProgramModule.BlockIf.CONDITION_NETWORK_IF)this.comboBoxCondition.SelectedIndex;
			switch (block.ConditionNetwork)
			{
			case ProgramModule.BlockIf.CONDITION_NETWORK_IF.OBJECT_BUTTON:
				block.Select = (this._radioButtonObjectButtonOn.Checked ? ProgramModule.BlockIf.SELECT.BUTTON_ON : ProgramModule.BlockIf.SELECT.BUTTON_OFF);
				if (this._comboBoxObjectButton.SelectedItem != null)
				{
					block.ObjectName = this._comboBoxObjectButton.SelectedItem.ToString();
					return;
				}
				break;
			case ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE:
			{
				if (this._radioButtonVariableConst.Checked)
				{
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
				}
				else if (this._radioButtonVariableVariable.Checked)
				{
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
				}
				else
				{
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST_STRING;
				}
				int[] array = new int[2];
				array[0] = (int)this._numericUpDownVariable.Value;
				block.Values = array;
				block.VariableIndexes = new int[]
				{
					this._comboBoxVariableLeft.SelectedIndex,
					this._comboBoxVariableRight.SelectedIndex
				};
				block.ConstString = this._textBoxVariableConstString.Text;
				if (this._programs.Level == NetworkProgramModules.LEVEL.LEVEL_1)
				{
					block.Select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					return;
				}
				block.Select = (ProgramModule.BlockIf.SELECT)this._comboBoxVariableCompare.SelectedIndex;
				return;
			}
			case ProgramModule.BlockIf.CONDITION_NETWORK_IF.BUTTON:
				block.Select = (this._radioButtonButtonOn.Checked ? ProgramModule.BlockIf.SELECT.BUTTON_ON : ProgramModule.BlockIf.SELECT.BUTTON_OFF);
				return;
			case ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT:
				if (this._radioButtonLightThreshold.Checked)
				{
					block.Select = (ProgramModule.BlockIf.SELECT)this._comboBoxLightThreshold.SelectedIndex;
					int[] array2 = new int[2];
					array2[0] = (int)this._numericUpDownLightThreshold.Value;
					block.Values = array2;
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					return;
				}
				if (this._radioButtonLightVariable.Checked)
				{
					block.Select = (ProgramModule.BlockIf.SELECT)this._comboBoxLightThreshold.SelectedIndex;
					int[] array3 = new int[2];
					array3[0] = this._comboBoxLightVariable.SelectedIndex;
					block.VariableIndexes = array3;
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					return;
				}
				block.Select = (this._radioButtonLightBright.Checked ? ProgramModule.BlockIf.SELECT.BUTTON_ON : ProgramModule.BlockIf.SELECT.BUTTON_OFF);
				block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID;
				return;
			case ProgramModule.BlockIf.CONDITION_NETWORK_IF.TEMPERATURE:
				if (this._radioButtonTemperatureConst.Checked)
				{
					int[] array4 = new int[2];
					array4[0] = (int)this._numericUpDownTemperature.Value;
					block.Values = array4;
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
				}
				else
				{
					block.VariableIndexes[0] = this._comboBoxTemperatureVariable.SelectedIndex;
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
				}
				block.Select = (ProgramModule.BlockIf.SELECT)this._comboBoxTemperatureCompare.SelectedIndex;
				return;
			case ProgramModule.BlockIf.CONDITION_NETWORK_IF.SOUND:
				block.Select = (this._radioButtonSoundOn.Checked ? ProgramModule.BlockIf.SELECT.BUTTON_ON : ProgramModule.BlockIf.SELECT.BUTTON_OFF);
				return;
			case ProgramModule.BlockIf.CONDITION_NETWORK_IF.USBIN:
				block.Select = (this._radioButtonUsbInOn.Checked ? ProgramModule.BlockIf.SELECT.BUTTON_ON : ProgramModule.BlockIf.SELECT.BUTTON_OFF);
				break;
			default:
				return;
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00012798 File Offset: 0x00010998
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000127B7 File Offset: 0x000109B7
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000127C9 File Offset: 0x000109C9
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000127DB File Offset: 0x000109DB
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00012800 File Offset: 0x00010A00
		private void variable_ValueChanged(object sender, EventArgs e)
		{
			this.updatePreview();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00012808 File Offset: 0x00010A08
		private void _radioButtonLightBright_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownLightThreshold.Enabled = false;
			this._comboBoxLightVariable.Enabled = false;
			this._comboBoxLightThreshold.Enabled = false;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00012808 File Offset: 0x00010A08
		private void _radioButtonLightDark_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownLightThreshold.Enabled = false;
			this._comboBoxLightVariable.Enabled = false;
			this._comboBoxLightThreshold.Enabled = false;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0001282E File Offset: 0x00010A2E
		private void _radioButtonLightThreshold_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownLightThreshold.Enabled = true;
			this._comboBoxLightVariable.Enabled = false;
			this._comboBoxLightThreshold.Enabled = true;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00012854 File Offset: 0x00010A54
		private void _radioButtonLightVariable_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownLightThreshold.Enabled = false;
			this._comboBoxLightVariable.Enabled = true;
			this._comboBoxLightThreshold.Enabled = true;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0001287A File Offset: 0x00010A7A
		private void _radioButtonTemperatureConst_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownTemperature.Enabled = true;
			this._comboBoxTemperatureVariable.Enabled = false;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00012894 File Offset: 0x00010A94
		private void _radioButtonTemperatureVariable_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownTemperature.Enabled = false;
			this._comboBoxTemperatureVariable.Enabled = true;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000128AE File Offset: 0x00010AAE
		private void _radioButtonVariableConst_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownVariable.Enabled = true;
			this._comboBoxVariableRight.Enabled = false;
			this._textBoxVariableConstString.Enabled = false;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000128D4 File Offset: 0x00010AD4
		private void _radioButtonVariableVariable_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownVariable.Enabled = false;
			this._comboBoxVariableRight.Enabled = true;
			this._textBoxVariableConstString.Enabled = false;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000128FA File Offset: 0x00010AFA
		private void _radioButtonVariableConstString_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownVariable.Enabled = false;
			this._comboBoxVariableRight.Enabled = false;
			this._textBoxVariableConstString.Enabled = true;
		}

		// Token: 0x04000122 RID: 290
		private ProgramModule.BlockIf _block;

		// Token: 0x04000123 RID: 291
		private NetworkProgramModules _programs;

		// Token: 0x04000124 RID: 292
		private Font _font = new Font("メイリオ", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);

		// Token: 0x04000125 RID: 293
		private GroupBox[] _groups = new GroupBox[7];

		// Token: 0x04000126 RID: 294
		private ComboBox _comboBoxObjectButton = new ComboBox();

		// Token: 0x04000127 RID: 295
		private Label _labelObjectButton = new Label();

		// Token: 0x04000128 RID: 296
		private RadioButton _radioButtonObjectButtonOn = new RadioButton();

		// Token: 0x04000129 RID: 297
		private RadioButton _radioButtonObjectButtonOff = new RadioButton();

		// Token: 0x0400012A RID: 298
		private Label _labelVariable = new Label();

		// Token: 0x0400012B RID: 299
		private Label _labelVariablePreview = new Label();

		// Token: 0x0400012C RID: 300
		private RadioButton _radioButtonVariableConst = new RadioButton();

		// Token: 0x0400012D RID: 301
		private RadioButton _radioButtonVariableVariable = new RadioButton();

		// Token: 0x0400012E RID: 302
		private RadioButton _radioButtonVariableConstString = new RadioButton();

		// Token: 0x0400012F RID: 303
		private NumericUpDown _numericUpDownVariable = new NumericUpDown();

		// Token: 0x04000130 RID: 304
		private ComboBox _comboBoxVariableLeft = new ComboBox();

		// Token: 0x04000131 RID: 305
		private ComboBox _comboBoxVariableRight = new ComboBox();

		// Token: 0x04000132 RID: 306
		private ComboBox _comboBoxVariableCompare = new ComboBox();

		// Token: 0x04000133 RID: 307
		private TextBox _textBoxVariableConstString = new TextBox();

		// Token: 0x04000134 RID: 308
		private Label _labelButton = new Label();

		// Token: 0x04000135 RID: 309
		private RadioButton _radioButtonButtonOn = new RadioButton();

		// Token: 0x04000136 RID: 310
		private RadioButton _radioButtonButtonOff = new RadioButton();

		// Token: 0x04000137 RID: 311
		private Label _labelLight = new Label();

		// Token: 0x04000138 RID: 312
		private Label _labelLightNow = new Label();

		// Token: 0x04000139 RID: 313
		private Label _labelLightNowValue = new Label();

		// Token: 0x0400013A RID: 314
		private RadioButton _radioButtonLightBright = new RadioButton();

		// Token: 0x0400013B RID: 315
		private RadioButton _radioButtonLightDark = new RadioButton();

		// Token: 0x0400013C RID: 316
		private RadioButton _radioButtonLightThreshold = new RadioButton();

		// Token: 0x0400013D RID: 317
		private RadioButton _radioButtonLightVariable = new RadioButton();

		// Token: 0x0400013E RID: 318
		private NumericUpDown _numericUpDownLightThreshold = new NumericUpDown();

		// Token: 0x0400013F RID: 319
		private ComboBox _comboBoxLightVariable = new ComboBox();

		// Token: 0x04000140 RID: 320
		private ComboBox _comboBoxLightThreshold = new ComboBox();

		// Token: 0x04000141 RID: 321
		private bool _lightNowEnable;

		// Token: 0x04000142 RID: 322
		private Label _labelTemperature = new Label();

		// Token: 0x04000143 RID: 323
		private Label _labelTemperature2 = new Label();

		// Token: 0x04000144 RID: 324
		private RadioButton _radioButtonTemperatureConst = new RadioButton();

		// Token: 0x04000145 RID: 325
		private RadioButton _radioButtonTemperatureVariable = new RadioButton();

		// Token: 0x04000146 RID: 326
		private NumericUpDown _numericUpDownTemperature = new NumericUpDown();

		// Token: 0x04000147 RID: 327
		private ComboBox _comboBoxTemperatureVariable = new ComboBox();

		// Token: 0x04000148 RID: 328
		private ComboBox _comboBoxTemperatureCompare = new ComboBox();

		// Token: 0x04000149 RID: 329
		private Label _labelSound = new Label();

		// Token: 0x0400014A RID: 330
		private RadioButton _radioButtonSoundOn = new RadioButton();

		// Token: 0x0400014B RID: 331
		private RadioButton _radioButtonSoundOff = new RadioButton();

		// Token: 0x0400014C RID: 332
		private Label _labelCounter = new Label();

		// Token: 0x0400014D RID: 333
		private RadioButton _radioButtonCounterLow = new RadioButton();

		// Token: 0x0400014E RID: 334
		private RadioButton _radioButtonCounterEqual = new RadioButton();

		// Token: 0x0400014F RID: 335
		private RadioButton _radioButtonCounterHigh = new RadioButton();

		// Token: 0x04000150 RID: 336
		private NumericUpDown _numericUpDownCounter = new NumericUpDown();

		// Token: 0x04000151 RID: 337
		private Label _labelUsbIn = new Label();

		// Token: 0x04000152 RID: 338
		private RadioButton _radioButtonUsbInOn = new RadioButton();

		// Token: 0x04000153 RID: 339
		private RadioButton _radioButtonUsbInOff = new RadioButton();
	}
}
