using System;
using PdfSharp.SharpZipLib.Checksums;

namespace PdfSharp.SharpZipLib.Zip.Compression
{
	// Token: 0x020001CF RID: 463
	internal class DeflaterEngine : DeflaterConstants
	{
		// Token: 0x06000F37 RID: 3895 RVA: 0x0003B034 File Offset: 0x00039234
		public DeflaterEngine(DeflaterPending pending)
		{
			this.pending = pending;
			this.huffman = new DeflaterHuffman(pending);
			this.adler = new Adler32();
			this.window = new byte[65536];
			this.head = new short[32768];
			this.prev = new short[32768];
			this.blockStart = (this.strstart = 1);
		}

		// Token: 0x06000F38 RID: 3896 RVA: 0x0003B0A8 File Offset: 0x000392A8
		public bool Deflate(bool flush, bool finish)
		{
			for (;;)
			{
				this.FillWindow();
				bool flag = flush && this.inputOff == this.inputEnd;
				bool flag2;
				switch (this.compressionFunction)
				{
				case 0:
					flag2 = this.DeflateStored(flag, finish);
					goto IL_62;
				case 1:
					flag2 = this.DeflateFast(flag, finish);
					goto IL_62;
				case 2:
					flag2 = this.DeflateSlow(flag, finish);
					goto IL_62;
				}
				break;
				IL_62:
				if (!this.pending.IsFlushed || !flag2)
				{
					return flag2;
				}
			}
			throw new InvalidOperationException("unknown compressionFunction");
		}

		// Token: 0x06000F39 RID: 3897 RVA: 0x0003B128 File Offset: 0x00039328
		public void SetInput(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (this.inputOff < this.inputEnd)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			int num = offset + count;
			if (offset > num || num > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			this.inputBuf = buffer;
			this.inputOff = offset;
			this.inputEnd = num;
		}

		// Token: 0x06000F3A RID: 3898 RVA: 0x0003B1A8 File Offset: 0x000393A8
		public bool NeedsInput()
		{
			return this.inputEnd == this.inputOff;
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x0003B1B8 File Offset: 0x000393B8
		public void SetDictionary(byte[] buffer, int offset, int length)
		{
			this.adler.Update(buffer, offset, length);
			if (length < 3)
			{
				return;
			}
			if (length > 32506)
			{
				offset += length - 32506;
				length = 32506;
			}
			Array.Copy(buffer, offset, this.window, this.strstart, length);
			this.UpdateHash();
			length--;
			while (--length > 0)
			{
				this.InsertString();
				this.strstart++;
			}
			this.strstart += 2;
			this.blockStart = this.strstart;
		}

		// Token: 0x06000F3C RID: 3900 RVA: 0x0003B24C File Offset: 0x0003944C
		public void Reset()
		{
			this.huffman.Reset();
			this.adler.Reset();
			this.blockStart = (this.strstart = 1);
			this.lookahead = 0;
			this.totalIn = 0L;
			this.prevAvailable = false;
			this.matchLen = 2;
			for (int i = 0; i < 32768; i++)
			{
				this.head[i] = 0;
			}
			for (int j = 0; j < 32768; j++)
			{
				this.prev[j] = 0;
			}
		}

		// Token: 0x06000F3D RID: 3901 RVA: 0x0003B2CE File Offset: 0x000394CE
		public void ResetAdler()
		{
			this.adler.Reset();
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06000F3E RID: 3902 RVA: 0x0003B2DB File Offset: 0x000394DB
		public int Adler
		{
			get
			{
				return (int)this.adler.Value;
			}
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x0003B2E9 File Offset: 0x000394E9
		public long TotalIn
		{
			get
			{
				return this.totalIn;
			}
		}

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06000F40 RID: 3904 RVA: 0x0003B2F1 File Offset: 0x000394F1
		// (set) Token: 0x06000F41 RID: 3905 RVA: 0x0003B2F9 File Offset: 0x000394F9
		public DeflateStrategy Strategy
		{
			get
			{
				return this.strategy;
			}
			set
			{
				this.strategy = value;
			}
		}

		// Token: 0x06000F42 RID: 3906 RVA: 0x0003B304 File Offset: 0x00039504
		public void SetLevel(int level)
		{
			if (level < 0 || level > 9)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			this.goodLength = DeflaterConstants.GOOD_LENGTH[level];
			this.max_lazy = DeflaterConstants.MAX_LAZY[level];
			this.niceLength = DeflaterConstants.NICE_LENGTH[level];
			this.max_chain = DeflaterConstants.MAX_CHAIN[level];
			if (DeflaterConstants.COMPR_FUNC[level] != this.compressionFunction)
			{
				switch (this.compressionFunction)
				{
				case 0:
					if (this.strstart > this.blockStart)
					{
						this.huffman.FlushStoredBlock(this.window, this.blockStart, this.strstart - this.blockStart, false);
						this.blockStart = this.strstart;
					}
					this.UpdateHash();
					break;
				case 1:
					if (this.strstart > this.blockStart)
					{
						this.huffman.FlushBlock(this.window, this.blockStart, this.strstart - this.blockStart, false);
						this.blockStart = this.strstart;
					}
					break;
				case 2:
					if (this.prevAvailable)
					{
						this.huffman.TallyLit((int)(this.window[this.strstart - 1] & byte.MaxValue));
					}
					if (this.strstart > this.blockStart)
					{
						this.huffman.FlushBlock(this.window, this.blockStart, this.strstart - this.blockStart, false);
						this.blockStart = this.strstart;
					}
					this.prevAvailable = false;
					this.matchLen = 2;
					break;
				}
				this.compressionFunction = DeflaterConstants.COMPR_FUNC[level];
			}
		}

		// Token: 0x06000F43 RID: 3907 RVA: 0x0003B49C File Offset: 0x0003969C
		public void FillWindow()
		{
			if (this.strstart >= 65274)
			{
				this.SlideWindow();
			}
			while (this.lookahead < 262 && this.inputOff < this.inputEnd)
			{
				int num = 65536 - this.lookahead - this.strstart;
				if (num > this.inputEnd - this.inputOff)
				{
					num = this.inputEnd - this.inputOff;
				}
				Array.Copy(this.inputBuf, this.inputOff, this.window, this.strstart + this.lookahead, num);
				this.adler.Update(this.inputBuf, this.inputOff, num);
				this.inputOff += num;
				this.totalIn += (long)num;
				this.lookahead += num;
			}
			if (this.lookahead >= 3)
			{
				this.UpdateHash();
			}
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x0003B58B File Offset: 0x0003978B
		private void UpdateHash()
		{
			this.ins_h = ((int)this.window[this.strstart] << 5) ^ (int)this.window[this.strstart + 1];
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x0003B5B4 File Offset: 0x000397B4
		private int InsertString()
		{
			int num = ((this.ins_h << 5) ^ (int)this.window[this.strstart + 2]) & 32767;
			short num2 = (this.prev[this.strstart & 32767] = this.head[num]);
			this.head[num] = (short)this.strstart;
			this.ins_h = num;
			return (int)num2 & 65535;
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x0003B61C File Offset: 0x0003981C
		private void SlideWindow()
		{
			Array.Copy(this.window, 32768, this.window, 0, 32768);
			this.matchStart -= 32768;
			this.strstart -= 32768;
			this.blockStart -= 32768;
			for (int i = 0; i < 32768; i++)
			{
				int num = (int)this.head[i] & 65535;
				this.head[i] = (short)((num >= 32768) ? (num - 32768) : 0);
			}
			for (int j = 0; j < 32768; j++)
			{
				int num2 = (int)this.prev[j] & 65535;
				this.prev[j] = (short)((num2 >= 32768) ? (num2 - 32768) : 0);
			}
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x0003B6F0 File Offset: 0x000398F0
		private bool FindLongestMatch(int curMatch)
		{
			int num = this.max_chain;
			int num2 = this.niceLength;
			short[] array = this.prev;
			int num3 = this.strstart;
			int num4 = this.strstart + this.matchLen;
			int num5 = Math.Max(this.matchLen, 2);
			int num6 = Math.Max(this.strstart - 32506, 0);
			int num7 = this.strstart + 258 - 1;
			byte b = this.window[num4 - 1];
			byte b2 = this.window[num4];
			if (num5 >= this.goodLength)
			{
				num >>= 2;
			}
			if (num2 > this.lookahead)
			{
				num2 = this.lookahead;
			}
			do
			{
				if (this.window[curMatch + num5] == b2 && this.window[curMatch + num5 - 1] == b && this.window[curMatch] == this.window[num3] && this.window[curMatch + 1] == this.window[num3 + 1])
				{
					int num8 = curMatch + 2;
					num3 += 2;
					while (this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && num3 < num7)
					{
					}
					if (num3 > num4)
					{
						this.matchStart = curMatch;
						num4 = num3;
						num5 = num3 - this.strstart;
						if (num5 >= num2)
						{
							break;
						}
						b = this.window[num4 - 1];
						b2 = this.window[num4];
					}
					num3 = this.strstart;
				}
			}
			while ((curMatch = (int)array[curMatch & 32767] & 65535) > num6 && --num != 0);
			this.matchLen = Math.Min(num5, this.lookahead);
			return this.matchLen >= 3;
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x0003B95C File Offset: 0x00039B5C
		private bool DeflateStored(bool flush, bool finish)
		{
			if (!flush && this.lookahead == 0)
			{
				return false;
			}
			this.strstart += this.lookahead;
			this.lookahead = 0;
			int num = this.strstart - this.blockStart;
			if (num >= DeflaterConstants.MAX_BLOCK_SIZE || (this.blockStart < 32768 && num >= 32506) || flush)
			{
				bool flag = finish;
				if (num > DeflaterConstants.MAX_BLOCK_SIZE)
				{
					num = DeflaterConstants.MAX_BLOCK_SIZE;
					flag = false;
				}
				this.huffman.FlushStoredBlock(this.window, this.blockStart, num, flag);
				this.blockStart += num;
				return !flag;
			}
			return true;
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x0003BA00 File Offset: 0x00039C00
		private bool DeflateFast(bool flush, bool finish)
		{
			if (this.lookahead < 262 && !flush)
			{
				return false;
			}
			while (this.lookahead >= 262 || flush)
			{
				if (this.lookahead == 0)
				{
					this.huffman.FlushBlock(this.window, this.blockStart, this.strstart - this.blockStart, finish);
					this.blockStart = this.strstart;
					return false;
				}
				if (this.strstart > 65274)
				{
					this.SlideWindow();
				}
				int num;
				if (this.lookahead >= 3 && (num = this.InsertString()) != 0 && this.strategy != DeflateStrategy.HuffmanOnly && this.strstart - num <= 32506 && this.FindLongestMatch(num))
				{
					bool flag = this.huffman.TallyDist(this.strstart - this.matchStart, this.matchLen);
					this.lookahead -= this.matchLen;
					if (this.matchLen <= this.max_lazy && this.lookahead >= 3)
					{
						while (--this.matchLen > 0)
						{
							this.strstart++;
							this.InsertString();
						}
						this.strstart++;
					}
					else
					{
						this.strstart += this.matchLen;
						if (this.lookahead >= 2)
						{
							this.UpdateHash();
						}
					}
					this.matchLen = 2;
					if (!flag)
					{
						continue;
					}
				}
				else
				{
					this.huffman.TallyLit((int)(this.window[this.strstart] & byte.MaxValue));
					this.strstart++;
					this.lookahead--;
				}
				if (this.huffman.IsFull())
				{
					bool flag2 = finish && this.lookahead == 0;
					this.huffman.FlushBlock(this.window, this.blockStart, this.strstart - this.blockStart, flag2);
					this.blockStart = this.strstart;
					return !flag2;
				}
			}
			return true;
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x0003BC10 File Offset: 0x00039E10
		private bool DeflateSlow(bool flush, bool finish)
		{
			if (this.lookahead < 262 && !flush)
			{
				return false;
			}
			while (this.lookahead >= 262 || flush)
			{
				if (this.lookahead == 0)
				{
					if (this.prevAvailable)
					{
						this.huffman.TallyLit((int)(this.window[this.strstart - 1] & byte.MaxValue));
					}
					this.prevAvailable = false;
					this.huffman.FlushBlock(this.window, this.blockStart, this.strstart - this.blockStart, finish);
					this.blockStart = this.strstart;
					return false;
				}
				if (this.strstart >= 65274)
				{
					this.SlideWindow();
				}
				int num = this.matchStart;
				int num2 = this.matchLen;
				if (this.lookahead >= 3)
				{
					int num3 = this.InsertString();
					if (this.strategy != DeflateStrategy.HuffmanOnly && num3 != 0 && this.strstart - num3 <= 32506 && this.FindLongestMatch(num3) && this.matchLen <= 5 && (this.strategy == DeflateStrategy.Filtered || (this.matchLen == 3 && this.strstart - this.matchStart > 4096)))
					{
						this.matchLen = 2;
					}
				}
				if (num2 >= 3 && this.matchLen <= num2)
				{
					this.huffman.TallyDist(this.strstart - 1 - num, num2);
					num2 -= 2;
					do
					{
						this.strstart++;
						this.lookahead--;
						if (this.lookahead >= 3)
						{
							this.InsertString();
						}
					}
					while (--num2 > 0);
					this.strstart++;
					this.lookahead--;
					this.prevAvailable = false;
					this.matchLen = 2;
				}
				else
				{
					if (this.prevAvailable)
					{
						this.huffman.TallyLit((int)(this.window[this.strstart - 1] & byte.MaxValue));
					}
					this.prevAvailable = true;
					this.strstart++;
					this.lookahead--;
				}
				if (this.huffman.IsFull())
				{
					int num4 = this.strstart - this.blockStart;
					if (this.prevAvailable)
					{
						num4--;
					}
					bool flag = finish && this.lookahead == 0 && !this.prevAvailable;
					this.huffman.FlushBlock(this.window, this.blockStart, num4, flag);
					this.blockStart += num4;
					return !flag;
				}
			}
			return true;
		}

		// Token: 0x040009A6 RID: 2470
		private const int TooFar = 4096;

		// Token: 0x040009A7 RID: 2471
		private int ins_h;

		// Token: 0x040009A8 RID: 2472
		private short[] head;

		// Token: 0x040009A9 RID: 2473
		private short[] prev;

		// Token: 0x040009AA RID: 2474
		private int matchStart;

		// Token: 0x040009AB RID: 2475
		private int matchLen;

		// Token: 0x040009AC RID: 2476
		private bool prevAvailable;

		// Token: 0x040009AD RID: 2477
		private int blockStart;

		// Token: 0x040009AE RID: 2478
		private int strstart;

		// Token: 0x040009AF RID: 2479
		private int lookahead;

		// Token: 0x040009B0 RID: 2480
		private byte[] window;

		// Token: 0x040009B1 RID: 2481
		private DeflateStrategy strategy;

		// Token: 0x040009B2 RID: 2482
		private int max_chain;

		// Token: 0x040009B3 RID: 2483
		private int max_lazy;

		// Token: 0x040009B4 RID: 2484
		private int niceLength;

		// Token: 0x040009B5 RID: 2485
		private int goodLength;

		// Token: 0x040009B6 RID: 2486
		private int compressionFunction;

		// Token: 0x040009B7 RID: 2487
		private byte[] inputBuf;

		// Token: 0x040009B8 RID: 2488
		private long totalIn;

		// Token: 0x040009B9 RID: 2489
		private int inputOff;

		// Token: 0x040009BA RID: 2490
		private int inputEnd;

		// Token: 0x040009BB RID: 2491
		private DeflaterPending pending;

		// Token: 0x040009BC RID: 2492
		private DeflaterHuffman huffman;

		// Token: 0x040009BD RID: 2493
		private Adler32 adler;
	}
}
