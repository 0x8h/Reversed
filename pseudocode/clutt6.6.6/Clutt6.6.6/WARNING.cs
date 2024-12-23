using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x0200000F RID: 15
public partial class WARNING : Form
{
	// Token: 0x06000053 RID: 83 RVA: 0x0000285D File Offset: 0x00000A5D
	public WARNING()
	{
		this.InitializeComponent();
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00002872 File Offset: 0x00000A72
	private void warn_Click(object sender, EventArgs e)
	{
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00002872 File Offset: 0x00000A72
	private void WARNING_FormClosing(object sender, FormClosingEventArgs e)
	{
	}

	// Token: 0x06000056 RID: 86 RVA: 0x00002872 File Offset: 0x00000A72
	private void WARNING_Load(object sender, EventArgs e)
	{
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00002874 File Offset: 0x00000A74
	private void exit_btn_Click(object sender, EventArgs e)
	{
		Environment.Exit(-1);
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00005DA4 File Offset: 0x00003FA4
	private void run_btn_Click(object sender, EventArgs e)
	{
		base.Hide();
		GClass0 gclass = new GClass0();
		gclass.method_0();
		base.Close();
	}

	// Token: 0x06000059 RID: 89 RVA: 0x0000287C File Offset: 0x00000A7C
	protected virtual void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x04000069 RID: 105
	private IContainer icontainer_0 = null;
}
