using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace IDK
{
	// Token: 0x02000012 RID: 18
	internal class Program
	{
		// Token: 0x060000A4 RID: 164
		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x060000A5 RID: 165
		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(int nIndex);

		// Token: 0x060000A6 RID: 166
		[DllImport("gdi32.dll")]
		private static extern bool BitBlt(IntPtr hdc, int x, int y, int cx, int cy, IntPtr hdcSrc, int x1, int y1, int rop);

		// Token: 0x060000A7 RID: 167 RVA: 0x00004CBD File Offset: 0x00002EBD
		private static void Sleep(int milliseconds)
		{
			Thread.Sleep(milliseconds);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00004CC8 File Offset: 0x00002EC8
		public static void ShowEffect()
		{
			IntPtr intPtr = Program.GetDC(IntPtr.Zero);
			int systemMetrics = Program.GetSystemMetrics(0);
			int systemMetrics2 = Program.GetSystemMetrics(1);
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = TimeSpan.FromSeconds(20.0);
			Random random = new Random();
			while (DateTime.Now - now < timeSpan)
			{
				intPtr = Program.GetDC(IntPtr.Zero);
				int num = random.Next(0, systemMetrics);
				int num2 = random.Next(0, systemMetrics2);
				int num3 = random.Next(num2 - 10, num2 + 10);
				int num4 = random.Next(0, 100);
				Program.BitBlt(intPtr, num, num2, 700, 700, intPtr, num4 % 91 + num - 10, num3, 15597702);
				Program.PlayBytebeatSound();
				Program.Sleep(10);
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00004DA4 File Offset: 0x00002FA4
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

		// Token: 0x060000AA RID: 170 RVA: 0x00004E44 File Offset: 0x00003044
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
