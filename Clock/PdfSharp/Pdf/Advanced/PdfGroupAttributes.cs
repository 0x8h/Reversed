using System;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x0200010B RID: 267
	public abstract class PdfGroupAttributes : PdfDictionary
	{
		// Token: 0x060009C6 RID: 2502 RVA: 0x0002487B File Offset: 0x00022A7B
		internal PdfGroupAttributes(PdfDocument thisDocument)
			: base(thisDocument)
		{
			base.Elements.SetName("/Type", "/Group");
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x060009C7 RID: 2503 RVA: 0x00024899 File Offset: 0x00022A99
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfGroupAttributes.Keys.Meta;
			}
		}

		// Token: 0x0200010C RID: 268
		public class Keys : KeysBase
		{
			// Token: 0x170003AC RID: 940
			// (get) Token: 0x060009C8 RID: 2504 RVA: 0x000248A0 File Offset: 0x00022AA0
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfGroupAttributes.Keys._meta) == null)
					{
						dictionaryMeta = (PdfGroupAttributes.Keys._meta = KeysBase.CreateMeta(typeof(PdfGroupAttributes.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x0400054A RID: 1354
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string Type = "/Type";

			// Token: 0x0400054B RID: 1355
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string S = "/S";

			// Token: 0x0400054C RID: 1356
			private static DictionaryMeta _meta;
		}
	}
}
