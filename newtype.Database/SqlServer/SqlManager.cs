using System.Data;
using System.Data.SqlClient;
using newtype.Interface;
using newtype.Common;
using System.Windows.Forms;

namespace newtype.Database
{
    /// <summary>
    /// SQL_Connecter Wrapper class.
    /// </summary>
    public class SqlManager : ISqlManager
    {
        private SqlConnecter sqlConnecter;

        public Connection connection;

        public object Server { get { return connection.Server; } set { connection.Server = (SqlConnectionStringBuilder)value; } }

        public string Catalog { get { return connection.catalog; } }

        public DataTableCollection Tables { get { return sqlConnecter.Tables; } }

        public bool isConnected { get { return sqlConnecter.DBinfo.conFlg; } }

        public SqlManager()
        {
            connection = new Connection();
            sqlConnecter = new SqlConnecter(new DBProvider());
        }

        
        public bool ConnectToServer()
        {
            if (sqlConnecter.ConnectToSQLServer(connection, true, false, false))
            {
                return GetDataBase();
            }
            return false;
        }


        public bool GetDataBase()
        {
            return ExecuteSqlToServer(Properties.Resource.DATABASE, "DataBase");
        }


        public bool GetTables()
        {
            return ExecuteSqlToServer(Properties.Resource.TABLES, "Tables");
        }


        public bool GetColumns()
        {
            return ExecuteSqlToServer(Properties.Resource.COLUMNS, "Columns");
        }


        public bool UpdateDataToSqlServer(string table, string sql)
        {
            sqlConnecter.command.CommandText = sql;
            return sqlConnecter.ExecuteUpdatingToSQLServer(table, true);
        }


        public bool ExecuteSqlToServer(string sql, string table)
        {
            if (sql.Length <= 6) return false;
            if (sql.Substring(0, 6).ToUpper().Equals("SELECT"))
            {
                if(Tables.Contains(table)) Tables.Remove(table);
                return sqlConnecter.GetDataFromSQLServer(sql, table, true).IsAccess();
            }
            else
            {
                if (sqlConnecter.ExecuteCommandToSQLServer(sql, true))
                {
                    MessageBox.Show("クエリの実行に成功しました。", "Reseacher");
                    return true;
                }
                return false;
            }
        }


        public bool ChangeConnectingCatalog(string catalog)
        {
            connection.catalog = catalog;

            if (sqlConnecter.ConnectToSQLServer(connection, true))
            {
                return GetDataBase();
            }
            return false;
        }


        public void SaveConnection()
        {
            connection.Save();
        }

        public void DisConnect()
        {
            sqlConnecter.DisconnectFromSQLServer();
        }
    }
}
