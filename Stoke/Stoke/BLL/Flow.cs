using System;
using System.Data.SqlClient;
using System.Data;
using Stoke.DAL;
using Stoke.BLL;

namespace Stoke.BLL
{
    /// <summary>
    /// Flow ��ժҪ˵����
    /// </summary>
    public class Flow
    {
        public Flow()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        #region ���÷���
        public static DataTable Getwork(int _flow, string _czz)
        {
            DataTable dt = null;
            //�洢������
            string spName1 = "p_qwsq_getwork";
            string spName2 = "p_qgsq_getwork";
            string spName3 = "p_xmz_getwork";
            SqlParameter para = new SqlParameter("@czz", _czz);
            if (_flow == 1)
                dt = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName1, para);
            else if (_flow == 2)
                dt = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName2, para);
            else if (_flow == 3)
                dt = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName3, para);
            return dt;
        }

        public static DataTable Getwork_ck(int _flow, string _zgbh, string _xm)
        {
            DataTable dt = null;
            //�洢������
            string spName1 = "p_qwsq_getwork_ck";
            string spName2 = "p_qgsq_getwork_ck";
            string spName3 = "p_xmz_getwork_ck";
            //ִ�д洢���̣�������DataTable
            SqlParameter para1 = new SqlParameter("@_zgbh", _zgbh);
            SqlParameter para2 = new SqlParameter("@_xm", _xm);
            if (_flow == 1)
                dt = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName1, para1, para2);
            else if (_flow == 2)
                dt = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName2, para1, para2);
            else if (_flow == 3)
                dt = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName3, para1, para2);
            return dt;
        }

        public static DataTable Getwork_ck2(int _flow, string _zgbh, string _xm)
        {
            DataTable dt = null;
            //�洢������
            string spName1 = "p_qwsq_getwork_ck2";
            string spName2 = "p_qgsq_getwork_ck2";
            string spName3 = "p_xmz_getwork_ck2";
            //ִ�д洢���̣�������DataTable
            SqlParameter para1 = new SqlParameter("@_zgbh", _zgbh);
            SqlParameter para2 = new SqlParameter("@_xm", _xm);
            if (_flow == 1)
                dt = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName1, para1, para2);
            else if (_flow == 2)
                dt = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName2, para1, para2);
            else if (_flow == 3)
                dt = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName3, para1, para2);
            return dt;
        }

        public static DataTable GetFlow(int _flag)
        {
            //�洢������
            string spName = "p_flow_getflow";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName, new SqlParameter("@flag", _flag));
        }

        public static DataTable Get_Work(int _flag, string _zgbh)
        {
            //�洢������
            string spName = "p_flow_getwork";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName,
                new SqlParameter("@flag", _flag), new SqlParameter("@zgbh", _zgbh));
        }
        #endregion
    }
}
