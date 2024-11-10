using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000018 RID: 24
	public partial class BlockPropertyWaitConditionDialog : Form
	{
		// Token: 0x0600019E RID: 414 RVA: 0x00019ED0 File Offset: 0x000180D0
		public BlockPropertyWaitConditionDialog(ProgramModule.BlockWaitCondition block, int costMax)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._costMax = costMax;
			switch (this._block.Condition)
			{
			case ProgramModule.BlockWaitCondition.CONDITION.BUTTON:
				this.radioButtonButton.Checked = true;
				break;
			case ProgramModule.BlockWaitCondition.CONDITION.LIGHT:
				if (this._block.Light == ProgramModule.BlockWaitCondition.LIGHT.BRIGHT)
				{
					this.radioButtonLightBright.Checked = true;
				}
				else
				{
					this.radioButtonLightDark.Checked = true;
				}
				break;
			case ProgramModule.BlockWaitCondition.CONDITION.SOUND:
				this.radioButtonSound.Checked = true;
				break;
			case ProgramModule.BlockWaitCondition.CONDITION.ALARM:
				this.radioButtonAlarm.Checked = true;
				break;
			case ProgramModule.BlockWaitCondition.CONDITION.TIMER:
				this.radioButtonTimer.Checked = true;
				break;
			case ProgramModule.BlockWaitCondition.CONDITION.TIME:
				this.radioButtonTime.Checked = true;
				break;
			case ProgramModule.BlockWaitCondition.CONDITION.TEMPERATURE:
				this.radioButtonTemperature.Checked = true;
				break;
			}
			this.numericUpDownHour.Value = this._block.Hour;
			this.numericUpDownMinute.Value = this._block.Minute;
			this.numericUpDownTemperature.Value = this._block.Temperature;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0001A00D File Offset: 0x0001820D
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0001A02C File Offset: 0x0001822C
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0001A03E File Offset: 0x0001823E
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0001A050 File Offset: 0x00018250
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				ProgramModule.BlockWaitCondition blockWaitCondition = new ProgramModule.BlockWaitCondition();
				this.setBlockData(blockWaitCondition);
				if (blockWaitCondition.getUsedMemory() > this._costMax)
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

		// Token: 0x060001A3 RID: 419 RVA: 0x0001A0C0 File Offset: 0x000182C0
		private void setBlockData(ProgramModule.BlockWaitCondition block)
		{
			if (this.radioButtonButton.Checked)
			{
				block.Condition = ProgramModule.BlockWaitCondition.CONDITION.BUTTON;
				return;
			}
			if (this.radioButtonLightBright.Checked)
			{
				block.Condition = ProgramModule.BlockWaitCondition.CONDITION.LIGHT;
				block.Light = ProgramModule.BlockWaitCondition.LIGHT.BRIGHT;
				return;
			}
			if (this.radioButtonLightDark.Checked)
			{
				block.Condition = ProgramModule.BlockWaitCondition.CONDITION.LIGHT;
				block.Light = ProgramModule.BlockWaitCondition.LIGHT.DARK;
				return;
			}
			if (this.radioButtonSound.Checked)
			{
				block.Condition = ProgramModule.BlockWaitCondition.CONDITION.SOUND;
				return;
			}
			if (this.radioButtonAlarm.Checked)
			{
				block.Condition = ProgramModule.BlockWaitCondition.CONDITION.ALARM;
				return;
			}
			if (this.radioButtonTimer.Checked)
			{
				block.Condition = ProgramModule.BlockWaitCondition.CONDITION.TIMER;
				return;
			}
			if (this.radioButtonTime.Checked)
			{
				block.Condition = ProgramModule.BlockWaitCondition.CONDITION.TIME;
				block.Hour = (int)this.numericUpDownHour.Value;
				block.Minute = (int)this.numericUpDownMinute.Value;
				return;
			}
			if (this.radioButtonTemperature.Checked)
			{
				block.Condition = ProgramModule.BlockWaitCondition.CONDITION.TEMPERATURE;
				block.Temperature = (int)this.numericUpDownTemperature.Value;
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0001A1C4 File Offset: 0x000183C4
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0001A1E3 File Offset: 0x000183E3
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0001A1F5 File Offset: 0x000183F5
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0001A207 File Offset: 0x00018407
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyWaitConditionDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0001A22C File Offset: 0x0001842C
		private void radioButtonButton_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownHour.Enabled = false;
			this.numericUpDownMinute.Enabled = false;
			this.numericUpDownTemperature.Enabled = false;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0001A22C File Offset: 0x0001842C
		private void radioButtonLightBright_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownHour.Enabled = false;
			this.numericUpDownMinute.Enabled = false;
			this.numericUpDownTemperature.Enabled = false;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0001A22C File Offset: 0x0001842C
		private void radioButtonLightDark_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownHour.Enabled = false;
			this.numericUpDownMinute.Enabled = false;
			this.numericUpDownTemperature.Enabled = false;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0001A22C File Offset: 0x0001842C
		private void radioButtonSound_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownHour.Enabled = false;
			this.numericUpDownMinute.Enabled = false;
			this.numericUpDownTemperature.Enabled = false;
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0001A22C File Offset: 0x0001842C
		private void radioButtonAlarm_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownHour.Enabled = false;
			this.numericUpDownMinute.Enabled = false;
			this.numericUpDownTemperature.Enabled = false;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0001A22C File Offset: 0x0001842C
		private void radioButtonTimer_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownHour.Enabled = false;
			this.numericUpDownMinute.Enabled = false;
			this.numericUpDownTemperature.Enabled = false;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0001A252 File Offset: 0x00018452
		private void radioButtonTime_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownHour.Enabled = true;
			this.numericUpDownMinute.Enabled = true;
			this.numericUpDownTemperature.Enabled = false;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0001A278 File Offset: 0x00018478
		private void radioButtonTemperature_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownHour.Enabled = false;
			this.numericUpDownMinute.Enabled = false;
			this.numericUpDownTemperature.Enabled = true;
		}

		// Token: 0x040001DF RID: 479
		private ProgramModule.BlockWaitCondition _block;

		// Token: 0x040001E0 RID: 480
		private int _costMax;
	}
}
