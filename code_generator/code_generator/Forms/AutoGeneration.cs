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
using RC.UI.DeveloperTools.BLL;
using RC.UI.DeveloperTools.Common;
using RC.UI.DeveloperTools.Control;
using RC.UI.DeveloperTools.Static;
using System.IO;

namespace RC.UI.DeveloperTools.Forms
{
    public partial class AutoGeneration : Form
    {
        public AutoGeneration()
        {
            InitializeComponent();
        }

        private void AutoGeneration_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!string.IsNullOrWhiteSpace(DataBaseStaticConfig.Config.provider)
                && !string.IsNullOrWhiteSpace(DataBaseStaticConfig.Config.username)
                && !string.IsNullOrWhiteSpace(DataBaseStaticConfig.Config.dbaddr)
                && !string.IsNullOrWhiteSpace(DataBaseStaticConfig.Config.dbname)
                && !string.IsNullOrWhiteSpace(DataBaseStaticConfig.Config.userpwd))
            {
                IDataBaseInfoBll bll = DataBaseInfoFactory.GetDataBaseInfoBll(DataBaseStaticConfig.Config.provider);
                var list = bll.GetTableList();
                gv_table.DataSource = list;
                
                //读取配置文件
                try
                {
                    string a = FileHelper.ReadFile("//temp//templateconfig.json");
                    if (!string.IsNullOrWhiteSpace(a))
                    {
                        var listTemplate = JsonConvert.DeserializeObject<List<uc_template_source>>(a);
                        foreach (var li in listTemplate.Where(o => o.Enable))
                        {
                            uc_templatereadonly tmp = new uc_templatereadonly();
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
                            tmp.buildcodeHandler += tmp_buildcodeHandler;
                            pnl_main.Controls.Add(tmp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" 读取配置失败！详细信息：" + ex.ToString());
                }
            }
        }

        void tmp_buildcodeHandler(uc_template_source source)
        {
            try
            {
                buildcode_start();
                buildcode_process(source);
                buildcode_end();
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成失败！" + ex.ToString());
            }
        }

        private void ckall_CheckedChanged(object sender, EventArgs e)
        {
            if (ckall.Checked)
            {
                List<TableInfo> source = (List<TableInfo>) gv_table.DataSource;
                source.ForEach(o => o.ck = true);
                gv_table.DataSource = source;
                gv_table.Refresh();
            }
            else
            {
                List<TableInfo> source = (List<TableInfo>)gv_table.DataSource;
                source.ForEach(o => o.ck = false);
                gv_table.DataSource = source;
                gv_table.Refresh();
            }
        }

        private void ckall_build_CheckedChanged(object sender, EventArgs e)
        {
            foreach (uc_templatereadonly control in pnl_main.Controls)
            {
                control.SetSelected(ckall_build.Checked);
            }
        }

        /// <summary>
        /// 全部生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool isexist = pnl_main.Controls.Cast<uc_templatereadonly>().Any(control => control.Selected);
                if (isexist)
                {
                    buildcode_start();
                    pnl_main.Controls.Cast<uc_templatereadonly>().Where(o => o.Selected).All(o =>
                    {
                        buildcode_process(o.GetDataSource());
                        return true;
                    });
                    buildcode_end();

                }
                else
                {
                    MessageBox.Show("未选中要生成的模板！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成失败！" + ex.ToString());
            }
           

        }
        #region 生成

        private void buildcode_start()
        {

        }
        private void buildcode_process(uc_template_source source)
        {
            var databaselist = (List<TableInfo>)gv_table.DataSource;
            foreach (TableInfo table in databaselist.Where(o=>o.ck))
            {
                ViewRazor razor = new ViewRazor();
                string filename = source.Format.Replace("$Table$", table.name);
                string file = source.BuildPath + "//" + filename + ".cs";
                if (File.Exists(file) && ck_ignore.Checked)
                {
                    continue;
                }
                IDataBaseInfoBll bll = DataBaseInfoFactory.GetDataBaseInfoBll(DataBaseStaticConfig.Config.provider);
                var list = bll.GetColumnList(table.name);

                ViewModel_back model = new ViewModel_back();
                model.FormatTablename = filename;
                model.TableInfo = table;
                model.Colums = list;
                model.DataBaseName = Static.DataBaseStaticConfig.Config.dbname;
                model.NameSpace = source.NameSpaceName;
                model.Tables = databaselist.Where(o => o.ck).ToList();

                razor.OutputEncoding = Encoding.UTF8;
                razor.TemplateUrl = source.TemplatePath;
                razor.SaveUrl = file;
                razor.ToPageNoMaster(model);
            }
        }
        private void buildcode_end()
        {
            MessageBox.Show("生成成功！");
        }

        #endregion
       


    }
}
