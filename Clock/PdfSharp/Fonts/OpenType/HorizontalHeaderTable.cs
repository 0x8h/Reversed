using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000092 RID: 146
	internal class HorizontalHeaderTable : OpenTypeFontTable
	{
		// Token: 0x0600072E RID: 1838 RVA: 0x0001B730 File Offset: 0x00019930
		public HorizontalHeaderTable(OpenTypeFontface fontData)
			: base(fontData, "hhea")
		{
			this.Read();
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x0001B744 File Offset: 0x00019944
		public void Read()
		{
			try
			{
				this.version = this._fontData.ReadFixed();
				this.ascender = this._fontData.ReadFWord();
				this.descender = this._fontData.ReadFWord();
				this.lineGap = this._fontData.ReadFWord();
				this.advanceWidthMax = this._fontData.ReadUFWord();
				this.minLeftSideBearing = this._fontData.ReadFWord();
				this.minRightSideBearing = this._fontData.ReadFWord();
				this.xMaxExtent = this._fontData.ReadFWord();
				this.caretSlopeRise = this._fontData.ReadShort();
				this.caretSlopeRun = this._fontData.ReadShort();
				this.reserved1 = this._fontData.ReadShort();
				this.reserved2 = this._fontData.ReadShort();
				this.reserved3 = this._fontData.ReadShort();
				this.reserved4 = this._fontData.ReadShort();
				this.reserved5 = this._fontData.ReadShort();
				this.metricDataFormat = this._fontData.ReadShort();
				this.numberOfHMetrics = this._fontData.ReadUShort();
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x04000365 RID: 869
		public const string Tag = "hhea";

		// Token: 0x04000366 RID: 870
		public int version;

		// Token: 0x04000367 RID: 871
		public short ascender;

		// Token: 0x04000368 RID: 872
		public short descender;

		// Token: 0x04000369 RID: 873
		public short lineGap;

		// Token: 0x0400036A RID: 874
		public ushort advanceWidthMax;

		// Token: 0x0400036B RID: 875
		public short minLeftSideBearing;

		// Token: 0x0400036C RID: 876
		public short minRightSideBearing;

		// Token: 0x0400036D RID: 877
		public short xMaxExtent;

		// Token: 0x0400036E RID: 878
		public short caretSlopeRise;

		// Token: 0x0400036F RID: 879
		public short caretSlopeRun;

		// Token: 0x04000370 RID: 880
		public short reserved1;

		// Token: 0x04000371 RID: 881
		public short reserved2;

		// Token: 0x04000372 RID: 882
		public short reserved3;

		// Token: 0x04000373 RID: 883
		public short reserved4;

		// Token: 0x04000374 RID: 884
		public short reserved5;

		// Token: 0x04000375 RID: 885
		public short metricDataFormat;

		// Token: 0x04000376 RID: 886
		public ushort numberOfHMetrics;
	}
}
