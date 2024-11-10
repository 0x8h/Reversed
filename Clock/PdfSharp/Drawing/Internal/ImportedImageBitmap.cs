using System;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal
{
	// Token: 0x02000045 RID: 69
	internal class ImportedImageBitmap : ImportedImage
	{
		// Token: 0x0600015A RID: 346 RVA: 0x0000A9AB File Offset: 0x00008BAB
		public ImportedImageBitmap(IImageImporter importer, ImagePrivateDataBitmap data, PdfDocument document)
			: base(importer, data, document)
		{
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000A9B8 File Offset: 0x00008BB8
		internal override ImageData PrepareImageData()
		{
			ImagePrivateDataBitmap imagePrivateDataBitmap = (ImagePrivateDataBitmap)this.Data;
			ImageDataBitmap imageDataBitmap = new ImageDataBitmap(this._document);
			imagePrivateDataBitmap.CopyBitmap(imageDataBitmap);
			return imageDataBitmap;
		}
	}
}
