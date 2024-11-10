using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000055 RID: 85
	public partial class SimulatorWindow : Form
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060008ED RID: 2285 RVA: 0x00066A34 File Offset: 0x00064C34
		public Simulator Simulator
		{
			get
			{
				return this._simulator;
			}
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00066A3C File Offset: 0x00064C3C
		public SimulatorWindow(IconWindow iconWindow, FlowchartWindow flowchartWindow)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 20;
			this.splitContainer1.SplitterDistance = 20;
			base.KeyPreview = true;
			this._iconWindow = iconWindow;
			this._flowchartWindow = flowchartWindow;
			this._simulator = new Simulator(this);
			this._clock = new SimulatorClock(this._simulator);
			this.splitContainer1.Panel2.Controls.Add(this._clock);
			this._thermometer = new SimulatorThermometer(this._simulator);
			this.splitContainer1.Panel2.Controls.Add(this._thermometer);
			if (iconWindow != null)
			{
				this.hScrollBarLight.Enabled = false;
				this.textBoxLight.Enabled = false;
			}
			this.updateUsbInOutEnable();
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00066B09 File Offset: 0x00064D09
		public Color getColor()
		{
			return this._clock.BackColor;
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x00066B16 File Offset: 0x00064D16
		public void setColor(Color color)
		{
			if (this._clock.BackColor != color)
			{
				this._clock.BackColor = color;
				this._clock.Invalidate();
			}
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00066B44 File Offset: 0x00064D44
		public void setDisplayMode(ProgramModule.BlockDisplay.DISPLAY_MODE mode, int variableIndex)
		{
			if (this._clock.DisplayMode != mode || this._clock.VariableIndex != variableIndex)
			{
				this._clock.DisplayMode = mode;
				this._clock.VariableIndex = variableIndex;
				this._clock.Invalidate();
			}
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x00066B90 File Offset: 0x00064D90
		public void updateClock()
		{
			this._clock.Invalidate();
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00066B9D File Offset: 0x00064D9D
		public void updateUsbInOutEnable()
		{
			if (this._flowchartWindow != null)
			{
				this.labelUsbIn.Visible = this._flowchartWindow.IsUsbInOutEnable;
				this.pictureBoxButtonUsbIn.Visible = this._flowchartWindow.IsUsbInOutEnable;
			}
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x00066BD4 File Offset: 0x00064DD4
		public void setSoundImage(ProgramModule.BlockSound.MODE mode)
		{
			switch (mode)
			{
			case ProgramModule.BlockSound.MODE.BEEP:
				this.pictureBoxSound.Image = Resources.sim_balloon_000;
				return;
			case ProgramModule.BlockSound.MODE.MELODY_PLAY:
				this.pictureBoxSound.Image = Resources.sim_balloon_010;
				return;
			case ProgramModule.BlockSound.MODE.MELODY_STOP:
				this.pictureBoxSound.Image = null;
				return;
			default:
				return;
			}
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x00066C22 File Offset: 0x00064E22
		public void setUsbOut(bool enable)
		{
			this.pictureBoxUsbOut.Image = (enable ? Resources.sim_icon_020 : null);
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00066C3C File Offset: 0x00064E3C
		public void onUpdateSimulator()
		{
			if (this._iconWindow != null)
			{
				this._iconWindow.updateSelect();
				this._iconWindow.Enabled = this._simulator.State == Simulator.STATE.STOP;
			}
			else if (this._flowchartWindow != null)
			{
				this._flowchartWindow.changeRoutine(this._simulator.Routine);
				this._flowchartWindow.Area.Invalidate();
				this._flowchartWindow.Enabled = this._simulator.State == Simulator.STATE.STOP;
				if (this._flowchartWindow.InformationWindow != null)
				{
					this._flowchartWindow.InformationWindow.updateView();
				}
			}
			this.updateButtonImage();
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x00066CE1 File Offset: 0x00064EE1
		private void run(bool step)
		{
			if (this._simulator.BreakBlock == null)
			{
				this._simulator.initialize(this.getPrograms());
			}
			this._simulator.run(step);
			this.updateButtonImage();
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00066D14 File Offset: 0x00064F14
		private void updateButtonImage()
		{
			Simulator.STATE state = this._simulator.State;
			if (state == Simulator.STATE.STOP)
			{
				this.pictureBoxButtonRun.Image = Resources.sim_btn_050;
				this.pictureBoxButtonStop.Image = Resources.sim_btn_063;
				this.pictureBoxButtonRunStep.Image = Resources.sim_btn_070;
				return;
			}
			if (state != Simulator.STATE.RUN)
			{
				return;
			}
			this.pictureBoxButtonRun.Image = Resources.sim_btn_053;
			this.pictureBoxButtonStop.Image = Resources.sim_btn_060;
			this.pictureBoxButtonRunStep.Image = Resources.sim_btn_073;
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00066D96 File Offset: 0x00064F96
		private ProgramModules getPrograms()
		{
			if (this._iconWindow != null)
			{
				return this._iconWindow.Programs;
			}
			return this._flowchartWindow.Programs;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x00066DB7 File Offset: 0x00064FB7
		private void SimulatorWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this._simulator.State == Simulator.STATE.RUN)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00066DCE File Offset: 0x00064FCE
		private void SimulatorWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
			if (this._iconWindow != null)
			{
				this._iconWindow.SimulatorWindow = null;
				return;
			}
			this._flowchartWindow.SimulatorWindow = null;
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00066DF7 File Offset: 0x00064FF7
		private void SimulatorWindow_KeyDown(object sender, KeyEventArgs e)
		{
			if ((e.KeyData & Keys.F8) == Keys.F8 && this._simulator.State == Simulator.STATE.STOP)
			{
				this.run(true);
			}
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x00066E1A File Offset: 0x0006501A
		private void numericUpDownHour_ValueChanged(object sender, EventArgs e)
		{
			this._simulator.Hour = (int)this.numericUpDownHour.Value;
			this._clock.DisplayMode = ProgramModule.BlockDisplay.DISPLAY_MODE.TIME;
			this._clock.Invalidate();
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00066E4E File Offset: 0x0006504E
		private void numericUpDownMinute_ValueChanged(object sender, EventArgs e)
		{
			this._simulator.Minute = (int)this.numericUpDownMinute.Value;
			this._clock.DisplayMode = ProgramModule.BlockDisplay.DISPLAY_MODE.TIME;
			this._clock.Invalidate();
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00066E84 File Offset: 0x00065084
		private void pictureBoxButtonBright_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.X < this.pictureBoxButtonBright.Image.Width / 2)
			{
				this._simulator.Light = Simulator.LIGHT.BRIGHT;
			}
			else
			{
				this._simulator.Light = Simulator.LIGHT.DARK;
			}
			this.pictureBoxButtonBright.Image = ((this._simulator.Light == Simulator.LIGHT.BRIGHT) ? Resources.sim_btn_000 : Resources.sim_btn_001);
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00066EE9 File Offset: 0x000650E9
		private void pictureBoxButtonButton_MouseDown(object sender, MouseEventArgs e)
		{
			this.pictureBoxButtonButton.Image = Resources.sim_btn_010;
			this._simulator.Button = true;
			this._simulator.Alarm = false;
			this.pictureBoxButtonAlarm.Image = Resources.sim_btn_031;
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x00066F23 File Offset: 0x00065123
		private void pictureBoxButtonButton_MouseUp(object sender, MouseEventArgs e)
		{
			this.pictureBoxButtonButton.Image = Resources.sim_btn_011;
			this._simulator.Button = false;
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x00066F41 File Offset: 0x00065141
		private void pictureBoxButtonSound_MouseDown(object sender, MouseEventArgs e)
		{
			this.pictureBoxButtonSound.Image = Resources.sim_btn_040;
			this._simulator.Sound = true;
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00066F5F File Offset: 0x0006515F
		private void pictureBoxButtonSound_MouseUp(object sender, MouseEventArgs e)
		{
			this.pictureBoxButtonSound.Image = Resources.sim_btn_041;
			this._simulator.Sound = false;
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00066F7D File Offset: 0x0006517D
		private void pictureBoxButtonAlarm_MouseClick(object sender, MouseEventArgs e)
		{
			this._simulator.Alarm = !this._simulator.Alarm;
			this.pictureBoxButtonAlarm.Image = (this._simulator.Alarm ? Resources.sim_btn_030 : Resources.sim_btn_031);
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00066FBC File Offset: 0x000651BC
		private void pictureBoxButtonTimer_MouseClick(object sender, MouseEventArgs e)
		{
			this._simulator.Timer = !this._simulator.Timer;
			this.pictureBoxButtonTimer.Image = (this._simulator.Timer ? Resources.sim_btn_020 : Resources.sim_btn_021);
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x00066FFB File Offset: 0x000651FB
		private void pictureBoxButtonUsbIn_MouseClick(object sender, MouseEventArgs e)
		{
			this._simulator.UsbIn = !this._simulator.UsbIn;
			this.pictureBoxButtonUsbIn.Image = (this._simulator.UsbIn ? Resources.sim_btn_080 : Resources.sim_btn_081);
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0006703A File Offset: 0x0006523A
		private void pictureBoxButtonRun_MouseDown(object sender, MouseEventArgs e)
		{
			if (this._simulator.isRunnable() && e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRun.Image = Resources.sim_btn_052;
			}
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x00067066 File Offset: 0x00065266
		private void pictureBoxButtonRun_MouseEnter(object sender, EventArgs e)
		{
			if (this._simulator.isRunnable())
			{
				this.pictureBoxButtonRun.Image = Resources.sim_btn_051;
			}
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x00067085 File Offset: 0x00065285
		private void pictureBoxButtonRun_MouseLeave(object sender, EventArgs e)
		{
			if (this._simulator.isRunnable())
			{
				this.pictureBoxButtonRun.Image = Resources.sim_btn_050;
			}
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x000670A4 File Offset: 0x000652A4
		private void pictureBoxButtonRun_MouseUp(object sender, MouseEventArgs e)
		{
			if (this._simulator.isRunnable() && e.Button == MouseButtons.Left)
			{
				this.getPrograms().updateConnectState();
				ProgramModule.ERROR error = this.getPrograms().getError(false);
				if (error == ProgramModule.ERROR.NONE)
				{
					this.run(false);
					return;
				}
				WarningDialog warningDialog = new WarningDialog();
				if (FlowchartWindow.Instance.IsBlockMode)
				{
					warningDialog.setText(ProgramModule.ERROR_ITEMS_BLOCK[(int)error]);
				}
				else
				{
					warningDialog.setText(ProgramModule.ERROR_ITEMS[(int)error]);
				}
				warningDialog.ShowDialog();
			}
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00067124 File Offset: 0x00065324
		private void pictureBoxButtonStop_MouseDown(object sender, MouseEventArgs e)
		{
			if (this._simulator.State == Simulator.STATE.RUN && e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonStop.Image = Resources.sim_btn_062;
			}
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x00067151 File Offset: 0x00065351
		private void pictureBoxButtonStop_MouseEnter(object sender, EventArgs e)
		{
			if (this._simulator.State == Simulator.STATE.RUN)
			{
				this.pictureBoxButtonStop.Image = Resources.sim_btn_061;
			}
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00067171 File Offset: 0x00065371
		private void pictureBoxButtonStop_MouseLeave(object sender, EventArgs e)
		{
			if (this._simulator.State == Simulator.STATE.RUN)
			{
				this.pictureBoxButtonStop.Image = Resources.sim_btn_060;
			}
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00067191 File Offset: 0x00065391
		private void pictureBoxButtonStop_MouseUp(object sender, MouseEventArgs e)
		{
			if (this._simulator.State == Simulator.STATE.RUN && e.Button == MouseButtons.Left)
			{
				this._simulator.stop();
				this.updateButtonImage();
			}
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x000671BF File Offset: 0x000653BF
		private void pictureBoxButtonRunStep_MouseDown(object sender, MouseEventArgs e)
		{
			if (this._simulator.isRunnable() && e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRunStep.Image = Resources.sim_btn_072;
			}
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x000671EB File Offset: 0x000653EB
		private void pictureBoxButtonRunStep_MouseEnter(object sender, EventArgs e)
		{
			if (this._simulator.isRunnable())
			{
				this.pictureBoxButtonRunStep.Image = Resources.sim_btn_071;
			}
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x0006720A File Offset: 0x0006540A
		private void pictureBoxButtonRunStep_MouseLeave(object sender, EventArgs e)
		{
			if (this._simulator.isRunnable())
			{
				this.pictureBoxButtonRunStep.Image = Resources.sim_btn_070;
			}
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x0006722C File Offset: 0x0006542C
		private void pictureBoxButtonRunStep_MouseUp(object sender, MouseEventArgs e)
		{
			if (this._simulator.isRunnable() && e.Button == MouseButtons.Left)
			{
				ProgramModule.ERROR error = this.getPrograms().getError(false);
				if (error == ProgramModule.ERROR.NONE)
				{
					this.run(true);
					return;
				}
				WarningDialog warningDialog = new WarningDialog();
				if (FlowchartWindow.Instance.IsBlockMode)
				{
					warningDialog.setText(ProgramModule.ERROR_ITEMS_BLOCK[(int)error]);
				}
				else
				{
					warningDialog.setText(ProgramModule.ERROR_ITEMS[(int)error]);
				}
				warningDialog.ShowDialog();
			}
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x000672A4 File Offset: 0x000654A4
		private void vScrollBarTemperature_Scroll(object sender, ScrollEventArgs e)
		{
			int num = 50 - this.vScrollBarTemperature.Value;
			this.textBoxTemperature.Text = num.ToString();
			this._simulator.Temperature = num;
			this._thermometer.Invalidate();
			this._clock.Invalidate();
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x000672F4 File Offset: 0x000654F4
		private void vScrollBarTemperature_ValueChanged(object sender, EventArgs e)
		{
			int num = 50 - this.vScrollBarTemperature.Value;
			this._simulator.Temperature = num;
			this._thermometer.Invalidate();
			this._clock.Invalidate();
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00067334 File Offset: 0x00065534
		private void textBoxTemperature_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsControl(e.KeyChar))
			{
				e.Handled = false;
				return;
			}
			if (char.IsDigit(e.KeyChar))
			{
				e.Handled = false;
				return;
			}
			if (e.KeyChar == '-')
			{
				e.Handled = false;
				return;
			}
			e.Handled = true;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x00067384 File Offset: 0x00065584
		private void textBoxTemperature_KeyUp(object sender, KeyEventArgs e)
		{
			int num;
			if (int.TryParse(this.textBoxTemperature.Text, out num))
			{
				if (num > this.vScrollBarTemperature.Maximum - 10 || num < this.vScrollBarTemperature.Minimum - 10)
				{
					this.textBoxTemperature.Text = "";
					return;
				}
				this.vScrollBarTemperature.Value = 50 - num;
				return;
			}
			else
			{
				if (this.textBoxTemperature.Text == "-" || this.textBoxTemperature.Text == "")
				{
					e.Handled = false;
					return;
				}
				this.textBoxTemperature.Text = "";
				return;
			}
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x00067430 File Offset: 0x00065630
		private void hScrollBarLight_Scroll(object sender, ScrollEventArgs e)
		{
			this.textBoxLight.Text = this.hScrollBarLight.Value.ToString();
			this._simulator.LightValue = this.hScrollBarLight.Value;
			this._clock.Invalidate();
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x0006747C File Offset: 0x0006567C
		private void hScrollBarLight_ValueChanged(object sender, EventArgs e)
		{
			this._simulator.LightValue = this.hScrollBarLight.Value;
			this._clock.Invalidate();
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x0006749F File Offset: 0x0006569F
		private void textBoxLight_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
			{
				e.Handled = false;
				return;
			}
			e.Handled = true;
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x000674CC File Offset: 0x000656CC
		private void textBoxLight_KeyUp(object sender, KeyEventArgs e)
		{
			int num;
			if (int.TryParse(this.textBoxLight.Text, out num))
			{
				if (num > this.hScrollBarLight.Maximum || num < this.hScrollBarLight.Minimum)
				{
					this.textBoxLight.Text = "";
					return;
				}
				this.hScrollBarLight.Value = num;
				return;
			}
			else
			{
				if (this.textBoxLight.Text == "")
				{
					e.Handled = false;
					return;
				}
				this.textBoxTemperature.Text = "";
				return;
			}
		}

		// Token: 0x04000685 RID: 1669
		private IconWindow _iconWindow;

		// Token: 0x04000686 RID: 1670
		private FlowchartWindow _flowchartWindow;

		// Token: 0x04000687 RID: 1671
		private Simulator _simulator;

		// Token: 0x04000688 RID: 1672
		private SimulatorClock _clock;

		// Token: 0x04000689 RID: 1673
		private SimulatorThermometer _thermometer;

		// Token: 0x020000D9 RID: 217
		// (Invoke) Token: 0x0600110C RID: 4364
		public delegate void onUpdateSimulator_Delegate();
	}
}
