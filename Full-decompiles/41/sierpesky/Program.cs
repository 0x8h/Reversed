using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace sierpesky
{
	// Token: 0x0200001D RID: 29
	internal class Program
	{
		// Token: 0x0600011B RID: 283
		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);

		// Token: 0x0600011C RID: 284
		[DllImport("user32.dll")]
		public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		// Token: 0x0600011D RID: 285
		[DllImport("user32.dll")]
		public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

		// Token: 0x0600011E RID: 286
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr LoadIcon(IntPtr hInstance, int lpIconName);

		// Token: 0x0600011F RID: 287
		[DllImport("user32.dll")]
		public static extern bool DrawIcon(IntPtr hdc, int x, int y, IntPtr hIcon);

		// Token: 0x06000120 RID: 288
		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(int nIndex);

		// Token: 0x06000121 RID: 289 RVA: 0x00006F48 File Offset: 0x00005148
		public static void ShowEffect()
		{
			Program.warningIcon = Program.LoadIcon(IntPtr.Zero, 32515);
			Program.dc = Program.GetDC(IntPtr.Zero);
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			double num = (double)systemMetrics / 2.0;
			double num2 = (double)systemMetrics2 / 2.0;
			Thread thread = new Thread(new ThreadStart(Bytebeat.PlayBytebeatAudio));
			thread.Start();
			Program.SierpinskiWithRotation(20, 200.0, num, num2);
			thread.Join();
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00006FD8 File Offset: 0x000051D8
		private static void SierpinskiWithRotation(int duration, double size, double cx, double cy)
		{
			DateTime now = DateTime.Now;
			while ((DateTime.Now - now).TotalSeconds < (double)duration)
			{
				Program.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
				Program.DrawTriangleRecursive(5, cx, cy, size);
				Program.angle += 0.05;
				Thread.Sleep(20);
			}
			Program.ReleaseDC(IntPtr.Zero, Program.dc);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00007054 File Offset: 0x00005254
		private static void DrawTriangleRecursive(int depth, double cx, double cy, double size)
		{
			bool flag = depth == 0;
			if (flag)
			{
				double num = size / 2.0;
				double[][] array = new double[3][];
				double[][] array2 = array;
				int num2 = 0;
				double[] array3 = new double[3];
				array3[0] = cx;
				array3[1] = cy - num;
				array2[num2] = Program.RotateZ(array3, Program.angle);
				double[][] array4 = array;
				int num3 = 1;
				double[] array5 = new double[3];
				array5[0] = cx - num;
				array5[1] = cy + num;
				array4[num3] = Program.RotateZ(array5, Program.angle);
				double[][] array6 = array;
				int num4 = 2;
				double[] array7 = new double[3];
				array7[0] = cx + num;
				array7[1] = cy + num;
				array6[num4] = Program.RotateZ(array7, Program.angle);
				Program.DrawIconAtVertex(Program.dc, Program.warningIcon, array[0][0], array[0][1]);
				Program.DrawIconAtVertex(Program.dc, Program.warningIcon, array[1][0], array[1][1]);
				Program.DrawIconAtVertex(Program.dc, Program.warningIcon, array[2][0], array[2][1]);
			}
			else
			{
				double num5 = size / 2.0;
				double num6 = num5 / 2.0;
				Program.DrawTriangleRecursive(depth - 1, cx, cy - num6, num5);
				Program.DrawTriangleRecursive(depth - 1, cx - num6, cy + num6, num5);
				Program.DrawTriangleRecursive(depth - 1, cx + num6, cy + num6, num5);
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000717C File Offset: 0x0000537C
		private static double[] RotateZ(double[] vertex, double angle)
		{
			double num = vertex[0] * Math.Cos(angle) - vertex[1] * Math.Sin(angle);
			double num2 = vertex[0] * Math.Sin(angle) + vertex[1] * Math.Cos(angle);
			return new double[]
			{
				num,
				num2,
				vertex[2]
			};
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000071CE File Offset: 0x000053CE
		private static void DrawIconAtVertex(IntPtr dc, IntPtr icon, double x, double y)
		{
			Program.DrawIcon(dc, (int)x, (int)y, icon);
		}

		// Token: 0x04000064 RID: 100
		private const int SM_CXSCREEN = 0;

		// Token: 0x04000065 RID: 101
		private const int SM_CYSCREEN = 1;

		// Token: 0x04000066 RID: 102
		private const int IDI_WARNING = 32515;

		// Token: 0x04000067 RID: 103
		private static IntPtr warningIcon;

		// Token: 0x04000068 RID: 104
		private static IntPtr dc;

		// Token: 0x04000069 RID: 105
		private static double angle;
	}
}
