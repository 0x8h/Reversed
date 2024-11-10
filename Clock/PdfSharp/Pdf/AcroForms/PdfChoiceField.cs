using System;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000D5 RID: 213
	public abstract class PdfChoiceField : PdfAcroField
	{
		// Token: 0x060008C4 RID: 2244 RVA: 0x0002139D File Offset: 0x0001F59D
		protected PdfChoiceField(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x000213A6 File Offset: 0x0001F5A6
		protected PdfChoiceField(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x000213B0 File Offset: 0x0001F5B0
		protected int IndexInOptArray(string value)
		{
			PdfArray array = base.Elements.GetArray("/Opt");
			if (array != null)
			{
				int count = array.Elements.Count;
				for (int i = 0; i < count; i++)
				{
					PdfItem pdfItem = array.Elements[i];
					if (pdfItem is PdfString)
					{
						if (pdfItem.ToString() == value)
						{
							return i;
						}
					}
					else if (pdfItem is PdfArray)
					{
						PdfArray pdfArray = (PdfArray)pdfItem;
						if (pdfArray.Elements.Count != 0 && pdfArray.Elements[0].ToString() == value)
						{
							return i;
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x0002144C File Offset: 0x0001F64C
		protected string ValueInOptArray(int index)
		{
			PdfArray array = base.Elements.GetArray("/Opt");
			if (array != null)
			{
				int count = array.Elements.Count;
				if (index < 0 || index >= count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				PdfItem pdfItem = array.Elements[index];
				if (pdfItem is PdfString)
				{
					return pdfItem.ToString();
				}
				if (pdfItem is PdfArray)
				{
					PdfArray pdfArray = (PdfArray)pdfItem;
					if (pdfArray.Elements.Count != 0)
					{
						return pdfArray.Elements[0].ToString();
					}
				}
			}
			return "";
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x060008C8 RID: 2248 RVA: 0x000214DB File Offset: 0x0001F6DB
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfChoiceField.Keys.Meta;
			}
		}

		// Token: 0x020000D6 RID: 214
		public new class Keys : PdfAcroField.Keys
		{
			// Token: 0x17000358 RID: 856
			// (get) Token: 0x060008C9 RID: 2249 RVA: 0x000214E2 File Offset: 0x0001F6E2
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfChoiceField.Keys._meta) == null)
					{
						dictionaryMeta = (PdfChoiceField.Keys._meta = KeysBase.CreateMeta(typeof(PdfChoiceField.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x04000481 RID: 1153
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Opt = "/Opt";

			// Token: 0x04000482 RID: 1154
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string TI = "/TI";

			// Token: 0x04000483 RID: 1155
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string I = "/I";

			// Token: 0x04000484 RID: 1156
			private static DictionaryMeta _meta;
		}
	}
}
