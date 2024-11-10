using System;
using PdfSharp.Drawing;

namespace PdfSharp.Internal
{
	// Token: 0x020000B9 RID: 185
	internal static class Calc
	{
		// Token: 0x060007B7 RID: 1975 RVA: 0x0001D838 File Offset: 0x0001BA38
		public static XSize PageSizeToSize(PageSize value)
		{
			if (value <= PageSize.B5)
			{
				switch (value)
				{
				case PageSize.A0:
					return new XSize(2380.0, 3368.0);
				case PageSize.A1:
					return new XSize(1684.0, 2380.0);
				case PageSize.A2:
					return new XSize(1190.0, 1684.0);
				case PageSize.A3:
					return new XSize(842.0, 1190.0);
				case PageSize.A4:
					return new XSize(595.0, 842.0);
				case PageSize.A5:
					return new XSize(420.0, 595.0);
				default:
					switch (value)
					{
					case PageSize.B4:
						return new XSize(729.0, 1032.0);
					case PageSize.B5:
						return new XSize(516.0, 729.0);
					}
					break;
				}
			}
			else
			{
				switch (value)
				{
				case PageSize.Quarto:
					return new XSize(610.0, 780.0);
				case PageSize.Foolscap:
				case PageSize.GovernmentLetter:
					break;
				case PageSize.Executive:
					return new XSize(540.0, 720.0);
				case PageSize.Letter:
					return new XSize(612.0, 792.0);
				case PageSize.Legal:
					return new XSize(612.0, 1008.0);
				case PageSize.Ledger:
					return new XSize(1224.0, 792.0);
				case PageSize.Tabloid:
					return new XSize(792.0, 1224.0);
				default:
					switch (value)
					{
					case PageSize.Folio:
						return new XSize(612.0, 936.0);
					case PageSize.Statement:
						return new XSize(396.0, 612.0);
					case PageSize.Size10x14:
						return new XSize(720.0, 1008.0);
					}
					break;
				}
			}
			throw new ArgumentException("Invalid PageSize.");
		}

		// Token: 0x04000416 RID: 1046
		public const double Deg2Rad = 0.017453292519943295;
	}
}
