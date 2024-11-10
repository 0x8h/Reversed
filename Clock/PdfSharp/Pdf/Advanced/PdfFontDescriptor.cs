using System;
using PdfSharp.Fonts.OpenType;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000101 RID: 257
	public sealed class PdfFontDescriptor : PdfDictionary
	{
		// Token: 0x06000998 RID: 2456 RVA: 0x00023CF0 File Offset: 0x00021EF0
		internal PdfFontDescriptor(PdfDocument document, OpenTypeDescriptor descriptor)
			: base(document)
		{
			this._descriptor = descriptor;
			base.Elements.SetName("/Type", "/FontDescriptor");
			base.Elements.SetInteger("/Ascent", this._descriptor.DesignUnitsToPdf((double)this._descriptor.Ascender));
			base.Elements.SetInteger("/CapHeight", this._descriptor.DesignUnitsToPdf((double)this._descriptor.CapHeight));
			base.Elements.SetInteger("/Descent", this._descriptor.DesignUnitsToPdf((double)this._descriptor.Descender));
			base.Elements.SetInteger("/Flags", (int)this.FlagsFromDescriptor(this._descriptor));
			base.Elements.SetRectangle("/FontBBox", new PdfRectangle((double)this._descriptor.DesignUnitsToPdf((double)this._descriptor.XMin), (double)this._descriptor.DesignUnitsToPdf((double)this._descriptor.YMin), (double)this._descriptor.DesignUnitsToPdf((double)this._descriptor.XMax), (double)this._descriptor.DesignUnitsToPdf((double)this._descriptor.YMax)));
			base.Elements.SetReal("/ItalicAngle", (double)this._descriptor.ItalicAngle);
			base.Elements.SetInteger("/StemV", this._descriptor.StemV);
			base.Elements.SetInteger("/XHeight", this._descriptor.DesignUnitsToPdf((double)this._descriptor.XHeight));
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000999 RID: 2457 RVA: 0x00023E84 File Offset: 0x00022084
		// (set) Token: 0x0600099A RID: 2458 RVA: 0x00023E96 File Offset: 0x00022096
		public string FontName
		{
			get
			{
				return base.Elements.GetName("/FontName");
			}
			set
			{
				base.Elements.SetName("/FontName", value);
			}
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x0600099B RID: 2459 RVA: 0x00023EA9 File Offset: 0x000220A9
		public bool IsSymbolFont
		{
			get
			{
				return this._isSymbolFont;
			}
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x00023EB4 File Offset: 0x000220B4
		private PdfFontDescriptorFlags FlagsFromDescriptor(OpenTypeDescriptor descriptor)
		{
			PdfFontDescriptorFlags pdfFontDescriptorFlags = (PdfFontDescriptorFlags)0;
			this._isSymbolFont = descriptor.FontFace.cmap.symbol;
			return pdfFontDescriptorFlags | (descriptor.FontFace.cmap.symbol ? PdfFontDescriptorFlags.Symbolic : PdfFontDescriptorFlags.Nonsymbolic);
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x0600099D RID: 2461 RVA: 0x00023EF4 File Offset: 0x000220F4
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfFontDescriptor.Keys.Meta;
			}
		}

		// Token: 0x04000520 RID: 1312
		internal OpenTypeDescriptor _descriptor;

		// Token: 0x04000521 RID: 1313
		private bool _isSymbolFont;

		// Token: 0x02000102 RID: 258
		public sealed class Keys : KeysBase
		{
			// Token: 0x170003A3 RID: 931
			// (get) Token: 0x0600099E RID: 2462 RVA: 0x00023EFB File Offset: 0x000220FB
			internal static DictionaryMeta Meta
			{
				get
				{
					if (PdfFontDescriptor.Keys._meta == null)
					{
						PdfFontDescriptor.Keys._meta = KeysBase.CreateMeta(typeof(PdfFontDescriptor.Keys));
					}
					return PdfFontDescriptor.Keys._meta;
				}
			}

			// Token: 0x04000522 RID: 1314
			[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "FontDescriptor")]
			public const string Type = "/Type";

			// Token: 0x04000523 RID: 1315
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string FontName = "/FontName";

			// Token: 0x04000524 RID: 1316
			[KeyInfo(KeyType.String | KeyType.Optional)]
			public const string FontFamily = "/FontFamily";

			// Token: 0x04000525 RID: 1317
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string FontStretch = "/FontStretch";

			// Token: 0x04000526 RID: 1318
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string FontWeight = "/FontWeight";

			// Token: 0x04000527 RID: 1319
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string Flags = "/Flags";

			// Token: 0x04000528 RID: 1320
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Integer | KeyType.Required)]
			public const string FontBBox = "/FontBBox";

			// Token: 0x04000529 RID: 1321
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Required)]
			public const string ItalicAngle = "/ItalicAngle";

			// Token: 0x0400052A RID: 1322
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Required)]
			public const string Ascent = "/Ascent";

			// Token: 0x0400052B RID: 1323
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Required)]
			public const string Descent = "/Descent";

			// Token: 0x0400052C RID: 1324
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string Leading = "/Leading";

			// Token: 0x0400052D RID: 1325
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Required)]
			public const string CapHeight = "/CapHeight";

			// Token: 0x0400052E RID: 1326
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string XHeight = "/XHeight";

			// Token: 0x0400052F RID: 1327
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Required)]
			public const string StemV = "/StemV";

			// Token: 0x04000530 RID: 1328
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string StemH = "/StemH";

			// Token: 0x04000531 RID: 1329
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string AvgWidth = "/AvgWidth";

			// Token: 0x04000532 RID: 1330
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string MaxWidth = "/MaxWidth";

			// Token: 0x04000533 RID: 1331
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string MissingWidth = "/MissingWidth";

			// Token: 0x04000534 RID: 1332
			[KeyInfo(KeyType.String | KeyType.Array | KeyType.Optional)]
			public const string FontFile = "/FontFile";

			// Token: 0x04000535 RID: 1333
			[KeyInfo(KeyType.String | KeyType.Array | KeyType.Optional)]
			public const string FontFile2 = "/FontFile2";

			// Token: 0x04000536 RID: 1334
			[KeyInfo(KeyType.String | KeyType.Array | KeyType.Optional)]
			public const string FontFile3 = "/FontFile3";

			// Token: 0x04000537 RID: 1335
			[KeyInfo(KeyType.String | KeyType.Optional)]
			public const string CharSet = "/CharSet";

			// Token: 0x04000538 RID: 1336
			private static DictionaryMeta _meta;
		}
	}
}
