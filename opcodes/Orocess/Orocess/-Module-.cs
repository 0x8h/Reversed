using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

// Token: 0x02000001 RID: 1
internal class <Module>
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	static <Module>()
	{
		<Module>.smethod_0();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x0000273C File Offset: 0x0000093C
	private static void smethod_0()
	{
		string text = "COR";
		Type type = <Module>.smethod_2(typeof(Environment).TypeHandle);
		MethodInfo methodInfo = <Module>.smethod_4(type, "GetEnvironmentVariable", new Type[] { <Module>.smethod_3(typeof(string).TypeHandle) });
		if (methodInfo != null && <Module>.smethod_7("1", <Module>.smethod_6(methodInfo, null, new object[] { <Module>.smethod_5(text, "_ENABLE_PROFILING") })))
		{
			<Module>.smethod_8(null);
		}
		Thread thread = <Module>.smethod_9(new ParameterizedThreadStart(<Module>.smethod_1));
		<Module>.smethod_10(thread, true);
		<Module>.smethod_11(thread, null);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000027D4 File Offset: 0x000009D4
	private static void smethod_1(object object_0)
	{
		Thread thread = object_0 as Thread;
		if (thread == null)
		{
			thread = <Module>.smethod_12(new ParameterizedThreadStart(<Module>.smethod_1));
			<Module>.smethod_13(thread, true);
			<Module>.smethod_15(thread, <Module>.smethod_14());
			<Module>.smethod_16(500);
		}
		for (;;)
		{
			if (<Module>.smethod_17())
			{
				goto IL_41;
			}
			if (<Module>.smethod_18())
			{
				goto IL_41;
			}
			IL_47:
			if (!<Module>.smethod_20(thread))
			{
				<Module>.smethod_21(null);
			}
			<Module>.smethod_22(1000);
			continue;
			IL_41:
			<Module>.smethod_19(null);
			goto IL_47;
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002059 File Offset: 0x00000259
	static Type smethod_2(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002059 File Offset: 0x00000259
	static Type smethod_3(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002061 File Offset: 0x00000261
	static MethodInfo smethod_4(Type type_0, string string_0, Type[] type_1)
	{
		return type_0.GetMethod(string_0, type_1);
	}

	// Token: 0x06000007 RID: 7 RVA: 0x0000206B File Offset: 0x0000026B
	static string smethod_5(string string_0, string string_1)
	{
		return string_0 + string_1;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002074 File Offset: 0x00000274
	static object smethod_6(MethodBase methodBase_0, object object_0, object[] object_1)
	{
		return methodBase_0.Invoke(object_0, object_1);
	}

	// Token: 0x06000009 RID: 9 RVA: 0x0000207E File Offset: 0x0000027E
	static bool smethod_7(object object_0, object object_1)
	{
		return object_0.Equals(object_1);
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002087 File Offset: 0x00000287
	static void smethod_8(string string_0)
	{
		Environment.FailFast(string_0);
	}

	// Token: 0x0600000B RID: 11 RVA: 0x0000208F File Offset: 0x0000028F
	static Thread smethod_9(ParameterizedThreadStart parameterizedThreadStart_0)
	{
		return new Thread(parameterizedThreadStart_0);
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002097 File Offset: 0x00000297
	static void smethod_10(Thread thread_0, bool bool_0)
	{
		thread_0.IsBackground = bool_0;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x000020A0 File Offset: 0x000002A0
	static void smethod_11(Thread thread_0, object object_0)
	{
		thread_0.Start(object_0);
	}

	// Token: 0x0600000E RID: 14 RVA: 0x0000208F File Offset: 0x0000028F
	static Thread smethod_12(ParameterizedThreadStart parameterizedThreadStart_0)
	{
		return new Thread(parameterizedThreadStart_0);
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002097 File Offset: 0x00000297
	static void smethod_13(Thread thread_0, bool bool_0)
	{
		thread_0.IsBackground = bool_0;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000020A9 File Offset: 0x000002A9
	static Thread smethod_14()
	{
		return Thread.CurrentThread;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000020A0 File Offset: 0x000002A0
	static void smethod_15(Thread thread_0, object object_0)
	{
		thread_0.Start(object_0);
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000020B0 File Offset: 0x000002B0
	static void smethod_16(int int_0)
	{
		Thread.Sleep(int_0);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000020B8 File Offset: 0x000002B8
	static bool smethod_17()
	{
		return Debugger.IsAttached;
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000020BF File Offset: 0x000002BF
	static bool smethod_18()
	{
		return Debugger.IsLogging();
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002087 File Offset: 0x00000287
	static void smethod_19(string string_0)
	{
		Environment.FailFast(string_0);
	}

	// Token: 0x06000016 RID: 22 RVA: 0x000020C6 File Offset: 0x000002C6
	static bool smethod_20(Thread thread_0)
	{
		return thread_0.IsAlive;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002087 File Offset: 0x00000287
	static void smethod_21(string string_0)
	{
		Environment.FailFast(string_0);
	}

	// Token: 0x06000018 RID: 24 RVA: 0x000020B0 File Offset: 0x000002B0
	static void smethod_22(int int_0)
	{
		Thread.Sleep(int_0);
	}
}
