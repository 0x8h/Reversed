//chilledwindows.exe
//decompile by qsqwqs
//WARNING! THIS IS NOT FULL REVERSE CODE. MAYBE IT DOESNT WORKING. NOTE THAT.

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

#nullable disable
namespace ChilledWindows
{
  public partial class MainWindow : Window, IComponentConnector
  {
    private TransformGroup fTransformGroup = new TransformGroup();
    private TransformGroup gTransGroup = new TransformGroup();
    private TranslateTransform gTransTransform = new TranslateTransform();
    private ScaleTransform gScaleTransform = new ScaleTransform();
    private ScaleTransform fFlipTrans = new ScaleTransform();
    private ScaleTransform FlipTrans1 = new ScaleTransform();
    private ScaleTransform FlipTrans2 = new ScaleTransform();
    private RotateTransform fRotateTrans = new RotateTransform();
    private int screenWidth;
    private int screenHeight;
    private DispatcherTimer dt = new DispatcherTimer();
    private int[] flipTimes = new int[96]
    {
      126,
      129,
      133,
      136,
      140,
      143,
      147,
      150,
      155,
      158,
      162,
      165,
      169,
      172,
      176,
      179,
      184,
      187,
      191,
      194,
      198,
      201,
      205,
      208,
      213,
      216,
      220,
      223,
      227,
      230,
      234,
      237,
      242,
      245,
      249,
      252,
      256,
      259,
      263,
      266,
      271,
      274,
      278,
      281,
      285,
      286,
      288,
      292,
      295,
      297,
      300,
      303,
      307,
      310,
      314,
      317,
      321,
      324,
      329,
      332,
      336,
      339,
      343,
      346,
      350,
      353,
      355,
      358,
      361,
      365,
      368,
      372,
      375,
      379,
      382,
      387,
      390,
      394,
      397,
      401,
      404,
      408,
      411,
      416,
      419,
      423,
      426,
      430,
      433,
      437,
      0,
      0,
      0,
      0,
      0,
      0
    };
    private int[] flipTimes2 = new int[40]
    {
      440,
      443,
      449,
      454,
      456,
      460,
      468,
      476,
      481,
      486,
      497,
      501,
      504,
      506,
      512,
      514,
      518,
      522,
      527,
      531,
      533,
      536,
      540,
      548,
      552,
      557,
      561,
      563,
      569,
      572,
      576,
      580,
      582,
      585,
      0,
      0,
      0,
      0,
      0,
      0
    };
    private int[] flipTimes1 = new int[14]
    {
      454,
      476,
      497,
      512,
      531,
      548,
      569,
      585,
      0,
      0,
      0,
      0,
      0,
      0
    };
    private int flipIndex;
    private int flipIndex1;
    private int flipIndex2;
    private int frameIndex;
    private bool refreshFirstFlips = true;
    private bool refreshSecondFlips = true;
    internal MediaElement mediaElement;
    internal System.Windows.Shapes.Rectangle bg;
    internal System.Windows.Controls.Image firstBg;
    internal Label label;
    internal Grid twoGrid;
    internal System.Windows.Controls.Image bg2;
    internal System.Windows.Controls.Image bg3;
    private bool _contentLoaded;

    public MainWindow()
    {
      Type typeFromProgId = Type.GetTypeFromProgID("Shell.Application");
      typeFromProgId.InvokeMember("MinimizeAll", BindingFlags.InvokeMethod, (Binder) null, Activator.CreateInstance(typeFromProgId), (object[]) null);
      Thread.Sleep(300);
      this.screenWidth = (int) SystemParameters.PrimaryScreenWidth;
      this.screenHeight = (int) SystemParameters.PrimaryScreenHeight;
      Bitmap bitmap = new Bitmap(this.screenWidth, this.screenHeight);
      using (Graphics graphics = Graphics.FromImage((System.Drawing.Image) bitmap))
        graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
      this.InitializeComponent();
      this.WindowState = WindowState.Normal;
      this.WindowStyle = WindowStyle.None;
      this.Topmost = true;
      this.WindowState = WindowState.Maximized;
      ImageSource imageSource = (ImageSource) this.BitmapToImageSource(bitmap);
      this.firstBg.Source = imageSource;
      this.bg2.Source = imageSource;
      this.bg3.Source = imageSource;
      this.firstBg.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
      this.fTransformGroup.Children.Add((Transform) this.fFlipTrans);
      this.fTransformGroup.Children.Add((Transform) this.fRotateTrans);
      this.firstBg.RenderTransform = (Transform) this.fTransformGroup;
      this.bg2.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
      this.bg2.RenderTransform = (Transform) this.FlipTrans1;
      this.bg3.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
      this.bg3.RenderTransform = (Transform) this.FlipTrans2;
      this.twoGrid.RenderTransformOrigin = new System.Windows.Point(0.0, 0.0);
      this.gTransGroup.Children.Add((Transform) this.gTransTransform);
      this.gTransGroup.Children.Add((Transform) this.gScaleTransform);
      this.twoGrid.RenderTransform = (Transform) this.gTransGroup;
      File.WriteAllBytes("chilledwindows.mp4", ChilledWindows.Properties.Resources.Chilled_Windows);
      this.mediaElement.Source = new Uri("chilledwindows.mp4", UriKind.Relative);
      this.dt.Tick += new EventHandler(this.Dt_Tick);
      this.dt.Interval = new TimeSpan(0, 0, 0, 0, 10);
      this.dt.Start();
    }

    private void Dt_Tick(object sender, EventArgs e)
    {
      this.frameIndex = (int) Math.Floor(this.mediaElement.Position.TotalMilliseconds / 33.33333);
      this.label.Content = (object) ("Frame:" + (object) this.frameIndex);
      if (this.frameIndex == 438)
      {
        this.refreshFirstFlips = false;
        this.firstBg.Visibility = Visibility.Hidden;
        this.twoGrid.Visibility = Visibility.Visible;
      }
      if (this.frameIndex == 585)
        this.refreshSecondFlips = false;
      if (this.frameIndex == 622)
      {
        this.bg.Visibility = Visibility.Hidden;
        double num1 = (double) this.screenWidth * (59.0 / 427.0);
        double num2 = (double) this.screenHeight * (17.0 / 48.0);
        DoubleAnimation animation1 = new DoubleAnimation(0.0, num1 * 3.0, (Duration) TimeSpan.FromMilliseconds(500.0));
        DoubleAnimation animation2 = new DoubleAnimation(0.0, num2 * 3.0, (Duration) TimeSpan.FromMilliseconds(500.0));
        DoubleAnimation animation3 = new DoubleAnimation(1.0, 0.3, (Duration) TimeSpan.FromMilliseconds(500.0));
        DoubleAnimation animation4 = new DoubleAnimation(1.0, 0.3, (Duration) TimeSpan.FromMilliseconds(500.0));
        this.gTransTransform.BeginAnimation(TranslateTransform.XProperty, (AnimationTimeline) animation1);
        this.gTransTransform.BeginAnimation(TranslateTransform.YProperty, (AnimationTimeline) animation2);
        this.gScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, (AnimationTimeline) animation3);
        this.gScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, (AnimationTimeline) animation4);
      }
      if (this.frameIndex == 665)
        this.twoGrid.Visibility = Visibility.Hidden;
      if (this.frameIndex == 1260)
      {
        File.Delete("chilledwindows.mp4");
        Application.Current.Shutdown();
      }
      if (this.refreshFirstFlips)
      {
        if (this.flipTimes[this.flipIndex] <= this.frameIndex)
        {
          ++this.flipIndex;
          this.fFlipTrans.ScaleX = this.fFlipTrans.ScaleX == -1.0 ? 1.0 : -1.0;
        }
        if (this.frameIndex != 286)
          return;
        this.fRotateTrans.Angle = -20.0;
      }
      else
      {
        if (!this.refreshSecondFlips)
          return;
        if (this.flipTimes1[this.flipIndex1] <= this.frameIndex)
        {
          ++this.flipIndex1;
          this.FlipTrans1.ScaleX = this.FlipTrans1.ScaleX == -1.0 ? 1.0 : -1.0;
        }
        if (this.flipTimes2[this.flipIndex2] > this.frameIndex)
          return;
        ++this.flipIndex2;
        this.FlipTrans2.ScaleX = this.FlipTrans2.ScaleX == -1.0 ? 1.0 : -1.0;
      }
    }

    private BitmapImage BitmapToImageSource(Bitmap bitmap)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        bitmap.Save((Stream) memoryStream, ImageFormat.Bmp);
        memoryStream.Position = 0L;
        BitmapImage imageSource = new BitmapImage();
        imageSource.BeginInit();
        imageSource.StreamSource = (Stream) memoryStream;
        imageSource.CacheOption = BitmapCacheOption.OnLoad;
        imageSource.EndInit();
        return imageSource;
      }
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key != Key.Space)
        return;
      this.fFlipTrans.ScaleX = this.fFlipTrans.ScaleX == -1.0 ? 1.0 : -1.0;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/ChilledWindows;component/mainwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          ((UIElement) target).KeyDown += new KeyEventHandler(this.Window_KeyDown);
          break;
        case 2:
          this.mediaElement = (MediaElement) target;
          break;
        case 3:
          this.bg = (System.Windows.Shapes.Rectangle) target;
          break;
        case 4:
          this.firstBg = (System.Windows.Controls.Image) target;
          break;
        case 5:
          this.label = (Label) target;
          break;
        case 6:
          this.twoGrid = (Grid) target;
          break;
        case 7:
          this.bg2 = (System.Windows.Controls.Image) target;
          break;
        case 8:
          this.bg3 = (System.Windows.Controls.Image) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
