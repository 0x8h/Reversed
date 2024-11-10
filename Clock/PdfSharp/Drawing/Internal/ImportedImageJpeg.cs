using System;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal
{
	// Token: 0x02000049 RID: 73
	internal class ImportedImageJpeg : ImportedImage
	{
		// Token: 0x06000180 RID: 384 RVA: 0x0000B45A File Offset: 0x0000965A
		public ImportedImageJpeg(IImageImporter importer, ImagePrivateDataDct data, PdfDocument document)
			: base(importer, data, document)
		{
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000B468 File Offset: 0x00009668
		internal override ImageData PrepareImageData()
		{
			ImagePrivateDataDct imagePrivateDataDct = (ImagePrivateDataDct)this.Data;
			return new ImageDataDct
			{
				Data = imagePrivateDataDct.Data,
				Length = imagePrivateDataDct.Length
			};
		}
	}
}
