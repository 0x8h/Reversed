using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000017 RID: 23
	public partial class BlockPropertyUsbOutDialog : Form
	{
		// Token: 0x0600018C RID: 396 RVA: 0x0001902C File Offset: 0x0001722C
		public BlockPropertyUsbOutDialog(ProgramModule.BlockUsbOut block, int costMax, bool isNetworkProgram = false)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._costMax = costMax;
			switch (this._block.Mode)
			{
			case ProgramModule.BlockUsbOut.USBOUT.ON:
				this.radioButtonOn.Checked = true;
				break;
			case ProgramModule.BlockUsbOut.USBOUT.ON_TIME:
				this.radioButtonOnTime.Checked = true;
				break;
			case ProgramModule.BlockUsbOut.USBOUT.OFF:
				this.radioButtonOff.Checked = true;
				break;
			}
			if (isNetworkProgram)
			{
				this.radioButtonOnTime.Visible = false;
				this.numericUpDownTime.Visible = false;
			}
			else
			{
				this.numericUpDownTime.Value = (decimal)this._block.Time;
			}
			this.numericUpDownPower.Value = this._block.Power;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00019108 File Offset: 0x00017308
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00019127 File Offset: 0x00017327
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00019139 File Offset: 0x00017339
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0001914C File Offset: 0x0001734C
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				ProgramModule.BlockUsbOut blockUsbOut = new ProgramModule.BlockUsbOut();
				this.setBlockData(blockUsbOut);
				if (blockUsbOut.getUsedMemory() > this._costMax)
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

		// Token: 0x06000191 RID: 401 RVA: 0x000191BC File Offset: 0x000173BC
		private void setBlockData(ProgramModule.BlockUsbOut block)
		{
			if (this.radioButtonOn.Checked)
			{
				block.Mode = ProgramModule.BlockUsbOut.USBOUT.ON;
			}
			else if (this.radioButtonOnTime.Checked)
			{
				block.Mode = ProgramModule.BlockUsbOut.USBOUT.ON_TIME;
			}
			else
			{
				block.Mode = ProgramModule.BlockUsbOut.USBOUT.OFF;
			}
			if ((int)(Math.Floor(this.numericUpDownTime.Value * 100m) % (Math.Floor(this.numericUpDownTime.Value * 10m) * 10m)) >= 5)
			{
				block.Time = (float)(Math.Ceiling(this.numericUpDownTime.Value * 10m) / 10m);
			}
			else
			{
				block.Time = (float)(Math.Floor(this.numericUpDownTime.Value * 10m) / 10m);
			}
			block.Power = (int)this.numericUpDownPower.Value;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000192CD File Offset: 0x000174CD
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x000192DF File Offset: 0x000174DF
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000192F1 File Offset: 0x000174F1
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00019303 File Offset: 0x00017503
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyUsbOutDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00019328 File Offset: 0x00017528
		private void hScrollBarPower_ValueChanged(object sender, EventArgs e)
		{
			if (this.hScrollBarPower.Value != this.numericUpDownPower.Value)
			{
				this.numericUpDownPower.Value = this.hScrollBarPower.Value;
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00019367 File Offset: 0x00017567
		private void numericUpDownPower_ValueChanged(object sender, EventArgs e)
		{
			if (this.hScrollBarPower.Value != this.numericUpDownPower.Value)
			{
				this.hScrollBarPower.Value = (int)this.numericUpDownPower.Value;
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000193A6 File Offset: 0x000175A6
		private void radioButtonOn_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownTime.Enabled = false;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000193B4 File Offset: 0x000175B4
		private void radioButtonOnTime_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownTime.Enabled = true;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000193A6 File Offset: 0x000175A6
		private void radioButtonOff_CheckedChanged(object sender, EventArgs e)
		{
			this.numericUpDownTime.Enabled = false;
		}

		// Token: 0x040001D0 RID: 464
		private ProgramModule.BlockUsbOut _block;

		// Token: 0x040001D1 RID: 465
		private int _costMax;
	}
}
