using System;

namespace PdfSharp.Pdf.Filters
{
	// Token: 0x0200015B RID: 347
	public class AsciiHexDecode : Filter
	{
		// Token: 0x06000B8A RID: 2954 RVA: 0x0002D888 File Offset: 0x0002BA88
		public override byte[] Encode(byte[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			int num = data.Length;
			byte[] array = new byte[2 * num];
			int i = 0;
			int num2 = 0;
			while (i < num)
			{
				byte b = data[i];
				array[num2++] = (byte)((b >> 4) + ((b >> 4 < 10) ? 48 : 55));
				array[num2++] = (b & 15) + (((b & 15) < 10) ? 48 : 55);
				i++;
			}
			return array;
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x0002D8FC File Offset: 0x0002BAFC
		public override byte[] Decode(byte[] data, FilterParms parms)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			data = base.RemoveWhiteSpace(data);
			int num = data.Length;
			if (num > 0 && data[num - 1] == 62)
			{
				num--;
			}
			if (num % 2 == 1)
			{
				num++;
				byte[] array = data;
				data = new byte[num];
				array.CopyTo(data, 0);
			}
			num >>= 1;
			byte[] array2 = new byte[num];
			int i = 0;
			int num2 = 0;
			while (i < num)
			{
				byte b = data[num2++];
				byte b2 = data[num2++];
				if (b >= 97 && b <= 102)
				{
					b -= 32;
				}
				if (b2 >= 97 && b2 <= 102)
				{
					b2 -= 32;
				}
				array2[i] = ((b > 57) ? (b - 55) : (b - 48)) * 16 + ((b2 > 57) ? (b2 - 55) : (b2 - 48));
				i++;
			}
			return array2;
		}
	}
}
