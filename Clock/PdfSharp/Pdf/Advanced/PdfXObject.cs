using System;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000105 RID: 261
	public abstract class PdfXObject : PdfDictionary
	{
		// Token: 0x060009A6 RID: 2470 RVA: 0x000240D4 File Offset: 0x000222D4
		protected PdfXObject(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x02000106 RID: 262
		public class Keys : PdfDictionary.PdfStream.Keys
		{
		}
	}
}
