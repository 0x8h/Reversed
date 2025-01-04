using System;

namespace DebugInjector
{
	// Token: 0x02000007 RID: 7
	public class ServerData
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00004E69 File Offset: 0x00003069
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00004E71 File Offset: 0x00003071
		public string status { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00004E7A File Offset: 0x0000307A
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00004E82 File Offset: 0x00003082
		public storeData data { get; set; }
	}
}
