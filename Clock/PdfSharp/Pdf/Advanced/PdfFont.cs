using System;
using System.Text;
using PdfSharp.Fonts;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x020000EC RID: 236
	public class PdfFont : PdfDictionary
	{
		// Token: 0x06000921 RID: 2337 RVA: 0x00022053 File Offset: 0x00020253
		public PdfFont(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06000922 RID: 2338 RVA: 0x0002205C File Offset: 0x0002025C
		// (set) Token: 0x06000923 RID: 2339 RVA: 0x00022064 File Offset: 0x00020264
		internal PdfFontDescriptor FontDescriptor
		{
			get
			{
				return this._fontDescriptor;
			}
			set
			{
				this._fontDescriptor = value;
			}
		}

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000924 RID: 2340 RVA: 0x0002206D File Offset: 0x0002026D
		public bool IsSymbolFont
		{
			get
			{
				return this._fontDescriptor.IsSymbolFont;
			}
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0002207A File Offset: 0x0002027A
		internal void AddChars(string text)
		{
			if (this._cmapInfo != null)
			{
				this._cmapInfo.AddChars(text);
			}
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x00022090 File Offset: 0x00020290
		internal void AddGlyphIndices(string glyphIndices)
		{
			if (this._cmapInfo != null)
			{
				this._cmapInfo.AddGlyphIndices(glyphIndices);
			}
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000927 RID: 2343 RVA: 0x000220A6 File Offset: 0x000202A6
		// (set) Token: 0x06000928 RID: 2344 RVA: 0x000220AE File Offset: 0x000202AE
		internal CMapInfo CMapInfo
		{
			get
			{
				return this._cmapInfo;
			}
			set
			{
				this._cmapInfo = value;
			}
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000929 RID: 2345 RVA: 0x000220B7 File Offset: 0x000202B7
		// (set) Token: 0x0600092A RID: 2346 RVA: 0x000220BF File Offset: 0x000202BF
		internal PdfToUnicodeMap ToUnicodeMap
		{
			get
			{
				return this._toUnicode;
			}
			set
			{
				this._toUnicode = value;
			}
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x000220C8 File Offset: 0x000202C8
		internal static string CreateEmbeddedFontSubsetName(string name)
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			byte[] array = Guid.NewGuid().ToByteArray();
			for (int i = 0; i < 6; i++)
			{
				stringBuilder.Append((char)(65 + array[i] % 26));
			}
			stringBuilder.Append('+');
			if (name.StartsWith("/"))
			{
				stringBuilder.Append(name.Substring(1));
			}
			else
			{
				stringBuilder.Append(name);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x040004C2 RID: 1218
		private PdfFontDescriptor _fontDescriptor;

		// Token: 0x040004C3 RID: 1219
		internal PdfFontEncoding FontEncoding;

		// Token: 0x040004C4 RID: 1220
		internal CMapInfo _cmapInfo;

		// Token: 0x040004C5 RID: 1221
		internal PdfToUnicodeMap _toUnicode;

		// Token: 0x020000ED RID: 237
		public class Keys : KeysBase
		{
			// Token: 0x040004C6 RID: 1222
			[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Font")]
			public const string Type = "/Type";

			// Token: 0x040004C7 RID: 1223
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string Subtype = "/Subtype";

			// Token: 0x040004C8 RID: 1224
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string BaseFont = "/BaseFont";

			// Token: 0x040004C9 RID: 1225
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.MustBeIndirect, typeof(PdfFontDescriptor))]
			public const string FontDescriptor = "/FontDescriptor";
		}
	}
}
