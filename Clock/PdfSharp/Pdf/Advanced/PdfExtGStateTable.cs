using System;
using System.Collections.Generic;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x020000FF RID: 255
	public sealed class PdfExtGStateTable : PdfResourceTable
	{
		// Token: 0x06000995 RID: 2453 RVA: 0x00023C08 File Offset: 0x00021E08
		public PdfExtGStateTable(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x00023C28 File Offset: 0x00021E28
		public PdfExtGState GetExtGStateStroke(double alpha, bool overprint)
		{
			string text = PdfExtGState.MakeKey(alpha, overprint);
			PdfExtGState pdfExtGState;
			if (!this._strokeAlphaValues.TryGetValue(text, out pdfExtGState))
			{
				pdfExtGState = new PdfExtGState(base.Owner);
				pdfExtGState.StrokeAlpha = alpha;
				if (overprint)
				{
					pdfExtGState.StrokeOverprint = true;
					pdfExtGState.Elements.SetInteger("/OPM", 1);
				}
				this._strokeAlphaValues[text] = pdfExtGState;
			}
			return pdfExtGState;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x00023C8C File Offset: 0x00021E8C
		public PdfExtGState GetExtGStateNonStroke(double alpha, bool overprint)
		{
			string text = PdfExtGState.MakeKey(alpha, overprint);
			PdfExtGState pdfExtGState;
			if (!this._nonStrokeStates.TryGetValue(text, out pdfExtGState))
			{
				pdfExtGState = new PdfExtGState(base.Owner);
				pdfExtGState.NonStrokeAlpha = alpha;
				if (overprint)
				{
					pdfExtGState.NonStrokeOverprint = true;
					pdfExtGState.Elements.SetInteger("/OPM", 1);
				}
				this._nonStrokeStates[text] = pdfExtGState;
			}
			return pdfExtGState;
		}

		// Token: 0x04000514 RID: 1300
		private readonly Dictionary<string, PdfExtGState> _strokeAlphaValues = new Dictionary<string, PdfExtGState>();

		// Token: 0x04000515 RID: 1301
		private readonly Dictionary<string, PdfExtGState> _nonStrokeStates = new Dictionary<string, PdfExtGState>();
	}
}
