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
    public partial class uc_template : UserControl
    {
        private uc_template_source _dataSource;

        public uc_template()
        {
            InitializeComponent();
        }

        public uc_template_source DataSource
        {
            get
            {
                //_dataSource.BuildPath = txtcreatepath.Text;
                //_dataSource.Format = txtformat.Text;
                //_dataSource.NameSpaceName = txtnamespace.Text;
                //_dataSource.TemplateName = txttemplate.Text;
                //_dataSource.TemplatePath = txttemplatepath.Text;
                //_dataSource.Enable = ckcanuse.Checked;
                return _dataSource;
            }
            set { _dataSource = value; }
        }

        public uc_template_source GetDataSource()
        {
            if (DataSource == null)
            {
                DataSource = new uc_template_source();
            }
            DataSource.BuildPath = txtcreatepath.Text;
            DataSource.Format = txtformat.Text;
            DataSource.NameSpaceName = txtnamespace.Text;
            DataSource.TemplateName = txttemplate.Text;
            DataSource.TemplatePath = txttemplatepath.Text;
            DataSource.Enable = ckcanuse.Checked;
            return DataSource;
        }

        public delegate void DeleteControl(System.Windows.Forms.Control control);
        public event DeleteControl DeleteControlHandler;
        public void DataBind()
        {
            if (DataSource != null)
            {
                txtcreatepath.Text = DataSource.BuildPath;
                txtformat.Text = DataSource.Format;
                txtnamespace.Text = DataSource.NameSpaceName;
                txttemplate.Text = DataSource.TemplateName;
                txttemplatepath.Text = DataSource.TemplatePath;
                ckcanuse.Checked = DataSource.Enable;
            }
        }

        public void SetDisabled()
        {
            btndelete.Visible = false;
            ckcanuse.Visible = false;
            btmtemplate.Visible = false;
            btnbuild.Visible = false;
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (control.GetType() == typeof (TextBox))
                {
                    control.Enabled = false;
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (DeleteControlHandler != null)
            {
                DeleteControlHandler.DynamicInvoke(this);
            }
        }

        private void btmtemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "模板文件|*.cshtml";
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txttemplatepath.Text = dialog.FileName;
            }
            
        }

        private void btnbuild_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Application.StartupPath;
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtcreatepath.Text = dialog.SelectedPath;
            }
        }

    }

    public class uc_template_source
    {
        public string TemplateName { get; set; }
        public string NameSpaceName { get; set; }
        public string Format { get; set; }
        public string TemplatePath { get; set; }
        public string BuildPath { get; set; }
        public bool Enable { get; set; }
    }
}
