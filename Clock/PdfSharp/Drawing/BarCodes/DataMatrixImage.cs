using System;

namespace PdfSharp.Drawing.BarCodes
{
	// Token: 0x0200000F RID: 15
	internal class DataMatrixImage
	{
		// Token: 0x06000076 RID: 118 RVA: 0x0000411C File Offset: 0x0000231C
		public static XImage GenerateMatrixImage(string text, string encoding, int rows, int columns)
		{
			DataMatrixImage dataMatrixImage = new DataMatrixImage(text, encoding, rows, columns);
			return dataMatrixImage.DrawMatrix();
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00004139 File Offset: 0x00002339
		public DataMatrixImage(string text, string encoding, int rows, int columns)
		{
			this._text = text;
			this._encoding = encoding;
			this._rows = rows;
			this._columns = columns;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000415E File Offset: 0x0000235E
		public XImage DrawMatrix()
		{
			return this.CreateImage(this.DataMatrix(), this._rows, this._columns);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00004178 File Offset: 0x00002378
		internal char[] DataMatrix()
		{
			int columns = this._columns;
			int rows = this._rows;
			int num = 200;
			if (string.IsNullOrEmpty(this._encoding))
			{
				this._encoding = new string('a', this._text.Length);
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			if (columns != 0 && rows != 0 && (columns & 1) != 0 && (rows & 1) != 0 && num == 200)
			{
				throw new ArgumentException(BcgSR.DataMatrixNotSupported);
			}
			char[] array = this.Iec16022Ecc200(columns, rows, this._encoding, this._text.Length, this._text, num2, num3, num4);
			if (array == null || columns == 0)
			{
				throw new ArgumentException(BcgSR.DataMatrixNull);
			}
			return array;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00004228 File Offset: 0x00002428
		internal char[] Iec16022Ecc200(int columns, int rows, string encoding, int barcodeLength, string barcode, int len, int max, int ecc)
		{
			char[] array = new char[3000];
			DataMatrixImage.Ecc200Block ecc200Block = new DataMatrixImage.Ecc200Block(0, 0, 0, 0, 0, 0, 0);
			for (int i = 0; i < 3000; i++)
			{
				array[i] = '\0';
			}
			foreach (DataMatrixImage.Ecc200Block ecc200Block2 in DataMatrixImage.ecc200Sizes)
			{
				ecc200Block = ecc200Block2;
				if (ecc200Block.Width == columns && ecc200Block.Height == rows)
				{
					break;
				}
			}
			if (ecc200Block.Width == 0)
			{
				throw new ArgumentException(BcgSR.DataMatrixInvalid(columns, rows));
			}
			if (!this.Ecc200Encode(ref array, ecc200Block.Bytes, barcode, barcodeLength, encoding, ref len))
			{
				throw new ArgumentException(BcgSR.DataMatrixTooBig);
			}
			this.Ecc200(array, ecc200Block.Bytes, ecc200Block.DataBlock, ecc200Block.RSBlock);
			int num = columns - 2 * (columns / ecc200Block.CellWidth);
			int num2 = rows - 2 * (rows / ecc200Block.CellHeight);
			int[] array3 = new int[num * num2];
			this.Ecc200Placement(ref array3, num2, num);
			char[] array4 = new char[columns * rows];
			for (int k = 0; k < rows; k += ecc200Block.CellHeight)
			{
				for (int l = 0; l < columns; l++)
				{
					array4[k * columns + l] = '\u0001';
				}
				for (int l = 0; l < columns; l += 2)
				{
					array4[(k + ecc200Block.CellHeight - 1) * columns + l] = '\u0001';
				}
			}
			for (int l = 0; l < columns; l += ecc200Block.CellWidth)
			{
				for (int k = 0; k < rows; k++)
				{
					array4[k * columns + l] = '\u0001';
				}
				for (int k = 0; k < rows; k += 2)
				{
					array4[k * columns + l + ecc200Block.CellWidth - 1] = '\u0001';
				}
			}
			for (int k = 0; k < num2; k++)
			{
				for (int l = 0; l < num; l++)
				{
					int num3 = array3[(num2 - k - 1) * num + l];
					if (num3 == 1 || (num3 > 7 && ((int)array[(num3 >> 3) - 1] & (1 << (num3 & 7))) != 0))
					{
						array4[(1 + k + 2 * (k / (ecc200Block.CellHeight - 2))) * columns + 1 + l + 2 * (l / (ecc200Block.CellWidth - 2))] = '\u0001';
					}
				}
			}
			return array4;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00004464 File Offset: 0x00002664
		internal bool Ecc200Encode(ref char[] t, int targetLength, string s, int sourceLength, string encoding, ref int len)
		{
			char c = 'a';
			int i = 0;
			int num = 0;
			if (encoding.Length < sourceLength)
			{
				return false;
			}
			IL_595:
			while (num < sourceLength && i < targetLength)
			{
				if ((targetLength - i <= 1 && (c == 'c' || c == 't')) || (targetLength - i <= 2 && c == 'x'))
				{
					c = 'a';
				}
				char c2 = char.ToLower(encoding[num]);
				char c3 = c2;
				switch (c3)
				{
				case 'a':
					if (c != c2)
					{
						if (c == 'c' || c == 't' || c == 'x')
						{
							t[i++] = 'þ';
						}
						else
						{
							t[i++] = '|';
						}
					}
					c = 'a';
					if (sourceLength - num >= 2 && char.IsDigit(s[num]) && char.IsDigit(s[num + 1]))
					{
						t[i++] = (s[num] - '0') * '\n' + s[num + 1] - '0' + '\u0082';
						num += 2;
						continue;
					}
					if (s[num] > '\u007f')
					{
						t[i++] = 'ë';
						t[i++] = s[num++] - '\u007f';
						continue;
					}
					t[i++] = s[num++] + '\u0001';
					continue;
				case 'b':
				{
					int num2 = 0;
					if (encoding != null)
					{
						int num3 = num;
						while (num3 < sourceLength && char.ToLower(encoding[num3]) == 'b')
						{
							num2++;
							num3++;
						}
					}
					t[i++] = 'ç';
					if (num2 < 250)
					{
						t[i] = (char)this.State255(num2, i);
						i++;
					}
					else
					{
						t[i] = (char)this.State255(249 + num2 / 250, i);
						i++;
						t[i] = (char)this.State255(num2 % 250, i);
						i++;
					}
					while (num2-- != 0 && i < targetLength)
					{
						t[i] = (char)this.State255((int)s[num++], i);
						i++;
					}
					c = 'a';
					continue;
				}
				case 'c':
					break;
				case 'd':
					continue;
				case 'e':
				{
					char[] array = new char[4];
					char c4 = '\0';
					if (c != c2)
					{
						t[i++] = 'þ';
						c = 'a';
					}
					while (num < sourceLength && char.ToLower(encoding[num]) == 'e' && c4 < '\u0004')
					{
						char[] array2 = array;
						char c5 = c4;
						c4 = c5 + '\u0001';
						array2[(int)c5] = s[num++];
					}
					if (c4 < '\u0004')
					{
						char[] array3 = array;
						char c6 = c4;
						c4 = c6 + '\u0001';
						array3[(int)c6] = 31;
						c = 'a';
					}
					t[i] = (s[0] & '?') << 2;
					char[] array4 = t;
					int num4 = i++;
					array4[num4] |= (s[1] & '0') >> 4;
					t[i] = (s[1] & '\u000f') << 4;
					if (c4 == '\u0002')
					{
						i++;
						continue;
					}
					char[] array5 = t;
					int num5 = i++;
					array5[num5] |= (s[2] & '<') >> 2;
					t[i] = (s[2] & '\u0003') << 6;
					char[] array6 = t;
					int num6 = i++;
					array6[num6] |= s[3] & '?';
					continue;
				}
				default:
					if (c3 != 't' && c3 != 'x')
					{
						continue;
					}
					break;
				}
				char[] array7 = new char[6];
				char c7 = '\0';
				string text = null;
				string text2 = "!\"#$%&'()*+,-./:;<=>?@[\\]_";
				string text3 = null;
				if (c2 == 'c')
				{
					text = " 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
					text3 = "`abcdefghijklmnopqrstuvwxyz{|}~ｱ";
				}
				if (c2 == 't')
				{
					text = " 0123456789abcdefghijklmnopqrstuvwxyz";
					text3 = "`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~ｱ";
				}
				if (c2 == 'x')
				{
					text = " 0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ\r*>";
				}
				for (;;)
				{
					char c8 = s[num++];
					if ((c8 & '\u0080') != '\0')
					{
						if (c2 == 'x')
						{
							break;
						}
						c8 &= '\u007f';
						char[] array8 = array7;
						char c9 = c7;
						c7 = c9 + '\u0001';
						array8[(int)c9] = 1;
						char[] array9 = array7;
						char c10 = c7;
						c7 = c10 + '\u0001';
						array9[(int)c10] = 30;
					}
					char c11 = ((text.IndexOf(c8) == -1) ? '\0' : text[text.IndexOf(c8)]);
					if (c11 != '\0')
					{
						char[] array10 = array7;
						char c12 = c7;
						c7 = c12 + '\u0001';
						array10[(int)c12] = (ushort)((text.IndexOf(c11) + 3) % 40);
					}
					else
					{
						if (c2 == 'x')
						{
							return false;
						}
						if (c8 < ' ')
						{
							char[] array11 = array7;
							char c13 = c7;
							c7 = c13 + '\u0001';
							array11[(int)c13] = 0;
							char[] array12 = array7;
							char c14 = c7;
							c7 = c14 + '\u0001';
							array12[(int)c14] = c8;
						}
						else
						{
							c11 = ((text2.IndexOf(c8) == -1) ? '\0' : ((char)text2.IndexOf(c8)));
							if (c11 != '\0')
							{
								char[] array13 = array7;
								char c15 = c7;
								c7 = c15 + '\u0001';
								array13[(int)c15] = 1;
								char[] array14 = array7;
								char c16 = c7;
								c7 = c16 + '\u0001';
								array14[(int)c16] = c11;
							}
							else
							{
								c11 = ((text3.IndexOf(c8) == -1) ? '\0' : ((char)text3.IndexOf(c8)));
								if (c11 == '\0')
								{
									return false;
								}
								char[] array15 = array7;
								char c17 = c7;
								c7 = c17 + '\u0001';
								array15[(int)c17] = 2;
								char[] array16 = array7;
								char c18 = c7;
								c7 = c18 + '\u0001';
								array16[(int)c18] = c11;
							}
						}
					}
					if (c7 == '\u0002' && i + 2 == targetLength && num == sourceLength)
					{
						char[] array17 = array7;
						char c19 = c7;
						c7 = c19 + '\u0001';
						array17[(int)c19] = 0;
					}
					while (c7 >= '\u0003')
					{
						int num7 = (int)(array7[0] * 'ـ' + array7[1] * '(' + array7[2] + '\u0001');
						if (c != c2)
						{
							if (c == 'c' || c == 't' || c == 'x')
							{
								t[i++] = 'þ';
							}
							else if (c == 'x')
							{
								t[i++] = '|';
							}
							if (c2 == 'c')
							{
								t[i++] = 'æ';
							}
							if (c2 == 't')
							{
								t[i++] = 'ï';
							}
							if (c2 == 'x')
							{
								t[i++] = 'î';
							}
							c = c2;
						}
						t[i++] = (char)(num7 >> 8);
						t[i++] = (char)(num7 & 255);
						c7 -= '\u0003';
						array7[0] = array7[3];
						array7[1] = array7[4];
						array7[2] = array7[5];
					}
					if (c7 == '\0')
					{
						goto IL_595;
					}
					if (num >= sourceLength)
					{
						goto Block_32;
					}
				}
				return false;
				Block_32:;
			}
			if (len != 0)
			{
				len = i;
			}
			if (i < targetLength && c != 'a')
			{
				if (c == 'c' || c == 'x' || c == 't')
				{
					t[i++] = 'þ';
				}
				else
				{
					t[i++] = '|';
				}
			}
			if (i < targetLength)
			{
				t[i++] = '\u0081';
			}
			while (i < targetLength)
			{
				int num8 = 129 + (i + 1) * 149 % 253 + 1;
				if (num8 > 254)
				{
					num8 -= 254;
				}
				t[i++] = (char)num8;
			}
			return i <= targetLength && num >= sourceLength;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00004AA6 File Offset: 0x00002CA6
		private int State255(int value, int position)
		{
			return (value + (position + 1) * 149 % 255 + 1) % 256;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00004AC4 File Offset: 0x00002CC4
		private void Ecc200Placement(ref int[] array, int NR, int NC)
		{
			int i;
			int j;
			for (i = 0; i < NR; i++)
			{
				for (j = 0; j < NC; j++)
				{
					array[i * NC + j] = 0;
				}
			}
			int num = 1;
			i = 4;
			j = 0;
			do
			{
				if (i == NR && j == 0)
				{
					this.Ecc200PlacementCornerA(ref array, NR, NC, num++);
				}
				if (i == NR - 2 && j == 0 && NC % 4 != 0)
				{
					this.Ecc200PlacementCornerB(ref array, NR, NC, num++);
				}
				if (i == NR - 2 && j == 0 && NC % 8 == 4)
				{
					this.Ecc200PlacementCornerC(ref array, NR, NC, num++);
				}
				if (i == NR + 4 && j == 2 && NC % 8 == 0)
				{
					this.Ecc200PlacementCornerD(ref array, NR, NC, num++);
				}
				do
				{
					if (i < NR && j >= 0 && array[i * NC + j] == 0)
					{
						this.Ecc200PlacementBlock(ref array, NR, NC, i, j, num++);
					}
					i -= 2;
					j += 2;
				}
				while (i >= 0 && j < NC);
				i++;
				j += 3;
				do
				{
					if (i >= 0 && j < NC && array[i * NC + j] == 0)
					{
						this.Ecc200PlacementBlock(ref array, NR, NC, i, j, num++);
					}
					i += 2;
					j -= 2;
				}
				while (i < NR && j >= 0);
				i += 3;
				j++;
			}
			while (i < NR || j < NC);
			if (array[NR * NC - 1] == 0)
			{
				array[NR * NC - 1] = (array[NR * NC - NC - 2] = 1);
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00004C08 File Offset: 0x00002E08
		private void Ecc200PlacementBit(ref int[] array, int NR, int NC, int r, int c, int p, int b)
		{
			if (r < 0)
			{
				r += NR;
				c += 4 - (NR + 4) % 8;
			}
			if (c < 0)
			{
				c += NC;
				r += 4 - (NC + 4) % 8;
			}
			array[r * NC + c] = (p << 3) + b;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00004C54 File Offset: 0x00002E54
		private void Ecc200PlacementBlock(ref int[] array, int NR, int NC, int r, int c, int p)
		{
			this.Ecc200PlacementBit(ref array, NR, NC, r - 2, c - 2, p, 7);
			this.Ecc200PlacementBit(ref array, NR, NC, r - 2, c - 1, p, 6);
			this.Ecc200PlacementBit(ref array, NR, NC, r - 1, c - 2, p, 5);
			this.Ecc200PlacementBit(ref array, NR, NC, r - 1, c - 1, p, 4);
			this.Ecc200PlacementBit(ref array, NR, NC, r - 1, c, p, 3);
			this.Ecc200PlacementBit(ref array, NR, NC, r, c - 2, p, 2);
			this.Ecc200PlacementBit(ref array, NR, NC, r, c - 1, p, 1);
			this.Ecc200PlacementBit(ref array, NR, NC, r, c, p, 0);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00004CF8 File Offset: 0x00002EF8
		private void Ecc200PlacementCornerA(ref int[] array, int NR, int NC, int p)
		{
			this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, 0, p, 7);
			this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, 1, p, 6);
			this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, 2, p, 5);
			this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 2, p, 4);
			this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 1, p, 3);
			this.Ecc200PlacementBit(ref array, NR, NC, 1, NC - 1, p, 2);
			this.Ecc200PlacementBit(ref array, NR, NC, 2, NC - 1, p, 1);
			this.Ecc200PlacementBit(ref array, NR, NC, 3, NC - 1, p, 0);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00004D88 File Offset: 0x00002F88
		private void Ecc200PlacementCornerB(ref int[] array, int NR, int NC, int p)
		{
			this.Ecc200PlacementBit(ref array, NR, NC, NR - 3, 0, p, 7);
			this.Ecc200PlacementBit(ref array, NR, NC, NR - 2, 0, p, 6);
			this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, 0, p, 5);
			this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 4, p, 4);
			this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 3, p, 3);
			this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 2, p, 2);
			this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 1, p, 1);
			this.Ecc200PlacementBit(ref array, NR, NC, 1, NC - 1, p, 0);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00004E18 File Offset: 0x00003018
		private void Ecc200PlacementCornerC(ref int[] array, int NR, int NC, int p)
		{
			this.Ecc200PlacementBit(ref array, NR, NC, NR - 3, 0, p, 7);
			this.Ecc200PlacementBit(ref array, NR, NC, NR - 2, 0, p, 6);
			this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, 0, p, 5);
			this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 2, p, 4);
			this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 1, p, 3);
			this.Ecc200PlacementBit(ref array, NR, NC, 1, NC - 1, p, 2);
			this.Ecc200PlacementBit(ref array, NR, NC, 2, NC - 1, p, 1);
			this.Ecc200PlacementBit(ref array, NR, NC, 3, NC - 1, p, 0);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004EA8 File Offset: 0x000030A8
		private void Ecc200PlacementCornerD(ref int[] array, int NR, int NC, int p)
		{
			this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, 0, p, 7);
			this.Ecc200PlacementBit(ref array, NR, NC, NR - 1, NC - 1, p, 6);
			this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 3, p, 5);
			this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 2, p, 4);
			this.Ecc200PlacementBit(ref array, NR, NC, 0, NC - 1, p, 3);
			this.Ecc200PlacementBit(ref array, NR, NC, 1, NC - 3, p, 2);
			this.Ecc200PlacementBit(ref array, NR, NC, 1, NC - 2, p, 1);
			this.Ecc200PlacementBit(ref array, NR, NC, 1, NC - 1, p, 0);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00004F38 File Offset: 0x00003138
		private void Ecc200(char[] binary, int bytes, int datablock, int rsblock)
		{
			int num = (bytes + 2) / datablock;
			DataMatrixImage.InitGalois(301);
			DataMatrixImage.InitReedSolomon(rsblock, 1);
			for (int i = 0; i < num; i++)
			{
				int[] array = new int[256];
				int[] array2 = new int[256];
				int num2 = 0;
				for (int j = i; j < bytes; j += num)
				{
					array[num2++] = (int)binary[j];
				}
				this.EncodeReedSolomon(num2, array, ref array2);
				num2 = rsblock - 1;
				for (int j = i; j < rsblock * num; j += num)
				{
					binary[bytes + j] = (char)array2[num2--];
				}
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00004FD4 File Offset: 0x000031D4
		public static void InitGalois(int poly)
		{
			if (DataMatrixImage.log != null)
			{
				DataMatrixImage.log = null;
				DataMatrixImage.alog = null;
				DataMatrixImage.rspoly = null;
			}
			int i = 1;
			int num = 0;
			while (i <= poly)
			{
				num++;
				i <<= 1;
			}
			i >>= 1;
			num--;
			DataMatrixImage.gfpoly = poly;
			DataMatrixImage.symsize = num;
			DataMatrixImage.logmod = (1 << num) - 1;
			DataMatrixImage.log = new int[DataMatrixImage.logmod + 1];
			DataMatrixImage.alog = new int[DataMatrixImage.logmod];
			int num2 = 1;
			for (int j = 0; j < DataMatrixImage.logmod; j++)
			{
				DataMatrixImage.alog[j] = num2;
				DataMatrixImage.log[num2] = j;
				num2 <<= 1;
				if ((num2 & i) != 0)
				{
					num2 ^= poly;
				}
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000507C File Offset: 0x0000327C
		public static void InitReedSolomon(int nsym, int index)
		{
			if (DataMatrixImage.rspoly != null)
			{
				DataMatrixImage.rspoly = null;
			}
			DataMatrixImage.rspoly = new int[nsym + 1];
			DataMatrixImage.rlen = nsym;
			DataMatrixImage.rspoly[0] = 1;
			for (int i = 1; i <= nsym; i++)
			{
				DataMatrixImage.rspoly[i] = 1;
				for (int j = i - 1; j > 0; j--)
				{
					if (DataMatrixImage.rspoly[j] != 0)
					{
						DataMatrixImage.rspoly[j] = DataMatrixImage.alog[(DataMatrixImage.log[DataMatrixImage.rspoly[j]] + index) % DataMatrixImage.logmod];
					}
					DataMatrixImage.rspoly[j] ^= DataMatrixImage.rspoly[j - 1];
				}
				DataMatrixImage.rspoly[0] = DataMatrixImage.alog[(DataMatrixImage.log[DataMatrixImage.rspoly[0]] + index) % DataMatrixImage.logmod];
				index++;
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000514C File Offset: 0x0000334C
		public void EncodeReedSolomon(int length, int[] data, ref int[] result)
		{
			for (int i = 0; i < DataMatrixImage.rlen; i++)
			{
				result[i] = 0;
			}
			for (int i = 0; i < length; i++)
			{
				int num = result[DataMatrixImage.rlen - 1] ^ data[i];
				for (int j = DataMatrixImage.rlen - 1; j > 0; j--)
				{
					if (num != 0 && DataMatrixImage.rspoly[j] != 0)
					{
						result[j] = result[j - 1] ^ DataMatrixImage.alog[(DataMatrixImage.log[num] + DataMatrixImage.log[DataMatrixImage.rspoly[j]]) % DataMatrixImage.logmod];
					}
					else
					{
						result[j] = result[j - 1];
					}
				}
				if (num != 0 && DataMatrixImage.rspoly[0] != 0)
				{
					result[0] = DataMatrixImage.alog[(DataMatrixImage.log[num] + DataMatrixImage.log[DataMatrixImage.rspoly[0]]) % DataMatrixImage.logmod];
				}
				else
				{
					result[0] = 0;
				}
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000521D File Offset: 0x0000341D
		public XImage CreateImage(char[] code, int size)
		{
			return this.CreateImage(code, size, size, 10);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000522A File Offset: 0x0000342A
		public XImage CreateImage(char[] code, int rows, int columns)
		{
			return this.CreateImage(code, rows, columns, 10);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00005237 File Offset: 0x00003437
		public XImage CreateImage(char[] code, int rows, int columns, int pixelsize)
		{
			return null;
		}

		// Token: 0x0400002A RID: 42
		private string _encoding;

		// Token: 0x0400002B RID: 43
		private readonly string _text;

		// Token: 0x0400002C RID: 44
		private readonly int _rows;

		// Token: 0x0400002D RID: 45
		private readonly int _columns;

		// Token: 0x0400002E RID: 46
		private static DataMatrixImage.Ecc200Block[] ecc200Sizes = new DataMatrixImage.Ecc200Block[]
		{
			new DataMatrixImage.Ecc200Block(10, 10, 10, 10, 3, 3, 5),
			new DataMatrixImage.Ecc200Block(12, 12, 12, 12, 5, 5, 7),
			new DataMatrixImage.Ecc200Block(8, 18, 8, 18, 5, 5, 7),
			new DataMatrixImage.Ecc200Block(14, 14, 14, 14, 8, 8, 10),
			new DataMatrixImage.Ecc200Block(8, 32, 8, 16, 10, 10, 11),
			new DataMatrixImage.Ecc200Block(16, 16, 16, 16, 12, 12, 12),
			new DataMatrixImage.Ecc200Block(12, 26, 12, 26, 16, 16, 14),
			new DataMatrixImage.Ecc200Block(18, 18, 18, 18, 18, 18, 14),
			new DataMatrixImage.Ecc200Block(20, 20, 20, 20, 22, 22, 18),
			new DataMatrixImage.Ecc200Block(12, 36, 12, 18, 22, 22, 18),
			new DataMatrixImage.Ecc200Block(22, 22, 22, 22, 30, 30, 20),
			new DataMatrixImage.Ecc200Block(16, 36, 16, 18, 32, 32, 24),
			new DataMatrixImage.Ecc200Block(24, 24, 24, 24, 36, 36, 24),
			new DataMatrixImage.Ecc200Block(26, 26, 26, 26, 44, 44, 28),
			new DataMatrixImage.Ecc200Block(16, 48, 16, 24, 49, 49, 28),
			new DataMatrixImage.Ecc200Block(32, 32, 16, 16, 62, 62, 36),
			new DataMatrixImage.Ecc200Block(36, 36, 18, 18, 86, 86, 42),
			new DataMatrixImage.Ecc200Block(40, 40, 20, 20, 114, 114, 48),
			new DataMatrixImage.Ecc200Block(44, 44, 22, 22, 144, 144, 56),
			new DataMatrixImage.Ecc200Block(48, 48, 24, 24, 174, 174, 68),
			new DataMatrixImage.Ecc200Block(52, 52, 26, 26, 204, 102, 42),
			new DataMatrixImage.Ecc200Block(64, 64, 16, 16, 280, 140, 56),
			new DataMatrixImage.Ecc200Block(72, 72, 18, 18, 368, 92, 36),
			new DataMatrixImage.Ecc200Block(80, 80, 20, 20, 456, 114, 48),
			new DataMatrixImage.Ecc200Block(88, 88, 22, 22, 576, 144, 56),
			new DataMatrixImage.Ecc200Block(96, 96, 24, 24, 696, 174, 68),
			new DataMatrixImage.Ecc200Block(104, 104, 26, 26, 816, 136, 56),
			new DataMatrixImage.Ecc200Block(120, 120, 20, 20, 1050, 175, 68),
			new DataMatrixImage.Ecc200Block(132, 132, 22, 22, 1304, 163, 62),
			new DataMatrixImage.Ecc200Block(144, 144, 24, 24, 1558, 156, 62),
			new DataMatrixImage.Ecc200Block(0, 0, 0, 0, 0, 0, 0)
		};

		// Token: 0x0400002F RID: 47
		private static int gfpoly;

		// Token: 0x04000030 RID: 48
		private static int symsize;

		// Token: 0x04000031 RID: 49
		private static int logmod;

		// Token: 0x04000032 RID: 50
		private static int rlen;

		// Token: 0x04000033 RID: 51
		private static int[] log = null;

		// Token: 0x04000034 RID: 52
		private static int[] alog = null;

		// Token: 0x04000035 RID: 53
		private static int[] rspoly = null;

		// Token: 0x02000010 RID: 16
		private struct Ecc200Block
		{
			// Token: 0x0600008C RID: 140 RVA: 0x00005675 File Offset: 0x00003875
			public Ecc200Block(int h, int w, int ch, int cw, int bytes, int dataBlock, int rsBlock)
			{
				this.Height = h;
				this.Width = w;
				this.CellHeight = ch;
				this.CellWidth = cw;
				this.Bytes = bytes;
				this.DataBlock = dataBlock;
				this.RSBlock = rsBlock;
			}

			// Token: 0x04000036 RID: 54
			public readonly int Height;

			// Token: 0x04000037 RID: 55
			public readonly int Width;

			// Token: 0x04000038 RID: 56
			public readonly int CellHeight;

			// Token: 0x04000039 RID: 57
			public readonly int CellWidth;

			// Token: 0x0400003A RID: 58
			public readonly int Bytes;

			// Token: 0x0400003B RID: 59
			public readonly int DataBlock;

			// Token: 0x0400003C RID: 60
			public readonly int RSBlock;
		}
	}
}
