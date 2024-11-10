using System;

namespace PdfSharp.Pdf
{
	// Token: 0x020001A0 RID: 416
	public abstract class PdfNumberObject : PdfObject
	{
		// Token: 0x06000D6F RID: 3439 RVA: 0x00035460 File Offset: 0x00033660
		protected PdfNumberObject()
		{
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x00035468 File Offset: 0x00033668
		protected PdfNumberObject(PdfDocument document)
			: base(document)
		{
		}
	}
}
