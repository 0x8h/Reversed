using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace LSDTRIP
{
	// Token: 0x02000006 RID: 6
	internal class Program
	{
		// Token: 0x06000023 RID: 35
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x06000024 RID: 36
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x06000025 RID: 37
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		// Token: 0x06000026 RID: 38
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int width, int height);

		// Token: 0x06000027 RID: 39
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		// Token: 0x06000028 RID: 40
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x06000029 RID: 41
		[DllImport("gdi32.dll")]
		private static extern bool DeleteDC(IntPtr hdc);

		// Token: 0x0600002A RID: 42
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, int rop);

		// Token: 0x0600002B RID: 43
		[DllImport("gdi32.dll")]
		private static extern int SetDIBits(IntPtr hdc, IntPtr hbm, uint start, uint cLines, byte[] lpBits, ref Program.BITMAPINFO lpbmi, uint usage);

		// Token: 0x0600002C RID: 44 RVA: 0x000029CC File Offset: 0x00000BCC
		public static void ShowEffect()
		{
			IntPtr hdc = Program.GetDC(IntPtr.Zero);
			int width = Program.GetSystemMetrics(0);
			int height = Program.GetSystemMetrics(1);
			Thread thread = new Thread(delegate
			{
				Program.ExtremeLSDPlasma(hdc, width, height);
			});
			Thread thread2 = new Thread(delegate
			{
				Bytebeat.PlayDistortedAudio();
			});
			thread.Start();
			thread2.Start();
			thread.Join();
			thread2.Join();
			Program.ReleaseDC(IntPtr.Zero, hdc);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002A6C File Offset: 0x00000C6C
		private static void ExtremeLSDPlasma(IntPtr hdc, int width, int height)
		{
			IntPtr intPtr = Program.CreateCompatibleDC(hdc);
			IntPtr intPtr2 = Program.CreateCompatibleBitmap(hdc, width, height);
			Program.SelectObject(intPtr, intPtr2);
			Program.BITMAPINFO bitmapinfo = default(Program.BITMAPINFO);
			bitmapinfo.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(Program.BITMAPINFOHEADER));
			bitmapinfo.bmiHeader.biWidth = width;
			bitmapinfo.bmiHeader.biHeight = -height;
			bitmapinfo.bmiHeader.biPlanes = 1;
			bitmapinfo.bmiHeader.biBitCount = 24;
			bitmapinfo.bmiHeader.biCompression = 0U;
			byte[] array = new byte[width * height * 3];
			int num = 0;
			int num2 = 10000;
			DateTime now = DateTime.Now;
			while ((DateTime.Now - now).TotalMilliseconds < (double)num2)
			{
				for (int i = 0; i < height; i++)
				{
					for (int j = 0; j < width; j++)
					{
						int num3 = (int)(128.0 + 128.0 * Math.Sin((double)j / 16.0) + 128.0 + 128.0 * Math.Sin((double)i / 8.0) + 128.0 + 128.0 * Math.Sin((double)(j + i) / 16.0) + 128.0 + 128.0 * Math.Sin(Math.Sqrt((double)(j * j + i * i)) / 8.0)) / 4;
						byte b = (byte)((double)num3 * Math.Sin((double)num * 0.1) % 256.0);
						byte b2 = (byte)((double)num3 * Math.Sin((double)num * 0.2) % 256.0);
						byte b3 = (byte)((double)num3 * Math.Cos((double)num * 0.3) % 256.0);
						array[(i * width + j) * 3] = b3;
						array[(i * width + j) * 3 + 1] = b2;
						array[(i * width + j) * 3 + 2] = b;
					}
				}
				Program.SetDIBits(intPtr, intPtr2, 0U, (uint)height, array, ref bitmapinfo, 0U);
				Program.BitBlt(hdc, 0, 0, width, height, intPtr, 0, 0, 13369376);
				num++;
				Thread.Sleep(10);
			}
			Program.DeleteObject(intPtr2);
			Program.DeleteDC(intPtr);
		}

		// Token: 0x0600002E RID: 46
		[DllImport("user32.dll", SetLastError = true)]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x04000012 RID: 18
		private const int SRCCOPY = 13369376;

		// Token: 0x02000031 RID: 49
		public struct BITMAPINFOHEADER
		{
			// Token: 0x040000AE RID: 174
			public uint biSize;

			// Token: 0x040000AF RID: 175
			public int biWidth;

			// Token: 0x040000B0 RID: 176
			public int biHeight;

			// Token: 0x040000B1 RID: 177
			public ushort biPlanes;

			// Token: 0x040000B2 RID: 178
			public ushort biBitCount;

			// Token: 0x040000B3 RID: 179
			public uint biCompression;

			// Token: 0x040000B4 RID: 180
			public uint biSizeImage;

			// Token: 0x040000B5 RID: 181
			public int biXPelsPerMeter;

			// Token: 0x040000B6 RID: 182
			public int biYPelsPerMeter;

			// Token: 0x040000B7 RID: 183
			public uint biClrUsed;

			// Token: 0x040000B8 RID: 184
			public uint biClrImportant;
		}

		// Token: 0x02000032 RID: 50
		public struct BITMAPINFO
		{
			// Token: 0x040000B9 RID: 185
			public Program.BITMAPINFOHEADER bmiHeader;
		}
	}
}
