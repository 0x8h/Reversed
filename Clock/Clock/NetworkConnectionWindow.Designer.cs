namespace Clock
{
	// Token: 0x02000033 RID: 51
	public partial class NetworkConnectionWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x060005C2 RID: 1474 RVA: 0x00045036 File Offset: 0x00043236
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x00045058 File Offset: 0x00043258
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.NetworkConnectionWindow));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxButtonUpdate = new global::System.Windows.Forms.PictureBox();
			this.labelWhich = new global::System.Windows.Forms.Label();
			this.labelPort = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.labelIP = new global::System.Windows.Forms.Label();
			this.dataGridViewClient = new global::System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pictureBoxButtonConnect = new global::System.Windows.Forms.PictureBox();
			this.dataGridViewServer = new global::System.Windows.Forms.DataGridView();
			this.Column1 = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.textBoxName = new global::System.Windows.Forms.TextBox();
			this.labelName = new global::System.Windows.Forms.Label();
			this.labelServer = new global::System.Windows.Forms.Label();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonUpdate).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridViewClient).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonConnect).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridViewServer).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxButtonUpdate);
			this.splitContainer1.Panel1.Controls.Add(this.labelWhich);
			this.splitContainer1.Panel1.Controls.Add(this.labelPort);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
			this.splitContainer1.Panel1.Controls.Add(this.labelIP);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.Panel2.Controls.Add(this.dataGridViewClient);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonConnect);
			this.splitContainer1.Panel2.Controls.Add(this.dataGridViewServer);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxName);
			this.splitContainer1.Panel2.Controls.Add(this.labelName);
			this.splitContainer1.Panel2.Controls.Add(this.labelServer);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Size = new global::System.Drawing.Size(465, 371);
			this.splitContainer1.SplitterDistance = 90;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 1;
			this.pictureBoxButtonUpdate.Image = global::Clock.Properties.Resources.popup_btn_080;
			this.pictureBoxButtonUpdate.Location = new global::System.Drawing.Point(346, 25);
			this.pictureBoxButtonUpdate.Name = "pictureBoxButtonUpdate";
			this.pictureBoxButtonUpdate.Size = new global::System.Drawing.Size(102, 40);
			this.pictureBoxButtonUpdate.TabIndex = 18;
			this.pictureBoxButtonUpdate.TabStop = false;
			this.pictureBoxButtonUpdate.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonUpdate_MouseDown);
			this.pictureBoxButtonUpdate.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonUpdate_MouseEnter);
			this.pictureBoxButtonUpdate.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonUpdate_MouseLeave);
			this.pictureBoxButtonUpdate.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonUpdate_MouseUp);
			this.labelWhich.AutoSize = true;
			this.labelWhich.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelWhich.ForeColor = global::System.Drawing.Color.Red;
			this.labelWhich.Location = new global::System.Drawing.Point(214, 66);
			this.labelWhich.Name = "labelWhich";
			this.labelWhich.Size = new global::System.Drawing.Size(44, 18);
			this.labelWhich.TabIndex = 7;
			this.labelWhich.Text = "起動中";
			this.labelPort.AutoSize = true;
			this.labelPort.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelPort.ForeColor = global::System.Drawing.Color.Black;
			this.labelPort.Location = new global::System.Drawing.Point(21, 30);
			this.labelPort.Name = "labelPort";
			this.labelPort.Size = new global::System.Drawing.Size(49, 18);
			this.labelPort.TabIndex = 18;
			this.labelPort.Text = "ポート:";
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(359, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(106, 90);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.labelIP.AutoSize = true;
			this.labelIP.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelIP.ForeColor = global::System.Drawing.Color.Black;
			this.labelIP.Location = new global::System.Drawing.Point(21, 9);
			this.labelIP.Name = "labelIP";
			this.labelIP.Size = new global::System.Drawing.Size(73, 18);
			this.labelIP.TabIndex = 8;
			this.labelIP.Text = "IPアドレス:";
			this.dataGridViewClient.AllowUserToAddRows = false;
			this.dataGridViewClient.AllowUserToDeleteRows = false;
			this.dataGridViewClient.AllowUserToResizeRows = false;
			this.dataGridViewClient.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewClient.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[] { this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2 });
			this.dataGridViewClient.Location = new global::System.Drawing.Point(108, 71);
			this.dataGridViewClient.MultiSelect = false;
			this.dataGridViewClient.Name = "dataGridViewClient";
			this.dataGridViewClient.RowTemplate.Height = 21;
			this.dataGridViewClient.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewClient.Size = new global::System.Drawing.Size(244, 150);
			this.dataGridViewClient.TabIndex = 17;
			this.dataGridViewTextBoxColumn1.HeaderText = "クライアント名";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.HeaderText = "ＩＰアドレス";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.pictureBoxButtonConnect.Image = global::Clock.Properties.Resources.nw_btn_off;
			this.pictureBoxButtonConnect.Location = new global::System.Drawing.Point(142, 19);
			this.pictureBoxButtonConnect.Name = "pictureBoxButtonConnect";
			this.pictureBoxButtonConnect.Size = new global::System.Drawing.Size(74, 39);
			this.pictureBoxButtonConnect.TabIndex = 14;
			this.pictureBoxButtonConnect.TabStop = false;
			this.pictureBoxButtonConnect.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonConnect_MouseClick);
			this.dataGridViewServer.AllowUserToAddRows = false;
			this.dataGridViewServer.AllowUserToDeleteRows = false;
			this.dataGridViewServer.AllowUserToResizeRows = false;
			this.dataGridViewServer.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewServer.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[] { this.Column1, this.Column2, this.Column3 });
			this.dataGridViewServer.Location = new global::System.Drawing.Point(53, 71);
			this.dataGridViewServer.MultiSelect = false;
			this.dataGridViewServer.Name = "dataGridViewServer";
			this.dataGridViewServer.RowTemplate.Height = 21;
			this.dataGridViewServer.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewServer.Size = new global::System.Drawing.Size(352, 150);
			this.dataGridViewServer.TabIndex = 8;
			this.dataGridViewServer.CellValueChanged += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewServer_CellValueChanged);
			this.dataGridViewServer.CurrentCellDirtyStateChanged += new global::System.EventHandler(this.dataGridViewServer_CurrentCellDirtyStateChanged);
			this.dataGridViewServer.SelectionChanged += new global::System.EventHandler(this.dataGridView1_SelectionChanged);
			this.Column1.HeaderText = "接続";
			this.Column1.Name = "Column1";
			this.Column2.HeaderText = "サーバ名";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column3.HeaderText = "ＩＰアドレス";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.textBoxName.Location = new global::System.Drawing.Point(342, 31);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new global::System.Drawing.Size(100, 19);
			this.textBoxName.TabIndex = 7;
			this.textBoxName.TextChanged += new global::System.EventHandler(this.textBox1_TextChanged);
			this.labelName.AutoSize = true;
			this.labelName.Font = new global::System.Drawing.Font("メイリオ", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelName.Location = new global::System.Drawing.Point(228, 29);
			this.labelName.Name = "labelName";
			this.labelName.Size = new global::System.Drawing.Size(108, 21);
			this.labelName.TabIndex = 6;
			this.labelName.Text = "ユーザー名設定";
			this.labelServer.AutoSize = true;
			this.labelServer.Font = new global::System.Drawing.Font("メイリオ", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelServer.Location = new global::System.Drawing.Point(20, 28);
			this.labelServer.Name = "labelServer";
			this.labelServer.Size = new global::System.Drawing.Size(94, 21);
			this.labelServer.TabIndex = 5;
			this.labelServer.Text = "サーバの起動";
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(176, 227);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 1;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			base.ClientSize = new global::System.Drawing.Size(465, 371);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "NetworkConnectionWindow";
			this.Text = "ネットワーク接続";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.NetworkConnectionWindow_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonUpdate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridViewClient).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonConnect).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridViewServer).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400047A RID: 1146
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400047B RID: 1147
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x0400047C RID: 1148
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400047D RID: 1149
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x0400047E RID: 1150
		private global::System.Windows.Forms.DataGridView dataGridViewServer;

		// Token: 0x0400047F RID: 1151
		private global::System.Windows.Forms.TextBox textBoxName;

		// Token: 0x04000480 RID: 1152
		private global::System.Windows.Forms.Label labelName;

		// Token: 0x04000481 RID: 1153
		private global::System.Windows.Forms.Label labelServer;

		// Token: 0x04000482 RID: 1154
		private global::System.Windows.Forms.PictureBox pictureBoxButtonConnect;

		// Token: 0x04000483 RID: 1155
		private global::System.Windows.Forms.Label labelWhich;

		// Token: 0x04000484 RID: 1156
		private global::System.Windows.Forms.Label labelIP;

		// Token: 0x04000485 RID: 1157
		private global::System.Windows.Forms.DataGridView dataGridViewClient;

		// Token: 0x04000486 RID: 1158
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		// Token: 0x04000487 RID: 1159
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		// Token: 0x04000488 RID: 1160
		private global::System.Windows.Forms.Label labelPort;

		// Token: 0x04000489 RID: 1161
		private global::System.Windows.Forms.PictureBox pictureBoxButtonUpdate;

		// Token: 0x0400048A RID: 1162
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn Column1;

		// Token: 0x0400048B RID: 1163
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column2;

		// Token: 0x0400048C RID: 1164
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column3;
	}
}
