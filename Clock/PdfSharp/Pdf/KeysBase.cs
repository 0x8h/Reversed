using System;

namespace PdfSharp.Pdf
{
	// Token: 0x020000C8 RID: 200
	public class KeysBase
	{
		// Token: 0x06000862 RID: 2146 RVA: 0x0001FE94 File Offset: 0x0001E094
		internal static DictionaryMeta CreateMeta(Type type)
		{
			return new DictionaryMeta(type);
		}
	}
}
