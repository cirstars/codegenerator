using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.UI.DeveloperTools.Common;
using RC.UI.DeveloperTools.Control;

namespace RC.UI.DeveloperTools.BLL
{
    public interface IDataBaseInfoBll
    {
        List<string> GetAllDatabaseName(uc_statusbar_datasource config);
        DbHelper SetDbHelper(uc_statusbar_datasource config);
        DbHelper SetDbHelperHasDbName(uc_statusbar_datasource config);
        List<TableInfo> GetTableList(string tableName = "");
        List<TableColums> GetColumnList(string tableName = "");
    }
}
