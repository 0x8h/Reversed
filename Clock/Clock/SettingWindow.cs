using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000051 RID: 81
	public partial class SettingWindow : Form
	{
		// Token: 0x06000893 RID: 2195 RVA: 0x00063274 File Offset: 0x00061474
		public SettingWindow()
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x000024F1 File Offset: 0x000006F1
		private void SettingWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0006329C File Offset: 0x0006149C
		private void updateSystemTime()
		{
			this.systemTime.Text = DateTime.Now.ToString("HH:mm");
			this.systemTimeSecond.Text = DateTime.Now.ToString(":ss");
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x000632E4 File Offset: 0x000614E4
		private void enabledControls()
		{
			this.pictureBoxButtonTime.Image = Resources.popup_btn_070;
			this.pictureBoxButtonAlerm.Image = Resources.popup_btn_070;
			this.pictureBoxButtonUpdate.Image = Resources.popup_btn_080;
			this.alermHour.Enabled = true;
			this.alermMinute.Enabled = true;
			this.pictureBoxConnectIcon.Image = Resources.popup_usb_on;
			this.connectWarningLabel.Text = "";
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0006335C File Offset: 0x0006155C
		private void disabledControls()
		{
			this.pictureBoxButtonTime.Image = Resources.popup_btn_073;
			this.pictureBoxButtonAlerm.Image = Resources.popup_btn_073;
			if (CommunicationModule.Instance.Connected)
			{
				this.pictureBoxButtonUpdate.Image = Resources.popup_btn_080;
			}
			else
			{
				this.pictureBoxButtonUpdate.Image = Resources.popup_btn_083;
			}
			this.alermHour.Enabled = false;
			this.alermMinute.Enabled = false;
			this.pictureBoxConnectIcon.Image = Resources.popup_usb_off;
			this.connectWarningLabel.Text = "本体をコンピュータに接続してください";
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x000633F0 File Offset: 0x000615F0
		private void updateFirmwere()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.Filter = "ファームウェアファイル(*.bin)|*.bin";
			openFileDialog.FilterIndex = 1;
			openFileDialog.Title = "ファームウェアファイルを選択してください";
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				CommunicationModule.Instance.updateFirmware(array);
			}
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00063472 File Offset: 0x00061672
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.updateSystemTime();
			if (CommunicationModule.Instance.Connected)
			{
				this.enabledControls();
				return;
			}
			this.disabledControls();
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x00063493 File Offset: 0x00061693
		private void pictureBoxButtonTime_MouseDown(object sender, MouseEventArgs e)
		{
			if (CommunicationModule.Instance.Connected && e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonTime.Image = Resources.popup_btn_071;
			}
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x000634BE File Offset: 0x000616BE
		private void pictureBoxButtonTime_MouseEnter(object sender, EventArgs e)
		{
			if (CommunicationModule.Instance.Connected)
			{
				this.pictureBoxButtonTime.Image = Resources.popup_btn_072;
			}
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x000634DC File Offset: 0x000616DC
		private void pictureBoxButtonTime_MouseLeave(object sender, EventArgs e)
		{
			if (CommunicationModule.Instance.Connected)
			{
				this.pictureBoxButtonTime.Image = Resources.popup_btn_070;
			}
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x000634FA File Offset: 0x000616FA
		private void pictureBoxButtonTime_MouseUp(object sender, MouseEventArgs e)
		{
			if (CommunicationModule.Instance.Connected && e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonTime.Image = Resources.popup_btn_072;
				CommunicationModule.Instance.setTime();
			}
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x00063530 File Offset: 0x00061730
		private void pictureBoxButtonAlerm_MouseDown(object sender, MouseEventArgs e)
		{
			if (CommunicationModule.Instance.Connected && e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonAlerm.Image = Resources.popup_btn_071;
			}
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x0006355B File Offset: 0x0006175B
		private void pictureBoxButtonAlerm_MouseEnter(object sender, EventArgs e)
		{
			if (CommunicationModule.Instance.Connected)
			{
				this.pictureBoxButtonAlerm.Image = Resources.popup_btn_072;
			}
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x00063579 File Offset: 0x00061779
		private void pictureBoxButtonAlerm_MouseLeave(object sender, EventArgs e)
		{
			if (CommunicationModule.Instance.Connected)
			{
				this.pictureBoxButtonAlerm.Image = Resources.popup_btn_070;
			}
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x00063598 File Offset: 0x00061798
		private void pictureBoxButtonAlerm_MouseUp(object sender, MouseEventArgs e)
		{
			if (CommunicationModule.Instance.Connected && e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonAlerm.Image = Resources.popup_btn_072;
				CommunicationModule.Instance.setAlarm((int)this.alermHour.Value, (int)this.alermMinute.Value);
			}
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x000635F9 File Offset: 0x000617F9
		private void pictureBoxButtonUpdate_MouseDown(object sender, MouseEventArgs e)
		{
			if (CommunicationModule.Instance.Connected && e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonUpdate.Image = Resources.popup_btn_081;
			}
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x00063624 File Offset: 0x00061824
		private void pictureBoxButtonUpdate_MouseEnter(object sender, EventArgs e)
		{
			if (CommunicationModule.Instance.Connected)
			{
				this.pictureBoxButtonUpdate.Image = Resources.popup_btn_082;
			}
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00063642 File Offset: 0x00061842
		private void pictureBoxButtonUpdate_MouseLeave(object sender, EventArgs e)
		{
			if (CommunicationModule.Instance.Connected)
			{
				this.pictureBoxButtonUpdate.Image = Resources.popup_btn_080;
			}
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00063660 File Offset: 0x00061860
		private void pictureBoxButtonUpdate_MouseUp(object sender, MouseEventArgs e)
		{
			if (CommunicationModule.Instance.Connected && e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonUpdate.Image = Resources.popup_btn_082;
				this.updateFirmwere();
			}
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x0002D834 File Offset: 0x0002BA34
		private void SettingWindow_Shown(object sender, EventArgs e)
		{
			base.Activate();
		}

		// Token: 0x0400064D RID: 1613
		private const string CONNECT_WARNING = "本体をコンピュータに接続してください";

		// Token: 0x0400064E RID: 1614
		private const string VERSION_WARNING = "本体とソフトウェアのバージョンが異なっています";
	}
}
