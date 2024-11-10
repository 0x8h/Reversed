using System;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000119 RID: 281
	internal class PdfPageInheritableObjects : PdfDictionary
	{
		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06000A23 RID: 2595 RVA: 0x000289A3 File Offset: 0x00026BA3
		// (set) Token: 0x06000A24 RID: 2596 RVA: 0x000289AB File Offset: 0x00026BAB
		public PdfRectangle MediaBox
		{
			get
			{
				return this._mediaBox;
			}
			set
			{
				this._mediaBox = value;
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x06000A25 RID: 2597 RVA: 0x000289B4 File Offset: 0x00026BB4
		// (set) Token: 0x06000A26 RID: 2598 RVA: 0x000289BC File Offset: 0x00026BBC
		public PdfRectangle CropBox
		{
			get
			{
				return this._cropBox;
			}
			set
			{
				this._cropBox = value;
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06000A27 RID: 2599 RVA: 0x000289C5 File Offset: 0x00026BC5
		// (set) Token: 0x06000A28 RID: 2600 RVA: 0x000289CD File Offset: 0x00026BCD
		public int Rotate
		{
			get
			{
				return this._rotate;
			}
			set
			{
				if (value % 90 != 0)
				{
					throw new ArgumentException("Rotate", "The value must be a multiple of 90.");
				}
				this._rotate = value;
			}
		}

		// Token: 0x0400058A RID: 1418
		private PdfRectangle _mediaBox;

		// Token: 0x0400058B RID: 1419
		private PdfRectangle _cropBox;

		// Token: 0x0400058C RID: 1420
		private int _rotate;
	}
}
