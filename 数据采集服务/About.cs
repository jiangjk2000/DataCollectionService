using CCWin;
using System;


namespace 数据采集服务
{
    public partial class About : Skin_Mac
    {
        public About()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.qq.com/cgi-bin/frame_html?sid=unS9O1PKdWuHXAhV&r=c64e46c6d3d281e0de922349cc3dbde4");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
