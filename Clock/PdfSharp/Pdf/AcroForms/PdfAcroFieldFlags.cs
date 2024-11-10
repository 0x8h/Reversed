using System;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000C2 RID: 194
	[Flags]
	public enum PdfAcroFieldFlags
	{
		// Token: 0x04000443 RID: 1091
		ReadOnly = 1,
		// Token: 0x04000444 RID: 1092
		Required = 2,
		// Token: 0x04000445 RID: 1093
		NoExport = 4,
		// Token: 0x04000446 RID: 1094
		Pushbutton = 65536,
		// Token: 0x04000447 RID: 1095
		Radio = 32768,
		// Token: 0x04000448 RID: 1096
		NoToggleToOff = 16384,
		// Token: 0x04000449 RID: 1097
		Multiline = 4096,
		// Token: 0x0400044A RID: 1098
		Password = 8192,
		// Token: 0x0400044B RID: 1099
		FileSelect = 1048576,
		// Token: 0x0400044C RID: 1100
		DoNotSpellCheckTextField = 4194304,
		// Token: 0x0400044D RID: 1101
		DoNotScroll = 8388608,
		// Token: 0x0400044E RID: 1102
		Combo = 131072,
		// Token: 0x0400044F RID: 1103
		Edit = 262144,
		// Token: 0x04000450 RID: 1104
		Sort = 524288,
		// Token: 0x04000451 RID: 1105
		MultiSelect = 2097152,
		// Token: 0x04000452 RID: 1106
		DoNotSpellCheckChoiseField = 4194304
	}
}
