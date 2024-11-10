using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000093 RID: 147
	internal class HorizontalMetrics : OpenTypeFontTable
	{
		// Token: 0x06000730 RID: 1840 RVA: 0x0001B8A0 File Offset: 0x00019AA0
		public HorizontalMetrics(OpenTypeFontface fontData)
			: base(fontData, "----")
		{
			this.Read();
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0001B8B4 File Offset: 0x00019AB4
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

		// Token: 0x04000377 RID: 887
		public const string Tag = "----";

		// Token: 0x04000378 RID: 888
		public ushort advanceWidth;

		// Token: 0x04000379 RID: 889
		public short lsb;
	}
}
