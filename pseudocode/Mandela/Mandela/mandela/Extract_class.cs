using System;
using System.IO;
using System.Reflection;

namespace mandela
{
	// Token: 0x02000004 RID: 4
	public class Extract_class
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000033A4 File Offset: 0x000015A4
		public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
		{
			using (Stream manifestResourceStream = Assembly.GetCallingAssembly().GetManifestResourceStream(nameSpace + "." + ((!(internalFilePath == "")) ? (internalFilePath + ".") : "") + resourceName))
			{
				using (BinaryReader binaryReader = new BinaryReader(manifestResourceStream))
				{
					using (FileStream fileStream = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
					{
						using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
						{
							binaryWriter.Write(binaryReader.ReadBytes((int)manifestResourceStream.Length));
						}
					}
				}
			}
		}
	}
}
