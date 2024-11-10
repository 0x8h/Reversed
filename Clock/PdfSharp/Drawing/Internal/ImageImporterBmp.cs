using System;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal
{
	// Token: 0x02000044 RID: 68
	internal class ImageImporterBmp : ImageImporterRoot, IImageImporter
	{
		// Token: 0x06000155 RID: 341 RVA: 0x0000A714 File Offset: 0x00008914
		public ImportedImage ImportImage(StreamReaderHelper stream, PdfDocument document)
		{
			try
			{
				stream.CurrentOffset = 0;
				int num;
				if (this.TestBitmapFileHeader(stream, out num))
				{
					ImagePrivateDataBitmap imagePrivateDataBitmap = new ImagePrivateDataBitmap(stream.Data, stream.Length);
					ImportedImage importedImage = new ImportedImageBitmap(this, imagePrivateDataBitmap, document);
					if (this.TestBitmapInfoHeader(stream, importedImage, num))
					{
						return importedImage;
					}
				}
			}
			catch (Exception)
			{
			}
			return null;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000A778 File Offset: 0x00008978
		private bool TestBitmapFileHeader(StreamReaderHelper stream, out int offset)
		{
			offset = 0;
			if (stream.GetWord(0, true) != 16973)
			{
				return false;
			}
			int dword = (int)stream.GetDWord(2, false);
			if (dword < stream.Length)
			{
				return false;
			}
			offset = (int)stream.GetDWord(10, false);
			stream.CurrentOffset += 14;
			return true;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000A7C8 File Offset: 0x000089C8
		private bool TestBitmapInfoHeader(StreamReaderHelper stream, ImportedImage ii, int offset)
		{
			int dword = (int)stream.GetDWord(0, false);
			if (dword == 40 || dword == 108 || dword == 124)
			{
				uint dword2 = stream.GetDWord(4, false);
				int dword3 = (int)stream.GetDWord(8, false);
				int word = (int)stream.GetWord(12, false);
				int word2 = (int)stream.GetWord(14, false);
				int dword4 = (int)stream.GetDWord(16, false);
				int dword5 = (int)stream.GetDWord(20, false);
				int dword6 = (int)stream.GetDWord(24, false);
				int dword7 = (int)stream.GetDWord(28, false);
				uint dword8 = stream.GetDWord(32, false);
				stream.GetDWord(36, false);
				if (dword5 != 0 && dword5 + offset > stream.Length)
				{
					return false;
				}
				ImagePrivateDataBitmap imagePrivateDataBitmap = (ImagePrivateDataBitmap)ii.Data;
				if (dword4 == 0 || dword4 == 3)
				{
					((ImagePrivateDataBitmap)ii.Data).Offset = offset;
					((ImagePrivateDataBitmap)ii.Data).ColorPaletteOffset = stream.CurrentOffset + dword;
					ii.Information.Width = dword2;
					ii.Information.Height = (uint)Math.Abs(dword3);
					ii.Information.HorizontalDPM = dword6;
					ii.Information.VerticalDPM = dword7;
					imagePrivateDataBitmap.FlippedImage = dword3 < 0;
					if (word == 1 && word2 == 24)
					{
						ii.Information.ImageFormat = ImageInformation.ImageFormats.RGB24;
						return true;
					}
					if (word == 1 && word2 == 32)
					{
						ii.Information.ImageFormat = ((dword4 == 0) ? ImageInformation.ImageFormats.RGB24 : ImageInformation.ImageFormats.ARGB32);
						return true;
					}
					if (word == 1 && word2 == 8)
					{
						ii.Information.ImageFormat = ImageInformation.ImageFormats.Palette8;
						ii.Information.ColorsUsed = dword8;
						return true;
					}
					if (word == 1 && word2 == 4)
					{
						ii.Information.ImageFormat = ImageInformation.ImageFormats.Palette4;
						ii.Information.ColorsUsed = dword8;
						return true;
					}
					if (word == 1 && word2 == 1)
					{
						ii.Information.ImageFormat = ImageInformation.ImageFormats.Palette1;
						ii.Information.ColorsUsed = dword8;
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000A99C File Offset: 0x00008B9C
		public ImageData PrepareImage(ImagePrivateData data)
		{
			throw new NotImplementedException();
		}
	}
}
