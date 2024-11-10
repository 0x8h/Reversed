using System;
using System.Collections.Generic;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000104 RID: 260
	internal sealed class PdfFontTable : PdfResourceTable
	{
		// Token: 0x060009A0 RID: 2464 RVA: 0x00023F25 File Offset: 0x00022125
		public PdfFontTable(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x00023F3C File Offset: 0x0002213C
		public PdfFont GetFont(XFont font)
		{
			string text = font.Selector;
			if (text == null)
			{
				text = PdfFontTable.ComputeKey(font);
				font.Selector = text;
			}
			PdfFont pdfFont;
			if (!this._fonts.TryGetValue(text, out pdfFont))
			{
				if (font.Unicode)
				{
					pdfFont = new PdfType0Font(base.Owner, font, font.IsVertical);
				}
				else
				{
					pdfFont = new PdfTrueTypeFont(base.Owner, font);
				}
				this._fonts[text] = pdfFont;
			}
			return pdfFont;
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00023FAC File Offset: 0x000221AC
		public PdfFont GetFont(string idName, byte[] fontData)
		{
			string text = null;
			PdfFont pdfFont;
			if (!this._fonts.TryGetValue(text, out pdfFont))
			{
				pdfFont = new PdfType0Font(base.Owner, idName, fontData, false);
				this._fonts[text] = pdfFont;
			}
			return pdfFont;
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x00023FE8 File Offset: 0x000221E8
		public PdfFont TryGetFont(string idName)
		{
			string text = null;
			PdfFont pdfFont;
			this._fonts.TryGetValue(text, out pdfFont);
			return pdfFont;
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x00024008 File Offset: 0x00022208
		internal static string ComputeKey(XFont font)
		{
			XGlyphTypeface glyphTypeface = font.GlyphTypeface;
			return string.Concat(new object[]
			{
				glyphTypeface.Fontface.FullFaceName.ToLowerInvariant(),
				glyphTypeface.IsBold ? "/b" : "",
				glyphTypeface.IsItalic ? "/i" : "",
				font.Unicode
			});
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0002407C File Offset: 0x0002227C
		public void PrepareForSave()
		{
			foreach (PdfFont pdfFont in this._fonts.Values)
			{
				pdfFont.PrepareForSave();
			}
		}

		// Token: 0x0400053C RID: 1340
		private readonly Dictionary<string, PdfFont> _fonts = new Dictionary<string, PdfFont>();
	}
}
