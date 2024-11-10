using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000043 RID: 67
	public partial class NetworkPortWindow : Form
	{
		// Token: 0x06000697 RID: 1687 RVA: 0x0004EC0F File Offset: 0x0004CE0F
		public NetworkPortWindow()
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this.numericUpDownPort.Value = NetworkConnectionWindow.Port;
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x000024F1 File Offset: 0x000006F1
		private void NetworkPortWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0004EC4C File Offset: 0x0004CE4C
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0004EC6B File Offset: 0x0004CE6B
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0004EC7D File Offset: 0x0004CE7D
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x0004EC90 File Offset: 0x0004CE90
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				ConfigFile.Instance.Data.NetworkPortNumber = (NetworkConnectionWindow.Port = (int)this.numericUpDownPort.Value);
				ConfigFile.Instance.Save();
				base.Close();
			}
		}
	}
}
