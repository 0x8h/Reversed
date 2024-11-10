using System;
using System.ComponentModel;

namespace PdfSharp.Drawing
{
	// Token: 0x02000071 RID: 113
	public sealed class XLinearGradientBrush : XBrush
	{
		// Token: 0x06000485 RID: 1157 RVA: 0x000134DF File Offset: 0x000116DF
		public XLinearGradientBrush(XPoint point1, XPoint point2, XColor color1, XColor color2)
		{
			this._point1 = point1;
			this._point2 = point2;
			this._color1 = color1;
			this._color2 = color2;
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00013504 File Offset: 0x00011704
		public XLinearGradientBrush(XRect rect, XColor color1, XColor color2, XLinearGradientMode linearGradientMode)
		{
			if (!Enum.IsDefined(typeof(XLinearGradientMode), linearGradientMode))
			{
				throw new InvalidEnumArgumentException("linearGradientMode", (int)linearGradientMode, typeof(XLinearGradientMode));
			}
			if (rect.Width == 0.0 || rect.Height == 0.0)
			{
				throw new ArgumentException("Invalid rectangle.", "rect");
			}
			this._useRect = true;
			this._color1 = color1;
			this._color2 = color2;
			this._rect = rect;
			this._linearGradientMode = linearGradientMode;
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x0001359E File Offset: 0x0001179E
		// (set) Token: 0x06000488 RID: 1160 RVA: 0x000135A6 File Offset: 0x000117A6
		public XMatrix Transform
		{
			get
			{
				return this._matrix;
			}
			set
			{
				this._matrix = value;
			}
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x000135AF File Offset: 0x000117AF
		public void TranslateTransform(double dx, double dy)
		{
			this._matrix.TranslatePrepend(dx, dy);
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x000135BE File Offset: 0x000117BE
		public void TranslateTransform(double dx, double dy, XMatrixOrder order)
		{
			this._matrix.Translate(dx, dy, order);
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x000135CE File Offset: 0x000117CE
		public void ScaleTransform(double sx, double sy)
		{
			this._matrix.ScalePrepend(sx, sy);
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x000135DD File Offset: 0x000117DD
		public void ScaleTransform(double sx, double sy, XMatrixOrder order)
		{
			this._matrix.Scale(sx, sy, order);
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x000135ED File Offset: 0x000117ED
		public void RotateTransform(double angle)
		{
			this._matrix.RotatePrepend(angle);
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x000135FB File Offset: 0x000117FB
		public void RotateTransform(double angle, XMatrixOrder order)
		{
			this._matrix.Rotate(angle, order);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0001360A File Offset: 0x0001180A
		public void MultiplyTransform(XMatrix matrix)
		{
			this._matrix.Prepend(matrix);
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00013618 File Offset: 0x00011818
		public void MultiplyTransform(XMatrix matrix, XMatrixOrder order)
		{
			this._matrix.Multiply(matrix, order);
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00013627 File Offset: 0x00011827
		public void ResetTransform()
		{
			this._matrix = default(XMatrix);
		}

		// Token: 0x04000285 RID: 645
		internal bool _useRect;

		// Token: 0x04000286 RID: 646
		internal XPoint _point1;

		// Token: 0x04000287 RID: 647
		internal XPoint _point2;

		// Token: 0x04000288 RID: 648
		internal XColor _color1;

		// Token: 0x04000289 RID: 649
		internal XColor _color2;

		// Token: 0x0400028A RID: 650
		internal XRect _rect;

		// Token: 0x0400028B RID: 651
		internal XLinearGradientMode _linearGradientMode;

		// Token: 0x0400028C RID: 652
		internal XMatrix _matrix;
	}
}
