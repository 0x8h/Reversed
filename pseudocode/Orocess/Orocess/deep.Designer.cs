// Token: 0x02000002 RID: 2
public partial class deep : global::System.Windows.Forms.Form
{
	// Token: 0x06000027 RID: 39 RVA: 0x00003154 File Offset: 0x00001354
	private void InitializeComponent()
	{
		this.icontainer_0 = global::deep.smethod_25();
		this.timer_0 = global::deep.smethod_26(this.icontainer_0);
		this.pictureBox2 = global::deep.smethod_27();
		this.timer_1 = global::deep.smethod_26(this.icontainer_0);
		this.timer_2 = global::deep.smethod_26(this.icontainer_0);
		this.timer_3 = global::deep.smethod_26(this.icontainer_0);
		this.timer_4 = global::deep.smethod_26(this.icontainer_0);
		this.timer_5 = global::deep.smethod_26(this.icontainer_0);
		global::deep.smethod_28(this.pictureBox2);
		global::deep.smethod_29(this);
		global::deep.smethod_30(this.timer_0, new global::System.EventHandler(this.method_0));
		global::deep.smethod_23(this.pictureBox2, global::Class2.Bitmap_4);
		this.pictureBox2.Location = new global::System.Drawing.Point(-1, -1);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new global::System.Drawing.Size(627, 406);
		this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox2.TabIndex = 4;
		this.pictureBox2.TabStop = false;
		this.pictureBox2.Click += new global::System.EventHandler(this.pictureBox2_Click);
		this.timer_1.Tick += new global::System.EventHandler(this.timer_1_Tick);
		this.timer_2.Tick += new global::System.EventHandler(this.timer_2_Tick);
		this.timer_3.Tick += new global::System.EventHandler(this.timer_3_Tick);
		this.timer_4.Tick += new global::System.EventHandler(this.timer_4_Tick);
		this.timer_5.Tick += new global::System.EventHandler(this.timer_5_Tick);
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(625, 404);
		base.Controls.Add(this.pictureBox2);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Name = "deep";
		base.ShowIcon = false;
		base.TopMost = true;
		base.Load += new global::System.EventHandler(this.deep_Load);
		((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
	}

	// Token: 0x04000001 RID: 1
	private global::System.ComponentModel.IContainer icontainer_0;

	// Token: 0x04000002 RID: 2
	private global::System.Windows.Forms.PictureBox pictureBox2;

	// Token: 0x04000003 RID: 3
	private global::System.Windows.Forms.Timer timer_0;

	// Token: 0x04000004 RID: 4
	private global::System.Windows.Forms.Timer timer_1;

	// Token: 0x04000005 RID: 5
	private global::System.Windows.Forms.Timer timer_2;

	// Token: 0x04000006 RID: 6
	private global::System.Windows.Forms.Timer timer_3;

	// Token: 0x04000007 RID: 7
	private global::System.Windows.Forms.Timer timer_4;

	// Token: 0x04000008 RID: 8
	private global::System.Windows.Forms.Timer timer_5;
}
