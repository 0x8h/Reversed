using System;

namespace PdfSharp.Drawing
{
	// Token: 0x02000041 RID: 65
	internal abstract class ImagePrivateData
	{
		// Token: 0x06000150 RID: 336 RVA: 0x0000A6EB File Offset: 0x000088EB
		internal ImagePrivateData()
		{
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000151 RID: 337 RVA: 0x0000A6F3 File Offset: 0x000088F3
		// (set) Token: 0x06000152 RID: 338 RVA: 0x0000A6FB File Offset: 0x000088FB
		public ImportedImage Image
		{
			get
			{
				return this._image;
			}
			internal set
			{
				this._image = value;
			}
		}

		// Token: 0x040001D4 RID: 468
		private ImportedImage _image;
	}
}
