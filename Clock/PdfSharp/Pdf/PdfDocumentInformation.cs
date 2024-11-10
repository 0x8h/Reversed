using System;

namespace PdfSharp.Pdf
{
	// Token: 0x0200019A RID: 410
	public sealed class PdfDocumentInformation : PdfDictionary
	{
		// Token: 0x06000D34 RID: 3380 RVA: 0x000350B7 File Offset: 0x000332B7
		public PdfDocumentInformation(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x000350C0 File Offset: 0x000332C0
		internal PdfDocumentInformation(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06000D36 RID: 3382 RVA: 0x000350C9 File Offset: 0x000332C9
		// (set) Token: 0x06000D37 RID: 3383 RVA: 0x000350DB File Offset: 0x000332DB
		public string Title
		{
			get
			{
				return base.Elements.GetString("/Title");
			}
			set
			{
				base.Elements.SetString("/Title", value);
			}
		}

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06000D38 RID: 3384 RVA: 0x000350EE File Offset: 0x000332EE
		// (set) Token: 0x06000D39 RID: 3385 RVA: 0x00035100 File Offset: 0x00033300
		public string Author
		{
			get
			{
				return base.Elements.GetString("/Author");
			}
			set
			{
				base.Elements.SetString("/Author", value);
			}
		}

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06000D3A RID: 3386 RVA: 0x00035113 File Offset: 0x00033313
		// (set) Token: 0x06000D3B RID: 3387 RVA: 0x00035125 File Offset: 0x00033325
		public string Subject
		{
			get
			{
				return base.Elements.GetString("/Subject");
			}
			set
			{
				base.Elements.SetString("/Subject", value);
			}
		}

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06000D3C RID: 3388 RVA: 0x00035138 File Offset: 0x00033338
		// (set) Token: 0x06000D3D RID: 3389 RVA: 0x0003514A File Offset: 0x0003334A
		public string Keywords
		{
			get
			{
				return base.Elements.GetString("/Keywords");
			}
			set
			{
				base.Elements.SetString("/Keywords", value);
			}
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06000D3E RID: 3390 RVA: 0x0003515D File Offset: 0x0003335D
		// (set) Token: 0x06000D3F RID: 3391 RVA: 0x0003516F File Offset: 0x0003336F
		public string Creator
		{
			get
			{
				return base.Elements.GetString("/Creator");
			}
			set
			{
				base.Elements.SetString("/Creator", value);
			}
		}

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06000D40 RID: 3392 RVA: 0x00035182 File Offset: 0x00033382
		public string Producer
		{
			get
			{
				return base.Elements.GetString("/Producer");
			}
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06000D41 RID: 3393 RVA: 0x00035194 File Offset: 0x00033394
		// (set) Token: 0x06000D42 RID: 3394 RVA: 0x000351AB File Offset: 0x000333AB
		public DateTime CreationDate
		{
			get
			{
				return base.Elements.GetDateTime("/CreationDate", DateTime.MinValue);
			}
			set
			{
				base.Elements.SetDateTime("/CreationDate", value);
			}
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06000D43 RID: 3395 RVA: 0x000351BE File Offset: 0x000333BE
		// (set) Token: 0x06000D44 RID: 3396 RVA: 0x000351D5 File Offset: 0x000333D5
		public DateTime ModificationDate
		{
			get
			{
				return base.Elements.GetDateTime("/ModDate", DateTime.MinValue);
			}
			set
			{
				base.Elements.SetDateTime("/ModDate", value);
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06000D45 RID: 3397 RVA: 0x000351E8 File Offset: 0x000333E8
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfDocumentInformation.Keys.Meta;
			}
		}

		// Token: 0x0200019B RID: 411
		internal sealed class Keys : KeysBase
		{
			// Token: 0x1700048F RID: 1167
			// (get) Token: 0x06000D46 RID: 3398 RVA: 0x000351EF File Offset: 0x000333EF
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfDocumentInformation.Keys._meta) == null)
					{
						dictionaryMeta = (PdfDocumentInformation.Keys._meta = KeysBase.CreateMeta(typeof(PdfDocumentInformation.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x04000867 RID: 2151
			[KeyInfo(KeyType.String | KeyType.Optional)]
			public const string Title = "/Title";

			// Token: 0x04000868 RID: 2152
			[KeyInfo(KeyType.String | KeyType.Optional)]
			public const string Author = "/Author";

			// Token: 0x04000869 RID: 2153
			[KeyInfo(KeyType.String | KeyType.Optional)]
			public const string Subject = "/Subject";

			// Token: 0x0400086A RID: 2154
			[KeyInfo(KeyType.String | KeyType.Optional)]
			public const string Keywords = "/Keywords";

			// Token: 0x0400086B RID: 2155
			[KeyInfo(KeyType.String | KeyType.Optional)]
			public const string Creator = "/Creator";

			// Token: 0x0400086C RID: 2156
			[KeyInfo(KeyType.String | KeyType.Optional)]
			public const string Producer = "/Producer";

			// Token: 0x0400086D RID: 2157
			[KeyInfo(KeyType.String | KeyType.Integer | KeyType.Optional)]
			public const string CreationDate = "/CreationDate";

			// Token: 0x0400086E RID: 2158
			[KeyInfo(KeyType.String | KeyType.Optional)]
			public const string ModDate = "/ModDate";

			// Token: 0x0400086F RID: 2159
			[KeyInfo("1.3", KeyType.Name | KeyType.Optional)]
			public const string Trapped = "/Trapped";

			// Token: 0x04000870 RID: 2160
			private static DictionaryMeta _meta;
		}
	}
}
