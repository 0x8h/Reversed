namespace Clock
{
	// Token: 0x0200004D RID: 77
	public partial class ReportWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06000865 RID: 2149 RVA: 0x000601E7 File Offset: 0x0005E3E7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x00060208 File Offset: 0x0005E408
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.ReportWindow));
			this.textBoxGrade = new global::System.Windows.Forms.TextBox();
			this.textBoxClass = new global::System.Windows.Forms.TextBox();
			this.textBoxNumber = new global::System.Windows.Forms.TextBox();
			this.textBoxName = new global::System.Windows.Forms.TextBox();
			this.textBoxComment = new global::System.Windows.Forms.TextBox();
			this.labelGrade = new global::System.Windows.Forms.Label();
			this.labelClass = new global::System.Windows.Forms.Label();
			this.labelNumber = new global::System.Windows.Forms.Label();
			this.labelName = new global::System.Windows.Forms.Label();
			this.labelComment = new global::System.Windows.Forms.Label();
			this.labelPreview = new global::System.Windows.Forms.Label();
			this.pictureBoxButtonPrint = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonSave = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonCancel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxPreview = new global::System.Windows.Forms.PictureBox();
			this.panelPreview = new global::System.Windows.Forms.Panel();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
			this.ファイルFToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.印刷ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.名前を付けて保存ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.終了XToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.pictureBoxButtonBack = new global::System.Windows.Forms.PictureBox();
			this.labelZoom = new global::System.Windows.Forms.Label();
			this.labelZoomIn = new global::System.Windows.Forms.Label();
			this.labelZoomOut = new global::System.Windows.Forms.Label();
			this.pictureBoxButtonNext = new global::System.Windows.Forms.PictureBox();
			this.labelPage = new global::System.Windows.Forms.Label();
			this.pageDownButton = new global::System.Windows.Forms.Label();
			this.nowPage = new global::System.Windows.Forms.Label();
			this.labelPageSlash = new global::System.Windows.Forms.Label();
			this.maxPage = new global::System.Windows.Forms.Label();
			this.pageUpButton = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonPrint).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonSave).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPreview).BeginInit();
			this.panelPreview.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			this.menuStrip1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonBack).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNext).BeginInit();
			base.SuspendLayout();
			this.textBoxGrade.Location = new global::System.Drawing.Point(50, 32);
			this.textBoxGrade.MaxLength = 2;
			this.textBoxGrade.Name = "textBoxGrade";
			this.textBoxGrade.Size = new global::System.Drawing.Size(30, 19);
			this.textBoxGrade.TabIndex = 0;
			this.textBoxGrade.TextChanged += new global::System.EventHandler(this.textBoxGrade_TextChanged);
			this.textBoxClass.Location = new global::System.Drawing.Point(112, 32);
			this.textBoxClass.MaxLength = 2;
			this.textBoxClass.Name = "textBoxClass";
			this.textBoxClass.Size = new global::System.Drawing.Size(30, 19);
			this.textBoxClass.TabIndex = 1;
			this.textBoxClass.TextChanged += new global::System.EventHandler(this.textBoxClass_TextChanged);
			this.textBoxNumber.Location = new global::System.Drawing.Point(177, 32);
			this.textBoxNumber.MaxLength = 2;
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.Size = new global::System.Drawing.Size(30, 19);
			this.textBoxNumber.TabIndex = 2;
			this.textBoxNumber.TextChanged += new global::System.EventHandler(this.textBoxNumber_TextChanged);
			this.textBoxName.Location = new global::System.Drawing.Point(305, 32);
			this.textBoxName.MaxLength = 15;
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new global::System.Drawing.Size(185, 19);
			this.textBoxName.TabIndex = 3;
			this.textBoxName.TextChanged += new global::System.EventHandler(this.textBoxName_TextChanged);
			this.textBoxComment.Font = new global::System.Drawing.Font("MS UI Gothic", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.textBoxComment.Location = new global::System.Drawing.Point(50, 79);
			this.textBoxComment.MaxLength = 385;
			this.textBoxComment.Multiline = true;
			this.textBoxComment.Name = "textBoxComment";
			this.textBoxComment.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxComment.Size = new global::System.Drawing.Size(455, 166);
			this.textBoxComment.TabIndex = 4;
			this.textBoxComment.WordWrap = false;
			this.textBoxComment.TextChanged += new global::System.EventHandler(this.textBoxComment_TextChanged);
			this.textBoxComment.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.textBoxComment_KeyUp);
			this.labelGrade.AutoSize = true;
			this.labelGrade.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelGrade.Location = new global::System.Drawing.Point(86, 32);
			this.labelGrade.Name = "labelGrade";
			this.labelGrade.Size = new global::System.Drawing.Size(20, 18);
			this.labelGrade.TabIndex = 5;
			this.labelGrade.Text = "年";
			this.labelClass.AutoSize = true;
			this.labelClass.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelClass.Location = new global::System.Drawing.Point(150, 32);
			this.labelClass.Name = "labelClass";
			this.labelClass.Size = new global::System.Drawing.Size(20, 18);
			this.labelClass.TabIndex = 6;
			this.labelClass.Text = "組";
			this.labelNumber.AutoSize = true;
			this.labelNumber.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelNumber.Location = new global::System.Drawing.Point(214, 32);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new global::System.Drawing.Size(20, 18);
			this.labelNumber.TabIndex = 7;
			this.labelNumber.Text = "番";
			this.labelName.AutoSize = true;
			this.labelName.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelName.Location = new global::System.Drawing.Point(267, 32);
			this.labelName.Name = "labelName";
			this.labelName.Size = new global::System.Drawing.Size(32, 18);
			this.labelName.TabIndex = 8;
			this.labelName.Text = "名前";
			this.labelComment.AutoSize = true;
			this.labelComment.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelComment.Location = new global::System.Drawing.Point(24, 58);
			this.labelComment.Name = "labelComment";
			this.labelComment.Size = new global::System.Drawing.Size(56, 18);
			this.labelComment.TabIndex = 9;
			this.labelComment.Text = "コメント";
			this.labelPreview.AutoSize = true;
			this.labelPreview.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelPreview.Location = new global::System.Drawing.Point(24, 11);
			this.labelPreview.Name = "labelPreview";
			this.labelPreview.Size = new global::System.Drawing.Size(68, 18);
			this.labelPreview.TabIndex = 10;
			this.labelPreview.Text = "プレビュー";
			this.pictureBoxButtonPrint.Image = global::Clock.Properties.Resources.popup_btn_050;
			this.pictureBoxButtonPrint.Location = new global::System.Drawing.Point(228, 646);
			this.pictureBoxButtonPrint.Name = "pictureBoxButtonPrint";
			this.pictureBoxButtonPrint.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonPrint.TabIndex = 13;
			this.pictureBoxButtonPrint.TabStop = false;
			this.pictureBoxButtonPrint.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonPrint_MouseDown);
			this.pictureBoxButtonPrint.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonPrint_MouseEnter);
			this.pictureBoxButtonPrint.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonPrint_MouseLeave);
			this.pictureBoxButtonPrint.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonPrint_MouseUp);
			this.pictureBoxButtonSave.Image = global::Clock.Properties.Resources.popup_btn_060;
			this.pictureBoxButtonSave.Location = new global::System.Drawing.Point(335, 646);
			this.pictureBoxButtonSave.Name = "pictureBoxButtonSave";
			this.pictureBoxButtonSave.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonSave.TabIndex = 11;
			this.pictureBoxButtonSave.TabStop = false;
			this.pictureBoxButtonSave.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonSave_MouseDown);
			this.pictureBoxButtonSave.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonSave_MouseEnter);
			this.pictureBoxButtonSave.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonSave_MouseLeave);
			this.pictureBoxButtonSave.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonSave_MouseUp);
			this.pictureBoxButtonCancel.Image = global::Clock.Properties.Resources.popup_btn_010;
			this.pictureBoxButtonCancel.Location = new global::System.Drawing.Point(442, 256);
			this.pictureBoxButtonCancel.Name = "pictureBoxButtonCancel";
			this.pictureBoxButtonCancel.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonCancel.TabIndex = 12;
			this.pictureBoxButtonCancel.TabStop = false;
			this.pictureBoxButtonCancel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseDown);
			this.pictureBoxButtonCancel.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseEnter);
			this.pictureBoxButtonCancel.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonCancel_MouseLeave);
			this.pictureBoxButtonCancel.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonCancel_MouseUp);
			this.pictureBoxPreview.BackColor = global::System.Drawing.Color.White;
			this.pictureBoxPreview.Location = new global::System.Drawing.Point(0, 0);
			this.pictureBoxPreview.Name = "pictureBoxPreview";
			this.pictureBoxPreview.Size = new global::System.Drawing.Size(455, 607);
			this.pictureBoxPreview.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxPreview.TabIndex = 14;
			this.pictureBoxPreview.TabStop = false;
			this.panelPreview.AutoScroll = true;
			this.panelPreview.Controls.Add(this.pictureBoxPreview);
			this.panelPreview.Location = new global::System.Drawing.Point(50, 31);
			this.panelPreview.Name = "panelPreview";
			this.panelPreview.Size = new global::System.Drawing.Size(455, 607);
			this.panelPreview.TabIndex = 15;
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxObi);
			this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonBack);
			this.splitContainer1.Panel2.Controls.Add(this.labelZoom);
			this.splitContainer1.Panel2.Controls.Add(this.labelZoomIn);
			this.splitContainer1.Panel2.Controls.Add(this.labelZoomOut);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonNext);
			this.splitContainer1.Panel2.Controls.Add(this.labelPage);
			this.splitContainer1.Panel2.Controls.Add(this.pageDownButton);
			this.splitContainer1.Panel2.Controls.Add(this.nowPage);
			this.splitContainer1.Panel2.Controls.Add(this.labelPageSlash);
			this.splitContainer1.Panel2.Controls.Add(this.maxPage);
			this.splitContainer1.Panel2.Controls.Add(this.pageUpButton);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonPrint);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonSave);
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxButtonCancel);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxName);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxGrade);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxClass);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxNumber);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxComment);
			this.splitContainer1.Panel2.Controls.Add(this.labelPreview);
			this.splitContainer1.Panel2.Controls.Add(this.labelGrade);
			this.splitContainer1.Panel2.Controls.Add(this.labelComment);
			this.splitContainer1.Panel2.Controls.Add(this.labelClass);
			this.splitContainer1.Panel2.Controls.Add(this.labelName);
			this.splitContainer1.Panel2.Controls.Add(this.labelNumber);
			this.splitContainer1.Panel2.Controls.Add(this.panelPreview);
			this.splitContainer1.Size = new global::System.Drawing.Size(557, 736);
			this.splitContainer1.SplitterDistance = 36;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 16;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.popup_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(451, 24);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(106, 12);
			this.pictureBoxObi.TabIndex = 2;
			this.pictureBoxObi.TabStop = false;
			this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.ファイルFToolStripMenuItem });
			this.menuStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new global::System.Drawing.Size(557, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.印刷ToolStripMenuItem, this.名前を付けて保存ToolStripMenuItem, this.終了XToolStripMenuItem });
			this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
			this.ファイルFToolStripMenuItem.Size = new global::System.Drawing.Size(67, 20);
			this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
			this.印刷ToolStripMenuItem.Name = "印刷ToolStripMenuItem";
			this.印刷ToolStripMenuItem.Size = new global::System.Drawing.Size(186, 22);
			this.印刷ToolStripMenuItem.Text = "印刷(&P)";
			this.印刷ToolStripMenuItem.Click += new global::System.EventHandler(this.印刷ToolStripMenuItem_Click);
			this.名前を付けて保存ToolStripMenuItem.Name = "名前を付けて保存ToolStripMenuItem";
			this.名前を付けて保存ToolStripMenuItem.Size = new global::System.Drawing.Size(186, 22);
			this.名前を付けて保存ToolStripMenuItem.Text = "名前を付けて保存(&A)...";
			this.名前を付けて保存ToolStripMenuItem.Click += new global::System.EventHandler(this.名前を付けて保存ToolStripMenuItem_Click);
			this.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem";
			this.終了XToolStripMenuItem.Size = new global::System.Drawing.Size(186, 22);
			this.終了XToolStripMenuItem.Text = "終了(&X)";
			this.終了XToolStripMenuItem.Click += new global::System.EventHandler(this.終了XToolStripMenuItem_Click);
			this.pictureBoxButtonBack.Image = global::Clock.Properties.Resources.popup_btn_100;
			this.pictureBoxButtonBack.Location = new global::System.Drawing.Point(442, 646);
			this.pictureBoxButtonBack.Name = "pictureBoxButtonBack";
			this.pictureBoxButtonBack.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonBack.TabIndex = 28;
			this.pictureBoxButtonBack.TabStop = false;
			this.pictureBoxButtonBack.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonBack_MouseDown);
			this.pictureBoxButtonBack.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonBack_MouseEnter);
			this.pictureBoxButtonBack.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonBack_MouseLeave);
			this.pictureBoxButtonBack.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonBack_MouseUp);
			this.labelZoom.AutoSize = true;
			this.labelZoom.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelZoom.Location = new global::System.Drawing.Point(513, 346);
			this.labelZoom.Name = "labelZoom";
			this.labelZoom.Size = new global::System.Drawing.Size(41, 18);
			this.labelZoom.TabIndex = 27;
			this.labelZoom.Text = "100%";
			this.labelZoomIn.AutoSize = true;
			this.labelZoomIn.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelZoomIn.Location = new global::System.Drawing.Point(523, 321);
			this.labelZoomIn.Name = "labelZoomIn";
			this.labelZoomIn.Size = new global::System.Drawing.Size(20, 18);
			this.labelZoomIn.TabIndex = 25;
			this.labelZoomIn.Text = "▲";
			this.labelZoomIn.Click += new global::System.EventHandler(this.labelZoomIn_Click);
			this.labelZoomOut.AutoSize = true;
			this.labelZoomOut.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelZoomOut.Location = new global::System.Drawing.Point(523, 374);
			this.labelZoomOut.Name = "labelZoomOut";
			this.labelZoomOut.Size = new global::System.Drawing.Size(20, 18);
			this.labelZoomOut.TabIndex = 26;
			this.labelZoomOut.Text = "▼";
			this.labelZoomOut.Click += new global::System.EventHandler(this.labelZoomOut_Click);
			this.pictureBoxButtonNext.Image = global::Clock.Properties.Resources.popup_btn_090;
			this.pictureBoxButtonNext.Location = new global::System.Drawing.Point(335, 256);
			this.pictureBoxButtonNext.Name = "pictureBoxButtonNext";
			this.pictureBoxButtonNext.Size = new global::System.Drawing.Size(101, 40);
			this.pictureBoxButtonNext.TabIndex = 24;
			this.pictureBoxButtonNext.TabStop = false;
			this.pictureBoxButtonNext.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNext_MouseDown);
			this.pictureBoxButtonNext.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonNext_MouseEnter);
			this.pictureBoxButtonNext.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonNext_MouseLeave);
			this.pictureBoxButtonNext.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNext_MouseUp);
			this.labelPage.AutoSize = true;
			this.labelPage.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelPage.Location = new global::System.Drawing.Point(33, 646);
			this.labelPage.Name = "labelPage";
			this.labelPage.Size = new global::System.Drawing.Size(44, 18);
			this.labelPage.TabIndex = 16;
			this.labelPage.Text = "ページ";
			this.pageDownButton.AutoSize = true;
			this.pageDownButton.Enabled = false;
			this.pageDownButton.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.pageDownButton.Location = new global::System.Drawing.Point(83, 646);
			this.pageDownButton.Name = "pageDownButton";
			this.pageDownButton.Size = new global::System.Drawing.Size(20, 18);
			this.pageDownButton.TabIndex = 17;
			this.pageDownButton.Text = "◀";
			this.pageDownButton.Click += new global::System.EventHandler(this.pageDownButton_Click);
			this.nowPage.AutoSize = true;
			this.nowPage.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.nowPage.Location = new global::System.Drawing.Point(109, 646);
			this.nowPage.Name = "nowPage";
			this.nowPage.Size = new global::System.Drawing.Size(15, 18);
			this.nowPage.TabIndex = 18;
			this.nowPage.Text = "1";
			this.labelPageSlash.AutoSize = true;
			this.labelPageSlash.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelPageSlash.Location = new global::System.Drawing.Point(130, 646);
			this.labelPageSlash.Name = "labelPageSlash";
			this.labelPageSlash.Size = new global::System.Drawing.Size(20, 18);
			this.labelPageSlash.TabIndex = 19;
			this.labelPageSlash.Text = "／";
			this.maxPage.AutoSize = true;
			this.maxPage.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.maxPage.Location = new global::System.Drawing.Point(156, 646);
			this.maxPage.Name = "maxPage";
			this.maxPage.Size = new global::System.Drawing.Size(15, 18);
			this.maxPage.TabIndex = 20;
			this.maxPage.Text = "1";
			this.pageUpButton.AutoSize = true;
			this.pageUpButton.Enabled = false;
			this.pageUpButton.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.pageUpButton.Location = new global::System.Drawing.Point(177, 646);
			this.pageUpButton.Name = "pageUpButton";
			this.pageUpButton.Size = new global::System.Drawing.Size(20, 18);
			this.pageUpButton.TabIndex = 21;
			this.pageUpButton.Text = "▶";
			this.pageUpButton.Click += new global::System.EventHandler(this.pageUpButton_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(557, 736);
			base.Controls.Add(this.splitContainer1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.menuStrip1;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ReportWindow";
			this.Text = "レポート作成";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.ReportWindow_FormClosed);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonPrint).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonSave).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonCancel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPreview).EndInit();
			this.panelPreview.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonBack).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNext).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000614 RID: 1556
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000615 RID: 1557
		private global::System.Windows.Forms.TextBox textBoxGrade;

		// Token: 0x04000616 RID: 1558
		private global::System.Windows.Forms.TextBox textBoxClass;

		// Token: 0x04000617 RID: 1559
		private global::System.Windows.Forms.TextBox textBoxNumber;

		// Token: 0x04000618 RID: 1560
		private global::System.Windows.Forms.TextBox textBoxName;

		// Token: 0x04000619 RID: 1561
		private global::System.Windows.Forms.TextBox textBoxComment;

		// Token: 0x0400061A RID: 1562
		private global::System.Windows.Forms.Label labelGrade;

		// Token: 0x0400061B RID: 1563
		private global::System.Windows.Forms.Label labelClass;

		// Token: 0x0400061C RID: 1564
		private global::System.Windows.Forms.Label labelNumber;

		// Token: 0x0400061D RID: 1565
		private global::System.Windows.Forms.Label labelName;

		// Token: 0x0400061E RID: 1566
		private global::System.Windows.Forms.Label labelComment;

		// Token: 0x0400061F RID: 1567
		private global::System.Windows.Forms.Label labelPreview;

		// Token: 0x04000620 RID: 1568
		private global::System.Windows.Forms.PictureBox pictureBoxButtonSave;

		// Token: 0x04000621 RID: 1569
		private global::System.Windows.Forms.PictureBox pictureBoxButtonCancel;

		// Token: 0x04000622 RID: 1570
		private global::System.Windows.Forms.PictureBox pictureBoxButtonPrint;

		// Token: 0x04000623 RID: 1571
		private global::System.Windows.Forms.PictureBox pictureBoxPreview;

		// Token: 0x04000624 RID: 1572
		private global::System.Windows.Forms.Panel panelPreview;

		// Token: 0x04000625 RID: 1573
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000626 RID: 1574
		private global::System.Windows.Forms.PictureBox pictureBoxObi;

		// Token: 0x04000627 RID: 1575
		private global::System.Windows.Forms.Label labelPage;

		// Token: 0x04000628 RID: 1576
		private global::System.Windows.Forms.Label pageUpButton;

		// Token: 0x04000629 RID: 1577
		private global::System.Windows.Forms.Label maxPage;

		// Token: 0x0400062A RID: 1578
		private global::System.Windows.Forms.Label labelPageSlash;

		// Token: 0x0400062B RID: 1579
		private global::System.Windows.Forms.Label nowPage;

		// Token: 0x0400062C RID: 1580
		private global::System.Windows.Forms.Label pageDownButton;

		// Token: 0x0400062D RID: 1581
		private global::System.Windows.Forms.MenuStrip menuStrip1;

		// Token: 0x0400062E RID: 1582
		private global::System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;

		// Token: 0x0400062F RID: 1583
		private global::System.Windows.Forms.ToolStripMenuItem 印刷ToolStripMenuItem;

		// Token: 0x04000630 RID: 1584
		private global::System.Windows.Forms.ToolStripMenuItem 名前を付けて保存ToolStripMenuItem;

		// Token: 0x04000631 RID: 1585
		private global::System.Windows.Forms.ToolStripMenuItem 終了XToolStripMenuItem;

		// Token: 0x04000632 RID: 1586
		private global::System.Windows.Forms.PictureBox pictureBoxButtonNext;

		// Token: 0x04000633 RID: 1587
		private global::System.Windows.Forms.Label labelZoom;

		// Token: 0x04000634 RID: 1588
		private global::System.Windows.Forms.Label labelZoomIn;

		// Token: 0x04000635 RID: 1589
		private global::System.Windows.Forms.Label labelZoomOut;

		// Token: 0x04000636 RID: 1590
		private global::System.Windows.Forms.PictureBox pictureBoxButtonBack;
	}
}
