namespace RC.UI.DeveloperTools.Control
{
    partial class uc_dbtooltip
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
            this.lable1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblprovider = new System.Windows.Forms.Label();
            this.lbldbaddr = new System.Windows.Forms.Label();
            this.lbluser = new System.Windows.Forms.Label();
            this.lblpwd = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(2, 29);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(77, 12);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "数据库地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "引擎：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "用户名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码：";
            // 
            // lblprovider
            // 
            this.lblprovider.AutoSize = true;
            this.lblprovider.Location = new System.Drawing.Point(85, 7);
            this.lblprovider.Name = "lblprovider";
            this.lblprovider.Size = new System.Drawing.Size(41, 12);
            this.lblprovider.TabIndex = 4;
            this.lblprovider.Text = "引擎：";
            // 
            // lbldbaddr
            // 
            this.lbldbaddr.AutoSize = true;
            this.lbldbaddr.Location = new System.Drawing.Point(85, 29);
            this.lbldbaddr.Name = "lbldbaddr";
            this.lbldbaddr.Size = new System.Drawing.Size(41, 12);
            this.lbldbaddr.TabIndex = 5;
            this.lbldbaddr.Text = "引擎：";
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.Location = new System.Drawing.Point(85, 50);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(41, 12);
            this.lbluser.TabIndex = 6;
            this.lbluser.Text = "引擎：";
            // 
            // lblpwd
            // 
            this.lblpwd.AutoSize = true;
            this.lblpwd.Location = new System.Drawing.Point(209, 50);
            this.lblpwd.Name = "lblpwd";
            this.lblpwd.Size = new System.Drawing.Size(41, 12);
            this.lblpwd.TabIndex = 7;
            this.lblpwd.Text = "引擎：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "删";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uc_dbtooltip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblpwd);
            this.Controls.Add(this.lbluser);
            this.Controls.Add(this.lbldbaddr);
            this.Controls.Add(this.lblprovider);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lable1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "uc_dbtooltip";
            this.Size = new System.Drawing.Size(286, 70);
            this.Load += new System.EventHandler(this.uc_dbtooltip_Load);
            this.Click += new System.EventHandler(this.uc_dbtooltip_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblprovider;
        private System.Windows.Forms.Label lbldbaddr;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.Label lblpwd;
        private System.Windows.Forms.Button button1;
    }
}
