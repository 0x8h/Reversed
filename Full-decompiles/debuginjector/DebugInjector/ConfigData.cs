using System;
using System.Collections.Generic;

namespace DebugInjector
{
	// Token: 0x02000004 RID: 4
	public class ConfigData
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00004D99 File Offset: 0x00002F99
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00004DA1 File Offset: 0x00002FA1
		public string Dll { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00004DAA File Offset: 0x00002FAA
		// (set) Token: 0x06000032 RID: 50 RVA: 0x00004DB2 File Offset: 0x00002FB2
		public string url { get; set; }

		// Token: 0x04000020 RID: 32
		public List<PanelData> Panels = new List<PanelData>();
	}
}
