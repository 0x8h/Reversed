using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace SOUND
{
	// Token: 0x02000017 RID: 23
	internal class Program
	{
		// Token: 0x060000E8 RID: 232
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hwnd);

		// Token: 0x060000E9 RID: 233
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		// Token: 0x060000EA RID: 234
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int width, int height, IntPtr hdcSrc, int xSrc, int ySrc, uint rop);

		// Token: 0x060000EB RID: 235
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x060000EC RID: 236 RVA: 0x000063C0 File Offset: 0x000045C0
		public static void ShowEffect()
		{
			IntPtr dc = Program.GetDC(IntPtr.Zero);
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			int num = 8000;
			long num2 = DateTime.Now.Ticks + TimeSpan.FromMilliseconds((double)num).Ticks;
			Thread thread = new Thread(delegate
			{
				Bytebeat.PlayBytebeatAudio();
			});
			thread.Start();
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
			thread.Join();
		}

		// Token: 0x0400004B RID: 75
		private const int SM_CXSCREEN = 0;

		// Token: 0x0400004C RID: 76
		private const int SM_CYSCREEN = 1;

		// Token: 0x0400004D RID: 77
		private const uint SRCCOPY = 13369376U;

		// Token: 0x0400004E RID: 78
		private static bool running = true;
	}
}
