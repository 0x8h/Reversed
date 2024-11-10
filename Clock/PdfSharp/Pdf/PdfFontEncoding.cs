using System;

namespace PdfSharp.Pdf
{
	// Token: 0x02000189 RID: 393
	public enum PdfFontEncoding
	{
		// Token: 0x04000814 RID: 2068
		WinAnsi,
		// Token: 0x04000815 RID: 2069
		Unicode,
		// Token: 0x04000816 RID: 2070
		[Obsolete("Use WinAnsi or Unicode")]
		Automatic = 1
	}
}
