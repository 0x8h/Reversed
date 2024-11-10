using System;
using System.IO;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.Content
{
	// Token: 0x02000155 RID: 341
	internal class ContentWriter
	{
		// Token: 0x06000B5F RID: 2911 RVA: 0x0002CC36 File Offset: 0x0002AE36
		public ContentWriter(Stream contentStream)
		{
			this._stream = contentStream;
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x0002CC4C File Offset: 0x0002AE4C
		public void Close(bool closeUnderlyingStream)
		{
			if (this._stream != null && closeUnderlyingStream)
			{
				this._stream.Close();
				this._stream = null;
			}
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x0002CC6B File Offset: 0x0002AE6B
		public void Close()
		{
			this.Close(true);
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06000B62 RID: 2914 RVA: 0x0002CC74 File Offset: 0x0002AE74
		public int Position
		{
			get
			{
				return (int)this._stream.Position;
			}
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x0002CC82 File Offset: 0x0002AE82
		public void Write(bool value)
		{
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x0002CC84 File Offset: 0x0002AE84
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

		// Token: 0x06000B65 RID: 2917 RVA: 0x0002CCCC File Offset: 0x0002AECC
		public void WriteLineRaw(string rawString)
		{
			if (string.IsNullOrEmpty(rawString))
			{
				return;
			}
			byte[] bytes = PdfEncoders.RawEncoding.GetBytes(rawString);
			this._stream.Write(bytes, 0, bytes.Length);
			this._stream.Write(new byte[] { 10 }, 0, 1);
			this._lastCat = this.GetCategory((char)bytes[bytes.Length - 1]);
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x0002CD2B File Offset: 0x0002AF2B
		public void WriteRaw(char ch)
		{
			this._stream.WriteByte((byte)ch);
			this._lastCat = this.GetCategory(ch);
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06000B67 RID: 2919 RVA: 0x0002CD47 File Offset: 0x0002AF47
		// (set) Token: 0x06000B68 RID: 2920 RVA: 0x0002CD4F File Offset: 0x0002AF4F
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

		// Token: 0x06000B69 RID: 2921 RVA: 0x0002CD58 File Offset: 0x0002AF58
		private void IncreaseIndent()
		{
			this._writeIndent += this._indent;
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x0002CD6D File Offset: 0x0002AF6D
		private void DecreaseIndent()
		{
			this._writeIndent -= this._indent;
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06000B6B RID: 2923 RVA: 0x0002CD82 File Offset: 0x0002AF82
		private string IndentBlanks
		{
			get
			{
				return new string(' ', this._writeIndent);
			}
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x0002CD91 File Offset: 0x0002AF91
		private void WriteIndent()
		{
			this.WriteRaw(this.IndentBlanks);
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x0002CDA0 File Offset: 0x0002AFA0
		private void WriteSeparator(ContentWriter.CharCat cat, char ch)
		{
			ContentWriter.CharCat lastCat = this._lastCat;
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x0002CDB8 File Offset: 0x0002AFB8
		private void WriteSeparator(ContentWriter.CharCat cat)
		{
			this.WriteSeparator(cat, '\0');
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x0002CDC2 File Offset: 0x0002AFC2
		public void NewLine()
		{
			if (this._lastCat != ContentWriter.CharCat.NewLine)
			{
				this.WriteRaw('\n');
			}
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x0002CDD4 File Offset: 0x0002AFD4
		private ContentWriter.CharCat GetCategory(char ch)
		{
			return ContentWriter.CharCat.Character;
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06000B71 RID: 2929 RVA: 0x0002CDD7 File Offset: 0x0002AFD7
		internal Stream Stream
		{
			get
			{
				return this._stream;
			}
		}

		// Token: 0x0400070C RID: 1804
		protected int _indent = 2;

		// Token: 0x0400070D RID: 1805
		protected int _writeIndent;

		// Token: 0x0400070E RID: 1806
		private ContentWriter.CharCat _lastCat;

		// Token: 0x0400070F RID: 1807
		private Stream _stream;

		// Token: 0x02000156 RID: 342
		private enum CharCat
		{
			// Token: 0x04000711 RID: 1809
			NewLine,
			// Token: 0x04000712 RID: 1810
			Character,
			// Token: 0x04000713 RID: 1811
			Delimiter
		}
	}
}
