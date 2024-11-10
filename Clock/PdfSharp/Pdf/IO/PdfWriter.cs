using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.Security;

namespace PdfSharp.Pdf.IO
{
	// Token: 0x02000176 RID: 374
	internal class PdfWriter
	{
		// Token: 0x06000C3D RID: 3133 RVA: 0x0003219C File Offset: 0x0003039C
		public PdfWriter(Stream pdfStream, PdfStandardSecurityHandler securityHandler)
		{
			this._stream = pdfStream;
			this._securityHandler = securityHandler;
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x000321C4 File Offset: 0x000303C4
		public void Close(bool closeUnderlyingStream)
		{
			if (this._stream != null && closeUnderlyingStream)
			{
				this._stream.Close();
			}
			this._stream = null;
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x000321E3 File Offset: 0x000303E3
		public void Close()
		{
			this.Close(true);
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06000C40 RID: 3136 RVA: 0x000321EC File Offset: 0x000303EC
		public int Position
		{
			get
			{
				return (int)this._stream.Position;
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06000C41 RID: 3137 RVA: 0x000321FA File Offset: 0x000303FA
		// (set) Token: 0x06000C42 RID: 3138 RVA: 0x00032202 File Offset: 0x00030402
		public PdfWriterLayout Layout
		{
			get
			{
				return this._layout;
			}
			set
			{
				this._layout = value;
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06000C43 RID: 3139 RVA: 0x0003220B File Offset: 0x0003040B
		// (set) Token: 0x06000C44 RID: 3140 RVA: 0x00032213 File Offset: 0x00030413
		public PdfWriterOptions Options
		{
			get
			{
				return this._options;
			}
			set
			{
				this._options = value;
			}
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x0003221C File Offset: 0x0003041C
		public void Write(bool value)
		{
			this.WriteSeparator(PdfWriter.CharCat.Character);
			this.WriteRaw(value ? bool.TrueString : bool.FalseString);
			this._lastCat = PdfWriter.CharCat.Character;
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x00032241 File Offset: 0x00030441
		public void Write(PdfBoolean value)
		{
			this.WriteSeparator(PdfWriter.CharCat.Character);
			this.WriteRaw(value.Value ? "true" : "false");
			this._lastCat = PdfWriter.CharCat.Character;
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x0003226B File Offset: 0x0003046B
		public void Write(int value)
		{
			this.WriteSeparator(PdfWriter.CharCat.Character);
			this.WriteRaw(value.ToString(CultureInfo.InvariantCulture));
			this._lastCat = PdfWriter.CharCat.Character;
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x0003228D File Offset: 0x0003048D
		public void Write(uint value)
		{
			this.WriteSeparator(PdfWriter.CharCat.Character);
			this.WriteRaw(value.ToString(CultureInfo.InvariantCulture));
			this._lastCat = PdfWriter.CharCat.Character;
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x000322B0 File Offset: 0x000304B0
		public void Write(PdfInteger value)
		{
			this.WriteSeparator(PdfWriter.CharCat.Character);
			this._lastCat = PdfWriter.CharCat.Character;
			this.WriteRaw(value.Value.ToString(CultureInfo.InvariantCulture));
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x000322E4 File Offset: 0x000304E4
		public void Write(PdfUInteger value)
		{
			this.WriteSeparator(PdfWriter.CharCat.Character);
			this._lastCat = PdfWriter.CharCat.Character;
			this.WriteRaw(value.Value.ToString(CultureInfo.InvariantCulture));
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x00032318 File Offset: 0x00030518
		public void Write(double value)
		{
			this.WriteSeparator(PdfWriter.CharCat.Character);
			this.WriteRaw(value.ToString("0.#######", CultureInfo.InvariantCulture));
			this._lastCat = PdfWriter.CharCat.Character;
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x00032340 File Offset: 0x00030540
		public void Write(PdfReal value)
		{
			this.WriteSeparator(PdfWriter.CharCat.Character);
			this.WriteRaw(value.Value.ToString("0.#######", CultureInfo.InvariantCulture));
			this._lastCat = PdfWriter.CharCat.Character;
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x0003237C File Offset: 0x0003057C
		public void Write(PdfString value)
		{
			this.WriteSeparator(PdfWriter.CharCat.Delimiter);
			PdfStringEncoding pdfStringEncoding = (PdfStringEncoding)(value.Flags & PdfStringFlags.EncodingMask);
			string text = (((value.Flags & PdfStringFlags.HexLiteral) == PdfStringFlags.RawEncoding) ? PdfEncoders.ToStringLiteral(value.Value, pdfStringEncoding, this.SecurityHandler) : PdfEncoders.ToHexStringLiteral(value.Value, pdfStringEncoding, this.SecurityHandler));
			this.WriteRaw(text);
			this._lastCat = PdfWriter.CharCat.Delimiter;
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x000323E0 File Offset: 0x000305E0
		public void Write(PdfName value)
		{
			this.WriteSeparator(PdfWriter.CharCat.Delimiter, '/');
			string value2 = value.Value;
			StringBuilder stringBuilder = new StringBuilder("/");
			int i = 1;
			while (i < value2.Length)
			{
				char c = value2[i];
				if (c <= ' ')
				{
					goto IL_81;
				}
				char c2 = c;
				switch (c2)
				{
				case '#':
				case '%':
				case '(':
				case ')':
					goto IL_81;
				case '$':
				case '&':
				case '\'':
					break;
				default:
					if (c2 == '/')
					{
						goto IL_81;
					}
					switch (c2)
					{
					case '<':
					case '>':
						goto IL_81;
					}
					break;
				}
				stringBuilder.Append(value2[i]);
				IL_99:
				i++;
				continue;
				IL_81:
				stringBuilder.AppendFormat("#{0:X2}", (int)value2[i]);
				goto IL_99;
			}
			this.WriteRaw(stringBuilder.ToString());
			this._lastCat = PdfWriter.CharCat.Character;
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x000324A9 File Offset: 0x000306A9
		public void Write(PdfLiteral value)
		{
			this.WriteSeparator(PdfWriter.CharCat.Character);
			this.WriteRaw(value.Value);
			this._lastCat = PdfWriter.CharCat.Character;
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x000324C8 File Offset: 0x000306C8
		public void Write(PdfRectangle rect)
		{
			this.WriteSeparator(PdfWriter.CharCat.Delimiter, '/');
			this.WriteRaw(PdfEncoders.Format("[{0:0.###} {1:0.###} {2:0.###} {3:0.###}]", new object[] { rect.X1, rect.Y1, rect.X2, rect.Y2 }));
			this._lastCat = PdfWriter.CharCat.Delimiter;
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x00032535 File Offset: 0x00030735
		public void Write(PdfReference iref)
		{
			this.WriteSeparator(PdfWriter.CharCat.Character);
			this.WriteRaw(iref.ToString());
			this._lastCat = PdfWriter.CharCat.Character;
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x00032554 File Offset: 0x00030754
		public void WriteDocString(string text, bool unicode)
		{
			this.WriteSeparator(PdfWriter.CharCat.Delimiter);
			byte[] array;
			if (!unicode)
			{
				array = PdfEncoders.DocEncoding.GetBytes(text);
			}
			else
			{
				array = PdfEncoders.UnicodeEncoding.GetBytes(text);
			}
			array = PdfEncoders.FormatStringLiteral(array, unicode, true, false, this._securityHandler);
			this.Write(array);
			this._lastCat = PdfWriter.CharCat.Delimiter;
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x000325A4 File Offset: 0x000307A4
		public void WriteDocString(string text)
		{
			this.WriteSeparator(PdfWriter.CharCat.Delimiter);
			byte[] array = PdfEncoders.DocEncoding.GetBytes(text);
			array = PdfEncoders.FormatStringLiteral(array, false, false, false, this._securityHandler);
			this.Write(array);
			this._lastCat = PdfWriter.CharCat.Delimiter;
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x000325E4 File Offset: 0x000307E4
		public void WriteDocStringHex(string text)
		{
			this.WriteSeparator(PdfWriter.CharCat.Delimiter);
			byte[] array = PdfEncoders.DocEncoding.GetBytes(text);
			array = PdfEncoders.FormatStringLiteral(array, false, false, true, this._securityHandler);
			this._stream.Write(array, 0, array.Length);
			this._lastCat = PdfWriter.CharCat.Delimiter;
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0003262C File Offset: 0x0003082C
		public void WriteBeginObject(PdfObject obj)
		{
			bool isIndirect = obj.IsIndirect;
			if (isIndirect)
			{
				this.WriteObjectAddress(obj);
				if (this._securityHandler != null)
				{
					this._securityHandler.SetHashKey(obj.ObjectID);
				}
			}
			this._stack.Add(new PdfWriter.StackItem(obj));
			if (isIndirect)
			{
				if (obj is PdfArray)
				{
					this.WriteRaw("[\n");
				}
				else if (obj is PdfDictionary)
				{
					this.WriteRaw("<<\n");
				}
				this._lastCat = PdfWriter.CharCat.NewLine;
			}
			else if (obj is PdfArray)
			{
				this.WriteSeparator(PdfWriter.CharCat.Delimiter);
				this.WriteRaw('[');
				this._lastCat = PdfWriter.CharCat.Delimiter;
			}
			else if (obj is PdfDictionary)
			{
				this.NewLine();
				this.WriteSeparator(PdfWriter.CharCat.Delimiter);
				this.WriteRaw("<<\n");
				this._lastCat = PdfWriter.CharCat.NewLine;
			}
			if (this._layout == PdfWriterLayout.Verbose)
			{
				this.IncreaseIndent();
			}
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x00032700 File Offset: 0x00030900
		public void WriteEndObject()
		{
			int count = this._stack.Count;
			PdfWriter.StackItem stackItem = this._stack[count - 1];
			this._stack.RemoveAt(count - 1);
			PdfObject @object = stackItem.Object;
			bool isIndirect = @object.IsIndirect;
			if (this._layout == PdfWriterLayout.Verbose)
			{
				this.DecreaseIndent();
			}
			if (@object is PdfArray)
			{
				if (isIndirect)
				{
					this.WriteRaw("\n]\n");
					this._lastCat = PdfWriter.CharCat.NewLine;
				}
				else
				{
					this.WriteRaw("]");
					this._lastCat = PdfWriter.CharCat.Delimiter;
				}
			}
			else if (@object is PdfDictionary)
			{
				if (isIndirect)
				{
					if (!stackItem.HasStream)
					{
						this.WriteRaw((this._lastCat == PdfWriter.CharCat.NewLine) ? ">>\n" : " >>\n");
					}
				}
				else
				{
					this.WriteSeparator(PdfWriter.CharCat.NewLine);
					this.WriteRaw(">>\n");
					this._lastCat = PdfWriter.CharCat.NewLine;
				}
			}
			if (isIndirect)
			{
				this.NewLine();
				this.WriteRaw("endobj\n");
				if (this._layout == PdfWriterLayout.Verbose)
				{
					this.WriteRaw("%--------------------------------------------------------------------------------------------------\n");
				}
			}
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x000327F8 File Offset: 0x000309F8
		public void WriteStream(PdfDictionary value, bool omitStream)
		{
			PdfWriter.StackItem stackItem = this._stack[this._stack.Count - 1];
			stackItem.HasStream = true;
			this.WriteRaw((this._lastCat == PdfWriter.CharCat.NewLine) ? ">>\nstream\n" : " >>\nstream\n");
			if (omitStream)
			{
				this.WriteRaw("  ｫ...stream content omitted...ｻ\n");
			}
			else
			{
				byte[] array = value.Stream.Value;
				if (array.Length != 0)
				{
					if (this._securityHandler != null)
					{
						array = (byte[])array.Clone();
						array = this._securityHandler.EncryptBytes(array);
					}
					this.Write(array);
					if (this._lastCat != PdfWriter.CharCat.NewLine)
					{
						this.WriteRaw('\n');
					}
				}
			}
			this.WriteRaw("endstream\n");
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x000328A4 File Offset: 0x00030AA4
		public void WriteRaw(string rawString)
		{
			if (string.IsNullOrEmpty(rawString))
			{
				return;
			}
			byte[] bytes = PdfEncoders.RawEncoding.GetBytes(rawString);
			this._stream.Write(bytes, 0, bytes.Length);
			this._lastCat = this.GetCategory((char)bytes[bytes.Length - 1]);
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x000328E9 File Offset: 0x00030AE9
		public void WriteRaw(char ch)
		{
			this._stream.WriteByte((byte)ch);
			this._lastCat = this.GetCategory(ch);
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x00032905 File Offset: 0x00030B05
		public void Write(byte[] bytes)
		{
			if (bytes == null || bytes.Length == 0)
			{
				return;
			}
			this._stream.Write(bytes, 0, bytes.Length);
			this._lastCat = this.GetCategory((char)bytes[bytes.Length - 1]);
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x00032934 File Offset: 0x00030B34
		private void WriteObjectAddress(PdfObject value)
		{
			if (this._layout == PdfWriterLayout.Verbose)
			{
				this.WriteRaw(string.Format("{0} {1} obj   % {2}\n", value.ObjectID.ObjectNumber, value.ObjectID.GenerationNumber, value.GetType().FullName));
				return;
			}
			this.WriteRaw(string.Format("{0} {1} obj\n", value.ObjectID.ObjectNumber, value.ObjectID.GenerationNumber));
		}

		// Token: 0x06000C5C RID: 3164 RVA: 0x000329C4 File Offset: 0x00030BC4
		public void WriteFileHeader(PdfDocument document)
		{
			StringBuilder stringBuilder = new StringBuilder("%PDF-");
			int version = document._version;
			stringBuilder.Append((version / 10).ToString(CultureInfo.InvariantCulture) + "." + (version % 10).ToString(CultureInfo.InvariantCulture) + "\n%ÓôÌá\n");
			this.WriteRaw(stringBuilder.ToString());
			if (this._layout == PdfWriterLayout.Verbose)
			{
				this.WriteRaw(string.Format("% PDFsharp Version {0} (verbose mode)\n", "1.50.4000.0"));
				this._commentPosition = (int)this._stream.Position + 2;
				this.WriteRaw("%                                                \n");
				this.WriteRaw("%                                                \n");
				this.WriteRaw("%                                                \n");
				this.WriteRaw("%                                                \n");
				this.WriteRaw("%                                                \n");
				this.WriteRaw("%--------------------------------------------------------------------------------------------------\n");
			}
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x00032A9C File Offset: 0x00030C9C
		public void WriteEof(PdfDocument document, int startxref)
		{
			this.WriteRaw("startxref\n");
			this.WriteRaw(startxref.ToString(CultureInfo.InvariantCulture));
			this.WriteRaw("\n%%EOF\n");
			int num = (int)this._stream.Position;
			if (this._layout == PdfWriterLayout.Verbose)
			{
				TimeSpan timeSpan = DateTime.Now - document._creation;
				this._stream.Position = (long)this._commentPosition;
				this.WriteRaw("Creation date: " + document._creation.ToString("G", CultureInfo.InvariantCulture));
				this._stream.Position = (long)(this._commentPosition + 50);
				this.WriteRaw("Creation time: " + timeSpan.TotalSeconds.ToString("0.000", CultureInfo.InvariantCulture) + " seconds");
				this._stream.Position = (long)(this._commentPosition + 100);
				this.WriteRaw("File size: " + num.ToString(CultureInfo.InvariantCulture) + " bytes");
				this._stream.Position = (long)(this._commentPosition + 150);
				this.WriteRaw("Pages: " + document.Pages.Count.ToString(CultureInfo.InvariantCulture));
				this._stream.Position = (long)(this._commentPosition + 200);
				this.WriteRaw("Objects: " + document._irefTable.ObjectTable.Count.ToString(CultureInfo.InvariantCulture));
			}
		}

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06000C5E RID: 3166 RVA: 0x00032C31 File Offset: 0x00030E31
		// (set) Token: 0x06000C5F RID: 3167 RVA: 0x00032C39 File Offset: 0x00030E39
		internal int Indent
		{
			get
			{
				return this._indent;
			}
			set
			{
				this._indent = value;
			}
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x00032C42 File Offset: 0x00030E42
		private void IncreaseIndent()
		{
			this._writeIndent += this._indent;
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x00032C57 File Offset: 0x00030E57
		private void DecreaseIndent()
		{
			this._writeIndent -= this._indent;
		}

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06000C62 RID: 3170 RVA: 0x00032C6C File Offset: 0x00030E6C
		private string IndentBlanks
		{
			get
			{
				return new string(' ', this._writeIndent);
			}
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x00032C7B File Offset: 0x00030E7B
		private void WriteIndent()
		{
			this.WriteRaw(this.IndentBlanks);
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x00032C8C File Offset: 0x00030E8C
		private void WriteSeparator(PdfWriter.CharCat cat, char ch)
		{
			switch (this._lastCat)
			{
			case PdfWriter.CharCat.NewLine:
				if (this._layout == PdfWriterLayout.Verbose)
				{
					this.WriteIndent();
					return;
				}
				break;
			case PdfWriter.CharCat.Character:
				if (this._layout == PdfWriterLayout.Verbose)
				{
					this._stream.WriteByte(32);
					return;
				}
				if (cat == PdfWriter.CharCat.Character)
				{
					this._stream.WriteByte(32);
				}
				break;
			case PdfWriter.CharCat.Delimiter:
				break;
			default:
				return;
			}
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x00032CEB File Offset: 0x00030EEB
		private void WriteSeparator(PdfWriter.CharCat cat)
		{
			this.WriteSeparator(cat, '\0');
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x00032CF5 File Offset: 0x00030EF5
		public void NewLine()
		{
			if (this._lastCat != PdfWriter.CharCat.NewLine)
			{
				this.WriteRaw('\n');
			}
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x00032D07 File Offset: 0x00030F07
		private PdfWriter.CharCat GetCategory(char ch)
		{
			if (Lexer.IsDelimiter(ch))
			{
				return PdfWriter.CharCat.Delimiter;
			}
			if (ch == '\n')
			{
				return PdfWriter.CharCat.NewLine;
			}
			return PdfWriter.CharCat.Character;
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06000C68 RID: 3176 RVA: 0x00032D1B File Offset: 0x00030F1B
		internal Stream Stream
		{
			get
			{
				return this._stream;
			}
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06000C69 RID: 3177 RVA: 0x00032D23 File Offset: 0x00030F23
		// (set) Token: 0x06000C6A RID: 3178 RVA: 0x00032D2B File Offset: 0x00030F2B
		internal PdfStandardSecurityHandler SecurityHandler
		{
			get
			{
				return this._securityHandler;
			}
			set
			{
				this._securityHandler = value;
			}
		}

		// Token: 0x0400079F RID: 1951
		private PdfWriterLayout _layout;

		// Token: 0x040007A0 RID: 1952
		private PdfWriterOptions _options;

		// Token: 0x040007A1 RID: 1953
		private int _indent = 2;

		// Token: 0x040007A2 RID: 1954
		private int _writeIndent;

		// Token: 0x040007A3 RID: 1955
		private PdfWriter.CharCat _lastCat;

		// Token: 0x040007A4 RID: 1956
		private Stream _stream;

		// Token: 0x040007A5 RID: 1957
		private PdfStandardSecurityHandler _securityHandler;

		// Token: 0x040007A6 RID: 1958
		private readonly List<PdfWriter.StackItem> _stack = new List<PdfWriter.StackItem>();

		// Token: 0x040007A7 RID: 1959
		private int _commentPosition;

		// Token: 0x02000177 RID: 375
		private enum CharCat
		{
			// Token: 0x040007A9 RID: 1961
			NewLine,
			// Token: 0x040007AA RID: 1962
			Character,
			// Token: 0x040007AB RID: 1963
			Delimiter
		}

		// Token: 0x02000178 RID: 376
		private class StackItem
		{
			// Token: 0x06000C6B RID: 3179 RVA: 0x00032D34 File Offset: 0x00030F34
			public StackItem(PdfObject value)
			{
				this.Object = value;
			}

			// Token: 0x040007AC RID: 1964
			public readonly PdfObject Object;

			// Token: 0x040007AD RID: 1965
			public bool HasStream;
		}
	}
}
