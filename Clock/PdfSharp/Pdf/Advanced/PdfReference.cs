using System;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x0200011A RID: 282
	[DebuggerDisplay("iref({ObjectNumber}, {GenerationNumber})")]
	public sealed class PdfReference : PdfItem
	{
		// Token: 0x06000A29 RID: 2601 RVA: 0x000289EC File Offset: 0x00026BEC
		public PdfReference(PdfObject pdfObject)
		{
			if (pdfObject.Reference != null)
			{
				throw new InvalidOperationException("Must not create iref for an object that already has one.");
			}
			this._value = pdfObject;
			pdfObject.Reference = this;
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x00028A15 File Offset: 0x00026C15
		public PdfReference(PdfObjectID objectID, int position)
		{
			this._objectID = objectID;
			this._position = position;
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00028A2C File Offset: 0x00026C2C
		internal void WriteXRefEnty(PdfWriter writer)
		{
			string text = string.Format("{0:0000000000} {1:00000} n\n", this._position, this._objectID.GenerationNumber);
			writer.WriteRaw(text);
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00028A66 File Offset: 0x00026C66
		internal override void WriteObject(PdfWriter writer)
		{
			writer.Write(this);
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06000A2D RID: 2605 RVA: 0x00028A6F File Offset: 0x00026C6F
		// (set) Token: 0x06000A2E RID: 2606 RVA: 0x00028A77 File Offset: 0x00026C77
		public PdfObjectID ObjectID
		{
			get
			{
				return this._objectID;
			}
			set
			{
				if (this._objectID == value)
				{
					return;
				}
				this._objectID = value;
				PdfDocument document = this.Document;
			}
		}

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06000A2F RID: 2607 RVA: 0x00028A96 File Offset: 0x00026C96
		public int ObjectNumber
		{
			get
			{
				return this._objectID.ObjectNumber;
			}
		}

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06000A30 RID: 2608 RVA: 0x00028AA3 File Offset: 0x00026CA3
		public int GenerationNumber
		{
			get
			{
				return this._objectID.GenerationNumber;
			}
		}

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06000A31 RID: 2609 RVA: 0x00028AB0 File Offset: 0x00026CB0
		// (set) Token: 0x06000A32 RID: 2610 RVA: 0x00028AB8 File Offset: 0x00026CB8
		public int Position
		{
			get
			{
				return this._position;
			}
			set
			{
				this._position = value;
			}
		}

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06000A33 RID: 2611 RVA: 0x00028AC1 File Offset: 0x00026CC1
		// (set) Token: 0x06000A34 RID: 2612 RVA: 0x00028AC9 File Offset: 0x00026CC9
		public PdfObject Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
				value.Reference = this;
			}
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00028AD9 File Offset: 0x00026CD9
		internal void SetObject(PdfObject value)
		{
			this._value = value;
		}

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06000A36 RID: 2614 RVA: 0x00028AE2 File Offset: 0x00026CE2
		// (set) Token: 0x06000A37 RID: 2615 RVA: 0x00028AEA File Offset: 0x00026CEA
		public PdfDocument Document
		{
			get
			{
				return this._document;
			}
			set
			{
				this._document = value;
			}
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00028AF3 File Offset: 0x00026CF3
		public override string ToString()
		{
			return this._objectID + " R";
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000A39 RID: 2617 RVA: 0x00028B0A File Offset: 0x00026D0A
		internal static PdfReference.PdfReferenceComparer Comparer
		{
			get
			{
				return new PdfReference.PdfReferenceComparer();
			}
		}

		// Token: 0x0400058D RID: 1421
		private PdfObjectID _objectID;

		// Token: 0x0400058E RID: 1422
		private int _position;

		// Token: 0x0400058F RID: 1423
		private PdfObject _value;

		// Token: 0x04000590 RID: 1424
		private PdfDocument _document;

		// Token: 0x0200011B RID: 283
		internal class PdfReferenceComparer : IComparer<PdfReference>
		{
			// Token: 0x06000A3A RID: 2618 RVA: 0x00028B14 File Offset: 0x00026D14
			public int Compare(PdfReference x, PdfReference y)
			{
				if (x != null)
				{
					if (y != null)
					{
						return x._objectID.CompareTo(y._objectID);
					}
					return -1;
				}
				else
				{
					if (y != null)
					{
						return 1;
					}
					return 0;
				}
			}
		}
	}
}
