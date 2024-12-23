using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Token: 0x0200000E RID: 14
public class GClass2
{
	// Token: 0x06000040 RID: 64
	[DllImport("ntdll.dll", SetLastError = true)]
	public static extern int NtSetInformationProcess(IntPtr intptr_0, int int_19, ref int int_20, int int_21);

	// Token: 0x06000041 RID: 65
	[DllImport("gdi32.dll")]
	public static extern IntPtr CreateEllipticRgn(int int_19, int int_20, int int_21, int int_22);

	// Token: 0x06000042 RID: 66
	[DllImport("gdi32.dll")]
	public static extern int SelectClipRgn(IntPtr intptr_0, IntPtr intptr_1);

	// Token: 0x06000043 RID: 67
	[DllImport("Shell32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
	public static extern int ExtractIconExW(string string_1, int int_19, out IntPtr intptr_0, out IntPtr intptr_1, int int_20);

	// Token: 0x06000044 RID: 68
	[DllImport("kernel32")]
	public static extern IntPtr CreateFile(string string_1, uint uint_22, uint uint_23, IntPtr intptr_0, uint uint_24, uint uint_25, IntPtr intptr_1);

	// Token: 0x06000045 RID: 69
	[DllImport("kernel32")]
	public static extern bool WriteFile(IntPtr intptr_0, byte[] byte_0, uint uint_22, out uint uint_23, IntPtr intptr_1);

	// Token: 0x06000046 RID: 70
	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetCursorPos(int int_19, int int_20);

	// Token: 0x06000047 RID: 71
	[DllImport("user32.dll")]
	public static extern void mouse_event(uint uint_22, int int_19, int int_20, uint uint_23, UIntPtr uintptr_0);

	// Token: 0x06000048 RID: 72
	[DllImport("gdi32.dll")]
	private static extern IntPtr CreatePen(GClass2.Enum4 enum4_0, int int_19, uint uint_22);

	// Token: 0x06000049 RID: 73
	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr GetDC(IntPtr intptr_0);

	// Token: 0x0600004A RID: 74
	[DllImport("gdi32.dll", SetLastError = true)]
	public static extern IntPtr CreateCompatibleDC(IntPtr intptr_0);

	// Token: 0x0600004B RID: 75
	[DllImport("gdi32.dll")]
	public static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);

	// Token: 0x0600004C RID: 76
	[DllImport("gdi32.dll")]
	private static extern bool MoveToEx(IntPtr intptr_0, int int_19, int int_20, IntPtr intptr_1);

	// Token: 0x0600004D RID: 77
	[DllImport("gdi32.dll", SetLastError = true)]
	private static extern bool MaskBlt(IntPtr intptr_0, int int_19, int int_20, int int_21, int int_22, IntPtr intptr_1, int int_23, int int_24, IntPtr intptr_2, int int_25, int int_26, uint uint_22);

	// Token: 0x0600004E RID: 78
	[DllImport("gdi32.dll")]
	private static extern bool LineTo(IntPtr intptr_0, int int_19, int int_20);

	// Token: 0x0600004F RID: 79
	[DllImport("gdi32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteObject(IntPtr intptr_0);

	// Token: 0x06000050 RID: 80
	[DllImport("gdi32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BitBlt(IntPtr intptr_0, int int_19, int int_20, int int_21, int int_22, IntPtr intptr_1, int int_23, int int_24, GClass2.GEnum3 genum3_0);

	// Token: 0x06000051 RID: 81
	[DllImport("gdi32.dll")]
	public static extern bool StretchBlt(IntPtr intptr_0, int int_19, int int_20, int int_21, int int_22, IntPtr intptr_1, int int_23, int int_24, int int_25, int int_26, GClass2.GEnum3 genum3_0);

	// Token: 0x06000052 RID: 82
	[DllImport("gdi32.dll")]
	public static extern bool PlgBlt(IntPtr intptr_0, GClass2.GStruct4[] gstruct4_0, IntPtr intptr_1, int int_19, int int_20, int int_21, int int_22, IntPtr intptr_2, int int_23, int int_24);

	// Token: 0x06000053 RID: 83
	[DllImport("gdi32.dll")]
	public static extern bool PatBlt(IntPtr intptr_0, int int_19, int int_20, int int_21, int int_22, GClass2.GEnum3 genum3_0);

	// Token: 0x06000054 RID: 84
	[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr Ellipse(IntPtr intptr_0, int int_19, int int_20, int int_21, int int_22);

	// Token: 0x06000055 RID: 85
	[DllImport("gdi32.dll")]
	public static extern bool GdiAlphaBlend(IntPtr intptr_0, int int_19, int int_20, int int_21, int int_22, IntPtr intptr_1, int int_23, int int_24, int int_25, int int_26, GClass2.GStruct5 gstruct5_0);

	// Token: 0x06000056 RID: 86
	[DllImport("gdi32.dll")]
	public static extern IntPtr CreateSolidBrush(uint uint_22);

	// Token: 0x06000057 RID: 87
	[DllImport("gdi32.dll")]
	public static extern IntPtr CreateBitmap(int int_19, int int_20, uint uint_22, uint uint_23, byte[] byte_0);

	// Token: 0x06000058 RID: 88
	[DllImport("gdi32.dll")]
	public static extern bool DeleteDC(IntPtr intptr_0);

	// Token: 0x06000059 RID: 89
	[DllImport("gdi32.dll")]
	private static extern bool FloodFill(IntPtr intptr_0, int int_19, int int_20, uint uint_22);

	// Token: 0x0600005A RID: 90
	[DllImport("gdi32.dll", ExactSpelling = true)]
	public static extern bool GdiGradientFill(IntPtr intptr_0, GClass2.GStruct7[] gstruct7_0, uint uint_22, GClass2.GStruct6[] gstruct6_0, uint uint_23, GClass2.GEnum4 genum4_0);

	// Token: 0x0600005B RID: 91
	[DllImport("user32.dll")]
	public static extern IntPtr GetDesktopWindow();

	// Token: 0x0600005C RID: 92
	[DllImport("user32.dll")]
	public static extern IntPtr GetWindowDC(IntPtr intptr_0);

	// Token: 0x0600005D RID: 93
	[DllImport("user32.dll")]
	public static extern bool InvalidateRect(IntPtr intptr_0, IntPtr intptr_1, bool bool_0);

	// Token: 0x0600005E RID: 94
	[DllImport("User32.dll")]
	private static extern int ReleaseDC(IntPtr intptr_0, IntPtr intptr_1);

	// Token: 0x0600005F RID: 95
	[DllImport("gdi32.dll")]
	private static extern bool FillRgn(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2);

	// Token: 0x06000060 RID: 96
	[DllImport("gdi32.dll")]
	private static extern IntPtr CreateRectRgn(int int_19, int int_20, int int_21, int int_22);

	// Token: 0x06000061 RID: 97
	[DllImport("gdi32.dll")]
	private static extern bool Pie(IntPtr intptr_0, int int_19, int int_20, int int_21, int int_22, int int_23, int int_24, int int_25, int int_26);

	// Token: 0x06000062 RID: 98
	[DllImport("gdi32.dll")]
	public static extern IntPtr CreateCompatibleBitmap(IntPtr intptr_0, int int_19, int int_20);

	// Token: 0x06000063 RID: 99
	[DllImport("gdi32.dll")]
	private static extern bool Rectangle(IntPtr intptr_0, int int_19, int int_20, int int_21, int int_22);

	// Token: 0x06000064 RID: 100
	[DllImport("gdi32.dll")]
	public static extern uint SetPixel(IntPtr intptr_0, int int_19, int int_20, uint uint_22);

	// Token: 0x06000065 RID: 101
	[DllImport("gdi32.dll")]
	private static extern IntPtr GetPixel(IntPtr intptr_0, int int_19, int int_20);

	// Token: 0x06000066 RID: 102
	[DllImport("gdi32.dll")]
	private static extern bool AngleArc(IntPtr intptr_0, int int_19, int int_20, uint uint_22, float float_0, float float_1);

	// Token: 0x06000067 RID: 103
	[DllImport("gdi32.dll")]
	private static extern bool RoundRect(IntPtr intptr_0, int int_19, int int_20, int int_21, int int_22, int int_23, int int_24);

	// Token: 0x06000068 RID: 104
	[DllImport("gdi32.dll")]
	private static extern bool DeleteMetaFile(IntPtr intptr_0);

	// Token: 0x06000069 RID: 105
	[DllImport("gdi32.dll")]
	private static extern bool CancelDC(IntPtr intptr_0);

	// Token: 0x0600006A RID: 106
	[DllImport("gdi32.dll")]
	private static extern bool Polygon(IntPtr intptr_0, GClass2.GStruct4[] gstruct4_0, int int_19);

	// Token: 0x0600006B RID: 107
	[DllImport("gdi32.dll")]
	public static extern int SetBitmapBits(IntPtr intptr_0, int int_19, byte[] byte_0);

	// Token: 0x0600006C RID: 108
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool Beep(uint uint_22, uint uint_23);

	// Token: 0x0600006D RID: 109
	[DllImport("user32.dll")]
	private static extern bool BlockInput(bool bool_0);

	// Token: 0x0600006E RID: 110
	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr LoadImage(IntPtr intptr_0, string string_1, uint uint_22, int int_19, int int_20, uint uint_23);

	// Token: 0x0600006F RID: 111
	[DllImport("user32.dll", SetLastError = true)]
	private static extern int DestroyIcon(IntPtr intptr_0);

	// Token: 0x06000070 RID: 112
	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr LoadLibraryEx(IntPtr intptr_0, IntPtr intptr_1, GClass2.Enum3 enum3_0);

	// Token: 0x06000071 RID: 113
	[DllImport("user32.dll")]
	private static extern IntPtr LoadBitmap(IntPtr intptr_0, string string_1);

	// Token: 0x06000072 RID: 114
	[DllImport("user32.dll")]
	private static extern IntPtr BeginPaint(IntPtr intptr_0, out GClass2.Struct5 struct5_0);

	// Token: 0x06000073 RID: 115
	[DllImport("user32.dll")]
	private static extern bool EndPaint(IntPtr intptr_0, out GClass2.Struct5 struct5_0);

	// Token: 0x06000074 RID: 116
	[DllImport("gdi32.dll")]
	private static extern int SetStretchBltMode(IntPtr intptr_0, GClass2.Enum2 enum2_0);

	// Token: 0x06000075 RID: 117
	[DllImport("gdi32.dll")]
	private static extern int StretchDIBits(IntPtr intptr_0, int int_19, int int_20, int int_21, int int_22, int int_23, int int_24, int int_25, int int_26, GClass2.GStruct9 gstruct9_0, [In] ref GClass2.GStruct1 gstruct1_0, GClass2.Enum1 enum1_0, GClass2.GEnum3 genum3_0);

	// Token: 0x06000076 RID: 118
	[DllImport("gdi32.dll")]
	public static extern bool SetDeviceGammaRamp(IntPtr intptr_0, ref GClass2.GStruct0 gstruct0_0);

	// Token: 0x06000077 RID: 119
	[DllImport("Gdi32")]
	public static extern long GetBitmapBits([In] IntPtr intptr_0, [In] int int_19, byte[] byte_0);

	// Token: 0x06000078 RID: 120
	[DllImport("gdi32.dll")]
	public static extern IntPtr CreateHatchBrush(int int_19, uint uint_22);

	// Token: 0x06000079 RID: 121
	[DllImport("gdi32.dll")]
	public static extern IntPtr CreatePatternBrush(IntPtr intptr_0);

	// Token: 0x0600007A RID: 122
	[DllImport("gdi32.dll")]
	public static extern IntPtr CreateDIBitmap(IntPtr intptr_0, [In] ref GClass2.GStruct2 gstruct2_0, uint uint_22, byte[] byte_0, [In] ref GClass2.GStruct1 gstruct1_0, uint uint_23);

	// Token: 0x0600007B RID: 123
	[DllImport("gdi32.dll")]
	private static extern int SetDIBitsToDevice(IntPtr intptr_0, int int_19, int int_20, uint uint_22, uint uint_23, int int_21, int int_22, uint uint_24, uint uint_25, byte[] byte_0, [In] ref GClass2.GStruct1 gstruct1_0, uint uint_26);

	// Token: 0x0600007C RID: 124
	[DllImport("gdi32.dll")]
	private static extern IntPtr SetDIBits(IntPtr intptr_0, IntPtr intptr_1, uint uint_22, int int_19, int int_20, [In] ref GClass2.GStruct1 gstruct1_0, GClass2.Enum1 enum1_0);

	// Token: 0x0600007D RID: 125
	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern bool SetWindowText(IntPtr intptr_0, string string_1);

	// Token: 0x0600007E RID: 126
	[DllImport("user32.dll")]
	public static extern IntPtr GetTopWindow(IntPtr intptr_0);

	// Token: 0x0600007F RID: 127
	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr GetWindow(IntPtr intptr_0, GClass2.GEnum2 genum2_0);

	// Token: 0x06000080 RID: 128
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern void MoveWindow(IntPtr intptr_0, int int_19, int int_20, int int_21, int int_22, bool bool_0);

	// Token: 0x06000081 RID: 129
	[DllImport("user32.dll")]
	private static extern IntPtr GetForegroundWindow();

	// Token: 0x06000082 RID: 130
	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool GetWindowRect(IntPtr intptr_0, out GClass2.GStruct3 gstruct3_0);

	// Token: 0x06000083 RID: 131
	[DllImport("gdi32.dll")]
	public static extern uint SetBkColor(IntPtr intptr_0, uint uint_22);

	// Token: 0x06000084 RID: 132
	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr FindWindow(string string_1, string string_2);

	// Token: 0x06000085 RID: 133
	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr FindWindowEx(IntPtr intptr_0, IntPtr intptr_1, string string_1, string string_2);

	// Token: 0x06000086 RID: 134
	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr VirtualAllocEx(IntPtr intptr_0, IntPtr intptr_1, uint uint_22, uint uint_23, uint uint_24);

	// Token: 0x06000087 RID: 135
	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr SendMessage(IntPtr intptr_0, uint uint_22, IntPtr intptr_1, IntPtr intptr_2);

	// Token: 0x06000088 RID: 136 RVA: 0x000026EA File Offset: 0x000008EA
	public static IntPtr smethod_0(int int_19, int int_20)
	{
		return (IntPtr)(((int)((short)int_20) << 16) | (int_19 & 65535));
	}

	// Token: 0x06000089 RID: 137 RVA: 0x000047D4 File Offset: 0x000029D4
	public static string smethod_1()
	{
		int num = 65;
		int num2 = 122;
		int num3 = 14;
		Random random = new Random(DateTime.Now.Millisecond);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < num3; i++)
		{
			stringBuilder.Append((char)(random.Next(num, num2 + 1) % 255));
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00004838 File Offset: 0x00002A38
	public static string smethod_2()
	{
		Random random = new Random();
		string text = string.Empty;
		for (int i = 0; i < 8; i++)
		{
			text += random.Next(0, int.MaxValue).ToString("X8");
		}
		return text;
	}

	// Token: 0x0600008B RID: 139 RVA: 0x00004880 File Offset: 0x00002A80
	public static string smethod_3(int int_19)
	{
		Random random = new Random();
		char[] array = "0123456789abcdef".ToArray<char>();
		string text = "";
		for (int i = 0; i < int_19; i++)
		{
			int num = random.Next(0, array.Length);
			text += array[num].ToString();
		}
		return text;
	}

	// Token: 0x0600008C RID: 140
	[DllImport("user32.dll")]
	public static extern bool SetWindowPos(int int_19, int int_20, short short_0, short short_1, short short_2, short short_3, uint uint_22);

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x0600008D RID: 141 RVA: 0x000026FE File Offset: 0x000008FE
	// (set) Token: 0x0600008E RID: 142 RVA: 0x00002705 File Offset: 0x00000905
	public static object Object_0 { get; internal set; }

	// Token: 0x0400002C RID: 44
	public static int int_0 = 1;

	// Token: 0x0400002D RID: 45
	public static int int_1 = 29;

	// Token: 0x0400002E RID: 46
	public const uint uint_0 = 2147483648U;

	// Token: 0x0400002F RID: 47
	public const uint uint_1 = 1073741824U;

	// Token: 0x04000030 RID: 48
	public const uint uint_2 = 536870912U;

	// Token: 0x04000031 RID: 49
	public const uint uint_3 = 268435456U;

	// Token: 0x04000032 RID: 50
	public const uint uint_4 = 1U;

	// Token: 0x04000033 RID: 51
	public const uint uint_5 = 2U;

	// Token: 0x04000034 RID: 52
	public const uint uint_6 = 3U;

	// Token: 0x04000035 RID: 53
	public const uint uint_7 = 1073741824U;

	// Token: 0x04000036 RID: 54
	public const uint uint_8 = 512U;

	// Token: 0x04000037 RID: 55
	public const uint uint_9 = 32768U;

	// Token: 0x04000038 RID: 56
	public const uint uint_10 = 2U;

	// Token: 0x04000039 RID: 57
	public const uint uint_11 = 4U;

	// Token: 0x0400003A RID: 58
	public const uint uint_12 = 32U;

	// Token: 0x0400003B RID: 59
	public const uint uint_13 = 64U;

	// Token: 0x0400003C RID: 60
	public const uint uint_14 = 1U;

	// Token: 0x0400003D RID: 61
	public const uint uint_15 = 8U;

	// Token: 0x0400003E RID: 62
	public const uint uint_16 = 16U;

	// Token: 0x0400003F RID: 63
	public const uint uint_17 = 128U;

	// Token: 0x04000040 RID: 64
	public const uint uint_18 = 256U;

	// Token: 0x04000041 RID: 65
	public const uint uint_19 = 2048U;

	// Token: 0x04000042 RID: 66
	public const uint uint_20 = 4096U;

	// Token: 0x04000043 RID: 67
	public const int int_2 = 0;

	// Token: 0x04000044 RID: 68
	public const int int_3 = 1;

	// Token: 0x04000045 RID: 69
	public const int int_4 = 4;

	// Token: 0x04000046 RID: 70
	public const int int_5 = 8;

	// Token: 0x04000047 RID: 71
	public const int int_6 = 16;

	// Token: 0x04000048 RID: 72
	public const int int_7 = 32;

	// Token: 0x04000049 RID: 73
	public const int int_8 = 64;

	// Token: 0x0400004A RID: 74
	public const int int_9 = 128;

	// Token: 0x0400004B RID: 75
	public const int int_10 = 4096;

	// Token: 0x0400004C RID: 76
	public const int int_11 = 8192;

	// Token: 0x0400004D RID: 77
	public const int int_12 = 16384;

	// Token: 0x0400004E RID: 78
	public const int int_13 = 32768;

	// Token: 0x0400004F RID: 79
	private const int int_14 = 0;

	// Token: 0x04000050 RID: 80
	private const int int_15 = 1;

	// Token: 0x04000051 RID: 81
	public const uint uint_21 = 4111U;

	// Token: 0x04000052 RID: 82
	public const string string_0 = "0123456789abcdef";

	// Token: 0x04000053 RID: 83
	public const int int_16 = 128;

	// Token: 0x04000054 RID: 84
	public const int int_17 = 64;

	// Token: 0x04000055 RID: 85
	public static int int_18 = (int)GClass2.FindWindow("Shell_traywnd", "");

	// Token: 0x04000056 RID: 86
	[CompilerGenerated]
	private static object object_0;

	// Token: 0x0200000F RID: 15
	public enum GEnum0 : uint
	{
		// Token: 0x04000058 RID: 88
		LEFTDOWN = 2U,
		// Token: 0x04000059 RID: 89
		LEFTUP = 4U,
		// Token: 0x0400005A RID: 90
		MIDDLEDOWN = 32U,
		// Token: 0x0400005B RID: 91
		MIDDLEUP = 64U,
		// Token: 0x0400005C RID: 92
		MOVE = 1U,
		// Token: 0x0400005D RID: 93
		ABSOLUTE = 32768U,
		// Token: 0x0400005E RID: 94
		RIGHTDOWN = 8U,
		// Token: 0x0400005F RID: 95
		RIGHTUP = 16U,
		// Token: 0x04000060 RID: 96
		WHEEL = 2048U,
		// Token: 0x04000061 RID: 97
		XDOWN = 128U,
		// Token: 0x04000062 RID: 98
		XUP = 256U
	}

	// Token: 0x02000010 RID: 16
	public enum GEnum1 : uint
	{
		// Token: 0x04000064 RID: 100
		XBUTTON1 = 1U,
		// Token: 0x04000065 RID: 101
		XBUTTON2
	}

	// Token: 0x02000011 RID: 17
	public struct GStruct0
	{
		// Token: 0x04000066 RID: 102
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public ushort[] ushort_0;

		// Token: 0x04000067 RID: 103
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public ushort[] ushort_1;

		// Token: 0x04000068 RID: 104
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public ushort[] ushort_2;
	}

	// Token: 0x02000012 RID: 18
	public enum GEnum2 : uint
	{
		// Token: 0x0400006A RID: 106
		GW_HWNDFIRST,
		// Token: 0x0400006B RID: 107
		GW_HWNDLAST,
		// Token: 0x0400006C RID: 108
		GW_HWNDNEXT,
		// Token: 0x0400006D RID: 109
		GW_HWNDPREV,
		// Token: 0x0400006E RID: 110
		GW_OWNER,
		// Token: 0x0400006F RID: 111
		GW_CHILD,
		// Token: 0x04000070 RID: 112
		GW_ENABLEDPOPUP
	}

	// Token: 0x02000013 RID: 19
	public struct GStruct1
	{
		// Token: 0x04000071 RID: 113
		public GClass2.GStruct2 gstruct2_0;

		// Token: 0x04000072 RID: 114
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
		public GClass2.GStruct9[] gstruct9_0;
	}

	// Token: 0x02000014 RID: 20
	public struct GStruct2
	{
		// Token: 0x06000091 RID: 145 RVA: 0x00002735 File Offset: 0x00000935
		public void method_0()
		{
			this.uint_0 = (uint)GClass2.GStruct2.smethod_0(this);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000274D File Offset: 0x0000094D
		static int smethod_0(object object_0)
		{
			return Marshal.SizeOf(object_0);
		}

		// Token: 0x04000073 RID: 115
		public uint uint_0;

		// Token: 0x04000074 RID: 116
		public int int_0;

		// Token: 0x04000075 RID: 117
		public int int_1;

		// Token: 0x04000076 RID: 118
		public ushort ushort_0;

		// Token: 0x04000077 RID: 119
		public ushort ushort_1;

		// Token: 0x04000078 RID: 120
		public uint uint_1;

		// Token: 0x04000079 RID: 121
		public int int_2;

		// Token: 0x0400007A RID: 122
		public int int_3;

		// Token: 0x0400007B RID: 123
		public uint uint_2;

		// Token: 0x0400007C RID: 124
		public uint uint_3;

		// Token: 0x0400007D RID: 125
		public uint uint_4;
	}

	// Token: 0x02000015 RID: 21
	private enum Enum0 : uint
	{
		// Token: 0x0400007F RID: 127
		BI_RGB,
		// Token: 0x04000080 RID: 128
		BI_RLE8,
		// Token: 0x04000081 RID: 129
		BI_RLE4,
		// Token: 0x04000082 RID: 130
		BI_BITFIELDS,
		// Token: 0x04000083 RID: 131
		BI_JPEG,
		// Token: 0x04000084 RID: 132
		BI_PNG
	}

	// Token: 0x02000016 RID: 22
	private enum Enum1 : uint
	{
		// Token: 0x04000086 RID: 134
		DIB_RGB_COLORS,
		// Token: 0x04000087 RID: 135
		DIB_PAL_COLORS
	}

	// Token: 0x02000017 RID: 23
	private enum Enum2
	{
		// Token: 0x04000089 RID: 137
		STRETCH_ANDSCANS = 1,
		// Token: 0x0400008A RID: 138
		STRETCH_ORSCANS,
		// Token: 0x0400008B RID: 139
		STRETCH_DELETESCANS,
		// Token: 0x0400008C RID: 140
		STRETCH_HALFTONE
	}

	// Token: 0x02000018 RID: 24
	private struct Struct5
	{
		// Token: 0x0400008D RID: 141
		public IntPtr intptr_0;

		// Token: 0x0400008E RID: 142
		public bool bool_0;

		// Token: 0x0400008F RID: 143
		public GClass2.GStruct3 gstruct3_0;

		// Token: 0x04000090 RID: 144
		public bool bool_1;

		// Token: 0x04000091 RID: 145
		public bool bool_2;

		// Token: 0x04000092 RID: 146
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public byte[] byte_0;
	}

	// Token: 0x02000019 RID: 25
	public struct GStruct3
	{
		// Token: 0x06000093 RID: 147 RVA: 0x00002755 File Offset: 0x00000955
		public GStruct3(int left, int top, int right, int bottom)
		{
			this.int_0 = left;
			this.int_1 = top;
			this.int_2 = right;
			this.int_3 = bottom;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00002774 File Offset: 0x00000974
		public GStruct3(Rectangle r)
		{
			this = new GClass2.GStruct3(r.Left, r.Top, r.Right, r.Bottom);
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00002798 File Offset: 0x00000998
		// (set) Token: 0x06000096 RID: 150 RVA: 0x000027A0 File Offset: 0x000009A0
		public int Int32_0
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_2 -= this.int_0 - value;
				this.int_0 = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000097 RID: 151 RVA: 0x000027BE File Offset: 0x000009BE
		// (set) Token: 0x06000098 RID: 152 RVA: 0x000027C6 File Offset: 0x000009C6
		public int Int32_1
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_3 -= this.int_1 - value;
				this.int_1 = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000099 RID: 153 RVA: 0x000027E4 File Offset: 0x000009E4
		// (set) Token: 0x0600009A RID: 154 RVA: 0x000027F3 File Offset: 0x000009F3
		public int Int32_2
		{
			get
			{
				return this.int_3 - this.int_1;
			}
			set
			{
				this.int_3 = value + this.int_1;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00002803 File Offset: 0x00000A03
		// (set) Token: 0x0600009C RID: 156 RVA: 0x00002812 File Offset: 0x00000A12
		public int Int32_3
		{
			get
			{
				return this.int_2 - this.int_0;
			}
			set
			{
				this.int_2 = value + this.int_0;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00002822 File Offset: 0x00000A22
		// (set) Token: 0x0600009E RID: 158 RVA: 0x00002835 File Offset: 0x00000A35
		public Point Point_0
		{
			get
			{
				return new Point(this.int_0, this.int_1);
			}
			set
			{
				this.Int32_0 = value.X;
				this.Int32_1 = value.Y;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00002851 File Offset: 0x00000A51
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x00002864 File Offset: 0x00000A64
		public Size Size_0
		{
			get
			{
				return new Size(this.Int32_3, this.Int32_2);
			}
			set
			{
				this.Int32_3 = value.Width;
				this.Int32_2 = value.Height;
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002880 File Offset: 0x00000A80
		public static Rectangle smethod_0(GClass2.GStruct3 gstruct3_0)
		{
			return new Rectangle(gstruct3_0.int_0, gstruct3_0.int_1, gstruct3_0.Int32_3, gstruct3_0.Int32_2);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000028A1 File Offset: 0x00000AA1
		public static GClass2.GStruct3 smethod_1(Rectangle rectangle_0)
		{
			return new GClass2.GStruct3(rectangle_0);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000028A9 File Offset: 0x00000AA9
		public static bool smethod_2(GClass2.GStruct3 gstruct3_0, GClass2.GStruct3 gstruct3_1)
		{
			return gstruct3_0.method_0(gstruct3_1);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000028B3 File Offset: 0x00000AB3
		public static bool smethod_3(GClass2.GStruct3 gstruct3_0, GClass2.GStruct3 gstruct3_1)
		{
			return !gstruct3_0.method_0(gstruct3_1);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000028C0 File Offset: 0x00000AC0
		public bool method_0(GClass2.GStruct3 gstruct3_0)
		{
			return gstruct3_0.int_0 == this.int_0 && gstruct3_0.int_1 == this.int_1 && gstruct3_0.int_2 == this.int_2 && gstruct3_0.int_3 == this.int_3;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000028FC File Offset: 0x00000AFC
		public bool Equals(object obj)
		{
			if (obj is GClass2.GStruct3)
			{
				return this.method_0((GClass2.GStruct3)obj);
			}
			return obj is Rectangle && this.method_0(new GClass2.GStruct3((Rectangle)obj));
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000048D4 File Offset: 0x00002AD4
		public int GetHashCode()
		{
			return GClass2.GStruct3.smethod_0(this).GetHashCode();
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000048FC File Offset: 0x00002AFC
		public string ToString()
		{
			return GClass2.GStruct3.smethod_5(GClass2.GStruct3.smethod_4(), "{{Left={0},Top={1},Right={2},Bottom={3}}}", new object[] { this.int_0, this.int_1, this.int_2, this.int_3 });
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000292E File Offset: 0x00000B2E
		static CultureInfo smethod_4()
		{
			return CultureInfo.CurrentCulture;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00002935 File Offset: 0x00000B35
		static string smethod_5(IFormatProvider iformatProvider_0, string string_0, object[] object_0)
		{
			return string.Format(iformatProvider_0, string_0, object_0);
		}

		// Token: 0x04000093 RID: 147
		public int int_0;

		// Token: 0x04000094 RID: 148
		public int int_1;

		// Token: 0x04000095 RID: 149
		public int int_2;

		// Token: 0x04000096 RID: 150
		public int int_3;
	}

	// Token: 0x0200001A RID: 26
	private enum Enum3 : uint
	{
		// Token: 0x04000098 RID: 152
		DONT_RESOLVE_DLL_REFERENCES = 1U,
		// Token: 0x04000099 RID: 153
		LOAD_IGNORE_CODE_AUTHZ_LEVEL = 16U,
		// Token: 0x0400009A RID: 154
		LOAD_LIBRARY_AS_DATAFILE = 2U,
		// Token: 0x0400009B RID: 155
		LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 64U,
		// Token: 0x0400009C RID: 156
		LOAD_LIBRARY_AS_IMAGE_RESOURCE = 32U,
		// Token: 0x0400009D RID: 157
		LOAD_WITH_ALTERED_SEARCH_PATH = 8U
	}

	// Token: 0x0200001B RID: 27
	private enum Enum4
	{
		// Token: 0x0400009F RID: 159
		PS_SOLID,
		// Token: 0x040000A0 RID: 160
		PS_DASH,
		// Token: 0x040000A1 RID: 161
		PS_DOT,
		// Token: 0x040000A2 RID: 162
		PS_DASHDOT,
		// Token: 0x040000A3 RID: 163
		PS_DASHDOTDOT,
		// Token: 0x040000A4 RID: 164
		PS_NULL,
		// Token: 0x040000A5 RID: 165
		PS_INSIDEFRAME,
		// Token: 0x040000A6 RID: 166
		PS_USERSTYLE,
		// Token: 0x040000A7 RID: 167
		PS_ALTERNATE,
		// Token: 0x040000A8 RID: 168
		PS_STYLE_MASK = 15,
		// Token: 0x040000A9 RID: 169
		PS_ENDCAP_ROUND = 0,
		// Token: 0x040000AA RID: 170
		PS_ENDCAP_SQUARE = 256,
		// Token: 0x040000AB RID: 171
		PS_ENDCAP_FLAT = 512,
		// Token: 0x040000AC RID: 172
		PS_ENDCAP_MASK = 3840,
		// Token: 0x040000AD RID: 173
		PS_JOIN_ROUND = 0,
		// Token: 0x040000AE RID: 174
		PS_JOIN_BEVEL = 4096,
		// Token: 0x040000AF RID: 175
		PS_JOIN_MITER = 8192,
		// Token: 0x040000B0 RID: 176
		PS_JOIN_MASK = 61440,
		// Token: 0x040000B1 RID: 177
		PS_COSMETIC = 0,
		// Token: 0x040000B2 RID: 178
		PS_GEOMETRIC = 65536,
		// Token: 0x040000B3 RID: 179
		PS_TYPE_MASK = 983040
	}

	// Token: 0x0200001C RID: 28
	public enum GEnum3 : uint
	{
		// Token: 0x040000B5 RID: 181
		SRCCOPY = 13369376U,
		// Token: 0x040000B6 RID: 182
		SRCPAINT = 15597702U,
		// Token: 0x040000B7 RID: 183
		SRCAND = 8913094U,
		// Token: 0x040000B8 RID: 184
		SRCINVERT = 6684742U,
		// Token: 0x040000B9 RID: 185
		SRCERASE = 4457256U,
		// Token: 0x040000BA RID: 186
		NOTSRCCOPY = 3342344U,
		// Token: 0x040000BB RID: 187
		NOTSRCERASE = 1114278U,
		// Token: 0x040000BC RID: 188
		MERGECOPY = 12583114U,
		// Token: 0x040000BD RID: 189
		MERGEPAINT = 12255782U,
		// Token: 0x040000BE RID: 190
		PATCOPY = 15728673U,
		// Token: 0x040000BF RID: 191
		PATPAINT = 16452105U,
		// Token: 0x040000C0 RID: 192
		PATINVERT = 5898313U,
		// Token: 0x040000C1 RID: 193
		DSTINVERT = 5570569U,
		// Token: 0x040000C2 RID: 194
		BLACKNESS = 66U,
		// Token: 0x040000C3 RID: 195
		WHITENESS = 16711778U,
		// Token: 0x040000C4 RID: 196
		CAPTUREBLT = 1073741824U,
		// Token: 0x040000C5 RID: 197
		CUSTOM = 1051781U
	}

	// Token: 0x0200001D RID: 29
	public struct GStruct4
	{
		// Token: 0x060000AB RID: 171 RVA: 0x0000293F File Offset: 0x00000B3F
		public GStruct4(int x, int y)
		{
			this.int_0 = x;
			this.int_1 = y;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000294F File Offset: 0x00000B4F
		public static Point smethod_0(GClass2.GStruct4 gstruct4_0)
		{
			return new Point(gstruct4_0.int_0, gstruct4_0.int_1);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00002962 File Offset: 0x00000B62
		public static GClass2.GStruct4 smethod_1(Point point_0)
		{
			return new GClass2.GStruct4(point_0.X, point_0.Y);
		}

		// Token: 0x040000C6 RID: 198
		public int int_0;

		// Token: 0x040000C7 RID: 199
		public int int_1;
	}

	// Token: 0x0200001E RID: 30
	public struct GStruct5
	{
		// Token: 0x060000AE RID: 174 RVA: 0x00002977 File Offset: 0x00000B77
		public GStruct5(byte op, byte flags, byte alpha, byte format)
		{
			this.byte_0 = op;
			this.byte_1 = flags;
			this.byte_2 = alpha;
			this.byte_3 = format;
		}

		// Token: 0x040000C8 RID: 200
		private byte byte_0;

		// Token: 0x040000C9 RID: 201
		private byte byte_1;

		// Token: 0x040000CA RID: 202
		private byte byte_2;

		// Token: 0x040000CB RID: 203
		private byte byte_3;
	}

	// Token: 0x0200001F RID: 31
	public struct GStruct6
	{
		// Token: 0x060000AF RID: 175 RVA: 0x00002996 File Offset: 0x00000B96
		public GStruct6(uint upLeft, uint lowRight)
		{
			this.uint_0 = upLeft;
			this.uint_1 = lowRight;
		}

		// Token: 0x040000CC RID: 204
		public uint uint_0;

		// Token: 0x040000CD RID: 205
		public uint uint_1;
	}

	// Token: 0x02000020 RID: 32
	public struct GStruct7
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x000029A6 File Offset: 0x00000BA6
		public GStruct7(int x, int y, ushort red, ushort green, ushort blue, ushort alpha)
		{
			this.int_0 = x;
			this.int_1 = y;
			this.ushort_0 = red;
			this.ushort_1 = green;
			this.ushort_2 = blue;
			this.ushort_3 = alpha;
		}

		// Token: 0x040000CE RID: 206
		public int int_0;

		// Token: 0x040000CF RID: 207
		public int int_1;

		// Token: 0x040000D0 RID: 208
		public ushort ushort_0;

		// Token: 0x040000D1 RID: 209
		public ushort ushort_1;

		// Token: 0x040000D2 RID: 210
		public ushort ushort_2;

		// Token: 0x040000D3 RID: 211
		public ushort ushort_3;
	}

	// Token: 0x02000021 RID: 33
	public enum GEnum4 : uint
	{
		// Token: 0x040000D5 RID: 213
		RECT_H,
		// Token: 0x040000D6 RID: 214
		RECT_V,
		// Token: 0x040000D7 RID: 215
		TRIANGLE,
		// Token: 0x040000D8 RID: 216
		OP_FLAG = 255U
	}

	// Token: 0x02000022 RID: 34
	public struct GStruct8
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x000029D5 File Offset: 0x00000BD5
		public GStruct8(uint vertex1, uint vertex2, uint vertex3)
		{
			this.uint_0 = vertex1;
			this.uint_1 = vertex2;
			this.uint_2 = vertex3;
		}

		// Token: 0x040000D9 RID: 217
		public uint uint_0;

		// Token: 0x040000DA RID: 218
		public uint uint_1;

		// Token: 0x040000DB RID: 219
		public uint uint_2;
	}

	// Token: 0x02000023 RID: 35
	[Serializable]
	public struct GStruct9
	{
		// Token: 0x040000DC RID: 220
		public byte rgbBlue;

		// Token: 0x040000DD RID: 221
		public byte rgbGreen;

		// Token: 0x040000DE RID: 222
		public byte rgbRed;

		// Token: 0x040000DF RID: 223
		public byte rgbReserved;
	}
}
