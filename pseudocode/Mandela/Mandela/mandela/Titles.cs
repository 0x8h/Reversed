using System;
using System.Threading;
using CsharpGDI;

namespace mandela
{
	// Token: 0x0200000F RID: 15
	public class Titles : gdi32
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00006408 File Offset: 0x00004608
		public void window_title()
		{
			while (!gdi.isscary)
			{
				this.intptr_0 = gdi32.GetTopWindow(gdi32.NULL);
				while (this.intptr_0 != IntPtr.Zero)
				{
					this.intptr_0 = gdi32.GetWindow(this.intptr_0, gdi32.GetWindowType.GW_HWNDNEXT);
					gdi32.SetWindowText(this.intptr_0, "NOTHING IS WORTH THE RISK NOTHING IS WORTH THE RISK NOTHING IS WORTH THE RISKNOTHING IS WORTH THE RISK NOTHING IS WORTH THE RISK NOTHING IS WORTH THE RISKNOTHING IS WORTH THE RISK NOTHING IS WORTH THE RISK NOTHING IS WORTH THE RISK");
				}
				Thread.Sleep(300);
			}
		}

		// Token: 0x0400002F RID: 47
		private IntPtr intptr_0;
	}
}
