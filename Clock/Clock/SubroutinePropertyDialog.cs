using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000057 RID: 87
	public partial class SubroutinePropertyDialog : Form
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x0006A5B4 File Offset: 0x000687B4
		public bool Updated
		{
			get
			{
				return this._updated;
			}
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0006A5BC File Offset: 0x000687BC
		public SubroutinePropertyDialog(ProgramModule program)
		{
			this.InitializeComponent();
			this.Text = "ルーチン名の変更";
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._program = program;
			this.textBoxName.Text = this._program.Name;
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0006A617 File Offset: 0x00068817
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0006A636 File Offset: 0x00068836
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0006A648 File Offset: 0x00068848
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0006A65C File Offset: 0x0006885C
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				string text = this.textBoxName.Text;
				if (text.Length > 7)
				{
					text = this.textBoxName.Text.Substring(0, 7);
				}
				if (this._program.Name != text)
				{
					this._program.Name = text;
					this._updated = true;
				}
				base.Close();
			}
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0006A6DA File Offset: 0x000688DA
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0006A6F9 File Offset: 0x000688F9
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0006A70B File Offset: 0x0006890B
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0006A71D File Offset: 0x0006891D
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x040006BB RID: 1723
		private ProgramModule _program;

		// Token: 0x040006BC RID: 1724
		private bool _updated;
	}
}
