using System;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing
{
	// Token: 0x0200004D RID: 77
	public class XPdfFontOptions
	{
		// Token: 0x0600018E RID: 398 RVA: 0x0000B5D8 File Offset: 0x000097D8
		internal XPdfFontOptions()
		{
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000B5E0 File Offset: 0x000097E0
		[Obsolete("Must not specify an embedding option anymore.")]
		public XPdfFontOptions(PdfFontEncoding encoding, PdfFontEmbedding embedding)
		{
			this._fontEncoding = encoding;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000B5EF File Offset: 0x000097EF
		public XPdfFontOptions(PdfFontEncoding encoding)
		{
			this._fontEncoding = encoding;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000B5FE File Offset: 0x000097FE
		[Obsolete("Must not specify an embedding option anymore.")]
		public XPdfFontOptions(PdfFontEmbedding embedding)
		{
			this._fontEncoding = PdfFontEncoding.WinAnsi;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000192 RID: 402 RVA: 0x0000B60D File Offset: 0x0000980D
		public PdfFontEmbedding FontEmbedding
		{
			get
			{
				return PdfFontEmbedding.Always;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000193 RID: 403 RVA: 0x0000B610 File Offset: 0x00009810
		public PdfFontEncoding FontEncoding
		{
			get
			{
				return this._fontEncoding;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000194 RID: 404 RVA: 0x0000B618 File Offset: 0x00009818
		public static XPdfFontOptions WinAnsiDefault
		{
			get
			{
				return new XPdfFontOptions(PdfFontEncoding.WinAnsi);
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000195 RID: 405 RVA: 0x0000B620 File Offset: 0x00009820
		public static XPdfFontOptions UnicodeDefault
		{
			get
			{
				return new XPdfFontOptions(PdfFontEncoding.Unicode);
			}
		}

		// Token: 0x040001EE RID: 494
		private readonly PdfFontEncoding _fontEncoding;
	}
}
