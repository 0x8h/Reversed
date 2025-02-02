using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PLASMA
{
	// Token: 0x02000020 RID: 32
	internal class Program
	{
		// Token: 0x0600013D RID: 317
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x0600013E RID: 318
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x0600013F RID: 319
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		// Token: 0x06000140 RID: 320
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int width, int height);

		// Token: 0x06000141 RID: 321
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		// Token: 0x06000142 RID: 322
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x06000143 RID: 323
		[DllImport("gdi32.dll")]
		private static extern bool DeleteDC(IntPtr hdc);

		// Token: 0x06000144 RID: 324
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, int rop);

		// Token: 0x06000145 RID: 325
		[DllImport("gdi32.dll")]
		private static extern int SetDIBits(IntPtr hdc, IntPtr hbm, uint start, uint cLines, byte[] lpBits, ref Program.BITMAPINFO lpbmi, uint usage);

		// Token: 0x06000146 RID: 326 RVA: 0x00007770 File Offset: 0x00005970
		public static void ShowEffect()
		{
			IntPtr hdc = Program.GetDC(IntPtr.Zero);
			int width = Program.GetSystemMetrics(0);
			int height = Program.GetSystemMetrics(1);
			Thread thread = new Thread(delegate
			{
				Program.BlueRedShader(hdc, width, height);
			});
			Thread thread2 = new Thread(delegate
			{
				Bytebeat.PlayBytebeatAudio();
			});
			thread.Start();
			thread2.Start();
			thread.Join();
			thread2.Join();
			Program.ReleaseDC(IntPtr.Zero, hdc);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00007810 File Offset: 0x00005A10
		private static void BlueRedShader(IntPtr hdc, int width, int height)
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
			int num2 = 5000;
			DateTime now = DateTime.Now;
			while ((DateTime.Now - now).TotalMilliseconds < (double)num2)
			{
				for (int i = 0; i < height; i++)
				{
					for (int j = 0; j < width; j++)
					{
						double num3 = (double)j;
						double num4 = (double)i;
						double num5 = (128.0 + 128.0 * Math.Sin(num3 / 66.0 + (double)num * 67.05) + 128.0 + 128.0 * Math.Sin(num4 / 8.0 + (double)num * 78.57) + 128.0 + 128.0 * Math.Sin((num3 + num4) / 89.5 + (double)num * 3.995) + 128.0 + 128.0 * Math.Sin(Math.Sqrt(num3 * num3 + num4 * num4) / 8.0 + (double)num * 6.05)) / 1.9;
						int num6 = (int)num5;
						byte b = (byte)(num6 % 556);
						byte b2 = (byte)(num6 * 2 % 356);
						byte b3 = (byte)(num6 * 3 % 356);
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

		// Token: 0x06000148 RID: 328
		[DllImport("user32.dll", SetLastError = true)]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x04000074 RID: 116
		private const int SRCCOPY = 13369376;

		// Token: 0x02000049 RID: 73
		public struct BITMAPINFOHEADER
		{
			// Token: 0x04000107 RID: 263
			public uint biSize;

			// Token: 0x04000108 RID: 264
			public int biWidth;

			// Token: 0x04000109 RID: 265
			public int biHeight;

			// Token: 0x0400010A RID: 266
			public ushort biPlanes;

			// Token: 0x0400010B RID: 267
			public ushort biBitCount;

			// Token: 0x0400010C RID: 268
			public uint biCompression;

			// Token: 0x0400010D RID: 269
			public uint biSizeImage;

			// Token: 0x0400010E RID: 270
			public int biXPelsPerMeter;

			// Token: 0x0400010F RID: 271
			public int biYPelsPerMeter;

			// Token: 0x04000110 RID: 272
			public uint biClrUsed;

			// Token: 0x04000111 RID: 273
			public uint biClrImportant;
		}

		// Token: 0x0200004A RID: 74
		public struct BITMAPINFO
		{
			// Token: 0x04000112 RID: 274
			public Program.BITMAPINFOHEADER bmiHeader;
		}
	}
}
