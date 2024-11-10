using System;

namespace PdfSharp.SharpZipLib.Checksums
{
	// Token: 0x020001C8 RID: 456
	internal interface IChecksum
	{
		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x06000F09 RID: 3849
		long Value { get; }

		// Token: 0x06000F0A RID: 3850
		void Reset();

		// Token: 0x06000F0B RID: 3851
		void Update(int value);

		// Token: 0x06000F0C RID: 3852
		void Update(byte[] buffer);

		// Token: 0x06000F0D RID: 3853
		void Update(byte[] buffer, int offset, int count);
	}
}
