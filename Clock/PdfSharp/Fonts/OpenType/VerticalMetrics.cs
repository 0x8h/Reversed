using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000096 RID: 150
	internal class VerticalMetrics : OpenTypeFontTable
	{
		// Token: 0x06000736 RID: 1846 RVA: 0x0001BB48 File Offset: 0x00019D48
		public VerticalMetrics(OpenTypeFontface fontData)
			: base(fontData, "----")
		{
			this.Read();
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x0001BB5C File Offset: 0x00019D5C
		public void Read()
		{
			try
			{
				this.advanceWidth = this._fontData.ReadUFWord();
				this.lsb = this._fontData.ReadFWord();
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x0400038F RID: 911
		public const string Tag = "----";

		// Token: 0x04000390 RID: 912
		public ushort advanceWidth;

		// Token: 0x04000391 RID: 913
		public short lsb;
	}
}
