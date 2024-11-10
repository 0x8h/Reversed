using System;
using System.Globalization;
using System.Text;
using PdfSharp.Internal;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Drawing.Pdf
{
	// Token: 0x0200001C RID: 28
	internal sealed class PdfGraphicsState : ICloneable
	{
		// Token: 0x0600009D RID: 157 RVA: 0x00005D64 File Offset: 0x00003F64
		public PdfGraphicsState(XGraphicsPdfRenderer renderer)
		{
			this._renderer = renderer;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00005DD4 File Offset: 0x00003FD4
		public PdfGraphicsState Clone()
		{
			return (PdfGraphicsState)base.MemberwiseClone();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00005DEE File Offset: 0x00003FEE
		object ICloneable.Clone()
		{
			return this.Clone();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00005DF6 File Offset: 0x00003FF6
		public void PushState()
		{
			this._renderer.Append("q/n");
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00005E08 File Offset: 0x00004008
		public void PopState()
		{
			this._renderer.Append("Q/n");
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00005E1C File Offset: 0x0000401C
		public void RealizePen(XPen pen, PdfColorMode colorMode)
		{
			XColor xcolor = pen.Color;
			bool overprint = pen.Overprint;
			xcolor = ColorSpaceHelper.EnsureColorMode(colorMode, xcolor);
			if (this._realizedLineWith != pen._width)
			{
				this._renderer.AppendFormatArgs("{0:0.###} w\n", new object[] { pen._width });
				this._realizedLineWith = pen._width;
			}
			if (this._realizedLineCap != (int)pen._lineCap)
			{
				this._renderer.AppendFormatArgs("{0} J\n", new object[] { (int)pen._lineCap });
				this._realizedLineCap = (int)pen._lineCap;
			}
			if (this._realizedLineJoin != (int)pen._lineJoin)
			{
				this._renderer.AppendFormatArgs("{0} j\n", new object[] { (int)pen._lineJoin });
				this._realizedLineJoin = (int)pen._lineJoin;
			}
			if (this._realizedLineCap == 0 && this._realizedMiterLimit != (double)((int)pen._miterLimit) && (int)pen._miterLimit != 0)
			{
				this._renderer.AppendFormatInt("{0} M\n", (int)pen._miterLimit);
				this._realizedMiterLimit = (double)((int)pen._miterLimit);
			}
			if (this._realizedDashStyle != pen._dashStyle || pen._dashStyle == XDashStyle.Custom)
			{
				double width = pen.Width;
				double num = 3.0 * width;
				XDashStyle xdashStyle = pen.DashStyle;
				if (width == 0.0)
				{
					xdashStyle = XDashStyle.Solid;
				}
				switch (xdashStyle)
				{
				case XDashStyle.Solid:
					this._renderer.Append("[]0 d\n");
					break;
				case XDashStyle.Dash:
					this._renderer.AppendFormatArgs("[{0:0.##} {1:0.##}]0 d\n", new object[] { num, width });
					break;
				case XDashStyle.Dot:
					this._renderer.AppendFormatArgs("[{0:0.##}]0 d\n", new object[] { width });
					break;
				case XDashStyle.DashDot:
					this._renderer.AppendFormatArgs("[{0:0.##} {1:0.##} {1:0.##} {1:0.##}]0 d\n", new object[] { num, width });
					break;
				case XDashStyle.DashDotDot:
					this._renderer.AppendFormatArgs("[{0:0.##} {1:0.##} {1:0.##} {1:0.##} {1:0.##} {1:0.##}]0 d\n", new object[] { num, width });
					break;
				case XDashStyle.Custom:
				{
					StringBuilder stringBuilder = new StringBuilder("[", 256);
					int num2 = ((pen._dashPattern == null) ? 0 : pen._dashPattern.Length);
					for (int i = 0; i < num2; i++)
					{
						if (i > 0)
						{
							stringBuilder.Append(' ');
						}
						stringBuilder.Append(PdfEncoders.ToString(pen._dashPattern[i] * pen._width));
					}
					if (num2 > 0 && num2 % 2 == 1)
					{
						stringBuilder.Append(' ');
						stringBuilder.Append(PdfEncoders.ToString(0.2 * pen._width));
					}
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "]{0:0.###} d\n", new object[] { pen._dashOffset * pen._width });
					string text = stringBuilder.ToString();
					this._realizedDashPattern = text;
					this._renderer.Append(text);
					break;
				}
				}
				this._realizedDashStyle = xdashStyle;
			}
			if (colorMode != PdfColorMode.Cmyk)
			{
				if (this._realizedStrokeColor.Rgb != xcolor.Rgb)
				{
					this._renderer.Append(PdfEncoders.ToString(xcolor, PdfColorMode.Rgb));
					this._renderer.Append(" RG\n");
				}
			}
			else if (!ColorSpaceHelper.IsEqualCmyk(this._realizedStrokeColor, xcolor))
			{
				this._renderer.Append(PdfEncoders.ToString(xcolor, PdfColorMode.Cmyk));
				this._renderer.Append(" K\n");
			}
			if (this._renderer.Owner.Version >= 14 && (this._realizedStrokeColor.A != xcolor.A || this._realizedStrokeOverPrint != overprint))
			{
				PdfExtGState extGStateStroke = this._renderer.Owner.ExtGStateTable.GetExtGStateStroke(xcolor.A, overprint);
				string text2 = this._renderer.Resources.AddExtGState(extGStateStroke);
				this._renderer.AppendFormatString("{0} gs\n", text2);
				if (this._renderer._page != null && xcolor.A < 1.0)
				{
					this._renderer._page.TransparencyUsed = true;
				}
			}
			this._realizedStrokeColor = xcolor;
			this._realizedStrokeOverPrint = overprint;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000062A4 File Offset: 0x000044A4
		public void RealizeBrush(XBrush brush, PdfColorMode colorMode, int renderingMode, double fontEmSize)
		{
			XSolidBrush xsolidBrush = brush as XSolidBrush;
			if (xsolidBrush != null)
			{
				XColor color = xsolidBrush.Color;
				bool overprint = xsolidBrush.Overprint;
				if (renderingMode == 0)
				{
					this.RealizeFillColor(color, overprint, colorMode);
					return;
				}
				if (renderingMode == 2)
				{
					this.RealizeFillColor(color, false, colorMode);
					this.RealizePen(new XPen(color, fontEmSize * 0.02), colorMode);
					return;
				}
				throw new InvalidOperationException("Only rendering modes 0 and 2 are currently supported.");
			}
			else
			{
				if (renderingMode != 0)
				{
					throw new InvalidOperationException("Rendering modes other than 0 can only be used with solid color brushes.");
				}
				XLinearGradientBrush xlinearGradientBrush = brush as XLinearGradientBrush;
				if (xlinearGradientBrush != null)
				{
					XMatrix defaultViewMatrix = this._renderer.DefaultViewMatrix;
					defaultViewMatrix.Prepend(this.EffectiveCtm);
					PdfShadingPattern pdfShadingPattern = new PdfShadingPattern(this._renderer.Owner);
					pdfShadingPattern.SetupFromBrush(xlinearGradientBrush, defaultViewMatrix, this._renderer);
					string text = this._renderer.Resources.AddPattern(pdfShadingPattern);
					this._renderer.AppendFormatString("/Pattern cs\n", text);
					this._renderer.AppendFormatString("{0} scn\n", text);
					this._realizedFillColor = XColor.Empty;
				}
				return;
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000063A0 File Offset: 0x000045A0
		private void RealizeFillColor(XColor color, bool overPrint, PdfColorMode colorMode)
		{
			color = ColorSpaceHelper.EnsureColorMode(colorMode, color);
			if (colorMode != PdfColorMode.Cmyk)
			{
				if (this._realizedFillColor.IsEmpty || this._realizedFillColor.Rgb != color.Rgb)
				{
					this._renderer.Append(PdfEncoders.ToString(color, PdfColorMode.Rgb));
					this._renderer.Append(" rg\n");
				}
			}
			else if (this._realizedFillColor.IsEmpty || !ColorSpaceHelper.IsEqualCmyk(this._realizedFillColor, color))
			{
				this._renderer.Append(PdfEncoders.ToString(color, PdfColorMode.Cmyk));
				this._renderer.Append(" k\n");
			}
			if (this._renderer.Owner.Version >= 14 && (this._realizedFillColor.A != color.A || this._realizedNonStrokeOverPrint != overPrint))
			{
				PdfExtGState extGStateNonStroke = this._renderer.Owner.ExtGStateTable.GetExtGStateNonStroke(color.A, overPrint);
				string text = this._renderer.Resources.AddExtGState(extGStateNonStroke);
				this._renderer.AppendFormatString("{0} gs\n", text);
				if (this._renderer._page != null && color.A < 1.0)
				{
					this._renderer._page.TransparencyUsed = true;
				}
			}
			this._realizedFillColor = color;
			this._realizedNonStrokeOverPrint = overPrint;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000064F0 File Offset: 0x000046F0
		internal void RealizeNonStrokeTransparency(double transparency, PdfColorMode colorMode)
		{
			XColor realizedFillColor = this._realizedFillColor;
			realizedFillColor.A = transparency;
			this.RealizeFillColor(realizedFillColor, this._realizedNonStrokeOverPrint, colorMode);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000651C File Offset: 0x0000471C
		public void RealizeFont(XFont font, XBrush brush, int renderingMode)
		{
			this.RealizeBrush(brush, this._renderer._colorMode, renderingMode, font.Size);
			if (this._realizedRenderingMode != renderingMode)
			{
				this._renderer.AppendFormatInt("{0} Tr\n", renderingMode);
				this._realizedRenderingMode = renderingMode;
			}
			if (this._realizedRenderingMode == 0)
			{
				if (this._realizedCharSpace != 0.0)
				{
					this._renderer.Append("0 Tc\n");
					this._realizedCharSpace = 0.0;
				}
			}
			else
			{
				double num = font.Size * 0.02;
				if (this._realizedCharSpace != num)
				{
					this._renderer.AppendFormatDouble("{0:0.###} Tc\n", num);
					this._realizedCharSpace = num;
				}
			}
			this._realizedFont = null;
			string fontName = this._renderer.GetFontName(font, out this._realizedFont);
			if (fontName != this._realizedFontName || this._realizedFontSize != font.Size)
			{
				if (this._renderer.Gfx.PageDirection == XPageDirection.Downwards)
				{
					this._renderer.AppendFormatFont("{0} {1:0.###} Tf\n", fontName, font.Size);
				}
				else
				{
					this._renderer.AppendFormatFont("{0} {1:0.###} Tf\n", fontName, font.Size);
				}
				this._realizedFontName = fontName;
				this._realizedFontSize = font.Size;
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000665C File Offset: 0x0000485C
		public void AddTransform(XMatrix value, XMatrixOrder matrixOrder)
		{
			XMatrix xmatrix = value;
			if (this._renderer.Gfx.PageDirection == XPageDirection.Downwards)
			{
				xmatrix.M12 = -value.M12;
				xmatrix.M21 = -value.M21;
			}
			this.UnrealizedCtm.Prepend(xmatrix);
			this.WorldTransform.Prepend(value);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000066B4 File Offset: 0x000048B4
		public void RealizeCtm()
		{
			if (!this.UnrealizedCtm.IsIdentity)
			{
				double[] elements = this.UnrealizedCtm.GetElements();
				this._renderer.AppendFormatArgs("{0:0.#######} {1:0.#######} {2:0.#######} {3:0.#######} {4:0.#######} {5:0.#######} cm\n", new object[]
				{
					elements[0],
					elements[1],
					elements[2],
					elements[3],
					elements[4],
					elements[5]
				});
				this.RealizedCtm.Prepend(this.UnrealizedCtm);
				this.UnrealizedCtm = default(XMatrix);
				this.EffectiveCtm = this.RealizedCtm;
				this.InverseEffectiveCtm = this.EffectiveCtm;
				this.InverseEffectiveCtm.Invert();
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00006778 File Offset: 0x00004978
		public void SetAndRealizeClipRect(XRect clipRect)
		{
			XGraphicsPath xgraphicsPath = new XGraphicsPath();
			xgraphicsPath.AddRectangle(clipRect);
			this.RealizeClipPath(xgraphicsPath);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00006799 File Offset: 0x00004999
		public void SetAndRealizeClipPath(XGraphicsPath clipPath)
		{
			this.RealizeClipPath(clipPath);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000067A4 File Offset: 0x000049A4
		private void RealizeClipPath(XGraphicsPath clipPath)
		{
			DiagnosticsHelper.HandleNotImplemented("RealizeClipPath");
			this._renderer.BeginGraphicMode();
			this.RealizeCtm();
			this._renderer.AppendPath(clipPath._corePath);
			this._renderer.Append((clipPath.FillMode == XFillMode.Winding) ? "W n\n" : "W* n\n");
		}

		// Token: 0x04000083 RID: 131
		private readonly XGraphicsPdfRenderer _renderer;

		// Token: 0x04000084 RID: 132
		internal int Level;

		// Token: 0x04000085 RID: 133
		internal InternalGraphicsState InternalState;

		// Token: 0x04000086 RID: 134
		private double _realizedLineWith = -1.0;

		// Token: 0x04000087 RID: 135
		private int _realizedLineCap = -1;

		// Token: 0x04000088 RID: 136
		private int _realizedLineJoin = -1;

		// Token: 0x04000089 RID: 137
		private double _realizedMiterLimit = -1.0;

		// Token: 0x0400008A RID: 138
		private XDashStyle _realizedDashStyle = (XDashStyle)(-1);

		// Token: 0x0400008B RID: 139
		private string _realizedDashPattern;

		// Token: 0x0400008C RID: 140
		private XColor _realizedStrokeColor = XColor.Empty;

		// Token: 0x0400008D RID: 141
		private bool _realizedStrokeOverPrint;

		// Token: 0x0400008E RID: 142
		private XColor _realizedFillColor = XColor.Empty;

		// Token: 0x0400008F RID: 143
		private bool _realizedNonStrokeOverPrint;

		// Token: 0x04000090 RID: 144
		internal PdfFont _realizedFont;

		// Token: 0x04000091 RID: 145
		private string _realizedFontName = string.Empty;

		// Token: 0x04000092 RID: 146
		private double _realizedFontSize;

		// Token: 0x04000093 RID: 147
		private int _realizedRenderingMode;

		// Token: 0x04000094 RID: 148
		private double _realizedCharSpace;

		// Token: 0x04000095 RID: 149
		public XPoint RealizedTextPosition;

		// Token: 0x04000096 RID: 150
		public bool ItalicSimulationOn;

		// Token: 0x04000097 RID: 151
		public XMatrix RealizedCtm;

		// Token: 0x04000098 RID: 152
		public XMatrix UnrealizedCtm;

		// Token: 0x04000099 RID: 153
		public XMatrix EffectiveCtm;

		// Token: 0x0400009A RID: 154
		public XMatrix InverseEffectiveCtm;

		// Token: 0x0400009B RID: 155
		public XMatrix WorldTransform;
	}
}
