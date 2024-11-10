using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000059 RID: 89
	public partial class TutorialWindow : Form
	{
		// Token: 0x0600098E RID: 2446 RVA: 0x0006BAA4 File Offset: 0x00069CA4
		public TutorialWindow(Form window)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._window = window;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0006BAD4 File Offset: 0x00069CD4
		public void initialize(Image image, string text, TutorialWindow.BUTTON_MODE buttonMode)
		{
			this.pictureBoxImage.Image = image;
			this.labelText.Text = text;
			this._buttonMode = buttonMode;
			if (this._buttonMode == TutorialWindow.BUTTON_MODE.QUIT)
			{
				this.pictureBoxButtonNext.Visible = false;
				this.pictureBoxButtonQuit.Location = new Point((base.Width - this.pictureBoxButtonQuit.Width) / 2, this.pictureBoxButtonQuit.Location.Y);
			}
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x000024F1 File Offset: 0x000006F1
		private void TutorialWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0006BB4C File Offset: 0x00069D4C
		private void pictureBoxButtonNext_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonNext.Image = Resources.tutorial_btn021;
			}
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0006BB6B File Offset: 0x00069D6B
		private void pictureBoxButtonNext_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonNext.Image = Resources.tutorial_btn022;
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0006BB7D File Offset: 0x00069D7D
		private void pictureBoxButtonNext_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonNext.Image = Resources.tutorial_btn020;
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x0006BB90 File Offset: 0x00069D90
		private void pictureBoxButtonNext_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonNext.Image = Resources.tutorial_btn022;
				if (this._window.GetType() == typeof(IconWindow))
				{
					IconWindow iconWindow = (IconWindow)this._window;
					IconWindow.TUTORIAL tutorial = iconWindow.Tutorial;
					iconWindow.Tutorial = tutorial + 1;
					return;
				}
				if (this._window.GetType() == typeof(FlowchartWindow))
				{
					FlowchartWindow flowchartWindow = (FlowchartWindow)this._window;
					FlowchartWindow.TUTORIAL tutorial2 = flowchartWindow.Tutorial;
					flowchartWindow.Tutorial = tutorial2 + 1;
					return;
				}
				if (this._window.GetType() == typeof(MelodyWindow))
				{
					MelodyWindow melodyWindow = (MelodyWindow)this._window;
					MelodyWindow.TUTORIAL tutorial3 = melodyWindow.Tutorial;
					melodyWindow.Tutorial = tutorial3 + 1;
					return;
				}
				if (this._window.GetType() == typeof(NetworkWindow))
				{
					NetworkWindow networkWindow = (NetworkWindow)this._window;
					NetworkWindow.TUTORIAL tutorial4 = networkWindow.Tutorial;
					networkWindow.Tutorial = tutorial4 + 1;
				}
			}
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0006BC98 File Offset: 0x00069E98
		private void pictureBoxButtonQuit_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonQuit.Image = Resources.tutorial_btn011;
			}
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0006BCB7 File Offset: 0x00069EB7
		private void pictureBoxButtonQuit_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonQuit.Image = Resources.tutorial_btn012;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0006BCC9 File Offset: 0x00069EC9
		private void pictureBoxButtonQuit_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonQuit.Image = Resources.tutorial_btn010;
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0006BCDB File Offset: 0x00069EDB
		private void pictureBoxButtonQuit_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonQuit.Image = Resources.tutorial_btn012;
				this._window.Close();
			}
		}

		// Token: 0x040006CD RID: 1741
		private TutorialWindow.BUTTON_MODE _buttonMode;

		// Token: 0x040006CE RID: 1742
		private Form _window;

		// Token: 0x020000DA RID: 218
		public enum BUTTON_MODE
		{
			// Token: 0x0400097D RID: 2429
			START,
			// Token: 0x0400097E RID: 2430
			QUIT
		}
	}
}
