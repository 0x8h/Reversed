using System;
using System.Collections.Generic;
using System.Reflection;

namespace PdfSharp.Pdf
{
	// Token: 0x02000191 RID: 401
	internal class DictionaryMeta
	{
		// Token: 0x06000CCC RID: 3276 RVA: 0x000341C0 File Offset: 0x000323C0
		public DictionaryMeta(Type type)
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			foreach (FieldInfo fieldInfo in fields)
			{
				object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(KeyInfoAttribute), false);
				if (customAttributes.Length == 1)
				{
					KeyInfoAttribute keyInfoAttribute = (KeyInfoAttribute)customAttributes[0];
					KeyDescriptor keyDescriptor = new KeyDescriptor(keyInfoAttribute);
					keyDescriptor.KeyValue = (string)fieldInfo.GetValue(null);
					this._keyDescriptors[keyDescriptor.KeyValue] = keyDescriptor;
				}
			}
		}

		// Token: 0x1700045D RID: 1117
		public KeyDescriptor this[string key]
		{
			get
			{
				KeyDescriptor keyDescriptor;
				this._keyDescriptors.TryGetValue(key, out keyDescriptor);
				return keyDescriptor;
			}
		}

		// Token: 0x0400083E RID: 2110
		private readonly Dictionary<string, KeyDescriptor> _keyDescriptors = new Dictionary<string, KeyDescriptor>();
	}
}
