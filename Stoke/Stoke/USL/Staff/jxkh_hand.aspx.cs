using System;
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
using System.Text.RegularExpressions;
using Stoke.COMMON;

namespace Stoke.USL.Staff
{
    public partial class jxkh_hand : System.Web.UI.Page
    {
        protected string _zgbh;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["zgbh"] != null)
                _zgbh = Session["zgbh"].ToString();
            else
                Response.Redirect("../error.aspx");
            if (!Page.IsPostBack)
            {
                //_zgbh = "0079";
                //				this.tr2.Visible = false;
                //				this.tr3.Visible = false;
                this.Table6.Visible = false;
                this.ddlNf.Items.Add(System.DateTime.Now.AddYears(-1).Year.ToString());
                this.ddlNf.Items.Add(System.DateTime.Now.Year.ToString());
                this.ddlNf.Items.Add(System.DateTime.Now.AddYears(1).Year.ToString());
                this.ddlNf.Items.Insert(0, "年份");
                //				this.ddlNf.SelectedIndex = 2;
                //				this.ddlYf.SelectedValue = (System.DateTime.Now.Month - 1).ToString();
                BindMyBm();
                BindGrid();
            }
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
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            this.ddlBm.SelectedIndexChanged += new System.EventHandler(this.ddlBm_SelectedIndexChanged);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.ddlXm.SelectedIndexChanged += new System.EventHandler(this.ddlXm_SelectedIndexChanged);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.lbtnAdd.Click += new System.EventHandler(this.lbtnAdd_Click);
            this.dgJxkh.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgJxkh_PageIndexChanged);
            this.dgJxkh.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgJxkh_CancelCommand);
            this.dgJxkh.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgJxkh_EditCommand);
            this.dgJxkh.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgJxkh_UpdateCommand);
            this.dgJxkh.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgJxkh_DeleteCommand);
            this.dgJxkh.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgJxkh_ItemDataBound);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void BindMyBm()
        {
            Stoke.Components.Staff _staff = new Stoke.Components.Staff();
            DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
            this.ddlBm.DataSource = dt_xm_bm;
            this.ddlBm.DataValueField = "ry_bm";
            this.ddlBm.DataTextField = "ry_bm";
            this.ddlBm.DataBind();
            this.ddlBm.Items.Insert(0, "-请选择-");
        }

        private void BindGrid()
        {
            string bm = this.ddlBm.SelectedValue.Trim();
            int nf = 0;
            int yf = 0;
            if (this.ddlNf.SelectedValue != "年份")
                nf = Convert.ToInt16(this.ddlNf.SelectedValue);
            if (this.ddlYf.SelectedValue != "月份")
                yf = Convert.ToInt16(this.ddlYf.SelectedValue);
            DataTable dt = Stoke.Components.Staff.SelectWzbHandJxkh(nf, yf, bm, _zgbh);
            this.dgJxkh.DataSource = dt;
            this.dgJxkh.DataBind();
            //			int count = dgJxkh.PageSize*dgJxkh.PageCount-dt.Rows.Count;
            if (dt.Rows.Count < 14)
            {
                for (int i = 0; i < 14; i++)
                    dt.Rows.Add(dt.NewRow());
                this.dgJxkh.DataBind();

                for (int i = 0; i < dgJxkh.Items.Count; i++)
                {
                    if (dgJxkh.Items[i].Cells[0].Text == "&nbsp;")
                    {
                        this.dgJxkh.Items[i].Cells[7].Controls[0].Visible = false;
                        this.dgJxkh.Items[i].Cells[8].Controls[0].Visible = false;
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            if (ddlBm.SelectedValue == "-请选择-")
                Response.Write("<script language='javascript'>alert('请选择部门');</script>");
            else
            {
                if (this.ddlNf.SelectedValue == "年份" || this.ddlYf.SelectedValue == "月份")
                    Response.Write("<script language='javascript'>alert('请选择年份和月份');</script>");
                else
                {
                    this.dgJxkh.SelectedIndex = 0;
                    BindGrid();
                }
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (ddlBm.SelectedValue == "-请选择-")
                Response.Write("<script language='javascript'>alert('请选择部门');</script>");
            else
            {
                if (this.ddlNf.SelectedValue == "年份" || this.ddlYf.SelectedValue == "月份")
                    Response.Write("<script language='javascript'>alert('请选择年份和月份');</script>");
                else
                {
                    if (this.txtZgbh.Text == string.Empty)
                    {
                        Response.Write("<script language='javascript'>alert('请填写职工编号');</script>");
                        return;
                    }
                    if (this.ddlXm.SelectedIndex == 0)
                    {
                        Response.Write("<script language='javascript'>alert('请填写职工姓名');</script>");
                        return;
                    }
                    if (this.txtFh.Text == string.Empty)
                    {
                        Response.Write("<script language='javascript'>alert('请填写复核分数');</script>");
                        return;
                    }
                    string zgbh = this.txtZgbh.Text;
                    string xm = this.ddlXm.SelectedItem.Text.Trim();
                    string bm = this.ddlBm.SelectedValue;
                    int nf = 0;
                    int yf = 0;
                    float zp = 0;
                    float kh = 0;
                    float fh = 0;
                    float zf = 0;
                    try
                    {
                        nf = int.Parse(this.ddlNf.SelectedValue);
                        yf = int.Parse(this.ddlYf.SelectedValue);
                        zf = float.Parse(this.txtFh.Text);
                        if (this.txtZp.Text == string.Empty)
                            zp = 0;
                        else
                            zp = float.Parse(this.txtZp.Text);
                    }
                    catch
                    {

                    }
                    double jxkh_xs = 0;
                    if (zf <= 90)
                        jxkh_xs = Convert.ToDouble(Math.Round(zf / 90, 2));
                    else
                        jxkh_xs = Convert.ToDouble(Math.Round(1 + (zf - 90) * 0.02, 2));

                    string pylx = "";
                    Stoke.Components.Staff person = new Stoke.Components.Staff();
                    SqlDataReader dr = person.GetStaffInfo(zgbh);
                    if (dr.Read())
                    {
                        pylx = dr["pylx"].ToString();
                    }

                    Stoke.Components.Staff.InsertGljslJxkhTemp(zgbh, xm, bm, "", nf, yf, zp, kh, fh, zf, pylx, jxkh_xs, _zgbh);
                    BindGrid();
                }
            }
        }

        private static bool IsNumeric(string itemValue)
        {
            return (IsRegEx("^(-?[0-9]*[.]*[0-9]{0,3})$", itemValue));
        }

        private static bool IsRegEx(string regExValue, string itemValue)
        {

            try
            {
                Regex regex = new System.Text.RegularExpressions.Regex(regExValue);
                if (regex.IsMatch(itemValue)) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
            }
        }

        private void dgJxkh_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int i = e.Item.ItemIndex;
            if (this.dgJxkh.Items[i].Cells[6].Text == "否")
            {
                this.dgJxkh.EditItemIndex = i;
                BindGrid();
                TextBox txt_fh = (TextBox)this.dgJxkh.Items[i].Cells[4].Controls[0];
                txt_fh.Width = Unit.Pixel(80);
            }
            else
            {
                Response.Write("<script>alert('该项已经提交，不能修改！')</script>");
            }
        }

        private void dgJxkh_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (((TextBox)e.Item.Cells[4].Controls[0]).Text.ToString() != "")
            {
                string jxkh_fh = ((TextBox)e.Item.Cells[4].Controls[0]).Text.ToString();
                float fh = 0;
                double xs = 0;
                if (IsNumeric(jxkh_fh))
                {
                    fh = float.Parse(jxkh_fh);
                    int i = e.Item.ItemIndex;
                    int zdbh = Convert.ToInt32(this.dgJxkh.Items[i].Cells[0].Text);
                    if (fh <= 90)
                        xs = Convert.ToDouble(Math.Round(fh / 90, 2));
                    else
                        xs = Convert.ToDouble(Math.Round(1 + (fh - 90) * 0.02, 2));
                    Stoke.Components.Staff.UpdateJxkhFhTempById(zdbh, fh, xs);
                    this.dgJxkh.EditItemIndex = -1;
                    this.BindGrid();
                }
                else
                {
                    Response.Write("<script>alert('请输入数值型！')</script>");
                    return;
                }

            }
        }

        private void dgJxkh_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            this.dgJxkh.EditItemIndex = -1;
            this.BindGrid();
        }

        private void dgJxkh_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.Item.Cells[6].Text == "否")
            {
                int ret = Stoke.Components.Staff.DeleteJxkhTemp(Convert.ToInt16(e.Item.Cells[0].Text));
                if (ret != -1)
                    Response.Write("<script>alert(删除成功！')</script>");
                this.BindGrid();
            }
            else
            {
                Response.Write("<script>alert('该项已经提交，不能删除！')</script>");
            }
        }

        private void dgJxkh_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            this.dgJxkh.CurrentPageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        private void dgJxkh_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            //			if(e.Item.Cells[0].Text=="&nbsp;")
            //			{
            //				e.Item.Cells[7].Visible = false;
            //				e.Item.Cells[8].Visible = false;
            //			}
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (ddlBm.SelectedValue == "-请选择-")
                Response.Write("<script language='javascript'>alert('请选择部门！');</script>");
            else
            {
                if (this.ddlNf.SelectedValue == "年份" || this.ddlYf.SelectedValue == "月份")
                    Response.Write("<script language='javascript'>alert('请选择年份和月份！');</script>");
                else
                {
                    int ret = Stoke.Components.Staff.InsertJxkhFromTemp(Convert.ToInt16(this.ddlNf.SelectedValue), Convert.ToInt16(this.ddlYf.SelectedValue), this.ddlBm.SelectedValue, _zgbh);
                    this.BindGrid();
                    if (ret != -1)
                        Response.Write("<script language='javascript'>alert('提交成功！');</script>");
                }
            }
        }

        private void lbtnAdd_Click(object sender, System.EventArgs e)
        {
            if (ddlBm.SelectedValue == "-请选择-")
                Response.Write("<script language='javascript'>alert('请选择部门！');</script>");
            else
            {
                if (this.ddlNf.SelectedValue == "年份" || this.ddlYf.SelectedValue == "月份")
                    Response.Write("<script language='javascript'>alert('请选择年份和月份！');</script>");
                else
                {
                    this.Table6.Visible = true;
                }
            }
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            this.Table6.Visible = false;
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            string ry_xm_list = SlctMember1.Send[0].ToString().Trim();
            string ry_zgbh_list = SlctMember1.Send[1].ToString().Trim();
            string xm = "";
            string zgbh = "";
            string bm = this.ddlBm.SelectedValue.Trim();
            int nf = Convert.ToInt16(this.ddlNf.SelectedValue);
            int yf = Convert.ToInt16(this.ddlYf.SelectedValue);
            for (int i = 0; i < ry_xm_list.Split(',').Length; i++)
            {
                xm = ry_xm_list.Split(',')[i].ToString().Trim();
                zgbh = ry_zgbh_list.Split(',')[i].ToString().Trim();

                string pylx = "";
                Stoke.Components.Staff person = new Stoke.Components.Staff();
                SqlDataReader dr = person.GetStaffInfo(zgbh);
                if (dr.Read())
                {
                    pylx = dr["pylx"].ToString();
                }

                Stoke.Components.Staff.InsertGljslJxkhTemp(zgbh, xm, bm, "", nf, yf, 0, 0, 0, 0, pylx, 0, _zgbh);
            }
            this.BindGrid();
            this.SlctMember1.Clear();
            this.Table6.Visible = false;
        }

        private void ddlBm_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlBm.SelectedIndex != 0)
            {
                string cmdText = "select distinct ry_zgbh, ry_xm from dsoc_ry where rtrim(ry_bm) = '" + ddlBm.SelectedValue.ToString().Trim() + "' order by ry_zgbh";
                string connString = Stoke.DAL.SQLHelper.CONN_STRING;
                SqlConnection conn = new SqlConnection(connString);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    ddlXm.Enabled = true;
                    ddlXm.DataSource = dt;
                    ddlXm.DataTextField = "ry_xm";
                    ddlXm.DataValueField = "ry_zgbh";
                    ddlXm.DataBind();
                    ddlXm.Items.Insert(0, "-请选择-");
                }
                catch (Exception ex)
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            else
            {
                txtZgbh.Text = string.Empty;
                ddlXm.SelectedIndex = 0;
                ddlXm.Enabled = false;
            }
        }

        private void ddlXm_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlXm.SelectedIndex != 0)
                txtZgbh.Text = ddlXm.SelectedValue.ToString().Trim();
            else
                txtZgbh.Text = string.Empty;
        }
    }
}
