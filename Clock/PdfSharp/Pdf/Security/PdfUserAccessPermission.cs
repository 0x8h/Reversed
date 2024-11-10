using System;

namespace PdfSharp.Pdf.Security
{
	// Token: 0x0200017B RID: 379
	[Flags]
	internal enum PdfUserAccessPermission
	{
		// Token: 0x040007B5 RID: 1973
		PermitAll = -3,
		// Token: 0x040007B6 RID: 1974
		PermitPrint = 4,
		// Token: 0x040007B7 RID: 1975
		PermitModifyDocument = 8,
		// Token: 0x040007B8 RID: 1976
		PermitExtractContent = 16,
		// Token: 0x040007B9 RID: 1977
		PermitAnnotations = 32,
		// Token: 0x040007BA RID: 1978
		PermitFormsFill = 256,
		// Token: 0x040007BB RID: 1979
		PermitAccessibilityExtractContent = 512,
		// Token: 0x040007BC RID: 1980
		PermitAssembleDocument = 1024,
		// Token: 0x040007BD RID: 1981
		PermitFullQualityPrint = 2048
	}
}
