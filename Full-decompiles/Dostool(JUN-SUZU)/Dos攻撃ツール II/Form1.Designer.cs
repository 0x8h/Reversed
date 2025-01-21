namespace Dos攻撃ツ\u30FCル_II
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000021E4 File Offset: 0x000003E4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000221C File Offset: 0x0000041C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Dos攻撃ツ\u30FCル_II.Form1));
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.iptxt = new global::System.Windows.Forms.TextBox();
			this.porttxt = new global::System.Windows.Forms.TextBox();
			this.datatxt = new global::System.Windows.Forms.TextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.linkLabel1 = new global::System.Windows.Forms.LinkLabel();
			this.label4 = new global::System.Windows.Forms.Label();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 36f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label2.Location = new global::System.Drawing.Point(51, 143);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(316, 48);
			this.label2.TabIndex = 1;
			this.label2.Text = "攻撃対象Port";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 36f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label3.Location = new global::System.Drawing.Point(51, 225);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(265, 48);
			this.label3.TabIndex = 2;
			this.label3.Text = "送信データ";
			this.iptxt.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 36f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.iptxt.Location = new global::System.Drawing.Point(373, 69);
			this.iptxt.MaxLength = 15;
			this.iptxt.Name = "iptxt";
			this.iptxt.Size = new global::System.Drawing.Size(392, 55);
			this.iptxt.TabIndex = 3;
			this.porttxt.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 36f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.porttxt.Location = new global::System.Drawing.Point(373, 143);
			this.porttxt.MaxLength = 5;
			this.porttxt.Name = "porttxt";
			this.porttxt.Size = new global::System.Drawing.Size(156, 55);
			this.porttxt.TabIndex = 4;
			this.datatxt.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 24f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.datatxt.Location = new global::System.Drawing.Point(373, 225);
			this.datatxt.MaxLength = 0;
			this.datatxt.Multiline = true;
			this.datatxt.Name = "datatxt";
			this.datatxt.Size = new global::System.Drawing.Size(618, 186);
			this.datatxt.TabIndex = 5;
			this.datatxt.TextChanged += new global::System.EventHandler(this.textBox3_TextChanged);
			this.button1.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 48f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.button1.ForeColor = global::System.Drawing.Color.Red;
			this.button1.Location = new global::System.Drawing.Point(13, 433);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(304, 146);
			this.button1.TabIndex = 6;
			this.button1.Text = "攻撃開始";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Font = new global::System.Drawing.Font("MS UI Gothic", 15.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.linkLabel1.Location = new global::System.Drawing.Point(59, 13);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new global::System.Drawing.Size(517, 21);
			this.linkLabel1.TabIndex = 8;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "This tool is supported by JUN-SUZU. Let's Check Update.";
			this.linkLabel1.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			this.label4.AutoSize = true;
			this.label4.BackColor = global::System.Drawing.Color.FromArgb(190, 255, 0, 0);
			this.label4.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 72f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label4.Location = new global::System.Drawing.Point(649, 446);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(333, 97);
			this.label4.TabIndex = 9;
			this.label4.Text = "未攻撃";
			this.timer1.Interval = 1;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("ＭＳ ゴシック", 36f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 128);
			this.label1.Location = new global::System.Drawing.Point(51, 69);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(266, 48);
			this.label1.TabIndex = 0;
			this.label1.Text = "攻撃対象IP";
			this.label1.Click += new global::System.EventHandler(this.label1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(173, 255, 225);
			base.ClientSize = new global::System.Drawing.Size(1064, 681);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.linkLabel1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.datatxt);
			base.Controls.Add(this.porttxt);
			base.Controls.Add(this.iptxt);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			this.MaximumSize = new global::System.Drawing.Size(1920, 1080);
			this.MinimumSize = new global::System.Drawing.Size(1000, 640);
			base.Name = "Form1";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Dos攻撃ツール ll";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000002 RID: 2
		private global::System.ComponentModel.IContainer components = null;

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
		private global::System.Windows.Forms.LinkLabel linkLabel1;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Label label1;
	}
}
