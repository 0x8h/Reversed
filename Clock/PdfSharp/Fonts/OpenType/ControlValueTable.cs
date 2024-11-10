using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x0200009E RID: 158
	internal class ControlValueTable : OpenTypeFontTable
	{
		// Token: 0x06000746 RID: 1862 RVA: 0x0001C44C File Offset: 0x0001A64C
		public ControlValueTable(OpenTypeFontface fontData)
			: base(fontData, "cvt ")
		{
			this.DirectoryEntry.Tag = "cvt ";
			this.DirectoryEntry = fontData.TableDictionary["cvt "];
			this.Read();
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x0001C488 File Offset: 0x0001A688
		public void Read()
		{
			try
			{
				int num = this.DirectoryEntry.Length / 2;
				this.array = new short[num];
				for (int i = 0; i < num; i++)
				{
					this.array[i] = this._fontData.ReadFWord();
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x040003E7 RID: 999
		public const string Tag = "cvt ";

		// Token: 0x040003E8 RID: 1000
		private short[] array;
	}
}
