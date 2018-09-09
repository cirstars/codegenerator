using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RC.UI.DeveloperTools.Control;

namespace RC.UI.DeveloperTools.Forms
{
    public partial class IconSetForm : Form
    {
        public delegate void AfterSelectPicture(string filename);

        public event AfterSelectPicture AfterSelectPictureHandler;
        public IconSetForm()
        {
            InitializeComponent();
        }
        List<string> listpath = new List<string>();
        private void IconSetForm_Load(object sender, EventArgs e)
        {

            DirectoryInfo TheFolder = new DirectoryInfo(Application.StartupPath + "//Resources//");
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                listpath.Add(NextFile.Name);
            }
            double aa = (int)Math.Ceiling((double)listpath.Count / pagesize);
            pagecount2 = Convert.ToInt32(aa);
            iconbind();
        }

        void uc_AfterSelectPictureHandler(string filename)
        {
            if (AfterSelectPictureHandler != null)
            {
                AfterSelectPictureHandler.DynamicInvoke(filename);
            }
            this.Close();
        }

        public int pagesize = 250;
        public int page = 1;
        public int pagecount2;
        public void iconbind()
        {
            
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in listpath.OrderBy(o => o).Skip((page - 1) * pagesize).Take(pagesize))
            {
                uc_image uc = new uc_image();
                uc.PicturePath = item;
                uc.AfterSelectPictureHandler += uc_AfterSelectPictureHandler;
                uc.DataBind();
                flowLayoutPanel1.Controls.Add(uc);
            }
            pagecount.Text = pagecount2.ToString();
            currpage.Text = page.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (page == 1) return;
            page = page - 1;
            iconbind();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (page == pagecount2) return;
            page = page + 1;
            iconbind();
        }


    }
}
