using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000007 RID: 7
	public partial class BlockPropertyDisplayDialog : Form
	{
		// Token: 0x06000050 RID: 80 RVA: 0x00006444 File Offset: 0x00004644
		public BlockPropertyDisplayDialog(ProgramModule.BlockDisplay block, int costMax)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._costMax = costMax;
			ComboBox.ObjectCollection items = this.comboBoxMode.Items;
			object[] array = ProgramModule.BlockDisplay.MODE_ITEMS;
			items.AddRange(array);
			ComboBox.ObjectCollection items2 = this.comboBoxVariable.Items;
			array = ProgramModule.BlockIf.VARIABLE_ITEMS;
			items2.AddRange(array);
			if (this._block.Mode == ProgramModule.BlockDisplay.DISPLAY_MODE.MAX)
			{
				this.radioButtonDisable.Select();
				this.comboBoxMode.SelectedIndex = 0;
			}
			else
			{
				this.radioButtonEnable.Select();
				this.comboBoxMode.SelectedIndex = (int)this._block.Mode;
			}
			this.comboBoxVariable.SelectedIndex = this._block.VariableIndex;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyDisplayDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00006511 File Offset: 0x00004711
		private void radioButtonEnable_CheckedChanged(object sender, EventArgs e)
		{
			this.comboBoxMode.Enabled = true;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000651F File Offset: 0x0000471F
		private void radioButtonDisable_CheckedChanged(object sender, EventArgs e)
		{
			this.comboBoxMode.Enabled = false;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000652D File Offset: 0x0000472D
		private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboBoxVariable.Enabled = this.comboBoxMode.SelectedIndex == 2;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00006548 File Offset: 0x00004748
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00006567 File Offset: 0x00004767
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00006579 File Offset: 0x00004779
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000658C File Offset: 0x0000478C
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				ProgramModule.BlockDisplay blockDisplay = new ProgramModule.BlockDisplay();
				this.setBlockData(blockDisplay);
				if (blockDisplay.getUsedMemory() > this._costMax)
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

		// Token: 0x06000059 RID: 89 RVA: 0x000065FC File Offset: 0x000047FC
		private void setBlockData(ProgramModule.BlockDisplay block)
		{
			if (this.radioButtonEnable.Checked)
			{
				block.Mode = (ProgramModule.BlockDisplay.DISPLAY_MODE)this.comboBoxMode.SelectedIndex;
				block.VariableIndex = this.comboBoxVariable.SelectedIndex;
				return;
			}
			block.Mode = ProgramModule.BlockDisplay.DISPLAY_MODE.MAX;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006635 File Offset: 0x00004835
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00006654 File Offset: 0x00004854
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00006666 File Offset: 0x00004866
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00006678 File Offset: 0x00004878
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x04000044 RID: 68
		private ProgramModule.BlockDisplay _block;

		// Token: 0x04000045 RID: 69
		private int _costMax;
	}
}
