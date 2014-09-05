using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Configuration;
using Stoke.DAL;

namespace Stoke.Components
{
    /// <summary>
    /// Staff 管理类
    /// </summary>
    public class Staff
    {

        #region 获取用户基本信息
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="StaffID">用户ID</param>
        /// <returns>返回DataReader</returns>
        public SqlDataReader GetStaffInfo(string StaffID)
        {
            SqlDataReader dataReader = null;
            try
            {
                string cmdText = "sp_Rs_GetStaffInfo";
                return SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                    new SqlParameter("@StaffID", StaffID));
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("人员信息读取出错!", ex);
            }

        }
        #endregion

        #region 人员更新
        /// <summary>
        /// 人员更新
        /// </summary>
        /// <param name="StaffID">人员ID</param>
        /// <returns>返回是否成功</returns>
        public int UpdateInfo(string StaffID, string RealName, string pylx, int Sex, string Email, string Phone, string Mobile, string Birthday, int Age, string ywm, string cym, string shi, string gwbdsj, string sfzh, string mz, string jg, string hkszd, string zzmm, string rdpsj, string jkqk, string hyzk, string cjgzsj, string jbdwsj, string zc, string zcjb, string zcrdsj, string htqssj, string htzzsj, string zgxl, string bysj, string byxx, string sxzy, string xxxs, string wyyz, string wysp, string jsjsp, string zzrzmc, string bdwcjpxmc, string pxxyyxsj, string jtzz, string yb, string jjlxrxm, string jjlxrdh, string bz, string dbrsfzh, string rylb, string htlb, string zylb, string lzyy, string lzsj, string oldZgbh)
        {
            SqlParameter[] prams = {
									   SQLHelper.MakeInParam("@zgbh",SqlDbType.VarChar,10,StaffID),
									   SQLHelper.MakeInParam("@RealName",SqlDbType.VarChar,50,RealName),
									   SQLHelper.MakeInParam("@pylx",SqlDbType.VarChar,20,pylx),
									   SQLHelper.MakeInParam("@Sex",SqlDbType.Int,4,Sex),
									   SQLHelper.MakeInParam("@Email",SqlDbType.VarChar,50,Email),
									   SQLHelper.MakeInParam("@Phone",SqlDbType.VarChar,50,Phone),						
									   SQLHelper.MakeInParam("@Mobile",SqlDbType.VarChar,50,Mobile),																					   
									   SQLHelper.MakeInParam("@Birthday",SqlDbType.DateTime ,8,Birthday),
									   SQLHelper.MakeInParam("@Age",SqlDbType.Int,4,Age),
									   SQLHelper.MakeInParam("@ywm",SqlDbType.VarChar,50,ywm),									   
									   SQLHelper.MakeInParam("@cym",SqlDbType.VarChar,50,cym),	
									   SQLHelper.MakeInParam("@shi",SqlDbType.VarChar,50,shi),	
									   SQLHelper.MakeInParam("@gwbdsj",SqlDbType.DateTime,8,gwbdsj),
									   SQLHelper.MakeInParam("@sfzh",SqlDbType.VarChar,50,sfzh),
									   SQLHelper.MakeInParam("@mz",SqlDbType.VarChar,50,mz),
									   SQLHelper.MakeInParam("@jg",SqlDbType.VarChar,50,jg),
									   SQLHelper.MakeInParam("@hkszd",SqlDbType.VarChar,50,hkszd),
									   SQLHelper.MakeInParam("@zzmm",SqlDbType.VarChar,50,zzmm),
									   SQLHelper.MakeInParam("@rdpsj",SqlDbType.DateTime,8,rdpsj),
									   SQLHelper.MakeInParam("@jkqk",SqlDbType.VarChar,50,jkqk),
									   SQLHelper.MakeInParam("@hyzk",SqlDbType.VarChar,50,hyzk),
									   SQLHelper.MakeInParam("@cjgzsj",SqlDbType.DateTime,8,cjgzsj),
									   SQLHelper.MakeInParam("@jbdwsj",SqlDbType.DateTime,8,jbdwsj),
									   SQLHelper.MakeInParam("@zc",SqlDbType.VarChar,50,zc),
									   SQLHelper.MakeInParam("@zcjb",SqlDbType.VarChar,50,zcjb),
									   SQLHelper.MakeInParam("@zcrdsj",SqlDbType.DateTime,8,zcrdsj),
									   SQLHelper.MakeInParam("@htqssj",SqlDbType.DateTime,8,htqssj),
									   SQLHelper.MakeInParam("@htzzsj",SqlDbType.DateTime,8,htzzsj),
									   SQLHelper.MakeInParam("@zgxl",SqlDbType.VarChar,50,zgxl),
									   SQLHelper.MakeInParam("@bysj",SqlDbType.DateTime,8,bysj),
									   SQLHelper.MakeInParam("@byxx",SqlDbType.VarChar,50,byxx),
									   SQLHelper.MakeInParam("@sxzy",SqlDbType.VarChar,50,sxzy),
									   SQLHelper.MakeInParam("@xxxs",SqlDbType.VarChar,50,xxxs),
									   SQLHelper.MakeInParam("@wyyz",SqlDbType.VarChar,50,wyyz),
									   SQLHelper.MakeInParam("@wysp",SqlDbType.VarChar,50,wysp),										   
									   SQLHelper.MakeInParam("@jsjsp",SqlDbType.VarChar,50,jsjsp),
									   SQLHelper.MakeInParam("@zzrzmc",SqlDbType.VarChar,50,zzrzmc),
									   SQLHelper.MakeInParam("@bdwcjpxmc",SqlDbType.VarChar,50,bdwcjpxmc),
									   SQLHelper.MakeInParam("@pxxyyxsj",SqlDbType.VarChar,50,pxxyyxsj),
									   SQLHelper.MakeInParam("@jtzz",SqlDbType.VarChar,100,jtzz),
									   SQLHelper.MakeInParam("@yb",SqlDbType.VarChar,10,yb),
									   SQLHelper.MakeInParam("@jjlxrxm",SqlDbType.VarChar,50,jjlxrxm),
									   SQLHelper.MakeInParam("@jjlxrdh",SqlDbType.VarChar,50,jjlxrdh),
									   SQLHelper.MakeInParam("@bz",SqlDbType.VarChar,300,bz),
									   SQLHelper.MakeInParam("@dbrsfzh",SqlDbType.VarChar,50,dbrsfzh),
									   SQLHelper.MakeInParam("@rylb",SqlDbType.VarChar,50,rylb),
									   SQLHelper.MakeInParam("@htlb",SqlDbType.VarChar,50,htlb),
									   SQLHelper.MakeInParam("@zylb",SqlDbType.VarChar,50,zylb),
									   SQLHelper.MakeInParam("@lzyy",SqlDbType.VarChar,200,lzyy),
									   SQLHelper.MakeInParam("@lzsj",SqlDbType.VarChar,20,lzsj),
									   SQLHelper.MakeInParam("@oldZgbh", SqlDbType.VarChar, 10, oldZgbh)
								   };
            string cmdText = "sp_Rs_UpdateStaffInfo";
            return SQLHelper.ExecuteNonQuery(new SqlParameter("@ReturnValue", ""), SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText, prams);
        }


        /// <summary>
        /// 修改手机号
        /// </summary>
        /// <param name="StaffID">人员ID</param>
        /// <returns>返回是否成功</returns>
        public int UpdateMobile(string ry_zgbh, string Mobile)
        {
            string cmdText = "sp_Rs_Update_Mobile";
            SqlParameter[] prams = {
									   SQLHelper.MakeInParam("@ry_zgbh",SqlDbType.VarChar,10,ry_zgbh),					
									   SQLHelper.MakeInParam("@Mobile",SqlDbType.VarChar,50,Mobile)
								   };
            return SQLHelper.ExecuteNonQuery(new SqlParameter("@ReturnValue", ""), SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText, prams);
        }

        #endregion

        public DataTable GetXmBmZwByZdbh(string _zgbh)//通过人员编号活得人员姓名、部门、职务
        {
            DataTable table = null;
            try
            {
                string cmdText = "sp_Rs_GetXmBmZwbyZgbh";
                table = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                    new SqlParameter("@ry_zgbh", _zgbh));
            }
            catch (Exception e)
            {
                Console.WriteLine("Staff.GetXmBmByZdbh(int _zdbh)" + e.Message);
            }
            return table;
        }

        public DataTable GetControlByZgbh(string _zgbh, int flow_id, int step_id)
        {
            DataTable table = null;
            try
            {
                string cmdText = "sp_Rs_GetControlByZgbh";
                table = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                    new SqlParameter("@zgbh", _zgbh),
                    new SqlParameter("@flow_id", flow_id),
                    new SqlParameter("@step_id", step_id));
            }
            catch (Exception e)
            {
                Console.WriteLine("Staff.GetControlByZgbh(int _zdbh)" + e.Message);
            }
            return table;
        }

        //请假信息存档
        public static int InsertQjsp(string qjsp_zgbh, string qjsp_xm, string qjsp_bm, string qjsp_zw, string qjsp_cssj, string qjsp_gssj, string qjsp_qjlb, string qjsp_kssj, string qjsp_jssj,
        string qjsp_qjts, string qjsp_gzr, string qjsp_qjsy, string qjsp_dlr, string qjsp_qjrq, string qjsp_kqzrr, string qjsp_kqzrr_rq,
        string qjsp_bmfzr, string qjsp_bmfzr_rq, int qjsp_jhts, int qjsp_yxts, int qjsp_bcts, string qjsp_lxdh, string qjsp_qt, string qjsp_zhglbjbr, string qjsp_zhglbjbr_rq, string qjsp_gszgld, string qjsp_gszgld_rq, string qjsp_zjlsp, string qjsp_zjlsp_rq, int doc_id)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Qjsp";
            //存储过程参数
            SqlParameter[] parms = {
                new SqlParameter("@qjsp_zgbh", qjsp_zgbh),
                new SqlParameter("@qjsp_xm", qjsp_xm),
                new SqlParameter("@qjsp_bm", qjsp_bm),
                new SqlParameter("@qjsp_zw", qjsp_zw),
                new SqlParameter("@qjsp_cssj", qjsp_cssj),
                new SqlParameter("@qjsp_gssj", qjsp_gssj),
                new SqlParameter("@qjsp_qjlb", qjsp_qjlb),
                new SqlParameter("@qjsp_kssj", qjsp_kssj),
                new SqlParameter("@qjsp_jssj", qjsp_jssj),
                new SqlParameter("@qjsp_qjts", qjsp_qjts),
                new SqlParameter("@qjsp_gzr", qjsp_gzr),
                new SqlParameter("@qjsp_qjsy", qjsp_qjsy),
                new SqlParameter("@qjsp_dlr", qjsp_dlr),
                new SqlParameter("@qjsp_qjrq", qjsp_qjrq),
                new SqlParameter("@qjsp_kqzrr", qjsp_kqzrr),
                new SqlParameter("@qjsp_kqzrr_rq", qjsp_kqzrr_rq),
                new SqlParameter("@qjsp_bmfzr", qjsp_bmfzr),
                new SqlParameter("@qjsp_bmfzr_rq", qjsp_bmfzr_rq),
                new SqlParameter("@qjsp_jhts", qjsp_jhts),
                new SqlParameter("@qjsp_yxts", qjsp_yxts),
                new SqlParameter("@qjsp_bcts", qjsp_bcts),
                new SqlParameter("@qjsp_lxdh", qjsp_lxdh),
                new SqlParameter("@qjsp_qt", qjsp_qt),
                new SqlParameter("@qjsp_zhglbjbr", qjsp_zhglbjbr),
                new SqlParameter("@qjsp_zhglbjbr_rq", qjsp_zhglbjbr_rq),
                new SqlParameter("@qjsp_gszgld", qjsp_gszgld),
                new SqlParameter("@qjsp_gszgld_rq", qjsp_gszgld_rq),
                new SqlParameter("@qjsp_zjlsp", qjsp_zjlsp),
                new SqlParameter("@qjsp_zjlsp_rq", qjsp_zjlsp_rq),
                new SqlParameter("@doc_id", doc_id)
            };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName, parms);

            return ret;
        }

        //销假信息存档
        public static int InsertXjsp(string xjsp_zgbh,
            string xjsp_xm,
                string xjsp_bm,
                    string xjsp_zw,
                        string xjsp_qjlb,
                            string xjsp_ykssj,
                                string xjsp_yjssj,
                                    string xjsp_sjkssj,
                                        string xjsp_sjjjsj,
                                            string xjsp_sjts,
                                                string xjsp_sbsj,
                                                    string xjsp_sfxj,
                                                        string xjsp_ccts,
                                                            string xjsp_ccyy,
                                                                string xjsp_rq,
                                                                    string xjsp_sffhgd,
                                                                        string xjsp_zhglbjbr,
                                                                            string xjsp_zhglbrq,
                                                                                string xjsp_cjqyj,
                                                                                    string xjsp_qt,
                                                                                        string xjsp_fzr,
                                                                                            string xjsp_fzrrq,
                                                                                                int qjsp_id,
            string xjsp_bmfzr, string xjsp_bmfzrrq)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Xjsp";
            //存储过程参数
            object[] para = new object[] {xjsp_zgbh,
											xjsp_xm , 
											xjsp_bm  ,
											xjsp_zw  ,
											xjsp_qjlb , 
											xjsp_ykssj , 
											xjsp_yjssj  ,
											xjsp_sjkssj  ,
											xjsp_sjjjsj  ,
											xjsp_sjts,
											xjsp_sbsj , 
											xjsp_sfxj,
											xjsp_ccts,
											xjsp_ccyy,
											xjsp_rq  ,
											xjsp_sffhgd,
											xjsp_zhglbjbr  ,
											xjsp_zhglbrq ,
											xjsp_cjqyj,
											xjsp_qt,
											xjsp_fzr,  
											xjsp_fzrrq,
											qjsp_id,
										    xjsp_bmfzr,
											xjsp_bmfzrrq};
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }
        //员工调动存档
        public static int InsertYgddsp(int ygddsp_id,
            string ygddsp_xm,
            string ygddsp_xbm,
            string ygddsp_xgw,
            string ygddsp_zgbh,
            string ygddsp_cjggsj,
            string ygddsp_xgwsj,
            string ygddsp_ddlx,
            string ygddsp_yddxq,
            string ygddsp_dddxq,
            string ygddsp_ddbz,
            string ygddsp_yddxq1,
            string ygddsp_dddxq1,
            string ygddsp_ddbz1,
            string ygddsp_yddxq2,
            string ygddsp_dddxq2,
            string ygddsp_ddbz2,
            string ygddsp_kssj,
            string ygddsp_jssj,
            string ygddsp_ddyy,
            string ygddsp_xbmyj,
            string ygddsp_xbmqm,
            string ygddsp_xbmrq,
            string ygddsp_xbmldyj,
            string ygddsp_xbmldqm,
            string ygddsp_xbmldrq,
            string ygddsp_dwbmyj,
            string ygddsp_dwbmqm,
            string ygddsp_dwbmrq,
            string ygddsp_dwbmldyj,
            string ygddsp_dwbmldqm,
            string ygddsp_dwbmldrq,
            string ygddsp_zhglbyj,
            string ygddsp_zhglbqm,
            string ygddsp_zhglbrq,
            string ygddsp_gsldyj,
            string ygddsp_gsldqm,
            string ygddsp_gsldrq,
            int ygddsp_flag)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Ygddsp";
            //存储过程参数
            object[] para = new object[] {ygddsp_id ,
											 ygddsp_xm ,
											 ygddsp_xbm ,
											 ygddsp_xgw ,
											 ygddsp_zgbh ,
											 ygddsp_cjggsj ,
											 ygddsp_xgwsj ,
											 ygddsp_ddlx ,
											 ygddsp_yddxq ,
											 ygddsp_dddxq ,
											 ygddsp_ddbz ,
											 ygddsp_yddxq1 ,
											 ygddsp_dddxq1 ,
											 ygddsp_ddbz1 ,
											 ygddsp_yddxq2 ,
											 ygddsp_dddxq2 ,
											 ygddsp_ddbz2 ,
											 ygddsp_kssj ,
											 ygddsp_jssj,
											 ygddsp_ddyy ,
											 ygddsp_xbmyj ,
											 ygddsp_xbmqm ,
											 ygddsp_xbmrq ,
											 ygddsp_xbmldyj ,
											 ygddsp_xbmldqm ,
											 ygddsp_xbmldrq ,
											 ygddsp_dwbmyj ,
											 ygddsp_dwbmqm ,
											 ygddsp_dwbmrq ,
											 ygddsp_dwbmldyj ,
											 ygddsp_dwbmldqm ,
											 ygddsp_dwbmldrq ,
											 ygddsp_zhglbyj ,
											 ygddsp_zhglbqm ,
											 ygddsp_zhglbrq ,
											 ygddsp_gsldyj ,
											 ygddsp_gsldqm ,
											 ygddsp_gsldrq,
												ygddsp_flag};
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //员工调动存档更新
        public static int UpdateYgddsp(int ygddsp_id,
            string ygddsp_ybmjj,
            string ygddsp_ybmsjr,
            string ygddsp_dbmjj,
            string ygddsp_dbmsjr,
            string ygddsp_sfzgpx,
            string ygddsp_yy,
            string ygddsp_bmfzr,
            string ygddsp_bmfzr_rq,
            string ygddsp_sfappx,
            string ygddsp_pxnr,
            string ygddsp_pxfs,
            string ygddsp_pxkssj,
            string ygddsp_pxjssj,
            string ygddsp_zhglbpxfzr,
            string ygddsp_zhglbpxfzrrq,
            string ygddsp_gsldpxyj,
            string ygddsp_gsldpxqz,
            string ygddsp_gsldpxqzrq)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Update_Ygddsp";
            //存储过程参数
            object[] para = new object[] {ygddsp_id ,
											 ygddsp_ybmjj ,
											 ygddsp_ybmsjr ,
											 ygddsp_dbmjj ,
											 ygddsp_dbmsjr ,
											 ygddsp_sfzgpx ,
											 ygddsp_yy ,
											 ygddsp_bmfzr ,
											 ygddsp_bmfzr_rq ,
											 ygddsp_sfappx ,
											 ygddsp_pxnr ,
											 ygddsp_pxfs ,
											 ygddsp_pxkssj ,
											 ygddsp_pxjssj ,
											 ygddsp_zhglbpxfzr ,
											 ygddsp_zhglbpxfzrrq ,
											 ygddsp_gsldpxyj ,
											 ygddsp_gsldpxqz ,
											 ygddsp_gsldpxqzrq };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //入职登记存档
        public static int InsertRzdj(string rzdj_rq,
            string rzdj_xm,
            string rzdj_bm,
            string rzdj_rzsj,
            string rzdj_zgbh,
            string rzdj_gw,
            string rzdj_pyxs,
            string rzdj_ajhbb_ajk,
            string rzdj_ajhbb_ajk_fzr,
            string rzdj_ajhbb_lbhj,
            string rzdj_ajhbb_lbhj_fzr,
            string rzdj_zhglb_tjqk,
            string rzdj_zhglb_tjqk_fzr,
            string rzdj_zhglb_hgk,
            string rzdj_zhglb_hgk_fzr,
            string rzdj_zhglb_kq,
            string rzdj_zhglb_kq_fzr,
            string rzdj_zhglb_bg,
            string rzdj_zhglb_bg_fzr,
            string rzdj_zhglb_sjc,
            string rzdj_zhglb_sjc_fzr,
            string rzdj_zhglb_bgdn,
            string rzdj_zhglb_bgdn_fzr,
            string rzdj_cwb_gzk,
            string rzdj_cwb_gzk_fzr,
            string rzdj_qtbm_clsx,
            string rzdj_qtbm_clsx_jtmx,
            string rzdj_qtbm_clsx_fzr,
            string rzdj_bz)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Rzdj";
            //存储过程参数
            object[] para = new object[] {rzdj_rq  ,
											 rzdj_xm  ,
											 rzdj_bm  ,
											 rzdj_rzsj  ,
											 rzdj_zgbh  ,
											 rzdj_gw  ,
											 rzdj_pyxs  ,
											 rzdj_ajhbb_ajk  ,
											 rzdj_ajhbb_ajk_fzr  ,
											 rzdj_ajhbb_lbhj  ,
											 rzdj_ajhbb_lbhj_fzr  ,
											 rzdj_zhglb_tjqk  ,
											 rzdj_zhglb_tjqk_fzr  ,
											 rzdj_zhglb_hgk  ,
											 rzdj_zhglb_hgk_fzr  ,
											 rzdj_zhglb_kq  ,
											 rzdj_zhglb_kq_fzr  ,
											 rzdj_zhglb_bg  ,
											 rzdj_zhglb_bg_fzr  ,
											 rzdj_zhglb_sjc  ,
											 rzdj_zhglb_sjc_fzr  ,
											 rzdj_zhglb_bgdn  ,
											 rzdj_zhglb_bgdn_fzr  ,
											 rzdj_cwb_gzk  ,
											 rzdj_cwb_gzk_fzr  ,
											 rzdj_qtbm_clsx  ,
											 rzdj_qtbm_clsx_jtmx  ,
											 rzdj_qtbm_clsx_fzr  ,
											 rzdj_bz  };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //离职存档
        public static int InsertYgdlsp(
            int doc_id,
            string ygdl_rq,
            string ygdl_zgbh,
            string ygdl_xm,
            string ygdl_bm,
            string ygdl_dlsj,
            string ygdl_bbm_yj,
            string ygdl_bbm_wj,
            string ygdl_bbm_jbr,
            string ygdl_ajhbb_yj,
            string ygdl_ajhbb_wj,
            string ygdl_ajhbb_jbr,
            string ygdl_zhglb_hgk_yj,
            string ygdl_zhglb_hgk_wj,
            string ygdl_zhglb_hgk_jbr,
            string ygdl_zhglb_it_yj,
            string ygdl_zhglb_it_wj,
            string ygdl_zhglb_it_jbr,
            string ygdl_zhglb_lw_yj,
            string ygdl_zhglb_lw_wj,
            string ygdl_zhglb_lw_jbr,
            string ygdl_wzcbb_yj,
            string ygdl_wzcbb_wj,
            string ygdl_wzcbb_jbr,
            string ygdl_qtbm_yj,
            string ygdl_qtbm_wj,
            string ygdl_qtbm_jbr,
            string ygdl_cwb_yj,
            string ygdl_cwb_wj,
            string ygdl_cwb_jbr,
            string ygdl_bz,
            int zc_flag)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Ygdlsp";
            //存储过程参数
            object[] para = new object[] {	 doc_id,
											 ygdl_rq,
											 ygdl_zgbh,
											 ygdl_xm,
											 ygdl_bm,
											 ygdl_dlsj,
											 ygdl_bbm_yj,
											 ygdl_bbm_wj,
											 ygdl_bbm_jbr,
											 ygdl_ajhbb_yj,
											 ygdl_ajhbb_wj,
											 ygdl_ajhbb_jbr,
											 ygdl_zhglb_hgk_yj,
											 ygdl_zhglb_hgk_wj,
											 ygdl_zhglb_hgk_jbr,
											 ygdl_zhglb_it_yj,
											 ygdl_zhglb_it_wj,
											 ygdl_zhglb_it_jbr,
											 ygdl_zhglb_lw_yj,
											 ygdl_zhglb_lw_wj,
											 ygdl_zhglb_lw_jbr,
											 ygdl_wzcbb_yj,
											 ygdl_wzcbb_wj,
											 ygdl_wzcbb_jbr,
											 ygdl_qtbm_yj,
											 ygdl_qtbm_wj,
											 ygdl_qtbm_jbr,
											 ygdl_cwb_yj,
											 ygdl_cwb_wj,
											 ygdl_cwb_jbr,
											 ygdl_bz ,
											 zc_flag };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //增员指标存档
        public static int InsertZyzbsp(string zyzb_tbsj,
            string zyzb_sqbm,
            string zyzb_xqgw,
            string zyzb_xqrs,
            string zyzb_xqlx,
            string zyzb_xjfl,
            string zyzb_ddsj,
            string zyzb_gwzr,
            string zyzb_zg_hymc_nx,
            string zyzb_zg_xl_zy,
            string zyzb_zg_jyxs,
            string zyzb_zg_zc_wy_jsj,
            string zyzb_zg_nl_xb_tz,
            string zyzb_zg_xwly,
            string zyzb_zg_xwly_fpq,
            string zyzb_zg_zgjy_jy,
            string zyzb_tbr,
            string zyzb_zg,
            string zyzb_yrbmfzr_yj,
            string zyzb_yrbmfzr,
            string zyzb_rlzy_yj,
            string zyzb_rlzy_qm,
            string zyzb_zjlsp,
            string zyzb_zjlqm,
            string zyzb_bz)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Zyzbsp";
            //存储过程参数
            object[] para = new object[] {zyzb_tbsj ,
											 zyzb_sqbm ,
											 zyzb_xqgw ,
											 zyzb_xqrs ,
											 zyzb_xqlx ,
											 zyzb_xjfl ,
											 zyzb_ddsj ,
											 zyzb_gwzr ,
											 zyzb_zg_hymc_nx ,
											 zyzb_zg_xl_zy ,
											 zyzb_zg_jyxs ,
											 zyzb_zg_zc_wy_jsj ,
											 zyzb_zg_nl_xb_tz ,
											 zyzb_zg_xwly ,
											 zyzb_zg_xwly_fpq ,
											 zyzb_zg_zgjy_jy ,
											 zyzb_tbr ,
											 zyzb_zg ,
											 zyzb_yrbmfzr_yj ,
											 zyzb_yrbmfzr ,
											 zyzb_rlzy_yj ,
											 zyzb_rlzy_qm ,
											 zyzb_zjlsp ,
											 zyzb_zjlqm ,
											 zyzb_bz};
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //添加教育经历到临时表
        public static int InsertQzspJyjlTemp(string qzsp_jy_kssj,
            string qzsp_jy_jssj,
            string qzsp_jy_xx,
            string qzsp_jy_zy,
            string qzsp_jy_xxxs,
            string qzsp_jy_hdzs)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Qzsp_Jyjl_Temp";
            //存储过程参数
            object[] para = new object[] {qzsp_jy_kssj,
											 qzsp_jy_jssj,
											 qzsp_jy_xx,
											 qzsp_jy_zy,
											 qzsp_jy_xxxs,
											 qzsp_jy_hdzs};
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //添加工作简历到临时表
        public static int InsertQzspGzjlTemp(string qzsp_gz_kssj,
            string qzsp_gz_jssj,
            string qzsp_gz_gzdw,
            string qzsp_gz_lxdh,
            string qzsp_gz_bm_zw,
            string qzsp_gz_srqk,
            string qzsp_gz_lzyy)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Qzsp_Gzjl_Temp";
            //存储过程参数
            object[] para = new object[] {qzsp_gz_kssj ,
											 qzsp_gz_jssj ,
											 qzsp_gz_gzdw ,
											 qzsp_gz_lxdh ,
											 qzsp_gz_bm_zw ,
											 qzsp_gz_srqk ,
											 qzsp_gz_lzyy };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //添加家庭关系到临时表
        public static int InsertQzspJtgxTemp(string qzsp_jt_xm,
            string qzsp_jt_nl,
            string qzsp_jt_gx,
            string qzsp_jt_dw_zw)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Qzsp_Jtgx_Temp";
            //存储过程参数
            object[] para = new object[] {qzsp_jt_xm ,
											 qzsp_jt_nl ,
											 qzsp_jt_gx ,
											 qzsp_jt_dw_zw };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //添加教育经历到正式表
        public static int InsertQzspJyjl(
            int doc_id,
            string qzsp_jy_kssj,
            string qzsp_jy_jssj,
            string qzsp_jy_xx,
            string qzsp_jy_zy,
            string qzsp_jy_xxxs,
            string qzsp_jy_hdzs)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Qzsp_Jyjl";
            //存储过程参数
            object[] para = new object[] {doc_id,
											 qzsp_jy_kssj,
											 qzsp_jy_jssj,
											 qzsp_jy_xx,
											 qzsp_jy_zy,
											 qzsp_jy_xxxs,
											 qzsp_jy_hdzs};
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //添加工作简历到正式表
        public static int InsertQzspGzjl(int doc_id,
            string qzsp_gz_kssj,
            string qzsp_gz_jssj,
            string qzsp_gz_gzdw,
            string qzsp_gz_lxdh,
            string qzsp_gz_bm_zw,
            string qzsp_gz_srqk,
            string qzsp_gz_lzyy)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Qzsp_Gzjl";
            //存储过程参数
            object[] para = new object[] {doc_id,
											 qzsp_gz_kssj ,
											 qzsp_gz_jssj ,
											 qzsp_gz_gzdw ,
											 qzsp_gz_lxdh ,
											 qzsp_gz_bm_zw ,
											 qzsp_gz_srqk ,
											 qzsp_gz_lzyy };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //添加家庭关系到正式表
        public static int InsertQzspJtgx(int doc_id,
            string qzsp_jt_xm,
            string qzsp_jt_nl,
            string qzsp_jt_gx,
            string qzsp_jt_dw_zw)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Qzsp_Jtgx";
            //存储过程参数
            object[] para = new object[] {doc_id,
											 qzsp_jt_xm ,
											 qzsp_jt_nl ,
											 qzsp_jt_gx ,
											 qzsp_jt_dw_zw };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //获得教育经历临时表
        public static DataTable SelectQzspJyjlTemp()
        {

            //存储过程名
            string spName = "sp_Rs_Select_Qzsp_Jyjl_Temp";
            //			//存储过程参数
            //			object[] para = new object[] {flow_id, step_id};
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName);
        }

        //获得工作简历临时表
        public static DataTable SelectQzspGzjlTemp()
        {

            //存储过程名
            string spName = "sp_Rs_Select_Qzsp_Gzjl_Temp";
            //			//存储过程参数
            //			object[] para = new object[] {flow_id, step_id};
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName);
        }

        //获得家庭关系临时表
        public static DataTable SelectQzspJtgxTemp()
        {

            //存储过程名
            string spName = "sp_Rs_Select_Qzsp_Jtgx_Temp";
            //			//存储过程参数
            //			object[] para = new object[] {flow_id, step_id};
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName);
        }

        //获得教育经历表
        public static DataTable SelectQzspJyjlByDocId(int doc_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Qzsp_Jyjl_By_Doc_Id";
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName, 
                new SqlParameter("@qzsp_id", doc_id));
        }

        //获得工作简历表
        public static DataTable SelectQzspGzjlByDocId(int doc_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Qzsp_Gzjl_By_Doc_Id";
            //存储过程参数
            object[] para = new object[] { doc_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //获得家庭关系表
        public static DataTable SelectQzspJtgxByDocId(int doc_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Qzsp_Jtgx_By_Doc_Id";
            //存储过程参数
            object[] para = new object[] { doc_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //删除教育经历临时表，并获取空表
        public static DataTable DeleteQzspJyjlTemp()
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Qzsp_Jyjl_Temp";
            //存储过程参数
            object[] para = new object[] { };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        //删除工作经历临时表，并获取空表
        public static DataTable DeleteQzspGzjlTemp()
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Qzsp_Gzjl_Temp";
            //存储过程参数
            object[] para = new object[] { };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        //删除家庭临时表，并获取空表
        public static DataTable DeleteQzspJtgxTemp()
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Qzsp_Jtgx_Temp";
            //存储过程参数
            object[] para = new object[] { };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);

        }

        //删除教育经历临时表，并获取剩余记录
        public static DataTable DeleteQzspJyjlTempById(int id)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Qzsp_Jyjl_Temp_By_Id";
            //存储过程参数
            object[] para = new object[] { id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        //删除工作经历临时表，并获取剩余记录
        public static DataTable DeleteQzspGzjlTempById(int id)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Qzsp_Gzjl_Temp_By_Id";
            //存储过程参数
            object[] para = new object[] { id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        //删除家庭临时表，并获取剩余记录
        public static DataTable DeleteQzspJtgxTempById(int id)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Qzsp_Jtgx_Temp_By_Id";
            //存储过程参数
            object[] para = new object[] { id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);

        }

        //求职审批存档
        public static int InsertQzsp(int qzsp_id,
            string qzsp_sqzw1,
            string qzsp_sqzw2,
            string qzsp_ddrq,
            string qzsp_qwdy,
            string qzsp_xm,
            string qzsp_xb,
            string qzsp_mz,
            string qzsp_csrq,
            string qzsp_jg,
            string qzsp_zzmm,
            string qzsp_jszc,
            string qzsp_wysp_tc,
            string qzsp_zgxl,
            string qzsp_byyx,
            string qzsp_sxzy,
            string qzsp_bysj,
                    string qzsp_rlzypj,
                        string qzsp_yrbmpj,
                            string qzsp_zjsh,
                                string qzsp_jbzscs,
                                    string qzsp_yxgw,
                                        string qzsp_rlzyppr,
                                            string qzsp_zyyycs,
                                                string qzsp_ywjncs,
                                                    string qzsp_ynbmppr,
                                                        string qzsp_zpgw,
                                                            string qzsp_sgsj,
                                                                string qzsp_htqx,
                                                                    string qzsp_syq,
                                                                        string qzsp_yrbmfzr,
                                                                            string qzsp_rlzyfzr,
                                                                                string qzsp_rlzyld,
                                                                                    string qzsp_zjlsp,
                                                                                        string qzsp_xzdy,
                                                                                            string qzsp_qt,
                                                                                                string qzsp_fzr,
                                                                                                    string qzsp_rq)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Qzsp";
            //存储过程参数
            object[] para = new object[] {	qzsp_id ,
											qzsp_sqzw1 ,
											qzsp_sqzw2 ,
											qzsp_ddrq ,
											qzsp_qwdy ,
											qzsp_xm ,
											qzsp_xb ,
											qzsp_mz ,
											qzsp_csrq ,
											qzsp_jg ,
											qzsp_zzmm ,
											qzsp_jszc ,
											qzsp_wysp_tc ,
											qzsp_zgxl ,
											qzsp_byyx ,
											qzsp_sxzy ,
											qzsp_bysj ,
											qzsp_rlzypj ,
											qzsp_yrbmpj ,
											qzsp_zjsh ,
											qzsp_jbzscs ,
											qzsp_yxgw ,
											qzsp_rlzyppr ,
											qzsp_zyyycs  ,
											qzsp_ywjncs  ,
											qzsp_ynbmppr ,
											qzsp_zpgw ,
											qzsp_sgsj ,
											qzsp_htqx ,
											qzsp_syq ,
											qzsp_yrbmfzr ,
											qzsp_rlzyfzr ,
											qzsp_rlzyld ,
											qzsp_zjlsp ,
											qzsp_xzdy ,
											qzsp_qt ,
											qzsp_fzr ,
											qzsp_rq};
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //求职审批存档更新后部分
        public static int UpdateQzsp(int qzsp_id,
            string qzsp_rlzypj,
            string qzsp_yrbmpj,
            string qzsp_zjsh,
            string qzsp_jbzscs,
            string qzsp_yxgw,
            string qzsp_rlzyppr,
            string qzsp_zyyycs,
            string qzsp_ywjncs,
            string qzsp_ynbmppr,
            string qzsp_zpgw,
            string qzsp_sgsj,
            string qzsp_htqx,
            string qzsp_syq,
            string qzsp_yrbmfzr,
            string qzsp_rlzyfzr,
            string qzsp_rlzyld,
            string qzsp_zjlsp,
            string qzsp_xzdy,
            string qzsp_qt,
            string qzsp_fzr,
            string qzsp_rq,
            string qzsp_yrbm)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Update_Qzsp";
            //存储过程参数
            object[] para = new object[] {	qzsp_id ,
											 qzsp_rlzypj ,
											 qzsp_yrbmpj ,
											 qzsp_zjsh ,
											 qzsp_jbzscs ,
											 qzsp_yxgw ,
											 qzsp_rlzyppr ,
											 qzsp_zyyycs  ,
											 qzsp_ywjncs  ,
											 qzsp_ynbmppr ,
											 qzsp_zpgw ,
											 qzsp_sgsj ,
											 qzsp_htqx ,
											 qzsp_syq ,
											 qzsp_yrbmfzr ,
											 qzsp_rlzyfzr ,
											 qzsp_rlzyld ,
											 qzsp_zjlsp ,
											 qzsp_xzdy ,
											 qzsp_qt ,
											 qzsp_fzr ,
											 qzsp_rq ,
											 qzsp_yrbm};
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //获得请假审批表
        public static DataTable SelectQjspByZgbhFlag(string zgbh, int qjsp_sfxj_flag)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Qjsp_By_Zgbh_Flag";
            //存储过程参数
            object[] para = new object[] { zgbh, qjsp_sfxj_flag };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //获得销假审批表
        public static DataTable SelectXjspByZgbh(string zgbh)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Xjsp_By_Zgbh";
            //存储过程参数
            object[] para = new object[] { zgbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据查询条件获得请假或者销假审批表
        public static DataTable SelectQjXjByCondition(string xm, string zgbh, string bm, string qjlb, int DisplayType, string qjbh)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Qj_Xj_By_Condition";
            //存储过程参数
            object[] para = new object[] { xm, zgbh, bm, qjlb, DisplayType, qjbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据查询条件获得员工调动审批表
        public static DataTable SelectYgddspByCondition(string xm, string zgbh, string ddsj, string ybm, string xbm, string yzw, string xzw, int DisplayType)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Ygddsp_By_Condition";
            //存储过程参数
            object[] para = new object[] { xm, zgbh, ddsj, ybm, xbm, yzw, xzw, DisplayType };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据查询条件获得员工调离审批表
        public static DataTable SelectYgdlspByCondition(string xm, string zgbh, string dlsj, string bm, int DisplayType)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Ygdlsp_By_Condition";
            //存储过程参数
            object[] para = new object[] { xm, zgbh, dlsj, bm, DisplayType };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据Id更新员工调动审批表flag,并且更新dsoc_ry的部门和职位
        public static int UpdateYgddspFlagById(int ygddsp_id, string zgbh, string ybm, string xbm, string yzw, string xzw, int xmz_y, int xmz_x, string xm)
        {

            //存储过程名
            string spName = "sp_Rs_Update_Ygddsp_Flag_By_Id";
            //存储过程参数
            object[] para = new object[] { ygddsp_id, zgbh, ybm, xbm, yzw, xzw, xmz_y, xmz_x, xm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //根据Id更新员工调离审批表flag,并且更新rs_staff标志位Dismission
        public static int UpdateYgdlspFlagAndStaffDismissionById(int ygddsp_id, string zgbh)
        {

            //存储过程名
            string spName = "sp_Rs_Update_Ygddsp_Flag_Staff_Dimission_By_Id";
            //存储过程参数
            object[] para = new object[] { ygddsp_id, zgbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //对人员信息表进行条件查询
        public static DataTable SelectStaffByCondition(string xm, string zgbh, string xb, string zw, string bm, int DisplayType)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Staff_By_Condition";
            //存储过程参数
            object[] para = new object[] { xm, zgbh, xb, zw, bm, DisplayType };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据部门获取dsoc_ry表
        public static DataTable GetRyByBm(string bm_mc)
        {
            //存储过程名
            string spName = "sp_Rs_Ry_By_Bm";
            //存储过程参数
            object[] para = new object[] { bm_mc };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据部门获取dsoc_ry表中的ry_zgbh
        public static DataTable GetRyZgbhByBm(string bm_mc)
        {
            //存储过程名
            string spName = "sp_Rs_Ry_Zgbh_By_Bm";
            //存储过程参数
            object[] para = new object[] { bm_mc };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }//sp_Rs_Ry_By_Bm_Bh

        //根据部门删除dsoc_ry表
        public static int DeleteRyByBm(string bm_mc)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Ry_By_Bm";
            //存储过程参数
            object[] para = new object[] { bm_mc };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //根据部门和职工编号删除dsoc_ry表
        public static int DeleteRyByZgbhBm(string ry_zgbh, string bm_mc)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Ry_By_Zgbh_Bm";
            //存储过程参数
            object[] para = new object[] { ry_zgbh, bm_mc };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //根据部门名称删除此部门
        public static int DeleteBmByBm(string bm_mc)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Bm_By_Bm";
            //存储过程参数
            object[] para = new object[] { bm_mc };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //删除原记录，并添加人员部门和职位到dsoc_ry表
        public static int InsertDscoRy2(
            string ry_zgbh,
            string ry_xm,
            string ry_bm,
            string ry_zw)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Dsoc_Ry2";
            //存储过程参数
            object[] para = new object[] {	ry_zgbh,
											 ry_xm ,
											 ry_bm ,
											 ry_zw };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //添加人员部门和职位到dsoc_ry表
        public static int InsertDscoRy(
            string ry_zgbh,
            string ry_xm,
            string ry_bm,
            string ry_zw)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Dsoc_Ry";
            //存储过程参数
            object[] para = new object[] {	ry_zgbh,
											ry_xm ,
											ry_bm ,
											ry_zw };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }


        //删除人员部门和职位到dsoc_ry表
        public static int DeleteDsocRyByZgbh(string ry_zgbh)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Delete_Dsoc_Ry_By_Zgbh";
            //存储过程参数
            object[] para = new object[] { ry_zgbh };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //根据id删除人员部门和职位到dsoc_ry表
        public static int DeleteDsocRyByID(int id)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Delete_Dsoc_Ry_By_ID";
            //存储过程参数
            object[] para = new object[] { id };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //根据id删除人员部门和职位到dsoc_ry_temp表
        public static int DeleteDsocRyTempByID(int id)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Delete_Dsoc_Ry_Temp_By_ID";
            //存储过程参数
            object[] para = new object[] { id };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //修改人员部门和职位到dsoc_ry表
        public static int UpdateDsocRy(string ry_zgbh,
            string ry_xm,
            string ry_bm,
            string ry_zw)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Update_Dsoc_Ry";
            //存储过程参数
            object[] para = new object[] {ry_zgbh,
											 ry_xm ,
											 ry_bm ,
											 ry_zw };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //DisplayType获取求职审批信息
        public static DataTable SelectQzsp(int DisplayType)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Qzsp";
            //存储过程参数
            object[] para = new object[] { DisplayType };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //通过qzsp_id获取求职审批信息
        public static DataTable SelectQzspById(int qzsp_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Qzsp_By_Id";
            //存储过程参数
            object[] para = new object[] { qzsp_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //删除人事通知单人员名单临时表
        public static DataTable DeleteRstzdRymdTemp()
        {

            //存储过程名
            string spName = "sp_Rs_Delete_Rstzd_Rymd_Temp";
            //存储过程参数
            object[] para = new object[] { };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //添加人事通知单人员名单临时表，并获取表中全部记录
        public static DataTable InsertSelectRstzdRymdTemp(string ry_zgbh,
            string ry_xm,
            string ry_bm)
        {
            //存储过程名
            string spName = "sp_Rs_Insert_Select_Rstzd_Rymd_Temp";
            //存储过程参数
            object[] para = new object[] {ry_zgbh,
											 ry_xm ,
											 ry_bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para); ;
        }

        //添加人事通知单人员名单临时表，并获取表中全部记录
        public static DataTable SelectRstzdRymdTemp()
        {
            //存储过程名
            string spName = "sp_Rs_Select_Rstzd_Rymd_Temp";
            //存储过程参数
            object[] para = new object[] { };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para); ;
        }
        //修改人员工资信息到rstzd人员名单临时表
        public static int UpdateRstzdRymdTemp(int zdbh, string gwdj, string jbgz, string gdgz, string qtgz, string fxbzj, string bm, int zzgx)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Update_Rstzd_Rymd_Temp";
            //存储过程参数
            object[] para = new object[] { zdbh, gwdj, jbgz, gdgz, qtgz, fxbzj, bm, zzgx };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //修改人员工资信息到rstzd人员名单表
        public static int UpdateRstzdRymd(int zdbh, string gwdj, string jbgz, string gdgz, string qtgz, string fxbzj, string bm, int zzgx)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Update_Rstzd_Rymd";
            //存储过程参数
            object[] para = new object[] { zdbh, gwdj, jbgz, gdgz, qtgz, fxbzj, bm, zzgx };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //2130//修改人员工资信息到rstzd人员名单临时表
        public static int UpdateRstzdRymdTemp2(int zdbh, string ybm, string ygw, string xgw, string ygwdj, string gwdj, string jbgz, string gdgz, string qtgz, string yfxbzj, string fxbzj, string bm, int flag, string bmdd, int zzgx)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Update_Rstzd_Rymd_Temp2";
            //存储过程参数
            object[] para = new object[] { zdbh, ybm, ygw, xgw, ygwdj, gwdj, jbgz, gdgz, qtgz, yfxbzj, fxbzj, bm, flag, bmdd, zzgx };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;

        }

        //		//修改人员工资信息到rstzd人员名单临时表
        //		public static int UpdateRstzdRymdTemp(int zdbh,string gwdj ,string jbgz ,string gdgz ,string qtgz ,string fxbzj,string bm)
        //		{
        //			int ret = -1;
        //			//存储过程名
        //			string spName = "sp_Rs_Update_Rstzd_Rymd_Temp";
        //			//存储过程参数
        //			object[] para = new object[] { zdbh, gwdj , jbgz , gdgz , qtgz , fxbzj,bm };
        //			//调用数据访问层的方法访问存储过程
        //			ret = SQLHelper.ExecuteNonQuery(spName,false,para);
        //
        //			return ret;
        //		}

        //修改人员工资信息到rstzd人员名单表
        //		public static int UpdateRstzdRymd(int zdbh,string gwdj ,string jbgz ,string gdgz ,string qtgz ,string fxbzj,string bm)
        //		{
        //			int ret = -1;
        //			//存储过程名
        //			string spName = "sp_Rs_Update_Rstzd_Rymd";
        //			//存储过程参数
        //			object[] para = new object[] { zdbh, gwdj , jbgz , gdgz , qtgz , fxbzj ,bm};
        //			//调用数据访问层的方法访问存储过程
        //			ret = SQLHelper.ExecuteNonQuery(spName,false,para);
        //
        //			return ret;
        //		}

        //2130//修改人员工资信息到rstzd人员名单临时表
        //		public static int UpdateRstzdRymdTemp2(int zdbh,string ybm,string ygw,string xgw,string ygwdj,string gwdj,string jbgz ,string gdgz ,string qtgz ,string yfxbzj , string fxbzj,string bm,int flag,string bmdd)
        //		{
        //			int ret = -1;
        //			//存储过程名
        //			string spName = "sp_Rs_Update_Rstzd_Rymd_Temp2";
        //			//存储过程参数
        //			object[] para = new object[] { zdbh,ybm,ygw,xgw,ygwdj,gwdj,jbgz,gdgz,qtgz,yfxbzj,fxbzj,bm,flag,bmdd};
        //			//调用数据访问层的方法访问存储过程
        //			ret = SQLHelper.ExecuteNonQuery(spName,false,para);
        //
        //			return ret;
        //
        //		}

        //		//2144修改人员工资信息到rstzd人员名单表
        //		public static int UpdateRstzdRymd2(int zdbh,string ybm,string ygw,string xgw,string ygwdj,string gwdj,string jbgz ,string gdgz ,string qtgz ,string yfxbzj , string fxbzj,string bm,int flag,string bmdd)
        //		{
        //			int ret = -1;
        //			//存储过程名
        //			string spName = "sp_Rs_Update_Rstzd_Rymd2";
        //			//存储过程参数
        //			object[] para = new object[] { zdbh,ybm,ygw,xgw,ygwdj,gwdj,jbgz,gdgz,qtgz,yfxbzj,fxbzj,bm,flag,bmdd };
        //			//调用数据访问层的方法访问存储过程
        //			ret = SQLHelper.ExecuteNonQuery(spName,false,para);
        //
        //			return ret;
        //		}

        //2144修改人员工资信息到rstzd人员名单表
        public static int UpdateRstzdRymd2(int zdbh, string ybm, string ygw, string xgw, string ygwdj, string gwdj, string jbgz, string gdgz, string qtgz, string yfxbzj, string fxbzj, string bm, int flag, string bmdd, int zzgx)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Update_Rstzd_Rymd2";
            //存储过程参数
            object[] para = new object[] { zdbh, ybm, ygw, xgw, ygwdj, gwdj, jbgz, gdgz, qtgz, yfxbzj, fxbzj, bm, flag, bmdd, zzgx };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }
        //修改人员工资信息到rstzd人员名单临时表
        public static int UpdateRstzdRymdTemp3(int zdbh, string txsj, string txylj, string bm)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Update_Rstzd_Rymd_Temp3";
            //存储过程参数
            object[] para = new object[] { zdbh, txsj, txylj, bm };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //修改人员工资信息到rstzd人员名单表
        public static int UpdateRstzdRymd3(int zdbh, string txsj, string txylj, string bm)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Update_Rstzd_Rymd3";
            //存储过程参数
            object[] para = new object[] { zdbh, txsj, txylj, bm };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }


        //删除rstzd人员名单临时表中某条记录,并获取剩余记录
        public static DataTable DeleteRstzdRymdTempByZdbh(int zdbh)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Rstzd_Rymd_Temp_by_Zdbh";
            //存储过程参数
            object[] para = new object[] { zdbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);

        }//sp_Rs_Insert_Rstzd

        //删除rstzd人员名单临时表中某条记录
        public static int DeleteRstzdRymdTempByZdbh2(int zdbh)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Rstzd_Rymd_Temp_by_Zdbh2";
            //存储过程参数
            object[] para = new object[] { zdbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);

        }

        //删除rstzd人员名单表中某条记录
        public static int DeleteRstzdRymdByZdbh2(int zdbh)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Rstzd_Rymd_by_Zdbh2";
            //存储过程参数
            object[] para = new object[] { zdbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);

        }


        //增加rstzd
        public static int InsertRstzd(int rstzd_id, int rstzd_fblx, string rstzd_bh, string rstzd_sy, string rstzd_nr, string rstzd_jbr, string rstzd_bmfzr, string rstzd_zgfz, string rstzd_zjl, string rstzd_rq)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Rstzd";
            //存储过程参数
            object[] para = new object[] { rstzd_id, rstzd_fblx, rstzd_bh, rstzd_sy, rstzd_nr, rstzd_jbr, rstzd_bmfzr, rstzd_zgfz, rstzd_zjl, rstzd_rq };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }



        //增加rs_tj
        public static int InsertRstj(string bm, int num, int M_num, int PM_num, int FP_num,
            int JY_num, int W_num, int PZ_num, int syhj_num, int bdrs_num, string bdxq, string nf, string yf, string rq, string bz)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Rstj";
            //存储过程参数
            object[] para = new object[] {  bm,num,M_num,PM_num,FP_num,
											 JY_num,W_num,PZ_num,syhj_num,bdrs_num,bdxq,nf,yf,rq,bz};
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //		//根据查询条件获得人事通知单
        //			 public static DataTable SelectRstzdByCondition(int nf, int yf, int tzfl)
        //			 {	
        //				 //存储过程名
        //				 string spName = "sp_Rs_Select_Rstzd_By_Condition";
        //				 //存储过程参数
        //				 object[] para = new object[] {  nf, yf, tzfl };
        //				 //调用数据访问层的方法访问存储过程
        //				 return SQLHelper.ExecuteDataTable(spName,para);
        //			 }

        //根据查询条件获得人事通知单
        public static DataTable SelectRstzdByCondition(int nf, int yf, int tzfl, string ry_xm, string ry_bm, string nr)
        {
            //存储过程名
            string spName = "sp_Rs_Select_Rstzd_By_Condition";
            //存储过程参数
            object[] para = new object[] { nf, yf, tzfl, ry_xm, ry_bm, nr };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }


        //根据id获得人事通知单
        public static DataTable SelectRstzdById(int rstzd_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Rstzd_By_Id";
            //存储过程参数
            object[] para = new object[] { rstzd_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据id获得人事通知单人员名单
        public static DataTable SelectRstzdRymdById(int doc_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Rstzd_Rymd_By_Id";
            //存储过程参数
            object[] para = new object[] { doc_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据id获得人事通知单人员名单并存入临时表中
        //流程返回第一步时执行
        public static DataTable SelectRstzdRymdTempByDocId(int rstzd_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Rstzd_Rymd_Temp_By_Doc_Id";
            //存储过程参数
            object[] para = new object[] { rstzd_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static int InsertInfo_to_wtsp_temp(string str0, string str1, string str2, string str3)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Wtspnr_Temp";
            //存储过程参数
            object[] para = new object[] { str0, str1, str2, str3 };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);


            return ret;
        }

        //插入wtsp内容
        public static int InsertInfo_to_wtspnr(int wtsp_id, string str1, string str2, string str3)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Wtspnr";
            //存储过程参数
            object[] para = new object[] { wtsp_id, str1, str2, str3 };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);


            return ret;
        }


        public static DataTable GetAll_wtsp_temp(string zgbh)
        {
            string spName = "sp_Rs_Select_Wtspnr_temp";
            object[] para = new object[] { zgbh };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static int DeleteInfo_from_wtsp_temp(int str)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Delete_Wtspnr_temp_ById";
            //存储过程参数
            object[] para = new object[] { str };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);


            return ret;
        }

        public static int DeleteInfoFromWtsp(int id)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Delete_Wtspnr_By_Id";
            //存储过程参数
            object[] para = new object[] { id };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);


            return ret;
        }

        public static DataTable GetAll2_wtsp_temp(string zgbh)
        {
            string spName = "sp_Rs_DeleteAndSelect_Wtspnr_temp";
            //存储过程参数
            object[] para = new object[] { zgbh };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据doc_id获取委托审批内容
        public static DataTable SelectWtspnrById(int wtsp_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Wtspnr_By_Id";
            //存储过程参数
            object[] para = new object[] { wtsp_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据id获取委托审批内容并转移到临时表中
        //流程打回到第一步时执行
        public static DataTable SelectWtspnrTempByDocId(int wtsp_id, string zgbh)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Wtspnr_Temp_By_Doc_Id";
            //存储过程参数
            object[] para = new object[] { wtsp_id, zgbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //将临时表插入委托审批内容
        public static int InsertWtspnrById(int wtsp_id, string zgbh)
        {

            //存储过程名
            string spName = "sp_Rs_Insert_Wtspnr_By_Id";
            //存储过程参数
            object[] para = new object[] { wtsp_id, zgbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //委托授权审批存档
        public static int InsertWtsp(int wtsp_id, string wtsp_wtr, DateTime wtsp_kssj, DateTime wtsp_jssj, string wtsp_fzr, string zgld)
        {

            //存储过程名
            string spName = "sp_Rs_Insert_Wtsp";
            //存储过程参数
            object[] para = new object[] { wtsp_id, wtsp_wtr, wtsp_kssj, wtsp_jssj, wtsp_fzr, zgld };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //员工入职情况统计
        public static int ReportYgddRz(int nf, int yf, string bm)
        {
            int iReturn = 0;
            SqlParameter[] parameters = {
											SQLHelper.MakeInParam("@nf",SqlDbType.Int,4,nf),
											SQLHelper.MakeInParam("@yf",SqlDbType.Int,4,yf),
											SQLHelper.MakeInParam("@bm",SqlDbType.VarChar,50,bm)
										};
            try
            {
                iReturn = SQLHelper.ExecuteNonQuery("sp_Rs_Report_Rz", false, parameters);
            }
            catch (Exception e)
            {
                Stoke.Components.Error.Log(e.ToString());
            }
            return iReturn;
        }

        //员工入职人员名单
        public static DataTable ReportYgddRzRy(int nf, int yf, string bm)
        {

            //存储过程名
            string spName = "sp_Rs_Report_Rz_Ry";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable ReportYgddRzRy1(int nf, int yf, string bm)
        {

            //存储过程名
            string spName = "sp_Rs_Report_Rz_Ry1";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //员工离职情况统计
        public static int ReportYgddLz(int nf, int yf, string bm)
        {
            int iReturn = 0;
            SqlParameter[] parameters = {
											SQLHelper.MakeInParam("@nf",SqlDbType.Int,4,nf),
											SQLHelper.MakeInParam("@yf",SqlDbType.Int,4,yf),
											SQLHelper.MakeInParam("@bm",SqlDbType.VarChar,50,bm)
										};
            try
            {
                iReturn = SQLHelper.ExecuteNonQuery("sp_Rs_Report_Lz", false, parameters);
            }
            catch (Exception e)
            {
                Stoke.Components.Error.Log(e.ToString());
            }
            return iReturn;
        }

        //员工离职人员名单
        public static DataTable ReportYgddLzRy(int nf, int yf, string bm)
        {

            //存储过程名
            string spName = "sp_Rs_Report_Lz_Ry";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable ReportYgddLzRy1(int nf, int yf, string bm)
        {

            //存储过程名
            string spName = "sp_Rs_Report_Lz_Ry1";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //部门调入情况统计
        public static int ReportYgddDr(int nf, int yf, string bm)
        {
            int iReturn = 0;
            SqlParameter[] parameters = {
											SQLHelper.MakeInParam("@nf",SqlDbType.Int,4,nf),
											SQLHelper.MakeInParam("@yf",SqlDbType.Int,4,yf),
											SQLHelper.MakeInParam("@bm",SqlDbType.VarChar,50,bm)
										};
            try
            {
                iReturn = SQLHelper.ExecuteNonQuery("sp_Rs_Report_Dr", false, parameters);
            }
            catch (Exception e)
            {
                Stoke.Components.Error.Log(e.ToString());
            }
            return iReturn;
        }

        public static int ReportYgddDr1(int nf, int yf, string bm)
        {
            int iReturn = 0;
            SqlParameter[] parameters = {
											SQLHelper.MakeInParam("@nf",SqlDbType.Int,4,nf),
											SQLHelper.MakeInParam("@yf",SqlDbType.Int,4,yf),
											SQLHelper.MakeInParam("@bm",SqlDbType.VarChar,50,bm)
										};
            try
            {
                iReturn = SQLHelper.ExecuteNonQuery("sp_Rs_Report_Dr1", false, parameters);
            }
            catch (Exception e)
            {
                Stoke.Components.Error.Log(e.ToString());
            }
            return iReturn;
        }

        //部门调入人员名单
        public static DataTable ReportYgddDrRy(int nf, int yf, string bm)
        {

            //存储过程名
            string spName = "sp_Rs_Report_Dr_Ry";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable ReportYgddDrRy1(int nf, int yf, string bm)
        {

            //存储过程名
            string spName = "sp_Rs_Report_Dr_Ry1";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //部门调离情况统计
        public static int ReportYgddDl(int nf, int yf, string bm)
        {
            int iReturn = 0;
            SqlParameter[] parameters = {
											SQLHelper.MakeInParam("@nf",SqlDbType.Int,4,nf),
											SQLHelper.MakeInParam("@yf",SqlDbType.Int,4,yf),
											SQLHelper.MakeInParam("@bm",SqlDbType.VarChar,50,bm)
										};
            try
            {
                iReturn = SQLHelper.ExecuteNonQuery("sp_Rs_Report_Dl", false, parameters);
            }
            catch (Exception e)
            {
                Stoke.Components.Error.Log(e.ToString());
            }
            return iReturn;
        }

        public static int ReportYgddDl1(int nf, int yf, string bm)
        {
            int iReturn = 0;
            SqlParameter[] parameters = {
											SQLHelper.MakeInParam("@nf",SqlDbType.Int,4,nf),
											SQLHelper.MakeInParam("@yf",SqlDbType.Int,4,yf),
											SQLHelper.MakeInParam("@bm",SqlDbType.VarChar,50,bm)
										};
            try
            {
                iReturn = SQLHelper.ExecuteNonQuery("sp_Rs_Report_Dl1", false, parameters);
            }
            catch (Exception e)
            {
                Stoke.Components.Error.Log(e.ToString());
            }

            return iReturn;
        }

        //部门调离人员名单
        public static DataTable ReportYgddDlRy(int nf, int yf, string bm)
        {

            //存储过程名
            string spName = "sp_Rs_Report_Dl_Ry";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable ReportYgddDlRy1(int nf, int yf, string bm)
        {

            //存储过程名
            string spName = "sp_Rs_Report_Dl_Ry1";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据根节点获得孩子节点
        public static DataTable GetSubZw(string PositionID)
        {

            //存储过程名
            string spName = "sp_GetSubZw";
            //存储过程参数
            object[] para = new object[] { PositionID };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //职务树根节点
        public static DataTable GetRootZw(string org_id)
        {
            string spName = "sp_GetRootZw";
            object[] para = new object[] { org_id };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据节点org_id获得人员信息
        public static DataTable GetRyByTreeId(string tree_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Ry_By_Zw";
            //存储过程参数
            object[] para = new object[] { tree_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据org_id获得人员职工编号和姓名
        public static DataTable GetRyByOrgId(string org_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Ry_By_Org_Id";
            //存储过程参数
            object[] para = new object[] { org_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据部门编号获得部门人员信息
        public static DataTable GetRyByBmBh(int bm_bh)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Ry_By_Bm_Bh";
            //存储过程参数
            object[] para = new object[] { bm_bh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }//

        //根据根节点获得孩子节点
        public static DataTable GetOrganizeByTreeId(string tree_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Organize_By_Tree_Id";
            //存储过程参数
            object[] para = new object[] { tree_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }//

        //根据节点号获取改节点信息
        public static DataTable GetZwByTreeId(int tree_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Zw_Tree_By_Id";
            //存储过程参数
            object[] para = new object[] { tree_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //添加叶子节点
        public static int InsertZwTree(string bm_mc, string zw_mc, string parent_zw_mc, int parent_tree_id)
        {
            //存储过程名
            string spName = "sp_Rs_Insert_Zw_Tree";
            //存储过程参数
            object[] para = new object[] { bm_mc, zw_mc, parent_zw_mc, parent_tree_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //删除职位树叶子节点
        public static int DeleteZwTree(long tree_id)
        {
            SqlParameter[] prams = {
									   SQLHelper.MakeInParam("@tree_id",SqlDbType.Int,4,tree_id)
								   };
            return (SQLHelper.ExecuteNonQuery("sp_Rs_Delete_Position", false, prams));
        }

        //sp_Rs_Insert_Qzsp_Qzjl
        //求职审批中求职简历存档
        public static int InsertQzspQzjl(int qzsp_id,
                                            string qzsp_sqzw1,
                                            string qzsp_sqzw2,
                                            string qzsp_ddrq,
                                            string qzsp_qwdy,
                                            string qzsp_xm,
                                            string qzsp_xb,
                                            string qzsp_mz,
                                            string qzsp_csrq,
                                            string qzsp_jg,
                                            string qzsp_zzmm,
                                            string qzsp_jszc,
                                            string qzsp_wysp_tc,
                                            string qzsp_zgxl,
                                            string qzsp_byyx,
                                            string qzsp_sxzy,
                                            string qzsp_bysj,
                                            string qzsp_lb_kssj,
                                            string qzsp_lb_jssj,
                                            string qzsp_zf_kssj,
                                            string qzsp_zf_jssj,
                                            string qzsp_cjgzsj,
                                            string qzsp_rsdaszdw,
                                            string qzsp_dqzt,
                                            string qzsp_jkzk,
                                            string qzsp_hyzk,
                                            string qzsp_sjc,
                                            string qzsp_lxdh_home,
                                            string qzsp_lxdh_mobile,
                                            string qzsp_sfzh,
                                            string qzsp_hkszd,
                                            string qzsp_dlxxdz,
                                            string qzsp_ywzdbs,
                                            string qzsp_bsjk,
                                            string qzsp_spsj)
        {

            //存储过程名
            string spName = "sp_Rs_Insert_Qzsp_Qzjl";
            //存储过程参数
            object[] para = new object[] { qzsp_id ,
											qzsp_sqzw1 ,
											qzsp_sqzw2 ,
											qzsp_ddrq ,
											qzsp_qwdy ,
											qzsp_xm ,
											qzsp_xb ,
											qzsp_mz ,
											qzsp_csrq ,
											qzsp_jg ,
											qzsp_zzmm ,
											qzsp_jszc ,
											qzsp_wysp_tc ,
											qzsp_zgxl ,
											qzsp_byyx ,
											qzsp_sxzy ,
											qzsp_bysj ,
											qzsp_lb_kssj ,
											qzsp_lb_jssj ,
											qzsp_zf_kssj ,
											qzsp_zf_jssj ,
											qzsp_cjgzsj ,
											qzsp_rsdaszdw ,
											qzsp_dqzt ,
											qzsp_jkzk ,
											qzsp_hyzk ,
											qzsp_sjc ,
											qzsp_lxdh_home ,
											qzsp_lxdh_mobile ,
											qzsp_sfzh ,
											qzsp_hkszd ,
											qzsp_dlxxdz ,
											qzsp_ywzdbs ,
											qzsp_bsjk ,
											qzsp_spsj };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //求职审批中求职简历更新、、不关闭页面时
        public static int UpdateQzspQzjl(int qzsp_id,
            string qzsp_sqzw1,
            string qzsp_sqzw2,
            string qzsp_ddrq,
            string qzsp_qwdy,
            string qzsp_xm,
            string qzsp_xb,
            string qzsp_mz,
            string qzsp_csrq,
            string qzsp_jg,
            string qzsp_zzmm,
            string qzsp_jszc,
            string qzsp_wysp_tc,
            string qzsp_zgxl,
            string qzsp_byyx,
            string qzsp_sxzy,
            string qzsp_bysj,
            string qzsp_lb_kssj,
            string qzsp_lb_jssj,
            string qzsp_zf_kssj,
            string qzsp_zf_jssj,
            string qzsp_cjgzsj,
            string qzsp_rsdaszdw,
            string qzsp_dqzt,
            string qzsp_jkzk,
            string qzsp_hyzk,
            string qzsp_sjc,
            string qzsp_lxdh_home,
            string qzsp_lxdh_mobile,
            string qzsp_sfzh,
            string qzsp_hkszd,
            string qzsp_dlxxdz,
            string qzsp_ywzdbs,
            string qzsp_bsjk,
            string qzsp_spsj)
        {

            //存储过程名
            string spName = "sp_Rs_Update_Qzsp_Qzjl";
            //存储过程参数
            object[] para = new object[] { qzsp_id ,
											 qzsp_sqzw1 ,
											 qzsp_sqzw2 ,
											 qzsp_ddrq ,
											 qzsp_qwdy ,
											 qzsp_xm ,
											 qzsp_xb ,
											 qzsp_mz ,
											 qzsp_csrq ,
											 qzsp_jg ,
											 qzsp_zzmm ,
											 qzsp_jszc ,
											 qzsp_wysp_tc ,
											 qzsp_zgxl ,
											 qzsp_byyx ,
											 qzsp_sxzy ,
											 qzsp_bysj ,
											 qzsp_lb_kssj ,
											 qzsp_lb_jssj ,
											 qzsp_zf_kssj ,
											 qzsp_zf_jssj ,
											 qzsp_cjgzsj ,
											 qzsp_rsdaszdw ,
											 qzsp_dqzt ,
											 qzsp_jkzk ,
											 qzsp_hyzk ,
											 qzsp_sjc ,
											 qzsp_lxdh_home ,
											 qzsp_lxdh_mobile ,
											 qzsp_sfzh ,
											 qzsp_hkszd ,
											 qzsp_dlxxdz ,
											 qzsp_ywzdbs ,
											 qzsp_bsjk ,
											 qzsp_spsj };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //Orgnize树内容
        public static DataTable GetOrganize()
        {
            string spName = "sp_Rs_Get_Organize_All";
            return SQLHelper.ExecuteDataTable(spName);
        }

        //根据部门获取Orgnize树内容
        public static DataTable GetRootIDByBm(string bm)
        {
            //存储过程名
            string spName = "sp_Rs_Get_RootID_By_Bm";
            //存储过程参数
            object[] para = new object[] { bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据部门编号获取Orgnize树内容
        public static DataTable GetRootIDByBmBh(int bm_bh)
        {
            //存储过程名
            string spName = "sp_Rs_Get_RootID_By_Bm_Bh";
            //存储过程参数
            object[] para = new object[] { bm_bh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //获取部门或项目组
        public static DataTable GetBmXmz2(int DisplayType)
        {

            //存储过程名
            string spName = "sp_Rs_Get_Bm_Xmz2";
            //存储过程参数
            object[] para = new object[] { DisplayType };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //获取部门或项目组及人数
        public static DataTable GetBmXmz(int DisplayType)
        {

            //存储过程名
            string spName = "sp_Rs_Get_Bm_Xmz";
            //存储过程参数
            object[] para = new object[] { DisplayType };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //获取已撤销部门或项目组
        public static DataTable GetBmXmzSc(int DisplayType)
        {

            //存储过程名
            string spName = "sp_Rs_Get_Bm_Xmz_Sc";
            //存储过程参数
            object[] para = new object[] { DisplayType };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }


        //根据职工编号获取部门和职务信息
        public static DataTable SelectRyByZgbh(string ry_zgbh)
        {
            string spName = "sp_Rs_Select_Ry_By_Zgbh";
            object[] para = new object[] { ry_zgbh };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable GetZwAll()
        {
            //存储过程名
            string spName = "sp_Rs_Position_Get_All";
            //执行存储过程，并返回DataTable
            return SQLHelper.ExecuteDataTable(spName);
        }

        public static DataTable GetZwJB()
        {
            //存储过程名
            string spName = "sp_Rs_Get_Zwjb";
            //执行存储过程，并返回DataTable
            return SQLHelper.ExecuteDataTable(spName);
        }

        public static DataTable GetZwByBh(int zw_bh)
        {
            //存储过程名
            string spName = "sp_Rs_Get_Zw_By_Bh";
            object[] para = new object[] { zw_bh };
            //执行存储过程，并返回DataTable
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static int InsertZw(string zw_mc, string zw_js, string zw_flag)
        {
            int result = -1;
            string spName = "sp_Rs_Position_Insert";
            object[] para = new object[] { zw_mc, zw_js, zw_flag };
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
            return result;
        }

        public static int UpdateZw(int zw_bh, string zw_js, string zw_flag)
        {
            int result = -1;
            string spName = "sp_Rs_Position_Update";
            object[] para = new object[] { zw_bh, zw_js, zw_flag };
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
            return result;
        }

        public static int DeleteZw(int id)
        {
            int result = -1;
            string spName = "sp_Rs_Position_Delete";
            object[] para = new object[] { id };
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
            return result;
        }

        public static DataTable GetRyNumByZw(string zw_mc)
        {
            //存储过程名
            string spName = "sp_Rs_Ry_Num_By_Zw";
            //存储过程参数
            object[] para = new object[] { zw_mc };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        //删除部门时根据部门删除Organize
        public static int DeleteOrganizeByBm(string bm_mc)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Organize_By_Bm";
            //存储过程参数
            object[] para = new object[] { bm_mc };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }



        //增加人事通知单人员名单（流程）
        public static int InsertFlowRstzdRymd(int doc_id)
        {
            //存储过程名
            string spName = "sp_Rs_Insert_Flow_Rstzd_Rymd";
            //存储过程参数
            object[] para = new object[] { doc_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //根据qjsp_id获得此请假信息
        public static DataTable SelectQjspById(int qjsp_id)
        {
            //存储过程名
            string spName = "sp_Rs_Select_Qjsp_By_Id";
            //存储过程参数
            object[] para = new object[] { qjsp_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据部门编号撤销此部门
        public static int DeleteBmByBh(int bm_bh)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Bm_By_Bh";
            //存储过程参数
            object[] para = new object[] { bm_bh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //根据部门编号删除此部门
        public static int ScBmByBh(int bm_bh)
        {
            //存储过程名
            string spName = "sp_Rs_Sc_Bm_By_Bh";
            //存储过程参数
            object[] para = new object[] { bm_bh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //根据部门编号获取dsoc_ry表中的ry_zgbh
        public static DataTable GetRyZgbhByBmBh(int bm_bh)
        {
            //存储过程名
            string spName = "sp_Rs_Ry_By_Bm_Bh";
            //存储过程参数
            object[] para = new object[] { bm_bh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据职工编号和年份获取年假计划
        public static DataTable GetNjjhByZgbh(string ry_zgbh, int nj_year)
        {
            //存储过程名
            string spName = "sp_Rs_Get_Njjh_By_Zgbh";
            //存储过程参数
            object[] para = new object[] { ry_zgbh, nj_year };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据职工编号和年份更新年假计划
        //根据职工编号和年份更新年假计划
        public static DataTable UpdateNjjhByZgbh(string ry_zgbh, int nj_year, int jhts, int yxts, int syts, string xm, string bm, string zw)
        {
            //存储过程名
            string spName = "sp_Rs_Update_Njjh_By_Zgbh";
            //存储过程参数
            object[] para = new object[] { ry_zgbh, nj_year, jhts, yxts, syts, xm, bm, zw };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }


        //获取部门在项目组中的人数
        public static DataTable GetBmToXmzNum(string bm, string xmz)
        {
            //存储过程名
            string spName = "rs_staff_statistics_by_bm_xmz";
            //存储过程参数
            object[] para = new object[] { bm, xmz };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //获取跨部门人员职工编号
        public static DataTable GetRyTwoBm()
        {
            //存储过程名
            string spName = "sp_Rs_Get_Ry_Two_Bm";
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName);
        }

        //获取跨部门人员姓名部门
        public static DataTable GetRyTwoBm2(string zgbh)
        {
            //存储过程名
            string spName = "sp_Rs_Get_Ry_Two_Bm2";
            //存储过程参数
            object[] para = new object[] { zgbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据id获取文件名
        public static DataTable GetFileName(int id)
        {
            //存储过程名
            string spName = "sp_scfj_get_file_name_by_id";
            //存储过程参数
            object[] para = new object[] { id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //获取入职-离职角色
        public static DataTable GetRzLzRole()
        {
            //存储过程名
            string spName = "sp_Rs_Get_Rz_Lz_Role";
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName);
        }

        //根据部门获取入职-离职角色
        public static DataTable GetRzLzRoleByBm(string bm)
        {
            //存储过程名
            string spName = "sp_Rs_Get_Rz_Lz_Role_By_Bm";
            //存储过程参数
            object[] para = new object[] { bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //添加入职-离职角色
        public static int InsertRzLzRole(string bm, string role)
        {
            //存储过程名
            string spName = "sp_Rs_Insert_Rz_Lz_Role";
            //存储过程参数
            object[] para = new object[] { bm, role };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //删除入职-离职角色
        public static int DeleteRzLzRole(int role_bh)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Rz_Lz_Role";
            //存储过程参数
            object[] para = new object[] { role_bh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //添加入职-离职角色对应人员
        public static int InsertRzLzRoleRy(string ry_zgbh, int role_bh)
        {
            //存储过程名
            string spName = "sp_Rs_Insert_Rz_Lz_Role_Ry";
            //存储过程参数
            object[] para = new object[] { ry_zgbh, role_bh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //删除入职-离职角色对应人员
        public static int DeleteRzLzRoleRy(string ry_zgbh, int role_bh)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Rz_Lz_Role_Ry";
            //存储过程参数
            object[] para = new object[] { ry_zgbh, role_bh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //获取入职-离职角色对应人员
        public static DataTable GetRzLzRoleRy(int role_bh)
        {
            //存储过程名
            string spName = "sp_Rs_Get_Rz_Lz_Role_Ry";
            //存储过程参数
            object[] para = new object[] { role_bh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //删除流程实例
        public static int DeleteDocument(int doc_id)
        {
            //存储过程名
            string spName = "sp_Flow_Delete_Document";
            //存储过程参数
            object[] para = new object[] { doc_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }
        //根据查询条件获得年假信息
        public static DataTable SelectNjxxByCondition(string xm, string bm, string year, string njjh, string yxts, string syts)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Njxx_By_Condition";
            //存储过程参数
            object[] para = new object[] { xm, bm, year, njjh, yxts, syts };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        #region 绩效考核，培训管理新增


        //操作类绩效考核信息存档
        public static int InsertJxcz(string jxcz_xm, string jxcz_zgbh, string jxcz_zw, string jxcz_bm, string jxcz_jx, string jxcz_bzcc,
            string jxcz_sjms, string jxcz_pj, int jxcz_fs, string jxcz_khr, string jxcz_khrq, string jxcz_shyj, string jxcz_shr, string jxcz_shrq)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Jxcz";
            //存储过程参数
            object[] para = new object[] { jxcz_xm,
											 jxcz_zgbh,
											 jxcz_zw,
											 jxcz_bm,
											 jxcz_jx,
											 jxcz_bzcc,
											 jxcz_sjms,
											 jxcz_pj,
											 jxcz_fs,
											 jxcz_khr,
											 jxcz_khrq,
											 jxcz_shyj,
											 jxcz_shr,
											 jxcz_shrq};


            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //见习类绩效考核信息存档
        public static int InsertJxjx(string xm, string zgbh, string bm, string td, string bx,
            string gx, string gz, string gzl, string gzhj, string gzsj, string jy, string wt, string yj, int fs)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Jxjx";
            //存储过程参数
            object[] para = new object[] { xm, zgbh, bm, td, bx, gx, gz, gzl, gzhj, gzsj, jy, wt, yj, fs };


            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }


        //见习类绩效考核根据doc_id修改自评表
        public static int UpdateJxjx_byid(string xm, string zgbh, string bm, string td, string bx,
            string gx, string gz, string gzl, string gzhj, string gzsj, string jy, string wt, string yj, int fs, int id)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Update_Jxjx_byid";
            //存储过程参数
            object[] para = new object[] { xm, zgbh, bm, td, bx, gx, gz, gzl, gzhj, gzsj, jy, wt, yj, fs, id };


            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //绩效考核见习类内容由工号或doc_id获得
        public static DataTable GetInfo_jxjx(string zgbh, int id)
        {

            //存储过程名
            string spName = "sp_Rs_Get_jxjx_By_zgbh_docid";
            //存储过程参数
            object[] para = new object[] { zgbh, id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //删除绩效考核见习类表数据
        public static int DeleteJxjx(int doc_id)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Jxjx";
            //存储过程参数
            object[] para = new object[] { doc_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }
        public static int UpdateJxjx_docid_by_zgbh(int id, string zgbh)
        {
            //存储过程名
            string spName = "sp_Rs_UpdateJxjx_docid_by_zgbh";
            //存储过程参数
            object[] para = new object[] { id, zgbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        public static DataTable GetInfo_jxjx_staff(string zgbh)
        {
            DataTable table = null;
            object[] _ob = new object[] { zgbh };
            try
            {
                table = SQLHelper.ExecuteDataTable("sp_Rs_Getzgxl_byxx_jbdwsj", _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("Staff.GetInfo_jxjx_staff(string zgbh)" + e.Message);
            }
            return table;
        }

        //见习类意见汇总插入表单（流程）
        public static int Insert_Flow_Rs_jxjx_yjhz(int id, string zgxm, int zpfs1, double zpfs2,
            string dsxm, int fs1, double fs2, string bzxm, int fs3, double fs4, double zf)
        {
            //存储过程名
            string spName = "sp_Rs_Insert_Flow_Rs_jxjx_yjhz";
            //存储过程参数
            object[] para = new object[] { id, zgxm, zpfs1, zpfs2, dsxm, fs1, fs2, bzxm, fs3, fs4, zf };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //		public static DataTable GetAll_pxgl_ry_temp(string txrid)
        //		{
        //			string spName = "sp_Rs_Select_pxgl_ry_temp";
        //			object[] para = new object[] { txrid };
        //			return SQLHelper.ExecuteDataTable(spName,para);
        //		}
        //
        //		public static DataTable GetAll2_pxgl_ry_temp(string txrid)
        //		{
        //			string spName = "sp_Rs_Select_pxgl_ry_temp2";
        //			object[] para = new object[] { txrid };
        //			return SQLHelper.ExecuteDataTable(spName,para);
        //		}
        //
        //		//培训管理页面绑定
        //		public static DataTable GetAll_pxgl()
        //		{
        //			string spName = "sp_Rs_Select_pxgl";
        //			object[] para = new object[] {};
        //			return SQLHelper.ExecuteDataTable(spName,para);
        //		}
        //
        //		//培训管理进入修改页面时绑定人员
        //		public static DataTable GetAll_pxgl_ry(int pxglid)
        //		{
        //			string spName = "sp_Rs_Select_pxgl_ry";
        //			object[] para = new object[] { pxglid };
        //			return SQLHelper.ExecuteDataTable(spName,para);
        //		}
        //
        //		//培训管理——人员管理页面——人员绑定
        //		public static DataTable GetAll_pxgl_rygl(string ryxm,string ryzgbh,string rybm,string ryzw,string pxkmmc,string pxzzbm,string pxjb)
        //		{
        //			string spName = "sp_Rs_Select_pxgl_rygl";
        //			object[] para = new object[] { ryxm,ryzgbh,rybm,ryzw,pxkmmc,pxzzbm,pxjb };
        //			return SQLHelper.ExecuteDataTable(spName,para);
        //		}
        //
        //		//培训管理——人员管理详情页面——人员绑定
        //		public static DataTable GetAll_pxgl_ryxq(string ryxm,string ryzgbh,string rybm,string ryzw,string pxkmmc,string pxzzbm,string pxjb)
        //		{
        //			string spName = "sp_Rs_Select_pxgl_ryxq";
        //			object[] para = new object[] { ryxm,ryzgbh,rybm,ryzw,pxkmmc,pxzzbm,pxjb };
        //			return SQLHelper.ExecuteDataTable(spName,para);
        //		}
        //
        //		
        //		public static int Insert_pxgl(string SQL)
        //		{
        //			int iReturn=-1;
        //			Stoke.Components.Database mySQL = new Stoke.Components.Database();
        //			SqlParameter[] parameters = {
        //											
        //											mySQL.MakeInParam("@SQL",SqlDbType.NText,4000,SQL),
        //											
        //			};
        //			try
        //			{
        //				iReturn = mySQL.RunProc("sp_Rs_insert_pxgl",parameters);		
        //			}
        //			catch(Exception e)
        //			{
        //				Stoke.Components.Error.Log(e.ToString());
        //			}
        //			finally
        //			{
        //				mySQL.Close();
        //				mySQL = null;	
        //			}
        //			return iReturn;
        //
        //		}
        //
        //		//将培训管理人员临时表插入正式表
        //		public static int Insert_pxgl_ry(int pxgl_id, string zgbh)
        //		{
        //		
        //			//存储过程名
        //			string spName = "sp_Rs_Insert_pxgl_ry";
        //			//存储过程参数
        //			object[] para = new object[] { pxgl_id, zgbh };
        //			//调用数据访问层的方法访问存储过程
        //			return SQLHelper.ExecuteNonQuery(spName,false,para);
        //		}
        //
        //		//修改培训管理人员临时表
        //		public static  int Update_pxgl_ry_temp (string cj,string zsbh,string bz,int id)
        //		{
        //			
        //			//存储过程名
        //			string spName = "sp_Rs_Update_pxgl_ry_temp";
        //			//存储过程参数
        //			object[] para = new object[] {cj,zsbh,bz,id};
        //			//调用数据访问层的方法访问存储过程
        //			return SQLHelper.ExecuteNonQuery(spName,false,para);
        //	
        //		}
        //
        //		//修改培训管理人员表
        //		public static  int Update_pxgl_ry(string cj,string zsbh,string bz,int id)
        //		{
        //			
        //			//存储过程名
        //			string spName = "sp_Rs_Update_pxgl_ry";
        //			//存储过程参数
        //			object[] para = new object[] {cj,zsbh,bz,id};
        //			//调用数据访问层的方法访问存储过程
        //			return SQLHelper.ExecuteNonQuery(spName,false,para);
        //	
        //		}
        //
        //		//修改培训管理表
        //		public static  int Update_pxgl(string kmmc,string zzbm,string jb,int xs,string pxks,string pxjs,string yxks,string yxjs,int pxglid)
        //		{
        //			
        //			//存储过程名
        //			string spName = "sp_Rs_Update_pxgl";
        //			//存储过程参数
        //			object[] para = new object[] {kmmc,zzbm,jb,xs,pxks,pxjs,yxks,yxjs,pxglid};
        //			//调用数据访问层的方法访问存储过程
        //			return SQLHelper.ExecuteNonQuery(spName,false,para);
        //	
        //		}
        //
        //
        //		//插入培训管理选人临时表
        //		public static int InsertInfo_to_pxgl_ry_temp(string xm,string sex,string zgbh,string bm,string zw,string txrzgbh)
        //		{
        //			int ret = -1;
        //			//存储过程名
        //			string spName = "sp_Rs_Insert_pxgl_ry_Temp";
        //			//存储过程参数
        //			object[] para = new object[] {xm,sex,zgbh,bm,zw,txrzgbh};
        //			//调用数据访问层的方法访问存储过程
        //			ret = SQLHelper.ExecuteNonQuery(spName, false, para);
        //
        //
        //			return ret;
        //		}
        //		
        //		//修改培训管理人员正式表
        //		public static int InsertNew_to_pxgl_ry(string xm,string sex,string zgbh,string bm,string zw,int pxglid)
        //		{
        //			int ret = -1;
        //			//存储过程名
        //			string spName = "sp_Rs_InsertNew_pxgl_ry";
        //			//存储过程参数
        //			object[] para = new object[] {xm,sex,zgbh,bm,zw,pxglid};
        //			//调用数据访问层的方法访问存储过程
        //			ret = SQLHelper.ExecuteNonQuery(spName, false, para);
        //
        //
        //			return ret;
        //		}
        #endregion
        #region 5月22日 wyw
        //根据职工编号判断此人员是否存在于项目组中
        public static int GetXmzFlag(string ry_zgbh)
        {

            //存储过程名
            string spName = "sp_Rs_Get_Xmz_Flag";
            //存储过程参数
            object[] para = new object[] { ry_zgbh };
            //调用数据访问层的方法访问存储过程
            return (int)SQLHelper.ExecuteScalar(spName, para);
        }

        //根据职工编号判断此存在于项目组的人员是否是物资采办部或市场营销部人员
        public static int GetWZYXFlag(string ry_zgbh)
        {

            //存储过程名
            string spName = "sp_Rs_Get_WZ_YX_Flag";
            //存储过程参数
            object[] para = new object[] { ry_zgbh };
            //调用数据访问层的方法访问存储过程
            return (int)SQLHelper.ExecuteScalar(spName, para);
        }
        #endregion
        public static DataTable SelectZwByBm(string bm)//20090603 wyw
        {

            //存储过程名
            string spName = "sp_Rs_Select_Zw_By_bm";
            //存储过程参数
            object[] para = new object[] { bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        #region 6月3日 duan管理技术类绩效考核

        public static DataTable GetAll_gljsl_jh(int id)
        {
            string spName = "sp_Rs_Get_gljsl_jh";
            object[] para = new object[] { id };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //管理类绩效考核——计划信息存档
        public static int InsertJx_gljsl(string nr, string sj, float qz, int docid, int flag)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_InsertJx_gljsl";
            //存储过程参数
            object[] para = new object[] { nr, sj, qz, docid, flag };


            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //修改管理技术类绩效考核正式表
        //		public static  int Update_Jx_gljsl(string nr,string sj,float qz,float bkr,float khr,float fhr,int bh)
        public static int Update_Jx_gljsl(string nr, string sj, string qz, string bkr, string khr, string fhr, int bh)
        {

            //存储过程名
            string spName = "sp_Rs_Update_Jx_gljsl";
            //存储过程参数
            object[] para = new object[] { nr, sj, qz, bkr, khr, fhr, bh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);

        }
        //删除流程实例
        public static int DeleteDocument_jx(int doc_id)
        {
            //存储过程名
            string spName = "sp_Flow_Delete_Document_jx";
            //存储过程参数
            object[] para = new object[] { doc_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        public DataTable GetXmBmZwByZdbh1(string _zdbh)//通过人员编号活得人员姓名、部门、职务(只是部门，没有项目组)
        {
            DataTable table = null;
            object[] _ob = new object[] { _zdbh };
            try
            {
                table = SQLHelper.ExecuteDataTable("sp_Rs_GetXmBmZwbyZgbh1", _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("Staff.GetXmBmByZdbh1(int _zdbh)" + e.Message);
            }
            return table;
        }
        #endregion


        #region 培训管理
        public static DataTable GetAll_pxgl_ry_temp(string txrid)
        {
            string spName = "sp_Rs_Select_pxgl_ry_temp";
            object[] para = new object[] { txrid };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable GetAll2_pxgl_ry_temp(string txrid)
        {
            string spName = "sp_Rs_Select_pxgl_ry_temp2";
            object[] para = new object[] { txrid };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //培训管理页面绑定
        public static DataTable GetAll_pxgl()
        {
            string spName = "sp_Rs_Select_pxgl";
            object[] para = new object[] { };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //培训管理进入修改页面时绑定人员
        public static DataTable GetAll_pxgl_ry(int pxglid)
        {
            string spName = "sp_Rs_Select_pxgl_ry";
            object[] para = new object[] { pxglid };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //培训管理——人员管理页面——人员绑定
        public static DataTable GetAll_pxgl_rygl(string ryxm, string ryzgbh, string rybm, string ryzw, string pxkmmc, string pxzzbm, string pxjb)
        {
            string spName = "sp_Rs_Select_pxgl_rygl";
            object[] para = new object[] { ryxm, ryzgbh, rybm, ryzw, pxkmmc, pxzzbm, pxjb };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //培训管理——人员管理详情页面——人员绑定
        public static DataTable GetAll_pxgl_ryxq(string ryxm, string ryzgbh, string rybm, string ryzw, string pxkmmc, string pxzzbm, string pxjb)
        {
            string spName = "sp_Rs_Select_pxgl_ryxq";
            object[] para = new object[] { ryxm, ryzgbh, rybm, ryzw, pxkmmc, pxzzbm, pxjb };
            return SQLHelper.ExecuteDataTable(spName, para);
        }


        public static int Insert_pxgl(string SQL)
        {
            int iReturn = -1;
            SqlParameter[] parameters = {
											
											SQLHelper.MakeInParam("@SQL",SqlDbType.NText,4000,SQL),
											
			};
            try
            {
                iReturn = SQLHelper.ExecuteNonQuery("sp_Rs_insert_pxgl", false, parameters);
            }
            catch (Exception e)
            {
                Stoke.Components.Error.Log(e.ToString());
            }

            return iReturn;

        }

        //将培训管理人员临时表插入正式表
        public static int Insert_pxgl_ry(int pxgl_id, string zgbh)
        {

            //存储过程名
            string spName = "sp_Rs_Insert_pxgl_ry";
            //存储过程参数
            object[] para = new object[] { pxgl_id, zgbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //修改培训管理人员临时表
        public static int Update_pxgl_ry_temp(string cj, string zsbh, string bz, int id)
        {

            //存储过程名
            string spName = "sp_Rs_Update_pxgl_ry_temp";
            //存储过程参数
            object[] para = new object[] { cj, zsbh, bz, id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);

        }

        //修改培训管理人员表
        public static int Update_pxgl_ry(string cj, string zsbh, string bz, int id)
        {

            //存储过程名
            string spName = "sp_Rs_Update_pxgl_ry";
            //存储过程参数
            object[] para = new object[] { cj, zsbh, bz, id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);

        }

        //修改培训管理表
        public static int Update_pxgl(string kmmc, string zzbm, string jb, int xs, string pxks, string pxjs, string yxks, string yxjs, int pxglid)
        {

            //存储过程名
            string spName = "sp_Rs_Update_pxgl";
            //存储过程参数
            object[] para = new object[] { kmmc, zzbm, jb, xs, pxks, pxjs, yxks, yxjs, pxglid };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);

        }


        //插入培训管理选人临时表
        public static int InsertInfo_to_pxgl_ry_temp(string xm, string sex, string zgbh, string bm, string zw, string txrzgbh)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_pxgl_ry_Temp";
            //存储过程参数
            object[] para = new object[] { xm, sex, zgbh, bm, zw, txrzgbh };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);


            return ret;
        }

        //修改培训管理人员正式表
        public static int InsertNew_to_pxgl_ry(string xm, string sex, string zgbh, string bm, string zw, int pxglid)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_InsertNew_pxgl_ry";
            //存储过程参数
            object[] para = new object[] { xm, sex, zgbh, bm, zw, pxglid };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);


            return ret;
        }
        #endregion

        #region 6月10日 dxq

        //插入新子项目组
        public static int InsertGljslJxkh(string zgbh, string xm, string bm, string gw, int nf, int yf, float zp, float kh, float fh, float zf, string pylx, double xs, int id)
        {
            //存储过程名
            string spName = "sp_Rs_Insert_Gljsl_Jxkh";
            //存储过程参数
            object[] para = new object[] { zgbh, xm, bm, gw, zp, kh, fh, zf, nf, yf, pylx, xs, id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        #endregion
        #region 6月3日以后 wyw
        //根据职工编号获取绩效考核结果
        public static DataTable SelectJxkhByZgbh(string zgbh, int nf, int yf)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Jxkh_By_Zgbh";
            //存储过程参数
            object[] para = new object[] { zgbh, nf, yf };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据职工编号更新doc_id
        public static int UpdateJxkhDocIdByZgbh(string zgbh, int nf, int yf, int doc_id)
        {

            //存储过程名
            string spName = "sp_Rs_Update_Jxkh_Doc_Id_By_Zgbh";
            //存储过程参数
            object[] para = new object[] { zgbh, nf, yf, doc_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //根据doc_id获取绩效考核结果
        public static DataTable SelectJxkhByDocId(int doc_id)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Jxkh_By_Doc_Id";
            //存储过程参数
            object[] para = new object[] { doc_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据年份和月份获取部长级及以上绩效考核结果
        public static DataTable SelectLdjxkhByNfYf(int nf, int yf, string order_flag)
        {

            //存储过程名
            string spName = "sp_Rs_Select_LdJxkh_By_Nf_Yf";
            //存储过程参数
            object[] para = new object[] { nf, yf, order_flag };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据年份、月份和部门获取部长级以下绩效考核结果
        public static DataTable SelectFldjxkhByNfYf(int nf, int yf, string bm, string order_flag)
        {

            //存储过程名
            string spName = "sp_Rs_Select_FldJxkh_By_Nf_Yf";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm, order_flag };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //根据id更新复核分数
        public static int UpdateJxkhFhById(int id, float jxkh_fh, double jxkh_xs, int docid)
        {

            //存储过程名
            string spName = "sp_Rs_Update_Jxkh_Fh_By_Id";
            //存储过程参数
            object[] para = new object[] { id, jxkh_fh, jxkh_xs, docid };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //根据id更新复核分数temp
        public static int UpdateJxkhFhTempById(int id, float jxkh_fh, double jxkh_xs)
        {

            //存储过程名
            string spName = "sp_Rs_Update_Jxkh_Fh_Temp_By_Id";
            //存储过程参数
            object[] para = new object[] { id, jxkh_fh, jxkh_xs };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //获取空dt，产生空行
        public static DataTable SelectNullJxkh()
        {

            //存储过程名
            string spName = "sp_Rs_Select_Null_Jxkh";
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName);
        }

        //根据年份、月份和部门统计绩效系数总和
        public static DataTable StatisticsJxkh(int nf, int yf, string bm, string flag)
        {

            //存储过程名
            string spName = "sp_Rs_Stat_Jxkh";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm, flag };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //部门绩效考核超过1.0的人数
        public static int JxkhBmFhPercent(int nf, int yf, string bm)
        {

            //存储过程名
            string spName = "sp_Rs_Check_FldJxkh_Percent";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm };
            //调用数据访问层的方法访问存储过程
            return (int)SQLHelper.ExecuteScalar(spName, para);
        }

        //部门参加绩效考核的总人数
        public static int JxkhBmFhNum(int nf, int yf, string bm)
        {

            //存储过程名
            string spName = "sp_Rs_Jxkh_Bm_Num";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm };
            //调用数据访问层的方法访问存储过程
            return (int)SQLHelper.ExecuteScalar(spName, para);
        }

        //获取领导层未进行绩效考核的人员名单
        public static DataTable SelectUnfoundLdjxkh(int nf, int yf)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Unfound_LdJxkh";
            //存储过程参数
            object[] para = new object[] { nf, yf };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //获取非领导层未进行绩效考核的人员名单
        public static DataTable SelectUnfoundFldjxkh(int nf, int yf, string bm)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Unfound_FldJxkh";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //获取物资采办部手工添加人员
        public static DataTable SelectWzbHandJxkh(int nf, int yf, string bm, string _zgbh)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Wzb_Hand_Jxkh";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm, _zgbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //插入绩效考核结果temp，手工录入
        public static int InsertGljslJxkhTemp(string zgbh, string xm, string bm, string gw, int nf, int yf, float zp, float kh, float fh, float zf, string pylx, double xs, string _zgbh)
        {
            //存储过程名
            string spName = "sp_Rs_Insert_Gljsl_Jxkh_Temp";
            //存储过程参数
            object[] para = new object[] { zgbh, xm, bm, gw, zp, kh, fh, zf, nf, yf, pylx, xs, _zgbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //删除绩效考核手工录入的分数
        public static int DeleteJxkhTemp(int id)
        {
            //存储过程名
            string spName = "sp_Rs_Delete_Jxkh_Temp";
            //存储过程参数
            object[] para = new object[] { id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //绩效考核结果temp插入正式表
        public static int InsertJxkhFromTemp(int nf, int yf, string bm, string _zgbh)
        {
            //存储过程名
            string spName = "sp_Rs_Insert_Jxkh_From_Temp";
            //存储过程参数
            object[] para = new object[] { nf, yf, bm, _zgbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }
        #endregion
        //6月16日
        //根据聘用类型统计绩效考核结果
        public static DataTable SelectJxkhByPylx(int nf, int yf, string pylx)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Jxkh_By_Pylx";
            //存储过程参数
            object[] para = new object[] { nf, yf, pylx };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }


        //6月18日
        //根据部门或人员统计绩效考核结果
        public static DataTable SelectJxkhByBmRy(int qs_nf, int qs_yf, int jz_nf, int jz_yf, string bm_or_ry, int flag)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Jxkh_By_Bm_Ry";
            //存储过程参数
            object[] para = new object[] { qs_nf, qs_yf, jz_nf, jz_yf, bm_or_ry, flag };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //插入请假开始结束时间，判断重复请假时使用
        public static int InsertQjsp_cfts(string qjsp_zgbh, string qjsp_kssj, string qjsp_jssj)
        {
            //存储过程名
            string spName = "sp_Rs_Insert_Qjsp_cfts";
            //存储过程参数
            object[] para = new object[] { qjsp_zgbh, qjsp_kssj, qjsp_jssj };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //删除请假开始结束时间，判断重复请假时使用
        public static int DeleteQjsp_cfts(string qjsp_zgbh, string qjsp_kssj, string qjsp_jssj)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Delete_Qjsp_cfts";
            //存储过程参数
            object[] para = new object[] { qjsp_zgbh, qjsp_kssj, qjsp_jssj };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }
        public static DataTable RyglByCondition(string bm, string zw, string zgbh, string xm)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Rygl_By_Condition";
            //存储过程参数
            object[] para = new object[] { bm, zw, zgbh, xm };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        public DataTable GetXmBmZwByZdbh_lz(string _zdbh)//通过人员编号活得人员姓名、部门、职务
        {
            DataTable table = null;
            object[] _ob = new object[] { _zdbh };
            try
            {
                table = SQLHelper.ExecuteDataTable("sp_Rs_GetXmBmZwbyZgbh_lz", _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("Staff.GetXmBmByZdbh_lz(int _zdbh)" + e.Message);
            }
            return table;
        }


        //根据id删除人员部门和职位到dsoc_ry_lz表
        public static int DeleteDsocRyByID_lz(int id)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Delete_Dsoc_Ry_By_ID";
            //存储过程参数
            object[] para = new object[] { id };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }


        //根据职工编号获取离职人员部门和职务信息
        public static DataTable SelectRyByZgbh_lz(string ry_zgbh)
        {
            string spName = "sp_Rs_Select_Ry_By_Zgbh_lz";
            object[] para = new object[] { ry_zgbh };
            return SQLHelper.ExecuteDataTable(spName, para);
        }


        //添加人员部门和职位到dsoc_ry_lz表
        public static int InsertDscoRy_lz(
            string ry_zgbh,
            string ry_xm,
            string ry_bm,
            string ry_zw)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_Rs_Insert_Dsoc_Ry_lz";
            //存储过程参数
            object[] para = new object[] {	ry_zgbh,
											 ry_xm ,
											 ry_bm ,
											 ry_zw };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //获取进本单位时间
        public static DataTable GetJbdwsj(string ry_zgbh)
        {
            //存储过程名
            string spName = "getJbdwsj";
            //存储过程参数
            object[] para = new object[] { ry_zgbh };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        /// <summary>
        /// 自动添加请假流程，出差用
        /// </summary>
        /// <param name="ry_zgbh">职工编号</param>
        /// <param name="qjType">请假类别</param>
        /// <param name="startTime">开始时间，格式如"2010-07-10 08:00:00"</param>
        /// <param name="totalDays">总天数</param>
        /// <param name="totalWorkDays">总工作日数</param>
        /// <param name="reason">请假事由</param>
        /// <param name="leaderName">领导姓名</param>
        /// <param name="leaderTime">领导签署时间，格式如"2010-07-10"</param>
        public static void insertNewQjFlow(string ry_zgbh, string qjType, string startTime, int totalDays, int totalWorkDays, string reason, string leaderName, string leaderTime)
        {
            string spName = "getQjBasicInfo";
            object[] para = new object[] { ry_zgbh };

            DataTable dt = SQLHelper.ExecuteDataTable(spName, para);

            if (dt.Rows.Count != 0)
            {
                string name = dt.Rows[0]["ry_xm"].ToString();
                string department = dt.Rows[0]["ry_bm"].ToString();
                string position = dt.Rows[0]["ry_zw"].ToString();
                string birthday = ((dt.Rows[0]["Birthday"] == DBNull.Value) || (DateTime.Parse(dt.Rows[0]["Birthday"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dt.Rows[0]["Birthday"].ToString()).ToString("yyyy-MM-dd");
                string jbdwsj = ((dt.Rows[0]["jbdwsj"] == DBNull.Value) || (DateTime.Parse(dt.Rows[0]["jbdwsj"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dt.Rows[0]["jbdwsj"].ToString()).ToString("yyyy-MM-dd");
                string cjgzsj = ((dt.Rows[0]["cjgzsj"] == DBNull.Value) || (DateTime.Parse(dt.Rows[0]["cjgzsj"].ToString()).Date == DateTime.Parse("1900-1-1").Date)) ? "" : DateTime.Parse(dt.Rows[0]["cjgzsj"].ToString()).ToString("yyyy-MM-dd");

                int njjh = 0;
                int yxts = 0;
                int syts = 0;


                if (cjgzsj != string.Empty)
                {
                    DateTime cjgzsjDateTime = DateTime.Parse(dt.Rows[0]["cjgzsj"].ToString());
                    if (cjgzsjDateTime.AddYears(11) > DateTime.Now)
                    {
                        njjh = 5;
                    }
                    else if (cjgzsjDateTime.AddYears(16) > DateTime.Now)
                    {
                        njjh = 10;
                    }
                    else
                    {
                        njjh = 15;
                    }

                    DataTable dtNj = Stoke.Components.Staff.GetNjjhByZgbh(ry_zgbh, DateTime.Now.Year);
                    if (dtNj.Rows.Count != 0)
                    {
                        yxts = Convert.ToInt32(dtNj.Rows[0]["yxts"]);
                    }
                    else
                    {
                        yxts = 0;
                    }
                    //			syts = njjh > yxts ? njjh - yxts : 0;
                    syts = njjh - yxts;
                }

                DateTime startTimeDateTime = DateTime.Parse(startTime);
                string endTime = startTimeDateTime.AddDays(totalDays).ToString("yyyy-MM-dd hh");

                startTime = startTime.Substring(0, 13);

                string sqlStr = "insert into DSOC_Flow_Style_Data (a,b,c,d,e,f,g,h,i,j,k,l,m,n,i1,s,t,u,a1,j1,e1,f1) "
                    + "values('" + name + "','" + department + "','" + position + "','" + birthday + "','" + jbdwsj + "','" + qjType + "','" + startTime + "','" + endTime + "','" + totalDays + "','" + totalWorkDays + "','" + reason
                    + "','','" + name + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + ry_zgbh + "','" + njjh + "','" + yxts + "','" + syts + "','','" + cjgzsj + "','" + leaderName + "','" + leaderTime + "')";


                //				Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
                //
                //				df.AddDocument(ry_zgbh,4,sqlStr,name.Trim()+"请假申请");
                string obj_id = "0406";

                spName = "sp_Flow_AddDocumentByStepID";
                para = new object[] { ry_zgbh, 4, 5, sqlStr, obj_id, name.Trim() + "请假申请" };

                SQLHelper.ExecuteDataTable(spName, para);
            }
        }
        /// <summary>
        /// 统计所有年假信息，在njxx页面使用
        /// </summary>
        /// <returns></returns>
        public static int Nj_tongji()
        {
            string spName = "sp_nj_tongji";
            object[] para = new object[] { };
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //11.25dxq 新人事统计
        public static DataTable TjByCondition(string bm, string zw, string xb, string ygxz, string xl,
            string zc, string zy, string age1, string age2, string cjgz1, string cjgz2, string jbdw1, string jbdw2,
            string htqs1, string htqs2, string htzz1, string htzz2, string htlb)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Tj_By_Condition1";
            //存储过程参数
            object[] para = new object[] { bm, zw, xb, ygxz, xl, zc, zy, age1, age2, cjgz1, cjgz2, jbdw1, jbdw2, htqs1, htqs2, htzz1, htzz2, htlb };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        /// <summary>
        /// 添加岗位变动情况
        /// </summary>
        /// <param name="ry_zgbh"></param>
        /// <param name="ry_bm"></param>
        /// <param name="ry_zw"></param>
        public static void addGwbd(string ry_zgbh, string ry_xm, string ry_bm, string ry_zw)
        {
            string spName = "sp_addGwbd";
            object[] para = new object[] { ry_zgbh, ry_xm, ry_bm, ry_zw };
            SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        /// <summary>
        /// 按职号获取岗位变动情况
        /// </summary>
        /// <param name="ry_zgbh"></param>
        /// <returns></returns>
        public static DataTable getGwbd(string ry_zgbh)
        {
            string spName = "sp_getGwbd";
            object[] para = new object[] { ry_zgbh };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static void addGwbdByDate(string ry_zgbh, string ry_xm, string ry_bm, string ry_zw, string addedTime)
        {
            string spName = "sp_addGwbdByDate";
            object[] para = new object[] { ry_zgbh, ry_xm, ry_bm, ry_zw, addedTime };
            SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        public static void deleteGwbdByID(int ID)
        {
            string spName = "sp_deleteGwbdByID";
            object[] para = new object[] { ID };
            SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        public static DataTable getHrStatistics(string month)
        {
            string spName = "sp_hrGetStatistics";
            object[] para = new object[] { month };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable getAllJxGljsl(string ry_zgbh, string ry_xm, string ry_bm, string year, string month)
        {
            string spName = "sp_getAllJxGljsl";
            object[] paras = new object[] { ry_zgbh, ry_xm, ry_bm, year, month };
            return SQLHelper.ExecuteDataTable(spName, paras);
        }

        //获得请假审批表
        public static DataTable SelectQjspByZgbhFlagNew(string zgbh, int qjsp_sfxj_flag)
        {

            //存储过程名
            string spName = "sp_Rs_Select_Qjsp_By_Zgbh_Flag_new";
            //存储过程参数
            object[] para = new object[] { zgbh, qjsp_sfxj_flag };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable getNdJxkhByBmAndNf(string bm_mc, string nf)
        {
            string spName = "sp_getNdJxkhByBmAndNf";
            object[] para = new object[] { bm_mc, nf };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable getNdjxkhJb()
        {
            string spName = "sp_getNdjxkhJb";
            return SQLHelper.ExecuteDataTable(spName);
        }

        public static bool updateNdjxkhByID(int ID, double generalScore, double generalScorePercent, double totalScore, string khjb, string khjbfh)
        {
            string spName = "sp_updateNdjxkhByID";
            object[] paras = new object[] { ID, generalScore, generalScorePercent, totalScore, khjb, khjbfh };
            try
            {
                SQLHelper.ExecuteNonQuery(spName, false, paras);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool initialNdJxkhByBmAndNf(string bm_mc, string nf)
        {
            string spName = "sp_initialNdJxkhByBmAndNf";
            object[] paras = new object[] { bm_mc, nf };
            try
            {
                SQLHelper.ExecuteNonQuery(spName, false, paras);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static DataTable getNdjxkhjbPercent(string ry_bm, string jxkh_nf)
        {
            string spName = "sp_getNdjxkhjbPercent";
            object[] paras = new object[] { ry_bm, jxkh_nf };
            return SQLHelper.ExecuteDataTable(spName, paras);
        }

        public static bool updateNdjxkhfh(int ID, string khjbfh)
        {
            string spName = "sp_updateNdjxkhfh";
            object[] paras = new object[] { ID, khjbfh };
            try
            {
                SQLHelper.ExecuteNonQuery(spName, false, paras);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool updateNdjxkhjbInfo(int ID, double jxkh_jb_down, double jxkh_jb_up, double jxkh_jb_percent)
        {
            string spName = "sp_updateNdjxkhjbInfo";
            object[] paras = new object[] { ID, jxkh_jb_down, jxkh_jb_up, jxkh_jb_percent };
            try
            {
                SQLHelper.ExecuteNonQuery(spName, false, paras);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool handNjxx(string ry_zgbh, int njjh, int yxts, int syts, int nj_year)
        {
            string spName = "sp_hand_njxx";
            object[] paras = new object[] { ry_zgbh, njjh, yxts, syts, nj_year };
            try
            {
                SQLHelper.ExecuteNonQuery(spName, false, paras);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        public bool Rehab(string StaffIDS)
        {
            if (StaffIDS.Length > 0)
            {
                SqlParameter[] prams = {
										   SQLHelper.MakeInParam("@StaffIDS",SqlDbType.VarChar,300,StaffIDS.ToString())
									   };
                return SQLHelper.ExecuteNonQuery("sp_StaffRehab", false, prams) == 0 ? true : false;
            }
            else
                return false;
        }

        public SqlDataReader GetAllStaffs()
        {
            SqlDataReader dataReader = null;
            try
            {
                // run the stored procedure
                dataReader = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.StoredProcedure, "sp_GetAllStaff");
                //data.RunProc("sp_GetAllStaff", out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("人员信息读取出错!", ex);
            }
        }
    }
}
