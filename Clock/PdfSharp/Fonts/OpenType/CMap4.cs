using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x0200008F RID: 143
	internal class CMap4 : OpenTypeFontTable
	{
		// Token: 0x06000728 RID: 1832 RVA: 0x0001B2C3 File Offset: 0x000194C3
		public CMap4(OpenTypeFontface fontData, WinEncodingId encodingId)
			: base(fontData, "----")
		{
			this.encodingId = encodingId;
			this.Read();
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0001B2E0 File Offset: 0x000194E0
		internal void Read()
		{
			try
			{
				this.format = this._fontData.ReadUShort();
				this.length = this._fontData.ReadUShort();
				this.language = this._fontData.ReadUShort();
				this.segCountX2 = this._fontData.ReadUShort();
				this.searchRange = this._fontData.ReadUShort();
				this.entrySelector = this._fontData.ReadUShort();
				this.rangeShift = this._fontData.ReadUShort();
				int num = (int)(this.segCountX2 / 2);
				this.glyphCount = ((int)this.length - (16 + 8 * num)) / 2;
				this.endCount = new ushort[num];
				this.startCount = new ushort[num];
				this.idDelta = new short[num];
				this.idRangeOffs = new ushort[num];
				this.glyphIdArray = new ushort[this.glyphCount];
				for (int i = 0; i < num; i++)
				{
					this.endCount[i] = this._fontData.ReadUShort();
				}
				this._fontData.ReadUShort();
				for (int j = 0; j < num; j++)
				{
					this.startCount[j] = this._fontData.ReadUShort();
				}
				for (int k = 0; k < num; k++)
				{
					this.idDelta[k] = this._fontData.ReadShort();
				}
				for (int l = 0; l < num; l++)
				{
					this.idRangeOffs[l] = this._fontData.ReadUShort();
				}
				for (int m = 0; m < this.glyphCount; m++)
				{
					this.glyphIdArray[m] = this._fontData.ReadUShort();
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x04000340 RID: 832
		public WinEncodingId encodingId;

		// Token: 0x04000341 RID: 833
		public ushort format;

		// Token: 0x04000342 RID: 834
		public ushort length;

		// Token: 0x04000343 RID: 835
		public ushort language;

		// Token: 0x04000344 RID: 836
		public ushort segCountX2;

		// Token: 0x04000345 RID: 837
		public ushort searchRange;

		// Token: 0x04000346 RID: 838
		public ushort entrySelector;

		// Token: 0x04000347 RID: 839
		public ushort rangeShift;

		// Token: 0x04000348 RID: 840
		public ushort[] endCount;

		// Token: 0x04000349 RID: 841
		public ushort[] startCount;

		// Token: 0x0400034A RID: 842
		public short[] idDelta;

		// Token: 0x0400034B RID: 843
		public ushort[] idRangeOffs;

		// Token: 0x0400034C RID: 844
		public int glyphCount;

		// Token: 0x0400034D RID: 845
		public ushort[] glyphIdArray;
	}
}
