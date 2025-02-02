using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace HYDROGEN
{
	// Token: 0x0200001B RID: 27
	internal class Program
	{
		// Token: 0x06000108 RID: 264
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x06000109 RID: 265
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x0600010A RID: 266
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		// Token: 0x0600010B RID: 267
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateDIBSection(IntPtr hdc, ref Program.BITMAPINFO pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

		// Token: 0x0600010C RID: 268
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

		// Token: 0x0600010D RID: 269
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);

		// Token: 0x0600010E RID: 270
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x0600010F RID: 271
		[DllImport("gdi32.dll")]
		private static extern bool DeleteDC(IntPtr hdc);

		// Token: 0x06000110 RID: 272
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

		// Token: 0x06000111 RID: 273 RVA: 0x00006ACC File Offset: 0x00004CCC
		public static void ShowEffect()
		{
			Task.Factory.StartNew(delegate
			{
				Bytebeat.PlayBytebeatAudio();
			});
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(0);
			int num = systemMetrics * systemMetrics2;
			DateTime dateTime = DateTime.Now.AddSeconds(10.0);
			while (DateTime.Now < dateTime)
			{
				IntPtr dc = Program.GetDC(IntPtr.Zero);
				IntPtr intPtr = Program.CreateCompatibleDC(dc);
				Program.BITMAPINFO bitmapinfo = new Program.BITMAPINFO
				{
					bmiHeader = new Program.BITMAPINFOHEADER
					{
						biSize = (uint)Marshal.SizeOf(typeof(Program.BITMAPINFOHEADER)),
						biWidth = systemMetrics,
						biHeight = -systemMetrics2,
						biPlanes = 1,
						biBitCount = 24,
						biCompression = 0U
					},
					bmiColors = new Program.RGBTRIPLE[256]
				};
				IntPtr intPtr3;
				IntPtr intPtr2 = Program.CreateDIBSection(dc, ref bitmapinfo, 0U, out intPtr3, IntPtr.Zero, 0U);
				IntPtr intPtr4 = Program.SelectObject(intPtr, intPtr2);
				Program.BitBlt(intPtr, 0, 0, systemMetrics, systemMetrics2, dc, 0, 0, 13369360U);
				byte[] array = new byte[num * 3];
				Marshal.Copy(intPtr3, array, 0, array.Length);
				for (int i = 8; i < num; i++)
				{
					array[i * 3 + 2] = (byte)Math.Min((int)(array[i * 3 + 2] + 58), 67889);
					array[i * 3 + 1] = (byte)Math.Min((int)(array[i * 3 + 1] + 190), 995089);
					array[i * 3] = (byte)Math.Min((int)(array[i * 3] + 89), 8995);
				}
				Marshal.Copy(array, 0, intPtr3, array.Length);
				Program.BitBlt(dc, 0, 0, systemMetrics, systemMetrics2, intPtr, 0, 0, 13369360U);
				Thread.Sleep(10);
				Program.SelectObject(intPtr, intPtr4);
				Program.ReleaseDC(IntPtr.Zero, dc);
				Program.DeleteObject(intPtr2);
				Program.DeleteDC(dc);
				Program.DeleteDC(intPtr);
			}
		}

		// Token: 0x0400005D RID: 93
		private const int SM_CXSCREEN = 0;

		// Token: 0x0400005E RID: 94
		private const int SM_CYSCREEN = 0;

		// Token: 0x0400005F RID: 95
		private const uint SRCCOPY = 13369360U;

		// Token: 0x02000043 RID: 67
		public struct BITMAPINFO
		{
			// Token: 0x040000F3 RID: 243
			public Program.BITMAPINFOHEADER bmiHeader;

			// Token: 0x040000F4 RID: 244
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
			public Program.RGBTRIPLE[] bmiColors;
		}

		// Token: 0x02000044 RID: 68
		public struct BITMAPINFOHEADER
		{
			// Token: 0x040000F5 RID: 245
			public uint biSize;

			// Token: 0x040000F6 RID: 246
			public int biWidth;

			// Token: 0x040000F7 RID: 247
			public int biHeight;

			// Token: 0x040000F8 RID: 248
			public ushort biPlanes;

			// Token: 0x040000F9 RID: 249
			public ushort biBitCount;

			// Token: 0x040000FA RID: 250
			public uint biCompression;

			// Token: 0x040000FB RID: 251
			public uint biSizeImage;

			// Token: 0x040000FC RID: 252
			public int biXPelsPerMeter;

			// Token: 0x040000FD RID: 253
			public int biYPelsPerMeter;

			// Token: 0x040000FE RID: 254
			public uint biClrUsed;

			// Token: 0x040000FF RID: 255
			public uint biClrImportant;
		}

		// Token: 0x02000045 RID: 69
		public struct RGBTRIPLE
		{
			// Token: 0x04000100 RID: 256
			public byte rgbtBlue;

			// Token: 0x04000101 RID: 257
			public byte rgbtGreen;

			// Token: 0x04000102 RID: 258
			public byte rgbtRed;
		}
	}
}
