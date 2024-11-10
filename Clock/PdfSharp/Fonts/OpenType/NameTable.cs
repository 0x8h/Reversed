using System;
using System.Text;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000099 RID: 153
	internal class NameTable : OpenTypeFontTable
	{
		// Token: 0x0600073C RID: 1852 RVA: 0x0001BDD8 File Offset: 0x00019FD8
		public NameTable(OpenTypeFontface fontData)
			: base(fontData, "name")
		{
			this.Read();
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0001BE10 File Offset: 0x0001A010
		public void Read()
		{
			try
			{
				this.bytes = new byte[this.DirectoryEntry.PaddedLength];
				Buffer.BlockCopy(this._fontData.FontSource.Bytes, this.DirectoryEntry.Offset, this.bytes, 0, this.DirectoryEntry.Length);
				this.format = this._fontData.ReadUShort();
				this.count = this._fontData.ReadUShort();
				this.stringOffset = this._fontData.ReadUShort();
				for (int i = 0; i < (int)this.count; i++)
				{
					NameTable.NameRecord nameRecord = this.ReadNameRecord();
					byte[] array = new byte[(int)nameRecord.length];
					Buffer.BlockCopy(this._fontData.FontSource.Bytes, this.DirectoryEntry.Offset + (int)this.stringOffset + (int)nameRecord.offset, array, 0, (int)nameRecord.length);
					if (nameRecord.platformID == 0 || nameRecord.platformID == 3)
					{
						if (nameRecord.nameID == 1 && nameRecord.languageID == 1033 && string.IsNullOrEmpty(this.Name))
						{
							this.Name = Encoding.BigEndianUnicode.GetString(array, 0, array.Length);
						}
						if (nameRecord.nameID == 2 && nameRecord.languageID == 1033 && string.IsNullOrEmpty(this.Style))
						{
							this.Style = Encoding.BigEndianUnicode.GetString(array, 0, array.Length);
						}
						if (nameRecord.nameID == 4 && nameRecord.languageID == 1033 && string.IsNullOrEmpty(this.FullFontName))
						{
							this.FullFontName = Encoding.BigEndianUnicode.GetString(array, 0, array.Length);
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x0001BFE0 File Offset: 0x0001A1E0
		private NameTable.NameRecord ReadNameRecord()
		{
			return new NameTable.NameRecord
			{
				platformID = this._fontData.ReadUShort(),
				encodingID = this._fontData.ReadUShort(),
				languageID = this._fontData.ReadUShort(),
				nameID = this._fontData.ReadUShort(),
				length = this._fontData.ReadUShort(),
				offset = this._fontData.ReadUShort()
			};
		}

		// Token: 0x040003A5 RID: 933
		public const string Tag = "name";

		// Token: 0x040003A6 RID: 934
		public string Name = string.Empty;

		// Token: 0x040003A7 RID: 935
		public string Style = string.Empty;

		// Token: 0x040003A8 RID: 936
		public string FullFontName = string.Empty;

		// Token: 0x040003A9 RID: 937
		public ushort format;

		// Token: 0x040003AA RID: 938
		public ushort count;

		// Token: 0x040003AB RID: 939
		public ushort stringOffset;

		// Token: 0x040003AC RID: 940
		private byte[] bytes;

		// Token: 0x0200009A RID: 154
		private class NameRecord
		{
			// Token: 0x040003AD RID: 941
			public ushort platformID;

			// Token: 0x040003AE RID: 942
			public ushort encodingID;

			// Token: 0x040003AF RID: 943
			public ushort languageID;

			// Token: 0x040003B0 RID: 944
			public ushort nameID;

			// Token: 0x040003B1 RID: 945
			public ushort length;

			// Token: 0x040003B2 RID: 946
			public ushort offset;
		}
	}
}
