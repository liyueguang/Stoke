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
using Stoke.COMMON;

namespace Stoke.USL.Staff
{
    public partial class style_jxkhcz : System.Web.UI.Page
    {
		DataTable dt_step_field;
		private int  step_id = 1;        
		private int doc_id = 0;         
		private int flow_id = 37;
		private int FieldNum = 0;
		private bool bEditMode = false;	
		protected string _zgbh;
		protected string _zgxm; 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			_zgbh = Request["zgbh"].ToString();
			step_id = Convert.ToInt32(Request["step_id"]);
			doc_id = Convert.ToInt32(Request["doc_id"]);
			//			_zgbh="0079";
			//			step_id=1;
			//根据doc_id判断执行表单数据的插入操作或更新操作
			if (doc_id > 0)
				bEditMode = true;

			//获取当前流程的当前步骤绑定的field
			dt_step_field = Stoke.Components.StyleRef.Select_Field_by_Step(flow_id, step_id);

			//获取当前流程的当前步骤绑定的field的数量
			FieldNum = dt_step_field.Rows.Count;
			if(!Page.IsPostBack)
			{
				//根据doc_id取得当前document中已有数据
				if(doc_id > 0)
					Step_Handle_Data();
			
				//绑定当前流程当前步骤的field
				Field_Bind(dt_step_field);
				//取得员工姓名
				Stoke.Components.Staff _staff = new Stoke.Components.Staff();
				DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh) ;
				_zgxm = dt_xm_bm.Rows[0][0].ToString();
				if(step_id==0)//工作查看
					this.btnSave.Visible = false;
				else if(step_id == 1)
				{
					
					this.o.Text = Convert.ToString(System.DateTime.Now.Year);
					this.p.Text = Convert.ToString(System.DateTime.Now.Month);
					
					
					this.a.Text = _zgxm;
					this.b.Text = _zgbh;
					this.c.DataSource = dt_xm_bm;
					this.c.DataValueField = "ry_zw";
					this.c.DataTextField = "ry_zw";
					this.c.DataBind();
					this.d.DataSource = dt_xm_bm;
					this.d.DataValueField = "ry_bm";
					this.d.DataTextField = "ry_bm";
					this.d.DataBind();
					if(doc_id>0)
						this.btnCancel.Text = "删除";
				}
				else if(step_id == 2)
				{
					this.j.Text = _zgxm;
					this.k.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
					this.btnSave.CausesValidation=true;
				}

				else if(step_id == 3)
				{
					this.m.Text = _zgxm;
					this.n.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
				}
				else if(step_id==-1)
				{
					SaveToJxcz();
					Response.Redirect("../Workflow/Work_Manage.aspx?zgbh="+_zgbh);
				}

				
					
			}//postback
		}//pageload

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
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		
		
		private void Step_Handle_Data()
		{
			DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
			
			this.a.Text = dt_style_data.Rows[0]["a"].ToString()!=null ? dt_style_data.Rows[0]["a"].ToString():null;
			this.b.Text = dt_style_data.Rows[0]["b"].ToString()!=null ? dt_style_data.Rows[0]["b"].ToString():null;

//			职务
			this.c.DataSource = dt_style_data;
			this.c.DataValueField = "c";
			this.c.DataTextField = "c";
			this.c.DataBind();
//			部门
			this.d.DataSource = dt_style_data;
			this.d.DataValueField = "d";
			this.d.DataTextField = "d";
			this.d.DataBind();
			
			this.c.SelectedItem.Text = dt_style_data.Rows[0]["c"].ToString()!=null ? dt_style_data.Rows[0]["c"].ToString():null;
			this.d.SelectedItem.Text = dt_style_data.Rows[0]["d"].ToString()!=null ? dt_style_data.Rows[0]["d"].ToString():null;
			//试一下1.直接用DataBind 2.直接用this.c.selectvalue
			
			this.e.Text = dt_style_data.Rows[0]["e"].ToString()!=null ? dt_style_data.Rows[0]["e"].ToString():null;
			this.f.Text = dt_style_data.Rows[0]["f"].ToString()!=null ? dt_style_data.Rows[0]["f"].ToString():null;
			this.g.Text = dt_style_data.Rows[0]["g"].ToString()!=null ? dt_style_data.Rows[0]["g"].ToString():null;
			this.h.Text = dt_style_data.Rows[0]["h"].ToString()!=null ? dt_style_data.Rows[0]["h"].ToString():null;
			this.i.Text = dt_style_data.Rows[0]["i"].ToString()!=null ? dt_style_data.Rows[0]["i"].ToString():null;
			this.j.Text = dt_style_data.Rows[0]["j"].ToString()!=null ? dt_style_data.Rows[0]["j"].ToString():null;
			this.k.Text = dt_style_data.Rows[0]["k"].ToString()!=null ? dt_style_data.Rows[0]["k"].ToString():null;
			this.l.Text = dt_style_data.Rows[0]["l"].ToString()!=null ? dt_style_data.Rows[0]["l"].ToString():null;
			this.m.Text = dt_style_data.Rows[0]["m"].ToString()!=null ? dt_style_data.Rows[0]["m"].ToString():null;
			this.n.Text = dt_style_data.Rows[0]["n"].ToString()!=null ? dt_style_data.Rows[0]["n"].ToString():null;	
			this.o.Text = dt_style_data.Rows[0]["o"].ToString()!=null ? dt_style_data.Rows[0]["o"].ToString():null;
			this.p.Text = dt_style_data.Rows[0]["p"].ToString()!=null ? dt_style_data.Rows[0]["p"].ToString():null;	
		}
		private void Field_Bind(DataTable dt)
		{
			string name = null;
			HtmlForm FrmNewDocument   = (HtmlForm)this.Page.FindControl("Form1");
			System.Web.UI.Control StyleControl = new Control();
			for(int i = 0; i < dt.Rows.Count; i++)
			{
				name = dt.Rows[i][0].ToString();
				StyleControl = FrmNewDocument.FindControl(name);
				if(StyleControl.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
				{
					((TextBox)StyleControl).BackColor = Color.White;
					((TextBox)StyleControl).ReadOnly = false;
				}
				if(StyleControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
				{
					((DropDownList)StyleControl).Enabled = true ;
					((DropDownList)StyleControl).BackColor = Color.White;
				}
				if(StyleControl.GetType().ToString() == "System.Web.UI.WebControls.Label")
				{
					((Label)StyleControl).Enabled = true ;
					((Label)StyleControl).BackColor = Color.White;
				}
			}
		}
		public void SaveToJxcz()
		{
			string zgbh = this.b.Text;
			string xm = this.a.Text;	
			string bm = this.d.SelectedValue;
			string gw = this.c.SelectedValue;
			int nf = 0;
			int yf = 0;
			float zp = 0;
			float kh = 0;
			float fh = 0;
			float zf = 0;
			try
			{
				

				nf = int.Parse(this.o.Text);
				yf = int.Parse(this.p.Text);
				zf = float.Parse(this.i.Text);
			}
			catch
			{
				
			}
			double jxkh_xs = 0;
			if(zf <= 90)
				jxkh_xs = Convert.ToDouble(Math.Round(zf / 90,2));
			else
				jxkh_xs = Convert.ToDouble(Math.Round(1 + (zf - 90) * 0.02,2));

			string pylx = "";
			Stoke.Components.Staff person = new Stoke.Components.Staff();
			SqlDataReader dr = person.GetStaffInfo(zgbh);
			if(dr.Read ())
			{
				pylx = dr["pylx"].ToString();
			}

			Stoke.Components.Staff.InsertGljslJxkh(zgbh,xm,bm,gw,nf,yf,zp,kh,fh,zf,pylx,jxkh_xs,doc_id);
			
//			string jxcz_xm = this.a.Text;
//			string jxcz_zgbh = this.b.Text;
//			string jxcz_zw = this.c.SelectedValue;
//			string jxcz_bm = this.d.SelectedValue;
//			
//			string jxcz_jx = this.e.Text;
//			string jxcz_bzcc = this.f.Text;
//			string jxcz_sjms = this.g.Text;
//
//			string jxcz_pj = this.h.Text;
//			int jxcz_fs = Convert.ToInt32(i.Text.ToString());
//			string jxcz_khr = this.j.Text;
//			string jxcz_khrq = this.k.Text;
//			
//			string jxcz_shyj = this.l.Text;
//			string jxcz_shr = this.m.Text;
//			string jxcz_shrq = this.n.Text;
//			int ret = Stoke.Components.Staff.InsertJxcz(jxcz_xm,
//				jxcz_zgbh,
//				jxcz_zw,
//				jxcz_bm,
//				jxcz_jx,
//				jxcz_bzcc,
//				jxcz_sjms,
//				jxcz_pj,
//				jxcz_fs ,
//				jxcz_khr,
//				jxcz_khrq,
//				jxcz_shyj,
//				jxcz_shr ,
//				jxcz_shrq);
//			//			int yxts = int.Parse(this.u.Text) + DateTime.Compare(Convert.ToDateTime(this.h.Text), Convert.ToDateTime(this.g.Text));
//			//			Stoke.Components.Staff.UpdateNjjhByZgbh(this.i1.Text,Convert.ToDateTime(this.d1.Text).Year,yxts);
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(step_id == 1)
			{		
				if(this.o.Text.Trim()==""||this.p.Text.Trim()=="")
				{
					Response.Write("<script>alert('请输入年和月')</script>");
					return;
				}
				SaveData();
				string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=37&step_id="+step_id.ToString()+"&doc_id="+doc_id.ToString()+"&zgbh="+_zgbh.ToString();
				Response.Redirect(_URL);
			}
			else
			{
				SaveData();
				string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=37&step_id="+step_id.ToString()+"&doc_id="+doc_id.ToString()+"&zgbh="+_zgbh.ToString();
				Response.Redirect(_URL);
			}
		}
		public void SaveData()
		{
			Stoke.Components.DocumentFlow df = new Stoke.Components.DocumentFlow();
			string mySql;
			//Response.Write(this.a.Text);

			if(bEditMode==false)
			{
				mySql= GetStyleInsertData();
				//拟稿
				doc_id = df.AddDocument(_zgbh,flow_id,mySql,a.Text.ToString().Trim()+"操作类绩效考核申请");
				df = null;
			}
			else
			{
				mySql = GetStyleUpdateData(doc_id);
				//Response.Write("<script language='javascript'>alert('" + mySql + "');</script>");
				df.UpdateDocument(mySql);
				df = null;
				//				if(step_id==6)
				//					SaveToQjsp();
							
			}
		
		}
		private string GetStyleInsertData()
		{
			string mySql="";
			HtmlForm FrmNewDocument   = (HtmlForm)this.Page.FindControl("Form1");

			mySql	+= "insert into DSOC_Flow_Style_Data (";
			for(int i=0;i<FieldNum;i++)
			{
				mySql	+= dt_step_field.Rows[i][0].ToString()+",";
			}
			mySql = mySql.Substring(0,mySql.Length-1)+") values(";
			for(int i=0;i<FieldNum;i++)
			{
				string field_name = dt_step_field.Rows[i][0].ToString();
				string field_text = GetControlText(field_name);
				mySql	+= "'" + field_text.Replace("'","''") + "',"; 
			}
			
				
			mySql = mySql.Substring(0,mySql.Length-1)+")";
			return mySql;
		}
		
		private string GetStyleUpdateData(int DocID)
		{
			string mySql="";
			HtmlForm FrmNewDocument   = (HtmlForm)this.Page.FindControl("Form1");
						
			if( FieldNum>0)
			{
				mySql	+= "update DSOC_Flow_Style_Data set ";
				for(int i=0;i<FieldNum;i++)
				{
					string field_name = dt_step_field.Rows[i][0].ToString();
					string field_text = GetControlText(field_name);
					mySql	+= field_name + "=" + "'" + field_text.Replace("'","''") + "'";
					if(i!=(FieldNum-1))
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
			HtmlForm FrmNewDocument   = (HtmlForm)this.Page.FindControl("Form1");
			System.Web.UI.Control StyleControl = new Control();
			StyleControl = FrmNewDocument.FindControl(field_name);
			switch (StyleControl.GetType().ToString())
			{
				case "System.Web.UI.WebControls.TextBox":
					return ((TextBox)StyleControl).Text;
				case "System.Web.UI.WebControls.DropDownList":
					return ((DropDownList)StyleControl).SelectedValue.ToString() ;
				case "System.Web.UI.WebControls.Label":
					return ((Label)StyleControl).Text.ToString() ;
				default:		
					return "";
			} 
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if(doc_id>0&&step_id==1)
			{
				Stoke.Components.Staff.DeleteDocument(doc_id);
				Response.Redirect("../Workflow/Work_Manage.aspx");
			}
			else if(step_id==0)
				Response.Redirect("../Workflow/Work_Record.aspx");
			else
				Response.Redirect("../Workflow/Work_Manage.aspx");
		}


	}
    }
