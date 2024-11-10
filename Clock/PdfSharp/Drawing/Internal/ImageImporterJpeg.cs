using System;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal
{
	// Token: 0x02000048 RID: 72
	internal class ImageImporterJpeg : ImageImporterRoot, IImageImporter
	{
		// Token: 0x06000178 RID: 376 RVA: 0x0000B16C File Offset: 0x0000936C
		public ImportedImage ImportImage(StreamReaderHelper stream, PdfDocument document)
		{
			try
			{
				stream.CurrentOffset = 0;
				if (this.TestFileHeader(stream))
				{
					stream.CurrentOffset += 2;
					ImagePrivateDataDct imagePrivateDataDct = new ImagePrivateDataDct(stream.Data, stream.Length);
					ImportedImage importedImage = new ImportedImageJpeg(this, imagePrivateDataDct, document);
					if (this.TestJfifHeader(stream, importedImage))
					{
						bool flag = false;
						bool flag2 = false;
						while (this.MoveToNextHeader(stream))
						{
							if (this.TestColorFormatHeader(stream, importedImage))
							{
								flag = true;
							}
							else if (this.TestInfoHeader(stream, importedImage))
							{
								flag2 = true;
							}
						}
						if (flag && flag2)
						{
							return importedImage;
						}
					}
				}
			}
			catch (Exception)
			{
			}
			return null;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000B20C File Offset: 0x0000940C
		private bool TestFileHeader(StreamReaderHelper stream)
		{
			return stream.GetWord(0, true) == 65496;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000B220 File Offset: 0x00009420
		private bool TestJfifHeader(StreamReaderHelper stream, ImportedImage ii)
		{
			if (stream.GetWord(0, true) == 65504 && stream.GetDWord(4, true) == 1246120262U)
			{
				int word = (int)stream.GetWord(2, true);
				if (word >= 16)
				{
					stream.GetWord(9, true);
					int @byte = (int)stream.GetByte(11);
					int word2 = (int)stream.GetWord(12, true);
					int word3 = (int)stream.GetWord(14, true);
					switch (@byte)
					{
					case 0:
						ii.Information.HorizontalAspectRatio = word2;
						ii.Information.VerticalAspectRatio = word3;
						break;
					case 1:
						ii.Information.HorizontalDPI = word2;
						ii.Information.VerticalDPI = word3;
						break;
					case 2:
						ii.Information.HorizontalDPM = word2 * 100;
						ii.Information.VerticalDPM = word3 * 100;
						break;
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000B314 File Offset: 0x00009514
		private bool TestColorFormatHeader(StreamReaderHelper stream, ImportedImage ii)
		{
			if (stream.GetWord(0, true) != 65498)
			{
				return false;
			}
			int @byte = (int)stream.GetByte(4);
			if (@byte < 1 || @byte > 4 || @byte == 2)
			{
				return false;
			}
			int word = (int)stream.GetWord(2, true);
			if (word != 6 + 2 * @byte)
			{
				return false;
			}
			ii.Information.ImageFormat = ((@byte == 3) ? ImageInformation.ImageFormats.JPEG : ((@byte == 1) ? ImageInformation.ImageFormats.JPEGGRAY : ImageInformation.ImageFormats.JPEGRGBW));
			return true;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000B378 File Offset: 0x00009578
		private bool TestInfoHeader(StreamReaderHelper stream, ImportedImage ii)
		{
			int word = (int)stream.GetWord(0, true);
			if ((word >= 65472 && word <= 65475) || (word >= 65481 && word <= 65483))
			{
				int word2 = (int)stream.GetWord(5, true);
				int word3 = (int)stream.GetWord(7, true);
				ii.Information.Width = (uint)word3;
				ii.Information.Height = (uint)word2;
				return true;
			}
			return false;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000B3DC File Offset: 0x000095DC
		private bool MoveToNextHeader(StreamReaderHelper stream)
		{
			int word = (int)stream.GetWord(2, true);
			int @byte = (int)stream.GetByte(0);
			int byte2 = (int)stream.GetByte(1);
			if (@byte != 255)
			{
				return false;
			}
			if (byte2 == 217)
			{
				return false;
			}
			if (byte2 == 1 || (byte2 >= 208 && byte2 <= 215))
			{
				stream.CurrentOffset += 2;
				return true;
			}
			stream.CurrentOffset += 2 + word;
			return true;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000B44B File Offset: 0x0000964B
		public ImageData PrepareImage(ImagePrivateData data)
		{
			throw new NotImplementedException();
		}
	}
}
