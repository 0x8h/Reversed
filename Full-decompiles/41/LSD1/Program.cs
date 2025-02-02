using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace LSD1
{
	// Token: 0x0200000C RID: 12
	internal class Program
	{
		// Token: 0x06000058 RID: 88
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hwnd);

		// Token: 0x06000059 RID: 89
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		// Token: 0x0600005A RID: 90
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int width, int height, IntPtr hdcSrc, int xSrc, int ySrc, int rop);

		// Token: 0x0600005B RID: 91
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x0600005C RID: 92
		[DllImport("gdi32.dll")]
		private static extern bool PatBlt(IntPtr hdc, int x, int y, int w, int h, uint rop);

		// Token: 0x0600005D RID: 93
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateSolidBrush(uint crColor);

		// Token: 0x0600005E RID: 94
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		// Token: 0x0600005F RID: 95
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x06000060 RID: 96
		[DllImport("gdi32.dll")]
		private static extern bool StretchBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSrc, int xSrc, int ySrc, int wSrc, int hSrc, uint rop);

		// Token: 0x06000061 RID: 97 RVA: 0x000036F8 File Offset: 0x000018F8
		public static void ShowEffect()
		{
			Thread thread = new Thread(new ThreadStart(Program.PlayBytebeatSound));
			thread.IsBackground = true;
			thread.Start();
			IntPtr dc = Program.GetDC(IntPtr.Zero);
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			Random random = new Random();
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(5.0);
			while (DateTime.Now - now < timeSpan)
			{
				bool flag = random.Next(8) == 2 || random.Next(6) == 1;
				if (flag)
				{
					IntPtr intPtr = Program.CreateSolidBrush(Program.GenerateLSDColor());
					Program.SelectObject(dc, intPtr);
					Program.PatBlt(dc, 0, 0, systemMetrics, systemMetrics2, 5898313U);
					Program.DeleteObject(intPtr);
				}
				bool flag2 = random.Next(9) == 1;
				if (flag2)
				{
					int num = random.Next(systemMetrics);
					int num2 = random.Next(systemMetrics2);
					int num3 = random.Next(systemMetrics / 10);
					IntPtr intPtr2 = Program.CreateSolidBrush(Program.GenerateLSDColor());
					Program.SelectObject(dc, intPtr2);
					IntPtr intPtr3 = Program.CreateSolidBrush(Program.GenerateLSDColor());
					Program.SelectObject(dc, intPtr3);
					Program.PatBlt(dc, num - num3, num2 - num3, num3 * 2, num3 * 2, 5898313U);
					Program.DeleteObject(intPtr2);
					Program.DeleteObject(intPtr3);
				}
				else
				{
					bool flag3 = random.Next(2) == 0;
					if (flag3)
					{
						int num4 = random.Next(systemMetrics);
						int num5 = random.Next(systemMetrics2);
						Program.StretchBlt(dc, 0, 0, systemMetrics, num4, dc, num4, num5, 1, 1, 5898313U);
					}
				}
				bool flag4 = random.Next(8) == 3;
				if (flag4)
				{
					Program.StretchBlt(dc, random.Next(systemMetrics), random.Next(systemMetrics2), systemMetrics, systemMetrics2, dc, 0, 0, systemMetrics, systemMetrics2, 13369376U);
					Program.StretchBlt(dc, 40, 90, systemMetrics - 5, systemMetrics2 - 90, dc, 0, 0, systemMetrics, systemMetrics2, 15597702U);
					Program.StretchBlt(dc, -20, -10, systemMetrics + 39, systemMetrics2 + 20, dc, 0, 0, systemMetrics, systemMetrics2, 15597702U);
					Program.StretchBlt(dc, 0, 0, systemMetrics, systemMetrics2, dc, random.Next(systemMetrics), random.Next(systemMetrics2), systemMetrics, systemMetrics2, 6684742U);
				}
				Program.BitBlt(dc, systemMetrics / 2, systemMetrics2 / 2, systemMetrics / 2, systemMetrics2 / 2, dc, systemMetrics / 2 - 5, systemMetrics2 / 2 - 5, 13369376);
				Program.BitBlt(dc, -5, -5, systemMetrics / 2, systemMetrics2 / 2, dc, 0, 0, 13369376);
				Thread.Sleep(10);
			}
			thread.Abort();
			Program.ReleaseDC(IntPtr.Zero, dc);
			Console.WriteLine("Effetti grafici e sonori terminati.");
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003994 File Offset: 0x00001B94
		private static uint GenerateLSDColor()
		{
			Random random = new Random();
			int num = random.Next(128, 256);
			int num2 = random.Next(128, 256);
			int num3 = random.Next(128, 256);
			bool flag = random.Next(2) == 0;
			if (flag)
			{
				int num4 = num;
				num = num3;
				num3 = num4;
			}
			bool flag2 = random.Next(3) == 1;
			if (flag2)
			{
				num2 = (num + num3) / 2;
			}
			bool flag3 = random.Next(4) == 2;
			if (flag3)
			{
				num = Math.Min(255, num + 50);
				num3 = Math.Max(0, num3 - 50);
			}
			return (uint)(num | (num2 << 8) | (num3 << 16));
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003A4C File Offset: 0x00001C4C
		private static void PlayBytebeatSound()
		{
			byte[] array = new byte[4410];
			int num = 0;
			for (;;)
			{
				byte b = (byte)((Math.Sin(2764.6015351590181 * (double)num / 44100.0) + 1.0) * 127.0);
				array[num % array.Length] = b;
				num++;
				string text = Path.GetTempFileName().Replace(".tmp", ".wav");
				Program.WriteWavFile(text, array, 44100);
				using (SoundPlayer soundPlayer = new SoundPlayer(text))
				{
					soundPlayer.PlaySync();
				}
				File.Delete(text);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003B0C File Offset: 0x00001D0C
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

		// Token: 0x04000022 RID: 34
		private const int SM_CXSCREEN = 0;

		// Token: 0x04000023 RID: 35
		private const int SM_CYSCREEN = 1;

		// Token: 0x04000024 RID: 36
		private const uint PATINVERT = 5898313U;

		// Token: 0x04000025 RID: 37
		private const uint SRCCOPY = 13369376U;

		// Token: 0x04000026 RID: 38
		private const uint SRCPAINT = 15597702U;

		// Token: 0x04000027 RID: 39
		private const uint SRCINVERT = 6684742U;
	}
}
