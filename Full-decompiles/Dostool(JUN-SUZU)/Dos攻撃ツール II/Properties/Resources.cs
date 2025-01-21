using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Dos攻撃ツ\u30FCル_II.Properties
{
	// Token: 0x02000004 RID: 4
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600000C RID: 12 RVA: 0x000029E9 File Offset: 0x00000BE9
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000029F4 File Offset: 0x00000BF4
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("Dos攻撃ツール_II.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002A3C File Offset: 0x00000C3C
		// (set) Token: 0x0600000F RID: 15 RVA: 0x00002A53 File Offset: 0x00000C53
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400000D RID: 13
		private static ResourceManager resourceMan;

		// Token: 0x0400000E RID: 14
		private static CultureInfo resourceCulture;
	}
}
