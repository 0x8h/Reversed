//chilledwindows.exe
//decompile by qsqwqs
//WARNING! THIS IS NOT FULL REVERSE CODE. MAYBE IT DOESNT WORKING. NOTE THAT.

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;

#nullable disable
namespace ChilledWindows
{
  public class App : Application
  {
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      this.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
    }

    [STAThread]
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public static void Main()
    {
      App app = new App();
      app.InitializeComponent();
      app.Run();
    }
  }
}
