//しるまを倒すゲーム Ver1.0.0.0
//code by citrax
//www.tiktok.com/@shiruma160150/video/7384012246524906753
//WARNING! THIS IS NOT FULL REVERSE CODE. MAYBE IT DOESNT WORKING. NOTE THAT.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace ClickBuster_cs
{
  public class F_Main : Form
  {
    public int Enms;
    public int EnmTim;
    public int GmTim;
    private Random _rnd = new Random();
    private ArrayList _enemies = new ArrayList();
    private IContainer components = (IContainer) null;
    private Button B_Start;
    private Label L_Jikan;
    private Label L_Tokuten;
    private Label L_Sum;
    private ProgressBar PG_Jikan;
    private Panel P_Enemy;
    private Timer T_Enemy;
    private Timer T_Jikan;

    public F_Main() => this.InitializeComponent();

    private void F_Main_FormClosed(object sender, FormClosedEventArgs e) => this.Owner.Show();

    public void FrmIni()
    {
      this.P_Enemy.Height = this.Height - this.P_Enemy.Top - 45;
      this.P_Enemy.Width = this.Width - 40;
      this.L_Sum.Text = "0";
      this.T_Enemy.Interval = this.EnmTim;
      this.PG_Jikan.Maximum = this.GmTim / 1000;
      this.PG_Jikan.Value = this.PG_Jikan.Maximum;
    }

    private void B_Start_Click(object sender, EventArgs e)
    {
      this.B_Start.Enabled = false;
      for (int index = 0; index <= this.Enms - 1; ++index)
      {
        this._enemies.Add((object) new CEnemy((Control) this.P_Enemy, this._rnd));
        ((CEnemy) this._enemies[index]).OnClick += new EventHandler(this.EnmOnClick);
        Application.DoEvents();
      }
      this.T_Enemy.Enabled = true;
      this.T_Jikan.Enabled = true;
    }

    private void T_Enemy_Tick(object sender, EventArgs e)
    {
      for (int index = 0; index <= this._enemies.Count - 1; ++index)
      {
        ((CEnemy) this._enemies[index]).MvEnm();
        Application.DoEvents();
      }
    }

    private void T_Jikan_Tick(object sender, EventArgs e)
    {
      if (this.PG_Jikan.Minimum <= this.PG_Jikan.Value - 1)
      {
        --this.PG_Jikan.Value;
      }
      else
      {
        this.PG_Jikan.Value = this.PG_Jikan.Minimum;
        this.T_Enemy.Enabled = false;
        this.T_Jikan.Enabled = false;
        int num = (int) MessageBox.Show("終了です\nあなたの得点は" + this.L_Sum.Text + "です");
        this.Close();
      }
    }

    private void EnmOnClick(object sender, EventArgs e)
    {
      this.L_Sum.Text = (int.Parse(this.L_Sum.Text) + ((CEnemy) sender).GetTokuten()).ToString();
      ((CEnemy) sender).EnemyDown();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (F_Main));
      this.B_Start = new Button();
      this.L_Jikan = new Label();
      this.L_Tokuten = new Label();
      this.L_Sum = new Label();
      this.PG_Jikan = new ProgressBar();
      this.P_Enemy = new Panel();
      this.T_Enemy = new Timer(this.components);
      this.T_Jikan = new Timer(this.components);
      this.SuspendLayout();
      this.B_Start.Location = new Point(12, 12);
      this.B_Start.Margin = new Padding(2, 2, 2, 2);
      this.B_Start.Name = "B_Start";
      this.B_Start.Size = new Size(80, 49);
      this.B_Start.TabIndex = 0;
      this.B_Start.Text = "スタート";
      this.B_Start.UseVisualStyleBackColor = true;
      this.B_Start.Click += new EventHandler(this.B_Start_Click);
      this.L_Jikan.AutoSize = true;
      this.L_Jikan.Font = new Font("MS UI Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.L_Jikan.Location = new Point(98, 12);
      this.L_Jikan.Name = "L_Jikan";
      this.L_Jikan.Size = new Size(65, 16);
      this.L_Jikan.TabIndex = 1;
      this.L_Jikan.Text = "残り時間";
      this.L_Tokuten.AutoSize = true;
      this.L_Tokuten.Font = new Font("MS UI Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.L_Tokuten.Location = new Point(249, 12);
      this.L_Tokuten.Name = "L_Tokuten";
      this.L_Tokuten.Size = new Size(39, 16);
      this.L_Tokuten.TabIndex = 2;
      this.L_Tokuten.Text = "得点";
      this.L_Sum.Font = new Font("MS UI Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.L_Sum.Location = new Point(249, 45);
      this.L_Sum.Name = "L_Sum";
      this.L_Sum.Size = new Size(123, 16);
      this.L_Sum.TabIndex = 3;
      this.L_Sum.Text = "0";
      this.L_Sum.TextAlign = ContentAlignment.TopRight;
      this.PG_Jikan.Location = new Point(101, 35);
      this.PG_Jikan.Maximum = 10;
      this.PG_Jikan.Name = "PG_Jikan";
      this.PG_Jikan.Size = new Size(142, 26);
      this.PG_Jikan.TabIndex = 4;
      this.PG_Jikan.Value = 10;
      this.P_Enemy.BackColor = Color.White;
      this.P_Enemy.BorderStyle = BorderStyle.Fixed3D;
      this.P_Enemy.Location = new Point(12, 67);
      this.P_Enemy.Name = "P_Enemy";
      this.P_Enemy.Size = new Size(360, 402);
      this.P_Enemy.TabIndex = 5;
      this.T_Enemy.Interval = 1000;
      this.T_Enemy.Tick += new EventHandler(this.T_Enemy_Tick);
      this.T_Jikan.Interval = 1000;
      this.T_Jikan.Tick += new EventHandler(this.T_Jikan_Tick);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(384, 481);
      this.Controls.Add((Control) this.P_Enemy);
      this.Controls.Add((Control) this.PG_Jikan);
      this.Controls.Add((Control) this.L_Sum);
      this.Controls.Add((Control) this.L_Tokuten);
      this.Controls.Add((Control) this.L_Jikan);
      this.Controls.Add((Control) this.B_Start);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(2, 2, 2, 2);
      this.MaximizeBox = false;
      this.Name = nameof (F_Main);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "しるまを倒すゲーム Ver1.0.0.0 (メイン画面)";
      this.FormClosed += new FormClosedEventHandler(this.F_Main_FormClosed);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
