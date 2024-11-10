using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000035 RID: 53
	public class NetworkFlowchartArea : PictureBox
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060005D2 RID: 1490 RVA: 0x00046CEC File Offset: 0x00044EEC
		// (set) Token: 0x060005D3 RID: 1491 RVA: 0x00046CF4 File Offset: 0x00044EF4
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

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00046D0E File Offset: 0x00044F0E
		// (set) Token: 0x060005D5 RID: 1493 RVA: 0x00046D16 File Offset: 0x00044F16
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

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00046D1F File Offset: 0x00044F1F
		// (set) Token: 0x060005D7 RID: 1495 RVA: 0x00046D27 File Offset: 0x00044F27
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

		// Token: 0x060005D8 RID: 1496 RVA: 0x00046D58 File Offset: 0x00044F58
		public NetworkFlowchartArea(NetworkWindow window, ContextMenuStrip contextMenuStrip, ProgramModule program)
		{
			this.InitializeComponent();
			this._window = window;
			this.setProgram(program);
			base.Size = (window.IsBlockMode ? NetworkFlowchartArea.AREA_SIZE_BLOCK : NetworkFlowchartArea.AREA_SIZE);
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

		// Token: 0x060005D9 RID: 1497 RVA: 0x00046E95 File Offset: 0x00045095
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			if (this._program == null)
			{
				return;
			}
			this.paintBlocks(pe);
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x00046EAE File Offset: 0x000450AE
		public void paintBlocks(PaintEventArgs pe)
		{
			if (this._window.IsBlockMode)
			{
				this.paintBlocksBlock(pe);
				return;
			}
			this.paintBlocksFlowchart(pe);
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00046ECC File Offset: 0x000450CC
		private void paintBlocksFlowchart(PaintEventArgs pe)
		{
			List<ProgramModule.Block> list = new List<ProgramModule.Block>();
			if (this._program.getError(false, true, false) != ProgramModule.ERROR.INFINITY)
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
			if (this._drag == NetworkFlowchartArea.DRAG.SELECT)
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
			if (this._drag == NetworkFlowchartArea.DRAG.CONNECT)
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

		// Token: 0x060005DC RID: 1500 RVA: 0x00047140 File Offset: 0x00045340
		private void paintBlocksBlock(PaintEventArgs pe)
		{
			foreach (ProgramModule.Block block in this._drawBlocks)
			{
				if (block == this._dragBlock)
				{
					if (this._drag == NetworkFlowchartArea.DRAG.BLOCK && this._connectIndex != ProgramModule.Block.CONNECT_BLOCK.INVALID)
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

		// Token: 0x060005DD RID: 1501 RVA: 0x00047328 File Offset: 0x00045528
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

		// Token: 0x060005DE RID: 1502 RVA: 0x000473AC File Offset: 0x000455AC
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

		// Token: 0x060005DF RID: 1503 RVA: 0x0004744C File Offset: 0x0004564C
		public void updateData()
		{
			foreach (ProgramModule.Block block in this._program.Blocks)
			{
				if (block is ProgramModule.BlockEvent || block is ProgramModule.BlockMessage || block is ProgramModule.BlockCommunication || block is ProgramModule.BlockIf || block is ProgramModule.BlockLoopStart || block is ProgramModule.BlockData || block is ProgramModule.BlockNetworkDisplay)
				{
					block.updateData();
				}
			}
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x000474DC File Offset: 0x000456DC
		public void updateLevel()
		{
			foreach (ProgramModule.Block block in this._program.Blocks)
			{
				if (block is ProgramModule.BlockEvent)
				{
					((ProgramModule.BlockEvent)block).updateLevel();
				}
				else if (block is ProgramModule.BlockCommunication)
				{
					((ProgramModule.BlockCommunication)block).updateLevel();
				}
				else if (block is ProgramModule.BlockOutput)
				{
					((ProgramModule.BlockOutput)block).updateLevel();
				}
				else if (block is ProgramModule.BlockData)
				{
					((ProgramModule.BlockData)block).updateLevel();
				}
				else if (block is ProgramModule.BlockNetworkDisplay)
				{
					((ProgramModule.BlockNetworkDisplay)block).updateLevel();
				}
				else if (block is ProgramModule.BlockIf)
				{
					((ProgramModule.BlockIf)block).updateLevel();
				}
				else if (block is ProgramModule.BlockLoopStart)
				{
					((ProgramModule.BlockLoopStart)block).updateLevel();
				}
			}
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x000475C4 File Offset: 0x000457C4
		public void updateUsbInOutEnable(bool enable)
		{
			foreach (ProgramModule.Block block in this._program.Blocks)
			{
				if (block is ProgramModule.BlockUsbOut)
				{
					((ProgramModule.BlockUsbOut)block).updateUsbInOutEnable(enable);
				}
				else if (block is ProgramModule.BlockEvent)
				{
					((ProgramModule.BlockEvent)block).updateUsbInOutEnable(enable);
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

		// Token: 0x060005E2 RID: 1506 RVA: 0x0004766C File Offset: 0x0004586C
		public void NetworkFlowchartArea_KeyDown(KeyEventArgs e)
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
						block.Location = this.getEmptyPosition(this.getGridPosition(new Point(block.Location.X + point.X * 8, block.Location.Y + point.Y * 8), ProgramModule.Block.BLOCK_SIZE), block, NetworkFlowchartArea.DIRECT.RIGHT_BOTTOM);
						base.Invalidate();
						this._window.addHistory(true);
					}
				}
			}
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x000477C4 File Offset: 0x000459C4
		public void setProgram(ProgramModule program)
		{
			this._program = program;
			if (this._window.IsBlockMode && program != null)
			{
				this._program.updateLabels();
				base.Controls.Clear();
				if (this.DisplayControl)
				{
					foreach (ProgramModule.Block block in program.Blocks)
					{
						block.createBlockControls();
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

		// Token: 0x060005E4 RID: 1508 RVA: 0x00047A28 File Offset: 0x00045C28
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
					if (!(list[0] is ProgramModule.BlockStart) || this._program.Starts.Count != 1)
					{
						ProgramModule.Block block2 = list[0];
						if (this._drawBlocks.Contains(block2))
						{
							this._drawBlocks.Remove(block2);
							if (block2.Next != null && !(block2 is ProgramModule.BlockEvent))
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
				}
				else
				{
					foreach (ProgramModule.Block block3 in list)
					{
						if (!(block3 is ProgramModule.BlockStart) || this._program.Starts.Count != 1)
						{
							this._program.removeBlock(block3, true);
						}
					}
				}
				base.Invalidate();
				this._window.updateProgramTextBoxSelect();
				this._window.addHistory(true);
				this._program.updateLoopIndex();
				this._program.updateConnectState();
				this._window.updateProgram();
				this._window.updateLog("ブロックを削除");
			}
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00047BF8 File Offset: 0x00045DF8
		public void setBlockSelected(ProgramModule.Block block, bool enable)
		{
			if (enable)
			{
				if (!this._window.IsBlockMode || !(block is ProgramModule.BlockEnd))
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

		// Token: 0x060005E6 RID: 1510 RVA: 0x00047C24 File Offset: 0x00045E24
		private void removeBlockBlock(ProgramModule.Block block)
		{
			foreach (Control control in block.Controls)
			{
				base.Controls.Remove(control);
			}
			this._program.removeBlockBlock(block);
			if (block is ProgramModule.BlockBranch)
			{
				using (List<ProgramModule.Block>.Enumerator enumerator2 = ((ProgramModule.BlockBranch)block).Branches.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						ProgramModule.Block block2 = enumerator2.Current;
						if (block2 != null)
						{
							for (ProgramModule.Block block3 = block2; block3 != null; block3 = block3.Next)
							{
								this.removeBlockBlock(block3);
							}
						}
					}
					return;
				}
			}
			if (block is ProgramModule.BlockEvent)
			{
				for (ProgramModule.Block block4 = block.Next; block4 != null; block4 = block4.Next)
				{
					this.removeBlockBlock(block4);
				}
			}
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x00047D14 File Offset: 0x00045F14
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
			this._window.addHistory(true);
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00047E24 File Offset: 0x00046024
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

		// Token: 0x060005E9 RID: 1513 RVA: 0x00047E9C File Offset: 0x0004609C
		public void clearSelect()
		{
			foreach (ProgramModule.Block block in this._program.Blocks)
			{
				this.setBlockSelected(block, false);
			}
			this._window.updateProgramTextBoxSelect();
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x00047F00 File Offset: 0x00046100
		public void alignSelectBlocks(NetworkFlowchartArea.ALIGNMENT alignment)
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
				case NetworkFlowchartArea.ALIGNMENT.LEFT:
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
							block3.Location = this.getEmptyPosition(new Point(num, block3.Location.Y), block3, NetworkFlowchartArea.DIRECT.BOTTOM);
						}
						goto IL_31F;
					}
					break;
				}
				case NetworkFlowchartArea.ALIGNMENT.RIGHT:
					break;
				case NetworkFlowchartArea.ALIGNMENT.UP:
					goto IL_1CA;
				case NetworkFlowchartArea.ALIGNMENT.BOTTOM:
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
						block5.Location = this.getEmptyPosition(new Point(num, block5.Location.Y), block5, NetworkFlowchartArea.DIRECT.BOTTOM);
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
						block7.Location = this.getEmptyPosition(new Point(block7.Location.X, num), block7, NetworkFlowchartArea.DIRECT.RIGHT);
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
					block9.Location = this.getEmptyPosition(new Point(block9.Location.X, num), block9, NetworkFlowchartArea.DIRECT.RIGHT);
				}
				IL_31F:
				this._window.addHistory(true);
				this._window.updateLog("ブロックを整列");
			}
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x000482B8 File Offset: 0x000464B8
		public Point getEmptyPosition(Point position, ProgramModule.Block ignoreBlock = null, NetworkFlowchartArea.DIRECT direct = NetworkFlowchartArea.DIRECT.RIGHT_BOTTOM)
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
							case NetworkFlowchartArea.DIRECT.RIGHT:
								return this.getEmptyPosition(new Point(position.X + 8, position.Y), ignoreBlock, direct);
							case NetworkFlowchartArea.DIRECT.BOTTOM:
								return this.getEmptyPosition(new Point(position.X, position.Y + 8), ignoreBlock, direct);
							case NetworkFlowchartArea.DIRECT.RIGHT_BOTTOM:
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
					case NetworkFlowchartArea.DIRECT.RIGHT:
						return this.getEmptyPosition(new Point(position.X + 8, position.Y), ignoreBlock, direct);
					case NetworkFlowchartArea.DIRECT.BOTTOM:
						return this.getEmptyPosition(new Point(position.X, position.Y + 8), ignoreBlock, direct);
					case NetworkFlowchartArea.DIRECT.RIGHT_BOTTOM:
						return this.getEmptyPosition(new Point(position.X + 8, position.Y + 8), ignoreBlock, direct);
					}
				}
			}
			return position;
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x000484C4 File Offset: 0x000466C4
		public Rectangle getReportRect()
		{
			Rectangle rectangle = default(Rectangle);
			rectangle.X = base.Width;
			rectangle.Y = base.Height;
			if (this._window.IsBlockMode)
			{
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
					rectangle.X = Math.Min(rectangle.X, block2.Location.X);
					rectangle.Y = Math.Min(rectangle.Y, block2.Location.Y);
					rectangle.Width = Math.Max(rectangle.Width, block2.Location.X);
					rectangle.Height = Math.Max(rectangle.Height, block2.Location.Y);
				}
				rectangle.X = Math.Max(0, rectangle.X - 20);
				rectangle.Y = Math.Max(0, rectangle.Y - 70);
				rectangle.Width = rectangle.Width + ProgramModule.Block.BLOCK_SIZE.Width + 20 - rectangle.X;
				rectangle.Height = rectangle.Height + ProgramModule.Block.BLOCK_SIZE.Height + 70 - rectangle.Y;
			}
			return rectangle;
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0004879C File Offset: 0x0004699C
		private void FlowchartArea_DragEnter(object sender, DragEventArgs e)
		{
			object data = e.Data.GetData(DataFormats.Text);
			if (data != null)
			{
				string text = data.ToString();
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
				if (num <= 1625091293U)
				{
					if (num <= 1061176027U)
					{
						if (num <= 236776447U)
						{
							if (num != 80939203U)
							{
								if (num != 236776447U)
								{
									return;
								}
								if (!(text == "EVENT"))
								{
									return;
								}
							}
							else if (!(text == "COUNTER"))
							{
								return;
							}
						}
						else if (num != 931238212U)
						{
							if (num != 1061176027U)
							{
								return;
							}
							if (!(text == "USBOUT"))
							{
								return;
							}
						}
						else if (!(text == "MESSAGE"))
						{
							return;
						}
					}
					else if (num <= 1469629700U)
					{
						if (num != 1348155789U)
						{
							if (num != 1469629700U)
							{
								return;
							}
							if (!(text == "OUTPUT"))
							{
								return;
							}
						}
						else if (!(text == "JUMP"))
						{
							return;
						}
					}
					else if (num != 1491660422U)
					{
						if (num != 1625091293U)
						{
							return;
						}
						if (!(text == "LABEL"))
						{
							return;
						}
					}
					else if (!(text == "IF"))
					{
						return;
					}
				}
				else if (num <= 3061266164U)
				{
					if (num <= 2393865632U)
					{
						if (num != 2320642179U)
						{
							if (num != 2393865632U)
							{
								return;
							}
							if (!(text == "WAIT"))
							{
								return;
							}
						}
						else if (!(text == "COMMUNICATION"))
						{
							return;
						}
					}
					else if (num != 2442931280U)
					{
						if (num != 3061266164U)
						{
							return;
						}
						if (!(text == "SOUND"))
						{
							return;
						}
					}
					else if (!(text == "LOOP_START"))
					{
						return;
					}
				}
				else if (num <= 3288857317U)
				{
					if (num != 3175886770U)
					{
						if (num != 3288857317U)
						{
							return;
						}
						if (!(text == "DATA"))
						{
							return;
						}
					}
					else if (!(text == "IF_ELSE"))
					{
						return;
					}
				}
				else if (num != 3529180305U)
				{
					if (num != 4165932597U)
					{
						return;
					}
					if (!(text == "DISPLAY"))
					{
						return;
					}
				}
				else if (!(text == "LOOP_END"))
				{
					return;
				}
				if (e.Data.GetDataPresent(DataFormats.Text))
				{
					e.Effect = DragDropEffects.Copy;
				}
			}
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x000489C5 File Offset: 0x00046BC5
		private void FlowchartArea_DragDrop(object sender, DragEventArgs e)
		{
			if (this._window.IsBlockMode)
			{
				this.DragDropBlock(e);
				return;
			}
			this.DragDropFlowchart(e);
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x000489E4 File Offset: 0x00046BE4
		private void DragDropFlowchart(DragEventArgs e)
		{
			if (this._program != null && e.Data.GetDataPresent(DataFormats.Text))
			{
				string text = e.Data.GetData(DataFormats.Text).ToString();
				ProgramModule.Block block = null;
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
				if (num <= 1491660422U)
				{
					if (num <= 931238212U)
					{
						if (num != 80939203U)
						{
							if (num != 236776447U)
							{
								if (num == 931238212U)
								{
									if (text == "MESSAGE")
									{
										block = new ProgramModule.BlockMessage();
									}
								}
							}
							else if (text == "EVENT")
							{
								NetworkFlowchartTab.TAB flowchartTabIndex = this._window.FlowchartTabIndex;
								if (flowchartTabIndex != NetworkFlowchartTab.TAB.OBJECT)
								{
									if (flowchartTabIndex == NetworkFlowchartTab.TAB.STAGE)
									{
										block = new ProgramModule.BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE.STAGE);
									}
								}
								else
								{
									NetworkProgramModules.ObjectInfo selectedObject = this._window.Programs.getSelectedObject();
									if (selectedObject is NetworkProgramModules.ObjectButtonInfo)
									{
										block = new ProgramModule.BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON);
									}
									else if (selectedObject is NetworkProgramModules.ObjectLabelInfo)
									{
										block = new ProgramModule.BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE.LABEL);
									}
									else if (selectedObject is NetworkProgramModules.ObjectListInfo)
									{
										block = new ProgramModule.BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE.LIST);
									}
									else if (selectedObject is NetworkProgramModules.ObjectGraphInfo)
									{
										block = new ProgramModule.BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE.GRAPH);
									}
									else if (selectedObject is NetworkProgramModules.ObjectInputInfo)
									{
										block = new ProgramModule.BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE.INPUT);
									}
								}
								if (block != null)
								{
									this._program.Starts.Add((ProgramModule.BlockEvent)block);
								}
							}
						}
						else if (text == "COUNTER")
						{
							block = new ProgramModule.BlockCounter();
						}
					}
					else if (num != 1061176027U)
					{
						if (num != 1469629700U)
						{
							if (num == 1491660422U)
							{
								if (text == "IF")
								{
									block = new ProgramModule.BlockIf();
									((ProgramModule.BlockIf)block).IsConditionNetwork = true;
								}
							}
						}
						else if (text == "OUTPUT")
						{
							block = new ProgramModule.BlockOutput();
						}
					}
					else if (text == "USBOUT")
					{
						block = new ProgramModule.BlockUsbOut();
					}
				}
				else if (num <= 2442931280U)
				{
					if (num != 2320642179U)
					{
						if (num != 2393865632U)
						{
							if (num == 2442931280U)
							{
								if (text == "LOOP_START")
								{
									block = new ProgramModule.BlockLoopStart();
								}
							}
						}
						else if (text == "WAIT")
						{
							block = new ProgramModule.BlockWait();
						}
					}
					else if (text == "COMMUNICATION")
					{
						block = new ProgramModule.BlockCommunication();
					}
				}
				else if (num <= 3288857317U)
				{
					if (num != 3061266164U)
					{
						if (num == 3288857317U)
						{
							if (text == "DATA")
							{
								block = new ProgramModule.BlockData();
							}
						}
					}
					else if (text == "SOUND")
					{
						block = new ProgramModule.BlockNetworkSound();
					}
				}
				else if (num != 3529180305U)
				{
					if (num == 4165932597U)
					{
						if (text == "DISPLAY")
						{
							block = new ProgramModule.BlockNetworkDisplay();
							if (this._window.Tutorial == NetworkWindow.TUTORIAL.DRAG_DISPLAY || this._window.Tutorial == NetworkWindow.TUTORIAL.DRAG_DISPLAY_2)
							{
								NetworkWindow window = this._window;
								NetworkWindow.TUTORIAL tutorial = window.Tutorial;
								window.Tutorial = tutorial + 1;
							}
						}
					}
				}
				else if (text == "LOOP_END")
				{
					block = new ProgramModule.BlockLoopEnd();
				}
				if (block != null)
				{
					block.Location = this.getEmptyPosition(this.getGridPosition(base.PointToClient(new Point(e.X - Resources.fc_block_000.Width / 2, e.Y - Resources.fc_block_000.Height / 2)), ProgramModule.Block.BLOCK_SIZE), null, NetworkFlowchartArea.DIRECT.RIGHT_BOTTOM);
					this._program.addBlock(block);
					this._window.updateProgramTextBoxSelect();
					this._window.addHistory(true);
					this._window.updateLog("ブロックを追加");
				}
			}
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x00048DD8 File Offset: 0x00046FD8
		private void DragDropBlock(DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				string text = e.Data.GetData(DataFormats.Text).ToString();
				ProgramModule.Block block = null;
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
				if (num <= 1491660422U)
				{
					if (num <= 931238212U)
					{
						if (num != 80939203U)
						{
							if (num != 236776447U)
							{
								if (num == 931238212U)
								{
									if (text == "MESSAGE")
									{
										block = new ProgramModule.BlockMessage();
									}
								}
							}
							else if (text == "EVENT")
							{
								NetworkFlowchartTab.TAB flowchartTabIndex = this._window.FlowchartTabIndex;
								if (flowchartTabIndex != NetworkFlowchartTab.TAB.OBJECT)
								{
									if (flowchartTabIndex == NetworkFlowchartTab.TAB.STAGE)
									{
										block = new ProgramModule.BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE.STAGE);
									}
								}
								else
								{
									NetworkProgramModules.ObjectInfo selectedObject = this._window.Programs.getSelectedObject();
									if (selectedObject is NetworkProgramModules.ObjectButtonInfo)
									{
										block = new ProgramModule.BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON);
									}
									else if (selectedObject is NetworkProgramModules.ObjectLabelInfo)
									{
										block = new ProgramModule.BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE.LABEL);
									}
									else if (selectedObject is NetworkProgramModules.ObjectListInfo)
									{
										block = new ProgramModule.BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE.LIST);
									}
									else if (selectedObject is NetworkProgramModules.ObjectGraphInfo)
									{
										block = new ProgramModule.BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE.GRAPH);
									}
									else if (selectedObject is NetworkProgramModules.ObjectInputInfo)
									{
										block = new ProgramModule.BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE.INPUT);
									}
								}
								if (block != null)
								{
									this._program.Starts.Add((ProgramModule.BlockEvent)block);
									ProgramModule.BlockEnd blockEnd = new ProgramModule.BlockEnd();
									if (this.DisplayControl)
									{
										blockEnd.createBlockControls();
									}
									block.Next = blockEnd;
									blockEnd.Before = block;
									this._program.Ends.Add(blockEnd);
									this._program.addBlock(blockEnd);
								}
							}
						}
						else if (text == "COUNTER")
						{
							block = new ProgramModule.BlockCounter();
						}
					}
					else if (num <= 1348155789U)
					{
						if (num != 1061176027U)
						{
							if (num == 1348155789U)
							{
								if (text == "JUMP")
								{
									block = new ProgramModule.BlockJump();
								}
							}
						}
						else if (text == "USBOUT")
						{
							block = new ProgramModule.BlockUsbOut();
						}
					}
					else if (num != 1469629700U)
					{
						if (num == 1491660422U)
						{
							if (text == "IF")
							{
								block = new ProgramModule.BlockIf(1);
								((ProgramModule.BlockIf)block).IsConditionNetwork = true;
							}
						}
					}
					else if (text == "OUTPUT")
					{
						block = new ProgramModule.BlockOutput();
					}
				}
				else if (num <= 2442931280U)
				{
					if (num <= 2320642179U)
					{
						if (num != 1625091293U)
						{
							if (num == 2320642179U)
							{
								if (text == "COMMUNICATION")
								{
									block = new ProgramModule.BlockCommunication();
								}
							}
						}
						else if (text == "LABEL")
						{
							block = new ProgramModule.BlockLabel();
						}
					}
					else if (num != 2393865632U)
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
				else if (num <= 3175886770U)
				{
					if (num != 3061266164U)
					{
						if (num == 3175886770U)
						{
							if (text == "IF_ELSE")
							{
								block = new ProgramModule.BlockIf(2);
								((ProgramModule.BlockIf)block).IsConditionNetwork = true;
							}
						}
					}
					else if (text == "SOUND")
					{
						block = new ProgramModule.BlockNetworkSound();
					}
				}
				else if (num != 3288857317U)
				{
					if (num == 4165932597U)
					{
						if (text == "DISPLAY")
						{
							block = new ProgramModule.BlockNetworkDisplay();
							if (this._window.Tutorial == NetworkWindow.TUTORIAL.DRAG_DISPLAY || this._window.Tutorial == NetworkWindow.TUTORIAL.DRAG_DISPLAY_2)
							{
								NetworkWindow window = this._window;
								NetworkWindow.TUTORIAL tutorial = window.Tutorial;
								window.Tutorial = tutorial + 1;
							}
						}
					}
				}
				else if (text == "DATA")
				{
					block = new ProgramModule.BlockData();
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
							goto IL_489;
						}
					}
					block.updateBlock();
					IL_489:
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
					if (this.DisplayControl)
					{
						this.updateBlockControlVisible();
					}
					this.Refresh();
				}
			}
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0004933C File Offset: 0x0004753C
		private void FlowchartArea_MouseDown(object sender, MouseEventArgs e)
		{
			if (this._window.IsBlockMode)
			{
				this.MouseDownBlock(e);
				return;
			}
			this.MouseDownFlowchart(e);
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0004935C File Offset: 0x0004755C
		private void MouseDownFlowchart(MouseEventArgs e)
		{
			if (this._window.isTutorial() && this._window.Tutorial != NetworkWindow.TUTORIAL.CONNECT_BLOCKS && this._window.Tutorial != NetworkWindow.TUTORIAL.CONNECT_BLOCKS_2)
			{
				return;
			}
			if (this._program == null)
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
						this._drag = NetworkFlowchartArea.DRAG.CONNECT;
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
						this._drag = NetworkFlowchartArea.DRAG.BLOCK;
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
			if (this._drag == NetworkFlowchartArea.DRAG.NONE)
			{
				this.clearSelect();
				base.Invalidate();
				if (e.Button == MouseButtons.Left)
				{
					this._drag = NetworkFlowchartArea.DRAG.SELECT;
					this._selectRect.Location = e.Location;
					this._selectRect.Size = Size.Empty;
				}
			}
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x00049584 File Offset: 0x00047784
		private void MouseDownBlock(MouseEventArgs e)
		{
			if (this._window.isTutorial() && this._window.Tutorial != NetworkWindow.TUTORIAL.CONNECT_BLOCKS && this._window.Tutorial != NetworkWindow.TUTORIAL.CONNECT_BLOCKS_2)
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
					this._drag = NetworkFlowchartArea.DRAG.BLOCK;
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
			if (this._drag == NetworkFlowchartArea.DRAG.NONE)
			{
				this.clearSelect();
				base.Invalidate();
				if (e.Button == MouseButtons.Left)
				{
					this._drag = NetworkFlowchartArea.DRAG.SELECT;
					this._selectRect.Location = e.Location;
					this._selectRect.Size = Size.Empty;
				}
			}
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x00049718 File Offset: 0x00047918
		private void FlowchartArea_MouseMove(object sender, MouseEventArgs e)
		{
			if (this._window.IsBlockMode)
			{
				this.MouseMoveBlock(e);
				return;
			}
			this.MouseMoveFlowchart(e);
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00049738 File Offset: 0x00047938
		private void MouseMoveFlowchart(MouseEventArgs e)
		{
			if (this._program == null)
			{
				return;
			}
			if (this._drag == NetworkFlowchartArea.DRAG.SELECT)
			{
				this._selectRect.Size = new Size(e.Location.X - this._selectRect.Location.X, e.Location.Y - this._selectRect.Location.Y);
				this.scrollScreen(e.Location);
			}
			else if (this._drag == NetworkFlowchartArea.DRAG.BLOCK)
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
			else if (this._drag == NetworkFlowchartArea.DRAG.CONNECT)
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

		// Token: 0x060005F6 RID: 1526 RVA: 0x00049AC4 File Offset: 0x00047CC4
		private void MouseMoveBlock(MouseEventArgs e)
		{
			if (this._drag == NetworkFlowchartArea.DRAG.SELECT)
			{
				this.scrollScreen(e.Location);
			}
			else if (this._drag == NetworkFlowchartArea.DRAG.BLOCK && !(this._dragBlock is ProgramModule.BlockEnd))
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

		// Token: 0x060005F7 RID: 1527 RVA: 0x00049EFC File Offset: 0x000480FC
		private void FlowchartArea_MouseUp(object sender, MouseEventArgs e)
		{
			if (this._window.IsBlockMode)
			{
				this.MouseUpBlock(e);
				return;
			}
			this.MouseUpFlowchart(e);
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x00049F1C File Offset: 0x0004811C
		private void MouseUpFlowchart(MouseEventArgs e)
		{
			if (this._drag == NetworkFlowchartArea.DRAG.SELECT)
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
			else if (this._drag == NetworkFlowchartArea.DRAG.CONNECT)
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
						this._window.updateLog("ブロックを接続");
						if (this._window.isTutorial() && (this._window.Tutorial == NetworkWindow.TUTORIAL.CONNECT_BLOCKS || this._window.Tutorial == NetworkWindow.TUTORIAL.CONNECT_BLOCKS_2) && this._window.Programs.getError(false) == ProgramModule.ERROR.NONE && this._program.getConnectBlocks(this._window.IsBlockMode).Count == 3)
						{
							NetworkWindow window = this._window;
							NetworkWindow.TUTORIAL tutorial = window.Tutorial;
							window.Tutorial = tutorial + 1;
							break;
						}
						break;
					}
				}
				this._dragConnectBlock = null;
				this._dragConnectTargetBlock = null;
				this._program.updateLoopIndex();
				this._program.updateConnectState();
				this._window.updateProgram();
				this._window.addHistory(true);
				base.Invalidate();
			}
			else if (this._drag == NetworkFlowchartArea.DRAG.BLOCK)
			{
				bool flag = false;
				foreach (ProgramModule.Block block2 in this._program.Blocks)
				{
					if (block2.Selected)
					{
						Point emptyPosition = this.getEmptyPosition(this.getGridPosition(block2.Location, ProgramModule.Block.BLOCK_SIZE), block2, NetworkFlowchartArea.DIRECT.RIGHT_BOTTOM);
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
			this._drag = NetworkFlowchartArea.DRAG.NONE;
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0004A1CC File Offset: 0x000483CC
		private void MouseUpBlock(MouseEventArgs e)
		{
			if (this._drag == NetworkFlowchartArea.DRAG.BLOCK && this._dragPoint == Point.Empty)
			{
				List<ProgramModule.Block> list = new List<ProgramModule.Block>();
				this._dragBlock.getBlockList(list);
				IEnumerable<ProgramModule.Block> enumerable = this._program.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.Block>().Except(list);
				if (this._connectIndex == ProgramModule.Block.CONNECT_BLOCK.DOWN)
				{
					this._connectBlock.SetNextBlock(this._dragBlock);
					ProgramModule.Block topBlock = this._program.getTopBlock(this._connectBlock.First, enumerable.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockBranch>().ToList<ProgramModule.BlockBranch>());
					topBlock.updateLocation(topBlock.LocationBlock.X);
					this._drawBlocks.Remove(this._dragBlock);
				}
				else if (this._connectIndex == ProgramModule.Block.CONNECT_BLOCK.BRANCH_FIRST || this._connectIndex == ProgramModule.Block.CONNECT_BLOCK.BRANCH_SECOND)
				{
					ProgramModule.BlockBranch blockBranch = (ProgramModule.BlockBranch)this._connectBlock;
					if (blockBranch.Branches[(int)this._connectIndex] != null)
					{
						this._dragBlock.Last.SetNextBlock(blockBranch.Branches[(int)this._connectIndex]);
					}
					blockBranch.SetBranch(this._connectIndex, this._dragBlock);
					ProgramModule.Block topBlock2 = this._program.getTopBlock(this._connectBlock.First, enumerable.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockBranch>().ToList<ProgramModule.BlockBranch>());
					topBlock2.updateLocation(topBlock2.LocationBlock.X);
					this._drawBlocks.Remove(this._dragBlock);
				}
				else if (this._connectIndex == ProgramModule.Block.CONNECT_BLOCK.UP)
				{
					this._dragBlock.Last.SetNextBlock(this._connectBlock);
					this._dragBlock.updateLocation(this._dragBlock.LocationBlock.X);
					this._drawBlocks.Remove(this._connectBlock);
				}
				this._window.addHistory(true);
				this._window.updateLog("ブロックを移動");
				if (this._window.isTutorial() && this._connectIndex != ProgramModule.Block.CONNECT_BLOCK.INVALID)
				{
					NetworkWindow window = this._window;
					NetworkWindow.TUTORIAL tutorial = window.Tutorial;
					window.Tutorial = tutorial + 1;
				}
			}
			this._dragBlock = null;
			this._drag = NetworkFlowchartArea.DRAG.NONE;
			if (this.DisplayControl)
			{
				this.updateBlockControlVisible();
			}
			this.Refresh();
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0004A460 File Offset: 0x00048660
		private void FlowchartArea_MouseWheel(object sender, MouseEventArgs e)
		{
			VScrollProperties verticalScroll = ((SplitterPanel)base.Parent).VerticalScroll;
			int num = Math.Min(verticalScroll.Maximum, verticalScroll.Value - e.Delta);
			num = Math.Max(verticalScroll.Minimum, num);
			verticalScroll.Value = num;
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0004A4AB File Offset: 0x000486AB
		private void FlowchartArea_MouseEnter(object sender, EventArgs e)
		{
			if (Form.ActiveForm == this._window)
			{
				base.Parent.Focus();
			}
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x0004A4C6 File Offset: 0x000486C6
		private void FlowchartArea_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._window.IsBlockMode)
			{
				this.MouseDoubleClickBlock(e);
				return;
			}
			this.MouseDoubleClickFlowchart(e);
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0004A4E4 File Offset: 0x000486E4
		private void MouseDoubleClickFlowchart(MouseEventArgs e)
		{
			if (this._window.isTutorial() && this._window.Tutorial != NetworkWindow.TUTORIAL.DOUBLE_CLICK && this._window.Tutorial != NetworkWindow.TUTORIAL.DOUBLE_CLICK_2)
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
						if (block.GetType() == typeof(ProgramModule.BlockNetworkSound))
						{
							form = new BlockPropertyNetworkSoundDialog((ProgramModule.BlockNetworkSound)block);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockWait))
						{
							form = new BlockPropertyWaitDialog((ProgramModule.BlockWait)block, num, true);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
						{
							form = new BlockPropertyLoopDialog((ProgramModule.BlockLoopStart)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockLoopEnd))
						{
							ProgramModule.BlockLoopEnd blockLoopEnd = (ProgramModule.BlockLoopEnd)block;
							if ((this._window.IsUsbInOutEnable || blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.USBIN) && (this._window.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || blockLoopEnd.ConditionNetwork == ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.OBJECT_BUTTON || blockLoopEnd.ConditionNetwork == ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE))
							{
								form = new BlockPropertyNetworkLoopEndDialog(blockLoopEnd, this._window.Programs);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockIf))
						{
							ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block;
							if ((this._window.IsUsbInOutEnable || blockIf.ConditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.USBIN) && (this._window.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || blockIf.ConditionNetwork == ProgramModule.BlockIf.CONDITION_NETWORK_IF.OBJECT_BUTTON || blockIf.ConditionNetwork == ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE))
							{
								form = new BlockPropertyNetworkIfDialog(blockIf, this._window.Programs);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockData))
						{
							if (this._window.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || ((ProgramModule.BlockData)block).Kind == ProgramModule.BlockData.DATA_KIND.SUBSTITUTION)
							{
								form = new BlockPropertyDataDialog((ProgramModule.BlockData)block, this._window.Programs);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockCounter))
						{
							form = new BlockPropertyCounterDialog((ProgramModule.BlockCounter)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockNetworkDisplay))
						{
							if (this._window.Tutorial == NetworkWindow.TUTORIAL.DOUBLE_CLICK || this._window.Tutorial == NetworkWindow.TUTORIAL.DOUBLE_CLICK_2)
							{
								NetworkWindow window = this._window;
								NetworkWindow.TUTORIAL tutorial = window.Tutorial;
								window.Tutorial = tutorial + 1;
							}
							ProgramModule.BlockNetworkDisplay blockNetworkDisplay = (ProgramModule.BlockNetworkDisplay)block;
							if (this._window.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || blockNetworkDisplay.ObjectType == ProgramModule.BlockEvent.OBJECT_TYPE.LABEL || blockNetworkDisplay.ObjectType == ProgramModule.BlockEvent.OBJECT_TYPE.LIST)
							{
								form = new BlockPropertyNetworkDisplayDialog(blockNetworkDisplay, this._window.Programs);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockEvent))
						{
							if (this._window.IsUsbInOutEnable || ((ProgramModule.BlockEvent)block).TriggerHardware != ProgramModule.BlockEvent.TRIGGER_HARDWARE.LEVEL2_MAX)
							{
								form = new BlockPropertyEventDialog((ProgramModule.BlockEvent)block, this._window.Programs);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockMessage))
						{
							form = new BlockPropertyMessageDialog((ProgramModule.BlockMessage)block, this._window.Programs);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockCommunication))
						{
							ProgramModule.BlockCommunication blockCommunication = (ProgramModule.BlockCommunication)block;
							if (this._window.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || (blockCommunication.VariableType != ProgramModule.BlockCommunication.VARIABLE_TYPE.LIGHT && blockCommunication.VariableType != ProgramModule.BlockCommunication.VARIABLE_TYPE.TEMPERATURE))
							{
								form = new BlockPropertyCommunicationDialog(blockCommunication, this._window.Programs);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockOutput))
						{
							if (this._window.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2)
							{
								form = new BlockPropertyOutputDialog((ProgramModule.BlockOutput)block);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockUsbOut) && this._window.IsUsbInOutEnable)
						{
							form = new BlockPropertyUsbOutDialog((ProgramModule.BlockUsbOut)block, num, true);
						}
						if (form == null)
						{
							break;
						}
						form.StartPosition = FormStartPosition.Manual;
						form.DesktopLocation = base.Parent.PointToScreen(new Point(base.Parent.Location.X + 20, base.Parent.Location.Y + 20));
						form.ShowDialog();
						if (!block.Updated)
						{
							break;
						}
						block.Updated = false;
						this._window.updateProgram();
						this._window.addHistory(true);
						if (block.GetType() == typeof(ProgramModule.BlockNetworkSound))
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
						if (block.GetType() == typeof(ProgramModule.BlockData))
						{
							this._window.updateLog("データブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockCounter))
						{
							this._window.updateLog("秒カウンタブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockNetworkDisplay))
						{
							if (this._window.Tutorial == NetworkWindow.TUTORIAL.CHANGE_PROPERTY || this._window.Tutorial == NetworkWindow.TUTORIAL.CHANGE_PROPERTY_2)
							{
								NetworkWindow window2 = this._window;
								NetworkWindow.TUTORIAL tutorial = window2.Tutorial;
								window2.Tutorial = tutorial + 1;
							}
							this._window.updateLog("表示ブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockEvent))
						{
							this._window.updateLog("イベントブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockMessage))
						{
							this._window.updateLog("メッセージブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockCommunication))
						{
							this._window.updateLog("送受信ブロックの設定を変更");
							return;
						}
						if (block.GetType() == typeof(ProgramModule.BlockOutput))
						{
							this._window.updateLog("出力ブロックの設定を変更");
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

		// Token: 0x060005FE RID: 1534 RVA: 0x0004AC0C File Offset: 0x00048E0C
		private void MouseDoubleClickBlock(MouseEventArgs e)
		{
			if (this._window.isTutorial() && this._window.Tutorial != NetworkWindow.TUTORIAL.DOUBLE_CLICK && this._window.Tutorial != NetworkWindow.TUTORIAL.DOUBLE_CLICK_2)
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
						if (block.GetType() == typeof(ProgramModule.BlockNetworkSound))
						{
							form = new BlockPropertyNetworkSoundDialog((ProgramModule.BlockNetworkSound)block);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockWait))
						{
							form = new BlockPropertyWaitDialog((ProgramModule.BlockWait)block, num, true);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
						{
							form = new BlockPropertyLoopDialog((ProgramModule.BlockLoopStart)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockLoopEnd))
						{
							ProgramModule.BlockLoopEnd blockLoopEnd = (ProgramModule.BlockLoopEnd)block;
							if ((this._window.IsUsbInOutEnable || blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.USBIN) && (this._window.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || blockLoopEnd.ConditionNetwork == ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.OBJECT_BUTTON || blockLoopEnd.ConditionNetwork == ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE))
							{
								form = new BlockPropertyNetworkLoopEndDialog(blockLoopEnd, this._window.Programs);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockIf))
						{
							ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block;
							if ((this._window.IsUsbInOutEnable || blockIf.ConditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.USBIN) && (this._window.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || blockIf.ConditionNetwork == ProgramModule.BlockIf.CONDITION_NETWORK_IF.OBJECT_BUTTON || blockIf.ConditionNetwork == ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE))
							{
								form = new BlockPropertyNetworkIfDialog(blockIf, this._window.Programs);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockData))
						{
							if (this._window.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || ((ProgramModule.BlockData)block).Kind == ProgramModule.BlockData.DATA_KIND.SUBSTITUTION)
							{
								form = new BlockPropertyDataDialog((ProgramModule.BlockData)block, this._window.Programs);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockCounter))
						{
							form = new BlockPropertyCounterDialog((ProgramModule.BlockCounter)block, num);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockNetworkDisplay))
						{
							if (this._window.Tutorial == NetworkWindow.TUTORIAL.DOUBLE_CLICK || this._window.Tutorial == NetworkWindow.TUTORIAL.DOUBLE_CLICK_2)
							{
								NetworkWindow window = this._window;
								NetworkWindow.TUTORIAL tutorial = window.Tutorial;
								window.Tutorial = tutorial + 1;
							}
							ProgramModule.BlockNetworkDisplay blockNetworkDisplay = (ProgramModule.BlockNetworkDisplay)block;
							if (this._window.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || blockNetworkDisplay.ObjectType == ProgramModule.BlockEvent.OBJECT_TYPE.LABEL || blockNetworkDisplay.ObjectType == ProgramModule.BlockEvent.OBJECT_TYPE.LIST)
							{
								form = new BlockPropertyNetworkDisplayDialog((ProgramModule.BlockNetworkDisplay)block, this._window.Programs);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockEvent))
						{
							if (this._window.IsUsbInOutEnable || ((ProgramModule.BlockEvent)block).TriggerHardware != ProgramModule.BlockEvent.TRIGGER_HARDWARE.LEVEL2_MAX)
							{
								form = new BlockPropertyEventDialog((ProgramModule.BlockEvent)block, this._window.Programs);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockMessage))
						{
							form = new BlockPropertyMessageDialog((ProgramModule.BlockMessage)block, this._window.Programs);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockCommunication))
						{
							ProgramModule.BlockCommunication blockCommunication = (ProgramModule.BlockCommunication)block;
							if (this._window.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || (blockCommunication.VariableType != ProgramModule.BlockCommunication.VARIABLE_TYPE.LIGHT && blockCommunication.VariableType != ProgramModule.BlockCommunication.VARIABLE_TYPE.TEMPERATURE))
							{
								form = new BlockPropertyCommunicationDialog(blockCommunication, this._window.Programs);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockOutput))
						{
							if (this._window.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2)
							{
								form = new BlockPropertyOutputDialog((ProgramModule.BlockOutput)block);
							}
						}
						else if (block.GetType() == typeof(ProgramModule.BlockUsbOut) && this._window.IsUsbInOutEnable)
						{
							form = new BlockPropertyUsbOutDialog((ProgramModule.BlockUsbOut)block, num, true);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockJump))
						{
							List<ProgramModule.BlockLabel> list = this._program.Blocks.OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>();
							form = new BlockPropertyJumpDialog((ProgramModule.BlockJump)block, list);
						}
						if (form == null)
						{
							break;
						}
						form.StartPosition = FormStartPosition.Manual;
						form.DesktopLocation = base.Parent.PointToScreen(new Point(base.Parent.Location.X + 20, base.Parent.Location.Y + 20));
						form.ShowDialog();
						if (block.Updated)
						{
							block.Updated = false;
							if (block.GetType() == typeof(ProgramModule.BlockNetworkSound))
							{
								this._window.updateLog("サウンドブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockWait))
							{
								this._window.updateLog("ウェイトブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
							{
								this._window.updateLog("ループ開始ブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockLoopEnd))
							{
								this._window.updateLog("ループ終了ブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockIf))
							{
								this._window.updateLog("分岐ブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockData))
							{
								this._window.updateLog("データブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockCounter))
							{
								this._window.updateLog("秒カウンタブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockNetworkDisplay))
							{
								if (this._window.Tutorial == NetworkWindow.TUTORIAL.CHANGE_PROPERTY || this._window.Tutorial == NetworkWindow.TUTORIAL.CHANGE_PROPERTY_2)
								{
									NetworkWindow window2 = this._window;
									NetworkWindow.TUTORIAL tutorial = window2.Tutorial;
									window2.Tutorial = tutorial + 1;
								}
								((ProgramModule.BlockNetworkDisplay)block).updateObject();
								this._window.updateLog("表示ブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockEvent))
							{
								this._window.updateLog("イベントブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockMessage))
							{
								this._window.updateLog("メッセージブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockCommunication))
							{
								this._window.updateLog("送受信ブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockOutput))
							{
								this._window.updateLog("出力ブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockUsbOut))
							{
								this._window.updateLog("外部出力ブロックの設定を変更");
							}
							else if (block.GetType() == typeof(ProgramModule.BlockJump))
							{
								this._window.updateLog("ジャンプブロックの設定を変更");
							}
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
							this._window.addHistory(true);
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

		// Token: 0x060005FF RID: 1535 RVA: 0x0004B474 File Offset: 0x00049674
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

		// Token: 0x06000600 RID: 1536 RVA: 0x0004B554 File Offset: 0x00049754
		private Point getGridPosition(Point position, Size blockSize)
		{
			return this.getAreaPosition(new Point(position.X / 8 * 8 + 1, position.Y / 8 * 8 + 1), blockSize);
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0004B57C File Offset: 0x0004977C
		private Point getAreaPosition(Point position, Size blockSize)
		{
			if (this._window.IsBlockMode)
			{
				return new Point(Math.Max(0, Math.Min(NetworkFlowchartArea.AREA_SIZE_BLOCK.Width - blockSize.Width, position.X)), Math.Max(0, Math.Min(NetworkFlowchartArea.AREA_SIZE_BLOCK.Height - blockSize.Height, position.Y)));
			}
			return new Point(Math.Max(0, Math.Min(NetworkFlowchartArea.AREA_SIZE.Width - blockSize.Width, position.X)), Math.Max(0, Math.Min(NetworkFlowchartArea.AREA_SIZE.Height - blockSize.Height, position.Y)));
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0004B640 File Offset: 0x00049840
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

		// Token: 0x06000603 RID: 1539 RVA: 0x0004B825 File Offset: 0x00049A25
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0004B844 File Offset: 0x00049A44
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040004A0 RID: 1184
		public const int GRID_SIZE = 8;

		// Token: 0x040004A1 RID: 1185
		public static readonly Size AREA_SIZE = new Size(1680, 2376);

		// Token: 0x040004A2 RID: 1186
		public static readonly Size AREA_SIZE_BLOCK = new Size(3360, 4752);

		// Token: 0x040004A3 RID: 1187
		private NetworkWindow _window;

		// Token: 0x040004A4 RID: 1188
		private ProgramModule _program;

		// Token: 0x040004A5 RID: 1189
		private NetworkFlowchartArea.DRAG _drag;

		// Token: 0x040004A6 RID: 1190
		private Point _dragBefore;

		// Token: 0x040004A7 RID: 1191
		private Point _dragPoint = Point.Empty;

		// Token: 0x040004A8 RID: 1192
		private ProgramModule.Block _dragBlock;

		// Token: 0x040004A9 RID: 1193
		private ProgramModule.Block.CONNECT_BLOCK _connectIndex = ProgramModule.Block.CONNECT_BLOCK.INVALID;

		// Token: 0x040004AA RID: 1194
		private ProgramModule.Block _connectBlock;

		// Token: 0x040004AB RID: 1195
		private ProgramModule.Block.CONNECT_POINT _dragConnectPoint = ProgramModule.Block.CONNECT_POINT.NONE;

		// Token: 0x040004AC RID: 1196
		private ProgramModule.Block _dragConnectBlock;

		// Token: 0x040004AD RID: 1197
		private ProgramModule.Block _dragConnectTargetBlock;

		// Token: 0x040004AE RID: 1198
		private List<ProgramModule.Block> _drawBlocks = new List<ProgramModule.Block>();

		// Token: 0x040004AF RID: 1199
		private bool _grid = true;

		// Token: 0x040004B0 RID: 1200
		private bool _detail = true;

		// Token: 0x040004B1 RID: 1201
		private bool _displayControl = true;

		// Token: 0x040004B2 RID: 1202
		private Rectangle _selectRect;

		// Token: 0x040004B3 RID: 1203
		private ToolTip _toolTip;

		// Token: 0x040004B4 RID: 1204
		private bool _toolTipEnable;

		// Token: 0x040004B5 RID: 1205
		private IContainer components;

		// Token: 0x020000A4 RID: 164
		public enum ALIGNMENT
		{
			// Token: 0x0400088A RID: 2186
			LEFT,
			// Token: 0x0400088B RID: 2187
			RIGHT,
			// Token: 0x0400088C RID: 2188
			UP,
			// Token: 0x0400088D RID: 2189
			BOTTOM
		}

		// Token: 0x020000A5 RID: 165
		public enum DIRECT
		{
			// Token: 0x0400088F RID: 2191
			RIGHT,
			// Token: 0x04000890 RID: 2192
			BOTTOM,
			// Token: 0x04000891 RID: 2193
			RIGHT_BOTTOM
		}

		// Token: 0x020000A6 RID: 166
		public enum DRAG
		{
			// Token: 0x04000893 RID: 2195
			NONE,
			// Token: 0x04000894 RID: 2196
			SELECT,
			// Token: 0x04000895 RID: 2197
			BLOCK,
			// Token: 0x04000896 RID: 2198
			CONNECT
		}
	}
}
