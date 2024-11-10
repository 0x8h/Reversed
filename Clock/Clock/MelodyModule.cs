using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Clock
{
	// Token: 0x0200002D RID: 45
	public class MelodyModule
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x0003CEF8 File Offset: 0x0003B0F8
		// (set) Token: 0x060004A8 RID: 1192 RVA: 0x0003CF00 File Offset: 0x0003B100
		public List<MelodyModule.Key> Keys
		{
			get
			{
				return this._keys;
			}
			set
			{
				this._keys = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x0003CF09 File Offset: 0x0003B109
		// (set) Token: 0x060004AA RID: 1194 RVA: 0x0003CF11 File Offset: 0x0003B111
		public int tempoIndex
		{
			get
			{
				return this._tempoIndex;
			}
			set
			{
				this._tempoIndex = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x0003CF1A File Offset: 0x0003B11A
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x0003CF22 File Offset: 0x0003B122
		public bool ledFlag
		{
			get
			{
				return this._ledFlag;
			}
			set
			{
				this._ledFlag = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0003CF2B File Offset: 0x0003B12B
		// (set) Token: 0x060004AE RID: 1198 RVA: 0x0003CF33 File Offset: 0x0003B133
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

		// Token: 0x060004B0 RID: 1200 RVA: 0x0003CF5C File Offset: 0x0003B15C
		public byte[] serializeBinary()
		{
			byte[] array = Enumerable.Repeat<byte>(0, 254).ToArray<byte>();
			array[0] = (byte)((this._tempoIndex << 1) + (int)Convert.ToInt16(this._ledFlag));
			for (int i = 0; i < this._keys.Count; i++)
			{
				array[i + 1] = (byte)((this._keys[i].Rank + 1 << 3) + (int)this._keys[i].Length);
			}
			return array;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0003CFD8 File Offset: 0x0003B1D8
		public void deserializeBinary(byte[] bytes)
		{
			if (bytes.Length > 254)
			{
				WarningDialog warningDialog = new WarningDialog();
				warningDialog.setText("メロディデータが古いフォーマットのため、\r\n一部が切り取られる可能性があります。");
				warningDialog.ShowDialog();
			}
			int num = Math.Min(bytes.Length, 254);
			this._tempoIndex = ((int)bytes[0] & Convert.ToInt32("00001110", 2)) >> 1;
			this._ledFlag = Convert.ToBoolean((int)bytes[0] & Convert.ToInt32("00000001", 2));
			List<MelodyModule.Key> list = new List<MelodyModule.Key>();
			for (int i = 1; i < num; i++)
			{
				if (((int)bytes[i] & Convert.ToInt32("11111000", 2)) >> 3 != 0)
				{
					list.Add(new MelodyModule.Key
					{
						Rank = (MelodyModule.Key.RANK)((((int)bytes[i] & Convert.ToInt32("11111000", 2)) >> 3) - 1),
						Length = (MelodyModule.Key.LENGTH)((int)bytes[i] & Convert.ToInt32("00000111", 2))
					});
				}
			}
			this._keys = list;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0003D0AB File Offset: 0x0003B2AB
		public void addKey(MelodyModule.Key key)
		{
			this._keys.Add(key);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0003D0B9 File Offset: 0x0003B2B9
		public void removeKey(MelodyModule.Key key)
		{
			this._keys.Remove(key);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0003D0C8 File Offset: 0x0003B2C8
		public void removeAllKeys()
		{
			this._keys.Clear();
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0003D0D5 File Offset: 0x0003B2D5
		public int getUsedMemory()
		{
			return 1 + this._keys.Count;
		}

		// Token: 0x040003EB RID: 1003
		public const int USE_MEMORY_MAX = 254;

		// Token: 0x040003EC RID: 1004
		private List<MelodyModule.Key> _keys = new List<MelodyModule.Key>();

		// Token: 0x040003ED RID: 1005
		private int _tempoIndex;

		// Token: 0x040003EE RID: 1006
		private bool _ledFlag;

		// Token: 0x040003EF RID: 1007
		private ReportModule _report = new ReportModule();

		// Token: 0x0200009D RID: 157
		public class Key
		{
			// Token: 0x170004B9 RID: 1209
			// (get) Token: 0x06001058 RID: 4184 RVA: 0x00090CAD File Offset: 0x0008EEAD
			// (set) Token: 0x06001059 RID: 4185 RVA: 0x00090CB5 File Offset: 0x0008EEB5
			public MelodyModule.Key.RANK Rank
			{
				get
				{
					return this._rank;
				}
				set
				{
					this._rank = value;
				}
			}

			// Token: 0x170004BA RID: 1210
			// (get) Token: 0x0600105A RID: 4186 RVA: 0x00090CBE File Offset: 0x0008EEBE
			// (set) Token: 0x0600105B RID: 4187 RVA: 0x00090CC6 File Offset: 0x0008EEC6
			public MelodyModule.Key.LENGTH Length
			{
				get
				{
					return this._length;
				}
				set
				{
					this._length = value;
				}
			}

			// Token: 0x170004BB RID: 1211
			// (get) Token: 0x0600105C RID: 4188 RVA: 0x00090CCF File Offset: 0x0008EECF
			// (set) Token: 0x0600105D RID: 4189 RVA: 0x00090CD7 File Offset: 0x0008EED7
			[XmlIgnore]
			public bool Selected
			{
				get
				{
					return this._selected;
				}
				set
				{
					this._selected = value;
				}
			}

			// Token: 0x0600105E RID: 4190 RVA: 0x00090CE0 File Offset: 0x0008EEE0
			public MelodyModule.Key.NOTE_SELECT judgeSelect()
			{
				if (this.Selected)
				{
					return MelodyModule.Key.NOTE_SELECT.SELECTED;
				}
				return MelodyModule.Key.NOTE_SELECT.UNSELECTED;
			}

			// Token: 0x0600105F RID: 4191 RVA: 0x00090CF0 File Offset: 0x0008EEF0
			public int getBlockSize()
			{
				switch (this.Length)
				{
				case MelodyModule.Key.LENGTH.SIXTEEN:
					return 1;
				case MelodyModule.Key.LENGTH.EIGHT:
					return 2;
				case MelodyModule.Key.LENGTH.EIGHT_DOT:
					return 3;
				case MelodyModule.Key.LENGTH.FOUR:
					return 4;
				case MelodyModule.Key.LENGTH.FOUR_DOT:
					return 6;
				case MelodyModule.Key.LENGTH.TWO:
					return 8;
				case MelodyModule.Key.LENGTH.TWO_DOT:
					return 12;
				case MelodyModule.Key.LENGTH.ONE:
					return 16;
				default:
					return 0;
				}
			}

			// Token: 0x06001060 RID: 4192 RVA: 0x00090D3F File Offset: 0x0008EF3F
			public static int getFrequency(MelodyModule.Key.RANK rank)
			{
				return MelodyModule.Key.FREQUENCYS[(int)rank];
			}

			// Token: 0x06001061 RID: 4193 RVA: 0x00090D48 File Offset: 0x0008EF48
			public bool isSharp()
			{
				return (this.Rank == MelodyModule.Key.RANK.LOW_FA_SHARP) | (this.Rank == MelodyModule.Key.RANK.LOW_SO_SHARP) | (this.Rank == MelodyModule.Key.RANK.LOW_RA_SHARP) | (this.Rank == MelodyModule.Key.RANK.DO_SHARP) | (this.Rank == MelodyModule.Key.RANK.RE_SHARP) | (this.Rank == MelodyModule.Key.RANK.FA_SHARP) | (this.Rank == MelodyModule.Key.RANK.SO_SHARP) | (this.Rank == MelodyModule.Key.RANK.RA_SHARP) | (this.Rank == MelodyModule.Key.RANK.HIGH_DO_SHARP) | (this.Rank == MelodyModule.Key.RANK.HIGH_RE_SHARP) | (this.Rank == MelodyModule.Key.RANK.HIGH_FA_SHARP) | (this.Rank == MelodyModule.Key.RANK.HIGH_SO_SHARP) | (this.Rank == MelodyModule.Key.RANK.HIGH_RA_SHARP);
			}

			// Token: 0x06001062 RID: 4194 RVA: 0x00090DE4 File Offset: 0x0008EFE4
			public MelodyModule.Key.NOTE_BAR judgeNoteBar()
			{
				if (this.Rank <= MelodyModule.Key.RANK.SI)
				{
					return MelodyModule.Key.NOTE_BAR.TOP;
				}
				return MelodyModule.Key.NOTE_BAR.UNDER;
			}

			// Token: 0x06001063 RID: 4195 RVA: 0x00090DF4 File Offset: 0x0008EFF4
			public int getTopLine()
			{
				int num = 0;
				if ((this.Rank == MelodyModule.Key.RANK.HIGH_RA) | (this.Rank == MelodyModule.Key.RANK.HIGH_RA_SHARP) | (this.Rank == MelodyModule.Key.RANK.HIGH_SI))
				{
					num = 1;
				}
				return num;
			}

			// Token: 0x06001064 RID: 4196 RVA: 0x00090E28 File Offset: 0x0008F028
			public int getBottomLine()
			{
				int num = 0;
				if ((this.Rank == MelodyModule.Key.RANK.DO) | (this.Rank == MelodyModule.Key.RANK.DO_SHARP) | (this.Rank == MelodyModule.Key.RANK.LOW_SI))
				{
					num = 1;
				}
				else if ((this.Rank == MelodyModule.Key.RANK.LOW_RA) | (this.Rank == MelodyModule.Key.RANK.LOW_RA_SHARP) | (this.Rank == MelodyModule.Key.RANK.LOW_SO) | (this.Rank == MelodyModule.Key.RANK.LOW_SO_SHARP))
				{
					num = 2;
				}
				else if (this.Rank == MelodyModule.Key.RANK.LOW_FA_SHARP)
				{
					num = 3;
				}
				return num;
			}

			// Token: 0x06001065 RID: 4197 RVA: 0x00090E94 File Offset: 0x0008F094
			public static int adjustHeightNote(MelodyModule.Key.RANK rank)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 1;
				int num4 = 5;
				if (rank == MelodyModule.Key.RANK.HIGH_SI)
				{
					num = num2 - num4 * 4;
				}
				else if ((rank == MelodyModule.Key.RANK.HIGH_RA) | (rank == MelodyModule.Key.RANK.HIGH_RA_SHARP))
				{
					num = num2 - num4 * 3;
				}
				else if ((rank == MelodyModule.Key.RANK.HIGH_SO) | (rank == MelodyModule.Key.RANK.HIGH_SO_SHARP))
				{
					num = num2 - num4 * 2;
				}
				else if ((rank == MelodyModule.Key.RANK.HIGH_FA) | (rank == MelodyModule.Key.RANK.HIGH_FA_SHARP))
				{
					num = num2 - num4;
				}
				else if (rank == MelodyModule.Key.RANK.HIGH_MI)
				{
					num = num2;
				}
				else if ((rank == MelodyModule.Key.RANK.HIGH_RE) | (rank == MelodyModule.Key.RANK.HIGH_RE_SHARP))
				{
					num = num2 + num4;
				}
				else if ((rank == MelodyModule.Key.RANK.HIGH_DO) | (rank == MelodyModule.Key.RANK.HIGH_DO_SHARP))
				{
					num = num2 + num4 * 2;
				}
				else if (rank == MelodyModule.Key.RANK.SI)
				{
					num = num3 - num4 * 3;
				}
				else if ((rank == MelodyModule.Key.RANK.RA) | (rank == MelodyModule.Key.RANK.RA_SHARP))
				{
					num = num3 - num4 * 2;
				}
				else if ((rank == MelodyModule.Key.RANK.SO) | (rank == MelodyModule.Key.RANK.SO_SHARP))
				{
					num = num3 - num4;
				}
				else if ((rank == MelodyModule.Key.RANK.FA) | (rank == MelodyModule.Key.RANK.FA_SHARP))
				{
					num = num3;
				}
				else if (rank == MelodyModule.Key.RANK.MI)
				{
					num = num3 + num4;
				}
				else if ((rank == MelodyModule.Key.RANK.RE) | (rank == MelodyModule.Key.RANK.RE_SHARP))
				{
					num = num3 + num4 * 2;
				}
				else if ((rank == MelodyModule.Key.RANK.DO) | (rank == MelodyModule.Key.RANK.DO_SHARP))
				{
					num = num3 + num4 * 3;
				}
				else if (rank == MelodyModule.Key.RANK.LOW_SI)
				{
					num = num3 + num4 * 4;
				}
				else if ((rank == MelodyModule.Key.RANK.LOW_RA) | (rank == MelodyModule.Key.RANK.LOW_RA_SHARP))
				{
					num = num3 + num4 * 5;
				}
				else if ((rank == MelodyModule.Key.RANK.LOW_SO) | (rank == MelodyModule.Key.RANK.LOW_SO_SHARP))
				{
					num = num3 + num4 * 6;
				}
				else if (rank == MelodyModule.Key.RANK.LOW_FA_SHARP)
				{
					num = num3 + num4 * 7;
				}
				return num;
			}

			// Token: 0x06001066 RID: 4198 RVA: 0x00090FF8 File Offset: 0x0008F1F8
			public static int adjustHeightRest(MelodyModule.Key.LENGTH length)
			{
				int num = 0;
				if ((length == MelodyModule.Key.LENGTH.FOUR) | (length == MelodyModule.Key.LENGTH.ONE))
				{
					num = 2;
				}
				else if (length == MelodyModule.Key.LENGTH.TWO)
				{
					num = 1;
				}
				return num;
			}

			// Token: 0x06001068 RID: 4200 RVA: 0x0009102C File Offset: 0x0008F22C
			public static uint getMidiKey(MelodyModule.Key.RANK rank)
			{
				return (uint)(51 + rank);
			}

			// Token: 0x04000869 RID: 2153
			private MelodyModule.Key.RANK _rank;

			// Token: 0x0400086A RID: 2154
			private MelodyModule.Key.LENGTH _length = MelodyModule.Key.LENGTH.FOUR;

			// Token: 0x0400086B RID: 2155
			private bool _selected;

			// Token: 0x0400086C RID: 2156
			private static readonly int[] FREQUENCYS = new int[]
			{
				0, 185, 196, 208, 220, 233, 247, 262, 277, 294,
				311, 330, 349, 370, 392, 415, 440, 466, 494, 523,
				554, 587, 622, 659, 698, 740, 784, 831, 880, 932,
				988
			};

			// Token: 0x02000118 RID: 280
			public enum RANK
			{
				// Token: 0x04000BA7 RID: 2983
				REST,
				// Token: 0x04000BA8 RID: 2984
				LOW_FA_SHARP,
				// Token: 0x04000BA9 RID: 2985
				LOW_SO,
				// Token: 0x04000BAA RID: 2986
				LOW_SO_SHARP,
				// Token: 0x04000BAB RID: 2987
				LOW_RA,
				// Token: 0x04000BAC RID: 2988
				LOW_RA_SHARP,
				// Token: 0x04000BAD RID: 2989
				LOW_SI,
				// Token: 0x04000BAE RID: 2990
				DO,
				// Token: 0x04000BAF RID: 2991
				DO_SHARP,
				// Token: 0x04000BB0 RID: 2992
				RE,
				// Token: 0x04000BB1 RID: 2993
				RE_SHARP,
				// Token: 0x04000BB2 RID: 2994
				MI,
				// Token: 0x04000BB3 RID: 2995
				FA,
				// Token: 0x04000BB4 RID: 2996
				FA_SHARP,
				// Token: 0x04000BB5 RID: 2997
				SO,
				// Token: 0x04000BB6 RID: 2998
				SO_SHARP,
				// Token: 0x04000BB7 RID: 2999
				RA,
				// Token: 0x04000BB8 RID: 3000
				RA_SHARP,
				// Token: 0x04000BB9 RID: 3001
				SI,
				// Token: 0x04000BBA RID: 3002
				HIGH_DO,
				// Token: 0x04000BBB RID: 3003
				HIGH_DO_SHARP,
				// Token: 0x04000BBC RID: 3004
				HIGH_RE,
				// Token: 0x04000BBD RID: 3005
				HIGH_RE_SHARP,
				// Token: 0x04000BBE RID: 3006
				HIGH_MI,
				// Token: 0x04000BBF RID: 3007
				HIGH_FA,
				// Token: 0x04000BC0 RID: 3008
				HIGH_FA_SHARP,
				// Token: 0x04000BC1 RID: 3009
				HIGH_SO,
				// Token: 0x04000BC2 RID: 3010
				HIGH_SO_SHARP,
				// Token: 0x04000BC3 RID: 3011
				HIGH_RA,
				// Token: 0x04000BC4 RID: 3012
				HIGH_RA_SHARP,
				// Token: 0x04000BC5 RID: 3013
				HIGH_SI,
				// Token: 0x04000BC6 RID: 3014
				MAX
			}

			// Token: 0x02000119 RID: 281
			public enum LENGTH
			{
				// Token: 0x04000BC8 RID: 3016
				SIXTEEN,
				// Token: 0x04000BC9 RID: 3017
				EIGHT,
				// Token: 0x04000BCA RID: 3018
				EIGHT_DOT,
				// Token: 0x04000BCB RID: 3019
				FOUR,
				// Token: 0x04000BCC RID: 3020
				FOUR_DOT,
				// Token: 0x04000BCD RID: 3021
				TWO,
				// Token: 0x04000BCE RID: 3022
				TWO_DOT,
				// Token: 0x04000BCF RID: 3023
				ONE,
				// Token: 0x04000BD0 RID: 3024
				MAX
			}

			// Token: 0x0200011A RID: 282
			public enum NOTE_SELECT
			{
				// Token: 0x04000BD2 RID: 3026
				UNSELECTED,
				// Token: 0x04000BD3 RID: 3027
				SELECTED,
				// Token: 0x04000BD4 RID: 3028
				MAX
			}

			// Token: 0x0200011B RID: 283
			public enum NOTE_BAR
			{
				// Token: 0x04000BD6 RID: 3030
				TOP,
				// Token: 0x04000BD7 RID: 3031
				UNDER,
				// Token: 0x04000BD8 RID: 3032
				MAX
			}
		}
	}
}
