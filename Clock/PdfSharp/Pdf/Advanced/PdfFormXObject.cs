using System;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000107 RID: 263
	public sealed class PdfFormXObject : PdfXObject, IContentStream
	{
		// Token: 0x060009A8 RID: 2472 RVA: 0x000240E8 File Offset: 0x000222E8
		internal PdfFormXObject(PdfDocument thisDocument)
			: base(thisDocument)
		{
			base.Elements.SetName("/Type", "/XObject");
			base.Elements.SetName("/Subtype", "/Form");
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x00024144 File Offset: 0x00022344
		internal PdfFormXObject(PdfDocument thisDocument, XForm form)
			: base(thisDocument)
		{
			base.Elements.SetName("/Type", "/XObject");
			base.Elements.SetName("/Subtype", "/Form");
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x060009AA RID: 2474 RVA: 0x000241A0 File Offset: 0x000223A0
		// (set) Token: 0x060009AB RID: 2475 RVA: 0x000241A8 File Offset: 0x000223A8
		internal double DpiX
		{
			get
			{
				return this._dpiX;
			}
			set
			{
				this._dpiX = value;
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x060009AC RID: 2476 RVA: 0x000241B1 File Offset: 0x000223B1
		// (set) Token: 0x060009AD RID: 2477 RVA: 0x000241B9 File Offset: 0x000223B9
		internal double DpiY
		{
			get
			{
				return this._dpiY;
			}
			set
			{
				this._dpiY = value;
			}
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x000241C4 File Offset: 0x000223C4
		internal PdfFormXObject(PdfDocument thisDocument, PdfImportedObjectTable importedObjectTable, XPdfForm form)
			: base(thisDocument)
		{
			base.Elements.SetName("/Type", "/XObject");
			base.Elements.SetName("/Subtype", "/Form");
			if (form.IsTemplate)
			{
				return;
			}
			PdfPages pages = importedObjectTable.ExternalDocument.Pages;
			if (form.PageNumber < 1 || form.PageNumber > pages.Count)
			{
				PSSR.ImportPageNumberOutOfRange(form.PageNumber, pages.Count, form._path);
			}
			PdfPage pdfPage = pages[form.PageNumber - 1];
			PdfItem pdfItem = pdfPage.Elements["/Resources"];
			if (pdfItem != null)
			{
				PdfObject pdfObject;
				if (pdfItem is PdfReference)
				{
					pdfObject = ((PdfReference)pdfItem).Value;
				}
				else
				{
					pdfObject = (PdfDictionary)pdfItem;
				}
				pdfObject = PdfObject.ImportClosure(importedObjectTable, thisDocument, pdfObject);
				if (pdfObject.Reference == null)
				{
					thisDocument._irefTable.Add(pdfObject);
				}
				base.Elements["/Resources"] = pdfObject.Reference;
			}
			PdfRectangle rectangle = pdfPage.Elements.GetRectangle("/MediaBox");
			int integer = pdfPage.Elements.GetInteger("/Rotate");
			if (integer == 0)
			{
				base.Elements["/BBox"] = rectangle;
			}
			else
			{
				base.Elements["/BBox"] = rectangle;
				XMatrix xmatrix = default(XMatrix);
				double width = rectangle.Width;
				double height = rectangle.Height;
				xmatrix.RotateAtPrepend((double)(-(double)integer), new XPoint(width / 2.0, height / 2.0));
				double num = (height - width) / 2.0;
				if (height > width)
				{
					xmatrix.TranslatePrepend(num, num);
				}
				else
				{
					xmatrix.TranslatePrepend(-num, -num);
				}
				base.Elements.SetMatrix("/Matrix", xmatrix);
			}
			PdfContent pdfContent = pdfPage.Contents.CreateSingleContent();
			pdfContent.Compressed = true;
			PdfItem pdfItem2 = pdfContent.Elements["/Filter"];
			if (pdfItem2 != null)
			{
				base.Elements["/Filter"] = pdfItem2.Clone();
			}
			base.Stream = pdfContent.Stream;
			base.Elements.SetInteger("/Length", pdfContent.Stream.Value.Length);
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x060009AF RID: 2479 RVA: 0x00024424 File Offset: 0x00022624
		public PdfResources Resources
		{
			get
			{
				if (this._resources == null)
				{
					this._resources = (PdfResources)base.Elements.GetValue("/Resources", VCF.Create);
				}
				return this._resources;
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x00024450 File Offset: 0x00022650
		PdfResources IContentStream.Resources
		{
			get
			{
				return this.Resources;
			}
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x00024458 File Offset: 0x00022658
		internal string GetFontName(XFont font, out PdfFont pdfFont)
		{
			pdfFont = this._document.FontTable.GetFont(font);
			return this.Resources.AddFont(pdfFont);
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x00024487 File Offset: 0x00022687
		string IContentStream.GetFontName(XFont font, out PdfFont pdfFont)
		{
			return this.GetFontName(font, out pdfFont);
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00024494 File Offset: 0x00022694
		internal string GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
		{
			pdfFont = this._document.FontTable.GetFont(idName, fontData);
			return this.Resources.AddFont(pdfFont);
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x000244C4 File Offset: 0x000226C4
		string IContentStream.GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
		{
			return this.GetFontName(idName, fontData, out pdfFont);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x000244CF File Offset: 0x000226CF
		string IContentStream.GetImageName(XImage image)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x000244D6 File Offset: 0x000226D6
		string IContentStream.GetFormName(XForm form)
		{
			throw new NotImplementedException();
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x060009B7 RID: 2487 RVA: 0x000244DD File Offset: 0x000226DD
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfFormXObject.Keys.Meta;
			}
		}

		// Token: 0x0400053D RID: 1341
		private double _dpiX = 72.0;

		// Token: 0x0400053E RID: 1342
		private double _dpiY = 72.0;

		// Token: 0x0400053F RID: 1343
		private PdfResources _resources;

		// Token: 0x02000108 RID: 264
		public new sealed class Keys : PdfXObject.Keys
		{
			// Token: 0x170003A9 RID: 937
			// (get) Token: 0x060009B8 RID: 2488 RVA: 0x000244E4 File Offset: 0x000226E4
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfFormXObject.Keys._meta) == null)
					{
						dictionaryMeta = (PdfFormXObject.Keys._meta = KeysBase.CreateMeta(typeof(PdfFormXObject.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x04000540 RID: 1344
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string Type = "/Type";

			// Token: 0x04000541 RID: 1345
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string Subtype = "/Subtype";

			// Token: 0x04000542 RID: 1346
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string FormType = "/FormType";

			// Token: 0x04000543 RID: 1347
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Integer | KeyType.Required)]
			public const string BBox = "/BBox";

			// Token: 0x04000544 RID: 1348
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Matrix = "/Matrix";

			// Token: 0x04000545 RID: 1349
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfResources))]
			public const string Resources = "/Resources";

			// Token: 0x04000546 RID: 1350
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string Group = "/Group";

			// Token: 0x04000547 RID: 1351
			private static DictionaryMeta _meta;
		}
	}
}
