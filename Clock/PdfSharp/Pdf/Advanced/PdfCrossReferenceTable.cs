using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x020000F9 RID: 249
	internal sealed class PdfCrossReferenceTable
	{
		// Token: 0x06000963 RID: 2403 RVA: 0x00023080 File Offset: 0x00021280
		public PdfCrossReferenceTable(PdfDocument document)
		{
			this._document = document;
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x000230A5 File Offset: 0x000212A5
		// (set) Token: 0x06000965 RID: 2405 RVA: 0x000230AD File Offset: 0x000212AD
		internal bool IsUnderConstruction
		{
			get
			{
				return this._isUnderConstruction;
			}
			set
			{
				this._isUnderConstruction = value;
			}
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x000230B8 File Offset: 0x000212B8
		public void Add(PdfReference iref)
		{
			if (iref.ObjectID.IsEmpty)
			{
				iref.ObjectID = new PdfObjectID(this.GetNewObjectNumber());
			}
			if (this.ObjectTable.ContainsKey(iref.ObjectID))
			{
				throw new InvalidOperationException("Object already in table.");
			}
			this.ObjectTable.Add(iref.ObjectID, iref);
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x00023118 File Offset: 0x00021318
		public void Add(PdfObject value)
		{
			if (value.Owner == null)
			{
				value.Document = this._document;
			}
			if (value.ObjectID.IsEmpty)
			{
				value.SetObjectID(this.GetNewObjectNumber(), 0);
			}
			if (this.ObjectTable.ContainsKey(value.ObjectID))
			{
				throw new InvalidOperationException("Object already in table.");
			}
			this.ObjectTable.Add(value.ObjectID, value.Reference);
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0002318B File Offset: 0x0002138B
		public void Remove(PdfReference iref)
		{
			this.ObjectTable.Remove(iref.ObjectID);
		}

		// Token: 0x17000391 RID: 913
		public PdfReference this[PdfObjectID objectID]
		{
			get
			{
				PdfReference pdfReference;
				this.ObjectTable.TryGetValue(objectID, out pdfReference);
				return pdfReference;
			}
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x000231BD File Offset: 0x000213BD
		public bool Contains(PdfObjectID objectID)
		{
			return this.ObjectTable.ContainsKey(objectID);
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x000231CC File Offset: 0x000213CC
		public int GetNewObjectNumber()
		{
			return ++this._maxObjectNumber;
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x000231EC File Offset: 0x000213EC
		internal void WriteObject(PdfWriter writer)
		{
			writer.WriteRaw("xref\n");
			PdfReference[] allReferences = this.AllReferences;
			int num = allReferences.Length;
			writer.WriteRaw(string.Format("0 {0}\n", num + 1));
			writer.WriteRaw(string.Format("{0:0000000000} {1:00000} {2} \n", 0, 65535, "f"));
			for (int i = 0; i < num; i++)
			{
				PdfReference pdfReference = allReferences[i];
				writer.WriteRaw(string.Format("{0:0000000000} {1:00000} {2} \n", pdfReference.Position, pdfReference.GenerationNumber, "n"));
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x0600096D RID: 2413 RVA: 0x00023288 File Offset: 0x00021488
		internal PdfObjectID[] AllObjectIDs
		{
			get
			{
				ICollection keys = this.ObjectTable.Keys;
				PdfObjectID[] array = new PdfObjectID[keys.Count];
				keys.CopyTo(array, 0);
				return array;
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x000232B8 File Offset: 0x000214B8
		internal PdfReference[] AllReferences
		{
			get
			{
				Dictionary<PdfObjectID, PdfReference>.ValueCollection values = this.ObjectTable.Values;
				List<PdfReference> list = new List<PdfReference>(values);
				list.Sort(PdfReference.Comparer);
				PdfReference[] array = new PdfReference[values.Count];
				list.CopyTo(array, 0);
				return array;
			}
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x000232F8 File Offset: 0x000214F8
		internal void HandleOrphanedReferences()
		{
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x000232FC File Offset: 0x000214FC
		internal int Compact()
		{
			int count = this.ObjectTable.Count;
			PdfReference[] array = this.TransitiveClosure(this._document._trailer);
			this._maxObjectNumber = 0;
			this.ObjectTable.Clear();
			foreach (PdfReference pdfReference in array)
			{
				this.ObjectTable.Add(pdfReference.ObjectID, pdfReference);
				this._maxObjectNumber = Math.Max(this._maxObjectNumber, pdfReference.ObjectNumber);
			}
			return count - this.ObjectTable.Count;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0002338C File Offset: 0x0002158C
		internal void Renumber()
		{
			PdfReference[] allReferences = this.AllReferences;
			this.ObjectTable.Clear();
			int num = allReferences.Length;
			for (int i = 0; i < num; i++)
			{
				PdfReference pdfReference = allReferences[i];
				pdfReference.ObjectID = new PdfObjectID(i + 1);
				this.ObjectTable.Add(pdfReference.ObjectID, pdfReference);
			}
			this._maxObjectNumber = num;
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x000233E8 File Offset: 0x000215E8
		[Conditional("DEBUG_")]
		public void CheckConsistence()
		{
			Dictionary<PdfReference, object> dictionary = new Dictionary<PdfReference, object>();
			foreach (PdfReference pdfReference in this.ObjectTable.Values)
			{
				dictionary.Add(pdfReference, null);
			}
			Dictionary<PdfObjectID, object> dictionary2 = new Dictionary<PdfObjectID, object>();
			foreach (PdfReference pdfReference2 in this.ObjectTable.Values)
			{
				dictionary2.Add(pdfReference2.ObjectID, null);
			}
			ICollection values = this.ObjectTable.Values;
			int count = values.Count;
			PdfReference[] array = new PdfReference[count];
			values.CopyTo(array, 0);
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < count; j++)
				{
					if (i != j)
					{
						base.GetType();
					}
				}
			}
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x000234F4 File Offset: 0x000216F4
		public PdfReference[] TransitiveClosure(PdfObject pdfObject)
		{
			return this.TransitiveClosure(pdfObject, 32767);
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x00023504 File Offset: 0x00021704
		public PdfReference[] TransitiveClosure(PdfObject pdfObject, int depth)
		{
			Dictionary<PdfItem, object> dictionary = new Dictionary<PdfItem, object>();
			this._overflow = new Dictionary<PdfItem, object>();
			this.TransitiveClosureImplementation(dictionary, pdfObject);
			while (this._overflow.Count > 0)
			{
				PdfObject[] array = new PdfObject[this._overflow.Count];
				this._overflow.Keys.CopyTo(array, 0);
				this._overflow = new Dictionary<PdfItem, object>();
				foreach (PdfObject pdfObject2 in array)
				{
					this.TransitiveClosureImplementation(dictionary, pdfObject2);
				}
			}
			ICollection keys = dictionary.Keys;
			int count = keys.Count;
			PdfReference[] array2 = new PdfReference[count];
			keys.CopyTo(array2, 0);
			return array2;
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x000235A8 File Offset: 0x000217A8
		private void TransitiveClosureImplementation(Dictionary<PdfItem, object> objects, PdfObject pdfObject)
		{
			try
			{
				PdfCrossReferenceTable._nestingLevel++;
				if (PdfCrossReferenceTable._nestingLevel >= 1000)
				{
					if (!this._overflow.ContainsKey(pdfObject))
					{
						this._overflow.Add(pdfObject, null);
					}
				}
				else
				{
					IEnumerable enumerable = null;
					PdfDictionary pdfDictionary;
					PdfArray pdfArray;
					if ((pdfDictionary = pdfObject as PdfDictionary) != null)
					{
						enumerable = pdfDictionary.Elements.Values;
					}
					else if ((pdfArray = pdfObject as PdfArray) != null)
					{
						enumerable = pdfArray.Elements;
					}
					if (enumerable != null)
					{
						foreach (object obj in enumerable)
						{
							PdfItem pdfItem = (PdfItem)obj;
							PdfReference pdfReference = pdfItem as PdfReference;
							if (pdfReference != null)
							{
								if (!object.ReferenceEquals(pdfReference.Document, this._document))
								{
									base.GetType();
								}
								if (!objects.ContainsKey(pdfReference))
								{
									PdfObject pdfObject2 = pdfReference.Value;
									if (pdfReference.Document != null)
									{
										if (pdfObject2 == null)
										{
											pdfReference = this.ObjectTable[pdfReference.ObjectID];
											pdfObject2 = pdfReference.Value;
										}
										objects.Add(pdfReference, null);
										if (pdfObject2 is PdfArray || pdfObject2 is PdfDictionary)
										{
											this.TransitiveClosureImplementation(objects, pdfObject2);
										}
									}
								}
							}
							else
							{
								PdfObject pdfObject3 = pdfItem as PdfObject;
								if (pdfObject3 != null && (pdfObject3 is PdfDictionary || pdfObject3 is PdfArray))
								{
									this.TransitiveClosureImplementation(objects, pdfObject3);
								}
							}
						}
					}
				}
			}
			finally
			{
				PdfCrossReferenceTable._nestingLevel--;
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x00023758 File Offset: 0x00021958
		public PdfReference DeadObject
		{
			get
			{
				if (this._deadObject == null)
				{
					this._deadObject = new PdfDictionary(this._document);
					this.Add(this._deadObject);
					this._deadObject.Elements.Add("/DeadObjectCount", new PdfInteger());
				}
				return this._deadObject.Reference;
			}
		}

		// Token: 0x040004EE RID: 1262
		private readonly PdfDocument _document;

		// Token: 0x040004EF RID: 1263
		public Dictionary<PdfObjectID, PdfReference> ObjectTable = new Dictionary<PdfObjectID, PdfReference>();

		// Token: 0x040004F0 RID: 1264
		private bool _isUnderConstruction;

		// Token: 0x040004F1 RID: 1265
		internal int _maxObjectNumber;

		// Token: 0x040004F2 RID: 1266
		private static int _nestingLevel;

		// Token: 0x040004F3 RID: 1267
		private Dictionary<PdfItem, object> _overflow = new Dictionary<PdfItem, object>();

		// Token: 0x040004F4 RID: 1268
		private PdfDictionary _deadObject;
	}
}
