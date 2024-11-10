using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000020 RID: 32
	public class FlowchartArea : PictureBox
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000232 RID: 562 RVA: 0x00020517 File Offset: 0x0001E717
		public ProgramModule Program
		{
			get
			{
				return this._program;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000233 RID: 563 RVA: 0x0002051F File Offset: 0x0001E71F
		// (set) Token: 0x06000234 RID: 564 RVA: 0x00020527 File Offset: 0x0001E727
		public bool Grid
		{
			get
			{
				return this._grid;
			}
			set
			{
				this._grid = value;
				this.BackgroundImage = (value ? Resources.fc_bg_000 : null);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000235 RID: 565 RVA: 0x00020541 File Offset: 0x0001E741
		// (set) Token: 0x06000236 RID: 566 RVA: 0x00020549 File Offset: 0x0001E749
		public bool Detail
		{
			get
			{
				return this._detail;
			}
			set
			{
				this._detail = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000237 RID: 567 RVA: 0x00020552 File Offset: 0x0001E752
		// (set) Token: 0x06000238 RID: 568 RVA: 0x0002055A File Offset: 0x0001E75A
		public bool DisplayControl
		{
			get
			{
				return this._displayControl;
			}
			set
			{
				this._displayControl = value;
				if (value)
				{
					this._program.createBlockControls();
				}
				else
				{
					this._program.destroyBlockControls();
				}
				this.setProgram(this._program);
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0002058C File Offset: 0x0001E78C
		public FlowchartArea(FlowchartWindow window, ContextMenuStrip contextMenuStrip, ProgramModule program)
		{
			this.InitializeComponent();
			this._window = window;
			this.setProgram(program);
			base.Size = (this._window.IsBlockMode ? FlowchartArea.AREA_SIZE_BLOCK : FlowchartArea.AREA_SIZE);
			this.Grid = true;
			this._toolTip = new ToolTip(this.components);
			this.AllowDrop = true;
			if (!this._window.isTutorial())
			{
				this.ContextMenuStrip = contextMenuStrip;
			}
			base.DragEnter += this.FlowchartArea_DragEnter;
			base.DragDrop += this.FlowchartArea_DragDrop;
			base.MouseDown += this.FlowchartArea_MouseDown;
			base.MouseMove += this.FlowchartArea_MouseMove;
			base.MouseUp += this.FlowchartArea_MouseUp;
			base.MouseDoubleClick += this.FlowchartArea_MouseDoubleClick;
			base.MouseEnter += this.FlowchartArea_MouseEnter;
			base.MouseWheel += this.FlowchartArea_MouseWheel;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x000206CE File Offset: 0x0001E8CE
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			this.paintBlocks(pe);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000206DE File Offset: 0x0001E8DE
		public void paintBlocks(PaintEventArgs pe)
		{
			if (this._window.IsBlockMode)
			{
				this.paintBlocksBlock(pe);
				return;
			}
			this.paintBlocksFlowchart(pe);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x000206FC File Offset: 0x0001E8FC
		private void paintBlocksFlowchart(PaintEventArgs pe)
		{
			List<ProgramModule.Block> list = new List<ProgramModule.Block>();
			if (this._program.getError(this._window.Programs.Programs, false) != ProgramModule.ERROR.INFINITY)
			{
				list = this._program.getSelectLoopBlockPair();
			}
			foreach (ProgramModule.Block block in this._program.Blocks)
			{
				if (list.IndexOf(block) != -1)
				{
					block.paintRect(pe.Graphics, Color.Red, false);
				}
				block.OnPaint(pe.Graphics, this.Detail, -1, false);
			}
			if (this._dragConnectTargetBlock != null)
			{
				this._dragConnectTargetBlock.paintRect(pe.Graphics, Color.FromArgb(128, Color.White), true);
			}
			if (this._drag == FlowchartArea.DRAG.SELECT)
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
				return;
			}
			if (this._drag == FlowchartArea.DRAG.CONNECT)
			{
				Point empty = Point.Empty;
				if (this._dragConnectPoint == ProgramModule.Block.CONNECT_POINT.BOTTOM)
				{
					empty = new Point(this._dragConnectBlock.Location.X + this._dragConnectBlock.Points[(int)this._dragConnectPoint].X + ProgramModule.Block.CONNECT_POINT_SIZE / 2, this._dragConnectBlock.Location.Y + this._dragConnectBlock.Points[(int)this._dragConnectPoint].Y + ProgramModule.Block.CONNECT_POINT_SIZE);
				}
				else
				{
					empty = new Point(this._dragConnectBlock.Location.X + this._dragConnectBlock.Points[(int)this._dragConnectPoint].X + ProgramModule.Block.CONNECT_POINT_SIZE, this._dragConnectBlock.Location.Y + this._dragConnectBlock.Points[(int)this._dragConnectPoint].Y + ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				}
				ProgramModule.Block.paintArrow(pe.Graphics, empty, this._dragBefore, this._dragConnectPoint, Color.Blue);
			}
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0002097C File Offset: 0x0001EB7C
		private void paintBlocksBlock(PaintEventArgs pe)
		{
			foreach (ProgramModule.Block block in this._drawBlocks)
			{
				if (block == this._dragBlock)
				{
					if (this._drag == FlowchartArea.DRAG.BLOCK && this._connectIndex != ProgramModule.Block.CONNECT_BLOCK.INVALID)
					{
						this._connectBlock.OnPaintBlockGuide(pe.Graphics, this._connectIndex);
					}
					block.OnPaintBlock(pe.Graphics, false, -1, false);
				}
				else
				{
					block.OnPaintBlock(pe.Graphics, true, -1, !this._displayControl);
				}
			}
			foreach (ProgramModule.Block block2 in this._program.Blocks)
			{
				block2.OnPaintBlockBreakPoint(pe.Graphics);
			}
			foreach (ProgramModule.Block block3 in this._program.Blocks)
			{
				if (block3.Selected)
				{
					if (block3 is ProgramModule.BlockLabel)
					{
						foreach (ProgramModule.BlockJump blockJump in this._program.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockJump>().ToList<ProgramModule.BlockJump>())
						{
							if (blockJump.Label == block3)
							{
								blockJump.paintRectBlock(pe.Graphics, Color.Red, false);
							}
						}
					}
					block3.OnPaintBlockSelect(pe.Graphics);
					break;
				}
			}
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00020B64 File Offset: 0x0001ED64
		public void addNewBlock(ProgramModule.Block block)
		{
			if (this.DisplayControl)
			{
				foreach (Control control in block.Controls)
				{
					base.Controls.Add(control);
				}
			}
			if (block.Before == null && this._program.getParentBlock(block) == null)
			{
				this._drawBlocks.Add(block);
			}
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00020BE8 File Offset: 0x0001EDE8
		public void updateBlockControlVisible()
		{
			if (this.DisplayControl)
			{
				List<Rectangle> list = new List<Rectangle>();
				for (int i = this._drawBlocks.Count - 1; i >= 0; i--)
				{
					if (this._drawBlocks[i] == this._dragBlock)
					{
						this._drawBlocks[i].setControlVisible(false);
					}
					else
					{
						this._drawBlocks[i].updateControlVisible(list);
					}
					list.Add(new Rectangle(this._drawBlocks[i].LocationBlock, this._drawBlocks[i].getConnectedBlocksSize()));
				}
			}
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00020C88 File Offset: 0x0001EE88
		public void updateSubroutineName()
		{
			foreach (ProgramModule.BlockSubroutine blockSubroutine in this._program.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockSubroutine>().ToList<ProgramModule.BlockSubroutine>())
			{
				blockSubroutine.updateSubroutineName();
			}
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00020D0C File Offset: 0x0001EF0C
		public void updateUsbInOutEnable(bool enable)
		{
			foreach (ProgramModule.Block block in this._program.Blocks)
			{
				if (block is ProgramModule.BlockUsbOut)
				{
					((ProgramModule.BlockUsbOut)block).updateUsbInOutEnable(enable);
				}
				else if (block is ProgramModule.BlockIf)
				{
					((ProgramModule.BlockIf)block).updateUsbInOutEnable(enable);
				}
				else if (block is ProgramModule.BlockLoopStart)
				{
					((ProgramModule.BlockLoopStart)block).updateUsbInOutEnable(enable);
				}
			}
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00020DA0 File Offset: 0x0001EFA0
		public void FlowchartArea_KeyDown(KeyEventArgs e)
		{
			if (this._window.IsBlockMode)
			{
				return;
			}
			Point point = default(Point);
			if (e.KeyCode == Keys.Left)
			{
				int num = point.X;
				point.X = num - 1;
			}
			else if (e.KeyCode == Keys.Right)
			{
				int num = point.X;
				point.X = num + 1;
			}
			else if (e.KeyCode == Keys.Up)
			{
				int num = point.Y;
				point.Y = num - 1;
			}
			else if (e.KeyCode == Keys.Down)
			{
				int num = point.Y;
				point.Y = num + 1;
			}
			if (point.X != 0 || point.Y != 0)
			{
				foreach (ProgramModule.Block block in this._program.Blocks)
				{
					if (block.Selected)
					{
						block.Location = this.getEmptyPosition(this.getGridPosition(new Point(block.Location.X + point.X * 8, block.Location.Y + point.Y * 8), ProgramModule.Block.BLOCK_SIZE), block, FlowchartArea.DIRECT.RIGHT_BOTTOM);
						base.Invalidate();
						this._window.addHistory(true);
					}
				}
			}
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00020EF8 File Offset: 0x0001F0F8
		public void setProgram(ProgramModule program)
		{
			this._program = program;
			if (this._window.IsBlockMode)
			{
				this._program.updateLabels();
				base.Controls.Clear();
				if (this.DisplayControl)
				{
					foreach (ProgramModule.Block block in program.Blocks)
					{
						foreach (Control control in block.Controls)
						{
							base.Controls.Add(control);
						}
					}
				}
				this._drawBlocks.Clear();
				List<ProgramModule.BlockBranch> list = this._program.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockBranch>().ToList<ProgramModule.BlockBranch>();
				foreach (ProgramModule.Block block2 in program.Blocks)
				{
					if (block2.Before == null)
					{
						this._drawBlocks.Add(block2);
						bool flag = false;
						foreach (ProgramModule.BlockBranch blockBranch in list)
						{
							using (List<ProgramModule.Block>.Enumerator enumerator4 = blockBranch.Branches.GetEnumerator())
							{
								while (enumerator4.MoveNext())
								{
									if (enumerator4.Current == block2)
									{
										this._drawBlocks.Remove(block2);
										flag = true;
										break;
									}
								}
							}
							if (flag)
							{
								break;
							}
						}
					}
				}
				foreach (ProgramModule.Block block3 in this._drawBlocks)
				{
					block3.updateLocation(block3.LocationBlock.X);
				}
				if (this.DisplayControl)
				{
					this.updateBlockControlVisible();
				}
			}
			base.Invalidate();
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00021150 File Offset: 0x0001F350
		public void removeSelectBlocks()
		{
			List<ProgramModule.Block> list = new List<ProgramModule.Block>();
			foreach (ProgramModule.Block block in this._program.Blocks)
			{
				if (block.Selected && block.GetType() != typeof(ProgramModule.BlockEnd))
				{
					list.Add(block);
				}
			}
			if (list.Count > 0)
			{
				if (this._window.IsBlockMode)
				{
					ProgramModule.Block block2 = list[0];
					if (this._drawBlocks.Contains(block2))
					{
						this._drawBlocks.Remove(block2);
						if (block2.Next != null)
						{
							this._drawBlocks.Add(block2.Next);
						}
					}
					this.removeBlockBlock(block2);
					if (block2.Next != null)
					{
						this.setBlockSelected(block2.Next, true);
					}
				}
				else
				{
					foreach (ProgramModule.Block block3 in list)
					{
						this._program.removeBlock(block3, true);
					}
				}
				base.Invalidate();
				this._window.updateProgramTextBoxSelect();
				this._window.addHistory(true);
				this._program.updateLoopIndex();
				this._program.updateConnectState();
				this._window.updateProgram();
				this._window.updateUsedMemory();
				this._window.updateLog("ブロックを削除");
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000212E0 File Offset: 0x0001F4E0
		public void setBlockSelected(ProgramModule.Block block, bool enable)
		{
			if (enable)
			{
				if (!(block is ProgramModule.BlockStart) && (!this._window.IsBlockMode || !(block is ProgramModule.BlockEnd)))
				{
					block.Selected = enable;
					return;
				}
			}
			else
			{
				block.Selected = enable;
			}
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00021314 File Offset: 0x0001F514
		private void removeBlockBlock(ProgramModule.Block block)
		{
			foreach (Control control in block.Controls)
			{
				base.Controls.Remove(control);
			}
			this._program.removeBlockBlock(block);
			if (block is ProgramModule.BlockBranch)
			{
				foreach (ProgramModule.Block block2 in ((ProgramModule.BlockBranch)block).Branches)
				{
					if (block2 != null)
					{
						for (ProgramModule.Block block3 = block2; block3 != null; block3 = block3.Next)
						{
							this.removeBlockBlock(block3);
						}
					}
				}
			}
		}

		// Token: 0x06000247 RID: 583 RVA: 0x000213E0 File Offset: 0x0001F5E0
		public void removeSelectBlockArrows()
		{
			List<ProgramModule.Block> list = new List<ProgramModule.Block>();
			foreach (ProgramModule.Block block in this._program.Blocks)
			{
				if (block.Selected && block.GetType() != typeof(ProgramModule.BlockEnd))
				{
					list.Add(block);
				}
			}
			foreach (ProgramModule.Block block2 in list)
			{
				block2.Next = null;
				if (block2.GetType() == typeof(ProgramModule.BlockIf))
				{
					((ProgramModule.BlockIf)block2).Else = null;
				}
			}
			this._program.updateLoopIndex();
			this._program.updateConnectState();
			base.Invalidate();
			this._window.updateProgram();
			this._window.updateUsedMemory();
			this._window.addHistory(true);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x000214FC File Offset: 0x0001F6FC
		public void setSelectAll()
		{
			if (!this._window.IsBlockMode)
			{
				foreach (ProgramModule.Block block in this._program.Blocks)
				{
					this.setBlockSelected(block, true);
				}
				base.Invalidate();
				this._window.updateProgramTextBoxSelect();
			}
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00021574 File Offset: 0x0001F774
		public void clearSelect()
		{
			foreach (ProgramModule.Block block in this._program.Blocks)
			{
				this.setBlockSelected(block, false);
			}
			this._window.updateProgramTextBoxSelect();
		}

		// Token: 0x0600024A RID: 586 RVA: 0x000215D8 File Offset: 0x0001F7D8
		public void alignSelectBlocks(FlowchartArea.ALIGNMENT alignment)
		{
			List<ProgramModule.Block> list = new List<ProgramModule.Block>();
			foreach (ProgramModule.Block block in this._program.Blocks)
			{
				if (block.Selected)
				{
					list.Add(block);
				}
			}
			if (list.Count > 1)
			{
				int num = 0;
				switch (alignment)
				{
				case FlowchartArea.ALIGNMENT.LEFT:
				{
					num = list[0].Location.X;
					foreach (ProgramModule.Block block2 in list)
					{
						num = Math.Min(num, block2.Location.X);
					}
					using (List<ProgramModule.Block>.Enumerator enumerator = list.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ProgramModule.Block block3 = enumerator.Current;
							block3.Location = this.getEmptyPosition(new Point(num, block3.Location.Y), block3, FlowchartArea.DIRECT.BOTTOM);
						}
						goto IL_31F;
					}
					break;
				}
				case FlowchartArea.ALIGNMENT.RIGHT:
					break;
				case FlowchartArea.ALIGNMENT.UP:
					goto IL_1CA;
				case FlowchartArea.ALIGNMENT.BOTTOM:
					goto IL_276;
				default:
					goto IL_31F;
				}
				num = list[0].Location.X;
				foreach (ProgramModule.Block block4 in list)
				{
					num = Math.Max(num, block4.Location.X);
				}
				using (List<ProgramModule.Block>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProgramModule.Block block5 = enumerator.Current;
						block5.Location = this.getEmptyPosition(new Point(num, block5.Location.Y), block5, FlowchartArea.DIRECT.BOTTOM);
					}
					goto IL_31F;
				}
				IL_1CA:
				num = list[0].Location.Y;
				foreach (ProgramModule.Block block6 in list)
				{
					num = Math.Min(num, block6.Location.Y);
				}
				using (List<ProgramModule.Block>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProgramModule.Block block7 = enumerator.Current;
						block7.Location = this.getEmptyPosition(new Point(block7.Location.X, num), block7, FlowchartArea.DIRECT.RIGHT);
					}
					goto IL_31F;
				}
				IL_276:
				num = list[0].Location.Y;
				foreach (ProgramModule.Block block8 in list)
				{
					num = Math.Max(num, block8.Location.Y);
				}
				foreach (ProgramModule.Block block9 in list)
				{
					block9.Location = this.getEmptyPosition(new Point(block9.Location.X, num), block9, FlowchartArea.DIRECT.RIGHT);
				}
				IL_31F:
				this._window.addHistory(true);
				this._window.updateLog("ブロックを整列");
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00021990 File Offset: 0x0001FB90
		public Point getEmptyPosition(Point position, ProgramModule.Block ignoreBlock = null, FlowchartArea.DIRECT direct = FlowchartArea.DIRECT.RIGHT_BOTTOM)
		{
			if (position.X > base.Size.Width || position.Y > base.Size.Height)
			{
				return Point.Empty;
			}
			if (this._window.IsBlockMode)
			{
				using (List<ProgramModule.Block>.Enumerator enumerator = this._program.Blocks.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProgramModule.Block block = enumerator.Current;
						if (block != ignoreBlock && block.LocationBlock == position)
						{
							switch (direct)
							{
							case FlowchartArea.DIRECT.RIGHT:
								return this.getEmptyPosition(new Point(position.X + 8, position.Y), ignoreBlock, direct);
							case FlowchartArea.DIRECT.BOTTOM:
								return this.getEmptyPosition(new Point(position.X, position.Y + 8), ignoreBlock, direct);
							case FlowchartArea.DIRECT.RIGHT_BOTTOM:
								return this.getEmptyPosition(new Point(position.X + 8, position.Y + 8), ignoreBlock, direct);
							}
						}
					}
					return position;
				}
			}
			foreach (ProgramModule.Block block2 in this._program.Blocks)
			{
				if (block2 != ignoreBlock && block2.Location == position)
				{
					switch (direct)
					{
					case FlowchartArea.DIRECT.RIGHT:
						return this.getEmptyPosition(new Point(position.X + 8, position.Y), ignoreBlock, direct);
					case FlowchartArea.DIRECT.BOTTOM:
						return this.getEmptyPosition(new Point(position.X, position.Y + 8), ignoreBlock, direct);
					case FlowchartArea.DIRECT.RIGHT_BOTTOM:
						return this.getEmptyPosition(new Point(position.X + 8, position.Y + 8), ignoreBlock, direct);
					}
				}
			}
			return position;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00021B9C File Offset: 0x0001FD9C
		public Rectangle getReportRect()
		{
			Rectangle rectangle = default(Rectangle);
			if (this._window.IsBlockMode)
			{
				rectangle.X = base.Width;
				rectangle.Y = base.Height;
				foreach (ProgramModule.Block block in this._program.Blocks)
				{
					rectangle.X = Math.Min(rectangle.X, block.LocationBlock.X);
					rectangle.Y = Math.Min(rectangle.Y, block.LocationBlock.Y);
					rectangle.Width = Math.Max(rectangle.Width, block.LocationBlock.X + block.SizeBlock.Width + 20);
					rectangle.Height = Math.Max(rectangle.Height, block.LocationBlock.Y + block.SizeBlock.Height + 70);
				}
				rectangle.X = Math.Max(0, rectangle.X - 20);
				rectangle.Y = Math.Max(0, rectangle.Y - 70);
				rectangle.Width -= rectangle.X;
				rectangle.Height -= rectangle.Y;
			}
			else
			{
				foreach (ProgramModule.Block block2 in this._program.Blocks)
				{
					rectangle.Width = Math.Max(rectangle.Width, block2.Location.X);
					rectangle.Height = Math.Max(rectangle.Height, block2.Location.Y);
				}
				rectangle.Width += ProgramModule.Block.BLOCK_SIZE.Width + 20;
				rectangle.Height += ProgramModule.Block.BLOCK_SIZE.Height + 70;
			}
			return rectangle;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00021DE8 File Offset: 0x0001FFE8
		private void FlowchartArea_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00021E03 File Offset: 0x00020003
		private void FlowchartArea_DragDrop(object sender, DragEventArgs e)
		{
			if (this._window.IsBlockMode)
			{
				this.DragDropBlock(e);
				return;
			}
			this.DragDropFlowchart(e);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00021E24 File Offset: 0x00020024
		private void DragDropFlowchart(DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				string text = e.Data.GetData(DataFormats.Text).ToString();
				ProgramModule.Block block = null;
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
				if (num <= 1897110529U)
				{
					if (num <= 1061176027U)
					{
						if (num != 80939203U)
						{
							if (num == 1061176027U)
							{
								if (text == "USBOUT")
								{
									block = new ProgramModule.BlockUsbOut();
								}
							}
						}
						else if (text == "COUNTER")
						{
							block = new ProgramModule.BlockCounter();
						}
					}
					else if (num != 1062884307U)
					{
						if (num != 1491660422U)
						{
							if (num == 1897110529U)
							{
								if (text == "ARITHMETIC")
								{
									block = new ProgramModule.BlockArithmetic();
								}
							}
						}
						else if (text == "IF")
						{
							block = new ProgramModule.BlockIf();
						}
					}
					else if (text == "SUBROUTINE")
					{
						block = new ProgramModule.BlockSubroutine();
					}
				}
				else if (num <= 3061266164U)
				{
					if (num != 2393865632U)
					{
						if (num != 2442931280U)
						{
							if (num == 3061266164U)
							{
								if (text == "SOUND")
								{
									block = new ProgramModule.BlockSound();
								}
							}
						}
						else if (text == "LOOP_START")
						{
							block = new ProgramModule.BlockLoopStart();
						}
					}
					else if (text == "WAIT")
					{
						block = new ProgramModule.BlockWait();
					}
				}
				else if (num != 3276105386U)
				{
					if (num != 3529180305U)
					{
						if (num == 4165932597U)
						{
							if (text == "DISPLAY")
							{
								block = new ProgramModule.BlockDisplay();
							}
						}
					}
					else if (text == "LOOP_END")
					{
						block = new ProgramModule.BlockLoopEnd();
					}
				}
				else if (text == "LED")
				{
					block = new ProgramModule.BlockLED();
				}
				if (block != null)
				{
					block.Location = this.getEmptyPosition(this.getGridPosition(base.PointToClient(new Point(e.X - Resources.fc_block_000.Width / 2, e.Y - Resources.fc_block_000.Height / 2)), ProgramModule.Block.BLOCK_SIZE), null, FlowchartArea.DIRECT.RIGHT_BOTTOM);
					this._program.addBlock(block);
					this._window.updateProgramTextBoxSelect();
					this._window.addHistory(true);
					this._window.updateLog("ブロックを追加");
					if (this._window.isTutorial())
					{
						FlowchartWindow window = this._window;
						FlowchartWindow.TUTORIAL tutorial = window.Tutorial;
						window.Tutorial = tutorial + 1;
					}
				}
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x000220C4 File Offset: 0x000202C4
		private void DragDropBlock(DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				string text = e.Data.GetData(DataFormats.Text).ToString();
				ProgramModule.Block block = null;
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
				if (num <= 1625091293U)
				{
					if (num <= 1062884307U)
					{
						if (num != 80939203U)
						{
							if (num != 1061176027U)
							{
								if (num == 1062884307U)
								{
									if (text == "SUBROUTINE")
									{
										block = new ProgramModule.BlockSubroutine();
									}
								}
							}
							else if (text == "USBOUT")
							{
								block = new ProgramModule.BlockUsbOut();
							}
						}
						else if (text == "COUNTER")
						{
							block = new ProgramModule.BlockCounter();
						}
					}
					else if (num != 1348155789U)
					{
						if (num != 1491660422U)
						{
							if (num == 1625091293U)
							{
								if (text == "LABEL")
								{
									block = new ProgramModule.BlockLabel();
								}
							}
						}
						else if (text == "IF")
						{
							block = new ProgramModule.BlockIf(1);
						}
					}
					else if (text == "JUMP")
					{
						block = new ProgramModule.BlockJump();
					}
				}
				else if (num <= 2442931280U)
				{
					if (num != 1897110529U)
					{
						if (num != 2393865632U)
						{
							if (num == 2442931280U)
							{
								if (text == "LOOP_START")
								{
									block = new ProgramModule.BlockLoopStart(1);
								}
							}
						}
						else if (text == "WAIT")
						{
							block = new ProgramModule.BlockWait();
						}
					}
					else if (text == "ARITHMETIC")
					{
						block = new ProgramModule.BlockArithmetic();
					}
				}
				else if (num <= 3175886770U)
				{
					if (num != 3061266164U)
					{
						if (num == 3175886770U)
						{
							if (text == "IF_ELSE")
							{
								block = new ProgramModule.BlockIf(2);
							}
						}
					}
					else if (text == "SOUND")
					{
						block = new ProgramModule.BlockSound();
					}
				}
				else if (num != 3276105386U)
				{
					if (num == 4165932597U)
					{
						if (text == "DISPLAY")
						{
							block = new ProgramModule.BlockDisplay();
						}
					}
				}
				else if (text == "LED")
				{
					block = new ProgramModule.BlockLED();
				}
				if (block != null)
				{
					if (this.DisplayControl)
					{
						block.createBlockControls();
						if (this._window.isTutorial())
						{
							block.disableControls();
						}
						using (List<Control>.Enumerator enumerator = block.Controls.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								Control control = enumerator.Current;
								base.Controls.Add(control);
							}
							goto IL_2C5;
						}
					}
					block.updateBlock();
					IL_2C5:
					block.LocationBlock = this.getAreaPosition(base.PointToClient(new Point(e.X - Resources.fc_block_000.Width / 2, e.Y - Resources.fc_block_000.Height / 2)), block.SizeBlock);
					block.updateLocation(block.LocationBlock.X);
					this._drawBlocks.Add(block);
					this._program.addBlock(block);
					if (block is ProgramModule.BlockLabel)
					{
						this._program.updateLabels();
					}
					this._window.updateProgramTextBoxSelect();
					this._window.addHistory(true);
					this._window.updateLog("ブロックを追加");
					if (this._window.isTutorial())
					{
						FlowchartWindow window = this._window;
						FlowchartWindow.TUTORIAL tutorial = window.Tutorial;
						window.Tutorial = tutorial + 1;
					}
					if (this.DisplayControl)
					{
						this.updateBlockControlVisible();
					}
					this.Refresh();
				}
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00022488 File Offset: 0x00020688
		private void FlowchartArea_MouseDown(object sender, MouseEventArgs e)
		{
			if (this._window.IsBlockMode)
			{
				this.MouseDownBlock(e);
				return;
			}
			this.MouseDownFlowchart(e);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000224A8 File Offset: 0x000206A8
		private void MouseDownFlowchart(MouseEventArgs e)
		{
			if (this._window.isTutorial() && this._window.Tutorial != FlowchartWindow.TUTORIAL.CONNECT_LED && this._window.Tutorial != FlowchartWindow.TUTORIAL.CONNECT_SOUND)
			{
				return;
			}
			if ((Control.ModifierKeys & Keys.Control) == Keys.Control && e.Button == MouseButtons.Left)
			{
				for (int i = this._program.Blocks.Count - 1; i >= 0; i--)
				{
					ProgramModule.Block block = this._program.Blocks[i];
					if (block.isIncluding(e.Location) && block.GetType() != typeof(ProgramModule.BlockStart) && block.GetType() != typeof(ProgramModule.BlockEnd))
					{
						block.BreakPoint = !block.BreakPoint;
						this._window.updateLog("ブレークポイントを設定");
						return;
					}
				}
				return;
			}
			int j = this._program.Blocks.Count - 1;
			while (j >= 0)
			{
				ProgramModule.Block block2 = this._program.Blocks[j];
				if (block2.isIncluding(e.Location))
				{
					this._dragConnectPoint = block2.isIncludingConnectPoint(e.Location);
					if (this._dragConnectPoint != ProgramModule.Block.CONNECT_POINT.NONE && e.Button == MouseButtons.Left)
					{
						this._drag = FlowchartArea.DRAG.CONNECT;
						this.clearSelect();
						this.setBlockSelected(block2, true);
						this._dragConnectBlock = block2;
						if (this._dragConnectPoint == ProgramModule.Block.CONNECT_POINT.BOTTOM)
						{
							block2.Next = null;
							break;
						}
						if (this._dragConnectPoint == ProgramModule.Block.CONNECT_POINT.RIGHT)
						{
							((ProgramModule.BlockIf)block2).Else = null;
							break;
						}
						break;
					}
					else
					{
						this._drag = FlowchartArea.DRAG.BLOCK;
						this._dragBefore = e.Location;
						if (!block2.Selected)
						{
							this.clearSelect();
							this.setBlockSelected(block2, true);
							break;
						}
						break;
					}
				}
				else
				{
					j--;
				}
			}
			this._window.updateProgramTextBoxSelect();
			if (this._drag == FlowchartArea.DRAG.NONE)
			{
				this.clearSelect();
				base.Invalidate();
				if (e.Button == MouseButtons.Left)
				{
					this._drag = FlowchartArea.DRAG.SELECT;
					this._selectRect.Location = e.Location;
					this._selectRect.Size = Size.Empty;
				}
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x000226C4 File Offset: 0x000208C4
		private void MouseDownBlock(MouseEventArgs e)
		{
			if (this._window.isTutorial() && this._window.Tutorial != FlowchartWindow.TUTORIAL.CONNECT_LED && this._window.Tutorial != FlowchartWindow.TUTORIAL.CONNECT_SOUND)
			{
				return;
			}
			if ((Control.ModifierKeys & Keys.Control) == Keys.Control && e.Button == MouseButtons.Left)
			{
				for (int i = this._program.Blocks.Count - 1; i >= 0; i--)
				{
					ProgramModule.Block block = this._program.Blocks[i];
					if (block.isIncludingBlock(e.Location) && !(block is ProgramModule.BlockStart) && !(block is ProgramModule.BlockEnd))
					{
						block.BreakPoint = !block.BreakPoint;
						this._window.updateLog("ブレークポイントを設定");
						return;
					}
				}
				return;
			}
			int j = this._program.Blocks.Count - 1;
			while (j >= 0)
			{
				ProgramModule.Block block2 = this._program.Blocks[j];
				if (block2.isIncludingBlock(e.Location))
				{
					this._drag = FlowchartArea.DRAG.BLOCK;
					this._dragBefore = (this._dragPoint = e.Location);
					this._dragBlock = block2;
					if (!block2.Selected)
					{
						this.clearSelect();
						this.setBlockSelected(block2, true);
						break;
					}
					break;
				}
				else
				{
					j--;
				}
			}
			this._window.updateProgramTextBoxSelect();
			if (this._drag == FlowchartArea.DRAG.NONE)
			{
				this.clearSelect();
				base.Invalidate();
				if (e.Button == MouseButtons.Left)
				{
					this._drag = FlowchartArea.DRAG.SELECT;
					this._selectRect.Location = e.Location;
					this._selectRect.Size = Size.Empty;
				}
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00022857 File Offset: 0x00020A57
		private void FlowchartArea_MouseMove(object sender, MouseEventArgs e)
		{
			if (this._window.IsBlockMode)
			{
				this.MouseMoveBlock(e);
				return;
			}
			this.MouseMoveFlowchart(e);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00022878 File Offset: 0x00020A78
		private void MouseMoveFlowchart(MouseEventArgs e)
		{
			if (this._drag == FlowchartArea.DRAG.SELECT)
			{
				this._selectRect.Size = new Size(e.Location.X - this._selectRect.Location.X, e.Location.Y - this._selectRect.Location.Y);
				this.scrollScreen(e.Location);
			}
			else if (this._drag == FlowchartArea.DRAG.BLOCK)
			{
				Point point = new Point(e.Location.X - this._dragBefore.X, e.Location.Y - this._dragBefore.Y);
				Point point2 = default(Point);
				foreach (ProgramModule.Block block in this._program.Blocks)
				{
					if (block.Selected)
					{
						point2.X = block.Location.X + point.X;
						point2.Y = block.Location.Y + point.Y;
						block.Location = point2;
					}
				}
				this.scrollScreen(e.Location);
			}
			else if (this._drag == FlowchartArea.DRAG.CONNECT)
			{
				this._dragConnectTargetBlock = null;
				foreach (ProgramModule.Block block2 in this._program.Blocks)
				{
					if (block2.isIncluding(e.Location) && block2.isConnectable(this._dragConnectBlock))
					{
						this._dragConnectTargetBlock = block2;
						break;
					}
				}
				this.scrollScreen(e.Location);
			}
			else
			{
				ProgramModule.Block block3 = null;
				foreach (ProgramModule.Block block4 in this._program.Blocks)
				{
					if (block4 != this._dragConnectBlock && block4.GetType() != typeof(ProgramModule.BlockStart) && block4.isIncluding(e.Location))
					{
						block3 = block4;
						break;
					}
				}
				if (block3 != null)
				{
					if (!this._toolTipEnable)
					{
						this._toolTip.Show(block3.getDetail(), this);
						this._toolTipEnable = true;
						if (block3.GetType() == typeof(ProgramModule.BlockIf))
						{
							int i = this._program.Blocks.Count - 1;
							while (i >= 0)
							{
								ProgramModule.Block block5 = this._program.Blocks[i];
								if (block5.isIncluding(e.Location))
								{
									this._dragConnectPoint = block5.isIncludingConnectPoint(e.Location);
									if (this._dragConnectPoint == ProgramModule.Block.CONNECT_POINT.BOTTOM)
									{
										this._toolTip.Show("YES", this);
										this._toolTipEnable = true;
										break;
									}
									if (this._dragConnectPoint == ProgramModule.Block.CONNECT_POINT.RIGHT)
									{
										this._toolTip.Show("NO", this);
										this._toolTipEnable = true;
										break;
									}
									break;
								}
								else
								{
									i--;
								}
							}
						}
					}
				}
				else
				{
					this._toolTip.Hide(this);
					this._toolTipEnable = false;
				}
			}
			this._dragBefore = e.Location;
			base.Invalidate();
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00022BFC File Offset: 0x00020DFC
		private void MouseMoveBlock(MouseEventArgs e)
		{
			if (this._drag == FlowchartArea.DRAG.SELECT)
			{
				this.scrollScreen(e.Location);
			}
			else if (this._drag == FlowchartArea.DRAG.BLOCK && !(this._dragBlock is ProgramModule.BlockEnd))
			{
				Point point = new Point(e.Location.X - this._dragBefore.X, e.Location.Y - this._dragBefore.Y);
				this._dragBlock.LocationBlock = this.getAreaPosition(new Point(this._dragBlock.LocationBlock.X + point.X, this._dragBlock.LocationBlock.Y + point.Y), this._dragBlock.SizeBlock);
				this._dragBlock.updateLocation(this._dragBlock.LocationBlock.X);
				this.scrollScreen(e.Location);
				if (this._dragPoint != Point.Empty)
				{
					this._dragPoint = Point.Empty;
					List<ProgramModule.BlockBranch> list = this._program.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockBranch>().ToList<ProgramModule.BlockBranch>();
					if (this._dragBlock.Before != null)
					{
						ProgramModule.Block before = this._dragBlock.Before;
						ProgramModule.Block last = this._dragBlock.Last;
						before.SetNextBlock(null);
						if (last is ProgramModule.BlockEnd)
						{
							last.Before.SetNextBlock(null);
							before.SetNextBlock(last);
						}
						ProgramModule.Block topBlock = this._program.getTopBlock(before.First, list);
						topBlock.updateLocation(topBlock.LocationBlock.X);
					}
					else
					{
						foreach (ProgramModule.BlockBranch blockBranch in list)
						{
							for (int i = 0; i < blockBranch.Branches.Count; i++)
							{
								if (blockBranch.Branches[i] == this._dragBlock)
								{
									blockBranch.SetBranch((ProgramModule.Block.CONNECT_BLOCK)i, null);
									ProgramModule.Block topBlock2 = this._program.getTopBlock(blockBranch.First, list);
									topBlock2.updateLocation(topBlock2.LocationBlock.X);
									break;
								}
							}
						}
					}
					if (this._drawBlocks.Contains(this._dragBlock))
					{
						this._drawBlocks.Remove(this._dragBlock);
					}
					this._drawBlocks.Add(this._dragBlock);
				}
				else
				{
					bool flag = false;
					this._connectIndex = ProgramModule.Block.CONNECT_BLOCK.INVALID;
					List<ProgramModule.Block> list2 = new List<ProgramModule.Block>();
					this._dragBlock.getBlockList(list2);
					IEnumerable<ProgramModule.Block> enumerable = this._program.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.Block>().Except(list2);
					foreach (ProgramModule.Block block in enumerable)
					{
						ProgramModule.Block.CONNECT_BLOCK connect_BLOCK = block.IsHit(this._dragBlock);
						if (!(block is ProgramModule.BlockEnd) && !(this._dragBlock is ProgramModule.BlockStart) && connect_BLOCK == ProgramModule.Block.CONNECT_BLOCK.DOWN)
						{
							this._connectBlock = block;
							this._connectIndex = connect_BLOCK;
							flag = true;
							break;
						}
						if (connect_BLOCK == ProgramModule.Block.CONNECT_BLOCK.BRANCH_FIRST || connect_BLOCK == ProgramModule.Block.CONNECT_BLOCK.BRANCH_SECOND)
						{
							this._connectBlock = block;
							this._connectIndex = connect_BLOCK;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						foreach (ProgramModule.Block block2 in enumerable)
						{
							ProgramModule.Block last2 = this._dragBlock.Last;
							if (block2.Before == null && !(last2 is ProgramModule.BlockEnd) && !(block2 is ProgramModule.BlockStart) && block2.IsHit(last2) == ProgramModule.Block.CONNECT_BLOCK.UP)
							{
								this._connectBlock = block2;
								this._connectIndex = ProgramModule.Block.CONNECT_BLOCK.UP;
								break;
							}
						}
					}
				}
				this._dragBefore = e.Location;
				if (this.DisplayControl)
				{
					this.updateBlockControlVisible();
				}
			}
			base.Invalidate();
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00023034 File Offset: 0x00021234
		private void FlowchartArea_MouseUp(object sender, MouseEventArgs e)
		{
			if (this._window.IsBlockMode)
			{
				this.MouseUpBlock(e);
				return;
			}
			this.MouseUpFlowchart(e);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00023054 File Offset: 0x00021254
		private void MouseUpFlowchart(MouseEventArgs e)
		{
			if (this._drag == FlowchartArea.DRAG.SELECT)
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
				this.setSelect(selectRect);
			}
			else if (this._drag == FlowchartArea.DRAG.CONNECT)
			{
				foreach (ProgramModule.Block block in this._program.Blocks)
				{
					if (block.isIncluding(e.Location))
					{
						if (this._dragConnectBlock == null || !block.isConnectable(this._dragConnectBlock))
						{
							break;
						}
						this._dragConnectBlock.setConnect(this._dragConnectPoint, block);
						this._program.updateConnectState();
						if (this._window.Programs.getUsedMemory(ProgramModules.ROUTINE.MAIN, true) > 256)
						{
							WarningDialog warningDialog = new WarningDialog();
							warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
							warningDialog.ShowDialog();
							this._dragConnectBlock.setConnect(this._dragConnectPoint, null);
							break;
						}
						this._window.updateLog("ブロックを接続");
						if (!this._window.isTutorial())
						{
							break;
						}
						if (this._window.Tutorial == FlowchartWindow.TUTORIAL.CONNECT_LED)
						{
							if (this._window.Programs.getError(false) == ProgramModule.ERROR.NONE && this._window.Programs.Programs[0].getConnectBlocks(this._window.IsBlockMode).Count == 3)
							{
								FlowchartWindow window = this._window;
								FlowchartWindow.TUTORIAL tutorial = window.Tutorial;
								window.Tutorial = tutorial + 1;
								break;
							}
							break;
						}
						else
						{
							if (this._window.Tutorial == FlowchartWindow.TUTORIAL.CONNECT_SOUND && this._window.Programs.getError(false) == ProgramModule.ERROR.NONE && this._window.Programs.Programs[0].getConnectBlocks(this._window.IsBlockMode).Count == 4 && this._window.Programs.Programs[0].Start.Next.GetType() == typeof(ProgramModule.BlockLED))
							{
								FlowchartWindow window2 = this._window;
								FlowchartWindow.TUTORIAL tutorial = window2.Tutorial;
								window2.Tutorial = tutorial + 1;
								break;
							}
							break;
						}
					}
				}
				this._dragConnectBlock = null;
				this._dragConnectTargetBlock = null;
				this._program.updateLoopIndex();
				this._program.updateConnectState();
				this._window.updateUsedMemory();
				this._window.updateProgram();
				this._window.addHistory(true);
				base.Invalidate();
			}
			else if (this._drag == FlowchartArea.DRAG.BLOCK)
			{
				bool flag = false;
				foreach (ProgramModule.Block block2 in this._program.Blocks)
				{
					if (block2.Selected)
					{
						Point emptyPosition = this.getEmptyPosition(this.getGridPosition(block2.Location, ProgramModule.Block.BLOCK_SIZE), block2, FlowchartArea.DIRECT.RIGHT_BOTTOM);
						if (block2.Location != emptyPosition)
						{
							block2.Location = emptyPosition;
							flag = true;
						}
					}
				}
				if (flag)
				{
					base.Invalidate();
					this._window.addHistory(true);
					this._window.updateLog("ブロックを移動");
				}
			}
			this._drag = FlowchartArea.DRAG.NONE;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00023410 File Offset: 0x00021610
		private void MouseUpBlock(MouseEventArgs e)
		{
			if (this._drag == FlowchartArea.DRAG.BLOCK && this._dragPoint == Point.Empty)
			{
				List<ProgramModule.Block> list = new List<ProgramModule.Block>();
				this._dragBlock.getBlockList(list);
				IEnumerable<ProgramModule.Block> enumerable = this._program.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.Block>().Except(list);
				if (this._connectIndex == ProgramModule.Block.CONNECT_BLOCK.DOWN)
				{
					this._window.addHistory(true);
					this._connectBlock.SetNextBlock(this._dragBlock);
					if (this._window.Programs.getUsedMemory(ProgramModules.ROUTINE.MAIN, true) > 256)
					{
						WarningDialog warningDialog = new WarningDialog();
						warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
						warningDialog.ShowDialog();
						this._window.undo();
					}
					else
					{
						ProgramModule.Block topBlock = this._program.getTopBlock(this._connectBlock.First, enumerable.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockBranch>().ToList<ProgramModule.BlockBranch>());
						topBlock.updateLocation(topBlock.LocationBlock.X);
						this._drawBlocks.Remove(this._dragBlock);
						this._window.removeHistory();
					}
				}
				else if (this._connectIndex == ProgramModule.Block.CONNECT_BLOCK.BRANCH_FIRST || this._connectIndex == ProgramModule.Block.CONNECT_BLOCK.BRANCH_SECOND)
				{
					ProgramModule.BlockBranch blockBranch = (ProgramModule.BlockBranch)this._connectBlock;
					if (blockBranch.Branches[(int)this._connectIndex] != null)
					{
						this._dragBlock.Last.SetNextBlock(blockBranch.Branches[(int)this._connectIndex]);
					}
					blockBranch.SetBranch(this._connectIndex, this._dragBlock);
					if (this._window.Programs.getUsedMemory(ProgramModules.ROUTINE.MAIN, true) > 256)
					{
						WarningDialog warningDialog2 = new WarningDialog();
						warningDialog2.setText(ProgramModule.ERROR_ITEMS[5]);
						warningDialog2.ShowDialog();
						this._window.undo();
					}
					else
					{
						ProgramModule.Block topBlock2 = this._program.getTopBlock(this._connectBlock.First, enumerable.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockBranch>().ToList<ProgramModule.BlockBranch>());
						topBlock2.updateLocation(topBlock2.LocationBlock.X);
						this._drawBlocks.Remove(this._dragBlock);
						this._window.removeHistory();
					}
				}
				else if (this._connectIndex == ProgramModule.Block.CONNECT_BLOCK.UP)
				{
					this._dragBlock.Last.SetNextBlock(this._connectBlock);
					if (this._window.Programs.getUsedMemory(ProgramModules.ROUTINE.MAIN, true) > 256)
					{
						WarningDialog warningDialog3 = new WarningDialog();
						warningDialog3.setText(ProgramModule.ERROR_ITEMS[5]);
						warningDialog3.ShowDialog();
						this._window.undo();
					}
					else
					{
						this._dragBlock.updateLocation(this._dragBlock.LocationBlock.X);
						this._drawBlocks.Remove(this._connectBlock);
						this._window.removeHistory();
					}
				}
				this._program.updateConnectState();
				this._window.updateUsedMemory();
				this._window.addHistory(true);
				this._window.updateLog("ブロックを移動");
				if (this._window.isTutorial() && this._connectIndex != ProgramModule.Block.CONNECT_BLOCK.INVALID)
				{
					if (this._window.Tutorial == FlowchartWindow.TUTORIAL.CONNECT_SOUND)
					{
						if (this._program.Start.Next is ProgramModule.BlockLED && this._program.End.Before is ProgramModule.BlockSound)
						{
							FlowchartWindow window = this._window;
							FlowchartWindow.TUTORIAL tutorial = window.Tutorial;
							window.Tutorial = tutorial + 1;
						}
					}
					else
					{
						FlowchartWindow window2 = this._window;
						FlowchartWindow.TUTORIAL tutorial = window2.Tutorial;
						window2.Tutorial = tutorial + 1;
					}
				}
			}
			this._dragBlock = null;
			this._drag = FlowchartArea.DRAG.NONE;
			if (this.DisplayControl)
			{
				this.updateBlockControlVisible();
			}
			this.Refresh();
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00023804 File Offset: 0x00021A04
		private void FlowchartArea_MouseWheel(object sender, MouseEventArgs e)
		{
			VScrollProperties verticalScroll = ((SplitterPanel)base.Parent).VerticalScroll;
			int num = Math.Min(verticalScroll.Maximum, verticalScroll.Value - e.Delta);
			num = Math.Max(verticalScroll.Minimum, num);
			verticalScroll.Value = num;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0002384F File Offset: 0x00021A4F
		private void FlowchartArea_MouseEnter(object sender, EventArgs e)
		{
			if (Form.ActiveForm == this._window)
			{
				base.Parent.Focus();
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0002386A File Offset: 0x00021A6A
		private void FlowchartArea_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._window.IsBlockMode)
			{
				this.MouseDoubleClickBlock(e);
				return;
			}
			this.MouseDoubleClickFlowchart(e);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00023888 File Offset: 0x00021A88
		private void MouseDoubleClickFlowchart(MouseEventArgs e)
		{
			if (this._window.isTutorial() && this._window.Tutorial != FlowchartWindow.TUTORIAL.DOUBLE_CLICK)
			{
				return;
			}
			if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
			{
				int i = this._program.Blocks.Count - 1;
				while (i >= 0)
				{
					ProgramModule.Block block = this._program.Blocks[i];
					if (block.isIncluding(e.Location))
					{
						Form form = null;
						int num = 999;
						if (block.ConnectState == ProgramModule.Block.CONNECT_STATE.RIGHT)
						{
							List<int> list = new List<int>();
							this._window.Programs.getSubroutineIndexes(ProgramModules.ROUTINE.MAIN, list);
							if (this._window.RoutineIndex == ProgramModules.ROUTINE.MAIN || list.IndexOf(this._window.RoutineIndex - ProgramModules.ROUTINE.SUB_1) >= 0)
							{
								num = 256 - this._window.Programs.getUsedMemory(ProgramModules.ROUTINE.MAIN, true) + block.getUsedMemory();
							}
						}
						if (block.GetType() == typeof(ProgramModule.BlockLED))
						{
							form = new BlockPropertyLEDDialog((ProgramModule.BlockLED)block, num, this._window.isTutorial());
						}
						else if (block.GetType() == typeof(ProgramModule.BlockSound))
						{
							form = new BlockPropertySoundDialog((ProgramModule.BlockSound)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockWait))
						{
							form = new BlockPropertyWaitDialog((ProgramModule.BlockWait)block, num, false);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
						{
							form = new BlockPropertyLoopDialog((ProgramModule.BlockLoopStart)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockLoopEnd))
						{
							if (this._window.IsUsbInOutEnable || ((ProgramModule.BlockLoopEnd)block).Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX)
							{
								form = new BlockPropertyLoopEndDialog((ProgramModule.BlockLoopEnd)block, num, this._window.RunningFlag);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockIf))
						{
							if (this._window.IsUsbInOutEnable || ((ProgramModule.BlockIf)block).Condition != ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX)
							{
								form = new BlockPropertyIfDialog((ProgramModule.BlockIf)block, num, this._window.RunningFlag);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockArithmetic))
						{
							form = new BlockPropertyArithmeticDialog((ProgramModule.BlockArithmetic)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockCounter))
						{
							form = new BlockPropertyCounterDialog((ProgramModule.BlockCounter)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockSubroutine))
						{
							form = new BlockPropertySubroutineDialog((ProgramModule.BlockSubroutine)block, this._window.Programs, FlowchartWindow.getSubroutineNames());
						}
						else if (block.GetType() == typeof(ProgramModule.BlockDisplay))
						{
							form = new BlockPropertyDisplayDialog((ProgramModule.BlockDisplay)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockUsbOut) && this._window.IsUsbInOutEnable)
						{
							form = new BlockPropertyUsbOutDialog((ProgramModule.BlockUsbOut)block, num, false);
						}
						if (form == null)
						{
							break;
						}
						form.StartPosition = FormStartPosition.Manual;
						form.DesktopLocation = base.Parent.PointToScreen(new Point(base.Parent.Location.X + 20, base.Parent.Location.Y + 20));
						if (this._window.isTutorial() && this._window.Tutorial == FlowchartWindow.TUTORIAL.DOUBLE_CLICK)
						{
							FlowchartWindow window = this._window;
							FlowchartWindow.TUTORIAL tutorial = window.Tutorial;
							window.Tutorial = tutorial + 1;
						}
						form.ShowDialog();
						if (this._window.isTutorial())
						{
							FlowchartWindow window2 = this._window;
							FlowchartWindow.TUTORIAL tutorial = window2.Tutorial;
							window2.Tutorial = tutorial + 1;
						}
						if (!block.Updated)
						{
							break;
						}
						block.Updated = false;
						this._window.updateProgram();
						this._window.updateUsedMemory();
						this._window.addHistory(true);
						if (block.GetType() == typeof(ProgramModule.BlockLED))
						{
							this._window.updateLog("LEDブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockSound))
						{
							this._window.updateLog("サウンドブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockWait))
						{
							this._window.updateLog("ウェイトブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
						{
							this._window.updateLog("ループ開始ブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockLoopEnd))
						{
							this._window.updateLog("ループ終了ブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockIf))
						{
							this._window.updateLog("分岐ブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockArithmetic))
						{
							this._window.updateLog("演算ブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockCounter))
						{
							this._window.updateLog("秒カウンタブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockSubroutine))
						{
							this._window.updateLog("サブルーチンブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockDisplay))
						{
							this._window.updateLog("表示ブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockUsbOut))
						{
							this._window.updateLog("外部出力ブロックの設定を変更");
							return;
						}
						break;
					}
					else
					{
						i--;
					}
				}
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00023E4C File Offset: 0x0002204C
		private void MouseDoubleClickBlock(MouseEventArgs e)
		{
			if (this._window.isTutorial() && this._window.Tutorial != FlowchartWindow.TUTORIAL.DOUBLE_CLICK)
			{
				return;
			}
			if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
			{
				int i = this._program.Blocks.Count - 1;
				while (i >= 0)
				{
					ProgramModule.Block block = this._program.Blocks[i];
					if (block.isIncludingBlock(e.Location))
					{
						ProgramModule.BlockLoopStart blockLoopStart = null;
						if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
						{
							if (((ProgramModule.BlockBranch)block).isIncludingBlockDown(e.Location))
							{
								blockLoopStart = (ProgramModule.BlockLoopStart)block;
								block = ((ProgramModule.BlockLoopStart)block).BlockLoopEnd;
							}
							else if (!((ProgramModule.BlockBranch)block).isIncludingBlockUp(e.Location))
							{
								break;
							}
						}
						Form form = null;
						int num = 999;
						if (block.ConnectState == ProgramModule.Block.CONNECT_STATE.RIGHT)
						{
							List<int> list = new List<int>();
							this._window.Programs.getSubroutineIndexes(ProgramModules.ROUTINE.MAIN, list);
							if (this._window.RoutineIndex == ProgramModules.ROUTINE.MAIN || list.IndexOf(this._window.RoutineIndex - ProgramModules.ROUTINE.SUB_1) >= 0)
							{
								num = 256 - this._window.Programs.getUsedMemory(ProgramModules.ROUTINE.MAIN, true) + block.getUsedMemory();
							}
						}
						if (block.GetType() == typeof(ProgramModule.BlockLED))
						{
							form = new BlockPropertyLEDDialog((ProgramModule.BlockLED)block, num, this._window.isTutorial());
						}
						else if (block.GetType() == typeof(ProgramModule.BlockSound))
						{
							form = new BlockPropertySoundDialog((ProgramModule.BlockSound)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockWait))
						{
							form = new BlockPropertyWaitDialog((ProgramModule.BlockWait)block, num, false);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
						{
							form = new BlockPropertyLoopDialog((ProgramModule.BlockLoopStart)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockLoopEnd))
						{
							if (this._window.IsUsbInOutEnable || ((ProgramModule.BlockLoopEnd)block).Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX)
							{
								form = new BlockPropertyLoopEndDialog((ProgramModule.BlockLoopEnd)block, num, this._window.RunningFlag);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockIf))
						{
							if (this._window.IsUsbInOutEnable || ((ProgramModule.BlockIf)block).Condition != ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX)
							{
								form = new BlockPropertyIfDialog((ProgramModule.BlockIf)block, num, this._window.RunningFlag);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockArithmetic))
						{
							form = new BlockPropertyArithmeticDialog((ProgramModule.BlockArithmetic)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockCounter))
						{
							form = new BlockPropertyCounterDialog((ProgramModule.BlockCounter)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockSubroutine))
						{
							form = new BlockPropertySubroutineDialog((ProgramModule.BlockSubroutine)block, this._window.Programs, FlowchartWindow.getSubroutineNames());
						}
						else if (block.GetType() == typeof(ProgramModule.BlockDisplay))
						{
							form = new BlockPropertyDisplayDialog((ProgramModule.BlockDisplay)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockUsbOut) && this._window.IsUsbInOutEnable)
						{
							form = new BlockPropertyUsbOutDialog((ProgramModule.BlockUsbOut)block, num, false);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockJump))
						{
							List<ProgramModule.BlockLabel> list2 = this._program.Blocks.OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>();
							form = new BlockPropertyJumpDialog((ProgramModule.BlockJump)block, list2);
						}
						if (form == null)
						{
							break;
						}
						form.StartPosition = FormStartPosition.Manual;
						form.DesktopLocation = base.Parent.PointToScreen(new Point(base.Parent.Location.X + 20, base.Parent.Location.Y + 20));
						if (this._window.isTutorial() && this._window.Tutorial == FlowchartWindow.TUTORIAL.DOUBLE_CLICK)
						{
							FlowchartWindow window = this._window;
							FlowchartWindow.TUTORIAL tutorial = window.Tutorial;
							window.Tutorial = tutorial + 1;
						}
						form.ShowDialog();
						if (this._window.isTutorial())
						{
							FlowchartWindow window2 = this._window;
							FlowchartWindow.TUTORIAL tutorial = window2.Tutorial;
							window2.Tutorial = tutorial + 1;
						}
						if (!block.Updated)
						{
							break;
						}
						block.Updated = false;
						if (blockLoopStart == null)
						{
							block.updateBlock();
							block.updateLocation(block.LocationBlock.X);
						}
						else
						{
							blockLoopStart.updateBlock();
							blockLoopStart.updateLocation(blockLoopStart.LocationBlock.X);
						}
						this._window.updateProgram();
						this._window.updateUsedMemory();
						this._window.addHistory(true);
						if (block.GetType() == typeof(ProgramModule.BlockLED))
						{
							this._window.updateLog("LEDブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockSound))
						{
							this._window.updateLog("サウンドブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockWait))
						{
							this._window.updateLog("ウェイトブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
						{
							this._window.updateLog("ループブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockLoopEnd))
						{
							this._window.updateLog("ループブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockIf))
						{
							this._window.updateLog("分岐ブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockArithmetic))
						{
							this._window.updateLog("演算ブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockCounter))
						{
							this._window.updateLog("秒カウンタブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockSubroutine))
						{
							this._window.updateLog("サブルーチンブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockDisplay))
						{
							this._window.updateLog("表示ブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockUsbOut))
						{
							this._window.updateLog("外部出力ブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockJump))
						{
							this._window.updateLog("ジャンプブロックの設定を変更");
							return;
						}
						break;
					}
					else
					{
						i--;
					}
				}
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00024518 File Offset: 0x00022718
		private void setSelect(Rectangle rect)
		{
			int num = 0;
			if (this._window.IsBlockMode)
			{
				using (List<ProgramModule.Block>.Enumerator enumerator = this._program.Blocks.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProgramModule.Block block = enumerator.Current;
						if (block.isIncludedBlock(rect))
						{
							this.setBlockSelected(block, true);
							num++;
						}
					}
					goto IL_A1;
				}
			}
			foreach (ProgramModule.Block block2 in this._program.Blocks)
			{
				if (block2.isIncluded(rect))
				{
					this.setBlockSelected(block2, true);
					num++;
				}
			}
			IL_A1:
			if (num >= 2)
			{
				ProgramModule.SelectLoopBlock = null;
			}
			this._window.updateProgramTextBoxSelect();
		}

		// Token: 0x06000260 RID: 608 RVA: 0x000245F8 File Offset: 0x000227F8
		private Point getGridPosition(Point position, Size blockSize)
		{
			return this.getAreaPosition(new Point(position.X / 8 * 8 + 1, position.Y / 8 * 8 + 1), blockSize);
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00024620 File Offset: 0x00022820
		private Point getAreaPosition(Point position, Size blockSize)
		{
			if (this._window.IsBlockMode)
			{
				return new Point(Math.Max(0, Math.Min(FlowchartArea.AREA_SIZE_BLOCK.Width - blockSize.Width, position.X)), Math.Max(0, Math.Min(FlowchartArea.AREA_SIZE_BLOCK.Height - blockSize.Height, position.Y)));
			}
			return new Point(Math.Max(0, Math.Min(FlowchartArea.AREA_SIZE.Width - blockSize.Width, position.X)), Math.Max(0, Math.Min(FlowchartArea.AREA_SIZE.Height - blockSize.Height, position.Y)));
		}

		// Token: 0x06000262 RID: 610 RVA: 0x000246E4 File Offset: 0x000228E4
		private void scrollScreen(Point location)
		{
			if (location.X + ((SplitterPanel)base.Parent).AutoScrollPosition.X > ((SplitterPanel)base.Parent).Width)
			{
				((SplitterPanel)base.Parent).AutoScrollPosition = new Point(-((SplitterPanel)base.Parent).AutoScrollPosition.X + 3, -((SplitterPanel)base.Parent).AutoScrollPosition.Y);
			}
			else if (location.X + ((SplitterPanel)base.Parent).AutoScrollPosition.X < 0)
			{
				((SplitterPanel)base.Parent).AutoScrollPosition = new Point(-((SplitterPanel)base.Parent).AutoScrollPosition.X - 3, -((SplitterPanel)base.Parent).AutoScrollPosition.Y);
			}
			if (location.Y + ((SplitterPanel)base.Parent).AutoScrollPosition.Y > ((SplitterPanel)base.Parent).Height)
			{
				((SplitterPanel)base.Parent).AutoScrollPosition = new Point(-((SplitterPanel)base.Parent).AutoScrollPosition.X, -((SplitterPanel)base.Parent).AutoScrollPosition.Y + 3);
			}
			else if (location.Y + ((SplitterPanel)base.Parent).AutoScrollPosition.Y < 0)
			{
				((SplitterPanel)base.Parent).AutoScrollPosition = new Point(-((SplitterPanel)base.Parent).AutoScrollPosition.X, -((SplitterPanel)base.Parent).AutoScrollPosition.Y - 3);
			}
			base.Update();
		}

		// Token: 0x06000263 RID: 611 RVA: 0x000248C9 File Offset: 0x00022AC9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000248E8 File Offset: 0x00022AE8
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x04000226 RID: 550
		public const int GRID_SIZE = 8;

		// Token: 0x04000227 RID: 551
		public static readonly Size AREA_SIZE = new Size(1680, 2376);

		// Token: 0x04000228 RID: 552
		public static readonly Size AREA_SIZE_BLOCK = new Size(3360, 4752);

		// Token: 0x04000229 RID: 553
		private FlowchartWindow _window;

		// Token: 0x0400022A RID: 554
		private ProgramModule _program;

		// Token: 0x0400022B RID: 555
		private FlowchartArea.DRAG _drag;

		// Token: 0x0400022C RID: 556
		private Point _dragBefore;

		// Token: 0x0400022D RID: 557
		private Point _dragPoint = Point.Empty;

		// Token: 0x0400022E RID: 558
		private ProgramModule.Block _dragBlock;

		// Token: 0x0400022F RID: 559
		private ProgramModule.Block.CONNECT_BLOCK _connectIndex = ProgramModule.Block.CONNECT_BLOCK.INVALID;

		// Token: 0x04000230 RID: 560
		private ProgramModule.Block _connectBlock;

		// Token: 0x04000231 RID: 561
		private ProgramModule.Block.CONNECT_POINT _dragConnectPoint = ProgramModule.Block.CONNECT_POINT.NONE;

		// Token: 0x04000232 RID: 562
		private ProgramModule.Block _dragConnectBlock;

		// Token: 0x04000233 RID: 563
		private ProgramModule.Block _dragConnectTargetBlock;

		// Token: 0x04000234 RID: 564
		private List<ProgramModule.Block> _drawBlocks = new List<ProgramModule.Block>();

		// Token: 0x04000235 RID: 565
		private bool _grid = true;

		// Token: 0x04000236 RID: 566
		private bool _detail = true;

		// Token: 0x04000237 RID: 567
		private bool _displayControl = true;

		// Token: 0x04000238 RID: 568
		private Rectangle _selectRect;

		// Token: 0x04000239 RID: 569
		private ToolTip _toolTip;

		// Token: 0x0400023A RID: 570
		private bool _toolTipEnable;

		// Token: 0x0400023B RID: 571
		private IContainer components;

		// Token: 0x0200008D RID: 141
		public enum ALIGNMENT
		{
			// Token: 0x04000819 RID: 2073
			LEFT,
			// Token: 0x0400081A RID: 2074
			RIGHT,
			// Token: 0x0400081B RID: 2075
			UP,
			// Token: 0x0400081C RID: 2076
			BOTTOM
		}

		// Token: 0x0200008E RID: 142
		public enum DIRECT
		{
			// Token: 0x0400081E RID: 2078
			RIGHT,
			// Token: 0x0400081F RID: 2079
			BOTTOM,
			// Token: 0x04000820 RID: 2080
			RIGHT_BOTTOM
		}

		// Token: 0x0200008F RID: 143
		public enum DRAG
		{
			// Token: 0x04000822 RID: 2082
			NONE,
			// Token: 0x04000823 RID: 2083
			SELECT,
			// Token: 0x04000824 RID: 2084
			BLOCK,
			// Token: 0x04000825 RID: 2085
			CONNECT
		}
	}
}
