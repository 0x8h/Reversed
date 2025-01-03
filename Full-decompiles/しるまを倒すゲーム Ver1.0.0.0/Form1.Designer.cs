// Decompiled with JetBrains decompiler
// Type: ClickBuster_cs.F_Menu
// Assembly: しるまを倒すゲーム Ver1.0.0.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C501FEF3-38DF-4162-9359-444F9E941403
// Assembly location: C:\Users\user\Downloads\Game to defeat shiruma\Game to defeat shiruma\しるまを倒すゲーム Ver1.0.0.0.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace ClickBuster_cs
{
  public class F_Menu : Form
  {
    private IContainer components = (IContainer) null;
    private Button B_Syokyu;
    private Button B_Chukyu;
    private Button B_Jyokyu;
    private Button B_Close;

    public F_Menu() => this.InitializeComponent();

    private void B_Syokyu_Click(object sender, EventArgs e)
    {
      F_Main fMain1 = new F_Main();
      fMain1.Height = 400;
      fMain1.Width = 400;
      fMain1.EnmTim = 1000;
      fMain1.Enms = 20;
      fMain1.GmTim = 10000;
      F_Main fMain2 = fMain1;
      fMain2.FrmIni();
      fMain2.Show((IWin32Window) this);
      this.Hide();
    }

    private void B_Chukyu_Click(object sender, EventArgs e)
    {
      F_Main fMain1 = new F_Main();
      fMain1.Height = 500;
      fMain1.Width = 700;
      fMain1.EnmTim = 800;
      fMain1.Enms = 30;
      fMain1.GmTim = 15000;
      F_Main fMain2 = fMain1;
      fMain2.FrmIni();
      fMain2.Show((IWin32Window) this);
      this.Hide();
    }

    private void B_Jyokyu_Click(object sender, EventArgs e)
    {
      F_Main fMain1 = new F_Main();
      fMain1.Height = 600;
      fMain1.Width = 800;
      fMain1.EnmTim = 300;
      fMain1.Enms = 40;
      fMain1.GmTim = 20000;
      F_Main fMain2 = fMain1;
      fMain2.FrmIni();
      fMain2.Show((IWin32Window) this);
      this.Hide();
    }

    private void B_Close_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (F_Menu));
      this.B_Syokyu = new Button();
      this.B_Chukyu = new Button();
      this.B_Jyokyu = new Button();
      this.B_Close = new Button();
      this.SuspendLayout();
      this.B_Syokyu.Location = new Point(12, 12);
      this.B_Syokyu.Name = "B_Syokyu";
      this.B_Syokyu.Size = new Size(260, 74);
      this.B_Syokyu.TabIndex = 0;
      this.B_Syokyu.Text = "初級";
      this.B_Syokyu.UseVisualStyleBackColor = true;
      this.B_Syokyu.Click += new EventHandler(this.B_Syokyu_Click);
      this.B_Chukyu.Location = new Point(12, 92);
      this.B_Chukyu.Name = "B_Chukyu";
      this.B_Chukyu.Size = new Size(260, 74);
      this.B_Chukyu.TabIndex = 1;
      this.B_Chukyu.Text = "中級";
      this.B_Chukyu.UseVisualStyleBackColor = true;
      this.B_Chukyu.Click += new EventHandler(this.B_Chukyu_Click);
      this.B_Jyokyu.Location = new Point(12, 172);
      this.B_Jyokyu.Name = "B_Jyokyu";
      this.B_Jyokyu.Size = new Size(260, 74);
      this.B_Jyokyu.TabIndex = 2;
      this.B_Jyokyu.Text = "上級";
      this.B_Jyokyu.UseVisualStyleBackColor = true;
      this.B_Jyokyu.Click += new EventHandler(this.B_Jyokyu_Click);
      this.B_Close.Location = new Point(12, 275);
      this.B_Close.Name = "B_Close";
      this.B_Close.Size = new Size(260, 74);
      this.B_Close.TabIndex = 3;
      this.B_Close.Text = "終了";
      this.B_Close.UseVisualStyleBackColor = true;
      this.B_Close.Click += new EventHandler(this.B_Close_Click);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(284, 361);
      this.Controls.Add((Control) this.B_Close);
      this.Controls.Add((Control) this.B_Jyokyu);
      this.Controls.Add((Control) this.B_Chukyu);
      this.Controls.Add((Control) this.B_Syokyu);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(2, 2, 2, 2);
      this.MaximizeBox = false;
      this.Name = nameof (F_Menu);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "しるまを倒すゲーム Ver1.0.0.0 (メニュー画面)";
      this.ResumeLayout(false);
    }
  }
}
