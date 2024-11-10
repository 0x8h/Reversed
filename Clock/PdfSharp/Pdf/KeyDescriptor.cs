using System;

namespace PdfSharp.Pdf
{
	// Token: 0x02000190 RID: 400
	internal sealed class KeyDescriptor
	{
		// Token: 0x06000CC0 RID: 3264 RVA: 0x00033FB0 File Offset: 0x000321B0
		public KeyDescriptor(KeyInfoAttribute attribute)
		{
			this._version = attribute.Version;
			this._keyType = attribute.KeyType;
			this._fixedValue = attribute.FixedValue;
			this._objectType = attribute.ObjectType;
			if (this._version == "")
			{
				this._version = "1.0";
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06000CC1 RID: 3265 RVA: 0x00034010 File Offset: 0x00032210
		// (set) Token: 0x06000CC2 RID: 3266 RVA: 0x00034018 File Offset: 0x00032218
		public string Version
		{
			get
			{
				return this._version;
			}
			set
			{
				this._version = value;
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06000CC3 RID: 3267 RVA: 0x00034021 File Offset: 0x00032221
		// (set) Token: 0x06000CC4 RID: 3268 RVA: 0x00034029 File Offset: 0x00032229
		public KeyType KeyType
		{
			get
			{
				return this._keyType;
			}
			set
			{
				this._keyType = value;
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06000CC5 RID: 3269 RVA: 0x00034032 File Offset: 0x00032232
		// (set) Token: 0x06000CC6 RID: 3270 RVA: 0x0003403A File Offset: 0x0003223A
		public string KeyValue
		{
			get
			{
				return this._keyValue;
			}
			set
			{
				this._keyValue = value;
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x00034043 File Offset: 0x00032243
		public string FixedValue
		{
			get
			{
				return this._fixedValue;
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06000CC8 RID: 3272 RVA: 0x0003404B File Offset: 0x0003224B
		// (set) Token: 0x06000CC9 RID: 3273 RVA: 0x00034053 File Offset: 0x00032253
		public Type ObjectType
		{
			get
			{
				return this._objectType;
			}
			set
			{
				this._objectType = value;
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06000CCA RID: 3274 RVA: 0x0003405C File Offset: 0x0003225C
		public bool CanBeIndirect
		{
			get
			{
				return (this._keyType & KeyType.MustNotBeIndirect) == (KeyType)0;
			}
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x00034070 File Offset: 0x00032270
		public Type GetValueType()
		{
			Type type = this._objectType;
			if (type == null)
			{
				KeyType keyType = this._keyType & KeyType.TypeMask;
				if (keyType <= KeyType.ArrayOrDictionary)
				{
					switch (keyType)
					{
					case KeyType.Name:
						type = typeof(PdfName);
						break;
					case KeyType.String:
						type = typeof(PdfString);
						break;
					case KeyType.Boolean:
						type = typeof(PdfBoolean);
						break;
					case KeyType.Integer:
						type = typeof(PdfInteger);
						break;
					case KeyType.Real:
						type = typeof(PdfReal);
						break;
					case KeyType.Date:
						type = typeof(PdfDate);
						break;
					case KeyType.Rectangle:
						type = typeof(PdfRectangle);
						break;
					case KeyType.Array:
						type = typeof(PdfArray);
						break;
					case KeyType.Dictionary:
						type = typeof(PdfDictionary);
						break;
					case KeyType.Stream:
						type = typeof(PdfDictionary);
						break;
					case KeyType.NumberTree:
						throw new NotImplementedException("KeyType.NumberTree");
					case KeyType.Function:
					case KeyType.TextString:
					case KeyType.ByteString:
					case KeyType.Name | KeyType.String | KeyType.Integer | KeyType.Array:
						break;
					case KeyType.NameOrArray:
						throw new NotImplementedException("KeyType.NameOrArray");
					default:
						if (keyType == KeyType.ArrayOrDictionary)
						{
							throw new NotImplementedException("KeyType.ArrayOrDictionary");
						}
						break;
					}
				}
				else
				{
					if (keyType == KeyType.StreamOrArray)
					{
						throw new NotImplementedException("KeyType.StreamOrArray");
					}
					if (keyType == KeyType.ArrayOrNameOrString)
					{
						return null;
					}
				}
			}
			return type;
		}

		// Token: 0x04000839 RID: 2105
		private string _version;

		// Token: 0x0400083A RID: 2106
		private KeyType _keyType;

		// Token: 0x0400083B RID: 2107
		private string _keyValue;

		// Token: 0x0400083C RID: 2108
		private readonly string _fixedValue;

		// Token: 0x0400083D RID: 2109
		private Type _objectType;
	}
}
