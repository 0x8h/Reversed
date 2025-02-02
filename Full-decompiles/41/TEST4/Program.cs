using System;
using System.IO;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace TEST4
{
	// Token: 0x02000015 RID: 21
	internal class Program
	{
		// Token: 0x060000C8 RID: 200
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x060000C9 RID: 201
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x060000CA RID: 202
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x060000CB RID: 203
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

		// Token: 0x060000CC RID: 204
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr GetDesktopWindow();

		// Token: 0x060000CD RID: 205
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr GetWindowDC(IntPtr hWnd);

		// Token: 0x060000CE RID: 206
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

		// Token: 0x060000CF RID: 207
		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern bool StretchBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSrc, int xSrc, int ySrc, int wSrc, int hSrc, uint rop);

		// Token: 0x060000D0 RID: 208
		[DllImport("gdi32.dll")]
		private static extern int SetStretchBltMode(IntPtr hdc, int mode);

		// Token: 0x060000D1 RID: 209
		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern bool PatBlt(IntPtr hdc, int x, int y, int width, int height, uint rop);

		// Token: 0x060000D2 RID: 210 RVA: 0x00005828 File Offset: 0x00003A28
		public static void ShowEffects()
		{
			IntPtr dc = Program.GetDC(IntPtr.Zero);
			Program.<>c__DisplayClass21_0 CS$<>8__locals1;
			CS$<>8__locals1.screenWidth = Program.GetSystemMetrics(0);
			CS$<>8__locals1.screenHeight = Program.GetSystemMetrics(1);
			DateTime dateTime = DateTime.Now.AddSeconds(10.0);
			while (DateTime.Now < dateTime)
			{
				int num = Program.random.Next(0, CS$<>8__locals1.screenWidth);
				int num2 = Program.random.Next(0, CS$<>8__locals1.screenHeight);
				int num3 = Program.random.Next(50, 200);
				int num4 = Program.random.Next(50, 200);
				int num5 = Program.random.Next(-10, 10);
				int num6 = Program.random.Next(-10, 10);
				int num7 = Program.random.Next(3);
				bool flag = num7 == 0;
				int num8;
				if (flag)
				{
					num8 = 6684742;
				}
				else
				{
					bool flag2 = num7 == 1;
					if (flag2)
					{
						num8 = 6684774;
					}
					else
					{
						num8 = 6684740;
					}
				}
				Program.BitBlt(dc, num + num5, num2 + num6, num3, num4, dc, num, num2, num8);
				Program.PlayBytebeatSound();
				Thread.Sleep(10);
			}
			DateTime dateTime2 = DateTime.Now;
			while ((DateTime.Now - dateTime2).TotalSeconds < 5.0)
			{
				Program.BitBlt(dc, 0, 0, CS$<>8__locals1.screenWidth, CS$<>8__locals1.screenHeight, dc, -5, -5, 3342344);
				Program.PlayBytebeatSound();
			}
			dateTime2 = DateTime.Now;
			while ((DateTime.Now - dateTime2).TotalSeconds < 8.0)
			{
				Program.PatBlt(dc, 0, 0, CS$<>8__locals1.screenWidth, CS$<>8__locals1.screenHeight, 5898313U);
				Program.PlayBytebeatSound();
				Thread.Sleep(100);
				Program.PatBlt(dc, 0, 0, CS$<>8__locals1.screenWidth, CS$<>8__locals1.screenHeight, 5898313U);
				Program.PlayBytebeatSound();
				Thread.Sleep(100);
			}
			int num9 = 1;
			int num10 = 1;
			double num11 = 0.0;
			int num12 = 1;
			int num13 = 100;
			dateTime2 = DateTime.Now;
			while ((DateTime.Now - dateTime2).TotalSeconds < 10.0)
			{
				Program.BitBlt(dc, 0, 0, CS$<>8__locals1.screenWidth, CS$<>8__locals1.screenHeight, dc, num9, num10, 13369376);
				num9 = (int)Math.Ceiling(Math.Sin(num11) * (double)num12 * 60.0);
				num10 = (int)Math.Ceiling(Math.Cos(num11) * (double)num12 * 60.0);
				num11 += (double)num13 / 100.0;
				bool flag3 = num11 > 3.1415926535897931;
				if (flag3)
				{
					num11 = -3.1415926535897931;
				}
				Program.PlayBytebeatSound();
			}
			IntPtr desktopWindow = Program.GetDesktopWindow();
			IntPtr windowDC = Program.GetWindowDC(desktopWindow);
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(0.2);
			while (DateTime.Now - now < timeSpan)
			{
				Program.<ShowEffects>g__ZoomVertical|21_1(ref CS$<>8__locals1);
				Program.<ShowEffects>g__Redraw|21_0();
				Program.<ShowEffects>g__ZoomHorizontal|21_2(ref CS$<>8__locals1);
				Program.<ShowEffects>g__Redraw|21_0();
			}
			Program.ReleaseDC(IntPtr.Zero, dc);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00005B80 File Offset: 0x00003D80
		private static void PlayBytebeatSound()
		{
			byte[] array = new byte[2646];
			for (int i = 0; i < array.Length; i++)
			{
				int num = i;
				byte b = (byte)(((num >> 10) & 3) * num);
				array[i] = b;
			}
			string text = Path.GetTempFileName().Replace(".tmp", ".wav");
			Program.WriteWavFile(text, array, 44100);
			using (SoundPlayer soundPlayer = new SoundPlayer(text))
			{
				soundPlayer.PlaySync();
			}
			File.Delete(text);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00005C1C File Offset: 0x00003E1C
		private static void WriteWavFile(string filePath, byte[] soundBuffer, int sampleRate)
		{
			using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
				{
					binaryWriter.Write("RIFF".ToCharArray());
					binaryWriter.Write(36 + soundBuffer.Length);
					binaryWriter.Write("WAVE".ToCharArray());
					binaryWriter.Write("fmt ".ToCharArray());
					binaryWriter.Write(16);
					binaryWriter.Write(1);
					binaryWriter.Write(1);
					binaryWriter.Write(sampleRate);
					binaryWriter.Write(sampleRate);
					binaryWriter.Write(1);
					binaryWriter.Write(8);
					binaryWriter.Write("data".ToCharArray());
					binaryWriter.Write(soundBuffer.Length);
					binaryWriter.Write(soundBuffer);
				}
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00005D25 File Offset: 0x00003F25
		[CompilerGenerated]
		internal static void <ShowEffects>g__Redraw|21_0()
		{
			Program.RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 133U);
			Program.PlayBytebeatSound();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00005D48 File Offset: 0x00003F48
		[CompilerGenerated]
		internal static void <ShowEffects>g__ZoomVertical|21_1(ref Program.<>c__DisplayClass21_0 A_0)
		{
			IntPtr windowDC = Program.GetWindowDC(IntPtr.Zero);
			for (int i = 0; i < 15; i++)
			{
				Program.SetStretchBltMode(windowDC, 4);
				Program.StretchBlt(windowDC, 0, -20, A_0.screenWidth + 20, A_0.screenHeight, windowDC, 0, 0, A_0.screenWidth, A_0.screenHeight, 6684742U);
				Program.StretchBlt(windowDC, 0, -20, A_0.screenWidth + 20, A_0.screenHeight, windowDC, 0, 0, A_0.screenWidth, A_0.screenHeight, 13369376U);
			}
			Program.ReleaseDC(IntPtr.Zero, windowDC);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00005DE4 File Offset: 0x00003FE4
		[CompilerGenerated]
		internal static void <ShowEffects>g__ZoomHorizontal|21_2(ref Program.<>c__DisplayClass21_0 A_0)
		{
			IntPtr windowDC = Program.GetWindowDC(IntPtr.Zero);
			for (int i = 0; i < 15; i++)
			{
				Program.SetStretchBltMode(windowDC, 4);
				Program.StretchBlt(windowDC, -10, 0, A_0.screenWidth, A_0.screenHeight + 90, windowDC, 0, 0, A_0.screenWidth, A_0.screenHeight, 6684742U);
				Program.StretchBlt(windowDC, -10, 0, A_0.screenWidth, A_0.screenHeight + 90, windowDC, 0, 0, A_0.screenWidth, A_0.screenHeight, 13369376U);
			}
			Program.ReleaseDC(IntPtr.Zero, windowDC);
		}

		// Token: 0x0400003D RID: 61
		private const int SRCCOPY = 13369376;

		// Token: 0x0400003E RID: 62
		private const int NOTSRCCOPY = 3342344;

		// Token: 0x0400003F RID: 63
		private const int DARK_RED_ROP = 6684742;

		// Token: 0x04000040 RID: 64
		private const int GREEN_ROP = 6684774;

		// Token: 0x04000041 RID: 65
		private const int BLUE_ROP = 6684740;

		// Token: 0x04000042 RID: 66
		private const int SM_CXSCREEN = 0;

		// Token: 0x04000043 RID: 67
		private const int SM_CYSCREEN = 1;

		// Token: 0x04000044 RID: 68
		private const uint RDW_ERASE = 4U;

		// Token: 0x04000045 RID: 69
		private const uint RDW_INVALIDATE = 1U;

		// Token: 0x04000046 RID: 70
		private const uint RDW_ALLCHILDREN = 128U;

		// Token: 0x04000047 RID: 71
		private static Random random = new Random();
	}
}
