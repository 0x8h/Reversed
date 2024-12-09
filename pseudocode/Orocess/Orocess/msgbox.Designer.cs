// Token: 0x02000004 RID: 4
public partial class msgbox : global::System.Windows.Forms.Form
{
	// Token: 0x0600005D RID: 93 RVA: 0x00003680 File Offset: 0x00001880
	private void InitializeComponent()
	{
		this.icontainer_0 = global::msgbox.smethod_9();
		this.timer_0 = global::msgbox.smethod_10(this.icontainer_0);
		global::msgbox.smethod_11(this);
		global::msgbox.smethod_12(this.timer_0, new global::System.EventHandler(this.method_3));
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(10, 10);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
		base.Name = "msgbox";
		base.Opacity = 0.0;
		base.ShowIcon = false;
		base.Load += new global::System.EventHandler(this.msgbox_Load);
		base.ResumeLayout(false);
	}

	// Token: 0x0400000D RID: 13
	private global::System.ComponentModel.IContainer icontainer_0;

	// Token: 0x0400000E RID: 14
	private global::System.Windows.Forms.Timer timer_0;
}
