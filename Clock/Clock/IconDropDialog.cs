using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000027 RID: 39
	public partial class IconDropDialog : Form
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00030523 File Offset: 0x0002E723
		public new IconDropDialog.SELECT Select
		{
			get
			{
				return this._select;
			}
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0003052B File Offset: 0x0002E72B
		public IconDropDialog(IconAreaBlock block, IconAreaBlock.TYPE type)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._type = type;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00030568 File Offset: 0x0002E768
		private void pictureBoxWrite_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxWrite.Image = Resources.popup_btn_032;
			}
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00030587 File Offset: 0x0002E787
		private void pictureBoxWrite_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxWrite.Image = Resources.popup_btn_031;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00030599 File Offset: 0x0002E799
		private void pictureBoxWrite_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxWrite.Image = Resources.popup_btn_030;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x000305AC File Offset: 0x0002E7AC
		private void pictureBoxWrite_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxWrite.Image = Resources.popup_btn_031;
				IconWindow iconWindow = (IconWindow)base.Owner;
				if (iconWindow.isMemoryOver(IconAreaBlock.getMemoryCost(this._type) - this._block.Block.getUsedMemory()))
				{
					WarningDialog warningDialog = new WarningDialog();
					warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
					warningDialog.ShowDialog();
					return;
				}
				this._block.Type = this._type;
				this._select = IconDropDialog.SELECT.WRITE;
				iconWindow.updateLayout();
				iconWindow.updateLog("アイコンを上書き");
				iconWindow.addHistory();
				base.Close();
			}
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00030657 File Offset: 0x0002E857
		private void pictureBoxInsert_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxInsert.Image = Resources.popup_btn_042;
			}
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00030676 File Offset: 0x0002E876
		private void pictureBoxInsert_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxInsert.Image = Resources.popup_btn_041;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00030688 File Offset: 0x0002E888
		private void pictureBoxInsert_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxInsert.Image = Resources.popup_btn_040;
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0003069C File Offset: 0x0002E89C
		private void pictureBoxInsert_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxInsert.Image = Resources.popup_btn_041;
				IconWindow iconWindow = (IconWindow)base.Owner;
				if (iconWindow.isMemoryOver(IconAreaBlock.getMemoryCost(this._type)))
				{
					WarningDialog warningDialog = new WarningDialog();
					warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
					warningDialog.ShowDialog();
					return;
				}
				IconAreaBlock iconAreaBlock = new IconAreaBlock(iconWindow);
				iconAreaBlock.Type = this._type;
				this._select = IconDropDialog.SELECT.INSERT;
				iconWindow.insertAreaBlock(this._block, iconAreaBlock);
				iconWindow.updateLayout();
				iconWindow.updateLog("アイコンを挿入");
				iconWindow.addHistory();
				iconWindow.clearSelect();
				iconWindow.setSelect(iconAreaBlock);
				base.Close();
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00030752 File Offset: 0x0002E952
		private void pictureBoxCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00030771 File Offset: 0x0002E971
		private void pictureBoxCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00030783 File Offset: 0x0002E983
		private void pictureBoxCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00030795 File Offset: 0x0002E995
		private void pictureBoxCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCancel.Image = Resources.popup_btn_011;
				this._select = IconDropDialog.SELECT.CANCEL;
				base.Close();
			}
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x000024F1 File Offset: 0x000006F1
		private void IconDropDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x040002FF RID: 767
		private IconAreaBlock _block;

		// Token: 0x04000300 RID: 768
		private IconAreaBlock.TYPE _type;

		// Token: 0x04000301 RID: 769
		private IconDropDialog.SELECT _select = IconDropDialog.SELECT.CANCEL;

		// Token: 0x02000097 RID: 151
		public enum SELECT
		{
			// Token: 0x04000851 RID: 2129
			WRITE,
			// Token: 0x04000852 RID: 2130
			INSERT,
			// Token: 0x04000853 RID: 2131
			CANCEL
		}
	}
}
