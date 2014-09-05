using System;
using System.Data;
using System.Data.SqlClient;
using Stoke.DAL;

namespace Stoke.Components
{
    #region �������ĺ���
    /// <summary>
    /// DocumentFlow ��ժҪ˵����
    /// </summary>
    public class DocumentFlow
    {

        //////////////////////////////////////////
        ///				������ת
        //////////////////////////////////////////

        #region ����ĵ�
        /// <summary>
        /// ����ĵ�
        /// </summary>
        /// <param name="UserName">�����</param>
        /// <param name="FlowID">��������ID</param>
        /// <param name="SQL">��ʽ�����ݵ�SQL���</param>
        public int AddDocument(string UserName, long FlowID, string SQL, string Title)
        {
            return SQLHelper.ExecuteNonQuery(new SqlParameter("@ReturnValue", ""), SQLHelper.CONN_STRING, CommandType.StoredProcedure, "sp_Flow_AddDocument",
                new SqlParameter("@DocBuilder", UserName),
                new SqlParameter("@FlowID", FlowID),
                new SqlParameter("@SQL", SQL),
                new SqlParameter("@Title", Title));
        }
        #endregion


        #region �޸��ĵ�
        /// <summary>
        /// �޸��ĵ�
        /// </summary>
        /// <param name="UpdateSQL">�����ĵ����</param>
        public int UpdateDocument(string UpdateSQL)
        {
            string cmdText = "sp_Flow_UpdateDocument";
            return SQLHelper.ExecuteNonQuery(new SqlParameter("@ReturnValue", ""), SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@SQL", UpdateSQL));
        }
        #endregion	

        #region ɾ���ĵ�
        /// <summary>
        /// ɾ���ĵ�
        /// </summary>
        /// <param name="DocID">��ɾ�����ĵ�ID</param>
        public int DeleteDocument(long DocID)
        {
            int iReturn = -1;
            SqlParameter[] parameters = {
											SQLHelper.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
            try
            {
                iReturn = SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, "sp_Flow_DeleteDocument", parameters);
            }
            catch (Exception e)
            {
                Stoke.Components.Error.Log(e.ToString());
            }
            return iReturn;

        }
        #endregion



    }
    #endregion

}
