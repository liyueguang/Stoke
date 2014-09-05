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
    public partial class style_qjsp : System.Web.UI.Page
    {
		DataTable dt_step_field;
		private int  step_id = 1;         ///////////////////////////////////////////////
		private int doc_id = 0;          //////////////////////////////////////////////
		private int flow_id = 4;
		private int FieldNum = 0;
		private bool bEditMode = false;
		protected string _zgbh="";
		protected string _zgxm=""; //////////////////////////////////////////////////
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(Request["zgbh"]!=null)
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

			//---------------------------------------------------tonzoc-2010.01.14----------------------------------------------
//			if (g.Text != string.Empty && h.Text != string.Empty)
//			{
//				if (this.getQjspCf() == true)
//				{
//					btnSave.Attributes.Add("onclick", "return confirm('test');");
//				}
//				else
//				{
//					btnSave.Attributes.Clear();
//				}
//			}
			//------------------------------------------------------------------------------------------------------------------
			

			if(!Page.IsPostBack)
			{
				ViewState["retu"]=Request.UrlReferrer.ToString(); //20090622

				tishi.Visible = false;

				//根据doc_id取得当前document中已有数据
				if(doc_id > 0)
					Step_Handle_Data();
			
				//绑定当前流程当前步骤的field
				Field_Bind(dt_step_field);
				//取得员工姓名
				Stoke.Components.Staff _staff = new Stoke.Components.Staff();
				DataTable dt_xm_bm = _staff.GetXmBmZwByZdbh(_zgbh);
				if(dt_xm_bm.Rows.Count!=0)
					_zgxm = dt_xm_bm.Rows[0][0].ToString();
				if(step_id==0||step_id==-2)
					this.btnSave.Visible = false;
				else if(step_id == 1)
				{
					Stoke.Components.Staff.Nj_tongji();
					
					this.i1.Text = _zgbh;
					this.a.Text = _zgxm;
					this.b.DataSource = dt_xm_bm;
					this.b.DataValueField = "ry_bm";
					this.b.DataTextField = "ry_bm";
					this.b.DataBind();
					this.c.DataSource = dt_xm_bm;
					this.c.DataValueField = "ry_zw";
					this.c.DataTextField = "ry_zw";
					this.c.DataBind();
					this.m.Text = _zgxm;
					this.n.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
					if(doc_id>0)
						this.btnCancel.Text = "删除";
					else if(doc_id==0)
					{
						SqlDataReader dr;
						Stoke.Components.Staff person = new Stoke.Components.Staff();
						dr = person.GetStaffInfo(_zgbh);
						if(dr.Read ())
						{
							this.d.Text = ((dr["Birthday"]==DBNull.Value) || (DateTime.Parse(dr["Birthday"].ToString()).Date==DateTime.Parse("1900-1-1").Date))?"":DateTime.Parse(dr["Birthday"].ToString()).ToString("yyyy-MM-dd");
							this.e.Text = ((dr["jbdwsj"]==DBNull.Value) || (DateTime.Parse(dr["jbdwsj"].ToString()).Date==DateTime.Parse("1900-1-1").Date))?"":DateTime.Parse(dr["jbdwsj"].ToString()).ToString("yyyy-MM-dd");
							this.j1.Text = ((dr["cjgzsj"]==DBNull.Value) || (DateTime.Parse(dr["cjgzsj"].ToString()).Date==DateTime.Parse("1900-1-1").Date))?"":DateTime.Parse(dr["cjgzsj"].ToString()).ToString("yyyy-MM-dd");
						}
						DataTable dt=Stoke.Components.Staff.GetAll2_wtsp_temp(_zgbh);
						this.DataGrid1.DataSource=dt;
						for(int i=0;i<this.DataGrid1.PageSize;i++)
							dt.Rows.Add(dt.NewRow());
						this.DataGrid1.DataBind();
						dr.Close();
					}

					//------------------tonzoc-1.21--------------------------
					bindNj();
					s.ReadOnly = true;
					t.ReadOnly = true;
					u.ReadOnly = true;
					//-------------------------------------------------------
					
				}
				else if (step_id == 2)
				{
					this.o.Text = _zgxm;
					this.p.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
				}

				else if(step_id == 3)
				{
					this.k1.Text = _zgxm;
					this.l1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
				}

				else if(step_id == 4)
				{
					this.q.Text = _zgxm;
					this.r.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
				}

				if(step_id == 5)
				{
					this.c1.Text = _zgxm;
					this.d1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
					this.njModifyBtn.Visible = true;
//					if(f.SelectedValue=="年假")
//					{
//						//年假信息
//						DataTable dt_nj = Stoke.Components.Staff.GetNjjhByZgbh(this.i1.Text,Convert.ToInt16((g.Text).Substring(0,4)));
//						if(dt_nj!=null)
//						{
//							if(dt_nj.Rows.Count!=0)
//							{
//								this.s.Text = dt_nj.Rows[0][2].ToString();
//								this.t.Text = dt_nj.Rows[0][3].ToString();
//								this.u.Text = dt_nj.Rows[0][4].ToString();
//							}
//							else
//							{
//								this.s.Text = "0";
//								this.t.Text = "0";
//								this.u.Text = "0";
//							}
//						}
//						else
//						{
//							this.s.Text = "0";
//							this.t.Text = "0";
//							this.u.Text = "0";
//						}
//					}
				}

				else if(step_id == 6)
				{
					this.e1.Text = _zgxm;
					this.f1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");						
				}

				else if(step_id == 7)
				{
					this.g1.Text = _zgxm;
					this.h1.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
				}

				else if(step_id==-1)
				{
					SaveToQjsp();
					Response.Redirect("../Workflow/Work_Manage.aspx?zgbh="+_zgbh);
				}
				Response.Write("<script>__doPostBack('h','')</script>");
			}
		}

		private void Step_Handle_Data()
		{
			DataTable dt_style_data = Stoke.Components.StyleRef.Select_Data_by_DocID(doc_id);
			this.i1.Text = dt_style_data.Rows[0]["i1"].ToString()!=null ? dt_style_data.Rows[0]["i1"].ToString():null;
			this.a.Text = dt_style_data.Rows[0]["a"].ToString()!=null ? dt_style_data.Rows[0]["a"].ToString():null;
			this.b.DataSource = dt_style_data;
			this.b.DataValueField = "b";
			this.b.DataTextField = "b";
			this.b.DataBind();
			this.c.DataSource = dt_style_data;
			this.c.DataValueField = "c";
			this.c.DataTextField = "c";
			this.c.DataBind();
			//this.b.SelectedItem.Text = dt_style_data.Rows[0]["b"].ToString()!=null ? dt_style_data.Rows[0]["b"].ToString():null;
			//this.c.SelectedItem.Text = dt_style_data.Rows[0]["c"].ToString()!=null ? dt_style_data.Rows[0]["c"].ToString():null;
			this.d.Text = dt_style_data.Rows[0]["d"].ToString()!=null ? dt_style_data.Rows[0]["d"].ToString():null;
			this.e.Text = dt_style_data.Rows[0]["e"].ToString()!=null ? dt_style_data.Rows[0]["e"].ToString():null;
			this.f.SelectedValue = dt_style_data.Rows[0]["f"].ToString();
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
			this.q.Text = dt_style_data.Rows[0]["q"].ToString()!=null ? dt_style_data.Rows[0]["q"].ToString():null;
			this.r.Text = dt_style_data.Rows[0]["r"].ToString()!=null ? dt_style_data.Rows[0]["r"].ToString():null;
			this.s.Text = dt_style_data.Rows[0]["s"].ToString()!=null ? dt_style_data.Rows[0]["s"].ToString():null;
			this.t.Text = dt_style_data.Rows[0]["t"].ToString()!=null ? dt_style_data.Rows[0]["t"].ToString():null;
			this.u.Text = dt_style_data.Rows[0]["u"].ToString()!=null ? dt_style_data.Rows[0]["u"].ToString():null;
			this.a1.Text = dt_style_data.Rows[0]["a1"].ToString()!=null ? dt_style_data.Rows[0]["a1"].ToString():null;
			this.b1.Text = dt_style_data.Rows[0]["b1"].ToString()!=null ? dt_style_data.Rows[0]["b1"].ToString():null;
			this.c1.Text = dt_style_data.Rows[0]["c1"].ToString()!=null ? dt_style_data.Rows[0]["c1"].ToString():null;
			this.d1.Text = dt_style_data.Rows[0]["d1"].ToString()!=null ? dt_style_data.Rows[0]["d1"].ToString():null;
			this.e1.Text = dt_style_data.Rows[0]["e1"].ToString()!=null ? dt_style_data.Rows[0]["e1"].ToString():null;
			this.f1.Text = dt_style_data.Rows[0]["f1"].ToString()!=null ? dt_style_data.Rows[0]["f1"].ToString():null;
			this.g1.Text = dt_style_data.Rows[0]["g1"].ToString()!=null ? dt_style_data.Rows[0]["g1"].ToString():null;
			this.h1.Text = dt_style_data.Rows[0]["h1"].ToString()!=null ? dt_style_data.Rows[0]["h1"].ToString():null;
			this.j1.Text = dt_style_data.Rows[0]["j1"].ToString()!=null ? dt_style_data.Rows[0]["j1"].ToString():null;
			this.k1.Text = dt_style_data.Rows[0]["k1"].ToString()!=null ? dt_style_data.Rows[0]["k1"].ToString():null;
			this.l1.Text = dt_style_data.Rows[0]["l1"].ToString()!=null ? dt_style_data.Rows[0]["l1"].ToString():null;
		
			DataTable dt_sqwt_nr = Stoke.Components.Staff.SelectWtspnrById(doc_id);
			this.DataGrid1.DataSource=dt_sqwt_nr;
			this.DataGrid1.DataBind();
			int count = DataGrid1.PageSize*DataGrid1.PageCount-dt_sqwt_nr.Rows.Count;
			for(int i= 0;i<count;i++)
				dt_sqwt_nr.Rows.Add(dt_sqwt_nr.NewRow());

			this.DataGrid1.DataBind();
			if(step_id!=1)
			{
				this.tr1.Visible = false;
				this.tr2.Visible = false;
			}
			
//			else
//			{
//				DataTable dt_sqwt_nr_temp = Stoke.Components.Staff.SelectWtspnrTempByDocId(doc_id,_zgbh);
//				this.DataGrid1.DataSource=dt_sqwt_nr_temp;
//				this.DataGrid1.DataBind();
//				int count = DataGrid1.PageSize*DataGrid1.PageCount-dt_sqwt_nr_temp.Rows.Count;
//				for(int i= 0;i<count;i++)
//					dt_sqwt_nr_temp.Rows.Add(dt_sqwt_nr_temp.NewRow());
//
//				this.DataGrid1.DataBind();
//				this.tr1.Visible = true;
//				this.tr2.Visible = true;
//			}
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
			this.h.TextChanged += new System.EventHandler(this.h_TextChanged);
			this.btn_y.Click += new System.EventHandler(this.btn_y_Click);
			this.btn_n.Click += new System.EventHandler(this.btn_n_Click);
			this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.t.TextChanged += new System.EventHandler(this.t_TextChanged);
			this.njModifyBtn.Click += new System.EventHandler(this.njModifyBtn_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(step_id==1)
			{
				if(a.Text==""||b.SelectedValue==""||f.SelectedIndex==0||g.Text ==""||h.Text =="")
				{
					Response.Write("<script>alert('请填写带*的项！')</script>");
					return;
				}
				if(f.SelectedValue=="年假"&&j.Text==string.Empty)
				{
					Response.Write("<script>alert('请填写请假天数！')</script>");
					return;
				}
				if (g.Text.Length < 13 || h.Text.Length < 13)
				{
					Response.Write("<script>alert('请填写请假时间中的小时部分！')</script>");
					return;
				}
				#region 判断是否补以前的请假
//				//10.8 dxq
//				string begin=this.g.Text.ToString();
////				string current= System.DateTime.Now.ToString("yyyy-MM-dd hh");
////				int cmp1=CompareStrings(begin,current);
////				
////				
////				if(cmp1<0)
////				{
////					Response.Write("<script>alert('请假开始时间不能早于当前时间！')</script>");
////					return;
////				}
//				string connString = dsocGlobals.Connectiondsoc; 
//				SqlConnection conn = new SqlConnection(connString);
//				conn.Open();
//				string str1 = "select max(qjsp_jssj) from rs_flow_qjsp where qjsp_zgbh= '"+ _zgbh+"'";
//				SqlCommand cmd = new SqlCommand(str1, conn);
//				SqlDataReader dr = cmd.ExecuteReader();
//				string max_end="";
//				if(dr.Read())
//				{
//					if(dr.GetValue(0).ToString()!="")
//						max_end=dr.GetValue(0).ToString();		
//				}
//				dr.Close();
//				conn.Close();
//				if(max_end!="")
//				{
//					int cmp2=CompareStrings(begin,max_end);
//					if(cmp2<0)
//					{
//						Response.Write("<script>alert('请假开始时间不能早于已经批准的请假中的结束时间！')</script>");
//						return;
//					}
//				}
				#endregion

				#region 判断是否交叉请假 用between and
				
				#endregion

				//-----------------------------tonzoc-2010.01.12-----------------------------------------------
//				string connString = dsocGlobals.Connectiondsoc; 
//				SqlConnection conn = new SqlConnection(connString);
//				conn.Open();
//				string str = "select qjsp_kssj, qjsp_jssj from rs_flow_qjsp_cfts where qjsp_zgbh='" + _zgbh + "'";
//				SqlDataAdapter  da=new SqlDataAdapter(str,conn);
//				DataTable dt1=new DataTable();
//				da.Fill(dt1);
//				conn.Close();
//
//				for (int i = 0; i < dt1.Rows.Count; i++)
//				{
//					//					string kssjLimitStr = dt.Rows[i][0].ToString();
//					//					string jssjLimitStr = dt.Rows[i][1].ToString();
//					//					string kssjStr = g.Text;
//					//					string jssjStr = h.Text;
//
//					DateTime kssjLimit = getDateTimeFromString(dt1.Rows[i][0].ToString());
//					DateTime jssjLimit = getDateTimeFromString(dt1.Rows[i][1].ToString());
//					DateTime kssj = getDateTimeFromString(g.Text.Trim());
//					DateTime jssj = getDateTimeFromString(h.Text.Trim());
//
//					if (kssj >= kssjLimit && kssj <= jssjLimit || jssj >= kssjLimit && jssj <= jssjLimit || kssj <= kssjLimit && jssj >= jssjLimit)
//					{
////						tishi.Visible = true;
////						Response.Write("<script>if(!confirm('请假时间重复，是否继续？')){return false;}</script>");
////						Response.Write("<script>confirm('请假时间重复，是否继续？')</script>");
//						return;
//					}
//				}
				//----------------------------------------------------------------------------------------------

				if (this.getQjspCf() == true)
				{
					tishi.Visible = true;
					return;
				}
				

				Stoke.Components.Staff.InsertQjsp_cfts(_zgbh, g.Text.Trim(), h.Text.Trim());

				SaveData();
				Stoke.Components.Staff.InsertWtspnrById(doc_id,this.i1.Text.Trim());
				string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=4&step_id="+step_id.ToString()+"&doc_id="+doc_id.ToString()+"&zgbh="+_zgbh.ToString();
				Response.Redirect(_URL);
			}
			else
			{
				SaveData();
				string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=4&step_id="+step_id.ToString()+"&doc_id="+doc_id.ToString()+"&zgbh="+_zgbh.ToString();
				Response.Redirect(_URL);
			}
		}

		//----------------------------------------------tonzoc-2010.01.12------------------------------------------

		/// <summary>
		/// 判断所提交请假时间是否与已有请假有重叠部分，是返回true，否返回false
		/// </summary>
		/// <returns></returns>
		bool getQjspCf()
		{
			string connString = StokeGlobals.Connectiondsoc; 
			SqlConnection conn = new SqlConnection(connString);
			conn.Open();
			string str = "select qjsp_kssj, qjsp_jssj from rs_flow_qjsp_cfts where qjsp_zgbh='" + _zgbh + "'";
			SqlDataAdapter  da=new SqlDataAdapter(str,conn);
			DataTable dt1=new DataTable();
			da.Fill(dt1);
			conn.Close();

			bool flag = false;

			for (int i = 0; i < dt1.Rows.Count; i++)
			{
				DateTime kssjLimit = getDateTimeFromString(dt1.Rows[i][0].ToString());
				DateTime jssjLimit = getDateTimeFromString(dt1.Rows[i][1].ToString());
				DateTime kssj = getDateTimeFromString(g.Text.Trim());
				DateTime jssj = getDateTimeFromString(h.Text.Trim());

				if (kssj >= kssjLimit && kssj <= jssjLimit || jssj >= kssjLimit && jssj <= jssjLimit || kssj <= kssjLimit && jssj >= jssjLimit)
				{
					flag = true;
					break;
				}
			}

			return flag;
		}

		//针对请假审批中的特定时间格式，如 2010-01-09 08
		DateTime getDateTimeFromString(string datetime)
		{
			string year = datetime.Substring(0, 4);
			string month = datetime.Substring(5, 2);
			string date = datetime.Substring(8, 2);
			string hour = datetime.Substring(11, 2);
			string test = string.Format("{0}-{1}-{2} {3}:0:0", year, month, date, hour);
			return DateTime.Parse(test);
		}
		//---------------------------------------------------------------------------------------------------------


		
		private   static   int   CompareStrings(   string   str1,   string   str2   )   
		{   
    
			//   compare   the   values,   using   the   CompareTo   method   on   the   first   string   
			int   cmpVal   =   str1.CompareTo(str2);   
    
			/*if   (cmpVal   ==   0)   //   the   values   are   the   same   
				return   "The   strings   have   the   same   value!";   
    
			else   if   (cmpVal   >   0)   //   the   first   value   is   greater   than   the   second   value   
				return   "The   first   string   is   greater   than   the   second   string!";   
                            
			else   //   the   second   string   is   greater   than   the   first   string   
				return   "The   second   string   is   greater   than   the   first   string!";*/   
			return cmpVal;
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
				doc_id = df.AddDocument(_zgbh,flow_id,mySql,a.Text.ToString().Trim()+"请假申请");
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
				Stoke.Components.Staff.DeleteQjsp_cfts(_zgbh, g.Text.Trim(), h.Text.Trim());
				Response.Redirect("../Workflow/Work_Manage.aspx");
			}
			else if(step_id==0)
				//Response.Redirect("../Workflow/Work_Record.aspx");
				Response.Redirect(ViewState["retu"].ToString());
			else if(step_id==-2)
				Response.Redirect("qj_xj_manage.aspx");
			else 
				Response.Redirect("../Workflow/Work_Manage.aspx");
		}

		private void h_TextChanged(object sender, System.EventArgs e)
		{
		}

		public void SaveToQjsp()
		{
			string qjsp_zgbh = this.i1.Text;
			string qjsp_xm = this.a.Text;
			string qjsp_bm = this.b.SelectedValue;
			string qjsp_zw = this.c.SelectedValue;
			string qjsp_cssj = this.d.Text;

			string qjsp_gssj = this.e.Text;

			string qjsp_qjlb = this.f.SelectedValue;

			string qjsp_kssj = this.g.Text;

			string qjsp_jssj = this.h.Text;
			string qjsp_qjts ="";
			if(this.i.Text != "")
				qjsp_qjts =this.i.Text;
			string qjsp_gzr = "";
			if(this.j.Text != "")
				qjsp_gzr =this.j.Text;
			string qjsp_qjsy = this.k.Text;
			string qjsp_dlr = this.l.Text;
			string qjsp_qjrq = this.n.Text;
			string qjsp_kqzrr = this.o.Text;
			string qjsp_kqzrr_rq = this.p.Text;
			string qjsp_bmfzr = this.q.Text;
			string qjsp_bmfzr_rq = this.r.Text;

			int qjsp_jhts = 0;
			if(this.s.Text != "")
				qjsp_jhts = Convert.ToInt32(this.s.Text);
			int qjsp_yxts = 0;
			if(this.t.Text != "")
				qjsp_yxts = Convert.ToInt32(this.t.Text);
			int qjsp_bcts = 0;
			if(this.u.Text != "")
				qjsp_bcts = Convert.ToInt32(this.u.Text);

//			int qjsp_jhts = Convert.ToInt32(this.s.Text);
//			int qjsp_yxts = Convert.ToInt32(this.t.Text);
//			int qjsp_bcts = Convert.ToInt32(this.u.Text);
			string qjsp_lxdh = this.a1.Text;
			string qjsp_qt = this.b1.Text;
			string qjsp_zhglbjbr = this.c1.Text;
			string qjsp_zhglbjbr_rq = this.d1.Text;
			string qjsp_gszgld = this.e1.Text;
			string qjsp_gszgld_rq = this.f1.Text;
			string qjsp_zjlsp = this.g1.Text;
			string qjsp_zjlsp_rq = this.h1.Text;
			int ret = Stoke.Components.Staff.InsertQjsp(qjsp_zgbh,
				qjsp_xm,
				qjsp_bm,
				qjsp_zw,
				qjsp_cssj,
				qjsp_gssj,
				qjsp_qjlb,
				qjsp_kssj,
				qjsp_jssj ,
				qjsp_qjts,
				qjsp_gzr,
				qjsp_qjsy,
				qjsp_dlr ,
				qjsp_qjrq,
				qjsp_kqzrr,
				qjsp_kqzrr_rq ,
				qjsp_bmfzr,
				qjsp_bmfzr_rq ,
				qjsp_jhts,
				qjsp_yxts,
				qjsp_bcts,
				qjsp_lxdh,
				qjsp_qt ,
				qjsp_zhglbjbr,
				qjsp_zhglbjbr_rq,
				qjsp_gszgld  ,
				qjsp_gszgld_rq  ,
				qjsp_zjlsp ,
				qjsp_zjlsp_rq,doc_id);
			if(f.SelectedValue=="年假")
			{
				try
				{
					string xm=this.a.Text;
					string bm=this.b.SelectedValue;
					string zw=bm+"/"+this.c.SelectedValue;
					int yxts = int.Parse(this.t.Text) + int.Parse(this.j.Text);
					int syts = int.Parse(this.s.Text) - yxts;
					int jhts=int.Parse(this.s.Text);
					Stoke.Components.Staff.UpdateNjjhByZgbh(this.i1.Text,int.Parse((g.Text).Substring(0,4)),jhts,yxts,syts,xm,bm,zw);
				}
				catch
				{}
			}
		}

		private void t_TextChanged(object sender, System.EventArgs e)
		{
//			this.r.Text = Convert.ToString(int.Parse(this.s.Text) - int.Parse(this.t.Text));
		}

		private void btn_add_Click(object sender, System.EventArgs e)
		{
			if(doc_id>0)
			{
				Stoke.Components.Staff.InsertInfo_to_wtspnr
					(doc_id,
					this.txt_gznr.Text.ToString(),
					this.txt_bwtr.Text.ToString(),
					this.txt_bz.Text.ToString()
					);
				DataTable dt=Stoke.Components.Staff.SelectWtspnrById(doc_id);
				this.DataGrid1.DataSource=dt;
				for(int i=dt.Rows.Count;i<DataGrid1.PageCount * DataGrid1.PageSize;i++)
					dt.Rows.Add(dt.NewRow());
				this.DataGrid1.DataBind();
			}
			else
			{
				Stoke.Components.Staff.InsertInfo_to_wtsp_temp
					(_zgbh,
					this.txt_gznr.Text.ToString(),
					this.txt_bwtr.Text.ToString(),
					this.txt_bz.Text.ToString()
					);
				DataTable dt=Stoke.Components.Staff.GetAll_wtsp_temp(_zgbh);
				this.DataGrid1.DataSource=dt;
				for(int i=dt.Rows.Count;i<DataGrid1.PageCount * DataGrid1.PageSize;i++)
					dt.Rows.Add(dt.NewRow());
				this.DataGrid1.DataBind();
			}
			this.txt_gznr.Text = "";
			this.txt_bwtr.Text = "";
			this.txt_bz.Text = "";
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item||e.Item.ItemType == ListItemType.AlternatingItem)
			{
				if(e.Item.Cells[1].Text=="&nbsp;")
				{
					e.Item.Cells[0].Controls[0].Visible = false;
					e.Item.Cells[5].Controls[0].Visible = false;
				}
			}
			if(step_id!=1)
				e.Item.Cells[5].Visible = false;
			else if(step_id==1&&doc_id>0)
				e.Item.Cells[5].Visible = true;
		}

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(doc_id>0)
			{
				int _xh=Convert.ToInt32(e.Item.Cells[1].Text);
				Stoke.Components.Staff.DeleteInfoFromWtsp(_xh);
				DataTable dt=Stoke.Components.Staff.SelectWtspnrById(doc_id);
				this.DataGrid1.DataSource=dt;
				for(int i=dt.Rows.Count;i<DataGrid1.PageSize;i++)
					dt.Rows.Add(dt.NewRow());
				this.DataGrid1.DataBind();
			}
			else
			{
				int _xh=Convert.ToInt32(e.Item.Cells[1].Text);
				Stoke.Components.Staff.DeleteInfo_from_wtsp_temp(_xh);
				DataTable dt=Stoke.Components.Staff.GetAll_wtsp_temp(_zgbh);
				this.DataGrid1.DataSource=dt;
				for(int i=dt.Rows.Count;i<this.DataGrid1.PageSize;i++)
					dt.Rows.Add(dt.NewRow());
				this.DataGrid1.DataBind();	
			}
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btn_y_Click(object sender, System.EventArgs e)
		{
			Stoke.Components.Staff.InsertQjsp_cfts(_zgbh, g.Text.Trim(), h.Text.Trim());

			SaveData();
			Stoke.Components.Staff.InsertWtspnrById(doc_id,this.i1.Text.Trim());
			string _URL = "../Workflow/Work_Next_Step.aspx?flow_id=4&step_id="+step_id.ToString()+"&doc_id="+doc_id.ToString()+"&zgbh="+_zgbh.ToString();
			Response.Redirect(_URL);
		}

		private void btn_n_Click(object sender, System.EventArgs e)
		{
			tishi.Visible = false;
		}

		//---------------------------tonzoc-2.24-----------------------------------
		private void bindNj()
		{
			int njjh;
			int yxts;
			int syts;
//			DataTable dt = Stoke.Components.Staff.GetJbdwsj(_zgbh);
//
//			int row = dt.Rows.Count;
//
//			if (dt.Rows[0]["cjgzsj"].ToString() == string.Empty)
//			{
//				s.Text = string.Empty;
//				t.Text = string.Empty;
//				u.Text = string.Empty;
//				return;
//			}
//
//			DateTime cjgzsj = Convert.ToDateTime(dt.Rows[0]["cjgzsj"]);
//
//			if (cjgzsj.AddYears(11) > DateTime.Now)
//			{
//				njjh = 5;
//			}
//			else if (cjgzsj.AddYears(16) > DateTime.Now)
//			{
//				njjh = 10;
//			}
//			else
//			{
//				njjh = 15;
//			}

			string ry_zgbh = step_id == 1 ? _zgbh : this.i1.Text.Trim();

			DataTable dt = Stoke.Components.Staff.GetNjjhByZgbh(ry_zgbh, DateTime.Now.Year);
			if (dt.Rows.Count != 0)
			{
				njjh = Convert.ToInt32(dt.Rows[0]["njjh"]);
				yxts = Convert.ToInt32(dt.Rows[0]["yxts"]);
			}
			else
			{
				njjh = 0;
				yxts = 0;
			}
//			syts = njjh > yxts ? njjh - yxts : 0;
			syts = njjh - yxts;
			
			s.Text = njjh.ToString();
			t.Text = yxts.ToString();
			u.Text = syts.ToString();
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
			if(doc_id>0)
			{
				DataTable dt=Stoke.Components.Staff.SelectWtspnrById(doc_id);
				this.DataGrid1.DataSource=dt;
				for(int i=dt.Rows.Count;i<DataGrid1.PageCount * DataGrid1.PageSize;i++)
					dt.Rows.Add(dt.NewRow());
				this.DataGrid1.DataBind();
			}
			else
			{
				DataTable dt=Stoke.Components.Staff.GetAll_wtsp_temp(_zgbh);
				this.DataGrid1.DataSource=dt;
				for(int i=dt.Rows.Count;i<DataGrid1.PageCount * DataGrid1.PageSize;i++)
					dt.Rows.Add(dt.NewRow());
				this.DataGrid1.DataBind();
			}
		}

		private void njModifyBtn_Click(object sender, System.EventArgs e)
		{
			string ry_zgbh = this.i1.Text.Trim();
			int nj_year = Convert.ToInt32(this.g.Text.Substring(0, 4));
			int njjh = Convert.ToInt32(this.s.Text.Trim());
			int yxts = Convert.ToInt32(this.t.Text.Trim());
			int syts = Convert.ToInt32(this.u.Text.Trim());

			Stoke.Components.Staff.handNjxx(ry_zgbh, njjh, yxts, syts, nj_year);
			Stoke.Components.Staff.Nj_tongji();
			this.bindNj();
		}


		//------------------------------------------------------------------------------------------
	}
}
