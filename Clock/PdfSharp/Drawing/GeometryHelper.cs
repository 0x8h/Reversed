using System;
using System.Collections.Generic;

namespace PdfSharp.Drawing
{
	// Token: 0x02000038 RID: 56
	internal static class GeometryHelper
	{
		// Token: 0x0600012B RID: 299 RVA: 0x00009B54 File Offset: 0x00007D54
		public static List<XPoint> BezierCurveFromArc(double x, double y, double width, double height, double startAngle, double sweepAngle, PathStart pathStart, ref XMatrix matrix)
		{
			List<XPoint> list = new List<XPoint>();
			double num = startAngle;
			if (num < 0.0)
			{
				num += (1.0 + Math.Floor(Math.Abs(num) / 360.0)) * 360.0;
			}
			else if (num > 360.0)
			{
				num -= Math.Floor(num / 360.0) * 360.0;
			}
			double num2 = sweepAngle;
			if (num2 < -360.0)
			{
				num2 = -360.0;
			}
			else if (num2 > 360.0)
			{
				num2 = 360.0;
			}
			if (num == 0.0 && num2 < 0.0)
			{
				num = 360.0;
			}
			else if (num == 360.0 && num2 > 0.0)
			{
				num = 0.0;
			}
			bool flag = Math.Abs(num2) <= 90.0;
			num2 = num + num2;
			if (num2 < 0.0)
			{
				num2 += (1.0 + Math.Floor(Math.Abs(num2) / 360.0)) * 360.0;
			}
			bool flag2 = sweepAngle > 0.0;
			int num3 = GeometryHelper.Quadrant(num, true, flag2);
			int num4 = GeometryHelper.Quadrant(num2, false, flag2);
			if (num3 == num4 && flag)
			{
				GeometryHelper.AppendPartialArcQuadrant(list, x, y, width, height, num, num2, pathStart, matrix);
			}
			else
			{
				int num5 = num3;
				bool flag3 = true;
				for (;;)
				{
					if (num5 == num3 && flag3)
					{
						double num6 = (double)(num5 * 90 + (flag2 ? 90 : 0));
						GeometryHelper.AppendPartialArcQuadrant(list, x, y, width, height, num, num6, pathStart, matrix);
					}
					else if (num5 == num4)
					{
						double num7 = (double)(num5 * 90 + (flag2 ? 0 : 90));
						GeometryHelper.AppendPartialArcQuadrant(list, x, y, width, height, num7, num2, PathStart.Ignore1st, matrix);
					}
					else
					{
						double num8 = (double)(num5 * 90 + (flag2 ? 0 : 90));
						double num9 = (double)(num5 * 90 + (flag2 ? 90 : 0));
						GeometryHelper.AppendPartialArcQuadrant(list, x, y, width, height, num8, num9, PathStart.Ignore1st, matrix);
					}
					if (num5 == num4 && flag)
					{
						break;
					}
					flag = true;
					if (flag2)
					{
						num5 = ((num5 == 3) ? 0 : (num5 + 1));
					}
					else
					{
						num5 = ((num5 == 0) ? 3 : (num5 - 1));
					}
					flag3 = false;
				}
			}
			return list;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00009DB8 File Offset: 0x00007FB8
		private static int Quadrant(double φ, bool start, bool clockwise)
		{
			if (φ > 360.0)
			{
				φ -= Math.Floor(φ / 360.0) * 360.0;
			}
			int num = (int)(φ / 90.0);
			if ((double)(num * 90) == φ)
			{
				if ((start && !clockwise) || (!start && clockwise))
				{
					num = ((num == 0) ? 3 : (num - 1));
				}
			}
			else
			{
				num = (clockwise ? ((int)Math.Floor(φ / 90.0) % 4) : ((int)Math.Floor(φ / 90.0)));
			}
			return num;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00009E48 File Offset: 0x00008048
		private static void AppendPartialArcQuadrant(List<XPoint> points, double x, double y, double width, double height, double α, double β, PathStart pathStart, XMatrix matrix)
		{
			if (β > 360.0)
			{
				β -= Math.Floor(β / 360.0) * 360.0;
			}
			double num = width / 2.0;
			double num2 = height / 2.0;
			double num3 = x + num;
			double num4 = y + num2;
			bool flag = false;
			if (α >= 180.0 && β >= 180.0)
			{
				α -= 180.0;
				β -= 180.0;
				flag = true;
			}
			double num5;
			double num6;
			if (width == height)
			{
				α *= 0.017453292519943295;
				β *= 0.017453292519943295;
			}
			else
			{
				α *= 0.017453292519943295;
				num5 = Math.Sin(α);
				if (Math.Abs(num5) > 1E-10)
				{
					α = 1.5707963267948966 - Math.Atan(num2 * Math.Cos(α) / (num * num5));
				}
				β *= 0.017453292519943295;
				num6 = Math.Sin(β);
				if (Math.Abs(num6) > 1E-10)
				{
					β = 1.5707963267948966 - Math.Atan(num2 * Math.Cos(β) / (num * num6));
				}
			}
			double num7 = 4.0 * (1.0 - Math.Cos((α - β) / 2.0)) / (3.0 * Math.Sin((β - α) / 2.0));
			num5 = Math.Sin(α);
			double num8 = Math.Cos(α);
			num6 = Math.Sin(β);
			double num9 = Math.Cos(β);
			if (!flag)
			{
				switch (pathStart)
				{
				case PathStart.MoveTo1st:
					points.Add(matrix.Transform(new XPoint(num3 + num * num8, num4 + num2 * num5)));
					break;
				case PathStart.LineTo1st:
					points.Add(matrix.Transform(new XPoint(num3 + num * num8, num4 + num2 * num5)));
					break;
				}
				points.Add(matrix.Transform(new XPoint(num3 + num * (num8 - num7 * num5), num4 + num2 * (num5 + num7 * num8))));
				points.Add(matrix.Transform(new XPoint(num3 + num * (num9 + num7 * num6), num4 + num2 * (num6 - num7 * num9))));
				points.Add(matrix.Transform(new XPoint(num3 + num * num9, num4 + num2 * num6)));
				return;
			}
			switch (pathStart)
			{
			case PathStart.MoveTo1st:
				points.Add(matrix.Transform(new XPoint(num3 - num * num8, num4 - num2 * num5)));
				break;
			case PathStart.LineTo1st:
				points.Add(matrix.Transform(new XPoint(num3 - num * num8, num4 - num2 * num5)));
				break;
			}
			points.Add(matrix.Transform(new XPoint(num3 - num * (num8 - num7 * num5), num4 - num2 * (num5 + num7 * num8))));
			points.Add(matrix.Transform(new XPoint(num3 - num * (num9 + num7 * num6), num4 - num2 * (num6 - num7 * num9))));
			points.Add(matrix.Transform(new XPoint(num3 - num * num9, num4 - num2 * num6)));
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000A19C File Offset: 0x0000839C
		public static List<XPoint> BezierCurveFromArc(XPoint point1, XPoint point2, XSize size, double rotationAngle, bool isLargeArc, bool clockwise, PathStart pathStart)
		{
			double width = size.Width;
			double height = size.Height;
			double num = height / width;
			bool flag = !clockwise;
			XMatrix xmatrix = default(XMatrix);
			xmatrix.RotateAppend(-rotationAngle);
			xmatrix.ScaleAppend(height / width, 1.0);
			XPoint xpoint = xmatrix.Transform(point1);
			XPoint xpoint2 = xmatrix.Transform(point2);
			XPoint xpoint3 = new XPoint((xpoint.X + xpoint2.X) / 2.0, (xpoint.Y + xpoint2.Y) / 2.0);
			XVector xvector = xpoint2 - xpoint;
			double num2 = xvector.Length / 2.0;
			XVector xvector2;
			if (isLargeArc == flag)
			{
				xvector2 = new XVector(-xvector.Y, xvector.X);
			}
			else
			{
				xvector2 = new XVector(xvector.Y, -xvector.X);
			}
			xvector2.Normalize();
			double num3 = Math.Sqrt(height * height - num2 * num2);
			if (double.IsNaN(num3))
			{
				num3 = 0.0;
			}
			XPoint xpoint4 = xpoint3 + num3 * xvector2;
			double num4 = Math.Atan2(xpoint.Y - xpoint4.Y, xpoint.X - xpoint4.X);
			double num5 = Math.Atan2(xpoint2.Y - xpoint4.Y, xpoint2.X - xpoint4.X);
			if (isLargeArc == Math.Abs(num5 - num4) < 3.1415926535897931)
			{
				if (num4 < num5)
				{
					num4 += 6.2831853071795862;
				}
				else
				{
					num5 += 6.2831853071795862;
				}
			}
			xmatrix.Invert();
			double num6 = num5 - num4;
			return GeometryHelper.BezierCurveFromArc(xpoint4.X - width * num, xpoint4.Y - height, 2.0 * width * num, 2.0 * height, num4 / 0.017453292519943295, num6 / 0.017453292519943295, pathStart, ref xmatrix);
		}
	}
}
