using System;
using System.Windows.Forms;

namespace DebugInjector
{
	// Token: 0x02000009 RID: 9
	internal static class Program
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00004EAE File Offset: 0x000030AE
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new DebugInjectorMain());
		}
	}
}
