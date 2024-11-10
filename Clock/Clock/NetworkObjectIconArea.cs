using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200003A RID: 58
	public class NetworkObjectIconArea : PictureBox
	{
		// Token: 0x06000633 RID: 1587 RVA: 0x0004CC70 File Offset: 0x0004AE70
		public NetworkObjectIconArea(NetworkWindow window, Size size)
		{
			this.InitializeComponent();
			base.Size = size;
			this.Dock = DockStyle.None;
			this._window = window;
			for (int i = 0; i < 5; i++)
			{
				PictureBox pictureBox = this.createPictureBox(10 + i % 3 * 85, 5 + i / 3 * 70);
				this._objectIcons.Add(pictureBox);
			}
			this._objectIcons[0].Image = Resources.nw_obj_000;
			this._objectIcons[0].MouseDown += this.objectIconButton0_MouseDown;
			this._objectIcons[0].MouseEnter += this.objectIconButton0_MouseEnter;
			this._objectIcons[0].MouseLeave += this.objectIconButton0_MouseLeave;
			this._objectIcons[0].GiveFeedback += this.objectIconButton0_GiveFeedback;
			this._objectIcons[0].QueryContinueDrag += this.objectIconButton0_QueryContinueDrag;
			this._objectIcons[1].Image = Resources.nw_obj_100;
			this._objectIcons[1].MouseDown += this.objectIconLabel0_MouseDown;
			this._objectIcons[1].MouseEnter += this.objectIconLabel0_MouseEnter;
			this._objectIcons[1].MouseLeave += this.objectIconLabel0_MouseLeave;
			this._objectIcons[1].GiveFeedback += this.objectIconLabel0_GiveFeedback;
			this._objectIcons[1].QueryContinueDrag += this.objectIconLabel0_QueryContinueDrag;
			this._objectIcons[2].Image = Resources.nw_obj_200;
			this._objectIcons[2].MouseDown += this.objectIconListNormal_MouseDown;
			this._objectIcons[2].MouseEnter += this.objectIconListNormal_MouseEnter;
			this._objectIcons[2].MouseLeave += this.objectIconListNormal_MouseLeave;
			this._objectIcons[2].GiveFeedback += this.objectIconListNormal_GiveFeedback;
			this._objectIcons[2].QueryContinueDrag += this.objectIconListNormal_QueryContinueDrag;
			this._objectIcons[3].Image = Resources.nw_obj_210;
			this._objectIcons[3].MouseDown += this.objectIconListNote_MouseDown;
			this._objectIcons[3].MouseEnter += this.objectIconListNote_MouseEnter;
			this._objectIcons[3].MouseLeave += this.objectIconListNote_MouseLeave;
			this._objectIcons[3].GiveFeedback += this.objectIconListNote_GiveFeedback;
			this._objectIcons[3].QueryContinueDrag += this.objectIconListNote_QueryContinueDrag;
			this._objectIcons[4].Image = Resources.nw_obj_220;
			this._objectIcons[4].MouseDown += this.objectIconListBalloon_MouseDown;
			this._objectIcons[4].MouseEnter += this.objectIconListBalloon_MouseEnter;
			this._objectIcons[4].MouseLeave += this.objectIconListBalloon_MouseLeave;
			this._objectIcons[4].GiveFeedback += this.objectIconListBalloon_GiveFeedback;
			this._objectIcons[4].QueryContinueDrag += this.objectIconListBalloon_QueryContinueDrag;
			for (int j = 0; j < 5; j++)
			{
				this._objectIcons[j].Size = this._objectIcons[j].Image.Size;
			}
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0004D117 File Offset: 0x0004B317
		public void setEnableObjectIcon(NetworkObjectIconArea.OBJECT_ICON icon, bool enable)
		{
			this._objectIcons[(int)icon].Enabled = enable;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0004D12C File Offset: 0x0004B32C
		private PictureBox createPictureBox(int x, int y)
		{
			PictureBox pictureBox = new PictureBox();
			pictureBox.BackColor = Color.Transparent;
			pictureBox.Location = new Point(x, y);
			base.Controls.Add(pictureBox);
			return pictureBox;
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0004D164 File Offset: 0x0004B364
		public void objectIconButton0_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this._window.Programs.Objects.Count < NetworkProgramModules.OBJECT_COUNT_MAX)
			{
				this._objectIcons[0].DoDragDrop("BUTTON", DragDropEffects.Copy);
				this._window.ObjectArea.DragObject = null;
			}
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0004D1C3 File Offset: 0x0004B3C3
		private void objectIconButton0_MouseEnter(object sender, EventArgs e)
		{
			this._objectIcons[0].Image = Resources.nw_obj_001;
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0004D1DB File Offset: 0x0004B3DB
		private void objectIconButton0_MouseLeave(object sender, EventArgs e)
		{
			this._objectIcons[0].Image = Resources.nw_obj_000;
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0004D1F4 File Offset: 0x0004B3F4
		private void objectIconButton0_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorObjectButton;
				this._objectIcons[0].Image = Resources.nw_obj_002;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this._objectIcons[0].Image = Resources.nw_obj_000;
			}
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0004D255 File Offset: 0x0004B455
		private void objectIconButton0_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this._objectIcons[0].Image = Resources.nw_obj_000;
			}
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0004D278 File Offset: 0x0004B478
		public void objectIconLabel0_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this._window.Programs.Objects.Count < NetworkProgramModules.OBJECT_COUNT_MAX)
			{
				this._objectIcons[1].DoDragDrop("LABEL", DragDropEffects.Copy);
				this._window.ObjectArea.DragObject = null;
			}
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x0004D2D7 File Offset: 0x0004B4D7
		private void objectIconLabel0_MouseEnter(object sender, EventArgs e)
		{
			this._objectIcons[1].Image = Resources.nw_obj_101;
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x0004D2EF File Offset: 0x0004B4EF
		private void objectIconLabel0_MouseLeave(object sender, EventArgs e)
		{
			this._objectIcons[1].Image = Resources.nw_obj_100;
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x0004D308 File Offset: 0x0004B508
		private void objectIconLabel0_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorObjectLabel;
				this._objectIcons[1].Image = Resources.nw_obj_102;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this._objectIcons[1].Image = Resources.nw_obj_100;
			}
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x0004D369 File Offset: 0x0004B569
		private void objectIconLabel0_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this._objectIcons[1].Image = Resources.nw_obj_100;
			}
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x0004D38C File Offset: 0x0004B58C
		public void objectIconListNormal_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this._window.Programs.Objects.Count < NetworkProgramModules.OBJECT_COUNT_MAX)
			{
				this._objectIcons[2].DoDragDrop("LIST_NORMAL", DragDropEffects.Copy);
				this._window.ObjectArea.DragObject = null;
			}
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x0004D3EB File Offset: 0x0004B5EB
		private void objectIconListNormal_MouseEnter(object sender, EventArgs e)
		{
			this._objectIcons[2].Image = Resources.nw_obj_201;
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0004D403 File Offset: 0x0004B603
		private void objectIconListNormal_MouseLeave(object sender, EventArgs e)
		{
			this._objectIcons[2].Image = Resources.nw_obj_200;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0004D41C File Offset: 0x0004B61C
		private void objectIconListNormal_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorObjectListNormal;
				this._objectIcons[2].Image = Resources.nw_obj_202;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this._objectIcons[2].Image = Resources.nw_obj_200;
			}
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0004D47D File Offset: 0x0004B67D
		private void objectIconListNormal_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this._objectIcons[2].Image = Resources.nw_obj_200;
			}
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0004D4A0 File Offset: 0x0004B6A0
		public void objectIconListNote_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this._window.Programs.Objects.Count < NetworkProgramModules.OBJECT_COUNT_MAX)
			{
				this._objectIcons[3].DoDragDrop("LIST_NOTE", DragDropEffects.Copy);
				this._window.ObjectArea.DragObject = null;
			}
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0004D4FF File Offset: 0x0004B6FF
		private void objectIconListNote_MouseEnter(object sender, EventArgs e)
		{
			this._objectIcons[3].Image = Resources.nw_obj_211;
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x0004D517 File Offset: 0x0004B717
		private void objectIconListNote_MouseLeave(object sender, EventArgs e)
		{
			this._objectIcons[3].Image = Resources.nw_obj_210;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x0004D530 File Offset: 0x0004B730
		private void objectIconListNote_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorObjectListNote;
				this._objectIcons[3].Image = Resources.nw_obj_212;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this._objectIcons[3].Image = Resources.nw_obj_210;
			}
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0004D591 File Offset: 0x0004B791
		private void objectIconListNote_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this._objectIcons[3].Image = Resources.nw_obj_210;
			}
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0004D5B4 File Offset: 0x0004B7B4
		public void objectIconListBalloon_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this._window.Programs.Objects.Count < NetworkProgramModules.OBJECT_COUNT_MAX)
			{
				this._objectIcons[4].DoDragDrop("LIST_BALLOON", DragDropEffects.Copy);
				this._window.ObjectArea.DragObject = null;
			}
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x0004D613 File Offset: 0x0004B813
		private void objectIconListBalloon_MouseEnter(object sender, EventArgs e)
		{
			this._objectIcons[4].Image = Resources.nw_obj_221;
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0004D62B File Offset: 0x0004B82B
		private void objectIconListBalloon_MouseLeave(object sender, EventArgs e)
		{
			this._objectIcons[4].Image = Resources.nw_obj_220;
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0004D644 File Offset: 0x0004B844
		private void objectIconListBalloon_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorObjectListBalloon;
				this._objectIcons[4].Image = Resources.nw_obj_222;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this._objectIcons[4].Image = Resources.nw_obj_220;
			}
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x0004D6A5 File Offset: 0x0004B8A5
		private void objectIconListBalloon_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this._objectIcons[4].Image = Resources.nw_obj_220;
			}
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0004D6C7 File Offset: 0x0004B8C7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0004D6E6 File Offset: 0x0004B8E6
		private void InitializeComponent()
		{
			((ISupportInitialize)this).BeginInit();
			base.SuspendLayout();
			this.Dock = DockStyle.Fill;
			((ISupportInitialize)this).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040004D1 RID: 1233
		private NetworkWindow _window;

		// Token: 0x040004D2 RID: 1234
		private List<PictureBox> _objectIcons = new List<PictureBox>();

		// Token: 0x040004D3 RID: 1235
		private Cursor cursorObjectButton = CursorCreator.CreateCursor(Resources.nw_obj_000, Resources.nw_obj_000.Width / 2, Resources.nw_obj_000.Height / 2);

		// Token: 0x040004D4 RID: 1236
		private Cursor cursorObjectLabel = CursorCreator.CreateCursor(Resources.nw_obj_100, Resources.nw_obj_100.Width / 2, Resources.nw_obj_100.Height / 2);

		// Token: 0x040004D5 RID: 1237
		private Cursor cursorObjectListNormal = CursorCreator.CreateCursor(Resources.nw_obj_200, Resources.nw_obj_200.Width / 2, Resources.nw_obj_200.Height / 2);

		// Token: 0x040004D6 RID: 1238
		private Cursor cursorObjectListNote = CursorCreator.CreateCursor(Resources.nw_obj_210, Resources.nw_obj_210.Width / 2, Resources.nw_obj_210.Height / 2);

		// Token: 0x040004D7 RID: 1239
		private Cursor cursorObjectListBalloon = CursorCreator.CreateCursor(Resources.nw_obj_220, Resources.nw_obj_220.Width / 2, Resources.nw_obj_220.Height / 2);

		// Token: 0x040004D8 RID: 1240
		private IContainer components;

		// Token: 0x020000AA RID: 170
		public enum OBJECT_ICON
		{
			// Token: 0x040008A9 RID: 2217
			BUTTON,
			// Token: 0x040008AA RID: 2218
			LABEL,
			// Token: 0x040008AB RID: 2219
			LIST_NORMAL,
			// Token: 0x040008AC RID: 2220
			LIST_NOTE,
			// Token: 0x040008AD RID: 2221
			LIST_BALLOON,
			// Token: 0x040008AE RID: 2222
			MAX
		}
	}
}
