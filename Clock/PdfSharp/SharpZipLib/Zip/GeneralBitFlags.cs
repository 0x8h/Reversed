using System;

namespace PdfSharp.SharpZipLib.Zip
{
	// Token: 0x020001DF RID: 479
	[Flags]
	public enum GeneralBitFlags
	{
		// Token: 0x04000A50 RID: 2640
		Encrypted = 1,
		// Token: 0x04000A51 RID: 2641
		Method = 6,
		// Token: 0x04000A52 RID: 2642
		Descriptor = 8,
		// Token: 0x04000A53 RID: 2643
		ReservedPKware4 = 16,
		// Token: 0x04000A54 RID: 2644
		Patched = 32,
		// Token: 0x04000A55 RID: 2645
		StrongEncryption = 64,
		// Token: 0x04000A56 RID: 2646
		Unused7 = 128,
		// Token: 0x04000A57 RID: 2647
		Unused8 = 256,
		// Token: 0x04000A58 RID: 2648
		Unused9 = 512,
		// Token: 0x04000A59 RID: 2649
		Unused10 = 1024,
		// Token: 0x04000A5A RID: 2650
		UnicodeText = 2048,
		// Token: 0x04000A5B RID: 2651
		EnhancedCompress = 4096,
		// Token: 0x04000A5C RID: 2652
		HeaderMasked = 8192,
		// Token: 0x04000A5D RID: 2653
		ReservedPkware14 = 16384,
		// Token: 0x04000A5E RID: 2654
		ReservedPkware15 = 32768
	}
}
