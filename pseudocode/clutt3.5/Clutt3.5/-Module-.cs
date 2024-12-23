using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

// Token: 0x02000001 RID: 1
internal class <Module>
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002498 File Offset: 0x00000698
	static <Module>()
	{
		<Module>.smethod_4();
		<Module>.smethod_2();
		<Module>.smethod_0();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002A64 File Offset: 0x00000C64
	private static void smethod_0()
	{
		string text = "COR";
		Type typeFromHandle = typeof(Environment);
		MethodInfo method = typeFromHandle.GetMethod("GetEnvironmentVariable", new Type[] { typeof(string) });
		if (method != null && (method.Invoke(null, new object[] { text + "_PROFILER" }) != null || method.Invoke(null, new object[] { text + "_ENABLE_PROFILING" }) != null))
		{
			Environment.FailFast(null);
		}
		new Thread(new ParameterizedThreadStart(<Module>.smethod_1))
		{
			IsBackground = true
		}.Start(null);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002B14 File Offset: 0x00000D14
	private static void smethod_1(object object_0)
	{
		Thread thread = object_0 as Thread;
		if (thread == null)
		{
			thread = new Thread(new ParameterizedThreadStart(<Module>.smethod_1));
			thread.IsBackground = true;
			thread.Start(Thread.CurrentThread);
			Thread.Sleep(500);
		}
		for (;;)
		{
			if (Debugger.IsAttached)
			{
				goto IL_41;
			}
			if (Debugger.IsLogging())
			{
				goto IL_41;
			}
			IL_47:
			if (!thread.IsAlive)
			{
				Environment.FailFast(null);
			}
			Thread.Sleep(1000);
			continue;
			IL_41:
			Environment.FailFast(null);
			goto IL_47;
		}
	}

	// Token: 0x06000004 RID: 4
	[DllImport("kernel32.dll")]
	internal unsafe static extern bool VirtualProtect(byte* pByte_0, int int_0, uint uint_0, ref uint uint_1);

	// Token: 0x06000005 RID: 5 RVA: 0x00002B88 File Offset: 0x00000D88
	internal unsafe static void smethod_2()
	{
		Module module = typeof(<Module>).Module;
		byte* ptr = (byte*)(void*)Marshal.GetHINSTANCE(module);
		byte* ptr2 = ptr + 60;
		ptr2 = ptr + *(uint*)ptr2;
		ptr2 += 6;
		ushort num = *(ushort*)ptr2;
		ptr2 += 14;
		ushort num2 = *(ushort*)ptr2;
		ptr2 = ptr2 + 4 + num2;
		byte* ptr3 = stackalloc byte[(UIntPtr)11];
		uint num5;
		if (module.FullyQualifiedName[0] == '<')
		{
			uint num3 = *(uint*)(ptr2 - 16);
			uint num4 = *(uint*)(ptr2 - 120);
			uint[] array = new uint[(int)num];
			uint[] array2 = new uint[(int)num];
			uint[] array3 = new uint[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				<Module>.VirtualProtect(ptr2, 8, 64U, ref num5);
				Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr2), 8);
				array[i] = *(uint*)(ptr2 + 12);
				array2[i] = *(uint*)(ptr2 + 8);
				array3[i] = *(uint*)(ptr2 + 20);
				ptr2 += 40;
			}
			if (num4 != 0U)
			{
				for (int j = 0; j < (int)num; j++)
				{
					if (array[j] <= num4 && num4 < array[j] + array2[j])
					{
						num4 = num4 - array[j] + array3[j];
						break;
					}
				}
				byte* ptr4 = ptr + num4;
				uint num6 = *(uint*)ptr4;
				for (int k = 0; k < (int)num; k++)
				{
					if (array[k] <= num6 && num6 < array[k] + array2[k])
					{
						num6 = num6 - array[k] + array3[k];
						break;
					}
				}
				byte* ptr5 = ptr + num6;
				uint num7 = *(uint*)(ptr4 + 12);
				for (int l = 0; l < (int)num; l++)
				{
					if (array[l] <= num7 && num7 < array[l] + array2[l])
					{
						num7 = num7 - array[l] + array3[l];
						break;
					}
				}
				uint num8 = *(uint*)ptr5 + 2U;
				for (int m = 0; m < (int)num; m++)
				{
					if (array[m] <= num8 && num8 < array[m] + array2[m])
					{
						num8 = num8 - array[m] + array3[m];
						IL_1E8:
						<Module>.VirtualProtect(ptr + num7, 11, 64U, ref num5);
						*(int*)ptr3 = 1818522734;
						*(int*)(ptr3 + 4) = 1818504812;
						*(short*)(ptr3 + 8) = 108;
						ptr3[10] = 0;
						for (int n = 0; n < 11; n++)
						{
							(ptr + num7)[n] = ptr3[n];
						}
						<Module>.VirtualProtect(ptr + num8, 11, 64U, ref num5);
						*(int*)ptr3 = 1866691662;
						*(int*)(ptr3 + 4) = 1852404846;
						*(short*)(ptr3 + 8) = 25973;
						ptr3[10] = 0;
						for (int num9 = 0; num9 < 11; num9++)
						{
							(ptr + num8)[num9] = ptr3[num9];
						}
						goto IL_28F;
					}
				}
				goto IL_1E8;
			}
			IL_28F:
			for (int num10 = 0; num10 < (int)num; num10++)
			{
				if (array[num10] <= num3 && num3 < array[num10] + array2[num10])
				{
					num3 = num3 - array[num10] + array3[num10];
					IL_2C9:
					byte* ptr6 = ptr + num3;
					<Module>.VirtualProtect(ptr6, 72, 64U, ref num5);
					uint num11 = *(uint*)(ptr6 + 8);
					for (int num12 = 0; num12 < (int)num; num12++)
					{
						if (array[num12] <= num11 && num11 < array[num12] + array2[num12])
						{
							num11 = num11 - array[num12] + array3[num12];
							break;
						}
					}
					*(int*)ptr6 = 0;
					*(int*)(ptr6 + 4) = 0;
					*(int*)(ptr6 + 8) = 0;
					*(int*)(ptr6 + 12) = 0;
					byte* ptr7 = ptr + num11;
					<Module>.VirtualProtect(ptr7, 4, 64U, ref num5);
					*(int*)ptr7 = 0;
					ptr7 += 12;
					ptr7 += *(uint*)ptr7;
					ptr7 = (ptr7 + 7U) & -4L;
					ptr7 += 2;
					ushort num13 = (ushort)(*ptr7);
					ptr7 += 2;
					int num14 = 0;
					IL_422:
					while (num14 < (int)num13)
					{
						<Module>.VirtualProtect(ptr7, 8, 64U, ref num5);
						ptr7 += 4;
						ptr7 += 4;
						int num15 = 0;
						while (num15 < 8)
						{
							<Module>.VirtualProtect(ptr7, 4, 64U, ref num5);
							*ptr7 = 0;
							ptr7++;
							if (*ptr7 != 0)
							{
								*ptr7 = 0;
								ptr7++;
								if (*ptr7 != 0)
								{
									*ptr7 = 0;
									ptr7++;
									if (*ptr7 != 0)
									{
										*ptr7 = 0;
										ptr7++;
										num15++;
										continue;
									}
									ptr7++;
								}
								else
								{
									ptr7 += 2;
								}
							}
							else
							{
								ptr7 += 3;
							}
							IL_41C:
							num14++;
							goto IL_422;
						}
						goto IL_41C;
					}
					return;
				}
			}
			goto IL_2C9;
		}
		byte* ptr8 = ptr + *(uint*)(ptr2 - 16);
		if (*(uint*)(ptr2 - 120) != 0U)
		{
			byte* ptr9 = ptr + *(uint*)(ptr2 - 120);
			byte* ptr10 = ptr + *(uint*)ptr9;
			byte* ptr11 = ptr + *(uint*)(ptr9 + 12);
			byte* ptr12 = ptr + *(uint*)ptr10 + 2;
			<Module>.VirtualProtect(ptr11, 11, 64U, ref num5);
			*(int*)ptr3 = 1818522734;
			*(int*)(ptr3 + 4) = 1818504812;
			*(short*)(ptr3 + 8) = 108;
			ptr3[10] = 0;
			for (int num16 = 0; num16 < 11; num16++)
			{
				ptr11[num16] = ptr3[num16];
			}
			<Module>.VirtualProtect(ptr12, 11, 64U, ref num5);
			*(int*)ptr3 = 1866691662;
			*(int*)(ptr3 + 4) = 1852404846;
			*(short*)(ptr3 + 8) = 25973;
			ptr3[10] = 0;
			for (int num17 = 0; num17 < 11; num17++)
			{
				ptr12[num17] = ptr3[num17];
			}
		}
		for (int num18 = 0; num18 < (int)num; num18++)
		{
			<Module>.VirtualProtect(ptr2, 8, 64U, ref num5);
			Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr2), 8);
			ptr2 += 40;
		}
		<Module>.VirtualProtect(ptr8, 72, 64U, ref num5);
		byte* ptr13 = ptr + *(uint*)(ptr8 + 8);
		*(int*)ptr8 = 0;
		*(int*)(ptr8 + 4) = 0;
		*(int*)(ptr8 + 8) = 0;
		*(int*)(ptr8 + 12) = 0;
		<Module>.VirtualProtect(ptr13, 4, 64U, ref num5);
		*(int*)ptr13 = 0;
		ptr13 += 12;
		ptr13 += *(uint*)ptr13;
		ptr13 = (ptr13 + 7U) & -4L;
		ptr13 += 2;
		ushort num19 = (ushort)(*ptr13);
		ptr13 += 2;
		for (int num20 = 0; num20 < (int)num19; num20++)
		{
			<Module>.VirtualProtect(ptr13, 8, 64U, ref num5);
			ptr13 += 4;
			ptr13 += 4;
			for (int num21 = 0; num21 < 8; num21++)
			{
				<Module>.VirtualProtect(ptr13, 4, 64U, ref num5);
				*ptr13 = 0;
				ptr13++;
				if (*ptr13 == 0)
				{
					ptr13 += 3;
					break;
				}
				*ptr13 = 0;
				ptr13++;
				if (*ptr13 == 0)
				{
					ptr13 += 2;
					break;
				}
				*ptr13 = 0;
				ptr13++;
				if (*ptr13 == 0)
				{
					ptr13++;
					break;
				}
				*ptr13 = 0;
				ptr13++;
			}
		}
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000031F0 File Offset: 0x000013F0
	internal static byte[] smethod_3(byte[] byte_0)
	{
		MemoryStream memoryStream = new MemoryStream(byte_0);
		<Module>.Class1 @class = new <Module>.Class1();
		byte[] array = new byte[5];
		memoryStream.Read(array, 0, 5);
		@class.method_5(array);
		long num = 0L;
		for (int i = 0; i < 8; i++)
		{
			int num2 = memoryStream.ReadByte();
			num |= (long)((long)((ulong)((byte)num2)) << 8 * i);
		}
		byte[] array2 = new byte[(int)num];
		MemoryStream memoryStream2 = new MemoryStream(array2, true);
		long num3 = memoryStream.Length - 13L;
		@class.method_4(memoryStream, memoryStream2, num3, num);
		return array2;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00003288 File Offset: 0x00001488
	internal static void smethod_4()
	{
		uint num = 112U;
		uint[] array = new uint[]
		{
			46077302U, 616366295U, 985277704U, 513667272U, 2982135181U, 3787418626U, 2353504712U, 939311098U, 2940973911U, 1035543746U,
			3262551805U, 843412504U, 2637994338U, 3267381512U, 1649705281U, 983441133U, 1165679111U, 106350844U, 3237731149U, 1813162363U,
			3728723081U, 618725432U, 614179996U, 1811328733U, 370818248U, 474562942U, 3357422051U, 3258434936U, 103019530U, 1574418554U,
			1275203023U, 3360333736U, 1799854922U, 2156800930U, 3442440933U, 2267886526U, 1171704900U, 4088853488U, 2147828602U, 347556821U,
			1475730734U, 895976165U, 3539809439U, 3723445763U, 1283578111U, 1263025902U, 2315167527U, 2267590751U, 2006385958U, 1592839228U,
			345061697U, 1214367009U, 1678203287U, 1293888377U, 2240212782U, 2501403784U, 2880968874U, 1889596141U, 677995806U, 1421600049U,
			88665141U, 3775034425U, 1811761952U, 1207211327U, 2898641514U, 2320169753U, 3453710799U, 3053934531U, 3864453464U, 4157951496U,
			3599543126U, 2952116890U, 1548479672U, 2605286531U, 4011981328U, 713264942U, 3084895177U, 301375106U, 3347393781U, 3804668108U,
			738667380U, 1190356617U, 2752969242U, 3849306674U, 3051993087U, 3997245084U, 2050371434U, 233042175U, 934088475U, 3115842303U,
			3180890304U, 3774518924U, 1778815975U, 3388539513U, 2560578909U, 2154869316U, 1126707091U, 3942925983U, 4291396645U, 824174189U,
			448182260U, 462999993U, 2050371417U, 233042175U, 934088475U, 3115842303U, 3180890304U, 3774518924U, 1778815975U, 3388539513U,
			2560578909U, 2154869316U
		};
		uint[] array2 = new uint[16];
		uint num2 = 4105744638U;
		for (int i = 0; i < 16; i++)
		{
			num2 ^= num2 >> 13;
			num2 ^= num2 << 25;
			num2 ^= num2 >> 27;
			array2[i] = num2;
		}
		int num3 = 0;
		int num4 = 0;
		uint[] array3 = new uint[16];
		byte[] array4 = new byte[num * 4U];
		while ((long)num3 < (long)((ulong)num))
		{
			for (int j = 0; j < 16; j++)
			{
				array3[j] = array[num3 + j];
			}
			array3[0] = array3[0] ^ array2[0];
			array3[1] = array3[1] ^ array2[1];
			array3[2] = array3[2] ^ array2[2];
			array3[3] = array3[3] ^ array2[3];
			array3[4] = array3[4] ^ array2[4];
			array3[5] = array3[5] ^ array2[5];
			array3[6] = array3[6] ^ array2[6];
			array3[7] = array3[7] ^ array2[7];
			array3[8] = array3[8] ^ array2[8];
			array3[9] = array3[9] ^ array2[9];
			array3[10] = array3[10] ^ array2[10];
			array3[11] = array3[11] ^ array2[11];
			array3[12] = array3[12] ^ array2[12];
			array3[13] = array3[13] ^ array2[13];
			array3[14] = array3[14] ^ array2[14];
			array3[15] = array3[15] ^ array2[15];
			for (int k = 0; k < 16; k++)
			{
				uint num5 = array3[k];
				array4[num4++] = (byte)num5;
				array4[num4++] = (byte)(num5 >> 8);
				array4[num4++] = (byte)(num5 >> 16);
				array4[num4++] = (byte)(num5 >> 24);
				array2[k] ^= num5;
			}
			num3 += 16;
		}
		<Module>.assembly_0 = Assembly.Load(<Module>.smethod_3(array4));
		AppDomain.CurrentDomain.ResourceResolve += <Module>.smethod_5;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000034A0 File Offset: 0x000016A0
	internal static Assembly smethod_5(object object_0, ResolveEventArgs resolveEventArgs_0)
	{
		string[] manifestResourceNames = <Module>.assembly_0.GetManifestResourceNames();
		if (Array.IndexOf<string>(manifestResourceNames, resolveEventArgs_0.Name) != -1)
		{
			return <Module>.assembly_0;
		}
		return null;
	}

	// Token: 0x06000009 RID: 9
	[DllImport("kernel32.dll", EntryPoint = "VirtualProtect")]
	internal static extern bool VirtualProtect_1(IntPtr intptr_0, uint uint_0, uint uint_1, ref uint uint_2);

	// Token: 0x0600000A RID: 10 RVA: 0x000034D0 File Offset: 0x000016D0
	internal unsafe static void smethod_6()
	{
		Module module = typeof(<Module>).Module;
		string fullyQualifiedName = module.FullyQualifiedName;
		bool flag = fullyQualifiedName.Length > 0 && fullyQualifiedName[0] == '<';
		byte* ptr = (byte*)(void*)Marshal.GetHINSTANCE(module);
		byte* ptr2 = ptr + *(uint*)(ptr + 60);
		ushort num = *(ushort*)(ptr2 + 6);
		ushort num2 = *(ushort*)(ptr2 + 20);
		uint* ptr3 = null;
		uint num3 = 0U;
		uint* ptr4 = (uint*)(ptr2 + 24 + num2);
		uint num4 = 155365708U;
		uint num5 = 1161453308U;
		uint num6 = 2906554038U;
		uint num7 = 2031137454U;
		for (int i = 0; i < (int)num; i++)
		{
			uint num8 = *(ptr4++) * *(ptr4++);
			if (num8 != 2032062952U)
			{
				if (num8 != 0U)
				{
					uint* ptr5 = (uint*)(ptr + (flag ? ptr4[3] : ptr4[1]) / 4U);
					uint num9 = ptr4[2] >> 2;
					for (uint num10 = 0U; num10 < num9; num10 += 1U)
					{
						uint num11 = (num4 ^ *(ptr5++)) + num5 + num6 * num7;
						num4 = num5;
						num5 = num7;
						num7 = num11;
					}
				}
			}
			else
			{
				ptr3 = (uint*)(ptr + (flag ? ptr4[3] : ptr4[1]) / 4U);
				num3 = (flag ? ptr4[2] : (*ptr4)) >> 2;
			}
			ptr4 += 8;
		}
		uint[] array = new uint[16];
		uint[] array2 = new uint[16];
		for (int j = 0; j < 16; j++)
		{
			array[j] = num7;
			array2[j] = num5;
			num4 = (num5 >> 5) | (num5 << 27);
			num5 = (num6 >> 3) | (num6 << 29);
			num6 = (num7 >> 7) | (num7 << 25);
			num7 = (num4 >> 11) | (num4 << 21);
		}
		array[0] = array[0] ^ array2[0];
		array[1] = array[1] * array2[1];
		array[2] = array[2] + array2[2];
		array[3] = array[3] ^ array2[3];
		array[4] = array[4] * array2[4];
		array[5] = array[5] + array2[5];
		array[6] = array[6] ^ array2[6];
		array[7] = array[7] * array2[7];
		array[8] = array[8] + array2[8];
		array[9] = array[9] ^ array2[9];
		array[10] = array[10] * array2[10];
		array[11] = array[11] + array2[11];
		array[12] = array[12] ^ array2[12];
		array[13] = array[13] * array2[13];
		array[14] = array[14] + array2[14];
		array[15] = array[15] ^ array2[15];
		uint num12 = 64U;
		<Module>.VirtualProtect_1((IntPtr)((void*)ptr3), num3 << 2, 64U, ref num12);
		uint num13 = 0U;
		for (uint num14 = 0U; num14 < num3; num14 += 1U)
		{
			*ptr3 ^= array[(int)((UIntPtr)(num13 & 15U))];
			array[(int)((UIntPtr)(num13 & 15U))] = (array[(int)((UIntPtr)(num13 & 15U))] ^ *(ptr3++)) + 1035675673U;
			num13 += 1U;
		}
	}

	// Token: 0x04000001 RID: 1
	internal static Assembly assembly_0;

	// Token: 0x04000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
	internal static <Module>.Struct4 struct4_0;

	// Token: 0x02000002 RID: 2
	internal struct Struct0
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000024AA File Offset: 0x000006AA
		internal void method_0()
		{
			this.uint_0 = 1024U;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000037D4 File Offset: 0x000019D4
		internal uint method_1(<Module>.Class0 class0_0)
		{
			uint num = (class0_0.uint_1 >> 11) * this.uint_0;
			if (class0_0.uint_0 < num)
			{
				class0_0.uint_1 = num;
				this.uint_0 += 2048U - this.uint_0 >> 5;
				if (class0_0.uint_1 < 16777216U)
				{
					class0_0.uint_0 = (class0_0.uint_0 << 8) | (uint)((byte)class0_0.stream_0.ReadByte());
					class0_0.uint_1 <<= 8;
				}
				return 0U;
			}
			class0_0.uint_1 -= num;
			class0_0.uint_0 -= num;
			this.uint_0 -= this.uint_0 >> 5;
			if (class0_0.uint_1 < 16777216U)
			{
				class0_0.uint_0 = (class0_0.uint_0 << 8) | (uint)((byte)class0_0.stream_0.ReadByte());
				class0_0.uint_1 <<= 8;
			}
			return 1U;
		}

		// Token: 0x04000003 RID: 3
		internal uint uint_0;
	}

	// Token: 0x02000003 RID: 3
	internal struct Struct1
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000024B7 File Offset: 0x000006B7
		internal Struct1(int int_1)
		{
			this.int_0 = int_1;
			this.struct0_0 = new <Module>.Struct0[1 << int_1];
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000038C0 File Offset: 0x00001AC0
		internal void method_0()
		{
			uint num = 1U;
			while ((ulong)num < (ulong)(1L << (this.int_0 & 31)))
			{
				this.struct0_0[(int)((UIntPtr)num)].method_0();
				num += 1U;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000038F8 File Offset: 0x00001AF8
		internal uint method_1(<Module>.Class0 class0_0)
		{
			uint num = 1U;
			for (int i = this.int_0; i > 0; i--)
			{
				num = (num << 1) + this.struct0_0[(int)((UIntPtr)num)].method_1(class0_0);
			}
			return num - (1U << this.int_0);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00003940 File Offset: 0x00001B40
		internal uint method_2(<Module>.Class0 class0_0)
		{
			uint num = 1U;
			uint num2 = 0U;
			for (int i = 0; i < this.int_0; i++)
			{
				uint num3 = this.struct0_0[(int)((UIntPtr)num)].method_1(class0_0);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003988 File Offset: 0x00001B88
		internal static uint smethod_0(<Module>.Struct0[] struct0_1, uint uint_0, <Module>.Class0 class0_0, int int_1)
		{
			uint num = 1U;
			uint num2 = 0U;
			for (int i = 0; i < int_1; i++)
			{
				uint num3 = struct0_1[(int)((UIntPtr)(uint_0 + num))].method_1(class0_0);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		// Token: 0x04000004 RID: 4
		internal readonly <Module>.Struct0[] struct0_0;

		// Token: 0x04000005 RID: 5
		internal readonly int int_0;
	}

	// Token: 0x02000004 RID: 4
	internal class Class0
	{
		// Token: 0x06000012 RID: 18 RVA: 0x000039C8 File Offset: 0x00001BC8
		internal void method_0(Stream stream_1)
		{
			this.stream_0 = stream_1;
			this.uint_0 = 0U;
			this.uint_1 = uint.MaxValue;
			for (int i = 0; i < 5; i++)
			{
				this.uint_0 = (this.uint_0 << 8) | (uint)((byte)this.stream_0.ReadByte());
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000024D1 File Offset: 0x000006D1
		internal void method_1()
		{
			this.stream_0 = null;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000024DA File Offset: 0x000006DA
		internal void method_2()
		{
			while (this.uint_1 < 16777216U)
			{
				this.uint_0 = (this.uint_0 << 8) | (uint)((byte)this.stream_0.ReadByte());
				this.uint_1 <<= 8;
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003A14 File Offset: 0x00001C14
		internal uint method_3(int int_0)
		{
			uint num = this.uint_1;
			uint num2 = this.uint_0;
			uint num3 = 0U;
			for (int i = int_0; i > 0; i--)
			{
				num >>= 1;
				uint num4 = num2 - num >> 31;
				num2 -= num & (num4 - 1U);
				num3 = (num3 << 1) | (1U - num4);
				if (num < 16777216U)
				{
					num2 = (num2 << 8) | (uint)((byte)this.stream_0.ReadByte());
					num <<= 8;
				}
			}
			this.uint_1 = num;
			this.uint_0 = num2;
			return num3;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002515 File Offset: 0x00000715
		internal Class0()
		{
		}

		// Token: 0x04000006 RID: 6
		internal uint uint_0;

		// Token: 0x04000007 RID: 7
		internal uint uint_1;

		// Token: 0x04000008 RID: 8
		internal Stream stream_0;
	}

	// Token: 0x02000005 RID: 5
	internal class Class1
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00003A88 File Offset: 0x00001C88
		internal Class1()
		{
			this.uint_0 = uint.MaxValue;
			int num = 0;
			while ((long)num < 4L)
			{
				this.struct1_0[num] = new <Module>.Struct1(6);
				num++;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003B88 File Offset: 0x00001D88
		internal void method_0(uint uint_3)
		{
			if (this.uint_0 != uint_3)
			{
				this.uint_0 = uint_3;
				this.uint_1 = Math.Max(this.uint_0, 1U);
				uint num = Math.Max(this.uint_1, 4096U);
				this.class4_0.method_0(num);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000251D File Offset: 0x0000071D
		internal void method_1(int int_0, int int_1)
		{
			this.class3_0.method_0(int_0, int_1);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003BD4 File Offset: 0x00001DD4
		internal void method_2(int int_0)
		{
			uint num = 1U << int_0;
			this.class2_0.method_0(num);
			this.class2_1.method_0(num);
			this.uint_2 = num - 1U;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003C0C File Offset: 0x00001E0C
		internal void method_3(Stream stream_0, Stream stream_1)
		{
			this.class0_0.method_0(stream_0);
			this.class4_0.method_1(stream_1, this.bool_0);
			for (uint num = 0U; num < 12U; num += 1U)
			{
				for (uint num2 = 0U; num2 <= this.uint_2; num2 += 1U)
				{
					uint num3 = (num << 4) + num2;
					this.struct0_0[(int)((UIntPtr)num3)].method_0();
					this.struct0_1[(int)((UIntPtr)num3)].method_0();
				}
				this.struct0_2[(int)((UIntPtr)num)].method_0();
				this.struct0_3[(int)((UIntPtr)num)].method_0();
				this.struct0_4[(int)((UIntPtr)num)].method_0();
				this.struct0_5[(int)((UIntPtr)num)].method_0();
			}
			this.class3_0.method_1();
			for (uint num = 0U; num < 4U; num += 1U)
			{
				this.struct1_0[(int)((UIntPtr)num)].method_0();
			}
			for (uint num = 0U; num < 114U; num += 1U)
			{
				this.struct0_6[(int)((UIntPtr)num)].method_0();
			}
			this.class2_0.method_1();
			this.class2_1.method_1();
			this.struct1_1.method_0();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003D38 File Offset: 0x00001F38
		internal void method_4(Stream stream_0, Stream stream_1, long long_0, long long_1)
		{
			this.method_3(stream_0, stream_1);
			<Module>.Struct3 @struct = default(<Module>.Struct3);
			@struct.method_0();
			uint num = 0U;
			uint num2 = 0U;
			uint num3 = 0U;
			uint num4 = 0U;
			ulong num5 = 0UL;
			if (0L < long_1)
			{
				this.struct0_0[(int)((UIntPtr)(@struct.uint_0 << 4))].method_1(this.class0_0);
				@struct.method_1();
				byte b = this.class3_0.method_3(this.class0_0, 0U, 0);
				this.class4_0.method_5(b);
				num5 += 1UL;
			}
			while (num5 < (ulong)long_1)
			{
				uint num6 = (uint)num5 & this.uint_2;
				if (this.struct0_0[(int)((UIntPtr)((@struct.uint_0 << 4) + num6))].method_1(this.class0_0) == 0U)
				{
					byte b2 = this.class4_0.method_6(0U);
					byte b3;
					if (@struct.method_5())
					{
						b3 = this.class3_0.method_3(this.class0_0, (uint)num5, b2);
					}
					else
					{
						b3 = this.class3_0.method_4(this.class0_0, (uint)num5, b2, this.class4_0.method_6(num));
					}
					this.class4_0.method_5(b3);
					@struct.method_1();
					num5 += 1UL;
				}
				else
				{
					uint num8;
					if (this.struct0_2[(int)((UIntPtr)@struct.uint_0)].method_1(this.class0_0) == 1U)
					{
						if (this.struct0_3[(int)((UIntPtr)@struct.uint_0)].method_1(this.class0_0) != 0U)
						{
							uint num7;
							if (this.struct0_4[(int)((UIntPtr)@struct.uint_0)].method_1(this.class0_0) == 0U)
							{
								num7 = num2;
							}
							else
							{
								if (this.struct0_5[(int)((UIntPtr)@struct.uint_0)].method_1(this.class0_0) != 0U)
								{
									num7 = num4;
									num4 = num3;
								}
								else
								{
									num7 = num3;
								}
								num3 = num2;
							}
							num2 = num;
							num = num7;
						}
						else if (this.struct0_1[(int)((UIntPtr)((@struct.uint_0 << 4) + num6))].method_1(this.class0_0) == 0U)
						{
							@struct.method_4();
							this.class4_0.method_5(this.class4_0.method_6(num));
							num5 += 1UL;
							continue;
						}
						num8 = this.class2_1.method_2(this.class0_0, num6) + 2U;
						@struct.method_3();
					}
					else
					{
						num4 = num3;
						num3 = num2;
						num2 = num;
						num8 = 2U + this.class2_0.method_2(this.class0_0, num6);
						@struct.method_2();
						uint num9 = this.struct1_0[(int)((UIntPtr)<Module>.Class1.smethod_0(num8))].method_1(this.class0_0);
						if (num9 >= 4U)
						{
							int num10 = (int)((num9 >> 1) - 1U);
							num = (2U | (num9 & 1U)) << num10;
							if (num9 >= 14U)
							{
								num += this.class0_0.method_3(num10 - 4) << 4;
								num += this.struct1_1.method_2(this.class0_0);
							}
							else
							{
								num += <Module>.Struct1.smethod_0(this.struct0_6, num - num9 - 1U, this.class0_0, num10);
							}
						}
						else
						{
							num = num9;
						}
					}
					if (((ulong)num >= num5 || num >= this.uint_1) && num == 4294967295U)
					{
						break;
					}
					this.class4_0.method_4(num, num8);
					num5 += (ulong)num8;
				}
			}
			this.class4_0.method_3();
			this.class4_0.method_2();
			this.class0_0.method_1();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000040A8 File Offset: 0x000022A8
		internal void method_5(byte[] byte_0)
		{
			int num = (int)(byte_0[0] % 9);
			int num2 = (int)(byte_0[0] / 9);
			int num3 = num2 % 5;
			int num4 = num2 / 5;
			uint num5 = 0U;
			for (int i = 0; i < 4; i++)
			{
				num5 += (uint)((uint)byte_0[1 + i] << i * 8);
			}
			this.method_0(num5);
			this.method_1(num3, num);
			this.method_2(num4);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000252C File Offset: 0x0000072C
		internal static uint smethod_0(uint uint_3)
		{
			uint_3 -= 2U;
			if (uint_3 >= 4U)
			{
				return 3U;
			}
			return uint_3;
		}

		// Token: 0x04000009 RID: 9
		internal readonly <Module>.Struct0[] struct0_0 = new <Module>.Struct0[192];

		// Token: 0x0400000A RID: 10
		internal readonly <Module>.Struct0[] struct0_1 = new <Module>.Struct0[192];

		// Token: 0x0400000B RID: 11
		internal readonly <Module>.Struct0[] struct0_2 = new <Module>.Struct0[12];

		// Token: 0x0400000C RID: 12
		internal readonly <Module>.Struct0[] struct0_3 = new <Module>.Struct0[12];

		// Token: 0x0400000D RID: 13
		internal readonly <Module>.Struct0[] struct0_4 = new <Module>.Struct0[12];

		// Token: 0x0400000E RID: 14
		internal readonly <Module>.Struct0[] struct0_5 = new <Module>.Struct0[12];

		// Token: 0x0400000F RID: 15
		internal readonly <Module>.Class1.Class2 class2_0 = new <Module>.Class1.Class2();

		// Token: 0x04000010 RID: 16
		internal readonly <Module>.Class1.Class3 class3_0 = new <Module>.Class1.Class3();

		// Token: 0x04000011 RID: 17
		internal readonly <Module>.Class4 class4_0 = new <Module>.Class4();

		// Token: 0x04000012 RID: 18
		internal readonly <Module>.Struct0[] struct0_6 = new <Module>.Struct0[114];

		// Token: 0x04000013 RID: 19
		internal readonly <Module>.Struct1[] struct1_0 = new <Module>.Struct1[4];

		// Token: 0x04000014 RID: 20
		internal readonly <Module>.Class0 class0_0 = new <Module>.Class0();

		// Token: 0x04000015 RID: 21
		internal readonly <Module>.Class1.Class2 class2_1 = new <Module>.Class1.Class2();

		// Token: 0x04000016 RID: 22
		internal bool bool_0;

		// Token: 0x04000017 RID: 23
		internal uint uint_0;

		// Token: 0x04000018 RID: 24
		internal uint uint_1;

		// Token: 0x04000019 RID: 25
		internal <Module>.Struct1 struct1_1 = new <Module>.Struct1(4);

		// Token: 0x0400001A RID: 26
		internal uint uint_2;

		// Token: 0x02000006 RID: 6
		internal class Class2
		{
			// Token: 0x0600001F RID: 31 RVA: 0x00004108 File Offset: 0x00002308
			internal void method_0(uint uint_1)
			{
				for (uint num = this.uint_0; num < uint_1; num += 1U)
				{
					this.struct1_0[(int)((UIntPtr)num)] = new <Module>.Struct1(3);
					this.struct1_1[(int)((UIntPtr)num)] = new <Module>.Struct1(3);
				}
				this.uint_0 = uint_1;
			}

			// Token: 0x06000020 RID: 32 RVA: 0x00004160 File Offset: 0x00002360
			internal void method_1()
			{
				this.struct0_0.method_0();
				for (uint num = 0U; num < this.uint_0; num += 1U)
				{
					this.struct1_0[(int)((UIntPtr)num)].method_0();
					this.struct1_1[(int)((UIntPtr)num)].method_0();
				}
				this.struct0_1.method_0();
				this.struct1_2.method_0();
			}

			// Token: 0x06000021 RID: 33 RVA: 0x000041C4 File Offset: 0x000023C4
			internal uint method_2(<Module>.Class0 class0_0, uint uint_1)
			{
				if (this.struct0_0.method_1(class0_0) == 0U)
				{
					return this.struct1_0[(int)((UIntPtr)uint_1)].method_1(class0_0);
				}
				uint num = 8U;
				if (this.struct0_1.method_1(class0_0) != 0U)
				{
					num += 8U;
					num += this.struct1_2.method_1(class0_0);
				}
				else
				{
					num += this.struct1_1[(int)((UIntPtr)uint_1)].method_1(class0_0);
				}
				return num;
			}

			// Token: 0x06000022 RID: 34 RVA: 0x00004230 File Offset: 0x00002430
			internal Class2()
			{
			}

			// Token: 0x0400001B RID: 27
			internal readonly <Module>.Struct1[] struct1_0 = new <Module>.Struct1[16];

			// Token: 0x0400001C RID: 28
			internal readonly <Module>.Struct1[] struct1_1 = new <Module>.Struct1[16];

			// Token: 0x0400001D RID: 29
			internal <Module>.Struct0 struct0_0 = default(<Module>.Struct0);

			// Token: 0x0400001E RID: 30
			internal <Module>.Struct0 struct0_1 = default(<Module>.Struct0);

			// Token: 0x0400001F RID: 31
			internal <Module>.Struct1 struct1_2 = new <Module>.Struct1(8);

			// Token: 0x04000020 RID: 32
			internal uint uint_0;
		}

		// Token: 0x02000007 RID: 7
		internal class Class3
		{
			// Token: 0x06000023 RID: 35 RVA: 0x00004284 File Offset: 0x00002484
			internal void method_0(int int_2, int int_3)
			{
				if (this.struct2_0 != null && this.int_1 == int_3 && this.int_0 == int_2)
				{
					return;
				}
				this.int_0 = int_2;
				this.uint_0 = (1U << int_2) - 1U;
				this.int_1 = int_3;
				uint num = 1U << this.int_1 + this.int_0;
				this.struct2_0 = new <Module>.Class1.Class3.Struct2[num];
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.struct2_0[(int)((UIntPtr)num2)].method_0();
				}
			}

			// Token: 0x06000024 RID: 36 RVA: 0x00004308 File Offset: 0x00002508
			internal void method_1()
			{
				uint num = 1U << this.int_1 + this.int_0;
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.struct2_0[(int)((UIntPtr)num2)].method_1();
				}
			}

			// Token: 0x06000025 RID: 37 RVA: 0x0000253A File Offset: 0x0000073A
			internal uint method_2(uint uint_1, byte byte_0)
			{
				return ((uint_1 & this.uint_0) << this.int_1) + (uint)(byte_0 >> 8 - this.int_1);
			}

			// Token: 0x06000026 RID: 38 RVA: 0x0000255C File Offset: 0x0000075C
			internal byte method_3(<Module>.Class0 class0_0, uint uint_1, byte byte_0)
			{
				return this.struct2_0[(int)((UIntPtr)this.method_2(uint_1, byte_0))].method_2(class0_0);
			}

			// Token: 0x06000027 RID: 39 RVA: 0x00002578 File Offset: 0x00000778
			internal byte method_4(<Module>.Class0 class0_0, uint uint_1, byte byte_0, byte byte_1)
			{
				return this.struct2_0[(int)((UIntPtr)this.method_2(uint_1, byte_0))].method_3(class0_0, byte_1);
			}

			// Token: 0x06000028 RID: 40 RVA: 0x00002515 File Offset: 0x00000715
			internal Class3()
			{
			}

			// Token: 0x04000021 RID: 33
			internal <Module>.Class1.Class3.Struct2[] struct2_0;

			// Token: 0x04000022 RID: 34
			internal int int_0;

			// Token: 0x04000023 RID: 35
			internal int int_1;

			// Token: 0x04000024 RID: 36
			internal uint uint_0;

			// Token: 0x02000008 RID: 8
			internal struct Struct2
			{
				// Token: 0x06000029 RID: 41 RVA: 0x00002596 File Offset: 0x00000796
				internal void method_0()
				{
					this.struct0_0 = new <Module>.Struct0[768];
				}

				// Token: 0x0600002A RID: 42 RVA: 0x00004348 File Offset: 0x00002548
				internal void method_1()
				{
					for (int i = 0; i < 768; i++)
					{
						this.struct0_0[i].method_0();
					}
				}

				// Token: 0x0600002B RID: 43 RVA: 0x00004378 File Offset: 0x00002578
				internal byte method_2(<Module>.Class0 class0_0)
				{
					uint num = 1U;
					do
					{
						num = (num << 1) | this.struct0_0[(int)((UIntPtr)num)].method_1(class0_0);
					}
					while (num < 256U);
					return (byte)num;
				}

				// Token: 0x0600002C RID: 44 RVA: 0x000043AC File Offset: 0x000025AC
				internal byte method_3(<Module>.Class0 class0_0, byte byte_0)
				{
					uint num = 1U;
					for (;;)
					{
						uint num2 = (uint)((byte_0 >> 7) & 1);
						byte_0 = (byte)(byte_0 << 1);
						uint num3 = this.struct0_0[(int)((UIntPtr)((1U + num2 << 8) + num))].method_1(class0_0);
						num = (num << 1) | num3;
						if (num2 != num3)
						{
							break;
						}
						if (num >= 256U)
						{
							goto IL_5E;
						}
					}
					while (num < 256U)
					{
						num = (num << 1) | this.struct0_0[(int)((UIntPtr)num)].method_1(class0_0);
					}
					IL_5E:
					return (byte)num;
				}

				// Token: 0x04000025 RID: 37
				internal <Module>.Struct0[] struct0_0;
			}
		}
	}

	// Token: 0x02000009 RID: 9
	internal class Class4
	{
		// Token: 0x0600002D RID: 45 RVA: 0x000025A8 File Offset: 0x000007A8
		internal void method_0(uint uint_3)
		{
			if (this.uint_2 != uint_3)
			{
				this.byte_0 = new byte[uint_3];
			}
			this.uint_2 = uint_3;
			this.uint_0 = 0U;
			this.uint_1 = 0U;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000025D5 File Offset: 0x000007D5
		internal void method_1(Stream stream_1, bool bool_0)
		{
			this.method_2();
			this.stream_0 = stream_1;
			if (!bool_0)
			{
				this.uint_1 = 0U;
				this.uint_0 = 0U;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000025F5 File Offset: 0x000007F5
		internal void method_2()
		{
			this.method_3();
			this.stream_0 = null;
			Buffer.BlockCopy(new byte[this.byte_0.Length], 0, this.byte_0, 0, this.byte_0.Length);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000441C File Offset: 0x0000261C
		internal void method_3()
		{
			uint num = this.uint_0 - this.uint_1;
			if (num == 0U)
			{
				return;
			}
			this.stream_0.Write(this.byte_0, (int)this.uint_1, (int)num);
			if (this.uint_0 >= this.uint_2)
			{
				this.uint_0 = 0U;
			}
			this.uint_1 = this.uint_0;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00004474 File Offset: 0x00002674
		internal void method_4(uint uint_3, uint uint_4)
		{
			uint num = this.uint_0 - uint_3 - 1U;
			if (num >= this.uint_2)
			{
				num += this.uint_2;
			}
			while (uint_4 > 0U)
			{
				if (num >= this.uint_2)
				{
					num = 0U;
				}
				this.byte_0[(int)((UIntPtr)(this.uint_0++))] = this.byte_0[(int)((UIntPtr)(num++))];
				if (this.uint_0 >= this.uint_2)
				{
					this.method_3();
				}
				uint_4 -= 1U;
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000044F0 File Offset: 0x000026F0
		internal void method_5(byte byte_1)
		{
			this.byte_0[(int)((UIntPtr)(this.uint_0++))] = byte_1;
			if (this.uint_0 >= this.uint_2)
			{
				this.method_3();
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000452C File Offset: 0x0000272C
		internal byte method_6(uint uint_3)
		{
			uint num = this.uint_0 - uint_3 - 1U;
			if (num >= this.uint_2)
			{
				num += this.uint_2;
			}
			return this.byte_0[(int)((UIntPtr)num)];
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002515 File Offset: 0x00000715
		internal Class4()
		{
		}

		// Token: 0x04000026 RID: 38
		internal byte[] byte_0;

		// Token: 0x04000027 RID: 39
		internal uint uint_0;

		// Token: 0x04000028 RID: 40
		internal Stream stream_0;

		// Token: 0x04000029 RID: 41
		internal uint uint_1;

		// Token: 0x0400002A RID: 42
		internal uint uint_2;
	}

	// Token: 0x0200000A RID: 10
	internal struct Struct3
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00002626 File Offset: 0x00000826
		internal void method_0()
		{
			this.uint_0 = 0U;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000262F File Offset: 0x0000082F
		internal void method_1()
		{
			if (this.uint_0 < 4U)
			{
				this.uint_0 = 0U;
				return;
			}
			if (this.uint_0 < 10U)
			{
				this.uint_0 -= 3U;
				return;
			}
			this.uint_0 -= 6U;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002669 File Offset: 0x00000869
		internal void method_2()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 7U : 10U);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000267F File Offset: 0x0000087F
		internal void method_3()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 8U : 11U);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002695 File Offset: 0x00000895
		internal void method_4()
		{
			this.uint_0 = ((this.uint_0 < 7U) ? 9U : 11U);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000026AC File Offset: 0x000008AC
		internal bool method_5()
		{
			return this.uint_0 < 7U;
		}

		// Token: 0x0400002B RID: 43
		internal uint uint_0;
	}

	// Token: 0x0200000B RID: 11
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 448)]
	internal struct Struct4
	{
	}
}
