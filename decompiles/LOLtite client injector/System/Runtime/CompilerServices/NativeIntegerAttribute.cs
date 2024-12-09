// Decompiled with JetBrains decompiler
// Type: System.Runtime.CompilerServices.NativeIntegerAttribute
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using Microsoft.CodeAnalysis;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Runtime.CompilerServices
{
  [CompilerGenerated]
  [Embedded]
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
  internal sealed class NativeIntegerAttribute : Attribute
  {
    public readonly bool[] TransformFlags;

    public NativeIntegerAttribute()
    {
      // ISSUE: reference to a compiler-generated field
      this.TransformFlags = new bool[1]{ true };
    }

    public NativeIntegerAttribute([In] bool[] obj0) => this.TransformFlags = obj0;
  }
}
