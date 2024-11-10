using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000016 RID: 22
	public partial class BlockPropertySubroutineDialog : Form
	{
		// Token: 0x0600017F RID: 383 RVA: 0x00018924 File Offset: 0x00016B24
		public BlockPropertySubroutineDialog(ProgramModule.BlockSubroutine block, ProgramModules programs, string[] subroutineNames)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._programs = programs;
			this.comboBoxRoutine.Items.AddRange(subroutineNames);
			this.comboBoxRoutine.SelectedIndex = block.Index;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertySubroutineDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00018989 File Offset: 0x00016B89
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000189A8 File Offset: 0x00016BA8
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000189BA File Offset: 0x00016BBA
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000189CC File Offset: 0x00016BCC
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				int index = this._block.Index;
				this.setBlockData(this._block);
				if (this._programs.getUsedMemory(ProgramModules.ROUTINE.MAIN, true) > 256)
				{
					WarningDialog warningDialog = new WarningDialog();
					warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
					warningDialog.ShowDialog();
					this.comboBoxRoutine.SelectedIndex = index;
					this.setBlockData(this._block);
					return;
				}
				base.Close();
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00018A59 File Offset: 0x00016C59
		private void setBlockData(ProgramModule.BlockSubroutine block)
		{
			block.Index = this.comboBoxRoutine.SelectedIndex;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00018A6C File Offset: 0x00016C6C
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00018A8B File Offset: 0x00016C8B
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00018A9D File Offset: 0x00016C9D
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00018AAF File Offset: 0x00016CAF
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x040001C8 RID: 456
		private ProgramModule.BlockSubroutine _block;

		// Token: 0x040001C9 RID: 457
		private ProgramModules _programs;
	}
}
