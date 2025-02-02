using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace GDI2
{
	// Token: 0x0200000B RID: 11
	internal class Program
	{
		// Token: 0x0600004F RID: 79
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x06000050 RID: 80
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x06000051 RID: 81
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, int rop);

		// Token: 0x06000052 RID: 82 RVA: 0x00003407 File Offset: 0x00001607
		private static void Sleep(int milliseconds)
		{
			Thread.Sleep(milliseconds);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003414 File Offset: 0x00001614
		public static void ShowEffect()
		{
			IntPtr dc = Program.GetDC(IntPtr.Zero);
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(10.0);
			Random random = new Random();
			while (DateTime.Now - now < timeSpan)
			{
				int num = random.Next(0, systemMetrics);
				int num2 = random.Next(0, systemMetrics2);
				int num3 = random.Next(num2 - 400, num2 + 400);
				int num4 = random.Next(0, 400);
				int num5 = Program.DistortedColor(random);
				Program.BitBlt(dc, num, num2, 900, 1200, dc, num4 % 180 + num - 300, num3, num5);
				for (int i = 0; i < 5; i++)
				{
					Program.PlayBytebeatSound();
				}
				Program.Sleep(1);
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003514 File Offset: 0x00001714
		private static int DistortedColor(Random random)
		{
			int num = random.Next(0, 256);
			int num2 = random.Next(0, 256);
			int num3 = random.Next(0, 256);
			return (num << 16) | (num2 << 8) | num3;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003558 File Offset: 0x00001758
		private static void PlayBytebeatSound()
		{
			byte[] array = new byte[4410];
			for (int i = 0; i < array.Length; i++)
			{
				int num = i;
				byte b = (byte)((num * num >> 10) ^ (num >> 7));
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

		// Token: 0x06000056 RID: 86 RVA: 0x000035F8 File Offset: 0x000017F8
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
	}
}
