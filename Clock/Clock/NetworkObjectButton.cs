using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
	// Token: 0x02000039 RID: 57
	public class NetworkObjectButton : Button, NetworkObjectInterface
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000621 RID: 1569 RVA: 0x0004C8B5 File Offset: 0x0004AAB5
		// (set) Token: 0x06000622 RID: 1570 RVA: 0x0004C8BD File Offset: 0x0004AABD
		public bool Selected { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x0004C8C6 File Offset: 0x0004AAC6
		// (set) Token: 0x06000624 RID: 1572 RVA: 0x0004C8CE File Offset: 0x0004AACE
		public bool IsOn { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000625 RID: 1573 RVA: 0x0004C8D7 File Offset: 0x0004AAD7
		// (set) Token: 0x06000626 RID: 1574 RVA: 0x0004C8DF File Offset: 0x0004AADF
		public GUIDE Guide { get; set; }

		// Token: 0x06000627 RID: 1575 RVA: 0x0004C8E8 File Offset: 0x0004AAE8
		public NetworkObjectButton()
		{
			this.InitializeComponent();
			base.MouseEnter += this.NetworkObjectButton_MouseEnter;
			base.MouseLeave += this.NetworkObjectButton_MouseLeave;
			base.MouseUp += this.NetworkObjectButton_MouseUp;
			base.MouseDown += this.NetworkObjectButton_MouseDown;
			base.DragOver += this.NetworkObject_DragOver;
			base.DragLeave += this.NetworkObject_DragLeave;
			this._timer = new Timer();
			this._timer.Tick += this.OnButtonOff;
			this._timer.Interval = NetworkObjectButton.BUTTON_ON_TIME;
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0004C9AC File Offset: 0x0004ABAC
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			if (this._brushCursor != null && !this._cursor)
			{
				pe.Graphics.FillRectangle(this._brushCursor, 0, 0, base.Width, base.Height);
			}
			Brush brush = new SolidBrush(Color.FromArgb(128, Color.White));
			switch (this.Guide)
			{
			case GUIDE.UP:
				pe.Graphics.FillRectangle(brush, 0, 0, base.Width, base.Height / 2);
				break;
			case GUIDE.DOWN:
				pe.Graphics.FillRectangle(brush, 0, base.Height / 2, base.Width, base.Height / 2);
				break;
			case GUIDE.LEFT:
				pe.Graphics.FillRectangle(brush, 0, 0, base.Width / 2, base.Height);
				break;
			case GUIDE.RIGHT:
				pe.Graphics.FillRectangle(brush, base.Width / 2, 0, base.Width / 2, base.Height);
				break;
			}
			if (this.Selected)
			{
				Pen pen = new Pen(Brushes.Red, 4f);
				pe.Graphics.DrawRectangle(pen, 0, 0, base.Width, base.Height);
			}
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0004CADE File Offset: 0x0004ACDE
		private void OnButtonOff(object sender, EventArgs e)
		{
			this.IsOn = false;
			this._timer.Stop();
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0004CAF2 File Offset: 0x0004ACF2
		private void NetworkObjectButton_MouseEnter(object sender, EventArgs e)
		{
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
			{
				this._brushCursor = new SolidBrush(Color.FromArgb(128, Color.White));
				base.Invalidate();
			}
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0004CB21 File Offset: 0x0004AD21
		private void NetworkObjectButton_MouseLeave(object sender, EventArgs e)
		{
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
			{
				this._brushCursor = null;
				base.Invalidate();
			}
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0004CB3D File Offset: 0x0004AD3D
		private void NetworkObjectButton_MouseUp(object sender, MouseEventArgs e)
		{
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
			{
				this._cursor = false;
				base.Invalidate();
			}
			this.IsOn = false;
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0004CB60 File Offset: 0x0004AD60
		private void NetworkObjectButton_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
			{
				this._cursor = true;
				base.Invalidate();
				this.IsOn = true;
				this._timer.Start();
			}
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0004CB9C File Offset: 0x0004AD9C
		private void NetworkObject_DragOver(object sender, DragEventArgs e)
		{
			Point point = base.PointToClient(new Point(e.X - base.Width / 2, e.Y - base.Height / 2));
			if (Math.Abs(point.X) > Math.Abs(point.Y))
			{
				if (point.X > 0)
				{
					this.Guide = GUIDE.RIGHT;
				}
				else
				{
					this.Guide = GUIDE.LEFT;
				}
			}
			else if (point.Y > 0)
			{
				this.Guide = GUIDE.DOWN;
			}
			else
			{
				this.Guide = GUIDE.UP;
			}
			base.Invalidate();
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0004CC29 File Offset: 0x0004AE29
		private void NetworkObject_DragLeave(object sender, EventArgs e)
		{
			this.Guide = GUIDE.NONE;
			base.Invalidate();
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0004CC38 File Offset: 0x0004AE38
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0004CC57 File Offset: 0x0004AE57
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040004C9 RID: 1225
		public static readonly int BUTTON_ON_TIME = 100;

		// Token: 0x040004CD RID: 1229
		private Brush _brushCursor;

		// Token: 0x040004CE RID: 1230
		private bool _cursor;

		// Token: 0x040004CF RID: 1231
		private Timer _timer = new Timer();

		// Token: 0x040004D0 RID: 1232
		private IContainer components;
	}
}
