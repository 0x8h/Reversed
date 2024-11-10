using System;
using PdfSharp.SharpZipLib.Zip.Compression.Streams;

namespace PdfSharp.SharpZipLib.Zip.Compression
{
	// Token: 0x020001D5 RID: 469
	internal class InflaterDynHeader
	{
		// Token: 0x06000F89 RID: 3977 RVA: 0x0003DDA4 File Offset: 0x0003BFA4
		public bool Decode(StreamManipulator input)
		{
			for (;;)
			{
				switch (this.mode)
				{
				case 0:
					this.lnum = input.PeekBits(5);
					if (this.lnum < 0)
					{
						return false;
					}
					this.lnum += 257;
					input.DropBits(5);
					this.mode = 1;
					goto IL_61;
				case 1:
					goto IL_61;
				case 2:
					goto IL_B9;
				case 3:
					break;
				case 4:
					goto IL_1A8;
				case 5:
					goto IL_1EE;
				default:
					continue;
				}
				IL_13B:
				while (this.ptr < this.blnum)
				{
					int num = input.PeekBits(3);
					if (num < 0)
					{
						return false;
					}
					input.DropBits(3);
					this.blLens[InflaterDynHeader.BL_ORDER[this.ptr]] = (byte)num;
					this.ptr++;
				}
				this.blTree = new InflaterHuffmanTree(this.blLens);
				this.blLens = null;
				this.ptr = 0;
				this.mode = 4;
				IL_1A8:
				int symbol;
				while (((symbol = this.blTree.GetSymbol(input)) & -16) == 0)
				{
					this.litdistLens[this.ptr++] = (this.lastLen = (byte)symbol);
					if (this.ptr == this.num)
					{
						return true;
					}
				}
				if (symbol < 0)
				{
					return false;
				}
				if (symbol >= 17)
				{
					this.lastLen = 0;
				}
				else if (this.ptr == 0)
				{
					goto Block_10;
				}
				this.repSymbol = symbol - 16;
				this.mode = 5;
				IL_1EE:
				int num2 = InflaterDynHeader.repBits[this.repSymbol];
				int num3 = input.PeekBits(num2);
				if (num3 < 0)
				{
					return false;
				}
				input.DropBits(num2);
				num3 += InflaterDynHeader.repMin[this.repSymbol];
				if (this.ptr + num3 > this.num)
				{
					goto Block_12;
				}
				while (num3-- > 0)
				{
					this.litdistLens[this.ptr++] = this.lastLen;
				}
				if (this.ptr == this.num)
				{
					return true;
				}
				this.mode = 4;
				continue;
				IL_B9:
				this.blnum = input.PeekBits(4);
				if (this.blnum < 0)
				{
					return false;
				}
				this.blnum += 4;
				input.DropBits(4);
				this.blLens = new byte[19];
				this.ptr = 0;
				this.mode = 3;
				goto IL_13B;
				IL_61:
				this.dnum = input.PeekBits(5);
				if (this.dnum < 0)
				{
					return false;
				}
				this.dnum++;
				input.DropBits(5);
				this.num = this.lnum + this.dnum;
				this.litdistLens = new byte[this.num];
				this.mode = 2;
				goto IL_B9;
			}
			return false;
			Block_10:
			throw new SharpZipBaseException();
			Block_12:
			throw new SharpZipBaseException();
		}

		// Token: 0x06000F8A RID: 3978 RVA: 0x0003E02C File Offset: 0x0003C22C
		public InflaterHuffmanTree BuildLitLenTree()
		{
			byte[] array = new byte[this.lnum];
			Array.Copy(this.litdistLens, 0, array, 0, this.lnum);
			return new InflaterHuffmanTree(array);
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x0003E060 File Offset: 0x0003C260
		public InflaterHuffmanTree BuildDistTree()
		{
			byte[] array = new byte[this.dnum];
			Array.Copy(this.litdistLens, this.lnum, array, 0, this.dnum);
			return new InflaterHuffmanTree(array);
		}

		// Token: 0x04000A02 RID: 2562
		private const int LNUM = 0;

		// Token: 0x04000A03 RID: 2563
		private const int DNUM = 1;

		// Token: 0x04000A04 RID: 2564
		private const int BLNUM = 2;

		// Token: 0x04000A05 RID: 2565
		private const int BLLENS = 3;

		// Token: 0x04000A06 RID: 2566
		private const int LENS = 4;

		// Token: 0x04000A07 RID: 2567
		private const int REPS = 5;

		// Token: 0x04000A08 RID: 2568
		private static readonly int[] repMin = new int[] { 3, 3, 11 };

		// Token: 0x04000A09 RID: 2569
		private static readonly int[] repBits = new int[] { 2, 3, 7 };

		// Token: 0x04000A0A RID: 2570
		private byte[] blLens;

		// Token: 0x04000A0B RID: 2571
		private byte[] litdistLens;

		// Token: 0x04000A0C RID: 2572
		private InflaterHuffmanTree blTree;

		// Token: 0x04000A0D RID: 2573
		private int mode;

		// Token: 0x04000A0E RID: 2574
		private int lnum;

		// Token: 0x04000A0F RID: 2575
		private int dnum;

		// Token: 0x04000A10 RID: 2576
		private int blnum;

		// Token: 0x04000A11 RID: 2577
		private int num;

		// Token: 0x04000A12 RID: 2578
		private int repSymbol;

		// Token: 0x04000A13 RID: 2579
		private byte lastLen;

		// Token: 0x04000A14 RID: 2580
		private int ptr;

		// Token: 0x04000A15 RID: 2581
		private static readonly int[] BL_ORDER = new int[]
		{
			16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
			11, 4, 12, 3, 13, 2, 14, 1, 15
		};
	}
}
