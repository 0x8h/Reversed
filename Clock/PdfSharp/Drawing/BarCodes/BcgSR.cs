using System;

namespace PdfSharp.Drawing.BarCodes
{
	// Token: 0x02000008 RID: 8
	internal class BcgSR
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00002990 File Offset: 0x00000B90
		internal static string Invalid2Of5Code(string code)
		{
			return string.Format("'{0}' is not a valid code for an interleave 2 of 5 bar code. It can only represent an even number of digits.", code);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000299D File Offset: 0x00000B9D
		internal static string Invalid3Of9Code(string code)
		{
			return string.Format("'{0}' is not a valid code for a 3 of 9 standard bar code.", code);
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000024 RID: 36 RVA: 0x000029AA File Offset: 0x00000BAA
		internal static string BarCodeNotSet
		{
			get
			{
				return "A text must be set before rendering the bar code.";
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000029B1 File Offset: 0x00000BB1
		internal static string EmptyBarCodeSize
		{
			get
			{
				return "A non-empty size must be set before rendering the bar code.";
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000026 RID: 38 RVA: 0x000029B8 File Offset: 0x00000BB8
		internal static string Invalid2of5Relation
		{
			get
			{
				return "Value of relation between thick and thin lines on the interleaved 2 of 5 code must be between 2 and 3.";
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000029BF File Offset: 0x00000BBF
		internal static string InvalidMarkName(string name)
		{
			return string.Format("'{0}' is not a valid mark name for this OMR representation.", name);
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000029CC File Offset: 0x00000BCC
		internal static string OmrAlreadyInitialized
		{
			get
			{
				return "Mark descriptions cannot be set when marks have already been set on OMR.";
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000029D3 File Offset: 0x00000BD3
		internal static string DataMatrixTooBig
		{
			get
			{
				return "The given data and encoding combination is too big for the matrix size.";
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000029DA File Offset: 0x00000BDA
		internal static string DataMatrixNotSupported
		{
			get
			{
				return "Zero sizes, odd sizes and other than ecc200 coded DataMatrix is not supported.";
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000029E1 File Offset: 0x00000BE1
		internal static string DataMatrixNull
		{
			get
			{
				return "No DataMatrix code is produced.";
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000029E8 File Offset: 0x00000BE8
		internal static string DataMatrixInvalid(int columns, int rows)
		{
			return string.Format("'{1}'x'{0}' is an invalid ecc200 DataMatrix size.", columns, rows);
		}
	}
}
