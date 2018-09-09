namespace RC.UI.DeveloperTools
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动生成配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成主界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模板管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模块ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统按钮ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据字典ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_status = new System.Windows.Forms.Panel();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.自动生成ToolStripMenuItem,
            this.系统配置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.文件ToolStripMenuItem.Text = "数据库";
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关闭ToolStripMenuItem.Text = "连接";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.数据库ToolStripMenuItem_Click);
            // 
            // 自动生成ToolStripMenuItem
            // 
            this.自动生成ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自动生成配置ToolStripMenuItem,
            this.生成主界面ToolStripMenuItem,
            this.模板管理ToolStripMenuItem});
            this.自动生成ToolStripMenuItem.Name = "自动生成ToolStripMenuItem";
            this.自动生成ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.自动生成ToolStripMenuItem.Text = "自动生成";
            // 
            // 自动生成配置ToolStripMenuItem
            // 
            this.自动生成配置ToolStripMenuItem.Name = "自动生成配置ToolStripMenuItem";
            this.自动生成配置ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.自动生成配置ToolStripMenuItem.Text = "前台代码生成";
            // 
            // 生成主界面ToolStripMenuItem
            // 
            this.生成主界面ToolStripMenuItem.Name = "生成主界面ToolStripMenuItem";
            this.生成主界面ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.生成主界面ToolStripMenuItem.Text = "后台代码生成";
            this.生成主界面ToolStripMenuItem.Click += new System.EventHandler(this.生成主界面ToolStripMenuItem_Click);
            // 
            // 模板管理ToolStripMenuItem
            // 
            this.模板管理ToolStripMenuItem.Name = "模板管理ToolStripMenuItem";
            this.模板管理ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.模板管理ToolStripMenuItem.Text = "模板管理";
            this.模板管理ToolStripMenuItem.Click += new System.EventHandler(this.模板管理ToolStripMenuItem_Click);
            // 
            // 系统配置ToolStripMenuItem
            // 
            this.系统配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.模块ToolStripMenuItem,
            this.系统按钮ToolStripMenuItem,
            this.数据字典ToolStripMenuItem});
            this.系统配置ToolStripMenuItem.Name = "系统配置ToolStripMenuItem";
            this.系统配置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统配置ToolStripMenuItem.Text = "系统配置";
            // 
            // 模块ToolStripMenuItem
            // 
            this.模块ToolStripMenuItem.Name = "模块ToolStripMenuItem";
            this.模块ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.模块ToolStripMenuItem.Text = "系统模块";
            this.模块ToolStripMenuItem.Click += new System.EventHandler(this.模块ToolStripMenuItem_Click);
            // 
            // 系统按钮ToolStripMenuItem
            // 
            this.系统按钮ToolStripMenuItem.Name = "系统按钮ToolStripMenuItem";
            this.系统按钮ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.系统按钮ToolStripMenuItem.Text = "系统按钮";
            this.系统按钮ToolStripMenuItem.Click += new System.EventHandler(this.系统按钮ToolStripMenuItem_Click);
            // 
            // 数据字典ToolStripMenuItem
            // 
            this.数据字典ToolStripMenuItem.Name = "数据字典ToolStripMenuItem";
            this.数据字典ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.数据字典ToolStripMenuItem.Text = "数据字典";
            this.数据字典ToolStripMenuItem.Click += new System.EventHandler(this.数据字典ToolStripMenuItem_Click);
            // 
            // pnl_status
            // 
            this.pnl_status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_status.Location = new System.Drawing.Point(0, 512);
            this.pnl_status.Name = "pnl_status";
            this.pnl_status.Size = new System.Drawing.Size(1008, 25);
            this.pnl_status.TabIndex = 1;
            // 
            // pnl_main
            // 
            this.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_main.Location = new System.Drawing.Point(0, 25);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(1008, 487);
            this.pnl_main.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 537);
            this.Controls.Add(this.pnl_main);
            this.Controls.Add(this.pnl_status);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "CodeAutoGeneration";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动生成配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成主界面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模块ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统按钮ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据字典ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模板管理ToolStripMenuItem;
        private System.Windows.Forms.Panel pnl_status;
        private System.Windows.Forms.Panel pnl_main;
    }
}

