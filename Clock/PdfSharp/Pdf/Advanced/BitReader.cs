using System;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000110 RID: 272
	internal class BitReader
	{
		// Token: 0x060009E4 RID: 2532 RVA: 0x00027FD5 File Offset: 0x000261D5
		internal BitReader(byte[] imageBits, uint bytesFileOffset, uint bits)
		{
			this._imageBits = imageBits;
			this._bytesFileOffset = bytesFileOffset;
			this._bitsTotal = bits;
			this._bytesOffsetRead = bytesFileOffset;
			this._buffer = imageBits[(int)((UIntPtr)this._bytesOffsetRead)];
			this._bitsInBuffer = 8U;
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0002800F File Offset: 0x0002620F
		internal void SetPosition(uint position)
		{
			this._bytesOffsetRead = this._bytesFileOffset + (position >> 3);
			this._buffer = this._imageBits[(int)((UIntPtr)this._bytesOffsetRead)];
			this._bitsInBuffer = 8U - (position & 7U);
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x00028040 File Offset: 0x00026240
		internal bool GetBit(uint position)
		{
			if (position >= this._bitsTotal)
			{
				return false;
			}
			this.SetPosition(position);
			uint num;
			return (this.PeekByte(out num) & 128) > 0;
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x00028070 File Offset: 0x00026270
		internal byte PeekByte(out uint bits)
		{
			if (this._bitsInBuffer == 8U)
			{
				bits = 8U;
				return this._buffer;
			}
			bits = this._bitsInBuffer;
			return (byte)(this._buffer << (int)(8U - this._bitsInBuffer));
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x000280A0 File Offset: 0x000262A0
		internal void NextByte()
		{
			this._buffer = this._imageBits[(int)((UIntPtr)(this._bytesOffsetRead += 1U))];
			this._bitsInBuffer = 8U;
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x000280D3 File Offset: 0x000262D3
		internal void SkipBits(uint bits)
		{
			if (bits == this._bitsInBuffer)
			{
				this.NextByte();
				return;
			}
			this._bitsInBuffer -= bits;
		}

		// Token: 0x04000571 RID: 1393
		private readonly byte[] _imageBits;

		// Token: 0x04000572 RID: 1394
		private uint _bytesOffsetRead;

		// Token: 0x04000573 RID: 1395
		private readonly uint _bytesFileOffset;

		// Token: 0x04000574 RID: 1396
		private byte _buffer;

		// Token: 0x04000575 RID: 1397
		private uint _bitsInBuffer;

		// Token: 0x04000576 RID: 1398
		private readonly uint _bitsTotal;
	}
}
