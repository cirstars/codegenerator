
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.UI.DeveloperTools.Common
{
    public class ViewModel_back
    {
        public ViewModel_back()
        {
            TableInfo = new TableInfo();
            Colums = new List<TableColums>();
            Tables = new List<TableInfo>();
        }
        public TableInfo TableInfo { get; set; }
        public List<TableColums> Colums { get; set; }
        public string DataBaseName { get; set; }
        public string FormatTablename { get; set; }
        public string NameSpace { get; set; }

        public List<TableInfo> Tables { get; set; }
    }
}
