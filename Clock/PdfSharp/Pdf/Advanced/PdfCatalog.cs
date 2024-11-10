using System;
using PdfSharp.Pdf.AcroForms;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x020000EA RID: 234
	public sealed class PdfCatalog : PdfDictionary
	{
		// Token: 0x0600090E RID: 2318 RVA: 0x00021CE7 File Offset: 0x0001FEE7
		public PdfCatalog(PdfDocument document)
			: base(document)
		{
			base.Elements.SetName("/Type", "/Catalog");
			this._version = "1.4";
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00021D1B File Offset: 0x0001FF1B
		internal PdfCatalog(PdfDictionary dictionary)
			: base(dictionary)
		{
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x00021D2F File Offset: 0x0001FF2F
		// (set) Token: 0x06000911 RID: 2321 RVA: 0x00021D38 File Offset: 0x0001FF38
		public string Version
		{
			get
			{
				return this._version;
			}
			set
			{
				switch (value)
				{
				case "1.0":
				case "1.1":
				case "1.2":
					throw new InvalidOperationException("Unsupported PDF version.");
				case "1.3":
				case "1.4":
					this._version = value;
					return;
				case "1.5":
				case "1.6":
					throw new InvalidOperationException("Unsupported PDF version.");
				}
				throw new ArgumentException("Invalid version.");
			}
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x00021E14 File Offset: 0x00020014
		public PdfPages Pages
		{
			get
			{
				if (this._pages == null)
				{
					this._pages = (PdfPages)base.Elements.GetValue("/Pages", VCF.CreateIndirect);
					if (this.Owner.IsImported)
					{
						this._pages.FlattenPageTree();
					}
				}
				return this._pages;
			}
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000913 RID: 2323 RVA: 0x00021E63 File Offset: 0x00020063
		// (set) Token: 0x06000914 RID: 2324 RVA: 0x00021E7B File Offset: 0x0002007B
		internal PdfPageLayout PageLayout
		{
			get
			{
				return (PdfPageLayout)base.Elements.GetEnumFromName("/PageLayout", PdfPageLayout.SinglePage);
			}
			set
			{
				base.Elements.SetEnumAsName("/PageLayout", value);
			}
		}

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000915 RID: 2325 RVA: 0x00021E93 File Offset: 0x00020093
		// (set) Token: 0x06000916 RID: 2326 RVA: 0x00021EAB File Offset: 0x000200AB
		internal PdfPageMode PageMode
		{
			get
			{
				return (PdfPageMode)base.Elements.GetEnumFromName("/PageMode", PdfPageMode.UseNone);
			}
			set
			{
				base.Elements.SetEnumAsName("/PageMode", value);
			}
		}

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000917 RID: 2327 RVA: 0x00021EC3 File Offset: 0x000200C3
		internal PdfViewerPreferences ViewerPreferences
		{
			get
			{
				if (this._viewerPreferences == null)
				{
					this._viewerPreferences = (PdfViewerPreferences)base.Elements.GetValue("/ViewerPreferences", VCF.CreateIndirect);
				}
				return this._viewerPreferences;
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000918 RID: 2328 RVA: 0x00021EEF File Offset: 0x000200EF
		internal PdfOutlineCollection Outlines
		{
			get
			{
				if (this._outline == null)
				{
					this._outline = (PdfOutline)base.Elements.GetValue("/Outlines", VCF.CreateIndirect);
				}
				return this._outline.Outlines;
			}
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000919 RID: 2329 RVA: 0x00021F20 File Offset: 0x00020120
		public PdfAcroForm AcroForm
		{
			get
			{
				if (this._acroForm == null)
				{
					this._acroForm = (PdfAcroForm)base.Elements.GetValue("/AcroForm");
				}
				return this._acroForm;
			}
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x00021F4B File Offset: 0x0002014B
		// (set) Token: 0x0600091B RID: 2331 RVA: 0x00021F5D File Offset: 0x0002015D
		public string Language
		{
			get
			{
				return base.Elements.GetString("/Lang");
			}
			set
			{
				if (value == null)
				{
					base.Elements.Remove("/Lang");
					return;
				}
				base.Elements.SetString("/Lang", value);
			}
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00021F88 File Offset: 0x00020188
		internal override void PrepareForSave()
		{
			if (this._pages != null)
			{
				this._pages.PrepareForSave();
			}
			if (this._outline != null && this._outline.Outlines.Count > 0)
			{
				if (base.Elements["/PageMode"] == null)
				{
					this.PageMode = PdfPageMode.UseOutlines;
				}
				this._outline.PrepareForSave();
			}
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x00021FE7 File Offset: 0x000201E7
		internal override void WriteObject(PdfWriter writer)
		{
			if (this._outline != null && this._outline.Outlines.Count > 0 && base.Elements["/PageMode"] == null)
			{
				this.PageMode = PdfPageMode.UseOutlines;
			}
			base.WriteObject(writer);
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x0600091E RID: 2334 RVA: 0x00022024 File Offset: 0x00020224
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfCatalog.Keys.Meta;
			}
		}

		// Token: 0x040004A3 RID: 1187
		private string _version = "1.3";

		// Token: 0x040004A4 RID: 1188
		private PdfPages _pages;

		// Token: 0x040004A5 RID: 1189
		private PdfViewerPreferences _viewerPreferences;

		// Token: 0x040004A6 RID: 1190
		private PdfOutline _outline;

		// Token: 0x040004A7 RID: 1191
		private PdfAcroForm _acroForm;

		// Token: 0x020000EB RID: 235
		internal sealed class Keys : KeysBase
		{
			// Token: 0x1700037B RID: 891
			// (get) Token: 0x0600091F RID: 2335 RVA: 0x0002202B File Offset: 0x0002022B
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfCatalog.Keys._meta) == null)
					{
						dictionaryMeta = (PdfCatalog.Keys._meta = KeysBase.CreateMeta(typeof(PdfCatalog.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040004A8 RID: 1192
			[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Catalog")]
			public const string Type = "/Type";

			// Token: 0x040004A9 RID: 1193
			[KeyInfo("1.4", KeyType.Name | KeyType.Optional)]
			public const string Version = "/Version";

			// Token: 0x040004AA RID: 1194
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required | KeyType.MustBeIndirect, typeof(PdfPages))]
			public const string Pages = "/Pages";

			// Token: 0x040004AB RID: 1195
			[KeyInfo("1.3", KeyType.Name | KeyType.String | KeyType.Array | KeyType.Optional)]
			public const string PageLabels = "/PageLabels";

			// Token: 0x040004AC RID: 1196
			[KeyInfo("1.2", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string Names = "/Names";

			// Token: 0x040004AD RID: 1197
			[KeyInfo("1.1", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string Dests = "/Dests";

			// Token: 0x040004AE RID: 1198
			[KeyInfo("1.2", KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfViewerPreferences))]
			public const string ViewerPreferences = "/ViewerPreferences";

			// Token: 0x040004AF RID: 1199
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string PageLayout = "/PageLayout";

			// Token: 0x040004B0 RID: 1200
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string PageMode = "/PageMode";

			// Token: 0x040004B1 RID: 1201
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfOutline))]
			public const string Outlines = "/Outlines";

			// Token: 0x040004B2 RID: 1202
			[KeyInfo("1.1", KeyType.Array | KeyType.Optional)]
			public const string Threads = "/Threads";

			// Token: 0x040004B3 RID: 1203
			[KeyInfo("1.1", KeyType.NameOrArray | KeyType.NameOrDictionary | KeyType.Optional)]
			public const string OpenAction = "/OpenAction";

			// Token: 0x040004B4 RID: 1204
			[KeyInfo("1.4", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string AA = "/AA";

			// Token: 0x040004B5 RID: 1205
			[KeyInfo("1.1", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string URI = "/URI";

			// Token: 0x040004B6 RID: 1206
			[KeyInfo("1.2", KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfAcroForm))]
			public const string AcroForm = "/AcroForm";

			// Token: 0x040004B7 RID: 1207
			[KeyInfo("1.4", KeyType.Name | KeyType.Array | KeyType.Optional | KeyType.MustBeIndirect)]
			public const string Metadata = "/Metadata";

			// Token: 0x040004B8 RID: 1208
			[KeyInfo("1.3", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string StructTreeRoot = "/StructTreeRoot";

			// Token: 0x040004B9 RID: 1209
			[KeyInfo("1.4", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string MarkInfo = "/MarkInfo";

			// Token: 0x040004BA RID: 1210
			[KeyInfo("1.4", KeyType.String | KeyType.Optional)]
			public const string Lang = "/Lang";

			// Token: 0x040004BB RID: 1211
			[KeyInfo("1.3", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string SpiderInfo = "/SpiderInfo";

			// Token: 0x040004BC RID: 1212
			[KeyInfo("1.4", KeyType.Array | KeyType.Optional)]
			public const string OutputIntents = "/OutputIntents";

			// Token: 0x040004BD RID: 1213
			[KeyInfo("1.4", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string PieceInfo = "/PieceInfo";

			// Token: 0x040004BE RID: 1214
			[KeyInfo("1.5", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string OCProperties = "/OCProperties";

			// Token: 0x040004BF RID: 1215
			[KeyInfo("1.5", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string Perms = "/Perms";

			// Token: 0x040004C0 RID: 1216
			[KeyInfo("1.5", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string Legal = "/Legal";

			// Token: 0x040004C1 RID: 1217
			private static DictionaryMeta _meta;
		}
	}
}
