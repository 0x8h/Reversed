using System;
using System.Collections.Generic;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000D1 RID: 209
	public abstract class PdfButtonField : PdfAcroField
	{
		// Token: 0x060008B4 RID: 2228 RVA: 0x00020C7A File Offset: 0x0001EE7A
		protected PdfButtonField(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00020C83 File Offset: 0x0001EE83
		protected PdfButtonField(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00020C8C File Offset: 0x0001EE8C
		protected string GetNonOffValue()
		{
			PdfDictionary pdfDictionary = base.Elements["/AP"] as PdfDictionary;
			if (pdfDictionary != null)
			{
				PdfDictionary pdfDictionary2 = pdfDictionary.Elements["/N"] as PdfDictionary;
				if (pdfDictionary2 != null)
				{
					foreach (string text in pdfDictionary2.Elements.Keys)
					{
						if (text != "/Off")
						{
							return text;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00020D24 File Offset: 0x0001EF24
		internal override void GetDescendantNames(ref List<string> names, string partialName)
		{
			string text = base.Elements.GetString("/T");
			if (text == "")
			{
				text = "???";
			}
			if (text.Length > 0)
			{
				if (!string.IsNullOrEmpty(partialName))
				{
					names.Add(partialName + "." + text);
					return;
				}
				names.Add(text);
			}
		}

		// Token: 0x020000D2 RID: 210
		public new class Keys : PdfAcroField.Keys
		{
		}
	}
}
