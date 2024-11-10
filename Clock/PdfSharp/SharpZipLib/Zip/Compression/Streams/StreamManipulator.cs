using System;

namespace PdfSharp.SharpZipLib.Zip.Compression.Streams
{
	// Token: 0x020001DB RID: 475
	internal class StreamManipulator
	{
		// Token: 0x06000FE3 RID: 4067 RVA: 0x0003F1F4 File Offset: 0x0003D3F4
		public int PeekBits(int bitCount)
		{
			if (this.bitsInBuffer_ < bitCount)
			{
				if (this.windowStart_ == this.windowEnd_)
				{
					return -1;
				}
				this.buffer_ |= (uint)((uint)((int)(this.window_[this.windowStart_++] & byte.MaxValue) | ((int)(this.window_[this.windowStart_++] & byte.MaxValue) << 8)) << this.bitsInBuffer_);
				this.bitsInBuffer_ += 16;
			}
			return (int)((ulong)this.buffer_ & (ulong)((long)((1 << bitCount) - 1)));
		}

		// Token: 0x06000FE4 RID: 4068 RVA: 0x0003F291 File Offset: 0x0003D491
		public void DropBits(int bitCount)
		{
			this.buffer_ >>= bitCount;
			this.bitsInBuffer_ -= bitCount;
		}

		// Token: 0x06000FE5 RID: 4069 RVA: 0x0003F2B4 File Offset: 0x0003D4B4
		public int GetBits(int bitCount)
		{
			int num = this.PeekBits(bitCount);
			if (num >= 0)
			{
				this.DropBits(bitCount);
			}
			return num;
		}

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x06000FE6 RID: 4070 RVA: 0x0003F2D5 File Offset: 0x0003D4D5
		public int AvailableBits
		{
			get
			{
				return this.bitsInBuffer_;
			}
		}

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x06000FE7 RID: 4071 RVA: 0x0003F2DD File Offset: 0x0003D4DD
		public int AvailableBytes
		{
			get
			{
				return this.windowEnd_ - this.windowStart_ + (this.bitsInBuffer_ >> 3);
			}
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x0003F2F5 File Offset: 0x0003D4F5
		public void SkipToByteBoundary()
		{
			this.buffer_ >>= this.bitsInBuffer_ & 7;
			this.bitsInBuffer_ &= -8;
		}

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x06000FE9 RID: 4073 RVA: 0x0003F31E File Offset: 0x0003D51E
		public bool IsNeedingInput
		{
			get
			{
				return this.windowStart_ == this.windowEnd_;
			}
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x0003F330 File Offset: 0x0003D530
		public int CopyBytes(byte[] output, int offset, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if ((this.bitsInBuffer_ & 7) != 0)
			{
				throw new InvalidOperationException("Bit buffer is not byte aligned!");
			}
			int num = 0;
			while (this.bitsInBuffer_ > 0 && length > 0)
			{
				output[offset++] = (byte)this.buffer_;
				this.buffer_ >>= 8;
				this.bitsInBuffer_ -= 8;
				length--;
				num++;
			}
			if (length == 0)
			{
				return num;
			}
			int num2 = this.windowEnd_ - this.windowStart_;
			if (length > num2)
			{
				length = num2;
			}
			Array.Copy(this.window_, this.windowStart_, output, offset, length);
			this.windowStart_ += length;
			if (((this.windowStart_ - this.windowEnd_) & 1) != 0)
			{
				this.buffer_ = (uint)(this.window_[this.windowStart_++] & byte.MaxValue);
				this.bitsInBuffer_ = 8;
			}
			return num + length;
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x0003F424 File Offset: 0x0003D624
		public void Reset()
		{
			this.buffer_ = 0U;
			this.windowStart_ = (this.windowEnd_ = (this.bitsInBuffer_ = 0));
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x0003F454 File Offset: 0x0003D654
		public void SetInput(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (this.windowStart_ < this.windowEnd_)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			int num = offset + count;
			if (offset > num || num > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if ((count & 1) != 0)
			{
				this.buffer_ |= (uint)((uint)(buffer[offset++] & byte.MaxValue) << this.bitsInBuffer_);
				this.bitsInBuffer_ += 8;
			}
			this.window_ = buffer;
			this.windowStart_ = offset;
			this.windowEnd_ = num;
		}

		// Token: 0x04000A31 RID: 2609
		private byte[] window_;

		// Token: 0x04000A32 RID: 2610
		private int windowStart_;

		// Token: 0x04000A33 RID: 2611
		private int windowEnd_;

		// Token: 0x04000A34 RID: 2612
		private uint buffer_;

		// Token: 0x04000A35 RID: 2613
		private int bitsInBuffer_;
	}
}
