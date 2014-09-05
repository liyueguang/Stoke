using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using Stoke.DAL;

namespace Stoke.BLL
{
    public static class Utility
    {
        public static DataTable GetFieldBind(int flow_id, int step_id)
        {
            string cmdText = "sp_getFlowFieldBind";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@flow_id", flow_id),
                new SqlParameter("@step_id", step_id));
        }

        public static DataTable GetFieldDescription(int flow_id)
        {
            string cmdText = "sp_getFlowFieldDescription";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@flow_id", flow_id));
        }

        public static DataTable GetFieldValue(int flow_id, int doc_id)
        {
            string sqlText = "SELECT doc_id";
            DataTable dt = GetFieldDescription(flow_id);
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                sqlText += ", " + dt.Rows[i][0].ToString();
            }
            sqlText += " FROM dsoc_flow_style_data WHERE doc_id = " + doc_id;

            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.Text, sqlText);
        }

        public static string GetRyxmByZgbh(string zgbh)
        {
            string cmdText = "sp_getRyxmByZgbh";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@zgbh", zgbh)).Rows[0][0].ToString();
        }

        public static DataTable GetDepartmentByZgbh(string zgbh)
        {
            string cmdText = "sp_getDepartmentByZgbh";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@zgbh", zgbh));
        }

        public static DataTable GetPositionByZgbh(string zgbh)
        {
            string cmdText = "sp_getPositionByZgbh";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@zgbh", zgbh));
        }

        public static DataTable GetAttachmentByDocid(int doc_id)
        {
            string cmdText = "sp_getAttachmentByDocid";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@doc_id", doc_id));
        }

        public static void AddAttachments(int doc_id, DataTable dt)
        {
            string cmdText = "sp_addAttachments";
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                    new SqlParameter("@doc_id", doc_id),
                    new SqlParameter("@filename", dt.Rows[i]["filename"]),
                    new SqlParameter("@fileurl", dt.Rows[i]["fileurl"]));
            }
        }

        public static void AddAttachment(int doc_id, string filename, string fileurl)
        {
            string cmdText = "sp_AddAttachments";
            SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                    new SqlParameter("@doc_id", doc_id),
                    new SqlParameter("@filename", filename),
                    new SqlParameter("@fileurl", fileurl));
        }

        public static void DeleteAttachment(int id)
        {
            string cmdText = "sp_deleteAttachmentById";
            SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@id", id));
        }

        public static void AddItemChoice(int doc_id, int item_choice)
        {
            string cmdText = "sp_addItemChoice";
            SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@doc_id", doc_id),
                new SqlParameter("@item_choice", item_choice));
        }

        public static int GetItemChoice(int doc_id)
        {
            if (doc_id == 0)
                return -1;
            else
            {
                string cmdText = "SELECT item_choice FROM stoke_item_choice WHERE doc_id = " + doc_id;
                return Convert.ToInt32(SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.Text, cmdText).Rows[0][0]);
            }
        }

        public static DataTable GetDefaultRights()
        {
            string cmdText = "sp_getDefaultRights";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText);
        }

        public static void ModifyDefaultRight(int right_id, int flag)
        {
            string cmdText = "sp_modifyDefaultRight";
            SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@right_id", right_id),
                new SqlParameter("@flag", flag));
        }

        public static DataTable GetEmergencyDegree()
        {
            string cmdText = "sp_getEmergencyDegree";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText);
        }

        public static void SetEmergencyWithDocid(int doc_id, int emergency_level)
        {
            string cmdText = "sp_SetEmergencyWithDocid";
            SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@doc_id", doc_id),
                new SqlParameter("@emergency_level", emergency_level));
        }

        public static int GetEmergencyByDocid(int doc_id)
        {
            string cmdText = "sp_GetEmergencyByDocid";
            return Convert.ToInt32(SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText, new SqlParameter("@doc_id", doc_id)).Rows[0][0]);
        }

        public static DataTable SelectContact(string username, string phonenumber)
        {
            string cmdText = "sp_selectContact";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@username", username),
                new SqlParameter("@phonenumber", phonenumber));
        }

        public static void AddNewStaff(string ry_zgbh, string ry_xm, string ry_bm, string ry_zw)
        {
            string cmdText = "p_NewStaff";
            SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@ry_zgbh", ry_zgbh),
                new SqlParameter("@ry_xm", ry_xm),
                new SqlParameter("@ry_bm", ry_bm),
                new SqlParameter("@ry_zw", ry_zw));
        }

        public static void ModifyStaff(string ry_zgbh, string ry_xm, string ry_bm, string ry_zw)
        {
            string cmdText = "p_modifyStaff";
            SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@ry_zgbh", ry_zgbh),
                new SqlParameter("@ry_xm", ry_xm),
                new SqlParameter("@ry_bm", ry_bm),
                new SqlParameter("@ry_zw", ry_zw));
        }

        public static void ModifyUserInfo1(string SUserNumber, string SUserName, string SSex, string SFixedPhone, string SMobilePhone1, string SMobilePhone2, string SCompanyName, string SPositionName, string SEmail, DateTime DUpdateTime)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter UserNumber = new SqlParameter("@UserNumber", System.Data.SqlDbType.VarChar, 10);
                UserNumber.Value = SUserNumber;
                SqlParameter UserName = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar, 30);
                UserName.Value = SUserName;
                SqlParameter Sex = new SqlParameter("@Sex", System.Data.SqlDbType.NVarChar, 2);
                Sex.Value = SSex;
                SqlParameter FixedPhone = new SqlParameter("@FixedPhone", System.Data.SqlDbType.VarChar, 15);
                FixedPhone.Value = SFixedPhone;
                SqlParameter MobilePhone1 = new SqlParameter("@MobilePhone1", System.Data.SqlDbType.VarChar, 15);
                MobilePhone1.Value = SMobilePhone1;
                SqlParameter MobilePhone2 = new SqlParameter("@MobilePhone2", System.Data.SqlDbType.VarChar, 15);
                MobilePhone2.Value = SMobilePhone2;
                SqlParameter CompanyName = new SqlParameter("@CompanyName", System.Data.SqlDbType.Char, 15);
                CompanyName.Value = SCompanyName;
                SqlParameter PositionName = new SqlParameter("@PositionName", System.Data.SqlDbType.VarChar, 64);
                PositionName.Value = SPositionName;
                SqlParameter Email = new SqlParameter("@Email", System.Data.SqlDbType.VarChar, 50);
                Email.Value = SEmail;
                SqlParameter UpdateTime = new SqlParameter("@UpdateTime", System.Data.SqlDbType.DateTime);
                UpdateTime.Value = DUpdateTime;
                SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_updateUserInfo_Staff", UserNumber, UserName, Sex, FixedPhone, MobilePhone1, MobilePhone2, CompanyName, PositionName, Email, UpdateTime);
            }
        }

        public static void ModifyStaffSet(string ry_zgbh, int flag)
        {
            string cmdText = "sp_modifyStaffSet";
            SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@ry_zgbh", ry_zgbh),
                new SqlParameter("@flag", flag));
        }

        public static void FinishStaff(string doc_id, string flow_id)
        {
            string cmdText = "sp_finishStaff";
            SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@doc_id", doc_id),
                new SqlParameter("@flow_id", flow_id));
        }

        public static DataTable GetStaffSetByBm(string bm)
        {
            string cmdText = "sp_getStaffSetByBm";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@bm", bm));
        }

        public static DataTable GetFlowClass()
        {
            string cmdText = "SELECT class_id, class_name FROM dsoc_flow_class";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.Text, cmdText);
        }

        public static DataTable GetFlowByClass(int class_id)
        {
            string cmdText = "sp_getFlowByClass";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@class_id", class_id));
        }

        public static void AddUserImage(string ry_zgbh, string url)
        {
            string cmdText = "sp_AddUserImage";
            SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@ry_zgbh", ry_zgbh),
                new SqlParameter("@image_url", url));
        }

        public static string GetUserImage(string ry_zgbh)
        {
            string cmdText = "sp_GetUserImage";
            return SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText,
                new SqlParameter("@ry_zgbh", ry_zgbh)).Rows[0][0].ToString();
        }
    }
}
