using System;

namespace PdfSharp.Pdf
{
	// Token: 0x0200019C RID: 412
	public sealed class PdfDocumentOptions
	{
		// Token: 0x06000D48 RID: 3400 RVA: 0x00035217 File Offset: 0x00033417
		internal PdfDocumentOptions(PdfDocument document)
		{
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06000D49 RID: 3401 RVA: 0x00035234 File Offset: 0x00033434
		// (set) Token: 0x06000D4A RID: 3402 RVA: 0x0003523C File Offset: 0x0003343C
		public PdfColorMode ColorMode
		{
			get
			{
				return this._colorMode;
			}
			set
			{
				this._colorMode = value;
			}
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06000D4B RID: 3403 RVA: 0x00035245 File Offset: 0x00033445
		// (set) Token: 0x06000D4C RID: 3404 RVA: 0x0003524D File Offset: 0x0003344D
		public bool CompressContentStreams
		{
			get
			{
				return this._compressContentStreams;
			}
			set
			{
				this._compressContentStreams = value;
			}
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06000D4D RID: 3405 RVA: 0x00035256 File Offset: 0x00033456
		// (set) Token: 0x06000D4E RID: 3406 RVA: 0x0003525E File Offset: 0x0003345E
		public bool NoCompression
		{
			get
			{
				return this._noCompression;
			}
			set
			{
				this._noCompression = value;
			}
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06000D4F RID: 3407 RVA: 0x00035267 File Offset: 0x00033467
		// (set) Token: 0x06000D50 RID: 3408 RVA: 0x0003526F File Offset: 0x0003346F
		public PdfFlateEncodeMode FlateEncodeMode
		{
			get
			{
				return this._flateEncodeMode;
			}
			set
			{
				this._flateEncodeMode = value;
			}
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06000D51 RID: 3409 RVA: 0x00035278 File Offset: 0x00033478
		// (set) Token: 0x06000D52 RID: 3410 RVA: 0x00035280 File Offset: 0x00033480
		public bool EnableCcittCompressionForBilevelImages
		{
			get
			{
				return this._enableCcittCompressionForBilevelImages;
			}
			set
			{
				this._enableCcittCompressionForBilevelImages = value;
			}
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06000D53 RID: 3411 RVA: 0x00035289 File Offset: 0x00033489
		// (set) Token: 0x06000D54 RID: 3412 RVA: 0x00035291 File Offset: 0x00033491
		public PdfUseFlateDecoderForJpegImages UseFlateDecoderForJpegImages
		{
			get
			{
				return this._useFlateDecoderForJpegImages;
			}
			set
			{
				this._useFlateDecoderForJpegImages = value;
			}
		}

		// Token: 0x04000871 RID: 2161
		private PdfColorMode _colorMode = PdfColorMode.Rgb;

		// Token: 0x04000872 RID: 2162
		private bool _compressContentStreams = true;

		// Token: 0x04000873 RID: 2163
		private bool _noCompression;

		// Token: 0x04000874 RID: 2164
		private PdfFlateEncodeMode _flateEncodeMode;

		// Token: 0x04000875 RID: 2165
		private bool _enableCcittCompressionForBilevelImages;

		// Token: 0x04000876 RID: 2166
		private PdfUseFlateDecoderForJpegImages _useFlateDecoderForJpegImages = PdfUseFlateDecoderForJpegImages.Never;
	}
}
