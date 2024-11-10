using System;

namespace PdfSharp.Pdf.Security
{
	// Token: 0x0200017C RID: 380
	public abstract class PdfSecurityHandler : PdfDictionary
	{
		// Token: 0x06000C75 RID: 3189 RVA: 0x00032EC1 File Offset: 0x000310C1
		internal PdfSecurityHandler(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x00032ECA File Offset: 0x000310CA
		internal PdfSecurityHandler(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x0200017D RID: 381
		internal class Keys : KeysBase
		{
			// Token: 0x040007BE RID: 1982
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string Filter = "/Filter";

			// Token: 0x040007BF RID: 1983
			[KeyInfo("1.3", KeyType.Name | KeyType.Optional)]
			public const string SubFilter = "/SubFilter";

			// Token: 0x040007C0 RID: 1984
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string V = "/V";

			// Token: 0x040007C1 RID: 1985
			[KeyInfo("1.4", KeyType.Integer | KeyType.Optional)]
			public const string Length = "/Length";

			// Token: 0x040007C2 RID: 1986
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string CF = "/CF";

			// Token: 0x040007C3 RID: 1987
			[KeyInfo("1.5", KeyType.Name | KeyType.Optional)]
			public const string StmF = "/StmF";

			// Token: 0x040007C4 RID: 1988
			[KeyInfo("1.5", KeyType.Name | KeyType.Optional)]
			public const string StrF = "/StrF";

			// Token: 0x040007C5 RID: 1989
			[KeyInfo("1.6", KeyType.Name | KeyType.Optional)]
			public const string EFF = "/EFF";
		}
	}
}
