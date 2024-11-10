using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Drawing;

namespace PdfSharp.Fonts
{
	// Token: 0x020000A7 RID: 167
	[DebuggerDisplay("{DebuggerDisplay}")]
	public class FontResolverInfo
	{
		// Token: 0x06000774 RID: 1908 RVA: 0x0001CB68 File Offset: 0x0001AD68
		public FontResolverInfo(string faceName)
			: this(faceName, false, false, 0)
		{
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x0001CB74 File Offset: 0x0001AD74
		internal FontResolverInfo(string faceName, bool mustSimulateBold, bool mustSimulateItalic, int collectionNumber)
		{
			if (string.IsNullOrEmpty(faceName))
			{
				throw new ArgumentNullException("faceName");
			}
			if (collectionNumber != 0)
			{
				throw new NotImplementedException("collectionNumber is not yet implemented and must be 0.");
			}
			this._faceName = faceName;
			this._mustSimulateBold = mustSimulateBold;
			this._mustSimulateItalic = mustSimulateItalic;
			this._collectionNumber = collectionNumber;
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0001CBC6 File Offset: 0x0001ADC6
		public FontResolverInfo(string faceName, bool mustSimulateBold, bool mustSimulateItalic)
			: this(faceName, mustSimulateBold, mustSimulateItalic, 0)
		{
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0001CBD2 File Offset: 0x0001ADD2
		public FontResolverInfo(string faceName, XStyleSimulations styleSimulations)
			: this(faceName, (styleSimulations & XStyleSimulations.BoldSimulation) == XStyleSimulations.BoldSimulation, (styleSimulations & XStyleSimulations.ItalicSimulation) == XStyleSimulations.ItalicSimulation, 0)
		{
		}

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x0001CBE8 File Offset: 0x0001ADE8
		internal string Key
		{
			get
			{
				string text;
				if ((text = this._key) == null)
				{
					text = (this._key = string.Concat(new object[]
					{
						"frik:",
						this._faceName.ToLowerInvariant(),
						'/',
						this._mustSimulateBold ? "b+" : "b-",
						this._mustSimulateItalic ? "i+" : "i-"
					}));
				}
				return text;
			}
		}

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x0001CC63 File Offset: 0x0001AE63
		public string FaceName
		{
			get
			{
				return this._faceName;
			}
		}

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x0600077A RID: 1914 RVA: 0x0001CC6B File Offset: 0x0001AE6B
		public bool MustSimulateBold
		{
			get
			{
				return this._mustSimulateBold;
			}
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x0600077B RID: 1915 RVA: 0x0001CC73 File Offset: 0x0001AE73
		public bool MustSimulateItalic
		{
			get
			{
				return this._mustSimulateItalic;
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x0001CC7B File Offset: 0x0001AE7B
		public XStyleSimulations StyleSimulations
		{
			get
			{
				return (this._mustSimulateBold ? XStyleSimulations.BoldSimulation : XStyleSimulations.None) | (this._mustSimulateItalic ? XStyleSimulations.ItalicSimulation : XStyleSimulations.None);
			}
		}

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x0001CC96 File Offset: 0x0001AE96
		internal int CollectionNumber
		{
			get
			{
				return this._collectionNumber;
			}
		}

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x0600077E RID: 1918 RVA: 0x0001CCA0 File Offset: 0x0001AEA0
		internal string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "FontResolverInfo: '{0}',{1}{2}", new object[]
				{
					this.FaceName,
					this.MustSimulateBold ? " simulate Bold" : "",
					this.MustSimulateItalic ? " simulate Italic" : ""
				});
			}
		}

		// Token: 0x040003FC RID: 1020
		private const string KeyPrefix = "frik:";

		// Token: 0x040003FD RID: 1021
		private string _key;

		// Token: 0x040003FE RID: 1022
		private readonly string _faceName;

		// Token: 0x040003FF RID: 1023
		private readonly bool _mustSimulateBold;

		// Token: 0x04000400 RID: 1024
		private readonly bool _mustSimulateItalic;

		// Token: 0x04000401 RID: 1025
		private readonly int _collectionNumber;
	}
}
