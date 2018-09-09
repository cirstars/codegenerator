using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RC.UI.DeveloperTools.Common
{
    public static class FileHelper
    {
        public static void WriteFile(string path, string model)
        {
            string filepath = Application.StartupPath + path;
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            if (!Directory.Exists(filepath.Substring(0,filepath.LastIndexOf("//"))))
            {
                Directory.CreateDirectory(filepath.Substring(0,filepath.LastIndexOf("//")));
            }

            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            var by = Encoding.UTF8.GetBytes(model);
            fs.Write(by, 0, by.Length);
            fs.Close();
        }

        public static string ReadFile(string path)
        {
            string filepath = Application.StartupPath + path;
            if (!File.Exists(filepath)) return "";
            return File.ReadAllText(filepath, Encoding.UTF8);
        }
    }
}
