using System;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Annotations
{
	// Token: 0x02000138 RID: 312
	public sealed class PdfLinkAnnotation : PdfAnnotation
	{
		// Token: 0x06000ABA RID: 2746 RVA: 0x0002A74A File Offset: 0x0002894A
		public PdfLinkAnnotation()
		{
			this._linkType = PdfLinkAnnotation.LinkType.None;
			base.Elements.SetName("/Subtype", "/Link");
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x0002A76E File Offset: 0x0002896E
		public PdfLinkAnnotation(PdfDocument document)
			: base(document)
		{
			this._linkType = PdfLinkAnnotation.LinkType.None;
			base.Elements.SetName("/Subtype", "/Link");
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x0002A794 File Offset: 0x00028994
		public static PdfLinkAnnotation CreateDocumentLink(PdfRectangle rect, int destinationPage)
		{
			if (destinationPage < 1)
			{
				throw new ArgumentException("Invalid destination page in call to CreateDocumentLink: page number is one-based and must be 1 or higher.", "destinationPage");
			}
			return new PdfLinkAnnotation
			{
				_linkType = PdfLinkAnnotation.LinkType.Document,
				Rectangle = rect,
				_destPage = destinationPage
			};
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x0002A7D4 File Offset: 0x000289D4
		public static PdfLinkAnnotation CreateWebLink(PdfRectangle rect, string url)
		{
			return new PdfLinkAnnotation
			{
				_linkType = PdfLinkAnnotation.LinkType.Web,
				Rectangle = rect,
				_url = url
			};
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0002A800 File Offset: 0x00028A00
		public static PdfLinkAnnotation CreateFileLink(PdfRectangle rect, string fileName)
		{
			return new PdfLinkAnnotation
			{
				_linkType = PdfLinkAnnotation.LinkType.File,
				Rectangle = rect,
				_url = fileName
			};
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0002A82C File Offset: 0x00028A2C
		internal override void WriteObject(PdfWriter writer)
		{
			if (base.Elements["/BS"] == null)
			{
				base.Elements["/BS"] = new PdfLiteral("<</Type/Border/W 0>>");
			}
			if (base.Elements["/Border"] == null)
			{
				base.Elements["/Border"] = new PdfLiteral("[0 0 0]");
			}
			switch (this._linkType)
			{
			case PdfLinkAnnotation.LinkType.Document:
			{
				int num = this._destPage;
				if (num > this.Owner.PageCount)
				{
					num = this.Owner.PageCount;
				}
				num--;
				PdfPage pdfPage = this.Owner.Pages[num];
				base.Elements["/Dest"] = new PdfLiteral("[{0} 0 R/XYZ null null 0]", new object[] { pdfPage.ObjectNumber });
				break;
			}
			case PdfLinkAnnotation.LinkType.Web:
				base.Elements["/A"] = new PdfLiteral("<</S/URI/URI{0}>>", new object[] { PdfEncoders.ToStringLiteral(this._url, PdfStringEncoding.WinAnsiEncoding, writer.SecurityHandler) });
				break;
			case PdfLinkAnnotation.LinkType.File:
				base.Elements["/A"] = new PdfLiteral("<</Type/Action/S/Launch/F<</Type/Filespec/F{0}>> >>", new object[] { PdfEncoders.ToStringLiteral(this._url, PdfStringEncoding.WinAnsiEncoding, writer.SecurityHandler) });
				break;
			}
			base.WriteObject(writer);
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000AC0 RID: 2752 RVA: 0x0002A99B File Offset: 0x00028B9B
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfLinkAnnotation.Keys.Meta;
			}
		}

		// Token: 0x0400061B RID: 1563
		private int _destPage;

		// Token: 0x0400061C RID: 1564
		private PdfLinkAnnotation.LinkType _linkType;

		// Token: 0x0400061D RID: 1565
		private string _url;

		// Token: 0x02000139 RID: 313
		private enum LinkType
		{
			// Token: 0x0400061F RID: 1567
			None,
			// Token: 0x04000620 RID: 1568
			Document,
			// Token: 0x04000621 RID: 1569
			Web,
			// Token: 0x04000622 RID: 1570
			File
		}

		// Token: 0x0200013A RID: 314
		internal new class Keys : PdfAnnotation.Keys
		{
			// Token: 0x170003FD RID: 1021
			// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x0002A9A2 File Offset: 0x00028BA2
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfLinkAnnotation.Keys._meta) == null)
					{
						dictionaryMeta = (PdfLinkAnnotation.Keys._meta = KeysBase.CreateMeta(typeof(PdfLinkAnnotation.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x04000623 RID: 1571
			[KeyInfo(KeyType.NameOrDictionary | KeyType.StreamOrArray | KeyType.Optional)]
			public const string Dest = "/Dest";

			// Token: 0x04000624 RID: 1572
			[KeyInfo("1.2", KeyType.Name | KeyType.Optional)]
			public const string H = "/H";

			// Token: 0x04000625 RID: 1573
			[KeyInfo("1.3", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string PA = "/PA";

			// Token: 0x04000626 RID: 1574
			private static DictionaryMeta _meta;
		}
	}
}
