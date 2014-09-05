using System;
using System.Data.SqlClient;
using System.Data;
using Stoke.DAL;
using Stoke.BLL;

namespace Stoke.BLL
{
	/// <summary>
	/// Department ��ժҪ˵����
	/// </summary>
	public class Department
	{
		public Department()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		#region ˽�б���	
		private int bm_bh;
		private string bm_mc;
		private string bm_js;
		private string bm_xmz;
		private string bm_jc;
		private string bm_kgmlh;
		#endregion

		#region ��������
		public int Bm_bh    /// ����ID
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

		public string Bm_mc   /// ������
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

		public string Bm_js 		/// ���Ž���
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

		public string Bm_xmz		/// �Ƿ���Ŀ��
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

		public string Bm_jc		/// ���ż��
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

		public string Bm_kgmlh 		/// ���������
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

		#region ���÷���
		public static DataTable GetAll()
		{			
			//�洢������
			string spName = "p_Department_GetAll" ;  
			//ִ�д洢���̣�������DataTable
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
