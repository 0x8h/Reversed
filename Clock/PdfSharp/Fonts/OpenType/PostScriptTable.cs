using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x0200009D RID: 157
	internal class PostScriptTable : OpenTypeFontTable
	{
		// Token: 0x06000744 RID: 1860 RVA: 0x0001C361 File Offset: 0x0001A561
		public PostScriptTable(OpenTypeFontface fontData)
			: base(fontData, "post")
		{
			this.Read();
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x0001C378 File Offset: 0x0001A578
		public void Read()
		{
			try
			{
				this.formatType = this._fontData.ReadFixed();
				this.italicAngle = (float)this._fontData.ReadFixed() / 65536f;
				this.underlinePosition = this._fontData.ReadFWord();
				this.underlineThickness = this._fontData.ReadFWord();
				this.isFixedPitch = (ulong)this._fontData.ReadULong();
				this.minMemType42 = (ulong)this._fontData.ReadULong();
				this.maxMemType42 = (ulong)this._fontData.ReadULong();
				this.minMemType1 = (ulong)this._fontData.ReadULong();
				this.maxMemType1 = (ulong)this._fontData.ReadULong();
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x040003DD RID: 989
		public const string Tag = "post";

		// Token: 0x040003DE RID: 990
		public int formatType;

		// Token: 0x040003DF RID: 991
		public float italicAngle;

		// Token: 0x040003E0 RID: 992
		public short underlinePosition;

		// Token: 0x040003E1 RID: 993
		public short underlineThickness;

		// Token: 0x040003E2 RID: 994
		public ulong isFixedPitch;

		// Token: 0x040003E3 RID: 995
		public ulong minMemType42;

		// Token: 0x040003E4 RID: 996
		public ulong maxMemType42;

		// Token: 0x040003E5 RID: 997
		public ulong minMemType1;

		// Token: 0x040003E6 RID: 998
		public ulong maxMemType1;
	}
}
