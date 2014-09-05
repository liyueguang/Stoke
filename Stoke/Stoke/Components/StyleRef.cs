using System;
using System.Data;
using System.Data.SqlClient;
using Stoke.DAL;

namespace Stoke.Components
{
	/// <summary>
	/// Ycsq 的摘要说明。
	/// </summary>
	public class StyleRef
	{
		public StyleRef()
		{
		}
		public static DataTable Select_Field_by_Step(int flow_id, int step_id)
		{
            string cmdText = "sp_Flow_Select_Field_By_Step";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@flow_id", flow_id),
                new SqlParameter("@step_id", step_id));
		}

		public static DataTable Select_Data_by_DocID(int DocID)
		{
            string cmdText = "sp_Flow_Get_Data_By_DocID";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@Doc_ID", DocID));
		}

		public static DataTable Select_Description_DocID(int DocID)
		{
            string cmdText = "sp_Description_Data_By_DocID";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@Doc_ID", DocID));
		}
		public static DataTable Select_Gwyj_DocID(int DocID)
		{
            string cmdText = "sp_Flow_Get_Gwyj_DocID";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@Doc_id", DocID));
		}

		public static DataTable Select_Qsyj_DocID(int DocID)
		{
            string cmdText = "sp_Flow_Get_Qsyj_DocID";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@Doc_id", DocID));
		}
	}
}
