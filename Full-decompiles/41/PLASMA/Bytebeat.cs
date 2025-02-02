using System;
using System.IO;
using System.Media;

namespace PLASMA
{
	// Token: 0x02000021 RID: 33
	internal class Bytebeat
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00007AAF File Offset: 0x00005CAF
		// (set) Token: 0x0600014B RID: 331 RVA: 0x00007AB6 File Offset: 0x00005CB6
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

		// Token: 0x0600014C RID: 332 RVA: 0x00007AC0 File Offset: 0x00005CC0
		private static byte[] GenerateBuffer(Func<int, int> formula)
		{
			byte[] array = new byte[45000];
			for (int i = 0; i < 45000; i++)
			{
				array[i] = (byte)(formula(i) & 255);
			}
			return array;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00007B08 File Offset: 0x00005D08
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
					binaryWriter.Write(9000);
					binaryWriter.Write(9000);
					binaryWriter.Write(1);
					binaryWriter.Write(8);
					binaryWriter.Write(new char[] { 'd', 'a', 't', 'a' });
					binaryWriter.Write(buffer.Length);
					binaryWriter.Write(buffer);
				}
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00007C20 File Offset: 0x00005E20
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

		// Token: 0x0600014F RID: 335 RVA: 0x00007C70 File Offset: 0x00005E70
		public static void PlayBytebeatAudio()
		{
			foreach (Func<int, int> func in Bytebeat.Formulas)
			{
				byte[] array2 = Bytebeat.GenerateBuffer(func);
				Bytebeat.PlayBuffer(array2);
			}
		}

		// Token: 0x04000075 RID: 117
		private const int SampleRate = 9000;

		// Token: 0x04000076 RID: 118
		private const int DurationSeconds = 5;

		// Token: 0x04000077 RID: 119
		private const int BufferSize = 45000;

		// Token: 0x04000078 RID: 120
		private static Func<int, int>[] formulas = new Func<int, int>[]
		{
			(int t) => (int)((long)t * (long)t >> 18) | (t >> 14) | (((t >> 4) & 80) * ((t * 2) & 32767))
		};
	}
}
