using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VS2012.WinForm.ValidateCode
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnResolveImage_Click(object sender, EventArgs e)
        {
            picOriginalCode.ImageLocation = txtImagePath.Text;
        }

      
        private void picOriginalCode_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var analysis = new unCodeAiYing((Bitmap)picOriginalCode.Image);
            var grayBimmap = analysis.GetGrayBitmapByPixels();
            picGrayCode.Image = grayBimmap;
            picOriginalCode.Image.Save(@"image\" + (++Common.Count) + "_src.jpg");
            grayBimmap.Save(@"image\" + Common.Count + "_gray.jpg");
        
            var dgGrayValue = analysis.GetDgGrayValue();
            analysis.GetPicValidByValue(dgGrayValue, 4); //得到有效空间
            Bitmap[] pics =analysis.GetSplitPics(4, 1);     //分割
            pictureBox1.Image = pics[0];
            pictureBox2.Image = pics[1];
            pictureBox3.Image = pics[2];
            pictureBox4.Image = pics[3];
        }
   
    }
}
