//bus.exe
//reversed by citraX
//youtube.com/watch?v=ftvo5IMdecU
//WARNING! THIS IS NOT FULL REVERSE CODE. MAYBE IT DOESNT WORKING. NOTE THAT.

using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace GDIConsoleApp
{
  internal class Program
  {
    private static Random random = new Random();

    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int X, int Y);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr LoadCursorFromFile(string lpFileName);

    [DllImport("user32.dll")]
    private static extern IntPtr SetCursor(IntPtr hCursor);

    private static void Main(string[] args)
    {
      if (MessageBox.Show("This is a warning. Are you sure you want to do this? bus.exe is a type of Trojan horse that can destroy your computer, remove your operating system, and extract personal information. Do you really want to do it?", "bus.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
      {
        if (MessageBox.Show("Are you sure you want to do it? If you want to run it, we recommend running it in a virtual environment. It is not recommended to run it on a real device. Run this exe file inside the folder. GDI and the destruction function may not start. The author is not responsible for any damage(No MBR) to your computer.", "bus.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
          Program.StartEffects();
        else
          Environment.Exit(0);
      }
      else
        Environment.Exit(0);
    }

    private static void StartEffects()
    {
      new SoundPlayer("sound.wav").PlayLooping();
      IntPtr hCursor = Program.LoadCursorFromFile("C:\\Windows\\Cursors\\aero_unavail.cur");
      if (hCursor != IntPtr.Zero)
        Program.SetCursor(hCursor);
      Program.ShowIcon(SystemIcons.Warning);
      Thread.Sleep(3000);
      Program.ShowIcon(SystemIcons.Question);
      Thread.Sleep(2000);
      Program.ShowIcon(SystemIcons.Information);
      Thread.Sleep(3000);
      Program.ShakeCursor();
      Thread.Sleep(3000);
      Program.ShowBusExeOneByOne();
      Thread.Sleep(3000);
      Program.ComplicateScreen();
      Thread.Sleep(3000);
      new SoundPlayer("sound.wav").Stop();
      if (MessageBox.Show("caveat. Now we will run the destruction program. Do you allow it? If you allow it, your computer will be destroyed. :)\r\n", "bus.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
        Process.Start("bus2.exe");
      Environment.Exit(0);
    }

    private static void ShowIcon(Icon icon)
    {
      IntPtr dc = Program.GetDC(IntPtr.Zero);
      Graphics graphics = Graphics.FromHdc(dc);
      int x = Program.random.Next(Screen.PrimaryScreen.Bounds.Width);
      int y = Program.random.Next(Screen.PrimaryScreen.Bounds.Height);
      graphics.DrawIcon(icon, x, y);
      graphics.Dispose();
      Program.ReleaseDC(IntPtr.Zero, dc);
    }

    private static void ShakeCursor()
    {
      Point position = Cursor.Position;
      for (int index = 0; index < 50; ++index)
      {
        Program.SetCursorPos(position.X + Program.random.Next(-10, 10), position.Y + Program.random.Next(-10, 10));
        Thread.Sleep(20);
      }
      Program.SetCursorPos(position.X, position.Y);
    }

    private static void ShowBusExeOneByOne()
    {
      IntPtr dc = Program.GetDC(IntPtr.Zero);
      Graphics graphics = Graphics.FromHdc(dc);
      Font font = new Font("Arial", 24f, FontStyle.Bold);
      for (int index = 0; index < 10; ++index)
      {
        Brush brush = (Brush) new SolidBrush(Color.FromArgb(Program.random.Next(256), Program.random.Next(256), Program.random.Next(256)));
        Random random1 = Program.random;
        Rectangle bounds = Screen.PrimaryScreen.Bounds;
        int maxValue1 = bounds.Width - 100;
        int x = random1.Next(maxValue1);
        Random random2 = Program.random;
        bounds = Screen.PrimaryScreen.Bounds;
        int maxValue2 = bounds.Height - 30;
        int y = random2.Next(maxValue2);
        graphics.DrawString("bus.exe", font, brush, new PointF((float) x, (float) y));
        brush.Dispose();
        Thread.Sleep(1000);
      }
      graphics.Dispose();
      Program.ReleaseDC(IntPtr.Zero, dc);
    }

    private static void ComplicateScreen()
    {
      IntPtr dc = Program.GetDC(IntPtr.Zero);
      Graphics graphics = Graphics.FromHdc(dc);
      Pen pen = new Pen(Color.FromArgb(Program.random.Next(256), Program.random.Next(256), Program.random.Next(256)), 2f);
      for (int index = 0; index < 100; ++index)
      {
        Random random1 = Program.random;
        Rectangle bounds = Screen.PrimaryScreen.Bounds;
        int width1 = bounds.Width;
        int x1 = random1.Next(width1);
        Random random2 = Program.random;
        bounds = Screen.PrimaryScreen.Bounds;
        int height1 = bounds.Height;
        int y1 = random2.Next(height1);
        Random random3 = Program.random;
        bounds = Screen.PrimaryScreen.Bounds;
        int width2 = bounds.Width;
        int x2 = random3.Next(width2);
        Random random4 = Program.random;
        bounds = Screen.PrimaryScreen.Bounds;
        int height2 = bounds.Height;
        int y2 = random4.Next(height2);
        graphics.DrawLine(pen, x1, y1, x2, y2);
        Thread.Sleep(50);
      }
      pen.Dispose();
      graphics.Dispose();
      Program.ReleaseDC(IntPtr.Zero, dc);
    }
  }
}
