using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000042 RID: 66
	public class NetworkObjectTab : PictureBox
	{
		// Token: 0x06000690 RID: 1680 RVA: 0x0004EA50 File Offset: 0x0004CC50
		public NetworkObjectTab(NetworkWindow window, int index)
		{
			this.InitializeComponent();
			this._window = window;
			this._index = index;
			base.Size = new Size(95, 33);
			base.Image = Resources.nw_tab_000;
			this._label.Text = NetworkObjectTab.TAB_NAMES[index];
			this._label.Size = new Size(80, 20);
			this._label.Location = new Point(10, 10);
			this._label.Font = NetworkObjectTab._font;
			base.Controls.Add(this._label);
			base.MouseClick += new MouseEventHandler(this.objectTab_Click);
			this._label.MouseClick += new MouseEventHandler(this.objectTab_Click);
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0004EB20 File Offset: 0x0004CD20
		public void setSelected(bool on)
		{
			if (on)
			{
				base.Image = Resources.nw_tab_000;
				this._label.BackColor = Color.FromArgb(247, 246, 229);
				return;
			}
			base.Image = Resources.nw_tab_001;
			this._label.BackColor = Color.FromArgb(117, 179, 179);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0004EB82 File Offset: 0x0004CD82
		public void setText(string text)
		{
			this._label.Text = text;
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0004EB90 File Offset: 0x0004CD90
		private void objectTab_Click(object sender, EventArgs e)
		{
			this._window.changeObjectTab((NetworkObjectTab.TAB)this._index);
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0004EBA3 File Offset: 0x0004CDA3
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0004EBC2 File Offset: 0x0004CDC2
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040004F5 RID: 1269
		public static readonly string[] TAB_NAMES = new string[] { "機能一覧", "設定", "サウンド" };

		// Token: 0x040004F6 RID: 1270
		private NetworkWindow _window;

		// Token: 0x040004F7 RID: 1271
		private int _index;

		// Token: 0x040004F8 RID: 1272
		private Label _label = new Label();

		// Token: 0x040004F9 RID: 1273
		private static Font _font = new Font("メイリオ", 8f, FontStyle.Regular, GraphicsUnit.Point, 128);

		// Token: 0x040004FA RID: 1274
		private IContainer components;

		// Token: 0x020000AE RID: 174
		public enum TAB
		{
			// Token: 0x040008BA RID: 2234
			INVALID = -1,
			// Token: 0x040008BB RID: 2235
			OBJECT,
			// Token: 0x040008BC RID: 2236
			PROPERTY,
			// Token: 0x040008BD RID: 2237
			SOUND,
			// Token: 0x040008BE RID: 2238
			MAX
		}
	}
}
