using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Dos.Properties
{
	// Token: 0x02000005 RID: 5
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002984 File Offset: 0x00000B84
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400000E RID: 14
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
