using System;
using System.Collections.Generic;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x0200011C RID: 284
	internal class PdfResourceMap : PdfDictionary
	{
		// Token: 0x06000A3C RID: 2620 RVA: 0x00028B52 File Offset: 0x00026D52
		public PdfResourceMap()
		{
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x00028B5A File Offset: 0x00026D5A
		public PdfResourceMap(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00028B63 File Offset: 0x00026D63
		protected PdfResourceMap(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x00028B6C File Offset: 0x00026D6C
		internal void CollectResourceNames(Dictionary<string, object> usedResourceNames)
		{
			PdfName[] keyNames = base.Elements.KeyNames;
			foreach (PdfName pdfName in keyNames)
			{
				usedResourceNames.Add(pdfName.ToString(), null);
			}
		}
	}
}
