using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
namespace VS2010.WinForm.BatchFileReplace
{
    public partial class Form1 : Form
    {
        private string srcDirectoryPath = "";
        private string desDirectoryPath = "";
        private string searchContent = "";
        private string replaceContent = "";
        private bool enabledSubDirectoryReplace = false;
        private int highestPercentageReached = 0;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 开始替换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            srcDirectoryPath = txtSrcDirectoryPath.Text.Trim();
            desDirectoryPath = txtDesDirectoryPath.Text.Trim();
            if (string.IsNullOrEmpty(srcDirectoryPath.Trim()))
            {
                MessageBox.Show("请选择要替换文件的目录!");
                return;
            }
            else if (string.IsNullOrEmpty(srcDirectoryPath.Trim()))
            {
                MessageBox.Show("请选择替换文件后的存放目录!");
                return;
            }
            enabledSubDirectoryReplace = chkSubDirectoryReplace.Checked;
            //enabledRegPatten = chkRegPatten.Checked;
            searchContent = rtxtSearchContent.Text.Trim();
            replaceContent = rtxtReplaceContent.Text.Trim();
            if (string.IsNullOrEmpty(searchContent))
            {
                MessageBox.Show("搜索内容不能为空");
                return;
            }
            if (string.IsNullOrEmpty(replaceContent))
            {
                MessageBox.Show("替换内容不能为空");
                return;
            }
            button1.Enabled = false;
            button4.Enabled = true;
            backgroundWorker1.RunWorkerAsync();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtSrcDirectoryPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
            txtDesDirectoryPath.Text = folderBrowserDialog2.SelectedPath;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                int completeNumbers = 0;
                int fileTotalNumbers = 0;
                if (enabledSubDirectoryReplace)
                {

                    RecursionSubDirFileNumbers(ref fileTotalNumbers, srcDirectoryPath);
                    RecursionSubDirReplace(ref completeNumbers, ref fileTotalNumbers, srcDirectoryPath);
                }
                else
                {
                    FileInfo[] files = new DirectoryInfo(srcDirectoryPath).GetFiles();
                    fileTotalNumbers = files.Length;
                    ReplaceFileContent(desDirectoryPath, ref completeNumbers, ref fileTotalNumbers, files);
                }
            }
        }
        /// <summary>
        /// 递归统计目录以及子目录中的所有文件数
        /// </summary>
        /// <param name="srcDirectoryPath"></param>
        private void RecursionSubDirFileNumbers(ref int fileTotalNumbers, string srcDirectoryPath)
        {
            DirectoryInfo rootDir = new DirectoryInfo(srcDirectoryPath);
            DirectoryInfo[] dirs = rootDir.GetDirectories();
            foreach (var dir in dirs)
            {
                RecursionSubDirFileNumbers(ref fileTotalNumbers, dir.FullName);
            }
             fileTotalNumbers += rootDir.GetFiles().Length;

        }
        /// <summary>
        /// 递归替换目录以及子目录的所有文件
        /// </summary>
        /// <param name="rootDirectoryPath"></param>
        private void RecursionSubDirReplace(ref int completeNumbers, ref int fileTotalNumbers, string rootDirectoryPath)
        {
            DirectoryInfo rootDir = new DirectoryInfo(rootDirectoryPath);
            DirectoryInfo[] dirs = rootDir.GetDirectories();
            foreach (var dir in dirs)
            {
                RecursionSubDirReplace(ref completeNumbers, ref fileTotalNumbers, dir.FullName);
            }
            //当前目录
            string   currentDirPath=rootDir.FullName;
            //将源根目录路径替换为目标根目录路径
            string  desDirPath = currentDirPath.Replace(srcDirectoryPath, desDirectoryPath);
            //如果当前目录不是源根目录则在目录根目录中创建子目录
            if (currentDirPath != srcDirectoryPath)
            {
                //创建子目录
                Directory.CreateDirectory(desDirPath);
            }
            FileInfo[] files = rootDir.GetFiles();
            ReplaceFileContent(desDirPath, ref completeNumbers, ref fileTotalNumbers, files);
        }
        /// <summary>
        /// 替换文件内容
        /// </summary>
        /// <param name="completeNumbers"></param>
        /// <param name="fileTotalNumbers"></param>
        private void ReplaceFileContent(string desSubDirectoryPath, ref int completeNumbers, ref int fileTotalNumbers, FileInfo[] files)
        {
            foreach (var fileInfo in files)
            {
                using (StreamReader read = new StreamReader(new FileStream(fileInfo.FullName, FileMode.Open), Encoding.GetEncoding("gb2312")))
                {
                    string srcContent = read.ReadToEnd();
                    string result = srcContent.Replace(searchContent, replaceContent);
                    using (StreamWriter write = new StreamWriter(new FileStream(desSubDirectoryPath + "\\" + fileInfo.Name, FileMode.Create), Encoding.UTF8))
                    {
                        write.Write(result);
                    }
                    completeNumbers++;
                    int percentComplete = (int)((float)completeNumbers / (float)fileTotalNumbers * 100);
                    if (percentComplete > highestPercentageReached)
                    {
                        highestPercentageReached = percentComplete;
                        backgroundWorker1.ReportProgress(percentComplete);
                    }
                }

            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                lblShowResult.Text = "文件替换已取消";
            }
            else
            {
                lblShowResult.Text = "文件替换已完成";
            }
            button1.Enabled = true;
            button4.Enabled = false;
        }
        /// <summary>
        /// 取消文件替换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            button4.Enabled = false;
        }
    }
}
