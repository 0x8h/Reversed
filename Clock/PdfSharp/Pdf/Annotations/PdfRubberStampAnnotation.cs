using System;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Annotations
{
	// Token: 0x0200013B RID: 315
	public sealed class PdfRubberStampAnnotation : PdfAnnotation
	{
		// Token: 0x06000AC3 RID: 2755 RVA: 0x0002A9CA File Offset: 0x00028BCA
		public PdfRubberStampAnnotation()
		{
			this.Initialize();
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x0002A9D8 File Offset: 0x00028BD8
		public PdfRubberStampAnnotation(PdfDocument document)
			: base(document)
		{
			this.Initialize();
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x0002A9E7 File Offset: 0x00028BE7
		private void Initialize()
		{
			base.Elements.SetName("/Subtype", "/Stamp");
			base.Color = XColors.Yellow;
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x0002AA0C File Offset: 0x00028C0C
		// (set) Token: 0x06000AC7 RID: 2759 RVA: 0x0002AA6C File Offset: 0x00028C6C
		public PdfRubberStampAnnotationIcon Icon
		{
			get
			{
				string text = base.Elements.GetName("/Name");
				if (text == "")
				{
					return PdfRubberStampAnnotationIcon.NoIcon;
				}
				text = text.Substring(1);
				if (!Enum.IsDefined(typeof(PdfRubberStampAnnotationIcon), text))
				{
					return PdfRubberStampAnnotationIcon.NoIcon;
				}
				return (PdfRubberStampAnnotationIcon)Enum.Parse(typeof(PdfRubberStampAnnotationIcon), text, false);
			}
			set
			{
				if (Enum.IsDefined(typeof(PdfRubberStampAnnotationIcon), value) && value != PdfRubberStampAnnotationIcon.NoIcon)
				{
					base.Elements.SetName("/Name", "/" + value.ToString());
					return;
				}
				base.Elements.Remove("/Name");
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000AC8 RID: 2760 RVA: 0x0002AACA File Offset: 0x00028CCA
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfRubberStampAnnotation.Keys.Meta;
			}
		}

		// Token: 0x0200013C RID: 316
		internal new class Keys : PdfAnnotation.Keys
		{
			// Token: 0x17000400 RID: 1024
			// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x0002AAD1 File Offset: 0x00028CD1
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfRubberStampAnnotation.Keys._meta) == null)
					{
						dictionaryMeta = (PdfRubberStampAnnotation.Keys._meta = KeysBase.CreateMeta(typeof(PdfRubberStampAnnotation.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x04000627 RID: 1575
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string Name = "/Name";

			// Token: 0x04000628 RID: 1576
			private static DictionaryMeta _meta;
		}
	}
}
