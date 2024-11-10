using System;
using System.IO;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000117 RID: 279
	public class PdfObjectStream : PdfDictionary
	{
		// Token: 0x06000A1D RID: 2589 RVA: 0x00028874 File Offset: 0x00026A74
		public PdfObjectStream(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x00028880 File Offset: 0x00026A80
		internal PdfObjectStream(PdfDictionary dict)
			: base(dict)
		{
			int integer = base.Elements.GetInteger("/N");
			int integer2 = base.Elements.GetInteger("/First");
			base.Stream.TryUnfilter();
			Parser parser = new Parser(null, new MemoryStream(base.Stream.Value));
			this._header = parser.ReadObjectStreamHeader(integer, integer2);
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x000288E8 File Offset: 0x00026AE8
		internal void ReadReferences(PdfCrossReferenceTable xrefTable)
		{
			for (int i = 0; i < this._header.Length; i++)
			{
				int num = this._header[i][0];
				int num2 = this._header[i][1];
				PdfObjectID pdfObjectID = new PdfObjectID(num);
				PdfReference pdfReference = new PdfReference(pdfObjectID, -1);
				if (!xrefTable.Contains(pdfReference.ObjectID))
				{
					xrefTable.Add(pdfReference);
				}
				else
				{
					base.GetType();
				}
			}
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x0002894C File Offset: 0x00026B4C
		internal PdfReference ReadCompressedObject(int index)
		{
			Parser parser = new Parser(this._document, new MemoryStream(base.Stream.Value));
			int num = this._header[index][0];
			int num2 = this._header[index][1];
			return parser.ReadCompressedObject(num, num2);
		}

		// Token: 0x04000585 RID: 1413
		private readonly int[][] _header;

		// Token: 0x02000118 RID: 280
		public class Keys : PdfDictionary.PdfStream.Keys
		{
			// Token: 0x04000586 RID: 1414
			[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "ObjStm")]
			public const string Type = "/Type";

			// Token: 0x04000587 RID: 1415
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string N = "/N";

			// Token: 0x04000588 RID: 1416
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string First = "/First";

			// Token: 0x04000589 RID: 1417
			[KeyInfo(KeyType.String | KeyType.Array | KeyType.Optional)]
			public const string Extends = "/Extends";
		}
	}
}
