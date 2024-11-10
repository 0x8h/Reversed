using System;

namespace PdfSharp.SharpZipLib.Zip
{
	// Token: 0x020001DE RID: 478
	public enum EncryptionAlgorithm
	{
		// Token: 0x04000A41 RID: 2625
		None,
		// Token: 0x04000A42 RID: 2626
		PkzipClassic,
		// Token: 0x04000A43 RID: 2627
		Des = 26113,
		// Token: 0x04000A44 RID: 2628
		RC2,
		// Token: 0x04000A45 RID: 2629
		TripleDes168,
		// Token: 0x04000A46 RID: 2630
		TripleDes112 = 26121,
		// Token: 0x04000A47 RID: 2631
		Aes128 = 26126,
		// Token: 0x04000A48 RID: 2632
		Aes192,
		// Token: 0x04000A49 RID: 2633
		Aes256,
		// Token: 0x04000A4A RID: 2634
		RC2Corrected = 26370,
		// Token: 0x04000A4B RID: 2635
		Blowfish = 26400,
		// Token: 0x04000A4C RID: 2636
		Twofish,
		// Token: 0x04000A4D RID: 2637
		RC4 = 26625,
		// Token: 0x04000A4E RID: 2638
		Unknown = 65535
	}
}
