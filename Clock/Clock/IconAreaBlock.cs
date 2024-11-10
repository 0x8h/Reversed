using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000026 RID: 38
	public class IconAreaBlock : PictureBox
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600038A RID: 906 RVA: 0x0002F5C8 File Offset: 0x0002D7C8
		// (set) Token: 0x0600038B RID: 907 RVA: 0x0002F5D0 File Offset: 0x0002D7D0
		public IconAreaBlock.TYPE Type
		{
			get
			{
				return this._type;
			}
			set
			{
				if (this._type != value)
				{
					if (this._type != IconAreaBlock.TYPE.BLANK)
					{
						this._window.Program.removeBlock(this._block, false);
					}
					this.createProgramBlock(value);
					this._type = value;
					switch (this._type)
					{
					case IconAreaBlock.TYPE.LED:
						base.Image = Resources.icon_block_010;
						break;
					case IconAreaBlock.TYPE.SOUND:
						base.Image = Resources.icon_block_030;
						break;
					case IconAreaBlock.TYPE.WAIT:
						base.Image = Resources.icon_block_050;
						break;
					case IconAreaBlock.TYPE.LOOP_START:
						base.Image = Resources.icon_block_060;
						break;
					case IconAreaBlock.TYPE.LOOP_END:
						base.Image = Resources.icon_block_070;
						break;
					case IconAreaBlock.TYPE.WAIT_CONDITION:
						base.Image = Resources.icon_block_080;
						break;
					}
					this.updateView();
				}
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600038C RID: 908 RVA: 0x0002F691 File Offset: 0x0002D891
		// (set) Token: 0x0600038D RID: 909 RVA: 0x0002F699 File Offset: 0x0002D899
		public new bool Select
		{
			get
			{
				return this._select;
			}
			set
			{
				if (this._type != IconAreaBlock.TYPE.BLANK)
				{
					this._select = value;
				}
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600038E RID: 910 RVA: 0x0002F6AA File Offset: 0x0002D8AA
		// (set) Token: 0x0600038F RID: 911 RVA: 0x0002F6B4 File Offset: 0x0002D8B4
		public ProgramModule.Block Block
		{
			get
			{
				return this._block;
			}
			set
			{
				if (this._block != null && this._block != value)
				{
					if (this._type != IconAreaBlock.TYPE.BLANK)
					{
						this._window.Program.removeBlock(this._block, false);
					}
					this._window.Program.addBlock(value);
				}
				this._block = value;
			}
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0002F70C File Offset: 0x0002D90C
		public IconAreaBlock(IconWindow window)
		{
			this._window = window;
			this.InitializeComponent();
			this._text = "ここにアイコンを\r\nドラッグしてくだ\r\nさい";
			this.AllowDrop = true;
			if (!this._window.isTutorial())
			{
				this.ContextMenuStrip = this._window.RightClickMenu;
			}
			base.MouseDown += this.IconAreaBlock_MouseDown;
			base.MouseDoubleClick += this.IconAreaBlock_MouseDoubleClick;
			base.GiveFeedback += this.IconAreaBlock_GiveFeedback;
			base.DragEnter += this.IconAreaBlock_DragEnter;
			base.DragLeave += this.IconAreaBlock_DragLeave;
			base.DragDrop += this.IconAreaBlock_DragDrop;
			base.QueryContinueDrag += this.IconAreaBlock_QueryContinueDrag;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0002F7E8 File Offset: 0x0002D9E8
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			Brush brush = new SolidBrush(this._textColor);
			if (this._type == IconAreaBlock.TYPE.BLANK)
			{
				pe.Graphics.DrawString(this._text, IconAreaBlock._font, brush, 10f, 40f);
			}
			else
			{
				pe.Graphics.DrawString(this._text, IconAreaBlock._font, brush, 10f, 60f);
			}
			if (this.Select)
			{
				Pen pen = new Pen(Color.Blue, 5f);
				pe.Graphics.DrawRectangle(pen, 0, 0, base.Size.Width, base.Size.Height);
			}
			if ((!this._window.isTutorial() || this._type == IconAreaBlock.TYPE.BLANK) && this._onDrag)
			{
				brush = new SolidBrush(Color.FromArgb(128, Color.White));
				pe.Graphics.FillRectangle(brush, 0, 0, base.Size.Width, base.Size.Height);
			}
		}

		// Token: 0x06000392 RID: 914 RVA: 0x0002F8F4 File Offset: 0x0002DAF4
		public void updateView()
		{
			this._text = this._block.getDetail();
			base.Invalidate();
			if (this._type == IconAreaBlock.TYPE.LED)
			{
				ProgramModule.BlockLED blockLED = (ProgramModule.BlockLED)this._block;
				if (blockLED.Mode == ProgramModule.BlockLED.LED_MODE.OFF || (blockLED.Red == 0 && blockLED.Green == 0 && blockLED.Blue == 0))
				{
					base.Image = Resources.icon_block_020;
				}
				else
				{
					base.Image = Resources.icon_block_010;
				}
				this.BackColor = Color.FromArgb((int)((double)blockLED.Red * 25.5), (int)((double)blockLED.Green * 25.5), (int)((double)blockLED.Blue * 25.5));
				return;
			}
			if (this._type == IconAreaBlock.TYPE.SOUND)
			{
				if (((ProgramModule.BlockSound)this._block).Mode == ProgramModule.BlockSound.MODE.BEEP)
				{
					base.Image = Resources.icon_block_030;
					return;
				}
				base.Image = Resources.icon_block_040;
				return;
			}
			else
			{
				if (this._type != IconAreaBlock.TYPE.LOOP_END)
				{
					if (this._type == IconAreaBlock.TYPE.WAIT_CONDITION)
					{
						ProgramModule.BlockWaitCondition blockWaitCondition = (ProgramModule.BlockWaitCondition)this._block;
						switch (blockWaitCondition.Condition)
						{
						case ProgramModule.BlockWaitCondition.CONDITION.BUTTON:
							base.Image = Resources.icon_block_080;
							return;
						case ProgramModule.BlockWaitCondition.CONDITION.LIGHT:
							if (blockWaitCondition.Light == ProgramModule.BlockWaitCondition.LIGHT.BRIGHT)
							{
								base.Image = Resources.icon_block_090;
								return;
							}
							base.Image = Resources.icon_block_095;
							return;
						case ProgramModule.BlockWaitCondition.CONDITION.SOUND:
							base.Image = Resources.icon_block_100;
							return;
						case ProgramModule.BlockWaitCondition.CONDITION.ALARM:
							base.Image = Resources.icon_block_120;
							return;
						case ProgramModule.BlockWaitCondition.CONDITION.TIMER:
							base.Image = Resources.icon_block_130;
							break;
						case ProgramModule.BlockWaitCondition.CONDITION.TIME:
							base.Image = Resources.icon_block_110;
							return;
						case ProgramModule.BlockWaitCondition.CONDITION.TEMPERATURE:
							base.Image = Resources.icon_block_140;
							return;
						default:
							return;
						}
					}
					return;
				}
				if (((ProgramModule.BlockLoopEnd)this._block).Index > 0)
				{
					this._textColor = Color.Black;
					return;
				}
				this._textColor = Color.Red;
				return;
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0002FABC File Offset: 0x0002DCBC
		public static IconAreaBlock.TYPE getType(ProgramModule.Block block)
		{
			if (block.GetType() == typeof(ProgramModule.BlockLED))
			{
				return IconAreaBlock.TYPE.LED;
			}
			if (block.GetType() == typeof(ProgramModule.BlockSound))
			{
				return IconAreaBlock.TYPE.SOUND;
			}
			if (block.GetType() == typeof(ProgramModule.BlockWait))
			{
				return IconAreaBlock.TYPE.WAIT;
			}
			if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
			{
				return IconAreaBlock.TYPE.LOOP_START;
			}
			if (block.GetType() == typeof(ProgramModule.BlockLoopEnd))
			{
				return IconAreaBlock.TYPE.LOOP_END;
			}
			if (block.GetType() == typeof(ProgramModule.BlockWaitCondition))
			{
				return IconAreaBlock.TYPE.WAIT_CONDITION;
			}
			return IconAreaBlock.TYPE.BLANK;
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0002FB60 File Offset: 0x0002DD60
		public static int getMemoryCost(IconAreaBlock.TYPE type)
		{
			int num = 0;
			switch (type)
			{
			case IconAreaBlock.TYPE.LED:
				num = 6;
				break;
			case IconAreaBlock.TYPE.SOUND:
				num = 2;
				break;
			case IconAreaBlock.TYPE.WAIT:
				num = 3;
				break;
			case IconAreaBlock.TYPE.LOOP_START:
				num = 3;
				break;
			case IconAreaBlock.TYPE.LOOP_END:
				num = 2;
				break;
			case IconAreaBlock.TYPE.WAIT_CONDITION:
				num = 5;
				break;
			}
			return num;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0002FBA8 File Offset: 0x0002DDA8
		public bool isIncluded(Rectangle rect)
		{
			return ((rect.X <= base.Location.X && rect.X + rect.Width >= base.Location.X) || (base.Location.X <= rect.X && rect.X <= base.Location.X + base.Width)) && ((rect.Y <= base.Location.Y && rect.Y + rect.Height >= base.Location.Y) || (base.Location.Y <= rect.Y && rect.Y <= base.Location.Y + base.Height));
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0002FC94 File Offset: 0x0002DE94
		private void createProgramBlock(IconAreaBlock.TYPE type)
		{
			switch (type)
			{
			case IconAreaBlock.TYPE.LED:
				this._block = new ProgramModule.BlockLED();
				break;
			case IconAreaBlock.TYPE.SOUND:
				this._block = new ProgramModule.BlockSound();
				break;
			case IconAreaBlock.TYPE.WAIT:
				this._block = new ProgramModule.BlockWait();
				break;
			case IconAreaBlock.TYPE.LOOP_START:
				this._block = new ProgramModule.BlockLoopStart();
				break;
			case IconAreaBlock.TYPE.LOOP_END:
				this._block = new ProgramModule.BlockLoopEnd();
				break;
			case IconAreaBlock.TYPE.WAIT_CONDITION:
				this._block = new ProgramModule.BlockWaitCondition();
				break;
			}
			this._window.Program.addBlock(this._block);
			this._window.updateLog("アイコンを追加");
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0002FD38 File Offset: 0x0002DF38
		private void IconAreaBlock_MouseDown(object sender, MouseEventArgs e)
		{
			if (this._window.isTutorial())
			{
				return;
			}
			if (!this.Select)
			{
				if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					this._window.addSelect(this);
				}
				else
				{
					this._window.clearSelect();
					this._window.setSelect(this);
				}
			}
			if (e.Button == MouseButtons.Left && this.Type != IconAreaBlock.TYPE.BLANK)
			{
				if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
				{
					this._block.BreakPoint = !this._block.BreakPoint;
					this._window.updateLog("ブレークポイントを設定");
					this._window.Area.Invalidate();
					return;
				}
				if (e.Clicks == 1)
				{
					base.DoDragDrop("MOVE", DragDropEffects.Copy);
				}
			}
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0002FE0C File Offset: 0x0002E00C
		private void IconAreaBlock_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._window.isTutorial() && this._window.Tutorial != IconWindow.TUTORIAL.DOUBLE_CLICK)
			{
				return;
			}
			if ((Control.ModifierKeys & Keys.Control) != Keys.Control && this._block != null)
			{
				Form form = null;
				int num = 256 - this._window.Program.getUsedMemory(false) + this._block.getUsedMemory();
				switch (this._type)
				{
				case IconAreaBlock.TYPE.LED:
					form = new BlockPropertyLEDDialog((ProgramModule.BlockLED)this._block, num, this._window.isTutorial());
					break;
				case IconAreaBlock.TYPE.SOUND:
					form = new BlockPropertySoundDialog((ProgramModule.BlockSound)this._block, num);
					break;
				case IconAreaBlock.TYPE.WAIT:
					form = new BlockPropertyWaitDialog((ProgramModule.BlockWait)this._block, num, false);
					break;
				case IconAreaBlock.TYPE.LOOP_START:
					form = new BlockPropertyLoopDialog((ProgramModule.BlockLoopStart)this._block, num);
					break;
				case IconAreaBlock.TYPE.WAIT_CONDITION:
					form = new BlockPropertyWaitConditionDialog((ProgramModule.BlockWaitCondition)this._block, num);
					break;
				}
				if (form != null)
				{
					form.StartPosition = FormStartPosition.Manual;
					form.DesktopLocation = base.Parent.PointToScreen(new Point(base.Location.X + 20, base.Location.Y + 20));
					if (this._window.isTutorial() && this._window.Tutorial == IconWindow.TUTORIAL.DOUBLE_CLICK)
					{
						IconWindow window = this._window;
						IconWindow.TUTORIAL tutorial = window.Tutorial;
						window.Tutorial = tutorial + 1;
					}
					form.ShowDialog();
					if (this._window.isTutorial())
					{
						IconWindow window2 = this._window;
						IconWindow.TUTORIAL tutorial = window2.Tutorial;
						window2.Tutorial = tutorial + 1;
					}
					if (this._block.Updated)
					{
						this._block.Updated = false;
						this._window.Program.updateConnectState();
						this._window.updateProgram();
						this._window.updateUsedMemory();
						this._window.addHistory();
						this.updateView();
						switch (this._type)
						{
						case IconAreaBlock.TYPE.LED:
							this._window.updateLog("LEDアイコンの設定を変更");
							return;
						case IconAreaBlock.TYPE.SOUND:
							this._window.updateLog("サウンドアイコンの設定を変更");
							return;
						case IconAreaBlock.TYPE.WAIT:
							this._window.updateLog("ウェイトアイコンの設定を変更");
							return;
						case IconAreaBlock.TYPE.LOOP_START:
							this._window.updateLog("ループ開始アイコンの設定を変更");
							return;
						case IconAreaBlock.TYPE.LOOP_END:
							break;
						case IconAreaBlock.TYPE.WAIT_CONDITION:
							this._window.updateLog("条件待ちアイコンの設定を変更");
							break;
						default:
							return;
						}
					}
				}
			}
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00030083 File Offset: 0x0002E283
		private void IconAreaBlock_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				Cursor.Current = IconAreaBlock.cursorAreaBlock;
			}
		}

		// Token: 0x0600039A RID: 922 RVA: 0x000300A1 File Offset: 0x0002E2A1
		private void IconAreaBlock_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.Copy;
				this._onDrag = true;
				base.Invalidate();
				return;
			}
			e.Effect = DragDropEffects.None;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x000300D1 File Offset: 0x0002E2D1
		private void IconAreaBlock_DragLeave(object sender, EventArgs e)
		{
			this._onDrag = false;
			base.Invalidate();
		}

		// Token: 0x0600039C RID: 924 RVA: 0x000300E0 File Offset: 0x0002E2E0
		private void IconAreaBlock_DragDrop(object sender, DragEventArgs e)
		{
			string text = e.Data.GetData(DataFormats.Text).ToString();
			if (text == "MOVE")
			{
				if (!this.Select)
				{
					if (this.Type == IconAreaBlock.TYPE.BLANK)
					{
						this._window.moveSelectAreaBlock(this._window.AreaBlocks[this._window.AreaBlocks.Count - 2]);
					}
					else
					{
						this._window.moveSelectAreaBlock(this);
					}
					this._window.addHistory();
				}
			}
			else
			{
				IconAreaBlock.TYPE type = IconAreaBlock.TYPE.BLANK;
				if (!(text == "LED"))
				{
					if (!(text == "SOUND"))
					{
						if (!(text == "WAIT"))
						{
							if (!(text == "LOOP_START"))
							{
								if (!(text == "LOOP_END"))
								{
									if (text == "WAIT_CONDITION")
									{
										type = IconAreaBlock.TYPE.WAIT_CONDITION;
									}
								}
								else
								{
									type = IconAreaBlock.TYPE.LOOP_END;
								}
							}
							else
							{
								type = IconAreaBlock.TYPE.LOOP_START;
							}
						}
						else
						{
							type = IconAreaBlock.TYPE.WAIT;
						}
					}
					else
					{
						type = IconAreaBlock.TYPE.SOUND;
					}
				}
				else
				{
					type = IconAreaBlock.TYPE.LED;
				}
				if (this.Type == IconAreaBlock.TYPE.BLANK)
				{
					if (type != IconAreaBlock.TYPE.BLANK)
					{
						if (this._window.isMemoryOver(IconAreaBlock.getMemoryCost(type)))
						{
							WarningDialog warningDialog = new WarningDialog();
							warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
							warningDialog.ShowDialog();
						}
						else
						{
							if (this._window.isTutorial() && (this._window.Tutorial == IconWindow.TUTORIAL.DRAG_LED || this._window.Tutorial == IconWindow.TUTORIAL.DRAG_SOUND))
							{
								IconWindow window = this._window;
								IconWindow.TUTORIAL tutorial = window.Tutorial;
								window.Tutorial = tutorial + 1;
							}
							this.Type = type;
							this._window.addAreaBlockBlank();
							this._window.updateLayout();
							this._window.addHistory();
							this._window.clearSelect();
							this._window.setSelect(this);
						}
					}
				}
				else if (!this._window.isTutorial())
				{
					IconDropDialog iconDropDialog = new IconDropDialog(this, type);
					iconDropDialog.ShowDialog(this._window);
					if (iconDropDialog.Select == IconDropDialog.SELECT.WRITE)
					{
						this._window.clearSelect();
						this._window.setSelect(this);
					}
				}
			}
			this._onDrag = false;
			base.Invalidate();
		}

		// Token: 0x0600039D RID: 925 RVA: 0x000302E3 File Offset: 0x0002E4E3
		private void IconAreaBlock_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
		{
			this.scrollScreen();
		}

		// Token: 0x0600039E RID: 926 RVA: 0x000302EC File Offset: 0x0002E4EC
		private void scrollScreen()
		{
			if (this._window.Area.PointToClient(Cursor.Position).Y + ((SplitterPanel)this._window.Area.Parent).AutoScrollPosition.Y > ((SplitterPanel)this._window.Area.Parent).Height)
			{
				((SplitterPanel)this._window.Area.Parent).AutoScrollPosition = new Point(-((SplitterPanel)this._window.Area.Parent).AutoScrollPosition.X, -((SplitterPanel)this._window.Area.Parent).AutoScrollPosition.Y + 3);
			}
			else if (this._window.Area.PointToClient(Cursor.Position).Y + ((SplitterPanel)this._window.Area.Parent).AutoScrollPosition.Y < 0)
			{
				((SplitterPanel)this._window.Area.Parent).AutoScrollPosition = new Point(-((SplitterPanel)this._window.Area.Parent).AutoScrollPosition.X, -((SplitterPanel)this._window.Area.Parent).AutoScrollPosition.Y - 3);
			}
			this._window.Area.Update();
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0003047B File Offset: 0x0002E67B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0003049A File Offset: 0x0002E69A
		private void InitializeComponent()
		{
			((ISupportInitialize)this).BeginInit();
			base.SuspendLayout();
			base.Image = Resources.icon_block_000;
			base.Size = new Size(121, 129);
			((ISupportInitialize)this).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040002F5 RID: 757
		private IconAreaBlock.TYPE _type;

		// Token: 0x040002F6 RID: 758
		private bool _select;

		// Token: 0x040002F7 RID: 759
		private bool _onDrag;

		// Token: 0x040002F8 RID: 760
		private IconWindow _window;

		// Token: 0x040002F9 RID: 761
		private ProgramModule.Block _block;

		// Token: 0x040002FA RID: 762
		private string _text;

		// Token: 0x040002FB RID: 763
		private static Font _font = new Font("メイリオ", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);

		// Token: 0x040002FC RID: 764
		private Color _textColor = Color.Black;

		// Token: 0x040002FD RID: 765
		private static Cursor cursorAreaBlock = CursorCreator.CreateCursor(Resources.icon_block_001, Resources.icon_block_001.Width / 2, Resources.icon_block_001.Height / 2);

		// Token: 0x040002FE RID: 766
		private IContainer components;

		// Token: 0x02000096 RID: 150
		public enum TYPE
		{
			// Token: 0x04000849 RID: 2121
			BLANK,
			// Token: 0x0400084A RID: 2122
			LED,
			// Token: 0x0400084B RID: 2123
			SOUND,
			// Token: 0x0400084C RID: 2124
			WAIT,
			// Token: 0x0400084D RID: 2125
			LOOP_START,
			// Token: 0x0400084E RID: 2126
			LOOP_END,
			// Token: 0x0400084F RID: 2127
			WAIT_CONDITION
		}
	}
}
