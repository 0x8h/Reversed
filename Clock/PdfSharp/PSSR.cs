using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using PdfSharp.Drawing;
using PdfSharp.Internal;
using PdfSharp.Pdf;

namespace PdfSharp
{
	// Token: 0x020001C6 RID: 454
	internal static class PSSR
	{
		// Token: 0x06000EE2 RID: 3810 RVA: 0x0003A0A0 File Offset: 0x000382A0
		public static string Format(PSMsgID id, params object[] args)
		{
			string text;
			try
			{
				text = PSSR.GetString(id);
				text = ((text != null) ? PSSR.Format(text, args) : "INTERNAL ERROR: Message not found in resources.");
				return text;
			}
			catch (Exception ex)
			{
				text = string.Format("UNEXPECTED ERROR while formatting message with ID {0}: {1}", id.ToString(), ex.ToString());
			}
			return text;
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x0003A0FC File Offset: 0x000382FC
		public static string Format(string format, params object[] args)
		{
			if (format == null)
			{
				throw new ArgumentNullException("format");
			}
			string text;
			try
			{
				text = string.Format(format, args);
			}
			catch (Exception ex)
			{
				text = string.Format("UNEXPECTED ERROR while formatting message '{0}': {1}", format, ex);
			}
			return text;
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x0003A144 File Offset: 0x00038344
		public static string GetString(PSMsgID id)
		{
			return PSSR.ResMngr.GetString(id.ToString());
		}

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06000EE5 RID: 3813 RVA: 0x0003A15B File Offset: 0x0003835B
		public static string IndexOutOfRange
		{
			get
			{
				return "The index is out of range.";
			}
		}

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06000EE6 RID: 3814 RVA: 0x0003A162 File Offset: 0x00038362
		public static string ListEnumCurrentOutOfRange
		{
			get
			{
				return "Enumeration out of range.";
			}
		}

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06000EE7 RID: 3815 RVA: 0x0003A169 File Offset: 0x00038369
		public static string PageIndexOutOfRange
		{
			get
			{
				return "The index of a page is out of range.";
			}
		}

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06000EE8 RID: 3816 RVA: 0x0003A170 File Offset: 0x00038370
		public static string OutlineIndexOutOfRange
		{
			get
			{
				return "The index of an outline is out of range.";
			}
		}

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06000EE9 RID: 3817 RVA: 0x0003A177 File Offset: 0x00038377
		public static string SetValueMustNotBeNull
		{
			get
			{
				return "The set value property must not be null.";
			}
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x0003A180 File Offset: 0x00038380
		public static string InvalidValue(int val, string name, int min, int max)
		{
			return PSSR.Format("{0} is not a valid value for {1}. {1} should be greater than or equal to {2} and less than or equal to {3}.", new object[] { val, name, min, max });
		}

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06000EEB RID: 3819 RVA: 0x0003A1BE File Offset: 0x000383BE
		public static string ObsoleteFunktionCalled
		{
			get
			{
				return "The function is obsolete and must not be called.";
			}
		}

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06000EEC RID: 3820 RVA: 0x0003A1C5 File Offset: 0x000383C5
		public static string OwningDocumentRequired
		{
			get
			{
				return "The PDF object must belong to a PdfDocument, but property Document is null.";
			}
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x0003A1CC File Offset: 0x000383CC
		public static string FileNotFound(string path)
		{
			return PSSR.Format("The file '{0}' does not exist.", new object[] { path });
		}

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06000EEE RID: 3822 RVA: 0x0003A1EF File Offset: 0x000383EF
		public static string FontDataReadOnly
		{
			get
			{
				return "Font data is read-only.";
			}
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06000EEF RID: 3823 RVA: 0x0003A1F6 File Offset: 0x000383F6
		public static string ErrorReadingFontData
		{
			get
			{
				return "Error while parsing an OpenType font.";
			}
		}

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06000EF0 RID: 3824 RVA: 0x0003A1FD File Offset: 0x000383FD
		public static string PointArrayEmpty
		{
			get
			{
				return "The PointF array must not be empty.";
			}
		}

		// Token: 0x06000EF1 RID: 3825 RVA: 0x0003A204 File Offset: 0x00038404
		public static string PointArrayAtLeast(int count)
		{
			return PSSR.Format("The point array must contain {0} or more points.", new object[] { count });
		}

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06000EF2 RID: 3826 RVA: 0x0003A22C File Offset: 0x0003842C
		public static string NeedPenOrBrush
		{
			get
			{
				return "XPen or XBrush or both must not be null.";
			}
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x0003A233 File Offset: 0x00038433
		public static string CannotChangeImmutableObject(string typename)
		{
			return string.Format("You cannot change this immutable {0} object.", typename);
		}

		// Token: 0x06000EF4 RID: 3828 RVA: 0x0003A240 File Offset: 0x00038440
		public static string FontAlreadyAdded(string fontname)
		{
			return string.Format("Fontface with the name '{0}' already added to font collection.", fontname);
		}

		// Token: 0x06000EF5 RID: 3829 RVA: 0x0003A24D File Offset: 0x0003844D
		public static string NotImplementedForFontsRetrievedWithFontResolver(string name)
		{
			return string.Format("Not implemented for font '{0}', because it was retrieved with font resolver.", name);
		}

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x06000EF6 RID: 3830 RVA: 0x0003A25A File Offset: 0x0003845A
		public static string InvalidPdf
		{
			get
			{
				return "The file is not a valid PDF document.";
			}
		}

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06000EF7 RID: 3831 RVA: 0x0003A261 File Offset: 0x00038461
		public static string InvalidVersionNumber
		{
			get
			{
				return "Invalid version number. Valid values are 12, 13, and 14.";
			}
		}

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06000EF8 RID: 3832 RVA: 0x0003A268 File Offset: 0x00038468
		public static string CannotHandleXRefStreams
		{
			get
			{
				return "Cannot handle cross-reference streams. The current implementation of PDFsharp cannot handle this PDF feature introduced with Acrobat 6.";
			}
		}

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06000EF9 RID: 3833 RVA: 0x0003A26F File Offset: 0x0003846F
		public static string PasswordRequired
		{
			get
			{
				return "A password is required to open the PDF document.";
			}
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06000EFA RID: 3834 RVA: 0x0003A276 File Offset: 0x00038476
		public static string InvalidPassword
		{
			get
			{
				return "The specified password is invalid.";
			}
		}

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06000EFB RID: 3835 RVA: 0x0003A27D File Offset: 0x0003847D
		public static string OwnerPasswordRequired
		{
			get
			{
				return "To modify the document the owner password is required";
			}
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06000EFC RID: 3836 RVA: 0x0003A284 File Offset: 0x00038484
		public static string UserOrOwnerPasswordRequired
		{
			get
			{
				return PSSR.GetString(PSMsgID.UserOrOwnerPasswordRequired);
			}
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x06000EFD RID: 3837 RVA: 0x0003A28C File Offset: 0x0003848C
		public static string CannotModify
		{
			get
			{
				return "The document cannot be modified.";
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06000EFE RID: 3838 RVA: 0x0003A293 File Offset: 0x00038493
		public static string NameMustStartWithSlash
		{
			get
			{
				return "A PDF name must start with a slash (/).";
			}
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x0003A29A File Offset: 0x0003849A
		public static string ImportPageNumberOutOfRange(int pageNumber, int maxPage, string path)
		{
			return string.Format("The page cannot be imported from document '{2}', because the page number is out of range. The specified page number is {0}, but it must be in the range from 1 to {1}.", pageNumber, maxPage, path);
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06000F00 RID: 3840 RVA: 0x0003A2B3 File Offset: 0x000384B3
		public static string MultiplePageInsert
		{
			get
			{
				return "The page cannot be added to this document because the document already owned this page.";
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06000F01 RID: 3841 RVA: 0x0003A2BA File Offset: 0x000384BA
		public static string UnexpectedTokenInPdfFile
		{
			get
			{
				return "Unexpected token in PDF file. The PDF file may be corrupt. If it is not, please send us the file for service.";
			}
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x0003A2C4 File Offset: 0x000384C4
		public static string InappropriateColorSpace(PdfColorMode colorMode, XColorSpace colorSpace)
		{
			string text;
			switch (colorMode)
			{
			case PdfColorMode.Rgb:
				text = "RGB";
				break;
			case PdfColorMode.Cmyk:
				text = "CMYK";
				break;
			default:
				text = "(undefined)";
				break;
			}
			string text2;
			switch (colorSpace)
			{
			case XColorSpace.Rgb:
				text2 = "RGB";
				break;
			case XColorSpace.Cmyk:
				text2 = "CMYK";
				break;
			case XColorSpace.GrayScale:
				text2 = "grayscale";
				break;
			default:
				text2 = "(undefined)";
				break;
			}
			return string.Format("The document requires color mode {0}, but a color is defined using {1}. Use only colors that match the color mode of the PDF document", text, text2);
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x0003A33C File Offset: 0x0003853C
		public static string CannotGetGlyphTypeface(string fontName)
		{
			return PSSR.Format("Cannot get a matching glyph typeface for font '{0}'.", new object[] { fontName });
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x0003A360 File Offset: 0x00038560
		public static string UnexpectedToken(string token)
		{
			return PSSR.Format(PSMsgID.UnexpectedToken, new object[] { token });
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06000F05 RID: 3845 RVA: 0x0003A37F File Offset: 0x0003857F
		public static string UnknownEncryption
		{
			get
			{
				return PSSR.GetString(PSMsgID.UnknownEncryption);
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06000F06 RID: 3846 RVA: 0x0003A388 File Offset: 0x00038588
		public static ResourceManager ResMngr
		{
			get
			{
				if (PSSR._resmngr == null)
				{
					try
					{
						Lock.EnterFontFactory();
						if (PSSR._resmngr == null)
						{
							PSSR._resmngr = new ResourceManager("PdfSharp.Resources.Messages", Assembly.GetExecutingAssembly());
						}
					}
					finally
					{
						Lock.ExitFontFactory();
					}
				}
				return PSSR._resmngr;
			}
		}

		// Token: 0x06000F07 RID: 3847 RVA: 0x0003A3DC File Offset: 0x000385DC
		[Conditional("DEBUG")]
		public static void TestResourceMessages()
		{
			string[] names = Enum.GetNames(typeof(PSMsgID));
			foreach (string text in names)
			{
				string.Format("{0}: '{1}'", text, PSSR.ResMngr.GetString(text));
			}
		}

		// Token: 0x04000962 RID: 2402
		private static ResourceManager _resmngr;
	}
}
