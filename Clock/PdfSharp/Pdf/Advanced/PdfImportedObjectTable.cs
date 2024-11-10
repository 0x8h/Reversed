using System;
using System.Collections.Generic;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000114 RID: 276
	internal sealed class PdfImportedObjectTable
	{
		// Token: 0x060009F8 RID: 2552 RVA: 0x00028344 File Offset: 0x00026544
		public PdfImportedObjectTable(PdfDocument owner, PdfDocument externalDocument)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner");
			}
			if (externalDocument == null)
			{
				throw new ArgumentNullException("externalDocument");
			}
			this._owner = owner;
			this._externalDocumentHandle = externalDocument.Handle;
			this._xObjects = new PdfFormXObject[externalDocument.PageCount];
		}

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x060009F9 RID: 2553 RVA: 0x000283A2 File Offset: 0x000265A2
		public PdfDocument Owner
		{
			get
			{
				return this._owner;
			}
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x060009FA RID: 2554 RVA: 0x000283AA File Offset: 0x000265AA
		public PdfDocument ExternalDocument
		{
			get
			{
				if (!this._externalDocumentHandle.IsAlive)
				{
					return null;
				}
				return this._externalDocumentHandle.Target;
			}
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x000283C6 File Offset: 0x000265C6
		public PdfFormXObject GetXObject(int pageNumber)
		{
			return this._xObjects[pageNumber - 1];
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x000283D2 File Offset: 0x000265D2
		public void SetXObject(int pageNumber, PdfFormXObject xObject)
		{
			this._xObjects[pageNumber - 1] = xObject;
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x000283DF File Offset: 0x000265DF
		public bool Contains(PdfObjectID externalID)
		{
			return this._externalIDs.ContainsKey(externalID.ToString());
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x000283F9 File Offset: 0x000265F9
		public void Add(PdfObjectID externalID, PdfReference iref)
		{
			this._externalIDs[externalID.ToString()] = iref;
		}

		// Token: 0x170003B2 RID: 946
		public PdfReference this[PdfObjectID externalID]
		{
			get
			{
				return this._externalIDs[externalID.ToString()];
			}
		}

		// Token: 0x0400057E RID: 1406
		private readonly PdfFormXObject[] _xObjects;

		// Token: 0x0400057F RID: 1407
		private readonly PdfDocument _owner;

		// Token: 0x04000580 RID: 1408
		private readonly PdfDocument.DocumentHandle _externalDocumentHandle;

		// Token: 0x04000581 RID: 1409
		private readonly Dictionary<string, PdfReference> _externalIDs = new Dictionary<string, PdfReference>();
	}
}
