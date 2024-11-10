using System;
using System.Collections.Generic;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x0200011D RID: 285
	public sealed class PdfResources : PdfDictionary
	{
		// Token: 0x06000A40 RID: 2624 RVA: 0x00028BA6 File Offset: 0x00026DA6
		public PdfResources(PdfDocument document)
			: base(document)
		{
			base.Elements["/ProcSet"] = new PdfLiteral("[/PDF/Text/ImageB/ImageC/ImageI]");
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x00028BD4 File Offset: 0x00026DD4
		internal PdfResources(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x00028BE8 File Offset: 0x00026DE8
		public string AddFont(PdfFont font)
		{
			string nextFontName;
			if (!this._resources.TryGetValue(font, out nextFontName))
			{
				nextFontName = this.NextFontName;
				this._resources[font] = nextFontName;
				if (font.Reference == null)
				{
					this.Owner._irefTable.Add(font);
				}
				this.Fonts.Elements[nextFontName] = font.Reference;
			}
			return nextFontName;
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00028C4C File Offset: 0x00026E4C
		public string AddImage(PdfImage image)
		{
			string nextImageName;
			if (!this._resources.TryGetValue(image, out nextImageName))
			{
				nextImageName = this.NextImageName;
				this._resources[image] = nextImageName;
				if (image.Reference == null)
				{
					this.Owner._irefTable.Add(image);
				}
				this.XObjects.Elements[nextImageName] = image.Reference;
			}
			return nextImageName;
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x00028CB0 File Offset: 0x00026EB0
		public string AddForm(PdfFormXObject form)
		{
			string nextFormName;
			if (!this._resources.TryGetValue(form, out nextFormName))
			{
				nextFormName = this.NextFormName;
				this._resources[form] = nextFormName;
				if (form.Reference == null)
				{
					this.Owner._irefTable.Add(form);
				}
				this.XObjects.Elements[nextFormName] = form.Reference;
			}
			return nextFormName;
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x00028D14 File Offset: 0x00026F14
		public string AddExtGState(PdfExtGState extGState)
		{
			string nextExtGStateName;
			if (!this._resources.TryGetValue(extGState, out nextExtGStateName))
			{
				nextExtGStateName = this.NextExtGStateName;
				this._resources[extGState] = nextExtGStateName;
				if (extGState.Reference == null)
				{
					this.Owner._irefTable.Add(extGState);
				}
				this.ExtGStates.Elements[nextExtGStateName] = extGState.Reference;
			}
			return nextExtGStateName;
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00028D78 File Offset: 0x00026F78
		public string AddPattern(PdfShadingPattern pattern)
		{
			string nextPatternName;
			if (!this._resources.TryGetValue(pattern, out nextPatternName))
			{
				nextPatternName = this.NextPatternName;
				this._resources[pattern] = nextPatternName;
				if (pattern.Reference == null)
				{
					this.Owner._irefTable.Add(pattern);
				}
				this.Patterns.Elements[nextPatternName] = pattern.Reference;
			}
			return nextPatternName;
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x00028DDC File Offset: 0x00026FDC
		public string AddPattern(PdfTilingPattern pattern)
		{
			string nextPatternName;
			if (!this._resources.TryGetValue(pattern, out nextPatternName))
			{
				nextPatternName = this.NextPatternName;
				this._resources[pattern] = nextPatternName;
				if (pattern.Reference == null)
				{
					this.Owner._irefTable.Add(pattern);
				}
				this.Patterns.Elements[nextPatternName] = pattern.Reference;
			}
			return nextPatternName;
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x00028E40 File Offset: 0x00027040
		public string AddShading(PdfShading shading)
		{
			string nextShadingName;
			if (!this._resources.TryGetValue(shading, out nextShadingName))
			{
				nextShadingName = this.NextShadingName;
				this._resources[shading] = nextShadingName;
				if (shading.Reference == null)
				{
					this.Owner._irefTable.Add(shading);
				}
				this.Shadings.Elements[nextShadingName] = shading.Reference;
			}
			return nextShadingName;
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06000A49 RID: 2633 RVA: 0x00028EA4 File Offset: 0x000270A4
		internal PdfResourceMap Fonts
		{
			get
			{
				PdfResourceMap pdfResourceMap;
				if ((pdfResourceMap = this._fonts) == null)
				{
					pdfResourceMap = (this._fonts = (PdfResourceMap)base.Elements.GetValue("/Font", VCF.Create));
				}
				return pdfResourceMap;
			}
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000A4A RID: 2634 RVA: 0x00028EDC File Offset: 0x000270DC
		internal PdfResourceMap XObjects
		{
			get
			{
				PdfResourceMap pdfResourceMap;
				if ((pdfResourceMap = this._xObjects) == null)
				{
					pdfResourceMap = (this._xObjects = (PdfResourceMap)base.Elements.GetValue("/XObject", VCF.Create));
				}
				return pdfResourceMap;
			}
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x00028F14 File Offset: 0x00027114
		internal PdfResourceMap ExtGStates
		{
			get
			{
				PdfResourceMap pdfResourceMap;
				if ((pdfResourceMap = this._extGStates) == null)
				{
					pdfResourceMap = (this._extGStates = (PdfResourceMap)base.Elements.GetValue("/ExtGState", VCF.Create));
				}
				return pdfResourceMap;
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06000A4C RID: 2636 RVA: 0x00028F4C File Offset: 0x0002714C
		internal PdfResourceMap ColorSpaces
		{
			get
			{
				PdfResourceMap pdfResourceMap;
				if ((pdfResourceMap = this._colorSpaces) == null)
				{
					pdfResourceMap = (this._colorSpaces = (PdfResourceMap)base.Elements.GetValue("/ColorSpace", VCF.Create));
				}
				return pdfResourceMap;
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06000A4D RID: 2637 RVA: 0x00028F84 File Offset: 0x00027184
		internal PdfResourceMap Patterns
		{
			get
			{
				PdfResourceMap pdfResourceMap;
				if ((pdfResourceMap = this._patterns) == null)
				{
					pdfResourceMap = (this._patterns = (PdfResourceMap)base.Elements.GetValue("/Pattern", VCF.Create));
				}
				return pdfResourceMap;
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000A4E RID: 2638 RVA: 0x00028FBC File Offset: 0x000271BC
		internal PdfResourceMap Shadings
		{
			get
			{
				PdfResourceMap pdfResourceMap;
				if ((pdfResourceMap = this._shadings) == null)
				{
					pdfResourceMap = (this._shadings = (PdfResourceMap)base.Elements.GetValue("/Shading", VCF.Create));
				}
				return pdfResourceMap;
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000A4F RID: 2639 RVA: 0x00028FF4 File Offset: 0x000271F4
		internal PdfResourceMap Properties
		{
			get
			{
				PdfResourceMap pdfResourceMap;
				if ((pdfResourceMap = this._properties) == null)
				{
					pdfResourceMap = (this._properties = (PdfResourceMap)base.Elements.GetValue("/Properties", VCF.Create));
				}
				return pdfResourceMap;
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000A50 RID: 2640 RVA: 0x0002902C File Offset: 0x0002722C
		private string NextFontName
		{
			get
			{
				string text;
				while (this.ExistsResourceNames(text = string.Format("/F{0}", this._fontNumber++)))
				{
				}
				return text;
			}
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000A51 RID: 2641 RVA: 0x00029064 File Offset: 0x00027264
		private string NextImageName
		{
			get
			{
				string text;
				while (this.ExistsResourceNames(text = string.Format("/I{0}", this._imageNumber++)))
				{
				}
				return text;
			}
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000A52 RID: 2642 RVA: 0x0002909C File Offset: 0x0002729C
		private string NextFormName
		{
			get
			{
				string text;
				while (this.ExistsResourceNames(text = string.Format("/Fm{0}", this._formNumber++)))
				{
				}
				return text;
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x000290D4 File Offset: 0x000272D4
		private string NextExtGStateName
		{
			get
			{
				string text;
				while (this.ExistsResourceNames(text = string.Format("/GS{0}", this._extGStateNumber++)))
				{
				}
				return text;
			}
		}

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06000A54 RID: 2644 RVA: 0x0002910C File Offset: 0x0002730C
		private string NextPatternName
		{
			get
			{
				string text;
				while (this.ExistsResourceNames(text = string.Format("/Pa{0}", this._patternNumber++)))
				{
				}
				return text;
			}
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000A55 RID: 2645 RVA: 0x00029144 File Offset: 0x00027344
		private string NextShadingName
		{
			get
			{
				string text;
				while (this.ExistsResourceNames(text = string.Format("/Sh{0}", this._shadingNumber++)))
				{
				}
				return text;
			}
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x0002917C File Offset: 0x0002737C
		internal bool ExistsResourceNames(string name)
		{
			if (this._importedResourceNames == null)
			{
				this._importedResourceNames = new Dictionary<string, object>();
				if (base.Elements["/Font"] != null)
				{
					this.Fonts.CollectResourceNames(this._importedResourceNames);
				}
				if (base.Elements["/XObject"] != null)
				{
					this.XObjects.CollectResourceNames(this._importedResourceNames);
				}
				if (base.Elements["/ExtGState"] != null)
				{
					this.ExtGStates.CollectResourceNames(this._importedResourceNames);
				}
				if (base.Elements["/ColorSpace"] != null)
				{
					this.ColorSpaces.CollectResourceNames(this._importedResourceNames);
				}
				if (base.Elements["/Pattern"] != null)
				{
					this.Patterns.CollectResourceNames(this._importedResourceNames);
				}
				if (base.Elements["/Shading"] != null)
				{
					this.Shadings.CollectResourceNames(this._importedResourceNames);
				}
				if (base.Elements["/Properties"] != null)
				{
					this.Properties.CollectResourceNames(this._importedResourceNames);
				}
			}
			return this._importedResourceNames.ContainsKey(name);
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000A57 RID: 2647 RVA: 0x000292A0 File Offset: 0x000274A0
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfResources.Keys.Meta;
			}
		}

		// Token: 0x04000591 RID: 1425
		private PdfResourceMap _fonts;

		// Token: 0x04000592 RID: 1426
		private PdfResourceMap _xObjects;

		// Token: 0x04000593 RID: 1427
		private PdfResourceMap _extGStates;

		// Token: 0x04000594 RID: 1428
		private PdfResourceMap _colorSpaces;

		// Token: 0x04000595 RID: 1429
		private PdfResourceMap _patterns;

		// Token: 0x04000596 RID: 1430
		private PdfResourceMap _shadings;

		// Token: 0x04000597 RID: 1431
		private PdfResourceMap _properties;

		// Token: 0x04000598 RID: 1432
		private int _fontNumber;

		// Token: 0x04000599 RID: 1433
		private int _imageNumber;

		// Token: 0x0400059A RID: 1434
		private int _formNumber;

		// Token: 0x0400059B RID: 1435
		private int _extGStateNumber;

		// Token: 0x0400059C RID: 1436
		private int _patternNumber;

		// Token: 0x0400059D RID: 1437
		private int _shadingNumber;

		// Token: 0x0400059E RID: 1438
		private Dictionary<string, object> _importedResourceNames;

		// Token: 0x0400059F RID: 1439
		private readonly Dictionary<PdfObject, string> _resources = new Dictionary<PdfObject, string>();

		// Token: 0x0200011E RID: 286
		public sealed class Keys : KeysBase
		{
			// Token: 0x170003D6 RID: 982
			// (get) Token: 0x06000A58 RID: 2648 RVA: 0x000292A7 File Offset: 0x000274A7
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfResources.Keys._meta) == null)
					{
						dictionaryMeta = (PdfResources.Keys._meta = KeysBase.CreateMeta(typeof(PdfResources.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040005A0 RID: 1440
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfResourceMap))]
			public const string ExtGState = "/ExtGState";

			// Token: 0x040005A1 RID: 1441
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfResourceMap))]
			public const string ColorSpace = "/ColorSpace";

			// Token: 0x040005A2 RID: 1442
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfResourceMap))]
			public const string Pattern = "/Pattern";

			// Token: 0x040005A3 RID: 1443
			[KeyInfo("1.3", KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfResourceMap))]
			public const string Shading = "/Shading";

			// Token: 0x040005A4 RID: 1444
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfResourceMap))]
			public const string XObject = "/XObject";

			// Token: 0x040005A5 RID: 1445
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfResourceMap))]
			public const string Font = "/Font";

			// Token: 0x040005A6 RID: 1446
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string ProcSet = "/ProcSet";

			// Token: 0x040005A7 RID: 1447
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfResourceMap))]
			public const string Properties = "/Properties";

			// Token: 0x040005A8 RID: 1448
			private static DictionaryMeta _meta;
		}
	}
}
