using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
	// Token: 0x02000017 RID: 23
	[CompilerGenerated]
	internal static class AssemblyLoader
	{
		// Token: 0x06000052 RID: 82 RVA: 0x0000678C File Offset: 0x0000498C
		private static string CultureToString(CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000067A8 File Offset: 0x000049A8
		private static Assembly ReadExistingAssembly(AssemblyName name)
		{
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				AssemblyName name2 = assembly.GetName();
				if (string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(AssemblyLoader.CultureToString(name2.CultureInfo), AssemblyLoader.CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000681C File Offset: 0x00004A1C
		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int num;
			while ((num = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, num);
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00006854 File Offset: 0x00004A54
		private static Stream LoadStream(string fullName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (!fullName.EndsWith(".compressed"))
			{
				return executingAssembly.GetManifestResourceStream(fullName);
			}
			Stream stream;
			using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullName))
			{
				using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
				{
					MemoryStream memoryStream = new MemoryStream();
					AssemblyLoader.CopyTo(deflateStream, memoryStream);
					memoryStream.Position = 0L;
					stream = memoryStream;
				}
			}
			return stream;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000068F0 File Offset: 0x00004AF0
		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			string text;
			if (resourceNames.TryGetValue(name, out text))
			{
				return AssemblyLoader.LoadStream(text);
			}
			return null;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00006910 File Offset: 0x00004B10
		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000693C File Offset: 0x00004B3C
		private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name.ToLowerInvariant();
			if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
			{
				text = requestedAssemblyName.CultureInfo.Name + "." + text;
			}
			byte[] array;
			using (Stream stream = AssemblyLoader.LoadStream(assemblyNames, text))
			{
				if (stream == null)
				{
					return null;
				}
				array = AssemblyLoader.ReadStream(stream);
			}
			using (Stream stream2 = AssemblyLoader.LoadStream(symbolNames, text))
			{
				if (stream2 != null)
				{
					byte[] array2 = AssemblyLoader.ReadStream(stream2);
					return Assembly.Load(array, array2);
				}
			}
			return Assembly.Load(array);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000069FC File Offset: 0x00004BFC
		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			object obj = AssemblyLoader.nullCacheLock;
			Assembly assembly;
			lock (obj)
			{
				if (!AssemblyLoader.nullCache.ContainsKey(e.Name))
				{
					goto IL_003B;
				}
				assembly = null;
			}
			return assembly;
			IL_003B:
			AssemblyName assemblyName = new AssemblyName(e.Name);
			Assembly assembly2 = AssemblyLoader.ReadExistingAssembly(assemblyName);
			if (!(assembly2 != null))
			{
				assembly2 = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
				if (assembly2 == null)
				{
					obj = AssemblyLoader.nullCacheLock;
					lock (obj)
					{
						AssemblyLoader.nullCache[e.Name] = true;
					}
					if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
					{
						assembly2 = Assembly.Load(assemblyName);
					}
				}
				return assembly2;
			}
			return assembly2;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006AEC File Offset: 0x00004CEC
		static AssemblyLoader()
		{
			AssemblyLoader.assemblyNames.Add("axinterop.wmplib", "costura.axinterop.wmplib.dll.compressed");
			AssemblyLoader.assemblyNames.Add("costura", "costura.costura.dll.compressed");
			AssemblyLoader.assemblyNames.Add("csharpgdi", "costura.csharpgdi.dll.compressed");
			AssemblyLoader.symbolNames.Add("csharpgdi", "costura.csharpgdi.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("interop.wmplib", "costura.interop.wmplib.dll.compressed");
			AssemblyLoader.assemblyNames.Add("sysprivileges", "costura.sysprivileges.dll.compressed");
			AssemblyLoader.symbolNames.Add("sysprivileges", "costura.sysprivileges.pdb.compressed");
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00006BB4 File Offset: 0x00004DB4
		public static void Attach()
		{
			if (Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1)
			{
				return;
			}
			AppDomain.CurrentDomain.AssemblyResolve += AssemblyLoader.ResolveAssembly;
		}

		// Token: 0x0400003B RID: 59
		private static object nullCacheLock = new object();

		// Token: 0x0400003C RID: 60
		private static Dictionary<string, bool> nullCache = new Dictionary<string, bool>();

		// Token: 0x0400003D RID: 61
		private static Dictionary<string, string> assemblyNames = new Dictionary<string, string>();

		// Token: 0x0400003E RID: 62
		private static Dictionary<string, string> symbolNames = new Dictionary<string, string>();

		// Token: 0x0400003F RID: 63
		private static int isAttached;
	}
}
