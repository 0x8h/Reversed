using System;
using System.Globalization;
using PdfSharp.Pdf.Content;

namespace PdfSharp.Internal
{
	// Token: 0x020000B2 RID: 178
	internal static class ContentReaderDiagnostics
	{
		// Token: 0x060007A9 RID: 1961 RVA: 0x0001D727 File Offset: 0x0001B927
		public static void ThrowContentReaderException(string message)
		{
			throw new ContentReaderException(message);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x0001D72F File Offset: 0x0001B92F
		public static void ThrowContentReaderException(string message, Exception innerException)
		{
			throw new ContentReaderException(message, innerException);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0001D738 File Offset: 0x0001B938
		public static void ThrowNumberOutOfIntegerRange(long value)
		{
			string text = string.Format(CultureInfo.InvariantCulture, "Number '{0}' out of integer range.", new object[] { value });
			ContentReaderDiagnostics.ThrowContentReaderException(text);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0001D76C File Offset: 0x0001B96C
		public static void HandleUnexpectedCharacter(char ch)
		{
			string text = string.Format(CultureInfo.InvariantCulture, "Unexpected character '0x{0:x4}' in content stream. The stream may be corrupted or the feature is not implemented. If you think this is a bug in PDFsharp, please send us your PDF file.", new object[] { ch });
			ContentReaderDiagnostics.ThrowContentReaderException(text);
		}
	}
}
