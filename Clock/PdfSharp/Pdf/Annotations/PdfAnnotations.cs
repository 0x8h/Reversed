using System;
using System.Collections;
using System.Collections.Generic;
using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Pdf.Annotations
{
	// Token: 0x02000134 RID: 308
	public sealed class PdfAnnotations : PdfArray
	{
		// Token: 0x06000AA5 RID: 2725 RVA: 0x0002A4F1 File Offset: 0x000286F1
		internal PdfAnnotations(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x0002A4FA File Offset: 0x000286FA
		internal PdfAnnotations(PdfArray array)
			: base(array)
		{
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x0002A503 File Offset: 0x00028703
		public void Add(PdfAnnotation annotation)
		{
			annotation.Document = this.Owner;
			this.Owner._irefTable.Add(annotation);
			base.Elements.Add(annotation.Reference);
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x0002A533 File Offset: 0x00028733
		public void Remove(PdfAnnotation annotation)
		{
			if (annotation.Owner != this.Owner)
			{
				throw new InvalidOperationException("The annotation does not belong to this document.");
			}
			this.Owner.Internals.RemoveObject(annotation);
			base.Elements.Remove(annotation.Reference);
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x0002A574 File Offset: 0x00028774
		public void Clear()
		{
			for (int i = this.Count - 1; i >= 0; i--)
			{
				this.Page.Annotations.Remove(this._page.Annotations[i]);
			}
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000AAA RID: 2730 RVA: 0x0002A5B5 File Offset: 0x000287B5
		public int Count
		{
			get
			{
				return base.Elements.Count;
			}
		}

		// Token: 0x170003F6 RID: 1014
		public PdfAnnotation this[int index]
		{
			get
			{
				PdfItem pdfItem = base.Elements[index];
				PdfReference pdfReference;
				PdfDictionary pdfDictionary;
				if ((pdfReference = pdfItem as PdfReference) != null)
				{
					pdfDictionary = (PdfDictionary)pdfReference.Value;
				}
				else
				{
					pdfDictionary = (PdfDictionary)pdfItem;
				}
				PdfAnnotation pdfAnnotation = pdfDictionary as PdfAnnotation;
				if (pdfAnnotation == null)
				{
					pdfAnnotation = new PdfGenericAnnotation(pdfDictionary);
					if (pdfReference == null)
					{
						base.Elements[index] = pdfAnnotation;
					}
				}
				return pdfAnnotation;
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000AAC RID: 2732 RVA: 0x0002A61F File Offset: 0x0002881F
		// (set) Token: 0x06000AAD RID: 2733 RVA: 0x0002A627 File Offset: 0x00028827
		internal PdfPage Page
		{
			get
			{
				return this._page;
			}
			set
			{
				this._page = value;
			}
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0002A630 File Offset: 0x00028830
		internal static void FixImportedAnnotation(PdfPage page)
		{
			PdfArray array = page.Elements.GetArray("/Annots");
			if (array != null)
			{
				int count = array.Elements.Count;
				for (int i = 0; i < count; i++)
				{
					PdfDictionary dictionary = array.Elements.GetDictionary(i);
					if (dictionary != null && dictionary.Elements.ContainsKey("/P"))
					{
						dictionary.Elements["/P"] = page.Reference;
					}
				}
			}
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x0002A6A1 File Offset: 0x000288A1
		public override IEnumerator<PdfItem> GetEnumerator()
		{
			return new PdfAnnotations.AnnotationsIterator(this);
		}

		// Token: 0x04000617 RID: 1559
		private PdfPage _page;

		// Token: 0x02000135 RID: 309
		private class AnnotationsIterator : IEnumerator<PdfItem>, IDisposable, IEnumerator
		{
			// Token: 0x06000AB0 RID: 2736 RVA: 0x0002A6A9 File Offset: 0x000288A9
			public AnnotationsIterator(PdfAnnotations annotations)
			{
				this._annotations = annotations;
				this._index = -1;
			}

			// Token: 0x170003F8 RID: 1016
			// (get) Token: 0x06000AB1 RID: 2737 RVA: 0x0002A6BF File Offset: 0x000288BF
			public PdfItem Current
			{
				get
				{
					return this._annotations[this._index];
				}
			}

			// Token: 0x170003F9 RID: 1017
			// (get) Token: 0x06000AB2 RID: 2738 RVA: 0x0002A6D2 File Offset: 0x000288D2
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06000AB3 RID: 2739 RVA: 0x0002A6DC File Offset: 0x000288DC
			public bool MoveNext()
			{
				return ++this._index < this._annotations.Count;
			}

			// Token: 0x06000AB4 RID: 2740 RVA: 0x0002A707 File Offset: 0x00028907
			public void Reset()
			{
				this._index = -1;
			}

			// Token: 0x06000AB5 RID: 2741 RVA: 0x0002A710 File Offset: 0x00028910
			public void Dispose()
			{
			}

			// Token: 0x04000618 RID: 1560
			private readonly PdfAnnotations _annotations;

			// Token: 0x04000619 RID: 1561
			private int _index;
		}
	}
}
