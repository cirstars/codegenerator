using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RC.UI.DeveloperTools.Common;
using RC.UI.DeveloperTools.Control;

namespace RC.UI.DeveloperTools.Forms
{
    public partial class TemplateForm : Form
    {
        public TemplateForm()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            uc_template control = new uc_template();
            control.DeleteControlHandler += tmp_DeleteControlHandler;
            control.Dock = DockStyle.Top;
            pnl_main.Controls.Add(control);
        }


        //更新到配置文件
        private void button1_Click(object sender, EventArgs e)
        {
            //保存到文件
            List<uc_template_source> config = new List<uc_template_source>();
            foreach (uc_template contorl in pnl_main.Controls)
            {
                config.Add(contorl.GetDataSource());
            }

            FileHelper.WriteFile("//temp//templateconfig.json",
                config.Count > 0 ? JsonConvert.SerializeObject(config) : "");
            MessageBox.Show("更新成功！");
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            try
            {
                string a = FileHelper.ReadFile("//temp//templateconfig.json");
                if (!string.IsNullOrWhiteSpace(a))
                {
                    var list = JsonConvert.DeserializeObject<List<uc_template_source>>(a);
                    foreach (var li in list)
                    {
                        uc_template tmp = new uc_template();
                        tmp.Dock = DockStyle.Top;
                        tmp.DataSource = new uc_template_source()
                        {
                            Enable = li.Enable,
                            TemplateName = li.TemplateName,
                            TemplatePath = li.TemplatePath,
                            BuildPath = li.BuildPath,
                            NameSpaceName = li.NameSpaceName,
                            Format = li.Format
                        };
                        tmp.DataBind();
                        tmp.DeleteControlHandler += tmp_DeleteControlHandler;
                        pnl_main.Controls.Add(tmp);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" 读取配置失败！详细信息：" + ex.ToString());
            }
        }

        private void tmp_DeleteControlHandler(System.Windows.Forms.Control control)
        {
            pnl_main.Controls.Remove(control);
            ////保存到文件
            //List<uc_template_source> conifg = new List<uc_template_source>();
            //foreach (uc_template contorl in pnl_main.Controls)
            //{
            //    conifg.Add(contorl.GetDataSource());
            //}

            //FileHelper.WriteFile("//temp//templateconfig.json",
            //    conifg.Count > 0 ? JsonConvert.SerializeObject(conifg) : "");
        }

        private void TemplateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<uc_template_source> conifg = new List<uc_template_source>();
            foreach (uc_template contorl in pnl_main.Controls)
            {
                conifg.Add(contorl.GetDataSource());
            }
            string a = FileHelper.ReadFile("//temp//templateconfig.json");
            if (JsonConvert.SerializeObject(conifg) != a)
            {
                DialogResult result = MessageBox.Show("检测到配置已经更改，是否保存？","提示",MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                    {
                        button1_Click(null,null);
                        break;
                    }
                    case DialogResult.No:
                    {
                        break;
                    }
                    case DialogResult.Cancel:
                    {
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }
    }
}
