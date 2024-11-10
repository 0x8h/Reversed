using System;

namespace PdfSharp.Drawing.Internal
{
	// Token: 0x0200004A RID: 74
	internal class ImageDataDct : ImageData
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000182 RID: 386 RVA: 0x0000B4A0 File Offset: 0x000096A0
		// (set) Token: 0x06000183 RID: 387 RVA: 0x0000B4A8 File Offset: 0x000096A8
		public byte[] Data
		{
			get
			{
				return this._data;
			}
			internal set
			{
				this._data = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000184 RID: 388 RVA: 0x0000B4B1 File Offset: 0x000096B1
		// (set) Token: 0x06000185 RID: 389 RVA: 0x0000B4B9 File Offset: 0x000096B9
		public int Length
		{
			get
			{
				return this._length;
			}
			internal set
			{
				this._length = value;
			}
		}

		// Token: 0x040001E9 RID: 489
		private byte[] _data;

		// Token: 0x040001EA RID: 490
		private int _length;
	}
}
