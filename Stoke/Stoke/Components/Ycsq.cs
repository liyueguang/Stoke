using System;
using System.Data;
using Stoke.DAL;

namespace Stoke.Components
{
    /// <summary>
    /// Ycsq 的摘要说明。
    /// </summary>
    public class Ycsq
    {
        public Ycsq()
        {
        }
        public static DataTable Select_Field_by_Step(int flow_id, int step_id)
        {

            //存储过程名
            string spName = "sp_Flow_Select_Field_By_Step";
            //存储过程参数
            object[] para = new object[] { flow_id, step_id };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static DataTable Select_Data_by_DocID(int DocID)
        {

            //存储过程名
            string spName = "sp_Flow_Get_Data_By_DocID";
            //存储过程参数
            object[] para = new object[] { DocID };
            //调用数据访问层的方法访问存储过程
            return SQLHelper.ExecuteDataTable(spName, para);
        }

        public static int InsertYcsq(string ycsq_bm, string ycsq_ri, string ycsq_fcsj, int ycsq_ycsj, int ycsq_rs, string ycsq_sfmd, string ycsq_ycr, string ycsq_sy, string ycsq_bmld, string ycsq_zjl, string ycsq_ccph, string ycsq_sjxm, string ycsq_ddy, float ycsq_cclc, float ycsq_hclc, float ycsq_lcs, float ycsq_fy)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_clgl_flow_ycsq_insert";
            //存储过程参数
            object[] para = new object[] { ycsq_bm, ycsq_ri, ycsq_fcsj, ycsq_ycsj, ycsq_rs, ycsq_sfmd, ycsq_ycr, ycsq_sy, ycsq_bmld, ycsq_zjl, ycsq_ccph, ycsq_sjxm, ycsq_ddy, ycsq_cclc, ycsq_hclc, ycsq_lcs, ycsq_fy };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        public static int InsertWxsq(string wxsq_cphm,
            string wxsq_sjxm,
            string wxsq_rq,
            string wxsq_wxxm,
            float wxsq_je,
            string wxsq_bz,
            string wxsq_zhbfzr,
            string wxsq_zjl,
            string wxsq_ddyap,
            string wxsq_wxzt)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_clgl_flow_wxsq_insert";
            //存储过程参数
            object[] para = new object[] { wxsq_cphm, wxsq_sjxm, wxsq_rq, wxsq_wxxm, wxsq_je, wxsq_bz, wxsq_zhbfzr, wxsq_zjl, wxsq_ddyap, wxsq_wxzt };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }

        public static int InsertJdsq(string Jdsqd_Sqbm,
            string Jdsqd_Jbr,
            DateTime Jdsqd_Sqsj,
            string Jdsqd_Lfdw,
            int Jdsqd_Lfrs,
            DateTime Jdsqd_Ddsj,
            DateTime Jdsqd_Lksj,
            string Jdsqd_Cgsx,
            string Jdsqd_Cgsxnr,
            string Jdsqd_Hysx,
            string Jdsqd_Hysxnr,
            string Jdsqd_Yqsx,
            string Jdsqd_Yqsxnr,
            string Jdsqd_Gzcsx,
            string Jdsqd_Zssx,
            string Jdsqd_Zssxnr,
            string Jdsqd_Sqbmyj,
            string Jdsqd_Sfylp,
            string Jdsqd_Zhglbyj,
            string Jdsqd_Gsldyj,
            string Jdsqd_Zsbz,
            string Jdsqd_Yq,
            string Jdsqd_Zjlyj,
            string Jdsqd_Bz)
        {
            int ret = -1;
            //存储过程名
            string spName = "sp_jdgl_flow_jdsq_insert";
            //存储过程参数
            object[] para = new object[] { Jdsqd_Sqbm,
											 Jdsqd_Jbr,
											 Jdsqd_Sqsj,
											 Jdsqd_Lfdw,
											 Jdsqd_Lfrs,
											 Jdsqd_Ddsj,
											 Jdsqd_Lksj,
											 Jdsqd_Cgsx,
											 Jdsqd_Cgsxnr,
											 Jdsqd_Hysx,
											 Jdsqd_Hysxnr,
											 Jdsqd_Yqsx,
											 Jdsqd_Yqsxnr,
											 Jdsqd_Gzcsx,
											 Jdsqd_Zssx,
											 Jdsqd_Zssxnr,
											 Jdsqd_Sqbmyj,
											 Jdsqd_Sfylp,
											 Jdsqd_Zhglbyj,
											 Jdsqd_Gsldyj,
											 Jdsqd_Zsbz,
											 Jdsqd_Yq,
											 Jdsqd_Zjlyj,
											 Jdsqd_Bz };
            //调用数据访问层的方法访问存储过程
            ret = SQLHelper.ExecuteNonQuery(spName, false, para);

            return ret;
        }
    }
}
