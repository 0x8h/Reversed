using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001BC RID: 444
	[DebuggerDisplay("({Value})")]
	public sealed class PdfUIntegerObject : PdfNumberObject
	{
		// Token: 0x06000EBC RID: 3772 RVA: 0x00039904 File Offset: 0x00037B04
		public PdfUIntegerObject()
		{
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x0003990C File Offset: 0x00037B0C
		public PdfUIntegerObject(uint value)
		{
			this._value = value;
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x0003991B File Offset: 0x00037B1B
		public PdfUIntegerObject(PdfDocument document, uint value)
			: base(document)
		{
			this._value = value;
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06000EBF RID: 3775 RVA: 0x0003992B File Offset: 0x00037B2B
		public uint Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x00039934 File Offset: 0x00037B34
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x00039954 File Offset: 0x00037B54
		internal override void WriteObject(PdfWriter writer)
		{
			writer.WriteBeginObject(this);
			writer.Write(this._value);
			writer.WriteEndObject();
		}

		// Token: 0x040008FB RID: 2299
		private readonly uint _value;
	}
}
