using System;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000D9 RID: 217
	public sealed class PdfGenericField : PdfAcroField
	{
		// Token: 0x060008D4 RID: 2260 RVA: 0x00021671 File Offset: 0x0001F871
		internal PdfGenericField(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x0002167A File Offset: 0x0001F87A
		internal PdfGenericField(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x00021683 File Offset: 0x0001F883
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfGenericField.Keys.Meta;
			}
		}

		// Token: 0x020000DA RID: 218
		public new class Keys : PdfAcroField.Keys
		{
			// Token: 0x1700035E RID: 862
			// (get) Token: 0x060008D7 RID: 2263 RVA: 0x0002168A File Offset: 0x0001F88A
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfGenericField.Keys._meta) == null)
					{
						dictionaryMeta = (PdfGenericField.Keys._meta = KeysBase.CreateMeta(typeof(PdfGenericField.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x04000486 RID: 1158
			private static DictionaryMeta _meta;
		}
	}
}
