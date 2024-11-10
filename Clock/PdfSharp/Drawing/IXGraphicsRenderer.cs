using System;

namespace PdfSharp.Drawing
{
	// Token: 0x0200001D RID: 29
	internal interface IXGraphicsRenderer
	{
		// Token: 0x060000AC RID: 172
		void Close();

		// Token: 0x060000AD RID: 173
		void DrawLine(XPen pen, double x1, double y1, double x2, double y2);

		// Token: 0x060000AE RID: 174
		void DrawLines(XPen pen, XPoint[] points);

		// Token: 0x060000AF RID: 175
		void DrawBezier(XPen pen, double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4);

		// Token: 0x060000B0 RID: 176
		void DrawBeziers(XPen pen, XPoint[] points);

		// Token: 0x060000B1 RID: 177
		void DrawCurve(XPen pen, XPoint[] points, double tension);

		// Token: 0x060000B2 RID: 178
		void DrawArc(XPen pen, double x, double y, double width, double height, double startAngle, double sweepAngle);

		// Token: 0x060000B3 RID: 179
		void DrawRectangle(XPen pen, XBrush brush, double x, double y, double width, double height);

		// Token: 0x060000B4 RID: 180
		void DrawRectangles(XPen pen, XBrush brush, XRect[] rects);

		// Token: 0x060000B5 RID: 181
		void DrawRoundedRectangle(XPen pen, XBrush brush, double x, double y, double width, double height, double ellipseWidth, double ellipseHeight);

		// Token: 0x060000B6 RID: 182
		void DrawEllipse(XPen pen, XBrush brush, double x, double y, double width, double height);

		// Token: 0x060000B7 RID: 183
		void DrawPolygon(XPen pen, XBrush brush, XPoint[] points, XFillMode fillmode);

		// Token: 0x060000B8 RID: 184
		void DrawPie(XPen pen, XBrush brush, double x, double y, double width, double height, double startAngle, double sweepAngle);

		// Token: 0x060000B9 RID: 185
		void DrawClosedCurve(XPen pen, XBrush brush, XPoint[] points, double tension, XFillMode fillmode);

		// Token: 0x060000BA RID: 186
		void DrawPath(XPen pen, XBrush brush, XGraphicsPath path);

		// Token: 0x060000BB RID: 187
		void DrawString(string s, XFont font, XBrush brush, XRect layoutRectangle, XStringFormat format);

		// Token: 0x060000BC RID: 188
		void DrawImage(XImage image, double x, double y, double width, double height);

		// Token: 0x060000BD RID: 189
		void DrawImage(XImage image, XRect destRect, XRect srcRect, XGraphicsUnit srcUnit);

		// Token: 0x060000BE RID: 190
		void Save(XGraphicsState state);

		// Token: 0x060000BF RID: 191
		void Restore(XGraphicsState state);

		// Token: 0x060000C0 RID: 192
		void BeginContainer(XGraphicsContainer container, XRect dstrect, XRect srcrect, XGraphicsUnit unit);

		// Token: 0x060000C1 RID: 193
		void EndContainer(XGraphicsContainer container);

		// Token: 0x060000C2 RID: 194
		void AddTransform(XMatrix transform, XMatrixOrder matrixOrder);

		// Token: 0x060000C3 RID: 195
		void SetClip(XGraphicsPath path, XCombineMode combineMode);

		// Token: 0x060000C4 RID: 196
		void ResetClip();

		// Token: 0x060000C5 RID: 197
		void WriteComment(string comment);
	}
}
