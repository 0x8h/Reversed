using System;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000100 RID: 256
	[Flags]
	internal enum PdfFontDescriptorFlags
	{
		// Token: 0x04000517 RID: 1303
		FixedPitch = 1,
		// Token: 0x04000518 RID: 1304
		Serif = 2,
		// Token: 0x04000519 RID: 1305
		Symbolic = 4,
		// Token: 0x0400051A RID: 1306
		Script = 8,
		// Token: 0x0400051B RID: 1307
		Nonsymbolic = 32,
		// Token: 0x0400051C RID: 1308
		Italic = 64,
		// Token: 0x0400051D RID: 1309
		AllCap = 65536,
		// Token: 0x0400051E RID: 1310
		SmallCap = 131072,
		// Token: 0x0400051F RID: 1311
		ForceBold = 262144
	}
}
