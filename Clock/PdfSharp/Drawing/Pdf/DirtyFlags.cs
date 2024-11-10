using System;

namespace PdfSharp.Drawing.Pdf
{
	// Token: 0x0200001A RID: 26
	[Flags]
	internal enum DirtyFlags
	{
		// Token: 0x0400007A RID: 122
		Ctm = 1,
		// Token: 0x0400007B RID: 123
		ClipPath = 2,
		// Token: 0x0400007C RID: 124
		LineWidth = 16,
		// Token: 0x0400007D RID: 125
		LineJoin = 32,
		// Token: 0x0400007E RID: 126
		MiterLimit = 64,
		// Token: 0x0400007F RID: 127
		StrokeFill = 112
	}
}
