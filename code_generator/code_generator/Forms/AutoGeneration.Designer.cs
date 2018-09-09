namespace RC.UI.DeveloperTools.Forms
{
    partial class AutoGeneration
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckall = new System.Windows.Forms.CheckBox();
            this.gv_table = new System.Windows.Forms.DataGridView();
            this.ck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tablename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabledescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ck_ignore = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ckall_build = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_table)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckall);
            this.panel1.Controls.Add(this.gv_table);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 459);
            this.panel1.TabIndex = 0;
            // 
            // ckall
            // 
            this.ckall.AutoSize = true;
            this.ckall.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ckall.Location = new System.Drawing.Point(0, 443);
            this.ckall.Name = "ckall";
            this.ckall.Size = new System.Drawing.Size(375, 16);
            this.ckall.TabIndex = 1;
            this.ckall.Text = "全选";
            this.ckall.UseVisualStyleBackColor = true;
            this.ckall.CheckedChanged += new System.EventHandler(this.ckall_CheckedChanged);
            // 
            // gv_table
            // 
            this.gv_table.AllowUserToAddRows = false;
            this.gv_table.AllowUserToDeleteRows = false;
            this.gv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ck,
            this.tablename,
            this.tabledescription});
            this.gv_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_table.Location = new System.Drawing.Point(0, 0);
            this.gv_table.Name = "gv_table";
            this.gv_table.RowHeadersVisible = false;
            this.gv_table.RowTemplate.Height = 23;
            this.gv_table.Size = new System.Drawing.Size(375, 459);
            this.gv_table.TabIndex = 0;
            // 
            // ck
            // 
            this.ck.DataPropertyName = "ck";
            this.ck.HeaderText = "选择";
            this.ck.Name = "ck";
            this.ck.Width = 50;
            // 
            // tablename
            // 
            this.tablename.DataPropertyName = "name";
            this.tablename.HeaderText = "表名";
            this.tablename.Name = "tablename";
            this.tablename.Width = 165;
            // 
            // tabledescription
            // 
            this.tabledescription.DataPropertyName = "tdescription";
            this.tabledescription.HeaderText = "描述";
            this.tabledescription.Name = "tabledescription";
            this.tabledescription.Width = 150;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnl_main);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(375, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 459);
            this.panel2.TabIndex = 1;
            // 
            // pnl_main
            // 
            this.pnl_main.AutoScroll = true;
            this.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_main.Location = new System.Drawing.Point(0, 47);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(524, 412);
            this.pnl_main.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ck_ignore);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(524, 47);
            this.panel3.TabIndex = 1;
            // 
            // ck_ignore
            // 
            this.ck_ignore.AutoSize = true;
            this.ck_ignore.Checked = true;
            this.ck_ignore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_ignore.Dock = System.Windows.Forms.DockStyle.Right;
            this.ck_ignore.Location = new System.Drawing.Point(327, 0);
            this.ck_ignore.Name = "ck_ignore";
            this.ck_ignore.Size = new System.Drawing.Size(120, 47);
            this.ck_ignore.TabIndex = 2;
            this.ck_ignore.Text = "忽略已存在的文件";
            this.ck_ignore.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(447, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "全部生成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ckall_build);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(74, 47);
            this.panel4.TabIndex = 0;
            // 
            // ckall_build
            // 
            this.ckall_build.AutoSize = true;
            this.ckall_build.Location = new System.Drawing.Point(16, 16);
            this.ckall_build.Name = "ckall_build";
            this.ckall_build.Size = new System.Drawing.Size(48, 16);
            this.ckall_build.TabIndex = 0;
            this.ckall_build.Text = "全选";
            this.ckall_build.UseVisualStyleBackColor = true;
            this.ckall_build.CheckedChanged += new System.EventHandler(this.ckall_build_CheckedChanged);
            // 
            // AutoGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 459);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AutoGeneration";
            this.Text = "后台代码生成";
            this.Load += new System.EventHandler(this.AutoGeneration_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_table)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gv_table;
        private System.Windows.Forms.CheckBox ckall;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ck;
        private System.Windows.Forms.DataGridViewTextBoxColumn tablename;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabledescription;
        private System.Windows.Forms.Panel pnl_main;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox ckall_build;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ck_ignore;
    }
}