using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200005B RID: 91
	public partial class WarningDialog : Form
	{
		// Token: 0x060009A0 RID: 2464 RVA: 0x0006C862 File Offset: 0x0006AA62
		public WarningDialog()
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x0006C88A File Offset: 0x0006AA8A
		public void setText(string text)
		{
			this.labelText.Text = text;
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x0006C898 File Offset: 0x0006AA98
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0006C8B7 File Offset: 0x0006AAB7
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x0006C8C9 File Offset: 0x0006AAC9
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0006C8DB File Offset: 0x0006AADB
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				base.Close();
			}
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x000024F1 File Offset: 0x000006F1
		private void WarningDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}
	}
}
