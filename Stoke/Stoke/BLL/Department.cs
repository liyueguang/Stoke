using System;
using System.Data.SqlClient;
using System.Data;
using Stoke.DAL;
using Stoke.BLL;

namespace Stoke.BLL
{
	/// <summary>
	/// Department 的摘要说明。
	/// </summary>
	public class Department
	{
		public Department()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 私有变量	
		private int bm_bh;
		private string bm_mc;
		private string bm_js;
		private string bm_xmz;
		private string bm_jc;
		private string bm_kgmlh;
		#endregion

		#region 公用属性
		public int Bm_bh    /// 部门ID
		{
			get 
			{
				return bm_bh ;
			}
			set 
			{ 
				bm_bh = value ;
			}
		}

		public string Bm_mc   /// 部门名
		{
			get 
			{
				return bm_mc ;
			}
			set 
			{ 
				bm_mc = value ;
			}
		}

		public string Bm_js 		/// 部门介绍
		{
			get 
			{
				return bm_js ;
			}
			set 
			{ 
				bm_js = value ;
			}
		}

		public string Bm_xmz		/// 是否项目组
		{
			get 
			{
				return bm_xmz ;
			}
			set 
			{ 
				bm_xmz = value ;
			}
		}

		public string Bm_jc		/// 部门简称
		{
			get 
			{
				return bm_jc ;
			}
			set 
			{ 
				bm_jc = value ;
			}
		}

		public string Bm_kgmlh 		/// 开工命令号
		{
			get 
			{
				return bm_kgmlh ;
			}
			set 
			{ 
				bm_kgmlh = value ;
			}
		}
		#endregion

		#region 公用方法
		public static DataTable GetAll()
		{			
			//存储过程名
			string spName = "p_Department_GetAll" ;  
			//执行存储过程，并返回DataTable
			return SQLHelper.ExecuteDataTable(spName) ;			
		}

		public static int InsertBm(Department _dpt)
		{
			int result =-1;
			string spName = "p_insert_bm" ;  
			object[] para = new object[] {_dpt.Bm_mc,_dpt.Bm_js,_dpt.Bm_xmz,_dpt.Bm_jc,_dpt.Bm_kgmlh} ;
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
			return result;
		}

		public static int UpdateBm(Department _dpt)
		{
			int result =-1;
			string spName = "p_update_bm" ;  
			object[] para = new object[] {_dpt.Bm_bh,_dpt.Bm_mc,_dpt.Bm_js,_dpt.Bm_xmz,_dpt.Bm_jc,_dpt.Bm_kgmlh} ;
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
			return result;
		}

		public static int DeleteBm(int id)
		{
			int result =-1;
			string spName = "p_delete_bm" ;  
			object[] para = new object[] {id} ;
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
			return result;

		}
		#endregion
	}
}
