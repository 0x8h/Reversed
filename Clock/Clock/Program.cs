using System;
using System.Windows.Forms;

namespace Clock
{
	// Token: 0x02000049 RID: 73
	internal static class Program
	{
		// Token: 0x060007F7 RID: 2039 RVA: 0x0005B34F File Offset: 0x0005954F
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new StartWindow());
		}
	}
}
