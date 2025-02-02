using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace CUBE2
{
	// Token: 0x0200000E RID: 14
	internal class Program
	{
		// Token: 0x06000077 RID: 119
		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);

		// Token: 0x06000078 RID: 120
		[DllImport("user32.dll")]
		public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		// Token: 0x06000079 RID: 121
		[DllImport("user32.dll")]
		public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

		// Token: 0x0600007A RID: 122
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr LoadIcon(IntPtr hInstance, int lpIconName);

		// Token: 0x0600007B RID: 123
		[DllImport("user32.dll")]
		public static extern bool DrawIcon(IntPtr hdc, int x, int y, IntPtr hIcon);

		// Token: 0x0600007C RID: 124
		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(int nIndex);

		// Token: 0x0600007D RID: 125 RVA: 0x00004025 File Offset: 0x00002225
		public static void ShowEffect()
		{
			Program.warningIcon = Program.LoadIcon(IntPtr.Zero, 32515);
			Program.dc = Program.GetDC(IntPtr.Zero);
			Program.SphereWithXor(5);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00004054 File Offset: 0x00002254
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

		// Token: 0x0600007F RID: 127 RVA: 0x000040A8 File Offset: 0x000022A8
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

		// Token: 0x06000080 RID: 128 RVA: 0x000040FC File Offset: 0x000022FC
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

		// Token: 0x06000081 RID: 129 RVA: 0x0000414E File Offset: 0x0000234E
		private static void DrawIconAtVertex(IntPtr dc, IntPtr icon, double x, double y)
		{
			Program.DrawIcon(dc, (int)x, (int)y, icon);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00004160 File Offset: 0x00002360
		private static void SphereWithXor(int duration)
		{
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			double num = (double)(systemMetrics + systemMetrics2) / 10.0;
			double num2 = num;
			double num3 = num;
			double num4 = 20.0;
			double num5 = 20.0;
			double num6 = 0.09;
			double num7 = 0.09;
			double num8 = 0.09;
			double num9 = num / 2.0;
			int num10 = 100;
			double[][] array = new double[num10][];
			Random random = new Random();
			for (int i = 0; i < num10; i++)
			{
				double num11 = Math.Acos(2.0 * random.NextDouble() - 1.0);
				double num12 = 6.2831853071795862 * random.NextDouble();
				double num13 = num9 * Math.Sin(num11) * Math.Cos(num12);
				double num14 = num9 * Math.Sin(num11) * Math.Sin(num12);
				double num15 = num9 * Math.Cos(num11);
				array[i] = new double[] { num13, num14, num15 };
			}
			DateTime now = DateTime.Now;
			while ((DateTime.Now - now).TotalSeconds < (double)duration)
			{
				Program.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
				double[][] array2 = new double[array.Length][];
				for (int j = 0; j < array.Length; j++)
				{
					double[] array3 = Program.RotateX(array[j], num6);
					array3 = Program.RotateY(array3, num7);
					array3 = Program.RotateZ(array3, num8);
					array2[j] = array3;
				}
				foreach (double[] array5 in array2)
				{
					Program.DrawIconAtVertex(Program.dc, Program.warningIcon, array5[0] + num2, array5[1] + num3);
				}
				Thread.Sleep(20);
				num2 += num4;
				num3 += num5;
				bool flag = num2 > (double)systemMetrics - num / 2.0 || num2 < num / 2.0;
				if (flag)
				{
					num4 *= -1.0;
				}
				bool flag2 = num3 > (double)systemMetrics2 - num / 2.0 || num3 < num / 2.0;
				if (flag2)
				{
					num5 *= -1.0;
				}
			}
			Program.ReleaseDC(IntPtr.Zero, Program.dc);
		}

		// Token: 0x0400002D RID: 45
		private const int SM_CXSCREEN = 0;

		// Token: 0x0400002E RID: 46
		private const int SM_CYSCREEN = 1;

		// Token: 0x0400002F RID: 47
		private const int IDI_WARNING = 32515;

		// Token: 0x04000030 RID: 48
		private static IntPtr warningIcon;

		// Token: 0x04000031 RID: 49
		private static IntPtr dc;
	}
}
