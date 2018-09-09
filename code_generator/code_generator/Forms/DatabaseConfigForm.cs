using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RC.UI.DeveloperTools.BLL;
using RC.UI.DeveloperTools.Common;
using RC.UI.DeveloperTools.Control;
using RC.UI.DeveloperTools.Static;

namespace RC.UI.DeveloperTools.Forms
{
    public partial class DatabaseConfigForm : Form
    {
        public DatabaseConfigForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uc_dbtooltip tip = new uc_dbtooltip();
            tip.DataSource = new uc_statusbar_datasource()
            {
                provider = txtprovider.Text,
                dbaddr = dbaddr.Text,
                username = username.Text,
                userpwd = userpwd.Text,
            };
            tip.Databind();
            tip.SelectedHandler += tip_SelectedHandler;
            tip.DeleteControlHandler += tip_DeleteControlHandler;
            tip.Dock = DockStyle.Top;
            pnldb.Controls.Add(tip);

            //保存到文件
            List<uc_statusbar_datasource> conifg = new List<uc_statusbar_datasource>();
            foreach (uc_dbtooltip contorl in pnldb.Controls)
            {
                conifg.Add(contorl.DataSource);
            }

            FileHelper.WriteFile("//temp//dbconfig.json", JsonConvert.SerializeObject(conifg));
        }

        private void DatabaseConfigForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            try
            {
                string a = FileHelper.ReadFile("//temp//dbconfig.json");
                if (!string.IsNullOrWhiteSpace(a))
                {
                    var list = JsonConvert.DeserializeObject<List<uc_statusbar_datasource>>(a);
                    foreach (var li in list)
                    {
                        uc_dbtooltip tip = new uc_dbtooltip();
                        tip.Dock = DockStyle.Top;
                        tip.DataSource = new uc_statusbar_datasource()
                        {
                            provider = li.provider,
                            dbaddr = li.dbaddr,
                            username = li.username,
                            userpwd = li.userpwd,
                        };
                        tip.Databind();
                        tip.SelectedHandler += tip_SelectedHandler;
                        tip.DeleteControlHandler += tip_DeleteControlHandler;
                        pnldb.Controls.Add(tip);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" 读取配置失败！详细信息：" + ex.ToString());
            }

        }

        void tip_DeleteControlHandler(System.Windows.Forms.Control control)
        {
            pnldb.Controls.Remove(control);
            //保存到文件
            List<uc_statusbar_datasource> conifg = new List<uc_statusbar_datasource>();
            foreach (uc_dbtooltip contorl in pnldb.Controls)
            {
                conifg.Add(contorl.DataSource);
            }

            FileHelper.WriteFile("//temp//dbconfig.json", JsonConvert.SerializeObject(conifg));
        }

        private void tip_SelectedHandler(uc_statusbar_datasource source)
        {
            txtprovider.Text = source.provider;
            dbaddr.Text = source.dbaddr;
            username.Text = source.username;
            userpwd.Text = source.userpwd;
        }

        private void dbname_Click(object sender, EventArgs e)
        {
            //根据配置 获取数据库列表
            if (!string.IsNullOrWhiteSpace(txtprovider.Text)
                && !string.IsNullOrWhiteSpace(dbaddr.Text)
                && !string.IsNullOrWhiteSpace(username.Text)
                && !string.IsNullOrWhiteSpace(userpwd.Text))
            {
                IDataBaseInfoBll bll = DataBaseInfoFactory.GetDataBaseInfoBll(txtprovider.Text);

                List<string> list = bll.GetAllDatabaseName(new uc_statusbar_datasource()
                {
                    provider = txtprovider.Text,
                    dbaddr = dbaddr.Text,
                    username = username.Text,
                    userpwd = userpwd.Text
                });

                dbname.DataSource = list;
            }
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtprovider.Text)
                && !string.IsNullOrWhiteSpace(dbaddr.Text)
                && !string.IsNullOrWhiteSpace(username.Text)
                && !string.IsNullOrWhiteSpace(userpwd.Text)
                && !string.IsNullOrWhiteSpace(dbname.Text))
            {
                DataBaseStaticConfig.Config = new uc_statusbar_datasource()
                {
                    dbname = dbname.Text,
                    userpwd = userpwd.Text,
                    username = username.Text,
                    provider = txtprovider.Text,
                    dbaddr = dbaddr.Text
                };
                this.Close();
            }
            else
            {
                MessageBox.Show("信息不全！");
            }
            
        }
    }
}
