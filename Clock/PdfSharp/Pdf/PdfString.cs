using System;
using System.Diagnostics;
using System.Text;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001B9 RID: 441
	[DebuggerDisplay("({Value})")]
	public sealed class PdfString : PdfItem
	{
		// Token: 0x06000E87 RID: 3719 RVA: 0x00039267 File Offset: 0x00037467
		public PdfString()
		{
		}

		// Token: 0x06000E88 RID: 3720 RVA: 0x0003926F File Offset: 0x0003746F
		public PdfString(string value)
		{
			PdfString.CheckRawEncoding(value);
			this._value = value;
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x00039284 File Offset: 0x00037484
		public PdfString(string value, PdfStringEncoding encoding)
		{
			switch (encoding)
			{
			case PdfStringEncoding.RawEncoding:
				PdfString.CheckRawEncoding(value);
				goto IL_47;
			case PdfStringEncoding.StandardEncoding:
			case PdfStringEncoding.PDFDocEncoding:
			case PdfStringEncoding.MacRomanEncoding:
			case PdfStringEncoding.Unicode:
				goto IL_47;
			case PdfStringEncoding.WinAnsiEncoding:
				PdfString.CheckRawEncoding(value);
				goto IL_47;
			}
			throw new ArgumentOutOfRangeException("encoding");
			IL_47:
			this._value = value;
			this._flags = (PdfStringFlags)encoding;
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x000392E6 File Offset: 0x000374E6
		internal PdfString(string value, PdfStringFlags flags)
		{
			this._value = value;
			this._flags = flags;
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06000E8B RID: 3723 RVA: 0x000392FC File Offset: 0x000374FC
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

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06000E8C RID: 3724 RVA: 0x00039313 File Offset: 0x00037513
		public PdfStringEncoding Encoding
		{
			get
			{
				return (PdfStringEncoding)(this._flags & PdfStringFlags.EncodingMask);
			}
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06000E8D RID: 3725 RVA: 0x0003931E File Offset: 0x0003751E
		public bool HexLiteral
		{
			get
			{
				return (this._flags & PdfStringFlags.HexLiteral) != PdfStringFlags.RawEncoding;
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06000E8E RID: 3726 RVA: 0x00039332 File Offset: 0x00037532
		internal PdfStringFlags Flags
		{
			get
			{
				return this._flags;
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06000E8F RID: 3727 RVA: 0x0003933A File Offset: 0x0003753A
		public string Value
		{
			get
			{
				return this._value ?? "";
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06000E90 RID: 3728 RVA: 0x0003934B File Offset: 0x0003754B
		// (set) Token: 0x06000E91 RID: 3729 RVA: 0x0003936C File Offset: 0x0003756C
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

		// Token: 0x06000E92 RID: 3730 RVA: 0x00039384 File Offset: 0x00037584
		public override string ToString()
		{
			PdfStringEncoding pdfStringEncoding = (PdfStringEncoding)(this._flags & PdfStringFlags.EncodingMask);
			return ((this._flags & PdfStringFlags.HexLiteral) == PdfStringFlags.RawEncoding) ? PdfEncoders.ToStringLiteral(this._value, pdfStringEncoding, null) : PdfEncoders.ToHexStringLiteral(this._value, pdfStringEncoding, null);
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x000393C8 File Offset: 0x000375C8
		public string ToStringFromPdfDocEncoded()
		{
			int length = this._value.Length;
			char[] array = new char[length];
			for (int i = 0; i < length; i++)
			{
				char c = this._value[i];
				if (c > 'ÿ')
				{
					throw new InvalidOperationException("DocEncoded string contains char greater 255.");
				}
				array[i] = PdfString.Encode[(int)c];
			}
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int j = 0; j < length; j++)
			{
				stringBuilder.Append(array[j]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000E94 RID: 3732 RVA: 0x0003944C File Offset: 0x0003764C
		private static void CheckRawEncoding(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return;
			}
			int length = s.Length;
			for (int i = 0; i < length; i++)
			{
			}
		}

		// Token: 0x06000E95 RID: 3733 RVA: 0x00039475 File Offset: 0x00037675
		internal override void WriteObject(PdfWriter writer)
		{
			writer.Write(this);
		}

		// Token: 0x040008F5 RID: 2293
		private readonly PdfStringFlags _flags;

		// Token: 0x040008F6 RID: 2294
		private string _value;

		// Token: 0x040008F7 RID: 2295
		private static readonly char[] Encode = new char[]
		{
			'\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\a', '\b', '\t',
			'\n', '\v', '\f', '\r', '\u000e', '\u000f', '\u0010', '\u0011', '\u0012', '\u0013',
			'\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019', '\u001a', '\u001b', '\u001c', '\u001d',
			'\u001e', '\u001f', ' ', '!', '"', '#', '$', '%', '&', '\'',
			'(', ')', '*', '+', ',', '-', '.', '/', '0', '1',
			'2', '3', '4', '5', '6', '7', '8', '9', ':', ';',
			'<', '=', '>', '?', '@', 'A', 'B', 'C', 'D', 'E',
			'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
			'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
			'Z', '[', '\\', ']', '^', '_', '`', 'a', 'b', 'c',
			'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
			'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
			'x', 'y', 'z', '{', '|', '}', '~', '\u007f', '•', '†',
			'‡', '…', '—', '–', 'ƒ', '⁄', '‹', '›', '−', '‰',
			'„', '“', '”', '‘', '’', '‚', '™', 'ﬁ', 'ﬂ', 'Ł',
			'Œ', 'Š', 'Ÿ', 'Ž', 'ı', 'ł', 'œ', 'š', 'ž', '\ufffd',
			'€', '¡', '¢', '£', '¤', '¥', '¦', '§', '\u00a8', '©',
			'ª', '«', '¬', '­', '®', '\u00af', '°', '±', '²', '³',
			'\u00b4', 'µ', '¶', '·', '\u00b8', '¹', 'º', '»', '¼', '½',
			'¾', '¿', 'À', 'Á', 'Â', 'Ã', 'Ä', 'Å', 'Æ', 'Ç',
			'È', 'É', 'Ê', 'Ë', 'Ì', 'Í', 'Î', 'Ï', 'Ð', 'Ñ',
			'Ò', 'Ó', 'Ô', 'Õ', 'Ö', '×', 'Ø', 'Ù', 'Ú', 'Û',
			'Ü', 'Ý', 'Þ', 'ß', 'à', 'á', 'â', 'ã', 'ä', 'å',
			'æ', 'ç', 'è', 'é', 'ê', 'ë', 'ì', 'í', 'î', 'ï',
			'ð', 'ñ', 'ò', 'ó', 'ô', 'õ', 'ö', '÷', 'ø', 'ù',
			'ú', 'û', 'ü', 'ý', 'þ', 'ÿ'
		};
	}
}
