using System;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001A7 RID: 423
	public sealed class PdfNullObject : PdfObject
	{
		// Token: 0x06000D99 RID: 3481 RVA: 0x00035756 File Offset: 0x00033956
		public PdfNullObject()
		{
		}

		// Token: 0x06000D9A RID: 3482 RVA: 0x0003575E File Offset: 0x0003395E
		public PdfNullObject(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x00035767 File Offset: 0x00033967
		public override string ToString()
		{
			return "null";
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x0003576E File Offset: 0x0003396E
		internal override void WriteObject(PdfWriter writer)
		{
			writer.WriteBeginObject(this);
			writer.WriteRaw(" null ");
			writer.WriteEndObject();
		}
	}
}
