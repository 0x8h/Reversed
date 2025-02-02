using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace LSD2
{
	// Token: 0x02000026 RID: 38
	internal class Program
	{
		// Token: 0x06000181 RID: 385
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hwnd);

		// Token: 0x06000182 RID: 386
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x06000183 RID: 387
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateSolidBrush(int crColor);

		// Token: 0x06000184 RID: 388
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		// Token: 0x06000185 RID: 389
		[DllImport("gdi32.dll")]
		private static extern bool PatBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, uint dwRop);

		// Token: 0x06000186 RID: 390
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x06000187 RID: 391
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x06000188 RID: 392
		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

		// Token: 0x06000189 RID: 393 RVA: 0x00008A10 File Offset: 0x00006C10
		public Program()
		{
			Program.ShowEffect();
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00008A20 File Offset: 0x00006C20
		public static void ShowEffect()
		{
			Program.<>c__DisplayClass13_0 CS$<>8__locals1 = new Program.<>c__DisplayClass13_0();
			CS$<>8__locals1.duration = 5;
			using (CancellationTokenSource cts = new CancellationTokenSource())
			{
				Thread thread = new Thread(delegate
				{
					Program.RunGraphics(CS$<>8__locals1.duration, cts.Token);
				});
				thread.Start();
				Bytebeat.PlayBytebeatAudio();
				Thread.Sleep(CS$<>8__locals1.duration * 1000);
				cts.Cancel();
				thread.Join();
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00008AC8 File Offset: 0x00006CC8
		private static void RunGraphics(int duration, CancellationToken token)
		{
			Thread thread = new Thread(delegate
			{
				Program.HITBMAP(token);
			});
			Thread thread2 = new Thread(delegate
			{
				Program.Squares(token);
			});
			Thread thread3 = new Thread(delegate
			{
				Program.Squares2(token);
			});
			Thread thread4 = new Thread(delegate
			{
				Program.Squares3(token);
			});
			thread.Start();
			thread2.Start();
			thread3.Start();
			thread4.Start();
			while (!token.IsCancellationRequested)
			{
				Thread.Sleep(100);
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00008B69 File Offset: 0x00006D69
		private static void Sleep(int milliseconds)
		{
			Thread.Sleep(milliseconds);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00008B74 File Offset: 0x00006D74
		private static int[] GetScreenDimensions()
		{
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			return new int[] { systemMetrics, systemMetrics2 };
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00008BA4 File Offset: 0x00006DA4
		private static int GenerateBrightColor()
		{
			int num = Program.random.Next(128, 256);
			int num2 = Program.random.Next(128, 256);
			int num3 = Program.random.Next(128, 256);
			return (num << 16) | (num2 << 8) | num3;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00008C00 File Offset: 0x00006E00
		private static void HITBMAP(CancellationToken token)
		{
			while (!token.IsCancellationRequested)
			{
				IntPtr dc = Program.GetDC(IntPtr.Zero);
				int[] screenDimensions = Program.GetScreenDimensions();
				int num = screenDimensions[0];
				int num2 = screenDimensions[1];
				int num3 = Program.GenerateBrightColor();
				IntPtr intPtr = Program.CreateSolidBrush(num3);
				Program.SelectObject(dc, intPtr);
				Program.PatBlt(dc, 9, 9, num, num2, 5898313U);
				Program.DeleteObject(intPtr);
				Program.Sleep(1000);
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00008C7C File Offset: 0x00006E7C
		private static void Squares(CancellationToken token)
		{
			int[] screenDimensions = Program.GetScreenDimensions();
			int num = screenDimensions[0];
			int num2 = screenDimensions[1];
			while (!token.IsCancellationRequested)
			{
				IntPtr dc = Program.GetDC(IntPtr.Zero);
				int num3 = Program.random.Next(0, num);
				int num4 = Program.random.Next(0, num2);
				int num5 = Program.random.Next(50, 150);
				int num6 = Program.random.Next(16711680, 16777215);
				IntPtr intPtr = Program.CreateSolidBrush(num6);
				Program.SelectObject(dc, intPtr);
				Program.PatBlt(dc, num3, num4, num5, num5, 13369376U);
				Program.Sleep(Program.random.Next(50, 150));
				Program.DeleteObject(intPtr);
				Program.Sleep(Program.random.Next(100, 300));
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00008D60 File Offset: 0x00006F60
		private static void Squares2(CancellationToken token)
		{
			int[] screenDimensions = Program.GetScreenDimensions();
			int num = screenDimensions[0];
			int num2 = screenDimensions[1];
			while (!token.IsCancellationRequested)
			{
				IntPtr dc = Program.GetDC(IntPtr.Zero);
				int num3 = Program.random.Next(0, num);
				int num4 = Program.random.Next(0, num2);
				int num5 = Program.random.Next(50, 300);
				int num6 = Program.random.Next(50, 300);
				int num7 = Program.random.Next(16711935, 16777215);
				IntPtr intPtr = Program.CreateSolidBrush(num7);
				Program.SelectObject(dc, intPtr);
				Program.PatBlt(dc, num3 + Program.random.Next(-10, 10), num4 + Program.random.Next(-10, 10), num5, num6, 13369376U);
				Program.Sleep(Program.random.Next(50, 150));
				Program.DeleteObject(intPtr);
				Program.Sleep(Program.random.Next(100, 300));
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00008E74 File Offset: 0x00007074
		private static void Squares3(CancellationToken token)
		{
			int[] screenDimensions = Program.GetScreenDimensions();
			int num = screenDimensions[0];
			int num2 = screenDimensions[1];
			while (!token.IsCancellationRequested)
			{
				IntPtr dc = Program.GetDC(IntPtr.Zero);
				int num3 = Program.random.Next(0, num);
				int num4 = Program.random.Next(0, num2);
				int num5 = Program.random.Next(20, 100);
				int num6 = Program.random.Next(255, 16777215);
				IntPtr intPtr = Program.CreateSolidBrush(num6);
				Program.SelectObject(dc, intPtr);
				for (int i = 0; i < 5; i++)
				{
					Program.PatBlt(dc, num3, num4, num5, num5, 13369376U);
					Program.Sleep(50);
				}
				Program.DeleteObject(intPtr);
				Program.Sleep(Program.random.Next(200, 600));
			}
		}

		// Token: 0x04000082 RID: 130
		private const int SM_CXSCREEN = 0;

		// Token: 0x04000083 RID: 131
		private const int SM_CYSCREEN = 1;

		// Token: 0x04000084 RID: 132
		private const uint SRCCOPY = 13369376U;

		// Token: 0x04000085 RID: 133
		private static Random random = new Random();
	}
}
