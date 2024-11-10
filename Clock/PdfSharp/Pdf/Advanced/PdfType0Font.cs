using System;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x0200012D RID: 301
	internal sealed class PdfType0Font : PdfFont
	{
		// Token: 0x06000A84 RID: 2692 RVA: 0x00029D30 File Offset: 0x00027F30
		public PdfType0Font(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00029D3C File Offset: 0x00027F3C
		public PdfType0Font(PdfDocument document, XFont font, bool vertical)
			: base(document)
		{
			base.Elements.SetName("/Type", "/Font");
			base.Elements.SetName("/Subtype", "/Type0");
			base.Elements.SetName("/Encoding", vertical ? "/Identity-V" : "/Identity-H");
			OpenTypeDescriptor openTypeDescriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptorFor(font);
			base.FontDescriptor = new PdfFontDescriptor(document, openTypeDescriptor);
			this._fontOptions = font.PdfOptions;
			this._cmapInfo = new CMapInfo(openTypeDescriptor);
			this._descendantFont = new PdfCIDFont(document, base.FontDescriptor, font);
			this._descendantFont.CMapInfo = this._cmapInfo;
			this._toUnicode = new PdfToUnicodeMap(document, this._cmapInfo);
			document.Internals.AddObject(this._toUnicode);
			base.Elements.Add("/ToUnicode", this._toUnicode);
			this.BaseFont = font.GlyphTypeface.GetBaseName();
			this.BaseFont = PdfFont.CreateEmbeddedFontSubsetName(this.BaseFont);
			base.FontDescriptor.FontName = this.BaseFont;
			this._descendantFont.BaseFont = this.BaseFont;
			PdfArray pdfArray = new PdfArray(document);
			this.Owner._irefTable.Add(this._descendantFont);
			pdfArray.Elements.Add(this._descendantFont.Reference);
			base.Elements["/DescendantFonts"] = pdfArray;
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00029EB0 File Offset: 0x000280B0
		public PdfType0Font(PdfDocument document, string idName, byte[] fontData, bool vertical)
			: base(document)
		{
			base.Elements.SetName("/Type", "/Font");
			base.Elements.SetName("/Subtype", "/Type0");
			base.Elements.SetName("/Encoding", vertical ? "/Identity-V" : "/Identity-H");
			OpenTypeDescriptor openTypeDescriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptor(idName, fontData);
			base.FontDescriptor = new PdfFontDescriptor(document, openTypeDescriptor);
			this._fontOptions = new XPdfFontOptions(PdfFontEncoding.Unicode);
			this._cmapInfo = new CMapInfo(openTypeDescriptor);
			this._descendantFont = new PdfCIDFont(document, base.FontDescriptor, fontData);
			this._descendantFont.CMapInfo = this._cmapInfo;
			this._toUnicode = new PdfToUnicodeMap(document, this._cmapInfo);
			document.Internals.AddObject(this._toUnicode);
			base.Elements.Add("/ToUnicode", this._toUnicode);
			this.BaseFont = openTypeDescriptor.FontName;
			if (!this.BaseFont.Contains("+"))
			{
				this.BaseFont = PdfFont.CreateEmbeddedFontSubsetName(this.BaseFont);
			}
			base.FontDescriptor.FontName = this.BaseFont;
			this._descendantFont.BaseFont = this.BaseFont;
			PdfArray pdfArray = new PdfArray(document);
			this.Owner._irefTable.Add(this._descendantFont);
			pdfArray.Elements.Add(this._descendantFont.Reference);
			base.Elements["/DescendantFonts"] = pdfArray;
		}

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06000A87 RID: 2695 RVA: 0x0002A032 File Offset: 0x00028232
		private XPdfFontOptions FontOptions
		{
			get
			{
				return this._fontOptions;
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x06000A88 RID: 2696 RVA: 0x0002A03A File Offset: 0x0002823A
		// (set) Token: 0x06000A89 RID: 2697 RVA: 0x0002A04C File Offset: 0x0002824C
		public string BaseFont
		{
			get
			{
				return base.Elements.GetName("/BaseFont");
			}
			set
			{
				base.Elements.SetName("/BaseFont", value);
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x06000A8A RID: 2698 RVA: 0x0002A05F File Offset: 0x0002825F
		internal PdfCIDFont DescendantFont
		{
			get
			{
				return this._descendantFont;
			}
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x0002A068 File Offset: 0x00028268
		internal override void PrepareForSave()
		{
			base.PrepareForSave();
			OpenTypeDescriptor descriptor = base.FontDescriptor._descriptor;
			StringBuilder stringBuilder = new StringBuilder("[");
			if (this._cmapInfo != null)
			{
				int[] glyphIndices = this._cmapInfo.GetGlyphIndices();
				int num = glyphIndices.Length;
				int[] array = new int[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = descriptor.GlyphIndexToPdfWidth(glyphIndices[i]);
				}
				for (int j = 0; j < num; j++)
				{
					stringBuilder.AppendFormat("{0}[{1}]", glyphIndices[j], array[j]);
				}
				stringBuilder.Append("]");
				this._descendantFont.Elements.SetValue("/W", new PdfLiteral(stringBuilder.ToString()));
			}
			this._descendantFont.PrepareForSave();
			this._toUnicode.PrepareForSave();
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06000A8C RID: 2700 RVA: 0x0002A145 File Offset: 0x00028345
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfType0Font.Keys.Meta;
			}
		}

		// Token: 0x040005D9 RID: 1497
		private XPdfFontOptions _fontOptions;

		// Token: 0x040005DA RID: 1498
		private readonly PdfCIDFont _descendantFont;

		// Token: 0x0200012E RID: 302
		public new sealed class Keys : PdfFont.Keys
		{
			// Token: 0x170003EC RID: 1004
			// (get) Token: 0x06000A8D RID: 2701 RVA: 0x0002A14C File Offset: 0x0002834C
			internal static DictionaryMeta Meta
			{
				get
				{
					if (PdfType0Font.Keys._meta == null)
					{
						PdfType0Font.Keys._meta = KeysBase.CreateMeta(typeof(PdfType0Font.Keys));
					}
					return PdfType0Font.Keys._meta;
				}
			}

			// Token: 0x040005DB RID: 1499
			[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Font")]
			public new const string Type = "/Type";

			// Token: 0x040005DC RID: 1500
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public new const string Subtype = "/Subtype";

			// Token: 0x040005DD RID: 1501
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public new const string BaseFont = "/BaseFont";

			// Token: 0x040005DE RID: 1502
			[KeyInfo(KeyType.NameOrArray | KeyType.StreamOrArray | KeyType.Required)]
			public const string Encoding = "/Encoding";

			// Token: 0x040005DF RID: 1503
			[KeyInfo(KeyType.Array | KeyType.Required)]
			public const string DescendantFonts = "/DescendantFonts";

			// Token: 0x040005E0 RID: 1504
			[KeyInfo(KeyType.String | KeyType.Array | KeyType.Optional)]
			public const string ToUnicode = "/ToUnicode";

			// Token: 0x040005E1 RID: 1505
			private static DictionaryMeta _meta;
		}
	}
}
