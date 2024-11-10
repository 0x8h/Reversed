using System;

namespace PdfSharp.Pdf
{
	// Token: 0x02000188 RID: 392
	public enum PdfFontEmbedding
	{
		// Token: 0x0400080F RID: 2063
		Always,
		// Token: 0x04000810 RID: 2064
		[Obsolete("Fonts must always be embedded.")]
		None,
		// Token: 0x04000811 RID: 2065
		[Obsolete("Fonts must always be embedded.")]
		Default,
		// Token: 0x04000812 RID: 2066
		[Obsolete("Fonts must always be embedded.")]
		Automatic
	}
}
