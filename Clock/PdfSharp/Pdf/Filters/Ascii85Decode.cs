using System;

namespace PdfSharp.Pdf.Filters
{
	// Token: 0x0200015A RID: 346
	public class Ascii85Decode : Filter
	{
		// Token: 0x06000B87 RID: 2951 RVA: 0x0002D248 File Offset: 0x0002B448
		public override byte[] Encode(byte[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			int num = data.Length;
			int num2 = num / 4;
			int num3 = num - num2 * 4;
			byte[] array = new byte[num2 * 5 + ((num3 == 0) ? 0 : (num3 + 1)) + 2];
			int num4 = 0;
			int num5 = 0;
			for (int i = 0; i < num2; i++)
			{
				uint num6 = (uint)(((int)data[num4++] << 24) + ((int)data[num4++] << 16) + ((int)data[num4++] << 8) + (int)data[num4++]);
				if (num6 == 0U)
				{
					array[num5++] = 122;
				}
				else
				{
					byte b = (byte)(num6 % 85U + 33U);
					num6 /= 85U;
					byte b2 = (byte)(num6 % 85U + 33U);
					num6 /= 85U;
					byte b3 = (byte)(num6 % 85U + 33U);
					num6 /= 85U;
					byte b4 = (byte)(num6 % 85U + 33U);
					num6 /= 85U;
					byte b5 = (byte)(num6 + 33U);
					array[num5++] = b5;
					array[num5++] = b4;
					array[num5++] = b3;
					array[num5++] = b2;
					array[num5++] = b;
				}
			}
			if (num3 == 1)
			{
				uint num7 = (uint)((uint)data[num4] << 24);
				num7 /= 614125U;
				byte b6 = (byte)(num7 % 85U + 33U);
				num7 /= 85U;
				byte b7 = (byte)(num7 + 33U);
				array[num5++] = b7;
				array[num5++] = b6;
			}
			else if (num3 == 2)
			{
				uint num8 = (uint)(((int)data[num4++] << 24) + ((int)data[num4] << 16));
				num8 /= 7225U;
				byte b8 = (byte)(num8 % 85U + 33U);
				num8 /= 85U;
				byte b9 = (byte)(num8 % 85U + 33U);
				num8 /= 85U;
				byte b10 = (byte)(num8 + 33U);
				array[num5++] = b10;
				array[num5++] = b9;
				array[num5++] = b8;
			}
			else if (num3 == 3)
			{
				uint num9 = (uint)(((int)data[num4++] << 24) + ((int)data[num4++] << 16) + ((int)data[num4] << 8));
				num9 /= 85U;
				byte b11 = (byte)(num9 % 85U + 33U);
				num9 /= 85U;
				byte b12 = (byte)(num9 % 85U + 33U);
				num9 /= 85U;
				byte b13 = (byte)(num9 % 85U + 33U);
				num9 /= 85U;
				byte b14 = (byte)(num9 + 33U);
				array[num5++] = b14;
				array[num5++] = b13;
				array[num5++] = b12;
				array[num5++] = b11;
			}
			array[num5++] = 126;
			array[num5++] = 62;
			if (num5 < array.Length)
			{
				Array.Resize<byte>(ref array, num5);
			}
			return array;
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x0002D4F4 File Offset: 0x0002B6F4
		public override byte[] Decode(byte[] data, FilterParms parms)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			int num = data.Length;
			int num2 = 0;
			int num3 = 0;
			int i;
			for (i = 0; i < num; i++)
			{
				char c = (char)data[i];
				if (c >= '!' && c <= 'u')
				{
					data[num3++] = (byte)c;
				}
				else if (c == 'z')
				{
					data[num3++] = (byte)c;
					num2++;
				}
				else if (c == '~')
				{
					if (data[i + 1] != 62)
					{
						throw new ArgumentException("Illegal character.", "data");
					}
					break;
				}
			}
			if (i == num)
			{
				throw new ArgumentException("Illegal character.", "data");
			}
			num = num3;
			int num4 = num - num2;
			int num5 = 4 * (num2 + num4 / 5);
			int num6 = num4 % 5;
			if (num6 == 1)
			{
				throw new InvalidOperationException("Illegal character.");
			}
			if (num6 != 0)
			{
				num5 += num6 - 1;
			}
			byte[] array = new byte[num5];
			num3 = 0;
			i = 0;
			while (i + 4 < num)
			{
				char c2 = (char)data[i];
				if (c2 == 'z')
				{
					i++;
					num3 += 4;
				}
				else
				{
					long num7 = (long)(data[i++] - 33) * 52200625L + (long)((ulong)((int)(data[i++] - 33) * 614125)) + (long)((ulong)((int)(data[i++] - 33) * 7225)) + (long)((ulong)((data[i++] - 33) * 85)) + (long)((ulong)(data[i++] - 33));
					if (num7 > (long)((ulong)(-1)))
					{
						throw new InvalidOperationException("Value of group greater than 2 power 32 - 1.");
					}
					array[num3++] = (byte)(num7 >> 24);
					array[num3++] = (byte)(num7 >> 16);
					array[num3++] = (byte)(num7 >> 8);
					array[num3++] = (byte)num7;
				}
			}
			if (num6 == 2)
			{
				uint num8 = (uint)(data[i++] - 33) * 52200625U + (uint)(data[i] - 33) * 614125U;
				if (num8 != 0U)
				{
					num8 += 16777216U;
				}
				array[num3] = (byte)(num8 >> 24);
			}
			else if (num6 == 3)
			{
				int num9 = i;
				uint num10 = (uint)(data[i++] - 33) * 52200625U + (uint)(data[i++] - 33) * 614125U + (uint)(data[i] - 33) * 7225U;
				if (num10 != 0U)
				{
					num10 &= 4294901760U;
					uint num11 = num10 / 7225U;
					byte b = (byte)(num11 % 85U + 33U);
					num11 /= 85U;
					byte b2 = (byte)(num11 % 85U + 33U);
					num11 /= 85U;
					byte b3 = (byte)(num11 + 33U);
					if (b3 != data[num9] || b2 != data[num9 + 1] || b != data[num9 + 2])
					{
						num10 += 65536U;
					}
				}
				array[num3++] = (byte)(num10 >> 24);
				array[num3] = (byte)(num10 >> 16);
			}
			else if (num6 == 4)
			{
				int num12 = i;
				uint num13 = (uint)(data[i++] - 33) * 52200625U + (uint)(data[i++] - 33) * 614125U + (uint)(data[i++] - 33) * 7225U + (uint)((data[i] - 33) * 85);
				if (num13 != 0U)
				{
					num13 &= 4294967040U;
					uint num14 = num13 / 85U;
					byte b4 = (byte)(num14 % 85U + 33U);
					num14 /= 85U;
					byte b5 = (byte)(num14 % 85U + 33U);
					num14 /= 85U;
					byte b6 = (byte)(num14 % 85U + 33U);
					num14 /= 85U;
					byte b7 = (byte)(num14 + 33U);
					if (b7 != data[num12] || b6 != data[num12 + 1] || b5 != data[num12 + 2] || b4 != data[num12 + 3])
					{
						num13 += 256U;
					}
				}
				array[num3++] = (byte)(num13 >> 24);
				array[num3++] = (byte)(num13 >> 16);
				array[num3] = (byte)(num13 >> 8);
			}
			return array;
		}
	}
}
