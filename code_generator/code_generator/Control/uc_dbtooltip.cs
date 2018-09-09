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
    public partial class uc_dbtooltip : UserControl
    {
        public delegate void Selected(uc_statusbar_datasource source);

        public event Selected SelectedHandler;

        public delegate void DeleteControl(System.Windows.Forms.Control control);
        public event DeleteControl DeleteControlHandler;

        public uc_dbtooltip()
        {
            InitializeComponent();
            DataSource = new uc_statusbar_datasource();
        }
        public uc_statusbar_datasource DataSource { get; set; }

        public void Databind()
        {
            if (DataSource != null)
            {
                lbldbaddr.Text = DataSource.dbaddr;
                lbluser.Text = DataSource.username;
                lblpwd.Text = DataSource.userpwd;
                lblprovider.Text = DataSource.provider;
                
            }
        }

        private void uc_dbtooltip_Click(object sender, EventArgs e)
        {
            if (SelectedHandler != null) SelectedHandler.Invoke(DataSource);
        }

        private void uc_dbtooltip_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(DeleteControlHandler!=null) DeleteControlHandler.DynamicInvoke(this);
        }
    }
}
