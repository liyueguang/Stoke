using System;
using System.Data.SqlClient;
using System.Data;
using Stoke.DAL;
using Stoke.BLL;

namespace Stoke.BLL
{
	/// <summary>
	/// Place ��ժҪ˵����
	/// </summary>
	public class Place
	{
		public Place()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		#region ˽�б���	
		private int zw_bh;
		private string zw_mc;
		private string zw_js;
		#endregion

		#region ��������
		public int Zw_bh    
		{
			get 
			{
				return zw_bh ;
			}
			set 
			{ 
				zw_bh = value ;
			}
		}

		public string Zw_mc  
		{
			get 
			{
				return zw_mc ;
			}
			set 
			{ 
				zw_mc = value ;
			}
		}

		public string Zw_js 		
		{
			get 
			{
				return zw_js ;
			}
			set 
			{ 
				zw_js = value ;
			}
		}
		#endregion

		#region ���÷���
		public static DataTable GetAll()
		{			
			//�洢������
			string spName = "p_Place_GetAll" ;  
			//ִ�д洢���̣�������DataTable
			return SQLHelper.ExecuteDataTable(spName) ;			
		}

		public static int InsertZw(Place _place)
		{
			int result =-1;
			string spName = "p_insert_zw" ;  
			object[] para = new object[] {_place.Zw_mc,_place.Zw_js} ;
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
			return result;
		}

		public static int UpdateZw(Place _place)
		{
			int result =-1;
			string spName = "p_update_zw" ;  
			object[] para = new object[] {_place.Zw_bh,_place.Zw_mc,_place.Zw_js} ;
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
			return result;
		}

		public static int DeleteZw(int id)
		{
			int result =-1;
			string spName = "p_delete_zw" ;  
			object[] para = new object[] {id} ;
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
			return result;

		}
		#endregion
	}
}
