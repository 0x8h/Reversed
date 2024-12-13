using System;
using System.Windows.Forms;
using mandela;

// Token: 0x0200000B RID: 11
internal static class Class0
{
	// Token: 0x06000031 RID: 49 RVA: 0x000061EC File Offset: 0x000043EC
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run(new WarnWin());
	}
}
