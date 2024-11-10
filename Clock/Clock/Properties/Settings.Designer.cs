using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Clock.Properties
{
	// Token: 0x0200005E RID: 94
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.5.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06000D72 RID: 3442 RVA: 0x00073938 File Offset: 0x00071B38
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040006EE RID: 1774
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
