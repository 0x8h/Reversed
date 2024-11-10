using System;

namespace PdfSharp.SharpZipLib.Zip.Compression
{
	// Token: 0x020001CC RID: 460
	internal class Deflater
	{
		// Token: 0x06000F20 RID: 3872 RVA: 0x0003AAFF File Offset: 0x00038CFF
		public Deflater()
			: this(-1, false)
		{
		}

		// Token: 0x06000F21 RID: 3873 RVA: 0x0003AB09 File Offset: 0x00038D09
		public Deflater(int level)
			: this(level, false)
		{
		}

		// Token: 0x06000F22 RID: 3874 RVA: 0x0003AB14 File Offset: 0x00038D14
		public Deflater(int level, bool noZlibHeaderOrFooter)
		{
			if (level == -1)
			{
				level = 6;
			}
			else if (level < 0 || level > 9)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			this.pending = new DeflaterPending();
			this.engine = new DeflaterEngine(this.pending);
			this.noZlibHeaderOrFooter = noZlibHeaderOrFooter;
			this.SetStrategy(DeflateStrategy.Default);
			this.SetLevel(level);
			this.Reset();
		}

		// Token: 0x06000F23 RID: 3875 RVA: 0x0003AB7B File Offset: 0x00038D7B
		public void Reset()
		{
			this.state = (this.noZlibHeaderOrFooter ? 16 : 0);
			this.totalOut = 0L;
			this.pending.Reset();
			this.engine.Reset();
		}

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x06000F24 RID: 3876 RVA: 0x0003ABAE File Offset: 0x00038DAE
		public int Adler
		{
			get
			{
				return this.engine.Adler;
			}
		}

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x06000F25 RID: 3877 RVA: 0x0003ABBB File Offset: 0x00038DBB
		public long TotalIn
		{
			get
			{
				return this.engine.TotalIn;
			}
		}

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x06000F26 RID: 3878 RVA: 0x0003ABC8 File Offset: 0x00038DC8
		public long TotalOut
		{
			get
			{
				return this.totalOut;
			}
		}

		// Token: 0x06000F27 RID: 3879 RVA: 0x0003ABD0 File Offset: 0x00038DD0
		public void Flush()
		{
			this.state |= 4;
		}

		// Token: 0x06000F28 RID: 3880 RVA: 0x0003ABE0 File Offset: 0x00038DE0
		public void Finish()
		{
			this.state |= 12;
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x06000F29 RID: 3881 RVA: 0x0003ABF1 File Offset: 0x00038DF1
		public bool IsFinished
		{
			get
			{
				return this.state == 30 && this.pending.IsFlushed;
			}
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x06000F2A RID: 3882 RVA: 0x0003AC0A File Offset: 0x00038E0A
		public bool IsNeedingInput
		{
			get
			{
				return this.engine.NeedsInput();
			}
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x0003AC17 File Offset: 0x00038E17
		public void SetInput(byte[] input)
		{
			this.SetInput(input, 0, input.Length);
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x0003AC24 File Offset: 0x00038E24
		public void SetInput(byte[] input, int offset, int count)
		{
			if ((this.state & 8) != 0)
			{
				throw new InvalidOperationException("Finish() already called");
			}
			this.engine.SetInput(input, offset, count);
		}

		// Token: 0x06000F2D RID: 3885 RVA: 0x0003AC49 File Offset: 0x00038E49
		public void SetLevel(int level)
		{
			if (level == -1)
			{
				level = 6;
			}
			else if (level < 0 || level > 9)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			if (this.level != level)
			{
				this.level = level;
				this.engine.SetLevel(level);
			}
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x0003AC84 File Offset: 0x00038E84
		public int GetLevel()
		{
			return this.level;
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x0003AC8C File Offset: 0x00038E8C
		public void SetStrategy(DeflateStrategy strategy)
		{
			this.engine.Strategy = strategy;
		}

		// Token: 0x06000F30 RID: 3888 RVA: 0x0003AC9A File Offset: 0x00038E9A
		public int Deflate(byte[] output)
		{
			return this.Deflate(output, 0, output.Length);
		}

		// Token: 0x06000F31 RID: 3889 RVA: 0x0003ACA8 File Offset: 0x00038EA8
		public int Deflate(byte[] output, int offset, int length)
		{
			int num = length;
			if (this.state == 127)
			{
				throw new InvalidOperationException("Deflater closed");
			}
			if (this.state < 16)
			{
				int num2 = 30720;
				int num3 = this.level - 1 >> 1;
				if (num3 < 0 || num3 > 3)
				{
					num3 = 3;
				}
				num2 |= num3 << 6;
				if ((this.state & 1) != 0)
				{
					num2 |= 32;
				}
				num2 += 31 - num2 % 31;
				this.pending.WriteShortMSB(num2);
				if ((this.state & 1) != 0)
				{
					int adler = this.engine.Adler;
					this.engine.ResetAdler();
					this.pending.WriteShortMSB(adler >> 16);
					this.pending.WriteShortMSB(adler & 65535);
				}
				this.state = 16 | (this.state & 12);
			}
			for (;;)
			{
				int num4 = this.pending.Flush(output, offset, length);
				offset += num4;
				this.totalOut += (long)num4;
				length -= num4;
				if (length == 0 || this.state == 30)
				{
					goto IL_1DE;
				}
				if (!this.engine.Deflate((this.state & 4) != 0, (this.state & 8) != 0))
				{
					if (this.state == 16)
					{
						break;
					}
					if (this.state == 20)
					{
						if (this.level != 0)
						{
							for (int i = 8 + (-this.pending.BitCount & 7); i > 0; i -= 10)
							{
								this.pending.WriteBits(2, 10);
							}
						}
						this.state = 16;
					}
					else if (this.state == 28)
					{
						this.pending.AlignToByte();
						if (!this.noZlibHeaderOrFooter)
						{
							int adler2 = this.engine.Adler;
							this.pending.WriteShortMSB(adler2 >> 16);
							this.pending.WriteShortMSB(adler2 & 65535);
						}
						this.state = 30;
					}
				}
			}
			return num - length;
			IL_1DE:
			return num - length;
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x0003AE96 File Offset: 0x00039096
		public void SetDictionary(byte[] dictionary)
		{
			this.SetDictionary(dictionary, 0, dictionary.Length);
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x0003AEA3 File Offset: 0x000390A3
		public void SetDictionary(byte[] dictionary, int index, int count)
		{
			if (this.state != 0)
			{
				throw new InvalidOperationException();
			}
			this.state = 1;
			this.engine.SetDictionary(dictionary, index, count);
		}

		// Token: 0x04000973 RID: 2419
		public const int BEST_COMPRESSION = 9;

		// Token: 0x04000974 RID: 2420
		public const int BEST_SPEED = 1;

		// Token: 0x04000975 RID: 2421
		public const int DEFAULT_COMPRESSION = -1;

		// Token: 0x04000976 RID: 2422
		public const int NO_COMPRESSION = 0;

		// Token: 0x04000977 RID: 2423
		public const int DEFLATED = 8;

		// Token: 0x04000978 RID: 2424
		private const int IS_SETDICT = 1;

		// Token: 0x04000979 RID: 2425
		private const int IS_FLUSHING = 4;

		// Token: 0x0400097A RID: 2426
		private const int IS_FINISHING = 8;

		// Token: 0x0400097B RID: 2427
		private const int INIT_STATE = 0;

		// Token: 0x0400097C RID: 2428
		private const int SETDICT_STATE = 1;

		// Token: 0x0400097D RID: 2429
		private const int BUSY_STATE = 16;

		// Token: 0x0400097E RID: 2430
		private const int FLUSHING_STATE = 20;

		// Token: 0x0400097F RID: 2431
		private const int FINISHING_STATE = 28;

		// Token: 0x04000980 RID: 2432
		private const int FINISHED_STATE = 30;

		// Token: 0x04000981 RID: 2433
		private const int CLOSED_STATE = 127;

		// Token: 0x04000982 RID: 2434
		private int level;

		// Token: 0x04000983 RID: 2435
		private bool noZlibHeaderOrFooter;

		// Token: 0x04000984 RID: 2436
		private int state;

		// Token: 0x04000985 RID: 2437
		private long totalOut;

		// Token: 0x04000986 RID: 2438
		private DeflaterPending pending;

		// Token: 0x04000987 RID: 2439
		private DeflaterEngine engine;
	}
}
