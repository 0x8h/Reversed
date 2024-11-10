using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001B6 RID: 438
	internal sealed class PdfReferenceTable_old
	{
		// Token: 0x06000E73 RID: 3699 RVA: 0x00038B38 File Offset: 0x00036D38
		public PdfReferenceTable_old(PdfDocument document)
		{
			this._document = document;
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06000E74 RID: 3700 RVA: 0x00038B5D File Offset: 0x00036D5D
		// (set) Token: 0x06000E75 RID: 3701 RVA: 0x00038B65 File Offset: 0x00036D65
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

		// Token: 0x06000E76 RID: 3702 RVA: 0x00038B70 File Offset: 0x00036D70
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

		// Token: 0x06000E77 RID: 3703 RVA: 0x00038BD0 File Offset: 0x00036DD0
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

		// Token: 0x06000E78 RID: 3704 RVA: 0x00038C43 File Offset: 0x00036E43
		public void Remove(PdfReference iref)
		{
			this.ObjectTable.Remove(iref.ObjectID);
		}

		// Token: 0x170004E1 RID: 1249
		public PdfReference this[PdfObjectID objectID]
		{
			get
			{
				PdfReference pdfReference;
				this.ObjectTable.TryGetValue(objectID, out pdfReference);
				return pdfReference;
			}
		}

		// Token: 0x06000E7A RID: 3706 RVA: 0x00038C75 File Offset: 0x00036E75
		public bool Contains(PdfObjectID objectID)
		{
			return this.ObjectTable.ContainsKey(objectID);
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x00038C84 File Offset: 0x00036E84
		public int GetNewObjectNumber()
		{
			return ++this._maxObjectNumber;
		}

		// Token: 0x06000E7C RID: 3708 RVA: 0x00038CA4 File Offset: 0x00036EA4
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

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06000E7D RID: 3709 RVA: 0x00038D40 File Offset: 0x00036F40
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

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06000E7E RID: 3710 RVA: 0x00038D70 File Offset: 0x00036F70
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

		// Token: 0x06000E7F RID: 3711 RVA: 0x00038DB0 File Offset: 0x00036FB0
		internal void HandleOrphanedReferences()
		{
		}

		// Token: 0x06000E80 RID: 3712 RVA: 0x00038DB4 File Offset: 0x00036FB4
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

		// Token: 0x06000E81 RID: 3713 RVA: 0x00038E44 File Offset: 0x00037044
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

		// Token: 0x06000E82 RID: 3714 RVA: 0x00038EA0 File Offset: 0x000370A0
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

		// Token: 0x06000E83 RID: 3715 RVA: 0x00038FAC File Offset: 0x000371AC
		public PdfReference[] TransitiveClosure(PdfObject pdfObject)
		{
			return this.TransitiveClosure(pdfObject, 32767);
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x00038FBC File Offset: 0x000371BC
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

		// Token: 0x06000E85 RID: 3717 RVA: 0x00039060 File Offset: 0x00037260
		private void TransitiveClosureImplementation(Dictionary<PdfItem, object> objects, PdfObject pdfObject)
		{
			try
			{
				PdfReferenceTable_old._nestingLevel++;
				if (PdfReferenceTable_old._nestingLevel >= 1000)
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
				PdfReferenceTable_old._nestingLevel--;
			}
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06000E86 RID: 3718 RVA: 0x00039210 File Offset: 0x00037410
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

		// Token: 0x040008DC RID: 2268
		private readonly PdfDocument _document;

		// Token: 0x040008DD RID: 2269
		public Dictionary<PdfObjectID, PdfReference> ObjectTable = new Dictionary<PdfObjectID, PdfReference>();

		// Token: 0x040008DE RID: 2270
		private bool _isUnderConstruction;

		// Token: 0x040008DF RID: 2271
		internal int _maxObjectNumber;

		// Token: 0x040008E0 RID: 2272
		private static int _nestingLevel;

		// Token: 0x040008E1 RID: 2273
		private Dictionary<PdfItem, object> _overflow = new Dictionary<PdfItem, object>();

		// Token: 0x040008E2 RID: 2274
		private PdfDictionary _deadObject;
	}
}
