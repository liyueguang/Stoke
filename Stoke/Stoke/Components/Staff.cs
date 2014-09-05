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
    /// Staff ������
    /// </summary>
    public class Staff
    {

        #region ��ȡ�û�������Ϣ
        /// <summary>
        /// ��ȡ�û�������Ϣ
        /// </summary>
        /// <param name="StaffID">�û�ID</param>
        /// <returns>����DataReader</returns>
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
                throw new Exception("��Ա��Ϣ��ȡ����!", ex);
            }

        }
        #endregion

        #region ��Ա����
        /// <summary>
        /// ��Ա����
        /// </summary>
        /// <param name="StaffID">��ԱID</param>
        /// <returns>�����Ƿ�ɹ�</returns>
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
        /// �޸��ֻ���
        /// </summary>
        /// <param name="StaffID">��ԱID</param>
        /// <returns>�����Ƿ�ɹ�</returns>
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

        public DataTable GetXmBmZwByZdbh(string _zgbh)//ͨ����Ա��Ż����Ա���������š�ְ��
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

        //�����Ϣ�浵
        public static int InsertQjsp(string qjsp_zgbh, string qjsp_xm, string qjsp_bm, string qjsp_zw, string qjsp_cssj, string qjsp_gssj, string qjsp_qjlb, string qjsp_kssj, string qjsp_jssj,
        string qjsp_qjts, string qjsp_gzr, string qjsp_qjsy, string qjsp_dlr, string qjsp_qjrq, string qjsp_kqzrr, string qjsp_kqzrr_rq,
        string qjsp_bmfzr, string qjsp_bmfzr_rq, int qjsp_jhts, int qjsp_yxts, int qjsp_bcts, string qjsp_lxdh, string qjsp_qt, string qjsp_zhglbjbr, string qjsp_zhglbjbr_rq, string qjsp_gszgld, string qjsp_gszgld_rq, string qjsp_zjlsp, string qjsp_zjlsp_rq, int doc_id)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Qjsp";
            //�洢���̲���
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
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName, parms);

            return ret;
        }

        //������Ϣ�浵
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
            //�洢������
            string spName = "sp_Rs_Insert_Xjsp";
            //�洢���̲���
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
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }
        //Ա�������浵
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
            //�洢������
            string spName = "sp_Rs_Insert_Ygddsp";
            //�洢���̲���
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
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //Ա�������浵����
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
            //�洢������
            string spName = "sp_Rs_Update_Ygddsp";
            //�洢���̲���
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
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��ְ�ǼǴ浵
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
            //�洢������
            string spName = "sp_Rs_Insert_Rzdj";
            //�洢���̲���
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
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��ְ�浵
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
            //�洢������
            string spName = "sp_Rs_Insert_Ygdlsp";
            //�洢���̲���
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
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��Աָ��浵
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
            //�洢������
            string spName = "sp_Rs_Insert_Zyzbsp";
            //�洢���̲���
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
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��ӽ�����������ʱ��
        public static int InsertQzspJyjlTemp(string qzsp_jy_kssj,
            string qzsp_jy_jssj,
            string qzsp_jy_xx,
            string qzsp_jy_zy,
            string qzsp_jy_xxxs,
            string qzsp_jy_hdzs)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Qzsp_Jyjl_Temp";
            //�洢���̲���
            object[] para = new object[] {qzsp_jy_kssj,
											 qzsp_jy_jssj,
											 qzsp_jy_xx,
											 qzsp_jy_zy,
											 qzsp_jy_xxxs,
											 qzsp_jy_hdzs};
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��ӹ�����������ʱ��
        public static int InsertQzspGzjlTemp(string qzsp_gz_kssj,
            string qzsp_gz_jssj,
            string qzsp_gz_gzdw,
            string qzsp_gz_lxdh,
            string qzsp_gz_bm_zw,
            string qzsp_gz_srqk,
            string qzsp_gz_lzyy)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Qzsp_Gzjl_Temp";
            //�洢���̲���
            object[] para = new object[] {qzsp_gz_kssj ,
											 qzsp_gz_jssj ,
											 qzsp_gz_gzdw ,
											 qzsp_gz_lxdh ,
											 qzsp_gz_bm_zw ,
											 qzsp_gz_srqk ,
											 qzsp_gz_lzyy };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��Ӽ�ͥ��ϵ����ʱ��
        public static int InsertQzspJtgxTemp(string qzsp_jt_xm,
            string qzsp_jt_nl,
            string qzsp_jt_gx,
            string qzsp_jt_dw_zw)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Qzsp_Jtgx_Temp";
            //�洢���̲���
            object[] para = new object[] {qzsp_jt_xm ,
											 qzsp_jt_nl ,
											 qzsp_jt_gx ,
											 qzsp_jt_dw_zw };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��ӽ�����������ʽ��
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
            //�洢������
            string spName = "sp_Rs_Insert_Qzsp_Jyjl";
            //�洢���̲���
            object[] para = new object[] {doc_id,
											 qzsp_jy_kssj,
											 qzsp_jy_jssj,
											 qzsp_jy_xx,
											 qzsp_jy_zy,
											 qzsp_jy_xxxs,
											 qzsp_jy_hdzs};
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��ӹ�����������ʽ��
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
            //�洢������
            string spName = "sp_Rs_Insert_Qzsp_Gzjl";
            //�洢���̲���
            object[] para = new object[] {doc_id,
											 qzsp_gz_kssj ,
											 qzsp_gz_jssj ,
											 qzsp_gz_gzdw ,
											 qzsp_gz_lxdh ,
											 qzsp_gz_bm_zw ,
											 qzsp_gz_srqk ,
											 qzsp_gz_lzyy };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��Ӽ�ͥ��ϵ����ʽ��
        public static int InsertQzspJtgx(int doc_id,
            string qzsp_jt_xm,
            string qzsp_jt_nl,
            string qzsp_jt_gx,
            string qzsp_jt_dw_zw)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Qzsp_Jtgx";
            //�洢���̲���
            object[] para = new object[] {doc_id,
											 qzsp_jt_xm ,
											 qzsp_jt_nl ,
											 qzsp_jt_gx ,
											 qzsp_jt_dw_zw };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��ý���������ʱ��
        public static DataTable SelectQzspJyjlTemp()
        {

            //�洢������
            string spName = "sp_Rs_Select_Qzsp_Jyjl_Temp";
            //			//�洢���̲���
            //			object[] para = new object[] {flow_id, step_id};
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName);
        }

        //��ù���������ʱ��
        public static DataTable SelectQzspGzjlTemp()
        {

            //�洢������
            string spName = "sp_Rs_Select_Qzsp_Gzjl_Temp";
            //			//�洢���̲���
            //			object[] para = new object[] {flow_id, step_id};
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName);
        }

        //��ü�ͥ��ϵ��ʱ��
        public static DataTable SelectQzspJtgxTemp()
        {

            //�洢������
            string spName = "sp_Rs_Select_Qzsp_Jtgx_Temp";
            //			//�洢���̲���
            //			object[] para = new object[] {flow_id, step_id};
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName);
        }

        //��ý���������
        public static DataTable SelectQzspJyjlByDocId(int doc_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Qzsp_Jyjl_By_Doc_Id";
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, spName, 
                new SqlParameter("@qzsp_id", doc_id));
        }

        //��ù���������
        public static DataTable SelectQzspGzjlByDocId(int doc_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Qzsp_Gzjl_By_Doc_Id";
            //�洢���̲���
            object[] para = new object[] { doc_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //��ü�ͥ��ϵ��
        public static DataTable SelectQzspJtgxByDocId(int doc_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Qzsp_Jtgx_By_Doc_Id";
            //�洢���̲���
            object[] para = new object[] { doc_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //ɾ������������ʱ������ȡ�ձ�
        public static DataTable DeleteQzspJyjlTemp()
        {
            //�洢������
            string spName = "sp_Rs_Delete_Qzsp_Jyjl_Temp";
            //�洢���̲���
            object[] para = new object[] { };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        //ɾ������������ʱ������ȡ�ձ�
        public static DataTable DeleteQzspGzjlTemp()
        {
            //�洢������
            string spName = "sp_Rs_Delete_Qzsp_Gzjl_Temp";
            //�洢���̲���
            object[] para = new object[] { };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        //ɾ����ͥ��ʱ������ȡ�ձ�
        public static DataTable DeleteQzspJtgxTemp()
        {
            //�洢������
            string spName = "sp_Rs_Delete_Qzsp_Jtgx_Temp";
            //�洢���̲���
            object[] para = new object[] { };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);

        }

        //ɾ������������ʱ������ȡʣ���¼
        public static DataTable DeleteQzspJyjlTempById(int id)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Qzsp_Jyjl_Temp_By_Id";
            //�洢���̲���
            object[] para = new object[] { id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        //ɾ������������ʱ������ȡʣ���¼
        public static DataTable DeleteQzspGzjlTempById(int id)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Qzsp_Gzjl_Temp_By_Id";
            //�洢���̲���
            object[] para = new object[] { id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        //ɾ����ͥ��ʱ������ȡʣ���¼
        public static DataTable DeleteQzspJtgxTempById(int id)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Qzsp_Jtgx_Temp_By_Id";
            //�洢���̲���
            object[] para = new object[] { id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);

        }

        //��ְ�����浵
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
            //�洢������
            string spName = "sp_Rs_Insert_Qzsp";
            //�洢���̲���
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
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��ְ�����浵���º󲿷�
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
            //�洢������
            string spName = "sp_Rs_Update_Qzsp";
            //�洢���̲���
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
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //������������
        public static DataTable SelectQjspByZgbhFlag(string zgbh, int qjsp_sfxj_flag)
        {

            //�洢������
            string spName = "sp_Rs_Select_Qjsp_By_Zgbh_Flag";
            //�洢���̲���
            object[] para = new object[] { zgbh, qjsp_sfxj_flag };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //�������������
        public static DataTable SelectXjspByZgbh(string zgbh)
        {

            //�洢������
            string spName = "sp_Rs_Select_Xjsp_By_Zgbh";
            //�洢���̲���
            object[] para = new object[] { zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ݲ�ѯ���������ٻ�������������
        public static DataTable SelectQjXjByCondition(string xm, string zgbh, string bm, string qjlb, int DisplayType, string qjbh)
        {

            //�洢������
            string spName = "sp_Rs_Select_Qj_Xj_By_Condition";
            //�洢���̲���
            object[] para = new object[] { xm, zgbh, bm, qjlb, DisplayType, qjbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ݲ�ѯ�������Ա������������
        public static DataTable SelectYgddspByCondition(string xm, string zgbh, string ddsj, string ybm, string xbm, string yzw, string xzw, int DisplayType)
        {

            //�洢������
            string spName = "sp_Rs_Select_Ygddsp_By_Condition";
            //�洢���̲���
            object[] para = new object[] { xm, zgbh, ddsj, ybm, xbm, yzw, xzw, DisplayType };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ݲ�ѯ�������Ա������������
        public static DataTable SelectYgdlspByCondition(string xm, string zgbh, string dlsj, string bm, int DisplayType)
        {

            //�洢������
            string spName = "sp_Rs_Select_Ygdlsp_By_Condition";
            //�洢���̲���
            object[] para = new object[] { xm, zgbh, dlsj, bm, DisplayType };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //����Id����Ա������������flag,���Ҹ���dsoc_ry�Ĳ��ź�ְλ
        public static int UpdateYgddspFlagById(int ygddsp_id, string zgbh, string ybm, string xbm, string yzw, string xzw, int xmz_y, int xmz_x, string xm)
        {

            //�洢������
            string spName = "sp_Rs_Update_Ygddsp_Flag_By_Id";
            //�洢���̲���
            object[] para = new object[] { ygddsp_id, zgbh, ybm, xbm, yzw, xzw, xmz_y, xmz_x, xm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //����Id����Ա������������flag,���Ҹ���rs_staff��־λDismission
        public static int UpdateYgdlspFlagAndStaffDismissionById(int ygddsp_id, string zgbh)
        {

            //�洢������
            string spName = "sp_Rs_Update_Ygddsp_Flag_Staff_Dimission_By_Id";
            //�洢���̲���
            object[] para = new object[] { ygddsp_id, zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //����Ա��Ϣ�����������ѯ
        public static DataTable SelectStaffByCondition(string xm, string zgbh, string xb, string zw, string bm, int DisplayType)
        {

            //�洢������
            string spName = "sp_Rs_Select_Staff_By_Condition";
            //�洢���̲���
            object[] para = new object[] { xm, zgbh, xb, zw, bm, DisplayType };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ݲ��Ż�ȡdsoc_ry��
        public static DataTable GetRyByBm(string bm_mc)
        {
            //�洢������
            string spName = "sp_Rs_Ry_By_Bm";
            //�洢���̲���
            object[] para = new object[] { bm_mc };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ݲ��Ż�ȡdsoc_ry���е�ry_zgbh
        public static DataTable GetRyZgbhByBm(string bm_mc)
        {
            //�洢������
            string spName = "sp_Rs_Ry_Zgbh_By_Bm";
            //�洢���̲���
            object[] para = new object[] { bm_mc };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }//sp_Rs_Ry_By_Bm_Bh

        //���ݲ���ɾ��dsoc_ry��
        public static int DeleteRyByBm(string bm_mc)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Ry_By_Bm";
            //�洢���̲���
            object[] para = new object[] { bm_mc };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //���ݲ��ź�ְ�����ɾ��dsoc_ry��
        public static int DeleteRyByZgbhBm(string ry_zgbh, string bm_mc)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Ry_By_Zgbh_Bm";
            //�洢���̲���
            object[] para = new object[] { ry_zgbh, bm_mc };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //���ݲ�������ɾ���˲���
        public static int DeleteBmByBm(string bm_mc)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Bm_By_Bm";
            //�洢���̲���
            object[] para = new object[] { bm_mc };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //ɾ��ԭ��¼���������Ա���ź�ְλ��dsoc_ry��
        public static int InsertDscoRy2(
            string ry_zgbh,
            string ry_xm,
            string ry_bm,
            string ry_zw)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Dsoc_Ry2";
            //�洢���̲���
            object[] para = new object[] {	ry_zgbh,
											 ry_xm ,
											 ry_bm ,
											 ry_zw };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //�����Ա���ź�ְλ��dsoc_ry��
        public static int InsertDscoRy(
            string ry_zgbh,
            string ry_xm,
            string ry_bm,
            string ry_zw)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Dsoc_Ry";
            //�洢���̲���
            object[] para = new object[] {	ry_zgbh,
											ry_xm ,
											ry_bm ,
											ry_zw };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }


        //ɾ����Ա���ź�ְλ��dsoc_ry��
        public static int DeleteDsocRyByZgbh(string ry_zgbh)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Delete_Dsoc_Ry_By_Zgbh";
            //�洢���̲���
            object[] para = new object[] { ry_zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //����idɾ����Ա���ź�ְλ��dsoc_ry��
        public static int DeleteDsocRyByID(int id)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Delete_Dsoc_Ry_By_ID";
            //�洢���̲���
            object[] para = new object[] { id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //����idɾ����Ա���ź�ְλ��dsoc_ry_temp��
        public static int DeleteDsocRyTempByID(int id)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Delete_Dsoc_Ry_Temp_By_ID";
            //�洢���̲���
            object[] para = new object[] { id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //�޸���Ա���ź�ְλ��dsoc_ry��
        public static int UpdateDsocRy(string ry_zgbh,
            string ry_xm,
            string ry_bm,
            string ry_zw)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Update_Dsoc_Ry";
            //�洢���̲���
            object[] para = new object[] {ry_zgbh,
											 ry_xm ,
											 ry_bm ,
											 ry_zw };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //DisplayType��ȡ��ְ������Ϣ
        public static DataTable SelectQzsp(int DisplayType)
        {

            //�洢������
            string spName = "sp_Rs_Select_Qzsp";
            //�洢���̲���
            object[] para = new object[] { DisplayType };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //ͨ��qzsp_id��ȡ��ְ������Ϣ
        public static DataTable SelectQzspById(int qzsp_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Qzsp_By_Id";
            //�洢���̲���
            object[] para = new object[] { qzsp_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //ɾ������֪ͨ����Ա������ʱ��
        public static DataTable DeleteRstzdRymdTemp()
        {

            //�洢������
            string spName = "sp_Rs_Delete_Rstzd_Rymd_Temp";
            //�洢���̲���
            object[] para = new object[] { };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //�������֪ͨ����Ա������ʱ������ȡ����ȫ����¼
        public static DataTable InsertSelectRstzdRymdTemp(string ry_zgbh,
            string ry_xm,
            string ry_bm)
        {
            //�洢������
            string spName = "sp_Rs_Insert_Select_Rstzd_Rymd_Temp";
            //�洢���̲���
            object[] para = new object[] {ry_zgbh,
											 ry_xm ,
											 ry_bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para); ;
        }

        //�������֪ͨ����Ա������ʱ������ȡ����ȫ����¼
        public static DataTable SelectRstzdRymdTemp()
        {
            //�洢������
            string spName = "sp_Rs_Select_Rstzd_Rymd_Temp";
            //�洢���̲���
            object[] para = new object[] { };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para); ;
        }
        //�޸���Ա������Ϣ��rstzd��Ա������ʱ��
        public static int UpdateRstzdRymdTemp(int zdbh, string gwdj, string jbgz, string gdgz, string qtgz, string fxbzj, string bm, int zzgx)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Update_Rstzd_Rymd_Temp";
            //�洢���̲���
            object[] para = new object[] { zdbh, gwdj, jbgz, gdgz, qtgz, fxbzj, bm, zzgx };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //�޸���Ա������Ϣ��rstzd��Ա������
        public static int UpdateRstzdRymd(int zdbh, string gwdj, string jbgz, string gdgz, string qtgz, string fxbzj, string bm, int zzgx)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Update_Rstzd_Rymd";
            //�洢���̲���
            object[] para = new object[] { zdbh, gwdj, jbgz, gdgz, qtgz, fxbzj, bm, zzgx };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //2130//�޸���Ա������Ϣ��rstzd��Ա������ʱ��
        public static int UpdateRstzdRymdTemp2(int zdbh, string ybm, string ygw, string xgw, string ygwdj, string gwdj, string jbgz, string gdgz, string qtgz, string yfxbzj, string fxbzj, string bm, int flag, string bmdd, int zzgx)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Update_Rstzd_Rymd_Temp2";
            //�洢���̲���
            object[] para = new object[] { zdbh, ybm, ygw, xgw, ygwdj, gwdj, jbgz, gdgz, qtgz, yfxbzj, fxbzj, bm, flag, bmdd, zzgx };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;

        }

        //		//�޸���Ա������Ϣ��rstzd��Ա������ʱ��
        //		public static int UpdateRstzdRymdTemp(int zdbh,string gwdj ,string jbgz ,string gdgz ,string qtgz ,string fxbzj,string bm)
        //		{
        //			int ret = -1;
        //			//�洢������
        //			string spName = "sp_Rs_Update_Rstzd_Rymd_Temp";
        //			//�洢���̲���
        //			object[] para = new object[] { zdbh, gwdj , jbgz , gdgz , qtgz , fxbzj,bm };
        //			//�������ݷ��ʲ�ķ������ʴ洢����
        //			ret = SQLHelper.ExecuteNonQuery(spName,false,para);
        //
        //			return ret;
        //		}

        //�޸���Ա������Ϣ��rstzd��Ա������
        //		public static int UpdateRstzdRymd(int zdbh,string gwdj ,string jbgz ,string gdgz ,string qtgz ,string fxbzj,string bm)
        //		{
        //			int ret = -1;
        //			//�洢������
        //			string spName = "sp_Rs_Update_Rstzd_Rymd";
        //			//�洢���̲���
        //			object[] para = new object[] { zdbh, gwdj , jbgz , gdgz , qtgz , fxbzj ,bm};
        //			//�������ݷ��ʲ�ķ������ʴ洢����
        //			ret = SQLHelper.ExecuteNonQuery(spName,false,para);
        //
        //			return ret;
        //		}

        //2130//�޸���Ա������Ϣ��rstzd��Ա������ʱ��
        //		public static int UpdateRstzdRymdTemp2(int zdbh,string ybm,string ygw,string xgw,string ygwdj,string gwdj,string jbgz ,string gdgz ,string qtgz ,string yfxbzj , string fxbzj,string bm,int flag,string bmdd)
        //		{
        //			int ret = -1;
        //			//�洢������
        //			string spName = "sp_Rs_Update_Rstzd_Rymd_Temp2";
        //			//�洢���̲���
        //			object[] para = new object[] { zdbh,ybm,ygw,xgw,ygwdj,gwdj,jbgz,gdgz,qtgz,yfxbzj,fxbzj,bm,flag,bmdd};
        //			//�������ݷ��ʲ�ķ������ʴ洢����
        //			ret = SQLHelper.ExecuteNonQuery(spName,false,para);
        //
        //			return ret;
        //
        //		}

        //		//2144�޸���Ա������Ϣ��rstzd��Ա������
        //		public static int UpdateRstzdRymd2(int zdbh,string ybm,string ygw,string xgw,string ygwdj,string gwdj,string jbgz ,string gdgz ,string qtgz ,string yfxbzj , string fxbzj,string bm,int flag,string bmdd)
        //		{
        //			int ret = -1;
        //			//�洢������
        //			string spName = "sp_Rs_Update_Rstzd_Rymd2";
        //			//�洢���̲���
        //			object[] para = new object[] { zdbh,ybm,ygw,xgw,ygwdj,gwdj,jbgz,gdgz,qtgz,yfxbzj,fxbzj,bm,flag,bmdd };
        //			//�������ݷ��ʲ�ķ������ʴ洢����
        //			ret = SQLHelper.ExecuteNonQuery(spName,false,para);
        //
        //			return ret;
        //		}

        //2144�޸���Ա������Ϣ��rstzd��Ա������
        public static int UpdateRstzdRymd2(int zdbh, string ybm, string ygw, string xgw, string ygwdj, string gwdj, string jbgz, string gdgz, string qtgz, string yfxbzj, string fxbzj, string bm, int flag, string bmdd, int zzgx)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Update_Rstzd_Rymd2";
            //�洢���̲���
            object[] para = new object[] { zdbh, ybm, ygw, xgw, ygwdj, gwdj, jbgz, gdgz, qtgz, yfxbzj, fxbzj, bm, flag, bmdd, zzgx };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }
        //�޸���Ա������Ϣ��rstzd��Ա������ʱ��
        public static int UpdateRstzdRymdTemp3(int zdbh, string txsj, string txylj, string bm)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Update_Rstzd_Rymd_Temp3";
            //�洢���̲���
            object[] para = new object[] { zdbh, txsj, txylj, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //�޸���Ա������Ϣ��rstzd��Ա������
        public static int UpdateRstzdRymd3(int zdbh, string txsj, string txylj, string bm)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Update_Rstzd_Rymd3";
            //�洢���̲���
            object[] para = new object[] { zdbh, txsj, txylj, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }


        //ɾ��rstzd��Ա������ʱ����ĳ����¼,����ȡʣ���¼
        public static DataTable DeleteRstzdRymdTempByZdbh(int zdbh)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Rstzd_Rymd_Temp_by_Zdbh";
            //�洢���̲���
            object[] para = new object[] { zdbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);

        }//sp_Rs_Insert_Rstzd

        //ɾ��rstzd��Ա������ʱ����ĳ����¼
        public static int DeleteRstzdRymdTempByZdbh2(int zdbh)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Rstzd_Rymd_Temp_by_Zdbh2";
            //�洢���̲���
            object[] para = new object[] { zdbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);

        }

        //ɾ��rstzd��Ա��������ĳ����¼
        public static int DeleteRstzdRymdByZdbh2(int zdbh)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Rstzd_Rymd_by_Zdbh2";
            //�洢���̲���
            object[] para = new object[] { zdbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);

        }


        //����rstzd
        public static int InsertRstzd(int rstzd_id, int rstzd_fblx, string rstzd_bh, string rstzd_sy, string rstzd_nr, string rstzd_jbr, string rstzd_bmfzr, string rstzd_zgfz, string rstzd_zjl, string rstzd_rq)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Rstzd";
            //�洢���̲���
            object[] para = new object[] { rstzd_id, rstzd_fblx, rstzd_bh, rstzd_sy, rstzd_nr, rstzd_jbr, rstzd_bmfzr, rstzd_zgfz, rstzd_zjl, rstzd_rq };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }



        //����rs_tj
        public static int InsertRstj(string bm, int num, int M_num, int PM_num, int FP_num,
            int JY_num, int W_num, int PZ_num, int syhj_num, int bdrs_num, string bdxq, string nf, string yf, string rq, string bz)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Rstj";
            //�洢���̲���
            object[] para = new object[] {  bm,num,M_num,PM_num,FP_num,
											 JY_num,W_num,PZ_num,syhj_num,bdrs_num,bdxq,nf,yf,rq,bz};
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //		//���ݲ�ѯ�����������֪ͨ��
        //			 public static DataTable SelectRstzdByCondition(int nf, int yf, int tzfl)
        //			 {	
        //				 //�洢������
        //				 string spName = "sp_Rs_Select_Rstzd_By_Condition";
        //				 //�洢���̲���
        //				 object[] para = new object[] {  nf, yf, tzfl };
        //				 //�������ݷ��ʲ�ķ������ʴ洢����
        //				 return SQLHelper.ExecuteDataTable(spName,para);
        //			 }

        //���ݲ�ѯ�����������֪ͨ��
        public static DataTable SelectRstzdByCondition(int nf, int yf, int tzfl, string ry_xm, string ry_bm, string nr)
        {
            //�洢������
            string spName = "sp_Rs_Select_Rstzd_By_Condition";
            //�洢���̲���
            object[] para = new object[] { nf, yf, tzfl, ry_xm, ry_bm, nr };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }


        //����id�������֪ͨ��
        public static DataTable SelectRstzdById(int rstzd_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Rstzd_By_Id";
            //�洢���̲���
            object[] para = new object[] { rstzd_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //����id�������֪ͨ����Ա����
        public static DataTable SelectRstzdRymdById(int doc_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Rstzd_Rymd_By_Id";
            //�洢���̲���
            object[] para = new object[] { doc_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //����id�������֪ͨ����Ա������������ʱ����
        //���̷��ص�һ��ʱִ��
        public static DataTable SelectRstzdRymdTempByDocId(int rstzd_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Rstzd_Rymd_Temp_By_Doc_Id";
            //�洢���̲���
            object[] para = new object[] { rstzd_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static int InsertInfo_to_wtsp_temp(string str0, string str1, string str2, string str3)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Wtspnr_Temp";
            //�洢���̲���
            object[] para = new object[] { str0, str1, str2, str3 };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);


            return ret;
        }

        //����wtsp����
        public static int InsertInfo_to_wtspnr(int wtsp_id, string str1, string str2, string str3)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Wtspnr";
            //�洢���̲���
            object[] para = new object[] { wtsp_id, str1, str2, str3 };
            //�������ݷ��ʲ�ķ������ʴ洢����
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
            //�洢������
            string spName = "sp_Rs_Delete_Wtspnr_temp_ById";
            //�洢���̲���
            object[] para = new object[] { str };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);


            return ret;
        }

        public static int DeleteInfoFromWtsp(int id)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Delete_Wtspnr_By_Id";
            //�洢���̲���
            object[] para = new object[] { id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);


            return ret;
        }

        public static DataTable GetAll2_wtsp_temp(string zgbh)
        {
            string spName = "sp_Rs_DeleteAndSelect_Wtspnr_temp";
            //�洢���̲���
            object[] para = new object[] { zgbh };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //����doc_id��ȡί����������
        public static DataTable SelectWtspnrById(int wtsp_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Wtspnr_By_Id";
            //�洢���̲���
            object[] para = new object[] { wtsp_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //����id��ȡί���������ݲ�ת�Ƶ���ʱ����
        //���̴�ص���һ��ʱִ��
        public static DataTable SelectWtspnrTempByDocId(int wtsp_id, string zgbh)
        {

            //�洢������
            string spName = "sp_Rs_Select_Wtspnr_Temp_By_Doc_Id";
            //�洢���̲���
            object[] para = new object[] { wtsp_id, zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //����ʱ�����ί����������
        public static int InsertWtspnrById(int wtsp_id, string zgbh)
        {

            //�洢������
            string spName = "sp_Rs_Insert_Wtspnr_By_Id";
            //�洢���̲���
            object[] para = new object[] { wtsp_id, zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //ί����Ȩ�����浵
        public static int InsertWtsp(int wtsp_id, string wtsp_wtr, DateTime wtsp_kssj, DateTime wtsp_jssj, string wtsp_fzr, string zgld)
        {

            //�洢������
            string spName = "sp_Rs_Insert_Wtsp";
            //�洢���̲���
            object[] para = new object[] { wtsp_id, wtsp_wtr, wtsp_kssj, wtsp_jssj, wtsp_fzr, zgld };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //Ա����ְ���ͳ��
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

        //Ա����ְ��Ա����
        public static DataTable ReportYgddRzRy(int nf, int yf, string bm)
        {

            //�洢������
            string spName = "sp_Rs_Report_Rz_Ry";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable ReportYgddRzRy1(int nf, int yf, string bm)
        {

            //�洢������
            string spName = "sp_Rs_Report_Rz_Ry1";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //Ա����ְ���ͳ��
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

        //Ա����ְ��Ա����
        public static DataTable ReportYgddLzRy(int nf, int yf, string bm)
        {

            //�洢������
            string spName = "sp_Rs_Report_Lz_Ry";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable ReportYgddLzRy1(int nf, int yf, string bm)
        {

            //�洢������
            string spName = "sp_Rs_Report_Lz_Ry1";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ŵ������ͳ��
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

        //���ŵ�����Ա����
        public static DataTable ReportYgddDrRy(int nf, int yf, string bm)
        {

            //�洢������
            string spName = "sp_Rs_Report_Dr_Ry";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable ReportYgddDrRy1(int nf, int yf, string bm)
        {

            //�洢������
            string spName = "sp_Rs_Report_Dr_Ry1";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ŵ������ͳ��
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

        //���ŵ�����Ա����
        public static DataTable ReportYgddDlRy(int nf, int yf, string bm)
        {

            //�洢������
            string spName = "sp_Rs_Report_Dl_Ry";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable ReportYgddDlRy1(int nf, int yf, string bm)
        {

            //�洢������
            string spName = "sp_Rs_Report_Dl_Ry1";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ݸ��ڵ��ú��ӽڵ�
        public static DataTable GetSubZw(string PositionID)
        {

            //�洢������
            string spName = "sp_GetSubZw";
            //�洢���̲���
            object[] para = new object[] { PositionID };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //ְ�������ڵ�
        public static DataTable GetRootZw(string org_id)
        {
            string spName = "sp_GetRootZw";
            object[] para = new object[] { org_id };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ݽڵ�org_id�����Ա��Ϣ
        public static DataTable GetRyByTreeId(string tree_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Ry_By_Zw";
            //�洢���̲���
            object[] para = new object[] { tree_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //����org_id�����Աְ����ź�����
        public static DataTable GetRyByOrgId(string org_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Ry_By_Org_Id";
            //�洢���̲���
            object[] para = new object[] { org_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ݲ��ű�Ż�ò�����Ա��Ϣ
        public static DataTable GetRyByBmBh(int bm_bh)
        {

            //�洢������
            string spName = "sp_Rs_Select_Ry_By_Bm_Bh";
            //�洢���̲���
            object[] para = new object[] { bm_bh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }//

        //���ݸ��ڵ��ú��ӽڵ�
        public static DataTable GetOrganizeByTreeId(string tree_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Organize_By_Tree_Id";
            //�洢���̲���
            object[] para = new object[] { tree_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }//

        //���ݽڵ�Ż�ȡ�Ľڵ���Ϣ
        public static DataTable GetZwByTreeId(int tree_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Zw_Tree_By_Id";
            //�洢���̲���
            object[] para = new object[] { tree_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���Ҷ�ӽڵ�
        public static int InsertZwTree(string bm_mc, string zw_mc, string parent_zw_mc, int parent_tree_id)
        {
            //�洢������
            string spName = "sp_Rs_Insert_Zw_Tree";
            //�洢���̲���
            object[] para = new object[] { bm_mc, zw_mc, parent_zw_mc, parent_tree_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //ɾ��ְλ��Ҷ�ӽڵ�
        public static int DeleteZwTree(long tree_id)
        {
            SqlParameter[] prams = {
									   SQLHelper.MakeInParam("@tree_id",SqlDbType.Int,4,tree_id)
								   };
            return (SQLHelper.ExecuteNonQuery("sp_Rs_Delete_Position", false, prams));
        }

        //sp_Rs_Insert_Qzsp_Qzjl
        //��ְ��������ְ�����浵
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

            //�洢������
            string spName = "sp_Rs_Insert_Qzsp_Qzjl";
            //�洢���̲���
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
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //��ְ��������ְ�������¡������ر�ҳ��ʱ
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

            //�洢������
            string spName = "sp_Rs_Update_Qzsp_Qzjl";
            //�洢���̲���
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
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //Orgnize������
        public static DataTable GetOrganize()
        {
            string spName = "sp_Rs_Get_Organize_All";
            return SQLHelper.ExecuteDataTable(spName);
        }

        //���ݲ��Ż�ȡOrgnize������
        public static DataTable GetRootIDByBm(string bm)
        {
            //�洢������
            string spName = "sp_Rs_Get_RootID_By_Bm";
            //�洢���̲���
            object[] para = new object[] { bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ݲ��ű�Ż�ȡOrgnize������
        public static DataTable GetRootIDByBmBh(int bm_bh)
        {
            //�洢������
            string spName = "sp_Rs_Get_RootID_By_Bm_Bh";
            //�洢���̲���
            object[] para = new object[] { bm_bh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //��ȡ���Ż���Ŀ��
        public static DataTable GetBmXmz2(int DisplayType)
        {

            //�洢������
            string spName = "sp_Rs_Get_Bm_Xmz2";
            //�洢���̲���
            object[] para = new object[] { DisplayType };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //��ȡ���Ż���Ŀ�鼰����
        public static DataTable GetBmXmz(int DisplayType)
        {

            //�洢������
            string spName = "sp_Rs_Get_Bm_Xmz";
            //�洢���̲���
            object[] para = new object[] { DisplayType };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //��ȡ�ѳ������Ż���Ŀ��
        public static DataTable GetBmXmzSc(int DisplayType)
        {

            //�洢������
            string spName = "sp_Rs_Get_Bm_Xmz_Sc";
            //�洢���̲���
            object[] para = new object[] { DisplayType };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }


        //����ְ����Ż�ȡ���ź�ְ����Ϣ
        public static DataTable SelectRyByZgbh(string ry_zgbh)
        {
            string spName = "sp_Rs_Select_Ry_By_Zgbh";
            object[] para = new object[] { ry_zgbh };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable GetZwAll()
        {
            //�洢������
            string spName = "sp_Rs_Position_Get_All";
            //ִ�д洢���̣�������DataTable
            return SQLHelper.ExecuteDataTable(spName);
        }

        public static DataTable GetZwJB()
        {
            //�洢������
            string spName = "sp_Rs_Get_Zwjb";
            //ִ�д洢���̣�������DataTable
            return SQLHelper.ExecuteDataTable(spName);
        }

        public static DataTable GetZwByBh(int zw_bh)
        {
            //�洢������
            string spName = "sp_Rs_Get_Zw_By_Bh";
            object[] para = new object[] { zw_bh };
            //ִ�д洢���̣�������DataTable
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
            //�洢������
            string spName = "sp_Rs_Ry_Num_By_Zw";
            //�洢���̲���
            object[] para = new object[] { zw_mc };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        //ɾ������ʱ���ݲ���ɾ��Organize
        public static int DeleteOrganizeByBm(string bm_mc)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Organize_By_Bm";
            //�洢���̲���
            object[] para = new object[] { bm_mc };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }



        //��������֪ͨ����Ա���������̣�
        public static int InsertFlowRstzdRymd(int doc_id)
        {
            //�洢������
            string spName = "sp_Rs_Insert_Flow_Rstzd_Rymd";
            //�洢���̲���
            object[] para = new object[] { doc_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //����qjsp_id��ô������Ϣ
        public static DataTable SelectQjspById(int qjsp_id)
        {
            //�洢������
            string spName = "sp_Rs_Select_Qjsp_By_Id";
            //�洢���̲���
            object[] para = new object[] { qjsp_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ݲ��ű�ų����˲���
        public static int DeleteBmByBh(int bm_bh)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Bm_By_Bh";
            //�洢���̲���
            object[] para = new object[] { bm_bh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //���ݲ��ű��ɾ���˲���
        public static int ScBmByBh(int bm_bh)
        {
            //�洢������
            string spName = "sp_Rs_Sc_Bm_By_Bh";
            //�洢���̲���
            object[] para = new object[] { bm_bh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //���ݲ��ű�Ż�ȡdsoc_ry���е�ry_zgbh
        public static DataTable GetRyZgbhByBmBh(int bm_bh)
        {
            //�洢������
            string spName = "sp_Rs_Ry_By_Bm_Bh";
            //�洢���̲���
            object[] para = new object[] { bm_bh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //����ְ����ź���ݻ�ȡ��ټƻ�
        public static DataTable GetNjjhByZgbh(string ry_zgbh, int nj_year)
        {
            //�洢������
            string spName = "sp_Rs_Get_Njjh_By_Zgbh";
            //�洢���̲���
            object[] para = new object[] { ry_zgbh, nj_year };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //����ְ����ź���ݸ�����ټƻ�
        //����ְ����ź���ݸ�����ټƻ�
        public static DataTable UpdateNjjhByZgbh(string ry_zgbh, int nj_year, int jhts, int yxts, int syts, string xm, string bm, string zw)
        {
            //�洢������
            string spName = "sp_Rs_Update_Njjh_By_Zgbh";
            //�洢���̲���
            object[] para = new object[] { ry_zgbh, nj_year, jhts, yxts, syts, xm, bm, zw };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }


        //��ȡ��������Ŀ���е�����
        public static DataTable GetBmToXmzNum(string bm, string xmz)
        {
            //�洢������
            string spName = "rs_staff_statistics_by_bm_xmz";
            //�洢���̲���
            object[] para = new object[] { bm, xmz };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //��ȡ�粿����Աְ�����
        public static DataTable GetRyTwoBm()
        {
            //�洢������
            string spName = "sp_Rs_Get_Ry_Two_Bm";
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName);
        }

        //��ȡ�粿����Ա��������
        public static DataTable GetRyTwoBm2(string zgbh)
        {
            //�洢������
            string spName = "sp_Rs_Get_Ry_Two_Bm2";
            //�洢���̲���
            object[] para = new object[] { zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //����id��ȡ�ļ���
        public static DataTable GetFileName(int id)
        {
            //�洢������
            string spName = "sp_scfj_get_file_name_by_id";
            //�洢���̲���
            object[] para = new object[] { id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //��ȡ��ְ-��ְ��ɫ
        public static DataTable GetRzLzRole()
        {
            //�洢������
            string spName = "sp_Rs_Get_Rz_Lz_Role";
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName);
        }

        //���ݲ��Ż�ȡ��ְ-��ְ��ɫ
        public static DataTable GetRzLzRoleByBm(string bm)
        {
            //�洢������
            string spName = "sp_Rs_Get_Rz_Lz_Role_By_Bm";
            //�洢���̲���
            object[] para = new object[] { bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //�����ְ-��ְ��ɫ
        public static int InsertRzLzRole(string bm, string role)
        {
            //�洢������
            string spName = "sp_Rs_Insert_Rz_Lz_Role";
            //�洢���̲���
            object[] para = new object[] { bm, role };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //ɾ����ְ-��ְ��ɫ
        public static int DeleteRzLzRole(int role_bh)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Rz_Lz_Role";
            //�洢���̲���
            object[] para = new object[] { role_bh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //�����ְ-��ְ��ɫ��Ӧ��Ա
        public static int InsertRzLzRoleRy(string ry_zgbh, int role_bh)
        {
            //�洢������
            string spName = "sp_Rs_Insert_Rz_Lz_Role_Ry";
            //�洢���̲���
            object[] para = new object[] { ry_zgbh, role_bh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //ɾ����ְ-��ְ��ɫ��Ӧ��Ա
        public static int DeleteRzLzRoleRy(string ry_zgbh, int role_bh)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Rz_Lz_Role_Ry";
            //�洢���̲���
            object[] para = new object[] { ry_zgbh, role_bh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //��ȡ��ְ-��ְ��ɫ��Ӧ��Ա
        public static DataTable GetRzLzRoleRy(int role_bh)
        {
            //�洢������
            string spName = "sp_Rs_Get_Rz_Lz_Role_Ry";
            //�洢���̲���
            object[] para = new object[] { role_bh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //ɾ������ʵ��
        public static int DeleteDocument(int doc_id)
        {
            //�洢������
            string spName = "sp_Flow_Delete_Document";
            //�洢���̲���
            object[] para = new object[] { doc_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }
        //���ݲ�ѯ������������Ϣ
        public static DataTable SelectNjxxByCondition(string xm, string bm, string year, string njjh, string yxts, string syts)
        {

            //�洢������
            string spName = "sp_Rs_Select_Njxx_By_Condition";
            //�洢���̲���
            object[] para = new object[] { xm, bm, year, njjh, yxts, syts };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        #region ��Ч���ˣ���ѵ��������


        //�����༨Ч������Ϣ�浵
        public static int InsertJxcz(string jxcz_xm, string jxcz_zgbh, string jxcz_zw, string jxcz_bm, string jxcz_jx, string jxcz_bzcc,
            string jxcz_sjms, string jxcz_pj, int jxcz_fs, string jxcz_khr, string jxcz_khrq, string jxcz_shyj, string jxcz_shr, string jxcz_shrq)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Jxcz";
            //�洢���̲���
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


            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��ϰ�༨Ч������Ϣ�浵
        public static int InsertJxjx(string xm, string zgbh, string bm, string td, string bx,
            string gx, string gz, string gzl, string gzhj, string gzsj, string jy, string wt, string yj, int fs)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Jxjx";
            //�洢���̲���
            object[] para = new object[] { xm, zgbh, bm, td, bx, gx, gz, gzl, gzhj, gzsj, jy, wt, yj, fs };


            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }


        //��ϰ�༨Ч���˸���doc_id�޸�������
        public static int UpdateJxjx_byid(string xm, string zgbh, string bm, string td, string bx,
            string gx, string gz, string gzl, string gzhj, string gzsj, string jy, string wt, string yj, int fs, int id)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Update_Jxjx_byid";
            //�洢���̲���
            object[] para = new object[] { xm, zgbh, bm, td, bx, gx, gz, gzl, gzhj, gzsj, jy, wt, yj, fs, id };


            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��Ч���˼�ϰ�������ɹ��Ż�doc_id���
        public static DataTable GetInfo_jxjx(string zgbh, int id)
        {

            //�洢������
            string spName = "sp_Rs_Get_jxjx_By_zgbh_docid";
            //�洢���̲���
            object[] para = new object[] { zgbh, id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //ɾ����Ч���˼�ϰ�������
        public static int DeleteJxjx(int doc_id)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Jxjx";
            //�洢���̲���
            object[] para = new object[] { doc_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }
        public static int UpdateJxjx_docid_by_zgbh(int id, string zgbh)
        {
            //�洢������
            string spName = "sp_Rs_UpdateJxjx_docid_by_zgbh";
            //�洢���̲���
            object[] para = new object[] { id, zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
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

        //��ϰ��������ܲ���������̣�
        public static int Insert_Flow_Rs_jxjx_yjhz(int id, string zgxm, int zpfs1, double zpfs2,
            string dsxm, int fs1, double fs2, string bzxm, int fs3, double fs4, double zf)
        {
            //�洢������
            string spName = "sp_Rs_Insert_Flow_Rs_jxjx_yjhz";
            //�洢���̲���
            object[] para = new object[] { id, zgxm, zpfs1, zpfs2, dsxm, fs1, fs2, bzxm, fs3, fs4, zf };
            //�������ݷ��ʲ�ķ������ʴ洢����
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
        //		//��ѵ����ҳ���
        //		public static DataTable GetAll_pxgl()
        //		{
        //			string spName = "sp_Rs_Select_pxgl";
        //			object[] para = new object[] {};
        //			return SQLHelper.ExecuteDataTable(spName,para);
        //		}
        //
        //		//��ѵ��������޸�ҳ��ʱ����Ա
        //		public static DataTable GetAll_pxgl_ry(int pxglid)
        //		{
        //			string spName = "sp_Rs_Select_pxgl_ry";
        //			object[] para = new object[] { pxglid };
        //			return SQLHelper.ExecuteDataTable(spName,para);
        //		}
        //
        //		//��ѵ��������Ա����ҳ�桪����Ա��
        //		public static DataTable GetAll_pxgl_rygl(string ryxm,string ryzgbh,string rybm,string ryzw,string pxkmmc,string pxzzbm,string pxjb)
        //		{
        //			string spName = "sp_Rs_Select_pxgl_rygl";
        //			object[] para = new object[] { ryxm,ryzgbh,rybm,ryzw,pxkmmc,pxzzbm,pxjb };
        //			return SQLHelper.ExecuteDataTable(spName,para);
        //		}
        //
        //		//��ѵ��������Ա��������ҳ�桪����Ա��
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
        //		//����ѵ������Ա��ʱ�������ʽ��
        //		public static int Insert_pxgl_ry(int pxgl_id, string zgbh)
        //		{
        //		
        //			//�洢������
        //			string spName = "sp_Rs_Insert_pxgl_ry";
        //			//�洢���̲���
        //			object[] para = new object[] { pxgl_id, zgbh };
        //			//�������ݷ��ʲ�ķ������ʴ洢����
        //			return SQLHelper.ExecuteNonQuery(spName,false,para);
        //		}
        //
        //		//�޸���ѵ������Ա��ʱ��
        //		public static  int Update_pxgl_ry_temp (string cj,string zsbh,string bz,int id)
        //		{
        //			
        //			//�洢������
        //			string spName = "sp_Rs_Update_pxgl_ry_temp";
        //			//�洢���̲���
        //			object[] para = new object[] {cj,zsbh,bz,id};
        //			//�������ݷ��ʲ�ķ������ʴ洢����
        //			return SQLHelper.ExecuteNonQuery(spName,false,para);
        //	
        //		}
        //
        //		//�޸���ѵ������Ա��
        //		public static  int Update_pxgl_ry(string cj,string zsbh,string bz,int id)
        //		{
        //			
        //			//�洢������
        //			string spName = "sp_Rs_Update_pxgl_ry";
        //			//�洢���̲���
        //			object[] para = new object[] {cj,zsbh,bz,id};
        //			//�������ݷ��ʲ�ķ������ʴ洢����
        //			return SQLHelper.ExecuteNonQuery(spName,false,para);
        //	
        //		}
        //
        //		//�޸���ѵ�����
        //		public static  int Update_pxgl(string kmmc,string zzbm,string jb,int xs,string pxks,string pxjs,string yxks,string yxjs,int pxglid)
        //		{
        //			
        //			//�洢������
        //			string spName = "sp_Rs_Update_pxgl";
        //			//�洢���̲���
        //			object[] para = new object[] {kmmc,zzbm,jb,xs,pxks,pxjs,yxks,yxjs,pxglid};
        //			//�������ݷ��ʲ�ķ������ʴ洢����
        //			return SQLHelper.ExecuteNonQuery(spName,false,para);
        //	
        //		}
        //
        //
        //		//������ѵ����ѡ����ʱ��
        //		public static int InsertInfo_to_pxgl_ry_temp(string xm,string sex,string zgbh,string bm,string zw,string txrzgbh)
        //		{
        //			int ret = -1;
        //			//�洢������
        //			string spName = "sp_Rs_Insert_pxgl_ry_Temp";
        //			//�洢���̲���
        //			object[] para = new object[] {xm,sex,zgbh,bm,zw,txrzgbh};
        //			//�������ݷ��ʲ�ķ������ʴ洢����
        //			ret = SQLHelper.ExecuteNonQuery(spName, false, para);
        //
        //
        //			return ret;
        //		}
        //		
        //		//�޸���ѵ������Ա��ʽ��
        //		public static int InsertNew_to_pxgl_ry(string xm,string sex,string zgbh,string bm,string zw,int pxglid)
        //		{
        //			int ret = -1;
        //			//�洢������
        //			string spName = "sp_Rs_InsertNew_pxgl_ry";
        //			//�洢���̲���
        //			object[] para = new object[] {xm,sex,zgbh,bm,zw,pxglid};
        //			//�������ݷ��ʲ�ķ������ʴ洢����
        //			ret = SQLHelper.ExecuteNonQuery(spName, false, para);
        //
        //
        //			return ret;
        //		}
        #endregion
        #region 5��22�� wyw
        //����ְ������жϴ���Ա�Ƿ��������Ŀ����
        public static int GetXmzFlag(string ry_zgbh)
        {

            //�洢������
            string spName = "sp_Rs_Get_Xmz_Flag";
            //�洢���̲���
            object[] para = new object[] { ry_zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return (int)SQLHelper.ExecuteScalar(spName, para);
        }

        //����ְ������жϴ˴�������Ŀ�����Ա�Ƿ������ʲɰ첿���г�Ӫ������Ա
        public static int GetWZYXFlag(string ry_zgbh)
        {

            //�洢������
            string spName = "sp_Rs_Get_WZ_YX_Flag";
            //�洢���̲���
            object[] para = new object[] { ry_zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return (int)SQLHelper.ExecuteScalar(spName, para);
        }
        #endregion
        public static DataTable SelectZwByBm(string bm)//20090603 wyw
        {

            //�洢������
            string spName = "sp_Rs_Select_Zw_By_bm";
            //�洢���̲���
            object[] para = new object[] { bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        #region 6��3�� duan�������༨Ч����

        public static DataTable GetAll_gljsl_jh(int id)
        {
            string spName = "sp_Rs_Get_gljsl_jh";
            object[] para = new object[] { id };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //�����༨Ч���ˡ����ƻ���Ϣ�浵
        public static int InsertJx_gljsl(string nr, string sj, float qz, int docid, int flag)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_InsertJx_gljsl";
            //�洢���̲���
            object[] para = new object[] { nr, sj, qz, docid, flag };


            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //�޸Ĺ������༨Ч������ʽ��
        //		public static  int Update_Jx_gljsl(string nr,string sj,float qz,float bkr,float khr,float fhr,int bh)
        public static int Update_Jx_gljsl(string nr, string sj, string qz, string bkr, string khr, string fhr, int bh)
        {

            //�洢������
            string spName = "sp_Rs_Update_Jx_gljsl";
            //�洢���̲���
            object[] para = new object[] { nr, sj, qz, bkr, khr, fhr, bh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);

        }
        //ɾ������ʵ��
        public static int DeleteDocument_jx(int doc_id)
        {
            //�洢������
            string spName = "sp_Flow_Delete_Document_jx";
            //�洢���̲���
            object[] para = new object[] { doc_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        public DataTable GetXmBmZwByZdbh1(string _zdbh)//ͨ����Ա��Ż����Ա���������š�ְ��(ֻ�ǲ��ţ�û����Ŀ��)
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


        #region ��ѵ����
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

        //��ѵ����ҳ���
        public static DataTable GetAll_pxgl()
        {
            string spName = "sp_Rs_Select_pxgl";
            object[] para = new object[] { };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //��ѵ��������޸�ҳ��ʱ����Ա
        public static DataTable GetAll_pxgl_ry(int pxglid)
        {
            string spName = "sp_Rs_Select_pxgl_ry";
            object[] para = new object[] { pxglid };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //��ѵ��������Ա����ҳ�桪����Ա��
        public static DataTable GetAll_pxgl_rygl(string ryxm, string ryzgbh, string rybm, string ryzw, string pxkmmc, string pxzzbm, string pxjb)
        {
            string spName = "sp_Rs_Select_pxgl_rygl";
            object[] para = new object[] { ryxm, ryzgbh, rybm, ryzw, pxkmmc, pxzzbm, pxjb };
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //��ѵ��������Ա��������ҳ�桪����Ա��
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

        //����ѵ������Ա��ʱ�������ʽ��
        public static int Insert_pxgl_ry(int pxgl_id, string zgbh)
        {

            //�洢������
            string spName = "sp_Rs_Insert_pxgl_ry";
            //�洢���̲���
            object[] para = new object[] { pxgl_id, zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //�޸���ѵ������Ա��ʱ��
        public static int Update_pxgl_ry_temp(string cj, string zsbh, string bz, int id)
        {

            //�洢������
            string spName = "sp_Rs_Update_pxgl_ry_temp";
            //�洢���̲���
            object[] para = new object[] { cj, zsbh, bz, id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);

        }

        //�޸���ѵ������Ա��
        public static int Update_pxgl_ry(string cj, string zsbh, string bz, int id)
        {

            //�洢������
            string spName = "sp_Rs_Update_pxgl_ry";
            //�洢���̲���
            object[] para = new object[] { cj, zsbh, bz, id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);

        }

        //�޸���ѵ�����
        public static int Update_pxgl(string kmmc, string zzbm, string jb, int xs, string pxks, string pxjs, string yxks, string yxjs, int pxglid)
        {

            //�洢������
            string spName = "sp_Rs_Update_pxgl";
            //�洢���̲���
            object[] para = new object[] { kmmc, zzbm, jb, xs, pxks, pxjs, yxks, yxjs, pxglid };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);

        }


        //������ѵ����ѡ����ʱ��
        public static int InsertInfo_to_pxgl_ry_temp(string xm, string sex, string zgbh, string bm, string zw, string txrzgbh)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_pxgl_ry_Temp";
            //�洢���̲���
            object[] para = new object[] { xm, sex, zgbh, bm, zw, txrzgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);


            return ret;
        }

        //�޸���ѵ������Ա��ʽ��
        public static int InsertNew_to_pxgl_ry(string xm, string sex, string zgbh, string bm, string zw, int pxglid)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_InsertNew_pxgl_ry";
            //�洢���̲���
            object[] para = new object[] { xm, sex, zgbh, bm, zw, pxglid };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);


            return ret;
        }
        #endregion

        #region 6��10�� dxq

        //����������Ŀ��
        public static int InsertGljslJxkh(string zgbh, string xm, string bm, string gw, int nf, int yf, float zp, float kh, float fh, float zf, string pylx, double xs, int id)
        {
            //�洢������
            string spName = "sp_Rs_Insert_Gljsl_Jxkh";
            //�洢���̲���
            object[] para = new object[] { zgbh, xm, bm, gw, zp, kh, fh, zf, nf, yf, pylx, xs, id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        #endregion
        #region 6��3���Ժ� wyw
        //����ְ����Ż�ȡ��Ч���˽��
        public static DataTable SelectJxkhByZgbh(string zgbh, int nf, int yf)
        {

            //�洢������
            string spName = "sp_Rs_Select_Jxkh_By_Zgbh";
            //�洢���̲���
            object[] para = new object[] { zgbh, nf, yf };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //����ְ����Ÿ���doc_id
        public static int UpdateJxkhDocIdByZgbh(string zgbh, int nf, int yf, int doc_id)
        {

            //�洢������
            string spName = "sp_Rs_Update_Jxkh_Doc_Id_By_Zgbh";
            //�洢���̲���
            object[] para = new object[] { zgbh, nf, yf, doc_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //����doc_id��ȡ��Ч���˽��
        public static DataTable SelectJxkhByDocId(int doc_id)
        {

            //�洢������
            string spName = "sp_Rs_Select_Jxkh_By_Doc_Id";
            //�洢���̲���
            object[] para = new object[] { doc_id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //������ݺ��·ݻ�ȡ�����������ϼ�Ч���˽��
        public static DataTable SelectLdjxkhByNfYf(int nf, int yf, string order_flag)
        {

            //�洢������
            string spName = "sp_Rs_Select_LdJxkh_By_Nf_Yf";
            //�洢���̲���
            object[] para = new object[] { nf, yf, order_flag };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //������ݡ��·ݺͲ��Ż�ȡ���������¼�Ч���˽��
        public static DataTable SelectFldjxkhByNfYf(int nf, int yf, string bm, string order_flag)
        {

            //�洢������
            string spName = "sp_Rs_Select_FldJxkh_By_Nf_Yf";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm, order_flag };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //����id���¸��˷���
        public static int UpdateJxkhFhById(int id, float jxkh_fh, double jxkh_xs, int docid)
        {

            //�洢������
            string spName = "sp_Rs_Update_Jxkh_Fh_By_Id";
            //�洢���̲���
            object[] para = new object[] { id, jxkh_fh, jxkh_xs, docid };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //����id���¸��˷���temp
        public static int UpdateJxkhFhTempById(int id, float jxkh_fh, double jxkh_xs)
        {

            //�洢������
            string spName = "sp_Rs_Update_Jxkh_Fh_Temp_By_Id";
            //�洢���̲���
            object[] para = new object[] { id, jxkh_fh, jxkh_xs };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //��ȡ��dt����������
        public static DataTable SelectNullJxkh()
        {

            //�洢������
            string spName = "sp_Rs_Select_Null_Jxkh";
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName);
        }

        //������ݡ��·ݺͲ���ͳ�Ƽ�Чϵ���ܺ�
        public static DataTable StatisticsJxkh(int nf, int yf, string bm, string flag)
        {

            //�洢������
            string spName = "sp_Rs_Stat_Jxkh";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm, flag };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���ż�Ч���˳���1.0������
        public static int JxkhBmFhPercent(int nf, int yf, string bm)
        {

            //�洢������
            string spName = "sp_Rs_Check_FldJxkh_Percent";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return (int)SQLHelper.ExecuteScalar(spName, para);
        }

        //���ŲμӼ�Ч���˵�������
        public static int JxkhBmFhNum(int nf, int yf, string bm)
        {

            //�洢������
            string spName = "sp_Rs_Jxkh_Bm_Num";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return (int)SQLHelper.ExecuteScalar(spName, para);
        }

        //��ȡ�쵼��δ���м�Ч���˵���Ա����
        public static DataTable SelectUnfoundLdjxkh(int nf, int yf)
        {

            //�洢������
            string spName = "sp_Rs_Select_Unfound_LdJxkh";
            //�洢���̲���
            object[] para = new object[] { nf, yf };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //��ȡ���쵼��δ���м�Ч���˵���Ա����
        public static DataTable SelectUnfoundFldjxkh(int nf, int yf, string bm)
        {

            //�洢������
            string spName = "sp_Rs_Select_Unfound_FldJxkh";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //��ȡ���ʲɰ첿�ֹ������Ա
        public static DataTable SelectWzbHandJxkh(int nf, int yf, string bm, string _zgbh)
        {

            //�洢������
            string spName = "sp_Rs_Select_Wzb_Hand_Jxkh";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm, _zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //���뼨Ч���˽��temp���ֹ�¼��
        public static int InsertGljslJxkhTemp(string zgbh, string xm, string bm, string gw, int nf, int yf, float zp, float kh, float fh, float zf, string pylx, double xs, string _zgbh)
        {
            //�洢������
            string spName = "sp_Rs_Insert_Gljsl_Jxkh_Temp";
            //�洢���̲���
            object[] para = new object[] { zgbh, xm, bm, gw, zp, kh, fh, zf, nf, yf, pylx, xs, _zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //ɾ����Ч�����ֹ�¼��ķ���
        public static int DeleteJxkhTemp(int id)
        {
            //�洢������
            string spName = "sp_Rs_Delete_Jxkh_Temp";
            //�洢���̲���
            object[] para = new object[] { id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //��Ч���˽��temp������ʽ��
        public static int InsertJxkhFromTemp(int nf, int yf, string bm, string _zgbh)
        {
            //�洢������
            string spName = "sp_Rs_Insert_Jxkh_From_Temp";
            //�洢���̲���
            object[] para = new object[] { nf, yf, bm, _zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }
        #endregion
        //6��16��
        //����Ƹ������ͳ�Ƽ�Ч���˽��
        public static DataTable SelectJxkhByPylx(int nf, int yf, string pylx)
        {

            //�洢������
            string spName = "sp_Rs_Select_Jxkh_By_Pylx";
            //�洢���̲���
            object[] para = new object[] { nf, yf, pylx };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }


        //6��18��
        //���ݲ��Ż���Աͳ�Ƽ�Ч���˽��
        public static DataTable SelectJxkhByBmRy(int qs_nf, int qs_yf, int jz_nf, int jz_yf, string bm_or_ry, int flag)
        {

            //�洢������
            string spName = "sp_Rs_Select_Jxkh_By_Bm_Ry";
            //�洢���̲���
            object[] para = new object[] { qs_nf, qs_yf, jz_nf, jz_yf, bm_or_ry, flag };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        //������ٿ�ʼ����ʱ�䣬�ж��ظ����ʱʹ��
        public static int InsertQjsp_cfts(string qjsp_zgbh, string qjsp_kssj, string qjsp_jssj)
        {
            //�洢������
            string spName = "sp_Rs_Insert_Qjsp_cfts";
            //�洢���̲���
            object[] para = new object[] { qjsp_zgbh, qjsp_kssj, qjsp_jssj };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //ɾ����ٿ�ʼ����ʱ�䣬�ж��ظ����ʱʹ��
        public static int DeleteQjsp_cfts(string qjsp_zgbh, string qjsp_kssj, string qjsp_jssj)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Delete_Qjsp_cfts";
            //�洢���̲���
            object[] para = new object[] { qjsp_zgbh, qjsp_kssj, qjsp_jssj };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }
        public static DataTable RyglByCondition(string bm, string zw, string zgbh, string xm)
        {

            //�洢������
            string spName = "sp_Rs_Select_Rygl_By_Condition";
            //�洢���̲���
            object[] para = new object[] { bm, zw, zgbh, xm };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        public DataTable GetXmBmZwByZdbh_lz(string _zdbh)//ͨ����Ա��Ż����Ա���������š�ְ��
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


        //����idɾ����Ա���ź�ְλ��dsoc_ry_lz��
        public static int DeleteDsocRyByID_lz(int id)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Delete_Dsoc_Ry_By_ID";
            //�洢���̲���
            object[] para = new object[] { id };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }


        //����ְ����Ż�ȡ��ְ��Ա���ź�ְ����Ϣ
        public static DataTable SelectRyByZgbh_lz(string ry_zgbh)
        {
            string spName = "sp_Rs_Select_Ry_By_Zgbh_lz";
            object[] para = new object[] { ry_zgbh };
            return SQLHelper.ExecuteDataTable(spName, para);
        }


        //�����Ա���ź�ְλ��dsoc_ry_lz��
        public static int InsertDscoRy_lz(
            string ry_zgbh,
            string ry_xm,
            string ry_bm,
            string ry_zw)
        {
            int ret = -1;
            //�洢������
            string spName = "sp_Rs_Insert_Dsoc_Ry_lz";
            //�洢���̲���
            object[] para = new object[] {	ry_zgbh,
											 ry_xm ,
											 ry_bm ,
											 ry_zw };
            //�������ݷ��ʲ�ķ������ʴ洢����
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        //��ȡ������λʱ��
        public static DataTable GetJbdwsj(string ry_zgbh)
        {
            //�洢������
            string spName = "getJbdwsj";
            //�洢���̲���
            object[] para = new object[] { ry_zgbh };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }
        /// <summary>
        /// �Զ����������̣�������
        /// </summary>
        /// <param name="ry_zgbh">ְ�����</param>
        /// <param name="qjType">������</param>
        /// <param name="startTime">��ʼʱ�䣬��ʽ��"2010-07-10 08:00:00"</param>
        /// <param name="totalDays">������</param>
        /// <param name="totalWorkDays">�ܹ�������</param>
        /// <param name="reason">�������</param>
        /// <param name="leaderName">�쵼����</param>
        /// <param name="leaderTime">�쵼ǩ��ʱ�䣬��ʽ��"2010-07-10"</param>
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
                //				df.AddDocument(ry_zgbh,4,sqlStr,name.Trim()+"�������");
                string obj_id = "0406";

                spName = "sp_Flow_AddDocumentByStepID";
                para = new object[] { ry_zgbh, 4, 5, sqlStr, obj_id, name.Trim() + "�������" };

                SQLHelper.ExecuteDataTable(spName, para);
            }
        }
        /// <summary>
        /// ͳ�����������Ϣ����njxxҳ��ʹ��
        /// </summary>
        /// <returns></returns>
        public static int Nj_tongji()
        {
            string spName = "sp_nj_tongji";
            object[] para = new object[] { };
            return SQLHelper.ExecuteNonQuery(spName, false, para);
        }

        //11.25dxq ������ͳ��
        public static DataTable TjByCondition(string bm, string zw, string xb, string ygxz, string xl,
            string zc, string zy, string age1, string age2, string cjgz1, string cjgz2, string jbdw1, string jbdw2,
            string htqs1, string htqs2, string htzz1, string htzz2, string htlb)
        {

            //�洢������
            string spName = "sp_Rs_Select_Tj_By_Condition1";
            //�洢���̲���
            object[] para = new object[] { bm, zw, xb, ygxz, xl, zc, zy, age1, age2, cjgz1, cjgz2, jbdw1, jbdw2, htqs1, htqs2, htzz1, htzz2, htlb };
            //�������ݷ��ʲ�ķ������ʴ洢����
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        /// <summary>
        /// ��Ӹ�λ�䶯���
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
        /// ��ְ�Ż�ȡ��λ�䶯���
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

        //������������
        public static DataTable SelectQjspByZgbhFlagNew(string zgbh, int qjsp_sfxj_flag)
        {

            //�洢������
            string spName = "sp_Rs_Select_Qjsp_By_Zgbh_Flag_new";
            //�洢���̲���
            object[] para = new object[] { zgbh, qjsp_sfxj_flag };
            //�������ݷ��ʲ�ķ������ʴ洢����
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
                throw new Exception("��Ա��Ϣ��ȡ����!", ex);
            }
        }
    }
}
