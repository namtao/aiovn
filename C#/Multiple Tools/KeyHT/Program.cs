using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KeyHT
{
    class Program
    {
		static void Main(string[] args)
		{
			/*//4ea05682bd342558cc2a402d18720baf
			ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
			byte[] bytes = aSCIIEncoding.GetBytes("PX-256M8VC");
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
			byte[] array2 = array;
			checked
			{
				string text = "";
				for (int i = 0; i < array2.Length; i++)
				{
					byte b = array2[i];
					text += b.ToString("x2");
				}
				Console.WriteLine(text);
			}*/

			var p = new Program();
			p.checkLicense("");
			//Console.WriteLine(GetHardDisk());
			Console.ReadKey();
		}

		public static string GetHardDisk()
		{
			string sMBsernumb = null;
			object oWMG = RuntimeHelpers.GetObjectValue(Interaction.GetObject("WinMgmts:", null));
			object oMotherB = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(oWMG, null, "InstancesOf", new object[]
			{
				"Win32_BaseBoard"
			}, null, null, null));
			try
			{
				IEnumerator enumerator = ((IEnumerable)oMotherB).GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = RuntimeHelpers.GetObjectValue(enumerator.Current);
					sMBsernumb = Conversions.ToString(Operators.AddObject(sMBsernumb, NewLateBinding.LateGet(obj, null, "SerialNumber", new object[0], null, null, null)));
				}
			}
			finally
			{
				IEnumerator enumerator = null;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			return sMBsernumb;
		}

		public bool checkLicense(string Key)
		{
			string str = "31534137394a5a30303436343537202020202020";
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
			bool result;
			try
			{
				ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator();
				while (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					string str2 = managementObject["Model"].ToString().Trim();
					Console.WriteLine(this.MD5(str2 + str));
					bool flag = Operators.CompareString(Key, this.MD5(str2 + str), false) == 0;
					if (flag)
					{
						result = true;
						return result;
					}
				}
			}
			catch
			{
				
			}
			result = false;
			return result;
		}

		private void EncodeHardDisk()
		{
			ManagementObjectSearcher Searcher_P = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
			try
			{
				ManagementObjectCollection.ManagementObjectEnumerator enumerator = Searcher_P.Get().GetEnumerator();
				while (enumerator.MoveNext())
				{
					ManagementObject queryObj = (ManagementObject)enumerator.Current;
					Console.WriteLine("Model hard disk: " + queryObj["Model"].ToString().Trim());
					Console.WriteLine("Model hard disk Encoding: " + this.MD5(queryObj["Model"].ToString().Trim() + "31534137394a5a30303436343537202020202020"));
				}
			}
			finally
			{
				ManagementObjectCollection.ManagementObjectEnumerator enumerator = null;
				if (enumerator != null)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		public string MD5(string chuoi_nguon)
		{
			ASCIIEncoding ASCIIenc = new ASCIIEncoding();
			byte[] ByteSourceText = ASCIIenc.GetBytes(chuoi_nguon);
			MD5CryptoServiceProvider Md5Hash = new MD5CryptoServiceProvider();
			byte[] ByteHash = Md5Hash.ComputeHash(ByteSourceText);
			byte[] array = ByteHash;
			checked
			{
				string strReturn = "";
				for (int i = 0; i < array.Length; i++)
				{
					byte b = array[i];
					strReturn += b.ToString("x2");
				}
				return strReturn;
			}
		}
	}
}
