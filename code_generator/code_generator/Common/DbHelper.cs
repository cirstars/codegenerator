using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

public class DbHelper
{
    public string dbProviderName = "";
    public string dbConnectionString = "";

    private DbConnection connection;
    public DbHelper()
    {
    }

    public DbConnection CreateConnection()
    {
        DbProviderFactory dbfactory = DbProviderFactories.GetFactory(dbProviderName);
        DbConnection dbconn = dbfactory.CreateConnection();
        dbconn.ConnectionString = dbConnectionString;
        connection = dbconn;
        return dbconn;
    }
    public DbConnection CreateConnection(string connectionString)
    {
        DbProviderFactory dbfactory = DbProviderFactories.GetFactory(dbProviderName);
        DbConnection dbconn = dbfactory.CreateConnection();
        dbconn.ConnectionString = connectionString;
        connection = dbconn;
        return dbconn;
    }

    public DbCommand GetStoredProcCommond(string storedProcedure)
    {
        DbCommand dbCommand = connection.CreateCommand();
        dbCommand.CommandText = storedProcedure;
        dbCommand.CommandType = CommandType.StoredProcedure;
        return dbCommand;
    }
    public DbCommand GetSqlStringCommond(string sqlQuery)
    {
        DbCommand dbCommand = connection.CreateCommand();
        dbCommand.CommandText = sqlQuery;
        dbCommand.CommandType = CommandType.Text;
        return dbCommand;
    }

    //增加参数#region 增加参数
    public void AddParameterCollection(DbCommand cmd, DbParameterCollection dbParameterCollection)
    {
        foreach (DbParameter dbParameter in dbParameterCollection)
        {
            cmd.Parameters.Add(dbParameter);
        }
    }
    public void AddOutParameter(DbCommand cmd, string parameterName, DbType dbType, int size)
    {
        DbParameter dbParameter = cmd.CreateParameter();
        dbParameter.DbType = dbType;
        dbParameter.ParameterName = parameterName;
        dbParameter.Size = size;
        dbParameter.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(dbParameter);
    }
    public void AddInParameter(DbCommand cmd, string parameterName, DbType dbType, object value)
    {
        DbParameter dbParameter = cmd.CreateParameter();
        dbParameter.DbType = dbType;
        dbParameter.ParameterName = parameterName;
        dbParameter.Value = value;
        dbParameter.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(dbParameter);
    }
    public void AddReturnParameter(DbCommand cmd, string parameterName, DbType dbType)
    {
        DbParameter dbParameter = cmd.CreateParameter();
        dbParameter.DbType = dbType;
        dbParameter.ParameterName = parameterName;
        dbParameter.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(dbParameter);
    }
    public DbParameter GetParameter(DbCommand cmd, string parameterName)
    {
        return cmd.Parameters[parameterName];
    }

    //执行#region 执行
    public DataSet ExecuteDataSet(DbCommand cmd)
    {
        DbProviderFactory dbfactory = DbProviderFactories.GetFactory(dbProviderName);
        DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
        dbDataAdapter.SelectCommand = cmd;
        DataSet ds = new DataSet();
        dbDataAdapter.Fill(ds);
        return ds;
    }

    public DataTable ExecuteDataTable(DbCommand cmd)
    {
        DbProviderFactory dbfactory = DbProviderFactories.GetFactory(dbProviderName);
        DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
        dbDataAdapter.SelectCommand = cmd;
        DataTable dataTable = new DataTable();
        dbDataAdapter.Fill(dataTable);
        return dataTable;
    }

    public DbDataReader ExecuteReader(DbCommand cmd)
    {
        cmd.Connection.Open();
        DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return reader;
    }
    public int ExecuteNonQuery(DbCommand cmd)
    {
        cmd.Connection.Open();
        int ret = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        return ret;
    }

    public object ExecuteScalar(DbCommand cmd)
    {
        cmd.Connection.Open();
        object ret = cmd.ExecuteScalar();
        cmd.Connection.Close();
        return ret;
    }

    ////执行事务#region 执行事务
    //public DataSet ExecuteDataSet(DbCommand cmd, Trans t)
    //{
    //    cmd.Connection = t.DbConnection;
    //    cmd.Transaction = t.DbTrans;
    //    DbProviderFactory dbfactory = DbProviderFactories.GetFactory(dbProviderName);
    //    DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
    //    dbDataAdapter.SelectCommand = cmd;
    //    DataSet ds = new DataSet();
    //    dbDataAdapter.Fill(ds);
    //    return ds;
    //}

    //public DataTable ExecuteDataTable(DbCommand cmd, Trans t)
    //{
    //    cmd.Connection = t.DbConnection;
    //    cmd.Transaction = t.DbTrans;
    //    DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbHelper.dbProviderName);
    //    DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
    //    dbDataAdapter.SelectCommand = cmd;
    //    DataTable dataTable = new DataTable();
    //    dbDataAdapter.Fill(dataTable);
    //    return dataTable;
    //}

    //public DbDataReader ExecuteReader(DbCommand cmd, Trans t)
    //{
    //    cmd.Connection.Close();
    //    cmd.Connection = t.DbConnection;
    //    cmd.Transaction = t.DbTrans;
    //    DbDataReader reader = cmd.ExecuteReader();
    //    DataTable dt = new DataTable();
    //    return reader;
    //}
    //public int ExecuteNonQuery(DbCommand cmd, Trans t)
    //{
    //    cmd.Connection.Close();
    //    cmd.Connection = t.DbConnection;
    //    cmd.Transaction = t.DbTrans;
    //    int ret = cmd.ExecuteNonQuery();
    //    return ret;
    //}

    //public object ExecuteScalar(DbCommand cmd, Trans t)
    //{
    //    cmd.Connection.Close();
    //    cmd.Connection = t.DbConnection;
    //    cmd.Transaction = t.DbTrans;
    //    object ret = cmd.ExecuteScalar();
    //    return ret;
    //}
}