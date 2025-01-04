using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace DebugInjector
{
	// Token: 0x02000002 RID: 2
	public partial class DebugInjectorMain : Form
	{
		// Token: 0x06000001 RID: 1
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(IntPtr dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

		// Token: 0x06000002 RID: 2
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		// Token: 0x06000003 RID: 3
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000004 RID: 4
		[DllImport("kernel32.dll")]
		public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		// Token: 0x06000005 RID: 5
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x06000006 RID: 6
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		// Token: 0x06000007 RID: 7
		[DllImport("kernel32.dll")]
		public static extern int CloseHandle(IntPtr hObject);

		// Token: 0x06000008 RID: 8
		[DllImport("kernel32.dll")]
		private static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint dwFreeType);

		// Token: 0x06000009 RID: 9
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

		// Token: 0x0600000A RID: 10
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool FreeLibrary(IntPtr hModule);

		// Token: 0x0600000B RID: 11
		[DllImport("psapi.dll", SetLastError = true)]
		public static extern bool EnumProcessModulesEx(IntPtr hProcess, [Out] IntPtr[] lphModule, uint cb, out uint lpcbNeeded, uint dwFilterFlag);

		// Token: 0x0600000C RID: 12
		[DllImport("psapi.dll", CharSet = CharSet.Auto)]
		public static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] char[] lpBaseName, uint nSize);

		// Token: 0x0600000D RID: 13 RVA: 0x00002048 File Offset: 0x00000248
		public DebugInjectorMain()
		{
			this.InitializeComponent();
			this.contextMenu = new ContextMenuStrip();
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Delete");
			toolStripMenuItem.Click += delegate(object s, EventArgs e)
			{
				this.DeleteItem(s);
			};
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("Information");
			toolStripMenuItem2.Click += delegate(object s, EventArgs e)
			{
				this.ShowInfo(s);
			};
			ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem("Open in explorer");
			toolStripMenuItem3.Click += delegate(object s, EventArgs e)
			{
				this.jumpPath(s);
			};
			this.contextMenu.Items.Add(toolStripMenuItem);
			this.contextMenu.Items.Add(toolStripMenuItem2);
			this.contextMenu.Items.Add(toolStripMenuItem3);
			this.configData = new ConfigData();
			this.check.Checked = true;
			this.timer1.Start();
			bool flag = File.Exists(this.config);
			if (flag)
			{
				try
				{
					this.LoadConfigData();
					this.current.Text = "Current Dll: " + Path.GetFileName(this.configData.Dll);
					this.currentDllpath = this.configData.Dll;
					bool flag2 = this.configData.url != null;
					if (flag2)
					{
						this.urlbox.Text = this.configData.url;
					}
					this.InitializePanels();
				}
				catch
				{
				}
			}
			else
			{
				this.configData = new ConfigData
				{
					Panels = new List<PanelData>()
				};
				File.AppendAllText(this.config, JsonConvert.SerializeObject(this.configData, Formatting.Indented));
			}
			this.dllPanel = this.ps;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002258 File Offset: 0x00000458
		public static bool UninjectDll(string processName, string dllPath)
		{
			Process[] processesByName = Process.GetProcessesByName(processName);
			bool flag = processesByName.Length == 0;
			bool flag2;
			if (flag)
			{
				MessageBox.Show(processName + " is not opened", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				flag2 = false;
			}
			else
			{
				Process process = processesByName.First((Process p) => p.Responding);
				IntPtr intPtr = DebugInjectorMain.OpenProcess((IntPtr)2035711, false, (uint)process.Id);
				bool flag3 = intPtr == IntPtr.Zero;
				if (flag3)
				{
					MessageBox.Show("Failed to open process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					flag2 = false;
				}
				else
				{
					IntPtr[] array = new IntPtr[1024];
					uint num;
					bool flag4 = DebugInjectorMain.EnumProcessModulesEx(intPtr, array, (uint)(IntPtr.Size * array.Length), out num, 3U);
					if (flag4)
					{
						int num2 = (int)(num / (uint)IntPtr.Size);
						int i = 0;
						while (i < num2)
						{
							char[] array2 = new char[1024];
							DebugInjectorMain.GetModuleFileNameEx(intPtr, array[i], array2, (uint)array2.Length);
							string text = new string(array2).TrimEnd(new char[1]);
							bool flag5 = text.Equals(dllPath, StringComparison.OrdinalIgnoreCase);
							if (flag5)
							{
								IntPtr intPtr2 = DebugInjectorMain.CreateRemoteThread(intPtr, IntPtr.Zero, 0U, DebugInjectorMain.GetProcAddress(DebugInjectorMain.GetModuleHandle("kernel32.dll"), "FreeLibraryAndExitThread"), array[i], 0U, IntPtr.Zero);
								bool flag6 = intPtr2 == IntPtr.Zero;
								if (flag6)
								{
									MessageBox.Show("Failed to create remote thread", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									return false;
								}
								DebugInjectorMain.CloseHandle(intPtr2);
								return true;
							}
							else
							{
								i++;
							}
						}
					}
					DebugInjectorMain.CloseHandle(intPtr);
					flag2 = false;
				}
			}
			return flag2;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000240C File Offset: 0x0000060C
		private void LoadConfigData()
		{
			bool flag = File.Exists(this.config);
			if (flag)
			{
				string text = File.ReadAllText(this.config);
				this.configData = JsonConvert.DeserializeObject<ConfigData>(text);
			}
			else
			{
				this.configData = new ConfigData
				{
					Panels = new List<PanelData>(),
					Dll = ""
				};
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002469 File Offset: 0x00000669
		private void DebugInjectorMain_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000246C File Offset: 0x0000066C
		private void inject_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002470 File Offset: 0x00000670
		private void inject_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Right;
			if (flag)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "DLL File(*.dll)|*.dll";
				openFileDialog.Title = "Select your client's dll";
				openFileDialog.RestoreDirectory = true;
				openFileDialog.CheckFileExists = true;
				bool flag2 = openFileDialog.ShowDialog() == DialogResult.OK;
				if (flag2)
				{
					Process[] processesByName = Process.GetProcessesByName("Minecraft.Windows");
					bool flag3 = processesByName.Length == 0;
					if (flag3)
					{
						MessageBox.Show("Open Minecraft First", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.status.Text = "Not Injected";
					}
					else
					{
						Process process = processesByName.First((Process p) => p.Responding);
						for (int i = 0; i < process.Modules.Count; i++)
						{
							bool flag4 = process.Modules[i].FileName == openFileDialog.FileName;
							if (flag4)
							{
								this.status.Text = "Injected";
							}
							else
							{
								this.status.Text = "Not Injected";
							}
						}
						this.currentDllpath = openFileDialog.FileName;
						this.current.Text = "Current Dll: " + Path.GetFileName(openFileDialog.FileName);
					}
				}
				else
				{
					MessageBox.Show("Select valid dll!", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				bool flag5 = e.Button == MouseButtons.Left;
				if (flag5)
				{
					bool flag6 = File.Exists(this.currentDllpath);
					if (flag6)
					{
						this.Inject(this.currentDllpath);
					}
					else
					{
						MessageBox.Show("DLL Not found", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000263C File Offset: 0x0000083C
		private void Inject(string filePath)
		{
			bool flag = !File.Exists(filePath);
			if (flag)
			{
				MessageBox.Show("DLL Not found", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				try
				{
					FileInfo fileInfo = new FileInfo(filePath);
					FileSecurity accessControl = fileInfo.GetAccessControl();
					accessControl.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier("S-1-15-2-1"), FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
					fileInfo.SetAccessControl(accessControl);
				}
				catch (Exception)
				{
					MessageBox.Show("Could not set permissions, try running the injector as admin.", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				Process[] processesByName = Process.GetProcessesByName("Minecraft.Windows");
				bool flag2 = processesByName.Length == 0;
				if (flag2)
				{
					MessageBox.Show("Open Minecraft First", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					this.status.Text = "Not Injected";
				}
				else
				{
					Process process = processesByName.First((Process p) => p.Responding);
					for (int i = 0; i < process.Modules.Count; i++)
					{
						bool flag3 = process.Modules[i].FileName == filePath;
						if (flag3)
						{
							bool @checked = this.check.Checked;
							if (@checked)
							{
								MessageBox.Show("Already Injected!", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								this.status.Text = "Injected";
								return;
							}
						}
					}
					this.currentDllpath = filePath;
					this.current.Text = "Current Dll: " + Path.GetFileName(filePath);
					this.configData.Dll = this.currentDllpath;
					int id = processesByName[0].Id;
					IntPtr intPtr = DebugInjectorMain.OpenProcess(this.PROCESS_ALL_ACCESS, false, (uint)id);
					byte[] bytes = Encoding.Unicode.GetBytes(filePath + "\0");
					IntPtr intPtr2 = DebugInjectorMain.VirtualAllocEx(intPtr, IntPtr.Zero, (uint)bytes.Length, 4096U, 64U);
					int num;
					DebugInjectorMain.WriteProcessMemory(intPtr, intPtr2, bytes, (uint)bytes.Length, out num);
					IntPtr procAddress = DebugInjectorMain.GetProcAddress(DebugInjectorMain.GetModuleHandle("kernel32.dll"), "LoadLibraryW");
					IntPtr zero = IntPtr.Zero;
					IntPtr intPtr3 = DebugInjectorMain.CreateRemoteThread(intPtr, IntPtr.Zero, 0U, procAddress, intPtr2, 0U, zero);
					this.status.Text = "Injected";
					DebugInjectorMain.CloseHandle(intPtr3);
					DebugInjectorMain.CloseHandle(intPtr);
				}
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000028A4 File Offset: 0x00000AA4
		private void DeleteItem(object sender)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			bool flag = toolStripMenuItem != null;
			if (flag)
			{
				ContextMenuStrip contextMenuStrip = toolStripMenuItem.Owner as ContextMenuStrip;
				Panel panel;
				bool flag2;
				if (contextMenuStrip != null)
				{
					panel = contextMenuStrip.SourceControl as Panel;
					flag2 = panel != null;
				}
				else
				{
					flag2 = false;
				}
				bool flag3 = flag2;
				if (flag3)
				{
					this.ps.Controls.Remove(panel);
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002900 File Offset: 0x00000B00
		private void ShowInfo(object sender)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			bool flag = toolStripMenuItem != null;
			if (flag)
			{
				ContextMenuStrip contextMenuStrip = toolStripMenuItem.Owner as ContextMenuStrip;
				Panel panel;
				bool flag2;
				if (contextMenuStrip != null)
				{
					panel = contextMenuStrip.SourceControl as Panel;
					flag2 = panel != null;
				}
				else
				{
					flag2 = false;
				}
				bool flag3 = flag2;
				if (flag3)
				{
					LinkLabel linkLabel;
					bool flag4;
					if (panel.Controls.Count > 0)
					{
						linkLabel = panel.Controls[0] as LinkLabel;
						flag4 = linkLabel != null;
					}
					else
					{
						flag4 = false;
					}
					bool flag5 = flag4;
					if (flag5)
					{
						bool flag6 = !File.Exists(linkLabel.Tag.ToString());
						if (flag6)
						{
							MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else
						{
							long length = new FileInfo(linkLabel.Tag.ToString()).Length;
							MessageBox.Show(string.Format("File path: {0}\nFile name: {1}\nFile size: {2}.{3}MB", new object[]
							{
								linkLabel.Tag,
								Path.GetFileName(linkLabel.Tag.ToString()),
								length / 1024L / 1024L,
								length / 1024L / 100L
							}), "Here's the selected DLL's information");
						}
					}
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002A34 File Offset: 0x00000C34
		private void jumpPath(object sender)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			bool flag = toolStripMenuItem != null;
			if (flag)
			{
				ContextMenuStrip contextMenuStrip = toolStripMenuItem.Owner as ContextMenuStrip;
				Panel panel;
				bool flag2;
				if (contextMenuStrip != null)
				{
					panel = contextMenuStrip.SourceControl as Panel;
					flag2 = panel != null;
				}
				else
				{
					flag2 = false;
				}
				bool flag3 = flag2;
				if (flag3)
				{
					LinkLabel linkLabel;
					bool flag4;
					if (panel.Controls.Count > 0)
					{
						linkLabel = panel.Controls[0] as LinkLabel;
						flag4 = linkLabel != null;
					}
					else
					{
						flag4 = false;
					}
					bool flag5 = flag4;
					if (flag5)
					{
						bool flag6 = !File.Exists(linkLabel.Tag.ToString());
						if (flag6)
						{
							MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						else
						{
							Process.Start("explorer.exe", Path.GetDirectoryName(new FileInfo(linkLabel.Tag.ToString()).FullName));
						}
					}
				}
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002B0C File Offset: 0x00000D0C
		private void InitializePanels()
		{
			foreach (PanelData panelData in this.configData.Panels)
			{
				Panel panel = new Panel();
				panel.Size = new Size(this.ps.Width, 33);
				panel.BorderStyle = BorderStyle.FixedSingle;
				LinkLabel accessButton = new LinkLabel();
				accessButton.Text = panelData.Title ?? "";
				accessButton.Tag = panelData.Path ?? "";
				accessButton.LinkClicked += delegate(object sender2, LinkLabelLinkClickedEventArgs e2)
				{
					this.clicked(sender2, e2, string.Format("{0}", accessButton.Tag));
				};
				accessButton.Location = new Point(10, 10);
				accessButton.Dock = DockStyle.Fill;
				accessButton.LinkBehavior = LinkBehavior.NeverUnderline;
				accessButton.LinkColor = Color.White;
				accessButton.Font = new Font("Open Sans", 11f);
				accessButton.Location = new Point(150, 35);
				panel.Controls.Add(accessButton);
				panel.ContextMenuStrip = this.contextMenu;
				panel.Dock = DockStyle.Top;
				panel.BorderStyle = BorderStyle.FixedSingle;
				this.ps.Controls.Add(panel);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002CB8 File Offset: 0x00000EB8
		private void clicked(object sender, LinkLabelLinkClickedEventArgs e, string path)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				try
				{
					this.currentDllpath = path;
					this.current.Text = "Current Dll: " + Path.GetFileName(path);
					Process[] processesByName = Process.GetProcessesByName("Minecraft.Windows");
					bool flag2 = processesByName.Length == 0;
					if (flag2)
					{
						this.status.Text = "Not Injected";
					}
					else
					{
						Process process = processesByName.First((Process p) => p.Responding);
						for (int i = 0; i < process.Modules.Count; i++)
						{
							bool flag3 = process.Modules[i].FileName == path;
							if (flag3)
							{
								this.status.Text = "Injected";
							}
							else
							{
								this.status.Text = "Not Injected";
							}
						}
						MessageBox.Show("Switched to " + Path.GetFileName(path) + "!", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002E00 File Offset: 0x00001000
		private void button1_Click(object sender, EventArgs e)
		{
			this.SaveConfigData();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002E0C File Offset: 0x0000100C
		private void SaveConfigData()
		{
			bool flag = this.configData != null && this.configData.Panels != null;
			if (flag)
			{
				bool flag2 = this.urlbox.Text != null;
				if (flag2)
				{
					this.configData.url = this.urlbox.Text;
				}
				List<PanelData> panels = this.configData.Panels;
				if (panels != null)
				{
					panels.Clear();
				}
				foreach (object obj in this.ps.Controls)
				{
					Control control = (Control)obj;
					Panel panel = control as Panel;
					bool flag3 = panel != null;
					if (flag3)
					{
						LinkLabel linkLabel;
						bool flag4;
						if (panel.Controls.Count > 0)
						{
							linkLabel = panel.Controls[0] as LinkLabel;
							flag4 = linkLabel != null;
						}
						else
						{
							flag4 = false;
						}
						bool flag5 = flag4;
						if (flag5)
						{
							PanelData panelData = new PanelData
							{
								Title = linkLabel.Text,
								Path = linkLabel.Tag.ToString()
							};
							this.configData.Panels.Add(panelData);
						}
					}
				}
				string text = JsonConvert.SerializeObject(this.configData, Formatting.Indented);
				bool flag6 = text != null;
				if (flag6)
				{
					File.WriteAllText(this.config, text);
				}
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002F80 File Offset: 0x00001180
		private void addlist_MouseUp(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Right;
			if (flag)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "DLL File(*.dll)|*.dll";
				openFileDialog.Title = "Select your client's dll";
				openFileDialog.RestoreDirectory = true;
				openFileDialog.CheckFileExists = true;
				bool flag2 = openFileDialog.ShowDialog() == DialogResult.OK;
				if (flag2)
				{
					foreach (object obj in this.ps.Controls)
					{
						Control control = (Control)obj;
						Panel panel = control as Panel;
						bool flag3 = panel != null;
						if (flag3)
						{
							LinkLabel linkLabel;
							bool flag4;
							if (panel.Controls.Count > 0)
							{
								linkLabel = panel.Controls[0] as LinkLabel;
								flag4 = linkLabel != null;
							}
							else
							{
								flag4 = false;
							}
							bool flag5 = flag4;
							if (flag5)
							{
								bool flag6 = linkLabel.Tag.ToString() == openFileDialog.FileName;
								if (flag6)
								{
									MessageBox.Show("This DLL is already registered!", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									return;
								}
							}
						}
					}
					Panel panel2 = new Panel();
					panel2.Size = new Size(this.ps.Width, 33);
					panel2.BorderStyle = BorderStyle.FixedSingle;
					LinkLabel accessButton2 = new LinkLabel();
					accessButton2.Text = Path.GetFileName(openFileDialog.FileName) ?? "";
					accessButton2.Tag = openFileDialog.FileName ?? "";
					accessButton2.LinkClicked += delegate(object sender2, LinkLabelLinkClickedEventArgs e2)
					{
						this.clicked(sender2, e2, string.Format("{0}", accessButton2.Tag));
					};
					accessButton2.Location = new Point(10, 10);
					accessButton2.Dock = DockStyle.Fill;
					accessButton2.LinkBehavior = LinkBehavior.NeverUnderline;
					accessButton2.LinkColor = Color.White;
					accessButton2.Font = new Font("Open Sans", 11f);
					accessButton2.Location = new Point(150, 35);
					panel2.Controls.Add(accessButton2);
					panel2.ContextMenuStrip = this.contextMenu;
					panel2.Dock = DockStyle.Top;
					panel2.BorderStyle = BorderStyle.FixedSingle;
					this.ps.Controls.Add(panel2);
				}
				else
				{
					MessageBox.Show("Select valid dll!", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				bool flag7 = e.Button == MouseButtons.Left;
				if (flag7)
				{
					bool flag8 = !File.Exists(this.currentDllpath);
					if (flag8)
					{
						MessageBox.Show("Select valid dll!", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						foreach (object obj2 in this.ps.Controls)
						{
							Control control2 = (Control)obj2;
							Panel panel3 = control2 as Panel;
							bool flag9 = panel3 != null;
							if (flag9)
							{
								LinkLabel linkLabel2;
								bool flag10;
								if (panel3.Controls.Count > 0)
								{
									linkLabel2 = panel3.Controls[0] as LinkLabel;
									flag10 = linkLabel2 != null;
								}
								else
								{
									flag10 = false;
								}
								bool flag11 = flag10;
								if (flag11)
								{
									bool flag12 = linkLabel2.Tag.ToString() == this.currentDllpath;
									if (flag12)
									{
										MessageBox.Show("This DLL is already registered!", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										return;
									}
								}
							}
						}
						Panel panel4 = new Panel();
						panel4.Size = new Size(this.ps.Width, 33);
						panel4.BorderStyle = BorderStyle.FixedSingle;
						LinkLabel accessButton = new LinkLabel();
						accessButton.Text = Path.GetFileName(this.currentDllpath) ?? "";
						accessButton.Tag = this.currentDllpath ?? "";
						accessButton.LinkClicked += delegate(object sender2, LinkLabelLinkClickedEventArgs e2)
						{
							this.clicked(sender2, e2, string.Format("{0}", accessButton.Tag));
						};
						accessButton.Location = new Point(10, 10);
						accessButton.Dock = DockStyle.Fill;
						accessButton.LinkBehavior = LinkBehavior.NeverUnderline;
						accessButton.LinkColor = Color.White;
						accessButton.Font = new Font("Open Sans", 11f);
						accessButton.Location = new Point(150, 35);
						panel4.Controls.Add(accessButton);
						panel4.ContextMenuStrip = this.contextMenu;
						panel4.Dock = DockStyle.Top;
						panel4.BorderStyle = BorderStyle.FixedSingle;
						this.ps.Controls.Add(panel4);
					}
				}
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000034A4 File Offset: 0x000016A4
		private void addlist_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000034A8 File Offset: 0x000016A8
		private void timer1_Tick(object sender, EventArgs e)
		{
			Process[] processesByName = Process.GetProcessesByName("Minecraft.Windows");
			bool flag = processesByName.Length == 0;
			if (flag)
			{
				this.mcstat.Text = "Minecraft: Not Opened";
			}
			else
			{
				this.mcstat.Text = "Minecraft: Opened";
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000034F4 File Offset: 0x000016F4
		public async Task falseTop()
		{
			await Task.Delay(2000);
			base.TopMost = false;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003538 File Offset: 0x00001738
		private async void openmc_Click(object sender, EventArgs e)
		{
			Process[] processes = Process.GetProcessesByName("Minecraft.Windows");
			bool flag = processes.Length != 0;
			if (flag)
			{
				MessageBox.Show("Minecraft is already opened", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.status.Text = "Not Injected";
			}
			else
			{
				base.TopMost = true;
				bool flag2 = Interaction.Shell("explorer.exe shell:appsFolder\\Microsoft.MinecraftUWP_8wekyb3d8bbwe!App", AppWinStyle.MinimizedFocus, false, -1) == 0;
				if (flag2)
				{
					MessageBox.Show("Minecraft is already open", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				await this.falseTop();
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003580 File Offset: 0x00001780
		private void closemc_Click(object sender, EventArgs e)
		{
			Process[] processesByName = Process.GetProcessesByName("Minecraft.Windows");
			DialogResult dialogResult = MessageBox.Show("Are u sure?", "Debug Injector", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "taskkill",
					Arguments = "/f /im Minecraft.Windows.exe",
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true
				});
				MessageBox.Show("Cleaning Done me go home");
				this.status.Text = "Not Injected";
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003610 File Offset: 0x00001810
		private void button2_Click(object sender, EventArgs e)
		{
			Process[] processesByName = Process.GetProcessesByName("Minecraft.Windows");
			bool flag = processesByName.Length == 0;
			if (flag)
			{
				MessageBox.Show("Minecraft is not opened", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.status.Text = "Not Injected";
			}
			else
			{
				Process process = processesByName.First((Process p) => p.Responding);
				for (int i = 0; i < process.Modules.Count; i++)
				{
					bool flag2 = process.Modules[i].FileName == this.currentDllpath;
					if (flag2)
					{
						DebugInjectorMain.UninjectDll(process.ProcessName, this.currentDllpath);
					}
				}
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000036D3 File Offset: 0x000018D3
		private void button3_Click(object sender, EventArgs e)
		{
			Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Packages\\Microsoft.MinecraftUWP_8wekyb3d8bbwe\\RoamingState"));
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000036F0 File Offset: 0x000018F0
		private async void upload_Click(object sender, EventArgs e)
		{
			bool flag = !File.Exists(this.currentDllpath);
			if (flag)
			{
				MessageBox.Show("Select valid dll!", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				using (HttpClient httpClient = new HttpClient())
				{
					using (FileStream fileStream = File.OpenRead(this.currentDllpath))
					{
						StreamContent fileContent = new StreamContent(fileStream);
						using (MultipartFormDataContent formData = new MultipartFormDataContent())
						{
							HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("https://api.gofile.io/getServer");
							HttpResponseMessage response2 = httpResponseMessage;
							httpResponseMessage = null;
							string text = await response2.Content.ReadAsStringAsync();
							ServerData store = JsonConvert.DeserializeObject<ServerData>(text);
							text = null;
							formData.Add(fileContent, "file", Path.GetFileName(this.currentDllpath));
							HttpResponseMessage httpResponseMessage2 = await httpClient.PostAsync("https://" + store.data.server + ".gofile.io/uploadFile", formData);
							HttpResponseMessage response3 = httpResponseMessage2;
							httpResponseMessage2 = null;
							string text2 = await response3.Content.ReadAsStringAsync();
							string responseData2 = text2;
							text2 = null;
							try
							{
								ResponseData responseData3 = JsonConvert.DeserializeObject<ResponseData>(responseData2);
								string downloadPage = responseData3.data.downloadPage;
								Clipboard.SetText(downloadPage);
								MessageBox.Show("Successfully uploaded to GoFile!\nLink: " + downloadPage + "\n(copied in clipboard)", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								responseData3 = null;
								downloadPage = null;
							}
							catch
							{
								MessageBox.Show("Failed to upload in GoFile!", "Debug Injector", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							response2 = null;
							store = null;
							response3 = null;
							responseData2 = null;
						}
						MultipartFormDataContent formData = null;
						fileContent = null;
					}
					FileStream fileStream = null;
				}
				HttpClient httpClient = null;
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003737 File Offset: 0x00001937
		private void ps_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000373C File Offset: 0x0000193C
		public static string RandomString(int length)
		{
			Random random = new Random();
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
				select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003785 File Offset: 0x00001985
		private void loaddllfromurl_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003788 File Offset: 0x00001988
		private void button4_Click(object sender, EventArgs e)
		{
			string text = "c:\\windows\\temp";
			DialogResult dialogResult = MessageBox.Show("Are u sure?", "Debug Injector", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				foreach (string text2 in Directory.GetFiles(text))
				{
					try
					{
						File.Delete(text2);
					}
					catch
					{
					}
				}
				MessageBox.Show("Complete");
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003808 File Offset: 0x00001A08
		private void loaddllfromurl_MouseUp(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				bool flag2 = this.urlbox.Text.Length != 0;
				if (flag2)
				{
					WebClient webClient = new WebClient();
					string text = "c:\\windows\\temp\\" + DebugInjectorMain.RandomString(8) + ".dll";
					webClient.DownloadFile(this.urlbox.Text, text);
					webClient.Dispose();
					this.Inject(text);
				}
			}
			else
			{
				bool flag3 = e.Button == MouseButtons.Right;
				if (flag3)
				{
					bool flag4 = this.urlbox.Text.Length != 0;
					if (flag4)
					{
						using (SaveFileDialog saveFileDialog = new SaveFileDialog())
						{
							saveFileDialog.Filter = "DLL files (*.dll)|*.dll";
							saveFileDialog.DefaultExt = "dll";
							saveFileDialog.AddExtension = true;
							saveFileDialog.Title = "Save DLL File";
							WebClient webClient2 = new WebClient();
							string text2 = "c:\\windows\\temp\\" + DebugInjectorMain.RandomString(8) + ".dll";
							try
							{
								webClient2.DownloadFile(this.urlbox.Text, text2);
								webClient2.Dispose();
							}
							catch
							{
							}
							bool flag5 = saveFileDialog.ShowDialog() == DialogResult.OK;
							if (flag5)
							{
								string fileName = saveFileDialog.FileName;
								byte[] array = File.ReadAllBytes(text2);
								File.WriteAllBytes(fileName, array);
								File.Delete(text2);
								MessageBox.Show("DLL file saved successfully!", "Debug injector", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
						}
					}
				}
			}
		}

		// Token: 0x04000001 RID: 1
		public IntPtr PROCESS_ALL_ACCESS = (IntPtr)2035711;

		// Token: 0x04000002 RID: 2
		public IntPtr LIST_MODULES_ALL = (IntPtr)3;

		// Token: 0x04000003 RID: 3
		private ConfigData configData;

		// Token: 0x04000004 RID: 4
		private string config = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json");

		// Token: 0x04000005 RID: 5
		private ContextMenuStrip contextMenu;

		// Token: 0x04000006 RID: 6
		public Panel dllPanel = new Panel();

		// Token: 0x04000007 RID: 7
		public string currentDllpath = "";
	}
}
