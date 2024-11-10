using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000048 RID: 72
	public partial class NetworkWindow : Form
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x00051F90 File Offset: 0x00050190
		public static NetworkWindow Instance
		{
			get
			{
				return NetworkWindow._instance;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000706 RID: 1798 RVA: 0x00051F97 File Offset: 0x00050197
		public NetworkObjectArea ObjectArea
		{
			get
			{
				return this._objectArea;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x00051F9F File Offset: 0x0005019F
		public NetworkObjectInput ObjectInput
		{
			get
			{
				return this._objectInput;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000708 RID: 1800 RVA: 0x00051FA7 File Offset: 0x000501A7
		public SplitContainer ObjectAreaAll
		{
			get
			{
				return this.splitContainer7;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x00051FAF File Offset: 0x000501AF
		public NetworkObjectIconArea ObjectIconArea
		{
			get
			{
				return this._objectIconArea;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600070A RID: 1802 RVA: 0x00051FB7 File Offset: 0x000501B7
		public NetworkObjectSoundArea ObjectSoundArea
		{
			get
			{
				return this._objectSoundArea;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x00051FBF File Offset: 0x000501BF
		public NetworkObjectPropertyArea ObjectPropertyArea
		{
			get
			{
				return this._objectPropertyArea;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600070C RID: 1804 RVA: 0x00051FC7 File Offset: 0x000501C7
		// (set) Token: 0x0600070D RID: 1805 RVA: 0x00051FCF File Offset: 0x000501CF
		public NetworkSimulatorWindow SimulatorWindow { get; set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600070E RID: 1806 RVA: 0x00051FD8 File Offset: 0x000501D8
		public NetworkFlowchartArea FlowchartArea
		{
			get
			{
				return this._flowchartArea;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00051FE0 File Offset: 0x000501E0
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x00051FE8 File Offset: 0x000501E8
		public NetworkFlowchartTab.TAB FlowchartTabIndex
		{
			get
			{
				return this._flowchartTabIndex;
			}
			set
			{
				this._flowchartTabIndex = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x00051FF1 File Offset: 0x000501F1
		public NetworkObjectTab.TAB ObjectTabIndex
		{
			get
			{
				return this._objectTabIndex;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000712 RID: 1810 RVA: 0x00051FF9 File Offset: 0x000501F9
		public bool RunningFlag
		{
			get
			{
				return this._runningFlag;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000713 RID: 1811 RVA: 0x00052001 File Offset: 0x00050201
		// (set) Token: 0x06000714 RID: 1812 RVA: 0x00052009 File Offset: 0x00050209
		public bool InformationViewFlag { get; set; } = true;

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x00052012 File Offset: 0x00050212
		// (set) Token: 0x06000716 RID: 1814 RVA: 0x0005201A File Offset: 0x0005021A
		public bool StopProgramWithErrorFlag { get; set; } = true;

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x00052023 File Offset: 0x00050223
		// (set) Token: 0x06000718 RID: 1816 RVA: 0x0005202B File Offset: 0x0005022B
		public bool ServerDataShareFlag { get; set; } = true;

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000719 RID: 1817 RVA: 0x00052034 File Offset: 0x00050234
		public bool Convert
		{
			get
			{
				return this._convert;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600071A RID: 1818 RVA: 0x0005203C File Offset: 0x0005023C
		public NetworkProgramModules Programs
		{
			get
			{
				return this._programs;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600071B RID: 1819 RVA: 0x00052044 File Offset: 0x00050244
		// (set) Token: 0x0600071C RID: 1820 RVA: 0x0005204C File Offset: 0x0005024C
		public bool IsBlockMode { get; private set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x00052055 File Offset: 0x00050255
		public bool IsUsbInOutEnable
		{
			get
			{
				return ((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[6]).DropDownItems[0]).Checked && this._programs.Level == NetworkProgramModules.LEVEL.LEVEL_3;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x00052094 File Offset: 0x00050294
		// (set) Token: 0x0600071F RID: 1823 RVA: 0x0005209C File Offset: 0x0005029C
		public NetworkWindow.TUTORIAL Tutorial
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
					base.Invoke(new MethodInvoker(delegate
					{
						this.updateEnables(false);
					}));
					TutorialWindow.BUTTON_MODE mode = TutorialWindow.BUTTON_MODE.QUIT;
					if (this._tutorial == NetworkWindow.TUTORIAL.CAUTION)
					{
						mode = TutorialWindow.BUTTON_MODE.START;
					}
					this._tutorialWindow.Invoke(new MethodInvoker(delegate
					{
						if (this.IsBlockMode)
						{
							this._tutorialWindow.initialize(this._tutorialImagesBlock[(int)this._tutorial], this._tutorialTextsBlock[(int)this._tutorial], mode);
							return;
						}
						this._tutorialWindow.initialize(this._tutorialImages[(int)this._tutorial], this._tutorialTexts[(int)this._tutorial], mode);
					}));
				}
			}
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x00052108 File Offset: 0x00050308
		public bool isTutorial()
		{
			return this._tutorialWindow != null;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00052114 File Offset: 0x00050314
		public NetworkWindow(NetworkProgramModules programs, bool tutorial, bool isBlockMode)
		{
			NetworkWindow._instance = this;
			this.IsBlockMode = isBlockMode;
			this.extention = (this.IsBlockMode ? ".nbp" : ".nwp");
			this.InitializeComponent();
			this._programs = programs;
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
			this._objectArea = new NetworkObjectArea(this);
			this._objectArea.DragEnter += this.NetworkFlowchartWindow_DragEnter;
			this._objectArea.DragDrop += this.NetworkFlowchartWindow_DragDrop;
			this.splitContainer7.Panel1.Controls.Add(this._objectArea);
			this._programs.Objects.Clear();
			this._objectArea.restoreObjects();
			this._objectInput = new NetworkObjectInput(this, this.splitContainer7.Panel2.Size);
			this._programs.ObjectInput.Control = this._objectInput;
			this._programs.ObjectInput.restoreObject();
			this.splitContainer7.Panel2.Controls.Add(this._objectInput);
			this._objectIconArea = new NetworkObjectIconArea(this, new Size(this.splitContainer8.Panel2.Width - SystemInformation.VerticalScrollBarWidth, 200));
			this._objectSoundArea = new NetworkObjectSoundArea();
			this._objectPropertyArea = new NetworkObjectPropertyArea(this);
			this.splitContainer8.Panel2.Controls.Add(this._objectIconArea);
			if (isBlockMode)
			{
				this.contextMenuStrip1.Items.RemoveAt(8);
				this.contextMenuStrip1.Items.RemoveAt(7);
				this.contextMenuStrip1.Items.RemoveAt(6);
			}
			this._flowchartArea = new NetworkFlowchartArea(this, this.contextMenuStrip1, null);
			this.splitContainer5.Panel1.Controls.Add(this._flowchartArea);
			this._flowchartArea.DragEnter += this.NetworkFlowchartWindow_DragEnter;
			this._flowchartArea.DragDrop += this.NetworkFlowchartWindow_DragDrop;
			this._buttonBlocks.Add(this.pictureBoxBlockEvent);
			this._buttonBlocks.Add(this.pictureBoxBlockMessage);
			this._buttonBlocks.Add(this.pictureBoxBlockCommunication);
			this._buttonBlocks.Add(this.pictureBoxBlockWait);
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
			this._buttonBlocks.Add(this.pictureBoxBlockData);
			this._buttonBlocks.Add(this.pictureBoxBlockDisplay);
			this._buttonBlocks.Add(this.pictureBoxBlockOutput);
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
			this._buttonTools.Add(this.pictureBoxRun);
			this._buttonTools.Add(this.pictureBoxChange);
			this._buttonTools.Add(this.pictureBoxReport);
			for (int i = 0; i < 2; i++)
			{
				this._flowchartTabs[i] = new NetworkFlowchartTab(this, (NetworkFlowchartTab.TAB)i);
				this._flowchartTabs[i].Location = new Point(3 + 102 * i, 9);
				this.splitContainer4.Panel1.Controls.Add(this._flowchartTabs[i]);
			}
			for (int j = 0; j < 3; j++)
			{
				this._objectTabs[j] = new NetworkObjectTab(this, j);
				this._objectTabs[j].Location = new Point(this._objectTabs[j].Width * j, 5);
				this.splitContainer8.Panel1.Controls.Add(this._objectTabs[j]);
			}
			this.changeSelectedObject(this._programs.ObjectInput);
			this.changeObjectTab(NetworkObjectTab.TAB.OBJECT);
			this._history.initialize(this.serialize());
			this._timer = new Timer();
			this._timer.Tick += this.OnUpdateConnection;
			this._timer.Interval = 1000;
			this._timer.Start();
			if (tutorial)
			{
				this.updateEnables(false);
			}
			if (((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[6]).DropDownItems[0]).Checked != ConfigFile.Instance.Data.NetworkUsbInOut)
			{
				this.外部入出力に対応UToolStripMenuItem_Click(((ToolStripDropDownItem)this.menuStrip1.Items[6]).DropDownItems[0], null);
			}
			if (((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[2]).DropDownItems[1]).Checked != ConfigFile.Instance.Data.NetworkErrorStop)
			{
				this.通信エラ\u30FCでプログラムを停止するIToolStripMenuItem_Click(((ToolStripDropDownItem)this.menuStrip1.Items[2]).DropDownItems[1], null);
			}
			if (((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[1]).Checked != ConfigFile.Instance.Data.NetworkGrid)
			{
				this.グリッドGToolStripMenuItem_Click(((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[1], null);
			}
			if (((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[5]).Checked != ConfigFile.Instance.Data.NetworkParameter)
			{
				this.パラメ\u30FCタ表示DToolStripMenuItem_Click(((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[5], null);
			}
			if (((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[7]).Checked != ConfigFile.Instance.Data.NetworkInformation)
			{
				this.各種情報表示ToolStripMenuItem_Click(((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[7], null);
			}
			if (((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[8]).Checked != ConfigFile.Instance.Data.NetworkDisplayControl)
			{
				this.選択メニュ\u30FC表示EToolStripMenuItem_Click(((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[8], null);
			}
			if (((ToolStripMenuItem)((ToolStripDropDownItem)this.menuStrip1.Items[4]).DropDownItems[3]).Checked != ConfigFile.Instance.Data.NetworkServerDataShare)
			{
				this.サ\u30FCバデ\u30FCタの情報を共有するSToolStripMenuItem_Click(((ToolStripDropDownItem)this.menuStrip1.Items[4]).DropDownItems[3], null);
			}
			if (this.comboBoxLevel.SelectedIndex != ConfigFile.Instance.Data.NetworkLevel)
			{
				this.comboBoxLevel.SelectedIndex = ConfigFile.Instance.Data.NetworkLevel;
			}
			this.pictureBoxArrowUp.Visible = false;
			this.pictureBoxArrowDown.Visible = false;
			this.pictureBoxArrowLeft.Visible = false;
			this.pictureBoxArrowRight.Visible = false;
			if (isBlockMode)
			{
				((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems.RemoveAt(5);
				((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems[2].Text = "フローチャートへ切替(&I)";
				this.pictureBoxBlockEvent.Image = Resources.bp_btn_000;
				this.pictureBoxBlockMessage.Image = Resources.bp_btn_130;
				this.pictureBoxBlockCommunication.Image = Resources.bp_btn_140;
				this.pictureBoxBlockWait.Image = Resources.bp_btn_030;
				this.pictureBoxBlockIf.Image = Resources.bp_btn_050;
				this.pictureBoxBlockLoopStart.Image = Resources.bp_btn_070;
				this.pictureBoxBlockData.Image = Resources.bp_btn_150;
				this.pictureBoxBlockDisplay.Image = Resources.bp_btn_170;
				this.pictureBoxBlockOutput.Image = Resources.bp_btn_160;
				this.pictureBoxBlockUsbOut.Image = Resources.bp_btn_180;
				int num = this._buttonBlocks[0].Location.Y;
				int num2 = 10;
				foreach (PictureBox pictureBox in this._buttonBlocks)
				{
					pictureBox.Location = new Point(pictureBox.Location.X, num);
					pictureBox.Size = pictureBox.Image.Size;
					num += pictureBox.Height + num2;
				}
				this.pictureBoxArrowUp.Visible = true;
				this.pictureBoxArrowDown.Visible = true;
				this.pictureBoxArrowDown.Location = new Point(this.pictureBoxArrowDown.Location.X, this.pictureBoxArrowDown.Parent.Height - this.pictureBoxArrowDown.Height);
				this.cursorEvent = CursorCreator.CreateCursor(Resources.bp_btn_000, Resources.bp_btn_000.Width / 2, Resources.bp_btn_000.Height / 2);
				this.cursorMessage = CursorCreator.CreateCursor(Resources.bp_btn_130, Resources.bp_btn_130.Width / 2, Resources.bp_btn_130.Height / 2);
				this.cursorCommunication = CursorCreator.CreateCursor(Resources.bp_btn_140, Resources.bp_btn_140.Width / 2, Resources.bp_btn_140.Height / 2);
				this.cursorWait = CursorCreator.CreateCursor(Resources.bp_btn_030, Resources.bp_btn_030.Width / 2, Resources.bp_btn_030.Height / 2);
				this.cursorIf = CursorCreator.CreateCursor(Resources.bp_btn_050, Resources.bp_btn_050.Width / 2, Resources.bp_btn_050.Height / 2);
				this.cursorLoopStart = CursorCreator.CreateCursor(Resources.bp_btn_070, Resources.bp_btn_070.Width / 2, Resources.bp_btn_070.Height / 2);
				this.cursorData = CursorCreator.CreateCursor(Resources.bp_btn_150, Resources.bp_btn_150.Width / 2, Resources.bp_btn_150.Height / 2);
				this.cursorDisplay = CursorCreator.CreateCursor(Resources.bp_btn_170, Resources.bp_btn_170.Width / 2, Resources.bp_btn_170.Height / 2);
				this.cursorOutput = CursorCreator.CreateCursor(Resources.bp_btn_160, Resources.bp_btn_160.Width / 2, Resources.bp_btn_160.Height / 2);
				this.cursorUsbOut = CursorCreator.CreateCursor(Resources.bp_btn_180, Resources.bp_btn_180.Width / 2, Resources.bp_btn_180.Height / 2);
			}
			else
			{
				((ToolStripDropDownItem)this.menuStrip1.Items[3]).DropDownItems.RemoveAt(8);
			}
			this.splitContainer5.Panel2Collapsed = true;
			this.updateLevel();
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00053388 File Offset: 0x00051588
		private void updateEnables(bool enable)
		{
			this.menuStrip1.Enabled = enable;
			this.切り取りTToolStripMenuItem.Enabled = enable;
			this.コピ\u30FCCToolStripMenuItem.Enabled = enable;
			this.貼り付けPToolStripMenuItem.Enabled = enable;
			this.削除DToolStripMenuItem.Enabled = enable;
			this.元に戻すUToolStripMenuItem.Enabled = enable;
			this.やり直しRToolStripMenuItem.Enabled = enable;
			this.すべて選択AToolStripMenuItem.Enabled = enable;
			this.splitContainer4.Panel1.Enabled = enable;
			this.splitContainer8.Panel1.Enabled = enable;
			this.pictureBoxNew.Enabled = enable;
			this.pictureBoxOpen.Enabled = enable;
			this.pictureBoxSave.Enabled = enable;
			this.pictureBoxUndo.Enabled = enable;
			this.pictureBoxRedo.Enabled = enable;
			this.pictureBoxCut.Enabled = enable;
			this.pictureBoxCopy.Enabled = enable;
			this.pictureBoxPaste.Enabled = enable;
			this.pictureBoxRun.Enabled = enable;
			this.pictureBoxReport.Enabled = enable;
			this.pictureBoxBlockEvent.Enabled = enable;
			this.pictureBoxBlockMessage.Enabled = enable;
			this.pictureBoxBlockCommunication.Enabled = enable;
			this.pictureBoxBlockWait.Enabled = enable;
			this.pictureBoxBlockLoopStart.Enabled = enable;
			this.pictureBoxBlockLoopEnd.Enabled = enable;
			this.pictureBoxBlockIf.Enabled = enable;
			this.pictureBoxBlockDisplay.Enabled = enable;
			this.pictureBoxBlockData.Enabled = enable;
			this.pictureBoxBlockOutput.Enabled = enable;
			this.pictureBoxBlockUsbOut.Enabled = enable;
			if (this.IsBlockMode)
			{
				this.pictureBoxChange.Enabled = enable;
				this.pictureBoxBlockIfElse.Enabled = enable;
				this.pictureBoxBlockJump.Enabled = enable;
				this.pictureBoxBlockLabel.Enabled = enable;
			}
			for (int i = 0; i < 5; i++)
			{
				this._objectIconArea.setEnableObjectIcon((NetworkObjectIconArea.OBJECT_ICON)i, enable);
			}
			this._flowchartArea.Enabled = enable;
			this._objectArea.Enabled = !this.isTutorial();
			if (this.isTutorial())
			{
				switch (this._tutorial)
				{
				case NetworkWindow.TUTORIAL.DRAG_LABEL:
					this._objectIconArea.setEnableObjectIcon(NetworkObjectIconArea.OBJECT_ICON.LABEL, true);
					this._objectArea.Enabled = true;
					return;
				case NetworkWindow.TUTORIAL.DRAG_BUTTON:
					this._objectIconArea.setEnableObjectIcon(NetworkObjectIconArea.OBJECT_ICON.BUTTON, true);
					this._objectArea.Enabled = true;
					return;
				case NetworkWindow.TUTORIAL.ADJUST_SPLITTER:
				case NetworkWindow.TUTORIAL.SELECT_BUTTON:
					this._objectArea.Enabled = true;
					return;
				case NetworkWindow.TUTORIAL.DRAG_DISPLAY:
					this.pictureBoxBlockDisplay.Enabled = true;
					this._flowchartArea.Enabled = true;
					return;
				case NetworkWindow.TUTORIAL.DOUBLE_CLICK:
					this._flowchartArea.Enabled = true;
					return;
				case NetworkWindow.TUTORIAL.CHANGE_PROPERTY:
				case NetworkWindow.TUTORIAL.CLOSE:
				case NetworkWindow.TUTORIAL.CHANGE_PROPERTY_2:
				case NetworkWindow.TUTORIAL.INPUT:
				case NetworkWindow.TUTORIAL.CLOSE_2:
					break;
				case NetworkWindow.TUTORIAL.CONNECT_BLOCKS:
					this._flowchartArea.Enabled = true;
					return;
				case NetworkWindow.TUTORIAL.RUN:
					this.pictureBoxRun.Enabled = true;
					return;
				case NetworkWindow.TUTORIAL.CLICK_BUTTON:
					this._objectArea.Enabled = true;
					return;
				case NetworkWindow.TUTORIAL.SELECT_INPUT:
					this._objectArea.Enabled = true;
					return;
				case NetworkWindow.TUTORIAL.DRAG_DISPLAY_2:
					this.pictureBoxBlockDisplay.Enabled = true;
					this._flowchartArea.Enabled = true;
					return;
				case NetworkWindow.TUTORIAL.DOUBLE_CLICK_2:
					this._flowchartArea.Enabled = true;
					return;
				case NetworkWindow.TUTORIAL.CONNECT_BLOCKS_2:
					this._flowchartArea.Enabled = true;
					return;
				case NetworkWindow.TUTORIAL.RUN_2:
					this.pictureBoxRun.Enabled = true;
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x000536C5 File Offset: 0x000518C5
		public void addHistory(bool clearBackup = true)
		{
			this._history.addHistory(this.serialize());
			if (clearBackup)
			{
				NetworkWindow._blockProgramBackup = "";
			}
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x000153E3 File Offset: 0x000135E3
		public void updateProgramTextBoxSelect()
		{
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x000153E3 File Offset: 0x000135E3
		public void updateProgram()
		{
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x000536E5 File Offset: 0x000518E5
		public void updateLog(string log)
		{
			this.toolStripStatusLabelLog.Text = log;
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x000536F3 File Offset: 0x000518F3
		public void updateData()
		{
			if (this.IsBlockMode)
			{
				this._flowchartArea.updateData();
			}
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00053708 File Offset: 0x00051908
		public void changeFlowchartTab(NetworkFlowchartTab.TAB index, bool isForce = false)
		{
			if (this._flowchartTabIndex != index || isForce)
			{
				this._flowchartTabIndex = index;
				for (int i = 0; i < 2; i++)
				{
					this._flowchartTabs[i].setSelected(false);
				}
				this._flowchartTabs[(int)index].setSelected(true);
				if (index == NetworkFlowchartTab.TAB.OBJECT)
				{
					if (this._programs.getSelectedObject() == null)
					{
						this._flowchartTabs[(int)index].setText(NetworkFlowchartTab.TAB_NAMES[0]);
					}
					else
					{
						this._flowchartTabs[(int)index].setText(this._programs.getSelectedObject().getObjectName());
					}
				}
				ProgramModule selectedProgramModule = this.getSelectedProgramModule(index, 0);
				this._flowchartArea.setProgram(selectedProgramModule);
				if (selectedProgramModule != null)
				{
					selectedProgramModule.updateConnectState();
				}
				this.updateProgram();
			}
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x000537C0 File Offset: 0x000519C0
		public void changeObjectTab(NetworkObjectTab.TAB index)
		{
			if (this._objectTabIndex != index)
			{
				this._objectTabIndex = index;
				for (int i = 0; i < 3; i++)
				{
					this._objectTabs[i].setSelected(false);
				}
				this._objectTabs[(int)index].setSelected(true);
				this.splitContainer8.Panel2.Controls.RemoveAt(0);
				switch (index)
				{
				case NetworkObjectTab.TAB.OBJECT:
					this.splitContainer8.Panel2.Controls.Add(this._objectIconArea);
					return;
				case NetworkObjectTab.TAB.PROPERTY:
					this._objectPropertyArea.changeObject(this._programs.getSelectedObject());
					this.splitContainer8.Panel2.Controls.Add(this._objectPropertyArea);
					break;
				case NetworkObjectTab.TAB.SOUND:
					this.splitContainer8.Panel2.Controls.Add(this._objectSoundArea);
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0005389C File Offset: 0x00051A9C
		public void changeSelectedObject(NetworkProgramModules.ObjectInfo objectInfo)
		{
			if (objectInfo is NetworkProgramModules.ObjectStageInfo)
			{
				this.changeFlowchartTab(NetworkFlowchartTab.TAB.STAGE, true);
				return;
			}
			this._programs.setSelectedObject(objectInfo);
			this.changeFlowchartTab(NetworkFlowchartTab.TAB.OBJECT, true);
			this._objectPropertyArea.changeObject(objectInfo);
			if (this._tutorial == NetworkWindow.TUTORIAL.SELECT_BUTTON && objectInfo is NetworkProgramModules.ObjectButtonInfo)
			{
				NetworkWindow.TUTORIAL tutorial = this.Tutorial;
				this.Tutorial = tutorial + 1;
				return;
			}
			if (this._tutorial == NetworkWindow.TUTORIAL.SELECT_INPUT && objectInfo is NetworkProgramModules.ObjectInputInfo)
			{
				NetworkWindow.TUTORIAL tutorial = this.Tutorial;
				this.Tutorial = tutorial + 1;
			}
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00053920 File Offset: 0x00051B20
		public void changeSimulator(bool enable)
		{
			this._programs.setEditorMode(!enable);
			if (!this.isTutorial())
			{
				this.updateEnables(!enable);
			}
			if (enable)
			{
				this._storeSelectedObject = this._programs.getSelectedObject();
				this._programs.setSelectedObject(null);
				this.SimulatorWindow = new NetworkSimulatorWindow(this);
				this.SimulatorWindow.SimulatorArea.addObjects(this.splitContainer7);
				this.SimulatorWindow.Show();
				return;
			}
			this._programs.setSelectedObject(this._storeSelectedObject);
			this.splitContainer6.Panel1.Controls.Add(this.SimulatorWindow.SimulatorArea.removeObjects());
			this.SimulatorWindow = null;
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x000539DC File Offset: 0x00051BDC
		private void runProgram()
		{
			this._programs.updateConnectState();
			ProgramModule.ERROR error = this._programs.getError(true);
			if (error == ProgramModule.ERROR.NONE)
			{
				this.changeSimulator(true);
				return;
			}
			WarningDialog warningDialog = new WarningDialog();
			if (this.IsBlockMode)
			{
				warningDialog.setText(ProgramModule.ERROR_ITEMS_BLOCK[(int)error]);
			}
			else
			{
				warningDialog.setText(ProgramModule.ERROR_ITEMS[(int)error]);
			}
			warningDialog.ShowDialog();
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x00053A40 File Offset: 0x00051C40
		private void OnUpdateConnection(object sender, EventArgs e)
		{
			if (Client.isConnect())
			{
				this.labelConnect.Text = (Server.isConnect() ? "サーバとして接続中" : "クライアントとして接続中");
				this.labelServer.Text = Client.ServerName;
				this.labelServer.Visible = true;
			}
			else
			{
				this.labelConnect.Text = "未接続";
				this.labelServer.Visible = false;
			}
			if (CommunicationModule.Instance.Connected)
			{
				this.pictureBoxConnection.Image = Resources.icon_usb_on;
				return;
			}
			this.pictureBoxConnection.Image = Resources.icon_usb_off;
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x00053ADC File Offset: 0x00051CDC
		private void updateLevel()
		{
			if (this.comboBoxLevel.SelectedIndex != (int)this._programs.Level)
			{
				this.comboBoxLevel.SelectedIndex = (int)this._programs.Level;
				if (ConfigFile.Instance.Data.NetworkLevel != this.comboBoxLevel.SelectedIndex)
				{
					ConfigFile.Instance.Data.NetworkLevel = this.comboBoxLevel.SelectedIndex;
					ConfigFile.Instance.Save();
				}
			}
			switch (this._programs.Level)
			{
			case NetworkProgramModules.LEVEL.LEVEL_1:
				this.pictureBoxBlockOutput.Visible = false;
				if (this._objectTabs[2] != null)
				{
					this._objectTabs[2].Visible = false;
				}
				break;
			case NetworkProgramModules.LEVEL.LEVEL_2:
				this.pictureBoxBlockOutput.Visible = true;
				if (this._objectTabs[2] != null)
				{
					this._objectTabs[2].Visible = false;
				}
				break;
			case NetworkProgramModules.LEVEL.LEVEL_3:
				this.pictureBoxBlockOutput.Visible = true;
				break;
			}
			this.pictureBoxBlockUsbOut.Visible = this.IsUsbInOutEnable;
			if (this._flowchartArea != null)
			{
				this._flowchartArea.updateLevel();
			}
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00053BF3 File Offset: 0x00051DF3
		private void updateUsbInOutEnable()
		{
			this.pictureBoxBlockUsbOut.Visible = this.IsUsbInOutEnable;
			if (this.IsBlockMode)
			{
				this._flowchartArea.updateUsbInOutEnable(this.IsUsbInOutEnable);
			}
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x00053C20 File Offset: 0x00051E20
		private void NetworkFlowchartWindow_DragEnter(object sender, DragEventArgs e)
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

		// Token: 0x06000731 RID: 1841 RVA: 0x00053C80 File Offset: 0x00051E80
		private void NetworkFlowchartWindow_DragDrop(object sender, DragEventArgs e)
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

		// Token: 0x06000732 RID: 1842 RVA: 0x00053CDC File Offset: 0x00051EDC
		private void openFileDragDrop(string file)
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "ファイルを開く";
				confirmDialog.setText("編集中のデータが失われますが良いですか？");
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

		// Token: 0x06000733 RID: 1843 RVA: 0x00053D40 File Offset: 0x00051F40
		private void scrollScreen()
		{
			if (this._flowchartArea.PointToClient(Cursor.Position).X + ((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition.X > ((SplitterPanel)this._flowchartArea.Parent).Width)
			{
				((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition = new Point(-((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition.X + 3, -((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition.Y);
			}
			else if (this._flowchartArea.PointToClient(Cursor.Position).X + ((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition.X < 0)
			{
				((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition = new Point(-((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition.X - 3, -((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition.Y);
			}
			if (this._flowchartArea.PointToClient(Cursor.Position).Y + ((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition.Y > ((SplitterPanel)this._flowchartArea.Parent).Height)
			{
				((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition = new Point(-((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition.X, -((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition.Y + 3);
			}
			else if (this._flowchartArea.PointToClient(Cursor.Position).Y + ((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition.Y < 0)
			{
				((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition = new Point(-((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition.X, -((SplitterPanel)this._flowchartArea.Parent).AutoScrollPosition.Y - 3);
			}
			base.Update();
			this._flowchartArea.Update();
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00053FD4 File Offset: 0x000521D4
		private void newFile()
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "新規作成";
				confirmDialog.setText("編集中のデータが失われますが良いですか？");
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
				this._programs.initialize();
				if (this.IsBlockMode && this._programs.getSelectedObject() != null)
				{
					this._flowchartArea.setProgram(this._programs.getSelectedObject().ProgramModule);
				}
				this.updateLog("新規作成");
				this._programs.Report = new ReportModule();
				this._programs.updateConnectState();
				this.updateProgram();
				this.updateLevel();
				this._history.initialize(this.serialize());
				NetworkWindow._blockProgramBackup = "";
				this._flowchartArea.Invalidate();
				this._flowchartArea.Focus();
				this._objectArea.Controls.Clear();
				this.changeFlowchartTab(NetworkFlowchartTab.TAB.OBJECT, true);
				this.changeSelectedObject(this._programs.ObjectInput);
			}
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x00054108 File Offset: 0x00052308
		private string serialize()
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(NetworkProgramModules));
			StringBuilder stringBuilder = new StringBuilder();
			StringWriter stringWriter = new StringWriter(stringBuilder);
			this._programs.IsBlockMode = this.IsBlockMode;
			this._programs.saveConnectIndex();
			this._programs.storeObjects();
			xmlSerializer.Serialize(stringWriter, this._programs);
			this._programs.restoreConnectIndex();
			stringWriter.Close();
			return stringBuilder.ToString();
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x0005417C File Offset: 0x0005237C
		private void deserialize(string xml)
		{
			if (this.IsBlockMode)
			{
				ProgramModule.BlockLabel.LabelIndexCount = 1;
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(NetworkProgramModules));
			StringReader stringReader = new StringReader(xml);
			this._programs = (NetworkProgramModules)xmlSerializer.Deserialize(stringReader);
			stringReader.Close();
			this._programs.clearUpdated();
			this._objectArea.restoreObjects();
			this._programs.ObjectInput.Control = this._objectInput;
			this._programs.ObjectInput.restoreObject();
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

		// Token: 0x06000737 RID: 1847 RVA: 0x00054264 File Offset: 0x00052464
		private void openFile()
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "ファイルを開く";
				confirmDialog.setText("編集中のデータが失われますが良いですか？");
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

		// Token: 0x06000738 RID: 1848 RVA: 0x00054328 File Offset: 0x00052528
		private void openFile(Stream stream)
		{
			StreamReader streamReader = new StreamReader(stream);
			this.deserialize(streamReader.ReadToEnd());
			this._programs.updateVersion();
			this._programs.updateObjectNewCounts();
			streamReader.Close();
			stream.Close();
			this._history.initialize(this.serialize());
			NetworkWindow._blockProgramBackup = "";
			this._flowchartArea.Focus();
			this._programs.updateLoopIndex();
			this._programs.updateConnectState();
			this.updateTitle();
			this.updateProgram();
			this.updateLevel();
			this.changeFlowchartTab(NetworkFlowchartTab.TAB.OBJECT, false);
			this.changeSelectedObject(this._programs.ObjectInput);
			this.updateLog("ファイルを開く");
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x000543E0 File Offset: 0x000525E0
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

		// Token: 0x0600073A RID: 1850 RVA: 0x00054478 File Offset: 0x00052678
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

		// Token: 0x0600073B RID: 1851 RVA: 0x00054537 File Offset: 0x00052737
		private void cutSelectBlocks()
		{
			this.copySelectBlocks();
			this._flowchartArea.removeSelectBlocks();
			this.updateLog("ブロックを切り取り");
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00054558 File Offset: 0x00052758
		private bool copySelectBlocks()
		{
			ProgramModule selectedProgramModule = this.getSelectedProgramModule(this._flowchartTabIndex, 0);
			if (selectedProgramModule == null)
			{
				return false;
			}
			this._copyObject._blocks.Clear();
			if (this.IsBlockMode)
			{
				using (List<ProgramModule.Block>.Enumerator enumerator = selectedProgramModule.Blocks.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProgramModule.Block block = enumerator.Current;
						if (block.Selected)
						{
							List<ProgramModule.Block> list = new List<ProgramModule.Block>();
							block.getBlockList(list);
							if (block is ProgramModule.BlockStart)
							{
								this._copyObject._blocks.AddRange(list);
								break;
							}
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
					goto IL_143;
				}
			}
			foreach (ProgramModule.Block block3 in selectedProgramModule.Blocks)
			{
				if (block3.Selected && block3.GetType() != typeof(ProgramModule.BlockEnd))
				{
					this._copyObject._blocks.Add(block3);
				}
			}
			IL_143:
			if (this._copyObject._blocks.Count > 0)
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(NetworkWindow.CopyObject));
				StringBuilder stringBuilder = new StringBuilder();
				StringWriter stringWriter = new StringWriter(stringBuilder);
				selectedProgramModule.saveConnectIndex(this._copyObject._blocks, this.IsBlockMode);
				xmlSerializer.Serialize(stringWriter, this._copyObject);
				selectedProgramModule.restoreConnectIndex(this._copyObject._blocks, this.IsBlockMode);
				stringWriter.Close();
				Clipboard.SetText("NetworkWindow:" + stringBuilder.ToString());
				this.updateLog("ブロックをコピー");
				return true;
			}
			return false;
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00054770 File Offset: 0x00052970
		private void pasteBlocks()
		{
			ProgramModule selectedProgramModule = this.getSelectedProgramModule(this._flowchartTabIndex, 0);
			if (selectedProgramModule == null)
			{
				return;
			}
			string text = Clipboard.GetText();
			if (text.StartsWith("NetworkWindow:"))
			{
				text = text.TrimStart("NetworkWindow:".ToCharArray());
				NetworkWindow.CopyObject copyObject = new NetworkWindow.CopyObject();
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(NetworkWindow.CopyObject));
				StringReader stringReader = new StringReader(text);
				copyObject = (NetworkWindow.CopyObject)xmlSerializer.Deserialize(stringReader);
				selectedProgramModule.restoreConnectIndex(copyObject._blocks, this.IsBlockMode);
				stringReader.Close();
				this._flowchartArea.clearSelect();
				if (this.IsBlockMode)
				{
					int num = 0;
					foreach (ProgramModule.Block block in copyObject._blocks)
					{
						num = Math.Max(num, this._flowchartArea.getEmptyPosition(block.LocationBlock, null, NetworkFlowchartArea.DIRECT.RIGHT_BOTTOM).X - block.LocationBlock.X);
					}
					foreach (ProgramModule.Block block2 in copyObject._blocks)
					{
						block2.LocationBlock = new Point(block2.LocationBlock.X + num, block2.LocationBlock.Y + num);
						if (block2 is ProgramModule.BlockStart)
						{
							selectedProgramModule.Starts.Add((ProgramModule.BlockStart)block2);
						}
						else if (block2 is ProgramModule.BlockEnd)
						{
							selectedProgramModule.Ends.Add((ProgramModule.BlockEnd)block2);
						}
						selectedProgramModule.addBlock(block2);
						block2.createBlockControls();
						this._flowchartArea.addNewBlock(block2);
					}
					this._flowchartArea.setBlockSelected(copyObject._blocks[0], true);
					copyObject._blocks[0].updateLocation(copyObject._blocks[0].LocationBlock.X);
					this._flowchartArea.updateBlockControlVisible();
					ProgramModule.BlockLabel.LabelIndexCount = this._programs.getLabelIndexCount() + 1;
					using (List<ProgramModule.BlockLabel>.Enumerator enumerator2 = copyObject._blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>()
						.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							ProgramModule.BlockLabel blockLabel = enumerator2.Current;
							blockLabel.updateLabelIndex();
						}
						goto IL_37B;
					}
				}
				int num2 = 0;
				foreach (ProgramModule.Block block3 in copyObject._blocks)
				{
					num2 = Math.Max(num2, this._flowchartArea.getEmptyPosition(block3.Location, null, NetworkFlowchartArea.DIRECT.RIGHT_BOTTOM).X - block3.Location.X);
				}
				foreach (ProgramModule.Block block4 in copyObject._blocks)
				{
					if (block4 is ProgramModule.BlockStart)
					{
						selectedProgramModule.Starts.Add((ProgramModule.BlockStart)block4);
					}
					block4.Location = new Point(block4.Location.X + num2, block4.Location.Y + num2);
					selectedProgramModule.addBlock(block4);
					this._flowchartArea.setBlockSelected(block4, true);
				}
				IL_37B:
				this._flowchartArea.Invalidate();
				this.updateProgramTextBoxSelect();
				this.updateLog("ブロックを貼り付け");
				this.addHistory(true);
			}
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00054B5C File Offset: 0x00052D5C
		private void undo()
		{
			string previous = this._history.getPrevious();
			if (previous != null)
			{
				int id = this._programs.getSelectedObject().Id;
				NetworkFlowchartTab.TAB flowchartTabIndex = this._flowchartTabIndex;
				this.deserialize(previous);
				if (this._programs.getObject(id) == null)
				{
					this.changeSelectedObject(this._programs.ObjectInput);
				}
				else
				{
					this.changeSelectedObject(this._programs.getObject(id));
				}
				if (flowchartTabIndex != this._flowchartTabIndex)
				{
					this.changeFlowchartTab(flowchartTabIndex, false);
				}
				this._programs.updateLoopIndex();
				this._programs.updateConnectState();
				this.updateProgram();
				this.updateLevel();
				this.updateLog("元に戻す");
			}
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00054C0C File Offset: 0x00052E0C
		private void redo()
		{
			string next = this._history.getNext();
			if (next != null)
			{
				int id = this._programs.getSelectedObject().Id;
				NetworkFlowchartTab.TAB flowchartTabIndex = this._flowchartTabIndex;
				this.deserialize(next);
				if (this._programs.getObject(id) == null)
				{
					this.changeSelectedObject(this._programs.ObjectInput);
				}
				else
				{
					this.changeSelectedObject(this._programs.getObject(id));
				}
				if (flowchartTabIndex != this._flowchartTabIndex)
				{
					this.changeFlowchartTab(flowchartTabIndex, false);
				}
				this._programs.updateLoopIndex();
				this._programs.updateConnectState();
				this.updateProgram();
				this.updateLevel();
				this.updateLog("やり直し");
			}
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00054CBC File Offset: 0x00052EBC
		private ProgramModule getSelectedProgramModule(NetworkFlowchartTab.TAB tabIndex, int objectId = 0)
		{
			ProgramModule programModule = null;
			if (tabIndex != NetworkFlowchartTab.TAB.OBJECT)
			{
				if (tabIndex == NetworkFlowchartTab.TAB.STAGE)
				{
					programModule = this._programs.ObjectStage.ProgramModule;
				}
			}
			else
			{
				NetworkProgramModules.ObjectInfo objectInfo;
				if (objectId == 0)
				{
					objectInfo = this._programs.getSelectedObject();
				}
				else
				{
					objectInfo = this._programs.getObject(objectId);
				}
				if (objectInfo != null)
				{
					programModule = objectInfo.ProgramModule;
				}
			}
			return programModule;
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00054D10 File Offset: 0x00052F10
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
					NetworkWindow._blockProgramBackup = this.serialize();
					this.convertFlowchart();
					return;
				}
			}
			else
			{
				if (NetworkWindow._blockProgramBackup == "")
				{
					this.convertBlock();
					return;
				}
				this.IsBlockMode = true;
				this.deserialize(NetworkWindow._blockProgramBackup);
				this._convert = true;
				base.Close();
			}
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00054D98 File Offset: 0x00052F98
		private void convertFlowchart()
		{
			ProgramModule.ERROR error = this.Programs.convertFlowchart();
			if (error == ProgramModule.ERROR.NONE)
			{
				this._convert = true;
				base.Close();
				return;
			}
			NetworkWindow._blockProgramBackup = "";
			WarningDialog warningDialog = new WarningDialog();
			if (this.IsBlockMode)
			{
				warningDialog.setText(ProgramModule.ERROR_ITEMS_BLOCK[(int)error]);
			}
			else
			{
				warningDialog.setText(ProgramModule.ERROR_ITEMS[(int)error]);
			}
			warningDialog.ShowDialog();
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00054E00 File Offset: 0x00053000
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
			warningDialog.setText(ProgramModule.ERROR_ITEMS[(int)error]);
			warningDialog.ShowDialog();
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x00054E44 File Offset: 0x00053044
		private void updateTitle()
		{
			string text = "";
			if (this._filePath != "")
			{
				text = this._filePath.Substring(this._filePath.LastIndexOf("\\") + 1);
			}
			this.Text = "ネットワークプログラム  " + text;
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00054E98 File Offset: 0x00053098
		private void NetworkWindow_Shown(object sender, EventArgs e)
		{
			base.Activate();
			if (this.isTutorial())
			{
				this._tutorialWindow.Show();
			}
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00054EB4 File Offset: 0x000530B4
		private void NetworkWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool flag = true;
			if (!this.isTutorial() && !this._history.isSaved() && !this._convert)
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "終了";
				confirmDialog.setText("編集中のデータが失われますが良いですか？");
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (!flag)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00054F14 File Offset: 0x00053114
		private void NetworkWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this.SimulatorWindow != null)
			{
				this.SimulatorWindow.Close();
			}
			if (this._tutorialWindow != null)
			{
				this._tutorialWindow.Close();
			}
			NetworkWindow._instance = null;
			this._timer.Stop();
			Clipboard.Clear();
			base.Dispose();
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00054F64 File Offset: 0x00053164
		private void NetworkWindow_Resize(object sender, EventArgs e)
		{
			int num = (int)(690 + this._programs.Level * (NetworkProgramModules.LEVEL)60);
			if (this.IsBlockMode || base.Height < num)
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

		// Token: 0x06000749 RID: 1865 RVA: 0x00055074 File Offset: 0x00053274
		private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this._programs.Level != (NetworkProgramModules.LEVEL)this.comboBoxLevel.SelectedIndex)
			{
				this._programs.Level = (NetworkProgramModules.LEVEL)this.comboBoxLevel.SelectedIndex;
				if (ConfigFile.Instance.Data.NetworkLevel != this.comboBoxLevel.SelectedIndex)
				{
					ConfigFile.Instance.Data.NetworkLevel = this.comboBoxLevel.SelectedIndex;
					ConfigFile.Instance.Save();
				}
				this.setScrollV(0);
				this.addHistory(true);
			}
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x000550FD File Offset: 0x000532FD
		private void pictureBoxBlockEvent_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockEvent.DoDragDrop("EVENT", DragDropEffects.Copy);
			}
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x0005511E File Offset: 0x0005331E
		private void pictureBoxBlockEvent_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockEvent.Image = (this.IsBlockMode ? Resources.bp_btn_001 : Resources.nw_btn_001);
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x0005513F File Offset: 0x0005333F
		private void pictureBoxBlockEvent_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockEvent.Image = (this.IsBlockMode ? Resources.bp_btn_000 : Resources.nw_btn_000);
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x00055160 File Offset: 0x00053360
		private void pictureBoxBlockEvent_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorEvent;
				this.pictureBoxBlockEvent.Image = (this.IsBlockMode ? Resources.bp_btn_002 : Resources.nw_btn_002);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockEvent.Image = (this.IsBlockMode ? Resources.bp_btn_000 : Resources.nw_btn_000);
			}
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x000551D3 File Offset: 0x000533D3
		private void pictureBoxBlockEvent_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockEvent.Image = (this.IsBlockMode ? Resources.bp_btn_000 : Resources.nw_btn_000);
			}
			this.scrollScreen();
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00055204 File Offset: 0x00053404
		private void pictureBoxBlockMessage_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockMessage.DoDragDrop("MESSAGE", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x00055225 File Offset: 0x00053425
		private void pictureBoxBlockMessage_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockMessage.Image = (this.IsBlockMode ? Resources.bp_btn_131 : Resources.nw_btn_011);
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x00055246 File Offset: 0x00053446
		private void pictureBoxBlockMessage_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockMessage.Image = (this.IsBlockMode ? Resources.bp_btn_130 : Resources.nw_btn_010);
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00055268 File Offset: 0x00053468
		private void pictureBoxBlockMessage_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorMessage;
				this.pictureBoxBlockMessage.Image = (this.IsBlockMode ? Resources.bp_btn_132 : Resources.nw_btn_012);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockMessage.Image = (this.IsBlockMode ? Resources.bp_btn_130 : Resources.nw_btn_010);
			}
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x000552DB File Offset: 0x000534DB
		private void pictureBoxBlockMessage_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockMessage.Image = (this.IsBlockMode ? Resources.bp_btn_130 : Resources.nw_btn_010);
			}
			this.scrollScreen();
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x0005530C File Offset: 0x0005350C
		private void pictureBoxBlockCommunication_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockCommunication.DoDragDrop("COMMUNICATION", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x0005532D File Offset: 0x0005352D
		private void pictureBoxBlockCommunication_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockCommunication.Image = (this.IsBlockMode ? Resources.bp_btn_141 : Resources.nw_btn_021);
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0005534E File Offset: 0x0005354E
		private void pictureBoxBlockCommunication_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockCommunication.Image = (this.IsBlockMode ? Resources.bp_btn_140 : Resources.nw_btn_020);
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x00055370 File Offset: 0x00053570
		private void pictureBoxBlockCommunication_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorCommunication;
				this.pictureBoxBlockCommunication.Image = (this.IsBlockMode ? Resources.bp_btn_142 : Resources.nw_btn_022);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockCommunication.Image = (this.IsBlockMode ? Resources.bp_btn_140 : Resources.nw_btn_020);
			}
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x000553E3 File Offset: 0x000535E3
		private void pictureBoxBlockCommunication_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockCommunication.Image = (this.IsBlockMode ? Resources.bp_btn_140 : Resources.nw_btn_020);
			}
			this.scrollScreen();
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00055414 File Offset: 0x00053614
		private void pictureBoxBlockWait_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockWait.DoDragDrop("WAIT", DragDropEffects.Copy);
			}
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x00055435 File Offset: 0x00053635
		private void pictureBoxBlockWait_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockWait.Image = (this.IsBlockMode ? Resources.bp_btn_031 : Resources.icon_btn_151);
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x00055456 File Offset: 0x00053656
		private void pictureBoxBlockWait_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockWait.Image = (this.IsBlockMode ? Resources.bp_btn_030 : Resources.icon_btn_150);
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00055478 File Offset: 0x00053678
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

		// Token: 0x0600075D RID: 1885 RVA: 0x000554EB File Offset: 0x000536EB
		private void pictureBoxBlockWait_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockWait.Image = (this.IsBlockMode ? Resources.bp_btn_030 : Resources.icon_btn_150);
			}
			this.scrollScreen();
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0005551C File Offset: 0x0005371C
		private void pictureBoxBlockOutput_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockOutput.DoDragDrop("OUTPUT", DragDropEffects.Copy);
			}
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0005553D File Offset: 0x0005373D
		private void pictureBoxBlockOutput_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockOutput.Image = (this.IsBlockMode ? Resources.bp_btn_161 : Resources.nw_btn_041);
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0005555E File Offset: 0x0005375E
		private void pictureBoxBlockOutput_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockOutput.Image = (this.IsBlockMode ? Resources.bp_btn_160 : Resources.nw_btn_040);
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x00055580 File Offset: 0x00053780
		private void pictureBoxBlockOutput_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorOutput;
				this.pictureBoxBlockOutput.Image = (this.IsBlockMode ? Resources.bp_btn_162 : Resources.nw_btn_042);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockOutput.Image = (this.IsBlockMode ? Resources.bp_btn_160 : Resources.nw_btn_040);
			}
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x000555F3 File Offset: 0x000537F3
		private void pictureBoxBlockOutput_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockOutput.Image = (this.IsBlockMode ? Resources.bp_btn_160 : Resources.nw_btn_040);
			}
			this.scrollScreen();
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x00055624 File Offset: 0x00053824
		private void pictureBoxBlockData_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockData.DoDragDrop("DATA", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x00055645 File Offset: 0x00053845
		private void pictureBoxBlockData_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockData.Image = (this.IsBlockMode ? Resources.bp_btn_151 : Resources.nw_btn_031);
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x00055666 File Offset: 0x00053866
		private void pictureBoxBlockData_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockData.Image = (this.IsBlockMode ? Resources.bp_btn_150 : Resources.nw_btn_030);
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x00055688 File Offset: 0x00053888
		private void pictureBoxBlockData_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorData;
				this.pictureBoxBlockData.Image = (this.IsBlockMode ? Resources.bp_btn_152 : Resources.nw_btn_032);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockData.Image = (this.IsBlockMode ? Resources.bp_btn_150 : Resources.nw_btn_030);
			}
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x000556FB File Offset: 0x000538FB
		private void pictureBoxBlockData_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockData.Image = (this.IsBlockMode ? Resources.bp_btn_150 : Resources.nw_btn_030);
			}
			this.scrollScreen();
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x0005572C File Offset: 0x0005392C
		private void pictureBoxBlockIf_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockIf.DoDragDrop("IF", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0005574D File Offset: 0x0005394D
		private void pictureBoxBlockIf_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockIf.Image = (this.IsBlockMode ? Resources.bp_btn_051 : Resources.fc_btn_011);
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x0005576E File Offset: 0x0005396E
		private void pictureBoxBlockIf_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockIf.Image = (this.IsBlockMode ? Resources.bp_btn_050 : Resources.fc_btn_010);
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x00055790 File Offset: 0x00053990
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

		// Token: 0x0600076C RID: 1900 RVA: 0x00055803 File Offset: 0x00053A03
		private void pictureBoxBlockIf_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockIf.Image = (this.IsBlockMode ? Resources.bp_btn_050 : Resources.fc_btn_010);
			}
			this.scrollScreen();
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x00055834 File Offset: 0x00053A34
		private void pictureBoxBlockIfElse_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockIfElse.DoDragDrop("IF_ELSE", DragDropEffects.Copy);
			}
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00055855 File Offset: 0x00053A55
		private void pictureBoxBlockIfElse_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockIfElse.Image = Resources.bp_btn_061;
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x00055867 File Offset: 0x00053A67
		private void pictureBoxBlockIfElse_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockIfElse.Image = Resources.bp_btn_060;
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0005587C File Offset: 0x00053A7C
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
				this.pictureBoxBlockIfElse.Image = Resources.bp_btn_061;
			}
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x000558D1 File Offset: 0x00053AD1
		private void pictureBoxBlockIfElse_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockIfElse.Image = Resources.bp_btn_060;
			}
			this.scrollScreen();
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x000558F3 File Offset: 0x00053AF3
		private void pictureBoxBlockLoopStart_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockLoopStart.DoDragDrop("LOOP_START", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x00055914 File Offset: 0x00053B14
		private void pictureBoxBlockLoopStart_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockLoopStart.Image = (this.IsBlockMode ? Resources.bp_btn_071 : Resources.icon_btn_161);
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x00055935 File Offset: 0x00053B35
		private void pictureBoxBlockLoopStart_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockLoopStart.Image = (this.IsBlockMode ? Resources.bp_btn_070 : Resources.icon_btn_160);
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x00055958 File Offset: 0x00053B58
		private void pictureBoxBlockLoopStart_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorLoopStart;
				this.pictureBoxBlockLoopStart.Image = (this.IsBlockMode ? Resources.bp_btn_071 : Resources.icon_btn_162);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockLoopStart.Image = (this.IsBlockMode ? Resources.bp_btn_070 : Resources.icon_btn_160);
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x000559CB File Offset: 0x00053BCB
		private void pictureBoxBlockLoopStart_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockLoopStart.Image = (this.IsBlockMode ? Resources.bp_btn_070 : Resources.icon_btn_160);
			}
			this.scrollScreen();
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x000559FC File Offset: 0x00053BFC
		private void pictureBoxBlockLoopEnd_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockLoopEnd.DoDragDrop("LOOP_END", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x00055A1D File Offset: 0x00053C1D
		private void pictureBoxBlockLoopEnd_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockLoopEnd.Image = Resources.icon_btn_171;
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x00055A2F File Offset: 0x00053C2F
		private void pictureBoxBlockLoopEnd_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockLoopEnd.Image = Resources.icon_btn_170;
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00055A44 File Offset: 0x00053C44
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

		// Token: 0x0600077B RID: 1915 RVA: 0x00055A99 File Offset: 0x00053C99
		private void pictureBoxBlockLoopEnd_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockLoopEnd.Image = Resources.icon_btn_170;
			}
			this.scrollScreen();
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x00055ABB File Offset: 0x00053CBB
		private void pictureBoxBlockDisplay_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockDisplay.DoDragDrop("DISPLAY", DragDropEffects.Copy);
			}
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x00055ADC File Offset: 0x00053CDC
		private void pictureBoxBlockDisplay_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockDisplay.Image = (this.IsBlockMode ? Resources.bp_btn_171 : Resources.nw_btn_051);
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x00055AFD File Offset: 0x00053CFD
		private void pictureBoxBlockDisplay_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockDisplay.Image = (this.IsBlockMode ? Resources.bp_btn_170 : Resources.nw_btn_050);
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x00055B20 File Offset: 0x00053D20
		private void pictureBoxBlockDisplay_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorDisplay;
				this.pictureBoxBlockDisplay.Image = (this.IsBlockMode ? Resources.bp_btn_172 : Resources.nw_btn_052);
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockDisplay.Image = (this.IsBlockMode ? Resources.bp_btn_170 : Resources.nw_btn_050);
			}
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x00055B93 File Offset: 0x00053D93
		private void pictureBoxBlockDisplay_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockDisplay.Image = (this.IsBlockMode ? Resources.bp_btn_170 : Resources.nw_btn_050);
			}
			this.scrollScreen();
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00055BC4 File Offset: 0x00053DC4
		private void pictureBoxBlockJump_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockJump.DoDragDrop("JUMP", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00055BE5 File Offset: 0x00053DE5
		private void pictureBoxBlockJump_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockJump.Image = Resources.bp_btn_111;
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x00055BF7 File Offset: 0x00053DF7
		private void pictureBoxBlockJump_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockJump.Image = Resources.bp_btn_110;
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00055C0C File Offset: 0x00053E0C
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
				this.pictureBoxBlockJump.Image = Resources.bp_btn_111;
			}
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x00055C61 File Offset: 0x00053E61
		private void pictureBoxBlockJump_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockJump.Image = Resources.bp_btn_110;
			}
			this.scrollScreen();
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x00055C83 File Offset: 0x00053E83
		private void pictureBoxBlockLabel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockLabel.DoDragDrop("LABEL", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x00055CA4 File Offset: 0x00053EA4
		private void pictureBoxBlockLabel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockLabel.Image = Resources.bp_btn_121;
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00055CB6 File Offset: 0x00053EB6
		private void pictureBoxBlockLabel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockLabel.Image = Resources.bp_btn_120;
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x00055CC8 File Offset: 0x00053EC8
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
				this.pictureBoxBlockLabel.Image = Resources.bp_btn_121;
			}
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x00055D1D File Offset: 0x00053F1D
		private void pictureBoxBlockLabel_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockLabel.Image = Resources.bp_btn_120;
			}
			this.scrollScreen();
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x00055D3F File Offset: 0x00053F3F
		private void pictureBoxBlockUsbOut_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockUsbOut.DoDragDrop("USBOUT", DragDropEffects.Copy);
			}
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x00055D60 File Offset: 0x00053F60
		private void pictureBoxBlockUsbOut_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockUsbOut.Image = (this.IsBlockMode ? Resources.bp_btn_181 : Resources.fc_btn_051);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x00055D81 File Offset: 0x00053F81
		private void pictureBoxBlockUsbOut_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockUsbOut.Image = (this.IsBlockMode ? Resources.bp_btn_180 : Resources.fc_btn_050);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00055DA4 File Offset: 0x00053FA4
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
				this.pictureBoxBlockUsbOut.Image = (this.IsBlockMode ? Resources.bp_btn_181 : Resources.fc_btn_051);
			}
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00055E17 File Offset: 0x00054017
		private void pictureBoxBlockUsbOut_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockUsbOut.Image = (this.IsBlockMode ? Resources.bp_btn_180 : Resources.fc_btn_050);
			}
			this.scrollScreen();
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00055E48 File Offset: 0x00054048
		private void NetworkWindow_KeyDown(object sender, KeyEventArgs e)
		{
			this._flowchartArea.NetworkFlowchartArea_KeyDown(e);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x00055E56 File Offset: 0x00054056
		private void comboBoxLevel_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x00055E5F File Offset: 0x0005405F
		private void pictureBoxNew_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxNew.Image = Resources.icon_btn_002;
			}
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x00055E7E File Offset: 0x0005407E
		private void pictureBoxNew_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxNew.Image = Resources.icon_btn_001;
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x00055E90 File Offset: 0x00054090
		private void pictureBoxNew_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxNew.Image = Resources.icon_btn_000;
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x00055EA2 File Offset: 0x000540A2
		private void pictureBoxNew_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxNew.Image = Resources.icon_btn_001;
				this.newFile();
			}
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x00055EC7 File Offset: 0x000540C7
		private void pictureBoxOpen_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxOpen.Image = Resources.icon_btn_012;
			}
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00055EE6 File Offset: 0x000540E6
		private void pictureBoxOpen_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxOpen.Image = Resources.icon_btn_011;
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00055EF8 File Offset: 0x000540F8
		private void pictureBoxOpen_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxOpen.Image = Resources.icon_btn_010;
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x00055F0A File Offset: 0x0005410A
		private void pictureBoxOpen_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxOpen.Image = Resources.icon_btn_011;
				this.openFile();
			}
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x00055F2F File Offset: 0x0005412F
		private void pictureBoxSave_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxSave.Image = Resources.icon_btn_022;
			}
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x00055F4E File Offset: 0x0005414E
		private void pictureBoxSave_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxSave.Image = Resources.icon_btn_021;
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x00055F60 File Offset: 0x00054160
		private void pictureBoxSave_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxSave.Image = Resources.icon_btn_020;
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x00055F72 File Offset: 0x00054172
		private void pictureBoxSave_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxSave.Image = Resources.icon_btn_021;
				this.saveFile(this._filePath);
			}
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x00055F9D File Offset: 0x0005419D
		private void pictureBoxUndo_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxUndo.Image = Resources.icon_btn_032;
			}
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00055FBC File Offset: 0x000541BC
		private void pictureBoxUndo_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxUndo.Image = Resources.icon_btn_031;
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00055FCE File Offset: 0x000541CE
		private void pictureBoxUndo_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxUndo.Image = Resources.icon_btn_030;
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00055FE0 File Offset: 0x000541E0
		private void pictureBoxUndo_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxUndo.Image = Resources.icon_btn_031;
				this.undo();
			}
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x00056005 File Offset: 0x00054205
		private void pictureBoxRedo_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRedo.Image = Resources.icon_btn_042;
			}
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x00056024 File Offset: 0x00054224
		private void pictureBoxRedo_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxRedo.Image = Resources.icon_btn_041;
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x00056036 File Offset: 0x00054236
		private void pictureBoxRedo_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxRedo.Image = Resources.icon_btn_040;
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x00056048 File Offset: 0x00054248
		private void pictureBoxRedo_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRedo.Image = Resources.icon_btn_041;
				this.redo();
			}
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0005606D File Offset: 0x0005426D
		private void pictureBoxCut_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCut.Image = Resources.icon_btn_052;
			}
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0005608C File Offset: 0x0005428C
		private void pictureBoxCut_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxCut.Image = Resources.icon_btn_051;
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0005609E File Offset: 0x0005429E
		private void pictureBoxCut_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxCut.Image = Resources.icon_btn_050;
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x000560B0 File Offset: 0x000542B0
		private void pictureBoxCut_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCut.Image = Resources.icon_btn_051;
				this.cutSelectBlocks();
			}
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x000560D5 File Offset: 0x000542D5
		private void pictureBoxCopy_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCopy.Image = Resources.icon_btn_062;
			}
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x000560F4 File Offset: 0x000542F4
		private void pictureBoxCopy_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxCopy.Image = Resources.icon_btn_061;
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x00056106 File Offset: 0x00054306
		private void pictureBoxCopy_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxCopy.Image = Resources.icon_btn_060;
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x00056118 File Offset: 0x00054318
		private void pictureBoxCopy_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCopy.Image = Resources.icon_btn_061;
				this.copySelectBlocks();
			}
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x0005613E File Offset: 0x0005433E
		private void pictureBoxPaste_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxPaste.Image = Resources.icon_btn_072;
			}
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x0005615D File Offset: 0x0005435D
		private void pictureBoxPaste_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxPaste.Image = Resources.icon_btn_071;
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x0005616F File Offset: 0x0005436F
		private void pictureBoxPaste_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxPaste.Image = Resources.icon_btn_070;
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x00056181 File Offset: 0x00054381
		private void pictureBoxPaste_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxPaste.Image = Resources.icon_btn_071;
				this.pasteBlocks();
			}
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x000561A6 File Offset: 0x000543A6
		private void pictureBoxRun_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRun.Image = Resources.icon_btn_092;
			}
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x000561C5 File Offset: 0x000543C5
		private void pictureBoxRun_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxRun.Image = Resources.icon_btn_091;
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x000561D7 File Offset: 0x000543D7
		private void pictureBoxRun_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxRun.Image = Resources.icon_btn_090;
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x000561EC File Offset: 0x000543EC
		private void pictureBoxRun_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this._tutorial == NetworkWindow.TUTORIAL.RUN || this._tutorial == NetworkWindow.TUTORIAL.RUN_2)
				{
					NetworkWindow.TUTORIAL tutorial = this.Tutorial;
					this.Tutorial = tutorial + 1;
				}
				this.pictureBoxRun.Image = Resources.icon_btn_091;
				this.runProgram();
			}
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x00056240 File Offset: 0x00054440
		private void pictureBoxChange_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxChange.Image = Resources.icon_btn_112;
			}
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0005625F File Offset: 0x0005445F
		private void pictureBoxChange_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxChange.Image = Resources.icon_btn_111;
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00056271 File Offset: 0x00054471
		private void pictureBoxChange_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxChange.Image = Resources.icon_btn_110;
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x00056283 File Offset: 0x00054483
		private void pictureBoxChange_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxChange.Image = Resources.icon_btn_111;
				this.convert();
			}
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x000562A8 File Offset: 0x000544A8
		private void pictureBoxReport_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxReport.Image = Resources.icon_btn_122;
			}
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x000562C7 File Offset: 0x000544C7
		private void pictureBoxReport_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxReport.Image = Resources.icon_btn_121;
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x000562D9 File Offset: 0x000544D9
		private void pictureBoxReport_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxReport.Image = Resources.icon_btn_120;
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x000562EC File Offset: 0x000544EC
		private void pictureBoxReport_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxReport.Image = Resources.icon_btn_121;
				this._programs.clearSelectBlocks();
				this.updateProgramTextBoxSelect();
				new ReportWindow(ReportWindow.REPORT.NETWORK, null, null, this._programs).ShowDialog();
			}
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0005633C File Offset: 0x0005453C
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
			this.updateLevel();
			this.pictureBoxArrowUp.Visible = true;
			this.pictureBoxArrowDown.Visible = true;
			this.pictureBoxArrowDown.BringToFront();
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0005640C File Offset: 0x0005460C
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

		// Token: 0x060007C0 RID: 1984 RVA: 0x000564BA File Offset: 0x000546BA
		private void pictureBoxArrowLeft_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowLeft.Image = Resources.icon_btn_222;
			}
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x000564D9 File Offset: 0x000546D9
		private void pictureBoxArrowLeft_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowLeft.Image = Resources.icon_btn_221;
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x000564EB File Offset: 0x000546EB
		private void pictureBoxArrowLeft_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowLeft.Image = Resources.icon_btn_220;
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x000564FD File Offset: 0x000546FD
		private void pictureBoxArrowLeft_MouseUp(object sender, MouseEventArgs e)
		{
			this.setScrollH(Math.Max(Math.Min(this._scrollIndexH - 1, this._buttonTools.Count - 1), -1));
			this.pictureBoxArrowLeft.Image = Resources.icon_btn_221;
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x00056535 File Offset: 0x00054735
		private void pictureBoxArrowRight_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowRight.Image = Resources.icon_btn_212;
			}
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x00056554 File Offset: 0x00054754
		private void pictureBoxArrowRight_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowRight.Image = Resources.icon_btn_211;
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x00056566 File Offset: 0x00054766
		private void pictureBoxArrowRight_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowRight.Image = Resources.icon_btn_210;
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x00056578 File Offset: 0x00054778
		private void pictureBoxArrowRight_MouseUp(object sender, MouseEventArgs e)
		{
			int num = (this.pictureBoxArrowRight.Parent.Width - this.pictureBoxArrowRight.Width - this._buttonTools[0].Location.X) / 72;
			this.setScrollH(Math.Max(Math.Min(this._scrollIndexH + 1, this._buttonTools.Count - num), 0));
			this.pictureBoxArrowRight.Image = Resources.icon_btn_211;
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x000565F5 File Offset: 0x000547F5
		private void pictureBoxArrowUp_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowUp.Image = Resources.icon_btn_192;
			}
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x00056614 File Offset: 0x00054814
		private void pictureBoxArrowUp_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowUp.Image = Resources.icon_btn_191;
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x00056626 File Offset: 0x00054826
		private void pictureBoxArrowUp_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowUp.Image = Resources.icon_btn_190;
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x00056638 File Offset: 0x00054838
		private void pictureBoxArrowUp_MouseUp(object sender, MouseEventArgs e)
		{
			this.setScrollV(Math.Max(Math.Min(this._scrollIndexV - 1, this._buttonBlocks.Count - 1), 0));
			this.pictureBoxArrowUp.Image = Resources.icon_btn_191;
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x00056670 File Offset: 0x00054870
		private void pictureBoxArrowDown_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowDown.Image = Resources.icon_btn_202;
			}
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x0005668F File Offset: 0x0005488F
		private void pictureBoxArrowDown_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowDown.Image = Resources.icon_btn_201;
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x000566A1 File Offset: 0x000548A1
		private void pictureBoxArrowDown_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowDown.Image = Resources.icon_btn_200;
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x000566B4 File Offset: 0x000548B4
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

		// Token: 0x060007D0 RID: 2000 RVA: 0x0005673D File Offset: 0x0005493D
		private void 新規作成NToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.newFile();
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x00056745 File Offset: 0x00054945
		private void ファイルを開くOToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.openFile();
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x0005674D File Offset: 0x0005494D
		private void 上書き保存SToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.saveFile(this._filePath);
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0005675B File Offset: 0x0005495B
		private void 名前を付けて保存AToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.saveFileAs();
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x000286B1 File Offset: 0x000268B1
		private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x00056763 File Offset: 0x00054963
		private void 元に戻すUToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.undo();
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0005676B File Offset: 0x0005496B
		private void やり直しRToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.redo();
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x00056774 File Offset: 0x00054974
		private void 切り取りTToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.ObjectPropertyArea.Controls)
			{
				if (obj is TextBox)
				{
					TextBox textBox = (TextBox)obj;
					if (textBox.Focused)
					{
						textBox.Cut();
						return;
					}
				}
			}
			this.cutSelectBlocks();
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x000567EC File Offset: 0x000549EC
		private void コピ\u30FCCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.ObjectPropertyArea.Controls)
			{
				if (obj is TextBox)
				{
					TextBox textBox = (TextBox)obj;
					if (textBox.Focused)
					{
						textBox.Copy();
						return;
					}
				}
			}
			this.copySelectBlocks();
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x00056864 File Offset: 0x00054A64
		private void 貼り付けPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.ObjectPropertyArea.Controls)
			{
				if (obj is TextBox)
				{
					TextBox textBox = (TextBox)obj;
					if (textBox.Focused)
					{
						textBox.Paste();
						return;
					}
				}
			}
			this.pasteBlocks();
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x000568DC File Offset: 0x00054ADC
		private void 削除DToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.ObjectPropertyArea.Controls)
			{
				if (obj is TextBox)
				{
					TextBox textBox = (TextBox)obj;
					if (textBox.Focused)
					{
						if (textBox.SelectedText.Length > 0)
						{
							textBox.SelectedText = "";
							return;
						}
						if (textBox.SelectionStart < textBox.Text.Length)
						{
							int selectionStart = textBox.SelectionStart;
							textBox.Text = textBox.Text.Remove(textBox.SelectionStart, 1);
							textBox.SelectionStart = selectionStart;
						}
						return;
					}
				}
			}
			this._flowchartArea.removeSelectBlocks();
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x000569AC File Offset: 0x00054BAC
		private void すべて選択AToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._flowchartArea.setSelectAll();
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x000569B9 File Offset: 0x00054BB9
		private void プログラム実行EToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.runProgram();
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x000569C4 File Offset: 0x00054BC4
		private void 通信エラ\u30FCでプログラムを停止するIToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (ConfigFile.Instance.Data.NetworkErrorStop != toolStripMenuItem.Checked)
			{
				ConfigFile.Instance.Data.NetworkErrorStop = toolStripMenuItem.Checked;
				ConfigFile.Instance.Save();
			}
			this.StopProgramWithErrorFlag = !this.StopProgramWithErrorFlag;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x00056A2C File Offset: 0x00054C2C
		private void レポ\u30FCト作成RToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new ReportWindow(ReportWindow.REPORT.NETWORK, null, null, this._programs).ShowDialog();
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x00056A44 File Offset: 0x00054C44
		private void グリッドGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (ConfigFile.Instance.Data.NetworkGrid != toolStripMenuItem.Checked)
			{
				ConfigFile.Instance.Data.NetworkGrid = toolStripMenuItem.Checked;
				ConfigFile.Instance.Save();
			}
			this._flowchartArea.Grid = !this._flowchartArea.Grid;
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x00056AB6 File Offset: 0x00054CB6
		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.convert();
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x00056AC0 File Offset: 0x00054CC0
		private void プログラムのスクリ\u30FCンショットをコピ\u30FCCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Rectangle reportRect = this._flowchartArea.getReportRect();
			Bitmap bitmap = new Bitmap(reportRect.X + reportRect.Width, reportRect.Y + reportRect.Height);
			this._flowchartArea.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
			bitmap = bitmap.Clone(reportRect, bitmap.PixelFormat);
			Clipboard.SetImage(bitmap);
			bitmap.Dispose();
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x00056B38 File Offset: 0x00054D38
		private void プログラムのスクリ\u30FCンショットを保存VToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Rectangle reportRect = this._flowchartArea.getReportRect();
			Bitmap bitmap = new Bitmap(reportRect.X + reportRect.Width, reportRect.Y + reportRect.Height);
			this._flowchartArea.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
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

		// Token: 0x060007E3 RID: 2019 RVA: 0x00056BF4 File Offset: 0x00054DF4
		private void パラメ\u30FCタ表示DToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (ConfigFile.Instance.Data.NetworkParameter != toolStripMenuItem.Checked)
			{
				ConfigFile.Instance.Data.NetworkParameter = toolStripMenuItem.Checked;
				ConfigFile.Instance.Save();
			}
			this._flowchartArea.Detail = !this._flowchartArea.Detail;
			this._flowchartArea.Invalidate();
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x00056C71 File Offset: 0x00054E71
		private void デ\u30FCタ設定DToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NetworkDataWindow networkDataWindow = new NetworkDataWindow(this._programs);
			networkDataWindow.ShowDialog();
			if (networkDataWindow.Updated)
			{
				this.updateData();
			}
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00056C94 File Offset: 0x00054E94
		private void 各種情報表示ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (ConfigFile.Instance.Data.NetworkInformation != toolStripMenuItem.Checked)
			{
				ConfigFile.Instance.Data.NetworkInformation = toolStripMenuItem.Checked;
				ConfigFile.Instance.Save();
			}
			this.InformationViewFlag = !this.InformationViewFlag;
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x00056CFC File Offset: 0x00054EFC
		private void 選択メニュ\u30FC表示EToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (ConfigFile.Instance.Data.NetworkDisplayControl != toolStripMenuItem.Checked)
			{
				ConfigFile.Instance.Data.NetworkDisplayControl = toolStripMenuItem.Checked;
				ConfigFile.Instance.Save();
			}
			this._flowchartArea.DisplayControl = !this._flowchartArea.DisplayControl;
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x00056D6E File Offset: 0x00054F6E
		private void サ\u30FCバ\u30FCクライアント設定NToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new NetworkConnectionWindow().ShowDialog();
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x00056D7B File Offset: 0x00054F7B
		private void 通信チェックCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new NetworkCheckWindow().ShowDialog();
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x00056D88 File Offset: 0x00054F88
		private void ポ\u30FCト番号指定PToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new NetworkPortWindow().ShowDialog();
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x00056D98 File Offset: 0x00054F98
		private void サ\u30FCバデ\u30FCタの情報を共有するSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (ConfigFile.Instance.Data.NetworkServerDataShare != toolStripMenuItem.Checked)
			{
				ConfigFile.Instance.Data.NetworkServerDataShare = toolStripMenuItem.Checked;
				ConfigFile.Instance.Save();
			}
			this.ServerDataShareFlag = !this.ServerDataShareFlag;
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x00028AD2 File Offset: 0x00026CD2
		private void ヘルプ表示BToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(".\\説明書\\Manual.pdf");
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x00028ADF File Offset: 0x00026CDF
		private void バ\u30FCジョン情報VToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new VersionDialog().ShowDialog();
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x00056E00 File Offset: 0x00055000
		private void 外部入出力に対応UToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (ConfigFile.Instance.Data.NetworkUsbInOut != toolStripMenuItem.Checked)
			{
				ConfigFile.Instance.Data.NetworkUsbInOut = toolStripMenuItem.Checked;
				ConfigFile.Instance.Save();
			}
			this.updateUsbInOutEnable();
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x00056E5F File Offset: 0x0005505F
		private void 左揃えToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._flowchartArea.alignSelectBlocks(NetworkFlowchartArea.ALIGNMENT.LEFT);
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x00056E6D File Offset: 0x0005506D
		private void 右揃えToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._flowchartArea.alignSelectBlocks(NetworkFlowchartArea.ALIGNMENT.RIGHT);
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x00056E7B File Offset: 0x0005507B
		private void 上揃えToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._flowchartArea.alignSelectBlocks(NetworkFlowchartArea.ALIGNMENT.UP);
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x00056E89 File Offset: 0x00055089
		private void 下揃えToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._flowchartArea.alignSelectBlocks(NetworkFlowchartArea.ALIGNMENT.BOTTOM);
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x00056E97 File Offset: 0x00055097
		private void 矢印を削除ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._flowchartArea.removeSelectBlockArrows();
		}

		// Token: 0x04000534 RID: 1332
		private const string PROTOCOL = "NetworkWindow:";

		// Token: 0x04000535 RID: 1333
		private string extention;

		// Token: 0x04000536 RID: 1334
		private static NetworkWindow _instance = null;

		// Token: 0x04000537 RID: 1335
		private NetworkObjectArea _objectArea;

		// Token: 0x04000538 RID: 1336
		private NetworkObjectInput _objectInput;

		// Token: 0x04000539 RID: 1337
		private NetworkObjectIconArea _objectIconArea;

		// Token: 0x0400053A RID: 1338
		private NetworkObjectSoundArea _objectSoundArea;

		// Token: 0x0400053B RID: 1339
		private NetworkObjectPropertyArea _objectPropertyArea;

		// Token: 0x0400053D RID: 1341
		private NetworkFlowchartArea _flowchartArea;

		// Token: 0x0400053E RID: 1342
		private NetworkFlowchartTab[] _flowchartTabs = new NetworkFlowchartTab[2];

		// Token: 0x0400053F RID: 1343
		private NetworkFlowchartTab.TAB _flowchartTabIndex = NetworkFlowchartTab.TAB.INVALID;

		// Token: 0x04000540 RID: 1344
		private NetworkObjectTab[] _objectTabs = new NetworkObjectTab[3];

		// Token: 0x04000541 RID: 1345
		private NetworkObjectTab.TAB _objectTabIndex = NetworkObjectTab.TAB.INVALID;

		// Token: 0x04000542 RID: 1346
		private bool _runningFlag;

		// Token: 0x04000546 RID: 1350
		private NetworkWindow.CopyObject _copyObject = new NetworkWindow.CopyObject();

		// Token: 0x04000547 RID: 1351
		private string _filePath = "";

		// Token: 0x04000548 RID: 1352
		private bool _convert;

		// Token: 0x04000549 RID: 1353
		private NetworkProgramModules _programs = new NetworkProgramModules();

		// Token: 0x0400054A RID: 1354
		private History _history = new History();

		// Token: 0x0400054B RID: 1355
		private Cursor cursorEvent = CursorCreator.CreateCursor(Resources.nw_btn_000, Resources.nw_btn_000.Width / 2, Resources.nw_btn_000.Height / 2);

		// Token: 0x0400054C RID: 1356
		private Cursor cursorMessage = CursorCreator.CreateCursor(Resources.nw_btn_010, Resources.nw_btn_010.Width / 2, Resources.nw_btn_010.Height / 2);

		// Token: 0x0400054D RID: 1357
		private Cursor cursorCommunication = CursorCreator.CreateCursor(Resources.nw_btn_020, Resources.nw_btn_020.Width / 2, Resources.nw_btn_020.Height / 2);

		// Token: 0x0400054E RID: 1358
		private Cursor cursorWait = CursorCreator.CreateCursor(Resources.icon_btn_150, Resources.icon_btn_150.Width / 2, Resources.icon_btn_150.Height / 2);

		// Token: 0x0400054F RID: 1359
		private Cursor cursorCounter = CursorCreator.CreateCursor(Resources.fc_btn_000, Resources.fc_btn_000.Width / 2, Resources.fc_btn_000.Height / 2);

		// Token: 0x04000550 RID: 1360
		private Cursor cursorData = CursorCreator.CreateCursor(Resources.nw_btn_030, Resources.nw_btn_030.Width / 2, Resources.nw_btn_030.Height / 2);

		// Token: 0x04000551 RID: 1361
		private Cursor cursorIf = CursorCreator.CreateCursor(Resources.fc_btn_010, Resources.fc_btn_010.Width / 2, Resources.fc_btn_010.Height / 2);

		// Token: 0x04000552 RID: 1362
		private Cursor cursorIfElse = CursorCreator.CreateCursor(Resources.bp_btn_060, Resources.bp_btn_060.Width / 2, Resources.bp_btn_060.Height / 2);

		// Token: 0x04000553 RID: 1363
		private Cursor cursorLoopStart = CursorCreator.CreateCursor(Resources.icon_btn_160, Resources.icon_btn_160.Width / 2, Resources.icon_btn_160.Height / 2);

		// Token: 0x04000554 RID: 1364
		private Cursor cursorLoopEnd = CursorCreator.CreateCursor(Resources.icon_btn_170, Resources.icon_btn_170.Width / 2, Resources.icon_btn_170.Height / 2);

		// Token: 0x04000555 RID: 1365
		private Cursor cursorDisplay = CursorCreator.CreateCursor(Resources.nw_btn_050, Resources.nw_btn_050.Width / 2, Resources.nw_btn_050.Height / 2);

		// Token: 0x04000556 RID: 1366
		private Cursor cursorOutput = CursorCreator.CreateCursor(Resources.nw_btn_040, Resources.nw_btn_040.Width / 2, Resources.nw_btn_040.Height / 2);

		// Token: 0x04000557 RID: 1367
		private Cursor cursorUsbOut = CursorCreator.CreateCursor(Resources.fc_btn_050, Resources.fc_btn_050.Width / 2, Resources.fc_btn_050.Height / 2);

		// Token: 0x04000558 RID: 1368
		private Cursor cursorSound = CursorCreator.CreateCursor(Resources.icon_btn_140, Resources.icon_btn_140.Width / 2, Resources.icon_btn_140.Height / 2);

		// Token: 0x04000559 RID: 1369
		private Cursor cursorJump = CursorCreator.CreateCursor(Resources.bp_btn_110, Resources.bp_btn_110.Width / 2, Resources.bp_btn_110.Height / 2);

		// Token: 0x0400055A RID: 1370
		private Cursor cursorLabel = CursorCreator.CreateCursor(Resources.bp_btn_120, Resources.bp_btn_120.Width / 2, Resources.bp_btn_120.Height / 2);

		// Token: 0x0400055B RID: 1371
		private Timer _timer = new Timer();

		// Token: 0x0400055C RID: 1372
		private int _scrollIndexV;

		// Token: 0x0400055D RID: 1373
		private int _scrollIndexH;

		// Token: 0x0400055E RID: 1374
		private List<PictureBox> _buttonBlocks = new List<PictureBox>();

		// Token: 0x0400055F RID: 1375
		private List<PictureBox> _buttonTools = new List<PictureBox>();

		// Token: 0x04000561 RID: 1377
		private NetworkProgramModules.ObjectInfo _storeSelectedObject;

		// Token: 0x04000562 RID: 1378
		private static string _blockProgramBackup = "";

		// Token: 0x04000563 RID: 1379
		private TutorialWindow _tutorialWindow;

		// Token: 0x04000564 RID: 1380
		private NetworkWindow.TUTORIAL _tutorial;

		// Token: 0x04000565 RID: 1381
		private readonly string[] _tutorialTexts = new string[]
		{
			"ここでは文字を表示させるコンテンツを作ります。\r\n「はじめる」ボタンを押してください。", "小さな画面の指示に従って操作してください。\r\n※指示以外の操作は受け付けないようになっています。", "①コンテンツ作成エリアに「テキスト表示」を配置しましょう。", "②コンテンツ作成エリアに「ボタン」を配置しましょう。", "③機能のサイズを変更しましょう。", "④「ボタン」機能をクリックして選択しましょう。", "⑤表示ブロックを配置しましょう。", "⑥配置された表示ブロックをダブルクリックして開きましょう。", "⑦「テキスト表示」、「テキスト表示１」、「表示する」を選択し、\r\nテキストボックスに文字を入力し「OK」ボタンを押しましょう。", "⑧イベントブロック→表示ブロック→終了ブロックの順に\r\nつなぎましょう。",
			"⑨プログラムを実行しましょう。", "⑩実行画面の「ボタン」をクリックしましょう。", "⑪実行画面を閉じましょう。", "⑫入力バーをクリックしましょう。", "⑬表示ブロックを配置しましょう。", "⑭配置された表示ブロックをダブルクリックして開きましょう。", "⑮「テキスト表示」、「テキスト表示１」、「表示する」、「入力変数」を選択し、\r\n「OK」ボタンを押しましょう。", "⑯イベントブロック→表示ブロック→終了ブロックの順に\r\nつなぎましょう。", "⑰プログラムを実行しましょう。", "⑱入力バーに文字を入力して確定ボタンをクリックしましょう。",
			"⑲実行画面を閉じましょう。", "つかいかたはこれで終わりです。\r\n今度は自分でいろいろなコンテンツをつくってみましょう。"
		};

		// Token: 0x04000566 RID: 1382
		private readonly string[] _tutorialTextsBlock = new string[]
		{
			"ここでは文字を表示させるコンテンツを作ります。\r\n「はじめる」ボタンを押してください。", "小さな画面の指示に従って操作してください。\r\n※指示以外の操作は受け付けないようになっています。", "①コンテンツ作成エリアに「テキスト表示」を配置しましょう。", "②コンテンツ作成エリアに「ボタン」を配置しましょう。", "③機能のサイズを変更しましょう。", "④「ボタン」機能をクリックして選択しましょう。", "⑤表示ブロックを配置しましょう。", "⑥配置された表示ブロックをダブルクリックして開きましょう。", "⑦「テキスト表示」、「テキスト表示１」、「表示する」を選択し、\r\nテキストボックスに文字を入力し「OK」ボタンを押しましょう。", "⑧イベントブロックと終了ブロックの間に表示ブロックを入れましょう。",
			"⑨プログラムを実行しましょう。", "⑩実行画面の「ボタン」をクリックしましょう。", "⑪実行画面を閉じましょう。", "⑫入力バーをクリックしましょう。", "⑬表示ブロックを配置しましょう。", "⑭配置された表示ブロックをダブルクリックして開きましょう。", "⑮「テキスト表示」、「テキスト表示１」、「表示する」、「入力変数」を選択し、\r\n「OK」ボタンを押しましょう。", "⑯イベントブロックと終了ブロックの間に表示ブロックを入れましょう。", "⑰プログラムを実行しましょう。", "⑱入力バーに文字を入力して確定ボタンをクリックしましょう。",
			"⑲実行画面を閉じましょう。", "つかいかたはこれで終わりです。\r\n今度は自分でいろいろなコンテンツをつくってみましょう。"
		};

		// Token: 0x04000567 RID: 1383
		private readonly Image[] _tutorialImages = new Image[]
		{
			Resources.tutorial_nw_000,
			Resources.tutorial_nw_018,
			Resources.tutorial_nw_001,
			Resources.tutorial_nw_002,
			Resources.tutorial_nw_003,
			Resources.tutorial_nw_004,
			Resources.tutorial_nw_005,
			Resources.tutorial_nw_006,
			Resources.tutorial_nw_007,
			Resources.tutorial_nw_008,
			Resources.tutorial_nw_009,
			Resources.tutorial_nw_010,
			Resources.tutorial_nw_011,
			Resources.tutorial_nw_012,
			Resources.tutorial_nw_013,
			Resources.tutorial_nw_006,
			Resources.tutorial_nw_014,
			Resources.tutorial_nw_019,
			Resources.tutorial_nw_009,
			Resources.tutorial_nw_015,
			Resources.tutorial_nw_016,
			Resources.tutorial_nw_017
		};

		// Token: 0x04000568 RID: 1384
		private readonly Image[] _tutorialImagesBlock = new Image[]
		{
			Resources.tutorial_nw_000,
			Resources.tutorial_nw_018,
			Resources.tutorial_nw_bl_001,
			Resources.tutorial_nw_bl_002,
			Resources.tutorial_nw_bl_003,
			Resources.tutorial_nw_bl_004,
			Resources.tutorial_nw_bl_005,
			Resources.tutorial_nw_bl_006,
			Resources.tutorial_nw_bl_007,
			Resources.tutorial_nw_bl_008,
			Resources.tutorial_nw_bl_009,
			Resources.tutorial_nw_bl_010,
			Resources.tutorial_nw_bl_011,
			Resources.tutorial_nw_bl_012,
			Resources.tutorial_nw_bl_013,
			Resources.tutorial_nw_bl_006,
			Resources.tutorial_nw_bl_014,
			Resources.tutorial_nw_bl_019,
			Resources.tutorial_nw_bl_009,
			Resources.tutorial_nw_bl_015,
			Resources.tutorial_nw_bl_016,
			Resources.tutorial_nw_017
		};

		// Token: 0x020000C2 RID: 194
		public class CopyObject
		{
			// Token: 0x04000919 RID: 2329
			[XmlArrayItem(typeof(ProgramModule.BlockEvent))]
			[XmlArrayItem(typeof(ProgramModule.BlockEnd))]
			[XmlArrayItem(typeof(ProgramModule.BlockMessage))]
			[XmlArrayItem(typeof(ProgramModule.BlockCommunication))]
			[XmlArrayItem(typeof(ProgramModule.BlockWait))]
			[XmlArrayItem(typeof(ProgramModule.BlockCounter))]
			[XmlArrayItem(typeof(ProgramModule.BlockData))]
			[XmlArrayItem(typeof(ProgramModule.BlockIf))]
			[XmlArrayItem(typeof(ProgramModule.BlockLoopStart))]
			[XmlArrayItem(typeof(ProgramModule.BlockLoopEnd))]
			[XmlArrayItem(typeof(ProgramModule.BlockNetworkDisplay))]
			[XmlArrayItem(typeof(ProgramModule.BlockNetworkSound))]
			[XmlArrayItem(typeof(ProgramModule.BlockOutput))]
			[XmlArrayItem(typeof(ProgramModule.BlockUsbOut))]
			[XmlArrayItem(typeof(ProgramModule.BlockJump))]
			[XmlArrayItem(typeof(ProgramModule.BlockLabel))]
			public List<ProgramModule.Block> _blocks = new List<ProgramModule.Block>();
		}

		// Token: 0x020000C3 RID: 195
		public enum TUTORIAL
		{
			// Token: 0x0400091B RID: 2331
			START,
			// Token: 0x0400091C RID: 2332
			CAUTION,
			// Token: 0x0400091D RID: 2333
			DRAG_LABEL,
			// Token: 0x0400091E RID: 2334
			DRAG_BUTTON,
			// Token: 0x0400091F RID: 2335
			ADJUST_SPLITTER,
			// Token: 0x04000920 RID: 2336
			SELECT_BUTTON,
			// Token: 0x04000921 RID: 2337
			DRAG_DISPLAY,
			// Token: 0x04000922 RID: 2338
			DOUBLE_CLICK,
			// Token: 0x04000923 RID: 2339
			CHANGE_PROPERTY,
			// Token: 0x04000924 RID: 2340
			CONNECT_BLOCKS,
			// Token: 0x04000925 RID: 2341
			RUN,
			// Token: 0x04000926 RID: 2342
			CLICK_BUTTON,
			// Token: 0x04000927 RID: 2343
			CLOSE,
			// Token: 0x04000928 RID: 2344
			SELECT_INPUT,
			// Token: 0x04000929 RID: 2345
			DRAG_DISPLAY_2,
			// Token: 0x0400092A RID: 2346
			DOUBLE_CLICK_2,
			// Token: 0x0400092B RID: 2347
			CHANGE_PROPERTY_2,
			// Token: 0x0400092C RID: 2348
			CONNECT_BLOCKS_2,
			// Token: 0x0400092D RID: 2349
			RUN_2,
			// Token: 0x0400092E RID: 2350
			INPUT,
			// Token: 0x0400092F RID: 2351
			CLOSE_2,
			// Token: 0x04000930 RID: 2352
			END,
			// Token: 0x04000931 RID: 2353
			MAX
		}
	}
}
