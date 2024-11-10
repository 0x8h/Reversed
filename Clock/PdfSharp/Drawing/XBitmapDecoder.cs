using System;

namespace PdfSharp.Drawing
{
	// Token: 0x0200004E RID: 78
	public class XBitmapDecoder
	{
		// Token: 0x06000196 RID: 406 RVA: 0x0000B628 File Offset: 0x00009828
		internal XBitmapDecoder()
		{
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000B630 File Offset: 0x00009830
		public static XBitmapDecoder GetPngDecoder()
		{
			return new XPngBitmapDecoder();
		}
	}
}
