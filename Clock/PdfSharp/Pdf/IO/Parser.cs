using System;
using System.Globalization;
using System.IO;
using PdfSharp.Internal;
using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Pdf.IO
{
	// Token: 0x0200016F RID: 367
	internal sealed class Parser
	{
		// Token: 0x06000C01 RID: 3073 RVA: 0x00030618 File Offset: 0x0002E818
		public Parser(PdfDocument document, Stream pdf)
		{
			this._document = document;
			this._lexer = new Lexer(pdf);
			this._stack = new ShiftStack();
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x0003063E File Offset: 0x0002E83E
		public Parser(PdfDocument document)
		{
			this._document = document;
			this._lexer = document._lexer;
			this._stack = new ShiftStack();
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x00030664 File Offset: 0x0002E864
		public int MoveToObject(PdfObjectID objectID)
		{
			int position = this._document._irefTable[objectID].Position;
			return this._lexer.Position = position;
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06000C04 RID: 3076 RVA: 0x00030697 File Offset: 0x0002E897
		public Symbol Symbol
		{
			get
			{
				return this._lexer.Symbol;
			}
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x000306A4 File Offset: 0x0002E8A4
		public PdfObjectID ReadObjectNumber(int position)
		{
			this._lexer.Position = position;
			int num = this.ReadInteger();
			int num2 = this.ReadInteger();
			return new PdfObjectID(num, num2);
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x000306D4 File Offset: 0x0002E8D4
		public PdfObject ReadObject(PdfObject pdfObject, PdfObjectID objectID, bool includeReferences, bool fromObjecStream)
		{
			int num = objectID.ObjectNumber;
			int num2 = objectID.GenerationNumber;
			if (!fromObjecStream)
			{
				this.MoveToObject(objectID);
				num = this.ReadInteger();
				num2 = this.ReadInteger();
			}
			num = objectID.ObjectNumber;
			num2 = objectID.GenerationNumber;
			if (!fromObjecStream)
			{
				this.ReadSymbol(Symbol.Obj);
			}
			switch (this.ScanNextToken())
			{
			case Symbol.Null:
				pdfObject = new PdfNullObject(this._document);
				pdfObject.SetObjectID(num, num2);
				if (!fromObjecStream)
				{
					this.ReadSymbol(Symbol.EndObj);
				}
				return pdfObject;
			case Symbol.Integer:
				pdfObject = new PdfIntegerObject(this._document, this._lexer.TokenToInteger);
				pdfObject.SetObjectID(num, num2);
				if (!fromObjecStream)
				{
					this.ReadSymbol(Symbol.EndObj);
				}
				return pdfObject;
			case Symbol.UInteger:
				pdfObject = new PdfUIntegerObject(this._document, this._lexer.TokenToUInteger);
				pdfObject.SetObjectID(num, num2);
				if (!fromObjecStream)
				{
					this.ReadSymbol(Symbol.EndObj);
				}
				return pdfObject;
			case Symbol.Real:
				pdfObject = new PdfRealObject(this._document, this._lexer.TokenToReal);
				pdfObject.SetObjectID(num, num2);
				if (!fromObjecStream)
				{
					this.ReadSymbol(Symbol.EndObj);
				}
				return pdfObject;
			case Symbol.Boolean:
				pdfObject = new PdfBooleanObject(this._document, string.Compare(this._lexer.Token, bool.TrueString, StringComparison.OrdinalIgnoreCase) == 0);
				pdfObject.SetObjectID(num, num2);
				if (!fromObjecStream)
				{
					this.ReadSymbol(Symbol.EndObj);
				}
				return pdfObject;
			case Symbol.String:
				pdfObject = new PdfStringObject(this._document, this._lexer.Token);
				pdfObject.SetObjectID(num, num2);
				if (!fromObjecStream)
				{
					this.ReadSymbol(Symbol.EndObj);
				}
				return pdfObject;
			case Symbol.Name:
				pdfObject = new PdfNameObject(this._document, this._lexer.Token);
				pdfObject.SetObjectID(num, num2);
				if (!fromObjecStream)
				{
					this.ReadSymbol(Symbol.EndObj);
				}
				return pdfObject;
			case Symbol.Keyword:
				ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
				goto IL_26E;
			case Symbol.BeginArray:
			{
				PdfArray pdfArray;
				if (pdfObject == null)
				{
					pdfArray = new PdfArray(this._document);
				}
				else
				{
					pdfArray = (PdfArray)pdfObject;
				}
				pdfObject = this.ReadArray(pdfArray, includeReferences);
				pdfObject.SetObjectID(num, num2);
				goto IL_26E;
			}
			case Symbol.BeginDictionary:
			{
				PdfDictionary pdfDictionary;
				if (pdfObject == null)
				{
					pdfDictionary = new PdfDictionary(this._document);
				}
				else
				{
					pdfDictionary = (PdfDictionary)pdfObject;
				}
				pdfObject = this.ReadDictionary(pdfDictionary, includeReferences);
				pdfObject.SetObjectID(num, num2);
				goto IL_26E;
			}
			}
			ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
			IL_26E:
			Symbol symbol = this.ScanNextToken();
			if (symbol == Symbol.BeginStream)
			{
				PdfDictionary pdfDictionary2 = (PdfDictionary)pdfObject;
				int streamLength = this.GetStreamLength(pdfDictionary2);
				byte[] array = this._lexer.ReadStream(streamLength);
				PdfDictionary.PdfStream pdfStream = new PdfDictionary.PdfStream(array, pdfDictionary2);
				pdfDictionary2.Stream = pdfStream;
				this.ReadSymbol(Symbol.EndStream);
				symbol = this.ScanNextToken();
			}
			if (!fromObjecStream && symbol != Symbol.EndObj)
			{
				ParserDiagnostics.ThrowParserException(PSSR.UnexpectedToken(this._lexer.Token));
			}
			return pdfObject;
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x000309C0 File Offset: 0x0002EBC0
		private void ReadStream(PdfDictionary dict)
		{
			Symbol symbol = this._lexer.Symbol;
			int streamLength = this.GetStreamLength(dict);
			byte[] array = this._lexer.ReadStream(streamLength);
			PdfDictionary.PdfStream pdfStream = new PdfDictionary.PdfStream(array, dict);
			dict.Stream = pdfStream;
			this.ReadSymbol(Symbol.EndStream);
			this.ScanNextToken();
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x00030A10 File Offset: 0x0002EC10
		private int GetStreamLength(PdfDictionary dict)
		{
			if (dict.Elements["/F"] != null)
			{
				throw new NotImplementedException("File streams are not yet implemented.");
			}
			PdfItem pdfItem = dict.Elements["/Length"];
			if (pdfItem is PdfInteger)
			{
				return Convert.ToInt32(pdfItem);
			}
			PdfReference pdfReference = pdfItem as PdfReference;
			if (pdfReference != null)
			{
				Parser.ParserState parserState = this.SaveState();
				object obj = this.ReadObject(null, pdfReference.ObjectID, false, false);
				this.RestoreState(parserState);
				int value = ((PdfIntegerObject)obj).Value;
				dict.Elements["/Length"] = new PdfInteger(value);
				return value;
			}
			throw new InvalidOperationException("Cannot retrieve stream length.");
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x00030AB4 File Offset: 0x0002ECB4
		public PdfArray ReadArray(PdfArray array, bool includeReferences)
		{
			if (array == null)
			{
				array = new PdfArray(this._document);
			}
			int sp = this._stack.SP;
			this.ParseObject(Symbol.EndArray);
			int num = this._stack.SP - sp;
			PdfItem[] array2 = this._stack.ToArray(sp, num);
			this._stack.Reduce(num);
			for (int i = 0; i < num; i++)
			{
				PdfItem pdfItem = array2[i];
				if (includeReferences && pdfItem is PdfReference)
				{
					pdfItem = this.ReadReference((PdfReference)pdfItem, true);
				}
				array.Elements.Add(pdfItem);
			}
			return array;
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x00030B48 File Offset: 0x0002ED48
		internal PdfDictionary ReadDictionary(PdfDictionary dict, bool includeReferences)
		{
			if (dict == null)
			{
				dict = new PdfDictionary(this._document);
			}
			DictionaryMeta meta = dict.Meta;
			int sp = this._stack.SP;
			this.ParseObject(Symbol.EndDictionary);
			int num = this._stack.SP - sp;
			PdfItem[] array = this._stack.ToArray(sp, num);
			this._stack.Reduce(num);
			for (int i = 0; i < num; i += 2)
			{
				PdfItem pdfItem = array[i];
				if (!(pdfItem is PdfName))
				{
					ParserDiagnostics.ThrowParserException("name expected");
				}
				string text = pdfItem.ToString();
				pdfItem = array[i + 1];
				if (includeReferences && pdfItem is PdfReference)
				{
					pdfItem = this.ReadReference((PdfReference)pdfItem, true);
				}
				dict.Elements[text] = pdfItem;
			}
			return dict;
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x00030C08 File Offset: 0x0002EE08
		private void ParseObject(Symbol stop)
		{
			Symbol symbol;
			while ((symbol = this.ScanNextToken()) != Symbol.Eof)
			{
				if (symbol == stop)
				{
					return;
				}
				switch (symbol)
				{
				case Symbol.Comment:
					continue;
				case Symbol.Null:
					this._stack.Shift(PdfNull.Value);
					continue;
				case Symbol.Integer:
					this._stack.Shift(new PdfInteger(this._lexer.TokenToInteger));
					continue;
				case Symbol.UInteger:
					this._stack.Shift(new PdfUInteger(this._lexer.TokenToUInteger));
					continue;
				case Symbol.Real:
					this._stack.Shift(new PdfReal(this._lexer.TokenToReal));
					continue;
				case Symbol.Boolean:
					this._stack.Shift(new PdfBoolean(this._lexer.TokenToBoolean));
					continue;
				case Symbol.String:
					this._stack.Shift(new PdfString(this._lexer.Token, PdfStringFlags.RawEncoding));
					continue;
				case Symbol.HexString:
					this._stack.Shift(new PdfString(this._lexer.Token, PdfStringFlags.HexLiteral));
					continue;
				case Symbol.UnicodeString:
					this._stack.Shift(new PdfString(this._lexer.Token, PdfStringFlags.Unicode));
					continue;
				case Symbol.UnicodeHexString:
					this._stack.Shift(new PdfString(this._lexer.Token, PdfStringFlags.PDFDocEncoding | PdfStringFlags.MacRomanEncoding | PdfStringFlags.HexLiteral));
					continue;
				case Symbol.Name:
					this._stack.Shift(new PdfName(this._lexer.Token));
					continue;
				case Symbol.BeginStream:
					throw new NotImplementedException();
				case Symbol.BeginArray:
				{
					PdfArray pdfArray = new PdfArray(this._document);
					this.ReadArray(pdfArray, false);
					this._stack.Shift(pdfArray);
					continue;
				}
				case Symbol.BeginDictionary:
				{
					PdfDictionary pdfDictionary = new PdfDictionary(this._document);
					this.ReadDictionary(pdfDictionary, false);
					this._stack.Shift(pdfDictionary);
					continue;
				}
				case Symbol.R:
				{
					PdfObjectID pdfObjectID = new PdfObjectID(this._stack.GetInteger(-2), this._stack.GetInteger(-1));
					PdfReference pdfReference = this._document._irefTable[pdfObjectID];
					if (pdfReference != null)
					{
						this._stack.Reduce(pdfReference, 2);
						continue;
					}
					if (this._document._irefTable.IsUnderConstruction)
					{
						pdfReference = new PdfReference(pdfObjectID, 0);
						this._stack.Reduce(pdfReference, 2);
						continue;
					}
					this._stack.Reduce(PdfNull.Value, 2);
					continue;
				}
				}
				ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
				this.SkipCharsUntil(stop);
				return;
			}
			ParserDiagnostics.ThrowParserException("Unexpected end of file.");
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x00030EC9 File Offset: 0x0002F0C9
		private Symbol ScanNextToken()
		{
			return this._lexer.ScanNextToken();
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x00030ED8 File Offset: 0x0002F0D8
		private Symbol ScanNextToken(out string token)
		{
			Symbol symbol = this._lexer.ScanNextToken();
			token = this._lexer.Token;
			return symbol;
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x00030F00 File Offset: 0x0002F100
		private Symbol SkipCharsUntil(Symbol stop)
		{
			if (stop == Symbol.EndDictionary)
			{
				return this.SkipCharsUntil(">>", stop);
			}
			Symbol symbol;
			do
			{
				symbol = this.ScanNextToken();
			}
			while (symbol != stop && symbol != Symbol.Eof);
			return symbol;
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x00030F34 File Offset: 0x0002F134
		private Symbol SkipCharsUntil(string text, Symbol stop)
		{
			int length = text.Length;
			int num = 0;
			char c;
			while ((c = this._lexer.ScanNextChar(true)) != '\uffff')
			{
				if (c == text[num])
				{
					if (num + 1 == length)
					{
						this._lexer.ScanNextChar(true);
						return stop;
					}
					num++;
				}
				else
				{
					num = 0;
				}
			}
			return Symbol.Eof;
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x00030F8C File Offset: 0x0002F18C
		private void ReadObjectID(PdfObject obj)
		{
			int num = this.ReadInteger();
			int num2 = this.ReadInteger();
			this.ReadSymbol(Symbol.Obj);
			if (obj != null)
			{
				obj.SetObjectID(num, num2);
			}
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x00030FBB File Offset: 0x0002F1BB
		private PdfItem ReadReference(PdfReference iref, bool includeReferences)
		{
			throw new NotImplementedException("ReadReference");
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x00030FC8 File Offset: 0x0002F1C8
		private Symbol ReadSymbol(Symbol symbol)
		{
			if (symbol == Symbol.EndStream)
			{
				for (;;)
				{
					char c = this._lexer.MoveToNonWhiteSpace();
					if (c == 'e')
					{
						break;
					}
					this._lexer.ScanNextChar(false);
				}
			}
			Symbol symbol2 = this._lexer.ScanNextToken();
			if (symbol != symbol2)
			{
				ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
			}
			return symbol2;
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x0003101C File Offset: 0x0002F21C
		private Symbol ReadToken(string token)
		{
			Symbol symbol = this._lexer.ScanNextToken();
			if (token != this._lexer.Token)
			{
				ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
			}
			return symbol;
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x0003105C File Offset: 0x0002F25C
		private string ReadName()
		{
			string text;
			Symbol symbol = this.ScanNextToken(out text);
			if (symbol != Symbol.Name)
			{
				ParserDiagnostics.HandleUnexpectedToken(text);
			}
			return text;
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x00031080 File Offset: 0x0002F280
		private int ReadInteger(bool canBeIndirect)
		{
			Symbol symbol = this._lexer.ScanNextToken();
			if (symbol == Symbol.Integer)
			{
				return this._lexer.TokenToInteger;
			}
			if (symbol == Symbol.R)
			{
				int position = this._lexer.Position;
				this.ReadObjectID(null);
				int num = this.ReadInteger();
				this.ReadSymbol(Symbol.EndObj);
				this._lexer.Position = position;
				return num;
			}
			ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
			return 0;
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x000310F0 File Offset: 0x0002F2F0
		private int ReadInteger()
		{
			return this.ReadInteger(false);
		}

		// Token: 0x06000C17 RID: 3095 RVA: 0x000310FC File Offset: 0x0002F2FC
		public static PdfObject ReadObject(PdfDocument owner, PdfObjectID objectID)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner");
			}
			Parser parser = new Parser(owner);
			return parser.ReadObject(null, objectID, false, false);
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x00031128 File Offset: 0x0002F328
		internal void ReadIRefsFromCompressedObject(PdfObjectID objectID)
		{
			PdfReference pdfReference;
			if (!this._document._irefTable.ObjectTable.TryGetValue(objectID, out pdfReference))
			{
				throw new NotImplementedException("This case is not coded or something else went wrong");
			}
			if (pdfReference.Value == null)
			{
				try
				{
					PdfDictionary pdfDictionary = (PdfDictionary)this.ReadObject(null, pdfReference.ObjectID, false, false);
					new PdfObjectStream(pdfDictionary);
				}
				catch (Exception)
				{
					throw;
				}
			}
			PdfObjectStream pdfObjectStream = pdfReference.Value as PdfObjectStream;
			if (pdfObjectStream == null)
			{
				pdfObjectStream = new PdfObjectStream((PdfDictionary)pdfReference.Value);
			}
			if (pdfObjectStream == null)
			{
				throw new Exception("Something went wrong here.");
			}
			pdfObjectStream.ReadReferences(this._document._irefTable);
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x000311D4 File Offset: 0x0002F3D4
		internal PdfReference ReadCompressedObject(PdfObjectID objectID, int index)
		{
			PdfReference pdfReference;
			if (!this._document._irefTable.ObjectTable.TryGetValue(objectID, out pdfReference))
			{
				throw new NotImplementedException("This case is not coded or something else went wrong");
			}
			if (pdfReference.Value == null)
			{
				try
				{
					PdfDictionary pdfDictionary = (PdfDictionary)this.ReadObject(null, pdfReference.ObjectID, false, false);
					new PdfObjectStream(pdfDictionary);
				}
				catch (Exception)
				{
					throw;
				}
			}
			PdfObjectStream pdfObjectStream = pdfReference.Value as PdfObjectStream;
			if (pdfObjectStream == null)
			{
				pdfObjectStream = new PdfObjectStream((PdfDictionary)pdfReference.Value);
			}
			if (pdfObjectStream == null)
			{
				throw new Exception("Something went wrong here.");
			}
			return pdfObjectStream.ReadCompressedObject(index);
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x00031274 File Offset: 0x0002F474
		internal PdfReference ReadCompressedObject(int objectNumber, int offset)
		{
			PdfObjectID pdfObjectID = new PdfObjectID(objectNumber);
			this._lexer.Position = offset;
			PdfObject pdfObject = this.ReadObject(null, pdfObjectID, false, true);
			return pdfObject.Reference;
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x000312A8 File Offset: 0x0002F4A8
		internal int[][] ReadObjectStreamHeader(int n, int first)
		{
			int[][] array = new int[n][];
			for (int i = 0; i < n; i++)
			{
				int num = this.ReadInteger();
				int num2 = this.ReadInteger() + first;
				array[i] = new int[] { num, num2 };
			}
			return array;
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x000312F0 File Offset: 0x0002F4F0
		internal PdfTrailer ReadTrailer()
		{
			int pdfLength = this._lexer.PdfLength;
			int num;
			if (pdfLength < 1030)
			{
				string text = this._lexer.ReadRawString(pdfLength - 31, 30);
				num = text.LastIndexOf("startxref", StringComparison.Ordinal);
				this._lexer.Position = pdfLength - 31 + num;
			}
			else
			{
				string text2 = this._lexer.ReadRawString(pdfLength - 1031, 1030);
				num = text2.LastIndexOf("startxref", StringComparison.Ordinal);
				this._lexer.Position = pdfLength - 1031 + num;
			}
			if (num == -1)
			{
				string text3 = this._lexer.ReadRawString(0, pdfLength);
				num = text3.LastIndexOf("startxref", StringComparison.Ordinal);
				this._lexer.Position = num;
			}
			if (num == -1)
			{
				throw new Exception("The StartXRef table could not be found, the file cannot be opened.");
			}
			this.ReadSymbol(Symbol.StartXRef);
			this._lexer.Position = this.ReadInteger();
			for (;;)
			{
				PdfTrailer pdfTrailer = this.ReadXRefTableAndTrailer(this._document._irefTable);
				if (this._document._trailer == null)
				{
					this._document._trailer = pdfTrailer;
				}
				int integer = pdfTrailer.Elements.GetInteger("/Prev");
				if (integer == 0)
				{
					break;
				}
				this._lexer.Position = integer;
			}
			return this._document._trailer;
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x00031430 File Offset: 0x0002F630
		private PdfTrailer ReadXRefTableAndTrailer(PdfCrossReferenceTable xrefTable)
		{
			Symbol symbol = this.ScanNextToken();
			if (symbol == Symbol.XRef)
			{
				for (;;)
				{
					symbol = this.ScanNextToken();
					if (symbol == Symbol.Integer)
					{
						int tokenToInteger = this._lexer.TokenToInteger;
						int num = this.ReadInteger();
						for (int i = tokenToInteger; i < tokenToInteger + num; i++)
						{
							int num2 = this.ReadInteger();
							int num3 = this.ReadInteger();
							this.ReadSymbol(Symbol.Keyword);
							string token = this._lexer.Token;
							if (i != 0 && !(token != "n"))
							{
								PdfObjectID pdfObjectID = new PdfObjectID(i, num3);
								if (!xrefTable.Contains(pdfObjectID))
								{
									xrefTable.Add(new PdfReference(pdfObjectID, num2));
								}
							}
						}
					}
					else
					{
						if (symbol == Symbol.Trailer)
						{
							break;
						}
						ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
					}
				}
				this.ReadSymbol(Symbol.BeginDictionary);
				PdfTrailer pdfTrailer = new PdfTrailer(this._document);
				this.ReadDictionary(pdfTrailer, false);
				return pdfTrailer;
			}
			if (symbol == Symbol.Integer)
			{
				return this.ReadXRefStream(xrefTable);
			}
			return null;
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x00031524 File Offset: 0x0002F724
		private PdfTrailer ReadXRefStream(PdfCrossReferenceTable xrefTable)
		{
			int tokenToInteger = this._lexer.TokenToInteger;
			int num = this.ReadInteger();
			this.ReadSymbol(Symbol.Obj);
			this.ReadSymbol(Symbol.BeginDictionary);
			PdfObjectID pdfObjectID = new PdfObjectID(tokenToInteger, num);
			PdfCrossReferenceStream pdfCrossReferenceStream = new PdfCrossReferenceStream(this._document);
			this.ReadDictionary(pdfCrossReferenceStream, false);
			this.ReadSymbol(Symbol.BeginStream);
			this.ReadStream(pdfCrossReferenceStream);
			xrefTable.Add(new PdfReference(pdfCrossReferenceStream)
			{
				ObjectID = pdfObjectID,
				Value = pdfCrossReferenceStream
			});
			byte[] unfilteredValue = pdfCrossReferenceStream.Stream.UnfilteredValue;
			byte[] array = unfilteredValue;
			if (pdfCrossReferenceStream.Stream.HasDecodeParams)
			{
				int decodePredictor = pdfCrossReferenceStream.Stream.DecodePredictor;
				int decodeColumns = pdfCrossReferenceStream.Stream.DecodeColumns;
				array = this.DecodeCrossReferenceStream(unfilteredValue, decodeColumns, decodePredictor);
			}
			int integer = pdfCrossReferenceStream.Elements.GetInteger("/Size");
			PdfArray pdfArray = pdfCrossReferenceStream.Elements.GetValue("/Index") as PdfArray;
			pdfCrossReferenceStream.Elements.GetInteger("/Prev");
			PdfArray pdfArray2 = (PdfArray)pdfCrossReferenceStream.Elements.GetValue("/W");
			int num2 = 0;
			int num3;
			int[][] array2;
			if (pdfArray == null)
			{
				num3 = 1;
				array2 = new int[num3][];
				array2[0] = new int[] { 0, integer };
				num2 = integer;
			}
			else
			{
				num3 = pdfArray.Elements.Count / 2;
				array2 = new int[num3][];
				for (int i = 0; i < num3; i++)
				{
					array2[i] = new int[]
					{
						pdfArray.Elements.GetInteger(2 * i),
						pdfArray.Elements.GetInteger(2 * i + 1)
					};
					num2 += array2[i][1];
				}
			}
			int[] array3 = new int[]
			{
				pdfArray2.Elements.GetInteger(0),
				pdfArray2.Elements.GetInteger(1),
				pdfArray2.Elements.GetInteger(2)
			};
			int num4 = StreamHelper.WSize(array3);
			if (num4 * num2 != array.Length)
			{
				base.GetType();
			}
			int num5 = array2[0][1];
			int[] array4 = array2[0];
			int num6 = -1;
			for (int j = 0; j < num3; j++)
			{
				int num7 = array2[j][1];
				for (int k = 0; k < num7; k++)
				{
					num6++;
					PdfCrossReferenceStream.CrossReferenceStreamEntry crossReferenceStreamEntry = default(PdfCrossReferenceStream.CrossReferenceStreamEntry);
					crossReferenceStreamEntry.Type = StreamHelper.ReadBytes(array, num6 * num4, array3[0]);
					crossReferenceStreamEntry.Field2 = StreamHelper.ReadBytes(array, num6 * num4 + array3[0], array3[1]);
					crossReferenceStreamEntry.Field3 = StreamHelper.ReadBytes(array, num6 * num4 + array3[0] + array3[1], array3[2]);
					pdfCrossReferenceStream.Entries.Add(crossReferenceStreamEntry);
					switch (crossReferenceStreamEntry.Type)
					{
					case 1U:
					{
						int field = (int)crossReferenceStreamEntry.Field2;
						pdfObjectID = this.ReadObjectNumber(field);
						if (!xrefTable.Contains(pdfObjectID))
						{
							xrefTable.Add(new PdfReference(pdfObjectID, field));
						}
						break;
					}
					}
				}
			}
			return pdfCrossReferenceStream;
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x00031834 File Offset: 0x0002FA34
		internal static DateTime ParseDateTime(string date, DateTime errorValue)
		{
			DateTime dateTime = errorValue;
			try
			{
				if (date.StartsWith("D:"))
				{
					int length = date.Length;
					int num = 0;
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					int num6 = 0;
					int num7 = 0;
					int num8 = 0;
					char c = 'Z';
					if (length >= 10)
					{
						num = int.Parse(date.Substring(2, 4));
						num2 = int.Parse(date.Substring(6, 2));
						num3 = int.Parse(date.Substring(8, 2));
						if (length >= 16)
						{
							num4 = int.Parse(date.Substring(10, 2));
							num5 = int.Parse(date.Substring(12, 2));
							num6 = int.Parse(date.Substring(14, 2));
							if (length >= 23 && (c = date[16]) != 'Z')
							{
								num7 = int.Parse(date.Substring(17, 2));
								num8 = int.Parse(date.Substring(20, 2));
							}
						}
					}
					num2 = Math.Min(Math.Max(num2, 1), 12);
					dateTime = new DateTime(num, num2, num3, num4, num5, num6);
					if (c != 'Z')
					{
						TimeSpan timeSpan = new TimeSpan(num7, num8, 0);
						if (c == '-')
						{
							dateTime = dateTime.Add(timeSpan);
						}
						else
						{
							dateTime = dateTime.Subtract(timeSpan);
						}
					}
					DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
				}
				else
				{
					dateTime = DateTime.Parse(date, CultureInfo.InvariantCulture);
				}
			}
			catch (Exception)
			{
			}
			return dateTime;
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x00031998 File Offset: 0x0002FB98
		private Parser.ParserState SaveState()
		{
			return new Parser.ParserState
			{
				Position = this._lexer.Position,
				Symbol = this._lexer.Symbol
			};
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x000319CE File Offset: 0x0002FBCE
		private void RestoreState(Parser.ParserState state)
		{
			this._lexer.Position = state.Position;
			this._lexer.Symbol = state.Symbol;
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x000319F4 File Offset: 0x0002FBF4
		private byte[] DecodeCrossReferenceStream(byte[] bytes, int columns, int predictor)
		{
			int num = bytes.Length;
			if (predictor < 10 || predictor > 15)
			{
				throw new ArgumentException("Invalid predictor.", "predictor");
			}
			int num2 = columns + 1;
			if (num % num2 != 0)
			{
				throw new ArgumentException("Columns and size of array do not match.");
			}
			int num3 = num / num2;
			byte[] array = new byte[num3 * columns];
			for (int i = 0; i < num3; i++)
			{
				if (bytes[i * num2] != 2)
				{
					throw new ArgumentException("Invalid predictor in array.");
				}
				for (int j = 0; j < columns; j++)
				{
					if (i == 0)
					{
						array[i * columns + j] = bytes[i * num2 + j + 1];
					}
					else
					{
						array[i * columns + j] = array[i * columns - columns + j] + bytes[i * num2 + j + 1];
					}
				}
			}
			return array;
		}

		// Token: 0x04000798 RID: 1944
		private readonly PdfDocument _document;

		// Token: 0x04000799 RID: 1945
		private readonly Lexer _lexer;

		// Token: 0x0400079A RID: 1946
		private readonly ShiftStack _stack;

		// Token: 0x02000170 RID: 368
		private class ParserState
		{
			// Token: 0x0400079B RID: 1947
			public int Position;

			// Token: 0x0400079C RID: 1948
			public Symbol Symbol;
		}
	}
}
