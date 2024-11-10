using System;

namespace PdfSharp.Pdf
{
	// Token: 0x020001B8 RID: 440
	[Flags]
	internal enum PdfStringFlags
	{
		// Token: 0x040008EC RID: 2284
		RawEncoding = 0,
		// Token: 0x040008ED RID: 2285
		StandardEncoding = 1,
		// Token: 0x040008EE RID: 2286
		PDFDocEncoding = 2,
		// Token: 0x040008EF RID: 2287
		WinAnsiEncoding = 3,
		// Token: 0x040008F0 RID: 2288
		MacRomanEncoding = 4,
		// Token: 0x040008F1 RID: 2289
		MacExpertEncoding = 5,
		// Token: 0x040008F2 RID: 2290
		Unicode = 6,
		// Token: 0x040008F3 RID: 2291
		EncodingMask = 15,
		// Token: 0x040008F4 RID: 2292
		HexLiteral = 128
	}
}
