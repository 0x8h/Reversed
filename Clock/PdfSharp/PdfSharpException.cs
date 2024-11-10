using System;

namespace PdfSharp
{
	// Token: 0x02000153 RID: 339
	public class PdfSharpException : Exception
	{
		// Token: 0x06000B59 RID: 2905 RVA: 0x0002CC00 File Offset: 0x0002AE00
		public PdfSharpException()
		{
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x0002CC08 File Offset: 0x0002AE08
		public PdfSharpException(string message)
			: base(message)
		{
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x0002CC11 File Offset: 0x0002AE11
		public PdfSharpException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
