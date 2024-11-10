using System;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x0200010F RID: 271
	internal class MonochromeMask
	{
		// Token: 0x170003AE RID: 942
		// (get) Token: 0x060009DF RID: 2527 RVA: 0x00027E94 File Offset: 0x00026094
		public byte[] MaskData
		{
			get
			{
				return this._maskData;
			}
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x00027E9C File Offset: 0x0002609C
		public MonochromeMask(int sizeX, int sizeY)
		{
			this._sizeX = sizeX;
			this._sizeY = sizeY;
			int num = (sizeX + 7) / 8 * sizeY;
			this._maskData = new byte[num];
			this.StartLine(0);
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x00027ED8 File Offset: 0x000260D8
		public void StartLine(int newCurrentLine)
		{
			this._bitsWritten = 0;
			this._byteBuffer = 0;
			this._writeOffset = (this._sizeX + 7) / 8 * (this._sizeY - 1 - newCurrentLine);
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x00027F04 File Offset: 0x00026104
		public void AddPel(bool isTransparent)
		{
			if (this._bitsWritten < this._sizeX)
			{
				if (isTransparent)
				{
					this._byteBuffer = (this._byteBuffer << 1) + 1;
				}
				else
				{
					this._byteBuffer <<= 1;
				}
				this._bitsWritten++;
				if ((this._bitsWritten & 7) == 0)
				{
					this._maskData[this._writeOffset] = (byte)this._byteBuffer;
					this._writeOffset++;
					this._byteBuffer = 0;
					return;
				}
				if (this._bitsWritten == this._sizeX)
				{
					int num = 8 - (this._bitsWritten & 7);
					this._byteBuffer <<= num;
					this._maskData[this._writeOffset] = (byte)this._byteBuffer;
				}
			}
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x00027FC5 File Offset: 0x000261C5
		public void AddPel(int shade)
		{
			this.AddPel(shade < 128);
		}

		// Token: 0x0400056B RID: 1387
		private readonly byte[] _maskData;

		// Token: 0x0400056C RID: 1388
		private readonly int _sizeX;

		// Token: 0x0400056D RID: 1389
		private readonly int _sizeY;

		// Token: 0x0400056E RID: 1390
		private int _writeOffset;

		// Token: 0x0400056F RID: 1391
		private int _byteBuffer;

		// Token: 0x04000570 RID: 1392
		private int _bitsWritten;
	}
}
