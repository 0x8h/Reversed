using System;
using System.Windows.Forms;

namespace Dos
{
	// Token: 0x02000003 RID: 3
	internal static class Program
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000028F6 File Offset: 0x00000AF6
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
