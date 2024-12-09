//しるまを倒すゲーム Ver1.0.0.0
//code by citrax
//www.tiktok.com/@shiruma160150/video/7384012246524906753
//WARNING! THIS IS NOT FULL REVERSE CODE. MAYBE IT DOESNT WORKING. NOTE THAT.

using System;
using System.Windows.Forms;

#nullable disable
namespace ClickBuster_cs
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new F_Menu());
    }
  }
}
