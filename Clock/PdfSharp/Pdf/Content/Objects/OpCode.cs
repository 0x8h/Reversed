using System;

namespace PdfSharp.Pdf.Content.Objects
{
	// Token: 0x0200014E RID: 334
	public sealed class OpCode
	{
		// Token: 0x06000B38 RID: 2872 RVA: 0x0002B44E File Offset: 0x0002964E
		internal OpCode(string name, OpCodeName opcodeName, int operands, string postscript, OpCodeFlags flags, string description)
		{
			this.Name = name;
			this.OpCodeName = opcodeName;
			this.Operands = operands;
			this.Postscript = postscript;
			this.Flags = flags;
			this.Description = description;
		}

		// Token: 0x0400068C RID: 1676
		public readonly string Name;

		// Token: 0x0400068D RID: 1677
		public readonly OpCodeName OpCodeName;

		// Token: 0x0400068E RID: 1678
		public readonly int Operands;

		// Token: 0x0400068F RID: 1679
		public readonly OpCodeFlags Flags;

		// Token: 0x04000690 RID: 1680
		public readonly string Postscript;

		// Token: 0x04000691 RID: 1681
		public readonly string Description;
	}
}
