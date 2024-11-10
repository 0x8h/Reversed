using System;

namespace PdfSharp.Pdf.Actions
{
	// Token: 0x020000E6 RID: 230
	public abstract class PdfAction : PdfDictionary
	{
		// Token: 0x06000907 RID: 2311 RVA: 0x00021C53 File Offset: 0x0001FE53
		protected PdfAction()
		{
			base.Elements.SetName("/Type", "/Action");
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x00021C70 File Offset: 0x0001FE70
		protected PdfAction(PdfDocument document)
			: base(document)
		{
			base.Elements.SetName("/Type", "/Action");
		}

		// Token: 0x020000E7 RID: 231
		internal class Keys : KeysBase
		{
			// Token: 0x0400049F RID: 1183
			[KeyInfo(KeyType.Name | KeyType.Optional, FixedValue = "Action")]
			public const string Type = "/Type";

			// Token: 0x040004A0 RID: 1184
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string S = "/S";

			// Token: 0x040004A1 RID: 1185
			[KeyInfo(KeyType.NameOrArray | KeyType.NameOrDictionary | KeyType.Optional)]
			public const string Next = "/Next";
		}
	}
}
