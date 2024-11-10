using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Security
{
	// Token: 0x0200017F RID: 383
	public sealed class PdfStandardSecurityHandler : PdfSecurityHandler
	{
		// Token: 0x06000C90 RID: 3216 RVA: 0x000331EC File Offset: 0x000313EC
		internal PdfStandardSecurityHandler(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x0003322A File Offset: 0x0003142A
		internal PdfStandardSecurityHandler(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x1700044E RID: 1102
		// (set) Token: 0x06000C92 RID: 3218 RVA: 0x00033268 File Offset: 0x00031468
		public string UserPassword
		{
			set
			{
				if (this._document._securitySettings.DocumentSecurityLevel == PdfDocumentSecurityLevel.None)
				{
					this._document._securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted128Bit;
				}
				this._userPassword = value;
			}
		}

		// Token: 0x1700044F RID: 1103
		// (set) Token: 0x06000C93 RID: 3219 RVA: 0x00033294 File Offset: 0x00031494
		public string OwnerPassword
		{
			set
			{
				if (this._document._securitySettings.DocumentSecurityLevel == PdfDocumentSecurityLevel.None)
				{
					this._document._securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted128Bit;
				}
				this._ownerPassword = value;
			}
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000C94 RID: 3220 RVA: 0x000332C0 File Offset: 0x000314C0
		// (set) Token: 0x06000C95 RID: 3221 RVA: 0x000332E5 File Offset: 0x000314E5
		internal PdfUserAccessPermission Permission
		{
			get
			{
				PdfUserAccessPermission pdfUserAccessPermission = (PdfUserAccessPermission)base.Elements.GetInteger("/P");
				if (pdfUserAccessPermission == (PdfUserAccessPermission)0)
				{
					pdfUserAccessPermission = PdfUserAccessPermission.PermitAll;
				}
				return pdfUserAccessPermission;
			}
			set
			{
				base.Elements.SetInteger("/P", (int)value);
			}
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x000332F8 File Offset: 0x000314F8
		public void EncryptDocument()
		{
			foreach (PdfReference pdfReference in this._document._irefTable.AllReferences)
			{
				if (!object.ReferenceEquals(pdfReference.Value, this))
				{
					this.EncryptObject(pdfReference.Value);
				}
			}
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x00033344 File Offset: 0x00031544
		internal void EncryptObject(PdfObject value)
		{
			this.SetHashKey(value.ObjectID);
			PdfDictionary pdfDictionary;
			if ((pdfDictionary = value as PdfDictionary) != null)
			{
				this.EncryptDictionary(pdfDictionary);
				return;
			}
			PdfArray pdfArray;
			if ((pdfArray = value as PdfArray) != null)
			{
				this.EncryptArray(pdfArray);
				return;
			}
			PdfStringObject pdfStringObject;
			if ((pdfStringObject = value as PdfStringObject) != null && pdfStringObject.Length != 0)
			{
				byte[] encryptionValue = pdfStringObject.EncryptionValue;
				this.PrepareKey();
				this.EncryptRC4(encryptionValue);
				pdfStringObject.EncryptionValue = encryptionValue;
			}
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x000333B0 File Offset: 0x000315B0
		private void EncryptDictionary(PdfDictionary dict)
		{
			PdfName[] keyNames = dict.Elements.KeyNames;
			foreach (KeyValuePair<string, PdfItem> keyValuePair in dict.Elements)
			{
				PdfString pdfString;
				PdfDictionary pdfDictionary;
				PdfArray pdfArray;
				if ((pdfString = keyValuePair.Value as PdfString) != null)
				{
					this.EncryptString(pdfString);
				}
				else if ((pdfDictionary = keyValuePair.Value as PdfDictionary) != null)
				{
					this.EncryptDictionary(pdfDictionary);
				}
				else if ((pdfArray = keyValuePair.Value as PdfArray) != null)
				{
					this.EncryptArray(pdfArray);
				}
			}
			if (dict.Stream != null)
			{
				byte[] value = dict.Stream.Value;
				if (value.Length != 0)
				{
					this.PrepareKey();
					this.EncryptRC4(value);
					dict.Stream.Value = value;
				}
			}
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x00033488 File Offset: 0x00031688
		private void EncryptArray(PdfArray array)
		{
			int count = array.Elements.Count;
			for (int i = 0; i < count; i++)
			{
				PdfItem pdfItem = array.Elements[i];
				PdfString pdfString;
				PdfDictionary pdfDictionary;
				PdfArray pdfArray;
				if ((pdfString = pdfItem as PdfString) != null)
				{
					this.EncryptString(pdfString);
				}
				else if ((pdfDictionary = pdfItem as PdfDictionary) != null)
				{
					this.EncryptDictionary(pdfDictionary);
				}
				else if ((pdfArray = pdfItem as PdfArray) != null)
				{
					this.EncryptArray(pdfArray);
				}
			}
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x000334F8 File Offset: 0x000316F8
		private void EncryptString(PdfString value)
		{
			if (value.Length != 0)
			{
				byte[] encryptionValue = value.EncryptionValue;
				this.PrepareKey();
				this.EncryptRC4(encryptionValue);
				value.EncryptionValue = encryptionValue;
			}
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x00033528 File Offset: 0x00031728
		internal byte[] EncryptBytes(byte[] bytes)
		{
			if (bytes != null && bytes.Length != 0)
			{
				this.PrepareKey();
				this.EncryptRC4(bytes);
			}
			return bytes;
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x00033540 File Offset: 0x00031740
		public PasswordValidity ValidatePassword(string inputPassword)
		{
			string name = base.Elements.GetName("/Filter");
			int integer = base.Elements.GetInteger("/V");
			if (name != "/Standard" || integer < 1 || integer > 3)
			{
				throw new PdfReaderException(PSSR.UnknownEncryption);
			}
			byte[] bytes = PdfEncoders.RawEncoding.GetBytes(this.Owner.Internals.FirstDocumentID);
			byte[] bytes2 = PdfEncoders.RawEncoding.GetBytes(base.Elements.GetString("/O"));
			byte[] bytes3 = PdfEncoders.RawEncoding.GetBytes(base.Elements.GetString("/U"));
			int integer2 = base.Elements.GetInteger("/P");
			int integer3 = base.Elements.GetInteger("/R");
			if (inputPassword == null)
			{
				inputPassword = "";
			}
			bool flag = integer3 == 3;
			int num = (flag ? 16 : 32);
			this.InitWithOwnerPassword(bytes, inputPassword, bytes2, integer2, flag);
			if (this.EqualsKey(bytes3, num))
			{
				this._document.SecuritySettings._hasOwnerPermissions = true;
				return PasswordValidity.OwnerPassword;
			}
			this._document.SecuritySettings._hasOwnerPermissions = false;
			this.InitWithUserPassword(bytes, inputPassword, bytes2, integer2, flag);
			if (this.EqualsKey(bytes3, num))
			{
				return PasswordValidity.UserPassword;
			}
			return PasswordValidity.Invalid;
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x0003367C File Offset: 0x0003187C
		[Conditional("DEBUG")]
		private static void DumpBytes(string tag, byte[] bytes)
		{
			string text = tag + ": ";
			for (int i = 0; i < bytes.Length; i++)
			{
				text += string.Format("{0:X2}", bytes[i]);
			}
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x000336BC File Offset: 0x000318BC
		private static byte[] PadPassword(string password)
		{
			byte[] array = new byte[32];
			if (password == null)
			{
				Array.Copy(PdfStandardSecurityHandler.PasswordPadding, 0, array, 0, 32);
			}
			else
			{
				int length = password.Length;
				Array.Copy(PdfEncoders.RawEncoding.GetBytes(password), 0, array, 0, Math.Min(length, 32));
				if (length < 32)
				{
					Array.Copy(PdfStandardSecurityHandler.PasswordPadding, 0, array, length, 32 - length);
				}
			}
			return array;
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x0003371E File Offset: 0x0003191E
		private void InitWithUserPassword(byte[] documentID, string userPassword, byte[] ownerKey, int permissions, bool strongEncryption)
		{
			this.InitEncryptionKey(documentID, PdfStandardSecurityHandler.PadPassword(userPassword), ownerKey, permissions, strongEncryption);
			this.SetupUserKey(documentID);
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x0003373C File Offset: 0x0003193C
		private void InitWithOwnerPassword(byte[] documentID, string ownerPassword, byte[] ownerKey, int permissions, bool strongEncryption)
		{
			byte[] array = this.ComputeOwnerKey(ownerKey, PdfStandardSecurityHandler.PadPassword(ownerPassword), strongEncryption);
			this.InitEncryptionKey(documentID, array, ownerKey, permissions, strongEncryption);
			this.SetupUserKey(documentID);
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x00033770 File Offset: 0x00031970
		private byte[] ComputeOwnerKey(byte[] userPad, byte[] ownerPad, bool strongEncryption)
		{
			byte[] array = new byte[32];
			byte[] array2 = this._md5.ComputeHash(ownerPad);
			if (strongEncryption)
			{
				byte[] array3 = new byte[16];
				for (int i = 0; i < 50; i++)
				{
					array2 = this._md5.ComputeHash(array2);
				}
				Array.Copy(userPad, 0, array, 0, 32);
				for (int j = 0; j < 20; j++)
				{
					for (int k = 0; k < array3.Length; k++)
					{
						array3[k] = (byte)((int)array2[k] ^ j);
					}
					this.PrepareRC4Key(array3);
					this.EncryptRC4(array);
				}
			}
			else
			{
				this.PrepareRC4Key(array2, 0, 5);
				this.EncryptRC4(userPad, array);
			}
			return array;
		}

		// Token: 0x06000CA2 RID: 3234 RVA: 0x00033814 File Offset: 0x00031A14
		private void InitEncryptionKey(byte[] documentID, byte[] userPad, byte[] ownerKey, int permissions, bool strongEncryption)
		{
			this._ownerKey = ownerKey;
			this._encryptionKey = new byte[strongEncryption ? 16 : 5];
			this._md5.Initialize();
			this._md5.TransformBlock(userPad, 0, userPad.Length, userPad, 0);
			this._md5.TransformBlock(ownerKey, 0, ownerKey.Length, ownerKey, 0);
			byte[] array = new byte[]
			{
				(byte)permissions,
				(byte)(permissions >> 8),
				(byte)(permissions >> 16),
				(byte)(permissions >> 24)
			};
			this._md5.TransformBlock(array, 0, 4, array, 0);
			this._md5.TransformBlock(documentID, 0, documentID.Length, documentID, 0);
			this._md5.TransformFinalBlock(array, 0, 0);
			byte[] array2 = this._md5.Hash;
			this._md5.Initialize();
			if (this._encryptionKey.Length == 16)
			{
				for (int i = 0; i < 50; i++)
				{
					array2 = this._md5.ComputeHash(array2);
					this._md5.Initialize();
				}
			}
			Array.Copy(array2, 0, this._encryptionKey, 0, this._encryptionKey.Length);
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x00033928 File Offset: 0x00031B28
		private void SetupUserKey(byte[] documentID)
		{
			if (this._encryptionKey.Length == 16)
			{
				this._md5.TransformBlock(PdfStandardSecurityHandler.PasswordPadding, 0, PdfStandardSecurityHandler.PasswordPadding.Length, PdfStandardSecurityHandler.PasswordPadding, 0);
				this._md5.TransformFinalBlock(documentID, 0, documentID.Length);
				byte[] hash = this._md5.Hash;
				this._md5.Initialize();
				Array.Copy(hash, 0, this._userKey, 0, 16);
				for (int i = 16; i < 32; i++)
				{
					this._userKey[i] = 0;
				}
				for (int j = 0; j < 20; j++)
				{
					for (int k = 0; k < this._encryptionKey.Length; k++)
					{
						hash[k] = (byte)((int)this._encryptionKey[k] ^ j);
					}
					this.PrepareRC4Key(hash, 0, this._encryptionKey.Length);
					this.EncryptRC4(this._userKey, 0, 16);
				}
				return;
			}
			this.PrepareRC4Key(this._encryptionKey);
			this.EncryptRC4(PdfStandardSecurityHandler.PasswordPadding, this._userKey);
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x00033A1D File Offset: 0x00031C1D
		private void PrepareKey()
		{
			this.PrepareRC4Key(this._key, 0, this._keySize);
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x00033A32 File Offset: 0x00031C32
		private void PrepareRC4Key(byte[] key)
		{
			this.PrepareRC4Key(key, 0, key.Length);
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x00033A40 File Offset: 0x00031C40
		private void PrepareRC4Key(byte[] key, int offset, int length)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 256; i++)
			{
				this._state[i] = (byte)i;
			}
			for (int j = 0; j < 256; j++)
			{
				num2 = ((int)(key[num + offset] + this._state[j]) + num2) & 255;
				byte b = this._state[j];
				this._state[j] = this._state[num2];
				this._state[num2] = b;
				num = (num + 1) % length;
			}
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x00033AC1 File Offset: 0x00031CC1
		private void EncryptRC4(byte[] data)
		{
			this.EncryptRC4(data, 0, data.Length, data);
		}

		// Token: 0x06000CA8 RID: 3240 RVA: 0x00033ACF File Offset: 0x00031CCF
		private void EncryptRC4(byte[] data, int offset, int length)
		{
			this.EncryptRC4(data, offset, length, data);
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x00033ADB File Offset: 0x00031CDB
		private void EncryptRC4(byte[] inputData, byte[] outputData)
		{
			this.EncryptRC4(inputData, 0, inputData.Length, outputData);
		}

		// Token: 0x06000CAA RID: 3242 RVA: 0x00033AEC File Offset: 0x00031CEC
		private void EncryptRC4(byte[] inputData, int offset, int length, byte[] outputData)
		{
			length += offset;
			int num = 0;
			int num2 = 0;
			for (int i = offset; i < length; i++)
			{
				num = (num + 1) & 255;
				num2 = ((int)this._state[num] + num2) & 255;
				byte b = this._state[num];
				this._state[num] = this._state[num2];
				this._state[num2] = b;
				outputData[i] = inputData[i] ^ this._state[(int)((this._state[num] + this._state[num2]) & byte.MaxValue)];
			}
		}

		// Token: 0x06000CAB RID: 3243 RVA: 0x00033B74 File Offset: 0x00031D74
		private bool EqualsKey(byte[] value, int length)
		{
			for (int i = 0; i < length; i++)
			{
				if (this._userKey[i] != value[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000CAC RID: 3244 RVA: 0x00033BA0 File Offset: 0x00031DA0
		internal void SetHashKey(PdfObjectID id)
		{
			byte[] array = new byte[5];
			this._md5.Initialize();
			array[0] = (byte)id.ObjectNumber;
			array[1] = (byte)(id.ObjectNumber >> 8);
			array[2] = (byte)(id.ObjectNumber >> 16);
			array[3] = (byte)id.GenerationNumber;
			array[4] = (byte)(id.GenerationNumber >> 8);
			this._md5.TransformBlock(this._encryptionKey, 0, this._encryptionKey.Length, this._encryptionKey, 0);
			this._md5.TransformFinalBlock(array, 0, array.Length);
			this._key = this._md5.Hash;
			this._md5.Initialize();
			this._keySize = this._encryptionKey.Length + 5;
			if (this._keySize > 16)
			{
				this._keySize = 16;
			}
		}

		// Token: 0x06000CAD RID: 3245 RVA: 0x00033C70 File Offset: 0x00031E70
		public void PrepareEncryption()
		{
			int num = (int)this.Permission;
			bool flag = this._document._securitySettings.DocumentSecurityLevel == PdfDocumentSecurityLevel.Encrypted128Bit;
			PdfInteger pdfInteger;
			PdfInteger pdfInteger2;
			PdfInteger pdfInteger3;
			if (flag)
			{
				pdfInteger = new PdfInteger(2);
				pdfInteger2 = new PdfInteger(128);
				pdfInteger3 = new PdfInteger(3);
			}
			else
			{
				pdfInteger = new PdfInteger(1);
				pdfInteger2 = new PdfInteger(40);
				pdfInteger3 = new PdfInteger(2);
			}
			if (string.IsNullOrEmpty(this._userPassword))
			{
				this._userPassword = "";
			}
			if (string.IsNullOrEmpty(this._ownerPassword))
			{
				this._ownerPassword = this._userPassword;
			}
			num |= (flag ? (-3904) : (-64));
			num &= -4;
			PdfInteger pdfInteger4 = new PdfInteger(num);
			byte[] array = PdfStandardSecurityHandler.PadPassword(this._userPassword);
			byte[] array2 = PdfStandardSecurityHandler.PadPassword(this._ownerPassword);
			this._md5.Initialize();
			this._ownerKey = this.ComputeOwnerKey(array, array2, flag);
			byte[] bytes = PdfEncoders.RawEncoding.GetBytes(this._document.Internals.FirstDocumentID);
			this.InitWithUserPassword(bytes, this._userPassword, this._ownerKey, num, flag);
			PdfString pdfString = new PdfString(PdfEncoders.RawEncoding.GetString(this._ownerKey, 0, this._ownerKey.Length));
			PdfString pdfString2 = new PdfString(PdfEncoders.RawEncoding.GetString(this._userKey, 0, this._userKey.Length));
			base.Elements["/Filter"] = new PdfName("/Standard");
			base.Elements["/V"] = pdfInteger;
			base.Elements["/Length"] = pdfInteger2;
			base.Elements["/R"] = pdfInteger3;
			base.Elements["/O"] = pdfString;
			base.Elements["/U"] = pdfString2;
			base.Elements["/P"] = pdfInteger4;
		}

		// Token: 0x06000CAE RID: 3246 RVA: 0x00033E48 File Offset: 0x00032048
		internal override void WriteObject(PdfWriter writer)
		{
			PdfStandardSecurityHandler securityHandler = writer.SecurityHandler;
			writer.SecurityHandler = null;
			base.WriteObject(writer);
			writer.SecurityHandler = securityHandler;
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x00033E71 File Offset: 0x00032071
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfStandardSecurityHandler.Keys.Meta;
			}
		}

		// Token: 0x040007C9 RID: 1993
		internal string _userPassword;

		// Token: 0x040007CA RID: 1994
		internal string _ownerPassword;

		// Token: 0x040007CB RID: 1995
		private static readonly byte[] PasswordPadding = new byte[]
		{
			40, 191, 78, 94, 78, 117, 138, 65, 100, 0,
			78, 86, byte.MaxValue, 250, 1, 8, 46, 46, 0, 182,
			208, 104, 62, 128, 47, 12, 169, 254, 100, 83,
			105, 122
		};

		// Token: 0x040007CC RID: 1996
		private byte[] _encryptionKey;

		// Token: 0x040007CD RID: 1997
		private readonly MD5 _md5 = new MD5CryptoServiceProvider();

		// Token: 0x040007CE RID: 1998
		private readonly byte[] _state = new byte[256];

		// Token: 0x040007CF RID: 1999
		private byte[] _ownerKey = new byte[32];

		// Token: 0x040007D0 RID: 2000
		private readonly byte[] _userKey = new byte[32];

		// Token: 0x040007D1 RID: 2001
		private byte[] _key;

		// Token: 0x040007D2 RID: 2002
		private int _keySize;

		// Token: 0x02000180 RID: 384
		internal new sealed class Keys : PdfSecurityHandler.Keys
		{
			// Token: 0x17000452 RID: 1106
			// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x00033EB1 File Offset: 0x000320B1
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfStandardSecurityHandler.Keys._meta) == null)
					{
						dictionaryMeta = (PdfStandardSecurityHandler.Keys._meta = KeysBase.CreateMeta(typeof(PdfStandardSecurityHandler.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040007D3 RID: 2003
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string R = "/R";

			// Token: 0x040007D4 RID: 2004
			[KeyInfo(KeyType.String | KeyType.Required)]
			public const string O = "/O";

			// Token: 0x040007D5 RID: 2005
			[KeyInfo(KeyType.String | KeyType.Required)]
			public const string U = "/U";

			// Token: 0x040007D6 RID: 2006
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string P = "/P";

			// Token: 0x040007D7 RID: 2007
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string EncryptMetadata = "/EncryptMetadata";

			// Token: 0x040007D8 RID: 2008
			private static DictionaryMeta _meta;
		}
	}
}
