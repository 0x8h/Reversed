using System;

namespace PdfSharp.Pdf.Internal
{
	// Token: 0x02000162 RID: 354
	internal class PdfDiagnostics
	{
		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06000BB1 RID: 2993 RVA: 0x0002E901 File Offset: 0x0002CB01
		// (set) Token: 0x06000BB2 RID: 2994 RVA: 0x0002E908 File Offset: 0x0002CB08
		public static bool TraceCompressedObjects
		{
			get
			{
				return PdfDiagnostics._traceCompressedObjects;
			}
			set
			{
				PdfDiagnostics._traceCompressedObjects = value;
			}
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06000BB3 RID: 2995 RVA: 0x0002E910 File Offset: 0x0002CB10
		// (set) Token: 0x06000BB4 RID: 2996 RVA: 0x0002E920 File Offset: 0x0002CB20
		public static bool TraceXrefStreams
		{
			get
			{
				return PdfDiagnostics._traceXrefStreams && PdfDiagnostics.TraceCompressedObjects;
			}
			set
			{
				PdfDiagnostics._traceXrefStreams = value;
			}
		}

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06000BB5 RID: 2997 RVA: 0x0002E928 File Offset: 0x0002CB28
		// (set) Token: 0x06000BB6 RID: 2998 RVA: 0x0002E938 File Offset: 0x0002CB38
		public static bool TraceObjectStreams
		{
			get
			{
				return PdfDiagnostics._traceObjectStreams && PdfDiagnostics.TraceCompressedObjects;
			}
			set
			{
				PdfDiagnostics._traceObjectStreams = value;
			}
		}

		// Token: 0x04000734 RID: 1844
		private static bool _traceCompressedObjects = true;

		// Token: 0x04000735 RID: 1845
		private static bool _traceXrefStreams = true;

		// Token: 0x04000736 RID: 1846
		private static bool _traceObjectStreams = true;
	}
}
