using System;
using System.IO;

namespace Stoke.Components
{
    /// <summary>
    /// AttachFile 的摘要说明。
    /// </summary>
    public class AttachFile
    {
        private string fileName;
        private string fileNameRq;
        private int fileLength;
        private Stream streamObject;
        private string fileType;

        public string FileName
        {
            //文件名
            get { return fileName; }
            set { fileName = value; }
        }

        public string FileNameRq
        {
            //带日期标示的文件名
            get { return fileNameRq; }
            set { fileNameRq = value; }
        }

        public int FileLength
        {
            //文件长度
            get { return fileLength; }
            set { fileLength = value; }
        }


        public Stream StreamObject
        {
            //文件字节流
            get { return streamObject; }
            set { streamObject = value; }
        }
        public string FileType
        {
            //文件名
            get { return fileType; }
            set { fileType = value; }
        }

    }
}
