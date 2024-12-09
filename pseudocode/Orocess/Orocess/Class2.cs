using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

// Token: 0x0200000D RID: 13
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Class2
{
	// Token: 0x06000091 RID: 145 RVA: 0x00002396 File Offset: 0x00000596
	internal Class2()
	{
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000092 RID: 146 RVA: 0x0000258A File Offset: 0x0000078A
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager_0
	{
		get
		{
			if (Class2.resourceManager_0 == null)
			{
				Class2.resourceManager_0 = Class2.smethod_2("'d<\\\\Ak\\]IW|pv;\\*T\\,ni<_:Qec\"", Class2.smethod_1(Class2.smethod_0(typeof(Class2).TypeHandle)));
			}
			return Class2.resourceManager_0;
		}
	}

	// Token: 0x17000008 RID: 8
	// (set) Token: 0x06000093 RID: 147 RVA: 0x000025B6 File Offset: 0x000007B6
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo CultureInfo_0
	{
		set
		{
			Class2.cultureInfo_0 = value;
		}
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000094 RID: 148 RVA: 0x000025BE File Offset: 0x000007BE
	internal static byte[] Byte_0
	{
		get
		{
			return (byte[])Class2.smethod_3(Class2.ResourceManager_0, "cursor", Class2.cultureInfo_0);
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000095 RID: 149 RVA: 0x000025D9 File Offset: 0x000007D9
	internal static byte[] Byte_1
	{
		get
		{
			return (byte[])Class2.smethod_3(Class2.ResourceManager_0, "del", Class2.cultureInfo_0);
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000096 RID: 150 RVA: 0x000025F4 File Offset: 0x000007F4
	internal static Bitmap Bitmap_0
	{
		get
		{
			return (Bitmap)Class2.smethod_3(Class2.ResourceManager_0, "img1", Class2.cultureInfo_0);
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000097 RID: 151 RVA: 0x0000260F File Offset: 0x0000080F
	internal static Bitmap Bitmap_1
	{
		get
		{
			return (Bitmap)Class2.smethod_3(Class2.ResourceManager_0, "img2", Class2.cultureInfo_0);
		}
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000098 RID: 152 RVA: 0x0000262A File Offset: 0x0000082A
	internal static Bitmap Bitmap_2
	{
		get
		{
			return (Bitmap)Class2.smethod_3(Class2.ResourceManager_0, "img3", Class2.cultureInfo_0);
		}
	}

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x06000099 RID: 153 RVA: 0x00002645 File Offset: 0x00000845
	internal static Bitmap Bitmap_3
	{
		get
		{
			return (Bitmap)Class2.smethod_3(Class2.ResourceManager_0, "img4", Class2.cultureInfo_0);
		}
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x0600009A RID: 154 RVA: 0x00002660 File Offset: 0x00000860
	internal static byte[] Byte_2
	{
		get
		{
			return (byte[])Class2.smethod_3(Class2.ResourceManager_0, "no", Class2.cultureInfo_0);
		}
	}

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x0600009B RID: 155 RVA: 0x0000267B File Offset: 0x0000087B
	internal static byte[] Byte_3
	{
		get
		{
			return (byte[])Class2.smethod_3(Class2.ResourceManager_0, "No_place_to_stay", Class2.cultureInfo_0);
		}
	}

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x0600009C RID: 156 RVA: 0x00002696 File Offset: 0x00000896
	internal static Bitmap Bitmap_4
	{
		get
		{
			return (Bitmap)Class2.smethod_3(Class2.ResourceManager_0, "pii", Class2.cultureInfo_0);
		}
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x0600009D RID: 157 RVA: 0x000026B1 File Offset: 0x000008B1
	internal static Bitmap Bitmap_5
	{
		get
		{
			return (Bitmap)Class2.smethod_3(Class2.ResourceManager_0, "pii1", Class2.cultureInfo_0);
		}
	}

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x0600009E RID: 158 RVA: 0x000026CC File Offset: 0x000008CC
	internal static UnmanagedMemoryStream UnmanagedMemoryStream_0
	{
		get
		{
			return Class2.smethod_4(Class2.ResourceManager_0, "w", Class2.cultureInfo_0);
		}
	}

	// Token: 0x0600009F RID: 159 RVA: 0x00002059 File Offset: 0x00000259
	static Type smethod_0(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x000026E2 File Offset: 0x000008E2
	static Assembly smethod_1(Type type_0)
	{
		return type_0.Assembly;
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x000026EA File Offset: 0x000008EA
	static ResourceManager smethod_2(string string_0, Assembly assembly_0)
	{
		return new ResourceManager(string_0, assembly_0);
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x000026F3 File Offset: 0x000008F3
	static object smethod_3(ResourceManager resourceManager_1, string string_0, CultureInfo cultureInfo_1)
	{
		return resourceManager_1.GetObject(string_0, cultureInfo_1);
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x000026FD File Offset: 0x000008FD
	static UnmanagedMemoryStream smethod_4(ResourceManager resourceManager_1, string string_0, CultureInfo cultureInfo_1)
	{
		return resourceManager_1.GetStream(string_0, cultureInfo_1);
	}

	// Token: 0x0400004A RID: 74
	private static ResourceManager resourceManager_0;

	// Token: 0x0400004B RID: 75
	private static CultureInfo cultureInfo_0;
}
