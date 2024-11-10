using System;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000DB RID: 219
	public sealed class PdfListBoxField : PdfChoiceField
	{
		// Token: 0x060008D9 RID: 2265 RVA: 0x000216B2 File Offset: 0x0001F8B2
		internal PdfListBoxField(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x000216BB File Offset: 0x0001F8BB
		internal PdfListBoxField(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x060008DB RID: 2267 RVA: 0x000216C4 File Offset: 0x0001F8C4
		// (set) Token: 0x060008DC RID: 2268 RVA: 0x000216EC File Offset: 0x0001F8EC
		public int SelectedIndex
		{
			get
			{
				string @string = base.Elements.GetString("/V");
				return base.IndexInOptArray(@string);
			}
			set
			{
				string text = base.ValueInOptArray(value);
				base.Elements.SetString("/V", text);
			}
		}

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x060008DD RID: 2269 RVA: 0x00021712 File Offset: 0x0001F912
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfListBoxField.Keys.Meta;
			}
		}

		// Token: 0x020000DC RID: 220
		public new class Keys : PdfAcroField.Keys
		{
			// Token: 0x17000361 RID: 865
			// (get) Token: 0x060008DE RID: 2270 RVA: 0x00021719 File Offset: 0x0001F919
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfListBoxField.Keys._meta) == null)
					{
						dictionaryMeta = (PdfListBoxField.Keys._meta = KeysBase.CreateMeta(typeof(PdfListBoxField.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x04000487 RID: 1159
			private static DictionaryMeta _meta;
		}
	}
}
