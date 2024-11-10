using System;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000E1 RID: 225
	public sealed class PdfSignatureField : PdfAcroField
	{
		// Token: 0x060008ED RID: 2285 RVA: 0x000218DF File Offset: 0x0001FADF
		internal PdfSignatureField(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x000218E8 File Offset: 0x0001FAE8
		internal PdfSignatureField(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x060008EF RID: 2287 RVA: 0x000218F1 File Offset: 0x0001FAF1
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfSignatureField.Keys.Meta;
			}
		}

		// Token: 0x020000E2 RID: 226
		public new class Keys : PdfAcroField.Keys
		{
			// Token: 0x17000368 RID: 872
			// (get) Token: 0x060008F0 RID: 2288 RVA: 0x000218F8 File Offset: 0x0001FAF8
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfSignatureField.Keys._meta) == null)
					{
						dictionaryMeta = (PdfSignatureField.Keys._meta = KeysBase.CreateMeta(typeof(PdfSignatureField.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x0400048B RID: 1163
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string Type = "/Type";

			// Token: 0x0400048C RID: 1164
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string Filter = "/Filter";

			// Token: 0x0400048D RID: 1165
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string SubFilter = "/SubFilter";

			// Token: 0x0400048E RID: 1166
			[KeyInfo(KeyType.Array | KeyType.Required)]
			public const string ByteRange = "/ByteRange";

			// Token: 0x0400048F RID: 1167
			[KeyInfo(KeyType.String | KeyType.Required)]
			public const string Contents = "/Contents";

			// Token: 0x04000490 RID: 1168
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string Name = "/Name";

			// Token: 0x04000491 RID: 1169
			[KeyInfo(KeyType.String | KeyType.Integer | KeyType.Optional)]
			public const string M = "/M";

			// Token: 0x04000492 RID: 1170
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string Location = "/Location";

			// Token: 0x04000493 RID: 1171
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string Reason = "/Reason";

			// Token: 0x04000494 RID: 1172
			private static DictionaryMeta _meta;
		}
	}
}
