using System;
using System.Text;

namespace PdfSharp.Pdf.Internal
{
	// Token: 0x02000165 RID: 357
	public sealed class RawEncoding : Encoding
	{
		// Token: 0x06000BD1 RID: 3025 RVA: 0x0002F45C File Offset: 0x0002D65C
		public override int GetByteCount(char[] chars, int index, int count)
		{
			return count;
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x0002F460 File Offset: 0x0002D660
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			for (int i = charCount; i > 0; i--)
			{
				bytes[byteIndex] = (byte)chars[charIndex];
				charIndex++;
				byteIndex++;
			}
			return charCount;
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x0002F48E File Offset: 0x0002D68E
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			return count;
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x0002F494 File Offset: 0x0002D694
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			for (int i = byteCount; i > 0; i--)
			{
				chars[charIndex] = (char)bytes[byteIndex];
				byteIndex++;
				charIndex++;
			}
			return byteCount;
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x0002F4C1 File Offset: 0x0002D6C1
		public override int GetMaxByteCount(int charCount)
		{
			return charCount;
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x0002F4C4 File Offset: 0x0002D6C4
		public override int GetMaxCharCount(int byteCount)
		{
			return byteCount;
		}
	}
}
