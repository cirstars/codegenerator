using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RC.UI.DeveloperTools.Control;
using RC.UI.DeveloperTools.Forms;

namespace RC.UI.DeveloperTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        uc_statusbar statusbar = new uc_statusbar();
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            #region 状态栏加载

            statusbar.Dock = DockStyle.Fill;
            pnl_status.Controls.Add(statusbar);

            #endregion


        }

        private void 数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pnl_main.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.Form control in pnl_main.Controls)
                {
                    control.Close();
                }
            }

            DatabaseConfigForm frm = new DatabaseConfigForm();
            frm.FormClosed += frm_FormClosed;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnl_main.Controls.Add(frm);
            frm.Show();
            
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            statusbar.DataSource = Static.DataBaseStaticConfig.Config;
            statusbar.DataBind();
        }

        private void 模板管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pnl_main.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.Form control in pnl_main.Controls)
                {
                    control.Close();
                }
            }

            TemplateForm frm = new TemplateForm();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnl_main.Controls.Add(frm);
            frm.Show();
        }

        private void 生成主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pnl_main.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.Form control in pnl_main.Controls)
                {
                    control.Close();
                }
            }

            AutoGeneration frm = new AutoGeneration();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnl_main.Controls.Add(frm);
            frm.Show();
        }

        private void 模块ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pnl_main.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.Form control in pnl_main.Controls)
                {
                    control.Close();
                }
            }
            ModuleManageForm frm = new ModuleManageForm();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnl_main.Controls.Add(frm);
            frm.Show();
        }

        private void 系统按钮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pnl_main.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.Form control in pnl_main.Controls)
                {
                    control.Close();
                }
            }
            ButtonManageForm frm = new ButtonManageForm();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnl_main.Controls.Add(frm);
            frm.Show();
        }

        private void 数据字典ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
