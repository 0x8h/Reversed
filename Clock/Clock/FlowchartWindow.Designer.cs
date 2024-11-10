namespace Clock
{
	// Token: 0x02000022 RID: 34
	public partial class FlowchartWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x0600035F RID: 863 RVA: 0x000293E5 File Offset: 0x000275E5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00029404 File Offset: 0x00027604
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Clock.FlowchartWindow));
			this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
			this.ファイルToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.新規作成ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ファイルを開くToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.上書き保存ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.名前を付けて保存ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.終了ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.編集ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.元に戻すToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.やり直すToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.切り取りToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.コピ\u30FCToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.貼り付けToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.削除ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.すべて選択ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.プログラムToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.プログラム書込みToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.プログラム読込みToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.プログラム実行ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.プログラム停止ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.表示ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.シミュレ\u30FCト画面ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.レポ\u30FCト作成ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.情報ウィンドウToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.プログラムToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.グリッドToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.アイコンへ切換ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.パラメ\u30FCタ表示DToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ヘルプToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ヘルプ表示ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.バ\u30FCジョン情報ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.設定CToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.外部入出力に対応UToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelUsedMemory = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelLog = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxArrowRight = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxArrowLeft = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxConnection = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxReport = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxChange = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxStop = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxRun = new global::System.Windows.Forms.PictureBox();
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
			this.pictureBoxArrowDown = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockUsbOut = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockLabel = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockJump = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockIfElse = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockDisplay = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxArrowUp = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockArithmetic = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockSubroutine = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockIf = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockCounter = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockLoopEnd = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockLoopStart = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockWait = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockSound = new global::System.Windows.Forms.PictureBox();
			this.pictureBoxBlockLED = new global::System.Windows.Forms.PictureBox();
			this.splitContainer3 = new global::System.Windows.Forms.SplitContainer();
			this.pictureBoxObi = new global::System.Windows.Forms.PictureBox();
			this.splitContainer4 = new global::System.Windows.Forms.SplitContainer();
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.元に戻すToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.やり直しToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.切り取りToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.コピ\u30FCToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.貼り付けToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.削除ToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.矢印を削除ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.整列ToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.左揃えToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.右揃えToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.上揃えToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.下揃えToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.すべて選択ToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.選択メニュ\u30FC表示EToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowRight).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowLeft).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxConnection).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxReport).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxChange).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxStop).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxRun).BeginInit();
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
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowDown).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockUsbOut).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLabel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockJump).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockIfElse).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockDisplay).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowUp).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockArithmetic).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockSubroutine).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockIf).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockCounter).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLoopEnd).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLoopStart).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockWait).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockSound).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLED).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer3).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer4).BeginInit();
			this.splitContainer4.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			base.SuspendLayout();
			this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.ファイルToolStripMenuItem, this.編集ToolStripMenuItem, this.プログラムToolStripMenuItem, this.表示ToolStripMenuItem, this.ヘルプToolStripMenuItem, this.設定CToolStripMenuItem });
			this.menuStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new global::System.Drawing.Size(1008, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.ファイルToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.新規作成ToolStripMenuItem, this.ファイルを開くToolStripMenuItem, this.上書き保存ToolStripMenuItem, this.名前を付けて保存ToolStripMenuItem, this.終了ToolStripMenuItem });
			this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
			this.ファイルToolStripMenuItem.Size = new global::System.Drawing.Size(67, 20);
			this.ファイルToolStripMenuItem.Text = "ファイル(&F)";
			this.新規作成ToolStripMenuItem.Name = "新規作成ToolStripMenuItem";
			this.新規作成ToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.新規作成ToolStripMenuItem.Text = "新規作成(&N)";
			this.新規作成ToolStripMenuItem.Click += new global::System.EventHandler(this.新規作成ToolStripMenuItem_Click);
			this.ファイルを開くToolStripMenuItem.Name = "ファイルを開くToolStripMenuItem";
			this.ファイルを開くToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.ファイルを開くToolStripMenuItem.Text = "ファイルを開く(&O)";
			this.ファイルを開くToolStripMenuItem.Click += new global::System.EventHandler(this.ファイルを開くToolStripMenuItem_Click);
			this.上書き保存ToolStripMenuItem.Name = "上書き保存ToolStripMenuItem";
			this.上書き保存ToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.上書き保存ToolStripMenuItem.Text = "上書き保存(&S)";
			this.上書き保存ToolStripMenuItem.Click += new global::System.EventHandler(this.上書き保存ToolStripMenuItem_Click);
			this.名前を付けて保存ToolStripMenuItem.Name = "名前を付けて保存ToolStripMenuItem";
			this.名前を付けて保存ToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.名前を付けて保存ToolStripMenuItem.Text = "名前を付けて保存(&A)";
			this.名前を付けて保存ToolStripMenuItem.Click += new global::System.EventHandler(this.名前を付けて保存ToolStripMenuItem_Click);
			this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
			this.終了ToolStripMenuItem.Size = new global::System.Drawing.Size(177, 22);
			this.終了ToolStripMenuItem.Text = "終了(&X)";
			this.終了ToolStripMenuItem.Click += new global::System.EventHandler(this.終了ToolStripMenuItem_Click);
			this.編集ToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.元に戻すToolStripMenuItem, this.やり直すToolStripMenuItem, this.切り取りToolStripMenuItem, this.コピ\u30FCToolStripMenuItem, this.貼り付けToolStripMenuItem, this.削除ToolStripMenuItem, this.すべて選択ToolStripMenuItem });
			this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
			this.編集ToolStripMenuItem.Size = new global::System.Drawing.Size(57, 20);
			this.編集ToolStripMenuItem.Text = "編集(&E)";
			this.元に戻すToolStripMenuItem.Name = "元に戻すToolStripMenuItem";
			this.元に戻すToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131162;
			this.元に戻すToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.元に戻すToolStripMenuItem.Text = "元に戻す(&U)";
			this.元に戻すToolStripMenuItem.Click += new global::System.EventHandler(this.元に戻すToolStripMenuItem_Click);
			this.やり直すToolStripMenuItem.Name = "やり直すToolStripMenuItem";
			this.やり直すToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131161;
			this.やり直すToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.やり直すToolStripMenuItem.Text = "やり直し(&R)";
			this.やり直すToolStripMenuItem.Click += new global::System.EventHandler(this.やり直すToolStripMenuItem_Click);
			this.切り取りToolStripMenuItem.Name = "切り取りToolStripMenuItem";
			this.切り取りToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131160;
			this.切り取りToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.切り取りToolStripMenuItem.Text = "切り取り(&T)";
			this.切り取りToolStripMenuItem.Click += new global::System.EventHandler(this.切り取りToolStripMenuItem_Click);
			this.コピ\u30FCToolStripMenuItem.Name = "コピーToolStripMenuItem";
			this.コピ\u30FCToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131139;
			this.コピ\u30FCToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.コピ\u30FCToolStripMenuItem.Text = "コピー(&C)";
			this.コピ\u30FCToolStripMenuItem.Click += new global::System.EventHandler(this.コピ\u30FCToolStripMenuItem_Click);
			this.貼り付けToolStripMenuItem.Name = "貼り付けToolStripMenuItem";
			this.貼り付けToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131158;
			this.貼り付けToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.貼り付けToolStripMenuItem.Text = "貼り付け(&P)";
			this.貼り付けToolStripMenuItem.Click += new global::System.EventHandler(this.貼り付けToolStripMenuItem_Click);
			this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
			this.削除ToolStripMenuItem.ShortcutKeys = global::System.Windows.Forms.Keys.Delete;
			this.削除ToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.削除ToolStripMenuItem.Text = "削除(&D)";
			this.削除ToolStripMenuItem.Click += new global::System.EventHandler(this.削除ToolStripMenuItem_Click);
			this.すべて選択ToolStripMenuItem.Name = "すべて選択ToolStripMenuItem";
			this.すべて選択ToolStripMenuItem.ShortcutKeys = (global::System.Windows.Forms.Keys)131137;
			this.すべて選択ToolStripMenuItem.Size = new global::System.Drawing.Size(184, 22);
			this.すべて選択ToolStripMenuItem.Text = "すべて選択(&A)";
			this.すべて選択ToolStripMenuItem.Click += new global::System.EventHandler(this.すべて選択ToolStripMenuItem_Click);
			this.プログラムToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.プログラム書込みToolStripMenuItem, this.プログラム読込みToolStripMenuItem, this.プログラム実行ToolStripMenuItem, this.プログラム停止ToolStripMenuItem });
			this.プログラムToolStripMenuItem.Name = "プログラムToolStripMenuItem";
			this.プログラムToolStripMenuItem.Size = new global::System.Drawing.Size(78, 20);
			this.プログラムToolStripMenuItem.Text = "プログラム(&P)";
			this.プログラム書込みToolStripMenuItem.Name = "プログラム書込みToolStripMenuItem";
			this.プログラム書込みToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.プログラム書込みToolStripMenuItem.Text = "プログラム書込み(&W)";
			this.プログラム書込みToolStripMenuItem.Click += new global::System.EventHandler(this.プログラム書込みToolStripMenuItem_Click);
			this.プログラム読込みToolStripMenuItem.Name = "プログラム読込みToolStripMenuItem";
			this.プログラム読込みToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.プログラム読込みToolStripMenuItem.Text = "プログラム読込み(&R)";
			this.プログラム読込みToolStripMenuItem.Click += new global::System.EventHandler(this.プログラム読込みToolStripMenuItem_Click);
			this.プログラム実行ToolStripMenuItem.Name = "プログラム実行ToolStripMenuItem";
			this.プログラム実行ToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.プログラム実行ToolStripMenuItem.Text = "プログラム実行(&E)";
			this.プログラム実行ToolStripMenuItem.Click += new global::System.EventHandler(this.プログラム実行ToolStripMenuItem_Click);
			this.プログラム停止ToolStripMenuItem.Name = "プログラム停止ToolStripMenuItem";
			this.プログラム停止ToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.プログラム停止ToolStripMenuItem.Text = "プログラム停止(&B)";
			this.プログラム停止ToolStripMenuItem.Click += new global::System.EventHandler(this.プログラム停止ToolStripMenuItem_Click);
			this.表示ToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.シミュレ\u30FCト画面ToolStripMenuItem, this.レポ\u30FCト作成ToolStripMenuItem, this.情報ウィンドウToolStripMenuItem, this.プログラムToolStripMenuItem1, this.グリッドToolStripMenuItem, this.アイコンへ切換ToolStripMenuItem, this.プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem, this.プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem, this.パラメ\u30FCタ表示DToolStripMenuItem, this.選択メニュ\u30FC表示EToolStripMenuItem });
			this.表示ToolStripMenuItem.Name = "表示ToolStripMenuItem";
			this.表示ToolStripMenuItem.Size = new global::System.Drawing.Size(58, 20);
			this.表示ToolStripMenuItem.Text = "表示(&V)";
			this.シミュレ\u30FCト画面ToolStripMenuItem.Name = "シミュレート画面ToolStripMenuItem";
			this.シミュレ\u30FCト画面ToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.シミュレ\u30FCト画面ToolStripMenuItem.Text = "シミュレート画面(&S)";
			this.シミュレ\u30FCト画面ToolStripMenuItem.Click += new global::System.EventHandler(this.シミュレ\u30FCト画面ToolStripMenuItem_Click);
			this.レポ\u30FCト作成ToolStripMenuItem.Name = "レポート作成ToolStripMenuItem";
			this.レポ\u30FCト作成ToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.レポ\u30FCト作成ToolStripMenuItem.Text = "レポート作成(&R)";
			this.レポ\u30FCト作成ToolStripMenuItem.Click += new global::System.EventHandler(this.レポ\u30FCト作成ToolStripMenuItem_Click);
			this.情報ウィンドウToolStripMenuItem.Name = "情報ウィンドウToolStripMenuItem";
			this.情報ウィンドウToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.情報ウィンドウToolStripMenuItem.Text = "情報ウィンドウ(&W)";
			this.情報ウィンドウToolStripMenuItem.Click += new global::System.EventHandler(this.情報ウィンドウToolStripMenuItem_Click);
			this.プログラムToolStripMenuItem1.Checked = true;
			this.プログラムToolStripMenuItem1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.プログラムToolStripMenuItem1.Name = "プログラムToolStripMenuItem1";
			this.プログラムToolStripMenuItem1.Size = new global::System.Drawing.Size(253, 22);
			this.プログラムToolStripMenuItem1.Text = "プログラム(&P)";
			this.プログラムToolStripMenuItem1.Click += new global::System.EventHandler(this.プログラムToolStripMenuItem1_Click);
			this.グリッドToolStripMenuItem.Checked = true;
			this.グリッドToolStripMenuItem.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.グリッドToolStripMenuItem.Name = "グリッドToolStripMenuItem";
			this.グリッドToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.グリッドToolStripMenuItem.Text = "グリッド(&G)";
			this.グリッドToolStripMenuItem.Click += new global::System.EventHandler(this.グリッドToolStripMenuItem_Click);
			this.アイコンへ切換ToolStripMenuItem.Name = "アイコンへ切換ToolStripMenuItem";
			this.アイコンへ切換ToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.アイコンへ切換ToolStripMenuItem.Text = "ブロックへ切替(&I)";
			this.アイコンへ切換ToolStripMenuItem.Click += new global::System.EventHandler(this.アイコンへ切換ToolStripMenuItem_Click);
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
			this.パラメ\u30FCタ表示DToolStripMenuItem.Text = "パラメータ表示(&D)";
			this.パラメ\u30FCタ表示DToolStripMenuItem.Click += new global::System.EventHandler(this.パラメ\u30FCタ表示DToolStripMenuItem_Click);
			this.ヘルプToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.ヘルプ表示ToolStripMenuItem, this.バ\u30FCジョン情報ToolStripMenuItem });
			this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
			this.ヘルプToolStripMenuItem.Size = new global::System.Drawing.Size(65, 20);
			this.ヘルプToolStripMenuItem.Text = "ヘルプ(&H)";
			this.ヘルプ表示ToolStripMenuItem.Name = "ヘルプ表示ToolStripMenuItem";
			this.ヘルプ表示ToolStripMenuItem.Size = new global::System.Drawing.Size(157, 22);
			this.ヘルプ表示ToolStripMenuItem.Text = "ヘルプ表示(&B)";
			this.ヘルプ表示ToolStripMenuItem.Click += new global::System.EventHandler(this.ヘルプ表示ToolStripMenuItem_Click);
			this.バ\u30FCジョン情報ToolStripMenuItem.Name = "バージョン情報ToolStripMenuItem";
			this.バ\u30FCジョン情報ToolStripMenuItem.Size = new global::System.Drawing.Size(157, 22);
			this.バ\u30FCジョン情報ToolStripMenuItem.Text = "バージョン情報(&V)";
			this.バ\u30FCジョン情報ToolStripMenuItem.Click += new global::System.EventHandler(this.バ\u30FCジョン情報ToolStripMenuItem_Click);
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
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.toolStripStatusLabelUsedMemory, this.toolStripStatusLabelLog });
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 705);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new global::System.Drawing.Size(1008, 24);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "メモリ消費 0/147";
			this.toolStripStatusLabelUsedMemory.BackColor = global::System.Drawing.SystemColors.Control;
			this.toolStripStatusLabelUsedMemory.BorderSides = global::System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.toolStripStatusLabelUsedMemory.Name = "toolStripStatusLabelUsedMemory";
			this.toolStripStatusLabelUsedMemory.Size = new global::System.Drawing.Size(92, 19);
			this.toolStripStatusLabelUsedMemory.Text = "メモリ消費 0/147";
			this.toolStripStatusLabelLog.BackColor = global::System.Drawing.SystemColors.Control;
			this.toolStripStatusLabelLog.Name = "toolStripStatusLabelLog";
			this.toolStripStatusLabelLog.Size = new global::System.Drawing.Size(49, 19);
			this.toolStripStatusLabelLog.Text = "ログ表示";
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new global::System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.BackColor = global::System.Drawing.Color.FromArgb(92, 87, 83);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxArrowRight);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxArrowLeft);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxConnection);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxReport);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxChange);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxStop);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBoxRun);
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
			this.splitContainer1.Size = new global::System.Drawing.Size(1008, 681);
			this.splitContainer1.SplitterDistance = 55;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 2;
			this.pictureBoxArrowRight.Image = global::Clock.Properties.Resources.icon_btn_210;
			this.pictureBoxArrowRight.Location = new global::System.Drawing.Point(951, 0);
			this.pictureBoxArrowRight.Name = "pictureBoxArrowRight";
			this.pictureBoxArrowRight.Size = new global::System.Drawing.Size(39, 54);
			this.pictureBoxArrowRight.TabIndex = 16;
			this.pictureBoxArrowRight.TabStop = false;
			this.pictureBoxArrowRight.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowRight_MouseDown);
			this.pictureBoxArrowRight.MouseEnter += new global::System.EventHandler(this.pictureBoxArrowRight_MouseEnter);
			this.pictureBoxArrowRight.MouseLeave += new global::System.EventHandler(this.pictureBoxArrowRight_MouseLeave);
			this.pictureBoxArrowRight.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxArrowRight_MouseUp);
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
			this.pictureBoxConnection.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxConnection.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxConnection.Image = global::Clock.Properties.Resources.icon_usb_off;
			this.pictureBoxConnection.Location = new global::System.Drawing.Point(958, 10);
			this.pictureBoxConnection.Name = "pictureBoxConnection";
			this.pictureBoxConnection.Size = new global::System.Drawing.Size(32, 35);
			this.pictureBoxConnection.TabIndex = 14;
			this.pictureBoxConnection.TabStop = false;
			this.pictureBoxReport.Image = global::Clock.Properties.Resources.icon_btn_120;
			this.pictureBoxReport.Location = new global::System.Drawing.Point(876, 5);
			this.pictureBoxReport.Name = "pictureBoxReport";
			this.pictureBoxReport.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxReport.TabIndex = 12;
			this.pictureBoxReport.TabStop = false;
			this.pictureBoxReport.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxReport_MouseDown);
			this.pictureBoxReport.MouseEnter += new global::System.EventHandler(this.pictureBoxReport_MouseEnter);
			this.pictureBoxReport.MouseLeave += new global::System.EventHandler(this.pictureBoxReport_MouseLeave);
			this.pictureBoxReport.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxReport_MouseUp);
			this.pictureBoxChange.Image = global::Clock.Properties.Resources.icon_btn_110;
			this.pictureBoxChange.Location = new global::System.Drawing.Point(804, 5);
			this.pictureBoxChange.Name = "pictureBoxChange";
			this.pictureBoxChange.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxChange.TabIndex = 11;
			this.pictureBoxChange.TabStop = false;
			this.pictureBoxChange.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxChange_MouseDown);
			this.pictureBoxChange.MouseEnter += new global::System.EventHandler(this.pictureBoxChange_MouseEnter);
			this.pictureBoxChange.MouseLeave += new global::System.EventHandler(this.pictureBoxChange_MouseLeave);
			this.pictureBoxChange.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxChange_MouseUp);
			this.pictureBoxStop.Image = global::Clock.Properties.Resources.icon_btn_100;
			this.pictureBoxStop.Location = new global::System.Drawing.Point(732, 5);
			this.pictureBoxStop.Name = "pictureBoxStop";
			this.pictureBoxStop.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxStop.TabIndex = 10;
			this.pictureBoxStop.TabStop = false;
			this.pictureBoxStop.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxStop_MouseDown);
			this.pictureBoxStop.MouseEnter += new global::System.EventHandler(this.pictureBoxStop_MouseEnter);
			this.pictureBoxStop.MouseLeave += new global::System.EventHandler(this.pictureBoxStop_MouseLeave);
			this.pictureBoxStop.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxStop_MouseUp);
			this.pictureBoxRun.Image = global::Clock.Properties.Resources.icon_btn_090;
			this.pictureBoxRun.Location = new global::System.Drawing.Point(660, 5);
			this.pictureBoxRun.Name = "pictureBoxRun";
			this.pictureBoxRun.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxRun.TabIndex = 9;
			this.pictureBoxRun.TabStop = false;
			this.pictureBoxRun.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxRun_MouseDown);
			this.pictureBoxRun.MouseEnter += new global::System.EventHandler(this.pictureBoxRun_MouseEnter);
			this.pictureBoxRun.MouseLeave += new global::System.EventHandler(this.pictureBoxRun_MouseLeave);
			this.pictureBoxRun.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxRun_MouseUp);
			this.pictureBoxWrite.Image = global::Clock.Properties.Resources.icon_btn_080;
			this.pictureBoxWrite.Location = new global::System.Drawing.Point(588, 5);
			this.pictureBoxWrite.Name = "pictureBoxWrite";
			this.pictureBoxWrite.Size = new global::System.Drawing.Size(66, 45);
			this.pictureBoxWrite.TabIndex = 8;
			this.pictureBoxWrite.TabStop = false;
			this.pictureBoxWrite.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxWrite_MouseDown);
			this.pictureBoxWrite.MouseEnter += new global::System.EventHandler(this.pictureBoxWrite_MouseEnter);
			this.pictureBoxWrite.MouseLeave += new global::System.EventHandler(this.pictureBoxWrite_MouseLeave);
			this.pictureBoxWrite.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxWrite_MouseUp);
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
			this.splitContainer2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Panel1.AllowDrop = true;
			this.splitContainer2.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxArrowDown);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockUsbOut);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockLabel);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockJump);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockIfElse);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockDisplay);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxArrowUp);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockArithmetic);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockSubroutine);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockIf);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockCounter);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockLoopEnd);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockLoopStart);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockWait);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockSound);
			this.splitContainer2.Panel1.Controls.Add(this.pictureBoxBlockLED);
			this.splitContainer2.Panel1.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.splitContainer2_Panel1_DragEnter);
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
			this.splitContainer2.Size = new global::System.Drawing.Size(1008, 625);
			this.splitContainer2.SplitterDistance = 91;
			this.splitContainer2.SplitterWidth = 1;
			this.splitContainer2.TabIndex = 0;
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
			this.pictureBoxBlockUsbOut.TabIndex = 16;
			this.pictureBoxBlockUsbOut.TabStop = false;
			this.pictureBoxBlockUsbOut.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockUsbOut_GiveFeedback);
			this.pictureBoxBlockUsbOut.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockUsbOut_QueryContinueDrag);
			this.pictureBoxBlockUsbOut.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockUsbOut_MouseDown);
			this.pictureBoxBlockUsbOut.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockUsbOut_MouseEnter);
			this.pictureBoxBlockUsbOut.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockUsbOut_MouseLeave);
			this.pictureBoxBlockLabel.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockLabel.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockLabel.Image = global::Clock.Properties.Resources.bp_btn_120;
			this.pictureBoxBlockLabel.Location = new global::System.Drawing.Point(4, 371);
			this.pictureBoxBlockLabel.Name = "pictureBoxBlockLabel";
			this.pictureBoxBlockLabel.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockLabel.TabIndex = 15;
			this.pictureBoxBlockLabel.TabStop = false;
			this.pictureBoxBlockLabel.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockLabel_GiveFeedback);
			this.pictureBoxBlockLabel.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockLabel_QueryContinueDrag);
			this.pictureBoxBlockLabel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockLabel_MouseDown);
			this.pictureBoxBlockLabel.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockLabel_MouseEnter);
			this.pictureBoxBlockLabel.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockLabel_MouseLeave);
			this.pictureBoxBlockJump.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockJump.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockJump.Image = global::Clock.Properties.Resources.bp_btn_110;
			this.pictureBoxBlockJump.Location = new global::System.Drawing.Point(5, 360);
			this.pictureBoxBlockJump.Name = "pictureBoxBlockJump";
			this.pictureBoxBlockJump.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockJump.TabIndex = 14;
			this.pictureBoxBlockJump.TabStop = false;
			this.pictureBoxBlockJump.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockJump_GiveFeedback);
			this.pictureBoxBlockJump.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockJump_QueryContinueDrag);
			this.pictureBoxBlockJump.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockJump_MouseDown);
			this.pictureBoxBlockJump.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockJump_MouseEnter);
			this.pictureBoxBlockJump.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockJump_MouseLeave);
			this.pictureBoxBlockIfElse.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockIfElse.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockIfElse.Image = global::Clock.Properties.Resources.bp_btn_060;
			this.pictureBoxBlockIfElse.Location = new global::System.Drawing.Point(5, 296);
			this.pictureBoxBlockIfElse.Name = "pictureBoxBlockIfElse";
			this.pictureBoxBlockIfElse.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockIfElse.TabIndex = 13;
			this.pictureBoxBlockIfElse.TabStop = false;
			this.pictureBoxBlockIfElse.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockIfElse_GiveFeedback);
			this.pictureBoxBlockIfElse.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockIfElse_QueryContinueDrag);
			this.pictureBoxBlockIfElse.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockIfElse_MouseDown);
			this.pictureBoxBlockIfElse.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockIfElse_MouseEnter);
			this.pictureBoxBlockIfElse.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockIfElse_MouseLeave);
			this.pictureBoxBlockDisplay.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockDisplay.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockDisplay.Image = global::Clock.Properties.Resources.fc_btn_040;
			this.pictureBoxBlockDisplay.Location = new global::System.Drawing.Point(5, 560);
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
			this.pictureBoxBlockArithmetic.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockArithmetic.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockArithmetic.Image = global::Clock.Properties.Resources.fc_btn_030;
			this.pictureBoxBlockArithmetic.Location = new global::System.Drawing.Point(5, 503);
			this.pictureBoxBlockArithmetic.Name = "pictureBoxBlockArithmetic";
			this.pictureBoxBlockArithmetic.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockArithmetic.TabIndex = 10;
			this.pictureBoxBlockArithmetic.TabStop = false;
			this.pictureBoxBlockArithmetic.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockArithmetic_GiveFeedback);
			this.pictureBoxBlockArithmetic.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockArithmetic_QueryContinueDrag);
			this.pictureBoxBlockArithmetic.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockArithmetic_MouseDown);
			this.pictureBoxBlockArithmetic.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockArithmetic_MouseEnter);
			this.pictureBoxBlockArithmetic.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockArithmetic_MouseLeave);
			this.pictureBoxBlockSubroutine.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockSubroutine.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockSubroutine.Image = global::Clock.Properties.Resources.fc_btn_020;
			this.pictureBoxBlockSubroutine.Location = new global::System.Drawing.Point(5, 446);
			this.pictureBoxBlockSubroutine.Name = "pictureBoxBlockSubroutine";
			this.pictureBoxBlockSubroutine.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockSubroutine.TabIndex = 9;
			this.pictureBoxBlockSubroutine.TabStop = false;
			this.pictureBoxBlockSubroutine.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockSubroutine_GiveFeedback);
			this.pictureBoxBlockSubroutine.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockSubroutine_QueryContinueDrag);
			this.pictureBoxBlockSubroutine.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockSubroutine_MouseDown);
			this.pictureBoxBlockSubroutine.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockSubroutine_MouseEnter);
			this.pictureBoxBlockSubroutine.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockSubroutine_MouseLeave);
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
			this.pictureBoxBlockCounter.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockCounter.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockCounter.Image = global::Clock.Properties.Resources.fc_btn_000;
			this.pictureBoxBlockCounter.Location = new global::System.Drawing.Point(5, 218);
			this.pictureBoxBlockCounter.Name = "pictureBoxBlockCounter";
			this.pictureBoxBlockCounter.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockCounter.TabIndex = 7;
			this.pictureBoxBlockCounter.TabStop = false;
			this.pictureBoxBlockCounter.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockCounter_GiveFeedback);
			this.pictureBoxBlockCounter.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockCounter_QueryContinueDrag);
			this.pictureBoxBlockCounter.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockCounter_MouseDown);
			this.pictureBoxBlockCounter.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockCounter_MouseEnter);
			this.pictureBoxBlockCounter.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockCounter_MouseLeave);
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
			this.pictureBoxBlockWait.Location = new global::System.Drawing.Point(5, 161);
			this.pictureBoxBlockWait.Name = "pictureBoxBlockWait";
			this.pictureBoxBlockWait.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockWait.TabIndex = 4;
			this.pictureBoxBlockWait.TabStop = false;
			this.pictureBoxBlockWait.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockWait_GiveFeedback);
			this.pictureBoxBlockWait.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockWait_QueryContinueDrag);
			this.pictureBoxBlockWait.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockWait_MouseDown);
			this.pictureBoxBlockWait.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockWait_MouseEnter);
			this.pictureBoxBlockWait.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockWait_MouseLeave);
			this.pictureBoxBlockSound.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockSound.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockSound.Image = global::Clock.Properties.Resources.icon_btn_140;
			this.pictureBoxBlockSound.Location = new global::System.Drawing.Point(5, 104);
			this.pictureBoxBlockSound.Name = "pictureBoxBlockSound";
			this.pictureBoxBlockSound.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockSound.TabIndex = 3;
			this.pictureBoxBlockSound.TabStop = false;
			this.pictureBoxBlockSound.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockSound_GiveFeedback);
			this.pictureBoxBlockSound.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockSound_QueryContinueDrag);
			this.pictureBoxBlockSound.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockSound_MouseDown);
			this.pictureBoxBlockSound.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockSound_MouseEnter);
			this.pictureBoxBlockSound.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockSound_MouseLeave);
			this.pictureBoxBlockLED.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBoxBlockLED.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.pictureBoxBlockLED.Image = global::Clock.Properties.Resources.icon_btn_130;
			this.pictureBoxBlockLED.Location = new global::System.Drawing.Point(5, 47);
			this.pictureBoxBlockLED.Name = "pictureBoxBlockLED";
			this.pictureBoxBlockLED.Size = new global::System.Drawing.Size(81, 47);
			this.pictureBoxBlockLED.TabIndex = 2;
			this.pictureBoxBlockLED.TabStop = false;
			this.pictureBoxBlockLED.GiveFeedback += new global::System.Windows.Forms.GiveFeedbackEventHandler(this.pictureBoxBlockLED_GiveFeedback);
			this.pictureBoxBlockLED.QueryContinueDrag += new global::System.Windows.Forms.QueryContinueDragEventHandler(this.pictureBoxBlockLED_QueryContinueDrag);
			this.pictureBoxBlockLED.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBoxBlockLED_MouseDown);
			this.pictureBoxBlockLED.MouseEnter += new global::System.EventHandler(this.pictureBoxBlockLED_MouseEnter);
			this.pictureBoxBlockLED.MouseLeave += new global::System.EventHandler(this.pictureBoxBlockLED_MouseLeave);
			this.splitContainer3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer3.IsSplitterFixed = true;
			this.splitContainer3.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer3.Panel1.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			this.splitContainer3.Panel1.Controls.Add(this.pictureBoxObi);
			this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
			this.splitContainer3.Size = new global::System.Drawing.Size(916, 625);
			this.splitContainer3.SplitterDistance = 42;
			this.splitContainer3.SplitterWidth = 1;
			this.splitContainer3.TabIndex = 0;
			this.pictureBoxObi.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pictureBoxObi.Image = global::Clock.Properties.Resources.icon_obi_000;
			this.pictureBoxObi.Location = new global::System.Drawing.Point(687, 0);
			this.pictureBoxObi.Name = "pictureBoxObi";
			this.pictureBoxObi.Size = new global::System.Drawing.Size(229, 42);
			this.pictureBoxObi.TabIndex = 1;
			this.pictureBoxObi.TabStop = false;
			this.splitContainer4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer4.Location = new global::System.Drawing.Point(0, 0);
			this.splitContainer4.Name = "splitContainer4";
			this.splitContainer4.Panel1.AllowDrop = true;
			this.splitContainer4.Panel1.AutoScroll = true;
			this.splitContainer4.Panel1.BackColor = global::System.Drawing.Color.FromArgb(247, 246, 229);
			this.splitContainer4.Panel2.BackColor = global::System.Drawing.Color.FromArgb(159, 217, 211);
			this.splitContainer4.Size = new global::System.Drawing.Size(916, 582);
			this.splitContainer4.SplitterDistance = 757;
			this.splitContainer4.SplitterWidth = 5;
			this.splitContainer4.TabIndex = 0;
			this.contextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.元に戻すToolStripMenuItem1, this.やり直しToolStripMenuItem, this.切り取りToolStripMenuItem1, this.コピ\u30FCToolStripMenuItem1, this.貼り付けToolStripMenuItem1, this.削除ToolStripMenuItem1, this.矢印を削除ToolStripMenuItem, this.整列ToolStripMenuItem, this.すべて選択ToolStripMenuItem1 });
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(132, 202);
			this.元に戻すToolStripMenuItem1.Name = "元に戻すToolStripMenuItem1";
			this.元に戻すToolStripMenuItem1.Size = new global::System.Drawing.Size(131, 22);
			this.元に戻すToolStripMenuItem1.Text = "元に戻す";
			this.元に戻すToolStripMenuItem1.Click += new global::System.EventHandler(this.元に戻すToolStripMenuItem_Click);
			this.やり直しToolStripMenuItem.Name = "やり直しToolStripMenuItem";
			this.やり直しToolStripMenuItem.Size = new global::System.Drawing.Size(131, 22);
			this.やり直しToolStripMenuItem.Text = "やり直し";
			this.やり直しToolStripMenuItem.Click += new global::System.EventHandler(this.やり直すToolStripMenuItem_Click);
			this.切り取りToolStripMenuItem1.Name = "切り取りToolStripMenuItem1";
			this.切り取りToolStripMenuItem1.Size = new global::System.Drawing.Size(131, 22);
			this.切り取りToolStripMenuItem1.Text = "切り取り";
			this.切り取りToolStripMenuItem1.Click += new global::System.EventHandler(this.切り取りToolStripMenuItem_Click);
			this.コピ\u30FCToolStripMenuItem1.Name = "コピーToolStripMenuItem1";
			this.コピ\u30FCToolStripMenuItem1.Size = new global::System.Drawing.Size(131, 22);
			this.コピ\u30FCToolStripMenuItem1.Text = "コピー";
			this.コピ\u30FCToolStripMenuItem1.Click += new global::System.EventHandler(this.コピ\u30FCToolStripMenuItem_Click);
			this.貼り付けToolStripMenuItem1.Name = "貼り付けToolStripMenuItem1";
			this.貼り付けToolStripMenuItem1.Size = new global::System.Drawing.Size(131, 22);
			this.貼り付けToolStripMenuItem1.Text = "貼り付け";
			this.貼り付けToolStripMenuItem1.Click += new global::System.EventHandler(this.貼り付けToolStripMenuItem_Click);
			this.削除ToolStripMenuItem1.Name = "削除ToolStripMenuItem1";
			this.削除ToolStripMenuItem1.Size = new global::System.Drawing.Size(131, 22);
			this.削除ToolStripMenuItem1.Text = "削除";
			this.削除ToolStripMenuItem1.Click += new global::System.EventHandler(this.削除ToolStripMenuItem_Click);
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
			this.すべて選択ToolStripMenuItem1.Name = "すべて選択ToolStripMenuItem1";
			this.すべて選択ToolStripMenuItem1.Size = new global::System.Drawing.Size(131, 22);
			this.すべて選択ToolStripMenuItem1.Text = "すべて選択";
			this.すべて選択ToolStripMenuItem1.Click += new global::System.EventHandler(this.すべて選択ToolStripMenuItem_Click);
			this.選択メニュ\u30FC表示EToolStripMenuItem.Checked = true;
			this.選択メニュ\u30FC表示EToolStripMenuItem.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.選択メニュ\u30FC表示EToolStripMenuItem.Name = "選択メニュー表示EToolStripMenuItem";
			this.選択メニュ\u30FC表示EToolStripMenuItem.Size = new global::System.Drawing.Size(253, 22);
			this.選択メニュ\u30FC表示EToolStripMenuItem.Text = "選択メニュー表示(&E)";
			this.選択メニュ\u30FC表示EToolStripMenuItem.Click += new global::System.EventHandler(this.選択メニュ\u30FC表示EToolStripMenuItem_Click);
			this.AllowDrop = true;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(182, 224, 224);
			base.ClientSize = new global::System.Drawing.Size(1008, 729);
			base.Controls.Add(this.splitContainer1);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.menuStrip1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MainMenuStrip = this.menuStrip1;
			base.Name = "FlowchartWindow";
			this.Text = "計測・制御プログラム";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FlowchartWindow_FormClosing);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.FlowchartWindow_FormClosed);
			base.Shown += new global::System.EventHandler(this.FlowchartWindow_Shown);
			base.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.FlowchartWindow_DragDrop);
			base.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.FlowchartWindow_DragEnter);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.FlowchartWindow_KeyDown);
			base.Resize += new global::System.EventHandler(this.FlowchartWindow_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowRight).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowLeft).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxConnection).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxReport).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxChange).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxStop).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxRun).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWrite).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxPaste).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCopy).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxCut).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxRedo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxUndo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxSave).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxOpen).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxNew).EndInit();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer2).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowDown).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockUsbOut).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLabel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockJump).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockIfElse).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockDisplay).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxArrowUp).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockArithmetic).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockSubroutine).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockIf).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockCounter).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLoopEnd).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLoopStart).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockWait).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockSound).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxBlockLED).EndInit();
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer3).EndInit();
			this.splitContainer3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxObi).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer4).EndInit();
			this.splitContainer4.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400026E RID: 622
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400026F RID: 623
		private global::System.Windows.Forms.MenuStrip menuStrip1;

		// Token: 0x04000270 RID: 624
		private global::System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;

		// Token: 0x04000271 RID: 625
		private global::System.Windows.Forms.ToolStripMenuItem 新規作成ToolStripMenuItem;

		// Token: 0x04000272 RID: 626
		private global::System.Windows.Forms.ToolStripMenuItem ファイルを開くToolStripMenuItem;

		// Token: 0x04000273 RID: 627
		private global::System.Windows.Forms.ToolStripMenuItem 上書き保存ToolStripMenuItem;

		// Token: 0x04000274 RID: 628
		private global::System.Windows.Forms.ToolStripMenuItem 名前を付けて保存ToolStripMenuItem;

		// Token: 0x04000275 RID: 629
		private global::System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;

		// Token: 0x04000276 RID: 630
		private global::System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;

		// Token: 0x04000277 RID: 631
		private global::System.Windows.Forms.ToolStripMenuItem 元に戻すToolStripMenuItem;

		// Token: 0x04000278 RID: 632
		private global::System.Windows.Forms.ToolStripMenuItem やり直すToolStripMenuItem;

		// Token: 0x04000279 RID: 633
		private global::System.Windows.Forms.ToolStripMenuItem 切り取りToolStripMenuItem;

		// Token: 0x0400027A RID: 634
		private global::System.Windows.Forms.ToolStripMenuItem コピ\u30FCToolStripMenuItem;

		// Token: 0x0400027B RID: 635
		private global::System.Windows.Forms.ToolStripMenuItem 貼り付けToolStripMenuItem;

		// Token: 0x0400027C RID: 636
		private global::System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;

		// Token: 0x0400027D RID: 637
		private global::System.Windows.Forms.ToolStripMenuItem すべて選択ToolStripMenuItem;

		// Token: 0x0400027E RID: 638
		private global::System.Windows.Forms.ToolStripMenuItem プログラムToolStripMenuItem;

		// Token: 0x0400027F RID: 639
		private global::System.Windows.Forms.ToolStripMenuItem プログラム書込みToolStripMenuItem;

		// Token: 0x04000280 RID: 640
		private global::System.Windows.Forms.ToolStripMenuItem プログラム読込みToolStripMenuItem;

		// Token: 0x04000281 RID: 641
		private global::System.Windows.Forms.ToolStripMenuItem プログラム実行ToolStripMenuItem;

		// Token: 0x04000282 RID: 642
		private global::System.Windows.Forms.ToolStripMenuItem プログラム停止ToolStripMenuItem;

		// Token: 0x04000283 RID: 643
		private global::System.Windows.Forms.ToolStripMenuItem 表示ToolStripMenuItem;

		// Token: 0x04000284 RID: 644
		private global::System.Windows.Forms.ToolStripMenuItem シミュレ\u30FCト画面ToolStripMenuItem;

		// Token: 0x04000285 RID: 645
		private global::System.Windows.Forms.ToolStripMenuItem レポ\u30FCト作成ToolStripMenuItem;

		// Token: 0x04000286 RID: 646
		private global::System.Windows.Forms.ToolStripMenuItem アイコンへ切換ToolStripMenuItem;

		// Token: 0x04000287 RID: 647
		private global::System.Windows.Forms.ToolStripMenuItem ヘルプToolStripMenuItem;

		// Token: 0x04000288 RID: 648
		private global::System.Windows.Forms.ToolStripMenuItem ヘルプ表示ToolStripMenuItem;

		// Token: 0x04000289 RID: 649
		private global::System.Windows.Forms.ToolStripMenuItem バ\u30FCジョン情報ToolStripMenuItem;

		// Token: 0x0400028A RID: 650
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x0400028B RID: 651
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUsedMemory;

		// Token: 0x0400028C RID: 652
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x0400028D RID: 653
		private global::System.Windows.Forms.SplitContainer splitContainer2;

		// Token: 0x0400028E RID: 654
		private global::System.Windows.Forms.SplitContainer splitContainer3;

		// Token: 0x0400028F RID: 655
		private global::System.Windows.Forms.SplitContainer splitContainer4;

		// Token: 0x04000290 RID: 656
		private global::System.Windows.Forms.ToolStripMenuItem 情報ウィンドウToolStripMenuItem;

		// Token: 0x04000291 RID: 657
		private global::System.Windows.Forms.ToolStripMenuItem プログラムToolStripMenuItem1;

		// Token: 0x04000292 RID: 658
		private global::System.Windows.Forms.ToolStripMenuItem グリッドToolStripMenuItem;

		// Token: 0x04000293 RID: 659
		private global::System.Windows.Forms.PictureBox pictureBoxNew;

		// Token: 0x04000294 RID: 660
		private global::System.Windows.Forms.PictureBox pictureBoxReport;

		// Token: 0x04000295 RID: 661
		private global::System.Windows.Forms.PictureBox pictureBoxChange;

		// Token: 0x04000296 RID: 662
		private global::System.Windows.Forms.PictureBox pictureBoxStop;

		// Token: 0x04000297 RID: 663
		private global::System.Windows.Forms.PictureBox pictureBoxRun;

		// Token: 0x04000298 RID: 664
		private global::System.Windows.Forms.PictureBox pictureBoxWrite;

		// Token: 0x04000299 RID: 665
		private global::System.Windows.Forms.PictureBox pictureBoxPaste;

		// Token: 0x0400029A RID: 666
		private global::System.Windows.Forms.PictureBox pictureBoxCopy;

		// Token: 0x0400029B RID: 667
		private global::System.Windows.Forms.PictureBox pictureBoxCut;

		// Token: 0x0400029C RID: 668
		private global::System.Windows.Forms.PictureBox pictureBoxRedo;

		// Token: 0x0400029D RID: 669
		private global::System.Windows.Forms.PictureBox pictureBoxUndo;

		// Token: 0x0400029E RID: 670
		private global::System.Windows.Forms.PictureBox pictureBoxSave;

		// Token: 0x0400029F RID: 671
		private global::System.Windows.Forms.PictureBox pictureBoxOpen;

		// Token: 0x040002A0 RID: 672
		private global::System.Windows.Forms.PictureBox pictureBoxConnection;

		// Token: 0x040002A1 RID: 673
		private global::System.Windows.Forms.PictureBox pictureBoxObi;

		// Token: 0x040002A2 RID: 674
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLog;

		// Token: 0x040002A3 RID: 675
		private global::System.Windows.Forms.PictureBox pictureBoxBlockLED;

		// Token: 0x040002A4 RID: 676
		private global::System.Windows.Forms.PictureBox pictureBoxBlockSound;

		// Token: 0x040002A5 RID: 677
		private global::System.Windows.Forms.PictureBox pictureBoxBlockWait;

		// Token: 0x040002A6 RID: 678
		private global::System.Windows.Forms.PictureBox pictureBoxBlockLoopStart;

		// Token: 0x040002A7 RID: 679
		private global::System.Windows.Forms.PictureBox pictureBoxBlockLoopEnd;

		// Token: 0x040002A8 RID: 680
		private global::System.Windows.Forms.PictureBox pictureBoxBlockArithmetic;

		// Token: 0x040002A9 RID: 681
		private global::System.Windows.Forms.PictureBox pictureBoxBlockSubroutine;

		// Token: 0x040002AA RID: 682
		private global::System.Windows.Forms.PictureBox pictureBoxBlockIf;

		// Token: 0x040002AB RID: 683
		private global::System.Windows.Forms.PictureBox pictureBoxBlockCounter;

		// Token: 0x040002AC RID: 684
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x040002AD RID: 685
		private global::System.Windows.Forms.ToolStripMenuItem 元に戻すToolStripMenuItem1;

		// Token: 0x040002AE RID: 686
		private global::System.Windows.Forms.ToolStripMenuItem やり直しToolStripMenuItem;

		// Token: 0x040002AF RID: 687
		private global::System.Windows.Forms.ToolStripMenuItem 切り取りToolStripMenuItem1;

		// Token: 0x040002B0 RID: 688
		private global::System.Windows.Forms.ToolStripMenuItem コピ\u30FCToolStripMenuItem1;

		// Token: 0x040002B1 RID: 689
		private global::System.Windows.Forms.ToolStripMenuItem 貼り付けToolStripMenuItem1;

		// Token: 0x040002B2 RID: 690
		private global::System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem1;

		// Token: 0x040002B3 RID: 691
		private global::System.Windows.Forms.ToolStripMenuItem 整列ToolStripMenuItem;

		// Token: 0x040002B4 RID: 692
		private global::System.Windows.Forms.ToolStripMenuItem すべて選択ToolStripMenuItem1;

		// Token: 0x040002B5 RID: 693
		private global::System.Windows.Forms.ToolStripMenuItem 左揃えToolStripMenuItem;

		// Token: 0x040002B6 RID: 694
		private global::System.Windows.Forms.ToolStripMenuItem 右揃えToolStripMenuItem;

		// Token: 0x040002B7 RID: 695
		private global::System.Windows.Forms.ToolStripMenuItem 上揃えToolStripMenuItem;

		// Token: 0x040002B8 RID: 696
		private global::System.Windows.Forms.ToolStripMenuItem 下揃えToolStripMenuItem;

		// Token: 0x040002B9 RID: 697
		private global::System.Windows.Forms.ToolStripMenuItem 矢印を削除ToolStripMenuItem;

		// Token: 0x040002BA RID: 698
		private global::System.Windows.Forms.PictureBox pictureBoxBlockDisplay;

		// Token: 0x040002BB RID: 699
		private global::System.Windows.Forms.PictureBox pictureBoxArrowRight;

		// Token: 0x040002BC RID: 700
		private global::System.Windows.Forms.PictureBox pictureBoxArrowLeft;

		// Token: 0x040002BD RID: 701
		private global::System.Windows.Forms.PictureBox pictureBoxArrowDown;

		// Token: 0x040002BE RID: 702
		private global::System.Windows.Forms.PictureBox pictureBoxArrowUp;

		// Token: 0x040002BF RID: 703
		private global::System.Windows.Forms.ToolStripMenuItem プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem;

		// Token: 0x040002C0 RID: 704
		private global::System.Windows.Forms.ToolStripMenuItem プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem;

		// Token: 0x040002C1 RID: 705
		private global::System.Windows.Forms.ToolStripMenuItem パラメ\u30FCタ表示DToolStripMenuItem;

		// Token: 0x040002C2 RID: 706
		private global::System.Windows.Forms.PictureBox pictureBoxBlockIfElse;

		// Token: 0x040002C3 RID: 707
		private global::System.Windows.Forms.PictureBox pictureBoxBlockLabel;

		// Token: 0x040002C4 RID: 708
		private global::System.Windows.Forms.PictureBox pictureBoxBlockJump;

		// Token: 0x040002C5 RID: 709
		private global::System.Windows.Forms.PictureBox pictureBoxBlockUsbOut;

		// Token: 0x040002C6 RID: 710
		private global::System.Windows.Forms.ToolStripMenuItem 設定CToolStripMenuItem;

		// Token: 0x040002C7 RID: 711
		private global::System.Windows.Forms.ToolStripMenuItem 外部入出力に対応UToolStripMenuItem;

		// Token: 0x040002C8 RID: 712
		private global::System.Windows.Forms.ToolStripMenuItem 選択メニュ\u30FC表示EToolStripMenuItem;
	}
}
