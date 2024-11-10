using System;

namespace Clock
{
	// Token: 0x0200004C RID: 76
	public class ReportModule
	{
		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x0005C3D0 File Offset: 0x0005A5D0
		// (set) Token: 0x0600081A RID: 2074 RVA: 0x0005C3D8 File Offset: 0x0005A5D8
		public string Grade
		{
			get
			{
				return this._grade;
			}
			set
			{
				this._grade = value;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600081B RID: 2075 RVA: 0x0005C3E1 File Offset: 0x0005A5E1
		// (set) Token: 0x0600081C RID: 2076 RVA: 0x0005C3E9 File Offset: 0x0005A5E9
		public string Class
		{
			get
			{
				return this._class;
			}
			set
			{
				this._class = value;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600081D RID: 2077 RVA: 0x0005C3F2 File Offset: 0x0005A5F2
		// (set) Token: 0x0600081E RID: 2078 RVA: 0x0005C3FA File Offset: 0x0005A5FA
		public string Number
		{
			get
			{
				return this._number;
			}
			set
			{
				this._number = value;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600081F RID: 2079 RVA: 0x0005C403 File Offset: 0x0005A603
		// (set) Token: 0x06000820 RID: 2080 RVA: 0x0005C40B File Offset: 0x0005A60B
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000821 RID: 2081 RVA: 0x0005C414 File Offset: 0x0005A614
		// (set) Token: 0x06000822 RID: 2082 RVA: 0x0005C41C File Offset: 0x0005A61C
		public string Comment
		{
			get
			{
				return this._comment;
			}
			set
			{
				this._comment = value;
			}
		}

		// Token: 0x040005D7 RID: 1495
		private string _grade = "";

		// Token: 0x040005D8 RID: 1496
		private string _class = "";

		// Token: 0x040005D9 RID: 1497
		private string _number = "";

		// Token: 0x040005DA RID: 1498
		private string _name = "";

		// Token: 0x040005DB RID: 1499
		private string _comment = "";
	}
}
