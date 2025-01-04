namespace DebugInjector
{
	// Token: 0x02000002 RID: 2
	public partial class DebugInjectorMain : global::System.Windows.Forms.Form
	{
		// Token: 0x06000029 RID: 41 RVA: 0x000039AC File Offset: 0x00001BAC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000039E4 File Offset: 0x00001BE4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::DebugInjector.DebugInjectorMain));
			this.inject = new global::System.Windows.Forms.Button();
			this.ps = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.check = new global::System.Windows.Forms.CheckBox();
			this.toolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.button1 = new global::System.Windows.Forms.Button();
			this.addlist = new global::System.Windows.Forms.Button();
			this.openmc = new global::System.Windows.Forms.Button();
			this.closemc = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.upload = new global::System.Windows.Forms.Button();
			this.loaddllfromurl = new global::System.Windows.Forms.Button();
			this.current = new global::System.Windows.Forms.Label();
			this.status = new global::System.Windows.Forms.Label();
			this.mcstat = new global::System.Windows.Forms.Label();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.label2 = new global::System.Windows.Forms.Label();
			this.urlbox = new global::System.Windows.Forms.TextBox();
			this.button4 = new global::System.Windows.Forms.Button();
			this.toolTip2 = new global::System.Windows.Forms.ToolTip(this.components);
			base.SuspendLayout();
			this.inject.BackColor = global::System.Drawing.Color.FromArgb(65, 65, 65);
			this.inject.FlatAppearance.BorderSize = 0;
			this.inject.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.inject.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.5f);
			this.inject.ForeColor = global::System.Drawing.Color.White;
			this.inject.Location = new global::System.Drawing.Point(337, 189);
			this.inject.Margin = new global::System.Windows.Forms.Padding(2);
			this.inject.Name = "inject";
			this.inject.Size = new global::System.Drawing.Size(95, 40);
			this.inject.TabIndex = 0;
			this.inject.Text = "Inject Dll";
			this.toolTip1.SetToolTip(this.inject, "Right click to load dll from explorer");
			this.inject.UseVisualStyleBackColor = false;
			this.inject.Click += new global::System.EventHandler(this.inject_Click);
			this.inject.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.inject_MouseDown);
			this.ps.AutoScroll = true;
			this.ps.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.ps.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.ps.Location = new global::System.Drawing.Point(9, 40);
			this.ps.Margin = new global::System.Windows.Forms.Padding(2);
			this.ps.Name = "ps";
			this.ps.Size = new global::System.Drawing.Size(201, 254);
			this.ps.TabIndex = 1;
			this.ps.Paint += new global::System.Windows.Forms.PaintEventHandler(this.ps_Paint);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(9, 16);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(71, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Dll paths";
			this.check.AutoSize = true;
			this.check.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f);
			this.check.ForeColor = global::System.Drawing.Color.White;
			this.check.Location = new global::System.Drawing.Point(236, 242);
			this.check.Margin = new global::System.Windows.Forms.Padding(2);
			this.check.Name = "check";
			this.check.Size = new global::System.Drawing.Size(103, 21);
			this.check.TabIndex = 3;
			this.check.Text = "Inject Check";
			this.check.UseVisualStyleBackColor = true;
			this.toolTip1.ToolTipTitle = "SulfurDev";
			this.button1.BackColor = global::System.Drawing.Color.FromArgb(65, 65, 65);
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.5f);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(448, 189);
			this.button1.Margin = new global::System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(79, 40);
			this.button1.TabIndex = 6;
			this.button1.Text = "Save Data";
			this.toolTip1.SetToolTip(this.button1, "Save current dll path lists");
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.addlist.BackColor = global::System.Drawing.Color.FromArgb(65, 65, 65);
			this.addlist.FlatAppearance.BorderSize = 0;
			this.addlist.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.addlist.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.5f);
			this.addlist.ForeColor = global::System.Drawing.Color.White;
			this.addlist.Location = new global::System.Drawing.Point(448, 141);
			this.addlist.Margin = new global::System.Windows.Forms.Padding(2);
			this.addlist.Name = "addlist";
			this.addlist.Size = new global::System.Drawing.Size(79, 40);
			this.addlist.TabIndex = 7;
			this.addlist.Text = "Add to List";
			this.toolTip1.SetToolTip(this.addlist, "Right click to add dll from explorer");
			this.addlist.UseVisualStyleBackColor = false;
			this.addlist.Click += new global::System.EventHandler(this.addlist_Click);
			this.addlist.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.addlist_MouseUp);
			this.openmc.BackColor = global::System.Drawing.Color.FromArgb(65, 65, 65);
			this.openmc.FlatAppearance.BorderSize = 0;
			this.openmc.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.openmc.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.5f);
			this.openmc.ForeColor = global::System.Drawing.Color.White;
			this.openmc.Location = new global::System.Drawing.Point(447, 93);
			this.openmc.Margin = new global::System.Windows.Forms.Padding(2);
			this.openmc.Name = "openmc";
			this.openmc.Size = new global::System.Drawing.Size(79, 40);
			this.openmc.TabIndex = 9;
			this.openmc.Text = "Open MC";
			this.toolTip1.SetToolTip(this.openmc, "Open Minecraft");
			this.openmc.UseVisualStyleBackColor = false;
			this.openmc.Click += new global::System.EventHandler(this.openmc_Click);
			this.closemc.BackColor = global::System.Drawing.Color.FromArgb(65, 65, 65);
			this.closemc.FlatAppearance.BorderSize = 0;
			this.closemc.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.closemc.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.5f);
			this.closemc.ForeColor = global::System.Drawing.Color.White;
			this.closemc.Location = new global::System.Drawing.Point(448, 46);
			this.closemc.Margin = new global::System.Windows.Forms.Padding(2);
			this.closemc.Name = "closemc";
			this.closemc.Size = new global::System.Drawing.Size(79, 40);
			this.closemc.TabIndex = 10;
			this.closemc.Text = "Kill MC";
			this.toolTip1.SetToolTip(this.closemc, "Close Minecraft");
			this.closemc.UseVisualStyleBackColor = false;
			this.closemc.Click += new global::System.EventHandler(this.closemc_Click);
			this.button2.BackColor = global::System.Drawing.Color.FromArgb(65, 65, 65);
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.5f);
			this.button2.ForeColor = global::System.Drawing.Color.White;
			this.button2.Location = new global::System.Drawing.Point(236, 189);
			this.button2.Margin = new global::System.Windows.Forms.Padding(2);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(95, 40);
			this.button2.TabIndex = 11;
			this.button2.Text = "Uninject Dll";
			this.toolTip1.SetToolTip(this.button2, "Not working :rage:");
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button3.BackColor = global::System.Drawing.Color.FromArgb(65, 65, 65);
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.5f);
			this.button3.ForeColor = global::System.Drawing.Color.White;
			this.button3.Location = new global::System.Drawing.Point(236, 93);
			this.button3.Margin = new global::System.Windows.Forms.Padding(2);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(196, 40);
			this.button3.TabIndex = 12;
			this.button3.Text = "Open Roaming Folder";
			this.toolTip1.SetToolTip(this.button3, "Open RoamingState folder");
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.upload.BackColor = global::System.Drawing.Color.FromArgb(65, 65, 65);
			this.upload.FlatAppearance.BorderSize = 0;
			this.upload.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.upload.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.5f);
			this.upload.ForeColor = global::System.Drawing.Color.White;
			this.upload.Location = new global::System.Drawing.Point(236, 141);
			this.upload.Margin = new global::System.Windows.Forms.Padding(2);
			this.upload.Name = "upload";
			this.upload.Size = new global::System.Drawing.Size(196, 40);
			this.upload.TabIndex = 13;
			this.upload.Text = "Upload dll in GoFile.io";
			this.toolTip1.SetToolTip(this.upload, "Upload current dll file in GoFile");
			this.upload.UseVisualStyleBackColor = false;
			this.upload.Click += new global::System.EventHandler(this.upload_Click);
			this.loaddllfromurl.BackColor = global::System.Drawing.Color.FromArgb(65, 65, 65);
			this.loaddllfromurl.FlatAppearance.BorderSize = 0;
			this.loaddllfromurl.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.loaddllfromurl.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.5f);
			this.loaddllfromurl.ForeColor = global::System.Drawing.Color.White;
			this.loaddllfromurl.Location = new global::System.Drawing.Point(439, 298);
			this.loaddllfromurl.Margin = new global::System.Windows.Forms.Padding(2);
			this.loaddllfromurl.Name = "loaddllfromurl";
			this.loaddllfromurl.Size = new global::System.Drawing.Size(95, 40);
			this.loaddllfromurl.TabIndex = 15;
			this.loaddllfromurl.Text = "Load";
			this.toolTip1.SetToolTip(this.loaddllfromurl, "Right click to save in local");
			this.loaddllfromurl.UseVisualStyleBackColor = false;
			this.loaddllfromurl.Click += new global::System.EventHandler(this.loaddllfromurl_Click);
			this.loaddllfromurl.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.loaddllfromurl_MouseUp);
			this.current.AutoSize = true;
			this.current.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f);
			this.current.ForeColor = global::System.Drawing.Color.White;
			this.current.Location = new global::System.Drawing.Point(232, 26);
			this.current.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.current.Name = "current";
			this.current.Size = new global::System.Drawing.Size(88, 20);
			this.current.TabIndex = 4;
			this.current.Text = "Current Dll:";
			this.status.AutoSize = true;
			this.status.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f);
			this.status.ForeColor = global::System.Drawing.Color.White;
			this.status.Location = new global::System.Drawing.Point(443, 246);
			this.status.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.status.Name = "status";
			this.status.Size = new global::System.Drawing.Size(83, 17);
			this.status.TabIndex = 5;
			this.status.Text = "Not Injected";
			this.mcstat.AutoSize = true;
			this.mcstat.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f);
			this.mcstat.ForeColor = global::System.Drawing.Color.White;
			this.mcstat.Location = new global::System.Drawing.Point(232, 55);
			this.mcstat.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.mcstat.Name = "mcstat";
			this.mcstat.Size = new global::System.Drawing.Size(169, 20);
			this.mcstat.TabIndex = 8;
			this.mcstat.Text = "Minecraft: Not Opened";
			this.timer1.Interval = 10;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(232, 274);
			this.label2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(121, 20);
			this.label2.TabIndex = 14;
			this.label2.Text = "Load dll from url";
			this.urlbox.Font = new global::System.Drawing.Font("MS UI Gothic", 8f);
			this.urlbox.Location = new global::System.Drawing.Point(236, 306);
			this.urlbox.Multiline = true;
			this.urlbox.Name = "urlbox";
			this.urlbox.Size = new global::System.Drawing.Size(190, 29);
			this.urlbox.TabIndex = 16;
			this.button4.BackColor = global::System.Drawing.Color.FromArgb(65, 65, 65);
			this.button4.FlatAppearance.BorderSize = 0;
			this.button4.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.5f);
			this.button4.ForeColor = global::System.Drawing.Color.White;
			this.button4.Location = new global::System.Drawing.Point(14, 306);
			this.button4.Margin = new global::System.Windows.Forms.Padding(2);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(196, 29);
			this.button4.TabIndex = 17;
			this.button4.Text = "Clean Temp Folder";
			this.toolTip1.SetToolTip(this.button4, "Clean Temp folder!");
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(45, 45, 45);
			base.ClientSize = new global::System.Drawing.Size(547, 349);
			base.Controls.Add(this.button4);
			base.Controls.Add(this.urlbox);
			base.Controls.Add(this.loaddllfromurl);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.upload);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.closemc);
			base.Controls.Add(this.openmc);
			base.Controls.Add(this.mcstat);
			base.Controls.Add(this.addlist);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.status);
			base.Controls.Add(this.current);
			base.Controls.Add(this.check);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ps);
			base.Controls.Add(this.inject);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(2);
			this.MaximumSize = new global::System.Drawing.Size(563, 388);
			this.MinimumSize = new global::System.Drawing.Size(563, 388);
			base.Name = "DebugInjectorMain";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Debug Injector | Made by ikakusa_";
			base.Load += new global::System.EventHandler(this.DebugInjectorMain_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000008 RID: 8
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Button inject;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Panel ps;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.CheckBox check;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Label current;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Label status;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Button addlist;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.Label mcstat;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Button openmc;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Button closemc;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Button button2;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Button button3;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Button upload;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Button loaddllfromurl;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.TextBox urlbox;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Button button4;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.ToolTip toolTip2;
	}
}
