using System;
using System.Data.SqlClient;
using System.Data;
using Stoke.DAL;
using Stoke.BLL;


namespace Stoke.BLL
{
	/// <summary>
	/// Staff 的摘要说明。
	/// </summary>
	public class Staff
	{
		public Staff()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 私有变量	
		private int ry_id;
		private string ry_zgbh;
		private string ry_xm;
		private string ry_bm;
		private string ry_zw;
		#endregion

		#region 公用属性

		public int Ry_id    
		{
			get 
			{
				return ry_id ;
			}
			set 
			{ 
				ry_id = value ;
			}
		}

		public string Ry_zgbh    
		{
			get 
			{
				return ry_zgbh ;
			}
			set 
			{ 
				ry_zgbh = value ;
			}
		}

		public string Ry_xm 
		{
			get 
			{
				return ry_xm ;
			}
			set 
			{ 
				ry_xm = value ;
			}
		}

		public string Ry_bm 		
		{
			get 
			{
				return ry_bm ;
			}
			set 
			{ 
				ry_bm = value ;
			}
		}

		public string Ry_zw 		
		{
			get 
			{
				return ry_zw ;
			}
			set 
			{ 
				ry_zw = value ;
			}
		}
		#endregion

		#region 公用方法
		public static DataTable GetAll()
		{			
			//存储过程名
			string spName = "p_Staff_GetAll" ;  
			//执行存储过程，并返回DataTable
			return SQLHelper.ExecuteDataTable(spName) ;			
		}

		public static int InsertStaff(Staff _staff)
		{
			int result =-1;
			string spName = "p_insert_ry" ;  
			object[] para = new object[] {_staff.ry_zgbh,_staff.ry_xm,_staff.ry_bm,_staff.ry_zw} ;
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
			return result;
		}

		public static int UpdateRy(Staff _staff)
		{
			int result =-1;
			string spName = "p_update_ry" ;  
			object[] para = new object[] {_staff.ry_id,_staff.ry_zgbh,_staff.ry_xm,_staff.ry_bm,_staff.ry_zw} ;
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
			return result;
		}

		public static int DeleteRy(int id)
		{
			int result =-1;
			string spName = "p_delete_ry" ;  
			object[] para = new object[] {id} ;
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
			return result;

		}
		public static int DeleteRy1(string id)
		{
			int result =-1;
			string spName = "p_delete_ry1" ;  
			object[] para = new object[] {id} ;
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
			return result;

		}

		#endregion
	}
}
