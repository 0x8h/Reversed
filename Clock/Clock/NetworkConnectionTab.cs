using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000032 RID: 50
	public class NetworkConnectionTab : PictureBox
	{
		// Token: 0x060005A2 RID: 1442 RVA: 0x00044414 File Offset: 0x00042614
		public NetworkConnectionTab(NetworkConnectionWindow window, int index, string text)
		{
			this.InitializeComponent();
			this._window = window;
			this._index = index;
			base.Size = new Size(105, 33);
			base.Image = Resources.fc_tab_000;
			this._label.Text = text;
			this._label.Size = new Size(90, 20);
			this._label.Location = new Point(10, 10);
			this._label.Font = NetworkConnectionTab._font;
			base.Controls.Add(this._label);
			base.MouseClick += new MouseEventHandler(this.networkConnectionTab_Click);
			this._label.MouseClick += new MouseEventHandler(this.networkConnectionTab_Click);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x000444E0 File Offset: 0x000426E0
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

		// Token: 0x060005A4 RID: 1444 RVA: 0x00044542 File Offset: 0x00042742
		private void networkConnectionTab_Click(object sender, EventArgs e)
		{
			this._window.changeMode((NetworkConnectionWindow.MODE)this._index);
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x00044555 File Offset: 0x00042755
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x00044574 File Offset: 0x00042774
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x04000470 RID: 1136
		private NetworkConnectionWindow _window;

		// Token: 0x04000471 RID: 1137
		private int _index;

		// Token: 0x04000472 RID: 1138
		private Label _label = new Label();

		// Token: 0x04000473 RID: 1139
		private static Font _font = new Font("メイリオ", 8f, FontStyle.Regular, GraphicsUnit.Point, 128);

		// Token: 0x04000474 RID: 1140
		private IContainer components;
	}
}
