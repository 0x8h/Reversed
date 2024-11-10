using System;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001A3 RID: 419
	[DebuggerDisplay("({Value})")]
	public sealed class PdfName : PdfItem
	{
		// Token: 0x06000D7E RID: 3454 RVA: 0x0003555D File Offset: 0x0003375D
		public PdfName()
		{
			this._value = "/";
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x00035570 File Offset: 0x00033770
		public PdfName(string value)
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

		// Token: 0x06000D80 RID: 3456 RVA: 0x000355AB File Offset: 0x000337AB
		public override bool Equals(object obj)
		{
			return this._value.Equals(obj);
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x000355B9 File Offset: 0x000337B9
		public override int GetHashCode()
		{
			return this._value.GetHashCode();
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06000D82 RID: 3458 RVA: 0x000355C6 File Offset: 0x000337C6
		public string Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x000355CE File Offset: 0x000337CE
		public override string ToString()
		{
			return this._value;
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x000355D6 File Offset: 0x000337D6
		public static bool operator ==(PdfName name, string str)
		{
			if (object.ReferenceEquals(name, null))
			{
				return str == null;
			}
			return name._value == str;
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x000355F2 File Offset: 0x000337F2
		public static bool operator !=(PdfName name, string str)
		{
			if (object.ReferenceEquals(name, null))
			{
				return str != null;
			}
			return name._value != str;
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x00035611 File Offset: 0x00033811
		internal override void WriteObject(PdfWriter writer)
		{
			writer.Write(this);
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06000D87 RID: 3463 RVA: 0x0003561A File Offset: 0x0003381A
		public static PdfName.PdfXNameComparer Comparer
		{
			get
			{
				return new PdfName.PdfXNameComparer();
			}
		}

		// Token: 0x0400087B RID: 2171
		private readonly string _value;

		// Token: 0x0400087C RID: 2172
		public static readonly PdfName Empty = new PdfName("/");

		// Token: 0x020001A4 RID: 420
		public class PdfXNameComparer : IComparer<PdfName>
		{
			// Token: 0x06000D89 RID: 3465 RVA: 0x00035632 File Offset: 0x00033832
			public int Compare(PdfName l, PdfName r)
			{
				if (l != null)
				{
					if (r != null)
					{
						return string.Compare(l._value, r._value, StringComparison.Ordinal);
					}
					return -1;
				}
				else
				{
					if (r != null)
					{
						return 1;
					}
					return 0;
				}
			}
		}
	}
}
