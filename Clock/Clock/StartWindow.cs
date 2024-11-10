using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000056 RID: 86
	public partial class StartWindow : Form
	{
		// Token: 0x0600091D RID: 2333 RVA: 0x000690B4 File Offset: 0x000672B4
		public StartWindow()
		{
			this.InitializeComponent();
			CommunicationModule.Instance.initialize();
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x000690D0 File Offset: 0x000672D0
		private void openIconWindow(ProgramModules programs, bool tutorial)
		{
			IconWindow iconWindow = new IconWindow(programs, tutorial);
			base.WindowState = FormWindowState.Minimized;
			iconWindow.ShowDialog();
			base.WindowState = FormWindowState.Normal;
			if (iconWindow.Convert)
			{
				this.openFlowchartWindow(iconWindow.Programs, false, false, true);
			}
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00069114 File Offset: 0x00067314
		private void openFlowchartWindow(ProgramModules programs, bool tutorial, bool isBlock, bool isConvert)
		{
			FlowchartWindow flowchartWindow = new FlowchartWindow(programs, tutorial, isBlock);
			if (isConvert)
			{
				flowchartWindow.addHistory(false);
			}
			base.WindowState = FormWindowState.Minimized;
			flowchartWindow.ShowDialog();
			base.WindowState = FormWindowState.Normal;
			if (flowchartWindow.Convert)
			{
				this.openFlowchartWindow(flowchartWindow.Programs, false, !isBlock, true);
			}
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00069164 File Offset: 0x00067364
		private void openNetworkWindow(NetworkProgramModules programs, bool tutorial, bool isBlock, bool isConvert)
		{
			NetworkWindow networkWindow = new NetworkWindow(programs, tutorial, isBlock);
			if (isConvert)
			{
				networkWindow.addHistory(false);
			}
			base.WindowState = FormWindowState.Minimized;
			networkWindow.ShowDialog();
			base.WindowState = FormWindowState.Normal;
			if (networkWindow.Convert)
			{
				this.openNetworkWindow(networkWindow.Programs, false, !isBlock, true);
			}
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x000691B4 File Offset: 0x000673B4
		private void StartWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			CommunicationModule.Instance.terminate();
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x000691C0 File Offset: 0x000673C0
		private void pictureBoxFlowchart_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxFlowchart.Image = Resources.top_btn_021;
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x000691D2 File Offset: 0x000673D2
		private void pictureBoxFlowchart_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxFlowchart.Image = Resources.top_btn_020;
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x000691E4 File Offset: 0x000673E4
		private void pictureBoxFlowchart_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxFlowchart.Image = Resources.top_btn_022;
			}
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x00069204 File Offset: 0x00067404
		private void pictureBoxFlowchart_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgramModules programModules = new ProgramModules();
				programModules.initialize(false);
				this.openFlowchartWindow(programModules, false, false, false);
			}
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x00069235 File Offset: 0x00067435
		private void pictureBoxFlowchartBlock_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxFlowchartBlock.Image = Resources.top_btn_111;
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x00069247 File Offset: 0x00067447
		private void pictureBoxFlowchartBlock_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxFlowchartBlock.Image = Resources.top_btn_110;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00069259 File Offset: 0x00067459
		private void pictureBoxFlowchartBlock_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxFlowchartBlock.Image = Resources.top_btn_112;
			}
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x00069278 File Offset: 0x00067478
		private void pictureBoxFlowchartBlock_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgramModule.BlockLabel.LabelIndexCount = 1;
				ProgramModules programModules = new ProgramModules();
				programModules.initialize(true);
				this.openFlowchartWindow(programModules, false, true, false);
			}
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x000692AF File Offset: 0x000674AF
		private void pictureBoxFlowchartTutorial_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxFlowchartTutorial.Image = Resources.top_btn_031;
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x000692C1 File Offset: 0x000674C1
		private void pictureBoxFlowchartTutorial_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxFlowchartTutorial.Image = Resources.top_btn_030;
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x000692D3 File Offset: 0x000674D3
		private void pictureBoxFlowchartTutorial_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxFlowchartTutorial.Image = Resources.top_btn_032;
			}
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x000692F4 File Offset: 0x000674F4
		private void pictureBoxFlowchartTutorial_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgramModules programModules = new ProgramModules();
				programModules.initialize(false);
				this.openFlowchartWindow(programModules, true, false, false);
			}
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x00069325 File Offset: 0x00067525
		private void pictureBoxFlowchartBlockTutorial_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxFlowchartBlockTutorial.Image = Resources.top_btn_031;
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x00069337 File Offset: 0x00067537
		private void pictureBoxFlowchartBlockTutorial_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxFlowchartBlockTutorial.Image = Resources.top_btn_030;
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00069349 File Offset: 0x00067549
		private void pictureBoxFlowchartBlockTutorial_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxFlowchartBlockTutorial.Image = Resources.top_btn_032;
			}
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x00069368 File Offset: 0x00067568
		private void pictureBoxFlowchartBlockTutorial_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgramModule.BlockLabel.LabelIndexCount = 1;
				ProgramModules programModules = new ProgramModules();
				programModules.initialize(true);
				this.openFlowchartWindow(programModules, true, true, false);
			}
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0006939F File Offset: 0x0006759F
		private void pictureBoxMelody_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxMelody.Image = Resources.top_btn_041;
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x000693B1 File Offset: 0x000675B1
		private void pictureBoxMelody_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxMelody.Image = Resources.top_btn_040;
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x000693C3 File Offset: 0x000675C3
		private void pictureBoxMelody_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxMelody.Image = Resources.top_btn_042;
			}
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x000693E2 File Offset: 0x000675E2
		private void pictureBoxMelody_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Form form = new MelodyWindow(false);
				base.WindowState = FormWindowState.Minimized;
				form.ShowDialog();
				base.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x0006940B File Offset: 0x0006760B
		private void pictureBoxMelodyTutorial_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxMelodyTutorial.Image = Resources.top_btn_051;
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x0006941D File Offset: 0x0006761D
		private void pictureBoxMelodyTutorial_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxMelodyTutorial.Image = Resources.top_btn_050;
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x0006942F File Offset: 0x0006762F
		private void pictureBoxMelodyTutorial_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxMelodyTutorial.Image = Resources.top_btn_052;
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0006944E File Offset: 0x0006764E
		private void pictureBoxMelodyTutorial_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Form form = new MelodyWindow(true);
				base.WindowState = FormWindowState.Minimized;
				form.ShowDialog();
				base.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00069477 File Offset: 0x00067677
		private void pictureBoxNetwork_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxNetwork.Image = Resources.top_btn_082;
			}
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00069496 File Offset: 0x00067696
		private void pictureBoxNetwork_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxNetwork.Image = Resources.top_btn_081;
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x000694A8 File Offset: 0x000676A8
		private void pictureBoxNetwork_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxNetwork.Image = Resources.top_btn_080;
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x000694BC File Offset: 0x000676BC
		private void pictureBoxNetwork_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				NetworkProgramModules networkProgramModules = new NetworkProgramModules();
				networkProgramModules.initialize();
				this.openNetworkWindow(networkProgramModules, false, false, false);
			}
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x000694EC File Offset: 0x000676EC
		private void pictureBoxNetworkBlock_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxNetworkBlock.Image = Resources.top_btn_122;
			}
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x0006950B File Offset: 0x0006770B
		private void pictureBoxNetworkBlock_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxNetworkBlock.Image = Resources.top_btn_121;
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x0006951D File Offset: 0x0006771D
		private void pictureBoxNetworkBlock_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxNetworkBlock.Image = Resources.top_btn_120;
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x00069530 File Offset: 0x00067730
		private void pictureBoxNetworkBlock_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgramModule.BlockLabel.LabelIndexCount = 1;
				NetworkProgramModules networkProgramModules = new NetworkProgramModules();
				networkProgramModules.initialize();
				this.openNetworkWindow(networkProgramModules, false, true, false);
			}
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x00069566 File Offset: 0x00067766
		private void pictureBoxNetworkTutorial_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxNetworkTutorial.Image = Resources.top_btn_092;
			}
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x00069585 File Offset: 0x00067785
		private void pictureBoxNetworkTutorial_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxNetworkTutorial.Image = Resources.top_btn_091;
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x00069597 File Offset: 0x00067797
		private void pictureBoxNetworkTutorial_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxNetworkTutorial.Image = Resources.top_btn_090;
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x000695AC File Offset: 0x000677AC
		private void pictureBoxNetworkTutorial_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				NetworkProgramModules networkProgramModules = new NetworkProgramModules();
				networkProgramModules.initialize();
				this.openNetworkWindow(networkProgramModules, true, false, false);
			}
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x000695DC File Offset: 0x000677DC
		private void pictureBoxNetworkBlockTutorial_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxNetworkBlockTutorial.Image = Resources.top_btn_092;
			}
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x000695FB File Offset: 0x000677FB
		private void pictureBoxNetworkBlockTutorial_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxNetworkBlockTutorial.Image = Resources.top_btn_091;
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x0006960D File Offset: 0x0006780D
		private void pictureBoxNetworkBlockTutorial_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxNetworkBlockTutorial.Image = Resources.top_btn_090;
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x00069620 File Offset: 0x00067820
		private void pictureBoxNetworkBlockTutorial_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgramModule.BlockLabel.LabelIndexCount = 1;
				NetworkProgramModules networkProgramModules = new NetworkProgramModules();
				networkProgramModules.initialize();
				this.openNetworkWindow(networkProgramModules, true, true, false);
			}
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x00069656 File Offset: 0x00067856
		private void pictureBoxSetting_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxSetting.Image = Resources.top_btn_061;
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x00069668 File Offset: 0x00067868
		private void pictureBoxSetting_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxSetting.Image = Resources.top_btn_060;
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x0006967A File Offset: 0x0006787A
		private void pictureBoxSetting_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxSetting.Image = Resources.top_btn_062;
			}
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00069699 File Offset: 0x00067899
		private void pictureBoxSetting_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Form form = new SettingWindow();
				base.WindowState = FormWindowState.Minimized;
				form.ShowDialog();
				base.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x000696C1 File Offset: 0x000678C1
		private void pictureBoxHardwareCheck_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxHardwareCheck.Image = Resources.top_btn_101;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x000696D3 File Offset: 0x000678D3
		private void pictureBoxHardwareCheck_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxHardwareCheck.Image = Resources.top_btn_100;
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x000696E5 File Offset: 0x000678E5
		private void pictureBoxHardwareCheck_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxHardwareCheck.Image = Resources.top_btn_102;
			}
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00069704 File Offset: 0x00067904
		private void pictureBoxHardwareCheck_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Form form = new HardwareCheckWindow();
				base.WindowState = FormWindowState.Minimized;
				form.ShowDialog();
				base.WindowState = FormWindowState.Normal;
			}
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0006972C File Offset: 0x0006792C
		private void pictureBoxHelp_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxHelp.Image = Resources.top_btn_071;
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x0006973E File Offset: 0x0006793E
		private void pictureBoxHelp_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxHelp.Image = Resources.top_btn_070;
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x00069750 File Offset: 0x00067950
		private void pictureBoxHelp_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxHelp.Image = Resources.top_btn_072;
			}
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x0006976F File Offset: 0x0006796F
		private void pictureBoxHelp_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Process.Start(".\\説明書\\Manual.pdf");
			}
		}
	}
}
