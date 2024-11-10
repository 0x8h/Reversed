using System;
using System.IO;
using PdfSharp.SharpZipLib.Zip.Compression;
using PdfSharp.SharpZipLib.Zip.Compression.Streams;

namespace PdfSharp.Pdf.Filters
{
	// Token: 0x0200015E RID: 350
	public class FlateDecode : Filter
	{
		// Token: 0x06000B9A RID: 2970 RVA: 0x0002DD3D File Offset: 0x0002BF3D
		public override byte[] Encode(byte[] data)
		{
			return this.Encode(data, PdfFlateEncodeMode.Default);
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x0002DD48 File Offset: 0x0002BF48
		public byte[] Encode(byte[] data, PdfFlateEncodeMode mode)
		{
			MemoryStream memoryStream = new MemoryStream();
			int num = -1;
			switch (mode)
			{
			case PdfFlateEncodeMode.BestSpeed:
				num = 1;
				break;
			case PdfFlateEncodeMode.BestCompression:
				num = 9;
				break;
			}
			DeflaterOutputStream deflaterOutputStream = new DeflaterOutputStream(memoryStream, new Deflater(num, false));
			deflaterOutputStream.Write(data, 0, data.Length);
			deflaterOutputStream.Finish();
			memoryStream.Capacity = (int)memoryStream.Length;
			return memoryStream.GetBuffer();
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x0002DDAC File Offset: 0x0002BFAC
		public override byte[] Decode(byte[] data, FilterParms parms)
		{
			MemoryStream memoryStream = new MemoryStream(data);
			MemoryStream memoryStream2 = new MemoryStream();
			InflaterInputStream inflaterInputStream = new InflaterInputStream(memoryStream, new Inflater(false));
			byte[] array = new byte[32768];
			int num;
			do
			{
				num = inflaterInputStream.Read(array, 0, array.Length);
				if (num > 0)
				{
					memoryStream2.Write(array, 0, num);
				}
			}
			while (num > 0);
			inflaterInputStream.Close();
			memoryStream2.Flush();
			if (memoryStream2.Length >= 0L)
			{
				memoryStream2.Capacity = (int)memoryStream2.Length;
				return memoryStream2.GetBuffer();
			}
			return null;
		}
	}
}
