namespace Clock
{
	// Token: 0x0200002A RID: 42
	public partial class InformationWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x0600047F RID: 1151 RVA: 0x00038561 File Offset: 0x00036761
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00038580 File Offset: 0x00036780
		private void InitializeComponent()
		{
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new global::System.Windows.Forms.DataGridViewCellStyle();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.InformationWindow));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.dataGridView1 = new global::System.Windows.Forms.DataGridView();
			this.Column1 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonReset = new global::System.Windows.Forms.Button();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.BackColor = global::System.Drawing.SystemColors.Control;
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer1.Panel2.Controls.Add(this.buttonReset);
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer1.Size = new global::System.Drawing.Size(194, 340);
			this.splitContainer1.SplitterDistance = 29;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBox1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(88, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(106, 29);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.BackgroundColor = global::System.Drawing.SystemColors.Window;
			dataGridViewCellStyle.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = global::System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			dataGridViewCellStyle.ForeColor = global::System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle.Padding = new global::System.Windows.Forms.Padding(10, 0, 0, 0);
			dataGridViewCellStyle.SelectionBackColor = global::System.Drawing.SystemColors.ControlLight;
			dataGridViewCellStyle.SelectionForeColor = global::System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridView1.ColumnHeadersHeight = 25;
			this.dataGridView1.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[] { this.Column1, this.Column2 });
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.Location = new global::System.Drawing.Point(30, 13);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.dataGridView1.RowHeadersVisible = false;
			dataGridViewCellStyle2.BackColor = global::System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			dataGridViewCellStyle2.ForeColor = global::System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = global::System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.SelectionForeColor = global::System.Drawing.SystemColors.ControlText;
			this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.RowTemplate.Height = 25;
			this.dataGridView1.ScrollBars = global::System.Windows.Forms.ScrollBars.None;
			this.dataGridView1.Size = new global::System.Drawing.Size(133, 252);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellEndEdit += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
			this.Column1.HeaderText = "説明";
			this.Column1.Name = "Column1";
			this.Column1.Width = 70;
			this.Column2.HeaderText = "数値";
			this.Column2.Name = "Column2";
			this.Column2.Width = 60;
			this.buttonReset.Location = new global::System.Drawing.Point(40, 272);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new global::System.Drawing.Size(113, 26);
			this.buttonReset.TabIndex = 1;
			this.buttonReset.Text = "数値をリセット";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new global::System.EventHandler(this.buttonReset_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(194, 340);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "InformationWindow";
			this.Text = "情報ウィンドウ";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.InformationWindow_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000396 RID: 918
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000397 RID: 919
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000398 RID: 920
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000399 RID: 921
		private global::System.Windows.Forms.DataGridView dataGridView1;

		// Token: 0x0400039A RID: 922
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column1;

		// Token: 0x0400039B RID: 923
		private global::System.Windows.Forms.DataGridViewTextBoxColumn Column2;

		// Token: 0x0400039C RID: 924
		private global::System.Windows.Forms.Button buttonReset;
	}
}
