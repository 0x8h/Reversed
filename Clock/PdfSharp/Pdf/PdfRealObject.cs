using System;
using System.Globalization;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001B4 RID: 436
	public sealed class PdfRealObject : PdfNumberObject
	{
		// Token: 0x06000E4E RID: 3662 RVA: 0x00038562 File Offset: 0x00036762
		public PdfRealObject()
		{
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x0003856A File Offset: 0x0003676A
		public PdfRealObject(double value)
		{
			this._value = value;
		}

		// Token: 0x06000E50 RID: 3664 RVA: 0x00038579 File Offset: 0x00036779
		public PdfRealObject(PdfDocument document, double value)
			: base(document)
		{
			this._value = value;
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06000E51 RID: 3665 RVA: 0x00038589 File Offset: 0x00036789
		// (set) Token: 0x06000E52 RID: 3666 RVA: 0x00038591 File Offset: 0x00036791
		public double Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x0003859A File Offset: 0x0003679A
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x000385AC File Offset: 0x000367AC
		internal override void WriteObject(PdfWriter writer)
		{
			writer.WriteBeginObject(this);
			writer.Write(this._value);
			writer.WriteEndObject();
		}

		// Token: 0x040008D6 RID: 2262
		private double _value;
	}
}
