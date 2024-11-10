using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000095 RID: 149
	internal class VerticalHeaderTable : OpenTypeFontTable
	{
		// Token: 0x06000734 RID: 1844 RVA: 0x0001B9D8 File Offset: 0x00019BD8
		public VerticalHeaderTable(OpenTypeFontface fontData)
			: base(fontData, "vhea")
		{
			this.Read();
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x0001B9EC File Offset: 0x00019BEC
		public void Read()
		{
			try
			{
				this.Version = this._fontData.ReadFixed();
				this.Ascender = this._fontData.ReadFWord();
				this.Descender = this._fontData.ReadFWord();
				this.LineGap = this._fontData.ReadFWord();
				this.AdvanceWidthMax = this._fontData.ReadUFWord();
				this.MinLeftSideBearing = this._fontData.ReadFWord();
				this.MinRightSideBearing = this._fontData.ReadFWord();
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

		// Token: 0x0400037D RID: 893
		public const string Tag = "vhea";

		// Token: 0x0400037E RID: 894
		public int Version;

		// Token: 0x0400037F RID: 895
		public short Ascender;

		// Token: 0x04000380 RID: 896
		public short Descender;

		// Token: 0x04000381 RID: 897
		public short LineGap;

		// Token: 0x04000382 RID: 898
		public ushort AdvanceWidthMax;

		// Token: 0x04000383 RID: 899
		public short MinLeftSideBearing;

		// Token: 0x04000384 RID: 900
		public short MinRightSideBearing;

		// Token: 0x04000385 RID: 901
		public short xMaxExtent;

		// Token: 0x04000386 RID: 902
		public short caretSlopeRise;

		// Token: 0x04000387 RID: 903
		public short caretSlopeRun;

		// Token: 0x04000388 RID: 904
		public short reserved1;

		// Token: 0x04000389 RID: 905
		public short reserved2;

		// Token: 0x0400038A RID: 906
		public short reserved3;

		// Token: 0x0400038B RID: 907
		public short reserved4;

		// Token: 0x0400038C RID: 908
		public short reserved5;

		// Token: 0x0400038D RID: 909
		public short metricDataFormat;

		// Token: 0x0400038E RID: 910
		public ushort numberOfHMetrics;
	}
}
