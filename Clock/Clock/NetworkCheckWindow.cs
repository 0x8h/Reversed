using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000031 RID: 49
	public partial class NetworkCheckWindow : Form
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x00043AC7 File Offset: 0x00041CC7
		public static NetworkCheckWindow Instance
		{
			get
			{
				return NetworkCheckWindow._instance;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x00043ACE File Offset: 0x00041CCE
		public IPAddress IpAddress { get; }

		// Token: 0x06000594 RID: 1428 RVA: 0x00043AD8 File Offset: 0x00041CD8
		public NetworkCheckWindow()
		{
			NetworkCheckWindow._instance = this;
			this.IpAddress = this.getMyIPAddress();
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			IPAddress myIPAddress = this.getMyIPAddress();
			this.labelIP.Text = "IPアドレス: " + ((myIPAddress == null) ? "不明" : myIPAddress.ToString());
			this.labelSender.Text = "";
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00043B59 File Offset: 0x00041D59
		private void NetworkCheckWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			NetworkCheckWindow._instance = null;
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00043B61 File Offset: 0x00041D61
		private void pictureBoxButtonCheck_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCheck.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00043B80 File Offset: 0x00041D80
		private void pictureBoxButtonCheck_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCheck.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00043B92 File Offset: 0x00041D92
		private void pictureBoxButtonCheck_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCheck.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00043BA4 File Offset: 0x00041DA4
		private void pictureBoxButtonCheck_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCheck.Image = Resources.popup_btn_001;
				if (Client.isConnect() && !this._clicked)
				{
					this._clicked = true;
					this.labelSender.Text = "";
					string text = "connectCheck,";
					IPAddress ipAddress = this.IpAddress;
					Client.send(text + ((ipAddress != null) ? ipAddress.ToString() : null));
					this.setLabel("送信OK", "");
				}
			}
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00043C28 File Offset: 0x00041E28
		private IPAddress getMyIPAddress()
		{
			foreach (IPAddress ipaddress in Dns.GetHostAddresses(Dns.GetHostName()))
			{
				if (ipaddress.AddressFamily == AddressFamily.InterNetwork)
				{
					return ipaddress;
				}
			}
			return null;
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x00043C5E File Offset: 0x00041E5E
		public void setLabel(string message, string senderIP = "")
		{
			this.label1.Text = message;
			this.label1.Visible = true;
			if (senderIP.Length > 0)
			{
				this.labelSender.Text = "送信者:" + senderIP;
			}
			this._clicked = false;
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x00043C9E File Offset: 0x00041E9E
		private void pictureBoxButtonReset_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonReset.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00043CC0 File Offset: 0x00041EC0
		private void pictureBoxButtonReset_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonReset.Image = Resources.popup_btn_011;
				this.label1.Visible = false;
				this.labelSender.Text = "";
				this._clicked = false;
			}
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x00043D0D File Offset: 0x00041F0D
		private void pictureBoxButtonReset_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonReset.Image = Resources.popup_btn_011;
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x00043D1F File Offset: 0x00041F1F
		private void pictureBoxButtonReset_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonReset.Image = Resources.popup_btn_010;
		}

		// Token: 0x04000465 RID: 1125
		private static NetworkCheckWindow _instance;

		// Token: 0x04000466 RID: 1126
		private bool _clicked;
	}
}
