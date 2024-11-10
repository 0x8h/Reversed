using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Clock
{
	// Token: 0x02000052 RID: 82
	public class Simulator
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060008A9 RID: 2217 RVA: 0x000644A3 File Offset: 0x000626A3
		public Simulator.STATE State
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x000644AB File Offset: 0x000626AB
		// (set) Token: 0x060008AB RID: 2219 RVA: 0x000644B3 File Offset: 0x000626B3
		public Simulator.LIGHT Light { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x000644BC File Offset: 0x000626BC
		// (set) Token: 0x060008AD RID: 2221 RVA: 0x000644C4 File Offset: 0x000626C4
		public int LightValue { get; set; } = 50;

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x000644CD File Offset: 0x000626CD
		// (set) Token: 0x060008AF RID: 2223 RVA: 0x000644D5 File Offset: 0x000626D5
		public bool Button { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x000644DE File Offset: 0x000626DE
		// (set) Token: 0x060008B1 RID: 2225 RVA: 0x000644E6 File Offset: 0x000626E6
		public bool Sound { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x000644EF File Offset: 0x000626EF
		// (set) Token: 0x060008B3 RID: 2227 RVA: 0x000644F7 File Offset: 0x000626F7
		public bool Alarm { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060008B4 RID: 2228 RVA: 0x00064500 File Offset: 0x00062700
		// (set) Token: 0x060008B5 RID: 2229 RVA: 0x00064508 File Offset: 0x00062708
		public bool Timer { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x00064511 File Offset: 0x00062711
		// (set) Token: 0x060008B7 RID: 2231 RVA: 0x00064519 File Offset: 0x00062719
		public bool UsbIn { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060008B8 RID: 2232 RVA: 0x00064522 File Offset: 0x00062722
		// (set) Token: 0x060008B9 RID: 2233 RVA: 0x0006452A File Offset: 0x0006272A
		public int Hour { get; set; } = 23;

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060008BA RID: 2234 RVA: 0x00064533 File Offset: 0x00062733
		// (set) Token: 0x060008BB RID: 2235 RVA: 0x0006453B File Offset: 0x0006273B
		public int Minute { get; set; } = 59;

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060008BC RID: 2236 RVA: 0x00064544 File Offset: 0x00062744
		// (set) Token: 0x060008BD RID: 2237 RVA: 0x0006454C File Offset: 0x0006274C
		public int Temperature { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060008BE RID: 2238 RVA: 0x00064555 File Offset: 0x00062755
		public int[] Variables
		{
			get
			{
				return this._variables;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060008BF RID: 2239 RVA: 0x0006455D File Offset: 0x0006275D
		// (set) Token: 0x060008C0 RID: 2240 RVA: 0x00064565 File Offset: 0x00062765
		public int Counter
		{
			get
			{
				return this._counter;
			}
			set
			{
				this._counter = value;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060008C1 RID: 2241 RVA: 0x0006456E File Offset: 0x0006276E
		public float WaitTime
		{
			get
			{
				return this._waitTime;
			}
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00064576 File Offset: 0x00062776
		public void pushCall(ProgramModule.BlockSubroutine block)
		{
			this._callStack.Add(block);
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x00064584 File Offset: 0x00062784
		public void popCall()
		{
			this._callStack.RemoveAt(this._callStack.Count - 1);
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060008C4 RID: 2244 RVA: 0x0006459E File Offset: 0x0006279E
		public ProgramModule.Block BreakBlock
		{
			get
			{
				return this._breakBlock;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060008C5 RID: 2245 RVA: 0x000645A6 File Offset: 0x000627A6
		public ProgramModules.ROUTINE Routine
		{
			get
			{
				return this._routine;
			}
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x000645B0 File Offset: 0x000627B0
		public Simulator(SimulatorWindow window)
		{
			this._window = window;
			this._onUpdateSimulator_Delegate = new SimulatorWindow.onUpdateSimulator_Delegate(this._window.onUpdateSimulator);
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x00064640 File Offset: 0x00062840
		public void initialize(ProgramModules programs)
		{
			this._programs = programs;
			this._programs.clearSelect();
			this._window.setColor(this._clearColor);
			this._loopIndex = -1;
			this.resetVariables();
			this._counterPlay = false;
			this._window.setSoundImage(ProgramModule.BlockSound.MODE.MELODY_STOP);
			this._window.setUsbOut(false);
			this._callStack.Clear();
			this._breakBlock = null;
			this._routine = ProgramModules.ROUTINE.MAIN;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x000646B5 File Offset: 0x000628B5
		public void resetVariables()
		{
			this._counter = 0;
			this._variables = new int[8];
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x000646CC File Offset: 0x000628CC
		public async void run(bool step)
		{
			if (this._programs != null)
			{
				this._step = step;
				this._state = Simulator.STATE.RUN;
				await Task.Run(delegate
				{
					this._isRunningProgram = true;
					if (this._breakBlock == null)
					{
						this.runProgram(this._programs.Programs[0].Start);
					}
					else
					{
						int count = this._callStack.Count;
						ProgramModule.Block block = null;
						int num = 0;
						if (count > 0)
						{
							num = this._callStack[count - 1].Index + 1;
						}
						foreach (ProgramModule.Block block2 in this._programs.Programs[num].Blocks)
						{
							if (block2.Selected)
							{
								block = block2;
								break;
							}
							if (block2 is ProgramModule.BlockLoopStart && ((ProgramModule.BlockLoopStart)block2).BlockLoopEnd != null && ((ProgramModule.BlockLoopStart)block2).BlockLoopEnd.Selected)
							{
								block = ((ProgramModule.BlockLoopStart)block2).BlockLoopEnd;
								break;
							}
						}
						if (block == this._breakBlock)
						{
							this._breakBlock = null;
							if (this._counterPlay)
							{
								this.runCounter();
							}
							this.runProgram(block);
							if (this._state == Simulator.STATE.RUN)
							{
								List<ProgramModule.BlockSubroutine> callStack = this._callStack;
								this._callStack = new List<ProgramModule.BlockSubroutine>();
								for (int i = count - 1; i >= 0; i--)
								{
									if (i == 0)
									{
										this._routine = ProgramModules.ROUTINE.MAIN;
									}
									else
									{
										this._routine = callStack[i - 1].Index + ProgramModules.ROUTINE.SUB_1;
									}
									this.runProgram(callStack[i].Next);
									if (this._state == Simulator.STATE.STOP)
									{
										while (i > 0)
										{
											this._callStack.Insert(0, callStack[i - 1]);
											i--;
										}
										break;
									}
								}
							}
							else if (this._breakBlock == null && count > 0)
							{
								if (this._callStack.Count - 1 == 0)
								{
									this._routine = ProgramModules.ROUTINE.MAIN;
								}
								else
								{
									this._routine = this._callStack[this._callStack.Count - 1].Index + ProgramModules.ROUTINE.SUB_1;
								}
								this._breakBlock = this._callStack[count - 1].Next;
								if (this._programs.IsBlockMode && this._breakBlock == null)
								{
									this._breakBlock = this.getParentNextBlock(this._callStack[count - 1]);
								}
								this.setBlockSelected(this._breakBlock, true);
								this.popCall();
							}
						}
						else
						{
							this.initialize(this._programs);
							this.runProgram(this._programs.Programs[0].Start);
						}
					}
					this.stop();
					this._window.Invoke(this._onUpdateSimulator_Delegate);
					this._isRunningProgram = false;
					if (this._breakBlock == null)
					{
						this.initialize(this._programs);
					}
				});
			}
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x0006470B File Offset: 0x0006290B
		private void setBlockSelected(ProgramModule.Block block, bool enable)
		{
			if (enable)
			{
				if (!(block is ProgramModule.BlockStart))
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

		// Token: 0x060008CB RID: 2251 RVA: 0x00064728 File Offset: 0x00062928
		private void runProgram(ProgramModule.Block block)
		{
			ProgramModule.Block block2 = null;
			while (block != null)
			{
				this.setBlockSelected(block, true);
				if (block2 != block)
				{
					this._window.Invoke(this._onUpdateSimulator_Delegate);
					Thread.Sleep(16);
				}
				block2 = block;
				bool flag = true;
				if (block.GetType() == typeof(ProgramModule.BlockLED))
				{
					this.runProgramLED((ProgramModule.BlockLED)block);
				}
				else if (block.GetType() == typeof(ProgramModule.BlockSound))
				{
					this.runProgramSound((ProgramModule.BlockSound)block);
				}
				else if (block.GetType() == typeof(ProgramModule.BlockWait))
				{
					this.runProgramWait((ProgramModule.BlockWait)block);
				}
				else if (block.GetType() == typeof(ProgramModule.BlockLoopStart))
				{
					this.runProgramLoopStart((ProgramModule.BlockLoopStart)block);
					if (this._programs.IsBlockMode)
					{
						flag = false;
						this.setBlockSelected(block2, false);
						block = ((((ProgramModule.BlockLoopStart)block).Branches[0] == null) ? ((ProgramModule.BlockLoopStart)block).BlockLoopEnd : ((ProgramModule.BlockLoopStart)block).Branches[0]);
					}
				}
				else if (block.GetType() == typeof(ProgramModule.BlockLoopEnd))
				{
					flag = this.runProgramLoopEnd((ProgramModule.BlockLoopEnd)block);
					if (flag)
					{
						if (this._programs.IsBlockMode)
						{
							flag = false;
							block = this._loopStartBlocks[this._loopIndex + 1].Next;
							if (block == null)
							{
								block = this.getParentNextBlock(this._loopStartBlocks[this._loopIndex + 1]);
							}
						}
					}
					else
					{
						this.setBlockSelected(block, false);
						if (this._programs.IsBlockMode)
						{
							block = this._loopStartBlocks[this._loopIndex].Branches[0];
							if (block == null)
							{
								block = this._loopStartBlocks[this._loopIndex].BlockLoopEnd;
							}
						}
						else
						{
							block = this._loopStartBlocks[this._loopIndex].Next;
						}
						if (block != null && block is ProgramModule.BlockJump)
						{
							ProgramModule.BlockLabel label = ((ProgramModule.BlockJump)block).Label;
							if (label != null)
							{
								block = label.Next;
							}
						}
						if ((block != null && block.BreakPoint) || this._step)
						{
							this.stop();
						}
					}
				}
				else if (block.GetType() == typeof(ProgramModule.BlockWaitCondition))
				{
					flag = this.runProgramWaitCondition((ProgramModule.BlockWaitCondition)block);
				}
				else if (block.GetType() == typeof(ProgramModule.BlockIf))
				{
					ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block;
					flag = this.runProgramIf(blockIf);
					if (flag)
					{
						if (this._programs.IsBlockMode)
						{
							flag = false;
							this.setBlockSelected(block2, false);
							block = blockIf.Branches[0];
							if (block == null)
							{
								block = blockIf.Next;
							}
							else if (block is ProgramModule.BlockJump)
							{
								ProgramModule.BlockLabel label2 = ((ProgramModule.BlockJump)block).Label;
								if (label2 != null)
								{
									block = label2.Next;
								}
							}
							if ((block != null && block.BreakPoint) || this._step)
							{
								this.stop();
							}
						}
					}
					else
					{
						this.setBlockSelected(block, false);
						if (this._programs.IsBlockMode)
						{
							if (blockIf.Branches.Count > 1 && blockIf.Branches[1] != null)
							{
								block = blockIf.Branches[1];
							}
							else
							{
								block = block.Next;
							}
						}
						else
						{
							block = blockIf.Else;
						}
						if (block != null && block is ProgramModule.BlockJump)
						{
							ProgramModule.BlockLabel label3 = ((ProgramModule.BlockJump)block).Label;
							if (label3 != null)
							{
								block = label3.Next;
							}
						}
						if ((block != null && block.BreakPoint) || this._step)
						{
							this.stop();
						}
					}
				}
				else if (block.GetType() == typeof(ProgramModule.BlockArithmetic))
				{
					this.runProgramArithmetic((ProgramModule.BlockArithmetic)block);
				}
				else if (block.GetType() == typeof(ProgramModule.BlockCounter))
				{
					this.runProgramCounter((ProgramModule.BlockCounter)block);
				}
				else if (block.GetType() == typeof(ProgramModule.BlockSubroutine))
				{
					this.runProgramSubroutine((ProgramModule.BlockSubroutine)block);
				}
				else if (block.GetType() == typeof(ProgramModule.BlockDisplay))
				{
					this.runProgramDisplay((ProgramModule.BlockDisplay)block);
				}
				else if (block.GetType() == typeof(ProgramModule.BlockUsbOut))
				{
					this.runProgramUsbOut((ProgramModule.BlockUsbOut)block);
				}
				if (flag)
				{
					block = block.Next;
					if (block != null && block is ProgramModule.BlockJump)
					{
						ProgramModule.BlockLabel label4 = ((ProgramModule.BlockJump)block).Label;
						if (label4 != null)
						{
							block = label4.Next;
						}
					}
					if ((block != null && block.BreakPoint) || this._step)
					{
						this.stop();
					}
				}
				if (this._programs.IsBlockMode && block == null)
				{
					block = this.getParentNextBlock(block2);
				}
				if (this._state == Simulator.STATE.STOP)
				{
					if (this._breakBlock != null)
					{
						break;
					}
					if (block != null)
					{
						this._breakBlock = block;
						this.setBlockSelected(this._breakBlock, true);
					}
					if (block != block2)
					{
						this.setBlockSelected(block2, false);
						return;
					}
					break;
				}
				else if (flag)
				{
					this.setBlockSelected(block2, false);
				}
			}
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00064C2C File Offset: 0x00062E2C
		private ProgramModule.Block getParentNextBlock(ProgramModule.Block block)
		{
			ProgramModule.BlockBranch parentBlock = this._programs.Programs[(int)this._routine].getParentBlock(block);
			if (parentBlock == null)
			{
				return null;
			}
			if (parentBlock is ProgramModule.BlockLoopStart)
			{
				return ((ProgramModule.BlockLoopStart)parentBlock).BlockLoopEnd;
			}
			if (parentBlock.Next == null)
			{
				return this.getParentNextBlock(parentBlock);
			}
			return parentBlock.Next;
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x00064C81 File Offset: 0x00062E81
		public void stop()
		{
			this._state = Simulator.STATE.STOP;
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x00064C8A File Offset: 0x00062E8A
		public bool isRunnable()
		{
			return this._state != Simulator.STATE.RUN && !this._isRunningProgram && !this._isRunningCounter;
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x00064CA8 File Offset: 0x00062EA8
		private void runProgramLED(ProgramModule.BlockLED blockLED)
		{
			switch (blockLED.Mode)
			{
			case ProgramModule.BlockLED.LED_MODE.ON:
				this._window.setColor(Color.FromArgb((int)((double)blockLED.Red * 25.5), (int)((double)blockLED.Green * 25.5), (int)((double)blockLED.Blue * 25.5)));
				return;
			case ProgramModule.BlockLED.LED_MODE.OFF:
				this._window.setColor(this._clearColor);
				return;
			case ProgramModule.BlockLED.LED_MODE.ON_TIME:
			{
				if (blockLED.Fade == ProgramModule.BlockLED.FADE.NONE)
				{
					Color color = Color.FromArgb((int)((double)blockLED.Red * 25.5), (int)((double)blockLED.Green * 25.5), (int)((double)blockLED.Blue * 25.5));
					this._window.setColor(color);
					float num = 0f;
					while (num < blockLED.Time)
					{
						num += 0.1f;
						Thread.Sleep(100);
						if (this._state == Simulator.STATE.STOP)
						{
							break;
						}
					}
					this._window.setColor(this._clearColor);
					return;
				}
				Color color2;
				Color color3;
				if (blockLED.Fade == ProgramModule.BlockLED.FADE.IN)
				{
					color2 = Color.FromArgb(255, (int)((double)this._window.getColor().R / 25.5), (int)((double)this._window.getColor().G / 25.5), (int)((double)this._window.getColor().B / 25.5));
					color3 = Color.FromArgb(blockLED.Red, blockLED.Green, blockLED.Blue);
				}
				else
				{
					color2 = Color.FromArgb(blockLED.Red, blockLED.Green, blockLED.Blue);
					color3 = Color.Black;
				}
				int i = 0;
				int num2 = Environment.TickCount;
				int num3 = (int)(blockLED.Time * 1000f);
				while (i <= num3)
				{
					float num4 = (float)i / (float)num3;
					this._window.setColor(Color.FromArgb((int)((double)((int)((float)color2.R + num4 * (float)(color3.R - color2.R))) * 25.5), (int)((double)((int)((float)color2.G + num4 * (float)(color3.G - color2.G))) * 25.5), (int)((double)((int)((float)color2.B + num4 * (float)(color3.B - color2.B))) * 25.5)));
					i += Environment.TickCount - num2;
					num2 = Environment.TickCount;
					if (this._state == Simulator.STATE.STOP)
					{
						break;
					}
				}
				this._window.setColor(Color.FromArgb((int)((double)color3.R * 25.5), (int)((double)color3.G * 25.5), (int)((double)color3.B * 25.5)));
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00064F90 File Offset: 0x00063190
		private void runProgramSound(ProgramModule.BlockSound blockSound)
		{
			if (blockSound.Mode == ProgramModule.BlockSound.MODE.MELODY_STOP || (blockSound.Mode == ProgramModule.BlockSound.MODE.MELODY_PLAY && blockSound.Loop))
			{
				this._window.setSoundImage(blockSound.Mode);
				return;
			}
			this._window.setSoundImage(blockSound.Mode);
			float num = 0f;
			while (num < 1f)
			{
				num += 0.1f;
				Thread.Sleep(100);
				if (this._state == Simulator.STATE.STOP)
				{
					break;
				}
			}
			this._window.setSoundImage(ProgramModule.BlockSound.MODE.MELODY_STOP);
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00065010 File Offset: 0x00063210
		private void runProgramWait(ProgramModule.BlockWait blockWait)
		{
			this._waitTime = blockWait.Time;
			this._window.updateClock();
			while (this._waitTime > 0f)
			{
				this._waitTime -= 0.1f;
				this._window.updateClock();
				Thread.Sleep(100);
				if (this._state == Simulator.STATE.STOP)
				{
					break;
				}
			}
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x0006506F File Offset: 0x0006326F
		private void runProgramLoopStart(ProgramModule.BlockLoopStart blockLoopStart)
		{
			this._loopIndex++;
			this._loopStartBlocks[this._loopIndex] = blockLoopStart;
			this._loopCounts[this._loopIndex] = blockLoopStart.Count - 1;
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x000650A4 File Offset: 0x000632A4
		private bool runProgramLoopEnd(ProgramModule.BlockLoopEnd blockLoopEnd)
		{
			Thread.Sleep(1);
			if (blockLoopEnd.IsCondition)
			{
				bool flag = false;
				switch (blockLoopEnd.Condition)
				{
				case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.BUTTON:
					flag = this.Button == (blockLoopEnd.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON);
					break;
				case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.LIGHT:
					switch (blockLoopEnd.Variable)
					{
					case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID:
						flag = this.Light == (Simulator.LIGHT)blockLoopEnd.Select;
						break;
					case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST:
						switch (blockLoopEnd.Select)
						{
						case ProgramModule.BlockIf.SELECT.BUTTON_ON:
							flag = this.LightValue > blockLoopEnd.Values[0];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
							flag = this.LightValue < blockLoopEnd.Values[0];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
							flag = this.LightValue == blockLoopEnd.Values[0];
							break;
						}
						break;
					case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX:
						switch (blockLoopEnd.Select)
						{
						case ProgramModule.BlockIf.SELECT.BUTTON_ON:
							flag = this.LightValue > this._variables[blockLoopEnd.VariableIndexes[0]];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
							flag = this.LightValue < this._variables[blockLoopEnd.VariableIndexes[0]];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
							flag = this.LightValue == this._variables[blockLoopEnd.VariableIndexes[0]];
							break;
						}
						break;
					}
					break;
				case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.SOUND:
					flag = this.Sound == (blockLoopEnd.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON);
					break;
				case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.ALARM:
					flag = this.Alarm == (blockLoopEnd.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON);
					break;
				case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIMER:
					flag = this.Timer == (blockLoopEnd.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON);
					break;
				case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TIME:
					switch (blockLoopEnd.Select)
					{
					case ProgramModule.BlockIf.SELECT.BUTTON_ON:
						flag = this.Hour > blockLoopEnd.Values[0] || (this.Hour == blockLoopEnd.Values[0] && this.Minute > blockLoopEnd.Values[1]);
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
						flag = this.Hour == blockLoopEnd.Values[0] && this.Minute == blockLoopEnd.Values[1];
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
						flag = this.Hour < blockLoopEnd.Values[0] || (this.Hour == blockLoopEnd.Values[0] && this.Minute < blockLoopEnd.Values[1]);
						break;
					}
					break;
				case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.TEMPERATURE:
				{
					ProgramModule.BlockIf.VARIABLE_TYPE_SECOND variable_TYPE_SECOND = blockLoopEnd.Variable;
					if (variable_TYPE_SECOND != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						if (variable_TYPE_SECOND == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							switch (blockLoopEnd.Select)
							{
							case ProgramModule.BlockIf.SELECT.BUTTON_ON:
								flag = this.Temperature < this._variables[blockLoopEnd.VariableIndexes[0]];
								break;
							case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
								flag = this.Temperature == this._variables[blockLoopEnd.VariableIndexes[0]];
								break;
							case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
								flag = this.Temperature > this._variables[blockLoopEnd.VariableIndexes[0]];
								break;
							}
						}
					}
					else
					{
						switch (blockLoopEnd.Select)
						{
						case ProgramModule.BlockIf.SELECT.BUTTON_ON:
							flag = this.Temperature < blockLoopEnd.Values[0];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
							flag = this.Temperature == blockLoopEnd.Values[0];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
							flag = this.Temperature > blockLoopEnd.Values[0];
							break;
						}
					}
					break;
				}
				case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.COUNTER:
					switch (blockLoopEnd.Select)
					{
					case ProgramModule.BlockIf.SELECT.BUTTON_ON:
						flag = this._counter < blockLoopEnd.Values[0];
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
						flag = this._counter == blockLoopEnd.Values[0];
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
						flag = this._counter > blockLoopEnd.Values[0];
						break;
					}
					break;
				case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.VARIABLE:
				{
					ProgramModule.BlockIf.VARIABLE_TYPE_SECOND variable_TYPE_SECOND = blockLoopEnd.Variable;
					if (variable_TYPE_SECOND != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						if (variable_TYPE_SECOND == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							switch (blockLoopEnd.Select)
							{
							case ProgramModule.BlockIf.SELECT.BUTTON_ON:
								flag = this._variables[blockLoopEnd.VariableIndexes[0]] < this._variables[blockLoopEnd.VariableIndexes[1]];
								break;
							case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
								flag = this._variables[blockLoopEnd.VariableIndexes[0]] == this._variables[blockLoopEnd.VariableIndexes[1]];
								break;
							case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
								flag = this._variables[blockLoopEnd.VariableIndexes[0]] > this._variables[blockLoopEnd.VariableIndexes[1]];
								break;
							}
						}
					}
					else
					{
						switch (blockLoopEnd.Select)
						{
						case ProgramModule.BlockIf.SELECT.BUTTON_ON:
							flag = this._variables[blockLoopEnd.VariableIndexes[0]] < blockLoopEnd.Values[0];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
							flag = this._variables[blockLoopEnd.VariableIndexes[0]] == blockLoopEnd.Values[0];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
							flag = this._variables[blockLoopEnd.VariableIndexes[0]] > blockLoopEnd.Values[0];
							break;
						}
					}
					break;
				}
				case ProgramModule.BlockLoopEnd.CONDITION_LOOP_END.NO_USBIN_MAX:
					flag = this.UsbIn == (blockLoopEnd.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON);
					break;
				}
				if (flag)
				{
					this._loopIndex--;
					return true;
				}
			}
			if (this._loopCounts[this._loopIndex] > 0)
			{
				this._loopCounts[this._loopIndex]--;
				return false;
			}
			if (this._loopCounts[this._loopIndex] == -1)
			{
				return false;
			}
			this._loopIndex--;
			return true;
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x000655F0 File Offset: 0x000637F0
		private bool runProgramWaitCondition(ProgramModule.BlockWaitCondition blockWaitCondition)
		{
			bool flag = true;
			switch (blockWaitCondition.Condition)
			{
			case ProgramModule.BlockWaitCondition.CONDITION.BUTTON:
				flag = this.Button;
				break;
			case ProgramModule.BlockWaitCondition.CONDITION.LIGHT:
				flag = this.Light == (Simulator.LIGHT)blockWaitCondition.Light;
				break;
			case ProgramModule.BlockWaitCondition.CONDITION.SOUND:
				flag = this.Sound;
				break;
			case ProgramModule.BlockWaitCondition.CONDITION.ALARM:
				flag = this.Alarm;
				break;
			case ProgramModule.BlockWaitCondition.CONDITION.TIMER:
				flag = this.Timer;
				break;
			case ProgramModule.BlockWaitCondition.CONDITION.TIME:
				flag = this.Hour == blockWaitCondition.Hour && this.Minute == blockWaitCondition.Minute;
				break;
			case ProgramModule.BlockWaitCondition.CONDITION.TEMPERATURE:
				flag = this.Temperature == blockWaitCondition.Temperature;
				break;
			}
			return flag;
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00065694 File Offset: 0x00063894
		private bool runProgramIf(ProgramModule.BlockIf blockIf)
		{
			bool flag = false;
			switch (blockIf.Condition)
			{
			case ProgramModule.BlockIf.CONDITION_IF.BUTTON:
				flag = this.Button == (blockIf.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON);
				break;
			case ProgramModule.BlockIf.CONDITION_IF.LIGHT:
				switch (blockIf.Variable)
				{
				case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID:
					flag = this.Light == (Simulator.LIGHT)blockIf.Select;
					break;
				case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST:
					switch (blockIf.Select)
					{
					case ProgramModule.BlockIf.SELECT.BUTTON_ON:
						flag = this.LightValue > blockIf.Values[0];
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
						flag = this.LightValue < blockIf.Values[0];
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
						flag = this.LightValue == blockIf.Values[0];
						break;
					}
					break;
				case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX:
					switch (blockIf.Select)
					{
					case ProgramModule.BlockIf.SELECT.BUTTON_ON:
						flag = this.LightValue > this._variables[blockIf.VariableIndexes[0]];
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
						flag = this.LightValue < this._variables[blockIf.VariableIndexes[0]];
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
						flag = this.LightValue == this._variables[blockIf.VariableIndexes[0]];
						break;
					}
					break;
				}
				break;
			case ProgramModule.BlockIf.CONDITION_IF.SOUND:
				flag = this.Sound == (blockIf.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON);
				break;
			case ProgramModule.BlockIf.CONDITION_IF.ALARM:
				flag = this.Alarm == (blockIf.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON);
				break;
			case ProgramModule.BlockIf.CONDITION_IF.TIMER:
				flag = this.Timer == (blockIf.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON);
				break;
			case ProgramModule.BlockIf.CONDITION_IF.TIME:
				switch (blockIf.Select)
				{
				case ProgramModule.BlockIf.SELECT.BUTTON_ON:
					flag = this.Hour > blockIf.Values[0] || (this.Hour == blockIf.Values[0] && this.Minute > blockIf.Values[1]);
					break;
				case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
					flag = this.Hour == blockIf.Values[0] && this.Minute == blockIf.Values[1];
					break;
				case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
					flag = this.Hour < blockIf.Values[0] || (this.Hour == blockIf.Values[0] && this.Minute < blockIf.Values[1]);
					break;
				}
				break;
			case ProgramModule.BlockIf.CONDITION_IF.TEMPERATURE:
			{
				ProgramModule.BlockIf.VARIABLE_TYPE_SECOND variable_TYPE_SECOND = blockIf.Variable;
				if (variable_TYPE_SECOND != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
				{
					if (variable_TYPE_SECOND == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
					{
						switch (blockIf.Select)
						{
						case ProgramModule.BlockIf.SELECT.BUTTON_ON:
							flag = this.Temperature < this._variables[blockIf.VariableIndexes[0]];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
							flag = this.Temperature == this._variables[blockIf.VariableIndexes[0]];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
							flag = this.Temperature > this._variables[blockIf.VariableIndexes[0]];
							break;
						}
					}
				}
				else
				{
					switch (blockIf.Select)
					{
					case ProgramModule.BlockIf.SELECT.BUTTON_ON:
						flag = this.Temperature < blockIf.Values[0];
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
						flag = this.Temperature == blockIf.Values[0];
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
						flag = this.Temperature > blockIf.Values[0];
						break;
					}
				}
				break;
			}
			case ProgramModule.BlockIf.CONDITION_IF.RANDOM:
				flag = this._random.Next(2) == 0;
				break;
			case ProgramModule.BlockIf.CONDITION_IF.COUNTER:
				switch (blockIf.Select)
				{
				case ProgramModule.BlockIf.SELECT.BUTTON_ON:
					flag = this._counter < blockIf.Values[0];
					break;
				case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
					flag = this._counter == blockIf.Values[0];
					break;
				case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
					flag = this._counter > blockIf.Values[0];
					break;
				}
				break;
			case ProgramModule.BlockIf.CONDITION_IF.VARIABLE:
			{
				ProgramModule.BlockIf.VARIABLE_TYPE_SECOND variable_TYPE_SECOND = blockIf.Variable;
				if (variable_TYPE_SECOND != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
				{
					if (variable_TYPE_SECOND == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
					{
						switch (blockIf.Select)
						{
						case ProgramModule.BlockIf.SELECT.BUTTON_ON:
							flag = this._variables[blockIf.VariableIndexes[0]] < this._variables[blockIf.VariableIndexes[1]];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
							flag = this._variables[blockIf.VariableIndexes[0]] == this._variables[blockIf.VariableIndexes[1]];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
							flag = this._variables[blockIf.VariableIndexes[0]] > this._variables[blockIf.VariableIndexes[1]];
							break;
						}
					}
				}
				else
				{
					switch (blockIf.Select)
					{
					case ProgramModule.BlockIf.SELECT.BUTTON_ON:
						flag = this._variables[blockIf.VariableIndexes[0]] < blockIf.Values[0];
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
						flag = this._variables[blockIf.VariableIndexes[0]] == blockIf.Values[0];
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
						flag = this._variables[blockIf.VariableIndexes[0]] > blockIf.Values[0];
						break;
					}
				}
				break;
			}
			case ProgramModule.BlockIf.CONDITION_IF.NO_USBIN_MAX:
				flag = this.UsbIn == (blockIf.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON);
				break;
			}
			return flag;
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00065B8C File Offset: 0x00063D8C
		private void runProgramArithmetic(ProgramModule.BlockArithmetic blockArithmetic)
		{
			switch (blockArithmetic.Variable)
			{
			case ProgramModule.BlockArithmetic.VARIABLE_SECOND.CONST:
				switch (blockArithmetic.Operate)
				{
				case ProgramModule.BlockArithmetic.OPERATE.EQUAL:
					this._variables[blockArithmetic.VariableIndex[0]] = blockArithmetic.ConstValue;
					break;
				case ProgramModule.BlockArithmetic.OPERATE.ADD:
					this._variables[blockArithmetic.VariableIndex[0]] = this.ArithmeticRange(this._variables[blockArithmetic.VariableIndex[0]] + blockArithmetic.ConstValue);
					break;
				case ProgramModule.BlockArithmetic.OPERATE.SUB:
					this._variables[blockArithmetic.VariableIndex[0]] = this.ArithmeticRange(this._variables[blockArithmetic.VariableIndex[0]] - blockArithmetic.ConstValue);
					break;
				}
				break;
			case ProgramModule.BlockArithmetic.VARIABLE_SECOND.INDEX:
				switch (blockArithmetic.Operate)
				{
				case ProgramModule.BlockArithmetic.OPERATE.EQUAL:
					this._variables[blockArithmetic.VariableIndex[0]] = this._variables[blockArithmetic.VariableIndex[1]];
					break;
				case ProgramModule.BlockArithmetic.OPERATE.ADD:
					this._variables[blockArithmetic.VariableIndex[0]] = this.ArithmeticRange(this._variables[blockArithmetic.VariableIndex[0]] + this._variables[blockArithmetic.VariableIndex[1]]);
					break;
				case ProgramModule.BlockArithmetic.OPERATE.SUB:
					this._variables[blockArithmetic.VariableIndex[0]] = this.ArithmeticRange(this._variables[blockArithmetic.VariableIndex[0]] - this._variables[blockArithmetic.VariableIndex[1]]);
					break;
				}
				break;
			case ProgramModule.BlockArithmetic.VARIABLE_SECOND.TEMPERATURE:
				switch (blockArithmetic.Operate)
				{
				case ProgramModule.BlockArithmetic.OPERATE.EQUAL:
					this._variables[blockArithmetic.VariableIndex[0]] = this.Temperature;
					break;
				case ProgramModule.BlockArithmetic.OPERATE.ADD:
					this._variables[blockArithmetic.VariableIndex[0]] = this.ArithmeticRange(this._variables[blockArithmetic.VariableIndex[0]] + this.Temperature);
					break;
				case ProgramModule.BlockArithmetic.OPERATE.SUB:
					this._variables[blockArithmetic.VariableIndex[0]] = this.ArithmeticRange(this._variables[blockArithmetic.VariableIndex[0]] - this.Temperature);
					break;
				}
				break;
			case ProgramModule.BlockArithmetic.VARIABLE_SECOND.LIGHT:
				switch (blockArithmetic.Operate)
				{
				case ProgramModule.BlockArithmetic.OPERATE.EQUAL:
					this._variables[blockArithmetic.VariableIndex[0]] = this.LightValue;
					break;
				case ProgramModule.BlockArithmetic.OPERATE.ADD:
					this._variables[blockArithmetic.VariableIndex[0]] = this.ArithmeticRange(this._variables[blockArithmetic.VariableIndex[0]] + this.LightValue);
					break;
				case ProgramModule.BlockArithmetic.OPERATE.SUB:
					this._variables[blockArithmetic.VariableIndex[0]] = this.ArithmeticRange(this._variables[blockArithmetic.VariableIndex[0]] - this.LightValue);
					break;
				}
				break;
			}
			this._window.updateClock();
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00065E34 File Offset: 0x00064034
		private void runProgramCounter(ProgramModule.BlockCounter blockCounter)
		{
			switch (blockCounter.Command)
			{
			case ProgramModule.BlockCounter.COMMAND.START:
				if (!this._counterPlay)
				{
					this._counterPlay = true;
					this.runCounter();
					return;
				}
				break;
			case ProgramModule.BlockCounter.COMMAND.STOP:
				this._counterPlay = false;
				return;
			case ProgramModule.BlockCounter.COMMAND.RESET:
				this._counter = 0;
				this._window.updateClock();
				break;
			default:
				return;
			}
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00065E8C File Offset: 0x0006408C
		private async void runCounter()
		{
			if (!this._isRunningCounter)
			{
				await Task.Run(delegate
				{
					this._isRunningCounter = true;
					while (this._counterPlay && this._state != Simulator.STATE.STOP)
					{
						Thread.Sleep(1000);
						if (this._state == Simulator.STATE.STOP || !this._counterPlay)
						{
							break;
						}
						if (this._counter < 255)
						{
							this._counter++;
							this._window.updateClock();
						}
						this._window.Invoke(this._onUpdateSimulator_Delegate);
					}
					this._isRunningCounter = false;
				});
			}
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x00065EC4 File Offset: 0x000640C4
		private void runProgramSubroutine(ProgramModule.BlockSubroutine blockSubroutine)
		{
			this.setBlockSelected(blockSubroutine, false);
			this.pushCall(blockSubroutine);
			ProgramModules.ROUTINE routine = this._routine;
			this._routine = blockSubroutine.Index + ProgramModules.ROUTINE.SUB_1;
			this.runProgram(this._programs.Programs[(int)this._routine].Start);
			if (this._state == Simulator.STATE.RUN)
			{
				this._routine = routine;
				this.popCall();
			}
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x00065F28 File Offset: 0x00064128
		private void runProgramDisplay(ProgramModule.BlockDisplay blockDisplay)
		{
			this._window.setDisplayMode(blockDisplay.Mode, blockDisplay.VariableIndex);
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00065F44 File Offset: 0x00064144
		private void runProgramUsbOut(ProgramModule.BlockUsbOut blockDisplay)
		{
			switch (blockDisplay.Mode)
			{
			case ProgramModule.BlockUsbOut.USBOUT.ON:
				this._window.setUsbOut(true);
				return;
			case ProgramModule.BlockUsbOut.USBOUT.ON_TIME:
			{
				this._window.setUsbOut(true);
				float num = 0f;
				while (num < blockDisplay.Time)
				{
					num += 0.1f;
					Thread.Sleep(100);
					if (this._state == Simulator.STATE.STOP)
					{
						break;
					}
				}
				this._window.setUsbOut(false);
				return;
			}
			case ProgramModule.BlockUsbOut.USBOUT.OFF:
				this._window.setUsbOut(false);
				return;
			default:
				return;
			}
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00065FC8 File Offset: 0x000641C8
		private int ArithmeticRange(int x)
		{
			int num = 0;
			bool flag = true;
			if (127 < x)
			{
				do
				{
					num++;
					if (256 * num - 128 <= x && 256 * num + 127 >= x)
					{
						x -= 256 * num;
						flag = false;
					}
				}
				while (flag);
			}
			else if (-128 > x)
			{
				do
				{
					num--;
					if (256 * num - 128 <= x && 256 * num + 127 >= x)
					{
						x -= 256 * num;
						flag = false;
					}
				}
				while (flag);
			}
			return x;
		}

		// Token: 0x04000661 RID: 1633
		private SimulatorWindow _window;

		// Token: 0x04000662 RID: 1634
		private ProgramModules _programs;

		// Token: 0x04000663 RID: 1635
		private Simulator.STATE _state;

		// Token: 0x0400066E RID: 1646
		private int[] _loopCounts = new int[6];

		// Token: 0x0400066F RID: 1647
		private ProgramModule.BlockLoopStart[] _loopStartBlocks = new ProgramModule.BlockLoopStart[6];

		// Token: 0x04000670 RID: 1648
		private int _loopIndex = -1;

		// Token: 0x04000671 RID: 1649
		private int[] _variables;

		// Token: 0x04000672 RID: 1650
		private int _counter;

		// Token: 0x04000673 RID: 1651
		private bool _counterPlay;

		// Token: 0x04000674 RID: 1652
		private float _waitTime;

		// Token: 0x04000675 RID: 1653
		private List<ProgramModule.BlockSubroutine> _callStack = new List<ProgramModule.BlockSubroutine>();

		// Token: 0x04000676 RID: 1654
		private ProgramModule.Block _breakBlock;

		// Token: 0x04000677 RID: 1655
		private ProgramModules.ROUTINE _routine;

		// Token: 0x04000678 RID: 1656
		private bool _isRunningProgram;

		// Token: 0x04000679 RID: 1657
		private bool _isRunningCounter;

		// Token: 0x0400067A RID: 1658
		private bool _step;

		// Token: 0x0400067B RID: 1659
		private Random _random = new Random();

		// Token: 0x0400067C RID: 1660
		private SimulatorWindow.onUpdateSimulator_Delegate _onUpdateSimulator_Delegate;

		// Token: 0x0400067D RID: 1661
		private Color _clearColor = Color.FromArgb(0, 0, 0, 0);

		// Token: 0x020000D3 RID: 211
		public enum STATE
		{
			// Token: 0x04000964 RID: 2404
			STOP,
			// Token: 0x04000965 RID: 2405
			RUN
		}

		// Token: 0x020000D4 RID: 212
		public enum LIGHT
		{
			// Token: 0x04000967 RID: 2407
			BRIGHT,
			// Token: 0x04000968 RID: 2408
			DARK
		}
	}
}
