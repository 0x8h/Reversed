using System;
using System.Collections.Generic;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000112 RID: 274
	internal sealed class PdfImageTable : PdfResourceTable
	{
		// Token: 0x060009F1 RID: 2545 RVA: 0x00028245 File Offset: 0x00026445
		public PdfImageTable(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x0002825C File Offset: 0x0002645C
		public PdfImage GetImage(XImage image)
		{
			PdfImageTable.ImageSelector imageSelector = image._selector;
			if (imageSelector == null)
			{
				imageSelector = new PdfImageTable.ImageSelector(image);
				image._selector = imageSelector;
			}
			PdfImage pdfImage;
			if (!this._images.TryGetValue(imageSelector, out pdfImage))
			{
				pdfImage = new PdfImage(base.Owner, image);
				this._images[imageSelector] = pdfImage;
			}
			return pdfImage;
		}

		// Token: 0x0400057C RID: 1404
		private readonly Dictionary<PdfImageTable.ImageSelector, PdfImage> _images = new Dictionary<PdfImageTable.ImageSelector, PdfImage>();

		// Token: 0x02000113 RID: 275
		public class ImageSelector
		{
			// Token: 0x060009F3 RID: 2547 RVA: 0x000282AC File Offset: 0x000264AC
			public ImageSelector(XImage image)
			{
				if (image._path == null)
				{
					image._path = "*" + Guid.NewGuid().ToString("B");
				}
				this._path = image._path.ToLowerInvariant();
			}

			// Token: 0x170003AF RID: 943
			// (get) Token: 0x060009F4 RID: 2548 RVA: 0x000282FA File Offset: 0x000264FA
			// (set) Token: 0x060009F5 RID: 2549 RVA: 0x00028302 File Offset: 0x00026502
			public string Path
			{
				get
				{
					return this._path;
				}
				set
				{
					this._path = value;
				}
			}

			// Token: 0x060009F6 RID: 2550 RVA: 0x0002830C File Offset: 0x0002650C
			public override bool Equals(object obj)
			{
				PdfImageTable.ImageSelector imageSelector = obj as PdfImageTable.ImageSelector;
				return imageSelector != null && this._path == imageSelector._path;
			}

			// Token: 0x060009F7 RID: 2551 RVA: 0x00028336 File Offset: 0x00026536
			public override int GetHashCode()
			{
				return this._path.GetHashCode();
			}

			// Token: 0x0400057D RID: 1405
			private string _path;
		}
	}
}
