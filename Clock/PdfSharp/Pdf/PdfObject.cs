using System;
using System.Diagnostics;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020000C4 RID: 196
	public abstract class PdfObject : PdfItem
	{
		// Token: 0x060007E9 RID: 2025 RVA: 0x0001E415 File Offset: 0x0001C615
		protected PdfObject()
		{
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x0001E41D File Offset: 0x0001C61D
		protected PdfObject(PdfDocument document)
		{
			this.Document = document;
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x0001E42C File Offset: 0x0001C62C
		protected PdfObject(PdfObject obj)
			: this(obj.Owner)
		{
			if (obj._iref != null)
			{
				obj._iref.Value = this;
			}
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x0001E44E File Offset: 0x0001C64E
		public new PdfObject Clone()
		{
			return (PdfObject)this.Copy();
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0001E45C File Offset: 0x0001C65C
		protected override object Copy()
		{
			PdfObject pdfObject = (PdfObject)base.Copy();
			pdfObject._document = null;
			pdfObject._iref = null;
			return pdfObject;
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0001E484 File Offset: 0x0001C684
		internal void SetObjectID(int objectNumber, int generationNumber)
		{
			PdfObjectID pdfObjectID = new PdfObjectID(objectNumber, generationNumber);
			if (this._iref == null)
			{
				this._iref = this._document._irefTable[pdfObjectID];
			}
			if (this._iref == null)
			{
				new PdfReference(this);
				this._iref.ObjectID = pdfObjectID;
			}
			this._iref.Value = this;
			this._iref.Document = this._document;
		}

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x0001E4F1 File Offset: 0x0001C6F1
		public virtual PdfDocument Owner
		{
			get
			{
				return this._document;
			}
		}

		// Token: 0x1700031C RID: 796
		// (set) Token: 0x060007F0 RID: 2032 RVA: 0x0001E4F9 File Offset: 0x0001C6F9
		internal virtual PdfDocument Document
		{
			set
			{
				if (!object.ReferenceEquals(this._document, value))
				{
					if (this._document != null)
					{
						throw new InvalidOperationException("Cannot change document.");
					}
					this._document = value;
					if (this._iref != null)
					{
						this._iref.Document = value;
					}
				}
			}
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x0001E537 File Offset: 0x0001C737
		public bool IsIndirect
		{
			get
			{
				return this._iref != null;
			}
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x060007F2 RID: 2034 RVA: 0x0001E548 File Offset: 0x0001C748
		public PdfObjectInternals Internals
		{
			get
			{
				PdfObjectInternals pdfObjectInternals;
				if ((pdfObjectInternals = this._internals) == null)
				{
					pdfObjectInternals = (this._internals = new PdfObjectInternals(this));
				}
				return pdfObjectInternals;
			}
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0001E56E File Offset: 0x0001C76E
		internal virtual void PrepareForSave()
		{
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0001E570 File Offset: 0x0001C770
		internal override void WriteObject(PdfWriter writer)
		{
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x0001E572 File Offset: 0x0001C772
		internal PdfObjectID ObjectID
		{
			get
			{
				if (this._iref == null)
				{
					return PdfObjectID.Empty;
				}
				return this._iref.ObjectID;
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x060007F6 RID: 2038 RVA: 0x0001E590 File Offset: 0x0001C790
		internal int ObjectNumber
		{
			get
			{
				return this.ObjectID.ObjectNumber;
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x0001E5AC File Offset: 0x0001C7AC
		internal int GenerationNumber
		{
			get
			{
				return this.ObjectID.GenerationNumber;
			}
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0001E5C8 File Offset: 0x0001C7C8
		internal static PdfObject DeepCopyClosure(PdfDocument owner, PdfObject externalObject)
		{
			PdfObject[] closure = externalObject.Owner.Internals.GetClosure(externalObject);
			int num = closure.Length;
			PdfImportedObjectTable pdfImportedObjectTable = new PdfImportedObjectTable(owner, externalObject.Owner);
			for (int i = 0; i < num; i++)
			{
				PdfObject pdfObject = closure[i];
				PdfObject pdfObject2 = pdfObject.Clone();
				pdfObject2.Document = owner;
				if (pdfObject.Reference != null)
				{
					owner._irefTable.Add(pdfObject2);
					pdfImportedObjectTable.Add(pdfObject.ObjectID, pdfObject2.Reference);
				}
				closure[i] = pdfObject2;
			}
			for (int j = 0; j < num; j++)
			{
				PdfObject pdfObject3 = closure[j];
				PdfObject.FixUpObject(pdfImportedObjectTable, owner, pdfObject3);
			}
			return closure[0];
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0001E66C File Offset: 0x0001C86C
		internal static PdfObject ImportClosure(PdfImportedObjectTable importedObjectTable, PdfDocument owner, PdfObject externalObject)
		{
			PdfObject[] closure = externalObject.Owner.Internals.GetClosure(externalObject);
			int num = closure.Length;
			for (int i = 0; i < num; i++)
			{
				PdfObject pdfObject = closure[i];
				if (importedObjectTable.Contains(pdfObject.ObjectID))
				{
					PdfReference pdfReference = importedObjectTable[pdfObject.ObjectID];
					closure[i] = pdfReference.Value;
				}
				else
				{
					PdfObject pdfObject2 = pdfObject.Clone();
					pdfObject2.Document = owner;
					if (pdfObject.Reference != null)
					{
						owner._irefTable.Add(pdfObject2);
						importedObjectTable.Add(pdfObject.ObjectID, pdfObject2.Reference);
					}
					closure[i] = pdfObject2;
				}
			}
			for (int j = 0; j < num; j++)
			{
				PdfObject pdfObject3 = closure[j];
				PdfObject.FixUpObject(importedObjectTable, importedObjectTable.Owner, pdfObject3);
			}
			return closure[0];
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0001E72C File Offset: 0x0001C92C
		private static void FixUpObject(PdfImportedObjectTable iot, PdfDocument owner, PdfObject value)
		{
			PdfDictionary pdfDictionary;
			if ((pdfDictionary = value as PdfDictionary) != null)
			{
				if (pdfDictionary.Owner == null)
				{
					pdfDictionary.Document = owner;
				}
				PdfName[] keyNames = pdfDictionary.Elements.KeyNames;
				foreach (PdfName pdfName in keyNames)
				{
					PdfItem pdfItem = pdfDictionary.Elements[pdfName];
					PdfReference pdfReference = pdfItem as PdfReference;
					if (pdfReference != null)
					{
						if (pdfReference.Document != owner)
						{
							PdfReference pdfReference2 = iot[pdfReference.ObjectID];
							pdfDictionary.Elements[pdfName] = pdfReference2;
						}
					}
					else
					{
						PdfObject pdfObject = pdfItem as PdfObject;
						if (pdfObject != null)
						{
							PdfObject.FixUpObject(iot, owner, pdfObject);
						}
					}
				}
				return;
			}
			PdfArray pdfArray;
			if ((pdfArray = value as PdfArray) != null)
			{
				if (pdfArray.Owner == null)
				{
					pdfArray.Document = owner;
				}
				int count = pdfArray.Elements.Count;
				for (int j = 0; j < count; j++)
				{
					PdfItem pdfItem2 = pdfArray.Elements[j];
					PdfReference pdfReference3 = pdfItem2 as PdfReference;
					if (pdfReference3 != null)
					{
						if (pdfReference3.Document != owner)
						{
							PdfReference pdfReference4 = iot[pdfReference3.ObjectID];
							pdfArray.Elements[j] = pdfReference4;
						}
					}
					else
					{
						PdfObject pdfObject2 = pdfItem2 as PdfObject;
						if (pdfObject2 != null)
						{
							PdfObject.FixUpObject(iot, owner, pdfObject2);
						}
					}
				}
				return;
			}
			if (!(value is PdfNameObject) && !(value is PdfStringObject) && !(value is PdfBooleanObject) && !(value is PdfIntegerObject))
			{
				PdfNumberObject pdfNumberObject = value as PdfNumberObject;
			}
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x0001E898 File Offset: 0x0001CA98
		[Conditional("DEBUG")]
		private static void DebugCheckNonObjects(PdfItem item)
		{
			if (item is PdfName)
			{
				return;
			}
			if (item is PdfBoolean)
			{
				return;
			}
			if (item is PdfInteger)
			{
				return;
			}
			if (item is PdfNumber)
			{
				return;
			}
			if (item is PdfString)
			{
				return;
			}
			if (item is PdfRectangle)
			{
				return;
			}
			if (item is PdfNull)
			{
				return;
			}
			item.GetType();
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x0001E8EB File Offset: 0x0001CAEB
		// (set) Token: 0x060007FD RID: 2045 RVA: 0x0001E8F3 File Offset: 0x0001CAF3
		public PdfReference Reference
		{
			get
			{
				return this._iref;
			}
			internal set
			{
				this._iref = value;
			}
		}

		// Token: 0x04000453 RID: 1107
		internal PdfDocument _document;

		// Token: 0x04000454 RID: 1108
		private PdfObjectInternals _internals;

		// Token: 0x04000455 RID: 1109
		private PdfReference _iref;
	}
}
