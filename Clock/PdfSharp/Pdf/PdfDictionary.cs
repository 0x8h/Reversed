using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Filters;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020000C5 RID: 197
	[DebuggerDisplay("{DebuggerDisplay}")]
	public class PdfDictionary : PdfObject, IEnumerable<KeyValuePair<string, PdfItem>>, IEnumerable
	{
		// Token: 0x060007FE RID: 2046 RVA: 0x0001E8FC File Offset: 0x0001CAFC
		public PdfDictionary()
		{
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x0001E904 File Offset: 0x0001CB04
		public PdfDictionary(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0001E90D File Offset: 0x0001CB0D
		protected PdfDictionary(PdfDictionary dict)
			: base(dict)
		{
			if (dict._elements != null)
			{
				dict._elements.ChangeOwner(this);
			}
			if (dict._stream != null)
			{
				dict._stream.ChangeOwner(this);
			}
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x0001E93E File Offset: 0x0001CB3E
		public new PdfDictionary Clone()
		{
			return (PdfDictionary)this.Copy();
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0001E94C File Offset: 0x0001CB4C
		protected override object Copy()
		{
			PdfDictionary pdfDictionary = (PdfDictionary)base.Copy();
			if (pdfDictionary._elements != null)
			{
				pdfDictionary._elements = pdfDictionary._elements.Clone();
				pdfDictionary._elements.ChangeOwner(pdfDictionary);
				PdfName[] keyNames = pdfDictionary._elements.KeyNames;
				foreach (PdfName pdfName in keyNames)
				{
					PdfObject pdfObject = pdfDictionary._elements[pdfName] as PdfObject;
					if (pdfObject != null)
					{
						pdfObject = pdfObject.Clone();
						pdfDictionary._elements[pdfName] = pdfObject;
					}
				}
			}
			if (pdfDictionary._stream != null)
			{
				pdfDictionary._stream = pdfDictionary._stream.Clone();
				pdfDictionary._stream.ChangeOwner(pdfDictionary);
			}
			return pdfDictionary;
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x0001EA04 File Offset: 0x0001CC04
		public PdfDictionary.DictionaryElements Elements
		{
			get
			{
				PdfDictionary.DictionaryElements dictionaryElements;
				if ((dictionaryElements = this._elements) == null)
				{
					dictionaryElements = (this._elements = new PdfDictionary.DictionaryElements(this));
				}
				return dictionaryElements;
			}
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x0001EA2A File Offset: 0x0001CC2A
		public IEnumerator<KeyValuePair<string, PdfItem>> GetEnumerator()
		{
			return this.Elements.GetEnumerator();
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x0001EA37 File Offset: 0x0001CC37
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0001EA40 File Offset: 0x0001CC40
		public override string ToString()
		{
			PdfName[] keyNames = this.Elements.KeyNames;
			List<PdfName> list = new List<PdfName>(keyNames);
			list.Sort(PdfName.Comparer);
			list.CopyTo(keyNames, 0);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<< ");
			foreach (PdfName pdfName in keyNames)
			{
				stringBuilder.Append(string.Concat(new object[]
				{
					pdfName,
					" ",
					this.Elements[pdfName],
					" "
				}));
			}
			stringBuilder.Append(">>");
			return stringBuilder.ToString();
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x0001EAF0 File Offset: 0x0001CCF0
		internal override void WriteObject(PdfWriter writer)
		{
			writer.WriteBeginObject(this);
			PdfName[] keyNames = this.Elements.KeyNames;
			foreach (PdfName pdfName in keyNames)
			{
				this.WriteDictionaryElement(writer, pdfName);
			}
			if (this.Stream != null)
			{
				this.WriteDictionaryStream(writer);
			}
			writer.WriteEndObject();
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x0001EB44 File Offset: 0x0001CD44
		internal virtual void WriteDictionaryElement(PdfWriter writer, PdfName key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			PdfItem pdfItem = this.Elements[key];
			key.WriteObject(writer);
			pdfItem.WriteObject(writer);
			writer.NewLine();
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x0001EB86 File Offset: 0x0001CD86
		internal virtual void WriteDictionaryStream(PdfWriter writer)
		{
			writer.WriteStream(this, (writer.Options & PdfWriterOptions.OmitStream) == PdfWriterOptions.OmitStream);
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x0600080A RID: 2058 RVA: 0x0001EB9A File Offset: 0x0001CD9A
		// (set) Token: 0x0600080B RID: 2059 RVA: 0x0001EBA2 File Offset: 0x0001CDA2
		public PdfDictionary.PdfStream Stream
		{
			get
			{
				return this._stream;
			}
			set
			{
				this._stream = value;
			}
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x0001EBAC File Offset: 0x0001CDAC
		public PdfDictionary.PdfStream CreateStream(byte[] value)
		{
			if (this._stream != null)
			{
				throw new InvalidOperationException("The dictionary already has a stream.");
			}
			this._stream = new PdfDictionary.PdfStream(value, this);
			this.Elements["/Length"] = new PdfInteger(this._stream.Length);
			return this._stream;
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x0600080D RID: 2061 RVA: 0x0001EBFF File Offset: 0x0001CDFF
		internal virtual DictionaryMeta Meta
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x0600080E RID: 2062 RVA: 0x0001EC04 File Offset: 0x0001CE04
		private string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "dictionary({0},[{1}])={2}", new object[]
				{
					base.ObjectID.DebuggerDisplay,
					this.Elements.Count,
					this._elements.DebuggerDisplay
				});
			}
		}

		// Token: 0x04000456 RID: 1110
		internal PdfDictionary.DictionaryElements _elements;

		// Token: 0x04000457 RID: 1111
		private PdfDictionary.PdfStream _stream;

		// Token: 0x020000C6 RID: 198
		[DebuggerDisplay("{DebuggerDisplay}")]
		public sealed class DictionaryElements : IDictionary<string, PdfItem>, ICollection<KeyValuePair<string, PdfItem>>, IEnumerable<KeyValuePair<string, PdfItem>>, IEnumerable, ICloneable
		{
			// Token: 0x0600080F RID: 2063 RVA: 0x0001EC5A File Offset: 0x0001CE5A
			internal DictionaryElements(PdfDictionary ownerDictionary)
			{
				this._elements = new Dictionary<string, PdfItem>();
				this._ownerDictionary = ownerDictionary;
			}

			// Token: 0x06000810 RID: 2064 RVA: 0x0001EC74 File Offset: 0x0001CE74
			object ICloneable.Clone()
			{
				PdfDictionary.DictionaryElements dictionaryElements = (PdfDictionary.DictionaryElements)base.MemberwiseClone();
				dictionaryElements._elements = new Dictionary<string, PdfItem>(dictionaryElements._elements);
				dictionaryElements._ownerDictionary = null;
				return dictionaryElements;
			}

			// Token: 0x06000811 RID: 2065 RVA: 0x0001ECA6 File Offset: 0x0001CEA6
			public PdfDictionary.DictionaryElements Clone()
			{
				return (PdfDictionary.DictionaryElements)((ICloneable)this).Clone();
			}

			// Token: 0x06000812 RID: 2066 RVA: 0x0001ECB3 File Offset: 0x0001CEB3
			internal void ChangeOwner(PdfDictionary ownerDictionary)
			{
				PdfDictionary ownerDictionary2 = this._ownerDictionary;
				this._ownerDictionary = ownerDictionary;
				ownerDictionary._elements = this;
			}

			// Token: 0x17000327 RID: 807
			// (get) Token: 0x06000813 RID: 2067 RVA: 0x0001ECCA File Offset: 0x0001CECA
			internal PdfDictionary Owner
			{
				get
				{
					return this._ownerDictionary;
				}
			}

			// Token: 0x06000814 RID: 2068 RVA: 0x0001ECD4 File Offset: 0x0001CED4
			public bool GetBoolean(string key, bool create)
			{
				object obj = this[key];
				if (obj == null)
				{
					if (create)
					{
						this[key] = new PdfBoolean();
					}
					return false;
				}
				if (obj is PdfReference)
				{
					obj = ((PdfReference)obj).Value;
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

			// Token: 0x06000815 RID: 2069 RVA: 0x0001ED3D File Offset: 0x0001CF3D
			public bool GetBoolean(string key)
			{
				return this.GetBoolean(key, false);
			}

			// Token: 0x06000816 RID: 2070 RVA: 0x0001ED47 File Offset: 0x0001CF47
			public void SetBoolean(string key, bool value)
			{
				this[key] = new PdfBoolean(value);
			}

			// Token: 0x06000817 RID: 2071 RVA: 0x0001ED58 File Offset: 0x0001CF58
			public int GetInteger(string key, bool create)
			{
				object obj = this[key];
				if (obj == null)
				{
					if (create)
					{
						this[key] = new PdfInteger();
					}
					return 0;
				}
				PdfReference pdfReference = obj as PdfReference;
				if (pdfReference != null)
				{
					obj = pdfReference.Value;
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

			// Token: 0x06000818 RID: 2072 RVA: 0x0001EDBE File Offset: 0x0001CFBE
			public int GetInteger(string key)
			{
				return this.GetInteger(key, false);
			}

			// Token: 0x06000819 RID: 2073 RVA: 0x0001EDC8 File Offset: 0x0001CFC8
			public void SetInteger(string key, int value)
			{
				this[key] = new PdfInteger(value);
			}

			// Token: 0x0600081A RID: 2074 RVA: 0x0001EDD8 File Offset: 0x0001CFD8
			public double GetReal(string key, bool create)
			{
				object obj = this[key];
				if (obj == null)
				{
					if (create)
					{
						this[key] = new PdfReal();
					}
					return 0.0;
				}
				PdfReference pdfReference = obj as PdfReference;
				if (pdfReference != null)
				{
					obj = pdfReference.Value;
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

			// Token: 0x0600081B RID: 2075 RVA: 0x0001EE70 File Offset: 0x0001D070
			public double GetReal(string key)
			{
				return this.GetReal(key, false);
			}

			// Token: 0x0600081C RID: 2076 RVA: 0x0001EE7A File Offset: 0x0001D07A
			public void SetReal(string key, double value)
			{
				this[key] = new PdfReal(value);
			}

			// Token: 0x0600081D RID: 2077 RVA: 0x0001EE8C File Offset: 0x0001D08C
			public string GetString(string key, bool create)
			{
				object obj = this[key];
				if (obj == null)
				{
					if (create)
					{
						this[key] = new PdfString();
					}
					return "";
				}
				PdfReference pdfReference = obj as PdfReference;
				if (pdfReference != null)
				{
					obj = pdfReference.Value;
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
				throw new InvalidCastException("GetString: Object is not a string.");
			}

			// Token: 0x0600081E RID: 2078 RVA: 0x0001EF2A File Offset: 0x0001D12A
			public string GetString(string key)
			{
				return this.GetString(key, false);
			}

			// Token: 0x0600081F RID: 2079 RVA: 0x0001EF34 File Offset: 0x0001D134
			public bool TryGetString(string key, out string value)
			{
				value = null;
				object obj = this[key];
				if (obj == null)
				{
					return false;
				}
				PdfReference pdfReference = obj as PdfReference;
				if (pdfReference != null)
				{
					obj = pdfReference.Value;
				}
				PdfString pdfString = obj as PdfString;
				if (pdfString != null)
				{
					value = pdfString.Value;
					return true;
				}
				PdfStringObject pdfStringObject = obj as PdfStringObject;
				if (pdfStringObject != null)
				{
					value = pdfStringObject.Value;
					return true;
				}
				PdfName pdfName = obj as PdfName;
				if (pdfName != null)
				{
					value = pdfName.Value;
					return true;
				}
				PdfNameObject pdfNameObject = obj as PdfNameObject;
				if (pdfNameObject != null)
				{
					value = pdfNameObject.Value;
					return true;
				}
				return false;
			}

			// Token: 0x06000820 RID: 2080 RVA: 0x0001EFC5 File Offset: 0x0001D1C5
			public void SetString(string key, string value)
			{
				this[key] = new PdfString(value);
			}

			// Token: 0x06000821 RID: 2081 RVA: 0x0001EFD4 File Offset: 0x0001D1D4
			public string GetName(string key)
			{
				object obj = this[key];
				if (obj == null)
				{
					return string.Empty;
				}
				PdfReference pdfReference = obj as PdfReference;
				if (pdfReference != null)
				{
					obj = pdfReference.Value;
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

			// Token: 0x06000822 RID: 2082 RVA: 0x0001F03B File Offset: 0x0001D23B
			public void SetName(string key, string value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length == 0 || value[0] != '/')
				{
					value = "/" + value;
				}
				this[key] = new PdfName(value);
			}

			// Token: 0x06000823 RID: 2083 RVA: 0x0001F078 File Offset: 0x0001D278
			public PdfRectangle GetRectangle(string key, bool create)
			{
				PdfRectangle pdfRectangle = new PdfRectangle();
				object obj = this[key];
				if (obj == null)
				{
					if (create)
					{
						pdfRectangle = (this[key] = new PdfRectangle());
					}
					return pdfRectangle;
				}
				if (obj is PdfReference)
				{
					obj = ((PdfReference)obj).Value;
				}
				PdfArray pdfArray = obj as PdfArray;
				if (pdfArray != null && pdfArray.Elements.Count == 4)
				{
					pdfRectangle = new PdfRectangle(pdfArray.Elements.GetReal(0), pdfArray.Elements.GetReal(1), pdfArray.Elements.GetReal(2), pdfArray.Elements.GetReal(3));
					this[key] = pdfRectangle;
				}
				else
				{
					pdfRectangle = (PdfRectangle)obj;
				}
				return pdfRectangle;
			}

			// Token: 0x06000824 RID: 2084 RVA: 0x0001F11D File Offset: 0x0001D31D
			public PdfRectangle GetRectangle(string key)
			{
				return this.GetRectangle(key, false);
			}

			// Token: 0x06000825 RID: 2085 RVA: 0x0001F127 File Offset: 0x0001D327
			public void SetRectangle(string key, PdfRectangle rect)
			{
				this._elements[key] = rect;
			}

			// Token: 0x06000826 RID: 2086 RVA: 0x0001F138 File Offset: 0x0001D338
			public XMatrix GetMatrix(string key, bool create)
			{
				XMatrix xmatrix = default(XMatrix);
				object obj = this[key];
				if (obj == null)
				{
					if (create)
					{
						this[key] = new PdfLiteral("[1 0 0 1 0 0]");
					}
					return xmatrix;
				}
				PdfReference pdfReference = obj as PdfReference;
				if (pdfReference != null)
				{
					obj = pdfReference.Value;
				}
				PdfArray pdfArray = obj as PdfArray;
				if (pdfArray != null && pdfArray.Elements.Count == 6)
				{
					xmatrix = new XMatrix(pdfArray.Elements.GetReal(0), pdfArray.Elements.GetReal(1), pdfArray.Elements.GetReal(2), pdfArray.Elements.GetReal(3), pdfArray.Elements.GetReal(4), pdfArray.Elements.GetReal(5));
					return xmatrix;
				}
				if (obj is PdfLiteral)
				{
					throw new NotImplementedException("Parsing matrix from literal.");
				}
				throw new InvalidCastException("Element is not an array with 6 values.");
			}

			// Token: 0x06000827 RID: 2087 RVA: 0x0001F207 File Offset: 0x0001D407
			public XMatrix GetMatrix(string key)
			{
				return this.GetMatrix(key, false);
			}

			// Token: 0x06000828 RID: 2088 RVA: 0x0001F211 File Offset: 0x0001D411
			public void SetMatrix(string key, XMatrix matrix)
			{
				this._elements[key] = PdfLiteral.FromMatrix(matrix);
			}

			// Token: 0x06000829 RID: 2089 RVA: 0x0001F228 File Offset: 0x0001D428
			public DateTime GetDateTime(string key, DateTime defaultValue)
			{
				object obj = this[key];
				if (obj == null)
				{
					return defaultValue;
				}
				PdfReference pdfReference = obj as PdfReference;
				if (pdfReference != null)
				{
					obj = pdfReference.Value;
				}
				PdfDate pdfDate = obj as PdfDate;
				if (pdfDate != null)
				{
					return pdfDate.Value;
				}
				PdfString pdfString = obj as PdfString;
				string text;
				if (pdfString != null)
				{
					text = pdfString.Value;
				}
				else
				{
					PdfStringObject pdfStringObject = obj as PdfStringObject;
					if (pdfStringObject == null)
					{
						throw new InvalidCastException("GetName: Object is not a name.");
					}
					text = pdfStringObject.Value;
				}
				if (text != "")
				{
					try
					{
						defaultValue = Parser.ParseDateTime(text, defaultValue);
					}
					catch
					{
					}
				}
				return defaultValue;
			}

			// Token: 0x0600082A RID: 2090 RVA: 0x0001F2C8 File Offset: 0x0001D4C8
			public void SetDateTime(string key, DateTime value)
			{
				this._elements[key] = new PdfDate(value);
			}

			// Token: 0x0600082B RID: 2091 RVA: 0x0001F2DC File Offset: 0x0001D4DC
			internal int GetEnumFromName(string key, object defaultValue, bool create)
			{
				if (!(defaultValue is Enum))
				{
					throw new ArgumentException("defaultValue");
				}
				object obj = this[key];
				if (obj == null)
				{
					if (create)
					{
						this[key] = new PdfName(defaultValue.ToString());
					}
					return (int)defaultValue;
				}
				return (int)Enum.Parse(defaultValue.GetType(), obj.ToString().Substring(1), false);
			}

			// Token: 0x0600082C RID: 2092 RVA: 0x0001F340 File Offset: 0x0001D540
			internal int GetEnumFromName(string key, object defaultValue)
			{
				return this.GetEnumFromName(key, defaultValue, false);
			}

			// Token: 0x0600082D RID: 2093 RVA: 0x0001F34B File Offset: 0x0001D54B
			internal void SetEnumAsName(string key, object value)
			{
				if (!(value is Enum))
				{
					throw new ArgumentException("value");
				}
				this._elements[key] = new PdfName("/" + value);
			}

			// Token: 0x0600082E RID: 2094 RVA: 0x0001F37C File Offset: 0x0001D57C
			public PdfItem GetValue(string key, VCF options)
			{
				PdfItem pdfItem = this[key];
				PdfReference pdfReference;
				if (pdfItem == null)
				{
					if (options != VCF.None)
					{
						Type valueType = this.GetValueType(key);
						if (valueType == null)
						{
							throw new NotImplementedException("Cannot create value for key: " + key);
						}
						PdfObject pdfObject;
						if (typeof(PdfDictionary).IsAssignableFrom(valueType))
						{
							pdfObject = (pdfItem = this.CreateDictionary(valueType, null));
						}
						else
						{
							if (!typeof(PdfArray).IsAssignableFrom(valueType))
							{
								throw new NotImplementedException("Type other than array or dictionary.");
							}
							pdfObject = (pdfItem = this.CreateArray(valueType, null));
						}
						if (options == VCF.CreateIndirect)
						{
							this._ownerDictionary.Owner._irefTable.Add(pdfObject);
							this[key] = pdfObject.Reference;
						}
						else
						{
							this[key] = pdfObject;
						}
					}
				}
				else if ((pdfReference = pdfItem as PdfReference) != null)
				{
					pdfItem = pdfReference.Value;
					if (pdfItem == null)
					{
						throw new InvalidOperationException("Indirect reference without value.");
					}
					Type valueType2 = this.GetValueType(key);
					if (valueType2 != null && valueType2 != pdfItem.GetType())
					{
						if (typeof(PdfDictionary).IsAssignableFrom(valueType2))
						{
							pdfItem = this.CreateDictionary(valueType2, (PdfDictionary)pdfItem);
						}
						else
						{
							if (!typeof(PdfArray).IsAssignableFrom(valueType2))
							{
								throw new NotImplementedException("Type other than array or dictionary.");
							}
							pdfItem = this.CreateArray(valueType2, (PdfArray)pdfItem);
						}
					}
					return pdfItem;
				}
				else
				{
					PdfDictionary pdfDictionary;
					if ((pdfDictionary = pdfItem as PdfDictionary) != null)
					{
						Type valueType3 = this.GetValueType(key);
						if (pdfDictionary.GetType() != valueType3)
						{
							pdfDictionary = this.CreateDictionary(valueType3, pdfDictionary);
						}
						return pdfDictionary;
					}
					PdfArray pdfArray;
					if ((pdfArray = pdfItem as PdfArray) != null)
					{
						Type valueType4 = this.GetValueType(key);
						if (valueType4 != null && valueType4 != pdfArray.GetType())
						{
							pdfArray = this.CreateArray(valueType4, pdfArray);
						}
						return pdfArray;
					}
				}
				return pdfItem;
			}

			// Token: 0x0600082F RID: 2095 RVA: 0x0001F539 File Offset: 0x0001D739
			public PdfItem GetValue(string key)
			{
				return this.GetValue(key, VCF.None);
			}

			// Token: 0x06000830 RID: 2096 RVA: 0x0001F544 File Offset: 0x0001D744
			private Type GetValueType(string key)
			{
				Type type = null;
				DictionaryMeta meta = this._ownerDictionary.Meta;
				if (meta != null)
				{
					KeyDescriptor keyDescriptor = meta[key];
					if (keyDescriptor != null)
					{
						type = keyDescriptor.GetValueType();
					}
				}
				return type;
			}

			// Token: 0x06000831 RID: 2097 RVA: 0x0001F578 File Offset: 0x0001D778
			private PdfArray CreateArray(Type type, PdfArray oldArray)
			{
				PdfArray pdfArray;
				if (oldArray == null)
				{
					ConstructorInfo constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(PdfDocument) }, null);
					pdfArray = constructorInfo.Invoke(new object[] { this._ownerDictionary.Owner }) as PdfArray;
				}
				else
				{
					ConstructorInfo constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(PdfArray) }, null);
					pdfArray = constructorInfo.Invoke(new object[] { oldArray }) as PdfArray;
				}
				return pdfArray;
			}

			// Token: 0x06000832 RID: 2098 RVA: 0x0001F60C File Offset: 0x0001D80C
			private PdfDictionary CreateDictionary(Type type, PdfDictionary oldDictionary)
			{
				PdfDictionary pdfDictionary;
				if (oldDictionary == null)
				{
					ConstructorInfo constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(PdfDocument) }, null);
					pdfDictionary = constructorInfo.Invoke(new object[] { this._ownerDictionary.Owner }) as PdfDictionary;
				}
				else
				{
					ConstructorInfo constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(PdfDictionary) }, null);
					pdfDictionary = constructorInfo.Invoke(new object[] { oldDictionary }) as PdfDictionary;
				}
				return pdfDictionary;
			}

			// Token: 0x06000833 RID: 2099 RVA: 0x0001F6A0 File Offset: 0x0001D8A0
			private PdfItem CreateValue(Type type, PdfDictionary oldValue)
			{
				ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(PdfDocument) }, null);
				PdfObject pdfObject = constructor.Invoke(new object[] { this._ownerDictionary.Owner }) as PdfObject;
				if (oldValue != null)
				{
					pdfObject.Reference = oldValue.Reference;
					pdfObject.Reference.Value = pdfObject;
					if (pdfObject is PdfDictionary)
					{
						PdfDictionary pdfDictionary = (PdfDictionary)pdfObject;
						pdfDictionary._elements = oldValue._elements;
					}
				}
				return pdfObject;
			}

			// Token: 0x06000834 RID: 2100 RVA: 0x0001F729 File Offset: 0x0001D929
			public void SetValue(string key, PdfItem value)
			{
				this._elements[key] = value;
			}

			// Token: 0x06000835 RID: 2101 RVA: 0x0001F738 File Offset: 0x0001D938
			public PdfObject GetObject(string key)
			{
				PdfItem pdfItem = this[key];
				PdfReference pdfReference = pdfItem as PdfReference;
				if (pdfReference != null)
				{
					return pdfReference.Value;
				}
				return pdfItem as PdfObject;
			}

			// Token: 0x06000836 RID: 2102 RVA: 0x0001F764 File Offset: 0x0001D964
			public PdfDictionary GetDictionary(string key)
			{
				return this.GetObject(key) as PdfDictionary;
			}

			// Token: 0x06000837 RID: 2103 RVA: 0x0001F772 File Offset: 0x0001D972
			public PdfArray GetArray(string key)
			{
				return this.GetObject(key) as PdfArray;
			}

			// Token: 0x06000838 RID: 2104 RVA: 0x0001F780 File Offset: 0x0001D980
			public PdfReference GetReference(string key)
			{
				PdfItem pdfItem = this[key];
				return pdfItem as PdfReference;
			}

			// Token: 0x06000839 RID: 2105 RVA: 0x0001F79B File Offset: 0x0001D99B
			public void SetObject(string key, PdfObject obj)
			{
				if (obj.Reference != null)
				{
					throw new ArgumentException("PdfObject must not be an indirect object.", "obj");
				}
				this[key] = obj;
			}

			// Token: 0x0600083A RID: 2106 RVA: 0x0001F7BD File Offset: 0x0001D9BD
			public void SetReference(string key, PdfObject obj)
			{
				if (obj.Reference == null)
				{
					throw new ArgumentException("PdfObject must be an indirect object.", "obj");
				}
				this[key] = obj.Reference;
			}

			// Token: 0x0600083B RID: 2107 RVA: 0x0001F7E4 File Offset: 0x0001D9E4
			public void SetReference(string key, PdfReference iref)
			{
				if (iref == null)
				{
					throw new ArgumentNullException("iref");
				}
				this[key] = iref;
			}

			// Token: 0x17000328 RID: 808
			// (get) Token: 0x0600083C RID: 2108 RVA: 0x0001F7FC File Offset: 0x0001D9FC
			public bool IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x0600083D RID: 2109 RVA: 0x0001F7FF File Offset: 0x0001D9FF
			public IEnumerator<KeyValuePair<string, PdfItem>> GetEnumerator()
			{
				return this._elements.GetEnumerator();
			}

			// Token: 0x0600083E RID: 2110 RVA: 0x0001F811 File Offset: 0x0001DA11
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable)this._elements).GetEnumerator();
			}

			// Token: 0x17000329 RID: 809
			public PdfItem this[string key]
			{
				get
				{
					PdfItem pdfItem;
					this._elements.TryGetValue(key, out pdfItem);
					return pdfItem;
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					PdfObject pdfObject = value as PdfObject;
					if (pdfObject != null && pdfObject.IsIndirect)
					{
						value = pdfObject.Reference;
					}
					this._elements[key] = value;
				}
			}

			// Token: 0x1700032A RID: 810
			public PdfItem this[PdfName key]
			{
				get
				{
					return this[key.Value];
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					PdfObject pdfObject = value as PdfObject;
					if (pdfObject != null && pdfObject.IsIndirect)
					{
						value = pdfObject.Reference;
					}
					this._elements[key.Value] = value;
				}
			}

			// Token: 0x06000843 RID: 2115 RVA: 0x0001F8D7 File Offset: 0x0001DAD7
			public bool Remove(string key)
			{
				return this._elements.Remove(key);
			}

			// Token: 0x06000844 RID: 2116 RVA: 0x0001F8E5 File Offset: 0x0001DAE5
			public bool Remove(KeyValuePair<string, PdfItem> item)
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000845 RID: 2117 RVA: 0x0001F8EC File Offset: 0x0001DAEC
			public bool ContainsKey(string key)
			{
				return this._elements.ContainsKey(key);
			}

			// Token: 0x06000846 RID: 2118 RVA: 0x0001F8FA File Offset: 0x0001DAFA
			public bool Contains(KeyValuePair<string, PdfItem> item)
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000847 RID: 2119 RVA: 0x0001F901 File Offset: 0x0001DB01
			public void Clear()
			{
				this._elements.Clear();
			}

			// Token: 0x06000848 RID: 2120 RVA: 0x0001F910 File Offset: 0x0001DB10
			public void Add(string key, PdfItem value)
			{
				if (string.IsNullOrEmpty(key))
				{
					throw new ArgumentNullException("key");
				}
				if (key[0] != '/')
				{
					throw new ArgumentException("The key must start with a slash '/'.");
				}
				PdfObject pdfObject = value as PdfObject;
				if (pdfObject != null && pdfObject.IsIndirect)
				{
					value = pdfObject.Reference;
				}
				this._elements.Add(key, value);
			}

			// Token: 0x06000849 RID: 2121 RVA: 0x0001F96D File Offset: 0x0001DB6D
			public void Add(KeyValuePair<string, PdfItem> item)
			{
				this.Add(item.Key, item.Value);
			}

			// Token: 0x1700032B RID: 811
			// (get) Token: 0x0600084A RID: 2122 RVA: 0x0001F984 File Offset: 0x0001DB84
			public PdfName[] KeyNames
			{
				get
				{
					ICollection keys = this._elements.Keys;
					int count = keys.Count;
					string[] array = new string[count];
					keys.CopyTo(array, 0);
					PdfName[] array2 = new PdfName[count];
					for (int i = 0; i < count; i++)
					{
						array2[i] = new PdfName(array[i]);
					}
					return array2;
				}
			}

			// Token: 0x1700032C RID: 812
			// (get) Token: 0x0600084B RID: 2123 RVA: 0x0001F9D8 File Offset: 0x0001DBD8
			public ICollection<string> Keys
			{
				get
				{
					ICollection keys = this._elements.Keys;
					int count = keys.Count;
					string[] array = new string[count];
					keys.CopyTo(array, 0);
					return array;
				}
			}

			// Token: 0x0600084C RID: 2124 RVA: 0x0001FA08 File Offset: 0x0001DC08
			public bool TryGetValue(string key, out PdfItem value)
			{
				return this._elements.TryGetValue(key, out value);
			}

			// Token: 0x1700032D RID: 813
			// (get) Token: 0x0600084D RID: 2125 RVA: 0x0001FA18 File Offset: 0x0001DC18
			public ICollection<PdfItem> Values
			{
				get
				{
					ICollection values = this._elements.Values;
					PdfItem[] array = new PdfItem[values.Count];
					values.CopyTo(array, 0);
					return array;
				}
			}

			// Token: 0x1700032E RID: 814
			// (get) Token: 0x0600084E RID: 2126 RVA: 0x0001FA46 File Offset: 0x0001DC46
			public bool IsFixedSize
			{
				get
				{
					return false;
				}
			}

			// Token: 0x1700032F RID: 815
			// (get) Token: 0x0600084F RID: 2127 RVA: 0x0001FA49 File Offset: 0x0001DC49
			public bool IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000330 RID: 816
			// (get) Token: 0x06000850 RID: 2128 RVA: 0x0001FA4C File Offset: 0x0001DC4C
			public int Count
			{
				get
				{
					return this._elements.Count;
				}
			}

			// Token: 0x06000851 RID: 2129 RVA: 0x0001FA59 File Offset: 0x0001DC59
			public void CopyTo(KeyValuePair<string, PdfItem>[] array, int arrayIndex)
			{
				throw new NotImplementedException();
			}

			// Token: 0x17000331 RID: 817
			// (get) Token: 0x06000852 RID: 2130 RVA: 0x0001FA60 File Offset: 0x0001DC60
			public object SyncRoot
			{
				get
				{
					return null;
				}
			}

			// Token: 0x17000332 RID: 818
			// (get) Token: 0x06000853 RID: 2131 RVA: 0x0001FA64 File Offset: 0x0001DC64
			internal string DebuggerDisplay
			{
				get
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "key={0}:(", new object[] { this._elements.Count });
					bool flag = false;
					ICollection<string> keys = this._elements.Keys;
					foreach (string text in keys)
					{
						if (flag)
						{
							stringBuilder.Append(' ');
						}
						flag = true;
						stringBuilder.Append(text);
					}
					stringBuilder.Append(")");
					return stringBuilder.ToString();
				}
			}

			// Token: 0x04000458 RID: 1112
			private Dictionary<string, PdfItem> _elements;

			// Token: 0x04000459 RID: 1113
			private PdfDictionary _ownerDictionary;
		}

		// Token: 0x020000C7 RID: 199
		public sealed class PdfStream
		{
			// Token: 0x06000854 RID: 2132 RVA: 0x0001FB18 File Offset: 0x0001DD18
			internal PdfStream(PdfDictionary ownerDictionary)
			{
				if (ownerDictionary == null)
				{
					throw new ArgumentNullException("ownerDictionary");
				}
				this._ownerDictionary = ownerDictionary;
			}

			// Token: 0x06000855 RID: 2133 RVA: 0x0001FB35 File Offset: 0x0001DD35
			internal PdfStream(byte[] value, PdfDictionary owner)
				: this(owner)
			{
				this._value = value;
			}

			// Token: 0x06000856 RID: 2134 RVA: 0x0001FB48 File Offset: 0x0001DD48
			public PdfDictionary.PdfStream Clone()
			{
				PdfDictionary.PdfStream pdfStream = (PdfDictionary.PdfStream)base.MemberwiseClone();
				pdfStream._ownerDictionary = null;
				if (pdfStream._value != null)
				{
					pdfStream._value = new byte[pdfStream._value.Length];
					this._value.CopyTo(pdfStream._value, 0);
				}
				return pdfStream;
			}

			// Token: 0x06000857 RID: 2135 RVA: 0x0001FB96 File Offset: 0x0001DD96
			internal void ChangeOwner(PdfDictionary dict)
			{
				PdfDictionary ownerDictionary = this._ownerDictionary;
				this._ownerDictionary = dict;
				this._ownerDictionary._stream = this;
			}

			// Token: 0x17000333 RID: 819
			// (get) Token: 0x06000858 RID: 2136 RVA: 0x0001FBB2 File Offset: 0x0001DDB2
			public int Length
			{
				get
				{
					if (this._value == null)
					{
						return 0;
					}
					return this._value.Length;
				}
			}

			// Token: 0x17000334 RID: 820
			// (get) Token: 0x06000859 RID: 2137 RVA: 0x0001FBC8 File Offset: 0x0001DDC8
			internal bool HasDecodeParams
			{
				get
				{
					return this._ownerDictionary.Elements.GetDictionary("/DecodeParms") != null;
				}
			}

			// Token: 0x17000335 RID: 821
			// (get) Token: 0x0600085A RID: 2138 RVA: 0x0001FBF4 File Offset: 0x0001DDF4
			internal int DecodePredictor
			{
				get
				{
					PdfDictionary dictionary = this._ownerDictionary.Elements.GetDictionary("/DecodeParms");
					if (dictionary != null)
					{
						return dictionary.Elements.GetInteger("/Predictor");
					}
					return 0;
				}
			}

			// Token: 0x17000336 RID: 822
			// (get) Token: 0x0600085B RID: 2139 RVA: 0x0001FC2C File Offset: 0x0001DE2C
			internal int DecodeColumns
			{
				get
				{
					PdfDictionary dictionary = this._ownerDictionary.Elements.GetDictionary("/DecodeParms");
					if (dictionary != null)
					{
						return dictionary.Elements.GetInteger("/Columns");
					}
					return 0;
				}
			}

			// Token: 0x17000337 RID: 823
			// (get) Token: 0x0600085C RID: 2140 RVA: 0x0001FC64 File Offset: 0x0001DE64
			// (set) Token: 0x0600085D RID: 2141 RVA: 0x0001FC6C File Offset: 0x0001DE6C
			public byte[] Value
			{
				get
				{
					return this._value;
				}
				set
				{
					if (value == null)
					{
						throw new ArgumentNullException("value");
					}
					this._value = value;
					this._ownerDictionary.Elements.SetInteger("/Length", value.Length);
				}
			}

			// Token: 0x17000338 RID: 824
			// (get) Token: 0x0600085E RID: 2142 RVA: 0x0001FC9C File Offset: 0x0001DE9C
			public byte[] UnfilteredValue
			{
				get
				{
					byte[] array = null;
					if (this._value != null)
					{
						PdfItem pdfItem = this._ownerDictionary.Elements["/Filter"];
						if (pdfItem != null)
						{
							array = Filtering.Decode(this._value, pdfItem);
							if (array == null)
							{
								string text = string.Format("«Cannot decode filter '{0}'»", pdfItem);
								array = PdfEncoders.RawEncoding.GetBytes(text);
							}
						}
						else
						{
							array = new byte[this._value.Length];
							this._value.CopyTo(array, 0);
						}
					}
					return array ?? new byte[0];
				}
			}

			// Token: 0x0600085F RID: 2143 RVA: 0x0001FD1C File Offset: 0x0001DF1C
			public bool TryUnfilter()
			{
				if (this._value != null)
				{
					PdfItem pdfItem = this._ownerDictionary.Elements["/Filter"];
					if (pdfItem != null)
					{
						byte[] array = Filtering.Decode(this._value, pdfItem);
						if (array == null)
						{
							return false;
						}
						this._ownerDictionary.Elements.Remove("/Filter");
						this.Value = array;
					}
				}
				return true;
			}

			// Token: 0x06000860 RID: 2144 RVA: 0x0001FD7C File Offset: 0x0001DF7C
			public void Zip()
			{
				if (this._value == null)
				{
					return;
				}
				if (!this._ownerDictionary.Elements.ContainsKey("/Filter"))
				{
					this._value = Filtering.FlateDecode.Encode(this._value, this._ownerDictionary._document.Options.FlateEncodeMode);
					this._ownerDictionary.Elements["/Filter"] = new PdfName("/FlateDecode");
					this._ownerDictionary.Elements["/Length"] = new PdfInteger(this._value.Length);
				}
			}

			// Token: 0x06000861 RID: 2145 RVA: 0x0001FE18 File Offset: 0x0001E018
			public override string ToString()
			{
				if (this._value == null)
				{
					return "«null»";
				}
				PdfItem pdfItem = this._ownerDictionary.Elements["/Filter"];
				string text;
				if (pdfItem != null)
				{
					byte[] array = Filtering.Decode(this._value, pdfItem);
					if (array == null)
					{
						throw new NotImplementedException("Unknown filter");
					}
					text = PdfEncoders.RawEncoding.GetString(array, 0, array.Length);
				}
				else
				{
					text = PdfEncoders.RawEncoding.GetString(this._value, 0, this._value.Length);
				}
				return text;
			}

			// Token: 0x0400045A RID: 1114
			private PdfDictionary _ownerDictionary;

			// Token: 0x0400045B RID: 1115
			private byte[] _value;

			// Token: 0x020000C9 RID: 201
			public class Keys : KeysBase
			{
				// Token: 0x0400045C RID: 1116
				[KeyInfo(KeyType.Integer | KeyType.Required)]
				public const string Length = "/Length";

				// Token: 0x0400045D RID: 1117
				[KeyInfo(KeyType.NameOrArray | KeyType.Optional)]
				public const string Filter = "/Filter";

				// Token: 0x0400045E RID: 1118
				[KeyInfo(KeyType.NameOrArray | KeyType.NameOrDictionary | KeyType.Optional)]
				public const string DecodeParms = "/DecodeParms";

				// Token: 0x0400045F RID: 1119
				[KeyInfo("1.2", KeyType.String | KeyType.Optional)]
				public const string F = "/F";

				// Token: 0x04000460 RID: 1120
				[KeyInfo("1.2", KeyType.NameOrArray | KeyType.Optional)]
				public const string FFilter = "/FFilter";

				// Token: 0x04000461 RID: 1121
				[KeyInfo("1.2", KeyType.NameOrArray | KeyType.NameOrDictionary | KeyType.Optional)]
				public const string FDecodeParms = "/FDecodeParms";

				// Token: 0x04000462 RID: 1122
				[KeyInfo("1.5", KeyType.Integer | KeyType.Optional)]
				public const string DL = "/DL";
			}
		}
	}
}
