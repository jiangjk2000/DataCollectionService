﻿namespace 数据采集服务
{
    partial class DataForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("文件1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("文件2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("实时数据", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("文件1");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("文件2");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("文件3");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("文件4");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("历史数据", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new ListViewNF();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(4, 32);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点4";
            treeNode1.Text = "文件1";
            treeNode2.Name = "节点5";
            treeNode2.Text = "文件2";
            treeNode3.Name = "节点3";
            treeNode3.Text = "实时数据";
            treeNode4.Name = "Fold1";
            treeNode4.Text = "文件1";
            treeNode5.Name = "节点4";
            treeNode5.Text = "文件2";
            treeNode6.Name = "节点5";
            treeNode6.Text = "文件3";
            treeNode7.Name = "节点6";
            treeNode7.Text = "文件4";
            treeNode8.Name = "历史数据";
            treeNode8.Text = "历史数据";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(121, 414);
            this.treeView1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(131, 32);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(665, 414);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataForm";
            this.Text = "Data";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        
        ListViewNF listView1;
    }
}