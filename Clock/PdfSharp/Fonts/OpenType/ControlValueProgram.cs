using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x020000A0 RID: 160
	internal class ControlValueProgram : OpenTypeFontTable
	{
		// Token: 0x0600074A RID: 1866 RVA: 0x0001C590 File Offset: 0x0001A790
		public ControlValueProgram(OpenTypeFontface fontData)
			: base(fontData, "prep")
		{
			this.DirectoryEntry.Tag = "prep";
			this.DirectoryEntry = fontData.TableDictionary["prep"];
			this.Read();
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x0001C5CC File Offset: 0x0001A7CC
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

		// Token: 0x040003EB RID: 1003
		public const string Tag = "prep";

		// Token: 0x040003EC RID: 1004
		private byte[] bytes;
	}
}
