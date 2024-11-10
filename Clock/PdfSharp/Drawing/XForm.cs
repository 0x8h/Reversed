using System;
using PdfSharp.Drawing.Pdf;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Drawing
{
	// Token: 0x02000062 RID: 98
	public class XForm : XImage, IContentStream
	{
		// Token: 0x06000374 RID: 884 RVA: 0x0000FD44 File Offset: 0x0000DF44
		protected XForm()
		{
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000FD4C File Offset: 0x0000DF4C
		public XForm(PdfDocument document, XRect viewBox)
		{
			if (viewBox.Width < 1.0 || viewBox.Height < 1.0)
			{
				throw new ArgumentNullException("viewBox", "The size of the XPdfForm is to small.");
			}
			if (document == null)
			{
				throw new ArgumentNullException("document", "An XPdfForm template must be associated with a document at creation time.");
			}
			this._formState = XForm.FormState.Created;
			this._document = document;
			this._pdfForm = new PdfFormXObject(document, this);
			this._viewBox = viewBox;
			PdfRectangle pdfRectangle = new PdfRectangle(viewBox);
			this._pdfForm.Elements.SetRectangle("/BBox", pdfRectangle);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000FDE5 File Offset: 0x0000DFE5
		public XForm(PdfDocument document, XSize size)
			: this(document, new XRect(0.0, 0.0, size.Width, size.Height))
		{
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000FE13 File Offset: 0x0000E013
		public XForm(PdfDocument document, XUnit width, XUnit height)
			: this(document, new XRect(0.0, 0.0, width, height))
		{
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000FE41 File Offset: 0x0000E041
		public void DrawingFinished()
		{
			if (this._formState == XForm.FormState.Finished)
			{
				return;
			}
			if (this._formState == XForm.FormState.NotATemplate)
			{
				throw new InvalidOperationException("This object is an imported PDF page and you cannot finish drawing on it because you must not draw on it at all.");
			}
			this.Finish();
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0000FE68 File Offset: 0x0000E068
		internal void AssociateGraphics(XGraphics gfx)
		{
			if (this._formState == XForm.FormState.NotATemplate)
			{
				throw new NotImplementedException("The current version of PDFsharp cannot draw on an imported page.");
			}
			if (this._formState == XForm.FormState.UnderConstruction)
			{
				throw new InvalidOperationException("An XGraphics object already exists for this form.");
			}
			if (this._formState == XForm.FormState.Finished)
			{
				throw new InvalidOperationException("After drawing a form it cannot be modified anymore.");
			}
			this._formState = XForm.FormState.UnderConstruction;
			this.Gfx = gfx;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000FEBE File Offset: 0x0000E0BE
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000FEC7 File Offset: 0x0000E0C7
		internal virtual void Finish()
		{
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x0600037C RID: 892 RVA: 0x0000FEC9 File Offset: 0x0000E0C9
		internal PdfDocument Owner
		{
			get
			{
				return this._document;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600037D RID: 893 RVA: 0x0000FED1 File Offset: 0x0000E0D1
		internal PdfColorMode ColorMode
		{
			get
			{
				if (this._document == null)
				{
					return PdfColorMode.Undefined;
				}
				return this._document.Options.ColorMode;
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x0600037E RID: 894 RVA: 0x0000FEED File Offset: 0x0000E0ED
		internal bool IsTemplate
		{
			get
			{
				return this._formState != XForm.FormState.NotATemplate;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600037F RID: 895 RVA: 0x0000FEFB File Offset: 0x0000E0FB
		[Obsolete("Use either PixelWidth or PointWidth. Temporarily obsolete because of rearrangements for WPF. Currently same as PixelWidth, but will become PointWidth in future releases of PDFsharp.")]
		public override double Width
		{
			get
			{
				return this._viewBox.Width;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000380 RID: 896 RVA: 0x0000FF08 File Offset: 0x0000E108
		[Obsolete("Use either PixelHeight or PointHeight. Temporarily obsolete because of rearrangements for WPF. Currently same as PixelHeight, but will become PointHeight in future releases of PDFsharp.")]
		public override double Height
		{
			get
			{
				return this._viewBox.Height;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000381 RID: 897 RVA: 0x0000FF15 File Offset: 0x0000E115
		public override double PointWidth
		{
			get
			{
				return this._viewBox.Width;
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000382 RID: 898 RVA: 0x0000FF22 File Offset: 0x0000E122
		public override double PointHeight
		{
			get
			{
				return this._viewBox.Height;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000383 RID: 899 RVA: 0x0000FF2F File Offset: 0x0000E12F
		public override int PixelWidth
		{
			get
			{
				return (int)this._viewBox.Width;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000384 RID: 900 RVA: 0x0000FF3D File Offset: 0x0000E13D
		public override int PixelHeight
		{
			get
			{
				return (int)this._viewBox.Height;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000385 RID: 901 RVA: 0x0000FF4B File Offset: 0x0000E14B
		public override XSize Size
		{
			get
			{
				return this._viewBox.Size;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000386 RID: 902 RVA: 0x0000FF58 File Offset: 0x0000E158
		public XRect ViewBox
		{
			get
			{
				return this._viewBox;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000387 RID: 903 RVA: 0x0000FF60 File Offset: 0x0000E160
		public override double HorizontalResolution
		{
			get
			{
				return 72.0;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000388 RID: 904 RVA: 0x0000FF6B File Offset: 0x0000E16B
		public override double VerticalResolution
		{
			get
			{
				return 72.0;
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000389 RID: 905 RVA: 0x0000FF76 File Offset: 0x0000E176
		// (set) Token: 0x0600038A RID: 906 RVA: 0x0000FF7E File Offset: 0x0000E17E
		public XRect BoundingBox
		{
			get
			{
				return this._boundingBox;
			}
			set
			{
				this._boundingBox = value;
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x0600038B RID: 907 RVA: 0x0000FF87 File Offset: 0x0000E187
		// (set) Token: 0x0600038C RID: 908 RVA: 0x0000FF8F File Offset: 0x0000E18F
		public virtual XMatrix Transform
		{
			get
			{
				return this._transform;
			}
			set
			{
				if (this._formState == XForm.FormState.Finished)
				{
					throw new InvalidOperationException("After a XPdfForm was once drawn it must not be modified.");
				}
				this._transform = value;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x0600038D RID: 909 RVA: 0x0000FFAC File Offset: 0x0000E1AC
		internal PdfResources Resources
		{
			get
			{
				return this.PdfForm.Resources;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x0600038E RID: 910 RVA: 0x0000FFB9 File Offset: 0x0000E1B9
		PdfResources IContentStream.Resources
		{
			get
			{
				return this.Resources;
			}
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000FFC4 File Offset: 0x0000E1C4
		internal string GetFontName(XFont font, out PdfFont pdfFont)
		{
			pdfFont = this._document.FontTable.GetFont(font);
			return this.Resources.AddFont(pdfFont);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0000FFF3 File Offset: 0x0000E1F3
		string IContentStream.GetFontName(XFont font, out PdfFont pdfFont)
		{
			return this.GetFontName(font, out pdfFont);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00010000 File Offset: 0x0000E200
		internal string TryGetFontName(string idName, out PdfFont pdfFont)
		{
			pdfFont = this._document.FontTable.TryGetFont(idName);
			string text = null;
			if (pdfFont != null)
			{
				text = this.Resources.AddFont(pdfFont);
			}
			return text;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00010038 File Offset: 0x0000E238
		internal string GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
		{
			pdfFont = this._document.FontTable.GetFont(idName, fontData);
			return this.Resources.AddFont(pdfFont);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00010068 File Offset: 0x0000E268
		string IContentStream.GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
		{
			return this.GetFontName(idName, fontData, out pdfFont);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00010074 File Offset: 0x0000E274
		internal string GetImageName(XImage image)
		{
			PdfImage image2 = this._document.ImageTable.GetImage(image);
			return this.Resources.AddImage(image2);
		}

		// Token: 0x06000395 RID: 917 RVA: 0x000100A1 File Offset: 0x0000E2A1
		string IContentStream.GetImageName(XImage image)
		{
			return this.GetImageName(image);
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000396 RID: 918 RVA: 0x000100AA File Offset: 0x0000E2AA
		internal PdfFormXObject PdfForm
		{
			get
			{
				if (this._pdfForm.Reference == null)
				{
					this._document._irefTable.Add(this._pdfForm);
				}
				return this._pdfForm;
			}
		}

		// Token: 0x06000397 RID: 919 RVA: 0x000100D8 File Offset: 0x0000E2D8
		internal string GetFormName(XForm form)
		{
			PdfFormXObject form2 = this._document.FormTable.GetForm(form);
			return this.Resources.AddForm(form2);
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00010105 File Offset: 0x0000E305
		string IContentStream.GetFormName(XForm form)
		{
			return this.GetFormName(form);
		}

		// Token: 0x0400023D RID: 573
		internal XGraphics Gfx;

		// Token: 0x0400023E RID: 574
		private PdfDocument _document;

		// Token: 0x0400023F RID: 575
		internal XForm.FormState _formState;

		// Token: 0x04000240 RID: 576
		private XRect _viewBox;

		// Token: 0x04000241 RID: 577
		private XRect _boundingBox;

		// Token: 0x04000242 RID: 578
		internal XMatrix _transform;

		// Token: 0x04000243 RID: 579
		internal PdfFormXObject _pdfForm;

		// Token: 0x04000244 RID: 580
		internal XGraphicsPdfRenderer PdfRenderer;

		// Token: 0x02000063 RID: 99
		internal enum FormState
		{
			// Token: 0x04000246 RID: 582
			NotATemplate,
			// Token: 0x04000247 RID: 583
			Created,
			// Token: 0x04000248 RID: 584
			UnderConstruction,
			// Token: 0x04000249 RID: 585
			Finished
		}
	}
}
