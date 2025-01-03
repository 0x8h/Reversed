// Decompiled with JetBrains decompiler
// Type: ERROR_408.Form1
// Assembly: ERROR 408, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3A16A069-E54E-486F-B90E-25ABCEBFADB0
// Assembly location: C:\Users\user\Downloads\huherror(Fixed)\huherror\huherror.exe
// XML documentation location: C:\Users\user\Downloads\huherror(Fixed)\huherror\huherror.xml

using AxWMPLib;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace ERROR_408
{
  [DesignerGenerated]
  public class Form1 : Form
  {
    private IContainer components;

    public Form1()
    {
      this.Load += new EventHandler(this.Form1_Load);
      this.InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void AxWindowsMediaPlayer1_Enter(object sender, EventArgs e)
    {
    }

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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.AxWindowsMediaPlayer1 = new AxWindowsMediaPlayer();
      this.AxWindowsMediaPlayer1.BeginInit();
      this.SuspendLayout();
      this.AxWindowsMediaPlayer1.Enabled = true;
      this.AxWindowsMediaPlayer1.Location = new Point(0, 1);
      this.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1";
      this.AxWindowsMediaPlayer1.OcxState = (AxHost.State) componentResourceManager.GetObject("AxWindowsMediaPlayer1.OcxState");
      this.AxWindowsMediaPlayer1.Size = new Size(2420, 1092);
      this.AxWindowsMediaPlayer1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(16f, 31f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(2432, 1092);
      this.Controls.Add((Control) this.AxWindowsMediaPlayer1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (Form1);
      this.Text = nameof (Form1);
      this.WindowState = FormWindowState.Maximized;
      this.AxWindowsMediaPlayer1.EndInit();
      this.ResumeLayout(false);
    }

    internal virtual AxWindowsMediaPlayer AxWindowsMediaPlayer1
    {
      get => this._AxWindowsMediaPlayer1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.AxWindowsMediaPlayer1_Enter);
        AxWindowsMediaPlayer windowsMediaPlayer1_1 = this._AxWindowsMediaPlayer1;
        if (windowsMediaPlayer1_1 != null)
          windowsMediaPlayer1_1.Enter -= eventHandler;
        this._AxWindowsMediaPlayer1 = value;
        AxWindowsMediaPlayer windowsMediaPlayer1_2 = this._AxWindowsMediaPlayer1;
        if (windowsMediaPlayer1_2 == null)
          return;
        windowsMediaPlayer1_2.Enter += eventHandler;
      }
    }
  }
}
