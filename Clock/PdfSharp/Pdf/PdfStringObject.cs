using System;
using System.Diagnostics;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001BA RID: 442
	[DebuggerDisplay("({Value})")]
	public sealed class PdfStringObject : PdfObject
	{
		// Token: 0x06000E97 RID: 3735 RVA: 0x0003969C File Offset: 0x0003789C
		public PdfStringObject()
		{
			this._flags = PdfStringFlags.RawEncoding;
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x000396AB File Offset: 0x000378AB
		public PdfStringObject(PdfDocument document, string value)
			: base(document)
		{
			this._value = value;
			this._flags = PdfStringFlags.RawEncoding;
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x000396C2 File Offset: 0x000378C2
		public PdfStringObject(string value, PdfStringEncoding encoding)
		{
			this._value = value;
			this._flags = (PdfStringFlags)encoding;
		}

		// Token: 0x06000E9A RID: 3738 RVA: 0x000396D8 File Offset: 0x000378D8
		internal PdfStringObject(string value, PdfStringFlags flags)
		{
			this._value = value;
			this._flags = flags;
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06000E9B RID: 3739 RVA: 0x000396EE File Offset: 0x000378EE
		public int Length
		{
			get
			{
				if (this._value != null)
				{
					return this._value.Length;
				}
				return 0;
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06000E9C RID: 3740 RVA: 0x00039705 File Offset: 0x00037905
		// (set) Token: 0x06000E9D RID: 3741 RVA: 0x00039710 File Offset: 0x00037910
		public PdfStringEncoding Encoding
		{
			get
			{
				return (PdfStringEncoding)(this._flags & PdfStringFlags.EncodingMask);
			}
			set
			{
				this._flags = (this._flags & (PdfStringFlags)(-16)) | (PdfStringFlags)(value & (PdfStringEncoding)15);
			}
		}

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06000E9E RID: 3742 RVA: 0x00039726 File Offset: 0x00037926
		// (set) Token: 0x06000E9F RID: 3743 RVA: 0x0003973A File Offset: 0x0003793A
		public bool HexLiteral
		{
			get
			{
				return (this._flags & PdfStringFlags.HexLiteral) != PdfStringFlags.RawEncoding;
			}
			set
			{
				this._flags = (value ? (this._flags | PdfStringFlags.HexLiteral) : (this._flags & ~PdfStringFlags.HexLiteral));
			}
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06000EA0 RID: 3744 RVA: 0x0003975F File Offset: 0x0003795F
		// (set) Token: 0x06000EA1 RID: 3745 RVA: 0x00039770 File Offset: 0x00037970
		public string Value
		{
			get
			{
				return this._value ?? "";
			}
			set
			{
				this._value = value ?? "";
			}
		}

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06000EA2 RID: 3746 RVA: 0x00039782 File Offset: 0x00037982
		// (set) Token: 0x06000EA3 RID: 3747 RVA: 0x000397A3 File Offset: 0x000379A3
		internal byte[] EncryptionValue
		{
			get
			{
				if (this._value != null)
				{
					return PdfEncoders.RawEncoding.GetBytes(this._value);
				}
				return new byte[0];
			}
			set
			{
				this._value = PdfEncoders.RawEncoding.GetString(value, 0, value.Length);
			}
		}

		// Token: 0x06000EA4 RID: 3748 RVA: 0x000397BA File Offset: 0x000379BA
		public override string ToString()
		{
			return this._value;
		}

		// Token: 0x06000EA5 RID: 3749 RVA: 0x000397C2 File Offset: 0x000379C2
		internal override void WriteObject(PdfWriter writer)
		{
			writer.WriteBeginObject(this);
			writer.Write(new PdfString(this._value, this._flags));
			writer.WriteEndObject();
		}

		// Token: 0x040008F8 RID: 2296
		private PdfStringFlags _flags;

		// Token: 0x040008F9 RID: 2297
		private string _value;
	}
}
