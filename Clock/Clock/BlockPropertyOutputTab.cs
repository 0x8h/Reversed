using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000014 RID: 20
	public class BlockPropertyOutputTab : PictureBox
	{
		// Token: 0x0600016A RID: 362 RVA: 0x00017F80 File Offset: 0x00016180
		public BlockPropertyOutputTab(BlockPropertyOutputDialog window, int index)
		{
			this.InitializeComponent();
			this._window = window;
			this._index = index;
			base.Size = new Size(95, 33);
			base.Image = Resources.nw_tab_000;
			this._label.Text = BlockPropertyOutputTab.TAB_NAMES[index];
			this._label.Size = new Size(80, 20);
			this._label.Location = new Point(10, 10);
			this._label.Font = BlockPropertyOutputTab._font;
			base.Controls.Add(this._label);
			base.MouseClick += new MouseEventHandler(this.outputTab_Click);
			this._label.MouseClick += new MouseEventHandler(this.outputTab_Click);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00018050 File Offset: 0x00016250
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

		// Token: 0x0600016C RID: 364 RVA: 0x000180B2 File Offset: 0x000162B2
		public void setText(string text)
		{
			this._label.Text = text;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000180C0 File Offset: 0x000162C0
		private void outputTab_Click(object sender, EventArgs e)
		{
			this._window.changeOutputTab((BlockPropertyOutputTab.TAB)this._index);
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000180D3 File Offset: 0x000162D3
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000180F2 File Offset: 0x000162F2
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040001B9 RID: 441
		public static readonly string[] TAB_NAMES = new string[] { "LED", "サウンド" };

		// Token: 0x040001BA RID: 442
		private BlockPropertyOutputDialog _window;

		// Token: 0x040001BB RID: 443
		private int _index;

		// Token: 0x040001BC RID: 444
		private Label _label = new Label();

		// Token: 0x040001BD RID: 445
		private static Font _font = new Font("メイリオ", 8f, FontStyle.Regular, GraphicsUnit.Point, 128);

		// Token: 0x040001BE RID: 446
		private IContainer components;

		// Token: 0x0200006D RID: 109
		public enum TAB
		{
			// Token: 0x04000726 RID: 1830
			INVALID = -1,
			// Token: 0x04000727 RID: 1831
			LED,
			// Token: 0x04000728 RID: 1832
			SOUND,
			// Token: 0x04000729 RID: 1833
			MAX
		}
	}
}
