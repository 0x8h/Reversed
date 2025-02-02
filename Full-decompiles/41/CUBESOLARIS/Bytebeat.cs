using System;
using System.IO;
using System.Media;

namespace CUBESOLARIS
{
	// Token: 0x02000023 RID: 35
	internal class Bytebeat
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00008239 File Offset: 0x00006439
		// (set) Token: 0x06000165 RID: 357 RVA: 0x00008240 File Offset: 0x00006440
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

		// Token: 0x06000166 RID: 358 RVA: 0x00008248 File Offset: 0x00006448
		private static byte[] GenerateBuffer(Func<int, int> formula)
		{
			byte[] array = new byte[160000];
			for (int i = 0; i < 160000; i++)
			{
				array[i] = (byte)(formula(i) & 255);
			}
			return array;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00008290 File Offset: 0x00006490
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

		// Token: 0x06000168 RID: 360 RVA: 0x000083A8 File Offset: 0x000065A8
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

		// Token: 0x06000169 RID: 361 RVA: 0x000083F8 File Offset: 0x000065F8
		public static void PlayBytebeatAudio()
		{
			foreach (Func<int, int> func in Bytebeat.Formulas)
			{
				byte[] array2 = Bytebeat.GenerateBuffer(func);
				Bytebeat.PlayBuffer(array2);
			}
		}

		// Token: 0x04000079 RID: 121
		private const int SampleRate = 8000;

		// Token: 0x0400007A RID: 122
		private const int DurationSeconds = 20;

		// Token: 0x0400007B RID: 123
		private const int BufferSize = 160000;

		// Token: 0x0400007C RID: 124
		private static Func<int, int>[] formulas = new Func<int, int>[]
		{
			(int t) => ((t >> 5) + t % 32) & 127
		};
	}
}
