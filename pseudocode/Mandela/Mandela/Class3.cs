using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

// Token: 0x0200001C RID: 28
internal class Class3
{
	// Token: 0x06000063 RID: 99 RVA: 0x00006C8C File Offset: 0x00004E8C
	static Class3()
	{
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	// Token: 0x06000064 RID: 100 RVA: 0x000025A8 File Offset: 0x000007A8
	private void method_0()
	{
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00006E08 File Offset: 0x00005008
	internal static byte[] smethod_0(object object_3)
	{
		uint[] array = new uint[16];
		uint num = (uint)((448 - object_3.Length * 8 % 512 + 512) % 512);
		if (num == 0U)
		{
			num = 512U;
		}
		uint num2 = (uint)((long)object_3.Length + (long)((ulong)(num / 8U)) + 8L);
		ulong num3 = (ulong)((long)object_3.Length * 8L);
		byte[] array2 = new byte[num2];
		for (int i = 0; i < object_3.Length; i++)
		{
			array2[i] = object_3[i];
		}
		byte[] array3 = array2;
		int num4 = object_3.Length;
		array3[num4] |= 128;
		for (int j = 8; j > 0; j--)
		{
			array2[(int)(checked((IntPtr)(unchecked((ulong)num2 - (ulong)((long)j)))))] = (byte)((num3 >> (8 - j) * 8) & 255UL);
		}
		uint num5 = (uint)(array2.Length * 8 / 32);
		uint num6 = 1732584193U;
		uint num7 = 4023233417U;
		uint num8 = 2562383102U;
		uint num9 = 271733878U;
		for (uint num10 = 0U; num10 < num5 / 16U; num10 += 1U)
		{
			uint num11 = num10 << 6;
			for (uint num12 = 0U; num12 < 61U; num12 += 4U)
			{
				array[(int)(num12 >> 2)] = (uint)(((int)array2[(int)(num11 + (num12 + 3U))] << 24) | ((int)array2[(int)(num11 + (num12 + 2U))] << 16) | ((int)array2[(int)(num11 + (num12 + 1U))] << 8) | (int)array2[(int)(num11 + num12)]);
			}
			uint num13 = num6;
			uint num14 = num7;
			uint num15 = num8;
			uint num16 = num9;
			Class3.smethod_1(ref num6, num7, num8, num9, 0U, 7, 1U, array);
			Class3.smethod_1(ref num9, num6, num7, num8, 1U, 12, 2U, array);
			Class3.smethod_1(ref num8, num9, num6, num7, 2U, 17, 3U, array);
			Class3.smethod_1(ref num7, num8, num9, num6, 3U, 22, 4U, array);
			Class3.smethod_1(ref num6, num7, num8, num9, 4U, 7, 5U, array);
			Class3.smethod_1(ref num9, num6, num7, num8, 5U, 12, 6U, array);
			Class3.smethod_1(ref num8, num9, num6, num7, 6U, 17, 7U, array);
			Class3.smethod_1(ref num7, num8, num9, num6, 7U, 22, 8U, array);
			Class3.smethod_1(ref num6, num7, num8, num9, 8U, 7, 9U, array);
			Class3.smethod_1(ref num9, num6, num7, num8, 9U, 12, 10U, array);
			Class3.smethod_1(ref num8, num9, num6, num7, 10U, 17, 11U, array);
			Class3.smethod_1(ref num7, num8, num9, num6, 11U, 22, 12U, array);
			Class3.smethod_1(ref num6, num7, num8, num9, 12U, 7, 13U, array);
			Class3.smethod_1(ref num9, num6, num7, num8, 13U, 12, 14U, array);
			Class3.smethod_1(ref num8, num9, num6, num7, 14U, 17, 15U, array);
			Class3.smethod_1(ref num7, num8, num9, num6, 15U, 22, 16U, array);
			Class3.smethod_2(ref num6, num7, num8, num9, 1U, 5, 17U, array);
			Class3.smethod_2(ref num9, num6, num7, num8, 6U, 9, 18U, array);
			Class3.smethod_2(ref num8, num9, num6, num7, 11U, 14, 19U, array);
			Class3.smethod_2(ref num7, num8, num9, num6, 0U, 20, 20U, array);
			Class3.smethod_2(ref num6, num7, num8, num9, 5U, 5, 21U, array);
			Class3.smethod_2(ref num9, num6, num7, num8, 10U, 9, 22U, array);
			Class3.smethod_2(ref num8, num9, num6, num7, 15U, 14, 23U, array);
			Class3.smethod_2(ref num7, num8, num9, num6, 4U, 20, 24U, array);
			Class3.smethod_2(ref num6, num7, num8, num9, 9U, 5, 25U, array);
			Class3.smethod_2(ref num9, num6, num7, num8, 14U, 9, 26U, array);
			Class3.smethod_2(ref num8, num9, num6, num7, 3U, 14, 27U, array);
			Class3.smethod_2(ref num7, num8, num9, num6, 8U, 20, 28U, array);
			Class3.smethod_2(ref num6, num7, num8, num9, 13U, 5, 29U, array);
			Class3.smethod_2(ref num9, num6, num7, num8, 2U, 9, 30U, array);
			Class3.smethod_2(ref num8, num9, num6, num7, 7U, 14, 31U, array);
			Class3.smethod_2(ref num7, num8, num9, num6, 12U, 20, 32U, array);
			Class3.smethod_3(ref num6, num7, num8, num9, 5U, 4, 33U, array);
			Class3.smethod_3(ref num9, num6, num7, num8, 8U, 11, 34U, array);
			Class3.smethod_3(ref num8, num9, num6, num7, 11U, 16, 35U, array);
			Class3.smethod_3(ref num7, num8, num9, num6, 14U, 23, 36U, array);
			Class3.smethod_3(ref num6, num7, num8, num9, 1U, 4, 37U, array);
			Class3.smethod_3(ref num9, num6, num7, num8, 4U, 11, 38U, array);
			Class3.smethod_3(ref num8, num9, num6, num7, 7U, 16, 39U, array);
			Class3.smethod_3(ref num7, num8, num9, num6, 10U, 23, 40U, array);
			Class3.smethod_3(ref num6, num7, num8, num9, 13U, 4, 41U, array);
			Class3.smethod_3(ref num9, num6, num7, num8, 0U, 11, 42U, array);
			Class3.smethod_3(ref num8, num9, num6, num7, 3U, 16, 43U, array);
			Class3.smethod_3(ref num7, num8, num9, num6, 6U, 23, 44U, array);
			Class3.smethod_3(ref num6, num7, num8, num9, 9U, 4, 45U, array);
			Class3.smethod_3(ref num9, num6, num7, num8, 12U, 11, 46U, array);
			Class3.smethod_3(ref num8, num9, num6, num7, 15U, 16, 47U, array);
			Class3.smethod_3(ref num7, num8, num9, num6, 2U, 23, 48U, array);
			Class3.smethod_4(ref num6, num7, num8, num9, 0U, 6, 49U, array);
			Class3.smethod_4(ref num9, num6, num7, num8, 7U, 10, 50U, array);
			Class3.smethod_4(ref num8, num9, num6, num7, 14U, 15, 51U, array);
			Class3.smethod_4(ref num7, num8, num9, num6, 5U, 21, 52U, array);
			Class3.smethod_4(ref num6, num7, num8, num9, 12U, 6, 53U, array);
			Class3.smethod_4(ref num9, num6, num7, num8, 3U, 10, 54U, array);
			Class3.smethod_4(ref num8, num9, num6, num7, 10U, 15, 55U, array);
			Class3.smethod_4(ref num7, num8, num9, num6, 1U, 21, 56U, array);
			Class3.smethod_4(ref num6, num7, num8, num9, 8U, 6, 57U, array);
			Class3.smethod_4(ref num9, num6, num7, num8, 15U, 10, 58U, array);
			Class3.smethod_4(ref num8, num9, num6, num7, 6U, 15, 59U, array);
			Class3.smethod_4(ref num7, num8, num9, num6, 13U, 21, 60U, array);
			Class3.smethod_4(ref num6, num7, num8, num9, 4U, 6, 61U, array);
			Class3.smethod_4(ref num9, num6, num7, num8, 11U, 10, 62U, array);
			Class3.smethod_4(ref num8, num9, num6, num7, 2U, 15, 63U, array);
			Class3.smethod_4(ref num7, num8, num9, num6, 9U, 21, 64U, array);
			num6 += num13;
			num7 += num14;
			num8 += num15;
			num9 += num16;
		}
		byte[] array4 = new byte[16];
		Array.Copy(BitConverter.GetBytes(num6), 0, array4, 0, 4);
		Array.Copy(BitConverter.GetBytes(num7), 0, array4, 4, 4);
		Array.Copy(BitConverter.GetBytes(num8), 0, array4, 8, 4);
		Array.Copy(BitConverter.GetBytes(num9), 0, array4, 12, 4);
		return array4;
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00002711 File Offset: 0x00000911
	private static void smethod_1(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_3)
	{
		uint_1 = uint_2 + Class3.smethod_5(uint_1 + ((uint_2 & uint_3) | (~uint_2 & uint_4)) + object_3[(int)uint_5] + Class3.uint_0[(int)(uint_6 - 1U)], ushort_0);
	}

	// Token: 0x06000067 RID: 103 RVA: 0x0000273A File Offset: 0x0000093A
	private static void smethod_2(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_3)
	{
		uint_1 = uint_2 + Class3.smethod_5(uint_1 + ((uint_2 & uint_4) | (uint_3 & ~uint_4)) + object_3[(int)uint_5] + Class3.uint_0[(int)(uint_6 - 1U)], ushort_0);
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00002763 File Offset: 0x00000963
	private static void smethod_3(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_3)
	{
		uint_1 = uint_2 + Class3.smethod_5(uint_1 + (uint_2 ^ uint_3 ^ uint_4) + object_3[(int)uint_5] + Class3.uint_0[(int)(uint_6 - 1U)], ushort_0);
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00002789 File Offset: 0x00000989
	private static void smethod_4(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_3)
	{
		uint_1 = uint_2 + Class3.smethod_5(uint_1 + (uint_3 ^ (uint_2 | ~uint_4)) + object_3[(int)uint_5] + Class3.uint_0[(int)(uint_6 - 1U)], ushort_0);
	}

	// Token: 0x0600006A RID: 106 RVA: 0x000027B0 File Offset: 0x000009B0
	private static uint smethod_5(uint uint_1, ushort ushort_0)
	{
		return (uint_1 >> (int)(32 - ushort_0)) | (uint_1 << (int)ushort_0);
	}

	// Token: 0x0600006B RID: 107 RVA: 0x000027C2 File Offset: 0x000009C2
	internal static bool smethod_6()
	{
		if (!Class3.bool_3)
		{
			Class3.smethod_8();
			Class3.bool_3 = true;
		}
		return Class3.bool_5;
	}

	// Token: 0x0600006C RID: 108 RVA: 0x000027DB File Offset: 0x000009DB
	internal Class3()
	{
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00007468 File Offset: 0x00005668
	private void method_1(byte[] byte_2, byte[] byte_3, byte[] byte_4)
	{
		int num = byte_4.Length % 4;
		int num2 = byte_4.Length / 4;
		byte[] array = new byte[byte_4.Length];
		int num3 = byte_2.Length / 4;
		uint num4 = 0U;
		if (num > 0)
		{
			num2++;
		}
		for (int i = 0; i < num2; i++)
		{
			int num5 = i % num3;
			int num6 = i * 4;
			uint num7 = (uint)(num5 * 4);
			uint num8 = (uint)(((int)byte_2[(int)(num7 + 3U)] << 24) | ((int)byte_2[(int)(num7 + 2U)] << 16) | ((int)byte_2[(int)(num7 + 1U)] << 8) | (int)byte_2[(int)num7]);
			uint num9 = 255U;
			int num10 = 0;
			uint num11;
			if (i == num2 - 1 && num > 0)
			{
				num11 = 0U;
				num4 += num8;
				for (int j = 0; j < num; j++)
				{
					if (j > 0)
					{
						num11 <<= 8;
					}
					num11 |= (uint)byte_4[byte_4.Length - (1 + j)];
				}
			}
			else
			{
				num4 += num8;
				num7 = (uint)num6;
				num11 = (uint)(((int)byte_4[(int)(num7 + 3U)] << 24) | ((int)byte_4[(int)(num7 + 2U)] << 16) | ((int)byte_4[(int)(num7 + 1U)] << 8) | (int)byte_4[(int)num7]);
			}
			uint num13;
			uint num12 = (num13 = num4);
			uint num14 = 1621803678U;
			uint num15 = 2371254347U ^ num13;
			uint num16 = num15 & 1431655765U;
			num15 &= 2863311530U;
			uint num17 = (num15 >> 1) | (num16 << 1);
			uint num18 = 1987112382U - num13;
			if (num13 == 0U)
			{
				num13 -= 1U;
			}
			uint num19 = num17 / num13 + num13;
			num13 = num17 - num17 - num19 + num17;
			uint num20 = num17 + num17 - num17;
			if (num14 == 0U)
			{
				num14 -= 1U;
			}
			num19 = num17 / num14 + num14;
			num14 = num17 - num17 - num19 + num17;
			num13 ^= num13 << 22;
			num13 += num13;
			num13 ^= num13 >> 5;
			num13 += num20;
			num13 ^= num13 << 3;
			num13 += num14;
			num13 = (((num18 << 18) - num18) ^ num13) + num13;
			num4 = num12 + (uint)num13;
			if (i == num2 - 1 && num > 0)
			{
				uint num21 = num4 ^ num11;
				for (int k = 0; k < num; k++)
				{
					if (k > 0)
					{
						num9 <<= 8;
						num10 += 8;
					}
					array[num6 + k] = (byte)((num21 & num9) >> num10);
				}
			}
			else
			{
				uint num22 = num4 ^ num11;
				array[num6] = (byte)(num22 & 255U);
				array[num6 + 1] = (byte)((num22 & 65280U) >> 8);
				array[num6 + 2] = (byte)((num22 & 16711680U) >> 16);
				array[num6 + 3] = (byte)((num22 & 4278190080U) >> 24);
			}
		}
		Class3.byte_1 = array;
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00007790 File Offset: 0x00005990
	internal static SymmetricAlgorithm smethod_7()
	{
		SymmetricAlgorithm symmetricAlgorithm = null;
		if (Class3.smethod_6())
		{
			symmetricAlgorithm = new AesCryptoServiceProvider();
		}
		else
		{
			try
			{
				symmetricAlgorithm = new RijndaelManaged();
			}
			catch
			{
				try
				{
					symmetricAlgorithm = (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
				}
				catch
				{
					symmetricAlgorithm = (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
				}
			}
		}
		return symmetricAlgorithm;
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00007810 File Offset: 0x00005A10
	internal static void smethod_8()
	{
		try
		{
			new MD5CryptoServiceProvider();
		}
		catch
		{
			Class3.bool_5 = true;
			return;
		}
		try
		{
			Class3.bool_5 = CryptoConfig.AllowOnlyFipsAlgorithms;
		}
		catch
		{
		}
	}

	// Token: 0x06000070 RID: 112 RVA: 0x000027E3 File Offset: 0x000009E3
	internal static byte[] smethod_9(byte[] byte_2)
	{
		if (!Class3.smethod_6())
		{
			return new MD5CryptoServiceProvider().ComputeHash(byte_2);
		}
		return Class3.smethod_0(byte_2);
	}

	// Token: 0x06000071 RID: 113 RVA: 0x0000785C File Offset: 0x00005A5C
	internal static void smethod_10(HashAlgorithm hashAlgorithm_0, Stream stream_0, uint uint_1, byte[] byte_2)
	{
		while (uint_1 > 0U)
		{
			int num = ((uint_1 > (uint)byte_2.Length) ? byte_2.Length : ((int)uint_1));
			stream_0.Read(byte_2, 0, num);
			Class3.smethod_11(hashAlgorithm_0, byte_2, 0, num);
			uint_1 -= (uint)num;
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x000027FE File Offset: 0x000009FE
	internal static void smethod_11(HashAlgorithm hashAlgorithm_0, byte[] byte_2, int int_5, int int_6)
	{
		hashAlgorithm_0.TransformBlock(byte_2, int_5, int_6, byte_2, int_5);
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00007898 File Offset: 0x00005A98
	internal static uint tKmeHdnHeI(uint uint_1, int int_5, long long_2, BinaryReader binaryReader_0)
	{
		for (int i = 0; i < int_5; i++)
		{
			binaryReader_0.BaseStream.Position = long_2 + (long)(i * 40 + 8);
			uint num = binaryReader_0.ReadUInt32();
			uint num2 = binaryReader_0.ReadUInt32();
			binaryReader_0.ReadUInt32();
			uint num3 = binaryReader_0.ReadUInt32();
			if (num2 <= uint_1 && uint_1 < num2 + num)
			{
				return num3 + uint_1 - num2;
			}
		}
		return 0U;
	}

	// Token: 0x06000074 RID: 116 RVA: 0x000078F4 File Offset: 0x00005AF4
	private static void smethod_12(Stream stream_0, int int_5)
	{
		Class3.Class6 @class = new Class3.Class6(stream_0);
		@class.method_0().Position = 0L;
		byte[] array = @class.method_1((int)@class.method_0().Length);
		@class.method_4();
		byte[] array2 = new byte[32];
		array2[0] = 102;
		array2[0] = 211;
		array2[0] = 88;
		array2[0] = 135;
		array2[0] = 106;
		array2[0] = 108;
		array2[1] = 89;
		array2[1] = 162;
		array2[1] = 127;
		array2[1] = 150;
		array2[1] = 28;
		array2[2] = 47;
		array2[2] = 177;
		array2[2] = 137;
		array2[2] = 129;
		array2[3] = 148;
		array2[3] = 81;
		array2[3] = 97;
		array2[4] = 98;
		array2[4] = 80;
		array2[4] = 98;
		array2[4] = 206;
		array2[5] = 211;
		array2[5] = 130;
		array2[5] = 198;
		array2[6] = 149;
		array2[6] = 86;
		array2[6] = 88;
		array2[6] = 63;
		array2[7] = 111;
		array2[7] = 158;
		array2[7] = 93;
		array2[7] = 239;
		array2[8] = 219;
		array2[8] = 112;
		array2[8] = 76;
		array2[9] = 112;
		array2[9] = 137;
		array2[9] = 92;
		array2[9] = 19;
		array2[10] = 110;
		array2[10] = 102;
		array2[10] = 121;
		array2[10] = 118;
		array2[10] = 126;
		array2[11] = 96;
		array2[11] = 152;
		array2[11] = 141;
		array2[11] = 72;
		array2[11] = 101;
		array2[11] = 5;
		array2[12] = 44;
		array2[12] = 114;
		array2[12] = 149;
		array2[12] = 146;
		array2[12] = 163;
		array2[12] = 231;
		array2[13] = 118;
		array2[13] = 113;
		array2[13] = 150;
		array2[13] = 109;
		array2[14] = 153;
		array2[14] = 158;
		array2[14] = 151;
		array2[15] = 155;
		array2[15] = 143;
		array2[15] = 122;
		array2[15] = 219;
		array2[16] = 68;
		array2[16] = 160;
		array2[16] = 144;
		array2[16] = 29;
		array2[17] = 166;
		array2[17] = 116;
		array2[17] = 134;
		array2[17] = 110;
		array2[17] = 99;
		array2[18] = 148;
		array2[18] = 55;
		array2[18] = 114;
		array2[18] = 80;
		array2[19] = 106;
		array2[19] = 113;
		array2[19] = 122;
		array2[20] = 95;
		array2[20] = 185;
		array2[20] = 132;
		array2[20] = 88;
		array2[21] = 221;
		array2[21] = 160;
		array2[21] = 198;
		array2[21] = 201;
		array2[22] = 151;
		array2[22] = 160;
		array2[22] = 183;
		array2[22] = 116;
		array2[22] = 118;
		array2[22] = 71;
		array2[23] = 176;
		array2[23] = 140;
		array2[23] = 209;
		array2[23] = 164;
		array2[23] = 97;
		array2[23] = 213;
		array2[24] = 86;
		array2[24] = 154;
		array2[24] = 43;
		array2[24] = 93;
		array2[24] = 109;
		array2[25] = 123;
		array2[25] = 148;
		array2[25] = 88;
		array2[25] = 103;
		array2[25] = 47;
		array2[26] = 111;
		array2[26] = 98;
		array2[26] = 125;
		array2[26] = 15;
		array2[27] = 235;
		array2[27] = 155;
		array2[27] = 181;
		array2[27] = 86;
		array2[27] = 148;
		array2[28] = 108;
		array2[28] = 125;
		array2[28] = 143;
		array2[28] = 100;
		array2[28] = 163;
		array2[28] = 253;
		array2[29] = 86;
		array2[29] = 141;
		array2[29] = 206;
		array2[30] = 188;
		array2[30] = 154;
		array2[30] = 152;
		array2[30] = 195;
		array2[30] = 118;
		array2[30] = 135;
		array2[31] = 118;
		array2[31] = 98;
		array2[31] = 121;
		array2[31] = 98;
		array2[31] = 209;
		array2[31] = 136;
		byte[] array3 = array2;
		byte[] array4 = new byte[16];
		array4[0] = 98;
		array4[0] = 118;
		array4[0] = 165;
		array4[0] = 4;
		array4[1] = 101;
		array4[1] = 131;
		array4[1] = 89;
		array4[1] = 217;
		array4[1] = 210;
		array4[1] = 64;
		array4[2] = 97;
		array4[2] = 224;
		array4[2] = 45;
		array4[3] = 103;
		array4[3] = 105;
		array4[3] = 200;
		array4[4] = 56;
		array4[4] = 67;
		array4[4] = 76;
		array4[4] = 89;
		array4[4] = 238;
		array4[5] = 161;
		array4[5] = 151;
		array4[5] = 182;
		array4[6] = 163;
		array4[6] = 44;
		array4[6] = 114;
		array4[6] = 80;
		array4[7] = 177;
		array4[7] = 89;
		array4[7] = 244;
		array4[8] = 150;
		array4[8] = 120;
		array4[8] = 59;
		array4[9] = 146;
		array4[9] = 137;
		array4[9] = 108;
		array4[9] = 129;
		array4[10] = 67;
		array4[10] = 101;
		array4[10] = 55;
		array4[11] = 123;
		array4[11] = 98;
		array4[11] = 229;
		array4[11] = 96;
		array4[11] = 160;
		array4[11] = 113;
		array4[12] = 101;
		array4[12] = 106;
		array4[12] = 109;
		array4[12] = 94;
		array4[12] = 226;
		array4[13] = 149;
		array4[13] = 146;
		array4[13] = 163;
		array4[13] = 135;
		array4[14] = 146;
		array4[14] = 110;
		array4[14] = 113;
		array4[14] = 104;
		array4[14] = 95;
		array4[15] = 135;
		array4[15] = 222;
		array4[15] = 155;
		array4[15] = 132;
		byte[] array5 = array4;
		Array.Reverse(array5);
		byte[] publicKeyToken = Class3.assembly_0.GetName().GetPublicKeyToken();
		if (publicKeyToken != null && publicKeyToken.Length != 0)
		{
			array5[1] = publicKeyToken[0];
			array5[3] = publicKeyToken[1];
			array5[5] = publicKeyToken[2];
			array5[7] = publicKeyToken[3];
			array5[9] = publicKeyToken[4];
			array5[11] = publicKeyToken[5];
			array5[13] = publicKeyToken[6];
			array5[15] = publicKeyToken[7];
		}
		for (int i = 0; i < array5.Length; i++)
		{
			array3[i] ^= array5[i];
		}
		if (int_5 == -1)
		{
			SymmetricAlgorithm symmetricAlgorithm = Class3.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateDecryptor(array3, array5);
			Stream stream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			Class3.byte_1 = Class3.smethod_28(stream);
			stream.Close();
			cryptoStream.Close();
			array = Class3.byte_1;
		}
		if (Class3.assembly_0.EntryPoint == null)
		{
			Class3.int_2 = 80;
		}
		new Class3().method_1(array3, array5, array);
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00008558 File Offset: 0x00006758
	internal static string smethod_13(string string_1)
	{
		"{11111-22222-50001-00000}".Trim();
		byte[] array = Convert.FromBase64String(string_1);
		return Encoding.Unicode.GetString(array, 0, array.Length);
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00008588 File Offset: 0x00006788
	internal static uint smethod_14(IntPtr intptr_4, IntPtr intptr_5, IntPtr intptr_6, [MarshalAs(UnmanagedType.U4)] uint uint_1, IntPtr intptr_7, ref uint uint_2)
	{
		IntPtr intPtr = intptr_6;
		if (Class3.bool_4)
		{
			intPtr = intptr_5;
		}
		long num;
		if (IntPtr.Size == 4)
		{
			num = (long)Marshal.ReadInt32(intPtr, IntPtr.Size * 2);
		}
		else
		{
			num = Marshal.ReadInt64(intPtr, IntPtr.Size * 2);
		}
		object obj = Class3.hashtable_0[num];
		if (obj == null)
		{
			return Class3.delegate2_1(intptr_4, intptr_5, intptr_6, uint_1, intptr_7, ref uint_2);
		}
		Class3.Struct3 @struct = (Class3.Struct3)obj;
		IntPtr intPtr2 = Marshal.AllocCoTaskMem(@struct.byte_0.Length);
		Marshal.Copy(@struct.byte_0, 0, intPtr2, @struct.byte_0.Length);
		if (@struct.bool_0)
		{
			intptr_7 = intPtr2;
			uint_2 = (uint)@struct.byte_0.Length;
			Class3.smethod_23(intptr_7, @struct.byte_0.Length, 64, ref Class3.bMfxquQagN);
			return 0U;
		}
		Marshal.WriteIntPtr(intPtr, IntPtr.Size * 2, intPtr2);
		Marshal.WriteInt32(intPtr, IntPtr.Size * 3, @struct.byte_0.Length);
		uint num2 = 0U;
		if (uint_1 == 216669565U && !Class3.bool_0)
		{
			Class3.bool_0 = true;
		}
		else
		{
			num2 = Class3.delegate2_1(intptr_4, intptr_5, intptr_6, uint_1, intptr_7, ref uint_2);
		}
		return num2;
	}

	// Token: 0x06000077 RID: 119 RVA: 0x0000280C File Offset: 0x00000A0C
	private static int smethod_15()
	{
		return 5;
	}

	// Token: 0x06000078 RID: 120 RVA: 0x000086AC File Offset: 0x000068AC
	private static void smethod_16()
	{
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	// Token: 0x06000079 RID: 121 RVA: 0x000086D4 File Offset: 0x000068D4
	private static Delegate smethod_17(IntPtr intptr_4, Type type_0)
	{
		return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
		{
			typeof(IntPtr),
			typeof(Type)
		}).Invoke(null, new object[] { intptr_4, type_0 });
	}

	// Token: 0x0600007A RID: 122 RVA: 0x00008738 File Offset: 0x00006938
	internal unsafe static void smethod_18()
	{
		if (!Class3.bool_1)
		{
			Class3.bool_1 = true;
			long num = 0L;
			Marshal.ReadIntPtr(new IntPtr((void*)(&num)), 0);
			Marshal.ReadInt32(new IntPtr((void*)(&num)), 0);
			Marshal.ReadInt64(new IntPtr((void*)(&num)), 0);
			Marshal.WriteIntPtr(new IntPtr((void*)(&num)), 0, IntPtr.Zero);
			Marshal.WriteInt32(new IntPtr((void*)(&num)), 0, 0);
			Marshal.WriteInt64(new IntPtr((void*)(&num)), 0, 0L);
			Marshal.Copy(new byte[1], 0, Marshal.AllocCoTaskMem(8), 1);
			Class3.smethod_16();
			if (IntPtr.Size == 4 && Type.GetType("System.Reflection.ReflectionContext", false) != null)
			{
				foreach (object obj in Process.GetCurrentProcess().Modules)
				{
					ProcessModule processModule = (ProcessModule)obj;
					if (processModule.ModuleName.ToLower() == "clrjit.dll")
					{
						Version version = new Version(processModule.FileVersionInfo.ProductMajorPart, processModule.FileVersionInfo.ProductMinorPart, processModule.FileVersionInfo.ProductBuildPart, processModule.FileVersionInfo.ProductPrivatePart);
						Version version2 = new Version(4, 0, 30319, 17020);
						Version version3 = new Version(4, 0, 30319, 17921);
						if (version >= version2 && version < version3)
						{
							Class3.bool_4 = true;
							break;
						}
					}
				}
			}
			Class3.Class6 @class = new Class3.Class6(Class3.assembly_0.GetManifestResourceStream("tIZYLJgTlaN86jfNyU.fwOhdKktwKFYlrNaRA"));
			@class.method_0().Position = 0L;
			byte[] array = @class.method_1((int)@class.method_0().Length);
			byte[] array2 = new byte[32];
			array2[0] = 86;
			array2[0] = 154;
			array2[0] = 151;
			array2[0] = 141;
			array2[0] = 28;
			array2[0] = 203;
			array2[1] = 111;
			array2[1] = 169;
			array2[1] = 200;
			array2[2] = 155;
			array2[2] = 92;
			array2[2] = 235;
			array2[2] = 40;
			array2[2] = 26;
			array2[3] = 142;
			array2[3] = 124;
			array2[3] = 143;
			array2[3] = 130;
			array2[3] = 43;
			array2[4] = 146;
			array2[4] = 152;
			array2[4] = 118;
			array2[4] = 49;
			array2[4] = 154;
			array2[5] = 157;
			array2[5] = 98;
			array2[5] = 136;
			array2[5] = 119;
			array2[5] = 221;
			array2[6] = 134;
			array2[6] = 183;
			array2[6] = 115;
			array2[6] = 129;
			array2[6] = 167;
			array2[7] = 212;
			array2[7] = 170;
			array2[7] = 150;
			array2[7] = 186;
			array2[8] = 76;
			array2[8] = 112;
			array2[8] = 159;
			array2[8] = 152;
			array2[8] = 105;
			array2[8] = 89;
			array2[9] = 172;
			array2[9] = 96;
			array2[9] = 119;
			array2[9] = 38;
			array2[10] = 144;
			array2[10] = 154;
			array2[10] = 75;
			array2[10] = 136;
			array2[11] = 149;
			array2[11] = 119;
			array2[11] = 35;
			array2[12] = 241;
			array2[12] = 120;
			array2[12] = 167;
			array2[12] = 162;
			array2[13] = 107;
			array2[13] = 160;
			array2[13] = 167;
			array2[13] = 120;
			array2[13] = 212;
			array2[14] = 158;
			array2[14] = 164;
			array2[14] = 35;
			array2[14] = 29;
			array2[15] = 172;
			array2[15] = 82;
			array2[15] = 114;
			array2[15] = 148;
			array2[15] = 66;
			array2[16] = 74;
			array2[16] = 93;
			array2[16] = 134;
			array2[16] = 158;
			array2[17] = 84;
			array2[17] = 118;
			array2[17] = 123;
			array2[17] = 90;
			array2[17] = 141;
			array2[17] = 249;
			array2[18] = 164;
			array2[18] = 85;
			array2[18] = 141;
			array2[18] = 126;
			array2[18] = 71;
			array2[19] = 141;
			array2[19] = 108;
			array2[19] = 92;
			array2[19] = 89;
			array2[19] = 76;
			array2[19] = 31;
			array2[20] = 160;
			array2[20] = 53;
			array2[20] = 90;
			array2[20] = 86;
			array2[20] = 85;
			array2[20] = 157;
			array2[21] = 49;
			array2[21] = 168;
			array2[21] = 160;
			array2[21] = 136;
			array2[21] = 210;
			array2[22] = 118;
			array2[22] = 84;
			array2[22] = 14;
			array2[23] = 118;
			array2[23] = 51;
			array2[23] = 161;
			array2[23] = 154;
			array2[23] = 254;
			array2[24] = 108;
			array2[24] = 131;
			array2[24] = 128;
			array2[25] = 136;
			array2[25] = 152;
			array2[25] = 228;
			array2[26] = 175;
			array2[26] = 130;
			array2[26] = 150;
			array2[26] = 21;
			array2[27] = 227;
			array2[27] = 98;
			array2[27] = 65;
			array2[28] = 110;
			array2[28] = 168;
			array2[28] = 130;
			array2[28] = 98;
			array2[28] = 142;
			array2[28] = 209;
			array2[29] = 98;
			array2[29] = 178;
			array2[29] = 149;
			array2[29] = 155;
			array2[29] = 189;
			array2[30] = 203;
			array2[30] = 136;
			array2[30] = 109;
			array2[30] = 84;
			array2[30] = 130;
			array2[30] = 153;
			array2[31] = 144;
			array2[31] = 168;
			array2[31] = 146;
			array2[31] = 148;
			array2[31] = 211;
			byte[] array3 = array2;
			byte[] array4 = new byte[16];
			array4[0] = 86;
			array4[0] = 166;
			array4[0] = 233;
			array4[1] = 151;
			array4[1] = 162;
			array4[1] = 102;
			array4[1] = 20;
			array4[2] = 117;
			array4[2] = 98;
			array4[2] = 169;
			array4[2] = 138;
			array4[2] = 155;
			array4[2] = 109;
			array4[3] = 163;
			array4[3] = 161;
			array4[3] = 111;
			array4[3] = 141;
			array4[3] = 34;
			array4[4] = 98;
			array4[4] = 158;
			array4[4] = 162;
			array4[4] = 142;
			array4[4] = 174;
			array4[4] = 107;
			array4[5] = 164;
			array4[5] = 130;
			array4[5] = 9;
			array4[6] = 98;
			array4[6] = 136;
			array4[6] = 119;
			array4[6] = 158;
			array4[6] = 69;
			array4[7] = 147;
			array4[7] = 115;
			array4[7] = 129;
			array4[7] = 118;
			array4[8] = 158;
			array4[8] = 170;
			array4[8] = 166;
			array4[8] = 163;
			array4[9] = 84;
			array4[9] = 88;
			array4[9] = 20;
			array4[10] = 175;
			array4[10] = 105;
			array4[10] = 136;
			array4[10] = 246;
			array4[11] = 136;
			array4[11] = 52;
			array4[11] = 132;
			array4[11] = 82;
			array4[11] = 166;
			array4[12] = 128;
			array4[12] = 90;
			array4[12] = 149;
			array4[12] = 181;
			array4[13] = 86;
			array4[13] = 241;
			array4[13] = 202;
			array4[14] = 118;
			array4[14] = 93;
			array4[14] = 146;
			array4[14] = 222;
			array4[15] = 160;
			array4[15] = 197;
			array4[15] = 50;
			array4[15] = 152;
			byte[] array5 = array4;
			Array.Reverse(array5);
			byte[] publicKeyToken = Class3.assembly_0.GetName().GetPublicKeyToken();
			if (publicKeyToken != null && publicKeyToken.Length != 0)
			{
				array5[1] = publicKeyToken[0];
				array5[3] = publicKeyToken[1];
				array5[5] = publicKeyToken[2];
				array5[7] = publicKeyToken[3];
				array5[9] = publicKeyToken[4];
				array5[11] = publicKeyToken[5];
				array5[13] = publicKeyToken[6];
				array5[15] = publicKeyToken[7];
				Array.Clear(publicKeyToken, 0, publicKeyToken.Length);
			}
			for (int i = 0; i < array5.Length; i++)
			{
				array3[i] ^= array5[i];
			}
			byte[] array6 = array;
			int num2 = array6.Length % 4;
			int num3 = array6.Length / 4;
			byte[] array7 = new byte[array6.Length];
			int num4 = array3.Length / 4;
			uint num5 = 0U;
			if (num2 > 0)
			{
				num3++;
			}
			for (int j = 0; j < num3; j++)
			{
				int num6 = j % num4;
				int num7 = j * 4;
				uint num8 = (uint)(num6 * 4);
				uint num9 = (uint)(((int)array3[(int)(num8 + 3U)] << 24) | ((int)array3[(int)(num8 + 2U)] << 16) | ((int)array3[(int)(num8 + 1U)] << 8) | (int)array3[(int)num8]);
				uint num10 = 255U;
				int num11 = 0;
				uint num12;
				if (j == num3 - 1 && num2 > 0)
				{
					num5 += num9;
					num12 = 0U;
					for (int k = 0; k < num2; k++)
					{
						if (k > 0)
						{
							num12 <<= 8;
						}
						num12 |= (uint)array6[array6.Length - (1 + k)];
					}
				}
				else
				{
					num8 = (uint)num7;
					num5 += num9;
					num12 = (uint)(((int)array6[(int)(num8 + 3U)] << 24) | ((int)array6[(int)(num8 + 2U)] << 16) | ((int)array6[(int)(num8 + 1U)] << 8) | (int)array6[(int)num8]);
				}
				num5 = num5;
				uint num13 = num5;
				uint num14 = num5;
				uint num15 = 1621803678U;
				uint num16 = 2371254347U ^ num14;
				uint num17 = num16 & 1431655765U;
				num16 &= 2863311530U;
				uint num18 = (num16 >> 1) | (num17 << 1);
				uint num19 = 1987112382U - num14;
				if (num14 == 0U)
				{
					num14 -= 1U;
				}
				uint num20 = num18 / num14 + num14;
				num14 = num18 - num18 - num20 + num18;
				uint num21 = num18 + num18 - num18;
				if (num15 == 0U)
				{
					num15 -= 1U;
				}
				num20 = num18 / num15 + num15;
				num15 = num18 - num18 - num20 + num18;
				num14 ^= num14 << 22;
				num14 += num14;
				num14 ^= num14 >> 5;
				num14 += num21;
				num14 ^= num14 << 3;
				num14 += num15;
				num14 = (((num19 << 18) - num19) ^ num14) + num14;
				num5 = num13 + (uint)num14;
				if (j == num3 - 1 && num2 > 0)
				{
					uint num22 = num5 ^ num12;
					for (int l = 0; l < num2; l++)
					{
						if (l > 0)
						{
							num10 <<= 8;
							num11 += 8;
						}
						array7[num7 + l] = (byte)((num22 & num10) >> num11);
					}
				}
				else
				{
					uint num23 = num5 ^ num12;
					array7[num7] = (byte)(num23 & 255U);
					array7[num7 + 1] = (byte)((num23 & 65280U) >> 8);
					array7[num7 + 2] = (byte)((num23 & 16711680U) >> 16);
					array7[num7 + 3] = (byte)((num23 & 4278190080U) >> 24);
				}
			}
			byte[] array8 = array7;
			int num24 = array8.Length / 8;
			byte[] array9;
			byte* ptr;
			if ((array9 = array8) != null && array9.Length != 0)
			{
				ptr = &array9[0];
			}
			else
			{
				ptr = null;
			}
			for (int m = 0; m < num24; m++)
			{
				*(long*)(ptr + m * 8) ^= 48839809L;
			}
			array9 = null;
			@class = new Class3.Class6(new MemoryStream(array8));
			@class.method_0().Position = 0L;
			long num25 = Marshal.GetHINSTANCE(Class3.assembly_0.GetModules()[0]).ToInt64();
			int num26 = 0;
			int num27 = 0;
			if (Class3.assembly_0.Location == null || Class3.assembly_0.Location.Length == 0)
			{
				num27 = 7680;
			}
			@class.method_3();
			@class.method_3();
			@class.method_3();
			int num28 = @class.method_3();
			int num29 = @class.method_3();
			if (num29 == 4)
			{
				SymmetricAlgorithm symmetricAlgorithm = Class3.smethod_7();
				symmetricAlgorithm.Mode = CipherMode.CBC;
				ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateDecryptor(array3, array5);
				Array.Clear(array3, 0, array3.Length);
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				array8 = memoryStream.ToArray();
				Array.Clear(array5, 0, array5.Length);
				memoryStream.Close();
				cryptoStream.Close();
				@class.method_4();
				num28 = @class.method_3();
				num29 = @class.method_3();
			}
			if (num29 == 1)
			{
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Class3.smethod_24(56U, 1, (uint)Process.GetCurrentProcess().Id);
				if (IntPtr.Size == 4)
				{
					Class3.int_4 = Marshal.GetHINSTANCE(Class3.assembly_0.GetModules()[0]).ToInt32();
				}
				Class3.long_1 = Marshal.GetHINSTANCE(Class3.assembly_0.GetModules()[0]).ToInt64();
				IntPtr zero = IntPtr.Zero;
				for (int n = 0; n < num28; n++)
				{
					IntPtr intPtr2 = new IntPtr(Class3.long_1 + (long)@class.method_3() - (long)num27);
					if (Class3.smethod_23(intPtr2, 4, 4, ref num26) == 0)
					{
						Class3.smethod_23(intPtr2, 4, 8, ref num26);
					}
					if (IntPtr.Size == 4)
					{
						Class3.smethod_22(intPtr, intPtr2, BitConverter.GetBytes(@class.method_3()), 4U, out zero);
					}
					else
					{
						Class3.smethod_22(intPtr, intPtr2, BitConverter.GetBytes(@class.method_3()), 4U, out zero);
					}
					Class3.smethod_23(intPtr2, 4, num26, ref num26);
				}
				while (@class.method_0().Position < @class.method_0().Length - 1L)
				{
					int num30 = @class.method_3();
					IntPtr intPtr3 = new IntPtr(Class3.long_1 + (long)num30 - (long)num27);
					int num31 = @class.method_3();
					if (Class3.smethod_23(intPtr3, num31 * 4, 4, ref num26) == 0)
					{
						Class3.smethod_23(intPtr3, num31 * 4, 8, ref num26);
					}
					for (int num32 = 0; num32 < num31; num32++)
					{
						Marshal.WriteInt32(new IntPtr(intPtr3.ToInt64() + (long)(num32 * 4)), @class.method_3());
					}
					Class3.smethod_23(intPtr3, num31 * 4, num26, ref num26);
				}
				Class3.smethod_25(intPtr);
				return;
			}
			for (int num33 = 0; num33 < num28; num33++)
			{
				IntPtr intPtr4 = new IntPtr(num25 + (long)@class.method_3() - (long)num27);
				if (Class3.smethod_23(intPtr4, 4, 4, ref num26) == 0)
				{
					Class3.smethod_23(intPtr4, 4, 8, ref num26);
				}
				Marshal.WriteInt32(intPtr4, @class.method_3());
				Class3.smethod_23(intPtr4, 4, num26, ref num26);
			}
			Class3.hashtable_0 = new Hashtable(@class.method_3() + 1);
			Class3.Struct3 @struct = default(Class3.Struct3);
			@struct.byte_0 = new byte[] { 42 };
			@struct.bool_0 = false;
			Class3.hashtable_0.Add(0L, @struct);
			while (@class.method_0().Position < @class.method_0().Length - 1L)
			{
				int num34 = @class.method_3() - num27;
				int num35 = @class.method_3();
				bool flag = false;
				if (num35 >= 1879048192)
				{
					flag = true;
				}
				int num36 = @class.method_3();
				byte[] array10 = @class.method_1(num36);
				Class3.Struct3 struct2 = default(Class3.Struct3);
				struct2.byte_0 = array10;
				struct2.bool_0 = flag;
				Class3.hashtable_0.Add(num25 + (long)num34, struct2);
			}
			Class3.long_0 = Marshal.GetHINSTANCE(typeof(Class3).Assembly.GetModules()[0]).ToInt64();
			if (IntPtr.Size == 4)
			{
				Class3.int_3 = Convert.ToInt32(Class3.long_0);
			}
			byte[] array11 = new byte[]
			{
				109, 115, 99, 111, 114, 106, 105, 116, 46, 100,
				108, 108
			};
			string text = Encoding.UTF8.GetString(array11);
			IntPtr intPtr5 = IntPtr.Zero;
			if (intPtr5 == IntPtr.Zero)
			{
				array11 = new byte[] { 99, 108, 114, 106, 105, 116, 46, 100, 108, 108 };
				text = Encoding.UTF8.GetString(array11);
				intPtr5 = Class3.LoadLibrary(text);
			}
			byte[] array12 = new byte[] { 103, 101, 116, 74, 105, 116 };
			string @string = Encoding.UTF8.GetString(array12);
			IntPtr intPtr6 = ((Class3.Delegate3)Class3.smethod_17(Class3.GetProcAddress(intPtr5, @string), typeof(Class3.Delegate3)))();
			long num37 = 0L;
			if (IntPtr.Size == 4)
			{
				num37 = (long)Marshal.ReadInt32(intPtr6);
			}
			else
			{
				num37 = Marshal.ReadInt64(intPtr6);
			}
			Marshal.ReadIntPtr(intPtr6, 0);
			Class3.delegate2_0 = new Class3.Delegate2(Class3.smethod_14);
			IntPtr intPtr7 = IntPtr.Zero;
			intPtr7 = Marshal.GetFunctionPointerForDelegate(Class3.delegate2_0);
			long num38 = 0L;
			if (IntPtr.Size == 4)
			{
				num38 = (long)Marshal.ReadInt32(new IntPtr(num37));
			}
			else
			{
				num38 = Marshal.ReadInt64(new IntPtr(num37));
			}
			Process currentProcess = Process.GetCurrentProcess();
			try
			{
				foreach (object obj2 in currentProcess.Modules)
				{
					ProcessModule processModule2 = (ProcessModule)obj2;
					if (processModule2.ModuleName == text && (num38 < processModule2.BaseAddress.ToInt64() || num38 > processModule2.BaseAddress.ToInt64() + (long)processModule2.ModuleMemorySize) && typeof(Class3).Assembly.EntryPoint != null)
					{
						return;
					}
				}
			}
			catch
			{
			}
			try
			{
				using (IEnumerator enumerator = currentProcess.Modules.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (((ProcessModule)enumerator.Current).BaseAddress.ToInt64() == Class3.long_0)
						{
							break;
						}
					}
				}
			}
			catch
			{
			}
			Class3.delegate2_1 = null;
			try
			{
				Class3.delegate2_1 = (Class3.Delegate2)Class3.smethod_17(new IntPtr(num38), typeof(Class3.Delegate2));
			}
			catch
			{
				try
				{
					Delegate @delegate = Class3.smethod_17(new IntPtr(num38), typeof(Class3.Delegate2));
					Class3.delegate2_1 = (Class3.Delegate2)Delegate.CreateDelegate(typeof(Class3.Delegate2), @delegate.Method);
				}
				catch
				{
				}
			}
			int num39 = 0;
			if (typeof(Class3).Assembly.EntryPoint != null && typeof(Class3).Assembly.EntryPoint.GetParameters().Length == 2 && typeof(Class3).Assembly.Location != null && typeof(Class3).Assembly.Location.Length > 0)
			{
				return;
			}
			try
			{
				object value = typeof(Class3).Assembly.ManifestModule.ModuleHandle.GetType().GetField("m_ptr", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(typeof(Class3).Assembly.ManifestModule.ModuleHandle);
				if (value is IntPtr)
				{
					Class3.intptr_3 = (IntPtr)value;
				}
				if (value.GetType().ToString() == "System.Reflection.RuntimeModule")
				{
					Class3.intptr_3 = (IntPtr)value.GetType().GetField("m_pData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(value);
				}
				MemoryStream memoryStream2 = new MemoryStream();
				memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
				if (IntPtr.Size == 4)
				{
					memoryStream2.Write(BitConverter.GetBytes(Class3.intptr_3.ToInt32()), 0, 4);
				}
				else
				{
					memoryStream2.Write(BitConverter.GetBytes(Class3.intptr_3.ToInt64()), 0, 8);
				}
				memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
				memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
				memoryStream2.Position = 0L;
				byte[] array13 = memoryStream2.ToArray();
				memoryStream2.Close();
				uint num40 = 0U;
				try
				{
					byte* ptr2;
					if ((array9 = array13) != null && array9.Length != 0)
					{
						ptr2 = &array9[0];
					}
					else
					{
						ptr2 = null;
					}
					Class3.delegate2_0(new IntPtr((void*)ptr2), new IntPtr((void*)ptr2), new IntPtr((void*)ptr2), 216669565U, new IntPtr((void*)ptr2), ref num40);
				}
				finally
				{
					array9 = null;
				}
			}
			catch
			{
			}
			RuntimeHelpers.PrepareDelegate(Class3.delegate2_1);
			RuntimeHelpers.PrepareMethod(Class3.delegate2_1.Method.MethodHandle);
			RuntimeHelpers.PrepareDelegate(Class3.delegate2_0);
			RuntimeHelpers.PrepareMethod(Class3.delegate2_0.Method.MethodHandle);
			byte[] array14;
			if (IntPtr.Size != 4)
			{
				array14 = new byte[]
				{
					72, 184, 0, 0, 0, 0, 0, 0, 0, 0,
					73, 57, 64, 8, 116, 12, 72, 184, 0, 0,
					0, 0, 0, 0, 0, 0, byte.MaxValue, 224, 72, 184,
					0, 0, 0, 0, 0, 0, 0, 0, byte.MaxValue, 224
				};
			}
			else
			{
				array14 = new byte[]
				{
					85, 139, 236, 139, 69, 16, 129, 120, 4, 125,
					29, 234, 12, 116, 7, 184, 182, 177, 74, 6,
					235, 5, 184, 182, 146, 64, 12, 93, byte.MaxValue, 224
				};
			}
			IntPtr intPtr8 = Class3.smethod_21(IntPtr.Zero, (uint)array14.Length, 4096U, 64U);
			byte[] array15 = array14;
			byte[] array16;
			byte[] array17;
			byte[] array18;
			if (IntPtr.Size == 4)
			{
				array16 = BitConverter.GetBytes(Class3.intptr_3.ToInt32());
				array17 = BitConverter.GetBytes(intPtr7.ToInt32());
				array18 = BitConverter.GetBytes(Convert.ToInt32(num38));
			}
			else
			{
				array16 = BitConverter.GetBytes(Class3.intptr_3.ToInt64());
				array17 = BitConverter.GetBytes(intPtr7.ToInt64());
				array18 = BitConverter.GetBytes(num38);
			}
			if (IntPtr.Size == 4)
			{
				array15[9] = array16[0];
				array15[10] = array16[1];
				array15[11] = array16[2];
				array15[12] = array16[3];
				array15[16] = array18[0];
				array15[17] = array18[1];
				array15[18] = array18[2];
				array15[19] = array18[3];
				array15[23] = array17[0];
				array15[24] = array17[1];
				array15[25] = array17[2];
				array15[26] = array17[3];
			}
			else
			{
				array15[2] = array16[0];
				array15[3] = array16[1];
				array15[4] = array16[2];
				array15[5] = array16[3];
				array15[6] = array16[4];
				array15[7] = array16[5];
				array15[8] = array16[6];
				array15[9] = array16[7];
				array15[18] = array18[0];
				array15[19] = array18[1];
				array15[20] = array18[2];
				array15[21] = array18[3];
				array15[22] = array18[4];
				array15[23] = array18[5];
				array15[24] = array18[6];
				array15[25] = array18[7];
				array15[30] = array17[0];
				array15[31] = array17[1];
				array15[32] = array17[2];
				array15[33] = array17[3];
				array15[34] = array17[4];
				array15[35] = array17[5];
				array15[36] = array17[6];
				array15[37] = array17[7];
			}
			Marshal.Copy(array15, 0, intPtr8, array15.Length);
			Class3.bool_2 = false;
			Class3.smethod_23(new IntPtr(num37), IntPtr.Size, 64, ref num39);
			Marshal.WriteIntPtr(new IntPtr(num37), intPtr8);
			Class3.smethod_23(new IntPtr(num37), IntPtr.Size, num39, ref num39);
		}
	}

	// Token: 0x0600007B RID: 123 RVA: 0x0000A5FC File Offset: 0x000087FC
	internal static object smethod_19(Assembly assembly_1)
	{
		try
		{
			if (File.Exists(((Assembly)assembly_1).Location))
			{
				return ((Assembly)assembly_1).Location;
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(((Assembly)assembly_1).GetName().CodeBase.ToString().Replace("file:///", "")))
			{
				return ((Assembly)assembly_1).GetName().CodeBase.ToString().Replace("file:///", "");
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0])
				.ToString()))
			{
				return assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0])
					.ToString();
			}
		}
		catch
		{
		}
		return "";
	}

	// Token: 0x0600007C RID: 124
	[DllImport("kernel32")]
	public static extern IntPtr LoadLibrary(string string_1);

	// Token: 0x0600007D RID: 125
	[DllImport("kernel32", CharSet = CharSet.Ansi)]
	public static extern IntPtr GetProcAddress(IntPtr intptr_4, string string_1);

	// Token: 0x0600007E RID: 126 RVA: 0x0000A70C File Offset: 0x0000890C
	private static IntPtr smethod_20(IntPtr intptr_4, string string_1, uint uint_1)
	{
		if (Class3.delegate4_0 == null)
		{
			Class3.delegate4_0 = (Class3.Delegate4)Marshal.GetDelegateForFunctionPointer(Class3.GetProcAddress(Class3.smethod_26(), "Find ".Trim() + "ResourceA"), typeof(Class3.Delegate4));
		}
		return Class3.delegate4_0(intptr_4, string_1, uint_1);
	}

	// Token: 0x0600007F RID: 127 RVA: 0x0000A768 File Offset: 0x00008968
	private static IntPtr smethod_21(IntPtr intptr_4, uint uint_1, uint uint_2, uint uint_3)
	{
		if (Class3.delegate5_0 == null)
		{
			Class3.delegate5_0 = (Class3.Delegate5)Marshal.GetDelegateForFunctionPointer(Class3.GetProcAddress(Class3.smethod_26(), "Virtual ".Trim() + "Alloc"), typeof(Class3.Delegate5));
		}
		return Class3.delegate5_0(intptr_4, uint_1, uint_2, uint_3);
	}

	// Token: 0x06000080 RID: 128 RVA: 0x0000A7C4 File Offset: 0x000089C4
	private static int smethod_22(IntPtr intptr_4, IntPtr intptr_5, [In] [Out] byte[] byte_2, uint uint_1, out IntPtr intptr_6)
	{
		if (Class3.delegate6_0 == null)
		{
			Class3.delegate6_0 = (Class3.Delegate6)Marshal.GetDelegateForFunctionPointer(Class3.GetProcAddress(Class3.smethod_26(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(Class3.Delegate6));
		}
		return Class3.delegate6_0(intptr_4, intptr_5, byte_2, uint_1, out intptr_6);
	}

	// Token: 0x06000081 RID: 129 RVA: 0x0000A82C File Offset: 0x00008A2C
	private static int smethod_23(IntPtr intptr_4, int int_5, int int_6, ref int int_7)
	{
		if (Class3.delegate7_0 == null)
		{
			Class3.delegate7_0 = (Class3.Delegate7)Marshal.GetDelegateForFunctionPointer(Class3.GetProcAddress(Class3.smethod_26(), "Virtual ".Trim() + "Protect"), typeof(Class3.Delegate7));
		}
		return Class3.delegate7_0(intptr_4, int_5, int_6, ref int_7);
	}

	// Token: 0x06000082 RID: 130 RVA: 0x0000A888 File Offset: 0x00008A88
	private static IntPtr smethod_24(uint uint_1, int int_5, uint uint_2)
	{
		if (Class3.delegate8_0 == null)
		{
			Class3.delegate8_0 = (Class3.Delegate8)Marshal.GetDelegateForFunctionPointer(Class3.GetProcAddress(Class3.smethod_26(), "Open ".Trim() + "Process"), typeof(Class3.Delegate8));
		}
		return Class3.delegate8_0(uint_1, int_5, uint_2);
	}

	// Token: 0x06000083 RID: 131 RVA: 0x0000A8E4 File Offset: 0x00008AE4
	private static int smethod_25(IntPtr intptr_4)
	{
		if (Class3.delegate9_0 == null)
		{
			Class3.delegate9_0 = (Class3.Delegate9)Marshal.GetDelegateForFunctionPointer(Class3.GetProcAddress(Class3.smethod_26(), "Close ".Trim() + "Handle"), typeof(Class3.Delegate9));
		}
		return Class3.delegate9_0(intptr_4);
	}

	// Token: 0x06000084 RID: 132 RVA: 0x0000280F File Offset: 0x00000A0F
	private static IntPtr smethod_26()
	{
		if (Class3.intptr_1 == IntPtr.Zero)
		{
			Class3.intptr_1 = Class3.LoadLibrary("kernel ".Trim() + "32.dll");
		}
		return Class3.intptr_1;
	}

	// Token: 0x06000085 RID: 133 RVA: 0x0000A93C File Offset: 0x00008B3C
	private static byte[] smethod_27(string string_1)
	{
		byte[] array;
		using (FileStream fileStream = new FileStream(string_1, FileMode.Open, FileAccess.Read, FileShare.Read))
		{
			int num = 0;
			int i = (int)fileStream.Length;
			array = new byte[i];
			while (i > 0)
			{
				int num2 = fileStream.Read(array, num, i);
				num += num2;
				i -= num2;
			}
		}
		return array;
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00002845 File Offset: 0x00000A45
	internal static byte[] smethod_28(MemoryStream memoryStream_0)
	{
		return ((MemoryStream)memoryStream_0).ToArray();
	}

	// Token: 0x06000087 RID: 135 RVA: 0x0000A99C File Offset: 0x00008B9C
	private static byte[] smethod_29(byte[] byte_2)
	{
		Stream stream = new MemoryStream();
		SymmetricAlgorithm symmetricAlgorithm = Class3.smethod_7();
		symmetricAlgorithm.Key = new byte[]
		{
			50, 185, 180, 115, 124, 200, 89, 204, 157, 98,
			6, 193, 83, 189, 22, 186, 27, 225, 25, 173,
			186, 134, 176, 116, 165, 152, 120, 224, 29, 96,
			160, 85
		};
		symmetricAlgorithm.IV = new byte[]
		{
			58, 39, 117, 254, 198, 156, 72, 63, 214, 64,
			91, 191, 162, 131, 32, 162
		};
		CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(byte_2, 0, byte_2.Length);
		cryptoStream.Close();
		return Class3.smethod_28(stream);
	}

	// Token: 0x06000088 RID: 136 RVA: 0x0000AA0C File Offset: 0x00008C0C
	private byte[] method_2()
	{
		return null;
	}

	// Token: 0x06000089 RID: 137 RVA: 0x0000AA0C File Offset: 0x00008C0C
	private byte[] method_3()
	{
		return null;
	}

	// Token: 0x0600008A RID: 138 RVA: 0x0000AA1C File Offset: 0x00008C1C
	private byte[] method_4()
	{
		return null;
	}

	// Token: 0x0600008B RID: 139 RVA: 0x0000AA1C File Offset: 0x00008C1C
	private byte[] method_5()
	{
		return null;
	}

	// Token: 0x0600008C RID: 140 RVA: 0x0000AA0C File Offset: 0x00008C0C
	private byte[] method_6()
	{
		return null;
	}

	// Token: 0x0600008D RID: 141 RVA: 0x0000AA0C File Offset: 0x00008C0C
	private byte[] method_7()
	{
		return null;
	}

	// Token: 0x0600008E RID: 142 RVA: 0x00002852 File Offset: 0x00000A52
	internal byte[] method_8()
	{
		int length = "{11111-22222-40001-00001}".Length;
		return new byte[] { 1, 2 };
	}

	// Token: 0x0600008F RID: 143 RVA: 0x0000286D File Offset: 0x00000A6D
	internal byte[] method_9()
	{
		int length = "{11111-22222-40001-00002}".Length;
		return new byte[] { 1, 2 };
	}

	// Token: 0x06000090 RID: 144 RVA: 0x0000AA0C File Offset: 0x00008C0C
	internal byte[] method_10()
	{
		return null;
	}

	// Token: 0x06000091 RID: 145 RVA: 0x0000AA0C File Offset: 0x00008C0C
	internal byte[] method_11()
	{
		return null;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x00002888 File Offset: 0x00000A88
	internal static bool smethod_30()
	{
		return null == null;
	}

	// Token: 0x06000093 RID: 147 RVA: 0x0000288E File Offset: 0x00000A8E
	internal static object smethod_31()
	{
		return null;
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00002888 File Offset: 0x00000A88
	internal static bool smethod_32()
	{
		return null == null;
	}

	// Token: 0x06000095 RID: 149 RVA: 0x0000288E File Offset: 0x00000A8E
	internal static object smethod_33()
	{
		return null;
	}

	// Token: 0x06000096 RID: 150 RVA: 0x00002891 File Offset: 0x00000A91
	static int smethod_34()
	{
		return 1;
	}

	// Token: 0x06000097 RID: 151 RVA: 0x00002894 File Offset: 0x00000A94
	internal static IntPtr smethod_35(IntPtr intptr_4, int int_5)
	{
		return Marshal.ReadIntPtr(intptr_4, int_5);
	}

	// Token: 0x06000098 RID: 152 RVA: 0x000028A3 File Offset: 0x00000AA3
	internal static int smethod_36(IntPtr intptr_4, int int_5)
	{
		return Marshal.ReadInt32(intptr_4, int_5);
	}

	// Token: 0x06000099 RID: 153 RVA: 0x000028B2 File Offset: 0x00000AB2
	internal static long smethod_37(IntPtr intptr_4, int int_5)
	{
		return Marshal.ReadInt64(intptr_4, int_5);
	}

	// Token: 0x0600009A RID: 154 RVA: 0x000028C1 File Offset: 0x00000AC1
	internal static void smethod_38(IntPtr intptr_4, int int_5, IntPtr intptr_5)
	{
		Marshal.WriteIntPtr(intptr_4, int_5, intptr_5);
	}

	// Token: 0x0600009B RID: 155 RVA: 0x000028D4 File Offset: 0x00000AD4
	internal static void smethod_39(IntPtr intptr_4, int int_5, int int_6)
	{
		Marshal.WriteInt32(intptr_4, int_5, int_6);
	}

	// Token: 0x0600009C RID: 156 RVA: 0x000028E7 File Offset: 0x00000AE7
	internal static void smethod_40(IntPtr intptr_4, int int_5, long long_2)
	{
		Marshal.WriteInt64(intptr_4, int_5, long_2);
	}

	// Token: 0x0600009D RID: 157 RVA: 0x000028FA File Offset: 0x00000AFA
	internal static IntPtr smethod_41(int int_5)
	{
		return Marshal.AllocCoTaskMem(int_5);
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00002905 File Offset: 0x00000B05
	internal static void smethod_42(byte[] byte_2, int int_5, IntPtr intptr_4, int int_6)
	{
		Marshal.Copy(byte_2, int_5, intptr_4, int_6);
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0000291C File Offset: 0x00000B1C
	internal static void smethod_43()
	{
		Class3.smethod_16();
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00002923 File Offset: 0x00000B23
	internal static object smethod_44()
	{
		return Process.GetCurrentProcess();
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x0000292A File Offset: 0x00000B2A
	internal static object smethod_45(Process process_0)
	{
		return process_0.MainModule;
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x00002935 File Offset: 0x00000B35
	internal static IntPtr smethod_46(ProcessModule processModule_0)
	{
		return processModule_0.BaseAddress;
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x00002940 File Offset: 0x00000B40
	internal static IntPtr smethod_47(IntPtr intptr_4, string string_1, uint uint_1)
	{
		return Class3.smethod_20(intptr_4, string_1, uint_1);
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x00002953 File Offset: 0x00000B53
	internal static bool smethod_48(IntPtr intptr_4, IntPtr intptr_5)
	{
		return intptr_4 != intptr_5;
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00002962 File Offset: 0x00000B62
	internal static void smethod_49()
	{
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x00002965 File Offset: 0x00000B65
	internal static int smethod_50()
	{
		return IntPtr.Size;
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x0000296C File Offset: 0x00000B6C
	internal static Type smethod_51(string string_1, bool bool_7)
	{
		return Type.GetType(string_1, bool_7);
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x0000297B File Offset: 0x00000B7B
	internal static bool smethod_52(Type type_0, Type type_1)
	{
		return type_0 != type_1;
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x0000298A File Offset: 0x00000B8A
	internal static object smethod_53(Process process_0)
	{
		return process_0.Modules;
	}

	// Token: 0x060000AA RID: 170 RVA: 0x00002995 File Offset: 0x00000B95
	internal static object smethod_54(ReadOnlyCollectionBase readOnlyCollectionBase_0)
	{
		return readOnlyCollectionBase_0.GetEnumerator();
	}

	// Token: 0x060000AB RID: 171 RVA: 0x000029A0 File Offset: 0x00000BA0
	internal static object smethod_55(IEnumerator ienumerator_0)
	{
		return ienumerator_0.Current;
	}

	// Token: 0x060000AC RID: 172 RVA: 0x000029AB File Offset: 0x00000BAB
	internal static object smethod_56(ProcessModule processModule_0)
	{
		return processModule_0.ModuleName;
	}

	// Token: 0x060000AD RID: 173 RVA: 0x000029B6 File Offset: 0x00000BB6
	internal static object smethod_57(string string_1)
	{
		return string_1.ToLower();
	}

	// Token: 0x060000AE RID: 174 RVA: 0x000029C1 File Offset: 0x00000BC1
	internal static bool smethod_58(string string_1, string string_2)
	{
		return string_1 == string_2;
	}

	// Token: 0x060000AF RID: 175 RVA: 0x000029D0 File Offset: 0x00000BD0
	internal static object smethod_59(ProcessModule processModule_0)
	{
		return processModule_0.FileVersionInfo;
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x000029DB File Offset: 0x00000BDB
	internal static int smethod_60(FileVersionInfo fileVersionInfo_0)
	{
		return fileVersionInfo_0.ProductMajorPart;
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x000029E6 File Offset: 0x00000BE6
	internal static int smethod_61(FileVersionInfo fileVersionInfo_0)
	{
		return fileVersionInfo_0.ProductMinorPart;
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x000029F1 File Offset: 0x00000BF1
	internal static int smethod_62(FileVersionInfo fileVersionInfo_0)
	{
		return fileVersionInfo_0.ProductBuildPart;
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x000029FC File Offset: 0x00000BFC
	internal static int smethod_63(FileVersionInfo fileVersionInfo_0)
	{
		return fileVersionInfo_0.ProductPrivatePart;
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00002A07 File Offset: 0x00000C07
	internal static bool smethod_64(Version version_0, Version version_1)
	{
		return version_0 >= version_1;
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x00002A16 File Offset: 0x00000C16
	internal static bool smethod_65(Version version_0, Version version_1)
	{
		return version_0 < version_1;
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x00002A25 File Offset: 0x00000C25
	internal static bool smethod_66(IEnumerator ienumerator_0)
	{
		return ienumerator_0.MoveNext();
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x00002A30 File Offset: 0x00000C30
	internal static void smethod_67(IDisposable idisposable_0)
	{
		idisposable_0.Dispose();
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00002A3B File Offset: 0x00000C3B
	internal static object smethod_68(Assembly assembly_1, string string_1)
	{
		return assembly_1.GetManifestResourceStream(string_1);
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x00002A4A File Offset: 0x00000C4A
	internal static object smethod_69(Class3.Class6 class6_0)
	{
		return class6_0.method_0();
	}

	// Token: 0x060000BA RID: 186 RVA: 0x00002A55 File Offset: 0x00000C55
	internal static void smethod_70(Stream stream_0, long long_2)
	{
		stream_0.Position = long_2;
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00002A64 File Offset: 0x00000C64
	internal static long smethod_71(Stream stream_0)
	{
		return stream_0.Length;
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00002A6F File Offset: 0x00000C6F
	internal static object smethod_72(Class3.Class6 class6_0, int int_5)
	{
		return class6_0.method_1(int_5);
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00002A7E File Offset: 0x00000C7E
	internal static void smethod_73(Array array_0)
	{
		Array.Reverse(array_0);
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00002A89 File Offset: 0x00000C89
	internal static object smethod_74(Assembly assembly_1)
	{
		return assembly_1.GetName();
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00002A94 File Offset: 0x00000C94
	internal static object smethod_75(AssemblyName assemblyName_0)
	{
		return assemblyName_0.GetPublicKeyToken();
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00002A9F File Offset: 0x00000C9F
	internal static void smethod_76(Array array_0, int int_5, int int_6)
	{
		Array.Clear(array_0, int_5, int_6);
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00002AB2 File Offset: 0x00000CB2
	internal static object smethod_77(Assembly assembly_1)
	{
		return assembly_1.GetModules();
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00002ABD File Offset: 0x00000CBD
	internal static IntPtr smethod_78(Module module_0)
	{
		return Marshal.GetHINSTANCE(module_0);
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x00002AC8 File Offset: 0x00000CC8
	internal static object smethod_79(Assembly assembly_1)
	{
		return assembly_1.Location;
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x00002AD3 File Offset: 0x00000CD3
	internal static int smethod_80(string string_1)
	{
		return string_1.Length;
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00002ADE File Offset: 0x00000CDE
	internal static int smethod_81(Class3.Class6 class6_0)
	{
		return class6_0.method_3();
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00002AE9 File Offset: 0x00000CE9
	internal static object smethod_82()
	{
		return Class3.smethod_7();
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x00002AF0 File Offset: 0x00000CF0
	internal static void smethod_83(SymmetricAlgorithm symmetricAlgorithm_0, CipherMode cipherMode_0)
	{
		symmetricAlgorithm_0.Mode = cipherMode_0;
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00002AFF File Offset: 0x00000CFF
	internal static object smethod_84(SymmetricAlgorithm symmetricAlgorithm_0, byte[] byte_2, byte[] byte_3)
	{
		return symmetricAlgorithm_0.CreateDecryptor(byte_2, byte_3);
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00002B12 File Offset: 0x00000D12
	internal static void smethod_85(Stream stream_0, byte[] byte_2, int int_5, int int_6)
	{
		stream_0.Write(byte_2, int_5, int_6);
	}

	// Token: 0x060000CA RID: 202 RVA: 0x00002B29 File Offset: 0x00000D29
	internal static void smethod_86(CryptoStream cryptoStream_0)
	{
		cryptoStream_0.FlushFinalBlock();
	}

	// Token: 0x060000CB RID: 203 RVA: 0x00002B34 File Offset: 0x00000D34
	internal static object smethod_87(MemoryStream memoryStream_0)
	{
		return memoryStream_0.ToArray();
	}

	// Token: 0x060000CC RID: 204 RVA: 0x00002B3F File Offset: 0x00000D3F
	internal static void smethod_88(Stream stream_0)
	{
		stream_0.Close();
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00002B4A File Offset: 0x00000D4A
	internal static void smethod_89(Class3.Class6 class6_0)
	{
		class6_0.method_4();
	}

	// Token: 0x060000CE RID: 206 RVA: 0x00002B55 File Offset: 0x00000D55
	internal static int smethod_90(Process process_0)
	{
		return process_0.Id;
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00002B60 File Offset: 0x00000D60
	internal static IntPtr smethod_91(uint uint_1, int int_5, uint uint_2)
	{
		return Class3.smethod_24(uint_1, int_5, uint_2);
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00002B73 File Offset: 0x00000D73
	internal static object smethod_92(int int_5)
	{
		return BitConverter.GetBytes(int_5);
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00002B7E File Offset: 0x00000D7E
	internal static long smethod_93(Stream stream_0)
	{
		return stream_0.Position;
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00002B89 File Offset: 0x00000D89
	internal static void smethod_94(IntPtr intptr_4, int int_5)
	{
		Marshal.WriteInt32(intptr_4, int_5);
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00002B98 File Offset: 0x00000D98
	internal static int smethod_95(IntPtr intptr_4)
	{
		return Class3.smethod_25(intptr_4);
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x00002BA3 File Offset: 0x00000DA3
	internal static void smethod_96(Hashtable hashtable_1, object object_3, object object_4)
	{
		hashtable_1.Add(object_3, object_4);
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x00002BB6 File Offset: 0x00000DB6
	internal static Type smethod_97(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00002BC1 File Offset: 0x00000DC1
	internal static int smethod_98(long long_2)
	{
		return Convert.ToInt32(long_2);
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00002BCC File Offset: 0x00000DCC
	internal static object smethod_99()
	{
		return Encoding.UTF8;
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00002BD3 File Offset: 0x00000DD3
	internal static object smethod_100(Encoding encoding_0, byte[] byte_2)
	{
		return encoding_0.GetString(byte_2);
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00002BE2 File Offset: 0x00000DE2
	internal static bool smethod_101(IntPtr intptr_4, IntPtr intptr_5)
	{
		return intptr_4 == intptr_5;
	}

	// Token: 0x060000DA RID: 218 RVA: 0x00002BF1 File Offset: 0x00000DF1
	internal static object smethod_102(IntPtr intptr_4, Type type_0)
	{
		return Class3.smethod_17(intptr_4, type_0);
	}

	// Token: 0x060000DB RID: 219 RVA: 0x00002C00 File Offset: 0x00000E00
	internal static IntPtr smethod_103(Class3.Delegate3 delegate3_0)
	{
		return delegate3_0();
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00002C0B File Offset: 0x00000E0B
	internal static int smethod_104(IntPtr intptr_4)
	{
		return Marshal.ReadInt32(intptr_4);
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00002C16 File Offset: 0x00000E16
	internal static long smethod_105(IntPtr intptr_4)
	{
		return Marshal.ReadInt64(intptr_4);
	}

	// Token: 0x060000DE RID: 222 RVA: 0x00002C21 File Offset: 0x00000E21
	internal static IntPtr smethod_106(Delegate delegate_0)
	{
		return Marshal.GetFunctionPointerForDelegate(delegate_0);
	}

	// Token: 0x060000DF RID: 223 RVA: 0x00002C2C File Offset: 0x00000E2C
	internal static int smethod_107(ProcessModule processModule_0)
	{
		return processModule_0.ModuleMemorySize;
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00002C37 File Offset: 0x00000E37
	internal static object smethod_108(Assembly assembly_1)
	{
		return assembly_1.EntryPoint;
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00002C42 File Offset: 0x00000E42
	internal static bool smethod_109(MethodInfo methodInfo_0, MethodInfo methodInfo_1)
	{
		return methodInfo_0 != methodInfo_1;
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00002C51 File Offset: 0x00000E51
	internal static object smethod_110(Delegate delegate_0)
	{
		return delegate_0.Method;
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00002C5C File Offset: 0x00000E5C
	internal static object smethod_111(Type type_0, MethodInfo methodInfo_0)
	{
		return Delegate.CreateDelegate(type_0, methodInfo_0);
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00002C6B File Offset: 0x00000E6B
	internal static object smethod_112(MethodBase methodBase_0)
	{
		return methodBase_0.GetParameters();
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x00002C76 File Offset: 0x00000E76
	internal static object smethod_113(Assembly assembly_1)
	{
		return assembly_1.ManifestModule;
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x00002C81 File Offset: 0x00000E81
	internal static ModuleHandle smethod_114(Module module_0)
	{
		return module_0.ModuleHandle;
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x00002C8C File Offset: 0x00000E8C
	internal static Type smethod_115(object object_3)
	{
		return object_3.GetType();
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x00002C97 File Offset: 0x00000E97
	internal static object smethod_116(FieldInfo fieldInfo_0, object object_3)
	{
		return fieldInfo_0.GetValue(object_3);
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x00002CA6 File Offset: 0x00000EA6
	internal static object smethod_117(long long_2)
	{
		return BitConverter.GetBytes(long_2);
	}

	// Token: 0x060000EA RID: 234 RVA: 0x00002CB1 File Offset: 0x00000EB1
	internal static void smethod_118(Delegate delegate_0)
	{
		RuntimeHelpers.PrepareDelegate(delegate_0);
	}

	// Token: 0x060000EB RID: 235 RVA: 0x00002CBC File Offset: 0x00000EBC
	internal static RuntimeMethodHandle smethod_119(MethodBase methodBase_0)
	{
		return methodBase_0.MethodHandle;
	}

	// Token: 0x060000EC RID: 236 RVA: 0x00002CC7 File Offset: 0x00000EC7
	internal static void smethod_120(RuntimeMethodHandle runtimeMethodHandle_0)
	{
		RuntimeHelpers.PrepareMethod(runtimeMethodHandle_0);
	}

	// Token: 0x060000ED RID: 237 RVA: 0x00002CD2 File Offset: 0x00000ED2
	internal static void smethod_121(Array array_0, RuntimeFieldHandle runtimeFieldHandle_0)
	{
		RuntimeHelpers.InitializeArray(array_0, runtimeFieldHandle_0);
	}

	// Token: 0x060000EE RID: 238 RVA: 0x00002CE1 File Offset: 0x00000EE1
	internal static IntPtr smethod_122(IntPtr intptr_4, uint uint_1, uint uint_2, uint uint_3)
	{
		return Class3.smethod_21(intptr_4, uint_1, uint_2, uint_3);
	}

	// Token: 0x060000EF RID: 239 RVA: 0x00002CF8 File Offset: 0x00000EF8
	internal static void smethod_123(IntPtr intptr_4, IntPtr intptr_5)
	{
		Marshal.WriteIntPtr(intptr_4, intptr_5);
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x00002888 File Offset: 0x00000A88
	internal static bool smethod_124()
	{
		return null == null;
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x0000288E File Offset: 0x00000A8E
	internal static object smethod_125()
	{
		return null;
	}

	// Token: 0x04000041 RID: 65
	internal static Assembly assembly_0 = typeof(Class3).Assembly;

	// Token: 0x04000042 RID: 66
	internal static object object_0 = null;

	// Token: 0x04000043 RID: 67
	private static uint[] uint_0 = new uint[]
	{
		3614090360U, 3905402710U, 606105819U, 3250441966U, 4118548399U, 1200080426U, 2821735955U, 4249261313U, 1770035416U, 2336552879U,
		4294925233U, 2304563134U, 1804603682U, 4254626195U, 2792965006U, 1236535329U, 4129170786U, 3225465664U, 643717713U, 3921069994U,
		3593408605U, 38016083U, 3634488961U, 3889429448U, 568446438U, 3275163606U, 4107603335U, 1163531501U, 2850285829U, 4243563512U,
		1735328473U, 2368359562U, 4294588738U, 2272392833U, 1839030562U, 4259657740U, 2763975236U, 1272893353U, 4139469664U, 3200236656U,
		681279174U, 3936430074U, 3572445317U, 76029189U, 3654602809U, 3873151461U, 530742520U, 3299628645U, 4096336452U, 1126891415U,
		2878612391U, 4237533241U, 1700485571U, 2399980690U, 4293915773U, 2240044497U, 1873313359U, 4264355552U, 2734768916U, 1309151649U,
		4149444226U, 3174756917U, 718787259U, 3951481745U
	};

	// Token: 0x04000044 RID: 68
	private static IntPtr intptr_0 = IntPtr.Zero;

	// Token: 0x04000045 RID: 69
	private static int int_0 = 1;

	// Token: 0x04000046 RID: 70
	[Class3.Attribute0(typeof(Class3.Attribute0.Class4<object>[]))]
	private static bool bool_0 = false;

	// Token: 0x04000047 RID: 71
	private static bool bool_1 = false;

	// Token: 0x04000048 RID: 72
	private static long long_0 = 0L;

	// Token: 0x04000049 RID: 73
	private static object object_1 = new object();

	// Token: 0x0400004A RID: 74
	private static Class3.Delegate4 delegate4_0 = null;

	// Token: 0x0400004B RID: 75
	private static Dictionary<int, int> dictionary_0 = null;

	// Token: 0x0400004C RID: 76
	private static Class3.Delegate6 delegate6_0 = null;

	// Token: 0x0400004D RID: 77
	private static bool bool_2 = false;

	// Token: 0x0400004E RID: 78
	private static int[] int_1 = new int[0];

	// Token: 0x0400004F RID: 79
	private static List<string> list_0 = null;

	// Token: 0x04000050 RID: 80
	private static int int_2 = 0;

	// Token: 0x04000051 RID: 81
	private static Class3.Delegate5 delegate5_0 = null;

	// Token: 0x04000052 RID: 82
	private static List<int> list_1 = null;

	// Token: 0x04000053 RID: 83
	internal static Class3.Delegate2 delegate2_0 = null;

	// Token: 0x04000054 RID: 84
	private static long long_1 = 0L;

	// Token: 0x04000055 RID: 85
	private static object object_2 = new object();

	// Token: 0x04000056 RID: 86
	private static Class3.Delegate9 delegate9_0 = null;

	// Token: 0x04000057 RID: 87
	private static int bMfxquQagN = 0;

	// Token: 0x04000058 RID: 88
	private static IntPtr intptr_1 = IntPtr.Zero;

	// Token: 0x04000059 RID: 89
	private static int int_3 = 0;

	// Token: 0x0400005A RID: 90
	private static IntPtr intptr_2 = IntPtr.Zero;

	// Token: 0x0400005B RID: 91
	private static byte[] byte_0 = new byte[0];

	// Token: 0x0400005C RID: 92
	private static Class3.Delegate7 delegate7_0 = null;

	// Token: 0x0400005D RID: 93
	internal static Hashtable hashtable_0 = new Hashtable();

	// Token: 0x0400005E RID: 94
	private static IntPtr intptr_3 = IntPtr.Zero;

	// Token: 0x0400005F RID: 95
	private static SortedList sortedList_0 = new SortedList();

	// Token: 0x04000060 RID: 96
	private static bool bool_3 = false;

	// Token: 0x04000061 RID: 97
	private static string[] string_0 = new string[0];

	// Token: 0x04000062 RID: 98
	private static int int_4 = 0;

	// Token: 0x04000063 RID: 99
	private static Class3.Delegate8 delegate8_0 = null;

	// Token: 0x04000064 RID: 100
	private static bool bool_4 = false;

	// Token: 0x04000065 RID: 101
	private static bool bool_5 = false;

	// Token: 0x04000066 RID: 102
	private static bool bool_6 = false;

	// Token: 0x04000067 RID: 103
	internal static Class3.Delegate2 delegate2_1 = null;

	// Token: 0x04000068 RID: 104
	private static byte[] byte_1 = new byte[0];

	// Token: 0x0200001D RID: 29
	// (Invoke) Token: 0x060000F3 RID: 243
	private delegate void Delegate1(object o);

	// Token: 0x0200001E RID: 30
	internal class Attribute0 : Attribute
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x00002D07 File Offset: 0x00000F07
		public Attribute0(object object_0)
		{
		}

		// Token: 0x0200001F RID: 31
		internal class Class4<T>
		{
			// Token: 0x060000F8 RID: 248 RVA: 0x00002D0F File Offset: 0x00000F0F
			internal static bool smethod_0()
			{
				return Class3.Attribute0.Class4<T>.object_0 == null;
			}

			// Token: 0x060000F9 RID: 249 RVA: 0x00002D19 File Offset: 0x00000F19
			internal static object smethod_1()
			{
				return Class3.Attribute0.Class4<T>.object_0;
			}

			// Token: 0x04000069 RID: 105
			internal static object object_0;
		}
	}

	// Token: 0x02000020 RID: 32
	internal class Class5
	{
		// Token: 0x060000FA RID: 250 RVA: 0x0000AA2C File Offset: 0x00008C2C
		internal static string smethod_0(string string_0, string string_1)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(string_0);
			byte[] array = new byte[]
			{
				82, 102, 104, 110, 32, 77, 24, 34, 118, 181,
				51, 17, 18, 51, 12, 109, 10, 32, 77, 24,
				34, 158, 161, 41, 97, 28, 118, 181, 5, 25,
				1, 88
			};
			byte[] array2 = Class3.smethod_9(Encoding.Unicode.GetBytes(string_1));
			MemoryStream memoryStream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = Class3.smethod_7();
			symmetricAlgorithm.Key = array;
			symmetricAlgorithm.IV = array2;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}

	// Token: 0x02000021 RID: 33
	// (Invoke) Token: 0x060000FD RID: 253
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate uint Delegate2(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

	// Token: 0x02000022 RID: 34
	// (Invoke) Token: 0x06000101 RID: 257
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate3();

	// Token: 0x02000023 RID: 35
	internal struct Struct3
	{
		// Token: 0x0400006A RID: 106
		internal bool bool_0;

		// Token: 0x0400006B RID: 107
		internal byte[] byte_0;
	}

	// Token: 0x02000024 RID: 36
	internal class Class6
	{
		// Token: 0x06000104 RID: 260 RVA: 0x00002D20 File Offset: 0x00000F20
		public Class6(Stream stream_0)
		{
			this.binaryReader_0 = new BinaryReader(stream_0);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00002D34 File Offset: 0x00000F34
		internal Stream method_0()
		{
			return this.binaryReader_0.BaseStream;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00002D41 File Offset: 0x00000F41
		internal byte[] method_1(int int_0)
		{
			return this.binaryReader_0.ReadBytes(int_0);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00002D4F File Offset: 0x00000F4F
		internal int method_2(byte[] byte_0, int int_0, int int_1)
		{
			return this.binaryReader_0.Read(byte_0, int_0, int_1);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00002D5F File Offset: 0x00000F5F
		internal int method_3()
		{
			return this.binaryReader_0.ReadInt32();
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00002D6C File Offset: 0x00000F6C
		internal void method_4()
		{
			this.binaryReader_0.Close();
		}

		// Token: 0x0400006C RID: 108
		private BinaryReader binaryReader_0;
	}

	// Token: 0x02000025 RID: 37
	// (Invoke) Token: 0x0600010B RID: 267
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private delegate IntPtr Delegate4(IntPtr hModule, string lpName, uint lpType);

	// Token: 0x02000026 RID: 38
	// (Invoke) Token: 0x0600010F RID: 271
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate5(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

	// Token: 0x02000027 RID: 39
	// (Invoke) Token: 0x06000113 RID: 275
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Delegate6(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

	// Token: 0x02000028 RID: 40
	// (Invoke) Token: 0x06000117 RID: 279
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Delegate7(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

	// Token: 0x02000029 RID: 41
	// (Invoke) Token: 0x0600011B RID: 283
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate8(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

	// Token: 0x0200002A RID: 42
	// (Invoke) Token: 0x0600011F RID: 287
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Delegate9(IntPtr ptr);

	// Token: 0x0200002B RID: 43
	[Flags]
	private enum Enum0
	{

	}
}
