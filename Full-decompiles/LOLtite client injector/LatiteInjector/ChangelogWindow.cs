// Decompiled with JetBrains decompiler
// Type: LatiteInjector.ChangelogWindow
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using LatiteInjector.Utils;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable enable
namespace LatiteInjector
{
  public class ChangelogWindow : Window, IComponentConnector
  {
    public 
    #nullable disable
    Label ClientChangelogLine1;
    public Label ClientChangelogLine2;
    public Label ClientChangelogLine3;
    public Label ClientChangelogLine4;
    public Label InjectorChangelogLine1;
    public Label InjectorChangelogLine2;
    public Label InjectorChangelogLine3;
    public Label InjectorChangelogLine4;
    internal Label InjectorVersionLabel;
    private bool _contentLoaded;

    public ChangelogWindow()
    {
      this.InitializeComponent();
      this.InjectorVersionLabel.Content = (object) "Injector version: 15";
    }

    private void CloseButton_Click(
    #nullable enable
    object sender, RoutedEventArgs e)
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

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "8.0.2.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Latite Injector;component/changelogwindow.xaml", UriKind.Relative));
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
          ((UIElement) target).MouseLeftButtonDown += new MouseButtonEventHandler(this.CloseButton_Click);
          break;
        case 2:
          this.ClientChangelogLine1 = (Label) target;
          break;
        case 3:
          this.ClientChangelogLine2 = (Label) target;
          break;
        case 4:
          this.ClientChangelogLine3 = (Label) target;
          break;
        case 5:
          this.ClientChangelogLine4 = (Label) target;
          break;
        case 6:
          this.InjectorChangelogLine1 = (Label) target;
          break;
        case 7:
          this.InjectorChangelogLine2 = (Label) target;
          break;
        case 8:
          this.InjectorChangelogLine3 = (Label) target;
          break;
        case 9:
          this.InjectorChangelogLine4 = (Label) target;
          break;
        case 10:
          this.InjectorVersionLabel = (Label) target;
          break;
        case 11:
          ((UIElement) target).MouseLeftButtonDown += new MouseButtonEventHandler(this.Window_OnMouseLeftButtonDown);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
