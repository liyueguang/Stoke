using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Configuration;
using Stoke.Model.zhxxgl;
using Stoke.DAL;

namespace Stoke.Components
{
    /// <summary>
    /// zhxxgl 的摘要说明。
    /// </summary>
    /// 
    public class zhxx
    {
        #region 存储过程
        private const string SQL_Get_GGL_XX_All = "sp_Zhxx_Ggl_GetAll";//得到所有公告栏的信息
        private const string SQL_Get_GGL_XXFB_All = "sp_zhxx_ggl_xxfb";//得到所有公告栏的信息
        private const string SQL_Get_GGL_XXFB_Allbyid = "sp_zhxx_xxfbbyid";//
        private const string SQL_Get_GGL_XXFB_All_BM = "sp_zhxx_ggl_xxfb_bm";//根据部门得到公告信息
        private const string SQL_GET_ZHXX_LB = "sp_Zhxx_Xxlb_All";//返回综合信息类别的存储过程
        private const string SQL_GET_ZHXX_Ggl_Xxxx = "sp_Zhxx_Ggl_Xxxx";
        private const string SQL_INSERT_XX_INFO = "sp_Zhxx_Xxyd_Insert_Info";
        private const string SQL_UPDATE_GGL_XX = "sp_Zhxx_Xxyd_Update_Info";
        private const string SQL_DELETE_GGL_INFO = "sp_Zhxx_Xxyd_Delete_Info";
        private const string SQL_SELECT_GGL_XX_ALL = "sp_Zhxx_Ggl_Selete_All";//根据条件查询公告栏信息
        private const string SQL_SELECT_XXFB_XX_ALL = "sp_Zhxxgl_fbxx_select";
        private const string SQL_GET_CYLJ_ALL = "sp_get_cylj_all";//显示所有链接
        private const string SQL_INSERT_LJ = "p_insert_lj";//添加新链接
        private const string SQL_GET_HL_LJ = "sp_get_hllj";
        #endregion
        public SqlDataReader GetLb()
        {
            SqlDataReader dr = null;
            try
            {
                dr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.StoredProcedure,
                    SQL_GET_ZHXX_LB);

            }
            catch (Exception e)
            {
                Console.WriteLine("zhxx.GetLb()" + e.Message);
                return null;
            }
            return dr;
        }
        public DataTable GetLJ()
        {
            DataTable dt = null;
            try
            {
                dt = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure,
                    SQL_GET_CYLJ_ALL);

            }
            catch (Exception e)
            {
                Console.WriteLine("zhxx.GetLJ()" + e.Message);
                return null;
            }
            return dt;
        }
        public DataTable GetHLLJ()
        {
            DataTable dt = null;
            try
            {
                dt = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure,
                    SQL_GET_HL_LJ);

            }
            catch (Exception e)
            {
                Console.WriteLine("zhxx.GetHLLJ()" + e.Message);
                return null;
            }
            return dt;
        }
        public bool InsertLJ(string ljname, string ljaddress)//添加新链接
        {
            bool flag = false;
            SqlParameter[] parameters = GetInsertLJParameters();
            parameters[0].Value = ljname;
            parameters[1].Value = ljaddress;

            //创建数据库连接
            try
            {
                SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, SQL_INSERT_LJ, parameters);
                flag = true;
            }
            catch (Exception e)
            {

                Console.WriteLine("InsertLJ(string ljname,string ljaddress)" + e.Message);
                return false;
            }
            return flag;
        }
        public SqlParameter[] GetInsertLJParameters()//获取参数
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters(SQL_INSERT_LJ);
            if (parameters == null)
            {
                parameters = new SqlParameter[]{
												   new SqlParameter("@lj",SqlDbType.VarChar,50),
												   new SqlParameter("@ljdz",SqlDbType.VarChar,50)

				};
                SQLHelper.CacheParameters(SQL_INSERT_LJ, parameters);
            }
            return parameters;
        }
        public DataTable GetGglXxAll()
        {
            DataTable table = null;
            try
            {
                table = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure,
                    SQL_Get_GGL_XX_All);
            }
            catch (Exception e)
            {
                Console.WriteLine("zhxx.GetGglXxAll()" + e.Message);
                return null;
            }
            return table;
        }
        public DataTable GetGglFbxx()
        {
            DataTable table = null;

            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure,
                        SQL_Get_GGL_XXFB_All, null);
                }
                catch (Exception e)
                {
                    Console.WriteLine("zhxx.GetGglXxAll()" + e.Message);
                    return null;
                }
            }
            return table;
        }

        public DataTable GetGglFbxx_bybm(string lb)
        {
            DataTable table = null;
            SqlParameter[] para = new SqlParameter[] {  new SqlParameter("@lb",SqlDbType.VarChar),
																	 
						};

            para[0].Value = lb;
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure,
                        SQL_Get_GGL_XXFB_All_BM, para);
                }
                catch (Exception e)
                {
                    Console.WriteLine("zhxx.GetGglXxAll()" + e.Message);
                    return null;
                }
            }
            return table;
        }


        public DataTable GetGglFbxxbyid(int id)
        {
            DataTable table = null;

            SqlParameter[] para = new SqlParameter[] {  new SqlParameter("@id",SqlDbType.Int),
			};
            para[0].Value = id;


            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure,
                        SQL_Get_GGL_XXFB_Allbyid, null);
                }
                catch (Exception e)
                {
                    Console.WriteLine("zhxx.GetGglXxAll()" + e.Message);
                    return null;
                }
            }
            return table;
        }






        public DataTable SelectGglXxAll(Ggl ggl, DateTime starttime, DateTime endtime)
        {
            DataTable table = null;
            SqlParameter[] para = new SqlParameter[] {   new SqlParameter("@lb",SqlDbType.VarChar),
														 new SqlParameter("@nr",SqlDbType.VarChar),
														 new SqlParameter("@starttime",SqlDbType.DateTime),
														 new SqlParameter("@endtime",SqlDbType.DateTime),
			};
            para[0].Value = ggl.Ggl_Xxlb;
            para[1].Value = ggl.Ggl_Xxnr;
            para[2].Value = starttime;
            para[3].Value = endtime;
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, SQL_SELECT_GGL_XX_ALL, para);

                }
                catch (Exception e)
                {
                    Console.WriteLine("zhxx.GetGglXxAll()" + e.Message);
                    return null;
                }
            }
            return table;
        }

        public DataTable Selectfb_XxAll(Stoke.Model.zhxxgl.Gggl gggl, DateTime starttime, DateTime endtime)
        {
            DataTable table = null;
            SqlParameter[] para = new SqlParameter[] {  new SqlParameter("@lb",SqlDbType.VarChar),
														 new SqlParameter("@nr",SqlDbType.VarChar),
														 new SqlParameter("@starttime",SqlDbType.DateTime),
				                                         new SqlParameter("@endtime",SqlDbType.DateTime),
														
			};
            para[0].Value = gggl.Xxfb_ssbm;
            para[1].Value = gggl.Xxfb_xxnr;
            para[2].Value = starttime;
            para[3].Value = endtime;
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    table = SQLHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, SQL_SELECT_XXFB_XX_ALL, para);

                }
                catch (Exception e)
                {
                    Console.WriteLine("zhxx.GetGglXxAll()" + e.Message);
                    return null;
                }
            }
            return table;
        }




        public Ggl GetXxnrAll(int id)
        {
            Ggl ggl = new Ggl();
            SqlDataReader dr = null;
            SqlParameter[] para = new SqlParameter[] {  new SqlParameter("@id",SqlDbType.Int),
													 };
            para[0].Value = id;
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                try
                {
                    conn.Open();
                    dr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.StoredProcedure,
                        SQL_GET_ZHXX_Ggl_Xxxx, para);
                    if (dr.Read())
                    {
                        ggl.Ggl_Xxlb = dr["Zhxx_Ggl_Lb"].ToString();
                        ggl.Ggl_Fbsj = dr["Zhxx_Ggl_Fbsj"].ToString();
                        ggl.Ggl_Btm = dr["Zhxx_Ggl_Btm"].ToString();
                        ggl.Ggl_Xxnr = dr["Zhxx_Ggl_Xxnr"].ToString();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("zhxx.GetXxnrAll()" + e.Message);
                }
            }
            return ggl;
        }
        public bool InsertInfo(Ggl ggl)//添加新的发布信息
        {
            bool flag = false;
            SqlParameter[] parameters = GetInsertStudentParameters();
            parameters[0].Value = ggl.Ggl_Xxlb;
            parameters[1].Value = ggl.Ggl_Fbsj;
            parameters[2].Value = ggl.Ggl_Btm;
            parameters[3].Value = ggl.Ggl_Xxnr;

            //创建数据库连接
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                //打开数据库连接
                conn.Open();
                try
                {
                    SQLHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SQL_INSERT_XX_INFO, parameters);
                    flag = true;
                }
                catch (Exception e)
                {

                    Console.WriteLine("zhxx.InsertInfo(Ggl ggl)" + e.Message);
                    return false;
                }
            }
            return flag;
        }
        public SqlParameter[] GetInsertStudentParameters()//获取参数
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters(SQL_INSERT_XX_INFO);
            if (parameters == null)
            {
                parameters = new SqlParameter[]{
												   new SqlParameter("@lb",SqlDbType.VarChar,50),
												   new SqlParameter("@fbsj",SqlDbType.DateTime),
												   new SqlParameter("@btm",SqlDbType.VarChar,50),
												   new SqlParameter("@xxnr",SqlDbType.Text),

				};
                SQLHelper.CacheParameters(SQL_INSERT_XX_INFO, parameters);
            }
            return parameters;
        }
        public bool UpdateGglInfo(Ggl ggl)//修改发布信息
        {
            bool flag = false;
            SqlParameter[] parameters = GetUpdateParameters();
            parameters[0].Value = ggl.Ggl_Id;
            parameters[1].Value = ggl.Ggl_Btm;
            parameters[2].Value = ggl.Ggl_Fbsj;
            parameters[3].Value = ggl.Ggl_Xxlb;
            parameters[4].Value = ggl.Ggl_Xxnr;

            //创建数据库连接
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                //打开数据库连接
                conn.Open();
                try
                {
                    SQLHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SQL_UPDATE_GGL_XX, parameters);
                    flag = true;
                }
                catch (SqlException e)
                {

                    Console.WriteLine("zhxxgl.UpdateGglInfo(zhxxgl ggl)" + e.Message);
                    return false;
                }
            }
            return flag;
        }
        public SqlParameter[] GetUpdateParameters()
        {
            SqlParameter[] parameters = SQLHelper.GetCachedParameters(SQL_UPDATE_GGL_XX);
            if (parameters == null)
            {
                parameters = new SqlParameter[]{
												   new SqlParameter("@id",SqlDbType.Int),
												   new SqlParameter("@btm",SqlDbType.VarChar,50),
												   new SqlParameter("@fbsj",SqlDbType.DateTime),
												   new SqlParameter("@xxlb",SqlDbType.VarChar),
												   new SqlParameter("@xxnr",SqlDbType.Text),
				};
                SQLHelper.CacheParameters(SQL_UPDATE_GGL_XX, parameters);
            }
            return parameters;
        }
        public bool DeleteGglInfo(int id)
        {
            bool flag = false;
            SqlParameter[] parameters = new SqlParameter[]{
															  new SqlParameter("@id",SqlDbType.Int)
														  };
            parameters[0].Value = id;
            //创建数据库连接
            using (SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING))
            {
                //打开数据库连接
                conn.Open();
                try
                {
                    SQLHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SQL_DELETE_GGL_INFO, parameters);
                    flag = true;
                }
                catch (Exception e)
                {

                    Console.WriteLine("zhxxgl.DeleteGglInfo(int id)" + e.Message);
                    return false;
                }
            }
            return flag;
        }

        public int Updateyzqh(string _bh, string _mc, string _dq)
        {
            int _i = -1;
            bool _b = false;
            object[] _ob = new object[] { _bh, _mc, _dq };
            try
            {
                _i = SQLHelper.ExecuteNonQuery("sp_yz_update_qh", _b, _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.UpdateKclJe(Gzkc newGz,float newKcl,float newJe)" + e.Message);
            }
            return _i;
        }

        public int Delete_qh(string _sf, string _xs)
        {
            int result = -1;
            string spName = "sp_yz_delete_qh";
            object[] para = new object[] { _sf, _xs };
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
            return result;

        }
        public int YZ_qh_Insert(string _sf, string _dq, string _qh)
        {
            int _i = -1;
            string _str = "sp_yz_insert_qh";
            bool _b = false;
            object[] _ob = new object[] { _sf, _dq, _qh };

            try
            {
                _i = SQLHelper.ExecuteNonQuery(_str, _b, _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("BgypDAL.BgypInsert()" + e.Message);
            }
            return _i;
        }

        public int YZ_yb_Insert(string _sf, string _dq, string _yb)
        {
            int _i = -1;
            string _str = "sp_yz_insert_yb";
            bool _b = false;
            object[] _ob = new object[] { _sf, _dq, _yb };
            try
            {
                _i = SQLHelper.ExecuteNonQuery(_str, _b, _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("BgypDAL.BgypInsert()" + e.Message);
            }
            return _i;
        }
        public int Updateyzyb(string _bh, string _mc, string _dq)
        {
            int _i = -1;
            bool _b = false;
            object[] _ob = new object[] { _bh, _mc, _dq };
            try
            {
                _i = SQLHelper.ExecuteNonQuery("sp_yz_update_yb", _b, _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.UpdateKclJe(Gzkc newGz,float newKcl,float newJe)" + e.Message);
            }
            return _i;
        }

        public int Delete_yb(string _sf, string _xs)
        {
            int result = -1;
            string spName = "sp_yz_delete_yb";
            object[] para = new object[] { _sf, _xs };
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
            return result;

        }


        public int Delete_cylj(string _ljmc)
        {
            int result = -1;
            string spName = "sp_zhxx_delete_lj";
            object[] para = new object[] { _ljmc };
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
            return result;

        }
        public int Update_cylj(int _bh, string _mc, string _dz)
        {
            int _i = -1;
            bool _b = false;
            object[] _ob = new object[] { _bh, _mc, _dz };
            try
            {
                _i = SQLHelper.ExecuteNonQuery("sp_zhxx_update_cylj", _b, _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.UpdateKclJe(Gzkc newGz,float newKcl,float newJe)" + e.Message);
            }
            return _i;
        }
        public DataTable Get_ggl_bm(string _bh)
        {
            DataTable table = null;
            object[] _ob = new object[] { _bh };
            try
            {
                table = SQLHelper.ExecuteDataTable("sp_zhxx_ggl_xxfb_bm", _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.GetGzckByZdbh(int _zdbh)" + e.Message);
            }
            return table;
        }
        public DataTable Get_ggl_xs(string _bh)//2009/06/06 wy
        {
            DataTable table = null;
            object[] _ob = new object[] { _bh };
            try
            {
                table = SQLHelper.ExecuteDataTable("sp_zhxx_ggl_xxfb_xs", _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.GetGzckByZdbh(int _zdbh)" + e.Message);
            }
            return table;
        }
        public DataTable Get_ggl_bm_cz(string _bm, string _bm1, string _bm2, string nr)
        {
            DataTable table = null;
            object[] _ob = new object[] { _bm, _bm1, _bm2, nr };
            try
            {
                table = SQLHelper.ExecuteDataTable("sp_zhxx_ggl_xxfb_bm_cz", _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.GetGzckByZdbh(int _zdbh)" + e.Message);
            }
            return table;
        }

        public DataTable Get_ggl_bm_cx_condition(string _bm, string _bm1, string _bm2, DateTime dt1, DateTime dt2, string nr)
        {
            DataTable table = null;
            object[] _ob = new object[] { _bm, _bm1, _bm2, dt1, dt2, nr };
            try
            {
                table = SQLHelper.ExecuteDataTable("sp_Zxxx_Select_By_Condition", _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.GetGzckByZdbh(int _zdbh)" + e.Message);
            }
            return table;
        }

        public static DataTable Select_zhxx_yj_DocID(int DocID)//20090606 wy
        {

            //存储过程名
            string spName = "sp_Flow_Get_zhxx_yj_DocID";
            //存储过程参数
            object[] para = new object[] { DocID };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public DataTable Get_ggl_xx_top(string _bh) //2009/06/19 wy
        {
            DataTable table = null;
            object[] _ob = new object[] { _bh };
            try
            {
                table = SQLHelper.ExecuteDataTable("sp_zhxx_ggl_xx_top", _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.GetGzckByZdbh(int _zdbh)" + e.Message);
            }
            return table;
        }

    }
}
