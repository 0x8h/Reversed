using System;
using System.Diagnostics;
using System.Globalization;

namespace PdfSharp.Pdf
{
	// Token: 0x020001A8 RID: 424
	[DebuggerDisplay("{DebuggerDisplay}")]
	public struct PdfObjectID : IComparable
	{
		// Token: 0x06000D9D RID: 3485 RVA: 0x00035788 File Offset: 0x00033988
		public PdfObjectID(int objectNumber)
		{
			this._objectNumber = objectNumber;
			this._generationNumber = 0;
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x00035798 File Offset: 0x00033998
		public PdfObjectID(int objectNumber, int generationNumber)
		{
			this._objectNumber = objectNumber;
			this._generationNumber = (ushort)generationNumber;
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06000D9F RID: 3487 RVA: 0x000357A9 File Offset: 0x000339A9
		public int ObjectNumber
		{
			get
			{
				return this._objectNumber;
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06000DA0 RID: 3488 RVA: 0x000357B1 File Offset: 0x000339B1
		public int GenerationNumber
		{
			get
			{
				return (int)this._generationNumber;
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06000DA1 RID: 3489 RVA: 0x000357B9 File Offset: 0x000339B9
		public bool IsEmpty
		{
			get
			{
				return this._objectNumber == 0;
			}
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x000357C4 File Offset: 0x000339C4
		public override bool Equals(object obj)
		{
			if (obj is PdfObjectID)
			{
				PdfObjectID pdfObjectID = (PdfObjectID)obj;
				if (this._objectNumber == pdfObjectID._objectNumber)
				{
					return this._generationNumber == pdfObjectID._generationNumber;
				}
			}
			return false;
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x00035800 File Offset: 0x00033A00
		public override int GetHashCode()
		{
			return this._objectNumber ^ (int)this._generationNumber;
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x0003580F File Offset: 0x00033A0F
		public static bool operator ==(PdfObjectID left, PdfObjectID right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x00035824 File Offset: 0x00033A24
		public static bool operator !=(PdfObjectID left, PdfObjectID right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x0003583C File Offset: 0x00033A3C
		public override string ToString()
		{
			return this._objectNumber.ToString(CultureInfo.InvariantCulture) + " " + this._generationNumber.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06000DA7 RID: 3495 RVA: 0x0003587C File Offset: 0x00033A7C
		public static PdfObjectID Empty
		{
			get
			{
				return default(PdfObjectID);
			}
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x00035894 File Offset: 0x00033A94
		public int CompareTo(object obj)
		{
			if (!(obj is PdfObjectID))
			{
				return 1;
			}
			PdfObjectID pdfObjectID = (PdfObjectID)obj;
			if (this._objectNumber == pdfObjectID._objectNumber)
			{
				return (int)(this._generationNumber - pdfObjectID._generationNumber);
			}
			return this._objectNumber - pdfObjectID._objectNumber;
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x000358DE File Offset: 0x00033ADE
		internal string DebuggerDisplay
		{
			get
			{
				return string.Format("id=({0})", this.ToString());
			}
		}

		// Token: 0x0400087F RID: 2175
		private readonly int _objectNumber;

		// Token: 0x04000880 RID: 2176
		private readonly ushort _generationNumber;
	}
}
