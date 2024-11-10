using System;

namespace PdfSharp.Drawing
{
	// Token: 0x02000066 RID: 102
	[Flags]
	internal enum InternalGraphicsMode
	{
		// Token: 0x0400025D RID: 605
		DrawingGdiGraphics = 0,
		// Token: 0x0400025E RID: 606
		DrawingPdfContent = 1,
		// Token: 0x0400025F RID: 607
		DrawingBitmap = 2
	}
}
