using System;

namespace PdfSharp.Pdf.Annotations
{
	// Token: 0x0200013F RID: 319
	internal sealed class PdfWidgetAnnotation : PdfAnnotation
	{
		// Token: 0x06000AD5 RID: 2773 RVA: 0x0002AC49 File Offset: 0x00028E49
		public PdfWidgetAnnotation()
		{
			this.Initialize();
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x0002AC57 File Offset: 0x00028E57
		public PdfWidgetAnnotation(PdfDocument document)
			: base(document)
		{
			this.Initialize();
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x0002AC66 File Offset: 0x00028E66
		private void Initialize()
		{
			base.Elements.SetName("/Subtype", "/Widget");
		}

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x0002AC7D File Offset: 0x00028E7D
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfWidgetAnnotation.Keys.Meta;
			}
		}

		// Token: 0x02000140 RID: 320
		internal new class Keys : PdfAnnotation.Keys
		{
			// Token: 0x17000406 RID: 1030
			// (get) Token: 0x06000AD9 RID: 2777 RVA: 0x0002AC84 File Offset: 0x00028E84
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfWidgetAnnotation.Keys._meta) == null)
					{
						dictionaryMeta = (PdfWidgetAnnotation.Keys._meta = KeysBase.CreateMeta(typeof(PdfWidgetAnnotation.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x0400062C RID: 1580
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string H = "/H";

			// Token: 0x0400062D RID: 1581
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string MK = "/MK";

			// Token: 0x0400062E RID: 1582
			private static DictionaryMeta _meta;
		}
	}
}
