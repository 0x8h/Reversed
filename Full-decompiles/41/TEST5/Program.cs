using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace TEST5
{
	// Token: 0x02000014 RID: 20
	internal class Program
	{
		// Token: 0x060000BA RID: 186
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x060000BB RID: 187
		[DllImport("user32.dll")]
		private static extern void ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x060000BC RID: 188
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		// Token: 0x060000BD RID: 189
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

		// Token: 0x060000BE RID: 190
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

		// Token: 0x060000BF RID: 191
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

		// Token: 0x060000C0 RID: 192
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x060000C1 RID: 193
		[DllImport("gdi32.dll")]
		private static extern bool DeleteDC(IntPtr hdc);

		// Token: 0x060000C2 RID: 194 RVA: 0x00005398 File Offset: 0x00003598
		private static void ScreenBlendEffect()
		{
			IntPtr dc = Program.GetDC(IntPtr.Zero);
			int deviceCaps = Program.GetDeviceCaps(dc, 8);
			int deviceCaps2 = Program.GetDeviceCaps(dc, 10);
			IntPtr intPtr = Program.CreateCompatibleDC(dc);
			IntPtr intPtr2 = Program.CreateCompatibleBitmap(dc, deviceCaps, deviceCaps2);
			Program.SelectObject(intPtr, intPtr2);
			Program.BitmapInfo bitmapInfo = new Program.BitmapInfo
			{
				bmiHeader = new Program.BitmapInfoHeader
				{
					biSize = Marshal.SizeOf(typeof(Program.BitmapInfoHeader)),
					biWidth = deviceCaps,
					biHeight = -deviceCaps2,
					biPlanes = 1,
					biBitCount = 24,
					biCompression = 0
				}
			};
			byte[] array = new byte[deviceCaps * deviceCaps2 * 3];
			int num = 0;
			int tickCount = Environment.TickCount;
			while (Environment.TickCount - tickCount < 10000)
			{
				for (int i = 0; i < deviceCaps2; i++)
				{
					for (int j = 0; j < deviceCaps; j++)
					{
						int num2 = (int)(128.0 + 127.0 * Math.Sin(0.25 * (double)i + (double)num * 0.3));
						int num3 = (int)(128.0 + 127.0 * Math.Cos(0.25 * (double)j + (double)num * 0.4));
						int num4 = (int)(128.0 + 127.0 * Math.Sin(0.35 * (double)(i + j) + (double)num * 0.5));
						num2 = Math.Min(255, Math.Max(0, num2));
						num3 = Math.Min(255, Math.Max(0, num3));
						num4 = Math.Min(255, Math.Max(0, num4));
						array[(i * deviceCaps + j) * 3] = (byte)num4;
						array[(i * deviceCaps + j) * 3 + 1] = (byte)num3;
						array[(i * deviceCaps + j) * 3 + 2] = (byte)num2;
					}
				}
				GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
				Program.SetDIBits(intPtr, intPtr2, 0U, (uint)deviceCaps2, gchandle.AddrOfPinnedObject(), ref bitmapInfo, 0U);
				gchandle.Free();
				Program.BitBlt(dc, 0, 0, deviceCaps, deviceCaps2, intPtr, 0, 0, 13369376);
				num++;
				Thread.Sleep(1);
			}
			Program.DeleteObject(intPtr2);
			Program.DeleteDC(intPtr);
			Program.ReleaseDC(IntPtr.Zero, dc);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00005624 File Offset: 0x00003824
		private static void GenerateAndPlayBytebeat()
		{
			byte[] array = new byte[882000];
			for (int i = 0; i < 441000; i++)
			{
				int num = i;
				short num2 = (short)((num * num >> 29) | (num >> 25) | (num >> 2) | (num >> 8));
				array[i * 2] = (byte)(num2 & 255);
				array[i * 2 + 1] = (byte)((num2 >> 8) & 255);
			}
			string text = "TEST555.wav";
			using (FileStream fileStream = new FileStream(text, FileMode.Create))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
				{
					binaryWriter.Write(new char[] { 'R', 'I', 'F', 'F' });
					binaryWriter.Write(441036);
					binaryWriter.Write(new char[] { 'W', 'A', 'V', 'E' });
					binaryWriter.Write(new char[] { 'f', 'm', 't', ' ' });
					binaryWriter.Write(16);
					binaryWriter.Write(1);
					binaryWriter.Write(1);
					binaryWriter.Write(44100);
					binaryWriter.Write(88200);
					binaryWriter.Write(2);
					binaryWriter.Write(16);
					binaryWriter.Write(new char[] { 'd', 'a', 't', 'a' });
					binaryWriter.Write(441000);
					binaryWriter.Write(array);
				}
			}
			File.SetAttributes(text, FileAttributes.Hidden);
			using (SoundPlayer soundPlayer = new SoundPlayer(text))
			{
				soundPlayer.PlaySync();
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000057E8 File Offset: 0x000039E8
		public static void ShowEffects()
		{
			Thread thread = new Thread(new ThreadStart(Program.ScreenBlendEffect));
			thread.Start();
			Program.GenerateAndPlayBytebeat();
			thread.Join();
		}

		// Token: 0x060000C5 RID: 197
		[DllImport("gdi32.dll")]
		private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

		// Token: 0x060000C6 RID: 198
		[DllImport("gdi32.dll")]
		private static extern bool SetDIBits(IntPtr hdc, IntPtr hbm, uint start, uint cLines, IntPtr lpBits, ref Program.BitmapInfo lpbmi, uint colorUse);

		// Token: 0x0400003A RID: 58
		private const int SRCCOPY = 13369376;

		// Token: 0x0400003B RID: 59
		private const int HORZRES = 8;

		// Token: 0x0400003C RID: 60
		private const int VERTRES = 10;

		// Token: 0x0200003A RID: 58
		public struct BitmapInfo
		{
			// Token: 0x040000D1 RID: 209
			public Program.BitmapInfoHeader bmiHeader;

			// Token: 0x040000D2 RID: 210
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
			public uint[] bmiColors;
		}

		// Token: 0x0200003B RID: 59
		public struct BitmapInfoHeader
		{
			// Token: 0x040000D3 RID: 211
			public int biSize;

			// Token: 0x040000D4 RID: 212
			public int biWidth;

			// Token: 0x040000D5 RID: 213
			public int biHeight;

			// Token: 0x040000D6 RID: 214
			public short biPlanes;

			// Token: 0x040000D7 RID: 215
			public short biBitCount;

			// Token: 0x040000D8 RID: 216
			public int biCompression;

			// Token: 0x040000D9 RID: 217
			public int biSizeImage;

			// Token: 0x040000DA RID: 218
			public int biXPelsPerMeter;

			// Token: 0x040000DB RID: 219
			public int biYPelsPerMeter;

			// Token: 0x040000DC RID: 220
			public int biClrUsed;

			// Token: 0x040000DD RID: 221
			public int biClrImportant;
		}
	}
}
