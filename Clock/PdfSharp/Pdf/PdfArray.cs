using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020000CB RID: 203
	[DebuggerDisplay("{DebuggerDisplay}")]
	public class PdfArray : PdfObject, IEnumerable<PdfItem>, IEnumerable
	{
		// Token: 0x06000879 RID: 2169 RVA: 0x000202C1 File Offset: 0x0001E4C1
		public PdfArray()
		{
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x000202C9 File Offset: 0x0001E4C9
		public PdfArray(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x000202D4 File Offset: 0x0001E4D4
		public PdfArray(PdfDocument document, params PdfItem[] items)
			: base(document)
		{
			foreach (PdfItem pdfItem in items)
			{
				this.Elements.Add(pdfItem);
			}
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x00020308 File Offset: 0x0001E508
		protected PdfArray(PdfArray array)
			: base(array)
		{
			if (array._elements != null)
			{
				array._elements.ChangeOwner(this);
			}
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x00020325 File Offset: 0x0001E525
		public new PdfArray Clone()
		{
			return (PdfArray)this.Copy();
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x00020334 File Offset: 0x0001E534
		protected override object Copy()
		{
			PdfArray pdfArray = (PdfArray)base.Copy();
			if (pdfArray._elements != null)
			{
				pdfArray._elements = pdfArray._elements.Clone();
				int count = pdfArray._elements.Count;
				for (int i = 0; i < count; i++)
				{
					PdfItem pdfItem = pdfArray._elements[i];
					if (pdfItem is PdfObject)
					{
						pdfArray._elements[i] = pdfItem.Clone();
					}
				}
			}
			return pdfArray;
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x0600087F RID: 2175 RVA: 0x000203A8 File Offset: 0x0001E5A8
		public PdfArray.ArrayElements Elements
		{
			get
			{
				PdfArray.ArrayElements arrayElements;
				if ((arrayElements = this._elements) == null)
				{
					arrayElements = (this._elements = new PdfArray.ArrayElements(this));
				}
				return arrayElements;
			}
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x000203CE File Offset: 0x0001E5CE
		public virtual IEnumerator<PdfItem> GetEnumerator()
		{
			return this.Elements.GetEnumerator();
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x000203DB File Offset: 0x0001E5DB
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x000203E4 File Offset: 0x0001E5E4
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[ ");
			int count = this.Elements.Count;
			for (int i = 0; i < count; i++)
			{
				stringBuilder.Append(this.Elements[i] + " ");
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x0002044C File Offset: 0x0001E64C
		internal override void WriteObject(PdfWriter writer)
		{
			writer.WriteBeginObject(this);
			int count = this.Elements.Count;
			for (int i = 0; i < count; i++)
			{
				PdfItem pdfItem = this.Elements[i];
				pdfItem.WriteObject(writer);
			}
			writer.WriteEndObject();
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06000884 RID: 2180 RVA: 0x00020494 File Offset: 0x0001E694
		private string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "array({0},[{1}])", new object[]
				{
					base.ObjectID.DebuggerDisplay,
					(this._elements == null) ? 0 : this._elements.Count
				});
			}
		}

		// Token: 0x04000464 RID: 1124
		private PdfArray.ArrayElements _elements;

		// Token: 0x020000CC RID: 204
		public sealed class ArrayElements : IList<PdfItem>, ICollection<PdfItem>, IEnumerable<PdfItem>, IEnumerable, ICloneable
		{
			// Token: 0x06000885 RID: 2181 RVA: 0x000204E7 File Offset: 0x0001E6E7
			internal ArrayElements(PdfArray array)
			{
				this._elements = new List<PdfItem>();
				this._ownerArray = array;
			}

			// Token: 0x06000886 RID: 2182 RVA: 0x00020504 File Offset: 0x0001E704
			object ICloneable.Clone()
			{
				PdfArray.ArrayElements arrayElements = (PdfArray.ArrayElements)base.MemberwiseClone();
				arrayElements._elements = new List<PdfItem>(arrayElements._elements);
				arrayElements._ownerArray = null;
				return arrayElements;
			}

			// Token: 0x06000887 RID: 2183 RVA: 0x00020536 File Offset: 0x0001E736
			public PdfArray.ArrayElements Clone()
			{
				return (PdfArray.ArrayElements)((ICloneable)this).Clone();
			}

			// Token: 0x06000888 RID: 2184 RVA: 0x00020543 File Offset: 0x0001E743
			internal void ChangeOwner(PdfArray array)
			{
				PdfArray ownerArray = this._ownerArray;
				this._ownerArray = array;
				array._elements = this;
			}

			// Token: 0x06000889 RID: 2185 RVA: 0x0002055C File Offset: 0x0001E75C
			public bool GetBoolean(int index)
			{
				if (index < 0 || index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
				}
				object obj = this[index];
				if (obj == null)
				{
					return false;
				}
				PdfBoolean pdfBoolean = obj as PdfBoolean;
				if (pdfBoolean != null)
				{
					return pdfBoolean.Value;
				}
				PdfBooleanObject pdfBooleanObject = obj as PdfBooleanObject;
				if (pdfBooleanObject != null)
				{
					return pdfBooleanObject.Value;
				}
				throw new InvalidCastException("GetBoolean: Object is not a boolean.");
			}

			// Token: 0x0600088A RID: 2186 RVA: 0x000205C8 File Offset: 0x0001E7C8
			public int GetInteger(int index)
			{
				if (index < 0 || index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
				}
				object obj = this[index];
				if (obj == null)
				{
					return 0;
				}
				PdfInteger pdfInteger = obj as PdfInteger;
				if (pdfInteger != null)
				{
					return pdfInteger.Value;
				}
				PdfIntegerObject pdfIntegerObject = obj as PdfIntegerObject;
				if (pdfIntegerObject != null)
				{
					return pdfIntegerObject.Value;
				}
				throw new InvalidCastException("GetInteger: Object is not an integer.");
			}

			// Token: 0x0600088B RID: 2187 RVA: 0x00020634 File Offset: 0x0001E834
			public double GetReal(int index)
			{
				if (index < 0 || index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
				}
				object obj = this[index];
				if (obj == null)
				{
					return 0.0;
				}
				PdfReal pdfReal = obj as PdfReal;
				if (pdfReal != null)
				{
					return pdfReal.Value;
				}
				PdfRealObject pdfRealObject = obj as PdfRealObject;
				if (pdfRealObject != null)
				{
					return pdfRealObject.Value;
				}
				PdfInteger pdfInteger = obj as PdfInteger;
				if (pdfInteger != null)
				{
					return (double)pdfInteger.Value;
				}
				PdfIntegerObject pdfIntegerObject = obj as PdfIntegerObject;
				if (pdfIntegerObject != null)
				{
					return (double)pdfIntegerObject.Value;
				}
				throw new InvalidCastException("GetReal: Object is not a number.");
			}

			// Token: 0x0600088C RID: 2188 RVA: 0x000206CC File Offset: 0x0001E8CC
			public string GetString(int index)
			{
				if (index < 0 || index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
				}
				object obj = this[index];
				if (obj == null)
				{
					return string.Empty;
				}
				PdfString pdfString = obj as PdfString;
				if (pdfString != null)
				{
					return pdfString.Value;
				}
				PdfStringObject pdfStringObject = obj as PdfStringObject;
				if (pdfStringObject != null)
				{
					return pdfStringObject.Value;
				}
				throw new InvalidCastException("GetString: Object is not a string.");
			}

			// Token: 0x0600088D RID: 2189 RVA: 0x0002073C File Offset: 0x0001E93C
			public string GetName(int index)
			{
				if (index < 0 || index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
				}
				object obj = this[index];
				if (obj == null)
				{
					return string.Empty;
				}
				PdfName pdfName = obj as PdfName;
				if (pdfName != null)
				{
					return pdfName.Value;
				}
				PdfNameObject pdfNameObject = obj as PdfNameObject;
				if (pdfNameObject != null)
				{
					return pdfNameObject.Value;
				}
				throw new InvalidCastException("GetName: Object is not a name.");
			}

			// Token: 0x0600088E RID: 2190 RVA: 0x000207B8 File Offset: 0x0001E9B8
			[Obsolete("Use GetObject, GetDictionary, GetArray, or GetReference")]
			public PdfObject GetIndirectObject(int index)
			{
				if (index < 0 || index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
				}
				PdfReference pdfReference = this[index] as PdfReference;
				if (pdfReference != null)
				{
					return pdfReference.Value;
				}
				return null;
			}

			// Token: 0x0600088F RID: 2191 RVA: 0x00020800 File Offset: 0x0001EA00
			public PdfObject GetObject(int index)
			{
				if (index < 0 || index >= this.Count)
				{
					throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
				}
				PdfItem pdfItem = this[index];
				PdfReference pdfReference = pdfItem as PdfReference;
				if (pdfReference != null)
				{
					return pdfReference.Value;
				}
				return pdfItem as PdfObject;
			}

			// Token: 0x06000890 RID: 2192 RVA: 0x0002084F File Offset: 0x0001EA4F
			public PdfDictionary GetDictionary(int index)
			{
				return this.GetObject(index) as PdfDictionary;
			}

			// Token: 0x06000891 RID: 2193 RVA: 0x0002085D File Offset: 0x0001EA5D
			public PdfArray GetArray(int index)
			{
				return this.GetObject(index) as PdfArray;
			}

			// Token: 0x06000892 RID: 2194 RVA: 0x0002086C File Offset: 0x0001EA6C
			public PdfReference GetReference(int index)
			{
				PdfItem pdfItem = this[index];
				return pdfItem as PdfReference;
			}

			// Token: 0x17000344 RID: 836
			// (get) Token: 0x06000893 RID: 2195 RVA: 0x00020887 File Offset: 0x0001EA87
			public PdfItem[] Items
			{
				get
				{
					return this._elements.ToArray();
				}
			}

			// Token: 0x17000345 RID: 837
			// (get) Token: 0x06000894 RID: 2196 RVA: 0x00020894 File Offset: 0x0001EA94
			public bool IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000346 RID: 838
			public PdfItem this[int index]
			{
				get
				{
					return this._elements[index];
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					this._elements[index] = value;
				}
			}

			// Token: 0x06000897 RID: 2199 RVA: 0x000208C2 File Offset: 0x0001EAC2
			public void RemoveAt(int index)
			{
				this._elements.RemoveAt(index);
			}

			// Token: 0x06000898 RID: 2200 RVA: 0x000208D0 File Offset: 0x0001EAD0
			public bool Remove(PdfItem item)
			{
				return this._elements.Remove(item);
			}

			// Token: 0x06000899 RID: 2201 RVA: 0x000208DE File Offset: 0x0001EADE
			public void Insert(int index, PdfItem value)
			{
				this._elements.Insert(index, value);
			}

			// Token: 0x0600089A RID: 2202 RVA: 0x000208ED File Offset: 0x0001EAED
			public bool Contains(PdfItem value)
			{
				return this._elements.Contains(value);
			}

			// Token: 0x0600089B RID: 2203 RVA: 0x000208FB File Offset: 0x0001EAFB
			public void Clear()
			{
				this._elements.Clear();
			}

			// Token: 0x0600089C RID: 2204 RVA: 0x00020908 File Offset: 0x0001EB08
			public int IndexOf(PdfItem value)
			{
				return this._elements.IndexOf(value);
			}

			// Token: 0x0600089D RID: 2205 RVA: 0x00020918 File Offset: 0x0001EB18
			public void Add(PdfItem value)
			{
				PdfObject pdfObject = value as PdfObject;
				if (pdfObject != null && pdfObject.IsIndirect)
				{
					this._elements.Add(pdfObject.Reference);
					return;
				}
				this._elements.Add(value);
			}

			// Token: 0x17000347 RID: 839
			// (get) Token: 0x0600089E RID: 2206 RVA: 0x00020955 File Offset: 0x0001EB55
			public bool IsFixedSize
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000348 RID: 840
			// (get) Token: 0x0600089F RID: 2207 RVA: 0x00020958 File Offset: 0x0001EB58
			public bool IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000349 RID: 841
			// (get) Token: 0x060008A0 RID: 2208 RVA: 0x0002095B File Offset: 0x0001EB5B
			public int Count
			{
				get
				{
					return this._elements.Count;
				}
			}

			// Token: 0x060008A1 RID: 2209 RVA: 0x00020968 File Offset: 0x0001EB68
			public void CopyTo(PdfItem[] array, int index)
			{
				this._elements.CopyTo(array, index);
			}

			// Token: 0x1700034A RID: 842
			// (get) Token: 0x060008A2 RID: 2210 RVA: 0x00020977 File Offset: 0x0001EB77
			public object SyncRoot
			{
				get
				{
					return null;
				}
			}

			// Token: 0x060008A3 RID: 2211 RVA: 0x0002097A File Offset: 0x0001EB7A
			public IEnumerator<PdfItem> GetEnumerator()
			{
				return this._elements.GetEnumerator();
			}

			// Token: 0x060008A4 RID: 2212 RVA: 0x0002098C File Offset: 0x0001EB8C
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this._elements.GetEnumerator();
			}

			// Token: 0x04000465 RID: 1125
			private List<PdfItem> _elements;

			// Token: 0x04000466 RID: 1126
			private PdfArray _ownerArray;
		}
	}
}
