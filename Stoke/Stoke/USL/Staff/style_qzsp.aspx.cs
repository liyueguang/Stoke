using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Stoke.COMMON;
using System.Drawing.Imaging;

namespace Stoke.USL.Staff
{
    public partial class style_qzsp : System.Web.UI.Page
    {
        protected int DisplayType = 0;
        DataTable dt_step_field;
        private int step_id = 1;         ///////////////////////////////////////////////
        private int doc_id = 0;			 //////////////////////////////////////////////
        private int _qzsp_id = 0;
        private int flow_id = 10;
        private int FieldNum = 0;
        private bool bEditMode = false;
        protected string _zgbh; //////////////////////////////////////////////////

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (Request["zgbh"] != null)
                _zgbh = Request["zgbh"].ToString();
            if (Request["step_id"] != null)
                step_id = Convert.ToInt32(Request["step_id"]);
            if (Request["doc_id"] != null)
                doc_id = Convert.ToInt32(Request["doc_id"]);

            if (Request.QueryString["DisplayType"] != null)
            {
                if (Request.QueryString["DisplayType"].ToString() != "")
                    DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
                else
                    DisplayType = 0;
            }
            else
                DisplayType = 0;

            if (Request.QueryString["qzsp_id"] != null)
                if (Request.QueryString["qzsp_id"].ToString() != "")
                {
                    _qzsp_id = Int32.Parse(Request.QueryString["qzsp_id"].ToString());
                    doc_id = Int32.Parse(Request.QueryString["qzsp_id"].ToString());
                }
            if ((doc_id == 0) && (this.txt_doc.Text != string.Empty))
                doc_id = int.Parse(this.txt_doc.Text);

            if (doc_id > 0)
                bEditMode = true;

            //获取当前流程的当前步骤绑定的field
            dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);

            //获取当前流程的当前步骤绑定的field的数量
            FieldNum = dt_step_field.Rows.Count;

            if (!Page.IsPostBack)
            {

                //绑定当前流程当前步骤的field
                Field_Bind(dt_step_field);

                DataTable dt_zw = Stoke.BLL.Place.GetAll();
                this.a.DataSource = dt_zw;
                this.a.DataTextField = "zw_mc";
                this.a.DataValueField = "zw_mc";
                this.a.DataBind();
                this.a.Items.Insert(0, "-请选择-");
                this.a.SelectedIndex = 0;
                this.b.DataSource = dt_zw;
                this.b.DataTextField = "zw_mc";
                this.b.DataValueField = "zw_mc";
                this.b.DataBind();
                this.b.Items.Insert(0, "-请选择-");
                this.b.SelectedIndex = 0;

                if (step_id == 0)
                    this.btnSave.Visible = false;
                else if (step_id == 1)
                {
                    if (doc_id > 0)
                        this.btnCancel.Text = "删除";
                    else if (doc_id == 0)
                    {
                        DataTable dt_jyjl_temp = Stoke.Components.Staff.DeleteQzspJyjlTemp();
                        for (int i = dt_jyjl_temp.Rows.Count; i < 1; i++)
                            dt_jyjl_temp.Rows.Add(dt_jyjl_temp.NewRow());
                        this.DataGrid1.DataSource = dt_jyjl_temp;
                        this.DataGrid1.DataBind();
                        for (int i = 0; i < DataGrid1.Items.Count; i++)
                            if (DataGrid1.Items[i].Cells[0].Text == "&nbsp;")
                            {
                                DataGrid1.Items[i].Cells[7].Controls[0].Visible = false;
                            }

                        DataTable dt_gzjl_temp = Stoke.Components.Staff.DeleteQzspGzjlTemp();
                        for (int i = 0; i < 1; i++)
                            dt_gzjl_temp.Rows.Add(dt_gzjl_temp.NewRow());
                        this.DataGrid2.DataSource = dt_gzjl_temp;
                        this.DataGrid2.DataBind();
                        for (int i = 0; i < DataGrid2.Items.Count; i++)
                            if (DataGrid2.Items[i].Cells[0].Text == "&nbsp;")
                            {
                                DataGrid2.Items[i].Cells[8].Controls[0].Visible = false;
                            }

                        DataTable dt_jtgx_temp = Stoke.Components.Staff.DeleteQzspJtgxTemp();
                        for (int i = 0; i < 1; i++)
                            dt_jtgx_temp.Rows.Add(dt_jtgx_temp.NewRow());
                        this.DataGrid3.DataSource = dt_jtgx_temp;
                        this.DataGrid3.DataBind();
                        for (int i = 0; i < DataGrid3.Items.Count; i++)
                            if (DataGrid3.Items[i].Cells[0].Text == "&nbsp;")
                            {
                                DataGrid3.Items[i].Cells[5].Controls[0].Visible = false;
                            }
                    }
                }
                else if (step_id > 1)
                {
                    this.btnSave.Visible = false;
                    this.Button1.Visible = false;
                    this.btnCancel.Visible = false;
                }
                else if (step_id == -2)
                {
                    this.btnSave.Visible = false;
                    this.Button1.Visible = false;
                }

                //根据doc_id取得当前document中已有数据
                if (doc_id > 0)
                    Step_Handle_Data();
            }
        }

        private void Step_Handle_Data()
        {
            DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
            //			this.a.DataSource = dt_style_data;
            //			this.a.DataValueField = "a";
            //			this.a.DataTextField = "a";
            //			this.a.DataBind();
            //			this.b.DataSource = dt_style_data;
            //			this.b.DataValueField = "b";
            //			this.b.DataTextField = "b";
            //			this.b.DataBind();
            this.a.SelectedValue = dt_style_data.Rows[0]["a"].ToString() != null ? dt_style_data.Rows[0]["a"].ToString() : "-请选择-";
            this.b.SelectedValue = dt_style_data.Rows[0]["b"].ToString() != null ? dt_style_data.Rows[0]["b"].ToString() : "-请选择-";
            this.c.Text = dt_style_data.Rows[0]["c"].ToString() != null ? dt_style_data.Rows[0]["c"].ToString() : null;
            this.d.Text = dt_style_data.Rows[0]["d"].ToString() != null ? dt_style_data.Rows[0]["d"].ToString() : null;
            this.e.Text = dt_style_data.Rows[0]["e"].ToString() != null ? dt_style_data.Rows[0]["e"].ToString() : null;
            this.f.SelectedValue = dt_style_data.Rows[0]["f"].ToString() != null ? dt_style_data.Rows[0]["f"].ToString() : "男";
            this.g.Text = dt_style_data.Rows[0]["g"].ToString() != null ? dt_style_data.Rows[0]["g"].ToString() : null;
            this.h.Text = dt_style_data.Rows[0]["h"].ToString() != null ? dt_style_data.Rows[0]["h"].ToString() : null;
            this.i.Text = dt_style_data.Rows[0]["i"].ToString() != null ? dt_style_data.Rows[0]["i"].ToString() : null;
            this.j.Text = dt_style_data.Rows[0]["j"].ToString() != null ? dt_style_data.Rows[0]["j"].ToString() : null;
            this.k.Text = dt_style_data.Rows[0]["k"].ToString() != null ? dt_style_data.Rows[0]["k"].ToString() : null;
            this.l.Text = dt_style_data.Rows[0]["l"].ToString() != null ? dt_style_data.Rows[0]["l"].ToString() : null;
            try
            {
                this.m.SelectedValue = dt_style_data.Rows[0]["m"].ToString() != null ? dt_style_data.Rows[0]["m"].ToString() : "-请选择-";
            }
            catch
            { }
            this.n.Text = dt_style_data.Rows[0]["n"].ToString() != null ? dt_style_data.Rows[0]["n"].ToString() : null;
            this.o.Text = dt_style_data.Rows[0]["o"].ToString() != null ? dt_style_data.Rows[0]["o"].ToString() : null;
            this.p.Text = dt_style_data.Rows[0]["p"].ToString() != null ? dt_style_data.Rows[0]["p"].ToString() : null;
            this.q.Text = dt_style_data.Rows[0]["q"].ToString() != null ? dt_style_data.Rows[0]["q"].ToString() : null;
            this.r.Text = dt_style_data.Rows[0]["r"].ToString() != null ? dt_style_data.Rows[0]["r"].ToString() : null;
            this.r.Text = dt_style_data.Rows[0]["r"].ToString() != null ? dt_style_data.Rows[0]["r"].ToString() : null;
            this.t.Text = dt_style_data.Rows[0]["t"].ToString() != null ? dt_style_data.Rows[0]["t"].ToString() : null;
            this.u.Text = dt_style_data.Rows[0]["u"].ToString() != null ? dt_style_data.Rows[0]["u"].ToString() : null;
            this.v.Text = dt_style_data.Rows[0]["v"].ToString() != null ? dt_style_data.Rows[0]["v"].ToString() : null;
            this.a1.Text = dt_style_data.Rows[0]["a1"].ToString() != null ? dt_style_data.Rows[0]["a1"].ToString() : null;
            this.b1.SelectedValue = dt_style_data.Rows[0]["b1"].ToString() != null ? dt_style_data.Rows[0]["b1"].ToString() : "-请选择-";
            this.c1.Text = dt_style_data.Rows[0]["c1"].ToString() != null ? dt_style_data.Rows[0]["c1"].ToString() : null;
            this.d1.SelectedValue = dt_style_data.Rows[0]["d1"].ToString() != null ? dt_style_data.Rows[0]["d1"].ToString() : "已婚";
            this.e1.Text = dt_style_data.Rows[0]["e1"].ToString() != null ? dt_style_data.Rows[0]["e1"].ToString() : null;
            this.f1.Text = dt_style_data.Rows[0]["f1"].ToString() != null ? dt_style_data.Rows[0]["f1"].ToString() : null;
            this.g1.Text = dt_style_data.Rows[0]["g1"].ToString() != null ? dt_style_data.Rows[0]["g1"].ToString() : null;
            this.h1.Text = dt_style_data.Rows[0]["h1"].ToString() != null ? dt_style_data.Rows[0]["h1"].ToString() : null;
            this.i1.Text = dt_style_data.Rows[0]["i1"].ToString() != null ? dt_style_data.Rows[0]["i1"].ToString() : null;
            this.j1.Text = dt_style_data.Rows[0]["j1"].ToString() != null ? dt_style_data.Rows[0]["j1"].ToString() : null;
            this.k1.Text = dt_style_data.Rows[0]["k1"].ToString() != null ? dt_style_data.Rows[0]["k1"].ToString() : null;
            this.l1.Text = dt_style_data.Rows[0]["l1"].ToString() != null ? dt_style_data.Rows[0]["l1"].ToString() : null;
            this.m1.Text = dt_style_data.Rows[0]["m1"].ToString() != null ? dt_style_data.Rows[0]["m1"].ToString() : null;
            this.n1.Text = dt_style_data.Rows[0]["n1"].ToString() != null ? dt_style_data.Rows[0]["n1"].ToString() : null;
            this.o1.Text = dt_style_data.Rows[0]["o1"].ToString() != null ? dt_style_data.Rows[0]["o1"].ToString() : null;
            this.p1.Text = dt_style_data.Rows[0]["p1"].ToString() != null ? dt_style_data.Rows[0]["p1"].ToString() : null;
            this.q1.Text = dt_style_data.Rows[0]["q1"].ToString() != null ? dt_style_data.Rows[0]["q1"].ToString() : null;
            this.r1.Text = dt_style_data.Rows[0]["r1"].ToString() != null ? dt_style_data.Rows[0]["r1"].ToString() : null;
            this.s1.Text = dt_style_data.Rows[0]["s1"].ToString() != null ? dt_style_data.Rows[0]["s1"].ToString() : null;
            this.t1.Text = dt_style_data.Rows[0]["t1"].ToString() != null ? dt_style_data.Rows[0]["t1"].ToString() : null;
            this.u1.Text = dt_style_data.Rows[0]["u1"].ToString() != null ? dt_style_data.Rows[0]["u1"].ToString() : null;
            this.v1.Text = dt_style_data.Rows[0]["v1"].ToString() != null ? dt_style_data.Rows[0]["v1"].ToString() : null;
            this.w1.Text = dt_style_data.Rows[0]["w1"].ToString() != null ? dt_style_data.Rows[0]["w1"].ToString() : null;
            this.x1.Text = dt_style_data.Rows[0]["x1"].ToString() != null ? dt_style_data.Rows[0]["x1"].ToString() : null;
            this.y1.Text = dt_style_data.Rows[0]["y1"].ToString() != null ? dt_style_data.Rows[0]["y1"].ToString() : null;
            this.z1.Text = dt_style_data.Rows[0]["z1"].ToString() != null ? dt_style_data.Rows[0]["z1"].ToString() : null;
            this.a2.Checked = dt_style_data.Rows[0]["a2"].ToString() != "False" ? true : false;
            this.b2.Checked = dt_style_data.Rows[0]["b2"].ToString() != "False" ? true : false;
            this.c2.Text = dt_style_data.Rows[0]["c2"].ToString() != null ? dt_style_data.Rows[0]["c2"].ToString() : null;
            this.d2.Text = dt_style_data.Rows[0]["d2"].ToString() != null ? dt_style_data.Rows[0]["d2"].ToString() : null;
            this.e2.Text = dt_style_data.Rows[0]["e2"].ToString() != null ? dt_style_data.Rows[0]["e2"].ToString() : null;
            this.z2.Text = dt_style_data.Rows[0]["z2"].ToString() != null ? dt_style_data.Rows[0]["z2"].ToString() : null;

            DataTable dt_jyjl_temp = Stoke.Components.Staff.SelectQzspJyjlByDocId(doc_id);
            this.DataGrid1.DataSource = dt_jyjl_temp;
            this.DataGrid1.DataBind();
            for (int i = 0; i < DataGrid1.Items.Count; i++)
                DataGrid1.Items[i].Cells[7].Controls[0].Visible = false;

            DataTable dt_gzjl_temp = Stoke.Components.Staff.SelectQzspGzjlByDocId(doc_id);
            this.DataGrid2.DataSource = dt_gzjl_temp;
            this.DataGrid2.DataBind();
            for (int i = 0; i < DataGrid2.Items.Count; i++)
                DataGrid2.Items[i].Cells[8].Controls[0].Visible = false;

            DataTable dt_jtgx_temp = Stoke.Components.Staff.SelectQzspJtgxByDocId(doc_id);
            this.DataGrid3.DataSource = dt_jtgx_temp;
            this.DataGrid3.DataBind();
            for (int i = 0; i < DataGrid3.Items.Count; i++)
                DataGrid3.Items[i].Cells[5].Controls[0].Visible = false;
            ShowAffix();

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
                if (StyleControl != null)
                {
                    if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                    {
                        ((TextBox)StyleControl).BackColor = Color.White;
                        ((TextBox)StyleControl).ReadOnly = false;
                    }
                    if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                    {
                        ((DropDownList)StyleControl).Enabled = true;
                        ((DropDownList)StyleControl).BackColor = Color.White;
                    }
                    if (StyleControl.GetType().ToString() == "System.Web.UI.WebControls.CheckBox")
                    {
                        ((CheckBox)StyleControl).Enabled = true;
                        ((CheckBox)StyleControl).BackColor = Color.White;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveData();
            //			if(this.Image1.ImageUrl.ToString()!=""||(this.Image1.ImageUrl.ToString()==""&&doc_id>0))
            //			{
            //				string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=10&step_id="+step_id.ToString()+"&doc_id="+doc_id.ToString()+"&zgbh="+_zgbh.ToString();
            //				Response.Redirect(_URL);
            //			}
            if (doc_id != 0)

                /////////////////
                ////保存doc_id,因为点击提交时，会重新加载页面，使docid为零
                ////////////////
                this.txt_doc.Text = doc_id.ToString();



        }

        public void SaveData()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;

            if (bEditMode == false)
            {
                mySql = GetStyleInsertData();
                //拟稿
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, e.Text.ToString() + "求职审批");
                df = null;

                SaveToQzspQzjl();
                UPaffixFiles();
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                //Response.Write("<script language='javascript'>alert('" + mySql + "');</script>");
                df.UpdateDocument(mySql);
                if (step_id == 1)
                {

                    SaveToQzspQzjl();
                    UPaffixFiles();
                }
                df = null;

            }

        }

        public void UPaffixFiles()
        {
            try
            {
                //获得图象并把图象转换为byte[] 
                HttpPostedFile upPhoto = upFile.PostedFile;
                if (upPhoto.ContentLength > 1 * 1024 * 1024)//判断文件的大小是否大于5M
                {
                    Response.Write("<script>alert('上传文件最大为1M。')</script>");

                    return;
                }

                if (upPhoto.ContentLength == 0)
                {
                    string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=10&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                    Response.Redirect(_URL);
                }

                int upPhotoLength = upPhoto.ContentLength;


                if (upPhotoLength != 0)
                {
                    byte[] PhotoArray = new Byte[upPhotoLength];
                    Stream PhotoStream = upPhoto.InputStream;
                    PhotoStream.Read(PhotoArray, 0, upPhotoLength);


                    System.Drawing.Image oImage = System.Drawing.Image.FromStream(PhotoStream);
                    int oWidth = oImage.Width; //原图宽度 
                    int oHeight = oImage.Height; //原图高度 
                    //					if(oWidth>295||oHeight>413)
                    if (oWidth > 768 || oHeight > 1024)
                    {

                        Response.Write("<script>alert('上传照片最大为1寸。')</script>");

                        return;

                    }
                    else
                    {
                        //连接数据库 
                        string connString = StokeGlobals.Connectiondsoc;
                        SqlConnection conn = new SqlConnection(connString);
                        SqlCommand cmd = new SqlCommand("rs_Qzsp_UpdateImage", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@qzsp_id", SqlDbType.Int);
                        cmd.Parameters["@qzsp_id"].Value = doc_id;
                        cmd.Parameters.Add("@UpdateImage", SqlDbType.Image);
                        cmd.Parameters["@UpdateImage"].Value = PhotoArray;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        this.Image1.ImageUrl = "read_qzsp_photo.aspx?qzsp_id=" + doc_id;

                        string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=10&step_id=" + step_id.ToString() + "&doc_id=" + doc_id.ToString() + "&zgbh=" + _zgbh.ToString();
                        Response.Redirect(_URL);
                    }

                }
            }
            catch (Exception ex)
            {
                //				Response.Write(ex.ToString());
            }

        }

        public void UPaffixFiles1()
        {
            try
            {
                //获得图象并把图象转换为byte[] 
                HttpPostedFile upPhoto = upFile.PostedFile;
                if (upPhoto.ContentLength > 1 * 1024 * 1024)//判断文件的大小是否大于5M
                {
                    Response.Write("<script>alert('上传文件最大为1M。')</script>");
                    return;
                }


                if (upPhoto.ContentLength == 0)
                {
                    Response.Redirect("../Workflow/Work_Manage.aspx");

                }

                int upPhotoLength = upPhoto.ContentLength;


                if (upPhotoLength != 0)
                {
                    byte[] PhotoArray = new Byte[upPhotoLength];
                    Stream PhotoStream = upPhoto.InputStream;
                    PhotoStream.Read(PhotoArray, 0, upPhotoLength);


                    System.Drawing.Image oImage = System.Drawing.Image.FromStream(PhotoStream);
                    int oWidth = oImage.Width; //原图宽度 
                    int oHeight = oImage.Height; //原图高度 
                    if (oWidth > 295 || oHeight > 413)
                    {
                        Response.Write("<script>alert('上传照片最大为1寸。')</script>");
                        return;

                    }
                    else
                    {
                        //连接数据库 
                        string connString = StokeGlobals.Connectiondsoc;
                        SqlConnection conn = new SqlConnection(connString);
                        SqlCommand cmd = new SqlCommand("rs_Qzsp_UpdateImage", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@qzsp_id", SqlDbType.Int);
                        cmd.Parameters["@qzsp_id"].Value = doc_id;
                        cmd.Parameters.Add("@UpdateImage", SqlDbType.Image);
                        cmd.Parameters["@UpdateImage"].Value = PhotoArray;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        this.Image1.ImageUrl = "read_qzsp_photo.aspx?qzsp_id=" + doc_id;

                        Response.Redirect("../Workflow/Work_Manage.aspx");

                        //						string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=10&step_id="+step_id.ToString()+"&doc_id="+doc_id.ToString()+"&zgbh="+_zgbh.ToString();
                        //						Response.Redirect(_URL);
                    }

                }
            }
            catch (Exception ex)
            {
                //				Response.Write(ex.ToString());
            }

        }

        /// <summary>
        /// tonzoc添加，可以自动裁剪图片大小，20110414，仅上传，不做页面跳转
        /// </summary>
        public void UPaffixFiles2()
        {
            try
            {
                if (upFile.PostedFile.FileName == string.Empty)
                {
                    Response.Write("<script>alert('请选择附件的上传路径！')</script>");
                    return;
                }

                //获得图象并把图象转换为byte[] 
                HttpPostedFile upPhoto = upFile.PostedFile;
                if (upPhoto.ContentLength > 1 * 1024 * 1024)//判断文件的大小是否大于5M
                {
                    Response.Write("<script>alert('上传文件最大为1M。')</script>");

                    return;
                }

                if (upPhoto.ContentLength == 0)
                {
                    Response.Write("<script> alert('附件不正确！') </script>");
                    return;
                }

                //				int upPhotoLength=upPhoto.ContentLength; 

                int upPhotoLength = upPhoto.ContentLength;
                if (upPhotoLength != 0)
                {


                    byte[] PhotoArray = new Byte[upPhotoLength];
                    Stream PhotoStream = upPhoto.InputStream;
                    PhotoStream.Read(PhotoArray, 0, upPhotoLength);


                    System.Drawing.Image oImage = System.Drawing.Image.FromStream(PhotoStream);
                    int oWidth = oImage.Width; //原图宽度 
                    int oHeight = oImage.Height; //原图高度 
                    if (oWidth > 148 || oHeight > 207)
                    {
                        //					Response.Write("<script>alert('上传照片最大为1寸，照片将被裁减！。')</script>");
                        Bitmap bitmap = new Bitmap(148, 207);
                        System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bitmap);
                        gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        System.Drawing.Rectangle rect = new Rectangle(0, 0, 148, 207);
                        gr.DrawImage(oImage, rect, 0, 0, oWidth, oHeight, GraphicsUnit.Pixel);
                        MemoryStream stream1 = new MemoryStream();
                        bitmap.Save(stream1, ImageFormat.Jpeg);
                        PhotoArray = stream1.GetBuffer();
                        bitmap.Dispose();
                        gr.Dispose();
                    }


                    //连接数据库 
                    string connString = StokeGlobals.Connectiondsoc;
                    SqlConnection conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand("rs_Qzsp_UpdateImage", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@qzsp_id", SqlDbType.Int);
                    cmd.Parameters["@qzsp_id"].Value = doc_id;
                    cmd.Parameters.Add("@UpdateImage", SqlDbType.Image);
                    cmd.Parameters["@UpdateImage"].Value = PhotoArray;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    this.Image1.ImageUrl = "read_qzsp_photo.aspx?qzsp_id=" + doc_id;

                }
            }
            catch (Exception ex)
            {
                //				Response.Write(ex.ToString());
            }

        }

        public void ShowAffix()
        {
            this.Image1.ImageUrl = "read_qzsp_photo.aspx?qzsp_id=" + doc_id;
        }

        public string GetAffixFilename(string _name)
        {
            string affixName = "";
            int j = _name.LastIndexOf("@_@");
            affixName = _name.Substring(j + 3);//获取文件名
            return affixName;
        }

        private string GetStyleInsertData()
        {
            string mySql = "";
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("Form1");

            mySql += "insert into DSOC_Flow_Style_Data (";
            for (int i = 0; i < FieldNum; i++)
            {
                mySql += dt_step_field.Rows[i][0].ToString() + ",";
            }
            mySql = mySql.Substring(0, mySql.Length - 1) + ") values(";
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
                mySql += "update DSOC_Flow_Style_Data set ";
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
                    return ((TextBox)StyleControl).Text;
                case "System.Web.UI.WebControls.DropDownList":
                    return ((DropDownList)StyleControl).SelectedValue.ToString();
                case "System.Web.UI.WebControls.CheckBox":
                    return ((CheckBox)StyleControl).Checked.ToString();
                default:
                    return "";
            }
        }

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
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
            this.zm.Click += new System.EventHandler(this.zm_Click);
            this.bm.Click += new System.EventHandler(this.bm_Click);
            this.btn_add_jyjl.Click += new System.EventHandler(this.btn_add_jyjl_Click);
            this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
            this.btn_add_gzjl.Click += new System.EventHandler(this.btn_add_gzjl_Click);
            this.DataGrid2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_DeleteCommand);
            this.btn_add_jtgx.Click += new System.EventHandler(this.btn_add_jtgx_Click);
            this.DataGrid3.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid3_DeleteCommand);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            //this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void btn_add_jyjl_Click(object sender, System.EventArgs e)
        {
            string qzsp_jy_kssj = this.j1.Text;
            string qzsp_jy_jssj = this.k1.Text;
            string qzsp_jy_xx = this.l1.Text;
            string qzsp_jy_zy = this.m1.Text;
            string qzsp_jy_xxxs = this.n1.Text;
            string qzsp_jy_hdzs = this.o1.Text;
            int ret = Stoke.Components.Staff.InsertQzspJyjlTemp(qzsp_jy_kssj,
                qzsp_jy_jssj,
                qzsp_jy_xx,
                qzsp_jy_zy,
                qzsp_jy_xxxs,
                qzsp_jy_hdzs);
            this.i1.Text = "";
            this.j1.Text = "";
            this.k1.Text = "";
            this.l1.Text = "";
            this.m1.Text = "";
            this.n1.Text = "";
            this.o1.Text = "";
            DataTable dt_jyjl_temp = Stoke.Components.Staff.SelectQzspJyjlTemp();
            this.DataGrid1.DataSource = dt_jyjl_temp;
            this.DataGrid1.DataBind();
        }

        private void btn_add_gzjl_Click(object sender, System.EventArgs e)
        {
            string qzsp_gz_kssj = this.p1.Text;
            string qzsp_gz_jssj = this.q1.Text;
            string qzsp_gz_gzdw = this.r1.Text;
            string qzsp_gz_lxdh = this.s1.Text;
            string qzsp_gz_bm_zw = this.t1.Text;
            string qzsp_gz_srqk = this.u1.Text;
            string qzsp_gz_lzyy = this.v1.Text;
            int ret = Stoke.Components.Staff.InsertQzspGzjlTemp(qzsp_gz_kssj,
                qzsp_gz_jssj,
                qzsp_gz_gzdw,
                qzsp_gz_lxdh,
                qzsp_gz_bm_zw,
                qzsp_gz_srqk,
                qzsp_gz_lzyy);
            this.p1.Text = "";
            this.q1.Text = "";
            this.r1.Text = "";
            this.s1.Text = "";
            this.t1.Text = "";
            this.u1.Text = "";
            this.v1.Text = "";
            DataTable dt_gzjl_temp = Stoke.Components.Staff.SelectQzspGzjlTemp();
            this.DataGrid2.DataSource = dt_gzjl_temp;
            this.DataGrid2.DataBind();
        }

        private void btn_add_jtgx_Click(object sender, System.EventArgs e)
        {
            string qzsp_jt_xm = this.w1.Text;
            string qzsp_jt_nl = this.x1.Text;
            string qzsp_jt_gx = this.y1.Text;
            string qzsp_jt_dw_zw = this.z1.Text;
            int ret = Stoke.Components.Staff.InsertQzspJtgxTemp(qzsp_jt_xm,
                qzsp_jt_nl,
                qzsp_jt_gx,
                qzsp_jt_dw_zw);
            this.w1.Text = "";
            this.x1.Text = "";
            this.y1.Text = "";
            this.z1.Text = "";
            DataTable dt_jtgx_temp = Stoke.Components.Staff.SelectQzspJtgxTemp();
            this.DataGrid3.DataSource = dt_jtgx_temp;
            this.DataGrid3.DataBind();
        }

        private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            DataTable dt = Stoke.Components.Staff.DeleteQzspJyjlTempById(Int32.Parse(e.Item.Cells[0].Text));
            this.DataGrid1.DataSource = dt;
            this.DataGrid1.DataBind();
        }

        private void DataGrid2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            DataTable dt = Stoke.Components.Staff.DeleteQzspGzjlTempById(Int32.Parse(e.Item.Cells[0].Text));
            this.DataGrid2.DataSource = dt;
            this.DataGrid2.DataBind();
        }

        private void DataGrid3_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            DataTable dt = Stoke.Components.Staff.DeleteQzspJtgxTempById(Int32.Parse(e.Item.Cells[0].Text));
            this.DataGrid3.DataSource = dt;
            this.DataGrid3.DataBind();
        }

        private void zm_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("style_qzsp.aspx?DisplayType=0&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id);
        }

        private void bm_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("style_qzsp2.aspx?DisplayType=1&zgbh=" + _zgbh + "&step_id=" + step_id + "&doc_id=" + doc_id + "&liujuan=" + this.z2.Text);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (doc_id > 0 && step_id == 1)
            {
                Stoke.Components.Staff.DeleteDocument(doc_id);
                Response.Redirect("../Workflow/Work_Manage.aspx");
            }
            else if (step_id == 0)
                Response.Redirect("../Workflow/Work_Record.aspx");
            //				Response.Redirect(ViewState["retu"].ToString());
            else if (step_id == -2)//父页面qzsp_list.aspx
                Response.Redirect("qzsp_list.aspx");
            else
                Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void SaveToQzspQzjl()
        {
            int qzsp_id = doc_id;
            string qzsp_sqzw1 = this.a.SelectedValue.Trim();
            string qzsp_sqzw2 = this.b.SelectedValue.Trim();
            string qzsp_ddrq = this.c.Text;
            string qzsp_qwdy = this.d.Text;
            string qzsp_xm = this.e.Text;
            string qzsp_xb = this.f.SelectedValue.Trim();
            string qzsp_mz = this.g.Text;
            string qzsp_csrq = this.h.Text;
            string qzsp_jg = this.i.Text;
            string qzsp_zzmm = this.j.Text;
            string qzsp_jszc = this.k.Text;
            string qzsp_wysp_tc = this.l.Text;
            string qzsp_zgxl = this.m.SelectedValue.Trim();
            string qzsp_byyx = this.n.Text;
            string qzsp_sxzy = this.o.Text;
            string qzsp_bysj = this.p.Text;
            string qzsp_lb_kssj = this.q.Text;
            string qzsp_lb_jssj = this.r.Text;
            string qzsp_zf_kssj = this.s.Text;
            string qzsp_zf_jssj = this.t.Text;
            string qzsp_cjgzsj = this.u.Text;
            string qzsp_rsdaszdw = this.a1.Text;
            string qzsp_dqzt = this.b1.SelectedValue.Trim();
            string qzsp_jkzk = this.c1.Text;
            string qzsp_hyzk = this.d1.SelectedValue.Trim();
            string qzsp_sjc = this.e1.Text;
            string qzsp_lxdh_home = this.f1.Text;
            string qzsp_lxdh_mobile = this.g1.Text;
            string qzsp_sfzh = this.h1.Text;
            string qzsp_hkszd = this.i1.Text;
            string qzsp_dlxxdz = this.v.Text;
            string qzsp_ywzdbs = "";
            if (this.a2.Checked == true)
                qzsp_ywzdbs = "无";
            else
                qzsp_ywzdbs = "有";
            string qzsp_bsjk = this.c2.Text;
            string qzsp_spsj = this.e2.Text;
            int ret = Stoke.Components.Staff.InsertQzspQzjl(qzsp_id,
                qzsp_sqzw1,
                qzsp_sqzw2,
                qzsp_ddrq,
                qzsp_qwdy,
                qzsp_xm,
                qzsp_xb,
                qzsp_mz,
                qzsp_csrq,
                qzsp_jg,
                qzsp_zzmm,
                qzsp_jszc,
                qzsp_wysp_tc,
                qzsp_zgxl,
                qzsp_byyx,
                qzsp_sxzy,
                qzsp_bysj,
                qzsp_lb_kssj,
                qzsp_lb_jssj,
                qzsp_zf_kssj,
                qzsp_zf_jssj,
                qzsp_cjgzsj,
                qzsp_rsdaszdw,
                qzsp_dqzt,
                qzsp_jkzk,
                qzsp_hyzk,
                qzsp_sjc,
                qzsp_lxdh_home,
                qzsp_lxdh_mobile,
                qzsp_sfzh,
                qzsp_hkszd,
                qzsp_dlxxdz,
                qzsp_ywzdbs,
                qzsp_bsjk,
                qzsp_spsj);
            //			string qzsp_rlzypj =this.a.Text;
            //			string qzsp_yrbmpj =this.a.Text;
            //			string qzsp_zjsh =this.a.Text;
            //			string qzsp_jbzscs =this.a.Text;
            //			string qzsp_yxgw =this.a.Text;
            //			string qzsp_rlzyppr =this.a.Text;
            //			string qzsp_zyyycs  =this.a.Text;
            //			string qzsp_ywjncs  =this.a.Text;
            //			string qzsp_ynbmppr =this.a.Text;
            //			string qzsp_zpgw =this.a.Text;
            //			string qzsp_sgsj =this.a.Text;
            //			string qzsp_htqx =this.a.Text;
            //			string qzsp_syq =this.a.Text;
            //			string qzsp_yrbmfzr =this.a.Text;
            //			string qzsp_rlzyfzr =this.a.Text;
            //			string qzsp_rlzyld =this.a.Text;
            //			string qzsp_zjlsp =this.a.Text;
            //			string qzsp_xzdy =this.a.Text;
            //			string qzsp_qt =this.a.Text;
            //			string qzsp_fzr =this.a.Text;
            //			string qzsp_rq ;
        }

        #region 没用到
        private void UpdateQzspQzjl()
        {
            int qzsp_id = doc_id;
            string qzsp_sqzw1 = this.a.SelectedValue.Trim();
            string qzsp_sqzw2 = this.b.SelectedValue.Trim();
            string qzsp_ddrq = this.c.Text;
            string qzsp_qwdy = this.d.Text;
            string qzsp_xm = this.e.Text;
            string qzsp_xb = this.f.SelectedValue.Trim();
            string qzsp_mz = this.g.Text;
            string qzsp_csrq = this.h.Text;
            string qzsp_jg = this.i.Text;
            string qzsp_zzmm = this.j.Text;
            string qzsp_jszc = this.k.Text;
            string qzsp_wysp_tc = this.l.Text;
            string qzsp_zgxl = this.m.SelectedValue.Trim();
            string qzsp_byyx = this.n.Text;
            string qzsp_sxzy = this.o.Text;
            string qzsp_bysj = this.p.Text;
            string qzsp_lb_kssj = this.q.Text;
            string qzsp_lb_jssj = this.r.Text;
            string qzsp_zf_kssj = this.s.Text;
            string qzsp_zf_jssj = this.t.Text;
            string qzsp_cjgzsj = this.u.Text;
            string qzsp_rsdaszdw = this.a1.Text;
            string qzsp_dqzt = this.b1.SelectedValue.Trim();
            string qzsp_jkzk = this.c1.Text;
            string qzsp_hyzk = this.d1.SelectedValue.Trim();
            string qzsp_sjc = this.e1.Text;
            string qzsp_lxdh_home = this.f1.Text;
            string qzsp_lxdh_mobile = this.g1.Text;
            string qzsp_sfzh = this.h1.Text;
            string qzsp_hkszd = this.i1.Text;
            string qzsp_dlxxdz = this.v.Text;
            string qzsp_ywzdbs = "";
            if (this.a2.Checked == true)
                qzsp_ywzdbs = "无";
            else
                qzsp_ywzdbs = "有";
            string qzsp_bsjk = this.c2.Text;
            string qzsp_spsj = this.e2.Text;
            int ret = Stoke.Components.Staff.UpdateQzspQzjl(qzsp_id,
                qzsp_sqzw1,
                qzsp_sqzw2,
                qzsp_ddrq,
                qzsp_qwdy,
                qzsp_xm,
                qzsp_xb,
                qzsp_mz,
                qzsp_csrq,
                qzsp_jg,
                qzsp_zzmm,
                qzsp_jszc,
                qzsp_wysp_tc,
                qzsp_zgxl,
                qzsp_byyx,
                qzsp_sxzy,
                qzsp_bysj,
                qzsp_lb_kssj,
                qzsp_lb_jssj,
                qzsp_zf_kssj,
                qzsp_zf_jssj,
                qzsp_cjgzsj,
                qzsp_rsdaszdw,
                qzsp_dqzt,
                qzsp_jkzk,
                qzsp_hyzk,
                qzsp_sjc,
                qzsp_lxdh_home,
                qzsp_lxdh_mobile,
                qzsp_sfzh,
                qzsp_hkszd,
                qzsp_dlxxdz,
                qzsp_ywzdbs,
                qzsp_bsjk,
                qzsp_spsj);
        }

        #endregion
        private void btnBc_Click(object sender, System.EventArgs e)
        {
            SaveData();
            Response.Redirect("../Workflow/Work_Manage.aspx");
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            SaveData1();
            if (doc_id != 0)

                /////////////////
                ////保存doc_id,因为点击提交时，会重新加载页面，使docid为零
                ////////////////
                this.txt_doc.Text = doc_id.ToString();
            //			Response.Redirect("../Workflow/Work_Manage.aspx");



        }

        public void SaveData1()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;

            if (bEditMode == false)
            {
                mySql = GetStyleInsertData();
                //拟稿
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, this.e.Text.ToString() + "求职审批");
                df = null;

                SaveToQzspQzjl();
                UPaffixFiles1();
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                //Response.Write("<script language='javascript'>alert('" + mySql + "');</script>");
                df.UpdateDocument(mySql);
                if (step_id == 1)
                {

                    SaveToQzspQzjl();
                    UPaffixFiles1();
                }
                df = null;

            }

        }

        public void SaveData_Photo()
        {
            Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
            string mySql;

            if (bEditMode == false)
            {
                mySql = GetStyleInsertData();
                //拟稿
                doc_id = df.AddDocument(_zgbh, flow_id, mySql, this.e.Text.ToString() + "求职审批");
                df = null;

                SaveToQzspQzjl();
                UPaffixFiles2();
            }
            else
            {
                mySql = GetStyleUpdateData(doc_id);
                //Response.Write("<script language='javascript'>alert('" + mySql + "');</script>");
                df.UpdateDocument(mySql);
                if (step_id == 1)
                {

                    SaveToQzspQzjl();
                    UPaffixFiles2();
                }
                df = null;

            }

            Response.Redirect("./style_qzsp.aspx?step_id=" + this.step_id + "&doc_id=" + doc_id + "&zgbh=" + this._zgbh);

        }

        private void uploadBtn_Click(object sender, System.EventArgs e)
        {
            if (this.e.Text.Trim() == string.Empty)
            {
                Response.Write("<script>alert('请确保您已经填写求职人员姓名！')</script>");
                return;
            }
            if (this.step_id == 1)
            {
                this.SaveData_Photo();
            }
            else
            {
                Response.Write("<script>alert('仅第一步可以进行上传图片操作！')</script>");
            }
        }
    }
}
