using System;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000125 RID: 293
	public sealed class PdfTilingPattern : PdfDictionaryWithContentStream
	{
		// Token: 0x06000A66 RID: 2662 RVA: 0x000296E2 File Offset: 0x000278E2
		public PdfTilingPattern(PdfDocument document)
			: base(document)
		{
			base.Elements.SetName("/Type", "/Pattern");
			base.Elements["/PatternType"] = new PdfInteger(1);
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06000A67 RID: 2663 RVA: 0x00029716 File Offset: 0x00027916
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfTilingPattern.Keys.Meta;
			}
		}

		// Token: 0x02000126 RID: 294
		internal new sealed class Keys : PdfDictionaryWithContentStream.Keys
		{
			// Token: 0x170003DC RID: 988
			// (get) Token: 0x06000A68 RID: 2664 RVA: 0x0002971D File Offset: 0x0002791D
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfTilingPattern.Keys._meta) == null)
					{
						dictionaryMeta = (PdfTilingPattern.Keys._meta = KeysBase.CreateMeta(typeof(PdfTilingPattern.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040005BE RID: 1470
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string Type = "/Type";

			// Token: 0x040005BF RID: 1471
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string PatternType = "/PatternType";

			// Token: 0x040005C0 RID: 1472
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string PaintType = "/PaintType";

			// Token: 0x040005C1 RID: 1473
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string TilingType = "/TilingType";

			// Token: 0x040005C2 RID: 1474
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Integer | KeyType.Optional)]
			public const string BBox = "/BBox";

			// Token: 0x040005C3 RID: 1475
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Required)]
			public const string XStep = "/XStep";

			// Token: 0x040005C4 RID: 1476
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Required)]
			public const string YStep = "/YStep";

			// Token: 0x040005C5 RID: 1477
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required)]
			public new const string Resources = "/Resources";

			// Token: 0x040005C6 RID: 1478
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Matrix = "/Matrix";

			// Token: 0x040005C7 RID: 1479
			private static DictionaryMeta _meta;
		}
	}
}
