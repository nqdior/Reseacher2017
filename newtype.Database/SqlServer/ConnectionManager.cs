using System.Data.SqlClient;
using newtype.Common;
using System.Collections.Generic;

namespace newtype.Database
{
    public class Connection
    {
        public SqlConnectionStringBuilder Server = new SqlConnectionStringBuilder();

        public string ConnectionString
        {
            get { return Server.ConnectionString; }
            set { Server.ConnectionString = value; }
        }

        public string dataSource
        {
            get { return Server.DataSource; }
            set { Server.DataSource = value; }
        }

        public string catalog
        {
            get { return Server.InitialCatalog; }
            set { Server.InitialCatalog = value; }
        }

        public string id
        {
            get { return Server.UserID; }
            set { Server.UserID = value; }
        }

        public string password
        {
            get { return Server.Password; }
            set { Server.Password = value; }
        }

        public bool security
        {
            get { return Server.IntegratedSecurity; }
            set { Server.IntegratedSecurity = value; }
        }

        public new string ToString
        {
            get { return Server.ConnectionString; }
        }        

        public Connection()
        {
            XmlManager xml = new XmlManager();
            ConnectionString = EncryptService.DecryptString(xml[new List<string>() { "server" }]);
        }

        public bool Save()
        {
            try
            {
                var xml = new XmlManager(false);
                xml[new List<string>() { "server" }] = EncryptService.EncryptString(ConnectionString);

                xml.Save();
                xml.Dispose();

                return true;
            }
            catch { return false; }
        }
    }
}
