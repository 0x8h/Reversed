using System;
using System.Diagnostics;
using System.IO;
using PdfSharp.Pdf.AcroForms;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;

namespace PdfSharp.Pdf
{
	// Token: 0x02000198 RID: 408
	[DebuggerDisplay("(Name={Name})")]
	public sealed class PdfDocument : PdfObject, IDisposable
	{
		// Token: 0x06000CF0 RID: 3312 RVA: 0x00034574 File Offset: 0x00032774
		public PdfDocument()
		{
			this._creation = DateTime.Now;
			this._state = DocumentState.Created;
			this._version = 14;
			this.Initialize();
			this.Info.CreationDate = this._creation;
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x000345DC File Offset: 0x000327DC
		public PdfDocument(string filename)
		{
			this._creation = DateTime.Now;
			this._state = DocumentState.Created;
			this._version = 14;
			this.Initialize();
			this.Info.CreationDate = this._creation;
			this._outStream = new FileStream(filename, FileMode.Create);
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x00034650 File Offset: 0x00032850
		public PdfDocument(Stream outputStream)
		{
			this._creation = DateTime.Now;
			this._state = DocumentState.Created;
			this.Initialize();
			this.Info.CreationDate = this._creation;
			this._outStream = outputStream;
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x000346B4 File Offset: 0x000328B4
		internal PdfDocument(Lexer lexer)
		{
			this._creation = DateTime.Now;
			this._state = DocumentState.Imported;
			this._irefTable = new PdfCrossReferenceTable(this);
			this._lexer = lexer;
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x0003470D File Offset: 0x0003290D
		private void Initialize()
		{
			this._fontTable = new PdfFontTable(this);
			this._imageTable = new PdfImageTable(this);
			this._trailer = new PdfTrailer(this);
			this._irefTable = new PdfCrossReferenceTable(this);
			this._trailer.CreateNewDocumentIDs();
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x0003474B File Offset: 0x0003294B
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x00034754 File Offset: 0x00032954
		private void Dispose(bool disposing)
		{
			if (this._state != DocumentState.Disposed)
			{
			}
			this._state = DocumentState.Disposed;
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x00034770 File Offset: 0x00032970
		// (set) Token: 0x06000CF8 RID: 3320 RVA: 0x00034778 File Offset: 0x00032978
		public object Tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				this._tag = value;
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x00034781 File Offset: 0x00032981
		// (set) Token: 0x06000CFA RID: 3322 RVA: 0x00034789 File Offset: 0x00032989
		private string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x00034792 File Offset: 0x00032992
		private static string NewName()
		{
			return "Document " + PdfDocument._nameCount++;
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06000CFC RID: 3324 RVA: 0x000347B0 File Offset: 0x000329B0
		internal bool CanModify
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x000347B4 File Offset: 0x000329B4
		public void Close()
		{
			if (!this.CanModify)
			{
				throw new InvalidOperationException(PSSR.CannotModify);
			}
			if (this._outStream != null)
			{
				PdfStandardSecurityHandler pdfStandardSecurityHandler = null;
				if (this.SecuritySettings.DocumentSecurityLevel != PdfDocumentSecurityLevel.None)
				{
					pdfStandardSecurityHandler = this.SecuritySettings.SecurityHandler;
				}
				PdfWriter pdfWriter = new PdfWriter(this._outStream, pdfStandardSecurityHandler);
				try
				{
					this.DoSave(pdfWriter);
				}
				finally
				{
					pdfWriter.Close();
				}
			}
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x00034824 File Offset: 0x00032A24
		public void Save(string path)
		{
			if (!this.CanModify)
			{
				throw new InvalidOperationException(PSSR.CannotModify);
			}
			using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				this.Save(stream);
			}
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x00034874 File Offset: 0x00032A74
		public void Save(Stream stream, bool closeStream)
		{
			if (!this.CanModify)
			{
				throw new InvalidOperationException(PSSR.CannotModify);
			}
			string text = "";
			if (!this.CanSave(ref text))
			{
				throw new PdfSharpException(text);
			}
			PdfStandardSecurityHandler pdfStandardSecurityHandler = null;
			if (this.SecuritySettings.DocumentSecurityLevel != PdfDocumentSecurityLevel.None)
			{
				pdfStandardSecurityHandler = this.SecuritySettings.SecurityHandler;
			}
			PdfWriter pdfWriter = null;
			try
			{
				pdfWriter = new PdfWriter(stream, pdfStandardSecurityHandler);
				this.DoSave(pdfWriter);
			}
			finally
			{
				if (stream != null)
				{
					if (closeStream)
					{
						stream.Close();
					}
					else
					{
						stream.Position = 0L;
					}
				}
				if (pdfWriter != null)
				{
					pdfWriter.Close(closeStream);
				}
			}
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x0003490C File Offset: 0x00032B0C
		public void Save(Stream stream)
		{
			this.Save(stream, false);
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x00034918 File Offset: 0x00032B18
		private void DoSave(PdfWriter writer)
		{
			if (this._pages != null && this._pages.Count != 0)
			{
				try
				{
					if (this._trailer is PdfCrossReferenceStream)
					{
						this._trailer = new PdfTrailer((PdfCrossReferenceStream)this._trailer);
					}
					bool flag = this._securitySettings.DocumentSecurityLevel != PdfDocumentSecurityLevel.None;
					if (flag)
					{
						PdfStandardSecurityHandler securityHandler = this._securitySettings.SecurityHandler;
						if (securityHandler.Reference == null)
						{
							this._irefTable.Add(securityHandler);
						}
						this._trailer.Elements["/Encrypt"] = this._securitySettings.SecurityHandler.Reference;
					}
					else
					{
						this._trailer.Elements.Remove("/Encrypt");
					}
					this.PrepareForSave();
					if (flag)
					{
						this._securitySettings.SecurityHandler.PrepareEncryption();
					}
					writer.WriteFileHeader(this);
					PdfReference[] allReferences = this._irefTable.AllReferences;
					int num = allReferences.Length;
					for (int i = 0; i < num; i++)
					{
						PdfReference pdfReference = allReferences[i];
						pdfReference.Position = writer.Position;
						pdfReference.Value.WriteObject(writer);
					}
					int position = writer.Position;
					this._irefTable.WriteObject(writer);
					writer.WriteRaw("trailer\n");
					this._trailer.Elements.SetInteger("/Size", num + 1);
					this._trailer.WriteObject(writer);
					writer.WriteEof(this, position);
				}
				finally
				{
					if (writer != null)
					{
						writer.Stream.Flush();
					}
				}
				return;
			}
			if (this._outStream != null)
			{
				throw new InvalidOperationException("Cannot save a PDF document with no pages. Do not use \"public PdfDocument(string filename)\" or \"public PdfDocument(Stream outputStream)\" if you want to open an existing PDF document from a file or stream; use PdfReader.Open() for that purpose.");
			}
			throw new InvalidOperationException("Cannot save a PDF document with no pages.");
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x00034AC8 File Offset: 0x00032CC8
		internal override void PrepareForSave()
		{
			PdfDocumentInformation info = this.Info;
			string text = "PDFsharp 1.50.4000 (www.pdfsharp.com)";
			if (!"0".Equals("0"))
			{
				text = "PDFsharp 1.50.4000.0 (www.pdfsharp.com)";
			}
			if (info.Elements["/Creator"] == null)
			{
				info.Creator = text;
			}
			string text2 = info.Producer;
			if (text2.Length == 0)
			{
				text2 = text;
			}
			else if (!text2.StartsWith("PDFsharp"))
			{
				text2 = text + " (Original: " + text2 + ")";
			}
			info.Elements.SetString("/Producer", text2);
			if (this._fontTable != null)
			{
				this._fontTable.PrepareForSave();
			}
			this.Catalog.PrepareForSave();
			int num = this._irefTable.Compact();
			this._irefTable.Renumber();
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x00034B8C File Offset: 0x00032D8C
		public bool CanSave(ref string message)
		{
			return this.SecuritySettings.CanSave(ref message);
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x00034B9F File Offset: 0x00032D9F
		internal bool HasVersion(string version)
		{
			return string.Compare(this.Catalog.Version, version) >= 0;
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06000D05 RID: 3333 RVA: 0x00034BB8 File Offset: 0x00032DB8
		public PdfDocumentOptions Options
		{
			get
			{
				if (this._options == null)
				{
					this._options = new PdfDocumentOptions(this);
				}
				return this._options;
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06000D06 RID: 3334 RVA: 0x00034BD4 File Offset: 0x00032DD4
		public PdfDocumentSettings Settings
		{
			get
			{
				if (this._settings == null)
				{
					this._settings = new PdfDocumentSettings(this);
				}
				return this._settings;
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06000D07 RID: 3335 RVA: 0x00034BF0 File Offset: 0x00032DF0
		internal bool EarlyWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06000D08 RID: 3336 RVA: 0x00034BF3 File Offset: 0x00032DF3
		// (set) Token: 0x06000D09 RID: 3337 RVA: 0x00034BFB File Offset: 0x00032DFB
		public int Version
		{
			get
			{
				return this._version;
			}
			set
			{
				if (!this.CanModify)
				{
					throw new InvalidOperationException(PSSR.CannotModify);
				}
				if (value < 12 || value > 17)
				{
					throw new ArgumentException(PSSR.InvalidVersionNumber, "value");
				}
				this._version = value;
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06000D0A RID: 3338 RVA: 0x00034C34 File Offset: 0x00032E34
		public int PageCount
		{
			get
			{
				if (this.CanModify)
				{
					return this.Pages.Count;
				}
				PdfDictionary pdfDictionary = (PdfDictionary)this.Catalog.Elements.GetObject("/Pages");
				return pdfDictionary.Elements.GetInteger("/Count");
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06000D0B RID: 3339 RVA: 0x00034C80 File Offset: 0x00032E80
		public long FileSize
		{
			get
			{
				return this._fileSize;
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06000D0C RID: 3340 RVA: 0x00034C88 File Offset: 0x00032E88
		public string FullPath
		{
			get
			{
				return this._fullPath;
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06000D0D RID: 3341 RVA: 0x00034C90 File Offset: 0x00032E90
		public Guid Guid
		{
			get
			{
				return this._guid;
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06000D0E RID: 3342 RVA: 0x00034C98 File Offset: 0x00032E98
		internal PdfDocument.DocumentHandle Handle
		{
			get
			{
				if (this._handle == null)
				{
					this._handle = new PdfDocument.DocumentHandle(this);
				}
				return this._handle;
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06000D0F RID: 3343 RVA: 0x00034CBA File Offset: 0x00032EBA
		public bool IsImported
		{
			get
			{
				return (this._state & DocumentState.Imported) != (DocumentState)0;
			}
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06000D10 RID: 3344 RVA: 0x00034CCA File Offset: 0x00032ECA
		public bool IsReadOnly
		{
			get
			{
				return this._openMode != PdfDocumentOpenMode.Modify;
			}
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x00034CD8 File Offset: 0x00032ED8
		internal Exception DocumentNotImported()
		{
			return new InvalidOperationException("Document not imported.");
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x06000D12 RID: 3346 RVA: 0x00034CE4 File Offset: 0x00032EE4
		public PdfDocumentInformation Info
		{
			get
			{
				if (this._info == null)
				{
					this._info = this._trailer.Info;
				}
				return this._info;
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06000D13 RID: 3347 RVA: 0x00034D05 File Offset: 0x00032F05
		// (set) Token: 0x06000D14 RID: 3348 RVA: 0x00034D2B File Offset: 0x00032F2B
		public PdfCustomValues CustomValues
		{
			get
			{
				if (this._customValues == null)
				{
					this._customValues = PdfCustomValues.Get(this.Catalog.Elements);
				}
				return this._customValues;
			}
			set
			{
				if (value != null)
				{
					throw new ArgumentException("Only null is allowed to clear all custom values.");
				}
				PdfCustomValues.Remove(this.Catalog.Elements);
				this._customValues = null;
			}
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06000D15 RID: 3349 RVA: 0x00034D52 File Offset: 0x00032F52
		public PdfPages Pages
		{
			get
			{
				if (this._pages == null)
				{
					this._pages = this.Catalog.Pages;
				}
				return this._pages;
			}
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06000D16 RID: 3350 RVA: 0x00034D73 File Offset: 0x00032F73
		// (set) Token: 0x06000D17 RID: 3351 RVA: 0x00034D80 File Offset: 0x00032F80
		public PdfPageLayout PageLayout
		{
			get
			{
				return this.Catalog.PageLayout;
			}
			set
			{
				if (!this.CanModify)
				{
					throw new InvalidOperationException(PSSR.CannotModify);
				}
				this.Catalog.PageLayout = value;
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x00034DA1 File Offset: 0x00032FA1
		// (set) Token: 0x06000D19 RID: 3353 RVA: 0x00034DAE File Offset: 0x00032FAE
		public PdfPageMode PageMode
		{
			get
			{
				return this.Catalog.PageMode;
			}
			set
			{
				if (!this.CanModify)
				{
					throw new InvalidOperationException(PSSR.CannotModify);
				}
				this.Catalog.PageMode = value;
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06000D1A RID: 3354 RVA: 0x00034DCF File Offset: 0x00032FCF
		public PdfViewerPreferences ViewerPreferences
		{
			get
			{
				return this.Catalog.ViewerPreferences;
			}
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06000D1B RID: 3355 RVA: 0x00034DDC File Offset: 0x00032FDC
		public PdfOutlineCollection Outlines
		{
			get
			{
				return this.Catalog.Outlines;
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06000D1C RID: 3356 RVA: 0x00034DE9 File Offset: 0x00032FE9
		public PdfAcroForm AcroForm
		{
			get
			{
				return this.Catalog.AcroForm;
			}
		}

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06000D1D RID: 3357 RVA: 0x00034DF6 File Offset: 0x00032FF6
		// (set) Token: 0x06000D1E RID: 3358 RVA: 0x00034E03 File Offset: 0x00033003
		public string Language
		{
			get
			{
				return this.Catalog.Language;
			}
			set
			{
				this.Catalog.Language = value;
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06000D1F RID: 3359 RVA: 0x00034E14 File Offset: 0x00033014
		public PdfSecuritySettings SecuritySettings
		{
			get
			{
				PdfSecuritySettings pdfSecuritySettings;
				if ((pdfSecuritySettings = this._securitySettings) == null)
				{
					pdfSecuritySettings = (this._securitySettings = new PdfSecuritySettings(this));
				}
				return pdfSecuritySettings;
			}
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06000D20 RID: 3360 RVA: 0x00034E3C File Offset: 0x0003303C
		internal PdfFontTable FontTable
		{
			get
			{
				PdfFontTable pdfFontTable;
				if ((pdfFontTable = this._fontTable) == null)
				{
					pdfFontTable = (this._fontTable = new PdfFontTable(this));
				}
				return pdfFontTable;
			}
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06000D21 RID: 3361 RVA: 0x00034E62 File Offset: 0x00033062
		internal PdfImageTable ImageTable
		{
			get
			{
				if (this._imageTable == null)
				{
					this._imageTable = new PdfImageTable(this);
				}
				return this._imageTable;
			}
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06000D22 RID: 3362 RVA: 0x00034E80 File Offset: 0x00033080
		internal PdfFormXObjectTable FormTable
		{
			get
			{
				PdfFormXObjectTable pdfFormXObjectTable;
				if ((pdfFormXObjectTable = this._formTable) == null)
				{
					pdfFormXObjectTable = (this._formTable = new PdfFormXObjectTable(this));
				}
				return pdfFormXObjectTable;
			}
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06000D23 RID: 3363 RVA: 0x00034EA8 File Offset: 0x000330A8
		internal PdfExtGStateTable ExtGStateTable
		{
			get
			{
				PdfExtGStateTable pdfExtGStateTable;
				if ((pdfExtGStateTable = this._extGStateTable) == null)
				{
					pdfExtGStateTable = (this._extGStateTable = new PdfExtGStateTable(this));
				}
				return pdfExtGStateTable;
			}
		}

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06000D24 RID: 3364 RVA: 0x00034ED0 File Offset: 0x000330D0
		internal PdfCatalog Catalog
		{
			get
			{
				PdfCatalog pdfCatalog;
				if ((pdfCatalog = this._catalog) == null)
				{
					pdfCatalog = (this._catalog = this._trailer.Root);
				}
				return pdfCatalog;
			}
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06000D25 RID: 3365 RVA: 0x00034EFC File Offset: 0x000330FC
		public new PdfInternals Internals
		{
			get
			{
				PdfInternals pdfInternals;
				if ((pdfInternals = this._internals) == null)
				{
					pdfInternals = (this._internals = new PdfInternals(this));
				}
				return pdfInternals;
			}
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x00034F22 File Offset: 0x00033122
		public PdfPage AddPage()
		{
			if (!this.CanModify)
			{
				throw new InvalidOperationException(PSSR.CannotModify);
			}
			return this.Catalog.Pages.Add();
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x00034F47 File Offset: 0x00033147
		public PdfPage AddPage(PdfPage page)
		{
			if (!this.CanModify)
			{
				throw new InvalidOperationException(PSSR.CannotModify);
			}
			return this.Catalog.Pages.Add(page);
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x00034F6D File Offset: 0x0003316D
		public PdfPage InsertPage(int index)
		{
			if (!this.CanModify)
			{
				throw new InvalidOperationException(PSSR.CannotModify);
			}
			return this.Catalog.Pages.Insert(index);
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x00034F93 File Offset: 0x00033193
		public PdfPage InsertPage(int index, PdfPage page)
		{
			if (!this.CanModify)
			{
				throw new InvalidOperationException(PSSR.CannotModify);
			}
			return this.Catalog.Pages.Insert(index, page);
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06000D2A RID: 3370 RVA: 0x00034FBA File Offset: 0x000331BA
		public PdfStandardSecurityHandler SecurityHandler
		{
			get
			{
				return this._trailer.SecurityHandler;
			}
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x00034FC7 File Offset: 0x000331C7
		internal void OnExternalDocumentFinalized(PdfDocument.DocumentHandle handle)
		{
			if (PdfDocument.tls != null)
			{
				PdfDocument.tls.DetachDocument(handle);
			}
			if (this._formTable != null)
			{
				this._formTable.DetachDocument(handle);
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06000D2C RID: 3372 RVA: 0x00034FEF File Offset: 0x000331EF
		internal static ThreadLocalStorage Tls
		{
			get
			{
				ThreadLocalStorage threadLocalStorage;
				if ((threadLocalStorage = PdfDocument.tls) == null)
				{
					threadLocalStorage = (PdfDocument.tls = new ThreadLocalStorage());
				}
				return threadLocalStorage;
			}
		}

		// Token: 0x04000849 RID: 2121
		internal DocumentState _state;

		// Token: 0x0400084A RID: 2122
		internal PdfDocumentOpenMode _openMode;

		// Token: 0x0400084B RID: 2123
		private object _tag;

		// Token: 0x0400084C RID: 2124
		private string _name = PdfDocument.NewName();

		// Token: 0x0400084D RID: 2125
		private static int _nameCount;

		// Token: 0x0400084E RID: 2126
		private PdfDocumentOptions _options;

		// Token: 0x0400084F RID: 2127
		private PdfDocumentSettings _settings;

		// Token: 0x04000850 RID: 2128
		internal int _version;

		// Token: 0x04000851 RID: 2129
		internal long _fileSize;

		// Token: 0x04000852 RID: 2130
		internal string _fullPath = string.Empty;

		// Token: 0x04000853 RID: 2131
		private Guid _guid = Guid.NewGuid();

		// Token: 0x04000854 RID: 2132
		private PdfDocument.DocumentHandle _handle;

		// Token: 0x04000855 RID: 2133
		private PdfDocumentInformation _info;

		// Token: 0x04000856 RID: 2134
		private PdfCustomValues _customValues;

		// Token: 0x04000857 RID: 2135
		private PdfPages _pages;

		// Token: 0x04000858 RID: 2136
		internal PdfSecuritySettings _securitySettings;

		// Token: 0x04000859 RID: 2137
		private PdfFontTable _fontTable;

		// Token: 0x0400085A RID: 2138
		private PdfImageTable _imageTable;

		// Token: 0x0400085B RID: 2139
		private PdfFormXObjectTable _formTable;

		// Token: 0x0400085C RID: 2140
		private PdfExtGStateTable _extGStateTable;

		// Token: 0x0400085D RID: 2141
		private PdfCatalog _catalog;

		// Token: 0x0400085E RID: 2142
		private PdfInternals _internals;

		// Token: 0x0400085F RID: 2143
		internal PdfTrailer _trailer;

		// Token: 0x04000860 RID: 2144
		internal PdfCrossReferenceTable _irefTable;

		// Token: 0x04000861 RID: 2145
		internal Stream _outStream;

		// Token: 0x04000862 RID: 2146
		internal Lexer _lexer;

		// Token: 0x04000863 RID: 2147
		internal DateTime _creation;

		// Token: 0x04000864 RID: 2148
		[ThreadStatic]
		private static ThreadLocalStorage tls;

		// Token: 0x02000199 RID: 409
		[DebuggerDisplay("(ID={ID}, alive={IsAlive})")]
		internal class DocumentHandle
		{
			// Token: 0x06000D2D RID: 3373 RVA: 0x00035005 File Offset: 0x00033205
			public DocumentHandle(PdfDocument document)
			{
				this._weakRef = new WeakReference(document);
				this.ID = document._guid.ToString("B").ToUpper();
			}

			// Token: 0x17000484 RID: 1156
			// (get) Token: 0x06000D2E RID: 3374 RVA: 0x00035034 File Offset: 0x00033234
			public bool IsAlive
			{
				get
				{
					return this._weakRef.IsAlive;
				}
			}

			// Token: 0x17000485 RID: 1157
			// (get) Token: 0x06000D2F RID: 3375 RVA: 0x00035041 File Offset: 0x00033241
			public PdfDocument Target
			{
				get
				{
					return this._weakRef.Target as PdfDocument;
				}
			}

			// Token: 0x06000D30 RID: 3376 RVA: 0x00035054 File Offset: 0x00033254
			public override bool Equals(object obj)
			{
				PdfDocument.DocumentHandle documentHandle = obj as PdfDocument.DocumentHandle;
				return !object.ReferenceEquals(documentHandle, null) && this.ID == documentHandle.ID;
			}

			// Token: 0x06000D31 RID: 3377 RVA: 0x00035084 File Offset: 0x00033284
			public override int GetHashCode()
			{
				return this.ID.GetHashCode();
			}

			// Token: 0x06000D32 RID: 3378 RVA: 0x00035091 File Offset: 0x00033291
			public static bool operator ==(PdfDocument.DocumentHandle left, PdfDocument.DocumentHandle right)
			{
				if (object.ReferenceEquals(left, null))
				{
					return object.ReferenceEquals(right, null);
				}
				return left.Equals(right);
			}

			// Token: 0x06000D33 RID: 3379 RVA: 0x000350AB File Offset: 0x000332AB
			public static bool operator !=(PdfDocument.DocumentHandle left, PdfDocument.DocumentHandle right)
			{
				return !(left == right);
			}

			// Token: 0x04000865 RID: 2149
			private readonly WeakReference _weakRef;

			// Token: 0x04000866 RID: 2150
			public string ID;
		}
	}
}
