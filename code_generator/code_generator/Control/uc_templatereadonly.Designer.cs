namespace RC.UI.DeveloperTools.Control
{
    partial class uc_templatereadonly
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
            this.btnbuilder = new System.Windows.Forms.Button();
            this.uc_template1 = new RC.UI.DeveloperTools.Control.uc_template();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnbuilder
            // 
            this.btnbuilder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnbuilder.Location = new System.Drawing.Point(895, 0);
            this.btnbuilder.Name = "btnbuilder";
            this.btnbuilder.Size = new System.Drawing.Size(75, 79);
            this.btnbuilder.TabIndex = 1;
            this.btnbuilder.Text = "生成";
            this.btnbuilder.UseVisualStyleBackColor = true;
            this.btnbuilder.Click += new System.EventHandler(this.btnbuilder_Click);
            // 
            // uc_template1
            // 
            this.uc_template1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc_template1.DataSource = null;
            this.uc_template1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_template1.Location = new System.Drawing.Point(46, 0);
            this.uc_template1.Name = "uc_template1";
            this.uc_template1.Size = new System.Drawing.Size(849, 79);
            this.uc_template1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(46, 79);
            this.panel1.TabIndex = 3;
            // 
            // uc_templatereadonly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.uc_template1);
            this.Controls.Add(this.btnbuilder);
            this.Controls.Add(this.panel1);
            this.Name = "uc_templatereadonly";
            this.Size = new System.Drawing.Size(970, 79);
            this.Load += new System.EventHandler(this.uc_templatereadonly_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private uc_template uc_template1;
        private System.Windows.Forms.Button btnbuilder;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
    }
}
