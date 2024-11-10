using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000058 RID: 88
	public partial class StartWindowPrimary : Form
	{
		// Token: 0x06000964 RID: 2404 RVA: 0x0006AC78 File Offset: 0x00068E78
		public StartWindowPrimary()
		{
			this.InitializeComponent();
			CommunicationModule.Instance.initialize();
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x0006AC94 File Offset: 0x00068E94
		private void openIconWindow(ProgramModules programs, bool tutorial)
		{
			IconWindow iconWindow = new IconWindow(programs, tutorial);
			base.WindowState = FormWindowState.Minimized;
			iconWindow.ShowDialog();
			base.WindowState = FormWindowState.Normal;
			if (iconWindow.Convert)
			{
				this.openFlowchartWindow(iconWindow.Programs, false);
			}
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x0006ACD4 File Offset: 0x00068ED4
		private void openFlowchartWindow(ProgramModules programs, bool tutorial)
		{
			FlowchartWindow flowchartWindow = new FlowchartWindow(programs, tutorial, false);
			base.WindowState = FormWindowState.Minimized;
			flowchartWindow.ShowDialog();
			base.WindowState = FormWindowState.Normal;
			if (flowchartWindow.Convert)
			{
				this.openIconWindow(flowchartWindow.Programs, false);
			}
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x000691B4 File Offset: 0x000673B4
		private void StartWindowPrimary_FormClosing(object sender, FormClosingEventArgs e)
		{
			CommunicationModule.Instance.terminate();
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0006AD14 File Offset: 0x00068F14
		private void pictureBoxIcon_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxIcon.Image = Resources.top_btn_001p;
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0006AD26 File Offset: 0x00068F26
		private void pictureBoxIcon_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxIcon.Image = Resources.top_btn_000p;
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x0006AD38 File Offset: 0x00068F38
		private void pictureBoxIcon_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxIcon.Image = Resources.top_btn_002p;
			}
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0006AD58 File Offset: 0x00068F58
		private void pictureBoxIcon_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgramModules programModules = new ProgramModules();
				programModules.initialize(false);
				programModules.Programs[0].Start.Next = programModules.Programs[0].End;
				this.openIconWindow(programModules, false);
			}
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x0006ADA6 File Offset: 0x00068FA6
		private void pictureBoxIconTutorial_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxIconTutorial.Image = Resources.top_btn_011p;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0006ADB8 File Offset: 0x00068FB8
		private void pictureBoxIconTutorial_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxIconTutorial.Image = Resources.top_btn_010p;
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0006ADCA File Offset: 0x00068FCA
		private void pictureBoxIconTutorial_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxIconTutorial.Image = Resources.top_btn_012p;
			}
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0006ADEC File Offset: 0x00068FEC
		private void pictureBoxIconTutorial_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgramModules programModules = new ProgramModules();
				programModules.initialize(false);
				programModules.Programs[0].Start.Next = programModules.Programs[0].End;
				this.openIconWindow(programModules, true);
			}
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0006AE3A File Offset: 0x0006903A
		private void pictureBoxFlowchart_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxFlowchart.Image = Resources.top_btn_021p;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0006AE4C File Offset: 0x0006904C
		private void pictureBoxFlowchart_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxFlowchart.Image = Resources.top_btn_020p;
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0006AE5E File Offset: 0x0006905E
		private void pictureBoxFlowchart_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxFlowchart.Image = Resources.top_btn_022p;
			}
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0006AE80 File Offset: 0x00069080
		private void pictureBoxFlowchart_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgramModules programModules = new ProgramModules();
				programModules.initialize(false);
				this.openFlowchartWindow(programModules, false);
			}
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x0006AEAF File Offset: 0x000690AF
		private void pictureBoxFlowchartTutorial_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxFlowchartTutorial.Image = Resources.top_btn_031p;
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x0006AEC1 File Offset: 0x000690C1
		private void pictureBoxFlowchartTutorial_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxFlowchartTutorial.Image = Resources.top_btn_030p;
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x0006AED3 File Offset: 0x000690D3
		private void pictureBoxFlowchartTutorial_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxFlowchartTutorial.Image = Resources.top_btn_032p;
			}
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0006AEF4 File Offset: 0x000690F4
		private void pictureBoxFlowchartTutorial_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgramModules programModules = new ProgramModules();
				programModules.initialize(false);
				this.openFlowchartWindow(programModules, true);
			}
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0006AF23 File Offset: 0x00069123
		private void pictureBoxMelody_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxMelody.Image = Resources.top_btn_041p;
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0006AF35 File Offset: 0x00069135
		private void pictureBoxMelody_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxMelody.Image = Resources.top_btn_040p;
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0006AF47 File Offset: 0x00069147
		private void pictureBoxMelody_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxMelody.Image = Resources.top_btn_042p;
			}
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x000693E2 File Offset: 0x000675E2
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

		// Token: 0x0600097C RID: 2428 RVA: 0x0006AF66 File Offset: 0x00069166
		private void pictureBoxMelodyTutorial_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxMelodyTutorial.Image = Resources.top_btn_051p;
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0006AF78 File Offset: 0x00069178
		private void pictureBoxMelodyTutorial_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxMelodyTutorial.Image = Resources.top_btn_050p;
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0006AF8A File Offset: 0x0006918A
		private void pictureBoxMelodyTutorial_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxMelodyTutorial.Image = Resources.top_btn_052p;
			}
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0006944E File Offset: 0x0006764E
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

		// Token: 0x06000980 RID: 2432 RVA: 0x0006AFA9 File Offset: 0x000691A9
		private void pictureBoxSetting_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxSetting.Image = Resources.top_btn_061p;
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0006AFBB File Offset: 0x000691BB
		private void pictureBoxSetting_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxSetting.Image = Resources.top_btn_060p;
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0006AFCD File Offset: 0x000691CD
		private void pictureBoxSetting_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxSetting.Image = Resources.top_btn_062p;
			}
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x00069699 File Offset: 0x00067899
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

		// Token: 0x06000984 RID: 2436 RVA: 0x0006AFEC File Offset: 0x000691EC
		private void pictureBoxHardwareCheck_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxHardwareCheck.Image = Resources.top_btn_101p;
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0006AFFE File Offset: 0x000691FE
		private void pictureBoxHardwareCheck_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxHardwareCheck.Image = Resources.top_btn_100p;
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0006B010 File Offset: 0x00069210
		private void pictureBoxHardwareCheck_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxHardwareCheck.Image = Resources.top_btn_102p;
			}
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x00069704 File Offset: 0x00067904
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

		// Token: 0x06000988 RID: 2440 RVA: 0x0006B02F File Offset: 0x0006922F
		private void pictureBoxHelp_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxHelp.Image = Resources.top_btn_071p;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0006B041 File Offset: 0x00069241
		private void pictureBoxHelp_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxHelp.Image = Resources.top_btn_070p;
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0006B053 File Offset: 0x00069253
		private void pictureBoxHelp_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxHelp.Image = Resources.top_btn_072p;
			}
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0006976F File Offset: 0x0006796F
		private void pictureBoxHelp_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Process.Start(".\\説明書\\Manual.pdf");
			}
		}
	}
}
