using System;
using System.IO;
using System.Media;

namespace GOCULLINATOR
{
	// Token: 0x02000025 RID: 37
	internal class Bytebeat
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000179 RID: 377 RVA: 0x000087EE File Offset: 0x000069EE
		// (set) Token: 0x0600017A RID: 378 RVA: 0x000087F5 File Offset: 0x000069F5
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

		// Token: 0x0600017B RID: 379 RVA: 0x00008800 File Offset: 0x00006A00
		private static byte[] GenerateBuffer(Func<int, int> formula)
		{
			byte[] array = new byte[16000];
			for (int i = 0; i < 16000; i++)
			{
				array[i] = (byte)(formula(i) & 255);
			}
			return array;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00008848 File Offset: 0x00006A48
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
					binaryWriter.Write(800);
					binaryWriter.Write(800);
					binaryWriter.Write(1);
					binaryWriter.Write(8);
					binaryWriter.Write(new char[] { 'd', 'a', 't', 'a' });
					binaryWriter.Write(buffer.Length);
					binaryWriter.Write(buffer);
				}
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00008960 File Offset: 0x00006B60
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

		// Token: 0x0600017E RID: 382 RVA: 0x000089B0 File Offset: 0x00006BB0
		public static void PlayDistortedAudio()
		{
			foreach (Func<int, int> func in Bytebeat.Formulas)
			{
				byte[] array2 = Bytebeat.GenerateBuffer(func);
				Bytebeat.PlayBuffer(array2);
			}
		}

		// Token: 0x0400007E RID: 126
		private const int SampleRate = 800;

		// Token: 0x0400007F RID: 127
		private const int DurationSeconds = 20;

		// Token: 0x04000080 RID: 128
		private const int BufferSize = 16000;

		// Token: 0x04000081 RID: 129
		private static Func<int, int>[] formulas = new Func<int, int>[]
		{
			(int t) => t * (t >> 1)
		};
	}
}
