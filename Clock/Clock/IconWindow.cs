using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000028 RID: 40
	public partial class IconWindow : Form
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x00030ED7 File Offset: 0x0002F0D7
		public IconArea Area
		{
			get
			{
				return this._area;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x00030EDF File Offset: 0x0002F0DF
		public ContextMenuStrip RightClickMenu
		{
			get
			{
				return this.contextMenuStrip1;
			}
		}

		// Token: 0x17000025 RID: 37
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x00030EE7 File Offset: 0x0002F0E7
		public SimulatorWindow SimulatorWindow
		{
			set
			{
				this._simulatorWindow = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x00030EF0 File Offset: 0x0002F0F0
		public ProgramModules Programs
		{
			get
			{
				return this._programs;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x00030EF8 File Offset: 0x0002F0F8
		public ProgramModule Program
		{
			get
			{
				return this._programs.Programs[0];
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x00030F07 File Offset: 0x0002F107
		public List<IconAreaBlock> AreaBlocks
		{
			get
			{
				return this._areaBlocks;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x00030F0F File Offset: 0x0002F10F
		public bool Convert
		{
			get
			{
				return this._convert;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060003BA RID: 954 RVA: 0x00030F17 File Offset: 0x0002F117
		// (set) Token: 0x060003BB RID: 955 RVA: 0x00030F20 File Offset: 0x0002F120
		public IconWindow.TUTORIAL Tutorial
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
					if (this._tutorial == IconWindow.TUTORIAL.CAUTION)
					{
						button_MODE = TutorialWindow.BUTTON_MODE.START;
					}
					this._tutorialWindow.initialize(this._tutorialImages[(int)this._tutorial], this._tutorialTexts[(int)this._tutorial], button_MODE);
				}
			}
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00030F76 File Offset: 0x0002F176
		public bool isTutorial()
		{
			return this._tutorialWindow != null;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00030F84 File Offset: 0x0002F184
		public IconWindow(ProgramModules programs, bool tutorial)
		{
			this.InitializeComponent();
			this._programs = programs;
			this._area = new IconArea(this);
			this.splitContainer4.Panel1.Controls.Add(this._area);
			this._area.Size = new Size(this.splitContainer4.Panel1.Width - 20, 2048);
			this._programTextBox = new ProgramTextBox();
			this._programTextBox.MouseDown += this.textBoxProgram_MouseDown;
			this.splitContainer4.Panel2.Controls.Add(this._programTextBox);
			this._programTextBox.Lines = new string[] { "start();", "end();" };
			this._programTextBox.Size = new Size(169, 582);
			if (this.Program.Blocks.Count > 2)
			{
				List<ProgramModule.Block> list = new List<ProgramModule.Block>();
				ProgramModule.Block block = this.Program.Start.Next;
				while (block.Next != null)
				{
					list.Add(block);
					block = block.Next;
				}
				this.Program.initialize(false, ProgramModule.BlockEvent.OBJECT_TYPE.INVALID);
				foreach (ProgramModule.Block block2 in list)
				{
					IconAreaBlock iconAreaBlock = new IconAreaBlock(this);
					iconAreaBlock.Type = IconAreaBlock.getType(block2);
					iconAreaBlock.Block = block2;
					this._area.Controls.Add(iconAreaBlock);
					this._areaBlocks.Add(iconAreaBlock);
					iconAreaBlock.updateView();
				}
			}
			if (tutorial)
			{
				this._tutorialWindow = new TutorialWindow(this);
				this._tutorialWindow.initialize(this._tutorialImages[(int)this._tutorial], this._tutorialTexts[(int)this._tutorial], TutorialWindow.BUTTON_MODE.START);
				this.updateEnables();
			}
			this.addAreaBlockBlank();
			this.updateLayout();
			this._history.initialize(this.serialize());
			this._timer = new System.Windows.Forms.Timer();
			this._timer.Tick += this.OnUpdateConnection;
			this._timer.Interval = 1000;
			this._timer.Start();
			this._area.DragEnter += this.IconWindow_DragEnter;
			this._area.DragDrop += this.IconWindow_DragDrop;
			this._buttonBlocks.Add(this.pictureBoxBlockLED);
			this._buttonBlocks.Add(this.pictureBoxBlockSound);
			this._buttonBlocks.Add(this.pictureBoxBlockWait);
			this._buttonBlocks.Add(this.pictureBoxBlockLoopStart);
			this._buttonBlocks.Add(this.pictureBoxBlockLoopEnd);
			this._buttonBlocks.Add(this.pictureBoxBlockWaitCondition);
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
			this.pictureBoxArrowUp.Visible = false;
			this.pictureBoxArrowDown.Visible = false;
			this.pictureBoxArrowLeft.Visible = false;
			this.pictureBoxArrowRight.Visible = false;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00031584 File Offset: 0x0002F784
		private void updateEnables()
		{
			bool flag = !this.isTutorial();
			this.menuStrip1.Enabled = flag;
			this.切り取りToolStripMenuItem1.Enabled = flag;
			this.コピ\u30FCToolStripMenuItem1.Enabled = flag;
			this.貼り付けToolStripMenuItem1.Enabled = flag;
			this.削除ToolStripMenuItem1.Enabled = flag;
			this.元に戻すToolStripMenuItem1.Enabled = flag;
			this.やり直すToolStripMenuItem1.Enabled = flag;
			this.すべて選択ToolStripMenuItem1.Enabled = flag;
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
			this.pictureBoxBlockWaitCondition.Enabled = flag;
			this._area.Enabled = flag;
			if (this.isTutorial())
			{
				switch (this._tutorial)
				{
				case IconWindow.TUTORIAL.DRAG_LED:
					this.pictureBoxBlockLED.Enabled = true;
					this._area.Enabled = true;
					return;
				case IconWindow.TUTORIAL.DOUBLE_CLICK:
					this._area.Enabled = true;
					return;
				case IconWindow.TUTORIAL.DETAIL:
				case IconWindow.TUTORIAL.CONNECT:
					break;
				case IconWindow.TUTORIAL.DRAG_SOUND:
					this.pictureBoxBlockSound.Enabled = true;
					this._area.Enabled = true;
					return;
				case IconWindow.TUTORIAL.WRITE:
					this.pictureBoxWrite.Enabled = true;
					return;
				case IconWindow.TUTORIAL.RUN:
					this.pictureBoxRun.Enabled = true;
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0003177C File Offset: 0x0002F97C
		public void reconnectBlocks()
		{
			if (this._areaBlocks.Count > 1)
			{
				this.Program.Start.Next = this._areaBlocks[0].Block;
				for (int i = 0; i < this._areaBlocks.Count - 2; i++)
				{
					this._areaBlocks[i].Block.Next = this._areaBlocks[i + 1].Block;
				}
				this._areaBlocks[this._areaBlocks.Count - 2].Block.Next = this.Program.End;
				return;
			}
			this.Program.Start.Next = this.Program.End;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00031848 File Offset: 0x0002FA48
		public IconAreaBlock addAreaBlockBlank()
		{
			IconAreaBlock iconAreaBlock = new IconAreaBlock(this);
			this._area.Controls.Add(iconAreaBlock);
			this._areaBlocks.Add(iconAreaBlock);
			return iconAreaBlock;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x0003187A File Offset: 0x0002FA7A
		public void insertAreaBlock(IconAreaBlock indexBlock, IconAreaBlock newBlock)
		{
			this._area.Controls.Add(newBlock);
			this._areaBlocks.Insert(this._areaBlocks.IndexOf(indexBlock), newBlock);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x000318A8 File Offset: 0x0002FAA8
		public void moveSelectAreaBlock(IconAreaBlock afterBlock)
		{
			int num = this._areaBlocks.IndexOf(afterBlock);
			if (num > this._areaBlocks.IndexOf(this._selectAreaBlocks[0]))
			{
				using (List<IconAreaBlock>.Enumerator enumerator = this._selectAreaBlocks.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IconAreaBlock iconAreaBlock = enumerator.Current;
						this._areaBlocks.Remove(iconAreaBlock);
						this._areaBlocks.Insert(num, iconAreaBlock);
					}
					goto IL_C4;
				}
			}
			int num2 = 0;
			foreach (IconAreaBlock iconAreaBlock2 in this._selectAreaBlocks)
			{
				this._areaBlocks.Remove(iconAreaBlock2);
				this._areaBlocks.Insert(num + num2, iconAreaBlock2);
				num2++;
			}
			IL_C4:
			this.updateLayout();
			this.updateLog("アイコンを移動");
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x000319A8 File Offset: 0x0002FBA8
		public void removeAreaBlock(IconAreaBlock block)
		{
			if (block.Type != IconAreaBlock.TYPE.BLANK)
			{
				this._area.Controls.Remove(block);
				this._areaBlocks.Remove(block);
				this.Program.removeBlock(block.Block, false);
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x000319E4 File Offset: 0x0002FBE4
		public void removeSelectAreaBlocks()
		{
			if (this._selectAreaBlocks.Count > 0)
			{
				foreach (IconAreaBlock iconAreaBlock in this._selectAreaBlocks)
				{
					if (iconAreaBlock.Select)
					{
						this.removeAreaBlock(iconAreaBlock);
					}
					iconAreaBlock.ContextMenuStrip = null;
					iconAreaBlock.Dispose();
				}
				this._selectAreaBlocks.Clear();
				this.updateProgramTextBoxSelect();
				this.updateLayout();
				this.updateLog("アイコンを削除");
				this.addHistory();
			}
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00031A84 File Offset: 0x0002FC84
		private void removeAllAreaBlocks()
		{
			this.Program.removeAllBlocks();
			foreach (IconAreaBlock iconAreaBlock in this._areaBlocks)
			{
				this._area.Controls.Remove(iconAreaBlock);
				iconAreaBlock.ContextMenuStrip = null;
				iconAreaBlock.Dispose();
			}
			this._selectAreaBlocks.Clear();
			this.updateProgramTextBoxSelect();
			this._areaBlocks.Clear();
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00031B18 File Offset: 0x0002FD18
		private void OnUpdateConnection(object sender, EventArgs e)
		{
			if (CommunicationModule.Instance.Connected)
			{
				this.pictureBoxConnection.Image = Resources.icon_usb_on;
				if (this._tutorial == IconWindow.TUTORIAL.CONNECT)
				{
					IconWindow.TUTORIAL tutorial = this.Tutorial;
					this.Tutorial = tutorial + 1;
					return;
				}
			}
			else
			{
				this.pictureBoxConnection.Image = Resources.icon_usb_off;
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00031B6C File Offset: 0x0002FD6C
		public void updateLayout()
		{
			int num = 0;
			int num2 = 0;
			foreach (IconAreaBlock iconAreaBlock in this._areaBlocks)
			{
				iconAreaBlock.Location = new Point(this.LEFT_TOP.X + num * (iconAreaBlock.Size.Width + 40), this.LEFT_TOP.Y + num2);
				num++;
				if (this.LEFT_TOP.X + (num + 1) * (iconAreaBlock.Size.Width + 40) >= this._area.Size.Width)
				{
					num = 0;
					num2 += iconAreaBlock.Size.Height + 50;
				}
			}
			if (this._area.Height < this.LEFT_TOP.Y + num2 + this._areaBlocks[0].Height + 50)
			{
				this._area.Size = new Size(this._area.Width, this.LEFT_TOP.Y + num2 + this._areaBlocks[0].Height + 50);
			}
			this._area.Invalidate();
			this.reconnectBlocks();
			this.Program.updateConnectState();
			List<IconAreaBlock> list = new List<IconAreaBlock>();
			foreach (IconAreaBlock iconAreaBlock2 in this._areaBlocks)
			{
				if (iconAreaBlock2.Type == IconAreaBlock.TYPE.LOOP_START)
				{
					list.Add(iconAreaBlock2);
					((ProgramModule.BlockLoopStart)iconAreaBlock2.Block).Index = list.IndexOf(iconAreaBlock2) + 1;
					iconAreaBlock2.updateView();
				}
				else if (iconAreaBlock2.Type == IconAreaBlock.TYPE.LOOP_END)
				{
					int i;
					for (i = list.Count - 1; i >= 0; i--)
					{
						if (list[i].Type == IconAreaBlock.TYPE.LOOP_START)
						{
							list[i] = iconAreaBlock2;
							break;
						}
					}
					((ProgramModule.BlockLoopEnd)iconAreaBlock2.Block).Index = i + 1;
					iconAreaBlock2.updateView();
				}
			}
			this.updateProgram();
			this.updateUsedMemory();
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00031DD4 File Offset: 0x0002FFD4
		public void updateUsedMemory()
		{
			int usedMemory = this.Program.getUsedMemory(false);
			this.toolStripStatusLabelUsedMemory.Text = "消費メモリ " + usedMemory.ToString() + "/" + 256.ToString();
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00031E1C File Offset: 0x0003001C
		public bool isMemoryOver(int addMemory)
		{
			return this.Program.getUsedMemory(false) + addMemory > 256;
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00031E36 File Offset: 0x00030036
		public void updateLog(string log)
		{
			this.toolStripStatusLabelLog.Text = log;
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00031E44 File Offset: 0x00030044
		public void updateProgram()
		{
			List<string> list = new List<string>();
			List<ProgramModule.Block> list2 = new List<ProgramModule.Block>();
			this.Program.getProgram(ref list, ref list2);
			this._programTextBox.setProgram(ref list, ref list2);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00031E7C File Offset: 0x0003007C
		private void updateTitle()
		{
			string text = "";
			if (this._filePath != "")
			{
				text = this._filePath.Substring(this._filePath.LastIndexOf("\\") + 1);
			}
			this.Text = "アイコンプログラム  " + text;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00031ED0 File Offset: 0x000300D0
		public void setSelect(IconAreaBlock block)
		{
			if (!block.Select && block.Type != IconAreaBlock.TYPE.BLANK)
			{
				block.Select = true;
				block.Invalidate();
				this._selectAreaBlocks.Add(block);
				this.updateProgramTextBoxSelect();
				this._selectCursorAreaBlock = block;
			}
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00031F08 File Offset: 0x00030108
		public void addSelect(IconAreaBlock block)
		{
			if (this._selectAreaBlocks.Count > 0)
			{
				if (!block.Select && block.Type != IconAreaBlock.TYPE.BLANK)
				{
					if (this._areaBlocks.IndexOf(block) < this._areaBlocks.IndexOf(this._selectAreaBlocks[0]))
					{
						int num = this._areaBlocks.IndexOf(this._selectAreaBlocks[0]);
						int num2 = 0;
						for (int i = this._areaBlocks.IndexOf(block); i < num; i++)
						{
							this._areaBlocks[i].Select = true;
							this._areaBlocks[i].Invalidate();
							this._selectAreaBlocks.Insert(num2, this._areaBlocks[i]);
							this._selectCursorAreaBlock = this._areaBlocks[i];
							num2++;
						}
					}
					else
					{
						for (int j = this._areaBlocks.IndexOf(this._selectAreaBlocks[this._selectAreaBlocks.Count - 1]) + 1; j <= this._areaBlocks.IndexOf(block); j++)
						{
							this._areaBlocks[j].Select = true;
							this._areaBlocks[j].Invalidate();
							this._selectAreaBlocks.Add(this._areaBlocks[j]);
							this._selectCursorAreaBlock = this._areaBlocks[j];
						}
					}
					this.updateProgramTextBoxSelect();
					return;
				}
			}
			else
			{
				this.setSelect(block);
			}
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00032080 File Offset: 0x00030280
		public void removeSelect(IconAreaBlock block)
		{
			foreach (IconAreaBlock iconAreaBlock in this._selectAreaBlocks)
			{
				if (block == iconAreaBlock)
				{
					this._selectAreaBlocks.Remove(block);
					this.updateProgramTextBoxSelect();
					block.Select = false;
					block.Invalidate();
					if (this._selectCursorAreaBlock == block)
					{
						this._selectCursorAreaBlock = null;
						break;
					}
					break;
				}
			}
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00032104 File Offset: 0x00030304
		public void setSelect(Rectangle rect)
		{
			int num = -1;
			int num2 = -2;
			for (int i = 0; i < this._areaBlocks.Count; i++)
			{
				if (this._areaBlocks[i].isIncluded(rect) && this._areaBlocks[i].Type != IconAreaBlock.TYPE.BLANK)
				{
					this._areaBlocks[i].Select = true;
					this._areaBlocks[i].Invalidate();
					num = ((num == -1) ? i : num);
					num2 = i;
				}
			}
			if (num >= 0)
			{
				if (num == num2)
				{
					this._selectAreaBlocks.Add(this._areaBlocks[num]);
					this._selectCursorAreaBlock = this._areaBlocks[num];
				}
				else
				{
					for (int j = num; j < num2 + 1; j++)
					{
						if (!this._areaBlocks[j].Select)
						{
							this._areaBlocks[j].Select = true;
							this._areaBlocks[j].Invalidate();
						}
						this._selectAreaBlocks.Add(this._areaBlocks[j]);
					}
					this._selectCursorAreaBlock = this._areaBlocks[num2];
				}
				this.updateProgramTextBoxSelect();
			}
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0003222C File Offset: 0x0003042C
		public void setSelectAll()
		{
			this.clearSelect();
			foreach (IconAreaBlock iconAreaBlock in this._areaBlocks)
			{
				if (iconAreaBlock.Type != IconAreaBlock.TYPE.BLANK)
				{
					this.setSelect(iconAreaBlock);
				}
			}
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00032290 File Offset: 0x00030490
		public void clearSelect()
		{
			this._selectAreaBlocks.Clear();
			this.updateProgramTextBoxSelect();
			this._selectCursorAreaBlock = null;
			foreach (IconAreaBlock iconAreaBlock in this._areaBlocks)
			{
				iconAreaBlock.Select = false;
				iconAreaBlock.Invalidate();
			}
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00032300 File Offset: 0x00030500
		public void updateSelect()
		{
			foreach (IconAreaBlock iconAreaBlock in this._areaBlocks)
			{
				if (iconAreaBlock.Block != null)
				{
					iconAreaBlock.Select = iconAreaBlock.Block.Selected;
					iconAreaBlock.Invalidate();
				}
			}
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0003236C File Offset: 0x0003056C
		public void addHistory()
		{
			this._programs.WriteAllBlocks.Clear();
			this._history.addHistory(this.serialize());
			this.resetSimulator();
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00032398 File Offset: 0x00030598
		private void updateProgramTextBoxSelect()
		{
			List<ProgramModule.Block> list = new List<ProgramModule.Block>();
			foreach (IconAreaBlock iconAreaBlock in this._selectAreaBlocks)
			{
				list.Add(iconAreaBlock.Block);
			}
			this._programTextBox.setSelectBlocks(ref list, null);
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00032404 File Offset: 0x00030604
		private void resetSimulator()
		{
			if (this._simulatorWindow != null)
			{
				this._simulatorWindow.Simulator.initialize(this._programs);
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00032424 File Offset: 0x00030624
		private void cutSelectAreaBlocks()
		{
			this.copySelectAreaBlocks();
			this.removeSelectAreaBlocks();
			this.updateLog("アイコンを切り取り");
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00032440 File Offset: 0x00030640
		private bool copySelectAreaBlocks()
		{
			if (this._selectAreaBlocks.Count > 0)
			{
				this._copyObject._blocks.Clear();
				foreach (IconAreaBlock iconAreaBlock in this._selectAreaBlocks)
				{
					this._copyObject._blocks.Add(iconAreaBlock.Block);
				}
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(IconWindow.CopyObject));
				StringBuilder stringBuilder = new StringBuilder();
				StringWriter stringWriter = new StringWriter(stringBuilder);
				xmlSerializer.Serialize(stringWriter, this._copyObject);
				stringWriter.Close();
				Clipboard.SetText("IconWindow:" + stringBuilder.ToString());
				this.updateLog("アイコンをコピー");
				return true;
			}
			return false;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00032514 File Offset: 0x00030714
		private void pasteAreaBlocks()
		{
			string text = Clipboard.GetText();
			if (text.StartsWith("IconWindow:"))
			{
				text = text.TrimStart("IconWindow:".ToCharArray());
				IconWindow.CopyObject copyObject = new IconWindow.CopyObject();
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(IconWindow.CopyObject));
				StringReader stringReader = new StringReader(text);
				copyObject = (IconWindow.CopyObject)xmlSerializer.Deserialize(stringReader);
				stringReader.Close();
				int num = 0;
				foreach (ProgramModule.Block block in copyObject._blocks)
				{
					num += block.getUsedMemory();
				}
				if (this.isMemoryOver(num))
				{
					WarningDialog warningDialog = new WarningDialog();
					warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
					warningDialog.ShowDialog();
					return;
				}
				foreach (ProgramModule.Block block2 in copyObject._blocks)
				{
					IconAreaBlock iconAreaBlock = new IconAreaBlock(this);
					iconAreaBlock.Type = IconAreaBlock.getType(block2);
					iconAreaBlock.Block = block2;
					if (this._selectAreaBlocks.Count > 0)
					{
						this.insertAreaBlock(this._selectAreaBlocks[0], iconAreaBlock);
					}
					else
					{
						this.insertAreaBlock(this._areaBlocks[this._areaBlocks.Count - 1], iconAreaBlock);
					}
					this.updateLayout();
					iconAreaBlock.updateView();
				}
				this.updateLog("アイコンを貼り付け");
				this.addHistory();
			}
		}

		// Token: 0x060003DA RID: 986 RVA: 0x000326A8 File Offset: 0x000308A8
		private void undo()
		{
			string previous = this._history.getPrevious();
			if (previous != null)
			{
				this.deserialize(previous);
				this.updateLog("元に戻す");
				this.resetSimulator();
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x000326DC File Offset: 0x000308DC
		private void redo()
		{
			string next = this._history.getNext();
			if (next != null)
			{
				this.deserialize(next);
				this.updateLog("やり直し");
				this.resetSimulator();
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00032710 File Offset: 0x00030910
		private void newFile()
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "新規作成";
				confirmDialog.setText(IconWindow.WARNING_SAVE);
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (flag)
			{
				this._filePath = "";
				this.updateTitle();
				this._programs.Report = new ReportModule();
				this.removeAllAreaBlocks();
				this.addAreaBlockBlank();
				this.Program.addBlock(this.Program.Start);
				this.Program.addBlock(this.Program.End);
				this.updateLayout();
				this.updateLog("新規作成");
				this._history.initialize(this.serialize());
				this.resetSimulator();
				this._area.Focus();
			}
		}

		// Token: 0x060003DD RID: 989 RVA: 0x000327E8 File Offset: 0x000309E8
		private void openFile()
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "ファイルを開く";
				confirmDialog.setText(IconWindow.WARNING_SAVE);
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (flag)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.FileName = "プログラム.icp";
				openFileDialog.Filter = "プログラミングファイル(*.icp)|*.icp";
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

		// Token: 0x060003DE RID: 990 RVA: 0x0003288C File Offset: 0x00030A8C
		private void openFile(Stream stream)
		{
			StreamReader streamReader = new StreamReader(stream);
			this.deserialize(streamReader.ReadToEnd());
			this._programs.updateVersion();
			streamReader.Close();
			stream.Close();
			this.updateTitle();
			this._history.initialize(this.serialize());
			this.resetSimulator();
			this._area.Focus();
			this.updateLog("ファイルを開く");
		}

		// Token: 0x060003DF RID: 991 RVA: 0x000328F8 File Offset: 0x00030AF8
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

		// Token: 0x060003E0 RID: 992 RVA: 0x00032990 File Offset: 0x00030B90
		private void saveFileAs()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = ((this._filePath.Length > 0) ? Path.GetFileName(this._filePath) : "プログラム.icp");
			saveFileDialog.Filter = "プログラミングファイル(*.icp)|*.icp|すべてのファイル(*.*)|*.*";
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

		// Token: 0x060003E1 RID: 993 RVA: 0x00032A14 File Offset: 0x00030C14
		private string serialize()
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProgramModules));
			StringBuilder stringBuilder = new StringBuilder();
			StringWriter stringWriter = new StringWriter(stringBuilder);
			this.Program.saveConnectIndex(this.Program.Blocks, false);
			xmlSerializer.Serialize(stringWriter, this._programs);
			this.Program.restoreConnectIndex(this.Program.Blocks, false);
			stringWriter.Close();
			return stringBuilder.ToString();
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00032A84 File Offset: 0x00030C84
		private void deserialize(string xml)
		{
			this.removeAllAreaBlocks();
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProgramModules));
			StringReader stringReader = new StringReader(xml);
			ProgramModules programModules = (ProgramModules)xmlSerializer.Deserialize(stringReader);
			stringReader.Close();
			ProgramModule programModule = programModules.Programs[0];
			foreach (ProgramModule.Block block in programModule.Blocks)
			{
				if (block.GetType() == typeof(ProgramModule.BlockStart))
				{
					programModule.Start = (ProgramModule.BlockStart)block;
				}
				else if (block.GetType() == typeof(ProgramModule.BlockEnd))
				{
					programModule.End = (ProgramModule.BlockEnd)block;
				}
			}
			programModule.restoreConnectIndex(programModule.Blocks, false);
			this.constructAreaBlocks(programModule);
			this._programs.Report = programModules.Report;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00032B7C File Offset: 0x00030D7C
		private void constructAreaBlocks(ProgramModule program)
		{
			this.Program.Start = program.Start;
			this.Program.End = program.End;
			this.Program.addBlock(this.Program.Start);
			this.Program.addBlock(this.Program.End);
			ProgramModule.Block block = program.Start.Next;
			while (block.Next != null)
			{
				IconAreaBlock iconAreaBlock = new IconAreaBlock(this);
				iconAreaBlock.Type = IconAreaBlock.getType(block);
				iconAreaBlock.Block = block;
				this._area.Controls.Add(iconAreaBlock);
				this._areaBlocks.Add(iconAreaBlock);
				iconAreaBlock.updateView();
				block = block.Next;
			}
			this.addAreaBlockBlank();
			this.updateLayout();
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00032C40 File Offset: 0x00030E40
		private void writeProgram()
		{
			ProgramModule.ERROR error = this.Program.getError(this._programs.Programs, false);
			if (error == ProgramModule.ERROR.NONE)
			{
				if (!this._runningFlag && CommunicationModule.Instance.writeProgram(this._programs))
				{
					if (this.isTutorial())
					{
						IconWindow.TUTORIAL tutorial = this.Tutorial;
						this.Tutorial = tutorial + 1;
						return;
					}
					WriteInformationDialog writeInformationDialog = new WriteInformationDialog();
					writeInformationDialog.ShowDialog();
					if (writeInformationDialog.IsRun)
					{
						this.runProgram();
						return;
					}
				}
			}
			else
			{
				WarningDialog warningDialog = new WarningDialog();
				warningDialog.setText(ProgramModule.ERROR_ITEMS[(int)error]);
				warningDialog.ShowDialog();
			}
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00032CD0 File Offset: 0x00030ED0
		private void readProgram()
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "プログラム読込み";
				confirmDialog.setText(IconWindow.WARNING_SAVE);
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (!this._runningFlag && flag)
			{
				ProgramModules programModules = new ProgramModules();
				if (CommunicationModule.Instance.readProgram(programModules, true))
				{
					this.removeAllAreaBlocks();
					this.constructAreaBlocks(programModules.Programs[0]);
					this._history.initialize(this.serialize());
					this.resetSimulator();
				}
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00032D60 File Offset: 0x00030F60
		private async void runProgram()
		{
			if (!this._runningFlag && CommunicationModule.Instance.runProgram())
			{
				if (this.isTutorial())
				{
					IconWindow.TUTORIAL tutorial = this.Tutorial;
					this.Tutorial = tutorial + 1;
				}
				else
				{
					await Task.Run(delegate
					{
						this._programs.clearSelect();
						ProgramModule.Block block = null;
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
								if (block != null)
								{
									block.Selected = false;
									this.updateSelect();
									return;
								}
								break;
							}
							else
							{
								ProgramModule.Block block2 = this._programs.getBlock(runningByteIndex);
								if (block2 != null)
								{
									if (block != null)
									{
										block.Selected = false;
									}
									block2.Selected = true;
									if (block != block2)
									{
										this.updateSelect();
									}
									if (block2.GetType() == typeof(ProgramModule.BlockEnd))
									{
										this._runningFlag = false;
										return;
									}
									block = block2;
									Thread.Sleep(33);
								}
							}
						}
					});
				}
			}
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00032D97 File Offset: 0x00030F97
		private void stopProgram()
		{
			if (this._runningFlag)
			{
				this._runningStopFlag = true;
				return;
			}
			CommunicationModule.Instance.stopProgram(true);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00032DB5 File Offset: 0x00030FB5
		private void IconWindow_Shown(object sender, EventArgs e)
		{
			base.Activate();
			if (this.isTutorial())
			{
				this._tutorialWindow.Show();
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00032DD0 File Offset: 0x00030FD0
		private void IconWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool flag = true;
			if (!this.isTutorial() && !this._history.isSaved() && !this._convert)
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "終了";
				confirmDialog.setText(IconWindow.WARNING_SAVE);
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (!flag)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00032E30 File Offset: 0x00031030
		private void IconWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this._simulatorWindow != null)
			{
				this._simulatorWindow.Close();
			}
			if (this._tutorialWindow != null)
			{
				this._tutorialWindow.Close();
			}
			this._timer.Stop();
			this._runningFlag = false;
			CommunicationModule.Instance.stopProgram(false);
			base.Dispose();
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00032E88 File Offset: 0x00031088
		private void IconWindow_Resize(object sender, EventArgs e)
		{
			this._area.Size = new Size(this.splitContainer4.Panel1.Width - 20, 2048);
			this.updateLayout();
			if (base.Height < 530)
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

		// Token: 0x060003EC RID: 1004 RVA: 0x00032FAC File Offset: 0x000311AC
		private void IconWindow_KeyDown(object sender, KeyEventArgs e)
		{
			if (this._selectAreaBlocks.Count > 0)
			{
				if ((e.KeyData & Keys.Shift) == Keys.Shift)
				{
					if (e.KeyCode == Keys.Left)
					{
						int num = this._areaBlocks.IndexOf(this._selectCursorAreaBlock) - 1;
						if (num >= 0)
						{
							if (this._areaBlocks[num].Select)
							{
								this.removeSelect(this._areaBlocks[num + 1]);
								this._selectCursorAreaBlock = this._areaBlocks[num];
								return;
							}
							this.addSelect(this._areaBlocks[num]);
							return;
						}
					}
					else if (e.KeyCode == Keys.Right)
					{
						int num2 = this._areaBlocks.IndexOf(this._selectCursorAreaBlock) + 1;
						if (num2 < this._areaBlocks.Count - 1)
						{
							if (this._areaBlocks[num2].Select)
							{
								this.removeSelect(this._areaBlocks[num2 - 1]);
								this._selectCursorAreaBlock = this._areaBlocks[num2];
								return;
							}
							this.addSelect(this._areaBlocks[num2]);
							return;
						}
					}
				}
				else
				{
					if (e.KeyCode == Keys.Left)
					{
						int num3 = Math.Max(0, this._areaBlocks.IndexOf(this._selectAreaBlocks[0]) - 1);
						this.clearSelect();
						this.setSelect(this._areaBlocks[num3]);
						return;
					}
					if (e.KeyCode == Keys.Right)
					{
						int num4 = Math.Min(this._areaBlocks.Count - 2, this._areaBlocks.IndexOf(this._selectAreaBlocks[this._selectAreaBlocks.Count - 1]) + 1);
						this.clearSelect();
						this.setSelect(this._areaBlocks[num4]);
					}
				}
			}
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00033170 File Offset: 0x00031370
		private void pictureBoxNew_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxNew.Image = Resources.icon_btn_002;
			}
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0003318F File Offset: 0x0003138F
		private void pictureBoxNew_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxNew.Image = Resources.icon_btn_001;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x000331A1 File Offset: 0x000313A1
		private void pictureBoxNew_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxNew.Image = Resources.icon_btn_000;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x000331B3 File Offset: 0x000313B3
		private void pictureBoxNew_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxNew.Image = Resources.icon_btn_001;
				this.newFile();
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x000331D8 File Offset: 0x000313D8
		private void pictureBoxOpen_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxOpen.Image = Resources.icon_btn_012;
			}
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x000331F7 File Offset: 0x000313F7
		private void pictureBoxOpen_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxOpen.Image = Resources.icon_btn_011;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00033209 File Offset: 0x00031409
		private void pictureBoxOpen_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxOpen.Image = Resources.icon_btn_010;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0003321B File Offset: 0x0003141B
		private void pictureBoxOpen_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxOpen.Image = Resources.icon_btn_011;
				this.openFile();
			}
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00033240 File Offset: 0x00031440
		private void pictureBoxSave_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxSave.Image = Resources.icon_btn_022;
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0003325F File Offset: 0x0003145F
		private void pictureBoxSave_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxSave.Image = Resources.icon_btn_021;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00033271 File Offset: 0x00031471
		private void pictureBoxSave_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxSave.Image = Resources.icon_btn_020;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00033283 File Offset: 0x00031483
		private void pictureBoxSave_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxSave.Image = Resources.icon_btn_021;
				this.saveFile(this._filePath);
			}
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x000332AE File Offset: 0x000314AE
		private void pictureBoxUndo_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxUndo.Image = Resources.icon_btn_032;
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x000332CD File Offset: 0x000314CD
		private void pictureBoxUndo_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxUndo.Image = Resources.icon_btn_031;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x000332DF File Offset: 0x000314DF
		private void pictureBoxUndo_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxUndo.Image = Resources.icon_btn_030;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x000332F1 File Offset: 0x000314F1
		private void pictureBoxUndo_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxUndo.Image = Resources.icon_btn_031;
				this.undo();
			}
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00033316 File Offset: 0x00031516
		private void pictureBoxRedo_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRedo.Image = Resources.icon_btn_042;
			}
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00033335 File Offset: 0x00031535
		private void pictureBoxRedo_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxRedo.Image = Resources.icon_btn_041;
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00033347 File Offset: 0x00031547
		private void pictureBoxRedo_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxRedo.Image = Resources.icon_btn_040;
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00033359 File Offset: 0x00031559
		private void pictureBoxRedo_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRedo.Image = Resources.icon_btn_041;
				this.redo();
			}
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0003337E File Offset: 0x0003157E
		private void pictureBoxCut_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCut.Image = Resources.icon_btn_052;
			}
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0003339D File Offset: 0x0003159D
		private void pictureBoxCut_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxCut.Image = Resources.icon_btn_051;
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x000333AF File Offset: 0x000315AF
		private void pictureBoxCut_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxCut.Image = Resources.icon_btn_050;
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x000333C1 File Offset: 0x000315C1
		private void pictureBoxCut_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCut.Image = Resources.icon_btn_051;
				this.cutSelectAreaBlocks();
			}
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x000333E6 File Offset: 0x000315E6
		private void pictureBoxCopy_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCopy.Image = Resources.icon_btn_062;
			}
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00033405 File Offset: 0x00031605
		private void pictureBoxCopy_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxCopy.Image = Resources.icon_btn_061;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00033417 File Offset: 0x00031617
		private void pictureBoxCopy_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxCopy.Image = Resources.icon_btn_060;
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00033429 File Offset: 0x00031629
		private void pictureBoxCopy_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCopy.Image = Resources.icon_btn_061;
				this.copySelectAreaBlocks();
			}
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0003344F File Offset: 0x0003164F
		private void pictureBoxPaste_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxPaste.Image = Resources.icon_btn_072;
			}
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0003346E File Offset: 0x0003166E
		private void pictureBoxPaste_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxPaste.Image = Resources.icon_btn_071;
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00033480 File Offset: 0x00031680
		private void pictureBoxPaste_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxPaste.Image = Resources.icon_btn_070;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00033492 File Offset: 0x00031692
		private void pictureBoxPaste_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxPaste.Image = Resources.icon_btn_071;
				this.pasteAreaBlocks();
			}
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x000334B7 File Offset: 0x000316B7
		private void pictureBoxWrite_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxWrite.Image = Resources.icon_btn_082;
			}
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x000334D6 File Offset: 0x000316D6
		private void pictureBoxWrite_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxWrite.Image = Resources.icon_btn_081;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x000334E8 File Offset: 0x000316E8
		private void pictureBoxWrite_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxWrite.Image = Resources.icon_btn_080;
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x000334FA File Offset: 0x000316FA
		private void pictureBoxWrite_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxWrite.Image = Resources.icon_btn_081;
				this.writeProgram();
			}
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0003351F File Offset: 0x0003171F
		private void pictureBoxRun_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRun.Image = Resources.icon_btn_092;
			}
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0003353E File Offset: 0x0003173E
		private void pictureBoxRun_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxRun.Image = Resources.icon_btn_091;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00033550 File Offset: 0x00031750
		private void pictureBoxRun_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxRun.Image = Resources.icon_btn_090;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00033562 File Offset: 0x00031762
		private void pictureBoxRun_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRun.Image = Resources.icon_btn_091;
				this.runProgram();
			}
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00033587 File Offset: 0x00031787
		private void pictureBoxStop_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxStop.Image = Resources.icon_btn_102;
			}
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x000335A6 File Offset: 0x000317A6
		private void pictureBoxStop_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxStop.Image = Resources.icon_btn_101;
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x000335B8 File Offset: 0x000317B8
		private void pictureBoxStop_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxStop.Image = Resources.icon_btn_100;
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x000335CA File Offset: 0x000317CA
		private void pictureBoxStop_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxStop.Image = Resources.icon_btn_101;
				this.stopProgram();
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000335EF File Offset: 0x000317EF
		private void pictureBoxChange_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxChange.Image = Resources.icon_btn_112;
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0003360E File Offset: 0x0003180E
		private void pictureBoxChange_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxChange.Image = Resources.icon_btn_111;
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00033620 File Offset: 0x00031820
		private void pictureBoxChange_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxChange.Image = Resources.icon_btn_110;
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00033632 File Offset: 0x00031832
		private void pictureBoxChange_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxChange.Image = Resources.icon_btn_111;
				this.Program.convertToFlowchartProgram();
				this._convert = true;
				base.Close();
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00033669 File Offset: 0x00031869
		private void pictureBoxReport_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxReport.Image = Resources.icon_btn_122;
			}
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00033688 File Offset: 0x00031888
		private void pictureBoxReport_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxReport.Image = Resources.icon_btn_121;
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0003369A File Offset: 0x0003189A
		private void pictureBoxReport_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxReport.Image = Resources.icon_btn_120;
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x000336AC File Offset: 0x000318AC
		private void pictureBoxReport_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxReport.Image = Resources.icon_btn_121;
				new ReportWindow(ReportWindow.REPORT.ICON, this._programs, null, null).ShowDialog();
			}
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x000336DF File Offset: 0x000318DF
		private void pictureBoxBlockLED_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockLED.DoDragDrop("LED", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00033700 File Offset: 0x00031900
		private void pictureBoxBlockLED_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockLED.Image = Resources.icon_btn_131;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00033712 File Offset: 0x00031912
		private void pictureBoxBlockLED_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockLED.Image = Resources.icon_btn_130;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00033724 File Offset: 0x00031924
		private void pictureBoxBlockLED_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorLED;
				this.pictureBoxBlockLED.Image = Resources.icon_btn_132;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockLED.Image = Resources.icon_btn_130;
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00033779 File Offset: 0x00031979
		private void pictureBoxBlockLED_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockLED.Image = Resources.icon_btn_130;
			}
			this.scrollScreen();
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0003379B File Offset: 0x0003199B
		private void pictureBoxBlockSound_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockSound.DoDragDrop("SOUND", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000337BC File Offset: 0x000319BC
		private void pictureBoxBlockSound_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockSound.Image = Resources.icon_btn_141;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x000337CE File Offset: 0x000319CE
		private void pictureBoxBlockSound_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockSound.Image = Resources.icon_btn_140;
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x000337E0 File Offset: 0x000319E0
		private void pictureBoxBlockSound_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorSound;
				this.pictureBoxBlockSound.Image = Resources.icon_btn_142;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockSound.Image = Resources.icon_btn_140;
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00033835 File Offset: 0x00031A35
		private void pictureBoxBlockSound_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockSound.Image = Resources.icon_btn_140;
			}
			this.scrollScreen();
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00033857 File Offset: 0x00031A57
		private void pictureBoxBlockWait_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockWait.DoDragDrop("WAIT", DragDropEffects.Copy);
			}
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x00033878 File Offset: 0x00031A78
		private void pictureBoxBlockWait_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockWait.Image = Resources.icon_btn_151;
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0003388A File Offset: 0x00031A8A
		private void pictureBoxBlockWait_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockWait.Image = Resources.icon_btn_150;
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0003389C File Offset: 0x00031A9C
		private void pictureBoxBlockWait_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorWait;
				this.pictureBoxBlockWait.Image = Resources.icon_btn_152;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockWait.Image = Resources.icon_btn_150;
			}
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x000338F1 File Offset: 0x00031AF1
		private void pictureBoxBlockWait_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockWait.Image = Resources.icon_btn_150;
			}
			this.scrollScreen();
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00033913 File Offset: 0x00031B13
		private void pictureBoxBlockLoopStart_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockLoopStart.DoDragDrop("LOOP_START", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00033934 File Offset: 0x00031B34
		private void pictureBoxBlockLoopStart_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockLoopStart.Image = Resources.icon_btn_161;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00033946 File Offset: 0x00031B46
		private void pictureBoxBlockLoopStart_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockLoopStart.Image = Resources.icon_btn_160;
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00033958 File Offset: 0x00031B58
		private void pictureBoxBlockLoopStart_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorLoopStart;
				this.pictureBoxBlockLoopStart.Image = Resources.icon_btn_162;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockLoopStart.Image = Resources.icon_btn_160;
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000339AD File Offset: 0x00031BAD
		private void pictureBoxBlockLoopStart_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockLoopStart.Image = Resources.icon_btn_160;
			}
			this.scrollScreen();
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x000339CF File Offset: 0x00031BCF
		private void pictureBoxBlockLoopEnd_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockLoopEnd.DoDragDrop("LOOP_END", DragDropEffects.Copy);
			}
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x000339F0 File Offset: 0x00031BF0
		private void pictureBoxBlockLoopEnd_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockLoopEnd.Image = Resources.icon_btn_171;
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00033A02 File Offset: 0x00031C02
		private void pictureBoxBlockLoopEnd_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockLoopEnd.Image = Resources.icon_btn_170;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00033A14 File Offset: 0x00031C14
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

		// Token: 0x06000439 RID: 1081 RVA: 0x00033A69 File Offset: 0x00031C69
		private void pictureBoxBlockLoopEnd_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockLoopEnd.Image = Resources.icon_btn_170;
			}
			this.scrollScreen();
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00033A8B File Offset: 0x00031C8B
		private void pictureBoxBlockWaitCondition_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxBlockWaitCondition.DoDragDrop("WAIT_CONDITION", DragDropEffects.Copy);
			}
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00033AAC File Offset: 0x00031CAC
		private void pictureBoxBlockWaitCondition_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxBlockWaitCondition.Image = Resources.icon_btn_181;
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00033ABE File Offset: 0x00031CBE
		private void pictureBoxBlockWaitCondition_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxBlockWaitCondition.Image = Resources.icon_btn_180;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00033AD0 File Offset: 0x00031CD0
		private void pictureBoxBlockWaitCondition_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = this.cursorWaitCondition;
				this.pictureBoxBlockWaitCondition.Image = Resources.icon_btn_182;
				return;
			}
			if ((e.Effect & DragDropEffects.None) == DragDropEffects.None)
			{
				this.pictureBoxBlockWaitCondition.Image = Resources.icon_btn_180;
			}
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00033B25 File Offset: 0x00031D25
		private void pictureBoxBlockWaitCondition_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			if ((e.KeyState & 1) == 0)
			{
				this.pictureBoxBlockWaitCondition.Image = Resources.icon_btn_180;
			}
			this.scrollScreen();
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00028668 File Offset: 0x00026868
		private void splitContainer2_Panel1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.Copy;
				return;
			}
			e.Effect = DragDropEffects.None;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00033B47 File Offset: 0x00031D47
		private void 新規作成ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.newFile();
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00033B4F File Offset: 0x00031D4F
		private void ファイルを開くToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.openFile();
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00033B57 File Offset: 0x00031D57
		private void 上書き保存ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.saveFile(this._filePath);
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00033B65 File Offset: 0x00031D65
		private void 名前を付けて保存ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.saveFileAs();
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x000286B1 File Offset: 0x000268B1
		private void 終了ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00033B6D File Offset: 0x00031D6D
		private void 元に戻すToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.undo();
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00033B75 File Offset: 0x00031D75
		private void やり直すToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.redo();
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00033B7D File Offset: 0x00031D7D
		private void 切り取りToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.cutSelectAreaBlocks();
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00033B85 File Offset: 0x00031D85
		private void コピ\u30FCToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (!this.copySelectAreaBlocks() && this._programTextBox.SelectedText.Length > 0)
			{
				Clipboard.SetText(this._programTextBox.SelectedText);
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00033BB2 File Offset: 0x00031DB2
		private void 貼り付けToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.pasteAreaBlocks();
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00033BBA File Offset: 0x00031DBA
		private void 削除ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.removeSelectAreaBlocks();
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00033BC2 File Offset: 0x00031DC2
		private void すべて選択ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.setSelectAll();
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00033BCA File Offset: 0x00031DCA
		private void プログラム書込みToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.writeProgram();
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00033BD2 File Offset: 0x00031DD2
		private void プログラム読込みToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.readProgram();
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00033BDA File Offset: 0x00031DDA
		private void プログラム実行ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.runProgram();
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00033BE2 File Offset: 0x00031DE2
		private void プログラム停止ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.stopProgram();
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00033BEA File Offset: 0x00031DEA
		private void シミュレ\u30FCト画面ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (this._simulatorWindow == null)
			{
				this._simulatorWindow = new SimulatorWindow(this, null);
				this._simulatorWindow.Show();
				return;
			}
			this._simulatorWindow.Focus();
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00033C19 File Offset: 0x00031E19
		private void レポ\u30FCト作成ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			new ReportWindow(ReportWindow.REPORT.ICON, this._programs, null, null).ShowDialog();
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00033C30 File Offset: 0x00031E30
		private void プログラムPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			this.splitContainer4.Panel2Collapsed = !this.splitContainer4.Panel2Collapsed;
			this._area.Size = new Size(this.splitContainer4.Panel1.Width - 20, 2048);
			this.updateLayout();
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00033C98 File Offset: 0x00031E98
		private void フロ\u30FCチャ\u30FCトへ切換ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.Program.convertToFlowchartProgram();
			this._convert = true;
			base.Close();
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00028AD2 File Offset: 0x00026CD2
		private void ヘルプを表示ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(".\\説明書\\Manual.pdf");
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00028ADF File Offset: 0x00026CDF
		private void バ\u30FCジョン情報ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			new VersionDialog().ShowDialog();
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00033CB4 File Offset: 0x00031EB4
		private void IconWindow_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (array.Length == 1 && Path.GetExtension(array[0]) == ".icp")
				{
					e.Effect = DragDropEffects.Copy;
					return;
				}
				e.Effect = DragDropEffects.None;
			}
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00033D14 File Offset: 0x00031F14
		private void IconWindow_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (array.Length == 1 && Path.GetExtension(array[0]) == ".icp")
				{
					this.openFileDragDrop(array[0]);
				}
			}
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00033D6C File Offset: 0x00031F6C
		private void openFileDragDrop(string file)
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "ファイルを開く";
				confirmDialog.setText(IconWindow.WARNING_SAVE);
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

		// Token: 0x06000459 RID: 1113 RVA: 0x00033DD0 File Offset: 0x00031FD0
		private void scrollScreen()
		{
			if (this._area.PointToClient(Cursor.Position).Y + this.splitContainer4.Panel1.AutoScrollPosition.Y > this.splitContainer4.Panel1.Height)
			{
				this.splitContainer4.Panel1.AutoScrollPosition = new Point(-this.splitContainer4.Panel1.AutoScrollPosition.X, -this.splitContainer4.Panel1.AutoScrollPosition.Y + 3);
			}
			else if (this._area.PointToClient(Cursor.Position).Y + this.splitContainer4.Panel1.AutoScrollPosition.Y < 0)
			{
				this.splitContainer4.Panel1.AutoScrollPosition = new Point(-this.splitContainer4.Panel1.AutoScrollPosition.X, -this.splitContainer4.Panel1.AutoScrollPosition.Y - 3);
			}
			this.Area.Update();
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00033EF3 File Offset: 0x000320F3
		private void textBoxProgram_MouseDown(object sender, MouseEventArgs e)
		{
			this.clearSelect();
			this._area.Invalidate();
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00033F08 File Offset: 0x00032108
		private void setScrollV(int index)
		{
			this._scrollIndexV = index;
			for (int i = 0; i < index; i++)
			{
				this._buttonBlocks[i].Visible = false;
			}
			for (int j = index; j < this._buttonBlocks.Count; j++)
			{
				this._buttonBlocks[j].Location = new Point(this._buttonBlocks[j].Location.X, 47 + (j - index) * 57);
				this._buttonBlocks[j].Visible = true;
			}
			this.pictureBoxArrowUp.Visible = true;
			this.pictureBoxArrowDown.Visible = true;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00033FB4 File Offset: 0x000321B4
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

		// Token: 0x0600045D RID: 1117 RVA: 0x00034062 File Offset: 0x00032262
		private void pictureBoxArrowUp_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowUp.Image = Resources.icon_btn_192;
			}
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00034081 File Offset: 0x00032281
		private void pictureBoxArrowUp_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowUp.Image = Resources.icon_btn_191;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00034093 File Offset: 0x00032293
		private void pictureBoxArrowUp_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowUp.Image = Resources.icon_btn_190;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x000340A5 File Offset: 0x000322A5
		private void pictureBoxArrowUp_MouseUp(object sender, MouseEventArgs e)
		{
			this.setScrollV(Math.Max(Math.Min(this._scrollIndexV - 1, this._buttonBlocks.Count - 1), 0));
			this.pictureBoxArrowUp.Image = Resources.icon_btn_191;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x000340DD File Offset: 0x000322DD
		private void pictureBoxArrowDown_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowDown.Image = Resources.icon_btn_202;
			}
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000340FC File Offset: 0x000322FC
		private void pictureBoxArrowDown_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowDown.Image = Resources.icon_btn_201;
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0003410E File Offset: 0x0003230E
		private void pictureBoxArrowDown_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowDown.Image = Resources.icon_btn_200;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00034120 File Offset: 0x00032320
		private void pictureBoxArrowDown_MouseUp(object sender, MouseEventArgs e)
		{
			int num = (this.pictureBoxArrowDown.Parent.Height - this.pictureBoxArrowDown.Height - this._buttonBlocks[0].Location.Y) / 57;
			this.setScrollV(Math.Max(Math.Min(this._scrollIndexV + 1, this._buttonBlocks.Count - num), 0));
			this.pictureBoxArrowDown.Image = Resources.icon_btn_201;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0003419D File Offset: 0x0003239D
		private void pictureBoxArrowLeft_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowLeft.Image = Resources.icon_btn_222;
			}
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x000341BC File Offset: 0x000323BC
		private void pictureBoxArrowLeft_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowLeft.Image = Resources.icon_btn_221;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x000341CE File Offset: 0x000323CE
		private void pictureBoxArrowLeft_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowLeft.Image = Resources.icon_btn_220;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x000341E0 File Offset: 0x000323E0
		private void pictureBoxArrowLeft_MouseUp(object sender, MouseEventArgs e)
		{
			this.setScrollH(Math.Max(Math.Min(this._scrollIndexH - 1, this._buttonTools.Count - 1), -1));
			this.pictureBoxArrowLeft.Image = Resources.icon_btn_221;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00034218 File Offset: 0x00032418
		private void pictureBoxArrowRight_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowRight.Image = Resources.icon_btn_212;
			}
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00034237 File Offset: 0x00032437
		private void pictureBoxArrowRight_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowRight.Image = Resources.icon_btn_211;
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00034249 File Offset: 0x00032449
		private void pictureBoxArrowRight_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowRight.Image = Resources.icon_btn_210;
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0003425C File Offset: 0x0003245C
		private void pictureBoxArrowRight_MouseUp(object sender, MouseEventArgs e)
		{
			int num = (this.pictureBoxArrowRight.Parent.Width - this.pictureBoxArrowRight.Width - this._buttonTools[0].Location.X) / 72;
			this.setScrollH(Math.Max(Math.Min(this._scrollIndexH + 1, this._buttonTools.Count - num), 0));
			this.pictureBoxArrowRight.Image = Resources.icon_btn_211;
		}

		// Token: 0x0400030A RID: 778
		private readonly Point LEFT_TOP = new Point(20, 20);

		// Token: 0x0400030B RID: 779
		private const int BLOCK_INTERVAL_X = 40;

		// Token: 0x0400030C RID: 780
		private const int BLOCK_INTERVAL_Y = 50;

		// Token: 0x0400030D RID: 781
		private const int AREA_HEIGHT = 2048;

		// Token: 0x0400030E RID: 782
		private const int SCROLL_BAR_WIDTH = 20;

		// Token: 0x0400030F RID: 783
		private const string PROTOCOL = "IconWindow:";

		// Token: 0x04000310 RID: 784
		private static readonly string WARNING_SAVE = "編集中のデータが失われますが良いですか？";

		// Token: 0x04000311 RID: 785
		private IconArea _area;

		// Token: 0x04000312 RID: 786
		private ProgramTextBox _programTextBox;

		// Token: 0x04000313 RID: 787
		private History _history = new History();

		// Token: 0x04000314 RID: 788
		private SimulatorWindow _simulatorWindow;

		// Token: 0x04000315 RID: 789
		private ProgramModules _programs;

		// Token: 0x04000316 RID: 790
		private List<IconAreaBlock> _areaBlocks = new List<IconAreaBlock>();

		// Token: 0x04000317 RID: 791
		private List<IconAreaBlock> _selectAreaBlocks = new List<IconAreaBlock>();

		// Token: 0x04000318 RID: 792
		private IconAreaBlock _selectCursorAreaBlock;

		// Token: 0x04000319 RID: 793
		private bool _runningFlag;

		// Token: 0x0400031A RID: 794
		private bool _runningStopFlag;

		// Token: 0x0400031B RID: 795
		private IconWindow.CopyObject _copyObject = new IconWindow.CopyObject();

		// Token: 0x0400031C RID: 796
		private string _filePath = "";

		// Token: 0x0400031D RID: 797
		private bool _convert;

		// Token: 0x0400031E RID: 798
		private Cursor cursorLED = CursorCreator.CreateCursor(Resources.icon_btn_130, Resources.icon_btn_130.Width / 2, Resources.icon_btn_130.Height / 2);

		// Token: 0x0400031F RID: 799
		private Cursor cursorSound = CursorCreator.CreateCursor(Resources.icon_btn_140, Resources.icon_btn_140.Width / 2, Resources.icon_btn_140.Height / 2);

		// Token: 0x04000320 RID: 800
		private Cursor cursorWait = CursorCreator.CreateCursor(Resources.icon_btn_150, Resources.icon_btn_150.Width / 2, Resources.icon_btn_150.Height / 2);

		// Token: 0x04000321 RID: 801
		private Cursor cursorLoopStart = CursorCreator.CreateCursor(Resources.icon_btn_160, Resources.icon_btn_160.Width / 2, Resources.icon_btn_160.Height / 2);

		// Token: 0x04000322 RID: 802
		private Cursor cursorLoopEnd = CursorCreator.CreateCursor(Resources.icon_btn_170, Resources.icon_btn_170.Width / 2, Resources.icon_btn_170.Height / 2);

		// Token: 0x04000323 RID: 803
		private Cursor cursorWaitCondition = CursorCreator.CreateCursor(Resources.icon_btn_180, Resources.icon_btn_180.Width / 2, Resources.icon_btn_180.Height / 2);

		// Token: 0x04000324 RID: 804
		private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

		// Token: 0x04000325 RID: 805
		private int _scrollIndexV;

		// Token: 0x04000326 RID: 806
		private int _scrollIndexH;

		// Token: 0x04000327 RID: 807
		private List<PictureBox> _buttonBlocks = new List<PictureBox>();

		// Token: 0x04000328 RID: 808
		private List<PictureBox> _buttonTools = new List<PictureBox>();

		// Token: 0x04000329 RID: 809
		private TutorialWindow _tutorialWindow;

		// Token: 0x0400032A RID: 810
		private IconWindow.TUTORIAL _tutorial;

		// Token: 0x0400032B RID: 811
		private readonly string[] _tutorialTexts = new string[] { "ここではLEDを1秒間点灯させ、メロディを鳴らします。\r\n「はじめる」ボタンを押してください。", "小さな画面の指示に従って操作してください。\r\n※指示以外の操作は受け付けないようになっています。", "①LEDアイコンを配置しましょう。", "②設置されたLEDアイコンをダブルクリックして開きましょう。", "③赤色、1秒に設定し「OK」ボタンを押しましょう。", "④サウンドアイコンを追加しましょう。", "⑤パソコンと本体をつなぎましょう。", "⑥プログラムを書き込みましょう。", "⑦プログラムを実行しましょう。", "つかいかたはこれで終わりです。\r\n今度は自分でいろいろなアイコンを配置してみましょう。" };

		// Token: 0x0400032C RID: 812
		private readonly Image[] _tutorialImages = new Image[]
		{
			Resources.tutorial_icon_000,
			Resources.tutorial_nw_018,
			Resources.tutorial_icon_001,
			Resources.tutorial_icon_002,
			Resources.tutorial_icon_003,
			Resources.tutorial_icon_004,
			Resources.tutorial_icon_005,
			Resources.tutorial_icon_006,
			Resources.tutorial_icon_007,
			Resources.tutorial_icon_008
		};

		// Token: 0x02000098 RID: 152
		public class CopyObject
		{
			// Token: 0x04000854 RID: 2132
			[XmlArrayItem(typeof(ProgramModule.BlockStart))]
			[XmlArrayItem(typeof(ProgramModule.BlockEnd))]
			[XmlArrayItem(typeof(ProgramModule.BlockLED))]
			[XmlArrayItem(typeof(ProgramModule.BlockSound))]
			[XmlArrayItem(typeof(ProgramModule.BlockWait))]
			[XmlArrayItem(typeof(ProgramModule.BlockLoopStart))]
			[XmlArrayItem(typeof(ProgramModule.BlockLoopEnd))]
			[XmlArrayItem(typeof(ProgramModule.BlockWaitCondition))]
			public List<ProgramModule.Block> _blocks = new List<ProgramModule.Block>();
		}

		// Token: 0x02000099 RID: 153
		public enum TUTORIAL
		{
			// Token: 0x04000856 RID: 2134
			START,
			// Token: 0x04000857 RID: 2135
			CAUTION,
			// Token: 0x04000858 RID: 2136
			DRAG_LED,
			// Token: 0x04000859 RID: 2137
			DOUBLE_CLICK,
			// Token: 0x0400085A RID: 2138
			DETAIL,
			// Token: 0x0400085B RID: 2139
			DRAG_SOUND,
			// Token: 0x0400085C RID: 2140
			CONNECT,
			// Token: 0x0400085D RID: 2141
			WRITE,
			// Token: 0x0400085E RID: 2142
			RUN,
			// Token: 0x0400085F RID: 2143
			END,
			// Token: 0x04000860 RID: 2144
			MAX
		}
	}
}
