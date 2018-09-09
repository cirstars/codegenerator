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
    public partial class ButtonManageEditForm : Form
    {
        public delegate void AfterUpdate();
        public event AfterUpdate AfterUpdateHandler;

        public string ParentName { get; set; }
        public long ParentID { get; set; }

        public long ModuleID { get; set; }

        public ButtonManageEditForm()
        {
            InitializeComponent();
        }

        public enum EditType
        {
            Add,
            Edit
        }
        public EditType FormMode { get; set; }
        private void txtName_TextChanged(object sender, EventArgs e)
        {

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
        public void GetDataSource()
        {
            if (DataSource == null) DataSource = new Base_Button();
            DataSource.ParentId = ParentID;
            DataSource.Split = ckSplit.Checked ? 1 : 0;
            DataSource.Code = txtCode.Text ;
            DataSource.Category = txtCategory.Text == "工具栏" ? "1" : "2";
            DataSource.Enabled = ckEnabled.Checked ? 1 : 0;
            DataSource.JsEvent = txtJsEvent.Text;
            DataSource.Icon = txtIcon.Text;
            DataSource.FullName = txtName.Text;
            DataSource.ActionEvent = txtActionEvent.Text;
            DataSource.SortCode = int.Parse(txtSortCode.Text);
            DataSource.Remark = txtRemark.Text;
            DataSource.ModuleId = ModuleID;

        }
        public void DataBind()
        {
            if (DataSource != null)
            {
                if (DataSource.ParentId.HasValue)
                {
                    ParentID = DataSource.ParentId.Value;
                    var item = _bll.GetBaseButton(ParentID);
                    if (item != null)
                    {
                        txtParent.Text = item.FullName;
                        ParentName = item.FullName;
                    }
                }
                ckSplit.Checked = DataSource.Split == 1;
                txtCode.Text = DataSource.Code;
                txtCategory.Text = (DataSource.Category == "1" || DataSource.Category == "工具栏") ? "工具栏" : "右键栏";
                ckEnabled.Checked = DataSource.Enabled == 1;
                txtJsEvent.Text = DataSource.JsEvent;
                txtIcon.Text = DataSource.Icon;
                txtName.Text = DataSource.FullName;
                txtActionEvent.Text = DataSource.ActionEvent;
                txtSortCode.Text = DataSource.SortCode.ToString();
                txtRemark.Text = DataSource.Remark;

                
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("按钮编码不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("按钮名称不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSortCode.Text))
            {
                MessageBox.Show("显示顺序不能为空！");
                return;
            }
            GetDataSource();
            if (FormMode == EditType.Add)
            {
                _bll.AddBase_Button(DataSource);
                MessageBox.Show("添加成功！");
            }
            else
            {
                _bll.UpdateBase_Button(DataSource);
                MessageBox.Show("更新成功！");
            }
            if (AfterUpdateHandler != null)
            {
                AfterUpdateHandler.DynamicInvoke();
            }
            this.Close();
        }
        private ModuleManageBLL _bll = new ModuleManageBLL();
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Base_Button DataSource { get; set; }

        private void ButtonManageEditForm_Load(object sender, EventArgs e)
        {
            if (DataSource == null)
            {
                ckEnabled.Checked = true;
                txtCategory.Text = "工具栏";
            }
        }

        private void btnParentSearch_Click(object sender, EventArgs e)
        {
            ButtonSearch frm = new ButtonSearch();
            frm.ModuleID = ModuleID;
            frm.ButtonID = DataSource.ButtonId;
            frm.AfterSelectNodeHandler += frm_AfterSelectNodeHandler;
            frm.ShowDialog();
        }

        void frm_AfterSelectNodeHandler(long buttonid,string text)
        {
            txtParent.Text = text;
            ParentID = buttonid;
            ParentName = text;
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
