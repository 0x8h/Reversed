using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200001D RID: 29
	public partial class ConfirmDialog : Form
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600021F RID: 543 RVA: 0x0001FD7A File Offset: 0x0001DF7A
		// (set) Token: 0x06000220 RID: 544 RVA: 0x0001FD82 File Offset: 0x0001DF82
		public bool OK { get; set; }

		// Token: 0x06000221 RID: 545 RVA: 0x0001FD8B File Offset: 0x0001DF8B
		public ConfirmDialog()
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this.OK = false;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0001FDBA File Offset: 0x0001DFBA
		public void setText(string text)
		{
			this.labelText.Text = text;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0001FDC8 File Offset: 0x0001DFC8
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0001FDE7 File Offset: 0x0001DFE7
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0001FDF9 File Offset: 0x0001DFF9
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0001FE0B File Offset: 0x0001E00B
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				this.OK = true;
				base.Close();
			}
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0001FE37 File Offset: 0x0001E037
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0001FE56 File Offset: 0x0001E056
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0001FE68 File Offset: 0x0001E068
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0001FE7A File Offset: 0x0001E07A
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x000024F1 File Offset: 0x000006F1
		private void ConfirmDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}
	}
}
