using System;
using System.Data;
using System.Data.SqlClient;
using Stoke.DAL;

namespace Stoke.Components
{
    #region 工作流的函数
    /// <summary>
    /// DocumentFlow 的摘要说明。
    /// </summary>
    public class DocumentFlow
    {

        //////////////////////////////////////////
        ///				公文流转
        //////////////////////////////////////////

        #region 添加文档
        /// <summary>
        /// 添加文档
        /// </summary>
        /// <param name="UserName">拟稿人</param>
        /// <param name="FlowID">所用流程ID</param>
        /// <param name="SQL">样式表数据的SQL语句</param>
        public int AddDocument(string UserName, long FlowID, string SQL, string Title)
        {
            return SQLHelper.ExecuteNonQuery(new SqlParameter("@ReturnValue", ""), SQLHelper.CONN_STRING, CommandType.StoredProcedure, "sp_Flow_AddDocument",
                new SqlParameter("@DocBuilder", UserName),
                new SqlParameter("@FlowID", FlowID),
                new SqlParameter("@SQL", SQL),
                new SqlParameter("@Title", Title));
        }
        #endregion


        #region 修改文档
        /// <summary>
        /// 修改文档
        /// </summary>
        /// <param name="UpdateSQL">更新文档语句</param>
        public int UpdateDocument(string UpdateSQL)
        {
            string cmdText = "sp_Flow_UpdateDocument";
            return SQLHelper.ExecuteNonQuery(new SqlParameter("@ReturnValue", ""), SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@SQL", UpdateSQL));
        }
        #endregion	

        #region 删除文档
        /// <summary>
        /// 删除文档
        /// </summary>
        /// <param name="DocID">被删除的文档ID</param>
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
