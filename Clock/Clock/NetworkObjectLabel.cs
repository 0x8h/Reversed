using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
	// Token: 0x0200003E RID: 62
	public class NetworkObjectLabel : Label, NetworkObjectInterface
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000665 RID: 1637 RVA: 0x0004DB26 File Offset: 0x0004BD26
		// (set) Token: 0x06000666 RID: 1638 RVA: 0x0004DB2E File Offset: 0x0004BD2E
		public bool Selected { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000667 RID: 1639 RVA: 0x0004DB37 File Offset: 0x0004BD37
		// (set) Token: 0x06000668 RID: 1640 RVA: 0x0004DB3F File Offset: 0x0004BD3F
		public GUIDE Guide { get; set; }

		// Token: 0x06000669 RID: 1641 RVA: 0x0004DB48 File Offset: 0x0004BD48
		public NetworkObjectLabel()
		{
			this.InitializeComponent();
			base.DragOver += this.NetworkObject_DragOver;
			base.DragLeave += this.NetworkObject_DragLeave;
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0004DB7C File Offset: 0x0004BD7C
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
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

		// Token: 0x0600066B RID: 1643 RVA: 0x0004DC80 File Offset: 0x0004BE80
		private void NetworkObject_DragOver(object sender, DragEventArgs e)
		{
			if (NetworkWindow.Instance.isTutorial())
			{
				this.Guide = GUIDE.DOWN;
			}
			else
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
			}
			base.Invalidate();
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0004DD22 File Offset: 0x0004BF22
		private void NetworkObject_DragLeave(object sender, EventArgs e)
		{
			this.Guide = GUIDE.NONE;
			base.Invalidate();
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0004DD31 File Offset: 0x0004BF31
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0004DD50 File Offset: 0x0004BF50
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040004E8 RID: 1256
		private IContainer components;
	}
}
