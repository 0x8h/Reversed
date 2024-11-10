using System;
using System.IO;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x020000A3 RID: 163
	internal class OpenTypeFontWriter : FontWriter
	{
		// Token: 0x0600075E RID: 1886 RVA: 0x0001C7EB File Offset: 0x0001A9EB
		public OpenTypeFontWriter(Stream stream)
			: base(stream)
		{
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0001C7F4 File Offset: 0x0001A9F4
		public void WriteTag(string tag)
		{
			base.WriteByte((byte)tag[0]);
			base.WriteByte((byte)tag[1]);
			base.WriteByte((byte)tag[2]);
			base.WriteByte((byte)tag[3]);
		}
	}
}
