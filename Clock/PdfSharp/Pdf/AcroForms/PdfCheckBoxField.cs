using System;
using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000D3 RID: 211
	public sealed class PdfCheckBoxField : PdfButtonField
	{
		// Token: 0x060008B9 RID: 2233 RVA: 0x00020D8A File Offset: 0x0001EF8A
		internal PdfCheckBoxField(PdfDocument document)
			: base(document)
		{
			this._document = document;
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00020DB0 File Offset: 0x0001EFB0
		internal PdfCheckBoxField(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x060008BB RID: 2235 RVA: 0x00020DD0 File Offset: 0x0001EFD0
		// (set) Token: 0x060008BC RID: 2236 RVA: 0x00020E7C File Offset: 0x0001F07C
		public bool Checked
		{
			get
			{
				if (!base.HasKids)
				{
					string @string = base.Elements.GetString("/V");
					return @string.Length != 0 && @string != "/Off";
				}
				if (base.Fields.Elements.Items.Length == 2)
				{
					string string2 = ((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements.GetString("/V");
					return string2.Length != 0 && string2 != "/Off" && string2 != "/Nein";
				}
				return false;
			}
			set
			{
				if (!base.HasKids)
				{
					string text = (value ? base.GetNonOffValue() : "/Off");
					base.Elements.SetName("/V", text);
					base.Elements.SetName("/AS", text);
					return;
				}
				if (base.Fields.Elements.Items.Length == 2)
				{
					if (value)
					{
						string text2 = "";
						PdfDictionary pdfDictionary = ((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements["/AP"] as PdfDictionary;
						if (pdfDictionary != null)
						{
							PdfDictionary pdfDictionary2 = pdfDictionary.Elements["/N"] as PdfDictionary;
							if (pdfDictionary2 != null)
							{
								foreach (string text3 in pdfDictionary2.Elements.Keys)
								{
									if (text3 != "/Off")
									{
										text2 = text3;
										break;
									}
								}
							}
						}
						if (text2.Length != 0)
						{
							((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements.SetName("/V", text2);
							((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements.SetName("/AS", text2);
						}
						pdfDictionary = ((PdfDictionary)((PdfReference)base.Fields.Elements.Items[1]).Value).Elements["/AP"] as PdfDictionary;
						if (pdfDictionary != null)
						{
							PdfDictionary pdfDictionary3 = pdfDictionary.Elements["/N"] as PdfDictionary;
							if (pdfDictionary3 != null)
							{
								foreach (string text4 in pdfDictionary3.Elements.Keys)
								{
									if (text4 == "/Off")
									{
										text2 = text4;
										break;
									}
								}
							}
						}
						if (text2.Length != 0)
						{
							((PdfDictionary)((PdfReference)base.Fields.Elements.Items[1]).Value).Elements.SetName("/V", text2);
							((PdfDictionary)((PdfReference)base.Fields.Elements.Items[1]).Value).Elements.SetName("/AS", text2);
							return;
						}
					}
					else
					{
						string text5 = "";
						PdfDictionary pdfDictionary4 = ((PdfDictionary)((PdfReference)base.Fields.Elements.Items[1]).Value).Elements["/AP"] as PdfDictionary;
						if (pdfDictionary4 != null)
						{
							PdfDictionary pdfDictionary5 = pdfDictionary4.Elements["/N"] as PdfDictionary;
							if (pdfDictionary5 != null)
							{
								foreach (string text6 in pdfDictionary5.Elements.Keys)
								{
									if (text6 != "/Off")
									{
										text5 = text6;
										break;
									}
								}
							}
						}
						if (text5.Length != 0)
						{
							((PdfDictionary)((PdfReference)base.Fields.Elements.Items[1]).Value).Elements.SetName("/V", text5);
							((PdfDictionary)((PdfReference)base.Fields.Elements.Items[1]).Value).Elements.SetName("/AS", text5);
						}
						pdfDictionary4 = ((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements["/AP"] as PdfDictionary;
						if (pdfDictionary4 != null)
						{
							PdfDictionary pdfDictionary6 = pdfDictionary4.Elements["/N"] as PdfDictionary;
							if (pdfDictionary6 != null)
							{
								foreach (string text7 in pdfDictionary6.Elements.Keys)
								{
									if (text7 == "/Off")
									{
										text5 = text7;
										break;
									}
								}
							}
						}
						if (text5.Length != 0)
						{
							((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements.SetName("/V", text5);
							((PdfDictionary)((PdfReference)base.Fields.Elements.Items[0]).Value).Elements.SetName("/AS", text5);
						}
					}
				}
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x060008BD RID: 2237 RVA: 0x0002134C File Offset: 0x0001F54C
		// (set) Token: 0x060008BE RID: 2238 RVA: 0x00021354 File Offset: 0x0001F554
		public string CheckedName
		{
			get
			{
				return this._checkedName;
			}
			set
			{
				this._checkedName = value;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x060008BF RID: 2239 RVA: 0x0002135D File Offset: 0x0001F55D
		// (set) Token: 0x060008C0 RID: 2240 RVA: 0x00021365 File Offset: 0x0001F565
		public string UncheckedName
		{
			get
			{
				return this._uncheckedName;
			}
			set
			{
				this._uncheckedName = value;
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x060008C1 RID: 2241 RVA: 0x0002136E File Offset: 0x0001F56E
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfCheckBoxField.Keys.Meta;
			}
		}

		// Token: 0x0400047D RID: 1149
		private string _checkedName = "/Yes";

		// Token: 0x0400047E RID: 1150
		private string _uncheckedName = "/Off";

		// Token: 0x020000D4 RID: 212
		public new class Keys : PdfButtonField.Keys
		{
			// Token: 0x17000356 RID: 854
			// (get) Token: 0x060008C2 RID: 2242 RVA: 0x00021375 File Offset: 0x0001F575
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfCheckBoxField.Keys._meta) == null)
					{
						dictionaryMeta = (PdfCheckBoxField.Keys._meta = KeysBase.CreateMeta(typeof(PdfCheckBoxField.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x0400047F RID: 1151
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string Opt = "/Opt";

			// Token: 0x04000480 RID: 1152
			private static DictionaryMeta _meta;
		}
	}
}
