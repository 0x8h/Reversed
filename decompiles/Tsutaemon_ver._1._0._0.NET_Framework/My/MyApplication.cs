// Decompiled with JetBrains decompiler
// Type: Tsutaemon_ver._1._0._0.NET_Framework.My.MyApplication
// Assembly: Tsutaemon_ver._1._0._0.NET_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C66F1F10-4B55-49DA-BE62-9742375F83F4
// Assembly location: C:\Users\user\Downloads\Tsutaemon_ver._1._0._0.NET_Framework\Tsutaemon_ver._1._0._0.NET_Framework.exe
// XML documentation location: C:\Users\user\Downloads\Tsutaemon_ver._1._0._0.NET_Framework\Tsutaemon_ver._1._0._0.NET_Framework.xml

using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace Tsutaemon_ver._1._0._0.NET_Framework.My
{
  [GeneratedCode("MyTemplate", "11.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  internal class MyApplication : WindowsFormsApplicationBase
  {
    [STAThread]
    [DebuggerHidden]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    internal static void Main(string[] Args)
    {
      try
      {
        Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
      }
      finally
      {
      }
      MyProject.Application.Run(Args);
    }

    [DebuggerStepThrough]
    public MyApplication()
      : base(AuthenticationMode.Windows)
    {
      this.IsSingleInstance = false;
      this.EnableVisualStyles = true;
      this.SaveMySettingsOnExit = true;
      this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
    }

    [DebuggerStepThrough]
    protected override void OnCreateMainForm() => this.MainForm = (Form) MyProject.Forms.Form1;

    [DebuggerStepThrough]
    protected override bool OnInitialize(ReadOnlyCollection<string> commandLineArgs)
    {
      this.MinimumSplashScreenDisplayTime = 0;
      return base.OnInitialize(commandLineArgs);
    }
  }
}
