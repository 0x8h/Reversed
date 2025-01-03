// Decompiled with JetBrains decompiler
// Type: ERROR_408.My.MyApplication
// Assembly: ERROR 408, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3A16A069-E54E-486F-B90E-25ABCEBFADB0
// Assembly location: C:\Users\user\Downloads\huherror(Fixed)\huherror\huherror.exe
// XML documentation location: C:\Users\user\Downloads\huherror(Fixed)\huherror\huherror.xml

using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace ERROR_408.My
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
      Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
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
  }
}
