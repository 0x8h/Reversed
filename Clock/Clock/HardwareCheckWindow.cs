using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000023 RID: 35
	public partial class HardwareCheckWindow : Form
	{
		// Token: 0x06000364 RID: 868 RVA: 0x0002D3E0 File Offset: 0x0002B5E0
		public HardwareCheckWindow()
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			CommunicationModule.Instance.checkVersion();
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0002D414 File Offset: 0x0002B614
		private void enabledControls()
		{
			this._connectFlag = true;
			this.pictureBoxButtonLED.Image = (this._LEDFlag ? Resources.nw_btn_on : Resources.nw_btn_off);
			this.pictureBoxButtonSound.Image = Resources.mld_btn_010;
			this.pictureBoxButtonUsbOut.Image = (this._usbOutFlag ? Resources.nw_btn_on : Resources.nw_btn_off);
			this.radioButtonLEDRed.Enabled = true;
			this.radioButtonLEDGreen.Enabled = true;
			this.radioButtonLEDBlue.Enabled = true;
			this.hScrollBarUsbOut.Enabled = true;
			this.numericUpDownUsbOut.Enabled = true;
			this.pictureBoxConnectIcon.Image = Resources.popup_usb_on;
			this.connectWarningLabel.Text = "";
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0002D4D4 File Offset: 0x0002B6D4
		private void disabledControls()
		{
			this._connectFlag = false;
			this.pictureBoxButtonLED.Image = Resources.nw_btn_disable;
			this.pictureBoxButtonSound.Image = Resources.mld_btn_013;
			this.pictureBoxButtonUsbOut.Image = Resources.nw_btn_disable;
			this.radioButtonLEDRed.Enabled = false;
			this.radioButtonLEDGreen.Enabled = false;
			this.radioButtonLEDBlue.Enabled = false;
			this.hScrollBarUsbOut.Enabled = false;
			this.numericUpDownUsbOut.Enabled = false;
			if (CommunicationModule.Instance.Connected)
			{
				this.connectWarningLabel.Text = "本体とソフトウェアのバージョンが異なっています";
				this.pictureBoxConnectIcon.Image = Resources.popup_usb_on;
			}
			else
			{
				this.connectWarningLabel.Text = "本体をコンピュータに接続してください";
				this.pictureBoxConnectIcon.Image = Resources.popup_usb_off;
			}
			this.labelTopButton.Text = "-";
			this.labelLight.Text = "-";
			this.labelLightValue.Text = "-";
			this.labelSound.Text = "-";
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0002D5E4 File Offset: 0x0002B7E4
		private void updateHardwareInfo()
		{
			CommunicationModule.HardwareInfo hardwareInfo = CommunicationModule.Instance.getHardwareInfo();
			this.labelTopButton.Text = (hardwareInfo.IsButtonOn ? "ON" : "OFF");
			this.labelLight.Text = (hardwareInfo.IsBright ? "明るい" : "暗い");
			this.labelLightValue.Text = hardwareInfo.LightValue.ToString();
			this.labelSound.Text = (hardwareInfo.IsSoundOn ? "あり" : "なし");
			this.labelUsbIn.Text = (hardwareInfo.IsUsbInOn ? "あり" : "なし");
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0002D68F File Offset: 0x0002B88F
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (CommunicationModule.Instance.Connected && CommunicationModule.Instance.IsCorrectVersion)
			{
				this.enabledControls();
				this.updateHardwareInfo();
				return;
			}
			this.disabledControls();
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0002D6BC File Offset: 0x0002B8BC
		private void pictureBoxButtonLED_MouseClick(object sender, MouseEventArgs e)
		{
			this._LEDFlag = !this._LEDFlag;
			if (!this._LEDFlag)
			{
				this.pictureBoxButtonLED.Image = Resources.nw_btn_off;
				CommunicationModule.Instance.setLEDOff();
				return;
			}
			this.pictureBoxButtonLED.Image = Resources.nw_btn_on;
			if (this.radioButtonLEDRed.Checked)
			{
				CommunicationModule.Instance.setLEDOn(Color.Red);
				return;
			}
			if (this.radioButtonLEDGreen.Checked)
			{
				CommunicationModule.Instance.setLEDOn(Color.Green);
				return;
			}
			CommunicationModule.Instance.setLEDOn(Color.Blue);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0002D758 File Offset: 0x0002B958
		private void radioButtonLEDRed_CheckedChanged(object sender, EventArgs e)
		{
			if (this._LEDFlag)
			{
				CommunicationModule.Instance.setLEDOn(Color.Red);
			}
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0002D772 File Offset: 0x0002B972
		private void radioButtonLEDGreen_CheckedChanged(object sender, EventArgs e)
		{
			if (this._LEDFlag)
			{
				CommunicationModule.Instance.setLEDOn(Color.Green);
			}
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0002D78C File Offset: 0x0002B98C
		private void radioButtonLEDBlue_CheckedChanged(object sender, EventArgs e)
		{
			if (this._LEDFlag)
			{
				CommunicationModule.Instance.setLEDOn(Color.Blue);
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0002D7A6 File Offset: 0x0002B9A6
		private void pictureBoxButtonSound_MouseDown(object sender, MouseEventArgs e)
		{
			if (this._connectFlag && e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonSound.Image = Resources.mld_btn_011;
			}
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0002D7CD File Offset: 0x0002B9CD
		private void pictureBoxButtonSound_MouseEnter(object sender, EventArgs e)
		{
			if (this._connectFlag)
			{
				this.pictureBoxButtonSound.Image = Resources.mld_btn_011;
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0002D7E7 File Offset: 0x0002B9E7
		private void pictureBoxButtonSound_MouseLeave(object sender, EventArgs e)
		{
			if (this._connectFlag)
			{
				this.pictureBoxButtonSound.Image = Resources.mld_btn_010;
			}
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0002D801 File Offset: 0x0002BA01
		private void pictureBoxButtonSound_MouseUp(object sender, MouseEventArgs e)
		{
			if (this._connectFlag && e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonSound.Image = Resources.mld_btn_012;
				CommunicationModule.Instance.playSE(0);
			}
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0002D834 File Offset: 0x0002BA34
		private void HardwareCheckWindow_Shown(object sender, EventArgs e)
		{
			base.Activate();
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0002D83C File Offset: 0x0002BA3C
		private void HardwareCheckWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			CommunicationModule.Instance.stopProgram(false);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0002D84C File Offset: 0x0002BA4C
		private void pictureBoxButtonUsbOut_MouseClick(object sender, MouseEventArgs e)
		{
			this._usbOutFlag = !this._usbOutFlag;
			if (this._usbOutFlag)
			{
				this.pictureBoxButtonUsbOut.Image = Resources.nw_btn_on;
				CommunicationModule.Instance.setUsbOutOn(this.hScrollBarUsbOut.Value);
				return;
			}
			this.pictureBoxButtonUsbOut.Image = Resources.nw_btn_off;
			CommunicationModule.Instance.setUsbOutOff();
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0002D8B2 File Offset: 0x0002BAB2
		private void hScrollBarUsbOut_ValueChanged(object sender, EventArgs e)
		{
			if (this.hScrollBarUsbOut.Value != this.numericUpDownUsbOut.Value)
			{
				this.numericUpDownUsbOut.Value = this.hScrollBarUsbOut.Value;
			}
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0002D8F1 File Offset: 0x0002BAF1
		private void numericUpDownUsbOut_ValueChanged(object sender, EventArgs e)
		{
			if (this.hScrollBarUsbOut.Value != this.numericUpDownUsbOut.Value)
			{
				this.hScrollBarUsbOut.Value = (int)this.numericUpDownUsbOut.Value;
			}
		}

		// Token: 0x040002C9 RID: 713
		private const string CONNECT_WARNING = "本体をコンピュータに接続してください";

		// Token: 0x040002CA RID: 714
		private const string VERSION_WARNING = "本体とソフトウェアのバージョンが異なっています";

		// Token: 0x040002CB RID: 715
		private bool _connectFlag;

		// Token: 0x040002CC RID: 716
		private bool _LEDFlag;

		// Token: 0x040002CD RID: 717
		private bool _usbOutFlag;
	}
}
