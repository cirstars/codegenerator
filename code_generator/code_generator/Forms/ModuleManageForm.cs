using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RC.BLL.BllFactory;
using RC.BLL.IBll;
using RC.Common.Utilities;
using RC.Dal.DalFactory;
using RC.Model.DataModel;
using RC.UI.DeveloperTools.BLL;
using RC.UI.DeveloperTools.Static;

namespace RC.UI.DeveloperTools.Forms
{
    public partial class ModuleManageForm : Form
    {
        public ModuleManageForm()
        {
            InitializeComponent();
            gv_module.AutoGenerateColumns = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CurrentNode == null)
            {
                MessageBox.Show("请选择菜单！");
                return;
            }

            ModuleManageEditForm frm = new ModuleManageEditForm();
            frm.FormMode = ModuleManageEditForm.EditType.Add;
            frm.DataSource = new Base_Module();
            frm.ParentName = CurrentNode.Text;
            frm.ParentID = long.Parse(CurrentNode.Name);
            frm.DataBind();
            frm.AfterUpdateHandler += frm_Closed;
            frm.Dock = DockStyle.Fill;
            frm.ShowDialog();
        }

        private ModuleManageBLL _bll;
        private void ModuleManageForm_Load(object sender, EventArgs e)
        {
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
        private TreeNode CurrentNode { get; set; }
        private void tv_list_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CurrentNode = e.Node;

            //绑定列表
            var list = _bll.GetBase_ModuleByParent(long.Parse(CurrentNode.Name));
            gv_module.DataSource = list;
        }

        private void gv_module_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (gv_module.SelectedRows.Count > 0)
            {
                var list = (List<Base_Module>) gv_module.DataSource;
                ModuleManageEditForm frm = new ModuleManageEditForm();
                frm.FormMode = ModuleManageEditForm.EditType.Edit;
                frm.DataSource = list[gv_module.SelectedRows[0].Index];
                frm.ParentID = list[gv_module.SelectedRows[0].Index].ParentId.Value;
                frm.ParentName = CurrentNode.Text;
                frm.DataBind();
                frm.AfterUpdateHandler += frm_Closed;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择一条记录！");
            }
        }

        void frm_Closed()
        {
            var list = _bll.GetBase_ModuleByParent(long.Parse(CurrentNode.Name));
            gv_module.DataSource = list;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (gv_module.SelectedRows.Count > 0)
            {
                var list = (List<Base_Module>)gv_module.DataSource;
                DialogResult dialog = MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    _bll.DeleteBase_Module(list[gv_module.SelectedRows[0].Index]);
                    gv_module.DataSource = _bll.GetBase_ModuleByParent(long.Parse(CurrentNode.Name));
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
    }
}
