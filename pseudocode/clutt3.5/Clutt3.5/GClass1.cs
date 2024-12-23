using System;
using System.Diagnostics;

// Token: 0x0200000D RID: 13
public class GClass1
{
	// Token: 0x0600003E RID: 62 RVA: 0x000026C4 File Offset: 0x000008C4
	public static void smethod_0(string string_0)
	{
		Process.Start(new ProcessStartInfo
		{
			FileName = "cmd.exe",
			WindowStyle = ProcessWindowStyle.Hidden,
			Arguments = string_0
		});
	}
}
