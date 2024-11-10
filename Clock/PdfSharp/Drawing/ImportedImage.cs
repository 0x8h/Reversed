using System;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing
{
	// Token: 0x0200003E RID: 62
	internal abstract class ImportedImage
	{
		// Token: 0x06000148 RID: 328 RVA: 0x0000A669 File Offset: 0x00008869
		protected ImportedImage(IImageImporter importer, ImagePrivateData data, PdfDocument document)
		{
			this.Data = data;
			this._document = document;
			data.Image = this;
			this._importer = importer;
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000149 RID: 329 RVA: 0x0000A698 File Offset: 0x00008898
		// (set) Token: 0x0600014A RID: 330 RVA: 0x0000A6A0 File Offset: 0x000088A0
		public ImageInformation Information
		{
			get
			{
				return this._information;
			}
			private set
			{
				this._information = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600014B RID: 331 RVA: 0x0000A6A9 File Offset: 0x000088A9
		public bool HasImageData
		{
			get
			{
				return this._imageData != null;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600014C RID: 332 RVA: 0x0000A6B7 File Offset: 0x000088B7
		// (set) Token: 0x0600014D RID: 333 RVA: 0x0000A6D3 File Offset: 0x000088D3
		public ImageData ImageData
		{
			get
			{
				if (!this.HasImageData)
				{
					this._imageData = this.PrepareImageData();
				}
				return this._imageData;
			}
			private set
			{
				this._imageData = value;
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000A6DC File Offset: 0x000088DC
		internal virtual ImageData PrepareImageData()
		{
			throw new NotImplementedException();
		}

		// Token: 0x040001BB RID: 443
		private ImageInformation _information = new ImageInformation();

		// Token: 0x040001BC RID: 444
		private ImageData _imageData;

		// Token: 0x040001BD RID: 445
		private IImageImporter _importer;

		// Token: 0x040001BE RID: 446
		internal ImagePrivateData Data;

		// Token: 0x040001BF RID: 447
		internal readonly PdfDocument _document;
	}
}
