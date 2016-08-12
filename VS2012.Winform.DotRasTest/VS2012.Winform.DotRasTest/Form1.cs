using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DotRas;

namespace VS2012.Winform.DotRasTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 测试拨号连接
        /// </summary>
        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                using (var rbk = new RasPhoneBook())
                {
                    //要进行拨号，首先要从指定的电话薄中读取已存在的连接实体放入集合中，不存在这个电话薄就会创建
                    rbk.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User));
                    #region
                    //如果要进行拨号的连接实体还不在电话薄中，那么就得向RasPhoneBook中添加连接实体

                    var rasEntity = RasEntry.CreateBroadbandEntry("宽带链接1",
                                            RasDevice.GetDevices().First(y => y.DeviceType == RasDeviceType.PPPoE));
                    if (!rbk.Entries.Contains(rasEntity.Name))
                        rbk.Entries.Add(rasEntity);
                    #endregion
                    using (var rasdialer = new RasDialer())
                    {
                        //rasdialer.AllowUseStoredCredentials = true;
                        rasdialer.Credentials = new NetworkCredential("02363114381", "113161");
                        rasdialer.EntryName = "宽带链接1";
                        rasdialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User);
                        rasdialer.Dial();
                        Thread.Sleep(100);
                        this.LoadConnections();
                    }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 断开网络连接
        /// </summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            ReadOnlyCollection<RasConnection> conList = RasConnection.GetActiveConnections();
            foreach (RasConnection con in conList)
            {
                con.HangUp();
            }

            this.LoadConnections();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadConnections();
        }

        /// <summary>
        /// 显示活动的连接
        /// </summary>
        private void LoadConnections()
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add("请选择一个链接...");
            foreach (RasConnection connection in RasConnection.GetActiveConnections())
            {
                this.comboBox1.Items.Add(connection.EntryName);
            }

            this.comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetAddressButton.Enabled = this.comboBox1.SelectedIndex > 0;
        }

        /// <summary>
        /// 获取IP地址信息
        /// </summary>
        private void GetAddressButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (RasConnection connection in RasConnection.GetActiveConnections())
            {
                if (connection.EntryName == this.comboBox1.SelectedItem.ToString())
                {
                    RasIPInfo ipAddresses = (RasIPInfo)connection.GetProjectionInfo(RasProjectionType.IP);
                    if (ipAddresses != null)
                    {
                        sb.AppendFormat("ClientIP:{0}\r\n", ipAddresses.IPAddress.ToString());
                        sb.AppendFormat("ServerIP:{0}\r\n", ipAddresses.ServerIPAddress.ToString());
                    }
                }
                sb.AppendLine();
            }
            MessageBox.Show(sb.ToString());
        }
    }
}
