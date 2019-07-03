using System.Data;

namespace newtype.Interface
{
    public interface ISqlManager
    {
        object Server { get; set; }
        string Catalog { get; }
        DataTableCollection Tables { get; }
        bool isConnected { get; }

        bool ChangeConnectingCatalog(string catalog);
        bool ConnectToServer();
        bool ExecuteSqlToServer(string sql, string table);
        bool GetColumns();
        bool GetDataBase();
        bool GetTables();
        bool UpdateDataToSqlServer(string table, string sql);
        void SaveConnection();
        void DisConnect();
    }
}