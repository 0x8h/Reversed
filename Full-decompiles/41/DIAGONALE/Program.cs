using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace DIAGONALE
{
	// Token: 0x0200000A RID: 10
	internal class Program
	{
		// Token: 0x06000048 RID: 72
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hwnd);

		// Token: 0x06000049 RID: 73
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		// Token: 0x0600004A RID: 74
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int width, int height, IntPtr hdcSrc, int xSrc, int ySrc, uint rop);

		// Token: 0x0600004B RID: 75
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x0600004C RID: 76 RVA: 0x00003324 File Offset: 0x00001524
		public static void ShowEffect()
		{
			IntPtr dc = Program.GetDC(IntPtr.Zero);
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			int num = 8000;
			long num2 = DateTime.Now.Ticks + TimeSpan.FromMilliseconds((double)num).Ticks;
			while (Program.running)
			{
				Thread.Sleep(1);
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
		}

		// Token: 0x0400001E RID: 30
		private const int SM_CXSCREEN = 0;

		// Token: 0x0400001F RID: 31
		private const int SM_CYSCREEN = 1;

		// Token: 0x04000020 RID: 32
		private const uint SRCCOPY = 13369376U;

		// Token: 0x04000021 RID: 33
		private static bool running = true;
	}
}
