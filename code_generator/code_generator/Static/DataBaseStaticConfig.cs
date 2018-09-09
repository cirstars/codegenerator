using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.UI.DeveloperTools.Control;

namespace RC.UI.DeveloperTools.Static
{
    public static class DataBaseStaticConfig
    {
        static DataBaseStaticConfig()
        {
            Config = new uc_statusbar_datasource();
        }
        public static uc_statusbar_datasource Config { get; set; }
    }
}
