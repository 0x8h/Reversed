using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace GDI4
{
	// Token: 0x0200000F RID: 15
	internal class Program
	{
		// Token: 0x06000084 RID: 132
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x06000085 RID: 133
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x06000086 RID: 134
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, int rop);

		// Token: 0x06000087 RID: 135 RVA: 0x000043F5 File Offset: 0x000025F5
		private static void Sleep(int milliseconds)
		{
			Thread.Sleep(milliseconds);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004400 File Offset: 0x00002600
		public static void ShowEffect()
		{
			IntPtr dc = Program.GetDC(IntPtr.Zero);
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(20.0);
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

		// Token: 0x06000089 RID: 137 RVA: 0x00004500 File Offset: 0x00002700
		private static int DistortedColor(Random random)
		{
			int num = random.Next(0, 256);
			int num2 = random.Next(0, 256);
			int num3 = random.Next(0, 256);
			return (num << 16) | (num2 << 8) | num3;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00004544 File Offset: 0x00002744
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

		// Token: 0x0600008B RID: 139 RVA: 0x000045E4 File Offset: 0x000027E4
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
