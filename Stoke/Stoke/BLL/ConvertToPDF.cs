﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;

/// <summary>
/// ConvertToPDF 的摘要说明
/// </summary>
public class ConvertToPDF
{
    public ConvertToPDF()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    //Word转换成pdf
    /// <summary>
    /// 把Word文件转换成为PDF格式文件
    /// </summary>
    /// <param name="sourcePath">源文件路径</param>
    /// <param name="targetPath">目标文件路径</param>
    /// <returns>true=转换成功</returns>
    public static bool DOCConvertToPDF(string sourcePath, string targetPath)
    {
        bool result = false;
        Word.WdExportFormat exportFormat = Word.WdExportFormat.wdExportFormatPDF;
        object paramMissing = Type.Missing;
        Word.ApplicationClass wordApplication = new Word.ApplicationClass();
        Word.Document wordDocument = null;
        try
        {
            object paramSourceDocPath = sourcePath;
            string paramExportFilePath = targetPath;

            Word.WdExportFormat paramExportFormat = exportFormat;
            bool paramOpenAfterExport = false;
            Word.WdExportOptimizeFor paramExportOptimizeFor = Word.WdExportOptimizeFor.wdExportOptimizeForPrint;
            Word.WdExportRange paramExportRange = Word.WdExportRange.wdExportAllDocument;
            int paramStartPage = 0;
            int paramEndPage = 0;
            Word.WdExportItem paramExportItem = Word.WdExportItem.wdExportDocumentContent;
            bool paramIncludeDocProps = true;
            bool paramKeepIRM = true;
            Word.WdExportCreateBookmarks paramCreateBookmarks = Word.WdExportCreateBookmarks.wdExportCreateWordBookmarks;
            bool paramDocStructureTags = true;
            bool paramBitmapMissingFonts = true;
            bool paramUseISO19005_1 = false;

            wordDocument = wordApplication.Documents.Open(
            ref paramSourceDocPath, ref paramMissing, ref paramMissing,
            ref paramMissing, ref paramMissing, ref paramMissing,
            ref paramMissing, ref paramMissing, ref paramMissing,
            ref paramMissing, ref paramMissing, ref paramMissing,
            ref paramMissing, ref paramMissing, ref paramMissing,
            ref paramMissing);

            if (wordDocument != null)
                wordDocument.ExportAsFixedFormat(paramExportFilePath,
                paramExportFormat, paramOpenAfterExport,
                paramExportOptimizeFor, paramExportRange, paramStartPage,
                paramEndPage, paramExportItem, paramIncludeDocProps,
                paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
                paramBitmapMissingFonts, paramUseISO19005_1,
                ref paramMissing);
            result = true;
        }
        catch
        {
            result = false;
        }
        finally
        {
            if (wordDocument != null)
            {
                wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
                wordDocument = null;
            }
            if (wordApplication != null)
            {
                wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
                wordApplication = null;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        return result;
    }
}