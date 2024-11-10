using System;

namespace PdfSharp.Pdf.Security
{
	// Token: 0x0200017E RID: 382
	public sealed class PdfSecuritySettings
	{
		// Token: 0x06000C78 RID: 3192 RVA: 0x00032EDB File Offset: 0x000310DB
		internal PdfSecuritySettings(PdfDocument document)
		{
			this._document = document;
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06000C79 RID: 3193 RVA: 0x00032EF1 File Offset: 0x000310F1
		public bool HasOwnerPermissions
		{
			get
			{
				return this._hasOwnerPermissions;
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06000C7A RID: 3194 RVA: 0x00032EF9 File Offset: 0x000310F9
		// (set) Token: 0x06000C7B RID: 3195 RVA: 0x00032F01 File Offset: 0x00031101
		public PdfDocumentSecurityLevel DocumentSecurityLevel
		{
			get
			{
				return this._documentSecurityLevel;
			}
			set
			{
				this._documentSecurityLevel = value;
			}
		}

		// Token: 0x17000443 RID: 1091
		// (set) Token: 0x06000C7C RID: 3196 RVA: 0x00032F0A File Offset: 0x0003110A
		public string UserPassword
		{
			set
			{
				this.SecurityHandler.UserPassword = value;
			}
		}

		// Token: 0x17000444 RID: 1092
		// (set) Token: 0x06000C7D RID: 3197 RVA: 0x00032F18 File Offset: 0x00031118
		public string OwnerPassword
		{
			set
			{
				this.SecurityHandler.OwnerPassword = value;
			}
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x00032F26 File Offset: 0x00031126
		internal bool CanSave(ref string message)
		{
			if (this._documentSecurityLevel != PdfDocumentSecurityLevel.None && string.IsNullOrEmpty(this.SecurityHandler._userPassword) && string.IsNullOrEmpty(this.SecurityHandler._ownerPassword))
			{
				message = PSSR.UserOrOwnerPasswordRequired;
				return false;
			}
			return true;
		}

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06000C7F RID: 3199 RVA: 0x00032F5E File Offset: 0x0003115E
		// (set) Token: 0x06000C80 RID: 3200 RVA: 0x00032F74 File Offset: 0x00031174
		public bool PermitPrint
		{
			get
			{
				return (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitPrint) != (PdfUserAccessPermission)0;
			}
			set
			{
				PdfUserAccessPermission pdfUserAccessPermission = this.SecurityHandler.Permission;
				if (value)
				{
					pdfUserAccessPermission |= PdfUserAccessPermission.PermitPrint;
				}
				else
				{
					pdfUserAccessPermission &= ~PdfUserAccessPermission.PermitPrint;
				}
				this.SecurityHandler.Permission = pdfUserAccessPermission;
			}
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06000C81 RID: 3201 RVA: 0x00032FA7 File Offset: 0x000311A7
		// (set) Token: 0x06000C82 RID: 3202 RVA: 0x00032FBC File Offset: 0x000311BC
		public bool PermitModifyDocument
		{
			get
			{
				return (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitModifyDocument) != (PdfUserAccessPermission)0;
			}
			set
			{
				PdfUserAccessPermission pdfUserAccessPermission = this.SecurityHandler.Permission;
				if (value)
				{
					pdfUserAccessPermission |= PdfUserAccessPermission.PermitModifyDocument;
				}
				else
				{
					pdfUserAccessPermission &= ~PdfUserAccessPermission.PermitModifyDocument;
				}
				this.SecurityHandler.Permission = pdfUserAccessPermission;
			}
		}

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06000C83 RID: 3203 RVA: 0x00032FEF File Offset: 0x000311EF
		// (set) Token: 0x06000C84 RID: 3204 RVA: 0x00033008 File Offset: 0x00031208
		public bool PermitExtractContent
		{
			get
			{
				return (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitExtractContent) != (PdfUserAccessPermission)0;
			}
			set
			{
				PdfUserAccessPermission pdfUserAccessPermission = this.SecurityHandler.Permission;
				if (value)
				{
					pdfUserAccessPermission |= PdfUserAccessPermission.PermitExtractContent;
				}
				else
				{
					pdfUserAccessPermission &= ~PdfUserAccessPermission.PermitExtractContent;
				}
				this.SecurityHandler.Permission = pdfUserAccessPermission;
			}
		}

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06000C85 RID: 3205 RVA: 0x0003303C File Offset: 0x0003123C
		// (set) Token: 0x06000C86 RID: 3206 RVA: 0x00033054 File Offset: 0x00031254
		public bool PermitAnnotations
		{
			get
			{
				return (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitAnnotations) != (PdfUserAccessPermission)0;
			}
			set
			{
				PdfUserAccessPermission pdfUserAccessPermission = this.SecurityHandler.Permission;
				if (value)
				{
					pdfUserAccessPermission |= PdfUserAccessPermission.PermitAnnotations;
				}
				else
				{
					pdfUserAccessPermission &= ~PdfUserAccessPermission.PermitAnnotations;
				}
				this.SecurityHandler.Permission = pdfUserAccessPermission;
			}
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06000C87 RID: 3207 RVA: 0x00033088 File Offset: 0x00031288
		// (set) Token: 0x06000C88 RID: 3208 RVA: 0x000330A4 File Offset: 0x000312A4
		public bool PermitFormsFill
		{
			get
			{
				return (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitFormsFill) != (PdfUserAccessPermission)0;
			}
			set
			{
				PdfUserAccessPermission pdfUserAccessPermission = this.SecurityHandler.Permission;
				if (value)
				{
					pdfUserAccessPermission |= PdfUserAccessPermission.PermitFormsFill;
				}
				else
				{
					pdfUserAccessPermission &= ~PdfUserAccessPermission.PermitFormsFill;
				}
				this.SecurityHandler.Permission = pdfUserAccessPermission;
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x06000C89 RID: 3209 RVA: 0x000330DE File Offset: 0x000312DE
		// (set) Token: 0x06000C8A RID: 3210 RVA: 0x000330F8 File Offset: 0x000312F8
		public bool PermitAccessibilityExtractContent
		{
			get
			{
				return (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitAccessibilityExtractContent) != (PdfUserAccessPermission)0;
			}
			set
			{
				PdfUserAccessPermission pdfUserAccessPermission = this.SecurityHandler.Permission;
				if (value)
				{
					pdfUserAccessPermission |= PdfUserAccessPermission.PermitAccessibilityExtractContent;
				}
				else
				{
					pdfUserAccessPermission &= ~PdfUserAccessPermission.PermitAccessibilityExtractContent;
				}
				this.SecurityHandler.Permission = pdfUserAccessPermission;
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x06000C8B RID: 3211 RVA: 0x00033132 File Offset: 0x00031332
		// (set) Token: 0x06000C8C RID: 3212 RVA: 0x0003314C File Offset: 0x0003134C
		public bool PermitAssembleDocument
		{
			get
			{
				return (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitAssembleDocument) != (PdfUserAccessPermission)0;
			}
			set
			{
				PdfUserAccessPermission pdfUserAccessPermission = this.SecurityHandler.Permission;
				if (value)
				{
					pdfUserAccessPermission |= PdfUserAccessPermission.PermitAssembleDocument;
				}
				else
				{
					pdfUserAccessPermission &= ~PdfUserAccessPermission.PermitAssembleDocument;
				}
				this.SecurityHandler.Permission = pdfUserAccessPermission;
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06000C8D RID: 3213 RVA: 0x00033186 File Offset: 0x00031386
		// (set) Token: 0x06000C8E RID: 3214 RVA: 0x000331A0 File Offset: 0x000313A0
		public bool PermitFullQualityPrint
		{
			get
			{
				return (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitFullQualityPrint) != (PdfUserAccessPermission)0;
			}
			set
			{
				PdfUserAccessPermission pdfUserAccessPermission = this.SecurityHandler.Permission;
				if (value)
				{
					pdfUserAccessPermission |= PdfUserAccessPermission.PermitFullQualityPrint;
				}
				else
				{
					pdfUserAccessPermission &= ~PdfUserAccessPermission.PermitFullQualityPrint;
				}
				this.SecurityHandler.Permission = pdfUserAccessPermission;
			}
		}

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06000C8F RID: 3215 RVA: 0x000331DA File Offset: 0x000313DA
		internal PdfStandardSecurityHandler SecurityHandler
		{
			get
			{
				return this._document._trailer.SecurityHandler;
			}
		}

		// Token: 0x040007C6 RID: 1990
		private readonly PdfDocument _document;

		// Token: 0x040007C7 RID: 1991
		internal bool _hasOwnerPermissions = true;

		// Token: 0x040007C8 RID: 1992
		private PdfDocumentSecurityLevel _documentSecurityLevel;
	}
}
