using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.UI.DeveloperTools.Control;

namespace RC.UI.DeveloperTools.BLL
{
    public class DataBaseInfoFactory
    {
        public static IDataBaseInfoBll GetDataBaseInfoBll(string provider)
        {
            switch (provider)
            {
                case "System.Data.SqlClient":
                    return new MssqlDataBaseInfoBll();
                default :
                    return null;
            }
        }
    }
}
