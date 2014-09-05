using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Office.Interop.Word;

/// <summary>
/// WordAction 的摘要说明
/// </summary>
public class WordAction
{
	public WordAction()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static void SaveAsWord(string fileName, string pFileName)//使用原生方法将mht转换为word文档，不是那种直接修改后缀名的方式
    {
        object missing = System.Reflection.Missing.Value;
        object readOnly = false;
        object isVisible = true;
        object file1 = fileName;
        object html1 = pFileName;
        object format = WdSaveFormat.wdFormatDocument;
        ApplicationClass oWordApp = new ApplicationClass();
        oWordApp.Visible = false;
        Document oWordDoc = oWordApp.Documents.Open(ref   file1, ref   format, ref   readOnly, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref missing);
        oWordApp.ActiveWindow.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdPrintView;  //将web视图修改为默认视图，不然打开word的时候会以web视图去展示，而不是默认视图。（唯独这句代码是自己加的 = =|||）
        oWordDoc.SaveAs(ref   html1, ref   format, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing, ref   missing);
        oWordDoc.Close(ref     missing, ref     missing, ref     missing);
        oWordDoc = null;
        oWordApp.Application.Quit(ref   missing, ref   missing, ref   missing);
        oWordApp = null;
        killAllProcess();

    }
    protected static void killAllProcess() // 杀掉所有winword.exe进程
    {
        System.Diagnostics.Process[] myPs;
        myPs = System.Diagnostics.Process.GetProcesses();
        foreach (System.Diagnostics.Process p in myPs)
        {
            if (p.Id != 0)
            {
                string myS = "WINWORD.EXE" + p.ProcessName + "  ID:" + p.Id.ToString();
                try
                {
                    if (p.Modules != null)
                        if (p.Modules.Count > 0)
                        {
                            System.Diagnostics.ProcessModule pm = p.Modules[0];
                            myS += "\n Modules[0].FileName:" + pm.FileName;
                            myS += "\n Modules[0].ModuleName:" + pm.ModuleName;
                            myS += "\n Modules[0].FileVersionInfo:\n" + pm.FileVersionInfo.ToString();
                            if (pm.ModuleName.ToLower() == "winword.exe")
                                p.Kill();
                        }
                }
                catch
                { }
                finally
                {
                }
            }
        }
    }
}
