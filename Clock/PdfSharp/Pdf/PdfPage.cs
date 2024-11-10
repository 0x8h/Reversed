using System;
using System.ComponentModel;
using System.Globalization;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001AC RID: 428
	public sealed class PdfPage : PdfDictionary, IContentStream
	{
		// Token: 0x06000DEF RID: 3567 RVA: 0x00036A58 File Offset: 0x00034C58
		public PdfPage()
		{
			base.Elements.SetName("/Type", "/Page");
			this.Initialize();
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x00036A88 File Offset: 0x00034C88
		public PdfPage(PdfDocument document)
			: base(document)
		{
			base.Elements.SetName("/Type", "/Page");
			base.Elements["/Parent"] = document.Pages.Reference;
			this.Initialize();
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x00036AE0 File Offset: 0x00034CE0
		internal PdfPage(PdfDictionary dict)
			: base(dict)
		{
			int integer = base.Elements.GetInteger("/Rotate");
			if (Math.Abs(integer / 90) % 2 == 1)
			{
				this._orientation = PageOrientation.Landscape;
			}
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x00036B25 File Offset: 0x00034D25
		private void Initialize()
		{
			this.Size = (RegionInfo.CurrentRegion.IsMetric ? PageSize.A4 : PageSize.Letter);
			PdfRectangle mediaBox = this.MediaBox;
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x00036B45 File Offset: 0x00034D45
		// (set) Token: 0x06000DF4 RID: 3572 RVA: 0x00036B4D File Offset: 0x00034D4D
		public object Tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				this._tag = value;
			}
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x00036B56 File Offset: 0x00034D56
		public void Close()
		{
			this._closed = true;
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06000DF6 RID: 3574 RVA: 0x00036B5F File Offset: 0x00034D5F
		internal bool IsClosed
		{
			get
			{
				return this._closed;
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (set) Token: 0x06000DF7 RID: 3575 RVA: 0x00036B68 File Offset: 0x00034D68
		internal override PdfDocument Document
		{
			set
			{
				if (!object.ReferenceEquals(this._document, value))
				{
					if (this._document != null)
					{
						throw new InvalidOperationException("Cannot change document.");
					}
					this._document = value;
					if (base.Reference != null)
					{
						base.Reference.Document = value;
					}
					base.Elements["/Parent"] = this._document.Pages.Reference;
				}
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06000DF8 RID: 3576 RVA: 0x00036BD1 File Offset: 0x00034DD1
		// (set) Token: 0x06000DF9 RID: 3577 RVA: 0x00036BD9 File Offset: 0x00034DD9
		public PageOrientation Orientation
		{
			get
			{
				return this._orientation;
			}
			set
			{
				this._orientation = value;
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06000DFA RID: 3578 RVA: 0x00036BE2 File Offset: 0x00034DE2
		// (set) Token: 0x06000DFB RID: 3579 RVA: 0x00036BEC File Offset: 0x00034DEC
		public PageSize Size
		{
			get
			{
				return this._pageSize;
			}
			set
			{
				if (!Enum.IsDefined(typeof(PageSize), value))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(PageSize));
				}
				XSize xsize = PageSizeConverter.ToSize(value);
				this.MediaBox = new PdfRectangle(0.0, 0.0, xsize.Width, xsize.Height);
				this._pageSize = value;
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06000DFC RID: 3580 RVA: 0x00036C5F File Offset: 0x00034E5F
		// (set) Token: 0x06000DFD RID: 3581 RVA: 0x00036C7C File Offset: 0x00034E7C
		public TrimMargins TrimMargins
		{
			get
			{
				if (this._trimMargins == null)
				{
					this._trimMargins = new TrimMargins();
				}
				return this._trimMargins;
			}
			set
			{
				if (this._trimMargins == null)
				{
					this._trimMargins = new TrimMargins();
				}
				if (value != null)
				{
					this._trimMargins.Left = value.Left;
					this._trimMargins.Right = value.Right;
					this._trimMargins.Top = value.Top;
					this._trimMargins.Bottom = value.Bottom;
					return;
				}
				this._trimMargins.All = 0;
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06000DFE RID: 3582 RVA: 0x00036CF5 File Offset: 0x00034EF5
		// (set) Token: 0x06000DFF RID: 3583 RVA: 0x00036D08 File Offset: 0x00034F08
		public PdfRectangle MediaBox
		{
			get
			{
				return base.Elements.GetRectangle("/MediaBox", true);
			}
			set
			{
				base.Elements.SetRectangle("/MediaBox", value);
			}
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06000E00 RID: 3584 RVA: 0x00036D1B File Offset: 0x00034F1B
		// (set) Token: 0x06000E01 RID: 3585 RVA: 0x00036D2E File Offset: 0x00034F2E
		public PdfRectangle CropBox
		{
			get
			{
				return base.Elements.GetRectangle("/CropBox", true);
			}
			set
			{
				base.Elements.SetRectangle("/CropBox", value);
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06000E02 RID: 3586 RVA: 0x00036D41 File Offset: 0x00034F41
		// (set) Token: 0x06000E03 RID: 3587 RVA: 0x00036D54 File Offset: 0x00034F54
		public PdfRectangle BleedBox
		{
			get
			{
				return base.Elements.GetRectangle("/BleedBox", true);
			}
			set
			{
				base.Elements.SetRectangle("/BleedBox", value);
			}
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06000E04 RID: 3588 RVA: 0x00036D67 File Offset: 0x00034F67
		// (set) Token: 0x06000E05 RID: 3589 RVA: 0x00036D7A File Offset: 0x00034F7A
		public PdfRectangle ArtBox
		{
			get
			{
				return base.Elements.GetRectangle("/ArtBox", true);
			}
			set
			{
				base.Elements.SetRectangle("/ArtBox", value);
			}
		}

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06000E06 RID: 3590 RVA: 0x00036D8D File Offset: 0x00034F8D
		// (set) Token: 0x06000E07 RID: 3591 RVA: 0x00036DA0 File Offset: 0x00034FA0
		public PdfRectangle TrimBox
		{
			get
			{
				return base.Elements.GetRectangle("/TrimBox", true);
			}
			set
			{
				base.Elements.SetRectangle("/TrimBox", value);
			}
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06000E08 RID: 3592 RVA: 0x00036DB4 File Offset: 0x00034FB4
		// (set) Token: 0x06000E09 RID: 3593 RVA: 0x00036DE4 File Offset: 0x00034FE4
		public XUnit Height
		{
			get
			{
				PdfRectangle mediaBox = this.MediaBox;
				return (this._orientation == PageOrientation.Portrait) ? mediaBox.Height : mediaBox.Width;
			}
			set
			{
				PdfRectangle mediaBox = this.MediaBox;
				if (this._orientation == PageOrientation.Portrait)
				{
					this.MediaBox = new PdfRectangle(mediaBox.X1, 0.0, mediaBox.X2, value);
				}
				else
				{
					this.MediaBox = new PdfRectangle(0.0, mediaBox.Y1, value, mediaBox.Y2);
				}
				this._pageSize = PageSize.Undefined;
			}
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06000E0A RID: 3594 RVA: 0x00036E58 File Offset: 0x00035058
		// (set) Token: 0x06000E0B RID: 3595 RVA: 0x00036E88 File Offset: 0x00035088
		public XUnit Width
		{
			get
			{
				PdfRectangle mediaBox = this.MediaBox;
				return (this._orientation == PageOrientation.Portrait) ? mediaBox.Width : mediaBox.Height;
			}
			set
			{
				PdfRectangle mediaBox = this.MediaBox;
				if (this._orientation == PageOrientation.Portrait)
				{
					this.MediaBox = new PdfRectangle(0.0, mediaBox.Y1, value, mediaBox.Y2);
				}
				else
				{
					this.MediaBox = new PdfRectangle(mediaBox.X1, 0.0, mediaBox.X2, value);
				}
				this._pageSize = PageSize.Undefined;
			}
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06000E0C RID: 3596 RVA: 0x00036EFB File Offset: 0x000350FB
		// (set) Token: 0x06000E0D RID: 3597 RVA: 0x00036F0D File Offset: 0x0003510D
		public int Rotate
		{
			get
			{
				return this._elements.GetInteger("/Rotate");
			}
			set
			{
				if (value / 90 * 90 != value)
				{
					throw new ArgumentException("Value must be a multiple of 90.");
				}
				this._elements.SetInteger("/Rotate", value);
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06000E0E RID: 3598 RVA: 0x00036F38 File Offset: 0x00035138
		public PdfContents Contents
		{
			get
			{
				if (this._contents == null)
				{
					PdfItem pdfItem = base.Elements["/Contents"];
					if (pdfItem == null)
					{
						this._contents = new PdfContents(this.Owner);
					}
					else
					{
						if (pdfItem is PdfReference)
						{
							pdfItem = ((PdfReference)pdfItem).Value;
						}
						PdfArray pdfArray = pdfItem as PdfArray;
						if (pdfArray != null)
						{
							if (pdfArray.IsIndirect)
							{
								pdfArray = pdfArray.Clone();
								pdfArray.Document = this.Owner;
							}
							this._contents = new PdfContents(pdfArray);
						}
						else
						{
							this._contents = new PdfContents(this.Owner);
							PdfContent pdfContent = new PdfContent((PdfDictionary)pdfItem);
							this._contents.Elements.Add(pdfContent.Reference);
						}
					}
					base.Elements["/Contents"] = this._contents;
				}
				return this._contents;
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06000E0F RID: 3599 RVA: 0x0003700D File Offset: 0x0003520D
		public bool HasAnnotations
		{
			get
			{
				if (this._annotations == null)
				{
					this._annotations = (PdfAnnotations)base.Elements.GetValue("/Annots");
					this._annotations.Page = this;
				}
				return this._annotations != null;
			}
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06000E10 RID: 3600 RVA: 0x0003704A File Offset: 0x0003524A
		public PdfAnnotations Annotations
		{
			get
			{
				if (this._annotations == null)
				{
					this._annotations = (PdfAnnotations)base.Elements.GetValue("/Annots", VCF.Create);
					this._annotations.Page = this;
				}
				return this._annotations;
			}
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x00037084 File Offset: 0x00035284
		public PdfLinkAnnotation AddDocumentLink(PdfRectangle rect, int destinationPage)
		{
			PdfLinkAnnotation pdfLinkAnnotation = PdfLinkAnnotation.CreateDocumentLink(rect, destinationPage);
			this.Annotations.Add(pdfLinkAnnotation);
			return pdfLinkAnnotation;
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x000370A8 File Offset: 0x000352A8
		public PdfLinkAnnotation AddWebLink(PdfRectangle rect, string url)
		{
			PdfLinkAnnotation pdfLinkAnnotation = PdfLinkAnnotation.CreateWebLink(rect, url);
			this.Annotations.Add(pdfLinkAnnotation);
			return pdfLinkAnnotation;
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x000370CC File Offset: 0x000352CC
		public PdfLinkAnnotation AddFileLink(PdfRectangle rect, string fileName)
		{
			PdfLinkAnnotation pdfLinkAnnotation = PdfLinkAnnotation.CreateFileLink(rect, fileName);
			this.Annotations.Add(pdfLinkAnnotation);
			return pdfLinkAnnotation;
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06000E14 RID: 3604 RVA: 0x000370EE File Offset: 0x000352EE
		// (set) Token: 0x06000E15 RID: 3605 RVA: 0x0003710F File Offset: 0x0003530F
		public PdfCustomValues CustomValues
		{
			get
			{
				if (this._customValues == null)
				{
					this._customValues = PdfCustomValues.Get(base.Elements);
				}
				return this._customValues;
			}
			set
			{
				if (value != null)
				{
					throw new ArgumentException("Only null is allowed to clear all custom values.");
				}
				PdfCustomValues.Remove(base.Elements);
				this._customValues = null;
			}
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06000E16 RID: 3606 RVA: 0x00037131 File Offset: 0x00035331
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

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06000E17 RID: 3607 RVA: 0x0003715D File Offset: 0x0003535D
		PdfResources IContentStream.Resources
		{
			get
			{
				return this.Resources;
			}
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x00037168 File Offset: 0x00035368
		internal string GetFontName(XFont font, out PdfFont pdfFont)
		{
			pdfFont = this._document.FontTable.GetFont(font);
			return this.Resources.AddFont(pdfFont);
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x00037197 File Offset: 0x00035397
		string IContentStream.GetFontName(XFont font, out PdfFont pdfFont)
		{
			return this.GetFontName(font, out pdfFont);
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x000371A4 File Offset: 0x000353A4
		internal string TryGetFontName(string idName, out PdfFont pdfFont)
		{
			pdfFont = this._document.FontTable.TryGetFont(idName);
			string text = null;
			if (pdfFont != null)
			{
				text = this.Resources.AddFont(pdfFont);
			}
			return text;
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x000371DC File Offset: 0x000353DC
		internal string GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
		{
			pdfFont = this._document.FontTable.GetFont(idName, fontData);
			return this.Resources.AddFont(pdfFont);
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x0003720C File Offset: 0x0003540C
		string IContentStream.GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
		{
			return this.GetFontName(idName, fontData, out pdfFont);
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x00037218 File Offset: 0x00035418
		internal string GetImageName(XImage image)
		{
			PdfImage image2 = this._document.ImageTable.GetImage(image);
			return this.Resources.AddImage(image2);
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x00037245 File Offset: 0x00035445
		string IContentStream.GetImageName(XImage image)
		{
			return this.GetImageName(image);
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x00037250 File Offset: 0x00035450
		internal string GetFormName(XForm form)
		{
			PdfFormXObject form2 = this._document.FormTable.GetForm(form);
			return this.Resources.AddForm(form2);
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x0003727D File Offset: 0x0003547D
		string IContentStream.GetFormName(XForm form)
		{
			return this.GetFormName(form);
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x00037288 File Offset: 0x00035488
		internal override void WriteObject(PdfWriter writer)
		{
			PdfRectangle mediaBox = this.MediaBox;
			if (this._orientation == PageOrientation.Landscape)
			{
				this.MediaBox = new PdfRectangle(mediaBox.X1, mediaBox.Y1, mediaBox.Y2, mediaBox.X2);
			}
			this.TransparencyUsed = true;
			if (this.TransparencyUsed && !base.Elements.ContainsKey("/Group") && this._document.Options.ColorMode != PdfColorMode.Undefined)
			{
				PdfDictionary pdfDictionary = new PdfDictionary();
				this._elements["/Group"] = pdfDictionary;
				if (this._document.Options.ColorMode != PdfColorMode.Cmyk)
				{
					pdfDictionary.Elements.SetName("/CS", "/DeviceRGB");
				}
				else
				{
					pdfDictionary.Elements.SetName("/CS", "/DeviceCMYK");
				}
				pdfDictionary.Elements.SetName("/S", "/Transparency");
			}
			base.WriteObject(writer);
			if (this._orientation == PageOrientation.Landscape)
			{
				this.MediaBox = mediaBox;
			}
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x00037380 File Offset: 0x00035580
		internal static void InheritValues(PdfDictionary page, PdfPage.InheritedValues values)
		{
			if (values.Resources != null)
			{
				PdfItem pdfItem = page.Elements["/Resources"];
				PdfDictionary pdfDictionary;
				if (pdfItem is PdfReference)
				{
					pdfDictionary = (PdfDictionary)((PdfReference)pdfItem).Value.Clone();
					pdfDictionary.Document = page.Owner;
				}
				else
				{
					pdfDictionary = (PdfDictionary)pdfItem;
				}
				if (pdfDictionary == null)
				{
					pdfDictionary = values.Resources.Clone();
					pdfDictionary.Document = page.Owner;
					page.Elements.Add("/Resources", pdfDictionary);
				}
				else
				{
					foreach (PdfName pdfName in values.Resources.Elements.KeyNames)
					{
						if (!pdfDictionary.Elements.ContainsKey(pdfName.Value))
						{
							PdfItem pdfItem2 = values.Resources.Elements[pdfName];
							if (pdfItem2 is PdfObject)
							{
								pdfItem2 = pdfItem2.Clone();
							}
							pdfDictionary.Elements.Add(pdfName.ToString(), pdfItem2);
						}
					}
				}
			}
			if (values.MediaBox != null && page.Elements["/MediaBox"] == null)
			{
				page.Elements["/MediaBox"] = values.MediaBox;
			}
			if (values.CropBox != null && page.Elements["/CropBox"] == null)
			{
				page.Elements["/CropBox"] = values.CropBox;
			}
			if (values.Rotate != null && page.Elements["/Rotate"] == null)
			{
				page.Elements["/Rotate"] = values.Rotate;
			}
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x00037524 File Offset: 0x00035724
		internal static void InheritValues(PdfDictionary page, ref PdfPage.InheritedValues values)
		{
			PdfItem pdfItem = page.Elements["/Resources"];
			if (pdfItem != null)
			{
				PdfReference pdfReference = pdfItem as PdfReference;
				if (pdfReference != null)
				{
					values.Resources = (PdfDictionary)pdfReference.Value;
				}
				else
				{
					values.Resources = (PdfDictionary)pdfItem;
				}
			}
			pdfItem = page.Elements["/MediaBox"];
			if (pdfItem != null)
			{
				values.MediaBox = new PdfRectangle(pdfItem);
			}
			pdfItem = page.Elements["/CropBox"];
			if (pdfItem != null)
			{
				values.CropBox = new PdfRectangle(pdfItem);
			}
			pdfItem = page.Elements["/Rotate"];
			if (pdfItem != null)
			{
				if (pdfItem is PdfReference)
				{
					pdfItem = ((PdfReference)pdfItem).Value;
				}
				values.Rotate = (PdfInteger)pdfItem;
			}
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x000375E4 File Offset: 0x000357E4
		internal override void PrepareForSave()
		{
			if (this._trimMargins.AreSet)
			{
				double num = this._trimMargins.Left.Point + this.Width.Point + this._trimMargins.Right.Point;
				double num2 = this._trimMargins.Top.Point + this.Height.Point + this._trimMargins.Bottom.Point;
				this.MediaBox = new PdfRectangle(0.0, 0.0, num, num2);
				this.CropBox = new PdfRectangle(0.0, 0.0, num, num2);
				this.BleedBox = new PdfRectangle(0.0, 0.0, num, num2);
				PdfRectangle pdfRectangle = new PdfRectangle(this._trimMargins.Left.Point, this._trimMargins.Top.Point, num - this._trimMargins.Right.Point, num2 - this._trimMargins.Bottom.Point);
				this.TrimBox = pdfRectangle;
				this.ArtBox = pdfRectangle.Clone();
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06000E25 RID: 3621 RVA: 0x0003773E File Offset: 0x0003593E
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfPage.Keys.Meta;
			}
		}

		// Token: 0x0400089E RID: 2206
		private object _tag;

		// Token: 0x0400089F RID: 2207
		private bool _closed;

		// Token: 0x040008A0 RID: 2208
		private PageOrientation _orientation;

		// Token: 0x040008A1 RID: 2209
		private PageSize _pageSize;

		// Token: 0x040008A2 RID: 2210
		private TrimMargins _trimMargins = new TrimMargins();

		// Token: 0x040008A3 RID: 2211
		internal PdfContent RenderContent;

		// Token: 0x040008A4 RID: 2212
		private PdfContents _contents;

		// Token: 0x040008A5 RID: 2213
		private PdfAnnotations _annotations;

		// Token: 0x040008A6 RID: 2214
		private PdfCustomValues _customValues;

		// Token: 0x040008A7 RID: 2215
		private PdfResources _resources;

		// Token: 0x040008A8 RID: 2216
		internal bool TransparencyUsed;

		// Token: 0x020001AD RID: 429
		internal class InheritablePageKeys : KeysBase
		{
			// Token: 0x040008A9 RID: 2217
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required | KeyType.Inheritable, typeof(PdfResources))]
			public const string Resources = "/Resources";

			// Token: 0x040008AA RID: 2218
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Integer | KeyType.Required | KeyType.Inheritable)]
			public const string MediaBox = "/MediaBox";

			// Token: 0x040008AB RID: 2219
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Integer | KeyType.Optional | KeyType.Inheritable)]
			public const string CropBox = "/CropBox";

			// Token: 0x040008AC RID: 2220
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string Rotate = "/Rotate";
		}

		// Token: 0x020001AE RID: 430
		internal sealed class Keys : PdfPage.InheritablePageKeys
		{
			// Token: 0x170004CC RID: 1228
			// (get) Token: 0x06000E27 RID: 3623 RVA: 0x0003774D File Offset: 0x0003594D
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfPage.Keys._meta) == null)
					{
						dictionaryMeta = (PdfPage.Keys._meta = KeysBase.CreateMeta(typeof(PdfPage.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040008AD RID: 2221
			[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Page")]
			public const string Type = "/Type";

			// Token: 0x040008AE RID: 2222
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required | KeyType.MustBeIndirect)]
			public const string Parent = "/Parent";

			// Token: 0x040008AF RID: 2223
			[KeyInfo(KeyType.Date)]
			public const string LastModified = "/LastModified";

			// Token: 0x040008B0 RID: 2224
			[KeyInfo("1.3", KeyType.Name | KeyType.String | KeyType.Integer | KeyType.Optional)]
			public const string BleedBox = "/BleedBox";

			// Token: 0x040008B1 RID: 2225
			[KeyInfo("1.3", KeyType.Name | KeyType.String | KeyType.Integer | KeyType.Optional)]
			public const string TrimBox = "/TrimBox";

			// Token: 0x040008B2 RID: 2226
			[KeyInfo("1.3", KeyType.Name | KeyType.String | KeyType.Integer | KeyType.Optional)]
			public const string ArtBox = "/ArtBox";

			// Token: 0x040008B3 RID: 2227
			[KeyInfo("1.4", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string BoxColorInfo = "/BoxColorInfo";

			// Token: 0x040008B4 RID: 2228
			[KeyInfo(KeyType.String | KeyType.Array | KeyType.Optional)]
			public const string Contents = "/Contents";

			// Token: 0x040008B5 RID: 2229
			[KeyInfo("1.4", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string Group = "/Group";

			// Token: 0x040008B6 RID: 2230
			[KeyInfo(KeyType.String | KeyType.Array | KeyType.Optional)]
			public const string Thumb = "/Thumb";

			// Token: 0x040008B7 RID: 2231
			[KeyInfo("1.1", KeyType.Array | KeyType.Optional)]
			public const string B = "/B";

			// Token: 0x040008B8 RID: 2232
			[KeyInfo("1.1", KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string Dur = "/Dur";

			// Token: 0x040008B9 RID: 2233
			[KeyInfo("1.1", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string Trans = "/Trans";

			// Token: 0x040008BA RID: 2234
			[KeyInfo(KeyType.Array | KeyType.Optional, typeof(PdfAnnotations))]
			public const string Annots = "/Annots";

			// Token: 0x040008BB RID: 2235
			[KeyInfo("1.2", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string AA = "/AA";

			// Token: 0x040008BC RID: 2236
			[KeyInfo("1.4", KeyType.String | KeyType.Array | KeyType.Optional)]
			public const string Metadata = "/Metadata";

			// Token: 0x040008BD RID: 2237
			[KeyInfo("1.3", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string PieceInfo = "/PieceInfo";

			// Token: 0x040008BE RID: 2238
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string StructParents = "/StructParents";

			// Token: 0x040008BF RID: 2239
			[KeyInfo("1.3", KeyType.String | KeyType.Optional)]
			public const string ID = "/ID";

			// Token: 0x040008C0 RID: 2240
			[KeyInfo("1.3", KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string PZ = "/PZ";

			// Token: 0x040008C1 RID: 2241
			[KeyInfo("1.3", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string SeparationInfo = "/SeparationInfo";

			// Token: 0x040008C2 RID: 2242
			[KeyInfo("1.5", KeyType.Name | KeyType.Optional)]
			public const string Tabs = "/Tabs";

			// Token: 0x040008C3 RID: 2243
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string TemplateInstantiated = "/TemplateInstantiated";

			// Token: 0x040008C4 RID: 2244
			[KeyInfo("1.5", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string PresSteps = "/PresSteps";

			// Token: 0x040008C5 RID: 2245
			[KeyInfo("1.6", KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string UserUnit = "/UserUnit";

			// Token: 0x040008C6 RID: 2246
			[KeyInfo("1.6", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string VP = "/VP";

			// Token: 0x040008C7 RID: 2247
			private static DictionaryMeta _meta;
		}

		// Token: 0x020001AF RID: 431
		internal struct InheritedValues
		{
			// Token: 0x040008C8 RID: 2248
			public PdfDictionary Resources;

			// Token: 0x040008C9 RID: 2249
			public PdfRectangle MediaBox;

			// Token: 0x040008CA RID: 2250
			public PdfRectangle CropBox;

			// Token: 0x040008CB RID: 2251
			public PdfInteger Rotate;
		}
	}
}
