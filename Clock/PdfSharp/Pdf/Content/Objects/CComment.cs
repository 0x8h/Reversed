using System;
using System.Diagnostics;

namespace PdfSharp.Pdf.Content.Objects
{
	// Token: 0x02000142 RID: 322
	[DebuggerDisplay("({Text})")]
	public class CComment : CObject
	{
		// Token: 0x06000AE0 RID: 2784 RVA: 0x0002ACD1 File Offset: 0x00028ED1
		public new CComment Clone()
		{
			return (CComment)this.Copy();
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0002ACE0 File Offset: 0x00028EE0
		protected override CObject Copy()
		{
			return base.Copy();
		}

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06000AE2 RID: 2786 RVA: 0x0002ACF5 File Offset: 0x00028EF5
		// (set) Token: 0x06000AE3 RID: 2787 RVA: 0x0002ACFD File Offset: 0x00028EFD
		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				this._text = value;
			}
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x0002AD06 File Offset: 0x00028F06
		public override string ToString()
		{
			return "% " + this._text;
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0002AD18 File Offset: 0x00028F18
		internal override void WriteObject(ContentWriter writer)
		{
			writer.WriteLineRaw(this.ToString());
		}

		// Token: 0x0400062F RID: 1583
		private string _text;
	}
}
