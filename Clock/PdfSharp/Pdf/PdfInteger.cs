using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x0200019F RID: 415
	[DebuggerDisplay("({Value})")]
	public sealed class PdfInteger : PdfNumber, IConvertible
	{
		// Token: 0x06000D59 RID: 3417 RVA: 0x00035349 File Offset: 0x00033549
		public PdfInteger()
		{
		}

		// Token: 0x06000D5A RID: 3418 RVA: 0x00035351 File Offset: 0x00033551
		public PdfInteger(int value)
		{
			this._value = value;
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06000D5B RID: 3419 RVA: 0x00035360 File Offset: 0x00033560
		public int Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x00035368 File Offset: 0x00033568
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x00035388 File Offset: 0x00033588
		internal override void WriteObject(PdfWriter writer)
		{
			writer.Write(this);
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x00035391 File Offset: 0x00033591
		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return Convert.ToUInt64(this._value);
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x0003539E File Offset: 0x0003359E
		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x000353A5 File Offset: 0x000335A5
		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return (double)this._value;
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x000353B0 File Offset: 0x000335B0
		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			return default(DateTime);
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x000353C6 File Offset: 0x000335C6
		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return (float)this._value;
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x000353CF File Offset: 0x000335CF
		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return Convert.ToBoolean(this._value);
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x000353DC File Offset: 0x000335DC
		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return this._value;
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x000353E4 File Offset: 0x000335E4
		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return Convert.ToUInt16(this._value);
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x000353F1 File Offset: 0x000335F1
		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return Convert.ToInt16(this._value);
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x00035400 File Offset: 0x00033600
		string IConvertible.ToString(IFormatProvider provider)
		{
			return this._value.ToString(provider);
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x0003541C File Offset: 0x0003361C
		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return Convert.ToByte(this._value);
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x00035429 File Offset: 0x00033629
		char IConvertible.ToChar(IFormatProvider provider)
		{
			return Convert.ToChar(this._value);
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x00035436 File Offset: 0x00033636
		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return (long)this._value;
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x0003543F File Offset: 0x0003363F
		public TypeCode GetTypeCode()
		{
			return TypeCode.Int32;
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x00035443 File Offset: 0x00033643
		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return this._value;
		}

		// Token: 0x06000D6D RID: 3437 RVA: 0x00035450 File Offset: 0x00033650
		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			return null;
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x00035453 File Offset: 0x00033653
		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return Convert.ToUInt32(this._value);
		}

		// Token: 0x04000878 RID: 2168
		private readonly int _value;
	}
}
