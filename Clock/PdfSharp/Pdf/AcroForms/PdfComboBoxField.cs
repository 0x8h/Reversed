using System;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000D7 RID: 215
	public sealed class PdfComboBoxField : PdfChoiceField
	{
		// Token: 0x060008CB RID: 2251 RVA: 0x0002150A File Offset: 0x0001F70A
		internal PdfComboBoxField(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00021513 File Offset: 0x0001F713
		internal PdfComboBoxField(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x060008CD RID: 2253 RVA: 0x0002151C File Offset: 0x0001F71C
		// (set) Token: 0x060008CE RID: 2254 RVA: 0x00021544 File Offset: 0x0001F744
		public int SelectedIndex
		{
			get
			{
				string @string = base.Elements.GetString("/V");
				return base.IndexInOptArray(@string);
			}
			set
			{
				if (value != -1)
				{
					string text = base.ValueInOptArray(value);
					base.Elements.SetString("/V", text);
					base.Elements.SetInteger("/I", value);
				}
			}
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x060008CF RID: 2255 RVA: 0x0002157F File Offset: 0x0001F77F
		// (set) Token: 0x060008D0 RID: 2256 RVA: 0x00021594 File Offset: 0x0001F794
		public override PdfItem Value
		{
			get
			{
				return base.Elements["/V"];
			}
			set
			{
				if (base.ReadOnly)
				{
					throw new InvalidOperationException("The field is read only.");
				}
				if (value is PdfString || value is PdfName)
				{
					base.Elements["/V"] = value;
					this.SelectedIndex = this.SelectedIndex;
					if (this.SelectedIndex == -1)
					{
						try
						{
							((PdfArray)((PdfItem[])base.Elements.Values)[2]).Elements.Add(this.Value);
							this.SelectedIndex = this.SelectedIndex;
							return;
						}
						catch
						{
							return;
						}
						goto IL_81;
					}
					return;
				}
				IL_81:
				throw new NotImplementedException("Values other than string cannot be set.");
			}
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x060008D1 RID: 2257 RVA: 0x00021640 File Offset: 0x0001F840
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfComboBoxField.Keys.Meta;
			}
		}

		// Token: 0x020000D8 RID: 216
		public new class Keys : PdfAcroField.Keys
		{
			// Token: 0x1700035C RID: 860
			// (get) Token: 0x060008D2 RID: 2258 RVA: 0x00021647 File Offset: 0x0001F847
			internal static DictionaryMeta Meta
			{
				get
				{
					if (PdfComboBoxField.Keys._meta == null)
					{
						PdfComboBoxField.Keys._meta = KeysBase.CreateMeta(typeof(PdfComboBoxField.Keys));
					}
					return PdfComboBoxField.Keys._meta;
				}
			}

			// Token: 0x04000485 RID: 1157
			private static DictionaryMeta _meta;
		}
	}
}
