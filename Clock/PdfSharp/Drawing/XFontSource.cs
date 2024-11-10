using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;

namespace PdfSharp.Drawing
{
	// Token: 0x02000064 RID: 100
	[DebuggerDisplay("{DebuggerDisplay}")]
	internal class XFontSource
	{
		// Token: 0x06000399 RID: 921 RVA: 0x0001010E File Offset: 0x0000E30E
		private XFontSource(byte[] bytes, ulong key)
		{
			this._fontName = null;
			this._bytes = bytes;
			this._key = key;
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0001012C File Offset: 0x0000E32C
		public static XFontSource GetOrCreateFrom(byte[] bytes)
		{
			ulong num = FontHelper.CalcChecksum(bytes);
			XFontSource xfontSource;
			if (!FontFactory.TryGetFontSourceByKey(num, out xfontSource))
			{
				xfontSource = new XFontSource(bytes, num);
				xfontSource = FontFactory.CacheFontSource(xfontSource);
			}
			return xfontSource;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0001015C File Offset: 0x0000E35C
		internal static XFontSource GetOrCreateFromGdi(string typefaceKey, Font gdiFont)
		{
			byte[] array = XFontSource.ReadFontBytesFromGdi(gdiFont);
			return XFontSource.GetOrCreateFrom(typefaceKey, array);
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0001017C File Offset: 0x0000E37C
		private static byte[] ReadFontBytesFromGdi(Font gdiFont)
		{
			Marshal.GetLastWin32Error();
			Marshal.GetLastWin32Error();
			IntPtr intPtr = gdiFont.ToHfont();
			IntPtr dc = NativeMethods.GetDC(IntPtr.Zero);
			Marshal.GetLastWin32Error();
			IntPtr intPtr2 = NativeMethods.SelectObject(dc, intPtr);
			Marshal.GetLastWin32Error();
			bool flag = false;
			int num = NativeMethods.GetFontData(dc, 0U, 0U, null, 0);
			if (num == -1073741790)
			{
				throw new InvalidOperationException("Microsoft Azure returns STATUS_ACCESS_DENIED ((NTSTATUS)0xC0000022L) from GetFontData. This is a bug in Azure. You must implement a FontResolver to circumvent this issue.");
			}
			if (num == -1)
			{
				num = NativeMethods.GetFontData(dc, 1717793908U, 0U, null, 0);
				flag = true;
			}
			Marshal.GetLastWin32Error();
			if (num == 0)
			{
				throw new InvalidOperationException("Cannot retrieve font data.");
			}
			byte[] array = new byte[num];
			NativeMethods.GetFontData(dc, flag ? 1717793908U : 0U, 0U, array, num);
			NativeMethods.SelectObject(dc, intPtr2);
			NativeMethods.ReleaseDC(IntPtr.Zero, dc);
			return array;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00010240 File Offset: 0x0000E440
		private static XFontSource GetOrCreateFrom(string typefaceKey, byte[] fontBytes)
		{
			ulong num = FontHelper.CalcChecksum(fontBytes);
			XFontSource xfontSource;
			if (FontFactory.TryGetFontSourceByKey(num, out xfontSource))
			{
				FontFactory.CacheExistingFontSourceWithNewTypefaceKey(typefaceKey, xfontSource);
			}
			else
			{
				xfontSource = new XFontSource(fontBytes, num);
				FontFactory.CacheNewFontSource(typefaceKey, xfontSource);
			}
			return xfontSource;
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00010278 File Offset: 0x0000E478
		public static XFontSource CreateCompiledFont(byte[] bytes)
		{
			return new XFontSource(bytes, 0UL);
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x0600039F RID: 927 RVA: 0x0001028F File Offset: 0x0000E48F
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x00010297 File Offset: 0x0000E497
		internal OpenTypeFontface Fontface
		{
			get
			{
				return this._fontface;
			}
			set
			{
				this._fontface = value;
				this._fontName = value.name.FullFontName;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x000102B1 File Offset: 0x0000E4B1
		internal ulong Key
		{
			get
			{
				if (this._key == 0UL)
				{
					this._key = FontHelper.CalcChecksum(this.Bytes);
				}
				return this._key;
			}
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x000102D4 File Offset: 0x0000E4D4
		public void IncrementKey()
		{
			this._key += 4294967296UL;
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x000102EC File Offset: 0x0000E4EC
		public string FontName
		{
			get
			{
				return this._fontName;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x000102F4 File Offset: 0x0000E4F4
		public byte[] Bytes
		{
			get
			{
				return this._bytes;
			}
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x000102FC File Offset: 0x0000E4FC
		public override int GetHashCode()
		{
			return (int)((this.Key >> 32) ^ this.Key);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00010310 File Offset: 0x0000E510
		public override bool Equals(object obj)
		{
			XFontSource xfontSource = obj as XFontSource;
			return xfontSource != null && this.Key == xfontSource.Key;
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x00010338 File Offset: 0x0000E538
		internal string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "XFontSource: '{0}', keyhash={1}", new object[]
				{
					this.FontName,
					this.Key % 99991UL
				});
			}
		}

		// Token: 0x0400024A RID: 586
		private const uint ttcf = 1717793908U;

		// Token: 0x0400024B RID: 587
		private OpenTypeFontface _fontface;

		// Token: 0x0400024C RID: 588
		private ulong _key;

		// Token: 0x0400024D RID: 589
		private string _fontName;

		// Token: 0x0400024E RID: 590
		private readonly byte[] _bytes;
	}
}
