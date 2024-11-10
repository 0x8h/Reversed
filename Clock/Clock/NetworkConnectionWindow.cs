using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000033 RID: 51
	public partial class NetworkConnectionWindow : Form
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x0004459E File Offset: 0x0004279E
		public static NetworkConnectionWindow Instance
		{
			get
			{
				return NetworkConnectionWindow._instance;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060005A9 RID: 1449 RVA: 0x000445A5 File Offset: 0x000427A5
		// (set) Token: 0x060005AA RID: 1450 RVA: 0x000445AC File Offset: 0x000427AC
		public static int Port { get; set; } = 50000;

		// Token: 0x060005AB RID: 1451 RVA: 0x000445B4 File Offset: 0x000427B4
		public NetworkConnectionWindow()
		{
			NetworkConnectionWindow._instance = this;
			this.InitializeComponent();
			this.textBoxName.Text = Server.Name;
			for (int i = 0; i < 2; i++)
			{
				this._tabs[i] = new NetworkConnectionTab(this, i, NetworkConnectionWindow.MODE_TEXT[i]);
				this._tabs[i].Location = new Point(3 + 102 * i, 60);
				this.splitContainer1.Panel1.Controls.Add(this._tabs[i]);
			}
			if (!Server.isConnect() && Client.isConnect())
			{
				this.changeMode(NetworkConnectionWindow.MODE.CLIENT);
			}
			else
			{
				this.changeMode(NetworkConnectionWindow.MODE.SERVER);
			}
			IPAddress myIPAddress = this.getMyIPAddress();
			this.labelIP.Text = "IPアドレス: " + ((myIPAddress == null) ? "不明" : myIPAddress.ToString());
			this.labelPort.Text = "ポート: " + NetworkConnectionWindow.Port.ToString();
			this.updateLabelWhich();
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x000446C4 File Offset: 0x000428C4
		public void updateClientList(Dictionary<string, string> clients)
		{
			this.dataGridViewClient.Rows.Clear();
			foreach (KeyValuePair<string, string> keyValuePair in clients)
			{
				if (keyValuePair.Key == "127.0.0.1")
				{
					IPAddress myIPAddress = this.getMyIPAddress();
					this.addClient(keyValuePair.Value, (myIPAddress == null) ? "不明" : myIPAddress.ToString());
				}
				else
				{
					this.addClient(keyValuePair.Value, keyValuePair.Key);
				}
			}
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x00044768 File Offset: 0x00042968
		public void updateServerList(List<string> servers)
		{
			this.dataGridViewServer.Rows.Clear();
			foreach (string text in servers)
			{
				string[] array = text.Split(new char[] { ',' });
				if (array.Length == 2)
				{
					this.addServer(array[0], array[1]);
					if (Client.isConnect())
					{
						if (!Server.isConnect() && Client.ServerIpAddress.ToString() == array[1])
						{
							this.dataGridViewServer[0, this.dataGridViewServer.Rows.Count - 1].Value = true;
							this.dataGridViewServer[0, this.dataGridViewServer.Rows.Count - 1].Selected = true;
							this.pictureBoxButtonConnect.Image = Resources.nw_btn_on;
						}
						else
						{
							this.dataGridViewServer[0, this.dataGridViewServer.Rows.Count - 1].ReadOnly = true;
						}
					}
				}
			}
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00044894 File Offset: 0x00042A94
		public void updateConnectedServer(string ip)
		{
			foreach (object obj in ((IEnumerable)this.dataGridViewServer.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Cells[2].Value.ToString() == ip)
				{
					dataGridViewRow.Cells[0].Value = true;
					this.pictureBoxButtonConnect.Image = Resources.nw_btn_on;
				}
				else
				{
					dataGridViewRow.Cells[0].Value = false;
				}
			}
			this.dataGridViewServer.EndEdit();
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00044958 File Offset: 0x00042B58
		public void updateLabelWhich()
		{
			if (Server.isConnect())
			{
				this.labelWhich.Visible = true;
				this.labelWhich.Text = "サーバとして起動中";
			}
			else if (Client.isConnect())
			{
				this.labelWhich.Visible = true;
				this.labelWhich.Text = "クライアントとして起動中";
			}
			else
			{
				this.labelWhich.Visible = false;
			}
			this.pictureBoxButtonConnect.Image = (Client.isConnect() ? Resources.nw_btn_on : Resources.nw_btn_off);
			this.pictureBoxButtonUpdate.Image = (Client.isConnect() ? Resources.popup_btn_083 : Resources.popup_btn_080);
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x000449F8 File Offset: 0x00042BF8
		private IPAddress getMyIPAddress()
		{
			foreach (IPAddress ipaddress in Dns.GetHostAddresses(Dns.GetHostName()))
			{
				if (ipaddress.AddressFamily == AddressFamily.InterNetwork)
				{
					return ipaddress;
				}
			}
			return null;
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00044A30 File Offset: 0x00042C30
		public void changeMode(NetworkConnectionWindow.MODE mode)
		{
			if (((!Server.isConnect() && !Client.isConnect()) || this._mode == NetworkConnectionWindow.MODE.MAX) && this._mode != mode)
			{
				if (mode != NetworkConnectionWindow.MODE.SERVER)
				{
					if (mode == NetworkConnectionWindow.MODE.CLIENT)
					{
						UDP.StartRecieve();
						this.labelServer.Text = "サーバへの接続";
						this.pictureBoxButtonConnect.Image = ((!Server.isConnect() && Client.isConnect()) ? Resources.nw_btn_on : Resources.nw_btn_off);
						this.dataGridViewClient.Visible = false;
						this.dataGridViewServer.Visible = true;
						this.pictureBoxButtonUpdate.Visible = true;
						UDP.broadcast();
					}
				}
				else
				{
					if (!Server.isConnect())
					{
						UDP.Stop();
					}
					this.labelServer.Text = "サーバの起動";
					this.pictureBoxButtonConnect.Image = (Server.isConnect() ? Resources.nw_btn_on : Resources.nw_btn_off);
					this.dataGridViewClient.Visible = true;
					this.dataGridViewServer.Visible = false;
					this.pictureBoxButtonUpdate.Visible = false;
					this.textBoxName.Enabled = !Server.isConnect();
					this.updateClientList(Server.ClientsInfo);
				}
				this._mode = mode;
				for (int i = 0; i < 2; i++)
				{
					this._tabs[i].setSelected(false);
				}
				this._tabs[(int)mode].setSelected(true);
			}
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00044B84 File Offset: 0x00042D84
		private void pictureBoxButtonConnect_MouseClick(object sender, MouseEventArgs e)
		{
			if (this._mode == NetworkConnectionWindow.MODE.SERVER)
			{
				if (e.X < this.pictureBoxButtonConnect.Image.Width / 2)
				{
					if (!Server.isConnect())
					{
						if (Client.isConnect())
						{
							Client.Disconnect();
						}
						else
						{
							Server.Start();
						}
					}
				}
				else if (Server.isConnect())
				{
					Server.Stop();
				}
				this.pictureBoxButtonConnect.Image = (Server.isConnect() ? Resources.nw_btn_on : Resources.nw_btn_off);
				this.textBoxName.Enabled = !Server.isConnect();
			}
			else if (this.dataGridViewServer.SelectedRows.Count > 0)
			{
				bool flag = Client.isConnect() && this.dataGridViewServer.SelectedCells[2].Value.ToString() == Client.ServerIpAddress.ToString().Split(new char[] { ':' })[0];
				if (e.X < this.pictureBoxButtonConnect.Image.Width / 2)
				{
					if (!flag)
					{
						if (Server.isConnect())
						{
							Server.Stop();
						}
						else if (Client.isConnect())
						{
							Client.Disconnect();
							this.dataGridViewServer.SelectedCells[0].Value = false;
						}
						else
						{
							Client.Connect(IPAddress.Parse((string)this.dataGridViewServer.SelectedCells[2].Value), (string)this.dataGridViewServer.SelectedCells[1].Value);
							for (int i = 0; i < this.dataGridViewServer.Rows.Count; i++)
							{
								if (this.dataGridViewServer.Rows[i] != this.dataGridViewServer.SelectedRows[0])
								{
									this.dataGridViewServer.Rows[i].ReadOnly = true;
								}
							}
						}
					}
				}
				else if (flag)
				{
					Client.Disconnect();
					this.dataGridViewServer.SelectedCells[0].Value = false;
				}
			}
			this.updateLabelWhich();
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x00044D91 File Offset: 0x00042F91
		private void addClient(string name, string ipAddress)
		{
			this.dataGridViewClient.Rows.Add(new object[] { name, ipAddress });
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00044DB2 File Offset: 0x00042FB2
		private void addServer(string name, string ipAddress)
		{
			this.dataGridViewServer.Rows.Add(new object[] { false, name, ipAddress });
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00044DDC File Offset: 0x00042FDC
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x00044DFB File Offset: 0x00042FFB
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x00044E0D File Offset: 0x0004300D
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x00044E1F File Offset: 0x0004301F
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				base.Close();
			}
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x00044E44 File Offset: 0x00043044
		private void NetworkConnectionWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (!Server.isConnect())
			{
				UDP.Stop();
			}
			NetworkLog.Instance.Save();
			base.Dispose();
			NetworkConnectionWindow._instance = null;
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00044E68 File Offset: 0x00043068
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Server.Name = ((TextBox)sender).Text;
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x00044E7C File Offset: 0x0004307C
		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			if (!Server.isConnect() && Client.isConnect())
			{
				foreach (object obj in ((IEnumerable)this.dataGridViewServer.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if ((bool)dataGridViewRow.Cells[0].Value)
					{
						dataGridViewRow.Selected = true;
						break;
					}
				}
			}
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x00044F04 File Offset: 0x00043104
		private void pictureBoxButtonUpdate_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !Client.isConnect())
			{
				this.pictureBoxButtonUpdate.Image = Resources.popup_btn_081;
			}
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x00044F2A File Offset: 0x0004312A
		private void pictureBoxButtonUpdate_MouseEnter(object sender, EventArgs e)
		{
			if (!Client.isConnect())
			{
				this.pictureBoxButtonUpdate.Image = Resources.popup_btn_082;
			}
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x00044F43 File Offset: 0x00043143
		private void pictureBoxButtonUpdate_MouseLeave(object sender, EventArgs e)
		{
			if (!Client.isConnect())
			{
				this.pictureBoxButtonUpdate.Image = Resources.popup_btn_080;
			}
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x00044F5C File Offset: 0x0004315C
		private void pictureBoxButtonUpdate_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !Client.isConnect())
			{
				this.pictureBoxButtonUpdate.Image = Resources.popup_btn_082;
				UDP.broadcast();
			}
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x00044F88 File Offset: 0x00043188
		private void dataGridViewServer_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (this.dataGridViewServer.CurrentCellAddress.X == 0 && this.dataGridViewServer.IsCurrentCellDirty)
			{
				this.dataGridViewServer.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x00044FC8 File Offset: 0x000431C8
		private void dataGridViewServer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0 && e.RowIndex >= 0)
			{
				int num = (((bool)this.dataGridViewServer[e.ColumnIndex, e.RowIndex].Value) ? 1 : (this.pictureBoxButtonConnect.Image.Width / 2 + 1));
				this.pictureBoxButtonConnect_MouseClick(sender, new MouseEventArgs(MouseButtons.Left, 1, num, 0, 0));
			}
		}

		// Token: 0x04000475 RID: 1141
		private static NetworkConnectionWindow _instance = null;

		// Token: 0x04000477 RID: 1143
		private NetworkConnectionWindow.MODE _mode = NetworkConnectionWindow.MODE.MAX;

		// Token: 0x04000478 RID: 1144
		private static readonly string[] MODE_TEXT = new string[] { "サーバー", "クライアント" };

		// Token: 0x04000479 RID: 1145
		private NetworkConnectionTab[] _tabs = new NetworkConnectionTab[2];

		// Token: 0x020000A2 RID: 162
		private enum SERVER_LIST_COLUMN
		{
			// Token: 0x04000882 RID: 2178
			CONNECTION,
			// Token: 0x04000883 RID: 2179
			NAME,
			// Token: 0x04000884 RID: 2180
			IP_ADDRESS
		}

		// Token: 0x020000A3 RID: 163
		public enum MODE
		{
			// Token: 0x04000886 RID: 2182
			SERVER,
			// Token: 0x04000887 RID: 2183
			CLIENT,
			// Token: 0x04000888 RID: 2184
			MAX
		}
	}
}
