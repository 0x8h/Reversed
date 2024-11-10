using System;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000CF RID: 207
	public sealed class PdfAcroForm : PdfDictionary
	{
		// Token: 0x060008AE RID: 2222 RVA: 0x00020BF7 File Offset: 0x0001EDF7
		internal PdfAcroForm(PdfDocument document)
			: base(document)
		{
			this._document = document;
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00020C07 File Offset: 0x0001EE07
		internal PdfAcroForm(PdfDictionary dictionary)
			: base(dictionary)
		{
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x00020C10 File Offset: 0x0001EE10
		public PdfAcroField.PdfAcroFieldCollection Fields
		{
			get
			{
				if (this._fields == null)
				{
					object value = base.Elements.GetValue("/Fields", VCF.CreateIndirect);
					this._fields = (PdfAcroField.PdfAcroFieldCollection)value;
				}
				return this._fields;
			}
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x060008B1 RID: 2225 RVA: 0x00020C49 File Offset: 0x0001EE49
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfAcroForm.Keys.Meta;
			}
		}

		// Token: 0x04000474 RID: 1140
		private PdfAcroField.PdfAcroFieldCollection _fields;

		// Token: 0x020000D0 RID: 208
		public sealed class Keys : KeysBase
		{
			// Token: 0x17000351 RID: 849
			// (get) Token: 0x060008B2 RID: 2226 RVA: 0x00020C50 File Offset: 0x0001EE50
			internal static DictionaryMeta Meta
			{
				get
				{
					if (PdfAcroForm.Keys.s_meta == null)
					{
						PdfAcroForm.Keys.s_meta = KeysBase.CreateMeta(typeof(PdfAcroForm.Keys));
					}
					return PdfAcroForm.Keys.s_meta;
				}
			}

			// Token: 0x04000475 RID: 1141
			[KeyInfo(KeyType.Array | KeyType.Required, typeof(PdfAcroField.PdfAcroFieldCollection))]
			public const string Fields = "/Fields";

			// Token: 0x04000476 RID: 1142
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string NeedAppearances = "/NeedAppearances";

			// Token: 0x04000477 RID: 1143
			[KeyInfo("1.3", KeyType.Integer | KeyType.Optional)]
			public const string SigFlags = "/SigFlags";

			// Token: 0x04000478 RID: 1144
			[KeyInfo(KeyType.Array)]
			public const string CO = "/CO";

			// Token: 0x04000479 RID: 1145
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string DR = "/DR";

			// Token: 0x0400047A RID: 1146
			[KeyInfo(KeyType.String | KeyType.Optional)]
			public const string DA = "/DA";

			// Token: 0x0400047B RID: 1147
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string Q = "/Q";

			// Token: 0x0400047C RID: 1148
			private static DictionaryMeta s_meta;
		}
	}
}
