using System;

namespace PdfSharp.Pdf
{
	// Token: 0x020001B7 RID: 439
	[Flags]
	public enum PdfStringEncoding
	{
		// Token: 0x040008E4 RID: 2276
		RawEncoding = 0,
		// Token: 0x040008E5 RID: 2277
		StandardEncoding = 1,
		// Token: 0x040008E6 RID: 2278
		PDFDocEncoding = 2,
		// Token: 0x040008E7 RID: 2279
		WinAnsiEncoding = 3,
		// Token: 0x040008E8 RID: 2280
		MacRomanEncoding = 5,
		// Token: 0x040008E9 RID: 2281
		MacExpertEncoding = 5,
		// Token: 0x040008EA RID: 2282
		Unicode = 6
	}
}
