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
using System.IO;
using Stoke.BLL;
using Stoke.DAL;
using Stoke.COMMON;
using Stoke.Components;
using Bestcomy.Web.Controls.Upload;//wyw
using System.Threading;//wyw
using FileToMSSQL;

namespace Stoke.USL.gwgl
{
    public partial class sw : System.Web.UI.Page
    {
        protected string _zgbh;
        protected string _zgxm;
        protected int step_id;
        protected int doc_id;
        protected int flow_id;
        protected DataTable dt_step_field;
        protected int FieldNum;
        private DataTable dt_file_name = new DataTable();
        private ArrayList attachList = new ArrayList();
        private AttachFile attachFile = new AttachFile();
        private Guid guid;

        private void Page_Load(object sender, System.EventArgs e)
        {
            Initializ();//程序变量初始化变量
            try
            {
                dt_file_name.Columns.Add("FileName0", typeof(string));
                dt_file_name.Columns.Add("FileName", typeof(string));
            }
            catch
            {
            }
            if (!IsPostBack)
            {

                ViewState["retu"] = Request.UrlReferrer.ToString(); //20090622
                //----------------------------wyw-----------------------//
                attachList = (ArrayList)Session["attachList"];
                if (Session["dt_file_name"] != null)
                    dt_file_name = (DataTable)Session["dt_file_name"];

                GetAffixFromMSSQL();
                //----------------------------wyw-----------------------//
                if (doc_id == 0)
                {   //反馈表插入空行
                    DataTable dt = new DataTable();
                    for (int i = 0; i < DataGrid1.Columns.Count; i++)
                        dt.Columns.Add(((BoundColumn)DataGrid1.Columns[i]).DataField.ToString());
                    int count = DataGrid1.PageSize;
                    for (int i = 0; i < count; i++)
                        dt.Rows.Add(dt.NewRow());
                    DataGrid1.DataSource = dt;
                    DataGrid1.DataBind();
                }
                else
                {
                    Yj_Handle_Data();
                    Step_Handle_Data();//表单数据初始化
                    BindEmergency();
                }

                if (step_id != 0)
                    BindZd();//绑定字段权限
                Bussiness();//业务逻辑初始化
                if (step_id != 5 && step_id != 6)
                    fieldset1.Visible = false;
            }
        }

        protected void BindEmergency()
        {
            this.EmergencySelector1.SelectedValue = Stoke.BLL.Utility.GetEmergencyByDocid(doc_id);
        }

        #region 程序变量初始化变量
        private void Initializ()
        {
            _zgbh = Request["zgbh"].ToString();
            step_id = Convert.ToInt32(Request["step_id"]);
            doc_id = Convert.ToInt32(Request["doc_id"]);
            flow_id = 1;

            if (step_id == 1)
                this.EmergencySelector1.Enabled = true;
        }
        #endregion

        #region 表单数据初始化
        private void Step_Handle_Data()
        {
            string name = null;
            doc_id = Convert.ToInt32(Request["doc_id"]);
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            DataTable dt_Description_data = Stoke.Components.StyleRef.Select_Description_DocID(flow_id);
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl = new Control();
            for (int i = 0; i < dt_Description_data.Rows.Count; i++)
            {
                name = dt_Description_data.Rows[i][0].ToString();
                StyleControl = FrmNewDocument.FindControl(name);
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    ((TextBox)StyleControl).Text = dt_style_data.Rows[0][name].ToString();
                }
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    for (int j = 0; j < ((DropDownList)StyleControl).Items.Count; j++)
                    {
                        if (((DropDownList)StyleControl).Items[j].Text.ToString().Trim() == dt_style_data.Rows[0][name].ToString().Trim())
                        {
                            ((DropDownList)StyleControl).SelectedIndex = j;
                            break;
                        }
                    }
                }

            }
        }
        #endregion

        #region 绑定字段权限
        private void BindZd()
        {
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);//获取当前流程的当前步骤绑定的field
            FieldNum = dt_step_field.Rows[0][0].ToString().Split(';').Length;//获取当前流程的当前步骤绑定的field的数量
            Field_Bind(dt_step_field);//绑定当前流程当前步骤的field
        }

        private void Field_Bind(DataTable dt)
        {
            string name = null;
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");
            System.Web.UI.Control StyleControl = new Control();
            string _field_bind = dt.Rows[0][0].ToString();
            for (int i = 0; i < _field_bind.Split(';').Length; i++)
            {
                name = _field_bind.Split(';')[i].ToString();
                StyleControl = FrmNewDocument.FindControl(name);
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    ((TextBox)StyleControl).BackColor = Color.White;//2010.02.25
                    if (name == "g" || name == "h" || name == "a" || name == "b" || name == "w" || name == "s" || name == "c" || name == "d" || name == "i" || name == "x")
                        ((TextBox)StyleControl).ReadOnly = false;
                }
                if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    ((DropDownList)StyleControl).Enabled = true;
                    ((DropDownList)StyleControl).BackColor = Color.White;
                }
            }
        }
        #endregion

        #region 业务逻辑初始化
        private void Bussiness()
        {
            _zgxm = GetName(_zgbh);
            this.TD1.Visible = false;
            this.TD2.Visible = false;
            this.TD3.Visible = false;
            this.TD4.Visible = false;
            this.TD5.Visible = true;
            this.TD6.Visible = true;
            switch (step_id)
            {
                case 0:
                    BtnTj.Text = "打印到WORD";
                    BtnTj.Visible = false;
                    BtnSave.Visible = false;
                    this.TD5.Visible = true;
                    this.TD6.Visible = true;
                    break;
                case 1:
                    BtnQx.Text = "删除";
                    BtnTj.Text = "提交";
                    this.TD1.Visible = true;
                    this.TD2.Visible = true;
                    this.TD3.Visible = true;
                    this.TD4.Visible = true;
                    this.TD5.Visible = false;
                    this.TD6.Visible = false;
                    break;
                //				case 2:
                //					x.Text = _zgxm;
                //					break;
                case 4:
                    f.Text = _zgxm;
                    break;
            }
        }

        protected string GetName(string _zgbh)
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql = "select * from dsoc_ry where ry_zgbh = '" + _zgbh + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                _zgxm = dr.IsDBNull(1) ? null : dr["ry_xm"].ToString();
            dr.Close();
            conn.Close();
            return (_zgxm.Trim());
        }

        protected void Delete()
        {
            string connString = StokeGlobals.Connectiondsoc;
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

        public void UpdataTitle()
        {
            string connString = StokeGlobals.Connectiondsoc;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string str = "update dbo.Dsoc_Flow_Document set Doc_Title='" + w.Text.ToString().Trim() + "'where Doc_ID='" + doc_id + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        private void Yj_Handle_Data()
        {
            DataTable dt_yj_data = Stoke.Components.StyleRef.Select_Gwyj_DocID(doc_id);
            if (dt_yj_data.Rows.Count <= DataGrid1.PageSize)
                for (int i = dt_yj_data.Rows.Count; i < DataGrid1.PageSize; i++)
                    dt_yj_data.Rows.Add(dt_yj_data.NewRow());
            DataGrid1.DataSource = dt_yj_data;
            DataGrid1.DataBind();
        }

        #endregion

        #region 存储意见
        protected void SaveYj()
        {
            if (tsyj.Text != string.Empty)
            {
                string Sj = System.DateTime.Now.ToString();
                string connString = StokeGlobals.Connectiondsoc;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string Yjnr = tsyj.Text.ToString().Trim();
                string _zgxm = GetName(_zgbh);
                string sql = "insert into Dsoc_Flow_Gwyj values('" + flow_id + "','" + doc_id + "','" + step_id + "','" + _zgxm + "','" + Yjnr + "','" + Sj + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region 处理提交
        private void Manage()
        {
            switch (step_id)
            {
                case 0:
                    break;
                case 1:
                    {
                        if (w.Text == string.Empty)
                            Response.Write("<script>alert('请填写题目！')</script>");
                        else
                        {
                            SaveData();
                            ScfjToMSSQL();
                            string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=1&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                            Response.Redirect(_URL);
                        }
                        break;
                    }
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    {
                        SaveData();
                        SaveYj();
                        string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=1&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                        Response.Redirect(_URL);
                        break;
                    }
            }
        }
        #endregion

        #region 保存数据
        private void SaveData()
        {
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);//获取当前流程的当前步骤绑定的field
            FieldNum = dt_step_field.Rows[0][0].ToString().Split(';').Length;//获取当前流程的当前步骤绑定的field的数量
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;
            if (doc_id == 0)
            {
                mySql = GetStyleInsertData();
                //拟稿
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, w.Text.ToString());
                df = null;
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                df.UpdateDocument(mySql);
                df = null;
            }
            UpdataTitle();
            if (step_id == 1)
                Stoke.BLL.Utility.SetEmergencyWithDocid(doc_id, this.EmergencySelector1.SelectedValue);
        }
        private string GetStyleInsertData()
        {
            string mySql = "";
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");

            mySql += "insert into DSOC_Flow_Style_Data (";
            for (int i = 0; i < FieldNum; i++)
            {
                mySql += dt_step_field.Rows[0][0].ToString().Split(';')[i] + ",";
            }
            mySql = mySql.Substring(0, mySql.Length - 1) + ") values(";
            for (int i = 0; i < FieldNum; i++)
            {
                string field_name = dt_step_field.Rows[0][0].ToString().Split(';')[i];
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
                mySql += "update DSOC_Flow_Style_Data set ";
                for (int i = 0; i < FieldNum; i++)
                {
                    string field_name = dt_step_field.Rows[0][0].ToString().Split(';')[i];
                    string field_text = GetControlText(field_name);
                    if (field_text == null)
                        break;
                    mySql += field_name + "=" + "'" + field_text.Replace("'", "''") + "'";
                    if (i != (FieldNum - 1))
                        mySql += ",";
                }
                mySql += " where Doc_ID = " + DocID.ToString();

                return mySql;
            }
            else
            {
                return "Select 1";
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
                    return ((TextBox)StyleControl).Text.Trim();
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedItem.Text.ToString().Trim();
                default:
                    return null;
            }
        }
        #endregion

        #region 附件
        public string GetAffixFilename(string _name)
        {
            string affixName = "";
            int j = _name.LastIndexOf("@_@");
            affixName = _name.Substring(j + 3);//获取文件名
            return affixName;

        }

        private void btn_upload_Click(object sender, System.EventArgs e)
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
            }
            Session["attachList"] = attachList;

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
            string connStr = StokeGlobals.Connectiondsoc;
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
            string connStr = StokeGlobals.Connectiondsoc;
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
        #endregion

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
            this.BtnTj.Click += new System.EventHandler(this.BtnTj_Click);
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.BtnQx.Click += new System.EventHandler(this.BtnQx_Click);
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            this.FileList.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.FileList_DeleteCommand);
            this.FileList.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.FileList_ItemDataBound);
            this.DBFileList.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DBFileList_DeleteCommand);
            this.DBFileList.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.DBFileList_ItemDataBound);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            if (this.w.Text.Trim() == string.Empty)
            {
                Response.Write("<script>alert('请填写文件题目！')</script>");
                return;
            }
            SaveData();
            ScfjToMSSQL();
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void BtnTj_Click(object sender, System.EventArgs e)
        {
            Manage();//处理提交
        }

        private void BtnQx_Click(object sender, System.EventArgs e)
        {
            if (doc_id > 0 && step_id == 1)
            {
                Delete();
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
