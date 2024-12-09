// Decompiled with JetBrains decompiler
// Type: Tsutaemon_ver._1._0._0.NET_Framework.My.MySettingsProperty
// Assembly: Tsutaemon_ver._1._0._0.NET_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C66F1F10-4B55-49DA-BE62-9742375F83F4
// Assembly location: C:\Users\user\Downloads\Tsutaemon_ver._1._0._0.NET_Framework\Tsutaemon_ver._1._0._0.NET_Framework.exe
// XML documentation location: C:\Users\user\Downloads\Tsutaemon_ver._1._0._0.NET_Framework\Tsutaemon_ver._1._0._0.NET_Framework.xml

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#nullable disable
namespace Tsutaemon_ver._1._0._0.NET_Framework.My
{
  [StandardModule]
  [HideModuleName]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal sealed class MySettingsProperty
  {
    [HelpKeyword("My.Settings")]
    internal static MySettings Settings
    {
      get
      {
        MySettings settings = MySettings.Default;
        return settings;
      }
    }
  }
}
