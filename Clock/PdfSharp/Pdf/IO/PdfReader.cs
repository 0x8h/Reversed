using System;
using System.Collections.Generic;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.Security;

namespace PdfSharp.Pdf.IO
{
	// Token: 0x02000174 RID: 372
	public static class PdfReader
	{
		// Token: 0x06000C2B RID: 3115 RVA: 0x00031AFC File Offset: 0x0002FCFC
		public static int TestPdfFile(string path)
		{
			FileStream fileStream = null;
			try
			{
				int num;
				string text = XPdfForm.ExtractPageNumber(path, out num);
				if (File.Exists(text))
				{
					fileStream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
					byte[] array = new byte[1024];
					fileStream.Read(array, 0, 1024);
					return PdfReader.GetPdfFileVersion(array);
				}
			}
			catch
			{
			}
			finally
			{
				try
				{
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				catch
				{
				}
			}
			return 0;
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x00031B8C File Offset: 0x0002FD8C
		public static int TestPdfFile(Stream stream)
		{
			long num = -1L;
			try
			{
				num = stream.Position;
				byte[] array = new byte[1024];
				stream.Read(array, 0, 1024);
				return PdfReader.GetPdfFileVersion(array);
			}
			catch
			{
			}
			finally
			{
				try
				{
					if (num != -1L)
					{
						stream.Position = num;
					}
				}
				catch
				{
				}
			}
			return 0;
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x00031C08 File Offset: 0x0002FE08
		public static int TestPdfFile(byte[] data)
		{
			return PdfReader.GetPdfFileVersion(data);
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x00031C10 File Offset: 0x0002FE10
		internal static int GetPdfFileVersion(byte[] bytes)
		{
			try
			{
				string @string = PdfEncoders.RawEncoding.GetString(bytes, 0, bytes.Length);
				if (@string[0] == '%' || @string.IndexOf("%PDF", StringComparison.Ordinal) >= 0)
				{
					int num = @string.IndexOf("PDF-", StringComparison.Ordinal);
					if (num > 0 && @string[num + 5] == '.')
					{
						char c = @string[num + 4];
						char c2 = @string[num + 6];
						if (c >= '1' && c < '2' && c2 >= '0' && c2 <= '9')
						{
							return (int)((c - '0') * '\n' + (c2 - '0'));
						}
					}
				}
			}
			catch
			{
			}
			return 0;
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x00031CB8 File Offset: 0x0002FEB8
		public static PdfDocument Open(string path, PdfDocumentOpenMode openmode)
		{
			return PdfReader.Open(path, null, openmode, null);
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x00031CC3 File Offset: 0x0002FEC3
		public static PdfDocument Open(string path, PdfDocumentOpenMode openmode, PdfPasswordProvider provider)
		{
			return PdfReader.Open(path, null, openmode, provider);
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x00031CCE File Offset: 0x0002FECE
		public static PdfDocument Open(string path, string password, PdfDocumentOpenMode openmode)
		{
			return PdfReader.Open(path, password, openmode, null);
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x00031CDC File Offset: 0x0002FEDC
		public static PdfDocument Open(string path, string password, PdfDocumentOpenMode openmode, PdfPasswordProvider provider)
		{
			Stream stream = null;
			PdfDocument pdfDocument;
			try
			{
				stream = new FileStream(path, FileMode.Open, FileAccess.Read);
				pdfDocument = PdfReader.Open(stream, password, openmode, provider);
				if (pdfDocument != null)
				{
					pdfDocument._fullPath = Path.GetFullPath(path);
				}
			}
			finally
			{
				if (stream != null)
				{
					stream.Close();
				}
			}
			return pdfDocument;
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x00031D2C File Offset: 0x0002FF2C
		public static PdfDocument Open(string path)
		{
			return PdfReader.Open(path, null, PdfDocumentOpenMode.Modify, null);
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x00031D37 File Offset: 0x0002FF37
		public static PdfDocument Open(string path, string password)
		{
			return PdfReader.Open(path, password, PdfDocumentOpenMode.Modify, null);
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x00031D42 File Offset: 0x0002FF42
		public static PdfDocument Open(Stream stream, PdfDocumentOpenMode openmode)
		{
			return PdfReader.Open(stream, null, openmode);
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x00031D4C File Offset: 0x0002FF4C
		public static PdfDocument Open(Stream stream, PdfDocumentOpenMode openmode, PdfPasswordProvider passwordProvider)
		{
			return PdfReader.Open(stream, null, openmode);
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x00031D56 File Offset: 0x0002FF56
		public static PdfDocument Open(Stream stream, string password, PdfDocumentOpenMode openmode)
		{
			return PdfReader.Open(stream, password, openmode, null);
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x00031D64 File Offset: 0x0002FF64
		public static PdfDocument Open(Stream stream, string password, PdfDocumentOpenMode openmode, PdfPasswordProvider passwordProvider)
		{
			PdfDocument pdfDocument;
			try
			{
				Lexer lexer = new Lexer(stream);
				pdfDocument = new PdfDocument(lexer);
				pdfDocument._state |= DocumentState.Imported;
				pdfDocument._openMode = openmode;
				pdfDocument._fileSize = stream.Length;
				byte[] array = new byte[1024];
				stream.Position = 0L;
				stream.Read(array, 0, 1024);
				pdfDocument._version = PdfReader.GetPdfFileVersion(array);
				if (pdfDocument._version == 0)
				{
					throw new InvalidOperationException(PSSR.InvalidPdf);
				}
				pdfDocument._irefTable.IsUnderConstruction = true;
				Parser parser = new Parser(pdfDocument);
				pdfDocument._trailer = parser.ReadTrailer();
				pdfDocument._irefTable.IsUnderConstruction = false;
				PdfReference pdfReference = pdfDocument._trailer.Elements["/Encrypt"] as PdfReference;
				if (pdfReference != null)
				{
					PdfObject pdfObject = parser.ReadObject(null, pdfReference.ObjectID, false, false);
					pdfObject.Reference = pdfReference;
					pdfReference.Value = pdfObject;
					PdfStandardSecurityHandler securityHandler = pdfDocument.SecurityHandler;
					for (;;)
					{
						PasswordValidity passwordValidity = securityHandler.ValidatePassword(password);
						if (passwordValidity == PasswordValidity.Invalid)
						{
							if (passwordProvider == null)
							{
								goto IL_125;
							}
							PdfPasswordProviderArgs pdfPasswordProviderArgs = new PdfPasswordProviderArgs();
							passwordProvider(pdfPasswordProviderArgs);
							if (pdfPasswordProviderArgs.Abort)
							{
								break;
							}
							password = pdfPasswordProviderArgs.Password;
						}
						else
						{
							if (passwordValidity != PasswordValidity.UserPassword || openmode != PdfDocumentOpenMode.Modify)
							{
								goto IL_184;
							}
							if (passwordProvider == null)
							{
								goto IL_177;
							}
							PdfPasswordProviderArgs pdfPasswordProviderArgs2 = new PdfPasswordProviderArgs();
							passwordProvider(pdfPasswordProviderArgs2);
							if (pdfPasswordProviderArgs2.Abort)
							{
								goto Block_11;
							}
							password = pdfPasswordProviderArgs2.Password;
						}
					}
					return null;
					IL_125:
					if (password == null)
					{
						throw new PdfReaderException(PSSR.PasswordRequired);
					}
					throw new PdfReaderException(PSSR.InvalidPassword);
					Block_11:
					return null;
					IL_177:
					throw new PdfReaderException(PSSR.OwnerPasswordRequired);
				}
				IL_184:
				PdfReference[] allReferences = pdfDocument._irefTable.AllReferences;
				int num = allReferences.Length;
				Dictionary<int, object> dictionary = new Dictionary<int, object>();
				for (int i = 0; i < num; i++)
				{
					PdfReference pdfReference2 = allReferences[i];
					PdfCrossReferenceStream pdfCrossReferenceStream = pdfReference2.Value as PdfCrossReferenceStream;
					if (pdfCrossReferenceStream != null)
					{
						for (int j = 0; j < pdfCrossReferenceStream.Entries.Count; j++)
						{
							PdfCrossReferenceStream.CrossReferenceStreamEntry crossReferenceStreamEntry = pdfCrossReferenceStream.Entries[j];
							if (crossReferenceStreamEntry.Type == 2U)
							{
								int field = (int)crossReferenceStreamEntry.Field2;
								if (!dictionary.ContainsKey(field))
								{
									dictionary.Add(field, null);
									PdfObjectID pdfObjectID = new PdfObjectID((int)crossReferenceStreamEntry.Field2);
									parser.ReadIRefsFromCompressedObject(pdfObjectID);
								}
							}
						}
					}
				}
				for (int k = 0; k < num; k++)
				{
					PdfReference pdfReference3 = allReferences[k];
					PdfCrossReferenceStream pdfCrossReferenceStream2 = pdfReference3.Value as PdfCrossReferenceStream;
					if (pdfCrossReferenceStream2 != null)
					{
						for (int l = 0; l < pdfCrossReferenceStream2.Entries.Count; l++)
						{
							PdfCrossReferenceStream.CrossReferenceStreamEntry crossReferenceStreamEntry2 = pdfCrossReferenceStream2.Entries[l];
							if (crossReferenceStreamEntry2.Type == 2U)
							{
								parser.ReadCompressedObject(new PdfObjectID((int)crossReferenceStreamEntry2.Field2), (int)crossReferenceStreamEntry2.Field3);
							}
						}
					}
				}
				PdfReference[] allReferences2 = pdfDocument._irefTable.AllReferences;
				int num2 = allReferences2.Length;
				for (int m = 0; m < num2; m++)
				{
					PdfReference pdfReference4 = allReferences2[m];
					if (pdfReference4.Value == null)
					{
						try
						{
							PdfObject pdfObject2 = parser.ReadObject(null, pdfReference4.ObjectID, false, false);
							pdfObject2.Reference = pdfReference4;
						}
						catch (Exception)
						{
							throw;
						}
					}
					pdfDocument._irefTable._maxObjectNumber = Math.Max(pdfDocument._irefTable._maxObjectNumber, pdfReference4.ObjectNumber);
				}
				if (pdfReference != null)
				{
					pdfDocument.SecurityHandler.EncryptDocument();
				}
				pdfDocument._trailer.Finish();
				if (openmode == PdfDocumentOpenMode.Modify)
				{
					if (pdfDocument.Internals.SecondDocumentID == "")
					{
						pdfDocument._trailer.CreateNewDocumentIDs();
					}
					else
					{
						byte[] array2 = Guid.NewGuid().ToByteArray();
						pdfDocument.Internals.SecondDocumentID = PdfEncoders.RawEncoding.GetString(array2, 0, array2.Length);
					}
					pdfDocument.Info.ModificationDate = DateTime.Now;
					int num3 = pdfDocument._irefTable.Compact();
					PdfPages pages = pdfDocument.Pages;
					pdfDocument._irefTable.Renumber();
				}
			}
			catch (Exception)
			{
				throw;
			}
			return pdfDocument;
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x00032178 File Offset: 0x00030378
		public static PdfDocument Open(Stream stream)
		{
			return PdfReader.Open(stream, PdfDocumentOpenMode.Modify);
		}
	}
}
