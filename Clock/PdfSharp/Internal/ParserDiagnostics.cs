using System;
using System.Globalization;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Internal
{
	// Token: 0x020000B1 RID: 177
	internal static class ParserDiagnostics
	{
		// Token: 0x060007A5 RID: 1957 RVA: 0x0001D6B3 File Offset: 0x0001B8B3
		public static void ThrowParserException(string message)
		{
			throw new PdfReaderException(message);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0001D6BB File Offset: 0x0001B8BB
		public static void ThrowParserException(string message, Exception innerException)
		{
			throw new PdfReaderException(message, innerException);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0001D6C4 File Offset: 0x0001B8C4
		public static void HandleUnexpectedCharacter(char ch)
		{
			string text = string.Format(CultureInfo.InvariantCulture, "Unexpected character '0x{0:x4}' in PDF stream. The file may be corrupted. If you think this is a bug in PDFsharp, please send us your PDF file.", new object[] { (int)ch });
			ParserDiagnostics.ThrowParserException(text);
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0001D6F8 File Offset: 0x0001B8F8
		public static void HandleUnexpectedToken(string token)
		{
			string text = string.Format(CultureInfo.InvariantCulture, "Unexpected token '{0}' in PDF stream. The file may be corrupted. If you think this is a bug in PDFsharp, please send us your PDF file.", new object[] { token });
			ParserDiagnostics.ThrowParserException(text);
		}
	}
}
