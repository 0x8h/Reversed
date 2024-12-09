using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x02000004 RID: 4
public partial class msgbox : Form
{
	// Token: 0x06000056 RID: 86 RVA: 0x00003460 File Offset: 0x00001660
	public msgbox()
	{
		this.InitializeComponent();
		msgbox.smethod_1(this, FormBorderStyle.None);
		msgbox.smethod_2(this);
		msgbox.smethod_3(this.timer_0, 500);
		msgbox.smethod_4(this.timer_0, true);
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00003514 File Offset: 0x00001714
	private void msgbox_Load(object sender, EventArgs e)
	{
		msgbox.smethod_2(this);
		msgbox.smethod_1(this, FormBorderStyle.None);
		Random random = msgbox.smethod_0();
		int width = msgbox.smethod_6(msgbox.smethod_5()).Width;
		int height = Screen.PrimaryScreen.Bounds.Height;
		int width2 = base.Width;
		int height2 = base.Height;
		int num = random.Next(0, width - width2);
		int num2 = random.Next(0, height - height2);
		base.Location = new Point(num, num2);
		this.method_0(this);
		int num3 = random.Next(this.string_0.Length);
		MessageBox.Show(this.string_0[num3], "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	// Token: 0x06000058 RID: 88 RVA: 0x000035C0 File Offset: 0x000017C0
	private void method_0(IWin32Window iwin32Window_0)
	{
		IntPtr windowLong = Class1.GetWindowLong(this.method_4(), -6);
		IntPtr currentThreadId = Class1.GetCurrentThreadId();
		this.intptr_0 = Class1.SetWindowsHookEx(5, new Class1.Delegate0(this.method_1), windowLong, currentThreadId);
	}

	// Token: 0x06000059 RID: 89 RVA: 0x000035FC File Offset: 0x000017FC
	private IntPtr method_1(int int_0, IntPtr intptr_1, IntPtr intptr_2)
	{
		if (int_0 == 5)
		{
			Class1.Struct0 @struct;
			Class1.GetWindowRect(this.method_4(), out @struct);
			Class1.Struct0 struct2;
			Class1.GetWindowRect(intptr_1, out struct2);
			int num = @struct.int_0 + (@struct.Int32_3 - struct2.Int32_3) / 2;
			int num2 = @struct.int_1 + (@struct.Int32_2 - struct2.Int32_2) / 2;
			Class1.SetWindowPos(intptr_1, 0, num, num2, 0, 0, 21U);
			Class1.UnhookWindowsHookEx(this.intptr_0);
		}
		return Class1.CallNextHookEx(this.intptr_0, int_0, intptr_1, intptr_2);
	}

	// Token: 0x0600005A RID: 90 RVA: 0x000020CE File Offset: 0x000002CE
	private void method_2(object sender, EventArgs e)
	{
	}

	// Token: 0x0600005B RID: 91 RVA: 0x0000233D File Offset: 0x0000053D
	private void method_3(object sender, EventArgs e)
	{
		msgbox.smethod_7(new msgbox());
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00002349 File Offset: 0x00000549
	protected virtual void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			msgbox.smethod_8(this.icontainer_0);
		}
		base.Dispose(disposing);
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00002368 File Offset: 0x00000568
	static Random smethod_0()
	{
		return new Random();
	}

	// Token: 0x0600005F RID: 95 RVA: 0x0000232B File Offset: 0x0000052B
	static void smethod_1(Form form_0, FormBorderStyle formBorderStyle_0)
	{
		form_0.FormBorderStyle = formBorderStyle_0;
	}

	// Token: 0x06000060 RID: 96 RVA: 0x0000236F File Offset: 0x0000056F
	static void smethod_2(Control control_0)
	{
		control_0.Hide();
	}

	// Token: 0x06000061 RID: 97 RVA: 0x0000227B File Offset: 0x0000047B
	static void smethod_3(Timer timer_1, int int_0)
	{
		timer_1.Interval = int_0;
	}

	// Token: 0x06000062 RID: 98 RVA: 0x00002284 File Offset: 0x00000484
	static void smethod_4(Timer timer_1, bool bool_0)
	{
		timer_1.Enabled = bool_0;
	}

	// Token: 0x06000063 RID: 99 RVA: 0x0000228D File Offset: 0x0000048D
	static Screen smethod_5()
	{
		return Screen.PrimaryScreen;
	}

	// Token: 0x06000064 RID: 100 RVA: 0x00002294 File Offset: 0x00000494
	static Rectangle smethod_6(Screen screen_0)
	{
		return screen_0.Bounds;
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00002377 File Offset: 0x00000577
	IntPtr method_4()
	{
		return base.Handle;
	}

	// Token: 0x06000066 RID: 102 RVA: 0x000022A5 File Offset: 0x000004A5
	static void smethod_7(Control control_0)
	{
		control_0.Show();
	}

	// Token: 0x06000067 RID: 103 RVA: 0x000021FC File Offset: 0x000003FC
	static void smethod_8(IDisposable idisposable_0)
	{
		idisposable_0.Dispose();
	}

	// Token: 0x06000068 RID: 104 RVA: 0x000022AD File Offset: 0x000004AD
	static Container smethod_9()
	{
		return new Container();
	}

	// Token: 0x06000069 RID: 105 RVA: 0x000022B4 File Offset: 0x000004B4
	static Timer smethod_10(IContainer icontainer_1)
	{
		return new Timer(icontainer_1);
	}

	// Token: 0x0600006A RID: 106 RVA: 0x000022CB File Offset: 0x000004CB
	static void smethod_11(Control control_0)
	{
		control_0.SuspendLayout();
	}

	// Token: 0x0600006B RID: 107 RVA: 0x000022D3 File Offset: 0x000004D3
	static void smethod_12(Timer timer_1, EventHandler eventHandler_0)
	{
		timer_1.Tick += eventHandler_0;
	}

	// Token: 0x0400000A RID: 10
	private IntPtr intptr_0;

	// Token: 0x0400000B RID: 11
	private Random random_0 = msgbox.smethod_0();

	// Token: 0x0400000C RID: 12
	private string[] string_0 = new string[]
	{
		"What is the meaning of your existence?", "You don't exist.", "I will make you disappear.", "I will not forgive you even if you die. Never.", "Do not look behind you.", "It is time for children to go to bed. There must be something to do first.", "You are not well. Is it because your friends are not happy with you?", "Are you really surrounded by people? Maybe they are aliens.", "We acted first. Now it's our turn to kill you.", "You cannot escape. That way doesn't exist.",
		"It's all your fault. Everything."
	};
}
