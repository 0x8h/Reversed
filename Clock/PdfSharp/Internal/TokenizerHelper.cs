using System;
using System.Globalization;

namespace PdfSharp.Internal
{
	// Token: 0x020000C1 RID: 193
	internal class TokenizerHelper
	{
		// Token: 0x060007D7 RID: 2007 RVA: 0x0001E0A0 File Offset: 0x0001C2A0
		public TokenizerHelper(string str, IFormatProvider formatProvider)
		{
			char numericListSeparator = TokenizerHelper.GetNumericListSeparator(formatProvider);
			this.Initialize(str, '\'', numericListSeparator);
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0001E0C4 File Offset: 0x0001C2C4
		public TokenizerHelper(string str, char quoteChar, char separator)
		{
			this.Initialize(str, quoteChar, separator);
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0001E0D8 File Offset: 0x0001C2D8
		private void Initialize(string str, char quoteChar, char separator)
		{
			this._str = str;
			this._strLen = ((str == null) ? 0 : str.Length);
			this._currentTokenIndex = -1;
			this._quoteChar = quoteChar;
			this._argSeparator = separator;
			while (this._charIndex < this._strLen)
			{
				if (!char.IsWhiteSpace(this._str, this._charIndex))
				{
					return;
				}
				this._charIndex++;
			}
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0001E145 File Offset: 0x0001C345
		public string NextTokenRequired()
		{
			if (!this.NextToken(false))
			{
				throw new InvalidOperationException("PrematureStringTermination");
			}
			return this.GetCurrentToken();
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0001E161 File Offset: 0x0001C361
		public string NextTokenRequired(bool allowQuotedToken)
		{
			if (!this.NextToken(allowQuotedToken))
			{
				throw new InvalidOperationException("PrematureStringTermination");
			}
			return this.GetCurrentToken();
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0001E17D File Offset: 0x0001C37D
		public string GetCurrentToken()
		{
			if (this._currentTokenIndex < 0)
			{
				return null;
			}
			return this._str.Substring(this._currentTokenIndex, this._currentTokenLength);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x0001E1A1 File Offset: 0x0001C3A1
		public void LastTokenRequired()
		{
			if (this._charIndex != this._strLen)
			{
				throw new InvalidOperationException("Extra data encountered");
			}
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0001E1BC File Offset: 0x0001C3BC
		public bool NextToken()
		{
			return this.NextToken(false);
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0001E1C5 File Offset: 0x0001C3C5
		public bool NextToken(bool allowQuotedToken)
		{
			return this.NextToken(allowQuotedToken, this._argSeparator);
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x0001E1D4 File Offset: 0x0001C3D4
		public bool NextToken(bool allowQuotedToken, char separator)
		{
			this._currentTokenIndex = -1;
			this._foundSeparator = false;
			if (this._charIndex >= this._strLen)
			{
				return false;
			}
			char c = this._str[this._charIndex];
			int num = 0;
			if (allowQuotedToken && c == this._quoteChar)
			{
				num++;
				this._charIndex++;
			}
			int charIndex = this._charIndex;
			int num2 = 0;
			while (this._charIndex < this._strLen)
			{
				c = this._str[this._charIndex];
				if (num > 0)
				{
					if (c == this._quoteChar)
					{
						num--;
						if (num == 0)
						{
							this._charIndex++;
							break;
						}
					}
				}
				else if (char.IsWhiteSpace(c) || c == separator)
				{
					if (c == separator)
					{
						this._foundSeparator = true;
						break;
					}
					break;
				}
				this._charIndex++;
				num2++;
			}
			if (num > 0)
			{
				throw new InvalidOperationException("Missing end quote");
			}
			this.ScanToNextToken(separator);
			this._currentTokenIndex = charIndex;
			this._currentTokenLength = num2;
			if (this._currentTokenLength < 1)
			{
				throw new InvalidOperationException("Empty token");
			}
			return true;
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x0001E2E4 File Offset: 0x0001C4E4
		private void ScanToNextToken(char separator)
		{
			if (this._charIndex < this._strLen)
			{
				char c = this._str[this._charIndex];
				if (c != separator && !char.IsWhiteSpace(c))
				{
					throw new InvalidOperationException("ExtraDataEncountered");
				}
				int num = 0;
				while (this._charIndex < this._strLen)
				{
					c = this._str[this._charIndex];
					if (c == separator)
					{
						this._foundSeparator = true;
						num++;
						this._charIndex++;
						if (num > 1)
						{
							throw new InvalidOperationException("EmptyToken");
						}
					}
					else
					{
						if (!char.IsWhiteSpace(c))
						{
							break;
						}
						this._charIndex++;
					}
				}
				if (num > 0 && this._charIndex >= this._strLen)
				{
					throw new InvalidOperationException("EmptyToken");
				}
			}
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0001E3B0 File Offset: 0x0001C5B0
		public static char GetNumericListSeparator(IFormatProvider provider)
		{
			char c = ',';
			NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
			if (instance.NumberDecimalSeparator.Length > 0 && c == instance.NumberDecimalSeparator[0])
			{
				c = ';';
			}
			return c;
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x060007E3 RID: 2019 RVA: 0x0001E3E8 File Offset: 0x0001C5E8
		public bool FoundSeparator
		{
			get
			{
				return this._foundSeparator;
			}
		}

		// Token: 0x0400043A RID: 1082
		private bool _foundSeparator;

		// Token: 0x0400043B RID: 1083
		private char _argSeparator;

		// Token: 0x0400043C RID: 1084
		private int _charIndex;

		// Token: 0x0400043D RID: 1085
		private int _currentTokenIndex;

		// Token: 0x0400043E RID: 1086
		private int _currentTokenLength;

		// Token: 0x0400043F RID: 1087
		private char _quoteChar;

		// Token: 0x04000440 RID: 1088
		private string _str;

		// Token: 0x04000441 RID: 1089
		private int _strLen;
	}
}
