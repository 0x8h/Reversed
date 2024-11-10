using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000029 RID: 41
	public partial class InformationDialog : Form
	{
		// Token: 0x06000471 RID: 1137 RVA: 0x00037C2E File Offset: 0x00035E2E
		public InformationDialog()
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00037C58 File Offset: 0x00035E58
		public void setText(string text)
		{
			this.labelText.Text = text;
			this.labelText.Location = new Point((base.Width - this.labelText.Width) / 2, this.labelText.Location.Y);
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00037CA8 File Offset: 0x00035EA8
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00037CC7 File Offset: 0x00035EC7
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00037CD9 File Offset: 0x00035ED9
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00037CEB File Offset: 0x00035EEB
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				base.Close();
			}
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x000024F1 File Offset: 0x000006F1
		private void InformationDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}
	}
}
