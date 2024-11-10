namespace Clock
{
	// Token: 0x02000010 RID: 16
	public partial class BlockPropertyNetworkIfDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600011C RID: 284 RVA: 0x00012920 File Offset: 0x00010B20
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00012940 File Offset: 0x00010B40
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.BlockPropertyNetworkIfDialog));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.comboBoxCondition = new global::System.Windows.Forms.ComboBox();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonOK = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).BeginInit();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
			this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxCondition);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonOK);
			this.splitContainer1.Size = new global::System.Drawing.Size(440, 255);
			this.splitContainer1.SplitterDistance = 26;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 0;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBox1.Location = new global::System.Drawing.Point(334, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(106, 26);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.comboBoxCondition.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCondition.FormattingEnabled = true;
			this.comboBoxCondition.Location = new global::System.Drawing.Point(150, 15);
			this.comboBoxCondition.Name = "comboBoxCondition";
			this.comboBoxCondition.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxCondition.TabIndex = 7;
			this.comboBoxCondition.SelectedValueChanged += new global::System.EventHandler(this.comboBoxCondition_SelectedValueChanged);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(250, 186);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 6;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.pictureBoxButtonOK.Image = global::Clock.Properties.Resources.popup_btn_000;
			this.pictureBoxButtonOK.Location = new global::System.Drawing.Point(75, 186);
			this.pictureBoxButtonOK.Name = "pictureBoxButtonOK";
			this.pictureBoxButtonOK.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonOK.TabIndex = 5;
			this.pictureBoxButtonOK.TabStop = false;
			this.pictureBoxButtonOK.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseDown);
			this.pictureBoxButtonOK.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonOK_MouseEnter);
			this.pictureBoxButtonOK.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonOK_MouseLeave);
			this.pictureBoxButtonOK.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonOK_MouseUp);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(440, 255);
			base.Controls.Add(this.splitContainer1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BlockPropertyNetworkIfDialog";
			this.Text = "分岐設定";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BlockPropertyNetworkIfDialog_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonOK).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000154 RID: 340
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000155 RID: 341
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000156 RID: 342
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x04000157 RID: 343
		private global::System.Windows.Forms.PictureBox pictureBoxButtonOK;

		// Token: 0x04000158 RID: 344
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000159 RID: 345
		private global::System.Windows.Forms.ComboBox comboBoxCondition;
	}
}
