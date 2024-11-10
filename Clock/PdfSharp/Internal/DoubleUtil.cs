using System;
using System.Runtime.InteropServices;
using PdfSharp.Drawing;

namespace PdfSharp.Internal
{
	// Token: 0x020000BD RID: 189
	internal static class DoubleUtil
	{
		// Token: 0x060007BA RID: 1978 RVA: 0x0001DB58 File Offset: 0x0001BD58
		public static bool AreClose(double value1, double value2)
		{
			if (value1.Equals(value2))
			{
				return true;
			}
			double num = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * 2.2204460492503131E-16;
			double num2 = value1 - value2;
			return -num < num2 && num > num2;
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0001DBA2 File Offset: 0x0001BDA2
		public static bool AreRoughlyEqual(double value1, double value2, int decimalPlace)
		{
			return value1 == value2 || Math.Abs(value1 - value2) < DoubleUtil.decs[decimalPlace];
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0001DBBB File Offset: 0x0001BDBB
		public static bool AreClose(XPoint point1, XPoint point2)
		{
			return DoubleUtil.AreClose(point1.X, point2.X) && DoubleUtil.AreClose(point1.Y, point2.Y);
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0001DBE8 File Offset: 0x0001BDE8
		public static bool AreClose(XRect rect1, XRect rect2)
		{
			if (rect1.IsEmpty)
			{
				return rect2.IsEmpty;
			}
			return !rect2.IsEmpty && DoubleUtil.AreClose(rect1.X, rect2.X) && DoubleUtil.AreClose(rect1.Y, rect2.Y) && DoubleUtil.AreClose(rect1.Height, rect2.Height) && DoubleUtil.AreClose(rect1.Width, rect2.Width);
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0001DC63 File Offset: 0x0001BE63
		public static bool AreClose(XSize size1, XSize size2)
		{
			return DoubleUtil.AreClose(size1.Width, size2.Width) && DoubleUtil.AreClose(size1.Height, size2.Height);
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0001DC8F File Offset: 0x0001BE8F
		public static bool AreClose(XVector vector1, XVector vector2)
		{
			return DoubleUtil.AreClose(vector1.X, vector2.X) && DoubleUtil.AreClose(vector1.Y, vector2.Y);
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x0001DCBB File Offset: 0x0001BEBB
		public static bool GreaterThan(double value1, double value2)
		{
			return value1 > value2 && !DoubleUtil.AreClose(value1, value2);
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0001DCCD File Offset: 0x0001BECD
		public static bool GreaterThanOrClose(double value1, double value2)
		{
			return value1 > value2 || DoubleUtil.AreClose(value1, value2);
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0001DCDC File Offset: 0x0001BEDC
		public static bool LessThan(double value1, double value2)
		{
			return value1 < value2 && !DoubleUtil.AreClose(value1, value2);
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0001DCEE File Offset: 0x0001BEEE
		public static bool LessThanOrClose(double value1, double value2)
		{
			return value1 < value2 || DoubleUtil.AreClose(value1, value2);
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0001DCFD File Offset: 0x0001BEFD
		public static bool IsBetweenZeroAndOne(double value)
		{
			return DoubleUtil.GreaterThanOrClose(value, 0.0) && DoubleUtil.LessThanOrClose(value, 1.0);
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0001DD24 File Offset: 0x0001BF24
		public static bool IsNaN(double value)
		{
			DoubleUtil.NanUnion nanUnion = default(DoubleUtil.NanUnion);
			nanUnion.DoubleValue = value;
			ulong num = nanUnion.UintValue & 18442240474082181120UL;
			ulong num2 = nanUnion.UintValue & 4503599627370495UL;
			return (num == 9218868437227405312UL || num == 18442240474082181120UL) && num2 != 0UL;
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x0001DD87 File Offset: 0x0001BF87
		public static bool RectHasNaN(XRect r)
		{
			return DoubleUtil.IsNaN(r.X) || DoubleUtil.IsNaN(r.Y) || DoubleUtil.IsNaN(r.Height) || DoubleUtil.IsNaN(r.Width);
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x0001DDC1 File Offset: 0x0001BFC1
		public static bool IsOne(double value)
		{
			return Math.Abs(value - 1.0) < 2.2204460492503131E-15;
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x0001DDDE File Offset: 0x0001BFDE
		public static bool IsZero(double value)
		{
			return Math.Abs(value) < 2.2204460492503131E-15;
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x0001DDF1 File Offset: 0x0001BFF1
		public static int DoubleToInt(double value)
		{
			if (0.0 >= value)
			{
				return (int)(value - 0.5);
			}
			return (int)(value + 0.5);
		}

		// Token: 0x0400041F RID: 1055
		private const double Epsilon = 2.2204460492503131E-16;

		// Token: 0x04000420 RID: 1056
		private const double TenTimesEpsilon = 2.2204460492503131E-15;

		// Token: 0x04000421 RID: 1057
		private const float FloatMinimum = 1.175494E-38f;

		// Token: 0x04000422 RID: 1058
		private static readonly double[] decs = new double[]
		{
			1.0, 0.1, 0.01, 0.001, 0.0001, 1E-05, 1E-06, 1E-07, 1E-08, 1E-09,
			1E-10, 1E-11, 1E-12, 1E-13, 1E-14, 1E-15, 1E-16
		};

		// Token: 0x020000BE RID: 190
		[StructLayout(LayoutKind.Explicit)]
		private struct NanUnion
		{
			// Token: 0x04000423 RID: 1059
			[FieldOffset(0)]
			internal double DoubleValue;

			// Token: 0x04000424 RID: 1060
			[FieldOffset(0)]
			internal readonly ulong UintValue;
		}
	}
}
