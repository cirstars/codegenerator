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
    public partial class uc_templatereadonly : UserControl
    {
        public delegate void BuildCode(uc_template_source source);

        public event BuildCode buildcodeHandler;

        public uc_templatereadonly()
        {
            InitializeComponent();
            
        }

        private void btnbuilder_Click(object sender, EventArgs e)
        {
            if (buildcodeHandler != null)
            {
                buildcodeHandler.DynamicInvoke(GetDataSource());
            }
        }

        private void uc_templatereadonly_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                this.uc_template1.SetDisabled();
            }
        }

        public uc_template_source DataSource { get; set; }

        public void DataBind()
        {
            this.uc_template1.DataSource = DataSource;
            this.uc_template1.DataBind();
        }

        public uc_template_source GetDataSource()
        {
            return this.uc_template1.GetDataSource();
        }

        public void SetSelected(bool check)
        {
            this.checkBox1.Checked = check;
        }

        public bool Selected
        {
            get { return this.checkBox1.Checked; }
            set { this.checkBox1.Checked = value; }
        }
    }
}
