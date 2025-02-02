using System;
using System.Runtime.InteropServices;

namespace PLASMA56
{
	// Token: 0x02000029 RID: 41
	internal class Program
	{
		// Token: 0x060001A4 RID: 420
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x060001A5 RID: 421
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		// Token: 0x060001A6 RID: 422
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateDIBSection(IntPtr hdc, ref Program.BITMAPINFO bmi, uint usage, out IntPtr bits, IntPtr hSection, uint offset);

		// Token: 0x060001A7 RID: 423
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

		// Token: 0x060001A8 RID: 424
		[DllImport("gdi32.dll")]
		private static extern bool StretchBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSrc, int xSrc, int ySrc, int wSrc, int hSrc, uint rop);

		// Token: 0x060001A9 RID: 425
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x060001AA RID: 426
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x060001AB RID: 427
		[DllImport("kernel32.dll")]
		private static extern void Sleep(uint dwMilliseconds);

		// Token: 0x060001AC RID: 428 RVA: 0x00009248 File Offset: 0x00007448
		public unsafe static void ShowEffect()
		{
			IntPtr dc = Program.GetDC(IntPtr.Zero);
			IntPtr intPtr = Program.CreateCompatibleDC(dc);
			int num = 1920;
			int num2 = 1080;
			int num3 = num / 4;
			int num4 = num2 / 4;
			Program.BITMAPINFO bitmapinfo = default(Program.BITMAPINFO);
			bitmapinfo.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(Program.BITMAPINFOHEADER));
			bitmapinfo.bmiHeader.biWidth = num3;
			bitmapinfo.bmiHeader.biHeight = num4;
			bitmapinfo.bmiHeader.biPlanes = 1;
			bitmapinfo.bmiHeader.biBitCount = 32;
			bitmapinfo.bmiHeader.biCompression = 0U;
			IntPtr intPtr3;
			IntPtr intPtr2 = Program.CreateDIBSection(dc, ref bitmapinfo, 0U, out intPtr3, IntPtr.Zero, 0U);
			Program.SelectObject(intPtr, intPtr2);
			int num5 = 0;
			double num6 = 0.1;
			Random random = new Random();
			int num7 = 20000;
			long num8 = DateTime.Now.Ticks / 10000L;
			for (;;)
			{
				long num9 = DateTime.Now.Ticks / 10000L;
				bool flag = num9 - num8 >= (long)num7;
				if (flag)
				{
					break;
				}
				Program.StretchBlt(intPtr, 0, 0, num3, num4, dc, 0, 0, num, num2, 13369376U);
				uint* ptr = (uint*)intPtr3.ToPointer();
				for (int i = 0; i < num3; i++)
				{
					for (int j = 0; j < num4; j++)
					{
						int num10 = j * num3 + i;
						double num11 = (double)(i - num3 / 2) * num6;
						double num12 = (double)(j - num4 / 2) * num6;
						double num13 = Math.Sin(num11 * 0.5 + (double)num5 * 0.1) * 128.0 + 128.0;
						double num14 = Math.Cos(num12 * 0.4 + (double)num5 * 0.15) * 128.0 + 128.0;
						double num15 = Math.Sin((num11 + num12) * 0.3 + (double)num5 * 0.2) * 128.0 + 128.0;
						double num16 = Math.Cos(num11 * 0.6 + num12 * 0.5 + (double)num5 * 0.25) * 128.0 + 128.0;
						double num17 = Math.Sin(num11 * 0.8 + num12 * 0.7 + (double)num5 * 0.3) * 128.0 + 128.0;
						double num18 = (num13 + num14 + num15 + num16 + num17) / 5.0;
						byte b = (byte)((Math.Sin(num18 * 0.03 + (double)num5 * 0.05) * 127.0 + 128.0 + (double)random.Next(-30, 30)) % 256.0);
						byte b2 = (byte)((Math.Sin(num18 * 0.02 + (double)num5 * 0.06) * 127.0 + 128.0 + (double)random.Next(-30, 30)) % 256.0);
						byte b3 = (byte)((Math.Sin(num18 * 0.01 + (double)num5 * 0.07) * 127.0 + 128.0 + (double)random.Next(-30, 30)) % 256.0);
						ptr[num10] = (uint)((int)b | ((int)b2 << 8) | ((int)b3 << 16));
					}
				}
				num5 += 4;
				Program.StretchBlt(dc, 0, 0, num, num2, intPtr, 0, 0, num3, num4, 13369376U);
				Program.Sleep(5U);
			}
			Program.DeleteObject(intPtr2);
			Program.ReleaseDC(IntPtr.Zero, dc);
		}

		// Token: 0x0400008A RID: 138
		private const uint DIB_RGB_COLORS = 0U;

		// Token: 0x0400008B RID: 139
		private const uint SRCCOPY = 13369376U;

		// Token: 0x0400008C RID: 140
		private const int BI_RGB = 0;

		// Token: 0x0200005C RID: 92
		private struct BITMAPINFOHEADER
		{
			// Token: 0x04000142 RID: 322
			public uint biSize;

			// Token: 0x04000143 RID: 323
			public int biWidth;

			// Token: 0x04000144 RID: 324
			public int biHeight;

			// Token: 0x04000145 RID: 325
			public ushort biPlanes;

			// Token: 0x04000146 RID: 326
			public ushort biBitCount;

			// Token: 0x04000147 RID: 327
			public uint biCompression;

			// Token: 0x04000148 RID: 328
			public uint biSizeImage;

			// Token: 0x04000149 RID: 329
			public int biXPelsPerMeter;

			// Token: 0x0400014A RID: 330
			public int biYPelsPerMeter;

			// Token: 0x0400014B RID: 331
			public uint biClrUsed;

			// Token: 0x0400014C RID: 332
			public uint biClrImportant;
		}

		// Token: 0x0200005D RID: 93
		private struct BITMAPINFO
		{
			// Token: 0x0400014D RID: 333
			public Program.BITMAPINFOHEADER bmiHeader;

			// Token: 0x0400014E RID: 334
			public uint bmiColors;
		}
	}
}
