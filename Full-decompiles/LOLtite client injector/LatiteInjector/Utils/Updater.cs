// Decompiled with JetBrains decompiler
// Type: LatiteInjector.Utils.Updater
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;

#nullable enable
namespace LatiteInjector.Utils
{
  public static class Updater
  {
    public const string InjectorCurrentVersion = "15";
    private const string INJECTOR_VERSION_URL = "https://raw.githubusercontent.com/Imrglop/Latite-Releases/main/launcher_version";
    private const string DLL_VERSION_URL = "https://raw.githubusercontent.com/Imrglop/Latite-Releases/main/latest_version.txt";
    private const string INJECTOR_EXECUTABLE_URL = "https://github.com/Imrglop/Latite-Releases/raw/main/injector/Injector.exe";
    private const string INJECTOR_CHANGELOG_URL = "https://raw.githubusercontent.com/Imrglop/Latite-Releases/main/injector_changelog";
    private const string CLIENT_CHANGELOG_URL = "https://raw.githubusercontent.com/Imrglop/Latite-Releases/main/client_changelog";
    private static string? _selectedVersion;
    private static readonly WebClient? Client = new WebClient();
    private static readonly MainWindow? Form = Application.Current.Windows[3] as MainWindow;
    private static readonly ChangelogWindow? ChangelogForm = Application.Current.Windows[1] as ChangelogWindow;

    private static string? GetLatestInjectorVersion()
    {
      try
      {
        return Updater.Client?.DownloadString("https://raw.githubusercontent.com/Imrglop/Latite-Releases/main/launcher_version")?.Replace("\n", "");
      }
      catch
      {
        SetStatusLabel.Error("Failed to check latest version of injector. Are you connected to the internet?");
        throw new Exception("Cannot get latest injector version!");
      }
    }

    private static string? GetLatestDllVersion()
    {
      try
      {
        return Updater.Client?.DownloadString("https://raw.githubusercontent.com/Imrglop/Latite-Releases/main/latest_version.txt")?.Replace("\n", "");
      }
      catch
      {
        SetStatusLabel.Error("Failed to check latest version of dll. Are you connected to the internet?");
        throw new Exception("Cannot get latest DLL!");
      }
    }

    public static bool IsVersionSimilar(string version1, string version2)
    {
      string[] strArray1 = version1.Split('.');
      string[] strArray2 = version2.Split('.');
      return strArray1.Length == strArray2.Length + 1 && strArray1[0] == strArray2[0] && strArray1[1] == strArray1[1] && (int) strArray1[2][0] == (int) strArray2[2][0];
    }

    public static void UpdateInjector()
    {
      string latestInjectorVersion = Updater.GetLatestInjectorVersion();
      try
      {
        if (Convert.ToInt32("15") >= Convert.ToInt32(latestInjectorVersion))
          return;
      }
      catch
      {
        throw new Exception("Failed to convert injector current version or latest injector version");
      }
      if (MessageBox.Show("The injector is outdated! Do you want to download the newest version?", "Injector outdated!", MessageBoxButton.YesNo, MessageBoxImage.Hand) != MessageBoxResult.Yes)
        return;
      string fileName = "Injector_" + latestInjectorVersion + ".exe";
      string str = "./" + fileName;
      if (System.IO.File.Exists(str))
        System.IO.File.Delete(str);
      Updater.Client?.DownloadFile("https://github.com/Imrglop/Latite-Releases/raw/main/injector/Injector.exe", str);
      Process.Start(fileName);
      Application.Current.Shutdown();
    }

    private static string? GetChangelogLine(string? changelog, int line, string changelogNum)
    {
      if (changelog == null || !MainWindow.GetLine(changelog, line).StartsWith(changelogNum + " "))
        return "Couldn't get changelog line";
      return MainWindow.GetLine(changelog, line)?.Replace(changelogNum + " ", "");
    }

    private static string? GetClientChangelogLine(string? changelog, int line, string changelogNum)
    {
      if (changelog == null || !MainWindow.GetLine(changelog, line).StartsWith(changelogNum + " "))
        return "";
      return MainWindow.GetLine(changelog, line)?.Replace(changelogNum + " ", "");
    }

    public static void GetInjectorChangelog()
    {
      string changelog = (string) null;
      try
      {
        changelog = Updater.Client?.DownloadString("https://raw.githubusercontent.com/Imrglop/Latite-Releases/main/injector_changelog");
      }
      catch
      {
        SetStatusLabel.Error("Failed to obtain injector changelog. Are you connected to the internet?");
      }
      if (changelog == "\n")
      {
        SetStatusLabel.Error("Failed to obtain client changelog. Please report error to devs");
        throw new Exception("The injector changelog on Latite-Releases is (probably) empty");
      }
      if (Updater.ChangelogForm == null)
        return;
      Updater.ChangelogForm.InjectorChangelogLine1.Content = (object) Updater.GetChangelogLine(changelog, 1, "1.");
      Updater.ChangelogForm.InjectorChangelogLine2.Content = (object) Updater.GetChangelogLine(changelog, 2, "2.");
      Updater.ChangelogForm.InjectorChangelogLine3.Content = (object) Updater.GetChangelogLine(changelog, 3, "3.");
      Updater.ChangelogForm.InjectorChangelogLine4.Content = (object) Updater.GetChangelogLine(changelog, 4, "4.");
    }

    public static void GetClientChangelog()
    {
      string changelog = (string) null;
      try
      {
        changelog = Updater.Client?.DownloadString("https://raw.githubusercontent.com/Imrglop/Latite-Releases/main/client_changelog");
      }
      catch
      {
        SetStatusLabel.Error("Failed to obtain client changelog. Are you connected to the internet?");
      }
      if (changelog == "\n")
      {
        SetStatusLabel.Error("Failed to obtain client changelog. Please report error to devs");
        throw new Exception("The client changelog on Latite-Releases is (probably) empty");
      }
      if (Updater.ChangelogForm == null)
        return;
      Updater.ChangelogForm.ClientChangelogLine1.Content = (object) Updater.GetClientChangelogLine(changelog, 1, "1.");
      Updater.ChangelogForm.ClientChangelogLine2.Content = (object) Updater.GetClientChangelogLine(changelog, 2, "2.");
      Updater.ChangelogForm.ClientChangelogLine3.Content = (object) Updater.GetClientChangelogLine(changelog, 3, "3.");
      Updater.ChangelogForm.ClientChangelogLine4.Content = (object) Updater.GetClientChangelogLine(changelog, 4, "4.");
    }

    public static string DownloadDll()
    {
      string latestDllVersion = Updater.GetLatestDllVersion();
      string str = Path.GetTempPath() + "Latite_" + latestDllVersion + ".dll";
      if (System.IO.File.Exists(str))
        return str;
      SetStatusLabel.Pending("Downloading Latite DLL");
      Updater.Client?.DownloadFile("https://github.com/Imrglop/Latite-Releases/releases/download/" + latestDllVersion + "/Latite.dll", str);
      return str;
    }
  }
}
