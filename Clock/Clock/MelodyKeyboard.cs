using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200002C RID: 44
	public class MelodyKeyboard : PictureBox
	{
		// Token: 0x0600049E RID: 1182 RVA: 0x0003A3B4 File Offset: 0x000385B4
		public MelodyKeyboard(MelodyWindow melodyWindow)
		{
			this.InitializeComponent();
			this._melodyWindow = melodyWindow;
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0003A3CC File Offset: 0x000385CC
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			Graphics graphics = pe.Graphics;
			Bitmap bitmap = new Bitmap(Resources.mld_bg_000);
			Point point = new Point(0, 0);
			graphics.DrawImage(bitmap, point);
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0003A404 File Offset: 0x00038604
		protected override void OnMouseDown(MouseEventArgs me)
		{
			if (this._melodyWindow.PlayingFlag || !this._melodyWindow.isTutorialKeyboardEnable())
			{
				return;
			}
			base.OnMouseDown(me);
			this._rank = MelodyModule.Key.RANK.REST;
			if (me.Button == MouseButtons.Left)
			{
				int x = me.X;
				int y = me.Y;
				if (x >= MelodyKeyboard.START_X && x <= MelodyKeyboard.END_X && y >= MelodyKeyboard.START_Y && y <= MelodyKeyboard.END_Y)
				{
					if (y > MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
					{
						if (x < MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH)
						{
							return;
						}
						if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH)
						{
							this._rank = MelodyModule.Key.RANK.LOW_SO;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 2)
						{
							this._rank = MelodyModule.Key.RANK.LOW_RA;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 3)
						{
							this._rank = MelodyModule.Key.RANK.LOW_SI;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 4)
						{
							this._rank = MelodyModule.Key.RANK.DO;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 5)
						{
							this._rank = MelodyModule.Key.RANK.RE;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 6)
						{
							this._rank = MelodyModule.Key.RANK.MI;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 7)
						{
							this._rank = MelodyModule.Key.RANK.FA;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 8)
						{
							this._rank = MelodyModule.Key.RANK.SO;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 9)
						{
							this._rank = MelodyModule.Key.RANK.RA;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 10)
						{
							this._rank = MelodyModule.Key.RANK.SI;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 11)
						{
							this._rank = MelodyModule.Key.RANK.HIGH_DO;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 12)
						{
							this._rank = MelodyModule.Key.RANK.HIGH_RE;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 13)
						{
							this._rank = MelodyModule.Key.RANK.HIGH_MI;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 14)
						{
							this._rank = MelodyModule.Key.RANK.HIGH_FA;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 15)
						{
							this._rank = MelodyModule.Key.RANK.HIGH_SO;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 16)
						{
							this._rank = MelodyModule.Key.RANK.HIGH_RA;
						}
						else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 17)
						{
							this._rank = MelodyModule.Key.RANK.HIGH_SI;
						}
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH)
					{
						this._rank = MelodyModule.Key.RANK.LOW_FA_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW)
					{
						this._rank = MelodyModule.Key.RANK.LOW_SO;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW)
					{
						this._rank = MelodyModule.Key.RANK.LOW_SO_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2)
					{
						this._rank = MelodyModule.Key.RANK.LOW_RA;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2)
					{
						this._rank = MelodyModule.Key.RANK.LOW_RA_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE)
					{
						this._rank = MelodyModule.Key.RANK.LOW_SI;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2)
					{
						this._rank = MelodyModule.Key.RANK.DO;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2)
					{
						this._rank = MelodyModule.Key.RANK.DO_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2)
					{
						this._rank = MelodyModule.Key.RANK.RE;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2)
					{
						this._rank = MelodyModule.Key.RANK.RE_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 3)
					{
						this._rank = MelodyModule.Key.RANK.MI;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4)
					{
						this._rank = MelodyModule.Key.RANK.FA;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4)
					{
						this._rank = MelodyModule.Key.RANK.FA_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4)
					{
						this._rank = MelodyModule.Key.RANK.SO;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4)
					{
						this._rank = MelodyModule.Key.RANK.SO_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4)
					{
						this._rank = MelodyModule.Key.RANK.RA;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4)
					{
						this._rank = MelodyModule.Key.RANK.RA_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 5)
					{
						this._rank = MelodyModule.Key.RANK.SI;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6)
					{
						this._rank = MelodyModule.Key.RANK.HIGH_DO;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 9 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6)
					{
						this._rank = MelodyModule.Key.RANK.HIGH_DO_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 9 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6)
					{
						this._rank = MelodyModule.Key.RANK.HIGH_RE;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 10 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6)
					{
						this._rank = MelodyModule.Key.RANK.HIGH_RE_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 10 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 7)
					{
						this._rank = MelodyModule.Key.RANK.HIGH_MI;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 10 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8)
					{
						this._rank = MelodyModule.Key.RANK.HIGH_FA;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 11 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8)
					{
						this._rank = MelodyModule.Key.RANK.HIGH_FA_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 11 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8)
					{
						this._rank = MelodyModule.Key.RANK.HIGH_SO;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 12 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8)
					{
						this._rank = MelodyModule.Key.RANK.HIGH_SO_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 12 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8)
					{
						this._rank = MelodyModule.Key.RANK.HIGH_RA;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 13 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8)
					{
						this._rank = MelodyModule.Key.RANK.HIGH_RA_SHARP;
					}
					else if (x <= MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 13 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 9)
					{
						this._rank = MelodyModule.Key.RANK.HIGH_SI;
					}
				}
			}
			if (this._melodyWindow.isTutorial())
			{
				if (this._melodyWindow.Tutorial == MelodyWindow.TUTORIAL.KEY && this._rank != MelodyModule.Key.RANK.SO)
				{
					return;
				}
				if (this._melodyWindow.Tutorial == MelodyWindow.TUTORIAL.CHANGE_KEY && this._rank != MelodyModule.Key.RANK.DO)
				{
					return;
				}
			}
			if (this._rank != MelodyModule.Key.RANK.REST)
			{
				this.colorKey(this._rank);
			}
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0003AC58 File Offset: 0x00038E58
		protected override void OnMouseUp(MouseEventArgs me)
		{
			if (this._melodyWindow.PlayingFlag)
			{
				return;
			}
			if (this._melodyWindow.isTutorial())
			{
				if (this._melodyWindow.Tutorial == MelodyWindow.TUTORIAL.KEY && this._rank != MelodyModule.Key.RANK.SO)
				{
					return;
				}
				if (this._melodyWindow.Tutorial == MelodyWindow.TUTORIAL.CHANGE_KEY && this._rank != MelodyModule.Key.RANK.DO)
				{
					return;
				}
			}
			if (this._rank != MelodyModule.Key.RANK.REST)
			{
				this._melodyWindow.clickKeyBoard(this._rank);
			}
			this._rank = MelodyModule.Key.RANK.REST;
			this._brush = null;
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0003ACD8 File Offset: 0x00038ED8
		public void colorKey(MelodyModule.Key.RANK rank)
		{
			this.clearColor();
			Point[] array = null;
			if (rank == MelodyModule.Key.RANK.LOW_FA_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_LOW_FA_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.LOW_SO)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_LOW_SO;
			}
			else if (rank == MelodyModule.Key.RANK.LOW_SO_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_LOW_SO_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.LOW_RA)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_LOW_RA;
			}
			else if (rank == MelodyModule.Key.RANK.LOW_RA_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_LOW_RA_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.LOW_SI)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_LOW_SI;
			}
			else if (rank == MelodyModule.Key.RANK.DO)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_DO;
			}
			else if (rank == MelodyModule.Key.RANK.DO_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_DO_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.RE)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_RE;
			}
			else if (rank == MelodyModule.Key.RANK.RE_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_RE_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.MI)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_MI;
			}
			else if (rank == MelodyModule.Key.RANK.FA)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_FA;
			}
			else if (rank == MelodyModule.Key.RANK.FA_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_FA_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.SO)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_SO;
			}
			else if (rank == MelodyModule.Key.RANK.SO_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_SO_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.RA)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_RA;
			}
			else if (rank == MelodyModule.Key.RANK.RA_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_RA_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.SI)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_SI;
			}
			else if (rank == MelodyModule.Key.RANK.HIGH_DO)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_HIGH_DO;
			}
			else if (rank == MelodyModule.Key.RANK.HIGH_DO_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_HIGH_DO_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.HIGH_RE)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_HIGH_RE;
			}
			else if (rank == MelodyModule.Key.RANK.HIGH_RE_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_HIGH_RE_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.HIGH_MI)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_HIGH_MI;
			}
			else if (rank == MelodyModule.Key.RANK.HIGH_FA)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_HIGH_FA;
			}
			else if (rank == MelodyModule.Key.RANK.HIGH_FA_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_HIGH_FA_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.HIGH_SO)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_HIGH_SO;
			}
			else if (rank == MelodyModule.Key.RANK.HIGH_SO_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_HIGH_SO_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.HIGH_RA)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_HIGH_RA;
			}
			else if (rank == MelodyModule.Key.RANK.HIGH_RA_SHARP)
			{
				this._brush = MelodyKeyboard.BLACK_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_HIGH_RA_SHARP;
			}
			else if (rank == MelodyModule.Key.RANK.HIGH_SI)
			{
				this._brush = MelodyKeyboard.WHITE_BRUSH;
				array = MelodyKeyboard.POINT_ARRAY_HIGH_SI;
			}
			if (array != null)
			{
				base.CreateGraphics().FillPolygon(this._brush, array);
			}
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0003B010 File Offset: 0x00039210
		public void clearColor()
		{
			Graphics graphics = base.CreateGraphics();
			Bitmap bitmap = new Bitmap(Resources.mld_bg_000);
			Point point = new Point(0, 0);
			graphics.DrawImage(bitmap, point);
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0003B03E File Offset: 0x0003923E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0003B05D File Offset: 0x0003925D
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040003BA RID: 954
		private static readonly SolidBrush WHITE_BRUSH = new SolidBrush(Color.FromArgb(50, 214, 77, 177));

		// Token: 0x040003BB RID: 955
		private static readonly SolidBrush BLACK_BRUSH = new SolidBrush(Color.FromArgb(50, 178, 72, 157));

		// Token: 0x040003BC RID: 956
		private static readonly int START_X = 155;

		// Token: 0x040003BD RID: 957
		private static readonly int START_Y = 11;

		// Token: 0x040003BE RID: 958
		private static readonly int END_X = 852;

		// Token: 0x040003BF RID: 959
		private static readonly int END_Y = 159;

		// Token: 0x040003C0 RID: 960
		private static readonly int WHITE_TOP_WIDTH_WIDE = 25;

		// Token: 0x040003C1 RID: 961
		private static readonly int WHITE_TOP_WIDTH_NARROW = 10;

		// Token: 0x040003C2 RID: 962
		private static readonly int WHITE_BOTTOM_WIDTH = 40;

		// Token: 0x040003C3 RID: 963
		private static readonly int BLACK_WIDTH = 30;

		// Token: 0x040003C4 RID: 964
		private static readonly int BLACK_HEIGHT = 98;

		// Token: 0x040003C5 RID: 965
		private static readonly int LEFT_WHITE_WIDTH = 17;

		// Token: 0x040003C6 RID: 966
		private const int POINT_OCTAGON = 8;

		// Token: 0x040003C7 RID: 967
		private const int POINT_HEXAGON = 6;

		// Token: 0x040003C8 RID: 968
		private const int POINT_QUADRANGLE = 4;

		// Token: 0x040003C9 RID: 969
		private static readonly Point[] POINT_ARRAY_LOW_SO = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003CA RID: 970
		private static readonly Point[] POINT_ARRAY_LOW_RA = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 2, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003CB RID: 971
		private static readonly Point[] POINT_ARRAY_LOW_SI = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 3, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 3, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 2, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003CC RID: 972
		private static readonly Point[] POINT_ARRAY_DO = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 3, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 4, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 3, MelodyKeyboard.END_Y)
		};

		// Token: 0x040003CD RID: 973
		private static readonly Point[] POINT_ARRAY_RE = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 5, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 5, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 4, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003CE RID: 974
		private static readonly Point[] POINT_ARRAY_MI = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 6, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 6, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 5, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 5, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003CF RID: 975
		private static readonly Point[] POINT_ARRAY_FA = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 6, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 7, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 7, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 6, MelodyKeyboard.END_Y)
		};

		// Token: 0x040003D0 RID: 976
		private static readonly Point[] POINT_ARRAY_SO = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 8, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 7, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 7, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003D1 RID: 977
		private static readonly Point[] POINT_ARRAY_RA = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 9, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 9, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 8, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003D2 RID: 978
		private static readonly Point[] POINT_ARRAY_SI = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 10, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 10, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 9, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 9, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003D3 RID: 979
		private static readonly Point[] POINT_ARRAY_HIGH_DO = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 10, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 10 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 10 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 11, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 11, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 10, MelodyKeyboard.END_Y)
		};

		// Token: 0x040003D4 RID: 980
		private static readonly Point[] POINT_ARRAY_HIGH_RE = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 9 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 9 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 9 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 12, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 12, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 11, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 11, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 9 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003D5 RID: 981
		private static readonly Point[] POINT_ARRAY_HIGH_MI = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 10 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 13, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 13, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 12, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 12, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 10 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003D6 RID: 982
		private static readonly Point[] POINT_ARRAY_HIGH_FA = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 13, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 13 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 13 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 14, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 14, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 13, MelodyKeyboard.END_Y)
		};

		// Token: 0x040003D7 RID: 983
		private static readonly Point[] POINT_ARRAY_HIGH_SO = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 11 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 11 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 11 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 15, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 15, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 14, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 14, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 11 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003D8 RID: 984
		private static readonly Point[] POINT_ARRAY_HIGH_RA = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 12 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 12 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 12 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 16, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 16, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 15, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 15, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 12 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003D9 RID: 985
		private static readonly Point[] POINT_ARRAY_HIGH_SI = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 13 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 17, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 17, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 16, MelodyKeyboard.END_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.LEFT_WHITE_WIDTH + MelodyKeyboard.WHITE_BOTTOM_WIDTH * 16, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 13 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003DA RID: 986
		private static readonly Point[] POINT_ARRAY_LOW_FA_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003DB RID: 987
		private static readonly Point[] POINT_ARRAY_LOW_SO_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003DC RID: 988
		private static readonly Point[] POINT_ARRAY_LOW_RA_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003DD RID: 989
		private static readonly Point[] POINT_ARRAY_DO_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 2 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003DE RID: 990
		private static readonly Point[] POINT_ARRAY_RE_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 2, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003DF RID: 991
		private static readonly Point[] POINT_ARRAY_FA_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 3 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003E0 RID: 992
		private static readonly Point[] POINT_ARRAY_SO_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 4 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003E1 RID: 993
		private static readonly Point[] POINT_ARRAY_RA_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 4, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003E2 RID: 994
		private static readonly Point[] POINT_ARRAY_HIGH_DO_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 9 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 9 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 5 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003E3 RID: 995
		private static readonly Point[] POINT_ARRAY_HIGH_RE_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 9 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 10 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 10 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 9 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 6, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003E4 RID: 996
		private static readonly Point[] POINT_ARRAY_HIGH_FA_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 10 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 11 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 11 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 10 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 6 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003E5 RID: 997
		private static readonly Point[] POINT_ARRAY_HIGH_SO_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 11 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 12 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 12 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 11 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 7 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003E6 RID: 998
		private static readonly Point[] POINT_ARRAY_HIGH_RA_SHARP = new Point[]
		{
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 12 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 13 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 13 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT),
			new Point(MelodyKeyboard.START_X + MelodyKeyboard.BLACK_WIDTH * 12 + MelodyKeyboard.WHITE_TOP_WIDTH_NARROW * 8 + MelodyKeyboard.WHITE_TOP_WIDTH_WIDE * 8, MelodyKeyboard.START_Y + MelodyKeyboard.BLACK_HEIGHT)
		};

		// Token: 0x040003E7 RID: 999
		private MelodyWindow _melodyWindow;

		// Token: 0x040003E8 RID: 1000
		private MelodyModule.Key.RANK _rank;

		// Token: 0x040003E9 RID: 1001
		private SolidBrush _brush;

		// Token: 0x040003EA RID: 1002
		private IContainer components;
	}
}
