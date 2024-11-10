using System;

namespace PdfSharp.Drawing
{
	// Token: 0x02000034 RID: 52
	[Flags]
	public enum XSmoothingMode
	{
		// Token: 0x040001A4 RID: 420
		Invalid = -1,
		// Token: 0x040001A5 RID: 421
		Default = 0,
		// Token: 0x040001A6 RID: 422
		HighSpeed = 1,
		// Token: 0x040001A7 RID: 423
		HighQuality = 2,
		// Token: 0x040001A8 RID: 424
		None = 3,
		// Token: 0x040001A9 RID: 425
		AntiAlias = 4
	}
}
