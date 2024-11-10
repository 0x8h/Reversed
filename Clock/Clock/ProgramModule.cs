using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200001A RID: 26
	public class ProgramModule
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x0001BD43 File Offset: 0x00019F43
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x0001BD4B File Offset: 0x00019F4B
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x0001BD54 File Offset: 0x00019F54
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x0001BD5C File Offset: 0x00019F5C
		[XmlArrayItem(typeof(ProgramModule.BlockStart))]
		[XmlArrayItem(typeof(ProgramModule.BlockEnd))]
		[XmlArrayItem(typeof(ProgramModule.BlockLED))]
		[XmlArrayItem(typeof(ProgramModule.BlockSound))]
		[XmlArrayItem(typeof(ProgramModule.BlockWait))]
		[XmlArrayItem(typeof(ProgramModule.BlockLoopStart))]
		[XmlArrayItem(typeof(ProgramModule.BlockLoopEnd))]
		[XmlArrayItem(typeof(ProgramModule.BlockWaitCondition))]
		[XmlArrayItem(typeof(ProgramModule.BlockIf))]
		[XmlArrayItem(typeof(ProgramModule.BlockArithmetic))]
		[XmlArrayItem(typeof(ProgramModule.BlockCounter))]
		[XmlArrayItem(typeof(ProgramModule.BlockSubroutine))]
		[XmlArrayItem(typeof(ProgramModule.BlockDisplay))]
		[XmlArrayItem(typeof(ProgramModule.BlockEvent))]
		[XmlArrayItem(typeof(ProgramModule.BlockMessage))]
		[XmlArrayItem(typeof(ProgramModule.BlockCommunication))]
		[XmlArrayItem(typeof(ProgramModule.BlockData))]
		[XmlArrayItem(typeof(ProgramModule.BlockNetworkDisplay))]
		[XmlArrayItem(typeof(ProgramModule.BlockNetworkSound))]
		[XmlArrayItem(typeof(ProgramModule.BlockOutput))]
		[XmlArrayItem(typeof(ProgramModule.BlockUsbOut))]
		[XmlArrayItem(typeof(ProgramModule.BlockBranch))]
		[XmlArrayItem(typeof(ProgramModule.BlockJump))]
		[XmlArrayItem(typeof(ProgramModule.BlockLabel))]
		public List<ProgramModule.Block> Blocks
		{
			get
			{
				return this._blocks;
			}
			set
			{
				this._blocks = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x0001BD65 File Offset: 0x00019F65
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x0001BD73 File Offset: 0x00019F73
		[XmlIgnore]
		public ProgramModule.BlockStart Start
		{
			get
			{
				return this._starts[0];
			}
			set
			{
				this._starts.Clear();
				this._starts.Add(value);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x0001BD8C File Offset: 0x00019F8C
		[XmlIgnore]
		public List<ProgramModule.BlockStart> Starts
		{
			get
			{
				return this._starts;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x0001BD94 File Offset: 0x00019F94
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x0001BDA2 File Offset: 0x00019FA2
		[XmlIgnore]
		public ProgramModule.BlockEnd End
		{
			get
			{
				return this._ends[0];
			}
			set
			{
				this._ends.Clear();
				this._ends.Add(value);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x0001BDBB File Offset: 0x00019FBB
		// (set) Token: 0x060001CA RID: 458 RVA: 0x0001BDC3 File Offset: 0x00019FC3
		[XmlIgnore]
		public List<ProgramModule.BlockEnd> Ends
		{
			get
			{
				return this._ends;
			}
			set
			{
				this._ends = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060001CB RID: 459 RVA: 0x0001BDCC File Offset: 0x00019FCC
		// (set) Token: 0x060001CC RID: 460 RVA: 0x0001BDD3 File Offset: 0x00019FD3
		[XmlIgnore]
		public static ProgramModule.Block SelectLoopBlock
		{
			get
			{
				return ProgramModule._selectLoopBlock;
			}
			set
			{
				ProgramModule._selectLoopBlock = value;
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0001BE10 File Offset: 0x0001A010
		public void initialize(bool preConnect = false, ProgramModule.BlockEvent.OBJECT_TYPE eventBlockObjectType = ProgramModule.BlockEvent.OBJECT_TYPE.INVALID)
		{
			this.removeAllBlocks();
			this._starts.Clear();
			if (eventBlockObjectType == ProgramModule.BlockEvent.OBJECT_TYPE.INVALID)
			{
				ProgramModule.BlockStart blockStart = new ProgramModule.BlockStart();
				blockStart.updateBlock();
				this._starts.Add(blockStart);
			}
			else
			{
				ProgramModule.BlockEvent blockEvent = new ProgramModule.BlockEvent(eventBlockObjectType);
				if (NetworkWindow.Instance != null && NetworkWindow.Instance.IsBlockMode)
				{
					blockEvent.createBlockControls();
				}
				else
				{
					blockEvent.updateBlock();
				}
				this._starts.Add(blockEvent);
			}
			this.End = new ProgramModule.BlockEnd();
			this.End.updateBlock();
			this._blocks.Add(this._starts[0]);
			this._blocks.Add(this.End);
			if (preConnect)
			{
				this._starts[0].setConnect(ProgramModule.Block.CONNECT_POINT.NONE, this.End);
				this.End.Before = this._starts[0];
				this.updateConnectState();
			}
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0001BEF8 File Offset: 0x0001A0F8
		public void updateVersion(int version)
		{
			foreach (ProgramModule.Block block in this._blocks)
			{
				block.updateVersion(version);
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0001BF4C File Offset: 0x0001A14C
		public byte[] serializeBinary(ProgramModules.ROUTINE routine, byte[] routineAddresses, ref List<ProgramModule.Block> connectBlocks)
		{
			int num = this.getUsedMemory(false);
			connectBlocks = this.getConnectBlocks(false);
			if (routine != ProgramModules.ROUTINE.MAIN)
			{
				connectBlocks.Remove(this._starts[0]);
				num -= 2;
			}
			if (routine != ProgramModules.ROUTINE.MAIN && this._starts[0].Next != this.End)
			{
				connectBlocks.Remove(this._starts[0].Next);
				connectBlocks.Insert(0, this._starts[0].Next);
			}
			connectBlocks.Remove(this.End);
			connectBlocks.Add(this.End);
			byte[] array = new byte[num];
			byte[] array2 = new byte[connectBlocks.Count];
			int num2 = 0;
			for (int i = 0; i < connectBlocks.Count; i++)
			{
				array2[i] = (byte)(num2 + (int)routineAddresses[(int)routine]);
				byte[] array3 = connectBlocks[i].serializeBinary();
				for (int j = 0; j < array3.Length; j++)
				{
					array[num2 + j] = array3[j];
				}
				num2 += array3.Length;
			}
			for (int k = 0; k < connectBlocks.Count; k++)
			{
				ProgramModule.Block block = connectBlocks[k];
				if (block.GetType() != typeof(ProgramModule.BlockEnd))
				{
					array[(int)(array2[k] - routineAddresses[(int)routine] + 1)] = array2[connectBlocks.IndexOf(block.Next)];
					if (block.GetType() == typeof(ProgramModule.BlockWaitCondition))
					{
						array[(int)(array2[k] - routineAddresses[(int)routine] + 2)] = array2[k] - routineAddresses[(int)routine];
					}
					else if (block.GetType() == typeof(ProgramModule.BlockIf))
					{
						ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block;
						array[(int)(array2[k] - routineAddresses[(int)routine] + 2)] = array2[connectBlocks.IndexOf(blockIf.Else)];
					}
					else if (block.GetType() == typeof(ProgramModule.BlockSubroutine))
					{
						ProgramModule.BlockSubroutine blockSubroutine = (ProgramModule.BlockSubroutine)block;
						array[(int)(array2[k] - routineAddresses[(int)routine] + 2)] = routineAddresses[blockSubroutine.Index + 1];
					}
				}
			}
			return array;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0001C15E File Offset: 0x0001A35E
		public void addBlock(ProgramModule.Block block)
		{
			this._blocks.Add(block);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0001C16C File Offset: 0x0001A36C
		public void removeBlock(ProgramModule.Block block, bool reconnect)
		{
			if (reconnect)
			{
				foreach (ProgramModule.BlockStart blockStart in this._starts)
				{
					if (blockStart.Next == block)
					{
						if (block.Next == block)
						{
							blockStart.Next = null;
						}
						else
						{
							blockStart.Next = block.Next;
						}
					}
				}
				foreach (ProgramModule.Block block2 in this._blocks)
				{
					if (block2.Next == block)
					{
						if (block.Next == block)
						{
							block2.Next = null;
						}
						else
						{
							block2.Next = block.Next;
						}
					}
					if (block2.GetType() == typeof(ProgramModule.BlockIf))
					{
						ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block2;
						if (blockIf.Else == block)
						{
							blockIf.Else = block.Next;
						}
					}
				}
			}
			if (block is ProgramModule.BlockStart)
			{
				this._starts.Remove(block as ProgramModule.BlockStart);
			}
			this._blocks.Remove(block);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0001C2A4 File Offset: 0x0001A4A4
		public void removeBlockBlock(ProgramModule.Block block)
		{
			if (block is ProgramModule.BlockStart)
			{
				this._starts.Remove(block as ProgramModule.BlockStart);
			}
			this._blocks.Remove(block);
			if (block is ProgramModule.BlockLabel)
			{
				this.updateLabels();
			}
			if (block.Before == null)
			{
				if (block.Next != null)
				{
					block.Next.Before = null;
				}
			}
			else
			{
				block.Before.Next = block.Next;
				if (block.Next != null)
				{
					block.Next.Before = block.Before;
				}
			}
			List<ProgramModule.BlockBranch> list = this.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockBranch>().ToList<ProgramModule.BlockBranch>();
			if (block.Before == null)
			{
				bool flag = false;
				using (List<ProgramModule.BlockBranch>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProgramModule.BlockBranch blockBranch = enumerator.Current;
						for (int i = 0; i < blockBranch.Branches.Count; i++)
						{
							if (blockBranch.Branches[i] == block)
							{
								blockBranch.Branches[i] = block.Next;
								ProgramModule.Block first = blockBranch.First;
								first.updateLocation(first.LocationBlock.X);
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					return;
				}
			}
			ProgramModule.Block topBlock = this.getTopBlock(block.Before.First, list);
			topBlock.updateLocation(topBlock.LocationBlock.X);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0001C430 File Offset: 0x0001A630
		public ProgramModule.Block getTopBlock(ProgramModule.Block first, List<ProgramModule.BlockBranch> branchBlocks)
		{
			foreach (ProgramModule.BlockBranch blockBranch in branchBlocks)
			{
				for (int i = 0; i < blockBranch.Branches.Count; i++)
				{
					if (blockBranch.Branches[i] == first)
					{
						return this.getTopBlock(blockBranch.First, branchBlocks);
					}
				}
			}
			return first;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0001C4B0 File Offset: 0x0001A6B0
		public void removeAllBlocks()
		{
			this._blocks.Clear();
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0001C4C0 File Offset: 0x0001A6C0
		public void clearSelect()
		{
			foreach (ProgramModule.Block block in this._blocks)
			{
				block.Selected = false;
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0001C514 File Offset: 0x0001A714
		public List<ProgramModule.Block> getSelectBlocks()
		{
			List<ProgramModule.Block> list = new List<ProgramModule.Block>();
			foreach (ProgramModule.Block block in this._blocks)
			{
				if (block.Selected)
				{
					list.Add(block);
				}
			}
			return list;
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0001C578 File Offset: 0x0001A778
		public List<ProgramModule.Block> getSelectLoopBlockPair()
		{
			List<ProgramModule.Block> list = new List<ProgramModule.Block>();
			if (ProgramModule._selectLoopBlock != null)
			{
				if (ProgramModule._selectLoopBlock.GetType() == typeof(ProgramModule.BlockLoopStart))
				{
					List<ProgramModule.Block> list2 = new List<ProgramModule.Block>();
					ProgramModule.BlockLoopStart blockLoopStart = (ProgramModule.BlockLoopStart)ProgramModule._selectLoopBlock;
					this.getSelectLoopBlockPairLoopStart(blockLoopStart, ProgramModule._selectLoopBlock.Next, ref list2, ref list);
				}
				else if (ProgramModule._selectLoopBlock.GetType() == typeof(ProgramModule.BlockLoopEnd))
				{
					foreach (ProgramModule.Block block in this._blocks)
					{
						if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
						{
							List<ProgramModule.Block> list3 = new List<ProgramModule.Block>();
							ProgramModule.BlockLoopStart blockLoopStart2 = (ProgramModule.BlockLoopStart)block;
							ProgramModule.Block selectLoopBlockPairLoopEnd = this.getSelectLoopBlockPairLoopEnd(blockLoopStart2, blockLoopStart2.Next, (ProgramModule.BlockLoopEnd)ProgramModule._selectLoopBlock, ref list3);
							if (selectLoopBlockPairLoopEnd != null)
							{
								list.Add(selectLoopBlockPairLoopEnd);
								break;
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0001C690 File Offset: 0x0001A890
		private void getSelectLoopBlockPairLoopStart(ProgramModule.BlockLoopStart blockLoopStart, ProgramModule.Block current, ref List<ProgramModule.Block> blocks, ref List<ProgramModule.Block> results)
		{
			while (current != null)
			{
				if (blocks.IndexOf(current) != -1)
				{
					return;
				}
				blocks.Add(current);
				if (current.GetType() == typeof(ProgramModule.BlockIf))
				{
					ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)current;
					this.getSelectLoopBlockPairLoopStart(blockLoopStart, blockIf.Else, ref blocks, ref results);
				}
				if (current.GetType() == typeof(ProgramModule.BlockLoopEnd))
				{
					ProgramModule.BlockLoopEnd blockLoopEnd = (ProgramModule.BlockLoopEnd)current;
					if (blockLoopEnd.Index == blockLoopStart.Index)
					{
						results.Add(blockLoopEnd);
						return;
					}
					if (blockLoopEnd.Index == blockLoopStart.Index)
					{
						return;
					}
				}
				current = current.Next;
			}
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0001C738 File Offset: 0x0001A938
		private ProgramModule.BlockLoopStart getSelectLoopBlockPairLoopEnd(ProgramModule.BlockLoopStart blockLoopStart, ProgramModule.Block current, ProgramModule.BlockLoopEnd blockLoopEnd, ref List<ProgramModule.Block> blocks)
		{
			while (current != null)
			{
				if (blocks.IndexOf(current) != -1)
				{
					return null;
				}
				blocks.Add(current);
				if (current.GetType() == typeof(ProgramModule.BlockLoopEnd))
				{
					if (current == blockLoopEnd && blockLoopStart.Index == blockLoopEnd.Index)
					{
						return blockLoopStart;
					}
					if (((ProgramModule.BlockLoopEnd)current).Index == blockLoopStart.Index)
					{
						return null;
					}
				}
				if (current.GetType() == typeof(ProgramModule.BlockIf))
				{
					ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)current;
					ProgramModule.Block selectLoopBlockPairLoopEnd = this.getSelectLoopBlockPairLoopEnd(blockLoopStart, blockIf.Else, blockLoopEnd, ref blocks);
					if (selectLoopBlockPairLoopEnd != null)
					{
						return (ProgramModule.BlockLoopStart)selectLoopBlockPairLoopEnd;
					}
				}
				current = current.Next;
			}
			return null;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0001C7EC File Offset: 0x0001A9EC
		public ProgramModule.ERROR convertToIconProgram()
		{
			ProgramModule.ERROR error = this.checkConnectError();
			if (error == ProgramModule.ERROR.NONE)
			{
				for (ProgramModule.Block block = this._starts[0].Next; block != null; block = block.Next)
				{
					if (!block.isIconBlock())
					{
						return ProgramModule.ERROR.INVALID_BLOCK;
					}
				}
				ProgramModule.Block block2 = this._starts[0];
				for (ProgramModule.Block block3 = this._starts[0].Next; block3 != null; block3 = block3.Next)
				{
					if (block3.GetType() == typeof(ProgramModule.BlockIf))
					{
						ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block3;
						ProgramModule.BlockWaitCondition blockWaitCondition = new ProgramModule.BlockWaitCondition();
						blockIf.convertToBlockWaitCondition(blockWaitCondition);
						block2.Next = blockWaitCondition;
						this._blocks.Insert(this._blocks.IndexOf(block3), blockWaitCondition);
						this._blocks.Remove(block3);
						block3 = blockWaitCondition;
					}
					block2 = block3;
				}
			}
			return error;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0001C8BC File Offset: 0x0001AABC
		public void convertToFlowchartProgram()
		{
			if (this._blocks.Count > 2)
			{
				ProgramModule.Block block = this._starts[0];
				int num = 0;
				for (ProgramModule.Block block2 = this._starts[0].Next; block2 != this.End; block2 = block2.Next)
				{
					if (block2.GetType() == typeof(ProgramModule.BlockWaitCondition))
					{
						ProgramModule.BlockWaitCondition blockWaitCondition = (ProgramModule.BlockWaitCondition)block2;
						ProgramModule.BlockIf blockIf = new ProgramModule.BlockIf();
						blockWaitCondition.convertToBlockIf(blockIf);
						block.Next = blockIf;
						this._blocks.Insert(this._blocks.IndexOf(block2), blockIf);
						this._blocks.Remove(block2);
						block2 = blockIf;
					}
					block = block2;
					num++;
				}
				this.alignmentBlocks(true);
			}
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0001C974 File Offset: 0x0001AB74
		public void alignmentBlocks(bool connectCheck)
		{
			int num = this._blocks.Count - 2;
			int num2 = (num + 4 - 1) / 4;
			int num3 = 4;
			if (num2 > 23)
			{
				num2 = 23;
				num3 = (num + 23 - 1) / 23;
			}
			this.End.Location = new Point(ProgramModule.BlockEnd.INITIAL_LOCATION.X + (num3 - 4) * ProgramModule.Block.BLOCK_SIZE.Width * 2, ProgramModule.BlockEnd.INITIAL_LOCATION.Y + (num2 - 4) * ProgramModule.Block.BLOCK_SIZE.Height * 2);
			int num4 = 0;
			if (connectCheck)
			{
				List<ProgramModule.Block> list = new List<ProgramModule.Block>();
				ProgramModule.Block block = this._starts[0].Next;
				while (block != this.End)
				{
					block.Location = new Point(ProgramModule.BlockStart.INITIAL_LOCATION.X + num4 / num2 * ProgramModule.Block.BLOCK_SIZE.Width * 2, 10 + (num4 % num2 + 1) * ProgramModule.Block.BLOCK_SIZE.Height * 2);
					list.Add(block);
					num4++;
					if (list.Contains(block.Next))
					{
						if (block.Next is ProgramModule.BlockIf)
						{
							block = ((ProgramModule.BlockIf)block.Next).Else;
						}
					}
					else
					{
						block = block.Next;
					}
				}
				return;
			}
			foreach (ProgramModule.Block block2 in this._blocks)
			{
				if (block2.GetType() != typeof(ProgramModule.BlockStart) && block2.GetType() != typeof(ProgramModule.BlockEnd))
				{
					block2.Location = new Point(ProgramModule.BlockStart.INITIAL_LOCATION.X + num4 / num2 * ProgramModule.Block.BLOCK_SIZE.Width * 2, 10 + (num4 % num2 + 1) * ProgramModule.Block.BLOCK_SIZE.Height * 2);
					num4++;
				}
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0001CB70 File Offset: 0x0001AD70
		public List<ProgramModule.Block> getSortedList(bool isBlockMode)
		{
			List<ProgramModule.Block> list = new List<ProgramModule.Block>();
			foreach (ProgramModule.BlockStart blockStart in this._starts)
			{
				this.getSortedList(blockStart, ref list, isBlockMode);
			}
			return list;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0001CBD0 File Offset: 0x0001ADD0
		private void getSortedList(ProgramModule.Block start, ref List<ProgramModule.Block> sortedList, bool isBlockMode)
		{
			ProgramModule.Block block = start;
			while (block != null && sortedList.IndexOf(block) < 0)
			{
				sortedList.Add(block);
				if (isBlockMode)
				{
					if (block is ProgramModule.BlockBranch)
					{
						ProgramModule.BlockBranch blockBranch = (ProgramModule.BlockBranch)block;
						if (blockBranch.Branches[0] != null)
						{
							this.getSortedList(blockBranch.Branches[0], ref sortedList, isBlockMode);
						}
						if (blockBranch.Branches.Count > 1 && blockBranch.Branches[1] != null)
						{
							this.getSortedList(blockBranch.Branches[1], ref sortedList, isBlockMode);
						}
					}
				}
				else if (block is ProgramModule.BlockIf)
				{
					ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block;
					this.getSortedList(blockIf.Else, ref sortedList, isBlockMode);
				}
				block = block.Next;
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0001CC8C File Offset: 0x0001AE8C
		public void getProgram(ref List<string> codeList, ref List<ProgramModule.Block> blockList)
		{
			this._starts[0].getProgram(blockList, codeList, 0);
			if (this.End.ConnectState == ProgramModule.Block.CONNECT_STATE.RIGHT)
			{
				if (blockList.Last<ProgramModule.Block>().GetType() != typeof(ProgramModule.BlockIf) && codeList.Last<string>().IndexOf("[end]") >= 0)
				{
					int num = codeList[codeList.Count - 1].LastIndexOf("\r\n");
					codeList[codeList.Count - 1] = codeList.Last<string>().Substring(0, num);
				}
				codeList.Add("END()");
				for (int i = 0; i < codeList.Count; i++)
				{
					codeList[i] = codeList[i].Replace("[end]", (codeList.Count - 1).ToString());
				}
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0001CD74 File Offset: 0x0001AF74
		public void createBlockControls()
		{
			foreach (ProgramModule.Block block in this._blocks)
			{
				block.createBlockControls();
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0001CDC4 File Offset: 0x0001AFC4
		public void destroyBlockControls()
		{
			foreach (ProgramModule.Block block in this._blocks)
			{
				block.destroyBlockControls();
			}
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0001CE14 File Offset: 0x0001B014
		public void convertBlock()
		{
			this._blocks = this.getConnectBlocks(false);
			for (int i = 1; i < this._starts.Count; i++)
			{
				ProgramModule.BlockEnd blockEnd = new ProgramModule.BlockEnd();
				List<ProgramModule.Block> list = new List<ProgramModule.Block>();
				this._starts[i].getBlockList(list);
				foreach (ProgramModule.Block block in list)
				{
					if (block.Next is ProgramModule.BlockEnd)
					{
						block.Next = blockEnd;
					}
					if (block is ProgramModule.BlockIf)
					{
						ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block;
						if (blockIf.Else is ProgramModule.BlockEnd)
						{
							blockIf.Else = blockEnd;
						}
					}
				}
				this._blocks.Add(blockEnd);
				this._ends.Add(blockEnd);
			}
			List<ProgramModule.Block> list2 = new List<ProgramModule.Block>();
			List<ProgramModule.Block> list3 = new List<ProgramModule.Block>();
			foreach (ProgramModule.BlockStart blockStart in this._starts)
			{
				blockStart.convertBlock(list2, list3);
			}
			foreach (ProgramModule.Block block2 in this._blocks.ToArray())
			{
				if (block2 is ProgramModule.BlockLoopEnd)
				{
					this._blocks.Remove(block2);
				}
			}
			foreach (ProgramModule.Block block3 in this._blocks)
			{
				if (block3 is ProgramModule.BlockEnd && block3.Next != null)
				{
					ProgramModule.BlockJump blockJump = new ProgramModule.BlockJump();
					list3.Add(blockJump);
					blockJump.JumpTemp = block3;
					blockJump.Before = block3.Before;
					blockJump.Before.Next = blockJump;
					blockJump.Next = block3.Next;
					blockJump.Next.Before = blockJump;
					ProgramModule.Block last = block3.Next.Last;
					block3.Before = last;
					block3.Before.Next = block3;
					block3.Next = null;
				}
			}
			foreach (ProgramModule.BlockJump blockJump2 in list3.ToArray())
			{
				if (blockJump2.JumpTemp is ProgramModule.BlockLoopEnd)
				{
					List<ProgramModule.BlockLoopStart> list4 = this._blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLoopStart>().ToList<ProgramModule.BlockLoopStart>();
					ProgramModule.BlockLoopStart blockLoopStart = null;
					foreach (ProgramModule.BlockLoopStart blockLoopStart2 in list4)
					{
						if (blockLoopStart2.BlockLoopEnd == blockJump2.JumpTemp)
						{
							blockLoopStart = blockLoopStart2;
							break;
						}
					}
					ProgramModule.Block last2 = blockLoopStart.Branches[0].Last;
					if (last2 is ProgramModule.BlockLabel)
					{
						blockJump2.Label = (ProgramModule.BlockLabel)last2;
					}
					else
					{
						ProgramModule.BlockLabel blockLabel = new ProgramModule.BlockLabel();
						list3.Add(blockLabel);
						blockJump2.Label = blockLabel;
						blockLabel.Before = last2;
						blockLabel.Before.Next = blockLabel;
					}
				}
				else
				{
					if (!(blockJump2.JumpTemp.Before is ProgramModule.BlockLabel))
					{
						ProgramModule.BlockLabel blockLabel2 = new ProgramModule.BlockLabel();
						list3.Add(blockLabel2);
						blockJump2.Label = blockLabel2;
						blockLabel2.Before = blockJump2.JumpTemp.Before;
						if (blockLabel2.Before == null)
						{
							using (List<ProgramModule.BlockBranch>.Enumerator enumerator4 = this.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockBranch>().ToList<ProgramModule.BlockBranch>()
								.GetEnumerator())
							{
								while (enumerator4.MoveNext())
								{
									ProgramModule.BlockBranch blockBranch = enumerator4.Current;
									bool flag = false;
									for (int k = 0; k < blockBranch.Branches.Count; k++)
									{
										if (blockBranch.Branches[k] == blockJump2.JumpTemp)
										{
											blockBranch.Branches[k] = blockLabel2;
											flag = true;
											break;
										}
									}
									if (flag)
									{
										break;
									}
								}
								goto IL_44C;
							}
							goto IL_43E;
						}
						goto IL_43E;
						IL_44C:
						blockLabel2.Next = blockJump2.JumpTemp;
						blockLabel2.Next.Before = blockLabel2;
						goto IL_468;
						IL_43E:
						blockLabel2.Before.Next = blockLabel2;
						goto IL_44C;
					}
					blockJump2.Label = (ProgramModule.BlockLabel)blockJump2.JumpTemp.Before;
				}
				IL_468:;
			}
			List<ProgramModule.BlockJump> list5 = list3.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockJump>().ToList<ProgramModule.BlockJump>();
			foreach (ProgramModule.BlockJump blockJump3 in list5)
			{
				if (blockJump3.Label == blockJump3.Next)
				{
					list3.Remove(blockJump3);
					blockJump3.Before.Next = blockJump3.Next;
					blockJump3.Next.Before = blockJump3.Before;
				}
			}
			list5 = list3.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockJump>().ToList<ProgramModule.BlockJump>();
			List<ProgramModule.BlockLabel> list6 = list3.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>();
			foreach (ProgramModule.BlockLabel blockLabel3 in list6)
			{
				bool flag2 = false;
				using (List<ProgramModule.BlockJump>.Enumerator enumerator5 = list5.GetEnumerator())
				{
					while (enumerator5.MoveNext())
					{
						if (enumerator5.Current.Label == blockLabel3)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (!flag2)
				{
					list3.Remove(blockLabel3);
					blockLabel3.Before.Next = blockLabel3.Next;
					if (blockLabel3.Next != null)
					{
						blockLabel3.Next.Before = blockLabel3.Before;
					}
					foreach (ProgramModule.BlockJump blockJump4 in list5)
					{
						if (blockJump4.Label.Label > blockLabel3.Label)
						{
							blockJump4.Label.Label--;
						}
					}
					foreach (ProgramModule.BlockLabel blockLabel4 in list6)
					{
						if (blockLabel4.Label > blockLabel3.Label)
						{
							blockLabel4.Label--;
						}
					}
					ProgramModule.BlockLabel.LabelIndexCount--;
				}
			}
			list6 = list3.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>();
			foreach (ProgramModule.BlockLabel blockLabel5 in list6)
			{
				blockLabel5.createBlockControls();
				this._blocks.Add(blockLabel5);
			}
			foreach (ProgramModule.BlockJump blockJump5 in list5)
			{
				blockJump5.createBlockControls();
				this._blocks.Add(blockJump5);
			}
			foreach (ProgramModule.BlockStart blockStart2 in this._starts)
			{
				blockStart2.updateLocation(blockStart2.LocationBlock.X);
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0001D71C File Offset: 0x0001B91C
		public void convertFlowchart()
		{
			this._blocks = this.getConnectBlocks(true);
			for (int i = 1; i < this._starts.Count; i++)
			{
				this._ends[i].Before.Next = this._ends[0];
				this._blocks.Remove(this._ends[i]);
			}
			if (this._ends.Count > 1)
			{
				this._ends.RemoveRange(1, this._starts.Count - 1);
			}
			List<ProgramModule.Block> list = new List<ProgramModule.Block>();
			foreach (ProgramModule.BlockStart blockStart in this._starts)
			{
				blockStart.convertFlowchart(list);
			}
			foreach (ProgramModule.Block block in this._blocks.ToArray())
			{
				if (block is ProgramModule.BlockJump || block is ProgramModule.BlockLabel)
				{
					this._blocks.Remove(block);
				}
				else if (block is ProgramModule.BlockLoopStart)
				{
					ProgramModule.BlockLoopStart blockLoopStart = (ProgramModule.BlockLoopStart)block;
					this._blocks.Add(blockLoopStart.BlockLoopEnd);
				}
			}
			foreach (ProgramModule.Block block2 in this._blocks)
			{
				if (!this._blocks.Contains(block2.Next))
				{
					block2.Next = null;
				}
				if (block2 is ProgramModule.BlockLoopStart)
				{
					ProgramModule.BlockLoopStart blockLoopStart2 = (ProgramModule.BlockLoopStart)block2;
					if (blockLoopStart2.Next == null)
					{
						blockLoopStart2.Next = blockLoopStart2.BlockLoopEnd;
					}
					blockLoopStart2.BlockLoopEnd = null;
				}
				if (block2 is ProgramModule.BlockBranch)
				{
					ProgramModule.BlockBranch blockBranch = (ProgramModule.BlockBranch)block2;
					for (int k = 0; k < blockBranch.Branches.Count; k++)
					{
						if (!this._blocks.Contains(blockBranch.Branches[k]))
						{
							blockBranch.Branches[k] = null;
						}
					}
				}
			}
			this.updateLoopIndex();
			bool flag = true;
			foreach (ProgramModule.Block block3 in this._blocks)
			{
				if (!(block3 is ProgramModule.BlockStart) && !(block3 is ProgramModule.BlockEnd) && block3.Location != Point.Empty)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				this.alignmentBlocks(true);
			}
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0001D9C4 File Offset: 0x0001BBC4
		public ProgramModule.BlockBranch getParentBlock(ProgramModule.Block block)
		{
			ProgramModule.Block first = block.First;
			foreach (ProgramModule.BlockBranch blockBranch in this.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockBranch>().ToList<ProgramModule.BlockBranch>())
			{
				for (int i = 0; i < blockBranch.Branches.Count; i++)
				{
					if (blockBranch.Branches[i] == first)
					{
						return blockBranch;
					}
				}
			}
			return null;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0001DA74 File Offset: 0x0001BC74
		public void updateLabels()
		{
			foreach (ProgramModule.Block block in this._blocks)
			{
				if (block is ProgramModule.BlockJump)
				{
					((ProgramModule.BlockJump)block).updateLabels();
				}
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0001DAD4 File Offset: 0x0001BCD4
		public int getUsedMemory(bool isblockMode)
		{
			int num = 0;
			foreach (ProgramModule.Block block in this.getConnectBlocks(isblockMode))
			{
				num += block.getUsedMemory();
			}
			return num;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0001DB30 File Offset: 0x0001BD30
		public ProgramModule.ERROR getError(ProgramModule[] programs, bool connectCheck)
		{
			ProgramModule.ERROR error = ProgramModule.ERROR.NONE;
			if (connectCheck)
			{
				error = this.checkConnectError();
			}
			if (error == ProgramModule.ERROR.NONE)
			{
				List<ProgramModule.BlockLoopStart> list = new List<ProgramModule.BlockLoopStart>();
				List<ProgramModule.Block> list2 = new List<ProgramModule.Block>();
				List<ProgramModule.BlockSubroutine> list3 = new List<ProgramModule.BlockSubroutine>();
				error = this.checkLoopError(programs, this._starts[0].Next, list, list2, list3, 0);
			}
			return error;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0001DB80 File Offset: 0x0001BD80
		public ProgramModule.ERROR getError(bool connectCheck, bool loopCheck, bool jumpCheck)
		{
			ProgramModule.ERROR error = ProgramModule.ERROR.NONE;
			if (connectCheck)
			{
				error = this.checkConnectError();
			}
			if (error == ProgramModule.ERROR.NONE && jumpCheck)
			{
				error = this.checkJumpError();
			}
			if (error == ProgramModule.ERROR.NONE && loopCheck)
			{
				List<ProgramModule.BlockLoopStart> list = new List<ProgramModule.BlockLoopStart>();
				List<ProgramModule.Block> list2 = new List<ProgramModule.Block>();
				foreach (ProgramModule.BlockStart blockStart in this._starts)
				{
					error = this.checkLoopError(blockStart.Next, list, list2);
					if (error != ProgramModule.ERROR.NONE)
					{
						break;
					}
				}
			}
			return error;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0001DC14 File Offset: 0x0001BE14
		public ProgramModule.ERROR checkConnectError()
		{
			ProgramModule.ERROR error = ProgramModule.ERROR.NONE;
			using (List<ProgramModule.BlockEnd>.Enumerator enumerator = this.Ends.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.ConnectState != ProgramModule.Block.CONNECT_STATE.RIGHT)
					{
						error = ProgramModule.ERROR.CONNECT;
					}
				}
			}
			if (error == ProgramModule.ERROR.NONE)
			{
				List<ProgramModule.Block> list = new List<ProgramModule.Block>();
				foreach (ProgramModule.Block block in this.Blocks)
				{
					if (block.ConnectState == ProgramModule.Block.CONNECT_STATE.RIGHT && !(block is ProgramModule.BlockEnd))
					{
						list.Add(block);
					}
				}
				foreach (ProgramModule.Block block2 in list)
				{
					if (block2.Next == null || block2.Next.ConnectState != ProgramModule.Block.CONNECT_STATE.RIGHT)
					{
						error = ProgramModule.ERROR.CONNECT;
						break;
					}
					if (block2.GetType() == typeof(ProgramModule.BlockIf))
					{
						ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block2;
						if (blockIf.Branches == null && (blockIf.Else == null || blockIf.Else.ConnectState != ProgramModule.Block.CONNECT_STATE.RIGHT))
						{
							error = ProgramModule.ERROR.CONNECT;
							break;
						}
					}
					else if (block2 is ProgramModule.BlockJump && ((ProgramModule.BlockJump)block2).Label == null)
					{
						error = ProgramModule.ERROR.CONNECT;
						break;
					}
				}
			}
			return error;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0001DD8C File Offset: 0x0001BF8C
		public ProgramModule.ERROR checkJumpError()
		{
			foreach (ProgramModule.Block block in this._starts)
			{
				List<ProgramModule.Block> list = new List<ProgramModule.Block>();
				block.getBlockList(list);
				List<ProgramModule.BlockJump> list2 = list.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockJump>().ToList<ProgramModule.BlockJump>();
				List<ProgramModule.BlockLabel> list3 = list.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>();
				foreach (ProgramModule.BlockJump blockJump in list2)
				{
					if (!list3.Contains(blockJump.Label))
					{
						return ProgramModule.ERROR.JUMP;
					}
				}
			}
			return ProgramModule.ERROR.NONE;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0001DE98 File Offset: 0x0001C098
		public ProgramModule.ERROR checkLoopError(ProgramModule[] programs, ProgramModule.Block block, List<ProgramModule.BlockLoopStart> loopBlocks, List<ProgramModule.Block> checkedBlocks, List<ProgramModule.BlockSubroutine> subroutineBlocks, int routineStartLoopCount = 0)
		{
			int count = loopBlocks.Count;
			ProgramModule.ERROR error = ProgramModule.ERROR.NONE;
			while (block != this.End)
			{
				if (block == null)
				{
					error = ProgramModule.ERROR.CONNECT;
					break;
				}
				if (checkedBlocks.IndexOf(block) != -1)
				{
					if (block.LoopBlockCount != loopBlocks.Count)
					{
						error = ProgramModule.ERROR.LOOP_MISMATCH;
						break;
					}
					break;
				}
				else
				{
					block.LoopBlockCount = loopBlocks.Count;
					checkedBlocks.Add(block);
					if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
					{
						ProgramModule.BlockLoopStart blockLoopStart = (ProgramModule.BlockLoopStart)block;
						if (loopBlocks.Count == 6)
						{
							error = ProgramModule.ERROR.LOOP_RANK_OVER;
							break;
						}
						if (loopBlocks.IndexOf(blockLoopStart) != -1)
						{
							error = ProgramModule.ERROR.LOOP_MISMATCH;
							break;
						}
						loopBlocks.Add(blockLoopStart);
					}
					else if (block.GetType() == typeof(ProgramModule.BlockLoopEnd))
					{
						if (loopBlocks.Count == 0)
						{
							error = ProgramModule.ERROR.LOOP_MISMATCH;
							break;
						}
						loopBlocks.RemoveAt(loopBlocks.Count - 1);
					}
					else if (block.GetType() == typeof(ProgramModule.BlockIf))
					{
						ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block;
						List<ProgramModule.BlockLoopStart> list = new List<ProgramModule.BlockLoopStart>(loopBlocks);
						List<ProgramModule.BlockSubroutine> list2 = new List<ProgramModule.BlockSubroutine>(subroutineBlocks);
						error = this.checkLoopError(programs, blockIf.Next, loopBlocks, checkedBlocks, subroutineBlocks, routineStartLoopCount);
						if (error != ProgramModule.ERROR.NONE)
						{
							break;
						}
						error = this.checkLoopError(programs, blockIf.Else, list, checkedBlocks, list2, routineStartLoopCount);
						if (error == ProgramModule.ERROR.NONE)
						{
							return error;
						}
						break;
					}
					else if (block.GetType() == typeof(ProgramModule.BlockSubroutine))
					{
						ProgramModule.BlockSubroutine blockSubroutine = (ProgramModule.BlockSubroutine)block;
						foreach (ProgramModule.BlockSubroutine blockSubroutine2 in subroutineBlocks)
						{
							if (blockSubroutine == blockSubroutine2)
							{
								error = ProgramModule.ERROR.INFINITY;
								break;
							}
						}
						if (error == ProgramModule.ERROR.NONE)
						{
							subroutineBlocks.Add(blockSubroutine);
							List<ProgramModule.BlockLoopStart> list3 = new List<ProgramModule.BlockLoopStart>(loopBlocks);
							List<ProgramModule.Block> list4 = new List<ProgramModule.Block>();
							List<ProgramModule.BlockSubroutine> list5 = new List<ProgramModule.BlockSubroutine>(subroutineBlocks);
							ProgramModule.Block next = programs[blockSubroutine.Index + 1]._starts[0].Next;
							if (next != null)
							{
								error = programs[blockSubroutine.Index + 1].checkLoopError(programs, next, list3, list4, list5, list3.Count);
								if (error != ProgramModule.ERROR.NONE)
								{
									break;
								}
							}
						}
					}
					block = block.Next;
				}
			}
			if (error == ProgramModule.ERROR.NONE)
			{
				if (block == this.End)
				{
					if (loopBlocks.Count != routineStartLoopCount)
					{
						error = ProgramModule.ERROR.LOOP_MISMATCH;
					}
				}
				else if (loopBlocks.Count != count)
				{
					error = ProgramModule.ERROR.LOOP_MISMATCH;
				}
			}
			return error;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0001E0F4 File Offset: 0x0001C2F4
		public ProgramModule.ERROR checkLoopError(ProgramModule.Block block, List<ProgramModule.BlockLoopStart> loopBlocks, List<ProgramModule.Block> checkedBlocks)
		{
			int count = loopBlocks.Count;
			ProgramModule.ERROR error = ProgramModule.ERROR.NONE;
			while (block != this.End)
			{
				if (block == null)
				{
					error = ProgramModule.ERROR.CONNECT;
					break;
				}
				if (checkedBlocks.IndexOf(block) != -1)
				{
					if (block.LoopBlockCount != loopBlocks.Count)
					{
						error = ProgramModule.ERROR.LOOP_MISMATCH;
						break;
					}
					break;
				}
				else
				{
					block.LoopBlockCount = loopBlocks.Count;
					checkedBlocks.Add(block);
					if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
					{
						ProgramModule.BlockLoopStart blockLoopStart = (ProgramModule.BlockLoopStart)block;
						if (loopBlocks.Count == 6)
						{
							error = ProgramModule.ERROR.LOOP_RANK_OVER;
							break;
						}
						if (loopBlocks.IndexOf(blockLoopStart) != -1)
						{
							error = ProgramModule.ERROR.LOOP_MISMATCH;
							break;
						}
						loopBlocks.Add(blockLoopStart);
					}
					else if (block.GetType() == typeof(ProgramModule.BlockLoopEnd))
					{
						if (loopBlocks.Count == 0)
						{
							error = ProgramModule.ERROR.LOOP_MISMATCH;
							break;
						}
						loopBlocks.RemoveAt(loopBlocks.Count - 1);
					}
					else if (block.GetType() == typeof(ProgramModule.BlockIf))
					{
						ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block;
						List<ProgramModule.BlockLoopStart> list = new List<ProgramModule.BlockLoopStart>(loopBlocks);
						error = this.checkLoopError(blockIf.Next, loopBlocks, checkedBlocks);
						if (error != ProgramModule.ERROR.NONE)
						{
							break;
						}
						error = this.checkLoopError(blockIf.Else, list, checkedBlocks);
						if (error == ProgramModule.ERROR.NONE)
						{
							return error;
						}
						break;
					}
					block = block.Next;
				}
			}
			if (error == ProgramModule.ERROR.NONE)
			{
				if (block == this.End)
				{
					if (loopBlocks.Count != 0)
					{
						error = ProgramModule.ERROR.LOOP_MISMATCH;
					}
				}
				else if (loopBlocks.Count != count)
				{
					error = ProgramModule.ERROR.LOOP_MISMATCH;
				}
			}
			return error;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0001E254 File Offset: 0x0001C454
		public void updateConnectState()
		{
			foreach (ProgramModule.Block block in this._blocks)
			{
				block.ConnectState = ProgramModule.Block.CONNECT_STATE.ERROR;
			}
			foreach (ProgramModule.Block block2 in this._starts)
			{
				List<ProgramModule.Block> list = new List<ProgramModule.Block>();
				block2.updateConnectState(list);
				List<ProgramModule.Block> list2 = new List<ProgramModule.Block>();
				bool flag = false;
				using (List<ProgramModule.Block>.Enumerator enumerator = this._blocks.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProgramModule.Block block3 = enumerator.Current;
						if (block3.ConnectState == ProgramModule.Block.CONNECT_STATE.START)
						{
							list2.Add(block3);
							flag = true;
						}
					}
					goto IL_F7;
				}
				goto IL_A7;
				IL_F7:
				if (!flag)
				{
					continue;
				}
				IL_A7:
				flag = false;
				for (int i = list2.Count - 1; i >= 0; i--)
				{
					ProgramModule.Block block4 = list2[i];
					if (block4.Next != null && block4.Next.ConnectState == ProgramModule.Block.CONNECT_STATE.RIGHT)
					{
						block4.ConnectState = ProgramModule.Block.CONNECT_STATE.RIGHT;
						list2.Remove(block4);
						flag = true;
					}
				}
				goto IL_F7;
			}
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0001E3A0 File Offset: 0x0001C5A0
		public List<ProgramModule.Block> getConnectBlocks(bool isBlockMode)
		{
			List<ProgramModule.Block> list = new List<ProgramModule.Block>();
			if (isBlockMode)
			{
				using (List<ProgramModule.BlockStart>.Enumerator enumerator = this._starts.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProgramModule.Block block = enumerator.Current;
						List<ProgramModule.Block> list2 = new List<ProgramModule.Block>();
						block.getBlockList(list2);
						list.AddRange(list2);
					}
					return list;
				}
			}
			foreach (ProgramModule.Block block2 in this._blocks)
			{
				if (block2.ConnectState == ProgramModule.Block.CONNECT_STATE.RIGHT)
				{
					list.Add(block2);
				}
			}
			return list;
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0001E458 File Offset: 0x0001C658
		public void updateLoopIndex()
		{
			List<ProgramModule.Block> list = new List<ProgramModule.Block>();
			List<ProgramModule.Block> list2 = new List<ProgramModule.Block>();
			foreach (ProgramModule.BlockStart blockStart in this._starts)
			{
				this.updateLoopIndex(list, list2, blockStart);
			}
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0001E4BC File Offset: 0x0001C6BC
		private void updateLoopIndex(List<ProgramModule.Block> checkedBlocks, List<ProgramModule.Block> loopBlocks, ProgramModule.Block block)
		{
			while (block != null && checkedBlocks.IndexOf(block) == -1)
			{
				checkedBlocks.Add(block);
				if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
				{
					loopBlocks.Add(block);
					((ProgramModule.BlockLoopStart)block).Index = loopBlocks.IndexOf(block) + 1;
				}
				else if (block.GetType() == typeof(ProgramModule.BlockLoopEnd))
				{
					int i;
					for (i = loopBlocks.Count - 1; i >= 0; i--)
					{
						if (loopBlocks[i].GetType() == typeof(ProgramModule.BlockLoopStart))
						{
							loopBlocks[i] = block;
							break;
						}
					}
					((ProgramModule.BlockLoopEnd)block).Index = i + 1;
				}
				else if (block.GetType() == typeof(ProgramModule.BlockIf))
				{
					ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block;
					if (blockIf.Else != null)
					{
						List<ProgramModule.Block> list = new List<ProgramModule.Block>(loopBlocks);
						this.updateLoopIndex(checkedBlocks, list, blockIf.Else);
					}
				}
				block = block.Next;
			}
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0001E5C4 File Offset: 0x0001C7C4
		public void saveConnectIndex(List<ProgramModule.Block> blocks, bool isBlockMode = false)
		{
			if (isBlockMode)
			{
				using (List<ProgramModule.Block>.Enumerator enumerator = blocks.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProgramModule.Block block = enumerator.Current;
						if (block.Next == null)
						{
							block.ConnectIndex = -1;
						}
						else
						{
							block.ConnectIndex = blocks.IndexOf(block.Next);
							if (block.ConnectIndex >= 0)
							{
								block.Next = null;
							}
						}
						if (block.Before == null)
						{
							block.ConnectIndexBefore = -1;
						}
						else
						{
							block.ConnectIndexBefore = blocks.IndexOf(block.Before);
							if (block.ConnectIndexBefore >= 0)
							{
								block.Before = null;
							}
						}
						if (block is ProgramModule.BlockBranch)
						{
							ProgramModule.BlockBranch blockBranch = (ProgramModule.BlockBranch)block;
							for (int i = 0; i < blockBranch.ConnectIndexBranches.Count; i++)
							{
								if (blockBranch.Branches[i] == null)
								{
									blockBranch.ConnectIndexBranches[i] = -1;
								}
								else
								{
									blockBranch.ConnectIndexBranches[i] = blocks.IndexOf(blockBranch.Branches[i]);
									if (blockBranch.ConnectIndexBranches[i] >= 0)
									{
										blockBranch.Branches[i] = null;
									}
								}
							}
						}
						else if (block is ProgramModule.BlockJump)
						{
							ProgramModule.BlockJump blockJump = (ProgramModule.BlockJump)block;
							if (blockJump.Label == null)
							{
								blockJump.ConnectIndexLabel = -1;
							}
							else
							{
								blockJump.ConnectIndexLabel = blocks.IndexOf(blockJump.Label);
								if (blockJump.ConnectIndexLabel >= 0)
								{
									blockJump.Label = null;
								}
							}
						}
					}
					return;
				}
			}
			foreach (ProgramModule.Block block2 in blocks)
			{
				if (block2.Next == null)
				{
					block2.ConnectIndex = -1;
				}
				else
				{
					block2.ConnectIndex = blocks.IndexOf(block2.Next);
					if (block2.ConnectIndex >= 0)
					{
						block2.Next = null;
					}
				}
				if (block2.GetType() == typeof(ProgramModule.BlockIf))
				{
					ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block2;
					if (blockIf.Else == null)
					{
						blockIf.ConnectIndexElse = -1;
					}
					else
					{
						blockIf.ConnectIndexElse = blocks.IndexOf(blockIf.Else);
						if (blockIf.ConnectIndexElse >= 0)
						{
							blockIf.Else = null;
						}
					}
				}
			}
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0001E830 File Offset: 0x0001CA30
		public void restoreConnectIndex(List<ProgramModule.Block> blocks, bool isBlockMode = false)
		{
			if (isBlockMode)
			{
				using (List<ProgramModule.Block>.Enumerator enumerator = blocks.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProgramModule.Block block = enumerator.Current;
						if (block.ConnectIndex != -1)
						{
							block.Next = blocks[block.ConnectIndex];
							block.ConnectIndex = -1;
						}
						if (block.ConnectIndexBefore != -1)
						{
							block.Before = blocks[block.ConnectIndexBefore];
							block.ConnectIndexBefore = -1;
						}
						if (block is ProgramModule.BlockBranch)
						{
							ProgramModule.BlockBranch blockBranch = (ProgramModule.BlockBranch)block;
							blockBranch.initializeBranches(blockBranch.ConnectIndexBranches.Count);
							for (int i = 0; i < blockBranch.ConnectIndexBranches.Count; i++)
							{
								if (blockBranch.ConnectIndexBranches[i] != -1)
								{
									blockBranch.Branches[i] = blocks[blockBranch.ConnectIndexBranches[i]];
									blockBranch.ConnectIndexBranches[i] = -1;
								}
							}
						}
						else if (block is ProgramModule.BlockJump)
						{
							ProgramModule.BlockJump blockJump = (ProgramModule.BlockJump)block;
							if (blockJump.ConnectIndexLabel != -1)
							{
								blockJump.Label = (ProgramModule.BlockLabel)blocks[blockJump.ConnectIndexLabel];
								blockJump.ConnectIndexLabel = -1;
							}
						}
					}
					return;
				}
			}
			foreach (ProgramModule.Block block2 in blocks)
			{
				if (block2.ConnectIndex != -1)
				{
					block2.Next = blocks[block2.ConnectIndex];
					block2.ConnectIndex = -1;
				}
				if (block2.GetType() == typeof(ProgramModule.BlockIf))
				{
					ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block2;
					if (blockIf.ConnectIndexElse != -1)
					{
						blockIf.Else = blocks[blockIf.ConnectIndexElse];
						blockIf.ConnectIndexElse = -1;
					}
				}
			}
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0001EA34 File Offset: 0x0001CC34
		public void clearUpdated()
		{
			foreach (ProgramModule.Block block in this.Blocks)
			{
				block.Updated = false;
				if (block is ProgramModule.BlockLoopStart && ((ProgramModule.BlockLoopStart)block).BlockLoopEnd != null)
				{
					((ProgramModule.BlockLoopStart)block).BlockLoopEnd.Updated = false;
				}
			}
		}

		// Token: 0x04000202 RID: 514
		public const int USE_MEMORY_MAX = 256;

		// Token: 0x04000203 RID: 515
		public const int NAME_LENGTH_MAX = 7;

		// Token: 0x04000204 RID: 516
		public const int LOOP_NEST_MAX = 6;

		// Token: 0x04000205 RID: 517
		public static readonly string[] ERROR_ITEMS = new string[] { "ループの開始、終了が不正です", "ループの入れ子は6階層までです", "接続されていないブロックがあります", "無限ループする可能性があります", "アイコンプログラムでは\r\n使えない命令ブロックが接続されています", "メモリが不足しています", "ジャンプ先のラベルが不正です" };

		// Token: 0x04000206 RID: 518
		public static readonly string[] ERROR_ITEMS_BLOCK = new string[] { "ループの開始、終了が不正です", "ループの入れ子は6階層までです", "ブロックの接続に間違いがあります", "無限ループする可能性があります", "アイコンプログラムでは\r\n使えない命令ブロックが接続されています", "メモリが不足しています", "ジャンプ先のラベルが不正です" };

		// Token: 0x04000207 RID: 519
		public static int ErrorRoutineIndex;

		// Token: 0x04000208 RID: 520
		private string _name = "メイン";

		// Token: 0x04000209 RID: 521
		private List<ProgramModule.Block> _blocks = new List<ProgramModule.Block>();

		// Token: 0x0400020A RID: 522
		private List<ProgramModule.BlockStart> _starts = new List<ProgramModule.BlockStart>();

		// Token: 0x0400020B RID: 523
		private List<ProgramModule.BlockEnd> _ends = new List<ProgramModule.BlockEnd>();

		// Token: 0x0400020C RID: 524
		public const int INVALID_LOOP_INDEX = -1;

		// Token: 0x0400020D RID: 525
		private static ProgramModule.Block _selectLoopBlock = null;

		// Token: 0x0200006F RID: 111
		public class BlockArithmetic : ProgramModule.Block
		{
			// Token: 0x17000449 RID: 1097
			// (get) Token: 0x06000D8E RID: 3470 RVA: 0x000747E6 File Offset: 0x000729E6
			// (set) Token: 0x06000D8F RID: 3471 RVA: 0x000747EE File Offset: 0x000729EE
			public int[] VariableIndex
			{
				get
				{
					return this._variableIndex;
				}
				set
				{
					base.Updated |= this._variableIndex != value;
					this._variableIndex = value;
				}
			}

			// Token: 0x1700044A RID: 1098
			// (get) Token: 0x06000D90 RID: 3472 RVA: 0x00074810 File Offset: 0x00072A10
			// (set) Token: 0x06000D91 RID: 3473 RVA: 0x00074818 File Offset: 0x00072A18
			public int ConstValue
			{
				get
				{
					return this._constValue;
				}
				set
				{
					base.Updated |= this._constValue != value;
					this._constValue = value;
				}
			}

			// Token: 0x1700044B RID: 1099
			// (get) Token: 0x06000D92 RID: 3474 RVA: 0x0007483A File Offset: 0x00072A3A
			// (set) Token: 0x06000D93 RID: 3475 RVA: 0x00074842 File Offset: 0x00072A42
			public ProgramModule.BlockArithmetic.VARIABLE_SECOND Variable
			{
				get
				{
					return this._variable;
				}
				set
				{
					base.Updated |= this._variable != value;
					this._variable = value;
				}
			}

			// Token: 0x1700044C RID: 1100
			// (get) Token: 0x06000D94 RID: 3476 RVA: 0x00074864 File Offset: 0x00072A64
			// (set) Token: 0x06000D95 RID: 3477 RVA: 0x0007486C File Offset: 0x00072A6C
			public ProgramModule.BlockArithmetic.OPERATE Operate
			{
				get
				{
					return this._operate;
				}
				set
				{
					base.Updated |= this._operate != value;
					this._operate = value;
				}
			}

			// Token: 0x06000D96 RID: 3478 RVA: 0x00074890 File Offset: 0x00072A90
			public BlockArithmetic()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000D97 RID: 3479 RVA: 0x00074910 File Offset: 0x00072B10
			public override byte[] serializeBinary()
			{
				byte[] array = new byte[0];
				switch (this._variable)
				{
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.CONST:
					array = new byte[4];
					if (this._operate == ProgramModule.BlockArithmetic.OPERATE.EQUAL)
					{
						array[0] = 79;
					}
					else if (this._operate == ProgramModule.BlockArithmetic.OPERATE.ADD)
					{
						array[0] = 82;
					}
					else
					{
						array[0] = 85;
					}
					array[2] = (byte)this._variableIndex[0];
					array[3] = (byte)this._constValue;
					break;
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.INDEX:
					array = new byte[4];
					if (this._operate == ProgramModule.BlockArithmetic.OPERATE.EQUAL)
					{
						array[0] = 80;
					}
					else if (this._operate == ProgramModule.BlockArithmetic.OPERATE.ADD)
					{
						array[0] = 83;
					}
					else
					{
						array[0] = 86;
					}
					array[2] = (byte)this._variableIndex[0];
					array[3] = (byte)this._variableIndex[1];
					break;
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.TEMPERATURE:
					array = new byte[3];
					if (this._operate == ProgramModule.BlockArithmetic.OPERATE.EQUAL)
					{
						array[0] = 81;
					}
					else if (this._operate == ProgramModule.BlockArithmetic.OPERATE.ADD)
					{
						array[0] = 84;
					}
					else
					{
						array[0] = 87;
					}
					array[2] = (byte)this._variableIndex[0];
					break;
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.LIGHT:
					array = new byte[3];
					if (this._operate == ProgramModule.BlockArithmetic.OPERATE.EQUAL)
					{
						array[0] = 94;
					}
					else if (this._operate == ProgramModule.BlockArithmetic.OPERATE.ADD)
					{
						array[0] = 95;
					}
					else
					{
						array[0] = 96;
					}
					array[2] = (byte)this._variableIndex[0];
					break;
				}
				return array;
			}

			// Token: 0x06000D98 RID: 3480 RVA: 0x00074A44 File Offset: 0x00072C44
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				ProgramModule.Block.COMMAND_NUMBER command_NUMBER = (ProgramModule.Block.COMMAND_NUMBER)bytes[0];
				if ((ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_EQUAL_TEMPERATURE) || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_SECOND_BEGIN)
				{
					this._operate = ProgramModule.BlockArithmetic.OPERATE.EQUAL;
				}
				else if ((ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_ADD_CONST <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_ADD_TEMPERATURE) || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_ADD_LIGHT)
				{
					this._operate = ProgramModule.BlockArithmetic.OPERATE.ADD;
				}
				else
				{
					this._operate = ProgramModule.BlockArithmetic.OPERATE.SUB;
				}
				switch (command_NUMBER)
				{
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_BEGIN:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_ADD_CONST:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_SUB_CONST:
					this._variable = ProgramModule.BlockArithmetic.VARIABLE_SECOND.CONST;
					this._variableIndex[0] = (int)bytes[2];
					this._constValue = (int)((sbyte)bytes[3]);
					break;
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_EQUAL_VARIABLE:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_ADD_VARIABLE:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_SUB_VARIABLE:
					this._variable = ProgramModule.BlockArithmetic.VARIABLE_SECOND.INDEX;
					this._variableIndex[0] = (int)bytes[2];
					this._variableIndex[1] = (int)bytes[3];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_EQUAL_TEMPERATURE:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_ADD_TEMPERATURE:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_SUB_TEMPERATURE:
					this._variable = ProgramModule.BlockArithmetic.VARIABLE_SECOND.TEMPERATURE;
					this._variableIndex[0] = (int)bytes[2];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_SECOND_BEGIN:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_ADD_LIGHT:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_SUB_LIGHT:
					this._variable = ProgramModule.BlockArithmetic.VARIABLE_SECOND.LIGHT;
					this._variableIndex[0] = (int)bytes[2];
					break;
				}
				return true;
			}

			// Token: 0x06000D99 RID: 3481 RVA: 0x00074B43 File Offset: 0x00072D43
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.fc_block_210, base.Location);
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000D9A RID: 3482 RVA: 0x00074B7C File Offset: 0x00072D7C
			public override void paintRect(Graphics graphics, Color color, bool fill)
			{
				Point[] array = new Point[]
				{
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 6, base.Location.Y),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width, base.Location.Y),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width * 5 / 6, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height),
					new Point(base.Location.X, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height)
				};
				if (fill)
				{
					Brush brush = new SolidBrush(color);
					graphics.FillPolygon(brush, array);
					return;
				}
				Pen pen = new Pen(color, 4f);
				graphics.DrawPolygon(pen, array);
			}

			// Token: 0x06000D9B RID: 3483 RVA: 0x00074C94 File Offset: 0x00072E94
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_080, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_081, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_080.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_080.Width - Resources.bp_block_082.Width), (float)Resources.bp_block_081.Height));
					graphics.DrawImage(Resources.bp_block_082, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_082.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_080.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000D9C RID: 3484 RVA: 0x00074E60 File Offset: 0x00073060
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				string text = "";
				base.addIndent(ref text, indent);
				switch (this._variable)
				{
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.CONST:
					text = string.Concat(new string[]
					{
						text,
						ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndex[0]],
						" ",
						ProgramModule.BlockArithmetic.OPERATE_ITEMS[(int)this._operate],
						" ",
						this._constValue.ToString()
					});
					break;
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.INDEX:
					text = string.Concat(new string[]
					{
						text,
						ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndex[0]],
						" ",
						ProgramModule.BlockArithmetic.OPERATE_ITEMS[(int)this._operate],
						" ",
						ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndex[1]]
					});
					break;
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.TEMPERATURE:
					text = string.Concat(new string[]
					{
						text,
						ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndex[0]],
						" ",
						ProgramModule.BlockArithmetic.OPERATE_ITEMS[(int)this._operate],
						" TEMPARATURE"
					});
					break;
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.LIGHT:
					text = string.Concat(new string[]
					{
						text,
						ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndex[0]],
						" ",
						ProgramModule.BlockArithmetic.OPERATE_ITEMS[(int)this._operate],
						" LIGHT"
					});
					break;
				}
				codeList.Add(text);
				base.getProgram(blockList, codeList, indent);
			}

			// Token: 0x06000D9D RID: 3485 RVA: 0x00074FDC File Offset: 0x000731DC
			public override string getDetail()
			{
				string text = "";
				switch (this._variable)
				{
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.CONST:
					text = string.Concat(new string[]
					{
						ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndex[0]],
						" ",
						ProgramModule.BlockArithmetic.OPERATE_ITEMS[(int)this._operate],
						" ",
						this._constValue.ToString()
					});
					break;
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.INDEX:
					text = string.Concat(new string[]
					{
						ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndex[0]],
						" ",
						ProgramModule.BlockArithmetic.OPERATE_ITEMS[(int)this._operate],
						" ",
						ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndex[1]]
					});
					break;
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.TEMPERATURE:
					text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndex[0]] + " " + ProgramModule.BlockArithmetic.OPERATE_ITEMS[(int)this._operate] + " 温度";
					break;
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.LIGHT:
					text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndex[0]] + " " + ProgramModule.BlockArithmetic.OPERATE_ITEMS[(int)this._operate] + " 明るさ";
					break;
				}
				return text;
			}

			// Token: 0x06000D9E RID: 3486 RVA: 0x00075106 File Offset: 0x00073306
			public override string getDetailBlock(bool isPrint)
			{
				if (isPrint)
				{
					return this.getDetail();
				}
				return "\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000";
			}

			// Token: 0x06000D9F RID: 3487 RVA: 0x00075117 File Offset: 0x00073317
			public override int getUsedMemory()
			{
				if (this._variable == ProgramModule.BlockArithmetic.VARIABLE_SECOND.CONST || this._variable == ProgramModule.BlockArithmetic.VARIABLE_SECOND.INDEX)
				{
					return 4;
				}
				return 3;
			}

			// Token: 0x06000DA0 RID: 3488 RVA: 0x0007512D File Offset: 0x0007332D
			public override bool isIconBlock()
			{
				return false;
			}

			// Token: 0x06000DA1 RID: 3489 RVA: 0x00075130 File Offset: 0x00073330
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_040.Width;
					base.Controls[0].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					x += base.Controls[0].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
					base.Controls[1].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					x += base.Controls[1].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
					base.Controls[3].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					base.Controls[2].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					base.Controls[4].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
				}
			}

			// Token: 0x06000DA2 RID: 3490 RVA: 0x00075270 File Offset: 0x00073470
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				ComboBox comboBox = new ComboBox();
				comboBox.Width = 60;
				foreach (string text in ProgramModule.BlockIf.VARIABLE_ITEMS)
				{
					comboBox.Items.Add(text);
				}
				base.Controls.Add(comboBox);
				comboBox = new ComboBox();
				comboBox.Width = 50;
				foreach (string text2 in ProgramModule.BlockArithmetic.OPERATE_ITEMS)
				{
					comboBox.Items.Add(text2);
				}
				base.Controls.Add(comboBox);
				comboBox = new ComboBox();
				comboBox.Width = 60;
				foreach (string text3 in ProgramModule.BlockIf.VARIABLE_ITEMS)
				{
					comboBox.Items.Add(text3);
				}
				base.Controls.Add(comboBox);
				NumericUpDown numericUpDown = new NumericUpDown();
				numericUpDown.Width = 50;
				numericUpDown.Minimum = -128m;
				numericUpDown.Maximum = 127m;
				base.Controls.Add(numericUpDown);
				comboBox = new ComboBox();
				comboBox.Width = 50;
				foreach (string text4 in ProgramModule.BlockArithmetic.OTHER_ITEMS)
				{
					comboBox.Items.Add(text4);
				}
				base.Controls.Add(comboBox);
				this.updateBlock();
				((ComboBox)base.Controls[0]).SelectedValueChanged += this.comboBoxVariableLeft_SelectedValueChanged;
				((ComboBox)base.Controls[1]).SelectedValueChanged += this.comboBoxOperator_SelectedValueChanged;
				((ComboBox)base.Controls[2]).SelectedValueChanged += this.comboBoxVariableRight_SelectedValueChanged;
				((NumericUpDown)base.Controls[3]).ValueChanged += this.numericUpDownConst_ValueChanged;
				((ComboBox)base.Controls[4]).SelectedValueChanged += this.comboBoxOther_SelectedValueChanged;
			}

			// Token: 0x06000DA3 RID: 3491 RVA: 0x00075470 File Offset: 0x00073670
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					int num = Resources.bp_block_040.Width + base.Controls[0].Width + base.Controls[1].Width + Resources.bp_block_042.Width;
					switch (this.Variable)
					{
					case ProgramModule.BlockArithmetic.VARIABLE_SECOND.CONST:
						num += base.Controls[3].Width;
						((NumericUpDown)base.Controls[3]).Value = this.ConstValue;
						break;
					case ProgramModule.BlockArithmetic.VARIABLE_SECOND.INDEX:
						num += base.Controls[2].Width;
						((ComboBox)base.Controls[2]).SelectedIndex = this.VariableIndex[1];
						break;
					case ProgramModule.BlockArithmetic.VARIABLE_SECOND.TEMPERATURE:
						num += base.Controls[4].Width;
						((ComboBox)base.Controls[4]).SelectedIndex = 0;
						break;
					case ProgramModule.BlockArithmetic.VARIABLE_SECOND.LIGHT:
						num += base.Controls[4].Width;
						((ComboBox)base.Controls[4]).SelectedIndex = 1;
						break;
					}
					((ComboBox)base.Controls[0]).SelectedIndex = this.VariableIndex[0];
					((ComboBox)base.Controls[1]).SelectedIndex = (int)this.Operate;
				}
			}

			// Token: 0x06000DA4 RID: 3492 RVA: 0x000755F0 File Offset: 0x000737F0
			public override void updateControlVisible(List<Rectangle> rects)
			{
				base.updateControlVisible(rects);
				switch (this._variable)
				{
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.CONST:
					base.Controls[2].Visible = false;
					base.Controls[4].Visible = false;
					return;
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.INDEX:
					base.Controls[3].Visible = false;
					base.Controls[4].Visible = false;
					return;
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.TEMPERATURE:
				case ProgramModule.BlockArithmetic.VARIABLE_SECOND.LIGHT:
					base.Controls[3].Visible = false;
					base.Controls[2].Visible = false;
					return;
				default:
					return;
				}
			}

			// Token: 0x06000DA5 RID: 3493 RVA: 0x00075690 File Offset: 0x00073890
			private void comboBoxVariableLeft_SelectedValueChanged(object sender, EventArgs e)
			{
				this.VariableIndex[0] = ((ComboBox)base.Controls[0]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000DA6 RID: 3494 RVA: 0x000756B6 File Offset: 0x000738B6
			private void comboBoxOperator_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Operate = (ProgramModule.BlockArithmetic.OPERATE)((ComboBox)base.Controls[1]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000DA7 RID: 3495 RVA: 0x000756DA File Offset: 0x000738DA
			private void comboBoxVariableRight_SelectedValueChanged(object sender, EventArgs e)
			{
				this.VariableIndex[1] = ((ComboBox)base.Controls[2]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000DA8 RID: 3496 RVA: 0x00075700 File Offset: 0x00073900
			private void comboBoxOther_SelectedValueChanged(object sender, EventArgs e)
			{
				ProgramModule.BlockArithmetic.OTHER selectedIndex = (ProgramModule.BlockArithmetic.OTHER)((ComboBox)base.Controls[4]).SelectedIndex;
				if (selectedIndex != ProgramModule.BlockArithmetic.OTHER.TEMPERATURE)
				{
					if (selectedIndex == ProgramModule.BlockArithmetic.OTHER.LIGHT)
					{
						this.Variable = ProgramModule.BlockArithmetic.VARIABLE_SECOND.LIGHT;
					}
				}
				else
				{
					this.Variable = ProgramModule.BlockArithmetic.VARIABLE_SECOND.TEMPERATURE;
				}
				base.addHistory();
			}

			// Token: 0x06000DA9 RID: 3497 RVA: 0x00075743 File Offset: 0x00073943
			private void numericUpDownConst_ValueChanged(object sender, EventArgs e)
			{
				this.ConstValue = (int)((NumericUpDown)base.Controls[3]).Value;
				base.addHistory();
			}

			// Token: 0x04000732 RID: 1842
			public const int USE_MEMORY_MAX = 4;

			// Token: 0x04000733 RID: 1843
			private static readonly string[] OTHER_ITEMS = new string[] { "温度", "明るさ" };

			// Token: 0x04000734 RID: 1844
			public static readonly string[] OPERATE_ITEMS = new string[] { "＝", "＋＝", "－＝" };

			// Token: 0x04000735 RID: 1845
			private int[] _variableIndex = new int[2];

			// Token: 0x04000736 RID: 1846
			private int _constValue;

			// Token: 0x04000737 RID: 1847
			private ProgramModule.BlockArithmetic.VARIABLE_SECOND _variable;

			// Token: 0x04000738 RID: 1848
			private ProgramModule.BlockArithmetic.OPERATE _operate;

			// Token: 0x020000E0 RID: 224
			public enum VARIABLE_INDEX
			{
				// Token: 0x04000980 RID: 2432
				FIRST,
				// Token: 0x04000981 RID: 2433
				SECOND
			}

			// Token: 0x020000E1 RID: 225
			public enum VARIABLE_SECOND
			{
				// Token: 0x04000983 RID: 2435
				CONST,
				// Token: 0x04000984 RID: 2436
				INDEX,
				// Token: 0x04000985 RID: 2437
				TEMPERATURE,
				// Token: 0x04000986 RID: 2438
				LIGHT
			}

			// Token: 0x020000E2 RID: 226
			public enum OPERATE
			{
				// Token: 0x04000988 RID: 2440
				EQUAL,
				// Token: 0x04000989 RID: 2441
				ADD,
				// Token: 0x0400098A RID: 2442
				SUB,
				// Token: 0x0400098B RID: 2443
				MAX
			}

			// Token: 0x020000E3 RID: 227
			private enum CONTROL
			{
				// Token: 0x0400098D RID: 2445
				COMBOBOX_VARIABLE_LEFT,
				// Token: 0x0400098E RID: 2446
				COMBOBOX_OPERATOR,
				// Token: 0x0400098F RID: 2447
				COMBOBOX_VARIABLE_RIGHT,
				// Token: 0x04000990 RID: 2448
				NUMERIC_CONST_VALUE,
				// Token: 0x04000991 RID: 2449
				COMBOBOX_OTHER,
				// Token: 0x04000992 RID: 2450
				MAX
			}

			// Token: 0x020000E4 RID: 228
			private enum OTHER
			{
				// Token: 0x04000994 RID: 2452
				TEMPERATURE,
				// Token: 0x04000995 RID: 2453
				LIGHT,
				// Token: 0x04000996 RID: 2454
				MAX
			}
		}

		// Token: 0x02000070 RID: 112
		public class BlockBranch : ProgramModule.Block
		{
			// Token: 0x1700044D RID: 1101
			// (get) Token: 0x06000DAB RID: 3499 RVA: 0x000757AC File Offset: 0x000739AC
			// (set) Token: 0x06000DAC RID: 3500 RVA: 0x000757B4 File Offset: 0x000739B4
			public List<int> ConnectIndexBranches { get; set; }

			// Token: 0x1700044E RID: 1102
			// (get) Token: 0x06000DAD RID: 3501 RVA: 0x000757BD File Offset: 0x000739BD
			// (set) Token: 0x06000DAE RID: 3502 RVA: 0x000757C5 File Offset: 0x000739C5
			[XmlIgnore]
			public List<ProgramModule.Block> Branches { get; protected set; }

			// Token: 0x06000DAF RID: 3503 RVA: 0x000757CE File Offset: 0x000739CE
			public void SetBranch(ProgramModule.Block.CONNECT_BLOCK index, ProgramModule.Block block)
			{
				this.Branches[(int)index] = block;
			}

			// Token: 0x06000DB0 RID: 3504 RVA: 0x000153E3 File Offset: 0x000135E3
			public virtual void initializeBranches(int branchCount)
			{
			}

			// Token: 0x06000DB1 RID: 3505 RVA: 0x000757E0 File Offset: 0x000739E0
			public override void updateLocation(int x)
			{
				base.LineCount = 1;
				foreach (ProgramModule.Block block in this.Branches)
				{
					int num;
					if (block == null)
					{
						num = base.LineCount;
						base.LineCount = num + 1;
					}
					else
					{
						block.LocationBlock = new Point(x + Resources.bp_block_053.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT * base.LineCount);
						block.updateLocation(block.LocationBlock.X);
						for (ProgramModule.Block block2 = block; block2 != null; block2 = block2.Next)
						{
							base.LineCount += block2.LineCount;
						}
					}
					num = base.LineCount;
					base.LineCount = num + 1;
				}
				this.updateBlock();
				base.updateLocation(x);
			}

			// Token: 0x06000DB2 RID: 3506 RVA: 0x000758D4 File Offset: 0x00073AD4
			public override void setControlVisible(bool on)
			{
				base.setControlVisible(on);
				foreach (ProgramModule.Block block in this.Branches)
				{
					if (block != null)
					{
						block.setControlVisible(on);
					}
				}
			}

			// Token: 0x06000DB3 RID: 3507 RVA: 0x00075934 File Offset: 0x00073B34
			public override void updateControlVisible(List<Rectangle> rects)
			{
				base.updateControlVisible(rects);
				foreach (ProgramModule.Block block in this.Branches)
				{
					if (block != null)
					{
						block.updateControlVisible(rects);
					}
				}
			}

			// Token: 0x06000DB4 RID: 3508 RVA: 0x00075994 File Offset: 0x00073B94
			public override ProgramModule.Block.CONNECT_BLOCK IsHit(ProgramModule.Block block)
			{
				Rectangle rectangle = new Rectangle(block.LocationBlock.X, block.LocationBlock.Y - (int)((float)ProgramModule.Block.LINE_HEIGHT * 0.5f), block.SizeBlock.Width, block.SizeBlock.Height + ProgramModule.Block.LINE_HEIGHT);
				if ((base.LocationBlock.X < rectangle.X && rectangle.X < base.LocationBlock.X + base.SizeBlock.Width) || (rectangle.X < base.LocationBlock.X && base.LocationBlock.X < rectangle.X + rectangle.Width))
				{
					if ((base.LocationBlock.Y < rectangle.Y && rectangle.Y < base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT) || (rectangle.Y < base.LocationBlock.Y && base.LocationBlock.Y < rectangle.Y + rectangle.Height))
					{
						if (base.LocationBlock.Y < rectangle.Y)
						{
							return ProgramModule.Block.CONNECT_BLOCK.BRANCH_FIRST;
						}
						return ProgramModule.Block.CONNECT_BLOCK.UP;
					}
					else
					{
						if (base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT < rectangle.Y && rectangle.Y < base.LocationBlock.Y + base.SizeBlock.Height)
						{
							return ProgramModule.Block.CONNECT_BLOCK.DOWN;
						}
						if (this.Branches.Count > 1)
						{
							int num = base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT;
							if (this.Branches[0] == null)
							{
								num += ProgramModule.Block.LINE_HEIGHT;
							}
							else
							{
								num += this.Branches[0].getConnectedBlocksSize().Height;
							}
							if (num < rectangle.Y && rectangle.Y < num + ProgramModule.Block.LINE_HEIGHT)
							{
								return ProgramModule.Block.CONNECT_BLOCK.BRANCH_SECOND;
							}
						}
					}
				}
				return ProgramModule.Block.CONNECT_BLOCK.INVALID;
			}

			// Token: 0x06000DB5 RID: 3509 RVA: 0x00075BBC File Offset: 0x00073DBC
			public override bool isIncludingBlock(Point point)
			{
				if (base.LocationBlock.X <= point.X && point.X <= base.LocationBlock.X + base.SizeBlock.Width && base.LocationBlock.Y <= point.Y && point.Y <= base.LocationBlock.Y + base.SizeBlock.Height)
				{
					if (point.Y <= base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT)
					{
						return true;
					}
					if (base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT <= point.Y)
					{
						return true;
					}
					if (point.X <= base.LocationBlock.X + Resources.bp_block_053.Width)
					{
						return true;
					}
					if (this.Branches.Count > 1)
					{
						int num = ProgramModule.Block.LINE_HEIGHT;
						if (this.Branches[0] == null)
						{
							num += ProgramModule.Block.LINE_HEIGHT;
						}
						else
						{
							num += this.Branches[0].getConnectedBlocksSize().Height;
						}
						if (num <= point.Y && point.Y <= num + ProgramModule.Block.LINE_HEIGHT)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06000DB6 RID: 3510 RVA: 0x00075D28 File Offset: 0x00073F28
			public bool isIncludingBlockUp(Point point)
			{
				return base.LocationBlock.X <= point.X && point.X <= base.LocationBlock.X + base.SizeBlock.Width && base.LocationBlock.Y <= point.Y && point.Y <= base.LocationBlock.Y + base.SizeBlock.Height && point.Y <= base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT;
			}

			// Token: 0x06000DB7 RID: 3511 RVA: 0x00075DD4 File Offset: 0x00073FD4
			public bool isIncludingBlockDown(Point point)
			{
				return base.LocationBlock.X <= point.X && point.X <= base.LocationBlock.X + base.SizeBlock.Width && base.LocationBlock.Y <= point.Y && point.Y <= base.LocationBlock.Y + base.SizeBlock.Height && base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT <= point.Y;
			}

			// Token: 0x06000DB8 RID: 3512 RVA: 0x00075E90 File Offset: 0x00074090
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					foreach (ProgramModule.Block block in this.Branches)
					{
						if (block != null)
						{
							block.OnPaintBlock(graphics, isDetail, index, isPrint);
						}
					}
				}
			}

			// Token: 0x06000DB9 RID: 3513 RVA: 0x00075EFC File Offset: 0x000740FC
			public override void OnPaintBlockSelect(Graphics graphics)
			{
				Pen pen = new Pen(Color.Blue, 2f);
				if (this.Branches.Count == 1)
				{
					graphics.DrawLines(pen, new Point[]
					{
						new Point(base.LocationBlock.X, base.LocationBlock.Y),
						new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y),
						new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT),
						new Point(base.LocationBlock.X + Resources.bp_block_053.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT),
						new Point(base.LocationBlock.X + Resources.bp_block_053.Width, base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT),
						new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT),
						new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + base.SizeBlock.Height),
						new Point(base.LocationBlock.X, base.LocationBlock.Y + base.SizeBlock.Height),
						new Point(base.LocationBlock.X, base.LocationBlock.Y)
					});
					return;
				}
				int num = ((this.Branches[0] == null) ? ProgramModule.Block.LINE_HEIGHT : this.Branches[0].getConnectedBlocksSize().Height);
				graphics.DrawLines(pen, new Point[]
				{
					new Point(base.LocationBlock.X, base.LocationBlock.Y),
					new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y),
					new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT),
					new Point(base.LocationBlock.X + Resources.bp_block_053.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT),
					new Point(base.LocationBlock.X + Resources.bp_block_053.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT + num),
					new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT + num),
					new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT * 2 + num),
					new Point(base.LocationBlock.X + Resources.bp_block_053.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT * 2 + num),
					new Point(base.LocationBlock.X + Resources.bp_block_053.Width, base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT),
					new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT),
					new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + base.SizeBlock.Height),
					new Point(base.LocationBlock.X, base.LocationBlock.Y + base.SizeBlock.Height),
					new Point(base.LocationBlock.X, base.LocationBlock.Y)
				});
			}

			// Token: 0x06000DBA RID: 3514 RVA: 0x00076490 File Offset: 0x00074690
			public override void OnPaintBlockGuide(Graphics graphics, ProgramModule.Block.CONNECT_BLOCK connectBlock)
			{
				Pen pen = new Pen(Color.Blue, 4f);
				if (connectBlock == ProgramModule.Block.CONNECT_BLOCK.BRANCH_FIRST)
				{
					graphics.DrawLine(pen, new Point(base.LocationBlock.X + Resources.bp_block_053.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT), new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT));
					return;
				}
				if (connectBlock == ProgramModule.Block.CONNECT_BLOCK.BRANCH_SECOND)
				{
					int num = base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT * 2;
					if (this.Branches[0] == null)
					{
						num += ProgramModule.Block.LINE_HEIGHT;
					}
					else
					{
						num += this.Branches[0].getConnectedBlocksSize().Height;
					}
					graphics.DrawLine(pen, new Point(base.LocationBlock.X + Resources.bp_block_053.Width, num), new Point(base.LocationBlock.X + base.SizeBlock.Width, num));
					return;
				}
				base.OnPaintBlockGuide(graphics, connectBlock);
			}
		}

		// Token: 0x02000071 RID: 113
		public class BlockCommunication : ProgramModule.Block
		{
			// Token: 0x1700044F RID: 1103
			// (get) Token: 0x06000DBC RID: 3516 RVA: 0x000765CC File Offset: 0x000747CC
			// (set) Token: 0x06000DBD RID: 3517 RVA: 0x000765D4 File Offset: 0x000747D4
			public ProgramModule.BlockCommunication.COMMUNICATION_MODE Mode
			{
				get
				{
					return this._mode;
				}
				set
				{
					base.Updated |= this._mode != value;
					this._mode = value;
				}
			}

			// Token: 0x17000450 RID: 1104
			// (get) Token: 0x06000DBE RID: 3518 RVA: 0x000765F6 File Offset: 0x000747F6
			// (set) Token: 0x06000DBF RID: 3519 RVA: 0x000765FE File Offset: 0x000747FE
			public int VariableIndexDistination
			{
				get
				{
					return this._variableIndexDistination;
				}
				set
				{
					base.Updated |= this._variableIndexDistination != value;
					this._variableIndexDistination = value;
				}
			}

			// Token: 0x17000451 RID: 1105
			// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x00076620 File Offset: 0x00074820
			// (set) Token: 0x06000DC1 RID: 3521 RVA: 0x00076628 File Offset: 0x00074828
			public int VariableIndexSource
			{
				get
				{
					return this._variableIndexSource;
				}
				set
				{
					base.Updated |= this._variableIndexSource != value;
					this._variableIndexSource = value;
				}
			}

			// Token: 0x17000452 RID: 1106
			// (get) Token: 0x06000DC2 RID: 3522 RVA: 0x0007664A File Offset: 0x0007484A
			// (set) Token: 0x06000DC3 RID: 3523 RVA: 0x00076652 File Offset: 0x00074852
			public ProgramModule.BlockCommunication.VARIABLE_TYPE VariableType
			{
				get
				{
					return this._variableType;
				}
				set
				{
					base.Updated |= this._variableType != value;
					this._variableType = value;
				}
			}

			// Token: 0x06000DC4 RID: 3524 RVA: 0x00076674 File Offset: 0x00074874
			public BlockCommunication()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000DC5 RID: 3525 RVA: 0x000766E8 File Offset: 0x000748E8
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					if (this.Mode == ProgramModule.BlockCommunication.COMMUNICATION_MODE.SEND)
					{
						graphics.DrawImage(Resources.nw_block_060, base.Location);
					}
					else
					{
						graphics.DrawImage(Resources.nw_block_070, base.Location);
					}
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000DC6 RID: 3526 RVA: 0x00076748 File Offset: 0x00074948
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_110, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_111, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_110.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_110.Width - Resources.bp_block_112.Width), (float)Resources.bp_block_111.Height));
					graphics.DrawImage(Resources.bp_block_112, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_112.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_110.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000DC7 RID: 3527 RVA: 0x00076914 File Offset: 0x00074B14
			public override string getDetail()
			{
				string text;
				if (this.Mode == ProgramModule.BlockCommunication.COMMUNICATION_MODE.SEND)
				{
					text = "(S)" + NetworkWindow.Instance.Programs.ServerVariableNames[this.VariableIndexDistination] + "に\r\n";
					switch (this.VariableType)
					{
					case ProgramModule.BlockCommunication.VARIABLE_TYPE.INPUT:
					case ProgramModule.BlockCommunication.VARIABLE_TYPE.LIGHT:
					case ProgramModule.BlockCommunication.VARIABLE_TYPE.TEMPERATURE:
					case ProgramModule.BlockCommunication.VARIABLE_TYPE.HARDWARE:
						text = text + ProgramModule.BlockCommunication.VARIABLE_TYPE_ITEMS[(int)this.VariableType] + "を送信";
						break;
					case ProgramModule.BlockCommunication.VARIABLE_TYPE.CLIENT:
						text = text + "(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this.VariableIndexSource] + "を送信";
						break;
					}
				}
				else
				{
					text = string.Concat(new string[]
					{
						"(C)",
						NetworkWindow.Instance.Programs.ClientVariableNames[this.VariableIndexDistination],
						"に\r\n(S)",
						NetworkWindow.Instance.Programs.ServerVariableNames[this.VariableIndexSource],
						"を受信"
					});
				}
				return text;
			}

			// Token: 0x06000DC8 RID: 3528 RVA: 0x00076A24 File Offset: 0x00074C24
			public override string getDetailBlock(bool isPrint)
			{
				string text;
				if (this.Mode == ProgramModule.BlockCommunication.COMMUNICATION_MODE.RECEIVE)
				{
					text = (isPrint ? string.Concat(new string[]
					{
						"(C)",
						NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexDistination],
						"に(S)",
						NetworkWindow.Instance.Programs.ServerVariableNames[this._variableIndexSource],
						"を受信"
					}) : "\u3000\u3000\u3000\u3000に\u3000\u3000\u3000\u3000\u3000を受信");
				}
				else if (isPrint)
				{
					if (this._variableType == ProgramModule.BlockCommunication.VARIABLE_TYPE.CLIENT)
					{
						text = string.Concat(new string[]
						{
							"(S)",
							NetworkWindow.Instance.Programs.ServerVariableNames[this._variableIndexDistination],
							"に(C)",
							NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexSource],
							"を送信"
						});
					}
					else
					{
						text = string.Concat(new string[]
						{
							"(S)",
							NetworkWindow.Instance.Programs.ServerVariableNames[this._variableIndexDistination],
							"に",
							ProgramModule.BlockCommunication.VARIABLE_TYPE_ITEMS[(int)this._variableType],
							"を送信"
						});
					}
				}
				else
				{
					text = "\u3000\u3000\u3000\u3000に\u3000\u3000\u3000\u3000\u3000を送信";
				}
				return text;
			}

			// Token: 0x06000DC9 RID: 3529 RVA: 0x00076B70 File Offset: 0x00074D70
			public override void updateData()
			{
				((ComboBox)base.Controls[0]).Items.Clear();
				foreach (string text in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					((ComboBox)base.Controls[0]).Items.Add("(C)" + text);
				}
				((ComboBox)base.Controls[1]).Items.Clear();
				foreach (string text2 in NetworkWindow.Instance.Programs.ServerVariableNames)
				{
					((ComboBox)base.Controls[1]).Items.Add("(S)" + text2);
				}
				((ComboBox)base.Controls[2]).Items.Clear();
				((ComboBox)base.Controls[2]).Items.Add("入力変数");
				foreach (string text3 in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					((ComboBox)base.Controls[2]).Items.Add("(C)" + text3);
				}
				if (NetworkWindow.Instance.Programs.Level != NetworkProgramModules.LEVEL.LEVEL_1)
				{
					((ComboBox)base.Controls[2]).Items.Add("光センサ値");
					((ComboBox)base.Controls[2]).Items.Add("温度");
				}
			}

			// Token: 0x06000DCA RID: 3530 RVA: 0x00076D88 File Offset: 0x00074F88
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_002.Width;
					ProgramModule.BlockCommunication.COMMUNICATION_MODE mode = this.Mode;
					if (mode != ProgramModule.BlockCommunication.COMMUNICATION_MODE.SEND)
					{
						if (mode == ProgramModule.BlockCommunication.COMMUNICATION_MODE.RECEIVE)
						{
							base.Controls[0].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							x += base.Controls[0].Width + TextRenderer.MeasureText("に", ProgramModule.Block._fontBlock).Width;
							base.Controls[1].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
					}
					else
					{
						base.Controls[1].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
						x += base.Controls[1].Width + TextRenderer.MeasureText("に", ProgramModule.Block._fontBlock).Width;
						base.Controls[2].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					}
				}
			}

			// Token: 0x06000DCB RID: 3531 RVA: 0x00076ED8 File Offset: 0x000750D8
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				ComboBox comboBox = new ComboBox();
				comboBox.Width = 80;
				foreach (string text in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					comboBox.Items.Add("(C)" + text);
				}
				base.Controls.Add(comboBox);
				comboBox = new ComboBox();
				comboBox.Width = 80;
				foreach (string text2 in NetworkWindow.Instance.Programs.ServerVariableNames)
				{
					comboBox.Items.Add("(S)" + text2);
				}
				base.Controls.Add(comboBox);
				comboBox = new ComboBox();
				comboBox.Width = 80;
				comboBox.Items.Add("入力変数");
				foreach (string text3 in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					comboBox.Items.Add("(C)" + text3);
				}
				if (NetworkWindow.Instance.Programs.Level != NetworkProgramModules.LEVEL.LEVEL_1)
				{
					comboBox.Items.Add("光センサ値");
					comboBox.Items.Add("温度");
				}
				base.Controls.Add(comboBox);
				((ComboBox)base.Controls[0]).SelectedValueChanged += this.comboBoxClient_SelectedValueChanged;
				((ComboBox)base.Controls[1]).SelectedValueChanged += this.comboBoxServer_SelectedValueChanged;
				((ComboBox)base.Controls[2]).SelectedValueChanged += this.comboBoxClientAll_SelectedValueChanged;
				this.updateBlock();
			}

			// Token: 0x06000DCC RID: 3532 RVA: 0x00077108 File Offset: 0x00075308
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					if (this.Mode == ProgramModule.BlockCommunication.COMMUNICATION_MODE.RECEIVE)
					{
						((ComboBox)base.Controls[0]).SelectedIndex = this._variableIndexDistination;
						((ComboBox)base.Controls[1]).SelectedIndex = this._variableIndexSource;
						return;
					}
					((ComboBox)base.Controls[1]).SelectedIndex = this._variableIndexDistination;
					((ComboBox)base.Controls[2]).SelectedIndex = BlockPropertyCommunicationDialog.getComboBoxIndex(this._variableType, this._variableIndexSource, NetworkWindow.Instance.Programs);
				}
			}

			// Token: 0x06000DCD RID: 3533 RVA: 0x000771BC File Offset: 0x000753BC
			public void updateLevel()
			{
				if (base.Controls.Count > 0)
				{
					ComboBox comboBox = (ComboBox)base.Controls[2];
					if (NetworkWindow.Instance.Programs.Level == NetworkProgramModules.LEVEL.LEVEL_1)
					{
						if (this.VariableType == ProgramModule.BlockCommunication.VARIABLE_TYPE.LIGHT || this.VariableType == ProgramModule.BlockCommunication.VARIABLE_TYPE.TEMPERATURE)
						{
							comboBox.Enabled = false;
							return;
						}
						comboBox.Enabled = true;
						this.resetComboBoxClientAll();
						return;
					}
					else
					{
						comboBox.Enabled = true;
						this.resetComboBoxClientAll();
					}
				}
			}

			// Token: 0x06000DCE RID: 3534 RVA: 0x00077230 File Offset: 0x00075430
			private void resetComboBoxClientAll()
			{
				ComboBox comboBox = (ComboBox)base.Controls[2];
				int selectedIndex = comboBox.SelectedIndex;
				comboBox.Items.Clear();
				comboBox.Items.Add("入力変数");
				foreach (string text in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					comboBox.Items.Add("(C)" + text);
				}
				if (NetworkWindow.Instance.Programs.Level != NetworkProgramModules.LEVEL.LEVEL_1)
				{
					comboBox.Items.Add("光センサ値");
					comboBox.Items.Add("温度");
				}
				comboBox.SelectedIndex = Math.Min(comboBox.Items.Count - 1, selectedIndex);
			}

			// Token: 0x06000DCF RID: 3535 RVA: 0x00077320 File Offset: 0x00075520
			public override void updateControlVisible(List<Rectangle> rects)
			{
				base.updateControlVisible(rects);
				if (this.Mode == ProgramModule.BlockCommunication.COMMUNICATION_MODE.RECEIVE)
				{
					base.Controls[2].Visible = false;
					return;
				}
				base.Controls[0].Visible = false;
			}

			// Token: 0x06000DD0 RID: 3536 RVA: 0x00077357 File Offset: 0x00075557
			private void comboBoxClient_SelectedValueChanged(object sender, EventArgs e)
			{
				this.VariableIndexDistination = ((ComboBox)base.Controls[0]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000DD1 RID: 3537 RVA: 0x0007737C File Offset: 0x0007557C
			private void comboBoxServer_SelectedValueChanged(object sender, EventArgs e)
			{
				if (this.Mode == ProgramModule.BlockCommunication.COMMUNICATION_MODE.RECEIVE)
				{
					this.VariableIndexSource = ((ComboBox)base.Controls[1]).SelectedIndex;
				}
				else
				{
					this.VariableIndexDistination = ((ComboBox)base.Controls[1]).SelectedIndex;
				}
				base.addHistory();
			}

			// Token: 0x06000DD2 RID: 3538 RVA: 0x000773D4 File Offset: 0x000755D4
			private void comboBoxClientAll_SelectedValueChanged(object sender, EventArgs e)
			{
				int selectedIndex = ((ComboBox)base.Controls[2]).SelectedIndex;
				this.VariableType = BlockPropertyCommunicationDialog.getVariableType(selectedIndex, NetworkWindow.Instance.Programs);
				this.VariableIndexSource = BlockPropertyCommunicationDialog.getVariableIndex(selectedIndex, NetworkWindow.Instance.Programs);
				base.addHistory();
			}

			// Token: 0x0400073B RID: 1851
			public static readonly string[] COMMUNICATION_MODE_ITEMS = new string[] { "送信する", "受信する" };

			// Token: 0x0400073C RID: 1852
			private ProgramModule.BlockCommunication.COMMUNICATION_MODE _mode;

			// Token: 0x0400073D RID: 1853
			private int _variableIndexDistination;

			// Token: 0x0400073E RID: 1854
			private int _variableIndexSource;

			// Token: 0x0400073F RID: 1855
			public static readonly string[] VARIABLE_TYPE_ITEMS = new string[] { "入力変数", "(C)データ", "光センサ値", "温度", "本体変数" };

			// Token: 0x04000740 RID: 1856
			private ProgramModule.BlockCommunication.VARIABLE_TYPE _variableType;

			// Token: 0x020000E5 RID: 229
			public enum COMMUNICATION_MODE
			{
				// Token: 0x04000998 RID: 2456
				SEND,
				// Token: 0x04000999 RID: 2457
				RECEIVE,
				// Token: 0x0400099A RID: 2458
				MAX
			}

			// Token: 0x020000E6 RID: 230
			public enum VARIABLE_TYPE
			{
				// Token: 0x0400099C RID: 2460
				INPUT,
				// Token: 0x0400099D RID: 2461
				CLIENT,
				// Token: 0x0400099E RID: 2462
				LIGHT,
				// Token: 0x0400099F RID: 2463
				TEMPERATURE,
				// Token: 0x040009A0 RID: 2464
				HARDWARE,
				// Token: 0x040009A1 RID: 2465
				MAX
			}

			// Token: 0x020000E7 RID: 231
			private enum CONTROL
			{
				// Token: 0x040009A3 RID: 2467
				COMBOBOX_CLIENT,
				// Token: 0x040009A4 RID: 2468
				COMBOBOX_SERVER,
				// Token: 0x040009A5 RID: 2469
				COMBOBOX_CLIENT_ALL,
				// Token: 0x040009A6 RID: 2470
				MAX
			}
		}

		// Token: 0x02000072 RID: 114
		public class BlockCounter : ProgramModule.Block
		{
			// Token: 0x17000453 RID: 1107
			// (get) Token: 0x06000DD4 RID: 3540 RVA: 0x00077487 File Offset: 0x00075687
			// (set) Token: 0x06000DD5 RID: 3541 RVA: 0x0007748F File Offset: 0x0007568F
			public ProgramModule.BlockCounter.COMMAND Command
			{
				get
				{
					return this._command;
				}
				set
				{
					base.Updated |= this._command != value;
					this._command = value;
				}
			}

			// Token: 0x06000DD6 RID: 3542 RVA: 0x000774B4 File Offset: 0x000756B4
			public BlockCounter()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000DD7 RID: 3543 RVA: 0x00077528 File Offset: 0x00075728
			public override byte[] serializeBinary()
			{
				byte[] array = new byte[2];
				if (this._command == ProgramModule.BlockCounter.COMMAND.START)
				{
					array[0] = 43;
				}
				if (this._command == ProgramModule.BlockCounter.COMMAND.STOP)
				{
					array[0] = 44;
				}
				if (this._command == ProgramModule.BlockCounter.COMMAND.RESET)
				{
					array[0] = 45;
				}
				return array;
			}

			// Token: 0x06000DD8 RID: 3544 RVA: 0x00077568 File Offset: 0x00075768
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				switch (bytes[0])
				{
				case 43:
					this._command = ProgramModule.BlockCounter.COMMAND.START;
					break;
				case 44:
					this._command = ProgramModule.BlockCounter.COMMAND.STOP;
					break;
				case 45:
					this._command = ProgramModule.BlockCounter.COMMAND.RESET;
					break;
				}
				return true;
			}

			// Token: 0x06000DD9 RID: 3545 RVA: 0x000775AA File Offset: 0x000757AA
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.fc_block_060, base.Location);
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000DDA RID: 3546 RVA: 0x000775E4 File Offset: 0x000757E4
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_040, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_041, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_040.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_040.Width - Resources.bp_block_042.Width), (float)Resources.bp_block_041.Height));
					graphics.DrawImage(Resources.bp_block_042, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_042.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_040.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000DDB RID: 3547 RVA: 0x000777B0 File Offset: 0x000759B0
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				string text = "";
				base.addIndent(ref text, indent);
				switch (this._command)
				{
				case ProgramModule.BlockCounter.COMMAND.START:
					text += "COUNTER_START()";
					break;
				case ProgramModule.BlockCounter.COMMAND.STOP:
					text += "COUNTER_STOP()";
					break;
				case ProgramModule.BlockCounter.COMMAND.RESET:
					text += "COUNTER_RESET()";
					break;
				}
				codeList.Add(text);
				base.getProgram(blockList, codeList, indent);
			}

			// Token: 0x06000DDC RID: 3548 RVA: 0x00077820 File Offset: 0x00075A20
			public override string getDetail()
			{
				string text = "";
				switch (this._command)
				{
				case ProgramModule.BlockCounter.COMMAND.START:
					text = "動かす";
					break;
				case ProgramModule.BlockCounter.COMMAND.STOP:
					text = "止める";
					break;
				case ProgramModule.BlockCounter.COMMAND.RESET:
					text = "リセットする";
					break;
				}
				return text;
			}

			// Token: 0x06000DDD RID: 3549 RVA: 0x00077865 File Offset: 0x00075A65
			public override string getDetailBlock(bool isPrint)
			{
				if (isPrint)
				{
					return ProgramModule.BlockCounter.COMMAND_ITEMS[(int)this._command];
				}
				return "\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000";
			}

			// Token: 0x06000DDE RID: 3550 RVA: 0x0007787C File Offset: 0x00075A7C
			public override int getUsedMemory()
			{
				return 2;
			}

			// Token: 0x06000DDF RID: 3551 RVA: 0x0007512D File Offset: 0x0007332D
			public override bool isIconBlock()
			{
				return false;
			}

			// Token: 0x06000DE0 RID: 3552 RVA: 0x00077880 File Offset: 0x00075A80
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					base.Controls[ProgramModule.BlockCounter.CONTROL_COMBOBOX].Location = new Point(base.LocationBlock.X + Resources.bp_block_040.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
				}
			}

			// Token: 0x06000DE1 RID: 3553 RVA: 0x000778EC File Offset: 0x00075AEC
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				ComboBox comboBox = new ComboBox();
				foreach (string text in ProgramModule.BlockCounter.COMMAND_ITEMS)
				{
					comboBox.Items.Add(text);
				}
				base.Controls.Add(comboBox);
				this.updateBlock();
				((ComboBox)base.Controls[ProgramModule.BlockCounter.CONTROL_COMBOBOX]).SelectedValueChanged += this.comboBoxCommand_SelectedValueChanged;
			}

			// Token: 0x06000DE2 RID: 3554 RVA: 0x00077967 File Offset: 0x00075B67
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					((ComboBox)base.Controls[ProgramModule.BlockCounter.CONTROL_COMBOBOX]).SelectedIndex = (int)this._command;
				}
			}

			// Token: 0x06000DE3 RID: 3555 RVA: 0x0007799D File Offset: 0x00075B9D
			private void comboBoxCommand_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Command = (ProgramModule.BlockCounter.COMMAND)((ComboBox)base.Controls[ProgramModule.BlockCounter.CONTROL_COMBOBOX]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x04000741 RID: 1857
			public const int USE_MEMORY_MAX = 2;

			// Token: 0x04000742 RID: 1858
			public const int COUNTER_MAX = 255;

			// Token: 0x04000743 RID: 1859
			public static readonly string[] COMMAND_ITEMS = new string[] { "カウンタを動かす", "カウンタを止める", "カウンタをリセットする" };

			// Token: 0x04000744 RID: 1860
			private static readonly int CONTROL_COMBOBOX = 0;

			// Token: 0x04000745 RID: 1861
			private ProgramModule.BlockCounter.COMMAND _command;

			// Token: 0x020000E8 RID: 232
			public enum COMMAND
			{
				// Token: 0x040009A8 RID: 2472
				START,
				// Token: 0x040009A9 RID: 2473
				STOP,
				// Token: 0x040009AA RID: 2474
				RESET,
				// Token: 0x040009AB RID: 2475
				MAX
			}
		}

		// Token: 0x02000073 RID: 115
		public class BlockData : ProgramModule.Block
		{
			// Token: 0x17000454 RID: 1108
			// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x000779F0 File Offset: 0x00075BF0
			// (set) Token: 0x06000DE6 RID: 3558 RVA: 0x000779F8 File Offset: 0x00075BF8
			public ProgramModule.BlockData.DATA_KIND Kind
			{
				get
				{
					return this._kind;
				}
				set
				{
					base.Updated |= this._kind != value;
					this._kind = value;
				}
			}

			// Token: 0x17000455 RID: 1109
			// (get) Token: 0x06000DE7 RID: 3559 RVA: 0x00077A1A File Offset: 0x00075C1A
			// (set) Token: 0x06000DE8 RID: 3560 RVA: 0x00077A22 File Offset: 0x00075C22
			public ProgramModule.BlockData.DATA_OPERATE Operate
			{
				get
				{
					return this._operate;
				}
				set
				{
					base.Updated |= this._operate != value;
					this._operate = value;
				}
			}

			// Token: 0x17000456 RID: 1110
			// (get) Token: 0x06000DE9 RID: 3561 RVA: 0x00077A44 File Offset: 0x00075C44
			// (set) Token: 0x06000DEA RID: 3562 RVA: 0x00077A4C File Offset: 0x00075C4C
			public ProgramModule.BlockData.CONNECT_DIRECT ConnectDirect
			{
				get
				{
					return this._connectDirect;
				}
				set
				{
					base.Updated |= this._connectDirect != value;
					this._connectDirect = value;
				}
			}

			// Token: 0x17000457 RID: 1111
			// (get) Token: 0x06000DEB RID: 3563 RVA: 0x00077A6E File Offset: 0x00075C6E
			// (set) Token: 0x06000DEC RID: 3564 RVA: 0x00077A76 File Offset: 0x00075C76
			public ProgramModule.BlockData.DATA_VALUE_TYPE ValueType
			{
				get
				{
					return this._valueType;
				}
				set
				{
					base.Updated |= this._valueType != value;
					this._valueType = value;
				}
			}

			// Token: 0x17000458 RID: 1112
			// (get) Token: 0x06000DED RID: 3565 RVA: 0x00077A98 File Offset: 0x00075C98
			// (set) Token: 0x06000DEE RID: 3566 RVA: 0x00077AA0 File Offset: 0x00075CA0
			public ProgramModule.BlockData.DATA_VARIABLE_TYPE VariableType
			{
				get
				{
					return this._variableType;
				}
				set
				{
					base.Updated |= this._variableType != value;
					this._variableType = value;
				}
			}

			// Token: 0x17000459 RID: 1113
			// (get) Token: 0x06000DEF RID: 3567 RVA: 0x00077AC2 File Offset: 0x00075CC2
			// (set) Token: 0x06000DF0 RID: 3568 RVA: 0x00077ACA File Offset: 0x00075CCA
			public int VariableIndexLeft
			{
				get
				{
					return this._variableIndexLeft;
				}
				set
				{
					base.Updated |= this._variableIndexLeft != value;
					this._variableIndexLeft = value;
				}
			}

			// Token: 0x1700045A RID: 1114
			// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x00077AEC File Offset: 0x00075CEC
			// (set) Token: 0x06000DF2 RID: 3570 RVA: 0x00077AF4 File Offset: 0x00075CF4
			public int VariableIndexRight
			{
				get
				{
					return this._variableIndexRight;
				}
				set
				{
					base.Updated |= this._variableIndexRight != value;
					this._variableIndexRight = value;
				}
			}

			// Token: 0x1700045B RID: 1115
			// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x00077B16 File Offset: 0x00075D16
			// (set) Token: 0x06000DF4 RID: 3572 RVA: 0x00077B1E File Offset: 0x00075D1E
			public string ConstString
			{
				get
				{
					return this._constString;
				}
				set
				{
					base.Updated |= this._constString != value;
					this._constString = value;
				}
			}

			// Token: 0x1700045C RID: 1116
			// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x00077B40 File Offset: 0x00075D40
			// (set) Token: 0x06000DF6 RID: 3574 RVA: 0x00077B48 File Offset: 0x00075D48
			public int ConstValue
			{
				get
				{
					return this._constValue;
				}
				set
				{
					base.Updated |= this._constValue != value;
					this._constValue = value;
				}
			}

			// Token: 0x06000DF7 RID: 3575 RVA: 0x00077B6C File Offset: 0x00075D6C
			public BlockData()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000DF8 RID: 3576 RVA: 0x00077BE0 File Offset: 0x00075DE0
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					switch (this.Kind)
					{
					case ProgramModule.BlockData.DATA_KIND.SUBSTITUTION:
						graphics.DrawImage(Resources.nw_block_090, base.Location);
						break;
					case ProgramModule.BlockData.DATA_KIND.ARITHMETIC:
						switch (this.Operate)
						{
						case ProgramModule.BlockData.DATA_OPERATE.ADD:
							graphics.DrawImage(Resources.nw_block_100, base.Location);
							break;
						case ProgramModule.BlockData.DATA_OPERATE.SUB:
							graphics.DrawImage(Resources.nw_block_110, base.Location);
							break;
						case ProgramModule.BlockData.DATA_OPERATE.LEVEL2_MAX:
							graphics.DrawImage(Resources.nw_block_100, base.Location);
							break;
						case ProgramModule.BlockData.DATA_OPERATE.DEVIDE:
							graphics.DrawImage(Resources.nw_block_100, base.Location);
							break;
						}
						break;
					case ProgramModule.BlockData.DATA_KIND.CONNECT:
						graphics.DrawImage(Resources.nw_block_090, base.Location);
						break;
					}
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000DF9 RID: 3577 RVA: 0x00077CC4 File Offset: 0x00075EC4
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_080, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_081, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_080.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_080.Width - Resources.bp_block_082.Width), (float)Resources.bp_block_081.Height));
					graphics.DrawImage(Resources.bp_block_082, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_082.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_080.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000DFA RID: 3578 RVA: 0x00077E90 File Offset: 0x00076090
			public override string getDetail()
			{
				string text = "";
				switch (this.Kind)
				{
				case ProgramModule.BlockData.DATA_KIND.SUBSTITUTION:
					text = "(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this.VariableIndexLeft] + "を\r\n";
					switch (this.ValueType)
					{
					case ProgramModule.BlockData.DATA_VALUE_TYPE.CONST:
						text = text + this.ConstString + "にする";
						break;
					case ProgramModule.BlockData.DATA_VALUE_TYPE.VARIABLE:
						if (this.VariableType == ProgramModule.BlockData.DATA_VARIABLE_TYPE.CLIENT)
						{
							text = text + "(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this.VariableIndexRight] + "にする";
						}
						else
						{
							text += "入力変数にする";
						}
						break;
					case ProgramModule.BlockData.DATA_VALUE_TYPE.TEMPERATURE:
					case ProgramModule.BlockData.DATA_VALUE_TYPE.LIGHT:
						text = text + " " + ProgramModule.BlockData.DATA_VALUE_TYPE_ITEMS[(int)this.ValueType] + "にする";
						break;
					}
					break;
				case ProgramModule.BlockData.DATA_KIND.ARITHMETIC:
					text = "(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this.VariableIndexLeft] + " " + ProgramModule.BlockData.DATA_OPERATE_ITEMS[(int)this.Operate];
					switch (this.ValueType)
					{
					case ProgramModule.BlockData.DATA_VALUE_TYPE.CONST:
						text += string.Format(" {0}", this.ConstValue);
						break;
					case ProgramModule.BlockData.DATA_VALUE_TYPE.VARIABLE:
						text = text + " (C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this.VariableIndexRight];
						break;
					case ProgramModule.BlockData.DATA_VALUE_TYPE.TEMPERATURE:
					case ProgramModule.BlockData.DATA_VALUE_TYPE.LIGHT:
						text = text + " " + ProgramModule.BlockData.DATA_VALUE_TYPE_ITEMS[(int)this.ValueType];
						break;
					}
					break;
				}
				return text;
			}

			// Token: 0x06000DFB RID: 3579 RVA: 0x00078044 File Offset: 0x00076244
			public override string getDetailBlock(bool isPrint)
			{
				string text2;
				if (this._kind == ProgramModule.BlockData.DATA_KIND.SUBSTITUTION)
				{
					if (this._valueType == ProgramModule.BlockData.DATA_VALUE_TYPE.LIGHT || this._valueType == ProgramModule.BlockData.DATA_VALUE_TYPE.TEMPERATURE)
					{
						string text = ((this._valueType == ProgramModule.BlockData.DATA_VALUE_TYPE.LIGHT) ? ProgramModule.BlockData.OTHER_ITEMS[1] : ProgramModule.BlockData.OTHER_ITEMS[0]);
						text2 = (isPrint ? string.Concat(new string[]
						{
							"(C)",
							NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexLeft],
							"を",
							text,
							"にする"
						}) : "\u3000\u3000\u3000\u3000を\u3000\u3000\u3000にする");
					}
					else if (this._valueType == ProgramModule.BlockData.DATA_VALUE_TYPE.CONST)
					{
						text2 = (isPrint ? string.Concat(new string[]
						{
							"(C)",
							NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexLeft],
							"を",
							this._constString,
							"にする"
						}) : "\u3000\u3000\u3000\u3000を\u3000\u3000\u3000\u3000 にする");
					}
					else
					{
						string text3 = ((this._variableIndexRight >= 0) ? ("(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexRight]) : "入力変数");
						text2 = (isPrint ? string.Concat(new string[]
						{
							"(C)",
							NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexLeft],
							"を",
							text3,
							"にする"
						}) : "\u3000\u3000\u3000\u3000を\u3000\u3000\u3000\u3000 にする");
					}
				}
				else if (this._valueType == ProgramModule.BlockData.DATA_VALUE_TYPE.VARIABLE)
				{
					text2 = (isPrint ? string.Concat(new string[]
					{
						"(C)",
						NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexLeft],
						ProgramModule.BlockData.DATA_OPERATE_ITEMS[(int)this._operate],
						"(C)",
						NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexRight]
					}) : "\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000");
				}
				else if (this._valueType == ProgramModule.BlockData.DATA_VALUE_TYPE.CONST)
				{
					text2 = (isPrint ? string.Format("(C){0}{1}{2}", NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexLeft], ProgramModule.BlockData.DATA_OPERATE_ITEMS[(int)this._operate], this._constValue) : "\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000 ");
				}
				else
				{
					string text4 = ((this._valueType == ProgramModule.BlockData.DATA_VALUE_TYPE.LIGHT) ? ProgramModule.BlockData.OTHER_ITEMS[1] : ProgramModule.BlockData.OTHER_ITEMS[0]);
					text2 = (isPrint ? ("(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexLeft] + ProgramModule.BlockData.DATA_OPERATE_ITEMS[(int)this._operate] + text4) : "\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000 ");
				}
				return text2;
			}

			// Token: 0x06000DFC RID: 3580 RVA: 0x000782F0 File Offset: 0x000764F0
			public override void updateData()
			{
				((ComboBox)base.Controls[0]).Items.Clear();
				foreach (string text in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					((ComboBox)base.Controls[0]).Items.Add("(C)" + text);
				}
				((ComboBox)base.Controls[1]).Items.Clear();
				foreach (string text2 in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					((ComboBox)base.Controls[1]).Items.Add("(C)" + text2);
				}
				((ComboBox)base.Controls[2]).Items.Clear();
				((ComboBox)base.Controls[2]).Items.Add("入力変数");
				foreach (string text3 in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					((ComboBox)base.Controls[2]).Items.Add("(C)" + text3);
				}
			}

			// Token: 0x06000DFD RID: 3581 RVA: 0x000784B4 File Offset: 0x000766B4
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_080.Width;
					base.Controls[0].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					x += base.Controls[0].Width;
					ProgramModule.BlockData.DATA_KIND kind = this._kind;
					if (kind == ProgramModule.BlockData.DATA_KIND.SUBSTITUTION)
					{
						x += TextRenderer.MeasureText("を", ProgramModule.Block._fontBlock).Width;
						base.Controls[6].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
						base.Controls[2].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
						base.Controls[4].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
						return;
					}
					if (kind != ProgramModule.BlockData.DATA_KIND.ARITHMETIC)
					{
						return;
					}
					x += ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
					base.Controls[3].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					x += base.Controls[3].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
					base.Controls[5].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					base.Controls[1].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					base.Controls[4].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
				}
			}

			// Token: 0x06000DFE RID: 3582 RVA: 0x000786A8 File Offset: 0x000768A8
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				ComboBox comboBox = new ComboBox();
				comboBox.Width = 80;
				foreach (string text in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					comboBox.Items.Add("(C)" + text);
				}
				base.Controls.Add(comboBox);
				comboBox = new ComboBox();
				comboBox.Width = 80;
				foreach (string text2 in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					comboBox.Items.Add("(C)" + text2);
				}
				base.Controls.Add(comboBox);
				comboBox = new ComboBox();
				comboBox.Width = 80;
				comboBox.Items.Add("入力変数");
				foreach (string text3 in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					comboBox.Items.Add("(C)" + text3);
				}
				base.Controls.Add(comboBox);
				comboBox = new ComboBox();
				comboBox.Width = 50;
				for (int i = 0; i < 2; i++)
				{
					comboBox.Items.Add(ProgramModule.BlockData.DATA_OPERATE_ITEMS[i]);
				}
				base.Controls.Add(comboBox);
				comboBox = new ComboBox();
				comboBox.Width = 50;
				foreach (string text4 in ProgramModule.BlockData.OTHER_ITEMS)
				{
					comboBox.Items.Add(text4);
				}
				base.Controls.Add(comboBox);
				NumericUpDown numericUpDown = new NumericUpDown();
				numericUpDown.Width = 50;
				numericUpDown.Minimum = -32768m;
				numericUpDown.Maximum = 32767m;
				base.Controls.Add(numericUpDown);
				TextBox textBox = new TextBox();
				textBox.Width = 80;
				base.Controls.Add(textBox);
				this.updateBlock();
				((ComboBox)base.Controls[0]).SelectedValueChanged += this.comboBoxVariableLeft_SelectedValueChanged;
				((ComboBox)base.Controls[1]).SelectedValueChanged += this.comboBoxVariableRight_SelectedValueChanged;
				((ComboBox)base.Controls[2]).SelectedValueChanged += this.comboBoxVariableRightAll_SelectedValueChanged;
				((ComboBox)base.Controls[3]).SelectedValueChanged += this.comboBoxOperator_SelectedValueChanged;
				((ComboBox)base.Controls[4]).SelectedValueChanged += this.comboBoxOther_SelectedValueChanged;
				((NumericUpDown)base.Controls[5]).ValueChanged += this.numericUpDownConst_ValueChanged;
				((TextBox)base.Controls[6]).TextChanged += this.textBoxConst_TextChanged;
			}

			// Token: 0x06000DFF RID: 3583 RVA: 0x00078A0C File Offset: 0x00076C0C
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					((ComboBox)base.Controls[0]).SelectedIndex = this.VariableIndexLeft;
					if (this._kind == ProgramModule.BlockData.DATA_KIND.ARITHMETIC)
					{
						((ComboBox)base.Controls[3]).SelectedIndex = (int)this.Operate;
					}
					switch (this._valueType)
					{
					case ProgramModule.BlockData.DATA_VALUE_TYPE.CONST:
						((TextBox)base.Controls[6]).Text = this._constString;
						((NumericUpDown)base.Controls[5]).Value = this._constValue;
						return;
					case ProgramModule.BlockData.DATA_VALUE_TYPE.VARIABLE:
						if (this._kind == ProgramModule.BlockData.DATA_KIND.SUBSTITUTION)
						{
							((ComboBox)base.Controls[2]).SelectedIndex = BlockPropertyDataDialog.getComboBoxRightIndex(this.Kind, this.VariableType, this.VariableIndexRight);
							return;
						}
						((ComboBox)base.Controls[1]).SelectedIndex = this.VariableIndexRight;
						return;
					case ProgramModule.BlockData.DATA_VALUE_TYPE.TEMPERATURE:
						((ComboBox)base.Controls[4]).SelectedIndex = 0;
						break;
					case ProgramModule.BlockData.DATA_VALUE_TYPE.LIGHT:
						((ComboBox)base.Controls[4]).SelectedIndex = 1;
						return;
					default:
						return;
					}
				}
			}

			// Token: 0x06000E00 RID: 3584 RVA: 0x00078B50 File Offset: 0x00076D50
			public override void updateControlVisible(List<Rectangle> rects)
			{
				base.updateControlVisible(rects);
				if (this._kind != ProgramModule.BlockData.DATA_KIND.ARITHMETIC)
				{
					base.Controls[3].Visible = false;
				}
				if (this._kind != ProgramModule.BlockData.DATA_KIND.SUBSTITUTION || this._valueType != ProgramModule.BlockData.DATA_VALUE_TYPE.VARIABLE)
				{
					base.Controls[2].Visible = false;
				}
				if (this._kind != ProgramModule.BlockData.DATA_KIND.ARITHMETIC || this._valueType != ProgramModule.BlockData.DATA_VALUE_TYPE.VARIABLE)
				{
					base.Controls[1].Visible = false;
				}
				if (this._valueType != ProgramModule.BlockData.DATA_VALUE_TYPE.LIGHT && this._valueType != ProgramModule.BlockData.DATA_VALUE_TYPE.TEMPERATURE)
				{
					base.Controls[4].Visible = false;
				}
				if (this._kind != ProgramModule.BlockData.DATA_KIND.SUBSTITUTION || this._valueType != ProgramModule.BlockData.DATA_VALUE_TYPE.CONST)
				{
					base.Controls[6].Visible = false;
				}
				if (this._kind != ProgramModule.BlockData.DATA_KIND.ARITHMETIC || this._valueType != ProgramModule.BlockData.DATA_VALUE_TYPE.CONST)
				{
					base.Controls[5].Visible = false;
				}
			}

			// Token: 0x06000E01 RID: 3585 RVA: 0x00078C30 File Offset: 0x00076E30
			public void updateLevel()
			{
				if (base.Controls.Count > 0)
				{
					bool flag = NetworkWindow.Instance.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || this.Kind == ProgramModule.BlockData.DATA_KIND.SUBSTITUTION;
					base.Controls[3].Enabled = flag;
					base.Controls[5].Enabled = flag;
					base.Controls[1].Enabled = flag;
					base.Controls[4].Enabled = flag;
				}
			}

			// Token: 0x06000E02 RID: 3586 RVA: 0x00078CB2 File Offset: 0x00076EB2
			private void comboBoxVariableLeft_SelectedValueChanged(object sender, EventArgs e)
			{
				this.VariableIndexLeft = ((ComboBox)base.Controls[0]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E03 RID: 3587 RVA: 0x00078CD6 File Offset: 0x00076ED6
			private void comboBoxVariableRight_SelectedValueChanged(object sender, EventArgs e)
			{
				this.VariableIndexRight = ((ComboBox)base.Controls[1]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E04 RID: 3588 RVA: 0x00078CFC File Offset: 0x00076EFC
			private void comboBoxVariableRightAll_SelectedValueChanged(object sender, EventArgs e)
			{
				int selectedIndex = ((ComboBox)base.Controls[2]).SelectedIndex;
				this.VariableType = BlockPropertyDataDialog.getVariableType(this.Kind, selectedIndex, NetworkWindow.Instance.Programs);
				this.VariableIndexRight = BlockPropertyDataDialog.getVariableIndex(this.Kind, selectedIndex, NetworkWindow.Instance.Programs);
				base.addHistory();
			}

			// Token: 0x06000E05 RID: 3589 RVA: 0x00078D5E File Offset: 0x00076F5E
			private void comboBoxOperator_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Operate = (ProgramModule.BlockData.DATA_OPERATE)((ComboBox)base.Controls[3]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E06 RID: 3590 RVA: 0x00078D84 File Offset: 0x00076F84
			private void comboBoxOther_SelectedValueChanged(object sender, EventArgs e)
			{
				ProgramModule.BlockData.OTHER selectedIndex = (ProgramModule.BlockData.OTHER)((ComboBox)base.Controls[4]).SelectedIndex;
				if (selectedIndex != ProgramModule.BlockData.OTHER.TEMPERATURE)
				{
					if (selectedIndex == ProgramModule.BlockData.OTHER.LIGHT)
					{
						this.ValueType = ProgramModule.BlockData.DATA_VALUE_TYPE.LIGHT;
					}
				}
				else
				{
					this.ValueType = ProgramModule.BlockData.DATA_VALUE_TYPE.TEMPERATURE;
				}
				base.addHistory();
			}

			// Token: 0x06000E07 RID: 3591 RVA: 0x00078DC7 File Offset: 0x00076FC7
			private void numericUpDownConst_ValueChanged(object sender, EventArgs e)
			{
				this.ConstValue = (int)((NumericUpDown)base.Controls[5]).Value;
				base.addHistory();
			}

			// Token: 0x06000E08 RID: 3592 RVA: 0x00078DF0 File Offset: 0x00076FF0
			private void textBoxConst_TextChanged(object sender, EventArgs e)
			{
				this.ConstString = ((TextBox)base.Controls[6]).Text;
				base.addHistory();
			}

			// Token: 0x04000746 RID: 1862
			private static readonly string[] OTHER_ITEMS = new string[] { "温度", "明るさ" };

			// Token: 0x04000747 RID: 1863
			public static readonly string[] DATA_VALUE_TYPE_ITEMS = new string[] { "定数", "変数", "温度", "明るさ" };

			// Token: 0x04000748 RID: 1864
			public static readonly string[] DATA_KIND_ITEMS = new string[] { "代入", "演算", "結合" };

			// Token: 0x04000749 RID: 1865
			private ProgramModule.BlockData.DATA_KIND _kind;

			// Token: 0x0400074A RID: 1866
			public static readonly string[] DATA_OPERATE_ITEMS = new string[] { "+=", "-=", "*=", "/=" };

			// Token: 0x0400074B RID: 1867
			private ProgramModule.BlockData.DATA_OPERATE _operate;

			// Token: 0x0400074C RID: 1868
			private ProgramModule.BlockData.CONNECT_DIRECT _connectDirect;

			// Token: 0x0400074D RID: 1869
			private ProgramModule.BlockData.DATA_VALUE_TYPE _valueType;

			// Token: 0x0400074E RID: 1870
			private ProgramModule.BlockData.DATA_VARIABLE_TYPE _variableType;

			// Token: 0x0400074F RID: 1871
			private int _variableIndexLeft;

			// Token: 0x04000750 RID: 1872
			private int _variableIndexRight;

			// Token: 0x04000751 RID: 1873
			private string _constString;

			// Token: 0x04000752 RID: 1874
			private int _constValue;

			// Token: 0x020000E9 RID: 233
			public enum DATA_KIND
			{
				// Token: 0x040009AD RID: 2477
				SUBSTITUTION,
				// Token: 0x040009AE RID: 2478
				ARITHMETIC,
				// Token: 0x040009AF RID: 2479
				CONNECT,
				// Token: 0x040009B0 RID: 2480
				MAX
			}

			// Token: 0x020000EA RID: 234
			public enum DATA_OPERATE
			{
				// Token: 0x040009B2 RID: 2482
				ADD,
				// Token: 0x040009B3 RID: 2483
				SUB,
				// Token: 0x040009B4 RID: 2484
				LEVEL2_MAX,
				// Token: 0x040009B5 RID: 2485
				MULTI = 2,
				// Token: 0x040009B6 RID: 2486
				DEVIDE,
				// Token: 0x040009B7 RID: 2487
				MAX
			}

			// Token: 0x020000EB RID: 235
			public enum CONNECT_DIRECT
			{
				// Token: 0x040009B9 RID: 2489
				BEFORE,
				// Token: 0x040009BA RID: 2490
				AFTER,
				// Token: 0x040009BB RID: 2491
				MAX
			}

			// Token: 0x020000EC RID: 236
			public enum DATA_VALUE_TYPE
			{
				// Token: 0x040009BD RID: 2493
				CONST,
				// Token: 0x040009BE RID: 2494
				VARIABLE,
				// Token: 0x040009BF RID: 2495
				TEMPERATURE,
				// Token: 0x040009C0 RID: 2496
				LIGHT,
				// Token: 0x040009C1 RID: 2497
				MAX
			}

			// Token: 0x020000ED RID: 237
			public enum DATA_VARIABLE_TYPE
			{
				// Token: 0x040009C3 RID: 2499
				INPUT,
				// Token: 0x040009C4 RID: 2500
				CLIENT,
				// Token: 0x040009C5 RID: 2501
				MAX
			}

			// Token: 0x020000EE RID: 238
			private enum CONTROL
			{
				// Token: 0x040009C7 RID: 2503
				COMBOBOX_VARIABLE_LEFT,
				// Token: 0x040009C8 RID: 2504
				COMBOBOX_VARIABLE_RIGHT,
				// Token: 0x040009C9 RID: 2505
				COMBOBOX_VARIABLE_RIGHT_ALL,
				// Token: 0x040009CA RID: 2506
				COMBOBOX_OPERATOR,
				// Token: 0x040009CB RID: 2507
				COMBOBOX_OTHER,
				// Token: 0x040009CC RID: 2508
				NUMERIC_VALUE,
				// Token: 0x040009CD RID: 2509
				TEXTBOX_VALUE,
				// Token: 0x040009CE RID: 2510
				MAX
			}

			// Token: 0x020000EF RID: 239
			private enum OTHER
			{
				// Token: 0x040009D0 RID: 2512
				TEMPERATURE,
				// Token: 0x040009D1 RID: 2513
				LIGHT,
				// Token: 0x040009D2 RID: 2514
				MAX
			}
		}

		// Token: 0x02000074 RID: 116
		public class BlockDisplay : ProgramModule.Block
		{
			// Token: 0x1700045D RID: 1117
			// (get) Token: 0x06000E0A RID: 3594 RVA: 0x00078EB5 File Offset: 0x000770B5
			// (set) Token: 0x06000E0B RID: 3595 RVA: 0x00078EBD File Offset: 0x000770BD
			public ProgramModule.BlockDisplay.DISPLAY_MODE Mode
			{
				get
				{
					return this._mode;
				}
				set
				{
					base.Updated |= this._mode != value;
					this._mode = value;
				}
			}

			// Token: 0x1700045E RID: 1118
			// (get) Token: 0x06000E0C RID: 3596 RVA: 0x00078EDF File Offset: 0x000770DF
			// (set) Token: 0x06000E0D RID: 3597 RVA: 0x00078EE7 File Offset: 0x000770E7
			public int VariableIndex
			{
				get
				{
					return this._variableIndex;
				}
				set
				{
					base.Updated |= this._variableIndex != value;
					this._variableIndex = value;
				}
			}

			// Token: 0x06000E0E RID: 3598 RVA: 0x00078F0C File Offset: 0x0007710C
			public BlockDisplay()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000E0F RID: 3599 RVA: 0x00078F80 File Offset: 0x00077180
			public override byte[] serializeBinary()
			{
				byte[] array = new byte[2];
				switch (this._mode)
				{
				case ProgramModule.BlockDisplay.DISPLAY_MODE.TIME:
					array[0] = 97;
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.TEMPERATURE:
					array[0] = 98;
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.VARIABLE:
					array = new byte[]
					{
						99,
						0,
						(byte)this._variableIndex
					};
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.COUNTER:
					array[0] = 100;
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.LIGHT:
					array[0] = 101;
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.WAIT:
					array[0] = 102;
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.MAX:
					array[0] = 103;
					break;
				}
				return array;
			}

			// Token: 0x06000E10 RID: 3600 RVA: 0x00079000 File Offset: 0x00077200
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				switch (bytes[0])
				{
				case 97:
					this._mode = ProgramModule.BlockDisplay.DISPLAY_MODE.TIME;
					break;
				case 98:
					this._mode = ProgramModule.BlockDisplay.DISPLAY_MODE.TEMPERATURE;
					break;
				case 99:
					this._mode = ProgramModule.BlockDisplay.DISPLAY_MODE.VARIABLE;
					this._variableIndex = (int)bytes[2];
					break;
				case 100:
					this._mode = ProgramModule.BlockDisplay.DISPLAY_MODE.COUNTER;
					break;
				case 101:
					this._mode = ProgramModule.BlockDisplay.DISPLAY_MODE.LIGHT;
					break;
				case 102:
					this._mode = ProgramModule.BlockDisplay.DISPLAY_MODE.WAIT;
					break;
				case 103:
					this._mode = ProgramModule.BlockDisplay.DISPLAY_MODE.MAX;
					break;
				}
				return true;
			}

			// Token: 0x06000E11 RID: 3601 RVA: 0x0007907F File Offset: 0x0007727F
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.fc_block_250, base.Location);
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000E12 RID: 3602 RVA: 0x000790B8 File Offset: 0x000772B8
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_090, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_091, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_090.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_090.Width - Resources.bp_block_092.Width), (float)Resources.bp_block_091.Height));
					graphics.DrawImage(Resources.bp_block_092, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_092.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_090.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000E13 RID: 3603 RVA: 0x00079284 File Offset: 0x00077484
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				string text = "";
				base.addIndent(ref text, indent);
				switch (this._mode)
				{
				case ProgramModule.BlockDisplay.DISPLAY_MODE.TIME:
					text += "DISPLAY_ON(TIME)";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.TEMPERATURE:
					text += "DISPLAY_ON(TEMPARATURE)";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.VARIABLE:
					text = text + "DISPLAY_ON(" + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndex] + ")";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.COUNTER:
					text += "DISPLAY_ON(COUNTER)";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.LIGHT:
					text += "DISPLAY_ON(LIGHT)";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.WAIT:
					text += "DISPLAY_ON(WAIT)";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.MAX:
					text += "DISPLAY_OFF()";
					break;
				}
				codeList.Add(text);
				base.getProgram(blockList, codeList, indent);
			}

			// Token: 0x06000E14 RID: 3604 RVA: 0x0007934C File Offset: 0x0007754C
			public override string getDetail()
			{
				string text = "";
				switch (this._mode)
				{
				case ProgramModule.BlockDisplay.DISPLAY_MODE.TIME:
					text = "表示\r\n時刻";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.TEMPERATURE:
					text = "表示\r\n温度";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.VARIABLE:
					text = "表示\r\n変数" + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndex];
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.COUNTER:
					text = "表示\r\n秒カウンタ値";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.LIGHT:
					text = "表示\r\n光センサ値";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.WAIT:
					text = "表示\r\nウェイト時間";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.MAX:
					text = "表示を消す";
					break;
				}
				return text;
			}

			// Token: 0x06000E15 RID: 3605 RVA: 0x000793D4 File Offset: 0x000775D4
			public override string getDetailBlock(bool isPrint)
			{
				string text = "";
				switch (this._mode)
				{
				case ProgramModule.BlockDisplay.DISPLAY_MODE.TIME:
					text = "表示 時刻";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.TEMPERATURE:
					text = "表示 温度";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.VARIABLE:
					text = (isPrint ? ("表示 " + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndex]) : "表示 変数値\u3000\u3000\u3000");
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.COUNTER:
					text = "表示 秒カウンタ値";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.LIGHT:
					text = "表示 光センサ値";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.WAIT:
					text = "表示 ウェイト時間";
					break;
				case ProgramModule.BlockDisplay.DISPLAY_MODE.MAX:
					text = "表示を消す";
					break;
				}
				return text;
			}

			// Token: 0x06000E16 RID: 3606 RVA: 0x00079464 File Offset: 0x00077664
			public override int getUsedMemory()
			{
				if (this._mode == ProgramModule.BlockDisplay.DISPLAY_MODE.VARIABLE)
				{
					return 3;
				}
				return 2;
			}

			// Token: 0x06000E17 RID: 3607 RVA: 0x0007512D File Offset: 0x0007332D
			public override bool isIconBlock()
			{
				return false;
			}

			// Token: 0x06000E18 RID: 3608 RVA: 0x00079474 File Offset: 0x00077674
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0 && this._mode == ProgramModule.BlockDisplay.DISPLAY_MODE.VARIABLE)
				{
					x += Resources.bp_block_090.Width;
					int width = TextRenderer.MeasureText("表示 変数値", ProgramModule.Block._fontBlock).Width;
					base.Controls[0].Location = new Point(x + width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
				}
			}

			// Token: 0x06000E19 RID: 3609 RVA: 0x000794F4 File Offset: 0x000776F4
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				ComboBox comboBox = new ComboBox();
				comboBox.Width = 60;
				foreach (string text in ProgramModule.BlockIf.VARIABLE_ITEMS)
				{
					comboBox.Items.Add(text);
				}
				base.Controls.Add(comboBox);
				this.updateBlock();
				((ComboBox)base.Controls[0]).SelectedValueChanged += this.comboBoxVariable_SelectedValueChanged;
			}

			// Token: 0x06000E1A RID: 3610 RVA: 0x00079573 File Offset: 0x00077773
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					((ComboBox)base.Controls[0]).SelectedIndex = this._variableIndex;
				}
			}

			// Token: 0x06000E1B RID: 3611 RVA: 0x000795A5 File Offset: 0x000777A5
			public override void updateControlVisible(List<Rectangle> rects)
			{
				base.updateControlVisible(rects);
				if (this._mode != ProgramModule.BlockDisplay.DISPLAY_MODE.VARIABLE)
				{
					base.Controls[0].Visible = false;
				}
			}

			// Token: 0x06000E1C RID: 3612 RVA: 0x000795C9 File Offset: 0x000777C9
			private void comboBoxVariable_SelectedValueChanged(object sender, EventArgs e)
			{
				this.VariableIndex = ((ComboBox)base.Controls[0]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x04000753 RID: 1875
			public const int USE_MEMORY_MAX = 3;

			// Token: 0x04000754 RID: 1876
			public static readonly string[] MODE_ITEMS = new string[] { "時刻", "温度", "変数値", "秒カウンタ値", "光センサ値", "ウェイト時間" };

			// Token: 0x04000755 RID: 1877
			private ProgramModule.BlockDisplay.DISPLAY_MODE _mode;

			// Token: 0x04000756 RID: 1878
			private int _variableIndex;

			// Token: 0x020000F0 RID: 240
			public enum DISPLAY_MODE
			{
				// Token: 0x040009D4 RID: 2516
				TIME,
				// Token: 0x040009D5 RID: 2517
				TEMPERATURE,
				// Token: 0x040009D6 RID: 2518
				VARIABLE,
				// Token: 0x040009D7 RID: 2519
				COUNTER,
				// Token: 0x040009D8 RID: 2520
				LIGHT,
				// Token: 0x040009D9 RID: 2521
				WAIT,
				// Token: 0x040009DA RID: 2522
				MAX,
				// Token: 0x040009DB RID: 2523
				INVALID = 6
			}

			// Token: 0x020000F1 RID: 241
			private enum CONTROL
			{
				// Token: 0x040009DD RID: 2525
				COMBOBOX_VARIABLE,
				// Token: 0x040009DE RID: 2526
				MAX
			}
		}

		// Token: 0x02000075 RID: 117
		public class BlockEnd : ProgramModule.Block
		{
			// Token: 0x06000E1E RID: 3614 RVA: 0x0007962C File Offset: 0x0007782C
			public BlockEnd()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Location = (base.LocationBlock = ProgramModule.BlockEnd.INITIAL_LOCATION);
			}

			// Token: 0x06000E1F RID: 3615 RVA: 0x0007967E File Offset: 0x0007787E
			public override byte[] serializeBinary()
			{
				return new byte[] { 2 };
			}

			// Token: 0x06000E20 RID: 3616 RVA: 0x0007968A File Offset: 0x0007788A
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				return true;
			}

			// Token: 0x06000E21 RID: 3617 RVA: 0x0007968D File Offset: 0x0007788D
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.fc_block_230, base.Location);
				}
				base.paintConnectPoints(graphics);
			}

			// Token: 0x06000E22 RID: 3618 RVA: 0x000796B8 File Offset: 0x000778B8
			public override void paintRect(Graphics graphics, Color color, bool fill)
			{
				if (fill)
				{
					Brush brush = new SolidBrush(color);
					graphics.FillPie(brush, new Rectangle(base.Location.X, base.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width / 2, ProgramModule.Block.BLOCK_SIZE.Height), 90f, 180f);
					graphics.FillRectangle(brush, base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 4, base.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width / 2, ProgramModule.Block.BLOCK_SIZE.Height);
					graphics.FillPie(brush, new Rectangle(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 2, base.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width / 2, ProgramModule.Block.BLOCK_SIZE.Height), 270f, 180f);
					return;
				}
				Pen pen = new Pen(color, 4f);
				graphics.DrawArc(pen, new Rectangle(base.Location.X, base.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width / 2, ProgramModule.Block.BLOCK_SIZE.Height), 90f, 180f);
				graphics.DrawLine(pen, base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 4, base.Location.Y, base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 4 + ProgramModule.Block.BLOCK_SIZE.Width / 2, base.Location.Y);
				graphics.DrawLine(pen, base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 4, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height, base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 4 + ProgramModule.Block.BLOCK_SIZE.Width / 2, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height);
				graphics.DrawArc(pen, new Rectangle(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 2, base.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width / 2, ProgramModule.Block.BLOCK_SIZE.Height), 270f, 180f);
			}

			// Token: 0x06000E23 RID: 3619 RVA: 0x00079944 File Offset: 0x00077B44
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_001, base.LocationBlock);
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
					}
				}
			}

			// Token: 0x06000E24 RID: 3620 RVA: 0x000153E3 File Offset: 0x000135E3
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
			}

			// Token: 0x06000E25 RID: 3621 RVA: 0x00079A38 File Offset: 0x00077C38
			public override string getDetail()
			{
				return "終了";
			}

			// Token: 0x06000E26 RID: 3622 RVA: 0x0007968A File Offset: 0x0007788A
			public override int getUsedMemory()
			{
				return 1;
			}

			// Token: 0x06000E27 RID: 3623 RVA: 0x00079A3F File Offset: 0x00077C3F
			public override ProgramModule.Block.CONNECT_STATE updateConnectState(List<ProgramModule.Block> blocks)
			{
				base.ConnectState = ProgramModule.Block.CONNECT_STATE.RIGHT;
				return base.ConnectState;
			}

			// Token: 0x04000757 RID: 1879
			public const int USE_MEMORY_MAX = 1;

			// Token: 0x04000758 RID: 1880
			public static readonly Point INITIAL_LOCATION = new Point(17, 497);
		}

		// Token: 0x02000076 RID: 118
		public class BlockEvent : ProgramModule.BlockStart
		{
			// Token: 0x1700045F RID: 1119
			// (get) Token: 0x06000E29 RID: 3625 RVA: 0x00079A61 File Offset: 0x00077C61
			// (set) Token: 0x06000E2A RID: 3626 RVA: 0x00079A69 File Offset: 0x00077C69
			public ProgramModule.BlockEvent.OBJECT_TYPE ObjectType
			{
				get
				{
					return this._objectType;
				}
				set
				{
					base.Updated |= this._objectType != value;
					this._objectType = value;
				}
			}

			// Token: 0x17000460 RID: 1120
			// (get) Token: 0x06000E2B RID: 3627 RVA: 0x00079A8B File Offset: 0x00077C8B
			// (set) Token: 0x06000E2C RID: 3628 RVA: 0x00079A93 File Offset: 0x00077C93
			public ProgramModule.BlockEvent.TRIGGER Trigger
			{
				get
				{
					return this._trigger;
				}
				set
				{
					base.Updated |= this._trigger != value;
					this._trigger = value;
				}
			}

			// Token: 0x17000461 RID: 1121
			// (get) Token: 0x06000E2D RID: 3629 RVA: 0x00079AB5 File Offset: 0x00077CB5
			// (set) Token: 0x06000E2E RID: 3630 RVA: 0x00079ABD File Offset: 0x00077CBD
			public ProgramModule.BlockEvent.TRIGGER_HARDWARE TriggerHardware
			{
				get
				{
					return this._triggerHardware;
				}
				set
				{
					base.Updated |= this._triggerHardware != value;
					this._triggerHardware = value;
				}
			}

			// Token: 0x17000462 RID: 1122
			// (get) Token: 0x06000E2F RID: 3631 RVA: 0x00079ADF File Offset: 0x00077CDF
			// (set) Token: 0x06000E30 RID: 3632 RVA: 0x00079AE7 File Offset: 0x00077CE7
			public int MessageIndex
			{
				get
				{
					return this._messageIndex;
				}
				set
				{
					base.Updated |= this._messageIndex != value;
					this._messageIndex = value;
				}
			}

			// Token: 0x06000E31 RID: 3633 RVA: 0x00079B09 File Offset: 0x00077D09
			private BlockEvent()
			{
			}

			// Token: 0x06000E32 RID: 3634 RVA: 0x00079B18 File Offset: 0x00077D18
			public BlockEvent(ProgramModule.BlockEvent.OBJECT_TYPE objectType)
			{
				this.ObjectType = objectType;
			}

			// Token: 0x06000E33 RID: 3635 RVA: 0x00079B2E File Offset: 0x00077D2E
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.nw_block_000, base.Location);
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000E34 RID: 3636 RVA: 0x00079B68 File Offset: 0x00077D68
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_002, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_003, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_002.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_002.Width - Resources.bp_block_004.Width), (float)Resources.bp_block_003.Height));
					graphics.DrawImage(Resources.bp_block_004, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_004.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000E35 RID: 3637 RVA: 0x00079D34 File Offset: 0x00077F34
			public override string getDetail()
			{
				switch (this.Trigger)
				{
				case ProgramModule.BlockEvent.TRIGGER.PLAY:
				{
					ProgramModule.BlockEvent.OBJECT_TYPE objectType = this._objectType;
					if (objectType == ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON)
					{
						return "(自身が)\r\nクリックされたとき";
					}
					if (objectType != ProgramModule.BlockEvent.OBJECT_TYPE.INPUT)
					{
						return ProgramModule.BlockEvent.TRIGGER_ITEMS[(int)this.Trigger];
					}
					return "(入力が)\r\n確定したとき";
				}
				case ProgramModule.BlockEvent.TRIGGER.MESSAGE:
					return "メッセージを受けた時\r\n(" + NetworkWindow.Instance.Programs.MessageNames[this.MessageIndex] + ")";
				case ProgramModule.BlockEvent.TRIGGER.HARDWARE:
					return ProgramModule.BlockEvent.TRIGGER_ITEMS[(int)this.Trigger] + "\r\n" + ProgramModule.BlockEvent.TRIGGER_HARDWARE_ITEMS[(int)this.TriggerHardware];
				default:
					return "";
				}
			}

			// Token: 0x06000E36 RID: 3638 RVA: 0x00079DD8 File Offset: 0x00077FD8
			public override string getDetailBlock(bool isPrint)
			{
				string text = "";
				switch (this._objectType)
				{
				case ProgramModule.BlockEvent.OBJECT_TYPE.LABEL:
				case ProgramModule.BlockEvent.OBJECT_TYPE.LIST:
				case ProgramModule.BlockEvent.OBJECT_TYPE.GRAPH:
				case ProgramModule.BlockEvent.OBJECT_TYPE.STAGE:
					switch (this._trigger)
					{
					case ProgramModule.BlockEvent.TRIGGER.PLAY:
						text = "実行されたとき";
						break;
					case ProgramModule.BlockEvent.TRIGGER.MESSAGE:
						text = (isPrint ? ("メッセージを受けたとき" + NetworkWindow.Instance.Programs.MessageNames[this._messageIndex]) : "メッセージを受けたとき\u3000\u3000\u3000\u3000\u3000");
						break;
					case ProgramModule.BlockEvent.TRIGGER.HARDWARE:
						text = (isPrint ? ("コロックル" + ProgramModule.BlockEvent.TRIGGER_HARDWARE_ITEMS[(int)this._triggerHardware]) : "コロックル\u3000\u3000\u3000\u3000\u3000\u3000\u3000");
						break;
					}
					break;
				case ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON:
					text = "(自身が)クリックされたとき";
					break;
				case ProgramModule.BlockEvent.OBJECT_TYPE.INPUT:
					text = "(入力が)確定した時";
					break;
				}
				return text;
			}

			// Token: 0x06000E37 RID: 3639 RVA: 0x00079E9C File Offset: 0x0007809C
			public override void updateData()
			{
				((ComboBox)base.Controls[0]).Items.Clear();
				foreach (string text in NetworkWindow.Instance.Programs.MessageNames)
				{
					((ComboBox)base.Controls[0]).Items.Add(text);
				}
			}

			// Token: 0x06000E38 RID: 3640 RVA: 0x00079F2C File Offset: 0x0007812C
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_002.Width;
					if (this._trigger == ProgramModule.BlockEvent.TRIGGER.MESSAGE)
					{
						int num = TextRenderer.MeasureText("メッセージを受けたとき", ProgramModule.Block._fontBlock).Width;
						base.Controls[0].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
						return;
					}
					if (this._trigger == ProgramModule.BlockEvent.TRIGGER.HARDWARE)
					{
						int num = TextRenderer.MeasureText("コロックル", ProgramModule.Block._fontBlock).Width;
						base.Controls[1].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					}
				}
			}

			// Token: 0x06000E39 RID: 3641 RVA: 0x00079FFC File Offset: 0x000781FC
			public override void createBlockControls()
			{
				if (NetworkWindow.Instance != null)
				{
					base.Controls = new List<Control>();
					ComboBox comboBox = new ComboBox();
					comboBox.Width = 100;
					foreach (string text in NetworkWindow.Instance.Programs.MessageNames)
					{
						comboBox.Items.Add(text);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 120;
					if (NetworkWindow.Instance.Programs.Level <= NetworkProgramModules.LEVEL.LEVEL_2 || !NetworkWindow.Instance.IsUsbInOutEnable)
					{
						for (int i = 0; i < 4; i++)
						{
							comboBox.Items.Add(ProgramModule.BlockEvent.TRIGGER_HARDWARE_ITEMS[i]);
						}
					}
					else
					{
						foreach (string text2 in ProgramModule.BlockEvent.TRIGGER_HARDWARE_ITEMS)
						{
							comboBox.Items.Add(text2);
						}
					}
					base.Controls.Add(comboBox);
				}
				this.updateBlock();
				if (NetworkWindow.Instance != null)
				{
					((ComboBox)base.Controls[0]).SelectedValueChanged += this.comboBoxMessage_SelectedValueChanged;
					((ComboBox)base.Controls[1]).SelectedValueChanged += this.comboBoxHardware_SelectedValueChanged;
				}
			}

			// Token: 0x06000E3A RID: 3642 RVA: 0x0007A168 File Offset: 0x00078368
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					if (this._trigger == ProgramModule.BlockEvent.TRIGGER.MESSAGE)
					{
						((ComboBox)base.Controls[0]).SelectedIndex = this._messageIndex;
						return;
					}
					if (this._trigger == ProgramModule.BlockEvent.TRIGGER.HARDWARE)
					{
						((ComboBox)base.Controls[1]).SelectedIndex = (int)this._triggerHardware;
					}
				}
			}

			// Token: 0x06000E3B RID: 3643 RVA: 0x0007A1D4 File Offset: 0x000783D4
			public void updateLevel()
			{
				if (base.Controls.Count > 0)
				{
					ComboBox comboBox = (ComboBox)base.Controls[1];
					if (NetworkWindow.Instance.Programs.Level == NetworkProgramModules.LEVEL.LEVEL_1)
					{
						comboBox.Enabled = false;
						return;
					}
					if (NetworkWindow.Instance.Programs.Level == NetworkProgramModules.LEVEL.LEVEL_2)
					{
						if (this._triggerHardware == ProgramModule.BlockEvent.TRIGGER_HARDWARE.LEVEL2_MAX)
						{
							comboBox.Enabled = false;
							return;
						}
						this.resetComboBoxHardware();
						comboBox.Enabled = true;
						return;
					}
					else
					{
						if (this._triggerHardware == ProgramModule.BlockEvent.TRIGGER_HARDWARE.LEVEL2_MAX)
						{
							comboBox.Enabled = NetworkWindow.Instance.IsUsbInOutEnable;
							return;
						}
						this.resetComboBoxHardware();
						comboBox.Enabled = true;
					}
				}
			}

			// Token: 0x06000E3C RID: 3644 RVA: 0x0007A278 File Offset: 0x00078478
			private void resetComboBoxHardware()
			{
				ComboBox comboBox = (ComboBox)base.Controls[1];
				int selectedIndex = comboBox.SelectedIndex;
				comboBox.Items.Clear();
				if (NetworkWindow.Instance.Programs.Level <= NetworkProgramModules.LEVEL.LEVEL_2 || !NetworkWindow.Instance.IsUsbInOutEnable)
				{
					for (int i = 0; i < 4; i++)
					{
						comboBox.Items.Add(ProgramModule.BlockEvent.TRIGGER_HARDWARE_ITEMS[i]);
					}
				}
				else
				{
					foreach (string text in ProgramModule.BlockEvent.TRIGGER_HARDWARE_ITEMS)
					{
						comboBox.Items.Add(text);
					}
				}
				comboBox.SelectedIndex = Math.Min(comboBox.Items.Count - 1, selectedIndex);
			}

			// Token: 0x06000E3D RID: 3645 RVA: 0x0007A32D File Offset: 0x0007852D
			public override void updateControlVisible(List<Rectangle> rects)
			{
				base.updateControlVisible(rects);
				if (this._trigger != ProgramModule.BlockEvent.TRIGGER.MESSAGE)
				{
					base.Controls[0].Visible = false;
				}
				if (this._trigger != ProgramModule.BlockEvent.TRIGGER.HARDWARE)
				{
					base.Controls[1].Visible = false;
				}
			}

			// Token: 0x06000E3E RID: 3646 RVA: 0x0007A36C File Offset: 0x0007856C
			public void updateUsbInOutEnable(bool enable)
			{
				if (base.Controls.Count > 0)
				{
					if (enable)
					{
						base.Controls[1].Enabled = true;
						this.resetComboBoxHardware();
						return;
					}
					if (this._triggerHardware == ProgramModule.BlockEvent.TRIGGER_HARDWARE.LEVEL2_MAX)
					{
						base.Controls[1].Enabled = false;
						return;
					}
					base.Controls[1].Enabled = true;
					this.resetComboBoxHardware();
				}
			}

			// Token: 0x06000E3F RID: 3647 RVA: 0x0007A3D7 File Offset: 0x000785D7
			private void comboBoxMessage_SelectedValueChanged(object sender, EventArgs e)
			{
				this.MessageIndex = ((ComboBox)base.Controls[0]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E40 RID: 3648 RVA: 0x0007A3FB File Offset: 0x000785FB
			private void comboBoxHardware_SelectedValueChanged(object sender, EventArgs e)
			{
				this.TriggerHardware = (ProgramModule.BlockEvent.TRIGGER_HARDWARE)((ComboBox)base.Controls[1]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x04000759 RID: 1881
			public static readonly string[] OBJECT_TYPE_ITEMS = new string[] { "テキスト表示", "リスト", "ボタン", "入力バー", "グラフ", "ステージ" };

			// Token: 0x0400075A RID: 1882
			private ProgramModule.BlockEvent.OBJECT_TYPE _objectType = ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON;

			// Token: 0x0400075B RID: 1883
			public static readonly string[] TRIGGER_ITEMS = new string[] { "実行された時", "メッセージを受けた時", "コロックル" };

			// Token: 0x0400075C RID: 1884
			private ProgramModule.BlockEvent.TRIGGER _trigger;

			// Token: 0x0400075D RID: 1885
			public static readonly string[] TRIGGER_HARDWARE_ITEMS = new string[] { "ボタンが押された時", "明るくなった時", "暗くなった時", "音入力があった時", "外部入力があった時" };

			// Token: 0x0400075E RID: 1886
			private ProgramModule.BlockEvent.TRIGGER_HARDWARE _triggerHardware;

			// Token: 0x0400075F RID: 1887
			private int _messageIndex;

			// Token: 0x020000F2 RID: 242
			public enum OBJECT_TYPE
			{
				// Token: 0x040009E0 RID: 2528
				INVALID = -1,
				// Token: 0x040009E1 RID: 2529
				LABEL,
				// Token: 0x040009E2 RID: 2530
				LIST,
				// Token: 0x040009E3 RID: 2531
				BUTTON,
				// Token: 0x040009E4 RID: 2532
				INPUT,
				// Token: 0x040009E5 RID: 2533
				GRAPH,
				// Token: 0x040009E6 RID: 2534
				STAGE,
				// Token: 0x040009E7 RID: 2535
				MAX
			}

			// Token: 0x020000F3 RID: 243
			public enum TRIGGER
			{
				// Token: 0x040009E9 RID: 2537
				PLAY,
				// Token: 0x040009EA RID: 2538
				MESSAGE,
				// Token: 0x040009EB RID: 2539
				HARDWARE,
				// Token: 0x040009EC RID: 2540
				MAX
			}

			// Token: 0x020000F4 RID: 244
			public enum TRIGGER_HARDWARE
			{
				// Token: 0x040009EE RID: 2542
				BUTTON,
				// Token: 0x040009EF RID: 2543
				BRIGHT,
				// Token: 0x040009F0 RID: 2544
				DARK,
				// Token: 0x040009F1 RID: 2545
				SOUND,
				// Token: 0x040009F2 RID: 2546
				LEVEL2_MAX,
				// Token: 0x040009F3 RID: 2547
				USBIN = 4,
				// Token: 0x040009F4 RID: 2548
				MAX
			}

			// Token: 0x020000F5 RID: 245
			private enum CONTROL
			{
				// Token: 0x040009F6 RID: 2550
				COMBOBOX_MESSAGE,
				// Token: 0x040009F7 RID: 2551
				COMBOBOX_HARDWARE,
				// Token: 0x040009F8 RID: 2552
				MAX
			}
		}

		// Token: 0x02000077 RID: 119
		public class BlockIf : ProgramModule.BlockBranch
		{
			// Token: 0x17000463 RID: 1123
			// (get) Token: 0x06000E42 RID: 3650 RVA: 0x0007A4BE File Offset: 0x000786BE
			// (set) Token: 0x06000E43 RID: 3651 RVA: 0x0007A4C6 File Offset: 0x000786C6
			[XmlIgnore]
			public ProgramModule.Block Else
			{
				get
				{
					return this._else;
				}
				set
				{
					base.Updated |= this._else != value;
					this._else = value;
				}
			}

			// Token: 0x17000464 RID: 1124
			// (get) Token: 0x06000E44 RID: 3652 RVA: 0x0007A4E8 File Offset: 0x000786E8
			// (set) Token: 0x06000E45 RID: 3653 RVA: 0x0007A4F0 File Offset: 0x000786F0
			public ProgramModule.BlockIf.CONDITION_IF Condition
			{
				get
				{
					return this._condition;
				}
				set
				{
					base.Updated |= this._condition != value;
					this._condition = value;
				}
			}

			// Token: 0x17000465 RID: 1125
			// (get) Token: 0x06000E46 RID: 3654 RVA: 0x0007A512 File Offset: 0x00078712
			// (set) Token: 0x06000E47 RID: 3655 RVA: 0x0007A51A File Offset: 0x0007871A
			public ProgramModule.BlockIf.CONDITION_NETWORK_IF ConditionNetwork
			{
				get
				{
					return this._conditionNetwork;
				}
				set
				{
					base.Updated |= this._conditionNetwork != value;
					this._conditionNetwork = value;
				}
			}

			// Token: 0x17000466 RID: 1126
			// (get) Token: 0x06000E48 RID: 3656 RVA: 0x0007A53C File Offset: 0x0007873C
			// (set) Token: 0x06000E49 RID: 3657 RVA: 0x0007A544 File Offset: 0x00078744
			public bool IsConditionNetwork
			{
				get
				{
					return this._isConditionNetwork;
				}
				set
				{
					base.Updated |= this._isConditionNetwork != value;
					this._isConditionNetwork = value;
				}
			}

			// Token: 0x17000467 RID: 1127
			// (get) Token: 0x06000E4A RID: 3658 RVA: 0x0007A566 File Offset: 0x00078766
			// (set) Token: 0x06000E4B RID: 3659 RVA: 0x0007A56E File Offset: 0x0007876E
			public ProgramModule.BlockIf.SELECT Select
			{
				get
				{
					return this._select;
				}
				set
				{
					base.Updated |= this._select != value;
					this._select = value;
				}
			}

			// Token: 0x17000468 RID: 1128
			// (get) Token: 0x06000E4C RID: 3660 RVA: 0x0007A590 File Offset: 0x00078790
			// (set) Token: 0x06000E4D RID: 3661 RVA: 0x0007A598 File Offset: 0x00078798
			public int[] Values
			{
				get
				{
					return this._values;
				}
				set
				{
					base.Updated |= this._values != value;
					this._values = value;
				}
			}

			// Token: 0x17000469 RID: 1129
			// (get) Token: 0x06000E4E RID: 3662 RVA: 0x0007A5BA File Offset: 0x000787BA
			// (set) Token: 0x06000E4F RID: 3663 RVA: 0x0007A5C2 File Offset: 0x000787C2
			public int[] VariableIndexes
			{
				get
				{
					return this._variableIndexes;
				}
				set
				{
					base.Updated |= this._variableIndexes != value;
					this._variableIndexes = value;
				}
			}

			// Token: 0x1700046A RID: 1130
			// (get) Token: 0x06000E50 RID: 3664 RVA: 0x0007A5E4 File Offset: 0x000787E4
			// (set) Token: 0x06000E51 RID: 3665 RVA: 0x0007A5EC File Offset: 0x000787EC
			public ProgramModule.BlockIf.VARIABLE_TYPE_SECOND Variable
			{
				get
				{
					return this._variable;
				}
				set
				{
					base.Updated |= this._variable != value;
					this._variable = value;
				}
			}

			// Token: 0x1700046B RID: 1131
			// (get) Token: 0x06000E52 RID: 3666 RVA: 0x0007A60E File Offset: 0x0007880E
			// (set) Token: 0x06000E53 RID: 3667 RVA: 0x0007A616 File Offset: 0x00078816
			public int ConnectIndexElse
			{
				get
				{
					return this._connectIndexElse;
				}
				set
				{
					base.Updated |= this._connectIndexElse != value;
					this._connectIndexElse = value;
				}
			}

			// Token: 0x1700046C RID: 1132
			// (get) Token: 0x06000E54 RID: 3668 RVA: 0x0007A638 File Offset: 0x00078838
			// (set) Token: 0x06000E55 RID: 3669 RVA: 0x0007A640 File Offset: 0x00078840
			public string ObjectName
			{
				get
				{
					return this._objectName;
				}
				set
				{
					base.Updated |= !this._objectName.Equals(value);
					this._objectName = value;
				}
			}

			// Token: 0x1700046D RID: 1133
			// (get) Token: 0x06000E56 RID: 3670 RVA: 0x0007A665 File Offset: 0x00078865
			// (set) Token: 0x06000E57 RID: 3671 RVA: 0x0007A66D File Offset: 0x0007886D
			public string ConstString
			{
				get
				{
					return this._constString;
				}
				set
				{
					base.Updated |= !this._constString.Equals(value);
					this._constString = value;
				}
			}

			// Token: 0x06000E58 RID: 3672 RVA: 0x0007A694 File Offset: 0x00078894
			public BlockIf()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[2] = new Point(ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE / 2, (ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE) / 2);
			}

			// Token: 0x06000E59 RID: 3673 RVA: 0x0007A771 File Offset: 0x00078971
			public BlockIf(int branchCount)
				: this()
			{
				this.initializeBranches(branchCount);
			}

			// Token: 0x06000E5A RID: 3674 RVA: 0x0007A780 File Offset: 0x00078980
			public override void initializeBranches(int branchCount)
			{
				if (base.Branches == null || base.Branches.Count != branchCount)
				{
					base.Branches = new List<ProgramModule.Block>();
					for (int i = 0; i < branchCount; i++)
					{
						base.Branches.Add(null);
					}
				}
				if (base.ConnectIndexBranches == null || base.ConnectIndexBranches.Count != branchCount)
				{
					base.ConnectIndexBranches = new List<int>();
					for (int j = 0; j < branchCount; j++)
					{
						base.ConnectIndexBranches.Add(-1);
					}
				}
			}

			// Token: 0x06000E5B RID: 3675 RVA: 0x0007A7FF File Offset: 0x000789FF
			public override void updateVersion(int version)
			{
				if (version < 1 && this._condition == ProgramModule.BlockIf.CONDITION_IF.LIGHT)
				{
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID;
				}
			}

			// Token: 0x06000E5C RID: 3676 RVA: 0x0007A818 File Offset: 0x00078A18
			public override byte[] serializeBinary()
			{
				byte[] array = new byte[0];
				switch (this._condition)
				{
				case ProgramModule.BlockIf.CONDITION_IF.BUTTON:
					array = new byte[3];
					if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
					{
						array[0] = 46;
					}
					else
					{
						array[0] = 47;
					}
					break;
				case ProgramModule.BlockIf.CONDITION_IF.LIGHT:
					if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						array = new byte[4];
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							array[0] = 88;
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							array[0] = 89;
						}
						else
						{
							array[0] = 90;
						}
						array[3] = (byte)this._values[0];
					}
					else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
					{
						array = new byte[4];
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							array[0] = 91;
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							array[0] = 92;
						}
						else
						{
							array[0] = 93;
						}
						array[3] = (byte)this._variableIndexes[0];
					}
					else
					{
						array = new byte[3];
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							array[0] = 48;
						}
						else
						{
							array[0] = 49;
						}
					}
					break;
				case ProgramModule.BlockIf.CONDITION_IF.SOUND:
					array = new byte[3];
					if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
					{
						array[0] = 50;
					}
					else
					{
						array[0] = 51;
					}
					break;
				case ProgramModule.BlockIf.CONDITION_IF.ALARM:
					array = new byte[3];
					if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
					{
						array[0] = 61;
					}
					else
					{
						array[0] = 62;
					}
					break;
				case ProgramModule.BlockIf.CONDITION_IF.TIMER:
					array = new byte[3];
					if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
					{
						array[0] = 63;
					}
					else
					{
						array[0] = 64;
					}
					break;
				case ProgramModule.BlockIf.CONDITION_IF.TIME:
					array = new byte[5];
					if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
					{
						array[0] = 58;
					}
					else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
					{
						array[0] = 59;
					}
					if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
					{
						array[0] = 60;
					}
					array[3] = (byte)this._values[0];
					array[4] = (byte)this._values[1];
					break;
				case ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE:
					array = new byte[4];
					if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							array[0] = 52;
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							array[0] = 53;
						}
						else
						{
							array[0] = 54;
						}
						array[3] = (byte)this._values[0];
					}
					else
					{
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							array[0] = 55;
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							array[0] = 56;
						}
						else
						{
							array[0] = 57;
						}
						array[3] = (byte)this._variableIndexes[0];
					}
					break;
				case ProgramModule.BlockIf.CONDITION_IF.RANDOM:
					array = new byte[3];
					array[0] = 75;
					break;
				case ProgramModule.BlockIf.CONDITION_IF.COUNTER:
					array = new byte[4];
					if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
					{
						array[0] = 65;
					}
					else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
					{
						array[0] = 66;
					}
					if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
					{
						array[0] = 67;
					}
					array[3] = (byte)this._values[0];
					break;
				case ProgramModule.BlockIf.CONDITION_IF.VARIABLE:
					array = new byte[5];
					if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						array[3] = (byte)this._variableIndexes[0];
						array[4] = (byte)this._values[0];
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							array[0] = 68;
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							array[0] = 69;
						}
						else
						{
							array[0] = 70;
						}
					}
					else
					{
						array[3] = (byte)this._variableIndexes[0];
						array[4] = (byte)this._variableIndexes[1];
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							array[0] = 71;
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							array[0] = 72;
						}
						else
						{
							array[0] = 73;
						}
					}
					break;
				case ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX:
					array = new byte[3];
					if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
					{
						array[0] = 141;
					}
					else
					{
						array[0] = 142;
					}
					break;
				}
				return array;
			}

			// Token: 0x06000E5D RID: 3677 RVA: 0x0007AB70 File Offset: 0x00078D70
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				ProgramModule.Block.COMMAND_NUMBER command_NUMBER = (ProgramModule.Block.COMMAND_NUMBER)bytes[0];
				switch (command_NUMBER)
				{
				case ProgramModule.Block.COMMAND_NUMBER.IF_BEGIN:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.BUTTON;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_BUTTON_OFF:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.BUTTON;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_LIGHT_BRIGHT:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_LIGHT_DARK:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_SOUND_OFF:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.SOUND;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_SOUND_ON:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.SOUND;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_TEMPERATURE_COMPARE_GREATER_CONST:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					this._values[0] = (int)((sbyte)bytes[3]);
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_TEMPERATURE_COMPARE_LESS_CONST:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					this._values[0] = (int)((sbyte)bytes[3]);
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_TEMPERATURE_COMPARE_EQUAL_CONST:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					this._values[0] = (int)((sbyte)bytes[3]);
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_TEMPERATURE_COMPARE_GREATER_VARIABLE:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					this._variableIndexes[0] = (int)bytes[3];
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_TEMPERATURE_COMPARE_LESS_VARIABLE:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					this._variableIndexes[0] = (int)bytes[3];
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_TEMPERATURE_COMPARE_EQUAL_VARIABLE:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					this._variableIndexes[0] = (int)bytes[3];
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_TIME_COMPARE_GREATER:
				case ProgramModule.Block.COMMAND_NUMBER.IF_TIME_COMPARE_EQUAL:
				case ProgramModule.Block.COMMAND_NUMBER.IF_TIME_COMPARE_LESS:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.TIME;
					this._values[0] = (int)bytes[3];
					this._values[1] = (int)bytes[4];
					if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.IF_TIME_COMPARE_GREATER)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					}
					else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.IF_TIME_COMPARE_EQUAL)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					}
					else
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					}
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_ALARAM_ON:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.ALARM;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_ALARAM_OFF:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.ALARM;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_TIMER_ON:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.TIMER;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_TIMER_OFF:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.TIMER;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_COUNTER_COMPARE_GREATER:
				case ProgramModule.Block.COMMAND_NUMBER.IF_COUNTER_COMPARE_EQUAL:
				case ProgramModule.Block.COMMAND_NUMBER.IF_COUNTER_COMPARE_LESS:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.COUNTER;
					this._values[0] = (int)bytes[3];
					if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.IF_COUNTER_COMPARE_GREATER)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					}
					else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.IF_COUNTER_COMPARE_EQUAL)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					}
					else
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					}
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_VARIABLE_COMPARE_GREATER_CONST:
				case ProgramModule.Block.COMMAND_NUMBER.IF_VARIABLE_COMPARE_EQUAL_CONST:
				case ProgramModule.Block.COMMAND_NUMBER.IF_VARIABLE_COMPARE_LESS_CONST:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.VARIABLE;
					this._variableIndexes[0] = (int)bytes[3];
					this._values[0] = (int)((sbyte)bytes[4]);
					if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.IF_VARIABLE_COMPARE_GREATER_CONST)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					}
					else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.IF_VARIABLE_COMPARE_EQUAL_CONST)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					}
					else
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					}
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_VARIABLE_COMPARE_GREATER_VARIABLE:
				case ProgramModule.Block.COMMAND_NUMBER.IF_VARIABLE_COMPARE_EQUAL_VARIABLE:
				case ProgramModule.Block.COMMAND_NUMBER.IF_VARIABLE_COMPARE_LESS_VARIABLE:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.VARIABLE;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					this._variableIndexes[0] = (int)bytes[3];
					this._variableIndexes[1] = (int)bytes[4];
					if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.IF_VARIABLE_COMPARE_GREATER_VARIABLE)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					}
					else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.IF_VARIABLE_COMPARE_EQUAL_VARIABLE)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					}
					else
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					}
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_ELSE:
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_START:
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END:
				case ProgramModule.Block.COMMAND_NUMBER.SUBROUTINE:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_BEGIN:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_EQUAL_VARIABLE:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_EQUAL_TEMPERATURE:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_ADD_CONST:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_ADD_VARIABLE:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_ADD_TEMPERATURE:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_SUB_CONST:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_SUB_VARIABLE:
				case ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_SUB_TEMPERATURE:
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_RANDOM:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.RANDOM;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_SECOND_BEGIN:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					this._values[0] = (int)bytes[3];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_LIGHT_CONST_SAME:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					this._values[0] = (int)bytes[3];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_LIGHT_CONST_DARK:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					this._values[0] = (int)bytes[3];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_LIGHT_VARIABLE_BRIGHT:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					this._variableIndexes[0] = (int)bytes[3];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_LIGHT_VARIABLE_SAME:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					this._variableIndexes[0] = (int)bytes[3];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_LIGHT_VARIABLE_DARK:
					this._condition = ProgramModule.BlockIf.CONDITION_IF.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					this._variableIndexes[0] = (int)bytes[3];
					break;
				default:
					if (command_NUMBER != ProgramModule.Block.COMMAND_NUMBER.IF_THIRD_BEGIN)
					{
						if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.IF_USBIN_OFF)
						{
							this._condition = ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX;
							this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
						}
					}
					else
					{
						this._condition = ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX;
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					}
					break;
				}
				return true;
			}

			// Token: 0x06000E5E RID: 3678 RVA: 0x0007B040 File Offset: 0x00079240
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (this._else != null)
				{
					Point point = new Point(base.Location.X + base.Points[2].X + ProgramModule.Block.CONNECT_POINT_SIZE / 2, base.Location.Y + base.Points[2].Y + ProgramModule.Block.CONNECT_POINT_SIZE / 2);
					Point point2 = new Point(this._else.Location.X + this._else.Points[0].X + ProgramModule.Block.CONNECT_POINT_SIZE / 2, this._else.Location.Y + this._else.Points[0].Y);
					if (base.ConnectState == ProgramModule.Block.CONNECT_STATE.RIGHT && this._else.ConnectState == ProgramModule.Block.CONNECT_STATE.RIGHT)
					{
						ProgramModule.Block.paintArrow(graphics, point, point2, ProgramModule.Block.CONNECT_POINT.RIGHT, ProgramModule.Block.ALLOW_GREEN);
					}
					else
					{
						ProgramModule.Block.paintArrow(graphics, point, point2, ProgramModule.Block.CONNECT_POINT.RIGHT, Color.Red);
					}
				}
				if (index == -1)
				{
					if (this._isConditionNetwork)
					{
						switch (this._conditionNetwork)
						{
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.OBJECT_BUTTON:
							graphics.DrawImage(Resources.nw_block_080, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE:
							graphics.DrawImage(Resources.fc_block_160, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.BUTTON:
							graphics.DrawImage(Resources.fc_block_090, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								graphics.DrawImage(Resources.fc_block_100, base.Location);
							}
							else
							{
								graphics.DrawImage(Resources.fc_block_105, base.Location);
							}
							break;
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.TEMPERATURE:
							graphics.DrawImage(Resources.fc_block_140, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.SOUND:
							graphics.DrawImage(Resources.fc_block_110, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.USBIN:
							graphics.DrawImage(Resources.fc_block_270, base.Location);
							break;
						}
					}
					else
					{
						switch (this._condition)
						{
						case ProgramModule.BlockIf.CONDITION_IF.BUTTON:
							graphics.DrawImage(Resources.fc_block_090, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_IF.LIGHT:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								graphics.DrawImage(Resources.fc_block_100, base.Location);
							}
							else
							{
								graphics.DrawImage(Resources.fc_block_105, base.Location);
							}
							break;
						case ProgramModule.BlockIf.CONDITION_IF.SOUND:
							graphics.DrawImage(Resources.fc_block_110, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_IF.ALARM:
							graphics.DrawImage(Resources.fc_block_120, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_IF.TIMER:
							graphics.DrawImage(Resources.fc_block_130, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_IF.TIME:
							graphics.DrawImage(Resources.fc_block_240, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE:
							graphics.DrawImage(Resources.fc_block_140, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_IF.RANDOM:
							graphics.DrawImage(Resources.fc_block_170, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_IF.COUNTER:
							graphics.DrawImage(Resources.fc_block_150, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_IF.VARIABLE:
							graphics.DrawImage(Resources.fc_block_160, base.Location);
							break;
						case ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX:
							graphics.DrawImage(Resources.fc_block_270, base.Location);
							break;
						}
					}
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000E5F RID: 3679 RVA: 0x0007B398 File Offset: 0x00079598
			public override void paintRect(Graphics graphics, Color color, bool fill)
			{
				Point[] array = new Point[]
				{
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 2, base.Location.Y),
					new Point(base.Location.X, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height / 2),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 2, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height / 2)
				};
				if (fill)
				{
					Brush brush = new SolidBrush(color);
					graphics.FillPolygon(brush, array);
					return;
				}
				Pen pen = new Pen(color, 4f);
				graphics.DrawPolygon(pen, array);
			}

			// Token: 0x06000E60 RID: 3680 RVA: 0x0007B4C0 File Offset: 0x000796C0
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					int num = base.LocationBlock.Y;
					graphics.DrawImage(Resources.bp_block_050, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_051, new Rectangle(base.LocationBlock.X + Resources.bp_block_050.Width, num, base.SizeBlock.Width - Resources.bp_block_050.Width - Resources.bp_block_052.Width, Resources.bp_block_051.Height));
					graphics.DrawImage(Resources.bp_block_052, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_052.Width, num));
					num += ProgramModule.Block.LINE_HEIGHT;
					if (base.Branches[0] == null)
					{
						graphics.DrawImage(Resources.bp_block_053, new Rectangle(base.LocationBlock.X, num, Resources.bp_block_053.Width, ProgramModule.Block.LINE_HEIGHT));
						num += ProgramModule.Block.LINE_HEIGHT;
					}
					else
					{
						int height = base.Branches[0].getConnectedBlocksSize().Height;
						graphics.DrawImage(Resources.bp_block_053, new Rectangle(base.LocationBlock.X, num, Resources.bp_block_053.Width, height));
						num += height;
					}
					if (base.Branches.Count == 2)
					{
						graphics.DrawImage(Resources.bp_block_055, new Point(base.LocationBlock.X, num));
						graphics.DrawImage(Resources.bp_block_051, new Rectangle(base.LocationBlock.X + Resources.bp_block_055.Width, num, base.SizeBlock.Width - Resources.bp_block_055.Width - Resources.bp_block_052.Width, Resources.bp_block_051.Height));
						graphics.DrawImage(Resources.bp_block_052, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_052.Width, num));
						if (isDetail)
						{
							graphics.DrawString("でなければ", ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_010.Width, num + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						}
						num += ProgramModule.Block.LINE_HEIGHT;
						if (base.Branches[1] == null)
						{
							graphics.DrawImage(Resources.bp_block_054, new Rectangle(base.LocationBlock.X, num, Resources.bp_block_054.Width, ProgramModule.Block.LINE_HEIGHT));
							num += ProgramModule.Block.LINE_HEIGHT;
						}
						else
						{
							int height2 = base.Branches[1].getConnectedBlocksSize().Height;
							graphics.DrawImage(Resources.bp_block_054, new Rectangle(base.LocationBlock.X, num, Resources.bp_block_054.Width, height2));
							num += height2;
						}
						graphics.DrawImage(Resources.bp_block_057, new Point(base.LocationBlock.X, num));
						graphics.DrawImage(Resources.bp_block_051, new Rectangle(base.LocationBlock.X + Resources.bp_block_057.Width, num, base.SizeBlock.Width - Resources.bp_block_050.Width - Resources.bp_block_052.Width, Resources.bp_block_051.Height));
						graphics.DrawImage(Resources.bp_block_052, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_052.Width, num));
					}
					else
					{
						graphics.DrawImage(Resources.bp_block_056, new Point(base.LocationBlock.X, num));
						graphics.DrawImage(Resources.bp_block_051, new Rectangle(base.LocationBlock.X + Resources.bp_block_056.Width, num, base.SizeBlock.Width - Resources.bp_block_050.Width - Resources.bp_block_052.Width, Resources.bp_block_051.Height));
						graphics.DrawImage(Resources.bp_block_052, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_052.Width, num));
					}
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					if (base.Branches.Count == 1)
					{
						graphics.DrawLines(Pens.Black, new Point[]
						{
							base.LocationBlock,
							new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y),
							new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT),
							new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT),
							new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT),
							new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT),
							new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + base.SizeBlock.Height),
							new Point(base.LocationBlock.X, base.LocationBlock.Y + base.SizeBlock.Height),
							base.LocationBlock
						});
					}
					else
					{
						int num2 = ((base.Branches[0] == null) ? ProgramModule.Block.LINE_HEIGHT : base.Branches[0].getConnectedBlocksSize().Height);
						graphics.DrawLines(Pens.Black, new Point[]
						{
							base.LocationBlock,
							new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y),
							new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT),
							new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT),
							new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT + num2),
							new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT + num2),
							new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT * 2 + num2),
							new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT * 2 + num2),
							new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT),
							new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT),
							new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + base.SizeBlock.Height),
							new Point(base.LocationBlock.X, base.LocationBlock.Y + base.SizeBlock.Height),
							base.LocationBlock
						});
						if (isDetail)
						{
							graphics.DrawString("でなければ", ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT + num2 + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						}
					}
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000E61 RID: 3681 RVA: 0x0007BF5C File Offset: 0x0007A15C
			public override void setConnect(ProgramModule.Block.CONNECT_POINT point, ProgramModule.Block block)
			{
				if (point == ProgramModule.Block.CONNECT_POINT.RIGHT)
				{
					this._else = block;
					return;
				}
				base.setConnect(point, block);
			}

			// Token: 0x06000E62 RID: 3682 RVA: 0x0007BF74 File Offset: 0x0007A174
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				string text = "";
				base.addIndent(ref text, indent);
				text = text + "IF " + this.getProgramCondition() + " THEN\r\n";
				base.addIndent(ref text, indent + 3);
				text += "GOTO:";
				if (base.Next != null)
				{
					if (base.Next.GetType() == typeof(ProgramModule.BlockEnd))
					{
						text += "[end]";
					}
					else
					{
						int num = blockList.IndexOf(base.Next);
						if (base.Next == this)
						{
							num = blockList.Count;
						}
						if (num >= 0)
						{
							text += num.ToString();
						}
						else
						{
							text += (codeList.Count + 1).ToString();
						}
					}
				}
				text += "\r\n";
				base.addIndent(ref text, indent + 2);
				text += "ELSE\r\n";
				base.addIndent(ref text, indent + 3);
				text += "GOTO:";
				int count = codeList.Count;
				codeList.Add(text);
				base.getProgram(blockList, codeList, indent);
				if (this._else != null)
				{
					if (this._else.GetType() == typeof(ProgramModule.BlockEnd))
					{
						text += "[end]";
						codeList[count] = text;
					}
					else
					{
						int num2 = blockList.IndexOf(this._else);
						if (num2 >= 0)
						{
							text += num2.ToString();
							codeList[count] = text;
						}
						else
						{
							text += codeList.Count.ToString();
							codeList[count] = text;
							this._else.getProgram(blockList, codeList, indent);
						}
					}
				}
				text += "\r\n";
				base.addIndent(ref text, indent + 2);
				text += "ENDIF";
				codeList[count] = text;
			}

			// Token: 0x06000E63 RID: 3683 RVA: 0x0007C148 File Offset: 0x0007A348
			public override void convertBlock(List<ProgramModule.Block> checkedBlocks, List<ProgramModule.Block> newBlocks)
			{
				this.createBlockControls();
				checkedBlocks.Add(this);
				if (this._else == null)
				{
					this.initializeBranches(1);
				}
				else
				{
					this.initializeBranches(2);
				}
				if (base.Next != null)
				{
					if (base.Next is ProgramModule.BlockLoopEnd)
					{
						ProgramModule.BlockJump blockJump = new ProgramModule.BlockJump();
						newBlocks.Add(blockJump);
						blockJump.JumpTemp = base.Next;
						base.Branches[0] = blockJump;
						base.Next = null;
					}
					else
					{
						ProgramModule.BlockJump blockJump2 = new ProgramModule.BlockJump();
						newBlocks.Add(blockJump2);
						base.Branches[0] = blockJump2;
						blockJump2.JumpTemp = base.Next;
						if (checkedBlocks.Contains(base.Next))
						{
							base.Next = null;
						}
						else
						{
							base.Next.Before = this;
							base.Next.convertBlock(checkedBlocks, newBlocks);
						}
					}
				}
				if (this._else != null)
				{
					if (this._else is ProgramModule.BlockLoopEnd)
					{
						ProgramModule.BlockJump blockJump3 = new ProgramModule.BlockJump();
						newBlocks.Add(blockJump3);
						blockJump3.JumpTemp = this._else;
						base.Branches[1] = blockJump3;
						this._else = null;
						return;
					}
					ProgramModule.BlockJump blockJump4 = new ProgramModule.BlockJump();
					newBlocks.Add(blockJump4);
					base.Branches[1] = blockJump4;
					blockJump4.JumpTemp = this._else;
					if (checkedBlocks.Contains(this._else))
					{
						this._else = null;
						return;
					}
					this._else.Before = base.Last;
					this._else.Before.Next = this._else;
					this._else.convertBlock(checkedBlocks, newBlocks);
				}
			}

			// Token: 0x06000E64 RID: 3684 RVA: 0x0007C2D0 File Offset: 0x0007A4D0
			public override void convertFlowchart(List<ProgramModule.Block> checkedBlocks)
			{
				checkedBlocks.Add(this);
				ProgramModule.Block block = base.Next;
				while (block != null && block is ProgramModule.BlockLabel)
				{
					block = block.Next;
				}
				if (base.Branches[0] != null)
				{
					if (base.Branches[0] is ProgramModule.BlockLabel)
					{
						base.Next = base.Branches[0].Next;
					}
					else
					{
						base.Next = base.Branches[0];
					}
					if (base.Branches[0] is ProgramModule.BlockJump)
					{
						base.Next.Before = this;
					}
					base.Next.Last.Next = block;
				}
				if (!checkedBlocks.Contains(base.Next))
				{
					base.Next.convertFlowchart(checkedBlocks);
				}
				if (base.Branches.Count > 1 && base.Branches[1] != null)
				{
					if (base.Branches[1] is ProgramModule.BlockLabel)
					{
						this.Else = base.Branches[1].Next;
					}
					else
					{
						this.Else = base.Branches[1];
					}
					if (base.Branches[1] is ProgramModule.BlockJump)
					{
						this.Else = ((ProgramModule.BlockJump)base.Branches[1]).Label.Next;
					}
					else
					{
						this.Else.Last.Next = block;
					}
					if (!checkedBlocks.Contains(this.Else))
					{
						this.Else.convertFlowchart(checkedBlocks);
						return;
					}
				}
				else
				{
					this.Else = block;
				}
			}

			// Token: 0x06000E65 RID: 3685 RVA: 0x0007C460 File Offset: 0x0007A660
			public override string getDetail()
			{
				string text = "";
				if (this._isConditionNetwork)
				{
					switch (this._conditionNetwork)
					{
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.OBJECT_BUTTON:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = this._objectName + "がON";
						}
						else
						{
							text = this._objectName + "がOFF";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								string text2 = ((this._variableIndexes[1] == 0) ? "入力変数" : NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]);
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + text2 + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + this._values[0].ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
							else
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + this._constString + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								string text3 = ((this._variableIndexes[1] == 0) ? "入力変数" : NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]);
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + text3 + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + this._values[0].ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
							else
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + this._constString + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							string text4 = ((this._variableIndexes[1] == 0) ? "入力変数" : NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]);
							text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + text4 + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + this._values[0].ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
						}
						else
						{
							text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + this._constString + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.BUTTON:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "ボタンがON";
						}
						else
						{
							text = "ボタンがOFF";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT:
						text = "周囲が";
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = text + this._values[0].ToString() + "より明るい";
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = text + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "より明るい";
							}
							else
							{
								text += "明るい";
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = text + this._values[0].ToString() + "と同じ";
							}
							else
							{
								text = text + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "と同じ";
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = text + this._values[0].ToString() + "より暗い";
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = text + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "より暗い";
						}
						else
						{
							text += "暗い";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.TEMPERATURE:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
							else
							{
								text = this._values[0].ToString() + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
							else
							{
								text = this._values[0].ToString() + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
						}
						else
						{
							text = this._values[0].ToString() + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.SOUND:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "音がする";
						}
						else
						{
							text = "音がしない";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.USBIN:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "外部入力あり";
						}
						else
						{
							text = "外部入力なし";
						}
						break;
					}
				}
				else
				{
					switch (this._condition)
					{
					case ProgramModule.BlockIf.CONDITION_IF.BUTTON:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "ボタンがON";
						}
						else
						{
							text = "ボタンがOFF";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.LIGHT:
						text = "周囲が";
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = text + this._values[0].ToString() + "より明るい";
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = text + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "より明るい";
							}
							else
							{
								text += "明るい";
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = text + this._values[0].ToString() + "と同じ";
							}
							else
							{
								text = text + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "と同じ";
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = text + this._values[0].ToString() + "より暗い";
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = text + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "より暗い";
						}
						else
						{
							text += "暗い";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.SOUND:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "音がする";
						}
						else
						{
							text = "音がしない";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.ALARM:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "アラーム入力あり";
						}
						else
						{
							text = "アラーム入力なし";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.TIMER:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "タイマー入力あり";
						}
						else
						{
							text = "タイマー入力なし";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.TIME:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._values[0] < 9)
							{
								text += "0";
							}
							text = text + this._values[0].ToString() + ":";
							if (this._values[1] < 9)
							{
								text += "0";
							}
							text = text + this._values[1].ToString() + "よりも早い";
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._values[0] < 9)
							{
								text += "0";
							}
							text = text + this._values[0].ToString() + ":";
							if (this._values[1] < 9)
							{
								text += "0";
							}
							text = text + this._values[1].ToString() + "と同じ";
						}
						else
						{
							if (this._values[0] < 9)
							{
								text += "0";
							}
							text = text + this._values[0].ToString() + ":";
							if (this._values[1] < 9)
							{
								text += "0";
							}
							text = text + this._values[1].ToString() + "よりも遅い";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
							else
							{
								text = this._values[0].ToString() + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
							else
							{
								text = this._values[0].ToString() + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
						}
						else
						{
							text = this._values[0].ToString() + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.RANDOM:
						text = "ランダム";
						break;
					case ProgramModule.BlockIf.CONDITION_IF.COUNTER:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							text = this._values[0].ToString() + "よりも多い";
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							text = this._values[0].ToString() + "と同じ";
						}
						else
						{
							text = this._values[0].ToString() + "よりも小さい";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.VARIABLE:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "が" + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[1]] + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
							else
							{
								text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "が" + this._values[0].ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "が" + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[1]] + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
							else
							{
								text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "が" + this._values[0].ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "が" + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[1]] + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
						}
						else
						{
							text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "が" + this._values[0].ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "外部入力あり";
						}
						else
						{
							text = "外部入力なし";
						}
						break;
					}
				}
				return text;
			}

			// Token: 0x06000E66 RID: 3686 RVA: 0x0007D18C File Offset: 0x0007B38C
			public override string getDetailBlock(bool isPrint)
			{
				string text = "";
				if (this._isConditionNetwork)
				{
					switch (this.ConditionNetwork)
					{
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.OBJECT_BUTTON:
						if (base.Controls.Count == 0 || ((ComboBox)base.Controls[0]).SelectedItem == null)
						{
							text = (isPrint ? ("もしが" + ProgramModule.BlockIf.SELECT_BUTTON_ITEMS[(int)this._select] + "なら") : "もし\u3000\u3000\u3000\u3000 が\u3000\u3000\u3000なら");
						}
						else
						{
							text = (isPrint ? string.Concat(new string[]
							{
								"もし",
								this._objectName,
								"が",
								ProgramModule.BlockIf.SELECT_BUTTON_ITEMS[(int)this._select],
								"なら"
							}) : "もし\u3000\u3000\u3000\u3000 が\u3000\u3000\u3000なら");
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE:
						if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = (isPrint ? string.Format("もし(C){0}が{1}{2}なら", NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]], this._values[0], ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select]) : "もし\u3000\u3000\u3000\u3000 が\u3000\u3000\u3000\u3000\u3000\u3000\u3000 なら");
						}
						else if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							string text2 = ((this._variableIndexes[1] == 0) ? "入力変数" : ("(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]));
							text = (isPrint ? string.Concat(new string[]
							{
								"もし(C)",
								NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]],
								"が",
								text2,
								ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select],
								"なら"
							}) : "もし\u3000\u3000\u3000\u3000 が\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら");
						}
						else
						{
							text = (isPrint ? string.Concat(new string[]
							{
								"もし(C)",
								NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]],
								"が",
								this._constString,
								ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select],
								"なら"
							}) : "もし\u3000\u3000\u3000\u3000 が\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら");
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.BUTTON:
						text = (isPrint ? ("もしコロックルのボタンが" + ProgramModule.BlockIf.SELECT_BUTTON_ITEMS[(int)this._select] + "なら") : "もしコロックルのボタンが\u3000\u3000\u3000なら");
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT:
						if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = (isPrint ? string.Format("もし周囲が{0}{1}なら", this._values[0], ProgramModule.BlockIf.LIGHT_ITEMS[(int)this._select]) : "もし周囲が\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら");
						}
						else if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = (isPrint ? ("もし周囲が(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + ProgramModule.BlockIf.LIGHT_ITEMS[(int)this._select] + "なら") : "もし周囲が\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら");
						}
						else
						{
							text = (isPrint ? ("もし周囲が" + ProgramModule.BlockIf.SELECT_LIGHT2_ITEMS[(int)this._select] + "なら") : "もし周囲が\u3000\u3000\u3000\u3000なら");
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.TEMPERATURE:
						if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = (isPrint ? string.Format("もし温度が{0}℃{1}なら", this._values[0], ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select]) : "もし温度が\u3000\u3000\u3000℃\u3000\u3000\u3000\u3000 なら");
						}
						else
						{
							text = (isPrint ? string.Concat(new string[]
							{
								"もし温度が(C)",
								NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]],
								"℃",
								ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select],
								"なら"
							}) : "もし温度が\u3000\u3000\u3000\u3000 ℃\u3000\u3000\u3000\u3000 なら");
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.SOUND:
						text = (isPrint ? ("もし音が" + ProgramModule.BlockIf.SELECT_SOUND_ITEMS[(int)this._select] + "なら") : "もし音が\u3000\u3000 \u3000なら");
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.USBIN:
						text = (isPrint ? ("もし外部入力が" + ProgramModule.BlockIf.SELECT_USBIN_ITEMS[(int)this._select] + "なら") : "もし外部入力が\u3000\u3000\u3000なら");
						break;
					}
				}
				else
				{
					switch (this.Condition)
					{
					case ProgramModule.BlockIf.CONDITION_IF.BUTTON:
						text = (isPrint ? ("もしボタンが" + ProgramModule.BlockIf.SELECT_BUTTON_ITEMS[(int)this._select] + "なら") : "もしボタンが\u3000\u3000\u3000なら");
						break;
					case ProgramModule.BlockIf.CONDITION_IF.LIGHT:
						if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = (isPrint ? string.Format("もし周囲が{0}{1}なら", this._values[0], ProgramModule.BlockIf.LIGHT_ITEMS[(int)this._select]) : "もし周囲が\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら");
						}
						else if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = (isPrint ? ("もし周囲が" + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + ProgramModule.BlockIf.LIGHT_ITEMS[(int)this._select] + "なら") : "もし周囲が\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら");
						}
						else
						{
							text = (isPrint ? ("もし周囲が" + ProgramModule.BlockIf.SELECT_LIGHT2_ITEMS[(int)this._select] + "なら") : "もし周囲が\u3000\u3000\u3000\u3000なら");
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.SOUND:
						text = (isPrint ? ("もし音が" + ProgramModule.BlockIf.SELECT_SOUND_ITEMS[(int)this._select] + "なら") : "もし音が\u3000\u3000\u3000なら");
						break;
					case ProgramModule.BlockIf.CONDITION_IF.ALARM:
						text = (isPrint ? ("もしアラーム入力" + ProgramModule.BlockIf.SELECT_ALARM_ITEMS[(int)this._select] + "なら") : "もしアラーム入力\u3000\u3000\u3000なら");
						break;
					case ProgramModule.BlockIf.CONDITION_IF.TIMER:
						text = (isPrint ? ("もしタイマー入力" + ProgramModule.BlockIf.SELECT_TIMER_ITEMS[(int)this._select] + "なら") : "もしタイマー入力\u3000\u3000\u3000なら");
						break;
					case ProgramModule.BlockIf.CONDITION_IF.TIME:
						text = (isPrint ? string.Concat(new string[]
						{
							"もし時刻が",
							this._values[0].ToString().PadLeft(2, '0'),
							":",
							this._values[1].ToString().PadLeft(2, '0'),
							ProgramModule.BlockIf.SELECT_TIME_ITEMS[(int)this._select],
							"なら"
						}) : "もし時刻が\u3000\u3000：\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら");
						break;
					case ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE:
						if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = (isPrint ? string.Format("もし温度が{0}℃{1}なら", this._values[0], ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select]) : "もし温度が\u3000\u3000\u3000℃\u3000\u3000\u3000\u3000\u3000なら");
						}
						else
						{
							text = (isPrint ? string.Concat(new string[]
							{
								"もし温度が",
								ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]],
								"℃",
								ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select],
								"なら"
							}) : "もし温度が\u3000\u3000\u3000 ℃\u3000\u3000\u3000 \u3000 なら");
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.RANDOM:
						text = (isPrint ? "ランダム" : "ランダム");
						break;
					case ProgramModule.BlockIf.CONDITION_IF.COUNTER:
						text = (isPrint ? string.Format("もし秒カウンタが{0}{1}なら", this._values[0], ProgramModule.BlockIf.SELECT_COUNTER_ITEMS[(int)this._select]) : "もし秒カウンタが\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら");
						break;
					case ProgramModule.BlockIf.CONDITION_IF.VARIABLE:
						if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = (isPrint ? string.Format("もし{0}が{1}{2}なら", ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]], this._values[0], ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select]) : "もし\u3000\u3000\u3000 が\u3000\u3000\u3000\u3000\u3000\u3000\u3000 なら");
						}
						else
						{
							text = (isPrint ? string.Concat(new string[]
							{
								"もし",
								ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]],
								"が",
								ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[1]],
								ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select],
								"なら"
							}) : "もし\u3000\u3000\u3000 が\u3000\u3000\u3000\u3000\u3000\u3000\u3000 なら");
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX:
						text = (isPrint ? ("もし外部入力が" + ProgramModule.BlockIf.SELECT_USBIN_ITEMS[(int)this._select] + "なら") : "もし外部入力が\u3000\u3000\u3000なら");
						break;
					}
				}
				return text;
			}

			// Token: 0x06000E67 RID: 3687 RVA: 0x0007D964 File Offset: 0x0007BB64
			public override int getUsedMemory()
			{
				int num = 0;
				switch (this._condition)
				{
				case ProgramModule.BlockIf.CONDITION_IF.BUTTON:
				case ProgramModule.BlockIf.CONDITION_IF.SOUND:
				case ProgramModule.BlockIf.CONDITION_IF.ALARM:
				case ProgramModule.BlockIf.CONDITION_IF.TIMER:
				case ProgramModule.BlockIf.CONDITION_IF.RANDOM:
				case ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX:
					num = 3;
					break;
				case ProgramModule.BlockIf.CONDITION_IF.LIGHT:
					if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID)
					{
						num = 3;
					}
					else
					{
						num = 4;
					}
					break;
				case ProgramModule.BlockIf.CONDITION_IF.TIME:
				case ProgramModule.BlockIf.CONDITION_IF.VARIABLE:
					num = 5;
					break;
				case ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE:
				case ProgramModule.BlockIf.CONDITION_IF.COUNTER:
					num = 4;
					break;
				}
				return num;
			}

			// Token: 0x06000E68 RID: 3688 RVA: 0x0007968A File Offset: 0x0007788A
			public override bool isConnectable(ProgramModule.Block block)
			{
				return true;
			}

			// Token: 0x06000E69 RID: 3689 RVA: 0x0007D9CC File Offset: 0x0007BBCC
			public override bool isIconBlock()
			{
				if (this._else != this)
				{
					return false;
				}
				switch (this._condition)
				{
				case ProgramModule.BlockIf.CONDITION_IF.BUTTON:
				case ProgramModule.BlockIf.CONDITION_IF.SOUND:
				case ProgramModule.BlockIf.CONDITION_IF.ALARM:
				case ProgramModule.BlockIf.CONDITION_IF.TIMER:
					return this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON;
				case ProgramModule.BlockIf.CONDITION_IF.LIGHT:
					return this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID;
				case ProgramModule.BlockIf.CONDITION_IF.TIME:
					return this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF;
				case ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE:
					return this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF && this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
				default:
					return false;
				}
			}

			// Token: 0x06000E6A RID: 3690 RVA: 0x0007DA44 File Offset: 0x0007BC44
			public void convertToBlockWaitCondition(ProgramModule.BlockWaitCondition blockWaitCondition)
			{
				blockWaitCondition.Next = base.Next;
				blockWaitCondition.Condition = (ProgramModule.BlockWaitCondition.CONDITION)this._condition;
				ProgramModule.BlockIf.CONDITION_IF condition = this._condition;
				if (condition != ProgramModule.BlockIf.CONDITION_IF.LIGHT)
				{
					if (condition == ProgramModule.BlockIf.CONDITION_IF.TIME)
					{
						blockWaitCondition.Hour = this._values[0];
						blockWaitCondition.Minute = this._values[1];
						return;
					}
					if (condition != ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE)
					{
						return;
					}
					blockWaitCondition.Temperature = this._values[0];
					return;
				}
				else
				{
					if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
					{
						blockWaitCondition.Light = ProgramModule.BlockWaitCondition.LIGHT.BRIGHT;
						return;
					}
					blockWaitCondition.Light = ProgramModule.BlockWaitCondition.LIGHT.DARK;
					return;
				}
			}

			// Token: 0x06000E6B RID: 3691 RVA: 0x0007DAC0 File Offset: 0x0007BCC0
			public override ProgramModule.Block.CONNECT_STATE updateConnectState(List<ProgramModule.Block> blocks)
			{
				blocks.Add(this);
				base.ConnectState = ProgramModule.Block.CONNECT_STATE.START;
				if (base.Next != null)
				{
					if (blocks.IndexOf(base.Next) == -1)
					{
						base.ConnectState = base.Next.updateConnectState(blocks);
					}
					else
					{
						base.ConnectState = base.Next.ConnectState;
					}
				}
				if (this._else != null)
				{
					if (blocks.IndexOf(this._else) == -1)
					{
						base.ConnectState = ((this._else.updateConnectState(blocks) == ProgramModule.Block.CONNECT_STATE.RIGHT) ? ProgramModule.Block.CONNECT_STATE.RIGHT : base.ConnectState);
					}
					else
					{
						base.ConnectState = ((this._else.ConnectState == ProgramModule.Block.CONNECT_STATE.RIGHT) ? ProgramModule.Block.CONNECT_STATE.RIGHT : base.ConnectState);
					}
				}
				return base.ConnectState;
			}

			// Token: 0x06000E6C RID: 3692 RVA: 0x0007DB74 File Offset: 0x0007BD74
			private string getProgramCondition()
			{
				string text = "";
				if (this._isConditionNetwork)
				{
					switch (this._conditionNetwork)
					{
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.OBJECT_BUTTON:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = this._objectName + " = ON";
						}
						else
						{
							text = this._objectName + " = OFF";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								string text2 = ((this._variableIndexes[1] == 0) ? "INPUT" : NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]);
								text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " > " + text2;
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " > " + this._values[0].ToString();
							}
							else
							{
								text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " > " + this._constString;
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								string text3 = ((this._variableIndexes[1] == 0) ? "INPUT" : NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]);
								text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " = " + text3;
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " = " + this._values[0].ToString();
							}
							else
							{
								text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " = " + this._constString;
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							string text4 = ((this._variableIndexes[1] == 0) ? "INPUT" : NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]);
							text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " < " + text4;
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " < " + this._values[0].ToString();
						}
						else
						{
							text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " < " + this._constString;
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.BUTTON:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "BUTTON = ON";
						}
						else
						{
							text = "BUTTON = OFF";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT:
						if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text = "LIGHT > " + this._values[0].ToString();
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								text = "LIGHT = " + this._values[0].ToString();
							}
							else
							{
								text = "LIGHT < " + this._values[0].ToString();
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text = "LIGHT > " + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]];
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								text = "LIGHT = " + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]];
							}
							else
							{
								text = "LIGHT < " + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]];
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "LIGHT = BRIGHT";
						}
						else
						{
							text = "LIGHT = DARK";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.TEMPERATURE:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = "TEMPERATURE > " + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]];
							}
							else
							{
								text = "TEMPERATURE > " + this._values[0].ToString();
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = "TEMPERATURE = " + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]];
							}
							else
							{
								text = "TEMPETATURE = " + this._values[0].ToString();
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = "TEMPERATURE < " + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]];
						}
						else
						{
							text = "TEMPERATURE < " + this._values[0].ToString();
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.SOUND:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "SOUND = ON";
						}
						else
						{
							text = "SOUND = OFF";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_NETWORK_IF.USBIN:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "INPUT = ON";
						}
						else
						{
							text = "INPUT = OFF";
						}
						break;
					}
				}
				else
				{
					switch (this._condition)
					{
					case ProgramModule.BlockIf.CONDITION_IF.BUTTON:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "BUTTON = ON";
						}
						else
						{
							text = "BUTTON = OFF";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.LIGHT:
						if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text = "LIGHT > " + this._values[0].ToString();
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								text = "LIGHT = " + this._values[0].ToString();
							}
							else
							{
								text = "LIGHT < " + this._values[0].ToString();
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text = "LIGHT > " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]];
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								text = "LIGHT = " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]];
							}
							else
							{
								text = "LIGHT < " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]];
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "LIGHT = BRIGHT";
						}
						else
						{
							text = "LIGHT = DARK";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.SOUND:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "SOUND = ON";
						}
						else
						{
							text = "SOUND = OFF";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.ALARM:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "ALARM = ON";
						}
						else
						{
							text = "ALARM = OFF";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.TIMER:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "TIMER = ON";
						}
						else
						{
							text = "TIMER = OFF";
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.TIME:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							text = string.Concat(new string[]
							{
								"HOUR < ",
								this._values[0].ToString(),
								" OR HOUR = ",
								this._values[0].ToString(),
								" AND MINUTE < ",
								this._values[1].ToString()
							});
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							text = "HOUR = " + this._values[0].ToString() + " AND MINUTE = " + this._values[1].ToString();
						}
						else
						{
							text = string.Concat(new string[]
							{
								"HOUR > ",
								this._values[0].ToString(),
								" OR HOUR = ",
								this._values[0].ToString(),
								" AND MINUTE > ",
								this._values[1].ToString()
							});
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = "TEMPERATURE > " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]];
							}
							else
							{
								text = "TEMPERATURE > " + this._values[0].ToString();
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = "TEMPERATURE = " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]];
							}
							else
							{
								text = "TEMPETATURE = " + this._values[0].ToString();
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = "TEMPERATURE < " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]];
						}
						else
						{
							text = "TEMPERATURE < " + this._values[0].ToString();
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.RANDOM:
						text = "RANDOM";
						break;
					case ProgramModule.BlockIf.CONDITION_IF.COUNTER:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							text = "COUNTER > " + this._values[0].ToString();
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							text = "COUNTER = " + this._values[0].ToString();
						}
						else
						{
							text = "COUNTER < " + this._values[0].ToString();
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.VARIABLE:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " > " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[1]];
							}
							else
							{
								text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " > " + this._values[0].ToString();
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " = " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[1]];
							}
							else
							{
								text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " = " + this._values[0].ToString();
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " < " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[1]];
						}
						else
						{
							text = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " < " + this._values[0].ToString();
						}
						break;
					case ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "INPUT = ON";
						}
						else
						{
							text = "INPUT = OFF";
						}
						break;
					}
				}
				return text;
			}

			// Token: 0x06000E6D RID: 3693 RVA: 0x0007E660 File Offset: 0x0007C860
			public override void updateData()
			{
				((ComboBox)base.Controls[4]).Items.Clear();
				foreach (string text in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					((ComboBox)base.Controls[4]).Items.Add("(C)" + text);
				}
				((ComboBox)base.Controls[5]).Items.Clear();
				((ComboBox)base.Controls[5]).Items.Add("入力変数");
				foreach (string text2 in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					((ComboBox)base.Controls[5]).Items.Add("(C)" + text2);
				}
			}

			// Token: 0x06000E6E RID: 3694 RVA: 0x0007E7A0 File Offset: 0x0007C9A0
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_010.Width;
					if (this._isConditionNetwork)
					{
						switch (this.ConditionNetwork)
						{
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.OBJECT_BUTTON:
						{
							int num = TextRenderer.MeasureText("もし", ProgramModule.Block._fontBlock).Width;
							base.Controls[0].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							num += base.Controls[0].Width + TextRenderer.MeasureText("が", ProgramModule.Block._fontBlock).Width;
							base.Controls[1].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE:
						{
							int num = TextRenderer.MeasureText("もし", ProgramModule.Block._fontBlock).Width;
							base.Controls[2].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							num += base.Controls[2].Width + TextRenderer.MeasureText("が", ProgramModule.Block._fontBlock).Width;
							if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								base.Controls[11].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
								num += base.Controls[11].Width;
							}
							else if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								base.Controls[3].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
								num += base.Controls[3].Width;
							}
							else
							{
								base.Controls[14].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
								num += base.Controls[14].Width;
							}
							num += ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							base.Controls[4].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.BUTTON:
						{
							int num = TextRenderer.MeasureText("もしコロックルのボタンが", ProgramModule.Block._fontBlock).Width;
							base.Controls[5].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT:
						{
							int num = TextRenderer.MeasureText("もし周囲が", ProgramModule.Block._fontBlock).Width;
							if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								base.Controls[13].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
								num += base.Controls[13].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
								base.Controls[8].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
								return;
							}
							if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								base.Controls[2].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
								num += base.Controls[2].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
								base.Controls[8].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
								return;
							}
							base.Controls[7].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.TEMPERATURE:
						{
							int num = TextRenderer.MeasureText("もし温度が", ProgramModule.Block._fontBlock).Width;
							if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								base.Controls[12].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
								num += base.Controls[12].Width;
							}
							else
							{
								base.Controls[2].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
								num += base.Controls[2].Width;
							}
							num += TextRenderer.MeasureText("度", ProgramModule.Block._fontBlock).Width;
							base.Controls[6].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.SOUND:
						{
							int num = TextRenderer.MeasureText("もし音が", ProgramModule.Block._fontBlock).Width;
							base.Controls[9].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.USBIN:
						{
							int num = TextRenderer.MeasureText("もし外部入力が", ProgramModule.Block._fontBlock).Width;
							base.Controls[10].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						default:
							return;
						}
					}
					else
					{
						switch (this.Condition)
						{
						case ProgramModule.BlockIf.CONDITION_IF.BUTTON:
						{
							int num = TextRenderer.MeasureText("もしボタンが", ProgramModule.Block._fontBlock).Width;
							base.Controls[0].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_IF.LIGHT:
						{
							int num = TextRenderer.MeasureText("もし周囲が", ProgramModule.Block._fontBlock).Width;
							base.Controls[2].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							base.Controls[13].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							base.Controls[4].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								num += base.Controls[13].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							}
							else
							{
								num += base.Controls[4].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							}
							base.Controls[3].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_IF.SOUND:
						{
							int num = TextRenderer.MeasureText("もし音が", ProgramModule.Block._fontBlock).Width;
							base.Controls[1].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_IF.ALARM:
						{
							int num = TextRenderer.MeasureText("もしアラーム入力", ProgramModule.Block._fontBlock).Width;
							base.Controls[6].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_IF.TIMER:
						{
							int num = TextRenderer.MeasureText("もしタイマー入力", ProgramModule.Block._fontBlock).Width;
							base.Controls[7].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_IF.TIME:
						{
							int num = TextRenderer.MeasureText("もし時刻が", ProgramModule.Block._fontBlock).Width;
							base.Controls[14].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							num += base.Controls[14].Width + TextRenderer.MeasureText(":", ProgramModule.Block._fontBlock).Width;
							base.Controls[15].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							num += base.Controls[15].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							base.Controls[8].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE:
						{
							int num = TextRenderer.MeasureText("もし温度が", ProgramModule.Block._fontBlock).Width;
							base.Controls[17].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							base.Controls[4].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								num += base.Controls[17].Width;
							}
							else
							{
								num += base.Controls[4].Width;
							}
							num += TextRenderer.MeasureText("℃", ProgramModule.Block._fontBlock).Width;
							base.Controls[10].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_IF.RANDOM:
							break;
						case ProgramModule.BlockIf.CONDITION_IF.COUNTER:
						{
							int num = TextRenderer.MeasureText("もし秒カウンタが", ProgramModule.Block._fontBlock).Width;
							base.Controls[16].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							num += base.Controls[16].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							base.Controls[9].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_IF.VARIABLE:
						{
							int num = TextRenderer.MeasureText("もし", ProgramModule.Block._fontBlock).Width;
							base.Controls[4].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							num += base.Controls[4].Width + TextRenderer.MeasureText("が", ProgramModule.Block._fontBlock).Width;
							base.Controls[18].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							base.Controls[5].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								num += base.Controls[18].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							}
							else
							{
								num += base.Controls[5].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							}
							base.Controls[11].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						case ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX:
						{
							int num = TextRenderer.MeasureText("もし外部入力が", ProgramModule.Block._fontBlock).Width;
							base.Controls[12].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							break;
						}
						default:
							return;
						}
					}
				}
			}

			// Token: 0x06000E6F RID: 3695 RVA: 0x0007F37C File Offset: 0x0007D57C
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				if (this._isConditionNetwork)
				{
					ComboBox comboBox = new ComboBox();
					comboBox.Width = 80;
					foreach (NetworkProgramModules.ObjectInfo objectInfo in NetworkWindow.Instance.Programs.getObjects(NetworkProgramModules.OBJECT_TYPE.BUTTON))
					{
						comboBox.Items.Add(objectInfo.getObjectName());
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 50;
					foreach (string text in ProgramModule.BlockIf.SELECT_BUTTON_ITEMS)
					{
						comboBox.Items.Add(text);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 80;
					foreach (string text2 in NetworkWindow.Instance.Programs.ClientVariableNames)
					{
						comboBox.Items.Add("(C)" + text2);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 80;
					comboBox.Items.Add("入力変数");
					foreach (string text3 in NetworkWindow.Instance.Programs.ClientVariableNames)
					{
						comboBox.Items.Add("(C)" + text3);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 80;
					foreach (string text4 in ProgramModule.BlockIf.COMPARE_ITEMS)
					{
						comboBox.Items.Add(text4);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 50;
					foreach (string text5 in ProgramModule.BlockIf.SELECT_BUTTON_ITEMS)
					{
						comboBox.Items.Add(text5);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 80;
					foreach (string text6 in ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE)
					{
						comboBox.Items.Add(text6);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 60;
					foreach (string text7 in ProgramModule.BlockIf.SELECT_LIGHT2_ITEMS)
					{
						comboBox.Items.Add(text7);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 80;
					foreach (string text8 in ProgramModule.BlockIf.LIGHT_ITEMS)
					{
						comboBox.Items.Add(text8);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 60;
					foreach (string text9 in ProgramModule.BlockIf.SELECT_SOUND_ITEMS)
					{
						comboBox.Items.Add(text9);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 50;
					foreach (string text10 in ProgramModule.BlockIf.SELECT_USBIN_ITEMS)
					{
						comboBox.Items.Add(text10);
					}
					base.Controls.Add(comboBox);
					NumericUpDown numericUpDown = new NumericUpDown();
					numericUpDown.Width = 50;
					numericUpDown.Maximum = 32767m;
					numericUpDown.Minimum = -32768m;
					base.Controls.Add(numericUpDown);
					numericUpDown = new NumericUpDown();
					numericUpDown.Width = 50;
					numericUpDown.Maximum = 50m;
					numericUpDown.Minimum = -10m;
					base.Controls.Add(numericUpDown);
					numericUpDown = new NumericUpDown();
					numericUpDown.Width = 50;
					numericUpDown.Minimum = 0m;
					numericUpDown.Maximum = 100m;
					base.Controls.Add(numericUpDown);
					TextBox textBox = new TextBox();
					base.Controls.Add(textBox);
				}
				else
				{
					ComboBox comboBox2 = new ComboBox();
					comboBox2.Width = 50;
					foreach (string text11 in ProgramModule.BlockIf.SELECT_BUTTON_ITEMS)
					{
						comboBox2.Items.Add(text11);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 50;
					foreach (string text12 in ProgramModule.BlockIf.SELECT_SOUND_ITEMS)
					{
						comboBox2.Items.Add(text12);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 60;
					foreach (string text13 in ProgramModule.BlockIf.SELECT_LIGHT2_ITEMS)
					{
						comboBox2.Items.Add(text13);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 80;
					foreach (string text14 in ProgramModule.BlockIf.LIGHT_ITEMS)
					{
						comboBox2.Items.Add(text14);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 55;
					foreach (string text15 in ProgramModule.BlockIf.VARIABLE_ITEMS)
					{
						comboBox2.Items.Add(text15);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 55;
					foreach (string text16 in ProgramModule.BlockIf.VARIABLE_ITEMS)
					{
						comboBox2.Items.Add(text16);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 50;
					foreach (string text17 in ProgramModule.BlockIf.SELECT_ALARM_ITEMS)
					{
						comboBox2.Items.Add(text17);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 50;
					foreach (string text18 in ProgramModule.BlockIf.SELECT_TIMER_ITEMS)
					{
						comboBox2.Items.Add(text18);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 80;
					foreach (string text19 in ProgramModule.BlockIf.SELECT_TIME_ITEMS)
					{
						comboBox2.Items.Add(text19);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 80;
					foreach (string text20 in ProgramModule.BlockIf.SELECT_COUNTER_ITEMS)
					{
						comboBox2.Items.Add(text20);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 80;
					foreach (string text21 in ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE)
					{
						comboBox2.Items.Add(text21);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 80;
					foreach (string text22 in ProgramModule.BlockIf.COMPARE_ITEMS)
					{
						comboBox2.Items.Add(text22);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 50;
					foreach (string text23 in ProgramModule.BlockIf.SELECT_USBIN_ITEMS)
					{
						comboBox2.Items.Add(text23);
					}
					base.Controls.Add(comboBox2);
					NumericUpDown numericUpDown2 = new NumericUpDown();
					numericUpDown2.Width = 35;
					numericUpDown2.Minimum = 0m;
					numericUpDown2.Maximum = 100m;
					base.Controls.Add(numericUpDown2);
					numericUpDown2 = new NumericUpDown();
					numericUpDown2.Width = 35;
					numericUpDown2.Minimum = 0m;
					numericUpDown2.Maximum = 23m;
					base.Controls.Add(numericUpDown2);
					numericUpDown2 = new NumericUpDown();
					numericUpDown2.Width = 35;
					numericUpDown2.Minimum = 0m;
					numericUpDown2.Maximum = 59m;
					base.Controls.Add(numericUpDown2);
					numericUpDown2 = new NumericUpDown();
					numericUpDown2.Width = 50;
					numericUpDown2.Maximum = 255m;
					base.Controls.Add(numericUpDown2);
					numericUpDown2 = new NumericUpDown();
					numericUpDown2.Width = 50;
					numericUpDown2.Minimum = -10m;
					numericUpDown2.Maximum = 50m;
					base.Controls.Add(numericUpDown2);
					numericUpDown2 = new NumericUpDown();
					numericUpDown2.Width = 50;
					numericUpDown2.Minimum = -128m;
					numericUpDown2.Maximum = 127m;
					base.Controls.Add(numericUpDown2);
				}
				this.updateBlock();
				if (this._isConditionNetwork)
				{
					((ComboBox)base.Controls[0]).SelectedValueChanged += this.comboBoxNetworkObjectButtonIndex_SelectedValueChanged;
					((ComboBox)base.Controls[1]).SelectedValueChanged += this.comboBoxNetworkObjectButton_SelectedValueChanged;
					((ComboBox)base.Controls[2]).SelectedValueChanged += this.comboBoxNetworkVariable_SelectedValueChanged;
					((ComboBox)base.Controls[3]).SelectedValueChanged += this.comboBoxNetworkVariable2_SelectedValueChanged;
					((ComboBox)base.Controls[4]).SelectedValueChanged += this.comboBoxNetworkData_SelectedValueChanged;
					((ComboBox)base.Controls[5]).SelectedValueChanged += this.comboBoxNetworkButton_SelectedValueChanged;
					((ComboBox)base.Controls[6]).SelectedValueChanged += this.comboBoxNetworkTemperature_SelectedValueChanged;
					((ComboBox)base.Controls[7]).SelectedValueChanged += this.comboBoxNetworkLight2_SelectedValueChanged;
					((ComboBox)base.Controls[8]).SelectedValueChanged += this.comboBoxNetworkLight3_SelectedValueChanged;
					((ComboBox)base.Controls[9]).SelectedValueChanged += this.comboBoxNetworkSound_SelectedValueChanged;
					((ComboBox)base.Controls[10]).SelectedValueChanged += this.comboBoxNetworkUsbIn_SelectedValueChanged;
					((NumericUpDown)base.Controls[11]).ValueChanged += this.numericUpDownNetworkData_ValueChanged;
					((NumericUpDown)base.Controls[12]).ValueChanged += this.numericUpDownNetworkTemperature_ValueChanged;
					((NumericUpDown)base.Controls[13]).ValueChanged += this.numericUpDownNetworkLight_ValueChanged;
					((TextBox)base.Controls[14]).TextChanged += this.textBoxNetworkData_TextChanged;
					return;
				}
				((ComboBox)base.Controls[0]).SelectedValueChanged += this.comboBoxButton_SelectedValueChanged;
				((ComboBox)base.Controls[1]).SelectedValueChanged += this.comboBoxSound_SelectedValueChanged;
				((ComboBox)base.Controls[2]).SelectedValueChanged += this.comboBoxLight2_SelectedValueChanged;
				((ComboBox)base.Controls[3]).SelectedValueChanged += this.comboBoxLight3_SelectedValueChanged;
				((ComboBox)base.Controls[4]).SelectedValueChanged += this.comboBoxVariable_SelectedValueChanged;
				((ComboBox)base.Controls[5]).SelectedValueChanged += this.comboBoxVariable2_SelectedValueChanged;
				((ComboBox)base.Controls[6]).SelectedValueChanged += this.comboBoxAlarm_SelectedValueChanged;
				((ComboBox)base.Controls[7]).SelectedValueChanged += this.comboBoxTimer_SelectedValueChanged;
				((ComboBox)base.Controls[8]).SelectedValueChanged += this.comboBoxTime_SelectedValueChanged;
				((ComboBox)base.Controls[9]).SelectedValueChanged += this.comboBoxCounter_SelectedValueChanged;
				((ComboBox)base.Controls[10]).SelectedValueChanged += this.comboBoxTemperature_SelectedValueChanged;
				((ComboBox)base.Controls[11]).SelectedValueChanged += this.comboBoxVariableCompare_SelectedValueChanged;
				((ComboBox)base.Controls[12]).SelectedValueChanged += this.comboBoxUsbIn_SelectedValueChanged;
				((NumericUpDown)base.Controls[13]).ValueChanged += this.numericUpDownLight_ValueChanged;
				((NumericUpDown)base.Controls[14]).ValueChanged += this.numericUpDownHour_ValueChanged;
				((NumericUpDown)base.Controls[15]).ValueChanged += this.numericUpDownMinute_ValueChanged;
				((NumericUpDown)base.Controls[16]).ValueChanged += this.numericUpDownCounter_ValueChanged;
				((NumericUpDown)base.Controls[17]).ValueChanged += this.numericUpDownTemperature_ValueChanged;
				((NumericUpDown)base.Controls[18]).ValueChanged += this.numericUpDownVariable_ValueChanged;
			}

			// Token: 0x06000E70 RID: 3696 RVA: 0x000801EC File Offset: 0x0007E3EC
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					if (this._isConditionNetwork)
					{
						switch (this.ConditionNetwork)
						{
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.OBJECT_BUTTON:
							((ComboBox)base.Controls[0]).SelectedIndex = ((ComboBox)base.Controls[0]).Items.IndexOf(this.ObjectName);
							((ComboBox)base.Controls[1]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE:
							((ComboBox)base.Controls[2]).SelectedIndex = this.VariableIndexes[0];
							((ComboBox)base.Controls[3]).SelectedIndex = this.VariableIndexes[1];
							((ComboBox)base.Controls[4]).SelectedIndex = (int)this._select;
							((NumericUpDown)base.Controls[11]).Value = this.Values[0];
							((TextBox)base.Controls[14]).Text = this._constString;
							return;
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.BUTTON:
							((ComboBox)base.Controls[5]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT:
							if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								((ComboBox)base.Controls[8]).SelectedIndex = (int)this._select;
								((NumericUpDown)base.Controls[13]).Value = this.Values[0];
								return;
							}
							if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								((ComboBox)base.Controls[8]).SelectedIndex = (int)this._select;
								((ComboBox)base.Controls[2]).SelectedIndex = this.VariableIndexes[0];
								return;
							}
							((ComboBox)base.Controls[7]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.TEMPERATURE:
							((ComboBox)base.Controls[6]).SelectedIndex = (int)this._select;
							if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								((NumericUpDown)base.Controls[12]).Value = this.Values[0];
								return;
							}
							((ComboBox)base.Controls[2]).SelectedIndex = this.VariableIndexes[0];
							return;
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.SOUND:
							((ComboBox)base.Controls[9]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_NETWORK_IF.USBIN:
							((ComboBox)base.Controls[10]).SelectedIndex = (int)this._select;
							return;
						default:
							return;
						}
					}
					else
					{
						switch (this.Condition)
						{
						case ProgramModule.BlockIf.CONDITION_IF.BUTTON:
							((ComboBox)base.Controls[0]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_IF.LIGHT:
							if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								((ComboBox)base.Controls[3]).SelectedIndex = (int)this._select;
								((NumericUpDown)base.Controls[13]).Value = this.Values[0];
								return;
							}
							if (this.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								((ComboBox)base.Controls[3]).SelectedIndex = (int)this._select;
								((ComboBox)base.Controls[4]).SelectedIndex = this.VariableIndexes[0];
								return;
							}
							((ComboBox)base.Controls[2]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_IF.SOUND:
							((ComboBox)base.Controls[1]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_IF.ALARM:
							((ComboBox)base.Controls[6]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_IF.TIMER:
							((ComboBox)base.Controls[7]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_IF.TIME:
							((NumericUpDown)base.Controls[14]).Value = this.Values[0];
							((NumericUpDown)base.Controls[15]).Value = this.Values[1];
							((ComboBox)base.Controls[8]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE:
							((NumericUpDown)base.Controls[17]).Value = this.Values[0];
							((ComboBox)base.Controls[4]).SelectedIndex = this.VariableIndexes[0];
							((ComboBox)base.Controls[10]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_IF.RANDOM:
							break;
						case ProgramModule.BlockIf.CONDITION_IF.COUNTER:
							((NumericUpDown)base.Controls[16]).Value = this.Values[0];
							((ComboBox)base.Controls[9]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_IF.VARIABLE:
							((NumericUpDown)base.Controls[18]).Value = this.Values[0];
							((ComboBox)base.Controls[4]).SelectedIndex = this.VariableIndexes[0];
							((ComboBox)base.Controls[5]).SelectedIndex = this.VariableIndexes[1];
							((ComboBox)base.Controls[11]).SelectedIndex = (int)this._select;
							return;
						case ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX:
							((ComboBox)base.Controls[12]).SelectedIndex = (int)this._select;
							break;
						default:
							return;
						}
					}
				}
			}

			// Token: 0x06000E71 RID: 3697 RVA: 0x00080798 File Offset: 0x0007E998
			public override void updateControlVisible(List<Rectangle> rects)
			{
				base.updateControlVisible(rects);
				if (this._isConditionNetwork)
				{
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.OBJECT_BUTTON)
					{
						base.Controls[0].Visible = false;
						base.Controls[1].Visible = false;
					}
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE || this.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						base.Controls[11].Visible = false;
					}
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE || this.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
					{
						base.Controls[3].Visible = false;
					}
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE || this.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST_STRING)
					{
						base.Controls[14].Visible = false;
					}
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE)
					{
						base.Controls[4].Visible = false;
					}
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.BUTTON)
					{
						base.Controls[5].Visible = false;
					}
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.TEMPERATURE)
					{
						base.Controls[6].Visible = false;
					}
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.TEMPERATURE || this.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						base.Controls[12].Visible = false;
					}
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT || this.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						base.Controls[13].Visible = false;
					}
					if ((this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT || this.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST) && (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT || this.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX))
					{
						base.Controls[8].Visible = false;
					}
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT || this.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID)
					{
						base.Controls[7].Visible = false;
					}
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.SOUND)
					{
						base.Controls[9].Visible = false;
					}
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE && (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.TEMPERATURE || this.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX) && (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT || this.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX))
					{
						base.Controls[2].Visible = false;
					}
					if (this._conditionNetwork != ProgramModule.BlockIf.CONDITION_NETWORK_IF.USBIN)
					{
						base.Controls[10].Visible = false;
						return;
					}
				}
				else
				{
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.BUTTON)
					{
						base.Controls[0].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.SOUND)
					{
						base.Controls[1].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.LIGHT || this._variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						base.Controls[13].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.LIGHT || this._variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID)
					{
						base.Controls[2].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.LIGHT || (this._variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST && this._variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX))
					{
						base.Controls[3].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.ALARM)
					{
						base.Controls[6].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.TIMER)
					{
						base.Controls[7].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.TIME)
					{
						base.Controls[8].Visible = false;
						base.Controls[14].Visible = false;
						base.Controls[15].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.COUNTER)
					{
						base.Controls[9].Visible = false;
						base.Controls[16].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE)
					{
						base.Controls[10].Visible = false;
						base.Controls[17].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.VARIABLE)
					{
						base.Controls[11].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.VARIABLE || this._variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						base.Controls[18].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.VARIABLE || this._variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
					{
						base.Controls[5].Visible = false;
					}
					if ((this._condition != ProgramModule.BlockIf.CONDITION_IF.LIGHT || this._variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX) && (this._condition != ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE || this._variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX) && this._condition != ProgramModule.BlockIf.CONDITION_IF.VARIABLE)
					{
						base.Controls[4].Visible = false;
					}
					if (this._condition != ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX)
					{
						base.Controls[12].Visible = false;
					}
				}
			}

			// Token: 0x06000E72 RID: 3698 RVA: 0x00080C00 File Offset: 0x0007EE00
			public void updateLevel()
			{
				if (base.Controls.Count > 0)
				{
					bool flag = NetworkWindow.Instance.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || this.ConditionNetwork == ProgramModule.BlockIf.CONDITION_NETWORK_IF.OBJECT_BUTTON || this.ConditionNetwork == ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE;
					base.Controls[2].Enabled = flag;
					base.Controls[4].Enabled = flag;
					base.Controls[5].Enabled = flag;
					base.Controls[6].Enabled = flag;
					base.Controls[7].Enabled = flag;
					base.Controls[8].Enabled = flag;
					base.Controls[9].Enabled = flag;
					base.Controls[11].Enabled = flag;
					base.Controls[12].Enabled = flag;
					base.Controls[13].Enabled = flag;
					base.Controls[14].Enabled = flag;
				}
			}

			// Token: 0x06000E73 RID: 3699 RVA: 0x00080D10 File Offset: 0x0007EF10
			public void updateUsbInOutEnable(bool enable)
			{
				if (base.Controls.Count > 0)
				{
					if (this._isConditionNetwork)
					{
						base.Controls[10].Enabled = enable;
						return;
					}
					base.Controls[12].Enabled = enable;
				}
			}

			// Token: 0x06000E74 RID: 3700 RVA: 0x00080D4F File Offset: 0x0007EF4F
			private void comboBoxButton_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[0]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E75 RID: 3701 RVA: 0x00080D73 File Offset: 0x0007EF73
			private void comboBoxSound_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[1]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E76 RID: 3702 RVA: 0x00080D97 File Offset: 0x0007EF97
			private void comboBoxLight2_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[2]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E77 RID: 3703 RVA: 0x00080DBB File Offset: 0x0007EFBB
			private void comboBoxLight3_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[3]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E78 RID: 3704 RVA: 0x00080DE0 File Offset: 0x0007EFE0
			private void comboBoxVariable_SelectedValueChanged(object sender, EventArgs e)
			{
				if (this.VariableIndexes[0] != ((ComboBox)base.Controls[4]).SelectedIndex)
				{
					this.VariableIndexes[0] = ((ComboBox)base.Controls[4]).SelectedIndex;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E79 RID: 3705 RVA: 0x00080E38 File Offset: 0x0007F038
			private void comboBoxVariable2_SelectedValueChanged(object sender, EventArgs e)
			{
				if (this.VariableIndexes[1] != ((ComboBox)base.Controls[5]).SelectedIndex)
				{
					this.VariableIndexes[1] = ((ComboBox)base.Controls[5]).SelectedIndex;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E7A RID: 3706 RVA: 0x00080E90 File Offset: 0x0007F090
			private void comboBoxAlarm_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[6]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E7B RID: 3707 RVA: 0x00080EB4 File Offset: 0x0007F0B4
			private void comboBoxTimer_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[7]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E7C RID: 3708 RVA: 0x00080ED8 File Offset: 0x0007F0D8
			private void comboBoxTime_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[8]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E7D RID: 3709 RVA: 0x00080EFC File Offset: 0x0007F0FC
			private void comboBoxCounter_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[9]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E7E RID: 3710 RVA: 0x00080F21 File Offset: 0x0007F121
			private void comboBoxTemperature_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[10]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E7F RID: 3711 RVA: 0x00080F46 File Offset: 0x0007F146
			private void comboBoxVariableCompare_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[11]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E80 RID: 3712 RVA: 0x00080F6B File Offset: 0x0007F16B
			private void comboBoxUsbIn_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[12]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E81 RID: 3713 RVA: 0x00080F90 File Offset: 0x0007F190
			private void numericUpDownLight_ValueChanged(object sender, EventArgs e)
			{
				if (this.Values[0] != (int)((NumericUpDown)base.Controls[13]).Value)
				{
					this.Values[0] = (int)((NumericUpDown)base.Controls[13]).Value;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E82 RID: 3714 RVA: 0x00080FF4 File Offset: 0x0007F1F4
			private void numericUpDownHour_ValueChanged(object sender, EventArgs e)
			{
				if (this.Values[0] != (int)((NumericUpDown)base.Controls[14]).Value)
				{
					this.Values[0] = (int)((NumericUpDown)base.Controls[14]).Value;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E83 RID: 3715 RVA: 0x00081058 File Offset: 0x0007F258
			private void numericUpDownMinute_ValueChanged(object sender, EventArgs e)
			{
				if (this.Values[1] != (int)((NumericUpDown)base.Controls[15]).Value)
				{
					this.Values[1] = (int)((NumericUpDown)base.Controls[15]).Value;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E84 RID: 3716 RVA: 0x000810BC File Offset: 0x0007F2BC
			private void numericUpDownCounter_ValueChanged(object sender, EventArgs e)
			{
				if (this.Values[0] != (int)((NumericUpDown)base.Controls[16]).Value)
				{
					this.Values[0] = (int)((NumericUpDown)base.Controls[16]).Value;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E85 RID: 3717 RVA: 0x00081120 File Offset: 0x0007F320
			private void numericUpDownTemperature_ValueChanged(object sender, EventArgs e)
			{
				if (this.Values[0] != (int)((NumericUpDown)base.Controls[17]).Value)
				{
					this.Values[0] = (int)((NumericUpDown)base.Controls[17]).Value;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E86 RID: 3718 RVA: 0x00081184 File Offset: 0x0007F384
			private void numericUpDownVariable_ValueChanged(object sender, EventArgs e)
			{
				if (this.Values[0] != (int)((NumericUpDown)base.Controls[18]).Value)
				{
					this.Values[0] = (int)((NumericUpDown)base.Controls[18]).Value;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E87 RID: 3719 RVA: 0x000811E8 File Offset: 0x0007F3E8
			private void comboBoxNetworkObjectButtonIndex_SelectedValueChanged(object sender, EventArgs e)
			{
				this.ObjectName = ((ComboBox)base.Controls[0]).SelectedItem.ToString();
				base.addHistory();
			}

			// Token: 0x06000E88 RID: 3720 RVA: 0x00080D73 File Offset: 0x0007EF73
			private void comboBoxNetworkObjectButton_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[1]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E89 RID: 3721 RVA: 0x00081214 File Offset: 0x0007F414
			private void comboBoxNetworkVariable_SelectedValueChanged(object sender, EventArgs e)
			{
				if (this.VariableIndexes[0] != ((ComboBox)base.Controls[2]).SelectedIndex)
				{
					this.VariableIndexes[0] = ((ComboBox)base.Controls[2]).SelectedIndex;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E8A RID: 3722 RVA: 0x0008126C File Offset: 0x0007F46C
			private void comboBoxNetworkVariable2_SelectedValueChanged(object sender, EventArgs e)
			{
				if (this.VariableIndexes[1] != ((ComboBox)base.Controls[3]).SelectedIndex)
				{
					this.VariableIndexes[1] = ((ComboBox)base.Controls[3]).SelectedIndex;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E8B RID: 3723 RVA: 0x000812C4 File Offset: 0x0007F4C4
			private void comboBoxNetworkData_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[4]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E8C RID: 3724 RVA: 0x000812E8 File Offset: 0x0007F4E8
			private void comboBoxNetworkButton_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[5]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E8D RID: 3725 RVA: 0x00080E90 File Offset: 0x0007F090
			private void comboBoxNetworkTemperature_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[6]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E8E RID: 3726 RVA: 0x00080EB4 File Offset: 0x0007F0B4
			private void comboBoxNetworkLight2_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[7]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E8F RID: 3727 RVA: 0x00080ED8 File Offset: 0x0007F0D8
			private void comboBoxNetworkLight3_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[8]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E90 RID: 3728 RVA: 0x00080EFC File Offset: 0x0007F0FC
			private void comboBoxNetworkSound_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[9]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E91 RID: 3729 RVA: 0x00080F21 File Offset: 0x0007F121
			private void comboBoxNetworkUsbIn_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[10]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x06000E92 RID: 3730 RVA: 0x0008130C File Offset: 0x0007F50C
			private void numericUpDownNetworkData_ValueChanged(object sender, EventArgs e)
			{
				if (this.Values[0] != (int)((NumericUpDown)base.Controls[11]).Value)
				{
					this.Values[0] = (int)((NumericUpDown)base.Controls[11]).Value;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E93 RID: 3731 RVA: 0x00081370 File Offset: 0x0007F570
			private void numericUpDownNetworkTemperature_ValueChanged(object sender, EventArgs e)
			{
				if (this.Values[0] != (int)((NumericUpDown)base.Controls[12]).Value)
				{
					this.Values[0] = (int)((NumericUpDown)base.Controls[12]).Value;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E94 RID: 3732 RVA: 0x000813D4 File Offset: 0x0007F5D4
			private void numericUpDownNetworkLight_ValueChanged(object sender, EventArgs e)
			{
				if (this.Values[0] != (int)((NumericUpDown)base.Controls[13]).Value)
				{
					this.Values[0] = (int)((NumericUpDown)base.Controls[13]).Value;
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x06000E95 RID: 3733 RVA: 0x00081438 File Offset: 0x0007F638
			private void textBoxNetworkData_TextChanged(object sender, EventArgs e)
			{
				this.ConstString = ((TextBox)base.Controls[14]).Text;
				base.addHistory();
			}

			// Token: 0x04000760 RID: 1888
			public const int USE_MEMORY_MAX = 5;

			// Token: 0x04000761 RID: 1889
			public const int LIGHT_THRESHOLD = 50;

			// Token: 0x04000762 RID: 1890
			public const int TEMPERATURE_MAX = 50;

			// Token: 0x04000763 RID: 1891
			public const int TEMPERATURE_MIN = -10;

			// Token: 0x04000764 RID: 1892
			public const int VARIABLE_COUNT_MAX = 8;

			// Token: 0x04000765 RID: 1893
			public const int VARIABLE_MAX = 127;

			// Token: 0x04000766 RID: 1894
			public const int VARIABLE_MIN = -128;

			// Token: 0x04000767 RID: 1895
			public const int VARIABLE_NETWORK_MAX = 32767;

			// Token: 0x04000768 RID: 1896
			public const int VARIABLE_NETWORK_MIN = -32768;

			// Token: 0x04000769 RID: 1897
			public static readonly string[] LIGHT_ITEMS = new string[] { "よりも明るい", "よりも暗い", "と同じ" };

			// Token: 0x0400076A RID: 1898
			public static readonly string[] CONDITION_ITEMS = new string[]
			{
				"ボタン", "明るさ", "音", "アラーム", "タイマー", "時刻", "温度", "ランダム", "秒カウンタ", "変数",
				"外部入力"
			};

			// Token: 0x0400076B RID: 1899
			public static readonly string[] CONDITION_NETWORK_ITEMS = new string[] { "配置ボタン", "データ", "コロックル ボタン", "コロックル 光センサ", "コロックル 温度センサ", "コロックル 音センサ", "コロックル 外部入力" };

			// Token: 0x0400076C RID: 1900
			public static readonly string[] VARIABLE_ITEMS = new string[] { "変数a", "変数b", "変数c", "変数d", "変数e", "変数f", "変数g", "変数h" };

			// Token: 0x0400076D RID: 1901
			public static readonly string[] VARIABLE_NAME_ITEMS = new string[] { "a", "b", "c", "d", "e", "f", "g", "h" };

			// Token: 0x0400076E RID: 1902
			public static readonly string[] COMPARE_ITEMS = new string[] { "よりも小さい", "と同じ", "よりも大きい" };

			// Token: 0x0400076F RID: 1903
			public static readonly string[] COMPARE_ITEMS_TEMPERATURE = new string[] { "よりも低い", "と同じ", "よりも高い" };

			// Token: 0x04000770 RID: 1904
			public static readonly string[] SELECT_BUTTON_ITEMS = new string[] { "ON", "OFF" };

			// Token: 0x04000771 RID: 1905
			public static readonly string[] SELECT_SOUND_ITEMS = new string[] { "する", "しない" };

			// Token: 0x04000772 RID: 1906
			public static readonly string[] SELECT_LIGHT2_ITEMS = new string[] { "明るい", "暗い" };

			// Token: 0x04000773 RID: 1907
			public static readonly string[] SELECT_ALARM_ITEMS = new string[] { "あり", "なし" };

			// Token: 0x04000774 RID: 1908
			public static readonly string[] SELECT_TIMER_ITEMS = new string[] { "あり", "なし" };

			// Token: 0x04000775 RID: 1909
			public static readonly string[] SELECT_TIME_ITEMS = new string[] { "よりも遅い", "と同じ", "よりも早い" };

			// Token: 0x04000776 RID: 1910
			public static readonly string[] SELECT_COUNTER_ITEMS = new string[] { "よりも小さい", "と同じ", "よりも多い" };

			// Token: 0x04000777 RID: 1911
			public static readonly string[] SELECT_USBIN_ITEMS = new string[] { "あり", "なし" };

			// Token: 0x04000778 RID: 1912
			private ProgramModule.Block _else;

			// Token: 0x04000779 RID: 1913
			private ProgramModule.BlockIf.CONDITION_IF _condition;

			// Token: 0x0400077A RID: 1914
			private ProgramModule.BlockIf.CONDITION_NETWORK_IF _conditionNetwork;

			// Token: 0x0400077B RID: 1915
			private bool _isConditionNetwork;

			// Token: 0x0400077C RID: 1916
			private ProgramModule.BlockIf.SELECT _select;

			// Token: 0x0400077D RID: 1917
			private int[] _values = new int[2];

			// Token: 0x0400077E RID: 1918
			private int[] _variableIndexes = new int[2];

			// Token: 0x0400077F RID: 1919
			private ProgramModule.BlockIf.VARIABLE_TYPE_SECOND _variable;

			// Token: 0x04000780 RID: 1920
			private int _connectIndexElse = -1;

			// Token: 0x04000781 RID: 1921
			private string _objectName = "";

			// Token: 0x04000782 RID: 1922
			private string _constString = "";

			// Token: 0x020000F6 RID: 246
			public enum CONDITION_IF
			{
				// Token: 0x040009FA RID: 2554
				BUTTON,
				// Token: 0x040009FB RID: 2555
				LIGHT,
				// Token: 0x040009FC RID: 2556
				SOUND,
				// Token: 0x040009FD RID: 2557
				ALARM,
				// Token: 0x040009FE RID: 2558
				TIMER,
				// Token: 0x040009FF RID: 2559
				TIME,
				// Token: 0x04000A00 RID: 2560
				TEMPERATURE,
				// Token: 0x04000A01 RID: 2561
				RANDOM,
				// Token: 0x04000A02 RID: 2562
				COUNTER,
				// Token: 0x04000A03 RID: 2563
				VARIABLE,
				// Token: 0x04000A04 RID: 2564
				NO_USBIN_MAX,
				// Token: 0x04000A05 RID: 2565
				USBIN = 10,
				// Token: 0x04000A06 RID: 2566
				MAX
			}

			// Token: 0x020000F7 RID: 247
			public enum CONDITION_NETWORK_IF
			{
				// Token: 0x04000A08 RID: 2568
				OBJECT_BUTTON,
				// Token: 0x04000A09 RID: 2569
				VARIABLE,
				// Token: 0x04000A0A RID: 2570
				BUTTON,
				// Token: 0x04000A0B RID: 2571
				LIGHT,
				// Token: 0x04000A0C RID: 2572
				TEMPERATURE,
				// Token: 0x04000A0D RID: 2573
				SOUND,
				// Token: 0x04000A0E RID: 2574
				USBIN,
				// Token: 0x04000A0F RID: 2575
				MAX
			}

			// Token: 0x020000F8 RID: 248
			public enum SELECT
			{
				// Token: 0x04000A11 RID: 2577
				BUTTON_ON,
				// Token: 0x04000A12 RID: 2578
				BUTTON_OFF,
				// Token: 0x04000A13 RID: 2579
				BUTTON_MAX,
				// Token: 0x04000A14 RID: 2580
				LIGHT_BRIGHT = 0,
				// Token: 0x04000A15 RID: 2581
				LIGHT_DARK,
				// Token: 0x04000A16 RID: 2582
				LIGHT2_MAX,
				// Token: 0x04000A17 RID: 2583
				LIGHT_SAME = 2,
				// Token: 0x04000A18 RID: 2584
				LIGHT_MAX,
				// Token: 0x04000A19 RID: 2585
				SOUND_ON = 0,
				// Token: 0x04000A1A RID: 2586
				SOUND_OFF,
				// Token: 0x04000A1B RID: 2587
				SOUND_MAX,
				// Token: 0x04000A1C RID: 2588
				ALARM_ON = 0,
				// Token: 0x04000A1D RID: 2589
				ALARM_OFF,
				// Token: 0x04000A1E RID: 2590
				ALARM_MAX,
				// Token: 0x04000A1F RID: 2591
				TIMER_ON = 0,
				// Token: 0x04000A20 RID: 2592
				TIMER_OFF,
				// Token: 0x04000A21 RID: 2593
				TIMER_MAX,
				// Token: 0x04000A22 RID: 2594
				COMPARE_LESS = 0,
				// Token: 0x04000A23 RID: 2595
				COMPARE_EQUAL,
				// Token: 0x04000A24 RID: 2596
				COMPARE_GREATER,
				// Token: 0x04000A25 RID: 2597
				COMPARE_MAX,
				// Token: 0x04000A26 RID: 2598
				USBIN_ON = 0,
				// Token: 0x04000A27 RID: 2599
				USBIN_OFF,
				// Token: 0x04000A28 RID: 2600
				USBIN_MAX
			}

			// Token: 0x020000F9 RID: 249
			public enum VALUE
			{
				// Token: 0x04000A2A RID: 2602
				LIGHT_THRESHOLD,
				// Token: 0x04000A2B RID: 2603
				TIME_HOUR = 0,
				// Token: 0x04000A2C RID: 2604
				TIME_MINUTE,
				// Token: 0x04000A2D RID: 2605
				TEMPERATURE = 0,
				// Token: 0x04000A2E RID: 2606
				COUNTER = 0,
				// Token: 0x04000A2F RID: 2607
				VARIABLE = 0
			}

			// Token: 0x020000FA RID: 250
			public enum VARIABLE_INDEX
			{
				// Token: 0x04000A31 RID: 2609
				FIRST,
				// Token: 0x04000A32 RID: 2610
				SECOND
			}

			// Token: 0x020000FB RID: 251
			public enum VARIABLE_TYPE_SECOND
			{
				// Token: 0x04000A34 RID: 2612
				CONST,
				// Token: 0x04000A35 RID: 2613
				INDEX,
				// Token: 0x04000A36 RID: 2614
				CONST_STRING,
				// Token: 0x04000A37 RID: 2615
				INVALID = -1
			}

			// Token: 0x020000FC RID: 252
			private enum CONTROL
			{
				// Token: 0x04000A39 RID: 2617
				COMBOBOX_BUTTON,
				// Token: 0x04000A3A RID: 2618
				COMBOBOX_SOUND,
				// Token: 0x04000A3B RID: 2619
				COMBOBOX_LIGHT2,
				// Token: 0x04000A3C RID: 2620
				COMBOBOX_LIGHT3,
				// Token: 0x04000A3D RID: 2621
				COMBOBOX_VARIABLE,
				// Token: 0x04000A3E RID: 2622
				COMBOBOX_VARIABLE2,
				// Token: 0x04000A3F RID: 2623
				COMBOBOX_ALARM,
				// Token: 0x04000A40 RID: 2624
				COMBOBOX_TIMER,
				// Token: 0x04000A41 RID: 2625
				COMBOBOX_TIME,
				// Token: 0x04000A42 RID: 2626
				COMBOBOX_COUNTER,
				// Token: 0x04000A43 RID: 2627
				COMBOBOX_TEMPERATURE,
				// Token: 0x04000A44 RID: 2628
				COMBOBOX_VARIABLE_COMPARE,
				// Token: 0x04000A45 RID: 2629
				COMBOBOX_USBIN,
				// Token: 0x04000A46 RID: 2630
				NUMERIC_LIGHT,
				// Token: 0x04000A47 RID: 2631
				NUMERIC_HOUR,
				// Token: 0x04000A48 RID: 2632
				NUMERIC_MINUTE,
				// Token: 0x04000A49 RID: 2633
				NUMERIC_COUNTER,
				// Token: 0x04000A4A RID: 2634
				NUMERIC_TEMPERATURE,
				// Token: 0x04000A4B RID: 2635
				NUMERIC_VARIABLE,
				// Token: 0x04000A4C RID: 2636
				MAX
			}

			// Token: 0x020000FD RID: 253
			private enum CONTROL_NETWORK
			{
				// Token: 0x04000A4E RID: 2638
				COMBOBOX_OBJECT_BUTTON_INDEX,
				// Token: 0x04000A4F RID: 2639
				COMBOBOX_OBJECT_BUTTON,
				// Token: 0x04000A50 RID: 2640
				COMBOBOX_VARIABLE,
				// Token: 0x04000A51 RID: 2641
				COMBOBOX_VARIABLE2,
				// Token: 0x04000A52 RID: 2642
				COMBOBOX_DATA,
				// Token: 0x04000A53 RID: 2643
				COMBOBOX_BUTTON,
				// Token: 0x04000A54 RID: 2644
				COMBOBOX_TEMPERATURE,
				// Token: 0x04000A55 RID: 2645
				COMBOBOX_LIGHT2,
				// Token: 0x04000A56 RID: 2646
				COMBOBOX_LIGHT3,
				// Token: 0x04000A57 RID: 2647
				COMBOBOX_SOUND,
				// Token: 0x04000A58 RID: 2648
				COMBOBOX_USBIN,
				// Token: 0x04000A59 RID: 2649
				NUMERIC_DATA,
				// Token: 0x04000A5A RID: 2650
				NUMERIC_TEMPERATURE,
				// Token: 0x04000A5B RID: 2651
				NUMERIC_LIGHT,
				// Token: 0x04000A5C RID: 2652
				TEXTBOX_DATA,
				// Token: 0x04000A5D RID: 2653
				MAX
			}
		}

		// Token: 0x02000078 RID: 120
		public class BlockJump : ProgramModule.Block
		{
			// Token: 0x1700046E RID: 1134
			// (get) Token: 0x06000E97 RID: 3735 RVA: 0x000816FD File Offset: 0x0007F8FD
			// (set) Token: 0x06000E98 RID: 3736 RVA: 0x00081705 File Offset: 0x0007F905
			[XmlIgnore]
			public ProgramModule.BlockLabel Label
			{
				get
				{
					return this._label;
				}
				set
				{
					base.Updated |= this._label != value;
					this._label = value;
				}
			}

			// Token: 0x1700046F RID: 1135
			// (get) Token: 0x06000E99 RID: 3737 RVA: 0x00081727 File Offset: 0x0007F927
			// (set) Token: 0x06000E9A RID: 3738 RVA: 0x0008172F File Offset: 0x0007F92F
			[XmlIgnore]
			public ProgramModule.Block JumpTemp { get; set; }

			// Token: 0x17000470 RID: 1136
			// (get) Token: 0x06000E9B RID: 3739 RVA: 0x00081738 File Offset: 0x0007F938
			// (set) Token: 0x06000E9C RID: 3740 RVA: 0x00081740 File Offset: 0x0007F940
			public int ConnectIndexLabel
			{
				get
				{
					return this._connectIndexLabel;
				}
				set
				{
					base.Updated |= this._connectIndexLabel != value;
					this._connectIndexLabel = value;
				}
			}

			// Token: 0x06000E9E RID: 3742 RVA: 0x00081774 File Offset: 0x0007F974
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_100, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_101, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_100.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_100.Width - Resources.bp_block_102.Width), (float)Resources.bp_block_101.Height));
					graphics.DrawImage(Resources.bp_block_102, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_102.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.White, new Point(base.LocationBlock.X + Resources.bp_block_100.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, isPrint ? Brushes.Black : Brushes.White, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000E9F RID: 3743 RVA: 0x00081948 File Offset: 0x0007FB48
			public override void OnPaintBlockSelect(Graphics graphics)
			{
				if (this.Label != null)
				{
					this.Label.paintRectBlock(graphics, Color.Red, false);
				}
				base.OnPaintBlockSelect(graphics);
			}

			// Token: 0x06000EA0 RID: 3744 RVA: 0x0008196B File Offset: 0x0007FB6B
			public override string getDetailBlock(bool isPrint)
			{
				if (!isPrint)
				{
					return "\u3000\u3000\u3000\u3000へジャンプ";
				}
				if (this.Label == null)
				{
					return "へジャンプ";
				}
				return this.Label.getDetailBlock(false) + "へジャンプ";
			}

			// Token: 0x06000EA1 RID: 3745 RVA: 0x0008199C File Offset: 0x0007FB9C
			public override void convertFlowchart(List<ProgramModule.Block> checkedBlocks)
			{
				if (base.Before != null)
				{
					base.Before.Next = this.Label.Next;
				}
				if (!checkedBlocks.Contains(this.Label.Next))
				{
					this.Label.Next.convertFlowchart(checkedBlocks);
				}
			}

			// Token: 0x06000EA2 RID: 3746 RVA: 0x000819EC File Offset: 0x0007FBEC
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_010.Width;
					base.Controls[0].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
				}
			}

			// Token: 0x06000EA3 RID: 3747 RVA: 0x00081A48 File Offset: 0x0007FC48
			public void updateLabels()
			{
				if (NetworkWindow.Instance != null)
				{
					if (NetworkWindow.Instance.FlowchartTabIndex == NetworkFlowchartTab.TAB.STAGE)
					{
						this._labels = NetworkWindow.Instance.Programs.ObjectStage.ProgramModule.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>();
					}
					else
					{
						NetworkProgramModules.ObjectInfo objectInfo = NetworkWindow.Instance.Programs.getSelectedObject();
						if (objectInfo == null)
						{
							objectInfo = NetworkWindow.Instance.Programs.ObjectInput;
						}
						this._labels = objectInfo.ProgramModule.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>();
					}
				}
				else
				{
					ProgramModule programModule;
					if (FlowchartWindow.Instance.RoutineIndex == ProgramModules.ROUTINE.INVALID)
					{
						programModule = FlowchartWindow.Instance.Programs.Programs[0];
					}
					else
					{
						programModule = FlowchartWindow.Instance.Programs.Programs[(int)FlowchartWindow.Instance.RoutineIndex];
					}
					this._labels = programModule.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>();
				}
				if (base.Controls.Count > 0)
				{
					ComboBox comboBox = (ComboBox)base.Controls[0];
					comboBox.Items.Clear();
					foreach (ProgramModule.BlockLabel blockLabel in this._labels)
					{
						comboBox.Items.Add(blockLabel.getDetailBlock(false));
					}
				}
				this.updateBlock();
			}

			// Token: 0x06000EA4 RID: 3748 RVA: 0x00081C20 File Offset: 0x0007FE20
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				ComboBox comboBox = new ComboBox();
				comboBox.Width = 80;
				base.Controls.Add(comboBox);
				this.updateLabels();
				this.updateBlock();
				((ComboBox)base.Controls[0]).SelectedValueChanged += this.comboBoxLabel_SelectedValueChanged;
			}

			// Token: 0x06000EA5 RID: 3749 RVA: 0x00081C80 File Offset: 0x0007FE80
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					if (this.Label != null && this._labels.Contains(this.Label))
					{
						((ComboBox)base.Controls[0]).SelectedIndex = this._labels.IndexOf(this.Label);
						return;
					}
					this.Label = null;
				}
			}

			// Token: 0x06000EA6 RID: 3750 RVA: 0x00081CEC File Offset: 0x0007FEEC
			private void comboBoxLabel_SelectedValueChanged(object sender, EventArgs e)
			{
				if (this.Label != this._labels[((ComboBox)base.Controls[0]).SelectedIndex])
				{
					this.Label = this._labels[((ComboBox)base.Controls[0]).SelectedIndex];
					base.Updated = true;
					base.addHistory();
				}
			}

			// Token: 0x04000783 RID: 1923
			private ProgramModule.BlockLabel _label;

			// Token: 0x04000785 RID: 1925
			private int _connectIndexLabel = -1;

			// Token: 0x04000786 RID: 1926
			private List<ProgramModule.BlockLabel> _labels;

			// Token: 0x020000FE RID: 254
			private enum CONTROL
			{
				// Token: 0x04000A5F RID: 2655
				COMBOBOX_LABEL,
				// Token: 0x04000A60 RID: 2656
				MAX
			}
		}

		// Token: 0x02000079 RID: 121
		public class BlockLabel : ProgramModule.Block
		{
			// Token: 0x17000471 RID: 1137
			// (get) Token: 0x06000EA7 RID: 3751 RVA: 0x00081D56 File Offset: 0x0007FF56
			// (set) Token: 0x06000EA8 RID: 3752 RVA: 0x00081D5E File Offset: 0x0007FF5E
			public int Label
			{
				get
				{
					return this._label;
				}
				set
				{
					this._label = value;
				}
			}

			// Token: 0x17000472 RID: 1138
			// (get) Token: 0x06000EA9 RID: 3753 RVA: 0x00081D67 File Offset: 0x0007FF67
			// (set) Token: 0x06000EAA RID: 3754 RVA: 0x00081D6E File Offset: 0x0007FF6E
			public static int LabelIndexCount { get; set; } = 1;

			// Token: 0x06000EAB RID: 3755 RVA: 0x00081D76 File Offset: 0x0007FF76
			public BlockLabel()
			{
				this._label = ProgramModule.BlockLabel.LabelIndexCount;
				ProgramModule.BlockLabel.LabelIndexCount++;
			}

			// Token: 0x06000EAC RID: 3756 RVA: 0x00081D98 File Offset: 0x0007FF98
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_100, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_101, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_100.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_100.Width - Resources.bp_block_102.Width), (float)Resources.bp_block_101.Height));
					graphics.DrawImage(Resources.bp_block_102, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_102.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.White, new Point(base.LocationBlock.X + Resources.bp_block_100.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, isPrint ? Brushes.Black : Brushes.White, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000EAD RID: 3757 RVA: 0x00081F6C File Offset: 0x0008016C
			public override string getDetailBlock(bool isPrint)
			{
				return "ラベル" + this.Label.ToString();
			}

			// Token: 0x06000EAE RID: 3758 RVA: 0x00081F91 File Offset: 0x00080191
			public override void convertFlowchart(List<ProgramModule.Block> checkedBlocks)
			{
				base.Before.Next = base.Next;
				if (!checkedBlocks.Contains(base.Next))
				{
					base.Next.convertFlowchart(checkedBlocks);
				}
			}

			// Token: 0x06000EAF RID: 3759 RVA: 0x00081FBE File Offset: 0x000801BE
			public void updateLabelIndex()
			{
				this._label = ProgramModule.BlockLabel.LabelIndexCount;
				ProgramModule.BlockLabel.LabelIndexCount++;
			}

			// Token: 0x04000787 RID: 1927
			private int _label;
		}

		// Token: 0x0200007A RID: 122
		public class BlockLED : ProgramModule.Block
		{
			// Token: 0x17000473 RID: 1139
			// (get) Token: 0x06000EB1 RID: 3761 RVA: 0x00081FDF File Offset: 0x000801DF
			// (set) Token: 0x06000EB2 RID: 3762 RVA: 0x00081FE7 File Offset: 0x000801E7
			public ProgramModule.BlockLED.LED_MODE Mode
			{
				get
				{
					return this._mode;
				}
				set
				{
					base.Updated |= this._mode != value;
					this._mode = value;
				}
			}

			// Token: 0x17000474 RID: 1140
			// (get) Token: 0x06000EB3 RID: 3763 RVA: 0x00082009 File Offset: 0x00080209
			// (set) Token: 0x06000EB4 RID: 3764 RVA: 0x00082011 File Offset: 0x00080211
			public ProgramModule.BlockLED.FADE Fade
			{
				get
				{
					return this._fade;
				}
				set
				{
					base.Updated |= this._fade != value;
					this._fade = value;
				}
			}

			// Token: 0x17000475 RID: 1141
			// (get) Token: 0x06000EB5 RID: 3765 RVA: 0x00082033 File Offset: 0x00080233
			// (set) Token: 0x06000EB6 RID: 3766 RVA: 0x0008203B File Offset: 0x0008023B
			public int Red
			{
				get
				{
					return this._red;
				}
				set
				{
					base.Updated |= this._red != value;
					this._red = value;
				}
			}

			// Token: 0x17000476 RID: 1142
			// (get) Token: 0x06000EB7 RID: 3767 RVA: 0x0008205D File Offset: 0x0008025D
			// (set) Token: 0x06000EB8 RID: 3768 RVA: 0x00082065 File Offset: 0x00080265
			public int Green
			{
				get
				{
					return this._green;
				}
				set
				{
					base.Updated |= this._green != value;
					this._green = value;
				}
			}

			// Token: 0x17000477 RID: 1143
			// (get) Token: 0x06000EB9 RID: 3769 RVA: 0x00082087 File Offset: 0x00080287
			// (set) Token: 0x06000EBA RID: 3770 RVA: 0x0008208F File Offset: 0x0008028F
			public int Blue
			{
				get
				{
					return this._blue;
				}
				set
				{
					base.Updated |= this._blue != value;
					this._blue = value;
				}
			}

			// Token: 0x17000478 RID: 1144
			// (get) Token: 0x06000EBB RID: 3771 RVA: 0x000820B1 File Offset: 0x000802B1
			// (set) Token: 0x06000EBC RID: 3772 RVA: 0x000820B9 File Offset: 0x000802B9
			public float Time
			{
				get
				{
					return this._time;
				}
				set
				{
					base.Updated |= this._time != value;
					this._time = value;
				}
			}

			// Token: 0x06000EBD RID: 3773 RVA: 0x000820DC File Offset: 0x000802DC
			public BlockLED()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				this._red = (this._green = (this._blue = 10));
			}

			// Token: 0x06000EBE RID: 3774 RVA: 0x00082174 File Offset: 0x00080374
			public override byte[] serializeBinary()
			{
				byte[] array = new byte[0];
				Color color = Color.FromArgb(this._red, this._green, this._blue);
				switch (this._mode)
				{
				case ProgramModule.BlockLED.LED_MODE.ON:
					if (this.isDefinedColor(color))
					{
						array = new byte[2];
					}
					else
					{
						array = new byte[5];
					}
					if (color == Color.FromArgb(0, 0, 10))
					{
						array[0] = 10;
					}
					else if (color == Color.FromArgb(10, 0, 0))
					{
						array[0] = 14;
					}
					else if (color == Color.FromArgb(10, 10, 0))
					{
						array[0] = 18;
					}
					else if (color == Color.FromArgb(0, 10, 10))
					{
						array[0] = 22;
					}
					else if (color == Color.FromArgb(10, 10, 10))
					{
						array[0] = 26;
					}
					else if (color == Color.FromArgb(10, 0, 10))
					{
						array[0] = 30;
					}
					else if (color == Color.FromArgb(0, 10, 0))
					{
						array[0] = 34;
					}
					else
					{
						array[0] = 6;
						array[2] = (byte)this._red;
						array[3] = (byte)this._green;
						array[4] = (byte)this._blue;
					}
					break;
				case ProgramModule.BlockLED.LED_MODE.OFF:
					array = new byte[2];
					array[0] = 35;
					break;
				case ProgramModule.BlockLED.LED_MODE.ON_TIME:
					if (this.isDefinedColor(color))
					{
						array = new byte[3];
					}
					else
					{
						array = new byte[6];
					}
					array[2] = (byte)(this._time * 10f);
					switch (this._fade)
					{
					case ProgramModule.BlockLED.FADE.NONE:
						if (color == Color.FromArgb(0, 0, 10))
						{
							array[0] = 7;
						}
						else if (color == Color.FromArgb(10, 0, 0))
						{
							array[0] = 11;
						}
						else if (color == Color.FromArgb(10, 10, 0))
						{
							array[0] = 15;
						}
						else if (color == Color.FromArgb(0, 10, 10))
						{
							array[0] = 19;
						}
						else if (color == Color.FromArgb(10, 10, 10))
						{
							array[0] = 23;
						}
						else if (color == Color.FromArgb(10, 0, 10))
						{
							array[0] = 27;
						}
						else if (color == Color.FromArgb(0, 10, 0))
						{
							array[0] = 31;
						}
						else
						{
							array[0] = 3;
							array[3] = (byte)this._red;
							array[4] = (byte)this._green;
							array[5] = (byte)this._blue;
						}
						break;
					case ProgramModule.BlockLED.FADE.IN:
						if (color == Color.FromArgb(0, 0, 10))
						{
							array[0] = 8;
						}
						else if (color == Color.FromArgb(10, 0, 0))
						{
							array[0] = 12;
						}
						else if (color == Color.FromArgb(10, 10, 0))
						{
							array[0] = 16;
						}
						else if (color == Color.FromArgb(0, 10, 10))
						{
							array[0] = 20;
						}
						else if (color == Color.FromArgb(10, 10, 10))
						{
							array[0] = 24;
						}
						else if (color == Color.FromArgb(10, 0, 10))
						{
							array[0] = 28;
						}
						else if (color == Color.FromArgb(0, 10, 0))
						{
							array[0] = 32;
						}
						else
						{
							array[0] = 4;
							array[3] = (byte)this._red;
							array[4] = (byte)this._green;
							array[5] = (byte)this._blue;
						}
						break;
					case ProgramModule.BlockLED.FADE.OUT:
						if (color == Color.FromArgb(0, 0, 10))
						{
							array[0] = 9;
						}
						else if (color == Color.FromArgb(10, 0, 0))
						{
							array[0] = 13;
						}
						else if (color == Color.FromArgb(10, 10, 0))
						{
							array[0] = 17;
						}
						else if (color == Color.FromArgb(0, 10, 10))
						{
							array[0] = 21;
						}
						else if (color == Color.FromArgb(10, 10, 10))
						{
							array[0] = 25;
						}
						else if (color == Color.FromArgb(10, 0, 10))
						{
							array[0] = 29;
						}
						else if (color == Color.FromArgb(0, 10, 0))
						{
							array[0] = 33;
						}
						else
						{
							array[0] = 5;
							array[3] = (byte)this._red;
							array[4] = (byte)this._green;
							array[5] = (byte)this._blue;
						}
						break;
					}
					break;
				}
				return array;
			}

			// Token: 0x06000EBF RID: 3775 RVA: 0x000825C0 File Offset: 0x000807C0
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				ProgramModule.Block.COMMAND_NUMBER command_NUMBER = (ProgramModule.Block.COMMAND_NUMBER)bytes[0];
				if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_BEGIN || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_BLUE_TIME_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_RED_TIME_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_YELLOW_TIME_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_CYAN_TIME_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_WHITE_TIME_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_MAGENTA_TIME_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_GREEN_TIME_ON)
				{
					this._mode = ProgramModule.BlockLED.LED_MODE.ON_TIME;
					this._fade = ProgramModule.BlockLED.FADE.NONE;
					this._time = (float)bytes[2] / 10f;
				}
				else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_RGB_FADE_IN || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_BLUE_FADE_IN || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_RED_FADE_IN || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_YELLOW_FADE_IN || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_CYAN_FADE_IN || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_WHITE_FADE_IN || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_MAGENTA_FADE_IN || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_GREEN_FADE_IN)
				{
					this._mode = ProgramModule.BlockLED.LED_MODE.ON_TIME;
					this._fade = ProgramModule.BlockLED.FADE.IN;
					this._time = (float)bytes[2] / 10f;
				}
				else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_RGB_FADE_OUT || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_BLUE_FADE_OUT || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_RED_FADE_OUT || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_YELLOW_FADE_OUT || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_CYAN_FADE_OUT || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_WHITE_FADE_OUT || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_MAGENTA_FADE_OUT || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_GREEN_FADE_OUT)
				{
					this._mode = ProgramModule.BlockLED.LED_MODE.ON_TIME;
					this._fade = ProgramModule.BlockLED.FADE.OUT;
					this._time = (float)bytes[2] / 10f;
				}
				else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_RGB_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_BLUE_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_RED_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_YELLOW_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_CYAN_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_WHITE_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_MAGENTA_ON || command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_GREEN_ON)
				{
					this._mode = ProgramModule.BlockLED.LED_MODE.ON;
				}
				else
				{
					this._mode = ProgramModule.BlockLED.LED_MODE.OFF;
				}
				if (ProgramModule.Block.COMMAND_NUMBER.LED_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.LED_RGB_FADE_OUT)
				{
					this._red = (int)bytes[3];
					this._green = (int)bytes[4];
					this._blue = (int)bytes[5];
				}
				else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LED_RGB_ON)
				{
					this._red = (int)bytes[2];
					this._green = (int)bytes[3];
					this._blue = (int)bytes[4];
				}
				else if (ProgramModule.Block.COMMAND_NUMBER.LED_BLUE_TIME_ON <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.LED_BLUE_ON)
				{
					this._red = 0;
					this._green = 0;
					this._blue = 10;
				}
				else if (ProgramModule.Block.COMMAND_NUMBER.LED_RED_TIME_ON <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.LED_RED_ON)
				{
					this._red = 10;
					this._green = 0;
					this._blue = 0;
				}
				else if (ProgramModule.Block.COMMAND_NUMBER.LED_YELLOW_TIME_ON <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.LED_YELLOW_ON)
				{
					this._red = 10;
					this._green = 10;
					this._blue = 0;
				}
				else if (ProgramModule.Block.COMMAND_NUMBER.LED_CYAN_TIME_ON <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.LED_CYAN_ON)
				{
					this._red = 0;
					this._green = 10;
					this._blue = 10;
				}
				else if (ProgramModule.Block.COMMAND_NUMBER.LED_WHITE_TIME_ON <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.LED_WHITE_ON)
				{
					this._red = 10;
					this._green = 10;
					this._blue = 10;
				}
				else if (ProgramModule.Block.COMMAND_NUMBER.LED_MAGENTA_TIME_ON <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.LED_MAGENTA_ON)
				{
					this._red = 10;
					this._green = 0;
					this._blue = 10;
				}
				else if (ProgramModule.Block.COMMAND_NUMBER.LED_GREEN_TIME_ON <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.LED_GREEN_ON)
				{
					this._red = 0;
					this._green = 10;
					this._blue = 0;
				}
				return true;
			}

			// Token: 0x06000EC0 RID: 3776 RVA: 0x00082824 File Offset: 0x00080A24
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					if (this._mode == ProgramModule.BlockLED.LED_MODE.OFF || (this._red == 0 && this._green == 0 && this._blue == 0))
					{
						graphics.DrawImage(Resources.fc_block_020, base.Location);
					}
					else
					{
						Brush brush = new SolidBrush(Color.FromArgb((int)((double)this._red * 25.5), (int)((double)this._green * 25.5), (int)((double)this._blue * 25.5)));
						graphics.FillRectangle(brush, new Rectangle(base.Location, ProgramModule.Block.BLOCK_SIZE));
						graphics.DrawImage(Resources.fc_block_010, base.Location);
					}
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000EC1 RID: 3777 RVA: 0x000828F8 File Offset: 0x00080AF8
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_010, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_011, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_010.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_010.Width - Resources.bp_block_012.Width), (float)Resources.bp_block_011.Height));
					graphics.DrawImage(Resources.bp_block_012, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_012.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						if (this.Mode != ProgramModule.BlockLED.LED_MODE.OFF)
						{
							int num = Resources.bp_block_011.Height - ProgramModule.Block.BLOCK_DETAIL_OFFSET * 4;
							graphics.FillRectangle(new SolidBrush(Color.FromArgb((int)((double)this._red * 25.5), (int)((double)this._green * 25.5), (int)((double)this._blue * 25.5))), base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET, num, num);
						}
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000EC2 RID: 3778 RVA: 0x00082B58 File Offset: 0x00080D58
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				string text = "";
				base.addIndent(ref text, indent);
				if (this._mode == ProgramModule.BlockLED.LED_MODE.ON_TIME)
				{
					if (this._fade == ProgramModule.BlockLED.FADE.NONE)
					{
						text = string.Concat(new string[]
						{
							text,
							"LED_ON_TIME(",
							this._time.ToString(),
							",",
							this._red.ToString(),
							",",
							this._green.ToString(),
							",",
							this._blue.ToString(),
							")"
						});
					}
					else if (this._fade == ProgramModule.BlockLED.FADE.IN)
					{
						text = string.Concat(new string[]
						{
							text,
							"LED_CHANGE(",
							this._time.ToString(),
							",",
							this._red.ToString(),
							",",
							this._green.ToString(),
							",",
							this._blue.ToString(),
							")"
						});
					}
					else
					{
						text = string.Concat(new string[]
						{
							text,
							"LED_FADE_OUT(",
							this._time.ToString(),
							",",
							this._red.ToString(),
							",",
							this._green.ToString(),
							",",
							this._blue.ToString(),
							")"
						});
					}
				}
				else if (this._mode == ProgramModule.BlockLED.LED_MODE.ON)
				{
					text = string.Concat(new string[]
					{
						text,
						"LED_ON(",
						this._red.ToString(),
						",",
						this._green.ToString(),
						",",
						this._blue.ToString(),
						")"
					});
				}
				else if (this._mode == ProgramModule.BlockLED.LED_MODE.OFF)
				{
					text += "LED_OFF()";
				}
				codeList.Add(text);
				base.getProgram(blockList, codeList, indent);
			}

			// Token: 0x06000EC3 RID: 3779 RVA: 0x00082D7C File Offset: 0x00080F7C
			public override string getDetail()
			{
				if (this._mode == ProgramModule.BlockLED.LED_MODE.ON_TIME)
				{
					if (this._fade == ProgramModule.BlockLED.FADE.NONE)
					{
						return "点灯(" + this._time.ToString() + "秒)";
					}
					if (this._fade == ProgramModule.BlockLED.FADE.IN)
					{
						return "だんだん変わる\r\n(" + this._time.ToString() + "秒)";
					}
					return "だんだん消える\r\n(" + this._time.ToString() + "秒)";
				}
				else
				{
					if (this._mode == ProgramModule.BlockLED.LED_MODE.ON)
					{
						return "連続点灯";
					}
					return "消灯";
				}
			}

			// Token: 0x06000EC4 RID: 3780 RVA: 0x00082E08 File Offset: 0x00081008
			public override string getDetailBlock(bool isPrint)
			{
				string text = "";
				switch (this.Mode)
				{
				case ProgramModule.BlockLED.LED_MODE.ON:
					text = (isPrint ? "\u3000 連続点灯" : "\u3000\u3000\u3000\u3000連続点灯");
					break;
				case ProgramModule.BlockLED.LED_MODE.OFF:
					text = "消灯";
					break;
				case ProgramModule.BlockLED.LED_MODE.ON_TIME:
					switch (this._fade)
					{
					case ProgramModule.BlockLED.FADE.NONE:
						text = (isPrint ? string.Format("\u3000 点灯{0}秒", this.Time) : "\u3000\u3000\u3000\u3000点灯\u3000\u3000\u3000秒");
						break;
					case ProgramModule.BlockLED.FADE.IN:
						text = (isPrint ? string.Format("\u3000 だんだん変わる{0}秒", this.Time) : "\u3000\u3000\u3000\u3000だんだん変わる\u3000\u3000\u3000秒");
						break;
					case ProgramModule.BlockLED.FADE.OUT:
						text = (isPrint ? string.Format("\u3000 だんだん消える{0}秒", this.Time) : "\u3000\u3000\u3000\u3000だんだん消える\u3000\u3000\u3000秒");
						break;
					}
					break;
				}
				return text;
			}

			// Token: 0x06000EC5 RID: 3781 RVA: 0x00082ED8 File Offset: 0x000810D8
			public override int getUsedMemory()
			{
				Color color = Color.FromArgb(this._red, this._green, this._blue);
				if (this._mode == ProgramModule.BlockLED.LED_MODE.ON_TIME)
				{
					if (this.isDefinedColor(color))
					{
						return 3;
					}
					return 6;
				}
				else
				{
					if (this._mode != ProgramModule.BlockLED.LED_MODE.ON)
					{
						return 2;
					}
					if (this.isDefinedColor(color))
					{
						return 2;
					}
					return 5;
				}
			}

			// Token: 0x06000EC6 RID: 3782 RVA: 0x00082F2C File Offset: 0x0008112C
			private bool isDefinedColor(Color color)
			{
				return color == Color.FromArgb(10, 0, 0) || color == Color.FromArgb(0, 10, 0) || color == Color.FromArgb(0, 0, 10) || color == Color.FromArgb(10, 10, 0) || color == Color.FromArgb(10, 0, 10) || color == Color.FromArgb(0, 10, 10) || color == Color.FromArgb(10, 10, 10);
			}

			// Token: 0x06000EC7 RID: 3783 RVA: 0x00082FC4 File Offset: 0x000811C4
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_010.Width;
					switch (this.Mode)
					{
					case ProgramModule.BlockLED.LED_MODE.ON:
					{
						int num = TextRenderer.MeasureText("\u3000", ProgramModule.Block._fontBlock).Width;
						base.Controls[0].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
						return;
					}
					case ProgramModule.BlockLED.LED_MODE.OFF:
						break;
					case ProgramModule.BlockLED.LED_MODE.ON_TIME:
					{
						int num = TextRenderer.MeasureText("\u3000", ProgramModule.Block._fontBlock).Width;
						base.Controls[0].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
						ProgramModule.BlockLED.FADE fade = this._fade;
						if (fade != ProgramModule.BlockLED.FADE.NONE)
						{
							if (fade - ProgramModule.BlockLED.FADE.IN <= 1)
							{
								num += base.Controls[0].Width + TextRenderer.MeasureText("だんだん変わる", ProgramModule.Block._fontBlock).Width;
							}
						}
						else
						{
							num += base.Controls[0].Width + TextRenderer.MeasureText("点灯", ProgramModule.Block._fontBlock).Width;
						}
						base.Controls[1].Location = new Point(x + num, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
						break;
					}
					default:
						return;
					}
				}
			}

			// Token: 0x06000EC8 RID: 3784 RVA: 0x00083138 File Offset: 0x00081338
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				ComboBox comboBox = new ComboBox();
				comboBox.BeginUpdate();
				comboBox.Width = 50;
				foreach (string text in ProgramModule.BlockLED.COLOR_ITEMS)
				{
					comboBox.Items.Add(text);
				}
				comboBox.EndUpdate();
				base.Controls.Add(comboBox);
				NumericUpDown numericUpDown = new NumericUpDown();
				numericUpDown.Width = 50;
				numericUpDown.DecimalPlaces = 1;
				numericUpDown.Increment = 0.1m;
				numericUpDown.Minimum = 0.1m;
				numericUpDown.Maximum = 25.5m;
				base.Controls.Add(numericUpDown);
				this.updateBlock();
				((ComboBox)base.Controls[0]).SelectedValueChanged += this.comboBoxColor_SelectedValueChanged;
				((NumericUpDown)base.Controls[1]).ValueChanged += this.numericUpDownTime_ValueChanged;
			}

			// Token: 0x06000EC9 RID: 3785 RVA: 0x0008323C File Offset: 0x0008143C
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					((ComboBox)base.Controls[0]).SelectedIndex = -1;
					((NumericUpDown)base.Controls[1]).Value = (decimal)this._time;
				}
			}

			// Token: 0x06000ECA RID: 3786 RVA: 0x00083295 File Offset: 0x00081495
			public override void updateControlVisible(List<Rectangle> rects)
			{
				base.updateControlVisible(rects);
				if (this.Mode == ProgramModule.BlockLED.LED_MODE.OFF)
				{
					base.Controls[0].Visible = false;
				}
				if (this.Mode != ProgramModule.BlockLED.LED_MODE.ON_TIME)
				{
					base.Controls[1].Visible = false;
				}
			}

			// Token: 0x06000ECB RID: 3787 RVA: 0x000832D4 File Offset: 0x000814D4
			private void comboBoxColor_SelectedValueChanged(object sender, EventArgs e)
			{
				switch (((ComboBox)base.Controls[0]).SelectedIndex)
				{
				case 0:
					this.Red = 10;
					this.Green = 0;
					this.Blue = 0;
					break;
				case 1:
					this.Red = 0;
					this.Green = 10;
					this.Blue = 0;
					break;
				case 2:
					this.Red = 0;
					this.Green = 0;
					this.Blue = 10;
					break;
				case 3:
					this.Red = 10;
					this.Green = 10;
					this.Blue = 0;
					break;
				case 4:
					this.Red = 10;
					this.Green = 0;
					this.Blue = 10;
					break;
				case 5:
					this.Red = 0;
					this.Green = 10;
					this.Blue = 10;
					break;
				case 6:
					this.Red = 10;
					this.Green = 10;
					this.Blue = 10;
					break;
				}
				FlowchartWindow.Instance.updateUsedMemory();
				base.addHistory();
			}

			// Token: 0x06000ECC RID: 3788 RVA: 0x000833DD File Offset: 0x000815DD
			private void numericUpDownTime_ValueChanged(object sender, EventArgs e)
			{
				this.Time = (float)((NumericUpDown)base.Controls[1]).Value;
				base.addHistory();
			}

			// Token: 0x04000789 RID: 1929
			public const int USE_MEMORY_MAX = 6;

			// Token: 0x0400078A RID: 1930
			public static readonly string[] COLOR_ITEMS = new string[] { "赤", "緑", "青", "黄", "紫", "水色", "白" };

			// Token: 0x0400078B RID: 1931
			private ProgramModule.BlockLED.LED_MODE _mode;

			// Token: 0x0400078C RID: 1932
			private ProgramModule.BlockLED.FADE _fade;

			// Token: 0x0400078D RID: 1933
			private int _red;

			// Token: 0x0400078E RID: 1934
			private int _green;

			// Token: 0x0400078F RID: 1935
			private int _blue;

			// Token: 0x04000790 RID: 1936
			private float _time = 0.1f;

			// Token: 0x02000100 RID: 256
			public enum LED_MODE
			{
				// Token: 0x04000A66 RID: 2662
				ON,
				// Token: 0x04000A67 RID: 2663
				OFF,
				// Token: 0x04000A68 RID: 2664
				ON_TIME
			}

			// Token: 0x02000101 RID: 257
			public enum FADE
			{
				// Token: 0x04000A6A RID: 2666
				NONE,
				// Token: 0x04000A6B RID: 2667
				IN,
				// Token: 0x04000A6C RID: 2668
				OUT
			}

			// Token: 0x02000102 RID: 258
			public enum COLOR
			{
				// Token: 0x04000A6E RID: 2670
				RED,
				// Token: 0x04000A6F RID: 2671
				GREEN,
				// Token: 0x04000A70 RID: 2672
				BLUE,
				// Token: 0x04000A71 RID: 2673
				YELLOW,
				// Token: 0x04000A72 RID: 2674
				MAGENTA,
				// Token: 0x04000A73 RID: 2675
				SYAN,
				// Token: 0x04000A74 RID: 2676
				WHITE,
				// Token: 0x04000A75 RID: 2677
				MAX
			}

			// Token: 0x02000103 RID: 259
			private enum CONTROL
			{
				// Token: 0x04000A77 RID: 2679
				COMBOBOX_COLOR,
				// Token: 0x04000A78 RID: 2680
				NUMERIC_TIME,
				// Token: 0x04000A79 RID: 2681
				MAX
			}
		}

		// Token: 0x0200007B RID: 123
		public class BlockLoopEnd : ProgramModule.Block
		{
			// Token: 0x17000479 RID: 1145
			// (get) Token: 0x06000ECE RID: 3790 RVA: 0x00083458 File Offset: 0x00081658
			// (set) Token: 0x06000ECF RID: 3791 RVA: 0x00083460 File Offset: 0x00081660
			[XmlIgnore]
			public int Index
			{
				get
				{
					return this._index;
				}
				set
				{
					this._index = value;
				}
			}

			// Token: 0x1700047A RID: 1146
			// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x00083469 File Offset: 0x00081669
			// (set) Token: 0x06000ED1 RID: 3793 RVA: 0x00083471 File Offset: 0x00081671
			public bool IsCondition
			{
				get
				{
					return this._isCondition;
				}
				set
				{
					base.Updated |= this._isCondition != value;
					this._isCondition = value;
				}
			}

			// Token: 0x1700047B RID: 1147
			// (get) Token: 0x06000ED2 RID: 3794 RVA: 0x00083493 File Offset: 0x00081693
			// (set) Token: 0x06000ED3 RID: 3795 RVA: 0x0008349B File Offset: 0x0008169B
			public bool IsConditionNetwork
			{
				get
				{
					return this._isConditionNetwork;
				}
				set
				{
					base.Updated |= this._isConditionNetwork != value;
					this._isConditionNetwork = value;
				}
			}

			// Token: 0x1700047C RID: 1148
			// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x000834BD File Offset: 0x000816BD
			// (set) Token: 0x06000ED5 RID: 3797 RVA: 0x000834C5 File Offset: 0x000816C5
			public ProgramModule.BlockLoopEnd.CONDITION_LOOP_END Condition
			{
				get
				{
					return this._condition;
				}
				set
				{
					base.Updated |= this._condition != value;
					this._condition = value;
				}
			}

			// Token: 0x1700047D RID: 1149
			// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x000834E7 File Offset: 0x000816E7
			// (set) Token: 0x06000ED7 RID: 3799 RVA: 0x000834EF File Offset: 0x000816EF
			public ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END ConditionNetwork
			{
				get
				{
					return this._conditionNetwork;
				}
				set
				{
					base.Updated |= this._conditionNetwork != value;
					this._conditionNetwork = value;
				}
			}

			// Token: 0x1700047E RID: 1150
			// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x00083511 File Offset: 0x00081711
			// (set) Token: 0x06000ED9 RID: 3801 RVA: 0x00083519 File Offset: 0x00081719
			public ProgramModule.BlockIf.SELECT Select
			{
				get
				{
					return this._select;
				}
				set
				{
					base.Updated |= this._select != value;
					this._select = value;
				}
			}

			// Token: 0x1700047F RID: 1151
			// (get) Token: 0x06000EDA RID: 3802 RVA: 0x0008353B File Offset: 0x0008173B
			// (set) Token: 0x06000EDB RID: 3803 RVA: 0x00083543 File Offset: 0x00081743
			public int[] Values
			{
				get
				{
					return this._values;
				}
				set
				{
					base.Updated |= this._values != value;
					this._values = value;
				}
			}

			// Token: 0x17000480 RID: 1152
			// (get) Token: 0x06000EDC RID: 3804 RVA: 0x00083565 File Offset: 0x00081765
			// (set) Token: 0x06000EDD RID: 3805 RVA: 0x0008356D File Offset: 0x0008176D
			public int[] VariableIndexes
			{
				get
				{
					return this._variableIndexes;
				}
				set
				{
					base.Updated |= this._variableIndexes != value;
					this._variableIndexes = value;
				}
			}

			// Token: 0x17000481 RID: 1153
			// (get) Token: 0x06000EDE RID: 3806 RVA: 0x0008358F File Offset: 0x0008178F
			// (set) Token: 0x06000EDF RID: 3807 RVA: 0x00083597 File Offset: 0x00081797
			public ProgramModule.BlockIf.VARIABLE_TYPE_SECOND Variable
			{
				get
				{
					return this._variable;
				}
				set
				{
					base.Updated |= this._variable != value;
					this._variable = value;
				}
			}

			// Token: 0x17000482 RID: 1154
			// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x000835B9 File Offset: 0x000817B9
			// (set) Token: 0x06000EE1 RID: 3809 RVA: 0x000835C1 File Offset: 0x000817C1
			public string ObjectName
			{
				get
				{
					return this._objectName;
				}
				set
				{
					base.Updated |= !this._objectName.Equals(value);
					this._objectName = value;
				}
			}

			// Token: 0x17000483 RID: 1155
			// (get) Token: 0x06000EE2 RID: 3810 RVA: 0x000835E6 File Offset: 0x000817E6
			// (set) Token: 0x06000EE3 RID: 3811 RVA: 0x000835EE File Offset: 0x000817EE
			public string ConstString
			{
				get
				{
					return this._constString;
				}
				set
				{
					base.Updated |= !this._constString.Equals(value);
					this._constString = value;
				}
			}

			// Token: 0x06000EE4 RID: 3812 RVA: 0x00083614 File Offset: 0x00081814
			public BlockLoopEnd()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000EE5 RID: 3813 RVA: 0x000836B8 File Offset: 0x000818B8
			public override byte[] serializeBinary()
			{
				byte[] array = null;
				if (this.IsCondition)
				{
					switch (this._condition)
					{
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.BUTTON:
						array = new byte[2];
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							array[0] = 104;
						}
						else
						{
							array[0] = 105;
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT:
						if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							array = new byte[3];
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								array[0] = 108;
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								array[0] = 109;
							}
							else
							{
								array[0] = 110;
							}
							array[2] = (byte)this._values[0];
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							array = new byte[3];
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								array[0] = 111;
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								array[0] = 112;
							}
							else
							{
								array[0] = 113;
							}
							array[2] = (byte)this._variableIndexes[0];
						}
						else
						{
							array = new byte[2];
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								array[0] = 106;
							}
							else
							{
								array[0] = 107;
							}
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.SOUND:
						array = new byte[2];
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							array[0] = 114;
						}
						else
						{
							array[0] = 115;
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.ALARM:
						array = new byte[2];
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							array[0] = 125;
						}
						else
						{
							array[0] = 126;
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIMER:
						array = new byte[2];
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							array[0] = 127;
						}
						else
						{
							array[0] = 128;
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIME:
						array = new byte[4];
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							array[0] = 122;
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							array[0] = 123;
						}
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							array[0] = 124;
						}
						array[2] = (byte)this._values[0];
						array[3] = (byte)this._values[1];
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE:
						array = new byte[3];
						if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								array[0] = 116;
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								array[0] = 117;
							}
							else
							{
								array[0] = 118;
							}
							array[2] = (byte)this._values[0];
						}
						else
						{
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								array[0] = 119;
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								array[0] = 120;
							}
							else
							{
								array[0] = 121;
							}
							array[2] = (byte)this._variableIndexes[0];
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.COUNTER:
						array = new byte[3];
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							array[0] = 129;
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							array[0] = 130;
						}
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							array[0] = 131;
						}
						array[2] = (byte)this._values[0];
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE:
						array = new byte[4];
						if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							array[2] = (byte)this._variableIndexes[0];
							array[3] = (byte)this._values[0];
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								array[0] = 132;
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
							{
								array[0] = 133;
							}
							else
							{
								array[0] = 134;
							}
						}
						else
						{
							array[2] = (byte)this._variableIndexes[0];
							array[3] = (byte)this._variableIndexes[1];
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								array[0] = 135;
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
							{
								array[0] = 136;
							}
							else
							{
								array[0] = 137;
							}
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX:
						array = new byte[2];
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							array[0] = 143;
						}
						else
						{
							array[0] = 144;
						}
						break;
					}
				}
				else
				{
					array = new byte[2];
					array[0] = 77;
				}
				return array;
			}

			// Token: 0x06000EE6 RID: 3814 RVA: 0x00083A34 File Offset: 0x00081C34
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				this._isCondition = true;
				ProgramModule.Block.COMMAND_NUMBER command_NUMBER = (ProgramModule.Block.COMMAND_NUMBER)bytes[0];
				switch (command_NUMBER)
				{
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END:
					this._isCondition = false;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_BEGIN:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.BUTTON;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_BUTTON_OFF:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.BUTTON;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_LIGHT_BRIGHT:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_LIGHT_DARK:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_LIGHT_CONST_BRIGHT:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					this._values[0] = (int)bytes[2];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_LIGHT_CONST_SAME:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					this._values[0] = (int)bytes[2];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_LIGHT_CONST_DARK:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					this._values[0] = (int)bytes[2];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_LIGHT_VARIABLE_BRIGHT:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					this._values[0] = (int)bytes[2];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_LIGHT_VARIABLE_SAME:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					this._values[0] = (int)bytes[2];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_LIGHT_VARIABLE_DARK:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					this._values[0] = (int)bytes[2];
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_SOUND_OFF:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.SOUND;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_SOUND_ON:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.SOUND;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TEMPERATURE_COMPARE_GREATER_CONST:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					this._values[0] = (int)((sbyte)bytes[2]);
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TEMPERATURE_COMPARE_LESS_CONST:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					this._values[0] = (int)((sbyte)bytes[2]);
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TEMPERATURE_COMPARE_EQUAL_CONST:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					this._values[0] = (int)((sbyte)bytes[2]);
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TEMPERATURE_COMPARE_GREATER_VARIABLE:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					this._variableIndexes[0] = (int)bytes[2];
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TEMPERATURE_COMPARE_LESS_VARIABLE:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					this._variableIndexes[0] = (int)bytes[2];
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TEMPERATURE_COMPARE_EQUAL_VARIABLE:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					this._variableIndexes[0] = (int)bytes[2];
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TIME_COMPARE_GREATER:
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TIME_COMPARE_EQUAL:
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TIME_COMPARE_LESS:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIME;
					this._values[0] = (int)bytes[2];
					this._values[1] = (int)bytes[3];
					if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TIME_COMPARE_GREATER)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					}
					else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TIME_COMPARE_EQUAL)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					}
					else
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					}
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_ALARAM_ON:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.ALARM;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_ALARAM_OFF:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.ALARM;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TIMER_ON:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIMER;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_TIMER_OFF:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIMER;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_COUNTER_COMPARE_GREATER:
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_COUNTER_COMPARE_EQUAL:
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_COUNTER_COMPARE_LESS:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.COUNTER;
					this._values[0] = (int)bytes[2];
					if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LOOP_END_COUNTER_COMPARE_GREATER)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					}
					else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LOOP_END_COUNTER_COMPARE_EQUAL)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					}
					else
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					}
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_VARIABLE_COMPARE_GREATER_CONST:
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_VARIABLE_COMPARE_EQUAL_CONST:
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_VARIABLE_COMPARE_LESS_CONST:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE;
					this._variableIndexes[0] = (int)bytes[2];
					this._values[0] = (int)((sbyte)bytes[3]);
					if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LOOP_END_VARIABLE_COMPARE_GREATER_CONST)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					}
					else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LOOP_END_VARIABLE_COMPARE_EQUAL_CONST)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					}
					else
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					}
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_VARIABLE_COMPARE_GREATER_VARIABLE:
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_VARIABLE_COMPARE_EQUAL_VARIABLE:
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_VARIABLE_COMPARE_LESS_VARIABLE:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE;
					this._variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX;
					this._variableIndexes[0] = (int)bytes[2];
					this._variableIndexes[1] = (int)bytes[3];
					if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LOOP_END_VARIABLE_COMPARE_GREATER_VARIABLE)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_MAX;
					}
					else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LOOP_END_VARIABLE_COMPARE_EQUAL_VARIABLE)
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					}
					else
					{
						this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					}
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_SECOND_BEGIN:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					break;
				case ProgramModule.Block.COMMAND_NUMBER.LOOP_END_USBIN_OFF:
					this._condition = ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX;
					this._select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					break;
				}
				return true;
			}

			// Token: 0x06000EE7 RID: 3815 RVA: 0x00083F4E File Offset: 0x0008214E
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.fc_block_190, base.Location);
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000EE8 RID: 3816 RVA: 0x00083F88 File Offset: 0x00082188
			public override void paintRect(Graphics graphics, Color color, bool fill)
			{
				Point[] array = new Point[]
				{
					new Point(base.Location.X, base.Location.Y),
					new Point(base.Location.X, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height * 2 / 3 + 2),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 6, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width * 5 / 6, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height * 2 / 3 + 2),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width, base.Location.Y)
				};
				if (fill)
				{
					Brush brush = new SolidBrush(color);
					graphics.FillPolygon(brush, array);
					return;
				}
				Pen pen = new Pen(color, 4f);
				graphics.DrawPolygon(pen, array);
			}

			// Token: 0x06000EE9 RID: 3817 RVA: 0x00084120 File Offset: 0x00082320
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				string text = "";
				if (this.IsCondition || this.IsConditionNetwork)
				{
					string text2 = "";
					if (this.IsCondition)
					{
						switch (this._condition)
						{
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.BUTTON:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text2 = "BUTTON = ON";
							}
							else
							{
								text2 = "BUTTON = OFF";
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT:
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
								{
									text2 = "LIGHT > " + this._values[0].ToString();
								}
								else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
								{
									text2 = "LIGHT = " + this._values[0].ToString();
								}
								else
								{
									text2 = "LIGHT < " + this._values[0].ToString();
								}
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
								{
									text2 = "LIGHT > " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]];
								}
								else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
								{
									text2 = "LIGHT = " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]];
								}
								else
								{
									text2 = "LIGHT < " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]];
								}
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text2 = "LIGHT = BRIGHT";
							}
							else
							{
								text2 = "LIGHT = DARK";
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.SOUND:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text2 = "SOUND = ON";
							}
							else
							{
								text2 = "SOUND = OFF";
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.ALARM:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text2 = "ALARM = ON";
							}
							else
							{
								text2 = "ALARM = OFF";
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIMER:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text2 = "TIMER == ON";
							}
							else
							{
								text2 = "TIMER == OFF";
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIME:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								text2 = string.Concat(new string[]
								{
									"HOUR < ",
									this._values[0].ToString(),
									" OR HOUR = ",
									this._values[0].ToString(),
									" AND MINUTE < ",
									this._values[1].ToString()
								});
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
							{
								text2 = "HOUR = " + this._values[0].ToString() + " AND MINUTE = " + this._values[1].ToString();
							}
							else
							{
								text2 = string.Concat(new string[]
								{
									"HOUR > ",
									this._values[0].ToString(),
									" OR HOUR = ",
									this._values[0].ToString(),
									" AND MINUTE > ",
									this._values[1].ToString()
								});
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
								{
									text2 = "TEMPERATURE > " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]];
								}
								else
								{
									text2 = "TEMPERATURE > " + this._values[0].ToString();
								}
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
							{
								if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
								{
									text2 = "TEMPERATURE = " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]];
								}
								else
								{
									text2 = "TEMPERATURE = " + this._values[0].ToString();
								}
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text2 = "TEMPERATURE < " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]];
							}
							else
							{
								text2 = "TEMPERATURE < " + this._values[0].ToString();
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.COUNTER:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								text2 = "COUNTER > " + this._values[0].ToString();
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
							{
								text2 = "COUNTER = " + this._values[0].ToString();
							}
							else
							{
								text2 = "COUNTER < " + this._values[0].ToString();
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
								{
									text2 = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " > " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[1]];
								}
								else
								{
									text2 = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " > " + this._values[0].ToString();
								}
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
							{
								if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
								{
									text2 = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " = " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[1]];
								}
								else
								{
									text2 = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " = " + this._values[0].ToString();
								}
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text2 = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " < " + ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[1]];
							}
							else
							{
								text2 = ProgramModule.BlockIf.VARIABLE_NAME_ITEMS[this._variableIndexes[0]] + " < " + this._values[0].ToString();
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text2 = "INPUT = ON";
							}
							else
							{
								text2 = "INPUT = OFF";
							}
							break;
						}
					}
					else
					{
						switch (this._conditionNetwork)
						{
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.OBJECT_BUTTON:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text2 = this._objectName + " = ON";
							}
							else
							{
								text2 = this._objectName + " = OFF";
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
								{
									string text3 = ((this._variableIndexes[1] == 0) ? "INPUT" : NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]);
									text2 = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + " > " + text3;
								}
								else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
								{
									text2 = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + " > " + this._values[0].ToString();
								}
								else
								{
									text2 = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + " > " + this._constString;
								}
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
							{
								if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
								{
									string text4 = ((this._variableIndexes[1] == 0) ? "INPUT" : NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]);
									text2 = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + " = " + text4;
								}
								else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
								{
									text2 = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + " = " + this._values[0].ToString();
								}
								else
								{
									text2 = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + " = " + this._constString;
								}
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								string text5 = ((this._variableIndexes[1] == 0) ? "INPUT" : NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]);
								text2 = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + " < " + text5;
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text2 = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + " < " + this._values[0].ToString();
							}
							else
							{
								text2 = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + " < " + this._constString;
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.BUTTON:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text2 = "BUTTON = ON";
							}
							else
							{
								text2 = "BUTTON = OFF";
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.LIGHT:
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
								{
									text2 = "LIGHT > " + this._values[0].ToString();
								}
								else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
								{
									text2 = "LIGHT = " + this._values[0].ToString();
								}
								else
								{
									text2 = "LIGHT < " + this._values[0].ToString();
								}
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
								{
									text2 = "LIGHT > " + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]];
								}
								else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
								{
									text2 = "LIGHT = " + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]];
								}
								else
								{
									text2 = "LIGHT < " + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]];
								}
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text2 = "LIGHT = BRIGHT";
							}
							else
							{
								text2 = "LIGHT = DARK";
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.TEMPERATURE:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
							{
								if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
								{
									text2 = "TEMPERATURE > " + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]];
								}
								else
								{
									text2 = "TEMPERATURE > " + this._values[0].ToString();
								}
							}
							else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
							{
								if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
								{
									text2 = "TEMPERATURE = " + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]];
								}
								else
								{
									text2 = "TEMPERATURE = " + this._values[0].ToString();
								}
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text2 = "TEMPERATURE < " + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]];
							}
							else
							{
								text2 = "TEMPERATURE < " + this._values[0].ToString();
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.SOUND:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text2 = "SOUND = ON";
							}
							else
							{
								text2 = "SOUND = OFF";
							}
							break;
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.USBIN:
							if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
							{
								text2 = "INPUT = ON";
							}
							else
							{
								text2 = "INPUT = OFF";
							}
							break;
						}
					}
					base.addIndent(ref text, indent);
					text = text + "IF " + text2 + " THEN\r\n";
					base.addIndent(ref text, indent + 3);
					text += "GOTO:";
					if (base.Next != null)
					{
						if (base.Next.GetType() == typeof(ProgramModule.BlockEnd))
						{
							text += "[end]";
						}
						else
						{
							int num = blockList.IndexOf(base.Next);
							if (base.Next == this)
							{
								num = blockList.Count;
							}
							if (num >= 0)
							{
								text += num.ToString();
							}
							else
							{
								text += (codeList.Count + 1).ToString();
							}
						}
					}
					text += "\r\n";
					base.addIndent(ref text, --indent + 2);
				}
				else
				{
					base.addIndent(ref text, --indent);
				}
				char c = ((this._index == 0 || this._index > 6) ? '?' : ((char)(105 + this._index - 1)));
				text = text + "NEXT " + c.ToString();
				codeList.Add(text);
				base.getProgram(blockList, codeList, indent);
			}

			// Token: 0x06000EEA RID: 3818 RVA: 0x00084DB4 File Offset: 0x00082FB4
			public override string getDetail()
			{
				string detailSub = this.getDetailSub();
				if (this._index <= 0)
				{
					return "対応するループ開\r\n始がありません";
				}
				if (this._isCondition || this._isConditionNetwork)
				{
					return string.Concat(new string[]
					{
						"ループ",
						this._index.ToString(),
						"の終了\r\n(",
						detailSub,
						")"
					});
				}
				return "ループ" + this._index.ToString() + "の終了";
			}

			// Token: 0x06000EEB RID: 3819 RVA: 0x00084E38 File Offset: 0x00083038
			private string getDetailSub()
			{
				string text = "";
				if (this._isCondition)
				{
					switch (this._condition)
					{
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.BUTTON:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "ボタンがON";
						}
						else
						{
							text = "ボタンがOFF";
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = "周囲が" + this._values[0].ToString() + "より明るい";
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = "周囲が" + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "より明るい";
							}
							else
							{
								text = "周囲が明るい";
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = "周囲が" + this._values[0].ToString() + "と同じ";
							}
							else
							{
								text = "周囲が" + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "と同じ";
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = "周囲が" + this._values[0].ToString() + "より暗い";
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = "周囲が" + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "より暗い";
						}
						else
						{
							text = "周囲が暗い";
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.SOUND:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "音がする";
						}
						else
						{
							text = "音がしない";
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.ALARM:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "アラーム入力あり";
						}
						else
						{
							text = "アラーム入力なし";
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIMER:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "タイマー入力あり";
						}
						else
						{
							text = "タイマー入力なし";
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIME:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._values[0] < 9)
							{
								text += "0";
							}
							text = text + this._values[0].ToString() + ":";
							if (this._values[1] < 9)
							{
								text += "0";
							}
							text = text + this._values[1].ToString() + "よりも早い";
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._values[0] < 9)
							{
								text += "0";
							}
							text = text + this._values[0].ToString() + ":";
							if (this._values[1] < 9)
							{
								text += "0";
							}
							text = text + this._values[1].ToString() + "と同じ";
						}
						else
						{
							if (this._values[0] < 9)
							{
								text += "0";
							}
							text = text + this._values[0].ToString() + ":";
							if (this._values[1] < 9)
							{
								text += "0";
							}
							text = text + this._values[1].ToString() + "よりも遅い";
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
							else
							{
								text = this._values[0].ToString() + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
							else
							{
								text = this._values[0].ToString() + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
						}
						else
						{
							text = this._values[0].ToString() + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.COUNTER:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							text = this._values[0].ToString() + "よりも多い";
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							text = this._values[0].ToString() + "と同じ";
						}
						else
						{
							text = this._values[0].ToString() + "よりも小さい";
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "が" + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[1]] + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
							else
							{
								text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "が" + this._values[0].ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "が" + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[1]] + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
							else
							{
								text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "が" + this._values[0].ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "が" + ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[1]] + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
						}
						else
						{
							text = ProgramModule.BlockIf.VARIABLE_ITEMS[this._variableIndexes[0]] + "が" + this._values[0].ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "外部入力あり";
						}
						else
						{
							text = "外部入力なし";
						}
						break;
					}
				}
				else if (this._isConditionNetwork)
				{
					switch (this._conditionNetwork)
					{
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.OBJECT_BUTTON:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = this._objectName + "がON";
						}
						else
						{
							text = this._objectName + "がOFF";
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								string text2 = ((this._variableIndexes[1] == 0) ? "入力変数" : NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]);
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + text2 + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + this._values[0].ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
							else
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + this._constString + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								string text3 = ((this._variableIndexes[1] == 0) ? "入力変数" : NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]);
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + text3 + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + this._values[0].ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
							else
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + this._constString + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							string text4 = ((this._variableIndexes[1] == 0) ? "入力変数" : NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[1] - 1]);
							text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + text4 + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + this._values[0].ToString() + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
						}
						else
						{
							text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "が" + this._constString + ProgramModule.BlockIf.COMPARE_ITEMS[(int)this._select];
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.BUTTON:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "ボタンがON";
						}
						else
						{
							text = "ボタンがOFF";
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.LIGHT:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = "周囲が" + this._values[0].ToString() + "より明るい";
							}
							else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = "周囲が" + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "より明るい";
							}
							else
							{
								text = "周囲が明るい";
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								text = "周囲が" + this._values[0].ToString() + "と同じ";
							}
							else
							{
								text = "周囲が" + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "と同じ";
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = "周囲が" + this._values[0].ToString() + "より暗い";
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = "周囲が" + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "より暗い";
						}
						else
						{
							text = "周囲が暗い";
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.TEMPERATURE:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_MAX)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
							else
							{
								text = this._values[0].ToString() + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
						}
						else if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_OFF)
						{
							if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
							else
							{
								text = this._values[0].ToString() + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
							}
						}
						else if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndexes[0]] + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
						}
						else
						{
							text = this._values[0].ToString() + "℃" + ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this._select];
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.SOUND:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "音がする";
						}
						else
						{
							text = "音がしない";
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.USBIN:
						if (this._select == ProgramModule.BlockIf.SELECT.BUTTON_ON)
						{
							text = "外部入力あり";
						}
						else
						{
							text = "外部入力なし";
						}
						break;
					}
				}
				return text;
			}

			// Token: 0x06000EEC RID: 3820 RVA: 0x00085B64 File Offset: 0x00083D64
			public override int getUsedMemory()
			{
				int num = 0;
				if (this.IsCondition)
				{
					switch (this._condition)
					{
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.BUTTON:
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.SOUND:
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.ALARM:
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIMER:
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX:
						num = 2;
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT:
						if (this._variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID)
						{
							num = 2;
						}
						else
						{
							num = 3;
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIME:
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE:
						num = 4;
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE:
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.COUNTER:
						num = 3;
						break;
					}
				}
				else
				{
					num = 2;
				}
				return num;
			}

			// Token: 0x06000EED RID: 3821 RVA: 0x00085BD2 File Offset: 0x00083DD2
			public override bool isIconBlock()
			{
				return !this._isCondition;
			}

			// Token: 0x04000791 RID: 1937
			public const int USE_MEMORY_MAX = 2;

			// Token: 0x04000792 RID: 1938
			public static readonly string[] CONDITION_ITEMS = new string[] { "ボタン", "明るさ", "音", "アラーム", "タイマー", "時刻", "温度", "秒カウンタ", "変数", "外部入力" };

			// Token: 0x04000793 RID: 1939
			public static readonly string[] CONDITION_NETWORK_ITEMS = new string[] { "ボタン", "データ", "コロックル ボタン", "コロックル 光センサ", "コロックル 温度センサ", "コロックル 音センサ", "コロックル 外部入力" };

			// Token: 0x04000794 RID: 1940
			private int _index;

			// Token: 0x04000795 RID: 1941
			private bool _isCondition;

			// Token: 0x04000796 RID: 1942
			private bool _isConditionNetwork;

			// Token: 0x04000797 RID: 1943
			private ProgramModule.BlockLoopEnd.CONDITION_LOOP_END _condition;

			// Token: 0x04000798 RID: 1944
			private ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END _conditionNetwork;

			// Token: 0x04000799 RID: 1945
			private ProgramModule.BlockIf.SELECT _select;

			// Token: 0x0400079A RID: 1946
			private int[] _values = new int[2];

			// Token: 0x0400079B RID: 1947
			private int[] _variableIndexes = new int[2];

			// Token: 0x0400079C RID: 1948
			private ProgramModule.BlockIf.VARIABLE_TYPE_SECOND _variable;

			// Token: 0x0400079D RID: 1949
			private string _objectName = "";

			// Token: 0x0400079E RID: 1950
			private string _constString = "";

			// Token: 0x02000104 RID: 260
			public enum CONDITION_LOOP_END
			{
				// Token: 0x04000A7B RID: 2683
				BUTTON,
				// Token: 0x04000A7C RID: 2684
				LIGHT,
				// Token: 0x04000A7D RID: 2685
				SOUND,
				// Token: 0x04000A7E RID: 2686
				ALARM,
				// Token: 0x04000A7F RID: 2687
				TIMER,
				// Token: 0x04000A80 RID: 2688
				TIME,
				// Token: 0x04000A81 RID: 2689
				TEMPERATURE,
				// Token: 0x04000A82 RID: 2690
				COUNTER,
				// Token: 0x04000A83 RID: 2691
				VARIABLE,
				// Token: 0x04000A84 RID: 2692
				NO_USBIN_MAX,
				// Token: 0x04000A85 RID: 2693
				USBIN = 9,
				// Token: 0x04000A86 RID: 2694
				MAX
			}

			// Token: 0x02000105 RID: 261
			public enum CONDITION_NETWORK_LOOP_END
			{
				// Token: 0x04000A88 RID: 2696
				OBJECT_BUTTON,
				// Token: 0x04000A89 RID: 2697
				VARIABLE,
				// Token: 0x04000A8A RID: 2698
				BUTTON,
				// Token: 0x04000A8B RID: 2699
				LIGHT,
				// Token: 0x04000A8C RID: 2700
				TEMPERATURE,
				// Token: 0x04000A8D RID: 2701
				SOUND,
				// Token: 0x04000A8E RID: 2702
				USBIN,
				// Token: 0x04000A8F RID: 2703
				MAX
			}
		}

		// Token: 0x0200007C RID: 124
		public class BlockLoopStart : ProgramModule.BlockBranch
		{
			// Token: 0x17000484 RID: 1156
			// (get) Token: 0x06000EEF RID: 3823 RVA: 0x00085C8D File Offset: 0x00083E8D
			// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x00085C95 File Offset: 0x00083E95
			public int Count
			{
				get
				{
					return this._count;
				}
				set
				{
					base.Updated |= this._count != value;
					this._count = value;
				}
			}

			// Token: 0x17000485 RID: 1157
			// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x00085CB7 File Offset: 0x00083EB7
			// (set) Token: 0x06000EF2 RID: 3826 RVA: 0x00085CBF File Offset: 0x00083EBF
			[XmlIgnore]
			public int Index
			{
				get
				{
					return this._index;
				}
				set
				{
					this._index = value;
				}
			}

			// Token: 0x17000486 RID: 1158
			// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x00085CC8 File Offset: 0x00083EC8
			// (set) Token: 0x06000EF4 RID: 3828 RVA: 0x00085CD0 File Offset: 0x00083ED0
			public ProgramModule.BlockLoopEnd BlockLoopEnd
			{
				get
				{
					return this._blockLoopEnd;
				}
				set
				{
					this._blockLoopEnd = value;
				}
			}

			// Token: 0x06000EF5 RID: 3829 RVA: 0x00085CDC File Offset: 0x00083EDC
			public BlockLoopStart()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000EF6 RID: 3830 RVA: 0x00085D4F File Offset: 0x00083F4F
			public BlockLoopStart(int branchCount)
				: this()
			{
				this.initializeBranches(branchCount);
				this._blockLoopEnd = new ProgramModule.BlockLoopEnd();
			}

			// Token: 0x06000EF7 RID: 3831 RVA: 0x00085D6C File Offset: 0x00083F6C
			public override void initializeBranches(int branchCount)
			{
				if (base.Branches == null || base.Branches.Count != branchCount)
				{
					base.Branches = new List<ProgramModule.Block>();
					base.Branches.Add(null);
				}
				if (base.ConnectIndexBranches == null || base.ConnectIndexBranches.Count != branchCount)
				{
					base.ConnectIndexBranches = new List<int>();
					base.ConnectIndexBranches.Add(-1);
				}
			}

			// Token: 0x06000EF8 RID: 3832 RVA: 0x00085DD3 File Offset: 0x00083FD3
			public override byte[] serializeBinary()
			{
				return new byte[]
				{
					76,
					0,
					(byte)this._count
				};
			}

			// Token: 0x06000EF9 RID: 3833 RVA: 0x00085DEA File Offset: 0x00083FEA
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				this._count = (int)bytes[2];
				return true;
			}

			// Token: 0x06000EFA RID: 3834 RVA: 0x00085DF6 File Offset: 0x00083FF6
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.fc_block_180, base.Location);
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000EFB RID: 3835 RVA: 0x00085E30 File Offset: 0x00084030
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					int num = base.LocationBlock.Y;
					int num2 = base.SizeBlock.Width - Resources.bp_block_060.Width - Resources.bp_block_062.Width + 1;
					graphics.DrawImage(Resources.bp_block_060, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_061, new Rectangle(base.LocationBlock.X + Resources.bp_block_060.Width, num, num2, Resources.bp_block_061.Height));
					graphics.DrawImage(Resources.bp_block_062, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_062.Width, num));
					num += ProgramModule.Block.LINE_HEIGHT;
					if (base.Branches[0] == null)
					{
						graphics.DrawImage(Resources.bp_block_063, new Rectangle(base.LocationBlock.X, num, Resources.bp_block_063.Width, ProgramModule.Block.LINE_HEIGHT));
						num += ProgramModule.Block.LINE_HEIGHT;
					}
					else
					{
						int height = base.Branches[0].getConnectedBlocksSize().Height;
						graphics.DrawImage(Resources.bp_block_063, new Rectangle(base.LocationBlock.X, num, Resources.bp_block_063.Width, height));
						num += height;
					}
					graphics.DrawImage(Resources.bp_block_064, new Point(base.LocationBlock.X, num));
					graphics.DrawImage(Resources.bp_block_061, new Rectangle(base.LocationBlock.X + Resources.bp_block_064.Width, num, num2, Resources.bp_block_061.Height));
					graphics.DrawImage(Resources.bp_block_062, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_062.Width, num));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						graphics.DrawString(this.getDetailBlockLoopEnd(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawLines(Pens.Black, new Point[]
					{
						base.LocationBlock,
						new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y),
						new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT),
						new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + ProgramModule.Block.LINE_HEIGHT),
						new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT),
						new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT),
						new Point(base.LocationBlock.X + base.SizeBlock.Width, base.LocationBlock.Y + base.SizeBlock.Height),
						new Point(base.LocationBlock.X, base.LocationBlock.Y + base.SizeBlock.Height),
						base.LocationBlock
					});
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						graphics.DrawString(this.getDetailBlockLoopEnd(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000EFC RID: 3836 RVA: 0x000863A4 File Offset: 0x000845A4
			public override void paintRect(Graphics graphics, Color color, bool fill)
			{
				Point[] array = new Point[]
				{
					new Point(base.Location.X, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height),
					new Point(base.Location.X, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height / 3 - 2),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 6, base.Location.Y),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width * 5 / 6, base.Location.Y),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height / 3 - 2),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height)
				};
				if (fill)
				{
					Brush brush = new SolidBrush(color);
					graphics.FillPolygon(brush, array);
					return;
				}
				Pen pen = new Pen(color, 4f);
				graphics.DrawPolygon(pen, array);
			}

			// Token: 0x06000EFD RID: 3837 RVA: 0x00086538 File Offset: 0x00084738
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				string text = "";
				base.addIndent(ref text, indent);
				char c = ((this._index > 6) ? '?' : ((char)(105 + this._index - 1)));
				if (this._count == 0)
				{
					text = text + "FOR " + c.ToString() + " = 0 TO 1 STEP 0";
				}
				else
				{
					text = string.Concat(new string[]
					{
						text,
						"FOR ",
						c.ToString(),
						" = 1 TO ",
						this._count.ToString()
					});
				}
				codeList.Add(text);
				base.getProgram(blockList, codeList, ++indent);
			}

			// Token: 0x06000EFE RID: 3838 RVA: 0x000865E0 File Offset: 0x000847E0
			public override void convertBlock(List<ProgramModule.Block> checkedBlocks, List<ProgramModule.Block> newBlocks)
			{
				this.createBlockControls();
				checkedBlocks.Add(this);
				this.initializeBranches(1);
				ProgramModule.Block block = base.Next;
				int num = 1;
				while (block != null)
				{
					if (block is ProgramModule.BlockLoopStart)
					{
						num++;
					}
					else if (block is ProgramModule.BlockLoopEnd)
					{
						num--;
						if (num == 0)
						{
							break;
						}
					}
					block = block.Next;
				}
				if (block != null)
				{
					this._blockLoopEnd = (ProgramModule.BlockLoopEnd)block;
					if (block != base.Next)
					{
						base.Branches[0] = base.Next;
						base.Branches[0].Before = null;
					}
					if (checkedBlocks.Contains(block.Next))
					{
						ProgramModule.BlockJump blockJump = new ProgramModule.BlockJump();
						newBlocks.Add(blockJump);
						blockJump.JumpTemp = block.Next;
						base.Next = blockJump;
					}
					else if (block.Next is ProgramModule.BlockLoopEnd)
					{
						ProgramModule.BlockJump blockJump2 = new ProgramModule.BlockJump();
						newBlocks.Add(blockJump2);
						blockJump2.JumpTemp = block.Next;
						base.Next = blockJump2;
					}
					else
					{
						base.Next = block.Next;
					}
					if (base.Next != null)
					{
						base.Next.Before = this;
					}
					if (base.Branches[0] != null)
					{
						base.Branches[0].convertBlock(checkedBlocks, newBlocks);
					}
					if (base.Next != null)
					{
						base.Next.convertBlock(checkedBlocks, newBlocks);
					}
				}
			}

			// Token: 0x06000EFF RID: 3839 RVA: 0x00086728 File Offset: 0x00084928
			public override void convertFlowchart(List<ProgramModule.Block> checkedBlocks)
			{
				checkedBlocks.Add(this);
				ProgramModule.Block next = base.Next;
				if (base.Branches[0] == null)
				{
					base.Next = this._blockLoopEnd;
				}
				else
				{
					if (base.Branches[0] is ProgramModule.BlockLabel)
					{
						base.Next = base.Branches[0].Next;
					}
					else
					{
						base.Next = base.Branches[0];
					}
					base.Next.Last.Next = this._blockLoopEnd;
					base.Next.convertFlowchart(checkedBlocks);
				}
				this._blockLoopEnd.Next = next;
				if (next != null)
				{
					next.Before = this._blockLoopEnd;
					if (!checkedBlocks.Contains(next))
					{
						next.convertFlowchart(checkedBlocks);
					}
				}
			}

			// Token: 0x06000F00 RID: 3840 RVA: 0x000867EC File Offset: 0x000849EC
			public override string getDetail()
			{
				string text = "ループ" + this._index.ToString() + "の開始\r\n";
				if (this._count == 0)
				{
					text += "ずっとくり返す";
				}
				else
				{
					text = text + this._count.ToString() + "回";
				}
				return text;
			}

			// Token: 0x06000F01 RID: 3841 RVA: 0x00086844 File Offset: 0x00084A44
			public override string getDetailBlock(bool isPrint)
			{
				string text;
				if (this.Count == 0)
				{
					text = "ずっとくり返す";
				}
				else
				{
					text = (isPrint ? string.Format("{0}回くり返す", this.Count) : "\u3000\u3000回くり返す");
				}
				return text;
			}

			// Token: 0x06000F02 RID: 3842 RVA: 0x00086884 File Offset: 0x00084A84
			public string getDetailBlockLoopEnd(bool isPrint)
			{
				string text = "";
				if (this.BlockLoopEnd.IsCondition)
				{
					switch (this.BlockLoopEnd.Condition)
					{
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.BUTTON:
						text = (isPrint ? ("ボタンが" + ProgramModule.BlockIf.SELECT_BUTTON_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "ボタンが\u3000\u3000\u3000なら抜ける");
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT:
						if (this.BlockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = (isPrint ? string.Format("周囲が{0}{1}なら抜ける", this.BlockLoopEnd.Values[0], ProgramModule.BlockIf.LIGHT_ITEMS[(int)this.BlockLoopEnd.Select]) : "周囲が\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら抜ける");
						}
						else if (this.BlockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = (isPrint ? ("周囲が" + ProgramModule.BlockIf.VARIABLE_ITEMS[this.BlockLoopEnd.VariableIndexes[0]] + ProgramModule.BlockIf.LIGHT_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "周囲が\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら抜ける");
						}
						else
						{
							text = (isPrint ? ("周囲が" + ProgramModule.BlockIf.SELECT_LIGHT2_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "周囲が\u3000\u3000\u3000\u3000なら抜ける");
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.SOUND:
						text = (isPrint ? ("音が" + ProgramModule.BlockIf.SELECT_SOUND_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "音が\u3000\u3000\u3000なら抜ける");
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.ALARM:
						text = (isPrint ? ("アラーム入力が" + ProgramModule.BlockIf.SELECT_ALARM_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "アラーム入力が\u3000\u3000\u3000なら抜ける");
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIMER:
						text = (isPrint ? ("タイマー入力が" + ProgramModule.BlockIf.SELECT_TIMER_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "タイマー入力が\u3000\u3000\u3000なら抜ける");
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIME:
						text = (isPrint ? string.Concat(new string[]
						{
							"時刻が",
							this.BlockLoopEnd.Values[0].ToString().PadLeft(2, '0'),
							":",
							this.BlockLoopEnd.Values[1].ToString().PadLeft(2, '0'),
							ProgramModule.BlockIf.SELECT_TIME_ITEMS[(int)this.BlockLoopEnd.Select],
							"なら抜ける"
						}) : "時刻が\u3000 \u3000：\u3000\u3000\u3000\u3000\u3000\u3000なら抜ける");
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE:
						if (this.BlockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = (isPrint ? string.Format("温度が{0}℃{1}なら抜ける", this.BlockLoopEnd.Values[0], ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this.BlockLoopEnd.Select]) : "温度が\u3000\u3000\u3000℃\u3000\u3000\u3000\u3000\u3000なら抜ける");
						}
						else
						{
							text = (isPrint ? string.Concat(new string[]
							{
								"温度が",
								ProgramModule.BlockIf.VARIABLE_ITEMS[this.BlockLoopEnd.VariableIndexes[0]],
								"℃",
								ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this.BlockLoopEnd.Select],
								"なら抜ける"
							}) : "温度が\u3000\u3000\u3000 ℃\u3000\u3000\u3000\u3000\u3000なら抜ける");
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.COUNTER:
						text = (isPrint ? string.Format("秒カウンタが{0}{1}なら抜ける", this.BlockLoopEnd.Values[0], ProgramModule.BlockIf.SELECT_COUNTER_ITEMS[(int)this.BlockLoopEnd.Select]) : "秒カウンタが\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら抜ける");
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE:
						if (this.BlockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = (isPrint ? string.Format("{0}が{1}{2}なら抜ける", ProgramModule.BlockIf.VARIABLE_ITEMS[this.BlockLoopEnd.VariableIndexes[0]], this.BlockLoopEnd.Values[0], ProgramModule.BlockIf.COMPARE_ITEMS[(int)this.BlockLoopEnd.Select]) : "\u3000\u3000\u3000が\u3000\u3000\u3000\u3000\u3000\u3000\u3000 なら抜ける");
						}
						else
						{
							text = (isPrint ? string.Concat(new string[]
							{
								ProgramModule.BlockIf.VARIABLE_ITEMS[this.BlockLoopEnd.VariableIndexes[0]],
								"が",
								ProgramModule.BlockIf.VARIABLE_ITEMS[this.BlockLoopEnd.VariableIndexes[1]],
								ProgramModule.BlockIf.COMPARE_ITEMS[(int)this.BlockLoopEnd.Select],
								"なら抜ける"
							}) : "\u3000\u3000\u3000が\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら抜ける");
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX:
						text = (isPrint ? ("外部入力が" + ProgramModule.BlockIf.SELECT_USBIN_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "外部入力が\u3000\u3000\u3000なら抜ける");
						break;
					}
				}
				else if (this.BlockLoopEnd.IsConditionNetwork)
				{
					switch (this.BlockLoopEnd.ConditionNetwork)
					{
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.OBJECT_BUTTON:
						if (this.BlockLoopEnd.ObjectName == null)
						{
							text = (isPrint ? ("が" + ProgramModule.BlockIf.SELECT_BUTTON_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "\u3000\u3000\u3000\u3000が\u3000\u3000\u3000なら抜ける");
						}
						else
						{
							text = (isPrint ? (this.BlockLoopEnd.ObjectName + "が" + ProgramModule.BlockIf.SELECT_BUTTON_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "\u3000\u3000\u3000\u3000が\u3000\u3000\u3000なら抜ける");
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE:
						if (this.BlockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = (isPrint ? string.Format("(C){0}が{1}{2}なら抜ける", NetworkWindow.Instance.Programs.ClientVariableNames[this.BlockLoopEnd.VariableIndexes[0]], this.BlockLoopEnd.Values[0], ProgramModule.BlockIf.COMPARE_ITEMS[(int)this.BlockLoopEnd.Select]) : "\u3000\u3000\u3000\u3000 が\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら抜ける");
						}
						else if (this.BlockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							string text2 = ((this.BlockLoopEnd.VariableIndexes[1] == 0) ? "入力変数" : ("(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this.BlockLoopEnd.VariableIndexes[1] - 1]));
							text = (isPrint ? string.Concat(new string[]
							{
								"(C)",
								NetworkWindow.Instance.Programs.ClientVariableNames[this.BlockLoopEnd.VariableIndexes[0]],
								"が",
								text2,
								ProgramModule.BlockIf.COMPARE_ITEMS[(int)this.BlockLoopEnd.Select],
								"なら抜ける"
							}) : "\u3000\u3000\u3000\u3000 が\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000 なら抜ける");
						}
						else
						{
							text = (isPrint ? string.Concat(new string[]
							{
								"(C)",
								NetworkWindow.Instance.Programs.ClientVariableNames[this.BlockLoopEnd.VariableIndexes[0]],
								"が",
								this.BlockLoopEnd.ConstString,
								ProgramModule.BlockIf.COMPARE_ITEMS[(int)this.BlockLoopEnd.Select],
								"なら抜ける"
							}) : "\u3000\u3000\u3000\u3000 が\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000 なら抜ける");
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.BUTTON:
						text = (isPrint ? ("コロックルのボタンが" + ProgramModule.BlockIf.SELECT_BUTTON_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "コロックルのボタンが\u3000\u3000\u3000なら抜ける");
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.LIGHT:
						if (this.BlockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = (isPrint ? string.Format("周囲が{0}{1}なら抜ける", this.BlockLoopEnd.Values[0], ProgramModule.BlockIf.LIGHT_ITEMS[(int)this.BlockLoopEnd.Select]) : "周囲が\u3000\u3000\u3000\u3000\u3000\u3000\u3000 なら抜ける");
						}
						else if (this.BlockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							text = (isPrint ? ("周囲が(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this.BlockLoopEnd.VariableIndexes[0]] + ProgramModule.BlockIf.LIGHT_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "周囲が\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000なら抜ける");
						}
						else
						{
							text = (isPrint ? ("周囲が" + ProgramModule.BlockIf.SELECT_LIGHT2_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "周囲が\u3000\u3000\u3000\u3000なら抜ける");
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.TEMPERATURE:
						if (this.BlockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							text = (isPrint ? string.Format("温度が{0}℃{1}なら抜ける", this.BlockLoopEnd.Values[0], ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this.BlockLoopEnd.Select]) : "温度が\u3000\u3000\u3000℃\u3000\u3000\u3000\u3000 なら抜ける");
						}
						else
						{
							text = (isPrint ? string.Concat(new string[]
							{
								"温度が(C)",
								NetworkWindow.Instance.Programs.ClientVariableNames[this.BlockLoopEnd.VariableIndexes[0]],
								"℃",
								ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE[(int)this.BlockLoopEnd.Select],
								"なら抜ける"
							}) : "温度が\u3000\u3000\u3000\u3000 ℃\u3000\u3000\u3000\u3000\u3000なら抜ける");
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.SOUND:
						text = (isPrint ? ("音が" + ProgramModule.BlockIf.SELECT_SOUND_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "音が\u3000\u3000 \u3000なら抜ける");
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.USBIN:
						text = (isPrint ? ("外部入力が" + ProgramModule.BlockIf.SELECT_USBIN_ITEMS[(int)this.BlockLoopEnd.Select] + "なら抜ける") : "外部入力が\u3000\u3000 \u3000なら抜ける");
						break;
					}
				}
				return text;
			}

			// Token: 0x06000F03 RID: 3843 RVA: 0x00087150 File Offset: 0x00085350
			public override int getUsedMemory()
			{
				int num = 3;
				if (this.BlockLoopEnd != null)
				{
					num += this.BlockLoopEnd.getUsedMemory();
				}
				return num;
			}

			// Token: 0x06000F04 RID: 3844 RVA: 0x00087178 File Offset: 0x00085378
			public override void updateData()
			{
				((ComboBox)base.Controls[5]).Items.Clear();
				foreach (string text in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					((ComboBox)base.Controls[5]).Items.Add("(C)" + text);
				}
				((ComboBox)base.Controls[6]).Items.Clear();
				((ComboBox)base.Controls[6]).Items.Add("入力変数");
				foreach (string text2 in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					((ComboBox)base.Controls[6]).Items.Add("(C)" + text2);
				}
			}

			// Token: 0x06000F05 RID: 3845 RVA: 0x000872B8 File Offset: 0x000854B8
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_010.Width;
					int num = base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
					base.Controls[0].Location = new Point(x, num);
					num += base.SizeBlock.Height - ProgramModule.Block.LINE_HEIGHT;
					if (this._blockLoopEnd.IsCondition)
					{
						switch (this._blockLoopEnd.Condition)
						{
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.BUTTON:
							x += TextRenderer.MeasureText("ボタンが", ProgramModule.Block._fontBlock).Width;
							base.Controls[1].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT:
							x += TextRenderer.MeasureText("周囲が", ProgramModule.Block._fontBlock).Width;
							base.Controls[3].Location = new Point(x, num);
							base.Controls[14].Location = new Point(x, num);
							base.Controls[5].Location = new Point(x, num);
							if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								x += base.Controls[14].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							}
							else
							{
								x += base.Controls[5].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							}
							base.Controls[4].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.SOUND:
							x += TextRenderer.MeasureText("音が", ProgramModule.Block._fontBlock).Width;
							base.Controls[2].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.ALARM:
							x += TextRenderer.MeasureText("アラーム入力が", ProgramModule.Block._fontBlock).Width;
							base.Controls[7].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIMER:
							x += TextRenderer.MeasureText("タイマー入力が", ProgramModule.Block._fontBlock).Width;
							base.Controls[8].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIME:
							x += TextRenderer.MeasureText("時刻が", ProgramModule.Block._fontBlock).Width;
							base.Controls[15].Location = new Point(x, num);
							x += base.Controls[15].Width + TextRenderer.MeasureText(":", ProgramModule.Block._fontBlock).Width;
							base.Controls[16].Location = new Point(x, num);
							x += base.Controls[16].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							base.Controls[9].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE:
							x += TextRenderer.MeasureText("温度が", ProgramModule.Block._fontBlock).Width;
							base.Controls[18].Location = new Point(x, num);
							base.Controls[5].Location = new Point(x, num);
							if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								x += base.Controls[18].Width;
							}
							else
							{
								x += base.Controls[5].Width;
							}
							x += TextRenderer.MeasureText("℃", ProgramModule.Block._fontBlock).Width;
							base.Controls[11].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.COUNTER:
							x += TextRenderer.MeasureText("秒カウンタが", ProgramModule.Block._fontBlock).Width;
							base.Controls[17].Location = new Point(x, num);
							x += base.Controls[17].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							base.Controls[10].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE:
							base.Controls[5].Location = new Point(x, num);
							x += base.Controls[5].Width + TextRenderer.MeasureText("が", ProgramModule.Block._fontBlock).Width;
							base.Controls[19].Location = new Point(x, num);
							base.Controls[6].Location = new Point(x, num);
							if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								x += base.Controls[19].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							}
							else
							{
								x += base.Controls[6].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							}
							base.Controls[12].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX:
							x += TextRenderer.MeasureText("外部入力が", ProgramModule.Block._fontBlock).Width;
							base.Controls[13].Location = new Point(x, num);
							return;
						default:
							return;
						}
					}
					else if (this._blockLoopEnd.IsConditionNetwork)
					{
						switch (this._blockLoopEnd.ConditionNetwork)
						{
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.OBJECT_BUTTON:
							base.Controls[1].Location = new Point(x, num);
							x += base.Controls[1].Width + TextRenderer.MeasureText("が", ProgramModule.Block._fontBlock).Width;
							base.Controls[2].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE:
							base.Controls[3].Location = new Point(x, num);
							x += base.Controls[3].Width + TextRenderer.MeasureText("が", ProgramModule.Block._fontBlock).Width;
							if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								base.Controls[12].Location = new Point(x, num);
								x += base.Controls[12].Width;
							}
							else if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								base.Controls[4].Location = new Point(x, num);
								x += base.Controls[4].Width;
							}
							else
							{
								base.Controls[15].Location = new Point(x, num);
								x += base.Controls[15].Width;
							}
							x += ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
							base.Controls[5].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.BUTTON:
							x += TextRenderer.MeasureText("コロックルのボタンが", ProgramModule.Block._fontBlock).Width;
							base.Controls[6].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.LIGHT:
							x += TextRenderer.MeasureText("周囲が", ProgramModule.Block._fontBlock).Width;
							if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								base.Controls[14].Location = new Point(x, num);
								x += base.Controls[14].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
								base.Controls[9].Location = new Point(x, num);
								return;
							}
							if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								base.Controls[3].Location = new Point(x, num);
								x += base.Controls[3].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET;
								base.Controls[9].Location = new Point(x, num);
								return;
							}
							base.Controls[8].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.TEMPERATURE:
							x += TextRenderer.MeasureText("温度が", ProgramModule.Block._fontBlock).Width;
							if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
							{
								base.Controls[13].Location = new Point(x, num);
								x += base.Controls[13].Width;
							}
							else
							{
								base.Controls[3].Location = new Point(x, num);
								x += base.Controls[3].Width;
							}
							x += TextRenderer.MeasureText("度", ProgramModule.Block._fontBlock).Width;
							base.Controls[7].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.SOUND:
							x += TextRenderer.MeasureText("音が", ProgramModule.Block._fontBlock).Width;
							base.Controls[10].Location = new Point(x, num);
							return;
						case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.USBIN:
							x += TextRenderer.MeasureText("外部入力が", ProgramModule.Block._fontBlock).Width;
							base.Controls[11].Location = new Point(x, num);
							break;
						default:
							return;
						}
					}
				}
			}

			// Token: 0x06000F06 RID: 3846 RVA: 0x00087BE0 File Offset: 0x00085DE0
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				NumericUpDown numericUpDown = new NumericUpDown();
				numericUpDown.Width = 35;
				numericUpDown.Minimum = 1m;
				numericUpDown.Maximum = 255m;
				base.Controls.Add(numericUpDown);
				if (NetworkWindow.Instance == null)
				{
					ComboBox comboBox = new ComboBox();
					comboBox.Width = 50;
					foreach (string text in ProgramModule.BlockIf.SELECT_BUTTON_ITEMS)
					{
						comboBox.Items.Add(text);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 50;
					foreach (string text2 in ProgramModule.BlockIf.SELECT_SOUND_ITEMS)
					{
						comboBox.Items.Add(text2);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 60;
					foreach (string text3 in ProgramModule.BlockIf.SELECT_LIGHT2_ITEMS)
					{
						comboBox.Items.Add(text3);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 80;
					foreach (string text4 in ProgramModule.BlockIf.LIGHT_ITEMS)
					{
						comboBox.Items.Add(text4);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 60;
					foreach (string text5 in ProgramModule.BlockIf.VARIABLE_ITEMS)
					{
						comboBox.Items.Add(text5);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 60;
					foreach (string text6 in ProgramModule.BlockIf.VARIABLE_ITEMS)
					{
						comboBox.Items.Add(text6);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 50;
					foreach (string text7 in ProgramModule.BlockIf.SELECT_ALARM_ITEMS)
					{
						comboBox.Items.Add(text7);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 50;
					foreach (string text8 in ProgramModule.BlockIf.SELECT_TIMER_ITEMS)
					{
						comboBox.Items.Add(text8);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 80;
					foreach (string text9 in ProgramModule.BlockIf.SELECT_TIME_ITEMS)
					{
						comboBox.Items.Add(text9);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 80;
					foreach (string text10 in ProgramModule.BlockIf.SELECT_COUNTER_ITEMS)
					{
						comboBox.Items.Add(text10);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 80;
					foreach (string text11 in ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE)
					{
						comboBox.Items.Add(text11);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 80;
					foreach (string text12 in ProgramModule.BlockIf.COMPARE_ITEMS)
					{
						comboBox.Items.Add(text12);
					}
					base.Controls.Add(comboBox);
					comboBox = new ComboBox();
					comboBox.Width = 50;
					foreach (string text13 in ProgramModule.BlockIf.SELECT_USBIN_ITEMS)
					{
						comboBox.Items.Add(text13);
					}
					base.Controls.Add(comboBox);
					numericUpDown = new NumericUpDown();
					numericUpDown.Width = 35;
					numericUpDown.Minimum = 0m;
					numericUpDown.Maximum = 100m;
					base.Controls.Add(numericUpDown);
					numericUpDown = new NumericUpDown();
					numericUpDown.Width = 35;
					numericUpDown.Minimum = 0m;
					numericUpDown.Maximum = 23m;
					base.Controls.Add(numericUpDown);
					numericUpDown = new NumericUpDown();
					numericUpDown.Width = 35;
					numericUpDown.Minimum = 0m;
					numericUpDown.Maximum = 59m;
					base.Controls.Add(numericUpDown);
					numericUpDown = new NumericUpDown();
					numericUpDown.Width = 50;
					numericUpDown.Minimum = 0m;
					numericUpDown.Maximum = 255m;
					base.Controls.Add(numericUpDown);
					numericUpDown = new NumericUpDown();
					numericUpDown.Width = 50;
					numericUpDown.Minimum = -10m;
					numericUpDown.Maximum = 50m;
					base.Controls.Add(numericUpDown);
					numericUpDown = new NumericUpDown();
					numericUpDown.Width = 50;
					numericUpDown.Minimum = -128m;
					numericUpDown.Maximum = 127m;
					base.Controls.Add(numericUpDown);
				}
				else
				{
					ComboBox comboBox2 = new ComboBox();
					comboBox2.Width = 80;
					foreach (NetworkProgramModules.ObjectInfo objectInfo in NetworkWindow.Instance.Programs.getObjects(NetworkProgramModules.OBJECT_TYPE.BUTTON))
					{
						comboBox2.Items.Add(objectInfo.getObjectName());
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 50;
					foreach (string text14 in ProgramModule.BlockIf.SELECT_BUTTON_ITEMS)
					{
						comboBox2.Items.Add(text14);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 80;
					foreach (string text15 in NetworkWindow.Instance.Programs.ClientVariableNames)
					{
						comboBox2.Items.Add("(C)" + text15);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 80;
					comboBox2.Items.Add("入力変数");
					foreach (string text16 in NetworkWindow.Instance.Programs.ClientVariableNames)
					{
						comboBox2.Items.Add("(C)" + text16);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 80;
					foreach (string text17 in ProgramModule.BlockIf.COMPARE_ITEMS)
					{
						comboBox2.Items.Add(text17);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 50;
					foreach (string text18 in ProgramModule.BlockIf.SELECT_BUTTON_ITEMS)
					{
						comboBox2.Items.Add(text18);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 80;
					foreach (string text19 in ProgramModule.BlockIf.COMPARE_ITEMS_TEMPERATURE)
					{
						comboBox2.Items.Add(text19);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 60;
					foreach (string text20 in ProgramModule.BlockIf.SELECT_LIGHT2_ITEMS)
					{
						comboBox2.Items.Add(text20);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 80;
					foreach (string text21 in ProgramModule.BlockIf.LIGHT_ITEMS)
					{
						comboBox2.Items.Add(text21);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 60;
					foreach (string text22 in ProgramModule.BlockIf.SELECT_SOUND_ITEMS)
					{
						comboBox2.Items.Add(text22);
					}
					base.Controls.Add(comboBox2);
					comboBox2 = new ComboBox();
					comboBox2.Width = 50;
					foreach (string text23 in ProgramModule.BlockIf.SELECT_USBIN_ITEMS)
					{
						comboBox2.Items.Add(text23);
					}
					base.Controls.Add(comboBox2);
					numericUpDown = new NumericUpDown();
					numericUpDown.Width = 50;
					numericUpDown.Minimum = -32768m;
					numericUpDown.Maximum = 32767m;
					base.Controls.Add(numericUpDown);
					numericUpDown = new NumericUpDown();
					numericUpDown.Width = 50;
					numericUpDown.Minimum = -10m;
					numericUpDown.Maximum = 50m;
					base.Controls.Add(numericUpDown);
					numericUpDown = new NumericUpDown();
					numericUpDown.Width = 50;
					numericUpDown.Minimum = 0m;
					numericUpDown.Maximum = 100m;
					base.Controls.Add(numericUpDown);
					TextBox textBox = new TextBox();
					base.Controls.Add(textBox);
				}
				this.updateBlock();
				((NumericUpDown)base.Controls[0]).ValueChanged += this.numericUpDownLoopCount_ValueChanged;
				if (NetworkWindow.Instance == null)
				{
					((ComboBox)base.Controls[1]).SelectedValueChanged += this.comboBoxButton_SelectedValueChanged;
					((ComboBox)base.Controls[2]).SelectedValueChanged += this.comboBoxSound_SelectedValueChanged;
					((ComboBox)base.Controls[3]).SelectedValueChanged += this.comboBoxLight2_SelectedValueChanged;
					((ComboBox)base.Controls[4]).SelectedValueChanged += this.comboBoxLight3_SelectedValueChanged;
					((ComboBox)base.Controls[5]).SelectedValueChanged += this.comboBoxVariable_SelectedValueChanged;
					((ComboBox)base.Controls[6]).SelectedValueChanged += this.comboBoxVariable2_SelectedValueChanged;
					((ComboBox)base.Controls[7]).SelectedValueChanged += this.comboBoxAlarm_SelectedValueChanged;
					((ComboBox)base.Controls[8]).SelectedValueChanged += this.comboBoxTimer_SelectedValueChanged;
					((ComboBox)base.Controls[9]).SelectedValueChanged += this.comboBoxTime_SelectedValueChanged;
					((ComboBox)base.Controls[10]).SelectedValueChanged += this.comboBoxCounter_SelectedValueChanged;
					((ComboBox)base.Controls[11]).SelectedValueChanged += this.comboBoxTemperature_SelectedValueChanged;
					((ComboBox)base.Controls[12]).SelectedValueChanged += this.comboBoxVariableCompare_SelectedValueChanged;
					((ComboBox)base.Controls[13]).SelectedValueChanged += this.comboBoxUsbIn_SelectedValueChanged;
					((NumericUpDown)base.Controls[14]).ValueChanged += this.numericUpDownLight_ValueChanged;
					((NumericUpDown)base.Controls[15]).ValueChanged += this.numericUpDownHour_ValueChanged;
					((NumericUpDown)base.Controls[16]).ValueChanged += this.numericUpDownMinute_ValueChanged;
					((NumericUpDown)base.Controls[17]).ValueChanged += this.numericUpDownCounter_ValueChanged;
					((NumericUpDown)base.Controls[18]).ValueChanged += this.numericUpDownTemperature_ValueChanged;
					((NumericUpDown)base.Controls[19]).ValueChanged += this.numericUpDownVariable_ValueChanged;
					return;
				}
				((ComboBox)base.Controls[1]).SelectedValueChanged += this.comboBoxNetworkObjectButtonIndex_SelectedValueChanged;
				((ComboBox)base.Controls[2]).SelectedValueChanged += this.comboBoxNetworkObjectButton_SelectedValueChanged;
				((ComboBox)base.Controls[3]).SelectedValueChanged += this.comboBoxNetworkVariable_SelectedValueChanged;
				((ComboBox)base.Controls[4]).SelectedValueChanged += this.comboBoxNetworkVariable2_SelectedValueChanged;
				((ComboBox)base.Controls[5]).SelectedValueChanged += this.comboBoxNetworkData_SelectedValueChanged;
				((ComboBox)base.Controls[6]).SelectedValueChanged += this.comboBoxNetworkButton_SelectedValueChanged;
				((ComboBox)base.Controls[7]).SelectedValueChanged += this.comboBoxNetworkTemperature_SelectedValueChanged;
				((ComboBox)base.Controls[8]).SelectedValueChanged += this.comboBoxNetworkLight2_SelectedValueChanged;
				((ComboBox)base.Controls[9]).SelectedValueChanged += this.comboBoxNetworkLight3_SelectedValueChanged;
				((ComboBox)base.Controls[10]).SelectedValueChanged += this.comboBoxNetworkSound_SelectedValueChanged;
				((ComboBox)base.Controls[11]).SelectedValueChanged += this.comboBoxNetworkUsbIn_SelectedValueChanged;
				((NumericUpDown)base.Controls[12]).ValueChanged += this.numericUpDownNetworkData_ValueChanged;
				((NumericUpDown)base.Controls[13]).ValueChanged += this.numericUpDownNetworkTemperature_ValueChanged;
				((NumericUpDown)base.Controls[14]).ValueChanged += this.numericUpDownNetworkLight_ValueChanged;
				((TextBox)base.Controls[15]).TextChanged += this.textBoxNetworkData_TextChanged;
			}

			// Token: 0x06000F07 RID: 3847 RVA: 0x000889E8 File Offset: 0x00086BE8
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					if (this._count > 0)
					{
						((NumericUpDown)base.Controls[0]).Value = this._count;
					}
					if (this.BlockLoopEnd != null)
					{
						int num = Math.Max(TextRenderer.MeasureText(this.getDetailBlock(false), ProgramModule.Block._fontBlock).Width, TextRenderer.MeasureText(this.getDetailBlockLoopEnd(false), ProgramModule.Block._fontBlock).Width);
						base.SizeBlock = new Size(Math.Max(ProgramModule.Block.BLOCK_SIZE.Width, Resources.bp_block_010.Width + num + Resources.bp_block_012.Width), ProgramModule.Block.LINE_HEIGHT * base.LineCount);
						if (this._blockLoopEnd.IsCondition)
						{
							switch (this._blockLoopEnd.Condition)
							{
							case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.BUTTON:
								((ComboBox)base.Controls[1]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT:
								if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
								{
									((ComboBox)base.Controls[4]).SelectedIndex = (int)this._blockLoopEnd.Select;
									((NumericUpDown)base.Controls[14]).Value = this._blockLoopEnd.Values[0];
									return;
								}
								if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
								{
									((ComboBox)base.Controls[4]).SelectedIndex = (int)this._blockLoopEnd.Select;
									((ComboBox)base.Controls[5]).SelectedIndex = this._blockLoopEnd.VariableIndexes[0];
									return;
								}
								((ComboBox)base.Controls[3]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.SOUND:
								((ComboBox)base.Controls[2]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.ALARM:
								((ComboBox)base.Controls[7]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIMER:
								((ComboBox)base.Controls[8]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIME:
								((NumericUpDown)base.Controls[15]).Value = this._blockLoopEnd.Values[0];
								((NumericUpDown)base.Controls[16]).Value = this._blockLoopEnd.Values[1];
								((ComboBox)base.Controls[9]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE:
								((NumericUpDown)base.Controls[18]).Value = this._blockLoopEnd.Values[0];
								((ComboBox)base.Controls[5]).SelectedIndex = this._blockLoopEnd.VariableIndexes[0];
								((ComboBox)base.Controls[11]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.COUNTER:
								((NumericUpDown)base.Controls[17]).Value = this._blockLoopEnd.Values[0];
								((ComboBox)base.Controls[10]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE:
								((NumericUpDown)base.Controls[19]).Value = this._blockLoopEnd.Values[0];
								((ComboBox)base.Controls[5]).SelectedIndex = this._blockLoopEnd.VariableIndexes[0];
								((ComboBox)base.Controls[6]).SelectedIndex = this._blockLoopEnd.VariableIndexes[1];
								((ComboBox)base.Controls[12]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX:
								((ComboBox)base.Controls[13]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							default:
								return;
							}
						}
						else if (this._blockLoopEnd.IsConditionNetwork)
						{
							switch (this._blockLoopEnd.ConditionNetwork)
							{
							case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.OBJECT_BUTTON:
								((ComboBox)base.Controls[1]).SelectedIndex = ((ComboBox)base.Controls[1]).Items.IndexOf(this._blockLoopEnd.ObjectName);
								((ComboBox)base.Controls[2]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE:
								((ComboBox)base.Controls[3]).SelectedIndex = this._blockLoopEnd.VariableIndexes[0];
								((ComboBox)base.Controls[4]).SelectedIndex = this._blockLoopEnd.VariableIndexes[1];
								((ComboBox)base.Controls[5]).SelectedIndex = (int)this._blockLoopEnd.Select;
								((NumericUpDown)base.Controls[12]).Value = this._blockLoopEnd.Values[0];
								((TextBox)base.Controls[15]).Text = this._blockLoopEnd.ConstString;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.BUTTON:
								((ComboBox)base.Controls[6]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.LIGHT:
								if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
								{
									((ComboBox)base.Controls[9]).SelectedIndex = (int)this._blockLoopEnd.Select;
									((NumericUpDown)base.Controls[14]).Value = this._blockLoopEnd.Values[0];
									return;
								}
								if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
								{
									((ComboBox)base.Controls[9]).SelectedIndex = (int)this._blockLoopEnd.Select;
									((ComboBox)base.Controls[3]).SelectedIndex = this._blockLoopEnd.VariableIndexes[0];
									return;
								}
								((ComboBox)base.Controls[8]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.TEMPERATURE:
								((ComboBox)base.Controls[7]).SelectedIndex = (int)this._blockLoopEnd.Select;
								if (this._blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
								{
									((NumericUpDown)base.Controls[13]).Value = this._blockLoopEnd.Values[0];
									return;
								}
								((ComboBox)base.Controls[3]).SelectedIndex = this._blockLoopEnd.VariableIndexes[0];
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.SOUND:
								((ComboBox)base.Controls[10]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.USBIN:
								((ComboBox)base.Controls[11]).SelectedIndex = (int)this._blockLoopEnd.Select;
								return;
							default:
								return;
							}
						}
					}
				}
				else if (this.BlockLoopEnd != null)
				{
					int num2 = Math.Max(TextRenderer.MeasureText(this.getDetailBlock(true), ProgramModule.Block._fontBlock).Width, TextRenderer.MeasureText(this.getDetailBlockLoopEnd(false), ProgramModule.Block._fontBlock).Width);
					base.SizeBlock = new Size(Math.Max(ProgramModule.Block.BLOCK_SIZE.Width, Resources.bp_block_010.Width + num2 + Resources.bp_block_012.Width), ProgramModule.Block.LINE_HEIGHT * base.LineCount);
				}
			}

			// Token: 0x06000F08 RID: 3848 RVA: 0x000891C0 File Offset: 0x000873C0
			public override void updateControlVisible(List<Rectangle> rects)
			{
				base.updateControlVisible(rects);
				if (this._count == 0)
				{
					base.Controls[0].Visible = false;
				}
				if (this._blockLoopEnd.IsCondition)
				{
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.BUTTON)
					{
						base.Controls[1].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.SOUND)
					{
						base.Controls[2].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						base.Controls[14].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID)
					{
						base.Controls[3].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT || (this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST && this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX))
					{
						base.Controls[4].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.ALARM)
					{
						base.Controls[7].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIMER)
					{
						base.Controls[8].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIME)
					{
						base.Controls[9].Visible = false;
						base.Controls[15].Visible = false;
						base.Controls[16].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.COUNTER)
					{
						base.Controls[10].Visible = false;
						base.Controls[17].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE)
					{
						base.Controls[11].Visible = false;
						base.Controls[18].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE)
					{
						base.Controls[12].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						base.Controls[19].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
					{
						base.Controls[6].Visible = false;
					}
					if ((this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX) && (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX) && this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE)
					{
						base.Controls[5].Visible = false;
					}
					if (this._blockLoopEnd.Condition != ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX)
					{
						base.Controls[13].Visible = false;
						return;
					}
				}
				else if (this._blockLoopEnd.IsConditionNetwork)
				{
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.OBJECT_BUTTON)
					{
						base.Controls[1].Visible = false;
						base.Controls[2].Visible = false;
					}
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						base.Controls[12].Visible = false;
					}
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
					{
						base.Controls[4].Visible = false;
					}
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST_STRING)
					{
						base.Controls[15].Visible = false;
					}
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE)
					{
						base.Controls[5].Visible = false;
					}
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.BUTTON)
					{
						base.Controls[6].Visible = false;
					}
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.TEMPERATURE)
					{
						base.Controls[7].Visible = false;
					}
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.TEMPERATURE || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						base.Controls[13].Visible = false;
					}
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.LIGHT || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						base.Controls[14].Visible = false;
					}
					if ((this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.LIGHT || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST) && (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.LIGHT || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX))
					{
						base.Controls[9].Visible = false;
					}
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.LIGHT || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID)
					{
						base.Controls[8].Visible = false;
					}
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.SOUND)
					{
						base.Controls[10].Visible = false;
					}
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE && (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.TEMPERATURE || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX) && (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.LIGHT || this._blockLoopEnd.Variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX))
					{
						base.Controls[3].Visible = false;
					}
					if (this._blockLoopEnd.ConditionNetwork != ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.USBIN)
					{
						base.Controls[11].Visible = false;
						return;
					}
				}
				else
				{
					for (int i = 1; i < base.Controls.Count; i++)
					{
						base.Controls[i].Visible = false;
					}
				}
			}

			// Token: 0x06000F09 RID: 3849 RVA: 0x00089784 File Offset: 0x00087984
			public void updateLevel()
			{
				if (base.Controls.Count > 0)
				{
					bool flag = NetworkWindow.Instance.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || this._blockLoopEnd.ConditionNetwork == ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.OBJECT_BUTTON || this._blockLoopEnd.ConditionNetwork == ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE;
					base.Controls[3].Enabled = flag;
					base.Controls[5].Enabled = flag;
					base.Controls[6].Enabled = flag;
					base.Controls[7].Enabled = flag;
					base.Controls[8].Enabled = flag;
					base.Controls[9].Enabled = flag;
					base.Controls[10].Enabled = flag;
					base.Controls[12].Enabled = flag;
					base.Controls[13].Enabled = flag;
					base.Controls[14].Enabled = flag;
					base.Controls[15].Enabled = flag;
				}
			}

			// Token: 0x06000F0A RID: 3850 RVA: 0x000898A0 File Offset: 0x00087AA0
			public void updateUsbInOutEnable(bool enable)
			{
				if (base.Controls.Count > 0)
				{
					if (this._blockLoopEnd.IsCondition)
					{
						base.Controls[13].Enabled = enable;
						return;
					}
					if (this._blockLoopEnd.IsConditionNetwork)
					{
						base.Controls[11].Enabled = enable;
					}
				}
			}

			// Token: 0x06000F0B RID: 3851 RVA: 0x000898FC File Offset: 0x00087AFC
			private void numericUpDownLoopCount_ValueChanged(object sender, EventArgs e)
			{
				this.Count = (int)((NumericUpDown)base.Controls[0]).Value;
				base.addHistory();
			}

			// Token: 0x06000F0C RID: 3852 RVA: 0x00089925 File Offset: 0x00087B25
			private void comboBoxButton_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[1]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F0D RID: 3853 RVA: 0x00089953 File Offset: 0x00087B53
			private void comboBoxSound_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[2]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F0E RID: 3854 RVA: 0x00089981 File Offset: 0x00087B81
			private void comboBoxLight2_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[3]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F0F RID: 3855 RVA: 0x000899AF File Offset: 0x00087BAF
			private void comboBoxLight3_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[4]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F10 RID: 3856 RVA: 0x000899E0 File Offset: 0x00087BE0
			private void comboBoxVariable_SelectedValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.VariableIndexes[0] != ((ComboBox)base.Controls[5]).SelectedIndex)
				{
					this._blockLoopEnd.VariableIndexes[0] = ((ComboBox)base.Controls[5]).SelectedIndex;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F11 RID: 3857 RVA: 0x00089A4C File Offset: 0x00087C4C
			private void comboBoxVariable2_SelectedValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.VariableIndexes[1] != ((ComboBox)base.Controls[6]).SelectedIndex)
				{
					this._blockLoopEnd.VariableIndexes[1] = ((ComboBox)base.Controls[6]).SelectedIndex;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F12 RID: 3858 RVA: 0x00089AB8 File Offset: 0x00087CB8
			private void comboBoxAlarm_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[7]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F13 RID: 3859 RVA: 0x00089AE6 File Offset: 0x00087CE6
			private void comboBoxTimer_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[8]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F14 RID: 3860 RVA: 0x00089B14 File Offset: 0x00087D14
			private void comboBoxTime_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[9]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F15 RID: 3861 RVA: 0x00089B43 File Offset: 0x00087D43
			private void comboBoxCounter_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[10]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F16 RID: 3862 RVA: 0x00089B72 File Offset: 0x00087D72
			private void comboBoxTemperature_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[11]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F17 RID: 3863 RVA: 0x00089BA1 File Offset: 0x00087DA1
			private void comboBoxVariableCompare_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[12]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F18 RID: 3864 RVA: 0x00089BD0 File Offset: 0x00087DD0
			private void comboBoxUsbIn_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[13]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F19 RID: 3865 RVA: 0x00089C00 File Offset: 0x00087E00
			private void numericUpDownLight_ValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.Values[0] != (int)((NumericUpDown)base.Controls[14]).Value)
				{
					this._blockLoopEnd.Values[0] = (int)((NumericUpDown)base.Controls[14]).Value;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F1A RID: 3866 RVA: 0x00089C78 File Offset: 0x00087E78
			private void numericUpDownHour_ValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.Values[0] != (int)((NumericUpDown)base.Controls[15]).Value)
				{
					this._blockLoopEnd.Values[0] = (int)((NumericUpDown)base.Controls[15]).Value;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F1B RID: 3867 RVA: 0x00089CF0 File Offset: 0x00087EF0
			private void numericUpDownMinute_ValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.Values[1] != (int)((NumericUpDown)base.Controls[16]).Value)
				{
					this._blockLoopEnd.Values[1] = (int)((NumericUpDown)base.Controls[16]).Value;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F1C RID: 3868 RVA: 0x00089D68 File Offset: 0x00087F68
			private void numericUpDownCounter_ValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.Values[0] != (int)((NumericUpDown)base.Controls[17]).Value)
				{
					this._blockLoopEnd.Values[0] = (int)((NumericUpDown)base.Controls[17]).Value;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F1D RID: 3869 RVA: 0x00089DE0 File Offset: 0x00087FE0
			private void numericUpDownTemperature_ValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.Values[0] != (int)((NumericUpDown)base.Controls[18]).Value)
				{
					this._blockLoopEnd.Values[0] = (int)((NumericUpDown)base.Controls[18]).Value;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F1E RID: 3870 RVA: 0x00089E58 File Offset: 0x00088058
			private void numericUpDownVariable_ValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.Values[0] != (int)((NumericUpDown)base.Controls[19]).Value)
				{
					this._blockLoopEnd.Values[0] = (int)((NumericUpDown)base.Controls[19]).Value;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F1F RID: 3871 RVA: 0x00089ED0 File Offset: 0x000880D0
			private void comboBoxNetworkObjectButtonIndex_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.ObjectName = ((ComboBox)base.Controls[1]).SelectedItem.ToString();
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F20 RID: 3872 RVA: 0x00089953 File Offset: 0x00087B53
			private void comboBoxNetworkObjectButton_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[2]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F21 RID: 3873 RVA: 0x00089F04 File Offset: 0x00088104
			private void comboBoxNetworkVariable_SelectedValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.VariableIndexes[0] != ((ComboBox)base.Controls[3]).SelectedIndex)
				{
					this._blockLoopEnd.VariableIndexes[0] = ((ComboBox)base.Controls[3]).SelectedIndex;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F22 RID: 3874 RVA: 0x00089F70 File Offset: 0x00088170
			private void comboBoxNetworkVariable2_SelectedValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.VariableIndexes[1] != ((ComboBox)base.Controls[4]).SelectedIndex)
				{
					this._blockLoopEnd.VariableIndexes[1] = ((ComboBox)base.Controls[4]).SelectedIndex;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F23 RID: 3875 RVA: 0x00089FDC File Offset: 0x000881DC
			private void comboBoxNetworkData_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[5]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F24 RID: 3876 RVA: 0x0008A00A File Offset: 0x0008820A
			private void comboBoxNetworkButton_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[6]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F25 RID: 3877 RVA: 0x00089AB8 File Offset: 0x00087CB8
			private void comboBoxNetworkTemperature_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[7]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F26 RID: 3878 RVA: 0x00089AE6 File Offset: 0x00087CE6
			private void comboBoxNetworkLight2_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[8]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F27 RID: 3879 RVA: 0x00089B14 File Offset: 0x00087D14
			private void comboBoxNetworkLight3_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[9]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F28 RID: 3880 RVA: 0x00089B43 File Offset: 0x00087D43
			private void comboBoxNetworkSound_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[10]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F29 RID: 3881 RVA: 0x00089B72 File Offset: 0x00087D72
			private void comboBoxNetworkUsbIn_SelectedValueChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.Select = (ProgramModule.BlockIf.SELECT)((ComboBox)base.Controls[11]).SelectedIndex;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x06000F2A RID: 3882 RVA: 0x0008A038 File Offset: 0x00088238
			private void numericUpDownNetworkData_ValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.Values[0] != (int)((NumericUpDown)base.Controls[12]).Value)
				{
					this._blockLoopEnd.Values[0] = (int)((NumericUpDown)base.Controls[12]).Value;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F2B RID: 3883 RVA: 0x0008A0B0 File Offset: 0x000882B0
			private void numericUpDownNetworkTemperature_ValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.Values[0] != (int)((NumericUpDown)base.Controls[13]).Value)
				{
					this._blockLoopEnd.Values[0] = (int)((NumericUpDown)base.Controls[13]).Value;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F2C RID: 3884 RVA: 0x0008A128 File Offset: 0x00088328
			private void numericUpDownNetworkLight_ValueChanged(object sender, EventArgs e)
			{
				if (this._blockLoopEnd.Values[0] != (int)((NumericUpDown)base.Controls[14]).Value)
				{
					this._blockLoopEnd.Values[0] = (int)((NumericUpDown)base.Controls[14]).Value;
					this._blockLoopEnd.Updated = true;
					this._blockLoopEnd.addHistory();
				}
			}

			// Token: 0x06000F2D RID: 3885 RVA: 0x0008A1A0 File Offset: 0x000883A0
			private void textBoxNetworkData_TextChanged(object sender, EventArgs e)
			{
				this._blockLoopEnd.ConstString = ((TextBox)base.Controls[15]).Text;
				this._blockLoopEnd.addHistory();
			}

			// Token: 0x0400079F RID: 1951
			public const int USE_MEMORY_MAX = 3;

			// Token: 0x040007A0 RID: 1952
			private int _count;

			// Token: 0x040007A1 RID: 1953
			private int _index;

			// Token: 0x040007A2 RID: 1954
			private ProgramModule.BlockLoopEnd _blockLoopEnd;

			// Token: 0x02000106 RID: 262
			private enum CONTROL
			{
				// Token: 0x04000A91 RID: 2705
				NUMERIC_LOOP_COUNT,
				// Token: 0x04000A92 RID: 2706
				COMBOBOX_BUTTON,
				// Token: 0x04000A93 RID: 2707
				COMBOBOX_SOUND,
				// Token: 0x04000A94 RID: 2708
				COMBOBOX_LIGHT2,
				// Token: 0x04000A95 RID: 2709
				COMBOBOX_LIGHT3,
				// Token: 0x04000A96 RID: 2710
				COMBOBOX_VARIABLE,
				// Token: 0x04000A97 RID: 2711
				COMBOBOX_VARIABLE2,
				// Token: 0x04000A98 RID: 2712
				COMBOBOX_ALARM,
				// Token: 0x04000A99 RID: 2713
				COMBOBOX_TIMER,
				// Token: 0x04000A9A RID: 2714
				COMBOBOX_TIME,
				// Token: 0x04000A9B RID: 2715
				COMBOBOX_COUNTER,
				// Token: 0x04000A9C RID: 2716
				COMBOBOX_TEMPERATURE,
				// Token: 0x04000A9D RID: 2717
				COMBOBOX_VARIABLE_COMPARE,
				// Token: 0x04000A9E RID: 2718
				COMBOBOX_USBIN,
				// Token: 0x04000A9F RID: 2719
				NUMERIC_LIGHT,
				// Token: 0x04000AA0 RID: 2720
				NUMERIC_HOUR,
				// Token: 0x04000AA1 RID: 2721
				NUMERIC_MINUTE,
				// Token: 0x04000AA2 RID: 2722
				NUMERIC_COUNTER,
				// Token: 0x04000AA3 RID: 2723
				NUMERIC_TEMPERATURE,
				// Token: 0x04000AA4 RID: 2724
				NUMERIC_VARIABLE,
				// Token: 0x04000AA5 RID: 2725
				MAX
			}

			// Token: 0x02000107 RID: 263
			private enum CONTROL_NETWORK
			{
				// Token: 0x04000AA7 RID: 2727
				NUMERIC_LOOP_COUNT,
				// Token: 0x04000AA8 RID: 2728
				COMBOBOX_OBJECT_BUTTON_INDEX,
				// Token: 0x04000AA9 RID: 2729
				COMBOBOX_OBJECT_BUTTON,
				// Token: 0x04000AAA RID: 2730
				COMBOBOX_VARIABLE,
				// Token: 0x04000AAB RID: 2731
				COMBOBOX_VARIABLE2,
				// Token: 0x04000AAC RID: 2732
				COMBOBOX_DATA,
				// Token: 0x04000AAD RID: 2733
				COMBOBOX_BUTTON,
				// Token: 0x04000AAE RID: 2734
				COMBOBOX_TEMPERATURE,
				// Token: 0x04000AAF RID: 2735
				COMBOBOX_LIGHT2,
				// Token: 0x04000AB0 RID: 2736
				COMBOBOX_LIGHT3,
				// Token: 0x04000AB1 RID: 2737
				COMBOBOX_SOUND,
				// Token: 0x04000AB2 RID: 2738
				COMBOBOX_USBIN,
				// Token: 0x04000AB3 RID: 2739
				NUMERIC_DATA,
				// Token: 0x04000AB4 RID: 2740
				NUMERIC_TEMPERATURE,
				// Token: 0x04000AB5 RID: 2741
				NUMERIC_LIGHT,
				// Token: 0x04000AB6 RID: 2742
				TEXTBOX_DATA,
				// Token: 0x04000AB7 RID: 2743
				MAX
			}
		}

		// Token: 0x0200007D RID: 125
		public class BlockMessage : ProgramModule.Block
		{
			// Token: 0x17000487 RID: 1159
			// (get) Token: 0x06000F2E RID: 3886 RVA: 0x0008A1CF File Offset: 0x000883CF
			// (set) Token: 0x06000F2F RID: 3887 RVA: 0x0008A1D7 File Offset: 0x000883D7
			public int MessageIndex
			{
				get
				{
					return this._messageIndex;
				}
				set
				{
					base.Updated |= this._messageIndex != value;
					this._messageIndex = value;
				}
			}

			// Token: 0x06000F30 RID: 3888 RVA: 0x0008A1FC File Offset: 0x000883FC
			public BlockMessage()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000F31 RID: 3889 RVA: 0x0008A26F File Offset: 0x0008846F
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.nw_block_010, base.Location);
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000F32 RID: 3890 RVA: 0x0008A2A8 File Offset: 0x000884A8
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_070, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_071, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_070.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_070.Width - Resources.bp_block_072.Width), (float)Resources.bp_block_071.Height));
					graphics.DrawImage(Resources.bp_block_072, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_072.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_070.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000F33 RID: 3891 RVA: 0x0008A471 File Offset: 0x00088671
			public override string getDetail()
			{
				return NetworkWindow.Instance.Programs.MessageNames[this.MessageIndex];
			}

			// Token: 0x06000F34 RID: 3892 RVA: 0x0008A48D File Offset: 0x0008868D
			public override string getDetailBlock(bool isPrint)
			{
				if (isPrint)
				{
					return NetworkWindow.Instance.Programs.MessageNames[this.MessageIndex] + "を送る";
				}
				return "\u3000\u3000\u3000\u3000を送る";
			}

			// Token: 0x06000F35 RID: 3893 RVA: 0x0008A4BC File Offset: 0x000886BC
			public override void updateData()
			{
				((ComboBox)base.Controls[0]).Items.Clear();
				foreach (string text in NetworkWindow.Instance.Programs.MessageNames)
				{
					((ComboBox)base.Controls[0]).Items.Add(text);
				}
			}

			// Token: 0x06000F36 RID: 3894 RVA: 0x0008A54C File Offset: 0x0008874C
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_002.Width;
					base.Controls[0].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
				}
			}

			// Token: 0x06000F37 RID: 3895 RVA: 0x0008A5A8 File Offset: 0x000887A8
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				ComboBox comboBox = new ComboBox();
				comboBox.Width = 80;
				foreach (string text in NetworkWindow.Instance.Programs.MessageNames)
				{
					comboBox.Items.Add(text);
				}
				base.Controls.Add(comboBox);
				this.updateBlock();
				((ComboBox)base.Controls[0]).SelectedValueChanged += this.comboBoxMessage_SelectedValueChanged;
			}

			// Token: 0x06000F38 RID: 3896 RVA: 0x0008A658 File Offset: 0x00088858
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					((ComboBox)base.Controls[0]).SelectedIndex = this._messageIndex;
				}
			}

			// Token: 0x06000F39 RID: 3897 RVA: 0x0008A68A File Offset: 0x0008888A
			private void comboBoxMessage_SelectedValueChanged(object sender, EventArgs e)
			{
				this.MessageIndex = ((ComboBox)base.Controls[0]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x040007A3 RID: 1955
			private int _messageIndex;

			// Token: 0x02000108 RID: 264
			private enum CONTROL
			{
				// Token: 0x04000AB9 RID: 2745
				COMBOBOX_MESSAGE,
				// Token: 0x04000ABA RID: 2746
				MAX
			}
		}

		// Token: 0x0200007E RID: 126
		public class BlockNetworkDisplay : ProgramModule.Block
		{
			// Token: 0x17000488 RID: 1160
			// (get) Token: 0x06000F3A RID: 3898 RVA: 0x0008A6AE File Offset: 0x000888AE
			// (set) Token: 0x06000F3B RID: 3899 RVA: 0x0008A6B6 File Offset: 0x000888B6
			public ProgramModule.BlockEvent.OBJECT_TYPE ObjectType
			{
				get
				{
					return this._objectType;
				}
				set
				{
					base.Updated |= this._objectType != value;
					this._objectType = value;
				}
			}

			// Token: 0x17000489 RID: 1161
			// (get) Token: 0x06000F3C RID: 3900 RVA: 0x0008A6D8 File Offset: 0x000888D8
			// (set) Token: 0x06000F3D RID: 3901 RVA: 0x0008A6E0 File Offset: 0x000888E0
			public string ObjectName
			{
				get
				{
					return this._objectName;
				}
				set
				{
					base.Updated |= this._objectName != value;
					this._objectName = value;
				}
			}

			// Token: 0x1700048A RID: 1162
			// (get) Token: 0x06000F3E RID: 3902 RVA: 0x0008A702 File Offset: 0x00088902
			// (set) Token: 0x06000F3F RID: 3903 RVA: 0x0008A70A File Offset: 0x0008890A
			public ProgramModule.BlockNetworkDisplay.VISIBLE Visible
			{
				get
				{
					return this._visible;
				}
				set
				{
					base.Updated |= this._visible != value;
					this._visible = value;
				}
			}

			// Token: 0x1700048B RID: 1163
			// (get) Token: 0x06000F40 RID: 3904 RVA: 0x0008A72C File Offset: 0x0008892C
			// (set) Token: 0x06000F41 RID: 3905 RVA: 0x0008A734 File Offset: 0x00088934
			public ProgramModule.BlockNetworkDisplay.VALUE_TYPE ValueType
			{
				get
				{
					return this._valueType;
				}
				set
				{
					base.Updated |= this._valueType != value;
					this._valueType = value;
				}
			}

			// Token: 0x1700048C RID: 1164
			// (get) Token: 0x06000F42 RID: 3906 RVA: 0x0008A756 File Offset: 0x00088956
			// (set) Token: 0x06000F43 RID: 3907 RVA: 0x0008A75E File Offset: 0x0008895E
			public int VariableIndex
			{
				get
				{
					return this._variableIndex;
				}
				set
				{
					base.Updated |= this._variableIndex != value;
					this._variableIndex = value;
				}
			}

			// Token: 0x1700048D RID: 1165
			// (get) Token: 0x06000F44 RID: 3908 RVA: 0x0008A780 File Offset: 0x00088980
			// (set) Token: 0x06000F45 RID: 3909 RVA: 0x0008A788 File Offset: 0x00088988
			public string ConstValue
			{
				get
				{
					return this._constValue;
				}
				set
				{
					base.Updated |= this._constValue != value;
					this._constValue = value;
				}
			}

			// Token: 0x06000F46 RID: 3910 RVA: 0x0008A7AC File Offset: 0x000889AC
			public BlockNetworkDisplay()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000F47 RID: 3911 RVA: 0x0008A82C File Offset: 0x00088A2C
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					switch (this.ObjectType)
					{
					case ProgramModule.BlockEvent.OBJECT_TYPE.LABEL:
						graphics.DrawImage(Resources.nw_block_120, base.Location);
						break;
					case ProgramModule.BlockEvent.OBJECT_TYPE.LIST:
						graphics.DrawImage(Resources.nw_block_130, base.Location);
						break;
					case ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON:
						graphics.DrawImage(Resources.nw_block_140, base.Location);
						break;
					case ProgramModule.BlockEvent.OBJECT_TYPE.INPUT:
						graphics.DrawImage(Resources.nw_block_150, base.Location);
						break;
					case ProgramModule.BlockEvent.OBJECT_TYPE.GRAPH:
						graphics.DrawImage(Resources.nw_block_120, base.Location);
						break;
					}
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000F48 RID: 3912 RVA: 0x0008A8E0 File Offset: 0x00088AE0
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_080, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_081, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_080.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_080.Width - Resources.bp_block_082.Width), (float)Resources.bp_block_081.Height));
					graphics.DrawImage(Resources.bp_block_082, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_082.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_080.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000F49 RID: 3913 RVA: 0x0008AAAC File Offset: 0x00088CAC
			public override string getDetail()
			{
				string text = "";
				ProgramModule.BlockNetworkDisplay.VISIBLE visible = this.Visible;
				if (visible != ProgramModule.BlockNetworkDisplay.VISIBLE.ON)
				{
					if (visible == ProgramModule.BlockNetworkDisplay.VISIBLE.OFF)
					{
						text = this.ObjectName + "の値を消す";
					}
				}
				else
				{
					string text2 = "";
					switch (this.ValueType)
					{
					case ProgramModule.BlockNetworkDisplay.VALUE_TYPE.INPUT:
						text2 = "入力変数";
						break;
					case ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CLIENT:
						text2 = "(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this.VariableIndex];
						break;
					case ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CONST:
						text2 = this.ConstValue;
						break;
					}
					text = this.ObjectName + "に\r\n" + text2 + "を表示";
				}
				return text;
			}

			// Token: 0x06000F4A RID: 3914 RVA: 0x0008AB54 File Offset: 0x00088D54
			public override string getDetailBlock(bool isPrint)
			{
				string text;
				if (this._objectType == ProgramModule.BlockEvent.OBJECT_TYPE.INPUT)
				{
					if (this._visible == ProgramModule.BlockNetworkDisplay.VISIBLE.ON)
					{
						if (this._valueType == ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CONST)
						{
							text = (isPrint ? ("入力バーに" + this._constValue + "を表示する") : "入力バーに\u3000\u3000\u3000\u3000 を表示する");
						}
						else
						{
							string text2 = ((this._valueType == ProgramModule.BlockNetworkDisplay.VALUE_TYPE.INPUT) ? "入力変数" : ("(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndex]));
							text = (isPrint ? ("入力バーに" + text2 + "を表示する") : "入力バーに\u3000\u3000\u3000\u3000 を表示する");
						}
					}
					else
					{
						text = "入力バーの値を消す";
					}
				}
				else if (this._visible == ProgramModule.BlockNetworkDisplay.VISIBLE.ON)
				{
					if (this._valueType == ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CONST)
					{
						if (this._objectName == null)
						{
							text = (isPrint ? ("に" + this._constValue + "を表示する") : "\u3000\u3000\u3000\u3000に\u3000\u3000\u3000\u3000 を表示する");
						}
						else
						{
							text = (isPrint ? (this._objectName + "に" + this._constValue + "を表示する") : "\u3000\u3000\u3000\u3000に\u3000\u3000\u3000\u3000 を表示する");
						}
					}
					else
					{
						string text3 = ((this._valueType == ProgramModule.BlockNetworkDisplay.VALUE_TYPE.INPUT) ? "入力変数" : ("(C)" + NetworkWindow.Instance.Programs.ClientVariableNames[this._variableIndex]));
						if (this._objectName == null)
						{
							text = (isPrint ? ("に" + text3 + "を表示する") : "\u3000\u3000\u3000\u3000に\u3000\u3000\u3000\u3000 を表示する");
						}
						else
						{
							text = (isPrint ? (this._objectName + "に" + text3 + "を表示する") : "\u3000\u3000\u3000\u3000に\u3000\u3000\u3000\u3000 を表示する");
						}
					}
				}
				else if (this._objectName == null)
				{
					text = (isPrint ? "の値を消す" : "\u3000\u3000\u3000\u3000の値を消す");
				}
				else
				{
					text = (isPrint ? (this._objectName + "の値を消す") : "\u3000\u3000\u3000\u3000の値を消す");
				}
				return text;
			}

			// Token: 0x06000F4B RID: 3915 RVA: 0x0008AD2C File Offset: 0x00088F2C
			public override void updateData()
			{
				((ComboBox)base.Controls[1]).Items.Clear();
				((ComboBox)base.Controls[1]).Items.Add("入力変数");
				foreach (string text in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					((ComboBox)base.Controls[1]).Items.Add("(C)" + text);
				}
			}

			// Token: 0x06000F4C RID: 3916 RVA: 0x0008ADE4 File Offset: 0x00088FE4
			public void updateObject()
			{
				List<NetworkProgramModules.ObjectInfo> list = null;
				switch (this._objectType)
				{
				case ProgramModule.BlockEvent.OBJECT_TYPE.LABEL:
					list = NetworkWindow.Instance.Programs.getObjects(NetworkProgramModules.OBJECT_TYPE.LABEL);
					break;
				case ProgramModule.BlockEvent.OBJECT_TYPE.LIST:
					list = NetworkWindow.Instance.Programs.getObjects(NetworkProgramModules.OBJECT_TYPE.LIST);
					break;
				case ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON:
					list = NetworkWindow.Instance.Programs.getObjects(NetworkProgramModules.OBJECT_TYPE.BUTTON);
					break;
				case ProgramModule.BlockEvent.OBJECT_TYPE.INPUT:
					list = NetworkWindow.Instance.Programs.getObjects(NetworkProgramModules.OBJECT_TYPE.INPUT);
					break;
				case ProgramModule.BlockEvent.OBJECT_TYPE.GRAPH:
					list = NetworkWindow.Instance.Programs.getObjects(NetworkProgramModules.OBJECT_TYPE.GRAPH);
					break;
				}
				if (base.Controls.Count > 0)
				{
					((ComboBox)base.Controls[0]).Items.Clear();
					foreach (NetworkProgramModules.ObjectInfo objectInfo in list)
					{
						((ComboBox)base.Controls[0]).Items.Add(objectInfo.getObjectName());
					}
					int num = ((ComboBox)base.Controls[0]).Items.IndexOf(this._objectName);
					((ComboBox)base.Controls[0]).SelectedIndex = num;
					if (num < 0)
					{
						this._objectName = "";
						((ComboBox)base.Controls[0]).Text = this._objectName;
						return;
					}
				}
				else if (list.Count > 0 && list.First((NetworkProgramModules.ObjectInfo a) => a.getObjectName() == this._objectName) == null)
				{
					this._objectName = "";
				}
			}

			// Token: 0x06000F4D RID: 3917 RVA: 0x0008AF8C File Offset: 0x0008918C
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_080.Width;
					if (this._objectType != ProgramModule.BlockEvent.OBJECT_TYPE.INPUT)
					{
						base.Controls[0].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					}
					x += base.Controls[0].Width + TextRenderer.MeasureText("に", ProgramModule.Block._fontBlock).Width;
					if (this._visible == ProgramModule.BlockNetworkDisplay.VISIBLE.ON)
					{
						if (this._valueType == ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CONST)
						{
							base.Controls[2].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
							return;
						}
						base.Controls[1].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					}
				}
			}

			// Token: 0x06000F4E RID: 3918 RVA: 0x0008B088 File Offset: 0x00089288
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				ComboBox comboBox = new ComboBox();
				comboBox.Width = 80;
				List<NetworkProgramModules.ObjectInfo> list = null;
				switch (this._objectType)
				{
				case ProgramModule.BlockEvent.OBJECT_TYPE.LABEL:
					list = NetworkWindow.Instance.Programs.getObjects(NetworkProgramModules.OBJECT_TYPE.LABEL);
					break;
				case ProgramModule.BlockEvent.OBJECT_TYPE.LIST:
					list = NetworkWindow.Instance.Programs.getObjects(NetworkProgramModules.OBJECT_TYPE.LIST);
					break;
				case ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON:
					list = NetworkWindow.Instance.Programs.getObjects(NetworkProgramModules.OBJECT_TYPE.BUTTON);
					break;
				case ProgramModule.BlockEvent.OBJECT_TYPE.INPUT:
					list = NetworkWindow.Instance.Programs.getObjects(NetworkProgramModules.OBJECT_TYPE.INPUT);
					break;
				case ProgramModule.BlockEvent.OBJECT_TYPE.GRAPH:
					list = NetworkWindow.Instance.Programs.getObjects(NetworkProgramModules.OBJECT_TYPE.GRAPH);
					break;
				}
				foreach (NetworkProgramModules.ObjectInfo objectInfo in list)
				{
					comboBox.Items.Add(objectInfo.getObjectName());
				}
				base.Controls.Add(comboBox);
				comboBox = new ComboBox();
				comboBox.Width = 80;
				comboBox.Items.Add("入力変数");
				foreach (string text in NetworkWindow.Instance.Programs.ClientVariableNames)
				{
					comboBox.Items.Add(text);
				}
				base.Controls.Add(comboBox);
				TextBox textBox = new TextBox();
				textBox.Width = 80;
				base.Controls.Add(textBox);
				this.updateBlock();
				((ComboBox)base.Controls[0]).SelectedValueChanged += this.comboBoxObject_SelectedValueChanged;
				((ComboBox)base.Controls[1]).SelectedValueChanged += this.comboBoxVariable_SelectedValueChanged;
				((TextBox)base.Controls[2]).TextChanged += this.textBoxConst_TextChanged;
			}

			// Token: 0x06000F4F RID: 3919 RVA: 0x0008B290 File Offset: 0x00089490
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					if (base.Controls[0].Visible)
					{
						((ComboBox)base.Controls[0]).SelectedIndex = ((ComboBox)base.Controls[0]).Items.IndexOf(this._objectName);
					}
					if (base.Controls[1].Visible)
					{
						((ComboBox)base.Controls[1]).SelectedIndex = BlockPropertyNetworkDisplayDialog.getComboBoxVariableIndex(this._valueType, this._variableIndex);
					}
					((TextBox)base.Controls[2]).Text = this.ConstValue;
				}
			}

			// Token: 0x06000F50 RID: 3920 RVA: 0x0008B354 File Offset: 0x00089554
			public override void updateControlVisible(List<Rectangle> rects)
			{
				base.updateControlVisible(rects);
				if (this._objectType == ProgramModule.BlockEvent.OBJECT_TYPE.INPUT)
				{
					base.Controls[0].Visible = false;
				}
				if (this._valueType != ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CONST || this._visible == ProgramModule.BlockNetworkDisplay.VISIBLE.OFF)
				{
					base.Controls[2].Visible = false;
				}
				if ((this._valueType != ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CLIENT && this._valueType != ProgramModule.BlockNetworkDisplay.VALUE_TYPE.INPUT) || this._visible == ProgramModule.BlockNetworkDisplay.VISIBLE.OFF)
				{
					base.Controls[1].Visible = false;
				}
			}

			// Token: 0x06000F51 RID: 3921 RVA: 0x0008B3D4 File Offset: 0x000895D4
			public void updateLevel()
			{
				if (base.Controls.Count > 0)
				{
					bool flag = NetworkWindow.Instance.Programs.Level >= NetworkProgramModules.LEVEL.LEVEL_2 || this.ObjectType == ProgramModule.BlockEvent.OBJECT_TYPE.LABEL || this.ObjectType == ProgramModule.BlockEvent.OBJECT_TYPE.LIST;
					base.Controls[0].Enabled = flag;
				}
			}

			// Token: 0x06000F52 RID: 3922 RVA: 0x0008B428 File Offset: 0x00089628
			private void comboBoxObject_SelectedValueChanged(object sender, EventArgs e)
			{
				this.ObjectName = ((ComboBox)base.Controls[0]).SelectedItem.ToString();
				base.addHistory();
			}

			// Token: 0x06000F53 RID: 3923 RVA: 0x0008B454 File Offset: 0x00089654
			private void comboBoxVariable_SelectedValueChanged(object sender, EventArgs e)
			{
				int selectedIndex = ((ComboBox)base.Controls[1]).SelectedIndex;
				if (this._valueType != ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CONST)
				{
					this.ValueType = BlockPropertyNetworkDisplayDialog.getValueType(selectedIndex);
					this.VariableIndex = BlockPropertyNetworkDisplayDialog.getVariableIndex(this._valueType, selectedIndex);
					base.addHistory();
				}
			}

			// Token: 0x06000F54 RID: 3924 RVA: 0x0008B4A5 File Offset: 0x000896A5
			private void textBoxConst_TextChanged(object sender, EventArgs e)
			{
				this.ConstValue = ((TextBox)base.Controls[2]).Text;
				base.addHistory();
			}

			// Token: 0x040007A4 RID: 1956
			private ProgramModule.BlockEvent.OBJECT_TYPE _objectType;

			// Token: 0x040007A5 RID: 1957
			private string _objectName = "";

			// Token: 0x040007A6 RID: 1958
			private ProgramModule.BlockNetworkDisplay.VISIBLE _visible;

			// Token: 0x040007A7 RID: 1959
			private ProgramModule.BlockNetworkDisplay.VALUE_TYPE _valueType;

			// Token: 0x040007A8 RID: 1960
			private int _variableIndex;

			// Token: 0x040007A9 RID: 1961
			private string _constValue;

			// Token: 0x02000109 RID: 265
			public enum VALUE_TYPE
			{
				// Token: 0x04000ABC RID: 2748
				INPUT,
				// Token: 0x04000ABD RID: 2749
				CLIENT,
				// Token: 0x04000ABE RID: 2750
				CONST,
				// Token: 0x04000ABF RID: 2751
				MAX
			}

			// Token: 0x0200010A RID: 266
			public enum VISIBLE
			{
				// Token: 0x04000AC1 RID: 2753
				ON,
				// Token: 0x04000AC2 RID: 2754
				OFF,
				// Token: 0x04000AC3 RID: 2755
				MAX
			}

			// Token: 0x0200010B RID: 267
			private enum CONTROL
			{
				// Token: 0x04000AC5 RID: 2757
				COMBOBOX_OBJECT,
				// Token: 0x04000AC6 RID: 2758
				COMBOBOX_VARIABLE,
				// Token: 0x04000AC7 RID: 2759
				TEXTBOX_VALUE,
				// Token: 0x04000AC8 RID: 2760
				MAX
			}
		}

		// Token: 0x0200007F RID: 127
		public class BlockNetworkSound : ProgramModule.Block
		{
			// Token: 0x1700048E RID: 1166
			// (get) Token: 0x06000F56 RID: 3926 RVA: 0x0008B4DC File Offset: 0x000896DC
			// (set) Token: 0x06000F57 RID: 3927 RVA: 0x0008B4E4 File Offset: 0x000896E4
			public int SoundIndex
			{
				get
				{
					return this._soundIndex;
				}
				set
				{
					base.Updated |= this._soundIndex != value;
					this._soundIndex = value;
				}
			}

			// Token: 0x1700048F RID: 1167
			// (get) Token: 0x06000F58 RID: 3928 RVA: 0x0008B506 File Offset: 0x00089706
			// (set) Token: 0x06000F59 RID: 3929 RVA: 0x0008B50E File Offset: 0x0008970E
			public int IsPlay
			{
				get
				{
					return this._isPlay;
				}
				set
				{
					base.Updated |= this._isPlay != value;
					this._isPlay = value;
				}
			}

			// Token: 0x17000490 RID: 1168
			// (get) Token: 0x06000F5A RID: 3930 RVA: 0x0008B530 File Offset: 0x00089730
			// (set) Token: 0x06000F5B RID: 3931 RVA: 0x0008B538 File Offset: 0x00089738
			public int IsLoop
			{
				get
				{
					return this._isLoop;
				}
				set
				{
					base.Updated |= this._isLoop != value;
					this._isLoop = value;
				}
			}

			// Token: 0x06000F5C RID: 3932 RVA: 0x0008B55C File Offset: 0x0008975C
			public BlockNetworkSound()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000F5D RID: 3933 RVA: 0x0008B5CF File Offset: 0x000897CF
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.fc_block_030, base.Location);
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000F5E RID: 3934 RVA: 0x0008B608 File Offset: 0x00089808
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_020, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_021, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_020.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_020.Width - Resources.bp_block_022.Width), (float)Resources.bp_block_021.Height));
					graphics.DrawImage(Resources.bp_block_022, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_022.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_020.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x040007AA RID: 1962
			private int _soundIndex;

			// Token: 0x040007AB RID: 1963
			private int _isPlay;

			// Token: 0x040007AC RID: 1964
			private int _isLoop;
		}

		// Token: 0x02000080 RID: 128
		public class BlockOutput : ProgramModule.Block
		{
			// Token: 0x17000491 RID: 1169
			// (get) Token: 0x06000F5F RID: 3935 RVA: 0x0008B7D1 File Offset: 0x000899D1
			// (set) Token: 0x06000F60 RID: 3936 RVA: 0x0008B7D9 File Offset: 0x000899D9
			public ProgramModule.BlockOutput.OUTPUT_TYPE OutputType
			{
				get
				{
					return this._outputType;
				}
				set
				{
					base.Updated |= this._outputType != value;
					this._outputType = value;
				}
			}

			// Token: 0x17000492 RID: 1170
			// (get) Token: 0x06000F61 RID: 3937 RVA: 0x0008B7FB File Offset: 0x000899FB
			// (set) Token: 0x06000F62 RID: 3938 RVA: 0x0008B803 File Offset: 0x00089A03
			public ProgramModule.BlockLED.LED_MODE Mode
			{
				get
				{
					return this._mode;
				}
				set
				{
					base.Updated |= this._mode != value;
					this._mode = value;
				}
			}

			// Token: 0x17000493 RID: 1171
			// (get) Token: 0x06000F63 RID: 3939 RVA: 0x0008B825 File Offset: 0x00089A25
			// (set) Token: 0x06000F64 RID: 3940 RVA: 0x0008B82D File Offset: 0x00089A2D
			public ProgramModule.BlockLED.FADE Fade
			{
				get
				{
					return this._fade;
				}
				set
				{
					base.Updated |= this._fade != value;
					this._fade = value;
				}
			}

			// Token: 0x17000494 RID: 1172
			// (get) Token: 0x06000F65 RID: 3941 RVA: 0x0008B84F File Offset: 0x00089A4F
			// (set) Token: 0x06000F66 RID: 3942 RVA: 0x0008B857 File Offset: 0x00089A57
			public int Red
			{
				get
				{
					return this._red;
				}
				set
				{
					base.Updated |= this._red != value;
					this._red = value;
				}
			}

			// Token: 0x17000495 RID: 1173
			// (get) Token: 0x06000F67 RID: 3943 RVA: 0x0008B879 File Offset: 0x00089A79
			// (set) Token: 0x06000F68 RID: 3944 RVA: 0x0008B881 File Offset: 0x00089A81
			public int Green
			{
				get
				{
					return this._green;
				}
				set
				{
					base.Updated |= this._green != value;
					this._green = value;
				}
			}

			// Token: 0x17000496 RID: 1174
			// (get) Token: 0x06000F69 RID: 3945 RVA: 0x0008B8A3 File Offset: 0x00089AA3
			// (set) Token: 0x06000F6A RID: 3946 RVA: 0x0008B8AB File Offset: 0x00089AAB
			public int Blue
			{
				get
				{
					return this._blue;
				}
				set
				{
					base.Updated |= this._blue != value;
					this._blue = value;
				}
			}

			// Token: 0x17000497 RID: 1175
			// (get) Token: 0x06000F6B RID: 3947 RVA: 0x0008B8CD File Offset: 0x00089ACD
			// (set) Token: 0x06000F6C RID: 3948 RVA: 0x0008B8D5 File Offset: 0x00089AD5
			public float Time
			{
				get
				{
					return this._time;
				}
				set
				{
					base.Updated |= this._time != value;
					this._time = value;
				}
			}

			// Token: 0x17000498 RID: 1176
			// (get) Token: 0x06000F6D RID: 3949 RVA: 0x0008B8F7 File Offset: 0x00089AF7
			// (set) Token: 0x06000F6E RID: 3950 RVA: 0x0008B8FF File Offset: 0x00089AFF
			public ProgramModule.BlockSound.MODE SoundMode
			{
				get
				{
					return this._soundMode;
				}
				set
				{
					base.Updated |= this._soundMode != value;
					this._soundMode = value;
				}
			}

			// Token: 0x17000499 RID: 1177
			// (get) Token: 0x06000F6F RID: 3951 RVA: 0x0008B921 File Offset: 0x00089B21
			// (set) Token: 0x06000F70 RID: 3952 RVA: 0x0008B929 File Offset: 0x00089B29
			public int BeepIndex
			{
				get
				{
					return this._beepIndex;
				}
				set
				{
					base.Updated |= this._beepIndex != value;
					this._beepIndex = value;
				}
			}

			// Token: 0x1700049A RID: 1178
			// (get) Token: 0x06000F71 RID: 3953 RVA: 0x0008B94B File Offset: 0x00089B4B
			// (set) Token: 0x06000F72 RID: 3954 RVA: 0x0008B953 File Offset: 0x00089B53
			public bool Loop
			{
				get
				{
					return this._loop;
				}
				set
				{
					base.Updated |= this._loop != value;
					this._loop = value;
				}
			}

			// Token: 0x06000F73 RID: 3955 RVA: 0x0008B978 File Offset: 0x00089B78
			public BlockOutput()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				this._red = (this._green = (this._blue = 10));
			}

			// Token: 0x06000F74 RID: 3956 RVA: 0x0008BA10 File Offset: 0x00089C10
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					ProgramModule.BlockOutput.OUTPUT_TYPE outputType = this.OutputType;
					if (outputType != ProgramModule.BlockOutput.OUTPUT_TYPE.LED)
					{
						if (outputType == ProgramModule.BlockOutput.OUTPUT_TYPE.SOUND)
						{
							graphics.DrawImage(Resources.nw_block_170, base.Location);
						}
					}
					else if (this._mode == ProgramModule.BlockLED.LED_MODE.OFF || (this._red == 0 && this._green == 0 && this._blue == 0))
					{
						graphics.DrawImage(Resources.nw_block_180, base.Location);
					}
					else
					{
						Brush brush = new SolidBrush(Color.FromArgb((int)((double)this._red * 25.5), (int)((double)this._green * 25.5), (int)((double)this._blue * 25.5)));
						graphics.FillRectangle(brush, new Rectangle(base.Location, ProgramModule.Block.BLOCK_SIZE));
						graphics.DrawImage(Resources.nw_block_160, base.Location);
					}
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000F75 RID: 3957 RVA: 0x0008BB0C File Offset: 0x00089D0C
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_090, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_091, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_090.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_090.Width - Resources.bp_block_092.Width), (float)Resources.bp_block_091.Height));
					graphics.DrawImage(Resources.bp_block_092, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_092.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						if (this.OutputType == ProgramModule.BlockOutput.OUTPUT_TYPE.LED && this.Mode != ProgramModule.BlockLED.LED_MODE.OFF)
						{
							int num = Resources.bp_block_091.Height - ProgramModule.Block.BLOCK_DETAIL_OFFSET * 4;
							graphics.FillRectangle(new SolidBrush(Color.FromArgb((int)((double)this._red * 25.5), (int)((double)this._green * 25.5), (int)((double)this._blue * 25.5))), base.LocationBlock.X + Resources.bp_block_090.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET, num, num);
						}
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_090.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000F76 RID: 3958 RVA: 0x0008BD74 File Offset: 0x00089F74
			public override string getDetail()
			{
				string text = "";
				ProgramModule.BlockOutput.OUTPUT_TYPE outputType = this.OutputType;
				if (outputType != ProgramModule.BlockOutput.OUTPUT_TYPE.LED)
				{
					if (outputType == ProgramModule.BlockOutput.OUTPUT_TYPE.SOUND)
					{
						switch (this.SoundMode)
						{
						case ProgramModule.BlockSound.MODE.BEEP:
							text = string.Format("サウンド{0}", this.BeepIndex + 1);
							break;
						case ProgramModule.BlockSound.MODE.MELODY_PLAY:
							text = "メロディ\r\n（連続）";
							break;
						case ProgramModule.BlockSound.MODE.MELODY_STOP:
							text = "メロディ\r\n停止";
							break;
						}
					}
				}
				else
				{
					switch (this.Mode)
					{
					case ProgramModule.BlockLED.LED_MODE.ON:
						text = "連続点灯";
						break;
					case ProgramModule.BlockLED.LED_MODE.OFF:
						text = "消灯";
						break;
					case ProgramModule.BlockLED.LED_MODE.ON_TIME:
						text = string.Format("点灯（{0}秒）", this.Time);
						break;
					}
				}
				return text;
			}

			// Token: 0x06000F77 RID: 3959 RVA: 0x0008BE24 File Offset: 0x0008A024
			public override string getDetailBlock(bool isPrint)
			{
				string text = "";
				ProgramModule.BlockOutput.OUTPUT_TYPE outputType = this.OutputType;
				if (outputType != ProgramModule.BlockOutput.OUTPUT_TYPE.LED)
				{
					if (outputType == ProgramModule.BlockOutput.OUTPUT_TYPE.SOUND)
					{
						text = (isPrint ? this.getDetail().Replace("\r\n", "") : "\u3000\u3000\u3000\u3000");
					}
				}
				else
				{
					ProgramModule.BlockLED.LED_MODE mode = this.Mode;
					if (mode != ProgramModule.BlockLED.LED_MODE.ON)
					{
						if (mode == ProgramModule.BlockLED.LED_MODE.OFF)
						{
							text = "消灯";
						}
					}
					else
					{
						text = (isPrint ? "\u3000 連続点灯" : "\u3000\u3000\u3000\u3000連続点灯");
					}
				}
				return text;
			}

			// Token: 0x06000F78 RID: 3960 RVA: 0x0008BE90 File Offset: 0x0008A090
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_002.Width;
					ProgramModule.BlockOutput.OUTPUT_TYPE outputType = this.OutputType;
					if (outputType != ProgramModule.BlockOutput.OUTPUT_TYPE.LED)
					{
						if (outputType != ProgramModule.BlockOutput.OUTPUT_TYPE.SOUND)
						{
							return;
						}
						base.Controls[1].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					}
					else if (this.Mode != ProgramModule.BlockLED.LED_MODE.OFF)
					{
						x += TextRenderer.MeasureText("\u3000", ProgramModule.Block._fontBlock).Width;
						base.Controls[0].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
						return;
					}
				}
			}

			// Token: 0x06000F79 RID: 3961 RVA: 0x0008BF50 File Offset: 0x0008A150
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				ComboBox comboBox = new ComboBox();
				comboBox.Width = 50;
				foreach (string text in ProgramModule.BlockLED.COLOR_ITEMS)
				{
					comboBox.Items.Add(text);
				}
				base.Controls.Add(comboBox);
				comboBox = new ComboBox();
				comboBox.Width = 80;
				foreach (string text2 in BlockPropertyOutputDialog.SOUND_ITEMS)
				{
					comboBox.Items.Add(text2);
				}
				base.Controls.Add(comboBox);
				this.updateBlock();
				((ComboBox)base.Controls[0]).SelectedValueChanged += this.comboBoxColor_SelectedValueChanged;
				((ComboBox)base.Controls[1]).SelectedValueChanged += this.comboBoxSound_SelectedValueChanged;
			}

			// Token: 0x06000F7A RID: 3962 RVA: 0x0008C034 File Offset: 0x0008A234
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					ProgramModule.BlockOutput.OUTPUT_TYPE outputType = this.OutputType;
					if (outputType == ProgramModule.BlockOutput.OUTPUT_TYPE.LED)
					{
						((ComboBox)base.Controls[0]).SelectedIndex = -1;
						return;
					}
					if (outputType != ProgramModule.BlockOutput.OUTPUT_TYPE.SOUND)
					{
						return;
					}
					switch (this.SoundMode)
					{
					case ProgramModule.BlockSound.MODE.BEEP:
						((ComboBox)base.Controls[1]).SelectedIndex = this.BeepIndex;
						return;
					case ProgramModule.BlockSound.MODE.MELODY_PLAY:
						if (this.Loop)
						{
							((ComboBox)base.Controls[1]).SelectedIndex = 3;
							return;
						}
						break;
					case ProgramModule.BlockSound.MODE.MELODY_STOP:
						((ComboBox)base.Controls[1]).SelectedIndex = 4;
						break;
					default:
						return;
					}
				}
			}

			// Token: 0x06000F7B RID: 3963 RVA: 0x0008C0F0 File Offset: 0x0008A2F0
			public override void updateControlVisible(List<Rectangle> rects)
			{
				base.updateControlVisible(rects);
				if (this.OutputType != ProgramModule.BlockOutput.OUTPUT_TYPE.LED || this.Mode == ProgramModule.BlockLED.LED_MODE.OFF)
				{
					base.Controls[0].Visible = false;
				}
				if (this.OutputType != ProgramModule.BlockOutput.OUTPUT_TYPE.SOUND)
				{
					base.Controls[1].Visible = false;
				}
			}

			// Token: 0x06000F7C RID: 3964 RVA: 0x0008C144 File Offset: 0x0008A344
			public void updateLevel()
			{
				foreach (Control control in base.Controls)
				{
					control.Enabled = NetworkWindow.Instance.Programs.Level > NetworkProgramModules.LEVEL.LEVEL_1;
				}
			}

			// Token: 0x06000F7D RID: 3965 RVA: 0x0008C1A8 File Offset: 0x0008A3A8
			private void comboBoxColor_SelectedValueChanged(object sender, EventArgs e)
			{
				switch (((ComboBox)base.Controls[0]).SelectedIndex)
				{
				case 0:
					this.Red = 10;
					this.Green = 0;
					this.Blue = 0;
					break;
				case 1:
					this.Red = 0;
					this.Green = 10;
					this.Blue = 0;
					break;
				case 2:
					this.Red = 0;
					this.Green = 0;
					this.Blue = 10;
					break;
				case 3:
					this.Red = 10;
					this.Green = 10;
					this.Blue = 0;
					break;
				case 4:
					this.Red = 10;
					this.Green = 0;
					this.Blue = 10;
					break;
				case 5:
					this.Red = 0;
					this.Green = 10;
					this.Blue = 10;
					break;
				case 6:
					this.Red = 10;
					this.Green = 10;
					this.Blue = 10;
					break;
				}
				base.addHistory();
			}

			// Token: 0x06000F7E RID: 3966 RVA: 0x0008C2A8 File Offset: 0x0008A4A8
			private void comboBoxSound_SelectedValueChanged(object sender, EventArgs e)
			{
				int selectedIndex = ((ComboBox)base.Controls[1]).SelectedIndex;
				switch (selectedIndex)
				{
				case 0:
				case 1:
				case 2:
					this.SoundMode = ProgramModule.BlockSound.MODE.BEEP;
					this.BeepIndex = selectedIndex;
					break;
				case 3:
					this.SoundMode = ProgramModule.BlockSound.MODE.MELODY_PLAY;
					this.Loop = true;
					break;
				case 4:
					this.SoundMode = ProgramModule.BlockSound.MODE.MELODY_STOP;
					break;
				}
				base.addHistory();
			}

			// Token: 0x040007AD RID: 1965
			public static readonly string[] OUTPUT_TYPE_ITEMS = new string[] { "LED", "サウンド" };

			// Token: 0x040007AE RID: 1966
			private ProgramModule.BlockOutput.OUTPUT_TYPE _outputType;

			// Token: 0x040007AF RID: 1967
			private ProgramModule.BlockLED.LED_MODE _mode;

			// Token: 0x040007B0 RID: 1968
			private ProgramModule.BlockLED.FADE _fade;

			// Token: 0x040007B1 RID: 1969
			private int _red;

			// Token: 0x040007B2 RID: 1970
			private int _green;

			// Token: 0x040007B3 RID: 1971
			private int _blue;

			// Token: 0x040007B4 RID: 1972
			private float _time = 0.1f;

			// Token: 0x040007B5 RID: 1973
			private ProgramModule.BlockSound.MODE _soundMode;

			// Token: 0x040007B6 RID: 1974
			private int _beepIndex;

			// Token: 0x040007B7 RID: 1975
			private bool _loop;

			// Token: 0x0200010C RID: 268
			public enum OUTPUT_TYPE
			{
				// Token: 0x04000ACA RID: 2762
				LED,
				// Token: 0x04000ACB RID: 2763
				SOUND,
				// Token: 0x04000ACC RID: 2764
				MAX
			}

			// Token: 0x0200010D RID: 269
			private enum CONTROL
			{
				// Token: 0x04000ACE RID: 2766
				COMBOBOX_COLOR,
				// Token: 0x04000ACF RID: 2767
				COMBOBOX_SOUND,
				// Token: 0x04000AD0 RID: 2768
				MAX
			}
		}

		// Token: 0x02000081 RID: 129
		public class BlockSound : ProgramModule.Block
		{
			// Token: 0x1700049B RID: 1179
			// (get) Token: 0x06000F80 RID: 3968 RVA: 0x0008C334 File Offset: 0x0008A534
			// (set) Token: 0x06000F81 RID: 3969 RVA: 0x0008C33C File Offset: 0x0008A53C
			public ProgramModule.BlockSound.MODE Mode
			{
				get
				{
					return this._mode;
				}
				set
				{
					base.Updated |= this._mode != value;
					this._mode = value;
				}
			}

			// Token: 0x1700049C RID: 1180
			// (get) Token: 0x06000F82 RID: 3970 RVA: 0x0008C35E File Offset: 0x0008A55E
			// (set) Token: 0x06000F83 RID: 3971 RVA: 0x0008C366 File Offset: 0x0008A566
			public int BeepIndex
			{
				get
				{
					return this._beepIndex;
				}
				set
				{
					base.Updated |= this._beepIndex != value;
					this._beepIndex = value;
				}
			}

			// Token: 0x1700049D RID: 1181
			// (get) Token: 0x06000F84 RID: 3972 RVA: 0x0008C388 File Offset: 0x0008A588
			// (set) Token: 0x06000F85 RID: 3973 RVA: 0x0008C390 File Offset: 0x0008A590
			public bool Loop
			{
				get
				{
					return this._loop;
				}
				set
				{
					base.Updated |= this._loop != value;
					this._loop = value;
				}
			}

			// Token: 0x06000F86 RID: 3974 RVA: 0x0008C3B4 File Offset: 0x0008A5B4
			public BlockSound()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000F87 RID: 3975 RVA: 0x0008C428 File Offset: 0x0008A628
			public override byte[] serializeBinary()
			{
				byte[] array = new byte[2];
				switch (this._mode)
				{
				case ProgramModule.BlockSound.MODE.BEEP:
					if (this._beepIndex == 0)
					{
						array[0] = 36;
					}
					else if (this._beepIndex == 1)
					{
						array[0] = 37;
					}
					else
					{
						array[0] = 38;
					}
					break;
				case ProgramModule.BlockSound.MODE.MELODY_PLAY:
					if (this._loop)
					{
						array[0] = 40;
					}
					else
					{
						array[0] = 39;
					}
					break;
				case ProgramModule.BlockSound.MODE.MELODY_STOP:
					array[0] = 41;
					break;
				}
				return array;
			}

			// Token: 0x06000F88 RID: 3976 RVA: 0x0008C49C File Offset: 0x0008A69C
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				switch (bytes[0])
				{
				case 36:
					this._mode = ProgramModule.BlockSound.MODE.BEEP;
					this._beepIndex = 0;
					break;
				case 37:
					this._mode = ProgramModule.BlockSound.MODE.BEEP;
					this._beepIndex = 1;
					break;
				case 38:
					this._mode = ProgramModule.BlockSound.MODE.BEEP;
					this._beepIndex = 2;
					break;
				case 39:
					this._mode = ProgramModule.BlockSound.MODE.MELODY_PLAY;
					this._loop = false;
					break;
				case 40:
					this._mode = ProgramModule.BlockSound.MODE.MELODY_PLAY;
					this._loop = true;
					break;
				case 41:
					this._mode = ProgramModule.BlockSound.MODE.MELODY_STOP;
					break;
				}
				return true;
			}

			// Token: 0x06000F89 RID: 3977 RVA: 0x0008C528 File Offset: 0x0008A728
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					if (this._mode == ProgramModule.BlockSound.MODE.BEEP)
					{
						graphics.DrawImage(Resources.fc_block_030, base.Location);
					}
					else
					{
						graphics.DrawImage(Resources.fc_block_040, base.Location);
					}
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000F8A RID: 3978 RVA: 0x0008C588 File Offset: 0x0008A788
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_020, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_021, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_020.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_020.Width - Resources.bp_block_022.Width), (float)Resources.bp_block_021.Height));
					graphics.DrawImage(Resources.bp_block_022, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_022.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_020.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000F8B RID: 3979 RVA: 0x0008C754 File Offset: 0x0008A954
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				string text = "";
				base.addIndent(ref text, indent);
				if (this._mode == ProgramModule.BlockSound.MODE.BEEP)
				{
					text = text + "BEEP(" + (this._beepIndex + 1).ToString() + ")";
				}
				else if (this._mode == ProgramModule.BlockSound.MODE.MELODY_PLAY)
				{
					text = text + "MELODY_PLAY(" + (this._loop ? "TRUE" : "FALSE") + ")";
				}
				else
				{
					text += "MELODY_STOP()";
				}
				codeList.Add(text);
				base.getProgram(blockList, codeList, indent);
			}

			// Token: 0x06000F8C RID: 3980 RVA: 0x0008C7E8 File Offset: 0x0008A9E8
			public override string getDetail()
			{
				if (this._mode == ProgramModule.BlockSound.MODE.BEEP)
				{
					return "サウンド(" + (this._beepIndex + 1).ToString() + ")";
				}
				if (this._mode != ProgramModule.BlockSound.MODE.MELODY_PLAY)
				{
					return "メロディ\r\n停止";
				}
				if (this._loop)
				{
					return "メロディ\r\n連続";
				}
				return "メロディ\r\n1回";
			}

			// Token: 0x06000F8D RID: 3981 RVA: 0x0008C83F File Offset: 0x0008AA3F
			public override string getDetailBlock(bool isPrint)
			{
				if (isPrint)
				{
					return this.getDetail().Replace("\r\n", "");
				}
				return "\u3000\u3000\u3000\u3000\u3000 \u3000\u3000";
			}

			// Token: 0x06000F8E RID: 3982 RVA: 0x0007787C File Offset: 0x00075A7C
			public override int getUsedMemory()
			{
				return 2;
			}

			// Token: 0x06000F8F RID: 3983 RVA: 0x0008C860 File Offset: 0x0008AA60
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				ComboBox comboBox = new ComboBox();
				comboBox.Width = 120;
				foreach (string text in BlockPropertySoundDialog.SOUND_ITEMS)
				{
					comboBox.Items.Add(text);
				}
				base.Controls.Add(comboBox);
				this.updateBlock();
				((ComboBox)base.Controls[ProgramModule.BlockSound.CONTROL_COMBOBOX]).SelectedValueChanged += this.comboBoxSound_SelectedValueChanged;
			}

			// Token: 0x06000F90 RID: 3984 RVA: 0x0008C8E4 File Offset: 0x0008AAE4
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					base.Controls[ProgramModule.BlockSound.CONTROL_COMBOBOX].Location = new Point(base.LocationBlock.X + Resources.bp_block_020.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
				}
			}

			// Token: 0x06000F91 RID: 3985 RVA: 0x0008C94D File Offset: 0x0008AB4D
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					this.updateComboBoxSound();
				}
			}

			// Token: 0x06000F92 RID: 3986 RVA: 0x0008C96C File Offset: 0x0008AB6C
			private void updateComboBoxSound()
			{
				ComboBox comboBox = (ComboBox)base.Controls[ProgramModule.BlockSound.CONTROL_COMBOBOX];
				switch (this.Mode)
				{
				case ProgramModule.BlockSound.MODE.BEEP:
					comboBox.SelectedIndex = this.BeepIndex;
					return;
				case ProgramModule.BlockSound.MODE.MELODY_PLAY:
					if (this.Loop)
					{
						comboBox.SelectedIndex = 4;
						return;
					}
					comboBox.SelectedIndex = 3;
					return;
				case ProgramModule.BlockSound.MODE.MELODY_STOP:
					comboBox.SelectedIndex = 5;
					return;
				default:
					return;
				}
			}

			// Token: 0x06000F93 RID: 3987 RVA: 0x0008C9D8 File Offset: 0x0008ABD8
			private void comboBoxSound_SelectedValueChanged(object sender, EventArgs e)
			{
				int selectedIndex = ((ComboBox)base.Controls[ProgramModule.BlockSound.CONTROL_COMBOBOX]).SelectedIndex;
				switch (selectedIndex)
				{
				case 0:
				case 1:
				case 2:
					this.Mode = ProgramModule.BlockSound.MODE.BEEP;
					this.BeepIndex = selectedIndex;
					break;
				case 3:
					this.Mode = ProgramModule.BlockSound.MODE.MELODY_PLAY;
					this.Loop = false;
					break;
				case 4:
					this.Mode = ProgramModule.BlockSound.MODE.MELODY_PLAY;
					this.Loop = true;
					break;
				case 5:
					this.Mode = ProgramModule.BlockSound.MODE.MELODY_STOP;
					break;
				}
				base.addHistory();
			}

			// Token: 0x040007B8 RID: 1976
			public const int USE_MEMORY_MAX = 2;

			// Token: 0x040007B9 RID: 1977
			public const int BEEP_MAX = 3;

			// Token: 0x040007BA RID: 1978
			private static readonly int CONTROL_COMBOBOX;

			// Token: 0x040007BB RID: 1979
			private ProgramModule.BlockSound.MODE _mode;

			// Token: 0x040007BC RID: 1980
			private int _beepIndex;

			// Token: 0x040007BD RID: 1981
			private bool _loop;

			// Token: 0x0200010E RID: 270
			public enum MODE
			{
				// Token: 0x04000AD2 RID: 2770
				BEEP,
				// Token: 0x04000AD3 RID: 2771
				MELODY_PLAY,
				// Token: 0x04000AD4 RID: 2772
				MELODY_STOP
			}
		}

		// Token: 0x02000082 RID: 130
		public class BlockStart : ProgramModule.Block
		{
			// Token: 0x06000F94 RID: 3988 RVA: 0x0008CA60 File Offset: 0x0008AC60
			public BlockStart()
			{
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Location = (base.LocationBlock = ProgramModule.BlockStart.INITIAL_LOCATION);
			}

			// Token: 0x06000F95 RID: 3989 RVA: 0x0008CABC File Offset: 0x0008ACBC
			public override byte[] serializeBinary()
			{
				byte[] array = new byte[2];
				array[0] = 1;
				return array;
			}

			// Token: 0x06000F96 RID: 3990 RVA: 0x0007968A File Offset: 0x0007788A
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				return true;
			}

			// Token: 0x06000F97 RID: 3991 RVA: 0x0008CAC8 File Offset: 0x0008ACC8
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.fc_block_000, base.Location);
				}
				base.paintConnectPoints(graphics);
			}

			// Token: 0x06000F98 RID: 3992 RVA: 0x0008CAF4 File Offset: 0x0008ACF4
			public override void paintRect(Graphics graphics, Color color, bool fill)
			{
				if (fill)
				{
					Brush brush = new SolidBrush(color);
					graphics.FillPie(brush, new Rectangle(base.Location.X, base.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width / 2, ProgramModule.Block.BLOCK_SIZE.Height), 90f, 180f);
					graphics.FillRectangle(brush, base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 4, base.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width / 2, ProgramModule.Block.BLOCK_SIZE.Height);
					graphics.FillPie(brush, new Rectangle(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 2, base.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width / 2, ProgramModule.Block.BLOCK_SIZE.Height), 270f, 180f);
					return;
				}
				Pen pen = new Pen(color, 4f);
				graphics.DrawArc(pen, new Rectangle(base.Location.X, base.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width / 2, ProgramModule.Block.BLOCK_SIZE.Height), 90f, 180f);
				graphics.DrawLine(pen, base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 4, base.Location.Y, base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 4 + ProgramModule.Block.BLOCK_SIZE.Width / 2, base.Location.Y);
				graphics.DrawLine(pen, base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 4, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height, base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 4 + ProgramModule.Block.BLOCK_SIZE.Width / 2, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height);
				graphics.DrawArc(pen, new Rectangle(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width / 2, base.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width / 2, ProgramModule.Block.BLOCK_SIZE.Height), 270f, 180f);
			}

			// Token: 0x06000F99 RID: 3993 RVA: 0x0008CD80 File Offset: 0x0008AF80
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_000, base.LocationBlock);
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_010.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
					}
				}
			}

			// Token: 0x06000F9A RID: 3994 RVA: 0x0008CE74 File Offset: 0x0008B074
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				codeList.Add("START()");
				base.getProgram(blockList, codeList, indent);
			}

			// Token: 0x06000F9B RID: 3995 RVA: 0x0008CE8A File Offset: 0x0008B08A
			public override string getDetail()
			{
				return "開始";
			}

			// Token: 0x06000F9C RID: 3996 RVA: 0x0007787C File Offset: 0x00075A7C
			public override int getUsedMemory()
			{
				return 2;
			}

			// Token: 0x06000F9D RID: 3997 RVA: 0x0007512D File Offset: 0x0007332D
			public override bool isConnectable(ProgramModule.Block block)
			{
				return false;
			}

			// Token: 0x06000F9E RID: 3998 RVA: 0x0008CE91 File Offset: 0x0008B091
			public override ProgramModule.Block.CONNECT_STATE updateConnectState(List<ProgramModule.Block> blocks)
			{
				if (base.Next != null)
				{
					base.Next.updateConnectState(blocks);
				}
				base.ConnectState = ProgramModule.Block.CONNECT_STATE.RIGHT;
				return base.ConnectState;
			}

			// Token: 0x040007BE RID: 1982
			public const int USE_MEMORY_MAX = 2;

			// Token: 0x040007BF RID: 1983
			public static readonly Point INITIAL_LOCATION = new Point(17, 17);
		}

		// Token: 0x02000083 RID: 131
		public class BlockSubroutine : ProgramModule.Block
		{
			// Token: 0x1700049E RID: 1182
			// (get) Token: 0x06000FA0 RID: 4000 RVA: 0x0008CEC5 File Offset: 0x0008B0C5
			// (set) Token: 0x06000FA1 RID: 4001 RVA: 0x0008CECD File Offset: 0x0008B0CD
			public int Index
			{
				get
				{
					return this._index;
				}
				set
				{
					base.Updated |= this._index != value;
					this._index = value;
				}
			}

			// Token: 0x06000FA2 RID: 4002 RVA: 0x0008CEF0 File Offset: 0x0008B0F0
			public BlockSubroutine()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, -ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000FA3 RID: 4003 RVA: 0x0008CF63 File Offset: 0x0008B163
			public override byte[] serializeBinary()
			{
				byte[] array = new byte[3];
				array[0] = 78;
				return array;
			}

			// Token: 0x06000FA4 RID: 4004 RVA: 0x0007968A File Offset: 0x0007788A
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				return true;
			}

			// Token: 0x06000FA5 RID: 4005 RVA: 0x0008CF70 File Offset: 0x0008B170
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.fc_block_200, base.Location);
					string text = FlowchartWindow.getSubroutineNames()[this._index];
					graphics.DrawString(text, ProgramModule.BlockSubroutine._font, Brushes.LightCyan, (float)(base.Location.X + (ProgramModule.Block.BLOCK_SIZE.Width - (int)((double)((float)text.Length * ProgramModule.BlockSubroutine._font.Size) * 1.5)) / 2), (float)(base.Location.Y + (ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.BlockSubroutine._font.Height) / 2));
				}
				else if (isDetail)
				{
					string text2 = FlowchartWindow.getSubroutineNames()[this._index];
					graphics.DrawString(text2, ProgramModule.BlockSubroutine._font, Brushes.Black, (float)(base.Location.X + (ProgramModule.Block.BLOCK_SIZE.Width - (int)((double)((float)text2.Length * ProgramModule.BlockSubroutine._font.Size) * 1.5)) / 2), (float)(base.Location.Y + (ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.BlockSubroutine._font.Height) / 2));
				}
				base.paintConnectPoints(graphics);
			}

			// Token: 0x06000FA6 RID: 4006 RVA: 0x0008D0B4 File Offset: 0x0008B2B4
			public override void paintRect(Graphics graphics, Color color, bool fill)
			{
				if (fill)
				{
					Brush brush = new SolidBrush(color);
					graphics.FillRectangle(brush, base.Location.X, base.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width, ProgramModule.Block.BLOCK_SIZE.Height);
					return;
				}
				Pen pen = new Pen(color, 4f);
				graphics.DrawRectangle(pen, base.Location.X, base.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width, ProgramModule.Block.BLOCK_SIZE.Height);
				graphics.DrawLine(pen, base.Location.X + (int)((double)ProgramModule.Block.BLOCK_SIZE.Width * 0.2), base.Location.Y, base.Location.X + (int)((double)ProgramModule.Block.BLOCK_SIZE.Width * 0.2), base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height);
				graphics.DrawLine(pen, base.Location.X + (int)((double)ProgramModule.Block.BLOCK_SIZE.Width * 0.8), base.Location.Y, base.Location.X + (int)((double)ProgramModule.Block.BLOCK_SIZE.Width * 0.8), base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height);
			}

			// Token: 0x06000FA7 RID: 4007 RVA: 0x0008D238 File Offset: 0x0008B438
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_070, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_071, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_070.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_070.Width - Resources.bp_block_072.Width), (float)Resources.bp_block_071.Height));
					graphics.DrawImage(Resources.bp_block_072, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_072.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_070.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000FA8 RID: 4008 RVA: 0x0008D404 File Offset: 0x0008B604
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				string text = "";
				base.addIndent(ref text, indent);
				text = text + "SUB_ROUTINE(" + (this._index + 1).ToString() + ")";
				codeList.Add(text);
				base.getProgram(blockList, codeList, indent);
			}

			// Token: 0x06000FA9 RID: 4009 RVA: 0x0008D451 File Offset: 0x0008B651
			public override string getDetailBlock(bool isPrint)
			{
				if (isPrint)
				{
					return FlowchartWindow.getSubroutineNames()[this._index];
				}
				return "\u3000\u3000\u3000\u3000\u3000";
			}

			// Token: 0x06000FAA RID: 4010 RVA: 0x0008D468 File Offset: 0x0008B668
			public override int getUsedMemory()
			{
				return 3;
			}

			// Token: 0x06000FAB RID: 4011 RVA: 0x0007512D File Offset: 0x0007332D
			public override bool isIconBlock()
			{
				return false;
			}

			// Token: 0x06000FAC RID: 4012 RVA: 0x0008D46C File Offset: 0x0008B66C
			public void updateSubroutineName()
			{
				if (base.Controls.Count > 0)
				{
					string[] subroutineNames = FlowchartWindow.getSubroutineNames();
					for (int i = 0; i < subroutineNames.Length; i++)
					{
						((ComboBox)base.Controls[ProgramModule.BlockSubroutine.CONTROL_COMBOBOX]).Items[i] = subroutineNames[i];
					}
				}
			}

			// Token: 0x06000FAD RID: 4013 RVA: 0x0008D4C0 File Offset: 0x0008B6C0
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					base.Controls[ProgramModule.BlockSubroutine.CONTROL_COMBOBOX].Location = new Point(base.LocationBlock.X + Resources.bp_block_070.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
				}
			}

			// Token: 0x06000FAE RID: 4014 RVA: 0x0008D52C File Offset: 0x0008B72C
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				ComboBox comboBox = new ComboBox();
				comboBox.Width = 100;
				foreach (string text in FlowchartWindow.getSubroutineNames())
				{
					comboBox.Items.Add(text);
				}
				base.Controls.Add(comboBox);
				this.updateBlock();
				((ComboBox)base.Controls[ProgramModule.BlockSubroutine.CONTROL_COMBOBOX]).SelectedValueChanged += this.comboBoxIndex_SelectedValueChanged;
			}

			// Token: 0x06000FAF RID: 4015 RVA: 0x0008D5AF File Offset: 0x0008B7AF
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					((ComboBox)base.Controls[ProgramModule.BlockSubroutine.CONTROL_COMBOBOX]).SelectedIndex = this._index;
				}
			}

			// Token: 0x06000FB0 RID: 4016 RVA: 0x0008D5E5 File Offset: 0x0008B7E5
			private void comboBoxIndex_SelectedValueChanged(object sender, EventArgs e)
			{
				this.Index = ((ComboBox)base.Controls[ProgramModule.BlockSubroutine.CONTROL_COMBOBOX]).SelectedIndex;
				base.addHistory();
			}

			// Token: 0x040007C0 RID: 1984
			public const int USE_MEMORY_MAX = 3;

			// Token: 0x040007C1 RID: 1985
			private static readonly int CONTROL_COMBOBOX = 0;

			// Token: 0x040007C2 RID: 1986
			private int _index;

			// Token: 0x040007C3 RID: 1987
			private static Font _font = new Font("メイリオ", 9f, FontStyle.Bold, GraphicsUnit.Point, 128);
		}

		// Token: 0x02000084 RID: 132
		public class BlockUsbOut : ProgramModule.Block
		{
			// Token: 0x1700049F RID: 1183
			// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x0008D630 File Offset: 0x0008B830
			// (set) Token: 0x06000FB3 RID: 4019 RVA: 0x0008D638 File Offset: 0x0008B838
			public ProgramModule.BlockUsbOut.USBOUT Mode
			{
				get
				{
					return this._mode;
				}
				set
				{
					base.Updated |= this._mode != value;
					this._mode = value;
				}
			}

			// Token: 0x170004A0 RID: 1184
			// (get) Token: 0x06000FB4 RID: 4020 RVA: 0x0008D65A File Offset: 0x0008B85A
			// (set) Token: 0x06000FB5 RID: 4021 RVA: 0x0008D662 File Offset: 0x0008B862
			public float Time
			{
				get
				{
					return this._time;
				}
				set
				{
					base.Updated |= this._time != value;
					this._time = value;
				}
			}

			// Token: 0x170004A1 RID: 1185
			// (get) Token: 0x06000FB6 RID: 4022 RVA: 0x0008D684 File Offset: 0x0008B884
			// (set) Token: 0x06000FB7 RID: 4023 RVA: 0x0008D68C File Offset: 0x0008B88C
			public int Power
			{
				get
				{
					return this._power;
				}
				set
				{
					base.Updated |= this._power != value;
					this._power = value;
				}
			}

			// Token: 0x06000FB8 RID: 4024 RVA: 0x0008D6B0 File Offset: 0x0008B8B0
			public BlockUsbOut()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height / 12 - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000FB9 RID: 4025 RVA: 0x0008D744 File Offset: 0x0008B944
			public override byte[] serializeBinary()
			{
				byte[] array = null;
				switch (this._mode)
				{
				case ProgramModule.BlockUsbOut.USBOUT.ON:
					array = new byte[]
					{
						138,
						0,
						(byte)this._power
					};
					break;
				case ProgramModule.BlockUsbOut.USBOUT.ON_TIME:
					array = new byte[]
					{
						139,
						0,
						(byte)this._power,
						(byte)(this._time * 10f)
					};
					break;
				case ProgramModule.BlockUsbOut.USBOUT.OFF:
					array = new byte[2];
					array[0] = 140;
					break;
				}
				return array;
			}

			// Token: 0x06000FBA RID: 4026 RVA: 0x0008D7C4 File Offset: 0x0008B9C4
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				switch (bytes[0])
				{
				case 138:
					this._mode = ProgramModule.BlockUsbOut.USBOUT.ON;
					this._power = (int)bytes[2];
					break;
				case 139:
					this._mode = ProgramModule.BlockUsbOut.USBOUT.ON_TIME;
					this._power = (int)bytes[2];
					this._time = (float)bytes[3] / 10f;
					break;
				case 140:
					this._mode = ProgramModule.BlockUsbOut.USBOUT.OFF;
					break;
				}
				return true;
			}

			// Token: 0x06000FBB RID: 4027 RVA: 0x0008D82B File Offset: 0x0008BA2B
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.fc_block_260, base.Location);
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000FBC RID: 4028 RVA: 0x0008D864 File Offset: 0x0008BA64
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_090, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_091, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_090.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_090.Width - Resources.bp_block_092.Width), (float)Resources.bp_block_091.Height));
					graphics.DrawImage(Resources.bp_block_092, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_092.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_090.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000FBD RID: 4029 RVA: 0x0008DA30 File Offset: 0x0008BC30
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				string text = "";
				base.addIndent(ref text, indent);
				switch (this._mode)
				{
				case ProgramModule.BlockUsbOut.USBOUT.ON:
					text += string.Format("OUTPUT_ON({0})", this._power);
					break;
				case ProgramModule.BlockUsbOut.USBOUT.ON_TIME:
					text += string.Format("OUTPUT_ON_TIME({0},{1})", this._time, this._power);
					break;
				case ProgramModule.BlockUsbOut.USBOUT.OFF:
					text += "OUTPUT_OFF";
					break;
				}
				codeList.Add(text);
				base.getProgram(blockList, codeList, indent);
			}

			// Token: 0x06000FBE RID: 4030 RVA: 0x0008DACC File Offset: 0x0008BCCC
			public override string getDetail()
			{
				string text = "";
				string text2 = "外部出力";
				switch (this._mode)
				{
				case ProgramModule.BlockUsbOut.USBOUT.ON:
					text = string.Format("{0} ON:{1}", text2, this._power);
					break;
				case ProgramModule.BlockUsbOut.USBOUT.ON_TIME:
					text = string.Format("{0} ON:{1}\r\n({2}秒)", text2, this._power, this._time);
					break;
				case ProgramModule.BlockUsbOut.USBOUT.OFF:
					text = text2 + " OFF";
					break;
				}
				return text;
			}

			// Token: 0x06000FBF RID: 4031 RVA: 0x0008DB4C File Offset: 0x0008BD4C
			public override string getDetailBlock(bool isPrint)
			{
				string text = "";
				switch (this._mode)
				{
				case ProgramModule.BlockUsbOut.USBOUT.ON:
					text = (isPrint ? string.Format("{0}で外部出力", this._power) : "\u3000\u3000\u3000で外部出力");
					break;
				case ProgramModule.BlockUsbOut.USBOUT.ON_TIME:
					text = (isPrint ? string.Format("{0}で外部出力{1}秒", this._power, this._time) : "\u3000\u3000\u3000で外部出力\u3000\u3000\u3000秒");
					break;
				case ProgramModule.BlockUsbOut.USBOUT.OFF:
					text = "外部出力 OFF";
					break;
				}
				return text;
			}

			// Token: 0x06000FC0 RID: 4032 RVA: 0x0008DBD0 File Offset: 0x0008BDD0
			public override int getUsedMemory()
			{
				int num = 0;
				switch (this._mode)
				{
				case ProgramModule.BlockUsbOut.USBOUT.ON:
					num = 3;
					break;
				case ProgramModule.BlockUsbOut.USBOUT.ON_TIME:
					num = 4;
					break;
				case ProgramModule.BlockUsbOut.USBOUT.OFF:
					num = 2;
					break;
				}
				return num;
			}

			// Token: 0x06000FC1 RID: 4033 RVA: 0x0008DC08 File Offset: 0x0008BE08
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_090.Width;
					base.Controls[0].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
					x += base.Controls[0].Width + ProgramModule.Block.BLOCK_COMPONENT_OFFSET + TextRenderer.MeasureText("で外部出力", ProgramModule.Block._fontBlock).Width;
					base.Controls[1].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
				}
			}

			// Token: 0x06000FC2 RID: 4034 RVA: 0x0008DCC4 File Offset: 0x0008BEC4
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				NumericUpDown numericUpDown = new NumericUpDown();
				numericUpDown.Width = 50;
				numericUpDown.Increment = 1m;
				numericUpDown.Minimum = 0m;
				numericUpDown.Maximum = 10m;
				base.Controls.Add(numericUpDown);
				numericUpDown = new NumericUpDown();
				numericUpDown.Width = 50;
				numericUpDown.DecimalPlaces = 1;
				numericUpDown.Increment = 0.1m;
				numericUpDown.Minimum = 0.1m;
				numericUpDown.Maximum = 25.5m;
				base.Controls.Add(numericUpDown);
				this.updateBlock();
				((NumericUpDown)base.Controls[0]).ValueChanged += this.numericUpDownPower_ValueChanged;
				((NumericUpDown)base.Controls[1]).ValueChanged += this.numericUpDownTime_ValueChanged;
			}

			// Token: 0x06000FC3 RID: 4035 RVA: 0x0008DDB8 File Offset: 0x0008BFB8
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					((NumericUpDown)base.Controls[0]).Value = this.Power;
					((NumericUpDown)base.Controls[1]).Value = (decimal)this.Time;
				}
			}

			// Token: 0x06000FC4 RID: 4036 RVA: 0x0008DE1C File Offset: 0x0008C01C
			public override void updateControlVisible(List<Rectangle> rects)
			{
				base.updateControlVisible(rects);
				switch (this._mode)
				{
				case ProgramModule.BlockUsbOut.USBOUT.ON:
					base.Controls[1].Visible = false;
					return;
				case ProgramModule.BlockUsbOut.USBOUT.ON_TIME:
					break;
				case ProgramModule.BlockUsbOut.USBOUT.OFF:
					base.Controls[0].Visible = false;
					base.Controls[1].Visible = false;
					break;
				default:
					return;
				}
			}

			// Token: 0x06000FC5 RID: 4037 RVA: 0x0008DE84 File Offset: 0x0008C084
			public void updateUsbInOutEnable(bool enable)
			{
				foreach (Control control in base.Controls)
				{
					control.Enabled = enable;
				}
			}

			// Token: 0x06000FC6 RID: 4038 RVA: 0x0008DED8 File Offset: 0x0008C0D8
			private void numericUpDownPower_ValueChanged(object sender, EventArgs e)
			{
				this.Power = (int)((NumericUpDown)base.Controls[0]).Value;
				base.addHistory();
			}

			// Token: 0x06000FC7 RID: 4039 RVA: 0x0008DF01 File Offset: 0x0008C101
			private void numericUpDownTime_ValueChanged(object sender, EventArgs e)
			{
				this.Time = (float)((NumericUpDown)base.Controls[1]).Value;
				base.addHistory();
			}

			// Token: 0x040007C4 RID: 1988
			public const int USE_MEMORY_MAX = 4;

			// Token: 0x040007C5 RID: 1989
			private ProgramModule.BlockUsbOut.USBOUT _mode;

			// Token: 0x040007C6 RID: 1990
			private float _time = 0.1f;

			// Token: 0x040007C7 RID: 1991
			private int _power = 10;

			// Token: 0x0200010F RID: 271
			private enum CONTROL
			{
				// Token: 0x04000AD6 RID: 2774
				NUMERIC_POWER,
				// Token: 0x04000AD7 RID: 2775
				NUMERIC_TIME,
				// Token: 0x04000AD8 RID: 2776
				MAX
			}

			// Token: 0x02000110 RID: 272
			public enum USBOUT
			{
				// Token: 0x04000ADA RID: 2778
				ON,
				// Token: 0x04000ADB RID: 2779
				ON_TIME,
				// Token: 0x04000ADC RID: 2780
				OFF,
				// Token: 0x04000ADD RID: 2781
				MAX
			}
		}

		// Token: 0x02000085 RID: 133
		public class BlockWait : ProgramModule.Block
		{
			// Token: 0x170004A2 RID: 1186
			// (get) Token: 0x06000FC8 RID: 4040 RVA: 0x0008DF2B File Offset: 0x0008C12B
			// (set) Token: 0x06000FC9 RID: 4041 RVA: 0x0008DF33 File Offset: 0x0008C133
			public float Time
			{
				get
				{
					return this._time;
				}
				set
				{
					base.Updated |= this._time != value;
					this._time = value;
				}
			}

			// Token: 0x06000FCA RID: 4042 RVA: 0x0008DF58 File Offset: 0x0008C158
			public BlockWait()
			{
				base.Points[0] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height / 12 - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
				base.Points[1] = new Point((ProgramModule.Block.BLOCK_SIZE.Width - ProgramModule.Block.CONNECT_POINT_SIZE) / 2, ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block.CONNECT_POINT_SIZE / 2);
			}

			// Token: 0x06000FCB RID: 4043 RVA: 0x0008DFE3 File Offset: 0x0008C1E3
			public override byte[] serializeBinary()
			{
				return new byte[]
				{
					42,
					0,
					(byte)(this._time * 10f)
				};
			}

			// Token: 0x06000FCC RID: 4044 RVA: 0x0008E000 File Offset: 0x0008C200
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				this._time = (float)bytes[2] / 10f;
				return true;
			}

			// Token: 0x06000FCD RID: 4045 RVA: 0x0008E013 File Offset: 0x0008C213
			public override void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaint(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.DrawImage(Resources.fc_block_050, base.Location);
				}
				base.paintConnectPoints(graphics);
				if (isDetail)
				{
					base.paintDetail(graphics, index == -1);
				}
			}

			// Token: 0x06000FCE RID: 4046 RVA: 0x0008E04C File Offset: 0x0008C24C
			public override void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				base.OnPaintBlock(graphics, isDetail, index, isPrint);
				if (index == -1)
				{
					graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = PixelOffsetMode.Half;
					graphics.DrawImage(Resources.bp_block_030, base.LocationBlock);
					graphics.DrawImage(Resources.bp_block_031, new RectangleF((float)(base.LocationBlock.X + Resources.bp_block_030.Width), (float)base.LocationBlock.Y, (float)(base.SizeBlock.Width - Resources.bp_block_030.Width - Resources.bp_block_032.Width), (float)Resources.bp_block_031.Height));
					graphics.DrawImage(Resources.bp_block_032, new Point(base.LocationBlock.X + base.SizeBlock.Width - Resources.bp_block_032.Width, base.LocationBlock.Y));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X + Resources.bp_block_030.Width, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
				}
				else
				{
					graphics.DrawRectangle(Pens.Black, new Rectangle(base.LocationBlock, base.SizeBlock));
					if (isDetail)
					{
						graphics.DrawString(this.getDetailBlock(isPrint), ProgramModule.Block._fontBlock, Brushes.Black, new Point(base.LocationBlock.X, base.LocationBlock.Y + ProgramModule.Block.BLOCK_DETAIL_OFFSET));
						return;
					}
					graphics.DrawString(index.ToString(), ProgramModule.Block._fontBlock, Brushes.Black, base.LocationBlock);
				}
			}

			// Token: 0x06000FCF RID: 4047 RVA: 0x0008E218 File Offset: 0x0008C418
			public override void paintRect(Graphics graphics, Color color, bool fill)
			{
				Point[] array = new Point[]
				{
					new Point(base.Location.X, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height / 6),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width, base.Location.Y),
					new Point(base.Location.X + ProgramModule.Block.BLOCK_SIZE.Width, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height),
					new Point(base.Location.X, base.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height)
				};
				if (fill)
				{
					Brush brush = new SolidBrush(color);
					graphics.FillPolygon(brush, array);
					return;
				}
				Pen pen = new Pen(color, 4f);
				graphics.DrawPolygon(pen, array);
			}

			// Token: 0x06000FD0 RID: 4048 RVA: 0x0008E32C File Offset: 0x0008C52C
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				string text = "";
				base.addIndent(ref text, indent);
				text = text + "WAIT(" + this._time.ToString() + ")";
				codeList.Add(text);
				base.getProgram(blockList, codeList, indent);
			}

			// Token: 0x06000FD1 RID: 4049 RVA: 0x0008E374 File Offset: 0x0008C574
			public override string getDetail()
			{
				float time = this._time;
				return time.ToString() + "秒";
			}

			// Token: 0x06000FD2 RID: 4050 RVA: 0x0008E399 File Offset: 0x0008C599
			public override string getDetailBlock(bool isPrint)
			{
				if (isPrint)
				{
					return string.Format("{0}秒待つ", this._time);
				}
				return "\u3000\u3000\u3000秒待つ";
			}

			// Token: 0x06000FD3 RID: 4051 RVA: 0x0008D468 File Offset: 0x0008B668
			public override int getUsedMemory()
			{
				return 3;
			}

			// Token: 0x06000FD4 RID: 4052 RVA: 0x0008E3BC File Offset: 0x0008C5BC
			public override void updateLocation(int x)
			{
				base.updateLocation(x);
				if (base.Controls.Count > 0)
				{
					x += Resources.bp_block_080.Width;
					base.Controls[0].Location = new Point(x, base.LocationBlock.Y + ProgramModule.Block.BLOCK_COMPONENT_OFFSET);
				}
			}

			// Token: 0x06000FD5 RID: 4053 RVA: 0x0008E418 File Offset: 0x0008C618
			public override void createBlockControls()
			{
				base.Controls = new List<Control>();
				NumericUpDown numericUpDown = new NumericUpDown();
				numericUpDown.Width = 50;
				numericUpDown.DecimalPlaces = 1;
				numericUpDown.Increment = 0.1m;
				numericUpDown.Minimum = 0.1m;
				numericUpDown.Maximum = 300m;
				base.Controls.Add(numericUpDown);
				this.updateBlock();
				((NumericUpDown)base.Controls[0]).ValueChanged += this.numericUpDownTime_ValueChanged;
			}

			// Token: 0x06000FD6 RID: 4054 RVA: 0x0008E4A9 File Offset: 0x0008C6A9
			public override void updateBlock()
			{
				base.updateBlock();
				if (base.Controls.Count > 0)
				{
					((NumericUpDown)base.Controls[0]).Value = (decimal)this.Time;
				}
			}

			// Token: 0x06000FD7 RID: 4055 RVA: 0x0008E4E0 File Offset: 0x0008C6E0
			private void numericUpDownTime_ValueChanged(object sender, EventArgs e)
			{
				this.Time = (float)((NumericUpDown)base.Controls[0]).Value;
				base.addHistory();
			}

			// Token: 0x040007C8 RID: 1992
			public const int USE_MEMORY_MAX = 3;

			// Token: 0x040007C9 RID: 1993
			private float _time = 0.1f;

			// Token: 0x02000111 RID: 273
			private enum CONTROL
			{
				// Token: 0x04000ADF RID: 2783
				NUMERIC_TIME,
				// Token: 0x04000AE0 RID: 2784
				MAX
			}
		}

		// Token: 0x02000086 RID: 134
		public class BlockWaitCondition : ProgramModule.Block
		{
			// Token: 0x170004A3 RID: 1187
			// (get) Token: 0x06000FD8 RID: 4056 RVA: 0x0008E50A File Offset: 0x0008C70A
			// (set) Token: 0x06000FD9 RID: 4057 RVA: 0x0008E512 File Offset: 0x0008C712
			public ProgramModule.BlockWaitCondition.CONDITION Condition
			{
				get
				{
					return this._condition;
				}
				set
				{
					base.Updated |= this._condition != value;
					this._condition = value;
				}
			}

			// Token: 0x170004A4 RID: 1188
			// (get) Token: 0x06000FDA RID: 4058 RVA: 0x0008E534 File Offset: 0x0008C734
			// (set) Token: 0x06000FDB RID: 4059 RVA: 0x0008E53C File Offset: 0x0008C73C
			public ProgramModule.BlockWaitCondition.LIGHT Light
			{
				get
				{
					return this._light;
				}
				set
				{
					base.Updated |= this._light != value;
					this._light = value;
				}
			}

			// Token: 0x170004A5 RID: 1189
			// (get) Token: 0x06000FDC RID: 4060 RVA: 0x0008E55E File Offset: 0x0008C75E
			// (set) Token: 0x06000FDD RID: 4061 RVA: 0x0008E566 File Offset: 0x0008C766
			public int Hour
			{
				get
				{
					return this._hour;
				}
				set
				{
					base.Updated |= this._hour != value;
					this._hour = value;
				}
			}

			// Token: 0x170004A6 RID: 1190
			// (get) Token: 0x06000FDE RID: 4062 RVA: 0x0008E588 File Offset: 0x0008C788
			// (set) Token: 0x06000FDF RID: 4063 RVA: 0x0008E590 File Offset: 0x0008C790
			public int Minute
			{
				get
				{
					return this._minute;
				}
				set
				{
					base.Updated |= this._minute != value;
					this._minute = value;
				}
			}

			// Token: 0x170004A7 RID: 1191
			// (get) Token: 0x06000FE0 RID: 4064 RVA: 0x0008E5B2 File Offset: 0x0008C7B2
			// (set) Token: 0x06000FE1 RID: 4065 RVA: 0x0008E5BA File Offset: 0x0008C7BA
			public int Temperature
			{
				get
				{
					return this._temperature;
				}
				set
				{
					base.Updated |= this._temperature != value;
					this._temperature = value;
				}
			}

			// Token: 0x06000FE3 RID: 4067 RVA: 0x0008E5DC File Offset: 0x0008C7DC
			public override byte[] serializeBinary()
			{
				byte[] array = new byte[0];
				switch (this._condition)
				{
				case ProgramModule.BlockWaitCondition.CONDITION.BUTTON:
					array = new byte[3];
					array[0] = 46;
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.LIGHT:
					array = new byte[3];
					if (this._light == ProgramModule.BlockWaitCondition.LIGHT.BRIGHT)
					{
						array[0] = 48;
					}
					else
					{
						array[0] = 49;
					}
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.SOUND:
					array = new byte[3];
					array[0] = 51;
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.ALARM:
					array = new byte[3];
					array[0] = 61;
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.TIMER:
					array = new byte[3];
					array[0] = 63;
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.TIME:
					array = new byte[]
					{
						59,
						0,
						0,
						(byte)this._hour,
						(byte)this._minute
					};
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.TEMPERATURE:
					array = new byte[]
					{
						54,
						0,
						0,
						(byte)this._temperature
					};
					break;
				}
				return array;
			}

			// Token: 0x06000FE4 RID: 4068 RVA: 0x0008E6AC File Offset: 0x0008C8AC
			protected override bool deserializeBinarySub(byte[] bytes)
			{
				ProgramModule.Block.COMMAND_NUMBER command_NUMBER = (ProgramModule.Block.COMMAND_NUMBER)bytes[0];
				switch (command_NUMBER)
				{
				case ProgramModule.Block.COMMAND_NUMBER.IF_BEGIN:
					this._condition = ProgramModule.BlockWaitCondition.CONDITION.BUTTON;
					return true;
				case ProgramModule.Block.COMMAND_NUMBER.IF_BUTTON_OFF:
				case ProgramModule.Block.COMMAND_NUMBER.IF_SOUND_OFF:
				case ProgramModule.Block.COMMAND_NUMBER.IF_TEMPERATURE_COMPARE_GREATER_CONST:
				case ProgramModule.Block.COMMAND_NUMBER.IF_TEMPERATURE_COMPARE_LESS_CONST:
					break;
				case ProgramModule.Block.COMMAND_NUMBER.IF_LIGHT_BRIGHT:
					this._condition = ProgramModule.BlockWaitCondition.CONDITION.LIGHT;
					this._light = ProgramModule.BlockWaitCondition.LIGHT.BRIGHT;
					return true;
				case ProgramModule.Block.COMMAND_NUMBER.IF_LIGHT_DARK:
					this._condition = ProgramModule.BlockWaitCondition.CONDITION.LIGHT;
					this._light = ProgramModule.BlockWaitCondition.LIGHT.DARK;
					return true;
				case ProgramModule.Block.COMMAND_NUMBER.IF_SOUND_ON:
					this._condition = ProgramModule.BlockWaitCondition.CONDITION.SOUND;
					return true;
				case ProgramModule.Block.COMMAND_NUMBER.IF_TEMPERATURE_COMPARE_EQUAL_CONST:
					this._condition = ProgramModule.BlockWaitCondition.CONDITION.TEMPERATURE;
					this._temperature = (int)((sbyte)bytes[3]);
					return true;
				default:
					switch (command_NUMBER)
					{
					case ProgramModule.Block.COMMAND_NUMBER.IF_TIME_COMPARE_EQUAL:
						this._condition = ProgramModule.BlockWaitCondition.CONDITION.TIME;
						this._hour = (int)bytes[3];
						this._minute = (int)bytes[4];
						return true;
					case ProgramModule.Block.COMMAND_NUMBER.IF_ALARAM_ON:
						this._condition = ProgramModule.BlockWaitCondition.CONDITION.ALARM;
						return true;
					case ProgramModule.Block.COMMAND_NUMBER.IF_TIMER_ON:
						this._condition = ProgramModule.BlockWaitCondition.CONDITION.TIMER;
						return true;
					}
					break;
				}
				return false;
			}

			// Token: 0x06000FE5 RID: 4069 RVA: 0x0008E780 File Offset: 0x0008C980
			public override void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				string text = "";
				switch (this._condition)
				{
				case ProgramModule.BlockWaitCondition.CONDITION.BUTTON:
					text = "BUTTON";
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.LIGHT:
					if (this._light == ProgramModule.BlockWaitCondition.LIGHT.BRIGHT)
					{
						text = "LIGHT,BRIGHT";
					}
					else
					{
						text = "LIGHT,DARK";
					}
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.SOUND:
					text = "SOUND";
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.ALARM:
					text = "ALARM";
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.TIMER:
					text = "TIMER";
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.TIME:
					text = "TIME," + this._hour.ToString() + "," + this._minute.ToString();
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.TEMPERATURE:
					text = "TEMPERATURE," + this._temperature.ToString();
					break;
				}
				string text2 = "";
				base.addIndent(ref text2, indent);
				text2 = text2 + "WAIT_CONDITION(" + text + ")";
				codeList.Add(text2);
				base.getProgram(blockList, codeList, indent);
			}

			// Token: 0x06000FE6 RID: 4070 RVA: 0x0008E868 File Offset: 0x0008CA68
			public override string getDetail()
			{
				string text = "";
				switch (this._condition)
				{
				case ProgramModule.BlockWaitCondition.CONDITION.BUTTON:
					text = "「ボタンが押され\r\nる」まで待つ";
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.LIGHT:
					if (this._light == ProgramModule.BlockWaitCondition.LIGHT.BRIGHT)
					{
						text = "「明るくなる」ま\r\nで待つ";
					}
					else
					{
						text = "「暗くなる」まで\r\n待つ";
					}
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.SOUND:
					text = "「音センサに入力\r\nがある」まで待つ";
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.ALARM:
					text = "「アラームがONに\r\nなる」まで待つ";
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.TIMER:
					text = "「タイマーがONに\r\nなる」まで待つ";
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.TIME:
					text = "「時刻が";
					if (this._hour <= 9)
					{
						text += "0";
					}
					text = text + this._hour.ToString() + ":";
					if (this._minute <= 9)
					{
						text += "0";
					}
					text = text + this._minute.ToString() + "に\r\nなる」まで待つ";
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.TEMPERATURE:
					text = "「温度が" + this._temperature.ToString() + "度にな\r\nる」まで待つ";
					break;
				}
				return text;
			}

			// Token: 0x06000FE7 RID: 4071 RVA: 0x0008E970 File Offset: 0x0008CB70
			public override int getUsedMemory()
			{
				int num = 0;
				switch (this._condition)
				{
				case ProgramModule.BlockWaitCondition.CONDITION.BUTTON:
				case ProgramModule.BlockWaitCondition.CONDITION.LIGHT:
				case ProgramModule.BlockWaitCondition.CONDITION.SOUND:
				case ProgramModule.BlockWaitCondition.CONDITION.ALARM:
				case ProgramModule.BlockWaitCondition.CONDITION.TIMER:
					num = 3;
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.TIME:
					num = 5;
					break;
				case ProgramModule.BlockWaitCondition.CONDITION.TEMPERATURE:
					num = 4;
					break;
				}
				return num;
			}

			// Token: 0x06000FE8 RID: 4072 RVA: 0x0008E9B8 File Offset: 0x0008CBB8
			public void convertToBlockIf(ProgramModule.BlockIf blockIf)
			{
				blockIf.Next = base.Next;
				blockIf.Else = blockIf;
				blockIf.Condition = (ProgramModule.BlockIf.CONDITION_IF)this._condition;
				switch (this._condition)
				{
				case ProgramModule.BlockWaitCondition.CONDITION.BUTTON:
					blockIf.Select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					return;
				case ProgramModule.BlockWaitCondition.CONDITION.LIGHT:
					if (this._light == ProgramModule.BlockWaitCondition.LIGHT.BRIGHT)
					{
						blockIf.Select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					}
					else
					{
						blockIf.Select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					}
					blockIf.Variable = ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID;
					return;
				case ProgramModule.BlockWaitCondition.CONDITION.SOUND:
					blockIf.Select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					return;
				case ProgramModule.BlockWaitCondition.CONDITION.ALARM:
					blockIf.Select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					return;
				case ProgramModule.BlockWaitCondition.CONDITION.TIMER:
					blockIf.Select = ProgramModule.BlockIf.SELECT.BUTTON_ON;
					return;
				case ProgramModule.BlockWaitCondition.CONDITION.TIME:
					blockIf.Select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					blockIf.Values = new int[] { this._hour, this._minute };
					return;
				case ProgramModule.BlockWaitCondition.CONDITION.TEMPERATURE:
				{
					blockIf.Select = ProgramModule.BlockIf.SELECT.BUTTON_OFF;
					int[] array = new int[2];
					array[0] = this._temperature;
					blockIf.Values = array;
					return;
				}
				default:
					return;
				}
			}

			// Token: 0x040007CA RID: 1994
			public const int USE_MEMORY_MAX = 5;

			// Token: 0x040007CB RID: 1995
			private ProgramModule.BlockWaitCondition.CONDITION _condition;

			// Token: 0x040007CC RID: 1996
			private ProgramModule.BlockWaitCondition.LIGHT _light;

			// Token: 0x040007CD RID: 1997
			private int _hour;

			// Token: 0x040007CE RID: 1998
			private int _minute;

			// Token: 0x040007CF RID: 1999
			private int _temperature;

			// Token: 0x02000112 RID: 274
			public enum CONDITION
			{
				// Token: 0x04000AE2 RID: 2786
				BUTTON,
				// Token: 0x04000AE3 RID: 2787
				LIGHT,
				// Token: 0x04000AE4 RID: 2788
				SOUND,
				// Token: 0x04000AE5 RID: 2789
				ALARM,
				// Token: 0x04000AE6 RID: 2790
				TIMER,
				// Token: 0x04000AE7 RID: 2791
				TIME,
				// Token: 0x04000AE8 RID: 2792
				TEMPERATURE
			}

			// Token: 0x02000113 RID: 275
			public enum LIGHT
			{
				// Token: 0x04000AEA RID: 2794
				BRIGHT,
				// Token: 0x04000AEB RID: 2795
				DARK
			}
		}

		// Token: 0x02000087 RID: 135
		public enum ERROR
		{
			// Token: 0x040007D1 RID: 2001
			LOOP_MISMATCH,
			// Token: 0x040007D2 RID: 2002
			LOOP_RANK_OVER,
			// Token: 0x040007D3 RID: 2003
			CONNECT,
			// Token: 0x040007D4 RID: 2004
			INFINITY,
			// Token: 0x040007D5 RID: 2005
			INVALID_BLOCK,
			// Token: 0x040007D6 RID: 2006
			LOW_MEMORY,
			// Token: 0x040007D7 RID: 2007
			JUMP,
			// Token: 0x040007D8 RID: 2008
			MAX,
			// Token: 0x040007D9 RID: 2009
			NONE
		}

		// Token: 0x02000088 RID: 136
		public class Block
		{
			// Token: 0x170004A8 RID: 1192
			// (get) Token: 0x06000FE9 RID: 4073 RVA: 0x0008EA90 File Offset: 0x0008CC90
			public Point[] Points
			{
				get
				{
					return this._points;
				}
			}

			// Token: 0x170004A9 RID: 1193
			// (get) Token: 0x06000FEA RID: 4074 RVA: 0x0008EA98 File Offset: 0x0008CC98
			// (set) Token: 0x06000FEB RID: 4075 RVA: 0x0008EAA0 File Offset: 0x0008CCA0
			public bool BreakPoint
			{
				get
				{
					return this._breakPoint;
				}
				set
				{
					this._breakPoint = value;
				}
			}

			// Token: 0x170004AA RID: 1194
			// (get) Token: 0x06000FEC RID: 4076 RVA: 0x0008EAA9 File Offset: 0x0008CCA9
			// (set) Token: 0x06000FED RID: 4077 RVA: 0x0008EAB4 File Offset: 0x0008CCB4
			[XmlIgnore]
			public bool Selected
			{
				get
				{
					return this._selected;
				}
				set
				{
					ProgramModule.SelectLoopBlock = null;
					this._selected = value;
					if (value && (base.GetType() == typeof(ProgramModule.BlockLoopStart) || base.GetType() == typeof(ProgramModule.BlockLoopEnd)))
					{
						ProgramModule.SelectLoopBlock = this;
					}
				}
			}

			// Token: 0x170004AB RID: 1195
			// (get) Token: 0x06000FEE RID: 4078 RVA: 0x0008EB05 File Offset: 0x0008CD05
			// (set) Token: 0x06000FEF RID: 4079 RVA: 0x0008EB0D File Offset: 0x0008CD0D
			[XmlIgnore]
			public bool Updated
			{
				get
				{
					return this._updated;
				}
				set
				{
					this._updated = value;
				}
			}

			// Token: 0x170004AC RID: 1196
			// (get) Token: 0x06000FF0 RID: 4080 RVA: 0x0008EB16 File Offset: 0x0008CD16
			// (set) Token: 0x06000FF1 RID: 4081 RVA: 0x0008EB1E File Offset: 0x0008CD1E
			[XmlIgnore]
			public ProgramModule.Block.CONNECT_STATE ConnectState
			{
				get
				{
					return this._connectState;
				}
				set
				{
					this._connectState = value;
				}
			}

			// Token: 0x170004AD RID: 1197
			// (get) Token: 0x06000FF2 RID: 4082 RVA: 0x0008EB27 File Offset: 0x0008CD27
			// (set) Token: 0x06000FF3 RID: 4083 RVA: 0x0008EB2F File Offset: 0x0008CD2F
			[XmlIgnore]
			public int LoopBlockCount
			{
				get
				{
					return this._loopBlockCount;
				}
				set
				{
					this._loopBlockCount = value;
				}
			}

			// Token: 0x170004AE RID: 1198
			// (get) Token: 0x06000FF4 RID: 4084 RVA: 0x0008EB38 File Offset: 0x0008CD38
			// (set) Token: 0x06000FF5 RID: 4085 RVA: 0x0008EB40 File Offset: 0x0008CD40
			[XmlIgnore]
			public ProgramModule.Block Before
			{
				get
				{
					return this._before;
				}
				set
				{
					this._before = value;
				}
			}

			// Token: 0x170004AF RID: 1199
			// (get) Token: 0x06000FF6 RID: 4086 RVA: 0x0008EB49 File Offset: 0x0008CD49
			// (set) Token: 0x06000FF7 RID: 4087 RVA: 0x0008EB51 File Offset: 0x0008CD51
			[XmlIgnore]
			public ProgramModule.Block Next
			{
				get
				{
					return this._next;
				}
				set
				{
					this._next = value;
				}
			}

			// Token: 0x06000FF8 RID: 4088 RVA: 0x0008EB5C File Offset: 0x0008CD5C
			public void SetNextBlock(ProgramModule.Block next)
			{
				if (next == null)
				{
					if (this._next != null)
					{
						this._next._before = null;
					}
				}
				else
				{
					ProgramModule.Block last = next.Last;
					last._next = this._next;
					if (this._next != null)
					{
						this._next._before = last;
					}
					next._before = this;
				}
				this._next = next;
			}

			// Token: 0x170004B0 RID: 1200
			// (get) Token: 0x06000FF9 RID: 4089 RVA: 0x0008EBB8 File Offset: 0x0008CDB8
			public ProgramModule.Block First
			{
				get
				{
					ProgramModule.Block block = this;
					while (block.Before != null)
					{
						block = block.Before;
					}
					return block;
				}
			}

			// Token: 0x170004B1 RID: 1201
			// (get) Token: 0x06000FFA RID: 4090 RVA: 0x0008EBDC File Offset: 0x0008CDDC
			public ProgramModule.Block Last
			{
				get
				{
					ProgramModule.Block block = this;
					while (block.Next != null)
					{
						block = block.Next;
					}
					return block;
				}
			}

			// Token: 0x170004B2 RID: 1202
			// (get) Token: 0x06000FFB RID: 4091 RVA: 0x0008EBFD File Offset: 0x0008CDFD
			// (set) Token: 0x06000FFC RID: 4092 RVA: 0x0008EC05 File Offset: 0x0008CE05
			public int LineCount
			{
				get
				{
					return this._lineCount;
				}
				set
				{
					this._lineCount = value;
				}
			}

			// Token: 0x170004B3 RID: 1203
			// (get) Token: 0x06000FFD RID: 4093 RVA: 0x0008EC0E File Offset: 0x0008CE0E
			// (set) Token: 0x06000FFE RID: 4094 RVA: 0x0008EC16 File Offset: 0x0008CE16
			public Point Location
			{
				get
				{
					return this._location;
				}
				set
				{
					this._location = value;
				}
			}

			// Token: 0x170004B4 RID: 1204
			// (get) Token: 0x06000FFF RID: 4095 RVA: 0x0008EC1F File Offset: 0x0008CE1F
			// (set) Token: 0x06001000 RID: 4096 RVA: 0x0008EC27 File Offset: 0x0008CE27
			public Point LocationBlock
			{
				get
				{
					return this._locationBlock;
				}
				set
				{
					this._locationBlock = value;
				}
			}

			// Token: 0x170004B5 RID: 1205
			// (get) Token: 0x06001001 RID: 4097 RVA: 0x0008EC30 File Offset: 0x0008CE30
			// (set) Token: 0x06001002 RID: 4098 RVA: 0x0008EC38 File Offset: 0x0008CE38
			public Size SizeBlock
			{
				get
				{
					return this._sizeBlock;
				}
				set
				{
					this._sizeBlock = value;
				}
			}

			// Token: 0x170004B6 RID: 1206
			// (get) Token: 0x06001003 RID: 4099 RVA: 0x0008EC41 File Offset: 0x0008CE41
			// (set) Token: 0x06001004 RID: 4100 RVA: 0x0008EC49 File Offset: 0x0008CE49
			public int ConnectIndex
			{
				get
				{
					return this._connectIndex;
				}
				set
				{
					this._connectIndex = value;
				}
			}

			// Token: 0x170004B7 RID: 1207
			// (get) Token: 0x06001005 RID: 4101 RVA: 0x0008EC52 File Offset: 0x0008CE52
			// (set) Token: 0x06001006 RID: 4102 RVA: 0x0008EC5A File Offset: 0x0008CE5A
			public int ConnectIndexBefore
			{
				get
				{
					return this._connectIndexBefore;
				}
				set
				{
					this._connectIndexBefore = value;
				}
			}

			// Token: 0x170004B8 RID: 1208
			// (get) Token: 0x06001007 RID: 4103 RVA: 0x0008EC63 File Offset: 0x0008CE63
			// (set) Token: 0x06001008 RID: 4104 RVA: 0x0008EC6B File Offset: 0x0008CE6B
			[XmlIgnore]
			public List<Control> Controls { get; set; } = new List<Control>();

			// Token: 0x0600100A RID: 4106 RVA: 0x000153E3 File Offset: 0x000135E3
			public virtual void updateVersion(int version)
			{
			}

			// Token: 0x0600100B RID: 4107 RVA: 0x0008ECA8 File Offset: 0x0008CEA8
			public virtual byte[] serializeBinary()
			{
				return null;
			}

			// Token: 0x0600100C RID: 4108 RVA: 0x0008ECAC File Offset: 0x0008CEAC
			public static ProgramModule.Block deserializeBinary(byte[] bytes, bool isIcon)
			{
				ProgramModule.Block block = null;
				ProgramModule.Block.COMMAND_NUMBER command_NUMBER = (ProgramModule.Block.COMMAND_NUMBER)bytes[0];
				if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.START)
				{
					block = new ProgramModule.BlockStart();
				}
				else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.END)
				{
					block = new ProgramModule.BlockEnd();
				}
				else if (ProgramModule.Block.COMMAND_NUMBER.LED_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.LED_OFF)
				{
					block = new ProgramModule.BlockLED();
				}
				else if (ProgramModule.Block.COMMAND_NUMBER.SOUND_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.SOUND_STOP)
				{
					block = new ProgramModule.BlockSound();
				}
				else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.WAIT)
				{
					block = new ProgramModule.BlockWait();
				}
				else if (ProgramModule.Block.COMMAND_NUMBER.COUNTER_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.COUNTER_STOP)
				{
					if (!isIcon)
					{
						block = new ProgramModule.BlockCounter();
					}
				}
				else if ((ProgramModule.Block.COMMAND_NUMBER.IF_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.IF_RANDOM) || (ProgramModule.Block.COMMAND_NUMBER.IF_SECOND_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.IF_LIGHT_VARIABLE_DARK) || (ProgramModule.Block.COMMAND_NUMBER.IF_THIRD_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.IF_USBIN_OFF))
				{
					if (isIcon)
					{
						block = new ProgramModule.BlockWaitCondition();
					}
					else
					{
						block = new ProgramModule.BlockIf();
					}
				}
				else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LOOP_START)
				{
					block = new ProgramModule.BlockLoopStart();
				}
				else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.LOOP_END || (ProgramModule.Block.COMMAND_NUMBER.LOOP_END_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.LOOP_END_VARIABLE_COMPARE_LESS_VARIABLE) || (ProgramModule.Block.COMMAND_NUMBER.LOOP_END_SECOND_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.LOOP_END_USBIN_OFF))
				{
					block = new ProgramModule.BlockLoopEnd();
				}
				else if (command_NUMBER == ProgramModule.Block.COMMAND_NUMBER.SUBROUTINE)
				{
					if (!isIcon)
					{
						block = new ProgramModule.BlockSubroutine();
					}
				}
				else if ((ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_SUB_TEMPERATURE) || (ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_SECOND_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.ARITHMETIC_SUB_LIGHT))
				{
					if (!isIcon)
					{
						block = new ProgramModule.BlockArithmetic();
					}
				}
				else if (ProgramModule.Block.COMMAND_NUMBER.DISPLAY_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.DISPLAY_INVALID)
				{
					if (!isIcon)
					{
						block = new ProgramModule.BlockDisplay();
					}
				}
				else if (ProgramModule.Block.COMMAND_NUMBER.USBOUT_BEGIN <= command_NUMBER && command_NUMBER <= ProgramModule.Block.COMMAND_NUMBER.USBOUT_OFF && !isIcon)
				{
					block = new ProgramModule.BlockUsbOut();
				}
				if (block != null && !block.deserializeBinarySub(bytes))
				{
					block = null;
				}
				return block;
			}

			// Token: 0x0600100D RID: 4109 RVA: 0x0007968A File Offset: 0x0007788A
			protected virtual bool deserializeBinarySub(byte[] bytes)
			{
				return true;
			}

			// Token: 0x0600100E RID: 4110 RVA: 0x0008EE14 File Offset: 0x0008D014
			public virtual void OnPaint(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				if (index == -1)
				{
					if (this.Selected)
					{
						this.paintRect(graphics, Color.Blue, false);
					}
					if (this._breakPoint)
					{
						Brush brush = new SolidBrush(Color.Red);
						graphics.FillEllipse(brush, new Rectangle(this.Location.X + this._points[0].X - (ProgramModule.Block.BREAK_RADIUS - ProgramModule.Block.CONNECT_POINT_SIZE / 2), this.Location.Y + this._points[0].Y - (ProgramModule.Block.BREAK_RADIUS - ProgramModule.Block.CONNECT_POINT_SIZE / 2), ProgramModule.Block.BREAK_RADIUS * 2, ProgramModule.Block.BREAK_RADIUS * 2));
					}
				}
				else
				{
					this.paintRect(graphics, Color.Black, false);
					if (index != 0)
					{
						string text = index.ToString();
						graphics.DrawString(text, ProgramModule.Block._font, Brushes.Black, new PointF((float)this.Location.X + ((float)ProgramModule.Block.BLOCK_SIZE.Width - (float)text.Length * ProgramModule.Block._font.Size) / 2f, (float)(this.Location.Y + (ProgramModule.Block.BLOCK_SIZE.Height - ProgramModule.Block._font.Height) / 2)));
					}
				}
				if (this._next != null)
				{
					Point point = new Point(this.Location.X + this._points[1].X + ProgramModule.Block.CONNECT_POINT_SIZE / 2, this.Location.Y + this._points[1].Y + ProgramModule.Block.CONNECT_POINT_SIZE);
					Point point2 = new Point(this._next.Location.X + this._next._points[0].X + ProgramModule.Block.CONNECT_POINT_SIZE / 2, this._next.Location.Y + this._next._points[0].Y);
					if (this.ConnectState == ProgramModule.Block.CONNECT_STATE.RIGHT && this._next.ConnectState == ProgramModule.Block.CONNECT_STATE.RIGHT)
					{
						ProgramModule.Block.paintArrow(graphics, point, point2, ProgramModule.Block.CONNECT_POINT.BOTTOM, ProgramModule.Block.ALLOW_GREEN);
						return;
					}
					ProgramModule.Block.paintArrow(graphics, point, point2, ProgramModule.Block.CONNECT_POINT.BOTTOM, Color.Red);
				}
			}

			// Token: 0x0600100F RID: 4111 RVA: 0x0008F050 File Offset: 0x0008D250
			public static void paintArrow(Graphics graphics, Point start, Point end, ProgramModule.Block.CONNECT_POINT connectPoint, Color color)
			{
				Pen pen = new Pen(color, 2f);
				AdjustableArrowCap adjustableArrowCap = new AdjustableArrowCap(5f, 5f, true);
				pen.CustomEndCap = adjustableArrowCap;
				if (connectPoint == ProgramModule.Block.CONNECT_POINT.BOTTOM)
				{
					if (start.X == end.X && start.Y > end.Y)
					{
						Point[] array = new Point[]
						{
							new Point(start.X, start.Y),
							new Point(start.X, start.Y + 15),
							new Point(start.X - 70, start.Y + 15),
							new Point(start.X - 70, end.Y - 15),
							new Point(end.X, end.Y - 15),
							new Point(end.X, end.Y)
						};
						graphics.DrawLines(pen, array);
						return;
					}
					if (start.Y <= end.Y)
					{
						Point[] array2 = new Point[]
						{
							new Point(start.X, start.Y),
							new Point(start.X, (start.Y + end.Y) / 2),
							new Point(end.X, (start.Y + end.Y) / 2),
							new Point(end.X, end.Y)
						};
						graphics.DrawLines(pen, array2);
						return;
					}
					if (start.Y - 70 <= end.Y || ((start.X - end.X >= 100 || start.X - end.X < 0) && (end.X - start.X >= 100 || end.X - start.X <= 0)))
					{
						Point[] array3 = new Point[]
						{
							new Point(start.X, start.Y),
							new Point(start.X, start.Y + 15),
							new Point((start.X + end.X) / 2, start.Y + 15),
							new Point((start.X + end.X) / 2, end.Y - 15),
							new Point(end.X, end.Y - 15),
							new Point(end.X, end.Y)
						};
						graphics.DrawLines(pen, array3);
						return;
					}
					if (end.X > start.X)
					{
						Point[] array4 = new Point[]
						{
							new Point(start.X, start.Y),
							new Point(start.X, start.Y + 15),
							new Point(start.X - 70, start.Y + 15),
							new Point(start.X - 70, end.Y - 15),
							new Point(end.X, end.Y - 15),
							new Point(end.X, end.Y)
						};
						graphics.DrawLines(pen, array4);
						return;
					}
					Point[] array5 = new Point[]
					{
						new Point(start.X, start.Y),
						new Point(start.X, start.Y + 15),
						new Point(start.X + 70, start.Y + 15),
						new Point(start.X + 70, end.Y - 15),
						new Point(end.X, end.Y - 15),
						new Point(end.X, end.Y)
					};
					graphics.DrawLines(pen, array5);
					return;
				}
				else
				{
					if (start.X >= end.X && start.Y <= end.Y)
					{
						Point[] array6 = new Point[]
						{
							new Point(start.X, start.Y),
							new Point(start.X + 15, start.Y),
							new Point(start.X + 15, (start.Y + end.Y) / 2),
							new Point(end.X, (start.Y + end.Y) / 2),
							new Point(end.X, end.Y)
						};
						graphics.DrawLines(pen, array6);
						return;
					}
					if (start.X >= end.X && start.Y > end.Y)
					{
						Point[] array7 = new Point[]
						{
							new Point(start.X, start.Y),
							new Point(start.X + 15, start.Y),
							new Point(start.X + 15, end.Y - 15),
							new Point(end.X, end.Y - 15),
							new Point(end.X, end.Y)
						};
						graphics.DrawLines(pen, array7);
						return;
					}
					if (start.X < end.X && start.Y <= end.Y)
					{
						Point[] array8 = new Point[]
						{
							new Point(start.X, start.Y),
							new Point(end.X, start.Y),
							new Point(end.X, end.Y)
						};
						graphics.DrawLines(pen, array8);
						return;
					}
					Point[] array9 = new Point[]
					{
						new Point(start.X, start.Y),
						new Point((start.X + end.X) / 2, start.Y),
						new Point((start.X + end.X) / 2, end.Y - 15),
						new Point(end.X, end.Y - 15),
						new Point(end.X, end.Y)
					};
					graphics.DrawLines(pen, array9);
					return;
				}
			}

			// Token: 0x06001010 RID: 4112 RVA: 0x0008F79C File Offset: 0x0008D99C
			protected void paintConnectPoints(Graphics graphics)
			{
				for (int i = 0; i < 3; i++)
				{
					if (this._points[i] != Point.Empty)
					{
						graphics.DrawImage(Resources.fc_point_030, new Point(this.Location.X + this.Points[i].X, this.Location.Y + this.Points[i].Y));
					}
				}
			}

			// Token: 0x06001011 RID: 4113 RVA: 0x0008F820 File Offset: 0x0008DA20
			public virtual void paintRect(Graphics graphics, Color color, bool fill)
			{
				if (fill)
				{
					Brush brush = new SolidBrush(color);
					graphics.FillRectangle(brush, this.Location.X, this.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width, ProgramModule.Block.BLOCK_SIZE.Height);
					return;
				}
				Pen pen = new Pen(color, 4f);
				graphics.DrawRectangle(pen, this.Location.X, this.Location.Y, ProgramModule.Block.BLOCK_SIZE.Width, ProgramModule.Block.BLOCK_SIZE.Height);
			}

			// Token: 0x06001012 RID: 4114 RVA: 0x0008F8B4 File Offset: 0x0008DAB4
			protected void paintDetail(Graphics graphics, bool isBold)
			{
				int num = (isBold ? 1 : 0);
				string[] array = this.getDetail().Split(new string[] { "\r\n" }, StringSplitOptions.None);
				if (array.Count<string>() == 2)
				{
					Size size = TextRenderer.MeasureText(graphics, array[0], ProgramModule.Block._fontDetails[num]);
					graphics.DrawString(array[0], ProgramModule.Block._fontDetails[num], Brushes.Black, new PointF((float)(this.Location.X + (ProgramModule.Block.BLOCK_SIZE.Width - size.Width) / 2), (float)(this.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height / 2 - size.Height)));
					size = TextRenderer.MeasureText(graphics, array[1], ProgramModule.Block._fontDetails[num]);
					graphics.DrawString(array[1], ProgramModule.Block._fontDetails[num], Brushes.Black, new PointF((float)(this.Location.X + (ProgramModule.Block.BLOCK_SIZE.Width - size.Width) / 2), (float)(this.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height / 2)));
					return;
				}
				if (array.Count<string>() == 1)
				{
					Size size2 = TextRenderer.MeasureText(graphics, array[0], ProgramModule.Block._fontDetails[num]);
					graphics.DrawString(array[0], ProgramModule.Block._fontDetails[num], Brushes.Black, new PointF((float)(this.Location.X + (ProgramModule.Block.BLOCK_SIZE.Width - size2.Width) / 2), (float)(this.Location.Y + (ProgramModule.Block.BLOCK_SIZE.Height - size2.Height) / 2)));
				}
			}

			// Token: 0x06001013 RID: 4115 RVA: 0x0008FA4C File Offset: 0x0008DC4C
			public virtual void OnPaintBlock(Graphics graphics, bool isDetail, int index = -1, bool isPrint = false)
			{
				if (this.Next != null && index == -1)
				{
					this.Next.OnPaintBlock(graphics, isDetail, index, isPrint);
				}
			}

			// Token: 0x06001014 RID: 4116 RVA: 0x0008FA6A File Offset: 0x0008DC6A
			public virtual void OnPaintBlockSelect(Graphics graphics)
			{
				this.paintRectBlock(graphics, Color.Blue, false);
			}

			// Token: 0x06001015 RID: 4117 RVA: 0x0008FA7C File Offset: 0x0008DC7C
			public virtual void OnPaintBlockBreakPoint(Graphics graphics)
			{
				if (this._breakPoint)
				{
					Brush brush = new SolidBrush(Color.Red);
					graphics.FillEllipse(brush, new Rectangle(this.LocationBlock.X + 20 - ProgramModule.Block.BREAK_RADIUS, this.LocationBlock.Y - ProgramModule.Block.BREAK_RADIUS, ProgramModule.Block.BREAK_RADIUS * 2, ProgramModule.Block.BREAK_RADIUS * 2));
				}
			}

			// Token: 0x06001016 RID: 4118 RVA: 0x0008FAE4 File Offset: 0x0008DCE4
			public virtual void OnPaintBlockGuide(Graphics graphics, ProgramModule.Block.CONNECT_BLOCK connectBlock)
			{
				Pen pen = new Pen(Color.Blue, 4f);
				if (connectBlock == ProgramModule.Block.CONNECT_BLOCK.UP)
				{
					graphics.DrawLine(pen, this.LocationBlock, new Point(this.LocationBlock.X + this.SizeBlock.Width, this.LocationBlock.Y));
					return;
				}
				if (connectBlock == ProgramModule.Block.CONNECT_BLOCK.DOWN)
				{
					graphics.DrawLine(pen, new Point(this.LocationBlock.X, this.LocationBlock.Y + this.SizeBlock.Height), new Point(this.LocationBlock.X + this.SizeBlock.Width, this.LocationBlock.Y + this.SizeBlock.Height));
				}
			}

			// Token: 0x06001017 RID: 4119 RVA: 0x0008FBC0 File Offset: 0x0008DDC0
			public virtual void paintRectBlock(Graphics graphics, Color color, bool fill)
			{
				if (fill)
				{
					Brush brush = new SolidBrush(color);
					graphics.FillRectangle(brush, this.LocationBlock.X, this.LocationBlock.Y, this.SizeBlock.Width, this.SizeBlock.Height);
					return;
				}
				Pen pen = new Pen(color, 2f);
				graphics.DrawRectangle(pen, this.LocationBlock.X, this.LocationBlock.Y, this.SizeBlock.Width, this.SizeBlock.Height);
			}

			// Token: 0x06001018 RID: 4120 RVA: 0x0008FC64 File Offset: 0x0008DE64
			public virtual void updateBlock()
			{
				bool flag = false;
				if (FlowchartWindow.Instance != null && FlowchartWindow.Instance.Area != null)
				{
					flag = !FlowchartWindow.Instance.Area.DisplayControl;
				}
				else if (NetworkWindow.Instance != null && NetworkWindow.Instance.FlowchartArea != null)
				{
					flag = !NetworkWindow.Instance.FlowchartArea.DisplayControl;
				}
				int width = TextRenderer.MeasureText(this.getDetailBlock(flag), ProgramModule.Block._fontBlock).Width;
				this._sizeBlock = new Size(Math.Max(ProgramModule.Block.BLOCK_SIZE.Width, Resources.bp_block_010.Width + width + Resources.bp_block_012.Width), ProgramModule.Block.LINE_HEIGHT * this.LineCount);
			}

			// Token: 0x06001019 RID: 4121 RVA: 0x0008FD18 File Offset: 0x0008DF18
			public virtual void createBlockControls()
			{
				this.updateBlock();
			}

			// Token: 0x0600101A RID: 4122 RVA: 0x0008FD20 File Offset: 0x0008DF20
			public virtual void destroyBlockControls()
			{
				this.Controls.Clear();
			}

			// Token: 0x0600101B RID: 4123 RVA: 0x000153E3 File Offset: 0x000135E3
			public virtual void updateData()
			{
			}

			// Token: 0x0600101C RID: 4124 RVA: 0x0008FD30 File Offset: 0x0008DF30
			public virtual void updateLocation(int x)
			{
				if (this.Next != null)
				{
					this.Next.LocationBlock = new Point(x, this.LocationBlock.Y + this._sizeBlock.Height);
					this.Next.updateLocation(x);
				}
			}

			// Token: 0x0600101D RID: 4125 RVA: 0x0008FD7C File Offset: 0x0008DF7C
			public virtual void setControlVisible(bool on)
			{
				foreach (Control control in this.Controls)
				{
					control.Visible = on;
				}
				if (this.Next != null)
				{
					this.Next.setControlVisible(on);
				}
			}

			// Token: 0x0600101E RID: 4126 RVA: 0x0008FDE4 File Offset: 0x0008DFE4
			public virtual void updateControlVisible(List<Rectangle> rects)
			{
				foreach (Control control in this.Controls)
				{
					bool flag = true;
					foreach (Rectangle rectangle in rects)
					{
						if (((rectangle.X <= control.Left && control.Left < rectangle.X + rectangle.Width) || (control.Left <= rectangle.X && rectangle.X < control.Left + control.Width)) && ((rectangle.Y <= control.Top && control.Top < rectangle.Y + rectangle.Height) || (control.Top <= rectangle.Y && rectangle.Y < control.Top + control.Height)))
						{
							flag = false;
							break;
						}
					}
					if (control.Visible != flag)
					{
						control.Visible = flag;
					}
				}
				if (this.Next != null)
				{
					this.Next.updateControlVisible(rects);
				}
			}

			// Token: 0x0600101F RID: 4127 RVA: 0x0008FF34 File Offset: 0x0008E134
			public Size getConnectedBlocksSize()
			{
				Size size = default(Size);
				for (ProgramModule.Block block = this; block != null; block = block.Next)
				{
					size.Width = Math.Max(size.Width, block.SizeBlock.Width);
					size.Height += block.SizeBlock.Height;
				}
				return size;
			}

			// Token: 0x06001020 RID: 4128 RVA: 0x0008FF98 File Offset: 0x0008E198
			public virtual ProgramModule.Block.CONNECT_BLOCK IsHit(ProgramModule.Block block)
			{
				Rectangle rectangle = new Rectangle(block.LocationBlock.X, block.LocationBlock.Y - (int)((float)ProgramModule.Block.LINE_HEIGHT * 0.5f), block.SizeBlock.Width, block.SizeBlock.Height + ProgramModule.Block.LINE_HEIGHT);
				if (((this.LocationBlock.X > rectangle.X || rectangle.X > this.LocationBlock.X + this._sizeBlock.Width) && (rectangle.X > this.LocationBlock.X || this.LocationBlock.X > rectangle.X + rectangle.Width)) || ((this.LocationBlock.Y > rectangle.Y || rectangle.Y > this.LocationBlock.Y + this._sizeBlock.Height) && (rectangle.Y > this.LocationBlock.Y || this.LocationBlock.Y > rectangle.Y + rectangle.Height)))
				{
					return ProgramModule.Block.CONNECT_BLOCK.INVALID;
				}
				if (this.LocationBlock.Y < rectangle.Y)
				{
					return ProgramModule.Block.CONNECT_BLOCK.DOWN;
				}
				return ProgramModule.Block.CONNECT_BLOCK.UP;
			}

			// Token: 0x06001021 RID: 4129 RVA: 0x000900FC File Offset: 0x0008E2FC
			public void getBlockList(List<ProgramModule.Block> blocks)
			{
				ProgramModule.Block block = this;
				while (block != null)
				{
					blocks.Add(block);
					if (block is ProgramModule.BlockBranch)
					{
						ProgramModule.BlockBranch blockBranch = (ProgramModule.BlockBranch)block;
						if (blockBranch.Branches == null)
						{
							if (blockBranch is ProgramModule.BlockIf)
							{
								ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)blockBranch;
								if (blockIf.Else != null && !blocks.Contains(blockIf.Else))
								{
									blockIf.Else.getBlockList(blocks);
								}
							}
						}
						else
						{
							for (int i = 0; i < blockBranch.Branches.Count; i++)
							{
								if (blockBranch.Branches[i] != null && !blocks.Contains(blockBranch.Branches[i]))
								{
									blockBranch.Branches[i].getBlockList(blocks);
								}
							}
						}
					}
					if (blocks.Contains(block.Next))
					{
						block = null;
					}
					else
					{
						block = block.Next;
					}
				}
			}

			// Token: 0x06001022 RID: 4130 RVA: 0x000901D0 File Offset: 0x0008E3D0
			public virtual void getProgram(List<ProgramModule.Block> blockList, List<string> codeList, int indent)
			{
				blockList.Add(this);
				if (this._next != null)
				{
					int num = blockList.IndexOf(this._next);
					if (num >= 0)
					{
						string text = codeList[codeList.Count - 1] + "\r\n";
						this.addIndent(ref text, indent + 2);
						text = text + "GOTO:" + num.ToString();
						codeList[codeList.Count - 1] = text;
						return;
					}
					if (this._next.GetType() == typeof(ProgramModule.BlockEnd))
					{
						string text2 = codeList[codeList.Count - 1] + "\r\n";
						this.addIndent(ref text2, indent + 2);
						text2 += "GOTO:[end]";
						codeList[codeList.Count - 1] = text2;
						return;
					}
					this._next.getProgram(blockList, codeList, indent);
				}
			}

			// Token: 0x06001023 RID: 4131 RVA: 0x000902B4 File Offset: 0x0008E4B4
			public virtual void convertBlock(List<ProgramModule.Block> checkedBlocks, List<ProgramModule.Block> newBlocks)
			{
				this.createBlockControls();
				checkedBlocks.Add(this);
				if (this._next != null)
				{
					if (this._next is ProgramModule.BlockLoopEnd)
					{
						ProgramModule.BlockJump blockJump = new ProgramModule.BlockJump();
						newBlocks.Add(blockJump);
						blockJump.JumpTemp = this._next;
						this.Next = blockJump;
						blockJump.Before = this;
						return;
					}
					if (checkedBlocks.Contains(this._next))
					{
						ProgramModule.BlockJump blockJump2 = new ProgramModule.BlockJump();
						newBlocks.Add(blockJump2);
						blockJump2.Before = this;
						blockJump2.JumpTemp = this._next;
						this._next = blockJump2;
						return;
					}
					this._next.Before = this;
					this._next.convertBlock(checkedBlocks, newBlocks);
				}
			}

			// Token: 0x06001024 RID: 4132 RVA: 0x0009035D File Offset: 0x0008E55D
			public virtual void convertFlowchart(List<ProgramModule.Block> checkedBlocks)
			{
				checkedBlocks.Add(this);
				if (this._next != null && !checkedBlocks.Contains(this._next))
				{
					this._next.convertFlowchart(checkedBlocks);
				}
			}

			// Token: 0x06001025 RID: 4133 RVA: 0x00090388 File Offset: 0x0008E588
			public void disableControls()
			{
				foreach (Control control in this.Controls)
				{
					control.Enabled = false;
				}
			}

			// Token: 0x06001026 RID: 4134 RVA: 0x000903DC File Offset: 0x0008E5DC
			public virtual string getDetail()
			{
				return "";
			}

			// Token: 0x06001027 RID: 4135 RVA: 0x000903E3 File Offset: 0x0008E5E3
			public virtual string getDetailBlock(bool isPrint)
			{
				return this.getDetail().Replace("\r\n", " ");
			}

			// Token: 0x06001028 RID: 4136 RVA: 0x0007512D File Offset: 0x0007332D
			public virtual int getUsedMemory()
			{
				return 0;
			}

			// Token: 0x06001029 RID: 4137 RVA: 0x000903FA File Offset: 0x0008E5FA
			public virtual bool isConnectable(ProgramModule.Block block)
			{
				return block != this;
			}

			// Token: 0x0600102A RID: 4138 RVA: 0x0007968A File Offset: 0x0007788A
			public virtual bool isIconBlock()
			{
				return true;
			}

			// Token: 0x0600102B RID: 4139 RVA: 0x00090404 File Offset: 0x0008E604
			public virtual ProgramModule.Block.CONNECT_STATE updateConnectState(List<ProgramModule.Block> blocks)
			{
				blocks.Add(this);
				this.ConnectState = ProgramModule.Block.CONNECT_STATE.START;
				if (this._next == null)
				{
					this.ConnectState = ProgramModule.Block.CONNECT_STATE.ERROR;
				}
				else if (blocks.IndexOf(this._next) == -1)
				{
					this.ConnectState = this._next.updateConnectState(blocks);
				}
				else
				{
					this.ConnectState = this._next.ConnectState;
				}
				return this.ConnectState;
			}

			// Token: 0x0600102C RID: 4140 RVA: 0x0009046C File Offset: 0x0008E66C
			public bool isIncluded(Rectangle rect)
			{
				return ((rect.X <= this.Location.X && rect.X + rect.Width >= this.Location.X) || (this.Location.X <= rect.X && rect.X <= this.Location.X + ProgramModule.Block.BLOCK_SIZE.Width)) && ((rect.Y <= this.Location.Y && rect.Y + rect.Height >= this.Location.Y) || (this.Location.Y <= rect.Y && rect.Y <= this.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height));
			}

			// Token: 0x0600102D RID: 4141 RVA: 0x00090560 File Offset: 0x0008E760
			public bool isIncludedBlock(Rectangle rect)
			{
				return ((rect.X <= this.LocationBlock.X && rect.X + rect.Width >= this.LocationBlock.X) || (this.LocationBlock.X <= rect.X && rect.X <= this.LocationBlock.X + this.SizeBlock.Width)) && ((rect.Y <= this.LocationBlock.Y && rect.Y + rect.Height >= this.LocationBlock.Y) || (this.LocationBlock.Y <= rect.Y && rect.Y <= this.LocationBlock.Y + this.SizeBlock.Height));
			}

			// Token: 0x0600102E RID: 4142 RVA: 0x0009065C File Offset: 0x0008E85C
			public bool isIncluding(Point point)
			{
				return this.Location.X - ProgramModule.Block.CONNECT_POINT_SIZE / 2 <= point.X && point.X <= this.Location.X + ProgramModule.Block.BLOCK_SIZE.Width + ProgramModule.Block.CONNECT_POINT_SIZE / 2 && this.Location.Y - ProgramModule.Block.CONNECT_POINT_SIZE / 2 <= point.Y && point.Y <= this.Location.Y + ProgramModule.Block.BLOCK_SIZE.Height + ProgramModule.Block.CONNECT_POINT_SIZE / 2;
			}

			// Token: 0x0600102F RID: 4143 RVA: 0x00090700 File Offset: 0x0008E900
			public virtual bool isIncludingBlock(Point point)
			{
				return this.LocationBlock.X <= point.X && point.X <= this.LocationBlock.X + this.SizeBlock.Width && this.LocationBlock.Y <= point.Y && point.Y <= this.LocationBlock.Y + this.SizeBlock.Height;
			}

			// Token: 0x06001030 RID: 4144 RVA: 0x0009078C File Offset: 0x0008E98C
			public ProgramModule.Block.CONNECT_POINT isIncludingConnectPoint(Point point)
			{
				for (int i = 1; i < 3; i++)
				{
					if (this._points[i] != Point.Empty && this.Location.X + this._points[i].X <= point.X && point.X <= this.Location.X + this._points[i].X + ProgramModule.Block.CONNECT_POINT_SIZE && this.Location.Y + this._points[i].Y <= point.Y && point.Y <= this.Location.Y + this._points[i].Y + ProgramModule.Block.CONNECT_POINT_SIZE)
					{
						return (ProgramModule.Block.CONNECT_POINT)i;
					}
				}
				return ProgramModule.Block.CONNECT_POINT.NONE;
			}

			// Token: 0x06001031 RID: 4145 RVA: 0x0009087C File Offset: 0x0008EA7C
			public virtual void setConnect(ProgramModule.Block.CONNECT_POINT point, ProgramModule.Block block)
			{
				this._next = block;
			}

			// Token: 0x06001032 RID: 4146 RVA: 0x00090888 File Offset: 0x0008EA88
			protected void addIndent(ref string text, int indent)
			{
				for (int i = 0; i < indent; i++)
				{
					text += "  ";
				}
			}

			// Token: 0x06001033 RID: 4147 RVA: 0x000908AF File Offset: 0x0008EAAF
			public void addHistory()
			{
				if (this.Updated)
				{
					this.Updated = false;
					if (FlowchartWindow.Instance != null)
					{
						FlowchartWindow.Instance.addHistory(true);
						return;
					}
					NetworkWindow.Instance.addHistory(true);
				}
			}

			// Token: 0x040007DA RID: 2010
			public static Size BLOCK_SIZE = new Size(Resources.fc_block_000.Width, Resources.fc_block_000.Height);

			// Token: 0x040007DB RID: 2011
			public static int CONNECT_POINT_SIZE = Resources.fc_point_030.Width;

			// Token: 0x040007DC RID: 2012
			protected static readonly int BREAK_RADIUS = 12;

			// Token: 0x040007DD RID: 2013
			protected static readonly int LINE_HEIGHT = 36;

			// Token: 0x040007DE RID: 2014
			protected static readonly int BLOCK_COMPONENT_OFFSET = 8;

			// Token: 0x040007DF RID: 2015
			protected static readonly int BLOCK_DETAIL_OFFSET = 5;

			// Token: 0x040007E0 RID: 2016
			protected static Color ALLOW_GREEN = Color.FromArgb(90, 185, 170);

			// Token: 0x040007E1 RID: 2017
			private Point[] _points = new Point[3];

			// Token: 0x040007E2 RID: 2018
			private static Font _font = new Font("メイリオ", 15f, FontStyle.Regular, GraphicsUnit.Point, 128);

			// Token: 0x040007E3 RID: 2019
			private static Font[] _fontDetails = new Font[]
			{
				new Font("メイリオ", 9f, FontStyle.Regular, GraphicsUnit.Point, 128),
				new Font("メイリオ", 9f, FontStyle.Bold, GraphicsUnit.Point, 128)
			};

			// Token: 0x040007E4 RID: 2020
			protected static Font _fontBlock = new Font("メイリオ", 15f, FontStyle.Regular, GraphicsUnit.Point, 128);

			// Token: 0x040007E5 RID: 2021
			private bool _breakPoint;

			// Token: 0x040007E6 RID: 2022
			private bool _selected;

			// Token: 0x040007E7 RID: 2023
			private bool _updated;

			// Token: 0x040007E8 RID: 2024
			private ProgramModule.Block.CONNECT_STATE _connectState;

			// Token: 0x040007E9 RID: 2025
			private int _loopBlockCount;

			// Token: 0x040007EA RID: 2026
			private ProgramModule.Block _before;

			// Token: 0x040007EB RID: 2027
			private ProgramModule.Block _next;

			// Token: 0x040007EC RID: 2028
			private int _lineCount = 1;

			// Token: 0x040007ED RID: 2029
			private Point _location;

			// Token: 0x040007EE RID: 2030
			private Point _locationBlock;

			// Token: 0x040007EF RID: 2031
			private Size _sizeBlock;

			// Token: 0x040007F0 RID: 2032
			private int _connectIndex = -1;

			// Token: 0x040007F1 RID: 2033
			private int _connectIndexBefore = -1;

			// Token: 0x040007F2 RID: 2034
			[XmlIgnore]
			public ProgramModules.ROUTINE Routine;

			// Token: 0x02000114 RID: 276
			public enum COMMAND_NUMBER
			{
				// Token: 0x04000AED RID: 2797
				INVALID,
				// Token: 0x04000AEE RID: 2798
				START,
				// Token: 0x04000AEF RID: 2799
				END,
				// Token: 0x04000AF0 RID: 2800
				LED_BEGIN,
				// Token: 0x04000AF1 RID: 2801
				LED_RGB_TIME_ON = 3,
				// Token: 0x04000AF2 RID: 2802
				LED_RGB_FADE_IN,
				// Token: 0x04000AF3 RID: 2803
				LED_RGB_FADE_OUT,
				// Token: 0x04000AF4 RID: 2804
				LED_RGB_ON,
				// Token: 0x04000AF5 RID: 2805
				LED_BLUE_TIME_ON,
				// Token: 0x04000AF6 RID: 2806
				LED_BLUE_FADE_IN,
				// Token: 0x04000AF7 RID: 2807
				LED_BLUE_FADE_OUT,
				// Token: 0x04000AF8 RID: 2808
				LED_BLUE_ON,
				// Token: 0x04000AF9 RID: 2809
				LED_RED_TIME_ON,
				// Token: 0x04000AFA RID: 2810
				LED_RED_FADE_IN,
				// Token: 0x04000AFB RID: 2811
				LED_RED_FADE_OUT,
				// Token: 0x04000AFC RID: 2812
				LED_RED_ON,
				// Token: 0x04000AFD RID: 2813
				LED_YELLOW_TIME_ON,
				// Token: 0x04000AFE RID: 2814
				LED_YELLOW_FADE_IN,
				// Token: 0x04000AFF RID: 2815
				LED_YELLOW_FADE_OUT,
				// Token: 0x04000B00 RID: 2816
				LED_YELLOW_ON,
				// Token: 0x04000B01 RID: 2817
				LED_CYAN_TIME_ON,
				// Token: 0x04000B02 RID: 2818
				LED_CYAN_FADE_IN,
				// Token: 0x04000B03 RID: 2819
				LED_CYAN_FADE_OUT,
				// Token: 0x04000B04 RID: 2820
				LED_CYAN_ON,
				// Token: 0x04000B05 RID: 2821
				LED_WHITE_TIME_ON,
				// Token: 0x04000B06 RID: 2822
				LED_WHITE_FADE_IN,
				// Token: 0x04000B07 RID: 2823
				LED_WHITE_FADE_OUT,
				// Token: 0x04000B08 RID: 2824
				LED_WHITE_ON,
				// Token: 0x04000B09 RID: 2825
				LED_MAGENTA_TIME_ON,
				// Token: 0x04000B0A RID: 2826
				LED_MAGENTA_FADE_IN,
				// Token: 0x04000B0B RID: 2827
				LED_MAGENTA_FADE_OUT,
				// Token: 0x04000B0C RID: 2828
				LED_MAGENTA_ON,
				// Token: 0x04000B0D RID: 2829
				LED_GREEN_TIME_ON,
				// Token: 0x04000B0E RID: 2830
				LED_GREEN_FADE_IN,
				// Token: 0x04000B0F RID: 2831
				LED_GREEN_FADE_OUT,
				// Token: 0x04000B10 RID: 2832
				LED_GREEN_ON,
				// Token: 0x04000B11 RID: 2833
				LED_OFF,
				// Token: 0x04000B12 RID: 2834
				LED_END = 35,
				// Token: 0x04000B13 RID: 2835
				SOUND_BEGIN,
				// Token: 0x04000B14 RID: 2836
				SOUND_BEEP_1 = 36,
				// Token: 0x04000B15 RID: 2837
				SOUND_BEEP_2,
				// Token: 0x04000B16 RID: 2838
				SOUND_BEEP_3,
				// Token: 0x04000B17 RID: 2839
				SOUND_PLAY,
				// Token: 0x04000B18 RID: 2840
				SOUND_PLAY_LOOP,
				// Token: 0x04000B19 RID: 2841
				SOUND_STOP,
				// Token: 0x04000B1A RID: 2842
				SOUND_END = 41,
				// Token: 0x04000B1B RID: 2843
				WAIT,
				// Token: 0x04000B1C RID: 2844
				COUNTER_BEGIN,
				// Token: 0x04000B1D RID: 2845
				COUNTER_START = 43,
				// Token: 0x04000B1E RID: 2846
				COUNTER_PAUSE,
				// Token: 0x04000B1F RID: 2847
				COUNTER_STOP,
				// Token: 0x04000B20 RID: 2848
				COUNTER_END = 45,
				// Token: 0x04000B21 RID: 2849
				IF_BEGIN,
				// Token: 0x04000B22 RID: 2850
				IF_BUTTON_ON = 46,
				// Token: 0x04000B23 RID: 2851
				IF_BUTTON_OFF,
				// Token: 0x04000B24 RID: 2852
				IF_LIGHT_BRIGHT,
				// Token: 0x04000B25 RID: 2853
				IF_LIGHT_DARK,
				// Token: 0x04000B26 RID: 2854
				IF_SOUND_OFF,
				// Token: 0x04000B27 RID: 2855
				IF_SOUND_ON,
				// Token: 0x04000B28 RID: 2856
				IF_TEMPERATURE_COMPARE_GREATER_CONST,
				// Token: 0x04000B29 RID: 2857
				IF_TEMPERATURE_COMPARE_LESS_CONST,
				// Token: 0x04000B2A RID: 2858
				IF_TEMPERATURE_COMPARE_EQUAL_CONST,
				// Token: 0x04000B2B RID: 2859
				IF_TEMPERATURE_COMPARE_GREATER_VARIABLE,
				// Token: 0x04000B2C RID: 2860
				IF_TEMPERATURE_COMPARE_LESS_VARIABLE,
				// Token: 0x04000B2D RID: 2861
				IF_TEMPERATURE_COMPARE_EQUAL_VARIABLE,
				// Token: 0x04000B2E RID: 2862
				IF_TIME_COMPARE_GREATER,
				// Token: 0x04000B2F RID: 2863
				IF_TIME_COMPARE_EQUAL,
				// Token: 0x04000B30 RID: 2864
				IF_TIME_COMPARE_LESS,
				// Token: 0x04000B31 RID: 2865
				IF_ALARAM_ON,
				// Token: 0x04000B32 RID: 2866
				IF_ALARAM_OFF,
				// Token: 0x04000B33 RID: 2867
				IF_TIMER_ON,
				// Token: 0x04000B34 RID: 2868
				IF_TIMER_OFF,
				// Token: 0x04000B35 RID: 2869
				IF_COUNTER_COMPARE_GREATER,
				// Token: 0x04000B36 RID: 2870
				IF_COUNTER_COMPARE_EQUAL,
				// Token: 0x04000B37 RID: 2871
				IF_COUNTER_COMPARE_LESS,
				// Token: 0x04000B38 RID: 2872
				IF_VARIABLE_COMPARE_GREATER_CONST,
				// Token: 0x04000B39 RID: 2873
				IF_VARIABLE_COMPARE_EQUAL_CONST,
				// Token: 0x04000B3A RID: 2874
				IF_VARIABLE_COMPARE_LESS_CONST,
				// Token: 0x04000B3B RID: 2875
				IF_VARIABLE_COMPARE_GREATER_VARIABLE,
				// Token: 0x04000B3C RID: 2876
				IF_VARIABLE_COMPARE_EQUAL_VARIABLE,
				// Token: 0x04000B3D RID: 2877
				IF_VARIABLE_COMPARE_LESS_VARIABLE,
				// Token: 0x04000B3E RID: 2878
				IF_ELSE,
				// Token: 0x04000B3F RID: 2879
				IF_RANDOM,
				// Token: 0x04000B40 RID: 2880
				IF_END = 75,
				// Token: 0x04000B41 RID: 2881
				LOOP_START,
				// Token: 0x04000B42 RID: 2882
				LOOP_END,
				// Token: 0x04000B43 RID: 2883
				SUBROUTINE,
				// Token: 0x04000B44 RID: 2884
				ARITHMETIC_BEGIN,
				// Token: 0x04000B45 RID: 2885
				ARITHMETIC_EQUAL_CONST = 79,
				// Token: 0x04000B46 RID: 2886
				ARITHMETIC_EQUAL_VARIABLE,
				// Token: 0x04000B47 RID: 2887
				ARITHMETIC_EQUAL_TEMPERATURE,
				// Token: 0x04000B48 RID: 2888
				ARITHMETIC_ADD_CONST,
				// Token: 0x04000B49 RID: 2889
				ARITHMETIC_ADD_VARIABLE,
				// Token: 0x04000B4A RID: 2890
				ARITHMETIC_ADD_TEMPERATURE,
				// Token: 0x04000B4B RID: 2891
				ARITHMETIC_SUB_CONST,
				// Token: 0x04000B4C RID: 2892
				ARITHMETIC_SUB_VARIABLE,
				// Token: 0x04000B4D RID: 2893
				ARITHMETIC_SUB_TEMPERATURE,
				// Token: 0x04000B4E RID: 2894
				ARITHMETIC_END = 87,
				// Token: 0x04000B4F RID: 2895
				IF_SECOND_BEGIN,
				// Token: 0x04000B50 RID: 2896
				IF_LIGHT_CONST_BRIGHT = 88,
				// Token: 0x04000B51 RID: 2897
				IF_LIGHT_CONST_SAME,
				// Token: 0x04000B52 RID: 2898
				IF_LIGHT_CONST_DARK,
				// Token: 0x04000B53 RID: 2899
				IF_LIGHT_VARIABLE_BRIGHT,
				// Token: 0x04000B54 RID: 2900
				IF_LIGHT_VARIABLE_SAME,
				// Token: 0x04000B55 RID: 2901
				IF_LIGHT_VARIABLE_DARK,
				// Token: 0x04000B56 RID: 2902
				IF_SECOND_END = 93,
				// Token: 0x04000B57 RID: 2903
				ARITHMETIC_SECOND_BEGIN,
				// Token: 0x04000B58 RID: 2904
				ARITHMETIC_EQUAL_LIGHT = 94,
				// Token: 0x04000B59 RID: 2905
				ARITHMETIC_ADD_LIGHT,
				// Token: 0x04000B5A RID: 2906
				ARITHMETIC_SUB_LIGHT,
				// Token: 0x04000B5B RID: 2907
				ARITHMETIC_SECOND_END = 96,
				// Token: 0x04000B5C RID: 2908
				DISPLAY_BEGIN,
				// Token: 0x04000B5D RID: 2909
				DISPLAY_TIME = 97,
				// Token: 0x04000B5E RID: 2910
				DISPLAY_TEMPERATURE,
				// Token: 0x04000B5F RID: 2911
				DISPLAY_VARIABLE,
				// Token: 0x04000B60 RID: 2912
				DISPLAY_COUNTER,
				// Token: 0x04000B61 RID: 2913
				DISPLAY_LIGHT,
				// Token: 0x04000B62 RID: 2914
				DISPLAY_WAIT,
				// Token: 0x04000B63 RID: 2915
				DISPLAY_INVALID,
				// Token: 0x04000B64 RID: 2916
				DISPLAY_END = 103,
				// Token: 0x04000B65 RID: 2917
				LOOP_END_BEGIN,
				// Token: 0x04000B66 RID: 2918
				LOOP_END_BUTTON_ON = 104,
				// Token: 0x04000B67 RID: 2919
				LOOP_END_BUTTON_OFF,
				// Token: 0x04000B68 RID: 2920
				LOOP_END_LIGHT_BRIGHT,
				// Token: 0x04000B69 RID: 2921
				LOOP_END_LIGHT_DARK,
				// Token: 0x04000B6A RID: 2922
				LOOP_END_LIGHT_CONST_BRIGHT,
				// Token: 0x04000B6B RID: 2923
				LOOP_END_LIGHT_CONST_SAME,
				// Token: 0x04000B6C RID: 2924
				LOOP_END_LIGHT_CONST_DARK,
				// Token: 0x04000B6D RID: 2925
				LOOP_END_LIGHT_VARIABLE_BRIGHT,
				// Token: 0x04000B6E RID: 2926
				LOOP_END_LIGHT_VARIABLE_SAME,
				// Token: 0x04000B6F RID: 2927
				LOOP_END_LIGHT_VARIABLE_DARK,
				// Token: 0x04000B70 RID: 2928
				LOOP_END_SOUND_OFF,
				// Token: 0x04000B71 RID: 2929
				LOOP_END_SOUND_ON,
				// Token: 0x04000B72 RID: 2930
				LOOP_END_TEMPERATURE_COMPARE_GREATER_CONST,
				// Token: 0x04000B73 RID: 2931
				LOOP_END_TEMPERATURE_COMPARE_LESS_CONST,
				// Token: 0x04000B74 RID: 2932
				LOOP_END_TEMPERATURE_COMPARE_EQUAL_CONST,
				// Token: 0x04000B75 RID: 2933
				LOOP_END_TEMPERATURE_COMPARE_GREATER_VARIABLE,
				// Token: 0x04000B76 RID: 2934
				LOOP_END_TEMPERATURE_COMPARE_LESS_VARIABLE,
				// Token: 0x04000B77 RID: 2935
				LOOP_END_TEMPERATURE_COMPARE_EQUAL_VARIABLE,
				// Token: 0x04000B78 RID: 2936
				LOOP_END_TIME_COMPARE_GREATER,
				// Token: 0x04000B79 RID: 2937
				LOOP_END_TIME_COMPARE_EQUAL,
				// Token: 0x04000B7A RID: 2938
				LOOP_END_TIME_COMPARE_LESS,
				// Token: 0x04000B7B RID: 2939
				LOOP_END_ALARAM_ON,
				// Token: 0x04000B7C RID: 2940
				LOOP_END_ALARAM_OFF,
				// Token: 0x04000B7D RID: 2941
				LOOP_END_TIMER_ON,
				// Token: 0x04000B7E RID: 2942
				LOOP_END_TIMER_OFF,
				// Token: 0x04000B7F RID: 2943
				LOOP_END_COUNTER_COMPARE_GREATER,
				// Token: 0x04000B80 RID: 2944
				LOOP_END_COUNTER_COMPARE_EQUAL,
				// Token: 0x04000B81 RID: 2945
				LOOP_END_COUNTER_COMPARE_LESS,
				// Token: 0x04000B82 RID: 2946
				LOOP_END_VARIABLE_COMPARE_GREATER_CONST,
				// Token: 0x04000B83 RID: 2947
				LOOP_END_VARIABLE_COMPARE_EQUAL_CONST,
				// Token: 0x04000B84 RID: 2948
				LOOP_END_VARIABLE_COMPARE_LESS_CONST,
				// Token: 0x04000B85 RID: 2949
				LOOP_END_VARIABLE_COMPARE_GREATER_VARIABLE,
				// Token: 0x04000B86 RID: 2950
				LOOP_END_VARIABLE_COMPARE_EQUAL_VARIABLE,
				// Token: 0x04000B87 RID: 2951
				LOOP_END_VARIABLE_COMPARE_LESS_VARIABLE,
				// Token: 0x04000B88 RID: 2952
				LOOP_END_END = 137,
				// Token: 0x04000B89 RID: 2953
				USBOUT_BEGIN,
				// Token: 0x04000B8A RID: 2954
				USBOUT_ON = 138,
				// Token: 0x04000B8B RID: 2955
				USBOUT_ON_TIME,
				// Token: 0x04000B8C RID: 2956
				USBOUT_OFF,
				// Token: 0x04000B8D RID: 2957
				USBOUT_END = 140,
				// Token: 0x04000B8E RID: 2958
				IF_THIRD_BEGIN,
				// Token: 0x04000B8F RID: 2959
				IF_USBIN_ON = 141,
				// Token: 0x04000B90 RID: 2960
				IF_USBIN_OFF,
				// Token: 0x04000B91 RID: 2961
				IF_THIRD_END = 142,
				// Token: 0x04000B92 RID: 2962
				LOOP_END_SECOND_BEGIN,
				// Token: 0x04000B93 RID: 2963
				LOOP_END_USBIN_ON = 143,
				// Token: 0x04000B94 RID: 2964
				LOOP_END_USBIN_OFF,
				// Token: 0x04000B95 RID: 2965
				LOOP_END_SECOND_END = 144
			}

			// Token: 0x02000115 RID: 277
			public enum CONNECT_POINT
			{
				// Token: 0x04000B97 RID: 2967
				TOP,
				// Token: 0x04000B98 RID: 2968
				BOTTOM,
				// Token: 0x04000B99 RID: 2969
				RIGHT,
				// Token: 0x04000B9A RID: 2970
				MAX,
				// Token: 0x04000B9B RID: 2971
				NONE
			}

			// Token: 0x02000116 RID: 278
			public enum CONNECT_STATE
			{
				// Token: 0x04000B9D RID: 2973
				ERROR,
				// Token: 0x04000B9E RID: 2974
				START,
				// Token: 0x04000B9F RID: 2975
				RIGHT
			}

			// Token: 0x02000117 RID: 279
			public enum CONNECT_BLOCK
			{
				// Token: 0x04000BA1 RID: 2977
				INVALID = -1,
				// Token: 0x04000BA2 RID: 2978
				BRANCH_FIRST,
				// Token: 0x04000BA3 RID: 2979
				BRANCH_SECOND,
				// Token: 0x04000BA4 RID: 2980
				UP,
				// Token: 0x04000BA5 RID: 2981
				DOWN
			}
		}
	}
}
