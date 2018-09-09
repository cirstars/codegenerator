using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RC.Model.DataModel;
using RC.UI.DeveloperTools.BLL;

namespace RC.UI.DeveloperTools.Forms
{
    public partial class ModuleManageEditForm : Form
    {
        public delegate void AfterUpdate();
        public event AfterUpdate AfterUpdateHandler;
        public string ParentName { get; set; }
        public long ParentID { get; set; }

        public enum EditType
        {
            Add,
            Edit
        }

        public EditType FormMode { get; set; }
        public ModuleManageEditForm()
        {
            InitializeComponent();
        }
        private ModuleManageBLL _bll = new ModuleManageBLL();
        private void btnok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("模块编码不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("模块名称不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLevel.Text))
            {
                MessageBox.Show("层次级别不能为空！");
                return;
            }
            GetDataSource();
            if (FormMode == EditType.Add)
            {
                _bll.AddBase_Module(DataSource);
                MessageBox.Show("添加成功！");
            }
            else
            {
                _bll.UpdateBase_Module(DataSource);
                MessageBox.Show("更新成功！");
            }
            if (AfterUpdateHandler != null)
            {
                AfterUpdateHandler.DynamicInvoke();
            }
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Base_Module DataSource { get; set; }

        public void GetDataSource()
        {
            if (DataSource == null) DataSource = new Base_Module();

            DataSource.ParentId = ParentID;
            DataSource.AllowButton = ckAllowButton.Checked ? 1 : 0;
            DataSource.AllowForm = ckAllowForm.Checked ? 1 : 0;
            DataSource.AllowView = ckAllowView.Checked ? 1 : 0;
            DataSource.Authority = ckAuthority.Checked ? 1 : 0;
            DataSource.Code = txtCode.Text;
            DataSource.Category = txtCategory.Text;
            DataSource.DataScope = ckDataScope.Checked ? 1 : 0;
            DataSource.Enabled = ckEnabled.Checked ? 1 : 0;
            DataSource.Target = txtTarget.Text;
            DataSource.Icon = txtIcon.Text;
            DataSource.FullName = txtName.Text;
            DataSource.Isexpand = ckIsexpand.Checked ? 1 : 0;
            DataSource.SortCode = int.Parse(txtSort.Text);
            DataSource.Level = int.Parse(txtLevel.Text);
            DataSource.Location = txtLocation.Text;
            DataSource.Remark = txtRemark.Text;

        }

        public void DataBind()
        {
            if (DataSource != null)
            {
                txtParent.Text = ParentName; //DataSource.ParentId.ToString();
                ckAllowButton.Checked = DataSource.AllowButton == 1;
                ckAllowForm.Checked = DataSource.AllowForm == 1;
                ckAllowView.Checked = DataSource.AllowView == 1;
                ckAuthority.Checked = DataSource.Authority == 1;
                txtCode.Text = DataSource.Code;
                txtCategory.Text = DataSource.Category;
                ckDataScope.Checked = DataSource.DataScope == 1;
                ckEnabled.Checked = DataSource.Enabled == 1;
                txtTarget.Text = DataSource.Target;
                txtIcon.Text = DataSource.Icon;
                txtName.Text = DataSource.FullName;
                ckIsexpand.Checked = DataSource.Isexpand == 1;
                txtSort.Text = DataSource.SortCode.ToString();
                txtLevel.Text = DataSource.Level.ToString();
                txtLocation.Text = DataSource.Location;
                txtRemark.Text = DataSource.Remark;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var control in flowLayoutPanel1.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)control).Checked = true;
                }
            }

        }

        private void btnParentSearch_Click(object sender, EventArgs e)
        {
            TreeSearch frm = new TreeSearch();
            frm.AfterSelectNodeHandler += frm_AfterSelectNodeHandler;
            frm.ShowDialog();
        }

        void frm_AfterSelectNodeHandler(string name, long key)
        {
            ParentID = key;
            ParentName = name;
            this.txtParent.Text = ParentName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IconSetForm frm = new IconSetForm();
            frm.AfterSelectPictureHandler += frm_AfterSelectPictureHandler;
            frm.ShowDialog();
        }

        void frm_AfterSelectPictureHandler(string filename)
        {
            this.txtIcon.Text = filename;
        }
    }
}
