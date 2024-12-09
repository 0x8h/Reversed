using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

// Token: 0x02000006 RID: 6
internal class Class1
{
	// Token: 0x0600006D RID: 109
	[DllImport("user32.dll")]
	public static extern IntPtr GetWindowLong(IntPtr intptr_0, int int_0);

	// Token: 0x0600006E RID: 110
	[DllImport("kernel32.dll")]
	public static extern IntPtr GetCurrentThreadId();

	// Token: 0x0600006F RID: 111
	[DllImport("user32.dll")]
	public static extern IntPtr SetWindowsHookEx(int int_0, Class1.Delegate0 delegate0_0, IntPtr intptr_0, IntPtr intptr_1);

	// Token: 0x06000070 RID: 112
	[DllImport("user32.dll")]
	public static extern bool GetWindowRect(IntPtr intptr_0, out Class1.Struct0 struct0_0);

	// Token: 0x06000071 RID: 113
	[DllImport("user32.dll")]
	public static extern bool SetWindowPos(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, int int_4, uint uint_0);

	// Token: 0x06000072 RID: 114
	[DllImport("user32.dll")]
	public static extern bool UnhookWindowsHookEx(IntPtr intptr_0);

	// Token: 0x06000073 RID: 115
	[DllImport("user32.dll")]
	public static extern IntPtr CallNextHookEx(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

	// Token: 0x02000007 RID: 7
	// (Invoke) Token: 0x06000076 RID: 118
	public delegate IntPtr Delegate0(int nCode, IntPtr wParam, IntPtr lParam);

	// Token: 0x02000008 RID: 8
	public struct Struct0
	{
		// Token: 0x06000079 RID: 121 RVA: 0x0000239E File Offset: 0x0000059E
		public Struct0(int int_4, int int_5, int int_6, int int_7)
		{
			this.int_0 = int_4;
			this.int_1 = int_5;
			this.int_2 = int_6;
			this.int_3 = int_7;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000023BD File Offset: 0x000005BD
		public Struct0(Rectangle rectangle_0)
		{
			this = new Class1.Struct0(rectangle_0.Left, rectangle_0.Top, rectangle_0.Right, rectangle_0.Bottom);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600007B RID: 123 RVA: 0x000023E1 File Offset: 0x000005E1
		// (set) Token: 0x0600007C RID: 124 RVA: 0x000023E9 File Offset: 0x000005E9
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

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00002407 File Offset: 0x00000607
		// (set) Token: 0x0600007E RID: 126 RVA: 0x0000240F File Offset: 0x0000060F
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

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600007F RID: 127 RVA: 0x0000242D File Offset: 0x0000062D
		// (set) Token: 0x06000080 RID: 128 RVA: 0x0000243C File Offset: 0x0000063C
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

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000081 RID: 129 RVA: 0x0000244C File Offset: 0x0000064C
		// (set) Token: 0x06000082 RID: 130 RVA: 0x0000245B File Offset: 0x0000065B
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

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000083 RID: 131 RVA: 0x0000246B File Offset: 0x0000066B
		// (set) Token: 0x06000084 RID: 132 RVA: 0x0000247E File Offset: 0x0000067E
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

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000085 RID: 133 RVA: 0x0000249A File Offset: 0x0000069A
		// (set) Token: 0x06000086 RID: 134 RVA: 0x000024AD File Offset: 0x000006AD
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

		// Token: 0x06000087 RID: 135 RVA: 0x000024C9 File Offset: 0x000006C9
		public static Rectangle smethod_0(Class1.Struct0 struct0_0)
		{
			return new Rectangle(struct0_0.int_0, struct0_0.int_1, struct0_0.Int32_3, struct0_0.Int32_2);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000024EA File Offset: 0x000006EA
		public static Class1.Struct0 smethod_1(Rectangle rectangle_0)
		{
			return new Class1.Struct0(rectangle_0);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000024F2 File Offset: 0x000006F2
		public static bool smethod_2(Class1.Struct0 struct0_0, Class1.Struct0 struct0_1)
		{
			return struct0_0.method_0(struct0_1);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000024FC File Offset: 0x000006FC
		public static bool smethod_3(Class1.Struct0 struct0_0, Class1.Struct0 struct0_1)
		{
			return !struct0_0.method_0(struct0_1);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00002509 File Offset: 0x00000709
		public bool method_0(Class1.Struct0 struct0_0)
		{
			if (struct0_0.int_0 == this.int_0)
			{
				if (struct0_0.int_1 == this.int_1)
				{
					if (struct0_0.int_2 == this.int_2)
					{
						return struct0_0.int_3 == this.int_3;
					}
				}
			}
			return false;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00002547 File Offset: 0x00000747
		public bool Equals(object obj)
		{
			if (obj is Class1.Struct0)
			{
				return this.method_0((Class1.Struct0)obj);
			}
			return obj is Rectangle && this.method_0(new Class1.Struct0((Rectangle)obj));
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003734 File Offset: 0x00001934
		public int GetHashCode()
		{
			return Class1.Struct0.smethod_0(this).GetHashCode();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000375C File Offset: 0x0000195C
		public string ToString()
		{
			return Class1.Struct0.smethod_5(Class1.Struct0.smethod_4(), "{{Left={0},Top={1},Right={2},Bottom={3}}}", new object[] { this.int_0, this.int_1, this.int_2, this.int_3 });
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00002579 File Offset: 0x00000779
		static CultureInfo smethod_4()
		{
			return CultureInfo.CurrentCulture;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00002580 File Offset: 0x00000780
		static string smethod_5(IFormatProvider iformatProvider_0, string string_0, object[] object_0)
		{
			return string.Format(iformatProvider_0, string_0, object_0);
		}

		// Token: 0x0400000F RID: 15
		public int int_0;

		// Token: 0x04000010 RID: 16
		public int int_1;

		// Token: 0x04000011 RID: 17
		public int int_2;

		// Token: 0x04000012 RID: 18
		public int int_3;
	}

	// Token: 0x02000009 RID: 9
	public enum Enum0
	{
		// Token: 0x04000014 RID: 20
		GWL_WNDPROC = -4,
		// Token: 0x04000015 RID: 21
		GWLP_HINSTANCE = -6,
		// Token: 0x04000016 RID: 22
		GWLP_HWNDPARENT = -8,
		// Token: 0x04000017 RID: 23
		GWL_ID = -12,
		// Token: 0x04000018 RID: 24
		GWL_STYLE = -16,
		// Token: 0x04000019 RID: 25
		GWL_EXSTYLE = -20,
		// Token: 0x0400001A RID: 26
		GWL_USERDATA = -21,
		// Token: 0x0400001B RID: 27
		DWLP_MSGRESULT = 0,
		// Token: 0x0400001C RID: 28
		DWLP_USER = 8,
		// Token: 0x0400001D RID: 29
		DWLP_DLGPROC = 4
	}

	// Token: 0x0200000A RID: 10
	[Flags]
	public enum Enum1 : uint
	{
		// Token: 0x0400001F RID: 31
		SWP_ASYNCWINDOWPOS = 16384U,
		// Token: 0x04000020 RID: 32
		SWP_DEFERERASE = 8192U,
		// Token: 0x04000021 RID: 33
		SWP_DRAWFRAME = 32U,
		// Token: 0x04000022 RID: 34
		SWP_FRAMECHANGED = 32U,
		// Token: 0x04000023 RID: 35
		SWP_HIDEWINDOW = 128U,
		// Token: 0x04000024 RID: 36
		SWP_NOACTIVATE = 16U,
		// Token: 0x04000025 RID: 37
		SWP_NOCOPYBITS = 256U,
		// Token: 0x04000026 RID: 38
		SWP_NOMOVE = 2U,
		// Token: 0x04000027 RID: 39
		SWP_NOOWNERZORDER = 512U,
		// Token: 0x04000028 RID: 40
		SWP_NOREDRAW = 8U,
		// Token: 0x04000029 RID: 41
		SWP_NOREPOSITION = 512U,
		// Token: 0x0400002A RID: 42
		SWP_NOSENDCHANGING = 1024U,
		// Token: 0x0400002B RID: 43
		SWP_NOSIZE = 1U,
		// Token: 0x0400002C RID: 44
		SWP_NOZORDER = 4U,
		// Token: 0x0400002D RID: 45
		SWP_SHOWWINDOW = 64U
	}

	// Token: 0x0200000B RID: 11
	public enum Enum2
	{
		// Token: 0x0400002F RID: 47
		HCBT_MOVESIZE,
		// Token: 0x04000030 RID: 48
		HCBT_MINMAX,
		// Token: 0x04000031 RID: 49
		HCBT_QS,
		// Token: 0x04000032 RID: 50
		HCBT_CREATEWND,
		// Token: 0x04000033 RID: 51
		HCBT_DESTROYWND,
		// Token: 0x04000034 RID: 52
		HCBT_ACTIVATE,
		// Token: 0x04000035 RID: 53
		HCBT_CLICKSKIPPED,
		// Token: 0x04000036 RID: 54
		HCBT_KEYSKIPPED,
		// Token: 0x04000037 RID: 55
		HCBT_SYSCOMMAND,
		// Token: 0x04000038 RID: 56
		HCBT_SETFOCUS
	}

	// Token: 0x0200000C RID: 12
	public enum Enum3
	{
		// Token: 0x0400003A RID: 58
		WH_MSGFILTER = -1,
		// Token: 0x0400003B RID: 59
		WH_JOURNALRECORD,
		// Token: 0x0400003C RID: 60
		WH_JOURNALPLAYBACK,
		// Token: 0x0400003D RID: 61
		WH_KEYBOARD,
		// Token: 0x0400003E RID: 62
		WH_GETMESSAGE,
		// Token: 0x0400003F RID: 63
		WH_CALLWNDPROC,
		// Token: 0x04000040 RID: 64
		WH_CBT,
		// Token: 0x04000041 RID: 65
		WH_SYSMSGFILTER,
		// Token: 0x04000042 RID: 66
		WH_MOUSE,
		// Token: 0x04000043 RID: 67
		WH_HARDWARE,
		// Token: 0x04000044 RID: 68
		WH_DEBUG,
		// Token: 0x04000045 RID: 69
		WH_SHELL,
		// Token: 0x04000046 RID: 70
		WH_FOREGROUNDIDLE,
		// Token: 0x04000047 RID: 71
		WH_CALLWNDPROCRET,
		// Token: 0x04000048 RID: 72
		WH_KEYBOARD_LL,
		// Token: 0x04000049 RID: 73
		WH_MOUSE_LL
	}
}
