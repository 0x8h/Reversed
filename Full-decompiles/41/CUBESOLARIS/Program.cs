using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace CUBESOLARIS
{
	// Token: 0x02000022 RID: 34
	internal class Program
	{
		// Token: 0x06000152 RID: 338
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x06000153 RID: 339
		[DllImport("user32.dll", SetLastError = true)]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x06000154 RID: 340
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

		// Token: 0x06000155 RID: 341
		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern IntPtr CreateSolidBrush(uint crColor);

		// Token: 0x06000156 RID: 342
		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

		// Token: 0x06000157 RID: 343
		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern bool Ellipse(IntPtr hdc, int left, int top, int right, int bottom);

		// Token: 0x06000158 RID: 344
		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x06000159 RID: 345
		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern IntPtr CreateFontW(int cHeight, int cWidth, int cEscapement, int cOrientation, int cWeight, bool bItalic, bool bUnderline, bool bStrikeOut, uint iCharSet, uint iOutPrecision, uint iClipPrecision, uint iQuality, uint iPitchAndFamily, string pszFaceName);

		// Token: 0x0600015A RID: 346
		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern bool TextOutW(IntPtr hdc, int x, int y, string lpString, int c);

		// Token: 0x0600015B RID: 347
		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

		// Token: 0x0600015C RID: 348 RVA: 0x00007CD0 File Offset: 0x00005ED0
		public static Tuple<double, double, double> Rotate(Tuple<double, double, double> vertex, Tuple<double, double, double> angles)
		{
			double item = angles.Item1;
			double item2 = angles.Item2;
			double item3 = angles.Item3;
			double num = vertex.Item2 * Math.Cos(item) - vertex.Item3 * Math.Sin(item);
			double num2 = vertex.Item2 * Math.Sin(item) + vertex.Item3 * Math.Cos(item);
			vertex = new Tuple<double, double, double>(vertex.Item1, num, num2);
			double num3 = vertex.Item1 * Math.Cos(item2) + vertex.Item3 * Math.Sin(item2);
			num2 = -vertex.Item1 * Math.Sin(item2) + vertex.Item3 * Math.Cos(item2);
			vertex = new Tuple<double, double, double>(num3, vertex.Item2, num2);
			num3 = vertex.Item1 * Math.Cos(item3) - vertex.Item2 * Math.Sin(item3);
			num = vertex.Item1 * Math.Sin(item3) + vertex.Item2 * Math.Cos(item3);
			return new Tuple<double, double, double>(num3, num, vertex.Item3);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00007DD8 File Offset: 0x00005FD8
		public static void DrawRedCircle(IntPtr dc, double x, double y, double radius)
		{
			IntPtr intPtr = Program.CreateSolidBrush(255U);
			Program.SelectObject(dc, intPtr);
			Program.Ellipse(dc, (int)(x - radius), (int)(y - radius), (int)(x + radius), (int)(y + radius));
			Program.DeleteObject(intPtr);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00007E18 File Offset: 0x00006018
		public static void DrawText(IntPtr dc, string text, int x, int y)
		{
			IntPtr intPtr = Program.CreateFontW(24, 0, 0, 0, 400, false, false, false, 0U, 0U, 0U, 0U, 0U, null);
			Program.SelectObject(dc, intPtr);
			Program.TextOutW(dc, x, y, text, text.Length);
			Program.DeleteObject(intPtr);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00007E60 File Offset: 0x00006060
		public static void BitBltPattern(IntPtr hdc, int duration)
		{
			Random random = new Random();
			int tickCount = Environment.TickCount;
			while (Environment.TickCount - tickCount < duration * 1000)
			{
				int num = random.Next(0, Program.GetSystemMetrics(0));
				int num2 = random.Next(0, Program.GetSystemMetrics(1));
				Program.BitBlt(hdc, num, num2, 200, 200, hdc, num - random.Next(-10, 10), num2 - random.Next(-10, 10), 15597702);
				Thread.Sleep(2);
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00007EE8 File Offset: 0x000060E8
		public static void SphereWithXor(int duration)
		{
			IntPtr dc = Program.GetDC(IntPtr.Zero);
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			double num = (double)(systemMetrics + systemMetrics2) / 20.0;
			double num2 = num;
			double num3 = num;
			Tuple<double, double, double> tuple = new Tuple<double, double, double>(0.01, 0.01, 0.01);
			Tuple<double, double, double>[] array = new Tuple<double, double, double>[441];
			int num4 = 0;
			for (int i = 0; i <= 20; i++)
			{
				for (int j = 0; j <= 20; j++)
				{
					double num5 = ((double)i - 10.0) / 10.0;
					double num6 = ((double)j - 10.0) / 10.0;
					double num7 = num * Math.Cos(3.1415926535897931 * num5) * Math.Cos(6.2831853071795862 * num6);
					double num8 = num * Math.Cos(3.1415926535897931 * num5) * Math.Sin(6.2831853071795862 * num6);
					double num9 = num * Math.Sin(3.1415926535897931 * num5);
					array[num4++] = new Tuple<double, double, double>(num7, num8, num9);
				}
			}
			IntPtr hdc = Program.GetDC(IntPtr.Zero);
			Thread thread = new Thread(delegate
			{
				Program.BitBltPattern(hdc, duration);
			});
			thread.Start();
			int tickCount = Environment.TickCount;
			while (Environment.TickCount - tickCount < duration * 1000)
			{
				Program.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
				for (int k = 0; k < 10; k++)
				{
					Program.DrawText(dc, "", new Random().Next(0, systemMetrics), new Random().Next(0, systemMetrics2));
				}
				for (int l = 0; l < array.Length; l++)
				{
					array[l] = Program.Rotate(array[l], tuple);
					Program.DrawRedCircle(dc, array[l].Item1 + num2, array[l].Item2 + num3, 5.0);
				}
				num2 += 2.0;
				num3 += 1.0;
				Thread.Sleep(15);
			}
			thread.Join();
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00008180 File Offset: 0x00006380
		public static void CUBE()
		{
			int duration = 20;
			Thread thread = new Thread(delegate
			{
				Program.SphereWithXor(duration);
			});
			thread.Start();
			thread.Join();
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000081BC File Offset: 0x000063BC
		public static void StartEffects()
		{
			Thread thread = new Thread(delegate
			{
				Program.CUBE();
			});
			Thread thread2 = new Thread(delegate
			{
				Bytebeat.PlayBytebeatAudio();
			});
			thread.Start();
			thread2.Start();
			thread.Join();
			thread2.Join();
		}
	}
}
