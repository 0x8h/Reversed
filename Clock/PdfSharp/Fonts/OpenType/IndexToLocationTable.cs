using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000088 RID: 136
	internal class IndexToLocationTable : OpenTypeFontTable
	{
		// Token: 0x060006F1 RID: 1777 RVA: 0x000199BB File Offset: 0x00017BBB
		public IndexToLocationTable()
			: base(null, "loca")
		{
			this.DirectoryEntry.Tag = "loca";
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x000199D9 File Offset: 0x00017BD9
		public IndexToLocationTable(OpenTypeFontface fontData)
			: base(fontData, "loca")
		{
			this.DirectoryEntry = this._fontData.TableDictionary["loca"];
			this.Read();
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00019A08 File Offset: 0x00017C08
		public void Read()
		{
			try
			{
				this.ShortIndex = this._fontData.head.indexToLocFormat == 0;
				this._fontData.Position = this.DirectoryEntry.Offset;
				if (this.ShortIndex)
				{
					int num = this.DirectoryEntry.Length / 2;
					this.LocaTable = new int[num];
					for (int i = 0; i < num; i++)
					{
						this.LocaTable[i] = (int)(2 * this._fontData.ReadUFWord());
					}
				}
				else
				{
					int num2 = this.DirectoryEntry.Length / 4;
					this.LocaTable = new int[num2];
					for (int j = 0; j < num2; j++)
					{
						this.LocaTable[j] = this._fontData.ReadLong();
					}
				}
			}
			catch (Exception)
			{
				base.GetType();
				throw;
			}
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00019AE0 File Offset: 0x00017CE0
		public override void PrepareForCompilation()
		{
			this.DirectoryEntry.Offset = 0;
			if (this.ShortIndex)
			{
				this.DirectoryEntry.Length = this.LocaTable.Length * 2;
			}
			else
			{
				this.DirectoryEntry.Length = this.LocaTable.Length * 4;
			}
			this._bytes = new byte[this.DirectoryEntry.PaddedLength];
			int num = this.LocaTable.Length;
			int num2 = 0;
			if (this.ShortIndex)
			{
				for (int i = 0; i < num; i++)
				{
					int num3 = this.LocaTable[i] / 2;
					this._bytes[num2++] = (byte)(num3 >> 8);
					this._bytes[num2++] = (byte)num3;
				}
			}
			else
			{
				for (int j = 0; j < num; j++)
				{
					int num4 = this.LocaTable[j];
					this._bytes[num2++] = (byte)(num4 >> 24);
					this._bytes[num2++] = (byte)(num4 >> 16);
					this._bytes[num2++] = (byte)(num4 >> 8);
					this._bytes[num2++] = (byte)num4;
				}
			}
			this.DirectoryEntry.CheckSum = OpenTypeFontTable.CalcChecksum(this._bytes);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00019C02 File Offset: 0x00017E02
		public override void Write(OpenTypeFontWriter writer)
		{
			writer.Write(this._bytes, 0, this.DirectoryEntry.PaddedLength);
		}

		// Token: 0x04000314 RID: 788
		public const string Tag = "loca";

		// Token: 0x04000315 RID: 789
		internal int[] LocaTable;

		// Token: 0x04000316 RID: 790
		public bool ShortIndex;

		// Token: 0x04000317 RID: 791
		private byte[] _bytes;
	}
}
