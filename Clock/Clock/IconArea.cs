using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000025 RID: 37
	public class IconArea : PictureBox
	{
		// Token: 0x0600037F RID: 895 RVA: 0x0002F028 File Offset: 0x0002D228
		public IconArea(IconWindow window)
		{
			this.InitializeComponent();
			this._window = window;
			base.DragEnter += this.IconArea_DragEnter;
			base.MouseDown += this.IconArea_MouseDown;
			base.MouseMove += this.IconArea_MouseMove;
			base.MouseUp += this.IconArea_MouseUp;
			base.MouseEnter += this.IconArea_MouseEnter;
			base.MouseWheel += this.IconArea_MouseWheel;
			this.AllowDrop = true;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0002F0C8 File Offset: 0x0002D2C8
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			for (int i = 0; i < this._window.AreaBlocks.Count - 1; i++)
			{
				IconAreaBlock iconAreaBlock = this._window.AreaBlocks[i];
				pe.Graphics.DrawImage(this._arrow, iconAreaBlock.Location.X + iconAreaBlock.Size.Width + 5, iconAreaBlock.Location.Y + (iconAreaBlock.Size.Height - this._arrow.Size.Height) / 2, this._arrow.Width, this._arrow.Height);
			}
			foreach (IconAreaBlock iconAreaBlock2 in this._window.AreaBlocks)
			{
				Rectangle rectangle = default(Rectangle);
				if (iconAreaBlock2.Type != IconAreaBlock.TYPE.BLANK && iconAreaBlock2.Block.BreakPoint)
				{
					rectangle.X = iconAreaBlock2.Location.X - 10;
					rectangle.Y = iconAreaBlock2.Location.Y + iconAreaBlock2.Size.Height / 2 - 10;
					rectangle.Width = 20;
					rectangle.Height = 20;
					pe.Graphics.FillEllipse(Brushes.Red, rectangle);
				}
			}
			if (this._drag)
			{
				Rectangle selectRect = this._selectRect;
				if (selectRect.Width < 0)
				{
					selectRect.X += selectRect.Width;
					selectRect.Width *= -1;
				}
				if (selectRect.Height < 0)
				{
					selectRect.Y += selectRect.Height;
					selectRect.Height *= -1;
				}
				pe.Graphics.DrawRectangle(Pens.Blue, selectRect);
			}
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00021DE8 File Offset: 0x0001FFE8
		private void IconArea_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0002F2DC File Offset: 0x0002D4DC
		private void IconArea_MouseDown(object sender, MouseEventArgs e)
		{
			if (this._window.isTutorial())
			{
				return;
			}
			this._window.clearSelect();
			this._drag = true;
			this._selectRect.Location = e.Location;
			this._selectRect.Size = Size.Empty;
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0002F32C File Offset: 0x0002D52C
		private void IconArea_MouseMove(object sender, MouseEventArgs e)
		{
			this._selectRect.Size = new Size(e.Location.X - this._selectRect.Location.X, e.Location.Y - this._selectRect.Location.Y);
			base.Invalidate();
			this.scrollScreen();
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0002F39C File Offset: 0x0002D59C
		private void IconArea_MouseUp(object sender, MouseEventArgs e)
		{
			this._drag = false;
			Rectangle selectRect = this._selectRect;
			if (selectRect.Width < 0)
			{
				selectRect.X += selectRect.Width;
				selectRect.Width *= -1;
			}
			if (selectRect.Height < 0)
			{
				selectRect.Y += selectRect.Height;
				selectRect.Height *= -1;
			}
			this._window.setSelect(selectRect);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0002F420 File Offset: 0x0002D620
		private void IconArea_MouseWheel(object sender, MouseEventArgs e)
		{
			VScrollProperties verticalScroll = ((SplitterPanel)base.Parent).VerticalScroll;
			int num = Math.Min(verticalScroll.Maximum, verticalScroll.Value - e.Delta);
			num = Math.Max(verticalScroll.Minimum, num);
			verticalScroll.Value = num;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0002F46B File Offset: 0x0002D66B
		private void IconArea_MouseEnter(object sender, EventArgs e)
		{
			if (Form.ActiveForm == this._window)
			{
				base.Parent.Focus();
			}
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0002F488 File Offset: 0x0002D688
		private void scrollScreen()
		{
			if (base.PointToClient(Cursor.Position).Y + ((SplitterPanel)base.Parent).AutoScrollPosition.Y > ((SplitterPanel)base.Parent).Height)
			{
				((SplitterPanel)base.Parent).AutoScrollPosition = new Point(-((SplitterPanel)base.Parent).AutoScrollPosition.X, -((SplitterPanel)base.Parent).AutoScrollPosition.Y + 3);
			}
			else if (base.PointToClient(Cursor.Position).Y + ((SplitterPanel)base.Parent).AutoScrollPosition.Y < 0)
			{
				((SplitterPanel)base.Parent).AutoScrollPosition = new Point(-((SplitterPanel)base.Parent).AutoScrollPosition.X, -((SplitterPanel)base.Parent).AutoScrollPosition.Y - 3);
			}
			base.Update();
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0002F59C File Offset: 0x0002D79C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0002F5BB File Offset: 0x0002D7BB
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040002F0 RID: 752
		private IconWindow _window;

		// Token: 0x040002F1 RID: 753
		private Image _arrow = Resources.icon_arrow_000;

		// Token: 0x040002F2 RID: 754
		private bool _drag;

		// Token: 0x040002F3 RID: 755
		private Rectangle _selectRect;

		// Token: 0x040002F4 RID: 756
		private IContainer components;
	}
}
