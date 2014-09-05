using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

/// <summary>
/// Function 的摘要说明
/// </summary>
public class Function
{
    public Function()
    {
        //根据html生成mht文件，需要引入相应的dll
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static void HtmlToMht(string src, string dst)
    {
        CDO.Message msg = new CDO.MessageClass();
        CDO.Configuration c = new CDO.ConfigurationClass();
        msg.Configuration = c;
        msg.CreateMHTMLBody(src, CDO.CdoMHTMLFlags.cdoSuppressNone, "", "");
        ADODB.Stream stream = msg.GetStream();
        stream.SaveToFile(dst, ADODB.SaveOptionsEnum.adSaveCreateOverWrite);
        stream.Close();
    }

    public static void WriteHtml(string RepID, string ShareID, string ShareName, string Company, string Author, string RepName, string RepContent, string RepDate, string RepDesc)
    {
        string spath = HttpContext.Current.Server.MapPath("");
        string datestr = DateTime.Now.ToString("yyyyMMddHHmmss");
        string Temp_Name = spath + "\\Articles.html";  //HTML模板的路径
        string File_Name = spath + "\\html\\" + RepName + datestr + ".html";//生成html文件的路径
        string File_NameM = spath + "\\html\\" + RepName + datestr + ".mht";//生成mht文件的路径
        string File_Name2 = spath + "\\html\\" + RepName + datestr.Substring(0,6) + ".doc";//生成Word文档的路径

        StreamReader sr = new StreamReader(Temp_Name);
        StringBuilder htmltext = new StringBuilder();
        String line;
        while ((line = sr.ReadLine()) != null)
        {
            htmltext.Append(line);//读取到html模板的内容
        }
        sr.Close();

        //替换相应的内容到指定的位置
        htmltext = htmltext.Replace("$htmldata[1]", RepName);
        htmltext = htmltext.Replace("$htmldata[2]", ShareName);
        htmltext = htmltext.Replace("$htmldata[3]", ShareID);
        htmltext = htmltext.Replace("$htmldata[4]", RepID);
        htmltext = htmltext.Replace("$htmldata[5]", Company);
        htmltext = htmltext.Replace("$htmldata[6]", RepName);
        htmltext = htmltext.Replace("$htmldata[7]", RepDesc);
        htmltext = htmltext.Replace("$htmldata[8]", RepContent);
        htmltext = htmltext.Replace("$htmldata[9]", Company);
        htmltext = htmltext.Replace("$htmldata[10]", Author);
        htmltext = htmltext.Replace("$htmldata[11]", RepDate);

        using (StreamWriter sw = new StreamWriter(File_Name, false, System.Text.Encoding.GetEncoding("UTF-8"))) //保存地址
        {
            //生成HTML文件
            sw.WriteLine(htmltext);
            sw.Flush();
            sw.Close();
        }
        HtmlToMht(File_Name, File_NameM);//因为带图片的html直接转为Word的话，图片会以引用的形式展示（也就是说不是内置到word文档里去的，一旦断网或将图片放在别的路径之后，打开word文档图片会显示不出来，所以通过折冲的办法先生成html，然后转换为mht，再转为word）
        WordAction.SaveAsWord(File_NameM, File_Name2);  //生成word
        if (File.Exists(File_NameM))
        {
            File.Delete(File_NameM);
        }
    }
}
