using System;
using System.IO;
using System.Media;

namespace LSD2
{
	// Token: 0x02000027 RID: 39
	internal class Bytebeat
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00008F6B File Offset: 0x0000716B
		// (set) Token: 0x06000195 RID: 405 RVA: 0x00008F72 File Offset: 0x00007172
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

		// Token: 0x06000196 RID: 406 RVA: 0x00008F7C File Offset: 0x0000717C
		private static byte[] GenerateBuffer(Func<int, int> formula)
		{
			byte[] array = new byte[40000];
			for (int i = 0; i < 40000; i++)
			{
				array[i] = (byte)(formula(i) & 255);
			}
			return array;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00008FC4 File Offset: 0x000071C4
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

		// Token: 0x06000198 RID: 408 RVA: 0x000090DC File Offset: 0x000072DC
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

		// Token: 0x06000199 RID: 409 RVA: 0x0000912C File Offset: 0x0000732C
		public static void PlayBytebeatAudio()
		{
			foreach (Func<int, int> func in Bytebeat.Formulas)
			{
				byte[] array2 = Bytebeat.GenerateBuffer(func);
				Bytebeat.PlayBuffer(array2);
			}
		}

		// Token: 0x04000086 RID: 134
		private const int SampleRate = 8000;

		// Token: 0x04000087 RID: 135
		private const int DurationSeconds = 5;

		// Token: 0x04000088 RID: 136
		private const int BufferSize = 40000;

		// Token: 0x04000089 RID: 137
		private static Func<int, int>[] formulas = new Func<int, int>[]
		{
			(int t) => (int)((long)t * (long)t >> 18) | (((t * (((t >> 9) | (t >> 3)) & 5)) ^ (t * t >> 12) ^ ((t >> 8) & (t >> 4))) & 255)
		};
	}
}
