using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001B3 RID: 435
	[DebuggerDisplay("({Value})")]
	public sealed class PdfReal : PdfNumber
	{
		// Token: 0x06000E49 RID: 3657 RVA: 0x00038514 File Offset: 0x00036714
		public PdfReal()
		{
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x0003851C File Offset: 0x0003671C
		public PdfReal(double value)
		{
			this._value = value;
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06000E4B RID: 3659 RVA: 0x0003852B File Offset: 0x0003672B
		public double Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x00038534 File Offset: 0x00036734
		public override string ToString()
		{
			return this._value.ToString("0.###", CultureInfo.InvariantCulture);
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x00038559 File Offset: 0x00036759
		internal override void WriteObject(PdfWriter writer)
		{
			writer.Write(this);
		}

		// Token: 0x040008D5 RID: 2261
		private readonly double _value;
	}
}
