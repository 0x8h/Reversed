using System;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Pdf.Filters;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x0200012B RID: 299
	internal class PdfTrueTypeFont : PdfFont
	{
		// Token: 0x06000A74 RID: 2676 RVA: 0x000299F5 File Offset: 0x00027BF5
		public PdfTrueTypeFont(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x00029A00 File Offset: 0x00027C00
		public PdfTrueTypeFont(PdfDocument document, XFont font)
			: base(document)
		{
			base.Elements.SetName("/Type", "/Font");
			base.Elements.SetName("/Subtype", "/TrueType");
			OpenTypeDescriptor openTypeDescriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptorFor(font);
			base.FontDescriptor = new PdfFontDescriptor(document, openTypeDescriptor);
			this._fontOptions = font.PdfOptions;
			this._cmapInfo = new CMapInfo(openTypeDescriptor);
			this.BaseFont = font.GlyphTypeface.GetBaseName();
			if (this._fontOptions.FontEmbedding == PdfFontEmbedding.Always)
			{
				this.BaseFont = PdfFont.CreateEmbeddedFontSubsetName(this.BaseFont);
			}
			base.FontDescriptor.FontName = this.BaseFont;
			if (!base.IsSymbolFont)
			{
				this.Encoding = "/WinAnsiEncoding";
			}
			this.Owner._irefTable.Add(base.FontDescriptor);
			base.Elements["/FontDescriptor"] = base.FontDescriptor.Reference;
			this.FontEncoding = font.PdfOptions.FontEncoding;
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06000A76 RID: 2678 RVA: 0x00029B04 File Offset: 0x00027D04
		private XPdfFontOptions FontOptions
		{
			get
			{
				return this._fontOptions;
			}
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06000A77 RID: 2679 RVA: 0x00029B0C File Offset: 0x00027D0C
		// (set) Token: 0x06000A78 RID: 2680 RVA: 0x00029B1E File Offset: 0x00027D1E
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

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06000A79 RID: 2681 RVA: 0x00029B31 File Offset: 0x00027D31
		// (set) Token: 0x06000A7A RID: 2682 RVA: 0x00029B43 File Offset: 0x00027D43
		public int FirstChar
		{
			get
			{
				return base.Elements.GetInteger("/FirstChar");
			}
			set
			{
				base.Elements.SetInteger("/FirstChar", value);
			}
		}

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06000A7B RID: 2683 RVA: 0x00029B56 File Offset: 0x00027D56
		// (set) Token: 0x06000A7C RID: 2684 RVA: 0x00029B68 File Offset: 0x00027D68
		public int LastChar
		{
			get
			{
				return base.Elements.GetInteger("/LastChar");
			}
			set
			{
				base.Elements.SetInteger("/LastChar", value);
			}
		}

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06000A7D RID: 2685 RVA: 0x00029B7B File Offset: 0x00027D7B
		public PdfArray Widths
		{
			get
			{
				return (PdfArray)base.Elements.GetValue("/Widths", VCF.Create);
			}
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06000A7E RID: 2686 RVA: 0x00029B93 File Offset: 0x00027D93
		// (set) Token: 0x06000A7F RID: 2687 RVA: 0x00029BA5 File Offset: 0x00027DA5
		public string Encoding
		{
			get
			{
				return base.Elements.GetName("/Encoding");
			}
			set
			{
				base.Elements.SetName("/Encoding", value);
			}
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x00029BB8 File Offset: 0x00027DB8
		internal override void PrepareForSave()
		{
			base.PrepareForSave();
			OpenTypeFontface openTypeFontface = base.FontDescriptor._descriptor.FontFace.CreateFontSubSet(this._cmapInfo.GlyphIndices, false);
			byte[] array = openTypeFontface.FontSource.Bytes;
			PdfDictionary pdfDictionary = new PdfDictionary(this.Owner);
			this.Owner.Internals.AddObject(pdfDictionary);
			base.FontDescriptor.Elements["/FontFile2"] = pdfDictionary.Reference;
			pdfDictionary.Elements["/Length1"] = new PdfInteger(array.Length);
			if (!this.Owner.Options.NoCompression)
			{
				array = Filtering.FlateDecode.Encode(array, this._document.Options.FlateEncodeMode);
				pdfDictionary.Elements["/Filter"] = new PdfName("/FlateDecode");
			}
			pdfDictionary.Elements["/Length"] = new PdfInteger(array.Length);
			pdfDictionary.CreateStream(array);
			this.FirstChar = 0;
			this.LastChar = 255;
			PdfArray widths = this.Widths;
			for (int i = 0; i < 256; i++)
			{
				widths.Elements.Add(new PdfInteger(base.FontDescriptor._descriptor.Widths[i]));
			}
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06000A81 RID: 2689 RVA: 0x00029D01 File Offset: 0x00027F01
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfTrueTypeFont.Keys.Meta;
			}
		}

		// Token: 0x040005CD RID: 1485
		private readonly XPdfFontOptions _fontOptions;

		// Token: 0x0200012C RID: 300
		public new sealed class Keys : PdfFont.Keys
		{
			// Token: 0x170003E7 RID: 999
			// (get) Token: 0x06000A82 RID: 2690 RVA: 0x00029D08 File Offset: 0x00027F08
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfTrueTypeFont.Keys._meta) == null)
					{
						dictionaryMeta = (PdfTrueTypeFont.Keys._meta = KeysBase.CreateMeta(typeof(PdfTrueTypeFont.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040005CE RID: 1486
			[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Font")]
			public new const string Type = "/Type";

			// Token: 0x040005CF RID: 1487
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public new const string Subtype = "/Subtype";

			// Token: 0x040005D0 RID: 1488
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string Name = "/Name";

			// Token: 0x040005D1 RID: 1489
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public new const string BaseFont = "/BaseFont";

			// Token: 0x040005D2 RID: 1490
			[KeyInfo(KeyType.Integer)]
			public const string FirstChar = "/FirstChar";

			// Token: 0x040005D3 RID: 1491
			[KeyInfo(KeyType.Integer)]
			public const string LastChar = "/LastChar";

			// Token: 0x040005D4 RID: 1492
			[KeyInfo(KeyType.Array, typeof(PdfArray))]
			public const string Widths = "/Widths";

			// Token: 0x040005D5 RID: 1493
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.MustBeIndirect, typeof(PdfFontDescriptor))]
			public new const string FontDescriptor = "/FontDescriptor";

			// Token: 0x040005D6 RID: 1494
			[KeyInfo(KeyType.Dictionary)]
			public const string Encoding = "/Encoding";

			// Token: 0x040005D7 RID: 1495
			[KeyInfo(KeyType.String | KeyType.Array | KeyType.Optional)]
			public const string ToUnicode = "/ToUnicode";

			// Token: 0x040005D8 RID: 1496
			private static DictionaryMeta _meta;
		}
	}
}
