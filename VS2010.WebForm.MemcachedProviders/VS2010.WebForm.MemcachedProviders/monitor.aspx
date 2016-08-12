<%@ Page Language="C#" %> 
<%@ Import Namespace="System" %> 
<%@ Import Namespace="System.IO" %> 
<%@ Import Namespace="System.Net" %> 
<%@ Import Namespace="System.Net.Sockets" %> 
<%@ Import Namespace="System.Collections.Generic" %> 
<%@ Import Namespace="System.Threading" %> 
<%@ Import Namespace="System.Security" %> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server"> 
/*  
 * 作者：周公  
 * 日期：2011-03-27  
 * 原文出处：http://blog.csdn.net/zhoufoxcn 或http://zhoufoxcn.blog.51cto.com  
 * 版权说明：本文可以在保留原文出处的情况下使用于非商业用途，周公对此不作任何担保或承诺。  
 * */  
      
    /// <summary> 
    /// Memcached服务器监控类  
    /// </summary> 
    public class MemcachedMonitor  
    {  
        /// <summary> 
        /// 连接Memcached的超时时间  
        /// </summary> 
        public TimeSpan ConnectionTimeout { get; set; }  
        /// <summary> 
        /// 接收Memcached返回数据的超时时间  
        /// </summary> 
        public TimeSpan ReceiveTimeout { get; set; }  
        private List<IPEndPoint> serverList;  
        public MemcachedMonitor(ICollection<IPEndPoint> list)  
        {  
            ConnectionTimeout = TimeSpan.FromSeconds(10);  
            ReceiveTimeout = TimeSpan.FromSeconds(20);  
            serverList = new List<IPEndPoint>();  
            serverList.AddRange(list);  
        }  
 
        public List<MemcachedServerStats> GetAllServerStats()  
        {  
            List<MemcachedServerStats> resultList = new List<MemcachedServerStats>();  
            foreach (IPEndPoint endPoint in serverList)  
            {  
                resultList.Add(GetServerStats(endPoint, ConnectionTimeout, ReceiveTimeout));  
            }  
            return resultList;  
        }  
 
        public static MemcachedServerStats GetServerStats(IPEndPoint ip, TimeSpan connectionTimeout, TimeSpan receiveTimeout)  
        {  
            MemcachedSocket socket = new MemcachedSocket(ip, connectionTimeout, receiveTimeout);  
            MemcachedServerStats stats = socket.GetStats();  
            return stats;  
        }  
 
        public static IPEndPoint Parse(string hostName,int port)  
        {  
            IPHostEntry host=Dns.GetHostEntry(hostName);  
            IPEndPoint endPoint = null;  
            foreach (IPAddress ip in host.AddressList)  
            {  
                if (ip.AddressFamily == AddressFamily.InterNetwork)  
                {  
                    endPoint = new IPEndPoint(ip, port);  
                    break;  
                }  
            }  
            return endPoint;  
        }  
    }  
    /// <summary> 
    /// Memcached服务器运行状态数据类，只有当IsReachable为true时获取的数据才有意义，否则表示不可访问或者Memcached挂了  
    /// </summary> 
    public class MemcachedServerStats  
    {  
        private Dictionary<string, string> results;  
        /// <summary> 
        /// 是否可访问，如果不可访问表示网络故障或者Memcached服务器Down掉了  
        /// </summary> 
        public bool IsReachable { get; set; }  
        /// <summary> 
        /// 服务器运行时间，单位秒(32u)  
        /// </summary> 
        public UInt32 Uptime { get; set; }  
        /// <summary> 
        /// 服务器当前的UNIX时间(32u)  
        /// </summary> 
        public UInt32 Time { get; set; }  
        /// <summary> 
        /// 服务器的版本号(string)  
        /// </summary> 
        public string Version { get; set; }  
        /// <summary> 
        /// 服务器当前存储的内容数量(32u)  
        /// </summary> 
        public UInt32 Curr_Items { get; set; }  
        /// <summary> 
        /// 服务器启动以来存储过的内容总数(32u)  
        /// </summary> 
        public UInt32 Total_Items { get; set; }  
        /// <summary> 
        /// 连接数量(32u)  
        /// </summary> 
        public UInt32 Curr_Connections { get; set; }  
        /// <summary> 
        /// 服务器运行以来接受的连接总数(32u)  
        /// </summary> 
        public UInt32 Total_Connections { get; set; }  
        /// <summary> 
        /// 服务器分配的连接结构的数量(32u)  
        /// </summary> 
        public UInt32 Connection_Structures { get; set; }  
        /// <summary> 
        /// 取回请求总数(32u)  
        /// </summary> 
        public UInt32 Cmd_Get { get; set; }  
        /// <summary> 
        /// 存储请求总数(32u)  
        /// </summary> 
        public UInt32 Cmd_Set { get; set; }  
        /// <summary> 
        /// 请求成功的总次数(32u)  
        /// </summary> 
        public UInt32 Get_Hits { get; set; }  
        /// <summary> 
        /// 请求失败的总次数(32u)  
        /// </summary> 
        public UInt32 Get_Misses { get; set; }  
        /// <summary> 
        /// 服务器当前存储内容所占用的字节数(64u)  
        /// </summary> 
        public UInt64 Bytes { get; set; }  
        /// <summary> 
        /// 服务器从网络读取到的总字节数(64u)  
        /// </summary> 
        public UInt64 Bytes_Read { get; set; }  
        /// <summary> 
        /// 服务器向网络发送的总字节数(64u)  
        /// </summary> 
        public UInt64 Bytes_Written { get; set; }  
        /// <summary> 
        /// 服务器在存储时被允许使用的字节总数(32u)  
        /// </summary> 
        public UInt32 Limit_Maxbytes { get; set; }  
        public IPEndPoint IPEndPoint { get; set; }  
 
        public MemcachedServerStats(IPEndPoint endpoint)  
        {  
            if (endpoint == null)  
            {  
                throw new ArgumentNullException("endpoint can't be null");  
            }  
            IPEndPoint = endpoint;  
        }  
 
        public MemcachedServerStats(IPEndPoint endpoint, Dictionary<string, string> results)  
        {  
            if (endpoint == null || results == null)  
            {  
                throw new ArgumentNullException("point and result can't be null");  
            }  
            IPEndPoint = endpoint;  
 
        }  
 
        public void InitializeData(Dictionary<string, string> results)  
        {  
            if (results == null)  
            {  
                throw new ArgumentNullException("result can't be null");  
            }  
            this.results = results;  
            Uptime = GetUInt32("uptime");  
            Time = GetUInt32("time");  
            Version = GetRaw("version");  
            Curr_Items = GetUInt32("curr_items");  
            Total_Items = GetUInt32("total_items");  
            Curr_Connections = GetUInt32("curr_connections");  
            Total_Connections = GetUInt32("total_connections");  
            Connection_Structures = GetUInt32("connection_structures");  
            Cmd_Get = GetUInt32("cmd_get");  
            Cmd_Set = GetUInt32("cmd_set");  
            Get_Hits = GetUInt32("get_hits");  
            Get_Misses = GetUInt32("get_misses");  
            Bytes = GetUInt64("bytes");  
            Bytes_Read = GetUInt64("bytes_read");  
            Bytes_Written = GetUInt64("bytes_written");  
            Limit_Maxbytes = GetUInt32("limit_maxbytes");  
        }  
 
        private string GetRaw(string key)  
        {  
            string value = string.Empty;  
            results.TryGetValue(key, out value);  
            return value;  
        }  
 
        private UInt32 GetUInt32(string key)  
        {  
            string value = GetRaw(key);  
            UInt32 uptime;  
            UInt32.TryParse(value, out uptime);  
            return uptime;  
        }  
 
        private UInt64 GetUInt64(string key)  
        {  
            string value = GetRaw(key);  
            UInt64 uptime;  
            UInt64.TryParse(value, out uptime);  
            return uptime;  
        }  
    }  
    /// <summary> 
    /// 与Memcached服务器通讯的Socket封装  
    /// </summary> 
    internal class MemcachedSocket : IDisposable  
    {  
        private const string CommandString = "stats\r\n";//发送查询Memcached状态的指令，以"\r\n"作为命令的结束  
        private const int ErrorResponseLength = 13;  
        private const string GenericErrorResponse = "ERROR";  
        private const string ClientErrorResponse = "CLIENT_ERROR ";  
        private const string ServerErrorResponse = "SERVER_ERROR ";  
        private Socket socket;  
        private IPEndPoint endpoint;  
        private BufferedStream bufferedStream;  
        private NetworkStream networkStream;  
 
        public MemcachedSocket(IPEndPoint ip, TimeSpan connectionTimeout, TimeSpan receiveTimeout)  
        {  
            if (ip == null)  
            {  
                throw new ArgumentNullException("ip", "不能为空！");  
            }  
            endpoint = ip;  
 
            socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);  
 
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, connectionTimeout == TimeSpan.MaxValue ? Timeout.Infinite : (int)connectionTimeout.TotalMilliseconds);  
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, receiveTimeout == TimeSpan.MaxValue ? Timeout.Infinite : (int)receiveTimeout.TotalMilliseconds);  
 
            // all operations are "atomic", we do not send small chunks of data  
            socket.NoDelay = true;  
        }  
        /// <summary> 
        /// 获取Memcached的运行状态  
        /// </summary> 
        /// <returns></returns> 
        public MemcachedServerStats GetStats()  
        {  
            MemcachedServerStats stats = new MemcachedServerStats(endpoint);  
            try  
            {  
                socket.Connect(endpoint);  
                networkStream = new NetworkStream(socket);  
                bufferedStream = new BufferedStream(networkStream);  
                byte[] buffer = Encoding.ASCII.GetBytes(CommandString);  
 
                SocketError socketError;  
                socket.Send(buffer, 0, buffer.Length, SocketFlags.None, out socketError);  
                if (socketError != SocketError.Success)  
                {  
                    stats.IsReachable = false;  
                }  
                else  
                {  
                    stats.IsReachable = true;  
                    string result = ReadLine();  
                    Dictionary<string, string> serverData = new Dictionary<string, string>(StringComparer.Ordinal);  
                    while (!string.IsNullOrEmpty(result))  
                    {  
                        // 返回的数据信息以"END"作为结束标记  
                        if (String.Compare(result, "END", StringComparison.Ordinal) == 0)  
                            break;  
 
                        //期望的响应格式是："STAT 名称 值"（注意"STAT 名称 值"之间有空格）  
                        if (result.Length < 6 || String.Compare(result, 0, "STAT ", 0, 5, StringComparison.Ordinal) != 0)  
                        {  
                            continue;  
                        }  
 
                        //获取以空格作为分隔符的键值对  
                        string[] parts = result.Remove(0, 5).Split(' ');  
                        if (parts.Length != 2)  
                        {  
                            continue;  
                        }  
                        serverData[parts[0]] = parts[1];  
                        result = ReadLine();  
                    }  
                    stats.InitializeData(serverData);  
                }  
            }  
            catch (Exception exception)  
            {  
                stats.IsReachable = false;  
                //Debug.WriteLine("Exception Message:" + exception.Message);  
            }  
            finally  
            {  
            }  
            return stats;  
 
        }  
        /// <summary> 
        /// 从远程主机的响应流中读取一行数据  
        /// </summary> 
        /// <returns></returns> 
        private string ReadLine()  
        {  
            MemoryStream ms = new MemoryStream(50);  
 
            bool gotR = false;  
            byte[] buffer = new byte[1];  
            int data;  
 
            try  
            {  
                while (true)  
                {  
                    data = bufferedStream.ReadByte();  
 
                    if (data == 13)  
                    {  
                        gotR = true;  
                        continue;  
                    }  
 
                    if (gotR)  
                    {  
                        if (data == 10)  
                            break;  
 
                        ms.WriteByte(13);  
 
                        gotR = false;  
                    }  
 
                    ms.WriteByte((byte)data);  
                }  
            }  
            catch (IOException)  
            {  
 
                throw;  
            }  
 
            string retureValue = Encoding.ASCII.GetString(ms.GetBuffer(), 0, (int)ms.Length);  
 
 
            if (String.IsNullOrEmpty(retureValue))  
                throw new Exception("接收到空响应。");  
 
            if (String.Compare(retureValue, GenericErrorResponse, StringComparison.Ordinal) == 0)  
                throw new NotSupportedException("无效的指令。");  
 
            if (retureValue.Length >= ErrorResponseLength)  
            {  
                if (String.Compare(retureValue, 0, ClientErrorResponse, 0, ErrorResponseLength, StringComparison.Ordinal) == 0)  
                {  
                    throw new Exception(retureValue.Remove(0, ErrorResponseLength));  
                }  
                else if (String.Compare(retureValue, 0, ServerErrorResponse, 0, ErrorResponseLength, StringComparison.Ordinal) == 0)  
                {  
                    throw new Exception(retureValue.Remove(0, ErrorResponseLength));  
                }  
            }  
 
            return retureValue;  
        }  
 
        public void Dispose()  
        {  
            if (socket != null)  
            {  
                socket.Shutdown(SocketShutdown.Both);  
            }  
            socket = null;  
            networkStream.Dispose();  
            networkStream = null;  
            bufferedStream.Dispose();  
            bufferedStream = null;  
        }  
    }  
</script> 
 
<html xmlns="http://www.w3.org/1999/xhtml"> 
<head> 
    <title>ASP.NET版Memcached监控工具</title> 
    <style> 
        a {  
    color:#000000;  
    text-decoration:none;  
}  
a.current {  
    color:#0000FF;  
}  
a:hover {  
    text-decoration: none;  
}  
body {  
    font-family: verdana, geneva,tahoma, helvetica, arial, sans-serif;  
    font-size: 100%;  
    background-color:#FFFFFF;  
    margin: 0em;  
}  
ul {  
    font-size:80%;  
    color:#666666;  
    line-height: 1.5em;  
    list-style: none;  
}  
    </style> 
</head> 
<body> 
<table border="0"> 
<tr><th>IP</th><th>Version</th><th>IsReachable</th><th>Bytes</th><th>Bytes_Read</th><th>Bytes_Written</th><th>Cmd_Get</th><th>Cmd_Set</th><th>Curr_Connections</th><th>Curr_Items</th><th>Get_Hits</th><th>Get_Misses</th><th>Limit_Maxbytes</th><th>Total_Items</th></tr> 
<%  
    String format = "<tr><td>{0}</td><td>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th><th>{7}</th><th>{8}</th><th>{9}</th><th>{10}</th><th>{11}</th><th>{12}</th><th>{13}</th></tr>";  
    List<IPEndPoint> list = new List<IPEndPoint> { new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11211) };  
    MemcachedMonitor monitor = new MemcachedMonitor(list);  
    List<MemcachedServerStats> resultList = monitor.GetAllServerStats();  
    string result=string.Empty;  
    foreach (MemcachedServerStats stats in resultList)  
    {  
        result = string.Format(format, stats.IPEndPoint, stats.Version,stats.IsReachable, stats.Bytes, stats.Bytes_Read, stats.Bytes_Written, stats.Cmd_Get, stats.Cmd_Set, stats.Curr_Connections, stats.Curr_Items, stats.Get_Hits, stats.Get_Misses, stats.Limit_Maxbytes, stats.Total_Items);  
        Response.Write(result);  
    }  
%> 
</table> 
这些数据所代表的意义如下：  
<ul> 
<li>pid：32u，服务器进程ID。</li>   
<li>uptime：32u， 服务器运行时间，单位秒。</li>   
<li>time ：32u， 服务器当前的UNIX时间。</li> 
<li>version ：string， 服务器的版本号。 </li> 
<li>curr_items ：32u， 服务器当前存储的内容数量</li>   
<li>total_items ：32u， 服务器启动以来存储过的内容总数。</li> 
<li>bytes ：64u， 服务器当前存储内容所占用的字节数。</li> 
<li>curr_connections ：32u， 连接数量。 </li> 
<li>total_connections ：32u， 服务器运行以来接受的连接总数。</li> 
<li>connection_structures：32u， 服务器分配的连接结构的数量。</li>   
<li>cmd_get ：32u， 取回请求总数。 </li> 
<li>cmd_set ：32u， 存储请求总数。 </li> 
<li>get_hits ：32u， 请求成功的总次数。</li> 
<li>get_misses ：32u， 请求失败的总次数。</li> 
<li>bytes_read ：64u， 服务器从网络读取到的总字节数。</li> 
<li>bytes_written ：64u， 服务器向网络发送的总字节数。</li> 
<li>limit_maxbytes ：32u， 服务器在存储时被允许使用的字节总数。</li> 
</ul> 
上面的描述中32u和64u表示32位和64位无符号整数，string表示是string类型数据。<br /> 
作者博客：<a href="http://blog.csdn.net/zhoufoxcn" target="_blank">CSDN博客</a>|<a href="http://zhoufoxcn.blog.51cto.com" target="_blank">51CTO博客</a> 
</body> 
</html> 
