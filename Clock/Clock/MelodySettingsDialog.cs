using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200002E RID: 46
	public partial class MelodySettingsDialog : Form
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x0003D0E4 File Offset: 0x0003B2E4
		public bool Updated
		{
			get
			{
				return this._updated;
			}
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0003D0EC File Offset: 0x0003B2EC
		public MelodySettingsDialog(MelodyWindow window)
		{
			this.InitializeComponent();
			this._window = window;
			this.Text = "メロディの設定";
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this.comboBoxTempo.SelectedIndex = this._window.getTempo();
			if (this._window.getLedFlag())
			{
				this.radioButtonLinkOn.Checked = true;
			}
			else
			{
				this.radioButtonLinkOff.Checked = true;
			}
			if (window.isTutorial())
			{
				this.pictureBoxButtonCancel.Enabled = false;
				this.radioButtonLinkOn.Enabled = false;
				this.radioButtonLinkOff.Enabled = false;
			}
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0003D19A File Offset: 0x0003B39A
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0003D1B9 File Offset: 0x0003B3B9
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0003D1CB File Offset: 0x0003B3CB
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0003D1E0 File Offset: 0x0003B3E0
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				this._window.setTempo(this.comboBoxTempo.SelectedIndex);
				this._window.setLedFlag(this.radioButtonLinkOn.Checked);
				this._updated = true;
				base.Close();
			}
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0003D243 File Offset: 0x0003B443
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0003D262 File Offset: 0x0003B462
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0003D274 File Offset: 0x0003B474
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0003D286 File Offset: 0x0003B486
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x000024F1 File Offset: 0x000006F1
		private void MelodySettingsDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0003D2AB File Offset: 0x0003B4AB
		private void MelodySettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this._window.isTutorial() && this._window.getTempo() != 1)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x040003F0 RID: 1008
		private MelodyWindow _window;

		// Token: 0x040003F1 RID: 1009
		private bool _updated;
	}
}
