using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace LST56
{
	// Token: 0x02000005 RID: 5
	internal class Program
	{
		// Token: 0x06000011 RID: 17
		[DllImport("gdi32.dll", SetLastError = true)]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		// Token: 0x06000012 RID: 18
		[DllImport("gdi32.dll", SetLastError = true)]
		public static extern IntPtr CreateDIBSection(IntPtr hdc, [In] ref Program.BITMAPINFO pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

		// Token: 0x06000013 RID: 19
		[DllImport("gdi32.dll", SetLastError = true)]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		// Token: 0x06000014 RID: 20
		[DllImport("gdi32.dll", SetLastError = true)]
		public static extern bool StretchBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSrc, int xSrc, int ySrc, int wSrc, int hSrc, uint rop);

		// Token: 0x06000015 RID: 21
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetDC(IntPtr hwnd);

		// Token: 0x06000016 RID: 22
		[DllImport("user32.dll", SetLastError = true)]
		public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		// Token: 0x06000017 RID: 23
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool DrawIcon(IntPtr hdc, int x, int y, IntPtr hIcon);

		// Token: 0x06000018 RID: 24
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

		// Token: 0x06000019 RID: 25
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr LoadIcon(IntPtr hInstance, int lpIconName);

		// Token: 0x0600001A RID: 26
		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(int nIndex);

		// Token: 0x0600001B RID: 27 RVA: 0x00002410 File Offset: 0x00000610
		public static void ShowEffect()
		{
			Thread thread = new Thread(new ThreadStart(Program.XORFractalFullScreen));
			Thread thread2 = new Thread(new ThreadStart(Program.ShowCubeEffect));
			Thread thread3 = new Thread(new ThreadStart(Bytebeat.PlayBytebeatAudio));
			Thread thread4 = new Thread(new ThreadStart(Program.CauseCrashAfterTimeout));
			thread.Start();
			thread2.Start();
			thread3.Start();
			thread4.Start();
			thread.Join();
			thread2.Join();
			thread3.Join();
			thread4.Join();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000249E File Offset: 0x0000069E
		public static void CauseCrashAfterTimeout()
		{
			Thread.Sleep(20000);
			throw new Exception("Crash intenzionale dopo 20 secondi!");
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000024B8 File Offset: 0x000006B8
		public static void XORFractalFullScreen()
		{
			IntPtr intPtr = Program.GetDC(IntPtr.Zero);
			IntPtr intPtr2 = Program.CreateCompatibleDC(intPtr);
			Program.BITMAPINFO bitmapinfo = new Program.BITMAPINFO
			{
				bmiHeader = new Program.BITMAPINFOHEADER
				{
					biSize = (uint)Marshal.SizeOf(typeof(Program.BITMAPINFOHEADER)),
					biWidth = Program.w,
					biHeight = Program.h,
					biPlanes = 1,
					biBitCount = 32,
					biCompression = 0U
				}
			};
			IntPtr intPtr4;
			IntPtr intPtr3 = Program.CreateDIBSection(intPtr, ref bitmapinfo, 0U, out intPtr4, IntPtr.Zero, 0U);
			Program.SelectObject(intPtr2, intPtr3);
			int num = 0;
			int num2 = 20;
			for (;;)
			{
				for (int i = 0; i < Program.w; i++)
				{
					for (int j = 0; j < Program.h; j++)
					{
						int num3 = j * Program.w + i;
						int num4 = ((i / num2) ^ (j / num2) ^ num) & 255;
						byte b = (byte)((Math.Sin((double)num4 * 0.15 + (double)num * 0.05) + 1.0) * 127.0);
						byte b2 = (byte)((Math.Sin((double)num4 * 0.25 + (double)num * 0.05) + 1.0) * 127.0);
						byte b3 = (byte)((Math.Sin((double)num4 * 0.35 + (double)num * 0.05) + 1.0) * 127.0);
						Marshal.WriteByte(intPtr4, num3 * 4 + 2, b);
						Marshal.WriteByte(intPtr4, num3 * 4 + 1, b2);
						Marshal.WriteByte(intPtr4, num3 * 4, b3);
					}
				}
				num += 5;
				Program.StretchBlt(intPtr, 0, 0, Program.w, Program.h, intPtr2, 0, 0, Program.w, Program.h, 13369376U);
				Thread.Sleep(10);
				Program.RedrawScreen();
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000026DC File Offset: 0x000008DC
		public static void ShowCubeEffect()
		{
			Program.warningIcon = Program.LoadIcon(IntPtr.Zero, 32515);
			Program.dc = Program.GetDC(IntPtr.Zero);
			Program.SphereWithXor(30);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000270C File Offset: 0x0000090C
		private static void SphereWithXor(int duration)
		{
			double num = (double)(Program.w + Program.h) / 10.0;
			double num2 = 0.09;
			double num3 = 0.09;
			double num4 = num / 2.0;
			int num5 = 200;
			double[][] array = new double[num5][];
			Random random = new Random();
			for (int i = 0; i < num5; i++)
			{
				double num6 = random.NextDouble() * 3.1415926535897931 * 2.0;
				double num7 = random.NextDouble() * 3.1415926535897931;
				double num8 = num4 * Math.Sin(num7) * Math.Cos(num6);
				double num9 = num4 * Math.Sin(num7) * Math.Sin(num6);
				double num10 = num4 * Math.Cos(num7);
				array[i] = new double[] { num8, num9, num10 };
			}
			DateTime dateTime = DateTime.Now.AddSeconds((double)duration);
			while (DateTime.Now < dateTime)
			{
				Program.RedrawScreen();
				for (int j = 0; j < num5; j++)
				{
					double[] array2 = array[j];
					double num11 = array2[0] * Math.Cos(num2) - array2[2] * Math.Sin(num2);
					double num12 = array2[0] * Math.Sin(num2) + array2[2] * Math.Cos(num2);
					double num13 = array2[1] * Math.Cos(num3) - num12 * Math.Sin(num3);
					array2[0] = num11;
					array2[1] = num13;
					array2[2] = num12;
				}
				for (int k = 0; k < num5; k++)
				{
					double num14 = array[k][0];
					double num15 = array[k][1];
					double num16 = array[k][2];
					int num17 = (int)(num14 / (num16 / num4 + 2.0) * (double)Program.w / 3.0 + (double)(Program.w / 2));
					int num18 = (int)(num15 / (num16 / num4 + 2.0) * (double)Program.h / 3.0 + (double)(Program.h / 2));
					Program.DrawIcon(Program.dc, num17, num18, Program.warningIcon);
				}
				Thread.Sleep(100);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002995 File Offset: 0x00000B95
		private static void RedrawScreen()
		{
			Program.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
		}

		// Token: 0x0400000A RID: 10
		private const int SRCCOPY = 13369376;

		// Token: 0x0400000B RID: 11
		private const int SM_CXSCREEN = 0;

		// Token: 0x0400000C RID: 12
		private const int SM_CYSCREEN = 1;

		// Token: 0x0400000D RID: 13
		private const int IDI_WARNING = 32515;

		// Token: 0x0400000E RID: 14
		private static IntPtr warningIcon;

		// Token: 0x0400000F RID: 15
		private static IntPtr dc;

		// Token: 0x04000010 RID: 16
		private static readonly int w = Program.GetSystemMetrics(0);

		// Token: 0x04000011 RID: 17
		private static readonly int h = Program.GetSystemMetrics(1);

		// Token: 0x0200002E RID: 46
		public struct BITMAPINFOHEADER
		{
			// Token: 0x0400009E RID: 158
			public uint biSize;

			// Token: 0x0400009F RID: 159
			public int biWidth;

			// Token: 0x040000A0 RID: 160
			public int biHeight;

			// Token: 0x040000A1 RID: 161
			public ushort biPlanes;

			// Token: 0x040000A2 RID: 162
			public ushort biBitCount;

			// Token: 0x040000A3 RID: 163
			public uint biCompression;

			// Token: 0x040000A4 RID: 164
			public uint biSizeImage;

			// Token: 0x040000A5 RID: 165
			public int biXPelsPerMeter;

			// Token: 0x040000A6 RID: 166
			public int biYPelsPerMeter;

			// Token: 0x040000A7 RID: 167
			public uint biClrUsed;

			// Token: 0x040000A8 RID: 168
			public uint biClrImportant;
		}

		// Token: 0x0200002F RID: 47
		public struct BITMAPINFO
		{
			// Token: 0x040000A9 RID: 169
			public Program.BITMAPINFOHEADER bmiHeader;
		}

		// Token: 0x02000030 RID: 48
		public struct RGBQUAD
		{
			// Token: 0x040000AA RID: 170
			public byte rgbBlue;

			// Token: 0x040000AB RID: 171
			public byte rgbGreen;

			// Token: 0x040000AC RID: 172
			public byte rgbRed;

			// Token: 0x040000AD RID: 173
			public byte rgbReserved;
		}
	}
}
