namespace RC.UI.DeveloperTools.Control
{
    partial class uc_statusbar
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusbar_db = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_dbname = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statususer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statuspwd = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_zhuangbi = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.statusbar_db,
            this.status_dbname,
            this.toolStripStatusLabel3,
            this.statususer,
            this.toolStripStatusLabel4,
            this.statuspwd,
            this.lbl_zhuangbi});
            this.statusbar.Location = new System.Drawing.Point(0, 1);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(695, 22);
            this.statusbar.TabIndex = 2;
            this.statusbar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel2.Text = "数据库：";
            // 
            // statusbar_db
            // 
            this.statusbar_db.Name = "statusbar_db";
            this.statusbar_db.Size = new System.Drawing.Size(59, 17);
            this.statusbar_db.Text = "127.0.0.1";
            // 
            // status_dbname
            // 
            this.status_dbname.Name = "status_dbname";
            this.status_dbname.Size = new System.Drawing.Size(49, 17);
            this.status_dbname.Text = "ZRMES";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel3.Text = "用户名：";
            // 
            // statususer
            // 
            this.statususer.Name = "statususer";
            this.statususer.Size = new System.Drawing.Size(21, 17);
            this.statususer.Text = "sa";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel4.Text = "密码：";
            // 
            // statuspwd
            // 
            this.statuspwd.Name = "statuspwd";
            this.statuspwd.Size = new System.Drawing.Size(43, 17);
            this.statuspwd.Text = "Sa123";
            // 
            // lbl_zhuangbi
            // 
            this.lbl_zhuangbi.Name = "lbl_zhuangbi";
            this.lbl_zhuangbi.Size = new System.Drawing.Size(116, 17);
            this.lbl_zhuangbi.Text = "荣联汇智天津工程部";
            // 
            // uc_statusbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusbar);
            this.Name = "uc_statusbar";
            this.Size = new System.Drawing.Size(695, 23);
            this.Load += new System.EventHandler(this.uc_statusbar_Load);
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel statusbar_db;
        private System.Windows.Forms.ToolStripStatusLabel status_dbname;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel statususer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel statuspwd;
        private System.Windows.Forms.ToolStripStatusLabel lbl_zhuangbi;

    }
}
