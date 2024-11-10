using System;

namespace PdfSharp.SharpZipLib.Zip.Compression
{
	// Token: 0x020001D2 RID: 466
	internal class PendingBuffer
	{
		// Token: 0x06000F63 RID: 3939 RVA: 0x0003CE99 File Offset: 0x0003B099
		public PendingBuffer()
			: this(4096)
		{
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x0003CEA6 File Offset: 0x0003B0A6
		public PendingBuffer(int bufferSize)
		{
			this.buffer_ = new byte[bufferSize];
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x0003CEBC File Offset: 0x0003B0BC
		public void Reset()
		{
			this.start = (this.end = (this.bitCount = 0));
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x0003CEE4 File Offset: 0x0003B0E4
		public void WriteByte(int value)
		{
			this.buffer_[this.end++] = (byte)value;
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x0003CF0C File Offset: 0x0003B10C
		public void WriteShort(int value)
		{
			this.buffer_[this.end++] = (byte)value;
			this.buffer_[this.end++] = (byte)(value >> 8);
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x0003CF50 File Offset: 0x0003B150
		public void WriteInt(int value)
		{
			this.buffer_[this.end++] = (byte)value;
			this.buffer_[this.end++] = (byte)(value >> 8);
			this.buffer_[this.end++] = (byte)(value >> 16);
			this.buffer_[this.end++] = (byte)(value >> 24);
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x0003CFCD File Offset: 0x0003B1CD
		public void WriteBlock(byte[] block, int offset, int length)
		{
			Array.Copy(block, offset, this.buffer_, this.end, length);
			this.end += length;
		}

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06000F6A RID: 3946 RVA: 0x0003CFF1 File Offset: 0x0003B1F1
		public int BitCount
		{
			get
			{
				return this.bitCount;
			}
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x0003CFFC File Offset: 0x0003B1FC
		public void AlignToByte()
		{
			if (this.bitCount > 0)
			{
				this.buffer_[this.end++] = (byte)this.bits;
				if (this.bitCount > 8)
				{
					this.buffer_[this.end++] = (byte)(this.bits >> 8);
				}
			}
			this.bits = 0U;
			this.bitCount = 0;
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x0003D06C File Offset: 0x0003B26C
		public void WriteBits(int b, int count)
		{
			this.bits |= (uint)((uint)b << this.bitCount);
			this.bitCount += count;
			if (this.bitCount >= 16)
			{
				this.buffer_[this.end++] = (byte)this.bits;
				this.buffer_[this.end++] = (byte)(this.bits >> 8);
				this.bits >>= 16;
				this.bitCount -= 16;
			}
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x0003D108 File Offset: 0x0003B308
		public void WriteShortMSB(int s)
		{
			this.buffer_[this.end++] = (byte)(s >> 8);
			this.buffer_[this.end++] = (byte)s;
		}

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06000F6E RID: 3950 RVA: 0x0003D14B File Offset: 0x0003B34B
		public bool IsFlushed
		{
			get
			{
				return this.end == 0;
			}
		}

		// Token: 0x06000F6F RID: 3951 RVA: 0x0003D158 File Offset: 0x0003B358
		public int Flush(byte[] output, int offset, int length)
		{
			if (this.bitCount >= 8)
			{
				this.buffer_[this.end++] = (byte)this.bits;
				this.bits >>= 8;
				this.bitCount -= 8;
			}
			if (length > this.end - this.start)
			{
				length = this.end - this.start;
				Array.Copy(this.buffer_, this.start, output, offset, length);
				this.start = 0;
				this.end = 0;
			}
			else
			{
				Array.Copy(this.buffer_, this.start, output, offset, length);
				this.start += length;
			}
			return length;
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x0003D210 File Offset: 0x0003B410
		public byte[] ToByteArray()
		{
			byte[] array = new byte[this.end - this.start];
			Array.Copy(this.buffer_, this.start, array, 0, array.Length);
			this.start = 0;
			this.end = 0;
			return array;
		}

		// Token: 0x040009DC RID: 2524
		private byte[] buffer_;

		// Token: 0x040009DD RID: 2525
		private int start;

		// Token: 0x040009DE RID: 2526
		private int end;

		// Token: 0x040009DF RID: 2527
		private uint bits;

		// Token: 0x040009E0 RID: 2528
		private int bitCount;
	}
}
