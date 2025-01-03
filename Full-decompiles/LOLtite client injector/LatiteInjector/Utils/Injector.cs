// Decompiled with JetBrains decompiler
// Type: LatiteInjector.Utils.Injector
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

#nullable enable
namespace LatiteInjector.Utils
{
  public static class Injector
  {
    public static void Inject(string path)
    {
      SetStatusLabel.Pending("Injecting " + path + " into Minecraft!");
      try
      {
        ApplyAppPackages(path);
        IntPtr hProcess = Api.OpenProcess(1082, false, Process.GetProcessesByName("Minecraft.Windows")[0].Id);
        IntPtr procAddress = Api.GetProcAddress(Api.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
        IntPtr num = Api.VirtualAllocEx(hProcess, IntPtr.Zero, (uint) ((path.Length + 1) * Marshal.SizeOf(typeof (char))), 12288U, 4U);
        Api.WriteProcessMemory(hProcess, num, Encoding.Default.GetBytes(path), (uint) ((path.Length + 1) * Marshal.SizeOf(typeof (char))), out UIntPtr _);
        Api.CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAddress, num, 0U, IntPtr.Zero);
        SetStatusLabel.Completed("Injected Latite Client into Minecraft successfully!");
        if (MainWindow.IsDiscordPresenceEnabled)
          DiscordPresence.PlayingPresence();
        if (!MainWindow.IsCloseAfterInjectedEnabled)
          return;
        if (MainWindow.IsHideToTrayEnabled)
          Application.Current.Windows[3].WindowState = WindowState.Minimized;
        else
          Application.Current.Shutdown();
      }
      catch (Exception ex)
      {
        SetStatusLabel.Error("Ran into an error while injecting!");
        Logging.ErrorLogging(ex);
      }

      static void ApplyAppPackages(string path)
      {
        FileInfo fileInfo = new FileInfo(path);
        FileSecurity accessControl = fileInfo.GetAccessControl();
        accessControl.AddAccessRule(new FileSystemAccessRule((IdentityReference) new SecurityIdentifier("S-1-15-2-1"), FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
        fileInfo.SetAccessControl(accessControl);
      }
    }

    public static async Task WaitForModules()
    {
      await Task.Run((Action) (() =>
      {
        Application.Current.Dispatcher.Invoke((Action) (() => SetStatusLabel.Pending("Waiting for Minecraft to finish loading...")));
        while (true)
        {
          MainWindow.Minecraft?.Refresh();
          Process minecraft = MainWindow.Minecraft;
          if (minecraft != null)
          {
            ProcessModuleCollection modules = minecraft.Modules;
            if (modules != null && modules.Count > 158)
              break;
          }
          Thread.Sleep(4000);
        }
      }));
      Application.Current.Dispatcher.Invoke((Action) (() => SetStatusLabel.Completed("Minecraft has finished loading!")));
    }
  }
}
