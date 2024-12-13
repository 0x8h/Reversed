using System;
using SysPrivileges;

namespace mandela
{
	// Token: 0x02000008 RID: 8
	public class Instant_Shutdown : Privileges
	{
		// Token: 0x06000029 RID: 41 RVA: 0x0000604C File Offset: 0x0000424C
		public static void Force_reboot()
		{
			Privileges.TOKEN_PRIVILEGES token_PRIVILEGES = default(Privileges.TOKEN_PRIVILEGES);
			token_PRIVILEGES.Privileges = new Privileges.LUID_AND_ATTRIBUTES[1];
			IntPtr intPtr;
			Privileges.OpenProcessToken(Privileges.GetCurrentProcess(), 40U, out intPtr);
			Privileges.LookupPrivilegeValue(null, Privileges.PrivilegeNames.SeShutdownPrivilege.ToString(), ref token_PRIVILEGES.Privileges[0].Luid);
			token_PRIVILEGES.PrivilegeCount = 1U;
			token_PRIVILEGES.Privileges[0].Attributes = 2U;
			Privileges.AdjustTokenPrivileges(intPtr, false, ref token_PRIVILEGES, 0U, IntPtr.Zero, IntPtr.Zero);
			Privileges.NtShutdownSystem(Privileges.SHUTDOWN_ACTION.ShutdownReboot);
		}
	}
}
