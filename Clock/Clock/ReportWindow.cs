using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Clock.Properties;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Clock
{
	// Token: 0x0200004D RID: 77
	public partial class ReportWindow : Form
	{
		// Token: 0x06000824 RID: 2084 RVA: 0x0005C464 File Offset: 0x0005A664
		static ReportWindow()
		{
			ReportWindow.ICON_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockLED), "LED");
			ReportWindow.ICON_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockSound), "サウンド");
			ReportWindow.ICON_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockWait), "ウェイト");
			ReportWindow.ICON_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockLoopStart), "ループ開始");
			ReportWindow.ICON_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockLoopEnd), "ループ終了");
			ReportWindow.ICON_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockWaitCondition), "条件待ち");
			ReportWindow.ICON_LED_COLOR_DICT.Add(Color.FromArgb(0, 10, 0), "(緑)");
			ReportWindow.ICON_LED_COLOR_DICT.Add(Color.FromArgb(0, 0, 10), "(青)");
			ReportWindow.ICON_LED_COLOR_DICT.Add(Color.FromArgb(10, 0, 0), "(赤)");
			ReportWindow.ICON_LED_COLOR_DICT.Add(Color.FromArgb(10, 10, 0), "(黄)");
			ReportWindow.ICON_LED_COLOR_DICT.Add(Color.FromArgb(10, 0, 10), "(紫)");
			ReportWindow.ICON_LED_COLOR_DICT.Add(Color.FromArgb(0, 10, 10), "(水色)");
			ReportWindow.ICON_LED_COLOR_DICT.Add(Color.FromArgb(10, 10, 10), "(白)");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockLED), "【LED】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockSound), "【サウンド】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockWait), "【ウェイト】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockCounter), "【秒カウンタ】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockIf), "【分岐】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockLoopStart), "【ループ開始】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockLoopEnd), "【ループ終了】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockSubroutine), "【サブルーチン】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockArithmetic), "【演算】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockDisplay), "【表示】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockCommunication), "【送受信】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockEvent), "【イベント】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockData), "【データ】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockOutput), "【出力】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockMessage), "【メッセージ】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockNetworkDisplay), "【表示】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockNetworkSound), "【サウンド】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockUsbOut), "【外部出力】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockJump), "【ジャンプ】");
			ReportWindow.FLOW_BLOCK_TYPE_DICT.Add(typeof(ProgramModule.BlockLabel), "【ラベル】");
			ReportWindow.NETWORK_OBJECT_TYPE_DICT.Add(typeof(NetworkObjectButton), "ボタン");
			ReportWindow.NETWORK_OBJECT_TYPE_DICT.Add(typeof(NetworkObjectLabel), "テキスト表示");
			ReportWindow.NETWORK_OBJECT_TYPE_DICT.Add(typeof(NetworkObjectList), "リスト");
			ReportWindow.NETWORK_OBJECT_TYPE_DICT.Add(typeof(NetworkObjectInput), "入力バー");
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0005C8D0 File Offset: 0x0005AAD0
		public ReportWindow(ReportWindow.REPORT report, ProgramModules program, MelodyArea melody = null, NetworkProgramModules network = null)
		{
			this.InitializeComponent();
			this.changePreview(false);
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 34;
			this.PREVIEW_SIZE = this.pictureBoxPreview.Size;
			this.labelZoomOut.Enabled = false;
			if (network != null)
			{
				this._programNetwork = network;
				this._program = new ProgramModules();
				this._program.Programs = this._programNetwork.Objects.ConvertAll<ProgramModule>((NetworkProgramModules.ObjectInfo p) => p.ProgramModule).ToArray();
			}
			else
			{
				this._program = program;
			}
			this._melody = melody;
			this._report = report;
			this._printDocument.PrintPage += this.printCallback;
			if (program != null)
			{
				this.textBoxGrade.Text = program.Report.Grade;
				this.textBoxClass.Text = program.Report.Class;
				this.textBoxNumber.Text = program.Report.Number;
				this.textBoxName.Text = program.Report.Name;
				this.textBoxComment.Text = program.Report.Comment;
			}
			else if (network != null)
			{
				this.textBoxGrade.Text = network.Report.Grade;
				this.textBoxClass.Text = network.Report.Class;
				this.textBoxNumber.Text = network.Report.Number;
				this.textBoxName.Text = network.Report.Name;
				this.textBoxComment.Text = network.Report.Comment;
			}
			else
			{
				this.textBoxGrade.Text = melody.Module.Report.Grade;
				this.textBoxClass.Text = melody.Module.Report.Class;
				this.textBoxNumber.Text = melody.Module.Report.Number;
				this.textBoxName.Text = melody.Module.Report.Name;
				this.textBoxComment.Text = melody.Module.Report.Comment;
			}
			this._maxPage = this.getMaxPage();
			this.maxPage.Text = this._maxPage.ToString();
			this.printPreview();
			if (this._maxPage > 1)
			{
				this.pageUpButton.Enabled = true;
			}
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0005CBB0 File Offset: 0x0005ADB0
		private void changePreview(bool enable)
		{
			this.pictureBoxButtonPrint.Visible = enable;
			this.pictureBoxButtonSave.Visible = enable;
			this.labelPreview.Visible = enable;
			this.labelPage.Visible = enable;
			this.labelPageSlash.Visible = enable;
			this.labelZoomIn.Visible = enable;
			this.labelZoomOut.Visible = enable;
			this.labelZoom.Visible = enable;
			this.pageDownButton.Visible = enable;
			this.pageUpButton.Visible = enable;
			this.nowPage.Visible = enable;
			this.maxPage.Visible = enable;
			this.panelPreview.Visible = enable;
			base.Height = (enable ? 768 : 384);
			this.pictureBoxButtonBack.Visible = enable;
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 34;
			this.pictureBoxButtonNext.Visible = !enable;
			this.pictureBoxButtonCancel.Visible = !enable;
			this.labelComment.Visible = !enable;
			this.labelGrade.Visible = !enable;
			this.labelClass.Visible = !enable;
			this.labelNumber.Visible = !enable;
			this.labelName.Visible = !enable;
			this.textBoxComment.Visible = !enable;
			this.textBoxGrade.Visible = !enable;
			this.textBoxClass.Visible = !enable;
			this.textBoxNumber.Visible = !enable;
			this.textBoxName.Visible = !enable;
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x000024F1 File Offset: 0x000006F1
		private void ReportWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0005CD48 File Offset: 0x0005AF48
		private void printPreview()
		{
			try
			{
				Bitmap bitmap = new Bitmap(this.A4_SIZE.Width, this.A4_SIZE.Height);
				this.pictureBoxPreview.Width = (int)((float)this.PREVIEW_SIZE.Width * this._previewScale);
				this.pictureBoxPreview.Height = (int)((float)this.PREVIEW_SIZE.Height * this._previewScale);
				this.pictureBoxPreview.Image = bitmap;
				Graphics graphics = Graphics.FromImage(this.pictureBoxPreview.Image);
				this.print(graphics, this._nowPage);
				this.nowPage.Text = this._nowPage.ToString();
			}
			catch (Exception)
			{
				GC.Collect();
			}
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x0005CE0C File Offset: 0x0005B00C
		private void print(Graphics graphics, int page)
		{
			this.printCommon(graphics, page);
			switch (this._report)
			{
			case ReportWindow.REPORT.ICON:
				this.printIcon(graphics, page);
				return;
			case ReportWindow.REPORT.FLOWCHART:
				this.printFlowchart(graphics, page);
				return;
			case ReportWindow.REPORT.MELODY:
				this.printMelody(graphics, page);
				return;
			case ReportWindow.REPORT.NETWORK:
				this.printNetwork(graphics, page);
				return;
			default:
				return;
			}
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x0005CE64 File Offset: 0x0005B064
		private void printPdf(XGraphics graphics, int page)
		{
			this.printCommonPdf(graphics, page);
			switch (this._report)
			{
			case ReportWindow.REPORT.ICON:
				this.printIconPdf(graphics, page);
				return;
			case ReportWindow.REPORT.FLOWCHART:
				this.printFlowchartPdf(graphics, page);
				return;
			case ReportWindow.REPORT.MELODY:
				this.printMelodyPdf(graphics, page);
				return;
			case ReportWindow.REPORT.NETWORK:
				this.printNetworkPdf(graphics, page);
				return;
			default:
				return;
			}
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x0005CEBC File Offset: 0x0005B0BC
		private int getMaxPage()
		{
			int num = 1;
			switch (this._report)
			{
			case ReportWindow.REPORT.ICON:
				if (this._program.Programs[0].Blocks.Count > 52)
				{
					return 2;
				}
				return num;
			case ReportWindow.REPORT.FLOWCHART:
			{
				num = 0;
				List<int> list = new List<int>();
				this._program.getSubroutineIndexes(ProgramModules.ROUTINE.MAIN, list);
				List<int> list2 = new List<int>();
				list2.Add(0);
				foreach (int num2 in list)
				{
					list2.Add(num2 + 1);
				}
				this._routinePages = new int[list2.Count];
				this._routineNames = new string[list2.Count];
				int num3 = 0;
				using (List<int>.Enumerator enumerator = list2.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						int num4 = enumerator.Current;
						List<ProgramModule.Block> sortedList = this._program.Programs[num4].getSortedList(this._program.IsBlockMode);
						this._routineNames[num3] = this._program.Programs[num4].Name;
						this._rightBlocksList.Add(sortedList);
						int num5 = 0;
						int num6 = 48;
						if (num != 0)
						{
							num6 = 68;
						}
						int num7 = sortedList.Count - (num6 + 2);
						num5++;
						if (num7 > 0)
						{
							num5 += (num7 - 1) / 68 + 1;
						}
						num += num5;
						this._routinePages[num3] = num5;
						num3++;
					}
					return num;
				}
				break;
			}
			case ReportWindow.REPORT.MELODY:
				break;
			case ReportWindow.REPORT.NETWORK:
			{
				num = 2;
				List<NetworkProgramModules.ObjectInfo> list3 = new List<NetworkProgramModules.ObjectInfo>(this._programNetwork.Objects) { this._programNetwork.ObjectInput };
				return num + list3.Select((NetworkProgramModules.ObjectInfo p) => p.ProgramModule.getSortedList(this._programNetwork.IsBlockMode).Count<ProgramModule.Block>()).Sum(delegate(int c)
				{
					if (c > 1)
					{
						return (int)Math.Ceiling((double)c / 68.0);
					}
					return 0;
				});
			}
			default:
				return num;
			}
			int num8 = this._melody.Size.Height / MelodyArea.SCORE_HEIGHT - 1;
			if (num8 > MelodyArea.SCORE_ROW_DEFAULT)
			{
				num8 -= MelodyArea.SCORE_ROW_DEFAULT;
				num += num8 / (MelodyArea.SCORE_ROW_DEFAULT + 5) + 1;
			}
			return num;
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0005D118 File Offset: 0x0005B318
		private void printCommon(Graphics graphics, int page)
		{
			graphics.DrawString("\u3000\u3000年\u3000\u3000\u3000組\u3000\u3000\u3000番\u3000名前：", ReportWindow.FONT_15, ReportWindow.STR_BRUSH, new PointF((float)(this.A4_SIZE.Width / 10), (float)(this.A4_SIZE.Height / 50)));
			string[] array = new string[]
			{
				this.textBoxGrade.Text,
				this.textBoxClass.Text,
				this.textBoxNumber.Text
			};
			PointF pointF = new PointF((float)(this.A4_SIZE.Width * 15 / 150), (float)(this.A4_SIZE.Height / 50));
			PointF pointF2 = new PointF((float)(this.A4_SIZE.Width * 30 / 150), (float)(this.A4_SIZE.Height / 50));
			PointF pointF3 = new PointF((float)(this.A4_SIZE.Width * 45 / 150), (float)(this.A4_SIZE.Height / 50));
			PointF[] array2 = new PointF[] { pointF, pointF2, pointF3 };
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Length == 1)
				{
					graphics.DrawString(" " + array[i], ReportWindow.FONT_15, ReportWindow.STR_BRUSH, array2[i]);
				}
				else
				{
					graphics.DrawString(array[i], ReportWindow.FONT_15, ReportWindow.STR_BRUSH, array2[i]);
				}
			}
			graphics.DrawString(this.textBoxName.Text, ReportWindow.FONT_15, ReportWindow.STR_BRUSH, new PointF((float)(this.A4_SIZE.Width * 73 / 150), (float)(this.A4_SIZE.Height / 50)));
			graphics.DrawString(page.ToString() + " / " + this._maxPage.ToString(), ReportWindow.FONT_10_5, ReportWindow.STR_BRUSH, new PointF((float)(this.A4_SIZE.Width * 18 / 20), (float)(this.A4_SIZE.Height / 50)));
			if (page == 1)
			{
				graphics.DrawString("コメント", ReportWindow.FONT_15, ReportWindow.STR_BRUSH, new PointF((float)(this.A4_SIZE.Width / 10), (float)(this.A4_SIZE.Height / 13)));
				Rectangle rectangle = new Rectangle(this.A4_SIZE.Width / 10, this.A4_SIZE.Height / 10, this.A4_SIZE.Width - this.A4_SIZE.Width / 10 * 2, this.A4_SIZE.Height / 3 - this.A4_SIZE.Height / 12);
				graphics.DrawRectangle(Pens.Black, rectangle);
				graphics.DrawString(this.textBoxComment.Text, ReportWindow.FONT_13, ReportWindow.STR_BRUSH, rectangle);
			}
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x0005D3F4 File Offset: 0x0005B5F4
		private void printCommonPdf(XGraphics graphics, int page)
		{
			Size size = new Size(this.A4_SIZE.Width, this.A4_SIZE.Height / 3);
			Bitmap bitmap = new Bitmap(size.Width, size.Height + 10);
			Graphics graphics2 = Graphics.FromImage(bitmap);
			graphics2.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bitmap.Size));
			int num = 20;
			graphics2.DrawString("\u3000\u3000年\u3000\u3000\u3000組\u3000\u3000\u3000番\u3000名前：", ReportWindow.FONT_15, ReportWindow.STR_BRUSH, new PointF((float)(size.Width / 10), (float)(size.Height * 3 / 50)));
			string[] array = new string[]
			{
				this.textBoxGrade.Text,
				this.textBoxClass.Text,
				this.textBoxNumber.Text
			};
			PointF pointF = new PointF((float)(size.Width * 15 / 150), (float)(size.Height * 3 / 50));
			PointF pointF2 = new PointF((float)(size.Width * 30 / 150), (float)(size.Height * 3 / 50));
			PointF pointF3 = new PointF((float)(size.Width * 46 / 150), (float)(size.Height * 3 / 50));
			PointF[] array2 = new PointF[] { pointF, pointF2, pointF3 };
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Length == 1)
				{
					graphics2.DrawString("  " + array[i], ReportWindow.FONT_15, ReportWindow.STR_BRUSH, array2[i]);
				}
				else
				{
					graphics2.DrawString(array[i], ReportWindow.FONT_15, ReportWindow.STR_BRUSH, array2[i]);
				}
			}
			graphics2.DrawString(this.textBoxName.Text, ReportWindow.FONT_15, ReportWindow.STR_BRUSH, new PointF((float)(size.Width * 74 / 150), (float)(size.Height * 3 / 50)));
			graphics2.DrawString(page.ToString() + " / " + this._maxPage.ToString(), ReportWindow.FONT_10_5, ReportWindow.STR_BRUSH, new PointF((float)(size.Width * 18 / 20), (float)(size.Height * 3 / 50)));
			if (page == 1)
			{
				graphics2.DrawString("コメント", ReportWindow.FONT_15, ReportWindow.STR_BRUSH, new PointF((float)(size.Width / 10), (float)(size.Height * 3 / 13 - num)));
				Rectangle rectangle = new Rectangle(size.Width / 10, size.Height * 3 / 10 - num, size.Width - size.Width / 10 * 2, size.Height - (size.Height * 3 / 10 - num));
				graphics2.DrawRectangle(Pens.Black, rectangle);
				graphics2.DrawString(this.textBoxComment.Text, ReportWindow.FONT_13, ReportWindow.STR_BRUSH, rectangle);
			}
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Bmp);
			graphics.DrawImage(XImage.FromStream(memoryStream), 0.0, 0.0, (double)size.Width * 0.72, (double)size.Height * 0.72);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x0005D750 File Offset: 0x0005B950
		private void printIcon(Graphics graphics, int page)
		{
			StringFormat stringFormat = new StringFormat();
			stringFormat.LineAlignment = StringAlignment.Center;
			int num = this.A4_SIZE.Height / 19;
			if (page == 1)
			{
				num = this.A4_SIZE.Height / 3 + this.A4_SIZE.Height * 9 / 200;
			}
			graphics.DrawString("プログラム", ReportWindow.FONT_15, ReportWindow.STR_BRUSH, new PointF((float)(this.A4_SIZE.Width / 20), (float)num));
			int num2 = this.A4_SIZE.Width / 23;
			int num3 = this.A4_SIZE.Height / 3 + this.A4_SIZE.Height * 28 / 400;
			int num4 = 26;
			int num5 = this.A4_SIZE.Width / 6;
			int num6 = 25;
			int num7 = 0;
			int num8 = 0;
			int num9 = 1;
			if (page == 2)
			{
				num3 = this.A4_SIZE.Height / 13;
				num6 = 40;
			}
			for (ProgramModule.Block block = this._program.Programs[0].Start; block != null; block = block.Next)
			{
				if (block != this._program.Programs[0].Start && block != this._program.Programs[0].End)
				{
					if (page == 2 && num9 <= 50)
					{
						num9++;
					}
					else
					{
						if (page == 1 && num9 == 51)
						{
							break;
						}
						Rectangle rectangle = new Rectangle(num2 + num7, num3 + num4 * num8, num5, num4);
						Rectangle rectangle2 = new Rectangle(num2 + num5 + num7, num3 + num4 * num8, this.A4_SIZE.Width / 2 - (num2 + num5), num4);
						graphics.DrawRectangle(Pens.Black, rectangle);
						graphics.DrawRectangle(Pens.Black, rectangle2);
						num8++;
						if (num8 == num6)
						{
							num8 = 0;
							num7 = this.A4_SIZE.Width / 2 - num2;
						}
						this.viewIcon(graphics, block, rectangle, rectangle2, stringFormat, num9);
						num9++;
					}
				}
			}
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x0005D940 File Offset: 0x0005BB40
		private void printIconPdf(XGraphics graphics, int page)
		{
			Bitmap bitmap;
			if (page == 1)
			{
				bitmap = new Bitmap(this.A4_SIZE.Width, this.A4_SIZE.Height * 2 / 3);
			}
			else
			{
				bitmap = new Bitmap(this.A4_SIZE.Width, this.A4_SIZE.Height);
			}
			Graphics graphics2 = Graphics.FromImage(bitmap);
			graphics2.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bitmap.Size));
			StringFormat stringFormat = new StringFormat();
			stringFormat.LineAlignment = StringAlignment.Center;
			graphics2.DrawString("プログラム", ReportWindow.FONT_15, ReportWindow.STR_BRUSH, new PointF((float)(this.A4_SIZE.Width / 20), 0f));
			int num = this.A4_SIZE.Width / 40;
			int num2 = this.A4_SIZE.Height * 5 / 200;
			int num3 = 25;
			int num4 = this.A4_SIZE.Width / 6;
			int num5 = 25;
			int num6 = 0;
			int num7 = 0;
			int num8 = 1;
			if (page == 2)
			{
				num5 = 40;
			}
			for (ProgramModule.Block block = this._program.Programs[0].Start; block != null; block = block.Next)
			{
				if (block != this._program.Programs[0].Start && block != this._program.Programs[0].End)
				{
					if (page == 2 && num8 <= 50)
					{
						num8++;
					}
					else
					{
						if (page == 1 && num8 == 51)
						{
							break;
						}
						int num9 = 36;
						Rectangle rectangle = new Rectangle(num + num6, num2 + num3 * num7, num4, num3);
						Rectangle rectangle2 = new Rectangle(num + num4 + num6, num2 + num3 * num7, (this.A4_SIZE.Width - num9) / 2 - (num + num4), num3);
						graphics2.DrawRectangle(Pens.Black, rectangle);
						graphics2.DrawRectangle(Pens.Black, rectangle2);
						num7++;
						if (num7 == num5)
						{
							num7 = 0;
							num6 = (this.A4_SIZE.Width - num9) / 2 - num;
						}
						this.viewIcon(graphics2, block, rectangle, rectangle2, stringFormat, num8);
						num8++;
					}
				}
			}
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Bmp);
			if (page == 1)
			{
				graphics.DrawImage(XImage.FromStream(memoryStream), 0.0, (double)(this.A4_SIZE.Height / 3 - 70));
				return;
			}
			graphics.DrawImage(XImage.FromStream(memoryStream), 0.0, (double)(this.A4_SIZE.Height * 2 / 50));
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x0005DBB8 File Offset: 0x0005BDB8
		private void viewIcon(Graphics g, ProgramModule.Block block, Rectangle rectangle1, Rectangle rectangle2, StringFormat format, int j)
		{
			string detail = block.getDetail();
			string text;
			if (block.GetType() == typeof(ProgramModule.BlockWaitCondition) || block.GetType() == typeof(ProgramModule.BlockLoopEnd))
			{
				text = detail.Replace("\r\n", "");
			}
			else
			{
				text = detail.Replace("\r\n", ",");
			}
			g.DrawString(text, ReportWindow.FONT_10_5, ReportWindow.STR_BRUSH, rectangle2, format);
			string text2 = ReportWindow.ICON_BLOCK_TYPE_DICT[block.GetType()];
			if (block.GetType() == typeof(ProgramModule.BlockLED))
			{
				Color color = Color.FromArgb(((ProgramModule.BlockLED)block).Red, ((ProgramModule.BlockLED)block).Green, ((ProgramModule.BlockLED)block).Blue);
				if (ReportWindow.ICON_LED_COLOR_DICT.ContainsKey(color))
				{
					text2 += ReportWindow.ICON_LED_COLOR_DICT[color];
				}
				else
				{
					text2 = string.Concat(new string[]
					{
						text2,
						"(",
						((ProgramModule.BlockLED)block).Red.ToString(),
						",",
						((ProgramModule.BlockLED)block).Green.ToString(),
						",",
						((ProgramModule.BlockLED)block).Blue.ToString(),
						")"
					});
				}
			}
			g.DrawString(j.ToString() + " : " + text2, ReportWindow.FONT_10_5, ReportWindow.STR_BRUSH, rectangle1, format);
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0005DD50 File Offset: 0x0005BF50
		private void printFlowchart(Graphics graphics, int page)
		{
			int num = FlowchartArea.AREA_SIZE.Width;
			int num2 = FlowchartArea.AREA_SIZE.Height;
			if (this._program.IsBlockMode)
			{
				num = FlowchartArea.AREA_SIZE_BLOCK.Width;
				num2 = FlowchartArea.AREA_SIZE_BLOCK.Height;
			}
			Bitmap bitmap = new Bitmap(num, num2);
			Graphics graphics2 = Graphics.FromImage(bitmap);
			List<ProgramModule.Block> list = null;
			int num3 = 0;
			string text = "";
			this.getRoutine(page, ref list, ref text, ref num3);
			int num4 = 420;
			if (page >= 2)
			{
				num4 = 105;
			}
			graphics.DrawString("【" + text + "】", ReportWindow.FONT_8, ReportWindow.STR_BRUSH, new PointF(30f, (float)num4));
			Bitmap bitmap2 = this.viewBlocks(graphics2, bitmap, list, num, num2, 500);
			int num5 = (int)(500f * ((float)num2 / (float)num));
			Bitmap bitmap3 = new Bitmap(500, num5);
			Graphics graphics3 = Graphics.FromImage(bitmap3);
			graphics3.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics3.DrawImage(bitmap2, 0, 0, 475, (int)((double)num5 * 0.95));
			int num6 = 435;
			if (page >= 2)
			{
				num6 = 120;
			}
			Rectangle rectangle = new Rectangle(30, num6, 500, num5);
			graphics.DrawRectangle(Pens.Black, rectangle);
			graphics.DrawImage(bitmap3, 30, num6);
			int num7 = 0;
			if (page >= 2)
			{
				num7 = 300;
			}
			Rectangle rectangle2 = new Rectangle(540, num6, 250, num5 + num7);
			graphics.DrawRectangle(Pens.Black, rectangle2);
			string flowchartDetails = this.getFlowchartDetails(page, num3);
			graphics.DrawString(flowchartDetails, ReportWindow.FONT_7, ReportWindow.STR_BRUSH, rectangle2);
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0005DEF8 File Offset: 0x0005C0F8
		private void printFlowchartPdf(XGraphics graphics, int page)
		{
			int num = FlowchartArea.AREA_SIZE.Width;
			int num2 = FlowchartArea.AREA_SIZE.Height;
			if (this._program.IsBlockMode)
			{
				num = FlowchartArea.AREA_SIZE_BLOCK.Width;
				num2 = FlowchartArea.AREA_SIZE_BLOCK.Height;
			}
			Bitmap bitmap = new Bitmap(num, num2);
			Graphics graphics2 = Graphics.FromImage(bitmap);
			graphics2.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bitmap.Size));
			List<ProgramModule.Block> list = null;
			int num3 = 0;
			string text = "";
			this.getRoutine(page, ref list, ref text, ref num3);
			int num4 = 305;
			if (page >= 2)
			{
				num4 = 75;
			}
			Bitmap bitmap2 = new Bitmap(350, 15);
			Graphics graphics3 = Graphics.FromImage(bitmap2);
			graphics3.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bitmap.Size));
			graphics3.DrawString("【" + text + "】", ReportWindow.FONT_8, ReportWindow.STR_BRUSH, new PointF(0f, 0f));
			MemoryStream memoryStream = new MemoryStream();
			bitmap2.Save(memoryStream, ImageFormat.Bmp);
			graphics.DrawImage(XImage.FromStream(memoryStream), 30.0, (double)num4);
			Bitmap bitmap3 = this.viewBlocks(graphics2, bitmap, list, num, num2, 350);
			int num5 = (int)((double)num2 * (350.0 / (double)num));
			Bitmap bitmap4 = new Bitmap(455, (int)((double)num5 * 1.3));
			Graphics graphics4 = Graphics.FromImage(bitmap4);
			graphics4.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bitmap.Size));
			graphics4.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics4.DrawImage(bitmap3, 0, 0, 455, (int)((double)num5 * 1.3));
			int num6 = 320;
			if (page >= 2)
			{
				num6 = 90;
			}
			XRect xrect = new XRect(30.0, (double)num6, 350.0, (double)num5);
			graphics.DrawRectangle(XPens.Black, xrect);
			MemoryStream memoryStream2 = new MemoryStream();
			bitmap4.Save(memoryStream2, ImageFormat.Bmp);
			graphics.DrawImage(XImage.FromStream(memoryStream2), 32.0, (double)(num6 + 2));
			int num7 = 0;
			if (page >= 2)
			{
				num7 = 200;
			}
			XRect xrect2 = new XRect(390.0, (double)num6, 175.0, (double)(num5 + num7));
			graphics.DrawRectangle(XPens.Black, xrect2);
			Bitmap bitmap5 = new Bitmap(227, (int)((double)(num5 + num7) * 1.3));
			Graphics graphics5 = Graphics.FromImage(bitmap5);
			graphics5.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bitmap.Size));
			string flowchartDetails = this.getFlowchartDetails(page, num3);
			graphics5.DrawString(flowchartDetails, ReportWindow.FONT_6_5, ReportWindow.STR_BRUSH, 0f, 0f);
			MemoryStream memoryStream3 = new MemoryStream();
			bitmap5.Save(memoryStream3, ImageFormat.Bmp);
			graphics.DrawImage(XImage.FromStream(memoryStream3), 392.0, (double)(num6 + 2));
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0005E1E0 File Offset: 0x0005C3E0
		private void getRoutine(int page, ref List<ProgramModule.Block> rightBlocks, ref string routineName, ref int routinePage)
		{
			int num = 0;
			for (int i = 0; i < this._routinePages.Length; i++)
			{
				for (int j = 0; j < this._routinePages[i]; j++)
				{
					num++;
					if (num == page)
					{
						rightBlocks = this._rightBlocksList[i];
						routineName = this._routineNames[i];
						routinePage = j + 1;
						break;
					}
				}
				if (rightBlocks != null)
				{
					break;
				}
			}
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x0005E244 File Offset: 0x0005C444
		private Bitmap viewBlocks(Graphics g, Bitmap bmp, List<ProgramModule.Block> rightBlocks, int areaWidth, int areaHeight, int imageWidth)
		{
			if ((this._report == ReportWindow.REPORT.FLOWCHART && this._program.IsBlockMode) || (this._report == ReportWindow.REPORT.NETWORK && this._programNetwork.IsBlockMode))
			{
				return this.viewBlocksBlock(g, bmp, rightBlocks, areaWidth, areaHeight, imageWidth);
			}
			return this.viewBlocksFlowchart(g, bmp, rightBlocks, areaWidth, areaHeight, imageWidth);
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0005E29C File Offset: 0x0005C49C
		private Bitmap viewBlocksFlowchart(Graphics g, Bitmap bmp, List<ProgramModule.Block> rightBlocks, int areaWidth, int areaHeight, int imageWidth)
		{
			int num = areaWidth;
			int num2 = areaHeight;
			int num3 = 0;
			int num4 = 0;
			foreach (ProgramModule.Block block in rightBlocks)
			{
				num = Math.Min(num, block.Location.X);
				num3 = Math.Max(num3, block.Location.X);
				num2 = Math.Min(num2, block.Location.Y);
				num4 = Math.Max(num4, block.Location.Y);
			}
			num = Math.Max(0, num - 20);
			num2 = Math.Max(0, num2 - 70);
			num3 = Math.Min(areaWidth, num3 + ProgramModule.Block.BLOCK_SIZE.Width + 20);
			num4 = Math.Min(areaHeight, num4 + ProgramModule.Block.BLOCK_SIZE.Height + 70);
			if ((float)(num3 - num) * ((float)areaHeight / (float)areaWidth) >= (float)(num4 - num2))
			{
				num4 = (int)((float)(num3 - num) * ((float)areaHeight / (float)areaWidth)) + num2;
			}
			else
			{
				num3 = (int)((float)(num4 - num2) * ((float)areaWidth / (float)areaHeight)) + num;
			}
			int num5 = ProgramModule.BlockEnd.INITIAL_LOCATION.X + ProgramModule.Block.BLOCK_SIZE.Width;
			int num6 = ProgramModule.BlockEnd.INITIAL_LOCATION.Y + ProgramModule.Block.BLOCK_SIZE.Height;
			if (num3 < num5 && num4 < num6)
			{
				num3 = num5;
				num4 = num6;
			}
			int num7 = num3 - num;
			int num8 = num4 - num2;
			if (num7 >= num8)
			{
				num8 = (int)((float)areaHeight * ((float)num7 / (float)areaWidth));
			}
			else
			{
				num7 = (int)((float)areaWidth * ((float)num8 / (float)areaHeight));
			}
			int num9 = 1;
			this._detailBlocks.Clear();
			bool flag = false;
			if ((float)num7 <= 629f && (double)num8 <= 889.58571428571429)
			{
				flag = true;
			}
			foreach (ProgramModule.Block block2 in rightBlocks)
			{
				if (block2.GetType() == typeof(ProgramModule.BlockStart) || block2.GetType() == typeof(ProgramModule.BlockEnd))
				{
					block2.OnPaint(g, flag, 0, true);
				}
				else
				{
					block2.OnPaint(g, flag, flag ? 0 : num9, true);
					num9++;
					this._detailBlocks.Add(block2);
				}
			}
			Rectangle rectangle = new Rectangle(num, num2, num7, num8);
			return bmp.Clone(rectangle, bmp.PixelFormat);
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x0005E51C File Offset: 0x0005C71C
		private Bitmap viewBlocksBlock(Graphics g, Bitmap bmp, List<ProgramModule.Block> rightBlocks, int areaWidth, int areaHeight, int imageWidth)
		{
			int num = areaWidth;
			int num2 = areaHeight;
			int num3 = 0;
			int num4 = 0;
			foreach (ProgramModule.Block block in rightBlocks)
			{
				num = Math.Min(num, block.LocationBlock.X - 20);
				num3 = Math.Max(num3, block.LocationBlock.X + block.SizeBlock.Width + 20);
				num2 = Math.Min(num2, block.LocationBlock.Y - 70);
				num4 = Math.Max(num4, block.LocationBlock.Y + block.SizeBlock.Height + 70);
			}
			num = Math.Max(0, num);
			num2 = Math.Max(0, num2);
			num3 = Math.Min(areaWidth, num3);
			num4 = Math.Min(areaHeight, num4);
			if ((float)(num3 - num) * ((float)areaHeight / (float)areaWidth) >= (float)(num4 - num2))
			{
				num4 = (int)((float)(num3 - num) * ((float)areaHeight / (float)areaWidth)) + num2;
			}
			else
			{
				num3 = (int)((float)(num4 - num2) * ((float)areaWidth / (float)areaHeight)) + num;
			}
			int num5 = num3 - num;
			int num6 = num4 - num2;
			if (num5 >= num6)
			{
				num6 = (int)((float)areaHeight * ((float)num5 / (float)areaWidth));
			}
			else
			{
				num5 = (int)((float)areaWidth * ((float)num6 / (float)areaHeight));
			}
			int num7 = 1;
			this._detailBlocks.Clear();
			bool flag = false;
			if ((float)num5 <= 629f && (double)num6 <= 889.58571428571429)
			{
				flag = true;
			}
			foreach (ProgramModule.Block block2 in rightBlocks)
			{
				if (block2.GetType() == typeof(ProgramModule.BlockStart) || block2.GetType() == typeof(ProgramModule.BlockEnd))
				{
					block2.OnPaintBlock(g, flag, 0, true);
				}
				else
				{
					block2.OnPaintBlock(g, flag, flag ? 0 : num7, true);
					num7++;
					this._detailBlocks.Add(block2);
				}
			}
			Rectangle rectangle = new Rectangle(num, num2, num5, num6);
			return bmp.Clone(rectangle, bmp.PixelFormat);
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x0005E768 File Offset: 0x0005C968
		private string getFlowchartDetails(int page, int routinePage)
		{
			string text = "";
			int num = 0;
			int num2 = this._detailBlocks.Count;
			if (page >= 2 && routinePage >= 2)
			{
				if (page <= this._routinePages[0])
				{
					num = 48 + 68 * (routinePage - 2);
					num2 = num2 - 48 - 68 * (routinePage - 2);
				}
				else
				{
					num = 68 * (routinePage - 1);
					num2 -= 68 * (routinePage - 1);
				}
			}
			if (page == 1 && num2 > 48)
			{
				num2 = 48;
			}
			else if (page >= 2 && num2 > 68)
			{
				num2 = 68;
			}
			int num3 = num + num2;
			for (int i = num; i < num3; i++)
			{
				ProgramModule.Block block = this._detailBlocks[i];
				string text2 = "";
				if (block.GetType() == typeof(ProgramModule.BlockLED))
				{
					text2 = string.Concat(new string[]
					{
						"(",
						((ProgramModule.BlockLED)block).Red.ToString(),
						",",
						((ProgramModule.BlockLED)block).Green.ToString(),
						",",
						((ProgramModule.BlockLED)block).Blue.ToString(),
						")"
					});
				}
				string text3 = "";
				if (block.GetType() == typeof(ProgramModule.BlockIf))
				{
					text3 = "(" + ProgramModule.BlockIf.CONDITION_ITEMS[(int)((ProgramModule.BlockIf)block).Condition] + ")";
				}
				string text4 = "";
				if (block.GetType() == typeof(ProgramModule.BlockSubroutine))
				{
					text4 = FlowchartWindow.getSubroutineNames()[((ProgramModule.BlockSubroutine)block).Index];
				}
				string text5 = block.getDetail();
				foreach (char c in ReportWindow.REMOVE_CHARS)
				{
					text5 = text5.Replace(c.ToString(), "");
				}
				text = string.Concat(new string[]
				{
					text,
					(i + 1).ToString(),
					":",
					ReportWindow.FLOW_BLOCK_TYPE_DICT[block.GetType()],
					text2,
					text3,
					text4,
					text5,
					"\r\n"
				});
			}
			if (text != "")
			{
				text = text.Remove(text.Length - "\r\n".Length);
			}
			return text;
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x0005E9D0 File Offset: 0x0005CBD0
		private void printMelody(Graphics graphics, int page)
		{
			Bitmap bitmap = this.viewMelody(page);
			int num = 470;
			if (page >= 2)
			{
				num = 100;
			}
			graphics.DrawImage(bitmap, 60, num);
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x0005E9FC File Offset: 0x0005CBFC
		private void printMelodyPdf(XGraphics graphics, int page)
		{
			Image image = this.viewMelody(page);
			int num = 330;
			if (page >= 2)
			{
				num = 70;
			}
			MemoryStream memoryStream = new MemoryStream();
			image.Save(memoryStream, ImageFormat.Bmp);
			graphics.DrawImage(XImage.FromStream(memoryStream), 35.0, (double)num);
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0005EA48 File Offset: 0x0005CC48
		private Bitmap viewMelody(int page)
		{
			int width = this._melody.Size.Width;
			int height = this._melody.Size.Height;
			Bitmap bitmap = new Bitmap(width, height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle clientRectangle = this._melody.ClientRectangle;
			PaintEventArgs paintEventArgs = new PaintEventArgs(graphics, clientRectangle);
			base.InvokePaintBackground(this._melody, paintEventArgs);
			base.InvokePaint(this._melody, paintEventArgs);
			Bitmap bitmap2 = bitmap;
			int num = height;
			if (this._maxPage > 1)
			{
				int num2 = MelodyArea.SCORE_HEIGHT * MelodyArea.SCORE_ROW_DEFAULT * (page - 1);
				if (page >= 3)
				{
					num2 += MelodyArea.SCORE_HEIGHT * 5 * (page - 2);
				}
				num -= num2;
				if (page == 1)
				{
					if (num > MelodyArea.SCORE_HEIGHT * MelodyArea.SCORE_ROW_DEFAULT)
					{
						num = MelodyArea.SCORE_HEIGHT * MelodyArea.SCORE_ROW_DEFAULT;
					}
				}
				else if (page >= 2 && num > MelodyArea.SCORE_HEIGHT * (MelodyArea.SCORE_ROW_DEFAULT + 5))
				{
					num = MelodyArea.SCORE_HEIGHT * (MelodyArea.SCORE_ROW_DEFAULT + 5);
				}
				Rectangle rectangle = new Rectangle(0, num2, width, num);
				bitmap2 = bitmap.Clone(rectangle, bitmap.PixelFormat);
			}
			int num3 = (int)((double)num * (700.0 / (double)width));
			Bitmap bitmap3 = new Bitmap(700, num3);
			Graphics graphics2 = Graphics.FromImage(bitmap3);
			graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics2.DrawImage(bitmap2, 0, 0, 700, num3);
			return bitmap3;
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0005EB9C File Offset: 0x0005CD9C
		private void printNetwork(Graphics graphics, int page)
		{
			if (page == 1)
			{
				graphics.DrawImage(this.viewNetwork(), 60, 470);
				graphics.DrawRectangle(Pens.Black, new Rectangle(400, 435, 400, 700));
				string text = "";
				IEnumerable<Control> enumerable = this.searchObjects(NetworkWindow.Instance.ObjectAreaAll);
				NetworkProgramModules objs = new NetworkProgramModules();
				this._programNetwork.Objects.ConvertAll<NetworkProgramModules.ObjectInfo>(delegate(NetworkProgramModules.ObjectInfo x)
				{
					objs.addObject(x);
					return x;
				});
				objs.addObject(this._programNetwork.ObjectInput);
				foreach (var <>f__AnonymousType in enumerable.Select((Control item, int index) => new { item, index }))
				{
					text += string.Format("{0}: {1}\n", <>f__AnonymousType.index + 1, objs.getObject(<>f__AnonymousType.item).getObjectName());
				}
				graphics.DrawString(text, ReportWindow.FONT_10_5, ReportWindow.STR_BRUSH, new PointF(410f, 445f));
				return;
			}
			Size size = NetworkFlowchartArea.AREA_SIZE;
			if (this._programNetwork.IsBlockMode)
			{
				size = NetworkFlowchartArea.AREA_SIZE_BLOCK;
			}
			Bitmap bitmap = new Bitmap(size.Width, size.Height);
			Graphics graphics2 = Graphics.FromImage(bitmap);
			graphics2.FillRectangle(Brushes.White, graphics2.VisibleClipBounds);
			List<NetworkProgramModules.ObjectInfo> list = new List<NetworkProgramModules.ObjectInfo>(this._programNetwork.Objects) { this._programNetwork.ObjectInput };
			list.Add(this._programNetwork.ObjectStage);
			IEnumerable<int> enumerable2 = list.Select((NetworkProgramModules.ObjectInfo p) => p.ProgramModule.getSortedList(this._programNetwork.IsBlockMode).Count<ProgramModule.Block>()).Select(delegate(int c)
			{
				if (c > 1)
				{
					return (int)Math.Ceiling((double)c / 68.0);
				}
				return 0;
			}).ToList<int>();
			List<Tuple<NetworkProgramModules.ObjectInfo, int>> list2 = new List<Tuple<NetworkProgramModules.ObjectInfo, int>>();
			foreach (var <>f__AnonymousType2 in enumerable2.Select((int item, int index) => new { item, index }))
			{
				for (int i = 0; i < <>f__AnonymousType2.item; i++)
				{
					list2.Add(new Tuple<NetworkProgramModules.ObjectInfo, int>(list[<>f__AnonymousType2.index], i + 1));
				}
			}
			NetworkProgramModules.ObjectInfo item2 = list2[page - 2].Item1;
			List<ProgramModule.Block> sortedList = item2.ProgramModule.getSortedList(this._programNetwork.IsBlockMode);
			string objectName = item2.getObjectName();
			graphics.DrawString("【" + objectName + "】", ReportWindow.FONT_8, ReportWindow.STR_BRUSH, new PointF(30f, 105f));
			Bitmap bitmap2 = this.viewBlocks(graphics2, bitmap, sortedList, size.Width, size.Height, 500);
			int num = (int)(500f * ((float)size.Height / (float)size.Width));
			Bitmap bitmap3 = new Bitmap(500, num);
			Graphics graphics3 = Graphics.FromImage(bitmap3);
			graphics3.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics3.DrawImage(bitmap2, 0, 0, 475, (int)((double)num * 0.95));
			Rectangle rectangle = new Rectangle(30, 120, 500, num);
			graphics.DrawImage(bitmap3, 30, 120);
			graphics.DrawRectangle(Pens.Black, rectangle);
			int num2 = 0;
			if (page >= 2)
			{
				num2 = 300;
			}
			Rectangle rectangle2 = new Rectangle(540, 120, 250, num + num2);
			graphics.DrawRectangle(Pens.Black, rectangle2);
			string networkFlowchartDetails = this.getNetworkFlowchartDetails(sortedList, list2, page);
			graphics.DrawString(networkFlowchartDetails, ReportWindow.FONT_7, ReportWindow.STR_BRUSH, rectangle2);
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x0005EF94 File Offset: 0x0005D194
		private void printNetworkPdf(XGraphics graphics, int page)
		{
			if (page == 1)
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					this.viewNetwork().Save(memoryStream, ImageFormat.Bmp);
					graphics.DrawImage(XImage.FromStream(memoryStream), 35.0, 330.0);
				}
				string text = "";
				IEnumerable<Control> enumerable = this.searchObjects(NetworkWindow.Instance.ObjectAreaAll);
				NetworkProgramModules objs = new NetworkProgramModules();
				this._programNetwork.Objects.ConvertAll<NetworkProgramModules.ObjectInfo>(delegate(NetworkProgramModules.ObjectInfo x)
				{
					objs.addObject(x);
					return x;
				});
				objs.addObject(this._programNetwork.ObjectInput);
				foreach (var <>f__AnonymousType in enumerable.Select((Control item, int index) => new { item, index }))
				{
					text += string.Format("{0}: {1}\n", <>f__AnonymousType.index + 1, objs.getObject(<>f__AnonymousType.item).getObjectName());
				}
				using (MemoryStream memoryStream2 = new MemoryStream())
				{
					using (Bitmap bitmap = new Bitmap(400, 700))
					{
						using (Graphics graphics2 = Graphics.FromImage(bitmap))
						{
							graphics2.FillRectangle(Brushes.White, graphics2.VisibleClipBounds);
							graphics2.DrawString(text, ReportWindow.FONT_10_5, ReportWindow.STR_BRUSH, new PointF(0f, 0f));
							bitmap.Save(memoryStream2, ImageFormat.Bmp);
							graphics.DrawImage(XImage.FromStream(memoryStream2), 305.0, 315.0);
						}
					}
				}
				graphics.DrawRectangle(XPens.Black, new XRect(300.0, 310.0, 250.0, 500.0));
				return;
			}
			Size size = NetworkFlowchartArea.AREA_SIZE;
			if (this._programNetwork.IsBlockMode)
			{
				size = NetworkFlowchartArea.AREA_SIZE_BLOCK;
			}
			Bitmap bitmap2 = new Bitmap(size.Width, size.Height);
			List<NetworkProgramModules.ObjectInfo> list = new List<NetworkProgramModules.ObjectInfo>(this._programNetwork.Objects) { this._programNetwork.ObjectInput };
			list.Add(this._programNetwork.ObjectStage);
			IEnumerable<int> enumerable2 = list.Select((NetworkProgramModules.ObjectInfo p) => p.ProgramModule.getSortedList(this._programNetwork.IsBlockMode).Count<ProgramModule.Block>()).Select(delegate(int c)
			{
				if (c > 1)
				{
					return (int)Math.Ceiling((double)c / 68.0);
				}
				return 0;
			}).ToList<int>();
			List<Tuple<NetworkProgramModules.ObjectInfo, int>> list2 = new List<Tuple<NetworkProgramModules.ObjectInfo, int>>();
			foreach (var <>f__AnonymousType2 in enumerable2.Select((int item, int index) => new { item, index }))
			{
				for (int i = 0; i < <>f__AnonymousType2.item; i++)
				{
					list2.Add(new Tuple<NetworkProgramModules.ObjectInfo, int>(list[<>f__AnonymousType2.index], i + 1));
				}
			}
			NetworkProgramModules.ObjectInfo item2 = list2[page - 2].Item1;
			List<ProgramModule.Block> sortedList = item2.ProgramModule.getSortedList(this._programNetwork.IsBlockMode);
			string objectName = item2.getObjectName();
			Bitmap bitmap3 = new Bitmap(350, 15);
			Graphics graphics3 = Graphics.FromImage(bitmap3);
			graphics3.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bitmap2.Size));
			graphics3.DrawString("【" + objectName + "】", ReportWindow.FONT_8, ReportWindow.STR_BRUSH, new PointF(0f, 0f));
			MemoryStream memoryStream3 = new MemoryStream();
			bitmap3.Save(memoryStream3, ImageFormat.Png);
			graphics.DrawImage(XImage.FromStream(memoryStream3), 30.0, 75.0);
			Graphics graphics4 = Graphics.FromImage(bitmap2);
			graphics4.FillRectangle(Brushes.White, graphics4.VisibleClipBounds);
			this.viewBlocks(graphics4, bitmap2, sortedList, size.Width, size.Height, 500);
			Bitmap bitmap4 = this.viewBlocks(graphics4, bitmap2, sortedList, size.Width, size.Height, 350);
			int num = (int)((double)size.Height * (350.0 / (double)size.Width));
			Bitmap bitmap5 = new Bitmap(455, (int)((double)num * 1.3));
			Graphics graphics5 = Graphics.FromImage(bitmap5);
			graphics5.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bitmap2.Size));
			graphics5.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics5.DrawImage(bitmap4, 0, 0, 455, (int)((double)num * 1.3));
			XRect xrect = new XRect(30.0, 90.0, 350.0, (double)num);
			graphics.DrawRectangle(XPens.Black, xrect);
			MemoryStream memoryStream4 = new MemoryStream();
			bitmap5.Save(memoryStream4, ImageFormat.Png);
			graphics.DrawImage(XImage.FromStream(memoryStream4), 32.0, 92.0);
			int num2 = 0;
			if (page >= 2)
			{
				num2 = 200;
			}
			XRect xrect2 = new XRect(390.0, 90.0, 175.0, (double)(num + num2));
			graphics.DrawRectangle(XPens.Black, xrect2);
			string networkFlowchartDetails = this.getNetworkFlowchartDetails(sortedList, list2, page);
			Bitmap bitmap6 = new Bitmap(227, (int)((double)(num + num2) * 1.3));
			Graphics graphics6 = Graphics.FromImage(bitmap6);
			graphics6.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bitmap2.Size));
			graphics6.DrawString(networkFlowchartDetails, ReportWindow.FONT_7, ReportWindow.STR_BRUSH, 0f, 0f);
			MemoryStream memoryStream5 = new MemoryStream();
			bitmap6.Save(memoryStream5, ImageFormat.Png);
			graphics.DrawImage(XImage.FromStream(memoryStream5), 392.0, 92.0);
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x0005F5E8 File Offset: 0x0005D7E8
		private string getNetworkFlowchartDetails(List<ProgramModule.Block> blocks, List<Tuple<NetworkProgramModules.ObjectInfo, int>> objects, int currentpage)
		{
			List<string> list = (from p in blocks
				where !(p is ProgramModule.BlockEnd)
				select ReportWindow.FLOW_BLOCK_TYPE_DICT[p.GetType()] + " " + p.getDetail()).Select(delegate(string p)
			{
				foreach (char c in ReportWindow.REMOVE_CHARS)
				{
					p = p.Replace(c.ToString(), "");
				}
				return p;
			}).Skip((objects[currentpage - 2].Item2 - 1) * 68).Take(68)
				.ToList<string>();
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = string.Format("{0}: {1}", i + 1, list[i]);
				if (i != 0 && list[i].Contains("【イベント】"))
				{
					list[i] = "\n" + list[i];
				}
			}
			return string.Join("\n", list);
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x0005F6F4 File Offset: 0x0005D8F4
		private Bitmap viewNetwork()
		{
			int width = NetworkWindow.Instance.ObjectAreaAll.Size.Width;
			int height = NetworkWindow.Instance.ObjectAreaAll.Size.Height;
			Bitmap bitmap = new Bitmap(width, height);
			NetworkWindow.Instance.ObjectAreaAll.DrawToBitmap(bitmap, NetworkWindow.Instance.ObjectAreaAll.ClientRectangle);
			List<Point> list = new List<Point>();
			IEnumerable<Control> enumerable = this.searchObjects(NetworkWindow.Instance.ObjectAreaAll);
			NetworkProgramModules objs = new NetworkProgramModules();
			this._programNetwork.Objects.ConvertAll<NetworkProgramModules.ObjectInfo>(delegate(NetworkProgramModules.ObjectInfo x)
			{
				objs.addObject(x);
				return x;
			});
			objs.addObject(this._programNetwork.ObjectInput);
			foreach (var <>f__AnonymousType in enumerable.Select((Control item, int index) => new { item, index }))
			{
				list.Add(<>f__AnonymousType.item.Location);
				Console.WriteLine(string.Format("{0}: {1}", <>f__AnonymousType.index + 1, objs.getObject(<>f__AnonymousType.item).getObjectName()));
			}
			return bitmap;
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x0005F858 File Offset: 0x0005DA58
		private IEnumerable<Control> searchObjects(Control parent)
		{
			List<Control> list = new List<Control>();
			foreach (object obj in parent.Controls)
			{
				Control control = (Control)obj;
				if (control is NetworkObjectInterface)
				{
					list.Add(control);
				}
				list.AddRange(this.searchObjects(control));
			}
			return list;
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x0005F8D0 File Offset: 0x0005DAD0
		private void pictureBoxButtonPrint_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonPrint.Image = Resources.popup_btn_052;
			}
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x0005F8EF File Offset: 0x0005DAEF
		private void pictureBoxButtonPrint_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonPrint.Image = Resources.popup_btn_051;
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x0005F901 File Offset: 0x0005DB01
		private void pictureBoxButtonPrint_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonPrint.Image = Resources.popup_btn_050;
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x0005F913 File Offset: 0x0005DB13
		private void pictureBoxButtonPrint_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonPrint.Image = Resources.popup_btn_051;
				this.printStart();
			}
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x0005F938 File Offset: 0x0005DB38
		private void printCallback(object sender, PrintPageEventArgs e)
		{
			this.print(e.Graphics, this._printPage);
			if (this._printPage == this._maxPage)
			{
				e.HasMorePages = false;
			}
			else
			{
				e.HasMorePages = true;
			}
			this._printPage++;
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x0005F978 File Offset: 0x0005DB78
		private void pictureBoxButtonSave_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonSave.Image = Resources.popup_btn_062;
			}
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x0005F997 File Offset: 0x0005DB97
		private void pictureBoxButtonSave_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonSave.Image = Resources.popup_btn_061;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x0005F9A9 File Offset: 0x0005DBA9
		private void pictureBoxButtonSave_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonSave.Image = Resources.popup_btn_060;
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x0005F9BB File Offset: 0x0005DBBB
		private void pictureBoxButtonSave_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonSave.Image = Resources.popup_btn_061;
				this.saveFile();
			}
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x0005F9E0 File Offset: 0x0005DBE0
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x0005F9FF File Offset: 0x0005DBFF
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0005FA11 File Offset: 0x0005DC11
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x0005FA23 File Offset: 0x0005DC23
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x0005FA48 File Offset: 0x0005DC48
		private void pictureBoxButtonBack_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonBack.Image = Resources.popup_btn_101;
			}
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x0005FA67 File Offset: 0x0005DC67
		private void pictureBoxButtonBack_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonBack.Image = Resources.popup_btn_102;
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x0005FA79 File Offset: 0x0005DC79
		private void pictureBoxButtonBack_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonBack.Image = Resources.popup_btn_100;
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x0005FA8B File Offset: 0x0005DC8B
		private void pictureBoxButtonBack_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonBack.Image = Resources.popup_btn_102;
				this.changePreview(false);
			}
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0005FAB4 File Offset: 0x0005DCB4
		private void textBoxGrade_TextChanged(object sender, EventArgs e)
		{
			if (this._program != null)
			{
				this._program.Report.Grade = this.textBoxGrade.Text;
				return;
			}
			this._melody.Module.Report.Grade = this.textBoxGrade.Text;
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0005FB08 File Offset: 0x0005DD08
		private void textBoxClass_TextChanged(object sender, EventArgs e)
		{
			if (this._program != null)
			{
				this._program.Report.Class = this.textBoxClass.Text;
				return;
			}
			this._melody.Module.Report.Class = this.textBoxClass.Text;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0005FB5C File Offset: 0x0005DD5C
		private void textBoxNumber_TextChanged(object sender, EventArgs e)
		{
			if (this._program != null)
			{
				this._program.Report.Number = this.textBoxNumber.Text;
				return;
			}
			this._melody.Module.Report.Number = this.textBoxNumber.Text;
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0005FBB0 File Offset: 0x0005DDB0
		private void textBoxName_TextChanged(object sender, EventArgs e)
		{
			if (this._program != null)
			{
				this._program.Report.Name = this.textBoxName.Text;
				return;
			}
			this._melody.Module.Report.Name = this.textBoxName.Text;
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x0005FC04 File Offset: 0x0005DE04
		private void textBoxComment_TextChanged(object sender, EventArgs e)
		{
			if (this._program != null)
			{
				this._program.Report.Comment = this.textBoxComment.Text;
				return;
			}
			this._melody.Module.Report.Comment = this.textBoxComment.Text;
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0005FC55 File Offset: 0x0005DE55
		private void pictureBoxButtonNext_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonNext.Image = Resources.popup_btn_091;
			}
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x0005FC74 File Offset: 0x0005DE74
		private void pictureBoxButtonNext_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonNext.Image = Resources.popup_btn_092;
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x0005FC86 File Offset: 0x0005DE86
		private void pictureBoxButtonNext_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonNext.Image = Resources.popup_btn_090;
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x0005FC98 File Offset: 0x0005DE98
		private void pictureBoxButtonNext_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonNext.Image = Resources.popup_btn_092;
				this.printPreview();
				this.changePreview(true);
			}
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x0005FCC4 File Offset: 0x0005DEC4
		private void pageUpButton_Click(object sender, EventArgs e)
		{
			if (this._nowPage + 1 <= this._maxPage)
			{
				this._nowPage++;
				this.printPreview();
				this.pageDownButton.Enabled = true;
				if (this._nowPage == this._maxPage)
				{
					this.pageUpButton.Enabled = false;
				}
			}
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x0005FD1B File Offset: 0x0005DF1B
		private void pageDownButton_Click(object sender, EventArgs e)
		{
			if (this._nowPage > 1)
			{
				this._nowPage--;
				this.printPreview();
				this.pageUpButton.Enabled = true;
				if (this._nowPage == 1)
				{
					this.pageDownButton.Enabled = false;
				}
			}
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x0005FD5B File Offset: 0x0005DF5B
		private void 印刷ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.printStart();
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x0005FD63 File Offset: 0x0005DF63
		private void 名前を付けて保存ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.saveFile();
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x000286B1 File Offset: 0x000268B1
		private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x0005FD6C File Offset: 0x0005DF6C
		private void printStart()
		{
			this._printPage = 1;
			if (new PrintDialog
			{
				Document = this._printDocument,
				Document = 
				{
					DefaultPageSettings = 
					{
						Margins = 
						{
							Left = 0,
							Right = 0,
							Top = 0,
							Bottom = 0
						}
					},
					OriginAtMargins = true
				}
			}.ShowDialog() == DialogResult.OK)
			{
				this._printDocument.Print();
			}
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x0005FE08 File Offset: 0x0005E008
		private void saveFile()
		{
			PdfDocument pdfDocument = new PdfDocument();
			for (int i = 1; i <= this._maxPage; i++)
			{
				XGraphics xgraphics = XGraphics.FromPdfPage(pdfDocument.AddPage());
				this.printPdf(xgraphics, i);
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "レポート.pdf";
			saveFileDialog.Filter = "PDFファイル(*.pdf)|*.pdf|すべてのファイル(*.*)|*.*";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.Title = "保存先のファイルを選択してください";
			saveFileDialog.RestoreDirectory = true;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (this.isFileLocked(saveFileDialog.FileName))
				{
					WarningDialog warningDialog = new WarningDialog();
					warningDialog.setText("ファイルがロックされています");
					warningDialog.ShowDialog();
					return;
				}
				pdfDocument.Save(saveFileDialog.FileName);
			}
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x0005FEB0 File Offset: 0x0005E0B0
		private bool isFileLocked(string path)
		{
			if (File.Exists(path))
			{
				FileStream fileStream = null;
				try
				{
					fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
				}
				catch
				{
					return true;
				}
				finally
				{
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0005FF04 File Offset: 0x0005E104
		private void textBoxComment_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				int num = 34;
				int num2 = num;
				int num3 = this.textBoxComment.Lines.Length;
				string text = "";
				int num4 = 0;
				int selectionStart = this.textBoxComment.SelectionStart;
				int num5 = 0;
				int lineFromCharIndex = this.textBoxComment.GetLineFromCharIndex(this.textBoxComment.SelectionStart);
				for (int i = 0; i < num3; i++)
				{
					string text2 = this.textBoxComment.Lines[i];
					if (text2.Length > num)
					{
						int num6 = text2.Length / num;
						for (int j = 0; j <= num6; j++)
						{
							if ((text2.Length - num * j < num) & (text2.Length - num * j > 0))
							{
								if (i == num3 - 1)
								{
									num2 = text2.Length - num * num6;
									text += text2.Substring(num * j, num2);
								}
								else
								{
									num2 = text2.Length - num * num6;
									text = text + text2.Substring(num * j, num2) + Environment.NewLine;
								}
							}
							else if (text2.Length - num * j >= num)
							{
								text = text + text2.Substring(num * j, num2) + Environment.NewLine;
								num5++;
							}
						}
					}
					else if (i == num3 - 1)
					{
						text += text2;
					}
					else
					{
						text = text + text2 + Environment.NewLine;
					}
					num4 += text2.Length;
					if (i > 0)
					{
						num4 += 2;
					}
					if (lineFromCharIndex == i)
					{
						num4 -= selectionStart;
						num4 = text2.Length - num4;
						if (num4 <= num)
						{
							num5 = 0;
						}
					}
				}
				this.textBoxComment.Text = text;
				this.textBoxComment.SelectionStart = selectionStart + num5 * 2;
			}
			catch (Exception)
			{
				GC.Collect();
			}
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x000600E8 File Offset: 0x0005E2E8
		private void labelZoomIn_Click(object sender, EventArgs e)
		{
			this._previewScale = Math.Min(this._previewScale + 0.2f, 2f);
			this.labelZoom.Text = (this._previewScale * 100f).ToString() + "%";
			this.labelZoomOut.Enabled = true;
			this.labelZoomIn.Enabled = this._previewScale != 2f;
			this.printPreview();
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x00060168 File Offset: 0x0005E368
		private void labelZoomOut_Click(object sender, EventArgs e)
		{
			this._previewScale = Math.Max(this._previewScale - 0.2f, 1f);
			this.labelZoom.Text = (this._previewScale * 100f).ToString() + "%";
			this.labelZoomOut.Enabled = this._previewScale != 1f;
			this.labelZoomIn.Enabled = true;
			this.printPreview();
		}

		// Token: 0x040005DC RID: 1500
		public const double ASPECT_RATIO = 0.70707070707070707;

		// Token: 0x040005DD RID: 1501
		private Size A4_SIZE = new Size(827, 1169);

		// Token: 0x040005DE RID: 1502
		private Size PREVIEW_SIZE;

		// Token: 0x040005DF RID: 1503
		private float _previewScale = 1f;

		// Token: 0x040005E0 RID: 1504
		private const string NEW_LINE = "\r\n";

		// Token: 0x040005E1 RID: 1505
		private static readonly Brush STR_BRUSH = new SolidBrush(Color.Black);

		// Token: 0x040005E2 RID: 1506
		private static readonly Font FONT_15 = new Font("メイリオ", 15f);

		// Token: 0x040005E3 RID: 1507
		private static readonly Font FONT_10_5 = new Font("メイリオ", 10.5f);

		// Token: 0x040005E4 RID: 1508
		private static readonly Font FONT_13 = new Font("メイリオ", 13f);

		// Token: 0x040005E5 RID: 1509
		private static readonly Font FONT_8 = new Font("メイリオ", 8f);

		// Token: 0x040005E6 RID: 1510
		private static readonly Font FONT_7 = new Font("メイリオ", 7f);

		// Token: 0x040005E7 RID: 1511
		private static readonly Font FONT_6_5 = new Font("メイリオ", 6.5f);

		// Token: 0x040005E8 RID: 1512
		private const string NAME_TITLE = "\u3000\u3000年\u3000\u3000\u3000組\u3000\u3000\u3000番\u3000名前：";

		// Token: 0x040005E9 RID: 1513
		private const int ICON_BLOCK_COUNT_1 = 50;

		// Token: 0x040005EA RID: 1514
		private static readonly Dictionary<Type, string> ICON_BLOCK_TYPE_DICT = new Dictionary<Type, string>();

		// Token: 0x040005EB RID: 1515
		private static readonly Dictionary<Color, string> ICON_LED_COLOR_DICT = new Dictionary<Color, string>();

		// Token: 0x040005EC RID: 1516
		private const int FLOW_PREVIEW_WIDTH = 500;

		// Token: 0x040005ED RID: 1517
		private const int FLOW_PREVIEW_X = 30;

		// Token: 0x040005EE RID: 1518
		private const int FLOW_PREVIEW_Y_1 = 435;

		// Token: 0x040005EF RID: 1519
		private const int FLOW_PREVIEW_Y_2 = 120;

		// Token: 0x040005F0 RID: 1520
		private const int FLOW_PREVIEW_ROUTINE_NAME_Y_1 = 420;

		// Token: 0x040005F1 RID: 1521
		private const int FLOW_PREVIEW_ROUTINE_NAME_Y_2 = 105;

		// Token: 0x040005F2 RID: 1522
		private const int FLOW_PDF_WIDTH = 350;

		// Token: 0x040005F3 RID: 1523
		private const int FLOW_PDF_X = 30;

		// Token: 0x040005F4 RID: 1524
		private const int FLOW_PDF_Y_1 = 320;

		// Token: 0x040005F5 RID: 1525
		private const int FLOW_PDF_Y_2 = 90;

		// Token: 0x040005F6 RID: 1526
		private const int FLOW_PDF_ROUTINE_NAME_Y_1 = 305;

		// Token: 0x040005F7 RID: 1527
		private const int FLOW_PDF_ROUTINE_NAME_Y_2 = 75;

		// Token: 0x040005F8 RID: 1528
		private static readonly char[] REMOVE_CHARS = new char[] { '\r', '\n' };

		// Token: 0x040005F9 RID: 1529
		private const int FLOW_GAP_WIDTH = 10;

		// Token: 0x040005FA RID: 1530
		private const int FLOW_DETAIL_ROW_MAX_1 = 48;

		// Token: 0x040005FB RID: 1531
		private const int FLOW_DETAIL_ROW_MAX_2 = 68;

		// Token: 0x040005FC RID: 1532
		private const int FLOW_PREVIEW_DETAIL_MORE_HEIGHT = 300;

		// Token: 0x040005FD RID: 1533
		private const int FLOW_PDF_DETAIL_MORE_HEIGHT = 200;

		// Token: 0x040005FE RID: 1534
		private static readonly Dictionary<Type, string> FLOW_BLOCK_TYPE_DICT = new Dictionary<Type, string>();

		// Token: 0x040005FF RID: 1535
		private const int MELODY_PLUS_ROW = 5;

		// Token: 0x04000600 RID: 1536
		private const int MELODY_PREVIEW_X = 60;

		// Token: 0x04000601 RID: 1537
		private const int MELODY_PREVIEW_Y_1 = 470;

		// Token: 0x04000602 RID: 1538
		private const int MELODY_PREVIEW_Y_2 = 100;

		// Token: 0x04000603 RID: 1539
		private const int MELODY_PREVIEW_WIDTH = 700;

		// Token: 0x04000604 RID: 1540
		private const int MELODY_PDF_X = 35;

		// Token: 0x04000605 RID: 1541
		private const int MELODY_PDF_Y_1 = 330;

		// Token: 0x04000606 RID: 1542
		private const int MELODY_PDF_Y_2 = 70;

		// Token: 0x04000607 RID: 1543
		private static readonly Dictionary<Type, string> NETWORK_OBJECT_TYPE_DICT = new Dictionary<Type, string>();

		// Token: 0x04000608 RID: 1544
		private ProgramModules _program;

		// Token: 0x04000609 RID: 1545
		private NetworkProgramModules _programNetwork;

		// Token: 0x0400060A RID: 1546
		private MelodyArea _melody;

		// Token: 0x0400060B RID: 1547
		private ReportWindow.REPORT _report;

		// Token: 0x0400060C RID: 1548
		private PrintDocument _printDocument = new PrintDocument();

		// Token: 0x0400060D RID: 1549
		private int _maxPage;

		// Token: 0x0400060E RID: 1550
		private int _nowPage = 1;

		// Token: 0x0400060F RID: 1551
		private int _printPage = 1;

		// Token: 0x04000610 RID: 1552
		private int[] _routinePages;

		// Token: 0x04000611 RID: 1553
		private string[] _routineNames;

		// Token: 0x04000612 RID: 1554
		private List<List<ProgramModule.Block>> _rightBlocksList = new List<List<ProgramModule.Block>>();

		// Token: 0x04000613 RID: 1555
		private List<ProgramModule.Block> _detailBlocks = new List<ProgramModule.Block>();

		// Token: 0x020000C8 RID: 200
		public enum REPORT
		{
			// Token: 0x04000942 RID: 2370
			ICON,
			// Token: 0x04000943 RID: 2371
			FLOWCHART,
			// Token: 0x04000944 RID: 2372
			MELODY,
			// Token: 0x04000945 RID: 2373
			NETWORK
		}
	}
}
