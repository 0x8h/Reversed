using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000019 RID: 25
	public partial class BlockPropertyWaitDialog : Form
	{
		// Token: 0x060001B3 RID: 435 RVA: 0x0001B444 File Offset: 0x00019644
		public BlockPropertyWaitDialog(ProgramModule.BlockWait block, int costMax, bool isNetworkProgram = false)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._costMax = costMax;
			if (isNetworkProgram)
			{
				this.numericUpDownTime.Minimum = 0.1m;
				this.numericUpDownTime.Maximum = 300.0m;
			}
			this.numericUpDownTime.Value = (decimal)this._block.Time;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0001B4D1 File Offset: 0x000196D1
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0001B4F0 File Offset: 0x000196F0
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0001B502 File Offset: 0x00019702
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0001B514 File Offset: 0x00019714
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				ProgramModule.BlockWait blockWait = new ProgramModule.BlockWait();
				this.setBlockData(blockWait);
				if (blockWait.getUsedMemory() > this._costMax)
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

		// Token: 0x060001B8 RID: 440 RVA: 0x0001B584 File Offset: 0x00019784
		private void setBlockData(ProgramModule.BlockWait block)
		{
			if ((int)(Math.Floor(this.numericUpDownTime.Value * 100m) % (Math.Floor(this.numericUpDownTime.Value * 10m) * 10m)) >= 5)
			{
				block.Time = (float)(Math.Ceiling(this.numericUpDownTime.Value * 10m) / 10m);
				return;
			}
			block.Time = (float)(Math.Floor(this.numericUpDownTime.Value * 10m) / 10m);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0001B64B File Offset: 0x0001984B
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0001B66A File Offset: 0x0001986A
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0001B67C File Offset: 0x0001987C
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0001B68E File Offset: 0x0001988E
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x060001BD RID: 445 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyWaitDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x040001F9 RID: 505
		private ProgramModule.BlockWait _block;

		// Token: 0x040001FA RID: 506
		private int _costMax;
	}
}
