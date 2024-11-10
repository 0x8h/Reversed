using System;

namespace PdfSharp.Internal
{
	// Token: 0x020000B0 RID: 176
	internal static class Diagnostics
	{
		// Token: 0x17000319 RID: 793
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x0001D6A4 File Offset: 0x0001B8A4
		// (set) Token: 0x060007A4 RID: 1956 RVA: 0x0001D6AB File Offset: 0x0001B8AB
		public static NotImplementedBehaviour NotImplementedBehaviour
		{
			get
			{
				return Diagnostics._notImplementedBehaviour;
			}
			set
			{
				Diagnostics._notImplementedBehaviour = value;
			}
		}

		// Token: 0x04000415 RID: 1045
		private static NotImplementedBehaviour _notImplementedBehaviour;
	}
}
