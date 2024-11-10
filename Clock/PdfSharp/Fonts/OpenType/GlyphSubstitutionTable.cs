using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x020000A1 RID: 161
	internal class GlyphSubstitutionTable : OpenTypeFontTable
	{
		// Token: 0x0600074C RID: 1868 RVA: 0x0001C630 File Offset: 0x0001A830
		public GlyphSubstitutionTable(OpenTypeFontface fontData)
			: base(fontData, "GSUB")
		{
			this.DirectoryEntry.Tag = "GSUB";
			this.DirectoryEntry = fontData.TableDictionary["GSUB"];
			this.Read();
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0001C66C File Offset: 0x0001A86C
		public void Read()
		{
		}

		// Token: 0x040003ED RID: 1005
		public const string Tag = "GSUB";
	}
}
