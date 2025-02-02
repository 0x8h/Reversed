using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace CUBE
{
	// Token: 0x0200000D RID: 13
	internal class Program
	{
		// Token: 0x06000066 RID: 102
		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);

		// Token: 0x06000067 RID: 103
		[DllImport("user32.dll")]
		public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		// Token: 0x06000068 RID: 104
		[DllImport("user32.dll")]
		public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

		// Token: 0x06000069 RID: 105
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr LoadIcon(IntPtr hInstance, int lpIconName);

		// Token: 0x0600006A RID: 106
		[DllImport("user32.dll")]
		public static extern bool DrawIcon(IntPtr hdc, int x, int y, IntPtr hIcon);

		// Token: 0x0600006B RID: 107
		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateSolidBrush(uint crColor);

		// Token: 0x0600006C RID: 108
		[DllImport("gdi32.dll")]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

		// Token: 0x0600006D RID: 109
		[DllImport("gdi32.dll")]
		public static extern bool Rectangle(IntPtr hdc, int left, int top, int right, int bottom);

		// Token: 0x0600006E RID: 110
		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x0600006F RID: 111
		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(int nIndex);

		// Token: 0x06000070 RID: 112 RVA: 0x00003C09 File Offset: 0x00001E09
		public static void ShowEffect()
		{
			Program.warningIcon = Program.LoadIcon(IntPtr.Zero, 32515);
			Program.dc = Program.GetDC(IntPtr.Zero);
			Program.SphereWithXor(3);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003C38 File Offset: 0x00001E38
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

		// Token: 0x06000072 RID: 114 RVA: 0x00003C8C File Offset: 0x00001E8C
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

		// Token: 0x06000073 RID: 115 RVA: 0x00003CE0 File Offset: 0x00001EE0
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

		// Token: 0x06000074 RID: 116 RVA: 0x00003D34 File Offset: 0x00001F34
		private static void DrawIconAtVertexWithRed(IntPtr dc, IntPtr icon, double x, double y)
		{
			Program.DrawIcon(dc, (int)x, (int)y, icon);
			uint num = 255U;
			IntPtr intPtr = Program.CreateSolidBrush(num);
			IntPtr intPtr2 = Program.SelectObject(dc, intPtr);
			int num2 = 32;
			int num3 = 32;
			Program.Rectangle(dc, (int)x, (int)y, (int)x + num2, (int)y + num3);
			Program.SelectObject(dc, intPtr2);
			Program.DeleteObject(intPtr);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003D90 File Offset: 0x00001F90
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
					Program.DrawIconAtVertexWithRed(Program.dc, Program.warningIcon, array5[0] + num2, array5[1] + num3);
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

		// Token: 0x04000028 RID: 40
		private const int SM_CXSCREEN = 0;

		// Token: 0x04000029 RID: 41
		private const int SM_CYSCREEN = 1;

		// Token: 0x0400002A RID: 42
		private const int IDI_WARNING = 32515;

		// Token: 0x0400002B RID: 43
		private static IntPtr warningIcon;

		// Token: 0x0400002C RID: 44
		private static IntPtr dc;
	}
}
