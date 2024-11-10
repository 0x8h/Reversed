using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000054 RID: 84
	public class SimulatorThermometer : PictureBox
	{
		// Token: 0x060008E9 RID: 2281 RVA: 0x00066984 File Offset: 0x00064B84
		public SimulatorThermometer(Simulator simulator)
		{
			this.InitializeComponent();
			this._simulator = simulator;
			base.Location = new Point(20, 113);
			base.Image = Resources.sim_icon_000;
			base.Size = base.Image.Size;
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x000669C4 File Offset: 0x00064BC4
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			Pen pen = new Pen(Color.Crimson, 7f);
			pe.Graphics.DrawLine(pen, 16, 83, 16, 72 - this._simulator.Temperature);
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00066A08 File Offset: 0x00064C08
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x00066A27 File Offset: 0x00064C27
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x04000683 RID: 1667
		private Simulator _simulator;

		// Token: 0x04000684 RID: 1668
		private IContainer components;
	}
}
