using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000021 RID: 33
	public class FlowchartTab : PictureBox
	{
		// Token: 0x06000266 RID: 614 RVA: 0x00024920 File Offset: 0x00022B20
		public FlowchartTab(FlowchartWindow window, int index)
		{
			this.InitializeComponent();
			this._window = window;
			this._index = index;
			base.Size = new Size(105, 33);
			base.Image = Resources.fc_tab_000;
			this._label.Text = "ルーチン名";
			this._label.Size = new Size(90, 20);
			this._label.Location = new Point(10, 10);
			this._label.Font = FlowchartTab._font;
			base.Controls.Add(this._label);
			base.MouseClick += new MouseEventHandler(this.flowchartTab_Click);
			base.MouseDoubleClick += new MouseEventHandler(this.flowchartTab_DoubleClick);
			this._label.MouseClick += new MouseEventHandler(this.flowchartTab_Click);
			this._label.MouseDoubleClick += new MouseEventHandler(this.flowchartTab_DoubleClick);
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00024A18 File Offset: 0x00022C18
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

		// Token: 0x06000268 RID: 616 RVA: 0x00024A7A File Offset: 0x00022C7A
		public void setText(string text)
		{
			this._label.Text = text;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00024A88 File Offset: 0x00022C88
		private void flowchartTab_Click(object sender, EventArgs e)
		{
			this._window.changeRoutine((ProgramModules.ROUTINE)this._index);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00024A9C File Offset: 0x00022C9C
		private void flowchartTab_DoubleClick(object sender, EventArgs e)
		{
			SubroutinePropertyDialog subroutinePropertyDialog = new SubroutinePropertyDialog(this._window.Programs.Programs[this._index]);
			subroutinePropertyDialog.ShowDialog();
			if (subroutinePropertyDialog.Updated)
			{
				this.setText(this._window.Programs.Programs[this._index].Name);
				this._window.updateSubroutineName();
				this._window.addHistory(true);
			}
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00024B0C File Offset: 0x00022D0C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00024B2B File Offset: 0x00022D2B
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x0400023C RID: 572
		private FlowchartWindow _window;

		// Token: 0x0400023D RID: 573
		private int _index;

		// Token: 0x0400023E RID: 574
		private Label _label = new Label();

		// Token: 0x0400023F RID: 575
		private static Font _font = new Font("メイリオ", 8f, FontStyle.Regular, GraphicsUnit.Point, 128);

		// Token: 0x04000240 RID: 576
		private IContainer components;
	}
}
