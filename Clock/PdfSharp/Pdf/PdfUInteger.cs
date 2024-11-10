using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001BB RID: 443
	[DebuggerDisplay("({Value})")]
	public sealed class PdfUInteger : PdfNumber, IConvertible
	{
		// Token: 0x06000EA6 RID: 3750 RVA: 0x000397E8 File Offset: 0x000379E8
		public PdfUInteger()
		{
		}

		// Token: 0x06000EA7 RID: 3751 RVA: 0x000397F0 File Offset: 0x000379F0
		public PdfUInteger(uint value)
		{
			this._value = value;
		}

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x000397FF File Offset: 0x000379FF
		public uint Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x00039808 File Offset: 0x00037A08
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x06000EAA RID: 3754 RVA: 0x00039828 File Offset: 0x00037A28
		internal override void WriteObject(PdfWriter writer)
		{
			writer.Write(this);
		}

		// Token: 0x06000EAB RID: 3755 RVA: 0x00039831 File Offset: 0x00037A31
		public ulong ToUInt64(IFormatProvider provider)
		{
			return Convert.ToUInt64(this._value);
		}

		// Token: 0x06000EAC RID: 3756 RVA: 0x0003983E File Offset: 0x00037A3E
		public sbyte ToSByte(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x00039845 File Offset: 0x00037A45
		public double ToDouble(IFormatProvider provider)
		{
			return this._value;
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x00039850 File Offset: 0x00037A50
		public DateTime ToDateTime(IFormatProvider provider)
		{
			return default(DateTime);
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x00039866 File Offset: 0x00037A66
		public float ToSingle(IFormatProvider provider)
		{
			return this._value;
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x00039870 File Offset: 0x00037A70
		public bool ToBoolean(IFormatProvider provider)
		{
			return Convert.ToBoolean(this._value);
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x0003987D File Offset: 0x00037A7D
		public int ToInt32(IFormatProvider provider)
		{
			return Convert.ToInt32(this._value);
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x0003988A File Offset: 0x00037A8A
		public ushort ToUInt16(IFormatProvider provider)
		{
			return Convert.ToUInt16(this._value);
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x00039897 File Offset: 0x00037A97
		public short ToInt16(IFormatProvider provider)
		{
			return Convert.ToInt16(this._value);
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x000398A4 File Offset: 0x00037AA4
		string IConvertible.ToString(IFormatProvider provider)
		{
			return this._value.ToString(provider);
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x000398C0 File Offset: 0x00037AC0
		public byte ToByte(IFormatProvider provider)
		{
			return Convert.ToByte(this._value);
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x000398CD File Offset: 0x00037ACD
		public char ToChar(IFormatProvider provider)
		{
			return Convert.ToChar(this._value);
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x000398DA File Offset: 0x00037ADA
		public long ToInt64(IFormatProvider provider)
		{
			return (long)((ulong)this._value);
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x000398E3 File Offset: 0x00037AE3
		public TypeCode GetTypeCode()
		{
			return TypeCode.Int32;
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x000398E7 File Offset: 0x00037AE7
		public decimal ToDecimal(IFormatProvider provider)
		{
			return this._value;
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x000398F4 File Offset: 0x00037AF4
		public object ToType(Type conversionType, IFormatProvider provider)
		{
			return null;
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x000398F7 File Offset: 0x00037AF7
		public uint ToUInt32(IFormatProvider provider)
		{
			return Convert.ToUInt32(this._value);
		}

		// Token: 0x040008FA RID: 2298
		private readonly uint _value;
	}
}
