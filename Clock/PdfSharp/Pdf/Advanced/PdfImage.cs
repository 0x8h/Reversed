using System;
using System.Drawing.Imaging;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Internal;
using PdfSharp.Pdf.Filters;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x0200010D RID: 269
	public sealed class PdfImage : PdfXObject
	{
		// Token: 0x060009CA RID: 2506 RVA: 0x000248C8 File Offset: 0x00022AC8
		public PdfImage(PdfDocument document, XImage image)
			: base(document)
		{
			base.Elements.SetName("/Type", "/XObject");
			base.Elements.SetName("/Subtype", "/Image");
			this._image = image;
			string text;
			switch (text = this._image.Format.Guid.ToString("B").ToUpper())
			{
			case "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}":
				this.InitializeJpeg();
				return;
			case "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}":
			case "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}":
			case "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}":
			case "{B96B3CB5-0728-11D3-9D7B-0000F81EF32E}":
				this.InitializeNonJpeg();
				break;
			case "{84570158-DBF0-4C6B-8368-62D6A3CA76E0}":
				break;

				return;
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x060009CB RID: 2507 RVA: 0x000249D1 File Offset: 0x00022BD1
		public XImage Image
		{
			get
			{
				return this._image;
			}
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x000249D9 File Offset: 0x00022BD9
		public override string ToString()
		{
			return "Image";
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x000249E0 File Offset: 0x00022BE0
		private void InitializeJpeg()
		{
			MemoryStream memoryStream = null;
			bool flag = false;
			byte[] array = null;
			int num = 0;
			if (this._image._importedImage != null)
			{
				ImageDataDct imageDataDct = (ImageDataDct)this._image._importedImage.ImageData;
				array = imageDataDct.Data;
				num = imageDataDct.Length;
			}
			if (this._image._importedImage == null)
			{
				if (!this._image._path.StartsWith("*"))
				{
					using (FileStream fileStream = File.OpenRead(this._image._path))
					{
						byte[] array2 = new byte[8192];
						memoryStream = new MemoryStream((int)fileStream.Length);
						flag = true;
						int num2;
						do
						{
							num2 = fileStream.Read(array2, 0, array2.Length);
							memoryStream.Write(array2, 0, num2);
						}
						while (num2 > 0);
						goto IL_146;
					}
				}
				memoryStream = new MemoryStream();
				flag = true;
				if (this._image._stream != null && this._image._stream.CanSeek)
				{
					Stream stream = this._image._stream;
					stream.Seek(0L, SeekOrigin.Begin);
					byte[] array3 = new byte[32768];
					int num3;
					while ((num3 = stream.Read(array3, 0, array3.Length)) > 0)
					{
						memoryStream.Write(array3, 0, num3);
					}
				}
				else
				{
					this._image._gdiImage.Save(memoryStream, ImageFormat.Jpeg);
				}
				IL_146:
				int num4 = (int)memoryStream.Length;
			}
			if (array == null)
			{
				num = (int)memoryStream.Length;
				array = new byte[num];
				memoryStream.Seek(0L, SeekOrigin.Begin);
				memoryStream.Read(array, 0, num);
				if (flag)
				{
					memoryStream.Dispose();
				}
			}
			bool flag2 = this._document.Options.UseFlateDecoderForJpegImages == PdfUseFlateDecoderForJpegImages.Automatic;
			bool flag3 = this._document.Options.UseFlateDecoderForJpegImages == PdfUseFlateDecoderForJpegImages.Always;
			FlateDecode flateDecode = new FlateDecode();
			byte[] array4 = ((flag3 || flag2) ? flateDecode.Encode(array, this._document.Options.FlateEncodeMode) : null);
			if (flag3 || (flag2 && array4.Length < array.Length))
			{
				base.Stream = new PdfDictionary.PdfStream(array4, this);
				base.Elements["/Length"] = new PdfInteger(array4.Length);
				PdfArray pdfArray = new PdfArray(this._document);
				pdfArray.Elements.Add(new PdfName("/FlateDecode"));
				pdfArray.Elements.Add(new PdfName("/DCTDecode"));
				base.Elements["/Filter"] = pdfArray;
			}
			else
			{
				base.Stream = new PdfDictionary.PdfStream(array, this);
				base.Elements["/Length"] = new PdfInteger(num);
				base.Elements["/Filter"] = new PdfName("/DCTDecode");
			}
			if (this._image.Interpolate)
			{
				base.Elements["/Interpolate"] = PdfBoolean.True;
			}
			base.Elements["/Width"] = new PdfInteger(this._image.PixelWidth);
			base.Elements["/Height"] = new PdfInteger(this._image.PixelHeight);
			base.Elements["/BitsPerComponent"] = new PdfInteger(8);
			if (this._image._importedImage != null)
			{
				if (this._image._importedImage.Information.ImageFormat == ImageInformation.ImageFormats.JPEGCMYK || this._image._importedImage.Information.ImageFormat == ImageInformation.ImageFormats.JPEGRGBW)
				{
					base.Elements["/ColorSpace"] = new PdfName("/DeviceCMYK");
					if (this._image._importedImage.Information.ImageFormat == ImageInformation.ImageFormats.JPEGRGBW)
					{
						base.Elements["/Decode"] = new PdfLiteral("[1 0 1 0 1 0 1 0]");
					}
				}
				else if (this._image._importedImage.Information.ImageFormat == ImageInformation.ImageFormats.JPEGGRAY)
				{
					base.Elements["/ColorSpace"] = new PdfName("/DeviceGray");
				}
				else
				{
					base.Elements["/ColorSpace"] = new PdfName("/DeviceRGB");
				}
			}
			if (this._image._importedImage == null)
			{
				if ((this._image._gdiImage.Flags & 288) != 0)
				{
					base.Elements["/ColorSpace"] = new PdfName("/DeviceCMYK");
					if ((this._image._gdiImage.Flags & 256) != 0)
					{
						base.Elements["/Decode"] = new PdfLiteral("[1 0 1 0 1 0 1 0]");
						return;
					}
				}
				else
				{
					if ((this._image._gdiImage.Flags & 64) != 0)
					{
						base.Elements["/ColorSpace"] = new PdfName("/DeviceGray");
						return;
					}
					base.Elements["/ColorSpace"] = new PdfName("/DeviceRGB");
				}
			}
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x00024EA8 File Offset: 0x000230A8
		private void InitializeNonJpeg()
		{
			if (this._image._importedImage == null)
			{
				PixelFormat pixelFormat = this._image._gdiImage.PixelFormat;
				if (pixelFormat <= PixelFormat.Format1bppIndexed)
				{
					if (pixelFormat == PixelFormat.Format24bppRgb)
					{
						this.ReadTrueColorMemoryBitmap(3, 8, false);
						return;
					}
					if (pixelFormat == PixelFormat.Format32bppRgb)
					{
						this.ReadTrueColorMemoryBitmap(4, 8, false);
						return;
					}
					if (pixelFormat == PixelFormat.Format1bppIndexed)
					{
						this.ReadIndexedMemoryBitmap(1);
						return;
					}
				}
				else if (pixelFormat <= PixelFormat.Format8bppIndexed)
				{
					if (pixelFormat == PixelFormat.Format4bppIndexed)
					{
						this.ReadIndexedMemoryBitmap(4);
						return;
					}
					if (pixelFormat == PixelFormat.Format8bppIndexed)
					{
						this.ReadIndexedMemoryBitmap(8);
						return;
					}
				}
				else if (pixelFormat == PixelFormat.Format32bppPArgb || pixelFormat == PixelFormat.Format32bppArgb)
				{
					this.ReadTrueColorMemoryBitmap(3, 8, true);
					return;
				}
				throw new NotImplementedException("Image format not supported.");
			}
			switch (this._image._importedImage.Information.ImageFormat)
			{
			case ImageInformation.ImageFormats.Palette1:
				this.CreateIndexedMemoryBitmap(1);
				return;
			case ImageInformation.ImageFormats.Palette4:
				this.CreateIndexedMemoryBitmap(4);
				return;
			case ImageInformation.ImageFormats.Palette8:
				this.CreateIndexedMemoryBitmap(8);
				return;
			case ImageInformation.ImageFormats.RGB24:
				this.CreateTrueColorMemoryBitmap(3, 8, false);
				return;
			default:
				throw new NotImplementedException("Image format not supported.");
			}
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x00024FC0 File Offset: 0x000231C0
		private void CreateIndexedMemoryBitmap(int bits)
		{
			ImageDataBitmap imageDataBitmap = (ImageDataBitmap)this._image._importedImage.ImageData;
			ImageInformation information = this._image._importedImage.Information;
			int version = this.Owner.Version;
			int num = -1;
			int num2 = -1;
			bool segmentedColorMask = imageDataBitmap.SegmentedColorMask;
			FlateDecode flateDecode = new FlateDecode();
			if (num != -1 && num2 != -1)
			{
				if (!segmentedColorMask && version >= 13 && !imageDataBitmap.IsGray)
				{
					PdfArray pdfArray = new PdfArray(this._document);
					pdfArray.Elements.Add(new PdfInteger(num));
					pdfArray.Elements.Add(new PdfInteger(num2));
					base.Elements["/Mask"] = pdfArray;
				}
				else
				{
					byte[] array = flateDecode.Encode(imageDataBitmap.BitmapMask, this._document.Options.FlateEncodeMode);
					PdfDictionary pdfDictionary = new PdfDictionary(this._document);
					pdfDictionary.Elements.SetName("/Type", "/XObject");
					pdfDictionary.Elements.SetName("/Subtype", "/Image");
					this.Owner._irefTable.Add(pdfDictionary);
					pdfDictionary.Stream = new PdfDictionary.PdfStream(array, pdfDictionary);
					pdfDictionary.Elements["/Length"] = new PdfInteger(array.Length);
					pdfDictionary.Elements["/Filter"] = new PdfName("/FlateDecode");
					pdfDictionary.Elements["/Width"] = new PdfInteger((int)information.Width);
					pdfDictionary.Elements["/Height"] = new PdfInteger((int)information.Height);
					pdfDictionary.Elements["/BitsPerComponent"] = new PdfInteger(1);
					pdfDictionary.Elements["/ImageMask"] = new PdfBoolean(true);
					base.Elements["/Mask"] = pdfDictionary.Reference;
				}
			}
			byte[] array2 = flateDecode.Encode(imageDataBitmap.Data, this._document.Options.FlateEncodeMode);
			byte[] array3 = ((imageDataBitmap.DataFax != null) ? flateDecode.Encode(imageDataBitmap.DataFax, this._document.Options.FlateEncodeMode) : null);
			bool flag = false;
			if (imageDataBitmap.DataFax != null && (imageDataBitmap.LengthFax < array2.Length || array3.Length < array2.Length))
			{
				flag = true;
				if (imageDataBitmap.LengthFax < array2.Length)
				{
					base.Stream = new PdfDictionary.PdfStream(imageDataBitmap.DataFax, this);
					base.Elements["/Length"] = new PdfInteger(imageDataBitmap.LengthFax);
					base.Elements["/Filter"] = new PdfName("/CCITTFaxDecode");
					PdfDictionary pdfDictionary2 = new PdfDictionary();
					if (imageDataBitmap.K != 0)
					{
						pdfDictionary2.Elements.Add("/K", new PdfInteger(imageDataBitmap.K));
					}
					if (imageDataBitmap.IsBitonal < 0)
					{
						pdfDictionary2.Elements.Add("/BlackIs1", new PdfBoolean(true));
					}
					pdfDictionary2.Elements.Add("/EndOfBlock", new PdfBoolean(false));
					pdfDictionary2.Elements.Add("/Columns", new PdfInteger((int)information.Width));
					pdfDictionary2.Elements.Add("/Rows", new PdfInteger((int)information.Height));
					base.Elements["/DecodeParms"] = pdfDictionary2;
				}
				else
				{
					base.Stream = new PdfDictionary.PdfStream(array3, this);
					base.Elements["/Length"] = new PdfInteger(array3.Length);
					PdfArray pdfArray2 = new PdfArray(this._document);
					pdfArray2.Elements.Add(new PdfName("/FlateDecode"));
					pdfArray2.Elements.Add(new PdfName("/CCITTFaxDecode"));
					base.Elements["/Filter"] = pdfArray2;
					PdfArray pdfArray3 = new PdfArray(this._document);
					PdfDictionary pdfDictionary3 = new PdfDictionary();
					PdfDictionary pdfDictionary4 = new PdfDictionary();
					if (imageDataBitmap.K != 0)
					{
						pdfDictionary4.Elements.Add("/K", new PdfInteger(imageDataBitmap.K));
					}
					if (imageDataBitmap.IsBitonal < 0)
					{
						pdfDictionary4.Elements.Add("/BlackIs1", new PdfBoolean(true));
					}
					pdfDictionary4.Elements.Add("/EndOfBlock", new PdfBoolean(false));
					pdfDictionary4.Elements.Add("/Columns", new PdfInteger((int)information.Width));
					pdfDictionary4.Elements.Add("/Rows", new PdfInteger((int)information.Height));
					pdfArray3.Elements.Add(pdfDictionary3);
					pdfArray3.Elements.Add(pdfDictionary4);
					base.Elements["/DecodeParms"] = pdfArray3;
				}
			}
			else
			{
				base.Stream = new PdfDictionary.PdfStream(array2, this);
				base.Elements["/Length"] = new PdfInteger(array2.Length);
				base.Elements["/Filter"] = new PdfName("/FlateDecode");
			}
			base.Elements["/Width"] = new PdfInteger((int)information.Width);
			base.Elements["/Height"] = new PdfInteger((int)information.Height);
			base.Elements["/BitsPerComponent"] = new PdfInteger(bits);
			if ((flag && imageDataBitmap.IsBitonal == 0) || (!flag && imageDataBitmap.IsBitonal <= 0 && !imageDataBitmap.IsGray))
			{
				PdfDictionary pdfDictionary5 = new PdfDictionary(this._document);
				byte[] array4 = ((imageDataBitmap.PaletteDataLength >= 48) ? flateDecode.Encode(imageDataBitmap.PaletteData, this._document.Options.FlateEncodeMode) : null);
				if (array4 != null && array4.Length + 20 < imageDataBitmap.PaletteDataLength)
				{
					pdfDictionary5.CreateStream(array4);
					pdfDictionary5.Elements["/Length"] = new PdfInteger(array4.Length);
					pdfDictionary5.Elements["/Filter"] = new PdfName("/FlateDecode");
				}
				else
				{
					pdfDictionary5.CreateStream(imageDataBitmap.PaletteData);
					pdfDictionary5.Elements["/Length"] = new PdfInteger(imageDataBitmap.PaletteDataLength);
				}
				this.Owner._irefTable.Add(pdfDictionary5);
				PdfArray pdfArray4 = new PdfArray(this._document);
				pdfArray4.Elements.Add(new PdfName("/Indexed"));
				pdfArray4.Elements.Add(new PdfName("/DeviceRGB"));
				pdfArray4.Elements.Add(new PdfInteger((int)(information.ColorsUsed - 1U)));
				pdfArray4.Elements.Add(pdfDictionary5.Reference);
				base.Elements["/ColorSpace"] = pdfArray4;
			}
			else
			{
				base.Elements["/ColorSpace"] = new PdfName("/DeviceGray");
			}
			if (this._image.Interpolate)
			{
				base.Elements["/Interpolate"] = PdfBoolean.True;
			}
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x000256AC File Offset: 0x000238AC
		private void CreateTrueColorMemoryBitmap(int components, int bits, bool hasAlpha)
		{
			int version = this.Owner.Version;
			FlateDecode flateDecode = new FlateDecode();
			ImageDataBitmap imageDataBitmap = (ImageDataBitmap)this._image._importedImage.ImageData;
			ImageInformation information = this._image._importedImage.Information;
			bool flag = imageDataBitmap.AlphaMaskLength > 0 || imageDataBitmap.BitmapMaskLength > 0;
			bool flag2 = imageDataBitmap.AlphaMaskLength > 0;
			if (flag)
			{
				byte[] array = flateDecode.Encode(imageDataBitmap.BitmapMask, this._document.Options.FlateEncodeMode);
				PdfDictionary pdfDictionary = new PdfDictionary(this._document);
				pdfDictionary.Elements.SetName("/Type", "/XObject");
				pdfDictionary.Elements.SetName("/Subtype", "/Image");
				this.Owner._irefTable.Add(pdfDictionary);
				pdfDictionary.Stream = new PdfDictionary.PdfStream(array, pdfDictionary);
				pdfDictionary.Elements["/Length"] = new PdfInteger(array.Length);
				pdfDictionary.Elements["/Filter"] = new PdfName("/FlateDecode");
				pdfDictionary.Elements["/Width"] = new PdfInteger((int)information.Width);
				pdfDictionary.Elements["/Height"] = new PdfInteger((int)information.Height);
				pdfDictionary.Elements["/BitsPerComponent"] = new PdfInteger(1);
				pdfDictionary.Elements["/ImageMask"] = new PdfBoolean(true);
				base.Elements["/Mask"] = pdfDictionary.Reference;
			}
			if (flag && flag2 && version >= 14)
			{
				byte[] array2 = flateDecode.Encode(imageDataBitmap.AlphaMask, this._document.Options.FlateEncodeMode);
				PdfDictionary pdfDictionary2 = new PdfDictionary(this._document);
				pdfDictionary2.Elements.SetName("/Type", "/XObject");
				pdfDictionary2.Elements.SetName("/Subtype", "/Image");
				this.Owner._irefTable.Add(pdfDictionary2);
				pdfDictionary2.Stream = new PdfDictionary.PdfStream(array2, pdfDictionary2);
				pdfDictionary2.Elements["/Length"] = new PdfInteger(array2.Length);
				pdfDictionary2.Elements["/Filter"] = new PdfName("/FlateDecode");
				pdfDictionary2.Elements["/Width"] = new PdfInteger((int)information.Width);
				pdfDictionary2.Elements["/Height"] = new PdfInteger((int)information.Height);
				pdfDictionary2.Elements["/BitsPerComponent"] = new PdfInteger(8);
				pdfDictionary2.Elements["/ColorSpace"] = new PdfName("/DeviceGray");
				base.Elements["/SMask"] = pdfDictionary2.Reference;
			}
			byte[] array3 = flateDecode.Encode(imageDataBitmap.Data, this._document.Options.FlateEncodeMode);
			base.Stream = new PdfDictionary.PdfStream(array3, this);
			base.Elements["/Length"] = new PdfInteger(array3.Length);
			base.Elements["/Filter"] = new PdfName("/FlateDecode");
			base.Elements["/Width"] = new PdfInteger((int)information.Width);
			base.Elements["/Height"] = new PdfInteger((int)information.Height);
			base.Elements["/BitsPerComponent"] = new PdfInteger(8);
			base.Elements["/ColorSpace"] = new PdfName("/DeviceRGB");
			if (this._image.Interpolate)
			{
				base.Elements["/Interpolate"] = PdfBoolean.True;
			}
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00025A72 File Offset: 0x00023C72
		private static int ReadWord(byte[] ab, int offset)
		{
			return (int)ab[offset] + 256 * (int)ab[offset + 1];
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x00025A83 File Offset: 0x00023C83
		private static int ReadDWord(byte[] ab, int offset)
		{
			return PdfImage.ReadWord(ab, offset) + 65536 * PdfImage.ReadWord(ab, offset + 2);
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x00025A9C File Offset: 0x00023C9C
		private void ReadTrueColorMemoryBitmap(int components, int bits, bool hasAlpha)
		{
			int version = this.Owner.Version;
			MemoryStream memoryStream = new MemoryStream();
			this._image._gdiImage.Save(memoryStream, ImageFormat.Bmp);
			int num = (int)memoryStream.Length;
			if (num > 0)
			{
				byte[] buffer = memoryStream.GetBuffer();
				int pixelHeight = this._image.PixelHeight;
				int pixelWidth = this._image.PixelWidth;
				if (PdfImage.ReadWord(buffer, 0) != 19778 || PdfImage.ReadDWord(buffer, 2) != num || PdfImage.ReadDWord(buffer, 14) != 40 || PdfImage.ReadDWord(buffer, 18) != pixelWidth || PdfImage.ReadDWord(buffer, 22) != pixelHeight)
				{
					throw new NotImplementedException("ReadTrueColorMemoryBitmap: unsupported format");
				}
				if (PdfImage.ReadWord(buffer, 26) != 1 || (!hasAlpha && PdfImage.ReadWord(buffer, 28) != components * bits) || (hasAlpha && PdfImage.ReadWord(buffer, 28) != (components + 1) * bits) || PdfImage.ReadDWord(buffer, 30) != 0)
				{
					throw new NotImplementedException("ReadTrueColorMemoryBitmap: unsupported format #2");
				}
				int num2 = PdfImage.ReadDWord(buffer, 10);
				int num3 = components;
				if (components == 4)
				{
					num3 = 3;
				}
				byte[] array = new byte[components * pixelWidth * pixelHeight];
				bool flag = false;
				bool flag2 = false;
				byte[] array2 = (hasAlpha ? new byte[pixelWidth * pixelHeight] : null);
				MonochromeMask monochromeMask = (hasAlpha ? new MonochromeMask(pixelWidth, pixelHeight) : null);
				int num4 = 0;
				if (num3 == 3)
				{
					for (int i = 0; i < pixelHeight; i++)
					{
						int num5 = 3 * (pixelHeight - 1 - i) * pixelWidth;
						int num6 = 0;
						if (hasAlpha)
						{
							monochromeMask.StartLine(i);
							num6 = (pixelHeight - 1 - i) * pixelWidth;
						}
						for (int j = 0; j < pixelWidth; j++)
						{
							array[num5] = buffer[num2 + num4 + 2];
							array[num5 + 1] = buffer[num2 + num4 + 1];
							array[num5 + 2] = buffer[num2 + num4];
							if (hasAlpha)
							{
								monochromeMask.AddPel((int)buffer[num2 + num4 + 3]);
								array2[num6] = buffer[num2 + num4 + 3];
								if ((!flag || !flag2) && buffer[num2 + num4 + 3] != 255)
								{
									flag = true;
									if (buffer[num2 + num4 + 3] != 0)
									{
										flag2 = true;
									}
								}
								num6++;
							}
							num4 += (hasAlpha ? 4 : components);
							num5 += 3;
						}
						num4 = 4 * ((num4 + 3) / 4);
					}
				}
				else if (components == 1)
				{
					throw new NotImplementedException("Image format not supported (grayscales).");
				}
				FlateDecode flateDecode = new FlateDecode();
				if (flag)
				{
					byte[] array3 = flateDecode.Encode(monochromeMask.MaskData, this._document.Options.FlateEncodeMode);
					PdfDictionary pdfDictionary = new PdfDictionary(this._document);
					pdfDictionary.Elements.SetName("/Type", "/XObject");
					pdfDictionary.Elements.SetName("/Subtype", "/Image");
					this.Owner._irefTable.Add(pdfDictionary);
					pdfDictionary.Stream = new PdfDictionary.PdfStream(array3, pdfDictionary);
					pdfDictionary.Elements["/Length"] = new PdfInteger(array3.Length);
					pdfDictionary.Elements["/Filter"] = new PdfName("/FlateDecode");
					pdfDictionary.Elements["/Width"] = new PdfInteger(pixelWidth);
					pdfDictionary.Elements["/Height"] = new PdfInteger(pixelHeight);
					pdfDictionary.Elements["/BitsPerComponent"] = new PdfInteger(1);
					pdfDictionary.Elements["/ImageMask"] = new PdfBoolean(true);
					base.Elements["/Mask"] = pdfDictionary.Reference;
				}
				if (flag && flag2 && version >= 14)
				{
					byte[] array4 = flateDecode.Encode(array2, this._document.Options.FlateEncodeMode);
					PdfDictionary pdfDictionary2 = new PdfDictionary(this._document);
					pdfDictionary2.Elements.SetName("/Type", "/XObject");
					pdfDictionary2.Elements.SetName("/Subtype", "/Image");
					this.Owner._irefTable.Add(pdfDictionary2);
					pdfDictionary2.Stream = new PdfDictionary.PdfStream(array4, pdfDictionary2);
					pdfDictionary2.Elements["/Length"] = new PdfInteger(array4.Length);
					pdfDictionary2.Elements["/Filter"] = new PdfName("/FlateDecode");
					pdfDictionary2.Elements["/Width"] = new PdfInteger(pixelWidth);
					pdfDictionary2.Elements["/Height"] = new PdfInteger(pixelHeight);
					pdfDictionary2.Elements["/BitsPerComponent"] = new PdfInteger(8);
					pdfDictionary2.Elements["/ColorSpace"] = new PdfName("/DeviceGray");
					base.Elements["/SMask"] = pdfDictionary2.Reference;
				}
				byte[] array5 = flateDecode.Encode(array, this._document.Options.FlateEncodeMode);
				base.Stream = new PdfDictionary.PdfStream(array5, this);
				base.Elements["/Length"] = new PdfInteger(array5.Length);
				base.Elements["/Filter"] = new PdfName("/FlateDecode");
				base.Elements["/Width"] = new PdfInteger(pixelWidth);
				base.Elements["/Height"] = new PdfInteger(pixelHeight);
				base.Elements["/BitsPerComponent"] = new PdfInteger(8);
				base.Elements["/ColorSpace"] = new PdfName("/DeviceRGB");
				if (this._image.Interpolate)
				{
					base.Elements["/Interpolate"] = PdfBoolean.True;
				}
			}
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0002602C File Offset: 0x0002422C
		private void ReadIndexedMemoryBitmap(int bits)
		{
			int version = this.Owner.Version;
			int num = -1;
			int num2 = -1;
			bool flag = false;
			MemoryStream memoryStream = new MemoryStream();
			this._image._gdiImage.Save(memoryStream, ImageFormat.Bmp);
			int num3 = (int)memoryStream.Length;
			if (num3 > 0)
			{
				byte[] array = new byte[num3];
				memoryStream.Seek(0L, SeekOrigin.Begin);
				memoryStream.Read(array, 0, num3);
				memoryStream.Close();
				int pixelHeight = this._image.PixelHeight;
				int pixelWidth = this._image.PixelWidth;
				if (PdfImage.ReadWord(array, 0) != 19778 || PdfImage.ReadDWord(array, 2) != num3 || PdfImage.ReadDWord(array, 14) != 40 || PdfImage.ReadDWord(array, 18) != pixelWidth || PdfImage.ReadDWord(array, 22) != pixelHeight)
				{
					throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format");
				}
				int num4 = PdfImage.ReadWord(array, 28);
				if (num4 != bits && (num4 == 1 || num4 == 4 || num4 == 8))
				{
					bits = num4;
				}
				if (PdfImage.ReadWord(array, 26) != 1 || PdfImage.ReadWord(array, 28) != bits || PdfImage.ReadDWord(array, 30) != 0)
				{
					throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format #2");
				}
				int num5 = PdfImage.ReadDWord(array, 10);
				int num6 = PdfImage.ReadDWord(array, 46);
				if ((num5 - 54) / 4 != num6)
				{
					throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format #3");
				}
				MonochromeMask monochromeMask = new MonochromeMask(pixelWidth, pixelHeight);
				bool flag2 = bits == 8 && (num6 == 256 || num6 == 0);
				int num7 = 0;
				byte[] array2 = new byte[3 * num6];
				for (int i = 0; i < num6; i++)
				{
					array2[3 * i] = array[54 + 4 * i + 2];
					array2[3 * i + 1] = array[54 + 4 * i + 1];
					array2[3 * i + 2] = array[54 + 4 * i];
					if (flag2)
					{
						flag2 = array2[3 * i] == array2[3 * i + 1] && array2[3 * i] == array2[3 * i + 2];
					}
					if (array[54 + 4 * i + 3] < 128)
					{
						if (num == -1)
						{
							num = i;
						}
						if (num2 == -1 || num2 == i - 1)
						{
							num2 = i;
						}
						if (num2 != i)
						{
							flag = true;
						}
					}
				}
				if (bits == 1)
				{
					if (num6 == 0)
					{
						num7 = 1;
					}
					if (num6 == 2)
					{
						if (array2[0] == 0 && array2[1] == 0 && array2[2] == 0 && array2[3] == 255 && array2[4] == 255 && array2[5] == 255)
						{
							num7 = 1;
						}
						if (array2[5] == 0 && array2[4] == 0 && array2[3] == 0 && array2[2] == 255 && array2[1] == 255 && array2[0] == 255)
						{
							num7 = -1;
						}
					}
				}
				bool flag3 = false;
				byte[] array3 = new byte[(pixelWidth * bits + 7) / 8 * pixelHeight];
				byte[] array4 = null;
				int num8 = 0;
				if (bits == 1)
				{
					byte[] array5 = new byte[array3.Length];
					int num9 = PdfImage.DoFaxEncodingGroup4(ref array5, array, (uint)num5, (uint)pixelWidth, (uint)pixelHeight);
					flag3 = num9 > 0;
					if (flag3)
					{
						if (num9 == 0)
						{
							num9 = int.MaxValue;
						}
						Array.Resize<byte>(ref array5, num9);
						array4 = array5;
						num8 = -1;
					}
				}
				int num10 = 0;
				if (bits != 8 && bits != 4 && bits != 1)
				{
					throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format #3");
				}
				int num11 = (pixelWidth * bits + 7) / 8;
				for (int j = 0; j < pixelHeight; j++)
				{
					monochromeMask.StartLine(j);
					int num12 = (pixelHeight - 1 - j) * ((pixelWidth * bits + 7) / 8);
					for (int k = 0; k < num11; k++)
					{
						if (flag2)
						{
							array3[num12] = array2[(int)(3 * array[num5 + num10])];
						}
						else
						{
							array3[num12] = array[num5 + num10];
						}
						if (num != -1)
						{
							int num13 = (int)array[num5 + num10];
							if (bits == 8)
							{
								monochromeMask.AddPel(num13 >= num && num13 <= num2);
							}
							else if (bits == 4)
							{
								int num14 = (num13 & 240) / 16;
								int num15 = num13 & 15;
								monochromeMask.AddPel(num14 >= num && num14 <= num2);
								monochromeMask.AddPel(num15 >= num && num15 <= num2);
							}
							else if (bits == 1)
							{
								for (int l = 1; l <= 8; l++)
								{
									int num16 = (num13 & 128) / 128;
									monochromeMask.AddPel(num16 >= num && num16 <= num2);
									num13 *= 2;
								}
							}
						}
						num10++;
						num12++;
					}
					num10 = 4 * ((num10 + 3) / 4);
				}
				FlateDecode flateDecode = new FlateDecode();
				if (num != -1 && num2 != -1)
				{
					if (!flag && version >= 13 && !flag2)
					{
						PdfArray pdfArray = new PdfArray(this._document);
						pdfArray.Elements.Add(new PdfInteger(num));
						pdfArray.Elements.Add(new PdfInteger(num2));
						base.Elements["/Mask"] = pdfArray;
					}
					else
					{
						byte[] array6 = flateDecode.Encode(monochromeMask.MaskData, this._document.Options.FlateEncodeMode);
						PdfDictionary pdfDictionary = new PdfDictionary(this._document);
						pdfDictionary.Elements.SetName("/Type", "/XObject");
						pdfDictionary.Elements.SetName("/Subtype", "/Image");
						this.Owner._irefTable.Add(pdfDictionary);
						pdfDictionary.Stream = new PdfDictionary.PdfStream(array6, pdfDictionary);
						pdfDictionary.Elements["/Length"] = new PdfInteger(array6.Length);
						pdfDictionary.Elements["/Filter"] = new PdfName("/FlateDecode");
						pdfDictionary.Elements["/Width"] = new PdfInteger(pixelWidth);
						pdfDictionary.Elements["/Height"] = new PdfInteger(pixelHeight);
						pdfDictionary.Elements["/BitsPerComponent"] = new PdfInteger(1);
						pdfDictionary.Elements["/ImageMask"] = new PdfBoolean(true);
						base.Elements["/Mask"] = pdfDictionary.Reference;
					}
				}
				byte[] array7 = flateDecode.Encode(array3, this._document.Options.FlateEncodeMode);
				byte[] array8 = (flag3 ? flateDecode.Encode(array4, this._document.Options.FlateEncodeMode) : null);
				bool flag4 = false;
				if (flag3 && (array4.Length < array7.Length || array8.Length < array7.Length))
				{
					flag4 = true;
					if (array4.Length < array7.Length)
					{
						base.Stream = new PdfDictionary.PdfStream(array4, this);
						base.Elements["/Length"] = new PdfInteger(array4.Length);
						base.Elements["/Filter"] = new PdfName("/CCITTFaxDecode");
						PdfDictionary pdfDictionary2 = new PdfDictionary();
						if (num8 != 0)
						{
							pdfDictionary2.Elements.Add("/K", new PdfInteger(num8));
						}
						if (num7 < 0)
						{
							pdfDictionary2.Elements.Add("/BlackIs1", new PdfBoolean(true));
						}
						pdfDictionary2.Elements.Add("/EndOfBlock", new PdfBoolean(false));
						pdfDictionary2.Elements.Add("/Columns", new PdfInteger(pixelWidth));
						pdfDictionary2.Elements.Add("/Rows", new PdfInteger(pixelHeight));
						base.Elements["/DecodeParms"] = pdfDictionary2;
					}
					else
					{
						base.Stream = new PdfDictionary.PdfStream(array8, this);
						base.Elements["/Length"] = new PdfInteger(array8.Length);
						PdfArray pdfArray2 = new PdfArray(this._document);
						pdfArray2.Elements.Add(new PdfName("/FlateDecode"));
						pdfArray2.Elements.Add(new PdfName("/CCITTFaxDecode"));
						base.Elements["/Filter"] = pdfArray2;
						PdfArray pdfArray3 = new PdfArray(this._document);
						PdfDictionary pdfDictionary3 = new PdfDictionary();
						PdfDictionary pdfDictionary4 = new PdfDictionary();
						if (num8 != 0)
						{
							pdfDictionary4.Elements.Add("/K", new PdfInteger(num8));
						}
						if (num7 < 0)
						{
							pdfDictionary4.Elements.Add("/BlackIs1", new PdfBoolean(true));
						}
						pdfDictionary4.Elements.Add("/EndOfBlock", new PdfBoolean(false));
						pdfDictionary4.Elements.Add("/Columns", new PdfInteger(pixelWidth));
						pdfDictionary4.Elements.Add("/Rows", new PdfInteger(pixelHeight));
						pdfArray3.Elements.Add(pdfDictionary3);
						pdfArray3.Elements.Add(pdfDictionary4);
						base.Elements["/DecodeParms"] = pdfArray3;
					}
				}
				else
				{
					base.Stream = new PdfDictionary.PdfStream(array7, this);
					base.Elements["/Length"] = new PdfInteger(array7.Length);
					base.Elements["/Filter"] = new PdfName("/FlateDecode");
				}
				base.Elements["/Width"] = new PdfInteger(pixelWidth);
				base.Elements["/Height"] = new PdfInteger(pixelHeight);
				base.Elements["/BitsPerComponent"] = new PdfInteger(bits);
				if ((flag4 && num7 == 0) || (!flag4 && num7 <= 0 && !flag2))
				{
					PdfDictionary pdfDictionary5 = new PdfDictionary(this._document);
					byte[] array9 = ((array2.Length >= 48) ? flateDecode.Encode(array2, this._document.Options.FlateEncodeMode) : null);
					if (array9 != null && array9.Length + 20 < array2.Length)
					{
						pdfDictionary5.CreateStream(array9);
						pdfDictionary5.Elements["/Length"] = new PdfInteger(array9.Length);
						pdfDictionary5.Elements["/Filter"] = new PdfName("/FlateDecode");
					}
					else
					{
						pdfDictionary5.CreateStream(array2);
						pdfDictionary5.Elements["/Length"] = new PdfInteger(array2.Length);
					}
					this.Owner._irefTable.Add(pdfDictionary5);
					PdfArray pdfArray4 = new PdfArray(this._document);
					pdfArray4.Elements.Add(new PdfName("/Indexed"));
					pdfArray4.Elements.Add(new PdfName("/DeviceRGB"));
					pdfArray4.Elements.Add(new PdfInteger(num6 - 1));
					pdfArray4.Elements.Add(pdfDictionary5.Reference);
					base.Elements["/ColorSpace"] = pdfArray4;
				}
				else
				{
					base.Elements["/ColorSpace"] = new PdfName("/DeviceGray");
				}
				if (this._image.Interpolate)
				{
					base.Elements["/Interpolate"] = PdfBoolean.True;
				}
			}
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x00026AD4 File Offset: 0x00024CD4
		private static uint CountOneBits(BitReader reader, uint bitsLeft)
		{
			uint num = 0U;
			uint num4;
			for (;;)
			{
				uint num3;
				int num2 = (int)reader.PeekByte(out num3);
				num4 = PdfImage._oneRuns[num2];
				if (num4 < num3)
				{
					break;
				}
				num += num3;
				if (num >= bitsLeft)
				{
					return bitsLeft;
				}
				reader.NextByte();
			}
			if (num4 > 0U)
			{
				reader.SkipBits(num4);
			}
			num += num4;
			if (num < bitsLeft)
			{
				return num;
			}
			return bitsLeft;
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x00026B20 File Offset: 0x00024D20
		private static uint CountZeroBits(BitReader reader, uint bitsLeft)
		{
			uint num = 0U;
			uint num4;
			for (;;)
			{
				uint num3;
				int num2 = (int)reader.PeekByte(out num3);
				num4 = PdfImage._zeroRuns[num2];
				if (num4 < num3)
				{
					break;
				}
				num += num3;
				if (num >= bitsLeft)
				{
					return bitsLeft;
				}
				reader.NextByte();
			}
			if (num4 > 0U)
			{
				reader.SkipBits(num4);
			}
			num += num4;
			if (num < bitsLeft)
			{
				return num;
			}
			return bitsLeft;
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x00026B6C File Offset: 0x00024D6C
		private static uint FindDifference(BitReader reader, uint bitStart, uint bitEnd, bool searchOne)
		{
			reader.SetPosition(bitStart);
			return bitStart + (searchOne ? PdfImage.CountOneBits(reader, bitEnd - bitStart) : PdfImage.CountZeroBits(reader, bitEnd - bitStart));
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00026B8E File Offset: 0x00024D8E
		private static uint FindDifferenceWithCheck(BitReader reader, uint bitStart, uint bitEnd, bool searchOne)
		{
			if (bitStart >= bitEnd)
			{
				return bitEnd;
			}
			return PdfImage.FindDifference(reader, bitStart, bitEnd, searchOne);
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x00026BA0 File Offset: 0x00024DA0
		private static void FaxEncode2DRow(BitWriter writer, uint bytesFileOffset, byte[] imageBits, uint currentRow, uint referenceRow, uint width, uint height, uint bytesPerLineBmp)
		{
			uint num = bytesFileOffset + (height - 1U - currentRow) * bytesPerLineBmp;
			BitReader bitReader = new BitReader(imageBits, num, width);
			BitReader bitReader2;
			if (referenceRow != 4294967295U)
			{
				uint num2 = bytesFileOffset + (height - 1U - referenceRow) * bytesPerLineBmp;
				bitReader2 = new BitReader(imageBits, num2, width);
			}
			else
			{
				byte[] array = new byte[bytesPerLineBmp];
				int num3 = 0;
				while ((long)num3 < (long)((ulong)bytesPerLineBmp))
				{
					array[num3] = byte.MaxValue;
					num3++;
				}
				bitReader2 = new BitReader(array, 0U, width);
			}
			uint num4 = 0U;
			uint num5 = ((!bitReader.GetBit(0U)) ? 0U : PdfImage.FindDifference(bitReader, 0U, width, true));
			uint num6 = ((!bitReader2.GetBit(0U)) ? 0U : PdfImage.FindDifference(bitReader2, 0U, width, true));
			for (;;)
			{
				uint num7 = PdfImage.FindDifferenceWithCheck(bitReader2, num6, width, bitReader2.GetBit(num6));
				if (num7 >= num5)
				{
					int num8 = (int)(num6 - num5);
					if (-3 > num8 || num8 > 3)
					{
						uint num9 = PdfImage.FindDifferenceWithCheck(bitReader, num5, width, bitReader.GetBit(num5));
						writer.WriteTableLine(PdfImage.HorizontalCodes, 0U);
						if (num4 + num5 == 0U || bitReader.GetBit(num4))
						{
							PdfImage.WriteSample(writer, num5 - num4, true);
							PdfImage.WriteSample(writer, num9 - num5, false);
						}
						else
						{
							PdfImage.WriteSample(writer, num5 - num4, false);
							PdfImage.WriteSample(writer, num9 - num5, true);
						}
						num4 = num9;
					}
					else
					{
						writer.WriteTableLine(PdfImage.VerticalCodes, (uint)(num8 + 3));
						num4 = num5;
					}
				}
				else
				{
					writer.WriteTableLine(PdfImage.PassCodes, 0U);
					num4 = num7;
				}
				if (num4 >= width)
				{
					break;
				}
				bool bit = bitReader.GetBit(num4);
				num5 = PdfImage.FindDifference(bitReader, num4, width, bit);
				num6 = PdfImage.FindDifference(bitReader2, num4, width, !bit);
				num6 = PdfImage.FindDifferenceWithCheck(bitReader2, num6, width, bit);
			}
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x00026D48 File Offset: 0x00024F48
		private static int DoFaxEncoding(ref byte[] imageData, byte[] imageBits, uint bytesFileOffset, uint width, uint height)
		{
			int num7;
			try
			{
				uint num = (width + 31U) / 32U * 4U;
				BitWriter bitWriter = new BitWriter(ref imageData);
				for (uint num2 = 0U; num2 < height; num2 += 1U)
				{
					uint num3 = bytesFileOffset + (height - 1U - num2) * num;
					BitReader bitReader = new BitReader(imageBits, num3, width);
					uint num4 = 0U;
					while (num4 < width)
					{
						uint num5 = PdfImage.CountOneBits(bitReader, width - num4);
						PdfImage.WriteSample(bitWriter, num5, true);
						num4 += num5;
						if (num4 < width)
						{
							uint num6 = PdfImage.CountZeroBits(bitReader, width - num4);
							PdfImage.WriteSample(bitWriter, num6, false);
							num4 += num6;
						}
					}
				}
				bitWriter.FlushBuffer();
				num7 = bitWriter.BytesWritten();
			}
			catch (Exception)
			{
				num7 = 0;
			}
			return num7;
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x00026DFC File Offset: 0x00024FFC
		internal static int DoFaxEncodingGroup4(ref byte[] imageData, byte[] imageBits, uint bytesFileOffset, uint width, uint height)
		{
			int num3;
			try
			{
				uint num = (width + 31U) / 32U * 4U;
				BitWriter bitWriter = new BitWriter(ref imageData);
				for (uint num2 = 0U; num2 < height; num2 += 1U)
				{
					PdfImage.FaxEncode2DRow(bitWriter, bytesFileOffset, imageBits, num2, (num2 != 0U) ? (num2 - 1U) : uint.MaxValue, width, height, num);
				}
				bitWriter.FlushBuffer();
				num3 = bitWriter.BytesWritten();
			}
			catch (Exception ex)
			{
				ex.GetType();
				num3 = 0;
			}
			return num3;
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x00026E6C File Offset: 0x0002506C
		private static void WriteSample(BitWriter writer, uint count, bool white)
		{
			uint[] array = (white ? PdfImage.WhiteTerminatingCodes : PdfImage.BlackTerminatingCodes);
			uint[] array2 = (white ? PdfImage.WhiteMakeUpCodes : PdfImage.BlackMakeUpCodes);
			while (count >= 2624U)
			{
				writer.WriteTableLine(array2, 39U);
				count -= 2560U;
			}
			if (count > 63U)
			{
				uint num = count / 64U - 1U;
				writer.WriteTableLine(array2, num);
				count -= (num + 1U) * 64U;
			}
			writer.WriteTableLine(array, count);
		}

		// Token: 0x0400054D RID: 1357
		private readonly XImage _image;

		// Token: 0x0400054E RID: 1358
		internal static readonly uint[] WhiteTerminatingCodes = new uint[]
		{
			53U, 8U, 7U, 6U, 7U, 4U, 8U, 4U, 11U, 4U,
			12U, 4U, 14U, 4U, 15U, 4U, 19U, 5U, 20U, 5U,
			7U, 5U, 8U, 5U, 8U, 6U, 3U, 6U, 52U, 6U,
			53U, 6U, 42U, 6U, 43U, 6U, 39U, 7U, 12U, 7U,
			8U, 7U, 23U, 7U, 3U, 7U, 4U, 7U, 40U, 7U,
			43U, 7U, 19U, 7U, 36U, 7U, 24U, 7U, 2U, 8U,
			3U, 8U, 26U, 8U, 27U, 8U, 18U, 8U, 19U, 8U,
			20U, 8U, 21U, 8U, 22U, 8U, 23U, 8U, 40U, 8U,
			41U, 8U, 42U, 8U, 43U, 8U, 44U, 8U, 45U, 8U,
			4U, 8U, 5U, 8U, 10U, 8U, 11U, 8U, 82U, 8U,
			83U, 8U, 84U, 8U, 85U, 8U, 36U, 8U, 37U, 8U,
			88U, 8U, 89U, 8U, 90U, 8U, 91U, 8U, 74U, 8U,
			75U, 8U, 50U, 8U, 51U, 8U, 52U, 8U
		};

		// Token: 0x0400054F RID: 1359
		internal static readonly uint[] BlackTerminatingCodes = new uint[]
		{
			55U, 10U, 2U, 3U, 3U, 2U, 2U, 2U, 3U, 3U,
			3U, 4U, 2U, 4U, 3U, 5U, 5U, 6U, 4U, 6U,
			4U, 7U, 5U, 7U, 7U, 7U, 4U, 8U, 7U, 8U,
			24U, 9U, 23U, 10U, 24U, 10U, 8U, 10U, 103U, 11U,
			104U, 11U, 108U, 11U, 55U, 11U, 40U, 11U, 23U, 11U,
			24U, 11U, 202U, 12U, 203U, 12U, 204U, 12U, 205U, 12U,
			104U, 12U, 105U, 12U, 106U, 12U, 107U, 12U, 210U, 12U,
			211U, 12U, 212U, 12U, 213U, 12U, 214U, 12U, 215U, 12U,
			108U, 12U, 109U, 12U, 218U, 12U, 219U, 12U, 84U, 12U,
			85U, 12U, 86U, 12U, 87U, 12U, 100U, 12U, 101U, 12U,
			82U, 12U, 83U, 12U, 36U, 12U, 55U, 12U, 56U, 12U,
			39U, 12U, 40U, 12U, 88U, 12U, 89U, 12U, 43U, 12U,
			44U, 12U, 90U, 12U, 102U, 12U, 103U, 12U
		};

		// Token: 0x04000550 RID: 1360
		internal static readonly uint[] WhiteMakeUpCodes = new uint[]
		{
			27U, 5U, 18U, 5U, 23U, 6U, 55U, 7U, 54U, 8U,
			55U, 8U, 100U, 8U, 101U, 8U, 104U, 8U, 103U, 8U,
			204U, 9U, 205U, 9U, 210U, 9U, 211U, 9U, 212U, 9U,
			213U, 9U, 214U, 9U, 215U, 9U, 216U, 9U, 217U, 9U,
			218U, 9U, 219U, 9U, 152U, 9U, 153U, 9U, 154U, 9U,
			24U, 6U, 155U, 9U, 8U, 11U, 12U, 11U, 13U, 11U,
			18U, 12U, 19U, 12U, 20U, 12U, 21U, 12U, 22U, 12U,
			23U, 12U, 28U, 12U, 29U, 12U, 30U, 12U, 31U, 12U,
			1U, 12U
		};

		// Token: 0x04000551 RID: 1361
		internal static readonly uint[] BlackMakeUpCodes = new uint[]
		{
			15U, 10U, 200U, 12U, 201U, 12U, 91U, 12U, 51U, 12U,
			52U, 12U, 53U, 12U, 108U, 13U, 109U, 13U, 74U, 13U,
			75U, 13U, 76U, 13U, 77U, 13U, 114U, 13U, 115U, 13U,
			116U, 13U, 117U, 13U, 118U, 13U, 119U, 13U, 82U, 13U,
			83U, 13U, 84U, 13U, 85U, 13U, 90U, 13U, 91U, 13U,
			100U, 13U, 101U, 13U, 8U, 11U, 12U, 11U, 13U, 11U,
			18U, 12U, 19U, 12U, 20U, 12U, 21U, 12U, 22U, 12U,
			23U, 12U, 28U, 12U, 29U, 12U, 30U, 12U, 31U, 12U,
			1U, 12U
		};

		// Token: 0x04000552 RID: 1362
		internal static readonly uint[] HorizontalCodes = new uint[] { 1U, 3U };

		// Token: 0x04000553 RID: 1363
		internal static readonly uint[] PassCodes = new uint[] { 1U, 4U };

		// Token: 0x04000554 RID: 1364
		internal static readonly uint[] VerticalCodes = new uint[]
		{
			3U, 7U, 3U, 6U, 3U, 3U, 1U, 1U, 2U, 3U,
			2U, 6U, 2U, 7U
		};

		// Token: 0x04000555 RID: 1365
		private static readonly uint[] _zeroRuns = new uint[]
		{
			8U, 7U, 6U, 6U, 5U, 5U, 5U, 5U, 4U, 4U,
			4U, 4U, 4U, 4U, 4U, 4U, 3U, 3U, 3U, 3U,
			3U, 3U, 3U, 3U, 3U, 3U, 3U, 3U, 3U, 3U,
			3U, 3U, 2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U,
			2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U,
			2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U,
			2U, 2U, 2U, 2U, 1U, 1U, 1U, 1U, 1U, 1U,
			1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U,
			1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U,
			1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U,
			1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U,
			1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U,
			1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U
		};

		// Token: 0x04000556 RID: 1366
		private static readonly uint[] _oneRuns = new uint[]
		{
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U,
			0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 1U, 1U,
			1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U,
			1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U,
			1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U,
			1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U,
			1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U,
			1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U, 1U,
			1U, 1U, 2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U,
			2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U,
			2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U, 2U,
			2U, 2U, 2U, 2U, 3U, 3U, 3U, 3U, 3U, 3U,
			3U, 3U, 3U, 3U, 3U, 3U, 3U, 3U, 3U, 3U,
			4U, 4U, 4U, 4U, 4U, 4U, 4U, 4U, 5U, 5U,
			5U, 5U, 6U, 6U, 7U, 8U
		};

		// Token: 0x0200010E RID: 270
		public new sealed class Keys : PdfXObject.Keys
		{
			// Token: 0x04000557 RID: 1367
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string Type = "/Type";

			// Token: 0x04000558 RID: 1368
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string Subtype = "/Subtype";

			// Token: 0x04000559 RID: 1369
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string Width = "/Width";

			// Token: 0x0400055A RID: 1370
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string Height = "/Height";

			// Token: 0x0400055B RID: 1371
			[KeyInfo(KeyType.NameOrArray | KeyType.Required)]
			public const string ColorSpace = "/ColorSpace";

			// Token: 0x0400055C RID: 1372
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string BitsPerComponent = "/BitsPerComponent";

			// Token: 0x0400055D RID: 1373
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string Intent = "/Intent";

			// Token: 0x0400055E RID: 1374
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string ImageMask = "/ImageMask";

			// Token: 0x0400055F RID: 1375
			[KeyInfo(KeyType.StreamOrArray | KeyType.Optional)]
			public const string Mask = "/Mask";

			// Token: 0x04000560 RID: 1376
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Decode = "/Decode";

			// Token: 0x04000561 RID: 1377
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string Interpolate = "/Interpolate";

			// Token: 0x04000562 RID: 1378
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Alternates = "/Alternates";

			// Token: 0x04000563 RID: 1379
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string SMask = "/SMask";

			// Token: 0x04000564 RID: 1380
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string SMaskInData = "/SMaskInData";

			// Token: 0x04000565 RID: 1381
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string Name = "/Name";

			// Token: 0x04000566 RID: 1382
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string StructParent = "/StructParent";

			// Token: 0x04000567 RID: 1383
			[KeyInfo(KeyType.String | KeyType.Optional)]
			public const string ID = "/ID";

			// Token: 0x04000568 RID: 1384
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string OPI = "/OPI";

			// Token: 0x04000569 RID: 1385
			[KeyInfo(KeyType.String | KeyType.Array | KeyType.Optional)]
			public const string Metadata = "/Metadata";

			// Token: 0x0400056A RID: 1386
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string OC = "/OC";
		}
	}
}
