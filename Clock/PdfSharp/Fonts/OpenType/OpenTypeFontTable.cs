using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000084 RID: 132
	internal class OpenTypeFontTable : ICloneable
	{
		// Token: 0x060006D4 RID: 1748 RVA: 0x0001926C File Offset: 0x0001746C
		public OpenTypeFontTable(OpenTypeFontface fontData, string tag)
		{
			this._fontData = fontData;
			if (fontData != null && fontData.TableDictionary.ContainsKey(tag))
			{
				this.DirectoryEntry = fontData.TableDictionary[tag];
			}
			else
			{
				this.DirectoryEntry = new TableDirectoryEntry(tag);
			}
			this.DirectoryEntry.FontTable = this;
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x000192C3 File Offset: 0x000174C3
		public object Clone()
		{
			return this.DeepCopy();
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x000192CC File Offset: 0x000174CC
		protected virtual OpenTypeFontTable DeepCopy()
		{
			OpenTypeFontTable openTypeFontTable = (OpenTypeFontTable)base.MemberwiseClone();
			openTypeFontTable.DirectoryEntry.Offset = 0;
			openTypeFontTable.DirectoryEntry.FontTable = openTypeFontTable;
			return openTypeFontTable;
		}

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x000192FE File Offset: 0x000174FE
		public OpenTypeFontface FontData
		{
			get
			{
				return this._fontData;
			}
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00019306 File Offset: 0x00017506
		public virtual void PrepareForCompilation()
		{
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00019308 File Offset: 0x00017508
		public virtual void Write(OpenTypeFontWriter writer)
		{
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0001930C File Offset: 0x0001750C
		public static uint CalcChecksum(byte[] bytes)
		{
			uint num4;
			uint num3;
			uint num2;
			uint num = (num2 = (num3 = (num4 = 0U)));
			int num5 = bytes.Length;
			int i = 0;
			while (i < num5)
			{
				num2 += (uint)bytes[i++];
				num += (uint)bytes[i++];
				num3 += (uint)bytes[i++];
				num4 += (uint)bytes[i++];
			}
			return (num2 << 24) + (num << 16) + (num3 << 8) + num4;
		}

		// Token: 0x04000306 RID: 774
		internal OpenTypeFontface _fontData;

		// Token: 0x04000307 RID: 775
		public TableDirectoryEntry DirectoryEntry;
	}
}
