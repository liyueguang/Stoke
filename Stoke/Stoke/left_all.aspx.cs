using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Stoke
{
    public partial class left_all : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string Zgbh = Convert.ToString(Session["zgbh"]);
                //				SqlConnection mycn=new SqlConnection(dsoc.COMMON.dsocGlobals.Connectiondsoc);
                //				mycn.Open() ;
                DataTable tb = new DataTable();
                Stoke.Components.xtqx _xtbll = new Stoke.Components.xtqx();
                tb = _xtbll.Gettreebyzgbh(Zgbh);
                TreeView1.Height = 480; //TreeView1 Ϊ�����ж�������οؼ�
                TreeView1.Width = 192;
                LoadTree(TreeView1, tb); //�������Ͳ˵�
                //				mycn.Close();
                //				mycn.Dispose();

            }
        }

        public void LoadTree(TreeView tv, DataTable tb)
        {
            //ͨ������Filltree ������ʵ�ּ������Ͳ˵�,�˵����������ݱ�tb ��
            try
            {
                if (tb != null)
                {
                    int i = 0;
                    tv.Nodes.Clear();
                    FillTree(tv.Nodes, tb, ref i);
                }
                else
                { tv.Nodes.Clear(); }
            }
            catch
            { throw; }
        }
        private void FillTree(TreeNodeCollection Nodes, DataTable dt, ref int i)
        {
            if (i >= dt.Rows.Count) return;
            string k = dt.Rows[i]["NodeKey"].ToString().Trim();
            int len = k.Length;
            while (i < dt.Rows.Count)
            {
                string k1 = dt.Rows[i]["NodeKey"].ToString().Trim();
                int len1 = k1.Length;


                if (len1 == len)
                {
                    TreeNode  t = new TreeNode();
                    t.Text = dt.Rows[i]["NodeName"].ToString().Trim();

                    //t.Expanded=true;
                    //if(i==0)
                    if (dt.Rows[i]["NodeLeaf"].ToString().Trim() == "0")
                    {
                        //t.Expanded=true;
                        if (dt.Rows[i]["NodeKey"].ToString().Trim() != "01")
                        {
                            string _node = dt.Rows[i]["NodeKey"].ToString().Substring(0, 4);
                            switch (_node.ToString())
                            {
                                case "0101": t.ImageUrl = "images/person2.gif";//���Ƶ�һ������ʾͼ��
                                    //t.ExpandedImageUrl = "images/admin_ico2.gif";
                                    break;
                                case "0102": t.ImageUrl = "images/admin_ico4.gif";
                                    //t.ExpandedImageUrl = "images/p_more2.gif";
                                    break;
                                case "0103": t.ImageUrl = "images/gw.gif";
                                    //t.ExpandedImageUrl = "images/ogw.gif";
                                    break;
                                case "0104":
                                    t.ImageUrl = "images/admin_ico4.gif";
                                    //t.ExpandedImageUrl = "images/p_more2.gif";
                                    break;
                                //								case "0105": t.ImageUrl="images/xin.jpg";
                                //									//t.ExpandedImageUrl="images/root.gif";
                                //									break;

                                case "0106": t.ImageUrl = "images/icon/191.gif";
                                    //t.ExpandedImageUrl = "images/icon/255.gif";
                                    break;

                                case "0109": t.ImageUrl = "images/icon/118.gif";
                                    //t.ExpandedImageUrl = "images/icon/118.gif";
                                    break;

                                case "0111": t.ImageUrl = "images/gzjk.ico";
                                    //t.ExpandedImageUrl = "images/gzl.ico";
                                    break;

                                case "0112": t.ImageUrl = "images/043_S.ico";
                                    //t.ExpandedImageUrl = "images/dbsx.ico";
                                    break;

                                case "0108": t.ImageUrl = "images/xjgz.ico";
                                    //t.ExpandedImageUrl = "images/root.gif";
                                    break;
                                case "0114": t.ImageUrl = "images/wj.gif";
                                    //t.ExpandedImageUrl = "images/owj.gif";
                                    break;
                                case "0115": t.ImageUrl = "images/wdk.gif";
                                    //t.ExpandedImageUrl = "images/owdk.gif";
                                    break;

                            }
                        }




                        string NodeKey = dt.Rows[i]["NodeKey"].ToString().Trim();
                        switch (NodeKey.ToString())
                        {
                            case "01": t.ImageUrl = "images/MyDoc.gif";
                                //t.ExpandedImageUrl = "images/MyDoc.gif";

                                break;
                            case "0101": t.ImageUrl = "images/admin_ico4.gif";//���Ƹ������ͼ��
                                //t.ExpandedImageUrl = "images/admin_ico2.gif";
                                break;

                            case "0102": t.ImageUrl = "images/icon/273.gif";
                                //t.ExpandedImageUrl = "images/person.gif";
                                break;

                            case "0104": t.ImageUrl = "images/admin_ico2.gif";
                                //t.ExpandedImageUrl = "images/person.gif";
                                break;
                            case "0106": t.ImageUrl = "images/book.gif";
                                //t.ExpandedImageUrl = "images/bookopen.gif";
                                break;

                            case "0109": t.ImageUrl = "images/icon/118.GIF";
                                //t.ExpandedImageUrl = "images/icon/118.gif";
                                break;

                            case "0111": t.ImageUrl = "images/gzjk.ico";
                                //t.ExpandedImageUrl = "images/gzl.ico";
                                break;

                            case "0112": t.ImageUrl = "images/043_S.ico";
                                //t.ExpandedImageUrl = "images/dbsx.ico";
                                break;

                            case "0108": t.ImageUrl = "images/xjgz.ico";
                                //t.ExpandedImageUrl = "images/root.gif";
                                break;
                        }

                    }
                    if (i == 0)
                    {
                        t.Expanded = true;
                        t.ImageUrl = "images/MyDoc.gif";
                    }
                    //t.CheckBox=true;
                    //t.ImageUrl="images/book.gif";

                    if (dt.Rows[i]["NodeLeaf"].ToString() == "1")
                    {
                        t.NavigateUrl = dt.Rows[i]["NodeFrameName"].ToString().Trim();// �ýڵ�ĵ�����ַ
                        t.Target = "rightMain";
                        //t.Expanded=true;
                        //t.ExpandedImageUrl=/images/b38.jpg;
                        t.ImageUrl = "images/ngx.ico";
                        //t.ImageUrl="images/sfw.ico";
                        string _node = dt.Rows[i]["NodeKey"].ToString().Substring(0, 4);
                        switch (_node.ToString())
                        {
                            case "0101": t.ImageUrl = "images/person2.gif";//����Ҷ�ӽڵ��ͼ��

                                break;
                            case "0102": t.ImageUrl = "images/icon/273.gif";
                                break;
                            case "0103": t.ImageUrl = "images/gwyz.gif";
                                break;

                            case "0104": t.ImageUrl = "images/admin_ico2.gif";

                                break;
                            case "0106": t.ImageUrl = "images/book.gif";

                                break;

                            case "0109": t.ImageUrl = "images/person.gif";
                                ;
                                break;

                            case "0111": t.ImageUrl = "images/gzjk.ico";

                                break;

                            case "0112": t.ImageUrl = "images/043_S.ico";

                                break;

                            case "0108": t.ImageUrl = "images/xjgz.ico";

                                break;
                            case "0114": t.ImageUrl = "images/wjyz.gif";

                                break;
                            case "0115": t.ImageUrl = "images/owj.gif";

                                break;

                        }

                    }
                    Nodes.Add(t);
                    i++;
                }
                else
                {
                    if (len1 > len)
                    {
                        //���õ�ǰ�����ڵ�,������һ�εݹ����
                        TreeNode t = Nodes[Nodes.Count - 1];
                        FillTree(t.ChildNodes, dt, ref i);//�ݹ����ֱ�����Ͳ˵�ȫ������ʾ����
                    }
                    else
                    { return; }
                }
            }
        }
    }
}
