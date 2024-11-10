using System;
using System.Collections.Generic;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000109 RID: 265
	internal sealed class PdfFormXObjectTable : PdfResourceTable
	{
		// Token: 0x060009BA RID: 2490 RVA: 0x0002450C File Offset: 0x0002270C
		public PdfFormXObjectTable(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x00024520 File Offset: 0x00022720
		public PdfFormXObject GetForm(XForm form)
		{
			if (form._pdfForm != null)
			{
				if (object.ReferenceEquals(form._pdfForm.Owner, base.Owner))
				{
					return form._pdfForm;
				}
				form._pdfForm = null;
			}
			XPdfForm xpdfForm = form as XPdfForm;
			if (xpdfForm != null)
			{
				PdfFormXObjectTable.Selector selector = new PdfFormXObjectTable.Selector(form);
				PdfImportedObjectTable pdfImportedObjectTable;
				if (!this._forms.TryGetValue(selector, out pdfImportedObjectTable))
				{
					PdfDocument externalDocument = xpdfForm.ExternalDocument;
					pdfImportedObjectTable = new PdfImportedObjectTable(base.Owner, externalDocument);
					this._forms[selector] = pdfImportedObjectTable;
				}
				PdfFormXObject pdfFormXObject = pdfImportedObjectTable.GetXObject(xpdfForm.PageNumber);
				if (pdfFormXObject == null)
				{
					pdfFormXObject = new PdfFormXObject(base.Owner, pdfImportedObjectTable, xpdfForm);
					pdfImportedObjectTable.SetXObject(xpdfForm.PageNumber, pdfFormXObject);
				}
				return pdfFormXObject;
			}
			form._pdfForm = new PdfFormXObject(base.Owner, form);
			return form._pdfForm;
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x000245E8 File Offset: 0x000227E8
		public PdfImportedObjectTable GetImportedObjectTable(PdfPage page)
		{
			PdfFormXObjectTable.Selector selector = new PdfFormXObjectTable.Selector(page);
			PdfImportedObjectTable pdfImportedObjectTable;
			if (!this._forms.TryGetValue(selector, out pdfImportedObjectTable))
			{
				pdfImportedObjectTable = new PdfImportedObjectTable(base.Owner, page.Owner);
				this._forms[selector] = pdfImportedObjectTable;
			}
			return pdfImportedObjectTable;
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x0002462C File Offset: 0x0002282C
		public PdfImportedObjectTable GetImportedObjectTable(PdfDocument document)
		{
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			PdfFormXObjectTable.Selector selector = new PdfFormXObjectTable.Selector(document);
			PdfImportedObjectTable pdfImportedObjectTable;
			if (!this._forms.TryGetValue(selector, out pdfImportedObjectTable))
			{
				pdfImportedObjectTable = new PdfImportedObjectTable(base.Owner, document);
				this._forms[selector] = pdfImportedObjectTable;
			}
			return pdfImportedObjectTable;
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0002467C File Offset: 0x0002287C
		public void DetachDocument(PdfDocument.DocumentHandle handle)
		{
			if (handle.IsAlive)
			{
				foreach (PdfFormXObjectTable.Selector selector in this._forms.Keys)
				{
					PdfImportedObjectTable pdfImportedObjectTable = this._forms[selector];
					if (pdfImportedObjectTable.ExternalDocument != null && pdfImportedObjectTable.ExternalDocument.Handle == handle)
					{
						this._forms.Remove(selector);
						break;
					}
				}
			}
			bool flag = true;
			while (flag)
			{
				flag = false;
				foreach (PdfFormXObjectTable.Selector selector2 in this._forms.Keys)
				{
					PdfImportedObjectTable pdfImportedObjectTable2 = this._forms[selector2];
					if (pdfImportedObjectTable2.ExternalDocument == null)
					{
						this._forms.Remove(selector2);
						flag = true;
						break;
					}
				}
			}
		}

		// Token: 0x04000548 RID: 1352
		private readonly Dictionary<PdfFormXObjectTable.Selector, PdfImportedObjectTable> _forms = new Dictionary<PdfFormXObjectTable.Selector, PdfImportedObjectTable>();

		// Token: 0x0200010A RID: 266
		public class Selector
		{
			// Token: 0x060009BF RID: 2495 RVA: 0x00024780 File Offset: 0x00022980
			public Selector(XForm form)
			{
				this._path = form._path.ToLowerInvariant();
			}

			// Token: 0x060009C0 RID: 2496 RVA: 0x0002479C File Offset: 0x0002299C
			public Selector(PdfPage page)
			{
				PdfDocument owner = page.Owner;
				this._path = "*" + owner.Guid.ToString("B");
				this._path = this._path.ToLowerInvariant();
			}

			// Token: 0x060009C1 RID: 2497 RVA: 0x000247EC File Offset: 0x000229EC
			public Selector(PdfDocument document)
			{
				this._path = "*" + document.Guid.ToString("B");
				this._path = this._path.ToLowerInvariant();
			}

			// Token: 0x170003AA RID: 938
			// (get) Token: 0x060009C2 RID: 2498 RVA: 0x00024833 File Offset: 0x00022A33
			// (set) Token: 0x060009C3 RID: 2499 RVA: 0x0002483B File Offset: 0x00022A3B
			public string Path
			{
				get
				{
					return this._path;
				}
				set
				{
					this._path = value;
				}
			}

			// Token: 0x060009C4 RID: 2500 RVA: 0x00024844 File Offset: 0x00022A44
			public override bool Equals(object obj)
			{
				PdfFormXObjectTable.Selector selector = obj as PdfFormXObjectTable.Selector;
				return obj != null && this._path == selector._path;
			}

			// Token: 0x060009C5 RID: 2501 RVA: 0x0002486E File Offset: 0x00022A6E
			public override int GetHashCode()
			{
				return this._path.GetHashCode();
			}

			// Token: 0x04000549 RID: 1353
			private string _path;
		}
	}
}
