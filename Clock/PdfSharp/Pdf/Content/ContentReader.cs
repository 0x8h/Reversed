using System;
using System.IO;
using PdfSharp.Pdf.Content.Objects;

namespace PdfSharp.Pdf.Content
{
	// Token: 0x02000152 RID: 338
	public static class ContentReader
	{
		// Token: 0x06000B56 RID: 2902 RVA: 0x0002CBAC File Offset: 0x0002ADAC
		public static CSequence ReadContent(PdfPage page)
		{
			CParser cparser = new CParser(page);
			return cparser.ReadContent();
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x0002CBC8 File Offset: 0x0002ADC8
		public static CSequence ReadContent(byte[] content)
		{
			CParser cparser = new CParser(content);
			return cparser.ReadContent();
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x0002CBE4 File Offset: 0x0002ADE4
		public static CSequence ReadContent(MemoryStream content)
		{
			CParser cparser = new CParser(content);
			return cparser.ReadContent();
		}
	}
}
