using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000097 RID: 151
	internal class VerticalMetricsTable : OpenTypeFontTable
	{
		// Token: 0x06000738 RID: 1848 RVA: 0x0001BBAC File Offset: 0x00019DAC
		public VerticalMetricsTable(OpenTypeFontface fontData)
			: base(fontData, "vmtx")
		{
			this.Read();
			throw new NotImplementedException("VerticalMetricsTable");
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x0001BBCC File Offset: 0x00019DCC
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
					this.metrics = new HorizontalMetrics[numberOfHMetrics];
					for (int i = 0; i < numberOfHMetrics; i++)
					{
						this.metrics[i] = new HorizontalMetrics(this._fontData);
					}
					if (num > 0)
					{
						this.leftSideBearing = new short[num];
						for (int j = 0; j < num; j++)
						{
							this.leftSideBearing[j] = this._fontData.ReadFWord();
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x04000392 RID: 914
		public const string Tag = "vmtx";

		// Token: 0x04000393 RID: 915
		public HorizontalMetrics[] metrics;

		// Token: 0x04000394 RID: 916
		public short[] leftSideBearing;
	}
}
