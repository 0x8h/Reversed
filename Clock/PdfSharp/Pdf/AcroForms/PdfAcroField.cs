using System;
using System.Collections.Generic;
using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000CA RID: 202
	public abstract class PdfAcroField : PdfDictionary
	{
		// Token: 0x06000865 RID: 2149 RVA: 0x0001FEAC File Offset: 0x0001E0AC
		internal PdfAcroField(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x0001FEB5 File Offset: 0x0001E0B5
		protected PdfAcroField(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000867 RID: 2151 RVA: 0x0001FEC0 File Offset: 0x0001E0C0
		public string Name
		{
			get
			{
				return base.Elements.GetString("/T");
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x0001FEDF File Offset: 0x0001E0DF
		public PdfAcroFieldFlags Flags
		{
			get
			{
				return (PdfAcroFieldFlags)base.Elements.GetInteger("/Ff");
			}
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000869 RID: 2153 RVA: 0x0001FEF1 File Offset: 0x0001E0F1
		// (set) Token: 0x0600086A RID: 2154 RVA: 0x0001FF03 File Offset: 0x0001E103
		internal PdfAcroFieldFlags SetFlags
		{
			get
			{
				return (PdfAcroFieldFlags)base.Elements.GetInteger("/Ff");
			}
			set
			{
				base.Elements.SetInteger("/Ff", (int)value);
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x0600086B RID: 2155 RVA: 0x0001FF16 File Offset: 0x0001E116
		// (set) Token: 0x0600086C RID: 2156 RVA: 0x0001FF28 File Offset: 0x0001E128
		public virtual PdfItem Value
		{
			get
			{
				return base.Elements["/V"];
			}
			set
			{
				if (this.ReadOnly)
				{
					throw new InvalidOperationException("The field is read only.");
				}
				if (value is PdfString || value is PdfName)
				{
					base.Elements["/V"] = value;
					return;
				}
				throw new NotImplementedException("Values other than string cannot be set.");
			}
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x0600086D RID: 2157 RVA: 0x0001FF74 File Offset: 0x0001E174
		// (set) Token: 0x0600086E RID: 2158 RVA: 0x0001FF84 File Offset: 0x0001E184
		public bool ReadOnly
		{
			get
			{
				return (this.Flags & PdfAcroFieldFlags.ReadOnly) != (PdfAcroFieldFlags)0;
			}
			set
			{
				if (value)
				{
					this.SetFlags |= PdfAcroFieldFlags.ReadOnly;
					return;
				}
				this.SetFlags &= ~PdfAcroFieldFlags.ReadOnly;
			}
		}

		// Token: 0x1700033E RID: 830
		public PdfAcroField this[string name]
		{
			get
			{
				return this.GetValue(name);
			}
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x0001FFB0 File Offset: 0x0001E1B0
		protected virtual PdfAcroField GetValue(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return this;
			}
			if (this.HasKids)
			{
				return this.Fields.GetValue(name);
			}
			return null;
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000871 RID: 2161 RVA: 0x0001FFD4 File Offset: 0x0001E1D4
		public bool HasKids
		{
			get
			{
				PdfItem pdfItem = base.Elements["/Kids"];
				return pdfItem != null && pdfItem is PdfArray && ((PdfArray)pdfItem).Elements.Count > 0;
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x00020014 File Offset: 0x0001E214
		[Obsolete("Use GetDescendantNames")]
		public string[] DescendantNames
		{
			get
			{
				return this.GetDescendantNames();
			}
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x0002001C File Offset: 0x0001E21C
		public string[] GetDescendantNames()
		{
			List<string> list = new List<string>();
			if (this.HasKids)
			{
				PdfAcroField.PdfAcroFieldCollection fields = this.Fields;
				fields.GetDescendantNames(ref list, null);
			}
			List<string> list2 = new List<string>();
			foreach (string text in list)
			{
				list2.Add(text);
			}
			return list2.ToArray();
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00020098 File Offset: 0x0001E298
		public string[] GetAppearanceNames()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			PdfDictionary pdfDictionary = base.Elements["/AP"] as PdfDictionary;
			if (pdfDictionary != null)
			{
				PdfAcroField.AppDict(pdfDictionary, dictionary);
				if (this.HasKids)
				{
					PdfItem[] items = this.Fields.Elements.Items;
					foreach (PdfItem pdfItem in items)
					{
						if (pdfItem is PdfReference)
						{
							PdfDictionary pdfDictionary2 = ((PdfReference)pdfItem).Value as PdfDictionary;
							if (pdfDictionary2 != null)
							{
								PdfAcroField.AppDict(pdfDictionary2, dictionary);
							}
						}
					}
				}
			}
			string[] array2 = new string[dictionary.Count];
			dictionary.Keys.CopyTo(array2, 0);
			return array2;
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x00020144 File Offset: 0x0001E344
		private static void AppDict(PdfDictionary dict, Dictionary<string, object> names)
		{
			PdfDictionary pdfDictionary;
			if ((pdfDictionary = dict.Elements["/D"] as PdfDictionary) != null)
			{
				PdfAcroField.AppDict2(pdfDictionary, names);
			}
			if ((pdfDictionary = dict.Elements["/N"] as PdfDictionary) != null)
			{
				PdfAcroField.AppDict2(pdfDictionary, names);
			}
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00020194 File Offset: 0x0001E394
		private static void AppDict2(PdfDictionary dict, Dictionary<string, object> names)
		{
			foreach (string text in dict.Elements.Keys)
			{
				if (!names.ContainsKey(text))
				{
					names.Add(text, null);
				}
			}
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x000201F0 File Offset: 0x0001E3F0
		internal virtual void GetDescendantNames(ref List<string> names, string partialName)
		{
			if (this.HasKids)
			{
				PdfAcroField.PdfAcroFieldCollection fields = this.Fields;
				string @string = base.Elements.GetString("/T");
				if (@string.Length > 0)
				{
					if (!string.IsNullOrEmpty(partialName))
					{
						partialName = partialName + "." + @string;
					}
					else
					{
						partialName = @string;
					}
					fields.GetDescendantNames(ref names, partialName);
					return;
				}
			}
			else
			{
				string string2 = base.Elements.GetString("/T");
				if (string2.Length > 0)
				{
					if (!string.IsNullOrEmpty(partialName))
					{
						names.Add(partialName + "." + string2);
						return;
					}
					names.Add(string2);
				}
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000878 RID: 2168 RVA: 0x00020288 File Offset: 0x0001E488
		public PdfAcroField.PdfAcroFieldCollection Fields
		{
			get
			{
				if (this._fields == null)
				{
					object value = base.Elements.GetValue("/Kids", VCF.CreateIndirect);
					this._fields = (PdfAcroField.PdfAcroFieldCollection)value;
				}
				return this._fields;
			}
		}

		// Token: 0x04000463 RID: 1123
		private PdfAcroField.PdfAcroFieldCollection _fields;

		// Token: 0x020000CD RID: 205
		public sealed class PdfAcroFieldCollection : PdfArray
		{
			// Token: 0x060008A5 RID: 2213 RVA: 0x0002099E File Offset: 0x0001EB9E
			private PdfAcroFieldCollection(PdfArray array)
				: base(array)
			{
			}

			// Token: 0x1700034B RID: 843
			// (get) Token: 0x060008A6 RID: 2214 RVA: 0x000209A8 File Offset: 0x0001EBA8
			public string[] Names
			{
				get
				{
					int count = base.Elements.Count;
					string[] array = new string[count];
					for (int i = 0; i < count; i++)
					{
						array[i] = ((PdfDictionary)((PdfReference)base.Elements[i]).Value).Elements.GetString("/T");
					}
					return array;
				}
			}

			// Token: 0x1700034C RID: 844
			// (get) Token: 0x060008A7 RID: 2215 RVA: 0x00020A04 File Offset: 0x0001EC04
			public string[] DescendantNames
			{
				get
				{
					List<string> list = new List<string>();
					this.GetDescendantNames(ref list, null);
					return list.ToArray();
				}
			}

			// Token: 0x060008A8 RID: 2216 RVA: 0x00020A28 File Offset: 0x0001EC28
			internal void GetDescendantNames(ref List<string> names, string partialName)
			{
				int count = base.Elements.Count;
				for (int i = 0; i < count; i++)
				{
					PdfAcroField pdfAcroField = this[i];
					if (pdfAcroField != null)
					{
						pdfAcroField.GetDescendantNames(ref names, partialName);
					}
				}
			}

			// Token: 0x1700034D RID: 845
			public PdfAcroField this[int index]
			{
				get
				{
					PdfItem pdfItem = base.Elements[index];
					PdfDictionary pdfDictionary = ((PdfReference)pdfItem).Value as PdfDictionary;
					PdfAcroField pdfAcroField = pdfDictionary as PdfAcroField;
					if (pdfAcroField == null && pdfDictionary != null)
					{
						pdfAcroField = this.CreateAcroField(pdfDictionary);
					}
					return pdfAcroField;
				}
			}

			// Token: 0x1700034E RID: 846
			public PdfAcroField this[string name]
			{
				get
				{
					return this.GetValue(name);
				}
			}

			// Token: 0x060008AB RID: 2219 RVA: 0x00020AAC File Offset: 0x0001ECAC
			internal PdfAcroField GetValue(string name)
			{
				if (string.IsNullOrEmpty(name))
				{
					return null;
				}
				int num = name.IndexOf('.');
				string text = ((num == -1) ? name : name.Substring(0, num));
				string text2 = ((num == -1) ? "" : name.Substring(num + 1));
				int count = base.Elements.Count;
				for (int i = 0; i < count; i++)
				{
					PdfAcroField pdfAcroField = this[i];
					if (pdfAcroField.Name == text)
					{
						return pdfAcroField.GetValue(text2);
					}
				}
				return null;
			}

			// Token: 0x060008AC RID: 2220 RVA: 0x00020B30 File Offset: 0x0001ED30
			private PdfAcroField CreateAcroField(PdfDictionary dict)
			{
				string name = dict.Elements.GetName("/FT");
				PdfAcroFieldFlags integer = (PdfAcroFieldFlags)dict.Elements.GetInteger("/Ff");
				string text;
				if ((text = name) != null)
				{
					if (!(text == "/Btn"))
					{
						if (text == "/Tx")
						{
							return new PdfTextField(dict);
						}
						if (!(text == "/Ch"))
						{
							if (text == "/Sig")
							{
								return new PdfSignatureField(dict);
							}
						}
						else
						{
							if ((integer & PdfAcroFieldFlags.Combo) != (PdfAcroFieldFlags)0)
							{
								return new PdfComboBoxField(dict);
							}
							return new PdfListBoxField(dict);
						}
					}
					else
					{
						if ((integer & PdfAcroFieldFlags.Pushbutton) != (PdfAcroFieldFlags)0)
						{
							return new PdfPushButtonField(dict);
						}
						if ((integer & PdfAcroFieldFlags.Radio) != (PdfAcroFieldFlags)0)
						{
							return new PdfRadioButtonField(dict);
						}
						return new PdfCheckBoxField(dict);
					}
				}
				return new PdfGenericField(dict);
			}
		}

		// Token: 0x020000CE RID: 206
		public class Keys : KeysBase
		{
			// Token: 0x04000467 RID: 1127
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string FT = "/FT";

			// Token: 0x04000468 RID: 1128
			[KeyInfo(KeyType.Dictionary)]
			public const string Parent = "/Parent";

			// Token: 0x04000469 RID: 1129
			[KeyInfo(KeyType.Array | KeyType.Optional, typeof(PdfAcroField.PdfAcroFieldCollection))]
			public const string Kids = "/Kids";

			// Token: 0x0400046A RID: 1130
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string T = "/T";

			// Token: 0x0400046B RID: 1131
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string TU = "/TU";

			// Token: 0x0400046C RID: 1132
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string TM = "/TM";

			// Token: 0x0400046D RID: 1133
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string Ff = "/Ff";

			// Token: 0x0400046E RID: 1134
			[KeyInfo(KeyType.Various | KeyType.Optional)]
			public const string V = "/V";

			// Token: 0x0400046F RID: 1135
			[KeyInfo(KeyType.Various | KeyType.Optional)]
			public const string DV = "/DV";

			// Token: 0x04000470 RID: 1136
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string AA = "/AA";

			// Token: 0x04000471 RID: 1137
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required)]
			public const string DR = "/DR";

			// Token: 0x04000472 RID: 1138
			[KeyInfo(KeyType.String | KeyType.Required)]
			public const string DA = "/DA";

			// Token: 0x04000473 RID: 1139
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string Q = "/Q";
		}
	}
}
