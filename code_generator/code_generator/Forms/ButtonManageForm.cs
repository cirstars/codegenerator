using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RC.Common.Utilities;
using RC.Model.DataModel;
using RC.UI.DeveloperTools.BLL;
using RC.UI.DeveloperTools.Static;

namespace RC.UI.DeveloperTools.Forms
{
    public partial class ButtonManageForm : Form
    {
        public ButtonManageForm()
        {
            InitializeComponent();
        }
        private ModuleManageBLL _bll;
        private TreeNode CurrentNode { get; set; }
        private void ButtonManageForm_Load(object sender, EventArgs e)
        {
            gv_module.AutoGenerateColumns = false;

            if (DesignMode) return;
            if (!string.IsNullOrWhiteSpace(DataBaseStaticConfig.Config.provider)
                && !string.IsNullOrWhiteSpace(DataBaseStaticConfig.Config.username)
                && !string.IsNullOrWhiteSpace(DataBaseStaticConfig.Config.dbaddr)
                && !string.IsNullOrWhiteSpace(DataBaseStaticConfig.Config.dbname)
                && !string.IsNullOrWhiteSpace(DataBaseStaticConfig.Config.userpwd))
            {
                _bll = new ModuleManageBLL();
                var list = _bll.GetTreeEntity();
                foreach (WdTreeNode item in list.Where(o => o.parentId == "0"))
                {
                    TreeNode node = new TreeNode();
                    node.Text = item.text;
                    node.Name = item.id.ToString();
                    tv_list.Nodes.Add(node);
                    bindnodes(node, list);
                    if (tv_list.Nodes.Count > 0)
                    {
                        tv_list.TopNode.Expand();
                    }
                }

            }
        }

        public void bindnodes(TreeNode node, List<WdTreeNode> source)
        {
            foreach (WdTreeNode item in source.Where(o => o.parentId.ToString() == node.Name).ToList())
            {
                TreeNode child = new TreeNode();
                child.Text = item.text;
                child.Name = item.id.ToString();
                node.Nodes.Add(child);
                bindnodes(child, source);
            }
        }

        private void tv_list_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CurrentNode = e.Node;

            //绑定列表
            var list = _bll.GetBase_ButtonByModule(long.Parse(CurrentNode.Name));
            gv_module.DataSource = list;
        }

        private void gv_module_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CurrentNode == null)
            {
                MessageBox.Show("请选择模块！");
                return;
            }

            ButtonManageEditForm frm = new ButtonManageEditForm();
            frm.FormMode = ButtonManageEditForm.EditType.Add;
            frm.DataSource = new Base_Button();
            frm.ModuleID = long.Parse(CurrentNode.Name);
            frm.DataBind();
            frm.AfterUpdateHandler += frm_Closed;
            frm.Dock = DockStyle.Fill;
            frm.ShowDialog();
        }
        void frm_Closed()
        {
            var list = _bll.GetBase_ButtonByModule(long.Parse(CurrentNode.Name));
            gv_module.DataSource = list;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (gv_module.SelectedRows.Count > 0)
            {
                var list = (List<Base_Button>)gv_module.DataSource;
                ButtonManageEditForm frm = new ButtonManageEditForm();
                frm.FormMode = ButtonManageEditForm.EditType.Edit;
                frm.DataSource = list[gv_module.SelectedRows[0].Index];
                frm.ModuleID = long.Parse(CurrentNode.Name);
                frm.DataBind();
                frm.AfterUpdateHandler += frm_Closed;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择一条记录！");
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (gv_module.SelectedRows.Count > 0)
            {
                var list = (List<Base_Button>)gv_module.DataSource;
                DialogResult dialog = MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    var item = list[gv_module.SelectedRows[0].Index];
                    _bll.DeleteBase_Button(_bll.GetBaseButton(item.ButtonId));
                    gv_module.DataSource = _bll.GetBase_ButtonByModule(long.Parse(CurrentNode.Name));
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("请选择一条记录！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gv_module.SelectedRows.Count > 0)
            {
                var list = (List<Base_Button>) gv_module.DataSource;
                Base_Button source = list[gv_module.SelectedRows[0].Index];
                TreeSearch frm = new TreeSearch();
                frm.AfterSelectNodeHandler += (x, y) =>
                {
                    source.ButtonId = 0;
                    source.ParentId = 0;
                    source.ModuleId = y;
                    source.Category = source.Category == "工具栏" ? "1" : "2";
                    _bll.AddBase_Button(source);
                };
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择一条记录！");
            }
        }





    }
}
