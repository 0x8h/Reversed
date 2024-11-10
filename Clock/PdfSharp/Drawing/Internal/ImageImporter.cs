using System;
using System.Collections.Generic;
using System.IO;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal
{
	// Token: 0x0200004C RID: 76
	internal class ImageImporter
	{
		// Token: 0x0600018A RID: 394 RVA: 0x0000B4F0 File Offset: 0x000096F0
		public static ImageImporter GetImageImporter()
		{
			return new ImageImporter();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000B4F7 File Offset: 0x000096F7
		private ImageImporter()
		{
			this._importers.Add(new ImageImporterJpeg());
			this._importers.Add(new ImageImporterBmp());
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000B52C File Offset: 0x0000972C
		public ImportedImage ImportImage(Stream stream, PdfDocument document)
		{
			StreamReaderHelper streamReaderHelper = new StreamReaderHelper(stream);
			foreach (IImageImporter imageImporter in this._importers)
			{
				streamReaderHelper.Reset();
				ImportedImage importedImage = imageImporter.ImportImage(streamReaderHelper, document);
				if (importedImage != null)
				{
					return importedImage;
				}
			}
			return null;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000B59C File Offset: 0x0000979C
		public ImportedImage ImportImage(string filename, PdfDocument document)
		{
			ImportedImage importedImage;
			using (Stream stream = File.OpenRead(filename))
			{
				importedImage = this.ImportImage(stream, document);
			}
			return importedImage;
		}

		// Token: 0x040001ED RID: 493
		private readonly List<IImageImporter> _importers = new List<IImageImporter>();
	}
}
