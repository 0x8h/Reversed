// Decompiled with JetBrains decompiler
// Type: ChilledWindows.Properties.Resources
// Assembly: ChilledWindows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03DD8084-1A47-4020-BB07-7BF62B11EC5F
// Assembly location: C:\Users\user\Documents\disassemble list\chillledwindows\chilledwindows.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace ChilledWindows.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (ChilledWindows.Properties.Resources.resourceMan == null)
          ChilledWindows.Properties.Resources.resourceMan = new ResourceManager("ChilledWindows.Properties.Resources", typeof (ChilledWindows.Properties.Resources).Assembly);
        return ChilledWindows.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => ChilledWindows.Properties.Resources.resourceCulture;
      set => ChilledWindows.Properties.Resources.resourceCulture = value;
    }

    internal static byte[] Chilled_Windows
    {
      get
      {
        return (byte[]) ChilledWindows.Properties.Resources.ResourceManager.GetObject(nameof (Chilled_Windows), ChilledWindows.Properties.Resources.resourceCulture);
      }
    }
  }
}
