using System;
using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x02000196 RID: 406
	[DebuggerDisplay("({Value})")]
	public sealed class PdfDate : PdfItem
	{
		// Token: 0x06000CEA RID: 3306 RVA: 0x000344F0 File Offset: 0x000326F0
		public PdfDate()
		{
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x000344F8 File Offset: 0x000326F8
		public PdfDate(string value)
		{
			this._value = Parser.ParseDateTime(value, DateTime.MinValue);
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x00034511 File Offset: 0x00032711
		public PdfDate(DateTime value)
		{
			this._value = value;
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06000CED RID: 3309 RVA: 0x00034520 File Offset: 0x00032720
		public DateTime Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x00034528 File Offset: 0x00032728
		public override string ToString()
		{
			string text = this._value.ToString("zzz").Replace(':', '\'');
			return string.Format("D:{0:yyyyMMddHHmmss}{1}'", this._value, text);
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x00034565 File Offset: 0x00032765
		internal override void WriteObject(PdfWriter writer)
		{
			writer.WriteDocString(this.ToString());
		}

		// Token: 0x04000844 RID: 2116
		private DateTime _value;
	}
}
