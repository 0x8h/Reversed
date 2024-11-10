using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000089 RID: 137
	internal class IRefFontTable : OpenTypeFontTable
	{
		// Token: 0x060006F6 RID: 1782 RVA: 0x00019C1C File Offset: 0x00017E1C
		public IRefFontTable(OpenTypeFontface fontData, OpenTypeFontTable fontTable)
			: base(null, fontTable.DirectoryEntry.Tag)
		{
			this._fontData = fontData;
			this._irefDirectoryEntry = fontTable.DirectoryEntry;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00019C43 File Offset: 0x00017E43
		public override void PrepareForCompilation()
		{
			base.PrepareForCompilation();
			this.DirectoryEntry.Length = this._irefDirectoryEntry.Length;
			this.DirectoryEntry.CheckSum = this._irefDirectoryEntry.CheckSum;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00019C77 File Offset: 0x00017E77
		public override void Write(OpenTypeFontWriter writer)
		{
			writer.Write(this._irefDirectoryEntry.FontTable._fontData.FontSource.Bytes, this._irefDirectoryEntry.Offset, this._irefDirectoryEntry.PaddedLength);
		}

		// Token: 0x04000318 RID: 792
		private readonly TableDirectoryEntry _irefDirectoryEntry;
	}
}
