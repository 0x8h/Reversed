using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace GOCULLINATOR
{
	// Token: 0x02000024 RID: 36
	internal class Program
	{
		// Token: 0x0600016C RID: 364
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x0600016D RID: 365
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x0600016E RID: 366
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		// Token: 0x0600016F RID: 367
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int width, int height);

		// Token: 0x06000170 RID: 368
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		// Token: 0x06000171 RID: 369
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x06000172 RID: 370
		[DllImport("gdi32.dll")]
		private static extern bool DeleteDC(IntPtr hdc);

		// Token: 0x06000173 RID: 371
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, int rop);

		// Token: 0x06000174 RID: 372
		[DllImport("gdi32.dll")]
		private static extern int SetDIBits(IntPtr hdc, IntPtr hbm, uint start, uint cLines, byte[] lpBits, ref Program.BITMAPINFO lpbmi, uint usage);

		// Token: 0x06000175 RID: 373 RVA: 0x00008458 File Offset: 0x00006658
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

		// Token: 0x06000176 RID: 374 RVA: 0x000084F8 File Offset: 0x000066F8
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
			int num2 = 20000;
			DateTime now = DateTime.Now;
			while ((DateTime.Now - now).TotalMilliseconds < (double)num2)
			{
				for (int i = 0; i < height; i++)
				{
					for (int j = 0; j < width; j++)
					{
						double num3 = (double)j;
						double num4 = (double)i;
						double num5 = (128.0 + 128.0 * Math.Sin(num3 * 0.03 + (double)num * 45.1) + 128.0 + 128.0 * Math.Cos(num4 * 0.04 + (double)num * 45.2) + 128.0 + 128.0 * Math.Sin(Math.Sqrt(num3 * num3 + num4 * num4) * 0.5 + (double)num * 0.15) + 128.0 * Math.Cos((double)num * 0.3)) / 3.0;
						int num6 = (int)num5;
						byte b = (byte)(Math.Abs(Math.Sin((double)num6 * 0.05 + (double)num * 0.01)) * 755.0);
						byte b2 = (byte)(Math.Abs(Math.Cos((double)num6 * 0.04 + (double)num * 0.015)) * 255.0);
						byte b3 = (byte)(Math.Abs(Math.Sin((double)num6 * 0.06 + (double)num * 0.02)) * 955.0);
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

		// Token: 0x06000177 RID: 375
		[DllImport("user32.dll", SetLastError = true)]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x0400007D RID: 125
		private const int SRCCOPY = 13369376;

		// Token: 0x02000052 RID: 82
		public struct BITMAPINFOHEADER
		{
			// Token: 0x04000120 RID: 288
			public uint biSize;

			// Token: 0x04000121 RID: 289
			public int biWidth;

			// Token: 0x04000122 RID: 290
			public int biHeight;

			// Token: 0x04000123 RID: 291
			public ushort biPlanes;

			// Token: 0x04000124 RID: 292
			public ushort biBitCount;

			// Token: 0x04000125 RID: 293
			public uint biCompression;

			// Token: 0x04000126 RID: 294
			public uint biSizeImage;

			// Token: 0x04000127 RID: 295
			public int biXPelsPerMeter;

			// Token: 0x04000128 RID: 296
			public int biYPelsPerMeter;

			// Token: 0x04000129 RID: 297
			public uint biClrUsed;

			// Token: 0x0400012A RID: 298
			public uint biClrImportant;
		}

		// Token: 0x02000053 RID: 83
		public struct BITMAPINFO
		{
			// Token: 0x0400012B RID: 299
			public Program.BITMAPINFOHEADER bmiHeader;
		}
	}
}
