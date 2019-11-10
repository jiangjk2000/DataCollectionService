using Cowboy.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace 数据采集服务
{
    public partial class MainForm : Form
    {
        private TcpSocketServer _server;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log("启动服务");
            int port = int.Parse(toolStripTextBox1.Text);
            StartServer(port);
            toolStripButton2.Enabled = true;
            toolStripButton1.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Log("关闭服务");
            StopServer();
            toolStripButton2.Enabled = false;
            toolStripButton1.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string dir = Application.StartupPath + "\\Data";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            System.Diagnostics.Process.Start(dir);
        }

        #region 日志
        private void Log(string msg)
        {
            textBox1.Invoke(new Action(() => LogImplement(msg)));
        }
        private void LogImplement(string msg)
        {
            textBox1.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss  ") + msg + "\r\n");
            if (textBox1.Text.Length > 5000)
            {
                textBox1.Text = textBox1.Text.Substring(4000);
            }
        }
        #endregion

        #region 网络服务
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
        private void StopServer()
        {
            _server.Shutdown();
            _server.ClientConnected -= server_ClientConnected;
            _server.ClientDisconnected -= server_ClientDisconnected;
            _server.ClientDataReceived -= server_ClientDataReceived;
            _server = null;
        }

        void server_ClientConnected(object sender, TcpClientConnectedEventArgs e)
        {
            Log(string.Format(e.Session.RemoteEndPoint.Address + ">> 接入服务器"));
        }

        void server_ClientDisconnected(object sender, TcpClientDisconnectedEventArgs e)
        {
            Log(string.Format(e.Session.RemoteEndPoint.Address + ">> 关闭连接"));
        }

        void server_ClientDataReceived(object sender, TcpClientDataReceivedEventArgs e)
        {
            Log(e.Session.RemoteEndPoint.Address + ">> 收到" + e.DataLength + "字节数据");
            string filepath = GetDataFilePath(e.Session.RemoteEndPoint.Address);
            WriteData(filepath, e.Data, e.DataOffset, e.DataLength);
        }

        private void WriteData(string filepath, byte[] data, int dataOffset, int dataLength)
        {
            bool NeedWriteHeader= !File.Exists(filepath) 
                && !string.IsNullOrWhiteSpace(this.toolStripTextBox2.Text);
            using (FileStream fs = new FileStream(filepath, FileMode.Append, FileAccess.Write))
            {
                if (NeedWriteHeader)
                {
                    string header = this.toolStripTextBox2.Text.Trim();
                    byte[] buffer = Encoding.Default.GetBytes(header+"\r\n");
                    fs.Write(buffer,0,buffer.Length);
                }
                fs.Write(data, dataOffset, dataLength);
            }
        }

        //获取数据文件路径，若目录不存在，会创建目录
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

    }
}
