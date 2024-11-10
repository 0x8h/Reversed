using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000038 RID: 56
	public class NetworkObjectArea : PictureBox
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000614 RID: 1556 RVA: 0x0004BD46 File Offset: 0x00049F46
		// (set) Token: 0x06000615 RID: 1557 RVA: 0x0004BD4E File Offset: 0x00049F4E
		public NetworkProgramModules.ObjectInfo DragObject
		{
			get
			{
				return this._dragObject;
			}
			set
			{
				this._dragObject = value;
			}
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0004BD58 File Offset: 0x00049F58
		public NetworkObjectArea(NetworkWindow window)
		{
			this.InitializeComponent();
			this.BackColor = Color.FromArgb(247, 246, 229);
			this.BackgroundImage = Resources.nw_grid;
			this._window = window;
			this.AllowDrop = true;
			base.DragEnter += this.NetworkObjectArea_DragEnter;
			base.DragDrop += this.NetworkObjectArea_DragDrop;
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0004BDD3 File Offset: 0x00049FD3
		public void restoreObjects()
		{
			base.Controls.Clear();
			if (this._window.Programs.TopNode != null)
			{
				this.restoreObjectsSub(this, this._window.Programs.TopNode);
			}
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0004BE0C File Offset: 0x0004A00C
		private void restoreObjectsSub(Control parent, NetworkProgramModules.NodeInfo nodeInfo)
		{
			Control control = nodeInfo.restoreObject();
			if (nodeInfo is NetworkProgramModules.SplitterInfo)
			{
				NetworkProgramModules.SplitterInfo splitterInfo = (NetworkProgramModules.SplitterInfo)nodeInfo;
				SplitContainer splitContainer = (SplitContainer)control;
				splitContainer.MouseDown += this.splitter_MouseDown;
				splitContainer.SplitterMoved += this.splitter_SplitterMoved;
				splitContainer.Dock = DockStyle.Fill;
				splitContainer.BackColor = Color.Gray;
				splitContainer.SplitterWidth = 2;
				splitContainer.Size = parent.Size;
				splitContainer.SplitterDistance = splitterInfo.Offset;
				this.restoreObjectsSub(splitContainer.Panel1, splitterInfo.Left);
				this.restoreObjectsSub(splitContainer.Panel2, splitterInfo.Right);
				parent.Controls.Add(splitContainer);
				this._window.Programs.Splitters.Add(splitterInfo);
				return;
			}
			control.Dock = DockStyle.Fill;
			control.AllowDrop = true;
			control.DragEnter += this.NetworkObjectArea_DragEnter;
			control.DragDrop += this.NetworkObjectArea_DragDrop;
			control.MouseDown += this.pictureBoxObject_MouseDown;
			control.MouseMove += this.pictureBoxObject_MouseMove;
			parent.Controls.Add(control);
			NetworkProgramModules.ObjectInfo objectInfo = (NetworkProgramModules.ObjectInfo)nodeInfo;
			this._window.Programs.Objects.Add(objectInfo);
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0004BF54 File Offset: 0x0004A154
		private void NetworkObjectArea_DragEnter(object sender, DragEventArgs e)
		{
			object data = e.Data.GetData(DataFormats.Text);
			if (data != null)
			{
				string text = data.ToString();
				if ((text == "BUTTON" || text == "LABEL" || text == "LIST_NORMAL" || text == "LIST_NOTE" || text == "LIST_BALLOON") && e.Data.GetDataPresent(DataFormats.Text))
				{
					e.Effect = DragDropEffects.Copy;
				}
			}
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0004BFD8 File Offset: 0x0004A1D8
		private void NetworkObjectArea_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				string text = e.Data.GetData(DataFormats.Text).ToString();
				Control control = null;
				NetworkProgramModules.ObjectInfo objectInfo = null;
				if (this._dragObject == null)
				{
					if (!(text == "BUTTON"))
					{
						if (!(text == "LABEL"))
						{
							if (!(text == "LIST_NORMAL"))
							{
								if (!(text == "LIST_NOTE"))
								{
									if (text == "LIST_BALLOON")
									{
										objectInfo = new NetworkProgramModules.ObjectListInfo(NetworkObjectList.KIND.BALLOON);
									}
								}
								else
								{
									objectInfo = new NetworkProgramModules.ObjectListInfo(NetworkObjectList.KIND.NOTE);
								}
							}
							else
							{
								objectInfo = new NetworkProgramModules.ObjectListInfo(NetworkObjectList.KIND.NORMAL);
							}
						}
						else
						{
							objectInfo = new NetworkProgramModules.ObjectLabelInfo();
							if (this._window.Tutorial == NetworkWindow.TUTORIAL.DRAG_LABEL)
							{
								NetworkWindow window = this._window;
								NetworkWindow.TUTORIAL tutorial = window.Tutorial;
								window.Tutorial = tutorial + 1;
							}
						}
					}
					else
					{
						objectInfo = new NetworkProgramModules.ObjectButtonInfo();
						if (this._window.Tutorial == NetworkWindow.TUTORIAL.DRAG_BUTTON)
						{
							NetworkWindow window2 = this._window;
							NetworkWindow.TUTORIAL tutorial = window2.Tutorial;
							window2.Tutorial = tutorial + 1;
						}
					}
					if (objectInfo != null)
					{
						objectInfo.initialize();
						control = objectInfo.restoreObject();
						control.Dock = DockStyle.Fill;
						control.AllowDrop = true;
						control.DragEnter += this.NetworkObjectArea_DragEnter;
						control.DragDrop += this.NetworkObjectArea_DragDrop;
						control.MouseDown += this.pictureBoxObject_MouseDown;
						control.MouseMove += this.pictureBoxObject_MouseMove;
						this._window.Programs.addObject(objectInfo);
						this._window.updateLog("オブジェクトを追加");
					}
				}
				else
				{
					control = this._dragObject.Control;
					objectInfo = this._dragObject;
					this._dragObject = null;
					this._window.Programs.addObject(objectInfo);
					this._window.updateLog("オブジェクトの配置変更");
				}
				if (control != null)
				{
					if (sender == this)
					{
						base.Controls.Add(control);
					}
					else
					{
						SplitContainer splitContainer = new SplitContainer();
						splitContainer.Dock = DockStyle.Fill;
						splitContainer.BackColor = Color.Gray;
						splitContainer.SplitterWidth = 2;
						splitContainer.MouseDown += this.splitter_MouseDown;
						splitContainer.SplitterMoved += this.splitter_SplitterMoved;
						NetworkProgramModules.SplitterInfo splitterInfo = new NetworkProgramModules.SplitterInfo();
						splitterInfo.Control = splitContainer;
						NetworkProgramModules.ObjectInfo @object = this._window.Programs.getObject((Control)sender);
						((NetworkObjectInterface)@object.Control).Guide = GUIDE.NONE;
						Control parent = ((Control)sender).Parent;
						splitContainer.Size = parent.Size;
						Point point = ((Control)sender).PointToClient(new Point(e.X - ((Control)sender).Width / 2, e.Y - ((Control)sender).Height / 2));
						if (Math.Abs(point.X) > Math.Abs(point.Y) && !this._window.isTutorial())
						{
							splitContainer.Orientation = Orientation.Vertical;
							splitContainer.SplitterDistance = splitContainer.Width / 2;
							if (point.X > 0)
							{
								splitContainer.Panel1.Controls.Add((Control)sender);
								splitContainer.Panel2.Controls.Add(control);
								splitterInfo.Left = @object;
								splitterInfo.Right = objectInfo;
							}
							else
							{
								splitContainer.Panel1.Controls.Add(control);
								splitContainer.Panel2.Controls.Add((Control)sender);
								splitterInfo.Left = objectInfo;
								splitterInfo.Right = @object;
							}
						}
						else
						{
							splitContainer.Orientation = Orientation.Horizontal;
							splitContainer.SplitterDistance = splitContainer.Height / 2;
							if (point.Y > 0 || this._window.isTutorial())
							{
								splitContainer.Panel1.Controls.Add((Control)sender);
								splitContainer.Panel2.Controls.Add(control);
								splitterInfo.Left = @object;
								splitterInfo.Right = objectInfo;
							}
							else
							{
								splitContainer.Panel1.Controls.Add(control);
								splitContainer.Panel2.Controls.Add((Control)sender);
								splitterInfo.Left = objectInfo;
								splitterInfo.Right = @object;
							}
						}
						parent.Controls.Add(splitContainer);
						if (parent == this)
						{
							this._window.Programs.TopNode = splitterInfo;
						}
						this._window.Programs.addSplitter(splitterInfo, @object);
					}
					this._window.changeSelectedObject(objectInfo);
					this._window.addHistory(true);
				}
			}
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0004C44E File Offset: 0x0004A64E
		private void splitter_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this._splitterFlag = true;
			}
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0004C464 File Offset: 0x0004A664
		private void splitter_SplitterMoved(object sender, SplitterEventArgs e)
		{
			if (this._splitterFlag)
			{
				if (this._window.Tutorial == NetworkWindow.TUTORIAL.ADJUST_SPLITTER)
				{
					SplitContainer splitContainer = (SplitContainer)this._window.Programs.getSplitter((Control)sender).Control;
					if (splitContainer.SplitterDistance > splitContainer.Parent.Height / 2)
					{
						splitContainer.SplitterDistance = splitContainer.Parent.Height / 4 * 3;
						this._window.Tutorial = NetworkWindow.TUTORIAL.SELECT_BUTTON;
					}
					else
					{
						splitContainer.SplitterDistance = splitContainer.Parent.Height / 2;
					}
				}
				this._window.addHistory(true);
				this._splitterFlag = false;
				this._window.updateLog("オブジェクトのサイズを変更");
			}
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0004C51C File Offset: 0x0004A71C
		private void pictureBoxObject_MouseDown(object sender, MouseEventArgs e)
		{
			if (this._window.SimulatorWindow == null)
			{
				if (e.Button == MouseButtons.Left)
				{
					this._window.changeSelectedObject(this._window.Programs.getObject((Control)sender));
					if (!NetworkWindow.Instance.isTutorial())
					{
						this._dragPoint = new Point(e.X, e.Y);
						return;
					}
				}
			}
			else
			{
				this._dragPoint = Point.Empty;
			}
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0004C594 File Offset: 0x0004A794
		private void pictureBoxObject_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !this._dragPoint.IsEmpty && (this._dragPoint.X != e.X || this._dragPoint.Y != e.Y))
			{
				this._dragPoint = Point.Empty;
				Control parent = ((Control)sender).Parent;
				NetworkProgramModules.ObjectInfo @object = this._window.Programs.getObject((Control)sender);
				if (((Control)sender).Parent == this)
				{
					this._window.Programs.TopNode = null;
					this._window.Programs.removeObject(@object);
				}
				else
				{
					SplitContainer splitContainer = (SplitContainer)parent.Parent;
					Control control = ((parent == splitContainer.Panel1) ? splitContainer.Panel2 : splitContainer.Panel1);
					if (splitContainer == this._window.Programs.TopNode.Control)
					{
						if (control.Controls[0] is SplitContainer)
						{
							this._window.Programs.TopNode = this._window.Programs.getSplitter(control.Controls[0]);
						}
						else
						{
							this._window.Programs.TopNode = this._window.Programs.getObject(control.Controls[0]);
						}
					}
					splitContainer.Parent.Controls.Add(control.Controls[0]);
					splitContainer.Parent.Controls.Remove(splitContainer);
					this._window.Programs.removeSplitter(@object);
				}
				parent.Controls.Remove((Control)sender);
				this._dragObject = @object;
				if (sender is NetworkObjectButton)
				{
					this._window.ObjectIconArea.objectIconButton0_MouseDown(sender, e);
				}
				else if (sender is NetworkObjectLabel)
				{
					this._window.ObjectIconArea.objectIconLabel0_MouseDown(sender, e);
				}
				else if (sender is NetworkObjectList)
				{
					switch (((NetworkObjectList)sender).Kind)
					{
					case NetworkObjectList.KIND.NORMAL:
						this._window.ObjectIconArea.objectIconListNormal_MouseDown(sender, e);
						break;
					case NetworkObjectList.KIND.NOTE:
						this._window.ObjectIconArea.objectIconListNote_MouseDown(sender, e);
						break;
					case NetworkObjectList.KIND.BALLOON:
						this._window.ObjectIconArea.objectIconListBalloon_MouseDown(sender, e);
						break;
					}
				}
				if (this._window.Programs.getSelectedObject() == null)
				{
					this._window.changeSelectedObject(this._window.Programs.ObjectInput);
				}
				Point point = base.PointToClient(Cursor.Position);
				if (point.X < 0 || base.Width < point.X || point.Y < 0 || base.Height < point.Y)
				{
					this._window.addHistory(true);
				}
			}
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0004C869 File Offset: 0x0004AA69
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0004C888 File Offset: 0x0004AA88
		private void InitializeComponent()
		{
			((ISupportInitialize)this).BeginInit();
			base.SuspendLayout();
			this.BackColor = Color.White;
			this.Dock = DockStyle.Fill;
			((ISupportInitialize)this).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040004C4 RID: 1220
		private NetworkWindow _window;

		// Token: 0x040004C5 RID: 1221
		private NetworkProgramModules.ObjectInfo _dragObject;

		// Token: 0x040004C6 RID: 1222
		private Point _dragPoint = Point.Empty;

		// Token: 0x040004C7 RID: 1223
		private bool _splitterFlag;

		// Token: 0x040004C8 RID: 1224
		private IContainer components;
	}
}
