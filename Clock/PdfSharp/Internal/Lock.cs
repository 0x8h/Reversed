using System;
using System.Threading;

namespace PdfSharp.Internal
{
	// Token: 0x020000AE RID: 174
	internal static class Lock
	{
		// Token: 0x0600079E RID: 1950 RVA: 0x0001D62E File Offset: 0x0001B82E
		public static void EnterGdiPlus()
		{
			Monitor.Enter(Lock.GdiPlus);
			Lock._gdiPlusLockCount++;
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0001D646 File Offset: 0x0001B846
		public static void ExitGdiPlus()
		{
			Lock._gdiPlusLockCount--;
			Monitor.Exit(Lock.GdiPlus);
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0001D65E File Offset: 0x0001B85E
		public static void EnterFontFactory()
		{
			Monitor.Enter(Lock.FontFactory);
			Lock._fontFactoryLockCount++;
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0001D676 File Offset: 0x0001B876
		public static void ExitFontFactory()
		{
			Lock._fontFactoryLockCount--;
			Monitor.Exit(Lock.FontFactory);
		}

		// Token: 0x0400040D RID: 1037
		private static readonly object GdiPlus = new object();

		// Token: 0x0400040E RID: 1038
		private static int _gdiPlusLockCount;

		// Token: 0x0400040F RID: 1039
		private static readonly object FontFactory = new object();

		// Token: 0x04000410 RID: 1040
		[ThreadStatic]
		private static int _fontFactoryLockCount;
	}
}
