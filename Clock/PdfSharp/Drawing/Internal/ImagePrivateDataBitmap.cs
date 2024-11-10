using System;
using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Drawing.Internal
{
	// Token: 0x02000047 RID: 71
	internal class ImagePrivateDataBitmap : ImagePrivateData
	{
		// Token: 0x06000172 RID: 370 RVA: 0x0000AAA6 File Offset: 0x00008CA6
		public ImagePrivateDataBitmap(byte[] data, int length)
		{
			this._data = data;
			this._length = length;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000173 RID: 371 RVA: 0x0000AABC File Offset: 0x00008CBC
		public byte[] Data
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000174 RID: 372 RVA: 0x0000AAC4 File Offset: 0x00008CC4
		public int Length
		{
			get
			{
				return this._length;
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000AACC File Offset: 0x00008CCC
		internal void CopyBitmap(ImageDataBitmap dest)
		{
			switch (base.Image.Information.ImageFormat)
			{
			case ImageInformation.ImageFormats.Palette1:
				this.CopyIndexedMemoryBitmap(1, dest);
				return;
			case ImageInformation.ImageFormats.Palette4:
				this.CopyIndexedMemoryBitmap(4, dest);
				return;
			case ImageInformation.ImageFormats.Palette8:
				this.CopyIndexedMemoryBitmap(8, dest);
				return;
			case ImageInformation.ImageFormats.RGB24:
				this.CopyTrueColorMemoryBitmap(4, 8, false, dest);
				return;
			case ImageInformation.ImageFormats.ARGB32:
				this.CopyTrueColorMemoryBitmap(3, 8, true, dest);
				return;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000AB40 File Offset: 0x00008D40
		private void CopyTrueColorMemoryBitmap(int components, int bits, bool hasAlpha, ImageDataBitmap dest)
		{
			int width = (int)base.Image.Information.Width;
			int height = (int)base.Image.Information.Height;
			int num = components;
			if (components == 4)
			{
				num = 3;
			}
			byte[] array = new byte[components * width * height];
			bool flag = false;
			bool flag2 = false;
			byte[] array2 = (hasAlpha ? new byte[width * height] : null);
			MonochromeMask monochromeMask = (hasAlpha ? new MonochromeMask(width, height) : null);
			int offset = this.Offset;
			int num2 = 0;
			if (num == 3)
			{
				for (int i = 0; i < height; i++)
				{
					int num3 = 3 * (height - 1 - i) * width;
					int num4 = 0;
					if (hasAlpha)
					{
						monochromeMask.StartLine(i);
						num4 = (height - 1 - i) * width;
					}
					for (int j = 0; j < width; j++)
					{
						array[num3] = this.Data[offset + num2 + 2];
						array[num3 + 1] = this.Data[offset + num2 + 1];
						array[num3 + 2] = this.Data[offset + num2];
						if (hasAlpha)
						{
							monochromeMask.AddPel((int)this.Data[offset + num2 + 3]);
							array2[num4] = this.Data[offset + num2 + 3];
							if ((!flag || !flag2) && this.Data[offset + num2 + 3] != 255)
							{
								flag = true;
								if (this.Data[offset + num2 + 3] != 0)
								{
									flag2 = true;
								}
							}
							num4++;
						}
						num2 += (hasAlpha ? 4 : components);
						num3 += 3;
					}
					num2 = 4 * ((num2 + 3) / 4);
				}
			}
			else if (components == 1)
			{
				throw new NotImplementedException("Image format not supported (grayscales).");
			}
			dest.Data = array;
			dest.Length = array.Length;
			if (array2 != null)
			{
				dest.AlphaMask = array2;
				dest.AlphaMaskLength = array2.Length;
			}
			if (monochromeMask != null)
			{
				dest.BitmapMask = monochromeMask.MaskData;
				dest.BitmapMaskLength = monochromeMask.MaskData.Length;
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000AD20 File Offset: 0x00008F20
		private void CopyIndexedMemoryBitmap(int bits, ImageDataBitmap dest)
		{
			int num = -1;
			int num2 = -1;
			bool flag = false;
			int colorPaletteOffset = ((ImagePrivateDataBitmap)base.Image.Data).ColorPaletteOffset;
			int offset = ((ImagePrivateDataBitmap)base.Image.Data).Offset;
			uint colorsUsed = base.Image.Information.ColorsUsed;
			int width = (int)base.Image.Information.Width;
			int height = (int)base.Image.Information.Height;
			MonochromeMask monochromeMask = new MonochromeMask(width, height);
			bool flag2 = bits == 8 && (colorsUsed == 256U || colorsUsed == 0U);
			int num3 = 0;
			byte[] array = new byte[3U * colorsUsed];
			int num4 = 0;
			while ((long)num4 < (long)((ulong)colorsUsed))
			{
				array[3 * num4] = this.Data[colorPaletteOffset + 4 * num4 + 2];
				array[3 * num4 + 1] = this.Data[colorPaletteOffset + 4 * num4 + 1];
				array[3 * num4 + 2] = this.Data[colorPaletteOffset + 4 * num4];
				if (flag2)
				{
					flag2 = array[3 * num4] == array[3 * num4 + 1] && array[3 * num4] == array[3 * num4 + 2];
				}
				if (this.Data[colorPaletteOffset + 4 * num4 + 3] < 128)
				{
					if (num == -1)
					{
						num = num4;
					}
					if (num2 == -1 || num2 == num4 - 1)
					{
						num2 = num4;
					}
					if (num2 != num4)
					{
						flag = true;
					}
				}
				num4++;
			}
			if (bits == 1)
			{
				if (colorsUsed == 0U)
				{
					num3 = 1;
				}
				if (colorsUsed == 2U)
				{
					if (array[0] == 0 && array[1] == 0 && array[2] == 0 && array[3] == 255 && array[4] == 255 && array[5] == 255)
					{
						num3 = 1;
					}
					if (array[5] == 0 && array[4] == 0 && array[3] == 0 && array[2] == 255 && array[1] == 255 && array[0] == 255)
					{
						num3 = -1;
					}
				}
			}
			byte[] array2 = new byte[(width * bits + 7) / 8 * height];
			byte[] array3 = null;
			int num5 = 0;
			if (bits == 1 && dest._document.Options.EnableCcittCompressionForBilevelImages)
			{
				byte[] array4 = new byte[array2.Length];
				int num6 = PdfImage.DoFaxEncodingGroup4(ref array4, this.Data, (uint)offset, (uint)width, (uint)height);
				bool flag3 = num6 > 0;
				if (flag3)
				{
					if (num6 == 0)
					{
						num6 = int.MaxValue;
					}
					Array.Resize<byte>(ref array4, num6);
					array3 = array4;
					num5 = -1;
				}
			}
			int num7 = 0;
			if (bits == 8 || bits == 4 || bits == 1)
			{
				int num8 = (width * bits + 7) / 8;
				for (int i = 0; i < height; i++)
				{
					monochromeMask.StartLine(i);
					int num9 = (height - 1 - i) * ((width * bits + 7) / 8);
					for (int j = 0; j < num8; j++)
					{
						if (flag2)
						{
							array2[num9] = array[(int)(3 * this.Data[offset + num7])];
						}
						else
						{
							array2[num9] = this.Data[offset + num7];
						}
						if (num != -1)
						{
							int num10 = (int)this.Data[offset + num7];
							if (bits == 8)
							{
								monochromeMask.AddPel(num10 >= num && num10 <= num2);
							}
							else if (bits == 4)
							{
								int num11 = (num10 & 240) / 16;
								int num12 = num10 & 15;
								monochromeMask.AddPel(num11 >= num && num11 <= num2);
								monochromeMask.AddPel(num12 >= num && num12 <= num2);
							}
							else if (bits == 1)
							{
								for (int k = 1; k <= 8; k++)
								{
									int num13 = (num10 & 128) / 128;
									monochromeMask.AddPel(num13 >= num && num13 <= num2);
									num10 *= 2;
								}
							}
						}
						num7++;
						num9++;
					}
					num7 = 4 * ((num7 + 3) / 4);
				}
				dest.Data = array2;
				dest.Length = array2.Length;
				if (array3 != null)
				{
					dest.DataFax = array3;
					dest.LengthFax = array3.Length;
				}
				dest.IsGray = flag2;
				dest.K = num5;
				dest.IsBitonal = num3;
				dest.PaletteData = array;
				dest.PaletteDataLength = array.Length;
				dest.SegmentedColorMask = flag;
				if (monochromeMask != null && num != -1)
				{
					dest.BitmapMask = monochromeMask.MaskData;
					dest.BitmapMaskLength = monochromeMask.MaskData.Length;
				}
				return;
			}
			throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format #3");
		}

		// Token: 0x040001E4 RID: 484
		private readonly byte[] _data;

		// Token: 0x040001E5 RID: 485
		private readonly int _length;

		// Token: 0x040001E6 RID: 486
		internal bool FlippedImage;

		// Token: 0x040001E7 RID: 487
		internal int Offset;

		// Token: 0x040001E8 RID: 488
		internal int ColorPaletteOffset;
	}
}
