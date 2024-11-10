using System;
using System.Globalization;
using System.IO;
using System.Text;
using PdfSharp.Internal;

namespace PdfSharp.Pdf.Content
{
	// Token: 0x02000151 RID: 337
	public class CLexer
	{
		// Token: 0x06000B3B RID: 2875 RVA: 0x0002BF6E File Offset: 0x0002A16E
		public CLexer(byte[] content)
		{
			this._content = content;
			this._charIndex = 0;
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0002BF8F File Offset: 0x0002A18F
		public CLexer(MemoryStream content)
		{
			this._content = content.ToArray();
			this._charIndex = 0;
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x0002BFB8 File Offset: 0x0002A1B8
		public CSymbol ScanNextToken()
		{
			char c;
			char c2;
			for (;;)
			{
				this.ClearToken();
				c = this.MoveToNonWhiteSpace();
				c2 = c;
				switch (c2)
				{
				case '"':
				case '\'':
					goto IL_114;
				case '#':
				case '$':
				case '&':
				case ')':
				case '*':
				case ',':
					goto IL_126;
				case '%':
					this.ScanComment();
					continue;
				case '(':
					goto IL_C2;
				case '+':
				case '-':
					goto IL_88;
				case '.':
					goto IL_102;
				case '/':
					goto IL_78;
				}
				break;
			}
			if (c2 != '<')
			{
				switch (c2)
				{
				case '[':
					this.ScanNextChar();
					return this._symbol = CSymbol.BeginArray;
				case '\\':
					goto IL_126;
				case ']':
					this.ScanNextChar();
					return this._symbol = CSymbol.EndArray;
				default:
					goto IL_126;
				}
			}
			else
			{
				if (this._nextChar == '<')
				{
					return this._symbol = this.ScanDictionary();
				}
				return this._symbol = this.ScanHexadecimalString();
			}
			IL_78:
			return this._symbol = this.ScanName();
			IL_88:
			return this._symbol = this.ScanNumber();
			IL_C2:
			return this._symbol = this.ScanLiteralString();
			IL_102:
			return this._symbol = this.ScanNumber();
			IL_114:
			return this._symbol = this.ScanOperator();
			IL_126:
			if (char.IsDigit(c))
			{
				return this._symbol = this.ScanNumber();
			}
			if (char.IsLetter(c))
			{
				return this._symbol = this.ScanOperator();
			}
			if (c == '\uffff')
			{
				return this._symbol = CSymbol.Eof;
			}
			ContentReaderDiagnostics.HandleUnexpectedCharacter(c);
			return this._symbol = CSymbol.None;
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x0002C148 File Offset: 0x0002A348
		public CSymbol ScanComment()
		{
			this.ClearToken();
			char c;
			while ((c = this.AppendAndScanNextChar()) != '\n' && c != '\uffff')
			{
			}
			return this._symbol = CSymbol.Comment;
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x0002C17C File Offset: 0x0002A37C
		public CSymbol ScanInlineImage()
		{
			bool flag = false;
			do
			{
				this.ScanNextToken();
				if (!flag && this._symbol == CSymbol.Name && (this.Token == "/ASCII85Decode" || this.Token == "/A85"))
				{
					flag = true;
				}
			}
			while (this._symbol != CSymbol.Operator || this.Token != "ID");
			if (flag)
			{
				while (this._currChar != '~' || this._nextChar != '>')
				{
					this.ScanNextChar();
				}
			}
			while (this._currChar != 'E' || this._nextChar != 'I')
			{
				this.ScanNextChar();
			}
			return CSymbol.None;
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0002C220 File Offset: 0x0002A420
		public CSymbol ScanName()
		{
			this.ClearToken();
			for (;;)
			{
				char c = this.AppendAndScanNextChar();
				if (CLexer.IsWhiteSpace(c) || CLexer.IsDelimiter(c))
				{
					break;
				}
				if (c == '#')
				{
					this.ScanNextChar();
					char[] array = new char[] { this._currChar, this._nextChar };
					this.ScanNextChar();
					c = (char)int.Parse(new string(array), NumberStyles.AllowHexSpecifier);
					this._currChar = c;
				}
			}
			return this._symbol = CSymbol.Name;
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0002C29C File Offset: 0x0002A49C
		protected CSymbol ScanDictionary()
		{
			this.ClearToken();
			this._token.Append(this._currChar);
			char c;
			do
			{
				this._token.Append(c = this.ScanNextChar());
			}
			while (c != '>');
			this._token.Append(this.ScanNextChar());
			this.ScanNextChar();
			return CSymbol.Dictionary;
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x0002C2F8 File Offset: 0x0002A4F8
		public CSymbol ScanNumber()
		{
			long num = 0L;
			int num2 = 0;
			bool flag = false;
			bool flag2 = false;
			this.ClearToken();
			char c = this._currChar;
			if (c == '+' || c == '-')
			{
				if (c == '-')
				{
					flag2 = true;
				}
				this._token.Append(c);
				c = this.ScanNextChar();
			}
			for (;;)
			{
				if (char.IsDigit(c))
				{
					this._token.Append(c);
					if (num2 < 10)
					{
						num = 10L * num + (long)((ulong)c) - 48L;
						if (flag)
						{
							num2++;
						}
					}
				}
				else
				{
					if (c != '.')
					{
						break;
					}
					if (flag)
					{
						ContentReaderDiagnostics.ThrowContentReaderException("More than one period in number.");
					}
					flag = true;
					this._token.Append(c);
				}
				c = this.ScanNextChar();
			}
			if (flag2)
			{
				num = -num;
			}
			if (flag)
			{
				if (num2 > 0)
				{
					this._tokenAsReal = (double)num / CLexer.PowersOf10[num2];
				}
				else
				{
					this._tokenAsReal = (double)num;
					this._tokenAsLong = num;
				}
				return CSymbol.Real;
			}
			this._tokenAsLong = num;
			this._tokenAsReal = Convert.ToDouble(num);
			if (num >= -2147483648L && num < 2147483647L)
			{
				return CSymbol.Integer;
			}
			ContentReaderDiagnostics.ThrowNumberOutOfIntegerRange(num);
			return CSymbol.Error;
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x0002C404 File Offset: 0x0002A604
		public CSymbol ScanOperator()
		{
			this.ClearToken();
			char c = this._currChar;
			while (CLexer.IsOperatorChar(c))
			{
				c = this.AppendAndScanNextChar();
			}
			return this._symbol = CSymbol.Operator;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0002C43C File Offset: 0x0002A63C
		public CSymbol ScanLiteralString()
		{
			this.ClearToken();
			int num = 0;
			char c = this.ScanNextChar();
			if (c != 'þ' || this._nextChar != 'ÿ')
			{
				for (;;)
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
							goto Block_22;
						}
						num--;
						break;
					default:
						if (c2 == '\\')
						{
							c = this.ScanNextChar();
							char c3 = c;
							if (c3 <= '\\')
							{
								if (c3 == '\n')
								{
									c = this.ScanNextChar();
									continue;
								}
								switch (c3)
								{
								case '(':
									c = '(';
									goto IL_2FB;
								case ')':
									c = ')';
									goto IL_2FB;
								default:
									if (c3 == '\\')
									{
										c = '\\';
										goto IL_2FB;
									}
									break;
								}
							}
							else if (c3 <= 'f')
							{
								if (c3 == 'b')
								{
									c = '\b';
									break;
								}
								if (c3 == 'f')
								{
									c = '\f';
									break;
								}
							}
							else
							{
								if (c3 == 'n')
								{
									c = '\n';
									break;
								}
								switch (c3)
								{
								case 'r':
									c = '\r';
									goto IL_2FB;
								case 't':
									c = '\t';
									goto IL_2FB;
								}
							}
							if (char.IsDigit(c))
							{
								int num2 = (int)(c - '0');
								if (char.IsDigit(this._nextChar))
								{
									num2 = num2 * 8 + (int)this.ScanNextChar() - 48;
									if (char.IsDigit(this._nextChar))
									{
										num2 = num2 * 8 + (int)this.ScanNextChar() - 48;
									}
								}
								c = (char)num2;
							}
						}
						break;
					}
					IL_2FB:
					this._token.Append(c);
					c = this.ScanNextChar();
				}
				Block_22:
				this.ScanNextChar();
				return this._symbol = CSymbol.String;
			}
			this.ScanNextChar();
			char c4 = this.ScanNextChar();
			if (c4 == ')')
			{
				this.ScanNextChar();
				return this._symbol = CSymbol.String;
			}
			char c5 = this.ScanNextChar();
			c = c4 * 'Ā' + c5;
			for (;;)
			{
				char c6 = c;
				switch (c6)
				{
				case '(':
					num++;
					break;
				case ')':
					if (num == 0)
					{
						goto Block_6;
					}
					num--;
					break;
				default:
					if (c6 == '\\')
					{
						c = this.ScanNextChar();
						char c7 = c;
						if (c7 <= '\\')
						{
							if (c7 == '\n')
							{
								c = this.ScanNextChar();
								continue;
							}
							switch (c7)
							{
							case '(':
								c = '(';
								goto IL_18D;
							case ')':
								c = ')';
								goto IL_18D;
							default:
								if (c7 == '\\')
								{
									c = '\\';
									goto IL_18D;
								}
								break;
							}
						}
						else if (c7 <= 'f')
						{
							if (c7 == 'b')
							{
								c = '\b';
								break;
							}
							if (c7 == 'f')
							{
								c = '\f';
								break;
							}
						}
						else
						{
							if (c7 == 'n')
							{
								c = '\n';
								break;
							}
							switch (c7)
							{
							case 'r':
								c = '\r';
								goto IL_18D;
							case 't':
								c = '\t';
								goto IL_18D;
							}
						}
						if (char.IsDigit(c))
						{
							int num3 = (int)(c - '0');
							if (char.IsDigit(this._nextChar))
							{
								num3 = num3 * 8 + (int)this.ScanNextChar() - 48;
								if (char.IsDigit(this._nextChar))
								{
									num3 = num3 * 8 + (int)this.ScanNextChar() - 48;
								}
							}
							c = (char)num3;
						}
					}
					break;
				}
				IL_18D:
				this._token.Append(c);
				c4 = this.ScanNextChar();
				if (c4 == ')')
				{
					goto Block_19;
				}
				c5 = this.ScanNextChar();
				c = c4 * 'Ā' + c5;
			}
			Block_6:
			this.ScanNextChar();
			return this._symbol = CSymbol.String;
			Block_19:
			this.ScanNextChar();
			return this._symbol = CSymbol.String;
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x0002C75C File Offset: 0x0002A95C
		public CSymbol ScanHexadecimalString()
		{
			this.ClearToken();
			char[] array = new char[2];
			this.ScanNextChar();
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
					this.ScanNextChar();
					this.ScanNextChar();
				}
			}
			this.ScanNextChar();
			string text = this._token.ToString();
			int length = text.Length;
			if (length > 2 && text[0] == 'þ' && text[1] == 'ÿ')
			{
				this._token.Length = 0;
				for (int i = 2; i < length; i += 2)
				{
					this._token.Append(text[i] * 'Ā' + text[i + 1]);
				}
			}
			return this._symbol = CSymbol.HexString;
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x0002C874 File Offset: 0x0002AA74
		internal char ScanNextChar()
		{
			if (this.ContLength <= this._charIndex)
			{
				this._currChar = char.MaxValue;
				if (CLexer.IsOperatorChar(this._nextChar))
				{
					this._token.Append(this._nextChar);
				}
				this._nextChar = char.MaxValue;
			}
			else
			{
				this._currChar = this._nextChar;
				this._nextChar = (char)this._content[this._charIndex++];
				if (this._currChar == '\r')
				{
					if (this._nextChar == '\n')
					{
						this._currChar = this._nextChar;
						if (this.ContLength <= this._charIndex)
						{
							this._nextChar = char.MaxValue;
						}
						else
						{
							this._nextChar = (char)this._content[this._charIndex++];
						}
					}
					else
					{
						this._currChar = '\n';
					}
				}
			}
			return this._currChar;
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x0002C95C File Offset: 0x0002AB5C
		private void ClearToken()
		{
			this._token.Length = 0;
			this._tokenAsLong = 0L;
			this._tokenAsReal = 0.0;
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x0002C981 File Offset: 0x0002AB81
		internal char AppendAndScanNextChar()
		{
			this._token.Append(this._currChar);
			return this.ScanNextChar();
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x0002C99C File Offset: 0x0002AB9C
		public char MoveToNonWhiteSpace()
		{
			while (this._currChar != '\uffff')
			{
				char currChar = this._currChar;
				if (currChar != '\0')
				{
					switch (currChar)
					{
					case '\t':
					case '\n':
					case '\f':
					case '\r':
						goto IL_2F;
					case '\v':
						break;
					default:
						if (currChar == ' ')
						{
							goto IL_2F;
						}
						break;
					}
					return this._currChar;
				}
				IL_2F:
				this.ScanNextChar();
			}
			return this._currChar;
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000B4A RID: 2890 RVA: 0x0002C9FB File Offset: 0x0002ABFB
		// (set) Token: 0x06000B4B RID: 2891 RVA: 0x0002CA03 File Offset: 0x0002AC03
		public CSymbol Symbol
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

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06000B4C RID: 2892 RVA: 0x0002CA0C File Offset: 0x0002AC0C
		public string Token
		{
			get
			{
				return this._token.ToString();
			}
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06000B4D RID: 2893 RVA: 0x0002CA19 File Offset: 0x0002AC19
		internal int TokenToInteger
		{
			get
			{
				return (int)this._tokenAsLong;
			}
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06000B4E RID: 2894 RVA: 0x0002CA22 File Offset: 0x0002AC22
		internal double TokenToReal
		{
			get
			{
				return this._tokenAsReal;
			}
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x0002CA2C File Offset: 0x0002AC2C
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

		// Token: 0x06000B50 RID: 2896 RVA: 0x0002CA64 File Offset: 0x0002AC64
		internal static bool IsOperatorChar(char ch)
		{
			return char.IsLetter(ch) || (ch == '"' || ch == '\'' || ch == '*');
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x0002CA90 File Offset: 0x0002AC90
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
						return false;
					}
					break;
				}
			}
			return true;
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06000B52 RID: 2898 RVA: 0x0002CAF7 File Offset: 0x0002ACF7
		public int ContLength
		{
			get
			{
				return this._content.Length;
			}
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06000B53 RID: 2899 RVA: 0x0002CB01 File Offset: 0x0002AD01
		// (set) Token: 0x06000B54 RID: 2900 RVA: 0x0002CB09 File Offset: 0x0002AD09
		public int Position
		{
			get
			{
				return this._charIndex;
			}
			set
			{
				this._charIndex = value;
				this._currChar = (char)this._content[this._charIndex - 1];
				this._nextChar = (char)this._content[this._charIndex - 1];
			}
		}

		// Token: 0x04000703 RID: 1795
		private static readonly double[] PowersOf10 = new double[] { 1.0, 10.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, 10000000.0, 100000000.0, 1000000000.0 };

		// Token: 0x04000704 RID: 1796
		private readonly byte[] _content;

		// Token: 0x04000705 RID: 1797
		private int _charIndex;

		// Token: 0x04000706 RID: 1798
		private char _currChar;

		// Token: 0x04000707 RID: 1799
		private char _nextChar;

		// Token: 0x04000708 RID: 1800
		private readonly StringBuilder _token = new StringBuilder();

		// Token: 0x04000709 RID: 1801
		private long _tokenAsLong;

		// Token: 0x0400070A RID: 1802
		private double _tokenAsReal;

		// Token: 0x0400070B RID: 1803
		private CSymbol _symbol;
	}
}
