using System;

namespace PdfSharp.Drawing
{
	// Token: 0x0200003F RID: 63
	internal class ImageInformation
	{
		// Token: 0x040001C0 RID: 448
		internal ImageInformation.ImageFormats ImageFormat;

		// Token: 0x040001C1 RID: 449
		internal uint Width;

		// Token: 0x040001C2 RID: 450
		internal uint Height;

		// Token: 0x040001C3 RID: 451
		internal decimal HorizontalDPI;

		// Token: 0x040001C4 RID: 452
		internal decimal VerticalDPI;

		// Token: 0x040001C5 RID: 453
		internal decimal HorizontalDPM;

		// Token: 0x040001C6 RID: 454
		internal decimal VerticalDPM;

		// Token: 0x040001C7 RID: 455
		internal decimal HorizontalAspectRatio;

		// Token: 0x040001C8 RID: 456
		internal decimal VerticalAspectRatio;

		// Token: 0x040001C9 RID: 457
		internal uint ColorsUsed;

		// Token: 0x02000040 RID: 64
		internal enum ImageFormats
		{
			// Token: 0x040001CB RID: 459
			JPEG,
			// Token: 0x040001CC RID: 460
			JPEGGRAY,
			// Token: 0x040001CD RID: 461
			JPEGRGBW,
			// Token: 0x040001CE RID: 462
			JPEGCMYK,
			// Token: 0x040001CF RID: 463
			Palette1,
			// Token: 0x040001D0 RID: 464
			Palette4,
			// Token: 0x040001D1 RID: 465
			Palette8,
			// Token: 0x040001D2 RID: 466
			RGB24,
			// Token: 0x040001D3 RID: 467
			ARGB32
		}
	}
}
