using System;

namespace PdfSharp.SharpZipLib.Zip
{
	// Token: 0x020001DD RID: 477
	public enum CompressionMethod
	{
		// Token: 0x04000A3B RID: 2619
		Stored,
		// Token: 0x04000A3C RID: 2620
		Deflated = 8,
		// Token: 0x04000A3D RID: 2621
		Deflate64,
		// Token: 0x04000A3E RID: 2622
		BZip2 = 11,
		// Token: 0x04000A3F RID: 2623
		WinZipAES = 99
	}
}
