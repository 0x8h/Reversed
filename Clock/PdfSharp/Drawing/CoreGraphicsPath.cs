using System;
using System.Collections.Generic;

namespace PdfSharp.Drawing
{
	// Token: 0x0200001F RID: 31
	internal class CoreGraphicsPath
	{
		// Token: 0x0600010F RID: 271 RVA: 0x00009124 File Offset: 0x00007324
		public CoreGraphicsPath()
		{
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00009142 File Offset: 0x00007342
		public CoreGraphicsPath(CoreGraphicsPath path)
		{
			this._points = new List<XPoint>(path._points);
			this._types = new List<byte>(path._types);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00009184 File Offset: 0x00007384
		public void MoveOrLineTo(double x, double y)
		{
			if (this._types.Count == 0 || (this._types[this._types.Count - 1] & 128) == 128)
			{
				this.MoveTo(x, y);
				return;
			}
			this.LineTo(x, y, false);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000091D5 File Offset: 0x000073D5
		public void MoveTo(double x, double y)
		{
			this._points.Add(new XPoint(x, y));
			this._types.Add(0);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000091F8 File Offset: 0x000073F8
		public void LineTo(double x, double y, bool closeSubpath)
		{
			if (this._points.Count > 0 && this._points[this._points.Count - 1].Equals(new XPoint(x, y)))
			{
				return;
			}
			this._points.Add(new XPoint(x, y));
			this._types.Add((byte)(1 | (closeSubpath ? 128 : 0)));
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00009268 File Offset: 0x00007468
		public void BezierTo(double x1, double y1, double x2, double y2, double x3, double y3, bool closeSubpath)
		{
			this._points.Add(new XPoint(x1, y1));
			this._types.Add(3);
			this._points.Add(new XPoint(x2, y2));
			this._types.Add(3);
			this._points.Add(new XPoint(x3, y3));
			this._types.Add((byte)(3 | (closeSubpath ? 128 : 0)));
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000092E0 File Offset: 0x000074E0
		public void QuadrantArcTo(double x, double y, double width, double height, int quadrant, bool clockwise)
		{
			if (width < 0.0)
			{
				throw new ArgumentOutOfRangeException("width");
			}
			if (height < 0.0)
			{
				throw new ArgumentOutOfRangeException("height");
			}
			double num = 0.55228474983079345 * width;
			double num2 = 0.55228474983079345 * height;
			double num3;
			double num4;
			double num5;
			double num6;
			double num7;
			double num8;
			switch (quadrant)
			{
			case 1:
				if (clockwise)
				{
					num3 = x + num;
					num4 = y - height;
					num5 = x + width;
					num6 = y - num2;
					num7 = x + width;
					num8 = y;
				}
				else
				{
					num3 = x + width;
					num4 = y - num2;
					num5 = x + num;
					num6 = y - height;
					num7 = x;
					num8 = y - height;
				}
				break;
			case 2:
				if (clockwise)
				{
					num3 = x - width;
					num4 = y - num2;
					num5 = x - num;
					num6 = y - height;
					num7 = x;
					num8 = y - height;
				}
				else
				{
					num3 = x - num;
					num4 = y - height;
					num5 = x - width;
					num6 = y - num2;
					num7 = x - width;
					num8 = y;
				}
				break;
			case 3:
				if (clockwise)
				{
					num3 = x - num;
					num4 = y + height;
					num5 = x - width;
					num6 = y + num2;
					num7 = x - width;
					num8 = y;
				}
				else
				{
					num3 = x - width;
					num4 = y + num2;
					num5 = x - num;
					num6 = y + height;
					num7 = x;
					num8 = y + height;
				}
				break;
			case 4:
				if (clockwise)
				{
					num3 = x + width;
					num4 = y + num2;
					num5 = x + num;
					num6 = y + height;
					num7 = x;
					num8 = y + height;
				}
				else
				{
					num3 = x + num;
					num4 = y + height;
					num5 = x + width;
					num6 = y + num2;
					num7 = x + width;
					num8 = y;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException("quadrant");
			}
			this.BezierTo(num3, num4, num5, num6, num7, num8, false);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000947C File Offset: 0x0000767C
		public void CloseSubpath()
		{
			int count = this._types.Count;
			if (count > 0)
			{
				List<byte> types;
				int num;
				(types = this._types)[num = count - 1] = types[num] | 128;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000117 RID: 279 RVA: 0x000094B9 File Offset: 0x000076B9
		// (set) Token: 0x06000118 RID: 280 RVA: 0x000094C1 File Offset: 0x000076C1
		private XFillMode FillMode
		{
			get
			{
				return this._fillMode;
			}
			set
			{
				this._fillMode = value;
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000094CC File Offset: 0x000076CC
		public void AddArc(double x, double y, double width, double height, double startAngle, double sweepAngle)
		{
			XMatrix identity = XMatrix.Identity;
			List<XPoint> list = GeometryHelper.BezierCurveFromArc(x, y, width, height, startAngle, sweepAngle, PathStart.MoveTo1st, ref identity);
			int count = list.Count;
			this.MoveOrLineTo(list[0].X, list[0].Y);
			for (int i = 1; i < count; i += 3)
			{
				this.BezierTo(list[i].X, list[i].Y, list[i + 1].X, list[i + 1].Y, list[i + 2].X, list[i + 2].Y, false);
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000959C File Offset: 0x0000779C
		public void AddArc(XPoint point1, XPoint point2, XSize size, double rotationAngle, bool isLargeArg, XSweepDirection sweepDirection)
		{
			List<XPoint> list = GeometryHelper.BezierCurveFromArc(point1, point2, size, rotationAngle, isLargeArg, sweepDirection == XSweepDirection.Clockwise, PathStart.MoveTo1st);
			int count = list.Count;
			this.MoveOrLineTo(list[0].X, list[0].Y);
			for (int i = 1; i < count; i += 3)
			{
				this.BezierTo(list[i].X, list[i].Y, list[i + 1].X, list[i + 1].Y, list[i + 2].X, list[i + 2].Y, false);
			}
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00009664 File Offset: 0x00007864
		public void AddCurve(XPoint[] points, double tension)
		{
			int num = points.Length;
			if (num < 2)
			{
				throw new ArgumentException("AddCurve requires two or more points.", "points");
			}
			tension /= 3.0;
			this.MoveOrLineTo(points[0].X, points[0].Y);
			if (num == 2)
			{
				this.ToCurveSegment(points[0], points[0], points[1], points[1], tension);
				return;
			}
			this.ToCurveSegment(points[0], points[0], points[1], points[2], tension);
			for (int i = 1; i < num - 2; i++)
			{
				this.ToCurveSegment(points[i - 1], points[i], points[i + 1], points[i + 2], tension);
			}
			this.ToCurveSegment(points[num - 3], points[num - 2], points[num - 1], points[num - 1], tension);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000097B4 File Offset: 0x000079B4
		private void ToCurveSegment(XPoint pt0, XPoint pt1, XPoint pt2, XPoint pt3, double tension3)
		{
			this.BezierTo(pt1.X + tension3 * (pt2.X - pt0.X), pt1.Y + tension3 * (pt2.Y - pt0.Y), pt2.X - tension3 * (pt3.X - pt1.X), pt2.Y - tension3 * (pt3.Y - pt1.Y), pt2.X, pt2.Y, false);
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600011D RID: 285 RVA: 0x0000983E File Offset: 0x00007A3E
		public XPoint[] PathPoints
		{
			get
			{
				return this._points.ToArray();
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600011E RID: 286 RVA: 0x0000984B File Offset: 0x00007A4B
		public byte[] PathTypes
		{
			get
			{
				return this._types.ToArray();
			}
		}

		// Token: 0x040000AB RID: 171
		private const byte PathPointTypeStart = 0;

		// Token: 0x040000AC RID: 172
		private const byte PathPointTypeLine = 1;

		// Token: 0x040000AD RID: 173
		private const byte PathPointTypeBezier = 3;

		// Token: 0x040000AE RID: 174
		private const byte PathPointTypePathTypeMask = 7;

		// Token: 0x040000AF RID: 175
		private const byte PathPointTypeCloseSubpath = 128;

		// Token: 0x040000B0 RID: 176
		private XFillMode _fillMode;

		// Token: 0x040000B1 RID: 177
		private readonly List<XPoint> _points = new List<XPoint>();

		// Token: 0x040000B2 RID: 178
		private readonly List<byte> _types = new List<byte>();
	}
}
