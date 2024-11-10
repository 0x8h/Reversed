using System;

namespace PdfSharp.SharpZipLib.Zip
{
	// Token: 0x020001E1 RID: 481
	internal class ZipException : SharpZipBaseException
	{
		// Token: 0x06000FF7 RID: 4087 RVA: 0x0003F635 File Offset: 0x0003D835
		public ZipException()
		{
		}

		// Token: 0x06000FF8 RID: 4088 RVA: 0x0003F63D File Offset: 0x0003D83D
		public ZipException(string message)
			: base(message)
		{
		}

		// Token: 0x06000FF9 RID: 4089 RVA: 0x0003F646 File Offset: 0x0003D846
		public ZipException(string message, Exception exception)
			: base(message, exception)
		{
		}
	}
}
