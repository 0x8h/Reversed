using System;
using PdfSharp.Internal;

namespace PdfSharp.Drawing
{
	// Token: 0x0200006B RID: 107
	public sealed class XGraphicsPath
	{
		// Token: 0x0600044C RID: 1100 RVA: 0x00012699 File Offset: 0x00010899
		public XGraphicsPath()
		{
			this._corePath = new CoreGraphicsPath();
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x000126AC File Offset: 0x000108AC
		public XGraphicsPath Clone()
		{
			XGraphicsPath xgraphicsPath = (XGraphicsPath)base.MemberwiseClone();
			this._corePath = new CoreGraphicsPath(this._corePath);
			return xgraphicsPath;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x000126D7 File Offset: 0x000108D7
		public void AddLine(XPoint pt1, XPoint pt2)
		{
			this.AddLine(pt1.X, pt1.Y, pt2.X, pt2.Y);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x000126FB File Offset: 0x000108FB
		public void AddLine(double x1, double y1, double x2, double y2)
		{
			this._corePath.MoveOrLineTo(x1, y1);
			this._corePath.LineTo(x2, y2, false);
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0001271C File Offset: 0x0001091C
		public void AddLines(XPoint[] points)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			int num = points.Length;
			if (num == 0)
			{
				return;
			}
			this._corePath.MoveOrLineTo(points[0].X, points[0].Y);
			for (int i = 1; i < num; i++)
			{
				this._corePath.LineTo(points[i].X, points[i].Y, false);
			}
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00012794 File Offset: 0x00010994
		public void AddBezier(XPoint pt1, XPoint pt2, XPoint pt3, XPoint pt4)
		{
			this.AddBezier(pt1.X, pt1.Y, pt2.X, pt2.Y, pt3.X, pt3.Y, pt4.X, pt4.Y);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x000127DF File Offset: 0x000109DF
		public void AddBezier(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
		{
			this._corePath.MoveOrLineTo(x1, y1);
			this._corePath.BezierTo(x2, y2, x3, y3, x4, y4, false);
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00012808 File Offset: 0x00010A08
		public void AddBeziers(XPoint[] points)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			int num = points.Length;
			if (num < 4)
			{
				throw new ArgumentException("At least four points required for bezier curve.", "points");
			}
			if ((num - 1) % 3 != 0)
			{
				throw new ArgumentException("Invalid number of points for bezier curve. Number must fulfil 4+3n.", "points");
			}
			this._corePath.MoveOrLineTo(points[0].X, points[0].Y);
			for (int i = 1; i < num; i += 3)
			{
				this._corePath.BezierTo(points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y, points[i + 2].X, points[i + 2].Y, false);
			}
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x000128DD File Offset: 0x00010ADD
		public void AddCurve(XPoint[] points)
		{
			this.AddCurve(points, 0.5);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000128F0 File Offset: 0x00010AF0
		public void AddCurve(XPoint[] points, double tension)
		{
			int num = points.Length;
			if (num < 2)
			{
				throw new ArgumentException("AddCurve requires two or more points.", "points");
			}
			this._corePath.AddCurve(points, tension);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00012922 File Offset: 0x00010B22
		public void AddCurve(XPoint[] points, int offset, int numberOfSegments, double tension)
		{
			throw new NotImplementedException("AddCurve not yet implemented.");
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0001292E File Offset: 0x00010B2E
		public void AddArc(XRect rect, double startAngle, double sweepAngle)
		{
			this.AddArc(rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00012954 File Offset: 0x00010B54
		public void AddArc(double x, double y, double width, double height, double startAngle, double sweepAngle)
		{
			this._corePath.AddArc(x, y, width, height, startAngle, sweepAngle);
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0001296A File Offset: 0x00010B6A
		public void AddArc(XPoint point1, XPoint point2, XSize size, double rotationAngle, bool isLargeArg, XSweepDirection sweepDirection)
		{
			this._corePath.AddArc(point1, point2, size, rotationAngle, isLargeArg, sweepDirection);
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00012980 File Offset: 0x00010B80
		public void AddRectangle(XRect rect)
		{
			this._corePath.MoveTo(rect.X, rect.Y);
			this._corePath.LineTo(rect.X + rect.Width, rect.Y, false);
			this._corePath.LineTo(rect.X + rect.Width, rect.Y + rect.Height, false);
			this._corePath.LineTo(rect.X, rect.Y + rect.Height, true);
			this._corePath.CloseSubpath();
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00012A1F File Offset: 0x00010C1F
		public void AddRectangle(double x, double y, double width, double height)
		{
			this.AddRectangle(new XRect(x, y, width, height));
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00012A34 File Offset: 0x00010C34
		public void AddRectangles(XRect[] rects)
		{
			int num = rects.Length;
			for (int i = 0; i < num; i++)
			{
				this.AddRectangle(rects[i]);
			}
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00012A64 File Offset: 0x00010C64
		public void AddRoundedRectangle(double x, double y, double width, double height, double ellipseWidth, double ellipseHeight)
		{
			double num = ellipseWidth / 2.0;
			double num2 = ellipseHeight / 2.0;
			this._corePath.MoveTo(x + width - num, y);
			this._corePath.QuadrantArcTo(x + width - num, y + num2, num, num2, 1, true);
			this._corePath.LineTo(x + width, y + height - num2, false);
			this._corePath.QuadrantArcTo(x + width - num, y + height - num2, num, num2, 4, true);
			this._corePath.LineTo(x + num, y + height, false);
			this._corePath.QuadrantArcTo(x + num, y + height - num2, num, num2, 3, true);
			this._corePath.LineTo(x, y + num2, false);
			this._corePath.QuadrantArcTo(x + num, y + num2, num, num2, 2, true);
			this._corePath.CloseSubpath();
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00012B3D File Offset: 0x00010D3D
		public void AddEllipse(XRect rect)
		{
			this.AddEllipse(rect.X, rect.Y, rect.Width, rect.Height);
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00012B64 File Offset: 0x00010D64
		public void AddEllipse(double x, double y, double width, double height)
		{
			double num = width / 2.0;
			double num2 = height / 2.0;
			double num3 = x + num;
			double num4 = y + num2;
			this._corePath.MoveTo(x + num, y);
			this._corePath.QuadrantArcTo(num3, num4, num, num2, 1, true);
			this._corePath.QuadrantArcTo(num3, num4, num, num2, 4, true);
			this._corePath.QuadrantArcTo(num3, num4, num, num2, 3, true);
			this._corePath.QuadrantArcTo(num3, num4, num, num2, 2, true);
			this._corePath.CloseSubpath();
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00012BF0 File Offset: 0x00010DF0
		public void AddPolygon(XPoint[] points)
		{
			int num = points.Length;
			if (num == 0)
			{
				return;
			}
			this._corePath.MoveTo(points[0].X, points[0].Y);
			for (int i = 0; i < num - 1; i++)
			{
				this._corePath.LineTo(points[i].X, points[i].Y, false);
			}
			this._corePath.LineTo(points[num - 1].X, points[num - 1].Y, true);
			this._corePath.CloseSubpath();
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00012C8D File Offset: 0x00010E8D
		public void AddPie(XRect rect, double startAngle, double sweepAngle)
		{
			this.AddPie(rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00012CB3 File Offset: 0x00010EB3
		public void AddPie(double x, double y, double width, double height, double startAngle, double sweepAngle)
		{
			DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddPie");
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00012CBF File Offset: 0x00010EBF
		public void AddClosedCurve(XPoint[] points)
		{
			this.AddClosedCurve(points, 0.5);
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00012CD4 File Offset: 0x00010ED4
		public void AddClosedCurve(XPoint[] points, double tension)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			int num = points.Length;
			if (num == 0)
			{
				return;
			}
			if (num < 2)
			{
				throw new ArgumentException("Not enough points.", "points");
			}
			DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddClosedCurve");
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00012D15 File Offset: 0x00010F15
		public void AddPath(XGraphicsPath path, bool connect)
		{
			DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddPath");
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00012D24 File Offset: 0x00010F24
		public void AddString(string s, XFontFamily family, XFontStyle style, double emSize, XPoint origin, XStringFormat format)
		{
			try
			{
				DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddString");
			}
			catch
			{
				throw;
			}
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00012D50 File Offset: 0x00010F50
		public void AddString(string s, XFontFamily family, XFontStyle style, double emSize, XRect layoutRect, XStringFormat format)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (family == null)
			{
				throw new ArgumentNullException("family");
			}
			if (format == null)
			{
				format = XStringFormats.Default;
			}
			if (format.LineAlignment == XLineAlignment.BaseLine && layoutRect.Height != 0.0)
			{
				throw new InvalidOperationException("DrawString: With XLineAlignment.BaseLine the height of the layout rectangle must be 0.");
			}
			if (s.Length == 0)
			{
				return;
			}
			new XFont(family.Name, emSize, style);
			DiagnosticsHelper.HandleNotImplemented("XGraphicsPath.AddString");
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00012DCD File Offset: 0x00010FCD
		public void CloseFigure()
		{
			this._corePath.CloseSubpath();
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00012DDA File Offset: 0x00010FDA
		public void StartFigure()
		{
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x00012DDC File Offset: 0x00010FDC
		// (set) Token: 0x0600046B RID: 1131 RVA: 0x00012DE4 File Offset: 0x00010FE4
		public XFillMode FillMode
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

		// Token: 0x0600046C RID: 1132 RVA: 0x00012DED File Offset: 0x00010FED
		public void Flatten()
		{
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00012DEF File Offset: 0x00010FEF
		public void Flatten(XMatrix matrix)
		{
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00012DF1 File Offset: 0x00010FF1
		public void Flatten(XMatrix matrix, double flatness)
		{
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00012DF3 File Offset: 0x00010FF3
		public void Widen(XPen pen)
		{
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00012DF5 File Offset: 0x00010FF5
		public void Widen(XPen pen, XMatrix matrix)
		{
			throw new NotImplementedException("XGraphicsPath.Widen");
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00012E01 File Offset: 0x00011001
		public void Widen(XPen pen, XMatrix matrix, double flatness)
		{
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x00012E03 File Offset: 0x00011003
		public XGraphicsPathInternals Internals
		{
			get
			{
				return new XGraphicsPathInternals(this);
			}
		}

		// Token: 0x04000276 RID: 630
		private XFillMode _fillMode;

		// Token: 0x04000277 RID: 631
		internal CoreGraphicsPath _corePath;
	}
}
