using System;
using System.IO;
using System.Media;

namespace sierpesky
{
	// Token: 0x0200001E RID: 30
	internal class Bytebeat
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000127 RID: 295 RVA: 0x000071E6 File Offset: 0x000053E6
		// (set) Token: 0x06000128 RID: 296 RVA: 0x000071ED File Offset: 0x000053ED
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

		// Token: 0x06000129 RID: 297 RVA: 0x000071F8 File Offset: 0x000053F8
		private static byte[] GenerateBuffer(Func<int, int> formula)
		{
			byte[] array = new byte[160000];
			for (int i = 0; i < 160000; i++)
			{
				array[i] = (byte)(formula(i) & 255);
			}
			return array;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00007240 File Offset: 0x00005440
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

		// Token: 0x0600012B RID: 299 RVA: 0x00007358 File Offset: 0x00005558
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

		// Token: 0x0600012C RID: 300 RVA: 0x000073A8 File Offset: 0x000055A8
		public static void PlayBytebeatAudio()
		{
			foreach (Func<int, int> func in Bytebeat.Formulas)
			{
				byte[] array2 = Bytebeat.GenerateBuffer(func);
				Bytebeat.PlayBuffer(array2);
			}
		}

		// Token: 0x0400006A RID: 106
		private const int SampleRate = 8000;

		// Token: 0x0400006B RID: 107
		private const int DurationSeconds = 20;

		// Token: 0x0400006C RID: 108
		private const int BufferSize = 160000;

		// Token: 0x0400006D RID: 109
		private static Func<int, int>[] formulas = new Func<int, int>[]
		{
			(int t) => ((t >> 1) & 78) * (t % 26)
		};
	}
}
