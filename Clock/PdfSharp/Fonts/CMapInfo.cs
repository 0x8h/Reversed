using System;
using System.Collections.Generic;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Fonts
{
	// Token: 0x020000A5 RID: 165
	internal class CMapInfo
	{
		// Token: 0x06000766 RID: 1894 RVA: 0x0001C8FC File Offset: 0x0001AAFC
		public CMapInfo(OpenTypeDescriptor descriptor)
		{
			this._descriptor = descriptor;
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x0001C92C File Offset: 0x0001AB2C
		public void AddChars(string text)
		{
			if (text != null)
			{
				bool symbol = this._descriptor.FontFace.cmap.symbol;
				int length = text.Length;
				for (int i = 0; i < length; i++)
				{
					char c = text[i];
					if (!this.CharacterToGlyphIndex.ContainsKey(c))
					{
						char c2 = c;
						if (symbol)
						{
							c2 = c | (char)(this._descriptor.FontFace.os2.usFirstCharIndex & 65280);
						}
						int num = this._descriptor.CharCodeToGlyphIndex(c2);
						this.CharacterToGlyphIndex.Add(c, num);
						this.GlyphIndices[num] = null;
						this.MinChar = (char)Math.Min((ushort)this.MinChar, (ushort)c);
						this.MaxChar = (char)Math.Max((ushort)this.MaxChar, (ushort)c);
					}
				}
			}
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x0001C9FC File Offset: 0x0001ABFC
		public void AddGlyphIndices(string glyphIndices)
		{
			if (glyphIndices != null)
			{
				int length = glyphIndices.Length;
				for (int i = 0; i < length; i++)
				{
					int num = (int)glyphIndices[i];
					this.GlyphIndices[num] = null;
				}
			}
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0001CA34 File Offset: 0x0001AC34
		internal void AddAnsiChars()
		{
			byte[] array = new byte[224];
			for (int i = 0; i < 224; i++)
			{
				array[i] = (byte)(i + 32);
			}
			string @string = PdfEncoders.WinAnsiEncoding.GetString(array, 0, array.Length);
			this.AddChars(@string);
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x0001CA7B File Offset: 0x0001AC7B
		internal bool Contains(char ch)
		{
			return this.CharacterToGlyphIndex.ContainsKey(ch);
		}

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x0001CA8C File Offset: 0x0001AC8C
		public char[] Chars
		{
			get
			{
				char[] array = new char[this.CharacterToGlyphIndex.Count];
				this.CharacterToGlyphIndex.Keys.CopyTo(array, 0);
				Array.Sort<char>(array);
				return array;
			}
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0001CAC4 File Offset: 0x0001ACC4
		public int[] GetGlyphIndices()
		{
			int[] array = new int[this.GlyphIndices.Count];
			this.GlyphIndices.Keys.CopyTo(array, 0);
			Array.Sort<int>(array);
			return array;
		}

		// Token: 0x040003F4 RID: 1012
		internal OpenTypeDescriptor _descriptor;

		// Token: 0x040003F5 RID: 1013
		public char MinChar = char.MaxValue;

		// Token: 0x040003F6 RID: 1014
		public char MaxChar;

		// Token: 0x040003F7 RID: 1015
		public Dictionary<char, int> CharacterToGlyphIndex = new Dictionary<char, int>();

		// Token: 0x040003F8 RID: 1016
		public Dictionary<int, object> GlyphIndices = new Dictionary<int, object>();
	}
}
