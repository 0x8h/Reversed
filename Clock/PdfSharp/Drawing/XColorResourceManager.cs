using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace PdfSharp.Drawing
{
	// Token: 0x02000058 RID: 88
	public class XColorResourceManager
	{
		// Token: 0x06000286 RID: 646 RVA: 0x0000D6C9 File Offset: 0x0000B8C9
		public XColorResourceManager()
			: this(Thread.CurrentThread.CurrentUICulture)
		{
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000D6DB File Offset: 0x0000B8DB
		public XColorResourceManager(CultureInfo cultureInfo)
		{
			this._cultureInfo = cultureInfo;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000D6EC File Offset: 0x0000B8EC
		public static XKnownColor GetKnownColor(uint argb)
		{
			XKnownColor knownColor = XKnownColorTable.GetKnownColor(argb);
			if (knownColor == (XKnownColor)(-1))
			{
				throw new ArgumentException("The argument is not a known color", "argb");
			}
			return knownColor;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000D718 File Offset: 0x0000B918
		public static XKnownColor[] GetKnownColors(bool includeTransparent)
		{
			int num = XColorResourceManager.colorInfos.Length;
			XKnownColor[] array = new XKnownColor[num - (includeTransparent ? 0 : 1)];
			int i = (includeTransparent ? 0 : 1);
			int num2 = 0;
			while (i < num)
			{
				array[num2] = XColorResourceManager.colorInfos[i].KnownColor;
				i++;
				num2++;
			}
			return array;
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000D768 File Offset: 0x0000B968
		public string ToColorName(XKnownColor knownColor)
		{
			XColorResourceManager.ColorResourceInfo colorInfo = XColorResourceManager.GetColorInfo(knownColor);
			if (this._cultureInfo.TwoLetterISOLanguageName == "de")
			{
				return colorInfo.NameDE;
			}
			return colorInfo.Name;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000D7A4 File Offset: 0x0000B9A4
		public string ToColorName(XColor color)
		{
			string text;
			if (color.IsKnownColor)
			{
				text = this.ToColorName(XKnownColorTable.GetKnownColor(color.Argb));
			}
			else
			{
				text = string.Format("{0}, {1}, {2}, {3}", new object[]
				{
					(int)(255.0 * color.A),
					color.R,
					color.G,
					color.B
				});
			}
			return text;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000D82C File Offset: 0x0000BA2C
		private static XColorResourceManager.ColorResourceInfo GetColorInfo(XKnownColor knownColor)
		{
			for (int i = 0; i < XColorResourceManager.colorInfos.Length; i++)
			{
				XColorResourceManager.ColorResourceInfo colorResourceInfo = XColorResourceManager.colorInfos[i];
				if (colorResourceInfo.KnownColor == knownColor)
				{
					return colorResourceInfo;
				}
			}
			throw new InvalidEnumArgumentException("Enum is not an XKnownColor.");
		}

		// Token: 0x04000207 RID: 519
		private readonly CultureInfo _cultureInfo;

		// Token: 0x04000208 RID: 520
		internal static XColorResourceManager.ColorResourceInfo[] colorInfos = new XColorResourceManager.ColorResourceInfo[]
		{
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Transparent, XColors.Transparent, 16777215U, "Transparent", "Transparent"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Black, XColors.Black, 4278190080U, "Black", "Schwarz"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkSlateGray, XColors.DarkSlateGray, 4287609999U, "Darkslategray", "Dunkles Schiefergrau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.SlateGray, XColors.SlateGray, 4285563024U, "Slategray", "Schiefergrau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightSlateGray, XColors.LightSlateGray, 4286023833U, "Lightslategray", "Helles Schiefergrau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightSteelBlue, XColors.LightSteelBlue, 4289774814U, "Lightsteelblue", "Helles Stahlblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DimGray, XColors.DimGray, 4285098345U, "Dimgray", "Gedecktes Grau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Gray, XColors.Gray, 4286611584U, "Gray", "Grau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkGray, XColors.DarkGray, 4289309097U, "Darkgray", "Dunkelgrau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Silver, XColors.Silver, 4290822336U, "Silver", "Silber"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Gainsboro, XColors.Gainsboro, 4292664540U, "Gainsboro", "Helles Blaugrau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.WhiteSmoke, XColors.WhiteSmoke, 4294309365U, "Whitesmoke", "Rauchweiß"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.GhostWhite, XColors.GhostWhite, 4294506751U, "Ghostwhite", "Schattenweiß"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.White, XColors.White, uint.MaxValue, "White", "Weiß"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Snow, XColors.Snow, 4294966010U, "Snow", "Schneeweiß"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Ivory, XColors.Ivory, 4294967280U, "Ivory", "Elfenbein"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.FloralWhite, XColors.FloralWhite, 4294966000U, "Floralwhite", "Blütenweiß"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.SeaShell, XColors.SeaShell, 4294964718U, "Seashell", "Muschel"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.OldLace, XColors.OldLace, 4294833638U, "Oldlace", "Altweiß"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Linen, XColors.Linen, 4294635750U, "Linen", "Leinen"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.AntiqueWhite, XColors.AntiqueWhite, 4294634455U, "Antiquewhite", "Antikes Weiß"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.BlanchedAlmond, XColors.BlanchedAlmond, 4294962125U, "Blanchedalmond", "Mandelweiß"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.PapayaWhip, XColors.PapayaWhip, 4294963157U, "Papayawhip", "Papayacreme"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Beige, XColors.Beige, 4294309340U, "Beige", "Beige"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Cornsilk, XColors.Cornsilk, 4294965468U, "Cornsilk", "Mais"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightGoldenrodYellow, XColors.LightGoldenrodYellow, 4294638290U, "Lightgoldenrodyellow", "Helles Goldgelb"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightYellow, XColors.LightYellow, 4294967264U, "Lightyellow", "Hellgelb"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LemonChiffon, XColors.LemonChiffon, 4294965965U, "Lemonchiffon", "Pastellgelb"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.PaleGoldenrod, XColors.PaleGoldenrod, 4293847210U, "Palegoldenrod", "Blasses Goldgelb"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Khaki, XColors.Khaki, 4293977740U, "Khaki", "Khaki"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Yellow, XColors.Yellow, 4294967040U, "Yellow", "Gelb"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Gold, XColors.Gold, 4294956800U, "Gold", "Gold"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Orange, XColors.Orange, 4294944000U, "Orange", "Orange"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkOrange, XColors.DarkOrange, 4294937600U, "Darkorange", "Dunkles Orange"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Goldenrod, XColors.Goldenrod, 4292519200U, "Goldenrod", "Goldgelb"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkGoldenrod, XColors.DarkGoldenrod, 4290283019U, "Darkgoldenrod", "Dunkles Goldgelb"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Peru, XColors.Peru, 4291659071U, "Peru", "Peru"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Chocolate, XColors.Chocolate, 4291979550U, "Chocolate", "Schokolade"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.SaddleBrown, XColors.SaddleBrown, 4287317267U, "Saddlebrown", "Sattelbraun"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Sienna, XColors.Sienna, 4288696877U, "Sienna", "Ocker"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Brown, XColors.Brown, 4289014314U, "Brown", "Braun"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkRed, XColors.DarkRed, 4287299584U, "Darkred", "Dunkelrot"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Maroon, XColors.Maroon, 4286578688U, "Maroon", "Kastanienbraun"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.PaleTurquoise, XColors.PaleTurquoise, 4289720046U, "Paleturquoise", "Blasses Türkis"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Firebrick, XColors.Firebrick, 4289864226U, "Firebrick", "Ziegel"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.IndianRed, XColors.IndianRed, 4291648604U, "Indianred", "Indischrot"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Crimson, XColors.Crimson, 4292613180U, "Crimson", "Karmesinrot"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Red, XColors.Red, 4294901760U, "Red", "Rot"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.OrangeRed, XColors.OrangeRed, 4294919424U, "Orangered", "Orangerot"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Tomato, XColors.Tomato, 4294927175U, "Tomato", "Tomate"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Coral, XColors.Coral, 4294934352U, "Coral", "Koralle"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Salmon, XColors.Salmon, 4294606962U, "Salmon", "Lachs"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightCoral, XColors.LightCoral, 4293951616U, "Lightcoral", "Helles Korallenrot"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkSalmon, XColors.DarkSalmon, 4293498490U, "Darksalmon", "Dunkles Lachs"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightSalmon, XColors.LightSalmon, 4294942842U, "Lightsalmon", "Helles Lachs"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.SandyBrown, XColors.SandyBrown, 4294222944U, "Sandybrown", "Sandbraun"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.RosyBrown, XColors.RosyBrown, 4290547599U, "Rosybrown", "Rotbraun"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Tan, XColors.Tan, 4291998860U, "Tan", "Gelbbraun"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.BurlyWood, XColors.BurlyWood, 4292786311U, "Burlywood", "Kräftiges Sandbraun"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Wheat, XColors.Wheat, 4294303411U, "Wheat", "Weizen"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.PeachPuff, XColors.PeachPuff, 4294957753U, "Peachpuff", "Pfirsich"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.NavajoWhite, XColors.NavajoWhite, 4294958765U, "Navajowhite", "Orangeweiß"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Bisque, XColors.Bisque, 4294960324U, "Bisque", "Blasses Rotbraun"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Moccasin, XColors.Moccasin, 4294960309U, "Moccasin", "Mokassin"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LavenderBlush, XColors.LavenderBlush, 4294963445U, "Lavenderblush", "Roter Lavendel"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.MistyRose, XColors.MistyRose, 4294960353U, "Mistyrose", "Altrosa"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Pink, XColors.Pink, 4294951115U, "Pink", "Rosa"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightPink, XColors.LightPink, 4294948545U, "Lightpink", "Hellrosa"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.HotPink, XColors.HotPink, 4294928820U, "Hotpink", "Leuchtendes Rosa"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Magenta, XColors.Magenta, 4294902015U, "Magenta", "Magentarot"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DeepPink, XColors.DeepPink, 4294907027U, "Deeppink", "Tiefrosa"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.MediumVioletRed, XColors.MediumVioletRed, 4291237253U, "Mediumvioletred", "Mittleres Violettrot"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.PaleVioletRed, XColors.PaleVioletRed, 4292571283U, "Palevioletred", "Blasses Violettrot"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Plum, XColors.Plum, 4292714717U, "Plum", "Pflaume"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Thistle, XColors.Thistle, 4292394968U, "Thistle", "Distel"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Lavender, XColors.Lavender, 4293322490U, "Lavender", "Lavendel"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Violet, XColors.Violet, 4293821166U, "Violet", "Violett"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Orchid, XColors.Orchid, 4292505814U, "Orchid", "Orchidee"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkMagenta, XColors.DarkMagenta, 4287299723U, "Darkmagenta", "Dunkles Magentarot"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Purple, XColors.Purple, 4286578816U, "Purple", "Violett"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Indigo, XColors.Indigo, 4283105410U, "Indigo", "Indigo"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.BlueViolet, XColors.BlueViolet, 4287245282U, "Blueviolet", "Blauviolett"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkViolet, XColors.DarkViolet, 4287889619U, "Darkviolet", "Dunkles Violett"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkOrchid, XColors.DarkOrchid, 4288230092U, "Darkorchid", "Dunkle Orchidee"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.MediumPurple, XColors.MediumPurple, 4287852763U, "Mediumpurple", "Mittleres Violett"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.MediumOrchid, XColors.MediumOrchid, 4290401747U, "Mediumorchid", "Mittlere Orchidee"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.MediumSlateBlue, XColors.MediumSlateBlue, 4286277870U, "Mediumslateblue", "Mittleres Schieferblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.SlateBlue, XColors.SlateBlue, 4285160141U, "Slateblue", "Schieferblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkSlateBlue, XColors.DarkSlateBlue, 4282924427U, "Darkslateblue", "Dunkles Schiefergrau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.MidnightBlue, XColors.MidnightBlue, 4279834992U, "Midnightblue", "Mitternachtsblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Navy, XColors.Navy, 4278190208U, "Navy", "Marineblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkBlue, XColors.DarkBlue, 4278190219U, "Darkblue", "Dunkelblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightGray, XColors.LightGray, 4292072403U, "Lightgray", "Hellgrau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.MediumBlue, XColors.MediumBlue, 4278190285U, "Mediumblue", "Mittelblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Blue, XColors.Blue, 4278190335U, "Blue", "Blau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.RoyalBlue, XColors.RoyalBlue, 4282477025U, "Royalblue", "Königsblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.SteelBlue, XColors.SteelBlue, 4282811060U, "Steelblue", "Stahlblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.CornflowerBlue, XColors.CornflowerBlue, 4284782061U, "Cornflowerblue", "Kornblumenblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DodgerBlue, XColors.DodgerBlue, 4280193279U, "Dodgerblue", "Dodger-Blau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DeepSkyBlue, XColors.DeepSkyBlue, 4278239231U, "Deepskyblue", "Tiefes Himmelblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightSkyBlue, XColors.LightSkyBlue, 4287090426U, "Lightskyblue", "Helles Himmelblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.SkyBlue, XColors.SkyBlue, 4287090411U, "Skyblue", "Himmelblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightBlue, XColors.LightBlue, 4289583334U, "Lightblue", "Hellblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Cyan, XColors.Cyan, 4278255615U, "Cyan", "Zyan"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.PowderBlue, XColors.PowderBlue, 4289781990U, "Powderblue", "Taubenblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightCyan, XColors.LightCyan, 4292935679U, "Lightcyan", "Helles Cyanblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.AliceBlue, XColors.AliceBlue, 4288728576U, "Aliceblue", "Aliceblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Azure, XColors.Azure, 4293984255U, "Azure", "Himmelblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.MintCream, XColors.MintCream, 4294311930U, "Mintcream", "Helles Pfefferminzgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Honeydew, XColors.Honeydew, 4293984240U, "Honeydew", "Honigmelone"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Aquamarine, XColors.Aquamarine, 4286578644U, "Aquamarine", "Aquamarinblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Turquoise, XColors.Turquoise, 4282441936U, "Turquoise", "Türkis"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.MediumTurquoise, XColors.MediumTurquoise, 4282962380U, "Mediumturqoise", "Mittleres Türkis"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkTurquoise, XColors.DarkTurquoise, 4278243025U, "Darkturquoise", "Dunkles Türkis"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.MediumAquamarine, XColors.MediumAquamarine, 4284927402U, "Mediumaquamarine", "Mittleres Aquamarinblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightSeaGreen, XColors.LightSeaGreen, 4280332970U, "Lightseagreen", "Helles Seegrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkCyan, XColors.DarkCyan, 4278225803U, "Darkcyan", "Dunkles Zyanblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Teal, XColors.Teal, 4278222976U, "Teal", "Entenblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.CadetBlue, XColors.CadetBlue, 4284456608U, "Cadetblue", "Kadettblau"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.MediumSeaGreen, XColors.MediumSeaGreen, 4282168177U, "Mediumseagreen", "Mittleres Seegrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkSeaGreen, XColors.DarkSeaGreen, 4287609999U, "Darkseagreen", "Dunkles Seegrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LightGreen, XColors.LightGreen, 4287688336U, "Lightgreen", "Hellgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.PaleGreen, XColors.PaleGreen, 4288215960U, "Palegreen", "Blassgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.MediumSpringGreen, XColors.MediumSpringGreen, 4278254234U, "Mediumspringgreen", "Mittleres Frühlingsgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.SpringGreen, XColors.SpringGreen, 4278255487U, "Springgreen", "Frühlingsgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Lime, XColors.Lime, 4278255360U, "Lime", "Zitronengrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LimeGreen, XColors.LimeGreen, 4281519410U, "Limegreen", "Gelbgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.SeaGreen, XColors.SeaGreen, 4281240407U, "Seagreen", "Seegrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.ForestGreen, XColors.ForestGreen, 4280453922U, "Forestgreen", "Waldgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Green, XColors.Green, 4278222848U, "Green", "Grün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.LawnGreen, XColors.LawnGreen, 4278222848U, "LawnGreen", "Grasgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkGreen, XColors.DarkGreen, 4278215680U, "Darkgreen", "Dunkelgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.OliveDrab, XColors.OliveDrab, 4285238819U, "Olivedrab", "Reife Olive"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkOliveGreen, XColors.DarkOliveGreen, 4283788079U, "Darkolivegreen", "Dunkles Olivgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Olive, XColors.Olive, 4286611456U, "Olive", "Olivgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.DarkKhaki, XColors.DarkKhaki, 4290623339U, "Darkkhaki", "Dunkles Khaki"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.YellowGreen, XColors.YellowGreen, 4288335154U, "Yellowgreen", "Gelbgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.Chartreuse, XColors.Chartreuse, 4286578432U, "Chartreuse", "Hellgrün"),
			new XColorResourceManager.ColorResourceInfo(XKnownColor.GreenYellow, XColors.GreenYellow, 4289593135U, "Greenyellow", "Grüngelb")
		};

		// Token: 0x02000059 RID: 89
		internal struct ColorResourceInfo
		{
			// Token: 0x0600028E RID: 654 RVA: 0x0000EE77 File Offset: 0x0000D077
			public ColorResourceInfo(XKnownColor knownColor, XColor color, uint argb, string name, string nameDE)
			{
				this.KnownColor = knownColor;
				this.Color = color;
				this.Argb = argb;
				this.Name = name;
				this.NameDE = nameDE;
			}

			// Token: 0x04000209 RID: 521
			public XKnownColor KnownColor;

			// Token: 0x0400020A RID: 522
			public XColor Color;

			// Token: 0x0400020B RID: 523
			public uint Argb;

			// Token: 0x0400020C RID: 524
			public string Name;

			// Token: 0x0400020D RID: 525
			public string NameDE;
		}
	}
}
