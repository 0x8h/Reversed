using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000094 RID: 148
	internal class HorizontalMetricsTable : OpenTypeFontTable
	{
		// Token: 0x06000732 RID: 1842 RVA: 0x0001B904 File Offset: 0x00019B04
		public HorizontalMetricsTable(OpenTypeFontface fontData)
			: base(fontData, "hmtx")
		{
			this.Read();
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x0001B918 File Offset: 0x00019B18
		public void Read()
		{
			try
			{
				HorizontalHeaderTable hhea = this._fontData.hhea;
				MaximumProfileTable maxp = this._fontData.maxp;
				if (hhea != null && maxp != null)
				{
					int numberOfHMetrics = (int)hhea.numberOfHMetrics;
					int num = (int)maxp.numGlyphs - numberOfHMetrics;
					this.Metrics = new HorizontalMetrics[numberOfHMetrics];
					for (int i = 0; i < numberOfHMetrics; i++)
					{
						this.Metrics[i] = new HorizontalMetrics(this._fontData);
					}
					if (num > 0)
					{
						this.LeftSideBearing = new short[num];
						for (int j = 0; j < num; j++)
						{
							this.LeftSideBearing[j] = this._fontData.ReadFWord();
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x0400037A RID: 890
		public const string Tag = "hmtx";

		// Token: 0x0400037B RID: 891
		public HorizontalMetrics[] Metrics;

		// Token: 0x0400037C RID: 892
		public short[] LeftSideBearing;
	}
}
