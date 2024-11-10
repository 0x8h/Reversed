using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200005C RID: 92
	public partial class WriteInformationDialog : Form
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060009A9 RID: 2473 RVA: 0x0006CE21 File Offset: 0x0006B021
		// (set) Token: 0x060009AA RID: 2474 RVA: 0x0006CE29 File Offset: 0x0006B029
		public bool IsRun { get; set; }

		// Token: 0x060009AB RID: 2475 RVA: 0x0006CE32 File Offset: 0x0006B032
		public WriteInformationDialog()
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x0006CE5A File Offset: 0x0006B05A
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x0006CE79 File Offset: 0x0006B079
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x0006CE8B File Offset: 0x0006B08B
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x0006CE9D File Offset: 0x0006B09D
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				base.Close();
			}
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x0006CEC2 File Offset: 0x0006B0C2
		private void pictureBoxButtonRun_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRun.Image = Resources.sim_btn_052;
			}
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x0006CEE1 File Offset: 0x0006B0E1
		private void pictureBoxButtonRun_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonRun.Image = Resources.sim_btn_051;
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0006CEF3 File Offset: 0x0006B0F3
		private void pictureBoxButtonRun_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonRun.Image = Resources.sim_btn_050;
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0006CF05 File Offset: 0x0006B105
		private void pictureBoxButtonRun_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRun.Image = Resources.sim_btn_051;
				this.IsRun = true;
				base.Close();
			}
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x000024F1 File Offset: 0x000006F1
		private void WriteInformationDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}
	}
}
