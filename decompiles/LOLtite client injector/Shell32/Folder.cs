// Decompiled with JetBrains decompiler
// Type: Shell32.Folder
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Shell32
{
  [CompilerGenerated]
  [Guid("BBCBDE60-C3FF-11CE-8350-444553540000")]
  [DefaultMember("Title")]
  [TypeIdentifier]
  [ComImport]
  public interface Folder
  {
    [DispId(0)]
    string Title { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.BStr)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    sealed extern void _VtblGap1_7();

    [DispId(1610743816)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void CopyHere([MarshalAs(UnmanagedType.Struct), In] object vItem, [MarshalAs(UnmanagedType.Struct), In, Optional] object vOptions);
  }
}
