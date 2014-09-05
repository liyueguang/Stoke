using System;
using System.IO;

namespace Stoke.Components
{
    /// <summary>
    /// AttachFile ��ժҪ˵����
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
            //�ļ���
            get { return fileName; }
            set { fileName = value; }
        }

        public string FileNameRq
        {
            //�����ڱ�ʾ���ļ���
            get { return fileNameRq; }
            set { fileNameRq = value; }
        }

        public int FileLength
        {
            //�ļ�����
            get { return fileLength; }
            set { fileLength = value; }
        }


        public Stream StreamObject
        {
            //�ļ��ֽ���
            get { return streamObject; }
            set { streamObject = value; }
        }
        public string FileType
        {
            //�ļ���
            get { return fileType; }
            set { fileType = value; }
        }

    }
}
