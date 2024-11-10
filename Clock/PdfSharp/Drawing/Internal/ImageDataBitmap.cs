using System;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal
{
	// Token: 0x02000046 RID: 70
	internal class ImageDataBitmap : ImageData
	{
		// Token: 0x0600015C RID: 348 RVA: 0x0000A9E5 File Offset: 0x00008BE5
		private ImageDataBitmap()
		{
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000A9ED File Offset: 0x00008BED
		internal ImageDataBitmap(PdfDocument document)
		{
			this._document = document;
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600015E RID: 350 RVA: 0x0000A9FC File Offset: 0x00008BFC
		// (set) Token: 0x0600015F RID: 351 RVA: 0x0000AA04 File Offset: 0x00008C04
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

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000160 RID: 352 RVA: 0x0000AA0D File Offset: 0x00008C0D
		// (set) Token: 0x06000161 RID: 353 RVA: 0x0000AA15 File Offset: 0x00008C15
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

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000162 RID: 354 RVA: 0x0000AA1E File Offset: 0x00008C1E
		// (set) Token: 0x06000163 RID: 355 RVA: 0x0000AA26 File Offset: 0x00008C26
		public byte[] DataFax
		{
			get
			{
				return this._dataFax;
			}
			internal set
			{
				this._dataFax = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000164 RID: 356 RVA: 0x0000AA2F File Offset: 0x00008C2F
		// (set) Token: 0x06000165 RID: 357 RVA: 0x0000AA37 File Offset: 0x00008C37
		public int LengthFax
		{
			get
			{
				return this._lengthFax;
			}
			internal set
			{
				this._lengthFax = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000166 RID: 358 RVA: 0x0000AA40 File Offset: 0x00008C40
		// (set) Token: 0x06000167 RID: 359 RVA: 0x0000AA48 File Offset: 0x00008C48
		public byte[] AlphaMask
		{
			get
			{
				return this._alphaMask;
			}
			internal set
			{
				this._alphaMask = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000168 RID: 360 RVA: 0x0000AA51 File Offset: 0x00008C51
		// (set) Token: 0x06000169 RID: 361 RVA: 0x0000AA59 File Offset: 0x00008C59
		public int AlphaMaskLength
		{
			get
			{
				return this._alphaMaskLength;
			}
			internal set
			{
				this._alphaMaskLength = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600016A RID: 362 RVA: 0x0000AA62 File Offset: 0x00008C62
		// (set) Token: 0x0600016B RID: 363 RVA: 0x0000AA6A File Offset: 0x00008C6A
		public byte[] BitmapMask
		{
			get
			{
				return this._bitmapMask;
			}
			internal set
			{
				this._bitmapMask = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600016C RID: 364 RVA: 0x0000AA73 File Offset: 0x00008C73
		// (set) Token: 0x0600016D RID: 365 RVA: 0x0000AA7B File Offset: 0x00008C7B
		public int BitmapMaskLength
		{
			get
			{
				return this._bitmapMaskLength;
			}
			internal set
			{
				this._bitmapMaskLength = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600016E RID: 366 RVA: 0x0000AA84 File Offset: 0x00008C84
		// (set) Token: 0x0600016F RID: 367 RVA: 0x0000AA8C File Offset: 0x00008C8C
		public byte[] PaletteData
		{
			get
			{
				return this._paletteData;
			}
			set
			{
				this._paletteData = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000170 RID: 368 RVA: 0x0000AA95 File Offset: 0x00008C95
		// (set) Token: 0x06000171 RID: 369 RVA: 0x0000AA9D File Offset: 0x00008C9D
		public int PaletteDataLength
		{
			get
			{
				return this._paletteDataLength;
			}
			set
			{
				this._paletteDataLength = value;
			}
		}

		// Token: 0x040001D5 RID: 469
		private byte[] _data;

		// Token: 0x040001D6 RID: 470
		private int _length;

		// Token: 0x040001D7 RID: 471
		private byte[] _dataFax;

		// Token: 0x040001D8 RID: 472
		private int _lengthFax;

		// Token: 0x040001D9 RID: 473
		private byte[] _alphaMask;

		// Token: 0x040001DA RID: 474
		private int _alphaMaskLength;

		// Token: 0x040001DB RID: 475
		private byte[] _bitmapMask;

		// Token: 0x040001DC RID: 476
		private int _bitmapMaskLength;

		// Token: 0x040001DD RID: 477
		private byte[] _paletteData;

		// Token: 0x040001DE RID: 478
		private int _paletteDataLength;

		// Token: 0x040001DF RID: 479
		public bool SegmentedColorMask;

		// Token: 0x040001E0 RID: 480
		public int IsBitonal;

		// Token: 0x040001E1 RID: 481
		public int K;

		// Token: 0x040001E2 RID: 482
		public bool IsGray;

		// Token: 0x040001E3 RID: 483
		internal readonly PdfDocument _document;
	}
}
