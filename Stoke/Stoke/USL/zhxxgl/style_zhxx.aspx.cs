using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Stoke.Components;
using Stoke.BLL;
using Stoke.DAL;
using Stoke.COMMON;
using System.IO;//wyw
using Bestcomy.Web.Controls.Upload;//wyw
using FileToMSSQL;//wyw 
using System.Threading;//wyw

namespace Stoke.USL.zhxxgl
{
    public partial class style_zhxx : System.Web.UI.Page
    {
        DataTable dt_step_field;
        private int step_id;
        private int doc_id;
        private int flow_id = 26;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh;
        protected string _zgxm;
        private DataTable dt_file_name = new DataTable();
        private ArrayList attachList = new ArrayList();
        private AttachFile attachFile = new AttachFile();
        protected static int flag;
        private Guid guid;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["zgbh"] != null)
                _zgbh = Request["zgbh"].ToString();
            else
                Response.Redirect("../error.aspx");


            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);


            //根据doc_id判断执行表单数据的插入操作或更新操作
            if (doc_id > 0)
                bEditMode = true;

            //获取当前流程的当前步骤绑定的field
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);

            //获取当前流程的当前步骤绑定的field的数量
            FieldNum = dt_step_field.Rows.Count;

            try
            {
                dt_file_name.Columns.Add("FileName0", typeof(string));//wyw
                dt_file_name.Columns.Add("FileName", typeof(string));//wyw
            }
            catch
            {
            }



            if (!Page.IsPostBack)
            {
                ViewState["retu"] = Request.UrlReferrer.ToString(); //20090622

                //----------------------------wyw-----------------------//
                attachList = (ArrayList)Session["attachList"];
                if (Session["dt_file_name"] != null)
                    dt_file_name = (DataTable)Session["dt_file_name"];

                GetAffixFromMSSQL();
                this.TD1.Visible = false;
                this.TD2.Visible = false;
                this.TD3.Visible = false;
                this.TD4.Visible = false;
                //this.TD5.Visible=false;
                //this.TD6.Visible=false;
                this.Table18.Visible = false;


                z.Items.Insert(0, "---请选择---");  // wy  2009/08/24  解决保存后与实际部门不能选择问题
                z.SelectedIndex = 0;
                if (doc_id > 0)
                {
                    Step_Handle_Data();
                    BindEmergency();
                }

                if (step_id > 1)
                {
                    Txt_yj.Enabled = true;

                    
                }
                zhxx_Yj_Handle_Data();

                string cmdText1 = "SELECT * FROM dsoc_ry WHERE ry_zgbh = '" + _zgbh + "'";
                SqlDataReader dr2 = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.Text, cmdText1);
                if (dr2.Read())
                {
                    _zgxm = dr2.IsDBNull(1) ? null : dr2["ry_xm"].ToString().Trim();
                }
                dr2.Close();


                //----------------------------wyw-----------------------//
                if (step_id == 1)
                {
                    this.EmergencySelector1.Enabled = true;

                    if (doc_id == 0)
                    {

                        this.TD20.Visible = false;
                        this.TD21.Visible = false;
                        this.TD22.Visible = false;
                        this.TD24.Visible = false;


                    }

                    this.TD5.Visible = false;
                    this.TD6.Visible = false;

                    //string connString = dsocGlobals.Connectiondsoc; //  wy  2009/08/17
                    //SqlConnection conn = new SqlConnection(connString);
                    //string sql = "select distinct(ry_bm) from dsoc_ry where ry_zgbh = '" + _zgbh + "'";
                    //SqlCommand cmd = new SqlCommand(sql, conn);
                    //conn.Open();


                    string cmdText = "SELECT DISTINCT(ry_bm) FROM dsoc_ry WHERE ry_zgbh = '" + _zgbh + "'";
                    SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.Text, cmdText);

                    z.DataSource = dr;
                    z.DataTextField = "ry_bm";
                    z.DataValueField = "ry_bm";
                    z.DataBind();
                    //conn.Close();

                    if (doc_id == 0)
                    {
                        z.Items.Insert(0, "---请选择---");
                        z.SelectedIndex = 0;
                    }                                              //  wy  2009/08/17

                }
                if (this.b.SelectedValue == "公司")
                {
                    this.TD20.Visible = false;
                    this.TD21.Visible = false;
                    this.TD22.Visible = false;
                    this.TD24.Visible = false;
                }

                
                //conn2.Close();

                if (doc_id == 0)
                    a.Text = _zgxm.Trim();
                if (step_id == 1)
                {
                    btnSave.Text = "提交";

                    this.TD1.Visible = true;//wyw
                    this.TD2.Visible = true;
                    this.TD3.Visible = true;
                    this.TD4.Visible = true;
                    this.btnBack.Visible = true;
                    if (doc_id > 0)
                    {
                        this.TD5.Visible = true;
                        this.TD6.Visible = true;
                    }
                    if (doc_id == 0)
                    {

                        zhxx_Yj_xs_table();


                    }
                }
                else if (step_id > 1)
                {
                    //this.Label4.Visible=false;
                    this.TD5.Visible = true;//wyw
                    this.TD6.Visible = true;
                }
                if (step_id == 0)
                {

                    this.btnSave.Visible = false;
                    this.Button1.Visible = false;
                    this.btnBack.Visible = true;
                    this.btnBack.Text = "返回";
                    this.Btn_bm.Enabled = false;
                    this.Btn_ry.Enabled = false;
                    zhxx_Yj_Handle_Data();


                }
                if (step_id == 2)
                {
                    this.Button1.Visible = false;
                    this.btnBack.Visible = true;
                    this.btnBack.Text = "返回";

                    if (1 == 1)
                    {
                        this.TD20.Visible = false;
                        this.TD21.Visible = false;
                        this.TD22.Visible = false;
                        this.TD24.Visible = false;
                    }

                    //zhxx_Yj_xs_table();

                    
                }
                if (step_id == 3)//备案时不能对权限进行修改 wy 20090606
                {
                    this.Button1.Visible = false;
                    this.btnBack.Visible = true;
                    this.btnBack.Text = "返回";
                    //zhxx_Yj_xs_table();
                    this.Btn_bm.Enabled = false;
                    this.Btn_ry.Enabled = false;

                }
                if (step_id == 4)
                {
                    zhxx_Yj_Handle_Data();
                    this.btnSave.Text = "签收公文";

                }
                if (step_id == -1)
                {
                    SaveToXxfb();
                    Response.Redirect("../Workflow/Work_Manage.aspx");
                }
                //绑定当前流程当前步骤的field
                Field_Bind(dt_step_field);
            }
        }

        protected void BindEmergency()
        {
            this.EmergencySelector1.SelectedValue = Stoke.BLL.Utility.GetEmergencyByDocid(doc_id);
        }

        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            if (step_id == 1)
            {
                d.SelectedItem.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
                b.SelectedItem.Text = dt_style_data.Rows[0]["b"].ToString() != null ? dt_style_data.Rows[0]["b"].ToString() : null;
                z.SelectedItem.Text = dt_style_data.Rows[0]["z"].ToString() != null ? dt_style_data.Rows[0]["z"].ToString() : null;
            }
            else
            {
                d.Items.Clear();
                d.Items.Insert(0, dt_style_data.Rows[0]["d"].ToString());
                b.Items.Clear();
                b.Items.Insert(0, dt_style_data.Rows[0]["b"].ToString());
                z.Items.Clear();
                z.Items.Insert(0, dt_style_data.Rows[0]["z"].ToString());
            }

            this.a.Text = dt_style_data.Rows[0]["a"].ToString() != null ? dt_style_data.Rows[0]["a"].ToString() : null;
            this.c.Text = dt_style_data.Rows[0]["c"].ToString() != null ? dt_style_data.Rows[0]["c"].ToString() : null;
            this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;
            this.f.Text = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : null;
            this.g.Text = dt_style_data.Rows[0]["g"].ToString() != null ? dt_style_data.Rows[0]["g"].ToString() : null;
            this.h.Text = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
            this.x.Text = dt_style_data.Rows[0]["x"].ToString() != null ? dt_style_data.Rows[0]["x"].ToString() : null;
            this.y.Text = dt_style_data.Rows[0]["y"].ToString() != null ? dt_style_data.Rows[0]["y"].ToString() : null;
            this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
            this.k.Text = dt_style_data.Rows[0]["k"].ToString() != null ? dt_style_data.Rows[0]["k"].ToString() : null;

        }

        private void Field_Bind(DataTable dt)
        {
            string name = null;
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl = new Control();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                name = dt.Rows[i][0].ToString();
                StyleControl = FrmNewDocument.FindControl(name);
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    ((TextBox)StyleControl).BackColor = Color.White;
                    if (name == "c" || name == "e" || name == "f" || name == "g" || name == "h" || name == "i" || name == "x" || name == "y")
                        ((TextBox)StyleControl).ReadOnly = false;
                }
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    ((DropDownList)StyleControl).Enabled = true;
                    ((DropDownList)StyleControl).BackColor = Color.White;
                }
            }
        }


        private void btnSave_Click(object sender, System.EventArgs e1)
        {



        }

        public void SaveData()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;

            if (bEditMode == false)
            {
                mySql = GetStyleInsertData();
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, this.e.Text.ToString().Trim());
                df = null;
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                df.UpdateDocument(mySql);
                df = null;
                //				if(step_id==2||step_id==3) // 2009/09/15 
                if (step_id == 5)
                    this.SaveToXxfb();

            }
            UpdataTitle();

            if (step_id == 1)
                Stoke.BLL.Utility.SetEmergencyWithDocid(doc_id, this.EmergencySelector1.SelectedValue);

            if (Txt_yj.Text.Trim() != string.Empty)
            {
                string cmdText1 = "SELECT * FROM dsoc_ry WHERE ry_zgbh = '" + _zgbh + "'";
                SqlDataReader dr2 = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, CommandType.Text, cmdText1);
                if (dr2.Read())
                {
                    _zgxm = dr2.IsDBNull(1) ? null : dr2["ry_xm"].ToString().Trim();
                }
                dr2.Close();
                string cmdText = "INSERT INTO zhxx_yj(doc_id, yj_zgbh, yj_time, yj_nr) VALUES('" + doc_id + "', '" + _zgxm + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + Txt_yj.Text.Trim() + "')";
                SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.Text, cmdText);
            }

        }

        public void UpdataTitle()
        {
            string cmdText = "UPDATE dsoc_flow_document SET doc_title='" + e.Text.Trim() + "' WHERE doc_id = '" + doc_id + "'";
            SQLHelper.ExecuteNonQuery(SQLHelper.CONN_STRING, CommandType.Text, cmdText);
        }

        private string GetStyleInsertData()
        {
            string mySql = "";
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");

            mySql += "INSERT INTO dsoc_flow_style_data (";
            for (int i = 0; i < FieldNum; i++)
            {
                mySql += dt_step_field.Rows[i][0].ToString() + ",";
            }
            mySql = mySql.Substring(0, mySql.Length - 1) + ") VALUES(";
            for (int i = 0; i < FieldNum; i++)
            {
                string field_name = dt_step_field.Rows[i][0].ToString();
                string field_text = GetControlText(field_name);
                mySql += "'" + field_text.Replace("'", "''") + "',";
            }


            mySql = mySql.Substring(0, mySql.Length - 1) + ")";
            return mySql;
        }

        private string GetStyleUpdateData(int DocID)
        {
            string mySql = "";
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");

            if (FieldNum > 0)
            {
                mySql += "UPDATE dsoc_flow_style_data SET ";
                for (int i = 0; i < FieldNum; i++)
                {
                    string field_name = dt_step_field.Rows[i][0].ToString();
                    string field_text = GetControlText(field_name);
                    if (field_text == null)
                        break;
                    mySql += field_name + "=" + "'" + field_text.Replace("'", "''") + "'";
                    if (i != (FieldNum - 1))
                        mySql += ",";
                }
                mySql += " WHERE doc_id = " + DocID.ToString();

                return mySql;
            }
            else
            {
                return "SELECT 1";
            }
        }

        private string GetControlText(string field_name)
        {
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl = new Control();
            StyleControl = FrmNewDocument.FindControl(field_name);
            switch (StyleControl.GetType().ToString())
            {
                case "System.Web.UI.WebControls.TextBox":
                    return ((TextBox)StyleControl).Text;
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedItem.Text.ToString().Trim();
                default:
                    return null;
            }
        }

        private void SaveToXxfb()
        {
            string _connString = SQLHelper.CONN_STRING; //判断是不是有数据 20090606 wy
            SqlConnection _conn = new SqlConnection(_connString);
            _conn.Open();
            string _sql = "select * from Zhxx_Xxfb where Doc_Id='" + doc_id + "'";
            SqlCommand _cmd = new SqlCommand(_sql, _conn);

            SqlDataReader _dr = _cmd.ExecuteReader();
            if (_dr.Read())
            {
                _dr.Close();

                _sql = "delete  from Zhxx_Xxfb where Doc_Id='" + doc_id + "'";
                _cmd = new SqlCommand(_sql, _conn);
                _cmd.ExecuteNonQuery();

            }
            _conn.Close();

            string Ngr = a.Text.ToString();
            string Ssbm = b.SelectedItem.ToString();
            string Sqrq = c.Text.ToString();
            string Fbrq = string.Empty;
            string Ngfl = d.SelectedItem.ToString();
            string Bt = e.Text.ToString();
            string Ztc = f.Text.ToString();
            string Xxnr = x.Text.ToString();
            string Zhbsp = g.Text.ToString();
            string Zgfzrsp = h.Text.ToString();
            string Zjlsp = "";
            string Bz = y.Text.ToString();
            //			doc_id = Convert.ToInt32(Request["doc_id"]);
            string zhxx_bm = this.j.Text.ToString();
            string zhxx_ry = this.k.Text.ToString();
            string zhxx_fbbm = this.z.SelectedItem.Text.ToString(); // wy  2009/08/17 修改添加发布部门

            string connString = SQLHelper.CONN_STRING;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();//插入部门、人员 wy 20090606  // wy  2009/08/17 修改添加发布部门
            string sql = "insert into Zhxx_Xxfb values('" + Ngr + "','" + Ssbm + "','" + Sqrq + "','" + Ngfl + "','" + Bt + "','" + Ztc + " ','" + Xxnr + " ','" + Zhbsp + " ','" + Zgfzrsp + " ','" + Zjlsp + " ','" + Bz + " ','" + doc_id + "','" + zhxx_bm + "','" + zhxx_ry + "','" + zhxx_fbbm + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdataZt()
        {
            string connString = SQLHelper.CONN_STRING;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str = "update dbo.Dsoc_Flow_Document set Doc_Title='" + this.e.Text.ToString().Trim() + "'where Doc_ID='" + doc_id + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.b.SelectedIndexChanged += new System.EventHandler(this.b_SelectedIndexChanged);
            this.Btn_bm.Click += new System.EventHandler(this.Btn_bm_Click);
            this.Btn_ry.Click += new System.EventHandler(this.Btn_ry_Click);
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            this.FileList.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.FileList_DeleteCommand);
            this.FileList.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.FileList_ItemDataBound);
            this.DBFileList.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DBFileList_DeleteCommand);
            this.DBFileList.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.DBFileList_ItemDataBound);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.BtnSD.Click += new System.EventHandler(this.BtnSD_Click);
            this.Btn_fh.Click += new System.EventHandler(this.Btn_fh_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void Button1_Click(object sender, System.EventArgs e)//保存按钮
        {
            SaveData();
            UpdataZt();
            ScfjToMSSQL();//wyw
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }
        public string GetAffixFilename(string _name)
        {
            string affixName = "";
            int j = _name.LastIndexOf("@_@");
            affixName = _name.Substring(j + 3);//获取文件名
            return affixName;

        }
        private void btn_upload_Click(object sender, System.EventArgs e)
        {

        }

        private void FileList_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton btn = (ImageButton)e.Item.FindControl("btn_delete");
                btn.Attributes.Add("onclick", "javascript:return window.confirm('确定删除?');");
            }
        }

        private void FileList_DeleteCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
        {
            attachList = (ArrayList)Session["attachList"];
            dt_file_name = (DataTable)Session["dt_file_name"];
            try
            {
                foreach (AttachFile attachFile in attachList)
                    if (attachFile.FileNameRq == dt_file_name.Rows[e.Item.ItemIndex]["FileName0"].ToString())
                        attachList.Remove(attachFile);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                //Response.Write("<script>alert('"+msg+"')</script>");
            }
            Session["attachList"] = attachList;

            if (Session["dt_file_name"] != null)
                dt_file_name = (DataTable)Session["dt_file_name"];
            dt_file_name.Rows.RemoveAt(e.Item.ItemIndex);
            FileList.DataSource = dt_file_name.DefaultView;
            FileList.DataBind();
        }
        public void ScfjToMSSQL()
        {
            guid = Guid.NewGuid();

            attachList = (ArrayList)Session["attachList"];
            long totalLength = 0;
            if (attachList != null)
            {
                foreach (AttachFile attachFile in attachList)
                    totalLength += attachFile.FileLength;
            }

            if (attachList != null)
            {
                if (attachList.Count > 0)
                {
                    //Initialize indicator.
                    Indicator status = new Indicator();
                    status.TotalLength = totalLength;
                    status.TotalCount = attachList.Count;
                    StokeGlobals.ProcessingResults.Add(guid.ToString(), status);

                    ThreadStart ts = new ThreadStart(StartProcessing);
                    Thread _t = new Thread(ts);
                    _t.Start();
                    //				Response.Write("<script>window.open('dsoc/USL/filetosql/IndicatorBar.aspx?id=" + guid.ToString() + "');</script>");
                }
            }
        }

        public void StartProcessing()
        {
            attachList = (ArrayList)Session["attachList"];
            Session["attachList"] = null;
            Session["dt_file_name"] = null;
            foreach (object obj in attachList)
            {
                attachFile = (AttachFile)obj;
                ((Indicator)StokeGlobals.ProcessingResults[guid.ToString()]).CurrentFile = attachFile.FileName;
                int BUFFER_LENGTH = 32768;
                string connStr = StokeGlobals.Connectiondsoc;
                SqlConnection cn = new SqlConnection(connStr);
                string sql = "SET NOCOUNT ON;";
                sql += "declare @idx int;";
                sql += "INSERT INTO Categories(CategoryName,Description,Picture,doc_id) VALUES('" + attachFile.FileName + "','" + attachFile.FileNameRq + "',0x0,'" + doc_id + "')";
                sql += "select @idx=IDENT_CURRENT('Categories');";
                sql += "SELECT @Pointer=TEXTPTR(Picture) FROM Categories WHERE CategoryID=@idx";
                SqlCommand cmdGetPointer = new SqlCommand(sql, cn);
                SqlParameter PointerOutParam = cmdGetPointer.Parameters.Add("@Pointer", SqlDbType.VarBinary, 100);
                PointerOutParam.Direction = ParameterDirection.Output;
                cn.Open();
                cmdGetPointer.ExecuteNonQuery();

                // Set up UPDATETEXT command, parameters, and open BinaryReader.

                SqlCommand cmdUploadBinary = new SqlCommand("UPDATETEXT Categories.Picture @Pointer @Offset @Delete WITH LOG @Bytes", cn);
                SqlParameter PointerParam = cmdUploadBinary.Parameters.Add("@Pointer", SqlDbType.Binary, 16);
                SqlParameter OffsetParam = cmdUploadBinary.Parameters.Add("@Offset", SqlDbType.Int);
                SqlParameter DeleteParam = cmdUploadBinary.Parameters.Add("@Delete", SqlDbType.Int);
                DeleteParam.Value = 1;  // delete 0x0 character
                SqlParameter BytesParam = cmdUploadBinary.Parameters.Add("@Bytes", SqlDbType.Binary, BUFFER_LENGTH);
                //				System.IO.FileStream fs = new System.IO.FileStream(SourceFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                System.IO.BinaryReader br = new System.IO.BinaryReader(attachFile.StreamObject);

                int Offset = 0;
                OffsetParam.Value = Offset;

                // Read buffer full of data and execute UPDATETEXT statement.

                Byte[] Buffer = br.ReadBytes(BUFFER_LENGTH);
                while (Buffer.Length > 0)
                {
                    PointerParam.Value = PointerOutParam.Value;
                    BytesParam.Value = Buffer;
                    cmdUploadBinary.ExecuteNonQuery();
                    ((Indicator)StokeGlobals.ProcessingResults[guid.ToString()]).UploadedLength += Buffer.Length;
                    DeleteParam.Value = 0; //Do not delete any other data.
                    Offset += Buffer.Length;
                    OffsetParam.Value = Offset;
                    Buffer = br.ReadBytes(BUFFER_LENGTH);
                }

                br.Close();
                //				fs.Close();

                cn.Dispose();

                ((Indicator)StokeGlobals.ProcessingResults[guid.ToString()]).UploadedCount++;
            }
        }

        public void GetAffixFromMSSQL()
        {
            DataTable dt = new DataTable();
            string connStr = SQLHelper.CONN_STRING;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select CategoryID,CategoryName,[Description] from Categories where doc_id='" + doc_id + "'";
            cmd.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            conn.Open();
            adapter.Fill(dt);
            adapter.Dispose();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            DBFileList.DataSource = dt.DefaultView;
            DBFileList.DataBind();
        }

        private void DBFileList_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (step_id == 1 && doc_id > 0)
                {
                    ImageButton btn = (ImageButton)e.Item.FindControl("btn_delete1");
                    btn.Visible = true;
                    btn.Attributes.Add("onclick", "javascript:return window.confirm(确定删除?');");
                }
                DataRowView drv = (DataRowView)e.Item.DataItem;
                HyperLink link = (HyperLink)e.Item.FindControl("link_download");
                link.NavigateUrl = "../filetosql/Download.aspx?id=" + drv["CategoryID"].ToString() + "&filename=" + FileToMSSQL.Util.EncryptFilename(drv["Description"].ToString());
            }
        }

        private void DBFileList_DeleteCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
        {
            string id = (string)e.CommandArgument;
            string connStr = SQLHelper.CONN_STRING;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Categories where CategoryID=" + id;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            GetAffixFromMSSQL();
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {


        }
        private void delete()
        {
            string connString = SQLHelper.CONN_STRING;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "delete from  Dsoc_Flow_Gwyj where Doc_id='" + doc_id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            sql = "delete from Dsoc_Flow_Document where Doc_ID='" + doc_id + "'";
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            sql = "delete from DSOC_Flow_Style_Data where Doc_ID='" + doc_id + "'";
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void b_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //if(this.b.SelectedValue=="公司")
            if (this.b.SelectedIndex == 1)
            {
                this.TD20.Visible = false;
                this.TD21.Visible = false;
                this.TD22.Visible = false;
                this.TD24.Visible = false;

                //Response.Write("<script> alert('以公司名义发布信息需由综合管理部备案!') </script>");
                //return;
            }
            //else if (this.b.SelectedIndex == 2)
            //{

            //    this.TD20.Visible = true;
            //    this.TD21.Visible = true;
            //    this.TD22.Visible = false;
            //    this.TD24.Visible = false;

            //}
            //else if (this.b.SelectedIndex == 3)
            //{
            //    this.TD20.Visible = false;
            //    this.TD21.Visible = false;
            //    this.TD22.Visible = true;
            //    this.TD24.Visible = true;

            //}
            else
            {

                this.TD20.Visible = false;
                this.TD21.Visible = false;
                this.TD22.Visible = false;
                this.TD24.Visible = false;

            }

        }

        private void Btn_bm_Click(object sender, System.EventArgs e)
        {

        }

        private void Btn_ry_Click(object sender, System.EventArgs e)
        {

        }

        private void BtnSD_Click(object sender, System.EventArgs e)
        {

        }

        private void Btn_fh_Click(object sender, System.EventArgs e)
        {
            this.Table18.Visible = false;
            SlctDepartment1.Visible = false;
            SlctMember1.Visible = false;
        }

        private void zhxx_Yj_Handle_Data()
        {
            DataTable dt_yj_data = Stoke.Components.zhxx.Select_zhxx_yj_DocID(doc_id);
            if (dt_yj_data.Rows.Count <= DataGrid1.PageSize)
                for (int i = dt_yj_data.Rows.Count; i < DataGrid1.PageSize; i++)
                    dt_yj_data.Rows.Add(dt_yj_data.NewRow());
            DataGrid1.DataSource = dt_yj_data;
            DataGrid1.DataBind();

        }
        private void zhxx_Yj_xs_table()
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < DataGrid1.Columns.Count; i++)
                dt.Columns.Add(((BoundField)DataGrid1.Columns[i]).DataField.ToString());
            int count = DataGrid1.PageSize;
            for (int i = 0; i < count; i++)
                dt.Rows.Add(dt.NewRow());
            DataGrid1.DataSource = dt;
            DataGrid1.DataBind();
        }
        private void zhxx_yj_insert()
        {
            //if (step_id == 2)
            //{
            //    SqlConnection conn = new SqlConnection(SQLHelper.CONN_STRING);

            //    conn.Open();

            //    string _sql = "delete  zhxx_qx   where doc_id=" + doc_id + "";//20090606 wy 更新以前的权限

            //    SqlCommand _cmd = new SqlCommand(_sql, conn);

            //    _cmd.ExecuteNonQuery();
            //    conn.Close();

            //    if (this.j.Text != "")
            //    {
            //        string bm_list = this.j.Text.ToString().Trim();
            //        string _bm = "";

            //        for (int i = 0; i < bm_list.Split(',').Length; i++)
            //        {
            //            _bm = bm_list.Split(',')[i].ToString().Trim();
            //            int qx_flag = 1;

            //            conn.Open();

            //            _sql = "insert into zhxx_qx values(0," + doc_id + "," + qx_flag + ",'" + _bm + "')";

            //            _cmd = new SqlCommand(_sql, conn);

            //            _cmd.ExecuteNonQuery();
            //            conn.Close();
            //        }

            //    }
            //    //可以加入默认本部门的员工可以查看
            //    if (this.k.Text != "")
            //    {
            //        string xm_list = this.k.Text.ToString().Trim();
            //        string _gr = "";
            //        for (int i = 0; i < xm_list.Split(',').Length; i++)
            //        {
            //            _gr = xm_list.Split(',')[i].ToString().Trim();
            //            int qx_flag = 0;

            //            conn.Open();

            //            _sql = "insert into zhxx_qx values(0," + doc_id + "," + qx_flag + ",'" + _gr + "')";

            //            _cmd = new SqlCommand(_sql, conn);

            //            _cmd.ExecuteNonQuery();
            //            conn.Close();
            //        }
            //    }
            //    conn.Open();//20090606 wy 经办人默认可以查看
            //    string jbr = this.a.Text.ToString().Trim();
            //    string sql_1 = "insert into zhxx_qx values(0," + doc_id + ",0,'" + jbr + "')";
            //    SqlCommand cmd_1 = new SqlCommand(sql_1, conn);

            //    cmd_1.ExecuteNonQuery();
            //    conn.Close();

            //    Stoke.Components.Staff _staff = new Stoke.Components.Staff();
            //    DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
            //    string zgxm_2 = dt_xm_bm.Rows[0][0].ToString();//

            //    conn.Open();//20090606 wy 部门负责人人默认可以查看
            //    sql_1 = "insert into zhxx_qx values(0," + doc_id + ",0,'" + zgxm_2 + "')";
            //    cmd_1 = new SqlCommand(sql_1, conn);

            //    cmd_1.ExecuteNonQuery();
            //    conn.Close();
            //    conn.Dispose();


            //}
            //if (step_id == 3)//备案时不能对权限进行修改 wy 20090606
            //{

            //    Stoke.Components.Staff _staff = new Stoke.Components.Staff();
            //    DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
            //    string zgxm_3 = dt_xm_bm.Rows[0][0].ToString();//
            //    SqlConnection conn = new SqlConnection(Stoke.COMMON.StokeGlobals.Connectiondsoc);
            //    conn.Open();//20090606 wy 综合部管理员默认可以查看
            //    string sql_1 = "insert into zhxx_qx values(0," + doc_id + ",0,'" + zgxm_3 + "')";
            //    SqlCommand cmd_1 = new SqlCommand(sql_1, conn);

            //    cmd_1.ExecuteNonQuery();
            //    conn.Close();
            //    conn.Dispose();

            //}
        }

        protected void Btn_bm_Click1(object sender, EventArgs e)
        {
            this.Table18.Visible = true;
            this.SlctDepartment1.Visible = true;
            this.BtnSD.Visible = true;
            this.Btn_fh.Visible = true;
            this.SlctMember1.Visible = false;
            flag = 1;
        }

        protected void Btn_ry_Click1(object sender, EventArgs e)
        {
            this.Table18.Visible = true;
            this.SlctMember1.Visible = true;
            this.BtnSD.Visible = true;
            this.Btn_fh.Visible = true;
            this.SlctDepartment1.Visible = false;
            flag = 2;
        }

        protected void btn_upload_Click1(object sender, EventArgs e)
        {
            string filebm = this.TextBox2.Text;
            string fileUrl = this.File1.PostedFile.FileName;//获取初始文件路径 

            int fileLength = this.File1.PostedFile.ContentLength;
            if (fileUrl == "")
            {
                Response.Write("<script> alert('请选择附件的上传路径。') </script>");
                return;
            }
            if (filebm == "")
            {
                Response.Write("<script> alert('附件名必须填写。') </script>");
                return;
            }

            if (fileLength > 10 * 1024 * 1024)//判断文件的大小是否大于5M
            {
                Response.Write("<script>alert('上传文件最大为10M。')</script>");
                this.TextBox2.Text = "";
                return;
            }
            if (Session["attachList"] != null)
                attachList = (ArrayList)Session["attachList"];
            string filetype = fileUrl.Substring(fileUrl.LastIndexOf(".") + 1); //获取文件类型
            attachFile.FileLength = fileLength;
            attachFile.FileName = filebm + "." + filetype;
            attachFile.FileNameRq = System.DateTime.Now.Ticks.ToString() + "@_@" + attachFile.FileName;
            attachFile.StreamObject = this.File1.PostedFile.InputStream;
            attachList.Add(attachFile);
            Session["attachList"] = attachList;

            if (Session["dt_file_name"] != null)
                dt_file_name = (DataTable)Session["dt_file_name"];
            DataRow ndr = dt_file_name.NewRow();
            ndr["FileName0"] = Path.GetFileName(@attachFile.FileNameRq);
            ndr["FileName"] = Path.GetFileName(@attachFile.FileName);
            dt_file_name.Rows.Add(ndr);
            Session["dt_file_name"] = dt_file_name;
            FileList.DataSource = dt_file_name.DefaultView;
            FileList.DataBind();
            this.TextBox2.Text = string.Empty;
        }

        protected void BtnSD_Click1(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                this.j.Text = SlctDepartment1.Send[0].ToString();
                if (SlctDepartment1.Visible == true)
                {
                    SlctDepartment1.Visible = false;
                    BtnSD.Visible = false;
                }
            }
            else if (flag == 2)
            {
                this.k.Text = SlctMember1.Send[0].ToString().Trim();
                if (SlctMember1.Visible == true)
                {
                    SlctMember1.Visible = false;
                    BtnSD.Visible = false;
                }
            }
            SlctMember1.Clear();
            this.Table18.Visible = false;
        }

        protected void Btn_fh_Click1(object sender, EventArgs e)
        {
            this.Table18.Visible = false;
            SlctDepartment1.Visible = false;
            SlctMember1.Visible = false;
        }

        protected void btnSave_Click1(object sender, EventArgs e1)
        {
            if (step_id == 1)
            {
                if (c.Text == "")
                    Response.Write("<script>alert('申请日期不能为空！')</script>");
                else if (d.SelectedItem.Text == "-请选择-")
                    Response.Write("<script>alert('拟稿分类不能为空！')</script>");
                else if (e.Text == "")
                    Response.Write("<script>alert('标题不能为空！')</script>");
                else if (f.Text == "")
                    Response.Write("<script>alert('主题词不能为空！')</script>");
                else if (z.SelectedItem.Text == "---请选择---")
                    Response.Write("<script>alert('请选择发布人所在部门！')</script>");
                else
                {
                    SaveData();
                    ScfjToMSSQL();//wyw
                    string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=26&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                    Response.Redirect(_URL);
                }
            }
            else if (step_id == 3)
            {
                if (g.Text == "")
                {
                    Response.Write("<script>alert('综合管理部审批不能为空！')</script>");
                    return;
                }
                else
                {
                    SaveData();
                    zhxx_yj_insert();
                }
                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=26&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Response.Redirect(_URL);
            }
            else if (step_id == 2)
            {


                if (this.h.Text != "")
                {



                    SaveData();
                    zhxx_yj_insert();

                }

                else
                {

                    Response.Write("<script>alert('部门主管负责人审批不能为空！')</script>");
                    return;





                }

                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=26&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Server.Transfer(_URL);


            }
            else if (step_id == 4)
            {
                SaveData();
                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=26&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Response.Redirect(_URL);

            }
            else if (step_id == 5) //  2009/09/15  综合信息发布步骤
            {
                SaveData();
                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=26&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Response.Redirect(_URL);

            }
            else if (step_id == 6) //  2009/09/15  综合信息发布步骤
            {
                SaveData();
                string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=26&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                Response.Redirect(_URL);

            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            SaveData();
            UpdataZt();
            ScfjToMSSQL();//wyw
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        protected void btnBack_Click1(object sender, EventArgs e)
        {
            if (doc_id > 0 && step_id == 1)
            {
                delete();
                Response.Redirect("../Workflow/Work_Manage.aspx");
            }
            else if (step_id == 0)
            {
                //Response.Redirect("../Workflow/Work_Record.aspx");
                Response.Redirect(ViewState["retu"].ToString());
            }
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
        }
    }
}
