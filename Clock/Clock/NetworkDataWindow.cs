using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000034 RID: 52
	public partial class NetworkDataWindow : Form
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060005C5 RID: 1477 RVA: 0x00045D6D File Offset: 0x00043F6D
		public bool Updated
		{
			get
			{
				return this._updated;
			}
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x00045D78 File Offset: 0x00043F78
		public NetworkDataWindow(NetworkProgramModules programs)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._programs = programs;
			foreach (string text in programs.MessageNames)
			{
				this.dataGridViewMessage.Rows.Add(new object[] { text });
			}
			foreach (string text2 in programs.ServerVariableNames)
			{
				this.dataGridViewServer.Rows.Add(new object[] { text2 });
			}
			foreach (string text3 in programs.ClientVariableNames)
			{
				this.dataGridViewClient.Rows.Add(new object[] { text3 });
			}
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x000024F1 File Offset: 0x000006F1
		private void NetworkDataWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00045EB8 File Offset: 0x000440B8
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00045ED7 File Offset: 0x000440D7
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00045EE9 File Offset: 0x000440E9
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00045EFC File Offset: 0x000440FC
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				this._programs.MessageNames.Clear();
				for (int i = 0; i < this.dataGridViewMessage.Rows.Count; i++)
				{
					this._programs.MessageNames.Add((string)this.dataGridViewMessage.Rows[i].Cells[0].Value);
				}
				this._programs.ServerVariableNames.Clear();
				for (int j = 0; j < this.dataGridViewServer.Rows.Count; j++)
				{
					this._programs.ServerVariableNames.Add((string)this.dataGridViewServer.Rows[j].Cells[0].Value);
				}
				this._programs.ClientVariableNames.Clear();
				for (int k = 0; k < this.dataGridViewClient.Rows.Count; k++)
				{
					this._programs.ClientVariableNames.Add((string)this.dataGridViewClient.Rows[k].Cells[0].Value);
				}
				this._updated = true;
				base.Close();
			}
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00046059 File Offset: 0x00044259
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x00046078 File Offset: 0x00044278
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0004608A File Offset: 0x0004428A
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0004609C File Offset: 0x0004429C
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x0400048D RID: 1165
		private NetworkProgramModules _programs;

		// Token: 0x0400048E RID: 1166
		private bool _updated;
	}
}
