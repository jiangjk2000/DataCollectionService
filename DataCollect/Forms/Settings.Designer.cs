namespace DataCollect
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("基础设置");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.settingCancel = new System.Windows.Forms.Button();
            this.settingYes = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.viewFoldButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.settingTextBox2 = new System.Windows.Forms.TextBox();
            this.settingTextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.settingCancel);
            this.splitContainer1.Panel2.Controls.Add(this.settingYes);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(792, 414);
            this.splitContainer1.SplitterDistance = 273;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点0";
            treeNode1.Text = "基础设置";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(273, 414);
            this.treeView1.TabIndex = 0;
            // 
            // settingCancel
            // 
            this.settingCancel.Location = new System.Drawing.Point(409, 369);
            this.settingCancel.Name = "settingCancel";
            this.settingCancel.Size = new System.Drawing.Size(90, 31);
            this.settingCancel.TabIndex = 4;
            this.settingCancel.Text = "取消";
            this.settingCancel.UseVisualStyleBackColor = true;
            this.settingCancel.Click += new System.EventHandler(this.settingCancel_Click);
            // 
            // settingYes
            // 
            this.settingYes.Location = new System.Drawing.Point(300, 369);
            this.settingYes.Name = "settingYes";
            this.settingYes.Size = new System.Drawing.Size(97, 31);
            this.settingYes.TabIndex = 3;
            this.settingYes.Text = "确定";
            this.settingYes.UseVisualStyleBackColor = true;
            this.settingYes.Click += new System.EventHandler(this.settingYes_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.viewFoldButton);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.settingTextBox2);
            this.groupBox1.Controls.Add(this.settingTextBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 149);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本";
            // 
            // viewFoldButton
            // 
            this.viewFoldButton.Location = new System.Drawing.Point(398, 80);
            this.viewFoldButton.Name = "viewFoldButton";
            this.viewFoldButton.Size = new System.Drawing.Size(93, 25);
            this.viewFoldButton.TabIndex = 5;
            this.viewFoldButton.Text = "浏览";
            this.viewFoldButton.UseVisualStyleBackColor = true;
            this.viewFoldButton.Click += new System.EventHandler(this.viewFoldButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(278, 25);
            this.textBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据存储路径:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "文件存储格式:";
            // 
            // settingTextBox2
            // 
            this.settingTextBox2.Location = new System.Drawing.Point(117, 49);
            this.settingTextBox2.Name = "settingTextBox2";
            this.settingTextBox2.Size = new System.Drawing.Size(100, 25);
            this.settingTextBox2.TabIndex = 1;
            this.settingTextBox2.Text = "22222";
            // 
            // settingTextBox1
            // 
            this.settingTextBox1.Location = new System.Drawing.Point(117, 18);
            this.settingTextBox1.Name = "settingTextBox1";
            this.settingTextBox1.Size = new System.Drawing.Size(278, 25);
            this.settingTextBox1.TabIndex = 1;
            this.settingTextBox1.Text = "y,m,d,h,m,s,x0,x1,x2,x3,x4,x5,x6,x7,x8,x9";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务端口:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Setting";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.TextBox settingTextBox2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox settingTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button settingCancel;
        private System.Windows.Forms.Button settingYes;
        private System.Windows.Forms.Button viewFoldButton;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeView1;
    }
}