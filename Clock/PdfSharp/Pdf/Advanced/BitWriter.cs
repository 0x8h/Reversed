using System;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000111 RID: 273
	internal class BitWriter
	{
		// Token: 0x060009EA RID: 2538 RVA: 0x000280F3 File Offset: 0x000262F3
		internal BitWriter(ref byte[] imageData)
		{
			this._imageData = imageData;
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x00028104 File Offset: 0x00026304
		internal void FlushBuffer()
		{
			if (this._bitsInBuffer > 0U)
			{
				uint num = 8U - this._bitsInBuffer;
				this.WriteBits(0U, num);
			}
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x0002812C File Offset: 0x0002632C
		internal void WriteBits(uint value, uint bits)
		{
			while (bits + this._bitsInBuffer > 8U)
			{
				uint num = 8U - this._bitsInBuffer;
				uint num2 = bits - num;
				this.WriteBits(value >> (int)num2, num);
				bits = num2;
			}
			this._buffer = (this._buffer << (int)bits) + (value & BitWriter.masks[(int)((UIntPtr)bits)]);
			this._bitsInBuffer += bits;
			if (this._bitsInBuffer == 8U)
			{
				this._imageData[this._bytesOffsetWrite] = (byte)this._buffer;
				this._bitsInBuffer = 0U;
				this._bytesOffsetWrite++;
			}
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x000281C0 File Offset: 0x000263C0
		internal void WriteTableLine(uint[] table, uint line)
		{
			uint num = table[(int)((UIntPtr)(line * 2U))];
			uint num2 = table[(int)((UIntPtr)(line * 2U + 1U))];
			this.WriteBits(num, num2);
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x000281E5 File Offset: 0x000263E5
		[Obsolete]
		internal void WriteEOL()
		{
			this.WriteTableLine(PdfImage.WhiteMakeUpCodes, 40U);
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x000281F4 File Offset: 0x000263F4
		internal int BytesWritten()
		{
			this.FlushBuffer();
			return this._bytesOffsetWrite;
		}

		// Token: 0x04000577 RID: 1399
		private static readonly uint[] masks = new uint[] { 0U, 1U, 3U, 7U, 15U, 31U, 63U, 127U, 255U };

		// Token: 0x04000578 RID: 1400
		private int _bytesOffsetWrite;

		// Token: 0x04000579 RID: 1401
		private readonly byte[] _imageData;

		// Token: 0x0400057A RID: 1402
		private uint _buffer;

		// Token: 0x0400057B RID: 1403
		private uint _bitsInBuffer;
	}
}
