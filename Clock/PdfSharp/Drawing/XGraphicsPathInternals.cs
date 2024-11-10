using System;

namespace PdfSharp.Drawing
{
	// Token: 0x0200006C RID: 108
	public sealed class XGraphicsPathInternals
	{
		// Token: 0x06000473 RID: 1139 RVA: 0x00012E0B File Offset: 0x0001100B
		internal XGraphicsPathInternals(XGraphicsPath path)
		{
			this._path = path;
		}

		// Token: 0x04000278 RID: 632
		private XGraphicsPath _path;
	}
}
