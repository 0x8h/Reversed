// Decompiled with JetBrains decompiler
// Type: LatiteInjector.Utils.Api
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable enable
namespace LatiteInjector.Utils
{
  public static class Api
  {
    public const int WM_NCLBUTTONDOWN = 161;
    public const int HT_CAPTION = 2;
    public const int PROCESS_CREATE_THREAD = 2;
    public const int PROCESS_QUERY_INFORMATION = 1024;
    public const int PROCESS_VM_OPERATION = 8;
    public const int PROCESS_VM_WRITE = 32;
    public const int PROCESS_VM_READ = 16;
    public const uint MEM_COMMIT = 4096;
    public const uint MEM_RESERVE = 8192;
    public const uint PAGE_READWRITE = 4;

    [DllImport("user32.dll")]
    public static extern int SendMessage([NativeInteger] IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    [DllImport("kernel32.dll")]
    [return: NativeInteger]
    public static extern IntPtr OpenProcess(
      int dwDesiredAccess,
      bool bInheritHandle,
      int dwProcessId);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    [return: NativeInteger]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
    [return: NativeInteger]
    public static extern IntPtr GetProcAddress([NativeInteger] IntPtr hModule, string procName);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: NativeInteger]
    public static extern IntPtr VirtualAllocEx(
      [NativeInteger] IntPtr hProcess,
      [NativeInteger] IntPtr lpAddress,
      uint dwSize,
      uint flAllocationType,
      uint flProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool WriteProcessMemory(
      [NativeInteger] IntPtr hProcess,
      [NativeInteger] IntPtr lpBaseAddress,
      byte[] lpBuffer,
      uint nSize,
      [NativeInteger] out UIntPtr lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    [return: NativeInteger]
    public static extern IntPtr CreateRemoteThread(
      [NativeInteger] IntPtr hProcess,
      [NativeInteger] IntPtr lpThreadAttributes,
      uint dwStackSize,
      [NativeInteger] IntPtr lpStartAddress,
      [NativeInteger] IntPtr lpParameter,
      uint dwCreationFlags,
      [NativeInteger] IntPtr lpThreadId);

    [DllImport("user32.dll")]
    public static extern int SetForegroundWindow(IntPtr hWnd);
  }
}
