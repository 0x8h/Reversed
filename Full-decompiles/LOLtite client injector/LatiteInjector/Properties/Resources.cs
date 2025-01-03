// Decompiled with JetBrains decompiler
// Type: LatiteInjector.Properties.Resources
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace LatiteInjector.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  public class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static ResourceManager ResourceManager
    {
      get
      {
        if (LatiteInjector.Properties.Resources.resourceMan == null)
          LatiteInjector.Properties.Resources.resourceMan = new ResourceManager("LatiteInjector.Properties.Resources", typeof (LatiteInjector.Properties.Resources).Assembly);
        return LatiteInjector.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static CultureInfo Culture
    {
      get => LatiteInjector.Properties.Resources.resourceCulture;
      set => LatiteInjector.Properties.Resources.resourceCulture = value;
    }

    public static Icon LatiteIcon
    {
      get
      {
        return (Icon) LatiteInjector.Properties.Resources.ResourceManager.GetObject(nameof (LatiteIcon), LatiteInjector.Properties.Resources.resourceCulture);
      }
    }
  }
}
