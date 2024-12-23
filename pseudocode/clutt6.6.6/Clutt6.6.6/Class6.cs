using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;

// Token: 0x02000011 RID: 17
[DebuggerNonUserCode]
[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
internal class Class6
{
	// Token: 0x0600005C RID: 92 RVA: 0x000026BB File Offset: 0x000008BB
	internal Class6()
	{
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x0600005D RID: 93 RVA: 0x000063F4 File Offset: 0x000045F4
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager_0
	{
		get
		{
			if (Class6.resourceManager_0 == null)
			{
				ResourceManager resourceManager = new ResourceManager("r)K8J8T\\*%SRaJCu>-p198-r2%", typeof(Class6).Assembly);
				Class6.resourceManager_0 = resourceManager;
			}
			return Class6.resourceManager_0;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x0600005E RID: 94 RVA: 0x00006434 File Offset: 0x00004634
	// (set) Token: 0x0600005F RID: 95 RVA: 0x000028B5 File Offset: 0x00000AB5
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo CultureInfo_0
	{
		get
		{
			return Class6.cultureInfo_0;
		}
		set
		{
			Class6.cultureInfo_0 = value;
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000060 RID: 96 RVA: 0x00006448 File Offset: 0x00004648
	internal static Icon Icon_0
	{
		get
		{
			object @object = Class6.ResourceManager_0.GetObject("clutterus_ico", Class6.cultureInfo_0);
			return (Icon)@object;
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000061 RID: 97 RVA: 0x00006474 File Offset: 0x00004674
	internal static Icon Icon_1
	{
		get
		{
			object @object = Class6.ResourceManager_0.GetObject("crossHD_large", Class6.cultureInfo_0);
			return (Icon)@object;
		}
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000062 RID: 98 RVA: 0x000064A0 File Offset: 0x000046A0
	internal static Icon Icon_2
	{
		get
		{
			object @object = Class6.ResourceManager_0.GetObject("crossHD_medium", Class6.cultureInfo_0);
			return (Icon)@object;
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000063 RID: 99 RVA: 0x000064CC File Offset: 0x000046CC
	internal static Icon Icon_3
	{
		get
		{
			object @object = Class6.ResourceManager_0.GetObject("crossHD_small", Class6.cultureInfo_0);
			return (Icon)@object;
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000064 RID: 100 RVA: 0x000064F8 File Offset: 0x000046F8
	internal static UnmanagedMemoryStream UnmanagedMemoryStream_0
	{
		get
		{
			return Class6.ResourceManager_0.GetStream("invert_snd", Class6.cultureInfo_0);
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000065 RID: 101 RVA: 0x0000651C File Offset: 0x0000471C
	internal static UnmanagedMemoryStream UnmanagedMemoryStream_1
	{
		get
		{
			return Class6.ResourceManager_0.GetStream("mirror_snd", Class6.cultureInfo_0);
		}
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000066 RID: 102 RVA: 0x00006540 File Offset: 0x00004740
	internal static UnmanagedMemoryStream UnmanagedMemoryStream_2
	{
		get
		{
			return Class6.ResourceManager_0.GetStream("plg", Class6.cultureInfo_0);
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000067 RID: 103 RVA: 0x00006564 File Offset: 0x00004764
	internal static UnmanagedMemoryStream UnmanagedMemoryStream_3
	{
		get
		{
			return Class6.ResourceManager_0.GetStream("rainbow_snd", Class6.cultureInfo_0);
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000068 RID: 104 RVA: 0x00006588 File Offset: 0x00004788
	internal static UnmanagedMemoryStream UnmanagedMemoryStream_4
	{
		get
		{
			return Class6.ResourceManager_0.GetStream("static_color", Class6.cultureInfo_0);
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000069 RID: 105 RVA: 0x000065AC File Offset: 0x000047AC
	internal static UnmanagedMemoryStream UnmanagedMemoryStream_5
	{
		get
		{
			return Class6.ResourceManager_0.GetStream("stretch", Class6.cultureInfo_0);
		}
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x0600006A RID: 106 RVA: 0x000065D0 File Offset: 0x000047D0
	internal static UnmanagedMemoryStream UnmanagedMemoryStream_6
	{
		get
		{
			return Class6.ResourceManager_0.GetStream("tunnel", Class6.cultureInfo_0);
		}
	}

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x0600006B RID: 107 RVA: 0x000065F4 File Offset: 0x000047F4
	internal static UnmanagedMemoryStream UnmanagedMemoryStream_7
	{
		get
		{
			return Class6.ResourceManager_0.GetStream("wind_edit", Class6.cultureInfo_0);
		}
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x0600006C RID: 108 RVA: 0x00006618 File Offset: 0x00004818
	internal static UnmanagedMemoryStream UnmanagedMemoryStream_8
	{
		get
		{
			return Class6.ResourceManager_0.GetStream("wind_short", Class6.cultureInfo_0);
		}
	}

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x0600006D RID: 109 RVA: 0x0000663C File Offset: 0x0000483C
	internal static UnmanagedMemoryStream UnmanagedMemoryStream_9
	{
		get
		{
			return Class6.ResourceManager_0.GetStream("wind_snd", Class6.cultureInfo_0);
		}
	}

	// Token: 0x04000070 RID: 112
	private static ResourceManager resourceManager_0;

	// Token: 0x04000071 RID: 113
	private static CultureInfo cultureInfo_0;
}
