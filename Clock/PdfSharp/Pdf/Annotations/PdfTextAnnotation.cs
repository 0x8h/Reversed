using System;

namespace PdfSharp.Pdf.Annotations
{
	// Token: 0x0200013D RID: 317
	public sealed class PdfTextAnnotation : PdfAnnotation
	{
		// Token: 0x06000ACB RID: 2763 RVA: 0x0002AAF9 File Offset: 0x00028CF9
		public PdfTextAnnotation()
		{
			this.Initialize();
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x0002AB07 File Offset: 0x00028D07
		public PdfTextAnnotation(PdfDocument document)
			: base(document)
		{
			this.Initialize();
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x0002AB16 File Offset: 0x00028D16
		private void Initialize()
		{
			base.Elements.SetName("/Subtype", "/Text");
			this.Icon = PdfTextAnnotationIcon.Comment;
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06000ACE RID: 2766 RVA: 0x0002AB34 File Offset: 0x00028D34
		// (set) Token: 0x06000ACF RID: 2767 RVA: 0x0002AB46 File Offset: 0x00028D46
		public bool Open
		{
			get
			{
				return base.Elements.GetBoolean("/Open");
			}
			set
			{
				base.Elements.SetBoolean("/Open", value);
			}
		}

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x0002AB5C File Offset: 0x00028D5C
		// (set) Token: 0x06000AD1 RID: 2769 RVA: 0x0002ABBC File Offset: 0x00028DBC
		public PdfTextAnnotationIcon Icon
		{
			get
			{
				string text = base.Elements.GetName("/Name");
				if (text == "")
				{
					return PdfTextAnnotationIcon.NoIcon;
				}
				text = text.Substring(1);
				if (!Enum.IsDefined(typeof(PdfTextAnnotationIcon), text))
				{
					return PdfTextAnnotationIcon.NoIcon;
				}
				return (PdfTextAnnotationIcon)Enum.Parse(typeof(PdfTextAnnotationIcon), text, false);
			}
			set
			{
				if (Enum.IsDefined(typeof(PdfTextAnnotationIcon), value) && value != PdfTextAnnotationIcon.NoIcon)
				{
					base.Elements.SetName("/Name", "/" + value.ToString());
					return;
				}
				base.Elements.Remove("/Name");
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x0002AC1A File Offset: 0x00028E1A
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfTextAnnotation.Keys.Meta;
			}
		}

		// Token: 0x0200013E RID: 318
		internal new class Keys : PdfAnnotation.Keys
		{
			// Token: 0x17000404 RID: 1028
			// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x0002AC21 File Offset: 0x00028E21
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfTextAnnotation.Keys._meta) == null)
					{
						dictionaryMeta = (PdfTextAnnotation.Keys._meta = KeysBase.CreateMeta(typeof(PdfTextAnnotation.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x04000629 RID: 1577
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string Open = "/Open";

			// Token: 0x0400062A RID: 1578
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string Name = "/Name";

			// Token: 0x0400062B RID: 1579
			private static DictionaryMeta _meta;
		}
	}
}
