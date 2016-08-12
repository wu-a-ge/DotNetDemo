using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;

namespace VS2008.WindowsService.Test
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            System.Timers.Timer t = new System.Timers.Timer(2000);//实例化Timer类，设置间隔时间为10000毫秒；    
            t.Elapsed += new System.Timers.ElapsedEventHandler(TimeElapse);//到达时间的时候执行事件；    
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；    
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；   
        }
        public void TimeElapse(object source, System.Timers.ElapsedEventArgs e)
        {

            Process[] processes = Process.GetProcessesByName("VS2008.ConsoleApp.Test");
            if (processes.Length != 0)
            {
                FileStream fs = new FileStream(@"d:/timetick.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                m_streamWriter.WriteLine("禁止了进程，其PID为 " + processes[0].ProcessName + "/n");
                m_streamWriter.Flush();
                m_streamWriter.Close();
                fs.Close();
                processes[0].Kill();
            }
           

        }  
        protected override void OnStart(string[] args)
        {
           
            EventLog.WriteEntry("测试服务启动了");
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("测试服务停止了");
        }
    }
}
