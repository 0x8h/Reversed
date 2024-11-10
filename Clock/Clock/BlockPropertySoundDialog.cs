using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000015 RID: 21
	public partial class BlockPropertySoundDialog : Form
	{
		// Token: 0x06000171 RID: 369 RVA: 0x00018138 File Offset: 0x00016338
		public BlockPropertySoundDialog(ProgramModule.BlockSound block, int costMax)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._costMax = costMax;
			foreach (string text in BlockPropertySoundDialog.SOUND_ITEMS)
			{
				this.comboBoxSound.Items.Add(text);
			}
			switch (this._block.Mode)
			{
			case ProgramModule.BlockSound.MODE.BEEP:
				this.comboBoxSound.SelectedIndex = this._block.BeepIndex;
				return;
			case ProgramModule.BlockSound.MODE.MELODY_PLAY:
				if (this._block.Loop)
				{
					this.comboBoxSound.SelectedIndex = 4;
					return;
				}
				this.comboBoxSound.SelectedIndex = 3;
				return;
			case ProgramModule.BlockSound.MODE.MELODY_STOP:
				this.comboBoxSound.SelectedIndex = 5;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0001820C File Offset: 0x0001640C
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0001822B File Offset: 0x0001642B
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0001823D File Offset: 0x0001643D
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00018250 File Offset: 0x00016450
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				ProgramModule.BlockSound blockSound = new ProgramModule.BlockSound();
				this.setBlockData(blockSound);
				if (blockSound.getUsedMemory() > this._costMax)
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

		// Token: 0x06000176 RID: 374 RVA: 0x000182C0 File Offset: 0x000164C0
		private void setBlockData(ProgramModule.BlockSound block)
		{
			switch (this.comboBoxSound.SelectedIndex)
			{
			case 0:
			case 1:
			case 2:
				block.Mode = ProgramModule.BlockSound.MODE.BEEP;
				block.BeepIndex = this.comboBoxSound.SelectedIndex;
				return;
			case 3:
				block.Mode = ProgramModule.BlockSound.MODE.MELODY_PLAY;
				block.Loop = false;
				return;
			case 4:
				block.Mode = ProgramModule.BlockSound.MODE.MELODY_PLAY;
				block.Loop = true;
				return;
			case 5:
				block.Mode = ProgramModule.BlockSound.MODE.MELODY_STOP;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00018336 File Offset: 0x00016536
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00018355 File Offset: 0x00016555
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00018367 File Offset: 0x00016567
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00018379 File Offset: 0x00016579
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertySoundDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x040001BF RID: 447
		public static readonly string[] SOUND_ITEMS = new string[] { "サウンド①", "サウンド②", "サウンド③", "メロディ再生", "メロディ再生(連続)", "メロディ停止" };

		// Token: 0x040001C0 RID: 448
		private ProgramModule.BlockSound _block;

		// Token: 0x040001C1 RID: 449
		private int _costMax;

		// Token: 0x0200006E RID: 110
		public enum SOUND
		{
			// Token: 0x0400072B RID: 1835
			BEEP_0,
			// Token: 0x0400072C RID: 1836
			BEEP_1,
			// Token: 0x0400072D RID: 1837
			BEEP_2,
			// Token: 0x0400072E RID: 1838
			MELODY_PLAY,
			// Token: 0x0400072F RID: 1839
			MELODY_PLAY_LOOP,
			// Token: 0x04000730 RID: 1840
			MELODY_STOP,
			// Token: 0x04000731 RID: 1841
			MAX
		}
	}
}
