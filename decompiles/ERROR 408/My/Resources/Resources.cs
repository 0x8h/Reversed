// Decompiled with JetBrains decompiler
// Type: ERROR_408.My.Resources.Resources
// Assembly: ERROR 408, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3A16A069-E54E-486F-B90E-25ABCEBFADB0
// Assembly location: C:\Users\user\Downloads\huherror(Fixed)\huherror\huherror.exe
// XML documentation location: C:\Users\user\Downloads\huherror(Fixed)\huherror\huherror.xml

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace ERROR_408.My.Resources
{
  /// <summary>A strongly-typed resource class, for looking up localized strings, etc.</summary>
  [StandardModule]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [HideModuleName]
  internal sealed class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    /// <summary>Returns the cached ResourceManager instance used by this class.</summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) ERROR_408.My.Resources.Resources.resourceMan, (object) null))
          ERROR_408.My.Resources.Resources.resourceMan = new ResourceManager("ERROR_408.Resources", typeof (ERROR_408.My.Resources.Resources).Assembly);
        return ERROR_408.My.Resources.Resources.resourceMan;
      }
    }

    /// <summary>
    ///   Overrides the current thread's CurrentUICulture property for all
    ///   resource lookups using this strongly typed resource class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => ERROR_408.My.Resources.Resources.resourceCulture;
      set => ERROR_408.My.Resources.Resources.resourceCulture = value;
    }
  }
}
