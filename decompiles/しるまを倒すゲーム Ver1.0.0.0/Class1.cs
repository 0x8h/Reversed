//しるまを倒すゲーム Ver1.0.0.0
//code by citrax
//www.tiktok.com/@shiruma160150/video/7384012246524906753
//WARNING! THIS IS NOT FULL REVERSE CODE. MAYBE IT DOESNT WORKING. NOTE THAT.

using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

#nullable disable
namespace ClickBuster_cs
{
  internal class CEnemy
  {
    private PictureBox _pbImgEnemy;
    private Control _enemyOwner;
    private Random _rnd;
    private int _intTokuten;
    private int _intMvwd;
    private int _intMvud;
    private int _intMovePattern;

    public event EventHandler OnClick;

    public CEnemy(Control owner, Random rand)
    {
      this._pbImgEnemy = new PictureBox();
      this._enemyOwner = owner;
      this._rnd = rand;
      this._intMvwd = 10;
      this._intMvud = 0;
      this._pbImgEnemy.Click += new EventHandler(this.DoClick);
      this._RandPlace();
      this._enemyOwner.Controls.Add((Control) this._pbImgEnemy);
    }

    private void DoClick(object sender, EventArgs e)
    {
      this.PlaySound("enemy_down.wav");
      if (!(this._enemyOwner.Parent is Form))
        ;
      this.EnemyDown();
    }

    private void _RandPlace()
    {
      Random random = new Random();
      int maxValue = 10;
      random.Next(maxValue);
      random.Next(10);
      random.Next(10);
      this._intMovePattern = this._rnd.Next(1, 4);
      this._pbImgEnemy.SizeMode = PictureBoxSizeMode.AutoSize;
      switch (this._intMovePattern)
      {
        case 1:
          this._pbImgEnemy.Image = Image.FromFile("enemy1.jpeg");
          this._intTokuten = 500;
          break;
        case 2:
          this._pbImgEnemy.Image = Image.FromFile("enemy2.jpeg");
          this._intTokuten = 1000;
          break;
        case 3:
          this._pbImgEnemy.Image = Image.FromFile("enemy3.jpeg");
          this._intTokuten = 3000;
          break;
      }
    }

    public void MvEnm()
    {
      switch (this._intMovePattern)
      {
        case 1:
          switch (this._rnd.Next(1, 5))
          {
            case 1:
              if (this._pbImgEnemy.Top + this._pbImgEnemy.Height + this._intMvwd >= this._enemyOwner.Height)
                return;
              this._pbImgEnemy.Top += this._intMvwd;
              return;
            case 2:
              if (this._pbImgEnemy.Top - this._intMvwd <= 0)
                return;
              this._pbImgEnemy.Top -= this._intMvwd;
              return;
            case 3:
              if (this._pbImgEnemy.Left + this._pbImgEnemy.Width + this._intMvwd >= this._enemyOwner.Width)
                return;
              this._pbImgEnemy.Left += this._intMvwd;
              return;
            case 4:
              if (this._pbImgEnemy.Left - this._intMvwd <= 0)
                return;
              this._pbImgEnemy.Left -= this._intMvwd;
              return;
            default:
              return;
          }
        case 2:
          if (this._intMvud == 0)
            this._intMvud = this._rnd.Next(1, 5);
          switch (this._intMvud)
          {
            case 1:
              if (this._pbImgEnemy.Top + this._pbImgEnemy.Height + this._intMvwd < this._enemyOwner.Height)
              {
                this._pbImgEnemy.Top += this._intMvwd;
                return;
              }
              this._intMvud = this._rnd.Next(1, 5);
              return;
            case 2:
              if (this._pbImgEnemy.Top - this._intMvwd > 0)
              {
                this._pbImgEnemy.Top -= this._intMvwd;
                return;
              }
              this._intMvud = this._rnd.Next(1, 5);
              return;
            case 3:
              if (this._pbImgEnemy.Left + this._pbImgEnemy.Width + this._intMvwd < this._enemyOwner.Width)
              {
                this._pbImgEnemy.Left += this._intMvwd;
                return;
              }
              this._intMvud = this._rnd.Next(1, 5);
              return;
            case 4:
              if (this._pbImgEnemy.Left - this._intMvwd > 0)
              {
                this._pbImgEnemy.Left -= this._intMvwd;
                return;
              }
              this._intMvud = this._rnd.Next(1, 5);
              return;
            default:
              return;
          }
        case 3:
          if (this._intMvud == 0)
            this._intMvud = this._rnd.Next(1, 5);
          switch (this._intMvud)
          {
            case 1:
              if (this._pbImgEnemy.Top + this._pbImgEnemy.Height + this._intMvwd < this._enemyOwner.Height)
                this._pbImgEnemy.Top += this._intMvwd;
              else
                this._intMvud = this._rnd.Next(1, 5);
              if (this._pbImgEnemy.Top + this._pbImgEnemy.Height + this._intMvwd < this._enemyOwner.Height && this._pbImgEnemy.Left + this._pbImgEnemy.Width + this._intMvwd < this._enemyOwner.Width)
              {
                this._pbImgEnemy.Top += this._intMvwd;
                this._pbImgEnemy.Left += this._intMvwd;
                return;
              }
              if (this._pbImgEnemy.Top + this._pbImgEnemy.Height + this._intMvwd >= this._enemyOwner.Height)
                this._intMvud = 2;
              else if (this._pbImgEnemy.Left + this._pbImgEnemy.Width + this._intMvwd >= this._enemyOwner.Width)
                this._intMvud = 3;
              return;
            case 2:
              if (this._pbImgEnemy.Top - this._intMvwd > 0 && this._pbImgEnemy.Left + this._pbImgEnemy.Width + this._intMvwd < this._enemyOwner.Width)
              {
                this._pbImgEnemy.Top -= this._intMvwd;
                this._pbImgEnemy.Left += this._intMvwd;
                return;
              }
              if (this._pbImgEnemy.Top - this._intMvwd <= 0)
                this._intMvud = 1;
              else if (this._pbImgEnemy.Left + this._pbImgEnemy.Width + this._intMvwd >= this._enemyOwner.Width)
                this._intMvud = 4;
              return;
            case 3:
              if (this._pbImgEnemy.Left - this._intMvwd > 0 && this._pbImgEnemy.Top + this._pbImgEnemy.Height + this._intMvwd < this._enemyOwner.Height)
              {
                this._pbImgEnemy.Top += this._intMvwd;
                this._pbImgEnemy.Left -= this._intMvwd;
                return;
              }
              if (this._pbImgEnemy.Left - this._intMvwd <= 0)
                this._intMvud = 1;
              else if (this._pbImgEnemy.Top + this._pbImgEnemy.Height + this._intMvwd >= this._enemyOwner.Height)
                this._intMvud = 4;
              return;
            case 4:
              if (this._pbImgEnemy.Left - this._intMvwd > 0 && this._pbImgEnemy.Top - this._intMvwd > 0)
              {
                this._pbImgEnemy.Top -= this._intMvwd;
                this._pbImgEnemy.Left -= this._intMvwd;
                return;
              }
              if (this._pbImgEnemy.Left - this._intMvwd <= 0)
                this._intMvud = 2;
              else if (this._pbImgEnemy.Top - this._intMvwd <= 0)
                this._intMvud = 3;
              return;
            default:
              return;
          }
      }
    }

    public void EnemyDown() => this._RandPlace();

    public int GetTokuten() => this._intTokuten;

    private void PlaySound(string soundFilePath) => new SoundPlayer(soundFilePath).Play();
  }
}
