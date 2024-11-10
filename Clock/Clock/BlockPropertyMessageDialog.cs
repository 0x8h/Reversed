using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200000E RID: 14
	public partial class BlockPropertyMessageDialog : Form
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x0000F598 File Offset: 0x0000D798
		public BlockPropertyMessageDialog(ProgramModule.BlockMessage block, NetworkProgramModules programs)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			for (int i = 0; i < programs.MessageNames.Count<string>(); i++)
			{
				this.comboBoxMessage.Items.Add(programs.MessageNames[i]);
			}
			this.comboBoxMessage.SelectedIndex = block.MessageIndex;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000F616 File Offset: 0x0000D816
		private void setBlockData(ProgramModule.BlockMessage block)
		{
			block.MessageIndex = this.comboBoxMessage.SelectedIndex;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyMessageDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000F629 File Offset: 0x0000D829
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000F648 File Offset: 0x0000D848
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000F65A File Offset: 0x0000D85A
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000F66C File Offset: 0x0000D86C
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				this.setBlockData(this._block);
				base.Close();
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000F69D File Offset: 0x0000D89D
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000F6BC File Offset: 0x0000D8BC
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000F6CE File Offset: 0x0000D8CE
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000F6E0 File Offset: 0x0000D8E0
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x0400010B RID: 267
		private ProgramModule.BlockMessage _block;
	}
}
