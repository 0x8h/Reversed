using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace BOH5
{
	// Token: 0x02000019 RID: 25
	internal class Program
	{
		// Token: 0x060000F7 RID: 247
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hwnd);

		// Token: 0x060000F8 RID: 248
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		// Token: 0x060000F9 RID: 249
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int width, int height, IntPtr hdcSrc, int xSrc, int ySrc, uint rop);

		// Token: 0x060000FA RID: 250
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x060000FB RID: 251
		[DllImport("gdi32.dll")]
		private static extern bool PatBlt(IntPtr hdc, int x, int y, int width, int height, uint rop);

		// Token: 0x060000FC RID: 252 RVA: 0x000066F8 File Offset: 0x000048F8
		private static void GeneratePalette()
		{
			for (int i = 0; i < 256; i++)
			{
				int num = i % 64 * 4;
				int num2 = i % 128 * 2;
				int num3 = 255 - i % 64 * 4;
				Program.palette[i] = (uint)((num << 16) | (num2 << 8) | num3);
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00006750 File Offset: 0x00004950
		public static void ShowEffect()
		{
			IntPtr dc = Program.GetDC(IntPtr.Zero);
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			int num = 8000;
			long num2 = DateTime.Now.Ticks + TimeSpan.FromMilliseconds((double)num).Ticks;
			Program.GeneratePalette();
			Thread thread = new Thread(delegate
			{
				Bytebeat.PlayBytebeatAudio();
			});
			thread.Start();
			int num3 = 0;
			while (Program.running)
			{
				Thread.Sleep(1);
				Program.PatBlt(dc, 0, 0, systemMetrics, systemMetrics2, 5898313U);
				uint num4 = Program.palette[num3 % 256];
				num3++;
				Program.BitBlt(dc, 0, 0, systemMetrics / 2, systemMetrics2 / 2, dc, 1, 1, 13369376U);
				Program.BitBlt(dc, systemMetrics / 2, systemMetrics2 / 2, systemMetrics / 2, systemMetrics2 / 2, dc, systemMetrics / 2 - 1, systemMetrics2 / 2 - 1, 13369376U);
				bool flag = DateTime.Now.Ticks > num2;
				if (flag)
				{
					Program.running = false;
				}
				Thread.Sleep(10);
			}
			Program.ReleaseDC(IntPtr.Zero, dc);
			thread.Join();
		}

		// Token: 0x04000053 RID: 83
		private const int SM_CXSCREEN = 0;

		// Token: 0x04000054 RID: 84
		private const int SM_CYSCREEN = 1;

		// Token: 0x04000055 RID: 85
		private const uint SRCCOPY = 13369376U;

		// Token: 0x04000056 RID: 86
		private const uint PATINVERT = 5898313U;

		// Token: 0x04000057 RID: 87
		private static bool running = true;

		// Token: 0x04000058 RID: 88
		private static uint[] palette = new uint[256];
	}
}
