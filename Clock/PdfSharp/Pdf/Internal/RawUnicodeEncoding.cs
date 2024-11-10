using System;
using System.Text;

namespace PdfSharp.Pdf.Internal
{
	// Token: 0x02000166 RID: 358
	internal sealed class RawUnicodeEncoding : Encoding
	{
		// Token: 0x06000BD8 RID: 3032 RVA: 0x0002F4CF File Offset: 0x0002D6CF
		public override int GetByteCount(char[] chars, int index, int count)
		{
			return 2 * count;
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x0002F4D4 File Offset: 0x0002D6D4
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			for (int i = charCount; i > 0; i--)
			{
				char c = chars[charIndex];
				bytes[byteIndex++] = (byte)(c >> 8);
				bytes[byteIndex++] = (byte)c;
				charIndex++;
			}
			return charCount * 2;
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x0002F513 File Offset: 0x0002D713
		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			return count / 2;
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x0002F518 File Offset: 0x0002D718
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			for (int i = byteCount; i > 0; i--)
			{
				chars[charIndex] = (char)(bytes[byteIndex] << (int)(8 + bytes[byteIndex + 1]));
				byteIndex += 2;
				charIndex++;
			}
			return byteCount;
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x0002F551 File Offset: 0x0002D751
		public override int GetMaxByteCount(int charCount)
		{
			return charCount * 2;
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x0002F556 File Offset: 0x0002D756
		public override int GetMaxCharCount(int byteCount)
		{
			return byteCount / 2;
		}
	}
}
