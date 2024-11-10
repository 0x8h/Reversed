using System;

namespace PdfSharp.Pdf
{
	// Token: 0x020001BD RID: 445
	public sealed class PdfViewerPreferences : PdfDictionary
	{
		// Token: 0x06000EC2 RID: 3778 RVA: 0x0003996F File Offset: 0x00037B6F
		internal PdfViewerPreferences(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x00039978 File Offset: 0x00037B78
		private PdfViewerPreferences(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06000EC4 RID: 3780 RVA: 0x00039981 File Offset: 0x00037B81
		// (set) Token: 0x06000EC5 RID: 3781 RVA: 0x00039993 File Offset: 0x00037B93
		public bool HideToolbar
		{
			get
			{
				return base.Elements.GetBoolean("/HideToolbar");
			}
			set
			{
				base.Elements.SetBoolean("/HideToolbar", value);
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06000EC6 RID: 3782 RVA: 0x000399A6 File Offset: 0x00037BA6
		// (set) Token: 0x06000EC7 RID: 3783 RVA: 0x000399B8 File Offset: 0x00037BB8
		public bool HideMenubar
		{
			get
			{
				return base.Elements.GetBoolean("/HideMenubar");
			}
			set
			{
				base.Elements.SetBoolean("/HideMenubar", value);
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06000EC8 RID: 3784 RVA: 0x000399CB File Offset: 0x00037BCB
		// (set) Token: 0x06000EC9 RID: 3785 RVA: 0x000399DD File Offset: 0x00037BDD
		public bool HideWindowUI
		{
			get
			{
				return base.Elements.GetBoolean("/HideWindowUI");
			}
			set
			{
				base.Elements.SetBoolean("/HideWindowUI", value);
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06000ECA RID: 3786 RVA: 0x000399F0 File Offset: 0x00037BF0
		// (set) Token: 0x06000ECB RID: 3787 RVA: 0x00039A02 File Offset: 0x00037C02
		public bool FitWindow
		{
			get
			{
				return base.Elements.GetBoolean("/FitWindow");
			}
			set
			{
				base.Elements.SetBoolean("/FitWindow", value);
			}
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06000ECC RID: 3788 RVA: 0x00039A15 File Offset: 0x00037C15
		// (set) Token: 0x06000ECD RID: 3789 RVA: 0x00039A27 File Offset: 0x00037C27
		public bool CenterWindow
		{
			get
			{
				return base.Elements.GetBoolean("/CenterWindow");
			}
			set
			{
				base.Elements.SetBoolean("/CenterWindow", value);
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06000ECE RID: 3790 RVA: 0x00039A3A File Offset: 0x00037C3A
		// (set) Token: 0x06000ECF RID: 3791 RVA: 0x00039A4C File Offset: 0x00037C4C
		public bool DisplayDocTitle
		{
			get
			{
				return base.Elements.GetBoolean("/DisplayDocTitle");
			}
			set
			{
				base.Elements.SetBoolean("/DisplayDocTitle", value);
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x00039A60 File Offset: 0x00037C60
		// (set) Token: 0x06000ED1 RID: 3793 RVA: 0x00039AB4 File Offset: 0x00037CB4
		public PdfReadingDirection? Direction
		{
			get
			{
				string name;
				if ((name = base.Elements.GetName("/Direction")) != null)
				{
					if (name == "L2R")
					{
						return new PdfReadingDirection?(PdfReadingDirection.LeftToRight);
					}
					if (name == "R2L")
					{
						return new PdfReadingDirection?(PdfReadingDirection.RightToLeft);
					}
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					base.Elements.Remove("/Direction");
					return;
				}
				PdfReadingDirection value2 = value.Value;
				if (value2 == PdfReadingDirection.RightToLeft)
				{
					base.Elements.SetName("/Direction", "R2L");
					return;
				}
				base.Elements.SetName("/Direction", "L2R");
			}
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06000ED2 RID: 3794 RVA: 0x00039B13 File Offset: 0x00037D13
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfViewerPreferences.Keys.Meta;
			}
		}

		// Token: 0x020001BE RID: 446
		internal sealed class Keys : KeysBase
		{
			// Token: 0x170004FA RID: 1274
			// (get) Token: 0x06000ED3 RID: 3795 RVA: 0x00039B1A File Offset: 0x00037D1A
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfViewerPreferences.Keys._meta) == null)
					{
						dictionaryMeta = (PdfViewerPreferences.Keys._meta = KeysBase.CreateMeta(typeof(PdfViewerPreferences.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040008FC RID: 2300
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string HideToolbar = "/HideToolbar";

			// Token: 0x040008FD RID: 2301
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string HideMenubar = "/HideMenubar";

			// Token: 0x040008FE RID: 2302
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string HideWindowUI = "/HideWindowUI";

			// Token: 0x040008FF RID: 2303
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string FitWindow = "/FitWindow";

			// Token: 0x04000900 RID: 2304
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string CenterWindow = "/CenterWindow";

			// Token: 0x04000901 RID: 2305
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string DisplayDocTitle = "/DisplayDocTitle";

			// Token: 0x04000902 RID: 2306
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string NonFullScreenPageMode = "/NonFullScreenPageMode";

			// Token: 0x04000903 RID: 2307
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string Direction = "/Direction";

			// Token: 0x04000904 RID: 2308
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string ViewArea = "/ViewArea";

			// Token: 0x04000905 RID: 2309
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string ViewClip = "/ViewClip";

			// Token: 0x04000906 RID: 2310
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string PrintArea = "/PrintArea";

			// Token: 0x04000907 RID: 2311
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string PrintClip = "/PrintClip";

			// Token: 0x04000908 RID: 2312
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string PrintScaling = "/PrintScaling";

			// Token: 0x04000909 RID: 2313
			private static DictionaryMeta _meta;
		}
	}
}
