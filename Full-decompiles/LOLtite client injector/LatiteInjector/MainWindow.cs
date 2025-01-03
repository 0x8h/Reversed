// Decompiled with JetBrains decompiler
// Type: LatiteInjector.MainWindow
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using LatiteInjector.Utils;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;

#nullable enable
namespace LatiteInjector
{
  public class MainWindow : Window, IComponentConnector
  {
    public static Process? Minecraft;
    public static string MinecraftVersion = "";
    private static readonly SettingsWindow SettingsWindow = new SettingsWindow();
    private static readonly ChangelogWindow ChangelogWindow = new ChangelogWindow();
    private static readonly CreditWindow CreditWindow = new CreditWindow();
    private static readonly WebClient? Client = new WebClient();
    public static bool IsMinecraftRunning;
    public static bool IsCustomDll;
    public static string? CustomDllName;
    public static readonly List<string> VersionList = new List<string>();
    private NotifyIcon? _notifyIcon;
    private readonly System.Windows.Forms.ContextMenu _contextMenu = new System.Windows.Forms.ContextMenu();
    private readonly System.Windows.Forms.MenuItem _menuItem = new System.Windows.Forms.MenuItem();
    private WindowState _storedWindowState;
    public static bool IsDiscordPresenceEnabled;
    public static bool IsHideToTrayEnabled;
    public static bool IsCloseAfterInjectedEnabled;
    internal 
    #nullable disable
    System.Windows.Controls.Label ChangelogLabel;
    internal System.Windows.Controls.Label CreditLabel;
    internal System.Windows.Controls.Button LaunchButton;
    internal System.Windows.Controls.Label StatusLabel;
    private bool _contentLoaded;

    public MainWindow()
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      AppDomain.CurrentDomain.UnhandledException += MainWindow.\u003C\u003EO.\u003C0\u003E__OnUnhandledException ?? (MainWindow.\u003C\u003EO.\u003C0\u003E__OnUnhandledException = new UnhandledExceptionEventHandler(MainWindow.OnUnhandledException));
      this.InitializeComponent();
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
      if (!Environment.Is64BitOperatingSystem)
      {
        int num = (int) System.Windows.MessageBox.Show("It looks like you're running a 32 bit OS/Computer. Sadly, you cannot use Latite Client with a 32 bit OS/Computer. Please do not report this as a bug, make a ticket, or ask how to switch to 64 bit in the Discord, you cannot use Latite Client AT ALL!!!", "32 bit OS/Computer", MessageBoxButton.OK, MessageBoxImage.Hand);
        System.Windows.Application.Current.Shutdown();
      }
      if (!FontManager.IsFontInstalled("Inter") && System.Windows.MessageBox.Show("The font that Latite Injector uses (Inter) is not installed. Do you want to install it?", "Install font", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
      {
        MainWindow.Client?.DownloadFile("https://github.com/Imrglop/Latite-Releases/raw/main/injector/InterFont.ttf", "Inter.ttf");
        FontManager.InstallFont(Directory.GetCurrentDirectory() + "\\Inter.ttf");
        System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\Inter.ttf");
      }
      Updater.UpdateInjector();
      DiscordPresence.InitializePresence();
      if (MainWindow.IsDiscordPresenceEnabled)
        DiscordPresence.DefaultPresence();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      MainWindow.SettingsWindow.Closing += MainWindow.\u003C\u003EO.\u003C1\u003E__OnClosing ?? (MainWindow.\u003C\u003EO.\u003C1\u003E__OnClosing = new CancelEventHandler(MainWindow.OnClosing));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      MainWindow.ChangelogWindow.Closing += MainWindow.\u003C\u003EO.\u003C1\u003E__OnClosing ?? (MainWindow.\u003C\u003EO.\u003C1\u003E__OnClosing = new CancelEventHandler(MainWindow.OnClosing));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      MainWindow.CreditWindow.Closing += MainWindow.\u003C\u003EO.\u003C1\u003E__OnClosing ?? (MainWindow.\u003C\u003EO.\u003C1\u003E__OnClosing = new CancelEventHandler(MainWindow.OnClosing));
      Updater.GetInjectorChangelog();
      Updater.GetClientChangelog();
      this._notifyIcon = new NotifyIcon();
      if (MainWindow.GetLine(System.IO.File.ReadAllText(SettingsWindow.ConfigFilePath), 4) == "firstrun:true")
      {
        this._notifyIcon.BalloonTipText = "Latite Injector has been minimized. Click the tray icon to bring back the Latite Injector. Right click the tray icon to exit the Latite Injector";
        this._notifyIcon.BalloonTipTitle = "I'm over here!";
        MainWindow.SettingsWindow.ModifyConfig("firstrun:false", 4);
      }
      else
      {
        this._notifyIcon.BalloonTipText = (string) null;
        this._notifyIcon.BalloonTipTitle = (string) null;
      }
      this._notifyIcon.Text = "Latite Client";
      Stream stream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Assets/latite.ico"))?.Stream;
      if (stream != null)
        this._notifyIcon.Icon = new System.Drawing.Icon(stream);
      this._notifyIcon.Click += new EventHandler(this.NotifyIconClick);
      this._contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[1]
      {
        this._menuItem
      });
      this._menuItem.Index = 0;
      this._menuItem.Text = "Exit Latite Client";
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this._menuItem.Click += MainWindow.\u003C\u003EO.\u003C2\u003E__MenuExitItem_Click ?? (MainWindow.\u003C\u003EO.\u003C2\u003E__MenuExitItem_Click = new EventHandler(MainWindow.MenuExitItem_Click));
      this._notifyIcon.ContextMenu = this._contextMenu;
    }

    private static void OpenGame()
    {
      new Process()
      {
        StartInfo = new ProcessStartInfo()
        {
          WindowStyle = ProcessWindowStyle.Normal,
          FileName = "explorer.exe",
          Arguments = "shell:appsFolder\\Microsoft.MinecraftUWP_8wekyb3d8bbwe!App"
        }
      }.Start();
    }

    private void OnStateChanged(
    #nullable enable
    object sender, EventArgs args)
    {
      if (MainWindow.IsHideToTrayEnabled)
      {
        if (this.WindowState == WindowState.Minimized)
        {
          this.Hide();
          if (MainWindow.IsDiscordPresenceEnabled)
            DiscordPresence.MinimizeToTrayPresence();
          if (this._notifyIcon?.BalloonTipText == null)
            return;
          this._notifyIcon.ShowBalloonTip(2000);
          this._notifyIcon.BalloonTipText = (string) null;
          this._notifyIcon.BalloonTipTitle = (string) null;
        }
        else
          this._storedWindowState = this.WindowState;
      }
      else
      {
        if (MainWindow.IsHideToTrayEnabled)
          return;
        System.Windows.Application.Current.Shutdown();
      }
    }

    private void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs args)
    {
      this.CheckTrayIcon();
    }

    private void NotifyIconClick(object sender, EventArgs e)
    {
      this.Show();
      if (MainWindow.IsDiscordPresenceEnabled)
      {
        if (!MainWindow.IsMinecraftRunning)
          DiscordPresence.IdlePresence();
        else if (MainWindow.IsMinecraftRunning)
          DiscordPresence.PlayingPresence();
      }
      this.WindowState = this._storedWindowState;
    }

    private void CheckTrayIcon() => this.ShowTrayIcon(!this.IsVisible);

    private void ShowTrayIcon(bool show)
    {
      if (this._notifyIcon == null)
        return;
      this._notifyIcon.Visible = show;
    }

    private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      LatiteInjector.Utils.Logging.ErrorLogging(e.ExceptionObject as Exception);
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
      this.WindowState = WindowState.Minimized;
    }

    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      this.DragMove();
    }

    public static string? GetLine(string? text, int lineNo)
    {
      string[] strArray1;
      if (text == null)
        strArray1 = (string[]) null;
      else
        strArray1 = text.Replace("\r", "").Split('\n');
      if (strArray1 == null)
        strArray1 = Array.Empty<string>();
      string[] strArray2 = strArray1;
      return strArray2.Length < lineNo ? (string) null : strArray2[lineNo - 1];
    }

    private async void LaunchButton_OnLeftClick(object sender, RoutedEventArgs e)
    {
      if (Process.GetProcessesByName("Minecaft.Windows").Length != 0)
        return;
      MainWindow.OpenGame();
      do
        ;
      while (Process.GetProcessesByName("Minecraft.Windows").Length == 0);
      MainWindow.Minecraft = Process.GetProcessesByName("Minecraft.Windows")[0];
      bool flag = true;
      while (MainWindow.MinecraftVersion.Length == 0)
      {
        int num1 = 0;
label_5:
        ++num1;
        try
        {
          MainWindow.MinecraftVersion = MainWindow.Minecraft.MainModule?.FileVersionInfo.FileVersion;
        }
        catch
        {
          if (num1 > 10)
          {
            int num2 = (int) System.Windows.MessageBox.Show("Could not inject. Please try again, or inject while Minecraft is already open.");
            return;
          }
          goto label_5;
        }
      }
      if (!flag)
        return;
      if (MainWindow.IsCustomDll)
        await Injector.WaitForModules();
      Injector.Inject(Updater.DownloadDll());
      MainWindow.IsMinecraftRunning = true;
      MainWindow.Minecraft.EnableRaisingEvents = true;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      MainWindow.Minecraft.Exited += MainWindow.\u003C\u003EO.\u003C3\u003E__IfMinecraftExited ?? (MainWindow.\u003C\u003EO.\u003C3\u003E__IfMinecraftExited = new EventHandler(MainWindow.IfMinecraftExited));
    }

    private async void LaunchButton_OnRightClick(object sender, RoutedEventArgs e)
    {
      SetStatusLabel.Pending("User is selecting DLL...");
      Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
      openFileDialog1.Filter = "DLL files (*.dll)|*.dll|All files (*.*)|*.*";
      openFileDialog1.RestoreDirectory = true;
      Microsoft.Win32.OpenFileDialog openFileDialog = openFileDialog1;
      bool? nullable = openFileDialog.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
      {
        SetStatusLabel.Default();
        openFileDialog = (Microsoft.Win32.OpenFileDialog) null;
      }
      else
      {
        MainWindow.CustomDllName = openFileDialog.SafeFileName;
        if (Process.GetProcessesByName("Minecaft.Windows").Length != 0)
        {
          openFileDialog = (Microsoft.Win32.OpenFileDialog) null;
        }
        else
        {
          MainWindow.OpenGame();
          do
            ;
          while (Process.GetProcessesByName("Minecraft.Windows").Length == 0);
          MainWindow.Minecraft = Process.GetProcessesByName("Minecraft.Windows")[0];
          MainWindow.IsCustomDll = true;
          await Injector.WaitForModules();
          Injector.Inject(openFileDialog.FileName);
          MainWindow.IsMinecraftRunning = true;
          MainWindow.Minecraft.EnableRaisingEvents = true;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          MainWindow.Minecraft.Exited += MainWindow.\u003C\u003EO.\u003C3\u003E__IfMinecraftExited ?? (MainWindow.\u003C\u003EO.\u003C3\u003E__IfMinecraftExited = new EventHandler(MainWindow.IfMinecraftExited));
          openFileDialog = (Microsoft.Win32.OpenFileDialog) null;
        }
      }
    }

    private static void IfMinecraftExited(object sender, EventArgs e)
    {
      if (MainWindow.IsDiscordPresenceEnabled)
        DiscordPresence.IdlePresence();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      System.Windows.Application.Current.Dispatcher.Invoke(MainWindow.\u003C\u003EO.\u003C4\u003E__Default ?? (MainWindow.\u003C\u003EO.\u003C4\u003E__Default = new Action(SetStatusLabel.Default)));
      MainWindow.IsMinecraftRunning = false;
      if (!MainWindow.IsCustomDll)
        return;
      MainWindow.IsCustomDll = false;
    }

    private void ChangelogButton_OnClick(object sender, RoutedEventArgs e)
    {
      MainWindow.ChangelogWindow.Show();
      if (!MainWindow.IsDiscordPresenceEnabled)
        return;
      DiscordPresence.ChangelogPresence();
    }

    private void CreditButton_OnClick(object sender, RoutedEventArgs e)
    {
      MainWindow.CreditWindow.Show();
      if (!MainWindow.IsDiscordPresenceEnabled)
        return;
      DiscordPresence.CreditsPresence();
    }

    private void SettingsButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      MainWindow.SettingsWindow.Show();
      if (!MainWindow.IsDiscordPresenceEnabled)
        return;
      DiscordPresence.SettingsPresence();
    }

    private void DiscordIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      if (Process.GetProcessesByName("Discord").Length != 0)
        Process.Start(new ProcessStartInfo()
        {
          FileName = "discord://-/invite/zcJfXxKTA4",
          UseShellExecute = true
        });
      else
        Process.Start(new ProcessStartInfo()
        {
          FileName = "https://discord.gg/zcJfXxKTA4",
          UseShellExecute = true
        });
    }

    private static void OnClosing(object sender, CancelEventArgs e) => e.Cancel = true;

    private static void MenuExitItem_Click(object sender, EventArgs e)
    {
      System.Windows.Application.Current.Shutdown();
    }

    private void Window_Closing(object sender, CancelEventArgs e)
    {
      DiscordPresence.ShutdownPresence();
      this._notifyIcon?.Dispose();
      this._notifyIcon = (NotifyIcon) null;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "8.0.2.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      System.Windows.Application.LoadComponent((object) this, new Uri("/Latite Injector;component/mainwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "8.0.2.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, 
    #nullable disable
    object target)
    {
      switch (connectionId)
      {
        case 1:
          ((Window) target).Closing += new CancelEventHandler(this.Window_Closing);
          ((UIElement) target).IsVisibleChanged += new DependencyPropertyChangedEventHandler(this.OnIsVisibleChanged);
          ((Window) target).StateChanged += new EventHandler(this.OnStateChanged);
          break;
        case 2:
          ((UIElement) target).MouseLeftButtonDown += new MouseButtonEventHandler(this.DiscordIcon_MouseLeftButtonDown);
          break;
        case 3:
          ((UIElement) target).MouseLeftButtonDown += new MouseButtonEventHandler(this.SettingsButton_MouseLeftButtonDown);
          break;
        case 4:
          this.ChangelogLabel = (System.Windows.Controls.Label) target;
          this.ChangelogLabel.MouseLeftButtonUp += new MouseButtonEventHandler(this.ChangelogButton_OnClick);
          break;
        case 5:
          this.CreditLabel = (System.Windows.Controls.Label) target;
          this.CreditLabel.MouseLeftButtonUp += new MouseButtonEventHandler(this.CreditButton_OnClick);
          break;
        case 6:
          this.LaunchButton = (System.Windows.Controls.Button) target;
          this.LaunchButton.Click += new RoutedEventHandler(this.LaunchButton_OnLeftClick);
          this.LaunchButton.MouseRightButtonUp += new MouseButtonEventHandler(this.LaunchButton_OnRightClick);
          break;
        case 7:
          ((UIElement) target).MouseLeftButtonUp += new MouseButtonEventHandler(this.CloseButton_Click);
          break;
        case 8:
          this.StatusLabel = (System.Windows.Controls.Label) target;
          break;
        case 9:
          ((UIElement) target).MouseLeftButtonDown += new MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
