namespace 数据采集服务
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingForm = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripSplitButton();
            this.查看帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LocalPart = new System.Windows.Forms.ToolStripStatusLabel();
            this.RemotePort = new System.Windows.Forms.ToolStripStatusLabel();
            this.DataLength = new System.Windows.Forms.ToolStripStatusLabel();
            this.AllDataLength = new System.Windows.Forms.ToolStripStatusLabel();
            this.LocalEndPointAddress = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Status = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IpAdress = new System.Windows.Forms.Label();
            this.服务器 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tcpClientConnectedEventArgsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.settingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcpClientConnectedEventArgsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.settingForm,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(4, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(864, 27);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::数据采集服务.Properties.Resources.playcircle_fill;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "启动服务";
            this.toolStripButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = global::数据采集服务.Properties.Resources.stopcircle_fill;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton2.Text = "关闭服务";
            this.toolStripButton2.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::数据采集服务.Properties.Resources.folder_fill;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton3.Text = "打开数据文件夹";
            this.toolStripButton3.Click += new System.EventHandler(this.button3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // settingForm
            // 
            this.settingForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingForm.Image = global::数据采集服务.Properties.Resources.cog;
            this.settingForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingForm.Name = "settingForm";
            this.settingForm.Size = new System.Drawing.Size(29, 24);
            this.settingForm.Text = "配置";
            this.settingForm.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看帮助ToolStripMenuItem,
            this.关于服务器ToolStripMenuItem});
            this.toolStripButton4.Image = global::数据采集服务.Properties.Resources.icon_bangzhuwendang;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(39, 24);
            this.toolStripButton4.Text = "帮助";
            // 
            // 查看帮助ToolStripMenuItem
            // 
            this.查看帮助ToolStripMenuItem.Name = "查看帮助ToolStripMenuItem";
            this.查看帮助ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.查看帮助ToolStripMenuItem.Text = "查看帮助";
            this.查看帮助ToolStripMenuItem.Click += new System.EventHandler(this.查看帮助ToolStripMenuItem_Click);
            // 
            // 关于服务器ToolStripMenuItem
            // 
            this.关于服务器ToolStripMenuItem.Name = "关于服务器ToolStripMenuItem";
            this.关于服务器ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.关于服务器ToolStripMenuItem.Text = "关于服务器";
            this.关于服务器ToolStripMenuItem.Click += new System.EventHandler(this.关于服务器ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.LocalPart,
            this.RemotePort,
            this.DataLength,
            this.AllDataLength,
            this.LocalEndPointAddress});
            this.statusStrip1.Location = new System.Drawing.Point(4, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(864, 26);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 20);
            this.toolStripStatusLabel1.Text = "就绪";
            // 
            // LocalPart
            // 
            this.LocalPart.Name = "LocalPart";
            this.LocalPart.Size = new System.Drawing.Size(99, 20);
            this.LocalPart.Text = "本地终结点：";
            // 
            // RemotePort
            // 
            this.RemotePort.Name = "RemotePort";
            this.RemotePort.Size = new System.Drawing.Size(99, 20);
            this.RemotePort.Text = "远程终结点：";
            // 
            // DataLength
            // 
            this.DataLength.Name = "DataLength";
            this.DataLength.Size = new System.Drawing.Size(114, 20);
            this.DataLength.Text = "实时数据的量：";
            // 
            // AllDataLength
            // 
            this.AllDataLength.Name = "AllDataLength";
            this.AllDataLength.Size = new System.Drawing.Size(129, 20);
            this.AllDataLength.Text = "接收数据的总量：";
            // 
            // LocalEndPointAddress
            // 
            this.LocalEndPointAddress.Name = "LocalEndPointAddress";
            this.LocalEndPointAddress.Size = new System.Drawing.Size(99, 20);
            this.LocalEndPointAddress.Text = "本地端口号：";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Status
            // 
            this.Status.Dock = System.Windows.Forms.DockStyle.Left;
            this.Status.Location = new System.Drawing.Point(4, 59);
            this.Status.Multiline = true;
            this.Status.Name = "Status";
            this.Status.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Status.Size = new System.Drawing.Size(500, 449);
            this.Status.TabIndex = 1;
            this.Status.MouseHover += new System.EventHandler(this.Status_MouseHover);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IpAdress);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(504, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 449);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接状态：";
            // 
            // IpAdress
            // 
            this.IpAdress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.IpAdress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IpAdress.Location = new System.Drawing.Point(3, 21);
            this.IpAdress.Name = "IpAdress";
            this.IpAdress.Size = new System.Drawing.Size(358, 425);
            this.IpAdress.TabIndex = 8;
            this.IpAdress.Text = "未有IP连接";
            this.IpAdress.MouseHover += new System.EventHandler(this.IpAdress_MouseHover);
            // 
            // 服务器
            // 
            this.服务器.Icon = ((System.Drawing.Icon)(resources.GetObject("服务器.Icon")));
            this.服务器.Text = "服务器";
            this.服务器.Visible = true;
            this.服务器.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.服务器_MouseDoubleClick);
            // 
            // tcpClientConnectedEventArgsBindingSource
            // 
            this.tcpClientConnectedEventArgsBindingSource.DataSource = typeof(Cowboy.Sockets.TcpClientConnectedEventArgs);
            // 
            // settingsBindingSource
            // 
            this.settingsBindingSource.DataSource = typeof(数据采集服务.Settings);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 538);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "服务器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcpClientConnectedEventArgsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel RemotePort;
        private System.Windows.Forms.ToolStripStatusLabel LocalPart;
        private System.Windows.Forms.ToolStripStatusLabel DataLength;
        private System.Windows.Forms.ToolStripStatusLabel AllDataLength;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.ToolStripStatusLabel LocalEndPointAddress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label IpAdress;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem 查看帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于服务器ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon 服务器;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton settingForm;
        private System.Windows.Forms.BindingSource settingsBindingSource;
        private System.Windows.Forms.BindingSource tcpClientConnectedEventArgsBindingSource;
    }
}

