using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;

namespace MANDELBROT
{
	// Token: 0x02000008 RID: 8
	internal class Program
	{
		// Token: 0x06000038 RID: 56
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x06000039 RID: 57
		[DllImport("user32.dll")]
		private static extern void ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x0600003A RID: 58
		[DllImport("gdi32.dll")]
		private static extern uint SetPixel(IntPtr hdc, int x, int y, uint color);

		// Token: 0x0600003B RID: 59
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x0600003C RID: 60 RVA: 0x00002F24 File Offset: 0x00001124
		private static uint RGB(int r, int g, int b)
		{
			return (uint)((r & 255) | ((g & 255) << 8) | ((b & 255) << 16));
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002F54 File Offset: 0x00001154
		private static void DrawMandelbrot(IntPtr hdc, int width, int height)
		{
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					Complex complex = new Complex(((double)i - (double)width / 2.0) * 3.5 / (double)width - 0.5, ((double)j - (double)height / 2.0) * 2.0 / (double)height);
					Complex complex2 = 0;
					int num = 0;
					while (complex2.Magnitude <= 2.0 && num < 10)
					{
						complex2 = complex2 * complex2 + complex;
						num++;
					}
					int num2 = ((num == 10) ? 0 : (855 * num / 10));
					int num3 = ((num == 10) ? 0 : (740 * num / 10));
					int num4 = 0;
					Program.SetPixel(hdc, i, j, Program.RGB(num2, num3, num4));
				}
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003068 File Offset: 0x00001268
		public static void ShowEffect()
		{
			int screenWidth = Program.GetSystemMetrics(0);
			int screenHeight = Program.GetSystemMetrics(1);
			IntPtr hdcScreen = Program.GetDC(IntPtr.Zero);
			bool flag = hdcScreen != IntPtr.Zero;
			if (flag)
			{
				Thread thread = new Thread(delegate
				{
					Program.DrawMandelbrot(hdcScreen, screenWidth, screenHeight);
				});
				thread.Start();
				Bytebeat.PlayBytebeatAudio();
				thread.Join();
				Program.ReleaseDC(IntPtr.Zero, hdcScreen);
			}
			Thread.Sleep(5000);
		}

		// Token: 0x04000017 RID: 23
		private const int MAX_ITER = 10;

		// Token: 0x04000018 RID: 24
		private const int SM_CXSCREEN = 0;

		// Token: 0x04000019 RID: 25
		private const int SM_CYSCREEN = 1;
	}
}
