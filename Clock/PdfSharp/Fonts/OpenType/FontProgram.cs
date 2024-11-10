using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x0200009F RID: 159
	internal class FontProgram : OpenTypeFontTable
	{
		// Token: 0x06000748 RID: 1864 RVA: 0x0001C4F0 File Offset: 0x0001A6F0
		public FontProgram(OpenTypeFontface fontData)
			: base(fontData, "fpgm")
		{
			this.DirectoryEntry.Tag = "fpgm";
			this.DirectoryEntry = fontData.TableDictionary["fpgm"];
			this.Read();
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0001C52C File Offset: 0x0001A72C
		public void Read()
		{
			try
			{
				int length = this.DirectoryEntry.Length;
				this.bytes = new byte[length];
				for (int i = 0; i < length; i++)
				{
					this.bytes[i] = this._fontData.ReadByte();
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x040003E9 RID: 1001
		public const string Tag = "fpgm";

		// Token: 0x040003EA RID: 1002
		private byte[] bytes;
	}
}
