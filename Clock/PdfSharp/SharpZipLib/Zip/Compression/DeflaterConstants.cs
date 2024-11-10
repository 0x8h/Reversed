using System;

namespace PdfSharp.SharpZipLib.Zip.Compression
{
	// Token: 0x020001CD RID: 461
	internal class DeflaterConstants
	{
		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06000F34 RID: 3892 RVA: 0x0003AEC8 File Offset: 0x000390C8
		public static bool DEBUGGING
		{
			get
			{
				return false;
			}
		}

		// Token: 0x04000988 RID: 2440
		public const int STORED_BLOCK = 0;

		// Token: 0x04000989 RID: 2441
		public const int STATIC_TREES = 1;

		// Token: 0x0400098A RID: 2442
		public const int DYN_TREES = 2;

		// Token: 0x0400098B RID: 2443
		public const int PRESET_DICT = 32;

		// Token: 0x0400098C RID: 2444
		public const int DEFAULT_MEM_LEVEL = 8;

		// Token: 0x0400098D RID: 2445
		public const int MAX_MATCH = 258;

		// Token: 0x0400098E RID: 2446
		public const int MIN_MATCH = 3;

		// Token: 0x0400098F RID: 2447
		public const int MAX_WBITS = 15;

		// Token: 0x04000990 RID: 2448
		public const int WSIZE = 32768;

		// Token: 0x04000991 RID: 2449
		public const int WMASK = 32767;

		// Token: 0x04000992 RID: 2450
		public const int HASH_BITS = 15;

		// Token: 0x04000993 RID: 2451
		public const int HASH_SIZE = 32768;

		// Token: 0x04000994 RID: 2452
		public const int HASH_MASK = 32767;

		// Token: 0x04000995 RID: 2453
		public const int HASH_SHIFT = 5;

		// Token: 0x04000996 RID: 2454
		public const int MIN_LOOKAHEAD = 262;

		// Token: 0x04000997 RID: 2455
		public const int MAX_DIST = 32506;

		// Token: 0x04000998 RID: 2456
		public const int PENDING_BUF_SIZE = 65536;

		// Token: 0x04000999 RID: 2457
		public const int DEFLATE_STORED = 0;

		// Token: 0x0400099A RID: 2458
		public const int DEFLATE_FAST = 1;

		// Token: 0x0400099B RID: 2459
		public const int DEFLATE_SLOW = 2;

		// Token: 0x0400099C RID: 2460
		public static int MAX_BLOCK_SIZE = Math.Min(65535, 65531);

		// Token: 0x0400099D RID: 2461
		public static int[] GOOD_LENGTH = new int[] { 0, 4, 4, 4, 4, 8, 8, 8, 32, 32 };

		// Token: 0x0400099E RID: 2462
		public static int[] MAX_LAZY = new int[] { 0, 4, 5, 6, 4, 16, 16, 32, 128, 258 };

		// Token: 0x0400099F RID: 2463
		public static int[] NICE_LENGTH = new int[] { 0, 8, 16, 32, 16, 32, 128, 128, 258, 258 };

		// Token: 0x040009A0 RID: 2464
		public static int[] MAX_CHAIN = new int[] { 0, 4, 8, 32, 16, 32, 128, 256, 1024, 4096 };

		// Token: 0x040009A1 RID: 2465
		public static int[] COMPR_FUNC = new int[] { 0, 1, 1, 1, 1, 2, 2, 2, 2, 2 };
	}
}
