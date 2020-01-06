using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollect.Modules
{
    class MainFormLogs
    {
        #region 日志
        /// <summary>
        /// 生成日志
        /// </summary>
        /// <param name="msg"></param>
        public void Log(string msg, TextBox Status)
        {
            Status.Invoke(new Action(() => LogImplement(msg, Status)));
        }

        /// <summary>
        /// 生成日志工具方法
        /// </summary>
        /// <param name="msg"></param>
        public void LogImplement(string msg, TextBox Status)
        {
            Status.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss  ") + msg + "\r\n");
            if (Status.Text.Length > 5000)
            {
                Status.Text = Status.Text.Substring(4000);
            }
        }
        #endregion
    }
}
