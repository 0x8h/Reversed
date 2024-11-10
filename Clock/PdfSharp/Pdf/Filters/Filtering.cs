using System;

namespace PdfSharp.Pdf.Filters
{
	// Token: 0x0200015D RID: 349
	public static class Filtering
	{
		// Token: 0x06000B8E RID: 2958 RVA: 0x0002D9E8 File Offset: 0x0002BBE8
		public static Filter GetFilter(string filterName)
		{
			if (filterName.StartsWith("/"))
			{
				filterName = filterName.Substring(1);
			}
			string text;
			switch (text = filterName)
			{
			case "ASCIIHexDecode":
			case "AHx":
			{
				AsciiHexDecode asciiHexDecode;
				if ((asciiHexDecode = Filtering._asciiHexDecode) == null)
				{
					asciiHexDecode = (Filtering._asciiHexDecode = new AsciiHexDecode());
				}
				return asciiHexDecode;
			}
			case "ASCII85Decode":
			case "A85":
			{
				Ascii85Decode ascii85Decode;
				if ((ascii85Decode = Filtering._ascii85Decode) == null)
				{
					ascii85Decode = (Filtering._ascii85Decode = new Ascii85Decode());
				}
				return ascii85Decode;
			}
			case "LZWDecode":
			case "LZW":
			{
				LzwDecode lzwDecode;
				if ((lzwDecode = Filtering._lzwDecode) == null)
				{
					lzwDecode = (Filtering._lzwDecode = new LzwDecode());
				}
				return lzwDecode;
			}
			case "FlateDecode":
			case "Fl":
			{
				FlateDecode flateDecode;
				if ((flateDecode = Filtering._flateDecode) == null)
				{
					flateDecode = (Filtering._flateDecode = new FlateDecode());
				}
				return flateDecode;
			}
			case "RunLengthDecode":
			case "CCITTFaxDecode":
			case "JBIG2Decode":
			case "DCTDecode":
			case "JPXDecode":
			case "Crypt":
				return null;
			}
			throw new NotImplementedException("Unknown filter: " + filterName);
		}

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x0002DB94 File Offset: 0x0002BD94
		public static AsciiHexDecode ASCIIHexDecode
		{
			get
			{
				AsciiHexDecode asciiHexDecode;
				if ((asciiHexDecode = Filtering._asciiHexDecode) == null)
				{
					asciiHexDecode = (Filtering._asciiHexDecode = new AsciiHexDecode());
				}
				return asciiHexDecode;
			}
		}

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06000B90 RID: 2960 RVA: 0x0002DBAA File Offset: 0x0002BDAA
		public static Ascii85Decode ASCII85Decode
		{
			get
			{
				Ascii85Decode ascii85Decode;
				if ((ascii85Decode = Filtering._ascii85Decode) == null)
				{
					ascii85Decode = (Filtering._ascii85Decode = new Ascii85Decode());
				}
				return ascii85Decode;
			}
		}

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x0002DBC0 File Offset: 0x0002BDC0
		public static LzwDecode LzwDecode
		{
			get
			{
				LzwDecode lzwDecode;
				if ((lzwDecode = Filtering._lzwDecode) == null)
				{
					lzwDecode = (Filtering._lzwDecode = new LzwDecode());
				}
				return lzwDecode;
			}
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x0002DBD6 File Offset: 0x0002BDD6
		public static FlateDecode FlateDecode
		{
			get
			{
				FlateDecode flateDecode;
				if ((flateDecode = Filtering._flateDecode) == null)
				{
					flateDecode = (Filtering._flateDecode = new FlateDecode());
				}
				return flateDecode;
			}
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0002DBEC File Offset: 0x0002BDEC
		public static byte[] Encode(byte[] data, string filterName)
		{
			Filter filter = Filtering.GetFilter(filterName);
			if (filter != null)
			{
				return filter.Encode(data);
			}
			return null;
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x0002DC0C File Offset: 0x0002BE0C
		public static byte[] Encode(string rawString, string filterName)
		{
			Filter filter = Filtering.GetFilter(filterName);
			if (filter != null)
			{
				return filter.Encode(rawString);
			}
			return null;
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x0002DC2C File Offset: 0x0002BE2C
		public static byte[] Decode(byte[] data, string filterName, FilterParms parms)
		{
			Filter filter = Filtering.GetFilter(filterName);
			if (filter != null)
			{
				return filter.Decode(data, parms);
			}
			return null;
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0002DC50 File Offset: 0x0002BE50
		public static byte[] Decode(byte[] data, string filterName)
		{
			Filter filter = Filtering.GetFilter(filterName);
			if (filter != null)
			{
				return filter.Decode(data, null);
			}
			return null;
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x0002DC74 File Offset: 0x0002BE74
		public static byte[] Decode(byte[] data, PdfItem filterItem)
		{
			byte[] array = null;
			if (filterItem is PdfName)
			{
				Filter filter = Filtering.GetFilter(filterItem.ToString());
				if (filter != null)
				{
					array = filter.Decode(data);
				}
			}
			else if (filterItem is PdfArray)
			{
				PdfArray pdfArray = (PdfArray)filterItem;
				foreach (PdfItem pdfItem in pdfArray)
				{
					data = Filtering.Decode(data, pdfItem);
				}
				array = data;
			}
			return array;
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x0002DCF8 File Offset: 0x0002BEF8
		public static string DecodeToString(byte[] data, string filterName, FilterParms parms)
		{
			Filter filter = Filtering.GetFilter(filterName);
			if (filter != null)
			{
				return filter.DecodeToString(data, parms);
			}
			return null;
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x0002DD1C File Offset: 0x0002BF1C
		public static string DecodeToString(byte[] data, string filterName)
		{
			Filter filter = Filtering.GetFilter(filterName);
			if (filter != null)
			{
				return filter.DecodeToString(data, null);
			}
			return null;
		}

		// Token: 0x04000727 RID: 1831
		private static AsciiHexDecode _asciiHexDecode;

		// Token: 0x04000728 RID: 1832
		private static Ascii85Decode _ascii85Decode;

		// Token: 0x04000729 RID: 1833
		private static LzwDecode _lzwDecode;

		// Token: 0x0400072A RID: 1834
		private static FlateDecode _flateDecode;
	}
}
