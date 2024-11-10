using System;
using System.Diagnostics;
using System.Text;

namespace PdfSharp.Pdf.Content.Objects
{
	// Token: 0x02000148 RID: 328
	[DebuggerDisplay("({Value})")]
	public class CString : CObject
	{
		// Token: 0x06000B19 RID: 2841 RVA: 0x0002B0B5 File Offset: 0x000292B5
		public new CString Clone()
		{
			return (CString)this.Copy();
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x0002B0C4 File Offset: 0x000292C4
		protected override CObject Copy()
		{
			return base.Copy();
		}

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x0002B0D9 File Offset: 0x000292D9
		// (set) Token: 0x06000B1C RID: 2844 RVA: 0x0002B0E1 File Offset: 0x000292E1
		public string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06000B1D RID: 2845 RVA: 0x0002B0EA File Offset: 0x000292EA
		// (set) Token: 0x06000B1E RID: 2846 RVA: 0x0002B0F2 File Offset: 0x000292F2
		public CStringType CStringType
		{
			get
			{
				return this._cStringType;
			}
			set
			{
				this._cStringType = value;
			}
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0002B0FC File Offset: 0x000292FC
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			switch (this.CStringType)
			{
			case CStringType.String:
			{
				stringBuilder.Append("(");
				int length = this._value.Length;
				int i = 0;
				while (i < length)
				{
					char c = this._value[i];
					char c2 = c;
					switch (c2)
					{
					case '\b':
						stringBuilder.Append("\\b");
						break;
					case '\t':
						stringBuilder.Append("\\t");
						break;
					case '\n':
						stringBuilder.Append("\\n");
						break;
					case '\v':
						goto IL_108;
					case '\f':
						stringBuilder.Append("\\f");
						break;
					case '\r':
						stringBuilder.Append("\\r");
						break;
					default:
						switch (c2)
						{
						case '(':
							stringBuilder.Append("\\(");
							break;
						case ')':
							stringBuilder.Append("\\)");
							break;
						default:
							if (c2 != '\\')
							{
								goto IL_108;
							}
							stringBuilder.Append("\\\\");
							break;
						}
						break;
					}
					IL_110:
					i++;
					continue;
					IL_108:
					stringBuilder.Append(c);
					goto IL_110;
				}
				stringBuilder.Append(')');
				break;
			}
			case CStringType.HexString:
				throw new NotImplementedException();
			case CStringType.UnicodeString:
				throw new NotImplementedException();
			case CStringType.UnicodeHexString:
				throw new NotImplementedException();
			case CStringType.Dictionary:
				stringBuilder.Append(this._value);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0002B25C File Offset: 0x0002945C
		internal override void WriteObject(ContentWriter writer)
		{
			writer.WriteRaw(this.ToString());
		}

		// Token: 0x04000639 RID: 1593
		private string _value;

		// Token: 0x0400063A RID: 1594
		private CStringType _cStringType;
	}
}
