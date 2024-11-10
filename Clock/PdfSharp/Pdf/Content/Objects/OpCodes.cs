using System;
using System.Collections.Generic;

namespace PdfSharp.Pdf.Content.Objects
{
	// Token: 0x0200014F RID: 335
	public static class OpCodes
	{
		// Token: 0x06000B39 RID: 2873 RVA: 0x0002B484 File Offset: 0x00029684
		public static COperator OperatorFromName(string name)
		{
			COperator coperator = null;
			OpCode opCode = OpCodes.StringToOpCode[name];
			if (opCode != null)
			{
				coperator = new COperator(opCode);
			}
			return coperator;
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0002B4AC File Offset: 0x000296AC
		static OpCodes()
		{
			for (int i = 0; i < OpCodes.ops.Length; i++)
			{
				OpCode opCode = OpCodes.ops[i];
				OpCodes.StringToOpCode.Add(opCode.Name, opCode);
			}
		}

		// Token: 0x04000692 RID: 1682
		private static readonly Dictionary<string, OpCode> StringToOpCode = new Dictionary<string, OpCode>();

		// Token: 0x04000693 RID: 1683
		private static readonly OpCode Dictionary = new OpCode("Dictionary", OpCodeName.Dictionary, -1, "name, dictionary", OpCodeFlags.None, "E.g.: /Name << ... >>");

		// Token: 0x04000694 RID: 1684
		private static readonly OpCode b = new OpCode("b", OpCodeName.b, 0, "closepath, fill, stroke", OpCodeFlags.None, "Close, fill, and stroke path using nonzero winding number");

		// Token: 0x04000695 RID: 1685
		private static readonly OpCode B = new OpCode("B", OpCodeName.B, 0, "fill, stroke", OpCodeFlags.None, "Fill and stroke path using nonzero winding number rule");

		// Token: 0x04000696 RID: 1686
		private static readonly OpCode bx = new OpCode("b*", OpCodeName.bx, 0, "closepath, eofill, stroke", OpCodeFlags.None, "Close, fill, and stroke path using even-odd rule");

		// Token: 0x04000697 RID: 1687
		private static readonly OpCode Bx = new OpCode("B*", OpCodeName.Bx, 0, "eofill, stroke", OpCodeFlags.None, "Fill and stroke path using even-odd rule");

		// Token: 0x04000698 RID: 1688
		private static readonly OpCode BDC = new OpCode("BDC", OpCodeName.BDC, -1, null, OpCodeFlags.None, "(PDF 1.2) Begin marked-content sequence with property list");

		// Token: 0x04000699 RID: 1689
		private static readonly OpCode BI = new OpCode("BI", OpCodeName.BI, 0, null, OpCodeFlags.None, "Begin inline image object");

		// Token: 0x0400069A RID: 1690
		private static readonly OpCode BMC = new OpCode("BMC", OpCodeName.BMC, 1, null, OpCodeFlags.None, "(PDF 1.2) Begin marked-content sequence");

		// Token: 0x0400069B RID: 1691
		private static readonly OpCode BT = new OpCode("BT", OpCodeName.BT, 0, null, OpCodeFlags.None, "Begin text object");

		// Token: 0x0400069C RID: 1692
		private static readonly OpCode BX = new OpCode("BX", OpCodeName.BX, 0, null, OpCodeFlags.None, "(PDF 1.1) Begin compatibility section");

		// Token: 0x0400069D RID: 1693
		private static readonly OpCode c = new OpCode("c", OpCodeName.c, 6, "curveto", OpCodeFlags.None, "Append curved segment to path (three control points)");

		// Token: 0x0400069E RID: 1694
		private static readonly OpCode cm = new OpCode("cm", OpCodeName.cm, 6, "concat", OpCodeFlags.None, "Concatenate matrix to current transformation matrix");

		// Token: 0x0400069F RID: 1695
		private static readonly OpCode CS = new OpCode("CS", OpCodeName.CS, 1, "setcolorspace", OpCodeFlags.None, "(PDF 1.1) Set color space for stroking operations");

		// Token: 0x040006A0 RID: 1696
		private static readonly OpCode cs = new OpCode("cs", OpCodeName.cs, 1, "setcolorspace", OpCodeFlags.None, "(PDF 1.1) Set color space for nonstroking operations");

		// Token: 0x040006A1 RID: 1697
		private static readonly OpCode d = new OpCode("d", OpCodeName.d, 2, "setdash", OpCodeFlags.None, "Set line dash pattern");

		// Token: 0x040006A2 RID: 1698
		private static readonly OpCode d0 = new OpCode("d0", OpCodeName.d0, 2, "setcharwidth", OpCodeFlags.None, "Set glyph width in Type 3 font");

		// Token: 0x040006A3 RID: 1699
		private static readonly OpCode d1 = new OpCode("d1", OpCodeName.d1, 6, "setcachedevice", OpCodeFlags.None, "Set glyph width and bounding box in Type 3 font");

		// Token: 0x040006A4 RID: 1700
		private static readonly OpCode Do = new OpCode("Do", OpCodeName.Do, 1, null, OpCodeFlags.None, "Invoke named XObject");

		// Token: 0x040006A5 RID: 1701
		private static readonly OpCode DP = new OpCode("DP", OpCodeName.DP, 2, null, OpCodeFlags.None, "(PDF 1.2) Define marked-content point with property list");

		// Token: 0x040006A6 RID: 1702
		private static readonly OpCode EI = new OpCode("EI", OpCodeName.EI, 0, null, OpCodeFlags.None, "End inline image object");

		// Token: 0x040006A7 RID: 1703
		private static readonly OpCode EMC = new OpCode("EMC", OpCodeName.EMC, 0, null, OpCodeFlags.None, "(PDF 1.2) End marked-content sequence");

		// Token: 0x040006A8 RID: 1704
		private static readonly OpCode ET = new OpCode("ET", OpCodeName.ET, 0, null, OpCodeFlags.None, "End text object");

		// Token: 0x040006A9 RID: 1705
		private static readonly OpCode EX = new OpCode("EX", OpCodeName.EX, 0, null, OpCodeFlags.None, "(PDF 1.1) End compatibility section");

		// Token: 0x040006AA RID: 1706
		private static readonly OpCode f = new OpCode("f", OpCodeName.f, 0, "fill", OpCodeFlags.None, "Fill path using nonzero winding number rule");

		// Token: 0x040006AB RID: 1707
		private static readonly OpCode F = new OpCode("F", OpCodeName.F, 0, "fill", OpCodeFlags.None, "Fill path using nonzero winding number rule (obsolete)");

		// Token: 0x040006AC RID: 1708
		private static readonly OpCode fx = new OpCode("f*", OpCodeName.fx, 0, "eofill", OpCodeFlags.None, "Fill path using even-odd rule");

		// Token: 0x040006AD RID: 1709
		private static readonly OpCode G = new OpCode("G", OpCodeName.G, 1, "setgray", OpCodeFlags.None, "Set gray level for stroking operations");

		// Token: 0x040006AE RID: 1710
		private static readonly OpCode g = new OpCode("g", OpCodeName.g, 1, "setgray", OpCodeFlags.None, "Set gray level for nonstroking operations");

		// Token: 0x040006AF RID: 1711
		private static readonly OpCode gs = new OpCode("gs", OpCodeName.gs, 1, null, OpCodeFlags.None, "(PDF 1.2) Set parameters from graphics state parameter dictionary");

		// Token: 0x040006B0 RID: 1712
		private static readonly OpCode h = new OpCode("h", OpCodeName.h, 0, "closepath", OpCodeFlags.None, "Close subpath");

		// Token: 0x040006B1 RID: 1713
		private static readonly OpCode i = new OpCode("i", OpCodeName.i, 1, "setflat", OpCodeFlags.None, "Set flatness tolerance");

		// Token: 0x040006B2 RID: 1714
		private static readonly OpCode ID = new OpCode("ID", OpCodeName.ID, 0, null, OpCodeFlags.None, "Begin inline image data");

		// Token: 0x040006B3 RID: 1715
		private static readonly OpCode j = new OpCode("j", OpCodeName.j, 1, "setlinejoin", OpCodeFlags.None, "Set line join style");

		// Token: 0x040006B4 RID: 1716
		private static readonly OpCode J = new OpCode("J", OpCodeName.J, 1, "setlinecap", OpCodeFlags.None, "Set line cap style");

		// Token: 0x040006B5 RID: 1717
		private static readonly OpCode K = new OpCode("K", OpCodeName.K, 4, "setcmykcolor", OpCodeFlags.None, "Set CMYK color for stroking operations");

		// Token: 0x040006B6 RID: 1718
		private static readonly OpCode k = new OpCode("k", OpCodeName.k, 4, "setcmykcolor", OpCodeFlags.None, "Set CMYK color for nonstroking operations");

		// Token: 0x040006B7 RID: 1719
		private static readonly OpCode l = new OpCode("l", OpCodeName.l, 2, "lineto", OpCodeFlags.None, "Append straight line segment to path");

		// Token: 0x040006B8 RID: 1720
		private static readonly OpCode m = new OpCode("m", OpCodeName.m, 2, "moveto", OpCodeFlags.None, "Begin new subpath");

		// Token: 0x040006B9 RID: 1721
		private static readonly OpCode M = new OpCode("M", OpCodeName.M, 1, "setmiterlimit", OpCodeFlags.None, "Set miter limit");

		// Token: 0x040006BA RID: 1722
		private static readonly OpCode MP = new OpCode("MP", OpCodeName.MP, 1, null, OpCodeFlags.None, "(PDF 1.2) Define marked-content point");

		// Token: 0x040006BB RID: 1723
		private static readonly OpCode n = new OpCode("n", OpCodeName.n, 0, null, OpCodeFlags.None, "End path without filling or stroking");

		// Token: 0x040006BC RID: 1724
		private static readonly OpCode q = new OpCode("q", OpCodeName.q, 0, "gsave", OpCodeFlags.None, "Save graphics state");

		// Token: 0x040006BD RID: 1725
		private static readonly OpCode Q = new OpCode("Q", OpCodeName.Q, 0, "grestore", OpCodeFlags.None, "Restore graphics state");

		// Token: 0x040006BE RID: 1726
		private static readonly OpCode re = new OpCode("re", OpCodeName.re, 4, null, OpCodeFlags.None, "Append rectangle to path");

		// Token: 0x040006BF RID: 1727
		private static readonly OpCode RG = new OpCode("RG", OpCodeName.RG, 3, "setrgbcolor", OpCodeFlags.None, "Set RGB color for stroking operations");

		// Token: 0x040006C0 RID: 1728
		private static readonly OpCode rg = new OpCode("rg", OpCodeName.rg, 3, "setrgbcolor", OpCodeFlags.None, "Set RGB color for nonstroking operations");

		// Token: 0x040006C1 RID: 1729
		private static readonly OpCode ri = new OpCode("ri", OpCodeName.ri, 1, null, OpCodeFlags.None, "Set color rendering intent");

		// Token: 0x040006C2 RID: 1730
		private static readonly OpCode s = new OpCode("s", OpCodeName.s, 0, "closepath,stroke", OpCodeFlags.None, "Close and stroke path");

		// Token: 0x040006C3 RID: 1731
		private static readonly OpCode S = new OpCode("S", OpCodeName.S, 0, "stroke", OpCodeFlags.None, "Stroke path");

		// Token: 0x040006C4 RID: 1732
		private static readonly OpCode SC = new OpCode("SC", OpCodeName.SC, -1, "setcolor", OpCodeFlags.None, "(PDF 1.1) Set color for stroking operations");

		// Token: 0x040006C5 RID: 1733
		private static readonly OpCode sc = new OpCode("sc", OpCodeName.sc, -1, "setcolor", OpCodeFlags.None, "(PDF 1.1) Set color for nonstroking operations");

		// Token: 0x040006C6 RID: 1734
		private static readonly OpCode SCN = new OpCode("SCN", OpCodeName.SCN, -1, "setcolor", OpCodeFlags.None, "(PDF 1.2) Set color for stroking operations (ICCBased and special color spaces)");

		// Token: 0x040006C7 RID: 1735
		private static readonly OpCode scn = new OpCode("scn", OpCodeName.scn, -1, "setcolor", OpCodeFlags.None, "(PDF 1.2) Set color for nonstroking operations (ICCBased and special color spaces)");

		// Token: 0x040006C8 RID: 1736
		private static readonly OpCode sh = new OpCode("sh", OpCodeName.sh, 1, "shfill", OpCodeFlags.None, "(PDF 1.3) Paint area defined by shading pattern");

		// Token: 0x040006C9 RID: 1737
		private static readonly OpCode Tx = new OpCode("T*", OpCodeName.Tx, 0, null, OpCodeFlags.None, "Move to start of next text line");

		// Token: 0x040006CA RID: 1738
		private static readonly OpCode Tc = new OpCode("Tc", OpCodeName.Tc, 1, null, OpCodeFlags.None, "Set character spacing");

		// Token: 0x040006CB RID: 1739
		private static readonly OpCode Td = new OpCode("Td", OpCodeName.Td, 2, null, OpCodeFlags.None, "Move text position");

		// Token: 0x040006CC RID: 1740
		private static readonly OpCode TD = new OpCode("TD", OpCodeName.TD, 2, null, OpCodeFlags.None, "Move text position and set leading");

		// Token: 0x040006CD RID: 1741
		private static readonly OpCode Tf = new OpCode("Tf", OpCodeName.Tf, 2, "selectfont", OpCodeFlags.None, "Set text font and size");

		// Token: 0x040006CE RID: 1742
		private static readonly OpCode Tj = new OpCode("Tj", OpCodeName.Tj, 1, "show", OpCodeFlags.TextOut, "Show text");

		// Token: 0x040006CF RID: 1743
		private static readonly OpCode TJ = new OpCode("TJ", OpCodeName.TJ, 1, null, OpCodeFlags.TextOut, "Show text, allowing individual glyph positioning");

		// Token: 0x040006D0 RID: 1744
		private static readonly OpCode TL = new OpCode("TL", OpCodeName.TL, 1, null, OpCodeFlags.None, "Set text leading");

		// Token: 0x040006D1 RID: 1745
		private static readonly OpCode Tm = new OpCode("Tm", OpCodeName.Tm, 6, null, OpCodeFlags.None, "Set text matrix and text line matrix");

		// Token: 0x040006D2 RID: 1746
		private static readonly OpCode Tr = new OpCode("Tr", OpCodeName.Tr, 1, null, OpCodeFlags.None, "Set text rendering mode");

		// Token: 0x040006D3 RID: 1747
		private static readonly OpCode Ts = new OpCode("Ts", OpCodeName.Ts, 1, null, OpCodeFlags.None, "Set text rise");

		// Token: 0x040006D4 RID: 1748
		private static readonly OpCode Tw = new OpCode("Tw", OpCodeName.Tw, 1, null, OpCodeFlags.None, "Set word spacing");

		// Token: 0x040006D5 RID: 1749
		private static readonly OpCode Tz = new OpCode("Tz", OpCodeName.Tz, 1, null, OpCodeFlags.None, "Set horizontal text scaling");

		// Token: 0x040006D6 RID: 1750
		private static readonly OpCode v = new OpCode("v", OpCodeName.v, 4, "curveto", OpCodeFlags.None, "Append curved segment to path (initial point replicated)");

		// Token: 0x040006D7 RID: 1751
		private static readonly OpCode w = new OpCode("w", OpCodeName.w, 1, "setlinewidth", OpCodeFlags.None, "Set line width");

		// Token: 0x040006D8 RID: 1752
		private static readonly OpCode W = new OpCode("W", OpCodeName.W, 0, "clip", OpCodeFlags.None, "Set clipping path using nonzero winding number rule");

		// Token: 0x040006D9 RID: 1753
		private static readonly OpCode Wx = new OpCode("W*", OpCodeName.Wx, 0, "eoclip", OpCodeFlags.None, "Set clipping path using even-odd rule");

		// Token: 0x040006DA RID: 1754
		private static readonly OpCode y = new OpCode("y", OpCodeName.y, 4, "curveto", OpCodeFlags.None, "Append curved segment to path (final point replicated)");

		// Token: 0x040006DB RID: 1755
		private static readonly OpCode QuoteSingle = new OpCode("'", OpCodeName.QuoteSingle, 1, null, OpCodeFlags.TextOut, "Move to next line and show text");

		// Token: 0x040006DC RID: 1756
		private static readonly OpCode QuoteDbl = new OpCode("\"", OpCodeName.QuoteDbl, 3, null, OpCodeFlags.TextOut, "Set word and character spacing, move to next line, and show text");

		// Token: 0x040006DD RID: 1757
		private static readonly OpCode[] ops = new OpCode[]
		{
			OpCodes.Dictionary,
			OpCodes.b,
			OpCodes.B,
			OpCodes.bx,
			OpCodes.Bx,
			OpCodes.BDC,
			OpCodes.BI,
			OpCodes.BMC,
			OpCodes.BT,
			OpCodes.BX,
			OpCodes.c,
			OpCodes.cm,
			OpCodes.CS,
			OpCodes.cs,
			OpCodes.d,
			OpCodes.d0,
			OpCodes.d1,
			OpCodes.Do,
			OpCodes.DP,
			OpCodes.EI,
			OpCodes.EMC,
			OpCodes.ET,
			OpCodes.EX,
			OpCodes.f,
			OpCodes.F,
			OpCodes.fx,
			OpCodes.G,
			OpCodes.g,
			OpCodes.gs,
			OpCodes.h,
			OpCodes.i,
			OpCodes.ID,
			OpCodes.j,
			OpCodes.J,
			OpCodes.K,
			OpCodes.k,
			OpCodes.l,
			OpCodes.m,
			OpCodes.M,
			OpCodes.MP,
			OpCodes.n,
			OpCodes.q,
			OpCodes.Q,
			OpCodes.re,
			OpCodes.RG,
			OpCodes.rg,
			OpCodes.ri,
			OpCodes.s,
			OpCodes.S,
			OpCodes.SC,
			OpCodes.sc,
			OpCodes.SCN,
			OpCodes.scn,
			OpCodes.sh,
			OpCodes.Tx,
			OpCodes.Tc,
			OpCodes.Td,
			OpCodes.TD,
			OpCodes.Tf,
			OpCodes.Tj,
			OpCodes.TJ,
			OpCodes.TL,
			OpCodes.Tm,
			OpCodes.Tr,
			OpCodes.Ts,
			OpCodes.Tw,
			OpCodes.Tz,
			OpCodes.v,
			OpCodes.w,
			OpCodes.W,
			OpCodes.Wx,
			OpCodes.y,
			OpCodes.QuoteSingle,
			OpCodes.QuoteDbl
		};
	}
}
