using System;
using System.Collections;
using System.Collections.Generic;
using PdfSharp.Pdf.Content.Objects;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x020000F2 RID: 242
	public sealed class PdfContents : PdfArray
	{
		// Token: 0x06000940 RID: 2368 RVA: 0x00022716 File Offset: 0x00020916
		public PdfContents(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x00022720 File Offset: 0x00020920
		internal PdfContents(PdfArray array)
			: base(array)
		{
			int count = base.Elements.Count;
			for (int i = 0; i < count; i++)
			{
				PdfItem pdfItem = base.Elements[i];
				PdfReference pdfReference = pdfItem as PdfReference;
				if (pdfReference == null || !(pdfReference.Value is PdfDictionary))
				{
					throw new InvalidOperationException("Unexpected item in a content stream array.");
				}
				new PdfContent((PdfDictionary)pdfReference.Value);
			}
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x00022790 File Offset: 0x00020990
		public PdfContent AppendContent()
		{
			this.SetModified();
			PdfContent pdfContent = new PdfContent(this.Owner);
			this.Owner._irefTable.Add(pdfContent);
			base.Elements.Add(pdfContent.Reference);
			return pdfContent;
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x000227D4 File Offset: 0x000209D4
		public PdfContent PrependContent()
		{
			this.SetModified();
			PdfContent pdfContent = new PdfContent(this.Owner);
			this.Owner._irefTable.Add(pdfContent);
			base.Elements.Insert(0, pdfContent.Reference);
			return pdfContent;
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x00022818 File Offset: 0x00020A18
		public PdfContent CreateSingleContent()
		{
			byte[] array = new byte[0];
			foreach (PdfItem pdfItem in base.Elements)
			{
				PdfDictionary pdfDictionary = (PdfDictionary)((PdfReference)pdfItem).Value;
				byte[] array2 = array;
				byte[] unfilteredValue = pdfDictionary.Stream.UnfilteredValue;
				array = new byte[array2.Length + unfilteredValue.Length + 1];
				array2.CopyTo(array, 0);
				array[array2.Length] = 10;
				unfilteredValue.CopyTo(array, array2.Length + 1);
			}
			PdfContent pdfContent = new PdfContent(this.Owner);
			pdfContent.Stream = new PdfDictionary.PdfStream(array, pdfContent);
			return pdfContent;
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x000228D4 File Offset: 0x00020AD4
		public PdfContent ReplaceContent(CSequence cseq)
		{
			if (cseq == null)
			{
				throw new ArgumentException("cseq");
			}
			return this.ReplaceContent(cseq.ToContent());
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x000228F0 File Offset: 0x00020AF0
		private PdfContent ReplaceContent(byte[] contentBytes)
		{
			PdfContent pdfContent = new PdfContent(this.Owner);
			pdfContent.CreateStream(contentBytes);
			this.Owner._irefTable.Add(pdfContent);
			base.Elements.Clear();
			base.Elements.Add(pdfContent.Reference);
			return pdfContent;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x00022940 File Offset: 0x00020B40
		private void SetModified()
		{
			if (!this._modified)
			{
				this._modified = true;
				int count = base.Elements.Count;
				if (count == 1)
				{
					PdfContent pdfContent = (PdfContent)((PdfReference)base.Elements[0]).Value;
					pdfContent.PreserveGraphicsState();
					return;
				}
				if (count > 1)
				{
					PdfContent pdfContent2 = (PdfContent)((PdfReference)base.Elements[0]).Value;
					if (pdfContent2 != null && pdfContent2.Stream != null)
					{
						int num = pdfContent2.Stream.Length;
						byte[] array = new byte[num + 2];
						array[0] = 113;
						array[1] = 10;
						Array.Copy(pdfContent2.Stream.Value, 0, array, 2, num);
						pdfContent2.Stream.Value = array;
						pdfContent2.Elements.SetInteger("/Length", num + 2);
					}
					pdfContent2 = (PdfContent)((PdfReference)base.Elements[count - 1]).Value;
					if (pdfContent2 != null && pdfContent2.Stream != null)
					{
						int num = pdfContent2.Stream.Length;
						byte[] array = new byte[num + 3];
						Array.Copy(pdfContent2.Stream.Value, 0, array, 0, num);
						array[num] = 32;
						array[num + 1] = 81;
						array[num + 2] = 10;
						pdfContent2.Stream.Value = array;
						pdfContent2.Elements.SetInteger("/Length", num + 3);
					}
				}
			}
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00022AA4 File Offset: 0x00020CA4
		internal override void WriteObject(PdfWriter writer)
		{
			if (base.Elements.Count == 1)
			{
				base.Elements[0].WriteObject(writer);
				return;
			}
			base.WriteObject(writer);
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x00022ACE File Offset: 0x00020CCE
		public new IEnumerator<PdfContent> GetEnumerator()
		{
			return new PdfContents.PdfPageContentEnumerator(this);
		}

		// Token: 0x040004D7 RID: 1239
		private bool _modified;

		// Token: 0x020000F3 RID: 243
		private class PdfPageContentEnumerator : IEnumerator<PdfContent>, IDisposable, IEnumerator
		{
			// Token: 0x0600094A RID: 2378 RVA: 0x00022AD6 File Offset: 0x00020CD6
			internal PdfPageContentEnumerator(PdfContents list)
			{
				this._contents = list;
				this._index = -1;
			}

			// Token: 0x0600094B RID: 2379 RVA: 0x00022AEC File Offset: 0x00020CEC
			public bool MoveNext()
			{
				if (this._index < this._contents.Elements.Count - 1)
				{
					this._index++;
					this._currentElement = (PdfContent)((PdfReference)this._contents.Elements[this._index]).Value;
					return true;
				}
				this._index = this._contents.Elements.Count;
				return false;
			}

			// Token: 0x0600094C RID: 2380 RVA: 0x00022B65 File Offset: 0x00020D65
			public void Reset()
			{
				this._currentElement = null;
				this._index = -1;
			}

			// Token: 0x17000386 RID: 902
			// (get) Token: 0x0600094D RID: 2381 RVA: 0x00022B75 File Offset: 0x00020D75
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x17000387 RID: 903
			// (get) Token: 0x0600094E RID: 2382 RVA: 0x00022B7D File Offset: 0x00020D7D
			public PdfContent Current
			{
				get
				{
					if (this._index == -1 || this._index >= this._contents.Elements.Count)
					{
						throw new InvalidOperationException(PSSR.ListEnumCurrentOutOfRange);
					}
					return this._currentElement;
				}
			}

			// Token: 0x0600094F RID: 2383 RVA: 0x00022BB1 File Offset: 0x00020DB1
			public void Dispose()
			{
			}

			// Token: 0x040004D8 RID: 1240
			private PdfContent _currentElement;

			// Token: 0x040004D9 RID: 1241
			private int _index;

			// Token: 0x040004DA RID: 1242
			private readonly PdfContents _contents;
		}
	}
}
