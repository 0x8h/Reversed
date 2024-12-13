using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace mandela.Properties
{
	// Token: 0x02000011 RID: 17
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	internal class Resources
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00003350 File Offset: 0x00001550
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00006714 File Offset: 0x00004914
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceManager_0 == null)
				{
					Resources.resourceManager_0 = new ResourceManager("mandela.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceManager_0;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000025B7 File Offset: 0x000007B7
		// (set) Token: 0x06000042 RID: 66 RVA: 0x000025BE File Offset: 0x000007BE
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.cultureInfo_0;
			}
			set
			{
				Resources.cultureInfo_0 = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000043 RID: 67 RVA: 0x000025C6 File Offset: 0x000007C6
		internal static Bitmap cybersoldier
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("cybersoldier", Resources.cultureInfo_0);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000025E1 File Offset: 0x000007E1
		internal static Bitmap cybersoldier_angry
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("cybersoldier_angry", Resources.cultureInfo_0);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000025FC File Offset: 0x000007FC
		internal static byte[] education
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("education", Resources.cultureInfo_0);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002617 File Offset: 0x00000817
		internal static Bitmap entity
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("entity", Resources.cultureInfo_0);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002632 File Offset: 0x00000832
		internal static Bitmap intruder
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("intruder", Resources.cultureInfo_0);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000048 RID: 72 RVA: 0x0000264D File Offset: 0x0000084D
		internal static Bitmap man
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("man", Resources.cultureInfo_0);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002668 File Offset: 0x00000868
		internal static Bitmap mask
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("mask", Resources.cultureInfo_0);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002683 File Offset: 0x00000883
		internal static Bitmap momo
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("momo", Resources.cultureInfo_0);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600004B RID: 75 RVA: 0x0000269E File Offset: 0x0000089E
		internal static Bitmap nosleep
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("nosleep", Resources.cultureInfo_0);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000026B9 File Offset: 0x000008B9
		internal static Bitmap nosleep2
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("nosleep2", Resources.cultureInfo_0);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000026D4 File Offset: 0x000008D4
		internal static Bitmap smile
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("smile", Resources.cultureInfo_0);
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000026EF File Offset: 0x000008EF
		internal static Bitmap watching
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("watching", Resources.cultureInfo_0);
			}
		}

		// Token: 0x04000034 RID: 52
		private static ResourceManager resourceManager_0;

		// Token: 0x04000035 RID: 53
		private static CultureInfo cultureInfo_0;
	}
}
