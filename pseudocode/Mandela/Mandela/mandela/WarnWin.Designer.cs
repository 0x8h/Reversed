namespace mandela
{
	// Token: 0x02000006 RID: 6
	public partial class WarnWin : global::System.Windows.Forms.Form
	{
		// Token: 0x06000020 RID: 32 RVA: 0x000041E0 File Offset: 0x000023E0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000420C File Offset: 0x0000240C
		private void InitializeComponent()
		{
			this.icontainer_0 = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::mandela.WarnWin));
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.timer_0 = new global::System.Windows.Forms.Timer(this.icontainer_0);
			this.timer_1 = new global::System.Windows.Forms.Timer(this.icontainer_0);
			this.UwLnLdKmu = new global::System.Windows.Forms.Timer(this.icontainer_0);
			this.timer_2 = new global::System.Windows.Forms.Timer(this.icontainer_0);
			this.timer_3 = new global::System.Windows.Forms.Timer(this.icontainer_0);
			this.pictureBox8 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox7 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox6 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox5 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox4 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox8).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.button1.BackColor = global::System.Drawing.Color.Transparent;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.Silver;
			this.button1.Location = new global::System.Drawing.Point(140, 377);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(175, 52);
			this.button1.TabIndex = 8;
			this.button1.Text = "RUN";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button1.MouseLeave += new global::System.EventHandler(this.button1_MouseLeave);
			this.button1.MouseHover += new global::System.EventHandler(this.button1_MouseHover);
			this.button2.BackColor = global::System.Drawing.Color.Transparent;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Popup;
			this.button2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.Silver;
			this.button2.Location = new global::System.Drawing.Point(330, 377);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(175, 52);
			this.button2.TabIndex = 9;
			this.button2.Text = "EXIT";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button2.MouseLeave += new global::System.EventHandler(this.button2_MouseLeave);
			this.button2.MouseHover += new global::System.EventHandler(this.button2_MouseHover);
			this.timer_0.Enabled = true;
			this.timer_0.Interval = 1000;
			this.timer_0.Tick += new global::System.EventHandler(this.timer_0_Tick);
			this.timer_1.Interval = 10;
			this.timer_1.Tick += new global::System.EventHandler(this.timer_1_Tick);
			this.UwLnLdKmu.Interval = 10;
			this.UwLnLdKmu.Tick += new global::System.EventHandler(this.UwLnLdKmu_Tick);
			this.timer_2.Enabled = true;
			this.timer_2.Interval = 10;
			this.timer_2.Tick += new global::System.EventHandler(this.timer_2_Tick);
			this.timer_3.Interval = 90000;
			this.timer_3.Tick += new global::System.EventHandler(this.timer_3_Tick);
			this.pictureBox8.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox8.Image");
			this.pictureBox8.Location = new global::System.Drawing.Point(10, 13);
			this.pictureBox8.Name = "pictureBox8";
			this.pictureBox8.Size = new global::System.Drawing.Size(640, 344);
			this.pictureBox8.TabIndex = 7;
			this.pictureBox8.TabStop = false;
			this.pictureBox8.Visible = false;
			this.pictureBox7.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox7.Image");
			this.pictureBox7.Location = new global::System.Drawing.Point(11, 13);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new global::System.Drawing.Size(640, 344);
			this.pictureBox7.TabIndex = 6;
			this.pictureBox7.TabStop = false;
			this.pictureBox7.Visible = false;
			this.pictureBox6.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox6.Image");
			this.pictureBox6.Location = new global::System.Drawing.Point(10, 13);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new global::System.Drawing.Size(640, 344);
			this.pictureBox6.TabIndex = 5;
			this.pictureBox6.TabStop = false;
			this.pictureBox6.Visible = false;
			this.pictureBox5.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox5.Image");
			this.pictureBox5.Location = new global::System.Drawing.Point(10, 14);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new global::System.Drawing.Size(640, 344);
			this.pictureBox5.TabIndex = 4;
			this.pictureBox5.TabStop = false;
			this.pictureBox5.Visible = false;
			this.pictureBox4.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox4.Image");
			this.pictureBox4.Location = new global::System.Drawing.Point(10, 14);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new global::System.Drawing.Size(640, 344);
			this.pictureBox4.TabIndex = 3;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Visible = false;
			this.pictureBox3.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox3.Image");
			this.pictureBox3.Location = new global::System.Drawing.Point(10, 13);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(640, 344);
			this.pictureBox3.TabIndex = 2;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Visible = false;
			this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new global::System.Drawing.Point(10, 13);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(640, 344);
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Visible = false;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(14, 14);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(640, 344);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.Black;
			base.ClientSize = new global::System.Drawing.Size(664, 441);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.pictureBox8);
			base.Controls.Add(this.pictureBox7);
			base.Controls.Add(this.pictureBox6);
			base.Controls.Add(this.pictureBox5);
			base.Controls.Add(this.pictureBox4);
			base.Controls.Add(this.pictureBox3);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.pictureBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "WarnWin";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mandela(Trojan.Win32) -  CREATED BY CYBER SOLDIER";
			base.TopMost = true;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.WarnWin_FormClosing);
			base.Load += new global::System.EventHandler(this.WarnWin_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox8).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000012 RID: 18
		private global::System.ComponentModel.IContainer icontainer_0;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.PictureBox pictureBox4;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.PictureBox pictureBox5;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.PictureBox pictureBox6;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.PictureBox pictureBox7;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.PictureBox pictureBox8;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Button button2;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Timer timer_0;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Timer timer_1;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Timer UwLnLdKmu;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Timer timer_2;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Timer timer_3;
	}
}
