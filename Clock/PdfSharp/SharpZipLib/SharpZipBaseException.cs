using System;

namespace PdfSharp.SharpZipLib
{
	// Token: 0x020001CB RID: 459
	[Serializable]
	internal class SharpZipBaseException : ApplicationException
	{
		// Token: 0x06000F1D RID: 3869 RVA: 0x0003AAE4 File Offset: 0x00038CE4
		public SharpZipBaseException()
		{
		}

		// Token: 0x06000F1E RID: 3870 RVA: 0x0003AAEC File Offset: 0x00038CEC
		public SharpZipBaseException(string message)
			: base(message)
		{
		}

		// Token: 0x06000F1F RID: 3871 RVA: 0x0003AAF5 File Offset: 0x00038CF5
		public SharpZipBaseException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
