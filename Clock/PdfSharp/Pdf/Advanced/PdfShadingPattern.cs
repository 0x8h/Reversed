using System;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Pdf;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000121 RID: 289
	public sealed class PdfShadingPattern : PdfDictionaryWithContentStream
	{
		// Token: 0x06000A5F RID: 2655 RVA: 0x00029607 File Offset: 0x00027807
		public PdfShadingPattern(PdfDocument document)
			: base(document)
		{
			base.Elements.SetName("/Type", "/Pattern");
			base.Elements["/PatternType"] = new PdfInteger(2);
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x0002963C File Offset: 0x0002783C
		internal void SetupFromBrush(XLinearGradientBrush brush, XMatrix matrix, XGraphicsPdfRenderer renderer)
		{
			if (brush == null)
			{
				throw new ArgumentNullException("brush");
			}
			PdfShading pdfShading = new PdfShading(this._document);
			pdfShading.SetupFromBrush(brush, renderer);
			base.Elements["/Shading"] = pdfShading;
			base.Elements.SetMatrix("/Matrix", matrix);
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06000A61 RID: 2657 RVA: 0x0002968D File Offset: 0x0002788D
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfShadingPattern.Keys.Meta;
			}
		}

		// Token: 0x02000122 RID: 290
		internal new sealed class Keys : PdfDictionaryWithContentStream.Keys
		{
			// Token: 0x170003DA RID: 986
			// (get) Token: 0x06000A62 RID: 2658 RVA: 0x00029694 File Offset: 0x00027894
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfShadingPattern.Keys._meta) == null)
					{
						dictionaryMeta = (PdfShadingPattern.Keys._meta = KeysBase.CreateMeta(typeof(PdfShadingPattern.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040005B3 RID: 1459
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string Type = "/Type";

			// Token: 0x040005B4 RID: 1460
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string PatternType = "/PatternType";

			// Token: 0x040005B5 RID: 1461
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required)]
			public const string Shading = "/Shading";

			// Token: 0x040005B6 RID: 1462
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Matrix = "/Matrix";

			// Token: 0x040005B7 RID: 1463
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string ExtGState = "/ExtGState";

			// Token: 0x040005B8 RID: 1464
			private static DictionaryMeta _meta;
		}
	}
}
