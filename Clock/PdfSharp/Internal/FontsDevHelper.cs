using System;
using PdfSharp.Drawing;
using PdfSharp.Fonts;

namespace PdfSharp.Internal
{
	// Token: 0x020000B8 RID: 184
	public static class FontsDevHelper
	{
		// Token: 0x060007B5 RID: 1973 RVA: 0x0001D822 File Offset: 0x0001BA22
		public static XFont CreateSpecialFont(string familyName, double emSize, XFontStyle style, XPdfFontOptions pdfOptions, XStyleSimulations styleSimulations)
		{
			return new XFont(familyName, emSize, style, pdfOptions, styleSimulations);
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x0001D82F File Offset: 0x0001BA2F
		public static string GetFontCachesState()
		{
			return FontFactory.GetFontCachesState();
		}
	}
}
