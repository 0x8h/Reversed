using System;
using System.IO;
using System.Reflection;
using System.Text;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000115 RID: 277
	public class PdfInternals
	{
		// Token: 0x06000A00 RID: 2560 RVA: 0x0002842E File Offset: 0x0002662E
		internal PdfInternals(PdfDocument document)
		{
			this._document = document;
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x00028448 File Offset: 0x00026648
		// (set) Token: 0x06000A02 RID: 2562 RVA: 0x0002845B File Offset: 0x0002665B
		public string FirstDocumentID
		{
			get
			{
				return this._document._trailer.GetDocumentID(0);
			}
			set
			{
				this._document._trailer.SetDocumentID(0, value);
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06000A03 RID: 2563 RVA: 0x0002846F File Offset: 0x0002666F
		public Guid FirstDocumentGuid
		{
			get
			{
				return this.GuidFromString(this._document._trailer.GetDocumentID(0));
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06000A04 RID: 2564 RVA: 0x00028488 File Offset: 0x00026688
		// (set) Token: 0x06000A05 RID: 2565 RVA: 0x0002849B File Offset: 0x0002669B
		public string SecondDocumentID
		{
			get
			{
				return this._document._trailer.GetDocumentID(1);
			}
			set
			{
				this._document._trailer.SetDocumentID(1, value);
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06000A06 RID: 2566 RVA: 0x000284AF File Offset: 0x000266AF
		public Guid SecondDocumentGuid
		{
			get
			{
				return this.GuidFromString(this._document._trailer.GetDocumentID(0));
			}
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x000284C8 File Offset: 0x000266C8
		private Guid GuidFromString(string id)
		{
			if (id == null || id.Length != 16)
			{
				return Guid.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 16; i++)
			{
				stringBuilder.AppendFormat("{0:X2}", (byte)id[i]);
			}
			return new Guid(stringBuilder.ToString());
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06000A08 RID: 2568 RVA: 0x0002851F File Offset: 0x0002671F
		public PdfCatalog Catalog
		{
			get
			{
				return this._document.Catalog;
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06000A09 RID: 2569 RVA: 0x0002852C File Offset: 0x0002672C
		public PdfExtGStateTable ExtGStateTable
		{
			get
			{
				return this._document.ExtGStateTable;
			}
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00028539 File Offset: 0x00026739
		public PdfObject GetObject(PdfObjectID objectID)
		{
			return this._document._irefTable[objectID].Value;
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00028554 File Offset: 0x00026754
		public PdfObject MapExternalObject(PdfObject externalObject)
		{
			PdfFormXObjectTable formTable = this._document.FormTable;
			PdfImportedObjectTable importedObjectTable = formTable.GetImportedObjectTable(externalObject.Owner);
			PdfReference pdfReference = importedObjectTable[externalObject.ObjectID];
			if (pdfReference != null)
			{
				return pdfReference.Value;
			}
			return null;
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00028592 File Offset: 0x00026792
		public static PdfReference GetReference(PdfObject obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			return obj.Reference;
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x000285A8 File Offset: 0x000267A8
		public static PdfObjectID GetObjectID(PdfObject obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			return obj.ObjectID;
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x000285BE File Offset: 0x000267BE
		public static int GetObjectNumber(PdfObject obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			return obj.ObjectNumber;
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x000285D4 File Offset: 0x000267D4
		public static int GenerationNumber(PdfObject obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			return obj.GenerationNumber;
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x000285EC File Offset: 0x000267EC
		public PdfObject[] GetAllObjects()
		{
			PdfReference[] allReferences = this._document._irefTable.AllReferences;
			int num = allReferences.Length;
			PdfObject[] array = new PdfObject[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = allReferences[i].Value;
			}
			return array;
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06000A11 RID: 2577 RVA: 0x0002862D File Offset: 0x0002682D
		[Obsolete("Use GetAllObjects.")]
		public PdfObject[] AllObjects
		{
			get
			{
				return this.GetAllObjects();
			}
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00028638 File Offset: 0x00026838
		public T CreateIndirectObject<T>() where T : PdfObject
		{
			T t = default(T);
			ConstructorInfo constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.ExactBinding, null, new Type[] { typeof(PdfDocument) }, null);
			if (constructor != null)
			{
				t = (T)((object)constructor.Invoke(new object[] { this._document }));
				this.AddObject(t);
			}
			return t;
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x000286A8 File Offset: 0x000268A8
		public void AddObject(PdfObject obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (obj.Owner == null)
			{
				obj.Document = this._document;
			}
			else if (obj.Owner != this._document)
			{
				throw new InvalidOperationException("Object does not belong to this document.");
			}
			this._document._irefTable.Add(obj);
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00028704 File Offset: 0x00026904
		public void RemoveObject(PdfObject obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (obj.Reference == null)
			{
				throw new InvalidOperationException("Only indirect objects can be removed.");
			}
			if (obj.Owner != this._document)
			{
				throw new InvalidOperationException("Object does not belong to this document.");
			}
			this._document._irefTable.Remove(obj.Reference);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00028761 File Offset: 0x00026961
		public PdfObject[] GetClosure(PdfObject obj)
		{
			return this.GetClosure(obj, int.MaxValue);
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00028770 File Offset: 0x00026970
		public PdfObject[] GetClosure(PdfObject obj, int depth)
		{
			PdfReference[] array = this._document._irefTable.TransitiveClosure(obj, depth);
			int num = array.Length + 1;
			PdfObject[] array2 = new PdfObject[num];
			array2[0] = obj;
			for (int i = 1; i < num; i++)
			{
				array2[i] = array[i - 1].Value;
			}
			return array2;
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x000287BC File Offset: 0x000269BC
		public void WriteObject(Stream stream, PdfItem item)
		{
			item.WriteObject(new PdfWriter(stream, null)
			{
				Options = PdfWriterOptions.OmitStream
			});
		}

		// Token: 0x04000582 RID: 1410
		private readonly PdfDocument _document;

		// Token: 0x04000583 RID: 1411
		public string CustomValueKey = "/PdfSharp.CustomValue";
	}
}
