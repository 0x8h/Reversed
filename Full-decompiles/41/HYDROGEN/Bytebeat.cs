using System;
using System.IO;
using System.Media;

namespace HYDROGEN
{
	// Token: 0x0200001C RID: 28
	internal class Bytebeat
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00006CF4 File Offset: 0x00004EF4
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00006CFB File Offset: 0x00004EFB
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

		// Token: 0x06000115 RID: 277 RVA: 0x00006D04 File Offset: 0x00004F04
		private static byte[] GenerateBuffer(Func<int, int> formula)
		{
			byte[] array = new byte[28467];
			for (int i = 0; i < 28467; i++)
			{
				array[i] = (byte)(formula(i) & 255);
			}
			return array;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00006D4C File Offset: 0x00004F4C
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
					binaryWriter.Write(9489);
					binaryWriter.Write(9489);
					binaryWriter.Write(1);
					binaryWriter.Write(8);
					binaryWriter.Write(new char[] { 'd', 'a', 't', 'a' });
					binaryWriter.Write(buffer.Length);
					binaryWriter.Write(buffer);
				}
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00006E64 File Offset: 0x00005064
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

		// Token: 0x06000118 RID: 280 RVA: 0x00006EB4 File Offset: 0x000050B4
		public static void PlayBytebeatAudio()
		{
			foreach (Func<int, int> func in Bytebeat.Formulas)
			{
				byte[] array2 = Bytebeat.GenerateBuffer(func);
				Bytebeat.PlayBuffer(array2);
			}
		}

		// Token: 0x04000060 RID: 96
		private const int SampleRate = 9489;

		// Token: 0x04000061 RID: 97
		private const int DurationSeconds = 3;

		// Token: 0x04000062 RID: 98
		private const int BufferSize = 28467;

		// Token: 0x04000063 RID: 99
		private static Func<int, int>[] formulas = new Func<int, int>[]
		{
			(int t) => ((t >> 2) | (t >> 8)) + ((t >> 1) & 31),
			(int t) => ((t >> 4) & 13) * (t & 8),
			(int t) => (int)(((long)(t / 4) * (long)((ulong)((3134974581U >> ((t >> 12) & 30)) & 3U)) * (long)((372709 >> ((t >> 16) & 28)) & 3)) & 188L)
		};
	}
}
