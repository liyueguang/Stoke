using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Stoke.DAL;

namespace Stoke.BLL
{
    public class SystemUM
    {


        /// <summary>
        /// �������Ȩ������
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPermissions()
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getPermission", null);
            }
        }

        /// <summary>
        /// ����Ȩ�����ƻ�Ȩ���������Ȩ���б�
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPermissions(string SPermissionName, string SPermissionDescription, int IflagPN, int IflagPD)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter PermissionName = new SqlParameter("@PermissionName", System.Data.SqlDbType.VarChar, 64);
                PermissionName.Value = SPermissionName;
                SqlParameter PermissionDescription = new SqlParameter("@PermissionDescription", System.Data.SqlDbType.VarChar, 200);
                PermissionDescription.Value = SPermissionDescription;
                SqlParameter flagPN = new SqlParameter("@flagPN", System.Data.SqlDbType.Int);
                flagPN.Value = IflagPN;
                SqlParameter flagPD = new SqlParameter("@flagPD", System.Data.SqlDbType.Int);
                flagPD.Value = IflagPD;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getPermission", PermissionName, PermissionDescription, flagPN, flagPD);
            }
        }

        /// <summary>
        /// ͨ��id���Ȩ����Ϣ
        /// </summary>
        /// <param name="IPermissionID">Ȩ��ID</param>
        /// <returns></returns>
        public static DataTable GetPermissions(int IPermissionID)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter PermissionID = new SqlParameter("@PermissionID", System.Data.SqlDbType.Int);
                PermissionID.Value = IPermissionID;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getPermission", PermissionID);
            }
        }

        /// <summary>
        /// ���Ȩ����Ϣ
        /// </summary>
        /// <param name="DCreateTime">����ʱ��</param>
        /// <param name="SPageUrl">��ҳ��ַ</param>
        /// <param name="SPermissionCode">Ȩ�޴���</param>
        /// <param name="SPermissionDescription">Ȩ������</param>
        /// <param name="SPermissionName">Ȩ������</param>
        /// <returns>��ӳɹ�����true�����򷵻�false</returns>
        public static bool addPermissionInfo(string SPermissionCode, string SPermissionName, string SPermissionDescription, string SPageUrl, DateTime DCreateTime)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter PermissionCode = new SqlParameter("@PermissionCode", System.Data.SqlDbType.VarChar, 20);
                PermissionCode.Value = SPermissionCode;
                SqlParameter PermissionName = new SqlParameter("@PermissionName", System.Data.SqlDbType.VarChar, 64);
                PermissionName.Value = SPermissionName;
                SqlParameter PermissionDescription = new SqlParameter("@PermissionDescription", System.Data.SqlDbType.VarChar, 200);
                PermissionDescription.Value = SPermissionDescription;
                SqlParameter PageUrl = new SqlParameter("@PageUrl", System.Data.SqlDbType.VarChar, 200);
                PageUrl.Value = SPageUrl;
                SqlParameter CreateTime = new SqlParameter("@CreateTime", System.Data.SqlDbType.DateTime);
                CreateTime.Value = DCreateTime;
                return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_addPermissionInfo", PermissionCode, PermissionName, PermissionDescription, PageUrl, CreateTime) > 0 ? true : false;
            }
        }


        /// <summary>
        /// �޸�Ȩ����Ϣ
        /// </summary>
        /// <param name="DUpdateTime">�޸�ʱ��</param>
        /// <param name="IPermissionID">Ȩ��ID</param>
        /// <param name="SPageUrl">��ҳ��ַ</param>
        /// <param name="SPermissionDescription">Ȩ������</param>
        /// <param name="SPermissionName">Ȩ������</param>
        /// <returns>��ӳɹ�����true�����򷵻�false</returns>
        public static bool updatePermissionInfo(int IPermissionID, string SPermissionName, string SPermissionDescription, DateTime DUpdateTime)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter PermissionID = new SqlParameter("@PermissionID", System.Data.SqlDbType.Int);
                PermissionID.Value = IPermissionID;
                SqlParameter PermissionName = new SqlParameter("@PermissionName", System.Data.SqlDbType.VarChar, 64);
                PermissionName.Value = SPermissionName;
                SqlParameter PermissionDescription = new SqlParameter("@PermissionDescription", System.Data.SqlDbType.VarChar, 200);
                PermissionDescription.Value = SPermissionDescription;
                //SqlParameter PageUrl = new SqlParameter("@PageUrl", System.Data.SqlDbType.VarChar, 200);
                //PageUrl.Value = SPageUrl;
                SqlParameter UpdateTime = new SqlParameter("@UpdateTime", System.Data.SqlDbType.DateTime);
                UpdateTime.Value = DUpdateTime;
                return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_updatePermissionInfo", PermissionID, PermissionName, PermissionDescription, UpdateTime) > 0 ? true : false;
            }
        }

        /// <summary>
        /// �������ƣ��������Ȩ�����ƣ����жϸ�Ȩ�������Ƿ����xl
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPermissionsByNameID(string SPermissionName, string SPermissionCode)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getPermissionByName", new SqlParameter("@PermissionName", SPermissionName), new SqlParameter("@PermissionCode", SPermissionCode));
            }
        }


        /// <summary>
        /// ���ݽ�ɫ���ƺ�������ý�ɫ��Ϣ
        /// </summary>
        /// <param name="SRoleName">��ɫ����</param>
        /// <param name="SRoleDescription">��ɫ����</param>
        /// <param name="SManageHighLevel">����Ա��߼��� xl���</param>
        /// <returns>��ɫ��Ϣ�б�</returns>
        public static DataTable GetRoleInfoByRoleND(string SRoleName, string SRoleDescription, int IflagD)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter RoleName = new SqlParameter("@RoleName", System.Data.SqlDbType.VarChar, 64);
                RoleName.Value = SRoleName;
                SqlParameter RoleDescription = new SqlParameter("@RoleDescription", System.Data.SqlDbType.VarChar, 200);
                RoleDescription.Value = SRoleDescription;
                SqlParameter flagD = new SqlParameter("@flagD", System.Data.SqlDbType.Int);
                flagD.Value = IflagD;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getRoleInfoByRoleND", RoleName, RoleDescription, flagD);
            }
        }

        /// <summary>
        /// ���ݱ�Ż�ý�ɫ��Ϣ
        /// </summary>
        /// <param name="RoleID">��ɫID</param>
        /// <returns>��ɫ��Ϣ�б�</returns>
        public static DataTable GetRolesPermissitionByID(int IRoleID)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter RoleID = new SqlParameter("@RoleID", System.Data.SqlDbType.Int);
                RoleID.Value = IRoleID;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getRolesPermissionByID", RoleID);
            }
        }

        /// <summary>
        /// ɾ����ɫ��Ϣ
        /// </summary>
        /// <param name="IRoleID">��ɫID</param>
        /// <returns>��ӳɹ�����true�����򷵻�false</returns>
        public static bool deleteRoleInfoByID(int IRoleID)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter RoleID = new SqlParameter("@RoleID", System.Data.SqlDbType.Int);
                RoleID.Value = IRoleID;
                return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_delelteRoleInfoByRoleID", RoleID) > 0 ? true : false;
            }
        }


        /// <summary>
        /// ͨ��Ȩ�޼�����Ȩ����Ϣ�����ڰ�Ȩ����xl
        /// </summary>
        /// <param name="IPermissionLevel">Ȩ�޼���</param>
        /// <param name="ICode">���ݼ����ȡ���ַ���</param> 
        /// <param name="IManageHighLevel">����Ա��ɫ��߼���</param> 
        /// <returns></returns>
        public static DataTable GetPermissionsByLevel(string IPermissionLevel, string ICode)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter PermissionLevel = new SqlParameter("@level", System.Data.SqlDbType.Char, 1);
                PermissionLevel.Value = IPermissionLevel;
                SqlParameter Code = new SqlParameter("@code", System.Data.SqlDbType.VarChar, 20);
                Code.Value = ICode;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getPermissionByLevel", PermissionLevel, Code);
            }
        }

        /// <summary>
        /// �������ơ����𣬻�ý�ɫ��Ϣxl
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRolesByName(string SRoleName, string SRoleCode)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter RoleName = new SqlParameter("@RoleName", System.Data.SqlDbType.VarChar, 64);
                RoleName.Value = SRoleName;
                SqlParameter RoleCode = new SqlParameter("@RoleCode", System.Data.SqlDbType.VarChar, 100);
                RoleCode.Value = SRoleCode;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getRoleByName", RoleName, RoleCode);
            }
        }

        ///<Summary>
        ///�жϽ�ɫ�����Ƿ��ظ�
        ///</Summary>
        ///<para name="IRoleID">��ɫ���</para>
        ///<para name="SRoleName">��ɫ����</para>
        ///<para name="SRoleLevelNum">��ɫ����</para>
        ///<returns>��ɫ�����ظ�����false�����򷵻�true</returns>
        public static int CheckRoleNamebyIRL(int IRoleID, string SRoleName)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter RoleID = new SqlParameter("@RoleID", System.Data.SqlDbType.Int);
                SqlParameter RoleName = new SqlParameter("@RoleName", System.Data.SqlDbType.VarChar, 64);
                SqlParameter ReturnValue = new SqlParameter("@count", System.Data.SqlDbType.Int);
                RoleID.Value = IRoleID;
                RoleName.Value = SRoleName;
                ReturnValue.Direction = ParameterDirection.ReturnValue;
                SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_CheckRoleNamebyIRL", RoleID, RoleName, ReturnValue);
                return Convert.ToInt32(ReturnValue.Value);
            }
        }

        /// <summary>
        /// �޸Ľ�ɫ��Ϣ
        /// </summary>
        /// <returns>��ӳɹ�����true�����򷵻�false</returns>
        public static bool updateRoleInfo(int IRoleID, string SRoleName, string SRoleDescription, string SPermissionRange, DateTime DUpdateTime)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter RoleID = new SqlParameter("@RoleID", System.Data.SqlDbType.Int);
                RoleID.Value = IRoleID;
                SqlParameter RoleName = new SqlParameter("@RoleName", System.Data.SqlDbType.VarChar, 64);
                RoleName.Value = SRoleName;
                SqlParameter RoleDescription = new SqlParameter("@RoleDescription", System.Data.SqlDbType.VarChar, 200);
                RoleDescription.Value = SRoleDescription;
                SqlParameter PermissionRange = new SqlParameter("@PermissionRange", System.Data.SqlDbType.NVarChar);
                PermissionRange.Value = SPermissionRange;
                SqlParameter UpdateTime = new SqlParameter("@UpdateTime", System.Data.SqlDbType.DateTime);
                UpdateTime.Value = DUpdateTime;
                return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_updateRoleInfo", RoleID, RoleName, RoleDescription, PermissionRange, UpdateTime) > 0 ? true : false;
            }
        }


        /// <summary>
        /// ��ӽ�ɫ��Ϣ
        /// </summary>
        /// <param name="DCreateTime">����ʱ��</param>
        /// <param name="SPermissionRange">Ȩ�޷�Χ</param>
        /// <param name="SRoleCode">��ɫ����</param>
        /// <param name="SRoleDescription">��ɫ����</param>
        /// <param name="SRoleName">��ɫ����</param>
        /// <returns>��ӳɹ�����true�����򷵻�false</returns>
        public static bool addRoleInfo(string SRoleName, string SRoleCode, string SRoleDescription, string SPermissionRange, DateTime DCreateTime)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter RoleName = new SqlParameter("@RoleName", System.Data.SqlDbType.VarChar, 64);
                RoleName.Value = SRoleName;
                SqlParameter RoleCode = new SqlParameter("@RoleCode", System.Data.SqlDbType.VarChar, 20);
                RoleCode.Value = SRoleCode;
                SqlParameter RoleDescription = new SqlParameter("@RoleDescription", System.Data.SqlDbType.VarChar, 200);
                RoleDescription.Value = SRoleDescription;
                SqlParameter PermissionRange = new SqlParameter("@PermissionRange", System.Data.SqlDbType.NVarChar);
                PermissionRange.Value = SPermissionRange;
                SqlParameter CreateTime = new SqlParameter("@CreateTime", System.Data.SqlDbType.DateTime);
                CreateTime.Value = DCreateTime;
                return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_addRoleInfoPermission", RoleCode, RoleDescription, RoleName, PermissionRange, CreateTime) > 0 ? true : false;
            }
        }

        /// <summary>
        /// ���ݽ�ɫ����λ��ְ����������û���Ϣ
        /// </summary>
        /// <param name="SUserName">�û�����</param>
        /// <param name="SRoleCode">��ɫ����</param>
        /// <param name="SPositionName">ְ������</param>
        /// <param name="SManageHighLevel">����Ա��߽�ɫ����xl</param>
        /// <param name="SManageUserNumber">����Ա�û����xl</param>
        /// <param name="SCompanyName">��λ����</param>
        /// <returns>�û���Ϣ�б�</returns>
        public static DataTable GetUserInfoByNRPC(string SRoleCode, string SCompanyName, string SPositionName, string SUserName)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter RoleCode = new SqlParameter("@RoleCode", SqlDbType.VarChar, 20);
                RoleCode.Value = SRoleCode;
                SqlParameter CompanyName = new SqlParameter("@CompanyName", SqlDbType.Char, 30);
                CompanyName.Value = SCompanyName;
                SqlParameter PositionName = new SqlParameter("@PositionName", SqlDbType.VarChar, 64);
                PositionName.Value = SPositionName;
                SqlParameter UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 30);
                UserName.Value = SUserName;

                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getUserInfoLoginRoles", RoleCode, CompanyName, PositionName, UserName);
            }
        }


        /// <summary>
        /// ɾ���û���Ϣ  
        /// </summary>
        /// <param name="IUserID">�û�ID</param>
        /// <returns>��ӳɹ�����true�����򷵻�false</returns>
        public static bool deleteUserInfo(int IUserID)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter UserID = new SqlParameter("@UserID", System.Data.SqlDbType.Int);
                UserID.Value = IUserID;
                return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_deleteUserInfoRoleLogin", UserID) > 0 ? true : false;
            }
        }

        /// <summary>
        /// ������н�ɫ�����ȡ�ü����������н�ɫ����
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRolesByLevel()
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getRolesByLevel");
            }
        }

        /// <summary>
        /// ����UserID����û���Ϣ
        /// </summary>
        /// <param name="UserID">���</param>
        /// <returns>�û���Ϣ�б�</returns>
        public static DataTable GetUserInfoByID(int UserID)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter UserNumber = new SqlParameter("@UserID", System.Data.SqlDbType.Int);
                UserNumber.Value = UserID;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getUserInfoByNUM", UserNumber);
            }
        }

        /// <summary>
        /// ���ݱ�Ż���û���ɫ��Ϣ
        /// </summary>
        /// <param name="SUserNumber">�û����</param>
        /// <returns>�û���ɫ��Ϣ�б�</returns>
        public static DataTable GetUserRoleByNum(string SUserNumber)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter UserNumber = new SqlParameter("@UserNumber", System.Data.SqlDbType.VarChar, 10);
                UserNumber.Value = SUserNumber;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getUserRoleRange", UserNumber);
            }
        }

        /// <summary>
        /// ͨ���û���ţ���ȡ�û���¼��Ŀ
        /// </summary>
        /// <param name="UserNumber">�û����</param>
        /// <returns>�û���Ŀ</returns>
        public static int GetUserCountByNum(string SUserNumber)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                SqlParameter UserNumber = new SqlParameter("@UserNumber", System.Data.SqlDbType.VarChar, 10);
                UserNumber.Value = SUserNumber;
                DataTable dt = SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getUserNumberByNum", UserNumber);
                return dt.Rows.Count;
            }
        }

        /// <summary>
        /// �޸��û���Ϣ
        /// </summary>
        /// <param name="OUserNumber">ԭ��¼��</param>
        /// <param name="UserNumber">��¼��</param>
        /// <param name="LoginPassword">����</param>//��ɾ��xl
        /// <param name="UserName">��ʵ����</param>
        /// <param name="Sex">�Ա�</param>
        /// <param name="FixedPhone">�̶��绰</param>
        /// <param name="MobilePhone1">�ƶ��绰</param>
        /// <param name="MobilePhone2">�ƶ��绰</param>
        /// <param name="CompanyName">��λ����</param>
        /// <param name="PositionName">ְ������</param>
        /// <param name="PositionRank">ְλ����</param>
        /// <param name="Email">��������</param>
        /// <param name="CreateTime">����ʱ��</param>
        /// <param name="UserRange">�û���ɫ��Χ</param>
        /// <returns>��ӳɹ�����true�����򷵻�false</returns>
        public static bool updateUserInfo(string SOUserNumber, string SUserNumber, string SUserName, string SSex, string SFixedPhone, string SMobilePhone1, string SMobilePhone2, string SCompanyName, string SPositionName, string SEmail, DateTime DUpdateTime, string SUserRange)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter OUserNumber = new SqlParameter("@OUserNumber", System.Data.SqlDbType.VarChar, 10);
                OUserNumber.Value = SOUserNumber;
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
                SqlParameter UserRange = new SqlParameter("@UserRange", System.Data.SqlDbType.NVarChar);
                UserRange.Value = SUserRange;
                return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_updateUserInfo", OUserNumber, UserNumber, UserName, Sex, FixedPhone, MobilePhone1, MobilePhone2, CompanyName, PositionName, Email, UpdateTime, UserRange) > 0 ? true : false;
            }
        }

        /// <Summary>
        /// �޸��û�����
        /// </Summary>
        /// <para name="SUserNumber">�û����</para>
        /// <para name="SUserNumber">�û�������</para>
        /// <returns></returns>

        public static bool UpdeateUserPwd(string SUserNumber, string SPwd)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_updateUserPwd", new SqlParameter("@UserNumber", SUserNumber), new SqlParameter("@LoginPassword", SPwd)) > 0 ? true : false;
            }
        }

        /// <summary>
        /// ����û���Ϣ
        /// </summary>
        /// <param name="UserNumber">��¼��</param>
        /// <param name="LoginPassword">����</param>
        /// <param name="UserName">��ʵ����</param>
        /// <param name="Sex">�Ա�</param>
        /// <param name="FixedPhone">�̶��绰</param>
        /// <param name="MobilePhone1">�ƶ��绰</param>
        /// <param name="MobilePhone2">�ƶ��绰</param>
        /// <param name="CompanyName">��λ����</param>
        /// <param name="PositionName">ְ������</param>
        /// <param name="PositionRank">ְλ����</param>
        /// <param name="Email">��������</param>
        /// <param name="CreateTime">����ʱ��</param>
        /// <param name="UserRange">�û���ɫ��Χ</param>
        /// <returns>��ӳɹ�����true�����򷵻�false</returns>
        public static bool addUserInfo(string SUserNumber, string SLoginPassword, string SUserName, string SSex, string SFixedPhone, string SMobilePhone1, string SMobilePhone2, string SCompanyName, string SPositionName, string SEmail, DateTime DCreateTime, string SUserRange)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter UserNumber = new SqlParameter("@UserNumber", System.Data.SqlDbType.VarChar, 10);
                UserNumber.Value = SUserNumber;
                SqlParameter LoginPassword = new SqlParameter("@LoginPassword", System.Data.SqlDbType.VarChar, 64);
                LoginPassword.Value = SLoginPassword;
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
                SqlParameter CreateTime = new SqlParameter("@CreateTime", System.Data.SqlDbType.DateTime);
                CreateTime.Value = DCreateTime;
                SqlParameter UserRange = new SqlParameter("@UserRange", System.Data.SqlDbType.NVarChar);
                UserRange.Value = SUserRange;
                return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_addUserInfo", UserNumber, LoginPassword, UserName, Sex, FixedPhone, MobilePhone1, MobilePhone2, CompanyName, PositionName, Email, CreateTime, UserRange) > 0 ? true : false;
            }
        }

        /// <summary>
        /// ���ݱ�Ż���û���Ϣ
        /// </summary>
        /// <param name="SUserNumber">�û����</param>
        /// <returns>�û���Ϣ�б�</returns>
        public static DataTable checkUserByNum(string SUserNumber)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter UserNumber = new SqlParameter("@UserNumber", System.Data.SqlDbType.VarChar, 10);
                UserNumber.Value = SUserNumber;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_checkUserByNum", UserNumber);
            }
        }

        /// <summary>
        /// �����Ϣ
        /// </summary>
        /// <param name="SMsgSend">������</param>
        /// <param name="SMsgReceive">������</param>
        /// <param name="SMessage">��Ϣ</param>
        /// <param name="SSendDate">���ʱ��</param>
        /// <returns>��ӳɹ�����true�����򷵻�false</returns>
        public static bool addMessage(string SMsgSend, string SMsgReceive, string SMsgType, string SMsgTitle, string SMessage, string SSendDate, string sfile, string sfilename)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter MsgSend = new SqlParameter("@MsgSend", System.Data.SqlDbType.VarChar, 30);
                MsgSend.Value = SMsgSend;
                SqlParameter MsgReceive = new SqlParameter("@MsgReceive", System.Data.SqlDbType.VarChar, 1000);
                MsgReceive.Value = SMsgReceive;
                SqlParameter MsgType = new SqlParameter("@MsgType", System.Data.SqlDbType.VarChar, 50);
                MsgType.Value = SMsgType;
                SqlParameter MsgTitle = new SqlParameter("@MsgTitle", System.Data.SqlDbType.VarChar, 100);
                MsgTitle.Value = SMsgTitle;
                SqlParameter Message = new SqlParameter("@Message", System.Data.SqlDbType.VarChar, 800);
                Message.Value = SMessage;
                SqlParameter SendDate = new SqlParameter("@SendDate", System.Data.SqlDbType.VarChar, 50);
                SendDate.Value = SSendDate;
                SqlParameter file = new SqlParameter("@FileName", System.Data.SqlDbType.VarChar, 100);
                file.Value = sfile;
                SqlParameter filename = new SqlParameter("@FileRealName", System.Data.SqlDbType.VarChar, 200);
                filename.Value = sfilename;
                return SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_addMessage", MsgSend, MsgReceive, MsgType, MsgTitle, Message, SendDate, file, filename) > 0 ? true : false;
            }
        }

        /// <summary>
        /// ���ݱ�Ż����Ϣ
        /// </summary>
        /// <param name="SUserNumber">�û����</param>
        /// <returns>��Ϣ�б�</returns>
        public static DataTable GetMessageByNum(string SUserNumber, string SMsgTitle, string SMessage, int flag)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter UserNumber = new SqlParameter("@UserNumber", System.Data.SqlDbType.VarChar, 10);
                UserNumber.Value = SUserNumber;
                SqlParameter MsgTitle = new SqlParameter("@MsgTitle", System.Data.SqlDbType.VarChar, 100);
                MsgTitle.Value = SMsgTitle;
                SqlParameter Message = new SqlParameter("@Message", System.Data.SqlDbType.VarChar, 800);
                Message.Value = SMessage;
                SqlParameter fflag = new SqlParameter("@flag", System.Data.SqlDbType.Int);
                fflag.Value = flag;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getMessage", UserNumber, MsgTitle, Message, fflag);
            }
        }

        /// <summary>
        /// ���ݱ�Ż����Ϣ
        /// </summary>
        /// <param name="SUserNumber">��Ϣ���</param>
        /// <returns></returns>
        public static DataTable GetMessageByID(int msgid)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter imsgid = new SqlParameter("@MsgID", System.Data.SqlDbType.Int);
                imsgid.Value = msgid;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getMessageByID", imsgid);
            }
        }

        //�޸���Ϣ
        public static DataTable EditMessageByID(int msgid, string smsgreceive, string smsgtype, string smsgtitle, string smessage, string sdate, string sfile, string sfilename)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter imsgid = new SqlParameter("@MsgID", System.Data.SqlDbType.Int);
                imsgid.Value = msgid;
                SqlParameter msgreceive = new SqlParameter("@MsgReceive", System.Data.SqlDbType.VarChar, 1000);
                msgreceive.Value = smsgreceive;
                SqlParameter msgtype = new SqlParameter("@MsgType", System.Data.SqlDbType.VarChar, 50);
                msgtype.Value = smsgtype;
                SqlParameter msgtitle = new SqlParameter("@MsgTitle", System.Data.SqlDbType.VarChar, 100);
                msgtitle.Value = smsgtitle;
                SqlParameter message = new SqlParameter("@Message", System.Data.SqlDbType.VarChar, 800);
                message.Value = smessage;
                SqlParameter date = new SqlParameter("@SendDate", System.Data.SqlDbType.VarChar, 50);
                date.Value = sdate;
                SqlParameter file = new SqlParameter("@FileName", System.Data.SqlDbType.VarChar, 100);
                file.Value = sfile;
                SqlParameter filename = new SqlParameter("@FileRealName", System.Data.SqlDbType.VarChar, 200);
                filename.Value = sfilename;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_editMessageByID", imsgid, msgreceive, msgtype, msgtitle, message, date, file, filename);
            }
        }

        //�޸���ϢIsRead
        public static DataTable EditMessageRead(int msgid, string susernum)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter imsgid = new SqlParameter("@MsgID", System.Data.SqlDbType.Int);
                imsgid.Value = msgid;
                SqlParameter usernum = new SqlParameter("@IsRead", System.Data.SqlDbType.VarChar, 10);
                usernum.Value = susernum;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_editMessageRead", imsgid, usernum);
            }
        }

        /// <summary>
        /// ���ݱ�Ż����Ϣ
        /// </summary>
        /// <param name="SUserNumber">�û����</param>
        /// <returns>��Ϣ�б�</returns>
        public static DataTable GetMessageByCount(string SUserNumber, string count, string sleixing, string sdate)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter UserNumber = new SqlParameter("@UserNumber", System.Data.SqlDbType.VarChar, 10);
                UserNumber.Value = SUserNumber;
                SqlParameter fcount = new SqlParameter("@count", System.Data.SqlDbType.VarChar, 10);
                fcount.Value = count;
                SqlParameter leixing = new SqlParameter("@MsgType", System.Data.SqlDbType.VarChar, 50);
                leixing.Value = sleixing;
                SqlParameter date = new SqlParameter("@SendDate", System.Data.SqlDbType.VarChar, 50);
                date.Value = sdate;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getMessageByCount", UserNumber, fcount, leixing, date);
            }
        }


        /// <summary>
        /// �õ�δ����Ϣ����
        /// </summary>
        /// <param name="SUserNumber">�û����</param>
        /// <returns>��Ϣ�б�</returns>
        public static DataTable GetUnreadMessage(string SUserNumber)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter UserNumber = new SqlParameter("@UserNumber", System.Data.SqlDbType.VarChar, 10);
                UserNumber.Value = SUserNumber;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getUnreadMessage", UserNumber);
            }
        }


        /// <summary>
        /// �õ�ģ����Ϣ  0Ϊ�õ�������Ϣ  1�õ�ID������Ϣ  2ɾ��
        /// </summary>
        /// <returns>��ӳɹ�����true�����򷵻�false</returns>
        public static DataTable GetDocInfo(string DocName, string DocDesc, string id, string flag)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter SDocName = new SqlParameter("@DocName", System.Data.SqlDbType.VarChar, 80);
                SDocName.Value = DocName;
                SqlParameter SDocDesc = new SqlParameter("@DocDesc", System.Data.SqlDbType.VarChar, 200);
                SDocDesc.Value = DocDesc;
                SqlParameter Sid = new SqlParameter("@id", System.Data.SqlDbType.VarChar, 10);
                Sid.Value = id;
                SqlParameter Sflag = new SqlParameter("@flag", System.Data.SqlDbType.VarChar, 2);
                Sflag.Value = flag;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getDocInfo", SDocName, SDocDesc, Sid, Sflag);
            }
        }

        /// <summary>
        /// �õ�����֪ʶ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFinanceInfo(string title, string finance, string fdate, string id, string flag)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter SDocName = new SqlParameter("@Title", System.Data.SqlDbType.VarChar, 80);
                SDocName.Value = title;
                SqlParameter SDocDesc = new SqlParameter("@Finance", System.Data.SqlDbType.NText);
                SDocDesc.Value = finance;
                SqlParameter SDate = new SqlParameter("@FDate", System.Data.SqlDbType.VarChar, 50);
                SDate.Value = fdate;
                SqlParameter Sid = new SqlParameter("@id", System.Data.SqlDbType.VarChar, 10);
                Sid.Value = id;
                SqlParameter Sflag = new SqlParameter("@flag", System.Data.SqlDbType.VarChar, 2);
                Sflag.Value = flag;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_editFinance", Sid, SDocName, SDocDesc, SDate, Sflag);
            }
        }

        /// <summary>
        /// ��ӹ�����Ϣ
        /// </summary>
        public static bool editReportInfo(string ID, string RepID, string ShareID, string ShareName, string Company, string Author, string RepName, string RepContent, string RepDate, string RepDesc, string Realtime, string flag)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter sid = new SqlParameter("@ID", System.Data.SqlDbType.VarChar, 10);
                sid.Value = ID;
                SqlParameter rid = new SqlParameter("@RepID", System.Data.SqlDbType.VarChar, 50);
                rid.Value = RepID;
                SqlParameter shid = new SqlParameter("@ShareID", System.Data.SqlDbType.VarChar, 50);
                shid.Value = ShareID;
                SqlParameter sn = new SqlParameter("@ShareName", System.Data.SqlDbType.VarChar, 50);
                sn.Value = ShareName;
                SqlParameter com = new SqlParameter("@Company", System.Data.SqlDbType.VarChar, 100);
                com.Value = Company;
                SqlParameter au = new SqlParameter("@Author", System.Data.SqlDbType.VarChar, 50);
                au.Value = Author;
                SqlParameter rn = new SqlParameter("@RepName", System.Data.SqlDbType.VarChar, 100);
                rn.Value = RepName;
                SqlParameter rc = new SqlParameter("@RepContent", System.Data.SqlDbType.NText);
                rc.Value = RepContent;
                SqlParameter rd = new SqlParameter("@RepDate", System.Data.SqlDbType.VarChar, 50);
                rd.Value = RepDate;
                SqlParameter rde = new SqlParameter("@RepDesc", System.Data.SqlDbType.VarChar, 1000);
                rde.Value = RepDesc;
                SqlParameter rt = new SqlParameter("@RealTime", System.Data.SqlDbType.VarChar, 50);
                rt.Value = Realtime;
                SqlParameter fl = new SqlParameter("@flag", System.Data.SqlDbType.VarChar, 2);
                fl.Value = flag;
                int cc = SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_editReport", sid, rid, shid, sn, com, au, rn, rc, rd, rde, rt, fl);
                return cc > 0 ? true : false;
            }
        }

        /// <summary>
        /// �õ�������Ϣ  0Ϊ�õ�������Ϣ  1�õ�ID������Ϣ  2ɾ��
        /// </summary>
        /// <returns>��ӳɹ�����true�����򷵻�false</returns>
        public static DataTable GetRepInfo(string RepName, string RepContent, string Company, string id, string flag)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter SRepName = new SqlParameter("@RepName", System.Data.SqlDbType.VarChar, 100);
                SRepName.Value = RepName;
                SqlParameter SRepContent = new SqlParameter("@RepContent", System.Data.SqlDbType.VarChar, 200);
                SRepContent.Value = RepContent;
                SqlParameter SCompany = new SqlParameter("@Company", System.Data.SqlDbType.VarChar, 100);
                SCompany.Value = Company;
                SqlParameter Sid = new SqlParameter("@id", System.Data.SqlDbType.VarChar, 10);
                Sid.Value = id;
                SqlParameter Sflag = new SqlParameter("@flag", System.Data.SqlDbType.VarChar, 2);
                Sflag.Value = flag;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getRepInfo", SRepName, SRepContent, SCompany, Sid, Sflag);
            }
        }

        /// <summary>
        /// �õ���������
        /// </summary>
        public static DataTable GetRepByCount(string count)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter fcount = new SqlParameter("@count", System.Data.SqlDbType.VarChar, 10);
                fcount.Value = count;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getRepByCount", fcount);
            }
        }

        /// <summary>
        /// �õ��걨�����û�
        /// </summary>
        public static DataTable GetAnnualUser(string flag)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter fflag = new SqlParameter("@AnnualType", System.Data.SqlDbType.VarChar, 10);
                fflag.Value = flag;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getAnnualUser", fflag);
            }
        }

        /// <summary>
        /// �õ��걨ʱ��
        /// </summary>
        public static DataTable GetAnnual()
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getAnnual",null);
            }
        }

        /// <summary>
        /// ��ӹ�����Ϣ
        /// </summary>
        public static void UpdateAnnual(string AnnualDate, string AnnualUser, string HalfAnnualDate1, string HalfAnnualDate2, string HalfAnnualUser, string ModifyUser, string ModifyDate)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter sAnnualDate = new SqlParameter("@AnnualDate", System.Data.SqlDbType.VarChar, 30);
                sAnnualDate.Value = AnnualDate;
                SqlParameter sAnnualUser = new SqlParameter("@AnnualUser", System.Data.SqlDbType.VarChar, 1000);
                sAnnualUser.Value = AnnualUser;
                SqlParameter sHalfAnnualDate1 = new SqlParameter("@HalfAnnualDate1", System.Data.SqlDbType.VarChar, 30);
                sHalfAnnualDate1.Value = HalfAnnualDate1;
                SqlParameter sHalfAnnualDate2 = new SqlParameter("@HalfAnnualDate2", System.Data.SqlDbType.VarChar, 30);
                sHalfAnnualDate2.Value = HalfAnnualDate2;
                SqlParameter sHalfAnnualUser = new SqlParameter("@HalfAnnualUser", System.Data.SqlDbType.VarChar, 1000);
                sHalfAnnualUser.Value = HalfAnnualUser;
                SqlParameter sModifyUser = new SqlParameter("@ModifyUser", System.Data.SqlDbType.VarChar, 30);
                sModifyUser.Value = ModifyUser;
                SqlParameter sModifyDate = new SqlParameter("@ModifyDate", System.Data.SqlDbType.VarChar, 50);
                sModifyDate.Value = ModifyDate;
                SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_UpdateAnnual", sAnnualDate, sAnnualUser, sHalfAnnualDate1, sHalfAnnualDate2, sHalfAnnualUser, sModifyUser, sModifyDate);
            }
        }

        /// <summary>
        /// �õ������ʼ����Ϣ
        /// </summary>
        public static DataTable GetInitInfo()
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getInit", null);
            }
        }

        /// <summary>
        /// ��ӹ����ʼ����Ϣ
        /// </summary>
        public static void UpdateInitInfo(string ShareID, string ShareName, string Company, string Author, string RepDesc)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter sShareID = new SqlParameter("@ShareID", System.Data.SqlDbType.VarChar, 50);
                sShareID.Value = ShareID;
                SqlParameter sShareName = new SqlParameter("@ShareName", System.Data.SqlDbType.VarChar, 50);
                sShareName.Value = ShareName;
                SqlParameter sCompany = new SqlParameter("@Company", System.Data.SqlDbType.VarChar, 100);
                sCompany.Value = Company;
                SqlParameter sAuthor = new SqlParameter("@Author", System.Data.SqlDbType.VarChar, 50);
                sAuthor.Value = Author;
                SqlParameter sRepDesc = new SqlParameter("@RepDesc", System.Data.SqlDbType.VarChar, 1000);
                sRepDesc.Value = RepDesc;

                SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_UpdateInit", sShareID, sShareName, sCompany, sAuthor, sRepDesc);
            }
        }

        /// <summary>
        /// �õ�doc��Ϣ
        /// </summary>
        public static DataTable GetDocInfoByDocID(string docid)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter fdocid = new SqlParameter("@doc_id", System.Data.SqlDbType.Int);
                fdocid.Value = docid;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getDocInfoByDocID", fdocid);
            }
        }

        /// <summary>
        /// �õ���Ϣ�����û�
        /// </summary>
        public static DataTable GetMessageUser(int id)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter fflag = new SqlParameter("@ID", System.Data.SqlDbType.Int, 30);
                fflag.Value = id;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getMessageUser", fflag);
            }
        }

        /// <summary>
        /// �õ���Ϣ������Ա�б�
        /// </summary>
        public static DataTable GetMessageUserList(string userlist)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter fflag = new SqlParameter("@UserRange", System.Data.SqlDbType.VarChar, 1000);
                fflag.Value = userlist;
                return SQLHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "stoke_getMessageUserList", fflag);
            }
        }


        /// <summary>
        /// ���ģ����Ϣ
        /// </summary>
        public static void addDocInfo(string docname, string realname, string docdesc, string doctype, string author, string realdate)
        {
            using (SqlConnection con = new SqlConnection(SQLHelper.CONN_STRING))
            {
                con.Open();
                SqlParameter sdocname = new SqlParameter("@DocName", System.Data.SqlDbType.VarChar, 80);
                sdocname.Value = docname;
                SqlParameter srealname = new SqlParameter("@DocRealName", System.Data.SqlDbType.VarChar, 100);
                srealname.Value = realname;
                SqlParameter sdocdesc = new SqlParameter("@DocDesc", System.Data.SqlDbType.VarChar, 200);
                sdocdesc.Value = docdesc;
                SqlParameter sdoctype = new SqlParameter("@DocType", System.Data.SqlDbType.VarChar, 50);
                sdoctype.Value = doctype;
                SqlParameter sauthor = new SqlParameter("@DocAuthor", System.Data.SqlDbType.VarChar, 50);
                sauthor.Value = author;
                SqlParameter srealdate = new SqlParameter("@DocDate", System.Data.SqlDbType.VarChar, 50);
                srealdate.Value = realdate;
                SQLHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "stoke_addDocInfo", sdocname, srealname, sdocdesc, sdoctype, sauthor, srealdate);
            }
        }
    }
}
