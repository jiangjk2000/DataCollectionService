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

namespace 数据采集服务
{
    public delegate void setIntArrayValue(int[] Value);
    public partial class MatPlotForm : Skin_Mac
    {
        public MatPlotForm()
        {
            InitializeComponent();
        }
        public event setIntArrayValue SetFormIntValue;
        private void MatPlotForm_Load(object sender, EventArgs e)
        {

        }
    }
}
