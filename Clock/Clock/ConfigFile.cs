using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Clock
{
	// Token: 0x0200001C RID: 28
	public class ConfigFile
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000219 RID: 537 RVA: 0x0001FC48 File Offset: 0x0001DE48
		// (set) Token: 0x0600021A RID: 538 RVA: 0x0001FC50 File Offset: 0x0001DE50
		public ConfigFile.SaveData Data { get; private set; } = new ConfigFile.SaveData();

		// Token: 0x0600021B RID: 539 RVA: 0x0001FC59 File Offset: 0x0001DE59
		private ConfigFile()
		{
			if (File.Exists(ConfigFile.FILE_PATH))
			{
				this.Open();
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0001FC80 File Offset: 0x0001DE80
		private void Open()
		{
			using (StreamReader streamReader = new StreamReader(ConfigFile.FILE_PATH, Encoding.GetEncoding("shift_jis")))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(ConfigFile.SaveData));
				this.Data = (ConfigFile.SaveData)xmlSerializer.Deserialize(streamReader);
				NetworkConnectionWindow.Port = this.Data.NetworkPortNumber;
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0001FCF0 File Offset: 0x0001DEF0
		public void Save()
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ConfigFile.SaveData));
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(ConfigFile.FILE_PATH, false, Encoding.GetEncoding("shift_jis")))
				{
					xmlSerializer.Serialize(streamWriter, this.Data);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		// Token: 0x04000217 RID: 535
		private static readonly string FILE_PATH = "config.xml";

		// Token: 0x04000218 RID: 536
		public static ConfigFile Instance = new ConfigFile();

		// Token: 0x0200008C RID: 140
		public class SaveData
		{
			// Token: 0x0400080A RID: 2058
			public bool FlowchartUsbInOut = true;

			// Token: 0x0400080B RID: 2059
			public bool FlowchartTextProgram = true;

			// Token: 0x0400080C RID: 2060
			public bool FlowchartGrid = true;

			// Token: 0x0400080D RID: 2061
			public bool FlowchartParameter = true;

			// Token: 0x0400080E RID: 2062
			public bool FlowchartDisplayControl = true;

			// Token: 0x0400080F RID: 2063
			public int NetworkLevel;

			// Token: 0x04000810 RID: 2064
			public bool NetworkUsbInOut = true;

			// Token: 0x04000811 RID: 2065
			public bool NetworkErrorStop = true;

			// Token: 0x04000812 RID: 2066
			public bool NetworkGrid = true;

			// Token: 0x04000813 RID: 2067
			public bool NetworkParameter = true;

			// Token: 0x04000814 RID: 2068
			public bool NetworkInformation = true;

			// Token: 0x04000815 RID: 2069
			public bool NetworkDisplayControl = true;

			// Token: 0x04000816 RID: 2070
			public bool NetworkServerDataShare = true;

			// Token: 0x04000817 RID: 2071
			public int NetworkPortNumber = NetworkConnectionWindow.Port;
		}
	}
}
