using System;
using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x02000192 RID: 402
	[DebuggerDisplay("({Value})")]
	public sealed class PdfBoolean : PdfItem
	{
		// Token: 0x06000CCE RID: 3278 RVA: 0x00034271 File Offset: 0x00032471
		public PdfBoolean()
		{
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x00034279 File Offset: 0x00032479
		public PdfBoolean(bool value)
		{
			this._value = value;
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000CD0 RID: 3280 RVA: 0x00034288 File Offset: 0x00032488
		public bool Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x00034290 File Offset: 0x00032490
		public override string ToString()
		{
			if (!this._value)
			{
				return bool.FalseString;
			}
			return bool.TrueString;
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x000342A5 File Offset: 0x000324A5
		internal override void WriteObject(PdfWriter writer)
		{
			writer.Write(this);
		}

		// Token: 0x0400083F RID: 2111
		private readonly bool _value;

		// Token: 0x04000840 RID: 2112
		public static readonly PdfBoolean True = new PdfBoolean(true);

		// Token: 0x04000841 RID: 2113
		public static readonly PdfBoolean False = new PdfBoolean(false);
	}
}
