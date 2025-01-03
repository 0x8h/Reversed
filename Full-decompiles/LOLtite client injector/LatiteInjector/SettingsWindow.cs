// Decompiled with JetBrains decompiler
// Type: LatiteInjector.SettingsWindow
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using LatiteInjector.Utils;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable enable
namespace LatiteInjector
{
  public class SettingsWindow : Window, IComponentConnector
  {
    public static string ConfigFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\LatiteInjector\\config.txt";
    private static readonly string LatiteInjectorFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\LatiteInjector";
    public 
    #nullable disable
    CheckBox DiscordPresenceCheckBox;
    public CheckBox HideToTrayCheckBox;
    public CheckBox CloseAfterInjectedCheckBox;
    private bool _contentLoaded;

    public SettingsWindow()
    {
      this.InitializeComponent();
      this.ConfigSetup();
    }

    private void ConfigSetup()
    {
      if (!File.Exists(SettingsWindow.ConfigFilePath))
      {
        Directory.CreateDirectory(SettingsWindow.LatiteInjectorFolder);
        File.Create(SettingsWindow.ConfigFilePath).Close();
        string contents = "discordstatus:true\nhidetotray:false\ncloseafterinjected:false\nfirstrun:true\n";
        File.WriteAllText(SettingsWindow.ConfigFilePath, contents);
        MainWindow.IsDiscordPresenceEnabled = true;
        MainWindow.IsHideToTrayEnabled = false;
        MainWindow.IsCloseAfterInjectedEnabled = false;
      }
      else
        this.LoadConfig();
    }

    private void LoadConfig()
    {
      string text = File.ReadAllText(SettingsWindow.ConfigFilePath);
      MainWindow.IsDiscordPresenceEnabled = MainWindow.GetLine(text, 1) == "discordstatus:true";
      MainWindow.IsHideToTrayEnabled = MainWindow.GetLine(text, 2) == "hidetotray:true";
      MainWindow.IsCloseAfterInjectedEnabled = MainWindow.GetLine(text, 3) == "closeafterinjected:true";
      this.DiscordPresenceCheckBox.IsChecked = new bool?(MainWindow.IsDiscordPresenceEnabled);
      this.HideToTrayCheckBox.IsChecked = new bool?(MainWindow.IsHideToTrayEnabled);
      this.CloseAfterInjectedCheckBox.IsChecked = new bool?(MainWindow.IsCloseAfterInjectedEnabled);
    }

    public void ModifyConfig(
    #nullable enable
    string newText, int lineToEdit)
    {
      string[] contents = File.ReadAllLines(SettingsWindow.ConfigFilePath);
      contents[lineToEdit - 1] = newText;
      File.WriteAllLines(SettingsWindow.ConfigFilePath, contents);
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
      this.Hide();
      if (!MainWindow.IsDiscordPresenceEnabled)
        return;
      if (!MainWindow.IsMinecraftRunning)
        DiscordPresence.IdlePresence();
      else
        DiscordPresence.PlayingPresence();
    }

    private void Window_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      this.DragMove();
    }

    private void DiscordPresenceCheckBox_OnClick(object sender, RoutedEventArgs e)
    {
      MainWindow.IsDiscordPresenceEnabled = this.DiscordPresenceCheckBox.IsChecked.Value;
      if (MainWindow.IsDiscordPresenceEnabled)
      {
        DiscordPresence.DefaultPresence();
        this.ModifyConfig("discordstatus:true", 1);
      }
      else
      {
        if (MainWindow.IsDiscordPresenceEnabled)
          return;
        DiscordPresence.StopPresence();
        this.ModifyConfig("discordstatus:false", 1);
      }
    }

    private void HideToTrayCheckBox_OnClick(object sender, RoutedEventArgs e)
    {
      MainWindow.IsHideToTrayEnabled = this.HideToTrayCheckBox.IsChecked.Value;
      if (MainWindow.IsHideToTrayEnabled)
      {
        this.ModifyConfig("hidetotray:true", 2);
      }
      else
      {
        if (MainWindow.IsHideToTrayEnabled)
          return;
        this.ModifyConfig("hidetotray:false", 2);
      }
    }

    private void CloseAfterInjectedCheckBox_OnClick(object sender, RoutedEventArgs e)
    {
      MainWindow.IsCloseAfterInjectedEnabled = this.CloseAfterInjectedCheckBox.IsChecked.Value;
      if (MainWindow.IsCloseAfterInjectedEnabled)
      {
        this.ModifyConfig("closeafterinjected:true", 3);
      }
      else
      {
        if (MainWindow.IsCloseAfterInjectedEnabled)
          return;
        this.ModifyConfig("closeafterinjected:false", 3);
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "8.0.2.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Latite Injector;component/settingswindow.xaml", UriKind.Relative));
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
          this.DiscordPresenceCheckBox = (CheckBox) target;
          this.DiscordPresenceCheckBox.Click += new RoutedEventHandler(this.DiscordPresenceCheckBox_OnClick);
          break;
        case 2:
          this.HideToTrayCheckBox = (CheckBox) target;
          this.HideToTrayCheckBox.Click += new RoutedEventHandler(this.HideToTrayCheckBox_OnClick);
          break;
        case 3:
          ((UIElement) target).MouseLeftButtonDown += new MouseButtonEventHandler(this.CloseButton_Click);
          break;
        case 4:
          ((UIElement) target).MouseLeftButtonDown += new MouseButtonEventHandler(this.Window_OnMouseLeftButtonDown);
          break;
        case 5:
          this.CloseAfterInjectedCheckBox = (CheckBox) target;
          this.CloseAfterInjectedCheckBox.Click += new RoutedEventHandler(this.CloseAfterInjectedCheckBox_OnClick);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
