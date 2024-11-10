using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200000A RID: 10
	public partial class BlockPropertyJumpDialog : Form
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00009C38 File Offset: 0x00007E38
		public BlockPropertyJumpDialog(ProgramModule.BlockJump block, List<ProgramModule.BlockLabel> labels)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._labels = labels;
			foreach (ProgramModule.BlockLabel blockLabel in labels)
			{
				this.comboBoxLabel.Items.Add(blockLabel.getDetailBlock(false));
			}
			this.comboBoxLabel.SelectedIndex = labels.IndexOf(block.Label);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyJumpDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00009CE4 File Offset: 0x00007EE4
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00009D03 File Offset: 0x00007F03
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00009D15 File Offset: 0x00007F15
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00009D27 File Offset: 0x00007F27
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				this.setBlockData(this._block);
				base.Close();
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00009D58 File Offset: 0x00007F58
		private void setBlockData(ProgramModule.BlockJump block)
		{
			if (this.comboBoxLabel.SelectedIndex >= 0)
			{
				block.Label = this._labels[this.comboBoxLabel.SelectedIndex];
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00009D84 File Offset: 0x00007F84
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00009DA3 File Offset: 0x00007FA3
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00009DB5 File Offset: 0x00007FB5
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00009DC7 File Offset: 0x00007FC7
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x04000097 RID: 151
		private ProgramModule.BlockJump _block;

		// Token: 0x04000098 RID: 152
		private List<ProgramModule.BlockLabel> _labels;
	}
}
