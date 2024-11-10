using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clock
{
	// Token: 0x0200003F RID: 63
	public class NetworkObjectList : Panel, NetworkObjectInterface
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x0004DD5D File Offset: 0x0004BF5D
		// (set) Token: 0x06000670 RID: 1648 RVA: 0x0004DD65 File Offset: 0x0004BF65
		public bool Selected
		{
			get
			{
				return this._selected;
			}
			set
			{
				this._selected = value;
				this._pictureBox.Invalidate();
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x0004DD79 File Offset: 0x0004BF79
		// (set) Token: 0x06000672 RID: 1650 RVA: 0x0004DD81 File Offset: 0x0004BF81
		public GUIDE Guide { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x0004DD8A File Offset: 0x0004BF8A
		// (set) Token: 0x06000674 RID: 1652 RVA: 0x0004DD92 File Offset: 0x0004BF92
		public NetworkObjectList.KIND Kind { get; set; }

		// Token: 0x06000675 RID: 1653 RVA: 0x0004DD9C File Offset: 0x0004BF9C
		public NetworkObjectList(NetworkObjectList.KIND kind, Color backColor)
		{
			this.InitializeComponent();
			this.Kind = kind;
			this.AutoScroll = true;
			this._pictureBox.BackColor = backColor;
			this._pictureBox.Dock = DockStyle.None;
			base.Controls.Add(this._pictureBox);
			base.Resize += this.NetworkObjectList_Resize;
			base.DragOver += this.NetworkObject_DragOver;
			base.DragLeave += this.NetworkObject_DragLeave;
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0004DE30 File Offset: 0x0004C030
		public void addLog(NetworkSimulator.NetworkVariable log)
		{
			this._pictureBox.addLog(log);
			this.resize();
			base.AutoScrollPosition = new Point(0, this._pictureBox.Size.Height);
			this._pictureBox.Invalidate();
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x0004DE79 File Offset: 0x0004C079
		public void clearText()
		{
			this._pictureBox.clearText();
			this.resize();
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x0004DE8C File Offset: 0x0004C08C
		private void NetworkObjectList_Resize(object sender, EventArgs e)
		{
			this.resize();
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0004DE94 File Offset: 0x0004C094
		private void resize()
		{
			if (this._pictureBox.getNeedHeight() > base.Parent.Height)
			{
				this._pictureBox.Size = new Size(base.Parent.Width - SystemInformation.VerticalScrollBarWidth, this._pictureBox.getNeedHeight());
				return;
			}
			this._pictureBox.Size = new Size(base.Parent.Width, base.Parent.Height);
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0004DF0C File Offset: 0x0004C10C
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
			this._pictureBox.Invalidate();
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x0004DF9E File Offset: 0x0004C19E
		private void NetworkObject_DragLeave(object sender, EventArgs e)
		{
			this.Guide = GUIDE.NONE;
			this._pictureBox.Invalidate();
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0004DFB2 File Offset: 0x0004C1B2
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0004DFD1 File Offset: 0x0004C1D1
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040004E9 RID: 1257
		private bool _selected;

		// Token: 0x040004EB RID: 1259
		private NetworkObjectList.ObjectListPictureBox _pictureBox = new NetworkObjectList.ObjectListPictureBox();

		// Token: 0x040004ED RID: 1261
		private IContainer components;

		// Token: 0x020000AC RID: 172
		public enum KIND
		{
			// Token: 0x040008B2 RID: 2226
			NORMAL,
			// Token: 0x040008B3 RID: 2227
			NOTE,
			// Token: 0x040008B4 RID: 2228
			BALLOON,
			// Token: 0x040008B5 RID: 2229
			MAX
		}

		// Token: 0x020000AD RID: 173
		private class ObjectListPictureBox : PictureBox
		{
			// Token: 0x06001080 RID: 4224 RVA: 0x000913D0 File Offset: 0x0008F5D0
			public ObjectListPictureBox()
			{
				base.Enabled = false;
				base.LocationChanged += this.NetworkObjectList_LocationChanged;
			}

			// Token: 0x06001081 RID: 4225 RVA: 0x000913FC File Offset: 0x0008F5FC
			public int getNeedHeight()
			{
				int num = 0;
				switch (((NetworkObjectList)base.Parent).Kind)
				{
				case NetworkObjectList.KIND.NORMAL:
				{
					using (List<NetworkSimulator.NetworkVariable>.Enumerator enumerator = this._logs.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							NetworkSimulator.NetworkVariable networkVariable = enumerator.Current;
							int num2 = (int)Math.Ceiling((double)TextRenderer.MeasureText(networkVariable.Value, NetworkObjectList.ObjectListPictureBox._font).Width / (double)base.Parent.Width);
							num += NetworkObjectList.ObjectListPictureBox._font.Height * num2;
						}
						return num;
					}
					break;
				}
				case NetworkObjectList.KIND.NOTE:
					break;
				case NetworkObjectList.KIND.BALLOON:
					goto IL_115;
				default:
					return num;
				}
				using (List<NetworkSimulator.NetworkVariable>.Enumerator enumerator = this._logs.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ref NetworkSimulator.NetworkVariable ptr = enumerator.Current;
						num += NetworkObjectList.ObjectListPictureBox._fontSmall.Height;
						int num3 = (int)Math.Ceiling((double)TextRenderer.MeasureText(ptr.Value, NetworkObjectList.ObjectListPictureBox._font).Width / (double)base.Parent.Width);
						num += NetworkObjectList.ObjectListPictureBox._font.Height * num3;
					}
					return num;
				}
				IL_115:
				int num4 = base.Parent.Width - 60;
				foreach (NetworkSimulator.NetworkVariable ptr2 in this._logs)
				{
					num += NetworkObjectList.ObjectListPictureBox._fontSmall.Height;
					int num5 = (int)Math.Ceiling((double)TextRenderer.MeasureText(ptr2.Value, NetworkObjectList.ObjectListPictureBox._font).Width / (double)num4);
					num += NetworkObjectList.ObjectListPictureBox._font.Height * num5;
				}
				return num;
			}

			// Token: 0x06001082 RID: 4226 RVA: 0x000915C8 File Offset: 0x0008F7C8
			public void addLog(NetworkSimulator.NetworkVariable log)
			{
				this._logs.Add(log);
			}

			// Token: 0x06001083 RID: 4227 RVA: 0x000915D6 File Offset: 0x0008F7D6
			public void clearText()
			{
				this._logs.Clear();
				base.Invalidate();
			}

			// Token: 0x06001084 RID: 4228 RVA: 0x000915EC File Offset: 0x0008F7EC
			protected override void OnPaint(PaintEventArgs pe)
			{
				base.OnPaint(pe);
				int num = 0;
				switch (((NetworkObjectList)base.Parent).Kind)
				{
				case NetworkObjectList.KIND.NORMAL:
				{
					using (List<NetworkSimulator.NetworkVariable>.Enumerator enumerator = this._logs.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							NetworkSimulator.NetworkVariable networkVariable = enumerator.Current;
							int num2 = (int)Math.Ceiling((double)TextRenderer.MeasureText(pe.Graphics, networkVariable.Value, NetworkObjectList.ObjectListPictureBox._font).Width / (double)base.Width);
							pe.Graphics.DrawString(networkVariable.Value, NetworkObjectList.ObjectListPictureBox._font, Brushes.Black, new Rectangle(0, num, base.Width, NetworkObjectList.ObjectListPictureBox._font.Height * num2));
							num += NetworkObjectList.ObjectListPictureBox._font.Height * num2;
						}
						goto IL_38F;
					}
					break;
				}
				case NetworkObjectList.KIND.NOTE:
					break;
				case NetworkObjectList.KIND.BALLOON:
					goto IL_22D;
				default:
					goto IL_38F;
				}
				using (List<NetworkSimulator.NetworkVariable>.Enumerator enumerator = this._logs.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						NetworkSimulator.NetworkVariable networkVariable2 = enumerator.Current;
						pe.Graphics.DrawString(networkVariable2.Name, NetworkObjectList.ObjectListPictureBox._fontSmall, Brushes.Black, 0f, (float)num);
						pe.Graphics.DrawString("IP:" + networkVariable2.IPAddress, NetworkObjectList.ObjectListPictureBox._fontSmall, Brushes.Black, (float)(base.Width / 3), (float)num);
						num += NetworkObjectList.ObjectListPictureBox._fontSmall.Height;
						int num3 = (int)Math.Ceiling((double)TextRenderer.MeasureText(pe.Graphics, networkVariable2.Value, NetworkObjectList.ObjectListPictureBox._font).Width / (double)base.Width);
						pe.Graphics.DrawString(networkVariable2.Value, NetworkObjectList.ObjectListPictureBox._font, Brushes.Black, new Rectangle(0, num, base.Width, NetworkObjectList.ObjectListPictureBox._font.Height * num3));
						num += NetworkObjectList.ObjectListPictureBox._font.Height * num3;
						pe.Graphics.DrawLine(new Pen(Color.FromArgb(170, 206, 147)), 0, num, base.Width, num);
					}
					goto IL_38F;
				}
				IL_22D:
				string text = UDP.getMyIPAddress().ToString();
				int num4 = base.Width - 60;
				foreach (NetworkSimulator.NetworkVariable networkVariable3 in this._logs)
				{
					bool flag = !text.Equals(networkVariable3.IPAddress);
					int num5 = (flag ? 20 : 40);
					pe.Graphics.DrawString(networkVariable3.Name, NetworkObjectList.ObjectListPictureBox._fontSmall, Brushes.Black, (float)num5, (float)num);
					pe.Graphics.DrawString("IP:" + networkVariable3.IPAddress, NetworkObjectList.ObjectListPictureBox._fontSmall, Brushes.Black, (float)(num5 + base.Width / 3), (float)num);
					num += NetworkObjectList.ObjectListPictureBox._fontSmall.Height;
					int num6 = (int)Math.Ceiling((double)TextRenderer.MeasureText(pe.Graphics, networkVariable3.Value, NetworkObjectList.ObjectListPictureBox._font).Width / (double)num4);
					this.paintBalloon(pe.Graphics, flag, num5, num, num4, NetworkObjectList.ObjectListPictureBox._font.Height * num6);
					pe.Graphics.DrawString(networkVariable3.Value, NetworkObjectList.ObjectListPictureBox._font, Brushes.Black, new Rectangle(num5, num, num4, NetworkObjectList.ObjectListPictureBox._font.Height * num6));
					num += NetworkObjectList.ObjectListPictureBox._font.Height * num6;
				}
				IL_38F:
				NetworkObjectList networkObjectList = (NetworkObjectList)base.Parent;
				Brush brush = new SolidBrush(Color.FromArgb(128, Color.White));
				switch (networkObjectList.Guide)
				{
				case GUIDE.UP:
					pe.Graphics.FillRectangle(brush, 0, -base.Location.Y, networkObjectList.Width, networkObjectList.Height / 2);
					break;
				case GUIDE.DOWN:
					pe.Graphics.FillRectangle(brush, 0, -base.Location.Y + networkObjectList.Height / 2, networkObjectList.Width, networkObjectList.Height / 2);
					break;
				case GUIDE.LEFT:
					pe.Graphics.FillRectangle(brush, 0, -base.Location.Y, networkObjectList.Width / 2, networkObjectList.Height);
					break;
				case GUIDE.RIGHT:
					pe.Graphics.FillRectangle(brush, networkObjectList.Width / 2, -base.Location.Y, networkObjectList.Width / 2, networkObjectList.Height);
					break;
				}
				if (networkObjectList.Selected)
				{
					Pen pen = new Pen(Brushes.Red, 2f);
					pe.Graphics.DrawRectangle(pen, 1, -base.Location.Y + 1, networkObjectList.Width - 2, networkObjectList.Height - 2);
				}
			}

			// Token: 0x06001085 RID: 4229 RVA: 0x00091B2C File Offset: 0x0008FD2C
			private void paintBalloon(Graphics graphics, bool isLeft, int x, int y, int width, int height)
			{
				int num = 5;
				int num2 = num * 2;
				graphics.FillRectangle(Brushes.White, x + num, y + num, width - num * 2, height - num * 2);
				graphics.FillRectangle(Brushes.White, x + num, y, width - num - 2, num);
				graphics.FillRectangle(Brushes.White, x + num, y + height - num, width - num - 2, num);
				graphics.FillRectangle(Brushes.White, x, y + num, num, height - num * 2);
				graphics.FillRectangle(Brushes.White, x + width - num, y + num, num, height - num * 2);
				graphics.FillPie(Brushes.White, x, y, num2, num2, 180, 90);
				graphics.FillPie(Brushes.White, x + width - num2, y, num2, num2, 270, 90);
				graphics.FillPie(Brushes.White, x, y + height - num2, num2, num2, 90, 90);
				graphics.FillPie(Brushes.White, x + width - num2, y + height - num2, num2, num2, 0, 90);
				graphics.DrawLine(Pens.Black, x + num, y, x + width - num, y);
				graphics.DrawLine(Pens.Black, x + num, y + height, x + width - num, y + height);
				int num3 = height / 2;
				int num4 = height / 3;
				using (GraphicsPath graphicsPath = new GraphicsPath())
				{
					if (isLeft)
					{
						graphicsPath.AddLine(x + 1, y + num4, x - num, y + num3);
						graphicsPath.AddLine(x + 1 - num, y + num3, x, y + num4 * 2);
						graphics.FillPath(Brushes.White, graphicsPath);
						graphics.DrawLine(Pens.Black, x, y + num, x, y + num4);
						graphics.DrawLine(Pens.Black, x - num, y + num3, x, y + num4);
						graphics.DrawLine(Pens.Black, x - num, y + num3, x, y + num4 * 2);
						graphics.DrawLine(Pens.Black, x, y + num4 * 2, x, y + height - num);
						graphics.DrawLine(Pens.Black, x + width, y + num, x + width, y + height - num);
					}
					else
					{
						graphicsPath.AddLine(x + width, y + num4, x + width + num, y + num3);
						graphicsPath.AddLine(x + width + num, y + num3, x + width, y + num4 * 2);
						graphics.FillPath(Brushes.White, graphicsPath);
						graphics.DrawLine(Pens.Black, x, y + num, x, y + height - num);
						graphics.DrawLine(Pens.Black, x + width, y + num, x + width, y + num4);
						graphics.DrawLine(Pens.Black, x + width + num, y + num3, x + width, y + num4);
						graphics.DrawLine(Pens.Black, x + width + num, y + num3, x + width, y + num4 * 2);
						graphics.DrawLine(Pens.Black, x + width, y + num4 * 2, x + width, y + height - num);
					}
				}
				graphics.DrawArc(Pens.Black, x, y, num2, num2, 180, 90);
				graphics.DrawArc(Pens.Black, x + width - num2, y, num2, num2, 270, 90);
				graphics.DrawArc(Pens.Black, x, y + height - num2, num2, num2, 90, 90);
				graphics.DrawArc(Pens.Black, x + width - num2, y + height - num2, num2, num2, 0, 90);
			}

			// Token: 0x06001086 RID: 4230 RVA: 0x00091E98 File Offset: 0x00090098
			private void NetworkObjectList_LocationChanged(object sender, EventArgs e)
			{
				base.Invalidate();
			}

			// Token: 0x040008B6 RID: 2230
			private List<NetworkSimulator.NetworkVariable> _logs = new List<NetworkSimulator.NetworkVariable>();

			// Token: 0x040008B7 RID: 2231
			private static Font _font = new Font("メイリオ", 12f, FontStyle.Regular, GraphicsUnit.Point, 128);

			// Token: 0x040008B8 RID: 2232
			private static Font _fontSmall = new Font("メイリオ", 10f, FontStyle.Regular, GraphicsUnit.Point, 128);
		}
	}
}
