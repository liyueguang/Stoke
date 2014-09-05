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
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.IO;

namespace Stoke.USL.Staff
{
    public partial class ImageUpload : System.Web.UI.Page
    {
        protected string ImageUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                init();
            }
        }

        protected void init()
        {
            ImageUrl = Session["imagefilename"] == null ? "sago.jpg" : "../../Attachments/" + Session["imagefilename"].ToString();
        }

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            init();
            int h = 0;
            FileStream fs = new FileStream(Server.MapPath(ImageUrl), FileMode.Open, FileAccess.Read);
            System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
            h = image.Height;
            fs.Close();
            
            string tempurl = "../../Attachments/Refined_" + Session["imagefilename"];
            int startX = int.Parse(x1.Text) * h / 400;
            int startY = int.Parse(y1.Text) * h / 400;
            int width = int.Parse(Iwidth.Text) * h / 400;
            int height = int.Parse(Iheight.Text) * h / 400;
            ImgReduceCutOut(startX, startY, width, height, Server.MapPath(ImageUrl), Server.MapPath(tempurl));
            Session["CurrentImageUrl"] = tempurl;
            Session.Remove("imagefilename");
        }

        /// <summary>
        /// 缩小裁剪图片
        /// </summary>
        /// <param name="int_Width">要缩小裁剪图片宽度</param>
        /// <param name="int_Height">要缩小裁剪图片长度</param>
        /// <param name="input_ImgUrl">要处理图片路径</param>
        /// <param name="out_ImgUrl">处理完毕图片路径</param>
        public void ImgReduceCutOut(int startX, int startY, int int_Width, int int_Height, string input_ImgUrl, string out_ImgUrl)
        {
            // ＝＝＝上传标准图大小＝＝＝
            int int_Standard_Width = 150;
            int int_Standard_Height = 150;

            int Reduce_Width = 0; // 缩小的宽度
            int Reduce_Height = 0; // 缩小的高度
            int CutOut_Width = 0; // 裁剪的宽度
            int CutOut_Height = 0; // 裁剪的高度
            int level = 100; //缩略图的质量 1-100的范围

            // ＝＝＝获得缩小，裁剪大小＝＝＝
            if (int_Standard_Height * int_Width / int_Standard_Width > int_Height)
            {
                Reduce_Width = int_Width;
                Reduce_Height = int_Standard_Height * int_Width / int_Standard_Width;
                CutOut_Width = int_Width;
                CutOut_Height = int_Height;
            }
            else if (int_Standard_Height * int_Width / int_Standard_Width < int_Height)
            {
                Reduce_Width = int_Standard_Width * int_Height / int_Standard_Height;
                Reduce_Height = int_Height;
                CutOut_Width = int_Width;
                CutOut_Height = int_Height;
            }
            else
            {
                Reduce_Width = int_Width;
                Reduce_Height = int_Height;
                CutOut_Width = int_Width;
                CutOut_Height = int_Height;
            }

            // ＝＝＝通过连接创建Image对象＝＝＝
            System.Drawing.Image oldimage = System.Drawing.Image.FromFile(input_ImgUrl);
            oldimage.Save(Server.MapPath("tepm.jpg"));
            oldimage.Dispose();

            //// ＝＝＝缩小图片＝＝＝
            //System.Drawing.Image thumbnailImage = oldimage.GetThumbnailImage(Reduce_Width, Reduce_Height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
            Bitmap bm = new Bitmap(Server.MapPath("tepm.jpg"));

            // ＝＝＝处理JPG质量的函数＝＝＝
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == "image/jpeg")
                {
                    ici = codec;
                    break;
                }

            }
            EncoderParameters ep = new EncoderParameters();
            ep.Param[0] = new EncoderParameter(Encoder.Quality, (long)level);



            // ＝＝＝裁剪图片＝＝＝
            Rectangle cloneRect = new Rectangle(startX, startY, CutOut_Width, CutOut_Height);
            PixelFormat format = bm.PixelFormat;
            Bitmap cloneBitmap = bm.Clone(cloneRect, format);

            // ＝＝＝保存图片＝＝＝
            cloneBitmap.Save(out_ImgUrl, ici, ep);
            bm.Dispose();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true)
            {
                if (FileUpload1.PostedFile.ContentLength < 10485760)
                {
                    try
                    {
                        string fileurl = FileUpload1.PostedFile.FileName;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("../../Attachments/" + fileurl));
                        Session["imagefilename"] = fileurl;
                        init();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script type=text/javascript>alert('上传失败！')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script type=text/javascript>alert('请确认操作正确且附件名称已填写！')</script>");
            }
        }
    }
}
