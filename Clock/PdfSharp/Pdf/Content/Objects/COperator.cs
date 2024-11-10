using System;
using System.Diagnostics;

namespace PdfSharp.Pdf.Content.Objects
{
	// Token: 0x0200014B RID: 331
	[DebuggerDisplay("({Name}, operands={Operands.Count})")]
	public class COperator : CObject
	{
		// Token: 0x06000B2F RID: 2863 RVA: 0x0002B36E File Offset: 0x0002956E
		protected COperator()
		{
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0002B376 File Offset: 0x00029576
		internal COperator(OpCode opcode)
		{
			this._opcode = opcode;
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0002B385 File Offset: 0x00029585
		public new COperator Clone()
		{
			return (COperator)this.Copy();
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0002B394 File Offset: 0x00029594
		protected override CObject Copy()
		{
			return base.Copy();
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06000B33 RID: 2867 RVA: 0x0002B3A9 File Offset: 0x000295A9
		public virtual string Name
		{
			get
			{
				return this._opcode.Name;
			}
		}

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06000B34 RID: 2868 RVA: 0x0002B3B8 File Offset: 0x000295B8
		public CSequence Operands
		{
			get
			{
				CSequence csequence;
				if ((csequence = this._seqence) == null)
				{
					csequence = (this._seqence = new CSequence());
				}
				return csequence;
			}
		}

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000B35 RID: 2869 RVA: 0x0002B3DD File Offset: 0x000295DD
		public OpCode OpCode
		{
			get
			{
				return this._opcode;
			}
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x0002B3E5 File Offset: 0x000295E5
		public override string ToString()
		{
			if (this._opcode.OpCodeName == OpCodeName.Dictionary)
			{
				return " ";
			}
			return this.Name;
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0002B400 File Offset: 0x00029600
		internal override void WriteObject(ContentWriter writer)
		{
			int num = ((this._seqence != null) ? this._seqence.Count : 0);
			for (int i = 0; i < num; i++)
			{
				this._seqence[i].WriteObject(writer);
			}
			writer.WriteLineRaw(this.ToString());
		}

		// Token: 0x0400063C RID: 1596
		private CSequence _seqence;

		// Token: 0x0400063D RID: 1597
		private readonly OpCode _opcode;
	}
}
