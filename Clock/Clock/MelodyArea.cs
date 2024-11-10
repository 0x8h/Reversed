using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200002B RID: 43
	public class MelodyArea : PictureBox
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x00038B67 File Offset: 0x00036D67
		public MelodyModule Module
		{
			get
			{
				return this._module;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x00038B6F File Offset: 0x00036D6F
		// (set) Token: 0x06000483 RID: 1155 RVA: 0x00038B77 File Offset: 0x00036D77
		public bool Bar { get; set; } = true;

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x00038B80 File Offset: 0x00036D80
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x00038B88 File Offset: 0x00036D88
		public int ScrollIndex
		{
			get
			{
				return this._scrollIndex;
			}
			set
			{
				this._scrollIndex = value;
			}
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00038B94 File Offset: 0x00036D94
		public MelodyArea(ref MelodyModule module, MelodyWindow window)
		{
			this.InitializeComponent();
			this._module = module;
			this._window = window;
			this.ContextMenuStrip = this._window.RightClickMenu;
			base.MouseDown += this.MelodyArea_MouseDown;
			base.MouseMove += this.MelodyArea_MouseMove;
			base.MouseUp += this.MelodyArea_MouseUp;
			base.MouseEnter += this.MelodyArea_MouseEnter;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00038C38 File Offset: 0x00036E38
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			int rowCount = this.getRowCount();
			base.Height = MelodyArea.SCORE_HEIGHT * rowCount;
			Graphics graphics = pe.Graphics;
			this.drawMelody(graphics, rowCount);
			this._window.updateUsedMemory();
			if (this._drag)
			{
				Rectangle selectRect = this._selectRect;
				if (selectRect.Width < 0)
				{
					selectRect.X += selectRect.Width;
					selectRect.Width *= -1;
				}
				if (selectRect.Height < 0)
				{
					selectRect.Y += selectRect.Height;
					selectRect.Height *= -1;
				}
				pe.Graphics.DrawRectangle(Pens.Blue, selectRect);
			}
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00038CF8 File Offset: 0x00036EF8
		private int getRowCount()
		{
			int num = 0;
			foreach (MelodyModule.Key key in this._module.Keys)
			{
				num += key.getBlockSize();
			}
			int num2 = MelodyArea.SCORE_ROW_DEFAULT;
			if (num > MelodyArea.BLOCK_SIZE_ROW * num2)
			{
				num2 = num / MelodyArea.BLOCK_SIZE_ROW + 1;
			}
			return num2;
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00038D70 File Offset: 0x00036F70
		private void drawMelody(Graphics graphics, int drawScoreCount)
		{
			int num = 0;
			for (int i = 0; i < drawScoreCount; i++)
			{
				int num2 = MelodyArea.SCORE_HEIGHT * num;
				for (int j = 0; j < 5; j++)
				{
					Point point = new Point(MelodyArea.SCORE_START_X, num2 + MelodyArea.SCORE_TOP_PADDING + MelodyArea.SCORE_LINE_INTERVAL * j);
					Point point2 = new Point(MelodyArea.SCORE_END_X, num2 + MelodyArea.SCORE_TOP_PADDING + MelodyArea.SCORE_LINE_INTERVAL * j);
					graphics.DrawLine(MelodyArea.PEN, point, point2);
				}
				if (this.Bar)
				{
					Point point3 = new Point(MelodyArea.SCORE_END_X / 2, num2 + MelodyArea.SCORE_TOP_PADDING);
					Point point4 = new Point(MelodyArea.SCORE_END_X / 2, num2 + MelodyArea.SCORE_TOP_PADDING + MelodyArea.SCORE_LINE_INTERVAL * 4);
					graphics.DrawLine(MelodyArea.PEN, point3, point4);
					point3.X = MelodyArea.SCORE_END_X;
					point4.X = MelodyArea.SCORE_END_X;
					graphics.DrawLine(MelodyArea.PEN, point3, point4);
				}
				Bitmap bitmap = new Bitmap(Resources.mld_note_000);
				Point point5 = new Point(MelodyArea.SCORE_START_X + (int)((double)bitmap.Width * 0.63), num2 + (int)((double)bitmap.Height * 0.26));
				graphics.DrawImage(bitmap, point5);
				num++;
			}
			int num3 = 0;
			int num4 = -1;
			int num5 = 0;
			for (int k = 0; k < this._module.Keys.Count; k++)
			{
				MelodyModule.Key key = this._module.Keys[k];
				int num6 = num3 / MelodyArea.BLOCK_SIZE_ROW + 1;
				int num7 = num3;
				if (num6 >= 2)
				{
					num7 = num3 - MelodyArea.BLOCK_SIZE_ROW * (num6 - 1);
				}
				int num8 = MelodyArea.SCORE_HEIGHT * (num6 - 1) + MelodyArea.SCORE_TOP_PADDING;
				int num9 = MelodyArea.NOTE_START_X + MelodyArea.BLOCK_WIDTH * num7;
				Bitmap bitmap2;
				if (key.Rank != MelodyModule.Key.RANK.REST)
				{
					bitmap2 = MelodyArea.NOTE_IMG_ARRAY[(int)key.Length, (int)key.judgeSelect(), (int)key.judgeNoteBar()];
					num8 += MelodyModule.Key.adjustHeightNote(key.Rank);
				}
				else
				{
					bitmap2 = MelodyArea.REST_IMG_ARRAY[(int)key.Length, (int)key.judgeSelect()];
					num8 += MelodyModule.Key.adjustHeightRest(key.Length);
				}
				Point point6 = new Point(num9, num8);
				graphics.DrawImage(bitmap2, point6);
				if (key.isSharp())
				{
					int num10 = num8 + (int)((double)bitmap2.Height * 0.175);
					int num11 = num9 - (int)((double)bitmap2.Width * 0.45);
					if (key.judgeNoteBar() == MelodyModule.Key.NOTE_BAR.UNDER)
					{
						num10 -= (int)((double)bitmap2.Height * 0.725);
					}
					Bitmap bitmap3 = MelodyArea.SHARP_IMG_ARRAY[(int)key.judgeSelect()];
					Point point7 = new Point(num11, num10);
					graphics.DrawImage(bitmap3, point7);
				}
				Pen pen;
				if (key.Selected)
				{
					pen = MelodyArea.LINE_PEN_SELECTED;
					if (num4 == -1)
					{
						num4 = k;
					}
				}
				else
				{
					pen = MelodyArea.LINE_PEN;
				}
				int num12 = MelodyArea.SCORE_HEIGHT * (num6 - 1);
				if (key.getTopLine() != 0)
				{
					for (int l = 1; l <= key.getTopLine(); l++)
					{
						Point point8 = new Point(num9 - (int)((double)bitmap2.Width * 0.23), num12 + MelodyArea.SCORE_TOP_PADDING - l * MelodyArea.SCORE_LINE_INTERVAL);
						Point point9 = new Point(num9 + (int)((double)bitmap2.Width * 0.68), num12 + MelodyArea.SCORE_TOP_PADDING - l * MelodyArea.SCORE_LINE_INTERVAL);
						graphics.DrawLine(pen, point8, point9);
					}
				}
				if (key.getBottomLine() != 0)
				{
					for (int m = 1; m <= key.getBottomLine(); m++)
					{
						Point point10 = new Point(num9 - (int)((double)bitmap2.Width * 0.23), num12 + MelodyArea.SCORE_TOP_PADDING + MelodyArea.SCORE_LINE_INTERVAL * 4 + m * MelodyArea.SCORE_LINE_INTERVAL);
						Point point11 = new Point(num9 + (int)((double)bitmap2.Width * 0.68), num12 + MelodyArea.SCORE_TOP_PADDING + MelodyArea.SCORE_LINE_INTERVAL * 4 + m * MelodyArea.SCORE_LINE_INTERVAL);
						graphics.DrawLine(pen, point10, point11);
					}
				}
				if (k == this._scrollIndex)
				{
					num5 = num6;
				}
				num3 += key.getBlockSize();
			}
			if (num5 != 0)
			{
				SplitterPanel panel = this._window.getPanel1();
				Point autoScrollPosition = panel.AutoScrollPosition;
				int num13 = -autoScrollPosition.X;
				int num14 = -autoScrollPosition.Y;
				int height = panel.Height;
				int num15 = base.Height / MelodyArea.SCORE_HEIGHT;
				int num16 = -1;
				int num17 = -1;
				for (int n = 1; n <= num15; n++)
				{
					int num18 = (n - 1) * MelodyArea.SCORE_HEIGHT;
					int num19 = n * MelodyArea.SCORE_HEIGHT;
					if (num18 >= num14 && num19 <= num14 + height)
					{
						if (num16 == -1)
						{
							num16 = n;
						}
						else
						{
							num17 = n;
						}
					}
				}
				if (num5 < num16 || num5 > num17)
				{
					int num20 = height / MelodyArea.SCORE_HEIGHT;
					int num21 = num5 - num20 + 1;
					if (num21 < 1)
					{
						num21 = 1;
					}
					int num22 = (num21 - 1) * MelodyArea.SCORE_HEIGHT;
					panel.AutoScrollPosition = new Point(num13, num22);
				}
			}
			this._scrollIndex = -1;
			if (this.countSelected() != 1)
			{
				this._window.unselectedNote();
			}
			else if (this._module.Keys[num4].Rank == MelodyModule.Key.RANK.REST)
			{
				this._window.unselectedNote();
			}
			this._firstSelectedIndex = num4;
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x000392BC File Offset: 0x000374BC
		public int countSelected()
		{
			int num = 0;
			for (int i = 0; i < this._module.Keys.Count; i++)
			{
				if (this._module.Keys[i].Selected)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00039304 File Offset: 0x00037504
		public void addNote(MelodyModule.Key.RANK rank, MelodyModule.Key.LENGTH length)
		{
			if (this._window.isMemoryOver(1))
			{
				WarningDialog warningDialog = new WarningDialog();
				warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
				warningDialog.ShowDialog();
				return;
			}
			MelodyModule.Key key = new MelodyModule.Key();
			key.Rank = rank;
			key.Length = length;
			this._module.addKey(key);
			this._scrollIndex = this._module.Keys.Count - 1;
			this.clearSelect();
			this._window.addHistory();
			this._window.updateLog("音符/休符を追加");
			base.Invalidate();
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00039398 File Offset: 0x00037598
		public void changeNote(MelodyArea.TYPE type, MelodyModule.Key.LENGTH length, MelodyModule.Key.RANK rank = MelodyModule.Key.RANK.REST)
		{
			int num = -1;
			for (int i = 0; i < this._module.Keys.Count; i++)
			{
				if (this._module.Keys[i].Selected)
				{
					num = i;
					break;
				}
			}
			MelodyModule.Key key = this._module.Keys[num];
			if (type.Equals(MelodyArea.TYPE.LENGTH))
			{
				if (key.Rank != MelodyModule.Key.RANK.REST)
				{
					key.Length = length;
				}
			}
			else if (type.Equals(MelodyArea.TYPE.RANK))
			{
				key.Rank = rank;
			}
			this._window.addHistory();
			this._window.updateLog("音符/休符を変更");
			base.Invalidate();
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00039454 File Offset: 0x00037654
		public void addRest(MelodyModule.Key.LENGTH length, int index = -1)
		{
			if (this._window.isMemoryOver(1))
			{
				WarningDialog warningDialog = new WarningDialog();
				warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
				warningDialog.ShowDialog();
				return;
			}
			MelodyModule.Key key = new MelodyModule.Key();
			key.Rank = MelodyModule.Key.RANK.REST;
			key.Length = length;
			if (index == -1)
			{
				this._module.addKey(key);
				this._scrollIndex = this._module.Keys.Count - 1;
				this.clearSelect();
				this._window.updateLog("音符/休符を追加");
			}
			else
			{
				this._module.Keys.Insert(index, key);
				this._scrollIndex = index;
				this._window.updateLog("音符/休符を挿入");
			}
			this._window.addHistory();
			base.Invalidate();
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x00039518 File Offset: 0x00037718
		public void changeRest(MelodyModule.Key.LENGTH length)
		{
			int num = -1;
			for (int i = 0; i < this._module.Keys.Count; i++)
			{
				if (this._module.Keys[i].Selected)
				{
					num = i;
					break;
				}
			}
			MelodyModule.Key key = this._module.Keys[num];
			key.Length = length;
			key.Rank = MelodyModule.Key.RANK.REST;
			this._window.addHistory();
			this._window.updateLog("音符/休符を変更");
			base.Invalidate();
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x000395A0 File Offset: 0x000377A0
		public void insertRest4()
		{
			int num = -1;
			for (int i = 0; i < this._module.Keys.Count; i++)
			{
				if (this._module.Keys[i].Selected)
				{
					num = i;
					this.addRest(MelodyModule.Key.LENGTH.FOUR, i);
					break;
				}
			}
			if (num != -1)
			{
				this.clearSelect();
				this._module.Keys[num].Selected = true;
			}
			base.Invalidate();
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00039618 File Offset: 0x00037818
		public void removeNote()
		{
			for (int i = this._module.Keys.Count - 1; i >= 0; i--)
			{
				if (this._module.Keys[i].Selected)
				{
					this._module.removeKey(this._module.Keys[i]);
				}
			}
			this._window.addHistory();
			this._window.updateLog("音符/休符を削除");
			base.Invalidate();
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00039698 File Offset: 0x00037898
		public void copyNote()
		{
			this._copyObject.keyList.Clear();
			foreach (MelodyModule.Key key in this._module.Keys)
			{
				if (key.Selected)
				{
					this._copyObject.keyList.Add(key);
				}
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(MelodyArea.CopyObject));
			StringBuilder stringBuilder = new StringBuilder();
			StringWriter stringWriter = new StringWriter(stringBuilder);
			xmlSerializer.Serialize(stringWriter, this._copyObject);
			stringWriter.Close();
			Console.WriteLine(stringBuilder);
			Clipboard.SetText("MelodyWindow:" + stringBuilder.ToString());
			this._window.updateLog("音符/休符をコピー");
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0003976C File Offset: 0x0003796C
		public void cutNote()
		{
			this.copyNote();
			foreach (MelodyModule.Key key in this._copyObject.keyList)
			{
				foreach (MelodyModule.Key key2 in this._module.Keys)
				{
					if (key2 == key)
					{
						this._module.removeKey(key2);
						break;
					}
				}
			}
			this._window.addHistory();
			this._window.updateLog("音符/休符を切り取り");
			base.Invalidate();
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00039838 File Offset: 0x00037A38
		public void pasteNote()
		{
			string text = Clipboard.GetText();
			if (text.StartsWith("MelodyWindow:"))
			{
				text = text.TrimStart("MelodyWindow:".ToCharArray());
				MelodyArea.CopyObject copyObject = new MelodyArea.CopyObject();
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(MelodyArea.CopyObject));
				StringReader stringReader = new StringReader(text);
				copyObject = (MelodyArea.CopyObject)xmlSerializer.Deserialize(stringReader);
				stringReader.Close();
				if (this._window.isMemoryOver(copyObject.keyList.Count))
				{
					WarningDialog warningDialog = new WarningDialog();
					warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
					warningDialog.ShowDialog();
					return;
				}
				int num = -1;
				for (int i = 0; i < this._module.Keys.Count; i++)
				{
					if (this._module.Keys[i].Selected)
					{
						num = i;
						break;
					}
				}
				foreach (MelodyModule.Key key in copyObject.keyList)
				{
					if (num == -1)
					{
						this._module.Keys.Add(key);
					}
					else
					{
						this._module.Keys.Insert(num, key);
						num++;
					}
				}
				if (num == -1)
				{
					this._scrollIndex = this._module.Keys.Count - 1;
				}
				else
				{
					this._scrollIndex = num;
				}
				this._window.addHistory();
				this._window.updateLog("音符/休符を貼り付け");
				base.Invalidate();
			}
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x000399C0 File Offset: 0x00037BC0
		private void setSelect(Rectangle rect)
		{
			int num = rect.X;
			int num2 = rect.Y;
			int num3 = rect.X + rect.Width;
			int num4 = rect.Y + rect.Height;
			if (num == 0 && num2 == 0)
			{
				return;
			}
			if (num < 0)
			{
				num = 0;
			}
			if (num3 > base.Width)
			{
				num3 = base.Width;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num4 > base.Height)
			{
				num4 = base.Height;
			}
			if (num < MelodyArea.NOTE_START_X)
			{
				if (num3 < MelodyArea.NOTE_START_X)
				{
					return;
				}
				num = MelodyArea.NOTE_START_X;
			}
			if (num3 > MelodyArea.NOTE_END_X)
			{
				if (num > MelodyArea.NOTE_END_X)
				{
					return;
				}
				num3 = MelodyArea.NOTE_END_X;
			}
			int num5 = num2 / MelodyArea.SCORE_HEIGHT + 1;
			int num6 = num4 / MelodyArea.SCORE_HEIGHT + 1;
			int num7 = 0;
			if (num >= MelodyArea.NOTE_START_X)
			{
				num7 = (num - MelodyArea.NOTE_START_X) / MelodyArea.BLOCK_WIDTH + 1;
				int num8 = MelodyArea.NOTE_START_X + num7 * MelodyArea.BLOCK_WIDTH - (MelodyArea.BLOCK_WIDTH - MelodyArea.NOTE_WIDTH);
				if (num >= num8)
				{
					num7++;
				}
				if (num7 > MelodyArea.BLOCK_SIZE_ROW)
				{
					return;
				}
			}
			int num9 = 0;
			if (num3 >= MelodyArea.NOTE_START_X)
			{
				num9 = (num3 - MelodyArea.NOTE_START_X) / MelodyArea.BLOCK_WIDTH + 1;
			}
			int num10 = MelodyArea.BLOCK_SIZE_ROW * (num5 - 1) + num7;
			int num11 = num10 + (num9 - num7);
			List<int> list = new List<int>();
			for (int i = num10; i <= num11; i++)
			{
				for (int j = num5; j <= num6; j++)
				{
					int num12 = i + (j - num5) * MelodyArea.BLOCK_SIZE_ROW;
					list.Add(num12);
				}
			}
			int num13 = -1;
			int num14 = -1;
			int num15 = 0;
			int num16 = 0;
			foreach (MelodyModule.Key key in this._module.Keys)
			{
				int blockSize = key.getBlockSize();
				int num17 = num15 + 1;
				if (num13 == -1 && list.Contains(num17))
				{
					int num18 = (num17 - 1) / MelodyArea.BLOCK_SIZE_ROW * MelodyArea.SCORE_HEIGHT + MelodyArea.SCORE_TOP_PADDING + MelodyModule.Key.adjustHeightNote(key.Rank) + MelodyArea.NOTE_HEIGHT;
					if (num2 <= num18)
					{
						num13 = num16;
					}
				}
				if (num13 != -1 && list.Contains(num17))
				{
					int num19 = (num17 - 1) / MelodyArea.BLOCK_SIZE_ROW * MelodyArea.SCORE_HEIGHT + MelodyArea.SCORE_TOP_PADDING + MelodyModule.Key.adjustHeightNote(key.Rank);
					int note_HEIGHT = MelodyArea.NOTE_HEIGHT;
					if (num4 >= num19)
					{
						num14 = num16;
					}
				}
				num15 += blockSize;
				num16++;
			}
			int firstSelectedIndex = this._firstSelectedIndex;
			this.clearSelect();
			if (num13 != -1 && num14 != -1)
			{
				if (num13 != num14)
				{
					if (this._window.isTutorial())
					{
						return;
					}
					for (int k = 0; k < this._module.Keys.Count; k++)
					{
						if (num13 <= k && k <= num14)
						{
							this._module.Keys[k].Selected = true;
						}
					}
				}
				else
				{
					if (this._window.isTutorial() && (num13 != 34 || num14 != 34))
					{
						return;
					}
					if (Control.ModifierKeys == Keys.Shift && firstSelectedIndex != -1)
					{
						int num20 = Math.Min(firstSelectedIndex, num13);
						int num21 = Math.Max(firstSelectedIndex, num13);
						for (int l = 0; l < this._module.Keys.Count; l++)
						{
							if (num20 <= l && l <= num21)
							{
								this._module.Keys[l].Selected = true;
							}
						}
					}
					else
					{
						this._module.Keys[num13].Selected = true;
						this._window.selectNote(this._module.Keys[num13].Rank);
					}
					if (this._window.isTutorial())
					{
						MelodyWindow window = this._window;
						MelodyWindow.TUTORIAL tutorial = window.Tutorial;
						window.Tutorial = tutorial + 1;
					}
				}
				this._selectRect = default(Rectangle);
				base.Invalidate();
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x00039DA4 File Offset: 0x00037FA4
		public void selectAllNote()
		{
			foreach (MelodyModule.Key key in this._module.Keys)
			{
				key.Selected = true;
			}
			base.Invalidate();
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00039E00 File Offset: 0x00038000
		public void clearSelect()
		{
			foreach (MelodyModule.Key key in this._module.Keys)
			{
				key.Selected = false;
			}
			base.Invalidate();
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00039E5C File Offset: 0x0003805C
		private void MelodyArea_MouseDown(object sender, MouseEventArgs e)
		{
			this._drag = true;
			this._selectRect.Location = e.Location;
			this._selectRect.Size = Size.Empty;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00039E88 File Offset: 0x00038088
		private void MelodyArea_MouseMove(object sender, MouseEventArgs e)
		{
			this._selectRect.Size = new Size(e.Location.X - this._selectRect.Location.X, e.Location.Y - this._selectRect.Location.Y);
			base.Invalidate();
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00039EF0 File Offset: 0x000380F0
		private void MelodyArea_MouseUp(object sender, MouseEventArgs e)
		{
			this._drag = false;
			Rectangle selectRect = this._selectRect;
			if (selectRect.Width < 0)
			{
				selectRect.X += selectRect.Width;
				selectRect.Width *= -1;
			}
			if (selectRect.Height < 0)
			{
				selectRect.Y += selectRect.Height;
				selectRect.Height *= -1;
			}
			this.setSelect(selectRect);
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x00039F6E File Offset: 0x0003816E
		private void MelodyArea_MouseEnter(object sender, EventArgs e)
		{
			base.Parent.Focus();
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00039F7C File Offset: 0x0003817C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00039F9B File Offset: 0x0003819B
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00039FA8 File Offset: 0x000381A8
		// Note: this type is marked as 'beforefieldinit'.
		static MelodyArea()
		{
			Bitmap[,,] array = new Bitmap[8, 2, 2];
			array[0, 0, 0] = new Bitmap(Resources.mld_note_010);
			array[0, 0, 1] = new Bitmap(Resources.mld_note_015);
			array[0, 1, 0] = new Bitmap(Resources.mld_note_011);
			array[0, 1, 1] = new Bitmap(Resources.mld_note_016);
			array[1, 0, 0] = new Bitmap(Resources.mld_note_020);
			array[1, 0, 1] = new Bitmap(Resources.mld_note_025);
			array[1, 1, 0] = new Bitmap(Resources.mld_note_021);
			array[1, 1, 1] = new Bitmap(Resources.mld_note_026);
			array[2, 0, 0] = new Bitmap(Resources.mld_note_030);
			array[2, 0, 1] = new Bitmap(Resources.mld_note_035);
			array[2, 1, 0] = new Bitmap(Resources.mld_note_031);
			array[2, 1, 1] = new Bitmap(Resources.mld_note_036);
			array[3, 0, 0] = new Bitmap(Resources.mld_note_040);
			array[3, 0, 1] = new Bitmap(Resources.mld_note_045);
			array[3, 1, 0] = new Bitmap(Resources.mld_note_041);
			array[3, 1, 1] = new Bitmap(Resources.mld_note_046);
			array[4, 0, 0] = new Bitmap(Resources.mld_note_050);
			array[4, 0, 1] = new Bitmap(Resources.mld_note_055);
			array[4, 1, 0] = new Bitmap(Resources.mld_note_051);
			array[4, 1, 1] = new Bitmap(Resources.mld_note_056);
			array[5, 0, 0] = new Bitmap(Resources.mld_note_060);
			array[5, 0, 1] = new Bitmap(Resources.mld_note_065);
			array[5, 1, 0] = new Bitmap(Resources.mld_note_061);
			array[5, 1, 1] = new Bitmap(Resources.mld_note_066);
			array[6, 0, 0] = new Bitmap(Resources.mld_note_070);
			array[6, 0, 1] = new Bitmap(Resources.mld_note_075);
			array[6, 1, 0] = new Bitmap(Resources.mld_note_071);
			array[6, 1, 1] = new Bitmap(Resources.mld_note_076);
			array[7, 0, 0] = new Bitmap(Resources.mld_note_080);
			array[7, 0, 1] = new Bitmap(Resources.mld_note_085);
			array[7, 1, 0] = new Bitmap(Resources.mld_note_081);
			array[7, 1, 1] = new Bitmap(Resources.mld_note_086);
			MelodyArea.NOTE_IMG_ARRAY = array;
			Bitmap[,] array2 = new Bitmap[8, 2];
			array2[0, 0] = new Bitmap(Resources.mld_note_090);
			array2[0, 1] = new Bitmap(Resources.mld_note_091);
			array2[1, 0] = new Bitmap(Resources.mld_note_100);
			array2[1, 1] = new Bitmap(Resources.mld_note_101);
			array2[3, 0] = new Bitmap(Resources.mld_note_110);
			array2[3, 1] = new Bitmap(Resources.mld_note_111);
			array2[5, 0] = new Bitmap(Resources.mld_note_120);
			array2[5, 1] = new Bitmap(Resources.mld_note_121);
			array2[7, 0] = new Bitmap(Resources.mld_note_130);
			array2[7, 1] = new Bitmap(Resources.mld_note_131);
			MelodyArea.REST_IMG_ARRAY = array2;
			MelodyArea.SHARP_IMG_ARRAY = new Bitmap[]
			{
				new Bitmap(Resources.mld_note_140),
				new Bitmap(Resources.mld_note_141)
			};
			MelodyArea.SCORE_ROW_DEFAULT = 8;
			MelodyArea.SCORE_HEIGHT = 105;
			MelodyArea.SCORE_START_X = 20;
			MelodyArea.SCORE_END_X = 960;
			MelodyArea.SCORE_TOP_PADDING = 23;
			MelodyArea.SCORE_LINE_INTERVAL = 10;
			MelodyArea.BLOCK_SIZE_ROW = 32;
			MelodyArea.BLOCK_WIDTH = 27;
			MelodyArea.NOTE_START_X = 85;
			MelodyArea.NOTE_END_X = 948;
			MelodyArea.NOTE_HEIGHT = 40;
			MelodyArea.NOTE_WIDTH = 22;
			MelodyArea.AREA_HEIGHT_DEFAULT = MelodyArea.SCORE_HEIGHT * MelodyArea.SCORE_ROW_DEFAULT;
		}

		// Token: 0x0400039D RID: 925
		private static readonly Pen PEN = new Pen(Color.FromArgb(100, 97, 54, 26), 2f);

		// Token: 0x0400039E RID: 926
		private static readonly Pen LINE_PEN = new Pen(Color.Black, 1f);

		// Token: 0x0400039F RID: 927
		private static readonly Pen LINE_PEN_SELECTED = new Pen(Color.Blue, 1f);

		// Token: 0x040003A0 RID: 928
		private static readonly Bitmap[,,] NOTE_IMG_ARRAY;

		// Token: 0x040003A1 RID: 929
		private static readonly Bitmap[,] REST_IMG_ARRAY;

		// Token: 0x040003A2 RID: 930
		private static readonly Bitmap[] SHARP_IMG_ARRAY;

		// Token: 0x040003A3 RID: 931
		public static readonly int SCORE_ROW_DEFAULT;

		// Token: 0x040003A4 RID: 932
		public static readonly int SCORE_HEIGHT;

		// Token: 0x040003A5 RID: 933
		private static readonly int SCORE_START_X;

		// Token: 0x040003A6 RID: 934
		private static readonly int SCORE_END_X;

		// Token: 0x040003A7 RID: 935
		private static readonly int SCORE_TOP_PADDING;

		// Token: 0x040003A8 RID: 936
		private static readonly int SCORE_LINE_INTERVAL;

		// Token: 0x040003A9 RID: 937
		private static readonly int BLOCK_SIZE_ROW;

		// Token: 0x040003AA RID: 938
		private static readonly int BLOCK_WIDTH;

		// Token: 0x040003AB RID: 939
		private static readonly int NOTE_START_X;

		// Token: 0x040003AC RID: 940
		private static readonly int NOTE_END_X;

		// Token: 0x040003AD RID: 941
		private static readonly int NOTE_HEIGHT;

		// Token: 0x040003AE RID: 942
		private static readonly int NOTE_WIDTH;

		// Token: 0x040003AF RID: 943
		private const string PROTOCOL = "MelodyWindow:";

		// Token: 0x040003B0 RID: 944
		private MelodyModule _module;

		// Token: 0x040003B1 RID: 945
		private MelodyWindow _window;

		// Token: 0x040003B2 RID: 946
		private bool _drag;

		// Token: 0x040003B3 RID: 947
		private int _firstSelectedIndex = -1;

		// Token: 0x040003B4 RID: 948
		private Rectangle _selectRect;

		// Token: 0x040003B6 RID: 950
		private int _scrollIndex = -1;

		// Token: 0x040003B7 RID: 951
		public static readonly int AREA_HEIGHT_DEFAULT;

		// Token: 0x040003B8 RID: 952
		private MelodyArea.CopyObject _copyObject = new MelodyArea.CopyObject();

		// Token: 0x040003B9 RID: 953
		private IContainer components;

		// Token: 0x0200009B RID: 155
		public enum TYPE
		{
			// Token: 0x04000866 RID: 2150
			RANK = 1,
			// Token: 0x04000867 RID: 2151
			LENGTH
		}

		// Token: 0x0200009C RID: 156
		public class CopyObject
		{
			// Token: 0x04000868 RID: 2152
			[XmlArrayItem(typeof(MelodyModule.Key))]
			public List<MelodyModule.Key> keyList = new List<MelodyModule.Key>();
		}
	}
}
