namespace Clock
{
	// Token: 0x02000048 RID: 72
	public partial class NetworkWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x060007F3 RID: 2035 RVA: 0x00056EA4 File Offset: 0x000550A4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x00056EC4 File Offset: 0x000550C4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.NetworkWindow));
			this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelLog = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxArrowRight = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxChange = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxConnection = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxArrowLeft = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxNew = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxReport = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxOpen = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxRun = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxSave = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxPaste = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxUndo = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxCopy = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxRedo = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxCut = new global::System.Windows.Forms.PictureBox();
			this.splitContainer2 = new global::System.Windows.Forms.SplitContainer();
			this.splitContainer6 = new global::System.Windows.Forms.SplitContainer();
			this.splitContainer7 = new global::System.Windows.Forms.SplitContainer();
			this.splitContainer8 = new global::System.Windows.Forms.SplitContainer();
			this.splitContainer3 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxArrowDown = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockUsbOut = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockLabel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockJump = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockIfElse = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockOutput = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockDisplay = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxArrowUp = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockData = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockCommunication = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockIf = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockLoopEnd = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockLoopStart = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockWait = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockMessage = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockEvent = new global::System.Windows.Forms.PictureBox();
			this.splitContainer4 = new global::System.Windows.Forms.SplitContainer();
			this.comboBoxLevel = new global::System.Windows.Forms.ComboBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.labelServer = new global::System.Windows.Forms.Label();
			this.labelConnect = new global::System.Windows.Forms.Label();
			this.pictureBox14 = new global::System.Windows.Forms.PictureBox();
			this.splitContainer5 = new global::System.Windows.Forms.SplitContainer();
			this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
			this.ファイルFToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
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
			this.削除DToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.すべて選択AToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.プログラムPToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.プログラム実行EToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.通信エラ\u30FCでプログラムを停止するIToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.表示VToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.レポ\u30FCト作成RToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.グリッドGToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.パラメ\u30FCタ表示DToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.デ\u30FCタ設定DToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.各種情報表示ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ネットワ\u30FCクNToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.サ\u30FCバ\u30FCクライアント設定NToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.通信チェックCToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ポ\u30FCト番号指定PToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ヘルプHToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ヘルプ表示BToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.バ\u30FCジョン情報VToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.設定CToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.外部入出力に対応UToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.元に戻すToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.やり直しToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.切り取りToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.コピ\u30FCToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.貼り付けToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.削除ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.矢印を削除ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.整列ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.左揃えToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.右揃えToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.上揃えToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.下揃えToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.すべて選択ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.サ\u30FCバデ\u30FCタの情報を共有するSToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.選択メニュ\u30FC表示EToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowRight).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxChange).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxConnection).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowLeft).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxNew).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxReport).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxOpen).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxRun).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxSave).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPaste).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxUndo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCopy).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxRedo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCut).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer2).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer6).BeginInit();
			this.splitContainer6.Panel1.SuspendLayout();
			this.splitContainer6.Panel2.SuspendLayout();
			this.splitContainer6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer7).BeginInit();
			this.splitContainer7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer8).BeginInit();
			this.splitContainer8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer3).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowDown).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockUsbOut).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLabel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockJump).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockIfElse).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockOutput).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockDisplay).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowUp).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockData).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockCommunication).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockIf).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLoopEnd).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLoopStart).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockWait).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockMessage).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockEvent).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer4).BeginInit();
			this.splitContainer4.Panel1.SuspendLayout();
			this.splitContainer4.Panel2.SuspendLayout();
			this.splitContainer4.SuspendLayout();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox14).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer5).BeginInit();
			this.splitContainer5.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.toolStripStatusLabelLog });
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 707);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new global::System.Drawing.Size(1008, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "メモリ消費 0/147";
			this.toolStripStatusLabelLog.BackColor = global::System.Drawing.SystemColors.Control;
			this.toolStripStatusLabelLog.Name = "toolStripStatusLabelLog";
			this.toolStripStatusLabelLog.Size = new global::System.Drawing.Size(49, 17);
			this.toolStripStatusLabelLog.Text = "ログ表示";
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(92, 87, 83);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxArrowRight);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxChange);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxConnection);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxArrowLeft);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxNew);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxReport);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxOpen);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxRun);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxSave);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxPaste);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxUndo);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxCopy);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxRedo);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxCut);
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new global::System.Drawing.Size(1008, 683);
			this.splitContainer1.SplitterDistance = 55;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 3;
			this.pictureBoxArrowRight.Image = global::Clock.Properties.Resources.icon_btn_210;
			this.pictureBoxArrowRight.Location = new global::System.Drawing.Point(809, 0);
			this.pictureBoxArrowRight.Name = "pictureBoxArrowRight";
			this.pictureBoxArrowRight.Size = new global::System.Drawing.Size(39, 54);
			this.pictureBoxArrowRight.TabIndex = 16;
			this.pictureBoxArrowRight.TabStop = false;
			this.pictureBoxArrowRight.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowRight_MouseDown);
			this.pictureBoxArrowRight.MouseEnter += new global::System.EventHandler(this.pictureBoxArrowRight_MouseEnter);
			this.pictureBoxArrowRight.MouseLeave += new global::System.EventHandler(this.pictureBoxArrowRight_MouseLeave);
			this.pictureBoxArrowRight.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowRight_MouseUp);
			this.pictureBoxChange.Image = global::Clock.Properties.Resources.icon_btn_110;
			this.pictureBoxChange.Location = new global::System.Drawing.Point(660, 5);
			this.pictureBoxChange.Name = "pictureBoxChange";
			this.pictureBoxChange.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxChange.TabIndex = 17;
			this.pictureBoxChange.TabStop = false;
			this.pictureBoxChange.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxChange_MouseDown);
			this.pictureBoxChange.MouseEnter += new global::System.EventHandler(this.pictureBoxChange_MouseEnter);
			this.pictureBoxChange.MouseLeave += new global::System.EventHandler(this.pictureBoxChange_MouseLeave);
			this.pictureBoxChange.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxChange_MouseUp);
			this.pictureBoxConnection.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxConnection.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxConnection.Image = global::Clock.Properties.Resources.icon_usb_off;
			this.pictureBoxConnection.Location = new global::System.Drawing.Point(809, 9);
			this.pictureBoxConnection.Name = "pictureBoxConnection";
			this.pictureBoxConnection.Size = new global::System.Drawing.Size(32, 35);
			this.pictureBoxConnection.TabIndex = 14;
			this.pictureBoxConnection.TabStop = false;
			this.pictureBoxArrowLeft.Image = global::Clock.Properties.Resources.icon_btn_220;
			this.pictureBoxArrowLeft.Location = new global::System.Drawing.Point(3, 0);
			this.pictureBoxArrowLeft.Name = "pictureBoxArrowLeft";
			this.pictureBoxArrowLeft.Size = new global::System.Drawing.Size(39, 54);
			this.pictureBoxArrowLeft.TabIndex = 15;
			this.pictureBoxArrowLeft.TabStop = false;
			this.pictureBoxArrowLeft.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowLeft_MouseDown);
			this.pictureBoxArrowLeft.MouseEnter += new global::System.EventHandler(this.pictureBoxArrowLeft_MouseEnter);
			this.pictureBoxArrowLeft.MouseLeave += new global::System.EventHandler(this.pictureBoxArrowLeft_MouseLeave);
			this.pictureBoxArrowLeft.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowLeft_MouseUp);
			this.pictureBoxNew.Image = global::Clock.Properties.Resources.icon_btn_000;
			this.pictureBoxNew.Location = new global::System.Drawing.Point(12, 5);
			this.pictureBoxNew.Name = "pictureBoxNew";
			this.pictureBoxNew.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxNew.TabIndex = 0;
			this.pictureBoxNew.TabStop = false;
			this.pictureBoxNew.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxNew_MouseDown);
			this.pictureBoxNew.MouseEnter += new global::System.EventHandler(this.pictureBoxNew_MouseEnter);
			this.pictureBoxNew.MouseLeave += new global::System.EventHandler(this.pictureBoxNew_MouseLeave);
			this.pictureBoxNew.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxNew_MouseUp);
			this.pictureBoxReport.Image = global::Clock.Properties.Resources.icon_btn_120;
			this.pictureBoxReport.Location = new global::System.Drawing.Point(732, 5);
			this.pictureBoxReport.Name = "pictureBoxReport";
			this.pictureBoxReport.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxReport.TabIndex = 12;
			this.pictureBoxReport.TabStop = false;
			this.pictureBoxReport.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxReport_MouseDown);
			this.pictureBoxReport.MouseEnter += new global::System.EventHandler(this.pictureBoxReport_MouseEnter);
			this.pictureBoxReport.MouseLeave += new global::System.EventHandler(this.pictureBoxReport_MouseLeave);
			this.pictureBoxReport.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxReport_MouseUp);
			this.pictureBoxOpen.Image = global::Clock.Properties.Resources.icon_btn_010;
			this.pictureBoxOpen.Location = new global::System.Drawing.Point(84, 5);
			this.pictureBoxOpen.Name = "pictureBoxOpen";
			this.pictureBoxOpen.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxOpen.TabIndex = 1;
			this.pictureBoxOpen.TabStop = false;
			this.pictureBoxOpen.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxOpen_MouseDown);
			this.pictureBoxOpen.MouseEnter += new global::System.EventHandler(this.pictureBoxOpen_MouseEnter);
			this.pictureBoxOpen.MouseLeave += new global::System.EventHandler(this.pictureBoxOpen_MouseLeave);
			this.pictureBoxOpen.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxOpen_MouseUp);
			this.pictureBoxRun.Image = global::Clock.Properties.Resources.icon_btn_090;
			this.pictureBoxRun.Location = new global::System.Drawing.Point(588, 5);
			this.pictureBoxRun.Name = "pictureBoxRun";
			this.pictureBoxRun.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxRun.TabIndex = 9;
			this.pictureBoxRun.TabStop = false;
			this.pictureBoxRun.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxRun_MouseDown);
			this.pictureBoxRun.MouseEnter += new global::System.EventHandler(this.pictureBoxRun_MouseEnter);
			this.pictureBoxRun.MouseLeave += new global::System.EventHandler(this.pictureBoxRun_MouseLeave);
			this.pictureBoxRun.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxRun_MouseUp);
			this.pictureBoxSave.Image = global::Clock.Properties.Resources.icon_btn_020;
			this.pictureBoxSave.Location = new global::System.Drawing.Point(156, 5);
			this.pictureBoxSave.Name = "pictureBoxSave";
			this.pictureBoxSave.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxSave.TabIndex = 2;
			this.pictureBoxSave.TabStop = false;
			this.pictureBoxSave.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxSave_MouseDown);
			this.pictureBoxSave.MouseEnter += new global::System.EventHandler(this.pictureBoxSave_MouseEnter);
			this.pictureBoxSave.MouseLeave += new global::System.EventHandler(this.pictureBoxSave_MouseLeave);
			this.pictureBoxSave.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxSave_MouseUp);
			this.pictureBoxPaste.Image = global::Clock.Properties.Resources.icon_btn_070;
			this.pictureBoxPaste.Location = new global::System.Drawing.Point(516, 5);
			this.pictureBoxPaste.Name = "pictureBoxPaste";
			this.pictureBoxPaste.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxPaste.TabIndex = 7;
			this.pictureBoxPaste.TabStop = false;
			this.pictureBoxPaste.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxPaste_MouseDown);
			this.pictureBoxPaste.MouseEnter += new global::System.EventHandler(this.pictureBoxPaste_MouseEnter);
			this.pictureBoxPaste.MouseLeave += new global::System.EventHandler(this.pictureBoxPaste_MouseLeave);
			this.pictureBoxPaste.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxPaste_MouseUp);
			this.pictureBoxUndo.Image = global::Clock.Properties.Resources.icon_btn_030;
			this.pictureBoxUndo.Location = new global::System.Drawing.Point(228, 5);
			this.pictureBoxUndo.Name = "pictureBoxUndo";
			this.pictureBoxUndo.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxUndo.TabIndex = 3;
			this.pictureBoxUndo.TabStop = false;
			this.pictureBoxUndo.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxUndo_MouseDown);
			this.pictureBoxUndo.MouseEnter += new global::System.EventHandler(this.pictureBoxUndo_MouseEnter);
			this.pictureBoxUndo.MouseLeave += new global::System.EventHandler(this.pictureBoxUndo_MouseLeave);
			this.pictureBoxUndo.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxUndo_MouseUp);
			this.pictureBoxCopy.Image = global::Clock.Properties.Resources.icon_btn_060;
			this.pictureBoxCopy.Location = new global::System.Drawing.Point(444, 5);
			this.pictureBoxCopy.Name = "pictureBoxCopy";
			this.pictureBoxCopy.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxCopy.TabIndex = 6;
			this.pictureBoxCopy.TabStop = false;
			this.pictureBoxCopy.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxCopy_MouseDown);
			this.pictureBoxCopy.MouseEnter += new global::System.EventHandler(this.pictureBoxCopy_MouseEnter);
			this.pictureBoxCopy.MouseLeave += new global::System.EventHandler(this.pictureBoxCopy_MouseLeave);
			this.pictureBoxCopy.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxCopy_MouseUp);
			this.pictureBoxRedo.Image = global::Clock.Properties.Resources.icon_btn_040;
			this.pictureBoxRedo.Location = new global::System.Drawing.Point(300, 5);
			this.pictureBoxRedo.Name = "pictureBoxRedo";
			this.pictureBoxRedo.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxRedo.TabIndex = 4;
			this.pictureBoxRedo.TabStop = false;
			this.pictureBoxRedo.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxRedo_MouseDown);
			this.pictureBoxRedo.MouseEnter += new global::System.EventHandler(this.pictureBoxRedo_MouseEnter);
			this.pictureBoxRedo.MouseLeave += new global::System.EventHandler(this.pictureBoxRedo_MouseLeave);
			this.pictureBoxRedo.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxRedo_MouseUp);
			this.pictureBoxCut.Image = global::Clock.Properties.Resources.icon_btn_050;
			this.pictureBoxCut.Location = new global::System.Drawing.Point(372, 5);
			this.pictureBoxCut.Name = "pictureBoxCut";
			this.pictureBoxCut.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxCut.TabIndex = 5;
			this.pictureBoxCut.TabStop = false;
			this.pictureBoxCut.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxCut_MouseDown);
			this.pictureBoxCut.MouseEnter += new global::System.EventHandler(this.pictureBoxCut_MouseEnter);
			this.pictureBoxCut.MouseLeave += new global::System.EventHandler(this.pictureBoxCut_MouseLeave);
			this.pictureBoxCut.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxCut_MouseUp);
			this.splitContainer2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Panel1.BackColor = global::System.Drawing.SystemColors.Control;
			this.splitContainer2.Panel1.Controls.Add(this.splitContainer6);
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
			this.splitContainer2.Size = new global::System.Drawing.Size(1008, 627);
			this.splitContainer2.SplitterDistance = 285;
			this.splitContainer2.SplitterWidth = 1;
			this.splitContainer2.TabIndex = 3;
			this.splitContainer6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer6.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer6.IsSplitterFixed = true;
			this.splitContainer6.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer6.Name = "splitContainer6";
			this.splitContainer6.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer6.Panel1.BackColor = global::System.Drawing.Color.Blue;
			this.splitContainer6.Panel1.Controls.Add(this.splitContainer7);
			this.splitContainer6.Panel2.Controls.Add(this.splitContainer8);
			this.splitContainer6.Size = new global::System.Drawing.Size(285, 627);
			this.splitContainer6.SplitterDistance = 440;
			this.splitContainer6.SplitterWidth = 1;
			this.splitContainer6.TabIndex = 0;
			this.splitContainer7.BackColor = global::System.Drawing.Color.FromArgb(117, 179, 179);
			this.splitContainer7.IsSplitterFixed = true;
			this.splitContainer7.Location = new global::System.Drawing.Point(3, 3);
			this.splitContainer7.Name = "splitContainer7";
			this.splitContainer7.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer7.Panel1.BackColor = global::System.Drawing.SystemColors.Control;
			this.splitContainer7.Panel2.BackColor = global::System.Drawing.SystemColors.Control;
			this.splitContainer7.Size = new global::System.Drawing.Size(279, 434);
			this.splitContainer7.SplitterDistance = 398;
			this.splitContainer7.SplitterWidth = 1;
			this.splitContainer7.TabIndex = 0;
			this.splitContainer8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer8.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer8.IsSplitterFixed = true;
			this.splitContainer8.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer8.Name = "splitContainer8";
			this.splitContainer8.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer8.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer8.Panel2.AutoScroll = true;
			this.splitContainer8.Panel2.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer8.Size = new global::System.Drawing.Size(285, 186);
			this.splitContainer8.SplitterDistance = 40;
			this.splitContainer8.SplitterWidth = 1;
			this.splitContainer8.TabIndex = 0;
			this.splitContainer3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer3.IsSplitterFixed = true;
			this.splitContainer3.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Panel1.AllowDrop = true;
			this.splitContainer3.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxArrowDown);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockUsbOut);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockLabel);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockJump);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockIfElse);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockOutput);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockDisplay);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxArrowUp);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockData);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockCommunication);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockIf);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockLoopEnd);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockLoopStart);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockWait);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockMessage);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxBlockEvent);
			this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
			this.splitContainer3.Size = new global::System.Drawing.Size(722, 627);
			this.splitContainer3.SplitterDistance = 91;
			this.splitContainer3.SplitterWidth = 1;
			this.splitContainer3.TabIndex = 0;
			this.pictureBoxArrowDown.Image = global::Clock.Properties.Resources.icon_btn_200;
			this.pictureBoxArrowDown.Location = new global::System.Drawing.Point(1, 556);
			this.pictureBoxArrowDown.Name = "pictureBoxArrowDown";
			this.pictureBoxArrowDown.Size = new global::System.Drawing.Size(89, 39);
			this.pictureBoxArrowDown.TabIndex = 12;
			this.pictureBoxArrowDown.TabStop = false;
			this.pictureBoxArrowDown.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowDown_MouseDown);
			this.pictureBoxArrowDown.MouseEnter += new global::System.EventHandler(this.pictureBoxArrowDown_MouseEnter);
			this.pictureBoxArrowDown.MouseLeave += new global::System.EventHandler(this.pictureBoxArrowDown_MouseLeave);
			this.pictureBoxArrowDown.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowDown_MouseUp);
			this.pictureBoxBlockUsbOut.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockUsbOut.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockUsbOut.Image = global::Clock.Properties.Resources.fc_btn_050;
			this.pictureBoxBlockUsbOut.Location = new global::System.Drawing.Point(5, 617);
			this.pictureBoxBlockUsbOut.Name = "pictureBoxBlockUsbOut";
			this.pictureBoxBlockUsbOut.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockUsbOut.TabIndex = 19;
			this.pictureBoxBlockUsbOut.TabStop = false;
			this.pictureBoxBlockUsbOut.Visible = false;
			this.pictureBoxBlockUsbOut.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockUsbOut_GiveFeedback);
			this.pictureBoxBlockUsbOut.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockUsbOut_QueryContinueDrag);
			this.pictureBoxBlockUsbOut.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockUsbOut_MouseDown);
			this.pictureBoxBlockUsbOut.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockUsbOut_MouseEnter);
			this.pictureBoxBlockUsbOut.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockUsbOut_MouseLeave);
			this.pictureBoxBlockLabel.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockLabel.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockLabel.Image = global::Clock.Properties.Resources.bp_btn_120;
			this.pictureBoxBlockLabel.Location = new global::System.Drawing.Point(5, 319);
			this.pictureBoxBlockLabel.Name = "pictureBoxBlockLabel";
			this.pictureBoxBlockLabel.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockLabel.TabIndex = 18;
			this.pictureBoxBlockLabel.TabStop = false;
			this.pictureBoxBlockLabel.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockLabel_GiveFeedback);
			this.pictureBoxBlockLabel.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockLabel_QueryContinueDrag);
			this.pictureBoxBlockLabel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockLabel_MouseDown);
			this.pictureBoxBlockLabel.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockLabel_MouseEnter);
			this.pictureBoxBlockLabel.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockLabel_MouseLeave);
			this.pictureBoxBlockJump.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockJump.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockJump.Image = global::Clock.Properties.Resources.bp_btn_110;
			this.pictureBoxBlockJump.Location = new global::System.Drawing.Point(5, 305);
			this.pictureBoxBlockJump.Name = "pictureBoxBlockJump";
			this.pictureBoxBlockJump.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockJump.TabIndex = 17;
			this.pictureBoxBlockJump.TabStop = false;
			this.pictureBoxBlockJump.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockJump_GiveFeedback);
			this.pictureBoxBlockJump.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockJump_QueryContinueDrag);
			this.pictureBoxBlockJump.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockJump_MouseDown);
			this.pictureBoxBlockJump.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockJump_MouseEnter);
			this.pictureBoxBlockJump.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockJump_MouseLeave);
			this.pictureBoxBlockIfElse.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockIfElse.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockIfElse.Image = global::Clock.Properties.Resources.bp_btn_060;
			this.pictureBoxBlockIfElse.Location = new global::System.Drawing.Point(5, 290);
			this.pictureBoxBlockIfElse.Name = "pictureBoxBlockIfElse";
			this.pictureBoxBlockIfElse.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockIfElse.TabIndex = 16;
			this.pictureBoxBlockIfElse.TabStop = false;
			this.pictureBoxBlockIfElse.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockIfElse_GiveFeedback);
			this.pictureBoxBlockIfElse.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockIfElse_QueryContinueDrag);
			this.pictureBoxBlockIfElse.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockIfElse_MouseDown);
			this.pictureBoxBlockIfElse.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockIfElse_MouseEnter);
			this.pictureBoxBlockIfElse.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockIfElse_MouseLeave);
			this.pictureBoxBlockOutput.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockOutput.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockOutput.Image = global::Clock.Properties.Resources.nw_btn_040;
			this.pictureBoxBlockOutput.Location = new global::System.Drawing.Point(5, 560);
			this.pictureBoxBlockOutput.Name = "pictureBoxBlockOutput";
			this.pictureBoxBlockOutput.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockOutput.TabIndex = 14;
			this.pictureBoxBlockOutput.TabStop = false;
			this.pictureBoxBlockOutput.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockOutput_GiveFeedback);
			this.pictureBoxBlockOutput.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockOutput_QueryContinueDrag);
			this.pictureBoxBlockOutput.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockOutput_MouseDown);
			this.pictureBoxBlockOutput.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockOutput_MouseEnter);
			this.pictureBoxBlockOutput.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockOutput_MouseLeave);
			this.pictureBoxBlockDisplay.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockDisplay.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockDisplay.Image = global::Clock.Properties.Resources.nw_btn_050;
			this.pictureBoxBlockDisplay.Location = new global::System.Drawing.Point(5, 503);
			this.pictureBoxBlockDisplay.Name = "pictureBoxBlockDisplay";
			this.pictureBoxBlockDisplay.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockDisplay.TabIndex = 11;
			this.pictureBoxBlockDisplay.TabStop = false;
			this.pictureBoxBlockDisplay.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockDisplay_GiveFeedback);
			this.pictureBoxBlockDisplay.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockDisplay_QueryContinueDrag);
			this.pictureBoxBlockDisplay.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockDisplay_MouseDown);
			this.pictureBoxBlockDisplay.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockDisplay_MouseEnter);
			this.pictureBoxBlockDisplay.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockDisplay_MouseLeave);
			this.pictureBoxArrowUp.Image = global::Clock.Properties.Resources.icon_btn_190;
			this.pictureBoxArrowUp.Location = new global::System.Drawing.Point(1, 4);
			this.pictureBoxArrowUp.Name = "pictureBoxArrowUp";
			this.pictureBoxArrowUp.Size = new global::System.Drawing.Size(89, 39);
			this.pictureBoxArrowUp.TabIndex = 11;
			this.pictureBoxArrowUp.TabStop = false;
			this.pictureBoxArrowUp.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowUp_MouseDown);
			this.pictureBoxArrowUp.MouseEnter += new global::System.EventHandler(this.pictureBoxArrowUp_MouseEnter);
			this.pictureBoxArrowUp.MouseLeave += new global::System.EventHandler(this.pictureBoxArrowUp_MouseLeave);
			this.pictureBoxArrowUp.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowUp_MouseUp);
			this.pictureBoxBlockData.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockData.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockData.Image = global::Clock.Properties.Resources.nw_btn_030;
			this.pictureBoxBlockData.Location = new global::System.Drawing.Point(5, 446);
			this.pictureBoxBlockData.Name = "pictureBoxBlockData";
			this.pictureBoxBlockData.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockData.TabIndex = 10;
			this.pictureBoxBlockData.TabStop = false;
			this.pictureBoxBlockData.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockData_GiveFeedback);
			this.pictureBoxBlockData.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockData_QueryContinueDrag);
			this.pictureBoxBlockData.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockData_MouseDown);
			this.pictureBoxBlockData.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockData_MouseEnter);
			this.pictureBoxBlockData.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockData_MouseLeave);
			this.pictureBoxBlockCommunication.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockCommunication.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockCommunication.Image = global::Clock.Properties.Resources.nw_btn_020;
			this.pictureBoxBlockCommunication.Location = new global::System.Drawing.Point(5, 161);
			this.pictureBoxBlockCommunication.Name = "pictureBoxBlockCommunication";
			this.pictureBoxBlockCommunication.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockCommunication.TabIndex = 9;
			this.pictureBoxBlockCommunication.TabStop = false;
			this.pictureBoxBlockCommunication.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockCommunication_GiveFeedback);
			this.pictureBoxBlockCommunication.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockCommunication_QueryContinueDrag);
			this.pictureBoxBlockCommunication.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockCommunication_MouseDown);
			this.pictureBoxBlockCommunication.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockCommunication_MouseEnter);
			this.pictureBoxBlockCommunication.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockCommunication_MouseLeave);
			this.pictureBoxBlockIf.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockIf.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockIf.Image = global::Clock.Properties.Resources.fc_btn_010;
			this.pictureBoxBlockIf.Location = new global::System.Drawing.Point(5, 275);
			this.pictureBoxBlockIf.Name = "pictureBoxBlockIf";
			this.pictureBoxBlockIf.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockIf.TabIndex = 8;
			this.pictureBoxBlockIf.TabStop = false;
			this.pictureBoxBlockIf.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockIf_GiveFeedback);
			this.pictureBoxBlockIf.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockIf_QueryContinueDrag);
			this.pictureBoxBlockIf.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockIf_MouseDown);
			this.pictureBoxBlockIf.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockIf_MouseEnter);
			this.pictureBoxBlockIf.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockIf_MouseLeave);
			this.pictureBoxBlockLoopEnd.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockLoopEnd.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockLoopEnd.Image = global::Clock.Properties.Resources.icon_btn_170;
			this.pictureBoxBlockLoopEnd.Location = new global::System.Drawing.Point(5, 389);
			this.pictureBoxBlockLoopEnd.Name = "pictureBoxBlockLoopEnd";
			this.pictureBoxBlockLoopEnd.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockLoopEnd.TabIndex = 6;
			this.pictureBoxBlockLoopEnd.TabStop = false;
			this.pictureBoxBlockLoopEnd.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockLoopEnd_GiveFeedback);
			this.pictureBoxBlockLoopEnd.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockLoopEnd_QueryContinueDrag);
			this.pictureBoxBlockLoopEnd.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockLoopEnd_MouseDown);
			this.pictureBoxBlockLoopEnd.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockLoopEnd_MouseEnter);
			this.pictureBoxBlockLoopEnd.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockLoopEnd_MouseLeave);
			this.pictureBoxBlockLoopStart.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockLoopStart.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockLoopStart.Image = global::Clock.Properties.Resources.icon_btn_160;
			this.pictureBoxBlockLoopStart.Location = new global::System.Drawing.Point(5, 332);
			this.pictureBoxBlockLoopStart.Name = "pictureBoxBlockLoopStart";
			this.pictureBoxBlockLoopStart.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockLoopStart.TabIndex = 5;
			this.pictureBoxBlockLoopStart.TabStop = false;
			this.pictureBoxBlockLoopStart.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockLoopStart_GiveFeedback);
			this.pictureBoxBlockLoopStart.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockLoopStart_QueryContinueDrag);
			this.pictureBoxBlockLoopStart.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockLoopStart_MouseDown);
			this.pictureBoxBlockLoopStart.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockLoopStart_MouseEnter);
			this.pictureBoxBlockLoopStart.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockLoopStart_MouseLeave);
			this.pictureBoxBlockWait.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockWait.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockWait.Image = global::Clock.Properties.Resources.icon_btn_150;
			this.pictureBoxBlockWait.Location = new global::System.Drawing.Point(4, 218);
			this.pictureBoxBlockWait.Name = "pictureBoxBlockWait";
			this.pictureBoxBlockWait.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockWait.TabIndex = 4;
			this.pictureBoxBlockWait.TabStop = false;
			this.pictureBoxBlockWait.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockWait_GiveFeedback);
			this.pictureBoxBlockWait.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockWait_QueryContinueDrag);
			this.pictureBoxBlockWait.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockWait_MouseDown);
			this.pictureBoxBlockWait.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockWait_MouseEnter);
			this.pictureBoxBlockWait.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockWait_MouseLeave);
			this.pictureBoxBlockMessage.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockMessage.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockMessage.Image = global::Clock.Properties.Resources.nw_btn_010;
			this.pictureBoxBlockMessage.Location = new global::System.Drawing.Point(5, 104);
			this.pictureBoxBlockMessage.Name = "pictureBoxBlockMessage";
			this.pictureBoxBlockMessage.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockMessage.TabIndex = 3;
			this.pictureBoxBlockMessage.TabStop = false;
			this.pictureBoxBlockMessage.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockMessage_GiveFeedback);
			this.pictureBoxBlockMessage.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockMessage_QueryContinueDrag);
			this.pictureBoxBlockMessage.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockMessage_MouseDown);
			this.pictureBoxBlockMessage.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockMessage_MouseEnter);
			this.pictureBoxBlockMessage.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockMessage_MouseLeave);
			this.pictureBoxBlockEvent.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockEvent.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockEvent.Image = global::Clock.Properties.Resources.nw_btn_000;
			this.pictureBoxBlockEvent.Location = new global::System.Drawing.Point(5, 47);
			this.pictureBoxBlockEvent.Name = "pictureBoxBlockEvent";
			this.pictureBoxBlockEvent.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockEvent.TabIndex = 2;
			this.pictureBoxBlockEvent.TabStop = false;
			this.pictureBoxBlockEvent.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockEvent_GiveFeedback);
			this.pictureBoxBlockEvent.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockEvent_QueryContinueDrag);
			this.pictureBoxBlockEvent.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockEvent_MouseDown);
			this.pictureBoxBlockEvent.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockEvent_MouseEnter);
			this.pictureBoxBlockEvent.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockEvent_MouseLeave);
			this.splitContainer4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer4.IsSplitterFixed = true;
			this.splitContainer4.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer4.Name = "splitContainer4";
			this.splitContainer4.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer4.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer4.Panel1.Controls.Add(this.comboBoxLevel);
			this.splitContainer4.Panel1.Controls.Add(this.panel1);
			this.splitContainer4.Panel1.Controls.Add(this.pictureBox14);
			this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
			this.splitContainer4.Size = new global::System.Drawing.Size(630, 627);
			this.splitContainer4.SplitterDistance = 42;
			this.splitContainer4.SplitterWidth = 1;
			this.splitContainer4.TabIndex = 0;
			this.comboBoxLevel.FormattingEnabled = true;
			this.comboBoxLevel.Items.AddRange(new object[] { "レベル１", "レベル２", "レベル３" });
			this.comboBoxLevel.Location = new global::System.Drawing.Point(488, 13);
			this.comboBoxLevel.Name = "comboBoxLevel";
			this.comboBoxLevel.Size = new global::System.Drawing.Size(121, 20);
			this.comboBoxLevel.TabIndex = 3;
			this.comboBoxLevel.SelectedIndexChanged += new global::System.EventHandler(this.comboBoxLevel_SelectedIndexChanged);
			this.comboBoxLevel.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.comboBoxLevel_KeyDown);
			this.panel1.BackColor = global::System.Drawing.Color.White;
			this.panel1.Controls.Add(this.labelServer);
			this.panel1.Controls.Add(this.labelConnect);
			this.panel1.Location = new global::System.Drawing.Point(239, 10);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(233, 27);
			this.panel1.TabIndex = 2;
			this.labelServer.AutoSize = true;
			this.labelServer.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelServer.ForeColor = global::System.Drawing.Color.Black;
			this.labelServer.Location = new global::System.Drawing.Point(165, 5);
			this.labelServer.Name = "labelServer";
			this.labelServer.Size = new global::System.Drawing.Size(68, 18);
			this.labelServer.TabIndex = 1;
			this.labelServer.Text = "サーバー名";
			this.labelServer.Visible = false;
			this.labelConnect.Font = new global::System.Drawing.Font("メイリオ", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 128);
			this.labelConnect.ForeColor = global::System.Drawing.Color.Red;
			this.labelConnect.Location = new global::System.Drawing.Point(3, 5);
			this.labelConnect.Name = "labelConnect";
			this.labelConnect.Size = new global::System.Drawing.Size(162, 18);
			this.labelConnect.TabIndex = 0;
			this.labelConnect.Text = "未接続";
			this.labelConnect.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.pictureBox14.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBox14.Image = global::Clock.Properties.Resources.icon_obi_000;
			this.pictureBox14.Location = new global::System.Drawing.Point(401, 0);
			this.pictureBox14.Name = "pictureBox14";
			this.pictureBox14.Size = new global::System.Drawing.Size(229, 42);
			this.pictureBox14.TabIndex = 1;
			this.pictureBox14.TabStop = false;
			this.splitContainer5.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer5.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer5.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer5.Name = "splitContainer5";
			this.splitContainer5.Panel1.AllowDrop = true;
			this.splitContainer5.Panel1.AutoScroll = true;
			this.splitContainer5.Panel1.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer5.Panel2.BackColor = global::System.Drawing.Color.FromArgb(159, 217, 211);
			this.splitContainer5.Size = new global::System.Drawing.Size(630, 584);
			this.splitContainer5.SplitterDistance = 517;
			this.splitContainer5.SplitterWidth = 5;
			this.splitContainer5.TabIndex = 0;
			this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.ファイルFToolStripMenuItem, this.編集EToolStripMenuItem, this.プログラムPToolStripMenuItem, this.表示VToolStripMenuItem, this.ネットワ\u30FCクNToolStripMenuItem, this.ヘルプHToolStripMenuItem, this.設定CToolStripMenuItem });
			this.menuStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new global::System.Drawing.Size(1008, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.新規作成NToolStripMenuItem, this.ファイルを開くOToolStripMenuItem, this.上書き保存SToolStripMenuItem, this.名前を付けて保存AToolStripMenuItem, this.終了XToolStripMenuItem });
			this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
			this.ファイルFToolStripMenuItem.Size = new global::System.Drawing.Size(67, 20);
			this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
			this.新規作成NToolStripMenuItem.Name = "新規作成NToolStripMenuItem";
			this.新規作成NToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.新規作成NToolStripMenuItem.Text = "新規作成(&N)";
			this.新規作成NToolStripMenuItem.Click += new global::System.EventHandler(this.新規作成NToolStripMenuItem_Click);
			this.ファイルを開くOToolStripMenuItem.Name = "ファイルを開くOToolStripMenuItem";
			this.ファイルを開くOToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.ファイルを開くOToolStripMenuItem.Text = "ファイルを開く(&O)";
			this.ファイルを開くOToolStripMenuItem.Click += new global::System.EventHandler(this.ファイルを開くOToolStripMenuItem_Click);
			this.上書き保存SToolStripMenuItem.Name = "上書き保存SToolStripMenuItem";
			this.上書き保存SToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.上書き保存SToolStripMenuItem.Text = "上書き保存(&S)";
			this.上書き保存SToolStripMenuItem.Click += new global::System.EventHandler(this.上書き保存SToolStripMenuItem_Click);
			this.名前を付けて保存AToolStripMenuItem.Name = "名前を付けて保存AToolStripMenuItem";
			this.名前を付けて保存AToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.名前を付けて保存AToolStripMenuItem.Text = "名前を付けて保存(&A)";
			this.名前を付けて保存AToolStripMenuItem.Click += new global::System.EventHandler(this.名前を付けて保存AToolStripMenuItem_Click);
			this.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem";
			this.終了XToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.終了XToolStripMenuItem.Text = "終了(&X)";
			this.終了XToolStripMenuItem.Click += new global::System.EventHandler(this.終了XToolStripMenuItem_Click);
			this.編集EToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.元に戻すUToolStripMenuItem, this.やり直しRToolStripMenuItem, this.切り取りTToolStripMenuItem, this.コピ\u30FCCToolStripMenuItem, this.貼り付けPToolStripMenuItem, this.削除DToolStripMenuItem, this.すべて選択AToolStripMenuItem });
			this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
			this.編集EToolStripMenuItem.Size = new global::System.Drawing.Size(57, 20);
			this.編集EToolStripMenuItem.Text = "編集(&E)";
			this.元に戻すUToolStripMenuItem.Name = "元に戻すUToolStripMenuItem";
			this.元に戻すUToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131162;
			this.元に戻すUToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.元に戻すUToolStripMenuItem.Text = "元に戻す(&U)";
			this.元に戻すUToolStripMenuItem.Click += new global::System.EventHandler(this.元に戻すUToolStripMenuItem_Click);
			this.やり直しRToolStripMenuItem.Name = "やり直しRToolStripMenuItem";
			this.やり直しRToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131161;
			this.やり直しRToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.やり直しRToolStripMenuItem.Text = "やり直し(&R)";
			this.やり直しRToolStripMenuItem.Click += new global::System.EventHandler(this.やり直しRToolStripMenuItem_Click);
			this.切り取りTToolStripMenuItem.Name = "切り取りTToolStripMenuItem";
			this.切り取りTToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131160;
			this.切り取りTToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.切り取りTToolStripMenuItem.Text = "切り取り(&T)";
			this.切り取りTToolStripMenuItem.Click += new global::System.EventHandler(this.切り取りTToolStripMenuItem_Click);
			this.コピ\u30FCCToolStripMenuItem.Name = "コピーCToolStripMenuItem";
			this.コピ\u30FCCToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131139;
			this.コピ\u30FCCToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.コピ\u30FCCToolStripMenuItem.Text = "コピー(&C)";
			this.コピ\u30FCCToolStripMenuItem.Click += new global::System.EventHandler(this.コピ\u30FCCToolStripMenuItem_Click);
			this.貼り付けPToolStripMenuItem.Name = "貼り付けPToolStripMenuItem";
			this.貼り付けPToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131158;
			this.貼り付けPToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.貼り付けPToolStripMenuItem.Text = "貼り付け(&P)";
			this.貼り付けPToolStripMenuItem.Click += new global::System.EventHandler(this.貼り付けPToolStripMenuItem_Click);
			this.削除DToolStripMenuItem.Name = "削除DToolStripMenuItem";
			this.削除DToolStripMenuItem.ShortcutKeys = global::System.Windows.Forms.Keys.Delete;
			this.削除DToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.削除DToolStripMenuItem.Text = "削除(&D)";
			this.削除DToolStripMenuItem.Click += new global::System.EventHandler(this.削除DToolStripMenuItem_Click);
			this.すべて選択AToolStripMenuItem.Name = "すべて選択AToolStripMenuItem";
			this.すべて選択AToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131137;
			this.すべて選択AToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.すべて選択AToolStripMenuItem.Text = "すべて選択(&A)";
			this.すべて選択AToolStripMenuItem.Click += new global::System.EventHandler(this.すべて選択AToolStripMenuItem_Click);
			this.プログラムPToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.プログラム実行EToolStripMenuItem, this.通信エラ\u30FCでプログラムを停止するIToolStripMenuItem });
			this.プログラムPToolStripMenuItem.Name = "プログラムPToolStripMenuItem";
			this.プログラムPToolStripMenuItem.Size = new global::System.Drawing.Size(78, 20);
			this.プログラムPToolStripMenuItem.Text = "プログラム(&P)";
			this.プログラム実行EToolStripMenuItem.Name = "プログラム実行EToolStripMenuItem";
			this.プログラム実行EToolStripMenuItem.Size = new global::System.Drawing.Size(240, 22);
			this.プログラム実行EToolStripMenuItem.Text = "プログラム実行(&E)";
			this.プログラム実行EToolStripMenuItem.Click += new global::System.EventHandler(this.プログラム実行EToolStripMenuItem_Click);
			this.通信エラ\u30FCでプログラムを停止するIToolStripMenuItem.Checked = true;
			this.通信エラ\u30FCでプログラムを停止するIToolStripMenuItem.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.通信エラ\u30FCでプログラムを停止するIToolStripMenuItem.Name = "通信エラーでプログラムを停止するIToolStripMenuItem";
			this.通信エラ\u30FCでプログラムを停止するIToolStripMenuItem.Size = new global::System.Drawing.Size(240, 22);
			this.通信エラ\u30FCでプログラムを停止するIToolStripMenuItem.Text = "通信エラーでプログラムを停止する(&I)";
			this.通信エラ\u30FCでプログラムを停止するIToolStripMenuItem.Click += new global::System.EventHandler(this.通信エラ\u30FCでプログラムを停止するIToolStripMenuItem_Click);
			this.表示VToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.レポ\u30FCト作成RToolStripMenuItem, this.グリッドGToolStripMenuItem, this.toolStripMenuItem1, this.プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem, this.プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem, this.パラメ\u30FCタ表示DToolStripMenuItem, this.デ\u30FCタ設定DToolStripMenuItem, this.各種情報表示ToolStripMenuItem, this.選択メニュ\u30FC表示EToolStripMenuItem });
			this.表示VToolStripMenuItem.Name = "表示VToolStripMenuItem";
			this.表示VToolStripMenuItem.Size = new global::System.Drawing.Size(58, 20);
			this.表示VToolStripMenuItem.Text = "表示(&V)";
			this.レポ\u30FCト作成RToolStripMenuItem.Name = "レポート作成RToolStripMenuItem";
			this.レポ\u30FCト作成RToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.レポ\u30FCト作成RToolStripMenuItem.Text = "レポート作成(&R)";
			this.レポ\u30FCト作成RToolStripMenuItem.Click += new global::System.EventHandler(this.レポ\u30FCト作成RToolStripMenuItem_Click);
			this.グリッドGToolStripMenuItem.Checked = true;
			this.グリッドGToolStripMenuItem.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.グリッドGToolStripMenuItem.Name = "グリッドGToolStripMenuItem";
			this.グリッドGToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.グリッドGToolStripMenuItem.Text = "グリッド(&G)";
			this.グリッドGToolStripMenuItem.Click += new global::System.EventHandler(this.グリッドGToolStripMenuItem_Click);
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new global::System.Drawing.Size(253, 22);
			this.toolStripMenuItem1.Text = "ブロックへ切換(&I)";
			this.toolStripMenuItem1.Click += new global::System.EventHandler(this.toolStripMenuItem1_Click);
			this.プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem.Name = "プログラムのスクリーンショットをコピーCToolStripMenuItem";
			this.プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem.Text = "プログラムのスクリーンショットをコピー(&C)";
			this.プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem.Click += new global::System.EventHandler(this.プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem_Click);
			this.プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem.Name = "プログラムのスクリーンショットを保存VToolStripMenuItem";
			this.プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem.Text = "プログラムのスクリーンショットを保存(&V)";
			this.プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem.Click += new global::System.EventHandler(this.プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem_Click);
			this.パラメ\u30FCタ表示DToolStripMenuItem.Checked = true;
			this.パラメ\u30FCタ表示DToolStripMenuItem.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.パラメ\u30FCタ表示DToolStripMenuItem.Name = "パラメータ表示DToolStripMenuItem";
			this.パラメ\u30FCタ表示DToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.パラメ\u30FCタ表示DToolStripMenuItem.Text = "パラメータ表示(&P)";
			this.パラメ\u30FCタ表示DToolStripMenuItem.Click += new global::System.EventHandler(this.パラメ\u30FCタ表示DToolStripMenuItem_Click);
			this.デ\u30FCタ設定DToolStripMenuItem.Name = "データ設定DToolStripMenuItem";
			this.デ\u30FCタ設定DToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.デ\u30FCタ設定DToolStripMenuItem.Text = "データ設定(&D)";
			this.デ\u30FCタ設定DToolStripMenuItem.Click += new global::System.EventHandler(this.デ\u30FCタ設定DToolStripMenuItem_Click);
			this.各種情報表示ToolStripMenuItem.Checked = true;
			this.各種情報表示ToolStripMenuItem.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.各種情報表示ToolStripMenuItem.Name = "各種情報表示ToolStripMenuItem";
			this.各種情報表示ToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.各種情報表示ToolStripMenuItem.Text = "各種情報表示（実行画面）(&I)";
			this.各種情報表示ToolStripMenuItem.Click += new global::System.EventHandler(this.各種情報表示ToolStripMenuItem_Click);
			this.ネットワ\u30FCクNToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.サ\u30FCバ\u30FCクライアント設定NToolStripMenuItem, this.通信チェックCToolStripMenuItem, this.ポ\u30FCト番号指定PToolStripMenuItem, this.サ\u30FCバデ\u30FCタの情報を共有するSToolStripMenuItem });
			this.ネットワ\u30FCクNToolStripMenuItem.Name = "ネットワークNToolStripMenuItem";
			this.ネットワ\u30FCクNToolStripMenuItem.Size = new global::System.Drawing.Size(88, 20);
			this.ネットワ\u30FCクNToolStripMenuItem.Text = "ネットワーク(&N)";
			this.サ\u30FCバ\u30FCクライアント設定NToolStripMenuItem.Name = "サーバークライアント設定NToolStripMenuItem";
			this.サ\u30FCバ\u30FCクライアント設定NToolStripMenuItem.Size = new global::System.Drawing.Size(228, 22);
			this.サ\u30FCバ\u30FCクライアント設定NToolStripMenuItem.Text = "サーバ/クライアント設定(&N)";
			this.サ\u30FCバ\u30FCクライアント設定NToolStripMenuItem.Click += new global::System.EventHandler(this.サ\u30FCバ\u30FCクライアント設定NToolStripMenuItem_Click);
			this.通信チェックCToolStripMenuItem.Name = "通信チェックCToolStripMenuItem";
			this.通信チェックCToolStripMenuItem.Size = new global::System.Drawing.Size(228, 22);
			this.通信チェックCToolStripMenuItem.Text = "通信チェック(&C)";
			this.通信チェックCToolStripMenuItem.Click += new global::System.EventHandler(this.通信チェックCToolStripMenuItem_Click);
			this.ポ\u30FCト番号指定PToolStripMenuItem.Name = "ポート番号指定PToolStripMenuItem";
			this.ポ\u30FCト番号指定PToolStripMenuItem.Size = new global::System.Drawing.Size(228, 22);
			this.ポ\u30FCト番号指定PToolStripMenuItem.Text = "ポート番号指定(&P)";
			this.ポ\u30FCト番号指定PToolStripMenuItem.Click += new global::System.EventHandler(this.ポ\u30FCト番号指定PToolStripMenuItem_Click);
			this.ヘルプHToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.ヘルプ表示BToolStripMenuItem, this.バ\u30FCジョン情報VToolStripMenuItem });
			this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
			this.ヘルプHToolStripMenuItem.Size = new global::System.Drawing.Size(65, 20);
			this.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
			this.ヘルプ表示BToolStripMenuItem.Name = "ヘルプ表示BToolStripMenuItem";
			this.ヘルプ表示BToolStripMenuItem.Size = new global::System.Drawing.Size(157, 22);
			this.ヘルプ表示BToolStripMenuItem.Text = "ヘルプ表示(&B)";
			this.ヘルプ表示BToolStripMenuItem.Click += new global::System.EventHandler(this.ヘルプ表示BToolStripMenuItem_Click);
			this.バ\u30FCジョン情報VToolStripMenuItem.Name = "バージョン情報VToolStripMenuItem";
			this.バ\u30FCジョン情報VToolStripMenuItem.Size = new global::System.Drawing.Size(157, 22);
			this.バ\u30FCジョン情報VToolStripMenuItem.Text = "バージョン情報(&V)";
			this.バ\u30FCジョン情報VToolStripMenuItem.Click += new global::System.EventHandler(this.バ\u30FCジョン情報VToolStripMenuItem_Click);
			this.設定CToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.外部入出力に対応UToolStripMenuItem });
			this.設定CToolStripMenuItem.Name = "設定CToolStripMenuItem";
			this.設定CToolStripMenuItem.Size = new global::System.Drawing.Size(58, 20);
			this.設定CToolStripMenuItem.Text = "設定(&C)";
			this.外部入出力に対応UToolStripMenuItem.Checked = true;
			this.外部入出力に対応UToolStripMenuItem.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.外部入出力に対応UToolStripMenuItem.Name = "外部入出力に対応UToolStripMenuItem";
			this.外部入出力に対応UToolStripMenuItem.Size = new global::System.Drawing.Size(183, 22);
			this.外部入出力に対応UToolStripMenuItem.Text = "外部入出力に対応(&U)";
			this.外部入出力に対応UToolStripMenuItem.Click += new global::System.EventHandler(this.外部入出力に対応UToolStripMenuItem_Click);
			this.contextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.元に戻すToolStripMenuItem, this.やり直しToolStripMenuItem, this.切り取りToolStripMenuItem, this.コピ\u30FCToolStripMenuItem, this.貼り付けToolStripMenuItem, this.削除ToolStripMenuItem, this.矢印を削除ToolStripMenuItem, this.整列ToolStripMenuItem, this.すべて選択ToolStripMenuItem });
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(132, 202);
			this.元に戻すToolStripMenuItem.Name = "元に戻すToolStripMenuItem";
			this.元に戻すToolStripMenuItem.Size = new global::System.Drawing.Size(131, 22);
			this.元に戻すToolStripMenuItem.Text = "元に戻す";
			this.元に戻すToolStripMenuItem.Click += new global::System.EventHandler(this.元に戻すUToolStripMenuItem_Click);
			this.やり直しToolStripMenuItem.Name = "やり直しToolStripMenuItem";
			this.やり直しToolStripMenuItem.Size = new global::System.Drawing.Size(131, 22);
			this.やり直しToolStripMenuItem.Text = "やり直し";
			this.やり直しToolStripMenuItem.Click += new global::System.EventHandler(this.やり直しRToolStripMenuItem_Click);
			this.切り取りToolStripMenuItem.Name = "切り取りToolStripMenuItem";
			this.切り取りToolStripMenuItem.Size = new global::System.Drawing.Size(131, 22);
			this.切り取りToolStripMenuItem.Text = "切り取り";
			this.切り取りToolStripMenuItem.Click += new global::System.EventHandler(this.切り取りTToolStripMenuItem_Click);
			this.コピ\u30FCToolStripMenuItem.Name = "コピーToolStripMenuItem";
			this.コピ\u30FCToolStripMenuItem.Size = new global::System.Drawing.Size(131, 22);
			this.コピ\u30FCToolStripMenuItem.Text = "コピー";
			this.コピ\u30FCToolStripMenuItem.Click += new global::System.EventHandler(this.コピ\u30FCCToolStripMenuItem_Click);
			this.貼り付けToolStripMenuItem.Name = "貼り付けToolStripMenuItem";
			this.貼り付けToolStripMenuItem.Size = new global::System.Drawing.Size(131, 22);
			this.貼り付けToolStripMenuItem.Text = "貼り付け";
			this.貼り付けToolStripMenuItem.Click += new global::System.EventHandler(this.貼り付けPToolStripMenuItem_Click);
			this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
			this.削除ToolStripMenuItem.Size = new global::System.Drawing.Size(131, 22);
			this.削除ToolStripMenuItem.Text = "削除";
			this.削除ToolStripMenuItem.Click += new global::System.EventHandler(this.削除DToolStripMenuItem_Click);
			this.矢印を削除ToolStripMenuItem.Name = "矢印を削除ToolStripMenuItem";
			this.矢印を削除ToolStripMenuItem.Size = new global::System.Drawing.Size(131, 22);
			this.矢印を削除ToolStripMenuItem.Text = "矢印を削除";
			this.矢印を削除ToolStripMenuItem.Click += new global::System.EventHandler(this.矢印を削除ToolStripMenuItem_Click);
			this.整列ToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.左揃えToolStripMenuItem, this.右揃えToolStripMenuItem, this.上揃えToolStripMenuItem, this.下揃えToolStripMenuItem });
			this.整列ToolStripMenuItem.Name = "整列ToolStripMenuItem";
			this.整列ToolStripMenuItem.Size = new global::System.Drawing.Size(131, 22);
			this.整列ToolStripMenuItem.Text = "整列";
			this.左揃えToolStripMenuItem.Name = "左揃えToolStripMenuItem";
			this.左揃えToolStripMenuItem.Size = new global::System.Drawing.Size(107, 22);
			this.左揃えToolStripMenuItem.Text = "左揃え";
			this.左揃えToolStripMenuItem.Click += new global::System.EventHandler(this.左揃えToolStripMenuItem_Click);
			this.右揃えToolStripMenuItem.Name = "右揃えToolStripMenuItem";
			this.右揃えToolStripMenuItem.Size = new global::System.Drawing.Size(107, 22);
			this.右揃えToolStripMenuItem.Text = "右揃え";
			this.右揃えToolStripMenuItem.Click += new global::System.EventHandler(this.右揃えToolStripMenuItem_Click);
			this.上揃えToolStripMenuItem.Name = "上揃えToolStripMenuItem";
			this.上揃えToolStripMenuItem.Size = new global::System.Drawing.Size(107, 22);
			this.上揃えToolStripMenuItem.Text = "上揃え";
			this.上揃えToolStripMenuItem.Click += new global::System.EventHandler(this.上揃えToolStripMenuItem_Click);
			this.下揃えToolStripMenuItem.Name = "下揃えToolStripMenuItem";
			this.下揃えToolStripMenuItem.Size = new global::System.Drawing.Size(107, 22);
			this.下揃えToolStripMenuItem.Text = "下揃え";
			this.下揃えToolStripMenuItem.Click += new global::System.EventHandler(this.下揃えToolStripMenuItem_Click);
			this.すべて選択ToolStripMenuItem.Name = "すべて選択ToolStripMenuItem";
			this.すべて選択ToolStripMenuItem.Size = new global::System.Drawing.Size(131, 22);
			this.すべて選択ToolStripMenuItem.Text = "すべて選択";
			this.すべて選択ToolStripMenuItem.Click += new global::System.EventHandler(this.すべて選択AToolStripMenuItem_Click);
			this.サ\u30FCバデ\u30FCタの情報を共有するSToolStripMenuItem.Checked = true;
			this.サ\u30FCバデ\u30FCタの情報を共有するSToolStripMenuItem.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.サ\u30FCバデ\u30FCタの情報を共有するSToolStripMenuItem.Name = "サーバデータの情報を共有するSToolStripMenuItem";
			this.サ\u30FCバデ\u30FCタの情報を共有するSToolStripMenuItem.Size = new global::System.Drawing.Size(228, 22);
			this.サ\u30FCバデ\u30FCタの情報を共有するSToolStripMenuItem.Text = "サーバデータの情報を共有する(&S)";
			this.サ\u30FCバデ\u30FCタの情報を共有するSToolStripMenuItem.Click += new global::System.EventHandler(this.サ\u30FCバデ\u30FCタの情報を共有するSToolStripMenuItem_Click);
			this.選択メニュ\u30FC表示EToolStripMenuItem.Checked = true;
			this.選択メニュ\u30FC表示EToolStripMenuItem.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.選択メニュ\u30FC表示EToolStripMenuItem.Name = "選択メニュー表示EToolStripMenuItem";
			this.選択メニュ\u30FC表示EToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.選択メニュ\u30FC表示EToolStripMenuItem.Text = "選択メニュー表示(&E)";
			this.選択メニュ\u30FC表示EToolStripMenuItem.Click += new global::System.EventHandler(this.選択メニュ\u30FC表示EToolStripMenuItem_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1008, 729);
			base.Controls.Add(this.splitContainer1);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.menuStrip1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MainMenuStrip = this.menuStrip1;
			base.Name = "NetworkWindow";
			this.Text = "ネットワークプログラム";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.NetworkWindow_FormClosing);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.NetworkWindow_FormClosed);
			base.Shown += new global::System.EventHandler(this.NetworkWindow_Shown);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.NetworkWindow_KeyDown);
			base.Resize += new global::System.EventHandler(this.NetworkWindow_Resize);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowRight).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxChange).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxConnection).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowLeft).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxNew).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxReport).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxOpen).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxRun).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxSave).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPaste).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxUndo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCopy).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxRedo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCut).EndInit();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer2).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer6.Panel1.ResumeLayout(false);
			this.splitContainer6.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer6).EndInit();
			this.splitContainer6.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer7).EndInit();
			this.splitContainer7.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer8).EndInit();
			this.splitContainer8.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer3).EndInit();
			this.splitContainer3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowDown).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockUsbOut).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLabel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockJump).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockIfElse).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockOutput).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockDisplay).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowUp).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockData).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockCommunication).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockIf).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLoopEnd).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLoopStart).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockWait).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockMessage).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockEvent).EndInit();
			this.splitContainer4.Panel1.ResumeLayout(false);
			this.splitContainer4.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer4).EndInit();
			this.splitContainer4.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox14).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer5).EndInit();
			this.splitContainer5.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000569 RID: 1385
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400056A RID: 1386
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x0400056B RID: 1387
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLog;

		// Token: 0x0400056C RID: 1388
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x0400056D RID: 1389
		private global::System.Windows.Forms.SplitContainer splitContainer2;

		// Token: 0x0400056E RID: 1390
		private global::System.Windows.Forms.PictureBox pictureBoxArrowRight;

		// Token: 0x0400056F RID: 1391
		private global::System.Windows.Forms.PictureBox pictureBoxArrowLeft;

		// Token: 0x04000570 RID: 1392
		private global::System.Windows.Forms.PictureBox pictureBoxConnection;

		// Token: 0x04000571 RID: 1393
		private global::System.Windows.Forms.PictureBox pictureBoxReport;

		// Token: 0x04000572 RID: 1394
		private global::System.Windows.Forms.PictureBox pictureBoxRun;

		// Token: 0x04000573 RID: 1395
		private global::System.Windows.Forms.PictureBox pictureBoxPaste;

		// Token: 0x04000574 RID: 1396
		private global::System.Windows.Forms.PictureBox pictureBoxCopy;

		// Token: 0x04000575 RID: 1397
		private global::System.Windows.Forms.PictureBox pictureBoxCut;

		// Token: 0x04000576 RID: 1398
		private global::System.Windows.Forms.PictureBox pictureBoxRedo;

		// Token: 0x04000577 RID: 1399
		private global::System.Windows.Forms.PictureBox pictureBoxUndo;

		// Token: 0x04000578 RID: 1400
		private global::System.Windows.Forms.PictureBox pictureBoxSave;

		// Token: 0x04000579 RID: 1401
		private global::System.Windows.Forms.PictureBox pictureBoxOpen;

		// Token: 0x0400057A RID: 1402
		private global::System.Windows.Forms.PictureBox pictureBoxNew;

		// Token: 0x0400057B RID: 1403
		private global::System.Windows.Forms.SplitContainer splitContainer3;

		// Token: 0x0400057C RID: 1404
		private global::System.Windows.Forms.PictureBox pictureBoxArrowDown;

		// Token: 0x0400057D RID: 1405
		private global::System.Windows.Forms.PictureBox pictureBoxBlockDisplay;

		// Token: 0x0400057E RID: 1406
		private global::System.Windows.Forms.PictureBox pictureBoxArrowUp;

		// Token: 0x0400057F RID: 1407
		private global::System.Windows.Forms.PictureBox pictureBoxBlockData;

		// Token: 0x04000580 RID: 1408
		private global::System.Windows.Forms.PictureBox pictureBoxBlockCommunication;

		// Token: 0x04000581 RID: 1409
		private global::System.Windows.Forms.PictureBox pictureBoxBlockIf;

		// Token: 0x04000582 RID: 1410
		private global::System.Windows.Forms.PictureBox pictureBoxBlockLoopEnd;

		// Token: 0x04000583 RID: 1411
		private global::System.Windows.Forms.PictureBox pictureBoxBlockLoopStart;

		// Token: 0x04000584 RID: 1412
		private global::System.Windows.Forms.PictureBox pictureBoxBlockWait;

		// Token: 0x04000585 RID: 1413
		private global::System.Windows.Forms.PictureBox pictureBoxBlockMessage;

		// Token: 0x04000586 RID: 1414
		private global::System.Windows.Forms.PictureBox pictureBoxBlockEvent;

		// Token: 0x04000587 RID: 1415
		private global::System.Windows.Forms.SplitContainer splitContainer4;

		// Token: 0x04000588 RID: 1416
		private global::System.Windows.Forms.PictureBox pictureBox14;

		// Token: 0x04000589 RID: 1417
		private global::System.Windows.Forms.SplitContainer splitContainer5;

		// Token: 0x0400058A RID: 1418
		private global::System.Windows.Forms.MenuStrip menuStrip1;

		// Token: 0x0400058B RID: 1419
		private global::System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;

		// Token: 0x0400058C RID: 1420
		private global::System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;

		// Token: 0x0400058D RID: 1421
		private global::System.Windows.Forms.ToolStripMenuItem プログラムPToolStripMenuItem;

		// Token: 0x0400058E RID: 1422
		private global::System.Windows.Forms.ToolStripMenuItem 表示VToolStripMenuItem;

		// Token: 0x0400058F RID: 1423
		private global::System.Windows.Forms.ToolStripMenuItem ネットワ\u30FCクNToolStripMenuItem;

		// Token: 0x04000590 RID: 1424
		private global::System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;

		// Token: 0x04000591 RID: 1425
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x04000592 RID: 1426
		private global::System.Windows.Forms.ToolStripMenuItem 元に戻すToolStripMenuItem;

		// Token: 0x04000593 RID: 1427
		private global::System.Windows.Forms.ToolStripMenuItem やり直しToolStripMenuItem;

		// Token: 0x04000594 RID: 1428
		private global::System.Windows.Forms.ToolStripMenuItem 切り取りToolStripMenuItem;

		// Token: 0x04000595 RID: 1429
		private global::System.Windows.Forms.ToolStripMenuItem コピ\u30FCToolStripMenuItem;

		// Token: 0x04000596 RID: 1430
		private global::System.Windows.Forms.ToolStripMenuItem 貼り付けToolStripMenuItem;

		// Token: 0x04000597 RID: 1431
		private global::System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;

		// Token: 0x04000598 RID: 1432
		private global::System.Windows.Forms.ToolStripMenuItem 矢印を削除ToolStripMenuItem;

		// Token: 0x04000599 RID: 1433
		private global::System.Windows.Forms.ToolStripMenuItem 整列ToolStripMenuItem;

		// Token: 0x0400059A RID: 1434
		private global::System.Windows.Forms.ToolStripMenuItem すべて選択ToolStripMenuItem;

		// Token: 0x0400059B RID: 1435
		private global::System.Windows.Forms.SplitContainer splitContainer6;

		// Token: 0x0400059C RID: 1436
		private global::System.Windows.Forms.SplitContainer splitContainer7;

		// Token: 0x0400059D RID: 1437
		private global::System.Windows.Forms.SplitContainer splitContainer8;

		// Token: 0x0400059E RID: 1438
		private global::System.Windows.Forms.ToolStripMenuItem 新規作成NToolStripMenuItem;

		// Token: 0x0400059F RID: 1439
		private global::System.Windows.Forms.ToolStripMenuItem ファイルを開くOToolStripMenuItem;

		// Token: 0x040005A0 RID: 1440
		private global::System.Windows.Forms.ToolStripMenuItem 上書き保存SToolStripMenuItem;

		// Token: 0x040005A1 RID: 1441
		private global::System.Windows.Forms.ToolStripMenuItem 名前を付けて保存AToolStripMenuItem;

		// Token: 0x040005A2 RID: 1442
		private global::System.Windows.Forms.ToolStripMenuItem 終了XToolStripMenuItem;

		// Token: 0x040005A3 RID: 1443
		private global::System.Windows.Forms.ToolStripMenuItem 元に戻すUToolStripMenuItem;

		// Token: 0x040005A4 RID: 1444
		private global::System.Windows.Forms.ToolStripMenuItem やり直しRToolStripMenuItem;

		// Token: 0x040005A5 RID: 1445
		private global::System.Windows.Forms.ToolStripMenuItem 切り取りTToolStripMenuItem;

		// Token: 0x040005A6 RID: 1446
		private global::System.Windows.Forms.ToolStripMenuItem コピ\u30FCCToolStripMenuItem;

		// Token: 0x040005A7 RID: 1447
		private global::System.Windows.Forms.ToolStripMenuItem 貼り付けPToolStripMenuItem;

		// Token: 0x040005A8 RID: 1448
		private global::System.Windows.Forms.ToolStripMenuItem 削除DToolStripMenuItem;

		// Token: 0x040005A9 RID: 1449
		private global::System.Windows.Forms.ToolStripMenuItem すべて選択AToolStripMenuItem;

		// Token: 0x040005AA RID: 1450
		private global::System.Windows.Forms.ToolStripMenuItem プログラム実行EToolStripMenuItem;

		// Token: 0x040005AB RID: 1451
		private global::System.Windows.Forms.ToolStripMenuItem レポ\u30FCト作成RToolStripMenuItem;

		// Token: 0x040005AC RID: 1452
		private global::System.Windows.Forms.ToolStripMenuItem グリッドGToolStripMenuItem;

		// Token: 0x040005AD RID: 1453
		private global::System.Windows.Forms.ToolStripMenuItem プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem;

		// Token: 0x040005AE RID: 1454
		private global::System.Windows.Forms.ToolStripMenuItem プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem;

		// Token: 0x040005AF RID: 1455
		private global::System.Windows.Forms.ToolStripMenuItem パラメ\u30FCタ表示DToolStripMenuItem;

		// Token: 0x040005B0 RID: 1456
		private global::System.Windows.Forms.ToolStripMenuItem デ\u30FCタ設定DToolStripMenuItem;

		// Token: 0x040005B1 RID: 1457
		private global::System.Windows.Forms.ToolStripMenuItem サ\u30FCバ\u30FCクライアント設定NToolStripMenuItem;

		// Token: 0x040005B2 RID: 1458
		private global::System.Windows.Forms.ToolStripMenuItem 通信チェックCToolStripMenuItem;

		// Token: 0x040005B3 RID: 1459
		private global::System.Windows.Forms.ToolStripMenuItem ポ\u30FCト番号指定PToolStripMenuItem;

		// Token: 0x040005B4 RID: 1460
		private global::System.Windows.Forms.ToolStripMenuItem ヘルプ表示BToolStripMenuItem;

		// Token: 0x040005B5 RID: 1461
		private global::System.Windows.Forms.ToolStripMenuItem バ\u30FCジョン情報VToolStripMenuItem;

		// Token: 0x040005B6 RID: 1462
		private global::System.Windows.Forms.PictureBox pictureBoxBlockOutput;

		// Token: 0x040005B7 RID: 1463
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040005B8 RID: 1464
		private global::System.Windows.Forms.Label labelServer;

		// Token: 0x040005B9 RID: 1465
		private global::System.Windows.Forms.Label labelConnect;

		// Token: 0x040005BA RID: 1466
		private global::System.Windows.Forms.ComboBox comboBoxLevel;

		// Token: 0x040005BB RID: 1467
		private global::System.Windows.Forms.ToolStripMenuItem 左揃えToolStripMenuItem;

		// Token: 0x040005BC RID: 1468
		private global::System.Windows.Forms.ToolStripMenuItem 右揃えToolStripMenuItem;

		// Token: 0x040005BD RID: 1469
		private global::System.Windows.Forms.ToolStripMenuItem 上揃えToolStripMenuItem;

		// Token: 0x040005BE RID: 1470
		private global::System.Windows.Forms.ToolStripMenuItem 下揃えToolStripMenuItem;

		// Token: 0x040005BF RID: 1471
		private global::System.Windows.Forms.ToolStripMenuItem 各種情報表示ToolStripMenuItem;

		// Token: 0x040005C0 RID: 1472
		private global::System.Windows.Forms.PictureBox pictureBoxBlockLabel;

		// Token: 0x040005C1 RID: 1473
		private global::System.Windows.Forms.PictureBox pictureBoxBlockJump;

		// Token: 0x040005C2 RID: 1474
		private global::System.Windows.Forms.PictureBox pictureBoxBlockIfElse;

		// Token: 0x040005C3 RID: 1475
		private global::System.Windows.Forms.PictureBox pictureBoxChange;

		// Token: 0x040005C4 RID: 1476
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

		// Token: 0x040005C5 RID: 1477
		private global::System.Windows.Forms.ToolStripMenuItem 通信エラ\u30FCでプログラムを停止するIToolStripMenuItem;

		// Token: 0x040005C6 RID: 1478
		private global::System.Windows.Forms.PictureBox pictureBoxBlockUsbOut;

		// Token: 0x040005C7 RID: 1479
		private global::System.Windows.Forms.ToolStripMenuItem 設定CToolStripMenuItem;

		// Token: 0x040005C8 RID: 1480
		private global::System.Windows.Forms.ToolStripMenuItem 外部入出力に対応UToolStripMenuItem;

		// Token: 0x040005C9 RID: 1481
		private global::System.Windows.Forms.ToolStripMenuItem サ\u30FCバデ\u30FCタの情報を共有するSToolStripMenuItem;

		// Token: 0x040005CA RID: 1482
		private global::System.Windows.Forms.ToolStripMenuItem 選択メニュ\u30FC表示EToolStripMenuItem;
	}
}
