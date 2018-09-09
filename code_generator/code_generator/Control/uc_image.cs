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
    public partial class uc_image : UserControl
    {
        public delegate void AfterSelectPicture(string filename);

        public event AfterSelectPicture AfterSelectPictureHandler;

        public uc_image()
        {
            InitializeComponent();
        }
        public string PicturePath { get; set; }

        public void DataBind()
        {
            this.pictureBox1.ImageLocation = Application.StartupPath + "//Resources//" + PicturePath;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (AfterSelectPictureHandler != null)
            {
                AfterSelectPictureHandler.DynamicInvoke(PicturePath);
            }
        }
    }
}
