using System;
using System.Data;
using Stoke.Components;
using Stoke.DAL;

namespace Stoke.Components
{
    /// <summary>
    /// xtqx 的摘要说明。
    /// </summary>
    public class xtqx
    {
        public xtqx()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public DataTable GetroleAll()
        {
            DataTable table = null;
            try
            {
                string cmdText = "sp_role_all";
                table = SQLHelper.ExecuteDataTable(cmdText);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.GetBgypckAll()" + e.Message);
            }
            return table;
        }
        public DataTable Getjs_rightAll()
        {
            DataTable table = null;
            try
            {
                string cmdText = "sp_getall_js_right";
                table = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.GetBgypckAll()" + e.Message);
            }
            return table;
        }

        public DataTable Getrolebh()
        {
            DataTable table = null;
            try
            {
                string cmdText = "sp_role_getbh";
                table = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.GetBgypckAll()" + e.Message);
            }
            return table;
        }
        public DataTable Getjs_rightbh()
        {
            DataTable table = null;
            try
            {
                string cmdText = "sp_js_right_getbh";
                table = SQLHelper.ExecuteDataTable(SQLHelper.CONN_STRING, CommandType.StoredProcedure, cmdText);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.GetBgypckAll()" + e.Message);
            }
            return table;
        }

        public int roleInsert(string _role_bh, string _role_mc, string _role_ms)
        {
            int _i = -1;
            string _str = "sp_role_insert";
            bool _b = false;
            object[] _ob = new object[] { _role_bh, _role_mc, _role_ms };
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

        public int js_rightInsert(string _role_bh, string _role_mc, string _role_ms)
        {
            int _i = -1;
            string _str = "sp_insert_js_right";
            bool _b = false;
            object[] _ob = new object[] { _role_bh, _role_mc, _role_ms };
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


        public int ry_roleInsert(string _bh, string _role_bh)
        {
            int _i = -1;
            string _str = "sp_ry_role_insert";
            bool _b = false;
            object[] _ob = new object[] { _bh, _role_bh };
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
        public int right_moduleInsert(string role_bh, string module_bh ,string right_bh)
        {
            int _i = -1;
            string _str = "sp_right_module_insert";
            bool _b = false;
            object[] _ob = new object[] { role_bh, module_bh, right_bh };

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

        public int Updaterole(string _bh, string _role_mc, string _role_ms)
        {
            int _i = -1;
            bool _b = false;
            object[] _ob = new object[] { _bh, _role_mc, _role_ms };
            try
            {
                _i = SQLHelper.ExecuteNonQuery("sp_role_update", _b, _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.UpdateKclJe(Gzkc newGz,float newKcl,float newJe)" + e.Message);
            }
            return _i;
        }


        public int Updateright(string _bh, string _right_mc, string _right_ms)
        {
            int _i = -1;
            bool _b = false;
            object[] _ob = new object[] { _bh, _right_mc, _right_ms };
            try
            {
                _i = SQLHelper.ExecuteNonQuery("sp_right_update", _b, _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.UpdateKclJe(Gzkc newGz,float newKcl,float newJe)" + e.Message);
            }
            return _i;
        }


        public int Deleterole(int _id)
        {
            int result = -1;
            string spName = "sp_role_delete";
            object[] para = new object[] { _id };
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
            return result;

        }



        public int Delete_right_role_module(string role_bh, string module_bh)
        {
            int result = -1;
            string spName = "sp_right_module_delete";
            object[] para = new object[] { role_bh, module_bh };
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
            return result;

        }


        public int Deletejs_right(int _id)
        {
            int result = -1;
            string spName = "sp_delete_js_right";
            object[] para = new object[] { _id };
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
            return result;

        }

        public int Deletery_role(string _id)
        {
            int result = -1;
            string spName = "sp_ry_role_delete";
            object[] para = new object[] { _id };
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
            return result;

        }
        public int Deletery_role_module(string _id, string _bh)
        {
            int result = -1;
            string spName = "sp_role_module_delete";
            object[] para = new object[] { _id, _bh };
            result = SQLHelper.ExecuteNonQuery(spName, false, para);
            return result;

        }
        public int role_moduleInsert(string _role_bh, string _module_bh,string _nodekey)
        {
            int _i = -1;
            string _str = "sp_role_module_insert";
            bool _b = false;
            object[] _ob = new object[] { _role_bh, _module_bh, _nodekey };
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
        public DataTable Getmodulebyzgbh(string _zgbh, string _module)
        {
            DataTable table = null;
            object[] _ob = new object[] { _zgbh, _module };
            try
            {
                table = SQLHelper.ExecuteDataTable("sp_select_zgbh_role_module", _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.GetGzckByZdbh(int _zdbh)" + e.Message);
            }
            return table;
        }

        public DataTable Getright_modulebyzgbh(string _role, string _module,string _right)
        {
            DataTable table = null;
            object[] _ob = new object[] { _role, _module, _right };
            try
            {
                table = SQLHelper.ExecuteDataTable("sp_right_role_module", _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.GetGzckByZdbh(int _zdbh)" + e.Message);
            }
            return table;
        }






        public DataTable Gettreebyzgbh(string _zgbh)
        {
            DataTable table = null;
            object[] _ob = new object[] { _zgbh };
            try
            {
                table = SQLHelper.ExecuteDataTable("sp_select_tree_zgbh", _ob);
            }
            catch (Exception e)
            {
                Console.WriteLine("GzkDAL.GetGzckByZdbh(int _zdbh)" + e.Message);
            }
            return table;
        }

        public int Isqx(string _zgbh, string _module_mc, string _right_mc)
        {
            //int _i = -1;
            //DataTable table = null;
            //object[] _ob = new object[] { _zgbh, _module_mc, _right_mc };
            //try
            //{
            //    table = SQLHelper.ExecuteDataTable("sp_isqx", _ob);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("GzkDAL.GetGzckByZdbh(int _zdbh)" + e.Message);
            //}
            ////return table;

            //if (table.Rows.Count == 0)
            //{
            //    return _i;
            //}
            //else
            //{
            //    _i = 1;
            //    return _i;
            //    //return 1;
            //}
            return 1;
        }



    }
}
