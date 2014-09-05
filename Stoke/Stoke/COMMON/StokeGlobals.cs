using System;
using System.Configuration;
using System.Collections.Specialized ;
using System.Web;
using System.Collections; 
using System.Data;
using System.IO;
using System.Threading;
using System.Web.SessionState;

namespace Stoke.COMMON
{
	/// <summary>
	/// </summary>
	public class StokeGlobals
	{
		//***********************************************************************
		//
		//属性   数据库连接字串，只读
		//
		//从web.config文件获取数据库连接字串
		//
		//***********************************************************************
		public static string Connectiondsoc
		{
			get 
			{
				NameValueCollection nvc = (NameValueCollection)
					ConfigurationSettings.GetConfig("appSettings");
				return nvc[ "connectiondsoc" ];
			} 
		}

		public static string Connectionerpoa
		{
			get 
			{
				NameValueCollection nvc = (NameValueCollection)
					ConfigurationSettings.GetConfig("appSettings");
				return nvc[ "connectionerpoa" ];
			} 
		}

		public static string Connectioncwbase
		{
			get 
			{
				NameValueCollection nvc = (NameValueCollection)
					ConfigurationSettings.GetConfig("appSettings");
				return nvc[ "connectioncwbase" ];
			} 
		}

		
		//***********************************************************************
		//
		//属性    系统配置文件路径，只读
		//
		//该路径固定
		//
		//***********************************************************************

		/// <summary>
		/// 系统配置文件路径，只读
		/// </summary>
		public static string ConfigFilePath
		{
			get 
			{
				string configpath = "COMMON\\Configs\\" ;
				string path = HttpRuntime.AppDomainAppPath ;
				return path + configpath ;	
			} 
		}

        public static Hashtable ProcessingResults = new Hashtable();

	}
}
