using System;

namespace PdfSharp.Pdf
{
	// Token: 0x02000182 RID: 386
	internal class KeyInfoAttribute : Attribute
	{
		// Token: 0x06000CB3 RID: 3251 RVA: 0x00033ED9 File Offset: 0x000320D9
		public KeyInfoAttribute()
		{
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x00033EEC File Offset: 0x000320EC
		public KeyInfoAttribute(KeyType keyType)
		{
			this.KeyType = keyType;
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x00033F06 File Offset: 0x00032106
		public KeyInfoAttribute(string version, KeyType keyType)
		{
			this._version = version;
			this.KeyType = keyType;
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x00033F27 File Offset: 0x00032127
		public KeyInfoAttribute(KeyType keyType, Type objectType)
		{
			this.KeyType = keyType;
			this._objectType = objectType;
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x00033F48 File Offset: 0x00032148
		public KeyInfoAttribute(string version, KeyType keyType, Type objectType)
		{
			this.KeyType = keyType;
			this._objectType = objectType;
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000CB8 RID: 3256 RVA: 0x00033F69 File Offset: 0x00032169
		// (set) Token: 0x06000CB9 RID: 3257 RVA: 0x00033F71 File Offset: 0x00032171
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

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06000CBA RID: 3258 RVA: 0x00033F7A File Offset: 0x0003217A
		// (set) Token: 0x06000CBB RID: 3259 RVA: 0x00033F82 File Offset: 0x00032182
		public KeyType KeyType
		{
			get
			{
				return this._entryType;
			}
			set
			{
				this._entryType = value;
			}
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06000CBC RID: 3260 RVA: 0x00033F8B File Offset: 0x0003218B
		// (set) Token: 0x06000CBD RID: 3261 RVA: 0x00033F93 File Offset: 0x00032193
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

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000CBE RID: 3262 RVA: 0x00033F9C File Offset: 0x0003219C
		// (set) Token: 0x06000CBF RID: 3263 RVA: 0x00033FA4 File Offset: 0x000321A4
		public string FixedValue
		{
			get
			{
				return this._fixedValue;
			}
			set
			{
				this._fixedValue = value;
			}
		}

		// Token: 0x040007F6 RID: 2038
		private string _version = "1.0";

		// Token: 0x040007F7 RID: 2039
		private KeyType _entryType;

		// Token: 0x040007F8 RID: 2040
		private Type _objectType;

		// Token: 0x040007F9 RID: 2041
		private string _fixedValue;
	}
}
