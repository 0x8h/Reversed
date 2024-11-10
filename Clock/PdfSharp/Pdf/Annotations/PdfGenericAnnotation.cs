using System;

namespace PdfSharp.Pdf.Annotations
{
	// Token: 0x02000136 RID: 310
	internal sealed class PdfGenericAnnotation : PdfAnnotation
	{
		// Token: 0x06000AB6 RID: 2742 RVA: 0x0002A712 File Offset: 0x00028912
		public PdfGenericAnnotation(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x0002A71B File Offset: 0x0002891B
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfGenericAnnotation.Keys.Meta;
			}
		}

		// Token: 0x02000137 RID: 311
		internal new class Keys : PdfAnnotation.Keys
		{
			// Token: 0x170003FB RID: 1019
			// (get) Token: 0x06000AB8 RID: 2744 RVA: 0x0002A722 File Offset: 0x00028922
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfGenericAnnotation.Keys._meta) == null)
					{
						dictionaryMeta = (PdfGenericAnnotation.Keys._meta = KeysBase.CreateMeta(typeof(PdfGenericAnnotation.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x0400061A RID: 1562
			private static DictionaryMeta _meta;
		}
	}
}
