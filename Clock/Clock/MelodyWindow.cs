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
	// Token: 0x0200002F RID: 47
	public partial class MelodyWindow : Form
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x0003DBAA File Offset: 0x0003BDAA
		public ContextMenuStrip RightClickMenu
		{
			get
			{
				return this.contextMenuStrip;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x0003DBB2 File Offset: 0x0003BDB2
		// (set) Token: 0x060004C6 RID: 1222 RVA: 0x0003DBBA File Offset: 0x0003BDBA
		public bool PlayingFlag
		{
			get
			{
				return this._playingFlag;
			}
			set
			{
				this._playingFlag = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x0003DBC3 File Offset: 0x0003BDC3
		// (set) Token: 0x060004C8 RID: 1224 RVA: 0x0003DBCC File Offset: 0x0003BDCC
		public MelodyWindow.TUTORIAL Tutorial
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
					this.updateTutorialEnables();
					TutorialWindow.BUTTON_MODE button_MODE = TutorialWindow.BUTTON_MODE.QUIT;
					if (this._tutorial == MelodyWindow.TUTORIAL.CAUTION)
					{
						button_MODE = TutorialWindow.BUTTON_MODE.START;
					}
					this._tutorialWindow.initialize(this._tutorialImages[(int)this._tutorial], this._tutorialTexts[(int)this._tutorial], button_MODE);
				}
			}
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0003DC22 File Offset: 0x0003BE22
		public bool isTutorial()
		{
			return this._tutorialWindow != null;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0003DC2D File Offset: 0x0003BE2D
		public bool isTutorialKeyboardEnable()
		{
			return this._tutorialKeyboardEnableFlag;
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0003DC38 File Offset: 0x0003BE38
		public MelodyWindow(bool tutorial)
		{
			this.InitializeComponent();
			this._area = new MelodyArea(ref this._module, this);
			this._area.Location = new Point(0, 0);
			this._area.Size = new Size(this.splitContainer2.Panel1.Width - 20, MelodyArea.AREA_HEIGHT_DEFAULT);
			this.splitContainer2.Panel1.Controls.Add(this._area);
			this._keyboard = new MelodyKeyboard(this);
			this._keyboard.Size = new Size(Resources.mld_bg_000.Width, Resources.mld_bg_000.Height);
			this._keyboard.Location = new Point(0, 24);
			this.splitContainer2.Panel2.Controls.Add(this._keyboard);
			this._selectedNoteButton = MelodyModule.Key.LENGTH.FOUR;
			this.pictureBoxButtonNote4.Image = Resources.mld_btn_062;
			if (MelodyWindow._midi.getDeviceCount() > 0)
			{
				this._useMidiFlag = true;
				MelodyWindow._midi.open();
			}
			this._history.initialize(this.serialize());
			this._area.Focus();
			if (tutorial)
			{
				this._tutorialWindow = new TutorialWindow(this);
				this._tutorialWindow.initialize(this._tutorialImages[(int)this._tutorial], this._tutorialTexts[(int)this._tutorial], TutorialWindow.BUTTON_MODE.START);
				MemoryStream memoryStream = new MemoryStream(Resources.tutorial);
				this.openFile(memoryStream);
				this._area.ScrollIndex = 33;
				this._area.Invalidate();
				this.updateTutorialEnables();
			}
			this._buttonTools.Add(this.pictureBoxNew);
			this._buttonTools.Add(this.pictureBoxOpen);
			this._buttonTools.Add(this.pictureBoxSave);
			this._buttonTools.Add(this.pictureBoxUndo);
			this._buttonTools.Add(this.pictureBoxRedo);
			this._buttonTools.Add(this.pictureBoxCut);
			this._buttonTools.Add(this.pictureBoxCopy);
			this._buttonTools.Add(this.pictureBoxPaste);
			this._buttonTools.Add(this.pictureBoxInsert);
			this._buttonTools.Add(this.pictureBoxWrite);
			this._buttonTools.Add(this.pictureBoxRun);
			this._buttonTools.Add(this.pictureBoxStop);
			this._buttonTools.Add(this.pictureBoxReport);
			this.pictureBoxArrowLeft.Visible = false;
			this.pictureBoxArrowRight.Visible = false;
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x0003DFC4 File Offset: 0x0003C1C4
		public void clickKeyBoard(MelodyModule.Key.RANK rank)
		{
			if (this._area.countSelected() == 0)
			{
				this._area.addNote(rank, this._selectedNoteButton);
			}
			else if (this._area.countSelected() == 1)
			{
				this._area.changeNote(MelodyArea.TYPE.RANK, this._selectedNoteButton, rank);
			}
			if (this._useMidiFlag)
			{
				MelodyWindow._midi.play(MelodyModule.Key.getMidiKey(rank));
				Thread.Sleep(200);
				MelodyWindow._midi.stop();
			}
			else
			{
				Console.Beep(MelodyModule.Key.getFrequency(rank), 200);
			}
			if (this.isTutorial())
			{
				MelodyWindow.TUTORIAL tutorial = this.Tutorial;
				this.Tutorial = tutorial + 1;
			}
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0003E069 File Offset: 0x0003C269
		public void selectNote(MelodyModule.Key.RANK rank)
		{
			this._keyboard.colorKey(rank);
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0003E077 File Offset: 0x0003C277
		public void unselectedNote()
		{
			this._keyboard.clearColor();
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0003E084 File Offset: 0x0003C284
		public SplitterPanel getPanel1()
		{
			return this.splitContainer2.Panel1;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0003E094 File Offset: 0x0003C294
		private void deselectNoteButton()
		{
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.SIXTEEN)
			{
				this.pictureBoxButtonNote16.Image = Resources.mld_btn_030;
				return;
			}
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.EIGHT)
			{
				this.pictureBoxButtonNote8.Image = Resources.mld_btn_040;
				return;
			}
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.EIGHT_DOT)
			{
				this.pictureBoxButtonNote8Dot.Image = Resources.mld_btn_050;
				return;
			}
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.FOUR)
			{
				this.pictureBoxButtonNote4.Image = Resources.mld_btn_060;
				return;
			}
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.FOUR_DOT)
			{
				this.pictureBoxButtonNote4Dot.Image = Resources.mld_btn_070;
				return;
			}
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.TWO)
			{
				this.pictureBoxButtonNote2.Image = Resources.mld_btn_080;
				return;
			}
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.TWO_DOT)
			{
				this.pictureBoxButtonNote2Dot.Image = Resources.mld_btn_090;
				return;
			}
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.ONE)
			{
				this.pictureBoxButtonNote.Image = Resources.mld_btn_100;
			}
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0003E170 File Offset: 0x0003C370
		private async void playMelody()
		{
			if (!this._playingFlag)
			{
				this._playingFlag = true;
				this._stopFlag = false;
				this.enableControls(false);
				if (this.isTutorial())
				{
					this.pictureBoxButtonStop.Enabled = false;
				}
				int selectedIndex = this.getSelectedIndex();
				if (selectedIndex == -1)
				{
					selectedIndex = 0;
				}
				float tempoCoefficient = 1f / (MelodyWindow.TEMPO_ARRAY[this._module.tempoIndex] / 60f);
				this._area.clearSelect();
				await Task.Run(delegate
				{
					for (int i = selectedIndex; i < this._module.Keys.Count; i++)
					{
						MelodyModule.Key key = this._module.Keys[i];
						key.Selected = true;
						this._area.ScrollIndex = i;
						this._area.Invalidate();
						int num = (int)((float)key.getBlockSize() * 250f * tempoCoefficient);
						if (key.Rank != MelodyModule.Key.RANK.REST)
						{
							if (this._useMidiFlag)
							{
								MelodyWindow._midi.play(MelodyModule.Key.getMidiKey(key.Rank));
								Thread.Sleep(num);
								MelodyWindow._midi.stop();
							}
							else
							{
								Console.Beep(MelodyModule.Key.getFrequency(key.Rank), num);
							}
						}
						else
						{
							Thread.Sleep(num);
						}
						if (this._stopFlag)
						{
							return;
						}
						key.Selected = false;
						this._area.Invalidate();
					}
				});
				this._playingFlag = false;
				this._stopFlag = false;
				this.enableControls(true);
				if (this.isTutorial())
				{
					this.Tutorial++;
				}
			}
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0003E1A8 File Offset: 0x0003C3A8
		private int getSelectedIndex()
		{
			for (int i = 0; i < this._module.Keys.Count; i++)
			{
				if (this._module.Keys[i].Selected)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0003E1EC File Offset: 0x0003C3EC
		private void enableControls(bool enable)
		{
			this.ファイルToolStripMenuItem.Enabled = enable;
			this.編集EToolStripMenuItem.Enabled = enable;
			this.書込み実行EToolStripMenuItem.Enabled = enable;
			this.pC上でメロディ再生PToolStripMenuItem.Enabled = enable;
			this.ヘルプHToolStripMenuItem.Enabled = enable;
			this.pictureBoxNew.Enabled = enable;
			this.pictureBoxOpen.Enabled = enable;
			this.pictureBoxSave.Enabled = enable;
			this.pictureBoxUndo.Enabled = enable;
			this.pictureBoxRedo.Enabled = enable;
			this.pictureBoxCut.Enabled = enable;
			this.pictureBoxCopy.Enabled = enable;
			this.pictureBoxPaste.Enabled = enable;
			this.pictureBoxInsert.Enabled = enable;
			this.pictureBoxWrite.Enabled = enable;
			this.pictureBoxReport.Enabled = enable;
			this.splitContainer2.Panel1.Enabled = enable;
			this.pictureBoxButtonNote16.Enabled = enable;
			this.pictureBoxButtonNote8.Enabled = enable;
			this.pictureBoxButtonNote8Dot.Enabled = enable;
			this.pictureBoxButtonNote4.Enabled = enable;
			this.pictureBoxButtonNote4Dot.Enabled = enable;
			this.pictureBoxButtonNote2.Enabled = enable;
			this.pictureBoxButtonNote2Dot.Enabled = enable;
			this.pictureBoxButtonNote.Enabled = enable;
			this.pictureBoxButtonRest16.Enabled = enable;
			this.pictureBoxButtonRest8.Enabled = enable;
			this.pictureBoxButtonRest4.Enabled = enable;
			this.pictureBoxButtonRest2.Enabled = enable;
			this.pictureBoxButtonRest.Enabled = enable;
			this.pictureBoxButtonPlay.Enabled = enable;
			this.pictureBoxButtonSettings.Enabled = enable;
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0003E37E File Offset: 0x0003C57E
		public int getTempo()
		{
			return this._module.tempoIndex;
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0003E38B File Offset: 0x0003C58B
		public bool getLedFlag()
		{
			return this._module.ledFlag;
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0003E398 File Offset: 0x0003C598
		public void setTempo(int tempoIndex)
		{
			this._module.tempoIndex = tempoIndex;
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x0003E3A6 File Offset: 0x0003C5A6
		public void setLedFlag(bool ledFlag)
		{
			this._module.ledFlag = ledFlag;
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x0003E3B4 File Offset: 0x0003C5B4
		public void addHistory()
		{
			this._history.addHistory(this.serialize());
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x0003E3C8 File Offset: 0x0003C5C8
		public void updateUsedMemory()
		{
			int usedMemory = this._module.getUsedMemory();
			this.toolStripStatusLabelUsedMemory.Text = "消費メモリ " + usedMemory.ToString() + "/" + 254.ToString();
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0003E40F File Offset: 0x0003C60F
		public bool isMemoryOver(int addMemory)
		{
			return this._module.getUsedMemory() + addMemory > 254;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0003E428 File Offset: 0x0003C628
		public void updateLog(string log)
		{
			this.toolStripStatusLabelLog.Text = log;
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0003E438 File Offset: 0x0003C638
		private void viewTitle()
		{
			string text = "";
			if (this._filePath != "")
			{
				text = this._filePath.Substring(this._filePath.LastIndexOf("\\") + 1);
			}
			this.Text = "メロディ作成  " + text;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0003E48C File Offset: 0x0003C68C
		private string serialize()
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(MelodyModule));
			StringBuilder stringBuilder = new StringBuilder();
			StringWriter stringWriter = new StringWriter(stringBuilder);
			xmlSerializer.Serialize(stringWriter, this._module);
			stringWriter.Close();
			return stringBuilder.ToString();
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0003E4D0 File Offset: 0x0003C6D0
		private void deserialize(string xml)
		{
			this._module.removeAllKeys();
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(MelodyModule));
			StringReader stringReader = new StringReader(xml);
			MelodyModule melodyModule = (MelodyModule)xmlSerializer.Deserialize(stringReader);
			stringReader.Close();
			if (melodyModule.Keys.Count > 253)
			{
				melodyModule.Keys.RemoveRange(253, melodyModule.Keys.Count - 253);
				WarningDialog warningDialog = new WarningDialog();
				warningDialog.setText("メロディデータが古いフォーマットのため、\r\nデータの一部が切り取られます。");
				warningDialog.ShowDialog();
			}
			this._module.Keys = melodyModule.Keys;
			this._module.tempoIndex = melodyModule.tempoIndex;
			this._module.ledFlag = melodyModule.ledFlag;
			this._module.Report = melodyModule.Report;
			this._area.Invalidate();
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0003E5A8 File Offset: 0x0003C7A8
		private void newFile()
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "新規作成";
				confirmDialog.setText(MelodyWindow.WARNING_SAVE);
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (flag)
			{
				this._filePath = "";
				this.viewTitle();
				this._module.removeAllKeys();
				this._module.tempoIndex = 0;
				this._module.ledFlag = false;
				this._module.Report = new ReportModule();
				this._history.initialize(this.serialize());
				this.updateLog("新規作成");
				this._area.Invalidate();
				this._area.Focus();
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0003E668 File Offset: 0x0003C868
		private void openFile()
		{
			bool flag = true;
			if (!this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "ファイルを開く";
				confirmDialog.setText(MelodyWindow.WARNING_SAVE);
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (flag)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.FileName = "メロディ.mdp";
				openFileDialog.Filter = "プログラミングファイル(*.mdp)|*.mdp";
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

		// Token: 0x060004E1 RID: 1249 RVA: 0x0003E70C File Offset: 0x0003C90C
		private void openFile(Stream stream)
		{
			StreamReader streamReader = new StreamReader(stream);
			this.deserialize(streamReader.ReadToEnd());
			streamReader.Close();
			stream.Close();
			this.viewTitle();
			this._history.initialize(this.serialize());
			this.updateLog("ファイルを開く");
			this._area.Focus();
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0003E768 File Offset: 0x0003C968
		private void saveFile(string filename)
		{
			if (filename.Length > 0)
			{
				try
				{
					using (StreamWriter streamWriter = new StreamWriter(filename, false))
					{
						streamWriter.Write(this.serialize());
						streamWriter.Close();
						this._history.setSaved();
						this.updateLog("ファイルを保存");
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

		// Token: 0x060004E3 RID: 1251 RVA: 0x0003E800 File Offset: 0x0003CA00
		private void saveFileAs()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = ((this._filePath.Length > 0) ? Path.GetFileName(this._filePath) : "メロディ.mdp");
			saveFileDialog.Filter = "プログラミングファイル(*.mdp)|*.mdp|すべてのファイル(*.*)|*.*";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.Title = "保存先のファイルを選択してください";
			saveFileDialog.RestoreDirectory = true;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.saveFile(saveFileDialog.FileName);
				this._filePath = saveFileDialog.FileName;
				this.viewTitle();
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0003E884 File Offset: 0x0003CA84
		private void undo()
		{
			string previous = this._history.getPrevious();
			if (previous != null)
			{
				this.deserialize(previous);
				this.updateLog("元に戻す");
			}
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x0003E8B4 File Offset: 0x0003CAB4
		private void redo()
		{
			string next = this._history.getNext();
			if (next != null)
			{
				this.deserialize(next);
				this.updateLog("やり直し");
			}
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x0003E8E2 File Offset: 0x0003CAE2
		private void MelodyWindow_Shown(object sender, EventArgs e)
		{
			base.Activate();
			if (this.isTutorial())
			{
				this._tutorialWindow.Show();
			}
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x0003E900 File Offset: 0x0003CB00
		private void MelodyWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool flag = true;
			if (!this.isTutorial() && !this._history.isSaved())
			{
				ConfirmDialog confirmDialog = new ConfirmDialog();
				confirmDialog.Text = "終了";
				confirmDialog.setText(MelodyWindow.WARNING_SAVE);
				confirmDialog.ShowDialog();
				flag = confirmDialog.OK;
			}
			if (!flag)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x0003E956 File Offset: 0x0003CB56
		private void MelodyWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this._tutorialWindow != null)
			{
				this._tutorialWindow.Close();
			}
			base.Dispose();
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0003E971 File Offset: 0x0003CB71
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (CommunicationModule.Instance.Connected)
			{
				this.pictureBoxConnection.Image = Resources.icon_usb_on;
				return;
			}
			this.pictureBoxConnection.Image = Resources.icon_usb_off;
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0003E9A0 File Offset: 0x0003CBA0
		private void updateTutorialEnables()
		{
			bool flag = !this.isTutorial();
			this.menuStrip1.Enabled = flag;
			this.pictureBoxNew.Enabled = flag;
			this.pictureBoxOpen.Enabled = flag;
			this.pictureBoxSave.Enabled = flag;
			this.pictureBoxUndo.Enabled = flag;
			this.pictureBoxRedo.Enabled = flag;
			this.pictureBoxCut.Enabled = flag;
			this.pictureBoxCopy.Enabled = flag;
			this.pictureBoxPaste.Enabled = flag;
			this.pictureBoxInsert.Enabled = flag;
			this.pictureBoxWrite.Enabled = flag;
			this.pictureBoxReport.Enabled = flag;
			this.splitContainer2.Panel1.Enabled = flag;
			this.pictureBoxButtonNote16.Enabled = flag;
			this.pictureBoxButtonNote8.Enabled = flag;
			this.pictureBoxButtonNote8Dot.Enabled = flag;
			this.pictureBoxButtonNote4.Enabled = flag;
			this.pictureBoxButtonNote4Dot.Enabled = flag;
			this.pictureBoxButtonNote2.Enabled = flag;
			this.pictureBoxButtonNote2Dot.Enabled = flag;
			this.pictureBoxButtonNote.Enabled = flag;
			this.pictureBoxButtonRest16.Enabled = flag;
			this.pictureBoxButtonRest8.Enabled = flag;
			this.pictureBoxButtonRest4.Enabled = flag;
			this.pictureBoxButtonRest2.Enabled = flag;
			this.pictureBoxButtonRest.Enabled = flag;
			this.pictureBoxButtonPlay.Enabled = flag;
			this.pictureBoxButtonStop.Enabled = flag;
			this.pictureBoxButtonSettings.Enabled = flag;
			this._tutorialKeyboardEnableFlag = flag;
			if (this.isTutorial())
			{
				switch (this._tutorial)
				{
				case MelodyWindow.TUTORIAL.NOTE:
					this.pictureBoxButtonNote.Enabled = true;
					return;
				case MelodyWindow.TUTORIAL.KEY:
					this._tutorialKeyboardEnableFlag = true;
					return;
				case MelodyWindow.TUTORIAL.TEMPO:
					this.pictureBoxButtonSettings.Enabled = true;
					return;
				case MelodyWindow.TUTORIAL.PLAY_1:
				case MelodyWindow.TUTORIAL.PLAY_2:
					this.pictureBoxButtonPlay.Enabled = true;
					return;
				case MelodyWindow.TUTORIAL.SELECT:
					this.splitContainer2.Panel1.Enabled = true;
					return;
				case MelodyWindow.TUTORIAL.CHANGE_NOTE:
					this.pictureBoxButtonNote4.Enabled = true;
					return;
				case MelodyWindow.TUTORIAL.CHANGE_KEY:
					this._tutorialKeyboardEnableFlag = true;
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0003EBB0 File Offset: 0x0003CDB0
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (this._playingFlag)
			{
				return false;
			}
			int num = -1;
			for (int i = 0; i < this._module.Keys.Count; i++)
			{
				if (this._module.Keys[i].Selected)
				{
					if (num != -1)
					{
						return base.ProcessCmdKey(ref msg, keyData);
					}
					num = i;
				}
			}
			if (num != -1)
			{
				if (keyData == Keys.Left)
				{
					if (num == 0)
					{
						num = this._module.Keys.Count - 1;
					}
					else
					{
						num--;
					}
					this._area.clearSelect();
					this._module.Keys[num].Selected = true;
					this._area.ScrollIndex = num;
				}
				else if (keyData == Keys.Right)
				{
					if (num == this._module.Keys.Count - 1)
					{
						num = 0;
					}
					else
					{
						num++;
					}
					this._area.clearSelect();
					this._module.Keys[num].Selected = true;
					this._area.ScrollIndex = num;
				}
				if (this._module.Keys[num].Rank == MelodyModule.Key.RANK.REST)
				{
					return base.ProcessCmdKey(ref msg, keyData);
				}
				if (keyData == Keys.Up)
				{
					if (this._module.Keys[num].Rank + 1 == MelodyModule.Key.RANK.MAX)
					{
						return base.ProcessCmdKey(ref msg, keyData);
					}
					this._module.Keys[num].Rank++;
					this.updateLog("音符を変更");
					this.addHistory();
				}
				else if (keyData == Keys.Down)
				{
					if (this._module.Keys[num].Rank - MelodyModule.Key.RANK.LOW_FA_SHARP <= 0)
					{
						return base.ProcessCmdKey(ref msg, keyData);
					}
					this._module.Keys[num].Rank--;
					this.updateLog("音符を変更");
					this.addHistory();
				}
				this.selectNote(this._module.Keys[num].Rank);
			}
			this._area.Invalidate();
			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0003EDB6 File Offset: 0x0003CFB6
		private void createReport()
		{
			this._area.clearSelect();
			new ReportWindow(ReportWindow.REPORT.MELODY, null, this._area, null).ShowDialog();
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0003EDD7 File Offset: 0x0003CFD7
		private void pictureBoxNew_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxNew.Image = Resources.icon_btn_002;
			}
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0003EDF6 File Offset: 0x0003CFF6
		private void pictureBoxNew_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxNew.Image = Resources.icon_btn_001;
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0003EE08 File Offset: 0x0003D008
		private void pictureBoxNew_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxNew.Image = Resources.icon_btn_000;
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0003EE1A File Offset: 0x0003D01A
		private void pictureBoxNew_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxNew.Image = Resources.icon_btn_001;
				this.newFile();
			}
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0003EE3F File Offset: 0x0003D03F
		private void pictureBoxOpen_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxOpen.Image = Resources.icon_btn_012;
			}
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0003EE5E File Offset: 0x0003D05E
		private void pictureBoxOpen_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxOpen.Image = Resources.icon_btn_011;
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0003EE70 File Offset: 0x0003D070
		private void pictureBoxOpen_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxOpen.Image = Resources.icon_btn_010;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0003EE82 File Offset: 0x0003D082
		private void pictureBoxOpen_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxOpen.Image = Resources.icon_btn_011;
				this.openFile();
			}
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0003EEA7 File Offset: 0x0003D0A7
		private void pictureBoxSave_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxSave.Image = Resources.icon_btn_022;
			}
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0003EEC6 File Offset: 0x0003D0C6
		private void pictureBoxSave_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxSave.Image = Resources.icon_btn_021;
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0003EED8 File Offset: 0x0003D0D8
		private void pictureBoxSave_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxSave.Image = Resources.icon_btn_020;
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0003EEEA File Offset: 0x0003D0EA
		private void pictureBoxSave_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxSave.Image = Resources.icon_btn_021;
				this.saveFile(this._filePath);
			}
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0003EF15 File Offset: 0x0003D115
		private void pictureBoxUndo_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxUndo.Image = Resources.icon_btn_032;
			}
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0003EF34 File Offset: 0x0003D134
		private void pictureBoxUndo_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxUndo.Image = Resources.icon_btn_031;
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0003EF46 File Offset: 0x0003D146
		private void pictureBoxUndo_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxUndo.Image = Resources.icon_btn_030;
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x0003EF58 File Offset: 0x0003D158
		private void pictureBoxUndo_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxUndo.Image = Resources.icon_btn_031;
				this.undo();
			}
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0003EF7D File Offset: 0x0003D17D
		private void pictureBoxRedo_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRedo.Image = Resources.icon_btn_042;
			}
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x0003EF9C File Offset: 0x0003D19C
		private void pictureBoxRedo_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxRedo.Image = Resources.icon_btn_041;
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0003EFAE File Offset: 0x0003D1AE
		private void pictureBoxRedo_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxRedo.Image = Resources.icon_btn_040;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0003EFC0 File Offset: 0x0003D1C0
		private void pictureBoxRedo_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRedo.Image = Resources.icon_btn_041;
				this.redo();
			}
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0003EFE5 File Offset: 0x0003D1E5
		private void pictureBoxCut_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCut.Image = Resources.icon_btn_052;
			}
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0003F004 File Offset: 0x0003D204
		private void pictureBoxCut_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxCut.Image = Resources.icon_btn_051;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0003F016 File Offset: 0x0003D216
		private void pictureBoxCut_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxCut.Image = Resources.icon_btn_050;
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0003F028 File Offset: 0x0003D228
		private void pictureBoxCut_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCut.Image = Resources.icon_btn_051;
				this._area.cutNote();
			}
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0003F052 File Offset: 0x0003D252
		private void pictureBoxCopy_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCopy.Image = Resources.icon_btn_062;
			}
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0003F071 File Offset: 0x0003D271
		private void pictureBoxCopy_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxCopy.Image = Resources.icon_btn_061;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x0003F083 File Offset: 0x0003D283
		private void pictureBoxCopy_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxCopy.Image = Resources.icon_btn_060;
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0003F095 File Offset: 0x0003D295
		private void pictureBoxCopy_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxCopy.Image = Resources.icon_btn_061;
				this._area.copyNote();
			}
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0003F0BF File Offset: 0x0003D2BF
		private void pictureBoxPaste_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxPaste.Image = Resources.icon_btn_072;
			}
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0003F0DE File Offset: 0x0003D2DE
		private void pictureBoxPaste_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxPaste.Image = Resources.icon_btn_071;
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0003F0F0 File Offset: 0x0003D2F0
		private void pictureBoxPaste_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxPaste.Image = Resources.icon_btn_070;
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0003F102 File Offset: 0x0003D302
		private void pictureBoxPaste_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxPaste.Image = Resources.icon_btn_071;
				this._area.pasteNote();
			}
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0003F12C File Offset: 0x0003D32C
		private void pictureBoxInsert_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxInsert.Image = Resources.mld_btn_002;
			}
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0003F14B File Offset: 0x0003D34B
		private void pictureBoxInsert_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxInsert.Image = Resources.mld_btn_001;
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0003F15D File Offset: 0x0003D35D
		private void pictureBoxInsert_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxInsert.Image = Resources.mld_btn_000;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0003F16F File Offset: 0x0003D36F
		private void pictureBoxInsert_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxInsert.Image = Resources.mld_btn_001;
				this._area.insertRest4();
			}
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0003F199 File Offset: 0x0003D399
		private void pictureBoxWrite_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxWrite.Image = Resources.icon_btn_082;
			}
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0003F1B8 File Offset: 0x0003D3B8
		private void pictureBoxWrite_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxWrite.Image = Resources.icon_btn_081;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0003F1CA File Offset: 0x0003D3CA
		private void pictureBoxWrite_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxWrite.Image = Resources.icon_btn_080;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0003F1DC File Offset: 0x0003D3DC
		private void pictureBoxWrite_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxWrite.Image = Resources.icon_btn_081;
				if (CommunicationModule.Instance.writeMelody(this._module))
				{
					if (this.isTutorial())
					{
						MelodyWindow.TUTORIAL tutorial = this.Tutorial;
						this.Tutorial = tutorial + 1;
						return;
					}
					WriteInformationDialog writeInformationDialog = new WriteInformationDialog();
					writeInformationDialog.ShowDialog();
					if (writeInformationDialog.IsRun)
					{
						int num = Math.Max(0, this.getSelectedIndex());
						CommunicationModule.Instance.playMelody(num, false);
					}
				}
			}
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0003F25E File Offset: 0x0003D45E
		private void pictureBoxRun_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRun.Image = Resources.icon_btn_092;
			}
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0003F27D File Offset: 0x0003D47D
		private void pictureBoxRun_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxRun.Image = Resources.icon_btn_091;
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0003F28F File Offset: 0x0003D48F
		private void pictureBoxRun_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxRun.Image = Resources.icon_btn_090;
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0003F2A4 File Offset: 0x0003D4A4
		private void pictureBoxRun_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxRun.Image = Resources.icon_btn_091;
				int num = Math.Max(0, this.getSelectedIndex());
				CommunicationModule.Instance.playMelody(num, false);
			}
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x0003F2E8 File Offset: 0x0003D4E8
		private void pictureBoxStop_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxStop.Image = Resources.icon_btn_102;
			}
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0003F307 File Offset: 0x0003D507
		private void pictureBoxStop_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxStop.Image = Resources.icon_btn_101;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0003F319 File Offset: 0x0003D519
		private void pictureBoxStop_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxStop.Image = Resources.icon_btn_100;
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0003F32B File Offset: 0x0003D52B
		private void pictureBoxStop_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxStop.Image = Resources.icon_btn_101;
				CommunicationModule.Instance.stopMelody();
			}
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0003F355 File Offset: 0x0003D555
		private void pictureBoxReport_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxReport.Image = Resources.icon_btn_122;
			}
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0003F374 File Offset: 0x0003D574
		private void pictureBoxReport_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxReport.Image = Resources.icon_btn_121;
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0003F386 File Offset: 0x0003D586
		private void pictureBoxReport_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxReport.Image = Resources.icon_btn_120;
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0003F398 File Offset: 0x0003D598
		private void pictureBoxReport_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxReport.Image = Resources.icon_btn_121;
				this.createReport();
			}
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0003F3BD File Offset: 0x0003D5BD
		private void pictureBoxButtonNote16_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonNote16.Image = Resources.mld_btn_032;
			}
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0003F3DC File Offset: 0x0003D5DC
		private void pictureBoxButtonNote16_MouseEnter(object sender, EventArgs e)
		{
			if (this._selectedNoteButton != MelodyModule.Key.LENGTH.SIXTEEN)
			{
				this.pictureBoxButtonNote16.Image = Resources.mld_btn_031;
			}
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0003F3F6 File Offset: 0x0003D5F6
		private void pictureBoxButtonNote16_MouseLeave(object sender, EventArgs e)
		{
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.SIXTEEN)
			{
				this.pictureBoxButtonNote16.Image = Resources.mld_btn_032;
				return;
			}
			this.pictureBoxButtonNote16.Image = Resources.mld_btn_030;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0003F421 File Offset: 0x0003D621
		private void pictureBoxButtonNote16_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this._selectedNoteButton != MelodyModule.Key.LENGTH.SIXTEEN)
				{
					this.deselectNoteButton();
					this._selectedNoteButton = MelodyModule.Key.LENGTH.SIXTEEN;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeNote(MelodyArea.TYPE.LENGTH, MelodyModule.Key.LENGTH.SIXTEEN, MelodyModule.Key.RANK.REST);
				}
			}
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0003F461 File Offset: 0x0003D661
		private void pictureBoxButtonNote8_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonNote8.Image = Resources.mld_btn_042;
			}
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0003F480 File Offset: 0x0003D680
		private void pictureBoxButtonNote8_MouseEnter(object sender, EventArgs e)
		{
			if (this._selectedNoteButton != MelodyModule.Key.LENGTH.EIGHT)
			{
				this.pictureBoxButtonNote8.Image = Resources.mld_btn_041;
			}
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0003F49B File Offset: 0x0003D69B
		private void pictureBoxButtonNote8_MouseLeave(object sender, EventArgs e)
		{
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.EIGHT)
			{
				this.pictureBoxButtonNote8.Image = Resources.mld_btn_042;
				return;
			}
			this.pictureBoxButtonNote8.Image = Resources.mld_btn_040;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0003F4C8 File Offset: 0x0003D6C8
		private void pictureBoxButtonNote8_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this._selectedNoteButton != MelodyModule.Key.LENGTH.EIGHT)
				{
					this.deselectNoteButton();
					this._selectedNoteButton = MelodyModule.Key.LENGTH.EIGHT;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeNote(MelodyArea.TYPE.LENGTH, MelodyModule.Key.LENGTH.EIGHT, MelodyModule.Key.RANK.REST);
				}
			}
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0003F514 File Offset: 0x0003D714
		private void pictureBoxButtonNote8Dot_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonNote8Dot.Image = Resources.mld_btn_052;
			}
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0003F533 File Offset: 0x0003D733
		private void pictureBoxButtonNote8Dot_MouseEnter(object sender, EventArgs e)
		{
			if (this._selectedNoteButton != MelodyModule.Key.LENGTH.EIGHT_DOT)
			{
				this.pictureBoxButtonNote8Dot.Image = Resources.mld_btn_051;
			}
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0003F54E File Offset: 0x0003D74E
		private void pictureBoxButtonNote8Dot_MouseLeave(object sender, EventArgs e)
		{
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.EIGHT_DOT)
			{
				this.pictureBoxButtonNote8Dot.Image = Resources.mld_btn_052;
				return;
			}
			this.pictureBoxButtonNote8Dot.Image = Resources.mld_btn_050;
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0003F57C File Offset: 0x0003D77C
		private void pictureBoxButtonNote8Dot_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this._selectedNoteButton != MelodyModule.Key.LENGTH.EIGHT_DOT)
				{
					this.deselectNoteButton();
					this._selectedNoteButton = MelodyModule.Key.LENGTH.EIGHT_DOT;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeNote(MelodyArea.TYPE.LENGTH, MelodyModule.Key.LENGTH.EIGHT_DOT, MelodyModule.Key.RANK.REST);
				}
			}
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0003F5C8 File Offset: 0x0003D7C8
		private void pictureBoxButtonNote4_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonNote4.Image = Resources.mld_btn_062;
			}
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0003F5E7 File Offset: 0x0003D7E7
		private void pictureBoxButtonNote4_MouseEnter(object sender, EventArgs e)
		{
			if (this._selectedNoteButton != MelodyModule.Key.LENGTH.FOUR)
			{
				this.pictureBoxButtonNote4.Image = Resources.mld_btn_061;
			}
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0003F602 File Offset: 0x0003D802
		private void pictureBoxButtonNote4_MouseLeave(object sender, EventArgs e)
		{
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.FOUR)
			{
				this.pictureBoxButtonNote4.Image = Resources.mld_btn_062;
				return;
			}
			this.pictureBoxButtonNote4.Image = Resources.mld_btn_060;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0003F630 File Offset: 0x0003D830
		private void pictureBoxButtonNote4_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this._selectedNoteButton != MelodyModule.Key.LENGTH.FOUR)
				{
					this.deselectNoteButton();
					this._selectedNoteButton = MelodyModule.Key.LENGTH.FOUR;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeNote(MelodyArea.TYPE.LENGTH, MelodyModule.Key.LENGTH.FOUR, MelodyModule.Key.RANK.REST);
				}
				if (this.isTutorial())
				{
					MelodyWindow.TUTORIAL tutorial = this.Tutorial;
					this.Tutorial = tutorial + 1;
				}
			}
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0003F694 File Offset: 0x0003D894
		private void pictureBoxButtonNote4Dot_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonNote4Dot.Image = Resources.mld_btn_072;
			}
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0003F6B3 File Offset: 0x0003D8B3
		private void pictureBoxButtonNote4Dot_MouseEnter(object sender, EventArgs e)
		{
			if (this._selectedNoteButton != MelodyModule.Key.LENGTH.FOUR_DOT)
			{
				this.pictureBoxButtonNote4Dot.Image = Resources.mld_btn_071;
			}
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0003F6CE File Offset: 0x0003D8CE
		private void pictureBoxButtonNote4Dot_MouseLeave(object sender, EventArgs e)
		{
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.FOUR_DOT)
			{
				this.pictureBoxButtonNote4Dot.Image = Resources.mld_btn_072;
				return;
			}
			this.pictureBoxButtonNote4Dot.Image = Resources.mld_btn_070;
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0003F6FC File Offset: 0x0003D8FC
		private void pictureBoxButtonNote4Dot_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this._selectedNoteButton != MelodyModule.Key.LENGTH.FOUR_DOT)
				{
					this.deselectNoteButton();
					this._selectedNoteButton = MelodyModule.Key.LENGTH.FOUR_DOT;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeNote(MelodyArea.TYPE.LENGTH, MelodyModule.Key.LENGTH.FOUR_DOT, MelodyModule.Key.RANK.REST);
				}
			}
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0003F748 File Offset: 0x0003D948
		private void pictureBoxButtonNote2_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonNote2.Image = Resources.mld_btn_082;
			}
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0003F767 File Offset: 0x0003D967
		private void pictureBoxButtonNote2_MouseEnter(object sender, EventArgs e)
		{
			if (this._selectedNoteButton != MelodyModule.Key.LENGTH.TWO)
			{
				this.pictureBoxButtonNote2.Image = Resources.mld_btn_081;
			}
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0003F782 File Offset: 0x0003D982
		private void pictureBoxButtonNote2_MouseLeave(object sender, EventArgs e)
		{
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.TWO)
			{
				this.pictureBoxButtonNote2.Image = Resources.mld_btn_082;
				return;
			}
			this.pictureBoxButtonNote2.Image = Resources.mld_btn_080;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0003F7B0 File Offset: 0x0003D9B0
		private void pictureBoxButtonNote2_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this._selectedNoteButton != MelodyModule.Key.LENGTH.TWO)
				{
					this.deselectNoteButton();
					this._selectedNoteButton = MelodyModule.Key.LENGTH.TWO;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeNote(MelodyArea.TYPE.LENGTH, MelodyModule.Key.LENGTH.TWO, MelodyModule.Key.RANK.REST);
				}
			}
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0003F7FC File Offset: 0x0003D9FC
		private void pictureBoxButtonNote2Dot_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonNote2Dot.Image = Resources.mld_btn_092;
			}
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0003F81B File Offset: 0x0003DA1B
		private void pictureBoxButtonNote2Dot_MouseEnter(object sender, EventArgs e)
		{
			if (this._selectedNoteButton != MelodyModule.Key.LENGTH.TWO_DOT)
			{
				this.pictureBoxButtonNote2Dot.Image = Resources.mld_btn_091;
			}
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0003F836 File Offset: 0x0003DA36
		private void pictureBoxButtonNote2Dot_MouseLeave(object sender, EventArgs e)
		{
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.TWO_DOT)
			{
				this.pictureBoxButtonNote2Dot.Image = Resources.mld_btn_092;
				return;
			}
			this.pictureBoxButtonNote2Dot.Image = Resources.mld_btn_090;
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0003F864 File Offset: 0x0003DA64
		private void pictureBoxButtonNote2Dot_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this._selectedNoteButton != MelodyModule.Key.LENGTH.TWO_DOT)
				{
					this.deselectNoteButton();
					this._selectedNoteButton = MelodyModule.Key.LENGTH.TWO_DOT;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeNote(MelodyArea.TYPE.LENGTH, MelodyModule.Key.LENGTH.TWO_DOT, MelodyModule.Key.RANK.REST);
				}
			}
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0003F8B0 File Offset: 0x0003DAB0
		private void pictureBoxButtonNote_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonNote.Image = Resources.mld_btn_102;
			}
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0003F8CF File Offset: 0x0003DACF
		private void pictureBoxButtonNote_MouseEnter(object sender, EventArgs e)
		{
			if (this._selectedNoteButton != MelodyModule.Key.LENGTH.ONE)
			{
				this.pictureBoxButtonNote.Image = Resources.mld_btn_101;
			}
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0003F8EA File Offset: 0x0003DAEA
		private void pictureBoxButtonNote_MouseLeave(object sender, EventArgs e)
		{
			if (this._selectedNoteButton == MelodyModule.Key.LENGTH.ONE)
			{
				this.pictureBoxButtonNote.Image = Resources.mld_btn_102;
				return;
			}
			this.pictureBoxButtonNote.Image = Resources.mld_btn_100;
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0003F918 File Offset: 0x0003DB18
		private void pictureBoxButtonNote_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this._selectedNoteButton != MelodyModule.Key.LENGTH.ONE)
				{
					this.deselectNoteButton();
					this._selectedNoteButton = MelodyModule.Key.LENGTH.ONE;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeNote(MelodyArea.TYPE.LENGTH, MelodyModule.Key.LENGTH.ONE, MelodyModule.Key.RANK.REST);
				}
				if (this.isTutorial())
				{
					MelodyWindow.TUTORIAL tutorial = this.Tutorial;
					this.Tutorial = tutorial + 1;
				}
			}
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0003F97C File Offset: 0x0003DB7C
		private void pictureBoxButtonRest16_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRest16.Image = Resources.mld_btn_112;
			}
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0003F99B File Offset: 0x0003DB9B
		private void pictureBoxButtonRest16_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonRest16.Image = Resources.mld_btn_111;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0003F9AD File Offset: 0x0003DBAD
		private void pictureBoxButtonRest16_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonRest16.Image = Resources.mld_btn_110;
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0003F9C0 File Offset: 0x0003DBC0
		private void pictureBoxButtonRest16_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRest16.Image = Resources.mld_btn_111;
				if (this._area.countSelected() == 0)
				{
					this._area.addRest(MelodyModule.Key.LENGTH.SIXTEEN, -1);
					return;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeRest(MelodyModule.Key.LENGTH.SIXTEEN);
				}
			}
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0003FA1F File Offset: 0x0003DC1F
		private void pictureBoxButtonRest8_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRest8.Image = Resources.mld_btn_122;
			}
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0003FA3E File Offset: 0x0003DC3E
		private void pictureBoxButtonRest8_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonRest8.Image = Resources.mld_btn_121;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0003FA50 File Offset: 0x0003DC50
		private void pictureBoxButtonRest8_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonRest8.Image = Resources.mld_btn_120;
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0003FA64 File Offset: 0x0003DC64
		private void pictureBoxButtonRest8_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRest8.Image = Resources.mld_btn_121;
				if (this._area.countSelected() == 0)
				{
					this._area.addRest(MelodyModule.Key.LENGTH.EIGHT, -1);
					return;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeRest(MelodyModule.Key.LENGTH.EIGHT);
				}
			}
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0003FAC3 File Offset: 0x0003DCC3
		private void pictureBoxButtonRest4_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRest4.Image = Resources.mld_btn_132;
			}
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0003FAE2 File Offset: 0x0003DCE2
		private void pictureBoxButtonRest4_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonRest4.Image = Resources.mld_btn_131;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0003FAF4 File Offset: 0x0003DCF4
		private void pictureBoxButtonRest4_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonRest4.Image = Resources.mld_btn_130;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0003FB08 File Offset: 0x0003DD08
		private void pictureBoxButtonRest4_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRest4.Image = Resources.mld_btn_131;
				if (this._area.countSelected() == 0)
				{
					this._area.addRest(MelodyModule.Key.LENGTH.FOUR, -1);
					return;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeRest(MelodyModule.Key.LENGTH.FOUR);
				}
			}
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0003FB67 File Offset: 0x0003DD67
		private void pictureBoxButtonRest2_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRest2.Image = Resources.mld_btn_142;
			}
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0003FB86 File Offset: 0x0003DD86
		private void pictureBoxButtonRest2_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonRest2.Image = Resources.mld_btn_141;
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0003FB98 File Offset: 0x0003DD98
		private void pictureBoxButtonRest2_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonRest2.Image = Resources.mld_btn_140;
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0003FBAC File Offset: 0x0003DDAC
		private void pictureBoxButtonRest2_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRest2.Image = Resources.mld_btn_141;
				if (this._area.countSelected() == 0)
				{
					this._area.addRest(MelodyModule.Key.LENGTH.TWO, -1);
					return;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeRest(MelodyModule.Key.LENGTH.TWO);
				}
			}
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0003FC0B File Offset: 0x0003DE0B
		private void pictureBoxButtonRest_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRest.Image = Resources.mld_btn_152;
			}
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0003FC2A File Offset: 0x0003DE2A
		private void pictureBoxButtonRest_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonRest.Image = Resources.mld_btn_151;
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0003FC3C File Offset: 0x0003DE3C
		private void pictureBoxButtonRest_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonRest.Image = Resources.mld_btn_150;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0003FC50 File Offset: 0x0003DE50
		private void pictureBoxButtonRest_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonRest.Image = Resources.mld_btn_151;
				if (this._area.countSelected() == 0)
				{
					this._area.addRest(MelodyModule.Key.LENGTH.ONE, -1);
					return;
				}
				if (this._area.countSelected() == 1)
				{
					this._area.changeRest(MelodyModule.Key.LENGTH.ONE);
				}
			}
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0003FCAF File Offset: 0x0003DEAF
		private void pictureBoxButtonPlay_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonPlay.Image = Resources.mld_btn_012;
			}
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0003FCCE File Offset: 0x0003DECE
		private void pictureBoxButtonPlay_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonPlay.Image = Resources.mld_btn_011;
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0003FCE0 File Offset: 0x0003DEE0
		private void pictureBoxButtonPlay_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonPlay.Image = Resources.mld_btn_010;
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0003FCF2 File Offset: 0x0003DEF2
		private void pictureBoxButtonPlay_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonPlay.Image = Resources.mld_btn_011;
				if (this.isTutorial())
				{
					this._area.clearSelect();
				}
				this.playMelody();
			}
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0003FD2A File Offset: 0x0003DF2A
		private void pictureBoxButtonStop_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonStop.Image = Resources.mld_btn_022;
			}
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0003FD49 File Offset: 0x0003DF49
		private void pictureBoxButtonStop_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonStop.Image = Resources.mld_btn_021;
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0003FD5B File Offset: 0x0003DF5B
		private void pictureBoxButtonStop_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonStop.Image = Resources.mld_btn_020;
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x0003FD6D File Offset: 0x0003DF6D
		private void pictureBoxButtonStop_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonStop.Image = Resources.mld_btn_021;
				this._stopFlag = true;
			}
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0003FD93 File Offset: 0x0003DF93
		private void pictureBoxButtonSettings_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonSettings.Image = Resources.mld_btn_171;
			}
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x0003FDB2 File Offset: 0x0003DFB2
		private void pictureBoxButtonSettings_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonSettings.Image = Resources.mld_btn_172;
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0003FDC4 File Offset: 0x0003DFC4
		private void pictureBoxButtonSettings_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonSettings.Image = Resources.mld_btn_170;
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0003FDD8 File Offset: 0x0003DFD8
		private void pictureBoxButtonSettings_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonSettings.Image = Resources.mld_btn_172;
				MelodySettingsDialog melodySettingsDialog = new MelodySettingsDialog(this);
				melodySettingsDialog.ShowDialog();
				if (this.isTutorial())
				{
					MelodyWindow.TUTORIAL tutorial = this.Tutorial;
					this.Tutorial = tutorial + 1;
				}
				if (melodySettingsDialog.Updated)
				{
					this.updateLog("設定を変更");
					this.addHistory();
				}
			}
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0003FE3F File Offset: 0x0003E03F
		private void 新規作成ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.newFile();
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0003FE47 File Offset: 0x0003E047
		private void ファイルを開くToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.openFile();
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0003FE4F File Offset: 0x0003E04F
		private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.saveFile(this._filePath);
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x0003FE5D File Offset: 0x0003E05D
		private void 名前を付けて保存ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.saveFileAs();
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x000286B1 File Offset: 0x000268B1
		private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0003FE65 File Offset: 0x0003E065
		private void 元に戻すToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.undo();
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0003FE6D File Offset: 0x0003E06D
		private void やり直すToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.redo();
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0003FE75 File Offset: 0x0003E075
		private void 切り取りToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.cutNote();
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0003FE82 File Offset: 0x0003E082
		private void コピ\u30FCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.copyNote();
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0003FE8F File Offset: 0x0003E08F
		private void 貼り付けToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.pasteNote();
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0003FE9C File Offset: 0x0003E09C
		private void 挿入ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.insertRest4();
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0003FEA9 File Offset: 0x0003E0A9
		private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.removeNote();
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0003FEB6 File Offset: 0x0003E0B6
		private void すべて選択ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._area.selectAllNote();
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0003FEC3 File Offset: 0x0003E0C3
		private void 書込みToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CommunicationModule.Instance.writeMelody(this._module);
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0003FED6 File Offset: 0x0003E0D6
		private void 読込みToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CommunicationModule.Instance.readMelody(this._module);
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0003FEEC File Offset: 0x0003E0EC
		private void 本体でメロディ再生BToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int num = Math.Max(0, this.getSelectedIndex());
			CommunicationModule.Instance.playMelody(num, false);
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0003FF13 File Offset: 0x0003E113
		private void 本体のメロディ停止EToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CommunicationModule.Instance.stopMelody();
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0003FF20 File Offset: 0x0003E120
		private void pC上でメロディ再生PToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.playMelody();
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0003FF28 File Offset: 0x0003E128
		private void pC上のメロディ停止SToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this._stopFlag = true;
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x00028AD2 File Offset: 0x00026CD2
		private void ヘルプ表示ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(".\\説明書\\Manual.pdf");
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00028ADF File Offset: 0x00026CDF
		private void バ\u30FCジョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new VersionDialog().ShowDialog();
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0003FF31 File Offset: 0x0003E131
		private void レポ\u30FCト作成RToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.createReport();
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0003FF39 File Offset: 0x0003E139
		private void 小節ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			this._area.Bar = !this._area.Bar;
			this._area.Invalidate();
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0003FF74 File Offset: 0x0003E174
		private void MelodyWindow_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (array.Length == 1 && Path.GetExtension(array[0]) == ".mdp")
				{
					e.Effect = DragDropEffects.Copy;
					return;
				}
				e.Effect = DragDropEffects.None;
			}
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0003FFD4 File Offset: 0x0003E1D4
		private void MelodyWindow_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (array.Length == 1 && Path.GetExtension(array[0]) == ".mdp")
				{
					bool flag = true;
					if (!this._history.isSaved())
					{
						ConfirmDialog confirmDialog = new ConfirmDialog();
						confirmDialog.Text = "ファイルを開く";
						confirmDialog.setText(MelodyWindow.WARNING_SAVE);
						confirmDialog.ShowDialog();
						flag = confirmDialog.OK;
					}
					if (flag)
					{
						Stream stream = new FileStream(array[0], FileMode.Open, FileAccess.Read);
						if (stream != null)
						{
							this._filePath = array[0];
							this.openFile(stream);
						}
					}
				}
			}
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x00040080 File Offset: 0x0003E280
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

		// Token: 0x0600057B RID: 1403 RVA: 0x00040130 File Offset: 0x0003E330
		private void MelodyWindow_Resize(object sender, EventArgs e)
		{
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

		// Token: 0x0600057C RID: 1404 RVA: 0x000401B0 File Offset: 0x0003E3B0
		private void pictureBoxArrowLeft_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowLeft.Image = Resources.icon_btn_222;
			}
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x000401CF File Offset: 0x0003E3CF
		private void pictureBoxArrowLeft_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowLeft.Image = Resources.icon_btn_221;
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x000401E1 File Offset: 0x0003E3E1
		private void pictureBoxArrowLeft_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowLeft.Image = Resources.icon_btn_220;
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x000401F3 File Offset: 0x0003E3F3
		private void pictureBoxArrowLeft_MouseUp(object sender, MouseEventArgs e)
		{
			this.setScrollH(Math.Max(Math.Min(this._scrollIndexH - 1, this._buttonTools.Count - 1), -1));
			this.pictureBoxArrowLeft.Image = Resources.icon_btn_221;
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x0004022B File Offset: 0x0003E42B
		private void pictureBoxArrowRight_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxArrowRight.Image = Resources.icon_btn_212;
			}
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0004024A File Offset: 0x0003E44A
		private void pictureBoxArrowRight_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxArrowRight.Image = Resources.icon_btn_211;
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0004025C File Offset: 0x0003E45C
		private void pictureBoxArrowRight_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxArrowRight.Image = Resources.icon_btn_210;
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x00040270 File Offset: 0x0003E470
		private void pictureBoxArrowRight_MouseUp(object sender, MouseEventArgs e)
		{
			int num = (this.pictureBoxArrowRight.Parent.Width - this.pictureBoxArrowRight.Width - this._buttonTools[0].Location.X) / 72;
			this.setScrollH(Math.Max(Math.Min(this._scrollIndexH + 1, this._buttonTools.Count - num), 0));
			this.pictureBoxArrowRight.Image = Resources.icon_btn_211;
		}

		// Token: 0x040003FC RID: 1020
		private const int SCROLL_BAR_WIDTH = 20;

		// Token: 0x040003FD RID: 1021
		private const int TONE_MILLI_SECOND = 200;

		// Token: 0x040003FE RID: 1022
		private const float SIXTEEN_MILLI_SECOND = 250f;

		// Token: 0x040003FF RID: 1023
		private const float MINUTE_SECOND = 60f;

		// Token: 0x04000400 RID: 1024
		private static readonly float[] TEMPO_ARRAY = new float[] { 60f, 90f, 120f, 150f, 180f };

		// Token: 0x04000401 RID: 1025
		private static readonly string WARNING_SAVE = "編集中のデータが失われますが良いですか？";

		// Token: 0x04000402 RID: 1026
		private static MidiModule _midi = new MidiModule();

		// Token: 0x04000403 RID: 1027
		private MelodyModule _module = new MelodyModule();

		// Token: 0x04000404 RID: 1028
		private MelodyArea _area;

		// Token: 0x04000405 RID: 1029
		private MelodyKeyboard _keyboard;

		// Token: 0x04000406 RID: 1030
		private MelodyModule.Key.LENGTH _selectedNoteButton;

		// Token: 0x04000407 RID: 1031
		private bool _useMidiFlag;

		// Token: 0x04000408 RID: 1032
		private bool _stopFlag;

		// Token: 0x04000409 RID: 1033
		private History _history = new History();

		// Token: 0x0400040A RID: 1034
		private string _filePath = "";

		// Token: 0x0400040B RID: 1035
		private bool _playingFlag;

		// Token: 0x0400040C RID: 1036
		private int _scrollIndexH;

		// Token: 0x0400040D RID: 1037
		private List<PictureBox> _buttonTools = new List<PictureBox>();

		// Token: 0x0400040E RID: 1038
		private TutorialWindow _tutorialWindow;

		// Token: 0x0400040F RID: 1039
		private MelodyWindow.TUTORIAL _tutorial;

		// Token: 0x04000410 RID: 1040
		private bool _tutorialKeyboardEnableFlag = true;

		// Token: 0x04000411 RID: 1041
		private readonly string[] _tutorialTexts = new string[]
		{
			"ここではメロディを作成し、本体で再生させます。\r\n「はじめる」ボタンを押してください。", "小さな画面の指示に従って操作してください。\r\n※指示以外の操作は受け付けないようになっています。", "①音符の種類から、全音符を選びましょう。", "②真ん中の「ソ」の鍵盤をクリックして、\r\n音符を配置してみましょう。", "③「設定」ボタンで設定ウィンドウを開き、\r\nテンポ「90」を選んで、「OK」ボタンを押しましょう。", "④再生してみましょう。", "⑤間違っていますね。変更してみましょう。\r\n楽譜の一番最後の音符をクリックしましょう。", "⑥音符の種類から、4分音符を選びましょう。", "⑦低い方の「ド」の鍵盤をクリックしましょう。", "⑧再生してみましょう。",
			"正しくなりましたね。つかいかたはこれで終わりです。\r\n今度は自分でいろんなメロディを作ってみましょう。"
		};

		// Token: 0x04000412 RID: 1042
		private readonly Image[] _tutorialImages = new Image[]
		{
			Resources.tutorial_mld_000,
			Resources.tutorial_nw_018,
			Resources.tutorial_mld_001,
			Resources.tutorial_mld_002,
			Resources.tutorial_mld_003,
			Resources.tutorial_mld_004,
			Resources.tutorial_mld_005,
			Resources.tutorial_mld_006,
			Resources.tutorial_mld_007,
			Resources.tutorial_mld_004,
			Resources.tutorial_mld_010
		};

		// Token: 0x0200009E RID: 158
		public enum TUTORIAL
		{
			// Token: 0x0400086E RID: 2158
			START,
			// Token: 0x0400086F RID: 2159
			CAUTION,
			// Token: 0x04000870 RID: 2160
			NOTE,
			// Token: 0x04000871 RID: 2161
			KEY,
			// Token: 0x04000872 RID: 2162
			TEMPO,
			// Token: 0x04000873 RID: 2163
			PLAY_1,
			// Token: 0x04000874 RID: 2164
			SELECT,
			// Token: 0x04000875 RID: 2165
			CHANGE_NOTE,
			// Token: 0x04000876 RID: 2166
			CHANGE_KEY,
			// Token: 0x04000877 RID: 2167
			PLAY_2,
			// Token: 0x04000878 RID: 2168
			END,
			// Token: 0x04000879 RID: 2169
			MAX
		}
	}
}
