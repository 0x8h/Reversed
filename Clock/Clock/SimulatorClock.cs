using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000053 RID: 83
	public class SimulatorClock : PictureBox
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060008DF RID: 2271 RVA: 0x0006638B File Offset: 0x0006458B
		// (set) Token: 0x060008E0 RID: 2272 RVA: 0x00066393 File Offset: 0x00064593
		public ProgramModule.BlockDisplay.DISPLAY_MODE DisplayMode { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060008E1 RID: 2273 RVA: 0x0006639C File Offset: 0x0006459C
		// (set) Token: 0x060008E2 RID: 2274 RVA: 0x000663A4 File Offset: 0x000645A4
		public int VariableIndex { get; set; }

		// Token: 0x060008E3 RID: 2275 RVA: 0x000663AD File Offset: 0x000645AD
		public SimulatorClock(Simulator simulator)
		{
			this.InitializeComponent();
			this._simulator = simulator;
			base.Location = new Point(126, 68);
			base.Image = Resources.sim_icon_010;
			base.Size = base.Image.Size;
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x000663F0 File Offset: 0x000645F0
		private void paintDisplay(Graphics g, int[] numbers, SimulatorClock.DISPLAY_TYPE type = SimulatorClock.DISPLAY_TYPE.NONE)
		{
			int[] array = new int[] { 53, 75, 97, 119 };
			for (int i = 0; i < 4; i++)
			{
				if (numbers[i] != -1)
				{
					this.paintNumber(g, array[i], 58, numbers[i]);
				}
			}
			Pen pen = new Pen(Brushes.Red, 2f);
			switch (type)
			{
			case SimulatorClock.DISPLAY_TYPE.NONE:
				break;
			case SimulatorClock.DISPLAY_TYPE.COLON:
				g.DrawEllipse(pen, 90, 72, 3, 3);
				g.DrawEllipse(pen, 90, 88, 3, 3);
				return;
			case SimulatorClock.DISPLAY_TYPE.DOT:
				g.DrawEllipse(pen, 112, 92, 3, 3);
				return;
			case SimulatorClock.DISPLAY_TYPE.DOT2:
				g.DrawEllipse(pen, 90, 92, 3, 3);
				break;
			default:
				return;
			}
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00066490 File Offset: 0x00064690
		private void paintNumber(Graphics g, int x, int y, int number)
		{
			bool[,] array = new bool[,]
			{
				{ true, true, true, false, true, true, true },
				{ false, false, true, false, false, false, true },
				{ false, true, true, true, true, true, false },
				{ false, true, true, true, false, true, true },
				{ true, false, true, true, false, false, true },
				{ true, true, false, true, false, true, true },
				{ true, true, false, true, true, true, true },
				{ false, true, true, false, false, false, true },
				{ true, true, true, true, true, true, true },
				{ true, true, true, true, false, true, true },
				{ false, false, false, true, false, false, false },
				{ false, false, false, true, true, true, false }
			};
			Pen pen = new Pen(Color.Red, 3f);
			pen.StartCap = LineCap.Triangle;
			pen.EndCap = LineCap.Triangle;
			int[,] array2 = new int[7, 4];
			array2[0, 0] = x;
			array2[0, 1] = y + 10;
			array2[0, 2] = x;
			array2[0, 3] = y + 11 + 10;
			array2[1, 0] = x + 2;
			array2[1, 1] = y - 2 + 10;
			array2[1, 2] = x + 7 + 2;
			array2[1, 3] = y - 2 + 10;
			array2[2, 0] = x + 12;
			array2[2, 1] = y + 10;
			array2[2, 2] = x + 12;
			array2[2, 3] = y + 11 + 10;
			array2[3, 0] = x + 2;
			array2[3, 1] = y + 18 + 5;
			array2[3, 2] = x + 7 + 2;
			array2[3, 3] = y + 18 + 5;
			array2[4, 0] = x;
			array2[4, 1] = y + 25;
			array2[4, 2] = x;
			array2[4, 3] = y + 11 + 25;
			array2[5, 0] = x + 2;
			array2[5, 1] = y + 2 + 36;
			array2[5, 2] = x + 7 + 2;
			array2[5, 3] = y + 2 + 36;
			array2[6, 0] = x + 12;
			array2[6, 1] = y + 25;
			array2[6, 2] = x + 12;
			array2[6, 3] = y + 11 + 25;
			int[,] array3 = array2;
			for (int i = 0; i < 7; i++)
			{
				if (array[number, i])
				{
					g.DrawLine(pen, array3[i, 0], array3[i, 1], array3[i, 2], array3[i, 3]);
				}
			}
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00066674 File Offset: 0x00064874
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			switch (this.DisplayMode)
			{
			case ProgramModule.BlockDisplay.DISPLAY_MODE.TIME:
				this.paintDisplay(pe.Graphics, new int[]
				{
					(this._simulator.Hour / 10 != 0) ? (this._simulator.Hour / 10) : (-1),
					this._simulator.Hour % 10,
					this._simulator.Minute / 10,
					this._simulator.Minute % 10
				}, SimulatorClock.DISPLAY_TYPE.COLON);
				return;
			case ProgramModule.BlockDisplay.DISPLAY_MODE.TEMPERATURE:
			{
				if (this._simulator.Temperature <= -10)
				{
					this.paintDisplay(pe.Graphics, new int[] { 10, 9, 9, 11 }, SimulatorClock.DISPLAY_TYPE.DOT2);
					return;
				}
				int num = Math.Abs(this._simulator.Temperature);
				this.paintDisplay(pe.Graphics, new int[]
				{
					(this._simulator.Temperature < 0) ? 10 : (num / 10),
					num % 10,
					0,
					11
				}, SimulatorClock.DISPLAY_TYPE.DOT2);
				return;
			}
			case ProgramModule.BlockDisplay.DISPLAY_MODE.VARIABLE:
				this.paintDisplay(pe.Graphics, new int[]
				{
					(this._simulator.Variables[this.VariableIndex] < 0) ? 10 : (-1),
					Math.Abs(this._simulator.Variables[this.VariableIndex]) / 100,
					Math.Abs(this._simulator.Variables[this.VariableIndex]) / 10 % 10,
					Math.Abs(this._simulator.Variables[this.VariableIndex]) % 10
				}, SimulatorClock.DISPLAY_TYPE.NONE);
				return;
			case ProgramModule.BlockDisplay.DISPLAY_MODE.COUNTER:
				this.paintDisplay(pe.Graphics, new int[]
				{
					-1,
					this._simulator.Counter / 100,
					this._simulator.Counter / 10 % 10,
					this._simulator.Counter % 10
				}, SimulatorClock.DISPLAY_TYPE.NONE);
				return;
			case ProgramModule.BlockDisplay.DISPLAY_MODE.LIGHT:
				this.paintDisplay(pe.Graphics, new int[]
				{
					-1,
					this._simulator.LightValue / 100,
					this._simulator.LightValue / 10 % 10,
					this._simulator.LightValue % 10
				}, SimulatorClock.DISPLAY_TYPE.NONE);
				return;
			case ProgramModule.BlockDisplay.DISPLAY_MODE.WAIT:
				this.paintDisplay(pe.Graphics, new int[]
				{
					-1,
					(int)Math.Floor((double)(this._simulator.WaitTime / 10f)),
					(int)Math.Floor((double)this._simulator.WaitTime) % 10,
					(int)Math.Floor((double)(this._simulator.WaitTime * 10f)) % 10
				}, (this._simulator.WaitTime >= 0f) ? SimulatorClock.DISPLAY_TYPE.DOT : SimulatorClock.DISPLAY_TYPE.NONE);
				return;
			case ProgramModule.BlockDisplay.DISPLAY_MODE.MAX:
				this.paintDisplay(pe.Graphics, new int[] { -1, -1, -1, -1 }, SimulatorClock.DISPLAY_TYPE.NONE);
				return;
			default:
				return;
			}
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00066958 File Offset: 0x00064B58
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x00066977 File Offset: 0x00064B77
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x04000680 RID: 1664
		private Simulator _simulator;

		// Token: 0x04000681 RID: 1665
		private const int NUMBER_COUNT = 4;

		// Token: 0x04000682 RID: 1666
		private IContainer components;

		// Token: 0x020000D7 RID: 215
		private enum DISPLAY_TYPE
		{
			// Token: 0x04000973 RID: 2419
			NONE,
			// Token: 0x04000974 RID: 2420
			COLON,
			// Token: 0x04000975 RID: 2421
			DOT,
			// Token: 0x04000976 RID: 2422
			DOT2
		}

		// Token: 0x020000D8 RID: 216
		private enum NUMBER_TYPE
		{
			// Token: 0x04000978 RID: 2424
			NONE = -1,
			// Token: 0x04000979 RID: 2425
			MINUS = 10,
			// Token: 0x0400097A RID: 2426
			C,
			// Token: 0x0400097B RID: 2427
			MAX
		}
	}
}
