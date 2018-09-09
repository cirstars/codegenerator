using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.UI.DeveloperTools.Common;
using RC.UI.DeveloperTools.Control;
using RC.UI.DeveloperTools.Static;

namespace RC.UI.DeveloperTools.BLL
{
    public class MssqlDataBaseInfoBll : IDataBaseInfoBll
    {
        public DbHelper SetDbHelper(uc_statusbar_datasource config)
        {
            DbHelper db = new DbHelper();
            db.dbProviderName = "System.Data.SqlClient";
            string dbConnectionString = "server={0};uid={1};pwd={2}";
            db.dbConnectionString = (string.Format(dbConnectionString, config.dbaddr, config.username, config.userpwd));
            db.CreateConnection();
            return db;
        }

        public DbHelper SetDbHelperHasDbName(uc_statusbar_datasource config)
        {
            DbHelper db = new DbHelper();
            db.dbProviderName = "System.Data.SqlClient";
            string dbConnectionString = "server={0};uid={1};pwd={2};database = {3}";
            db.dbConnectionString =
                (string.Format(dbConnectionString, config.dbaddr, config.username, config.userpwd, config.dbname));
            db.CreateConnection();
            return db;
        }

        public List<string> GetAllDatabaseName(uc_statusbar_datasource config)
        {
            List<string> result = new List<string>();
            DbHelper db = SetDbHelper(config);
            DataTable dt =
                db.ExecuteDataTable(db.GetSqlStringCommond("Select Name FROM Master..SysDatabases order BY Name"));
            foreach (DataRow dr in dt.Rows)
            {
                result.Add(dr["Name"].ToString());
            }
            return result;
        }

        public List<TableInfo> GetTableList(string tableName = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"

DECLARE @TableInfo TABLE (
	name VARCHAR (50),
	sumrows VARCHAR (11),
	reserved VARCHAR (50),
	data VARCHAR (50),
	index_size VARCHAR (50),
	unused VARCHAR (50),
	pk VARCHAR (50)
)

 DECLARE @TableName TABLE (name VARCHAR(50))
 DECLARE @name VARCHAR (50)
 DECLARE @pk VARCHAR (50) 
 INSERT INTO @TableName (name) 
-- SELECT	o.name FROM	sysobjects o,	sysindexes i 
-- WHERE	o.id = i.id AND o.Xtype = 'U' AND i.indid < 2 
-- ORDER BY
-- 	i. ROWS DESC,
-- 	o.name

select s.[name] + '.'+t.[name]  as name from sys.tables as t,sys.schemas as s where t.schema_id = s.schema_id
union ALL
select s.[name] + '.'+ v.[name] as name from sys.views as v,sys.schemas as s where v.schema_id = s.schema_id



WHILE EXISTS (SELECT 1 FROM @TableName)
BEGIN
	SELECT TOP 1 @name = name	FROM @TableName 
  DELETE @TableName	WHERE	name = @name
	DECLARE @objectid INT
	SET @objectid = OBJECT_ID(@name) 
  --select count(1) from @TableName
  
  SELECT @pk = COL_NAME(@objectid, colid)	FROM	sysobjects AS o
	INNER JOIN sysindexes AS i ON i.name = o.name
	INNER JOIN sysindexkeys AS k ON k.indid = i.indid
	WHERE o.xtype = 'PK'	AND parent_obj = @objectid AND k.id = @objectid 

  INSERT INTO @TableInfo (
		name,
		sumrows,
		reserved,
		data,
		index_size,
		unused
	) EXEC sys.sp_spaceused @name 
  
  UPDATE @TableInfo
	SET pk = @pk
	WHERE
		name = @name
	END 

SELECT
		F.name,
		F.reserved,
		F.data,
		F.index_size,
		RTRIM(F.sumrows) AS sumrows,
		F.unused,
		ISNULL(P.tdescription, F.name) AS tdescription,
		F.pk
	FROM
		@TableInfo F
	LEFT JOIN (
		SELECT
			name = CASE
		WHEN A.colorder = 1 THEN
			D.name
		ELSE
			''
		END,
		tdescription = CASE
	WHEN A.colorder = 1 THEN
		ISNULL(F. value, '')
	ELSE
		''
	END
	FROM
		[sys].[syscolumns] A
	LEFT JOIN [sys].[systypes] B ON A.xusertype = B.xusertype
	INNER JOIN [sys].[sysobjects] D ON A.id = D.id
	AND D.xtype = 'U'
	AND D.name <> 'DTPROPERTIES'
	LEFT JOIN sys.extended_properties F ON D.id = F.major_id
	WHERE
		A.colorder = 1
	AND F.minor_id = 0
	) P ON F.name = P.name
	WHERE
		1 = 1");
            List<DbParameter> parameter = new List<DbParameter>();

            DbHelper db = SetDbHelperHasDbName(DataBaseStaticConfig.Config);
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(tableName))
            {
                strSql.Append(
                    " AND CAST(F.name AS VARCHAR(100)) like @tableCode  or CAST(P.tdescription  AS VARCHAR(100)) like @remark");
                DbCommand cmd = db.GetSqlStringCommond(strSql.ToString());
                db.AddInParameter(cmd, "@tableCode", DbType.String, tableName);
                db.AddInParameter(cmd, "@remark", DbType.String, tableName);
                dt = db.ExecuteDataTable(cmd);
            }
            else
            {
                DbCommand cmd = db.GetSqlStringCommond(strSql.ToString());
                dt = db.ExecuteDataTable(cmd);
            }

            List<TableInfo> result = new List<TableInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                result.Add(new TableInfo()
                {
                    data = dr["data"].ToString(),
                    index_size = dr["index_size"].ToString(),
                    name = dr["name"].ToString(),
                    pk = dr["pk"].ToString(),
                    reserved = dr["reserved"].ToString(),
                    sumrows = dr["sumrows"].ToString(),
                    tdescription = dr["tdescription"].ToString(),
                    unused = dr["unused"].ToString(),
                });
            }
            return result;
        }

        public List<TableColums> GetColumnList(string tableName = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT
                                d.name as tablename,
                                [number]=a.colorder,
                                [column] =a.name,
                                [datatype]=b.name,
                                [length]=COLUMNPROPERTY(a.id,a.name,'PRECISION'),
                                [identity]=case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '√'else '' end,
                                [key]=case when exists(SELECT 1 FROM sysobjects where xtype='PK' and parent_obj=a.id and name in (
                                SELECT name FROM sysindexes WHERE indid in(
                                SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid
                                ))) then '√' else '' end,
                                [isnullable]=case when a.isnullable=1 then '√'else '' end,
                                [defaultvalue]=isnull(e.text,''),
                                [remark]=isnull(g.[value],a.name)
                                FROM syscolumns a
                                left join systypes b on a.xusertype=b.xusertype
                                inner join sysobjects d on a.id=d.id  and d.xtype='U' and  d.name<>'dtproperties'
                                left join syscomments e on a.cdefault=e.id
                                left join sys.extended_properties g on a.id=g.major_id and a.colid=g.minor_id 
                                left join sys.extended_properties f on d.id=f.major_id and f.minor_id=0");
            strSql.Append("where d.name='" + tableName + "' order by a.id,a.colorder");
            DbHelper db = SetDbHelperHasDbName(DataBaseStaticConfig.Config);
            DataTable dt = db.ExecuteDataTable(db.GetSqlStringCommond(strSql.ToString()));
            List<TableColums> result = new List<TableColums>();
            foreach (DataRow dr in dt.Rows)
            {
                result.Add(new TableColums()
                {
                    column = dr["column"].ToString(),
                    datatype = dr["datatype"].ToString(),
                    defaultvalue = dr["defaultvalue"].ToString(),
                    identity = dr["identity"].ToString(),
                    isnullable = dr["isnullable"].ToString(),
                    key = dr["key"].ToString(),
                    length = dr["length"].ToString(),
                    number = dr["number"].ToString(),
                    remark = dr["remark"].ToString(),
                    tablename = dr["tablename"].ToString(),
                });
            }

            return result;
        }
    }
}
