using System;

namespace PdfSharp.Pdf.Content
{
	// Token: 0x02000154 RID: 340
	public class ContentReaderException : PdfSharpException
	{
		// Token: 0x06000B5C RID: 2908 RVA: 0x0002CC1B File Offset: 0x0002AE1B
		public ContentReaderException()
		{
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x0002CC23 File Offset: 0x0002AE23
		public ContentReaderException(string message)
			: base(message)
		{
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x0002CC2C File Offset: 0x0002AE2C
		public ContentReaderException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
