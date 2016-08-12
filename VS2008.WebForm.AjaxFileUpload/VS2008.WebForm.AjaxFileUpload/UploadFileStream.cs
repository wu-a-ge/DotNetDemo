using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using FSM.DotNetSSH.java.io;
namespace VS2008.WebForm.AjaxFileUpload
{
    public class UploadFileStream:InputStream
    {
        private Stream fs;

        public UploadFileStream(Stream stream)
        {
            fs = stream;
        }

        public override void Close()
        {
            fs.Close();
        }


        public override int Read(byte[] buffer, int offset, int count)
        {
            return fs.Read(buffer, offset, count);
        }

        public override bool CanSeek
        {
            get
            {
                return fs.CanSeek;
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return fs.Seek(offset, origin);
        }
    }
}
