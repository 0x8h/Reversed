using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Internal;

namespace PdfSharp.Drawing
{
	// Token: 0x02000072 RID: 114
	[DebuggerDisplay("{DebuggerDisplay}")]
	[Serializable]
	public struct XMatrix : IFormattable
	{
		// Token: 0x06000492 RID: 1170 RVA: 0x00013635 File Offset: 0x00011835
		public XMatrix(double m11, double m12, double m21, double m22, double offsetX, double offsetY)
		{
			this._m11 = m11;
			this._m12 = m12;
			this._m21 = m21;
			this._m22 = m22;
			this._offsetX = offsetX;
			this._offsetY = offsetY;
			this._type = XMatrix.XMatrixTypes.Unknown;
			this.DeriveMatrixType();
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x00013671 File Offset: 0x00011871
		public static XMatrix Identity
		{
			get
			{
				return XMatrix.s_identity;
			}
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00013678 File Offset: 0x00011878
		public void SetIdentity()
		{
			this._type = XMatrix.XMatrixTypes.Identity;
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x00013684 File Offset: 0x00011884
		public bool IsIdentity
		{
			get
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					return true;
				}
				if (this._m11 == 1.0 && this._m12 == 0.0 && this._m21 == 0.0 && this._m22 == 1.0 && this._offsetX == 0.0 && this._offsetY == 0.0)
				{
					this._type = XMatrix.XMatrixTypes.Identity;
					return true;
				}
				return false;
			}
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0001370C File Offset: 0x0001190C
		public double[] GetElements()
		{
			if (this._type == XMatrix.XMatrixTypes.Identity)
			{
				double[] array = new double[6];
				array[0] = 1.0;
				array[3] = 1.0;
				return array;
			}
			return new double[] { this._m11, this._m12, this._m21, this._m22, this._offsetX, this._offsetY };
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00013780 File Offset: 0x00011980
		public static XMatrix operator *(XMatrix trans1, XMatrix trans2)
		{
			XMatrix.MatrixHelper.MultiplyMatrix(ref trans1, ref trans2);
			return trans1;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0001378C File Offset: 0x0001198C
		public static XMatrix Multiply(XMatrix trans1, XMatrix trans2)
		{
			XMatrix.MatrixHelper.MultiplyMatrix(ref trans1, ref trans2);
			return trans1;
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00013798 File Offset: 0x00011998
		public void Append(XMatrix matrix)
		{
			this *= matrix;
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x000137AC File Offset: 0x000119AC
		public void Prepend(XMatrix matrix)
		{
			this = matrix * this;
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x000137C0 File Offset: 0x000119C0
		[Obsolete("Use Append.")]
		public void Multiply(XMatrix matrix)
		{
			this.Append(matrix);
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x000137C9 File Offset: 0x000119C9
		[Obsolete("Use Prepend.")]
		public void MultiplyPrepend(XMatrix matrix)
		{
			this.Prepend(matrix);
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x000137D4 File Offset: 0x000119D4
		public void Multiply(XMatrix matrix, XMatrixOrder order)
		{
			if (this._type == XMatrix.XMatrixTypes.Identity)
			{
				this = XMatrix.CreateIdentity();
			}
			double m = this.M11;
			double m2 = this.M12;
			double m3 = this.M21;
			double m4 = this.M22;
			double offsetX = this.OffsetX;
			double offsetY = this.OffsetY;
			if (order == XMatrixOrder.Append)
			{
				this._m11 = m * matrix.M11 + m2 * matrix.M21;
				this._m12 = m * matrix.M12 + m2 * matrix.M22;
				this._m21 = m3 * matrix.M11 + m4 * matrix.M21;
				this._m22 = m3 * matrix.M12 + m4 * matrix.M22;
				this._offsetX = offsetX * matrix.M11 + offsetY * matrix.M21 + matrix.OffsetX;
				this._offsetY = offsetX * matrix.M12 + offsetY * matrix.M22 + matrix.OffsetY;
			}
			else
			{
				this._m11 = m * matrix.M11 + m3 * matrix.M12;
				this._m12 = m2 * matrix.M11 + m4 * matrix.M12;
				this._m21 = m * matrix.M21 + m3 * matrix.M22;
				this._m22 = m2 * matrix.M21 + m4 * matrix.M22;
				this._offsetX = m * matrix.OffsetX + m3 * matrix.OffsetY + offsetX;
				this._offsetY = m2 * matrix.OffsetX + m4 * matrix.OffsetY + offsetY;
			}
			this.DeriveMatrixType();
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00013978 File Offset: 0x00011B78
		[Obsolete("Use TranslateAppend or TranslatePrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
		public void Translate(double offsetX, double offsetY)
		{
			throw new InvalidOperationException("Temporarily out of order.");
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00013984 File Offset: 0x00011B84
		public void TranslateAppend(double offsetX, double offsetY)
		{
			if (this._type == XMatrix.XMatrixTypes.Identity)
			{
				this.SetMatrix(1.0, 0.0, 0.0, 1.0, offsetX, offsetY, XMatrix.XMatrixTypes.Translation);
				return;
			}
			if (this._type == XMatrix.XMatrixTypes.Unknown)
			{
				this._offsetX += offsetX;
				this._offsetY += offsetY;
				return;
			}
			this._offsetX += offsetX;
			this._offsetY += offsetY;
			this._type |= XMatrix.XMatrixTypes.Translation;
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00013A17 File Offset: 0x00011C17
		public void TranslatePrepend(double offsetX, double offsetY)
		{
			this = XMatrix.CreateTranslation(offsetX, offsetY) * this;
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00013A34 File Offset: 0x00011C34
		public void Translate(double offsetX, double offsetY, XMatrixOrder order)
		{
			if (this._type == XMatrix.XMatrixTypes.Identity)
			{
				this = XMatrix.CreateIdentity();
			}
			if (order == XMatrixOrder.Append)
			{
				this._offsetX += offsetX;
				this._offsetY += offsetY;
			}
			else
			{
				this._offsetX += offsetX * this._m11 + offsetY * this._m21;
				this._offsetY += offsetX * this._m12 + offsetY * this._m22;
			}
			this.DeriveMatrixType();
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00013AB8 File Offset: 0x00011CB8
		[Obsolete("Use ScaleAppend or ScalePrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
		public void Scale(double scaleX, double scaleY)
		{
			this = XMatrix.CreateScaling(scaleX, scaleY) * this;
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00013AD2 File Offset: 0x00011CD2
		public void ScaleAppend(double scaleX, double scaleY)
		{
			this *= XMatrix.CreateScaling(scaleX, scaleY);
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00013AEC File Offset: 0x00011CEC
		public void ScalePrepend(double scaleX, double scaleY)
		{
			this = XMatrix.CreateScaling(scaleX, scaleY) * this;
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x00013B08 File Offset: 0x00011D08
		public void Scale(double scaleX, double scaleY, XMatrixOrder order)
		{
			if (this._type == XMatrix.XMatrixTypes.Identity)
			{
				this = XMatrix.CreateIdentity();
			}
			if (order == XMatrixOrder.Append)
			{
				this._m11 *= scaleX;
				this._m12 *= scaleY;
				this._m21 *= scaleX;
				this._m22 *= scaleY;
				this._offsetX *= scaleX;
				this._offsetY *= scaleY;
			}
			else
			{
				this._m11 *= scaleX;
				this._m12 *= scaleX;
				this._m21 *= scaleY;
				this._m22 *= scaleY;
			}
			this.DeriveMatrixType();
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x00013BC0 File Offset: 0x00011DC0
		[Obsolete("Use ScaleAppend or ScalePrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
		public void Scale(double scaleXY)
		{
			throw new InvalidOperationException("Temporarily out of order.");
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x00013BCC File Offset: 0x00011DCC
		public void ScaleAppend(double scaleXY)
		{
			this.Scale(scaleXY, scaleXY, XMatrixOrder.Append);
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00013BD7 File Offset: 0x00011DD7
		public void ScalePrepend(double scaleXY)
		{
			this.Scale(scaleXY, scaleXY, XMatrixOrder.Prepend);
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00013BE2 File Offset: 0x00011DE2
		public void Scale(double scaleXY, XMatrixOrder order)
		{
			this.Scale(scaleXY, scaleXY, order);
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00013BED File Offset: 0x00011DED
		[Obsolete("Use ScaleAtAppend or ScaleAtPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
		public void ScaleAt(double scaleX, double scaleY, double centerX, double centerY)
		{
			throw new InvalidOperationException("Temporarily out of order.");
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00013BF9 File Offset: 0x00011DF9
		public void ScaleAtAppend(double scaleX, double scaleY, double centerX, double centerY)
		{
			this *= XMatrix.CreateScaling(scaleX, scaleY, centerX, centerY);
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00013C16 File Offset: 0x00011E16
		public void ScaleAtPrepend(double scaleX, double scaleY, double centerX, double centerY)
		{
			this = XMatrix.CreateScaling(scaleX, scaleY, centerX, centerY) * this;
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00013C33 File Offset: 0x00011E33
		[Obsolete("Use RotateAppend or RotatePrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
		public void Rotate(double angle)
		{
			throw new InvalidOperationException("Temporarily out of order.");
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00013C3F File Offset: 0x00011E3F
		public void RotateAppend(double angle)
		{
			angle %= 360.0;
			this *= XMatrix.CreateRotationRadians(angle * 0.017453292519943295);
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00013C6F File Offset: 0x00011E6F
		public void RotatePrepend(double angle)
		{
			angle %= 360.0;
			this = XMatrix.CreateRotationRadians(angle * 0.017453292519943295) * this;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00013CA0 File Offset: 0x00011EA0
		public void Rotate(double angle, XMatrixOrder order)
		{
			if (this._type == XMatrix.XMatrixTypes.Identity)
			{
				this = XMatrix.CreateIdentity();
			}
			angle *= 0.017453292519943295;
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			if (order == XMatrixOrder.Append)
			{
				double m = this._m11;
				double m2 = this._m12;
				double m3 = this._m21;
				double m4 = this._m22;
				double offsetX = this._offsetX;
				double offsetY = this._offsetY;
				this._m11 = m * num - m2 * num2;
				this._m12 = m * num2 + m2 * num;
				this._m21 = m3 * num - m4 * num2;
				this._m22 = m3 * num2 + m4 * num;
				this._offsetX = offsetX * num - offsetY * num2;
				this._offsetY = offsetX * num2 + offsetY * num;
			}
			else
			{
				double m5 = this._m11;
				double m6 = this._m12;
				double m7 = this._m21;
				double m8 = this._m22;
				this._m11 = m5 * num + m7 * num2;
				this._m12 = m6 * num + m8 * num2;
				this._m21 = -m5 * num2 + m7 * num;
				this._m22 = -m6 * num2 + m8 * num;
			}
			this.DeriveMatrixType();
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00013DCC File Offset: 0x00011FCC
		[Obsolete("Use RotateAtAppend or RotateAtPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
		public void RotateAt(double angle, double centerX, double centerY)
		{
			throw new InvalidOperationException("Temporarily out of order.");
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00013DD8 File Offset: 0x00011FD8
		public void RotateAtAppend(double angle, double centerX, double centerY)
		{
			angle %= 360.0;
			this *= XMatrix.CreateRotationRadians(angle * 0.017453292519943295, centerX, centerY);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00013E0A File Offset: 0x0001200A
		public void RotateAtPrepend(double angle, double centerX, double centerY)
		{
			angle %= 360.0;
			this = XMatrix.CreateRotationRadians(angle * 0.017453292519943295, centerX, centerY) * this;
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00013E3C File Offset: 0x0001203C
		[Obsolete("Use RotateAtAppend or RotateAtPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
		public void RotateAt(double angle, XPoint point)
		{
			throw new InvalidOperationException("Temporarily out of order.");
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00013E48 File Offset: 0x00012048
		public void RotateAtAppend(double angle, XPoint point)
		{
			this.RotateAt(angle, point, XMatrixOrder.Append);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00013E53 File Offset: 0x00012053
		public void RotateAtPrepend(double angle, XPoint point)
		{
			this.RotateAt(angle, point, XMatrixOrder.Prepend);
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00013E60 File Offset: 0x00012060
		public void RotateAt(double angle, XPoint point, XMatrixOrder order)
		{
			if (order == XMatrixOrder.Append)
			{
				angle %= 360.0;
				this *= XMatrix.CreateRotationRadians(angle * 0.017453292519943295, point.X, point.Y);
			}
			else
			{
				angle %= 360.0;
				this = XMatrix.CreateRotationRadians(angle * 0.017453292519943295, point.X, point.Y) * this;
			}
			this.DeriveMatrixType();
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00013EF1 File Offset: 0x000120F1
		[Obsolete("Use ShearAppend or ShearPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
		public void Shear(double shearX, double shearY)
		{
			throw new InvalidOperationException("Temporarily out of order.");
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00013EFD File Offset: 0x000120FD
		public void ShearAppend(double shearX, double shearY)
		{
			this.Shear(shearX, shearY, XMatrixOrder.Append);
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00013F08 File Offset: 0x00012108
		public void ShearPrepend(double shearX, double shearY)
		{
			this.Shear(shearX, shearY, XMatrixOrder.Prepend);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00013F14 File Offset: 0x00012114
		public void Shear(double shearX, double shearY, XMatrixOrder order)
		{
			if (this._type == XMatrix.XMatrixTypes.Identity)
			{
				this = XMatrix.CreateIdentity();
			}
			double m = this._m11;
			double m2 = this._m12;
			double m3 = this._m21;
			double m4 = this._m22;
			double offsetX = this._offsetX;
			double offsetY = this._offsetY;
			if (order == XMatrixOrder.Append)
			{
				this._m11 += shearX * m2;
				this._m12 += shearY * m;
				this._m21 += shearX * m4;
				this._m22 += shearY * m3;
				this._offsetX += shearX * offsetY;
				this._offsetY += shearY * offsetX;
			}
			else
			{
				this._m11 += shearY * m3;
				this._m12 += shearY * m4;
				this._m21 += shearX * m;
				this._m22 += shearX * m2;
			}
			this.DeriveMatrixType();
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0001400E File Offset: 0x0001220E
		[Obsolete("Use SkewAppend or SkewPrepend explicitly, because in GDI+ and WPF the defaults are contrary.", true)]
		public void Skew(double skewX, double skewY)
		{
			throw new InvalidOperationException("Temporarily out of order.");
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0001401C File Offset: 0x0001221C
		public void SkewAppend(double skewX, double skewY)
		{
			skewX %= 360.0;
			skewY %= 360.0;
			this *= XMatrix.CreateSkewRadians(skewX * 0.017453292519943295, skewY * 0.017453292519943295);
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00014070 File Offset: 0x00012270
		public void SkewPrepend(double skewX, double skewY)
		{
			skewX %= 360.0;
			skewY %= 360.0;
			this = XMatrix.CreateSkewRadians(skewX * 0.017453292519943295, skewY * 0.017453292519943295) * this;
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x000140C4 File Offset: 0x000122C4
		public XPoint Transform(XPoint point)
		{
			double x = point.X;
			double y = point.Y;
			this.MultiplyPoint(ref x, ref y);
			return new XPoint(x, y);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x000140F4 File Offset: 0x000122F4
		public void Transform(XPoint[] points)
		{
			if (points != null)
			{
				int num = points.Length;
				for (int i = 0; i < num; i++)
				{
					double x = points[i].X;
					double y = points[i].Y;
					this.MultiplyPoint(ref x, ref y);
					points[i].X = x;
					points[i].Y = y;
				}
			}
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00014154 File Offset: 0x00012354
		public void TransformPoints(XPoint[] points)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points");
			}
			if (this.IsIdentity)
			{
				return;
			}
			int num = points.Length;
			for (int i = 0; i < num; i++)
			{
				double x = points[i].X;
				double y = points[i].Y;
				points[i].X = x * this._m11 + y * this._m21 + this._offsetX;
				points[i].Y = x * this._m12 + y * this._m22 + this._offsetY;
			}
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x000141EC File Offset: 0x000123EC
		public XVector Transform(XVector vector)
		{
			double x = vector.X;
			double y = vector.Y;
			this.MultiplyVector(ref x, ref y);
			return new XVector(x, y);
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0001421C File Offset: 0x0001241C
		public void Transform(XVector[] vectors)
		{
			if (vectors != null)
			{
				int num = vectors.Length;
				for (int i = 0; i < num; i++)
				{
					double x = vectors[i].X;
					double y = vectors[i].Y;
					this.MultiplyVector(ref x, ref y);
					vectors[i].X = x;
					vectors[i].Y = y;
				}
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x0001427C File Offset: 0x0001247C
		public double Determinant
		{
			get
			{
				switch (this._type)
				{
				case XMatrix.XMatrixTypes.Identity:
				case XMatrix.XMatrixTypes.Translation:
					return 1.0;
				case XMatrix.XMatrixTypes.Scaling:
				case XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling:
					return this._m11 * this._m22;
				default:
					return this._m11 * this._m22 - this._m12 * this._m21;
				}
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x000142DB File Offset: 0x000124DB
		public bool HasInverse
		{
			get
			{
				return !DoubleUtil.IsZero(this.Determinant);
			}
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000142EC File Offset: 0x000124EC
		public void Invert()
		{
			double determinant = this.Determinant;
			if (DoubleUtil.IsZero(determinant))
			{
				throw new InvalidOperationException("NotInvertible");
			}
			switch (this._type)
			{
			case XMatrix.XMatrixTypes.Identity:
				break;
			case XMatrix.XMatrixTypes.Translation:
				this._offsetX = -this._offsetX;
				this._offsetY = -this._offsetY;
				return;
			case XMatrix.XMatrixTypes.Scaling:
				this._m11 = 1.0 / this._m11;
				this._m22 = 1.0 / this._m22;
				return;
			case XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling:
				this._m11 = 1.0 / this._m11;
				this._m22 = 1.0 / this._m22;
				this._offsetX = -this._offsetX * this._m11;
				this._offsetY = -this._offsetY * this._m22;
				return;
			default:
			{
				double num = 1.0 / determinant;
				this.SetMatrix(this._m22 * num, -this._m12 * num, -this._m21 * num, this._m11 * num, (this._m21 * this._offsetY - this._offsetX * this._m22) * num, (this._offsetX * this._m12 - this._m11 * this._offsetY) * num, XMatrix.XMatrixTypes.Unknown);
				break;
			}
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x00014441 File Offset: 0x00012641
		// (set) Token: 0x060004C8 RID: 1224 RVA: 0x0001445C File Offset: 0x0001265C
		public double M11
		{
			get
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					return 1.0;
				}
				return this._m11;
			}
			set
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					this.SetMatrix(value, 0.0, 0.0, 1.0, 0.0, 0.0, XMatrix.XMatrixTypes.Scaling);
					return;
				}
				this._m11 = value;
				if (this._type != XMatrix.XMatrixTypes.Unknown)
				{
					this._type |= XMatrix.XMatrixTypes.Scaling;
				}
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x000144C5 File Offset: 0x000126C5
		// (set) Token: 0x060004CA RID: 1226 RVA: 0x000144E0 File Offset: 0x000126E0
		public double M12
		{
			get
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					return 0.0;
				}
				return this._m12;
			}
			set
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					this.SetMatrix(1.0, value, 0.0, 1.0, 0.0, 0.0, XMatrix.XMatrixTypes.Unknown);
					return;
				}
				this._m12 = value;
				this._type = XMatrix.XMatrixTypes.Unknown;
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x00014539 File Offset: 0x00012739
		// (set) Token: 0x060004CC RID: 1228 RVA: 0x00014554 File Offset: 0x00012754
		public double M21
		{
			get
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					return 0.0;
				}
				return this._m21;
			}
			set
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					this.SetMatrix(1.0, 0.0, value, 1.0, 0.0, 0.0, XMatrix.XMatrixTypes.Unknown);
					return;
				}
				this._m21 = value;
				this._type = XMatrix.XMatrixTypes.Unknown;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x000145AD File Offset: 0x000127AD
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x000145C8 File Offset: 0x000127C8
		public double M22
		{
			get
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					return 1.0;
				}
				return this._m22;
			}
			set
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					this.SetMatrix(1.0, 0.0, 0.0, value, 0.0, 0.0, XMatrix.XMatrixTypes.Scaling);
					return;
				}
				this._m22 = value;
				if (this._type != XMatrix.XMatrixTypes.Unknown)
				{
					this._type |= XMatrix.XMatrixTypes.Scaling;
				}
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00014631 File Offset: 0x00012831
		// (set) Token: 0x060004D0 RID: 1232 RVA: 0x0001464C File Offset: 0x0001284C
		public double OffsetX
		{
			get
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					return 0.0;
				}
				return this._offsetX;
			}
			set
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					this.SetMatrix(1.0, 0.0, 0.0, 1.0, value, 0.0, XMatrix.XMatrixTypes.Translation);
					return;
				}
				this._offsetX = value;
				if (this._type != XMatrix.XMatrixTypes.Unknown)
				{
					this._type |= XMatrix.XMatrixTypes.Translation;
				}
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x000146B5 File Offset: 0x000128B5
		// (set) Token: 0x060004D2 RID: 1234 RVA: 0x000146D0 File Offset: 0x000128D0
		public double OffsetY
		{
			get
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					return 0.0;
				}
				return this._offsetY;
			}
			set
			{
				if (this._type == XMatrix.XMatrixTypes.Identity)
				{
					this.SetMatrix(1.0, 0.0, 0.0, 1.0, 0.0, value, XMatrix.XMatrixTypes.Translation);
					return;
				}
				this._offsetY = value;
				if (this._type != XMatrix.XMatrixTypes.Unknown)
				{
					this._type |= XMatrix.XMatrixTypes.Translation;
				}
			}
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0001473C File Offset: 0x0001293C
		public static bool operator ==(XMatrix matrix1, XMatrix matrix2)
		{
			if (matrix1.IsDistinguishedIdentity || matrix2.IsDistinguishedIdentity)
			{
				return matrix1.IsIdentity == matrix2.IsIdentity;
			}
			return matrix1.M11 == matrix2.M11 && matrix1.M12 == matrix2.M12 && matrix1.M21 == matrix2.M21 && matrix1.M22 == matrix2.M22 && matrix1.OffsetX == matrix2.OffsetX && matrix1.OffsetY == matrix2.OffsetY;
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x000147CE File Offset: 0x000129CE
		public static bool operator !=(XMatrix matrix1, XMatrix matrix2)
		{
			return !(matrix1 == matrix2);
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x000147DC File Offset: 0x000129DC
		public static bool Equals(XMatrix matrix1, XMatrix matrix2)
		{
			if (matrix1.IsDistinguishedIdentity || matrix2.IsDistinguishedIdentity)
			{
				return matrix1.IsIdentity == matrix2.IsIdentity;
			}
			return matrix1.M11.Equals(matrix2.M11) && matrix1.M12.Equals(matrix2.M12) && matrix1.M21.Equals(matrix2.M21) && matrix1.M22.Equals(matrix2.M22) && matrix1.OffsetX.Equals(matrix2.OffsetX) && matrix1.OffsetY.Equals(matrix2.OffsetY);
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0001489E File Offset: 0x00012A9E
		public override bool Equals(object o)
		{
			return o is XMatrix && XMatrix.Equals(this, (XMatrix)o);
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x000148BB File Offset: 0x00012ABB
		public bool Equals(XMatrix value)
		{
			return XMatrix.Equals(this, value);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x000148CC File Offset: 0x00012ACC
		public override int GetHashCode()
		{
			if (this.IsDistinguishedIdentity)
			{
				return 0;
			}
			return this.M11.GetHashCode() ^ this.M12.GetHashCode() ^ this.M21.GetHashCode() ^ this.M22.GetHashCode() ^ this.OffsetX.GetHashCode() ^ this.OffsetY.GetHashCode();
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00014940 File Offset: 0x00012B40
		public static XMatrix Parse(string source)
		{
			IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
			TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantCulture);
			string text = tokenizerHelper.NextTokenRequired();
			XMatrix xmatrix = ((text == "Identity") ? XMatrix.Identity : new XMatrix(Convert.ToDouble(text, invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture)));
			tokenizerHelper.LastTokenRequired();
			return xmatrix;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x000149C6 File Offset: 0x00012BC6
		public override string ToString()
		{
			return this.ConvertToString(null, null);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x000149D0 File Offset: 0x00012BD0
		public string ToString(IFormatProvider provider)
		{
			return this.ConvertToString(null, provider);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x000149DA File Offset: 0x00012BDA
		string IFormattable.ToString(string format, IFormatProvider provider)
		{
			return this.ConvertToString(format, provider);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x000149E4 File Offset: 0x00012BE4
		internal string ConvertToString(string format, IFormatProvider provider)
		{
			if (this.IsIdentity)
			{
				return "Identity";
			}
			char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
			provider = provider ?? CultureInfo.InvariantCulture;
			return string.Format(provider, string.Concat(new string[]
			{
				"{1:", format, "}{0}{2:", format, "}{0}{3:", format, "}{0}{4:", format, "}{0}{5:", format,
				"}{0}{6:", format, "}"
			}), new object[] { numericListSeparator, this._m11, this._m12, this._m21, this._m22, this._offsetX, this._offsetY });
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00014AE0 File Offset: 0x00012CE0
		internal void MultiplyVector(ref double x, ref double y)
		{
			switch (this._type)
			{
			case XMatrix.XMatrixTypes.Identity:
			case XMatrix.XMatrixTypes.Translation:
				return;
			case XMatrix.XMatrixTypes.Scaling:
			case XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling:
				x *= this._m11;
				y *= this._m22;
				return;
			default:
			{
				double num = y * this._m21;
				double num2 = x * this._m12;
				x *= this._m11;
				x += num;
				y *= this._m22;
				y += num2;
				return;
			}
			}
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00014B5C File Offset: 0x00012D5C
		internal void MultiplyPoint(ref double x, ref double y)
		{
			switch (this._type)
			{
			case XMatrix.XMatrixTypes.Identity:
				return;
			case XMatrix.XMatrixTypes.Translation:
				x += this._offsetX;
				y += this._offsetY;
				return;
			case XMatrix.XMatrixTypes.Scaling:
				x *= this._m11;
				y *= this._m22;
				return;
			case XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling:
				x *= this._m11;
				x += this._offsetX;
				y *= this._m22;
				y += this._offsetY;
				return;
			default:
			{
				double num = y * this._m21 + this._offsetX;
				double num2 = x * this._m12 + this._offsetY;
				x *= this._m11;
				x += num;
				y *= this._m22;
				y += num2;
				return;
			}
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00014C28 File Offset: 0x00012E28
		internal static XMatrix CreateTranslation(double offsetX, double offsetY)
		{
			XMatrix xmatrix = default(XMatrix);
			xmatrix.SetMatrix(1.0, 0.0, 0.0, 1.0, offsetX, offsetY, XMatrix.XMatrixTypes.Translation);
			return xmatrix;
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00014C6C File Offset: 0x00012E6C
		internal static XMatrix CreateRotationRadians(double angle)
		{
			return XMatrix.CreateRotationRadians(angle, 0.0, 0.0);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00014C88 File Offset: 0x00012E88
		internal static XMatrix CreateRotationRadians(double angle, double centerX, double centerY)
		{
			XMatrix xmatrix = default(XMatrix);
			double num = Math.Sin(angle);
			double num2 = Math.Cos(angle);
			double num3 = centerX * (1.0 - num2) + centerY * num;
			double num4 = centerY * (1.0 - num2) - centerX * num;
			xmatrix.SetMatrix(num2, num, -num, num2, num3, num4, XMatrix.XMatrixTypes.Unknown);
			return xmatrix;
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00014CE4 File Offset: 0x00012EE4
		internal static XMatrix CreateScaling(double scaleX, double scaleY)
		{
			XMatrix xmatrix = default(XMatrix);
			xmatrix.SetMatrix(scaleX, 0.0, 0.0, scaleY, 0.0, 0.0, XMatrix.XMatrixTypes.Scaling);
			return xmatrix;
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00014D28 File Offset: 0x00012F28
		internal static XMatrix CreateScaling(double scaleX, double scaleY, double centerX, double centerY)
		{
			XMatrix xmatrix = default(XMatrix);
			xmatrix.SetMatrix(scaleX, 0.0, 0.0, scaleY, centerX - scaleX * centerX, centerY - scaleY * centerY, XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling);
			return xmatrix;
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00014D64 File Offset: 0x00012F64
		internal static XMatrix CreateSkewRadians(double skewX, double skewY, double centerX, double centerY)
		{
			XMatrix xmatrix = default(XMatrix);
			xmatrix.Append(XMatrix.CreateTranslation(-centerX, -centerY));
			xmatrix.Append(new XMatrix(1.0, Math.Tan(skewY), Math.Tan(skewX), 1.0, 0.0, 0.0));
			xmatrix.Append(XMatrix.CreateTranslation(centerX, centerY));
			return xmatrix;
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00014DD4 File Offset: 0x00012FD4
		internal static XMatrix CreateSkewRadians(double skewX, double skewY)
		{
			XMatrix xmatrix = default(XMatrix);
			xmatrix.SetMatrix(1.0, Math.Tan(skewY), Math.Tan(skewX), 1.0, 0.0, 0.0, XMatrix.XMatrixTypes.Unknown);
			return xmatrix;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00014E24 File Offset: 0x00013024
		private static XMatrix CreateIdentity()
		{
			XMatrix xmatrix = default(XMatrix);
			xmatrix.SetMatrix(1.0, 0.0, 0.0, 1.0, 0.0, 0.0, XMatrix.XMatrixTypes.Identity);
			return xmatrix;
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00014E78 File Offset: 0x00013078
		private void SetMatrix(double m11, double m12, double m21, double m22, double offsetX, double offsetY, XMatrix.XMatrixTypes type)
		{
			this._m11 = m11;
			this._m12 = m12;
			this._m21 = m21;
			this._m22 = m22;
			this._offsetX = offsetX;
			this._offsetY = offsetY;
			this._type = type;
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00014EB0 File Offset: 0x000130B0
		private void DeriveMatrixType()
		{
			this._type = XMatrix.XMatrixTypes.Identity;
			if (this._m12 != 0.0 || this._m21 != 0.0)
			{
				this._type = XMatrix.XMatrixTypes.Unknown;
				return;
			}
			if (this._m11 != 1.0 || this._m22 != 1.0)
			{
				this._type = XMatrix.XMatrixTypes.Scaling;
			}
			if (this._offsetX != 0.0 || this._offsetY != 0.0)
			{
				this._type |= XMatrix.XMatrixTypes.Translation;
			}
			if ((this._type & (XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling)) == XMatrix.XMatrixTypes.Identity)
			{
				this._type = XMatrix.XMatrixTypes.Identity;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x00014F58 File Offset: 0x00013158
		private bool IsDistinguishedIdentity
		{
			get
			{
				return this._type == XMatrix.XMatrixTypes.Identity;
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x00014F64 File Offset: 0x00013164
		private string DebuggerDisplay
		{
			get
			{
				if (this.IsIdentity)
				{
					return "matrix=(Identity)";
				}
				XPoint xpoint = new XMatrix(this._m11, this._m12, this._m21, this._m22, 0.0, 0.0).Transform(new XPoint(1.0, 0.0));
				double num = Math.Atan2(xpoint.Y, xpoint.X) / 0.017453292519943295;
				return string.Format(CultureInfo.InvariantCulture, "matrix=({0:0.#######}, {1:0.#######}, {2:0.#######}, {3:0.#######}, {4:0.#######}, {5:0.#######}), φ={6:0.0#########}°", new object[] { this._m11, this._m12, this._m21, this._m22, this._offsetX, this._offsetY, num });
			}
		}

		// Token: 0x0400028D RID: 653
		private double _m11;

		// Token: 0x0400028E RID: 654
		private double _m12;

		// Token: 0x0400028F RID: 655
		private double _m21;

		// Token: 0x04000290 RID: 656
		private double _m22;

		// Token: 0x04000291 RID: 657
		private double _offsetX;

		// Token: 0x04000292 RID: 658
		private double _offsetY;

		// Token: 0x04000293 RID: 659
		private XMatrix.XMatrixTypes _type;

		// Token: 0x04000294 RID: 660
		private static readonly XMatrix s_identity = XMatrix.CreateIdentity();

		// Token: 0x02000073 RID: 115
		[Flags]
		internal enum XMatrixTypes
		{
			// Token: 0x04000296 RID: 662
			Identity = 0,
			// Token: 0x04000297 RID: 663
			Translation = 1,
			// Token: 0x04000298 RID: 664
			Scaling = 2,
			// Token: 0x04000299 RID: 665
			Unknown = 4
		}

		// Token: 0x02000074 RID: 116
		internal static class MatrixHelper
		{
			// Token: 0x060004ED RID: 1261 RVA: 0x0001506C File Offset: 0x0001326C
			internal static void MultiplyMatrix(ref XMatrix matrix1, ref XMatrix matrix2)
			{
				XMatrix.XMatrixTypes type = matrix1._type;
				XMatrix.XMatrixTypes type2 = matrix2._type;
				if (type2 != XMatrix.XMatrixTypes.Identity)
				{
					if (type == XMatrix.XMatrixTypes.Identity)
					{
						matrix1 = matrix2;
						return;
					}
					if (type2 == XMatrix.XMatrixTypes.Translation)
					{
						matrix1._offsetX += matrix2._offsetX;
						matrix1._offsetY += matrix2._offsetY;
						if (type != XMatrix.XMatrixTypes.Unknown)
						{
							matrix1._type |= XMatrix.XMatrixTypes.Translation;
							return;
						}
					}
					else
					{
						if (type != XMatrix.XMatrixTypes.Translation)
						{
							int num = (int)(((int)type << 4) | type2);
							switch (num)
							{
							case 34:
								matrix1._m11 *= matrix2._m11;
								matrix1._m22 *= matrix2._m22;
								return;
							case 35:
								matrix1._m11 *= matrix2._m11;
								matrix1._m22 *= matrix2._m22;
								matrix1._offsetX = matrix2._offsetX;
								matrix1._offsetY = matrix2._offsetY;
								matrix1._type = XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling;
								return;
							case 36:
								break;
							default:
								switch (num)
								{
								case 50:
									matrix1._m11 *= matrix2._m11;
									matrix1._m22 *= matrix2._m22;
									matrix1._offsetX *= matrix2._m11;
									matrix1._offsetY *= matrix2._m22;
									return;
								case 51:
									matrix1._m11 *= matrix2._m11;
									matrix1._m22 *= matrix2._m22;
									matrix1._offsetX = matrix2._m11 * matrix1._offsetX + matrix2._offsetX;
									matrix1._offsetY = matrix2._m22 * matrix1._offsetY + matrix2._offsetY;
									return;
								case 52:
									break;
								default:
									switch (num)
									{
									case 66:
									case 67:
									case 68:
										break;
									default:
										return;
									}
									break;
								}
								break;
							}
							matrix1 = new XMatrix(matrix1._m11 * matrix2._m11 + matrix1._m12 * matrix2._m21, matrix1._m11 * matrix2._m12 + matrix1._m12 * matrix2._m22, matrix1._m21 * matrix2._m11 + matrix1._m22 * matrix2._m21, matrix1._m21 * matrix2._m12 + matrix1._m22 * matrix2._m22, matrix1._offsetX * matrix2._m11 + matrix1._offsetY * matrix2._m21 + matrix2._offsetX, matrix1._offsetX * matrix2._m12 + matrix1._offsetY * matrix2._m22 + matrix2._offsetY);
							return;
						}
						double offsetX = matrix1._offsetX;
						double offsetY = matrix1._offsetY;
						matrix1 = matrix2;
						matrix1._offsetX = offsetX * matrix2._m11 + offsetY * matrix2._m21 + matrix2._offsetX;
						matrix1._offsetY = offsetX * matrix2._m12 + offsetY * matrix2._m22 + matrix2._offsetY;
						if (type2 == XMatrix.XMatrixTypes.Unknown)
						{
							matrix1._type = XMatrix.XMatrixTypes.Unknown;
							return;
						}
						matrix1._type = XMatrix.XMatrixTypes.Translation | XMatrix.XMatrixTypes.Scaling;
						return;
					}
				}
			}

			// Token: 0x060004EE RID: 1262 RVA: 0x00015368 File Offset: 0x00013568
			internal static void PrependOffset(ref XMatrix matrix, double offsetX, double offsetY)
			{
				if (matrix._type == XMatrix.XMatrixTypes.Identity)
				{
					matrix = new XMatrix(1.0, 0.0, 0.0, 1.0, offsetX, offsetY);
					matrix._type = XMatrix.XMatrixTypes.Translation;
					return;
				}
				matrix._offsetX += matrix._m11 * offsetX + matrix._m21 * offsetY;
				matrix._offsetY += matrix._m12 * offsetX + matrix._m22 * offsetY;
				if (matrix._type != XMatrix.XMatrixTypes.Unknown)
				{
					matrix._type |= XMatrix.XMatrixTypes.Translation;
				}
			}

			// Token: 0x060004EF RID: 1263 RVA: 0x0001540C File Offset: 0x0001360C
			internal static void TransformRect(ref XRect rect, ref XMatrix matrix)
			{
				if (!rect.IsEmpty)
				{
					XMatrix.XMatrixTypes type = matrix._type;
					if (type != XMatrix.XMatrixTypes.Identity)
					{
						if ((type & XMatrix.XMatrixTypes.Scaling) != XMatrix.XMatrixTypes.Identity)
						{
							rect.X *= matrix._m11;
							rect.Y *= matrix._m22;
							rect.Width *= matrix._m11;
							rect.Height *= matrix._m22;
							if (rect.Width < 0.0)
							{
								rect.X += rect.Width;
								rect.Width = -rect.Width;
							}
							if (rect.Height < 0.0)
							{
								rect.Y += rect.Height;
								rect.Height = -rect.Height;
							}
						}
						if ((type & XMatrix.XMatrixTypes.Translation) != XMatrix.XMatrixTypes.Identity)
						{
							rect.X += matrix._offsetX;
							rect.Y += matrix._offsetY;
						}
						if (type == XMatrix.XMatrixTypes.Unknown)
						{
							XPoint xpoint = matrix.Transform(rect.TopLeft);
							XPoint xpoint2 = matrix.Transform(rect.TopRight);
							XPoint xpoint3 = matrix.Transform(rect.BottomRight);
							XPoint xpoint4 = matrix.Transform(rect.BottomLeft);
							rect.X = Math.Min(Math.Min(xpoint.X, xpoint2.X), Math.Min(xpoint3.X, xpoint4.X));
							rect.Y = Math.Min(Math.Min(xpoint.Y, xpoint2.Y), Math.Min(xpoint3.Y, xpoint4.Y));
							rect.Width = Math.Max(Math.Max(xpoint.X, xpoint2.X), Math.Max(xpoint3.X, xpoint4.X)) - rect.X;
							rect.Height = Math.Max(Math.Max(xpoint.Y, xpoint2.Y), Math.Max(xpoint3.Y, xpoint4.Y)) - rect.Y;
						}
					}
				}
			}
		}
	}
}
