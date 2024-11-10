using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000091 RID: 145
	internal class FontHeaderTable : OpenTypeFontTable
	{
		// Token: 0x0600072C RID: 1836 RVA: 0x0001B5C0 File Offset: 0x000197C0
		public FontHeaderTable(OpenTypeFontface fontData)
			: base(fontData, "head")
		{
			this.Read();
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0001B5D4 File Offset: 0x000197D4
		public void Read()
		{
			try
			{
				this.version = this._fontData.ReadFixed();
				this.fontRevision = this._fontData.ReadFixed();
				this.checkSumAdjustment = this._fontData.ReadULong();
				this.magicNumber = this._fontData.ReadULong();
				this.flags = this._fontData.ReadUShort();
				this.unitsPerEm = this._fontData.ReadUShort();
				this.created = this._fontData.ReadLongDate();
				this.modified = this._fontData.ReadLongDate();
				this.xMin = this._fontData.ReadShort();
				this.yMin = this._fontData.ReadShort();
				this.xMax = this._fontData.ReadShort();
				this.yMax = this._fontData.ReadShort();
				this.macStyle = this._fontData.ReadUShort();
				this.lowestRecPPEM = this._fontData.ReadUShort();
				this.fontDirectionHint = this._fontData.ReadShort();
				this.indexToLocFormat = this._fontData.ReadShort();
				this.glyphDataFormat = this._fontData.ReadShort();
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x04000353 RID: 851
		public const string Tag = "head";

		// Token: 0x04000354 RID: 852
		public int version;

		// Token: 0x04000355 RID: 853
		public int fontRevision;

		// Token: 0x04000356 RID: 854
		public uint checkSumAdjustment;

		// Token: 0x04000357 RID: 855
		public uint magicNumber;

		// Token: 0x04000358 RID: 856
		public ushort flags;

		// Token: 0x04000359 RID: 857
		public ushort unitsPerEm;

		// Token: 0x0400035A RID: 858
		public long created;

		// Token: 0x0400035B RID: 859
		public long modified;

		// Token: 0x0400035C RID: 860
		public short xMin;

		// Token: 0x0400035D RID: 861
		public short yMin;

		// Token: 0x0400035E RID: 862
		public short xMax;

		// Token: 0x0400035F RID: 863
		public short yMax;

		// Token: 0x04000360 RID: 864
		public ushort macStyle;

		// Token: 0x04000361 RID: 865
		public ushort lowestRecPPEM;

		// Token: 0x04000362 RID: 866
		public short fontDirectionHint;

		// Token: 0x04000363 RID: 867
		public short indexToLocFormat;

		// Token: 0x04000364 RID: 868
		public short glyphDataFormat;
	}
}
