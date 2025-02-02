using System;
using System.IO;
using System.Media;

namespace MANDELBROT
{
	// Token: 0x02000009 RID: 9
	internal class Bytebeat
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00003105 File Offset: 0x00001305
		// (set) Token: 0x06000041 RID: 65 RVA: 0x0000310C File Offset: 0x0000130C
		public static Func<int, int>[] Formulas
		{
			get
			{
				return Bytebeat.formulas;
			}
			set
			{
				Bytebeat.formulas = value;
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003114 File Offset: 0x00001314
		private static byte[] GenerateBuffer(Func<int, int> formula)
		{
			byte[] array = new byte[40000];
			for (int i = 0; i < 40000; i++)
			{
				array[i] = (byte)(formula(i) & 255);
			}
			return array;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000315C File Offset: 0x0000135C
		private static void SaveWav(byte[] buffer, string filePath)
		{
			using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
				{
					binaryWriter.Write(new char[] { 'R', 'I', 'F', 'F' });
					binaryWriter.Write(36 + buffer.Length);
					binaryWriter.Write(new char[] { 'W', 'A', 'V', 'E' });
					binaryWriter.Write(new char[] { 'f', 'm', 't', ' ' });
					binaryWriter.Write(16);
					binaryWriter.Write(1);
					binaryWriter.Write(1);
					binaryWriter.Write(8000);
					binaryWriter.Write(8000);
					binaryWriter.Write(1);
					binaryWriter.Write(8);
					binaryWriter.Write(new char[] { 'd', 'a', 't', 'a' });
					binaryWriter.Write(buffer.Length);
					binaryWriter.Write(buffer);
				}
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003274 File Offset: 0x00001474
		private static void PlayBuffer(byte[] buffer)
		{
			string tempFileName = Path.GetTempFileName();
			Bytebeat.SaveWav(buffer, tempFileName);
			using (SoundPlayer soundPlayer = new SoundPlayer(tempFileName))
			{
				soundPlayer.PlaySync();
			}
			File.Delete(tempFileName);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000032C4 File Offset: 0x000014C4
		public static void PlayBytebeatAudio()
		{
			foreach (Func<int, int> func in Bytebeat.Formulas)
			{
				byte[] array2 = Bytebeat.GenerateBuffer(func);
				Bytebeat.PlayBuffer(array2);
			}
		}

		// Token: 0x0400001A RID: 26
		private const int SampleRate = 8000;

		// Token: 0x0400001B RID: 27
		private const int DurationSeconds = 5;

		// Token: 0x0400001C RID: 28
		private const int BufferSize = 40000;

		// Token: 0x0400001D RID: 29
		private static Func<int, int>[] formulas = new Func<int, int>[]
		{
			(int t) => (int)((long)t * (long)t >> 18) | (t >> 2) | (((t & 63) * (t >> 2)) ^ (t % 1))
		};
	}
}
