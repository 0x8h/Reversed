using System;
using PdfSharp.SharpZipLib.Zip.Compression.Streams;

namespace PdfSharp.SharpZipLib.Zip.Compression
{
	// Token: 0x020001D6 RID: 470
	internal class InflaterHuffmanTree
	{
		// Token: 0x06000F8D RID: 3981 RVA: 0x0003E154 File Offset: 0x0003C354
		static InflaterHuffmanTree()
		{
			try
			{
				byte[] array = new byte[288];
				int i = 0;
				while (i < 144)
				{
					array[i++] = 8;
				}
				while (i < 256)
				{
					array[i++] = 9;
				}
				while (i < 280)
				{
					array[i++] = 7;
				}
				while (i < 288)
				{
					array[i++] = 8;
				}
				InflaterHuffmanTree.defLitLenTree = new InflaterHuffmanTree(array);
				array = new byte[32];
				i = 0;
				while (i < 32)
				{
					array[i++] = 5;
				}
				InflaterHuffmanTree.defDistTree = new InflaterHuffmanTree(array);
			}
			catch (Exception)
			{
				throw new SharpZipBaseException("InflaterHuffmanTree: static tree length illegal");
			}
		}

		// Token: 0x06000F8E RID: 3982 RVA: 0x0003E20C File Offset: 0x0003C40C
		public InflaterHuffmanTree(byte[] codeLengths)
		{
			this.BuildTree(codeLengths);
		}

		// Token: 0x06000F8F RID: 3983 RVA: 0x0003E21C File Offset: 0x0003C41C
		private void BuildTree(byte[] codeLengths)
		{
			int[] array = new int[InflaterHuffmanTree.MAX_BITLEN + 1];
			int[] array2 = new int[InflaterHuffmanTree.MAX_BITLEN + 1];
			foreach (int num in codeLengths)
			{
				if (num > 0)
				{
					array[num]++;
				}
			}
			int num2 = 0;
			int num3 = 512;
			for (int j = 1; j <= InflaterHuffmanTree.MAX_BITLEN; j++)
			{
				array2[j] = num2;
				num2 += array[j] << 16 - j;
				if (j >= 10)
				{
					int num4 = array2[j] & 130944;
					int num5 = num2 & 130944;
					num3 += num5 - num4 >> 16 - j;
				}
			}
			this.tree = new short[num3];
			int num6 = 512;
			for (int k = InflaterHuffmanTree.MAX_BITLEN; k >= 10; k--)
			{
				int num7 = num2 & 130944;
				num2 -= array[k] << 16 - k;
				int num8 = num2 & 130944;
				for (int l = num8; l < num7; l += 128)
				{
					this.tree[(int)DeflaterHuffman.BitReverse(l)] = (short)((-num6 << 4) | k);
					num6 += 1 << k - 9;
				}
			}
			for (int m = 0; m < codeLengths.Length; m++)
			{
				int num9 = (int)codeLengths[m];
				if (num9 != 0)
				{
					num2 = array2[num9];
					int num10 = (int)DeflaterHuffman.BitReverse(num2);
					if (num9 <= 9)
					{
						do
						{
							this.tree[num10] = (short)((m << 4) | num9);
							num10 += 1 << num9;
						}
						while (num10 < 512);
					}
					else
					{
						int num11 = (int)this.tree[num10 & 511];
						int num12 = 1 << (num11 & 15);
						num11 = -(num11 >> 4);
						do
						{
							this.tree[num11 | (num10 >> 9)] = (short)((m << 4) | num9);
							num10 += 1 << num9;
						}
						while (num10 < num12);
					}
					array2[num9] = num2 + (1 << 16 - num9);
				}
			}
		}

		// Token: 0x06000F90 RID: 3984 RVA: 0x0003E420 File Offset: 0x0003C620
		public int GetSymbol(StreamManipulator input)
		{
			int num;
			if ((num = input.PeekBits(9)) >= 0)
			{
				int num2;
				if ((num2 = (int)this.tree[num]) >= 0)
				{
					input.DropBits(num2 & 15);
					return num2 >> 4;
				}
				int num3 = -(num2 >> 4);
				int num4 = num2 & 15;
				if ((num = input.PeekBits(num4)) >= 0)
				{
					num2 = (int)this.tree[num3 | (num >> 9)];
					input.DropBits(num2 & 15);
					return num2 >> 4;
				}
				int availableBits = input.AvailableBits;
				num = input.PeekBits(availableBits);
				num2 = (int)this.tree[num3 | (num >> 9)];
				if ((num2 & 15) <= availableBits)
				{
					input.DropBits(num2 & 15);
					return num2 >> 4;
				}
				return -1;
			}
			else
			{
				int availableBits2 = input.AvailableBits;
				num = input.PeekBits(availableBits2);
				int num2 = (int)this.tree[num];
				if (num2 >= 0 && (num2 & 15) <= availableBits2)
				{
					input.DropBits(num2 & 15);
					return num2 >> 4;
				}
				return -1;
			}
		}

		// Token: 0x04000A16 RID: 2582
		private static int MAX_BITLEN = 15;

		// Token: 0x04000A17 RID: 2583
		private short[] tree;

		// Token: 0x04000A18 RID: 2584
		public static InflaterHuffmanTree defLitLenTree;

		// Token: 0x04000A19 RID: 2585
		public static InflaterHuffmanTree defDistTree;
	}
}
