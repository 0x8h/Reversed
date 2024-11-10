using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Clock
{
	// Token: 0x0200004A RID: 74
	public class ProgramModules
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060007F8 RID: 2040 RVA: 0x0005B366 File Offset: 0x00059566
		// (set) Token: 0x060007F9 RID: 2041 RVA: 0x0005B36E File Offset: 0x0005956E
		public ProgramModule[] Programs
		{
			get
			{
				return this._programs;
			}
			set
			{
				this._programs = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060007FA RID: 2042 RVA: 0x0005B377 File Offset: 0x00059577
		// (set) Token: 0x060007FB RID: 2043 RVA: 0x0005B37F File Offset: 0x0005957F
		public ReportModule Report
		{
			get
			{
				return this._report;
			}
			set
			{
				this._report = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x0005B388 File Offset: 0x00059588
		[XmlIgnore]
		public List<ProgramModule.Block> WriteAllBlocks { get; } = new List<ProgramModule.Block>();

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x0005B390 File Offset: 0x00059590
		// (set) Token: 0x060007FE RID: 2046 RVA: 0x0005B398 File Offset: 0x00059598
		public bool IsBlockMode { get; set; }

		// Token: 0x060007FF RID: 2047 RVA: 0x0005B3A4 File Offset: 0x000595A4
		public ProgramModules()
		{
			for (int i = 0; i < 5; i++)
			{
				this._programs[i] = new ProgramModule();
			}
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0005B3F4 File Offset: 0x000595F4
		public void initialize(bool preConnect = false)
		{
			this.Version = ProgramModules.CurrentVersion;
			this._programs[0].initialize(preConnect, ProgramModule.BlockEvent.OBJECT_TYPE.INVALID);
			this._programs[0].Name = ProgramModules.ROUTINE_NAMES[0];
			for (int i = 1; i < 5; i++)
			{
				this._programs[i].initialize(true, ProgramModule.BlockEvent.OBJECT_TYPE.INVALID);
				this._programs[i].Name = ProgramModules.ROUTINE_NAMES[i];
			}
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x0005B460 File Offset: 0x00059660
		public void updateVersion()
		{
			for (int i = 0; i < 5; i++)
			{
				this._programs[i].updateVersion(this.Version);
			}
			this.Version = ProgramModules.CurrentVersion;
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0005B498 File Offset: 0x00059698
		public byte[] serializeBinary()
		{
			byte[] array = new byte[256];
			int num = this.getUsedMemory(ProgramModules.ROUTINE.MAIN, false);
			byte[] array2 = new byte[5];
			List<int> list = new List<int>();
			this.getSubroutineIndexes(ProgramModules.ROUTINE.MAIN, list);
			list.Sort();
			for (int i = 0; i < 4; i++)
			{
				array2[i + 1] = (byte)num;
				if (list.IndexOf(i) >= 0)
				{
					num += this.getUsedMemory(i + ProgramModules.ROUTINE.SUB_1, true);
				}
			}
			num = 0;
			List<ProgramModule.Block> list2 = null;
			this.WriteAllBlocks.Clear();
			byte[] array3 = this._programs[0].serializeBinary(ProgramModules.ROUTINE.MAIN, array2, ref list2);
			foreach (ProgramModule.Block block in list2)
			{
				this.WriteAllBlocks.Add(block);
				block.Routine = ProgramModules.ROUTINE.MAIN;
			}
			for (int j = 0; j < array3.Length; j++)
			{
				array[num + j] = array3[j];
			}
			num += array3.Length;
			foreach (int num2 in list)
			{
				array3 = this._programs[num2 + 1].serializeBinary(ProgramModules.ROUTINE.SUB_1 + num2, array2, ref list2);
				foreach (ProgramModule.Block block2 in list2)
				{
					this.WriteAllBlocks.Add(block2);
					block2.Routine = ProgramModules.ROUTINE.SUB_1 + num2;
				}
				for (int k = 0; k < array3.Length; k++)
				{
					array[num + k] = array3[k];
				}
				num += array3.Length;
			}
			return array;
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x0005B670 File Offset: 0x00059870
		public ProgramModule.ERROR deserializeBinary(byte[] bytes, bool isIcon)
		{
			this.WriteAllBlocks.Clear();
			List<int> list = new List<int>();
			int num = 0;
			int num2 = 0;
			while (num2 < 256 && bytes[num2] != 0)
			{
				ProgramModule.Block block = ProgramModule.Block.deserializeBinary(bytes.Skip(num2).Take(6).ToArray<byte>(), isIcon);
				if (block == null)
				{
					return ProgramModule.ERROR.INVALID_BLOCK;
				}
				this._programs[num].addBlock(block);
				if (block.GetType() == typeof(ProgramModule.BlockStart))
				{
					this._programs[num].Start = (ProgramModule.BlockStart)block;
				}
				else if (block.GetType() == typeof(ProgramModule.BlockEnd))
				{
					this._programs[num].End = (ProgramModule.BlockEnd)block;
					num++;
				}
				this.WriteAllBlocks.Add(block);
				list.Add(num2);
				num2 += block.getUsedMemory();
			}
			for (int i = 1; i < 5; i++)
			{
				ProgramModule.BlockStart blockStart = new ProgramModule.BlockStart();
				this._programs[i].addBlock(blockStart);
				this._programs[i].Start = blockStart;
				if (i < num)
				{
					blockStart.Next = this._programs[i].Blocks[0];
				}
				else
				{
					ProgramModule.BlockEnd blockEnd = new ProgramModule.BlockEnd();
					this._programs[i].addBlock(blockEnd);
					this._programs[i].End = blockEnd;
					blockStart.Next = blockEnd;
				}
			}
			for (int j = 0; j < this.WriteAllBlocks.Count; j++)
			{
				ProgramModule.Block block2 = this.WriteAllBlocks[j];
				if (block2.GetType() != typeof(ProgramModule.BlockEnd))
				{
					block2.Next = this.WriteAllBlocks[list.IndexOf((int)bytes[list[j] + 1])];
				}
				if (block2.GetType() == typeof(ProgramModule.BlockIf))
				{
					((ProgramModule.BlockIf)block2).Else = this.WriteAllBlocks[list.IndexOf((int)bytes[list[j] + 2])];
				}
				else if (block2.GetType() == typeof(ProgramModule.BlockSubroutine))
				{
					ProgramModule.BlockSubroutine blockSubroutine = (ProgramModule.BlockSubroutine)block2;
					ProgramModule.Block block3 = this.WriteAllBlocks[list.IndexOf((int)bytes[list[j] + 2])];
					for (int k = 1; k <= num; k++)
					{
						if (this._programs[k].Start.Next == block3)
						{
							blockSubroutine.Index = k - 1;
							break;
						}
					}
				}
			}
			if (isIcon)
			{
				List<ProgramModule.Block> list2 = new List<ProgramModule.Block>();
				for (ProgramModule.Block block4 = this._programs[0].Start; block4 != null; block4 = block4.Next)
				{
					if (list2.IndexOf(block4) >= 0)
					{
						return ProgramModule.ERROR.INVALID_BLOCK;
					}
					list2.Add(block4);
				}
			}
			for (int l = 0; l < num; l++)
			{
				this._programs[l].alignmentBlocks(false);
			}
			return ProgramModule.ERROR.NONE;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x0005B95C File Offset: 0x00059B5C
		public ProgramModule.Block getBlock(int byteIndex)
		{
			ProgramModule.Block block = null;
			int num = 0;
			foreach (ProgramModule.Block block2 in this.WriteAllBlocks)
			{
				if (num == byteIndex)
				{
					return block2;
				}
				num += block2.getUsedMemory();
			}
			return block;
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x0005B9C4 File Offset: 0x00059BC4
		public void removeAllBlocks()
		{
			ProgramModule[] programs = this._programs;
			for (int i = 0; i < programs.Length; i++)
			{
				programs[i].removeAllBlocks();
			}
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0005B9F0 File Offset: 0x00059BF0
		public void createBlockControls()
		{
			ProgramModules.ROUTINE routineIndex = FlowchartWindow.Instance.RoutineIndex;
			for (int i = 0; i < this._programs.Length; i++)
			{
				FlowchartWindow.Instance.RoutineIndex = (ProgramModules.ROUTINE)i;
				this._programs[i].createBlockControls();
			}
			FlowchartWindow.Instance.RoutineIndex = routineIndex;
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x0005BA40 File Offset: 0x00059C40
		public ProgramModule.ERROR convertBlock()
		{
			ProgramModule.ERROR error = this.getError(true);
			if (error == ProgramModule.ERROR.NONE)
			{
				ProgramModule.BlockLabel.LabelIndexCount = 1;
				ProgramModules.ROUTINE routineIndex = FlowchartWindow.Instance.RoutineIndex;
				for (int i = 0; i < this._programs.Length; i++)
				{
					FlowchartWindow.Instance.RoutineIndex = (ProgramModules.ROUTINE)i;
					this._programs[i].convertBlock();
				}
				FlowchartWindow.Instance.RoutineIndex = routineIndex;
				this.IsBlockMode = true;
			}
			return error;
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x0005BAA8 File Offset: 0x00059CA8
		public ProgramModule.ERROR convertFlowchart()
		{
			ProgramModule.ERROR error = this.getError(true);
			if (error == ProgramModule.ERROR.NONE)
			{
				ProgramModule[] programs = this._programs;
				for (int i = 0; i < programs.Length; i++)
				{
					programs[i].convertFlowchart();
				}
				this.IsBlockMode = false;
			}
			return error;
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x0005BAE8 File Offset: 0x00059CE8
		public void saveConnectIndex()
		{
			foreach (ProgramModule programModule in this._programs)
			{
				programModule.saveConnectIndex(programModule.Blocks, this.IsBlockMode);
			}
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x0005BB20 File Offset: 0x00059D20
		public void restoreConnectIndex()
		{
			foreach (ProgramModule programModule in this._programs)
			{
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
				programModule.restoreConnectIndex(programModule.Blocks, this.IsBlockMode);
			}
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x0005BBEC File Offset: 0x00059DEC
		public int getUsedMemory(ProgramModules.ROUTINE routine, bool addSubroutine = true)
		{
			int num = this._programs[(int)routine].getUsedMemory(this.IsBlockMode);
			if (routine == ProgramModules.ROUTINE.MAIN)
			{
				if (!addSubroutine)
				{
					return num;
				}
				List<int> list = new List<int>();
				this.getSubroutineIndexes(routine, list);
				using (List<int>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						int num2 = enumerator.Current;
						num += this._programs[1 + num2].getUsedMemory(this.IsBlockMode) - 2;
					}
					return num;
				}
			}
			num -= 2;
			return num;
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x0005BC7C File Offset: 0x00059E7C
		public void getSubroutineIndexes(ProgramModules.ROUTINE routine, List<int> indexes)
		{
			foreach (ProgramModule.Block block in this._programs[(int)routine].getConnectBlocks(this.IsBlockMode))
			{
				if (block.GetType() == typeof(ProgramModule.BlockSubroutine))
				{
					ProgramModule.BlockSubroutine blockSubroutine = (ProgramModule.BlockSubroutine)block;
					if (indexes.IndexOf(blockSubroutine.Index) == -1)
					{
						indexes.Add(blockSubroutine.Index);
						this.getSubroutineIndexes(ProgramModules.ROUTINE.SUB_1 + blockSubroutine.Index, indexes);
					}
				}
			}
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x0005BD20 File Offset: 0x00059F20
		public void clearSelect()
		{
			ProgramModule[] programs = this._programs;
			for (int i = 0; i < programs.Length; i++)
			{
				programs[i].clearSelect();
			}
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0005BD4C File Offset: 0x00059F4C
		public ProgramModule.ERROR getError(bool allSubroutine = false)
		{
			ProgramModule.ERROR error = this._programs[0].checkConnectError();
			if (error == ProgramModule.ERROR.NONE)
			{
				List<int> list = new List<int>();
				if (allSubroutine)
				{
					list.AddRange(Enumerable.Range(0, 4));
				}
				else
				{
					this.getSubroutineIndexes(ProgramModules.ROUTINE.MAIN, list);
				}
				foreach (int num in list)
				{
					error = this._programs[num + 1].checkConnectError();
					if (error != ProgramModule.ERROR.NONE)
					{
						ProgramModule.ErrorRoutineIndex = num + 1;
						break;
					}
				}
				if (error == ProgramModule.ERROR.NONE && this.IsBlockMode)
				{
					error = this._programs[0].checkJumpError();
					if (error == ProgramModule.ERROR.NONE)
					{
						foreach (int num2 in list)
						{
							error = this._programs[num2 + 1].checkJumpError();
							if (error != ProgramModule.ERROR.NONE)
							{
								break;
							}
						}
					}
				}
				if (error == ProgramModule.ERROR.NONE && !this.IsBlockMode)
				{
					List<ProgramModule.BlockLoopStart> list2 = new List<ProgramModule.BlockLoopStart>();
					List<ProgramModule.Block> list3 = new List<ProgramModule.Block>();
					List<ProgramModule.BlockSubroutine> list4 = new List<ProgramModule.BlockSubroutine>();
					error = this._programs[0].checkLoopError(this._programs, this._programs[0].Start.Next, list2, list3, list4, 0);
				}
			}
			else
			{
				ProgramModule.ErrorRoutineIndex = 0;
			}
			return error;
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0005BEAC File Offset: 0x0005A0AC
		public void updateLoopIndex()
		{
			ProgramModule[] programs = this._programs;
			for (int i = 0; i < programs.Length; i++)
			{
				programs[i].updateLoopIndex();
			}
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0005BED8 File Offset: 0x0005A0D8
		public void updateConnectState()
		{
			for (int i = 0; i < 5; i++)
			{
				this._programs[i].updateConnectState();
			}
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x0005BF00 File Offset: 0x0005A100
		public int getLabelIndexCount()
		{
			int num = 1;
			ProgramModule[] programs = this._programs;
			for (int i = 0; i < programs.Length; i++)
			{
				foreach (ProgramModule.BlockLabel blockLabel in programs[i].Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>())
				{
					num = Math.Max(blockLabel.Label, num);
				}
			}
			return num;
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x0005BFA0 File Offset: 0x0005A1A0
		public void clearUpdated()
		{
			ProgramModule[] programs = this.Programs;
			for (int i = 0; i < programs.Length; i++)
			{
				programs[i].clearUpdated();
			}
		}

		// Token: 0x040005CB RID: 1483
		private static readonly string[] ROUTINE_NAMES = new string[] { "メイン", "サブルーチン①", "サブルーチン②", "サブルーチン③", "サブルーチン④" };

		// Token: 0x040005CC RID: 1484
		public int Version;

		// Token: 0x040005CD RID: 1485
		private static readonly int CurrentVersion = 1;

		// Token: 0x040005CE RID: 1486
		private ProgramModule[] _programs = new ProgramModule[5];

		// Token: 0x040005CF RID: 1487
		private ReportModule _report = new ReportModule();

		// Token: 0x020000C6 RID: 198
		public enum ROUTINE
		{
			// Token: 0x04000937 RID: 2359
			INVALID = -1,
			// Token: 0x04000938 RID: 2360
			MAIN,
			// Token: 0x04000939 RID: 2361
			SUB_1,
			// Token: 0x0400093A RID: 2362
			SUB_2,
			// Token: 0x0400093B RID: 2363
			SUB_3,
			// Token: 0x0400093C RID: 2364
			SUB_4,
			// Token: 0x0400093D RID: 2365
			MAX,
			// Token: 0x0400093E RID: 2366
			SUB_MAX = 4
		}
	}
}
