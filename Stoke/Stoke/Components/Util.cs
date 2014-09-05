using System;
using System.IO;
using System.Web;

namespace FileToMSSQL
{
	/// <summary>
	///
	/// </summary>
	public class Util
	{
		public Util()
		{
		}

		public static string GetFileDirecotry()
		{
			string dir = HttpContext.Current.Request.PhysicalApplicationPath;
			dir = Path.Combine(dir,"Upload");
			if(!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
			return dir;
		}

		public static string EncryptFilename(string filename)
		{
			byte[] buffer = HttpContext.Current.Request.ContentEncoding.GetBytes(filename);
			return HttpUtility.UrlEncode(Convert.ToBase64String(buffer));
		}

		public static string DecryptFilename(string encryptfilename)
		{
			byte[] buffer = Convert.FromBase64String(encryptfilename);
			return HttpContext.Current.Request.ContentEncoding.GetString(buffer);
		}

	}
}
