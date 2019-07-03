using MySql.Data.MySqlClient;
using newtype.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using newtype.Interface;
using newtype.Common;

namespace newtype.Database
{
    /// <summary>
    /// SQL_Connecter Wrapper class.
    /// </summary>
    public class MySqlManager : ISqlManager
    {
        private MySqlConnecter sqlConnecter;

        private MyConnection connection;

        public DataTableCollection Tables { get { return sqlConnecter.Tables; } }

        public object Server { get { return connection.Server; } set { connection.Server = (MySqlConnectionStringBuilder)value; } }

        public string Catalog { get { return connection.catalog; } }

        public bool isConnected { get { return sqlConnecter.DBinfo.conFlg; } }


        public MySqlManager()
        {
            connection = new MyConnection();
            sqlConnecter = new MySqlConnecter(new MyDBProvider());
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
            if (ExecuteSqlToServer(Properties.Resource.MYDATABASE, "DataBase"))
            {
                Tables["DataBase"].Columns[0].ColumnName = "Name";
                return true;
            }
            return false;
        }


        public bool GetTables()
        {
            var sql = string.Format(Properties.Resource.MYTABLES, Catalog);
            return ExecuteSqlToServer(sql, "Tables");
        }


        public bool GetColumns()
        {
            return ExecuteSqlToServer(Properties.Resource.MYCOLUMNS, "Columns");
        }


        public bool UpdateDataToSqlServer(string table, string sql)
        {
            sqlConnecter.cmd.CommandText = sql;
            return sqlConnecter.ExecuteUpdatingToSQLServer(table, true);
        }


        public bool ExecuteSqlToServer(string sql, string table)
        {
            if (sql.Length <= 6) return false;
            if (!sql.Substring(0, 6).ToUpper().Equals("SELECT") && !sql.Substring(0, 4).ToUpper().Equals("SHOW"))
            {
                if (sqlConnecter.ExecuteCommandToSQLServer(sql, true))
                {
                    MessageBox.Show("クエリの実行に成功しました。", "Reseacher");
                    return true;
                }
                return false;
            }
            else
            {
                if (Tables.Contains(table)) Tables.Remove(table);
                return sqlConnecter.GetDataFromSQLServer(sql, table, true).IsAccess();
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
