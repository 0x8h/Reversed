// Token: 0x0200000F RID: 15
public partial class WARNING : global::System.Windows.Forms.Form
{
	// Token: 0x0600005A RID: 90 RVA: 0x00005DCC File Offset: 0x00003FCC
	private void InitializeComponent()
	{
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::WARNING));
		this.warn = new global::System.Windows.Forms.Label();
		this.label1 = new global::System.Windows.Forms.Label();
		this.label2 = new global::System.Windows.Forms.Label();
		this.label3 = new global::System.Windows.Forms.Label();
		this.exit_btn = new global::System.Windows.Forms.Button();
		this.run_btn = new global::System.Windows.Forms.Button();
		base.SuspendLayout();
		this.warn.AutoSize = true;
		this.warn.BackColor = global::System.Drawing.Color.Transparent;
		this.warn.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
		this.warn.Cursor = global::System.Windows.Forms.Cursors.Help;
		this.warn.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.warn.ForeColor = global::System.Drawing.Color.White;
		this.warn.Location = new global::System.Drawing.Point(12, 73);
		this.warn.Name = "warn";
		this.warn.Size = new global::System.Drawing.Size(326, 106);
		this.warn.TabIndex = 0;
		this.warn.Text = componentResourceManager.GetString("warn.Text");
		this.warn.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.warn.Click += new global::System.EventHandler(this.warn_Click);
		this.label1.AutoSize = true;
		this.label1.BackColor = global::System.Drawing.Color.Transparent;
		this.label1.Font = new global::System.Drawing.Font("Arial Black", 20.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = global::System.Drawing.Color.Red;
		this.label1.Location = new global::System.Drawing.Point(84, 17);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(190, 38);
		this.label1.TabIndex = 1;
		this.label1.Text = "CLUTT6.6.6";
		this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
		this.label2.AutoSize = true;
		this.label2.BackColor = global::System.Drawing.Color.Transparent;
		this.label2.Font = new global::System.Drawing.Font("Arial Black", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 238);
		this.label2.ForeColor = global::System.Drawing.Color.Red;
		this.label2.Location = new global::System.Drawing.Point(12, 188);
		this.label2.Name = "label2";
		this.label2.Size = new global::System.Drawing.Size(166, 27);
		this.label2.TabIndex = 2;
		this.label2.Text = "ABOUT CLUTT";
		this.label3.AutoSize = true;
		this.label3.BackColor = global::System.Drawing.Color.Transparent;
		this.label3.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
		this.label3.Cursor = global::System.Windows.Forms.Cursors.Help;
		this.label3.ForeColor = global::System.Drawing.Color.White;
		this.label3.Location = new global::System.Drawing.Point(14, 220);
		this.label3.Name = "label3";
		this.label3.Size = new global::System.Drawing.Size(298, 132);
		this.label3.TabIndex = 3;
		this.label3.Text = componentResourceManager.GetString("label3.Text");
		this.exit_btn.BackColor = global::System.Drawing.Color.Transparent;
		this.exit_btn.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.exit_btn.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.exit_btn.Font = new global::System.Drawing.Font("Arial Black", 18f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 238);
		this.exit_btn.ForeColor = global::System.Drawing.Color.Red;
		this.exit_btn.Location = new global::System.Drawing.Point(14, 355);
		this.exit_btn.Name = "exit_btn";
		this.exit_btn.Size = new global::System.Drawing.Size(148, 39);
		this.exit_btn.TabIndex = 4;
		this.exit_btn.Text = "EXIT";
		this.exit_btn.UseVisualStyleBackColor = false;
		this.exit_btn.Click += new global::System.EventHandler(this.exit_btn_Click);
		this.run_btn.BackColor = global::System.Drawing.Color.Transparent;
		this.run_btn.Cursor = global::System.Windows.Forms.Cursors.Hand;
		this.run_btn.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
		this.run_btn.Font = new global::System.Drawing.Font("Arial Black", 18f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 238);
		this.run_btn.ForeColor = global::System.Drawing.Color.Red;
		this.run_btn.Location = new global::System.Drawing.Point(164, 355);
		this.run_btn.Name = "run_btn";
		this.run_btn.Size = new global::System.Drawing.Size(148, 39);
		this.run_btn.TabIndex = 5;
		this.run_btn.Text = "RUN";
		this.run_btn.UseVisualStyleBackColor = false;
		this.run_btn.Click += new global::System.EventHandler(this.run_btn_Click);
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = global::System.Drawing.Color.Red;
		this.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("$this.BackgroundImage");
		this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
		base.ClientSize = new global::System.Drawing.Size(347, 396);
		base.ControlBox = false;
		base.Controls.Add(this.run_btn);
		base.Controls.Add(this.exit_btn);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.warn);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "WARNING";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "WARNING";
		base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.WARNING_FormClosing);
		base.Load += new global::System.EventHandler(this.WARNING_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x0400006A RID: 106
	private global::System.Windows.Forms.Label warn;

	// Token: 0x0400006B RID: 107
	private global::System.Windows.Forms.Label label1;

	// Token: 0x0400006C RID: 108
	private global::System.Windows.Forms.Label label2;

	// Token: 0x0400006D RID: 109
	private global::System.Windows.Forms.Label label3;

	// Token: 0x0400006E RID: 110
	private global::System.Windows.Forms.Button exit_btn;

	// Token: 0x0400006F RID: 111
	private global::System.Windows.Forms.Button run_btn;
}
