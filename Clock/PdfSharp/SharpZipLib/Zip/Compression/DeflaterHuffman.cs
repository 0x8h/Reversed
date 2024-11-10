using System;

namespace PdfSharp.SharpZipLib.Zip.Compression
{
	// Token: 0x020001D0 RID: 464
	internal class DeflaterHuffman
	{
		// Token: 0x06000F4B RID: 3915 RVA: 0x0003BEE8 File Offset: 0x0003A0E8
		static DeflaterHuffman()
		{
			int i = 0;
			while (i < 144)
			{
				DeflaterHuffman.staticLCodes[i] = DeflaterHuffman.BitReverse(48 + i << 8);
				DeflaterHuffman.staticLLength[i++] = 8;
			}
			while (i < 256)
			{
				DeflaterHuffman.staticLCodes[i] = DeflaterHuffman.BitReverse(256 + i << 7);
				DeflaterHuffman.staticLLength[i++] = 9;
			}
			while (i < 280)
			{
				DeflaterHuffman.staticLCodes[i] = DeflaterHuffman.BitReverse(-256 + i << 9);
				DeflaterHuffman.staticLLength[i++] = 7;
			}
			while (i < 286)
			{
				DeflaterHuffman.staticLCodes[i] = DeflaterHuffman.BitReverse(-88 + i << 8);
				DeflaterHuffman.staticLLength[i++] = 8;
			}
			DeflaterHuffman.staticDCodes = new short[30];
			DeflaterHuffman.staticDLength = new byte[30];
			for (i = 0; i < 30; i++)
			{
				DeflaterHuffman.staticDCodes[i] = DeflaterHuffman.BitReverse(i << 11);
				DeflaterHuffman.staticDLength[i] = 5;
			}
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x0003C028 File Offset: 0x0003A228
		public DeflaterHuffman(DeflaterPending pending)
		{
			this.pending = pending;
			this.literalTree = new DeflaterHuffman.Tree(this, 286, 257, 15);
			this.distTree = new DeflaterHuffman.Tree(this, 30, 1, 15);
			this.blTree = new DeflaterHuffman.Tree(this, 19, 4, 7);
			this.d_buf = new short[16384];
			this.l_buf = new byte[16384];
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x0003C09B File Offset: 0x0003A29B
		public void Reset()
		{
			this.last_lit = 0;
			this.extra_bits = 0;
			this.literalTree.Reset();
			this.distTree.Reset();
			this.blTree.Reset();
		}

		// Token: 0x06000F4E RID: 3918 RVA: 0x0003C0CC File Offset: 0x0003A2CC
		public void SendAllTrees(int blTreeCodes)
		{
			this.blTree.BuildCodes();
			this.literalTree.BuildCodes();
			this.distTree.BuildCodes();
			this.pending.WriteBits(this.literalTree.numCodes - 257, 5);
			this.pending.WriteBits(this.distTree.numCodes - 1, 5);
			this.pending.WriteBits(blTreeCodes - 4, 4);
			for (int i = 0; i < blTreeCodes; i++)
			{
				this.pending.WriteBits((int)this.blTree.length[DeflaterHuffman.BL_ORDER[i]], 3);
			}
			this.literalTree.WriteTree(this.blTree);
			this.distTree.WriteTree(this.blTree);
		}

		// Token: 0x06000F4F RID: 3919 RVA: 0x0003C18C File Offset: 0x0003A38C
		public void CompressBlock()
		{
			for (int i = 0; i < this.last_lit; i++)
			{
				int num = (int)(this.l_buf[i] & byte.MaxValue);
				int num2 = (int)this.d_buf[i];
				if (num2-- != 0)
				{
					int num3 = DeflaterHuffman.Lcode(num);
					this.literalTree.WriteSymbol(num3);
					int num4 = (num3 - 261) / 4;
					if (num4 > 0 && num4 <= 5)
					{
						this.pending.WriteBits(num & ((1 << num4) - 1), num4);
					}
					int num5 = DeflaterHuffman.Dcode(num2);
					this.distTree.WriteSymbol(num5);
					num4 = num5 / 2 - 1;
					if (num4 > 0)
					{
						this.pending.WriteBits(num2 & ((1 << num4) - 1), num4);
					}
				}
				else
				{
					this.literalTree.WriteSymbol(num);
				}
			}
			this.literalTree.WriteSymbol(256);
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x0003C268 File Offset: 0x0003A468
		public void FlushStoredBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
		{
			this.pending.WriteBits(lastBlock ? 1 : 0, 3);
			this.pending.AlignToByte();
			this.pending.WriteShort(storedLength);
			this.pending.WriteShort(~storedLength);
			this.pending.WriteBlock(stored, storedOffset, storedLength);
			this.Reset();
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x0003C2C4 File Offset: 0x0003A4C4
		public void FlushBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
		{
			short[] freqs = this.literalTree.freqs;
			int num = 256;
			freqs[num] += 1;
			this.literalTree.BuildTree();
			this.distTree.BuildTree();
			this.literalTree.CalcBLFreq(this.blTree);
			this.distTree.CalcBLFreq(this.blTree);
			this.blTree.BuildTree();
			int num2 = 4;
			for (int i = 18; i > num2; i--)
			{
				if (this.blTree.length[DeflaterHuffman.BL_ORDER[i]] > 0)
				{
					num2 = i + 1;
				}
			}
			int num3 = 14 + num2 * 3 + this.blTree.GetEncodedLength() + this.literalTree.GetEncodedLength() + this.distTree.GetEncodedLength() + this.extra_bits;
			int num4 = this.extra_bits;
			for (int j = 0; j < 286; j++)
			{
				num4 += (int)(this.literalTree.freqs[j] * (short)DeflaterHuffman.staticLLength[j]);
			}
			for (int k = 0; k < 30; k++)
			{
				num4 += (int)(this.distTree.freqs[k] * (short)DeflaterHuffman.staticDLength[k]);
			}
			if (num3 >= num4)
			{
				num3 = num4;
			}
			if (storedOffset >= 0 && storedLength + 4 < num3 >> 3)
			{
				this.FlushStoredBlock(stored, storedOffset, storedLength, lastBlock);
				return;
			}
			if (num3 == num4)
			{
				this.pending.WriteBits(2 + (lastBlock ? 1 : 0), 3);
				this.literalTree.SetStaticCodes(DeflaterHuffman.staticLCodes, DeflaterHuffman.staticLLength);
				this.distTree.SetStaticCodes(DeflaterHuffman.staticDCodes, DeflaterHuffman.staticDLength);
				this.CompressBlock();
				this.Reset();
				return;
			}
			this.pending.WriteBits(4 + (lastBlock ? 1 : 0), 3);
			this.SendAllTrees(num2);
			this.CompressBlock();
			this.Reset();
		}

		// Token: 0x06000F52 RID: 3922 RVA: 0x0003C48A File Offset: 0x0003A68A
		public bool IsFull()
		{
			return this.last_lit >= 16384;
		}

		// Token: 0x06000F53 RID: 3923 RVA: 0x0003C49C File Offset: 0x0003A69C
		public bool TallyLit(int literal)
		{
			this.d_buf[this.last_lit] = 0;
			this.l_buf[this.last_lit++] = (byte)literal;
			short[] freqs = this.literalTree.freqs;
			freqs[literal] += 1;
			return this.IsFull();
		}

		// Token: 0x06000F54 RID: 3924 RVA: 0x0003C4F8 File Offset: 0x0003A6F8
		public bool TallyDist(int distance, int length)
		{
			this.d_buf[this.last_lit] = (short)distance;
			this.l_buf[this.last_lit++] = (byte)(length - 3);
			int num = DeflaterHuffman.Lcode(length - 3);
			short[] freqs = this.literalTree.freqs;
			int num2 = num;
			freqs[num2] += 1;
			if (num >= 265 && num < 285)
			{
				this.extra_bits += (num - 261) / 4;
			}
			int num3 = DeflaterHuffman.Dcode(distance - 1);
			short[] freqs2 = this.distTree.freqs;
			int num4 = num3;
			freqs2[num4] += 1;
			if (num3 >= 4)
			{
				this.extra_bits += num3 / 2 - 1;
			}
			return this.IsFull();
		}

		// Token: 0x06000F55 RID: 3925 RVA: 0x0003C5C2 File Offset: 0x0003A7C2
		public static short BitReverse(int toReverse)
		{
			return (short)(((int)DeflaterHuffman.bit4Reverse[toReverse & 15] << 12) | ((int)DeflaterHuffman.bit4Reverse[(toReverse >> 4) & 15] << 8) | ((int)DeflaterHuffman.bit4Reverse[(toReverse >> 8) & 15] << 4) | (int)DeflaterHuffman.bit4Reverse[toReverse >> 12]);
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x0003C5FC File Offset: 0x0003A7FC
		private static int Lcode(int length)
		{
			if (length == 255)
			{
				return 285;
			}
			int num = 257;
			while (length >= 8)
			{
				num += 4;
				length >>= 1;
			}
			return num + length;
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x0003C630 File Offset: 0x0003A830
		private static int Dcode(int distance)
		{
			int num = 0;
			while (distance >= 4)
			{
				num += 2;
				distance >>= 1;
			}
			return num + distance;
		}

		// Token: 0x040009BE RID: 2494
		private const int BUFSIZE = 16384;

		// Token: 0x040009BF RID: 2495
		private const int LITERAL_NUM = 286;

		// Token: 0x040009C0 RID: 2496
		private const int DIST_NUM = 30;

		// Token: 0x040009C1 RID: 2497
		private const int BITLEN_NUM = 19;

		// Token: 0x040009C2 RID: 2498
		private const int REP_3_6 = 16;

		// Token: 0x040009C3 RID: 2499
		private const int REP_3_10 = 17;

		// Token: 0x040009C4 RID: 2500
		private const int REP_11_138 = 18;

		// Token: 0x040009C5 RID: 2501
		private const int EOF_SYMBOL = 256;

		// Token: 0x040009C6 RID: 2502
		private static readonly int[] BL_ORDER = new int[]
		{
			16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
			11, 4, 12, 3, 13, 2, 14, 1, 15
		};

		// Token: 0x040009C7 RID: 2503
		private static readonly byte[] bit4Reverse = new byte[]
		{
			0, 8, 4, 12, 2, 10, 6, 14, 1, 9,
			5, 13, 3, 11, 7, 15
		};

		// Token: 0x040009C8 RID: 2504
		private static short[] staticLCodes = new short[286];

		// Token: 0x040009C9 RID: 2505
		private static byte[] staticLLength = new byte[286];

		// Token: 0x040009CA RID: 2506
		private static short[] staticDCodes;

		// Token: 0x040009CB RID: 2507
		private static byte[] staticDLength;

		// Token: 0x040009CC RID: 2508
		public DeflaterPending pending;

		// Token: 0x040009CD RID: 2509
		private DeflaterHuffman.Tree literalTree;

		// Token: 0x040009CE RID: 2510
		private DeflaterHuffman.Tree distTree;

		// Token: 0x040009CF RID: 2511
		private DeflaterHuffman.Tree blTree;

		// Token: 0x040009D0 RID: 2512
		private short[] d_buf;

		// Token: 0x040009D1 RID: 2513
		private byte[] l_buf;

		// Token: 0x040009D2 RID: 2514
		private int last_lit;

		// Token: 0x040009D3 RID: 2515
		private int extra_bits;

		// Token: 0x020001D1 RID: 465
		private class Tree
		{
			// Token: 0x06000F58 RID: 3928 RVA: 0x0003C651 File Offset: 0x0003A851
			public Tree(DeflaterHuffman dh, int elems, int minCodes, int maxLength)
			{
				this.dh = dh;
				this.minNumCodes = minCodes;
				this.maxLength = maxLength;
				this.freqs = new short[elems];
				this.bl_counts = new int[maxLength];
			}

			// Token: 0x06000F59 RID: 3929 RVA: 0x0003C688 File Offset: 0x0003A888
			public void Reset()
			{
				for (int i = 0; i < this.freqs.Length; i++)
				{
					this.freqs[i] = 0;
				}
				this.codes = null;
				this.length = null;
			}

			// Token: 0x06000F5A RID: 3930 RVA: 0x0003C6BF File Offset: 0x0003A8BF
			public void WriteSymbol(int code)
			{
				this.dh.pending.WriteBits((int)this.codes[code] & 65535, (int)this.length[code]);
			}

			// Token: 0x06000F5B RID: 3931 RVA: 0x0003C6E8 File Offset: 0x0003A8E8
			public void CheckEmpty()
			{
				bool flag = true;
				for (int i = 0; i < this.freqs.Length; i++)
				{
					if (this.freqs[i] != 0)
					{
						flag = false;
					}
				}
				if (!flag)
				{
					throw new SharpZipBaseException("!Empty");
				}
			}

			// Token: 0x06000F5C RID: 3932 RVA: 0x0003C724 File Offset: 0x0003A924
			public void SetStaticCodes(short[] staticCodes, byte[] staticLengths)
			{
				this.codes = staticCodes;
				this.length = staticLengths;
			}

			// Token: 0x06000F5D RID: 3933 RVA: 0x0003C734 File Offset: 0x0003A934
			public void BuildCodes()
			{
				int[] array = new int[this.maxLength];
				int num = 0;
				this.codes = new short[this.freqs.Length];
				for (int i = 0; i < this.maxLength; i++)
				{
					array[i] = num;
					num += this.bl_counts[i] << 15 - i;
				}
				for (int j = 0; j < this.numCodes; j++)
				{
					int num2 = (int)this.length[j];
					if (num2 > 0)
					{
						this.codes[j] = DeflaterHuffman.BitReverse(array[num2 - 1]);
						array[num2 - 1] += 1 << 16 - num2;
					}
				}
			}

			// Token: 0x06000F5E RID: 3934 RVA: 0x0003C7E0 File Offset: 0x0003A9E0
			public void BuildTree()
			{
				int num = this.freqs.Length;
				int[] array = new int[num];
				int i = 0;
				int num2 = 0;
				for (int j = 0; j < num; j++)
				{
					int num3 = (int)this.freqs[j];
					if (num3 != 0)
					{
						int num4 = i++;
						int num5;
						while (num4 > 0 && (int)this.freqs[array[num5 = (num4 - 1) / 2]] > num3)
						{
							array[num4] = array[num5];
							num4 = num5;
						}
						array[num4] = j;
						num2 = j;
					}
				}
				while (i < 2)
				{
					int num6 = ((num2 < 2) ? (++num2) : 0);
					array[i++] = num6;
				}
				this.numCodes = Math.Max(num2 + 1, this.minNumCodes);
				int num7 = i;
				int[] array2 = new int[4 * i - 2];
				int[] array3 = new int[2 * i - 1];
				int num8 = num7;
				for (int k = 0; k < i; k++)
				{
					int num9 = array[k];
					array2[2 * k] = num9;
					array2[2 * k + 1] = -1;
					array3[k] = (int)this.freqs[num9] << 8;
					array[k] = k;
				}
				do
				{
					int num10 = array[0];
					int num11 = array[--i];
					int num12 = 0;
					int l;
					for (l = 1; l < i; l = l * 2 + 1)
					{
						if (l + 1 < i && array3[array[l]] > array3[array[l + 1]])
						{
							l++;
						}
						array[num12] = array[l];
						num12 = l;
					}
					int num13 = array3[num11];
					while ((l = num12) > 0 && array3[array[num12 = (l - 1) / 2]] > num13)
					{
						array[l] = array[num12];
					}
					array[l] = num11;
					int num14 = array[0];
					num11 = num8++;
					array2[2 * num11] = num10;
					array2[2 * num11 + 1] = num14;
					int num15 = Math.Min(array3[num10] & 255, array3[num14] & 255);
					num13 = (array3[num11] = array3[num10] + array3[num14] - num15 + 1);
					num12 = 0;
					for (l = 1; l < i; l = num12 * 2 + 1)
					{
						if (l + 1 < i && array3[array[l]] > array3[array[l + 1]])
						{
							l++;
						}
						array[num12] = array[l];
						num12 = l;
					}
					while ((l = num12) > 0 && array3[array[num12 = (l - 1) / 2]] > num13)
					{
						array[l] = array[num12];
					}
					array[l] = num11;
				}
				while (i > 1);
				if (array[0] != array2.Length / 2 - 1)
				{
					throw new SharpZipBaseException("Heap invariant violated");
				}
				this.BuildLength(array2);
			}

			// Token: 0x06000F5F RID: 3935 RVA: 0x0003CA50 File Offset: 0x0003AC50
			public int GetEncodedLength()
			{
				int num = 0;
				for (int i = 0; i < this.freqs.Length; i++)
				{
					num += (int)(this.freqs[i] * (short)this.length[i]);
				}
				return num;
			}

			// Token: 0x06000F60 RID: 3936 RVA: 0x0003CA88 File Offset: 0x0003AC88
			public void CalcBLFreq(DeflaterHuffman.Tree blTree)
			{
				int num = -1;
				int i = 0;
				while (i < this.numCodes)
				{
					int num2 = 1;
					int num3 = (int)this.length[i];
					int num4;
					int num5;
					if (num3 == 0)
					{
						num4 = 138;
						num5 = 3;
					}
					else
					{
						num4 = 6;
						num5 = 3;
						if (num != num3)
						{
							short[] array = blTree.freqs;
							int num6 = num3;
							array[num6] += 1;
							num2 = 0;
						}
					}
					num = num3;
					i++;
					while (i < this.numCodes && num == (int)this.length[i])
					{
						i++;
						if (++num2 >= num4)
						{
							break;
						}
					}
					if (num2 < num5)
					{
						short[] array2 = blTree.freqs;
						int num7 = num;
						array2[num7] += (short)num2;
					}
					else if (num != 0)
					{
						short[] array3 = blTree.freqs;
						int num8 = 16;
						array3[num8] += 1;
					}
					else if (num2 <= 10)
					{
						short[] array4 = blTree.freqs;
						int num9 = 17;
						array4[num9] += 1;
					}
					else
					{
						short[] array5 = blTree.freqs;
						int num10 = 18;
						array5[num10] += 1;
					}
				}
			}

			// Token: 0x06000F61 RID: 3937 RVA: 0x0003CB9C File Offset: 0x0003AD9C
			public void WriteTree(DeflaterHuffman.Tree blTree)
			{
				int num = -1;
				int i = 0;
				while (i < this.numCodes)
				{
					int num2 = 1;
					int num3 = (int)this.length[i];
					int num4;
					int num5;
					if (num3 == 0)
					{
						num4 = 138;
						num5 = 3;
					}
					else
					{
						num4 = 6;
						num5 = 3;
						if (num != num3)
						{
							blTree.WriteSymbol(num3);
							num2 = 0;
						}
					}
					num = num3;
					i++;
					while (i < this.numCodes && num == (int)this.length[i])
					{
						i++;
						if (++num2 >= num4)
						{
							break;
						}
					}
					if (num2 < num5)
					{
						while (num2-- > 0)
						{
							blTree.WriteSymbol(num);
						}
					}
					else if (num != 0)
					{
						blTree.WriteSymbol(16);
						this.dh.pending.WriteBits(num2 - 3, 2);
					}
					else if (num2 <= 10)
					{
						blTree.WriteSymbol(17);
						this.dh.pending.WriteBits(num2 - 3, 3);
					}
					else
					{
						blTree.WriteSymbol(18);
						this.dh.pending.WriteBits(num2 - 11, 7);
					}
				}
			}

			// Token: 0x06000F62 RID: 3938 RVA: 0x0003CC98 File Offset: 0x0003AE98
			private void BuildLength(int[] childs)
			{
				this.length = new byte[this.freqs.Length];
				int num = childs.Length / 2;
				int num2 = (num + 1) / 2;
				int num3 = 0;
				for (int i = 0; i < this.maxLength; i++)
				{
					this.bl_counts[i] = 0;
				}
				int[] array = new int[num];
				array[num - 1] = 0;
				for (int j = num - 1; j >= 0; j--)
				{
					if (childs[2 * j + 1] != -1)
					{
						int num4 = array[j] + 1;
						if (num4 > this.maxLength)
						{
							num4 = this.maxLength;
							num3++;
						}
						array[childs[2 * j]] = (array[childs[2 * j + 1]] = num4);
					}
					else
					{
						int num5 = array[j];
						this.bl_counts[num5 - 1]++;
						this.length[childs[2 * j]] = (byte)array[j];
					}
				}
				if (num3 == 0)
				{
					return;
				}
				int num6 = this.maxLength - 1;
				for (;;)
				{
					if (this.bl_counts[--num6] != 0)
					{
						do
						{
							this.bl_counts[num6]--;
							this.bl_counts[++num6]++;
							num3 -= 1 << this.maxLength - 1 - num6;
						}
						while (num3 > 0 && num6 < this.maxLength - 1);
						if (num3 <= 0)
						{
							break;
						}
					}
				}
				this.bl_counts[this.maxLength - 1] += num3;
				this.bl_counts[this.maxLength - 2] -= num3;
				int num7 = 2 * num2;
				for (int num8 = this.maxLength; num8 != 0; num8--)
				{
					int k = this.bl_counts[num8 - 1];
					while (k > 0)
					{
						int num9 = 2 * childs[num7++];
						if (childs[num9 + 1] == -1)
						{
							this.length[childs[num9]] = (byte)num8;
							k--;
						}
					}
				}
			}

			// Token: 0x040009D4 RID: 2516
			public short[] freqs;

			// Token: 0x040009D5 RID: 2517
			public byte[] length;

			// Token: 0x040009D6 RID: 2518
			public int minNumCodes;

			// Token: 0x040009D7 RID: 2519
			public int numCodes;

			// Token: 0x040009D8 RID: 2520
			private short[] codes;

			// Token: 0x040009D9 RID: 2521
			private int[] bl_counts;

			// Token: 0x040009DA RID: 2522
			private int maxLength;

			// Token: 0x040009DB RID: 2523
			private DeflaterHuffman dh;
		}
	}
}
