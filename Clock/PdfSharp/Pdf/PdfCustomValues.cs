using System;

namespace PdfSharp.Pdf
{
	// Token: 0x02000195 RID: 405
	public class PdfCustomValues : PdfDictionary
	{
		// Token: 0x06000CE0 RID: 3296 RVA: 0x00034384 File Offset: 0x00032584
		internal PdfCustomValues()
		{
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x0003438C File Offset: 0x0003258C
		internal PdfCustomValues(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x00034395 File Offset: 0x00032595
		internal PdfCustomValues(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x17000461 RID: 1121
		// (set) Token: 0x06000CE3 RID: 3299 RVA: 0x0003439E File Offset: 0x0003259E
		public PdfCustomValueCompressionMode CompressionMode
		{
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x000343A5 File Offset: 0x000325A5
		public bool Contains(string key)
		{
			return base.Elements.ContainsKey(key);
		}

		// Token: 0x17000462 RID: 1122
		public PdfCustomValue this[string key]
		{
			get
			{
				PdfDictionary dictionary = base.Elements.GetDictionary(key);
				if (dictionary == null)
				{
					return null;
				}
				PdfCustomValue pdfCustomValue = dictionary as PdfCustomValue;
				if (pdfCustomValue == null)
				{
					pdfCustomValue = new PdfCustomValue(dictionary);
				}
				return pdfCustomValue;
			}
			set
			{
				if (value == null)
				{
					base.Elements.Remove(key);
					return;
				}
				this.Owner.Internals.AddObject(value);
				base.Elements.SetReference(key, value);
			}
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x00034418 File Offset: 0x00032618
		public static void ClearAllCustomValues(PdfDocument document)
		{
			document.CustomValues = null;
			foreach (PdfPage pdfPage in document.Pages)
			{
				pdfPage.CustomValues = null;
			}
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x0003446C File Offset: 0x0003266C
		internal static PdfCustomValues Get(PdfDictionary.DictionaryElements elem)
		{
			string customValueKey = elem.Owner.Owner.Internals.CustomValueKey;
			PdfDictionary dictionary = elem.GetDictionary(customValueKey);
			PdfCustomValues pdfCustomValues;
			if (dictionary == null)
			{
				pdfCustomValues = new PdfCustomValues();
				elem.Owner.Owner.Internals.AddObject(pdfCustomValues);
				elem.Add(customValueKey, pdfCustomValues);
			}
			else
			{
				pdfCustomValues = dictionary as PdfCustomValues;
				if (pdfCustomValues == null)
				{
					pdfCustomValues = new PdfCustomValues(dictionary);
				}
			}
			return pdfCustomValues;
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x000344D2 File Offset: 0x000326D2
		internal static void Remove(PdfDictionary.DictionaryElements elem)
		{
			elem.Remove(elem.Owner.Owner.Internals.CustomValueKey);
		}
	}
}
