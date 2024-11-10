using System;
using System.Runtime.InteropServices;

namespace PdfSharp.Internal
{
	// Token: 0x020000BF RID: 191
	internal static class NativeMethods
	{
		// Token: 0x060007CB RID: 1995
		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);

		// Token: 0x060007CC RID: 1996
		[DllImport("user32.dll")]
		public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

		// Token: 0x060007CD RID: 1997
		[DllImport("gdi32.dll", SetLastError = true)]
		public static extern int GetFontData(IntPtr hdc, uint dwTable, uint dwOffset, byte[] lpvBuffer, int cbData);

		// Token: 0x060007CE RID: 1998
		[DllImport("gdi32.dll", SetLastError = true)]
		public static extern IntPtr CreateDC(string driver, string device, string port, IntPtr data);

		// Token: 0x060007CF RID: 1999
		[DllImport("gdi32.dll", SetLastError = true)]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		// Token: 0x060007D0 RID: 2000
		[DllImport("gdi32.dll", EntryPoint = "CreateFontIndirectW")]
		public static extern IntPtr CreateFontIndirect(NativeMethods.LOGFONT lpLogFont);

		// Token: 0x060007D1 RID: 2001
		[DllImport("gdi32.dll")]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		// Token: 0x060007D2 RID: 2002
		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hgdiobj);

		// Token: 0x060007D3 RID: 2003
		[DllImport("gdi32.dll")]
		public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

		// Token: 0x04000425 RID: 1061
		public const int GDI_ERROR = -1;

		// Token: 0x04000426 RID: 1062
		public const int HORZSIZE = 4;

		// Token: 0x04000427 RID: 1063
		public const int VERTSIZE = 6;

		// Token: 0x04000428 RID: 1064
		public const int HORZRES = 8;

		// Token: 0x04000429 RID: 1065
		public const int VERTRES = 10;

		// Token: 0x0400042A RID: 1066
		public const int LOGPIXELSX = 88;

		// Token: 0x0400042B RID: 1067
		public const int LOGPIXELSY = 90;

		// Token: 0x020000C0 RID: 192
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public class LOGFONT
		{
			// Token: 0x060007D4 RID: 2004 RVA: 0x0001DEBC File Offset: 0x0001C0BC
			private LOGFONT(int dummy)
			{
				this.lfHeight = 0;
				this.lfWidth = 0;
				this.lfEscapement = 0;
				this.lfOrientation = 0;
				this.lfWeight = 0;
				this.lfItalic = 0;
				this.lfUnderline = 0;
				this.lfStrikeOut = 0;
				this.lfCharSet = 0;
				this.lfOutPrecision = 0;
				this.lfClipPrecision = 0;
				this.lfQuality = 0;
				this.lfPitchAndFamily = 0;
				this.lfFaceName = "";
			}

			// Token: 0x060007D5 RID: 2005 RVA: 0x0001DF38 File Offset: 0x0001C138
			public override string ToString()
			{
				object[] array = new object[]
				{
					"lfHeight=", this.lfHeight, ", lfWidth=", this.lfWidth, ", lfEscapement=", this.lfEscapement, ", lfOrientation=", this.lfOrientation, ", lfWeight=", this.lfWeight,
					", lfItalic=", this.lfItalic, ", lfUnderline=", this.lfUnderline, ", lfStrikeOut=", this.lfStrikeOut, ", lfCharSet=", this.lfCharSet, ", lfOutPrecision=", this.lfOutPrecision,
					", lfClipPrecision=", this.lfClipPrecision, ", lfQuality=", this.lfQuality, ", lfPitchAndFamily=", this.lfPitchAndFamily, ", lfFaceName=", this.lfFaceName
				};
				return string.Concat(array);
			}

			// Token: 0x060007D6 RID: 2006 RVA: 0x0001E097 File Offset: 0x0001C297
			public LOGFONT()
			{
			}

			// Token: 0x0400042C RID: 1068
			public int lfHeight;

			// Token: 0x0400042D RID: 1069
			public int lfWidth;

			// Token: 0x0400042E RID: 1070
			public int lfEscapement;

			// Token: 0x0400042F RID: 1071
			public int lfOrientation;

			// Token: 0x04000430 RID: 1072
			public int lfWeight;

			// Token: 0x04000431 RID: 1073
			public byte lfItalic;

			// Token: 0x04000432 RID: 1074
			public byte lfUnderline;

			// Token: 0x04000433 RID: 1075
			public byte lfStrikeOut;

			// Token: 0x04000434 RID: 1076
			public byte lfCharSet;

			// Token: 0x04000435 RID: 1077
			public byte lfOutPrecision;

			// Token: 0x04000436 RID: 1078
			public byte lfClipPrecision;

			// Token: 0x04000437 RID: 1079
			public byte lfQuality;

			// Token: 0x04000438 RID: 1080
			public byte lfPitchAndFamily;

			// Token: 0x04000439 RID: 1081
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string lfFaceName;
		}
	}
}
