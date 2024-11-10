using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000012 RID: 18
	public partial class BlockPropertyNetworkSoundDialog : Form
	{
		// Token: 0x0600013C RID: 316 RVA: 0x000153B4 File Offset: 0x000135B4
		public BlockPropertyNetworkSoundDialog(ProgramModule.BlockNetworkSound block)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000153E3 File Offset: 0x000135E3
		private void setBlockData(ProgramModule.BlockNetworkSound block)
		{
		}

		// Token: 0x0600013E RID: 318 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyNetworkSoundDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x000153E5 File Offset: 0x000135E5
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00015404 File Offset: 0x00013604
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00015416 File Offset: 0x00013616
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00015428 File Offset: 0x00013628
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				this.setBlockData(this._block);
				base.Close();
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00015459 File Offset: 0x00013659
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00015478 File Offset: 0x00013678
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0001548A File Offset: 0x0001368A
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0001549C File Offset: 0x0001369C
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x04000190 RID: 400
		private ProgramModule.BlockNetworkSound _block;
	}
}
