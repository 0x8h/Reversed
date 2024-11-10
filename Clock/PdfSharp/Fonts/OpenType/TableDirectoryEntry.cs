using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x020000A4 RID: 164
	internal class TableDirectoryEntry
	{
		// Token: 0x06000760 RID: 1888 RVA: 0x0001C82E File Offset: 0x0001AA2E
		public TableDirectoryEntry()
		{
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0001C836 File Offset: 0x0001AA36
		public TableDirectoryEntry(string tag)
		{
			this.Tag = tag;
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000762 RID: 1890 RVA: 0x0001C845 File Offset: 0x0001AA45
		public int PaddedLength
		{
			get
			{
				return (this.Length + 3) & -4;
			}
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0001C854 File Offset: 0x0001AA54
		public static TableDirectoryEntry ReadFrom(OpenTypeFontface fontData)
		{
			return new TableDirectoryEntry
			{
				Tag = fontData.ReadTag(),
				CheckSum = fontData.ReadULong(),
				Offset = fontData.ReadLong(),
				Length = (int)fontData.ReadULong()
			};
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0001C898 File Offset: 0x0001AA98
		public void Read(OpenTypeFontface fontData)
		{
			this.Tag = fontData.ReadTag();
			this.CheckSum = fontData.ReadULong();
			this.Offset = fontData.ReadLong();
			this.Length = (int)fontData.ReadULong();
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x0001C8CA File Offset: 0x0001AACA
		public void Write(OpenTypeFontWriter writer)
		{
			writer.WriteTag(this.Tag);
			writer.WriteUInt(this.CheckSum);
			writer.WriteInt(this.Offset);
			writer.WriteUInt((uint)this.Length);
		}

		// Token: 0x040003EF RID: 1007
		public string Tag;

		// Token: 0x040003F0 RID: 1008
		public uint CheckSum;

		// Token: 0x040003F1 RID: 1009
		public int Offset;

		// Token: 0x040003F2 RID: 1010
		public int Length;

		// Token: 0x040003F3 RID: 1011
		public OpenTypeFontTable FontTable;
	}
}
