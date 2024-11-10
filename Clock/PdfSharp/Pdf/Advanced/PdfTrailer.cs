using System;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x020000F4 RID: 244
	internal class PdfTrailer : PdfDictionary
	{
		// Token: 0x06000950 RID: 2384 RVA: 0x00022BB3 File Offset: 0x00020DB3
		public PdfTrailer(PdfDocument document)
			: base(document)
		{
			this._document = document;
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00022BC4 File Offset: 0x00020DC4
		public PdfTrailer(PdfCrossReferenceStream trailer)
			: base(trailer._document)
		{
			this._document = trailer._document;
			PdfReference reference = trailer.Elements.GetReference("/Info");
			if (reference != null)
			{
				base.Elements.SetReference("/Info", reference);
			}
			base.Elements.SetReference("/Root", trailer.Elements.GetReference("/Root"));
			base.Elements.SetInteger("/Size", trailer.Elements.GetInteger("/Size"));
			PdfArray array = trailer.Elements.GetArray("/ID");
			if (array != null)
			{
				base.Elements.SetValue("/ID", array);
			}
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x00022C73 File Offset: 0x00020E73
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x00022C85 File Offset: 0x00020E85
		public int Size
		{
			get
			{
				return base.Elements.GetInteger("/Size");
			}
			set
			{
				base.Elements.SetInteger("/Size", value);
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x00022C98 File Offset: 0x00020E98
		public PdfDocumentInformation Info
		{
			get
			{
				return (PdfDocumentInformation)base.Elements.GetValue("/Info", VCF.CreateIndirect);
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000955 RID: 2389 RVA: 0x00022CB0 File Offset: 0x00020EB0
		public PdfCatalog Root
		{
			get
			{
				return (PdfCatalog)base.Elements.GetValue("/Root", VCF.CreateIndirect);
			}
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x00022CC8 File Offset: 0x00020EC8
		public string GetDocumentID(int index)
		{
			if (index < 0 || index > 1)
			{
				throw new ArgumentOutOfRangeException("index", index, "Index must be 0 or 1.");
			}
			PdfArray pdfArray = base.Elements["/ID"] as PdfArray;
			if (pdfArray == null || pdfArray.Elements.Count < 2)
			{
				return "";
			}
			PdfItem pdfItem = pdfArray.Elements[index];
			if (pdfItem is PdfString)
			{
				return ((PdfString)pdfItem).Value;
			}
			return "";
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x00022D48 File Offset: 0x00020F48
		public void SetDocumentID(int index, string value)
		{
			if (index < 0 || index > 1)
			{
				throw new ArgumentOutOfRangeException("index", index, "Index must be 0 or 1.");
			}
			PdfArray pdfArray = base.Elements["/ID"] as PdfArray;
			if (pdfArray == null || pdfArray.Elements.Count < 2)
			{
				pdfArray = this.CreateNewDocumentIDs();
			}
			pdfArray.Elements[index] = new PdfString(value, PdfStringFlags.HexLiteral);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00022DB8 File Offset: 0x00020FB8
		internal PdfArray CreateNewDocumentIDs()
		{
			PdfArray pdfArray = new PdfArray(this._document);
			byte[] array = Guid.NewGuid().ToByteArray();
			string @string = PdfEncoders.RawEncoding.GetString(array, 0, array.Length);
			pdfArray.Elements.Add(new PdfString(@string, PdfStringFlags.HexLiteral));
			pdfArray.Elements.Add(new PdfString(@string, PdfStringFlags.HexLiteral));
			base.Elements["/ID"] = pdfArray;
			return pdfArray;
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000959 RID: 2393 RVA: 0x00022E2D File Offset: 0x0002102D
		public PdfStandardSecurityHandler SecurityHandler
		{
			get
			{
				if (this._securityHandler == null)
				{
					this._securityHandler = (PdfStandardSecurityHandler)base.Elements.GetValue("/Encrypt", VCF.CreateIndirect);
				}
				return this._securityHandler;
			}
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x00022E5C File Offset: 0x0002105C
		internal override void WriteObject(PdfWriter writer)
		{
			this._elements.Remove("/XRefStm");
			PdfStandardSecurityHandler securityHandler = writer.SecurityHandler;
			writer.SecurityHandler = null;
			base.WriteObject(writer);
			writer.SecurityHandler = securityHandler;
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x00022E98 File Offset: 0x00021098
		internal void Finish()
		{
			PdfReference pdfReference = this._document._trailer.Elements["/Root"] as PdfReference;
			if (pdfReference != null && pdfReference.Value == null)
			{
				pdfReference = this._document._irefTable[pdfReference.ObjectID];
				this._document._trailer.Elements["/Root"] = pdfReference;
			}
			pdfReference = this._document._trailer.Elements["/Info"] as PdfReference;
			if (pdfReference != null && pdfReference.Value == null)
			{
				pdfReference = this._document._irefTable[pdfReference.ObjectID];
				this._document._trailer.Elements["/Info"] = pdfReference;
			}
			pdfReference = this._document._trailer.Elements["/Encrypt"] as PdfReference;
			if (pdfReference != null)
			{
				pdfReference = this._document._irefTable[pdfReference.ObjectID];
				this._document._trailer.Elements["/Encrypt"] = pdfReference;
				pdfReference.Value = this._document._trailer._securityHandler;
				this._document._trailer._securityHandler.Reference = pdfReference;
				pdfReference.Value.Reference = pdfReference;
			}
			base.Elements.Remove("/Prev");
			this._document._irefTable.IsUnderConstruction = false;
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x0002300E File Offset: 0x0002120E
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfTrailer.Keys.Meta;
			}
		}

		// Token: 0x040004DB RID: 1243
		internal PdfStandardSecurityHandler _securityHandler;

		// Token: 0x020000F5 RID: 245
		internal class Keys : KeysBase
		{
			// Token: 0x1700038D RID: 909
			// (get) Token: 0x0600095D RID: 2397 RVA: 0x00023015 File Offset: 0x00021215
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfTrailer.Keys._meta) == null)
					{
						dictionaryMeta = (PdfTrailer.Keys._meta = KeysBase.CreateMeta(typeof(PdfTrailer.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040004DC RID: 1244
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string Size = "/Size";

			// Token: 0x040004DD RID: 1245
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string Prev = "/Prev";

			// Token: 0x040004DE RID: 1246
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required, typeof(PdfCatalog))]
			public const string Root = "/Root";

			// Token: 0x040004DF RID: 1247
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfStandardSecurityHandler))]
			public const string Encrypt = "/Encrypt";

			// Token: 0x040004E0 RID: 1248
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional, typeof(PdfDocumentInformation))]
			public const string Info = "/Info";

			// Token: 0x040004E1 RID: 1249
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string ID = "/ID";

			// Token: 0x040004E2 RID: 1250
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string XRefStm = "/XRefStm";

			// Token: 0x040004E3 RID: 1251
			private static DictionaryMeta _meta;
		}
	}
}
