// Decompiled with JetBrains decompiler
// Type: LatiteInjector.Utils.FontManager
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using Shell32;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;

#nullable enable
namespace LatiteInjector.Utils
{
  public static class FontManager
  {
    public static bool IsFontInstalled(string fontName)
    {
      using (Font font = new Font(fontName, 8f))
        return string.Compare(fontName, font.Name, StringComparison.InvariantCultureIgnoreCase) == 0;
    }

    public static void InstallFont(string fontSourcePath)
    {
      Type typeFromProgId = Type.GetTypeFromProgID("Shell.Application");
      // ISSUE: variable of a compiler-generated type
      Folder folder = (Folder) typeFromProgId.InvokeMember("NameSpace", BindingFlags.InvokeMethod, (Binder) null, Activator.CreateInstance(typeFromProgId), new object[1]
      {
        (object) Environment.GetFolderPath(Environment.SpecialFolder.Fonts)
      });
      if (!File.Exists(fontSourcePath))
        return;
      // ISSUE: reference to a compiler-generated method
      folder.CopyHere((object) fontSourcePath, Type.Missing);
    }
  }
}
