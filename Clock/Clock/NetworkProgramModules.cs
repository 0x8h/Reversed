using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Clock
{
	// Token: 0x02000044 RID: 68
	[XmlInclude(typeof(NetworkProgramModules.ObjectButtonInfo))]
	[XmlInclude(typeof(NetworkProgramModules.ObjectLabelInfo))]
	[XmlInclude(typeof(NetworkProgramModules.ObjectListInfo))]
	[XmlInclude(typeof(NetworkProgramModules.SplitterInfo))]
	public class NetworkProgramModules
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600069F RID: 1695 RVA: 0x0004F1E2 File Offset: 0x0004D3E2
		// (set) Token: 0x060006A0 RID: 1696 RVA: 0x0004F1EA File Offset: 0x0004D3EA
		[XmlIgnore]
		public List<NetworkProgramModules.ObjectInfo> Objects
		{
			get
			{
				return this._objects;
			}
			set
			{
				this._objects = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060006A1 RID: 1697 RVA: 0x0004F1F3 File Offset: 0x0004D3F3
		// (set) Token: 0x060006A2 RID: 1698 RVA: 0x0004F1FB File Offset: 0x0004D3FB
		[XmlIgnore]
		public List<NetworkProgramModules.SplitterInfo> Splitters
		{
			get
			{
				return this._splitters;
			}
			set
			{
				this._splitters = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060006A3 RID: 1699 RVA: 0x0004F204 File Offset: 0x0004D404
		// (set) Token: 0x060006A4 RID: 1700 RVA: 0x0004F20C File Offset: 0x0004D40C
		public NetworkProgramModules.NodeInfo TopNode
		{
			get
			{
				return this._topNode;
			}
			set
			{
				this._topNode = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x0004F215 File Offset: 0x0004D415
		// (set) Token: 0x060006A6 RID: 1702 RVA: 0x0004F21D File Offset: 0x0004D41D
		public NetworkProgramModules.ObjectInputInfo ObjectInput
		{
			get
			{
				return this._objectInput;
			}
			set
			{
				this._objectInput = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x0004F226 File Offset: 0x0004D426
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x0004F22E File Offset: 0x0004D42E
		public NetworkProgramModules.ObjectStageInfo ObjectStage
		{
			get
			{
				return this._objectStage;
			}
			set
			{
				this._objectStage = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x0004F237 File Offset: 0x0004D437
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x0004F23F File Offset: 0x0004D43F
		public ReportModule Report
		{
			get
			{
				return this._report;
			}
			set
			{
				this._report = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060006AB RID: 1707 RVA: 0x0004F248 File Offset: 0x0004D448
		// (set) Token: 0x060006AC RID: 1708 RVA: 0x0004F250 File Offset: 0x0004D450
		public bool IsBlockMode { get; set; }

		// Token: 0x060006AE RID: 1710 RVA: 0x0004F2DC File Offset: 0x0004D4DC
		public void initialize()
		{
			this.Version = NetworkProgramModules.CurrentVersion;
			this.Level = NetworkProgramModules.LEVEL.LEVEL_1;
			this._topNode = null;
			this._objects.Clear();
			this._splitters.Clear();
			this.clearObjectNewCounts();
			this._objectInput.initialize();
			this._objectStage.initialize();
			this.MessageNames.Clear();
			for (int i = 0; i < this.MESSAGE_INITIAL_COUNT; i++)
			{
				this.MessageNames.Add("メッセージ" + (i + 1).ToString());
			}
			this.ServerVariableNames.Clear();
			for (int j = 0; j < this.SERVER_VARIABLES_INITIAL_COUNT; j++)
			{
				this.ServerVariableNames.Add("データ" + (j + 1).ToString());
			}
			this.ClientVariableNames.Clear();
			for (int k = 0; k < this.CLIENT_VARIABLES_INITIAL_COUNT; k++)
			{
				this.ClientVariableNames.Add("データ" + (k + 1).ToString());
			}
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x0004F3E8 File Offset: 0x0004D5E8
		public void reset()
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				objectInfo.reset(this.MessageNames.Count);
			}
			this._objectInput.reset(this.MessageNames.Count);
			this._objectStage.reset(this.MessageNames.Count);
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x0004F470 File Offset: 0x0004D670
		public void run()
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				objectInfo.run();
			}
			this._objectInput.run();
			this._objectStage.run();
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x0004F4D8 File Offset: 0x0004D6D8
		public void stop()
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				objectInfo.stop();
			}
			this._objectInput.stop();
			this._objectStage.stop();
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x0004F540 File Offset: 0x0004D740
		public void updateVersion()
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				objectInfo.ProgramModule.updateVersion(this.Version);
			}
			this._objectInput.ProgramModule.updateVersion(this.Version);
			this._objectStage.ProgramModule.updateVersion(this.Version);
			this.Version = NetworkProgramModules.CurrentVersion;
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x0004F5D4 File Offset: 0x0004D7D4
		public ProgramModule.ERROR getError(bool jumpCheck)
		{
			ProgramModule.ERROR error;
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				error = objectInfo.ProgramModule.getError(true, !this.IsBlockMode, jumpCheck);
				if (error != ProgramModule.ERROR.NONE)
				{
					return error;
				}
			}
			error = this._objectInput.ProgramModule.getError(true, !this.IsBlockMode, jumpCheck);
			if (error != ProgramModule.ERROR.NONE)
			{
				return error;
			}
			return this._objectStage.ProgramModule.getError(true, !this.IsBlockMode, jumpCheck);
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x0004F680 File Offset: 0x0004D880
		public void clearSelectBlocks()
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				objectInfo.ProgramModule.clearSelect();
			}
			this._objectInput.ProgramModule.clearSelect();
			this._objectStage.ProgramModule.clearSelect();
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x0004F6F8 File Offset: 0x0004D8F8
		public void clearObjectNewCounts()
		{
			for (int i = 0; i < 5; i++)
			{
				NetworkProgramModules.ObjectNewCounts[i] = 0;
			}
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x0004F71C File Offset: 0x0004D91C
		public void updateObjectNewCounts()
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				if (objectInfo is NetworkProgramModules.ObjectInputInfo)
				{
					NetworkProgramModules.ObjectNewCounts[4] = Math.Max(objectInfo.ObjectId, NetworkProgramModules.ObjectNewCounts[4]);
				}
				else if (objectInfo is NetworkProgramModules.ObjectButtonInfo)
				{
					NetworkProgramModules.ObjectNewCounts[0] = Math.Max(objectInfo.ObjectId, NetworkProgramModules.ObjectNewCounts[0]);
				}
				else if (objectInfo is NetworkProgramModules.ObjectLabelInfo)
				{
					NetworkProgramModules.ObjectNewCounts[1] = Math.Max(objectInfo.ObjectId, NetworkProgramModules.ObjectNewCounts[1]);
				}
				else if (objectInfo is NetworkProgramModules.ObjectListInfo)
				{
					NetworkProgramModules.ObjectNewCounts[2] = Math.Max(objectInfo.ObjectId, NetworkProgramModules.ObjectNewCounts[2]);
				}
				else if (objectInfo is NetworkProgramModules.ObjectGraphInfo)
				{
					NetworkProgramModules.ObjectNewCounts[3] = Math.Max(objectInfo.ObjectId, NetworkProgramModules.ObjectNewCounts[3]);
				}
			}
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x0004F820 File Offset: 0x0004DA20
		public void updateLoopIndex()
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				objectInfo.ProgramModule.updateLoopIndex();
			}
			this._objectInput.ProgramModule.updateLoopIndex();
			this._objectStage.ProgramModule.updateLoopIndex();
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x0004F898 File Offset: 0x0004DA98
		public void updateConnectState()
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				objectInfo.ProgramModule.updateConnectState();
			}
			this._objectInput.ProgramModule.updateConnectState();
			this._objectStage.ProgramModule.updateConnectState();
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x0004F910 File Offset: 0x0004DB10
		public void createBlockControls()
		{
			NetworkWindow.Instance.FlowchartTabIndex = NetworkFlowchartTab.TAB.OBJECT;
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				this.setSelectedObject(objectInfo);
				objectInfo.ProgramModule.createBlockControls();
			}
			this.setSelectedObject(this._objectInput);
			this._objectInput.ProgramModule.createBlockControls();
			NetworkWindow.Instance.FlowchartTabIndex = NetworkFlowchartTab.TAB.STAGE;
			this._objectStage.ProgramModule.createBlockControls();
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x0004F9B0 File Offset: 0x0004DBB0
		public void clearUpdated()
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				objectInfo.ProgramModule.clearUpdated();
			}
			this._objectInput.ProgramModule.clearUpdated();
			this._objectStage.ProgramModule.clearUpdated();
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0004FA28 File Offset: 0x0004DC28
		public ProgramModule.ERROR convertBlock()
		{
			this.updateConnectState();
			ProgramModule.ERROR error = this.getError(false);
			if (error == ProgramModule.ERROR.NONE)
			{
				ProgramModule.BlockLabel.LabelIndexCount = 1;
				NetworkWindow.Instance.FlowchartTabIndex = NetworkFlowchartTab.TAB.OBJECT;
				foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
				{
					this.setSelectedObject(objectInfo);
					objectInfo.ProgramModule.convertBlock();
				}
				this.setSelectedObject(this._objectInput);
				this._objectInput.ProgramModule.convertBlock();
				NetworkWindow.Instance.FlowchartTabIndex = NetworkFlowchartTab.TAB.STAGE;
				this._objectStage.ProgramModule.convertBlock();
				this.IsBlockMode = true;
			}
			return error;
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x0004FAEC File Offset: 0x0004DCEC
		public ProgramModule.ERROR convertFlowchart()
		{
			this.updateConnectState();
			ProgramModule.ERROR error = this.getError(true);
			if (error == ProgramModule.ERROR.NONE)
			{
				foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
				{
					objectInfo.ProgramModule.convertFlowchart();
				}
				this._objectInput.ProgramModule.convertFlowchart();
				this._objectStage.ProgramModule.convertFlowchart();
				this.IsBlockMode = false;
			}
			return error;
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0004FB7C File Offset: 0x0004DD7C
		public int getLabelIndexCount()
		{
			int num = 1;
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				foreach (ProgramModule.BlockLabel blockLabel in objectInfo.ProgramModule.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>())
				{
					num = Math.Max(blockLabel.Label, num);
				}
			}
			foreach (ProgramModule.BlockLabel blockLabel2 in this._objectInput.ProgramModule.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>())
			{
				num = Math.Max(blockLabel2.Label, num);
			}
			foreach (ProgramModule.BlockLabel blockLabel3 in this._objectStage.ProgramModule.Blocks.Select((ProgramModule.Block x) => x).OfType<ProgramModule.BlockLabel>().ToList<ProgramModule.BlockLabel>())
			{
				num = Math.Max(blockLabel3.Label, num);
			}
			return num;
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x0004FD40 File Offset: 0x0004DF40
		public void saveConnectIndex()
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				objectInfo.ProgramModule.saveConnectIndex(objectInfo.ProgramModule.Blocks, this.IsBlockMode);
			}
			this._objectInput.ProgramModule.saveConnectIndex(this._objectInput.ProgramModule.Blocks, this.IsBlockMode);
			this._objectStage.ProgramModule.saveConnectIndex(this._objectStage.ProgramModule.Blocks, this.IsBlockMode);
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x0004FDF4 File Offset: 0x0004DFF4
		public void restoreConnectIndex()
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				if (objectInfo.ProgramModule.Starts.Count == 0)
				{
					foreach (ProgramModule.Block block in objectInfo.ProgramModule.Blocks)
					{
						if (block.GetType() == typeof(ProgramModule.BlockEvent))
						{
							objectInfo.ProgramModule.Starts.Add((ProgramModule.BlockEvent)block);
						}
						else if (block.GetType() == typeof(ProgramModule.BlockEnd))
						{
							objectInfo.ProgramModule.Ends.Add((ProgramModule.BlockEnd)block);
						}
					}
				}
				objectInfo.ProgramModule.restoreConnectIndex(objectInfo.ProgramModule.Blocks, this.IsBlockMode);
			}
			if (this._objectInput.ProgramModule.Starts.Count == 0)
			{
				foreach (ProgramModule.Block block2 in this._objectInput.ProgramModule.Blocks)
				{
					if (block2.GetType() == typeof(ProgramModule.BlockEvent))
					{
						this._objectInput.ProgramModule.Starts.Add((ProgramModule.BlockEvent)block2);
					}
					else if (block2.GetType() == typeof(ProgramModule.BlockEnd))
					{
						this._objectInput.ProgramModule.Ends.Add((ProgramModule.BlockEnd)block2);
					}
				}
			}
			this._objectInput.ProgramModule.restoreConnectIndex(this._objectInput.ProgramModule.Blocks, this.IsBlockMode);
			if (this._objectStage.ProgramModule.Starts.Count == 0)
			{
				foreach (ProgramModule.Block block3 in this._objectStage.ProgramModule.Blocks)
				{
					if (block3.GetType() == typeof(ProgramModule.BlockEvent))
					{
						this._objectStage.ProgramModule.Starts.Add((ProgramModule.BlockEvent)block3);
					}
					else if (block3.GetType() == typeof(ProgramModule.BlockEnd))
					{
						this._objectStage.ProgramModule.Ends.Add((ProgramModule.BlockEnd)block3);
					}
				}
			}
			this._objectStage.ProgramModule.restoreConnectIndex(this._objectStage.ProgramModule.Blocks, this.IsBlockMode);
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x000500F4 File Offset: 0x0004E2F4
		public void storeObjects()
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				objectInfo.storeObject();
			}
			foreach (NetworkProgramModules.SplitterInfo splitterInfo in this._splitters)
			{
				splitterInfo.storeObject();
			}
			this._objectInput.storeObject();
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00050190 File Offset: 0x0004E390
		public void receiveMessage(int index)
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				objectInfo.receiveMessage(index);
			}
			this._objectInput.receiveMessage(index);
			this._objectStage.receiveMessage(index);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x000501FC File Offset: 0x0004E3FC
		public void setSelectedObject(NetworkProgramModules.ObjectInfo targetObjectInfo)
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				objectInfo.Selected = objectInfo == targetObjectInfo;
				((NetworkObjectInterface)objectInfo.Control).Selected = objectInfo.Selected;
				objectInfo.Control.Invalidate();
			}
			this._objectInput.Selected = this._objectInput == targetObjectInfo;
			((NetworkObjectInterface)this._objectInput.Control).Selected = this._objectInput.Selected;
			this._objectInput.Control.Invalidate();
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x000502B8 File Offset: 0x0004E4B8
		public NetworkProgramModules.ObjectInfo getSelectedObject()
		{
			if (this._objectInput.Selected)
			{
				return this._objectInput;
			}
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				if (objectInfo.Selected)
				{
					return objectInfo;
				}
			}
			return null;
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00050328 File Offset: 0x0004E528
		public List<NetworkProgramModules.ObjectInfo> getObjects(NetworkProgramModules.OBJECT_TYPE type)
		{
			List<NetworkProgramModules.ObjectInfo> list = new List<NetworkProgramModules.ObjectInfo>();
			switch (type)
			{
			case NetworkProgramModules.OBJECT_TYPE.BUTTON:
			{
				using (List<NetworkProgramModules.ObjectInfo>.Enumerator enumerator = this._objects.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						NetworkProgramModules.ObjectInfo objectInfo = enumerator.Current;
						if (objectInfo is NetworkProgramModules.ObjectButtonInfo)
						{
							list.Add(objectInfo);
						}
					}
					return list;
				}
				break;
			}
			case NetworkProgramModules.OBJECT_TYPE.LABEL:
				break;
			case NetworkProgramModules.OBJECT_TYPE.LIST:
				goto IL_A7;
			case NetworkProgramModules.OBJECT_TYPE.GRAPH:
				goto IL_E8;
			case NetworkProgramModules.OBJECT_TYPE.INPUT:
				goto IL_129;
			default:
				return list;
			}
			using (List<NetworkProgramModules.ObjectInfo>.Enumerator enumerator = this._objects.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					NetworkProgramModules.ObjectInfo objectInfo2 = enumerator.Current;
					if (objectInfo2 is NetworkProgramModules.ObjectLabelInfo)
					{
						list.Add(objectInfo2);
					}
				}
				return list;
			}
			IL_A7:
			using (List<NetworkProgramModules.ObjectInfo>.Enumerator enumerator = this._objects.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					NetworkProgramModules.ObjectInfo objectInfo3 = enumerator.Current;
					if (objectInfo3 is NetworkProgramModules.ObjectListInfo)
					{
						list.Add(objectInfo3);
					}
				}
				return list;
			}
			IL_E8:
			using (List<NetworkProgramModules.ObjectInfo>.Enumerator enumerator = this._objects.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					NetworkProgramModules.ObjectInfo objectInfo4 = enumerator.Current;
					if (objectInfo4 is NetworkProgramModules.ObjectGraphInfo)
					{
						list.Add(objectInfo4);
					}
				}
				return list;
			}
			IL_129:
			list.Add(this._objectInput);
			return list;
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x000504A0 File Offset: 0x0004E6A0
		public NetworkProgramModules.ObjectInfo getObject(string name)
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				if (objectInfo.getObjectName() == name)
				{
					return objectInfo;
				}
			}
			if (this.ObjectInput.getObjectName() == name)
			{
				return this.ObjectInput;
			}
			return null;
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0005051C File Offset: 0x0004E71C
		public NetworkProgramModules.ObjectInfo getObject(int id)
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				if (objectInfo.Id == id)
				{
					return objectInfo;
				}
			}
			return null;
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00050578 File Offset: 0x0004E778
		public NetworkProgramModules.ObjectInfo getObject(Control control)
		{
			foreach (NetworkProgramModules.ObjectInfo objectInfo in this._objects)
			{
				if (objectInfo.Control == control)
				{
					return objectInfo;
				}
			}
			return null;
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x000505D4 File Offset: 0x0004E7D4
		public void addObject(NetworkProgramModules.ObjectInfo objectInfo)
		{
			if (this._topNode == null)
			{
				this._topNode = objectInfo;
			}
			this._objects.Add(objectInfo);
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x000505F1 File Offset: 0x0004E7F1
		public void removeObject(NetworkProgramModules.ObjectInfo objectInfo)
		{
			this._objects.Remove(objectInfo);
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00050600 File Offset: 0x0004E800
		public void setEditorMode(bool on)
		{
			foreach (NetworkProgramModules.SplitterInfo splitterInfo in this._splitters)
			{
				((SplitContainer)splitterInfo.Control).IsSplitterFixed = !on;
			}
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00050660 File Offset: 0x0004E860
		public NetworkProgramModules.SplitterInfo getSplitter(Control control)
		{
			foreach (NetworkProgramModules.SplitterInfo splitterInfo in this._splitters)
			{
				if (splitterInfo.Control == control)
				{
					return splitterInfo;
				}
			}
			return null;
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x000506BC File Offset: 0x0004E8BC
		public void addSplitter(NetworkProgramModules.SplitterInfo splitterInfo, NetworkProgramModules.ObjectInfo targetObjectInfo)
		{
			foreach (NetworkProgramModules.SplitterInfo splitterInfo2 in this._splitters)
			{
				if (splitterInfo2.Right == targetObjectInfo)
				{
					splitterInfo2.Right = splitterInfo;
					break;
				}
				if (splitterInfo2.Left == targetObjectInfo)
				{
					splitterInfo2.Left = splitterInfo;
					break;
				}
			}
			this._splitters.Add(splitterInfo);
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x00050738 File Offset: 0x0004E938
		public void removeSplitter(NetworkProgramModules.ObjectInfo targetObjectInfo)
		{
			NetworkProgramModules.NodeInfo nodeInfo = null;
			NetworkProgramModules.SplitterInfo splitterInfo = null;
			foreach (NetworkProgramModules.SplitterInfo splitterInfo2 in this._splitters)
			{
				if (splitterInfo2.Right == targetObjectInfo)
				{
					splitterInfo = splitterInfo2;
					nodeInfo = splitterInfo2.Left;
					break;
				}
				if (splitterInfo2.Left == targetObjectInfo)
				{
					splitterInfo = splitterInfo2;
					nodeInfo = splitterInfo2.Right;
					break;
				}
			}
			if (splitterInfo != null)
			{
				this._splitters.Remove(splitterInfo);
				this._objects.Remove(targetObjectInfo);
				foreach (NetworkProgramModules.SplitterInfo splitterInfo3 in this._splitters)
				{
					if (splitterInfo3.Right == splitterInfo)
					{
						splitterInfo3.Right = nodeInfo;
					}
					else if (splitterInfo3.Left == splitterInfo)
					{
						splitterInfo3.Left = nodeInfo;
					}
				}
			}
		}

		// Token: 0x04000501 RID: 1281
		private static int[] ObjectNewCounts = new int[5];

		// Token: 0x04000502 RID: 1282
		public int Version;

		// Token: 0x04000503 RID: 1283
		private static readonly int CurrentVersion = 1;

		// Token: 0x04000504 RID: 1284
		public static readonly int OBJECT_COUNT_MAX = 10;

		// Token: 0x04000505 RID: 1285
		private List<NetworkProgramModules.ObjectInfo> _objects = new List<NetworkProgramModules.ObjectInfo>();

		// Token: 0x04000506 RID: 1286
		private List<NetworkProgramModules.SplitterInfo> _splitters = new List<NetworkProgramModules.SplitterInfo>();

		// Token: 0x04000507 RID: 1287
		private NetworkProgramModules.NodeInfo _topNode;

		// Token: 0x04000508 RID: 1288
		private NetworkProgramModules.ObjectInputInfo _objectInput = new NetworkProgramModules.ObjectInputInfo();

		// Token: 0x04000509 RID: 1289
		private NetworkProgramModules.ObjectStageInfo _objectStage = new NetworkProgramModules.ObjectStageInfo();

		// Token: 0x0400050A RID: 1290
		private readonly int MESSAGE_INITIAL_COUNT = 8;

		// Token: 0x0400050B RID: 1291
		private readonly int SERVER_VARIABLES_INITIAL_COUNT = 8;

		// Token: 0x0400050C RID: 1292
		private readonly int CLIENT_VARIABLES_INITIAL_COUNT = 8;

		// Token: 0x0400050D RID: 1293
		public List<string> MessageNames = new List<string>();

		// Token: 0x0400050E RID: 1294
		public List<string> ServerVariableNames = new List<string>();

		// Token: 0x0400050F RID: 1295
		public List<string> ClientVariableNames = new List<string>();

		// Token: 0x04000510 RID: 1296
		public NetworkProgramModules.LEVEL Level;

		// Token: 0x04000511 RID: 1297
		private ReportModule _report = new ReportModule();

		// Token: 0x020000AF RID: 175
		public enum OBJECT_TYPE
		{
			// Token: 0x040008C0 RID: 2240
			BUTTON,
			// Token: 0x040008C1 RID: 2241
			LABEL,
			// Token: 0x040008C2 RID: 2242
			LIST,
			// Token: 0x040008C3 RID: 2243
			GRAPH,
			// Token: 0x040008C4 RID: 2244
			INPUT,
			// Token: 0x040008C5 RID: 2245
			MAX
		}

		// Token: 0x020000B0 RID: 176
		public enum LEVEL
		{
			// Token: 0x040008C7 RID: 2247
			LEVEL_1,
			// Token: 0x040008C8 RID: 2248
			LEVEL_2,
			// Token: 0x040008C9 RID: 2249
			LEVEL_3,
			// Token: 0x040008CA RID: 2250
			MAX
		}

		// Token: 0x020000B1 RID: 177
		public class NodeInfo
		{
			// Token: 0x06001088 RID: 4232 RVA: 0x00091ED8 File Offset: 0x000900D8
			public NodeInfo()
			{
				NetworkProgramModules.NodeInfo.count++;
				this.Id = NetworkProgramModules.NodeInfo.count;
			}

			// Token: 0x06001089 RID: 4233 RVA: 0x000153E3 File Offset: 0x000135E3
			public virtual void storeObject()
			{
			}

			// Token: 0x0600108A RID: 4234 RVA: 0x0008ECA8 File Offset: 0x0008CEA8
			public virtual Control restoreObject()
			{
				return null;
			}

			// Token: 0x040008CB RID: 2251
			[XmlIgnore]
			public Control Control;

			// Token: 0x040008CC RID: 2252
			public int Id;

			// Token: 0x040008CD RID: 2253
			[XmlIgnore]
			private static int count;
		}

		// Token: 0x020000B2 RID: 178
		public class ObjectInfo : NetworkProgramModules.NodeInfo
		{
			// Token: 0x170004BD RID: 1213
			// (get) Token: 0x0600108B RID: 4235 RVA: 0x00091EF7 File Offset: 0x000900F7
			// (set) Token: 0x0600108C RID: 4236 RVA: 0x00091EFF File Offset: 0x000900FF
			[XmlIgnore]
			public float WaitTime
			{
				get
				{
					return this._waitTime;
				}
				set
				{
					this._waitTime = value;
				}
			}

			// Token: 0x0600108D RID: 4237 RVA: 0x00091F08 File Offset: 0x00090108
			public void pushCall(ProgramModule.BlockSubroutine block)
			{
				this._callStack.Add(block);
			}

			// Token: 0x0600108E RID: 4238 RVA: 0x00091F16 File Offset: 0x00090116
			public void popCall()
			{
				this._callStack.RemoveAt(this._callStack.Count - 1);
			}

			// Token: 0x0600108F RID: 4239 RVA: 0x000153E3 File Offset: 0x000135E3
			public virtual void initialize()
			{
			}

			// Token: 0x06001090 RID: 4240 RVA: 0x00091F30 File Offset: 0x00090130
			public virtual string getObjectName()
			{
				return this.ObjectId.ToString();
			}

			// Token: 0x06001091 RID: 4241 RVA: 0x00091F40 File Offset: 0x00090140
			public virtual void reset(int messageCount)
			{
				this._loopIndex = -1;
				this._callStack.Clear();
				this.Messages.Clear();
				for (int i = 0; i < messageCount; i++)
				{
					this.Messages.Add(false);
				}
			}

			// Token: 0x06001092 RID: 4242 RVA: 0x00091F82 File Offset: 0x00090182
			public void receiveMessage(int index)
			{
				if (index < this.Messages.Count)
				{
					this.Messages[index] = true;
				}
			}

			// Token: 0x06001093 RID: 4243 RVA: 0x00091FA0 File Offset: 0x000901A0
			public void run()
			{
				this._isRunning = true;
				List<Task> list = new List<Task>();
				using (List<ProgramModule.BlockStart>.Enumerator enumerator = this.ProgramModule.Starts.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProgramModule.BlockEvent eventBlock = (ProgramModule.BlockEvent)enumerator.Current;
						Task task = Task.Run(delegate
						{
							this.runProgram(eventBlock);
						});
						list.Add(task);
					}
				}
			}

			// Token: 0x06001094 RID: 4244 RVA: 0x0009202C File Offset: 0x0009022C
			protected void runProgram(ProgramModule.Block block)
			{
				ProgramModule.BlockEvent blockEvent = null;
				while (block != null)
				{
					bool flag = true;
					if (block is ProgramModule.BlockEvent)
					{
						blockEvent = this.runProgramEvent((ProgramModule.BlockEvent)block);
					}
					else if (block is ProgramModule.BlockMessage)
					{
						this.runProgramMessage((ProgramModule.BlockMessage)block);
					}
					else if (block is ProgramModule.BlockCommunication)
					{
						this.runProgramCommunication((ProgramModule.BlockCommunication)block);
					}
					else if (block is ProgramModule.BlockWait)
					{
						this.runProgramWait((ProgramModule.BlockWait)block);
					}
					else if (block is ProgramModule.BlockCounter)
					{
						this.runProgramCounter((ProgramModule.BlockCounter)block);
					}
					else if (block is ProgramModule.BlockData)
					{
						this.runProgramData((ProgramModule.BlockData)block);
					}
					else if (block is ProgramModule.BlockIf)
					{
						ProgramModule.BlockIf blockIf = (ProgramModule.BlockIf)block;
						flag = this.runProgramIf(blockIf);
						if (flag)
						{
							if (NetworkWindow.Instance.IsBlockMode)
							{
								flag = false;
								block = blockIf.Branches[0];
							}
						}
						else if (NetworkWindow.Instance.IsBlockMode)
						{
							if (blockIf.Branches.Count > 1)
							{
								block = blockIf.Branches[1];
							}
							else
							{
								block = block.Next;
							}
						}
						else
						{
							block = blockIf.Else;
						}
						if (block != null && block is ProgramModule.BlockJump)
						{
							ProgramModule.BlockLabel label = ((ProgramModule.BlockJump)block).Label;
							if (label != null)
							{
								block = label.Next;
							}
						}
						if (block != null && block.BreakPoint)
						{
							this.setBlockSelected(block, true);
							NetworkSimulator.Instance.stop(NetworkSimulator.ERROR.NONE);
							NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, "ブレークポイントで停止しました");
							NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
							NetworkWindow.Instance.Invoke(new MethodInvoker(delegate
							{
								NetworkWindow.Instance.changeSelectedObject(this);
							}));
						}
					}
					else if (block is ProgramModule.BlockLoopStart)
					{
						this.runProgramLoopStart((ProgramModule.BlockLoopStart)block);
						if (NetworkWindow.Instance.IsBlockMode)
						{
							flag = false;
							block = ((ProgramModule.BlockLoopStart)block).Branches[0];
						}
					}
					else if (block is ProgramModule.BlockLoopEnd)
					{
						flag = this.runProgramLoopEnd((ProgramModule.BlockLoopEnd)block);
						if (flag)
						{
							if (NetworkWindow.Instance.IsBlockMode)
							{
								flag = false;
								block = this._loopStartBlocks[this._loopIndex + 1].Next;
							}
						}
						else
						{
							if (NetworkWindow.Instance.IsBlockMode)
							{
								block = this._loopStartBlocks[this._loopIndex].Branches[0];
							}
							else
							{
								block = this._loopStartBlocks[this._loopIndex].Next;
							}
							if (block != null && block is ProgramModule.BlockJump)
							{
								ProgramModule.BlockLabel label2 = ((ProgramModule.BlockJump)block).Label;
								if (label2 != null)
								{
									block = label2.Next;
								}
							}
							if (block != null && block.BreakPoint)
							{
								this.setBlockSelected(block, true);
								NetworkSimulator.Instance.stop(NetworkSimulator.ERROR.NONE);
								NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, "ブレークポイントで停止しました");
								NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
								NetworkWindow.Instance.Invoke(new MethodInvoker(delegate
								{
									NetworkWindow.Instance.changeSelectedObject(this);
								}));
							}
						}
					}
					else if (block is ProgramModule.BlockNetworkDisplay)
					{
						this.runProgramDisplay((ProgramModule.BlockNetworkDisplay)block);
					}
					else if (block is ProgramModule.BlockNetworkSound)
					{
						this.runProgramSound((ProgramModule.BlockNetworkSound)block);
					}
					else if (block is ProgramModule.BlockOutput)
					{
						this.runProgramOutput((ProgramModule.BlockOutput)block);
					}
					else if (block is ProgramModule.BlockUsbOut)
					{
						this.runProgramUsbOut((ProgramModule.BlockUsbOut)block);
					}
					if (!this._isRunning)
					{
						break;
					}
					if (flag)
					{
						block = block.Next;
						if (block != null && block is ProgramModule.BlockJump)
						{
							ProgramModule.BlockLabel label3 = ((ProgramModule.BlockJump)block).Label;
							if (label3 != null)
							{
								block = label3.Next;
							}
						}
						if (block != null && block.BreakPoint)
						{
							this.setBlockSelected(block, true);
							NetworkSimulator.Instance.stop(NetworkSimulator.ERROR.NONE);
							NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, "ブレークポイントで停止しました");
							NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
							NetworkWindow.Instance.Invoke(new MethodInvoker(delegate
							{
								NetworkWindow.Instance.changeSelectedObject(this);
							}));
						}
					}
					if (NetworkWindow.Instance.IsBlockMode && block == null && this._loopIndex >= 0 && this._loopStartBlocks[this._loopIndex].BlockLoopEnd != null)
					{
						block = this._loopStartBlocks[this._loopIndex].BlockLoopEnd;
					}
					if (block == null && blockEvent != null)
					{
						block = blockEvent;
						Thread.Sleep(NetworkObjectButton.BUTTON_ON_TIME);
					}
				}
			}

			// Token: 0x06001095 RID: 4245 RVA: 0x00092465 File Offset: 0x00090665
			private void setBlockSelected(ProgramModule.Block block, bool enable)
			{
				if (enable)
				{
					if (!NetworkWindow.Instance.IsBlockMode || !(block is ProgramModule.BlockEnd))
					{
						block.Selected = enable;
						return;
					}
				}
				else
				{
					block.Selected = enable;
				}
			}

			// Token: 0x06001096 RID: 4246 RVA: 0x0009248D File Offset: 0x0009068D
			public void stop()
			{
				this._isRunning = false;
			}

			// Token: 0x06001097 RID: 4247 RVA: 0x00092498 File Offset: 0x00090698
			private ProgramModule.BlockEvent runProgramEvent(ProgramModule.BlockEvent blockEvent)
			{
				while (this._isRunning)
				{
					bool flag = false;
					switch (blockEvent.ObjectType)
					{
					case ProgramModule.BlockEvent.OBJECT_TYPE.LABEL:
					case ProgramModule.BlockEvent.OBJECT_TYPE.LIST:
					case ProgramModule.BlockEvent.OBJECT_TYPE.GRAPH:
					case ProgramModule.BlockEvent.OBJECT_TYPE.STAGE:
						switch (blockEvent.Trigger)
						{
						case ProgramModule.BlockEvent.TRIGGER.PLAY:
							flag = true;
							blockEvent = null;
							break;
						case ProgramModule.BlockEvent.TRIGGER.MESSAGE:
							flag = this.Messages[blockEvent.MessageIndex];
							this.Messages[blockEvent.MessageIndex] = false;
							break;
						case ProgramModule.BlockEvent.TRIGGER.HARDWARE:
							switch (blockEvent.TriggerHardware)
							{
							case ProgramModule.BlockEvent.TRIGGER_HARDWARE.BUTTON:
								flag = NetworkSimulator.Instance.HardwareInfo.IsButtonOn;
								break;
							case ProgramModule.BlockEvent.TRIGGER_HARDWARE.BRIGHT:
								flag = NetworkSimulator.Instance.HardwareInfo.IsBright;
								break;
							case ProgramModule.BlockEvent.TRIGGER_HARDWARE.DARK:
								flag = !NetworkSimulator.Instance.HardwareInfo.IsBright;
								break;
							case ProgramModule.BlockEvent.TRIGGER_HARDWARE.SOUND:
								flag = NetworkSimulator.Instance.HardwareInfo.IsSoundOn;
								break;
							case ProgramModule.BlockEvent.TRIGGER_HARDWARE.LEVEL2_MAX:
								flag = NetworkSimulator.Instance.HardwareInfo.IsUsbInOn;
								break;
							}
							break;
						}
						break;
					case ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON:
						flag = ((NetworkObjectButton)this.Control).IsOn;
						if (NetworkWindow.Instance.Tutorial == NetworkWindow.TUTORIAL.CLICK_BUTTON && flag)
						{
							NetworkWindow instance = NetworkWindow.Instance;
							NetworkWindow.TUTORIAL tutorial = instance.Tutorial;
							instance.Tutorial = tutorial + 1;
						}
						break;
					case ProgramModule.BlockEvent.OBJECT_TYPE.INPUT:
						flag = ((NetworkObjectInput)this.Control).IsOn;
						((NetworkObjectInput)this.Control).IsOn = false;
						if (NetworkWindow.Instance.Tutorial == NetworkWindow.TUTORIAL.INPUT && flag)
						{
							NetworkWindow instance2 = NetworkWindow.Instance;
							NetworkWindow.TUTORIAL tutorial = instance2.Tutorial;
							instance2.Tutorial = tutorial + 1;
						}
						break;
					}
					if (flag)
					{
						break;
					}
					Thread.Sleep(100);
				}
				return blockEvent;
			}

			// Token: 0x06001098 RID: 4248 RVA: 0x0009264C File Offset: 0x0009084C
			private void runProgramMessage(ProgramModule.BlockMessage blockMessage)
			{
				NetworkSimulator.ERROR error = NetworkSimulator.Instance.sendMessage(blockMessage.MessageIndex);
				if (!NetworkWindow.Instance.StopProgramWithErrorFlag && error != NetworkSimulator.ERROR.NONE)
				{
					this._isRunning = false;
					NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, NetworkSimulator.ERROR_TEXTS[(int)error]);
					NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
				}
			}

			// Token: 0x06001099 RID: 4249 RVA: 0x000926A8 File Offset: 0x000908A8
			private void runProgramCommunication(ProgramModule.BlockCommunication blockCommunication)
			{
				NetworkSimulator.ERROR error = NetworkSimulator.ERROR.NONE;
				if (blockCommunication.Mode == ProgramModule.BlockCommunication.COMMUNICATION_MODE.SEND)
				{
					switch (blockCommunication.VariableType)
					{
					case ProgramModule.BlockCommunication.VARIABLE_TYPE.INPUT:
						error = NetworkSimulator.Instance.sendVariable(blockCommunication.VariableIndexDistination, NetworkSimulator.Instance.InputVariable);
						break;
					case ProgramModule.BlockCommunication.VARIABLE_TYPE.CLIENT:
						error = NetworkSimulator.Instance.sendVariable(blockCommunication.VariableIndexDistination, NetworkSimulator.Instance.ClientVariables[blockCommunication.VariableIndexSource].Value);
						break;
					case ProgramModule.BlockCommunication.VARIABLE_TYPE.LIGHT:
					{
						NetworkSimulator instance = NetworkSimulator.Instance;
						int variableIndexDistination = blockCommunication.VariableIndexDistination;
						CommunicationModule.HardwareInfo hardwareInfo = NetworkSimulator.Instance.HardwareInfo;
						error = instance.sendVariable(variableIndexDistination, hardwareInfo.LightValue.ToString());
						break;
					}
					case ProgramModule.BlockCommunication.VARIABLE_TYPE.TEMPERATURE:
					{
						NetworkSimulator instance2 = NetworkSimulator.Instance;
						int variableIndexDistination2 = blockCommunication.VariableIndexDistination;
						CommunicationModule.HardwareInfo hardwareInfo = NetworkSimulator.Instance.HardwareInfo;
						error = instance2.sendVariable(variableIndexDistination2, hardwareInfo.Temperature.ToString());
						break;
					}
					}
				}
				else
				{
					error = NetworkSimulator.Instance.receiveVariable(blockCommunication.VariableIndexDistination, blockCommunication.VariableIndexSource);
				}
				if (!NetworkWindow.Instance.StopProgramWithErrorFlag && error != NetworkSimulator.ERROR.NONE)
				{
					this._isRunning = false;
					NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, NetworkSimulator.ERROR_TEXTS[(int)error]);
					NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
				}
			}

			// Token: 0x0600109A RID: 4250 RVA: 0x000927DD File Offset: 0x000909DD
			private void runProgramWait(ProgramModule.BlockWait blockWait)
			{
				this._waitTime = blockWait.Time;
				while (this._waitTime > 0f)
				{
					this._waitTime -= 0.1f;
					Thread.Sleep(100);
					if (!this._isRunning)
					{
						break;
					}
				}
			}

			// Token: 0x0600109B RID: 4251 RVA: 0x0009281C File Offset: 0x00090A1C
			private void runProgramCounter(ProgramModule.BlockCounter blockCounter)
			{
				switch (blockCounter.Command)
				{
				case ProgramModule.BlockCounter.COMMAND.START:
					NetworkSimulator.Instance.counterStart();
					return;
				case ProgramModule.BlockCounter.COMMAND.STOP:
					NetworkSimulator.Instance.counterStop();
					return;
				case ProgramModule.BlockCounter.COMMAND.RESET:
					NetworkSimulator.Instance.counterReset();
					return;
				default:
					return;
				}
			}

			// Token: 0x0600109C RID: 4252 RVA: 0x00092864 File Offset: 0x00090A64
			private void runProgramData(ProgramModule.BlockData blockData)
			{
				NetworkSimulator.NetworkVariable networkVariable = NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexLeft];
				string text = "";
				networkVariable.IPAddress = UDP.getMyIPAddress().ToString();
				networkVariable.Name = Server.Name;
				switch (blockData.Kind)
				{
				case ProgramModule.BlockData.DATA_KIND.SUBSTITUTION:
					switch (blockData.ValueType)
					{
					case ProgramModule.BlockData.DATA_VALUE_TYPE.CONST:
						networkVariable.Value = blockData.ConstString;
						if (networkVariable.isNumber())
						{
							text = blockData.ConstString;
						}
						else
						{
							text = "\"" + blockData.ConstString + "\"";
						}
						break;
					case ProgramModule.BlockData.DATA_VALUE_TYPE.VARIABLE:
						if (blockData.VariableType == ProgramModule.BlockData.DATA_VARIABLE_TYPE.INPUT)
						{
							networkVariable.Value = NetworkSimulator.Instance.InputVariable;
							if (networkVariable.isNumber())
							{
								text = "入力変数「" + networkVariable.Value + "」";
							}
							else
							{
								text = "入力変数「\"" + networkVariable.Value + "\"」";
							}
						}
						else
						{
							networkVariable.Value = NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexRight].Value;
							networkVariable.IPAddress = NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexRight].IPAddress;
							networkVariable.Name = NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexRight].Name;
							if (networkVariable.isNumber())
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[blockData.VariableIndexRight] + "「" + networkVariable.Value + "」";
							}
							else
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[blockData.VariableIndexRight] + "「\"" + networkVariable.Value + "\"」";
							}
						}
						break;
					case ProgramModule.BlockData.DATA_VALUE_TYPE.TEMPERATURE:
					{
						CommunicationModule.HardwareInfo hardwareInfo = NetworkSimulator.Instance.HardwareInfo;
						networkVariable.Value = hardwareInfo.Temperature.ToString();
						text = "温度「" + networkVariable.Value + "」";
						break;
					}
					case ProgramModule.BlockData.DATA_VALUE_TYPE.LIGHT:
					{
						CommunicationModule.HardwareInfo hardwareInfo = NetworkSimulator.Instance.HardwareInfo;
						networkVariable.Value = hardwareInfo.LightValue.ToString();
						text = "明るさ「" + networkVariable.Value + "」";
						break;
					}
					}
					NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexLeft] = networkVariable;
					if (NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexLeft].isNumber())
					{
						NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, string.Concat(new string[]
						{
							"代入：",
							NetworkWindow.Instance.Programs.ClientVariableNames[blockData.VariableIndexLeft],
							"「",
							NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexLeft].Value,
							"」 = ",
							text
						}));
					}
					else
					{
						NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, string.Concat(new string[]
						{
							"代入：",
							NetworkWindow.Instance.Programs.ClientVariableNames[blockData.VariableIndexLeft],
							"「\"",
							NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexLeft].Value,
							"\"」 = ",
							text
						}));
					}
					NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
					break;
				case ProgramModule.BlockData.DATA_KIND.ARITHMETIC:
				{
					double num = 0.0;
					string text2 = "";
					NetworkLog.IMPORTANCE importance = NetworkLog.IMPORTANCE.INFO;
					switch (blockData.ValueType)
					{
					case ProgramModule.BlockData.DATA_VALUE_TYPE.CONST:
						num = (double)blockData.ConstValue;
						text = blockData.ConstValue.ToString();
						break;
					case ProgramModule.BlockData.DATA_VALUE_TYPE.VARIABLE:
						if (blockData.VariableType == ProgramModule.BlockData.DATA_VARIABLE_TYPE.CLIENT)
						{
							num = NetworkSimulator.Instance.getClientVariable(blockData.VariableIndexRight);
							networkVariable.IPAddress = NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexRight].IPAddress;
							networkVariable.Name = NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexRight].Name;
							if (NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexRight].isNumber())
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[blockData.VariableIndexRight] + "「" + NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexRight].Value + "」";
							}
							else
							{
								text = NetworkWindow.Instance.Programs.ClientVariableNames[blockData.VariableIndexRight] + "「\"" + NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexRight].Value + "\"」";
								importance = NetworkLog.IMPORTANCE.WARNING;
							}
						}
						break;
					case ProgramModule.BlockData.DATA_VALUE_TYPE.TEMPERATURE:
						num = (double)NetworkSimulator.Instance.HardwareInfo.Temperature;
						text = "温度「" + num.ToString() + "」";
						break;
					case ProgramModule.BlockData.DATA_VALUE_TYPE.LIGHT:
						num = (double)NetworkSimulator.Instance.HardwareInfo.LightValue;
						text = "明るさ「" + num.ToString() + "」";
						break;
					}
					switch (blockData.Operate)
					{
					case ProgramModule.BlockData.DATA_OPERATE.ADD:
						num = NetworkSimulator.Instance.getClientVariable(blockData.VariableIndexLeft) + num;
						text2 = " + ";
						break;
					case ProgramModule.BlockData.DATA_OPERATE.SUB:
						num = NetworkSimulator.Instance.getClientVariable(blockData.VariableIndexLeft) - num;
						text2 = " - ";
						break;
					case ProgramModule.BlockData.DATA_OPERATE.LEVEL2_MAX:
						num = NetworkSimulator.Instance.getClientVariable(blockData.VariableIndexLeft) * num;
						text2 = " * ";
						break;
					case ProgramModule.BlockData.DATA_OPERATE.DEVIDE:
						num = NetworkSimulator.Instance.getClientVariable(blockData.VariableIndexLeft) / num;
						text2 = " / ";
						break;
					}
					networkVariable.Value = num.ToString();
					string text3;
					if (NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexLeft].isNumber())
					{
						text3 = NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexLeft].Value;
					}
					else
					{
						text3 = "\"" + NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexLeft].Value + "\"";
						importance = NetworkLog.IMPORTANCE.WARNING;
					}
					NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexLeft] = networkVariable;
					NetworkLog.Instance.addLog(importance, string.Concat(new string[]
					{
						"演算：",
						NetworkWindow.Instance.Programs.ClientVariableNames[blockData.VariableIndexLeft],
						"「",
						NetworkSimulator.Instance.ClientVariables[blockData.VariableIndexLeft].Value,
						"」 = ",
						NetworkWindow.Instance.Programs.ClientVariableNames[blockData.VariableIndexLeft],
						"「",
						text3,
						"」",
						text2,
						text
					}));
					NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
					break;
				}
				}
				NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.CLIENT_VARIABLE);
			}

			// Token: 0x0600109D RID: 4253 RVA: 0x00092F8E File Offset: 0x0009118E
			private bool tryParse(string text, out double value)
			{
				return double.TryParse(text, out value) && -32768.0 <= value && value <= 32767.0;
			}

			// Token: 0x0600109E RID: 4254 RVA: 0x00092FB8 File Offset: 0x000911B8
			private bool runProgramIf(ProgramModule.BlockIf blockIf)
			{
				bool flag = false;
				switch (blockIf.ConditionNetwork)
				{
				case ProgramModule.BlockIf.CONDITION_NETWORK_IF.OBJECT_BUTTON:
				{
					NetworkProgramModules.ObjectInfo @object = NetworkSimulator.Instance.Programs.getObject(blockIf.ObjectName);
					if (@object != null)
					{
						flag = ((blockIf.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON) ? ((NetworkObjectButton)@object.Control).IsOn : (!((NetworkObjectButton)@object.Control).IsOn));
					}
					break;
				}
				case ProgramModule.BlockIf.CONDITION_NETWORK_IF.VARIABLE:
				{
					if (blockIf.Select == ProgramModule.BlockIf.SELECT.BUTTON_OFF && !NetworkSimulator.Instance.ClientVariables[blockIf.VariableIndexes[0]].isNumber())
					{
						double num;
						if (blockIf.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							if (blockIf.VariableIndexes[1] == 0)
							{
								if (!this.tryParse(NetworkSimulator.Instance.InputVariable, out num))
								{
									flag = NetworkSimulator.Instance.ClientVariables[blockIf.VariableIndexes[0]].Value == NetworkSimulator.Instance.InputVariable;
									NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, string.Concat(new string[]
									{
										"比較：",
										NetworkWindow.Instance.Programs.ClientVariableNames[0],
										"「\"",
										NetworkSimulator.Instance.ClientVariables[blockIf.VariableIndexes[0]].Value,
										"\"」 == 入力変数「\"",
										NetworkSimulator.Instance.InputVariable,
										"\"」"
									}));
									NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
									break;
								}
							}
							else
							{
								int num2 = blockIf.VariableIndexes[1] - 1;
								if (!NetworkSimulator.Instance.ClientVariables[num2].isNumber())
								{
									flag = NetworkSimulator.Instance.ClientVariables[blockIf.VariableIndexes[0]].Value == NetworkSimulator.Instance.ClientVariables[num2].Value;
									NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, string.Concat(new string[]
									{
										"比較：",
										NetworkWindow.Instance.Programs.ClientVariableNames[0],
										"「\"",
										NetworkSimulator.Instance.ClientVariables[blockIf.VariableIndexes[0]].Value,
										"\"」 == ",
										NetworkWindow.Instance.Programs.ClientVariableNames[num2],
										"「\"",
										NetworkSimulator.Instance.ClientVariables[num2].Value,
										"\"」"
									}));
									NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
									break;
								}
							}
						}
						else if (blockIf.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST_STRING && !this.tryParse(NetworkSimulator.Instance.InputVariable, out num))
						{
							flag = NetworkSimulator.Instance.ClientVariables[blockIf.VariableIndexes[0]].Value == blockIf.ConstString;
							NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, string.Concat(new string[]
							{
								"比較：",
								NetworkWindow.Instance.Programs.ClientVariableNames[0],
								"「\"",
								NetworkSimulator.Instance.ClientVariables[blockIf.VariableIndexes[0]].Value,
								"\"」 == 「\"",
								blockIf.ConstString,
								"\"」"
							}));
							NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
							break;
						}
					}
					NetworkLog.IMPORTANCE importance = NetworkLog.IMPORTANCE.INFO;
					double clientVariable = NetworkSimulator.Instance.getClientVariable(blockIf.VariableIndexes[0]);
					string text;
					if (NetworkSimulator.Instance.ClientVariables[blockIf.VariableIndexes[0]].isNumber())
					{
						text = NetworkWindow.Instance.Programs.ClientVariableNames[blockIf.VariableIndexes[0]] + "「" + NetworkSimulator.Instance.ClientVariables[blockIf.VariableIndexes[0]].Value + "」";
					}
					else
					{
						text = NetworkWindow.Instance.Programs.ClientVariableNames[blockIf.VariableIndexes[0]] + "「\"" + NetworkSimulator.Instance.ClientVariables[blockIf.VariableIndexes[0]].Value + "\"」";
						importance = NetworkLog.IMPORTANCE.NOTICE;
					}
					double num3 = 0.0;
					string text2 = "";
					switch (blockIf.Variable)
					{
					case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST:
						num3 = (double)blockIf.Values[0];
						text2 = blockIf.Values[0].ToString();
						break;
					case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX:
						if (blockIf.VariableIndexes[1] == 0)
						{
							num3 = NetworkSimulator.Instance.getInputVariable();
							double num;
							if (this.tryParse(NetworkSimulator.Instance.InputVariable, out num))
							{
								text2 = "入力変数「" + NetworkSimulator.Instance.InputVariable + "」";
							}
							else
							{
								text2 = "入力変数「\"" + NetworkSimulator.Instance.InputVariable + "\"」";
								importance = NetworkLog.IMPORTANCE.NOTICE;
							}
						}
						else
						{
							int num4 = blockIf.VariableIndexes[1] - 1;
							num3 = NetworkSimulator.Instance.getClientVariable(num4);
							if (NetworkSimulator.Instance.ClientVariables[num4].isNumber())
							{
								text2 = NetworkWindow.Instance.Programs.ClientVariableNames[num4] + "「" + NetworkSimulator.Instance.ClientVariables[num4].Value + "」";
							}
							else
							{
								text2 = NetworkWindow.Instance.Programs.ClientVariableNames[num4] + "「\"" + NetworkSimulator.Instance.ClientVariables[num4].Value + "\"」";
								importance = NetworkLog.IMPORTANCE.NOTICE;
							}
						}
						break;
					case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST_STRING:
						if (!this.tryParse(blockIf.ConstString, out num3))
						{
							num3 = 0.0;
							importance = NetworkLog.IMPORTANCE.NOTICE;
						}
						text2 = blockIf.ConstString;
						break;
					}
					switch (blockIf.Select)
					{
					case ProgramModule.BlockIf.SELECT.BUTTON_ON:
						flag = clientVariable < num3;
						NetworkLog.Instance.addLog(importance, "比較：" + text + " < " + text2);
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
						flag = clientVariable == num3;
						NetworkLog.Instance.addLog(importance, "比較：" + text + " == " + text2);
						break;
					case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
						flag = clientVariable > num3;
						NetworkLog.Instance.addLog(importance, "比較：" + text + " > " + text2);
						break;
					}
					NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
					break;
				}
				case ProgramModule.BlockIf.CONDITION_NETWORK_IF.BUTTON:
					flag = ((blockIf.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON) ? NetworkSimulator.Instance.HardwareInfo.IsButtonOn : (!NetworkSimulator.Instance.HardwareInfo.IsButtonOn));
					break;
				case ProgramModule.BlockIf.CONDITION_NETWORK_IF.LIGHT:
					switch (blockIf.Variable)
					{
					case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID:
						flag = ((blockIf.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON) ? NetworkSimulator.Instance.HardwareInfo.IsBright : (!NetworkSimulator.Instance.HardwareInfo.IsBright));
						break;
					case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST:
						switch (blockIf.Select)
						{
						case ProgramModule.BlockIf.SELECT.BUTTON_ON:
							flag = NetworkSimulator.Instance.HardwareInfo.LightValue > blockIf.Values[0];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
							flag = NetworkSimulator.Instance.HardwareInfo.LightValue < blockIf.Values[0];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
							flag = NetworkSimulator.Instance.HardwareInfo.LightValue == blockIf.Values[0];
							break;
						}
						break;
					case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX:
					{
						double clientVariable2 = NetworkSimulator.Instance.getClientVariable(blockIf.VariableIndexes[0]);
						switch (blockIf.Select)
						{
						case ProgramModule.BlockIf.SELECT.BUTTON_ON:
							flag = (double)NetworkSimulator.Instance.HardwareInfo.LightValue > clientVariable2;
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
							flag = (double)NetworkSimulator.Instance.HardwareInfo.LightValue < clientVariable2;
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
							flag = (double)NetworkSimulator.Instance.HardwareInfo.LightValue == clientVariable2;
							break;
						}
						break;
					}
					}
					break;
				case ProgramModule.BlockIf.CONDITION_NETWORK_IF.TEMPERATURE:
				{
					ProgramModule.BlockIf.VARIABLE_TYPE_SECOND variable = blockIf.Variable;
					if (variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
					{
						if (variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
						{
							double clientVariable3 = NetworkSimulator.Instance.getClientVariable(blockIf.VariableIndexes[0]);
							switch (blockIf.Select)
							{
							case ProgramModule.BlockIf.SELECT.BUTTON_ON:
								flag = (double)NetworkSimulator.Instance.HardwareInfo.Temperature < clientVariable3;
								break;
							case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
								flag = (double)NetworkSimulator.Instance.HardwareInfo.Temperature == clientVariable3;
								break;
							case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
								flag = (double)NetworkSimulator.Instance.HardwareInfo.Temperature > clientVariable3;
								break;
							}
						}
					}
					else
					{
						switch (blockIf.Select)
						{
						case ProgramModule.BlockIf.SELECT.BUTTON_ON:
							flag = NetworkSimulator.Instance.HardwareInfo.Temperature < blockIf.Values[0];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
							flag = NetworkSimulator.Instance.HardwareInfo.Temperature == blockIf.Values[0];
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
							flag = NetworkSimulator.Instance.HardwareInfo.Temperature > blockIf.Values[0];
							break;
						}
					}
					break;
				}
				case ProgramModule.BlockIf.CONDITION_NETWORK_IF.SOUND:
					flag = ((blockIf.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON) ? NetworkSimulator.Instance.HardwareInfo.IsSoundOn : (!NetworkSimulator.Instance.HardwareInfo.IsSoundOn));
					break;
				case ProgramModule.BlockIf.CONDITION_NETWORK_IF.USBIN:
					flag = ((blockIf.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON) ? NetworkSimulator.Instance.HardwareInfo.IsUsbInOn : (!NetworkSimulator.Instance.HardwareInfo.IsUsbInOn));
					break;
				}
				return flag;
			}

			// Token: 0x0600109F RID: 4255 RVA: 0x00093967 File Offset: 0x00091B67
			private void runProgramLoopStart(ProgramModule.BlockLoopStart blockLoopStart)
			{
				this._loopIndex++;
				this._loopStartBlocks[this._loopIndex] = blockLoopStart;
				this._loopCounts[this._loopIndex] = blockLoopStart.Count - 1;
			}

			// Token: 0x060010A0 RID: 4256 RVA: 0x0009399C File Offset: 0x00091B9C
			private bool runProgramLoopEnd(ProgramModule.BlockLoopEnd blockLoopEnd)
			{
				if (blockLoopEnd.IsConditionNetwork)
				{
					bool flag = false;
					switch (blockLoopEnd.ConditionNetwork)
					{
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.OBJECT_BUTTON:
					{
						NetworkProgramModules.ObjectInfo @object = NetworkSimulator.Instance.Programs.getObject(blockLoopEnd.ObjectName);
						if (@object != null)
						{
							flag = ((blockLoopEnd.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON) ? ((NetworkObjectButton)@object.Control).IsOn : (!((NetworkObjectButton)@object.Control).IsOn));
						}
						break;
					}
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.VARIABLE:
					{
						if (blockLoopEnd.Select == ProgramModule.BlockIf.SELECT.BUTTON_OFF && !NetworkSimulator.Instance.ClientVariables[blockLoopEnd.VariableIndexes[0]].isNumber())
						{
							double num;
							if (blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								if (blockLoopEnd.VariableIndexes[1] == 0)
								{
									if (!this.tryParse(NetworkSimulator.Instance.InputVariable, out num))
									{
										flag = NetworkSimulator.Instance.ClientVariables[blockLoopEnd.VariableIndexes[0]].Value == NetworkSimulator.Instance.InputVariable;
										NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, string.Concat(new string[]
										{
											"比較：",
											NetworkWindow.Instance.Programs.ClientVariableNames[0],
											"「\"",
											NetworkSimulator.Instance.ClientVariables[blockLoopEnd.VariableIndexes[0]].Value,
											"\"」 == 入力変数「\"",
											NetworkSimulator.Instance.InputVariable,
											"\"」"
										}));
										NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
										break;
									}
								}
								else
								{
									int num2 = blockLoopEnd.VariableIndexes[1] - 1;
									if (!NetworkSimulator.Instance.ClientVariables[num2].isNumber())
									{
										flag = NetworkSimulator.Instance.ClientVariables[blockLoopEnd.VariableIndexes[0]].Value == NetworkSimulator.Instance.ClientVariables[num2].Value;
										NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, string.Concat(new string[]
										{
											"比較：",
											NetworkWindow.Instance.Programs.ClientVariableNames[0],
											"「\"",
											NetworkSimulator.Instance.ClientVariables[blockLoopEnd.VariableIndexes[0]].Value,
											"\"」 == ",
											NetworkWindow.Instance.Programs.ClientVariableNames[num2],
											"「\"",
											NetworkSimulator.Instance.ClientVariables[num2].Value,
											"\"」"
										}));
										NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
										break;
									}
								}
							}
							else if (blockLoopEnd.Variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST_STRING && !this.tryParse(NetworkSimulator.Instance.InputVariable, out num))
							{
								flag = NetworkSimulator.Instance.ClientVariables[blockLoopEnd.VariableIndexes[0]].Value == blockLoopEnd.ConstString;
								NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, string.Concat(new string[]
								{
									"比較：",
									NetworkWindow.Instance.Programs.ClientVariableNames[0],
									"「\"",
									NetworkSimulator.Instance.ClientVariables[blockLoopEnd.VariableIndexes[0]].Value,
									"\"」 == 「\"",
									blockLoopEnd.ConstString,
									"\"」"
								}));
								NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
								break;
							}
						}
						NetworkLog.IMPORTANCE importance = NetworkLog.IMPORTANCE.INFO;
						double clientVariable = NetworkSimulator.Instance.getClientVariable(blockLoopEnd.VariableIndexes[0]);
						string text;
						if (NetworkSimulator.Instance.ClientVariables[blockLoopEnd.VariableIndexes[0]].isNumber())
						{
							text = NetworkWindow.Instance.Programs.ClientVariableNames[blockLoopEnd.VariableIndexes[0]] + "「" + NetworkSimulator.Instance.ClientVariables[blockLoopEnd.VariableIndexes[0]].Value + "」";
						}
						else
						{
							text = NetworkWindow.Instance.Programs.ClientVariableNames[blockLoopEnd.VariableIndexes[0]] + "「\"" + NetworkSimulator.Instance.ClientVariables[blockLoopEnd.VariableIndexes[0]].Value + "\"」";
							importance = NetworkLog.IMPORTANCE.NOTICE;
						}
						double num3 = 0.0;
						string text2 = "";
						switch (blockLoopEnd.Variable)
						{
						case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST:
							num3 = (double)blockLoopEnd.Values[0];
							text2 = blockLoopEnd.Values[0].ToString();
							break;
						case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX:
							if (blockLoopEnd.VariableIndexes[1] == 0)
							{
								num3 = NetworkSimulator.Instance.getInputVariable();
								double num;
								if (this.tryParse(NetworkSimulator.Instance.InputVariable, out num))
								{
									text2 = "入力変数「" + NetworkSimulator.Instance.InputVariable + "」";
								}
								else
								{
									text2 = "入力変数「\"" + NetworkSimulator.Instance.InputVariable + "\"」";
									importance = NetworkLog.IMPORTANCE.NOTICE;
								}
							}
							else
							{
								int num4 = blockLoopEnd.VariableIndexes[1] - 1;
								num3 = NetworkSimulator.Instance.getClientVariable(num4);
								if (NetworkSimulator.Instance.ClientVariables[num4].isNumber())
								{
									text2 = NetworkWindow.Instance.Programs.ClientVariableNames[num4] + "「" + NetworkSimulator.Instance.ClientVariables[num4].Value + "」";
								}
								else
								{
									text2 = NetworkWindow.Instance.Programs.ClientVariableNames[num4] + "「\"" + NetworkSimulator.Instance.ClientVariables[num4].Value + "\"」";
									importance = NetworkLog.IMPORTANCE.NOTICE;
								}
							}
							break;
						case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST_STRING:
							if (!this.tryParse(blockLoopEnd.ConstString, out num3))
							{
								num3 = 0.0;
								importance = NetworkLog.IMPORTANCE.NOTICE;
							}
							text2 = blockLoopEnd.ConstString;
							break;
						}
						switch (blockLoopEnd.Select)
						{
						case ProgramModule.BlockIf.SELECT.BUTTON_ON:
							flag = clientVariable < num3;
							NetworkLog.Instance.addLog(importance, "比較：" + text + " < " + text2);
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
							flag = clientVariable == num3;
							NetworkLog.Instance.addLog(importance, "比較：" + text + " == " + text2);
							break;
						case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
							flag = clientVariable > num3;
							NetworkLog.Instance.addLog(importance, "比較：" + text + " > " + text2);
							break;
						}
						NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
						break;
					}
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.BUTTON:
						flag = ((blockLoopEnd.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON) ? NetworkSimulator.Instance.HardwareInfo.IsButtonOn : (!NetworkSimulator.Instance.HardwareInfo.IsButtonOn));
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.LIGHT:
						switch (blockLoopEnd.Variable)
						{
						case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INVALID:
							flag = ((blockLoopEnd.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON) ? NetworkSimulator.Instance.HardwareInfo.IsBright : (!NetworkSimulator.Instance.HardwareInfo.IsBright));
							break;
						case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST:
							switch (blockLoopEnd.Select)
							{
							case ProgramModule.BlockIf.SELECT.BUTTON_ON:
								flag = NetworkSimulator.Instance.HardwareInfo.LightValue > blockLoopEnd.Values[0];
								break;
							case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
								flag = NetworkSimulator.Instance.HardwareInfo.LightValue < blockLoopEnd.Values[0];
								break;
							case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
								flag = NetworkSimulator.Instance.HardwareInfo.LightValue == blockLoopEnd.Values[0];
								break;
							}
							break;
						case ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX:
						{
							double clientVariable2 = NetworkSimulator.Instance.getClientVariable(blockLoopEnd.VariableIndexes[0]);
							switch (blockLoopEnd.Select)
							{
							case ProgramModule.BlockIf.SELECT.BUTTON_ON:
								flag = (double)NetworkSimulator.Instance.HardwareInfo.LightValue > clientVariable2;
								break;
							case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
								flag = (double)NetworkSimulator.Instance.HardwareInfo.LightValue < clientVariable2;
								break;
							case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
								flag = (double)NetworkSimulator.Instance.HardwareInfo.LightValue == clientVariable2;
								break;
							}
							break;
						}
						}
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.TEMPERATURE:
					{
						ProgramModule.BlockIf.VARIABLE_TYPE_SECOND variable = blockLoopEnd.Variable;
						if (variable != ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.CONST)
						{
							if (variable == ProgramModule.BlockIf.VARIABLE_TYPE_SECOND.INDEX)
							{
								double clientVariable3 = NetworkSimulator.Instance.getClientVariable(blockLoopEnd.VariableIndexes[0]);
								switch (blockLoopEnd.Select)
								{
								case ProgramModule.BlockIf.SELECT.BUTTON_ON:
									flag = (double)NetworkSimulator.Instance.HardwareInfo.Temperature < clientVariable3;
									break;
								case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
									flag = (double)NetworkSimulator.Instance.HardwareInfo.Temperature == clientVariable3;
									break;
								case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
									flag = (double)NetworkSimulator.Instance.HardwareInfo.Temperature > clientVariable3;
									break;
								}
							}
						}
						else
						{
							switch (blockLoopEnd.Select)
							{
							case ProgramModule.BlockIf.SELECT.BUTTON_ON:
								flag = NetworkSimulator.Instance.HardwareInfo.Temperature < blockLoopEnd.Values[0];
								break;
							case ProgramModule.BlockIf.SELECT.BUTTON_OFF:
								flag = NetworkSimulator.Instance.HardwareInfo.Temperature == blockLoopEnd.Values[0];
								break;
							case ProgramModule.BlockIf.SELECT.BUTTON_MAX:
								flag = NetworkSimulator.Instance.HardwareInfo.Temperature > blockLoopEnd.Values[0];
								break;
							}
						}
						break;
					}
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.SOUND:
						flag = ((blockLoopEnd.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON) ? NetworkSimulator.Instance.HardwareInfo.IsSoundOn : (!NetworkSimulator.Instance.HardwareInfo.IsSoundOn));
						break;
					case ProgramModule.BlockLoopEnd.CONDITION_NETWORK_LOOP_END.USBIN:
						flag = ((blockLoopEnd.Select == ProgramModule.BlockIf.SELECT.BUTTON_ON) ? NetworkSimulator.Instance.HardwareInfo.IsUsbInOn : (!NetworkSimulator.Instance.HardwareInfo.IsUsbInOn));
						break;
					}
					if (flag)
					{
						this._loopIndex--;
						return true;
					}
				}
				if (this._loopCounts[this._loopIndex] > 0)
				{
					this._loopCounts[this._loopIndex]--;
					return false;
				}
				if (this._loopCounts[this._loopIndex] == -1)
				{
					return false;
				}
				this._loopIndex--;
				return true;
			}

			// Token: 0x060010A1 RID: 4257 RVA: 0x000943B4 File Offset: 0x000925B4
			private void runProgramDisplay(ProgramModule.BlockNetworkDisplay blockDisplay)
			{
				NetworkProgramModules.ObjectInfo @object = NetworkSimulator.Instance.Programs.getObject(blockDisplay.ObjectName);
				if (@object != null)
				{
					NetworkSimulator.NetworkVariable variable = new NetworkSimulator.NetworkVariable("", "", "");
					if (blockDisplay.Visible == ProgramModule.BlockNetworkDisplay.VISIBLE.ON)
					{
						switch (blockDisplay.ValueType)
						{
						case ProgramModule.BlockNetworkDisplay.VALUE_TYPE.INPUT:
							variable.Value = NetworkSimulator.Instance.InputVariable;
							break;
						case ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CLIENT:
							variable = NetworkSimulator.Instance.ClientVariables[blockDisplay.VariableIndex];
							break;
						case ProgramModule.BlockNetworkDisplay.VALUE_TYPE.CONST:
							variable.Value = blockDisplay.ConstValue;
							break;
						}
					}
					switch (blockDisplay.ObjectType)
					{
					case ProgramModule.BlockEvent.OBJECT_TYPE.LABEL:
					{
						NetworkObjectLabel label = (NetworkObjectLabel)((NetworkProgramModules.ObjectLabelInfo)@object).Control;
						label.Invoke(new MethodInvoker(delegate
						{
							label.Text = variable.Value;
						}));
						return;
					}
					case ProgramModule.BlockEvent.OBJECT_TYPE.LIST:
					{
						NetworkObjectList list = (NetworkObjectList)((NetworkProgramModules.ObjectListInfo)@object).Control;
						list.Invoke(new MethodInvoker(delegate
						{
							if (blockDisplay.Visible == ProgramModule.BlockNetworkDisplay.VISIBLE.ON)
							{
								if (variable.Value == "")
								{
									variable.Value = " ";
								}
								list.addLog(variable);
								return;
							}
							list.clearText();
						}));
						return;
					}
					case ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON:
					{
						NetworkObjectButton button = (NetworkObjectButton)((NetworkProgramModules.ObjectButtonInfo)@object).Control;
						button.Invoke(new MethodInvoker(delegate
						{
							button.Text = variable.Value;
						}));
						return;
					}
					case ProgramModule.BlockEvent.OBJECT_TYPE.INPUT:
					{
						NetworkObjectInput input = (NetworkObjectInput)((NetworkProgramModules.ObjectInputInfo)@object).Control;
						input.Invoke(new MethodInvoker(delegate
						{
							input.PlaceHolder.PlaceHolder = variable.Value;
						}));
						break;
					}
					case ProgramModule.BlockEvent.OBJECT_TYPE.GRAPH:
						break;
					default:
						return;
					}
				}
			}

			// Token: 0x060010A2 RID: 4258 RVA: 0x000153E3 File Offset: 0x000135E3
			private void runProgramSound(ProgramModule.BlockNetworkSound blockSound)
			{
			}

			// Token: 0x060010A3 RID: 4259 RVA: 0x00094568 File Offset: 0x00092768
			private void runProgramOutput(ProgramModule.BlockOutput blockOutput)
			{
				bool flag = true;
				ProgramModule.BlockOutput.OUTPUT_TYPE outputType = blockOutput.OutputType;
				if (outputType != ProgramModule.BlockOutput.OUTPUT_TYPE.LED)
				{
					if (outputType == ProgramModule.BlockOutput.OUTPUT_TYPE.SOUND)
					{
						switch (blockOutput.SoundMode)
						{
						case ProgramModule.BlockSound.MODE.BEEP:
							flag = CommunicationModule.Instance.playSE(blockOutput.BeepIndex);
							if (flag)
							{
								float[] array = new float[] { 0.6f, 0.8f, 1.2f };
								this._waitTime = array[blockOutput.BeepIndex];
								while (this._waitTime > 0f)
								{
									this._waitTime -= 0.1f;
									Thread.Sleep(100);
									if (!this._isRunning)
									{
										break;
									}
								}
							}
							break;
						case ProgramModule.BlockSound.MODE.MELODY_PLAY:
							flag = CommunicationModule.Instance.playMelody(0, blockOutput.Loop);
							break;
						case ProgramModule.BlockSound.MODE.MELODY_STOP:
							flag = CommunicationModule.Instance.stopMelody();
							break;
						}
					}
				}
				else
				{
					switch (blockOutput.Mode)
					{
					case ProgramModule.BlockLED.LED_MODE.ON:
						flag = CommunicationModule.Instance.setLEDOn(Color.FromArgb((int)((double)blockOutput.Red * 25.5), (int)((double)blockOutput.Green * 25.5), (int)((double)blockOutput.Blue * 25.5)));
						break;
					case ProgramModule.BlockLED.LED_MODE.OFF:
						flag = CommunicationModule.Instance.setLEDOff();
						break;
					}
				}
				if (!flag)
				{
					NetworkSimulator.Instance.stop(NetworkSimulator.ERROR.NONE);
				}
			}

			// Token: 0x060010A4 RID: 4260 RVA: 0x000946B8 File Offset: 0x000928B8
			private void runProgramUsbOut(ProgramModule.BlockUsbOut blockUsbOut)
			{
				bool flag = true;
				ProgramModule.BlockUsbOut.USBOUT mode = blockUsbOut.Mode;
				if (mode != ProgramModule.BlockUsbOut.USBOUT.ON)
				{
					if (mode == ProgramModule.BlockUsbOut.USBOUT.OFF)
					{
						flag = CommunicationModule.Instance.setUsbOutOff();
					}
				}
				else
				{
					flag = CommunicationModule.Instance.setUsbOutOn(blockUsbOut.Power);
				}
				if (!flag)
				{
					NetworkSimulator.Instance.stop(NetworkSimulator.ERROR.NONE);
				}
			}

			// Token: 0x040008CE RID: 2254
			public ProgramModule ProgramModule = new ProgramModule();

			// Token: 0x040008CF RID: 2255
			public int ObjectId;

			// Token: 0x040008D0 RID: 2256
			[XmlIgnore]
			public bool Selected;

			// Token: 0x040008D1 RID: 2257
			private bool _isRunning;

			// Token: 0x040008D2 RID: 2258
			private int[] _loopCounts = new int[6];

			// Token: 0x040008D3 RID: 2259
			private ProgramModule.BlockLoopStart[] _loopStartBlocks = new ProgramModule.BlockLoopStart[6];

			// Token: 0x040008D4 RID: 2260
			private int _loopIndex = -1;

			// Token: 0x040008D5 RID: 2261
			private float _waitTime;

			// Token: 0x040008D6 RID: 2262
			private List<ProgramModule.BlockSubroutine> _callStack = new List<ProgramModule.BlockSubroutine>();

			// Token: 0x040008D7 RID: 2263
			[XmlIgnore]
			public List<bool> Messages = new List<bool>();
		}

		// Token: 0x020000B3 RID: 179
		public class ObjectInputInfo : NetworkProgramModules.ObjectInfo
		{
			// Token: 0x060010A9 RID: 4265 RVA: 0x00094764 File Offset: 0x00092964
			public ObjectInputInfo()
			{
				this.ProgramModule.initialize(true, ProgramModule.BlockEvent.OBJECT_TYPE.INPUT);
			}

			// Token: 0x060010AA RID: 4266 RVA: 0x00094784 File Offset: 0x00092984
			public override void initialize()
			{
				base.initialize();
				this.ProgramModule.initialize(true, ProgramModule.BlockEvent.OBJECT_TYPE.INPUT);
				this.DefaultText = "ここに文字を入力";
				if (this.Control != null)
				{
					this.restoreObject();
				}
				NetworkProgramModules.ObjectNewCounts[4]++;
				this.ObjectId = NetworkProgramModules.ObjectNewCounts[4];
			}

			// Token: 0x060010AB RID: 4267 RVA: 0x000947DB File Offset: 0x000929DB
			public override string getObjectName()
			{
				return "入力バー";
			}

			// Token: 0x060010AC RID: 4268 RVA: 0x000947E2 File Offset: 0x000929E2
			public override void storeObject()
			{
				this.DefaultText = ((NetworkObjectInput)this.Control).PlaceHolder.PlaceHolder;
			}

			// Token: 0x060010AD RID: 4269 RVA: 0x000947FF File Offset: 0x000929FF
			public override Control restoreObject()
			{
				((NetworkObjectInput)this.Control).PlaceHolder.PlaceHolder = this.DefaultText;
				return null;
			}

			// Token: 0x060010AE RID: 4270 RVA: 0x0009481D File Offset: 0x00092A1D
			public override void reset(int messageCount)
			{
				base.reset(messageCount);
				((NetworkObjectInput)this.Control).PlaceHolder.PlaceHolder = this.DefaultText;
				this.Control.Text = "";
			}

			// Token: 0x060010AF RID: 4271 RVA: 0x00094851 File Offset: 0x00092A51
			public string getText()
			{
				return ((NetworkObjectInput)this.Control).Text;
			}

			// Token: 0x040008D8 RID: 2264
			public string DefaultText = "ここに文字を入力";
		}

		// Token: 0x020000B4 RID: 180
		public class ObjectStageInfo : NetworkProgramModules.ObjectInfo
		{
			// Token: 0x060010B0 RID: 4272 RVA: 0x00094863 File Offset: 0x00092A63
			public ObjectStageInfo()
			{
				this.ProgramModule.initialize(true, ProgramModule.BlockEvent.OBJECT_TYPE.STAGE);
			}

			// Token: 0x060010B1 RID: 4273 RVA: 0x00094878 File Offset: 0x00092A78
			public override void initialize()
			{
				base.initialize();
				this.ProgramModule.initialize(true, ProgramModule.BlockEvent.OBJECT_TYPE.STAGE);
			}

			// Token: 0x060010B2 RID: 4274 RVA: 0x0009488D File Offset: 0x00092A8D
			public override string getObjectName()
			{
				return "ステージ";
			}
		}

		// Token: 0x020000B5 RID: 181
		public class ObjectButtonInfo : NetworkProgramModules.ObjectInfo
		{
			// Token: 0x060010B3 RID: 4275 RVA: 0x00094894 File Offset: 0x00092A94
			public ObjectButtonInfo()
			{
				this.ProgramModule.initialize(true, ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON);
			}

			// Token: 0x060010B4 RID: 4276 RVA: 0x00094912 File Offset: 0x00092B12
			public override void initialize()
			{
				base.initialize();
				this.ProgramModule.initialize(true, ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON);
				NetworkProgramModules.ObjectNewCounts[0]++;
				this.ObjectId = NetworkProgramModules.ObjectNewCounts[0];
			}

			// Token: 0x060010B5 RID: 4277 RVA: 0x00094944 File Offset: 0x00092B44
			public override string getObjectName()
			{
				return "ボタン" + this.ObjectId.ToString();
			}

			// Token: 0x060010B6 RID: 4278 RVA: 0x0009495C File Offset: 0x00092B5C
			public override void storeObject()
			{
				this.Caption = this.Control.Text;
				this.BackColor = this.Control.BackColor.ToArgb();
			}

			// Token: 0x060010B7 RID: 4279 RVA: 0x00094994 File Offset: 0x00092B94
			public override Control restoreObject()
			{
				NetworkObjectButton networkObjectButton = new NetworkObjectButton();
				networkObjectButton.Text = this.Caption;
				FontStyle fontStyle = (this.Bold ? FontStyle.Bold : FontStyle.Regular) | (this.Italic ? FontStyle.Italic : FontStyle.Regular);
				networkObjectButton.Font = new Font(this.FontName, this.TextSize, fontStyle, GraphicsUnit.Point, 128);
				networkObjectButton.ForeColor = Color.FromArgb(this.TextColor);
				networkObjectButton.TextAlign = this.Alignment;
				networkObjectButton.BackColor = Color.FromArgb(this.BackColor);
				this.Control = networkObjectButton;
				return this.Control;
			}

			// Token: 0x060010B8 RID: 4280 RVA: 0x00094A26 File Offset: 0x00092C26
			public override void reset(int messageCount)
			{
				base.reset(messageCount);
				this.Control.Text = this.Caption;
			}

			// Token: 0x040008D9 RID: 2265
			public string Caption = "ボタン";

			// Token: 0x040008DA RID: 2266
			public string FontName = "メイリオ";

			// Token: 0x040008DB RID: 2267
			public float TextSize = 16f;

			// Token: 0x040008DC RID: 2268
			public bool Bold;

			// Token: 0x040008DD RID: 2269
			public bool Italic;

			// Token: 0x040008DE RID: 2270
			public int TextColor = Color.Black.ToArgb();

			// Token: 0x040008DF RID: 2271
			public ContentAlignment Alignment = ContentAlignment.MiddleCenter;

			// Token: 0x040008E0 RID: 2272
			public int BackColor = Color.FromArgb(240, 130, 130).ToArgb();
		}

		// Token: 0x020000B6 RID: 182
		public class ObjectLabelInfo : NetworkProgramModules.ObjectInfo
		{
			// Token: 0x060010B9 RID: 4281 RVA: 0x00094A40 File Offset: 0x00092C40
			public ObjectLabelInfo()
			{
				this.ProgramModule.initialize(true, ProgramModule.BlockEvent.OBJECT_TYPE.LABEL);
			}

			// Token: 0x060010BA RID: 4282 RVA: 0x00094ABB File Offset: 0x00092CBB
			public override void initialize()
			{
				base.initialize();
				this.ProgramModule.initialize(true, ProgramModule.BlockEvent.OBJECT_TYPE.LABEL);
				NetworkProgramModules.ObjectNewCounts[1]++;
				this.ObjectId = NetworkProgramModules.ObjectNewCounts[1];
			}

			// Token: 0x060010BB RID: 4283 RVA: 0x00094AED File Offset: 0x00092CED
			public override string getObjectName()
			{
				return "テキスト表示" + this.ObjectId.ToString();
			}

			// Token: 0x060010BC RID: 4284 RVA: 0x00094B04 File Offset: 0x00092D04
			public override void storeObject()
			{
				this.Caption = this.Control.Text;
				this.BackColor = this.Control.BackColor.ToArgb();
			}

			// Token: 0x060010BD RID: 4285 RVA: 0x00094B3C File Offset: 0x00092D3C
			public override Control restoreObject()
			{
				Label label = new NetworkObjectLabel();
				label.Text = this.Caption;
				FontStyle fontStyle = (this.Bold ? FontStyle.Bold : FontStyle.Regular) | (this.Italic ? FontStyle.Italic : FontStyle.Regular);
				label.Font = new Font(this.FontName, this.TextSize, fontStyle, GraphicsUnit.Point, 128);
				label.ForeColor = Color.FromArgb(this.TextColor);
				label.TextAlign = this.Alignment;
				label.BackColor = Color.FromArgb(this.BackColor);
				this.Control = label;
				return this.Control;
			}

			// Token: 0x060010BE RID: 4286 RVA: 0x00094BCE File Offset: 0x00092DCE
			public override void reset(int messageCount)
			{
				base.reset(messageCount);
				this.Control.Text = this.Caption;
			}

			// Token: 0x040008E1 RID: 2273
			public string Caption = "テキスト";

			// Token: 0x040008E2 RID: 2274
			public string FontName = "メイリオ";

			// Token: 0x040008E3 RID: 2275
			public float TextSize = 16f;

			// Token: 0x040008E4 RID: 2276
			public bool Bold;

			// Token: 0x040008E5 RID: 2277
			public bool Italic;

			// Token: 0x040008E6 RID: 2278
			public int TextColor = Color.Black.ToArgb();

			// Token: 0x040008E7 RID: 2279
			public ContentAlignment Alignment = ContentAlignment.MiddleCenter;

			// Token: 0x040008E8 RID: 2280
			public int BackColor = Color.FromArgb(255, 190, 90).ToArgb();
		}

		// Token: 0x020000B7 RID: 183
		public class ObjectListInfo : NetworkProgramModules.ObjectInfo
		{
			// Token: 0x060010BF RID: 4287 RVA: 0x00094BE8 File Offset: 0x00092DE8
			private ObjectListInfo()
			{
			}

			// Token: 0x060010C0 RID: 4288 RVA: 0x00094C54 File Offset: 0x00092E54
			public ObjectListInfo(NetworkObjectList.KIND kind)
			{
				this.ProgramModule.initialize(true, ProgramModule.BlockEvent.OBJECT_TYPE.LIST);
				this.Kind = kind;
				switch (kind)
				{
				case NetworkObjectList.KIND.NORMAL:
					this.BackColor = Color.FromArgb(243, 245, 198).ToArgb();
					return;
				case NetworkObjectList.KIND.NOTE:
					this.BackColor = Color.FromArgb(216, 245, 198).ToArgb();
					return;
				case NetworkObjectList.KIND.BALLOON:
					this.BackColor = Color.FromArgb(210, 231, 236).ToArgb();
					return;
				default:
					return;
				}
			}

			// Token: 0x060010C1 RID: 4289 RVA: 0x00094D4E File Offset: 0x00092F4E
			public override void initialize()
			{
				base.initialize();
				this.ProgramModule.initialize(true, ProgramModule.BlockEvent.OBJECT_TYPE.LIST);
				NetworkProgramModules.ObjectNewCounts[2]++;
				this.ObjectId = NetworkProgramModules.ObjectNewCounts[2];
			}

			// Token: 0x060010C2 RID: 4290 RVA: 0x00094D80 File Offset: 0x00092F80
			public override string getObjectName()
			{
				return "リスト" + this.ObjectId.ToString();
			}

			// Token: 0x060010C3 RID: 4291 RVA: 0x00094D98 File Offset: 0x00092F98
			public override void storeObject()
			{
				NetworkObjectList networkObjectList = (NetworkObjectList)this.Control;
				this.Kind = networkObjectList.Kind;
			}

			// Token: 0x060010C4 RID: 4292 RVA: 0x00094DC0 File Offset: 0x00092FC0
			public override Control restoreObject()
			{
				NetworkObjectList networkObjectList = new NetworkObjectList(this.Kind, Color.FromArgb(this.BackColor));
				this.Control = networkObjectList;
				return this.Control;
			}

			// Token: 0x060010C5 RID: 4293 RVA: 0x00094DF1 File Offset: 0x00092FF1
			public override void reset(int messageCount)
			{
				base.reset(messageCount);
				((NetworkObjectList)this.Control).clearText();
			}

			// Token: 0x040008E9 RID: 2281
			public NetworkObjectList.KIND Kind;

			// Token: 0x040008EA RID: 2282
			public string FontName = "メイリオ";

			// Token: 0x040008EB RID: 2283
			public float TextSize = 20f;

			// Token: 0x040008EC RID: 2284
			public bool Bold;

			// Token: 0x040008ED RID: 2285
			public bool Italic;

			// Token: 0x040008EE RID: 2286
			public int TextColor = Color.Black.ToArgb();

			// Token: 0x040008EF RID: 2287
			public ContentAlignment Alignment = ContentAlignment.TopLeft;

			// Token: 0x040008F0 RID: 2288
			public int BackColor;

			// Token: 0x040008F1 RID: 2289
			public int LineColor = Color.Black.ToArgb();

			// Token: 0x040008F2 RID: 2290
			public int LineWidth = 1;

			// Token: 0x040008F3 RID: 2291
			public bool UserVisible = true;

			// Token: 0x040008F4 RID: 2292
			public bool IpVisible = true;
		}

		// Token: 0x020000B8 RID: 184
		public class ObjectGraphInfo : NetworkProgramModules.ObjectInfo
		{
		}

		// Token: 0x020000B9 RID: 185
		public class SplitterInfo : NetworkProgramModules.NodeInfo
		{
			// Token: 0x060010C7 RID: 4295 RVA: 0x00094E12 File Offset: 0x00093012
			public override void storeObject()
			{
				this.Orientation = ((SplitContainer)this.Control).Orientation;
				this.Offset = ((SplitContainer)this.Control).SplitterDistance;
			}

			// Token: 0x060010C8 RID: 4296 RVA: 0x00094E40 File Offset: 0x00093040
			public override Control restoreObject()
			{
				SplitContainer splitContainer = new SplitContainer();
				splitContainer.Orientation = this.Orientation;
				splitContainer.SplitterDistance = this.Offset;
				this.Control = splitContainer;
				return splitContainer;
			}

			// Token: 0x040008F5 RID: 2293
			public NetworkProgramModules.NodeInfo Right;

			// Token: 0x040008F6 RID: 2294
			public NetworkProgramModules.NodeInfo Left;

			// Token: 0x040008F7 RID: 2295
			public int Offset;

			// Token: 0x040008F8 RID: 2296
			public Orientation Orientation;
		}
	}
}
