namespace RC.UI.DeveloperTools.Control
{
    partial class uc_template
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
            this.btndelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txttemplate = new System.Windows.Forms.TextBox();
            this.txttemplatepath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcreatepath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btmtemplate = new System.Windows.Forms.Button();
            this.btnbuild = new System.Windows.Forms.Button();
            this.txtnamespace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtformat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ckcanuse = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Bisque;
            this.btndelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btndelete.Location = new System.Drawing.Point(794, 0);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(44, 78);
            this.btndelete.TabIndex = 1;
            this.btndelete.Text = "删除";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "模板名称";
            // 
            // txttemplate
            // 
            this.txttemplate.Location = new System.Drawing.Point(90, 3);
            this.txttemplate.Name = "txttemplate";
            this.txttemplate.Size = new System.Drawing.Size(116, 21);
            this.txttemplate.TabIndex = 3;
            // 
            // txttemplatepath
            // 
            this.txttemplatepath.Location = new System.Drawing.Point(272, 3);
            this.txttemplatepath.Name = "txttemplatepath";
            this.txttemplatepath.Size = new System.Drawing.Size(252, 21);
            this.txttemplatepath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "模板路径";
            // 
            // txtcreatepath
            // 
            this.txtcreatepath.Location = new System.Drawing.Point(272, 28);
            this.txtcreatepath.Name = "txtcreatepath";
            this.txtcreatepath.Size = new System.Drawing.Size(252, 21);
            this.txtcreatepath.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "生成路径";
            // 
            // btmtemplate
            // 
            this.btmtemplate.Location = new System.Drawing.Point(529, 3);
            this.btmtemplate.Name = "btmtemplate";
            this.btmtemplate.Size = new System.Drawing.Size(37, 23);
            this.btmtemplate.TabIndex = 8;
            this.btmtemplate.Text = "设置";
            this.btmtemplate.UseVisualStyleBackColor = true;
            this.btmtemplate.Click += new System.EventHandler(this.btmtemplate_Click);
            // 
            // btnbuild
            // 
            this.btnbuild.Location = new System.Drawing.Point(529, 26);
            this.btnbuild.Name = "btnbuild";
            this.btnbuild.Size = new System.Drawing.Size(37, 23);
            this.btnbuild.TabIndex = 9;
            this.btnbuild.Text = "设置";
            this.btnbuild.UseVisualStyleBackColor = true;
            this.btnbuild.Click += new System.EventHandler(this.btnbuild_Click);
            // 
            // txtnamespace
            // 
            this.txtnamespace.Location = new System.Drawing.Point(90, 28);
            this.txtnamespace.Name = "txtnamespace";
            this.txtnamespace.Size = new System.Drawing.Size(116, 21);
            this.txtnamespace.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "命名空间";
            // 
            // txtformat
            // 
            this.txtformat.Location = new System.Drawing.Point(90, 54);
            this.txtformat.Name = "txtformat";
            this.txtformat.Size = new System.Drawing.Size(116, 21);
            this.txtformat.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "文件名Format";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "（表名通配符：$Table$）";
            // 
            // ckcanuse
            // 
            this.ckcanuse.AutoSize = true;
            this.ckcanuse.Dock = System.Windows.Forms.DockStyle.Right;
            this.ckcanuse.Location = new System.Drawing.Point(746, 0);
            this.ckcanuse.Name = "ckcanuse";
            this.ckcanuse.Size = new System.Drawing.Size(48, 78);
            this.ckcanuse.TabIndex = 17;
            this.ckcanuse.Text = "启用";
            this.ckcanuse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckcanuse.UseVisualStyleBackColor = true;
            // 
            // uc_template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ckcanuse);
            this.Controls.Add(this.txtformat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtnamespace);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnbuild);
            this.Controls.Add(this.btmtemplate);
            this.Controls.Add(this.txtcreatepath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txttemplatepath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttemplate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btndelete);
            this.Name = "uc_template";
            this.Size = new System.Drawing.Size(838, 78);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttemplate;
        private System.Windows.Forms.TextBox txttemplatepath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcreatepath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btmtemplate;
        private System.Windows.Forms.Button btnbuild;
        private System.Windows.Forms.TextBox txtnamespace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtformat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckcanuse;
    }
}
