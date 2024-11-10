using System;

namespace PdfSharp.Pdf
{
	// Token: 0x02000183 RID: 387
	[Flags]
	internal enum DocumentState
	{
		// Token: 0x040007FB RID: 2043
		Created = 1,
		// Token: 0x040007FC RID: 2044
		Imported = 2,
		// Token: 0x040007FD RID: 2045
		Disposed = 32768
	}
}
