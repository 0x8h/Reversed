using System;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000061 RID: 97
	internal interface IContentStream
	{
		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x0600036F RID: 879
		PdfResources Resources { get; }

		// Token: 0x06000370 RID: 880
		string GetFontName(XFont font, out PdfFont pdfFont);

		// Token: 0x06000371 RID: 881
		string GetFontName(string idName, byte[] fontData, out PdfFont pdfFont);

		// Token: 0x06000372 RID: 882
		string GetImageName(XImage image);

		// Token: 0x06000373 RID: 883
		string GetFormName(XForm form);
	}
}
