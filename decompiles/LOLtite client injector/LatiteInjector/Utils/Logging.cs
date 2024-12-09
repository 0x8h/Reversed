// Decompiled with JetBrains decompiler
// Type: LatiteInjector.Utils.Logging
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

#nullable enable
namespace LatiteInjector.Utils
{
  public static class Logging
  {
    public static readonly string RoamingStateDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Packages\\Microsoft.MinecraftUWP_8wekyb3d8bbwe\\RoamingState";

    public static void ErrorLogging(Exception? error)
    {
      string path1 = Logging.RoamingStateDirectory + "\\Latite\\Logs";
      Directory.CreateDirectory(path1);
      string path2 = string.Format("{0}\\Latite_Injector_Error_{1:yyyy_MM_dd_HH_mm_ss}.txt", (object) path1, (object) DateTime.Now);
      if (File.Exists(path2))
        File.Create(path2).Close();
      File.WriteAllText(path2, error?.ToString());
      if (MessageBox.Show("An error has occurred! Please report this error to the developers!\nClick Yes to go to the Latite Discord.\n\n" + error?.ToString().Substring(0, 500) + "...", "An unhandled error has occurred!", MessageBoxButton.YesNo, MessageBoxImage.Hand) != MessageBoxResult.Yes)
        return;
      if (Process.GetProcessesByName("Discord").Length != 0)
        Process.Start(new ProcessStartInfo()
        {
          FileName = "discord://-/invite/2ZFsuTsfeX",
          UseShellExecute = true
        });
      else
        Process.Start(new ProcessStartInfo()
        {
          FileName = "https://discord.gg/2ZFsuTsfeX",
          UseShellExecute = true
        });
    }
  }
}
