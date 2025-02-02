using System;
using System.IO;
using System.Media;

namespace LSDTRIP
{
	// Token: 0x02000007 RID: 7
	internal class Bytebeat
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002D05 File Offset: 0x00000F05
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00002D0C File Offset: 0x00000F0C
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

		// Token: 0x06000032 RID: 50 RVA: 0x00002D14 File Offset: 0x00000F14
		private static byte[] GenerateBuffer(Func<int, int> formula)
		{
			byte[] array = new byte[1900];
			for (int i = 0; i < 1900; i++)
			{
				array[i] = (byte)(formula(i) & 255);
			}
			return array;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002D5C File Offset: 0x00000F5C
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
					binaryWriter.Write(190);
					binaryWriter.Write(190);
					binaryWriter.Write(1);
					binaryWriter.Write(8);
					binaryWriter.Write(new char[] { 'd', 'a', 't', 'a' });
					binaryWriter.Write(buffer.Length);
					binaryWriter.Write(buffer);
				}
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002E74 File Offset: 0x00001074
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

		// Token: 0x06000035 RID: 53 RVA: 0x00002EC4 File Offset: 0x000010C4
		public static void PlayDistortedAudio()
		{
			foreach (Func<int, int> func in Bytebeat.Formulas)
			{
				byte[] array2 = Bytebeat.GenerateBuffer(func);
				Bytebeat.PlayBuffer(array2);
			}
		}

		// Token: 0x04000013 RID: 19
		private const int SampleRate = 190;

		// Token: 0x04000014 RID: 20
		private const int DurationSeconds = 10;

		// Token: 0x04000015 RID: 21
		private const int BufferSize = 1900;

		// Token: 0x04000016 RID: 22
		private static Func<int, int>[] formulas = new Func<int, int>[]
		{
			(int t) => ((t & 65535) ^ (t >> 1)) * ((t >> 8) & 5)
		};
	}
}
