using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200000C RID: 12
	public partial class BlockPropertyLoopDialog : Form
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x0000C4D4 File Offset: 0x0000A6D4
		public BlockPropertyLoopDialog(ProgramModule.BlockLoopStart block, int costMax)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._costMax = costMax;
			if (this._block.Count == 0)
			{
				this.radioButtonEternal.Checked = true;
				return;
			}
			this.radioButtonCount.Checked = true;
			this.numericUpDownCount.Value = this._block.Count;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000C556 File Offset: 0x0000A756
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000C575 File Offset: 0x0000A775
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000C587 File Offset: 0x0000A787
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000C59C File Offset: 0x0000A79C
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				ProgramModule.BlockLoopStart blockLoopStart = new ProgramModule.BlockLoopStart();
				this.setBlockData(blockLoopStart);
				if (blockLoopStart.getUsedMemory() > this._costMax)
				{
					WarningDialog warningDialog = new WarningDialog();
					warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
					warningDialog.ShowDialog();
					return;
				}
				this.setBlockData(this._block);
				base.Close();
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000C60C File Offset: 0x0000A80C
		private void setBlockData(ProgramModule.BlockLoopStart block)
		{
			if (this.radioButtonEternal.Checked)
			{
				block.Count = 0;
				return;
			}
			block.Count = (int)this.numericUpDownCount.Value;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000C639 File Offset: 0x0000A839
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000C658 File Offset: 0x0000A858
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000C66A File Offset: 0x0000A86A
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000C67C File Offset: 0x0000A87C
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyLoopDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000C6A1 File Offset: 0x0000A8A1
		private void radioButtonCount_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownCount.Enabled = true;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000C6AF File Offset: 0x0000A8AF
		private void radioButtonEternal_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownCount.Enabled = false;
		}

		// Token: 0x040000BE RID: 190
		private ProgramModule.BlockLoopStart _block;

		// Token: 0x040000BF RID: 191
		private int _costMax;
	}
}
