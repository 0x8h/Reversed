using System;
using System.IO;
using PdfSharp.Internal;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Drawing
{
	// Token: 0x02000075 RID: 117
	public class XPdfForm : XForm
	{
		// Token: 0x060004F0 RID: 1264 RVA: 0x00015620 File Offset: 0x00013820
		internal XPdfForm(string path)
		{
			int num;
			path = XPdfForm.ExtractPageNumber(path, out num);
			path = Path.GetFullPath(path);
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(PSSR.FileNotFound(path));
			}
			if (PdfReader.TestPdfFile(path) == 0)
			{
				throw new ArgumentException("The specified file has no valid PDF file header.", "path");
			}
			this._path = path;
			if (num != 0)
			{
				this.PageNumber = num;
			}
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00015690 File Offset: 0x00013890
		internal XPdfForm(Stream stream)
		{
			this._path = "*" + Guid.NewGuid().ToString("B");
			if (PdfReader.TestPdfFile(stream) == 0)
			{
				throw new ArgumentException("The specified stream has no valid PDF file header.", "stream");
			}
			this._externalDocument = PdfReader.Open(stream);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x000156F7 File Offset: 0x000138F7
		public new static XPdfForm FromFile(string path)
		{
			return new XPdfForm(path);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x000156FF File Offset: 0x000138FF
		public new static XPdfForm FromStream(Stream stream)
		{
			return new XPdfForm(stream);
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00015707 File Offset: 0x00013907
		internal override void Finish()
		{
			if (this._formState == XForm.FormState.NotATemplate || this._formState == XForm.FormState.Finished)
			{
				return;
			}
			base.Finish();
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00015724 File Offset: 0x00013924
		protected override void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				this._disposed = true;
				try
				{
					if (this._externalDocument != null)
					{
						PdfDocument.Tls.DetachDocument(this._externalDocument.Handle);
					}
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x0001577C File Offset: 0x0001397C
		// (set) Token: 0x060004F7 RID: 1271 RVA: 0x00015784 File Offset: 0x00013984
		public XImage PlaceHolder
		{
			get
			{
				return this._placeHolder;
			}
			set
			{
				this._placeHolder = value;
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x00015790 File Offset: 0x00013990
		public PdfPage Page
		{
			get
			{
				if (base.IsTemplate)
				{
					return null;
				}
				return this.ExternalDocument.Pages[this._pageNumber - 1];
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x060004F9 RID: 1273 RVA: 0x000157C1 File Offset: 0x000139C1
		public int PageCount
		{
			get
			{
				if (base.IsTemplate)
				{
					return 1;
				}
				if (this._pageCount == -1)
				{
					this._pageCount = this.ExternalDocument.Pages.Count;
				}
				return this._pageCount;
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x000157F4 File Offset: 0x000139F4
		[Obsolete("Use either PixelWidth or PointWidth. Temporarily obsolete because of rearrangements for WPF.")]
		public override double Width
		{
			get
			{
				PdfPage pdfPage = this.ExternalDocument.Pages[this._pageNumber - 1];
				return pdfPage.Width;
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x00015828 File Offset: 0x00013A28
		[Obsolete("Use either PixelHeight or PointHeight. Temporarily obsolete because of rearrangements for WPF.")]
		public override double Height
		{
			get
			{
				PdfPage pdfPage = this.ExternalDocument.Pages[this._pageNumber - 1];
				return pdfPage.Height;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x0001585C File Offset: 0x00013A5C
		public override double PointWidth
		{
			get
			{
				PdfPage pdfPage = this.ExternalDocument.Pages[this._pageNumber - 1];
				return pdfPage.Width;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x00015890 File Offset: 0x00013A90
		public override double PointHeight
		{
			get
			{
				PdfPage pdfPage = this.ExternalDocument.Pages[this._pageNumber - 1];
				return pdfPage.Height;
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x000158C2 File Offset: 0x00013AC2
		public override int PixelWidth
		{
			get
			{
				return DoubleUtil.DoubleToInt(this.PointWidth);
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x000158CF File Offset: 0x00013ACF
		public override int PixelHeight
		{
			get
			{
				return DoubleUtil.DoubleToInt(this.PointHeight);
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x000158DC File Offset: 0x00013ADC
		public override XSize Size
		{
			get
			{
				PdfPage pdfPage = this.ExternalDocument.Pages[this._pageNumber - 1];
				return new XSize(pdfPage.Width, pdfPage.Height);
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x0001591F File Offset: 0x00013B1F
		// (set) Token: 0x06000502 RID: 1282 RVA: 0x00015927 File Offset: 0x00013B27
		public override XMatrix Transform
		{
			get
			{
				return this._transform;
			}
			set
			{
				if (this._transform != value)
				{
					this._pdfForm = null;
					this._transform = value;
				}
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x00015945 File Offset: 0x00013B45
		// (set) Token: 0x06000504 RID: 1284 RVA: 0x0001594D File Offset: 0x00013B4D
		public int PageNumber
		{
			get
			{
				return this._pageNumber;
			}
			set
			{
				if (base.IsTemplate)
				{
					throw new InvalidOperationException("The page number of an XPdfForm template cannot be modified.");
				}
				if (this._pageNumber != value)
				{
					this._pageNumber = value;
					this._pdfForm = null;
				}
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x00015979 File Offset: 0x00013B79
		// (set) Token: 0x06000506 RID: 1286 RVA: 0x00015983 File Offset: 0x00013B83
		public int PageIndex
		{
			get
			{
				return this.PageNumber - 1;
			}
			set
			{
				this.PageNumber = value + 1;
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x0001598E File Offset: 0x00013B8E
		internal PdfDocument ExternalDocument
		{
			get
			{
				if (base.IsTemplate)
				{
					throw new InvalidOperationException("This XPdfForm is a template and not an imported PDF page; therefore it has no external document.");
				}
				if (this._externalDocument == null)
				{
					this._externalDocument = PdfDocument.Tls.GetDocument(this._path);
				}
				return this._externalDocument;
			}
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x000159C8 File Offset: 0x00013BC8
		public static string ExtractPageNumber(string path, out int pageNumber)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			pageNumber = 0;
			int num = path.Length;
			if (num != 0)
			{
				num--;
				if (char.IsDigit(path, num))
				{
					while (char.IsDigit(path, num) && num >= 0)
					{
						num--;
					}
					if (num > 0 && path[num] == '#' && path.IndexOf('.') != -1)
					{
						pageNumber = int.Parse(path.Substring(num + 1));
						path = path.Substring(0, num);
					}
				}
			}
			return path;
		}

		// Token: 0x0400029A RID: 666
		private bool _disposed;

		// Token: 0x0400029B RID: 667
		private XImage _placeHolder;

		// Token: 0x0400029C RID: 668
		private int _pageCount = -1;

		// Token: 0x0400029D RID: 669
		private int _pageNumber = 1;

		// Token: 0x0400029E RID: 670
		internal PdfDocument _externalDocument;
	}
}
