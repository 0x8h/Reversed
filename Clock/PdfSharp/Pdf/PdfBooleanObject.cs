using System;
using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x02000193 RID: 403
	[DebuggerDisplay("({Value})")]
	public sealed class PdfBooleanObject : PdfObject
	{
		// Token: 0x06000CD4 RID: 3284 RVA: 0x000342C6 File Offset: 0x000324C6
		public PdfBooleanObject()
		{
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x000342CE File Offset: 0x000324CE
		public PdfBooleanObject(bool value)
		{
			this._value = value;
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x000342DD File Offset: 0x000324DD
		public PdfBooleanObject(PdfDocument document, bool value)
			: base(document)
		{
			this._value = value;
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06000CD7 RID: 3287 RVA: 0x000342ED File Offset: 0x000324ED
		public bool Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x000342F5 File Offset: 0x000324F5
		public override string ToString()
		{
			if (!this._value)
			{
				return bool.FalseString;
			}
			return bool.TrueString;
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x0003430A File Offset: 0x0003250A
		internal override void WriteObject(PdfWriter writer)
		{
			writer.WriteBeginObject(this);
			writer.Write(this._value);
			writer.WriteEndObject();
		}

		// Token: 0x04000842 RID: 2114
		private readonly bool _value;
	}
}
