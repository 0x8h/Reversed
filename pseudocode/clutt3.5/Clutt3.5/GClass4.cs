using System;
using System.Threading;

// Token: 0x02000025 RID: 37
public class GClass4
{
	// Token: 0x060000B4 RID: 180 RVA: 0x000029EC File Offset: 0x00000BEC
	public void method_0()
	{
		GClass4.int_0 = 300;
		while (GClass4.int_0 > 0)
		{
			Thread.Sleep(1000);
			GClass4.int_0--;
		}
		for (;;)
		{
			Environment.Exit(-1);
		}
	}

	// Token: 0x040000E0 RID: 224
	public static int int_0;
}
