namespace Dos
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00002168 File Offset: 0x00000368
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000021A0 File Offset: 0x000003A0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Dos.Form1));
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.iptxt = new global::System.Windows.Forms.TextBox();
			this.porttxt = new global::System.Windows.Forms.TextBox();
			this.datatxt = new global::System.Windows.Forms.TextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.button2 = new global::System.Windows.Forms.Button();
			this.linkLabel1 = new global::System.Windows.Forms.LinkLabel();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 48f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label1.Location = new global::System.Drawing.Point(133, 107);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(224, 64);
			this.label1.TabIndex = 0;
			this.label1.Text = "標的IP";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 48f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label2.Location = new global::System.Drawing.Point(133, 187);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(290, 64);
			this.label2.TabIndex = 1;
			this.label2.Text = "標的Port";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 48f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label3.Location = new global::System.Drawing.Point(133, 270);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(353, 64);
			this.label3.TabIndex = 2;
			this.label3.Text = "送信データ";
			this.iptxt.Font = new global::System.Drawing.Font("MS UI Gothic", 27.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.iptxt.Location = new global::System.Drawing.Point(554, 107);
			this.iptxt.Name = "iptxt";
			this.iptxt.Size = new global::System.Drawing.Size(292, 44);
			this.iptxt.TabIndex = 3;
			this.porttxt.Font = new global::System.Drawing.Font("MS UI Gothic", 27.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.porttxt.Location = new global::System.Drawing.Point(554, 187);
			this.porttxt.Name = "porttxt";
			this.porttxt.Size = new global::System.Drawing.Size(199, 44);
			this.porttxt.TabIndex = 4;
			this.datatxt.Font = new global::System.Drawing.Font("MS UI Gothic", 27.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.datatxt.Location = new global::System.Drawing.Point(554, 270);
			this.datatxt.Multiline = true;
			this.datatxt.Name = "datatxt";
			this.datatxt.Size = new global::System.Drawing.Size(510, 297);
			this.datatxt.TabIndex = 5;
			this.button1.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 72f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.button1.ForeColor = global::System.Drawing.Color.Red;
			this.button1.Location = new global::System.Drawing.Point(12, 442);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(268, 125);
			this.button1.TabIndex = 6;
			this.button1.Text = "攻撃";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.timer1.Interval = 1;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.button2.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 72f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.button2.ForeColor = global::System.Drawing.Color.Red;
			this.button2.Location = new global::System.Drawing.Point(280, 442);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(268, 125);
			this.button2.TabIndex = 7;
			this.button2.Text = "停止";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 18f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.linkLabel1.Location = new global::System.Drawing.Point(140, 9);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new global::System.Drawing.Size(283, 24);
			this.linkLabel1.TabIndex = 8;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "supported by JUN-SUZU";
			this.linkLabel1.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1095, 627);
			base.Controls.Add(this.linkLabel1);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.datatxt);
			base.Controls.Add(this.porttxt);
			base.Controls.Add(this.iptxt);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			this.MaximumSize = new global::System.Drawing.Size(1111, 666);
			this.MinimumSize = new global::System.Drawing.Size(900, 600);
			base.Name = "Form1";
			this.Text = "Dos攻撃ツール";
			base.Load += new global::System.EventHandler(this.Form1_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000001 RID: 1
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000002 RID: 2
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.TextBox iptxt;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.TextBox porttxt;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.TextBox datatxt;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Button button2;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.LinkLabel linkLabel1;
	}
}
