using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000090 RID: 144
	internal class CMapTable : OpenTypeFontTable
	{
		// Token: 0x0600072A RID: 1834 RVA: 0x0001B4A8 File Offset: 0x000196A8
		public CMapTable(OpenTypeFontface fontData)
			: base(fontData, "cmap")
		{
			this.Read();
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0001B4BC File Offset: 0x000196BC
		internal void Read()
		{
			try
			{
				int position = this._fontData.Position;
				this.version = this._fontData.ReadUShort();
				this.numTables = this._fontData.ReadUShort();
				bool flag = false;
				for (int i = 0; i < (int)this.numTables; i++)
				{
					PlatformId platformId = (PlatformId)this._fontData.ReadUShort();
					WinEncodingId winEncodingId = (WinEncodingId)this._fontData.ReadUShort();
					int num = this._fontData.ReadLong();
					int position2 = this._fontData.Position;
					if (platformId == PlatformId.Win && (winEncodingId == WinEncodingId.Symbol || winEncodingId == WinEncodingId.Unicode))
					{
						this.symbol = winEncodingId == WinEncodingId.Symbol;
						this._fontData.Position = position + num;
						this.cmap4 = new CMap4(this._fontData, winEncodingId);
						this._fontData.Position = position2;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					throw new InvalidOperationException("Font has no usable platform or encoding ID. It cannot be used with PDFsharp.");
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x0400034E RID: 846
		public const string Tag = "cmap";

		// Token: 0x0400034F RID: 847
		public ushort version;

		// Token: 0x04000350 RID: 848
		public ushort numTables;

		// Token: 0x04000351 RID: 849
		public bool symbol;

		// Token: 0x04000352 RID: 850
		public CMap4 cmap4;
	}
}
