using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace DDT
{
	// Token: 0x0200001F RID: 31
	internal class Program
	{
		// Token: 0x0600012F RID: 303
		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);

		// Token: 0x06000130 RID: 304
		[DllImport("user32.dll")]
		public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		// Token: 0x06000131 RID: 305
		[DllImport("user32.dll")]
		public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

		// Token: 0x06000132 RID: 306
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr LoadIcon(IntPtr hInstance, int lpIconName);

		// Token: 0x06000133 RID: 307
		[DllImport("user32.dll")]
		public static extern bool DrawIcon(IntPtr hdc, int x, int y, IntPtr hIcon);

		// Token: 0x06000134 RID: 308
		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(int nIndex);

		// Token: 0x06000135 RID: 309 RVA: 0x00007408 File Offset: 0x00005608
		public static void ShowEffect()
		{
			Program.warningIcon = Program.LoadIcon(IntPtr.Zero, 32515);
			Program.dc = Program.GetDC(IntPtr.Zero);
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			double num = (double)systemMetrics / 2.0;
			double num2 = (double)systemMetrics2 / 2.0;
			Program.DrawRotatingCube(20, 100.0, num, num2);
			Program.ReleaseDC(IntPtr.Zero, Program.dc);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00007484 File Offset: 0x00005684
		private static void DrawRotatingCube(int duration, double size, double cx, double cy)
		{
			DateTime now = DateTime.Now;
			while ((DateTime.Now - now).TotalSeconds < (double)duration)
			{
				Program.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
				Program.DrawCube(cx, cy, size);
				Program.angle += 8.78;
				Thread.Sleep(20);
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000074F0 File Offset: 0x000056F0
		private static void DrawCube(double cx, double cy, double size)
		{
			double num = size / 2.0;
			double[][] array = new double[][]
			{
				new double[]
				{
					cx - num,
					cy - num,
					num
				},
				new double[]
				{
					cx + num,
					cy - num,
					num
				},
				new double[]
				{
					cx + num,
					cy + num,
					num
				},
				new double[]
				{
					cx - num,
					cy + num,
					num
				},
				new double[]
				{
					cx - num,
					cy - num,
					-num
				},
				new double[]
				{
					cx + num,
					cy - num,
					-num
				},
				new double[]
				{
					cx + num,
					cy + num,
					-num
				},
				new double[]
				{
					cx - num,
					cy + num,
					-num
				}
			};
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Program.RotateX(array[i], Program.angle);
				array[i] = Program.RotateY(array[i], Program.angle);
				array[i] = Program.RotateZ(array[i], Program.angle);
			}
			foreach (double[] array3 in array)
			{
				Program.DrawIconAtVertex(Program.dc, Program.warningIcon, array3[0], array3[1]);
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000765C File Offset: 0x0000585C
		private static double[] RotateX(double[] vertex, double angle)
		{
			double num = vertex[1] * Math.Cos(angle) - vertex[2] * Math.Sin(angle);
			double num2 = vertex[1] * Math.Sin(angle) + vertex[2] * Math.Cos(angle);
			return new double[]
			{
				vertex[0],
				num,
				num2
			};
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000076B0 File Offset: 0x000058B0
		private static double[] RotateY(double[] vertex, double angle)
		{
			double num = vertex[0] * Math.Cos(angle) + vertex[2] * Math.Sin(angle);
			double num2 = -vertex[0] * Math.Sin(angle) + vertex[2] * Math.Cos(angle);
			return new double[]
			{
				num,
				vertex[1],
				num2
			};
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00007704 File Offset: 0x00005904
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

		// Token: 0x0600013B RID: 315 RVA: 0x00007756 File Offset: 0x00005956
		private static void DrawIconAtVertex(IntPtr dc, IntPtr icon, double x, double y)
		{
			Program.DrawIcon(dc, (int)x, (int)y, icon);
		}

		// Token: 0x0400006E RID: 110
		private const int SM_CXSCREEN = 0;

		// Token: 0x0400006F RID: 111
		private const int SM_CYSCREEN = 1;

		// Token: 0x04000070 RID: 112
		private const int IDI_WARNING = 32515;

		// Token: 0x04000071 RID: 113
		private static IntPtr warningIcon;

		// Token: 0x04000072 RID: 114
		private static IntPtr dc;

		// Token: 0x04000073 RID: 115
		private static double angle;
	}
}
