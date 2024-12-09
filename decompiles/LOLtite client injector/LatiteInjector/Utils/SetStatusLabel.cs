// Decompiled with JetBrains decompiler
// Type: LatiteInjector.Utils.SetStatusLabel
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#nullable enable
namespace LatiteInjector.Utils
{
  public static class SetStatusLabel
  {
    private static readonly MainWindow? Form = Application.Current.Windows[3] as MainWindow;
    private static readonly Label? StatusLabel = SetStatusLabel.Form?.StatusLabel;

    public static void Default()
    {
      if (SetStatusLabel.StatusLabel == null)
        return;
      SetStatusLabel.StatusLabel.Foreground = (Brush) Brushes.White;
      SetStatusLabel.StatusLabel.Content = (object) "Status: Idle";
    }

    public static void Pending(string statusText)
    {
      if (SetStatusLabel.StatusLabel == null)
        return;
      SetStatusLabel.StatusLabel.Foreground = (Brush) Brushes.Khaki;
      SetStatusLabel.StatusLabel.Content = (object) ("Status: " + statusText);
    }

    public static void Completed(string statusText)
    {
      if (SetStatusLabel.StatusLabel == null)
        return;
      SetStatusLabel.StatusLabel.Foreground = (Brush) Brushes.LightGreen;
      SetStatusLabel.StatusLabel.Content = (object) ("Status: " + statusText);
    }

    public static void Error(string statusText)
    {
      if (SetStatusLabel.StatusLabel == null)
        return;
      SetStatusLabel.StatusLabel.Foreground = (Brush) Brushes.Crimson;
      SetStatusLabel.StatusLabel.Content = (object) ("Status: " + statusText);
    }
  }
}
