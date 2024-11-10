using System;

namespace PdfSharp.Pdf.IO
{
	// Token: 0x02000175 RID: 373
	public class PdfReaderException : PdfSharpException
	{
		// Token: 0x06000C3A RID: 3130 RVA: 0x00032181 File Offset: 0x00030381
		public PdfReaderException()
		{
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x00032189 File Offset: 0x00030389
		public PdfReaderException(string message)
			: base(message)
		{
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x00032192 File Offset: 0x00030392
		public PdfReaderException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
