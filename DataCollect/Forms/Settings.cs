using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace DataCollect
{
    /// <summary>
    /// 建立传值委托
    /// </summary>
    /// <param name="textValue"></param>
    public delegate void setTextValue(string textValue);
    /// <summary>
    /// 设置界面的窗体类
    /// </summary>
    public partial class Settings : Skin_Mac
    {
        /// <summary>
        /// Settings构造器
        /// </summary>
        public Settings()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 建立传值事件
        /// </summary>
        public event setTextValue SetFormTextValue;

        private void settingYes_Click(object sender, EventArgs e)
        {
            string value = settingTextBox1.Text + '#' + settingTextBox2.Text + '#' +textBox1.Text;
            SetFormTextValue(value);
            this.Close();
        }

        private void settingCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewFoldButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
            }
        }


    }
}
