using System;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000DF RID: 223
	public sealed class PdfRadioButtonField : PdfButtonField
	{
		// Token: 0x060008E5 RID: 2277 RVA: 0x00021789 File Offset: 0x0001F989
		internal PdfRadioButtonField(PdfDocument document)
			: base(document)
		{
			this._document = document;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00021799 File Offset: 0x0001F999
		internal PdfRadioButtonField(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x060008E7 RID: 2279 RVA: 0x000217A4 File Offset: 0x0001F9A4
		// (set) Token: 0x060008E8 RID: 2280 RVA: 0x000217CC File Offset: 0x0001F9CC
		public int SelectedIndex
		{
			get
			{
				string @string = base.Elements.GetString("/V");
				return this.IndexInOptStrings(@string);
			}
			set
			{
				PdfArray pdfArray = base.Elements["/Opt"] as PdfArray;
				if (pdfArray == null)
				{
					pdfArray = base.Elements["/Kids"] as PdfArray;
				}
				if (pdfArray != null)
				{
					int count = pdfArray.Elements.Count;
					if (value < 0 || value >= count)
					{
						throw new ArgumentOutOfRangeException("value");
					}
					base.Elements.SetName("/V", pdfArray.Elements[value].ToString());
				}
			}
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0002184C File Offset: 0x0001FA4C
		private int IndexInOptStrings(string value)
		{
			PdfArray pdfArray = base.Elements["/Opt"] as PdfArray;
			if (pdfArray != null)
			{
				int count = pdfArray.Elements.Count;
				for (int i = 0; i < count; i++)
				{
					PdfItem pdfItem = pdfArray.Elements[i];
					if (pdfItem is PdfString && pdfItem.ToString() == value)
					{
						return i;
					}
				}
			}
			return -1;
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x060008EA RID: 2282 RVA: 0x000218B0 File Offset: 0x0001FAB0
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfRadioButtonField.Keys.Meta;
			}
		}

		// Token: 0x020000E0 RID: 224
		public new class Keys : PdfButtonField.Keys
		{
			// Token: 0x17000366 RID: 870
			// (get) Token: 0x060008EB RID: 2283 RVA: 0x000218B7 File Offset: 0x0001FAB7
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfRadioButtonField.Keys._meta) == null)
					{
						dictionaryMeta = (PdfRadioButtonField.Keys._meta = KeysBase.CreateMeta(typeof(PdfRadioButtonField.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x04000489 RID: 1161
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Opt = "/Opt";

			// Token: 0x0400048A RID: 1162
			private static DictionaryMeta _meta;
		}
	}
}
