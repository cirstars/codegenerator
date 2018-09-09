using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RC.UI.DeveloperTools.Control
{
    public partial class uc_statusbar : UserControl
    {
        public uc_statusbar_datasource DataSource { get; set; }
        public uc_statusbar()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                DataSource = new uc_statusbar_datasource();
            }
        }

        private void uc_statusbar_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            statusbar.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            lbl_zhuangbi.Alignment = ToolStripItemAlignment.Right;
            DataBind();
        }

        public void DataBind()
        {
            this.statusbar_db.Text = DataSource.dbaddr;
            this.statususer.Text = DataSource.username;
            this.statuspwd.Text = DataSource.userpwd;
            this.status_dbname.Text = DataSource.dbname;
        }

    }

    public class uc_statusbar_datasource
    {
        public string dbaddr { get; set; }
        public string dbname { get; set; }
        public string username { get; set; }
        public string userpwd { get; set; }
        public string provider { get; set; }
    }
}
