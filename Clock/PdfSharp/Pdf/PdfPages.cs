using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001B0 RID: 432
	[DebuggerDisplay("(PageCount={Count})")]
	public sealed class PdfPages : PdfDictionary, IEnumerable<PdfPage>, IEnumerable
	{
		// Token: 0x06000E29 RID: 3625 RVA: 0x00037775 File Offset: 0x00035975
		internal PdfPages(PdfDocument document)
			: base(document)
		{
			base.Elements.SetName("/Type", "/Pages");
			base.Elements["/Count"] = new PdfInteger(0);
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x000377A9 File Offset: 0x000359A9
		internal PdfPages(PdfDictionary dictionary)
			: base(dictionary)
		{
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06000E2B RID: 3627 RVA: 0x000377B2 File Offset: 0x000359B2
		public int Count
		{
			get
			{
				return this.PagesArray.Elements.Count;
			}
		}

		// Token: 0x170004CE RID: 1230
		public PdfPage this[int index]
		{
			get
			{
				if (index < 0 || index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", index, PSSR.PageIndexOutOfRange);
				}
				PdfDictionary pdfDictionary = (PdfDictionary)((PdfReference)this.PagesArray.Elements[index]).Value;
				if (!(pdfDictionary is PdfPage))
				{
					pdfDictionary = new PdfPage(pdfDictionary);
				}
				return (PdfPage)pdfDictionary;
			}
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x0003782C File Offset: 0x00035A2C
		internal PdfPage FindPage(PdfObjectID id)
		{
			PdfPage pdfPage = null;
			foreach (PdfItem pdfItem in this.PagesArray)
			{
				PdfReference pdfReference = pdfItem as PdfReference;
				if (pdfReference != null)
				{
					PdfDictionary pdfDictionary = pdfReference.Value as PdfDictionary;
					if (pdfDictionary != null && pdfDictionary.ObjectID == id)
					{
						pdfPage = (pdfDictionary as PdfPage) ?? new PdfPage(pdfDictionary);
						break;
					}
				}
			}
			return pdfPage;
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x000378B4 File Offset: 0x00035AB4
		public PdfPage Add()
		{
			PdfPage pdfPage = new PdfPage();
			this.Insert(this.Count, pdfPage);
			return pdfPage;
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x000378D6 File Offset: 0x00035AD6
		public PdfPage Add(PdfPage page)
		{
			return this.Insert(this.Count, page);
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x000378E8 File Offset: 0x00035AE8
		public PdfPage Insert(int index)
		{
			PdfPage pdfPage = new PdfPage();
			this.Insert(index, pdfPage);
			return pdfPage;
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x00037908 File Offset: 0x00035B08
		public PdfPage Insert(int index, PdfPage page)
		{
			if (page == null)
			{
				throw new ArgumentNullException("page");
			}
			if (page.Owner == this.Owner)
			{
				int count = this.Count;
				for (int i = 0; i < count; i++)
				{
					if (object.ReferenceEquals(this[i], page))
					{
						throw new InvalidOperationException(PSSR.MultiplePageInsert);
					}
				}
				this.Owner._irefTable.Add(page);
				this.PagesArray.Elements.Insert(index, page.Reference);
				base.Elements.SetInteger("/Count", this.PagesArray.Elements.Count);
				return page;
			}
			if (page.Owner == null)
			{
				page.Document = this.Owner;
				this.Owner._irefTable.Add(page);
				this.PagesArray.Elements.Insert(index, page.Reference);
				base.Elements.SetInteger("/Count", this.PagesArray.Elements.Count);
			}
			else
			{
				PdfPage pdfPage = page;
				page = this.ImportExternalPage(pdfPage);
				this.Owner._irefTable.Add(page);
				PdfImportedObjectTable importedObjectTable = this.Owner.FormTable.GetImportedObjectTable(pdfPage);
				importedObjectTable.Add(pdfPage.ObjectID, page.Reference);
				this.PagesArray.Elements.Insert(index, page.Reference);
				base.Elements.SetInteger("/Count", this.PagesArray.Elements.Count);
				PdfAnnotations.FixImportedAnnotation(page);
			}
			if (this.Owner.Settings.TrimMargins.AreSet)
			{
				page.TrimMargins = this.Owner.Settings.TrimMargins;
			}
			return page;
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x00037AB4 File Offset: 0x00035CB4
		public void InsertRange(int index, PdfDocument document, int startIndex, int pageCount)
		{
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (index < 0 || index > this.Count)
			{
				throw new ArgumentOutOfRangeException("index", "Argument 'index' out of range.");
			}
			int pageCount2 = document.PageCount;
			if (startIndex < 0 || startIndex + pageCount > pageCount2)
			{
				throw new ArgumentOutOfRangeException("startIndex", "Argument 'startIndex' out of range.");
			}
			if (pageCount > pageCount2)
			{
				throw new ArgumentOutOfRangeException("pageCount", "Argument 'pageCount' out of range.");
			}
			PdfPage[] array = new PdfPage[pageCount];
			PdfPage[] array2 = new PdfPage[pageCount];
			int num = 0;
			int num2 = index;
			for (int i = startIndex; i < startIndex + pageCount; i++)
			{
				PdfPage pdfPage = document.Pages[i];
				PdfPage pdfPage2 = this.ImportExternalPage(pdfPage);
				array[num] = pdfPage2;
				array2[num] = pdfPage;
				this.Owner._irefTable.Add(pdfPage2);
				PdfImportedObjectTable importedObjectTable = this.Owner.FormTable.GetImportedObjectTable(pdfPage);
				importedObjectTable.Add(pdfPage.ObjectID, pdfPage2.Reference);
				this.PagesArray.Elements.Insert(num2, pdfPage2.Reference);
				if (this.Owner.Settings.TrimMargins.AreSet)
				{
					pdfPage2.TrimMargins = this.Owner.Settings.TrimMargins;
				}
				num++;
				num2++;
			}
			base.Elements.SetInteger("/Count", this.PagesArray.Elements.Count);
			int num3 = 0;
			for (int j = startIndex; j < startIndex + pageCount; j++)
			{
				PdfPage pdfPage3 = document.Pages[j];
				PdfPage pdfPage4 = array[num3];
				PdfArray array3 = pdfPage3.Elements.GetArray("/Annots");
				if (array3 != null)
				{
					PdfAnnotations pdfAnnotations = new PdfAnnotations(this.Owner);
					int count = array3.Elements.Count;
					for (int k = 0; k < count; k++)
					{
						PdfDictionary dictionary = array3.Elements.GetDictionary(k);
						if (dictionary != null)
						{
							string @string = dictionary.Elements.GetString("/Subtype");
							if (@string == "/Link")
							{
								bool flag = false;
								PdfLinkAnnotation pdfLinkAnnotation = new PdfLinkAnnotation(this.Owner);
								PdfName[] keyNames = dictionary.Elements.KeyNames;
								foreach (PdfName pdfName in keyNames)
								{
									string value;
									switch (value = pdfName.Value)
									{
									case "/BS":
										pdfLinkAnnotation.Elements.Add("/BS", new PdfLiteral("<</W 0>>"));
										break;
									case "/F":
									{
										PdfItem pdfItem = dictionary.Elements.GetValue("/F");
										pdfLinkAnnotation.Elements.Add("/F", pdfItem.Clone());
										break;
									}
									case "/Rect":
									{
										PdfItem pdfItem = dictionary.Elements.GetValue("/Rect");
										pdfLinkAnnotation.Elements.Add("/Rect", pdfItem.Clone());
										break;
									}
									case "/StructParent":
									{
										PdfItem pdfItem = dictionary.Elements.GetValue("/StructParent");
										pdfLinkAnnotation.Elements.Add("/StructParent", pdfItem.Clone());
										break;
									}
									case "/Dest":
									{
										PdfItem pdfItem = dictionary.Elements.GetValue("/Dest");
										pdfItem = pdfItem.Clone();
										PdfArray pdfArray = pdfItem as PdfArray;
										if (pdfArray != null && pdfArray.Elements.Count == 5)
										{
											PdfReference pdfReference = pdfArray.Elements[0] as PdfReference;
											if (pdfReference != null)
											{
												pdfReference = PdfPages.RemapReference(array, array2, pdfReference);
												if (pdfReference != null)
												{
													pdfArray.Elements[0] = pdfReference;
													pdfLinkAnnotation.Elements.Add("/Dest", pdfArray);
													flag = true;
												}
											}
										}
										break;
									}
									}
								}
								if (flag)
								{
									pdfAnnotations.Add(pdfLinkAnnotation);
								}
							}
						}
					}
					if (pdfAnnotations.Count > 0)
					{
						pdfPage4.Elements.Add("/Annots", pdfAnnotations);
					}
				}
				num3++;
			}
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x00037F24 File Offset: 0x00036124
		public void InsertRange(int index, PdfDocument document)
		{
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			this.InsertRange(index, document, 0, document.PageCount);
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x00037F43 File Offset: 0x00036143
		public void InsertRange(int index, PdfDocument document, int startIndex)
		{
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			this.InsertRange(index, document, startIndex, document.PageCount - startIndex);
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x00037F64 File Offset: 0x00036164
		public void Remove(PdfPage page)
		{
			this.PagesArray.Elements.Remove(page.Reference);
			base.Elements.SetInteger("/Count", this.PagesArray.Elements.Count);
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x00037F9D File Offset: 0x0003619D
		public void RemoveAt(int index)
		{
			this.PagesArray.Elements.RemoveAt(index);
			base.Elements.SetInteger("/Count", this.PagesArray.Elements.Count);
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x00037FD0 File Offset: 0x000361D0
		public void MovePage(int oldIndex, int newIndex)
		{
			if (oldIndex < 0 || oldIndex >= this.Count)
			{
				throw new ArgumentOutOfRangeException("oldIndex");
			}
			if (newIndex < 0 || newIndex >= this.Count)
			{
				throw new ArgumentOutOfRangeException("newIndex");
			}
			if (oldIndex == newIndex)
			{
				return;
			}
			PdfReference pdfReference = (PdfReference)this._pagesArray.Elements[oldIndex];
			this._pagesArray.Elements.RemoveAt(oldIndex);
			this._pagesArray.Elements.Insert(newIndex, pdfReference);
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x0003804C File Offset: 0x0003624C
		private PdfPage ImportExternalPage(PdfPage importPage)
		{
			if (importPage.Owner._openMode != PdfDocumentOpenMode.Import)
			{
				throw new InvalidOperationException("A PDF document must be opened with PdfDocumentOpenMode.Import to import pages from it.");
			}
			PdfPage pdfPage = new PdfPage(this._document);
			this.CloneElement(pdfPage, importPage, "/Resources", false);
			this.CloneElement(pdfPage, importPage, "/Contents", false);
			this.CloneElement(pdfPage, importPage, "/MediaBox", true);
			this.CloneElement(pdfPage, importPage, "/CropBox", true);
			this.CloneElement(pdfPage, importPage, "/Rotate", true);
			this.CloneElement(pdfPage, importPage, "/BleedBox", true);
			this.CloneElement(pdfPage, importPage, "/TrimBox", true);
			this.CloneElement(pdfPage, importPage, "/ArtBox", true);
			return pdfPage;
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x000380F0 File Offset: 0x000362F0
		private void CloneElement(PdfPage page, PdfPage importPage, string key, bool deepcopy)
		{
			PdfItem pdfItem = importPage.Elements[key];
			if (pdfItem != null)
			{
				PdfImportedObjectTable pdfImportedObjectTable = null;
				if (!deepcopy)
				{
					pdfImportedObjectTable = this.Owner.FormTable.GetImportedObjectTable(importPage);
				}
				if (pdfItem is PdfReference)
				{
					pdfItem = ((PdfReference)pdfItem).Value;
				}
				if (pdfItem is PdfObject)
				{
					PdfObject pdfObject = (PdfObject)pdfItem;
					if (deepcopy)
					{
						pdfObject = PdfObject.DeepCopyClosure(this._document, pdfObject);
					}
					else
					{
						if (pdfObject.Owner == null)
						{
							pdfObject.Document = importPage.Owner;
						}
						pdfObject = PdfObject.ImportClosure(pdfImportedObjectTable, page.Owner, pdfObject);
					}
					if (pdfObject.Reference == null)
					{
						page.Elements[key] = pdfObject;
						return;
					}
					page.Elements[key] = pdfObject.Reference;
					return;
				}
				else
				{
					page.Elements[key] = pdfItem.Clone();
				}
			}
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x000381BC File Offset: 0x000363BC
		private static PdfReference RemapReference(PdfPage[] newPages, PdfPage[] impPages, PdfReference iref)
		{
			for (int i = 0; i < newPages.Length; i++)
			{
				if (impPages[i].Reference == iref)
				{
					return newPages[i].Reference;
				}
			}
			return null;
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06000E3B RID: 3643 RVA: 0x000381EC File Offset: 0x000363EC
		public PdfArray PagesArray
		{
			get
			{
				if (this._pagesArray == null)
				{
					this._pagesArray = (PdfArray)base.Elements.GetValue("/Kids", VCF.Create);
				}
				return this._pagesArray;
			}
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x00038218 File Offset: 0x00036418
		internal void FlattenPageTree()
		{
			PdfPage.InheritedValues inheritedValues = default(PdfPage.InheritedValues);
			PdfPage.InheritValues(this, ref inheritedValues);
			PdfDictionary[] kids = this.GetKids(base.Reference, inheritedValues, null);
			PdfArray pdfArray = new PdfArray(this.Owner);
			foreach (PdfDictionary pdfDictionary in kids)
			{
				pdfDictionary.Elements["/Parent"] = base.Reference;
				pdfArray.Elements.Add(pdfDictionary.Reference);
			}
			base.Elements.SetName("/Type", "/Pages");
			base.Elements.SetValue("/Kids", pdfArray);
			base.Elements.SetInteger("/Count", pdfArray.Elements.Count);
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x000382D4 File Offset: 0x000364D4
		private PdfDictionary[] GetKids(PdfReference iref, PdfPage.InheritedValues values, PdfDictionary parent)
		{
			PdfDictionary pdfDictionary = (PdfDictionary)iref.Value;
			string name = pdfDictionary.Elements.GetName("/Type");
			if (name == "/Page")
			{
				PdfPage.InheritValues(pdfDictionary, values);
				return new PdfDictionary[] { pdfDictionary };
			}
			if (string.IsNullOrEmpty(name))
			{
				PdfPage.InheritValues(pdfDictionary, values);
				return new PdfDictionary[] { pdfDictionary };
			}
			PdfPage.InheritValues(pdfDictionary, ref values);
			List<PdfDictionary> list = new List<PdfDictionary>();
			PdfArray pdfArray = pdfDictionary.Elements["/Kids"] as PdfArray;
			if (pdfArray == null)
			{
				PdfReference pdfReference = pdfDictionary.Elements["/Kids"] as PdfReference;
				pdfArray = pdfReference.Value as PdfArray;
			}
			foreach (PdfItem pdfItem in pdfArray)
			{
				PdfReference pdfReference2 = (PdfReference)pdfItem;
				list.AddRange(this.GetKids(pdfReference2, values, pdfDictionary));
			}
			int count = list.Count;
			return list.ToArray();
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x000383E8 File Offset: 0x000365E8
		internal override void PrepareForSave()
		{
			int count = this._pagesArray.Elements.Count;
			for (int i = 0; i < count; i++)
			{
				PdfPage pdfPage = this[i];
				pdfPage.PrepareForSave();
			}
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x00038420 File Offset: 0x00036620
		public new IEnumerator<PdfPage> GetEnumerator()
		{
			return new PdfPages.PdfPagesEnumerator(this);
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06000E40 RID: 3648 RVA: 0x00038428 File Offset: 0x00036628
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfPages.Keys.Meta;
			}
		}

		// Token: 0x040008CC RID: 2252
		private PdfArray _pagesArray;

		// Token: 0x020001B1 RID: 433
		private class PdfPagesEnumerator : IEnumerator<PdfPage>, IDisposable, IEnumerator
		{
			// Token: 0x06000E41 RID: 3649 RVA: 0x0003842F File Offset: 0x0003662F
			internal PdfPagesEnumerator(PdfPages list)
			{
				this._list = list;
				this._index = -1;
			}

			// Token: 0x06000E42 RID: 3650 RVA: 0x00038448 File Offset: 0x00036648
			public bool MoveNext()
			{
				if (this._index < this._list.Count - 1)
				{
					this._index++;
					this._currentElement = this._list[this._index];
					return true;
				}
				this._index = this._list.Count;
				return false;
			}

			// Token: 0x06000E43 RID: 3651 RVA: 0x000384A3 File Offset: 0x000366A3
			public void Reset()
			{
				this._currentElement = null;
				this._index = -1;
			}

			// Token: 0x170004D1 RID: 1233
			// (get) Token: 0x06000E44 RID: 3652 RVA: 0x000384B3 File Offset: 0x000366B3
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x170004D2 RID: 1234
			// (get) Token: 0x06000E45 RID: 3653 RVA: 0x000384BB File Offset: 0x000366BB
			public PdfPage Current
			{
				get
				{
					if (this._index == -1 || this._index >= this._list.Count)
					{
						throw new InvalidOperationException(PSSR.ListEnumCurrentOutOfRange);
					}
					return this._currentElement;
				}
			}

			// Token: 0x06000E46 RID: 3654 RVA: 0x000384EA File Offset: 0x000366EA
			public void Dispose()
			{
			}

			// Token: 0x040008CD RID: 2253
			private PdfPage _currentElement;

			// Token: 0x040008CE RID: 2254
			private int _index;

			// Token: 0x040008CF RID: 2255
			private readonly PdfPages _list;
		}

		// Token: 0x020001B2 RID: 434
		internal sealed class Keys : PdfPage.InheritablePageKeys
		{
			// Token: 0x170004D3 RID: 1235
			// (get) Token: 0x06000E47 RID: 3655 RVA: 0x000384EC File Offset: 0x000366EC
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfPages.Keys._meta) == null)
					{
						dictionaryMeta = (PdfPages.Keys._meta = KeysBase.CreateMeta(typeof(PdfPages.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040008D0 RID: 2256
			[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Pages")]
			public const string Type = "/Type";

			// Token: 0x040008D1 RID: 2257
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required)]
			public const string Parent = "/Parent";

			// Token: 0x040008D2 RID: 2258
			[KeyInfo(KeyType.Array | KeyType.Required)]
			public const string Kids = "/Kids";

			// Token: 0x040008D3 RID: 2259
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string Count = "/Count";

			// Token: 0x040008D4 RID: 2260
			private static DictionaryMeta _meta;
		}
	}
}
