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
		//����   ���ݿ������ִ���ֻ��
		//
		//��web.config�ļ���ȡ���ݿ������ִ�
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
		//����    ϵͳ�����ļ�·����ֻ��
		//
		//��·���̶�
		//
		//***********************************************************************

		/// <summary>
		/// ϵͳ�����ļ�·����ֻ��
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
