using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace TEST89
{
	// Token: 0x02000016 RID: 22
	internal class Program
	{
		// Token: 0x060000DA RID: 218
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x060000DB RID: 219
		[DllImport("user32.dll")]
		private static extern void ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x060000DC RID: 220
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		// Token: 0x060000DD RID: 221
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

		// Token: 0x060000DE RID: 222
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

		// Token: 0x060000DF RID: 223
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

		// Token: 0x060000E0 RID: 224
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x060000E1 RID: 225
		[DllImport("gdi32.dll")]
		private static extern bool DeleteDC(IntPtr hdc);

		// Token: 0x060000E2 RID: 226 RVA: 0x00005E80 File Offset: 0x00004080
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
			byte[][] array2 = new byte[deviceCaps2][];
			for (int i = 0; i < deviceCaps2; i++)
			{
				array2[i] = new byte[deviceCaps * 3];
			}
			int tickCount = Environment.TickCount;
			while (Environment.TickCount - tickCount < 10000)
			{
				int num2 = (int)((double)num / 10.0) % 256;
				for (int j = 0; j < deviceCaps2; j++)
				{
					for (int k = 0; k < deviceCaps; k++)
					{
						int num3 = (int)(228.0 + 127.0 * Math.Sin(0.05 * (double)j + (double)num * 0.1));
						int num4 = (int)(228.0 + 127.0 * Math.Cos(0.05 * (double)k + (double)num * 0.1));
						int num5 = (int)(228.0 + 127.0 * Math.Sin(0.1 * (double)(j + k) + (double)num * 0.1));
						int num6 = (j * deviceCaps + k) % 256;
						array2[j][k * 3] = (byte)num5;
						array2[j][k * 3 + 1] = (byte)num4;
						array2[j][k * 3 + 2] = (byte)num3;
					}
				}
				for (int l = 0; l < deviceCaps2; l++)
				{
					for (int m = 0; m < deviceCaps; m++)
					{
						int num7 = (l * deviceCaps + m) * 3;
						array[num7] = array2[l][(m * 3 + (num2 + 2) % 256) % (deviceCaps * 3)];
						array[num7 + 1] = array2[l][(m * 3 + (num2 + 1) % 256) % (deviceCaps * 3)];
						array[num7 + 2] = array2[l][(m * 3 + num2 % 256) % (deviceCaps * 3)];
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

		// Token: 0x060000E3 RID: 227 RVA: 0x000061BC File Offset: 0x000043BC
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
			string text = "CAZZOO.wav";
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

		// Token: 0x060000E4 RID: 228 RVA: 0x00006380 File Offset: 0x00004580
		public static void ShowEffects()
		{
			Thread thread = new Thread(new ThreadStart(Program.ScreenBlendEffect));
			thread.Start();
			Program.GenerateAndPlayBytebeat();
			thread.Join();
		}

		// Token: 0x060000E5 RID: 229
		[DllImport("gdi32.dll")]
		private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

		// Token: 0x060000E6 RID: 230
		[DllImport("gdi32.dll")]
		private static extern bool SetDIBits(IntPtr hdc, IntPtr hbm, uint start, uint cLines, IntPtr lpBits, ref Program.BitmapInfo lpbmi, uint colorUse);

		// Token: 0x04000048 RID: 72
		private const int SRCCOPY = 13369376;

		// Token: 0x04000049 RID: 73
		private const int HORZRES = 8;

		// Token: 0x0400004A RID: 74
		private const int VERTRES = 10;

		// Token: 0x0200003D RID: 61
		public struct BitmapInfo
		{
			// Token: 0x040000E0 RID: 224
			public Program.BitmapInfoHeader bmiHeader;

			// Token: 0x040000E1 RID: 225
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
			public uint[] bmiColors;
		}

		// Token: 0x0200003E RID: 62
		public struct BitmapInfoHeader
		{
			// Token: 0x040000E2 RID: 226
			public int biSize;

			// Token: 0x040000E3 RID: 227
			public int biWidth;

			// Token: 0x040000E4 RID: 228
			public int biHeight;

			// Token: 0x040000E5 RID: 229
			public short biPlanes;

			// Token: 0x040000E6 RID: 230
			public short biBitCount;

			// Token: 0x040000E7 RID: 231
			public int biCompression;

			// Token: 0x040000E8 RID: 232
			public int biSizeImage;

			// Token: 0x040000E9 RID: 233
			public int biXPelsPerMeter;

			// Token: 0x040000EA RID: 234
			public int biYPelsPerMeter;

			// Token: 0x040000EB RID: 235
			public int biClrUsed;

			// Token: 0x040000EC RID: 236
			public int biClrImportant;
		}
	}
}
