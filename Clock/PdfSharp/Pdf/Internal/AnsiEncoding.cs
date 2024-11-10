using System;
using System.Text;

namespace PdfSharp.Pdf.Internal
{
	// Token: 0x02000160 RID: 352
	public sealed class AnsiEncoding : Encoding
	{
		// Token: 0x06000BA4 RID: 2980 RVA: 0x0002E157 File Offset: 0x0002C357
		public override int GetByteCount(char[] chars, int index, int count)
		{
			return count;
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x0002E15C File Offset: 0x0002C35C
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			int num = charCount;
			while (charCount > 0)
			{
				bytes[byteIndex] = (byte)AnsiEncoding.UnicodeToAnsi(chars[charIndex]);
				byteIndex++;
				charIndex++;
				charCount--;
			}
			return num;
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0002E190 File Offset: 0x0002C390
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			return count;
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0002E194 File Offset: 0x0002C394
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			for (int i = byteCount; i > 0; i--)
			{
				chars[charIndex] = AnsiEncoding.AnsiToUnicode[(int)bytes[byteIndex]];
				byteIndex++;
				charIndex++;
			}
			return byteCount;
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x0002E1C7 File Offset: 0x0002C3C7
		public override int GetMaxByteCount(int charCount)
		{
			return charCount;
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x0002E1CA File Offset: 0x0002C3CA
		public override int GetMaxCharCount(int byteCount)
		{
			return byteCount;
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x0002E1D0 File Offset: 0x0002C3D0
		public static bool IsAnsi1252Char(char ch)
		{
			if (ch < '\u0080' || (ch >= '\u00a0' && ch <= 'ÿ'))
			{
				return true;
			}
			if (ch <= 'ž')
			{
				if (ch <= '\u009d')
				{
					if (ch != '\u0081')
					{
						switch (ch)
						{
						case '\u008d':
						case '\u008f':
						case '\u0090':
							break;
						case '\u008e':
							return false;
						default:
							if (ch != '\u009d')
							{
								return false;
							}
							break;
						}
					}
				}
				else if (ch <= 'š')
				{
					switch (ch)
					{
					case 'Œ':
					case 'œ':
						break;
					default:
						switch (ch)
						{
						case 'Š':
						case 'š':
							break;
						default:
							return false;
						}
						break;
					}
				}
				else if (ch != 'Ÿ')
				{
					switch (ch)
					{
					case 'Ž':
					case 'ž':
						break;
					default:
						return false;
					}
				}
			}
			else if (ch <= '…')
			{
				if (ch <= 'ˆ')
				{
					if (ch != 'ƒ' && ch != 'ˆ')
					{
						return false;
					}
				}
				else if (ch != '\u02dc')
				{
					switch (ch)
					{
					case '–':
					case '—':
					case '‘':
					case '’':
					case '‚':
					case '“':
					case '”':
					case '„':
					case '†':
					case '‡':
					case '•':
					case '…':
						break;
					case '―':
					case '‖':
					case '‗':
					case '‛':
					case '‟':
					case '‣':
					case '․':
					case '‥':
						return false;
					default:
						return false;
					}
				}
			}
			else if (ch <= '›')
			{
				if (ch != '‰')
				{
					switch (ch)
					{
					case '‹':
					case '›':
						break;
					default:
						return false;
					}
				}
			}
			else if (ch != '€' && ch != '™')
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x0002E36C File Offset: 0x0002C56C
		public static char UnicodeToAnsi(char ch)
		{
			if (ch < '\u0080' || (ch >= '\u00a0' && ch <= 'ÿ'))
			{
				return ch;
			}
			if (ch <= 'ž')
			{
				if (ch <= '\u009d')
				{
					if (ch == '\u0081')
					{
						return '\u0081';
					}
					switch (ch)
					{
					case '\u008d':
						return '\u008d';
					case '\u008e':
						break;
					case '\u008f':
						return '\u008f';
					case '\u0090':
						return '\u0090';
					default:
						if (ch == '\u009d')
						{
							return '\u009d';
						}
						break;
					}
				}
				else if (ch <= 'š')
				{
					switch (ch)
					{
					case 'Œ':
						return '\u008c';
					case 'œ':
						return '\u009c';
					default:
						switch (ch)
						{
						case 'Š':
							return '\u008a';
						case 'š':
							return '\u009a';
						}
						break;
					}
				}
				else
				{
					if (ch == 'Ÿ')
					{
						return '\u009f';
					}
					switch (ch)
					{
					case 'Ž':
						return '\u008e';
					case 'ž':
						return '\u009e';
					}
				}
			}
			else if (ch <= '…')
			{
				if (ch <= 'ˆ')
				{
					if (ch == 'ƒ')
					{
						return '\u0083';
					}
					if (ch == 'ˆ')
					{
						return '\u0088';
					}
				}
				else
				{
					if (ch == '\u02dc')
					{
						return '\u0098';
					}
					switch (ch)
					{
					case '–':
						return '\u0096';
					case '—':
						return '\u0097';
					case '‘':
						return '\u0091';
					case '’':
						return '\u0092';
					case '‚':
						return '\u0082';
					case '“':
						return '\u0093';
					case '”':
						return '\u0094';
					case '„':
						return '\u0084';
					case '†':
						return '\u0086';
					case '‡':
						return '\u0087';
					case '•':
						return '\u0095';
					case '…':
						return '\u0085';
					}
				}
			}
			else if (ch <= '›')
			{
				if (ch == '‰')
				{
					return '\u0089';
				}
				switch (ch)
				{
				case '‹':
					return '\u008b';
				case '›':
					return '\u009b';
				}
			}
			else
			{
				if (ch == '€')
				{
					return '\u0080';
				}
				if (ch == '™')
				{
					return '\u0099';
				}
			}
			return '¤';
		}

		// Token: 0x04000733 RID: 1843
		private static readonly char[] AnsiToUnicode = new char[]
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
			'x', 'y', 'z', '{', '|', '}', '~', '\u007f', '€', '\u0081',
			'‚', 'ƒ', '„', '…', '†', '‡', 'ˆ', '‰', 'Š', '‹',
			'Œ', '\u008d', 'Ž', '\u008f', '\u0090', '‘', '’', '“', '”', '•',
			'–', '—', '\u02dc', '™', 'š', '›', 'œ', '\u009d', 'ž', 'Ÿ',
			'\u00a0', '¡', '¢', '£', '¤', '¥', '¦', '§', '\u00a8', '©',
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
