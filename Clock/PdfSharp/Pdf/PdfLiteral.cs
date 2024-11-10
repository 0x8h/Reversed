using System;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001A2 RID: 418
	public sealed class PdfLiteral : PdfItem
	{
		// Token: 0x06000D77 RID: 3447 RVA: 0x000354DB File Offset: 0x000336DB
		public PdfLiteral()
		{
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x000354EE File Offset: 0x000336EE
		public PdfLiteral(string value)
		{
			this._value = value;
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x00035508 File Offset: 0x00033708
		public PdfLiteral(string format, params object[] args)
		{
			this._value = PdfEncoders.Format(format, args);
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x00035528 File Offset: 0x00033728
		public static PdfLiteral FromMatrix(XMatrix matrix)
		{
			return new PdfLiteral("[" + PdfEncoders.ToString(matrix) + "]");
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06000D7B RID: 3451 RVA: 0x00035544 File Offset: 0x00033744
		public string Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x0003554C File Offset: 0x0003374C
		public override string ToString()
		{
			return this._value;
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x00035554 File Offset: 0x00033754
		internal override void WriteObject(PdfWriter writer)
		{
			writer.Write(this);
		}

		// Token: 0x0400087A RID: 2170
		private readonly string _value = string.Empty;
	}
}
