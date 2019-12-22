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
        #region 初始化
        /// <summary>
        /// 全局变量
        /// </summary>
        double DataSum = 0;
        List<IPEndPoint> session = new List<IPEndPoint>();
        List<double> list = new List<double>();
        private TcpSocketServer _server;
        public delegate void TcpConnect(TcpClientConnectedEventArgs e);
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public int port = 22222;
        string header = "y,m,d,h,m,s,x0,x1,x2,x3,x4,x5,x6,x7,x8,x9".Trim();
        string dir = Application.StartupPath + "\\Data";

        bool IfAdd = false;
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
            int headerlength = header.Split(',').Length;
            ColumnHeader[] column = new ColumnHeader[headerlength];

            for (int i = 0; i < headerlength; i++)
            {
                column[i] = new ColumnHeader();
                column[i].Text = (header.Split(','))[i];
                column[i].Width = 60;
                column[i].TextAlign = HorizontalAlignment.Center;
            }
            this.listView2.Columns.AddRange(column);

            listView1.Columns.Add("IP", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Port", 120, HorizontalAlignment.Left);
        }
        public void Update_session()
        {
            this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度

            for (int i = 0; i < session.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = session[i].Address.ToString();
                lvi.SubItems.Add(session[i].Port.ToString());
                this.listView1.Items.Add(lvi);
            }

            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
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
                this.listView1.Items.Clear();
                IfAdd = true;
            }
            toolStripStatusLabel1.Text = "已连接";
        }
        /// <summary>
        /// 服务端与客户端连接断开方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void server_ClientDisconnected(object sender, TcpClientDisconnectedEventArgs e)
        {
            session.Remove(e.Session.RemoteEndPoint);
            //listView1.Items.Remove();   //按项移除
            IfAdd = true;
            if (session.Count == 0)
            {
                toolStripStatusLabel1.Text = "就绪";
            }
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
            UpdateGraph(e.Data, e.DataOffset, e.DataLength);
            UpdateListView2(RealDataReceive(e.Data, e.DataOffset, e.DataLength));
            DataLength.Text = "实时接收数据的量:" + e.DataLength.ToString() + " bytes";
            DataSum += e.DataLength;
            AllDataLength.Text = "接受数据的总量为：" + DataSum.ToString() + " bytes";
            list.Add(e.DataLength);
        }

        private void UpdateListView2(int[] intvalues)
        {
            this.listView2.BeginUpdate();
            ListViewItem.ListViewSubItem[] subItem = new ListViewItem.ListViewSubItem[intvalues.Length];
            for (int i = 0; i < intvalues.Length; i++)
            {
                subItem[i] = new ListViewItem.ListViewSubItem();
                subItem[i].Text = intvalues[i].ToString();
            }
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.AddRange(subItem);
            this.listView2.Items.Add(lvi);
            this.listView2.EndUpdate();
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

        #region 速度及连接状态
        /// <summary>
        /// 连接状态更新计时器方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            string x = "";
            foreach (var item in session)
            {
                x += item;
                x += "\n";
            }
            if (IfAdd)
            {
                Update_session();

            }
            IfAdd = false;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];

            }
            speed.Text = "速度为:" + (sum / 5).ToString() + "b/s";
            list.Clear();
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
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.服务器.Visible = true;
            }
            this.FormBorderStyle = FormBorderStyle.None;
        }
        #endregion

        #region 实时与历史数据窗口
        /// <summary>
        /// 打开窗口Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DataForm dataForm = new DataForm();
            dataForm.ShowDialog();
        }

        #endregion

        #region ZedGraph窗口
        /// <summary>
        /// 更新图像
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataOffset"></param>
        /// <param name="dataLength"></param>
        private void UpdateGraph(byte[] data, int dataOffset, int dataLength)
        {
<<<<<<< Updated upstream
            RealDataReceive(data, dataOffset, dataLength);

        }
        public int[] realdata;
        private static int[] RealDataReceive(byte[] data, int dataOffset, int dataLength)
        {
            int[] realdatatemp = null;
            string str = System.Text.Encoding.UTF8.GetString(data, dataOffset + 1, dataLength - 1);
            if (str.StartsWith("Data>>") && str.EndsWith("\r\n"))
            {
                string[] databox = str.Split('#');
                string[] strdata = databox[1].Split(',');
                realdatatemp = new int[strdata.Length];
                for (int i = 0; i < strdata.Length; i++)
                {
                    realdatatemp[i] = int.Parse(strdata[i]);
                }
            }
            //MainForm.realdata = realdatatemp;
            return realdatatemp;
=======
            MatPlotForm matPlotForm = new MatPlotForm();
            matPlotForm.ShowDialog();
            
>>>>>>> Stashed changes
        }
        #endregion
    }
    /// <summary>
    /// 双缓冲ListView
    /// </summary>
    public class ListViewNF : System.Windows.Forms.ListView
    {
        public ListViewNF()
        {
            // 开启双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            // Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}
