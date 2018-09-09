using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RC.UI.DeveloperTools.BLL;

namespace RC.UI.DeveloperTools.Forms
{
    public partial class ButtonSearch : Form
    {
        public delegate void AfterSelectNode(long buttonid, string buttontext);

        public event AfterSelectNode AfterSelectNodeHandler;

        public ButtonSearch()
        {
            InitializeComponent();
        }
        public long? ModuleID { get; set; }
        public long ButtonID { get; set; }

        private ModuleManageBLL _bll = new ModuleManageBLL();
        private void ButtonSearch_Load(object sender, EventArgs e)
        {
            if (ModuleID.HasValue)
            {
                var source = _bll.GetBase_ButtonByModule(ModuleID.Value);
                if (source.Count > 0)
                {
                    foreach (var item in source)
                    {
                        if (ButtonID == item.ButtonId) continue;
                        tree.Nodes.Add(new TreeNode()
                        {
                            Text = item.FullName,
                            Name = item.ButtonId.ToString(),
                        });
                    }
                }
            }
        }

        private void tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (AfterSelectNodeHandler != null)
            {
                AfterSelectNodeHandler(long.Parse(e.Node.Name), e.Node.Text);
                this.Close();
            }
        }
    }
}
