using System;
using System.Diagnostics;

namespace PdfSharp.Pdf.Content.Objects
{
	// Token: 0x02000149 RID: 329
	[DebuggerDisplay("({Name})")]
	public class CName : CObject
	{
		// Token: 0x06000B22 RID: 2850 RVA: 0x0002B272 File Offset: 0x00029472
		public CName()
		{
			this._name = "/";
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0002B285 File Offset: 0x00029485
		public CName(string name)
		{
			this.Name = name;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0002B294 File Offset: 0x00029494
		public new CName Clone()
		{
			return (CName)this.Copy();
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0002B2A4 File Offset: 0x000294A4
		protected override CObject Copy()
		{
			return base.Copy();
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x06000B26 RID: 2854 RVA: 0x0002B2B9 File Offset: 0x000294B9
		// (set) Token: 0x06000B27 RID: 2855 RVA: 0x0002B2C1 File Offset: 0x000294C1
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (string.IsNullOrEmpty(this._name))
				{
					throw new ArgumentNullException("name");
				}
				if (this._name[0] != '/')
				{
					throw new ArgumentException(PSSR.NameMustStartWithSlash);
				}
				this._name = value;
			}
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0002B2FD File Offset: 0x000294FD
		public override string ToString()
		{
			return this._name;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0002B305 File Offset: 0x00029505
		internal override void WriteObject(ContentWriter writer)
		{
			writer.WriteRaw(this.ToString() + " ");
		}

		// Token: 0x0400063B RID: 1595
		private string _name;
	}
}
