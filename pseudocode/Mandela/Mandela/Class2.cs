using System;
using System.Reflection;

// Token: 0x0200001A RID: 26
internal class Class2
{
	// Token: 0x0600005C RID: 92 RVA: 0x00006BE8 File Offset: 0x00004DE8
	internal static void smethod_0(int typemdt)
	{
		Type type = Class2.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo methodInfo = (MethodInfo)Class2.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, methodInfo));
		}
	}

	// Token: 0x04000040 RID: 64
	internal static Module module_0 = typeof(Class2).Assembly.ManifestModule;

	// Token: 0x0200001B RID: 27
	// (Invoke) Token: 0x06000060 RID: 96
	internal delegate void Delegate0(object o);
}
