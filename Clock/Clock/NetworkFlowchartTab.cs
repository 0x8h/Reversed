using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000036 RID: 54
	public class NetworkFlowchartTab : PictureBox
	{
		// Token: 0x06000606 RID: 1542 RVA: 0x0004B87C File Offset: 0x00049A7C
		public NetworkFlowchartTab(NetworkWindow window, NetworkFlowchartTab.TAB index)
		{
			this.InitializeComponent();
			this._window = window;
			this._index = index;
			base.Size = new Size(105, 33);
			base.Image = Resources.fc_tab_000;
			this._label.Text = NetworkFlowchartTab.TAB_NAMES[(int)index];
			this._label.Size = new Size(90, 20);
			this._label.Location = new Point(10, 10);
			this._label.Font = NetworkFlowchartTab._font;
			base.Controls.Add(this._label);
			base.MouseClick += new MouseEventHandler(this.flowchartTab_Click);
			this._label.MouseClick += new MouseEventHandler(this.flowchartTab_Click);
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0004B94C File Offset: 0x00049B4C
		public void setSelected(bool on)
		{
			if (on)
			{
				base.Image = Resources.fc_tab_000;
				this._label.BackColor = Color.FromArgb(247, 246, 229);
				return;
			}
			base.Image = Resources.fc_tab_001;
			this._label.BackColor = Color.FromArgb(117, 179, 179);
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0004B9AE File Offset: 0x00049BAE
		public void setText(string text)
		{
			this._label.Text = text;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0004B9BC File Offset: 0x00049BBC
		private void flowchartTab_Click(object sender, EventArgs e)
		{
			this._window.changeFlowchartTab(this._index, false);
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0004B9D0 File Offset: 0x00049BD0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0004B9EF File Offset: 0x00049BEF
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040004B6 RID: 1206
		public static readonly string[] TAB_NAMES = new string[] { "オブジェクト", "ステージ" };

		// Token: 0x040004B7 RID: 1207
		private NetworkWindow _window;

		// Token: 0x040004B8 RID: 1208
		private NetworkFlowchartTab.TAB _index;

		// Token: 0x040004B9 RID: 1209
		private Label _label = new Label();

		// Token: 0x040004BA RID: 1210
		private static Font _font = new Font("メイリオ", 8f, FontStyle.Regular, GraphicsUnit.Point, 128);

		// Token: 0x040004BB RID: 1211
		private IContainer components;

		// Token: 0x020000A8 RID: 168
		public enum TAB
		{
			// Token: 0x040008A0 RID: 2208
			INVALID = -1,
			// Token: 0x040008A1 RID: 2209
			OBJECT,
			// Token: 0x040008A2 RID: 2210
			STAGE,
			// Token: 0x040008A3 RID: 2211
			MAX
		}
	}
}
