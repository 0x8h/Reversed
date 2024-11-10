using System;
using System.Globalization;
using System.Text;

namespace PdfSharp.SharpZipLib.Zip
{
	// Token: 0x020001E0 RID: 480
	internal sealed class ZipConstants
	{
		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x06000FED RID: 4077 RVA: 0x0003F516 File Offset: 0x0003D716
		// (set) Token: 0x06000FEE RID: 4078 RVA: 0x0003F51D File Offset: 0x0003D71D
		public static int DefaultCodePage
		{
			get
			{
				return ZipConstants.defaultCodePage;
			}
			set
			{
				if (value < 0 || value > 65535 || value == 1 || value == 2 || value == 3 || value == 42)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				ZipConstants.defaultCodePage = value;
			}
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x0003F54D File Offset: 0x0003D74D
		public static string ConvertToString(byte[] data, int count)
		{
			if (data == null)
			{
				return string.Empty;
			}
			return Encoding.GetEncoding(ZipConstants.DefaultCodePage).GetString(data, 0, count);
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x0003F56A File Offset: 0x0003D76A
		public static string ConvertToString(byte[] data)
		{
			if (data == null)
			{
				return string.Empty;
			}
			return ZipConstants.ConvertToString(data, data.Length);
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x0003F57E File Offset: 0x0003D77E
		public static string ConvertToStringExt(int flags, byte[] data, int count)
		{
			if (data == null)
			{
				return string.Empty;
			}
			if ((flags & 2048) != 0)
			{
				return Encoding.UTF8.GetString(data, 0, count);
			}
			return ZipConstants.ConvertToString(data, count);
		}

		// Token: 0x06000FF2 RID: 4082 RVA: 0x0003F5A7 File Offset: 0x0003D7A7
		public static string ConvertToStringExt(int flags, byte[] data)
		{
			if (data == null)
			{
				return string.Empty;
			}
			if ((flags & 2048) != 0)
			{
				return Encoding.UTF8.GetString(data, 0, data.Length);
			}
			return ZipConstants.ConvertToString(data, data.Length);
		}

		// Token: 0x06000FF3 RID: 4083 RVA: 0x0003F5D4 File Offset: 0x0003D7D4
		public static byte[] ConvertToArray(string str)
		{
			if (str == null)
			{
				return new byte[0];
			}
			return Encoding.GetEncoding(ZipConstants.DefaultCodePage).GetBytes(str);
		}

		// Token: 0x06000FF4 RID: 4084 RVA: 0x0003F5F0 File Offset: 0x0003D7F0
		public static byte[] ConvertToArray(int flags, string str)
		{
			if (str == null)
			{
				return new byte[0];
			}
			if ((flags & 2048) != 0)
			{
				return Encoding.UTF8.GetBytes(str);
			}
			return ZipConstants.ConvertToArray(str);
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x0003F617 File Offset: 0x0003D817
		private ZipConstants()
		{
		}

		// Token: 0x04000A5F RID: 2655
		public const int VersionMadeBy = 51;

		// Token: 0x04000A60 RID: 2656
		[Obsolete("Use VersionMadeBy instead")]
		public const int VERSION_MADE_BY = 51;

		// Token: 0x04000A61 RID: 2657
		public const int VersionStrongEncryption = 50;

		// Token: 0x04000A62 RID: 2658
		[Obsolete("Use VersionStrongEncryption instead")]
		public const int VERSION_STRONG_ENCRYPTION = 50;

		// Token: 0x04000A63 RID: 2659
		public const int VERSION_AES = 51;

		// Token: 0x04000A64 RID: 2660
		public const int VersionZip64 = 45;

		// Token: 0x04000A65 RID: 2661
		public const int LocalHeaderBaseSize = 30;

		// Token: 0x04000A66 RID: 2662
		[Obsolete("Use LocalHeaderBaseSize instead")]
		public const int LOCHDR = 30;

		// Token: 0x04000A67 RID: 2663
		public const int Zip64DataDescriptorSize = 24;

		// Token: 0x04000A68 RID: 2664
		public const int DataDescriptorSize = 16;

		// Token: 0x04000A69 RID: 2665
		[Obsolete("Use DataDescriptorSize instead")]
		public const int EXTHDR = 16;

		// Token: 0x04000A6A RID: 2666
		public const int CentralHeaderBaseSize = 46;

		// Token: 0x04000A6B RID: 2667
		[Obsolete("Use CentralHeaderBaseSize instead")]
		public const int CENHDR = 46;

		// Token: 0x04000A6C RID: 2668
		public const int EndOfCentralRecordBaseSize = 22;

		// Token: 0x04000A6D RID: 2669
		[Obsolete("Use EndOfCentralRecordBaseSize instead")]
		public const int ENDHDR = 22;

		// Token: 0x04000A6E RID: 2670
		public const int CryptoHeaderSize = 12;

		// Token: 0x04000A6F RID: 2671
		[Obsolete("Use CryptoHeaderSize instead")]
		public const int CRYPTO_HEADER_SIZE = 12;

		// Token: 0x04000A70 RID: 2672
		public const int LocalHeaderSignature = 67324752;

		// Token: 0x04000A71 RID: 2673
		[Obsolete("Use LocalHeaderSignature instead")]
		public const int LOCSIG = 67324752;

		// Token: 0x04000A72 RID: 2674
		public const int SpanningSignature = 134695760;

		// Token: 0x04000A73 RID: 2675
		[Obsolete("Use SpanningSignature instead")]
		public const int SPANNINGSIG = 134695760;

		// Token: 0x04000A74 RID: 2676
		public const int SpanningTempSignature = 808471376;

		// Token: 0x04000A75 RID: 2677
		[Obsolete("Use SpanningTempSignature instead")]
		public const int SPANTEMPSIG = 808471376;

		// Token: 0x04000A76 RID: 2678
		public const int DataDescriptorSignature = 134695760;

		// Token: 0x04000A77 RID: 2679
		[Obsolete("Use DataDescriptorSignature instead")]
		public const int EXTSIG = 134695760;

		// Token: 0x04000A78 RID: 2680
		[Obsolete("Use CentralHeaderSignature instead")]
		public const int CENSIG = 33639248;

		// Token: 0x04000A79 RID: 2681
		public const int CentralHeaderSignature = 33639248;

		// Token: 0x04000A7A RID: 2682
		public const int Zip64CentralFileHeaderSignature = 101075792;

		// Token: 0x04000A7B RID: 2683
		[Obsolete("Use Zip64CentralFileHeaderSignature instead")]
		public const int CENSIG64 = 101075792;

		// Token: 0x04000A7C RID: 2684
		public const int Zip64CentralDirLocatorSignature = 117853008;

		// Token: 0x04000A7D RID: 2685
		public const int ArchiveExtraDataSignature = 117853008;

		// Token: 0x04000A7E RID: 2686
		public const int CentralHeaderDigitalSignature = 84233040;

		// Token: 0x04000A7F RID: 2687
		[Obsolete("Use CentralHeaderDigitalSignaure instead")]
		public const int CENDIGITALSIG = 84233040;

		// Token: 0x04000A80 RID: 2688
		public const int EndOfCentralDirectorySignature = 101010256;

		// Token: 0x04000A81 RID: 2689
		[Obsolete("Use EndOfCentralDirectorySignature instead")]
		public const int ENDSIG = 101010256;

		// Token: 0x04000A82 RID: 2690
		private static int defaultCodePage = CultureInfo.CurrentCulture.TextInfo.ANSICodePage;
	}
}
