using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000009 RID: 9
	public partial class BlockPropertyIfDialog : Form
	{
		// Token: 0x0600006E RID: 110 RVA: 0x00007854 File Offset: 0x00005A54
		public BlockPropertyIfDialog(ProgramModule.BlockIf block, int costMax, bool runningFlag)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._costMax = costMax;
			this._runningFlag = runningFlag;
			for (int i = 0; i < 11; i++)
			{
				this._groups[i] = new GroupBox();
				this._groups[i].Visible = false;
				this.splitContainer1.Panel2.Controls.Add(this._groups[i]);
				this._groups[i].Location = new Point(20, 40);
				this._groups[i].Size = new Size(this.splitContainer1.Panel2.Width - this._groups[i].Location.X * 2, 110);
				this._groups[i].Font = this._font;
			}
			object[] array;
			if (FlowchartWindow.Instance.IsUsbInOutEnable)
			{
				ComboBox.ObjectCollection items = this.comboBoxCondition.Items;
				array = ProgramModule.BlockIf.CONDITION_ITEMS;
				items.AddRange(array);
			}
			else
			{
				for (int j = 0; j < 10; j++)
				{
					this.comboBoxCondition.Items.Add(ProgramModule.BlockIf.CONDITION_ITEMS[j]);
				}
			}
			this._groups[0].Controls.Add(this._radioButtonButtonOn);
			this._groups[0].Controls.Add(this._radioButtonButtonOff);
			this._groups[0].Controls.Add(this._labelButton);
			this._labelButton.Text = "ボタンが";
			this._labelButton.Location = new Point(20, 20);
			this._labelButton.Size = new Size(200, 40);
			this._radioButtonButtonOn.Text = "ON";
			this._radioButtonButtonOn.Width = 50;
			this._radioButtonButtonOn.Location = new Point(20, 40);
			this._radioButtonButtonOff.Text = "OFF";
			this._radioButtonButtonOff.Location = new Point(70, 40);
			this._groups[1].Controls.Add(this._numericUpDownLightThreshold);
			this._groups[1].Controls.Add(this._radioButtonLightBright);
			this._groups[1].Controls.Add(this._radioButtonLightDark);
			this._groups[1].Controls.Add(this._radioButtonLightThreshold);
			this._groups[1].Controls.Add(this._radioButtonLightVariable);
			this._groups[1].Controls.Add(this._labelLight);
			this._groups[1].Controls.Add(this._comboBoxLightVariable);
			this._groups[1].Controls.Add(this._comboBoxLightThreshold);
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
			ComboBox.ObjectCollection items2 = this._comboBoxLightVariable.Items;
			array = ProgramModule.BlockIf.VARIABLE_ITEMS;
			items2.AddRange(array);
			this._comboBoxLightVariable.DropDownStyle = ComboBoxStyle.DropDownList;
			this._comboBoxLightThreshold.Location = new Point(280, 40);
			this._comboBoxLightThreshold.Width = 100;
			ComboBox.ObjectCollection items3 = this._comboBoxLightThreshold.Items;
			array = ProgramModule.BlockIf.LIGHT_ITEMS;
			items3.AddRange(array);
			this._comboBoxLightThreshold.DropDownStyle = ComboBoxStyle.DropDownList;
			this._groups[2].Controls.Add(this._radioButtonSoundOn);
			this._groups[2].Controls.Add(this._radioButtonSoundOff);
			this._groups[2].Controls.Add(this._labelSound);
			this._labelSound.Text = "音センサに入力が";
			this._labelSound.Location = new Point(20, 20);
			this._labelSound.Size = new Size(200, 40);
			this._radioButtonSoundOn.Text = "ある";
			this._radioButtonSoundOn.Location = new Point(20, 40);
			this._radioButtonSoundOn.Width = 50;
			this._radioButtonSoundOff.Text = "ない";
			this._radioButtonSoundOff.Location = new Point(70, 40);
			this._groups[3].Controls.Add(this._radioButtonAlarmOn);
			this._groups[3].Controls.Add(this._radioButtonAlarmOff);
			this._groups[3].Controls.Add(this._labelAlarm);
			this._labelAlarm.Text = "アラーム信号入力が";
			this._labelAlarm.Location = new Point(20, 20);
			this._labelAlarm.Size = new Size(200, 40);
			this._radioButtonAlarmOn.Text = "ある";
			this._radioButtonAlarmOn.Location = new Point(20, 40);
			this._radioButtonAlarmOn.Width = 50;
			this._radioButtonAlarmOff.Text = "ない";
			this._radioButtonAlarmOff.Location = new Point(70, 40);
			this._groups[4].Controls.Add(this._radioButtonTimerOn);
			this._groups[4].Controls.Add(this._radioButtonTimerOff);
			this._groups[4].Controls.Add(this._labelTimer);
			this._labelTimer.Text = "タイマー信号入力が";
			this._labelTimer.Location = new Point(20, 20);
			this._labelTimer.Size = new Size(200, 40);
			this._radioButtonTimerOn.Text = "ある";
			this._radioButtonTimerOn.Width = 50;
			this._radioButtonTimerOn.Location = new Point(20, 40);
			this._radioButtonTimerOff.Text = "ない";
			this._radioButtonTimerOff.Location = new Point(70, 40);
			this._groups[5].Controls.Add(this._numericUpDownTimeHour);
			this._groups[5].Controls.Add(this._numericUpDownTimeMinute);
			this._groups[5].Controls.Add(this._radioButtonTimeFast);
			this._groups[5].Controls.Add(this._radioButtonTimeEqual);
			this._groups[5].Controls.Add(this._radioButtonTimeSlow);
			this._groups[5].Controls.Add(this._labelTime);
			this._labelTime.Text = " 時刻が\u3000\u3000\u3000     :";
			this._labelTime.Location = new Point(80, 53);
			this._labelTime.Size = new Size(200, 40);
			this._numericUpDownTimeHour.Location = new Point(140, 50);
			this._numericUpDownTimeHour.Width = 35;
			this._numericUpDownTimeHour.Maximum = 23m;
			this._numericUpDownTimeMinute.Location = new Point(190, 50);
			this._numericUpDownTimeMinute.Width = 35;
			this._numericUpDownTimeMinute.Maximum = 59m;
			this._radioButtonTimeFast.Text = "よりも早い";
			this._radioButtonTimeFast.Location = new Point(250, 30);
			this._radioButtonTimeFast.Width = 100;
			this._radioButtonTimeEqual.Text = "と同じ";
			this._radioButtonTimeEqual.Location = new Point(250, 50);
			this._radioButtonTimeEqual.Width = 70;
			this._radioButtonTimeSlow.Text = "よりも遅い";
			this._radioButtonTimeSlow.Location = new Point(250, 70);
			this._radioButtonTimeSlow.Width = 100;
			this._groups[6].Controls.Add(this._numericUpDownTemperature);
			this._groups[6].Controls.Add(this._radioButtonTemperatureConst);
			this._groups[6].Controls.Add(this._radioButtonTemperatureVariable);
			this._groups[6].Controls.Add(this._comboBoxTemperatureVariable);
			this._groups[6].Controls.Add(this._comboBoxTemperatureCompare);
			this._groups[6].Controls.Add(this._labelTemperature);
			this._groups[6].Controls.Add(this._labelTemperature2);
			this._radioButtonTemperatureConst.CheckedChanged += this._radioButtonTemperatureConst_CheckedChanged;
			this._radioButtonTemperatureVariable.CheckedChanged += this._radioButtonTemperatureVariable_CheckedChanged;
			this._labelTemperature.Text = "温度が";
			this._labelTemperature.Location = new Point(75, 60);
			this._labelTemperature.Size = new Size(80, 40);
			this._labelTemperature2.Text = "℃";
			this._labelTemperature2.Size = new Size(20, 40);
			this._numericUpDownTemperature.Width = 45;
			this._numericUpDownTemperature.Maximum = 50m;
			this._numericUpDownTemperature.Minimum = -10m;
			this._radioButtonTemperatureConst.Location = new Point(130, 40);
			this._radioButtonTemperatureConst.Width = 20;
			this._labelTemperature2.Location = new Point(200, 45);
			this._numericUpDownTemperature.Location = new Point(150, 40);
			this._radioButtonTemperatureVariable.Location = new Point(130, 70);
			this._radioButtonTemperatureVariable.Width = 20;
			this._comboBoxTemperatureVariable.Location = new Point(150, 70);
			this._comboBoxTemperatureVariable.Width = 60;
			ComboBox.ObjectCollection items4 = this._comboBoxTemperatureVariable.Items;
			array = ProgramModule.BlockIf.VARIABLE_ITEMS;
			items4.AddRange(array);
			this._comboBoxTemperatureVariable.DropDownStyle = ComboBoxStyle.DropDownList;
			this._comboBoxTemperatureCompare.Location = new Point(250, 55);
			this._comboBoxTemperatureCompare.Width = 100;
			ComboBox.ObjectCollection items5 = this._comboBoxTemperatureCompare.Items;
			array = ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE;
			items5.AddRange(array);
			this._comboBoxTemperatureCompare.DropDownStyle = ComboBoxStyle.DropDownList;
			this._groups[8].Controls.Add(this._numericUpDownCounter);
			this._groups[8].Controls.Add(this._radioButtonCounterLow);
			this._groups[8].Controls.Add(this._radioButtonCounterEqual);
			this._groups[8].Controls.Add(this._radioButtonCounterHigh);
			this._groups[8].Controls.Add(this._labelCounter);
			this._labelCounter.Text = "秒カウンタが";
			this._labelCounter.Location = new Point(75, 55);
			this._labelCounter.Size = new Size(100, 40);
			this._numericUpDownCounter.Location = new Point(160, 50);
			this._numericUpDownCounter.Width = 45;
			this._numericUpDownCounter.Maximum = 255m;
			this._radioButtonCounterLow.Text = "よりも小さい";
			this._radioButtonCounterLow.Location = new Point(235, 30);
			this._radioButtonCounterLow.Width = 120;
			this._radioButtonCounterEqual.Text = "と同じ";
			this._radioButtonCounterEqual.Location = new Point(235, 50);
			this._radioButtonCounterEqual.Width = 70;
			this._radioButtonCounterHigh.Text = "よりも多い";
			this._radioButtonCounterHigh.Location = new Point(235, 70);
			this._radioButtonCounterHigh.Width = 120;
			this._groups[9].Controls.Add(this._numericUpDownVariable);
			this._groups[9].Controls.Add(this._comboBoxVariableLeft);
			this._groups[9].Controls.Add(this._comboBoxVariableRight);
			this._groups[9].Controls.Add(this._comboBoxVariableCompare);
			this._groups[9].Controls.Add(this._radioButtonVariableConst);
			this._groups[9].Controls.Add(this._radioButtonVariableVariable);
			this._groups[9].Controls.Add(this._labelVariable);
			this._groups[9].Controls.Add(this._labelVariablePreview);
			this._comboBoxVariableLeft.SelectedValueChanged += this.variable_ValueChanged;
			this._comboBoxVariableRight.SelectedValueChanged += this.variable_ValueChanged;
			this._comboBoxVariableCompare.SelectedValueChanged += this.variable_ValueChanged;
			this._radioButtonVariableConst.CheckedChanged += this.variable_ValueChanged;
			this._radioButtonVariableConst.CheckedChanged += this._radioButtonVariableConst_CheckedChanged;
			this._radioButtonVariableVariable.CheckedChanged += this.variable_ValueChanged;
			this._radioButtonVariableVariable.CheckedChanged += this._radioButtonVariableVariable_CheckedChanged;
			this._numericUpDownVariable.ValueChanged += this.variable_ValueChanged;
			this._labelVariablePreview.Text = "preview";
			this._labelVariablePreview.TextAlign = ContentAlignment.TopCenter;
			this._labelVariablePreview.Size = new Size(200, 20);
			this._labelVariablePreview.Location = new Point((this._groups[9].Width - this._labelVariablePreview.Width) / 2, 20);
			this._comboBoxVariableLeft.Location = new Point(20, 55);
			this._comboBoxVariableLeft.Width = 60;
			ComboBox.ObjectCollection items6 = this._comboBoxVariableLeft.Items;
			array = ProgramModule.BlockIf.VARIABLE_ITEMS;
			items6.AddRange(array);
			this._comboBoxVariableLeft.DropDownStyle = ComboBoxStyle.DropDownList;
			this._labelVariable.Text = "\u3000\u3000\u3000\u3000\u3000が";
			this._labelVariable.Location = new Point(20, 60);
			this._labelVariable.Size = new Size(100, 20);
			this._radioButtonVariableConst.Text = "";
			this._radioButtonVariableConst.Location = new Point(130, 40);
			this._radioButtonVariableConst.Width = 50;
			this._numericUpDownVariable.Location = new Point(150, 40);
			this._numericUpDownVariable.Width = 45;
			this._numericUpDownVariable.Maximum = 127m;
			this._numericUpDownVariable.Minimum = -128m;
			this._radioButtonVariableVariable.Text = "";
			this._radioButtonVariableVariable.Location = new Point(130, 70);
			this._radioButtonVariableVariable.Width = 50;
			this._comboBoxVariableRight.Location = new Point(150, 70);
			this._comboBoxVariableRight.Width = 60;
			ComboBox.ObjectCollection items7 = this._comboBoxVariableRight.Items;
			array = ProgramModule.BlockIf.VARIABLE_ITEMS;
			items7.AddRange(array);
			this._comboBoxVariableRight.DropDownStyle = ComboBoxStyle.DropDownList;
			this._comboBoxVariableCompare.Location = new Point(250, 55);
			this._comboBoxVariableCompare.Width = 120;
			ComboBox.ObjectCollection items8 = this._comboBoxVariableCompare.Items;
			array = ProgramModule.BlockIf.COMPARE_ITEMS;
			items8.AddRange(array);
			this._comboBoxVariableCompare.DropDownStyle = ComboBoxStyle.DropDownList;
			this._groups[10].Controls.Add(this._radioButtonUsbInOn);
			this._groups[10].Controls.Add(this._radioButtonUsbInOff);
			this._groups[10].Controls.Add(this._labelUsbIn);
			this._labelUsbIn.Text = "外部入力が";
			this._labelUsbIn.Location = new Point(20, 20);
			this._labelUsbIn.Size = new Size(200, 40);
			this._radioButtonUsbInOn.Text = "ある";
			this._radioButtonUsbInOn.Location = new Point(20, 40);
			this._radioButtonUsbInOn.Width = 50;
			this._radioButtonUsbInOff.Text = "ない";
			this._radioButtonUsbInOff.Location = new Point(70, 40);
			this.comboBoxCondition.SelectedIndex = (int)block.Condition;
			switch (block.Select)
			{
			case ProgramModule.BlockIf.SELECT.BUTTON_ON:
				this._radioButtonButtonOn.Select();
				this._radioButtonSoundOn.Select();
				this._radioButtonAlarmOn.Select();
				this._radioButtonTimerOn.Select();
				this._radioButtonTimeSlow.Select();
				this._radioButtonCounterLow.Select();
				this._radioButtonUsbInOn.Select();
				break;
			case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
				this._radioButtonButtonOff.Select();
				this._radioButtonSoundOff.Select();
				this._radioButtonAlarmOff.Select();
				this._radioButtonTimerOff.Select();
				this._radioButtonTimeEqual.Select();
				this._radioButtonCounterEqual.Select();
				this._radioButtonUsbInOff.Select();
				break;
			case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
				this._radioButtonButtonOn.Select();
				this._radioButtonSoundOn.Select();
				this._radioButtonAlarmOn.Select();
				this._radioButtonTimerOn.Select();
				this._radioButtonTimeFast.Select();
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
			this._comboBoxLightVariable.SelectedIndex = block.VariableIndexes[0];
			this._comboBoxLightThreshold.SelectedIndex = (int)block.Select;
			this._comboBoxVariableCompare.SelectedIndex = (int)block.Select;
			this._comboBoxTemperatureCompare.SelectedIndex = (int)block.Select;
			switch (block.Condition)
			{
			case ProgramModule.BlockIf.CONDITION_IF.TIME:
				this._numericUpDownTimeHour.Value = block.Values[0];
				this._numericUpDownTimeMinute.Value = block.Values[1];
				break;
			case ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE:
				this._numericUpDownTemperature.Value = block.Values[0];
				break;
			case ProgramModule.BlockIf.CONDITION_IF.COUNTER:
				this._numericUpDownCounter.Value = block.Values[0];
				break;
			case ProgramModule.BlockIf.CONDITION_IF.VARIABLE:
				this._numericUpDownVariable.Value = block.Values[0];
				break;
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
			this._radioButtonTemperatureVariable.Select();
			this._radioButtonVariableVariable.Select();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00009002 File Offset: 0x00007202
		private void updateLightNow(int value)
		{
			this._labelLightNowValue.Text = value.ToString();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00009018 File Offset: 0x00007218
		private async void comboBoxCondition_SelectedValueChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < 11; i++)
			{
				this._groups[i].Visible = false;
			}
			if (this.comboBoxCondition.SelectedIndex != 7)
			{
				this._groups[this.comboBoxCondition.SelectedIndex].Visible = true;
			}
			if (this.comboBoxCondition.SelectedIndex == 1)
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
							if (!this._runningFlag)
							{
								lightValue = CommunicationModule.Instance.getLightValue();
							}
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

		// Token: 0x06000071 RID: 113 RVA: 0x0000904F File Offset: 0x0000724F
		private void variable_ValueChanged(object sender, EventArgs e)
		{
			this.updatePreview();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00009058 File Offset: 0x00007258
		private void updatePreview()
		{
			if (this._comboBoxVariableLeft.SelectedIndex >= 0 && this._comboBoxVariableCompare.SelectedIndex >= 0)
			{
				if (this._radioButtonVariableConst.Checked)
				{
					this._labelVariablePreview.Text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._comboBoxVariableLeft.SelectedIndex] + "が" + this._numericUpDownVariable.Value.ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[this._comboBoxVariableCompare.SelectedIndex];
					return;
				}
				if (this._comboBoxVariableRight.SelectedIndex >= 0)
				{
					this._labelVariablePreview.Text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._comboBoxVariableLeft.SelectedIndex] + "が" + ProgramModule.BlockIf.VARIABLE_ITEMS[this._comboBoxVariableRight.SelectedIndex] + ProgramModule.BlockIf.COMPARE_ITEMS[this._comboBoxVariableCompare.SelectedIndex];
				}
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00009135 File Offset: 0x00007335
		private void BlockPropertyIfDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			this._lightNowEnable = false;
			base.Dispose();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00009144 File Offset: 0x00007344
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00009163 File Offset: 0x00007363
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00009175 File Offset: 0x00007375
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00009188 File Offset: 0x00007388
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				ProgramModule.BlockIf blockIf = new ProgramModule.BlockIf();
				this.setBlockData(blockIf);
				if (blockIf.getUsedMemory() > this._costMax)
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

		// Token: 0x06000078 RID: 120 RVA: 0x000091F8 File Offset: 0x000073F8
		private void setBlockData(ProgramModule.BlockIf block)
		{
			block.Condition = (ProgramModule.BlockIf.CONDITION_IF)this.comboBoxCondition.SelectedIndex;
			switch (block.Condition)
			{
			case ProgramModule.BlockIf.CONDITION_IF.BUTTON:
				block.Select = (this._radioButtonButtonOn.Checked ? ProgramModule.BlockIf.SELECT.BUTTON_ON : ProgramModule.BlockIf.SELECT.BUTTON_OFF);
				return;
			case ProgramModule.BlockIf.CONDITION_IF.LIGHT:
				if (this._radioButtonLightThreshold.Checked)
				{
					block.Select = (ProgramModule.BlockIf.SELECT)this._comboBoxLightThreshold.SelectedIndex;
					int[] array = new int[2];
					array[0] = (int)this._numericUpDownLightThreshold.Value;
					block.Values = array;
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					return;
				}
				if (this._radioButtonLightVariable.Checked)
				{
					block.Select = (ProgramModule.BlockIf.SELECT)this._comboBoxLightThreshold.SelectedIndex;
					int[] array2 = new int[2];
					array2[0] = this._comboBoxLightVariable.SelectedIndex;
					block.VariableIndexes = array2;
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					return;
				}
				block.Select = (this._radioButtonLightBright.Checked ? ProgramModule.BlockIf.SELECT.BUTTON_ON : ProgramModule.BlockIf.SELECT.BUTTON_OFF);
				block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID;
				return;
			case ProgramModule.BlockIf.CONDITION_IF.SOUND:
				block.Select = (this._radioButtonSoundOn.Checked ? ProgramModule.BlockIf.SELECT.BUTTON_ON : ProgramModule.BlockIf.SELECT.BUTTON_OFF);
				return;
			case ProgramModule.BlockIf.CONDITION_IF.ALARM:
				block.Select = (this._radioButtonAlarmOn.Checked ? ProgramModule.BlockIf.SELECT.BUTTON_ON : ProgramModule.BlockIf.SELECT.BUTTON_OFF);
				return;
			case ProgramModule.BlockIf.CONDITION_IF.TIMER:
				block.Select = (this._radioButtonTimerOn.Checked ? ProgramModule.BlockIf.SELECT.BUTTON_ON : ProgramModule.BlockIf.SELECT.BUTTON_OFF);
				return;
			case ProgramModule.BlockIf.CONDITION_IF.TIME:
				if (this._radioButtonTimeFast.Checked)
				{
					block.Select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
				}
				else if (this._radioButtonTimeEqual.Checked)
				{
					block.Select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
				}
				else
				{
					block.Select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
				}
				block.Values = new int[]
				{
					(int)this._numericUpDownTimeHour.Value,
					(int)this._numericUpDownTimeMinute.Value
				};
				return;
			case ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE:
				if (this._radioButtonTemperatureConst.Checked)
				{
					int[] array3 = new int[2];
					array3[0] = (int)this._numericUpDownTemperature.Value;
					block.Values = array3;
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
				}
				else
				{
					block.VariableIndexes[0] = this._comboBoxTemperatureVariable.SelectedIndex;
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
				}
				block.Select = (ProgramModule.BlockIf.SELECT)this._comboBoxTemperatureCompare.SelectedIndex;
				return;
			case ProgramModule.BlockIf.CONDITION_IF.RANDOM:
				break;
			case ProgramModule.BlockIf.CONDITION_IF.COUNTER:
			{
				if (this._radioButtonCounterLow.Checked)
				{
					block.Select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
				}
				else if (this._radioButtonCounterEqual.Checked)
				{
					block.Select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
				}
				else
				{
					block.Select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
				}
				int[] array4 = new int[2];
				array4[0] = (int)this._numericUpDownCounter.Value;
				block.Values = array4;
				return;
			}
			case ProgramModule.BlockIf.CONDITION_IF.VARIABLE:
			{
				if (this._radioButtonVariableConst.Checked)
				{
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
				}
				else
				{
					block.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
				}
				int[] array5 = new int[2];
				array5[0] = (int)this._numericUpDownVariable.Value;
				block.Values = array5;
				block.VariableIndexes = new int[]
				{
					this._comboBoxVariableLeft.SelectedIndex,
					this._comboBoxVariableRight.SelectedIndex
				};
				block.Select = (ProgramModule.BlockIf.SELECT)this._comboBoxVariableCompare.SelectedIndex;
				return;
			}
			case ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX:
				block.Select = (this._radioButtonUsbInOn.Checked ? ProgramModule.BlockIf.SELECT.BUTTON_ON : ProgramModule.BlockIf.SELECT.BUTTON_OFF);
				break;
			default:
				return;
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000094FB File Offset: 0x000076FB
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000951A File Offset: 0x0000771A
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000952C File Offset: 0x0000772C
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000953E File Offset: 0x0000773E
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00009563 File Offset: 0x00007763
		private void _radioButtonLightBright_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownLightThreshold.Enabled = false;
			this._comboBoxLightVariable.Enabled = false;
			this._comboBoxLightThreshold.Enabled = false;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00009563 File Offset: 0x00007763
		private void _radioButtonLightDark_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownLightThreshold.Enabled = false;
			this._comboBoxLightVariable.Enabled = false;
			this._comboBoxLightThreshold.Enabled = false;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00009589 File Offset: 0x00007789
		private void _radioButtonLightThreshold_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownLightThreshold.Enabled = true;
			this._comboBoxLightVariable.Enabled = false;
			this._comboBoxLightThreshold.Enabled = true;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000095AF File Offset: 0x000077AF
		private void _radioButtonLightVariable_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownLightThreshold.Enabled = false;
			this._comboBoxLightVariable.Enabled = true;
			this._comboBoxLightThreshold.Enabled = true;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000095D5 File Offset: 0x000077D5
		private void _radioButtonTemperatureConst_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownTemperature.Enabled = true;
			this._comboBoxTemperatureVariable.Enabled = false;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000095EF File Offset: 0x000077EF
		private void _radioButtonTemperatureVariable_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownTemperature.Enabled = false;
			this._comboBoxTemperatureVariable.Enabled = true;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00009609 File Offset: 0x00007809
		private void _radioButtonVariableConst_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownVariable.Enabled = true;
			this._comboBoxVariableRight.Enabled = false;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00009623 File Offset: 0x00007823
		private void _radioButtonVariableVariable_CheckedChanged(object sender, EventArgs e)
		{
			this._numericUpDownVariable.Enabled = false;
			this._comboBoxVariableRight.Enabled = true;
		}

		// Token: 0x04000058 RID: 88
		private ProgramModule.BlockIf _block;

		// Token: 0x04000059 RID: 89
		private int _costMax;

		// Token: 0x0400005A RID: 90
		private bool _runningFlag;

		// Token: 0x0400005B RID: 91
		private Font _font = new Font("メイリオ", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);

		// Token: 0x0400005C RID: 92
		private GroupBox[] _groups = new GroupBox[11];

		// Token: 0x0400005D RID: 93
		private Label _labelButton = new Label();

		// Token: 0x0400005E RID: 94
		private RadioButton _radioButtonButtonOn = new RadioButton();

		// Token: 0x0400005F RID: 95
		private RadioButton _radioButtonButtonOff = new RadioButton();

		// Token: 0x04000060 RID: 96
		private Label _labelLight = new Label();

		// Token: 0x04000061 RID: 97
		private Label _labelLightNow = new Label();

		// Token: 0x04000062 RID: 98
		private Label _labelLightNowValue = new Label();

		// Token: 0x04000063 RID: 99
		private RadioButton _radioButtonLightBright = new RadioButton();

		// Token: 0x04000064 RID: 100
		private RadioButton _radioButtonLightDark = new RadioButton();

		// Token: 0x04000065 RID: 101
		private RadioButton _radioButtonLightThreshold = new RadioButton();

		// Token: 0x04000066 RID: 102
		private RadioButton _radioButtonLightVariable = new RadioButton();

		// Token: 0x04000067 RID: 103
		private NumericUpDown _numericUpDownLightThreshold = new NumericUpDown();

		// Token: 0x04000068 RID: 104
		private ComboBox _comboBoxLightVariable = new ComboBox();

		// Token: 0x04000069 RID: 105
		private ComboBox _comboBoxLightThreshold = new ComboBox();

		// Token: 0x0400006A RID: 106
		private bool _lightNowEnable;

		// Token: 0x0400006B RID: 107
		private Label _labelSound = new Label();

		// Token: 0x0400006C RID: 108
		private RadioButton _radioButtonSoundOn = new RadioButton();

		// Token: 0x0400006D RID: 109
		private RadioButton _radioButtonSoundOff = new RadioButton();

		// Token: 0x0400006E RID: 110
		private Label _labelAlarm = new Label();

		// Token: 0x0400006F RID: 111
		private RadioButton _radioButtonAlarmOn = new RadioButton();

		// Token: 0x04000070 RID: 112
		private RadioButton _radioButtonAlarmOff = new RadioButton();

		// Token: 0x04000071 RID: 113
		private Label _labelTimer = new Label();

		// Token: 0x04000072 RID: 114
		private RadioButton _radioButtonTimerOn = new RadioButton();

		// Token: 0x04000073 RID: 115
		private RadioButton _radioButtonTimerOff = new RadioButton();

		// Token: 0x04000074 RID: 116
		private Label _labelTime = new Label();

		// Token: 0x04000075 RID: 117
		private RadioButton _radioButtonTimeFast = new RadioButton();

		// Token: 0x04000076 RID: 118
		private RadioButton _radioButtonTimeEqual = new RadioButton();

		// Token: 0x04000077 RID: 119
		private RadioButton _radioButtonTimeSlow = new RadioButton();

		// Token: 0x04000078 RID: 120
		private NumericUpDown _numericUpDownTimeHour = new NumericUpDown();

		// Token: 0x04000079 RID: 121
		private NumericUpDown _numericUpDownTimeMinute = new NumericUpDown();

		// Token: 0x0400007A RID: 122
		private Label _labelTemperature = new Label();

		// Token: 0x0400007B RID: 123
		private Label _labelTemperature2 = new Label();

		// Token: 0x0400007C RID: 124
		private RadioButton _radioButtonTemperatureConst = new RadioButton();

		// Token: 0x0400007D RID: 125
		private RadioButton _radioButtonTemperatureVariable = new RadioButton();

		// Token: 0x0400007E RID: 126
		private NumericUpDown _numericUpDownTemperature = new NumericUpDown();

		// Token: 0x0400007F RID: 127
		private ComboBox _comboBoxTemperatureVariable = new ComboBox();

		// Token: 0x04000080 RID: 128
		private ComboBox _comboBoxTemperatureCompare = new ComboBox();

		// Token: 0x04000081 RID: 129
		private Label _labelCounter = new Label();

		// Token: 0x04000082 RID: 130
		private RadioButton _radioButtonCounterLow = new RadioButton();

		// Token: 0x04000083 RID: 131
		private RadioButton _radioButtonCounterEqual = new RadioButton();

		// Token: 0x04000084 RID: 132
		private RadioButton _radioButtonCounterHigh = new RadioButton();

		// Token: 0x04000085 RID: 133
		private NumericUpDown _numericUpDownCounter = new NumericUpDown();

		// Token: 0x04000086 RID: 134
		private Label _labelVariable = new Label();

		// Token: 0x04000087 RID: 135
		private Label _labelVariablePreview = new Label();

		// Token: 0x04000088 RID: 136
		private RadioButton _radioButtonVariableConst = new RadioButton();

		// Token: 0x04000089 RID: 137
		private RadioButton _radioButtonVariableVariable = new RadioButton();

		// Token: 0x0400008A RID: 138
		private NumericUpDown _numericUpDownVariable = new NumericUpDown();

		// Token: 0x0400008B RID: 139
		private ComboBox _comboBoxVariableLeft = new ComboBox();

		// Token: 0x0400008C RID: 140
		private ComboBox _comboBoxVariableRight = new ComboBox();

		// Token: 0x0400008D RID: 141
		private ComboBox _comboBoxVariableCompare = new ComboBox();

		// Token: 0x0400008E RID: 142
		private Label _labelUsbIn = new Label();

		// Token: 0x0400008F RID: 143
		private RadioButton _radioButtonUsbInOn = new RadioButton();

		// Token: 0x04000090 RID: 144
		private RadioButton _radioButtonUsbInOff = new RadioButton();
	}
}
