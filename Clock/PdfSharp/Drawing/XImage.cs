using System;
using System.Drawing;
using System.IO;
using PdfSharp.Drawing.Internal;
using PdfSharp.Internal;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Drawing
{
	// Token: 0x02000052 RID: 82
	public class XImage : IDisposable
	{
		// Token: 0x060001A0 RID: 416 RVA: 0x0000B6D4 File Offset: 0x000098D4
		protected XImage()
		{
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0000B6E3 File Offset: 0x000098E3
		private XImage(ImportedImage image)
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			this._importedImage = image;
			this.Initialize();
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0000B710 File Offset: 0x00009910
		private XImage(string path)
		{
			path = Path.GetFullPath(path);
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(PSSR.FileNotFound(path));
			}
			this._path = path;
			try
			{
				Lock.EnterGdiPlus();
				this._gdiImage = Image.FromFile(path);
			}
			finally
			{
				Lock.ExitGdiPlus();
			}
			this.Initialize();
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000B77C File Offset: 0x0000997C
		private XImage(Stream stream)
		{
			this._path = "*" + Guid.NewGuid().ToString("B");
			try
			{
				Lock.EnterGdiPlus();
				this._gdiImage = Image.FromStream(stream);
			}
			finally
			{
				Lock.ExitGdiPlus();
			}
			this._stream = stream;
			this.Initialize();
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000B7F0 File Offset: 0x000099F0
		public static XImage FromFile(string path)
		{
			if (PdfReader.TestPdfFile(path) > 0)
			{
				return new XPdfForm(path);
			}
			return new XImage(path);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000B808 File Offset: 0x00009A08
		public static XImage FromStream(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			return new XImage(stream);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000B81E File Offset: 0x00009A1E
		public static bool ExistsFile(string path)
		{
			return PdfReader.TestPdfFile(path) > 0 || File.Exists(path);
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x0000B831 File Offset: 0x00009A31
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x0000B839 File Offset: 0x00009A39
		internal XImageState XImageState
		{
			get
			{
				return this._xImageState;
			}
			set
			{
				this._xImageState = value;
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000B844 File Offset: 0x00009A44
		internal void Initialize()
		{
			if (this._importedImage != null)
			{
				ImportedImageJpeg importedImageJpeg = this._importedImage as ImportedImageJpeg;
				if (importedImageJpeg != null)
				{
					this._format = XImageFormat.Jpeg;
					return;
				}
				this._format = XImageFormat.Png;
				return;
			}
			else
			{
				if (this._gdiImage != null)
				{
					string text;
					try
					{
						Lock.EnterGdiPlus();
						text = this._gdiImage.RawFormat.Guid.ToString("B").ToUpper();
					}
					finally
					{
						Lock.ExitGdiPlus();
					}
					string text2;
					switch (text2 = text)
					{
					case "{B96B3CAA-0728-11D3-9D7B-0000F81EF32E}":
					case "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}":
					case "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}":
						this._format = XImageFormat.Png;
						return;
					case "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}":
						this._format = XImageFormat.Jpeg;
						return;
					case "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}":
						this._format = XImageFormat.Gif;
						return;
					case "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}":
						this._format = XImageFormat.Tiff;
						return;
					case "{B96B3CB5-0728-11D3-9D7B-0000F81EF32E}":
						this._format = XImageFormat.Icon;
						return;
					}
					throw new InvalidOperationException("Unsupported image format.");
				}
				return;
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000BA14 File Offset: 0x00009C14
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000BA20 File Offset: 0x00009C20
		protected virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				this._disposed = true;
			}
			this._importedImage = null;
			if (this._gdiImage != null)
			{
				try
				{
					Lock.EnterGdiPlus();
					this._gdiImage.Dispose();
					this._gdiImage = null;
				}
				finally
				{
					Lock.ExitGdiPlus();
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001AC RID: 428 RVA: 0x0000BA7C File Offset: 0x00009C7C
		[Obsolete("Use either PixelWidth or PointWidth. Temporarily obsolete because of rearrangements for WPF. Currently same as PixelWidth, but will become PointWidth in future releases of PDFsharp.")]
		public virtual double Width
		{
			get
			{
				if (this._importedImage != null)
				{
					return this._importedImage.Information.Width;
				}
				double num;
				try
				{
					Lock.EnterGdiPlus();
					num = (double)this._gdiImage.Width;
				}
				finally
				{
					Lock.ExitGdiPlus();
				}
				return num;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001AD RID: 429 RVA: 0x0000BAD0 File Offset: 0x00009CD0
		[Obsolete("Use either PixelHeight or PointHeight. Temporarily obsolete because of rearrangements for WPF. Currently same as PixelHeight, but will become PointHeight in future releases of PDFsharp.")]
		public virtual double Height
		{
			get
			{
				if (this._importedImage != null)
				{
					return this._importedImage.Information.Height;
				}
				double num;
				try
				{
					Lock.EnterGdiPlus();
					num = (double)this._gdiImage.Height;
				}
				finally
				{
					Lock.ExitGdiPlus();
				}
				return num;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0000BB24 File Offset: 0x00009D24
		public virtual double PointWidth
		{
			get
			{
				if (this._importedImage == null)
				{
					double num;
					try
					{
						Lock.EnterGdiPlus();
						num = (double)((float)(this._gdiImage.Width * 72) / this._gdiImage.HorizontalResolution);
					}
					finally
					{
						Lock.ExitGdiPlus();
					}
					return num;
				}
				if (this._importedImage.Information.HorizontalDPM > 0m)
				{
					return (double)(this._importedImage.Information.Width * 2834.6456692913385826771653543m / this._importedImage.Information.HorizontalDPM);
				}
				if (this._importedImage.Information.HorizontalDPI > 0m)
				{
					return (double)(this._importedImage.Information.Width * 72U / this._importedImage.Information.HorizontalDPI);
				}
				return this._importedImage.Information.Width;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001AF RID: 431 RVA: 0x0000BC48 File Offset: 0x00009E48
		public virtual double PointHeight
		{
			get
			{
				if (this._importedImage == null)
				{
					double num;
					try
					{
						Lock.EnterGdiPlus();
						num = (double)((float)(this._gdiImage.Height * 72) / this._gdiImage.HorizontalResolution);
					}
					finally
					{
						Lock.ExitGdiPlus();
					}
					return num;
				}
				if (this._importedImage.Information.VerticalDPM > 0m)
				{
					return (double)(this._importedImage.Information.Height * 2834.6456692913385826771653543m / this._importedImage.Information.VerticalDPM);
				}
				if (this._importedImage.Information.VerticalDPI > 0m)
				{
					return (double)(this._importedImage.Information.Height * 72U / this._importedImage.Information.VerticalDPI);
				}
				return this._importedImage.Information.Width;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x0000BD6C File Offset: 0x00009F6C
		public virtual int PixelWidth
		{
			get
			{
				if (this._importedImage != null)
				{
					return (int)this._importedImage.Information.Width;
				}
				int width;
				try
				{
					Lock.EnterGdiPlus();
					width = this._gdiImage.Width;
				}
				finally
				{
					Lock.ExitGdiPlus();
				}
				return width;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x0000BDBC File Offset: 0x00009FBC
		public virtual int PixelHeight
		{
			get
			{
				if (this._importedImage != null)
				{
					return (int)this._importedImage.Information.Height;
				}
				int height;
				try
				{
					Lock.EnterGdiPlus();
					height = this._gdiImage.Height;
				}
				finally
				{
					Lock.ExitGdiPlus();
				}
				return height;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x0000BE0C File Offset: 0x0000A00C
		public virtual XSize Size
		{
			get
			{
				return new XSize(this.PointWidth, this.PointHeight);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x0000BE20 File Offset: 0x0000A020
		public virtual double HorizontalResolution
		{
			get
			{
				if (this._importedImage == null)
				{
					double num;
					try
					{
						Lock.EnterGdiPlus();
						num = (double)this._gdiImage.HorizontalResolution;
					}
					finally
					{
						Lock.ExitGdiPlus();
					}
					return num;
				}
				if (this._importedImage.Information.HorizontalDPI > 0m)
				{
					return (double)this._importedImage.Information.HorizontalDPI;
				}
				if (this._importedImage.Information.HorizontalDPM > 0m)
				{
					return (double)(this._importedImage.Information.HorizontalDPM / 39.370078740157480314960629921m);
				}
				return 72.0;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000BEF4 File Offset: 0x0000A0F4
		public virtual double VerticalResolution
		{
			get
			{
				if (this._importedImage == null)
				{
					double num;
					try
					{
						Lock.EnterGdiPlus();
						num = (double)this._gdiImage.VerticalResolution;
					}
					finally
					{
						Lock.ExitGdiPlus();
					}
					return num;
				}
				if (this._importedImage.Information.VerticalDPI > 0m)
				{
					return (double)this._importedImage.Information.VerticalDPI;
				}
				if (this._importedImage.Information.VerticalDPM > 0m)
				{
					return (double)(this._importedImage.Information.VerticalDPM / 39.370078740157480314960629921m);
				}
				return 72.0;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x0000BFC8 File Offset: 0x0000A1C8
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x0000BFD0 File Offset: 0x0000A1D0
		public virtual bool Interpolate
		{
			get
			{
				return this._interpolate;
			}
			set
			{
				this._interpolate = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x0000BFD9 File Offset: 0x0000A1D9
		public XImageFormat Format
		{
			get
			{
				return this._format;
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0000BFE1 File Offset: 0x0000A1E1
		internal void AssociateWithGraphics(XGraphics gfx)
		{
			if (this._associatedGraphics != null)
			{
				throw new InvalidOperationException("XImage already associated with XGraphics.");
			}
			this._associatedGraphics = null;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000BFFD File Offset: 0x0000A1FD
		internal void DisassociateWithGraphics()
		{
			if (this._associatedGraphics == null)
			{
				throw new InvalidOperationException("XImage not associated with XGraphics.");
			}
			this._associatedGraphics.DisassociateImage();
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0000C01D File Offset: 0x0000A21D
		internal void DisassociateWithGraphics(XGraphics gfx)
		{
			if (this._associatedGraphics != gfx)
			{
				throw new InvalidOperationException("XImage not associated with XGraphics.");
			}
			this._associatedGraphics = null;
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001BB RID: 443 RVA: 0x0000C03A File Offset: 0x0000A23A
		// (set) Token: 0x060001BC RID: 444 RVA: 0x0000C042 File Offset: 0x0000A242
		internal XGraphics AssociatedGraphics
		{
			get
			{
				return this._associatedGraphics;
			}
			set
			{
				this._associatedGraphics = value;
			}
		}

		// Token: 0x040001F0 RID: 496
		private const decimal FactorDPM72 = 2834.6456692913385826771653543m;

		// Token: 0x040001F1 RID: 497
		private const decimal FactorDPM = 39.370078740157480314960629921m;

		// Token: 0x040001F2 RID: 498
		private XImageState _xImageState;

		// Token: 0x040001F3 RID: 499
		private bool _disposed;

		// Token: 0x040001F4 RID: 500
		private bool _interpolate = true;

		// Token: 0x040001F5 RID: 501
		private XImageFormat _format;

		// Token: 0x040001F6 RID: 502
		private XGraphics _associatedGraphics;

		// Token: 0x040001F7 RID: 503
		internal ImportedImage _importedImage;

		// Token: 0x040001F8 RID: 504
		internal Image _gdiImage;

		// Token: 0x040001F9 RID: 505
		internal string _path;

		// Token: 0x040001FA RID: 506
		internal Stream _stream;

		// Token: 0x040001FB RID: 507
		internal PdfImageTable.ImageSelector _selector;
	}
}
