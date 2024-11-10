using System;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000DD RID: 221
	public sealed class PdfPushButtonField : PdfButtonField
	{
		// Token: 0x060008E0 RID: 2272 RVA: 0x00021741 File Offset: 0x0001F941
		internal PdfPushButtonField(PdfDocument document)
			: base(document)
		{
			this._document = document;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00021751 File Offset: 0x0001F951
		internal PdfPushButtonField(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x060008E2 RID: 2274 RVA: 0x0002175A File Offset: 0x0001F95A
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfPushButtonField.Keys.Meta;
			}
		}

		// Token: 0x020000DE RID: 222
		public new class Keys : PdfAcroField.Keys
		{
			// Token: 0x17000363 RID: 867
			// (get) Token: 0x060008E3 RID: 2275 RVA: 0x00021761 File Offset: 0x0001F961
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfPushButtonField.Keys._meta) == null)
					{
						dictionaryMeta = (PdfPushButtonField.Keys._meta = KeysBase.CreateMeta(typeof(PdfPushButtonField.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x04000488 RID: 1160
			private static DictionaryMeta _meta;
		}
	}
}
