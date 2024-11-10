using System;
using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001A5 RID: 421
	[DebuggerDisplay("({Value})")]
	public sealed class PdfNameObject : PdfObject
	{
		// Token: 0x06000D8B RID: 3467 RVA: 0x0003566F File Offset: 0x0003386F
		public PdfNameObject()
		{
			this._value = "/";
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x00035682 File Offset: 0x00033882
		public PdfNameObject(PdfDocument document, string value)
			: base(document)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.Length == 0 || value[0] != '/')
			{
				throw new ArgumentException(PSSR.NameMustStartWithSlash);
			}
			this._value = value;
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x000356BE File Offset: 0x000338BE
		public override bool Equals(object obj)
		{
			return this._value.Equals(obj);
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x000356CC File Offset: 0x000338CC
		public override int GetHashCode()
		{
			return this._value.GetHashCode();
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06000D8F RID: 3471 RVA: 0x000356D9 File Offset: 0x000338D9
		// (set) Token: 0x06000D90 RID: 3472 RVA: 0x000356E1 File Offset: 0x000338E1
		public string Value
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

		// Token: 0x06000D91 RID: 3473 RVA: 0x000356EA File Offset: 0x000338EA
		public override string ToString()
		{
			return this._value;
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x000356F2 File Offset: 0x000338F2
		public static bool operator ==(PdfNameObject name, string str)
		{
			return name._value == str;
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x00035700 File Offset: 0x00033900
		public static bool operator !=(PdfNameObject name, string str)
		{
			return name._value != str;
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x0003570E File Offset: 0x0003390E
		internal override void WriteObject(PdfWriter writer)
		{
			writer.WriteBeginObject(this);
			writer.Write(new PdfName(this._value));
			writer.WriteEndObject();
		}

		// Token: 0x0400087D RID: 2173
		private string _value;
	}
}
