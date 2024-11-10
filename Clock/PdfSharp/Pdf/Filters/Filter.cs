using System;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.Filters
{
	// Token: 0x02000159 RID: 345
	public abstract class Filter
	{
		// Token: 0x06000B7F RID: 2943
		public abstract byte[] Encode(byte[] data);

		// Token: 0x06000B80 RID: 2944 RVA: 0x0002D158 File Offset: 0x0002B358
		public virtual byte[] Encode(string rawString)
		{
			byte[] bytes = PdfEncoders.RawEncoding.GetBytes(rawString);
			return this.Encode(bytes);
		}

		// Token: 0x06000B81 RID: 2945
		public abstract byte[] Decode(byte[] data, FilterParms parms);

		// Token: 0x06000B82 RID: 2946 RVA: 0x0002D17A File Offset: 0x0002B37A
		public byte[] Decode(byte[] data)
		{
			return this.Decode(data, null);
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x0002D184 File Offset: 0x0002B384
		public virtual string DecodeToString(byte[] data, FilterParms parms)
		{
			byte[] array = this.Decode(data, parms);
			return PdfEncoders.RawEncoding.GetString(array, 0, array.Length);
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x0002D1AB File Offset: 0x0002B3AB
		public string DecodeToString(byte[] data)
		{
			return this.DecodeToString(data, null);
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0002D1B8 File Offset: 0x0002B3B8
		protected byte[] RemoveWhiteSpace(byte[] data)
		{
			int num = data.Length;
			int num2 = 0;
			int i = 0;
			while (i < num)
			{
				byte b = data[i];
				if (b == 0)
				{
					goto IL_38;
				}
				switch (b)
				{
				case 9:
				case 10:
				case 12:
				case 13:
					goto IL_38;
				case 11:
					break;
				default:
					if (b == 32)
					{
						goto IL_38;
					}
					break;
				}
				if (i != num2)
				{
					data[num2] = data[i];
				}
				IL_48:
				i++;
				num2++;
				continue;
				IL_38:
				num2--;
				goto IL_48;
			}
			if (num2 < num)
			{
				byte[] array = data;
				data = new byte[num2];
				for (int j = 0; j < num2; j++)
				{
					data[j] = array[j];
				}
			}
			return data;
		}
	}
}
