using System;
using System.Globalization;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Security;

namespace PdfSharp.Pdf.Internal
{
	// Token: 0x02000164 RID: 356
	internal static class PdfEncoders
	{
		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06000BC1 RID: 3009 RVA: 0x0002ED16 File Offset: 0x0002CF16
		public static Encoding RawEncoding
		{
			get
			{
				Encoding encoding;
				if ((encoding = PdfEncoders._rawEncoding) == null)
				{
					encoding = (PdfEncoders._rawEncoding = new RawEncoding());
				}
				return encoding;
			}
		}

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x0002ED2C File Offset: 0x0002CF2C
		public static Encoding RawUnicodeEncoding
		{
			get
			{
				Encoding encoding;
				if ((encoding = PdfEncoders._rawUnicodeEncoding) == null)
				{
					encoding = (PdfEncoders._rawUnicodeEncoding = new RawUnicodeEncoding());
				}
				return encoding;
			}
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06000BC3 RID: 3011 RVA: 0x0002ED42 File Offset: 0x0002CF42
		public static Encoding WinAnsiEncoding
		{
			get
			{
				if (PdfEncoders._winAnsiEncoding == null)
				{
					PdfEncoders._winAnsiEncoding = Encoding.GetEncoding(1252);
				}
				return PdfEncoders._winAnsiEncoding;
			}
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x0002ED5F File Offset: 0x0002CF5F
		public static Encoding DocEncoding
		{
			get
			{
				Encoding encoding;
				if ((encoding = PdfEncoders._docEncoding) == null)
				{
					encoding = (PdfEncoders._docEncoding = new DocEncoding());
				}
				return encoding;
			}
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x0002ED75 File Offset: 0x0002CF75
		public static Encoding UnicodeEncoding
		{
			get
			{
				Encoding encoding;
				if ((encoding = PdfEncoders._unicodeEncoding) == null)
				{
					encoding = (PdfEncoders._unicodeEncoding = Encoding.Unicode);
				}
				return encoding;
			}
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x0002ED8C File Offset: 0x0002CF8C
		public static string ToStringLiteral(string text, PdfStringEncoding encoding, PdfStandardSecurityHandler securityHandler)
		{
			if (string.IsNullOrEmpty(text))
			{
				return "()";
			}
			byte[] array;
			switch (encoding)
			{
			case PdfStringEncoding.RawEncoding:
				array = PdfEncoders.RawEncoding.GetBytes(text);
				goto IL_7D;
			case PdfStringEncoding.PDFDocEncoding:
				array = PdfEncoders.DocEncoding.GetBytes(text);
				goto IL_7D;
			case PdfStringEncoding.WinAnsiEncoding:
				array = PdfEncoders.WinAnsiEncoding.GetBytes(text);
				goto IL_7D;
			case PdfStringEncoding.Unicode:
				array = PdfEncoders.RawUnicodeEncoding.GetBytes(text);
				goto IL_7D;
			}
			throw new NotImplementedException(encoding.ToString());
			IL_7D:
			byte[] array2 = PdfEncoders.FormatStringLiteral(array, encoding == PdfStringEncoding.Unicode, true, false, securityHandler);
			return PdfEncoders.RawEncoding.GetString(array2, 0, array2.Length);
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x0002EE34 File Offset: 0x0002D034
		public static string ToStringLiteral(byte[] bytes, bool unicode, PdfStandardSecurityHandler securityHandler)
		{
			if (bytes == null || bytes.Length == 0)
			{
				return "()";
			}
			byte[] array = PdfEncoders.FormatStringLiteral(bytes, unicode, true, false, securityHandler);
			return PdfEncoders.RawEncoding.GetString(array, 0, array.Length);
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x0002EE6C File Offset: 0x0002D06C
		public static string ToHexStringLiteral(string text, PdfStringEncoding encoding, PdfStandardSecurityHandler securityHandler)
		{
			if (string.IsNullOrEmpty(text))
			{
				return "<>";
			}
			byte[] array;
			switch (encoding)
			{
			case PdfStringEncoding.RawEncoding:
				array = PdfEncoders.RawEncoding.GetBytes(text);
				goto IL_7D;
			case PdfStringEncoding.PDFDocEncoding:
				array = PdfEncoders.DocEncoding.GetBytes(text);
				goto IL_7D;
			case PdfStringEncoding.WinAnsiEncoding:
				array = PdfEncoders.WinAnsiEncoding.GetBytes(text);
				goto IL_7D;
			case PdfStringEncoding.Unicode:
				array = PdfEncoders.RawUnicodeEncoding.GetBytes(text);
				goto IL_7D;
			}
			throw new NotImplementedException(encoding.ToString());
			IL_7D:
			byte[] array2 = PdfEncoders.FormatStringLiteral(array, encoding == PdfStringEncoding.Unicode, true, true, securityHandler);
			return PdfEncoders.RawEncoding.GetString(array2, 0, array2.Length);
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x0002EF14 File Offset: 0x0002D114
		public static string ToHexStringLiteral(byte[] bytes, bool unicode, PdfStandardSecurityHandler securityHandler)
		{
			if (bytes == null || bytes.Length == 0)
			{
				return "<>";
			}
			byte[] array = PdfEncoders.FormatStringLiteral(bytes, unicode, true, true, securityHandler);
			return PdfEncoders.RawEncoding.GetString(array, 0, array.Length);
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x0002EF4C File Offset: 0x0002D14C
		public static byte[] FormatStringLiteral(byte[] bytes, bool unicode, bool prefix, bool hex, PdfStandardSecurityHandler securityHandler)
		{
			if (bytes != null && bytes.Length != 0)
			{
				if (securityHandler != null)
				{
					bytes = (byte[])bytes.Clone();
					bytes = securityHandler.EncryptBytes(bytes);
				}
				int num = bytes.Length;
				StringBuilder stringBuilder = new StringBuilder();
				if (!unicode)
				{
					if (!hex)
					{
						stringBuilder.Append("(");
						for (int i = 0; i < num; i++)
						{
							char c = (char)bytes[i];
							if (c < ' ')
							{
								switch (c)
								{
								case '\b':
									stringBuilder.Append("\\b");
									goto IL_187;
								case '\t':
									stringBuilder.Append("\\t");
									goto IL_187;
								case '\n':
									stringBuilder.Append("\\n");
									goto IL_187;
								case '\r':
									stringBuilder.Append("\\r");
									goto IL_187;
								}
								if (!true)
								{
									stringBuilder.Append("\\0");
									stringBuilder.Append(c % '\b' + '0');
									stringBuilder.Append(c / '\b' + '0');
								}
								else
								{
									stringBuilder.Append(c);
								}
							}
							else
							{
								char c2 = c;
								switch (c2)
								{
								case '(':
									stringBuilder.Append("\\(");
									break;
								case ')':
									stringBuilder.Append("\\)");
									break;
								default:
									if (c2 != '\\')
									{
										stringBuilder.Append(c);
									}
									else
									{
										stringBuilder.Append("\\\\");
									}
									break;
								}
							}
							IL_187:;
						}
						stringBuilder.Append(')');
					}
					else
					{
						stringBuilder.Append('<');
						for (int j = 0; j < num; j++)
						{
							stringBuilder.AppendFormat("{0:X2}", bytes[j]);
						}
						stringBuilder.Append('>');
					}
				}
				else
				{
					while (!hex)
					{
						hex = true;
					}
					stringBuilder.Append(prefix ? "<FEFF" : "<");
					for (int k = 0; k < num; k += 2)
					{
						stringBuilder.AppendFormat("{0:X2}{1:X2}", bytes[k], bytes[k + 1]);
						if (k != 0 && k % 48 == 0)
						{
							stringBuilder.Append("\n");
						}
					}
					stringBuilder.Append(">");
				}
				return PdfEncoders.RawEncoding.GetBytes(stringBuilder.ToString());
			}
			if (!hex)
			{
				return new byte[] { 40, 41 };
			}
			return new byte[] { 60, 62 };
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x0002F1B5 File Offset: 0x0002D3B5
		public static string Format(string format, params object[] args)
		{
			return string.Format(CultureInfo.InvariantCulture, format, args);
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x0002F1C3 File Offset: 0x0002D3C3
		public static string ToString(double val)
		{
			return val.ToString("0.###", CultureInfo.InvariantCulture);
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0002F1D8 File Offset: 0x0002D3D8
		public static string ToString(XColor color, PdfColorMode colorMode)
		{
			if (colorMode == PdfColorMode.Undefined)
			{
				colorMode = ((color.ColorSpace == XColorSpace.Cmyk) ? PdfColorMode.Cmyk : PdfColorMode.Rgb);
			}
			PdfColorMode pdfColorMode = colorMode;
			if (pdfColorMode == PdfColorMode.Cmyk)
			{
				return string.Format(CultureInfo.InvariantCulture, "{0:0.###} {1:0.###} {2:0.###} {3:0.###}", new object[] { color.C, color.M, color.Y, color.K });
			}
			return string.Format(CultureInfo.InvariantCulture, "{0:0.###} {1:0.###} {2:0.###}", new object[]
			{
				(double)color.R / 255.0,
				(double)color.G / 255.0,
				(double)color.B / 255.0
			});
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x0002F2B8 File Offset: 0x0002D4B8
		public static string ToString(XMatrix matrix)
		{
			return string.Format(CultureInfo.InvariantCulture, "{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4:0.####} {5:0.####}", new object[] { matrix.M11, matrix.M12, matrix.M21, matrix.M22, matrix.OffsetX, matrix.OffsetY });
		}

		// Token: 0x04000739 RID: 1849
		private static Encoding _rawEncoding;

		// Token: 0x0400073A RID: 1850
		private static Encoding _rawUnicodeEncoding;

		// Token: 0x0400073B RID: 1851
		private static Encoding _winAnsiEncoding;

		// Token: 0x0400073C RID: 1852
		private static Encoding _docEncoding;

		// Token: 0x0400073D RID: 1853
		private static Encoding _unicodeEncoding;

		// Token: 0x0400073E RID: 1854
		private static byte[] docencode_______ = new byte[]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
			20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
			30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
			40, 41, 42, 43, 44, 45, 46, 47, 48, 49,
			50, 51, 52, 53, 54, 55, 56, 57, 58, 59,
			60, 61, 62, 63, 64, 65, 66, 67, 68, 69,
			70, 71, 72, 73, 74, 75, 76, 77, 78, 79,
			80, 81, 82, 83, 84, 85, 86, 87, 88, 89,
			90, 91, 92, 93, 94, 95, 96, 97, 98, 99,
			100, 101, 102, 103, 104, 105, 106, 107, 108, 109,
			110, 111, 112, 113, 114, 115, 116, 117, 118, 119,
			120, 121, 122, 123, 124, 125, 126, 127, 160, 127,
			130, 131, 132, 133, 134, 135, 136, 137, 138, 139,
			140, 141, 142, 143, 144, 145, 146, 147, 148, 149,
			138, 140, 152, 153, 154, 155, 156, 157, 158, 159,
			160, 161, 162, 163, 164, 165, 166, 167, 168, 169,
			170, 171, 172, 173, 174, 175, 176, 177, 178, 179,
			180, 181, 182, 183, 184, 185, 186, 187, 188, 189,
			190, 191, 192, 193, 194, 195, 196, 197, 198, 199,
			200, 201, 202, 203, 204, 205, 206, 207, 208, 209,
			210, 211, 212, 213, 214, 215, 216, 217, 218, 219,
			220, 221, 222, 223, 224, 225, 226, 227, 228, 229,
			230, 231, 232, 233, 234, 235, 236, 237, 238, 239,
			240, 241, 242, 243, 244, 245, 246, 247, 248, 249,
			250, 251, 252, 253, 254, byte.MaxValue
		};
	}
}
