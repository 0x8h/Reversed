// Decompiled with JetBrains decompiler
// Type: ERROR_408.Form2
// Assembly: ERROR 408, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3A16A069-E54E-486F-B90E-25ABCEBFADB0
// Assembly location: C:\Users\user\Downloads\huherror(Fixed)\huherror\huherror.exe
// XML documentation location: C:\Users\user\Downloads\huherror(Fixed)\huherror\huherror.xml

using Microsoft.VisualBasic.CompilerServices;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace ERROR_408
{
  [DesignerGenerated]
  public class Form2 : Form
  {
    private IContainer components;

    public Form2() => this.InitializeComponent();

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(800, 450);
      this.Text = nameof (Form2);
    }
  }
}
