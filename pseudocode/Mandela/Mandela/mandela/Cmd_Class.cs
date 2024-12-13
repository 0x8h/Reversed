using System;
using System.Diagnostics;

namespace mandela
{
	// Token: 0x02000003 RID: 3
	public class Cmd_Class
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00003368 File Offset: 0x00001568
		public static void cmd(string argue)
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "cmd.exe",
				WindowStyle = ProcessWindowStyle.Hidden,
				Arguments = "/k " + argue
			});
		}
	}
}
