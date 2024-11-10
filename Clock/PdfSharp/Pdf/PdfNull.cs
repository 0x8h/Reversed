using System;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001A6 RID: 422
	public sealed class PdfNull : PdfItem
	{
		// Token: 0x06000D95 RID: 3477 RVA: 0x0003572E File Offset: 0x0003392E
		private PdfNull()
		{
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x00035736 File Offset: 0x00033936
		public override string ToString()
		{
			return "null";
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x0003573D File Offset: 0x0003393D
		internal override void WriteObject(PdfWriter writer)
		{
			writer.WriteRaw(" null ");
		}

		// Token: 0x0400087E RID: 2174
		public static readonly PdfNull Value = new PdfNull();
	}
}
