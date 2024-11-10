using System;
using PdfSharp.Drawing.BarCodes;
using PdfSharp.Drawing.Pdf;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Drawing
{
	// Token: 0x02000067 RID: 103
	public sealed class XGraphics : IDisposable
	{
		// Token: 0x060003BE RID: 958 RVA: 0x0001086C File Offset: 0x0000EA6C
		private XGraphics(PdfPage page, XGraphicsPdfPageOptions options, XGraphicsUnit pageUnit, XPageDirection pageDirection)
		{
			if (page == null)
			{
				throw new ArgumentNullException("page");
			}
			if (page.Owner == null)
			{
				throw new ArgumentException("You cannot draw on a page that is not owned by a PdfDocument object.", "page");
			}
			if (page.RenderContent != null)
			{
				throw new InvalidOperationException("An XGraphics object already exists for this page and must be disposed before a new one can be created.");
			}
			if (page.Owner.IsReadOnly)
			{
				throw new InvalidOperationException("Cannot create XGraphics for a page of a document that cannot be modified. Use PdfDocumentOpenMode.Modify.");
			}
			this._gsStack = new GraphicsStateStack(this);
			PdfContent pdfContent = null;
			switch (options)
			{
			case XGraphicsPdfPageOptions.Append:
				break;
			case XGraphicsPdfPageOptions.Prepend:
				pdfContent = page.Contents.PrependContent();
				goto IL_A7;
			case XGraphicsPdfPageOptions.Replace:
				page.Contents.Elements.Clear();
				break;
			default:
				goto IL_A7;
			}
			pdfContent = page.Contents.AppendContent();
			IL_A7:
			page.RenderContent = pdfContent;
			this.TargetContext = XGraphicTargetContext.CORE;
			this._renderer = new XGraphicsPdfRenderer(page, this, options);
			this._pageSizePoints = new XSize(page.Width, page.Height);
			switch (pageUnit)
			{
			case XGraphicsUnit.Point:
				this._pageSize = new XSize(page.Width, page.Height);
				break;
			case XGraphicsUnit.Inch:
				this._pageSize = new XSize(XUnit.FromPoint(page.Width).Inch, XUnit.FromPoint(page.Height).Inch);
				break;
			case XGraphicsUnit.Millimeter:
				this._pageSize = new XSize(XUnit.FromPoint(page.Width).Millimeter, XUnit.FromPoint(page.Height).Millimeter);
				break;
			case XGraphicsUnit.Centimeter:
				this._pageSize = new XSize(XUnit.FromPoint(page.Width).Centimeter, XUnit.FromPoint(page.Height).Centimeter);
				break;
			case XGraphicsUnit.Presentation:
				this._pageSize = new XSize(XUnit.FromPoint(page.Width).Presentation, XUnit.FromPoint(page.Height).Presentation);
				break;
			default:
				throw new NotImplementedException("unit");
			}
			this._pageUnit = pageUnit;
			this._pageDirection = pageDirection;
			this.Initialize();
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00010AD4 File Offset: 0x0000ECD4
		private XGraphics(XForm form)
		{
			if (form == null)
			{
				throw new ArgumentNullException("form");
			}
			this._form = form;
			form.AssociateGraphics(this);
			this._gsStack = new GraphicsStateStack(this);
			this.TargetContext = XGraphicTargetContext.CORE;
			this._drawGraphics = false;
			if (form.Owner != null)
			{
				this._renderer = new XGraphicsPdfRenderer(form, this);
			}
			this._pageSize = form.Size;
			this.Initialize();
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00010B44 File Offset: 0x0000ED44
		public static XGraphics CreateMeasureContext(XSize size, XGraphicsUnit pageUnit, XPageDirection pageDirection)
		{
			PdfDocument pdfDocument = new PdfDocument();
			PdfPage pdfPage = pdfDocument.AddPage();
			return XGraphics.FromPdfPage(pdfPage, XGraphicsPdfPageOptions.Append, pageUnit, pageDirection);
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00010B69 File Offset: 0x0000ED69
		public static XGraphics FromPdfPage(PdfPage page)
		{
			return new XGraphics(page, XGraphicsPdfPageOptions.Append, XGraphicsUnit.Point, XPageDirection.Downwards);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00010B74 File Offset: 0x0000ED74
		public static XGraphics FromPdfPage(PdfPage page, XGraphicsUnit unit)
		{
			return new XGraphics(page, XGraphicsPdfPageOptions.Append, unit, XPageDirection.Downwards);
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00010B7F File Offset: 0x0000ED7F
		public static XGraphics FromPdfPage(PdfPage page, XPageDirection pageDirection)
		{
			return new XGraphics(page, XGraphicsPdfPageOptions.Append, XGraphicsUnit.Point, pageDirection);
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00010B8A File Offset: 0x0000ED8A
		public static XGraphics FromPdfPage(PdfPage page, XGraphicsPdfPageOptions options)
		{
			return new XGraphics(page, options, XGraphicsUnit.Point, XPageDirection.Downwards);
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00010B95 File Offset: 0x0000ED95
		public static XGraphics FromPdfPage(PdfPage page, XGraphicsPdfPageOptions options, XPageDirection pageDirection)
		{
			return new XGraphics(page, options, XGraphicsUnit.Point, pageDirection);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00010BA0 File Offset: 0x0000EDA0
		public static XGraphics FromPdfPage(PdfPage page, XGraphicsPdfPageOptions options, XGraphicsUnit unit)
		{
			return new XGraphics(page, options, unit, XPageDirection.Downwards);
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00010BAB File Offset: 0x0000EDAB
		public static XGraphics FromPdfPage(PdfPage page, XGraphicsPdfPageOptions options, XGraphicsUnit unit, XPageDirection pageDirection)
		{
			return new XGraphics(page, options, unit, pageDirection);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00010BB6 File Offset: 0x0000EDB6
		public static XGraphics FromPdfForm(XPdfForm form)
		{
			if (form.Gfx != null)
			{
				return form.Gfx;
			}
			return new XGraphics(form);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00010BCD File Offset: 0x0000EDCD
		public static XGraphics FromForm(XForm form)
		{
			if (form.Gfx != null)
			{
				return form.Gfx;
			}
			return new XGraphics(form);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00010BE4 File Offset: 0x0000EDE4
		public static XGraphics FromImage(XImage image)
		{
			return XGraphics.FromImage(image, XGraphicsUnit.Point);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00010BF0 File Offset: 0x0000EDF0
		public static XGraphics FromImage(XImage image, XGraphicsUnit unit)
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			XBitmapImage xbitmapImage = image as XBitmapImage;
			if (xbitmapImage != null)
			{
				return null;
			}
			return null;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00010C18 File Offset: 0x0000EE18
		private void Initialize()
		{
			this._pageOrigin = default(XPoint);
			double num = this._pageSize.Height;
			PdfPage pdfPage = this.PdfPage;
			XPoint xpoint = default(XPoint);
			if (pdfPage != null && pdfPage.TrimMargins.AreSet)
			{
				num += pdfPage.TrimMargins.Top.Point + pdfPage.TrimMargins.Bottom.Point;
				xpoint = new XPoint(pdfPage.TrimMargins.Left.Point, pdfPage.TrimMargins.Top.Point);
			}
			XMatrix xmatrix = default(XMatrix);
			if (this._pageDirection != XPageDirection.Downwards)
			{
				xmatrix.Prepend(new XMatrix(1.0, 0.0, 0.0, -1.0, 0.0, num));
			}
			if (xpoint != default(XPoint))
			{
				xmatrix.TranslatePrepend(xpoint.X, -xpoint.Y);
			}
			this.DefaultViewMatrix = xmatrix;
			this._transform = default(XMatrix);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00010D3C File Offset: 0x0000EF3C
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00010D48 File Offset: 0x0000EF48
		private void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				this._disposed = true;
				if (disposing && this._associatedImage != null)
				{
					this._associatedImage.DisassociateWithGraphics(this);
					this._associatedImage = null;
				}
				if (this._form != null)
				{
					this._form.Finish();
				}
				this._drawGraphics = false;
				if (this._renderer != null)
				{
					this._renderer.Close();
					this._renderer = null;
				}
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060003CF RID: 975 RVA: 0x00010DB6 File Offset: 0x0000EFB6
		// (set) Token: 0x060003D0 RID: 976 RVA: 0x00010DBE File Offset: 0x0000EFBE
		public PdfFontEncoding MUH
		{
			get
			{
				return this._muh;
			}
			set
			{
				this._muh = value;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x00010DC7 File Offset: 0x0000EFC7
		public XGraphicsUnit PageUnit
		{
			get
			{
				return this._pageUnit;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x00010DCF File Offset: 0x0000EFCF
		// (set) Token: 0x060003D3 RID: 979 RVA: 0x00010DD7 File Offset: 0x0000EFD7
		public XPageDirection PageDirection
		{
			get
			{
				return this._pageDirection;
			}
			set
			{
				if (value != XPageDirection.Downwards)
				{
					throw new NotImplementedException("PageDirection must be XPageDirection.Downwards in current implementation.");
				}
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060003D4 RID: 980 RVA: 0x00010DE7 File Offset: 0x0000EFE7
		// (set) Token: 0x060003D5 RID: 981 RVA: 0x00010DF0 File Offset: 0x0000EFF0
		public XPoint PageOrigin
		{
			get
			{
				return this._pageOrigin;
			}
			set
			{
				if (value != default(XPoint))
				{
					throw new NotImplementedException("PageOrigin cannot be modified in current implementation.");
				}
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x00010E19 File Offset: 0x0000F019
		public XSize PageSize
		{
			get
			{
				return this._pageSize;
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00010E21 File Offset: 0x0000F021
		public void DrawLine(XPen pen, XPoint pt1, XPoint pt2)
		{
			this.DrawLine(pen, pt1.X, pt1.Y, pt2.X, pt2.Y);
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00010E48 File Offset: 0x0000F048
		public void DrawLine(XPen pen, double x1, double y1, double x2, double y2)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawLines(pen, new XPoint[]
				{
					new XPoint(x1, y1),
					new XPoint(x2, y2)
				});
			}
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00010EB0 File Offset: 0x0000F0B0
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
			if (points.Length < 2)
			{
				throw new ArgumentException("points", PSSR.PointArrayAtLeast(2));
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawLines(pen, points);
			}
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00010F0C File Offset: 0x0000F10C
		public void DrawLines(XPen pen, double x, double y, params double[] value)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			int num = value.Length;
			XPoint[] array = new XPoint[num / 2 + 1];
			array[0].X = x;
			array[0].Y = y;
			for (int i = 0; i < num / 2; i++)
			{
				array[i + 1].X = value[2 * i];
				array[i + 1].Y = value[2 * i + 1];
			}
			this.DrawLines(pen, array);
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00010FA0 File Offset: 0x0000F1A0
		public void DrawBezier(XPen pen, XPoint pt1, XPoint pt2, XPoint pt3, XPoint pt4)
		{
			this.DrawBezier(pen, pt1.X, pt1.Y, pt2.X, pt2.Y, pt3.X, pt3.Y, pt4.X, pt4.Y);
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00010FEC File Offset: 0x0000F1EC
		public void DrawBezier(XPen pen, double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawBeziers(pen, new XPoint[]
				{
					new XPoint(x1, y1),
					new XPoint(x2, y2),
					new XPoint(x3, y3),
					new XPoint(x4, y4)
				});
			}
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0001107C File Offset: 0x0000F27C
		public void DrawBeziers(XPen pen, XPoint[] points)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
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
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawBeziers(pen, points);
			}
		}

		// Token: 0x060003DE RID: 990 RVA: 0x000110D2 File Offset: 0x0000F2D2
		public void DrawCurve(XPen pen, XPoint[] points)
		{
			this.DrawCurve(pen, points, 0.5);
		}

		// Token: 0x060003DF RID: 991 RVA: 0x000110E8 File Offset: 0x0000F2E8
		public void DrawCurve(XPen pen, XPoint[] points, int offset, int numberOfSegments, double tension)
		{
			XPoint[] array = new XPoint[numberOfSegments];
			Array.Copy(points, offset, array, 0, numberOfSegments);
			this.DrawCurve(pen, array, tension);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00011114 File Offset: 0x0000F314
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
			if (num < 2)
			{
				throw new ArgumentException("DrawCurve requires two or more points.", "points");
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawCurve(pen, points, tension);
			}
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00011172 File Offset: 0x0000F372
		public void DrawArc(XPen pen, XRect rect, double startAngle, double sweepAngle)
		{
			this.DrawArc(pen, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0001119C File Offset: 0x0000F39C
		public void DrawArc(XPen pen, double x, double y, double width, double height, double startAngle, double sweepAngle)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			if (Math.Abs(sweepAngle) >= 360.0)
			{
				this.DrawEllipse(pen, x, y, width, height);
				return;
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x000111FC File Offset: 0x0000F3FC
		public void DrawRectangle(XPen pen, XRect rect)
		{
			this.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00011221 File Offset: 0x0000F421
		public void DrawRectangle(XPen pen, double x, double y, double width, double height)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawRectangle(pen, null, x, y, width, height);
			}
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00011253 File Offset: 0x0000F453
		public void DrawRectangle(XBrush brush, XRect rect)
		{
			this.DrawRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00011278 File Offset: 0x0000F478
		public void DrawRectangle(XBrush brush, double x, double y, double width, double height)
		{
			if (brush == null)
			{
				throw new ArgumentNullException("brush");
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawRectangle(null, brush, x, y, width, height);
			}
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x000112AA File Offset: 0x0000F4AA
		public void DrawRectangle(XPen pen, XBrush brush, XRect rect)
		{
			this.DrawRectangle(pen, brush, rect.X, rect.Y, rect.Width, rect.Height);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x000112D0 File Offset: 0x0000F4D0
		public void DrawRectangle(XPen pen, XBrush brush, double x, double y, double width, double height)
		{
			if (pen == null && brush == null)
			{
				throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawRectangle(pen, brush, x, y, width, height);
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0001130B File Offset: 0x0000F50B
		public void DrawRectangles(XPen pen, XRect[] rectangles)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			if (rectangles == null)
			{
				throw new ArgumentNullException("rectangles");
			}
			this.DrawRectangles(pen, null, rectangles);
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00011332 File Offset: 0x0000F532
		public void DrawRectangles(XBrush brush, XRect[] rectangles)
		{
			if (brush == null)
			{
				throw new ArgumentNullException("brush");
			}
			if (rectangles == null)
			{
				throw new ArgumentNullException("rectangles");
			}
			this.DrawRectangles(null, brush, rectangles);
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0001135C File Offset: 0x0000F55C
		public void DrawRectangles(XPen pen, XBrush brush, XRect[] rectangles)
		{
			if (pen == null && brush == null)
			{
				throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
			}
			if (rectangles == null)
			{
				throw new ArgumentNullException("rectangles");
			}
			int num = rectangles.Length;
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				for (int i = 0; i < num; i++)
				{
					XRect xrect = rectangles[i];
					this._renderer.DrawRectangle(pen, brush, xrect.X, xrect.Y, xrect.Width, xrect.Height);
				}
			}
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x000113E2 File Offset: 0x0000F5E2
		public void DrawRoundedRectangle(XPen pen, XRect rect, XSize ellipseSize)
		{
			this.DrawRoundedRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height, ellipseSize.Width, ellipseSize.Height);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00011418 File Offset: 0x0000F618
		public void DrawRoundedRectangle(XPen pen, double x, double y, double width, double height, double ellipseWidth, double ellipseHeight)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			this.DrawRoundedRectangle(pen, null, x, y, width, height, ellipseWidth, ellipseHeight);
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00011445 File Offset: 0x0000F645
		public void DrawRoundedRectangle(XBrush brush, XRect rect, XSize ellipseSize)
		{
			this.DrawRoundedRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height, ellipseSize.Width, ellipseSize.Height);
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00011478 File Offset: 0x0000F678
		public void DrawRoundedRectangle(XBrush brush, double x, double y, double width, double height, double ellipseWidth, double ellipseHeight)
		{
			if (brush == null)
			{
				throw new ArgumentNullException("brush");
			}
			this.DrawRoundedRectangle(null, brush, x, y, width, height, ellipseWidth, ellipseHeight);
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x000114A8 File Offset: 0x0000F6A8
		public void DrawRoundedRectangle(XPen pen, XBrush brush, XRect rect, XSize ellipseSize)
		{
			this.DrawRoundedRectangle(pen, brush, rect.X, rect.Y, rect.Width, rect.Height, ellipseSize.Width, ellipseSize.Height);
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x000114E8 File Offset: 0x0000F6E8
		public void DrawRoundedRectangle(XPen pen, XBrush brush, double x, double y, double width, double height, double ellipseWidth, double ellipseHeight)
		{
			if (pen == null && brush == null)
			{
				throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawRoundedRectangle(pen, brush, x, y, width, height, ellipseWidth, ellipseHeight);
			}
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00011532 File Offset: 0x0000F732
		public void DrawEllipse(XPen pen, XRect rect)
		{
			this.DrawEllipse(pen, rect.X, rect.Y, rect.Width, rect.Height);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00011557 File Offset: 0x0000F757
		public void DrawEllipse(XPen pen, double x, double y, double width, double height)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawEllipse(pen, null, x, y, width, height);
			}
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00011589 File Offset: 0x0000F789
		public void DrawEllipse(XBrush brush, XRect rect)
		{
			this.DrawEllipse(brush, rect.X, rect.Y, rect.Width, rect.Height);
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x000115AE File Offset: 0x0000F7AE
		public void DrawEllipse(XBrush brush, double x, double y, double width, double height)
		{
			if (brush == null)
			{
				throw new ArgumentNullException("brush");
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawEllipse(null, brush, x, y, width, height);
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x000115E0 File Offset: 0x0000F7E0
		public void DrawEllipse(XPen pen, XBrush brush, XRect rect)
		{
			this.DrawEllipse(pen, brush, rect.X, rect.Y, rect.Width, rect.Height);
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00011606 File Offset: 0x0000F806
		public void DrawEllipse(XPen pen, XBrush brush, double x, double y, double width, double height)
		{
			if (pen == null && brush == null)
			{
				throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawEllipse(pen, brush, x, y, width, height);
			}
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00011644 File Offset: 0x0000F844
		public void DrawPolygon(XPen pen, XPoint[] points)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			if (points.Length < 2)
			{
				throw new ArgumentException("points", PSSR.PointArrayAtLeast(2));
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawPolygon(pen, null, points, XFillMode.Alternate);
			}
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x000116A4 File Offset: 0x0000F8A4
		public void DrawPolygon(XBrush brush, XPoint[] points, XFillMode fillmode)
		{
			if (brush == null)
			{
				throw new ArgumentNullException("brush");
			}
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			if (points.Length < 2)
			{
				throw new ArgumentException("points", PSSR.PointArrayAtLeast(2));
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawPolygon(null, brush, points, fillmode);
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00011704 File Offset: 0x0000F904
		public void DrawPolygon(XPen pen, XBrush brush, XPoint[] points, XFillMode fillmode)
		{
			if (pen == null && brush == null)
			{
				throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
			}
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			if (points.Length < 2)
			{
				throw new ArgumentException("points", PSSR.PointArrayAtLeast(2));
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawPolygon(pen, brush, points, fillmode);
			}
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0001176B File Offset: 0x0000F96B
		public void DrawPie(XPen pen, XRect rect, double startAngle, double sweepAngle)
		{
			this.DrawPie(pen, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00011794 File Offset: 0x0000F994
		public void DrawPie(XPen pen, double x, double y, double width, double height, double startAngle, double sweepAngle)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen", PSSR.NeedPenOrBrush);
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawPie(pen, null, x, y, width, height, startAngle, sweepAngle);
			}
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x000117DA File Offset: 0x0000F9DA
		public void DrawPie(XBrush brush, XRect rect, double startAngle, double sweepAngle)
		{
			this.DrawPie(brush, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00011804 File Offset: 0x0000FA04
		public void DrawPie(XBrush brush, double x, double y, double width, double height, double startAngle, double sweepAngle)
		{
			if (brush == null)
			{
				throw new ArgumentNullException("brush", PSSR.NeedPenOrBrush);
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawPie(null, brush, x, y, width, height, startAngle, sweepAngle);
			}
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0001184C File Offset: 0x0000FA4C
		public void DrawPie(XPen pen, XBrush brush, XRect rect, double startAngle, double sweepAngle)
		{
			this.DrawPie(pen, brush, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00011884 File Offset: 0x0000FA84
		public void DrawPie(XPen pen, XBrush brush, double x, double y, double width, double height, double startAngle, double sweepAngle)
		{
			if (pen == null && brush == null)
			{
				throw new ArgumentNullException("pen", PSSR.NeedPenOrBrush);
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawPie(pen, brush, x, y, width, height, startAngle, sweepAngle);
			}
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x000118CE File Offset: 0x0000FACE
		public void DrawClosedCurve(XPen pen, XPoint[] points)
		{
			this.DrawClosedCurve(pen, null, points, XFillMode.Alternate, 0.5);
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x000118E3 File Offset: 0x0000FAE3
		public void DrawClosedCurve(XPen pen, XPoint[] points, double tension)
		{
			this.DrawClosedCurve(pen, null, points, XFillMode.Alternate, tension);
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x000118F0 File Offset: 0x0000FAF0
		public void DrawClosedCurve(XBrush brush, XPoint[] points)
		{
			this.DrawClosedCurve(null, brush, points, XFillMode.Alternate, 0.5);
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00011905 File Offset: 0x0000FB05
		public void DrawClosedCurve(XBrush brush, XPoint[] points, XFillMode fillmode)
		{
			this.DrawClosedCurve(null, brush, points, fillmode, 0.5);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0001191A File Offset: 0x0000FB1A
		public void DrawClosedCurve(XBrush brush, XPoint[] points, XFillMode fillmode, double tension)
		{
			this.DrawClosedCurve(null, brush, points, fillmode, tension);
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00011928 File Offset: 0x0000FB28
		public void DrawClosedCurve(XPen pen, XBrush brush, XPoint[] points)
		{
			this.DrawClosedCurve(pen, brush, points, XFillMode.Alternate, 0.5);
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0001193D File Offset: 0x0000FB3D
		public void DrawClosedCurve(XPen pen, XBrush brush, XPoint[] points, XFillMode fillmode)
		{
			this.DrawClosedCurve(pen, brush, points, fillmode, 0.5);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00011954 File Offset: 0x0000FB54
		public void DrawClosedCurve(XPen pen, XBrush brush, XPoint[] points, XFillMode fillmode, double tension)
		{
			if (pen == null && brush == null)
			{
				throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
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
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawClosedCurve(pen, brush, points, tension, fillmode);
			}
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x000119B4 File Offset: 0x0000FBB4
		public void DrawPath(XPen pen, XGraphicsPath path)
		{
			if (pen == null)
			{
				throw new ArgumentNullException("pen");
			}
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawPath(pen, null, path);
			}
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x000119EF File Offset: 0x0000FBEF
		public void DrawPath(XBrush brush, XGraphicsPath path)
		{
			if (brush == null)
			{
				throw new ArgumentNullException("brush");
			}
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawPath(null, brush, path);
			}
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00011A2C File Offset: 0x0000FC2C
		public void DrawPath(XPen pen, XBrush brush, XGraphicsPath path)
		{
			if (pen == null && brush == null)
			{
				throw new ArgumentNullException("pen and brush", PSSR.NeedPenOrBrush);
			}
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawPath(pen, brush, path);
			}
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00011A7A File Offset: 0x0000FC7A
		public void DrawString(string s, XFont font, XBrush brush, XPoint point)
		{
			this.DrawString(s, font, brush, new XRect(point.X, point.Y, 0.0, 0.0), XStringFormats.Default);
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00011AAF File Offset: 0x0000FCAF
		public void DrawString(string s, XFont font, XBrush brush, XPoint point, XStringFormat format)
		{
			this.DrawString(s, font, brush, new XRect(point.X, point.Y, 0.0, 0.0), format);
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00011AE1 File Offset: 0x0000FCE1
		public void DrawString(string s, XFont font, XBrush brush, double x, double y)
		{
			this.DrawString(s, font, brush, new XRect(x, y, 0.0, 0.0), XStringFormats.Default);
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00011B0C File Offset: 0x0000FD0C
		public void DrawString(string s, XFont font, XBrush brush, double x, double y, XStringFormat format)
		{
			this.DrawString(s, font, brush, new XRect(x, y, 0.0, 0.0), format);
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00011B34 File Offset: 0x0000FD34
		public void DrawString(string s, XFont font, XBrush brush, XRect layoutRectangle)
		{
			this.DrawString(s, font, brush, layoutRectangle, XStringFormats.Default);
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00011B48 File Offset: 0x0000FD48
		public void DrawString(string text, XFont font, XBrush brush, XRect layoutRectangle, XStringFormat format)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			if (font == null)
			{
				throw new ArgumentNullException("font");
			}
			if (brush == null)
			{
				throw new ArgumentNullException("brush");
			}
			if (format != null && format.LineAlignment == XLineAlignment.BaseLine && layoutRectangle.Height != 0.0)
			{
				throw new InvalidOperationException("DrawString: With XLineAlignment.BaseLine the height of the layout rectangle must be 0.");
			}
			if (text.Length == 0)
			{
				return;
			}
			if (format == null)
			{
				format = XStringFormats.Default;
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawString(text, font, brush, layoutRectangle, format);
			}
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00011BE0 File Offset: 0x0000FDE0
		public XSize MeasureString(string text, XFont font, XStringFormat stringFormat)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			if (font == null)
			{
				throw new ArgumentNullException("font");
			}
			if (stringFormat == null)
			{
				throw new ArgumentNullException("stringFormat");
			}
			return FontHelper.MeasureString(text, font, XStringFormats.Default);
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00011C25 File Offset: 0x0000FE25
		public XSize MeasureString(string text, XFont font)
		{
			return this.MeasureString(text, font, XStringFormats.Default);
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00011C34 File Offset: 0x0000FE34
		public void DrawImage(XImage image, XPoint point)
		{
			this.DrawImage(image, point.X, point.Y);
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00011C4C File Offset: 0x0000FE4C
		public void DrawImage(XImage image, double x, double y)
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			this.CheckXPdfFormConsistence(image);
			double pointWidth = image.PointWidth;
			double pointHeight = image.PointHeight;
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawImage(image, x, y, image.PointWidth, image.PointHeight);
			}
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00011CA5 File Offset: 0x0000FEA5
		public void DrawImage(XImage image, XRect rect)
		{
			this.DrawImage(image, rect.X, rect.Y, rect.Width, rect.Height);
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00011CCA File Offset: 0x0000FECA
		public void DrawImage(XImage image, double x, double y, double width, double height)
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			this.CheckXPdfFormConsistence(image);
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawImage(image, x, y, width, height);
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00011D02 File Offset: 0x0000FF02
		public void DrawImage(XImage image, XRect destRect, XRect srcRect, XGraphicsUnit srcUnit)
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			this.CheckXPdfFormConsistence(image);
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.DrawImage(image, destRect, srcRect, srcUnit);
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00011D38 File Offset: 0x0000FF38
		private void DrawMissingImageRect(XRect rect)
		{
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00011D3C File Offset: 0x0000FF3C
		private void CheckXPdfFormConsistence(XImage image)
		{
			XForm xform = image as XForm;
			if (xform != null)
			{
				xform.Finish();
				if (this._renderer != null && this._renderer is XGraphicsPdfRenderer)
				{
					if (xform.Owner != null && xform.Owner != ((XGraphicsPdfRenderer)this._renderer).Owner)
					{
						throw new InvalidOperationException("A XPdfForm object is always bound to the document it was created for and cannot be drawn in the context of another document.");
					}
					if (xform == ((XGraphicsPdfRenderer)this._renderer)._form)
					{
						throw new InvalidOperationException("A XPdfForm cannot be drawn on itself.");
					}
				}
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00011DB7 File Offset: 0x0000FFB7
		public void DrawBarCode(BarCode barcode, XPoint position)
		{
			barcode.Render(this, XBrushes.Black, null, position);
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00011DC7 File Offset: 0x0000FFC7
		public void DrawBarCode(BarCode barcode, XBrush brush, XPoint position)
		{
			barcode.Render(this, brush, null, position);
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00011DD3 File Offset: 0x0000FFD3
		public void DrawBarCode(BarCode barcode, XBrush brush, XFont font, XPoint position)
		{
			barcode.Render(this, brush, font, position);
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00011DE0 File Offset: 0x0000FFE0
		public void DrawMatrixCode(MatrixCode matrixcode, XPoint position)
		{
			matrixcode.Render(this, XBrushes.Black, position);
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00011DEF File Offset: 0x0000FFEF
		public void DrawMatrixCode(MatrixCode matrixcode, XBrush brush, XPoint position)
		{
			matrixcode.Render(this, brush, position);
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00011DFC File Offset: 0x0000FFFC
		public XGraphicsState Save()
		{
			XGraphicsState xgraphicsState = null;
			if (this.TargetContext == XGraphicTargetContext.CORE || this.TargetContext == XGraphicTargetContext.NONE)
			{
				xgraphicsState = new XGraphicsState();
				InternalGraphicsState internalGraphicsState = new InternalGraphicsState(this, xgraphicsState);
				internalGraphicsState.Transform = this._transform;
				this._gsStack.Push(internalGraphicsState);
			}
			if (this._renderer != null)
			{
				this._renderer.Save(xgraphicsState);
			}
			return xgraphicsState;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00011E58 File Offset: 0x00010058
		public void Restore(XGraphicsState state)
		{
			if (state == null)
			{
				throw new ArgumentNullException("state");
			}
			if (this.TargetContext == XGraphicTargetContext.CORE)
			{
				this._gsStack.Restore(state.InternalState);
				this._transform = state.InternalState.Transform;
			}
			if (this._renderer != null)
			{
				this._renderer.Restore(state);
			}
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00011EB3 File Offset: 0x000100B3
		public void Restore()
		{
			if (this._gsStack.Count == 0)
			{
				throw new InvalidOperationException("Cannot restore without preceding save operation.");
			}
			this.Restore(this._gsStack.Current.State);
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00011EE4 File Offset: 0x000100E4
		public XGraphicsContainer BeginContainer()
		{
			return this.BeginContainer(new XRect(0.0, 0.0, 1.0, 1.0), new XRect(0.0, 0.0, 1.0, 1.0), XGraphicsUnit.Point);
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00011F4C File Offset: 0x0001014C
		public XGraphicsContainer BeginContainer(XRect dstrect, XRect srcrect, XGraphicsUnit unit)
		{
			if (unit != XGraphicsUnit.Point)
			{
				throw new ArgumentException("The current implementation supports XGraphicsUnit.Point only.", "unit");
			}
			XGraphicsContainer xgraphicsContainer = null;
			if (this.TargetContext == XGraphicTargetContext.CORE)
			{
				xgraphicsContainer = new XGraphicsContainer();
			}
			InternalGraphicsState internalGraphicsState = new InternalGraphicsState(this, xgraphicsContainer);
			internalGraphicsState.Transform = this._transform;
			this._gsStack.Push(internalGraphicsState);
			if (this._renderer != null)
			{
				this._renderer.BeginContainer(xgraphicsContainer, dstrect, srcrect, unit);
			}
			XMatrix xmatrix = default(XMatrix);
			double num = dstrect.Width / srcrect.Width;
			double num2 = dstrect.Height / srcrect.Height;
			xmatrix.TranslatePrepend(-srcrect.X, -srcrect.Y);
			xmatrix.ScalePrepend(num, num2);
			xmatrix.TranslatePrepend(dstrect.X / num, dstrect.Y / num2);
			this.AddTransform(xmatrix, XMatrixOrder.Prepend);
			return xgraphicsContainer;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00012024 File Offset: 0x00010224
		public void EndContainer(XGraphicsContainer container)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}
			this._gsStack.Restore(container.InternalState);
			this._transform = container.InternalState.Transform;
			if (this._renderer != null)
			{
				this._renderer.EndContainer(container);
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x00012076 File Offset: 0x00010276
		public int GraphicsStateLevel
		{
			get
			{
				return this._gsStack.Count;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x00012083 File Offset: 0x00010283
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x0001208B File Offset: 0x0001028B
		public XSmoothingMode SmoothingMode
		{
			get
			{
				return this._smoothingMode;
			}
			set
			{
				this._smoothingMode = value;
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00012094 File Offset: 0x00010294
		public void TranslateTransform(double dx, double dy)
		{
			this.AddTransform(XMatrix.CreateTranslation(dx, dy), XMatrixOrder.Prepend);
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x000120A4 File Offset: 0x000102A4
		public void TranslateTransform(double dx, double dy, XMatrixOrder order)
		{
			XMatrix xmatrix = default(XMatrix);
			xmatrix.TranslatePrepend(dx, dy);
			this.AddTransform(xmatrix, order);
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x000120CA File Offset: 0x000102CA
		public void ScaleTransform(double scaleX, double scaleY)
		{
			this.AddTransform(XMatrix.CreateScaling(scaleX, scaleY), XMatrixOrder.Prepend);
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x000120DC File Offset: 0x000102DC
		public void ScaleTransform(double scaleX, double scaleY, XMatrixOrder order)
		{
			XMatrix xmatrix = default(XMatrix);
			xmatrix.ScalePrepend(scaleX, scaleY);
			this.AddTransform(xmatrix, order);
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00012102 File Offset: 0x00010302
		public void ScaleTransform(double scaleXY)
		{
			this.ScaleTransform(scaleXY, scaleXY);
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0001210C File Offset: 0x0001030C
		public void ScaleTransform(double scaleXY, XMatrixOrder order)
		{
			this.ScaleTransform(scaleXY, scaleXY, order);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00012117 File Offset: 0x00010317
		public void ScaleAtTransform(double scaleX, double scaleY, double centerX, double centerY)
		{
			this.AddTransform(XMatrix.CreateScaling(scaleX, scaleY, centerX, centerY), XMatrixOrder.Prepend);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0001212A File Offset: 0x0001032A
		public void ScaleAtTransform(double scaleX, double scaleY, XPoint center)
		{
			this.AddTransform(XMatrix.CreateScaling(scaleX, scaleY, center.X, center.Y), XMatrixOrder.Prepend);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00012148 File Offset: 0x00010348
		public void RotateTransform(double angle)
		{
			this.AddTransform(XMatrix.CreateRotationRadians(angle * 0.017453292519943295), XMatrixOrder.Prepend);
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00012164 File Offset: 0x00010364
		public void RotateTransform(double angle, XMatrixOrder order)
		{
			XMatrix xmatrix = default(XMatrix);
			xmatrix.RotatePrepend(angle);
			this.AddTransform(xmatrix, order);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00012189 File Offset: 0x00010389
		public void RotateAtTransform(double angle, XPoint point)
		{
			this.AddTransform(XMatrix.CreateRotationRadians(angle * 0.017453292519943295, point.X, point.Y), XMatrixOrder.Prepend);
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000121B0 File Offset: 0x000103B0
		public void RotateAtTransform(double angle, XPoint point, XMatrixOrder order)
		{
			this.AddTransform(XMatrix.CreateRotationRadians(angle * 0.017453292519943295, point.X, point.Y), order);
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x000121D7 File Offset: 0x000103D7
		public void ShearTransform(double shearX, double shearY)
		{
			this.AddTransform(XMatrix.CreateSkewRadians(shearX * 0.017453292519943295, shearY * 0.017453292519943295), XMatrixOrder.Prepend);
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x000121FB File Offset: 0x000103FB
		public void ShearTransform(double shearX, double shearY, XMatrixOrder order)
		{
			this.AddTransform(XMatrix.CreateSkewRadians(shearX * 0.017453292519943295, shearY * 0.017453292519943295), order);
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0001221F File Offset: 0x0001041F
		public void SkewAtTransform(double shearX, double shearY, double centerX, double centerY)
		{
			this.AddTransform(XMatrix.CreateSkewRadians(shearX * 0.017453292519943295, shearY * 0.017453292519943295, centerX, centerY), XMatrixOrder.Prepend);
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00012246 File Offset: 0x00010446
		public void SkewAtTransform(double shearX, double shearY, XPoint center)
		{
			this.AddTransform(XMatrix.CreateSkewRadians(shearX * 0.017453292519943295, shearY * 0.017453292519943295, center.X, center.Y), XMatrixOrder.Prepend);
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00012278 File Offset: 0x00010478
		public void MultiplyTransform(XMatrix matrix)
		{
			this.AddTransform(matrix, XMatrixOrder.Prepend);
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00012282 File Offset: 0x00010482
		public void MultiplyTransform(XMatrix matrix, XMatrixOrder order)
		{
			this.AddTransform(matrix, order);
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x0001228C File Offset: 0x0001048C
		public XMatrix Transform
		{
			get
			{
				return this._transform;
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00012294 File Offset: 0x00010494
		private void AddTransform(XMatrix transform, XMatrixOrder order)
		{
			XMatrix xmatrix = this._transform;
			xmatrix.Multiply(transform, order);
			this._transform = xmatrix;
			xmatrix = this.DefaultViewMatrix;
			xmatrix.Multiply(this._transform, XMatrixOrder.Prepend);
			if (this.TargetContext == XGraphicTargetContext.CORE)
			{
				base.GetType();
			}
			if (this._renderer != null)
			{
				this._renderer.AddTransform(transform, XMatrixOrder.Prepend);
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x000122F4 File Offset: 0x000104F4
		public void IntersectClip(XRect rect)
		{
			XGraphicsPath xgraphicsPath = new XGraphicsPath();
			xgraphicsPath.AddRectangle(rect);
			this.IntersectClip(xgraphicsPath);
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00012315 File Offset: 0x00010515
		public void IntersectClip(XGraphicsPath path)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.SetClip(path, XCombineMode.Intersect);
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00012341 File Offset: 0x00010541
		public void WriteComment(string comment)
		{
			if (comment == null)
			{
				throw new ArgumentNullException("comment");
			}
			bool drawGraphics = this._drawGraphics;
			if (this._renderer != null)
			{
				this._renderer.WriteComment(comment);
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x0001236C File Offset: 0x0001056C
		public XGraphics.XGraphicsInternals Internals
		{
			get
			{
				XGraphics.XGraphicsInternals xgraphicsInternals;
				if ((xgraphicsInternals = this._internals) == null)
				{
					xgraphicsInternals = (this._internals = new XGraphics.XGraphicsInternals(this));
				}
				return xgraphicsInternals;
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x00012394 File Offset: 0x00010594
		public XGraphics.SpaceTransformer Transformer
		{
			get
			{
				XGraphics.SpaceTransformer spaceTransformer;
				if ((spaceTransformer = this._transformer) == null)
				{
					spaceTransformer = (this._transformer = new XGraphics.SpaceTransformer(this));
				}
				return spaceTransformer;
			}
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x000123BA File Offset: 0x000105BA
		internal void DisassociateImage()
		{
			if (this._associatedImage == null)
			{
				throw new InvalidOperationException("No image associated.");
			}
			this.Dispose();
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x000123D5 File Offset: 0x000105D5
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x000123DD File Offset: 0x000105DD
		internal InternalGraphicsMode InternalGraphicsMode
		{
			get
			{
				return this._internalGraphicsMode;
			}
			set
			{
				this._internalGraphicsMode = value;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x000123E6 File Offset: 0x000105E6
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x000123EE File Offset: 0x000105EE
		internal XImage AssociatedImage
		{
			get
			{
				return this._associatedImage;
			}
			set
			{
				this._associatedImage = value;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x000123F8 File Offset: 0x000105F8
		public PdfPage PdfPage
		{
			get
			{
				XGraphicsPdfRenderer xgraphicsPdfRenderer = this._renderer as XGraphicsPdfRenderer;
				if (xgraphicsPdfRenderer == null)
				{
					return null;
				}
				return xgraphicsPdfRenderer._page;
			}
		}

		// Token: 0x04000260 RID: 608
		private bool _disposed;

		// Token: 0x04000261 RID: 609
		private PdfFontEncoding _muh;

		// Token: 0x04000262 RID: 610
		internal XGraphicTargetContext TargetContext;

		// Token: 0x04000263 RID: 611
		private readonly XGraphicsUnit _pageUnit;

		// Token: 0x04000264 RID: 612
		private readonly XPageDirection _pageDirection;

		// Token: 0x04000265 RID: 613
		private XPoint _pageOrigin;

		// Token: 0x04000266 RID: 614
		private XSize _pageSize;

		// Token: 0x04000267 RID: 615
		private XSize _pageSizePoints;

		// Token: 0x04000268 RID: 616
		private XSmoothingMode _smoothingMode;

		// Token: 0x04000269 RID: 617
		private XGraphics.XGraphicsInternals _internals;

		// Token: 0x0400026A RID: 618
		private XGraphics.SpaceTransformer _transformer;

		// Token: 0x0400026B RID: 619
		private InternalGraphicsMode _internalGraphicsMode;

		// Token: 0x0400026C RID: 620
		private XImage _associatedImage;

		// Token: 0x0400026D RID: 621
		internal XMatrix DefaultViewMatrix;

		// Token: 0x0400026E RID: 622
		private bool _drawGraphics;

		// Token: 0x0400026F RID: 623
		private readonly XForm _form;

		// Token: 0x04000270 RID: 624
		private IXGraphicsRenderer _renderer;

		// Token: 0x04000271 RID: 625
		private XMatrix _transform;

		// Token: 0x04000272 RID: 626
		private readonly GraphicsStateStack _gsStack;

		// Token: 0x02000068 RID: 104
		public class XGraphicsInternals
		{
			// Token: 0x06000448 RID: 1096 RVA: 0x0001241C File Offset: 0x0001061C
			internal XGraphicsInternals(XGraphics gfx)
			{
				this._gfx = gfx;
			}

			// Token: 0x04000273 RID: 627
			private readonly XGraphics _gfx;
		}

		// Token: 0x02000069 RID: 105
		public class SpaceTransformer
		{
			// Token: 0x06000449 RID: 1097 RVA: 0x0001242B File Offset: 0x0001062B
			internal SpaceTransformer(XGraphics gfx)
			{
				this._gfx = gfx;
			}

			// Token: 0x0600044A RID: 1098 RVA: 0x0001243C File Offset: 0x0001063C
			public XRect WorldToDefaultPage(XRect rect)
			{
				XPoint[] array = new XPoint[]
				{
					new XPoint(rect.X, rect.Y),
					new XPoint(rect.X + rect.Width, rect.Y),
					new XPoint(rect.X, rect.Y + rect.Height),
					new XPoint(rect.X + rect.Width, rect.Y + rect.Height)
				};
				this._gfx.Transform.TransformPoints(array);
				double height = this._gfx.PageSize.Height;
				array[0].Y = height - array[0].Y;
				array[1].Y = height - array[1].Y;
				array[2].Y = height - array[2].Y;
				array[3].Y = height - array[3].Y;
				double num = Math.Min(Math.Min(array[0].X, array[1].X), Math.Min(array[2].X, array[3].X));
				double num2 = Math.Max(Math.Max(array[0].X, array[1].X), Math.Max(array[2].X, array[3].X));
				double num3 = Math.Min(Math.Min(array[0].Y, array[1].Y), Math.Min(array[2].Y, array[3].Y));
				double num4 = Math.Max(Math.Max(array[0].Y, array[1].Y), Math.Max(array[2].Y, array[3].Y));
				return new XRect(num, num3, num2 - num, num4 - num3);
			}

			// Token: 0x04000274 RID: 628
			private readonly XGraphics _gfx;
		}
	}
}
