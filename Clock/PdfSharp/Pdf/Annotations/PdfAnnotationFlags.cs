using System;

namespace PdfSharp.Pdf.Annotations
{
	// Token: 0x0200012F RID: 303
	public enum PdfAnnotationFlags
	{
		// Token: 0x040005E3 RID: 1507
		Invisible = 1,
		// Token: 0x040005E4 RID: 1508
		Hidden,
		// Token: 0x040005E5 RID: 1509
		Print = 4,
		// Token: 0x040005E6 RID: 1510
		NoZoom = 8,
		// Token: 0x040005E7 RID: 1511
		NoRotate = 16,
		// Token: 0x040005E8 RID: 1512
		NoView = 32,
		// Token: 0x040005E9 RID: 1513
		ReadOnly = 64,
		// Token: 0x040005EA RID: 1514
		Locked = 128,
		// Token: 0x040005EB RID: 1515
		ToggleNoView = 256
	}
}
