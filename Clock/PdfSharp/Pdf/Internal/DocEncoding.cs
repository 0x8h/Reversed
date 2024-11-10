using System;
using System.Text;

namespace PdfSharp.Pdf.Internal
{
	// Token: 0x02000163 RID: 355
	internal sealed class DocEncoding : Encoding
	{
		// Token: 0x06000BBA RID: 3002 RVA: 0x0002E964 File Offset: 0x0002CB64
		public override int GetByteCount(char[] chars, int index, int count)
		{
			return PdfEncoders.WinAnsiEncoding.GetByteCount(chars, index, count);
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x0002E974 File Offset: 0x0002CB74
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			byte[] bytes2 = PdfEncoders.WinAnsiEncoding.GetBytes(chars, charIndex, charCount);
			int num = 0;
			for (int i = bytes2.Length; i > 0; i--)
			{
				bytes[byteIndex] = DocEncoding.AnsiToDoc[(int)bytes2[num]];
				num++;
				byteIndex++;
			}
			return bytes2.Length;
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x0002E9BA File Offset: 0x0002CBBA
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			return count;
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0002E9BD File Offset: 0x0002CBBD
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			DocEncoding.PdfDocToUnicode.GetType();
			throw new NotImplementedException("GetChars");
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x0002E9D4 File Offset: 0x0002CBD4
		public override int GetMaxByteCount(int charCount)
		{
			return charCount;
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x0002E9D7 File Offset: 0x0002CBD7
		public override int GetMaxCharCount(int byteCount)
		{
			return byteCount;
		}

		// Token: 0x04000737 RID: 1847
		private static readonly byte[] AnsiToDoc = new byte[]
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
			120, 121, 122, 123, 124, 125, 126, 127, 160, 129,
			145, 131, 140, 131, 129, 130, 26, 137, 151, 136,
			150, 141, 153, 143, 144, 143, 144, 141, 142, 128,
			133, 132, 31, 146, 144, 137, 156, 157, 158, 152,
			32, 161, 162, 163, 164, 165, 166, 167, 168, 169,
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

		// Token: 0x04000738 RID: 1848
		private static readonly char[] PdfDocToUnicode = new char[]
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
