using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace GDI
{
	// Token: 0x02000010 RID: 16
	internal class Program
	{
		// Token: 0x0600008D RID: 141
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x0600008E RID: 142
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x0600008F RID: 143
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, int rop);

		// Token: 0x06000090 RID: 144 RVA: 0x000046E1 File Offset: 0x000028E1
		private static void Sleep(int milliseconds)
		{
			Thread.Sleep(milliseconds);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000046EC File Offset: 0x000028EC
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
				int num3 = random.Next(num2 - 50, num2 + 50);
				int num4 = random.Next(0, 100);
				int num5 = Program.DistortedColor(random);
				Program.BitBlt(dc, num, num2, 700, 700, dc, num4 % 91 + num - 10, num3, num5);
				Program.PlayBytebeatSound();
				Program.Sleep(10);
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000047C0 File Offset: 0x000029C0
		private static int DistortedColor(Random random)
		{
			int num = random.Next(0, 256);
			int num2 = random.Next(0, 256);
			int num3 = random.Next(0, 256);
			return (num << 16) | (num2 << 8) | num3;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004804 File Offset: 0x00002A04
		private static void PlayBytebeatSound()
		{
			byte[] array = new byte[4410];
			for (int i = 0; i < array.Length; i++)
			{
				int num = i;
				byte b = (byte)((num * num >> 11) ^ (num >> 7));
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

		// Token: 0x06000094 RID: 148 RVA: 0x000048A4 File Offset: 0x00002AA4
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
