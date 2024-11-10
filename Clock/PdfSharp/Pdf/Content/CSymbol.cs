using System;

namespace PdfSharp.Pdf.Content
{
	// Token: 0x02000158 RID: 344
	public enum CSymbol
	{
		// Token: 0x04000718 RID: 1816
		None,
		// Token: 0x04000719 RID: 1817
		Comment,
		// Token: 0x0400071A RID: 1818
		Integer,
		// Token: 0x0400071B RID: 1819
		Real,
		// Token: 0x0400071C RID: 1820
		String,
		// Token: 0x0400071D RID: 1821
		HexString,
		// Token: 0x0400071E RID: 1822
		UnicodeString,
		// Token: 0x0400071F RID: 1823
		UnicodeHexString,
		// Token: 0x04000720 RID: 1824
		Name,
		// Token: 0x04000721 RID: 1825
		Operator,
		// Token: 0x04000722 RID: 1826
		BeginArray,
		// Token: 0x04000723 RID: 1827
		EndArray,
		// Token: 0x04000724 RID: 1828
		Dictionary,
		// Token: 0x04000725 RID: 1829
		Eof,
		// Token: 0x04000726 RID: 1830
		Error = -1
	}
}
