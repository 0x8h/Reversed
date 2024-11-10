using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Drawing.Pdf
{
	// Token: 0x0200001E RID: 30
	internal class XGraphicsPdfRenderer : IXGraphicsRenderer
	{
		// Token: 0x060000C6 RID: 198 RVA: 0x00006800 File Offset: 0x00004A00
		public XGraphicsPdfRenderer(PdfPage page, XGraphics gfx, XGraphicsPdfPageOptions options)
		{
			this._page = page;
			this._colorMode = page._document.Options.ColorMode;
			this._options = options;
			this._gfx = gfx;
			this._content = new StringBuilder();
			page.RenderContent._pdfRenderer = this;
			this._gfxState = new PdfGraphicsState(this);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000686C File Offset: 0x00004A6C
		public XGraphicsPdfRenderer(XForm form, XGraphics gfx)
		{
			this._form = form;
			this._colorMode = form.Owner.Options.ColorMode;
			this._gfx = gfx;
			this._content = new StringBuilder();
			form.PdfRenderer = this;
			this._gfxState = new PdfGraphicsState(this);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000068CC File Offset: 0x00004ACC
		private string GetContent()
		{
			this.EndPage();
			return this._content.ToString();
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x000068DF File Offset: 0x00004ADF
		public XGraphicsPdfPageOptions PageOptions
		{
			get
			{
				return this._options;
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000068E8 File Offset: 0x00004AE8
		public void Close()
		{
			if (this._page != null)
			{
				PdfContent renderContent = this._page.RenderContent;
				renderContent.CreateStream(PdfEncoders.RawEncoding.GetBytes(this.GetContent()));
				this._gfx = null;
				this._page.RenderContent._pdfRenderer = null;
				this._page.RenderContent = null;
				this._page = null;
				return;
			}
			if (this._form != null)
			{
				this._form._pdfForm.CreateStream(PdfEncoders.RawEncoding.GetBytes(this.GetContent()));
				this._gfx = null;
				this._form.PdfRenderer = null;
				this._form = null;
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00006990 File Offset: 0x00004B90
		public void DrawLine(XPen pen, double x1, double y1, double x2, double y2)
		{
			this.DrawLines(pen, new XPoint[]
			{
				new XPoint(x1, y1),
				new XPoint(x2, y2)
			});
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000069D4 File Offset: 0x00004BD4
		public void DrawLines(XPen pen, XPoint[] points)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			int num = points.Length;
			if (num == 0)
			{
				return;
			}
			this.Realize(pen);
			this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
			for (int i = 1; i < num; i++)
			{
				this.AppendFormatPoint("{0:0.####} {1:0.####} l\n", points[i].X, points[i].Y);
			}
			this._content.Append("S\n");
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00006A70 File Offset: 0x00004C70
		public void DrawBezier(XPen pen, double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
		{
			this.DrawBeziers(pen, new XPoint[]
			{
				new XPoint(x1, y1),
				new XPoint(x2, y2),
				new XPoint(x3, y3),
				new XPoint(x4, y4)
			});
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00006AE0 File Offset: 0x00004CE0
		public void DrawBeziers(XPen pen, XPoint[] points)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			int num = points.Length;
			if (num == 0)
			{
				return;
			}
			if ((num - 1) % 3 != 0)
			{
				throw new ArgumentException("Invalid number of points for bezier curves. Number must fulfil 4+3n.", "points");
			}
			this.Realize(pen);
			this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
			for (int i = 1; i < num; i += 3)
			{
				this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y, points[i + 2].X, points[i + 2].Y);
			}
			this.AppendStrokeFill(pen, null, XFillMode.Alternate, false);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00006BC4 File Offset: 0x00004DC4
		public void DrawCurve(XPen pen, XPoint[] points, double tension)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
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
				throw new ArgumentException("Not enough points", "points");
			}
			tension /= 3.0;
			this.Realize(pen);
			this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
			if (num == 2)
			{
				this.AppendCurveSegment(points[0], points[0], points[1], points[1], tension);
			}
			else
			{
				this.AppendCurveSegment(points[0], points[0], points[1], points[2], tension);
				for (int i = 1; i < num - 2; i++)
				{
					this.AppendCurveSegment(points[i - 1], points[i], points[i + 1], points[i + 2], tension);
				}
				this.AppendCurveSegment(points[num - 3], points[num - 2], points[num - 1], points[num - 1], tension);
			}
			this.AppendStrokeFill(pen, null, XFillMode.Alternate, false);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00006D4C File Offset: 0x00004F4C
		public void DrawArc(XPen pen, double x, double y, double width, double height, double startAngle, double sweepAngle)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			this.Realize(pen);
			this.AppendPartialArc(x, y, width, height, startAngle, sweepAngle, PathStart.MoveTo1st, default(XMatrix));
			this.AppendStrokeFill(pen, null, XFillMode.Alternate, false);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00006D94 File Offset: 0x00004F94
		public void DrawRectangle(XPen pen, XBrush brush, double x, double y, double width, double height)
		{
			if (pen == null && brush == null)
			{
				throw new ArgumentNullException("pen and brush");
			}
			this.Realize(pen, brush);
			this.AppendFormatRect("{0:0.###} {1:0.###} {2:0.###} {3:0.###} re\n", x, y + height, width, height);
			if (pen != null && brush != null)
			{
				this._content.Append("B\n");
				return;
			}
			if (pen != null)
			{
				this._content.Append("S\n");
				return;
			}
			this._content.Append("f\n");
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00006E10 File Offset: 0x00005010
		public void DrawRectangles(XPen pen, XBrush brush, XRect[] rects)
		{
			int num = rects.Length;
			for (int i = 0; i < num; i++)
			{
				XRect xrect = rects[i];
				this.DrawRectangle(pen, brush, xrect.X, xrect.Y, xrect.Width, xrect.Height);
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00006E60 File Offset: 0x00005060
		public void DrawRoundedRectangle(XPen pen, XBrush brush, double x, double y, double width, double height, double ellipseWidth, double ellipseHeight)
		{
			XGraphicsPath xgraphicsPath = new XGraphicsPath();
			xgraphicsPath.AddRoundedRectangle(x, y, width, height, ellipseWidth, ellipseHeight);
			this.DrawPath(pen, brush, xgraphicsPath);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00006E90 File Offset: 0x00005090
		public void DrawEllipse(XPen pen, XBrush brush, double x, double y, double width, double height)
		{
			this.Realize(pen, brush);
			XRect xrect = new XRect(x, y, width, height);
			double num = xrect.Width / 2.0;
			double num2 = xrect.Height / 2.0;
			double num3 = num * 0.55228474983079345;
			double num4 = num2 * 0.55228474983079345;
			double num5 = xrect.X + num;
			double num6 = xrect.Y + num2;
			this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", num5 + num, num6);
			this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", num5 + num, num6 + num4, num5 + num3, num6 + num2, num5, num6 + num2);
			this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", num5 - num3, num6 + num2, num5 - num, num6 + num4, num5 - num, num6);
			this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", num5 - num, num6 - num4, num5 - num3, num6 - num2, num5, num6 - num2);
			this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", num5 + num3, num6 - num2, num5 + num, num6 - num4, num5 + num, num6);
			this.AppendStrokeFill(pen, brush, XFillMode.Winding, true);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00006FAC File Offset: 0x000051AC
		public void DrawPolygon(XPen pen, XBrush brush, XPoint[] points, XFillMode fillmode)
		{
			this.Realize(pen, brush);
			int num = points.Length;
			if (points.Length < 2)
			{
				throw new ArgumentException("points", PSSR.PointArrayAtLeast(2));
			}
			this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
			for (int i = 1; i < num; i++)
			{
				this.AppendFormatPoint("{0:0.####} {1:0.####} l\n", points[i].X, points[i].Y);
			}
			this.AppendStrokeFill(pen, brush, fillmode, true);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000703C File Offset: 0x0000523C
		public void DrawPie(XPen pen, XBrush brush, double x, double y, double width, double height, double startAngle, double sweepAngle)
		{
			this.Realize(pen, brush);
			this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", x + width / 2.0, y + height / 2.0);
			this.AppendPartialArc(x, y, width, height, startAngle, sweepAngle, PathStart.LineTo1st, default(XMatrix));
			this.AppendStrokeFill(pen, brush, XFillMode.Alternate, true);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000070A0 File Offset: 0x000052A0
		public void DrawClosedCurve(XPen pen, XBrush brush, XPoint[] points, double tension, XFillMode fillmode)
		{
			int num = points.Length;
			if (num == 0)
			{
				return;
			}
			if (num < 2)
			{
				throw new ArgumentException("Not enough points.", "points");
			}
			tension /= 3.0;
			this.Realize(pen, brush);
			this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[0].X, points[0].Y);
			if (num == 2)
			{
				this.AppendCurveSegment(points[0], points[0], points[1], points[1], tension);
			}
			else
			{
				this.AppendCurveSegment(points[num - 1], points[0], points[1], points[2], tension);
				for (int i = 1; i < num - 2; i++)
				{
					this.AppendCurveSegment(points[i - 1], points[i], points[i + 1], points[i + 2], tension);
				}
				this.AppendCurveSegment(points[num - 3], points[num - 2], points[num - 1], points[0], tension);
				this.AppendCurveSegment(points[num - 2], points[num - 1], points[0], points[1], tension);
			}
			this.AppendStrokeFill(pen, brush, fillmode, true);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000724E File Offset: 0x0000544E
		public void DrawPath(XPen pen, XBrush brush, XGraphicsPath path)
		{
			if (pen == null && brush == null)
			{
				throw new ArgumentNullException("pen");
			}
			this.Realize(pen, brush);
			this.AppendPath(path._corePath);
			this.AppendStrokeFill(pen, brush, path.FillMode, false);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00007284 File Offset: 0x00005484
		public void DrawString(string s, XFont font, XBrush brush, XRect rect, XStringFormat format)
		{
			double num = rect.X;
			double num2 = rect.Y;
			double height = font.GetHeight();
			double num3 = height * (double)font.CellAscent / (double)font.CellSpace;
			double num4 = height * (double)font.CellDescent / (double)font.CellSpace;
			double width = this._gfx.MeasureString(s, font).Width;
			bool flag = (font.GlyphTypeface.StyleSimulations & XStyleSimulations.ItalicSimulation) != XStyleSimulations.None;
			bool flag2 = (font.GlyphTypeface.StyleSimulations & XStyleSimulations.BoldSimulation) != XStyleSimulations.None;
			bool flag3 = (font.Style & XFontStyle.Strikeout) != XFontStyle.Regular;
			bool flag4 = (font.Style & XFontStyle.Underline) != XFontStyle.Regular;
			this.Realize(font, brush, flag2 ? 2 : 0);
			switch (format.Alignment)
			{
			case XStringAlignment.Center:
				num += (rect.Width - width) / 2.0;
				break;
			case XStringAlignment.Far:
				num += rect.Width - width;
				break;
			}
			if (this.Gfx.PageDirection == XPageDirection.Downwards)
			{
				switch (format.LineAlignment)
				{
				case XLineAlignment.Near:
					num2 += num3;
					break;
				case XLineAlignment.Center:
					num2 += num3 * 3.0 / 4.0 / 2.0 + rect.Height / 2.0;
					break;
				case XLineAlignment.Far:
					num2 += -num4 + rect.Height;
					break;
				}
			}
			else
			{
				switch (format.LineAlignment)
				{
				case XLineAlignment.Near:
					num2 += num4;
					break;
				case XLineAlignment.Center:
					num2 += -(num3 * 3.0 / 4.0) / 2.0 + rect.Height / 2.0;
					break;
				case XLineAlignment.Far:
					num2 += -num3 + rect.Height;
					break;
				}
			}
			PdfFont realizedFont = this._gfxState._realizedFont;
			realizedFont.AddChars(s);
			OpenTypeDescriptor descriptor = realizedFont.FontDescriptor._descriptor;
			string text;
			if (font.Unicode)
			{
				StringBuilder stringBuilder = new StringBuilder();
				bool symbol = descriptor.FontFace.cmap.symbol;
				foreach (char c in s)
				{
					if (symbol)
					{
						c |= (char)(descriptor.FontFace.os2.usFirstCharIndex & 65280);
					}
					int num5 = descriptor.CharCodeToGlyphIndex(c);
					stringBuilder.Append((char)num5);
				}
				s = stringBuilder.ToString();
				byte[] array = PdfEncoders.RawUnicodeEncoding.GetBytes(s);
				array = PdfEncoders.FormatStringLiteral(array, true, false, true, null);
				text = PdfEncoders.RawEncoding.GetString(array, 0, array.Length);
			}
			else
			{
				byte[] bytes = PdfEncoders.WinAnsiEncoding.GetBytes(s);
				text = PdfEncoders.ToStringLiteral(bytes, false, null);
			}
			XPoint xpoint = new XPoint(num, num2);
			xpoint = this.WorldToView(xpoint);
			double num6 = 0.0;
			if (flag)
			{
				if (this._gfxState.ItalicSimulationOn)
				{
					this.AdjustTdOffset(ref xpoint, num6, true);
					this.AppendFormatArgs("{0:0.####} {1:0.####} Td\n{2} Tj\n", new object[] { xpoint.X, xpoint.Y, text });
				}
				else
				{
					XMatrix xmatrix = new XMatrix(1.0, 0.0, 0.34202014332566871, 1.0, xpoint.X, xpoint.Y);
					this.AppendFormatArgs("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} Tm\n{6} Tj\n", new object[] { xmatrix.M11, xmatrix.M12, xmatrix.M21, xmatrix.M22, xmatrix.OffsetX, xmatrix.OffsetY, text });
					this._gfxState.ItalicSimulationOn = true;
					this.AdjustTdOffset(ref xpoint, num6, false);
				}
			}
			else if (this._gfxState.ItalicSimulationOn)
			{
				XMatrix xmatrix2 = new XMatrix(1.0, 0.0, 0.0, 1.0, xpoint.X, xpoint.Y);
				this.AppendFormatArgs("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} Tm\n{6} Tj\n", new object[] { xmatrix2.M11, xmatrix2.M12, xmatrix2.M21, xmatrix2.M22, xmatrix2.OffsetX, xmatrix2.OffsetY, text });
				this._gfxState.ItalicSimulationOn = false;
				this.AdjustTdOffset(ref xpoint, num6, false);
			}
			else
			{
				this.AdjustTdOffset(ref xpoint, num6, false);
				this.AppendFormatArgs("{0:0.####} {1:0.####} Td {2} Tj\n", new object[] { xpoint.X, xpoint.Y, text });
			}
			if (flag4)
			{
				double num7 = height * (double)realizedFont.FontDescriptor._descriptor.UnderlinePosition / (double)font.CellSpace;
				double num8 = height * (double)realizedFont.FontDescriptor._descriptor.UnderlineThickness / (double)font.CellSpace;
				double num9 = ((this.Gfx.PageDirection == XPageDirection.Downwards) ? (num2 - num7) : (num2 + num7 - num8));
				this.DrawRectangle(null, brush, num, num9, width, num8);
			}
			if (flag3)
			{
				double num10 = height * (double)realizedFont.FontDescriptor._descriptor.StrikeoutPosition / (double)font.CellSpace;
				double num11 = height * (double)realizedFont.FontDescriptor._descriptor.StrikeoutSize / (double)font.CellSpace;
				double num12 = ((this.Gfx.PageDirection == XPageDirection.Downwards) ? (num2 - num10) : (num2 + num10 - num11));
				this.DrawRectangle(null, brush, num, num12, width, num11);
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000078B0 File Offset: 0x00005AB0
		public void DrawImage(XImage image, double x, double y, double width, double height)
		{
			string text = this.Realize(image);
			if (image is XForm)
			{
				this.BeginPage();
				XForm xform = (XForm)image;
				xform.Finish();
				this.Owner.FormTable.GetForm(xform);
				double num = width / image.PointWidth;
				double num2 = height / image.PointHeight;
				if (num != 0.0 && num2 != 0.0)
				{
					XPdfForm xpdfForm = image as XPdfForm;
					if (this._gfx.PageDirection == XPageDirection.Downwards)
					{
						double num3 = x;
						double num4 = y;
						if (xpdfForm != null)
						{
							num3 -= xpdfForm.Page.MediaBox.X1;
							num4 += xpdfForm.Page.MediaBox.Y1;
						}
						this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm 100 Tz {4} Do Q\n", num3, num4 + height, num, num2, text);
						return;
					}
					this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y, num, num2, text);
				}
				return;
			}
			if (this._gfx.PageDirection == XPageDirection.Downwards)
			{
				this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y + height, width, height, text);
				return;
			}
			this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y, width, height, text);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000079C8 File Offset: 0x00005BC8
		public void DrawImage(XImage image, XRect destRect, XRect srcRect, XGraphicsUnit srcUnit)
		{
			double x = destRect.X;
			double y = destRect.Y;
			double width = destRect.Width;
			double height = destRect.Height;
			string text = this.Realize(image);
			if (image is XForm)
			{
				this.BeginPage();
				XForm xform = (XForm)image;
				xform.Finish();
				this.Owner.FormTable.GetForm(xform);
				double num = width / image.PointWidth;
				double num2 = height / image.PointHeight;
				if (num != 0.0 && num2 != 0.0)
				{
					XPdfForm xpdfForm = image as XPdfForm;
					if (this._gfx.PageDirection == XPageDirection.Downwards)
					{
						double num3 = x;
						double num4 = y;
						if (xpdfForm != null)
						{
							num3 -= xpdfForm.Page.MediaBox.X1;
							num4 += xpdfForm.Page.MediaBox.Y1;
						}
						this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", num3, num4 + height, num, num2, text);
						return;
					}
					this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y, num, num2, text);
				}
				return;
			}
			if (this._gfx.PageDirection == XPageDirection.Downwards)
			{
				this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do\nQ\n", x, y + height, width, height, text);
				return;
			}
			this.AppendFormatImage("q {2:0.####} 0 0 {3:0.####} {0:0.####} {1:0.####} cm {4} Do Q\n", x, y, width, height, text);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00007B08 File Offset: 0x00005D08
		public void Save(XGraphicsState state)
		{
			this.BeginGraphicMode();
			this.RealizeTransform();
			this._gfxState.InternalState = state.InternalState;
			this.SaveState();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00007B2D File Offset: 0x00005D2D
		public void Restore(XGraphicsState state)
		{
			this.BeginGraphicMode();
			this.RestoreState(state.InternalState);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00007B42 File Offset: 0x00005D42
		public void BeginContainer(XGraphicsContainer container, XRect dstrect, XRect srcrect, XGraphicsUnit unit)
		{
			this.BeginGraphicMode();
			this.RealizeTransform();
			this._gfxState.InternalState = container.InternalState;
			this.SaveState();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00007B67 File Offset: 0x00005D67
		public void EndContainer(XGraphicsContainer container)
		{
			this.BeginGraphicMode();
			this.RestoreState(container.InternalState);
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00007B7C File Offset: 0x00005D7C
		public XMatrix Transform
		{
			get
			{
				if (this._gfxState.UnrealizedCtm.IsIdentity)
				{
					return this._gfxState.EffectiveCtm;
				}
				return this._gfxState.UnrealizedCtm * this._gfxState.RealizedCtm;
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00007BB7 File Offset: 0x00005DB7
		public void AddTransform(XMatrix value, XMatrixOrder matrixOrder)
		{
			this._gfxState.AddTransform(value, matrixOrder);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00007BC8 File Offset: 0x00005DC8
		public void SetClip(XGraphicsPath path, XCombineMode combineMode)
		{
			if (path == null)
			{
				throw new NotImplementedException("SetClip with no path.");
			}
			if (this._gfxState.Level < 2)
			{
				this.RealizeTransform();
			}
			if (combineMode == XCombineMode.Replace)
			{
				if (this._clipLevel != 0)
				{
					if (this._clipLevel != this._gfxState.Level)
					{
						throw new NotImplementedException("Cannot set new clip region in an inner graphic state level.");
					}
					this.ResetClip();
				}
				this._clipLevel = this._gfxState.Level;
			}
			else if (combineMode == XCombineMode.Intersect && this._clipLevel == 0)
			{
				this._clipLevel = this._gfxState.Level;
			}
			this._gfxState.SetAndRealizeClipPath(path);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00007C64 File Offset: 0x00005E64
		public void ResetClip()
		{
			if (this._clipLevel == 0)
			{
				return;
			}
			if (this._clipLevel != this._gfxState.Level)
			{
				throw new NotImplementedException("Cannot reset clip region in an inner graphic state level.");
			}
			this.BeginGraphicMode();
			InternalGraphicsState internalState = this._gfxState.InternalState;
			XMatrix effectiveCtm = this._gfxState.EffectiveCtm;
			this.RestoreState();
			this.SaveState();
			this._gfxState.InternalState = internalState;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00007CCE File Offset: 0x00005ECE
		public void WriteComment(string comment)
		{
			comment = comment.Replace("\n", "\n% ");
			this.Append("% " + comment + "\n");
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00007CF8 File Offset: 0x00005EF8
		private void AppendPartialArc(double x, double y, double width, double height, double startAngle, double sweepAngle, PathStart pathStart, XMatrix matrix)
		{
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
			int num3 = this.Quadrant(num, true, flag2);
			int num4 = this.Quadrant(num2, false, flag2);
			if (num3 == num4 && flag)
			{
				this.AppendPartialArcQuadrant(x, y, width, height, num, num2, pathStart, matrix);
				return;
			}
			int num5 = num3;
			bool flag3 = true;
			for (;;)
			{
				if (num5 == num3 && flag3)
				{
					double num6 = (double)(num5 * 90 + (flag2 ? 90 : 0));
					this.AppendPartialArcQuadrant(x, y, width, height, num, num6, pathStart, matrix);
				}
				else if (num5 == num4)
				{
					double num7 = (double)(num5 * 90 + (flag2 ? 0 : 90));
					this.AppendPartialArcQuadrant(x, y, width, height, num7, num2, PathStart.Ignore1st, matrix);
				}
				else
				{
					double num8 = (double)(num5 * 90 + (flag2 ? 0 : 90));
					double num9 = (double)(num5 * 90 + (flag2 ? 90 : 0));
					this.AppendPartialArcQuadrant(x, y, width, height, num8, num9, PathStart.Ignore1st, matrix);
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

		// Token: 0x060000E6 RID: 230 RVA: 0x00007F3C File Offset: 0x0000613C
		private int Quadrant(double φ, bool start, bool clockwise)
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

		// Token: 0x060000E7 RID: 231 RVA: 0x00007FCC File Offset: 0x000061CC
		private void AppendPartialArcQuadrant(double x, double y, double width, double height, double α, double β, PathStart pathStart, XMatrix matrix)
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
			XPoint xpoint;
			XPoint xpoint2;
			XPoint xpoint3;
			if (!flag)
			{
				switch (pathStart)
				{
				case PathStart.MoveTo1st:
					xpoint = matrix.Transform(new XPoint(num3 + num * num8, num4 + num2 * num5));
					this.AppendFormatPoint("{0:0.###} {1:0.###} m\n", xpoint.X, xpoint.Y);
					break;
				case PathStart.LineTo1st:
					xpoint = matrix.Transform(new XPoint(num3 + num * num8, num4 + num2 * num5));
					this.AppendFormatPoint("{0:0.###} {1:0.###} l\n", xpoint.X, xpoint.Y);
					break;
				}
				xpoint = matrix.Transform(new XPoint(num3 + num * (num8 - num7 * num5), num4 + num2 * (num5 + num7 * num8)));
				xpoint2 = matrix.Transform(new XPoint(num3 + num * (num9 + num7 * num6), num4 + num2 * (num6 - num7 * num9)));
				xpoint3 = matrix.Transform(new XPoint(num3 + num * num9, num4 + num2 * num6));
				this.AppendFormat3Points("{0:0.###} {1:0.###} {2:0.###} {3:0.###} {4:0.###} {5:0.###} c\n", xpoint.X, xpoint.Y, xpoint2.X, xpoint2.Y, xpoint3.X, xpoint3.Y);
				return;
			}
			switch (pathStart)
			{
			case PathStart.MoveTo1st:
				xpoint = matrix.Transform(new XPoint(num3 - num * num8, num4 - num2 * num5));
				this.AppendFormatPoint("{0:0.###} {1:0.###} m\n", xpoint.X, xpoint.Y);
				break;
			case PathStart.LineTo1st:
				xpoint = matrix.Transform(new XPoint(num3 - num * num8, num4 - num2 * num5));
				this.AppendFormatPoint("{0:0.###} {1:0.###} l\n", xpoint.X, xpoint.Y);
				break;
			}
			xpoint = matrix.Transform(new XPoint(num3 - num * (num8 - num7 * num5), num4 - num2 * (num5 + num7 * num8)));
			xpoint2 = matrix.Transform(new XPoint(num3 - num * (num9 + num7 * num6), num4 - num2 * (num6 - num7 * num9)));
			xpoint3 = matrix.Transform(new XPoint(num3 - num * num9, num4 - num2 * num6));
			this.AppendFormat3Points("{0:0.###} {1:0.###} {2:0.###} {3:0.###} {4:0.###} {5:0.###} c\n", xpoint.X, xpoint.Y, xpoint2.X, xpoint2.Y, xpoint3.X, xpoint3.Y);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000083C8 File Offset: 0x000065C8
		private void AppendCurveSegment(XPoint pt0, XPoint pt1, XPoint pt2, XPoint pt3, double tension3)
		{
			this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", pt1.X + tension3 * (pt2.X - pt0.X), pt1.Y + tension3 * (pt2.Y - pt0.Y), pt2.X - tension3 * (pt3.X - pt1.X), pt2.Y - tension3 * (pt3.Y - pt1.Y), pt2.X, pt2.Y);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00008456 File Offset: 0x00006656
		internal void AppendPath(CoreGraphicsPath path)
		{
			this.AppendPath(path.PathPoints, path.PathTypes);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000846C File Offset: 0x0000666C
		private void AppendPath(XPoint[] points, byte[] types)
		{
			int num = points.Length;
			if (num == 0)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				byte b = types[i];
				switch (b & 7)
				{
				case 0:
					this.AppendFormatPoint("{0:0.####} {1:0.####} m\n", points[i].X, points[i].Y);
					break;
				case 1:
					this.AppendFormatPoint("{0:0.####} {1:0.####} l\n", points[i].X, points[i].Y);
					if ((b & 128) != 0)
					{
						this.Append("h\n");
					}
					break;
				case 3:
					this.AppendFormat3Points("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####} c\n", points[i].X, points[i].Y, points[++i].X, points[i].Y, points[++i].X, points[i].Y);
					if ((types[i] & 128) != 0)
					{
						this.Append("h\n");
					}
					break;
				}
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00008588 File Offset: 0x00006788
		internal void Append(string value)
		{
			this._content.Append(value);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00008597 File Offset: 0x00006797
		internal void AppendFormatArgs(string format, params object[] args)
		{
			this._content.AppendFormat(CultureInfo.InvariantCulture, format, args);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000085AC File Offset: 0x000067AC
		internal void AppendFormatString(string format, string s)
		{
			this._content.AppendFormat(CultureInfo.InvariantCulture, format, new object[] { s });
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000085D8 File Offset: 0x000067D8
		internal void AppendFormatFont(string format, string s, double d)
		{
			this._content.AppendFormat(CultureInfo.InvariantCulture, format, new object[] { s, d });
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000860C File Offset: 0x0000680C
		internal void AppendFormatInt(string format, int n)
		{
			this._content.AppendFormat(CultureInfo.InvariantCulture, format, new object[] { n });
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000863C File Offset: 0x0000683C
		internal void AppendFormatDouble(string format, double d)
		{
			this._content.AppendFormat(CultureInfo.InvariantCulture, format, new object[] { d });
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000866C File Offset: 0x0000686C
		internal void AppendFormatPoint(string format, double x, double y)
		{
			XPoint xpoint = this.WorldToView(new XPoint(x, y));
			this._content.AppendFormat(CultureInfo.InvariantCulture, format, new object[] { xpoint.X, xpoint.Y });
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000086C0 File Offset: 0x000068C0
		internal void AppendFormatRect(string format, double x, double y, double width, double height)
		{
			XPoint xpoint = this.WorldToView(new XPoint(x, y));
			this._content.AppendFormat(CultureInfo.InvariantCulture, format, new object[] { xpoint.X, xpoint.Y, width, height });
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00008728 File Offset: 0x00006928
		internal void AppendFormat3Points(string format, double x1, double y1, double x2, double y2, double x3, double y3)
		{
			XPoint xpoint = this.WorldToView(new XPoint(x1, y1));
			XPoint xpoint2 = this.WorldToView(new XPoint(x2, y2));
			XPoint xpoint3 = this.WorldToView(new XPoint(x3, y3));
			this._content.AppendFormat(CultureInfo.InvariantCulture, format, new object[] { xpoint.X, xpoint.Y, xpoint2.X, xpoint2.Y, xpoint3.X, xpoint3.Y });
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000087D8 File Offset: 0x000069D8
		internal void AppendFormat(string format, XPoint point)
		{
			XPoint xpoint = this.WorldToView(point);
			this._content.AppendFormat(CultureInfo.InvariantCulture, format, new object[] { xpoint.X, xpoint.Y });
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00008828 File Offset: 0x00006A28
		internal void AppendFormat(string format, double x, double y, string s)
		{
			XPoint xpoint = this.WorldToView(new XPoint(x, y));
			this._content.AppendFormat(CultureInfo.InvariantCulture, format, new object[] { xpoint.X, xpoint.Y, s });
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00008880 File Offset: 0x00006A80
		internal void AppendFormatImage(string format, double x, double y, double width, double height, string name)
		{
			XPoint xpoint = this.WorldToView(new XPoint(x, y));
			this._content.AppendFormat(CultureInfo.InvariantCulture, format, new object[] { xpoint.X, xpoint.Y, width, height, name });
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x000088EC File Offset: 0x00006AEC
		private void AppendStrokeFill(XPen pen, XBrush brush, XFillMode fillMode, bool closePath)
		{
			if (closePath)
			{
				this._content.Append("h ");
			}
			if (fillMode == XFillMode.Winding)
			{
				if (pen != null && brush != null)
				{
					this._content.Append("B\n");
					return;
				}
				if (pen != null)
				{
					this._content.Append("S\n");
					return;
				}
				this._content.Append("f\n");
				return;
			}
			else
			{
				if (pen != null && brush != null)
				{
					this._content.Append("B*\n");
					return;
				}
				if (pen != null)
				{
					this._content.Append("S\n");
					return;
				}
				this._content.Append("f*\n");
				return;
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00008990 File Offset: 0x00006B90
		private void BeginPage()
		{
			if (this._gfxState.Level == 0)
			{
				this.DefaultViewMatrix = default(XMatrix);
				if (this._gfx.PageDirection == XPageDirection.Downwards)
				{
					this.PageHeightPt = this.Size.Height;
					XPoint xpoint = default(XPoint);
					if (this._page != null && this._page.TrimMargins.AreSet)
					{
						this.PageHeightPt += this._page.TrimMargins.Top.Point + this._page.TrimMargins.Bottom.Point;
						xpoint = new XPoint(this._page.TrimMargins.Left.Point, this._page.TrimMargins.Top.Point);
					}
					switch (this._gfx.PageUnit)
					{
					case XGraphicsUnit.Inch:
						this.DefaultViewMatrix.ScalePrepend(72.0);
						break;
					case XGraphicsUnit.Millimeter:
						this.DefaultViewMatrix.ScalePrepend(2.8346456692913389);
						break;
					case XGraphicsUnit.Centimeter:
						this.DefaultViewMatrix.ScalePrepend(28.346456692913385);
						break;
					case XGraphicsUnit.Presentation:
						this.DefaultViewMatrix.ScalePrepend(0.75);
						break;
					}
					if (xpoint != default(XPoint))
					{
						this.DefaultViewMatrix.TranslatePrepend(xpoint.X, -xpoint.Y);
					}
					this.SaveState();
					if (!this.DefaultViewMatrix.IsIdentity)
					{
						double[] elements = this.DefaultViewMatrix.GetElements();
						this.AppendFormatArgs("{0:0.#######} {1:0.#######} {2:0.#######} {3:0.#######} {4:0.#######} {5:0.#######} cm ", new object[]
						{
							elements[0],
							elements[1],
							elements[2],
							elements[3],
							elements[4],
							elements[5]
						});
						return;
					}
				}
				else
				{
					switch (this._gfx.PageUnit)
					{
					case XGraphicsUnit.Inch:
						this.DefaultViewMatrix.ScalePrepend(72.0);
						break;
					case XGraphicsUnit.Millimeter:
						this.DefaultViewMatrix.ScalePrepend(2.8346456692913389);
						break;
					case XGraphicsUnit.Centimeter:
						this.DefaultViewMatrix.ScalePrepend(28.346456692913385);
						break;
					case XGraphicsUnit.Presentation:
						this.DefaultViewMatrix.ScalePrepend(0.75);
						break;
					}
					this.SaveState();
					double[] elements2 = this.DefaultViewMatrix.GetElements();
					this.AppendFormat3Points("{0:0.#######} {1:0.#######} {2:0.#######} {3:0.#######} {4:0.#######} {5:0.#######} cm ", elements2[0], elements2[1], elements2[2], elements2[3], elements2[4], elements2[5]);
				}
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00008C56 File Offset: 0x00006E56
		private void EndPage()
		{
			if (this._streamMode == StreamMode.Text)
			{
				this._content.Append("ET\n");
				this._streamMode = StreamMode.Graphic;
			}
			while (this._gfxStateStack.Count != 0)
			{
				this.RestoreState();
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00008C8E File Offset: 0x00006E8E
		internal void BeginGraphicMode()
		{
			if (this._streamMode != StreamMode.Graphic)
			{
				if (this._streamMode == StreamMode.Text)
				{
					this._content.Append("ET\n");
				}
				this._streamMode = StreamMode.Graphic;
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00008CB9 File Offset: 0x00006EB9
		internal void BeginTextMode()
		{
			if (this._streamMode != StreamMode.Text)
			{
				this._streamMode = StreamMode.Text;
				this._content.Append("BT\n");
				this._gfxState.RealizedTextPosition = default(XPoint);
				this._gfxState.ItalicSimulationOn = false;
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00008CFC File Offset: 0x00006EFC
		private void Realize(XPen pen, XBrush brush)
		{
			this.BeginPage();
			this.BeginGraphicMode();
			this.RealizeTransform();
			if (pen != null)
			{
				this._gfxState.RealizePen(pen, this._colorMode);
			}
			if (brush != null)
			{
				this._gfxState.RealizeBrush(brush, this._colorMode, 0, 0.0);
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00008D4F File Offset: 0x00006F4F
		private void Realize(XPen pen)
		{
			this.Realize(pen, null);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00008D59 File Offset: 0x00006F59
		private void Realize(XBrush brush)
		{
			this.Realize(null, brush);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00008D63 File Offset: 0x00006F63
		private void Realize(XFont font, XBrush brush, int renderingMode)
		{
			this.BeginPage();
			this.RealizeTransform();
			this.BeginTextMode();
			this._gfxState.RealizeFont(font, brush, renderingMode);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00008D88 File Offset: 0x00006F88
		private void AdjustTdOffset(ref XPoint pos, double dy, bool adjustSkew)
		{
			pos.Y += dy;
			XPoint xpoint = pos;
			pos -= new XVector(this._gfxState.RealizedTextPosition.X, this._gfxState.RealizedTextPosition.Y);
			if (adjustSkew)
			{
				pos.X -= 0.34202014332566871 * pos.Y;
			}
			this._gfxState.RealizedTextPosition = xpoint;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00008E0C File Offset: 0x0000700C
		private string Realize(XImage image)
		{
			this.BeginPage();
			this.BeginGraphicMode();
			this.RealizeTransform();
			this._gfxState.RealizeNonStrokeTransparency(1.0, this._colorMode);
			XForm xform = image as XForm;
			if (xform == null)
			{
				return this.GetImageName(image);
			}
			return this.GetFormName(xform);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00008E60 File Offset: 0x00007060
		private void RealizeTransform()
		{
			this.BeginPage();
			if (this._gfxState.Level == 1)
			{
				this.BeginGraphicMode();
				this.SaveState();
			}
			if (!this._gfxState.UnrealizedCtm.IsIdentity)
			{
				this.BeginGraphicMode();
				this._gfxState.RealizeCtm();
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00008EB0 File Offset: 0x000070B0
		internal XPoint WorldToView(XPoint point)
		{
			XPoint xpoint = this._gfxState.WorldTransform.Transform(point);
			return this._gfxState.InverseEffectiveCtm.Transform(new XPoint(xpoint.X, this.PageHeightPt / this.DefaultViewMatrix.M22 - xpoint.Y));
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00008F08 File Offset: 0x00007108
		[Conditional("DEBUG")]
		private void DumpPathData(XPoint[] points, byte[] types)
		{
			int num = points.Length;
			for (int i = 0; i < num; i++)
			{
				PdfEncoders.Format("{0:X}   {1:####0.000} {2:####0.000}", new object[]
				{
					types[i],
					points[i].X,
					points[i].Y
				});
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00008F6B File Offset: 0x0000716B
		internal PdfDocument Owner
		{
			get
			{
				if (this._page != null)
				{
					return this._page.Owner;
				}
				return this._form.Owner;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00008F8C File Offset: 0x0000718C
		internal XGraphics Gfx
		{
			get
			{
				return this._gfx;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00008F94 File Offset: 0x00007194
		internal PdfResources Resources
		{
			get
			{
				if (this._page != null)
				{
					return this._page.Resources;
				}
				return this._form.Resources;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00008FB5 File Offset: 0x000071B5
		internal XSize Size
		{
			get
			{
				if (this._page != null)
				{
					return new XSize(this._page.Width, this._page.Height);
				}
				return this._form.Size;
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00008FF2 File Offset: 0x000071F2
		internal string GetFontName(XFont font, out PdfFont pdfFont)
		{
			if (this._page != null)
			{
				return this._page.GetFontName(font, out pdfFont);
			}
			return this._form.GetFontName(font, out pdfFont);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00009017 File Offset: 0x00007217
		internal string GetImageName(XImage image)
		{
			if (this._page != null)
			{
				return this._page.GetImageName(image);
			}
			return this._form.GetImageName(image);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000903A File Offset: 0x0000723A
		internal string GetFormName(XForm form)
		{
			if (this._page != null)
			{
				return this._page.GetFormName(form);
			}
			return this._form.GetFormName(form);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00009060 File Offset: 0x00007260
		private void SaveState()
		{
			this._gfxStateStack.Push(this._gfxState);
			this._gfxState = this._gfxState.Clone();
			this._gfxState.Level = this._gfxStateStack.Count;
			this.Append("q\n");
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000090B0 File Offset: 0x000072B0
		private void RestoreState()
		{
			this._gfxState = this._gfxStateStack.Pop();
			this.Append("Q\n");
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000090D0 File Offset: 0x000072D0
		private PdfGraphicsState RestoreState(InternalGraphicsState state)
		{
			int num = 1;
			PdfGraphicsState pdfGraphicsState = this._gfxStateStack.Pop();
			while (pdfGraphicsState.InternalState != state)
			{
				this.Append("Q\n");
				num++;
				pdfGraphicsState = this._gfxStateStack.Pop();
			}
			this.Append("Q\n");
			this._gfxState = pdfGraphicsState;
			return pdfGraphicsState;
		}

		// Token: 0x0400009C RID: 156
		private const int GraphicsStackLevelInitial = 0;

		// Token: 0x0400009D RID: 157
		private const int GraphicsStackLevelPageSpace = 1;

		// Token: 0x0400009E RID: 158
		private const int GraphicsStackLevelWorldSpace = 2;

		// Token: 0x0400009F RID: 159
		private int _clipLevel;

		// Token: 0x040000A0 RID: 160
		private StreamMode _streamMode;

		// Token: 0x040000A1 RID: 161
		internal PdfPage _page;

		// Token: 0x040000A2 RID: 162
		internal XForm _form;

		// Token: 0x040000A3 RID: 163
		internal PdfColorMode _colorMode;

		// Token: 0x040000A4 RID: 164
		private XGraphicsPdfPageOptions _options;

		// Token: 0x040000A5 RID: 165
		private XGraphics _gfx;

		// Token: 0x040000A6 RID: 166
		private readonly StringBuilder _content;

		// Token: 0x040000A7 RID: 167
		private PdfGraphicsState _gfxState;

		// Token: 0x040000A8 RID: 168
		private readonly Stack<PdfGraphicsState> _gfxStateStack = new Stack<PdfGraphicsState>();

		// Token: 0x040000A9 RID: 169
		public double PageHeightPt;

		// Token: 0x040000AA RID: 170
		public XMatrix DefaultViewMatrix;
	}
}
