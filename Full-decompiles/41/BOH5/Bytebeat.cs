using System;
using System.IO;
using System.Media;

namespace BOH5
{
	// Token: 0x0200001A RID: 26
	internal class Bytebeat
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000100 RID: 256 RVA: 0x000068AD File Offset: 0x00004AAD
		// (set) Token: 0x06000101 RID: 257 RVA: 0x000068B4 File Offset: 0x00004AB4
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

		// Token: 0x06000102 RID: 258 RVA: 0x000068BC File Offset: 0x00004ABC
		private static byte[] GenerateBuffer(Func<int, int> formula)
		{
			byte[] array = new byte[64000];
			for (int i = 0; i < 64000; i++)
			{
				array[i] = (byte)(formula(i) & 255);
			}
			return array;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00006904 File Offset: 0x00004B04
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

		// Token: 0x06000104 RID: 260 RVA: 0x00006A1C File Offset: 0x00004C1C
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

		// Token: 0x06000105 RID: 261 RVA: 0x00006A6C File Offset: 0x00004C6C
		public static void PlayBytebeatAudio()
		{
			foreach (Func<int, int> func in Bytebeat.Formulas)
			{
				byte[] array2 = Bytebeat.GenerateBuffer(func);
				Bytebeat.PlayBuffer(array2);
			}
		}

		// Token: 0x04000059 RID: 89
		private const int SampleRate = 8000;

		// Token: 0x0400005A RID: 90
		private const int DurationSeconds = 8;

		// Token: 0x0400005B RID: 91
		private const int BufferSize = 64000;

		// Token: 0x0400005C RID: 92
		private static Func<int, int>[] formulas = new Func<int, int>[]
		{
			(int t) => ((t >> 1) & 9) * (t % 5)
		};
	}
}
