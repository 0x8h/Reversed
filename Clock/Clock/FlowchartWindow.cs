using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000022 RID: 34
	public partial class FlowchartWindow : Form
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600026E RID: 622 RVA: 0x00024B55 File Offset: 0x00022D55
		public static FlowchartWindow Instance
		{
			get
			{
				return FlowchartWindow._instance;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600026F RID: 623 RVA: 0x00024B5C File Offset: 0x00022D5C
		public FlowchartArea Area
		{
			get
			{
				return this._area;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000270 RID: 624 RVA: 0x00024B64 File Offset: 0x00022D64
		// (set) Token: 0x06000271 RID: 625 RVA: 0x00024B6C File Offset: 0x00022D6C
		public ProgramModules.ROUTINE RoutineIndex
		{
			get
			{
				return this._routineIndex;
			}
			set
			{
				this._routineIndex = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000272 RID: 626 RVA: 0x00024B75 File Offset: 0x00022D75
		public ProgramModules Programs
		{
			get
			{
				return this._programs;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000273 RID: 627 RVA: 0x00024B7D File Offset: 0x00022D7D
		// (set) Token: 0x06000274 RID: 628 RVA: 0x00024B85 File Offset: 0x00022D85
		public SimulatorWindow SimulatorWindow
		{
			get
			{
				return this._simulatorWindow;
			}
			set
			{
				this._simulatorWindow = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00024B8E File Offset: 0x00022D8E
		// (set) Token: 0x06000276 RID: 630 RVA: 0x00024B96 File Offset: 0x00022D96
		public InformationWindow InformationWindow
		{
			get
			{
				return this._informationWindow;
			}
			set
			{
				this._informationWindow = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00024B9F File Offset: 0x00022D9F
		public bool RunningFlag
		{
			get
			{
				return this._runningFlag;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000278 RID: 632 RVA: 0x00024BA7 File Offset: 0x00022DA7
		public bool Convert
		{
			get
			{
				return this._convert;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000279 RID: 633 RVA: 0x00024BAF File Offset: 0x00022DAF
		// (set) Token: 0x0600027A RID: 634 RVA: 0x00024BB7 File Offset: 0x00022DB7
		public Point DragBefore
		{
			get
			{
				return this._dragBefore;
			}
			set
			{
				this._dragBefore = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600027B RID: 635 RVA: 0x00024BC0 File Offset: 0x00022DC0
		// (set) Token: 0x0600027C RID: 636 RVA: 0x00024BC8 File Offset: 0x00022DC8
		public bool IsBlockMode { get; private set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600027D RID: 637 RVA: 0x00024BD1 File Offset: 0x00022DD1
		public bool IsUsbInOutEnable
		{
			get
			{
				return ((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[5]).DropDownItems[0]).Checked;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00024BFE File Offset: 0x00022DFE
		// (set) Token: 0x0600027F RID: 639 RVA: 0x00024C08 File Offset: 0x00022E08
		public FlowchartWindow.TUTORIAL Tutorial
		{
			get
			{
				return this._tutorial;
			}
			set
			{
				if (this._tutorial != value)
				{
					this._tutorial = value;
					this.updateEnables();
					TutorialWindow.BUTTON_MODE button_MODE = TutorialWindow.BUTTON_MODE.QUIT;
					if (this._tutorial == FlowchartWindow.TUTORIAL.CAUTION)
					{
						button_MODE = TutorialWindow.BUTTON_MODE.START;
					}
					if (this.IsBlockMode)
					{
						this._tutorialWindow.initialize(this._tutorialImagesBlock[(int)this._tutorial], this._tutorialTextsBlock[(int)this._tutorial], button_MODE);
						return;
					}
					this._tutorialWindow.initialize(this._tutorialImages[(int)this._tutorial], this._tutorialTexts[(int)this._tutorial], button_MODE);
				}
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00024C8D File Offset: 0x00022E8D
		public bool isTutorial()
		{
			return this._tutorialWindow != null;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00024C98 File Offset: 0x00022E98
		public FlowchartWindow(ProgramModules programs, bool tutorial, bool isBlockMode)
		{
			FlowchartWindow._instance = this;
			this.InitializeComponent();
			this._programs = programs;
			this.IsBlockMode = isBlockMode;
			this.extention = (this.IsBlockMode ? ".blp" : ".fcp");
			if (tutorial)
			{
				this._tutorialWindow = new TutorialWindow(this);
				if (isBlockMode)
				{
					this._tutorialWindow.initialize(this._tutorialImagesBlock[(int)this._tutorial], this._tutorialTextsBlock[(int)this._tutorial], TutorialWindow.BUTTON_MODE.START);
				}
				else
				{
					this._tutorialWindow.initialize(this._tutorialImages[(int)this._tutorial], this._tutorialTexts[(int)this._tutorial], TutorialWindow.BUTTON_MODE.START);
				}
			}
			if (isBlockMode)
			{
				this.contextMenuStrip1.Items.RemoveAt(8);
				this.contextMenuStrip1.Items.RemoveAt(7);
				this.contextMenuStrip1.Items.RemoveAt(6);
			}
			this._area = new FlowchartArea(this, this.contextMenuStrip1, this._programs.Programs[0]);
			this.splitContainer4.Panel1.Controls.Add(this._area);
			if (!isBlockMode)
			{
				this._programTextBox = new ProgramTextBox();
				this._programTextBox.MouseDown += this.textBoxProgram_MouseDown;
				this.splitContainer4.Panel2.Controls.Add(this._programTextBox);
				this._programTextBox.Lines = new string[] { "start();" };
				this._programTextBox.Size = new Size(145, 582);
			}
			for (int i = 0; i < 5; i++)
			{
				this._tabs[i] = new FlowchartTab(this, i);
				this._tabs[i].Location = new Point(3 + 102 * i, 9);
				this._tabs[i].setText(this._programs.Programs[i].Name);
				this.splitContainer3.Panel1.Controls.Add(this._tabs[i]);
			}
			this.changeRoutine(ProgramModules.ROUTINE.MAIN);
			this._history.initialize(this.serialize());
			this._timer = new System.Windows.Forms.Timer();
			this._timer.Tick += this.OnUpdateConnection;
			this._timer.Interval = 1000;
			this._timer.Start();
			if (tutorial)
			{
				this.updateEnables();
			}
			if (((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[5]).DropDownItems[0]).Checked != ConfigFile.Instance.Data.FlowchartUsbInOut)
			{
				this.外部入出力に対応UToolStripMenuItem_Click(((ToolStripDropDownItem)this.menuStrip1.Items[5]).DropDownItems[0], null);
			}
			if (((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[3]).Checked != ConfigFile.Instance.Data.FlowchartTextProgram)
			{
				this.プログラムToolStripMenuItem1_Click(((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[3], null);
			}
			if (((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[4]).Checked != ConfigFile.Instance.Data.FlowchartGrid)
			{
				this.グリッドToolStripMenuItem_Click(((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[4], null);
			}
			if (((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[8]).Checked != ConfigFile.Instance.Data.FlowchartParameter)
			{
				this.パラメ\u30FCタ表示DToolStripMenuItem_Click(((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[8], null);
			}
			if (((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[9]).Checked != ConfigFile.Instance.Data.FlowchartDisplayControl)
			{
				this.選択メニュ\u30FC表示EToolStripMenuItem_Click(((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[9], null);
			}
			this._area.DragEnter += this.FlowchartWindow_DragEnter;
			this._area.DragDrop += this.FlowchartWindow_DragDrop;
			this._buttonBlocks.Add(this.pictureBoxBlockLED);
			this._buttonBlocks.Add(this.pictureBoxBlockSound);
			this._buttonBlocks.Add(this.pictureBoxBlockWait);
			this._buttonBlocks.Add(this.pictureBoxBlockCounter);
			this._buttonBlocks.Add(this.pictureBoxBlockIf);
			if (this.IsBlockMode)
			{
				this._buttonBlocks.Add(this.pictureBoxBlockIfElse);
			}
			else
			{
				this.pictureBoxBlockIfElse.Visible = false;
			}
			this._buttonBlocks.Add(this.pictureBoxBlockLoopStart);
			if (this.IsBlockMode)
			{
				this.pictureBoxBlockLoopEnd.Visible = false;
			}
			else
			{
				this._buttonBlocks.Add(this.pictureBoxBlockLoopEnd);
			}
			this._buttonBlocks.Add(this.pictureBoxBlockSubroutine);
			this._buttonBlocks.Add(this.pictureBoxBlockArithmetic);
			this._buttonBlocks.Add(this.pictureBoxBlockDisplay);
			this._buttonBlocks.Add(this.pictureBoxBlockUsbOut);
			if (this.IsBlockMode)
			{
				this._buttonBlocks.Add(this.pictureBoxBlockJump);
				this._buttonBlocks.Add(this.pictureBoxBlockLabel);
			}
			else
			{
				this.pictureBoxBlockJump.Visible = false;
				this.pictureBoxBlockLabel.Visible = false;
			}
			this._buttonTools.Add(this.pictureBoxNew);
			this._buttonTools.Add(this.pictureBoxOpen);
			this._buttonTools.Add(this.pictureBoxSave);
			this._buttonTools.Add(this.pictureBoxUndo);
			this._buttonTools.Add(this.pictureBoxRedo);
			this._buttonTools.Add(this.pictureBoxCut);
			this._buttonTools.Add(this.pictureBoxCopy);
			this._buttonTools.Add(this.pictureBoxPaste);
			this._buttonTools.Add(this.pictureBoxWrite);
			this._buttonTools.Add(this.pictureBoxRun);
			this._buttonTools.Add(this.pictureBoxStop);
			this._buttonTools.Add(this.pictureBoxChange);
			this._buttonTools.Add(this.pictureBoxReport);
			this.pictureBoxArrowUp.Visible = true;
			this.pictureBoxArrowDown.Visible = true;
			this.pictureBoxArrowLeft.Visible = false;
			this.pictureBoxArrowRight.Visible = false;
			this.pictureBoxArrowDown.Location = new Point(this.pictureBoxArrowDown.Location.X, this.pictureBoxArrowDown.Parent.Height - this.pictureBoxArrowDown.Height);
			if (this.IsBlockMode)
			{
				((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[5].Text = "フローチャートへ切替(&I)";
				((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems.RemoveAt(8);
				((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems.RemoveAt(3);
				this.pictureBoxBlockLED.Image = Resources.bp_btn_010;
				this.pictureBoxBlockSound.Image = Resources.bp_btn_020;
				this.pictureBoxBlockWait.Image = Resources.bp_btn_030;
				this.pictureBoxBlockCounter.Image = Resources.bp_btn_040;
				this.pictureBoxBlockIf.Image = Resources.bp_btn_050;
				this.pictureBoxBlockLoopStart.Image = Resources.bp_btn_070;
				this.pictureBoxBlockSubroutine.Image = Resources.bp_btn_080;
				this.pictureBoxBlockArithmetic.Image = Resources.bp_btn_090;
				this.pictureBoxBlockDisplay.Image = Resources.bp_btn_100;
				this.pictureBoxBlockUsbOut.Image = Resources.bp_btn_180;
				int num = this._buttonBlocks[0].Location.Y;
				int num2 = 10;
				foreach (PictureBox pictureBox in this._buttonBlocks)
				{
					pictureBox.Location = new Point(pictureBox.Location.X, num);
					pictureBox.Size = pictureBox.Image.Size;
					num += pictureBox.Height + num2;
				}
				this.splitContainer4.Panel2Collapsed = true;
				this.cursorLED = CursorCreator.CreateCursor(Resources.bp_btn_010, Resources.bp_btn_010.Width / 2, Resources.bp_btn_010.Height / 2);
				this.cursorSound = CursorCreator.CreateCursor(Resources.bp_btn_020, Resources.bp_btn_020.Width / 2, Resources.bp_btn_020.Height / 2);
				this.cursorWait = CursorCreator.CreateCursor(Resources.bp_btn_030, Resources.bp_btn_030.Width / 2, Resources.bp_btn_030.Height / 2);
				this.cursorCounter = CursorCreator.CreateCursor(Resources.bp_btn_040, Resources.bp_btn_040.Width / 2, Resources.bp_btn_040.Height / 2);
				this.cursorIf = CursorCreator.CreateCursor(Resources.bp_btn_050, Resources.bp_btn_050.Width / 2, Resources.bp_btn_050.Height / 2);
				this.cursorLoopStart = CursorCreator.CreateCursor(Resources.bp_btn_070, Resources.bp_btn_070.Width / 2, Resources.bp_btn_070.Height / 2);
				this.cursorSubroutine = CursorCreator.CreateCursor(Resources.bp_btn_080, Resources.bp_btn_080.Width / 2, Resources.bp_btn_080.Height / 2);
				this.cursorArithmetic = CursorCreator.CreateCursor(Resources.bp_btn_090, Resources.bp_btn_090.Width / 2, Resources.bp_btn_090.Height / 2);
				this.cursorDisplay = CursorCreator.CreateCursor(Resources.bp_btn_100, Resources.bp_btn_100.Width / 2, Resources.bp_btn_100.Height / 2);
				this.cursorUsbOut = CursorCreator.CreateCursor(Resources.bp_btn_180, Resources.bp_btn_180.Width / 2, Resources.bp_btn_180.Height / 2);
				this.updateUsedMemory();
			}
			else
			{
				((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems.RemoveAt(9);
			}
			this.updateUsbInOutEnable();
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00025BA8 File Offset: 0x00023DA8
		private void updateEnables()
		{
			bool flag = !this.isTutorial();
			this.menuStrip1.Enabled = flag;
			this.切り取りToolStripMenuItem.Enabled = false;
			this.コピ\u30FCToolStripMenuItem.Enabled = false;
			this.貼り付けToolStripMenuItem.Enabled = false;
			this.削除ToolStripMenuItem.Enabled = false;
			this.元に戻すToolStripMenuItem.Enabled = false;
			this.やり直しToolStripMenuItem.Enabled = false;
			this.すべて選択ToolStripMenuItem.Enabled = false;
			this.splitContainer3.Panel1.Enabled = flag;
			this.pictureBoxNew.Enabled = flag;
			this.pictureBoxOpen.Enabled = flag;
			this.pictureBoxSave.Enabled = flag;
			this.pictureBoxUndo.Enabled = flag;
			this.pictureBoxRedo.Enabled = flag;
			this.pictureBoxCut.Enabled = flag;
			this.pictureBoxCopy.Enabled = flag;
			this.pictureBoxPaste.Enabled = flag;
			this.pictureBoxWrite.Enabled = flag;
			this.pictureBoxRun.Enabled = flag;
			this.pictureBoxStop.Enabled = flag;
			this.pictureBoxChange.Enabled = flag;
			this.pictureBoxReport.Enabled = flag;
			this.pictureBoxBlockLED.Enabled = flag;
			this.pictureBoxBlockSound.Enabled = flag;
			this.pictureBoxBlockWait.Enabled = flag;
			this.pictureBoxBlockLoopStart.Enabled = flag;
			this.pictureBoxBlockLoopEnd.Enabled = flag;
			this.pictureBoxBlockIf.Enabled = flag;
			this.pictureBoxBlockCounter.Enabled = flag;
			this.pictureBoxBlockArithmetic.Enabled = flag;
			this.pictureBoxBlockDisplay.Enabled = flag;
			this.pictureBoxBlockSubroutine.Enabled = flag;
			this.pictureBoxBlockUsbOut.Enabled = flag;
			if (this.IsBlockMode)
			{
				this.pictureBoxBlockIfElse.Enabled = flag;
				this.pictureBoxBlockJump.Enabled = flag;
				this.pictureBoxBlockLabel.Enabled = flag;
			}
			this._area.Enabled = flag;
			if (this.isTutorial())
			{
				switch (this._tutorial)
				{
				case FlowchartWindow.TUTORIAL.DRAG_LED:
					this.pictureBoxBlockLED.Enabled = true;
					this._area.Enabled = true;
					return;
				case FlowchartWindow.TUTORIAL.DOUBLE_CLICK:
				case FlowchartWindow.TUTORIAL.CONNECT_LED:
				case FlowchartWindow.TUTORIAL.CONNECT_SOUND:
					this._area.Enabled = true;
					return;
				case FlowchartWindow.TUTORIAL.DETAIL:
				case FlowchartWindow.TUTORIAL.CONNECT_USB:
					break;
				case FlowchartWindow.TUTORIAL.WRITE_LED:
				case FlowchartWindow.TUTORIAL.WRITE_SOUND:
					this.pictureBoxWrite.Enabled = true;
					return;
				case FlowchartWindow.TUTORIAL.RUN_LED:
				case FlowchartWindow.TUTORIAL.RUN_SOUND:
					this.pictureBoxRun.Enabled = true;
					break;
				case FlowchartWindow.TUTORIAL.DRAG_SOUND:
					this.pictureBoxBlockSound.Enabled = true;
					this._area.Enabled = true;
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00025E27 File Offset: 0x00024027
		private void updateUsbInOutEnable()
		{
			this.pictureBoxBlockUsbOut.Visible = this.IsUsbInOutEnable;
			if (this._simulatorWindow != null)
			{
				this._simulatorWindow.updateUsbInOutEnable();
			}
			if (this.IsBlockMode)
			{
				this._area.updateUsbInOutEnable(this.IsUsbInOutEnable);
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00025E68 File Offset: 0x00024068
		public static string[] getSubroutineNames()
		{
			string[] array = new string[4];
			for (int i = 0; i < 4; i++)
			{
				array[i] = FlowchartWindow._instance._programs.Programs[1 + i].Name;
			}
			return array;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00025EA4 File Offset: 0x000240A4
		private void writeProgram()
		{
			ProgramModule.ERROR error;
			if (this.IsBlockMode)
			{
				this.addHistory(true);
				error = this.Programs.convertFlowchart();
				if (error != ProgramModule.ERROR.NONE)
				{
					this.undo();
					WarningDialog warningDialog = new WarningDialog();
					if (this.IsBlockMode)
					{
						if (error == ProgramModule.ERROR.CONNECT && ProgramModule.ErrorRoutineIndex > 0)
						{
							warningDialog.setText(string.Format("{0}\n(サブルーチン{1})", ProgramModule.ERROR_ITEMS_BLOCK[(int)error], ProgramModule.ErrorRoutineIndex));
						}
						else
						{
							warningDialog.setText(ProgramModule.ERROR_ITEMS_BLOCK[(int)error]);
						}
					}
					else
					{
						warningDialog.setText(ProgramModule.ERROR_ITEMS[(int)error]);
					}
					warningDialog.ShowDialog();
					return;
				}
				this.Programs.updateConnectState();
			}
			error = this._programs.getError(false);
			if (error == ProgramModule.ERROR.NONE)
			{
				if (!this._runningFlag && CommunicationModule.Instance.writeProgram(this._programs))
				{
					if (this.isTutorial())
					{
						FlowchartWindow.TUTORIAL tutorial = this.Tutorial;
						this.Tutorial = tutorial + 1;
					}
					else
					{
						WriteInformationDialog writeInformationDialog = new WriteInformationDialog();
						writeInformationDialog.ShowDialog();
						if (writeInformationDialog.IsRun)
						{
							this.runProgram();
						}
					}
				}
			}
			else
			{
				WarningDialog warningDialog2 = new WarningDialog();
				if (this.IsBlockMode)
				{
					warningDialog2.setText(ProgramModule.ERROR_ITEMS_BLOCK[(int)error]);
				}
				else
				{
					warningDialog2.setText(ProgramModule.ERROR_ITEMS[(int)error]);
				}
				warningDialog2.ShowDialog();
			}
			if (this.IsBlockMode)
			{
				this.undo();
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00025FE4 File Offset: 0x000241E4
		private void readProgram()
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "プログラム読込み";
				confirmDialog.setText(FlowchartWindow.WARNING_SAVE);
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (!this._runningFlag && flag)
			{
				ProgramModules programModules = new ProgramModules();
				programModules.initialize(false);
				ProgramModule[] programs = programModules.Programs;
				for (int i = 0; i < programs.Length; i++)
				{
					programs[i].removeAllBlocks();
				}
				if (CommunicationModule.Instance.readProgram(programModules, false))
				{
					this._programs = programModules;
					if (this.IsBlockMode)
					{
						programModules.updateConnectState();
						ProgramModule.ERROR error = programModules.convertBlock();
						if (error != ProgramModule.ERROR.NONE)
						{
							WarningDialog warningDialog = new WarningDialog();
							warningDialog.setText(ProgramModule.ERROR_ITEMS[(int)error]);
							warningDialog.ShowDialog();
							return;
						}
					}
					this._area.setProgram(this._programs.Programs[(int)this._routineIndex]);
					this.updateTabName();
					this.Programs.updateLoopIndex();
					this.Programs.updateConnectState();
					this.updateProgram();
					this.updateUsedMemory();
					this._history.initialize(this.serialize());
					FlowchartWindow._blockProgramBackup = "";
					this.resetSimulator();
				}
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00026118 File Offset: 0x00024318
		private async void runProgram()
		{
			if (!this._runningFlag && CommunicationModule.Instance.runProgram())
			{
				if (this.isTutorial())
				{
					FlowchartWindow.TUTORIAL tutorial = this.Tutorial;
					this.Tutorial = tutorial + 1;
				}
				else if (!this.IsBlockMode)
				{
					await Task.Run(delegate
					{
						this._programs.clearSelect();
						ProgramModule.Block block2 = null;
						this._runningFlag = true;
						while (this._runningFlag)
						{
							if (this._runningStopFlag)
							{
								this._runningStopFlag = false;
								CommunicationModule.Instance.stopProgram(true);
								this._runningFlag = false;
								return;
							}
							int runningByteIndex = CommunicationModule.Instance.getRunningByteIndex();
							if (runningByteIndex < 0)
							{
								this._runningFlag = false;
								if (block2 != null)
								{
									this._area.setBlockSelected(block2, false);
								}
								this._area.setBlockSelected(this._programs.Programs[(int)this._routineIndex].End, true);
								base.Invoke(new MethodInvoker(delegate
								{
									this.updateRunningBlock(this._programs.Programs[(int)this._routineIndex].End);
								}));
								return;
							}
							ProgramModule.Block block = this._programs.getBlock(runningByteIndex);
							if (block == null)
							{
								Thread.Sleep(33);
							}
							else
							{
								if (block2 != null)
								{
									this._area.setBlockSelected(block2, false);
								}
								this._area.setBlockSelected(block, true);
								if (block2 != block && this._runningFlag)
								{
									base.Invoke(new MethodInvoker(delegate
									{
										this.updateRunningBlock(block);
									}));
								}
								block2 = block;
								Thread.Sleep(33);
							}
						}
					});
				}
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0002614F File Offset: 0x0002434F
		private void updateRunningBlock(ProgramModule.Block block)
		{
			this.changeRoutine(block.Routine);
			this.Area.Invalidate();
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00026168 File Offset: 0x00024368
		private void stopProgram()
		{
			if (this._runningFlag)
			{
				this._runningStopFlag = true;
				return;
			}
			CommunicationModule.Instance.stopProgram(true);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00026188 File Offset: 0x00024388
		private void OnUpdateConnection(object sender, EventArgs e)
		{
			if (CommunicationModule.Instance.Connected)
			{
				this.pictureBoxConnection.Image = Resources.icon_usb_on;
				if (this._tutorial == FlowchartWindow.TUTORIAL.CONNECT_USB)
				{
					FlowchartWindow.TUTORIAL tutorial = this.Tutorial;
					this.Tutorial = tutorial + 1;
					return;
				}
			}
			else
			{
				this.pictureBoxConnection.Image = Resources.icon_usb_off;
			}
		}

		// Token: 0x0600028B RID: 651 RVA: 0x000261DB File Offset: 0x000243DB
		public void updateLog(string log)
		{
			this.toolStripStatusLabelLog.Text = log;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x000261EC File Offset: 0x000243EC
		public void updateProgram()
		{
			if (!this.IsBlockMode)
			{
				List<string> list = new List<string>();
				List<ProgramModule.Block> list2 = new List<ProgramModule.Block>();
				this._programs.Programs[(int)this._routineIndex].getProgram(ref list, ref list2);
				this._programTextBox.setProgram(ref list, ref list2);
			}
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00026238 File Offset: 0x00024438
		public void updateUsedMemory()
		{
			int usedMemory = this._programs.getUsedMemory(this._routineIndex, true);
			this.toolStripStatusLabelUsedMemory.Text = "消費メモリ " + usedMemory.ToString() + "/" + 256.ToString();
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00026288 File Offset: 0x00024488
		public void updateProgramTextBoxSelect()
		{
			if (!this.IsBlockMode)
			{
				List<ProgramModule.Block> selectBlocks = this._programs.Programs[(int)this._routineIndex].getSelectBlocks();
				List<ProgramModule.Block> selectLoopBlockPair = this._programs.Programs[(int)this._routineIndex].getSelectLoopBlockPair();
				this._programTextBox.setSelectBlocks(ref selectBlocks, selectLoopBlockPair);
			}
		}

		// Token: 0x0600028F RID: 655 RVA: 0x000262DC File Offset: 0x000244DC
		private void updateTitle()
		{
			string text = "";
			if (this._filePath != "")
			{
				text = this._filePath.Substring(this._filePath.LastIndexOf("\\") + 1);
			}
			this.Text = "計測・制御プログラム  " + text;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00026330 File Offset: 0x00024530
		private void updateTabName()
		{
			for (int i = 0; i < 5; i++)
			{
				this._tabs[i].setText(this._programs.Programs[i].Name);
			}
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00026368 File Offset: 0x00024568
		public void updateSubroutineName()
		{
			if (this.IsBlockMode)
			{
				this._area.updateSubroutineName();
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0002637D File Offset: 0x0002457D
		public void addHistory(bool clearBackup = true)
		{
			this._programs.WriteAllBlocks.Clear();
			this._history.addHistory(this.serialize());
			this.resetSimulator();
			if (clearBackup)
			{
				FlowchartWindow._blockProgramBackup = "";
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x000263B3 File Offset: 0x000245B3
		public void removeHistory()
		{
			this._programs.WriteAllBlocks.Clear();
			this._history.getPrevious();
			this.resetSimulator();
		}

		// Token: 0x06000294 RID: 660 RVA: 0x000263D7 File Offset: 0x000245D7
		private void resetSimulator()
		{
			if (this._simulatorWindow != null)
			{
				this._simulatorWindow.Simulator.initialize(this._programs);
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x000263F7 File Offset: 0x000245F7
		private void cutSelectBlocks()
		{
			this.copySelectBlocks();
			this._area.removeSelectBlocks();
			this.updateLog("ブロックを切り取り");
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00026418 File Offset: 0x00024618
		private bool copySelectBlocks()
		{
			this._copyObject._blocks.Clear();
			if (this.IsBlockMode)
			{
				using (List<ProgramModule.Block>.Enumerator enumerator = this._programs.Programs[(int)this._routineIndex].Blocks.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProgramModule.Block block = enumerator.Current;
						if (block.Selected)
						{
							List<ProgramModule.Block> list = new List<ProgramModule.Block>();
							block.getBlockList(list);
							using (List<ProgramModule.Block>.Enumerator enumerator2 = list.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									ProgramModule.Block block2 = enumerator2.Current;
									if (!(block2 is ProgramModule.BlockEnd))
									{
										this._copyObject._blocks.Add(block2);
									}
								}
								break;
							}
						}
					}
					goto IL_130;
				}
			}
			foreach (ProgramModule.Block block3 in this._programs.Programs[(int)this._routineIndex].Blocks)
			{
				if (block3.Selected && block3.GetType() != typeof(ProgramModule.BlockEnd))
				{
					this._copyObject._blocks.Add(block3);
				}
			}
			IL_130:
			if (this._copyObject._blocks.Count > 0)
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(FlowchartWindow.CopyObject));
				StringBuilder stringBuilder = new StringBuilder();
				StringWriter stringWriter = new StringWriter(stringBuilder);
				this._programs.Programs[(int)this._routineIndex].saveConnectIndex(this._copyObject._blocks, this.IsBlockMode);
				xmlSerializer.Serialize(stringWriter, this._copyObject);
				this._programs.Programs[(int)this._routineIndex].restoreConnectIndex(this._copyObject._blocks, this.IsBlockMode);
				stringWriter.Close();
				Clipboard.SetText("FlowchartWindow:" + stringBuilder.ToString());
				this.updateLog("ブロックをコピー");
				return true;
			}
			return false;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0002663C File Offset: 0x0002483C
		private void pasteBlocks()
		{
			string text = Clipboard.GetText();
			if (text.StartsWith("FlowchartWindow:"))
			{
				text = text.TrimStart("FlowchartWindow:".ToCharArray());
				FlowchartWindow.CopyObject copyObject = new FlowchartWindow.CopyObject();
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(FlowchartWindow.CopyObject));
				StringReader stringReader = new StringReader(text);
				copyObject = (FlowchartWindow.CopyObject)xmlSerializer.Deserialize(stringReader);
				this._programs.Programs[(int)this._routineIndex].restoreConnectIndex(copyObject._blocks, this.IsBlockMode);
				stringReader.Close();
				this._area.clearSelect();
				if (this.IsBlockMode)
				{
					int num = 0;
					foreach (ProgramModule.Block block in copyObject._blocks)
					{
						num = Math.Max(num, this._area.getEmptyPosition(block.LocationBlock, null, FlowchartArea.DIRECT.RIGHT_BOTTOM).X - block.LocationBlock.X);
					}
					foreach (ProgramModule.Block block2 in copyObject._blocks)
					{
						block2.LocationBlock = new Point(block2.LocationBlock.X + num, block2.LocationBlock.Y + num);
						this._programs.Programs[(int)this._routineIndex].addBlock(block2);
						block2.createBlockControls();
						this._area.addNewBlock(block2);
					}
					this._area.setBlockSelected(copyObject._blocks[0], true);
					copyObject._blocks[0].updateLocation(copyObject._blocks[0].LocationBlock.X);
					this._area.updateBlockControlVisible();
					ProgramModule.BlockLabel.LabelIndexCount = this._programs.getLabelIndexCount() + 1;
					using (List<ProgramModule.BlockLabel>.Enumerator enumerator2 = copyObject._blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>()
						.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							ProgramModule.BlockLabel blockLabel = enumerator2.Current;
							blockLabel.updateLabelIndex();
						}
						goto IL_33E;
					}
				}
				int num2 = 0;
				foreach (ProgramModule.Block block3 in copyObject._blocks)
				{
					num2 = Math.Max(num2, this._area.getEmptyPosition(block3.Location, null, FlowchartArea.DIRECT.RIGHT_BOTTOM).X - block3.Location.X);
				}
				foreach (ProgramModule.Block block4 in copyObject._blocks)
				{
					block4.Location = new Point(block4.Location.X + num2, block4.Location.Y + num2);
					this._programs.Programs[(int)this._routineIndex].addBlock(block4);
					this._area.setBlockSelected(block4, true);
				}
				IL_33E:
				this._area.Invalidate();
				this.updateProgramTextBoxSelect();
				this.updateLog("ブロックを貼り付け");
				this.addHistory(true);
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x000269EC File Offset: 0x00024BEC
		public void undo()
		{
			string previous = this._history.getPrevious();
			if (previous != null)
			{
				this.deserialize(previous);
				this._area.setProgram(this._programs.Programs[(int)this._routineIndex]);
				this.updateTabName();
				this.Programs.updateLoopIndex();
				this.Programs.updateConnectState();
				this.updateProgram();
				this.updateUsedMemory();
				this.resetSimulator();
				this.updateLog("元に戻す");
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00026A68 File Offset: 0x00024C68
		private void redo()
		{
			string next = this._history.getNext();
			if (next != null)
			{
				this.deserialize(next);
				this._area.setProgram(this._programs.Programs[(int)this._routineIndex]);
				this.updateTabName();
				this.Programs.updateLoopIndex();
				this.Programs.updateConnectState();
				this.updateProgram();
				this.updateUsedMemory();
				this.resetSimulator();
				this.updateLog("やり直し");
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00026AE4 File Offset: 0x00024CE4
		private void newFile()
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "新規作成";
				confirmDialog.setText(FlowchartWindow.WARNING_SAVE);
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (flag)
			{
				this._filePath = "";
				this.updateTitle();
				if (this.IsBlockMode)
				{
					ProgramModule.BlockLabel.LabelIndexCount = 1;
				}
				this._programs.initialize(this.IsBlockMode);
				if (this.IsBlockMode)
				{
					this._area.setProgram(this._programs.Programs[0]);
				}
				for (int i = 0; i < 5; i++)
				{
					this._tabs[i].setText(this._programs.Programs[i].Name);
				}
				this.updateLog("新規作成");
				this.Programs.Report = new ReportModule();
				this.Programs.updateConnectState();
				this.updateProgram();
				this.updateUsedMemory();
				this._history.initialize(this.serialize());
				FlowchartWindow._blockProgramBackup = "";
				this.resetSimulator();
				this._area.Invalidate();
				this._area.Focus();
				this.changeRoutine(ProgramModules.ROUTINE.MAIN);
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00026C1C File Offset: 0x00024E1C
		private void openFile()
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "ファイルを開く";
				confirmDialog.setText(FlowchartWindow.WARNING_SAVE);
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (flag)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.FileName = "プログラム" + this.extention;
				openFileDialog.Filter = "プログラミングファイル(*" + this.extention + ")|*" + this.extention;
				openFileDialog.FilterIndex = 1;
				openFileDialog.Title = "開くファイルを選択してください";
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					Stream stream = openFileDialog.OpenFile();
					if (stream != null)
					{
						this._filePath = openFileDialog.FileName;
						this.openFile(stream);
					}
				}
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00026CE0 File Offset: 0x00024EE0
		private void openFile(Stream stream)
		{
			StreamReader streamReader = new StreamReader(stream);
			this.deserialize(streamReader.ReadToEnd());
			this._programs.updateVersion();
			streamReader.Close();
			stream.Close();
			this._history.initialize(this.serialize());
			FlowchartWindow._blockProgramBackup = "";
			this.resetSimulator();
			this._area.setProgram(this._programs.Programs[(int)this._routineIndex]);
			this._area.Focus();
			this.updateTabName();
			this.Programs.updateLoopIndex();
			this.Programs.updateConnectState();
			this.updateTitle();
			this.updateProgram();
			this.updateUsedMemory();
			this.changeRoutine(ProgramModules.ROUTINE.MAIN);
			this.updateLog("ファイルを開く");
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00026DA4 File Offset: 0x00024FA4
		private void saveFile(string filename)
		{
			if (filename.Length > 0)
			{
				try
				{
					using (StreamWriter streamWriter = new StreamWriter(filename, false))
					{
						streamWriter.Write(this.serialize());
						this.updateLog("ファイルを保存");
						streamWriter.Close();
						this._history.setSaved();
					}
					return;
				}
				catch (UnauthorizedAccessException)
				{
					WarningDialog warningDialog = new WarningDialog();
					warningDialog.setText("ファイルが読み取り専用の為、保存できません");
					warningDialog.ShowDialog();
					this.saveFileAs();
					return;
				}
			}
			this.saveFileAs();
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00026E3C File Offset: 0x0002503C
		private void saveFileAs()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = ((this._filePath.Length > 0) ? Path.GetFileName(this._filePath) : ("プログラム" + this.extention));
			saveFileDialog.Filter = string.Concat(new string[] { "プログラミングファイル(*", this.extention, ")|*", this.extention, "|すべてのファイル(*.*)|*.*" });
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.Title = "保存先のファイルを選択してください";
			saveFileDialog.RestoreDirectory = true;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.saveFile(saveFileDialog.FileName);
				this._filePath = saveFileDialog.FileName;
				this.updateTitle();
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00026EFC File Offset: 0x000250FC
		private string serialize()
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProgramModules));
			StringBuilder stringBuilder = new StringBuilder();
			StringWriter stringWriter = new StringWriter(stringBuilder);
			this._programs.IsBlockMode = this.IsBlockMode;
			this._programs.saveConnectIndex();
			xmlSerializer.Serialize(stringWriter, this._programs);
			this._programs.restoreConnectIndex();
			stringWriter.Close();
			return stringBuilder.ToString();
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00026F64 File Offset: 0x00025164
		private void deserialize(string xml)
		{
			if (this.IsBlockMode)
			{
				ProgramModule.BlockLabel.LabelIndexCount = 1;
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProgramModules));
			StringReader stringReader = new StringReader(xml);
			this._programs = (ProgramModules)xmlSerializer.Deserialize(stringReader);
			stringReader.Close();
			this._programs.clearUpdated();
			this._programs.restoreConnectIndex();
			if (!this._programs.IsBlockMode)
			{
				if (this.IsBlockMode)
				{
					this._programs.convertBlock();
				}
				return;
			}
			if (this.IsBlockMode)
			{
				ProgramModule.BlockLabel.LabelIndexCount = this._programs.getLabelIndexCount() + 1;
				this._programs.createBlockControls();
				return;
			}
			this._programs.convertFlowchart();
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00027018 File Offset: 0x00025218
		public void changeRoutine(ProgramModules.ROUTINE index)
		{
			if (this._routineIndex != index)
			{
				this._routineIndex = index;
				for (int i = 0; i < 5; i++)
				{
					this._tabs[i].setSelected(false);
				}
				this._tabs[(int)index].setSelected(true);
				this._area.setProgram(this._programs.Programs[(int)this._routineIndex]);
				this.updateSubroutineName();
				this.Programs.updateConnectState();
				this.updateProgram();
				this.updateUsedMemory();
			}
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00027098 File Offset: 0x00025298
		private void convert()
		{
			if (this.IsBlockMode)
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "フローチャートへ切替";
				confirmDialog.setText("ブロックの接続情報は失われる場合があります。\r\nよろしいですか？");
				confirmDialog.ShowDialog();
				if (confirmDialog.OK)
				{
					FlowchartWindow._blockProgramBackup = this.serialize();
					this.convertFlowchart();
					return;
				}
			}
			else
			{
				if (FlowchartWindow._blockProgramBackup == "")
				{
					this.convertBlock();
					return;
				}
				this.IsBlockMode = true;
				this.deserialize(FlowchartWindow._blockProgramBackup);
				this._convert = true;
				base.Close();
			}
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00027120 File Offset: 0x00025320
		private void convertIcon()
		{
			ConfirmDialog confirmDialog = new ConfirmDialog();
			confirmDialog.Text = "アイコンにする";
			confirmDialog.setText("ブロックのおいているばしょは\r\n元にはもどりません。よろしいですか？");
			confirmDialog.ShowDialog();
			if (confirmDialog.OK)
			{
				ProgramModule.ERROR error = this.Programs.Programs[0].convertToIconProgram();
				if (error == ProgramModule.ERROR.NONE)
				{
					this._convert = true;
					base.Close();
					return;
				}
				WarningDialog warningDialog = new WarningDialog();
				warningDialog.setText(ProgramModule.ERROR_ITEMS[(int)error]);
				warningDialog.ShowDialog();
			}
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00027194 File Offset: 0x00025394
		private void convertFlowchart()
		{
			ProgramModule.ERROR error = this.Programs.convertFlowchart();
			if (error == ProgramModule.ERROR.NONE)
			{
				this._convert = true;
				base.Close();
				return;
			}
			FlowchartWindow._blockProgramBackup = "";
			WarningDialog warningDialog = new WarningDialog();
			if (this.IsBlockMode)
			{
				if (error == ProgramModule.ERROR.CONNECT && ProgramModule.ErrorRoutineIndex > 0)
				{
					warningDialog.setText(string.Format("{0}\n(サブルーチン{1})", ProgramModule.ERROR_ITEMS_BLOCK[(int)error], ProgramModule.ErrorRoutineIndex));
				}
				else
				{
					warningDialog.setText(ProgramModule.ERROR_ITEMS_BLOCK[(int)error]);
				}
			}
			else
			{
				warningDialog.setText(ProgramModule.ERROR_ITEMS[(int)error]);
			}
			warningDialog.ShowDialog();
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0002722C File Offset: 0x0002542C
		private void convertBlock()
		{
			ProgramModule.ERROR error = this.Programs.convertBlock();
			if (error == ProgramModule.ERROR.NONE)
			{
				this._convert = true;
				base.Close();
				return;
			}
			WarningDialog warningDialog = new WarningDialog();
			if (error == ProgramModule.ERROR.CONNECT && ProgramModule.ErrorRoutineIndex > 0)
			{
				warningDialog.setText(string.Format("{0}\n(サブルーチン{1})", ProgramModule.ERROR_ITEMS[(int)error], ProgramModule.ErrorRoutineIndex));
			}
			else
			{
				warningDialog.setText(ProgramModule.ERROR_ITEMS[(int)error]);
			}
			warningDialog.ShowDialog();
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x000272A0 File Offset: 0x000254A0
		private void FlowchartWindow_Shown(object sender, EventArgs e)
		{
			base.Activate();
			if (this.isTutorial())
			{
				this._tutorialWindow.Show();
			}
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x000272BC File Offset: 0x000254BC
		private void FlowchartWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool flag = true;
			if (!this.isTutorial() && !this._history.isSaved() && !this._convert)
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "終了";
				confirmDialog.setText(FlowchartWindow.WARNING_SAVE);
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (!flag)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0002731C File Offset: 0x0002551C
		private void FlowchartWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this._simulatorWindow != null)
			{
				this._simulatorWindow.Close();
			}
			if (this._informationWindow != null)
			{
				this._informationWindow.Close();
			}
			if (this._tutorialWindow != null)
			{
				this._tutorialWindow.Close();
			}
			FlowchartWindow._instance = null;
			this._timer.Stop();
			this._runningFlag = false;
			CommunicationModule.Instance.stopProgram(false);
			Clipboard.Clear();
			base.Dispose();
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00027391 File Offset: 0x00025591
		private void FlowchartWindow_KeyDown(object sender, KeyEventArgs e)
		{
			this._area.FlowchartArea_KeyDown(e);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0002739F File Offset: 0x0002559F
		private void pictureBoxNew_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxNew.Image = Resources.icon_btn_002;
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000273BE File Offset: 0x000255BE
		private void pictureBoxNew_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxNew.Image = Resources.icon_btn_001;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x000273D0 File Offset: 0x000255D0
		private void pictureBoxNew_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxNew.Image = Resources.icon_btn_000;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000273E2 File Offset: 0x000255E2
		private void pictureBoxNew_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxNew.Image = Resources.icon_btn_001;
				this.newFile();
			}
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00027407 File Offset: 0x00025607
		private void pictureBoxOpen_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxOpen.Image = Resources.icon_btn_012;
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00027426 File Offset: 0x00025626
		private void pictureBoxOpen_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxOpen.Image = Resources.icon_btn_011;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00027438 File Offset: 0x00025638
		private void pictureBoxOpen_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxOpen.Image = Resources.icon_btn_010;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0002744A File Offset: 0x0002564A
		private void pictureBoxOpen_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxOpen.Image = Resources.icon_btn_011;
				this.openFile();
			}
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0002746F File Offset: 0x0002566F
		private void pictureBoxSave_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxSave.Image = Resources.icon_btn_022;
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0002748E File Offset: 0x0002568E
		private void pictureBoxSave_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxSave.Image = Resources.icon_btn_021;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x000274A0 File Offset: 0x000256A0
		private void pictureBoxSave_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxSave.Image = Resources.icon_btn_020;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x000274B2 File Offset: 0x000256B2
		private void pictureBoxSave_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxSave.Image = Resources.icon_btn_021;
				this.saveFile(this._filePath);
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x000274DD File Offset: 0x000256DD
		private void pictureBoxUndo_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxUndo.Image = Resources.icon_btn_032;
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x000274FC File Offset: 0x000256FC
		private void pictureBoxUndo_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxUndo.Image = Resources.icon_btn_031;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0002750E File Offset: 0x0002570E
		private void pictureBoxUndo_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxUndo.Image = Resources.icon_btn_030;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00027520 File Offset: 0x00025720
		private void pictureBoxUndo_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxUndo.Image = Resources.icon_btn_031;
				this.undo();
			}
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00027545 File Offset: 0x00025745
		private void pictureBoxRedo_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRedo.Image = Resources.icon_btn_042;
			}
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00027564 File Offset: 0x00025764
		private void pictureBoxRedo_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxRedo.Image = Resources.icon_btn_041;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00027576 File Offset: 0x00025776
		private void pictureBoxRedo_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxRedo.Image = Resources.icon_btn_040;
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00027588 File Offset: 0x00025788
		private void pictureBoxRedo_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRedo.Image = Resources.icon_btn_041;
				this.redo();
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x000275AD File Offset: 0x000257AD
		private void pictureBoxCut_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCut.Image = Resources.icon_btn_052;
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x000275CC File Offset: 0x000257CC
		private void pictureBoxCut_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxCut.Image = Resources.icon_btn_051;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x000275DE File Offset: 0x000257DE
		private void pictureBoxCut_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxCut.Image = Resources.icon_btn_050;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x000275F0 File Offset: 0x000257F0
		private void pictureBoxCut_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCut.Image = Resources.icon_btn_051;
				this.cutSelectBlocks();
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00027615 File Offset: 0x00025815
		private void pictureBoxCopy_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCopy.Image = Resources.icon_btn_062;
			}
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00027634 File Offset: 0x00025834
		private void pictureBoxCopy_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxCopy.Image = Resources.icon_btn_061;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00027646 File Offset: 0x00025846
		private void pictureBoxCopy_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxCopy.Image = Resources.icon_btn_060;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00027658 File Offset: 0x00025858
		private void pictureBoxCopy_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCopy.Image = Resources.icon_btn_061;
				this.copySelectBlocks();
			}
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0002767E File Offset: 0x0002587E
		private void pictureBoxPaste_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxPaste.Image = Resources.icon_btn_072;
			}
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0002769D File Offset: 0x0002589D
		private void pictureBoxPaste_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxPaste.Image = Resources.icon_btn_071;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x000276AF File Offset: 0x000258AF
		private void pictureBoxPaste_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxPaste.Image = Resources.icon_btn_070;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x000276C1 File Offset: 0x000258C1
		private void pictureBoxPaste_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxPaste.Image = Resources.icon_btn_071;
				this.pasteBlocks();
			}
		}

		// Token: 0x060002CA RID: 714 RVA: 0x000276E6 File Offset: 0x000258E6
		private void pictureBoxWrite_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxWrite.Image = Resources.icon_btn_082;
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00027705 File Offset: 0x00025905
		private void pictureBoxWrite_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxWrite.Image = Resources.icon_btn_081;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00027717 File Offset: 0x00025917
		private void pictureBoxWrite_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxWrite.Image = Resources.icon_btn_080;
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00027729 File Offset: 0x00025929
		private void pictureBoxWrite_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxWrite.Image = Resources.icon_btn_081;
				this.writeProgram();
			}
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0002774E File Offset: 0x0002594E
		private void pictureBoxRun_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRun.Image = Resources.icon_btn_092;
			}
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0002776D File Offset: 0x0002596D
		private void pictureBoxRun_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxRun.Image = Resources.icon_btn_091;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0002777F File Offset: 0x0002597F
		private void pictureBoxRun_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxRun.Image = Resources.icon_btn_090;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00027791 File Offset: 0x00025991
		private void pictureBoxRun_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRun.Image = Resources.icon_btn_091;
				this.runProgram();
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x000277B6 File Offset: 0x000259B6
		private void pictureBoxStop_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxStop.Image = Resources.icon_btn_102;
			}
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000277D5 File Offset: 0x000259D5
		private void pictureBoxStop_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxStop.Image = Resources.icon_btn_101;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x000277E7 File Offset: 0x000259E7
		private void pictureBoxStop_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxStop.Image = Resources.icon_btn_100;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000277F9 File Offset: 0x000259F9
		private void pictureBoxStop_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxStop.Image = Resources.icon_btn_101;
				this.stopProgram();
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0002781E File Offset: 0x00025A1E
		private void pictureBoxChange_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxChange.Image = Resources.icon_btn_112;
			}
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0002783D File Offset: 0x00025A3D
		private void pictureBoxChange_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxChange.Image = Resources.icon_btn_111;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0002784F File Offset: 0x00025A4F
		private void pictureBoxChange_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxChange.Image = Resources.icon_btn_110;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00027861 File Offset: 0x00025A61
		private void pictureBoxChange_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxChange.Image = Resources.icon_btn_111;
				this.convert();
			}
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00027886 File Offset: 0x00025A86
		private void pictureBoxReport_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxReport.Image = Resources.icon_btn_122;
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x000278A5 File Offset: 0x00025AA5
		private void pictureBoxReport_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxReport.Image = Resources.icon_btn_121;
		}

		// Token: 0x060002DC RID: 732 RVA: 0x000278B7 File Offset: 0x00025AB7
		private void pictureBoxReport_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxReport.Image = Resources.icon_btn_120;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x000278CC File Offset: 0x00025ACC
		private void pictureBoxReport_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxReport.Image = Resources.icon_btn_121;
				this._programs.clearSelect();
				this.updateProgramTextBoxSelect();
				new ReportWindow(ReportWindow.REPORT.FLOWCHART, this._programs, null, null).ShowDialog();
			}
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0002791B File Offset: 0x00025B1B
		private void pictureBoxBlockLED_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockLED.DoDragDrop("LED", DragDropEffects.Copy);
			}
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0002793C File Offset: 0x00025B3C
		private void pictureBoxBlockLED_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockLED.Image = (this.IsBlockMode ? Resources.bp_btn_011 : Resources.icon_btn_131);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0002795D File Offset: 0x00025B5D
		private void pictureBoxBlockLED_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockLED.Image = (this.IsBlockMode ? Resources.bp_btn_010 : Resources.icon_btn_130);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00027980 File Offset: 0x00025B80
		private void pictureBoxBlockLED_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorLED;
				this.pictureBoxBlockLED.Image = (this.IsBlockMode ? Resources.bp_btn_012 : Resources.icon_btn_132);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockLED.Image = (this.IsBlockMode ? Resources.bp_btn_010 : Resources.icon_btn_130);
			}
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000279F3 File Offset: 0x00025BF3
		private void pictureBoxBlockLED_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockLED.Image = (this.IsBlockMode ? Resources.bp_btn_010 : Resources.icon_btn_130);
			}
			this.scrollScreen();
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00027A24 File Offset: 0x00025C24
		private void pictureBoxBlockSound_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockSound.DoDragDrop("SOUND", DragDropEffects.Copy);
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00027A45 File Offset: 0x00025C45
		private void pictureBoxBlockSound_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockSound.Image = (this.IsBlockMode ? Resources.bp_btn_021 : Resources.icon_btn_141);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00027A66 File Offset: 0x00025C66
		private void pictureBoxBlockSound_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockSound.Image = (this.IsBlockMode ? Resources.bp_btn_020 : Resources.icon_btn_140);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00027A88 File Offset: 0x00025C88
		private void pictureBoxBlockSound_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorSound;
				this.pictureBoxBlockSound.Image = (this.IsBlockMode ? Resources.bp_btn_022 : Resources.icon_btn_142);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockSound.Image = (this.IsBlockMode ? Resources.bp_btn_020 : Resources.icon_btn_140);
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00027AFB File Offset: 0x00025CFB
		private void pictureBoxBlockSound_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockSound.Image = (this.IsBlockMode ? Resources.bp_btn_020 : Resources.icon_btn_140);
			}
			this.scrollScreen();
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00027B2C File Offset: 0x00025D2C
		private void pictureBoxBlockWait_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockWait.DoDragDrop("WAIT", DragDropEffects.Copy);
			}
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00027B4D File Offset: 0x00025D4D
		private void pictureBoxBlockWait_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockWait.Image = (this.IsBlockMode ? Resources.bp_btn_031 : Resources.icon_btn_151);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00027B6E File Offset: 0x00025D6E
		private void pictureBoxBlockWait_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockWait.Image = (this.IsBlockMode ? Resources.bp_btn_030 : Resources.icon_btn_150);
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00027B90 File Offset: 0x00025D90
		private void pictureBoxBlockWait_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorWait;
				this.pictureBoxBlockWait.Image = (this.IsBlockMode ? Resources.bp_btn_032 : Resources.icon_btn_152);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockWait.Image = (this.IsBlockMode ? Resources.bp_btn_030 : Resources.icon_btn_150);
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00027C03 File Offset: 0x00025E03
		private void pictureBoxBlockWait_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockWait.Image = (this.IsBlockMode ? Resources.bp_btn_030 : Resources.icon_btn_150);
			}
			this.scrollScreen();
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00027C34 File Offset: 0x00025E34
		private void pictureBoxBlockCounter_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockCounter.DoDragDrop("COUNTER", DragDropEffects.Copy);
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00027C55 File Offset: 0x00025E55
		private void pictureBoxBlockCounter_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockCounter.Image = (this.IsBlockMode ? Resources.bp_btn_041 : Resources.fc_btn_001);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00027C76 File Offset: 0x00025E76
		private void pictureBoxBlockCounter_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockCounter.Image = (this.IsBlockMode ? Resources.bp_btn_040 : Resources.fc_btn_000);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00027C98 File Offset: 0x00025E98
		private void pictureBoxBlockCounter_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorCounter;
				this.pictureBoxBlockCounter.Image = (this.IsBlockMode ? Resources.bp_btn_042 : Resources.fc_btn_002);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockCounter.Image = (this.IsBlockMode ? Resources.bp_btn_040 : Resources.fc_btn_000);
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00027D0B File Offset: 0x00025F0B
		private void pictureBoxBlockCounter_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockCounter.Image = (this.IsBlockMode ? Resources.bp_btn_040 : Resources.fc_btn_000);
			}
			this.scrollScreen();
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00027D3C File Offset: 0x00025F3C
		private void pictureBoxBlockIf_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockIf.DoDragDrop("IF", DragDropEffects.Copy);
			}
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00027D5D File Offset: 0x00025F5D
		private void pictureBoxBlockIf_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockIf.Image = (this.IsBlockMode ? Resources.bp_btn_051 : Resources.fc_btn_011);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00027D7E File Offset: 0x00025F7E
		private void pictureBoxBlockIf_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockIf.Image = (this.IsBlockMode ? Resources.bp_btn_050 : Resources.fc_btn_010);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00027DA0 File Offset: 0x00025FA0
		private void pictureBoxBlockIf_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorIf;
				this.pictureBoxBlockIf.Image = (this.IsBlockMode ? Resources.bp_btn_052 : Resources.fc_btn_012);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockIf.Image = (this.IsBlockMode ? Resources.bp_btn_050 : Resources.fc_btn_010);
			}
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00027E13 File Offset: 0x00026013
		private void pictureBoxBlockIf_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockIf.Image = (this.IsBlockMode ? Resources.bp_btn_050 : Resources.fc_btn_010);
			}
			this.scrollScreen();
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00027E44 File Offset: 0x00026044
		private void pictureBoxBlockIfElse_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockIfElse.DoDragDrop("IF_ELSE", DragDropEffects.Copy);
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00027E65 File Offset: 0x00026065
		private void pictureBoxBlockIfElse_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockIfElse.Image = Resources.bp_btn_061;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00027E77 File Offset: 0x00026077
		private void pictureBoxBlockIfElse_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockIfElse.Image = Resources.bp_btn_060;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00027E8C File Offset: 0x0002608C
		private void pictureBoxBlockIfElse_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorIfElse;
				this.pictureBoxBlockIfElse.Image = Resources.bp_btn_062;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockIfElse.Image = Resources.bp_btn_060;
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00027EE1 File Offset: 0x000260E1
		private void pictureBoxBlockIfElse_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockIfElse.Image = Resources.bp_btn_060;
			}
			this.scrollScreen();
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00027F03 File Offset: 0x00026103
		private void pictureBoxBlockLoopStart_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockLoopStart.DoDragDrop("LOOP_START", DragDropEffects.Copy);
			}
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00027F24 File Offset: 0x00026124
		private void pictureBoxBlockLoopStart_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockLoopStart.Image = (this.IsBlockMode ? Resources.bp_btn_071 : Resources.icon_btn_161);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00027F45 File Offset: 0x00026145
		private void pictureBoxBlockLoopStart_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockLoopStart.Image = (this.IsBlockMode ? Resources.bp_btn_070 : Resources.icon_btn_160);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00027F68 File Offset: 0x00026168
		private void pictureBoxBlockLoopStart_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorLoopStart;
				this.pictureBoxBlockLoopStart.Image = (this.IsBlockMode ? Resources.bp_btn_070 : Resources.icon_btn_162);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockLoopStart.Image = (this.IsBlockMode ? Resources.bp_btn_070 : Resources.icon_btn_160);
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00027FDB File Offset: 0x000261DB
		private void pictureBoxBlockLoopStart_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockLoopStart.Image = (this.IsBlockMode ? Resources.bp_btn_070 : Resources.icon_btn_160);
			}
			this.scrollScreen();
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0002800C File Offset: 0x0002620C
		private void pictureBoxBlockLoopEnd_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockLoopEnd.DoDragDrop("LOOP_END", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0002802D File Offset: 0x0002622D
		private void pictureBoxBlockLoopEnd_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockLoopEnd.Image = Resources.icon_btn_171;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0002803F File Offset: 0x0002623F
		private void pictureBoxBlockLoopEnd_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockLoopEnd.Image = Resources.icon_btn_170;
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00028054 File Offset: 0x00026254
		private void pictureBoxBlockLoopEnd_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorLoopEnd;
				this.pictureBoxBlockLoopEnd.Image = Resources.icon_btn_172;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockLoopEnd.Image = Resources.icon_btn_170;
			}
		}

		// Token: 0x06000305 RID: 773 RVA: 0x000280A9 File Offset: 0x000262A9
		private void pictureBoxBlockLoopEnd_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockLoopEnd.Image = Resources.icon_btn_170;
			}
			this.scrollScreen();
		}

		// Token: 0x06000306 RID: 774 RVA: 0x000280CB File Offset: 0x000262CB
		private void pictureBoxBlockSubroutine_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockSubroutine.DoDragDrop("SUBROUTINE", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000307 RID: 775 RVA: 0x000280EC File Offset: 0x000262EC
		private void pictureBoxBlockSubroutine_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockSubroutine.Image = (this.IsBlockMode ? Resources.bp_btn_081 : Resources.fc_btn_021);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0002810D File Offset: 0x0002630D
		private void pictureBoxBlockSubroutine_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockSubroutine.Image = (this.IsBlockMode ? Resources.bp_btn_080 : Resources.fc_btn_020);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00028130 File Offset: 0x00026330
		private void pictureBoxBlockSubroutine_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorSubroutine;
				this.pictureBoxBlockSubroutine.Image = (this.IsBlockMode ? Resources.bp_btn_082 : Resources.fc_btn_022);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockSubroutine.Image = (this.IsBlockMode ? Resources.bp_btn_080 : Resources.fc_btn_020);
			}
		}

		// Token: 0x0600030A RID: 778 RVA: 0x000281A3 File Offset: 0x000263A3
		private void pictureBoxBlockSubroutine_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockSubroutine.Image = (this.IsBlockMode ? Resources.bp_btn_080 : Resources.fc_btn_020);
			}
			this.scrollScreen();
		}

		// Token: 0x0600030B RID: 779 RVA: 0x000281D4 File Offset: 0x000263D4
		private void pictureBoxBlockArithmetic_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockArithmetic.DoDragDrop("ARITHMETIC", DragDropEffects.Copy);
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x000281F5 File Offset: 0x000263F5
		private void pictureBoxBlockArithmetic_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockArithmetic.Image = (this.IsBlockMode ? Resources.bp_btn_091 : Resources.fc_btn_031);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00028216 File Offset: 0x00026416
		private void pictureBoxBlockArithmetic_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockArithmetic.Image = (this.IsBlockMode ? Resources.bp_btn_090 : Resources.fc_btn_030);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00028238 File Offset: 0x00026438
		private void pictureBoxBlockArithmetic_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorArithmetic;
				this.pictureBoxBlockArithmetic.Image = (this.IsBlockMode ? Resources.bp_btn_092 : Resources.fc_btn_032);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockArithmetic.Image = (this.IsBlockMode ? Resources.bp_btn_090 : Resources.fc_btn_030);
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x000282AB File Offset: 0x000264AB
		private void pictureBoxBlockArithmetic_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockArithmetic.Image = (this.IsBlockMode ? Resources.bp_btn_090 : Resources.fc_btn_030);
			}
			this.scrollScreen();
		}

		// Token: 0x06000310 RID: 784 RVA: 0x000282DC File Offset: 0x000264DC
		private void pictureBoxBlockDisplay_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockDisplay.DoDragDrop("DISPLAY", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000311 RID: 785 RVA: 0x000282FD File Offset: 0x000264FD
		private void pictureBoxBlockDisplay_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockDisplay.Image = (this.IsBlockMode ? Resources.bp_btn_101 : Resources.fc_btn_041);
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0002831E File Offset: 0x0002651E
		private void pictureBoxBlockDisplay_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockDisplay.Image = (this.IsBlockMode ? Resources.bp_btn_100 : Resources.fc_btn_040);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00028340 File Offset: 0x00026540
		private void pictureBoxBlockDisplay_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorDisplay;
				this.pictureBoxBlockDisplay.Image = (this.IsBlockMode ? Resources.bp_btn_102 : Resources.fc_btn_042);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockDisplay.Image = (this.IsBlockMode ? Resources.bp_btn_100 : Resources.fc_btn_040);
			}
		}

		// Token: 0x06000314 RID: 788 RVA: 0x000283B3 File Offset: 0x000265B3
		private void pictureBoxBlockDisplay_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockDisplay.Image = (this.IsBlockMode ? Resources.bp_btn_100 : Resources.fc_btn_040);
			}
			this.scrollScreen();
		}

		// Token: 0x06000315 RID: 789 RVA: 0x000283E4 File Offset: 0x000265E4
		private void pictureBoxBlockJump_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockJump.DoDragDrop("JUMP", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00028405 File Offset: 0x00026605
		private void pictureBoxBlockJump_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockJump.Image = Resources.bp_btn_111;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00028417 File Offset: 0x00026617
		private void pictureBoxBlockJump_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockJump.Image = Resources.bp_btn_110;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0002842C File Offset: 0x0002662C
		private void pictureBoxBlockJump_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorJump;
				this.pictureBoxBlockJump.Image = Resources.bp_btn_112;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockJump.Image = Resources.bp_btn_110;
			}
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00028481 File Offset: 0x00026681
		private void pictureBoxBlockJump_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockJump.Image = Resources.bp_btn_110;
			}
			this.scrollScreen();
		}

		// Token: 0x0600031A RID: 794 RVA: 0x000284A3 File Offset: 0x000266A3
		private void pictureBoxBlockLabel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockLabel.DoDragDrop("LABEL", DragDropEffects.Copy);
			}
		}

		// Token: 0x0600031B RID: 795 RVA: 0x000284C4 File Offset: 0x000266C4
		private void pictureBoxBlockLabel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockLabel.Image = Resources.bp_btn_121;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x000284D6 File Offset: 0x000266D6
		private void pictureBoxBlockLabel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockLabel.Image = Resources.bp_btn_120;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x000284E8 File Offset: 0x000266E8
		private void pictureBoxBlockLabel_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorLabel;
				this.pictureBoxBlockLabel.Image = Resources.bp_btn_122;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockLabel.Image = Resources.bp_btn_120;
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0002853D File Offset: 0x0002673D
		private void pictureBoxBlockLabel_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockLabel.Image = Resources.bp_btn_120;
			}
			this.scrollScreen();
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0002855F File Offset: 0x0002675F
		private void pictureBoxBlockUsbOut_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockUsbOut.DoDragDrop("USBOUT", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00028580 File Offset: 0x00026780
		private void pictureBoxBlockUsbOut_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockUsbOut.Image = (this.IsBlockMode ? Resources.bp_btn_181 : Resources.fc_btn_051);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x000285A1 File Offset: 0x000267A1
		private void pictureBoxBlockUsbOut_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockUsbOut.Image = (this.IsBlockMode ? Resources.bp_btn_180 : Resources.fc_btn_050);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x000285C4 File Offset: 0x000267C4
		private void pictureBoxBlockUsbOut_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorUsbOut;
				this.pictureBoxBlockUsbOut.Image = (this.IsBlockMode ? Resources.bp_btn_182 : Resources.fc_btn_052);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockUsbOut.Image = (this.IsBlockMode ? Resources.bp_btn_180 : Resources.fc_btn_050);
			}
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00028637 File Offset: 0x00026837
		private void pictureBoxBlockUsbOut_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockUsbOut.Image = (this.IsBlockMode ? Resources.bp_btn_180 : Resources.fc_btn_050);
			}
			this.scrollScreen();
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00028668 File Offset: 0x00026868
		private void splitContainer2_Panel1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.Copy;
				return;
			}
			e.Effect = DragDropEffects.None;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0002868B File Offset: 0x0002688B
		private void 新規作成ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.newFile();
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00028693 File Offset: 0x00026893
		private void ファイルを開くToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.openFile();
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0002869B File Offset: 0x0002689B
		private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.saveFile(this._filePath);
		}

		// Token: 0x06000328 RID: 808 RVA: 0x000286A9 File Offset: 0x000268A9
		private void 名前を付けて保存ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.saveFileAs();
		}

		// Token: 0x06000329 RID: 809 RVA: 0x000286B1 File Offset: 0x000268B1
		private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600032A RID: 810 RVA: 0x000286B9 File Offset: 0x000268B9
		private void 元に戻すToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.undo();
		}

		// Token: 0x0600032B RID: 811 RVA: 0x000286C1 File Offset: 0x000268C1
		private void やり直すToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.redo();
		}

		// Token: 0x0600032C RID: 812 RVA: 0x000286C9 File Offset: 0x000268C9
		private void 切り取りToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.cutSelectBlocks();
		}

		// Token: 0x0600032D RID: 813 RVA: 0x000286D1 File Offset: 0x000268D1
		private void コピ\u30FCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!this.copySelectBlocks() && this._programTextBox != null && this._programTextBox.SelectedText.Length > 0)
			{
				Clipboard.SetText(this._programTextBox.SelectedText);
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00028706 File Offset: 0x00026906
		private void 貼り付けToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.pasteBlocks();
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0002870E File Offset: 0x0002690E
		private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.removeSelectBlocks();
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0002871B File Offset: 0x0002691B
		private void 矢印を削除ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.removeSelectBlockArrows();
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00028728 File Offset: 0x00026928
		private void すべて選択ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.setSelectAll();
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00028735 File Offset: 0x00026935
		private void プログラム書込みToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.writeProgram();
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0002873D File Offset: 0x0002693D
		private void プログラム読込みToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.readProgram();
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00028745 File Offset: 0x00026945
		private void プログラム実行ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.runProgram();
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0002874D File Offset: 0x0002694D
		private void プログラム停止ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.stopProgram();
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00028755 File Offset: 0x00026955
		private void シミュレ\u30FCト画面ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this._simulatorWindow == null)
			{
				this._simulatorWindow = new SimulatorWindow(null, this);
				this._simulatorWindow.Show();
				return;
			}
			this._simulatorWindow.Focus();
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00028784 File Offset: 0x00026984
		private void レポ\u30FCト作成ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new ReportWindow(ReportWindow.REPORT.FLOWCHART, this._programs, null, null).ShowDialog();
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0002879A File Offset: 0x0002699A
		private void 情報ウィンドウToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this._informationWindow == null)
			{
				this._informationWindow = new InformationWindow(this);
				this._informationWindow.Show();
				return;
			}
			this._informationWindow.Focus();
		}

		// Token: 0x06000339 RID: 825 RVA: 0x000287C8 File Offset: 0x000269C8
		private void プログラムToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (ConfigFile.Instance.Data.FlowchartTextProgram != toolStripMenuItem.Checked)
			{
				ConfigFile.Instance.Data.FlowchartTextProgram = toolStripMenuItem.Checked;
				ConfigFile.Instance.Save();
			}
			this.splitContainer4.Panel2Collapsed = !this.splitContainer4.Panel2Collapsed;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0002883C File Offset: 0x00026A3C
		private void グリッドToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (ConfigFile.Instance.Data.FlowchartGrid != toolStripMenuItem.Checked)
			{
				ConfigFile.Instance.Data.FlowchartGrid = toolStripMenuItem.Checked;
				ConfigFile.Instance.Save();
			}
			this._area.Grid = !this._area.Grid;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x000288AE File Offset: 0x00026AAE
		private void アイコンへ切換ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.convert();
		}

		// Token: 0x0600033C RID: 828 RVA: 0x000288B8 File Offset: 0x00026AB8
		private void プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Rectangle reportRect = this._area.getReportRect();
			Bitmap bitmap = new Bitmap(reportRect.X + reportRect.Width, reportRect.Y + reportRect.Height);
			this._area.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
			bitmap = bitmap.Clone(reportRect, bitmap.PixelFormat);
			Clipboard.SetImage(bitmap);
			bitmap.Dispose();
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00028930 File Offset: 0x00026B30
		private void プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Rectangle reportRect = this._area.getReportRect();
			Bitmap bitmap = new Bitmap(reportRect.X + reportRect.Width, reportRect.Y + reportRect.Height);
			this._area.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
			bitmap = bitmap.Clone(reportRect, bitmap.PixelFormat);
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "screenshot.png";
			saveFileDialog.Filter = "画像ファイル(*.png)|*.png";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.Title = "保存先のファイルを選択してください";
			saveFileDialog.RestoreDirectory = true;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				bitmap.Save(saveFileDialog.FileName);
			}
			bitmap.Dispose();
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000289EC File Offset: 0x00026BEC
		private void パラメ\u30FCタ表示DToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (ConfigFile.Instance.Data.FlowchartParameter != toolStripMenuItem.Checked)
			{
				ConfigFile.Instance.Data.FlowchartParameter = toolStripMenuItem.Checked;
				ConfigFile.Instance.Save();
			}
			this._area.Detail = !this._area.Detail;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00028A60 File Offset: 0x00026C60
		private void 選択メニュ\u30FC表示EToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (ConfigFile.Instance.Data.FlowchartDisplayControl != toolStripMenuItem.Checked)
			{
				ConfigFile.Instance.Data.FlowchartDisplayControl = toolStripMenuItem.Checked;
				ConfigFile.Instance.Save();
			}
			this._area.DisplayControl = !this._area.DisplayControl;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00028AD2 File Offset: 0x00026CD2
		private void ヘルプ表示ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(".\\説明書\\Manual.pdf");
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00028ADF File Offset: 0x00026CDF
		private void バ\u30FCジョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new VersionDialog().ShowDialog();
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00028AEC File Offset: 0x00026CEC
		private void 外部入出力に対応UToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (ConfigFile.Instance.Data.FlowchartUsbInOut != toolStripMenuItem.Checked)
			{
				ConfigFile.Instance.Data.FlowchartUsbInOut = toolStripMenuItem.Checked;
				ConfigFile.Instance.Save();
			}
			this.updateUsbInOutEnable();
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00028B4B File Offset: 0x00026D4B
		private void 左揃えToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.alignSelectBlocks(FlowchartArea.ALIGNMENT.LEFT);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00028B59 File Offset: 0x00026D59
		private void 右揃えToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.alignSelectBlocks(FlowchartArea.ALIGNMENT.RIGHT);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00028B67 File Offset: 0x00026D67
		private void 上揃えToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.alignSelectBlocks(FlowchartArea.ALIGNMENT.UP);
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00028B75 File Offset: 0x00026D75
		private void 下揃えToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.alignSelectBlocks(FlowchartArea.ALIGNMENT.BOTTOM);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00028B84 File Offset: 0x00026D84
		private void FlowchartWindow_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (array.Length == 1 && Path.GetExtension(array[0]) == this.extention)
				{
					e.Effect = DragDropEffects.Copy;
					return;
				}
				e.Effect = DragDropEffects.None;
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00028BE4 File Offset: 0x00026DE4
		private void FlowchartWindow_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (array.Length == 1 && Path.GetExtension(array[0]) == this.extention)
				{
					this.openFileDragDrop(array[0]);
				}
			}
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00028C40 File Offset: 0x00026E40
		private void openFileDragDrop(string file)
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "ファイルを開く";
				confirmDialog.setText(FlowchartWindow.WARNING_SAVE);
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (flag)
			{
				Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
				if (stream != null)
				{
					this._filePath = file;
					this.openFile(stream);
				}
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00028CA4 File Offset: 0x00026EA4
		private void scrollScreen()
		{
			if (this._area.PointToClient(Cursor.Position).X + this.splitContainer4.Panel1.AutoScrollPosition.X > this.splitContainer4.Panel1.Width)
			{
				this.splitContainer4.Panel1.AutoScrollPosition = new Point(-this.splitContainer4.Panel1.AutoScrollPosition.X + 3, -this.splitContainer4.Panel1.AutoScrollPosition.Y);
			}
			else if (this._area.PointToClient(Cursor.Position).X + this.splitContainer4.Panel1.AutoScrollPosition.X < 0)
			{
				this.splitContainer4.Panel1.AutoScrollPosition = new Point(-this.splitContainer4.Panel1.AutoScrollPosition.X - 3, -this.splitContainer4.Panel1.AutoScrollPosition.Y);
			}
			if (this._area.PointToClient(Cursor.Position).Y + this.splitContainer4.Panel1.AutoScrollPosition.Y > this.splitContainer4.Panel1.Height)
			{
				this.splitContainer4.Panel1.AutoScrollPosition = new Point(-this.splitContainer4.Panel1.AutoScrollPosition.X, -this.splitContainer4.Panel1.AutoScrollPosition.Y + 3);
			}
			else if (this._area.PointToClient(Cursor.Position).Y + this.splitContainer4.Panel1.AutoScrollPosition.Y < 0)
			{
				this.splitContainer4.Panel1.AutoScrollPosition = new Point(-this.splitContainer4.Panel1.AutoScrollPosition.X, -this.splitContainer4.Panel1.AutoScrollPosition.Y - 3);
			}
			base.Update();
			this._area.Update();
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00028ED8 File Offset: 0x000270D8
		private void textBoxProgram_MouseDown(object sender, MouseEventArgs e)
		{
			this._programs.clearSelect();
			this._area.Invalidate();
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00028EF0 File Offset: 0x000270F0
		private void setScrollV(int index)
		{
			this._scrollIndexV = index;
			for (int i = 0; i < index; i++)
			{
				this._buttonBlocks[i].Visible = false;
			}
			int num = 47;
			for (int j = index; j < this._buttonBlocks.Count; j++)
			{
				this._buttonBlocks[j].Location = new Point(this._buttonBlocks[j].Location.X, num);
				this._buttonBlocks[j].Visible = true;
				num += this._buttonBlocks[j].Height + 10;
			}
			this.updateUsbInOutEnable();
			this.pictureBoxArrowUp.Visible = true;
			this.pictureBoxArrowDown.Visible = true;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00028FB4 File Offset: 0x000271B4
		private void setScrollH(int index)
		{
			this._scrollIndexH = index;
			for (int i = 0; i < index; i++)
			{
				this._buttonTools[i].Visible = false;
			}
			for (int j = index; j < this._buttonTools.Count; j++)
			{
				if (j >= 0)
				{
					this._buttonTools[j].Location = new Point(12 + (j - index) * 72, this._buttonTools[j].Location.Y);
					this._buttonTools[j].Visible = true;
				}
			}
			this.pictureBoxArrowLeft.Visible = true;
			this.pictureBoxArrowRight.Visible = true;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00029064 File Offset: 0x00027264
		private void FlowchartWindow_Resize(object sender, EventArgs e)
		{
			if (this.IsBlockMode || base.Height < 810)
			{
				this.pictureBoxArrowDown.Location = new Point(this.pictureBoxArrowDown.Location.X, this.pictureBoxArrowDown.Parent.Height - this.pictureBoxArrowDown.Height);
				this.setScrollV(0);
			}
			else
			{
				this.setScrollV(0);
				this.pictureBoxArrowUp.Visible = false;
				this.pictureBoxArrowDown.Visible = false;
			}
			if (base.Width < 960)
			{
				this.pictureBoxArrowRight.Location = new Point(this.pictureBoxArrowRight.Parent.Width - this.pictureBoxArrowRight.Width, this.pictureBoxArrowRight.Location.Y);
				this.setScrollH(0);
				return;
			}
			this.setScrollH(0);
			this.pictureBoxArrowLeft.Visible = false;
			this.pictureBoxArrowRight.Visible = false;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00029160 File Offset: 0x00027360
		private void pictureBoxArrowUp_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowUp.Image = Resources.icon_btn_192;
			}
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0002917F File Offset: 0x0002737F
		private void pictureBoxArrowUp_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowUp.Image = Resources.icon_btn_191;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00029191 File Offset: 0x00027391
		private void pictureBoxArrowUp_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowUp.Image = Resources.icon_btn_190;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x000291A3 File Offset: 0x000273A3
		private void pictureBoxArrowUp_MouseUp(object sender, MouseEventArgs e)
		{
			this.setScrollV(Math.Max(Math.Min(this._scrollIndexV - 1, this._buttonBlocks.Count - 1), 0));
			this.pictureBoxArrowUp.Image = Resources.icon_btn_191;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x000291DB File Offset: 0x000273DB
		private void pictureBoxArrowDown_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowDown.Image = Resources.icon_btn_202;
			}
		}

		// Token: 0x06000354 RID: 852 RVA: 0x000291FA File Offset: 0x000273FA
		private void pictureBoxArrowDown_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowDown.Image = Resources.icon_btn_201;
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0002920C File Offset: 0x0002740C
		private void pictureBoxArrowDown_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowDown.Image = Resources.icon_btn_200;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00029220 File Offset: 0x00027420
		private void pictureBoxArrowDown_MouseUp(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < this._buttonBlocks.Count; i++)
			{
				if (this._buttonBlocks[i].Location.Y + this._buttonBlocks[i].Height > this.pictureBoxArrowDown.Location.Y)
				{
					this.setScrollV(Math.Max(this._scrollIndexV + 1, 0));
					break;
				}
			}
			this.pictureBoxArrowDown.Image = Resources.icon_btn_201;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x000292A9 File Offset: 0x000274A9
		private void pictureBoxArrowLeft_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowLeft.Image = Resources.icon_btn_222;
			}
		}

		// Token: 0x06000358 RID: 856 RVA: 0x000292C8 File Offset: 0x000274C8
		private void pictureBoxArrowLeft_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowLeft.Image = Resources.icon_btn_221;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x000292DA File Offset: 0x000274DA
		private void pictureBoxArrowLeft_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowLeft.Image = Resources.icon_btn_220;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x000292EC File Offset: 0x000274EC
		private void pictureBoxArrowLeft_MouseUp(object sender, MouseEventArgs e)
		{
			this.setScrollH(Math.Max(Math.Min(this._scrollIndexH - 1, this._buttonTools.Count - 1), -1));
			this.pictureBoxArrowLeft.Image = Resources.icon_btn_221;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00029324 File Offset: 0x00027524
		private void pictureBoxArrowRight_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowRight.Image = Resources.icon_btn_212;
			}
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00029343 File Offset: 0x00027543
		private void pictureBoxArrowRight_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowRight.Image = Resources.icon_btn_211;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00029355 File Offset: 0x00027555
		private void pictureBoxArrowRight_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowRight.Image = Resources.icon_btn_210;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00029368 File Offset: 0x00027568
		private void pictureBoxArrowRight_MouseUp(object sender, MouseEventArgs e)
		{
			int num = (this.pictureBoxArrowRight.Parent.Width - this.pictureBoxArrowRight.Width - this._buttonTools[0].Location.X) / 72;
			this.setScrollH(Math.Max(Math.Min(this._scrollIndexH + 1, this._buttonTools.Count - num), 0));
			this.pictureBoxArrowRight.Image = Resources.icon_btn_211;
		}

		// Token: 0x04000241 RID: 577
		private const string PROTOCOL = "FlowchartWindow:";

		// Token: 0x04000242 RID: 578
		private string extention;

		// Token: 0x04000243 RID: 579
		private static FlowchartWindow _instance = null;

		// Token: 0x04000244 RID: 580
		private static readonly string WARNING_SAVE = "編集中のデータが失われますが良いですか？";

		// Token: 0x04000245 RID: 581
		private FlowchartArea _area;

		// Token: 0x04000246 RID: 582
		private ProgramTextBox _programTextBox;

		// Token: 0x04000247 RID: 583
		private ProgramModules.ROUTINE _routineIndex = ProgramModules.ROUTINE.INVALID;

		// Token: 0x04000248 RID: 584
		private FlowchartTab[] _tabs = new FlowchartTab[5];

		// Token: 0x04000249 RID: 585
		private ProgramModules _programs;

		// Token: 0x0400024A RID: 586
		private History _history = new History();

		// Token: 0x0400024B RID: 587
		private SimulatorWindow _simulatorWindow;

		// Token: 0x0400024C RID: 588
		private InformationWindow _informationWindow;

		// Token: 0x0400024D RID: 589
		private bool _runningFlag;

		// Token: 0x0400024E RID: 590
		private bool _runningStopFlag;

		// Token: 0x0400024F RID: 591
		private FlowchartWindow.CopyObject _copyObject = new FlowchartWindow.CopyObject();

		// Token: 0x04000250 RID: 592
		private string _filePath = "";

		// Token: 0x04000251 RID: 593
		private bool _convert;

		// Token: 0x04000252 RID: 594
		private Point _dragBefore;

		// Token: 0x04000253 RID: 595
		private Cursor cursorLED = CursorCreator.CreateCursor(Resources.icon_btn_130, Resources.icon_btn_130.Width / 2, Resources.icon_btn_130.Height / 2);

		// Token: 0x04000254 RID: 596
		private Cursor cursorSound = CursorCreator.CreateCursor(Resources.icon_btn_140, Resources.icon_btn_140.Width / 2, Resources.icon_btn_140.Height / 2);

		// Token: 0x04000255 RID: 597
		private Cursor cursorWait = CursorCreator.CreateCursor(Resources.icon_btn_150, Resources.icon_btn_150.Width / 2, Resources.icon_btn_150.Height / 2);

		// Token: 0x04000256 RID: 598
		private Cursor cursorLoopStart = CursorCreator.CreateCursor(Resources.icon_btn_160, Resources.icon_btn_160.Width / 2, Resources.icon_btn_160.Height / 2);

		// Token: 0x04000257 RID: 599
		private Cursor cursorLoopEnd = CursorCreator.CreateCursor(Resources.icon_btn_170, Resources.icon_btn_170.Width / 2, Resources.icon_btn_170.Height / 2);

		// Token: 0x04000258 RID: 600
		private Cursor cursorCounter = CursorCreator.CreateCursor(Resources.fc_btn_000, Resources.fc_btn_000.Width / 2, Resources.fc_btn_000.Height / 2);

		// Token: 0x04000259 RID: 601
		private Cursor cursorIf = CursorCreator.CreateCursor(Resources.fc_btn_010, Resources.fc_btn_010.Width / 2, Resources.fc_btn_010.Height / 2);

		// Token: 0x0400025A RID: 602
		private Cursor cursorIfElse = CursorCreator.CreateCursor(Resources.bp_btn_060, Resources.bp_btn_060.Width / 2, Resources.bp_btn_060.Height / 2);

		// Token: 0x0400025B RID: 603
		private Cursor cursorSubroutine = CursorCreator.CreateCursor(Resources.fc_btn_020, Resources.fc_btn_020.Width / 2, Resources.fc_btn_020.Height / 2);

		// Token: 0x0400025C RID: 604
		private Cursor cursorArithmetic = CursorCreator.CreateCursor(Resources.fc_btn_030, Resources.fc_btn_030.Width / 2, Resources.fc_btn_030.Height / 2);

		// Token: 0x0400025D RID: 605
		private Cursor cursorDisplay = CursorCreator.CreateCursor(Resources.fc_btn_040, Resources.fc_btn_040.Width / 2, Resources.fc_btn_040.Height / 2);

		// Token: 0x0400025E RID: 606
		private Cursor cursorJump = CursorCreator.CreateCursor(Resources.bp_btn_110, Resources.bp_btn_110.Width / 2, Resources.bp_btn_110.Height / 2);

		// Token: 0x0400025F RID: 607
		private Cursor cursorLabel = CursorCreator.CreateCursor(Resources.bp_btn_120, Resources.bp_btn_120.Width / 2, Resources.bp_btn_120.Height / 2);

		// Token: 0x04000260 RID: 608
		private Cursor cursorUsbOut = CursorCreator.CreateCursor(Resources.fc_btn_050, Resources.fc_btn_050.Width / 2, Resources.fc_btn_050.Height / 2);

		// Token: 0x04000261 RID: 609
		private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

		// Token: 0x04000262 RID: 610
		private int _scrollIndexV;

		// Token: 0x04000263 RID: 611
		private int _scrollIndexH;

		// Token: 0x04000264 RID: 612
		private List<PictureBox> _buttonBlocks = new List<PictureBox>();

		// Token: 0x04000265 RID: 613
		private List<PictureBox> _buttonTools = new List<PictureBox>();

		// Token: 0x04000267 RID: 615
		private static string _blockProgramBackup = "";

		// Token: 0x04000268 RID: 616
		private TutorialWindow _tutorialWindow;

		// Token: 0x04000269 RID: 617
		private FlowchartWindow.TUTORIAL _tutorial;

		// Token: 0x0400026A RID: 618
		private readonly string[] _tutorialTexts = new string[]
		{
			"ここではLEDを1秒間点灯させ、メロディを鳴らします。\r\n「はじめる」ボタンを押してください。", "小さな画面の指示に従って操作してください。\r\n※指示以外の操作は受け付けないようになっています。", "①LEDブロックを配置しましょう。", "②設置されたLEDブロックをダブルクリックして開きましょう。", "③赤色、1秒に設定し「OK」ボタンを押しましょう。", "④開始ブロック→LEDブロック→終了ブロックの順につなぎましょう。", "⑤パソコンと本体をつなぎましょう。", "⑥プログラムを書き込みましょう。", "⑦プログラムを実行しましょう。", "⑧サウンドブロックを追加しましょう。",
			"⑨LEDブロックから終了ブロックまでつなげましょう。", "⑩プログラムを書き込みましょう。", "⑪プログラムを実行しましょう。", "つかいかたはこれで終わりです。\r\n今度は自分でいろいろなブロックをつなげてみましょう。"
		};

		// Token: 0x0400026B RID: 619
		private readonly string[] _tutorialTextsBlock = new string[]
		{
			"ここではLEDを1秒間点灯させ、メロディを鳴らします。\r\n「はじめる」ボタンを押してください。", "小さな画面の指示に従って操作してください。\r\n※指示以外の操作は受け付けないようになっています。", "①LEDブロックを配置しましょう。", "②設置されたLEDブロックをダブルクリックして開きましょう。", "③赤色、1秒に設定し「OK」ボタンを押しましょう。", "④開始ブロックと終了ブロックの間にLEDブロックを入れましょう。", "⑤パソコンと本体をつなぎましょう。", "⑥プログラムを書き込みましょう。", "⑦プログラムを実行しましょう。", "⑧サウンドブロックを追加しましょう。",
			"⑨サウンドブロックをLEDブロックの下に接続しましょう。", "⑩プログラムを書き込みましょう。", "⑪プログラムを実行しましょう。", "つかいかたはこれで終わりです。\r\n今度は自分でいろいろなブロックをつなげてみましょう。"
		};

		// Token: 0x0400026C RID: 620
		private readonly Image[] _tutorialImages = new Image[]
		{
			Resources.tutorial_fc_000,
			Resources.tutorial_nw_018,
			Resources.tutorial_fc_001,
			Resources.tutorial_fc_002,
			Resources.tutorial_fc_003,
			Resources.tutorial_fc_004,
			Resources.tutorial_fc_005,
			Resources.tutorial_fc_006,
			Resources.tutorial_fc_007,
			Resources.tutorial_fc_008,
			Resources.tutorial_fc_009,
			Resources.tutorial_fc_006,
			Resources.tutorial_fc_010,
			Resources.tutorial_fc_011
		};

		// Token: 0x0400026D RID: 621
		private readonly Image[] _tutorialImagesBlock = new Image[]
		{
			Resources.tutorial_fc_bl_000,
			Resources.tutorial_nw_018,
			Resources.tutorial_fc_bl_001,
			Resources.tutorial_fc_bl_002,
			Resources.tutorial_fc_bl_003,
			Resources.tutorial_fc_bl_004,
			Resources.tutorial_fc_bl_005,
			Resources.tutorial_fc_bl_006,
			Resources.tutorial_fc_bl_007,
			Resources.tutorial_fc_bl_008,
			Resources.tutorial_fc_bl_009,
			Resources.tutorial_fc_bl_006,
			Resources.tutorial_fc_bl_010,
			Resources.tutorial_fc_011
		};

		// Token: 0x02000091 RID: 145
		public class CopyObject
		{
			// Token: 0x0400082F RID: 2095
			[XmlArrayItem(typeof(ProgramModule.BlockLED))]
			[XmlArrayItem(typeof(ProgramModule.BlockSound))]
			[XmlArrayItem(typeof(ProgramModule.BlockWait))]
			[XmlArrayItem(typeof(ProgramModule.BlockLoopStart))]
			[XmlArrayItem(typeof(ProgramModule.BlockLoopEnd))]
			[XmlArrayItem(typeof(ProgramModule.BlockIf))]
			[XmlArrayItem(typeof(ProgramModule.BlockArithmetic))]
			[XmlArrayItem(typeof(ProgramModule.BlockCounter))]
			[XmlArrayItem(typeof(ProgramModule.BlockSubroutine))]
			[XmlArrayItem(typeof(ProgramModule.BlockDisplay))]
			[XmlArrayItem(typeof(ProgramModule.BlockJump))]
			[XmlArrayItem(typeof(ProgramModule.BlockLabel))]
			[XmlArrayItem(typeof(ProgramModule.BlockUsbOut))]
			public List<ProgramModule.Block> _blocks = new List<ProgramModule.Block>();
		}

		// Token: 0x02000092 RID: 146
		public enum TUTORIAL
		{
			// Token: 0x04000831 RID: 2097
			START,
			// Token: 0x04000832 RID: 2098
			CAUTION,
			// Token: 0x04000833 RID: 2099
			DRAG_LED,
			// Token: 0x04000834 RID: 2100
			DOUBLE_CLICK,
			// Token: 0x04000835 RID: 2101
			DETAIL,
			// Token: 0x04000836 RID: 2102
			CONNECT_LED,
			// Token: 0x04000837 RID: 2103
			CONNECT_USB,
			// Token: 0x04000838 RID: 2104
			WRITE_LED,
			// Token: 0x04000839 RID: 2105
			RUN_LED,
			// Token: 0x0400083A RID: 2106
			DRAG_SOUND,
			// Token: 0x0400083B RID: 2107
			CONNECT_SOUND,
			// Token: 0x0400083C RID: 2108
			WRITE_SOUND,
			// Token: 0x0400083D RID: 2109
			RUN_SOUND,
			// Token: 0x0400083E RID: 2110
			END,
			// Token: 0x0400083F RID: 2111
			MAX
		}
	}
}
