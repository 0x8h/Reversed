using System;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000129 RID: 297
	public sealed class PdfTransparencyGroupAttributes : PdfGroupAttributes
	{
		// Token: 0x06000A70 RID: 2672 RVA: 0x000299A8 File Offset: 0x00027BA8
		internal PdfTransparencyGroupAttributes(PdfDocument thisDocument)
			: base(thisDocument)
		{
			base.Elements.SetName("/S", "/Transparency");
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000A71 RID: 2673 RVA: 0x000299C6 File Offset: 0x00027BC6
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfTransparencyGroupAttributes.Keys.Meta;
			}
		}

		// Token: 0x0200012A RID: 298
		public new sealed class Keys : PdfGroupAttributes.Keys
		{
			// Token: 0x170003DF RID: 991
			// (get) Token: 0x06000A72 RID: 2674 RVA: 0x000299CD File Offset: 0x00027BCD
			internal new static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfTransparencyGroupAttributes.Keys._meta) == null)
					{
						dictionaryMeta = (PdfTransparencyGroupAttributes.Keys._meta = KeysBase.CreateMeta(typeof(PdfTransparencyGroupAttributes.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040005C9 RID: 1481
			[KeyInfo(KeyType.NameOrArray | KeyType.Optional)]
			public const string CS = "/CS";

			// Token: 0x040005CA RID: 1482
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string I = "/I";

			// Token: 0x040005CB RID: 1483
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string K = "/K";

			// Token: 0x040005CC RID: 1484
			private static DictionaryMeta _meta;
		}
	}
}
