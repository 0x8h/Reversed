using System;
using PdfSharp.SharpZipLib.Checksums;
using PdfSharp.SharpZipLib.Zip.Compression.Streams;

namespace PdfSharp.SharpZipLib.Zip.Compression
{
	// Token: 0x020001D4 RID: 468
	internal class Inflater
	{
		// Token: 0x06000F72 RID: 3954 RVA: 0x0003D262 File Offset: 0x0003B462
		public Inflater()
			: this(false)
		{
		}

		// Token: 0x06000F73 RID: 3955 RVA: 0x0003D26B File Offset: 0x0003B46B
		public Inflater(bool noHeader)
		{
			this.noHeader = noHeader;
			this.adler = new Adler32();
			this.input = new StreamManipulator();
			this.outputWindow = new OutputWindow();
			this.mode = (noHeader ? 2 : 0);
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x0003D2A8 File Offset: 0x0003B4A8
		public void Reset()
		{
			this.mode = (this.noHeader ? 2 : 0);
			this.totalIn = 0L;
			this.totalOut = 0L;
			this.input.Reset();
			this.outputWindow.Reset();
			this.dynHeader = null;
			this.litlenTree = null;
			this.distTree = null;
			this.isLastBlock = false;
			this.adler.Reset();
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x0003D314 File Offset: 0x0003B514
		private bool DecodeHeader()
		{
			int num = this.input.PeekBits(16);
			if (num < 0)
			{
				return false;
			}
			this.input.DropBits(16);
			num = ((num << 8) | (num >> 8)) & 65535;
			if (num % 31 != 0)
			{
				throw new SharpZipBaseException("Header checksum illegal");
			}
			if ((num & 3840) != 2048)
			{
				throw new SharpZipBaseException("Compression Method unknown");
			}
			if ((num & 32) == 0)
			{
				this.mode = 2;
			}
			else
			{
				this.mode = 1;
				this.neededBits = 32;
			}
			return true;
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x0003D39C File Offset: 0x0003B59C
		private bool DecodeDict()
		{
			while (this.neededBits > 0)
			{
				int num = this.input.PeekBits(8);
				if (num < 0)
				{
					return false;
				}
				this.input.DropBits(8);
				this.readAdler = (this.readAdler << 8) | num;
				this.neededBits -= 8;
			}
			return false;
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x0003D3F4 File Offset: 0x0003B5F4
		private bool DecodeHuffman()
		{
			int i = this.outputWindow.GetFreeSpace();
			while (i >= 258)
			{
				int num;
				switch (this.mode)
				{
				case 7:
					while (((num = this.litlenTree.GetSymbol(this.input)) & -256) == 0)
					{
						this.outputWindow.Write(num);
						if (--i < 258)
						{
							return true;
						}
					}
					if (num >= 257)
					{
						try
						{
							this.repLength = Inflater.CPLENS[num - 257];
							this.neededBits = Inflater.CPLEXT[num - 257];
						}
						catch (Exception)
						{
							throw new SharpZipBaseException("Illegal rep length code");
						}
						goto IL_C5;
					}
					if (num < 0)
					{
						return false;
					}
					this.distTree = null;
					this.litlenTree = null;
					this.mode = 2;
					return true;
				case 8:
					goto IL_C5;
				case 9:
					goto IL_114;
				case 10:
					break;
				default:
					throw new SharpZipBaseException("Inflater unknown mode");
				}
				IL_154:
				if (this.neededBits > 0)
				{
					this.mode = 10;
					int num2 = this.input.PeekBits(this.neededBits);
					if (num2 < 0)
					{
						return false;
					}
					this.input.DropBits(this.neededBits);
					this.repDist += num2;
				}
				this.outputWindow.Repeat(this.repLength, this.repDist);
				i -= this.repLength;
				this.mode = 7;
				continue;
				IL_114:
				num = this.distTree.GetSymbol(this.input);
				if (num < 0)
				{
					return false;
				}
				try
				{
					this.repDist = Inflater.CPDIST[num];
					this.neededBits = Inflater.CPDEXT[num];
				}
				catch (Exception)
				{
					throw new SharpZipBaseException("Illegal rep dist code");
				}
				goto IL_154;
				IL_C5:
				if (this.neededBits > 0)
				{
					this.mode = 8;
					int num3 = this.input.PeekBits(this.neededBits);
					if (num3 < 0)
					{
						return false;
					}
					this.input.DropBits(this.neededBits);
					this.repLength += num3;
				}
				this.mode = 9;
				goto IL_114;
			}
			return true;
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x0003D5FC File Offset: 0x0003B7FC
		private bool DecodeChksum()
		{
			while (this.neededBits > 0)
			{
				int num = this.input.PeekBits(8);
				if (num < 0)
				{
					return false;
				}
				this.input.DropBits(8);
				this.readAdler = (this.readAdler << 8) | num;
				this.neededBits -= 8;
			}
			if ((int)this.adler.Value != this.readAdler)
			{
				throw new SharpZipBaseException(string.Concat(new object[]
				{
					"Adler chksum doesn't match: ",
					(int)this.adler.Value,
					" vs. ",
					this.readAdler
				}));
			}
			this.mode = 12;
			return false;
		}

		// Token: 0x06000F79 RID: 3961 RVA: 0x0003D6B4 File Offset: 0x0003B8B4
		private bool Decode()
		{
			switch (this.mode)
			{
			case 0:
				return this.DecodeHeader();
			case 1:
				return this.DecodeDict();
			case 2:
				if (this.isLastBlock)
				{
					if (this.noHeader)
					{
						this.mode = 12;
						return false;
					}
					this.input.SkipToByteBoundary();
					this.neededBits = 32;
					this.mode = 11;
					return true;
				}
				else
				{
					int num = this.input.PeekBits(3);
					if (num < 0)
					{
						return false;
					}
					this.input.DropBits(3);
					if ((num & 1) != 0)
					{
						this.isLastBlock = true;
					}
					switch (num >> 1)
					{
					case 0:
						this.input.SkipToByteBoundary();
						this.mode = 3;
						break;
					case 1:
						this.litlenTree = InflaterHuffmanTree.defLitLenTree;
						this.distTree = InflaterHuffmanTree.defDistTree;
						this.mode = 7;
						break;
					case 2:
						this.dynHeader = new InflaterDynHeader();
						this.mode = 6;
						break;
					default:
						throw new SharpZipBaseException("Unknown block type " + num);
					}
					return true;
				}
				break;
			case 3:
				if ((this.uncomprLen = this.input.PeekBits(16)) < 0)
				{
					return false;
				}
				this.input.DropBits(16);
				this.mode = 4;
				break;
			case 4:
				break;
			case 5:
				goto IL_1A9;
			case 6:
				if (!this.dynHeader.Decode(this.input))
				{
					return false;
				}
				this.litlenTree = this.dynHeader.BuildLitLenTree();
				this.distTree = this.dynHeader.BuildDistTree();
				this.mode = 7;
				goto IL_22D;
			case 7:
			case 8:
			case 9:
			case 10:
				goto IL_22D;
			case 11:
				return this.DecodeChksum();
			case 12:
				return false;
			default:
				throw new SharpZipBaseException("Inflater.Decode unknown mode");
			}
			int num2 = this.input.PeekBits(16);
			if (num2 < 0)
			{
				return false;
			}
			this.input.DropBits(16);
			if (num2 != (this.uncomprLen ^ 65535))
			{
				throw new SharpZipBaseException("broken uncompressed block");
			}
			this.mode = 5;
			IL_1A9:
			int num3 = this.outputWindow.CopyStored(this.input, this.uncomprLen);
			this.uncomprLen -= num3;
			if (this.uncomprLen == 0)
			{
				this.mode = 2;
				return true;
			}
			return !this.input.IsNeedingInput;
			IL_22D:
			return this.DecodeHuffman();
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x0003D901 File Offset: 0x0003BB01
		public void SetDictionary(byte[] buffer)
		{
			this.SetDictionary(buffer, 0, buffer.Length);
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x0003D910 File Offset: 0x0003BB10
		public void SetDictionary(byte[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (!this.IsNeedingDictionary)
			{
				throw new InvalidOperationException("Dictionary is not needed");
			}
			this.adler.Update(buffer, index, count);
			if ((int)this.adler.Value != this.readAdler)
			{
				throw new SharpZipBaseException("Wrong adler checksum");
			}
			this.adler.Reset();
			this.outputWindow.CopyDict(buffer, index, count);
			this.mode = 2;
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x0003D9A9 File Offset: 0x0003BBA9
		public void SetInput(byte[] buffer)
		{
			this.SetInput(buffer, 0, buffer.Length);
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x0003D9B6 File Offset: 0x0003BBB6
		public void SetInput(byte[] buffer, int index, int count)
		{
			this.input.SetInput(buffer, index, count);
			this.totalIn += (long)count;
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x0003D9D5 File Offset: 0x0003BBD5
		public int Inflate(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return this.Inflate(buffer, 0, buffer.Length);
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x0003D9F0 File Offset: 0x0003BBF0
		public int Inflate(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "count cannot be negative");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "offset cannot be negative");
			}
			if (offset + count > buffer.Length)
			{
				throw new ArgumentException("count exceeds buffer bounds");
			}
			if (count == 0)
			{
				if (!this.IsFinished)
				{
					this.Decode();
				}
				return 0;
			}
			int num = 0;
			for (;;)
			{
				if (this.mode != 11)
				{
					int num2 = this.outputWindow.CopyOutput(buffer, offset, count);
					if (num2 > 0)
					{
						this.adler.Update(buffer, offset, num2);
						offset += num2;
						num += num2;
						this.totalOut += (long)num2;
						count -= num2;
						if (count == 0)
						{
							break;
						}
					}
				}
				if (!this.Decode() && (this.outputWindow.GetAvailable() <= 0 || this.mode == 11))
				{
					return num;
				}
			}
			return num;
		}

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06000F80 RID: 3968 RVA: 0x0003DACA File Offset: 0x0003BCCA
		public bool IsNeedingInput
		{
			get
			{
				return this.input.IsNeedingInput;
			}
		}

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06000F81 RID: 3969 RVA: 0x0003DAD7 File Offset: 0x0003BCD7
		public bool IsNeedingDictionary
		{
			get
			{
				return this.mode == 1 && this.neededBits == 0;
			}
		}

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06000F82 RID: 3970 RVA: 0x0003DAED File Offset: 0x0003BCED
		public bool IsFinished
		{
			get
			{
				return this.mode == 12 && this.outputWindow.GetAvailable() == 0;
			}
		}

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06000F83 RID: 3971 RVA: 0x0003DB09 File Offset: 0x0003BD09
		public int Adler
		{
			get
			{
				if (!this.IsNeedingDictionary)
				{
					return (int)this.adler.Value;
				}
				return this.readAdler;
			}
		}

		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06000F84 RID: 3972 RVA: 0x0003DB26 File Offset: 0x0003BD26
		public long TotalOut
		{
			get
			{
				return this.totalOut;
			}
		}

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x06000F85 RID: 3973 RVA: 0x0003DB2E File Offset: 0x0003BD2E
		public long TotalIn
		{
			get
			{
				return this.totalIn - (long)this.RemainingInput;
			}
		}

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x06000F86 RID: 3974 RVA: 0x0003DB3E File Offset: 0x0003BD3E
		public int RemainingInput
		{
			get
			{
				return this.input.AvailableBytes;
			}
		}

		// Token: 0x040009E1 RID: 2529
		private const int DECODE_HEADER = 0;

		// Token: 0x040009E2 RID: 2530
		private const int DECODE_DICT = 1;

		// Token: 0x040009E3 RID: 2531
		private const int DECODE_BLOCKS = 2;

		// Token: 0x040009E4 RID: 2532
		private const int DECODE_STORED_LEN1 = 3;

		// Token: 0x040009E5 RID: 2533
		private const int DECODE_STORED_LEN2 = 4;

		// Token: 0x040009E6 RID: 2534
		private const int DECODE_STORED = 5;

		// Token: 0x040009E7 RID: 2535
		private const int DECODE_DYN_HEADER = 6;

		// Token: 0x040009E8 RID: 2536
		private const int DECODE_HUFFMAN = 7;

		// Token: 0x040009E9 RID: 2537
		private const int DECODE_HUFFMAN_LENBITS = 8;

		// Token: 0x040009EA RID: 2538
		private const int DECODE_HUFFMAN_DIST = 9;

		// Token: 0x040009EB RID: 2539
		private const int DECODE_HUFFMAN_DISTBITS = 10;

		// Token: 0x040009EC RID: 2540
		private const int DECODE_CHKSUM = 11;

		// Token: 0x040009ED RID: 2541
		private const int FINISHED = 12;

		// Token: 0x040009EE RID: 2542
		private static readonly int[] CPLENS = new int[]
		{
			3, 4, 5, 6, 7, 8, 9, 10, 11, 13,
			15, 17, 19, 23, 27, 31, 35, 43, 51, 59,
			67, 83, 99, 115, 131, 163, 195, 227, 258
		};

		// Token: 0x040009EF RID: 2543
		private static readonly int[] CPLEXT = new int[]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
			1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
			4, 4, 4, 4, 5, 5, 5, 5, 0
		};

		// Token: 0x040009F0 RID: 2544
		private static readonly int[] CPDIST = new int[]
		{
			1, 2, 3, 4, 5, 7, 9, 13, 17, 25,
			33, 49, 65, 97, 129, 193, 257, 385, 513, 769,
			1025, 1537, 2049, 3073, 4097, 6145, 8193, 12289, 16385, 24577
		};

		// Token: 0x040009F1 RID: 2545
		private static readonly int[] CPDEXT = new int[]
		{
			0, 0, 0, 0, 1, 1, 2, 2, 3, 3,
			4, 4, 5, 5, 6, 6, 7, 7, 8, 8,
			9, 9, 10, 10, 11, 11, 12, 12, 13, 13
		};

		// Token: 0x040009F2 RID: 2546
		private int mode;

		// Token: 0x040009F3 RID: 2547
		private int readAdler;

		// Token: 0x040009F4 RID: 2548
		private int neededBits;

		// Token: 0x040009F5 RID: 2549
		private int repLength;

		// Token: 0x040009F6 RID: 2550
		private int repDist;

		// Token: 0x040009F7 RID: 2551
		private int uncomprLen;

		// Token: 0x040009F8 RID: 2552
		private bool isLastBlock;

		// Token: 0x040009F9 RID: 2553
		private long totalOut;

		// Token: 0x040009FA RID: 2554
		private long totalIn;

		// Token: 0x040009FB RID: 2555
		private bool noHeader;

		// Token: 0x040009FC RID: 2556
		private StreamManipulator input;

		// Token: 0x040009FD RID: 2557
		private OutputWindow outputWindow;

		// Token: 0x040009FE RID: 2558
		private InflaterDynHeader dynHeader;

		// Token: 0x040009FF RID: 2559
		private InflaterHuffmanTree litlenTree;

		// Token: 0x04000A00 RID: 2560
		private InflaterHuffmanTree distTree;

		// Token: 0x04000A01 RID: 2561
		private Adler32 adler;
	}
}
