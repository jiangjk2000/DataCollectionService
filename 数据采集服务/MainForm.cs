using CCWin;
using Cowboy.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace 数据采集服务
{
    /// <summary>
    /// 主窗体采用CSkin第三方界面库的Mac主题
    /// </summary>
    public partial class MainForm : Skin_Mac
    {
        #region 初始化变量
        /// <summary>
        /// 全局变量
        /// </summary>
        double DataSum = 0;
        List<IPEndPoint> session = new List<IPEndPoint>();
        private TcpSocketServer _server;
        public delegate void TcpConnect(TcpClientConnectedEventArgs e);
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public int port = 22222;
        string header = "y,m,d,h,m,s,x0,x1,x2,x3,x4,x5,x6,x7,x8,x9".Trim();
        string dir = Application.StartupPath + "\\Data";
        ColumnHeader ch;

        /// <summary>
        /// 默认窗体初始化
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载方法
        /// 1.加载默认ListView的列表头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region 菜单
        /// <summary>
        /// 启动服务方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Log("启动服务");

            StartServer(port);
            toolStripButton2.Enabled = true;
            toolStripButton1.Enabled = false;
        }
        /// <summary>
        /// 关闭服务方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Log("关闭服务");
            StopServer();
            toolStripButton2.Enabled = false;
            toolStripButton1.Enabled = true;
        }
        /// <summary>
        /// 打开数据存储目录方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            System.Diagnostics.Process.Start(dir);
        }
        #endregion

        #region 日志
        /// <summary>
        /// 生成日志
        /// </summary>
        /// <param name="msg"></param>
        private void Log(string msg)
        {
            Status.Invoke(new Action(() => LogImplement(msg)));
        }
        /// <summary>
        /// 生成日志工具方法
        /// </summary>
        /// <param name="msg"></param>
        private void LogImplement(string msg)
        {
            Status.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss  ") + msg + "\r\n");
            if (Status.Text.Length > 5000)
            {
                Status.Text = Status.Text.Substring(4000);
            }
        }
        #endregion

        #region 网络服务
        /// <summary>
        /// 启动服务方法
        /// </summary>
        /// <param name="port"></param>
        private void StartServer(int port)
        {
            TcpSocketServerConfiguration config = new TcpSocketServerConfiguration();
            config.FrameBuilder = new RawBufferFrameBuilder();

            _server = new TcpSocketServer(port, config);
            _server.ClientConnected += server_ClientConnected;
            _server.ClientDisconnected += server_ClientDisconnected;
            _server.ClientDataReceived += server_ClientDataReceived;
            _server.Listen();
        }
        /// <summary>
        /// 关闭服务方法
        /// </summary>
        private void StopServer()
        {
            _server.Shutdown();
            _server.ClientConnected -= server_ClientConnected;
            _server.ClientDisconnected -= server_ClientDisconnected;
            _server.ClientDataReceived -= server_ClientDataReceived;
            _server = null;
        }
        /// <summary>
        /// 服务端与客户端连接方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void server_ClientConnected(object sender, TcpClientConnectedEventArgs e)
        {
            Log(string.Format(e.Session.RemoteEndPoint.Address + ">> 接入服务器"));
            if (!session.Contains(e.Session.RemoteEndPoint))
            {
                session.Add(e.Session.RemoteEndPoint);
            }
            TcpConnect connect = new TcpConnect(Func);
            toolStripStatusLabel1.Text = "已连接" + e.Session.RemoteEndPoint;
            RemotePort.Text = "远程终结点为：" + e.Session.RemoteEndPoint.Port.ToString();
            LocalPart.Text = "本地终结点" + e.Session.LocalEndPoint.Port.ToString();
            LocalEndPointAddress.Text = "本地端口号：" + e.Session.LocalEndPoint.Address.ToString();
        }
        private void Func(TcpClientConnectedEventArgs e)
        {

        }
        /// <summary>
        /// 服务端与客户端连接断开方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void server_ClientDisconnected(object sender, TcpClientDisconnectedEventArgs e)
        {
            session.Remove(e.Session.RemoteEndPoint);
            Log(string.Format(e.Session.RemoteEndPoint.Address + ">> 关闭连接"));
        }
        /// <summary>
        /// 服务端数据接收方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void server_ClientDataReceived(object sender, TcpClientDataReceivedEventArgs e)
        {

            Log(e.Session.RemoteEndPoint.Address + ">> 收到" + e.DataLength + "字节数据");
            string filepath = GetDataFilePath(e.Session.RemoteEndPoint.Address);
            WriteData(filepath, e.Data, e.DataOffset, e.DataLength);
            DataLength.Text = "实时接收数据的量:" + e.DataLength.ToString();
            DataSum += e.DataLength;
            AllDataLength.Text = "接受数据的总量为：" + DataSum.ToString();
        }
        /// <summary>
        /// 数据接收
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="data"></param>
        /// <param name="dataOffset"></param>
        /// <param name="dataLength"></param>
        private void WriteData(string filepath, byte[] data, int dataOffset, int dataLength)
        {
            //bool NeedWriteHeader= !File.Exists(filepath) 
            //    && !string.IsNullOrWhiteSpace(this.toolStripTextBox2.Text);
            bool NeedWriteHeader = !File.Exists(filepath)
                && !string.IsNullOrWhiteSpace(this.header);
            using (FileStream fs = new FileStream(filepath, FileMode.Append, FileAccess.Write))
            {
                if (NeedWriteHeader)
                {
                    //string header = this.toolStripTextBox2.Text.Trim();
                    byte[] buffer = Encoding.Default.GetBytes(header + "\r\n");
                    fs.Write(buffer, 0, buffer.Length);
                }
                fs.Write(data, dataOffset, dataLength);
            }
        }
        /// <summary>
        /// 获取数据文件路径
        /// 若目录不存在，会创建目录
        /// </summary>
        /// <param name="iPAddress"></param>
        /// <returns></returns>
        string GetDataFilePath(IPAddress iPAddress)
        {
            string dir = Application.StartupPath + "\\Data";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string ip = iPAddress.ToString();
            dir = dir + "\\" + ip;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            DateTime date = DateTime.Today;
            string datestr = date.ToString("yyyy-MM");
            dir = dir + "\\" + datestr;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string filepath = dir + "\\" + date.ToString("yyyy-MM-dd") + ".csv";


            return filepath;
        }
        #endregion

        #region 连接状态
        /// <summary>
        /// 连接状态更新计时器方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            IpAdress.Text = "已有以下已连接，共" + session.Count.ToString() + "个\n";
            foreach (var item in session)
            {
                IpAdress.Text += item;
            }
        }
        #endregion

        #region 设置
        /// <summary>
        /// 打开配置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Settings settingForm = new Settings();
            settingForm.settingTextBox1.Text = header;
            settingForm.settingTextBox2.Text = port.ToString();
            settingForm.textBox1.Text = dir;
            settingForm.SetFormTextValue += Setting_SetFormTextValue;
            settingForm.Owner = this;
            settingForm.ShowDialog();
        }
        /// <summary>
        /// 获取配置数据
        /// </summary>
        /// <param name="value"></param>
        private void Setting_SetFormTextValue(string value)
        {
            string[] temp = value.Split('#');
            this.header = temp[0].Trim();
            this.port = int.Parse(temp[1]);
            this.dir = temp[2];
        }
        #endregion

        #region 关于
        /// <summary>
        /// 关于窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关于服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About form = new About();
            form.ShowDialog();
        }
        #endregion

        #region 帮助
        /// <summary>
        /// 帮助文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("帮助正在更新中....", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region 相关提示内容
        /// <summary>
        /// 状态栏提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Status_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("显示接受字节数量", Status);
        }
        /// <summary>
        /// 显示连接状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IpAdress_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("显示连接状态", IpAdress);
        }
        #endregion

        #region 后台最小化
        /// <summary>
        /// 后台最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 服务器_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        #endregion
    }
}
