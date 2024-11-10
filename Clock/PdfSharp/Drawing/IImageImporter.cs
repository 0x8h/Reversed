using System;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing
{
	// Token: 0x0200003C RID: 60
	internal interface IImageImporter
	{
		// Token: 0x0600013B RID: 315
		ImportedImage ImportImage(StreamReaderHelper stream, PdfDocument document);

		// Token: 0x0600013C RID: 316
		ImageData PrepareImage(ImagePrivateData data);
	}
}
