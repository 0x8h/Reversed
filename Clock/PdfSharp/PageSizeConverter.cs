using System;
using PdfSharp.Drawing;

namespace PdfSharp
{
	// Token: 0x020001C4 RID: 452
	public static class PageSizeConverter
	{
		// Token: 0x06000EE1 RID: 3809 RVA: 0x00039C20 File Offset: 0x00037E20
		public static XSize ToSize(PageSize value)
		{
			switch (value)
			{
			case PageSize.A0:
				return new XSize(2384.0, 3370.0);
			case PageSize.A1:
				return new XSize(1684.0, 2384.0);
			case PageSize.A2:
				return new XSize(1191.0, 1684.0);
			case PageSize.A3:
				return new XSize(842.0, 1191.0);
			case PageSize.A4:
				return new XSize(595.0, 842.0);
			case PageSize.A5:
				return new XSize(420.0, 595.0);
			case PageSize.RA0:
				return new XSize(2438.0, 3458.0);
			case PageSize.RA1:
				return new XSize(1729.0, 2438.0);
			case PageSize.RA2:
				return new XSize(1219.0, 1729.0);
			case PageSize.RA3:
				return new XSize(865.0, 1219.0);
			case PageSize.RA4:
				return new XSize(609.0, 865.0);
			case PageSize.RA5:
				return new XSize(433.0, 609.0);
			case PageSize.B0:
				return new XSize(2835.0, 4008.0);
			case PageSize.B1:
				return new XSize(2004.0, 2835.0);
			case PageSize.B2:
				return new XSize(1417.0, 2004.0);
			case PageSize.B3:
				return new XSize(1001.0, 1417.0);
			case PageSize.B4:
				return new XSize(709.0, 1001.0);
			case PageSize.B5:
				return new XSize(499.0, 709.0);
			default:
				switch (value)
				{
				case PageSize.Quarto:
					return new XSize(576.0, 720.0);
				case PageSize.Foolscap:
					return new XSize(576.0, 936.0);
				case PageSize.Executive:
					return new XSize(540.0, 720.0);
				case PageSize.GovernmentLetter:
					return new XSize(576.0, 756.0);
				case PageSize.Letter:
					return new XSize(612.0, 792.0);
				case PageSize.Legal:
					return new XSize(612.0, 1008.0);
				case PageSize.Ledger:
					return new XSize(1224.0, 792.0);
				case PageSize.Tabloid:
					return new XSize(792.0, 1224.0);
				case PageSize.Post:
					return new XSize(1126.0, 1386.0);
				case PageSize.Crown:
					return new XSize(1440.0, 1080.0);
				case PageSize.LargePost:
					return new XSize(1188.0, 1512.0);
				case PageSize.Demy:
					return new XSize(1260.0, 1584.0);
				case PageSize.Medium:
					return new XSize(1296.0, 1656.0);
				case PageSize.Royal:
					return new XSize(1440.0, 1800.0);
				case PageSize.Elephant:
					return new XSize(1565.0, 2016.0);
				case PageSize.DoubleDemy:
					return new XSize(1692.0, 2520.0);
				case PageSize.QuadDemy:
					return new XSize(2520.0, 3240.0);
				case PageSize.STMT:
					return new XSize(396.0, 612.0);
				case PageSize.Folio:
					return new XSize(612.0, 936.0);
				case PageSize.Statement:
					return new XSize(396.0, 612.0);
				case PageSize.Size10x14:
					return new XSize(720.0, 1008.0);
				}
				throw new ArgumentException("Invalid PageSize.", "value");
			}
		}
	}
}
