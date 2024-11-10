using System;

namespace PdfSharp.Pdf
{
	// Token: 0x0200019D RID: 413
	public sealed class PdfDocumentSettings
	{
		// Token: 0x06000D55 RID: 3413 RVA: 0x0003529A File Offset: 0x0003349A
		internal PdfDocumentSettings(PdfDocument document)
		{
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06000D56 RID: 3414 RVA: 0x000352AD File Offset: 0x000334AD
		// (set) Token: 0x06000D57 RID: 3415 RVA: 0x000352C8 File Offset: 0x000334C8
		public TrimMargins TrimMargins
		{
			get
			{
				if (this._trimMargins == null)
				{
					this._trimMargins = new TrimMargins();
				}
				return this._trimMargins;
			}
			set
			{
				if (this._trimMargins == null)
				{
					this._trimMargins = new TrimMargins();
				}
				if (value != null)
				{
					this._trimMargins.Left = value.Left;
					this._trimMargins.Right = value.Right;
					this._trimMargins.Top = value.Top;
					this._trimMargins.Bottom = value.Bottom;
					return;
				}
				this._trimMargins.All = 0;
			}
		}

		// Token: 0x04000877 RID: 2167
		private TrimMargins _trimMargins = new TrimMargins();
	}
}
