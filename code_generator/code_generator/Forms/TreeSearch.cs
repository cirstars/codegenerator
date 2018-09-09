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
using RC.UI.DeveloperTools.BLL;

namespace RC.UI.DeveloperTools.Forms
{
    public partial class TreeSearch : Form
    {
        public TreeSearch()
        {
            InitializeComponent();
        }
        private ModuleManageBLL _bll;

        public delegate void AfterSelectNode(string name,long key);

        public event AfterSelectNode AfterSelectNodeHandler;

        private void TreeSearch_Load(object sender, EventArgs e)
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
            }
            tv_list.ExpandAll();
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
            lblcurr.Text = e.Node.Text;
            CurrentNode = e.Node;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CurrentNode != null)
            {
                if (AfterSelectNodeHandler != null)
                {
                    AfterSelectNodeHandler(CurrentNode.Text, long.Parse(CurrentNode.Name));
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("请选择父级目录！");
            }
        }


    }
}
