using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.UI.DeveloperTools.Common
{
    public class TableColums
    {
        public string tablename { get; set; }
        public string number { get; set; }
        public string column { get; set; }
        public string datatype { get; set; }
        public string length { get; set; }
        public string identity { get; set; }
        public string key { get; set; }
        public string isnullable { get; set; }
        public string defaultvalue { get; set; }
        public string remark { get; set; }
    }
}
