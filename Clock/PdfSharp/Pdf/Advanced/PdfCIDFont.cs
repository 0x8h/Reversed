using System;
using PdfSharp.Drawing;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Pdf.Filters;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x020000EE RID: 238
	internal class PdfCIDFont : PdfFont
	{
		// Token: 0x0600092D RID: 2349 RVA: 0x00022144 File Offset: 0x00020344
		public PdfCIDFont(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x00022150 File Offset: 0x00020350
		public PdfCIDFont(PdfDocument document, PdfFontDescriptor fontDescriptor, XFont font)
			: base(document)
		{
			base.Elements.SetName("/Type", "/Font");
			base.Elements.SetName("/Subtype", "/CIDFontType2");
			PdfDictionary pdfDictionary = new PdfDictionary();
			pdfDictionary.Elements.SetString("/Ordering", "Identity");
			pdfDictionary.Elements.SetString("/Registry", "Adobe");
			pdfDictionary.Elements.SetInteger("/Supplement", 0);
			base.Elements.SetValue("/CIDSystemInfo", pdfDictionary);
			base.FontDescriptor = fontDescriptor;
			this.Owner._irefTable.Add(fontDescriptor);
			base.Elements["/FontDescriptor"] = fontDescriptor.Reference;
			this.FontEncoding = font.PdfOptions.FontEncoding;
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x00022220 File Offset: 0x00020420
		public PdfCIDFont(PdfDocument document, PdfFontDescriptor fontDescriptor, byte[] fontData)
			: base(document)
		{
			base.Elements.SetName("/Type", "/Font");
			base.Elements.SetName("/Subtype", "/CIDFontType2");
			PdfDictionary pdfDictionary = new PdfDictionary();
			pdfDictionary.Elements.SetString("/Ordering", "Identity");
			pdfDictionary.Elements.SetString("/Registry", "Adobe");
			pdfDictionary.Elements.SetInteger("/Supplement", 0);
			base.Elements.SetValue("/CIDSystemInfo", pdfDictionary);
			base.FontDescriptor = fontDescriptor;
			this.Owner._irefTable.Add(fontDescriptor);
			base.Elements["/FontDescriptor"] = fontDescriptor.Reference;
			this.FontEncoding = PdfFontEncoding.Unicode;
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000930 RID: 2352 RVA: 0x000222E5 File Offset: 0x000204E5
		// (set) Token: 0x06000931 RID: 2353 RVA: 0x000222F7 File Offset: 0x000204F7
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

		// Token: 0x06000932 RID: 2354 RVA: 0x0002230C File Offset: 0x0002050C
		internal override void PrepareForSave()
		{
			base.PrepareForSave();
			OpenTypeFontface openTypeFontface;
			if (base.FontDescriptor._descriptor.FontFace.loca == null)
			{
				openTypeFontface = base.FontDescriptor._descriptor.FontFace;
			}
			else
			{
				openTypeFontface = base.FontDescriptor._descriptor.FontFace.CreateFontSubSet(this._cmapInfo.GlyphIndices, true);
			}
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
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000933 RID: 2355 RVA: 0x00022431 File Offset: 0x00020631
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfCIDFont.Keys.Meta;
			}
		}

		// Token: 0x020000EF RID: 239
		public new sealed class Keys : PdfFont.Keys
		{
			// Token: 0x17000382 RID: 898
			// (get) Token: 0x06000934 RID: 2356 RVA: 0x00022438 File Offset: 0x00020638
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfCIDFont.Keys._meta) == null)
					{
						dictionaryMeta = (PdfCIDFont.Keys._meta = KeysBase.CreateMeta(typeof(PdfCIDFont.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040004CA RID: 1226
			[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Font")]
			public new const string Type = "/Type";

			// Token: 0x040004CB RID: 1227
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public new const string Subtype = "/Subtype";

			// Token: 0x040004CC RID: 1228
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public new const string BaseFont = "/BaseFont";

			// Token: 0x040004CD RID: 1229
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required)]
			public const string CIDSystemInfo = "/CIDSystemInfo";

			// Token: 0x040004CE RID: 1230
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.MustBeIndirect, typeof(PdfFontDescriptor))]
			public new const string FontDescriptor = "/FontDescriptor";

			// Token: 0x040004CF RID: 1231
			[KeyInfo(KeyType.Integer)]
			public const string DW = "/DW";

			// Token: 0x040004D0 RID: 1232
			[KeyInfo(KeyType.Array, typeof(PdfArray))]
			public const string W = "/W";

			// Token: 0x040004D1 RID: 1233
			[KeyInfo(KeyType.Array)]
			public const string DW2 = "/DW2";

			// Token: 0x040004D2 RID: 1234
			[KeyInfo(KeyType.Array, typeof(PdfArray))]
			public const string W2 = "/W2";

			// Token: 0x040004D3 RID: 1235
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.NameOrArray | KeyType.StreamOrArray)]
			public const string CIDToGIDMap = "/CIDToGIDMap";

			// Token: 0x040004D4 RID: 1236
			private static DictionaryMeta _meta;
		}
	}
}
