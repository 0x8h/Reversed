namespace Clock
{
	// Token: 0x02000034 RID: 52
	public partial class NetworkDataWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x060005D0 RID: 1488 RVA: 0x000460C1 File Offset: 0x000442C1
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x000460E0 File Offset: 0x000442E0
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.NetworkDataWindow));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.dataGridViewClient = new global::System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewServer = new global::System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewMessage = new global::System.Windows.Forms.DataGridView();
			this.メッセ\u30FCジ = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox4 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridViewClient).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridViewServer).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridViewMessage).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBox4);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBox3);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
			this.splitContainer1.Panel2.Controls.Add(this.dataGridViewClient);
			this.splitContainer1.Panel2.Controls.Add(this.dataGridViewServer);
			this.splitContainer1.Panel2.Controls.Add(this.dataGridViewMessage);
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Size = new global::System.Drawing.Size(615, 320);
			this.splitContainer1.SplitterDistance = 25;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(509, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(106, 25);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			this.dataGridViewClient.AllowUserToAddRows = false;
			this.dataGridViewClient.AutoSizeColumnsMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewClient.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewClient.ColumnHeadersVisible = false;
			this.dataGridViewClient.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[] { this.dataGridViewTextBoxColumn2 });
			this.dataGridViewClient.Location = new global::System.Drawing.Point(413, 87);
			this.dataGridViewClient.Name = "dataGridViewClient";
			this.dataGridViewClient.RowHeadersVisible = false;
			this.dataGridViewClient.RowTemplate.Height = 21;
			this.dataGridViewClient.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridViewClient.Size = new global::System.Drawing.Size(113, 130);
			this.dataGridViewClient.TabIndex = 13;
			this.dataGridViewTextBoxColumn2.HeaderText = "Column1";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewServer.AllowUserToAddRows = false;
			this.dataGridViewServer.AutoSizeColumnsMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewServer.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewServer.ColumnHeadersVisible = false;
			this.dataGridViewServer.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[] { this.dataGridViewTextBoxColumn1 });
			this.dataGridViewServer.Location = new global::System.Drawing.Point(248, 87);
			this.dataGridViewServer.Name = "dataGridViewServer";
			this.dataGridViewServer.RowHeadersVisible = false;
			this.dataGridViewServer.RowTemplate.Height = 21;
			this.dataGridViewServer.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridViewServer.Size = new global::System.Drawing.Size(113, 130);
			this.dataGridViewServer.TabIndex = 12;
			this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewMessage.AllowUserToAddRows = false;
			this.dataGridViewMessage.AutoSizeColumnsMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewMessage.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewMessage.ColumnHeadersVisible = false;
			this.dataGridViewMessage.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[] { this.メッセ\u30FCジ });
			this.dataGridViewMessage.Location = new global::System.Drawing.Point(79, 87);
			this.dataGridViewMessage.Name = "dataGridViewMessage";
			this.dataGridViewMessage.RowHeadersVisible = false;
			this.dataGridViewMessage.RowTemplate.Height = 21;
			this.dataGridViewMessage.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridViewMessage.Size = new global::System.Drawing.Size(113, 130);
			this.dataGridViewMessage.TabIndex = 11;
			this.メッセ\u30FCジ.HeaderText = "Column1";
			this.メッセ\u30FCジ.Name = "メッセージ";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label3.Location = new global::System.Drawing.Point(425, 55);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(116, 18);
			this.label3.TabIndex = 9;
			this.label3.Text = "クライアントデータ";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label2.Location = new global::System.Drawing.Point(267, 55);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(80, 18);
			this.label2.TabIndex = 8;
			this.label2.Text = "サーバデータ";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label1.Location = new global::System.Drawing.Point(103, 55);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(68, 18);
			this.label1.TabIndex = 7;
			this.label1.Text = "メッセージ";
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(338, 251);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 5;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(176, 251);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 3;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			this.pictureBox2.Image = global::Clock.Properties.Resources.nw_icon_000;
			this.pictureBox2.Location = new global::System.Drawing.Point(60, 41);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(32, 32);
			this.pictureBox2.TabIndex = 14;
			this.pictureBox2.TabStop = false;
			this.pictureBox3.Image = global::Clock.Properties.Resources.nw_icon_001;
			this.pictureBox3.Location = new global::System.Drawing.Point(228, 41);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(32, 32);
			this.pictureBox3.TabIndex = 15;
			this.pictureBox3.TabStop = false;
			this.pictureBox4.Image = global::Clock.Properties.Resources.nw_icon_002;
			this.pictureBox4.Location = new global::System.Drawing.Point(392, 41);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new global::System.Drawing.Size(32, 32);
			this.pictureBox4.TabIndex = 16;
			this.pictureBox4.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			base.ClientSize = new global::System.Drawing.Size(615, 320);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "NetworkDataWindow";
			this.Text = "データの設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.NetworkDataWindow_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridViewClient).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridViewServer).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridViewMessage).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400048F RID: 1167
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000490 RID: 1168
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000491 RID: 1169
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000492 RID: 1170
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x04000493 RID: 1171
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x04000494 RID: 1172
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000495 RID: 1173
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000496 RID: 1174
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000497 RID: 1175
		private global::System.Windows.Forms.DataGridView dataGridViewMessage;

		// Token: 0x04000498 RID: 1176
		private global::System.Windows.Forms.DataGridViewTextBoxColumn メッセ\u30FCジ;

		// Token: 0x04000499 RID: 1177
		private global::System.Windows.Forms.DataGridView dataGridViewClient;

		// Token: 0x0400049A RID: 1178
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		// Token: 0x0400049B RID: 1179
		private global::System.Windows.Forms.DataGridView dataGridViewServer;

		// Token: 0x0400049C RID: 1180
		private global::System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		// Token: 0x0400049D RID: 1181
		private global::System.Windows.Forms.PictureBox pictureBox4;

		// Token: 0x0400049E RID: 1182
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x0400049F RID: 1183
		private global::System.Windows.Forms.PictureBox pictureBox2;
	}
}
