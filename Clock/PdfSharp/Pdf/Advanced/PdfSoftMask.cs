using System;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000123 RID: 291
	public class PdfSoftMask : PdfDictionary
	{
		// Token: 0x06000A64 RID: 2660 RVA: 0x000296BC File Offset: 0x000278BC
		public PdfSoftMask(PdfDocument document)
			: base(document)
		{
			base.Elements.SetName("/Type", "/Mask");
		}

		// Token: 0x02000124 RID: 292
		public class Keys : KeysBase
		{
			// Token: 0x040005B9 RID: 1465
			[KeyInfo(KeyType.Name | KeyType.Optional, FixedValue = "Mask")]
			public const string Type = "/Type";

			// Token: 0x040005BA RID: 1466
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string S = "/S";

			// Token: 0x040005BB RID: 1467
			[KeyInfo(KeyType.String | KeyType.Array | KeyType.Required)]
			public const string G = "/G";

			// Token: 0x040005BC RID: 1468
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string BC = "/BC";

			// Token: 0x040005BD RID: 1469
			[KeyInfo(KeyType.NameOrArray | KeyType.NameOrDictionary | KeyType.StreamOrArray | KeyType.Optional)]
			public const string TR = "/TR";
		}
	}
}
