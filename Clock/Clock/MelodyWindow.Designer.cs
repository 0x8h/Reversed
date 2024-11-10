namespace Clock
{
	// Token: 0x0200002F RID: 47
	public partial class MelodyWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06000584 RID: 1412 RVA: 0x000402ED File Offset: 0x0003E4ED
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x0004030C File Offset: 0x0003E50C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.MelodyWindow));
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxArrowRight = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxArrowLeft = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxStop = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxRun = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxInsert = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxConnection = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxReport = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxWrite = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxPaste = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxCopy = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxCut = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxRedo = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxUndo = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxSave = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxOpen = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxNew = new global::System.Windows.Forms.PictureBox();
			this.splitContainer2 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxButtonSettings = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonStop = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonPlay = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonRest = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonRest2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonRest4 = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonRest8 = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonRest16 = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonNote = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonNote2Dot = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonNote2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonNote4Dot = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonNote4 = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonNote8Dot = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonNote8 = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxButtonNote16 = new global::System.Windows.Forms.PictureBox();
			this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelUsedMemory = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelLog = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.contextMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.元に戻すUToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.やり直しRToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.切り取りTToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.コピ\u30FCCToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.貼り付けPToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.挿入IToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.削除DToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.すべて選択AToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.小節ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ファイルToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.新規作成NToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ファイルを開くOToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.上書き保存SToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.名前を付けて保存AToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.終了XToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.編集EToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.元に戻すUToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.やり直しRToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.切り取りTToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.コピ\u30FCCToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.貼り付けPToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.挿入IToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.削除DToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.すべて選択ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.書込み実行EToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.書込みWToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.読込みRToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.本体でメロディ再生BToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.本体のメロディ停止EToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.pC上でメロディ再生PToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.pC上のメロディ停止SToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.表示VToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.レポ\u30FCト作成RToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ヘルプHToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ヘルプ表示BToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.バ\u30FCジョン情報VToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowRight).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowLeft).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxStop).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxRun).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxInsert).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxConnection).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxReport).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWrite).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPaste).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCopy).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCut).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxRedo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxUndo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxSave).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxOpen).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxNew).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer2).BeginInit();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonSettings).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonStop).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonPlay).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRest).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRest2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRest4).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRest8).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRest16).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote2Dot).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote4Dot).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote4).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote8Dot).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote8).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote16).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(92, 87, 83);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxArrowRight);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxArrowLeft);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxStop);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxRun);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxInsert);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxConnection);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxReport);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxWrite);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxPaste);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxCopy);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxCut);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxRedo);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxUndo);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxSave);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxOpen);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxNew);
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
			this.splitContainer1.Size = new global::System.Drawing.Size(1008, 705);
			this.splitContainer1.SplitterDistance = 55;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 1;
			this.pictureBoxArrowRight.Image = global::Clock.Properties.Resources.icon_btn_210;
			this.pictureBoxArrowRight.Location = new global::System.Drawing.Point(951, 0);
			this.pictureBoxArrowRight.Name = "pictureBoxArrowRight";
			this.pictureBoxArrowRight.Size = new global::System.Drawing.Size(39, 54);
			this.pictureBoxArrowRight.TabIndex = 30;
			this.pictureBoxArrowRight.TabStop = false;
			this.pictureBoxArrowRight.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowRight_MouseDown);
			this.pictureBoxArrowRight.MouseEnter += new global::System.EventHandler(this.pictureBoxArrowRight_MouseEnter);
			this.pictureBoxArrowRight.MouseLeave += new global::System.EventHandler(this.pictureBoxArrowRight_MouseLeave);
			this.pictureBoxArrowRight.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowRight_MouseUp);
			this.pictureBoxArrowLeft.Image = global::Clock.Properties.Resources.icon_btn_220;
			this.pictureBoxArrowLeft.Location = new global::System.Drawing.Point(3, 0);
			this.pictureBoxArrowLeft.Name = "pictureBoxArrowLeft";
			this.pictureBoxArrowLeft.Size = new global::System.Drawing.Size(39, 54);
			this.pictureBoxArrowLeft.TabIndex = 16;
			this.pictureBoxArrowLeft.TabStop = false;
			this.pictureBoxArrowLeft.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowLeft_MouseDown);
			this.pictureBoxArrowLeft.MouseEnter += new global::System.EventHandler(this.pictureBoxArrowLeft_MouseEnter);
			this.pictureBoxArrowLeft.MouseLeave += new global::System.EventHandler(this.pictureBoxArrowLeft_MouseLeave);
			this.pictureBoxArrowLeft.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowLeft_MouseUp);
			this.pictureBoxStop.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxStop.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxStop.Image = global::Clock.Properties.Resources.icon_btn_100;
			this.pictureBoxStop.Location = new global::System.Drawing.Point(807, 5);
			this.pictureBoxStop.Name = "pictureBoxStop";
			this.pictureBoxStop.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxStop.TabIndex = 29;
			this.pictureBoxStop.TabStop = false;
			this.pictureBoxStop.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxStop_MouseDown);
			this.pictureBoxStop.MouseEnter += new global::System.EventHandler(this.pictureBoxStop_MouseEnter);
			this.pictureBoxStop.MouseLeave += new global::System.EventHandler(this.pictureBoxStop_MouseLeave);
			this.pictureBoxStop.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxStop_MouseUp);
			this.pictureBoxRun.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxRun.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxRun.Image = global::Clock.Properties.Resources.icon_btn_090;
			this.pictureBoxRun.Location = new global::System.Drawing.Point(735, 5);
			this.pictureBoxRun.Name = "pictureBoxRun";
			this.pictureBoxRun.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxRun.TabIndex = 28;
			this.pictureBoxRun.TabStop = false;
			this.pictureBoxRun.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxRun_MouseDown);
			this.pictureBoxRun.MouseEnter += new global::System.EventHandler(this.pictureBoxRun_MouseEnter);
			this.pictureBoxRun.MouseLeave += new global::System.EventHandler(this.pictureBoxRun_MouseLeave);
			this.pictureBoxRun.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxRun_MouseUp);
			this.pictureBoxInsert.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxInsert.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxInsert.Image = global::Clock.Properties.Resources.mld_btn_000;
			this.pictureBoxInsert.Location = new global::System.Drawing.Point(591, 5);
			this.pictureBoxInsert.Name = "pictureBoxInsert";
			this.pictureBoxInsert.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxInsert.TabIndex = 27;
			this.pictureBoxInsert.TabStop = false;
			this.pictureBoxInsert.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxInsert_MouseDown);
			this.pictureBoxInsert.MouseEnter += new global::System.EventHandler(this.pictureBoxInsert_MouseEnter);
			this.pictureBoxInsert.MouseLeave += new global::System.EventHandler(this.pictureBoxInsert_MouseLeave);
			this.pictureBoxInsert.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxInsert_MouseUp);
			this.pictureBoxConnection.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxConnection.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxConnection.Image = global::Clock.Properties.Resources.icon_usb_off;
			this.pictureBoxConnection.Location = new global::System.Drawing.Point(961, 10);
			this.pictureBoxConnection.Name = "pictureBoxConnection";
			this.pictureBoxConnection.Size = new global::System.Drawing.Size(32, 35);
			this.pictureBoxConnection.TabIndex = 26;
			this.pictureBoxConnection.TabStop = false;
			this.pictureBoxReport.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxReport.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxReport.Image = global::Clock.Properties.Resources.icon_btn_120;
			this.pictureBoxReport.Location = new global::System.Drawing.Point(879, 5);
			this.pictureBoxReport.Name = "pictureBoxReport";
			this.pictureBoxReport.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxReport.TabIndex = 25;
			this.pictureBoxReport.TabStop = false;
			this.pictureBoxReport.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxReport_MouseDown);
			this.pictureBoxReport.MouseEnter += new global::System.EventHandler(this.pictureBoxReport_MouseEnter);
			this.pictureBoxReport.MouseLeave += new global::System.EventHandler(this.pictureBoxReport_MouseLeave);
			this.pictureBoxReport.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxReport_MouseUp);
			this.pictureBoxWrite.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxWrite.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxWrite.Image = global::Clock.Properties.Resources.icon_btn_080;
			this.pictureBoxWrite.Location = new global::System.Drawing.Point(663, 5);
			this.pictureBoxWrite.Name = "pictureBoxWrite";
			this.pictureBoxWrite.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxWrite.TabIndex = 22;
			this.pictureBoxWrite.TabStop = false;
			this.pictureBoxWrite.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxWrite_MouseDown);
			this.pictureBoxWrite.MouseEnter += new global::System.EventHandler(this.pictureBoxWrite_MouseEnter);
			this.pictureBoxWrite.MouseLeave += new global::System.EventHandler(this.pictureBoxWrite_MouseLeave);
			this.pictureBoxWrite.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxWrite_MouseUp);
			this.pictureBoxPaste.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxPaste.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxPaste.Image = global::Clock.Properties.Resources.icon_btn_070;
			this.pictureBoxPaste.Location = new global::System.Drawing.Point(519, 5);
			this.pictureBoxPaste.Name = "pictureBoxPaste";
			this.pictureBoxPaste.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxPaste.TabIndex = 21;
			this.pictureBoxPaste.TabStop = false;
			this.pictureBoxPaste.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxPaste_MouseDown);
			this.pictureBoxPaste.MouseEnter += new global::System.EventHandler(this.pictureBoxPaste_MouseEnter);
			this.pictureBoxPaste.MouseLeave += new global::System.EventHandler(this.pictureBoxPaste_MouseLeave);
			this.pictureBoxPaste.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxPaste_MouseUp);
			this.pictureBoxCopy.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxCopy.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxCopy.Image = global::Clock.Properties.Resources.icon_btn_060;
			this.pictureBoxCopy.Location = new global::System.Drawing.Point(447, 5);
			this.pictureBoxCopy.Name = "pictureBoxCopy";
			this.pictureBoxCopy.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxCopy.TabIndex = 20;
			this.pictureBoxCopy.TabStop = false;
			this.pictureBoxCopy.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxCopy_MouseDown);
			this.pictureBoxCopy.MouseEnter += new global::System.EventHandler(this.pictureBoxCopy_MouseEnter);
			this.pictureBoxCopy.MouseLeave += new global::System.EventHandler(this.pictureBoxCopy_MouseLeave);
			this.pictureBoxCopy.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxCopy_MouseUp);
			this.pictureBoxCut.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxCut.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxCut.Image = global::Clock.Properties.Resources.icon_btn_050;
			this.pictureBoxCut.Location = new global::System.Drawing.Point(375, 5);
			this.pictureBoxCut.Name = "pictureBoxCut";
			this.pictureBoxCut.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxCut.TabIndex = 19;
			this.pictureBoxCut.TabStop = false;
			this.pictureBoxCut.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxCut_MouseDown);
			this.pictureBoxCut.MouseEnter += new global::System.EventHandler(this.pictureBoxCut_MouseEnter);
			this.pictureBoxCut.MouseLeave += new global::System.EventHandler(this.pictureBoxCut_MouseLeave);
			this.pictureBoxCut.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxCut_MouseUp);
			this.pictureBoxRedo.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxRedo.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxRedo.Image = global::Clock.Properties.Resources.icon_btn_040;
			this.pictureBoxRedo.Location = new global::System.Drawing.Point(303, 5);
			this.pictureBoxRedo.Name = "pictureBoxRedo";
			this.pictureBoxRedo.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxRedo.TabIndex = 18;
			this.pictureBoxRedo.TabStop = false;
			this.pictureBoxRedo.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxRedo_MouseDown);
			this.pictureBoxRedo.MouseEnter += new global::System.EventHandler(this.pictureBoxRedo_MouseEnter);
			this.pictureBoxRedo.MouseLeave += new global::System.EventHandler(this.pictureBoxRedo_MouseLeave);
			this.pictureBoxRedo.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxRedo_MouseUp);
			this.pictureBoxUndo.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxUndo.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxUndo.Image = global::Clock.Properties.Resources.icon_btn_030;
			this.pictureBoxUndo.Location = new global::System.Drawing.Point(231, 5);
			this.pictureBoxUndo.Name = "pictureBoxUndo";
			this.pictureBoxUndo.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxUndo.TabIndex = 17;
			this.pictureBoxUndo.TabStop = false;
			this.pictureBoxUndo.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxUndo_MouseDown);
			this.pictureBoxUndo.MouseEnter += new global::System.EventHandler(this.pictureBoxUndo_MouseEnter);
			this.pictureBoxUndo.MouseLeave += new global::System.EventHandler(this.pictureBoxUndo_MouseLeave);
			this.pictureBoxUndo.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxUndo_MouseUp);
			this.pictureBoxSave.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxSave.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxSave.Image = global::Clock.Properties.Resources.icon_btn_020;
			this.pictureBoxSave.Location = new global::System.Drawing.Point(159, 5);
			this.pictureBoxSave.Name = "pictureBoxSave";
			this.pictureBoxSave.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxSave.TabIndex = 16;
			this.pictureBoxSave.TabStop = false;
			this.pictureBoxSave.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxSave_MouseDown);
			this.pictureBoxSave.MouseEnter += new global::System.EventHandler(this.pictureBoxSave_MouseEnter);
			this.pictureBoxSave.MouseLeave += new global::System.EventHandler(this.pictureBoxSave_MouseLeave);
			this.pictureBoxSave.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxSave_MouseUp);
			this.pictureBoxOpen.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxOpen.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxOpen.Image = global::Clock.Properties.Resources.icon_btn_010;
			this.pictureBoxOpen.Location = new global::System.Drawing.Point(87, 5);
			this.pictureBoxOpen.Name = "pictureBoxOpen";
			this.pictureBoxOpen.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxOpen.TabIndex = 15;
			this.pictureBoxOpen.TabStop = false;
			this.pictureBoxOpen.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxOpen_MouseDown);
			this.pictureBoxOpen.MouseEnter += new global::System.EventHandler(this.pictureBoxOpen_MouseEnter);
			this.pictureBoxOpen.MouseLeave += new global::System.EventHandler(this.pictureBoxOpen_MouseLeave);
			this.pictureBoxOpen.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxOpen_MouseUp);
			this.pictureBoxNew.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxNew.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxNew.Image = global::Clock.Properties.Resources.icon_btn_000;
			this.pictureBoxNew.Location = new global::System.Drawing.Point(15, 5);
			this.pictureBoxNew.Name = "pictureBoxNew";
			this.pictureBoxNew.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxNew.TabIndex = 14;
			this.pictureBoxNew.TabStop = false;
			this.pictureBoxNew.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxNew_MouseDown);
			this.pictureBoxNew.MouseEnter += new global::System.EventHandler(this.pictureBoxNew_MouseEnter);
			this.pictureBoxNew.MouseLeave += new global::System.EventHandler(this.pictureBoxNew_MouseLeave);
			this.pictureBoxNew.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxNew_MouseUp);
			this.splitContainer2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer2.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer2.Panel1.AutoScroll = true;
			this.splitContainer2.Panel1.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer2.Panel2.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonSettings);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonStop);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonPlay);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonRest);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonRest2);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonRest4);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonRest8);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonRest16);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonNote);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonNote2Dot);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonNote2);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonNote4Dot);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonNote4);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonNote8Dot);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonNote8);
			this.splitContainer2.Panel2.Controls.Add(this.pictureBoxButtonNote16);
			this.splitContainer2.Size = new global::System.Drawing.Size(1008, 627);
			this.splitContainer2.SplitterDistance = 341;
			this.splitContainer2.SplitterWidth = 1;
			this.splitContainer2.TabIndex = 1;
			this.splitContainer2.TabStop = false;
			this.pictureBoxButtonSettings.Image = global::Clock.Properties.Resources.mld_btn_170;
			this.pictureBoxButtonSettings.Location = new global::System.Drawing.Point(800, 259);
			this.pictureBoxButtonSettings.Name = "pictureBoxButtonSettings";
			this.pictureBoxButtonSettings.Size = new global::System.Drawing.Size(178, 42);
			this.pictureBoxButtonSettings.TabIndex = 18;
			this.pictureBoxButtonSettings.TabStop = false;
			this.pictureBoxButtonSettings.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonSettings_MouseDown);
			this.pictureBoxButtonSettings.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonSettings_MouseEnter);
			this.pictureBoxButtonSettings.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonSettings_MouseLeave);
			this.pictureBoxButtonSettings.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonSettings_MouseUp);
			this.pictureBoxButtonStop.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonStop.Image = global::Clock.Properties.Resources.mld_btn_020;
			this.pictureBoxButtonStop.Location = new global::System.Drawing.Point(892, 204);
			this.pictureBoxButtonStop.Name = "pictureBoxButtonStop";
			this.pictureBoxButtonStop.Size = new global::System.Drawing.Size(86, 50);
			this.pictureBoxButtonStop.TabIndex = 17;
			this.pictureBoxButtonStop.TabStop = false;
			this.pictureBoxButtonStop.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonStop_MouseDown);
			this.pictureBoxButtonStop.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonStop_MouseEnter);
			this.pictureBoxButtonStop.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonStop_MouseLeave);
			this.pictureBoxButtonStop.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonStop_MouseUp);
			this.pictureBoxButtonPlay.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonPlay.Image = global::Clock.Properties.Resources.mld_btn_010;
			this.pictureBoxButtonPlay.Location = new global::System.Drawing.Point(800, 204);
			this.pictureBoxButtonPlay.Name = "pictureBoxButtonPlay";
			this.pictureBoxButtonPlay.Size = new global::System.Drawing.Size(86, 50);
			this.pictureBoxButtonPlay.TabIndex = 16;
			this.pictureBoxButtonPlay.TabStop = false;
			this.pictureBoxButtonPlay.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonPlay_MouseDown);
			this.pictureBoxButtonPlay.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonPlay_MouseEnter);
			this.pictureBoxButtonPlay.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonPlay_MouseLeave);
			this.pictureBoxButtonPlay.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonPlay_MouseUp);
			this.pictureBoxButtonRest.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonRest.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonRest.Image = global::Clock.Properties.Resources.mld_btn_150;
			this.pictureBoxButtonRest.Location = new global::System.Drawing.Point(664, 211);
			this.pictureBoxButtonRest.Name = "pictureBoxButtonRest";
			this.pictureBoxButtonRest.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonRest.TabIndex = 14;
			this.pictureBoxButtonRest.TabStop = false;
			this.pictureBoxButtonRest.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRest_MouseDown);
			this.pictureBoxButtonRest.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonRest_MouseEnter);
			this.pictureBoxButtonRest.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonRest_MouseLeave);
			this.pictureBoxButtonRest.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRest_MouseUp);
			this.pictureBoxButtonRest2.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonRest2.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonRest2.Image = global::Clock.Properties.Resources.mld_btn_140;
			this.pictureBoxButtonRest2.Location = new global::System.Drawing.Point(610, 211);
			this.pictureBoxButtonRest2.Name = "pictureBoxButtonRest2";
			this.pictureBoxButtonRest2.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonRest2.TabIndex = 13;
			this.pictureBoxButtonRest2.TabStop = false;
			this.pictureBoxButtonRest2.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRest2_MouseDown);
			this.pictureBoxButtonRest2.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonRest2_MouseEnter);
			this.pictureBoxButtonRest2.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonRest2_MouseLeave);
			this.pictureBoxButtonRest2.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRest2_MouseUp);
			this.pictureBoxButtonRest4.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonRest4.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonRest4.Image = global::Clock.Properties.Resources.mld_btn_130;
			this.pictureBoxButtonRest4.Location = new global::System.Drawing.Point(556, 211);
			this.pictureBoxButtonRest4.Name = "pictureBoxButtonRest4";
			this.pictureBoxButtonRest4.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonRest4.TabIndex = 12;
			this.pictureBoxButtonRest4.TabStop = false;
			this.pictureBoxButtonRest4.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRest4_MouseDown);
			this.pictureBoxButtonRest4.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonRest4_MouseEnter);
			this.pictureBoxButtonRest4.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonRest4_MouseLeave);
			this.pictureBoxButtonRest4.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRest4_MouseUp);
			this.pictureBoxButtonRest8.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonRest8.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonRest8.Image = global::Clock.Properties.Resources.mld_btn_120;
			this.pictureBoxButtonRest8.Location = new global::System.Drawing.Point(502, 211);
			this.pictureBoxButtonRest8.Name = "pictureBoxButtonRest8";
			this.pictureBoxButtonRest8.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonRest8.TabIndex = 11;
			this.pictureBoxButtonRest8.TabStop = false;
			this.pictureBoxButtonRest8.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRest8_MouseDown);
			this.pictureBoxButtonRest8.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonRest8_MouseEnter);
			this.pictureBoxButtonRest8.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonRest8_MouseLeave);
			this.pictureBoxButtonRest8.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRest8_MouseUp);
			this.pictureBoxButtonRest16.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonRest16.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonRest16.Image = global::Clock.Properties.Resources.mld_btn_110;
			this.pictureBoxButtonRest16.Location = new global::System.Drawing.Point(448, 211);
			this.pictureBoxButtonRest16.Name = "pictureBoxButtonRest16";
			this.pictureBoxButtonRest16.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonRest16.TabIndex = 10;
			this.pictureBoxButtonRest16.TabStop = false;
			this.pictureBoxButtonRest16.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRest16_MouseDown);
			this.pictureBoxButtonRest16.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonRest16_MouseEnter);
			this.pictureBoxButtonRest16.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonRest16_MouseLeave);
			this.pictureBoxButtonRest16.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonRest16_MouseUp);
			this.pictureBoxButtonNote.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonNote.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonNote.Image = global::Clock.Properties.Resources.mld_btn_100;
			this.pictureBoxButtonNote.Location = new global::System.Drawing.Point(387, 211);
			this.pictureBoxButtonNote.Name = "pictureBoxButtonNote";
			this.pictureBoxButtonNote.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonNote.TabIndex = 9;
			this.pictureBoxButtonNote.TabStop = false;
			this.pictureBoxButtonNote.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote_MouseDown);
			this.pictureBoxButtonNote.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonNote_MouseEnter);
			this.pictureBoxButtonNote.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonNote_MouseLeave);
			this.pictureBoxButtonNote.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote_MouseUp);
			this.pictureBoxButtonNote2Dot.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonNote2Dot.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonNote2Dot.Image = global::Clock.Properties.Resources.mld_btn_090;
			this.pictureBoxButtonNote2Dot.Location = new global::System.Drawing.Point(333, 211);
			this.pictureBoxButtonNote2Dot.Name = "pictureBoxButtonNote2Dot";
			this.pictureBoxButtonNote2Dot.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonNote2Dot.TabIndex = 8;
			this.pictureBoxButtonNote2Dot.TabStop = false;
			this.pictureBoxButtonNote2Dot.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote2Dot_MouseDown);
			this.pictureBoxButtonNote2Dot.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonNote2Dot_MouseEnter);
			this.pictureBoxButtonNote2Dot.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonNote2Dot_MouseLeave);
			this.pictureBoxButtonNote2Dot.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote2Dot_MouseUp);
			this.pictureBoxButtonNote2.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonNote2.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonNote2.Image = global::Clock.Properties.Resources.mld_btn_080;
			this.pictureBoxButtonNote2.Location = new global::System.Drawing.Point(279, 211);
			this.pictureBoxButtonNote2.Name = "pictureBoxButtonNote2";
			this.pictureBoxButtonNote2.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonNote2.TabIndex = 7;
			this.pictureBoxButtonNote2.TabStop = false;
			this.pictureBoxButtonNote2.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote2_MouseDown);
			this.pictureBoxButtonNote2.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonNote2_MouseEnter);
			this.pictureBoxButtonNote2.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonNote2_MouseLeave);
			this.pictureBoxButtonNote2.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote2_MouseUp);
			this.pictureBoxButtonNote4Dot.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonNote4Dot.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonNote4Dot.Image = global::Clock.Properties.Resources.mld_btn_070;
			this.pictureBoxButtonNote4Dot.Location = new global::System.Drawing.Point(225, 211);
			this.pictureBoxButtonNote4Dot.Name = "pictureBoxButtonNote4Dot";
			this.pictureBoxButtonNote4Dot.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonNote4Dot.TabIndex = 6;
			this.pictureBoxButtonNote4Dot.TabStop = false;
			this.pictureBoxButtonNote4Dot.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote4Dot_MouseDown);
			this.pictureBoxButtonNote4Dot.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonNote4Dot_MouseEnter);
			this.pictureBoxButtonNote4Dot.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonNote4Dot_MouseLeave);
			this.pictureBoxButtonNote4Dot.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote4Dot_MouseUp);
			this.pictureBoxButtonNote4.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonNote4.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonNote4.Image = global::Clock.Properties.Resources.mld_btn_060;
			this.pictureBoxButtonNote4.Location = new global::System.Drawing.Point(171, 211);
			this.pictureBoxButtonNote4.Name = "pictureBoxButtonNote4";
			this.pictureBoxButtonNote4.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonNote4.TabIndex = 5;
			this.pictureBoxButtonNote4.TabStop = false;
			this.pictureBoxButtonNote4.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote4_MouseDown);
			this.pictureBoxButtonNote4.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonNote4_MouseEnter);
			this.pictureBoxButtonNote4.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonNote4_MouseLeave);
			this.pictureBoxButtonNote4.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote4_MouseUp);
			this.pictureBoxButtonNote8Dot.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonNote8Dot.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonNote8Dot.Image = global::Clock.Properties.Resources.mld_btn_050;
			this.pictureBoxButtonNote8Dot.Location = new global::System.Drawing.Point(117, 211);
			this.pictureBoxButtonNote8Dot.Name = "pictureBoxButtonNote8Dot";
			this.pictureBoxButtonNote8Dot.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonNote8Dot.TabIndex = 4;
			this.pictureBoxButtonNote8Dot.TabStop = false;
			this.pictureBoxButtonNote8Dot.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote8Dot_MouseDown);
			this.pictureBoxButtonNote8Dot.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonNote8Dot_MouseEnter);
			this.pictureBoxButtonNote8Dot.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonNote8Dot_MouseLeave);
			this.pictureBoxButtonNote8Dot.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote8Dot_MouseUp);
			this.pictureBoxButtonNote8.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonNote8.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonNote8.Image = global::Clock.Properties.Resources.mld_btn_040;
			this.pictureBoxButtonNote8.Location = new global::System.Drawing.Point(63, 211);
			this.pictureBoxButtonNote8.Name = "pictureBoxButtonNote8";
			this.pictureBoxButtonNote8.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonNote8.TabIndex = 3;
			this.pictureBoxButtonNote8.TabStop = false;
			this.pictureBoxButtonNote8.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote8_MouseDown);
			this.pictureBoxButtonNote8.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonNote8_MouseEnter);
			this.pictureBoxButtonNote8.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonNote8_MouseLeave);
			this.pictureBoxButtonNote8.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote8_MouseUp);
			this.pictureBoxButtonNote16.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxButtonNote16.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxButtonNote16.Image = global::Clock.Properties.Resources.mld_btn_030;
			this.pictureBoxButtonNote16.Location = new global::System.Drawing.Point(9, 211);
			this.pictureBoxButtonNote16.Name = "pictureBoxButtonNote16";
			this.pictureBoxButtonNote16.Size = new global::System.Drawing.Size(51, 77);
			this.pictureBoxButtonNote16.TabIndex = 2;
			this.pictureBoxButtonNote16.TabStop = false;
			this.pictureBoxButtonNote16.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote16_MouseDown);
			this.pictureBoxButtonNote16.MouseEnter += new global::System.EventHandler(this.pictureBoxButtonNote16_MouseEnter);
			this.pictureBoxButtonNote16.MouseLeave += new global::System.EventHandler(this.pictureBoxButtonNote16_MouseLeave);
			this.pictureBoxButtonNote16.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxButtonNote16_MouseUp);
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.toolStripStatusLabelUsedMemory, this.toolStripStatusLabelLog });
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 627);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new global::System.Drawing.Size(1008, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripStatusLabelUsedMemory.BackColor = global::System.Drawing.SystemColors.Control;
			this.toolStripStatusLabelUsedMemory.BorderSides = global::System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.toolStripStatusLabelUsedMemory.Name = "toolStripStatusLabelUsedMemory";
			this.toolStripStatusLabelUsedMemory.Size = new global::System.Drawing.Size(4, 17);
			this.toolStripStatusLabelLog.BackColor = global::System.Drawing.SystemColors.Control;
			this.toolStripStatusLabelLog.Name = "toolStripStatusLabelLog";
			this.toolStripStatusLabelLog.Size = new global::System.Drawing.Size(49, 17);
			this.toolStripStatusLabelLog.Text = "ログ表示";
			this.contextMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.元に戻すUToolStripMenuItem1, this.やり直しRToolStripMenuItem1, this.切り取りTToolStripMenuItem1, this.コピ\u30FCCToolStripMenuItem1, this.貼り付けPToolStripMenuItem1, this.挿入IToolStripMenuItem1, this.削除DToolStripMenuItem1, this.すべて選択AToolStripMenuItem });
			this.contextMenuStrip.Name = "contextMenuStrip2";
			this.contextMenuStrip.Size = new global::System.Drawing.Size(128, 180);
			this.元に戻すUToolStripMenuItem1.Name = "元に戻すUToolStripMenuItem1";
			this.元に戻すUToolStripMenuItem1.Size = new global::System.Drawing.Size(127, 22);
			this.元に戻すUToolStripMenuItem1.Text = "元に戻す";
			this.やり直しRToolStripMenuItem1.Name = "やり直しRToolStripMenuItem1";
			this.やり直しRToolStripMenuItem1.Size = new global::System.Drawing.Size(127, 22);
			this.やり直しRToolStripMenuItem1.Text = "やり直し";
			this.切り取りTToolStripMenuItem1.Name = "切り取りTToolStripMenuItem1";
			this.切り取りTToolStripMenuItem1.Size = new global::System.Drawing.Size(127, 22);
			this.切り取りTToolStripMenuItem1.Text = "切り取り";
			this.切り取りTToolStripMenuItem1.Click += new global::System.EventHandler(this.切り取りToolStripMenuItem_Click);
			this.コピ\u30FCCToolStripMenuItem1.Name = "コピーCToolStripMenuItem1";
			this.コピ\u30FCCToolStripMenuItem1.Size = new global::System.Drawing.Size(127, 22);
			this.コピ\u30FCCToolStripMenuItem1.Text = "コピー";
			this.コピ\u30FCCToolStripMenuItem1.Click += new global::System.EventHandler(this.コピ\u30FCToolStripMenuItem_Click);
			this.貼り付けPToolStripMenuItem1.Name = "貼り付けPToolStripMenuItem1";
			this.貼り付けPToolStripMenuItem1.Size = new global::System.Drawing.Size(127, 22);
			this.貼り付けPToolStripMenuItem1.Text = "貼り付け";
			this.貼り付けPToolStripMenuItem1.Click += new global::System.EventHandler(this.貼り付けToolStripMenuItem_Click);
			this.挿入IToolStripMenuItem1.Name = "挿入IToolStripMenuItem1";
			this.挿入IToolStripMenuItem1.Size = new global::System.Drawing.Size(127, 22);
			this.挿入IToolStripMenuItem1.Text = "挿入";
			this.挿入IToolStripMenuItem1.Click += new global::System.EventHandler(this.挿入ToolStripMenuItem_Click);
			this.削除DToolStripMenuItem1.Name = "削除DToolStripMenuItem1";
			this.削除DToolStripMenuItem1.Size = new global::System.Drawing.Size(127, 22);
			this.削除DToolStripMenuItem1.Text = "削除";
			this.削除DToolStripMenuItem1.Click += new global::System.EventHandler(this.削除ToolStripMenuItem_Click);
			this.すべて選択AToolStripMenuItem.Name = "すべて選択AToolStripMenuItem";
			this.すべて選択AToolStripMenuItem.Size = new global::System.Drawing.Size(127, 22);
			this.すべて選択AToolStripMenuItem.Text = "すべて選択";
			this.すべて選択AToolStripMenuItem.Click += new global::System.EventHandler(this.すべて選択ToolStripMenuItem_Click);
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.小節ToolStripMenuItem.Checked = true;
			this.小節ToolStripMenuItem.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.小節ToolStripMenuItem.Name = "小節ToolStripMenuItem";
			this.小節ToolStripMenuItem.Size = new global::System.Drawing.Size(148, 22);
			this.小節ToolStripMenuItem.Text = "小節(&B)";
			this.小節ToolStripMenuItem.Click += new global::System.EventHandler(this.小節ToolStripMenuItem_Click);
			this.ファイルToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.新規作成NToolStripMenuItem, this.ファイルを開くOToolStripMenuItem, this.上書き保存SToolStripMenuItem, this.名前を付けて保存AToolStripMenuItem, this.終了XToolStripMenuItem });
			this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
			this.ファイルToolStripMenuItem.Size = new global::System.Drawing.Size(67, 20);
			this.ファイルToolStripMenuItem.Text = "ファイル(&F)";
			this.新規作成NToolStripMenuItem.Name = "新規作成NToolStripMenuItem";
			this.新規作成NToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.新規作成NToolStripMenuItem.Text = "新規作成(&N)";
			this.新規作成NToolStripMenuItem.Click += new global::System.EventHandler(this.新規作成ToolStripMenuItem_Click);
			this.ファイルを開くOToolStripMenuItem.Name = "ファイルを開くOToolStripMenuItem";
			this.ファイルを開くOToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.ファイルを開くOToolStripMenuItem.Text = "ファイルを開く(&O)";
			this.ファイルを開くOToolStripMenuItem.Click += new global::System.EventHandler(this.ファイルを開くToolStripMenuItem_Click);
			this.上書き保存SToolStripMenuItem.Name = "上書き保存SToolStripMenuItem";
			this.上書き保存SToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.上書き保存SToolStripMenuItem.Text = "上書き保存(&S)";
			this.上書き保存SToolStripMenuItem.Click += new global::System.EventHandler(this.上書き保存ToolStripMenuItem_Click);
			this.名前を付けて保存AToolStripMenuItem.Name = "名前を付けて保存AToolStripMenuItem";
			this.名前を付けて保存AToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.名前を付けて保存AToolStripMenuItem.Text = "名前を付けて保存(&A)";
			this.名前を付けて保存AToolStripMenuItem.Click += new global::System.EventHandler(this.名前を付けて保存ToolStripMenuItem_Click);
			this.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem";
			this.終了XToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.終了XToolStripMenuItem.Text = "終了(&X)";
			this.終了XToolStripMenuItem.Click += new global::System.EventHandler(this.終了ToolStripMenuItem_Click);
			this.編集EToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.元に戻すUToolStripMenuItem, this.やり直しRToolStripMenuItem, this.切り取りTToolStripMenuItem, this.コピ\u30FCCToolStripMenuItem, this.貼り付けPToolStripMenuItem, this.挿入IToolStripMenuItem, this.削除DToolStripMenuItem, this.すべて選択ToolStripMenuItem });
			this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
			this.編集EToolStripMenuItem.Size = new global::System.Drawing.Size(57, 20);
			this.編集EToolStripMenuItem.Text = "編集(&E)";
			this.元に戻すUToolStripMenuItem.Name = "元に戻すUToolStripMenuItem";
			this.元に戻すUToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131162;
			this.元に戻すUToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.元に戻すUToolStripMenuItem.Text = "元に戻す(&U)";
			this.元に戻すUToolStripMenuItem.Click += new global::System.EventHandler(this.元に戻すToolStripMenuItem_Click);
			this.やり直しRToolStripMenuItem.Name = "やり直しRToolStripMenuItem";
			this.やり直しRToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131161;
			this.やり直しRToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.やり直しRToolStripMenuItem.Text = "やり直し(&R)";
			this.やり直しRToolStripMenuItem.Click += new global::System.EventHandler(this.やり直すToolStripMenuItem_Click);
			this.切り取りTToolStripMenuItem.Name = "切り取りTToolStripMenuItem";
			this.切り取りTToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131160;
			this.切り取りTToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.切り取りTToolStripMenuItem.Text = "切り取り(&T)";
			this.切り取りTToolStripMenuItem.Click += new global::System.EventHandler(this.切り取りToolStripMenuItem_Click);
			this.コピ\u30FCCToolStripMenuItem.Name = "コピーCToolStripMenuItem";
			this.コピ\u30FCCToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131139;
			this.コピ\u30FCCToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.コピ\u30FCCToolStripMenuItem.Text = "コピー(&C)";
			this.コピ\u30FCCToolStripMenuItem.Click += new global::System.EventHandler(this.コピ\u30FCToolStripMenuItem_Click);
			this.貼り付けPToolStripMenuItem.Name = "貼り付けPToolStripMenuItem";
			this.貼り付けPToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131158;
			this.貼り付けPToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.貼り付けPToolStripMenuItem.Text = "貼り付け(&P)";
			this.貼り付けPToolStripMenuItem.Click += new global::System.EventHandler(this.貼り付けToolStripMenuItem_Click);
			this.挿入IToolStripMenuItem.Name = "挿入IToolStripMenuItem";
			this.挿入IToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.挿入IToolStripMenuItem.Text = "挿入(&I)";
			this.挿入IToolStripMenuItem.Click += new global::System.EventHandler(this.挿入ToolStripMenuItem_Click);
			this.削除DToolStripMenuItem.Name = "削除DToolStripMenuItem";
			this.削除DToolStripMenuItem.ShortcutKeys = global::System.Windows.Forms.Keys.Delete;
			this.削除DToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.削除DToolStripMenuItem.Text = "削除(&D)";
			this.削除DToolStripMenuItem.Click += new global::System.EventHandler(this.削除ToolStripMenuItem_Click);
			this.すべて選択ToolStripMenuItem.Name = "すべて選択ToolStripMenuItem";
			this.すべて選択ToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131137;
			this.すべて選択ToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.すべて選択ToolStripMenuItem.Text = "すべて選択(&A)";
			this.すべて選択ToolStripMenuItem.Click += new global::System.EventHandler(this.すべて選択ToolStripMenuItem_Click);
			this.書込み実行EToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.書込みWToolStripMenuItem, this.読込みRToolStripMenuItem, this.本体でメロディ再生BToolStripMenuItem, this.本体のメロディ停止EToolStripMenuItem, this.pC上でメロディ再生PToolStripMenuItem, this.pC上のメロディ停止SToolStripMenuItem });
			this.書込み実行EToolStripMenuItem.Name = "書込み実行EToolStripMenuItem";
			this.書込み実行EToolStripMenuItem.Size = new global::System.Drawing.Size(71, 20);
			this.書込み実行EToolStripMenuItem.Text = "メロディ(&M)";
			this.書込みWToolStripMenuItem.Name = "書込みWToolStripMenuItem";
			this.書込みWToolStripMenuItem.Size = new global::System.Drawing.Size(182, 22);
			this.書込みWToolStripMenuItem.Text = "メロディ書込み(&W)";
			this.書込みWToolStripMenuItem.Click += new global::System.EventHandler(this.書込みToolStripMenuItem_Click);
			this.読込みRToolStripMenuItem.Name = "読込みRToolStripMenuItem";
			this.読込みRToolStripMenuItem.Size = new global::System.Drawing.Size(182, 22);
			this.読込みRToolStripMenuItem.Text = "メロディ読込み(&R)";
			this.読込みRToolStripMenuItem.Click += new global::System.EventHandler(this.読込みToolStripMenuItem_Click);
			this.本体でメロディ再生BToolStripMenuItem.Name = "本体でメロディ再生BToolStripMenuItem";
			this.本体でメロディ再生BToolStripMenuItem.Size = new global::System.Drawing.Size(182, 22);
			this.本体でメロディ再生BToolStripMenuItem.Text = "本体でメロディ再生(&B)";
			this.本体でメロディ再生BToolStripMenuItem.Click += new global::System.EventHandler(this.本体でメロディ再生BToolStripMenuItem_Click);
			this.本体のメロディ停止EToolStripMenuItem.Name = "本体のメロディ停止EToolStripMenuItem";
			this.本体のメロディ停止EToolStripMenuItem.Size = new global::System.Drawing.Size(182, 22);
			this.本体のメロディ停止EToolStripMenuItem.Text = "本体のメロディ停止(&E)";
			this.本体のメロディ停止EToolStripMenuItem.Click += new global::System.EventHandler(this.本体のメロディ停止EToolStripMenuItem_Click);
			this.pC上でメロディ再生PToolStripMenuItem.Name = "pC上でメロディ再生PToolStripMenuItem";
			this.pC上でメロディ再生PToolStripMenuItem.Size = new global::System.Drawing.Size(182, 22);
			this.pC上でメロディ再生PToolStripMenuItem.Text = "PC上でメロディ再生(&P)";
			this.pC上でメロディ再生PToolStripMenuItem.Click += new global::System.EventHandler(this.pC上でメロディ再生PToolStripMenuItem_Click);
			this.pC上のメロディ停止SToolStripMenuItem.Name = "pC上のメロディ停止SToolStripMenuItem";
			this.pC上のメロディ停止SToolStripMenuItem.Size = new global::System.Drawing.Size(182, 22);
			this.pC上のメロディ停止SToolStripMenuItem.Text = "PC上のメロディ停止(&S)";
			this.pC上のメロディ停止SToolStripMenuItem.Click += new global::System.EventHandler(this.pC上のメロディ停止SToolStripMenuItem_Click);
			this.表示VToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.レポ\u30FCト作成RToolStripMenuItem, this.小節ToolStripMenuItem });
			this.表示VToolStripMenuItem.Name = "表示VToolStripMenuItem";
			this.表示VToolStripMenuItem.Size = new global::System.Drawing.Size(58, 20);
			this.表示VToolStripMenuItem.Text = "表示(&V)";
			this.レポ\u30FCト作成RToolStripMenuItem.Name = "レポート作成RToolStripMenuItem";
			this.レポ\u30FCト作成RToolStripMenuItem.Size = new global::System.Drawing.Size(148, 22);
			this.レポ\u30FCト作成RToolStripMenuItem.Text = "レポート作成(&R)";
			this.レポ\u30FCト作成RToolStripMenuItem.Click += new global::System.EventHandler(this.レポ\u30FCト作成RToolStripMenuItem_Click);
			this.ヘルプHToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.ヘルプ表示BToolStripMenuItem, this.バ\u30FCジョン情報VToolStripMenuItem });
			this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
			this.ヘルプHToolStripMenuItem.Size = new global::System.Drawing.Size(65, 20);
			this.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
			this.ヘルプ表示BToolStripMenuItem.Name = "ヘルプ表示BToolStripMenuItem";
			this.ヘルプ表示BToolStripMenuItem.Size = new global::System.Drawing.Size(157, 22);
			this.ヘルプ表示BToolStripMenuItem.Text = "ヘルプ表示(&B)";
			this.ヘルプ表示BToolStripMenuItem.Click += new global::System.EventHandler(this.ヘルプ表示ToolStripMenuItem_Click);
			this.バ\u30FCジョン情報VToolStripMenuItem.Name = "バージョン情報VToolStripMenuItem";
			this.バ\u30FCジョン情報VToolStripMenuItem.Size = new global::System.Drawing.Size(157, 22);
			this.バ\u30FCジョン情報VToolStripMenuItem.Text = "バージョン情報(&V)";
			this.バ\u30FCジョン情報VToolStripMenuItem.Click += new global::System.EventHandler(this.バ\u30FCジョン情報ToolStripMenuItem_Click);
			this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.ファイルToolStripMenuItem, this.編集EToolStripMenuItem, this.書込み実行EToolStripMenuItem, this.表示VToolStripMenuItem, this.ヘルプHToolStripMenuItem });
			this.menuStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new global::System.Drawing.Size(1008, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.AllowDrop = true;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(1008, 729);
			base.Controls.Add(this.splitContainer1);
			base.Controls.Add(this.menuStrip1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.menuStrip1;
			base.Name = "MelodyWindow";
			this.Text = "メロディ作成";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.MelodyWindow_FormClosing);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.MelodyWindow_FormClosed);
			base.Shown += new global::System.EventHandler(this.MelodyWindow_Shown);
			base.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.MelodyWindow_DragDrop);
			base.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.MelodyWindow_DragEnter);
			base.Resize += new global::System.EventHandler(this.MelodyWindow_Resize);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowRight).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowLeft).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxStop).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxRun).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxInsert).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxConnection).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxReport).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWrite).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPaste).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCopy).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCut).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxRedo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxUndo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxSave).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxOpen).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxNew).EndInit();
			this.splitContainer2.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer2).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonSettings).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonStop).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonPlay).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRest).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRest2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRest4).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRest8).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonRest16).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote2Dot).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote4Dot).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote4).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote8Dot).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote8).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxButtonNote16).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.contextMenuStrip.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000413 RID: 1043
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000414 RID: 1044
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000415 RID: 1045
		private global::System.Windows.Forms.PictureBox pictureBoxInsert;

		// Token: 0x04000416 RID: 1046
		private global::System.Windows.Forms.PictureBox pictureBoxConnection;

		// Token: 0x04000417 RID: 1047
		private global::System.Windows.Forms.PictureBox pictureBoxReport;

		// Token: 0x04000418 RID: 1048
		private global::System.Windows.Forms.PictureBox pictureBoxWrite;

		// Token: 0x04000419 RID: 1049
		private global::System.Windows.Forms.PictureBox pictureBoxPaste;

		// Token: 0x0400041A RID: 1050
		private global::System.Windows.Forms.PictureBox pictureBoxCopy;

		// Token: 0x0400041B RID: 1051
		private global::System.Windows.Forms.PictureBox pictureBoxCut;

		// Token: 0x0400041C RID: 1052
		private global::System.Windows.Forms.PictureBox pictureBoxRedo;

		// Token: 0x0400041D RID: 1053
		private global::System.Windows.Forms.PictureBox pictureBoxUndo;

		// Token: 0x0400041E RID: 1054
		private global::System.Windows.Forms.PictureBox pictureBoxSave;

		// Token: 0x0400041F RID: 1055
		private global::System.Windows.Forms.PictureBox pictureBoxOpen;

		// Token: 0x04000420 RID: 1056
		private global::System.Windows.Forms.PictureBox pictureBoxNew;

		// Token: 0x04000421 RID: 1057
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x04000422 RID: 1058
		private global::System.Windows.Forms.SplitContainer splitContainer2;

		// Token: 0x04000423 RID: 1059
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUsedMemory;

		// Token: 0x04000424 RID: 1060
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLog;

		// Token: 0x04000425 RID: 1061
		private global::System.Windows.Forms.PictureBox pictureBoxButtonStop;

		// Token: 0x04000426 RID: 1062
		private global::System.Windows.Forms.PictureBox pictureBoxButtonPlay;

		// Token: 0x04000427 RID: 1063
		private global::System.Windows.Forms.PictureBox pictureBoxButtonNote16;

		// Token: 0x04000428 RID: 1064
		private global::System.Windows.Forms.PictureBox pictureBoxButtonRest;

		// Token: 0x04000429 RID: 1065
		private global::System.Windows.Forms.PictureBox pictureBoxButtonRest2;

		// Token: 0x0400042A RID: 1066
		private global::System.Windows.Forms.PictureBox pictureBoxButtonRest4;

		// Token: 0x0400042B RID: 1067
		private global::System.Windows.Forms.PictureBox pictureBoxButtonRest8;

		// Token: 0x0400042C RID: 1068
		private global::System.Windows.Forms.PictureBox pictureBoxButtonRest16;

		// Token: 0x0400042D RID: 1069
		private global::System.Windows.Forms.PictureBox pictureBoxButtonNote;

		// Token: 0x0400042E RID: 1070
		private global::System.Windows.Forms.PictureBox pictureBoxButtonNote2Dot;

		// Token: 0x0400042F RID: 1071
		private global::System.Windows.Forms.PictureBox pictureBoxButtonNote2;

		// Token: 0x04000430 RID: 1072
		private global::System.Windows.Forms.PictureBox pictureBoxButtonNote4Dot;

		// Token: 0x04000431 RID: 1073
		private global::System.Windows.Forms.PictureBox pictureBoxButtonNote4;

		// Token: 0x04000432 RID: 1074
		private global::System.Windows.Forms.PictureBox pictureBoxButtonNote8Dot;

		// Token: 0x04000433 RID: 1075
		private global::System.Windows.Forms.PictureBox pictureBoxButtonNote8;

		// Token: 0x04000434 RID: 1076
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip;

		// Token: 0x04000435 RID: 1077
		private global::System.Windows.Forms.ToolStripMenuItem 元に戻すUToolStripMenuItem1;

		// Token: 0x04000436 RID: 1078
		private global::System.Windows.Forms.ToolStripMenuItem やり直しRToolStripMenuItem1;

		// Token: 0x04000437 RID: 1079
		private global::System.Windows.Forms.ToolStripMenuItem 切り取りTToolStripMenuItem1;

		// Token: 0x04000438 RID: 1080
		private global::System.Windows.Forms.ToolStripMenuItem コピ\u30FCCToolStripMenuItem1;

		// Token: 0x04000439 RID: 1081
		private global::System.Windows.Forms.ToolStripMenuItem 貼り付けPToolStripMenuItem1;

		// Token: 0x0400043A RID: 1082
		private global::System.Windows.Forms.ToolStripMenuItem 挿入IToolStripMenuItem1;

		// Token: 0x0400043B RID: 1083
		private global::System.Windows.Forms.ToolStripMenuItem 削除DToolStripMenuItem1;

		// Token: 0x0400043C RID: 1084
		private global::System.Windows.Forms.ToolStripMenuItem すべて選択AToolStripMenuItem;

		// Token: 0x0400043D RID: 1085
		private global::System.Windows.Forms.PictureBox pictureBoxButtonSettings;

		// Token: 0x0400043E RID: 1086
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x0400043F RID: 1087
		private global::System.Windows.Forms.PictureBox pictureBoxRun;

		// Token: 0x04000440 RID: 1088
		private global::System.Windows.Forms.PictureBox pictureBoxStop;

		// Token: 0x04000441 RID: 1089
		private global::System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;

		// Token: 0x04000442 RID: 1090
		private global::System.Windows.Forms.ToolStripMenuItem 新規作成NToolStripMenuItem;

		// Token: 0x04000443 RID: 1091
		private global::System.Windows.Forms.ToolStripMenuItem ファイルを開くOToolStripMenuItem;

		// Token: 0x04000444 RID: 1092
		private global::System.Windows.Forms.ToolStripMenuItem 上書き保存SToolStripMenuItem;

		// Token: 0x04000445 RID: 1093
		private global::System.Windows.Forms.ToolStripMenuItem 名前を付けて保存AToolStripMenuItem;

		// Token: 0x04000446 RID: 1094
		private global::System.Windows.Forms.ToolStripMenuItem 終了XToolStripMenuItem;

		// Token: 0x04000447 RID: 1095
		private global::System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;

		// Token: 0x04000448 RID: 1096
		private global::System.Windows.Forms.ToolStripMenuItem 元に戻すUToolStripMenuItem;

		// Token: 0x04000449 RID: 1097
		private global::System.Windows.Forms.ToolStripMenuItem やり直しRToolStripMenuItem;

		// Token: 0x0400044A RID: 1098
		private global::System.Windows.Forms.ToolStripMenuItem 切り取りTToolStripMenuItem;

		// Token: 0x0400044B RID: 1099
		private global::System.Windows.Forms.ToolStripMenuItem コピ\u30FCCToolStripMenuItem;

		// Token: 0x0400044C RID: 1100
		private global::System.Windows.Forms.ToolStripMenuItem 貼り付けPToolStripMenuItem;

		// Token: 0x0400044D RID: 1101
		private global::System.Windows.Forms.ToolStripMenuItem 挿入IToolStripMenuItem;

		// Token: 0x0400044E RID: 1102
		private global::System.Windows.Forms.ToolStripMenuItem 削除DToolStripMenuItem;

		// Token: 0x0400044F RID: 1103
		private global::System.Windows.Forms.ToolStripMenuItem すべて選択ToolStripMenuItem;

		// Token: 0x04000450 RID: 1104
		private global::System.Windows.Forms.ToolStripMenuItem 書込み実行EToolStripMenuItem;

		// Token: 0x04000451 RID: 1105
		private global::System.Windows.Forms.ToolStripMenuItem 書込みWToolStripMenuItem;

		// Token: 0x04000452 RID: 1106
		private global::System.Windows.Forms.ToolStripMenuItem 読込みRToolStripMenuItem;

		// Token: 0x04000453 RID: 1107
		private global::System.Windows.Forms.ToolStripMenuItem 本体でメロディ再生BToolStripMenuItem;

		// Token: 0x04000454 RID: 1108
		private global::System.Windows.Forms.ToolStripMenuItem 本体のメロディ停止EToolStripMenuItem;

		// Token: 0x04000455 RID: 1109
		private global::System.Windows.Forms.ToolStripMenuItem pC上でメロディ再生PToolStripMenuItem;

		// Token: 0x04000456 RID: 1110
		private global::System.Windows.Forms.ToolStripMenuItem pC上のメロディ停止SToolStripMenuItem;

		// Token: 0x04000457 RID: 1111
		private global::System.Windows.Forms.ToolStripMenuItem 表示VToolStripMenuItem;

		// Token: 0x04000458 RID: 1112
		private global::System.Windows.Forms.ToolStripMenuItem レポ\u30FCト作成RToolStripMenuItem;

		// Token: 0x04000459 RID: 1113
		private global::System.Windows.Forms.ToolStripMenuItem 小節ToolStripMenuItem;

		// Token: 0x0400045A RID: 1114
		private global::System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;

		// Token: 0x0400045B RID: 1115
		private global::System.Windows.Forms.ToolStripMenuItem ヘルプ表示BToolStripMenuItem;

		// Token: 0x0400045C RID: 1116
		private global::System.Windows.Forms.ToolStripMenuItem バ\u30FCジョン情報VToolStripMenuItem;

		// Token: 0x0400045D RID: 1117
		private global::System.Windows.Forms.MenuStrip menuStrip1;

		// Token: 0x0400045E RID: 1118
		private global::System.Windows.Forms.PictureBox pictureBoxArrowLeft;

		// Token: 0x0400045F RID: 1119
		private global::System.Windows.Forms.PictureBox pictureBoxArrowRight;
	}
}
