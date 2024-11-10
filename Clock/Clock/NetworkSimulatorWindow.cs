using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000047 RID: 71
	public partial class NetworkSimulatorWindow : Form
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060006FE RID: 1790 RVA: 0x00051BA7 File Offset: 0x0004FDA7
		// (set) Token: 0x060006FF RID: 1791 RVA: 0x00051BAF File Offset: 0x0004FDAF
		public NetworkSimulatorArea SimulatorArea { get; set; }

		// Token: 0x06000700 RID: 1792 RVA: 0x00051BB8 File Offset: 0x0004FDB8
		public NetworkSimulatorWindow(NetworkWindow window)
		{
			this.InitializeComponent();
			this._window = window;
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this.SimulatorArea = new NetworkSimulatorArea(window, new Size(base.Width, base.Height));
			this.splitContainer1.Panel2.Controls.Add(this.SimulatorArea);
			CommunicationModule.Instance.checkVersion();
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00051C35 File Offset: 0x0004FE35
		private void NetworkSimulatorWindow_Shown(object sender, EventArgs e)
		{
			this.SimulatorArea.run();
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00051C44 File Offset: 0x0004FE44
		private void NetworkSimulatorWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this._window.isTutorial())
			{
				if (this._window.Tutorial != NetworkWindow.TUTORIAL.CLOSE && this._window.Tutorial != NetworkWindow.TUTORIAL.CLOSE_2)
				{
					e.Cancel = true;
					return;
				}
				NetworkWindow window = this._window;
				NetworkWindow.TUTORIAL tutorial = window.Tutorial;
				window.Tutorial = tutorial + 1;
			}
			NetworkSimulator.Instance.stop(NetworkSimulator.ERROR.NONE);
			NetworkSimulator.Instance.Programs.reset();
			this._window.changeSimulator(false);
			this.SimulatorArea.Dispose();
		}

		// Token: 0x0400052F RID: 1327
		public NetworkWindow _window;
	}
}
