using System;

namespace DebugInjector
{
	// Token: 0x02000005 RID: 5
	public class ResponseData
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00004DCF File Offset: 0x00002FCF
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00004DD7 File Offset: 0x00002FD7
		public string status { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00004DE0 File Offset: 0x00002FE0
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00004DE8 File Offset: 0x00002FE8
		public Data data { get; set; }
	}
}
