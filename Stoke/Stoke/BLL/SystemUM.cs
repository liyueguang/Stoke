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
        /// 获得所有权限名称
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
        /// 根据权限名称或权限描述获得权限列表
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
        /// 通过id获得权限信息
        /// </summary>
        /// <param name="IPermissionID">权限ID</param>
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
        /// 添加权限信息
        /// </summary>
        /// <param name="DCreateTime">创建时间</param>
        /// <param name="SPageUrl">网页地址</param>
        /// <param name="SPermissionCode">权限代码</param>
        /// <param name="SPermissionDescription">权限描述</param>
        /// <param name="SPermissionName">权限名称</param>
        /// <returns>添加成功返回true，否则返回false</returns>
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
        /// 修改权限信息
        /// </summary>
        /// <param name="DUpdateTime">修改时间</param>
        /// <param name="IPermissionID">权限ID</param>
        /// <param name="SPageUrl">网页地址</param>
        /// <param name="SPermissionDescription">权限描述</param>
        /// <param name="SPermissionName">权限名称</param>
        /// <returns>添加成功返回true，否则返回false</returns>
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
        /// 根据名称，获得所有权限名称，以判断该权限名称是否存在xl
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
        /// 根据角色名称和描述获得角色信息
        /// </summary>
        /// <param name="SRoleName">角色名称</param>
        /// <param name="SRoleDescription">角色描述</param>
        /// <param name="SManageHighLevel">管理员最高级别 xl添加</param>
        /// <returns>角色信息列表</returns>
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
        /// 根据编号获得角色信息
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns>角色信息列表</returns>
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
        /// 删除角色信息
        /// </summary>
        /// <param name="IRoleID">角色ID</param>
        /// <returns>添加成功返回true，否则返回false</returns>
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
        /// 通过权限级别获得权限信息，用于绑定权限树xl
        /// </summary>
        /// <param name="IPermissionLevel">权限级别</param>
        /// <param name="ICode">根据级别截取的字符串</param> 
        /// <param name="IManageHighLevel">管理员角色最高级别</param> 
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
        /// 根据名称、级别，获得角色信息xl
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
        ///判断角色名称是否重复
        ///</Summary>
        ///<para name="IRoleID">角色编号</para>
        ///<para name="SRoleName">角色名称</para>
        ///<para name="SRoleLevelNum">角色级别</para>
        ///<returns>角色名称重复返回false，否则返回true</returns>
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
        /// 修改角色信息
        /// </summary>
        /// <returns>添加成功返回true，否则返回false</returns>
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
        /// 添加角色信息
        /// </summary>
        /// <param name="DCreateTime">创建时间</param>
        /// <param name="SPermissionRange">权限范围</param>
        /// <param name="SRoleCode">角色代码</param>
        /// <param name="SRoleDescription">角色描述</param>
        /// <param name="SRoleName">角色名称</param>
        /// <returns>添加成功返回true，否则返回false</returns>
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
        /// 根据角色、单位、职务、姓名获得用户信息
        /// </summary>
        /// <param name="SUserName">用户姓名</param>
        /// <param name="SRoleCode">角色代码</param>
        /// <param name="SPositionName">职务名称</param>
        /// <param name="SManageHighLevel">管理员最高角色级别xl</param>
        /// <param name="SManageUserNumber">管理员用户编号xl</param>
        /// <param name="SCompanyName">单位名称</param>
        /// <returns>用户信息列表</returns>
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
        /// 删除用户信息  
        /// </summary>
        /// <param name="IUserID">用户ID</param>
        /// <returns>添加成功返回true，否则返回false</returns>
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
        /// 获得所有角色级别获取该级别以下所有角色级别
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
        /// 根据UserID获得用户信息
        /// </summary>
        /// <param name="UserID">编号</param>
        /// <returns>用户信息列表</returns>
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
        /// 根据编号获得用户角色信息
        /// </summary>
        /// <param name="SUserNumber">用户编号</param>
        /// <returns>用户角色信息列表</returns>
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
        /// 通过用户编号，获取用户记录数目
        /// </summary>
        /// <param name="UserNumber">用户编号</param>
        /// <returns>用户数目</returns>
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
        /// 修改用户信息
        /// </summary>
        /// <param name="OUserNumber">原登录名</param>
        /// <param name="UserNumber">登录名</param>
        /// <param name="LoginPassword">密码</param>//已删除xl
        /// <param name="UserName">真实姓名</param>
        /// <param name="Sex">性别</param>
        /// <param name="FixedPhone">固定电话</param>
        /// <param name="MobilePhone1">移动电话</param>
        /// <param name="MobilePhone2">移动电话</param>
        /// <param name="CompanyName">单位代码</param>
        /// <param name="PositionName">职务名称</param>
        /// <param name="PositionRank">职位级别</param>
        /// <param name="Email">电子邮箱</param>
        /// <param name="CreateTime">创建时间</param>
        /// <param name="UserRange">用户角色范围</param>
        /// <returns>添加成功返回true，否则返回false</returns>
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
        /// 修改用户密码
        /// </Summary>
        /// <para name="SUserNumber">用户编号</para>
        /// <para name="SUserNumber">用户新密码</para>
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
        /// 添加用户信息
        /// </summary>
        /// <param name="UserNumber">登录名</param>
        /// <param name="LoginPassword">密码</param>
        /// <param name="UserName">真实姓名</param>
        /// <param name="Sex">性别</param>
        /// <param name="FixedPhone">固定电话</param>
        /// <param name="MobilePhone1">移动电话</param>
        /// <param name="MobilePhone2">移动电话</param>
        /// <param name="CompanyName">单位代码</param>
        /// <param name="PositionName">职务名称</param>
        /// <param name="PositionRank">职位级别</param>
        /// <param name="Email">电子邮箱</param>
        /// <param name="CreateTime">创建时间</param>
        /// <param name="UserRange">用户角色范围</param>
        /// <returns>添加成功返回true，否则返回false</returns>
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
        /// 根据编号获得用户信息
        /// </summary>
        /// <param name="SUserNumber">用户编号</param>
        /// <returns>用户信息列表</returns>
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
        /// 添加消息
        /// </summary>
        /// <param name="SMsgSend">发送人</param>
        /// <param name="SMsgReceive">接收人</param>
        /// <param name="SMessage">消息</param>
        /// <param name="SSendDate">添加时间</param>
        /// <returns>添加成功返回true，否则返回false</returns>
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
        /// 根据编号获得消息
        /// </summary>
        /// <param name="SUserNumber">用户编号</param>
        /// <returns>信息列表</returns>
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
        /// 根据编号获得消息
        /// </summary>
        /// <param name="SUserNumber">消息编号</param>
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

        //修改消息
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

        //修改消息IsRead
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
        /// 根据编号获得消息
        /// </summary>
        /// <param name="SUserNumber">用户编号</param>
        /// <returns>信息列表</returns>
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
        /// 得到未读信息条数
        /// </summary>
        /// <param name="SUserNumber">用户编号</param>
        /// <returns>信息列表</returns>
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
        /// 得到模板信息  0为得到所有信息  1得到ID单条信息  2删除
        /// </summary>
        /// <returns>添加成功返回true，否则返回false</returns>
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
        /// 得到金融知识信息
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
        /// 添加公告信息
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
        /// 得到公告信息  0为得到所有信息  1得到ID单条信息  2删除
        /// </summary>
        /// <returns>添加成功返回true，否则返回false</returns>
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
        /// 得到公告条数
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
        /// 得到年报提醒用户
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
        /// 得到年报时间
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
        /// 添加公告信息
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
        /// 得到公告初始化信息
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
        /// 添加公告初始化信息
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
        /// 得到doc信息
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
        /// 得到消息提醒用户
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
        /// 得到消息接收人员列表
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
        /// 添加模板信息
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
