using System;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x020000FA RID: 250
	public abstract class PdfDictionaryWithContentStream : PdfDictionary, IContentStream
	{
		// Token: 0x06000977 RID: 2423 RVA: 0x000237AF File Offset: 0x000219AF
		public PdfDictionaryWithContentStream()
		{
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x000237B7 File Offset: 0x000219B7
		public PdfDictionaryWithContentStream(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x000237C0 File Offset: 0x000219C0
		protected PdfDictionaryWithContentStream(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x000237C9 File Offset: 0x000219C9
		internal PdfResources Resources
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

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x0600097B RID: 2427 RVA: 0x000237F5 File Offset: 0x000219F5
		PdfResources IContentStream.Resources
		{
			get
			{
				return this.Resources;
			}
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x00023800 File Offset: 0x00021A00
		internal string GetFontName(XFont font, out PdfFont pdfFont)
		{
			pdfFont = this._document.FontTable.GetFont(font);
			return this.Resources.AddFont(pdfFont);
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0002382F File Offset: 0x00021A2F
		string IContentStream.GetFontName(XFont font, out PdfFont pdfFont)
		{
			return this.GetFontName(font, out pdfFont);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0002383C File Offset: 0x00021A3C
		internal string GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
		{
			pdfFont = this._document.FontTable.GetFont(idName, fontData);
			return this.Resources.AddFont(pdfFont);
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0002386C File Offset: 0x00021A6C
		string IContentStream.GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
		{
			return this.GetFontName(idName, fontData, out pdfFont);
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x00023878 File Offset: 0x00021A78
		internal string GetImageName(XImage image)
		{
			PdfImage image2 = this._document.ImageTable.GetImage(image);
			return this.Resources.AddImage(image2);
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x000238A5 File Offset: 0x00021AA5
		string IContentStream.GetImageName(XImage image)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x000238AC File Offset: 0x00021AAC
		internal string GetFormName(XForm form)
		{
			PdfFormXObject form2 = this._document.FormTable.GetForm(form);
			return this.Resources.AddForm(form2);
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x000238D9 File Offset: 0x00021AD9
		string IContentStream.GetFormName(XForm form)
		{
			throw new NotImplementedException();
		}

		// Token: 0x040004F5 RID: 1269
		private PdfResources _resources;

		// Token: 0x020000FB RID: 251
		public class Keys : PdfDictionary.PdfStream.Keys
		{
			// Token: 0x040004F6 RID: 1270
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfResources))]
			public const string Resources = "/Resources";
		}
	}
}
