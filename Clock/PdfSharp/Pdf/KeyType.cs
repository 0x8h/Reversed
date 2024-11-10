using System;

namespace PdfSharp.Pdf
{
	// Token: 0x02000181 RID: 385
	[Flags]
	internal enum KeyType
	{
		// Token: 0x040007DA RID: 2010
		Name = 1,
		// Token: 0x040007DB RID: 2011
		String = 2,
		// Token: 0x040007DC RID: 2012
		Boolean = 3,
		// Token: 0x040007DD RID: 2013
		Integer = 4,
		// Token: 0x040007DE RID: 2014
		Real = 5,
		// Token: 0x040007DF RID: 2015
		Date = 6,
		// Token: 0x040007E0 RID: 2016
		Rectangle = 7,
		// Token: 0x040007E1 RID: 2017
		Array = 8,
		// Token: 0x040007E2 RID: 2018
		Dictionary = 9,
		// Token: 0x040007E3 RID: 2019
		Stream = 10,
		// Token: 0x040007E4 RID: 2020
		NumberTree = 11,
		// Token: 0x040007E5 RID: 2021
		Function = 12,
		// Token: 0x040007E6 RID: 2022
		TextString = 13,
		// Token: 0x040007E7 RID: 2023
		ByteString = 14,
		// Token: 0x040007E8 RID: 2024
		NameOrArray = 16,
		// Token: 0x040007E9 RID: 2025
		NameOrDictionary = 32,
		// Token: 0x040007EA RID: 2026
		ArrayOrDictionary = 48,
		// Token: 0x040007EB RID: 2027
		StreamOrArray = 64,
		// Token: 0x040007EC RID: 2028
		StreamOrName = 80,
		// Token: 0x040007ED RID: 2029
		ArrayOrNameOrString = 96,
		// Token: 0x040007EE RID: 2030
		FunctionOrName = 112,
		// Token: 0x040007EF RID: 2031
		Various = 128,
		// Token: 0x040007F0 RID: 2032
		TypeMask = 255,
		// Token: 0x040007F1 RID: 2033
		Optional = 256,
		// Token: 0x040007F2 RID: 2034
		Required = 512,
		// Token: 0x040007F3 RID: 2035
		Inheritable = 1024,
		// Token: 0x040007F4 RID: 2036
		MustBeIndirect = 4096,
		// Token: 0x040007F5 RID: 2037
		MustNotBeIndirect = 8192
	}
}
