using System;
using System.Collections.Generic;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Internal
{
	// Token: 0x02000167 RID: 359
	internal class ThreadLocalStorage
	{
		// Token: 0x06000BDE RID: 3038 RVA: 0x0002F55B File Offset: 0x0002D75B
		public ThreadLocalStorage()
		{
			this._importedDocuments = new Dictionary<string, PdfDocument.DocumentHandle>(StringComparer.OrdinalIgnoreCase);
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x0002F573 File Offset: 0x0002D773
		public void AddDocument(string path, PdfDocument document)
		{
			this._importedDocuments.Add(path, document.Handle);
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x0002F587 File Offset: 0x0002D787
		public void RemoveDocument(string path)
		{
			this._importedDocuments.Remove(path);
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x0002F598 File Offset: 0x0002D798
		public PdfDocument GetDocument(string path)
		{
			PdfDocument pdfDocument = null;
			PdfDocument.DocumentHandle documentHandle;
			if (this._importedDocuments.TryGetValue(path, out documentHandle))
			{
				pdfDocument = documentHandle.Target;
				if (pdfDocument == null)
				{
					this.RemoveDocument(path);
				}
			}
			if (pdfDocument == null)
			{
				pdfDocument = PdfReader.Open(path, PdfDocumentOpenMode.Import);
				this._importedDocuments.Add(path, pdfDocument.Handle);
			}
			return pdfDocument;
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06000BE2 RID: 3042 RVA: 0x0002F5E8 File Offset: 0x0002D7E8
		public PdfDocument[] Documents
		{
			get
			{
				List<PdfDocument> list = new List<PdfDocument>();
				foreach (PdfDocument.DocumentHandle documentHandle in this._importedDocuments.Values)
				{
					if (documentHandle.IsAlive)
					{
						list.Add(documentHandle.Target);
					}
				}
				return list.ToArray();
			}
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x0002F65C File Offset: 0x0002D85C
		public void DetachDocument(PdfDocument.DocumentHandle handle)
		{
			if (handle.IsAlive)
			{
				foreach (string text in this._importedDocuments.Keys)
				{
					if (this._importedDocuments[text] == handle)
					{
						this._importedDocuments.Remove(text);
						break;
					}
				}
			}
			bool flag = true;
			while (flag)
			{
				flag = false;
				foreach (string text2 in this._importedDocuments.Keys)
				{
					if (!this._importedDocuments[text2].IsAlive)
					{
						this._importedDocuments.Remove(text2);
						flag = true;
						break;
					}
				}
			}
		}

		// Token: 0x0400073F RID: 1855
		private readonly Dictionary<string, PdfDocument.DocumentHandle> _importedDocuments;
	}
}
