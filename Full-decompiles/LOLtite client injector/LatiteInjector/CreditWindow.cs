// Decompiled with JetBrains decompiler
// Type: LatiteInjector.CreditWindow
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using LatiteInjector.Utils;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

#nullable enable
namespace LatiteInjector
{
  public class CreditWindow : Window, IComponentConnector
  {
    private bool _contentLoaded;

    public CreditWindow() => this.InitializeComponent();

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

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "8.0.2.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Latite Injector;component/creditwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "8.0.2.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, 
    #nullable disable
    object target)
    {
      if (connectionId != 1)
      {
        if (connectionId == 2)
          ((UIElement) target).MouseLeftButtonDown += new MouseButtonEventHandler(this.Window_OnMouseLeftButtonDown);
        else
          this._contentLoaded = true;
      }
      else
        ((UIElement) target).MouseLeftButtonDown += new MouseButtonEventHandler(this.CloseButton_Click);
    }
  }
}
