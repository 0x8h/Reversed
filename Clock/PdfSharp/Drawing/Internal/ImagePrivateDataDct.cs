using System;

namespace PdfSharp.Drawing.Internal
{
	// Token: 0x0200004B RID: 75
	internal class ImagePrivateDataDct : ImagePrivateData
	{
		// Token: 0x06000187 RID: 391 RVA: 0x0000B4CA File Offset: 0x000096CA
		public ImagePrivateDataDct(byte[] data, int length)
		{
			this._data = data;
			this._length = length;
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000188 RID: 392 RVA: 0x0000B4E0 File Offset: 0x000096E0
		public byte[] Data
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000189 RID: 393 RVA: 0x0000B4E8 File Offset: 0x000096E8
		public int Length
		{
			get
			{
				return this._length;
			}
		}

		// Token: 0x040001EB RID: 491
		private readonly byte[] _data;

		// Token: 0x040001EC RID: 492
		private readonly int _length;
	}
}
