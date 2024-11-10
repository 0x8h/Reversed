using System;
using System.Globalization;
using System.IO;
using System.Text;
using PdfSharp.Internal;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.IO
{
	// Token: 0x0200016E RID: 366
	public class Lexer
	{
		// Token: 0x06000BE5 RID: 3045 RVA: 0x0002F750 File Offset: 0x0002D950
		public Lexer(Stream pdfInputStream)
		{
			this._pdfSteam = pdfInputStream;
			this._pdfLength = (int)this._pdfSteam.Length;
			this._idxChar = 0;
			this.Position = 0;
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x0002F77F File Offset: 0x0002D97F
		// (set) Token: 0x06000BE7 RID: 3047 RVA: 0x0002F788 File Offset: 0x0002D988
		public int Position
		{
			get
			{
				return this._idxChar;
			}
			set
			{
				this._idxChar = value;
				this._pdfSteam.Position = (long)value;
				this._currChar = (char)this._pdfSteam.ReadByte();
				this._nextChar = (char)this._pdfSteam.ReadByte();
				this._token = new StringBuilder();
			}
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x0002F7D8 File Offset: 0x0002D9D8
		public Symbol ScanNextToken()
		{
			char c;
			char c2;
			for (;;)
			{
				this._token = new StringBuilder();
				c = this.MoveToNonWhiteSpace();
				c2 = c;
				switch (c2)
				{
				case '%':
					this.ScanComment();
					continue;
				case '&':
				case '\'':
				case ')':
				case '*':
				case ',':
					goto IL_163;
				case '(':
					goto IL_A4;
				case '+':
				case '-':
					goto IL_94;
				case '.':
					goto IL_151;
				case '/':
					goto IL_84;
				}
				break;
			}
			switch (c2)
			{
			case '<':
				if (this._nextChar == '<')
				{
					this.ScanNextChar(true);
					this.ScanNextChar(true);
					return this._symbol = Symbol.BeginDictionary;
				}
				return this._symbol = this.ScanHexadecimalString();
			case '=':
				goto IL_163;
			case '>':
				if (this._nextChar == '>')
				{
					this.ScanNextChar(true);
					this.ScanNextChar(true);
					return this._symbol = Symbol.EndDictionary;
				}
				ParserDiagnostics.HandleUnexpectedCharacter(this._nextChar);
				goto IL_163;
			default:
				switch (c2)
				{
				case '[':
					this.ScanNextChar(true);
					return this._symbol = Symbol.BeginArray;
				case '\\':
					goto IL_163;
				case ']':
					this.ScanNextChar(true);
					return this._symbol = Symbol.EndArray;
				default:
					goto IL_163;
				}
				break;
			}
			IL_84:
			return this._symbol = this.ScanName();
			IL_94:
			return this._symbol = this.ScanNumber();
			IL_A4:
			return this._symbol = this.ScanLiteralString();
			IL_151:
			return this._symbol = this.ScanNumber();
			IL_163:
			if (char.IsDigit(c))
			{
				if (this.PeekReference())
				{
					return this._symbol = this.ScanNumber();
				}
				return this._symbol = this.ScanNumber();
			}
			else
			{
				if (char.IsLetter(c))
				{
					return this._symbol = this.ScanKeyword();
				}
				if (c == '\uffff')
				{
					return this._symbol = Symbol.Eof;
				}
				ParserDiagnostics.HandleUnexpectedCharacter(c);
				return this._symbol = Symbol.None;
			}
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x0002F9C0 File Offset: 0x0002DBC0
		public byte[] ReadStream(int length)
		{
			while (this._currChar == ' ')
			{
				this.ScanNextChar(true);
			}
			int num;
			if (this._currChar == '\r')
			{
				if (this._nextChar == '\n')
				{
					num = this._idxChar + 2;
				}
				else
				{
					num = this._idxChar + 1;
				}
			}
			else
			{
				num = this._idxChar + 1;
			}
			this._pdfSteam.Position = (long)num;
			byte[] array = new byte[length];
			this._pdfSteam.Read(array, 0, length);
			this.Position = num + length;
			return array;
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x0002FA44 File Offset: 0x0002DC44
		public string ReadRawString(int position, int length)
		{
			this._pdfSteam.Position = (long)position;
			byte[] array = new byte[length];
			this._pdfSteam.Read(array, 0, length);
			return PdfEncoders.RawEncoding.GetString(array, 0, array.Length);
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x0002FA84 File Offset: 0x0002DC84
		public Symbol ScanComment()
		{
			this._token = new StringBuilder();
			char c;
			do
			{
				c = this.AppendAndScanNextChar();
			}
			while (c != '\n' && c != '\uffff');
			if (this._token.ToString().StartsWith("%%EOF"))
			{
				return Symbol.Eof;
			}
			return this._symbol = Symbol.Comment;
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x0002FAD4 File Offset: 0x0002DCD4
		public Symbol ScanName()
		{
			this._token = new StringBuilder();
			for (;;)
			{
				char c = this.AppendAndScanNextChar();
				if (Lexer.IsWhiteSpace(c) || Lexer.IsDelimiter(c) || c == '\uffff')
				{
					break;
				}
				if (c == '#')
				{
					this.ScanNextChar(true);
					char[] array = new char[] { this._currChar, this._nextChar };
					this.ScanNextChar(true);
					c = (char)int.Parse(new string(array), NumberStyles.AllowHexSpecifier);
					this._currChar = c;
				}
			}
			return this._symbol = Symbol.Name;
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x0002FB60 File Offset: 0x0002DD60
		public Symbol ScanNumber()
		{
			bool flag = false;
			this._token = new StringBuilder();
			char c = this._currChar;
			if (c == '+' || c == '-')
			{
				this._token.Append(c);
				c = this.ScanNextChar(true);
			}
			for (;;)
			{
				if (char.IsDigit(c))
				{
					this._token.Append(c);
				}
				else
				{
					if (c != '.')
					{
						break;
					}
					if (flag)
					{
						ParserDiagnostics.ThrowParserException("More than one period in number.");
					}
					flag = true;
					this._token.Append(c);
				}
				c = this.ScanNextChar(true);
			}
			if (flag)
			{
				return Symbol.Real;
			}
			long num = long.Parse(this._token.ToString(), CultureInfo.InvariantCulture);
			if (num >= -2147483648L && num <= 2147483647L)
			{
				return Symbol.Integer;
			}
			if (num > 0L && num <= (long)((ulong)(-1)))
			{
				return Symbol.UInteger;
			}
			return Symbol.Real;
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x0002FC20 File Offset: 0x0002DE20
		public Symbol ScanNumberOrReference()
		{
			Symbol symbol = this.ScanNumber();
			if (symbol == Symbol.Integer)
			{
				int position = this.Position;
				string token = this.Token;
			}
			return symbol;
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x0002FC48 File Offset: 0x0002DE48
		public Symbol ScanKeyword()
		{
			this._token = new StringBuilder();
			char c = this._currChar;
			while (char.IsLetter(c))
			{
				this._token.Append(c);
				c = this.ScanNextChar(false);
			}
			string text;
			switch (text = this._token.ToString())
			{
			case "obj":
				return this._symbol = Symbol.Obj;
			case "endobj":
				return this._symbol = Symbol.EndObj;
			case "null":
				return this._symbol = Symbol.Null;
			case "true":
			case "false":
				return this._symbol = Symbol.Boolean;
			case "R":
				return this._symbol = Symbol.R;
			case "stream":
				return this._symbol = Symbol.BeginStream;
			case "endstream":
				return this._symbol = Symbol.EndStream;
			case "xref":
				return this._symbol = Symbol.XRef;
			case "trailer":
				return this._symbol = Symbol.Trailer;
			case "startxref":
				return this._symbol = Symbol.StartXRef;
			}
			return this._symbol = Symbol.Keyword;
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x0002FE18 File Offset: 0x0002E018
		public Symbol ScanLiteralString()
		{
			this._token = new StringBuilder();
			int num = 0;
			for (char c = this.ScanNextChar(false); c != '\uffff'; c = this.ScanNextChar(false))
			{
				char c2 = c;
				switch (c2)
				{
				case '(':
					num++;
					break;
				case ')':
					if (num == 0)
					{
						this.ScanNextChar(false);
						goto IL_1CB;
					}
					num--;
					break;
				default:
					if (c2 == '\\')
					{
						c = this.ScanNextChar(false);
						char c3 = c;
						if (c3 <= ')')
						{
							if (c3 <= '\r')
							{
								if (c3 == '\n' || c3 == '\r')
								{
									c = this.ScanNextChar(false);
									continue;
								}
							}
							else
							{
								if (c3 == ' ')
								{
									c = ' ';
									break;
								}
								switch (c3)
								{
								case '(':
									c = '(';
									goto IL_1AB;
								case ')':
									c = ')';
									goto IL_1AB;
								}
							}
						}
						else if (c3 <= 'b')
						{
							if (c3 == '\\')
							{
								c = '\\';
								break;
							}
							if (c3 == 'b')
							{
								c = '\b';
								break;
							}
						}
						else
						{
							if (c3 == 'f')
							{
								c = '\f';
								break;
							}
							if (c3 == 'n')
							{
								c = '\n';
								break;
							}
							switch (c3)
							{
							case 'r':
								c = '\r';
								goto IL_1AB;
							case 't':
								c = '\t';
								goto IL_1AB;
							}
						}
						if (char.IsDigit(c))
						{
							if (c >= '8')
							{
								ParserDiagnostics.HandleUnexpectedCharacter(c);
							}
							int num2 = (int)(c - '0');
							if (char.IsDigit(this._nextChar))
							{
								c = this.ScanNextChar(false);
								if (c >= '8')
								{
									ParserDiagnostics.HandleUnexpectedCharacter(c);
								}
								num2 = num2 * 8 + (int)c - 48;
								if (char.IsDigit(this._nextChar))
								{
									c = this.ScanNextChar(false);
									if (c >= '8')
									{
										ParserDiagnostics.HandleUnexpectedCharacter(c);
									}
									num2 = num2 * 8 + (int)c - 48;
								}
							}
							c = (char)num2;
						}
						else
						{
							ParserDiagnostics.HandleUnexpectedCharacter(c);
						}
					}
					break;
				}
				IL_1AB:
				this._token.Append(c);
			}
			IL_1CB:
			if (this._token.Length >= 2 && this._token[0] == 'þ' && this._token[1] == 'ÿ')
			{
				StringBuilder token = this._token;
				int num3 = token.Length;
				if ((num3 & 1) == 1)
				{
					token.Append(0);
					num3++;
					DebugBreak.Break();
				}
				this._token = new StringBuilder();
				for (int i = 2; i < num3; i += 2)
				{
					this._token.Append('Ā' * token[i] + token[i + 1]);
				}
				return this._symbol = Symbol.UnicodeString;
			}
			if (this._token.Length >= 2 && this._token[0] == 'ÿ' && this._token[1] == 'þ')
			{
				StringBuilder token2 = this._token;
				int num4 = token2.Length;
				if ((num4 & 1) == 1)
				{
					token2.Append(0);
					num4++;
					DebugBreak.Break();
				}
				this._token = new StringBuilder();
				for (int j = 2; j < num4; j += 2)
				{
					this._token.Append('Ā' * token2[j + 1] + token2[j]);
				}
				return this._symbol = Symbol.UnicodeString;
			}
			return this._symbol = Symbol.String;
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x00030168 File Offset: 0x0002E368
		public Symbol ScanHexadecimalString()
		{
			this._token = new StringBuilder();
			char[] array = new char[2];
			this.ScanNextChar(true);
			for (;;)
			{
				this.MoveToNonWhiteSpace();
				if (this._currChar == '>')
				{
					break;
				}
				if (char.IsLetterOrDigit(this._currChar))
				{
					array[0] = char.ToUpper(this._currChar);
					array[1] = char.ToUpper(this._nextChar);
					int num = int.Parse(new string(array), NumberStyles.AllowHexSpecifier);
					this._token.Append(Convert.ToChar(num));
					this.ScanNextChar(true);
					this.ScanNextChar(true);
				}
			}
			this.ScanNextChar(true);
			string text = this._token.ToString();
			int length = text.Length;
			if (length > 2 && text[0] == 'þ' && text[1] == 'ÿ')
			{
				this._token.Length = 0;
				for (int i = 2; i < length; i += 2)
				{
					this._token.Append(text[i] * 'Ā' + text[i + 1]);
				}
				return this._symbol = Symbol.UnicodeHexString;
			}
			return this._symbol = Symbol.HexString;
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x00030298 File Offset: 0x0002E498
		internal char ScanNextChar(bool handleCRLF)
		{
			if (this._pdfLength <= this._idxChar)
			{
				this._currChar = char.MaxValue;
				this._nextChar = char.MaxValue;
			}
			else
			{
				this._currChar = this._nextChar;
				this._nextChar = (char)this._pdfSteam.ReadByte();
				this._idxChar++;
				if (handleCRLF && this._currChar == '\r')
				{
					if (this._nextChar == '\n')
					{
						this._currChar = this._nextChar;
						this._nextChar = (char)this._pdfSteam.ReadByte();
						this._idxChar++;
					}
					else
					{
						this._currChar = '\n';
					}
				}
			}
			return this._currChar;
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x0003034C File Offset: 0x0002E54C
		private bool PeekReference()
		{
			int position = this.Position;
			while (char.IsDigit(this._currChar))
			{
				this.ScanNextChar(true);
			}
			if (this._currChar == ' ')
			{
				while (this._currChar == ' ')
				{
					this.ScanNextChar(true);
				}
				if (char.IsDigit(this._currChar))
				{
					while (char.IsDigit(this._currChar))
					{
						this.ScanNextChar(true);
					}
					if (this._currChar == ' ')
					{
						while (this._currChar == ' ')
						{
							this.ScanNextChar(true);
						}
						if (this._currChar == 'R')
						{
							this.Position = position;
							return true;
						}
					}
				}
			}
			this.Position = position;
			return false;
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x000303F2 File Offset: 0x0002E5F2
		internal char AppendAndScanNextChar()
		{
			if (this._currChar == '\uffff')
			{
				ParserDiagnostics.ThrowParserException("Undetected EOF reached.");
			}
			this._token.Append(this._currChar);
			return this.ScanNextChar(true);
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x00030424 File Offset: 0x0002E624
		public char MoveToNonWhiteSpace()
		{
			while (this._currChar != '\uffff')
			{
				char currChar = this._currChar;
				if (currChar <= '\r')
				{
					if (currChar != '\0')
					{
						switch (currChar)
						{
						case '\t':
						case '\n':
						case '\f':
						case '\r':
							break;
						case '\v':
							goto IL_4A;
						default:
							goto IL_54;
						}
					}
				}
				else if (currChar != ' ')
				{
					if (currChar != '­')
					{
						goto IL_54;
					}
					goto IL_4A;
				}
				this.ScanNextChar(true);
				continue;
				IL_4A:
				this.ScanNextChar(true);
				continue;
				IL_54:
				return this._currChar;
			}
			return this._currChar;
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06000BF6 RID: 3062 RVA: 0x0003049F File Offset: 0x0002E69F
		// (set) Token: 0x06000BF7 RID: 3063 RVA: 0x000304A7 File Offset: 0x0002E6A7
		public Symbol Symbol
		{
			get
			{
				return this._symbol;
			}
			set
			{
				this._symbol = value;
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x000304B0 File Offset: 0x0002E6B0
		public string Token
		{
			get
			{
				return this._token.ToString();
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06000BF9 RID: 3065 RVA: 0x000304BD File Offset: 0x0002E6BD
		public bool TokenToBoolean
		{
			get
			{
				return this._token.ToString()[0] == 't';
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06000BFA RID: 3066 RVA: 0x000304D4 File Offset: 0x0002E6D4
		public int TokenToInteger
		{
			get
			{
				return int.Parse(this._token.ToString(), CultureInfo.InvariantCulture);
			}
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06000BFB RID: 3067 RVA: 0x000304EB File Offset: 0x0002E6EB
		public uint TokenToUInteger
		{
			get
			{
				return uint.Parse(this._token.ToString(), CultureInfo.InvariantCulture);
			}
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06000BFC RID: 3068 RVA: 0x00030502 File Offset: 0x0002E702
		public double TokenToReal
		{
			get
			{
				return double.Parse(this._token.ToString(), CultureInfo.InvariantCulture);
			}
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06000BFD RID: 3069 RVA: 0x0003051C File Offset: 0x0002E71C
		public PdfObjectID TokenToObjectID
		{
			get
			{
				string[] array = this.Token.Split(new char[] { '|' });
				int num = int.Parse(array[0]);
				int num2 = int.Parse(array[1]);
				return new PdfObjectID(num, num2);
			}
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x0003055C File Offset: 0x0002E75C
		internal static bool IsWhiteSpace(char ch)
		{
			if (ch != '\0')
			{
				switch (ch)
				{
				case '\t':
				case '\n':
				case '\f':
				case '\r':
					return true;
				case '\v':
					break;
				default:
					if (ch == ' ')
					{
						return true;
					}
					break;
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x00030594 File Offset: 0x0002E794
		internal static bool IsDelimiter(char ch)
		{
			if (ch <= '/')
			{
				switch (ch)
				{
				case '%':
				case '(':
				case ')':
					break;
				case '&':
				case '\'':
					return false;
				default:
					if (ch != '/')
					{
						return false;
					}
					break;
				}
			}
			else
			{
				switch (ch)
				{
				case '<':
				case '>':
					break;
				case '=':
					return false;
				default:
					switch (ch)
					{
					case '[':
					case ']':
						break;
					case '\\':
						return false;
					default:
						switch (ch)
						{
						case '{':
						case '}':
							break;
						case '|':
							return false;
						default:
							return false;
						}
						break;
					}
					break;
				}
			}
			return true;
		}

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06000C00 RID: 3072 RVA: 0x00030610 File Offset: 0x0002E810
		public int PdfLength
		{
			get
			{
				return this._pdfLength;
			}
		}

		// Token: 0x04000791 RID: 1937
		private readonly int _pdfLength;

		// Token: 0x04000792 RID: 1938
		private int _idxChar;

		// Token: 0x04000793 RID: 1939
		private char _currChar;

		// Token: 0x04000794 RID: 1940
		private char _nextChar;

		// Token: 0x04000795 RID: 1941
		private StringBuilder _token;

		// Token: 0x04000796 RID: 1942
		private Symbol _symbol;

		// Token: 0x04000797 RID: 1943
		private readonly Stream _pdfSteam;
	}
}
