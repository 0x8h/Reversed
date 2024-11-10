using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001A1 RID: 417
	[DebuggerDisplay("({Value})")]
	public sealed class PdfIntegerObject : PdfNumberObject
	{
		// Token: 0x06000D71 RID: 3441 RVA: 0x00035471 File Offset: 0x00033671
		public PdfIntegerObject()
		{
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x00035479 File Offset: 0x00033679
		public PdfIntegerObject(int value)
		{
			this._value = value;
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x00035488 File Offset: 0x00033688
		public PdfIntegerObject(PdfDocument document, int value)
			: base(document)
		{
			this._value = value;
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06000D74 RID: 3444 RVA: 0x00035498 File Offset: 0x00033698
		public int Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x000354A0 File Offset: 0x000336A0
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x000354C0 File Offset: 0x000336C0
		internal override void WriteObject(PdfWriter writer)
		{
			writer.WriteBeginObject(this);
			writer.Write(this._value);
			writer.WriteEndObject();
		}

		// Token: 0x04000879 RID: 2169
		private readonly int _value;
	}
}
