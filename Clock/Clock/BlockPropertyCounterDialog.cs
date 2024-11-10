using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000005 RID: 5
	public partial class BlockPropertyCounterDialog : Form
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00004228 File Offset: 0x00002428
		public BlockPropertyCounterDialog(ProgramModule.BlockCounter block, int costMax)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._costMax = costMax;
			switch (this._block.Command)
			{
			case ProgramModule.BlockCounter.COMMAND.START:
				this.radioButtonStart.Select();
				return;
			case ProgramModule.BlockCounter.COMMAND.STOP:
				this.radioButtonStop.Select();
				return;
			case ProgramModule.BlockCounter.COMMAND.RESET:
				this.radioButtonReset.Select();
				return;
			default:
				return;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyCounterDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000042AB File Offset: 0x000024AB
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000042CA File Offset: 0x000024CA
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000042DC File Offset: 0x000024DC
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000042F0 File Offset: 0x000024F0
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				ProgramModule.BlockCounter blockCounter = new ProgramModule.BlockCounter();
				this.setBlockData(blockCounter);
				if (blockCounter.getUsedMemory() > this._costMax)
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

		// Token: 0x06000032 RID: 50 RVA: 0x00004360 File Offset: 0x00002560
		private void setBlockData(ProgramModule.BlockCounter block)
		{
			if (this.radioButtonStart.Checked)
			{
				block.Command = ProgramModule.BlockCounter.COMMAND.START;
				return;
			}
			if (this.radioButtonStop.Checked)
			{
				block.Command = ProgramModule.BlockCounter.COMMAND.STOP;
				return;
			}
			block.Command = ProgramModule.BlockCounter.COMMAND.RESET;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004393 File Offset: 0x00002593
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000043B2 File Offset: 0x000025B2
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000043C4 File Offset: 0x000025C4
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000043D6 File Offset: 0x000025D6
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x04000024 RID: 36
		private ProgramModule.BlockCounter _block;

		// Token: 0x04000025 RID: 37
		private int _costMax;
	}
}
