using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace TEST8
{
	// Token: 0x02000013 RID: 19
	internal class Program
	{
		// Token: 0x060000AC RID: 172
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x060000AD RID: 173
		[DllImport("user32.dll")]
		private static extern void ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x060000AE RID: 174
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		// Token: 0x060000AF RID: 175
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

		// Token: 0x060000B0 RID: 176
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

		// Token: 0x060000B1 RID: 177
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

		// Token: 0x060000B2 RID: 178
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x060000B3 RID: 179
		[DllImport("gdi32.dll")]
		private static extern bool DeleteDC(IntPtr hdc);

		// Token: 0x060000B4 RID: 180 RVA: 0x00004F44 File Offset: 0x00003144
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
						int num2 = (int)(228.0 + 127.0 * Math.Sin(0.05 * (double)i + (double)num * 0.1));
						int num3 = (int)(228.0 + 127.0 * Math.Cos(0.05 * (double)j + (double)num * 0.1));
						int num4 = (int)(228.0 + 127.0 * Math.Sin(0.1 * (double)(i + j) + (double)num * 0.1));
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
				Thread.Sleep(2);
			}
			Program.DeleteObject(intPtr2);
			Program.DeleteDC(intPtr);
			Program.ReleaseDC(IntPtr.Zero, dc);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00005194 File Offset: 0x00003394
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
			string text = "bytebeat.wav";
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

		// Token: 0x060000B6 RID: 182 RVA: 0x00005358 File Offset: 0x00003558
		public static void ShowEffects()
		{
			Thread thread = new Thread(new ThreadStart(Program.ScreenBlendEffect));
			thread.Start();
			Program.GenerateAndPlayBytebeat();
			thread.Join();
		}

		// Token: 0x060000B7 RID: 183
		[DllImport("gdi32.dll")]
		private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

		// Token: 0x060000B8 RID: 184
		[DllImport("gdi32.dll")]
		private static extern bool SetDIBits(IntPtr hdc, IntPtr hbm, uint start, uint cLines, IntPtr lpBits, ref Program.BitmapInfo lpbmi, uint colorUse);

		// Token: 0x04000037 RID: 55
		private const int SRCCOPY = 13369376;

		// Token: 0x04000038 RID: 56
		private const int HORZRES = 8;

		// Token: 0x04000039 RID: 57
		private const int VERTRES = 10;

		// Token: 0x02000038 RID: 56
		public struct BitmapInfo
		{
			// Token: 0x040000C4 RID: 196
			public Program.BitmapInfoHeader bmiHeader;

			// Token: 0x040000C5 RID: 197
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
			public uint[] bmiColors;
		}

		// Token: 0x02000039 RID: 57
		public struct BitmapInfoHeader
		{
			// Token: 0x040000C6 RID: 198
			public int biSize;

			// Token: 0x040000C7 RID: 199
			public int biWidth;

			// Token: 0x040000C8 RID: 200
			public int biHeight;

			// Token: 0x040000C9 RID: 201
			public short biPlanes;

			// Token: 0x040000CA RID: 202
			public short biBitCount;

			// Token: 0x040000CB RID: 203
			public int biCompression;

			// Token: 0x040000CC RID: 204
			public int biSizeImage;

			// Token: 0x040000CD RID: 205
			public int biXPelsPerMeter;

			// Token: 0x040000CE RID: 206
			public int biYPelsPerMeter;

			// Token: 0x040000CF RID: 207
			public int biClrUsed;

			// Token: 0x040000D0 RID: 208
			public int biClrImportant;
		}
	}
}
