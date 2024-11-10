using System;
using System.Diagnostics;

namespace PdfSharp.Internal
{
	// Token: 0x020000B7 RID: 183
	public static class DebugBreak
	{
		// Token: 0x060007B3 RID: 1971 RVA: 0x0001D809 File Offset: 0x0001BA09
		public static void Break()
		{
			DebugBreak.Break(false);
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0001D811 File Offset: 0x0001BA11
		public static void Break(bool always)
		{
			if (always || Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}
}
