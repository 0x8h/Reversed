using System;
using System.IO;
using PdfSharp.Internal;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Content.Objects;

namespace PdfSharp.Pdf.Content
{
	// Token: 0x02000157 RID: 343
	public sealed class CParser
	{
		// Token: 0x06000B72 RID: 2930 RVA: 0x0002CDE0 File Offset: 0x0002AFE0
		public CParser(PdfPage page)
		{
			this._page = page;
			PdfContent pdfContent = page.Contents.CreateSingleContent();
			byte[] value = pdfContent.Stream.Value;
			this._lexer = new CLexer(value);
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x0002CE29 File Offset: 0x0002B029
		public CParser(byte[] content)
		{
			this._lexer = new CLexer(content);
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x0002CE48 File Offset: 0x0002B048
		public CParser(MemoryStream content)
		{
			this._lexer = new CLexer(content.ToArray());
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x0002CE6C File Offset: 0x0002B06C
		public CParser(CLexer lexer)
		{
			this._lexer = lexer;
		}

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06000B76 RID: 2934 RVA: 0x0002CE86 File Offset: 0x0002B086
		public CSymbol Symbol
		{
			get
			{
				return this._lexer.Symbol;
			}
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x0002CE94 File Offset: 0x0002B094
		public CSequence ReadContent()
		{
			CSequence csequence = new CSequence();
			this.ParseObject(csequence, CSymbol.Eof);
			return csequence;
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x0002CEB4 File Offset: 0x0002B0B4
		private void ParseObject(CSequence sequence, CSymbol stop)
		{
			CSymbol csymbol;
			while ((csymbol = this.ScanNextToken()) != CSymbol.Eof)
			{
				if (csymbol == stop)
				{
					return;
				}
				switch (csymbol)
				{
				case CSymbol.Integer:
				{
					CInteger cinteger = new CInteger();
					cinteger.Value = this._lexer.TokenToInteger;
					this._operands.Add(cinteger);
					break;
				}
				case CSymbol.Real:
				{
					CReal creal = new CReal();
					creal.Value = this._lexer.TokenToReal;
					this._operands.Add(creal);
					break;
				}
				case CSymbol.String:
				case CSymbol.HexString:
				case CSymbol.UnicodeString:
				case CSymbol.UnicodeHexString:
				{
					CString cstring = new CString();
					cstring.Value = this._lexer.Token;
					this._operands.Add(cstring);
					break;
				}
				case CSymbol.Name:
				{
					CName cname = new CName();
					cname.Name = this._lexer.Token;
					this._operands.Add(cname);
					break;
				}
				case CSymbol.Operator:
				{
					COperator coperator = this.CreateOperator();
					sequence.Add(coperator);
					break;
				}
				case CSymbol.BeginArray:
				{
					CArray carray = new CArray();
					if (this._operands.Count != 0)
					{
						ContentReaderDiagnostics.ThrowContentReaderException("Array within array...");
					}
					this.ParseObject(carray, CSymbol.EndArray);
					carray.Add(this._operands);
					this._operands.Clear();
					this._operands.Add(carray);
					break;
				}
				case CSymbol.EndArray:
					ContentReaderDiagnostics.HandleUnexpectedCharacter(']');
					break;
				case CSymbol.Dictionary:
				{
					CString cstring = new CString();
					cstring.Value = this._lexer.Token;
					cstring.CStringType = CStringType.Dictionary;
					this._operands.Add(cstring);
					COperator coperator = this.CreateOperator(OpCodeName.Dictionary);
					sequence.Add(coperator);
					break;
				}
				}
			}
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x0002D064 File Offset: 0x0002B264
		private COperator CreateOperator()
		{
			string token = this._lexer.Token;
			COperator coperator = OpCodes.OperatorFromName(token);
			return this.CreateOperator(coperator);
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x0002D08C File Offset: 0x0002B28C
		private COperator CreateOperator(OpCodeName nameop)
		{
			string text = nameop.ToString();
			COperator coperator = OpCodes.OperatorFromName(text);
			return this.CreateOperator(coperator);
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x0002D0B3 File Offset: 0x0002B2B3
		private COperator CreateOperator(COperator op)
		{
			if (op.OpCode.OpCodeName == OpCodeName.BI)
			{
				this._lexer.ScanInlineImage();
			}
			op.Operands.Add(this._operands);
			this._operands.Clear();
			return op;
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x0002D0EC File Offset: 0x0002B2EC
		private CSymbol ScanNextToken()
		{
			return this._lexer.ScanNextToken();
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x0002D0FC File Offset: 0x0002B2FC
		private CSymbol ScanNextToken(out string token)
		{
			CSymbol csymbol = this._lexer.ScanNextToken();
			token = this._lexer.Token;
			return csymbol;
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x0002D124 File Offset: 0x0002B324
		private CSymbol ReadSymbol(CSymbol symbol)
		{
			CSymbol csymbol = this._lexer.ScanNextToken();
			if (symbol != csymbol)
			{
				ContentReaderDiagnostics.ThrowContentReaderException(PSSR.UnexpectedToken(this._lexer.Token));
			}
			return csymbol;
		}

		// Token: 0x04000714 RID: 1812
		private readonly CSequence _operands = new CSequence();

		// Token: 0x04000715 RID: 1813
		private PdfPage _page;

		// Token: 0x04000716 RID: 1814
		private readonly CLexer _lexer;
	}
}
